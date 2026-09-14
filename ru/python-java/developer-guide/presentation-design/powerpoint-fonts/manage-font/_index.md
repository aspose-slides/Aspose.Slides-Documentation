---
title: Управление шрифтами в презентациях с помощью Python через Java
linktitle: Управление шрифтами
type: docs
weight: 10
url: /ru/python-java/manage-fonts/
keywords:
- управление шрифтами
- свойства шрифтов
- абзац
- форматирование текста
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Контролируйте шрифты в Python через Java с Aspose.Slides: внедряйте, заменяйте и загружайте пользовательские шрифты, чтобы презентации PPT, PPTX и ODP оставались чистыми, соответствующими бренду и согласованными."
---
## **Обзор**

Aspose.Slides позволяет управлять свойствами шрифтов в тексте презентации непосредственно из вашего кода. Вы можете получать доступ к тексту в слайдах через фигуры, текстовые кадры, абзацы и части, а затем применять форматирование к выбранному тексту.

В этой статье объясняется, как настроить свойства шрифта для существующего текста в презентации, включая семейство шрифтов, полужирный и курсивный стили, выравнивание абзаца и цвет шрифта. Также показано, как создать текстовое поле, добавить в него текст и задать свойства шрифта, такие как семейство шрифтов, полужирный, курсив, подчеркивание, размер шрифта и цвет, перед сохранением результата в файл PPTX.

## **Управление свойствами шрифта**
{{% alert color="info" title="Note" %}} 

Презентации обычно содержат как текст, так и изображения. Текст можно форматировать различными способами, либо для выделения определённых разделов и слов, либо для соответствия корпоративным стилям. Форматирование текста помогает пользователям менять внешний вид контента презентации. В этой статье показано, как использовать Aspose.Slides for Python via Java для настройки свойств шрифта абзацев текста на слайдах.

{{% /alert %}} 

Для управления свойствами шрифта абзаца с помощью Aspose.Slides for Python via Java:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Получите доступ к фигуре [Placeholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/placeholder/) на слайде как к [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/).
1. Получите [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) из [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/), предоставленного [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/).
1. Выровняйте абзац по ширине.
1. Доступ к [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/) текста [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/).
1. Определите шрифт с помощью [FontData](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fontdata/) и установите **Font** для текста [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/) соответственно.
   1. Установите шрифт полужирным.
   1. Установите шрифт курсивом.
1. Установите цвет шрифта с помощью [FillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/), предоставляемого объектом [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/).
1. Сохраните изменённую презентацию в файл PPTX.

Реализация вышеуказанных шагов приведена ниже. Она берёт исходную презентацию без форматирования и применяет к шрифтам одного из слайдов нужные изменения. На скриншотах ниже показан входной файл и как фрагменты кода меняют его. Код изменяет шрифт, цвет и стиль шрифта.

|![Текст во входной презентации](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Рисунок: Текст во входном файле**|

|![Текст с обновленным форматированием шрифта](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Рисунок: Тот же текст с обновленным форматированием**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Загрузить презентацию.
presentation = Presentation("FontProperties.pptx")
try:
    # Получить первый слайд и текстовые кадры его первых двух заполнителей.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Получить первый абзац в каждом текстовом кадре.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Получить первую часть в каждом абзаце.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Определить и назначить новые шрифты.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Установить шрифты полужирными и курсивными.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Установить цвета шрифтов.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Сохранить презентацию.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка свойств шрифта текста**
{{% alert color="info" title="Note" %}} 

Как упоминалось в **Управление свойствами шрифта**, [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/) используется для хранения текста с одинаковым стилем форматирования в абзаце. В этой статье показано, как использовать Aspose.Slides for Python via Java для создания текстового поля с некоторым текстом и последующего определения конкретного шрифта и различных других свойств шрифта.

{{% /alert %}} 

Для создания текстового поля и установки свойств шрифта текста в нём:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте [AutoShape] типа **Rectangle** на слайд.
1. Удалите стиль заливки, связанный с [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/).
1. Получите доступ к [TextFrame] у [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/).
1. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/).
1. Получите объект [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/), связанный с [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/).
1. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/).
1. Установите другие свойства шрифта, такие как полужирный, курсив, подчеркивание, цвет и высоту, используя соответствующие свойства, доступные в объекте [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/).
1. Запишите изменённую презентацию в файл PPTX.

|![Текст с применёнными свойствами шрифта](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Рисунок: Текст с некоторыми свойствами шрифта, установленными Aspose.Slides for Python via Java**|

```python
import jpage
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Получить первый слайд и добавить прямоугольник.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Удалить заливку фигуры.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Добавить текст в текстовый кадр фигуры.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Установить семейство шрифта.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Установить полужирный, курсив, подчеркивание и размер шрифта.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Установить цвет шрифта.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Сохранить презентацию.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```