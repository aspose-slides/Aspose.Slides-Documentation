---
title: Egyszerű és könnyűsúlyú telepítés
type: docs
weight: 50
url: /hu/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Services egy [rendering extension](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) a Microsoft SQL Server Reporting Services számára.  
Aspose.Slides for Reporting Services egyetlen MSI telepítőként érhető el, amely a következő egyikét futtató számítógépekre telepíthető: 

- Microsoft SQL Server 2005 Reporting Services (32-bit és 64-bit)
- Microsoft SQL Server 2008 Reporting Services (32-bit és 64-bit)

Az Aspose.Slides for Reporting Services kézzel is könnyen telepíthető és kezelhető, mivel csak egy .NET összeállítóból áll: *Aspose.Slides* *.ReportingServices.dll*, amely teljesen C#‑ban íródott, CLS‑kompatibilis, és kizárólag biztonságos kezelt kódot tartalmaz. 

{{% /alert %}} 

Az MSI telepítő és a ZIP letöltés tartalmazza az Aspose.Slides for ReportingServices-t: 

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2005 és .NET Framework 2.0 számára építve (x86 és x64 használathoz)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – Microsoft SQL Server 2008 és .NET Framework 2.0 számára építve (x86 és x64 használathoz)

Telepítéskor az Aspose.Slides.ReportingServices.dll a ReportServer\bin könyvtárba kerül, és a konfigurációs fájl frissül, hogy a Reporting Services felismerje az új megjelenítési kiterjesztést. Ezeket a lépéseket az Aspose.Slides for Reporting Services telepítő végzi, de a dokumentációban később leírtak szerint kézzel is elvégezhetők. 

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figure**: Az Aspose.Slides.ReportingServices.dll a **ReportServer\bin** könyvtárba kerül.