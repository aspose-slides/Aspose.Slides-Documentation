---
title: Manuell installieren
type: docs
weight: 30
url: /de/reportingservices/install-manually/
keywords:
- manuelle Installation
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Installieren Sie Aspose.Slides für Reporting Services manuell aus dem ZIP-Paket nur mit DLLs: Welche Assembly zu kopieren ist und was zu rsreportserver.config und rssrvpolicy.config hinzuzufügen ist."
---
## **Übersicht**

Führen Sie diese Schritte aus, um Aspose.Slides für Reporting Services ohne den MSI‑Installer aus dem ZIP‑Paket *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* auf der [Downloadseite](https://releases.aspose.com/slides/de/reportingservices/) zu installieren. Sie registrieren dieselben Erweiterungen wie der [MSI‑Installer](/slides/de/reportingservices/install-with-msi-installer/). Wiederholen Sie sie für jede Report‑Server‑Instanz.

Bevor Sie beginnen, prüfen Sie die [Systemanforderungen](/slides/de/reportingservices/system-requirements/). Sie benötigen lokale Administratorrechte auf dem Report‑Server.

## **Wählen Sie die Assembly**

Das ZIP‑Paket enthält mehrere Builds. Kopieren Sie genau eine *Aspose.Slides.ReportingServices.dll* auf den Report‑Server:

| Datei im ZIP‑Paket | Verwendung |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 und neuere Reporting Services sowie Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Nicht für einen Report‑Server: Anwendungen, die aus dem ReportViewer‑Steuerelement 2010 oder 2012 exportieren, siehe [Verwendung von Aspose.Slides mit ReportViewer 2010 und 2012](/slides/de/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | Optional: speichert Berichte im RPL‑Format für Problemberichte, siehe [Exportieren von Berichten ins RPL‑Format](/slides/de/reportingservices/exporting-reports-to-rpl-format/) |

## **Finden Sie den Report‑Server‑Ordner**

Die nachstehenden Schritte beziehen sich auf den *ReportServer*‑Ordner des Report‑Servers, der *rsreportserver.config* und *rssrvpolicy.config* enthält. In einer Standardinstallation befindet er sich unter:

| Report‑Server | Standard *ReportServer* Ordner |
| :- | :- |
| SQL Server 2017 und neuere Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 und frühere Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, wobei der Instanz‑Ordner z. B. `MSRS13.MSSQLSERVER` für SQL Server 2016 oder `MSSQL.x` für SQL Server 2005 ist |

Weitere Speicherorte finden Sie im Microsoft‑Artikel zur [RsReportServer.config‑Konfigurationsdatei](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file).

## **Erweiterung installieren**

1. Kopieren Sie die ausgewählte Assembly in den Unterordner *bin* des *ReportServer*‑Ordners.

   Die kopierte Datei darf keine explizit zugewiesenen NTFS‑Berechtigungen besitzen, da der Report‑Server sonst beim Laden der Assembly keinen Zugriff hat und die neuen Exportformate nicht angezeigt werden. Rechtsklicken Sie die Datei, wählen Sie **Properties**, und entfernen Sie auf der Registerkarte **Security** alle explizit zugewiesenen Berechtigungen, sodass nur geerbte verbleiben. Falls die Registerkarte **General** die Option **Unblock** anzeigt, wählen Sie sie.

1. Speichern Sie eine Kopie von *rsreportserver.config* und öffnen Sie die Datei anschließend in einem Texteditor. Fügen Sie diese Einträge innerhalb des `<Render>`‑Elements hinzu:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Jeder Eintrag registriert ein Exportformat; `Name` muss unter den Rendering‑Erweiterungen eindeutig sein. Der MSI‑Installer registriert dieselben sechs Namen und Typen. Lassen Sie einen Eintrag weg, wenn Sie dessen Format nicht in der Exportliste wünschen.

1. Speichern Sie eine Kopie von *rssrvpolicy.config* und öffnen Sie die Datei anschließend in einem Texteditor. Suchen Sie die Codegruppe, deren `Description` den Text "This code group grants MyComputer code Execution permission." enthält, und fügen Sie diese Codegruppe als letztes Kind hinzu:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` ist der öffentliche Schlüssel der Aspose.Slides.ReportingServices‑Assembly. Halten Sie ihn in einer Zeile.

1. Speichern Sie beide Dateien. Der Report‑Server liest seine Konfigurationsdateien erneut ein, sobald sie gespeichert werden. Enthält eine Datei fehlerhaftes XML, ignoriert der Report‑Server sie oder startet nicht, daher stellen Sie Ihre Kopie wieder her, falls etwas schiefgeht.

## **Installation prüfen**

Öffnen Sie einen paginierten Bericht im Web‑Portal (Report Manager bei SQL Server 2014 und früher) und öffnen Sie die **Export**‑Liste. Sie enthält nun diese Formate:

- PPT – PowerPoint‑Präsentation über Aspose.Slides
- PPS – PowerPoint‑SlideShow über Aspose.Slides
- PPTX – PowerPoint‑2007‑Präsentation über Aspose.Slides
- PPSX – PowerPoint‑2007‑SlideShow über Aspose.Slides
- ODP – OpenDocument‑Präsentation über Aspose.Slides
- XPS – über Aspose.Slides

Wählen Sie eines davon aus, um den Bericht zu exportieren. Die Datei wird in der mit dem Format verknüpften Anwendung geöffnet.

![Ein Bericht, der von Aspose.Slides for Reporting Services nach PowerPoint exportiert wurde](install-manually_2.png)

Falls die Formate nicht angezeigt werden, überprüfen Sie die NTFS‑Berechtigungen der kopierten Assembly. Ohne Lizenz erhalten exportierte Dateien ein Evaluations‑Wasserzeichen; siehe [Lizenzierung](/slides/de/reportingservices/license-aspose-slides-for-reporting-services/).