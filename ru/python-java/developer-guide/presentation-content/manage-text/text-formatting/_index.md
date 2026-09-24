---
title: Форматирование текста презентации в Python через Java
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/python-java/text-formatting/
keywords:
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- межсимвольный интервал
- свойства шрифта
- семейство шрифтов
- поворот текста
- угол вращения
- текстовая рамка
- межстрочный интервал
- свойство автоподгонки
- привязка текстовой рамки
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Форматируйте и стилизуйте текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

Эта статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via Java. Рассматриваются цвета фона, прозрачность, межсимвольный интервал, свойства шрифта, вращение, межабзацный интервал, поведение автоподгонки, привязка текста, табуляция и настройки языка.

В приведённых ниже примерах мы будем использовать файл с именем “sample.pptx”, который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

Для поиска и выделения буквального текста или совпадений регулярных выражений см. [Поиск и замена текста](/slides/ru/python-java/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat), чтобы задать цвет подсветки по умолчанию для абзаца, либо [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/) для отдельных частей текста.

Следующий пример кода показывает, как установить цвет фона для **всего абзаца**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Установить цвет подсветки для всего абзаца.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Серый абзац](gray_paragraph.png)

Пример кода ниже демонстрирует, как установить цвет фона для **частей текста с полужирным шрифтом**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Установить цвет подсветки для части текста.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Серые части текста](gray_text_portions.png)

## **Выравнивать абзацы текста**

Используйте [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setAlignment), чтобы задать выравнивание абзаца внутри текстовой рамки. Значение может быть по центру, по левому краю, по правому краю, выровнено по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац **по центру**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Установить выравнивание абзаца по центру.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Выравненный абзац](aligned_paragraph.png)

## **Установить прозрачность текста**

Прозрачность текста управляется через альфа‑компонент цвета, присвоенного [PortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Пример кода ниже показывает, как применить прозрачность к **всему абзацу**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Установить цвет заливки текста в прозрачный цвет.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **частям текста с полужирным шрифтом**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Установить прозрачность части текста.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Прозрачные части текста](transparent_text_portions.png)

## **Установить межсимвольный интервал текста**

Используйте [PortionFormat.setSpacing](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/), чтобы расширить или сжать интервал между символами в текстовом блоке.

Следующий Python‑код показывает, как расширить межсимвольный интервал в **всём абзаце**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Увеличить интервал между символами.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как расширить межсимвольный интервал в **частях текста с полужирным шрифтом**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
            portion.getPortionFormat().setSpacing(3) # Увеличить интервал между символами.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Межсимвольный интервал в частях текста](character_spacing_in_text_portions.png)

### **Отключить кернинг для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть слегка более плотно, чем тот же текст в PowerPoint. Это происходит потому, что PowerPoint может игнорировать данные кернинга для определённых шрифтов, даже если шрифт содержит корректные данные кернинга и кернинг включён в настройках PowerPoint.

Чтобы сделать вывод более похожим на PowerPoint в таких случаях, можно отключить кернинг для частей текста, использующих затронутый шрифт. Установите [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/) в значение, значительно превышающее фактический размер шрифта:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Эта настройка предотвращает применение кернинга к соответствующим частям текста и может помочь согласовать отрисовку Aspose.Slides с визуальным выводом PowerPoint для шрифтов, затронутых этим специфическим для PowerPoint поведением.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) или для отдельных частей через [PortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/).

Следующий код задаёт шрифт и стиль текста для всего абзаца: применяется размер шрифта, полужирный, курсив, пунктирное подчёркивание и шрифт Times New Roman для всех частей абзаца.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Установить свойства шрифта для абзаца.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Свойства шрифта для абзаца](font_properties_for_paragraph.png)

Пример кода ниже применяет аналогичные свойства к **частям текста с полужирным шрифтом**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Установить свойства шрифта для части текста.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Свойства шрифта для частей текста](font_properties_for_text_portions.png)

## **Установить поворот текста**

Используйте [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setTextVerticalType), чтобы задать предопределённую ориентацию текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре как `Vertical270`, что вращает текст **на 90 градусов против часовой стрелки**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Поворот текста](text_rotation.png)

## **Установить пользовательский поворот для текстовых рамок**

Используйте [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setRotationAngle), чтобы задать пользовательский угол вращения для [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/).

Пример кода ниже вращает текстовую рамку на 3 градуса по часовой стрелке внутри фигуры:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Пользовательский поворот текста](custom_text_rotation.png)

## **Установить межстрочный интервал абзацев**

Aspose.Slides предоставляет [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setSpaceBefore) и [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setSpaceWithin) для управления интервалом абзацев. Эти свойства используются так:

* Укажите положительное значение, чтобы задать межстрочный интервал в процентах от высоты строки.
* Укажите отрицательное значение, чтобы задать межстрочный интервал в пунктах.

Следующий пример кода показывает, как задать межстрочный интервал внутри абзаца:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Межстрочный интервал в абзаце](line_spacing.png)

## **Установить тип автоподгонки для текстовых рамок**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setAutofitType) определяет, как текст ведёт себя, когда превышает границы контейнера. Используйте его, чтобы контролировать, будет ли текст уменьшаться, вылезать за пределы или автоматически менять размер фигуры.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняется ширина текста или фигуры, см. [Подсчёт отрисованных строк](/slides/ru/python-java/manage-paragraph/). Само количество строк не указывает, выходит ли текст за пределы контейнера.

## **Установить привязку текстовых рамок**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setAnchoringType) определяет, как текст позиционируется вертикально внутри фигуры, например вверху, по центру или внизу.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить табуляцию текста**

Используйте [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) и [ParagraphFormat.getTabs](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#getTabs), чтобы настроить табуляцию в абзаце.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Табуляция абзаца](paragraph_tabs.png)

## **Установить язык проверки правописания**

Aspose.Slides предоставляет [PortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/), который позволяет задать язык проверки правописания для части текста. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

Следующий пример кода показывает, как задать язык проверки правописания для части текста:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Установить идентификатор проверочного языка.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить язык по умолчанию**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), чтобы определить язык по умолчанию для текста, создаваемого при загрузке или создании презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Добавить прямоугольную фигуру с текстом.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Проверить язык первой части текста.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Следующий пример кода показывает, как задать шрифт полужирный размером 14 пунктов по умолчанию для всего текста на всех слайдах новой презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Получить формат абзаца верхнего уровня.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Извлечь текст с эффектом “Все заглавные”**

В PowerPoint применение эффекта **All Caps** делает текст заглавным на слайде, даже если он был введён строчными буквами. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст точно так, как он был введён. Чтобы сопоставить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно `All`.

Допустим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![Эффект All Caps](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Вывод:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Часто задаваемые вопросы**

**Как изменить текст в таблице на слайде?**

Чтобы изменить текст в таблице на слайде, используйте [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/). Проходите по ячейкам и обновляйте каждую ячейку через [Cell.getTextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cell/#getTextFrame) и форматирование абзацев через [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [PortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/). Установите [FillFormat.setFillType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/#setFillType) в значение [FillType.Gradient](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filltype/#Gradient) и настройте градиентные стопы, направление и прозрачность.