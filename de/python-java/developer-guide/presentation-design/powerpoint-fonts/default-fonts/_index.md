---
title: Standard‑Schriftarten für Präsentationen in Python via Java festlegen
linktitle: Standard‑Schrift
type: docs
weight: 30
url: /de/python-java/default-font/
keywords:
- Standardschrift
- normale Schrift
- normale Schrift
- asiatische Schrift
- PDF-Export
- XPS-Export
- Bildexport
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Standard‑Schriften in Aspose.Slides für Python via Java festlegen, um eine korrekte Konvertierung von PowerPoint (PPT, PPTX) und OpenDocument (ODP) zu PDF, XPS und Bildern zu gewährleisten."
---
## **Übersicht**

Aspose.Slides ermöglicht das Festlegen von Standardschriften, die beim Rendern einer Präsentation verwendet werden. Dies ist nützlich beim Erzeugen von Folien‑Thumbnails oder beim Exportieren einer Präsentation in Formate wie PDF und XPS. Standardschriften werden über [LoadOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/) konfiguriert, bevor die Präsentation geladen wird.

Die Methode [setDefaultRegularFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) definiert die Standardschrift für normalen Text, während [setDefaultAsianFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) die Standardschrift für asiatischen Text festlegt. Nachdem diese Optionen gesetzt wurden, kann die Präsentation mit den angegebenen Schriften geladen und gerendert werden.

## **Standard-Schriften zum Rendern einer Präsentation verwenden**

Aspose.Slides lässt Sie Standardschriften für das Rendern einer Präsentation zu PDF, XPS oder Thumbnails festlegen. Dieser Abschnitt zeigt, wie Sie Standardschriften für normalen und asiatischen Text mit Aspose.Slides für Python via Java definieren:

1. Erstellen Sie eine Instanz von [LoadOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/).
1. Verwenden Sie [setDefaultRegularFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setDefaultRegularFont), um die gewünschte Schrift anzugeben. Das folgende Beispiel verwendet Wingdings.
1. Verwenden Sie [setDefaultAsianFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setDefaultAsianFont), um die gewünschte Schrift anzugeben. Das folgende Beispiel verwendet ebenfalls Wingdings.
1. Laden Sie die Präsentation mit [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) und den Ladeoptionen.
1. Erzeugen Sie das Folien‑Thumbnail, PDF und XPS, um die Ergebnisse zu überprüfen.

Das folgende Beispiel implementiert diese Schritte:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Verwenden Sie Ladeoptionen, um die standardmäßige reguläre und asiatische Schriftart festzulegen.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Laden Sie die Präsentation.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Erzeugen Sie ein Folien-Thumbnail.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Bild auf die Festplatte speichern.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # PDF erzeugen.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # XPS-Dokument erzeugen.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **FAQ**

**Worauf wirken die Standardschriften für normalen bzw. asiatischen Text genau – nur beim Export oder auch bei Thumbnails, PDF, XPS, HTML und SVG?**

Sie werden in der Rendering‑Pipeline für alle unterstützten Ausgaben verwendet. Dazu gehören Folien‑Thumbnails, [PDF](/slides/de/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-java/convert-powerpoint-to-xps/), [Raster‑Bilder](/slides/de/python-java/convert-powerpoint-to-png/), [HTML](/slides/de/python-java/convert-powerpoint-to-html/) und [SVG](/slides/de/python-java/render-a-slide-as-an-svg-image/), da Aspose.Slides dieselbe Layout‑ und Glyphen‑Auflösungslogik für diese Ziele nutzt.

**Werden Standardschriften angewendet, wenn man einfach ein PPTX liest und speichert, ohne zu rendern?**

Nein. Standardschriften sind relevant, wenn Text gemessen und gezeichnet werden muss. Ein einfaches Öffnen‑und‑Speichern einer Präsentation ändert weder die gespeicherten Schriftlauf‑Runs noch die Dateistruktur. Standardschriften kommen bei Operationen zum Einsatz, die rendern oder Text umfließen lassen.

**Wenn ich eigene Schriftordner hinzufüge oder Schriften aus dem Speicher bereitstelle, werden diese bei der Auswahl der Standardschriften berücksichtigt?**

Ja. [Custom font sources](/slides/de/python-java/custom-font/) erweitern den Katalog verfügbarer Familien und Glyphen, die die Engine nutzen kann. Standardschriften und etwaige [Fallback‑Regeln](/slides/de/python-java/fallback-font/) werden zuerst gegen diese Quellen aufgelöst, was auf Servern und in Containern für zuverlässigere Abdeckung sorgt.

**Werden Standardschriften die Textmetriken (Kerning, Advances) und damit Zeilenumbrüche und Textumbruch beeinflussen?**

Ja. Das Ändern der Schriftart ändert die Glyphen‑Metriken und kann Zeilenumbrüche, Textumbruch und Paginierung beim Rendern beeinflussen. Für Layout‑Stabilität sollten Sie die Originalschriften einbetten](/slides/de/python-java/embedded-font/) oder metrisch kompatible Standards‑ und Fallback‑Familien wählen.

**Macht es Sinn, Standardschriften zu setzen, wenn alle in der Präsentation verwendeten Schriften eingebettet sind?**

Oft ist das nicht nötig, weil [embedded fonts](/slides/de/python-java/embedded-font/) bereits ein konsistentes Erscheinungsbild gewährleisten. Standardschriften bleiben dennoch als Sicherheitsnetz für Zeichen, die nicht von dem eingebetteten Subset abgedeckt werden, oder wenn eine Datei eingebetteten und nicht eingebetteten Text mischt.