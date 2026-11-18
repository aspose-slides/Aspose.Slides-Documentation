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
description: "Вставка и редактирование математических уравнений в PowerPoint PPT и PPTX с использованием Aspose.Slides для .NET, поддержка OMML, средств форматирования и понятных примеров кода на C#."
---
## **Обзор**

PowerPoint хранит уравнения в формате Office Math Markup Language (OMML). С помощью Aspose.Slides для .NET вы можете программно создавать такой же тип математического контента: дроби, радикалы, функции, пределы, N‑арные операторы, матрицы, массивы и форматированные математические блоки.

В PowerPoint пользователи обычно добавляют уравнения через **Insert > Equation**:

![Вкладка Insert в PowerPoint с выбранной командой Equation](powerpoint-math-equations_1.png)

Результат – редактируемый математический текст на слайде:

![Слайд PowerPoint, содержащий редактируемое математическое уравнение](powerpoint-math-equations_2.png)

Aspose.Slides создаёт этот математический текст с помощью трёх основных объектов:

- Математическая фигура, создаваемая с помощью [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/), является фигурой, содержащей уравнение.
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) хранит математическое содержание внутри текстового блока фигуры.
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) содержит один или несколько объектов [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/).

Большинство примеров ниже используют [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) и плавные методы из [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) для краткости и читаемости кода.

Для сценариев экспорта в MathML см. [Экспорт уравнений Math из презентаций в .NET](/slides/ru/net/exporting-math-equations/).

## **Создание уравнения**

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) создаёт фигуру, уже содержащую математический абзац. Получите первую [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), извлеките её [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), и добавляйте в неё математические блоки или элементы.
{{% /alert %}}

## **Добавление дробей**

Используйте [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) для создания дроби. Вы можете выбрать стиль дроби с помощью [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/).

![Наклоненная математическая дробь, показывающая один деленное на x](powerpoint-math-equations_4.png)

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

Для сложенной дроби используйте [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **Добавление радикалов**

Используйте [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) для создания квадратного, кубического или другого корня. Текущий элемент становится основанием, а аргумент – степенью.

![Выражение n‑го корня с x под радикалом](powerpoint-math-equations_5.png)

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

### **Показать или скрыть степень квадратного корня**

Квадратный корень может отображать явную 2 или использовать обычную запись √x. Свойство [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) интерфейса [IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) управляет отображаемой формой. Оба варианта сохраняют степень 2 и радиканд x в редактируемом уравнении.

![Тот же квадратный корень с HideDegree, установленным в false слева и true справа](square-root-degree.png)

Пример сохраняет один и тот же квадратный корень дважды. В `visible-degree.pptx` степень 2 видима. В `hidden-degree.pptx` она скрыта.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var radical = new MathematicalText("x").Radical("2");

var shape = slide.Shapes.AddMathShape(20, 20, 200, 100);
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
portion.MathParagraph.Add(new MathBlock(radical));

radical.HideDegree = false;
presentation.Save("visible-degree.pptx", SaveFormat.Pptx);

radical.HideDegree = true;
presentation.Save("hidden-degree.pptx", SaveFormat.Pptx);
```

## **Добавление функций и пределов**

Используйте [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) или [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) для функций вроде `sin(x)`, `log(x)` или пользовательских имён функций. Для пределов поместите `lim` в [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) или используйте [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/).

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

## **Добавление N‑арных операторов и интегралов**

Используйте [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) для сумм, объединений, пересечений и других больших операторов. Для интегралов используйте [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/). Оба метода позволяют задать нижний и верхний пределы.

![Суммирование с нижним и верхним пределами](powerpoint-math-equations_7.png)

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

N‑арные операторы предназначены для больших операторов с необязательными пределами. Простые операторы вроде `+`, `-` и `=` обычно добавляются как [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) и включаются в выражение.

Для интеграла используйте [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/):

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **Добавление матриц**

Используйте [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) для работы со строками и столбцами. По умолчанию матрицы не включают скобки, поэтому при необходимости обрамляйте их круглыми скобками, квадратными или фигурными.

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

### **Редактирование существующей матрицы**

Предположим, что урок линейной алгебры начинается с матрицы коэффициентов в `matrix.pptx`, сохранённой предыдущим примером. Для следующего упражнения оставьте первое уравнение, замените второе двумя новыми уравнениями и измените набор переменных. Откройте существующую матрицу через [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/), чтобы сохранить коэффициенты, которые всё ещё актуальны.

![Исходная матрица коэффициентов из двух строк с элементами 1, x и пустой ячейкой в первой строке и x, 2, y во второй](matrix-before-edit.png)

Индексы строк и столбцов нумеруются с нуля и относятся к текущему состоянию матрицы на каждый вызов. Вставка строки перед индексом 1 перемещает оригинальную вторую строку к индексу 2. Вставка после индекса 2 затем добавляет строку. Удаление строки 2 удаляет оригинальное второе уравнение и сдвигает добавленную строку вверх на одну позицию. Столбцы смещаются аналогично.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation("matrix.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var portion = (IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
var matrix = (IMathMatrix)portion.MathParagraph[0][0];

matrix.InsertRowBefore(1);
matrix.InsertRowAfter(2);
matrix.DeleteRow(2);

matrix.InsertColumnBefore(1);
matrix.InsertColumnAfter(3);
matrix.DeleteColumn(3);

// Новые ячейки изначально равны null. Сначала установите ненулевые коэффициенты.
matrix[1, 0] = new MathematicalText("12");
matrix[1, 1] = new MathematicalText("1");
matrix[2, 2] = new MathematicalText("10");
matrix[2, 3] = new MathematicalText("1");
for (var row = 0; row < matrix.RowCount; row++)
{
    for (var column = 0; column < matrix.ColumnCount; column++)
    {
        matrix[row, column] ??= new MathematicalText("0");
    }
}

matrix.SetColumnAlignment(0, MathHorizontalAlignment.Left);
matrix.SetColumnsAlignment(1, 3, MathHorizontalAlignment.Right);

presentation.Save("updated-matrix.pptx", SaveFormat.Pptx);
```

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) выравнивает первый столбец по левому краю. [SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) выравнивает три соседних столбца по правому краю, начиная с индекса 1. В `updated-matrix.pptx` матрица содержит три уравнения и четыре переменные. Первоначальные коэффициенты первой строки `1` и `x` теперь находятся в первом и третьем столбцах.

