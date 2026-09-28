---
title: Systemkrav
type: docs
weight: 15
url: /sv/reportingservices/system-requirements/
keywords:
- systemkrav
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Kontrollera vilka rapportservrar, utgåvor och .NET Framework version Aspose.Slides for Reporting Services kräver innan du installerar den."
---
## **Översikt**

Aspose.Slides for Reporting Services körs i rapportservern som en renderingsutökning. Denna sida listar vad rapportservermaskinen behöver innan du [installera](/slides/sv/reportingservices/installing-aspose-slides-for-reporting-services/) den. Microsoft PowerPoint och Microsoft Office krävs inte.

## **Stödda rapportservrar**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 och 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, för paginerade (RDL) rapporter

Både 32-bit- och 64-bit-rapportservrar stöds. SQL Server 2005 använder sin egen build av utökningen; alla senare versioner och Power BI Report Server använder samma build. [Installera manuellt](/slides/sv/reportingservices/install-manually/) visar vilken fil som ska kopieras.

Om din rapportserverversion inte finns i listan, fråga på det [gratis supportforumet](https://forum.aspose.com/c/slides/sv/11) innan du distribuerar.

## **Rapportserverutgåvor**

För SQL Server 2016 Reporting Services och senare samt för Power BI Report Server stödjer Microsoft renderingsutökningar i Enterprise-, Standard-, Developer- och Evaluation-utgåvorna; Web- och Express-utgåvorna stöder dem inte. Se [Funktioner i Reporting Services som stöds av utgåvor](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). MSI‑installationsprogrammet hoppar över Express‑utgåvor av SQL Server 2016 och tidigare.

## **.NET Framework**

.NET Framework 3.5 måste vara installerat på rapportservermaskinen. Utökningens sammansättningar är byggda för .NET Framework 2.0‑runtime, och MSI‑installationsprogrammet stoppar med ett meddelande om .NET Framework 3.5 saknas. På Windows Server, lägg till **.NET Framework 3.5 Features** i guiden Lägg till roller och funktioner; se [Installera .NET Framework 3.5 på Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Behörigheter**

När utökningen installeras ändras filer i rapportserverns mapp, så båda installationsvägarna kräver lokala administratörsrättigheter. Om du startar MSI‑installationsprogrammet utan dem erbjuder det att starta om sig självt med administratörsbehörighet.

## **FAQ**

**Behöver jag Microsoft PowerPoint på rapportservern?**

Nej. Utökningen skapar presentationerna själv; varken PowerPoint eller Microsoft Office behöver installeras.

**Kan jag installera utökningen på en Express‑utgåva?**

Nej. Express‑utgåvor stöder inte renderingsutökningar. MSI‑installationsprogrammet döljer Express‑instanser av SQL Server 2016 och tidigare; på senare versioner får du inte välja en Express‑instans.

**Vilka format lägger utökningen till exportlistan?**

PPT, PPS, PPTX, PPSX, ODP och XPS. Se [Stödda filformat](/slides/sv/reportingservices/supported-file-formats/).