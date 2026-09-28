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
- вращение текста
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
description: "Форматировать и оформлять текст в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для Python через Java. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via Java. Рассматриваются фоновые цвета, прозрачность, межсимвольный интервал, свойства шрифта, поворот, межабзацный интервал, автоподгонка, привязка текста, табуляция и языковые настройки.

Если не указано иное, в примерах используется [sample.pptx](sample.pptx). Первая фигура на первом слайде — это текстовое поле, и первый абзац содержит показанный ниже текст. Индексы слайдов и фигур начинаются с нуля. Примеры, выделяющие жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Для поиска и выделения буквального текста или совпадений регулярных выражений см. [Search and Replace Text](/slides/ru/python-java/search-and-replace-text/).

## **Установка фонового цвета текста**

Используйте [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) для задания цвета подсветки по умолчанию для абзаца или [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#getHighlightColor) для отдельных частей текста.

Следующий пример задаёт светло-серую подсветку по умолчанию для первого абзаца. Явные цвета подсветки для отдельных частей текста имеют приоритет над этим значением по умолчанию:

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

Ниже показан пример кода, демонстрирующий, как установить фон для **частей текста с жирным шрифтом**:

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

## **Выравнивание абзацев текста**

Используйте [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setAlignment) для установки выравнивания абзаца внутри текстового кадра. Значение может быть «centered», «left-aligned», «right-aligned», «justified» и т.д.

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

![Выровненный абзац](aligned_paragraph.png)

## **Установка прозрачности текста**

Прозрачность текста управляется альфа‑компонентой цвета, задаваемого для [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#getFillFormat). В приведённых ниже примерах `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Ниже показан пример кода, демонстрирующий, как применить прозрачность к **всему абзацу**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

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

Следующий пример кода показывает, как применить прозрачность к **частям текста с жирным шрифтом**:

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

## **Установка межсимвольного интервала текста**

Используйте [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setSpacing) для увеличения или сжатия интервала между символами в текстовом поле. В примерах добавляется 3 пункта интервала; отрицательные значения сжимают текст.

Следующий код на Python показывает, как увеличить межсимвольный интервал в **всех абзацах**:

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
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Расширить межсимвольный интервал.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Ниже показан пример кода, демонстрирующий, как увеличить межсимвольный интервал в **частях текста с жирным шрифтом**:

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
            portion.getPortionFormat().setSpacing(3) # Расширить межсимвольный интервал.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Межсимвольный интервал в частях текста](character_spacing_in_text_portions.png)

### **Отключение кернинга для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, выглядит чуть плотнее, чем тот же текст в PowerPoint. Это может произойти, потому что PowerPoint игнорирует данные кернинга для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы сделать вывод более похожим на PowerPoint, можно отключить кернинг для частей текста, использующих затронутый шрифт. Установите [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) в значение, превышающее фактический размер шрифта. Этот пример требует «presentation.pptx» с текстовым полем в первой фигуре первого слайда. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог в 100 пунктов для частей, использующих Roboto. Это отключает кернинг для соответствующих частей с размером шрифта менее 100 пунктов:

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
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Для текста, попадающего под порог, эта настройка отключает кернинг и может помочь согласовать рендеринг Aspose.Slides с визуальным выводом PowerPoint для шрифтов, на которые влияет данное специфическое поведение PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) или на отдельных частях через [PortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/).

Следующий пример задаёт для первого абзаца шрифт по умолчанию — Times New Roman 12 пунктов с жирным, курсивом и пунктирным подчёркиванием. Явное форматирование отдельных частей имеет приоритет над этими значениями по умолчанию:

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

    # Задать свойства шрифта для абзаца.
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

Следующий пример применяет к частям текста, у которых эффективное форматирование содержит жирный шрифт, Times New Roman 13 пунктов, курсив и пунктирное подчёркивание:

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

## **Установка поворота текста**

Используйте [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setTextVerticalType) для задания предопределённой ориентации текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре как [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

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

## **Установка пользовательского поворота для текстовых рамок**

Используйте [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setRotationAngle) для задания собственного угла поворота для [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/).

Ниже пример кода, вращающего текстовую рамку на 3 градуса по часовой стрелке внутри фигуры:

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

## **Установка межстрочного интервала абзацев**

Aspose.Slides предоставляет [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setSpaceBefore) и [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setSpaceWithin) для управления интервалами абзацев. Эти свойства применяются следующим образом:

* Положительное значение задаёт межстрочный интервал в процентах от высоты строки.
* Отрицательное значение задаёт межстрочный интервал в пунктах.

Следующий пример задаёт интервал внутри первого абзаца как 200 % от высоты строки (двойной интервал):

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

![Межстрочный интервал внутри абзаца](line_spacing.png)

## **Контроль разрыва строк**

Правила разрыва строк абзаца полезны в узких блоках текста и презентациях, где смешиваются латинский и восточноазиатский тексты. Следующие методы принадлежат [ParagraphFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/), поэтому они применяются к целому абзацу:

- [setLatinLineBreak](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) управляет правилами разрыва строк для латиницы. В смешанном тексте изменение этого параметра может также изменить место переноса соседнего восточноазиатского текста и пунктуации.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) управляет правилами разрыва строк для восточноазиатского текста, включая ограничения на символы в начале и в конце строки.

Эти правила не заменяют [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setWrapText), который включает автоматический перенос внутри текстовой рамки. Они влияют на компоновку, когда происходит перенос; они не вставляют символы разрыва строки. Явный разрыв строки принудительно создаёт новую строку внутри абзаца независимо от доступной ширины.

Следующий автономный пример создаёт узкий блок текста, содержащий китайский и латинский тексты. Он явно задаёт оба параметра разрыва строк и сохраняет файл «line_breaking.pptx». Чтобы протестировать каждое правило, измените соответствующее значение, оставив другое неизменным. Пример использует Arial 24 пт и SimSun с шириной рамки 160 пт и нулевыми горизонтальными отступами текстовой рамки. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setAutofitType) вызывается с [TextAutofitType.None_](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textautofittype/), чтобы размер текста и рамки оставались фиксированными.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Контроль висячей пунктуации**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) позволяет пунктуации, допускающей висячее отображение, простираться за правый край строки вместо переноса на следующую строку. Применяется к целому абзацу и отличается от висячего отступа.

