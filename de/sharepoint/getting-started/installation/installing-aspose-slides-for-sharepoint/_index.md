---
title: Installation von Aspose.Slides für SharePoint
type: docs
weight: 10
url: /de/sharepoint/installing-aspose-slides-for-sharepoint/
description: "Installieren Sie Aspose.Slides für SharePoint in einer SharePoint-Farm: Wählen Sie das Setup-Programm für Ihre SharePoint-Version, führen Sie den System-Check aus und stellen Sie die Lösung bereit und aktivieren Sie sie."
---
## **Paketinhalt**

Aspose.Slides for SharePoint wird von der [Download‑Seite](https://releases.aspose.com/slides/sharepoint/) als ZIP‑Archiv heruntergeladen. Das Archiv enthält ein SharePoint‑Lösungspaket (WSP) und ein Setup‑Programm für jede unterstützte SharePoint‑Version:

| SharePoint‑Version | Setup‑Programm | Lösungspaket |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

Jedes Setup‑Programm hat eine Konfigurationsdatei daneben (z. B. *Setup2019.exe.config*), die das zu installierende Lösungspaket benennt. Der *License*‑Ordner enthält einen Link zur Endbenutzer‑Lizenzvereinbarung sowie Hinweise zu Drittanbieter‑Lizenzen.

Aspose.Slides for SharePoint wird als SharePoint‑Lösung bereitgestellt, die SharePoint im Server‑Farm‑Umfeld verteilt. Die zugehörige Funktion wird dann pro Sitesammlung aktiviert oder deaktiviert.

## **Installationsvorgang**

Vor der Installation führt das Setup‑Programm einen System‑Check durch. Es wird geprüft, dass:

- SharePoint auf dem Server installiert ist.
- Der aktuelle Benutzer über Berechtigungen zum Installieren und Bereitstellen von SharePoint‑Lösungen verfügt.
- Der SharePoint‑Administrationsservice gestartet ist.
- Der SharePoint‑Timer‑Service gestartet ist.
- Das im Konfigurationsfile benannte Lösungspaket vorhanden ist.

Die Administrations‑ und Timer‑Services werden benötigt, weil einige Setup‑Aktionen als Timer‑Jobs ausgeführt werden, die die Lösung auf alle Server der Farm verteilen.

### **Durchführen der Installation**

Um Aspose.Slides for SharePoint zu installieren:

1. Entpacken Sie das ZIP‑Archiv auf einem lokalen Laufwerk eines Servers in der SharePoint‑Farm.
2. Starten Sie das Setup‑Programm, das Ihrer SharePoint‑Version entspricht (siehe Tabelle oben), und folgen Sie den Anweisungen auf dem Bildschirm. Das Setup‑Programm:
   1. Führt den System‑Check aus. Das Setup wird nicht fortgesetzt, wenn ein Prüfschritt fehlschlägt.

      **System‑Check ausführen**

      ![Der System‑Check‑Bildschirm des Setup‑Programms](installing-aspose-slides-for-sharepoint_1.png)

   2. Zeigt die Endbenutzer‑Lizenzvereinbarung an. Sie müssen diese akzeptieren, um fortzufahren.

      **Die Lizenzvereinbarung**

      ![Der Lizenz‑Bildschirm des Setup‑Programms](installing-aspose-slides-for-sharepoint_2.png)

   3. Zeigt die Bereitstellungsziele an. Wählen Sie die Web‑Applikationen und Sitesammlungen aus, für die die Funktion aktiviert werden soll.

      **Auswahl der Bereitstellungsziele**

      ![Der Ziel‑Auswahl‑Bildschirm des Setup‑Programms](installing-aspose-slides-for-sharepoint_3.png)

   4. Deployt die Lösung in die Farm.

      **Der Installationsfortschritt**

      ![Der Fortschritts‑Bildschirm des Setup‑Programms](installing-aspose-slides-for-sharepoint_4.png)

   5. Aktiviert Aspose.Slides for SharePoint in den ausgewählten Sitesammlungen.
   6. Listet die Web‑Applikationen und Sitesammlungen auf, in denen die Lösung bereitgestellt und aktiviert wurde.

      **Erfolgreiche Installation**

      ![Der Abschluss‑Bildschirm des Setup‑Programms](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Hinweis" %}}
Die Screenshots wurden unter SharePoint 2007 aufgenommen. Die Setup‑Programme für neuere Versionen durchlaufen die gleichen Bildschirme.
{{% /alert %}}

Ist dieselbe Version von Aspose.Slides for SharePoint bereits installiert, bietet das Setup‑Programm eine Reparatur‑ oder Deinstallationsoption an. Ist eine andere Version installiert, wird ein Upgrade‑ oder Deinstallationsvorschlag gemacht.

Nach der Installation erscheint ein **Convert via Aspose.Slides**‑Eintrag im Menü „Dateien“ von Dokumentenbibliotheken der ausgewählten Sitesammlungen (unter SharePoint 2007 **Convert with Aspose.Slides**). Zum Konvertieren einer ersten Präsentation siehe [Converting Microsoft PowerPoint Documents into Other Formats](/slides/de/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/). Was die Lösung der Farm hinzufügt, wird in [Deployment and Activation](/slides/de/sharepoint/deployment-and-activation/) beschrieben.

## **FAQ**

**Welches Setup‑Programm soll ich ausführen?**

Das, dessen Name Ihrer SharePoint‑Version entspricht. Beispiel: Führen Sie *Setup2016.exe* in einer SharePoint Server 2016‑Farm aus. Jedes Setup‑Programm installiert nur sein jeweiliges Lösungspaket.

**Benötige ich einen gesonderten Download für die lizenzierte Version?**

Nein. Das gleiche Paket funktioniert im Evaluierungsmodus, bis Sie die Lizenz‑Lösung installieren; siehe [Installing Aspose.Slides for SharePoint License](/slides/de/sharepoint/installing-aspose-slides-for-sharepoint-license/).

**Wie deinstalliere ich das Produkt?**

Führen Sie dasselbe Setup‑Programm erneut aus und wählen Sie **Remove**; siehe [Uninstalling Aspose.Slides for SharePoint](/slides/de/sharepoint/uninstalling-aspose-slides-for-sharepoint/).