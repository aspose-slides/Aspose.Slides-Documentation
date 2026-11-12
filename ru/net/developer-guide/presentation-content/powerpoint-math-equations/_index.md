---
title: Добавить математические уравнения в презентации PowerPoint в .NET
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
description: "Вставляйте и редактируйте математические уравнения в PowerPoint PPT и PPTX с помощью Aspose.Slides for .NET, поддерживая OMML, элементы управления форматированием и понятные примеры кода C#."
---
## **Обзор**

PowerPoint хранит уравнения в формате Office Math Markup Language (OMML). С помощью Aspose.Slides for .NET вы можете программно создавать тот же тип математического контента: дроби, радикалы, функции, пределы, N-ary операторы, матрицы, массивы и форматированные математические блоки.

В PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![Вкладка Insert в PowerPoint с выбранной командой Equation](powerpoint-math-equations_1.png)

Результатом является редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides создает этот математический текст с помощью трех основных объектов:

- Математическая фигура, созданная с помощью [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), это фигура, содержащая уравнение.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) хранит математическое содержимое внутри текстового фрейма фигуры.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) содержит один или более объектов [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) и плавные методы из [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) для краткости и читаемости кода.

Для сценариев экспорта в MathML см. [Export Math Equations from Presentations in .NET](/slides/ru/net/exporting-math-equations/).

## **Создать уравнение**

Этот пример использует [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) для создания математической фигуры и добавляет теорему Пифагора:

![Уравнение c в квадрате равно a в квадрате плюс b в квадрате](powerpoint-math-equations_3.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

{{% alert color="info" title="Note" %}}
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) создает фигуру, которая уже содержит математический абзац. Получите первый [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), его [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), и добавьте в него математические блоки или элементы.
{{% /alert %}}

## **Добавить дроби**

