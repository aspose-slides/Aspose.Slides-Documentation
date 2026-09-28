---
title: Požadavky systému
type: docs
weight: 15
url: /cs/reportingservices/system-requirements/
keywords:
- systémové požadavky
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Zkontrolujte, které servery reportů, edice a verzi .NET Framework Aspose.Slides for Reporting Services potřebuje před instalací."
---
## **Přehled**

Aspose.Slides for Reporting Services běží uvnitř serveru reportů jako rozšíření pro vykreslování. Tato stránka uvádí, co potřebuje počítač serveru reportů před tím, než jej [install](/slides/cs/reportingservices/installing-aspose-slides-for-reporting-services/) nainstalujete. Microsoft PowerPoint a Microsoft Office nejsou vyžadovány.

## **Podporované servery reportů**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 a 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, pro stránkované (RDL) zprávy

Podporovány jsou jak 32‑bitové, tak 64‑bitové servery reportů. SQL Server 2005 používá vlastní sestavení rozšíření; všechny novější verze a Power BI Report Server používají stejné sestavení. [Install Manually](/slides/cs/reportingservices/install-manually/) ukazuje, který soubor je potřeba zkopírovat.

Pokud vaše verze serveru reportů není v tomto seznamu, zeptejte se na [free support forum](https://forum.aspose.com/c/slides/cs/11) před nasazením.

## **Edice serveru reportů**

Pro SQL Server 2016 Reporting Services a novější a pro Power BI Report Server Microsoft podporuje rozšíření pro vykreslování v edicích Enterprise, Standard, Developer a Evaluation; edice Web a Express je nepodporují. Viz [Reporting Services features supported by editions](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). Instalátor MSI přeskočí instance Express edice SQL Serveru 2016 a starší.

## **.NET Framework**

Na počítači serveru reportů musí být nainstalován .NET Framework 3.5. Assemblies rozšíření jsou postaveny pro runtime .NET Framework 2.0 a instalátor MSI zastaví s hláškou, pokud .NET Framework 3.5 chybí. Ve Windows Server přidejte **.NET Framework 3.5 Features** v Průvodci přidáním rolí a funkcí; viz [Install .NET Framework 3.5 on Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Oprávnění**

Instalace rozšíření mění soubory ve složce serveru reportů, takže oba způsoby instalace vyžadují lokální administrátorská práva. Pokud spustíte instalátor MSI bez nich, nabídne restart s administrátorskými oprávněními.

## **FAQ**

**Potřebuji na serveru reportů Microsoft PowerPoint?**

Ne. Rozšíření samo vytváří prezentace; není potřeba instalovat PowerPoint ani Microsoft Office.

**Mohu rozšíření nainstalovat na edici Express?**

Ne. Edice Express nepodporují rozšíření pro vykreslování. Instalátor MSI skryje instance Express SQL Serveru 2016 a starších; u novějších verzí nevybírejte instanci Express.

**Jaké formáty rozšíření přidává do seznamu exportu?**

PPT, PPS, PPTX, PPSX, ODP a XPS. Viz [Supported File Formats](/slides/cs/reportingservices/supported-file-formats/).