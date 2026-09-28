---
title: Einfache und leichte Bereitstellung
type: docs
weight: 50
url: /de/reportingservices/easy-and-lightweight-deployment/
description: "Erfahren Sie, wie Aspose.Slides for Reporting Services bereitgestellt wird: eine Assembly im Bin-Ordner des Berichtservers, registriert in der Konfiguration des Berichtservers."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for Reporting Services ist eine [Rendering‑Erweiterung](https://learn.microsoft.com/en-us/sql/reporting-services/extensions/rendering-extension/rendering-extensions-overview) für Microsoft SQL Server Reporting Services und Power BI Report Server.  
Aspose.Slides for Reporting Services wird als einzelnes MSI‑Installationsprogramm bereitgestellt, das auf Computern mit einem unterstützten Berichtserver, 32‑Bit oder 64‑Bit, installiert werden kann; siehe [Systemanforderungen](/slides/de/reportingservices/system-requirements/).

Auch die manuelle Bereitstellung und Verwaltung von Aspose.Slides for Reporting Services ist einfach, da es nur aus einer .NET‑Assembly *Aspose.Slides* *.ReportingServices.dll* besteht, die vollständig in C# geschrieben, CLS‑konform und ausschließlich sicheren verwalteten Code enthält.

{{% /alert %}}

Der ZIP‑Download enthält zwei Builds von Aspose.Slides.ReportingServices.dll für Berichtserver:

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll – gebaut für Microsoft SQL Server 2005 und .NET Framework 2.0 (für x86 und x64 verwenden)
- Bin\Universal\Aspose.Slides.ReportingServices.dll – gebaut für Microsoft SQL Server 2008 und höher, Power BI Report Server und .NET Framework 2.0 (für x86 und x64 verwenden)

Das MSI‑Installationsprogramm installiert dieselben beiden Builds und wählt für jede Berichtserver‑Instanz das passende aus. [Manuell installieren](/slides/de/reportingservices/install-manually/) listet jede Datei im ZIP‑Download auf.

Beim Installieren wird Aspose.Slides.ReportingServices.dll in das Verzeichnis ReportServer\bin kopiert und die Konfigurationsdatei aktualisiert, sodass Reporting Services die neue Rendering‑Erweiterung erkennt. Diese Schritte werden vom Aspose.Slides for Reporting Services‑Installer ausgeführt, können aber auch manuell durchgeführt werden, wie im weiteren Verlauf dieser Dokumentation beschrieben.

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)

**Abbildung**: Aspose.Slides.ReportingServices.dll wird in das **ReportServer\bin**‑Verzeichnis kopiert.