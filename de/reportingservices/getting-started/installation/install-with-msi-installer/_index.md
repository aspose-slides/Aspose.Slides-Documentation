---
title: Installation mit MSI-Installer
type: docs
weight: 20
url: /de/reportingservices/install-with-msi-installer/
keywords:
- MSI-Installer
- Installation
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Installieren Sie Aspose.Slides for Reporting Services mit dem MSI-Installer: was der Installer benötigt, welche Änderungen er an jeder Report-Server-Instanz vornimmt und wie Sie das Ergebnis überprüfen."
---
## **Installation**

Der MSI‑Installer ist der einfachste Weg, Aspose.Slides for Reporting Services zu installieren. Er benötigt .NET Framework 3.5 und Administratorrechte auf dem Bericht‑Server; siehe [Systemanforderungen](/slides/de/reportingservices/system-requirements/).

1. Laden Sie den MSI‑Installer, *Aspose.Slides for Reporting Services XX.XX*, von der [Downloadseite](https://releases.aspose.com/slides/de/reportingservices/) herunter und kopieren Sie ihn auf den Bericht‑Server.
2. Führen Sie ihn als Administrator aus. Wenn .NET Framework 3.5 fehlt, stoppt der Installer mit einer Meldung; installieren Sie die .NET Framework 3.5‑Features und führen Sie ihn erneut aus.
3. Akzeptieren Sie die Lizenzvereinbarung.
4. Auf der Seite **Custom Setup** listet der Funktionsbaum jede SQL Server Reporting Services‑ und Power BI Report‑Server‑Instanz, die der Installer auf dem Rechner erkennt. Um eine Instanz unverändert zu lassen, klicken Sie ihr Symbol an und wählen **Entire feature will be unavailable**. Express‑Editionen unterstützen keine Rendering‑Erweiterungen, daher wählen Sie keine Express‑Instanz aus. Der Installer blendet Express‑Instanzen von SQL Server 2016 und früher aus.
5. Wählen Sie **Next**, und dann **Install**.
6. Die optionale Funktion **Rpl Export** ist standardmäßig nicht ausgewählt. Sie fügt eine versteckte Erweiterung hinzu, die Berichte im RPL‑Format speichert, was nützlich ist, wenn Sie einen Problembericht an Aspose senden; siehe [Exporting Reports to RPL Format](/slides/de/reportingservices/exporting-reports-to-rpl-format/).

## **Was der Installer ändert**

Der Installer speichert seine Dateien in *Aspose\Aspose.Slides for Reporting Services* im Programmdateien‑Ordner — *Program Files (x86)* unter 64‑Bit‑Windows, da der Installer ein 32‑Bit‑Paket ist. Anschließend wird für jede ausgewählte Instanz Folgendes durchgeführt:

- kopiert *Aspose.Slides.ReportingServices.dll* in den *ReportServer\bin*‑Ordner der Instanz — den Build für SQL Server 2005 bzw. den Build für SQL Server 2008 und neuer sowie Power BI Report Server;
- fügt dem `<Render>`‑Element von *rsreportserver.config* sechs Rendering‑Erweiterungen — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS und ASODP — hinzu;
- fügt eine Code‑Gruppe hinzu, die der Assembly volles Vertrauen in *rssrvpolicy.config* gewährt;
- speichert eine Kopie jeder geänderten Konfigurationsdatei, indem *.bak* an den Dateinamen angehängt wird.

[Manuell installieren](/slides/de/reportingservices/install-manually/) zeigt diese Änderungen Schritt für Schritt.

## **Installation überprüfen**

Öffnen Sie einen paginierten Bericht im Web‑Portal (Report Manager unter SQL Server 2014 und früher) und öffnen Sie die **Export**‑Liste. Sie enthält nun folgende Formate:

- PPT – PowerPoint‑Präsentation über Aspose.Slides
- PPS – PowerPoint‑Diashow über Aspose.Slides
- PPTX – PowerPoint 2007‑Präsentation über Aspose.Slides
- PPSX – PowerPoint 2007‑Diashow über Aspose.Slides
- ODP – OpenDocument‑Präsentation über Aspose.Slides
- XPS – über Aspose.Slides

Ohne Lizenz enthalten die exportierten Dateien ein Evaluations‑Wasserzeichen; siehe [Lizenzierung](/slides/de/reportingservices/license-aspose-slides-for-reporting-services/).

## **Wann manuell installieren**

Installieren Sie die Erweiterung [manuell](/slides/de/reportingservices/install-manually/) stattdessen, wenn:

- der Installer eine Instanz nicht konfigurieren kann, beispielsweise wegen Sicherheitseinstellungen auf dem Server;
- nach einem Upgrade nur die Assembly ersetzen möchten, anstatt die alte Version zu deinstallieren und den neuen Installer auszuführen.

Die Deinstallation des Produkts entfernt die Assembly und die Konfigurationseinträge aus jeder Instanz.