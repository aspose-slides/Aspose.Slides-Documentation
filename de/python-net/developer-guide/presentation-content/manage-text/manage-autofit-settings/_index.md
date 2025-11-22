---
title: Verbessern Sie Ihre Präsentationen mit AutoFit in Python
linktitle: Autofit-Einstellungen
type: docs
weight: 30
url: /de/python-net/manage-autofit-settings/
keywords:
- Textfeld
- Autofit
- Kein Autofit
- Text einpassen
- Text verkleinern
- Text umbrechen
- Formgröße anpassen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie die AutoFit-Einstellungen in Aspose.Slides für Python via .NET verwalten, um die Textdarstellung in Ihren PowerPoint- und OpenDocument-Präsentationen zu optimieren und die Lesbarkeit des Inhalts zu verbessern."
---

Standardmäßig verwendet Microsoft PowerPoint beim Hinzufügen eines Textfelds die **Resize shape to fix text**‑Einstellung für das Textfeld – es ändert automatisch die Größe des Textfelds, um sicherzustellen, dass sein Text immer hineinpasst. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld automatisch – erhöht die Höhe – damit mehr Text hineingepasst werden kann. 
* Wenn der Text im Textfeld kürzer oder kleiner wird, verkleinert PowerPoint das Textfeld automatisch – verringert die Höhe – um überflüssigen Platz zu entfernen. 

Im PowerPoint sind dies die vier wichtigen Parameter bzw. Optionen, die das Autofit‑Verhalten für ein Textfeld steuern: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides für Python via .NET bietet ähnliche Optionen – einige Eigenschaften der Klasse [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) – mit denen Sie das Autofit‑Verhalten von Textfeldern in Präsentationen steuern können. 

## **Formengröße an Text anpassen**

Wenn Sie möchten, dass der Text in einem Feld immer in das Feld passt, nachdem Änderungen am Text vorgenommen wurden, müssen Sie die Option **Resize shape to fix text** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) der Klasse [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) auf `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Wird der Text länger oder größer, wird das Textfeld automatisch in der Größe angepasst (Höhe erhöhen), sodass der gesamte Text hineinpasst. Wird der Text kürzer, geschieht das Gegenteil. 

## **Do Not Autofit**

Wenn ein Textfeld oder eine Form ihre Abmessungen beibehalten soll, unabhängig von Änderungen am enthaltenen Text, müssen Sie die Option **Do not Autofit** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) der Klasse [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) auf `NONE`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Wird der Text zu lang für sein Feld, läuft er heraus. 

## **Shrink Text on Overflow**

Wird ein Text zu lang für sein Feld, können Sie mit der Option **Shrink text on overflow** festlegen, dass Größe und Abstand des Textes reduziert werden, damit er in das Feld passt. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) der Klasse [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) auf `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Info" color="info" %}}
Wird die Option **Shrink text on overflow** verwendet, wird die Einstellung nur angewendet, wenn der Text zu lang für sein Feld wird. 
{{% /alert %}}

## **Wrap Text**

Wenn Sie möchten, dass der Text in einer Form umgebrochen wird, sobald er die Formgrenze (nur die Breite) überschreitet, müssen Sie den Parameter **Wrap text in shape** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) der Klasse [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) auf `NullableBool.TRUE`. 

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="Note" color="warning" %}} 
Setzen Sie die Eigenschaft `wrap_text` für eine Form auf `NullableBool.FALSE`, wird bei Überschreiten der Formbreite der Text in einer einzigen Zeile über die Formgrenzen hinaus erweitert. 
{{% /alert %}}

## **FAQ**

**Beeinflussen die internen Ränder des Textframes AutoFit?**

Ja. Innenabstände (Padding) verkleinern die nutzbare Textfläche, sodass AutoFit früher greift – die Schriftart wird früher verkleinert oder die Form früher angepasst. Prüfen und passen Sie die Ränder an, bevor Sie AutoFit feinjustieren.

**Wie interagiert AutoFit mit manuellen und weichen Zeilenumbrüchen?**

Erzwungene Umbrüche bleiben bestehen, und AutoFit passt Schriftgröße und Abstand um diese herum an. Das Entfernen unnötiger Umbrüche reduziert häufig die Aggressivität, mit der AutoFit den Text verkleinern muss.

**Wirkt sich das Ändern der Design‑Schriftart oder das Auslösen einer Schriftart‑Substitution auf das AutoFit‑Ergebnis aus?**

Ja. Der Austausch gegen eine Schriftart mit anderen Glyphenmaßen ändert Breite/Höhe des Textes, was die endgültige Schriftgröße und den Zeilenumbruch beeinflussen kann. Nach jeder Schriftart‑Änderung oder -Substitution sollten Sie die Folien erneut überprüfen.