Используйте [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Наклоненная математическая дробь, показывающая один, делённый на x](powerpoint-math-equations_4.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var fraction = new MathematicalText("1")
    .Divide("x", MathFractionTypes.Skewed);

mathParagraph.Add(new MathBlock(fraction));

presentation.Save("fraction.pptx", SaveFormat.Pptx);
```

Для сложенной (stacked) дроби используйте [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Добавить радикалы**

Используйте [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) для создания квадратного корня, кубического корня или другого корня. Текущий элемент становится основанием, а аргумент — степенью.

![n-ый корень с x под радикальной чертой](powerpoint-math-equations_5.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Используйте [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) или [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) для функций, таких как `sin(x)`, `log(x)` или пользовательские имена функций. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) или используйте [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

![Предел x при x стремящемся к бесконечности](powerpoint-math-equations_8.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Для пользовательского имени функции сделайте имя функции текущим элементом и вызовите [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) с его аргументом:

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **Добавить N-арные операторы и интегралы**

Используйте [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) для суммирования, объединений, пересечений и других больших операторов. Используйте [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) для интегралов. Оба метода позволяют задавать нижние и верхние пределы.

![Суммирование с нижними и верхними пределами](powerpoint-math-equations_7.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

N-ary операторы предназначены для больших операторов с необязательными пределами. Простые операторы, такие как `+`, `-` и `=`, обычно добавляются как [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) и объединяются в выражение.

Для интеграла используйте [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Добавить матрицы**

Используйте [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) для строк и столбцов. По умолчанию матрицы не включают скобки, поэтому обрамляйте матрицу, когда нужны круглые, квадратные или фигурные скобки.

![Математическая матрица из двух строк с одной пустой ячейкой](powerpoint-math-equations_10.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Используйте [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) когда нужны выровненные уравнения или вертикальный стек выражений.

![Вертикальный массив уравнений с x над y](powerpoint-math-equations_11.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

### **Выровнять массив с окружающими элементами**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) управляет вертикальным выравниванием массива относительно соседних математических элементов. Пример ниже сравнивает выравнивание по первой строке, по центру массива и по последней строке.

Следующий пример создает три одинаковых массива, каждый из трёх строк, с соседними элементами `A=` и `=B`. Весь математический текст использует шрифт Cambria Math 24 пункта. Меняется только выравнивание массива.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(780, 200, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var alignments = new[] { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };

for (int i = 0; i < alignments.Length; i++)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = alignments[i].ToString();
    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 16;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var mathShape = slide.Shapes.AddMathShape(20 + i * 260, 60, 240, 130);
    mathShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    var mathParagraph = ((IMathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Justification = MathJustification.LeftJustified;

    var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
    var equationArray = new MathArray(rows);
    equationArray.BaseJustification = alignments[i];
    var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
    mathParagraph.Add(equation);
}

presentation.Save("equation-array-alignment.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

Сравнение ниже показывает сохранённую презентацию в PowerPoint. Обратите внимание на положение `A=` и `=B` рядом с каждым массивом.

![Массивы уравнений в PowerPoint с выравниванием по верхнему, центральному и нижнему краю и одинаковыми соседними элементами](equation-array-alignment.png)

### **Настроить расстояние между строками**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) выбирает правило отступа для строк внутри массива. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) задаёт численное значение для явного правила отступа и игнорируется предустановленными правилами.

Для точного отступа значение измеряется в пунктах. Для пропорционального отступа измеряется в половинах строк: значение `3` в примере соответствует 1,5 строки. Устанавливайте оба свойства, когда задаёте явное значение; изменение только численного значения не выбирает правило отступа.

Пример ниже сохраняет пять презентаций с одинаковыми уравнениями, выравниванием и настройками шрифта. Первые три используют предустановки; последние два показывают явные значения.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

var settings = new (MathRowSpacingRule Rule, uint Spacing)[]
{
    (MathRowSpacingRule.SingleLineGap, 0),
    (MathRowSpacingRule.OneAndAHalfLineGap, 0),
    (MathRowSpacingRule.TwoLineGap, 0),
    (MathRowSpacingRule.Exactly, 20),
    (MathRowSpacingRule.Multiple, 3)
};

foreach (var setting in settings)
{
    var fileName = $"equation-array-{setting.Rule}.pptx";
    using (var presentation = new Presentation())
    {
        var mathShape = presentation.Slides[0].Shapes.AddMathShape(20, 20, 600, 300);
        var paragraph = mathShape.TextFrame.Paragraphs[0];
        paragraph.ParagraphFormat.SpaceBefore = 0;
        paragraph.ParagraphFormat.SpaceAfter = 0;
        var mathParagraph = ((IMathPortion)paragraph.Portions[0]).MathParagraph;
        mathParagraph.Justification = MathJustification.LeftJustified;

        var rows = new IMathElement[] { CreateText("x+y=3"), CreateText("x-y=1"), CreateText("x=2") };
        var equationArray = new MathArray(rows);
        equationArray.BaseJustification = MathVerticalAlignment.Center;
        equationArray.RowSpacingRule = setting.Rule;
        equationArray.RowSpacing = setting.Spacing;
        var equation = new MathBlock(CreateText("A=")).Join(equationArray).Join(CreateText("=B"));
        mathParagraph.Add(equation);

        presentation.Save(fileName, SaveFormat.Pptx);
    }

}

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

Отступы строк массива отделены от отступов абзаца. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) и [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) добавляют пространство вокруг содержащего абзаца, а не между строками массива. Аналогично, [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) позиционирует весь математический абзац по горизонтали; он не заменяет настройку вертикального выравнивания массива.

## **Добавить тригонометрические функции**

Используйте [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) когда аргумент является текущим элементом и имя функции известно.

![Тригонометрическая функция cos, применённая к 2x](powerpoint-math-equations_6.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Используйте вспомогательные функции индексов и степеней для индексов и показателей. Когда индексы должны располагаться слева от основания, используйте [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![Заглавная Y с левым индексом 1 и степенью n](powerpoint-math-equations_9.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var scripts = new MathematicalText("Y")
    .SetSubSuperscriptOnTheLeft("1", "n");

mathParagraph.Add(new MathBlock(scripts));

presentation.Save("subscript-superscript.pptx", SaveFormat.Pptx);
```

## **Добавить ограничители**

Используйте [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) чтобы поместить выражение внутри ограничителей. Вы также можете задать символ-разделитель для выражений с несколькими элементами.

![Выражение с ограничителями, содержащие x, y и z, разделённые вертикальными чертами](powerpoint-math-equations_13.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

### **Размер и выравнивание ограничителей**

Установите [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) в `true`, чтобы скобки увеличивались вокруг высокого операнда, или в `false`, чтобы оставить их обычного размера. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) принимает одно из двух значений [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/). `Centered` центрирует скобки по математической оси, проходящей через середину знака `=`. `Match` выравнивает их по содержимому. Оба параметра влияют только на ограничители. Выражение внутри остаётся неизменным.

Пример помещает дробь в степень `x`, поэтому выражение вытягивается выше базовой линии, чем ниже её. Все четыре уравнения используют одинаковые скобки и настройки шрифта.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

void AddExpression(float left, float top, bool grow, MathDelimiterShape shape)
{
    var fraction = new MathematicalText("a + b").Divide("c + d");
    var power = new MathematicalText("x").SetSuperscript(fraction);
    var delimiter = power.Enclose('(', ')');
    delimiter.GrowToMatchOperandHeight = grow;
    delimiter.DelimiterShape = shape;

    var mathShape = slide.Shapes.AddMathShape(left, top, 300, 100);
    var portion = (MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 32;
    var equation = new MathematicalText("y = ").Join(delimiter);
    portion.MathParagraph.Add(equation);
}

AddExpression(20, 20, true, MathDelimiterShape.Centered);
AddExpression(350, 20, true, MathDelimiterShape.Match);
AddExpression(20, 140, false, MathDelimiterShape.Centered);
AddExpression(350, 140, false, MathDelimiterShape.Match);

presentation.Save("delimiter-sizing.pptx", SaveFormat.Pptx);
```

В PowerPoint сравните строки, чтобы увидеть эффект роста. В верхней строке скобки растут, охватывая степень, и выглядят одинаково для обеих форм. В нижней строке рост выключен. Меньшие скобки слева (`Centered`) выравниваются с знаком `=`, а справа (`Match`) находятся выше вокруг выражения.

![Четыре уравнения в PowerPoint с включённым ростом ограничителей сверху и выключенным снизу, при этом `Centered` слева и `Match` справа](delimiter-sizing.png)

## **Добавить рамку**

Вызовите [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) для дроби, чтобы обрамить всё выражение. Возвращаемый [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) по умолчанию показывает все четыре стороны. Используйте [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) и [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) для удаления отдельных сторон.

Пример размещает шесть копий одной и той же дроби на одном слайде. Чтобы показать отмену, скройте все четыре стороны и задайте [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) для восходящей диагонали (↗) или [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) для нисходящей диагонали (↘). Вы также можете использовать [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) или [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) в любой комбинации видимых сторон.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(540, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

IMathBorderBox AddFraction(float x, float y, bool hideBorder = false)
{
    var fraction = new MathematicalText("x+1").Divide("y+2");
    var box = fraction.ToBorderBox();
    box.HideTop = box.HideBottom = box.HideLeft = box.HideRight = hideBorder;

    var shape = slide.Shapes.AddMathShape(x, y, 160, 90);
    var portion = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.FontHeight = 28;
    portion.MathParagraph.Add(new MathBlock(box));
    return box;
}

AddFraction(10, 10);

var partial = AddFraction(190, 10);
partial.HideTop = true;
partial.HideRight = true;

AddFraction(370, 10, hideBorder: true).StrikethroughBottomLeftToTopRight = true;
AddFraction(10, 120, hideBorder: true).StrikethroughTopLeftToBottomRight = true;
AddFraction(190, 120, hideBorder: true).StrikethroughHorizontal = true;
AddFraction(370, 120).StrikethroughVertical = true;

presentation.Save("border-box.pptx", SaveFormat.Pptx);
```

![Шесть редактируемых дробей в PowerPoint. Верхняя строка: полная рамка, нижняя и левая стороны, восходящая диагональ. Нижняя строка: нисходящая диагональ, горизонтальная черта, вертикальная черта с полной рамкой.](border-box-fractions.png)

В этой дроби горизонтальная черта перекрывает черту дроби. Вертикальная черта пересекает и числитель, и знаменатель, в то время как окружающая рамка остаётся видимой. Эти линии украшают всё выражение. Обычное зачеркивание текста применяется к символам в текстовом фрагменте. После повторного открытия презентации в PowerPoint вы всё ещё можете независимо редактировать числитель и знаменатель.

## **Группировать члены**

Используйте [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) чтобы разместить символ группировки над или под выражением. Добавьте предел, чтобы пометить сгруппированные члены.

![Выражение x плюс y, сгруппированное с подписью любой текст снизу](powerpoint-math-equations_15.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

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

Используйте вспомогательные функции форматирования только там, где они проясняют формулу. Например, [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) помещает черту над математическим элементом.

![Математическое выражение ABC с надчеркиванием](powerpoint-math-equations_14.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

### **Форматировать текст в существующем уравнении**

Чтобы отформатировать текст по всему существующему уравнению, обойдите дерево элементов каждого математического блока. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) возвращает только непосредственных детей, поэтому вызывайте его рекурсивно, чтобы попасть к тексту внутри дробей, скриптов, радикалов и других вложенных структур. Проверяйте текущий элемент и его детей, чтобы включить начальный элемент, когда он является [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/).

Этот пример предполагает, что презентация содержит уравнение, например `z = xᵢ / ∛y`, где дробь содержит нижний индекс в числителе и радикал в знаменателе. Обработка только элементов верхнего уровня блока пропустит текст внутри дроби. Пример ищет математические части в текстовых фреймах слайдов, получает их блоки через [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), и задаёт [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) 28 пунктов каждому текстовому элементу через его свойство [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape || autoShape.TextFrame == null)
            continue;

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is IMathPortion mathPortion)
                {
                    foreach (var block in mathPortion.MathParagraph)
                        FormatMathText(block);
                }
            }
        }
    }
}

