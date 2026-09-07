---
title: PowerPoint-Präsentationen in XPS konvertieren in Python
linktitle: PowerPoint zu XPS
type: docs
weight: 70
url: /de/python-java/convert-powerpoint-to-xps/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu XPS
- Präsentation zu XPS
- PPT zu XPS
- PPTX zu XPS
- PPT als XPS speichern
- PPTX als XPS speichern
- PPT nach XPS exportieren
- PPTX nach XPS exportieren
- Python
- Java
- Aspose.Slides
description: "PowerPoint PPT- und PPTX-Präsentationen in XPS konvertieren in Python mit Aspose.Slides für Python via Java, mit Standard- oder benutzerdefinierten Exporteinstellungen."
---
## **Übersicht**

Aspose.Slides for Python via Java ermöglicht es Ihnen, PowerPoint‑Präsentationen in XPS zu konvertieren, indem Sie eine PPT‑ oder PPTX‑Datei im XPS‑Format speichern. Dieser Artikel erklärt, wann XPS nützlich sein kann, und zeigt, wie man eine Präsentation mit den standardmäßigen Einstellungen oder benutzerdefinierten [XpsOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/xpsoptions/)-Einstellungen exportiert.

## **Über XPS**

XPS (XML Paper Specification) ist ein XML‑basiertes Dokumentformat, das von Microsoft entwickelt wurde. Es beschreibt feste Seiten und bewahrt das Layout von Text und Grafiken für die Anzeige und den Druck mit kompatibler Software.

## **Wann das Microsoft XPS‑Format verwenden**

Verwenden Sie XPS, wenn ein Dokumenten‑Workflow feste Layout‑Dateien für das Teilen oder Drucken über XPS‑kompatible Werkzeuge erfordert. Empfänger benötigen Software, die XPS unterstützt. Wenn Ihr Workflow stattdessen PDF erfordert, siehe [Convert PowerPoint to PDF](/slides/de/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Hinweis" %}}
Um das Konvertieren einer PPT‑ oder PPTX‑Präsentation in XPS auszuprobieren, nutzen Sie den [kostenlosen Online‑Konverter](https://products.aspose.app/slides/de/conversion).
{{% /alert %}}

| Eingabe PowerPoint‑Präsentation | Ausgabe XPS‑Dokument |
| --- | --- |
| ![Original PowerPoint‑Präsentation](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Präsentation in XPS konvertiert](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **XPS‑Konvertierung mit Aspose.Slides**

Verwenden Sie die [save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)-Methode der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)-Klasse zusammen mit [SaveFormat.Xps](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/#Xps), um eine Präsentation zu exportieren. Sie können die Standard‑Exporteinstellungen verwenden oder [XpsOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/xpsoptions/) angeben, um die Ausgabe anzupassen.

Jedes Beispiel startet die Java‑Virtuelle Maschine bei Bedarf und gibt die Präsentation nach der Verwendung frei. Ersetzen Sie den Eingabedateinamen durch den Pfad zu Ihrer PPT‑ oder PPTX‑Datei.

### **Präsentationen mit Standardeinstellungen in XPS konvertieren**

Der folgende Python‑Code konvertiert eine Präsentation mit den Standard‑Einstellungen in XPS:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Präsentation als XPS-Dokument speichern.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Präsentationen mit benutzerdefinierten Einstellungen in XPS konvertieren**

Das folgende Beispiel verwendet [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/de/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng), um Metadateien als PNG‑Bilder im resultierenden XPS‑Dokument zu speichern:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Präsentation mit den benutzerdefinierten XPS-Einstellungen speichern.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich XPS in einen Stream statt in eine Datei speichern?**

Ja. Die [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save)-Methode hat Überladungen, die einen Java‑Ausgabestream akzeptieren. Mit Python via Java verwenden Sie einen kompatiblen Java‑Stream über JPype, z. B. einen Java‑Byte‑Array‑Ausgabestream, um die exportierten Daten im Speicher zu behalten.

**Werden ausgeblendete Folien in die XPS‑Ausgabe einbezogen?**

Ausgeblendete Folien werden standardmäßig ausgeschlossen. Um sie einzubeziehen, setzen Sie [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) vor dem Speichern auf `True`.

**Werden Animationen und Folienübergänge in XPS beibehalten?**

Nein. XPS enthält feste Seiten, sodass die exportierten Folien keine Animationen oder Übergangseffekte wiedergeben.