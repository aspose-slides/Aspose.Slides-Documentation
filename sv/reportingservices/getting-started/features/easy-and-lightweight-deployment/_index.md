---
title: Enkel och lättviktig distribution
type: docs
weight: 50
url: /sv/reportingservices/easy-and-lightweight-deployment/
---
{{% alert color="primary" %}} 

Aspose.Slides for Reporting Services är en [renderingutökning](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) för Microsoft SQL Server Reporting Services. 
Aspose.Slides for Reporting Services levereras som en enda MSI‑installerare som kan installeras på datorer som kör någon av följande: 

- Microsoft SQL Server 2005 Reporting Services (32-bit och 64-bit)
- Microsoft SQL Server 2008 Reporting Services (32-bit och 64-bit)

Det är också enkelt att distribuera och hantera Aspose.Slides for Reporting Services manuellt, eftersom den består av endast en .NET‑assembly *Aspose.Slides* *.ReportingServices.dll* , skriven helt i C#, CLS‑kompatibel och innehåller endast säker hanterad kod. 

{{% /alert %}} 

MSI‑installationsprogrammet och ZIP‑nedladdningen inkluderar Aspose.Slides for ReportingServices: 

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – byggd för Microsoft SQL Server 2005 och .NET Framework 2.0 (använd för x86 och x64)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – byggd för Microsoft SQL Server 2008 och .NET Framework 2.0 (använd för x86 och x64)

När du installerar kopieras Aspose.Slides.ReportingServices.dll till katalogen ReportServer\bin och konfigurationsfilen uppdateras så att Reporting Services är medveten om den nya renderingutökningen. Dessa steg utförs av installatören för Aspose.Slides for Reporting Services, men du kan också utföra dem manuellt som beskrivs senare i denna dokumentation. 

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Figur**: Aspose.Slides.ReportingServices.dll kopieras till **ReportServer\bin**-katalogen.