presentation.Save("formatted-equations.pptx", SaveFormat.Pptx);

void FormatMathText(IMathElement element)
{
    if (element is MathematicalText text)
        text.Format.FontHeight = 28;

    foreach (var child in element.GetChildren())
        FormatMathText(child);
}
```

Сохранённая презентация содержит обновлённое форматирование текста на каждом уровне каждой обработанной формулы, сохраняя её текстовое содержимое и математическую структуру.

## **Быстрая справка**

| Task | Main API |
| --- | --- |
| Create math text | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| Combine elements | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| Create fractions | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| Add superscript or subscript | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| Add functions | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Add radicals | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| Add limits | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Add left-side scripts | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Add summations and integrals | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| Add matrices | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| Add equation arrays | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| Add delimiters | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| Add bars and borders | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| Group terms | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **FAQ**

**Можно ли отредактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), получите её [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математическая часть PowerPoint?**

Да. При сохранении в формате PPTX Aspose.Slides записывает уравнение как редактируемое Office‑math содержимое.

**Можно ли экспортировать уравнения в LaTeX?**

Да. Получите [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) уравнения из его [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), и вызовите [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) для непосредственного экспорта. Для полного примера см. [Export Math Equations from Presentations in .NET](/slides/ru/net/exporting-math-equations/#export-math-equations-to-latex).