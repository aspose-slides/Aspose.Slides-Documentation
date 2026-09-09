---
title: Verbessern Sie Ihre Präsentationen mit AutoFit in Python
linktitle: Autofit-Einstellungen
type: docs
weight: 30
url: /de/python-java/manage-autofit-settings/
keywords:
- Textfeld
- Autofit
- Kein Autofit
- Text einpassen
- Text verkleinern
- Text umbrechen
- Formgröße anpassen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie die AutoFit-Einstellungen in Aspose.Slides für Python via Java verwalten, um die Textdarstellung in Ihren PowerPoint- und OpenDocument-Präsentationen zu optimieren und die Lesbarkeit des Inhalts zu verbessern."
---
## **Einführung**

Standardmäßig verwendet Microsoft PowerPoint für ein Textfeld die Einstellung **Resize shape to fit text** – das Textfeld wird automatisch in seiner Größe angepasst, sodass der Text stets hineinpasst.

![Textfeld in PowerPoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld automatisch – die Höhe wird erhöht – um mehr Text aufnehmen zu können.  
* Wenn der Text im Textfeld kürzer oder kleiner wird, verkleinert PowerPoint das Textfeld automatisch – die Höhe wird verringert – um überflüssigen Abstand zu entfernen.

In PowerPoint sind dies die vier wichtigen Parameter bzw. Optionen, die das Autofit‑Verhalten eines Textfeldes steuern:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![Autofit‑Optionen PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java bietet ähnliche Optionen – einige Eigenschaften der Klasse [TextFrameFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/)-Klasse – die es ermöglichen, das Autofit‑Verhalten von Textfeldern in Präsentationen zu steuern.

## **Shape auf Text anpassen**

Wenn der Text in einem Feld immer in das Feld passen soll, nachdem Änderungen am Text vorgenommen wurden, muss die Option **Resize shape to fit text** verwendet werden. Um diese Einstellung festzulegen, nutzen Sie die Methode [setAutofitType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setAutofitType) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/)) mit [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/textautofittype/#Shape).

![alwaysfit‑setting‑PowerPoint](alwaysfit-setting-powerpoint.png)

Dieser Python‑Code zeigt, wie Sie festlegen, dass der Text immer in sein Feld passen muss, in einer PowerPoint‑Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wird der Text länger oder größer, wird das Textfeld automatisch vergrößert (Höhe wird erhöht), damit der gesamte Text hineinpasst. Wird der Text kürzer, geschieht das Gegenteil.

## **Do Not Autofit**

Wenn ein Textfeld oder eine Form ihre Abmessungen unabhängig von Änderungen des darin enthaltenen Textes beibehalten soll, muss die Option **Do not Autofit** verwendet werden. Um diese Einstellung festzulegen, nutzen Sie die Methode [setAutofitType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setAutofitType) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/)) mit [None](https://reference.aspose.com/slides/de/python-java/aspose.slides/textautofittype/#None).

![donotautofit‑setting‑PowerPoint](donotautofit-setting-powerpoint.png)

Dieser Python‑Code zeigt, wie Sie festlegen, dass ein Textfeld stets seine Abmessungen behält, in einer PowerPoint‑Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wird der Text zu lang für sein Feld, fließt er über den Rand hinaus. 

## **Shrink Text on Overflow**

Wenn der Text zu lang für sein Feld wird, können Sie die Option **Shrink text on overflow** verwenden, um festzulegen, dass Größe und Abstand des Textes reduziert werden, damit er in das Feld passt. Um diese Einstellung festzulegen, nutzen Sie die Methode [setAutofitType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setAutofitType) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/)) mit [Normal](https://reference.aspose.com/slides/de/python-java/aspose.slides/textautofittype/#Normal).

![shrinktextonoverflow‑setting‑PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Dieser Python‑Code zeigt, wie Sie festlegen, dass Text bei Überlauf verkleinert wird, in einer PowerPoint‑Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
Wird die Option **Shrink text on overflow** verwendet, wird die Einstellung nur angewendet, wenn der Text zu lang für sein Feld wird. 
{{% /alert %}}

## **Wrap Text**

Wenn der Text in einer Form umbrochen werden soll, sobald er über die Begrenzung der Form (nur Breite) hinausgeht, muss der Parameter **Wrap text in shape** verwendet werden. Um diese Einstellung festzulegen, nutzen Sie die Methode [setWrapText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setWrapText) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/)) mit [NullableBool.True_](https://reference.aspose.com/slides/de/python-java/aspose.slides/nullablebool/#True).

Dieser Python‑Code zeigt, wie Sie die Einstellung Wrap Text in einer PowerPoint‑Präsentation verwenden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
Verwenden Sie die Methode [setWrapText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setWrapText) mit [NullableBool.False](https://reference.aspose.com/slides/de/python-java/aspose.slides/nullablebool/#False) für eine Form, wird der Text, wenn er länger als die Formbreite wird, über die Formgrenzen hinaus in einer einzigen Zeile fortgesetzt. 
{{% /alert %}}

## **FAQ**

**Beeinflussen die internen Abstände des Textfelds das AutoFit?**

Ja. Innenabstände (Padding) verkleinern den nutzbaren Platz für Text, sodass AutoFit früher eingreift – die Schrift wird früher verkleinert oder die Form früher angepasst. Passen Sie die Abstände vor der Feinabstimmung von AutoFit an.

**Wie interagiert AutoFit mit manuellen und weichen Zeilenumbrüchen?**

Erzwungene Umbrüche bleiben erhalten, und AutoFit passt Schriftgröße und Abstand um diese herum an. Das Entfernen unnötiger Umbrüche reduziert häufig das aggressive Schrumpfen des Textes durch AutoFit.

**Wirkt sich das Ändern der Design‑Schriftart oder das Auslösen einer Schriftart‑Substitution auf die AutoFit‑Ergebnisse aus?**

Ja. Der Austausch einer Schriftart mit anderen Glyphen‑Metriken ändert Breite/Höhe des Textes, was die endgültige Schriftgröße und Zeilenumbrüche beeinflussen kann. Nach jeder Schriftart‑Änderung oder -Substitution sollten die Folien erneut geprüft werden.