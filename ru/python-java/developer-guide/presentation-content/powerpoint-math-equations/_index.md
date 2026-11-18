---
title: Добавить математические уравнения в презентации PowerPoint на Python
linktitle: Математические уравнения PowerPoint
type: docs
weight: 80
url: /ru/python-java/powerpoint-math-equations/
keywords:
- математическое уравнение
- математический символ
- математическая формула
- математический текст
- добавить математическое уравнение
- добавить математический символ
- добавить математическую формулу
- добавить математический текст
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Вставляйте и редактируйте математические уравнения в PowerPoint PPT и PPTX с помощью Aspose.Slides для Python через Java, поддерживая OMML, элементы управления форматированием и понятные примеры кода на Python."
---
## **Обзор**

PowerPoint сохраняет уравнения в формате Office Math Markup Language (OMML). С помощью Aspose.Slides для Python через Java вы можете программно создавать такой же тип математического содержимого: дроби, корни, функции, пределы, N‑арные операторы, матрицы, массивы и отформатированные блоки математики.

В PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![Вкладка Insert программы PowerPoint с выбранной командой Equation](powerpoint-math-equations_1.png)

Результатом является редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides создает этот математический текст с помощью трех основных объектов:

- Математической фигуры, создаваемой с помощью [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape), которая содержит уравнение.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) хранит математическое содержимое внутри текстового кадра фигуры.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) и методы из [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) для поддержания кода коротким и читаемым.

Для сценариев экспорта в MathML смотрите [Экспорт математических уравнений из презентаций на Python](/slides/ru/python-java/exporting-math-equations/).

## **Создание уравнения**

Этот пример использует [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) для создания математической фигуры и добавляет теорему Пифагора:

![Уравнение c^2 = a^2 + b^2](powerpoint-math-equations_3.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    equation = MathematicalText("c").setSuperscript("2").join("=").join(a_squared).join("+").join(b_squared)

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Примечание" %}}
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) создает фигуру, которая уже содержит математический абзац. Получите первый [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), вызовите [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) и добавьте в него математические блоки или элементы.
{{% /alert %}}

## **Добавление дробей**

Используйте [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/).

