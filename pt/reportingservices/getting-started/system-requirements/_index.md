---
title: Requisitos do Sistema
type: docs
weight: 15
url: /pt/reportingservices/system-requirements/
keywords:
- requisitos do sistema
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Verifique quais servidores de relatório, edições e versão do .NET Framework o Aspose.Slides for Reporting Services precisa antes de instalá-lo."
---
## **Visão geral**

Aspose.Slides for Reporting Services executa dentro do servidor de relatórios como uma extensão de renderização. Esta página lista o que a máquina do servidor de relatórios precisa antes de você [instalar](/slides/pt/reportingservices/installing-aspose-slides-for-reporting-services/) a extensão. Microsoft PowerPoint e Microsoft Office não são necessários.

## **Servidores de Relatórios Compatíveis**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, for paginated (RDL) reports

Both 32-bit and 64-bit report servers are supported. SQL Server 2005 uses its own build of the extension; all later versions and Power BI Report Server use the same build. [Instalar manualmente](/slides/pt/reportingservices/install-manually/) shows which file to copy.

If your report server version is not in this list, ask on the [fórum de suporte gratuito](https://forum.aspose.com/c/slides/pt/11) before you deploy.

## **Edições do Servidor de Relatórios**

For SQL Server 2016 Reporting Services and later and for Power BI Report Server, Microsoft supports rendering extensions in the Enterprise, Standard, Developer and Evaluation editions; the Web and Express editions do not support them. See [Reporting Services features supported by editions](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). The MSI installer skips Express edition instances of SQL Server 2016 and earlier.

## **.NET Framework**

.NET Framework 3.5 must be installed on the report server machine. The extension's assemblies are built for the .NET Framework 2.0 runtime, and the MSI installer stops with a message if .NET Framework 3.5 is missing. On Windows Server, add **.NET Framework 3.5 Features** in the Add Roles and Features Wizard; see [Install .NET Framework 3.5 on Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Permissões**

Installing the extension changes files in the report server folder, so both installation routes need local administrator rights. If you start the MSI installer without them, it offers to restart itself with administrator privileges.

## **FAQ**

**Preciso do Microsoft PowerPoint no servidor de relatórios?**

Não. A extensão cria as apresentações por conta própria; nem o PowerPoint nem o Microsoft Office precisam ser instalados.

**Posso instalar a extensão em uma edição Express?**

Não. As edições Express não suportam extensões de renderização. O instalador MSI oculta instâncias Express do SQL Server 2016 e anteriores; em versões posteriores, não selecione uma instância Express.

**Quais formatos a extensão adiciona à lista de exportação?**

PPT, PPS, PPTX, PPSX, ODP e XPS. See [Supported File Formats](/slides/pt/reportingservices/supported-file-formats/).