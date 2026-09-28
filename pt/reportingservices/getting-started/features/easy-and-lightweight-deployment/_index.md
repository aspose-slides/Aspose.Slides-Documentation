---
title: Implantação Fácil e Leve
type: docs
weight: 50
url: /pt/reportingservices/easy-and-lightweight-deployment/
description: "Aprenda como o Aspose.Slides for Reporting Services é implantado: um assembly na pasta bin do servidor de relatórios, registrado na configuração do servidor de relatórios."
---
{{% alert color="info" title="Nota" %}}

Aspose.Slides for Reporting Services é uma [extensão de renderização](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) para Microsoft SQL Server Reporting Services e Power BI Report Server.  
Aspose.Slides for Reporting Services é fornecido como um único instalador MSI que pode ser instalado em computadores que executam um servidor de relatórios compatível, 32-bit ou 64-bit; veja [Requisitos do Sistema](/slides/pt/reportingservices/system-requirements/).

Também é fácil implantar e gerenciar o Aspose.Slides for Reporting Services manualmente, pois ele consiste em apenas um assembly .NET *Aspose.Slides* *.ReportingServices.dll* , escrito completamente em C#, compatível com CLS e contendo apenas código gerenciado seguro.

{{% /alert %}}

O download ZIP inclui duas compilações de Aspose.Slides.ReportingServices.dll para servidores de relatório:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – compilado para Microsoft SQL Server 2005 e .NET Framework 2.0 (usar para x86 e x64)  
- Bin\Universal\Aspose.Slides.ReportingServices.dll – compilado para Microsoft SQL Server 2008 e posterior, Power BI Report Server e .NET Framework 2.0 (usar para x86 e x64)

O instalador MSI instala as mesmas duas compilações e seleciona a correta para cada instância do servidor de relatórios. [Instalar Manualmente](/slides/pt/reportingservices/install-manually/) lista cada arquivo no download ZIP.

Ao instalar, Aspose.Slides.ReportingServices.dll é copiado para o diretório ReportServer\bin e o arquivo de configuração é atualizado para que Reporting Services reconheça a nova extensão de renderização. Essas etapas são realizadas pelo instalador do Aspose.Slides for Reporting Services, mas você também pode executá‑las manualmente conforme descrito mais adiante nesta documentação.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figura**: Aspose.Slides.ReportingServices.dll é copiado para o diretório **ReportServer\bin**.