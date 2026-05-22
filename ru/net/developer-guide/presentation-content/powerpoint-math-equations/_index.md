---
title: Добавление математических уравнений в презентации PowerPoint в .NET
linktitle: Математические уравнения PowerPoint
type: docs
weight: 80
url: /ru/net/powerpoint-math-equations/
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
- .NET
- C#
- Aspose.Slides
description: "Вставка и редактирование математических уравнений в PowerPoint PPT и PPTX с помощью Aspose.Slides для .NET, поддержка OMML, элементов управления форматированием и понятных примеров кода C#."
---
## **Обзор**

PowerPoint сохраняет уравнения в виде Office Math Markup Language (OMML). С помощью Aspose.Slides для .NET вы можете программно создавать такой же тип математического контента: дроби, радикалы, функции, пределы, N‑арные операторы, матрицы, массивы и отформатированные блоки формул.

В PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![Вкладка Insert в PowerPoint с выбранной командой Equation](powerpoint-math-equations_1.png)

Результатом является редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides строит этот математический текст с помощью трех основных объектов:

- Математическая фигура, создаваемая с помощью [AddMathShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addmathshape/), — это объект, содержащий уравнение.
- [MathPortion](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathportion/) хранит математическое содержание внутри текстового кадра фигуры.
- [MathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathematicaltext/) и «флюентные» методы из [IMathElement](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/) для краткости и читаемости кода.

Для сценариев экспорта в MathML см. [Export Math Equations from Presentations in .NET](/slides/ru/net/exporting-math-equations/).

## **Создать уравнение**

В этом примере создаётся математическая фигура и добавляется теорема Пифагора:

