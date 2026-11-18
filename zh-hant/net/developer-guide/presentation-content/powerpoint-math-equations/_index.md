---
title: 在 .NET 中將數學方程式加入 PowerPoint 簡報
linktitle: PowerPoint 數學方程式
type: docs
weight: 80
url: /zh-hant/net/powerpoint-math-equations/
keywords:
- 數學方程式
- 數學符號
- 數學公式
- 數學文字
- 新增數學方程式
- 新增數學符號
- 新增數學公式
- 新增數學文字
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 PowerPoint PPT 與 PPTX 中使用 Aspose.Slides for .NET 插入與編輯數學方程式，支援 OMML、格式控制，並提供清晰的 C# 程式碼範例。"
---
## **概述**

PowerPoint 以 Office Math Markup Language (OMML) 形式儲存方程式。使用 Aspose.Slides for .NET，您可以以程式方式建立相同類型的數學內容：分數、根號、函數、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常從 **Insert > Equation** 新增方程式：

![PowerPoint 插入索引標籤，已選取 Equation 指令](powerpoint-math-equations_1.png)

結果是在投影片上可編輯的數學文字：

![包含可編輯數學方程式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建構此數學文字：

- 使用 [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) 建立的數學圖形，是包含方程式的圖形。
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) 將數學內容儲存在圖形的文字框內。
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) 包含一或多個 [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) 物件。

以下大多數範例使用 [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) 以及來自 [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) 的連鎖方法，以保持程式碼簡潔易讀。

欲了解 MathML 匯出情境，請參閱 [Export Math Equations from Presentations in .NET](/slides/zh-hant/net/exporting-math-equations/)。

## **建立方程式**

此範例使用 [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) 建立數學圖形，並加入畢氏定理：

![方程式 c² = a² + b²](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="注意" %}}
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) 會建立已包含數學段落的圖形。存取第一個 [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)，取得其 [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/)，即可向其中新增數學區塊或數學元素。
{{% /alert %}}

## **新增分數**

使用 [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) 建立分數。您可以透過 [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) 選擇分數樣式。

![顯示 1 除以 x 的斜分數](powerpoint-math-equations_4.png)

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

若要使用堆疊式分數，請使用 [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/)：

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **新增根號**

使用 [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) 建立平方根、立方根或其他根號。當前元素成為根號的底，參數則成為指數。

![帶有 x 的 n 次根號表達式](powerpoint-math-equations_5.png)

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

### **顯示或隱藏平方根的指數**

平方根可顯示明確的 2，或使用慣用的 √x 記法。[IMathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/) 的 [HideDegree](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathradical/hidedegree/) 屬性控制使用哪種形式。兩種形式皆保留指數 2 與根號內的 x。

![左側 HideDegree 為 false，右側為 true 的同一平方根](square-root-degree.png)

此範例將相同的平方根儲存兩次。`visible-degree.pptx` 中 2 為可見；`hidden-degree.pptx` 中則被隱藏。

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

## **新增函數與極限**

使用 [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) 或 [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) 來建立 `sin(x)`、`log(x)` 或自訂函數名稱等函數。對於極限，將 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) 或使用 [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/)。

![當 x 趨近於無限大時的極限圖示](powerpoint-math-equations_8.png)

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

若要使用自訂函數名稱，將函數名稱設為當前元素，然後以其參數呼叫 [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/)：

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **新增 N 元運算子與積分**

使用 [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) 來建立總和、聯集、交集以及其他大型運算子。使用 [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) 來建立積分。兩者皆允許設定上下限。

![帶有上下限的總和圖示](powerpoint-math-equations_7.png)

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

N 元運算子用於具有可選上下限的大型運算子。像 `+`、`-`、`=` 這類簡單運算子通常以 [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) 加入表達式中。

要建立積分，請使用 [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/)：

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **新增矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) 來建立列與行。矩陣預設不包含括號，若需要括弧、方括號或大括號，請自行將矩陣包起來。

![包含一個空格的兩列矩陣圖示](powerpoint-math-equations_10.png)

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

### **編輯既有矩陣**

假設線性代數課程以 `matrix.pptx` 中的係數矩陣開始，此檔案由前述範例儲存。下一個練習保留第一個方程式，將第二個方程式換成兩個新方程式，並重新設定變數集合。透過 [IMathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/) 開啟既有矩陣，以保留仍然適用的係數。

![原始兩列係數矩陣，第一列為 1、x、空格，第二列為 x、2、y](matrix-before-edit.png)

