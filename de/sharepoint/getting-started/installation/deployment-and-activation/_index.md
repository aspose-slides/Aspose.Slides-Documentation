---
title: Bereitstellung und Aktivierung
type: docs
weight: 20
url: /de/sharepoint/deployment-and-activation/
description: "Was die Aspose.Slides for SharePoint-Lösung auf dem Farm installiert, wenn sie bereitgestellt wird, und was ihr Feature für die Websitesammlung hinzufügt, wenn es aktiviert wird."
---
## **Bereitstellung**

Während der Bereitstellung installiert die Aspose.Slides for SharePoint-Lösung:

- Installiert seine Assembly in den Global Assembly Cache und fügt dem **web.config**-Datei SafeControl‑Einträge hinzu. Auf SharePoint 2010 und neuer ist dies *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* oder *Aspose.Slides.SharePoint2016.dll* (das SharePoint‑2019‑Paket installiert ebenfalls *Aspose.Slides.SharePoint2016.dll*). Auf SharePoint 2007 ist es *Aspose.Slides.SharePointUI.dll* zusammen mit *Aspose.Slides.SharePoint.Deployment.dll*.
- Kopiert die Konvertierungsseite sowie deren Bilder und andere unterstützende Dateien in die SharePoint‑Installationsordner.
- Installiert das Feature und macht es für die Aktivierung in Websitesammlungen verfügbar.

## **Aktivierung**

Aspose.Slides for SharePoint wird als Feature für eine Websitesammlung verpackt und kann in Websitesammlungen aktiviert oder deaktiviert werden. Wenn es in einer Websitesammlung aktiviert wird, fügt das Feature hinzu:

- Auf SharePoint 2010 und neuer:
  - den Eintrag **Convert via Aspose.Slides** zum Menü Dokumente in Dokumentbibliotheken;
  - die Registerkarte **Aspose Tools** im Ribbon mit dem Button **Convert Slides**, der die ausgewählten Dokumente konvertiert;
  - den Eintrag **View Slides** zum Menü von PPT-, PPTX-, PPS- und PPSX-Dateien.
- Auf SharePoint 2007:
  - den Eintrag **Convert with Aspose.Slides** zum Menü Dokumente in Dokumentbibliotheken;
  - den Eintrag **Convert All with Aspose.Slides** zum **Actions**-Menü von Dokumentbibliotheken.

In SharePoint 2007 bewirkt die Aktivierung außerdem Änderungen am virtuellen Verzeichnis der übergeordneten Webanwendung der Websitesammlung. Es:

- Fügt die Konvertierungseinstellungsseite zur Sitemap‑Datei hinzu.
- Kopiert die erforderlichen Resourcendateien in den Ordner App_GlobalResources im virtuellen Verzeichnis.

Das Installationsprogramm aktiviert das Feature in den Websitesammlungen, die Sie während der [Installation](/slides/de/sharepoint/installing-aspose-slides-for-sharepoint/) auswählen.