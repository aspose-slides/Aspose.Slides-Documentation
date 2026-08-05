---
title: Добавить математические уравнения в презентации PowerPoint на Python
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
description: "Вставка и редактирование математических уравнений в PowerPoint PPT и PPTX с помощью Aspose.Slides for Python via .NET, поддержка OMML, средств форматирования и понятных примеров кода на Python."
---
## **Обзор**

PowerPoint хранит уравнения в формате Office Math Markup Language (OMML). С помощью Aspose.Slides for Python via .NET вы можете программно создавать такие же математические элементы: дроби, радикалы, функции, пределы, N‑арные операторы, матрицы, массивы и отформатированные блоки математики.

В PowerPoint пользователи обычно добавляют уравнения через **Вставка > Уравнение**:

![Вкладка Вставка PowerPoint с выбранной командой Уравнение](powerpoint-math-equations_1.png)

Результатом является редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides строит этот математический текст с помощью трёх основных объектов:

- Математическая фигура, создаваемая с помощью [add_math_shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_math_shape/), является фигурой, содержащей уравнение.
- [MathPortion](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathportion/) хранит математическое содержимое внутри текстового фрейма фигуры.
- [MathParagraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathematicaltext/) и плавные методы из [IMathElement](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/) для короткого и читабельного кода.

Для сценариев экспорта MathML см. [Export Math Equations from Presentations in Python via .NET](/slides/ru/python-net/exporting-math-equations/).

## **Создать уравнение**

Этот пример создаёт математическую фигуру и добавляет теорему Пифагора:

![Уравнение c в квадрате равно a в квадрате плюс b в квадрате](powerpoint-math-equations_3.png)

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

{{% alert color="primary" %}}
`add_math_shape` создает фигуру, которая уже содержит математический абзац. Получите первый `MathPortion`, возьмите его `MathParagraph` и добавьте в него математические блоки или элементы.
{{% /alert %}}

## **Добавить дроби**

Используйте [`divide`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/divide/) для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Скосная математическая дробь, показывающая один, делённый на x](powerpoint-math-equations_4.png)

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

Для обычной дроби используйте `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Добавить радикалы**

Используйте [`radical`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/radical/) для создания квадратного, кубического или другого корня. Текущий элемент становится основанием, а аргумент — степенью.

![Выражение радикала n‑й степени с x под радикалом](powerpoint-math-equations_5.png)

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

## **Добавить функции и пределы**

Используйте [`as_argument_of_function`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) или [`function`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/function/) для функций, таких как `sin(x)`, `log(x)` или пользовательских названий функций. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathlimit/) или используйте [`set_lower_limit`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

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

Для пользовательского имени функции сделайте имя функции текущим элементом:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **Добавить N‑арные операторы и интегралы**

Используйте [`nary`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/nary/) для суммирования, объединений, пересечений и других крупных операторов. Используйте [`integral`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/integral/) для интегралов. Оба метода позволяют задавать нижний и верхний пределы.

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

N‑арные операторы предназначены для крупных операторов с необязательными пределами. Простые операторы, такие как `+`, `-` и `=`, обычно добавляются как `MathematicalText` и объединяются в выражение.

Для интеграла используйте `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Добавить матрицы**

Используйте [MathMatrix](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathmatrix/) для строк и столбцов. По умолчанию матрицы не включают скобки, поэтому оборачивайте их, когда нужны круглые, квадратные или фигурные скобки.

![Математическая матрица из двух строк с одной пустой ячейкой](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)
    matrix[0, 0] = math.MathematicalText("1")
    matrix[0, 1] = math.MathematicalText("x")
    matrix[1, 0] = math.MathematicalText("x")
    matrix[1, 1] = math.MathematicalText("2")
    matrix[1, 2] = math.MathematicalText("y")

    math_paragraph.add(math.MathBlock(matrix))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавить массивы уравнений**

Используйте [`to_math_array`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/to_math_array/) когда нужны выровненные уравнения или вертикальная стековая последовательность выражений.

![Вертикальный мат. массив с x над y](powerpoint-math-equations_11.png)

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

## **Добавить тригонометрические функции**

Используйте [`as_argument_of_function`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) когда аргумент является текущим элементом, а имя функции известно.

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

## **Добавить индексы и степени**

Используйте вспомогательные функции для индексов и степеней. Когда индексы должны располагаться слева от основания, используйте [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Буква Y с левым индексом 1 и степенью n](powerpoint-math-equations_9.png)

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

## **Добавить разделители**

Используйте [`enclose`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/enclose/) чтобы поместить выражение в разделители. Вы также можете задать символ‑разделитель для выражений с несколькими элементами.

![Выражение с разделителями, содержащие x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

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

## **Добавить рамку**

Используйте [`to_border_box`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/to_border_box/) когда уравнение должно быть обрамлено.

![Уравнение в рамке, показывающее a² = b² + c²](powerpoint-math-equations_12.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    boxed_equation = (
        math.MathematicalText("a")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("b").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("c").set_superscript("2"))
        .to_border_box()
    )

    math_paragraph.add(math.MathBlock(boxed_equation))

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

## **Группировать члены**

Используйте [`group`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/group/) чтобы разместить символ группировки над или под выражением. Добавьте предел, чтобы отметить сгруппированные члены.

![Выражение x + y, сгруппированное с меткой любой текст под ним](powerpoint-math-equations_15.png)

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

## **Форматировать математические элементы**

Используйте вспомогательные функции форматирования только там, где они проясняют формулу. Например, [`overbar`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/overbar/) помещает линию над элементом.

![Математическое выражение ABC с надстрочной чертой](powerpoint-math-equations_14.png)

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

## **Быстрая справка**

| Задача | Основной API |
| --- | --- |
| Создать математический текст | [MathematicalText](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Объединить элементы | [IMathElement.join](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/join/) |
| Создать дроби | [IMathElement.divide](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Добавить надстрочный или подстрочный индекс | [set_superscript](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Добавить функции | [function](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Добавить радикалы | [radical](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Добавить пределы | [set_lower_limit](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Добавить индексы слева | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Добавить суммирование и интегралы | [nary](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Добавить матрицы | [MathMatrix](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathmatrix/) |
| Добавить массивы уравнений | [to_math_array](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Добавить разделители | [enclose](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Добавить линии и рамки | [overbar](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Группировать члены | [group](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Можно ли отредактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую `MathPortion`, получите её `MathParagraph` и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математическая часть PowerPoint?**

Да. При сохранении в PPTX Aspose.Slides записывает уравнение как редактируемое содержимое Office Math.

**Можно ли экспортировать уравнения в LaTeX?**

Да. Получите [MathParagraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathparagraph/) уравнения из его [MathPortion](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathportion/) и вызовите [MathParagraph.to_latex](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) для прямого экспорта. Полный пример см. в [Export Math Equations from Presentations in Python via .NET](/slides/ru/python-net/exporting-math-equations/#export-math-equations-to-latex).