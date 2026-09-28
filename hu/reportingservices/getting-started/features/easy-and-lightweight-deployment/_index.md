---
title: Egyszerű és könnyű telepítés
type: docs
weight: 50
url: /hu/reportingservices/easy-and-lightweight-deployment/
description: "Ismerje meg, hogyan települ az Aspose.Slides for Reporting Services: egy assembly a jelentéskiszolgáló bin mappájában, regisztrálva a jelentéskiszolgáló konfigurációjában."
---
{{% alert color="info" title="Note" %}}

Az Aspose.Slides for Reporting Services egy [renderelési kiterjesztés](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) a Microsoft SQL Server Reporting Services és a Power BI Report Server számára.  
Az Aspose.Slides for Reporting Services egyetlen MSI telepítőként érhető el, amely telepíthető olyan számítógépekre, amelyeken támogatott jelentéskiszolgáló fut, 32‑bit vagy 64‑bit; lásd a [Rendszerkövetelmények](/slides/hu/reportingservices/system-requirements/).

Kézzel is egyszerűen telepíthető és kezelhető az Aspose.Slides for Reporting Services, mivel csak egy .NET assembly‑ből, a *Aspose.Slides* *.ReportingServices.dll*‑ből áll, amely teljesen C#‑ban íródott, CLS‑kompatibilis, és csak biztonságos managed kódot tartalmaz.

{{% /alert %}}

A ZIP letöltés tartalmazza az Aspose.Slides.ReportingServices.dll két változatát a jelentéskiszolgálókhoz:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – a Microsoft SQL Server 2005‑höz és a .NET Framework 2.0‑hoz építve (x86 és x64 használatra)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – a Microsoft SQL Server 2008 és későbbi verziók, a Power BI Report Server és a .NET Framework 2.0 számára építve (x86 és x64 használatra)

Az MSI telepítő ugyanazokat a két változatot telepíti, és a megfelelő példányt választja ki minden jelentéskiszolgáló‑példányhoz. A [Telepítés kézzel](/slides/hu/reportingservices/install-manually/) minden fájlt felsorol a ZIP letöltésben.

A telepítés során az Aspose.Slides.ReportingServices.dll a ReportServer\bin könyvtárba másolódik, és a konfigurációs fájl frissül, hogy a Reporting Services tudomására hozza az új renderelési kiterjesztést. Ezeket a lépéseket az Aspose.Slides for Reporting Services telepítője végzi, de kézzel is elvégezhetők, amint azt a dokumentáció későbbi része leírja.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Ábra**: Az Aspose.Slides.ReportingServices.dll a **ReportServer\bin** könyvtárba kerül másolásra.