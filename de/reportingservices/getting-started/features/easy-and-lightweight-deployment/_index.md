---
title: Einfache und leichte Bereitstellung
type: docs
weight: 50
url: /de/reportingservices/easy-and-lightweight-deployment/
---

{{% alert color="primary" %}} 

Aspose.Slides für Reporting Services ist eine [Rendering-Erweiterung](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) für Microsoft SQL Server Reporting Services. 
Aspose.Slides für Reporting Services wird als ein einzelner MSI-Installer bereitgestellt, der auf Computern installiert werden kann, die eines der folgenden Systeme verwenden: 

- Microsoft SQL Server 2005 Reporting Services (32-Bit und 64-Bit)
- Microsoft SQL Server 2008 Reporting Services (32-Bit und 64-Bit)

Es ist auch einfach, Aspose.Slides für Reporting Services manuell bereitzustellen und zu verwalten, da es aus nur einer .NET-Assembly *Aspose.Slides* *.ReportingServices.dll* besteht, die vollständig in C# geschrieben, CLS-konform und enthält nur sicheren verwalteten Code. 

{{% /alert %}} 

Der MSI-Installer und der ZIP-Download enthalten Aspose.Slides für Reporting Services: 

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – erstellt für Microsoft SQL Server 2005 und .NET Framework 2.0 (benutzen für x86 und x64)
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll – erstellt für Microsoft SQL Server 2008 und .NET Framework 2.0 (benutzen für x86 und x64)

Beim Installieren wird Aspose.Slides.ReportingServices.dll in das ReportServer\bin-Verzeichnis kopiert und die Konfigurationsdatei wird aktualisiert, damit Reporting Services über die neue Rendering-Erweiterung informiert ist. Diese Schritte werden vom Installer für Aspose.Slides für Reporting Services durchgeführt, können aber auch manuell durchgeführt werden, wie weiter in dieser Dokumentation beschrieben. 

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Abbildung**: Aspose.Slides.ReportingServices.dll wird in das **ReportServer\bin**-Verzeichnis kopiert.
