using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace SPMedicalGroup.Senai.WebApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }


		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc()
				.AddJsonOptions(options =>
				{
					options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
					options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
				})
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.
			 AddAuthentication(op => {
				 op.DefaultAuthenticateScheme = "JwtBearer";
				 op.DefaultChallengeScheme = "JwtBearer";
			 }).
				AddJwtBearer("JwtBearer", op =>
				{
					op.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("9d1f71ad00ffb3977d61ba56e44d4e6f")),
						ClockSkew = TimeSpan.FromMinutes(10),
						ValidIssuer = "SPMedicalGroup.Senai.WebApi",
						ValidAudience = "SPMedicalGroup.Senai.WebApi"
					};
				});

		}


		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseAuthentication();
			app.UseMvc();
		}
	}
}
