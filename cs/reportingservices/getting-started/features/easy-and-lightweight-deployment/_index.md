---
title: Jednoduché a lehké nasazení
type: docs
weight: 50
url: /cs/reportingservices/easy-and-lightweight-deployment/
description: "Zjistěte, jak se nasazuje Aspose.Slides for Reporting Services: jedna sestava ve složce bin serveru zpráv, registrovaná v konfiguraci serveru zpráv."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services je [rendering extension](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) pro Microsoft SQL Server Reporting Services a Power BI Report Server.  
Aspose.Slides for Reporting Services je poskytován jako jediný MSI instalátor, který lze nainstalovat na počítače s podporovaným serverem zpráv, 32‑bitovým nebo 64‑bitovým; viz [System Requirements](/slides/cs/reportingservices/system-requirements/).

Nasazení a správa Aspose.Slides for Reporting Services ručně je také snadná, protože se skládá pouze z jedné .NET sestavy *Aspose.Slides* *.ReportingServices.dll*, kompletně napsané v C#, kompatibilní s CLS a obsahující pouze bezpečný řízený kód.

{{% /alert %}}

ZIP soubor ke stažení obsahuje dva sestavení Aspose.Slides.ReportingServices.dll pro servery zpráv:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – sestaveno pro Microsoft SQL Server 2005 a .NET Framework 2.0 (použijte pro x86 a x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – sestaveno pro Microsoft SQL Server 2008 a novější, Power BI Report Server a .NET Framework 2.0 (použijte pro x86 a x64)

Instalátor MSI nainstaluje stejná dvě sestavení a vybere to správné pro každou instanci serveru zpráv. [Install Manually](/slides/cs/reportingservices/install-manually/) uvádí každý soubor v ZIP souboru ke stažení.

Při instalaci se Aspose.Slides.ReportingServices.dll zkopíruje do adresáře ReportServer\bin a konfigurační soubor se aktualizuje, aby Reporting Services byl informován o nové rozšiřující komponentě pro vykreslování. Tyto kroky provádí instalátor Aspose.Slides for Reporting Services, ale můžete je také provést ručně, jak je dále popsáno v této dokumentaci.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Obrázek**: Aspose.Slides.ReportingServices.dll je zkopírován do adresáře **ReportServer\bin**.