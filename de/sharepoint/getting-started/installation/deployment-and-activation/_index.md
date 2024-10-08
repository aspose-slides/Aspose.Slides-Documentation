---
title: Bereitstellung und Aktivierung
type: docs
weight: 20
url: /de/sharepoint/deployment-and-activation/
---

## **Bereitstellung**
Während der Bereitstellung installiert Aspose.Slides für SharePoint: 

- Die **Aspose.Slides.SharePoint.dll** in den Global Assembly Cache und fügt einen SafeControl-Eintrag zur **web.config**-Datei hinzu.
- Das Funktionsmanifest und andere notwendige Dateien in die entsprechenden Verzeichnisse.
- Die Funktion in der SharePoint-Datenbank und macht sie für die Aktivierung auf Funktionsebene verfügbar.
## **Aktivierung**
Aspose.Slides für SharePoint wird als Funktion auf der Ebene der Site (Site-Sammlungen) verpackt und kann in Site-Sammlungen aktiviert oder deaktiviert werden. Während der Aktivierung nimmt die Funktion einige Änderungen am virtuellen Verzeichnis der übergeordneten Webanwendung der Site-Sammlung vor. Es: 

- Fügt die Seite mit den Konversionseinstellungen zur Sitemap-Datei hinzu.
- Kopiert die erforderlichen Ressourcendateien in den App_GlobalResources-Ordner im virtuellen Verzeichnis.