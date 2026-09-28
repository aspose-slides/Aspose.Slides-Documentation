---
title: Systemanforderungen
type: docs
weight: 15
url: /de/reportingservices/system-requirements/
keywords:
- Systemanforderungen
- SQL Server Reporting Services
- SSRS
- Power BI Report Server
- .NET Framework 3.5
- Aspose.Slides for Reporting Services
description: "Überprüfen Sie, welche Berichtserver, Editionen und .NET Framework-Version Aspose.Slides for Reporting Services benötigt, bevor Sie es installieren."
---
## **Übersicht**

Aspose.Slides for Reporting Services läuft innerhalb des Berichtservers als Rendering-Erweiterung. Diese Seite listet auf, was die Berichtserver-Maschine benötigt, bevor Sie es [installieren](/slides/de/reportingservices/installing-aspose-slides-for-reporting-services/) . Microsoft PowerPoint und Microsoft Office sind nicht erforderlich.

## **Unterstützte Berichtserver**

- Microsoft SQL Server 2005 Reporting Services
- Microsoft SQL Server 2008 and 2008 R2 Reporting Services
- Microsoft SQL Server 2012 Reporting Services
- Microsoft SQL Server 2014 Reporting Services
- Microsoft SQL Server 2016 Reporting Services
- Microsoft SQL Server 2017 Reporting Services
- Microsoft SQL Server 2019 Reporting Services
- Power BI Report Server, für paginierte (RDL) Berichte

Sowohl 32-bit- als auch 64-bit-Berichtserver werden unterstützt. SQL Server 2005 verwendet seine eigene Build der Erweiterung; alle späteren Versionen und Power BI Report Server verwenden dieselbe Build. [Manuell installieren](/slides/de/reportingservices/install-manually/) zeigt, welche Datei kopiert werden muss.

Wenn Ihre Berichtserver-Version nicht in dieser Liste steht, fragen Sie im [kostenlosen Support-Forum](https://forum.aspose.com/c/slides/11), bevor Sie die Bereitstellung durchführen.

## **Report Server Editionen**

Für SQL Server 2016 Reporting Services und neuere sowie für Power BI Report Server unterstützt Microsoft Rendering-Erweiterungen in den Editionen Enterprise, Standard, Developer und Evaluation; die Web- und Express-Editionen unterstützen sie nicht. Siehe [Reporting Services Funktionen, die von Editionen unterstützt werden](https://learn.microsoft.com/en-us/sql/reporting-services/reporting-services-features-supported-by-the-editions-of-sql-server). Der MSI-Installer überspringt Express-Instanzen von SQL Server 2016 und früher.

## **.NET Framework**

.NET Framework 3.5 muss auf dem Berichtserver installiert sein. Die Assemblies der Erweiterung sind für die .NET Framework 2.0 Laufzeit gebaut, und der MSI-Installer stoppt mit einer Meldung, wenn .NET Framework 3.5 fehlt. Auf Windows Server fügen Sie **.NET Framework 3.5 Features** im Assistenten Rollen und Features hinzufügen hinzu; siehe [Installieren Sie .NET Framework 3.5 unter Windows](https://learn.microsoft.com/en-us/dotnet/framework/install/dotnet-35-windows).

## **Berechtigungen**

Die Installation der Erweiterung ändert Dateien im Berichtserver-Ordner, daher benötigen beide Installationswege lokale Administratorrechte. Wenn Sie den MSI-Installer ohne diese starten, bietet er an, sich mit Administrator-Privilegien neu zu starten.

## **FAQ**

**Benötige ich Microsoft PowerPoint auf dem Berichtserver?**

Nein. Die Erweiterung erstellt die Präsentationen selbst; weder PowerPoint noch Microsoft Office müssen installiert sein.

**Kann ich die Erweiterung in einer Express-Edition installieren?**

Nein. Express-Editionen unterstützen keine Rendering-Erweiterungen. Der MSI-Installer versteckt Express-Instanzen von SQL Server 2016 und früher; bei neueren Versionen wählen Sie keine Express-Instanz aus.

**Welche Formate fügt die Erweiterung der Export-Liste hinzu?**

PPT, PPS, PPTX, PPSX, ODP und XPS. Siehe [Unterstützte Dateiformate](/slides/de/reportingservices/supported-file-formats/).