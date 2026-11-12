---
title: Добавление математических уравнений в презентации PowerPoint на Python
linktitle: Математические уравнения PowerPoint
type: docs
weight: 80
url: /ru/python-net/powerpoint-math-equations/
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
- Aspose.Slides
description: "Вставка и редактирование математических уравнений в PowerPoint PPT и PPTX с помощью Aspose.Slides for Python via .NET, поддержка OMML, элементов форматирования и понятных примеров кода на Python."
---
## **Обзор**

PowerPoint хранит уравнения в виде Office Math Markup Language (OMML). С помощью Aspose.Slides for Python via .NET вы можете программно создавать такой же тип математического контента: дроби, радикалы, функции, пределы, N‑арные операторы, матрицы, массивы и отформатированные математические блоки.

В PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![Вкладка Insert PowerPoint с выбранной командой Equation](powerpoint-math-equations_1.png)

Результатом является редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides создает этот математический текст с помощью трех основных объектов:

- Математическая фигура, созданная с помощью [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/), — это фигура, содержащая уравнение.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) хранит математическое содержание внутри текстового кадра фигуры.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) и методы цепочки из [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) , чтобы код был коротким и читаемым.

Для сценариев экспорта MathML см. [Экспорт математических уравнений из презентаций в Python через .NET](/slides/ru/python-net/exporting-math-equations/).

## **Создание уравнения**

В этом примере используется [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) , чтобы создать математическую фигуру и добавить теорему Пифагора:

![Уравнение c² = a² + b²](powerpoint-math-equations_3.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation = (
        math.MathematicalText("c")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("a").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("b").set_superscript("2"))
    )

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) создает фигуру, которая уже содержит математический абзац. Получите первый [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), возьмите его [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), и добавьте в него математические блоки или элементы.
{{% /alert %}}

## **Добавление дробей**

