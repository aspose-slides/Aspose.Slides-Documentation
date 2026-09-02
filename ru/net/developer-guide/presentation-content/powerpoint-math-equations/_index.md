---
title: Добавление математических уравнений в презентации PowerPoint на .NET
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
description: "Вставка и редактирование математических уравнений в PowerPoint PPT и PPTX с помощью Aspose.Slides для .NET, поддержка OMML, элементов управления форматированием и понятных примеров кода на C#."
---
## **Обзор**

PowerPoint хранит уравнения в виде Office Math Markup Language (OMML). С помощью Aspose.Slides для .NET вы можете программно создавать такой же математический контент: дроби, радикалы, функции, пределы, N‑арные операторы, матрицы, массивы и отформатированные блоки математических выражений.

В PowerPoint пользователи обычно добавляют уравнения через **Вставка > Уравнение**:

![Вкладка Insert в PowerPoint с выбранной командой Уравнение](powerpoint-math-equations_1.png)

В результате получаем редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides создает этот математический текст с помощью трех основных объектов:

- Математическая фигура, создаваемая с помощью [AddMathShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addmathshape/), является фигурой, содержащей уравнение.
- [MathPortion](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathportion/) сохраняет математическое содержимое внутри текстового фрейма фигуры.
- [MathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathematicaltext/) и методы из [IMathElement](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/) для краткого и читаемого кода.

Для сценариев экспорта MathML см. [Export Math Equations from Presentations in .NET](/slides/ru/net/exporting-math-equations/).

## **Создание уравнения**

В этом примере создается математическая фигура и добавляется теорема Пифагора:

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

`AddMathShape` создает фигуру, в которой уже содержится математический абзац. Получите первый `MathPortion`, затем его `MathParagraph` и добавьте в него математические блоки или элементы.

{{% /alert %}}

## **Добавление дробей**

Используйте `Divide` для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathfractiontypes/).

![Наклонная математическая дробь, показывающая 1 делённое на x](powerpoint-math-equations_4.png)

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

Для дроби с чертой используйте `MathFractionTypes.Bar`:

```csharp
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Добавление радикалов**

Используйте `Radical` для создания квадратного корня, кубического корня или другого корня. Текущий элемент становится основанием, а аргумент — показателем.

![n‑й корень с x под радикальной чертой](powerpoint-math-equations_5.png)

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

## **Добавление функций и пределов**

Используйте `AsArgumentOfFunction` или `Function` для функций, таких как `sin(x)`, `log(x)`, или пользовательских имён функций. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathlimit/) или используйте `SetLowerLimit`.

![Предел x при x, стремящемся к бесконечности](powerpoint-math-equations_8.png)

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

## **Добавление N‑арных операторов и интегралов**

Используйте `Nary` для сумм, объединений, пересечений и других больших операторов. Используйте `Integral` для интегралов. Оба метода позволяют задавать нижний и верхний пределы.

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

N‑арные операторы предназначены для больших операторов с необязательными пределами. Простые операторы, такие как `+`, `-` и `=`, обычно добавляются как `MathematicalText` и соединяются в выражении.

Для интеграла используйте `Integral`:

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Добавление матриц**

Используйте [MathMatrix](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathmatrix/) для строк и столбцов. По умолчанию матрицы не включают скобки, поэтому обрамляйте их, когда нужны круглые, квадратные скобки или фигурные скобки.

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

## **Добавление массивов уравнений**

Используйте `ToMathArray`, когда нужны выровненные уравнения или вертикальная стековка выражений.

![Вертикальный массив уравнений с x над y](powerpoint-math-equations_11.png)

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

## **Добавление тригонометрических функций**

Используйте `AsArgumentOfFunction`, когда аргумент является текущим элементом и имя функции известно.

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

## **Добавление индексов и степеней**

Используйте вспомогательные функции для индексов и степеней. Когда индексы должны располагаться слева от основания, используйте `SetSubSuperscriptOnTheLeft`.

![Большая буква Y с левым индексом 1 и степенью n](powerpoint-math-equations_9.png)

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

## **Добавление разделителей**

Используйте `Enclose` для помещения выражения в разделители. Можно также задать символ‑разделитель для выражений с несколькими элементами.

![Выражение с разделителями, содержащие x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

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

## **Добавление рамки**

Используйте `ToBorderBox`, когда уравнение должно быть обрамлено.

![Уравнение в рамке, показывающее a² = b² + c²](powerpoint-math-equations_12.png)

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

## **Группировка членов**

Используйте `Group` для размещения символа группировки над или под выражением. Добавьте предел, чтобы пометить сгруппированные члены.

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

## **Форматирование элементов математики**

Используйте вспомогательные функции форматирования только там, где они проясняют формулу. Например, `Overbar` ставит черту над элементом.

![Математическое выражение ABC с надчеркиванием](powerpoint-math-equations_14.png)

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
| Создание математического текста | [MathematicalText](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathematicaltext/) |
| Объединение элементов | [IMathElement.Join](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/join/) |
| Создание дробей | [IMathElement.Divide](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/divide/) |
| Добавление верхнего или нижнего индекса | [SetSuperscript](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Добавление функций | [Function](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Добавление радикалов | [IMathElement.Radical](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/radical/) |
| Добавление пределов | [SetLowerLimit](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Добавление индексов слева | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Добавление сумм и интегралов | [Nary](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/integral/) |
| Добавление матриц | [MathMatrix](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathmatrix/) |
| Добавление массивов уравнений | [ToMathArray](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Добавление разделителей | [Enclose](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/enclose/) |
| Добавление черт и рамок | [Overbar](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Группировка членов | [Group](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Можно ли отредактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую `MathPortion`, получите её `MathParagraph` и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математика PowerPoint?**

Да. При сохранении в формате PPTX Aspose.Slides записывает уравнение как редактируемый контент Office Math.

**Можно ли экспортировать уравнения в LaTeX?**

Да. Получите [IMathParagraph](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathparagraph/) уравнения из его [MathPortion](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/mathportion/), затем вызовите [IMathParagraph.ToLatex](https://reference.aspose.com/slides/ru/net/aspose.slides.mathtext/imathparagraph/tolatex/) для прямого экспорта. Полный пример см. в статье [Export Math Equations from Presentations in .NET](/slides/ru/net/exporting-math-equations/#export-math-equations-to-latex).