列與行索引從 0 開始，並在每次呼叫時指向當前矩陣。於索引 1 前插入一列會把原本的第二列移至索引 2。於索引 2 後插入則會在末端新增一列。刪除第 2 列會移除原始的第二個方程式，並將新插入的列上移一個位置。行的變動方式相同。

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

// 新儲存格起初為 null。先設定非零係數。
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

[SetColumnAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnalignment/) 將第一欄對齊左側。[SetColumnsAlignment](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathmatrix/setcolumnsalignment/) 會將從索引 1 開始的連續三欄對齊右側。在 `updated-matrix.pptx` 中，矩陣有三個方程式與四個變數。原始第一列的係數 `1` 與 `x` 現在出現在第一與第三欄。

![更新後的三列矩陣，顯示列 1,0,x,0；12,1,0,0；以及 0,0,10,1](matrix-after-edit.png)

## **新增方程式陣列**

當需要對齊的方程式或垂直堆疊的表達式時，使用 [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/)。

![垂直陣列，x 位於 y 之上](powerpoint-math-equations_11.png)

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

### **將陣列與周圍元素對齊**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) 控制陣列相對於相鄰數學元素的垂直對齊方式。以下範例比較第一列、陣列中心與最後一列的對齊效果。

此範例建立三個相同的陣列，每個皆有三列，且左右相鄰元素分別為 `A=` 與 `=B`。所有數學文字均使用 Cambria Math，字型大小 24 點。唯一變化的是陣列的對齊方式。

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

以下比較圖示在 PowerPoint 中的儲存結果。請注意每個陣列旁的 `A=` 與 `=B` 位置。

![PowerPoint 中的方程式陣列，分別為上對齊、置中與下對齊，且相鄰元素相同](equation-array-alignment.png)

### **設定列間距**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) 可選擇陣列內列的間距規則。[RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) 提供明確的數值，僅在使用自訂間距時生效，預設規則會忽略此屬性。

對於精確間距，數值以點為單位。對於比例間距，則以半行為單位：範例中的 `3` 代表 1.5 行。設定明確值時，同時需設定兩個屬性；僅變更數值不會改變間距規則。

下列範例儲存五個投影片，內容、對齊與字型設定相同。前三個使用預設規則，最後兩個則示範明確數值。

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

陣列列間距獨立於段落間距。[SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) 與 [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) 會在包含段落的前後加入空間，而非在陣列列之間。同理，[IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) 只會水平定位整個數學段落，並不會取代陣列的垂直對齊設定。

## **新增三角函數**

當函數名稱已知且參數為當前元素時，使用 [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/)。

![三角函數 cos 作用於 2x 的示例](powerpoint-math-equations_6.png)

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

## **新增下標與上標**

使用下標與上標輔助工具處理索引與次方。若索引需顯示在基底的左側，請使用 [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/)。

![左側下標 1、上標 n 的大寫 Y](powerpoint-math-equations_9.png)

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

## **新增分界符號**

使用 [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) 可將表達式置於分界符號內。對於包含多個元素的分界符號，亦可設定分隔字元。

![使用直線分隔 x、y、z 的分界符號表達式](powerpoint-math-equations_13.png)

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

### **調整分界符號大小與對齊**

將 [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) 設為 `true`，可讓括號依高大的運算元自動伸展；設為 `false` 則保持原始大小。[DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) 接受兩種 [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) 值。`Centered` 會將括號置於數學軸的中心（等號中線），`Match` 則與所包圍的內容對齊。此設定僅影響分界符號本身，內部表達式保持不變。

範例將分數放入 `x` 的指數，使得表達式在基線上方的延伸比下方更長。四個方程式使用相同的括號與字型設定。

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

在 PowerPoint 中比較各列可見伸展效果。上排的括號會因指數而伸展，左右兩種形狀看起來相同；下排則關閉伸展。左側的較小括號（`Centered`）與等號對齊，右側的（`Match`）則在表達式上方稍高。

![四個方程式，上排括號伸展，下排不伸展，左側使用 Centered，右側使用 Match](delimiter-sizing.png)

## **新增邊框盒**

對分數呼叫 [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) 可為整個表達式加上框線。預設返回的 [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) 會顯示四條邊。使用 [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/)、[HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/)、[HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/)、[HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) 可自行隱藏任一邊。

範例在同一投影片放置六個相同的分數。為顯示取消效果，隱藏四條邊並設定 [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) 形成上升對角線 (↗)，或使用 [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) 形成下降對角線 (↘)。亦可搭配 [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) 或 [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) 與任意可見邊組合使用。

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

