---
title: Systeemvereisten
type: docs
weight: 15
url: /nl/reportingservices/system-requirements/
keywords:
- systeemvereisten
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Controleer welke rapportservers, edities en .NET Framework‑versie Aspose.Slides for Reporting Services nodig heeft voordat u het installeert."
---
## **Overzicht**

Aspose.Slides for Reporting Services draait op de rapportserver als een weergave-extensie. Deze pagina geeft weer wat de rapportserver-machine nodig heeft voordat u het [installeert](/slides/nl/reportingservices/installing-aspose-slides-for-reporting-services/). Microsoft PowerPoint en Microsoft Office zijn niet vereist.

## **Ondersteunde rapportservers**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 en 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, voor gepagineerde (RDL) rapporten

Zowel 32-bit als 64-bit rapportservers worden ondersteund. SQL Server 2005 gebruikt zijn eigen build van de extensie; alle latere versies en Power BI Report Server gebruiken dezelfde build. [Handmatig installeren](/slides/nl/reportingservices/install-manually/) toont welk bestand moet worden gekopieerd.

Als uw rapportserver-versie niet in deze lijst staat, vraag dan op het [gratis ondersteuningsforum](https://forum.aspose.com/c/slides/11) voordat u implementeert.

## **Rapportserver-edities**

Voor SQL Server 2016 Reporting Services en latere versies en voor Power BI Report Server ondersteunt Microsoft weergave-extensies in de Enterprise-, Standard-, Developer- en Evaluation-edities; de Web- en Express-edities ondersteunen ze niet. Zie [Reporting Services-functies ondersteund per editie](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). De MSI-installatie slaat Express-edities van SQL Server 2016 en eerder over.

## **.NET Framework**

.NET Framework 3.5 moet geïnstalleerd zijn op de rapportserver-machine. De assemblies van de extensie zijn gebouwd voor .NET Framework 2.0, en de MSI-installatie stopt met een bericht als .NET Framework 3.5 ontbreekt. Op Windows Server voegt u **.NET Framework 3.5 Features** toe via de wizard Rollen en functies toevoegen; zie [ .NET Framework 3.5 installeren op Windows](/learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Rechten**

Het installeren van de extensie wijzigt bestanden in de rapportservermap, dus beide installatieroutes vereisen lokale beheerdersrechten. Als u de MSI-installatie zonder die rechten start, biedt deze aan zichzelf opnieuw te starten met beheerdersprivileges.

## **FAQ**

**Moet ik Microsoft PowerPoint op de rapportserver hebben?**

Nee. De extensie maakt de presentaties zelf; PowerPoint noch Microsoft Office hoeven geïnstalleerd te zijn.

**Kan ik de extensie installeren op een Express-editie?**

Nee. Express-edities ondersteunen geen weergave-extensies. De MSI-installatie verbergt Express-installaties van SQL Server 2016 en eerder; bij latere versies selecteert u geen Express-installatie.

**Welke formaten voegt de extensie toe aan de exportlijst?**

PPT, PPS, PPTX, PPSX, ODP en XPS. Zie [Ondersteunde bestandsformaten](/slides/nl/reportingservices/supported-file-formats/).