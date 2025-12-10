using Microsoft.AspNetCore.Mvc;

namespace ComponentAsp.Controllers;

[ApiController]
[Route("")]
public class WelcomeController : ControllerBase
{
    [HttpGet]
    public ContentResult Welcome()
    {
        const string html = """
        <!DOCTYPE html>
        <html>
        <head>
            <title>ASP.NET</title>
            <meta name="viewport" content="width=device-width, initial-scale=1" />
            <style>
            * {
                font-family: sans-serif;
                font-size: 16px;
            }

            html,
            body {
                margin: 0;
                min-height: 100vh;
                background: #202328;
                color: #fff;
            }

            body {
                display: flex;
                flex-direction: column;
                gap: 8px;
                padding: 32px;
                align-items: center;
                justify-content: center;
                box-sizing: border-box;
            }

            h1 {
                font-size: 24px;
            }

            p,
            form,
            hr {
                max-width: min(400px, 100%);
            }

            p {
                text-align: center;
                opacity: 0.8;
                line-height: 1.5;
            }

            button,
            .button {
                padding: 10px 18px;
                align-self: center;
                text-decoration: none;
                background: #6650fa;
                border-radius: 64px;
                border: none;
                color: #fff;
                cursor: pointer;
            }

            a {
                font-size: inherit;
                color: inherit;
            }

            hr {
                display: block;
                margin: 32px 0;
                width: 100%;
                height: 2px;
                background: #31363f;
                border: none;
            }

            a:last-child {
                margin-top: 32px;
            }

            code {
                font-family: monospace;
                font-size: 14px;
                background: #31363f;
                padding: 2px 4px;
                border-radius: 4px;
            }
            </style>
        </head>
        <body>
            <img
                alt="ASP.NET logo"
                src="https://github.com/diploi/component-asp/raw/main/.diploi/icon.svg"
                width="64"
                height="64"
            />
            
            <h1>ASP.NET</h1>

            <p>
                Your ASP.NET application is up and running! You can start editing the code
                to build your backend API. 
                In development stage, ASP.NET will automatically reload as you make changes.
                <br><br>
                <b> Install dependencies: </b><br> 
                Please use <code>dotnet add package &lt;packageId&gt;</code> to add packages to your environment.
                Afterward, manually press the restart button on the running ASP.NET pod so it picks up the newly installed dependencies.
            </p>

            <hr />

            <a href="https://diploi.com/"
            ><img width="54" height="16" src="https://diploi.com/logo-white.svg"
            /></a>
        </body>
        </html>
    """;
        return Content(html, "text/html");
    }

}
