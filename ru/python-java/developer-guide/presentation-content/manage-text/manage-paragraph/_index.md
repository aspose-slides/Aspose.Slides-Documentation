---
title: Управление текстовыми абзацами PowerPoint в Python через Java
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- добавить текст
- добавить абзац
- управлять текстом
- управлять абзацем
- управлять маркером
- отступ абзаца
- висячий отступ
- маркер абзаца
- нумерованный список
- маркированный список
- свойства абзаца
- импорт HTML
- текст в HTML
- абзац в HTML
- абзац в изображение
- текст в изображение
- экспортировать абзац
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как создавать и форматировать абзацы, фрагменты, маркеры, нумерованные списки, отступы, HTML‑контент и изображения абзацев с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Aspose.Slides for Python via Java представляет текст как иерархию текстовых рамок, абзацев и фрагментов:

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) представляет контейнер текста в фигуре и обеспечивает доступ к её коллекции абзацев.
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) представляет один абзац в текстовой рамке и предоставляет доступ к его фрагментам и форматированию уровня абзаца.
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) представляет фрагмент текста внутри абзаца. Каждый фрагмент может иметь собственный текст и форматирование символов.

Таким образом, абзац может содержать текст с разными шрифтами, цветами, размерами и другим форматированием, используя несколько фрагментов.

## **Создание и форматирование абзацев**

Создавайте абзацы в текстовой рамке фигуры и используйте фрагменты для форматирования отдельных запусков текста. В этом разделе показано, как комбинировать несколько фрагментов внутри каждого абзаца и применять разные цвета, размеры шрифта и стили.

### **Создание абзацев с несколькими фрагментами**

Следующий пример на Python создаёт три абзаца, каждый из которых содержит три текстовых запуска в коллекции, возвращаемой [Paragraph.getPortions](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getPortions). Он переиспользует абзац по умолчанию и его пустой фрагмент, затем добавляет остальные абзацы и фрагменты. Форматирование применяется через [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat): первый фрагмент в каждом абзаце красный, жирный и 15 пунктов; второй — синий, курсивный и 18 пунктов. Третий фрагмент сохраняет форматирование по умолчанию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()

    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())

    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)

    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")

            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Создание маркированных и нумерованных списков**

Организуйте текст абзаца в списки с символами, цифрами или пользовательскими изображениями. Примеры в этом разделе охватывают форматирование маркеров, многоуровневые списки и пользовательские начальные номера.

### **Создание маркированного или нумерованного списка**

Маркеры и нумерация упрощают восприятие связанных элементов. В Aspose.Slides настройки списка определяются через [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/).

Этот пример на Python добавляет символический маркер и нумерованный элемент в одну и ту же текстовую рамку. [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) выбирает тип маркера, а [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) задаёт символ, и [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) выбирает стиль нумерации. Оба элемента используют чёрные маркеры высотой 100 % и отступ абзаца 25 пунктов:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)

    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Использование графических маркеров**

Графические маркеры позволяют использовать пользовательское изображение вместо символа или цифры.

Этот пример на Python добавляет изображение в коллекцию изображений презентации как [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) и использует его в качестве маркера абзаца. Он вызывает [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType), чтобы использовать графический маркер, и задаёт изображение через [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture). [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) установлен в 100 % для масштабирования маркера относительно текста абзаца:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **Создание многоуровневого списка**

Установите [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth), чтобы разместить абзацы на разных уровнях списка. Верхний уровень имеет глубину `0`.

Этот пример на Python задаёт значения [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) от 0 до 3 четырём абзацам, создавая иерархию в одной текстовой рамке. Каждый абзац использует символический маркер, при этом [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar) чередуется между круглым маркером и дефисом для различения соседних уровней:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)

    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)

    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)

    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Начало нумерованных элементов списка с пользовательских значений**

Используйте [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith), чтобы задать начальное число, отображаемое для нумерованного абзаца.

Этот пример на Python устанавливает [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) для нумерации трёх абзацев и задаёт значения [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) 2, 3 и 7. Начальное значение задаётся отдельно для каждого абзаца, позволяя пропускать числа в отображаемой последовательности:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)

    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Управление макетом абзаца и свойствами завершения**

Регулируйте поля и отступы абзаца, чтобы управлять позицией первой строки и перенесённых строк. Вы также можете форматировать маркер окончания абзаца отдельно от видимых фрагментов текста.

### **Установка отступа первой строки**

Используйте метод [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) для контроля отступа первой строки абзаца. Эта настройка перемещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft), когда нужно переместить весь абзац. Используйте [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent), когда необходимо переместить только первую строку.

Следующий пример задаёт трём абзацам одинаковый [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) в 20 пунктов и значения [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) 0, 20 и 40 пунктов. Первые строки начинаются с постепенно увеличивающихся смещений, тогда как перенесённые строки сохраняют тот же левый отступ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)

    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)

    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Отступ первой строки абзацев](first_line_indent.png)

