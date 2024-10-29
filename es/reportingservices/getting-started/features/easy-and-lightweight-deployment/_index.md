---
title: Implementación Fácil y Ligera
type: docs
weight: 50
url: /es/reportingservices/easy-and-lightweight-deployment/
---

{{% alert color="primary" %}} 

Aspose.Slides para Reporting Services es una [extensión de renderizado](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) para Microsoft SQL Server Reporting Services. 
Aspose.Slides para Reporting Services se proporciona como un único instalador MSI que puede instalarse en las computadoras que ejecuten uno de los siguientes:

- Microsoft SQL Server 2005 Reporting Services (32 bits y 64 bits)
- Microsoft SQL Server 2008 Reporting Services (32 bits y 64 bits)

También es fácil implementar y gestionar Aspose.Slides para Reporting Services manualmente, ya que se compone de solo un ensamblado .NET *Aspose.Slides* *.ReportingServices.dll*, escrito completamente en C#, compatible con CLS y que contiene solo código gestionado seguro. 

{{% /alert %}} 

El instalador MSI y la descarga ZIP incluyen Aspose.Slides para ReportingServices:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – construido para Microsoft SQL Server 2005 y .NET Framework 2.0 (uso para x86 y x64)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – construido para Microsoft SQL Server 2008 y .NET Framework 2.0 (uso para x86 y x64)

Al instalar, Aspose.Slides.ReportingServices.dll se copia en el directorio ReportServer\bin y el archivo de configuración se actualiza para que Reporting Services esté al tanto de la nueva extensión de renderizado. Estos pasos son realizados por el instalador de Aspose.Slides para Reporting Services, pero también podrías realizarlos manualmente como se describe más adelante en esta documentación.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figura**: Aspose.Slides.ReportingServices.dll se copia en el directorio **ReportServer\bin**.