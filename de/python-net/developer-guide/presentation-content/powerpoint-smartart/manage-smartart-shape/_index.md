---
title: Verwalten von SmartArt-Formen
type: docs
weight: 20
url: /de/python-net/manage-smartart-shape/
keywords: "SmartArt-Form, SmartArt-Formstil, SmartArt-Formfarbstil, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Verwalten von SmartArt in PowerPoint-Präsentationen in Python"
---

## **SmartArt-Form erstellen**
Aspose.Slides für Python über .NET erleichtert nun das Hinzufügen benutzerdefinierter SmartArt-Formen zu ihren Folien von Grund auf. Aspose.Slides für Python über .NET hat die einfachste API bereitgestellt, um SmartArt-Formen auf die einfachste Weise zu erstellen. Um eine SmartArt-Form auf einer Folie zu erstellen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
- Abrufen der Referenz zu einer Folie unter Verwendung ihres Index.
- Eine SmartArt-Form hinzufügen, indem Sie den Layouttyp festlegen.
- Die modifizierte Präsentation als PPTX-Datei speichern.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Präsentation instanziieren
with slides.Presentation() as pres:
    # Auf die Folie der Präsentation zugreifen
    slide = pres.slides[0]

    # Smart Art Form hinzufügen
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.BASIC_BLOCK_LIST)

    # Präsentation speichern
    pres.save("SimpleSmartArt_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Zugriff auf SmartArt-Form in der Folie**
Der folgende Code wird verwendet, um auf die in der Präsentationsfolie hinzugefügten SmartArt-Formen zuzugreifen. Im Beispielcode werden wir durch jede Form innerhalb der Folie traversieren und überprüfen, ob es sich um eine SmartArt-Form handelt. Wenn die Form vom Typ SmartArt ist, werden wir sie in eine SmartArt-Instanz umwandeln.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Die gewünschte Präsentation laden
with slides.Presentation(path + "SmartArt.pptx") as pres:

    # Durch jede Form innerhalb der ersten Folie traversieren
    for shape in pres.slides[0].shapes:
        # Überprüfen, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Form in SmartArtEx umwandeln
            print("Formname:" + shape.name)
```



## **Zugriff auf SmartArt-Form mit einem bestimmten Layouttyp**
Der folgende Beispielcode hilft, auf die SmartArt-Form mit einem bestimmten Layouttyp zuzugreifen. Bitte beachten Sie, dass Sie den Layouttyp der SmartArt nicht ändern können, da er schreibgeschützt ist und nur festgelegt wird, wenn die SmartArt-Form hinzugefügt wird.

- Erstellen Sie eine Instanz der `Presentation` Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Abrufen der Referenz zur ersten Folie unter Verwendung ihres Index.
- Durch jede Form innerhalb der ersten Folie traversieren.
- Überprüfen, ob die Form vom Typ SmartArt ist und die ausgewählte Form in SmartArt umwandeln, wenn es sich um SmartArt handelt.
- Überprüfen Sie die SmartArt-Form mit dem bestimmten Layouttyp und führen Sie die erforderlichen Aktionen danach aus.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Durch jede Form innerhalb der ersten Folie traversieren
    for shape in presentation.slides[0].shapes:
        # Überprüfen, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Überprüfen des SmartArt-Layouts
            if shape.layout == art.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Mach hier etwas....")
```



## **SmartArt-Formstil ändern**
Der folgende Beispielcode hilft, auf die SmartArt-Form mit einem bestimmten Layouttyp zuzugreifen.

- Erstellen Sie eine Instanz der `Presentation` Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Abrufen der Referenz zur ersten Folie unter Verwendung ihres Index.
- Durch jede Form innerhalb der ersten Folie traversieren.
- Überprüfen, ob die Form vom Typ SmartArt ist und die ausgewählte Form in SmartArt umwandeln, wenn es sich um SmartArt handelt.
- Finden Sie die SmartArt-Form mit einem bestimmten Stil.
- Setzen Sie den neuen Stil für die SmartArt-Form.
- Speichern Sie die Präsentation.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Durch jede Form innerhalb der ersten Folie traversieren
    for shape in presentation.slides[0].shapes:
        # Überprüfen, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Überprüfen des SmartArt-Stils
            if shape.quick_style == art.SmartArtQuickStyleType.SIMPLE_FILL:
                # Ändern des SmartArt-Stils
                smart.quick_style = art.SmartArtQuickStyleType.CARTOON

    # Präsentation speichern
    presentation.save("ChangeSmartArtStyle_out.pptx", slides.export.SaveFormat.PPTX)
```



## **SmartArt-Formfarbstil ändern**
In diesem Beispiel lernen wir, den Farbstil für eine beliebige SmartArt-Form zu ändern. Im folgenden Beispielcode wird auf die SmartArt-Form mit einem bestimmten Farbstil zugegriffen und ihr Stil geändert.

- Erstellen Sie eine Instanz der `Presentation` Klasse und laden Sie die Präsentation mit der SmartArt-Form.
- Abrufen der Referenz zur ersten Folie unter Verwendung ihres Index.
- Durch jede Form innerhalb der ersten Folie traversieren.
- Überprüfen, ob die Form vom Typ SmartArt ist und die ausgewählte Form in SmartArt umwandeln, wenn es sich um SmartArt handelt.
- Finden Sie die SmartArt-Form mit einem bestimmten Farbstil.
- Setzen Sie den neuen Farbstil für die SmartArt-Form.
- Speichern Sie die Präsentation.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation(path + "SmartArt.pptx") as presentation:
    # Durch jede Form innerhalb der ersten Folie traversieren
    for shape in presentation.slides[0].shapes:
        # Überprüfen, ob die Form vom Typ SmartArt ist
        if type(shape) is art.SmartArt:
            # Überprüfen des SmartArt-Farbstils
            if shape.color_style == art.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Ändern des SmartArt-Farbstils
                shape.color_style = art.SmartArtColorType.COLORFUL_ACCENT_COLORS

    # Präsentation speichern
    presentation.save("ChangeSmartArtColorStyle_out.pptx", slides.export.SaveFormat.PPTX)
```