---
title: Implantação Fácil e Leve
type: docs
weight: 50
url: /pt/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}} 
Aspose.Slides for Reporting Services é uma [extensão de renderização](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) para o Microsoft SQL Server Reporting Services. 
Aspose.Slides for Reporting Services é fornecido como um único instalador MSI que pode ser instalado nos computadores que executam uma das seguintes opções: 

- Microsoft SQL Server 2005 Reporting Services (32 bits e 64 bits)
- Microsoft SQL Server 2008 Reporting Services (32 bits e 64 bits)

Também é fácil implantar e gerenciar o Aspose.Slides for Reporting Services manualmente, pois ele consiste em apenas um assembly .NET *Aspose.Slides* *.ReportingServices.dll* , escrito totalmente em C#, compatível com CLS e contendo apenas código gerenciado seguro. 

{{% /alert %}} 
O instalador MSI e o download ZIP incluem o Aspose.Slides for ReportingServices: 

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – compilado para Microsoft SQL Server 2005 e .NET Framework 2.0 (uso para x86 e x64)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – compilado para Microsoft SQL Server 2008 e .NET Framework 2.0 (uso para x86 e x64)

Ao instalar, o Aspose.Slides.ReportingServices.dll é copiado para o diretório ReportServer\bin e o arquivo de configuração é atualizado para que o Reporting Services reconheça a nova extensão de renderização. Essas etapas são executadas pelo instalador do Aspose.Slides for Reporting Services, mas você também pode realizá‑las manualmente conforme descrito mais adiante nesta documentação. 

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figura**: Aspose.Slides.ReportingServices.dll é copiado para o diretório **ReportServer\bin**.