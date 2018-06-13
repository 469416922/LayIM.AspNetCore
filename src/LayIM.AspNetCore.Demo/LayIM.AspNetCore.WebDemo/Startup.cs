using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LayIM.AspNetCore.WebDemo.User;

namespace LayIM.AspNetCore.WebDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //ע��LayIM��Ĭ�Ϸ���
            services.AddLayIM()
                //ʹ������ͨ�ţ�����Զ���Ļ�������ĳ��Զ���ļ��ɡ���Ҫʵ�� ILayIMServer�ӿڣ�
                .AddRongCloud(config =>
                    {
                        config.AppKey = "pvxdm17jpv1or";
                        config.AppSecret = "I8a4qFGzFe8";
                    })
                //ʹ��SqlServer���������Ϣ
                .AddSqlServer("server=192.168.1.18;user id=sa;password=123123;database=LayIM;Min Pool Size=16;Connect Timeout=500;");

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            //app.UseHelloWorld();

            app.UseStaticFiles();
            //�ͻ���ģ��ʹ��session���浱ǰ�û�ID
            app.UseSession();

            //ʹ��LayIM���Զ�������
            app.UseLayIM(options => {
                options.UserFactory = new MyUserFactory();
                //options.UIConfig.
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