Следующий автономный пример включает висячую пунктуацию в текстовой рамке шириной 100 пт и сохраняет файл «hanging_punctuation.pptx». При Arial 24 пт и нулевых горизонтальных отступах окончательная точка остаётся после слова «sentence» и выходит за правый край текста. Установите свойство в [NullableBool.False_](https://reference.aspose.com/slides/ru/python-java/aspose.slides/nullablebool/), чтобы увидеть противоположный результат: точка будет занимать отдельную строку. Перенос включён, а автоподгонка отключена, чтобы ширина оставалась фиксированной.

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Не все знаки пунктуации могут «висеть». Видимый результат зависит от доступных шрифтов и компоновки: изменение шрифта, доступной ширины, отступов или настроек автоподгонки может убрать визуальное различие.

## **Установка типа автоподгонки для текстовых рамок**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setAutofitType) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы управлять тем, будет ли текст сжиматься, выходить за пределы или автоматически изменять размер фигуры. Следующий пример настраивает фигуру на изменение размера под текст и сохраняет результат в файл «autofit_type.pptx».

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

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняются ширина текста или фигуры, см. [Count Rendered Lines](/slides/ru/python-java/manage-paragraph/). Само количество строк не указывает, выходит ли текст за пределы контейнера.

## **Установка привязки текстовых рамок**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setAnchoringType) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, по центру или внизу. Следующий пример привязывает текст к нижней части первой фигуры и сохраняет результат в файл «text_anchor.pptx».

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

## **Установка табуляции текста**

Используйте [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) и [ParagraphFormat.getTabs](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#getTabs) для настройки табуляций в абзаце. Следующий пример задаёт интервал табуляции по умолчанию 100 пт и добавляет левый табулятор на позиции 30 пт. Эти настройки влияют на текст, содержащий символы табуляции.

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

![Табуляция в абзаце](paragraph_tabs.png)

## **Установка языка проверки правописания**

Aspose.Slides предоставляет [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setLanguageId), позволяя задать язык проверки правописания для части текста. Язык проверки определяет, какой язык использовать для проверки орфографии и грамматики в PowerPoint.

Следующий пример требует «presentation.pptx» с текстовым полем в первой фигуре первого слайда и как минимум одним абзацем. Он заменяет содержимое первого абзаца на «1。», задаёт шрифт SimSun и устанавливает язык проверки упрощённого китайского (`zh-CN`). Результат сохраняется в файл «proofing_language.pptx»:

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

    # Установить идентификатор языка проверки правописания.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка языка по умолчанию**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации. В следующем примере создаётся презентация с американским английским в качестве языка текста по умолчанию, добавляется текстовое поле и выводится `en-US` для первой части текста.

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

## **Установка стиля текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Следующий пример задаёт для верхнего уровня абзацев новой презентации шрифт 14 пт с жирным начертанием и сохраняет её в файл «default_text_style.pptx». Текст может наследовать эти значения, если более специфическое форматирование их не переопределит.

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

## **Извлечение текста с эффектом «Все заглавные»**

В PowerPoint применение эффекта шрифта **All Caps** заставляет текст отображаться заглавными буквами на слайде, даже если он был введён строчными. При извлечении такой части текста с помощью Aspose.Slides библиотека возвращает исходный ввод. Чтобы получить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textcaptype/) и при значении `All` преобразуйте полученную строку в верхний регистр.

Этот пример требует «sample2.pptx» с текстовым полем в первой фигуре первого слайда. Первый абзац его первой части содержит «Hello, Aspose!» с применённым эффектом All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

Ниже пример кода, показывающий, как извлечь текст с применённым эффектом **All Caps**:

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

## **FAQ**

**Как изменить текст в таблице на слайде?**

Для изменения текста в таблице используйте [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/). Пройдитесь по ячейкам и обновите каждую через [Cell.getTextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cell/#getTextFrame) и форматирование абзацев через [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Для применения градиентного цвета к тексту используйте [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#getFillFormat). Установите [FillFormat.setFillType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/#setFillType) в [FillType.Gradient](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filltype/) и настройте градиентные стопы, направление и прозрачность.