![Наклонная математическая дробь, показывающая один делить на x](powerpoint-math-equations_4.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFractionTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    fraction = MathematicalText("1").divide("x", MathFractionTypes.Skewed)

    math_block = MathBlock(fraction)
    math_paragraph.add(math_block)

    presentation.save("fraction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Для дроби с чертой используйте [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **Добавление радикалов**

Используйте [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) для создания квадратного корня, кубического корня или другого корня. Текущий элемент становится основанием, а аргумент — степенью.

![Выражение n‑го корня с x под радикальной чертой](powerpoint-math-equations_5.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    radical = MathematicalText("x").radical("n")

    math_block = MathBlock(radical)
    math_paragraph.add(math_block)

    presentation.save("radical.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Показ или скрытие степени квадратного корня**

Квадратный корень может отображать явную степень 2 или использовать традиционную запись √x. Метод [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) класса [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) управляет тем, какая форма отображается. Оба варианта сохраняют степень 2 и радиканд x в редактируемом уравнении.

![Тот же квадратный корень с видимой степенью слева и скрытой справа](square-root-degree.png)

Пример сохраняет один и тот же квадратный корень дважды. В файле `visible-degree.pptx` степень 2 видна. В файле `hidden-degree.pptx` она скрыта.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    radical = MathematicalText("x").radical("2")
    math_block = MathBlock(radical)

    math_shape = slide.getShapes().addMathShape(20, 20, 200, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()
    math_paragraph.add(math_block)

    radical.setHideDegree(False)
    presentation.save("visible-degree.pptx", SaveFormat.Pptx)

    radical.setHideDegree(True)
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Добавление функций и пределов**

Для функций, таких как `sin(x)`, `log(x)` или пользовательских имен функций, используйте [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) или [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function). Для пределов разместите `lim` в объекте [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) или используйте [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit).

![Предел x при x стремящемся к бесконечности](powerpoint-math-equations_8.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    limit = MathematicalText("lim").setLowerLimit("x\u2192\u221E").function("x")

    math_block = MathBlock(limit)
    math_paragraph.add(math_block)

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Для пользовательского имени функции сделайте имя функции текущим элементом и вызовите [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) с его аргументом:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **Добавление N‑арных операторов и интегралов**

Используйте [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) для сумм, объединений, пересечений и других больших операторов. Для интегралов используйте [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral). Оба метода позволяют задавать нижние и верхние пределы.

![Сумма с нижним и верхним пределами](powerpoint-math-equations_7.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathNaryOperatorTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_power = MathematicalText("a").setSuperscript("n-k")
    summation_base = MathematicalText("x").setSuperscript("k").join(a_power)

    summation = summation_base.nary(MathNaryOperatorTypes.Summation, "k=0", "n")

    math_block = MathBlock(summation)
    math_paragraph.add(math_block)

    presentation.save("nary-operators.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

N‑арные операторы предназначены для больших операторов с необязательными пределами. Простые операторы, такие как `+`, `-` и `=`, обычно добавляются как [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) и объединяются в выражение.

Для интеграла используйте [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathIntegralTypes, MathematicalText

differential = MathematicalText("dx").toBox()
integral_base = MathematicalText("x").join(differential)
integral = integral_base.integral(MathIntegralTypes.Simple, "0", "1")
```

## **Добавление матриц**

Для строк и столбцов используйте [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/). По умолчанию матрицы не включают скобки, поэтому при необходимости оборачивайте матрицу в круглые скобки, квадратные скобки или фигурные скобки.

![Матрица с двумя строками, одна ячейка пустая](powerpoint-math-equations_10.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathMatrix, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    matrix = MathMatrix(2, 3)
    cell_0_0 = MathematicalText("1")
    matrix.set_Item(0, 0, cell_0_0)
    cell_0_1 = MathematicalText("x")
    matrix.set_Item(0, 1, cell_0_1)
    cell_1_0 = MathematicalText("x")
    matrix.set_Item(1, 0, cell_1_0)
    cell_1_1 = MathematicalText("2")
    matrix.set_Item(1, 1, cell_1_1)
    cell_1_2 = MathematicalText("y")
    matrix.set_Item(1, 2, cell_1_2)

    math_block = MathBlock(matrix)
    math_paragraph.add(math_block)

    presentation.save("matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Редактирование существующей матрицы**

Предположим, урок линейной алгебры начинается с матрицы коэффициентов в файле `matrix.pptx`, сохранённом в предыдущем примере. Для следующего упражнения оставьте первое уравнение, замените второе двумя новыми уравнениями и измените набор переменных. Откройте существующую матрицу через [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/), чтобы сохранить коэффициенты, которые всё ещё применимы.

![Исходная матрица коэффициентов с двумя строками, содержащая 1, x и пустую ячейку в первой строке и x, 2 и y во второй](matrix-before-edit.png)

Индексы строк и столбцов начинаются с нуля и относятся к текущему состоянию матрицы на каждый вызов. Вставка строки перед индексом 1 перемещает исходную вторую строку на индекс 2. Вставка после индекса 2 добавляет строку. Удаление строки 2 удаляет исходное второе уравнение и перемещает добавленную строку вверх на одну позицию. Столбцы сдвигаются аналогичным образом.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathHorizontalAlignment, MathematicalText, Presentation, SaveFormat

presentation = Presentation("matrix.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    matrix = portion.getMathParagraph().get_Item(0).get_Item(0)

    matrix.insertRowBefore(1)
    matrix.insertRowAfter(2)
    matrix.deleteRow(2)

    matrix.insertColumnBefore(1)
    matrix.insertColumnAfter(3)
    matrix.deleteColumn(3)

    # Новые ячейки изначально пустые. Сначала установите ненулевые коэффициенты.
    matrix.set_Item(1, 0, MathematicalText("12"))
    matrix.set_Item(1, 1, MathematicalText("1"))
    matrix.set_Item(2, 2, MathematicalText("10"))
    matrix.set_Item(2, 3, MathematicalText("1"))
    for row in range(matrix.getRowCount()):
        for column in range(matrix.getColumnCount()):
            if matrix.get_Item(row, column) is None:
                matrix.set_Item(row, column, MathematicalText("0"))

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left)
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right)
    
    presentation.save("updated-matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) выравнивает первый столбец по левому краю. [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) выравнивает оставшиеся три столбца по правому краю, начиная с индекса 1. В файле `updated-matrix.pptx` матрица содержит три уравнения и четыре переменные. Коэффициенты первой строки `1` и `x` теперь находятся в первом и третьем столбцах.

![Обновлённая матрица из трёх строк, показывающая строки 1, 0, x, 0; 12, 1, 0, 0; и 0, 0, 10, 1](matrix-after-edit.png)

## **Добавление массивов уравнений**

Используйте [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray), когда нужны выровненные уравнения или вертикальный набор выражений.

![Вертикальный массив математики с x над y](powerpoint-math-equations_11.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 140)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    equation_array = MathematicalText("x").join("y").toMathArray()

    math_block = MathBlock(equation_array)
    math_paragraph.add(math_block)

    presentation.save("equation-array.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Выровнять массив с окружающими элементами**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) управляет вертикальным выравниванием массива относительно соседних математических элементов. Пример ниже сравнивает выравнивание по первой строке, по центру массива и по последней строке.

Следующий пример создаёт три одинаковых массива, каждый с тремя строками и соседними элементами `A=` и `=B`. Весь математический текст использует шрифт Cambria Math 24 pt. Изменяется только выравнивание массива.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathVerticalAlignment, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)
    
    alignments = (("Top", MathVerticalAlignment.Top), ("Center", MathVerticalAlignment.Center), ("Bottom", MathVerticalAlignment.Bottom))
    for index, (name, alignment) in enumerate(alignments):
        x = 20 + index * 260
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 10, 240, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(16)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        math_shape = slide.getShapes().addMathShape(x, 60, 240, 130)
        math_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(alignment)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Сравнение показывает сохранённую презентацию в PowerPoint. Обратите внимание на положение `A=` и `=B` рядом с каждым массивом.

![Массивы уравнений в PowerPoint с выравниванием Top, Center и Bottom и одинаковыми соседними элементами](equation-array-alignment.png)

### **Настройка расстояния между строками**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) выбирает правило расстояния между строками в массиве. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) задаёт числовое значение для явного правила и игнорируется предустановленными правилами.

Для точного расстояния значение измеряется в пунктах. Для пропорционального расстояния измеряется в полутчениях: значение `3` в примере означает 1,5 строки. Устанавливайте оба свойства, когда задаёте явное значение; изменение только числового значения не выбирает правило расстояния.

Пример ниже сохраняет пять презентаций с теми же уравнениями, выравниванием и настройками шрифта. Первые три используют предустановки; последние два показывают явные значения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathRowSpacingRule, MathVerticalAlignment, Presentation, SaveFormat

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


settings = (("SingleLineGap", MathRowSpacingRule.SingleLineGap, 0), ("OneAndAHalfLineGap", MathRowSpacingRule.OneAndAHalfLineGap, 0), ("TwoLineGap", MathRowSpacingRule.TwoLineGap, 0), ("Exactly", MathRowSpacingRule.Exactly, 20), ("Multiple", MathRowSpacingRule.Multiple, 3))
for name, rule, spacing in settings:
    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        math_shape = slide.getShapes().addMathShape(20, 20, 600, 300)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(MathVerticalAlignment.Center)
        equation_array.setRowSpacingRule(rule)
        equation_array.setRowSpacing(spacing)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

        presentation.save(f"equation-array-{name}.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Расстояние между строками массива отделено от расстояния между абзацами. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) и [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) добавляют отступы вокруг содержащего абзаца, а не между строками массива. Аналогично, [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) позиционирует весь математический абзац по горизонтали; он не заменяет вертикальное выравнивание массива.

## **Добавление тригонометрических функций**

Используйте [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction), когда аргумент является текущим элементом и имя функции известно.

![Тригонометрическая функция cos, применённая к 2x](powerpoint-math-equations_6.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFunctionsOfOneArgument, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    cosine = MathematicalText("2x").asArgumentOfFunction(MathFunctionsOfOneArgument.Cos)

    math_block = MathBlock(cosine)
    math_paragraph.add(math_block)

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Добавление индексов и степеней**

Используйте вспомогательные функции для индексов и степеней. Когда индексы должны находиться слева от основания, используйте [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Буква Y с левым индексом 1 и верхним индексом n](powerpoint-math-equations_9.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    scripts = MathematicalText("Y").setSubSuperscriptOnTheLeft("1", "n")

    math_block = MathBlock(scripts)
    math_paragraph.add(math_block)

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Добавление разделителей**

Используйте [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) для помещения выражения в разделители. Можно также задать символ‑разделитель для выражений, содержащих несколько элементов.

![Выражение с разделителями, содержащими x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    delimiter = MathematicalText("x").join("y").join("z").enclose('<', '>')
    delimiter.setSeparatorCharacter('|')

    math_block = MathBlock(delimiter)
    math_paragraph.add(math_block)

    presentation.save("delimiters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Размер и выравнивание разделителей**

Передайте `True` в [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight), чтобы скобки увеличивались вокруг высокого операнда, или `False`, чтобы оставить их обычного размера. Используйте [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) с одной из двух величин [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/). `Centered` центрирует скобки по оси математики, проходящей через середину знака равенства. `Match` выравнивает их по содержимому. Оба параметра влияют только на разделители. Выражение внутри остаётся прежним.

Пример помещает дробь в показатель степени `x`, поэтому выражение поднимается выше базовой линии, чем ниже. Все четыре уравнения используют одинаковые скобки и настройки шрифта.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathDelimiterShape, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    for row, grow in enumerate((True, False)):
        for column, shape in enumerate((MathDelimiterShape.Centered, MathDelimiterShape.Match)):
            fraction = MathematicalText("a + b").divide("c + d")
            power = MathematicalText("x").setSuperscript(fraction)
            delimiter = power.enclose("(", ")")
            delimiter.setGrowToMatchOperandHeight(grow)
            delimiter.setDelimiterShape(shape)

            math_shape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100)
            portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            portion.getPortionFormat().setFontHeight(32)
            equation = MathematicalText("y = ").join(delimiter)
            portion.getMathParagraph().add(equation)

    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

В PowerPoint сравните строки, чтобы увидеть эффект роста. В верхней строке скобки растут, охватывая показатель, и выглядят одинаково для обеих форм. В нижней строке рост отключён. Меньшие скобки слева (`Centered`) выравниваются по знаку равенства, а скобки справа (`Match`) находятся выше вокруг выражения.

![Четыре уравнения в PowerPoint с включённым ростом разделителей сверху и отключённым снизу, `Centered` слева и `Match` справа](delimiter-sizing.png)

## **Добавление рамки‑коробки**

Вызовите [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) у дроби, чтобы оформить всю выражение в рамку. Возвращённый объект [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) по умолчанию отображает все четыре стороны. Используйте [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) и [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight), чтобы скрыть отдельные стороны.

Пример размещает шесть копий одной и той же дроби на одном слайде. Чтобы показать зачёркивание, скройте все четыре стороны и передайте `True` в [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) для диагонали вверх (↗) или в [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) для диагонали вниз (↘). Можно также использовать [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) или [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) с любой комбинацией видимых сторон.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    def add_fraction(x, y, hide_border):
        fraction = MathematicalText("x+1").divide("y+2")
        box = fraction.toBorderBox()
        box.setHideTop(hide_border)
        box.setHideBottom(hide_border)
        box.setHideLeft(hide_border)
        box.setHideRight(hide_border)

        shape = slide.getShapes().addMathShape(x, y, 160, 90)
        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(28)
        math_block = MathBlock(box)
        portion.getMathParagraph().add(math_block)
        return box

    add_fraction(10, 10, False)

    partial = add_fraction(190, 10, False)
    partial.setHideTop(True)
    partial.setHideRight(True)

    add_fraction(370, 10, True).setStrikethroughBottomLeftToTopRight(True)
    add_fraction(10, 120, True).setStrikethroughTopLeftToBottomRight(True)
    add_fraction(190, 120, True).setStrikethroughHorizontal(True)
    add_fraction(370, 120, False).setStrikethroughVertical(True)

    presentation.save("border-box.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Шесть редактируемых дробей в PowerPoint. Верхняя строка: полная рамка, нижняя и левая стороны, диагональ вверх. Нижняя строка: диагональ вниз, горизонтальное зачёркивание, вертикальное зачёркивание с полной рамкой.](border-box-fractions.png)

На этой дроби горизонтальное зачёркивание перекрывает черту дроби. Вертикальное зачёркивание пересекает числитель и знаменатель, при этом окружающая рамка остаётся видимой. Эти линии украшают всё выражение. Обычное зачёркивание текста применяется к символам в текстовом фрагменте. После повторного открытия презентации в PowerPoint вы всё ещё можете независимо редактировать числитель и знаменатель.

## **Управление видимостью и компоновкой с помощью phantom‑элементов**

Обёрните выражение в [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/), чтобы контролировать его видимость и пространство, которое оно занимает в уравнении, независимо. Методы [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) управляют следующими параметрами:

| Метод | Эффект |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | Передайте `False`, чтобы скрыть выражение. Его размеры всё равно учитываются при компоновке, если ниже не задать `True`. |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | Рассматривать горизонтальную ширину выражения как нулевую, позволяя соседним элементам сблизиться. |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | Рассматривать его восхождение (высоту над базовой линией) как нулевое. Это может уменьшить пространство над соседними элементами. |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | Рассматривать его нисхождение (глубину ниже базовой линии) как нулевое. Это может приблизить черту дроби или другое содержимое ниже выражения к соседям. |

Базовая линия — это справочная линия, на которой размещаются обычные математические символы. Скрытие содержимого не удаляет его размеры, а установка нулевого значения не удаляет выражение. Исходное выражение остаётся доступным через [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase). Передайте `True` в [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow), чтобы отобразить его снова; настройки размеров сохраняются.

В примере ниже созданы пять вариантов рядом: видимая дробь, скрытая дробь, сохраняющая место, и три скрытых дроби, у которых одна из размерностей установлена в ноль. Каждый вариант использует то же окружающее выражение и шрифт Cambria Math 24 pt. Все фигуры уравнений имеют одинаковую верхнюю позицию, отмеченную серой направляющей. Размещение phantom‑элемента в числителе внешней дроби облегчает наблюдение за изменениями вертикального расположения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathBlock, MathFraction, MathematicalText, MathPhantom, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color


def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    labels = ("Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc")

    guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0)
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)

    for index, name in enumerate(labels):
        left = 10 + index * 200
        
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(14)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = MathFraction(fraction_numerator, fraction_denominator)
        phantom = MathPhantom(fraction)
        phantom.setShow(index == 0)
        phantom.setZeroWidth(index == 2)
        phantom.setZeroAsc(index == 3)
        phantom.setZeroDesc(index == 4)

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = MathFraction(numerator, denominator)

        shape = slide.getShapes().addMathShape(left, 60, 190, 100)
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        math_paragraph = math_portion.getMathParagraph()
        math_block = MathBlock(equation)
        math_paragraph.add(math_block)

    presentation.save("math-phantom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Пять уравнений в PowerPoint, сравнивающие видимую дробь, скрытую дробь, сохраняющую место, и скрытые дроби с включенными ZeroWidth, ZeroAsc или ZeroDesc](math-phantom.png)

## **Группировка терминов**

Используйте [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group), чтобы разместить символ группировки над или под выражением. Добавьте предел, чтобы подписать сгруппированные члены.

![Выражение x + y, сгруппированное с меткой любой текст снизу](powerpoint-math-equations_15.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathTopBotPositions, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    grouped = MathematicalText("x + y").group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top).setLowerLimit("any text")

    math_block = MathBlock(grouped)
    math_paragraph.add(math_block)

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Форматирование математических элементов**

Используйте вспомогательные функции форматирования только там, где они проясняют формулу. Например, [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) помещает черту над математическим элементом.

![Математическое выражение ABC с надчеркой](powerpoint-math-equations_14.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    overbar = MathematicalText("ABC").overbar()

    math_block = MathBlock(overbar)
    math_paragraph.add(math_block)

    presentation.save("overbar.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Форматирование текста в существующем уравнении**

Чтобы отформатировать текст во всём существующем уравнении, пройдитесь по дереву элементов каждого математического блока. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) возвращает только непосредственных детей, поэтому вызывайте его рекурсивно, чтобы добраться до текста внутри дробей, скриптов, радикалов и других вложенных структур. Проверяйте текущий элемент и его детей, чтобы включить начальный элемент, если он является [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/).

Этот пример предполагает, что `input.pptx` содержит уравнение вида `z = xᵢ / ∛y`, где в числителе дроби есть индекс, а в знаменателе — радикал. Обработка только верхних элементов блока пропустит текст внутри дроби. Пример находит математические части в текстовых кадрах слайдов, получает их блоки через [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) и использует [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight), чтобы установить размер шрифта 28 pt через каждый текстовый элемент с помощью метода [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathematicalText, MathPortion, Presentation, SaveFormat


def format_math_text(element):
    if isinstance(element, MathematicalText):
        element.getFormat().setFontHeight(28)

    for child in element.getChildren():
        format_math_text(child)


presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    if isinstance(portion, MathPortion):
                        for block in portion.getMathParagraph():
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Сохранённая презентация содержит обновлённое форматирование текста на каждом уровне каждого обработанного уравнения, сохраняя при этом его содержимое и математическую структуру.

## **Быстрая справка**

| Задача | Основной API |
| --- | --- |
| Создание математического текста | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| Объединение элементов | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| Создание дробей | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| Добавление надстрочного или нижстрочного индекса | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| Добавление функций | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| Добавление радикалов | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| Добавление пределов | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| Добавление левых скриптов | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| Добавление сумм и интегралов | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| Добавление матриц | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| Добавление массивов уравнений | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| Добавление разделителей | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| Добавление штрихов и рамок | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| Группировка терминов | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **Вопросы и ответы**

**Можно ли редактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), вызовите [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математика PowerPoint?**

Да. При сохранении в PPTX Aspose.Slides записывает уравнение как редактируемое содержимое Office Math.

**Можно ли экспортировать уравнения в LaTeX?**

Да. Получите [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) из его [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) и вызовите [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) для прямого экспорта. Для полного примера смотрите [Экспорт математических уравнений из презентаций на Python](/slides/ru/python-java/exporting-math-equations/#export-math-equations-to-latex).