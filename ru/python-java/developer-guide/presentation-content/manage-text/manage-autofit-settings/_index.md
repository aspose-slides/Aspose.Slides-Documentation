---
title: Улучшите свои презентации с помощью AutoFit в Python
linktitle: Настройки автоподгонки
type: docs
weight: 30
url: /ru/python-java/manage-autofit-settings/
keywords:
- текстовое поле
- автоподгонка
- не использовать автоподгонку
- подгонка текста
- уменьшать текст
- перенос текста
- изменять размер фигуры
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как управлять настройками AutoFit в Aspose.Slides для Python через Java, чтобы оптимизировать отображение текста в ваших презентациях PowerPoint и OpenDocument и повысить читаемость контента."
---
## **Введение**

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Resize shape to fit text** для текстового поля — оно автоматически изменяет размер текстового поля, чтобы текст всегда помещался в нём.

![Текстовое поле в PowerPoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает текстовое поле — увеличивает его высоту — чтобы разместить больше текста.  
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — уменьшает его высоту — чтобы убрать лишнее пространство.

В PowerPoint это 4 важных параметра или опции, которые управляют поведением автоподгонки для текстового поля:

* **Не использовать автоподгонку**
* **Уменьшать текст при переполнении**
* **Изменять размер фигуры, чтобы текст помещался**
* **Переносить текст в фигуре.**

![параметры автоподгонки PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java предоставляет похожие параметры — некоторые свойства класса [TextFrameFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/), которые позволяют управлять поведением автоподгонки для текстовых полей в презентациях.

## **Изменять размер фигуры, чтобы текст помещался**

Если вы хотите, чтобы текст в поле всегда помещался в этом поле после изменения текста, необходимо использовать опцию **Resize shape to fit text**. Чтобы задать эту настройку, используйте метод [setAutofitType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setAutofitType) (из класса [TextFrameFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/)) с параметром [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textautofittype/#Shape).

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

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

Если текст становится длиннее или больше, текстовое поле будет автоматически изменено в размере (увеличена высота), чтобы весь текст поместился. Если текст становится короче, произойдёт обратное действие.

## **Не использовать автоподгонку**

Если вы хотите, чтобы текстовое поле или фигура сохраняли свои размеры независимо от изменений текста, необходимо использовать опцию **Do not Autofit**. Чтобы задать эту настройку, используйте метод [setAutofitType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setAutofitType) (из класса [TextFrameFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/)) с параметром [None](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textautofittype/#None).

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

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

Когда текст становится слишком длинным для своего поля, он выходит за его границы.

## **Уменьшать текст при переполнении**

Если текст становится слишком длинным для своего поля, вы можете использовать опцию **Shrink text on overflow**, чтобы указать, что размер и межбуквенный интервал текста должны уменьшаться, чтобы он поместился в поле. Чтобы задать эту настройку, используйте метод [setAutofitType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setAutofitType) (из класса [TextFrameFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/)) с параметром [Normal](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textautofittype/#Normal).

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

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
При использовании опции **Shrink text on overflow** настройка применяется только тогда, когда текст становится слишком длинным для своего поля. 
{{% /alert %}}

## **Переносить текст в фигуре**

Если вы хотите, чтобы текст в фигуре переносился внутри этой фигуры, когда текст выходит за границы фигуры (только по ширине), необходимо использовать параметр **Wrap text in shape**. Чтобы задать эту настройку, используйте метод [setWrapText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setWrapText) (из класса [TextFrameFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/)) с параметром [NullableBool.True_](https://reference.aspose.com/slides/ru/python-java/aspose.slides/nullablebool/#True).

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
Если вы вызываете метод [setWrapText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setWrapText) с параметром [NullableBool.False](https://reference.aspose.com/slides/ru/python-java/aspose.slides/nullablebool/#False) для фигуры, когда текст внутри фигуры становится длиннее её ширины, текст будет выходить за границы фигуры в одну строку. 
{{% /alert %}}

## **FAQ**

**Влияют ли внутренние отступы текстового кадра на AutoFit?**

Да. Внутренние отступы уменьшают доступную площадь для текста, поэтому AutoFit срабатывает раньше — шрифт уменьшается или фигура изменяется быстрее. Проверьте и отрегулируйте отступы перед настройкой AutoFit.

**Как AutoFit взаимодействует с принудительными и мягкими разрывами строк?**

Принудительные разрывы остаются на месте, а AutoFit подбирает размер шрифта и межстрочный интервал вокруг них. Удаление лишних разрывов часто уменьшает степень сжатия текста AutoFit‑ом.

**Влияет ли изменение шрифта темы или подстановка шрифта на результаты AutoFit?**

Да. Подстановка шрифта с другими метрическими характеристиками меняет ширину/высоту текста, что может изменить конечный размер шрифта и перенос строк. После любой замены шрифта повторно проверьте слайды.