### **Установка висячего отступа**

Висячий отступ — это макет абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides этот эффект создаётся свойством [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent). Установите `Indent` в отрицательное значение, чтобы переместить первую строку влево относительно тела абзаца.

На практике [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) определяет левую позицию тела абзаца, а [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) задаёт позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение `MarginLeft` и отрицательное значение `Indent`.

Это форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где перенесённые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

Следующий пример на Python сочетает значения [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) 40 и 60 пунктов с значениями [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) — 20 и 30 пунктов соответственно. В каждом абзаце первая строка начинается левее перенесённых строк; во втором абзаце висячий отступ глубже:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)

    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Висячий отступ абзацев](hanging_indent.png)

### **Установка свойств завершающего фрагмента абзаца**

Метод [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) управляет форматированием маркера окончания абзаца. В следующем примере создаётся [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) с [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight), установленным в 48 пунктов, и [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont), установленным в Times New Roman. Этот формат применяется к маркеру окончания второго абзаца, не изменяя видимых фрагментов текста:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)

    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)

    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)

    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Подсчет отрисованных строк**

Для правил абзаца, влияющих на автоматический перенос и пунктуацию в конце строк, см. [Control Line Breaking](/slides/ru/python-java/text-formatting/#control-line-breaking) и [Control Hanging Punctuation](/slides/ru/python-java/text-formatting/#control-hanging-punctuation).

Используйте [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount), чтобы подсчитать строки, занятые абзацем после размещения текста, включая автоматический перенос. Это полезно при проверке длины текста и размещения в шаблонах презентаций.

Абзац — это один элемент в [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs) и может занимать несколько отрисованных строк. Явный разрыв строки внутри абзаца заставляет начать новую строку без создания нового абзаца. Автоматический перенос создаёт строки на основе доступной ширины, не вставляя явные разрывы в текст. Поэтому подсчёт абзацев или символов разрыва строк не даёт количество отрисованных строк.

Следующий пример создаёт текстовую фигуру, подсчитывает её строки, сужает фигуру, а затем заменяет текст более короткой строкой. Пример включает перенос с помощью [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) и отключает автоподгонку с помощью [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType), чтобы ширина фигуры контролировала перенос без автоматического уменьшения текста или изменения размеров фигуры. Каждое измерение использует [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount). Размеры фигуры указаны в пунктах. В конце пример добавляет ещё один абзац и суммирует количество строк по всей текстовой рамке.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

С этим текстом и этими размерами сужение фигуры увеличивает количество строк, а замена текста короткой строкой уменьшает его. Точные подсчёты могут различаться в зависимости от доступности шрифтов и их замены, размера шрифта, полей, отступов, переноса и настроек автоподгонки. Используйте шрифты и параметры размещения, предназначенные для целевой среды, при проверке шаблона.

Само количество строк не определяет, переполняет ли текст свой контейнер. Важны доступная высота, высота строк, межстрочный интервал и поведение автоподгонки; даже одна строка может превышать доступную ширину, если перенос отключён.

## **Импорт и экспорт содержимого абзаца**

Используйте HTML, чтобы импортировать текст в презентацию или экспортировать существующие абзацы для использования вне её. Этот раздел также показывает, как отрисовывать отдельные абзацы как изображения, включая абзацы в ячейках таблиц.

### **Импорт HTML-текста в абзацы**

Используйте [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) для преобразования разметки HTML в абзацы и фрагменты в текстовой рамке.

Этот пример на Python читает HTML из файла и передаёт разметку в [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml). Он очищает абзац по умолчанию в текстовой рамке, чтобы она содержала только импортированный контент. Прямоугольная фигура оставляет 10‑пунктовый отступ со всех сторон слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)

        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **Экспорт текста абзаца в HTML**

Используйте [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml), чтобы экспортировать выбранный диапазон абзацев в виде HTML. При повторном использовании текста презентации на веб‑сайте вы можете захотеть сохранить локальное выделение без переноса шрифта, размера или стилей текстового блока презентации. Установите [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit), чтобы контролировать, насколько глубоко экспортировщик следует наследованию форматирования.

Скачайте [sample presentation](text-inheritance.pptx) и разместите её в рабочем каталоге приложения. На первом слайде находится одна текстовая фигура с текстом «Inherited text; explicit red 18pt». Входные данные специально используют несколько уровней форматирования:

- Стиль текста по умолчанию презентации задаёт шрифт Calibri и размер 28 pt.
- Стиль текста первого уровня текстовой рамки задаёт синий цвет и курсив.
- Абзац явно задаёт жирный шрифт.
- Второй фрагмент «explicit red 18pt» явно задаёт красный цвет и размер 18 pt.

Следующий полный пример экспортирует те же абзацы трижды. Он передаёт [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-java/aspose.slides/texttohtmlconversionoptions/) в метод экспорта и записывает каждый результат в отдельный UTF‑8 HTML‑файл:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, TextInheritanceLimit, TextToHtmlConversionOptions

