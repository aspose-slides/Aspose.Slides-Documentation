---
title: Gesamten Folienhintergrund aus einer Präsentation als Bild extrahieren
linktitle: Gesamter Folienhintergrund
type: docs
weight: 95
url: /de/python-net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- Folie
- Hintergrund
- Folienhintergrund
- endgültiger Hintergrund
- Hintergrund zu Bild
- PowerPoint
- OpenDocument
- Präsentation
- PPT
- PPTX
- ODP
- Python
- Aspose.Slides
description: "Extrahieren Sie vollständige Folienhintergründe als Bilder aus PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET und vereinfachen Sie visuelle Arbeitsabläufe."
---

## **Gesamten Folienhintergrund erhalten**

In PowerPoint‑Präsentationen kann der Folienhintergrund aus vielen Elementen bestehen. Neben dem als [Folienhintergrund](/slides/de/python-net/presentation-background/) festgelegten Bild kann der endgültige Hintergrund durch das Präsentationsthema, das Farbschema sowie die Formen, die auf der Master‑Folie und der Layout‑Folie platziert sind, beeinflusst werden.

Aspose.Slides für Python bietet keine einfache Methode, um den gesamten Folienhintergrund einer Präsentation als Bild zu extrahieren, aber Sie können die nachstehenden Schritte ausführen:
1. Laden Sie die Präsentation mit der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
2. Ermitteln Sie die Foliengröße aus der Präsentation.
3. Wählen Sie eine Folie aus.
4. Erstellen Sie eine temporäre Präsentation.
5. Setzen Sie die gleiche Foliengröße in der temporären Präsentation.
6. Klonen Sie die ausgewählte Folie in die temporäre Präsentation.
7. Löschen Sie die Formen aus der geklonten Folie.
8. Konvertieren Sie die geklonte Folie in ein Bild.

Das folgende Codebeispiel extrahiert den gesamten Folienhintergrund einer Präsentation als Bild.
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

**Werden komplexe Verläufe, Texturen oder Bildfüllungen von einer Master‑Folie im resultierenden Hintergrundbild erhalten bleiben?**

Ja. Aspose.Slides rendert Verlauf-, Bild‑ und Texturfüllungen, die auf der Folie, dem Layout oder dem Master definiert sind. Wenn Sie das Aussehen von vererbten Mastern isolieren möchten, [setzen Sie einen eigenen Hintergrund](/slides/de/python-net/presentation-background/) auf die aktuelle Folie, bevor Sie exportieren.

**Kann ich dem resultierenden Hintergrundbild vor dem Speichern ein Wasserzeichen hinzufügen?**

Ja. Sie können ein [Wasserzeichen](/slides/de/python-net/watermark/)‑Form oder -Bild auf einer Arbeitskopie der Folie [hinzufügen](/slides/de/python-net/clone-slides/) (hinter anderen Inhalten) und dann exportieren. So erzeugen Sie ein Hintergrundbild, das das Wasserzeichen bereits enthält.

**Kann ich den Hintergrund für ein bestimmtes Layout oder einen Master erhalten, ohne ihn an eine vorhandene Folie zu binden?**

Ja. Greifen Sie auf den gewünschten Master oder das Layout zu, wenden Sie ihn auf eine [temporäre Folie](/slides/de/python-net/clone-slides/) mit der erforderlichen Größe an und exportieren Sie diese Folie, um den von diesem Layout oder Master abgeleiteten Hintergrund zu erhalten.

**Gibt es Lizenzbeschränkungen, die den Bildexport betreffen?**

Render‑Funktionen sind mit einer [gültigen Lizenz](/slides/de/python-net/licensing/) vollständig verfügbar. Im Evaluierungsmodus können Ausgaben Einschränkungen wie ein Wasserzeichen enthalten. Aktivieren Sie die Lizenz einmal pro Prozess, bevor Sie Batch‑Exporte ausführen.