![六個可編輯分數，上排：完整邊框、下與左邊框、上升對角線；下排：下降對角線、水平刪除、垂直刪除且保留完整邊框](border-box-fractions.png)

在此分數中，水平刪除線會覆蓋分數線。垂直刪除線會同時貫穿分子與分母，而外圍邊框仍保持可見。這些線條裝飾整個表達式。普通文字的刪除線僅作用於文字執行序。重新開啟 PowerPoint 後，仍可獨立編輯分子與分母。

## **使用幻影元素控制可見性與版面配置**

將表達式包裹於 [MathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathphantom/) 可獨立控制其可見性與在方程式中佔用的空間。[IMathPhantom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/) 的屬性如下：

| Property | Effect |
| --- | --- |
| [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) | 設為 `false` 可隱藏表達式。其尺寸仍會影響版面配置，除非下列屬性設為 `true`。 |
| [ZeroWidth](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerowidth/) | 將表達式的水平寬度視為零，讓相鄰元素更貼近。 |
| [ZeroAsc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zeroasc/) | 將上升高度（基線上方的高度）視為零，可減少相鄰元素上方的保留空間。 |
| [ZeroDesc](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/zerodesc/) | 將下降深度（基線下方的深度）視為零，讓分數線或其他內容可更靠近相鄰元素。 |

基線是普通數學字母所坐落的參考線。隱藏內容不會移除其尺寸，將尺寸視為零亦不會刪除表達式。底層表達式仍可透過 [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/base/) 取得。將 [Show](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathphantom/show/) 設回 `true` 後即可再次顯示，尺寸設定保持不變。

以下範例建立五種並排變體：一個可見分數、一個保留空間的隱藏分數，及三個分別將寬度、上升或下降視為零的隱藏分數。每種變體使用相同的外圍表達式與 Cambria Math，字型大小 24 點。所有方程式圖形的頂部位置相同，以灰色導線標示。將幻影放在外層分數的分子中，可更容易觀察垂直版面變化。

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

![PowerPoint 中的五個方程式，分別比較可見分數、保留空間的隱藏分數，以及啟用 ZeroWidth、ZeroAsc 或 ZeroDesc 的隱藏分數](math-phantom.png)

## **分組項目**

使用 [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) 可在表達式上方或下方放置分組符號。可為分組項目加上極限標籤。

![x 加 y 的表達式，以下方文字標籤分組](powerpoint-math-equations_15.png)

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

## **格式化數學元素**

僅在需要時使用格式化輔助工具，以免干擾公式的可讀性。例如，使用 [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) 可在數學元素上方加上一條線。

![帶有上橫線的數學表達式 ABC](powerpoint-math-equations_14.png)

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

### **格式化既有方程式中的文字**

若要在既有方程式中格式化文字，請遍歷每個數學區塊的元素樹。[IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) 只會回傳直接子項，需遞迴呼叫才能取得分數、上下標、根號及其他巢狀結構中的文字。檢查當前元素與其子項，以確保包括當前元素為 [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) 時也會被處理。

此範例假設投影片中包含方程式 `z = xᵢ / ∛y`，其中分數的分子含有下標，分母含有根號。若僅處理區塊的頂層元素，會錯過分數內的文字。範例在投影片文字框中尋找數學片段，透過 [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) 取得其區塊，並將每個文字元素的 [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) 中的 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) 設為 28 點。

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

儲存的投影片在每個處理過的方程式各層級都已更新文字格式，同時保留原始文字內容與數學結構。

## **快速參考**

| Task | Main API |
| --- | --- |
| 建立數學文字 | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| 合併元素 | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| 建立分數 | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| 新增上標或下標 | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| 新增函數 | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| 新增根號 | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| 新增極限 | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| 新增左側上下標 | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| 新增總和與積分 | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| 新增矩陣 | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| 新增方程式陣列 | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| 新增分界符號 | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| 新增橫線與邊框 | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| 分組項目 | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **常見問答**

**我可以編輯既有的 PowerPoint 方程式嗎？**

可以。開啟投影片後，找到包含 [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) 的圖形，取得其 [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/)，即可更新該段落中的數學區塊。

**方程式是否會以可編輯的 PowerPoint 數學格式儲存？**

會。將檔案另存為 PPTX 時，Aspose.Slides 會將方程式寫入可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

可以。從其 [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) 取得 [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/)，呼叫 [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) 直接匯出。完整範例請參閱 [Export Math Equations from Presentations in .NET](/slides/zh-hant/net/exporting-math-equations/#export-math-equations-to-latex)。