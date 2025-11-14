---
title: Holen Sie sich den gesamten Hintergrund der Präsentationsfolie als Bild
type: docs
weight: 95
url: /de/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- folien
- hintergrund
- folienhintergrund
- hintergrund zu einem bild
- PowerPoint
- PPT
- PPTX
- PowerPoint-Präsentation
- Python
- Aspose.Slides für Python
---

In PowerPoint-Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Neben dem Bild, das als [Folienhintergrund](/slides/python-net/presentation-background/) festgelegt ist, kann der endgültige Hintergrund von dem Präsentationsthema, dem Farbschema und den Formen auf der Masterfolie und Layoutfolie beeinflusst werden.

Aspose.Slides für Python bietet keine einfache Methode, um den gesamten Hintergrund der Präsentationsfolie als Bild zu extrahieren, aber Sie können die folgenden Schritte befolgen, um dies zu tun:
1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Foliengröße aus der Präsentation.
1. Wählen Sie eine Folie aus.
1. Erstellen Sie eine temporäre Präsentation.
1. Setzen Sie die gleiche Foliengröße in der temporären Präsentation.
1. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
1. Löschen Sie die Formen aus der geklonten Folie.
1. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Hintergrund der Präsentationsfolie als Bild.
```py
slide_index = 0
image_scale = 1

with slides.Presentation("sample.pptx") as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[slide_index]

    with slides.Presentation() as temp_presentation:
        temp_presentation.slide_size.set_size(
            slide_size.width, slide_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)

        cloned_slide = temp_presentation.slides.add_clone(slide)
        cloned_slide.shapes.clear()

        with cloned_slide.get_image(image_scale, image_scale) as background:
            background.save("output.png", slides.ImageFormat.PNG)
```