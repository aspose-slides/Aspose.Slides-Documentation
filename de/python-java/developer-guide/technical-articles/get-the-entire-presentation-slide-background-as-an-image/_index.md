---
title: Gesamten Folienhintergrund aus einer Präsentation als Bild erhalten
linktitle: Ganzer Folienhintergrund
type: docs
weight: 95
url: /de/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- Folienhintergrund
- endgültiger Hintergrund
- Hintergrund extrahieren
- gesamter Hintergrund
- Hintergrund zu Bild
- PPT-Hintergrund
- PPTX-Hintergrund
- ODP-Hintergrund
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Extrahieren Sie vollständige Folienhintergründe als Bilder aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via Java und optimieren Sie so visuelle Arbeitsabläufe."
---
## **Übersicht**

In PowerPoint-Präsentationen kann ein Folienhintergrund aus mehreren Elementen bestehen, darunter das Hintergrundbild der Folie, das Präsentationsthema, das Farbschema und Objekte, die auf der Master-Folie oder Layout-Folie platziert sind.

Dieser Artikel zeigt, wie man den gesamten Folienhintergrund als Bild mit Aspose.Slides für Python via Java extrahiert. Da es keine einzelne Methode dafür gibt, besteht der Ansatz darin, die ausgewählte Folie in eine temporäre Präsentation zu klonen, die Folienformen zu entfernen und anschließend den resultierenden Folienhintergrund in ein Bild zu konvertieren.

## **Gesamten Folienhintergrund extrahieren**

Aspose.Slides für Python via Java bietet keine einfache Methode, um den gesamten Folienhintergrund einer Präsentation als Bild zu extrahieren, aber Sie können die folgenden Schritte befolgen, um dies zu erreichen:

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
1. Ermitteln Sie die Foliengröße aus der Präsentation.
1. Wählen Sie eine Folie aus.
1. Erstellen Sie eine temporäre Präsentation.
1. Setzen Sie dieselbe Foliengröße in der temporären Präsentation.
1. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
1. Löschen Sie die Formen von der geklonten Folie.
1. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Folienhintergrund der Präsentation als Bild.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Werden komplexe Verlaeufe, Texturen oder Bildfuellungen von einer Master-Folie im resultierenden Hintergrundbild erhalten?**

Ja. Aspose.Slides rendert Gradient-, Bild- und Texturfuellungen, die auf der Folie, dem Layout oder dem Master definiert sind. Wenn Sie das Aussehen von vererbten Mastern isolieren moechten, [setzen Sie einen benutzerdefinierten Hintergrund](/slides/de/python-java/presentation-background/) auf der aktuellen Folie, bevor Sie exportieren.

**Kann ich dem resultierenden Hintergrundbild vor dem Speichern ein Wasserzeichen hinzufuegen?**

Ja. Sie können ein [Wasserzeichen hinzufuegen](/slides/de/python-java/watermark/) Form oder Bild auf einer Arbeits-[Kopie der Folie](/slides/de/python-java/clone-slides/) (hinter anderem Inhalt platziert) hinzufuegen und dann exportieren. So erhalten Sie ein Hintergrundbild, in das das Wasserzeichen eingebettet ist.

**Kann ich den Hintergrund fuer ein bestimmtes Layout oder Master erhalten, ohne ihn an eine vorhandene Folie zu binden?**

Ja. Greifen Sie auf das gewuenschte Master- oder Layout zu, wenden Sie es auf eine [temporare Folie](/slides/de/python-java/clone-slides/) mit der erforderten Groesse an und exportieren Sie diese Folie, um den aus diesem Layout oder Master abgeleiteten Hintergrund zu erhalten.

**Gibt es Lizenzbeschraenkungen, die den Bildexport beeinflussen?**

Render-Funktionen sind mit einer [gueltige Lizenz](/slides/de/python-java/licensing/) vollstaendig verfuegbar. Im Evaluierungsmodus kann die Ausgabe Einschränkungen wie ein Wasserzeichen enthalten. Aktivieren Sie die Lizenz einmal pro Prozess, bevor Sie Batch-Exporte starten.