Используйте [divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) , чтобы создать дробь. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Наклонённая математическая дробь, показывающая 1, делённое на x](powerpoint-math-equations_4.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("1").divide("x", math.MathFractionTypes.SKEWED)

    math_paragraph.add(math.MathBlock(fraction))

    presentation.save("fraction.pptx", slides.export.SaveFormat.PPTX)
```

Для сложенной дроби используйте [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/):

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Добавление радикалов**

Используйте [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) , чтобы создать квадратный корень, кубический корень или другой корень. Текущий элемент становится основанием, а аргумент — показателем.

![Выражение n‑го корня с x под радиальной чертой](powerpoint-math-equations_5.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    radical = math.MathematicalText("x").radical("n")

    math_paragraph.add(math.MathBlock(radical))

    presentation.save("radical.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление функций и пределов**

Используйте [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) или [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) для функций, таких как `sin(x)`, `log(x)` или пользовательских имён функций. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) или используйте [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![Предел x при x стремящемся к бесконечности](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x\u2192\u221E")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

Для пользовательского имени функции сделайте имя функции текущим элементом и вызовите [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/) с её аргументом:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **Добавление N‑арных операторов и интегралов**

Используйте [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/) для сумм, объединений, пересечений и других больших операторов. Используйте [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) для интегралов. Оба метода позволяют задать нижний и верхний пределы.

![Суммирование с нижним и верхним пределами](powerpoint-math-equations_7.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    summation_base = (
        math.MathematicalText("x")
        .set_superscript("k")
        .join(math.MathematicalText("a").set_superscript("n-k"))
    )

    summation = summation_base.nary(math.MathNaryOperatorTypes.SUMMATION, "k=0", "n")

    math_paragraph.add(math.MathBlock(summation))

    presentation.save("nary-operators.pptx", slides.export.SaveFormat.PPTX)
```

N‑арные операторы предназначены для больших операторов с необязательными пределами. Простые операторы, такие как `+`, `-` и `=`, обычно добавляются как [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) и объединяются в выражение.

Для интеграла используйте [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/):

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Добавление матриц**

Используйте [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) для строк и столбцов. По умолчанию матрицы не включают скобки, поэтому обрамляйте матрицу, когда нужны круглые, квадратные скобки или фигурные скобки.

![Математическая матрица из двух строк с одной пустой ячейкой](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)

    # У матрицы нет собственных скобок, поэтому обрамите её в круглые скобки.
    math_paragraph.add(math.MathBlock(matrix.enclose("(", ")")))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`MathMatrix` создает сетку строк и столбцов, задает промежутки между ними и выравнивает столбцы, но Aspose.Slides for Python via .NET не предоставляет доступ к отдельным ячейкам матрицы. Матрица, созданная в коде, поэтому сохраняет пустые ячейки; ячейки матрицы, полученной из существующей презентации, можно прочитать с помощью `get_children`. Используйте массив уравнений, когда необходимо заполнять строки из кода.
{{% /alert %}}

## **Добавление массивов уравнений**

Используйте [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) , когда нужны выровненные уравнения или вертикальная стопка выражений.

![Вертикальный массив математических выражений с x над y](powerpoint-math-equations_11.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 140)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation_array = (
        math.MathematicalText("x")
        .join("y")
        .to_math_array()
    )

    math_paragraph.add(math.MathBlock(equation_array))

    presentation.save("equation-array.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление тригонометрических функций**

Используйте [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) , когда аргумент является текущим элементом и имя функции известно.

![Тригонометрическая функция cos, применённая к 2x](powerpoint-math-equations_6.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    cosine = math.MathematicalText("2x").as_argument_of_function(
        math.MathFunctionsOfOneArgument.COS
    )

    math_paragraph.add(math.MathBlock(cosine))

    presentation.save("trigonometric-function.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление подстрочных и надстрочных индексов**

Используйте вспомогательные функции подстрочного и надстрочного индекса для индексов и степеней. Когда индексы должны располагаться слева от основания, используйте [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Буква Y с левым подстрочным индексом 1 и надстрочным индексом n](powerpoint-math-equations_9.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    scripts = math.MathematicalText("Y").set_sub_superscript_on_the_left("1", "n")

    math_paragraph.add(math.MathBlock(scripts))

    presentation.save("subscript-superscript.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление разделителей**

Используйте [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) , чтобы поместить выражение внутрь разделителей. Вы также можете задать символ‑разделитель для выражений с несколькими элементами.

![Выражение с разделителями, содержащее x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    delimiter = (
        math.MathematicalText("x")
        .join("y")
        .join("z")
        .enclose("<", ">")
    )
    delimiter.separator_character = "|"

    math_paragraph.add(math.MathBlock(delimiter))

    presentation.save("delimiters.pptx", slides.export.SaveFormat.PPTX)
```

### **Размер и выравнивание разделителей**

Установите [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/grow_to_match_operand_height/) в `True`, чтобы круглые скобки увеличивались вокруг высокого операнда, или в `False`, чтобы оставить их обычного размера. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/delimiter_shape/) принимает одно из двух значений [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) . `CENTERED` центрирует скобки по математической оси, проходящей через середину знака «=». `MATCH` выравнивает их по содержимому внутри. Оба параметра влияют только на разделители. Выражение внутри остаётся без изменений.

Пример помещает дробь в показатель `x`, поэтому выражение вытягивается выше базовой линии, чем ниже её. Все четыре уравнения используют одинаковые скобки и параметры шрифта.

```python
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_expression(slide, left, top, grow, shape):
    fraction = math.MathematicalText("a + b").divide("c + d")
    power = math.MathematicalText("x").set_superscript(fraction)
    delimiter = power.enclose("(", ")")
    delimiter.grow_to_match_operand_height = grow
    delimiter.delimiter_shape = shape

    math_shape = slide.shapes.add_math_shape(left, top, 300, 100)
    portion = math_shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 32
    equation = math.MathematicalText("y = ").join(delimiter)
    portion.math_paragraph.add(equation)


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    add_expression(slide, 20, 20, True, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 20, True, math.MathDelimiterShape.MATCH)
    add_expression(slide, 20, 140, False, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 140, False, math.MathDelimiterShape.MATCH)

    presentation.save("delimiter-sizing.pptx", slides.export.SaveFormat.PPTX)
```

В PowerPoint сравните строки, чтобы увидеть эффект роста. В верхней строке скобки увеличиваются, охватывая показатель, и выглядят одинаково для обеих фигур. В нижней строке рост отключён. Более маленькие скобки слева (`CENTERED`) выравниваются с знаком «=», тогда как справа (`MATCH`) находятся выше вокруг выражения.

![Четыре уравнения в PowerPoint с включенным ростом разделителей сверху и отключённым снизу, с `CENTERED` слева и `MATCH` справа](delimiter-sizing.png)

## **Добавление рамки**

Вызовите [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) на дроби, чтобы обрамить всё выражение. Возвращаемый [IMathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/) по умолчанию показывает все четыре стороны. Используйте [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_left/), и [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/hide_right/) , чтобы убрать отдельные стороны.

Пример размещает шесть копий одной и той же дроби на одном слайде. Чтобы показать отмену, скройте все четыре стороны и задайте [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_bottom_left_to_top_right/) для восходящей диагонали (↗) или [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_top_left_to_bottom_right/) для нисходящей (↘). Можно также использовать [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_horizontal/) или [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathborderbox/strikethrough_vertical/) в любой комбинации видимых сторон.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_fraction(slide, x, y, hide_border=False):
    fraction = math.MathematicalText("x+1").divide("y+2")
    box = fraction.to_border_box()
    box.hide_top = box.hide_bottom = box.hide_left = box.hide_right = hide_border

    shape = slide.shapes.add_math_shape(x, y, 160, 90)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 28
    portion.math_paragraph.add(math.MathBlock(box))
    return box


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(540, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    add_fraction(slide, 10, 10)

    partial = add_fraction(slide, 190, 10)
    partial.hide_top = True
    partial.hide_right = True

    add_fraction(slide, 370, 10, hide_border=True).strikethrough_bottom_left_to_top_right = True
    add_fraction(slide, 10, 120, hide_border=True).strikethrough_top_left_to_bottom_right = True
    add_fraction(slide, 190, 120, hide_border=True).strikethrough_horizontal = True
    add_fraction(slide, 370, 120).strikethrough_vertical = True

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

![Шесть редактируемых дробей в PowerPoint. Верхняя строка: полная рамка, нижняя и левая стороны, восходящая диагональ. Нижняя строка: нисходящая диагональ, горизонтальная черта, вертикальная черта с полной рамкой](border-box-fractions.png)

На этой дроби горизонтальная черта пересекает линию дроби. Вертикальная черта пересекает числитель и знаменатель, при этом окружающая рамка остаётся видимой. Эти линии украшают всё выражение. Обычное зачеркивание текста применяется к символам в текстовом фрагменте. После повторного открытия презентации в PowerPoint вы всё равно сможете редактировать числитель и знаменатель независимо.

## **Группировка терминов**

Используйте [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) , чтобы разместить группирующий символ над или под выражением. Добавьте предел, чтобы подпись к сгруппированным термам.

![Выражение x + y, сгруппированное с подписью любой текст снизу](powerpoint-math-equations_15.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    grouped = (
        math.MathematicalText("x + y")
        .group(chr(0x23DF), math.MathTopBotPositions.BOTTOM, math.MathTopBotPositions.TOP)
        .set_lower_limit("any text")
    )

    math_paragraph.add(math.MathBlock(grouped))

    presentation.save("grouped-terms.pptx", slides.export.SaveFormat.PPTX)
```

## **Форматирование математических элементов**

Используйте вспомогательные функции форматирования только там, где они проясняют формулу. Например, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) помещает надчерку над математическим элементом.

![Математическое выражение ABC с надчеркой](powerpoint-math-equations_14.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    overbar = math.MathematicalText("ABC").overbar()

    math_paragraph.add(math.MathBlock(overbar))

    presentation.save("overbar.pptx", slides.export.SaveFormat.PPTX)
```

### **Форматирование текста в существующем уравнении**

Чтобы отформатировать текст во всём существующем уравнении, пройдите по дереву элементов каждого математического блока. [IMathElement.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/get_children/) возвращает только непосредственных потомков, поэтому вызывайте его рекурсивно, чтобы попасть в текст внутри дробей, скриптов, радикалов и других вложенных структур. Проверяйте текущий элемент и его дочерние, чтобы включить начальный элемент, когда он является [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Этот пример предполагает, что `input.pptx` содержит уравнение, например `z = xᵢ / ∛y`, где в числителе дроби есть подстрочный индекс, а в знаменателе – радикал. Обработка только элементов верхнего уровня блока пропустит текст внутри дроби. Пример ищет математические части в текстовых кадрах слайдов, получает их блоки через [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), и задаёт [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) 28 пунктов каждому текстовому элементу через его свойство [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/).

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def format_math_text(element):
    if isinstance(element, math.MathematicalText):
        element.format.font_height = 28

    for child in element.get_children():
        format_math_text(child)


with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if isinstance(portion, math.MathPortion):
                        for block in portion.math_paragraph:
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", slides.export.SaveFormat.PPTX)
```

Сохранённая презентация содержит обновлённое форматирование текста на каждом уровне каждого обработанного уравнения, при этом сохраняет его текстовое содержание и математическую структуру.

## **Быстрая справка**

| Задача | Основной API |
| --- | --- |
| Создание математического текста | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Объединение элементов | [IMathElement.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/) |
| Создание дробей | [IMathElement.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Добавление надстрочного или подстрочного индекса | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Добавление функций | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Добавление радикалов | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Добавление пределов | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Добавление скриптов слева | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Добавление сумм и интегралов | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Добавление матриц | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Добавление массивов уравнений | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Добавление разделителей | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Добавление надчерки и рамок | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Группировка терминов | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Можно ли редактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, которая содержит [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), получите её [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/), и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математика PowerPoint?**

Да. При сохранении в PPTX Aspose.Slides записывает уравнение как редактируемый Office‑math контент.

**Можно ли экспортировать уравнения в LaTeX?**

Да. Получите [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) из его [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), и вызовите [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) для прямого экспорта. Полный пример см. в [Экспорт математических уравнений из презентаций в Python через .NET](/slides/ru/python-net/exporting-math-equations/#export-math-equations-to-latex).