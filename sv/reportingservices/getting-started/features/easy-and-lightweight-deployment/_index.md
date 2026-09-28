---
title: Enkel och lättviktig distribution
type: docs
weight: 50
url: /sv/reportingservices/easy-and-lightweight-deployment/
description: "Lär dig hur Aspose.Slides for Reporting Services distribueras: en assembly i rapportserverns bin-mapp, registrerad i rapportserverns konfiguration."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services är en [rendering‑tillägg](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) för Microsoft SQL Server Reporting Services och Power BI Report Server.  
Aspose.Slides for Reporting Services tillhandahålls som en enda MSI‑installationsfil som kan installeras på datorer som kör en stödd rapportserver, 32‑bit eller 64‑bit; se [Systemkrav](/slides/sv/reportingservices/system-requirements/).

Det är också enkelt att distribuera och hantera Aspose.Slides for Reporting Services manuellt, eftersom det endast består av en .NET‑assembly *Aspose.Slides* *.ReportingServices.dll*, skriven helt i C#, CLS‑kompatibel och som endast innehåller säker hanterad kod.

{{% /alert %}}

ZIP‑nedladdningen inkluderar två versioner av Aspose.Slides.ReportingServices.dll för rapportservrar:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – byggd för Microsoft SQL Server 2005 och .NET Framework 2.0 (använd för x86 och x64)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – byggd för Microsoft SQL Server 2008 och senare, Power BI Report Server och .NET Framework 2.0 (använd för x86 och x64)

MSI‑installationsprogrammet installerar samma två versioner och väljer rätt version för varje rapportserverinstans. [Installera manuellt](/slides/sv/reportingservices/install-manually/) listar varje fil i ZIP‑nedladdningen.

Vid installation kopieras Aspose.Slides.ReportingServices.dll till katalogen ReportServer\bin och konfigurationsfilen uppdateras så att Reporting Services känner till det nya rendering‑tillägget. Dessa steg utförs av Aspose.Slides for Reporting Services‑installationsprogrammet, men du kan även utföra dem manuellt enligt beskrivningen vidare i denna dokumentation.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figur**: Aspose.Slides.ReportingServices.dll kopieras in i **ReportServer\bin**-katalogen.