![Обновленная матрица из трёх строк, показывающая строки 1, 0, x, 0; 12, 1, 0, 0; и 0, 0, 10, 1](matrix-after-edit.png)

## **Добавление массивов уравнений**

Используйте [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) когда нужны выровненные уравнения или вертикальная стековая последовательность выражений.

![Вертикальный математический массив с x над y](powerpoint-math-equations_11.png)

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

### **Выравнивание массива с окружающими элементами**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) управляет вертикальным выравниванием массива относительно соседних математических элементов. Ниже приведён пример, сравнивающий выравнивание по первой строке, центру массива и последней строке.

Следующий пример создаёт три одинаковых массива, каждый с тремя строками и соседними элементами `A=` и `=B`. Весь математический текст использует шрифт Cambria Math размером 24 пт. Меняется только выравнивание массива.

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

Сравнительная таблица показывает сохранённую презентацию в PowerPoint. Обратите внимание на позицию `A=` и `=B` рядом с каждым массивом.

![Массивы уравнений в PowerPoint с выравниванием сверху, по центру и снизу и одинаковыми соседними элементами](equation-array-alignment.png)

### **Настройка интервала строк**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) выбирает правило интервала для строк внутри массива. [RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) задаёт числовое значение для явного правила и игнорируется предустановленными правилами.

Для точного интервала значение измеряется в пунктах. Для пропорционального интервала оно измеряется в полу‑строках: значение `3` в примере означает 1,5 строки. Устанавливайте оба свойства, когда задаёте явное значение; изменение только числового значения не выбирает правило интервала.

Ниже приведён пример, сохраняющий пять презентаций с одинаковыми уравнениями, выравниванием и настройками шрифта. Первые три используют предустановки; последние два показывают явные значения.

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

Интервал строк массива отдельный от интервала абзаца. [SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) и [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) добавляют пространство вокруг содержащего абзаца, а не между строками массива. Аналогично, [IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) позиционирует весь математический абзац по горизонтали; он не заменяет настройку вертикального выравнивания массива.

