---
title: Verbessern Sie Ihre Präsentationen mit AutoFit in Python
linktitle: Autofit-Einstellungen
type: docs
weight: 30
url: /de/python-java/manage-autofit-settings/
keywords:
- Textfeld
- AutoFit
- Kein AutoFit
- Text anpassen
- Text verkleinern
- Text umbrechen
- Formgröße ändern
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie AutoFit-Einstellungen in Aspose.Slides für Python über Java verwalten, um die Textdarstellung in Ihren PowerPoint- und OpenDocument-Präsentationen zu optimieren und die Lesbarkeit des Inhalts zu verbessern."
---
## **Einführung**

Standardmäßig verwendet Microsoft PowerPoint beim Hinzufügen eines Textfeldes die Einstellung **Resize shape to fix text** – das Textfeld wird automatisch in der Größe angepasst, damit sein Text immer hineinpasst. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld – erhöht die Höhe – damit mehr Text hineingepasst werden kann. 
* Wenn der Text im Textfeld kürzer oder kleiner wird, verkleinert PowerPoint das Textfeld – reduziert die Höhe – um überflüssigen Raum zu entfernen. 

In PowerPoint gibt es vier wichtige Parameter bzw. Optionen, die das Autofit‑Verhalten eines Textfeldes steuern: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java bietet ähnliche Optionen – einige Eigenschaften der Klasse [TextFrameFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/) – die es ermöglichen, das Autofit‑Verhalten von Textfeldern in Präsentationen zu steuern. 

## **Resize a Shape to Fit Text**

Wenn der Text in einem Feld immer in dieses Feld passen soll, nachdem Änderungen am Text vorgenommen wurden, muss die Option **Resize shape to fix text** verwendet werden. Um diese Einstellung festzulegen, verwenden Sie die Methode [setAutofitType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setAutofitType) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/)) mit [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/textautofittype/#Shape).

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Dieser Python‑Code zeigt, wie Sie festlegen, dass ein Text immer in sein Feld in einer PowerPoint‑Präsentation passen muss:

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

Wird der Text länger oder größer, wird das Textfeld automatisch in der Höhe vergrößert, sodass der gesamte Text hineinpasst. Wird der Text kürzer, geschieht das Gegenteil. 

## **Do Not Autofit**

Wenn ein Textfeld oder eine Form ihre Abmessungen unabhängig von Änderungen am enthaltenen Text beibehalten soll, muss die Option **Do not Autofit** verwendet werden. Um diese Einstellung festzulegen, verwenden Sie die Methode [setAutofitType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setAutofitType) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/)) mit [None](https://reference.aspose.com/slides/de/python-java/aspose.slides/textautofittype/#None). 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Dieser Python‑Code zeigt, wie Sie festlegen, dass ein Textfeld seine Abmessungen in einer PowerPoint‑Präsentation immer beibehält:

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
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wird der Text zu lang für sein Feld, läuft er heraus. 

## **Shrink Text on Overflow**

Wenn ein Text zu lang für sein Feld wird, können Sie mit der Option **Shrink text on overflow** festlegen, dass Größe und Abstand des Textes verringert werden, damit er in das Feld passt. Um diese Einstellung festzulegen, verwenden Sie die Methode [setAutofitType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setAutofitType) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/)) mit [Normal](https://reference.aspose.com/slides/de/python-java/aspose.slides/textautofittype/#Normal).

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Dieser Python‑Code zeigt, wie Sie festlegen, dass ein Text bei Überlauf verkleinert wird in einer PowerPoint‑Präsentation:

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

{{% alert title="Hinweis" color="info" %}}

Wenn die Option **Shrink text on overflow** verwendet wird, wird die Einstellung nur angewendet, wenn der Text zu lang für sein Feld wird. 

{{% /alert %}}

## **Wrap Text**

Wenn der Text in einer Form umbrochen werden soll, sobald er die rechte Grenze der Form (nur die Breite) überschreitet, muss der Parameter **Wrap text in shape** verwendet werden. Um diese Einstellung festzulegen, verwenden Sie die Methode [setWrapText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setWrapText) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/)) mit [NullableBool.True](https://reference.aspose.com/slides/de/python-java/aspose.slides/nullablebool/#True). 

Dieser Python‑Code zeigt, wie Sie die Einstellung Wrap Text in einer PowerPoint‑Präsentation nutzen:

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
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warnung" color="warning" %}} 

Wenn Sie die Methode [setWrapText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setWrapText) mit [NullableBool.False](https://reference.aspose.com/slides/de/python-java/aspose.slides/nullablebool/#False) für eine Form verwenden, wird der Text, sobald er länger als die Breite der Form wird, über die Formgrenzen hinaus in einer einzelnen Zeile verlängert. 

{{% /alert %}}

## **FAQ**

**Beeinflussen die internen Ränder des Textfeldes das AutoFit?**

Ja. Padding (interne Ränder) reduziert den nutzbaren Textbereich, sodass AutoFit früher greift – die Schrift wird früher verkleinert oder die Form früher angepasst. Überprüfen und passen Sie die Ränder an, bevor Sie AutoFit feinjustieren.

**Wie verhält sich AutoFit bei manuellen und weichen Zeilenumbrüchen?**

Erzwungene Umbrüche bleiben erhalten, und AutoFit passt Schriftgröße und Abstand um sie herum an. Das Entfernen unnötiger Umbrüche reduziert häufig, wie aggressiv AutoFit den Text verkleinern muss.

**Wirken sich Änderungen der Design‑Schriftart oder Schriftart‑Ersetzungen auf das AutoFit‑Ergebnis aus?**

Ja. Das Ersetzen durch eine Schriftart mit anderen Glyphen‑Metriken ändert Breite/Höhe des Textes, was die endgültige Schriftgröße und Zeilenumbrüche verändern kann. Nach jeder Schriftart‑Änderung oder -Ersetzung sollten Sie die Folien erneut prüfen.