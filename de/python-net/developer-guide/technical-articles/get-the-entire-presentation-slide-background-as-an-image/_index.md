---
title: Den gesamten Folienhintergrund aus einer Präsentation als Bild extrahieren
linktitle: Gesamter Folienhintergrund
type: docs
weight: 95
url: /de/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- Folie
- Hintergrund
- Folienhintergrund
- Endhintergrund
- Hintergrund zu Bild
- PowerPoint
- OpenDocument
- Präsentation
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Extrahieren Sie komplette Folienhintergründe als Bilder aus PowerPoint- und OpenDocument-Präsentationen mithilfe von Aspose.Slides für Python via .NET und optimieren Sie damit visuelle Workflows."
---

## **Den gesamten Folienhintergrund erhalten**

In PowerPoint‑Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Neben dem als [Folienhintergrund](/slides/de/python-net/presentation-background/) festgelegten Bild kann der endgültige Hintergrund durch das Präsentationsthema, das Farbschema und die auf der Master‑Folie sowie der Layout‑Folie platzierten Formen beeinflusst werden.

Aspose.Slides for Python bietet keine einfache Methode, um den gesamten Folienhintergrund einer Präsentation als Bild zu extrahieren, aber Sie können die folgenden Schritte ausführen:
1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Ermitteln Sie die Foliengröße aus der Präsentation.
1. Wählen Sie eine Folie aus.
1. Erstellen Sie eine temporäre Präsentation.
1. Setzen Sie dieselbe Foliengröße in der temporären Präsentation.
1. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
1. Löschen Sie die Formen von der geklonten Folie.
1. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Folienhintergrund der Präsentation als Bild.
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


## **FAQ**

**Werden komplexe Verläufe, Texturen oder Bildfüllungen einer Master‑Folie im resultierenden Hintergrundbild erhalten?**

Ja. Aspose.Slides rendert Gradient‑, Bild‑ und Textur‑Füllungen, die auf der Folie, dem Layout oder dem Master definiert sind. Wenn Sie das Aussehen von geerbten Mastern isolieren möchten, [setzen Sie einen eigenen Hintergrund](/slides/de/python-net/presentation-background/) auf der aktuellen Folie, bevor Sie exportieren.

**Kann ich dem resultierenden Hintergrundbild vor dem Speichern ein Wasserzeichen hinzufügen?**

Ja. Sie können ein [Wasserzeichen hinzufügen](/slides/de/python-net/watermark/)‑Form oder Bild auf einer Arbeits‑[Kopie der Folie](/slides/de/python-net/clone-slides/) (hinter anderem Inhalt platziert) hinzufügen und anschließend exportieren. So können Sie ein Hintergrundbild mit eingebettetem Wasserzeichen erzeugen.

**Kann ich den Hintergrund für ein bestimmtes Layout oder einen Master erhalten, ohne ihn an eine vorhandene Folie zu binden?**

Ja. Greifen Sie auf den gewünschten Master oder das Layout zu, wenden Sie es auf eine [temporäre Folie](/slides/de/python-net/clone-slides/) mit der erforderlichen Größe an und exportieren Sie diese Folie, um den aus diesem Layout oder Master abgeleiteten Hintergrund zu erhalten.

**Gibt es Lizenzbeschränkungen, die den Bildexport beeinflussen?**

Render‑Funktionen sind mit einer [gültigen Lizenz](/slides/de/python-net/licensing/) vollständig verfügbar. Im Evaluierungsmodus kann die Ausgabe Einschränkungen wie ein Wasserzeichen enthalten. Aktivieren Sie die Lizenz einmal pro Prozess, bevor Sie Batch‑Exporte starten.