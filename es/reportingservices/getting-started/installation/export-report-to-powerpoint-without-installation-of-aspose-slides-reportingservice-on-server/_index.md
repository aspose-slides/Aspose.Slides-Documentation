---
title: Exportar informe a Powerpoint sin instalación de Aspose.Slides.ReportingService en el servidor
type: docs
weight: 120
url: /es/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---

{{% alert color="primary" %}} 

Aspose.Slides para Reporting Service se puede usar sin instalación en un servidor. Este enfoque es adecuado cuando necesitas integrar la exportación a Powerpoint en tu aplicación, pero el acceso al servicio está restringido.

{{% /alert %}} {{% alert color="primary" %}} 

La solución de Visual Studio que ilustra el enfoque se puede encontrar [aquí](attachments/10289165/10453062.zip).

{{% /alert %}} 

El proceso de renderizado consta de dos partes: 

1. Renderizar el informe a RPL usando el Servicio Web de Reporting. Consulta más información sobre el Servicio Web de Reporting [aquí](http://technet.microsoft.com/en-us/library/ms152787.aspx).
2. Renderizar RPL a Powerpoint usando Aspose.Slides para Reporting service para ReportViewer. El ensamblado se encuentra en ﻿﻿﻿﻿﻿{directorio de inicio de Aspose.Slides para Reporting Services}\bin\RV2010  
## **Cómo Implementar la Exportación a PowerPoint:**
 1) Crea el proxy del servicio web (consulta los detalles [aquí](http://technet.microsoft.com/en-us/library/ms155134.aspx)) y añádelo a tu solución.

 2) Agrega una referencia a Aspose.Slides.ReportingServices.dll para ReportViewer 2010.

 3) Usa esta clase para integrar el proxy del servicio web y Aspose.Slides para Reporting Service

``` xml

 class PowerpointRenderer

{

/// <summary>

/// Obtiene o establece la URL base del servicio web XML que está solicitando el cliente.

/// </summary>

/// <value>

/// La URL base del servicio web XML que está solicitando el cliente. El valor predeterminado es System.String.Empty.

/// </value>

public string ReportingServiceUrl { get; set; }


/// <summary>

/// Obtiene o establece el nombre de usuario para el Servicio de Reporting.

/// </summary>

/// <value>

/// El nombre de usuario.

/// </value>

public string Username { get; set; }

/// <summary>

/// Obtiene o establece la contraseña para el Servicio de Reporting.

/// </summary>

/// <value>

/// La contraseña.

/// </value>

public string Password { get; set; }

/// <summary>

/// Renderiza el informe especificado en un archivo.

/// </summary>

/// <param name="outputFileName">Nombre del archivo de salida.</param>

/// <param name="reportPath">La ruta del informe.</param>

/// <param name="format">El formato de presentación de salida.</param>

public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{

using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))

{

Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

//iniciar el proceso de renderizado

//aquí estamos eligiendo exportar en formato PPT y proporcionando outputStream

renderer.StartRendering(format, false);

int page = 1;

//este ciclo itera a través de todas las páginas del informe

while (true)

{

using (MemoryStream rplStream = CreateRplStream(page, reportPath))

{

//si rplStream está vacío, hemos llegado al final del informe

if (rplStream.Length == 0)

break;

//agregar página del informe como diapositiva al documento

renderer.RenderPage(rplStream);

}

page++;

}

//llamar al método finish para volcar nuestra presentación recién creada al flujo de salida

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

```

 4) Ahora puedes exportar el informe a través de este código:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Nombre del Servidor>/Reportserver";

powerpointRenderer.Username = "Nombre de usuario";

powerpointRenderer.Password = "contraseña";

powerpointRenderer.Render("test.ppt", "/Informes de Muestra AdventureWorks/Detalles del Pedido SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 

El proceso de exportación aquí utiliza saltos de página suaves similares a Word o Excel, por lo que su resultado puede diferir de la Presentación que se exportó utilizando el enfoque estándar.

{{% /alert %}}