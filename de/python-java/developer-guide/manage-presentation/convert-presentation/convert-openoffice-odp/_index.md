---
title: OpenDocument-Präsentationen in Python konvertieren
linktitle: OpenDocument konvertieren
type: docs
weight: 10
url: /de/python-java/convert-openoffice-odp/
keywords:
- ODP konvertieren
- ODP zu PDF
- ODP zu HTML
- ODP zu TIFF
- ODP zu PPT
- ODP zu PPTX
- ODP zu XPS
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Konvertieren Sie OpenDocument (ODP)-Präsentationen in PDF, HTML und andere Formate mit Aspose.Slides für Python über Java, ohne OpenOffice oder LibreOffice zu installieren."
---
## **Einführung**

Aspose.Slides für Python über Java ermöglicht das Konvertieren von OpenDocument (ODP)-Präsentationen in Formate wie PDF, HTML, TIFF, XPS, PPT und PPTX. Die ODP-Konvertierung verwendet dieselbe API wie die PowerPoint-Konvertierung: Laden Sie die Quelldatei mit [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und wählen Sie das Ausgabeformat mit [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/).

## **ODP in PDF konvertieren**

Befolgen Sie die [Installationsanweisungen](/slides/de/python-java/installation/), bevor Sie das Beispiel ausführen. Legen Sie eine ODP-Präsentation mit dem Namen `pres.odp` im Arbeitsverzeichnis ab. Der folgende Code startet bei Bedarf die JVM, lädt die Präsentation und speichert sie als `pres.pdf`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **OpenDocument-Präsentation in verschiedenen Anwendungen**

Eine ODP-Präsentation kann in PowerPoint und LibreOffice/OpenOffice Impress unterschiedlich aussehen, da diese Anwendungen unterschiedliche Präsentationsfunktionen und Renderverhalten unterstützen. Überprüfen Sie konvertierte Präsentationen, wenn ihr Layout von komplexer Formatierung abhängt.

Kompatibilitätsunterschiede können Folgendes betreffen:
- Tabellen, einschließlich ihrer Stapelreihenfolge im Verhältnis zu anderen Formen und der Unterstützung von Bildfüllungen.
- Textdrehung und -ausrichtung.
- Bild-, Farbverlauf- und Musterfüllungen, die auf Text angewendet werden.
- Nummerierte und Aufzählungslisten.

Das Bild unten zeigt ein in LibreOffice Impress erstelltes Beispiel einer Liste:

![ODP-Listenbeispiel in LibreOffice Impress](odp-list-example.png)

Aspose.Slides speichert ODP-Listen zur Kompatibilität mit LibreOffice/OpenOffice Impress.

Weitere Details zur Feature-Kompatibilität finden Sie in [Microsofts Leitfaden zum OpenDocument-Präsentationsformat](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**Was passiert, wenn sich die Formatierung meiner ODP-Datei nach der Konvertierung ändert?**

ODP und PowerPoint verwenden unterschiedliche Präsentationsmodelle. Tabellen, Schriftarten und Füllstile können anders dargestellt werden. Stellen Sie sicher, dass die erforderlichen Schriftarten verfügbar sind, überprüfen Sie das Ergebnis und passen Sie bei Bedarf das Layout oder die Formatierung an.

**Benötige ich OpenOffice oder LibreOffice, um ODP-Dateien zu konvertieren?**

Nein. Aspose.Slides für Python über Java verarbeitet Präsentationen ohne eine dieser Anwendungen. Eine kompatible Java-Laufzeitumgebung und das Python-Paket sind erforderlich.

**Kann ich die PDF-Ausgabe beim Konvertieren einer ODP-Präsentation anpassen?**

Ja. Verwenden Sie [PdfOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/pdfoptions/), um die PDF-Exportoptionen zu konfigurieren, z. B. Bildqualität und Komprimierung.

**Kann ich ODP-Präsentationen auf einem Server oder in einem Container konvertieren?**

Ja. Installieren Sie das Python-Paket, eine kompatible Java-Laufzeitumgebung und die für Ihre Präsentationen erforderlichen Schriftarten in der Zielumgebung. Es wird keine Office-Anwendung benötigt.