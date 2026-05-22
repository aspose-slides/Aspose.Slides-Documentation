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
description: "Вставка и редактирование математических уравнений в PowerPoint PPT и PPTX с помощью Aspose.Slides for Python via .NET, поддержка OMML, элементов управления форматированием и понятных примеров кода Python."
---
## **Обзор**

PowerPoint хранит уравнения в виде Office Math Markup Language (OMML). С помощью Aspose.Slides for Python via .NET вы можете программно создавать такой же математический контент: дроби, радикалы, функции, пределы, N‑арные операторы, матрицы, массивы и отформатированные блоки формул.

В PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![Вкладка Insert в PowerPoint с выбранной командой Equation](powerpoint-math-equations_1.png)

Результат — редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides формирует этот математический текст с помощью трёх основных объектов:

- Math shape, создаваемый с помощью [add_math_shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_math_shape/), является фигурой, содержащей уравнение.
- [MathPortion](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathportion/) хранит математическое содержимое внутри текстового кадра фигуры.
- [MathParagraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathematicaltext/) и цепочечные методы из [IMathElement](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/) для краткости и читаемости кода.

Для сценариев экспорта в MathML см. [Экспорт уравнений из презентаций в Python через .NET](/slides/ru/python-net/exporting-math-equations/).

## **Создать уравнение**

Этот пример создаёт математическую фигуру и добавляет теорему Пифагора:

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

{{% alert color="primary" %}}
`add_math_shape` создает фигуру, которая уже содержит математический абзац. Доступ к первому `MathPortion`, получаем его `MathParagraph` и добавляем в него математические блоки или элементы.
{{% /alert %}}

## **Добавить дроби**

Используйте [`divide`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/divide/) для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Наклонённая математическая дробь, показывающая 1, разделённое на x](powerpoint-math-equations_4.png)

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

Для сложенной (stacked) дроби используйте `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Добавить радикалы**

Используйте [`radical`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/radical/) для создания квадратного корня, кубического корня или другого корня. Текущий элемент становится основанием, а аргумент — степенью.

![n‑й корень с x под радикалом](powerpoint-math-equations_5.png)

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

Используйте [`as_argument_of_function`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) или [`function`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/function/) для функций типа `sin(x)`, `log(x)` или пользовательских имён функций. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathlimit/) или используйте [`set_lower_limit`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![Предел x при x → ∞](powerpoint-math-equations_8.png)

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

Используйте [`nary`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/nary/) для сумм, объединений, пересечений и других больших операторов. Используйте [`integral`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/integral/) для интегралов. Оба метода позволяют задавать нижний и верхний пределы.

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

N‑арные операторы — это большие операторы с необязательными пределами. Простые операторы вроде `+`, `-` и `=` обычно добавляются как `MathematicalText` и соединяются в выражении.

Для интеграла используйте `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Добавить матрицы**

Используйте [MathMatrix](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathmatrix/) для задания строк и столбцов. По умолчанию в матрицы не включаются скобки, поэтому при необходимости заключайте матрицу в круглые скобки, квадратные скобки или фигурные скобки.

![Матрица с двумя строками и одной пустой ячейкой](powerpoint-math-equations_10.png)

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

Используйте [`to_math_array`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/to_math_array/) когда нужны выровненные уравнения или вертикальная стопка выражений.

![Вертикальный массив с x над y](powerpoint-math-equations_11.png)

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

Используйте [`as_argument_of_function`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) когда аргумент — текущий элемент, а имя функции известно.

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

## **Добавить нижние и верхние индексы**

Используйте вспомогательные функции для нижних и верхних индексов. Когда индексы должны располагаться слева от основания, используйте [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Заглавная Y с левым нижним индексом 1 и верхним индексом n](powerpoint-math-equations_9.png)

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

Используйте [`enclose`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/enclose/) для помещения выражения в разделители. Можно также задать символ‑разделитель для выражений, содержащих несколько элементов.

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

## **Добавить ограничивающий блок**

Используйте [`to_border_box`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/to_border_box/) когда уравнение должно быть обрамлено.

![Уравнение в рамке: a² = b² + c²](powerpoint-math-equations_12.png)

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

## **Группировать термы**

Используйте [`group`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/group/) для размещения символа группировки над или под выражением. Добавьте предел, чтобы подписать сгруппированные термы.

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

## **Форматировать элементы формул**

Используйте функции форматирования только там, где они делают формулу более понятной. Например, [`overbar`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/overbar/) помещает черту над математическим элементом.

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
| Объединять элементы | [IMathElement.join](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/join/) |
| Создавать дроби | [IMathElement.divide](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Добавлять верхний или нижний индекс | [set_superscript](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Добавлять функции | [function](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Добавлять радикалы | [radical](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Добавлять пределы | [set_lower_limit](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Добавлять индексы слева | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Добавлять суммы и интегралы | [nary](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Добавлять матрицы | [MathMatrix](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/mathmatrix/) |
| Добавлять массивы уравнений | [to_math_array](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Добавлять разделители | [enclose](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Добавлять черты и рамки | [overbar](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Группировать термы | [group](https://reference.aspose.com/slides/ru/python-net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Могу ли я отредактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую `MathPortion`, получите её `MathParagraph` и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математика PowerPoint?**

Да. При сохранении в PPTX Aspose.Slides записывает уравнение как редактируемое содержимое Office Math.

**Могу ли я экспортировать уравнения в LaTeX?**

Aspose.Slides экспортирует математические уравнения в MathML. Если нужен LaTeX, сначала экспортируйте в MathML, а затем преобразуйте MathML с помощью инструмента, поддерживающего нужный диалект LaTeX.