![Уравнение c² = a² + b²](powerpoint-math-equations_3.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equation = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(equation);

presentation.Save("pythagorean-theorem.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}}
`AddMathShape` создает фигуру, уже содержащую математический абзац. Получите первый `MathPortion`, его `MathParagraph` и добавьте в него математические блоки или элементы.
{{% /alert %}}

## **Добавить дроби**

Используйте `Divide` для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathfractiontypes/).

![Наклонённая математическая дробь, показывающая 1 ÷ x](powerpoint-math-equations_4.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Для «stacked» дроби используйте `MathFractionTypes.Bar`:

```csharp
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Добавить радикалы**

Используйте `Radical` для создания квадратного корня, кубического корня или другого корня. Текущий элемент становится основанием, а аргумент — степенью.

![Выражение n‑го корня с x под радикальной чертой](powerpoint-math-equations_5.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var radical = new MathematicalText("x")
    .Radical("n");

mathParagraph.Add(new MathBlock(radical));

presentation.Save("radical.pptx", SaveFormat.Pptx);
```

## **Добавить функции и пределы**

Для функций, таких как `sin(x)`, `log(x)` или пользовательских имен функций, используйте `AsArgumentOfFunction` или `Function`. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathlimit/) или используйте `SetLowerLimit`.

![Предел x при x → ∞](powerpoint-math-equations_8.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var limit = new MathematicalText("lim")
    .SetLowerLimit("x→∞")
    .Function("x");

mathParagraph.Add(new MathBlock(limit));

presentation.Save("functions-and-limits.pptx", SaveFormat.Pptx);
```

Для пользовательского имени функции сделайте имя функции текущим элементом:

```csharp
var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Добавить N‑арные операторы и интегралы**

Для сумм, объединений, пересечений и других больших операторов используйте `Nary`. Для интегралов — `Integral`. Оба метода позволяют задать нижний и верхний пределы.

![Сумма с нижним и верхним пределами](powerpoint-math-equations_7.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var summationBase = new MathematicalText("x")
    .SetSuperscript("k")
    .Join(new MathematicalText("a").SetSuperscript("n-k"));

var summation = summationBase.Nary(MathNaryOperatorTypes.Summation, "k=0", "n");

mathParagraph.Add(new MathBlock(summation));

presentation.Save("nary-operators.pptx", SaveFormat.Pptx);
```

N‑арные операторы предназначены для больших операторов с опциональными пределами. Простые операторы, такие как `+`, `-` и `=`, обычно добавляются как `MathematicalText` и объединяются в выражении.

Для интеграла используйте `Integral`:

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Добавить матрицы**

Для строк и столбцов используйте [MathMatrix](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathmatrix/). По умолчанию матрицы не включают скобки, поэтому заключайте их в круглые, квадратные или фигурные скобки при необходимости.

![Математическая матрица из двух строк с одной пустой ячейкой](powerpoint-math-equations_10.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var matrix = new MathMatrix(2, 3);
matrix[0, 0] = new MathematicalText("1");
matrix[0, 1] = new MathematicalText("x");
matrix[1, 0] = new MathematicalText("x");
matrix[1, 1] = new MathematicalText("2");
matrix[1, 2] = new MathematicalText("y");

mathParagraph.Add(new MathBlock(matrix));

presentation.Save("matrix.pptx", SaveFormat.Pptx);
```

## **Добавить массивы уравнений**

Когда нужны выровненные уравнения или вертикальная стопка выражений, используйте `ToMathArray`.

![Вертикальный математический массив с x над y](powerpoint-math-equations_11.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 140);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var equationArray = new MathematicalText("x")
    .Join("y")
    .ToMathArray();

mathParagraph.Add(new MathBlock(equationArray));

presentation.Save("equation-array.pptx", SaveFormat.Pptx);
```

## **Добавить тригонометрические функции**

Когда аргумент — текущий элемент, а имя функции известно, используйте `AsArgumentOfFunction`.

![Тригонометрическая функция cos, применённая к 2x](powerpoint-math-equations_6.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var cosine = new MathematicalText("2x")
    .AsArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

mathParagraph.Add(new MathBlock(cosine));

presentation.Save("trigonometric-function.pptx", SaveFormat.Pptx);
```

## **Добавить индексы и степени**

Для индексов и степеней используйте вспомогательные функции субскриптов и суперкриптов. Когда индексы должны располагаться слева от основания, используйте `SetSubSuperscriptOnTheLeft`.

![Большая Y с левым индексом 1 и степенью n](powerpoint-math-equations_9.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **Добавить разделители**

Для помещения выражения внутрь разделителей используйте `Enclose`. Можно также установить символ‑разделитель для выражений с несколькими элементами.

![Выражение‑разделитель, содержащий x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var delimiter = new MathematicalText("x")
    .Join("y")
    .Join("z")
    .Enclose('<', '>');
delimiter.SeparatorCharacter = '|';

mathParagraph.Add(new MathBlock(delimiter));

presentation.Save("delimiters.pptx", SaveFormat.Pptx);
```

## **Добавить рамку‑коробку**

Когда уравнение должно быть обрамлено, используйте `ToBorderBox`.

![Уравнение в рамке: a² = b² + c²](powerpoint-math-equations_12.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var boxedEquation = new MathematicalText("a")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("b").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("c").SetSuperscript("2"))
    .ToBorderBox();

mathParagraph.Add(new MathBlock(boxedEquation));

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

## **Группировать элементы**

Для размещения символа группировки над или под выражением используйте `Group`. Добавьте предел, чтобы пометить сгруппированные термы.

![Выражение x + y, сгруппированное с подписью любой текст под ним](powerpoint-math-equations_15.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 120);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var grouped = new MathematicalText("x + y")
    .Group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
    .SetLowerLimit("any text");

mathParagraph.Add(new MathBlock(grouped));

presentation.Save("grouped-terms.pptx", SaveFormat.Pptx);
```

## **Форматировать математические элементы**

Используйте функции форматирования только там, где они делают формулу понятнее. Например, `Overbar` ставит черту над элементом.

![Математическое выражение ABC с надчеркой](powerpoint-math-equations_14.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

## **Быстрая справка**

| Задача | Основной API |
| --- | --- |
| Создать математический текст | [MathematicalText](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathematicaltext/) |
| Объединить элементы | [IMathElement.Join](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/join/) |
| Создать дроби | [IMathElement.Divide](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/divide/) |
| Добавить надстрочный или подстрочный индекс | [SetSuperscript](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Добавить функции | [Function](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Добавить радикалы | [IMathElement.Radical](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/radical/) |
| Добавить пределы | [SetLowerLimit](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Добавить индексы слева | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Добавить суммы и интегралы | [Nary](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/integral/) |
| Добавить матрицы | [MathMatrix](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathmatrix/) |
| Добавить массивы уравнений | [ToMathArray](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Добавить разделители | [Enclose](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/enclose/) |
| Добавить черты и рамки | [Overbar](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Группировать термы | [Group](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Можно ли отредактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую `MathPortion`, получите её `MathParagraph` и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математика PowerPoint?**

Да. При сохранении в формате PPTX Aspose.Slides пишет уравнение как редактируемое содержимое Office Math.

**Можно ли экспортировать уравнения в LaTeX?**

Aspose.Slides экспортирует математические уравнения в MathML. Если нужен LaTeX, сначала экспортируйте в MathML, а затем преобразуйте MathML с помощью инструмента, поддерживающего ваш целевой диалект LaTeX.