## **Добавление тригонометрических функций**

Используйте [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/), когда аргумент является текущим элементом, а имя функции известно.

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

## **Добавление индексов и надстрочных**

Используйте вспомогательные функции для нижних и верхних индексов. Когда индексы должны располагаться слева от основания, используйте [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/).

![Заглавная Y с левым нижним индексом 1 и верхним индексом n](powerpoint-math-equations_9.png)

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

## **Добавление разделителей**

Используйте [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) для помещения выражения внутрь разделителей. Вы также можете задать символ‑разделитель для выражений, содержащих несколько элементов.

![Выражение с разделителями, содержащие x, y и z, разделённые вертикальными линиями](powerpoint-math-equations_13.png)

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

### **Размер и выравнивание разделителей**

Установите [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) в `true`, чтобы скобки автоматически растягивались вокруг высокого операнда, или в `false`, чтобы сохранять их обычный размер. [DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) принимает одно из двух значений [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/). `Centered` центрирует скобки относительно математической оси, проходящей через середину знака равенства. `Match` выравнивает их по содержимому. Оба параметра влияют только на скобки; выражение внутри остаётся тем же.

В примере дробь помещена в экспоненту `x`, поэтому выражение выступает выше базовой линии сильнее, чем ниже. Все четыре уравнения используют одинаковые скобки и настройки шрифта.

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

В PowerPoint сравните строки, чтобы увидеть эффект роста. В верхней строке скобки растягиваются, охватывая экспоненту, и выглядят одинаково для обеих форм. В нижней строке рост отключён. Меньшие скобки слева (`Centered`) выравниваются с знаком равно, а правые (`Match`) находятся выше вокруг выражения.

![Четыре уравнения в PowerPoint с включённым ростом скобок сверху и отключённым снизу, `Centered` слева и `Match` справа](delimiter-sizing.png)

## **Добавление рамки**

Вызовите [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) у дроби, чтобы обрамить всё выражение. Возвращаемый [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) по умолчанию отображает все четыре стороны. Используйте [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/), [HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/), [HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) и [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/), чтобы убрать отдельные стороны.

В примере размещены шесть копий одной и той же дроби на одном слайде. Чтобы показать отмену, скрывают все четыре стороны и задают [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) для восходящей диагонали (↗) или [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) для нисходящей диагонали (↘). Можно также использовать [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) или [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) в сочетании с любыми видимыми сторонами.

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

![Шесть редактируемых дробей в PowerPoint. Верхняя строка: полностью обрамлена, нижняя и левая стороны, восходящая диагональ. Нижняя строка: нисходящая диагональ, горизонтальная линия, вертикальная линия с полной рамкой](border-box-fractions.png)

На этой дроби горизонтальная черта перекрывает черту дроби. Вертикальная черта пересекает и числитель, и знаменатель, при этом окружающая рамка остаётся видимой. Эти линии украшают всё выражение. Обычное зачеркивание текста действует только на символы в текстовом фрагменте. После повторного открытия презентации в PowerPoint вы всё равно сможете независимо редактировать числитель и знаменатель.

## **Управление видимостью и компоновкой с помощью Phantom‑элементов**

Обёрните выражение в [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/), чтобы независимо контролировать его видимость и пространство, которое оно занимает в уравнении. Свойства [IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) управляют следующими параметрами:

| Property | Effect |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | Установите `false`, чтобы скрыть выражение. Его размеры всё равно учитываются в компоновке, если соответствующие свойства ниже не установлены в `true`. |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | Рассматривать горизонтальную ширину выражения как ноль, позволяя соседним элементам приближаться друг к другу. |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | Рассматривать восхождение (высоту над базовой линией) как ноль, что может уменьшить пространство выше соседних элементов. |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | Рассматривать спуск (глубину ниже базовой линии) как ноль, что может приблизить дробную черту или другое содержимое под выражением к соседям. |

Базовая линия — это референсная линия, на которой расположены обычные математические символы. Скрытие содержимого не удаляет его размеры, а задание нулевого размера не удаляет выражение. Исходное выражение остаётся доступным через [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/). Установите [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) обратно в `true`, чтобы отобразить его снова; настройки размеров сохраняются.