presentation = Presentation("text-inheritance.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(shape, AutoShape):
        text_frame = shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            
            modes = [TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly]
            file_names = ["All.html", "TextBox.html", "ParagraphOnly.html"]

            for mode, file_name in zip(modes, file_names):
                options = TextToHtmlConversionOptions()
                options.setTextInheritanceLimit(mode)

                html = paragraphs.exportToHtml(0, paragraphs.getCount(), options)
                try:
                    Path(file_name).write_text(str(html), encoding="utf-8")
                except OSError as exception:
                    print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

Сгенерированный HTML содержит следующий CSS для первого фрагмента, «Inherited text; ». В таблице перечислены соответствующие объявления; остальные сгенерированные свойства опущены для ясности.

| Вывод | Соответствующий CSS для первой части | Внешний вид |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Синий, жирный, курсивный текст размером 28 pt в шрифте Calibri, если этот шрифт доступен. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Синий, жирный, курсивный текст; шрифт и размер предоставляются страницей или браузером. |
| `ParagraphOnly.html` | `font-weight:bold` | Жирный текст; шрифт, размер, цвет и курсив предоставляются страницей или браузером. |

Второй фрагмент сохраняет `color:#ff0000`, `font-size:18pt` и `font-weight:bold` во всех трёх выводах. Он также сохраняет курсив в `All` и `TextBox`, но не в `ParagraphOnly`. Ограничение наследования поэтому не удаляет форматирование, явно заданное абзацу или фрагменту.

Откройте файлы в одном браузере для сравнения. В двух ограниченных режимах опущенные свойства CSS разрешаются стилями целевой страницы или настройками браузера, поэтому итоговый вид зависит от места использования HTML.

### **Отображение абзаца как изображения**

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) отрисовывает отдельный абзац напрямую и возвращает объект изображения. Сохраните результат в файл или поток с помощью метода `save`. Отрисовка содержащей фигуры или ручное обрезание битмапа не требуется.

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) может вернуть `None`, если абзац не найден в родительской коллекции, у него нет действительных границ отрисовки или он не может быть отрисован. Проверьте результат перед сохранением и освободите полученное изображение после использования.

#### **Отображение абзаца в масштабе по умолчанию**

Пример использует презентацию с одним слайдом, где первая фигура — текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

Следующий пример выбирает второй абзац с индексом 1 и вызывает [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) без параметров масштаба. Он проверяет, что фигура содержит требуемый абзац и что отрисовка возвращает изображение, прежде чем вызвать метод `save` для сохранения в формате PNG. Блок `finally` освобождает изображение после использования.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()

            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

Результат:

![Изображение абзаца](paragraph_to_image_output.png)

#### **Отображение абзаца в ячейке таблицы с масштабированием**

Используйте перегрузку [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/), принимающую параметры `scale_x` и `scale_y`, чтобы задать горизонтальные и вертикальные коэффициенты масштабирования. Следующий пример создаёт таблицу, отрисовывает абзац в её первой ячейке с двойной шириной и высотой по сравнению с размером по умолчанию и сохраняет результат в виде PNG‑изображения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])

    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")

    paragraph_image = paragraph.getImage(scale_x, scale_y)

    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

Коэффициент масштаба `1` оставляет ось с её стандартным размером в пикселях. Например, `2` для обеих осей создаёт изображение, ширина и высота которого примерно вдвое больше стандартных размеров, что даёт в четыре раза больше пикселей. Большие коэффициенты, как правило, дают более чёткий текст для увеличения или вывода в высоком разрешении, но также увеличивают потребление памяти и размер файла. Коэффициенты ниже `1` дают меньшие изображения с меньшей детализацией. Используйте одинаковые коэффициенты, чтобы сохранить соотношение сторон абзаца; разные горизонтальные и вертикальные коэффициенты растягивают вывод независимо.

Отрисовка всей фигуры с помощью [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) остаётся полезной, когда в выводе должны присутствовать заливка, граница или другой визуальный контекст фигуры. Для изображения только абзаца используйте [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/).

## **Часто задаваемые вопросы**

**Могу ли я полностью отключить перенос строк внутри текстовой рамки?**

Да. Установите [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), чтобы отключить перенос, так чтобы строки не разрывались у краёв текстовой рамки.

**Как получить точные границы конкретного абзаца на слайде?**

Используйте [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) для получения ограничивающего прямоугольника абзаца. [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) предоставляет границы отдельного фрагмента.

**Где управляется выравнивание абзаца (по левому, правому краю, по центру или по ширине)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) — это настройка уровня абзаца и применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

Чтобы вертикально выровнять фрагменты разного размера шрифта в каждой строке, см. [Align Fonts Within a Line](/slides/ru/python-java/text-formatting/#align-fonts-within-a-line).

**Могу ли я установить язык проверки части абзаца?**

Да. Установите [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) для отдельных фрагментов, чтобы один абзац мог содержать текст на нескольких языках.