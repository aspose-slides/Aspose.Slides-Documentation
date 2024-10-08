---
title: Autofit-Einstellungen verwalten
type: docs
weight: 30
url: /de/python-net/manage-autofit-settings/
keywords: "Textbox, Autofit, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Legt die Autofit-Einstellungen für Textfelder in PowerPoint in Python fest"
---

Standardmäßig verwendet Microsoft PowerPoint beim Hinzufügen eines Textfelds die Einstellung **Form an Text anpassen** für das Textfeld—es passt das Textfeld automatisch an, um sicherzustellen, dass der Text immer hineinpasst. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld automatisch—es erhöht dessen Höhe—um mehr Text aufzunehmen. 
* Wenn der Text im Textfeld kürzer oder kleiner wird, reduziert PowerPoint das Textfeld automatisch—es verringert dessen Höhe—um redundanten Platz zu entfernen. 

In PowerPoint sind dies die 4 wichtigen Parameter oder Optionen, die das Autofit-Verhalten für ein Textfeld steuern: 

* **Nicht anpassen**
* **Text bei Überlauf verkleinern**
* **Form an Text anpassen**
* **Text in der Form umbrechen.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides für Python über .NET bietet ähnliche Optionen—einige Eigenschaften der [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) Klasse—die es Ihnen ermöglichen, das Autofit-Verhalten für Textfelder in Präsentationen zu steuern. 

## **Form an Text anpassen**

Wenn Sie möchten, dass der Text in einem Feld nach Änderungen immer in dieses Feld passt, müssen Sie die Option **Form an Text anpassen** verwenden. Um diese Einstellung festzulegen, setzen Sie die [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) Eigenschaft (aus der [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) Klasse) auf `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Dieser Python-Code zeigt Ihnen, wie Sie festlegen, dass ein Text immer in sein Feld in einer PowerPoint-Präsentation passen muss:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.SHAPE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

Wenn der Text länger oder größer wird, wird das Textfeld automatisch resized (Höhenerhöhung), um sicherzustellen, dass der gesamte Text hineinpasst. Wenn der Text kürzer wird, erfolgt das Umgekehrte. 

## **Nicht anpassen**

Wenn Sie möchten, dass ein Textfeld oder eine Form ihre Abmessungen unabhängig von den Änderungen am enthaltenen Text beibehält, müssen Sie die Option **Nicht anpassen** verwenden. Um diese Einstellung festzulegen, setzen Sie die [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) Eigenschaft (aus der [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) Klasse) auf `NONE`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Dieser Python-Code zeigt Ihnen, wie Sie festlegen, dass ein Textfeld immer seine Abmessungen in einer PowerPoint-Präsentation beibehalten muss:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

Wenn der Text zu lang für sein Feld wird, überläuft er. 

## **Text bei Überlauf verkleinern**

Wenn ein Text zu lang für sein Feld wird, können Sie mit der Option **Text bei Überlauf verkleinern** festlegen, dass die Größe und der Abstand des Textes reduziert werden, um ihn in sein Feld zu bringen. Um diese Einstellung festzulegen, setzen Sie die [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) Eigenschaft (aus der [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) Klasse) auf `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Dieser Python-Code zeigt Ihnen, wie Sie festlegen, dass ein Text bei Überlauf in einer PowerPoint-Präsentation verkleinert werden muss:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NORMAL

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}

Wenn die Option **Text bei Überlauf verkleinern** verwendet wird, wird die Einstellung nur angewendet, wenn der Text zu lang für sein Feld wird. 

{{% /alert %}}

## **Text umbrechen**

Wenn Sie möchten, dass der Text in einer Form innerhalb dieser Form umgebrochen wird, wenn der Text den Rand der Form (nur Breite) überschreitet, müssen Sie den Parameter **Text in der Form umbrechen** verwenden. Um diese Einstellung festzulegen, müssen Sie die [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) Eigenschaft (aus der [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) Klasse) auf `1` setzen. 

Dieser Python-Code zeigt Ihnen, wie Sie die Wrap-Text-Einstellung in einer PowerPoint-Präsentation verwenden:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    autoShape.text_frame.paragraphs[0].portions.add(portion)

    textFrameFormat = autoShape.text_frame.text_frame_format
    textFrameFormat.autofit_type = slides.TextAutofitType.NONE
    textFrameFormat.wrap_text = 1

    pres.save("Output-presentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Hinweis" color="warning" %}} 

Wenn Sie die `wrap_text` Eigenschaft für eine Form auf `0` setzen, wird der Text innerhalb der Form, wenn er länger als die Breite der Form wird, in einer einzigen Zeile über die Ränder der Form hinaus verlängert. 

{{% /alert %}}