---
title: Implementación fácil y ligera
type: docs
weight: 50
url: /es/reportingservices/easy-and-lightweight-deployment/
description: "Aprenda cómo se implementa Aspose.Slides for Reporting Services: un ensamblado en la carpeta bin del servidor de informes, registrado en la configuración del servidor de informes."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services es una [extensión de renderizado](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) para Microsoft SQL Server Reporting Services y Power BI Report Server.
Aspose.Slides for Reporting Services se ofrece como un único instalador MSI que puede instalarse en equipos que ejecuten un servidor de informes compatible, de 32 bits o 64 bits; consulte [Requisitos del sistema](/slides/es/reportingservices/system-requirements/).

También es fácil implementar y administrar Aspose.Slides for Reporting Services manualmente, ya que consta de un solo ensamblado .NET *Aspose.Slides* *.ReportingServices.dll* , escrito completamente en C#, compatible con CLS y que contiene solo código administrado seguro.

{{% /alert %}}

La descarga ZIP incluye dos compilaciones de Aspose.Slides.ReportingServices.dll para servidores de informes:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – compilada para Microsoft SQL Server 2005 y .NET Framework 2.0 (uso para x86 y x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – compilada para Microsoft SQL Server 2008 y versiones posteriores, Power BI Report Server y .NET Framework 2.0 (uso para x86 y x64)

El instalador MSI instala las mismas dos compilaciones y selecciona la adecuada para cada instancia del servidor de informes. [Instalar manualmente](/slides/es/reportingservices/install-manually/) enumera cada archivo de la descarga ZIP.

Al instalar, Aspose.Slides.ReportingServices.dll se copia al directorio ReportServer\bin y el archivo de configuración se actualiza para que Reporting Services sea consciente de la nueva extensión de renderizado. Estos pasos los realiza el instalador de Aspose.Slides for Reporting Services, pero también puede ejecutarlos manualmente como se describe más adelante en esta documentación.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figura**: Aspose.Slides.ReportingServices.dll se copia en el directorio **ReportServer\bin**.