Ниже пример, создающий пять вариантов рядом: видимая дробь, скрытая дробь, сохраняющая пространство, и три скрытые дроби, у которых один из параметров равен нулю. Каждый вариант использует то же окружающее выражение и шрифт Cambria Math 24 пт. Все фигуры уравнений имеют одинаковую верхнюю позицию, отмеченную серой направляющей. Размещение phantom‑элемента в числителе внешней дроби облегчает восприятие вертикальных изменений компоновки.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(1000, 180, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var labels = new[] { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

var guide = slide.Shapes.AddAutoShape(ShapeType.Line, 10, 60, 980, 0);
guide.LineFormat.FillFormat.FillType = FillType.Solid;
guide.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;

for (var i = 0; i < labels.Length; i++)
{
    var left = 10 + i * 200;
    
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;
    label.TextFrame.Text = labels[i];

    var labelFormat = label.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    labelFormat.FontHeight = 14;
    labelFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var fraction = new MathFraction(CreateText("a+b"), CreateText("c+d"));
    var phantom = new MathPhantom(fraction);
    phantom.Show = i == 0;
    phantom.ZeroWidth = i == 2;
    phantom.ZeroAsc = i == 3;
    phantom.ZeroDesc = i == 4;

    var numerator = new MathBlock(CreateText("x+")).Join(phantom).Join(CreateText("+y"));
    var equation = new MathFraction(numerator, CreateText("z"));

    var shape = slide.Shapes.AddMathShape(left, 60, 190, 100);
    shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;

    var mathParagraph = ((IMathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    mathParagraph.Add(new MathBlock(equation));
}

presentation.Save("math-phantom.pptx", SaveFormat.Pptx);

MathematicalText CreateText(string value)
{
    var text = new MathematicalText(value);
    text.Format.FontHeight = 24;
    text.Format.LatinFont = new FontData("Cambria Math");
    return text;
}
```

![Пять уравнений в PowerPoint, сравнивающих видимую дробь, скрытую, сохраняющую пространство, и скрытые с включёнными ZeroWidth, ZeroAsc или ZeroDesc](math-phantom.png)


## **Группировка терминов**

Используйте [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) для размещения группировочного символа над или под выражением. Добавьте предел, чтобы подписать сгруппированные термины.

![Выражение x + y, сгруппированное с подписью любой текст снизу](powerpoint-math-equations_15.png)

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

## **Форматирование математических элементов**

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

### **Форматирование текста в существующем уравнении**

Чтобы отформатировать текст во всём существующем уравнении, пройдите по дереву элементов каждого математического блока. [IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) возвращает только непосредственные дочерние элементы, поэтому вызывайте его рекурсивно, чтобы достичь текста внутри дробей, скриптов, радикалов и других вложенных структур. Проверяйте текущий элемент и его дочерние, чтобы включить начальный элемент, если он является [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/).

В этом примере предполагается, что презентация содержит уравнение вида `z = xᵢ / ∛y`, где дробь содержит нижний индекс в числителе и радикал в знаменателе. Обработка только верхнего уровня блока пропустила бы текст внутри дроби. Пример находит математические части в текстовых фреймах слайдов, получает их блоки через [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/), и задаёт [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) = 28 пт каждому текстовому элементу через свойство [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/).

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

Сохранённая презентация содержит обновлённое форматирование текста на каждом уровне всех обработанных уравнений, при этом сохраняет их текстовое содержание и математическую структуру.

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

**Могу ли я отредактировать существующее уравнение PowerPoint?**

Да. Откройте презентацию, найдите фигуру, содержащую [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), извлеките её [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/), и обновите математические блоки в этом абзаце.

**Сохраняются ли уравнения как редактируемая математика PowerPoint?**

Да. При сохранении в PPTX Aspose.Slides записывает уравнение как редактируемый Office‑math контент.

**Могу ли я экспортировать уравнения в LaTeX?**

Да. Получите [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/) уравнения из его [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/), и вызовите [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) для прямого экспорта. Полный пример см. в [Экспорт уравнений Math из презентаций в .NET](/slides/ru/net/exporting-math-equations/#export-math-equations-to-latex).