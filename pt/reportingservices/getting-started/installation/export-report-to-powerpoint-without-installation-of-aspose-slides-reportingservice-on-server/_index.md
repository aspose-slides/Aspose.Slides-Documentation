---
title: Exportar relatório para PowerPoint sem instalação do Aspose.Slides.ReportingService no servidor
type: docs
weight: 120
url: /pt/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---
{{% alert color="primary" %}} 
Aspose.Slides for Reporting Service pode ser usado sem instalação em um servidor. Essa abordagem é adequada quando você precisa integrar a exportação para PowerPoint em sua aplicação, mas o acesso ao serviço é restrito.
{{% /alert %}} {{% alert color="primary" %}} 
A solução do Visual Studio que ilustra a abordagem pode ser encontrada [aqui](attachments/10289165/10453062.zip).
{{% /alert %}} 
O processo de renderização compreende duas partes:
1. Renderize o relatório para RPL usando o Reporting Service Web Service. Veja mais informações sobre o Reporting Service Web Service [aqui](http://technet.microsoft.com/en-us/library/ms152787.aspx).
1. Renderize o RPL para PowerPoint usando o Aspose.Slides for Reporting service para ReportViewer. O assembly está localizado em {Aspose.Slides for Reporting Services home directory}\bin\RV2010 
## **Como Implementar a Exportação para PowerPoint:**
1) Crie o proxy do serviço web (veja os detalhes [aqui](http://technet.microsoft.com/en-us/library/ms155134.aspx)) e adicione-o à sua solução.
2) Adicione uma referência ao Aspose.Slides.ReportingServices.dll para ReportViewer 2010.
3) Use esta classe para integrar o proxy do serviço web e o Apose.Slides for Reporting Service
``` xml

 class PowerpointRenderer

{

/// <summary>

/// Obtém ou define a URL base do serviço Web XML que o cliente está solicitando.

/// </summary>

/// <value>

/// A URL base do serviço Web XML que o cliente está solicitando. O padrão é System.String.Empty.

/// </value>

public string ReportingServiceUrl { get; set; }


/// <summary>

/// Obtém ou define o nome de usuário para o Reporting Service.

/// </summary>

/// <value>

/// O nome de usuário.

/// </value>

public string Username { get; set; }

/// <summary>

/// Obtém ou define a senha para o Reporting Service.

/// </summary>

/// <value>

/// A senha.

/// </value>

public string Password { get; set; }

/// <summary>

/// Renderiza o relatório especificado para um arquivo.

/// </summary>

/// <param name="outputFileName">Nome do arquivo de saída.</param>

/// <param name="reportPath">O caminho do relatório.</param>

/// <param name="format">O formato da apresentação de saída.</param>

public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{

using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))

{

Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

//iniciar o processo de renderização

//aqui estamos escolhendo exportar no formato PPT e fornecendo outputStream

renderer.StartRendering(format, false);

int page = 1;

//este ciclo itera por todas as páginas do relatório

while (true)

{

using (MemoryStream rplStream = CreateRplStream(page, reportPath))

{

//se rplStream está vazio então alcançamos o fim do relatório

if (rplStream.Length == 0)

break;

//adicionar página do relatório como slide ao documento

renderer.RenderPage(rplStream);

}

page++;

}

//chamar método finish para gravar nossa apresentação recém-criada no stream de saída

renderer.FinishRendering(pptSteam);

}

}

private MemoryStream CreateRplStream(int page, string reportPath)

{

ReportExecutionService _executionService = new ReportExecutionService();

_executionService.Url = ReportingServiceUrl + "/ReportExecution2005.asmx";

_executionService.Credentials = new System.Net.NetworkCredential(Username, Password, string.Empty);

string extension;

Warning[] warnings;

string[] streamIds;

string mimeType;

string encoding;

var executionInfo = _executionService.LoadReport(reportPath, null);

string deviceInfo = String.Format(

@"<DeviceInfo>

<StartPage>{0}</StartPage>

<EndPage>{0}</EndPage>

<SecondaryStreams>Embedded</SecondaryStreams>

</DeviceInfo>", page);

byte[] result = _executionService.Render("RPL", deviceInfo, out extension, out mimeType, out encoding, out warnings, out streamIds);

return new MemoryStream(result);

}

}
```
4) Agora você pode exportar o relatório usando este código:
``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Server Name>/Reportserver";

powerpointRenderer.Username = "Username";

powerpointRenderer.Password = "password";

powerpointRenderer.Render("test.ppt, "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```
{{% alert color="primary" %}} 
O processo de exportação aqui usa quebras de página suaves semelhantes ao Word ou Excel, portanto seu resultado pode diferir da apresentação que foi exportada usando a abordagem padrão.
{{% /alert %}}