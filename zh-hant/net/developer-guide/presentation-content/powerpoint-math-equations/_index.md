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
description: "使用 Aspose.Slides for .NET 在 PowerPoint PPT 與 PPTX 中插入與編輯數學方程式，支援 OMML、格式控制，並提供清晰的 C# 程式碼範例。"
---
## **概觀**

PowerPoint 將方程式儲存為 Office Math Markup Language (OMML)。使用 Aspose.Slides for .NET，您可以以程式方式建立相同類型的數學內容：分數、根號、函數、極限、N 元運算子、矩陣、陣列，以及格式化的數學區塊。

在 PowerPoint 中，使用者通常從 **Insert > Equation** 新增方程式：

![PowerPoint 插入標籤，已選取方程式命令](powerpoint-math-equations_1.png)

結果是投影片上可編輯的數學文字：

![包含可編輯數學方程式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建立此數學文字：

- 數學形狀，由 [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) 建立，是包含方程式的形狀。
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) 將數學內容儲存在形狀文字框內。
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) 物件。

以下大多數範例使用 [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) 以及 [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) 的流暢方法，以保持程式碼簡潔且易讀。

關於 MathML 匯出情境，請參閱 [從 .NET 簡報匯出數學方程式](/slides/zh-hant/net/exporting-math-equations/)。

## **建立方程式**

此範例使用 [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) 建立數學形狀，並加入畢氏定理：

![c 平方等於 a 平方加 b 平方的方程式](powerpoint-math-equations_3.png)

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
[AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) 建立已包含數學段落的形狀。存取第一個 [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)，取得它的 [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/)，並向其中新增數學區塊或數學元素。
{{% /alert %}}

## **新增分數**

使用 [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) 建立分數。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) 選擇分數樣式。

![一個斜式的數學分數，顯示 1 除以 x](powerpoint-math-equations_4.png)

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

若要堆疊式分數，使用 [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/)：

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **新增根號**

使用 [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) 建立平方根、立方根或其他次方根。當前元素成為底數，參數則成為指數。

![一個 n 次根號表達式，x 位於根號符號下方](powerpoint-math-equations_5.png)

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

## **新增函數與極限**

使用 [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) 或 [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) 來處理如 `sin(x)`、`log(x)` 或自訂函數名稱等函數。對於極限，將 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/)，或使用 [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/)。

![當 x 趨近無限大時的極限](powerpoint-math-equations_8.png)

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

若要使用自訂函數名稱，將函數名稱設為當前元素，並以其參數呼叫 [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/)：

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **新增 N 元運算子與積分**

使用 [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) 來處理求和、合併、交集以及其他大型運算子。使用 [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) 來處理積分。這兩種方法皆可設定上下限。

![帶有上下限的求和](powerpoint-math-equations_7.png)

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

N 元運算子用於帶有可選上下限的大型運算子。像 `+`、`-`、`=` 這樣的簡單運算子通常以 [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) 加入並連接到表達式中。

若要建立積分，使用 [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/)：

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **新增矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) 來建立列與行。預設情況下矩陣不會包含括號，當需要括號、方括號或大括號時，請自行將矩陣包起來。

![一個兩列的數學矩陣，包含一個空白儲存格](powerpoint-math-equations_10.png)

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

## **新增方程式陣列**

當需要對齊的方程式或垂直堆疊的表達式時，請使用 [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/)。

![垂直數學陣列，x 位於 y 之上](powerpoint-math-equations_11.png)

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

### **調整陣列與周圍元素的對齊**

[IMathArray.BaseJustification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/basejustification/) 控制陣列相對於旁邊數學元素的垂直對齊。下面的範例比較第一列、陣列中心與最後一列的對齊方式。

以下範例建立三個相同的陣列，每個都有三列，且鄰近元素為 `A=` 與 `=B`。所有數學文字使用 Cambria Math，字型大小 24 點。僅變更陣列的對齊方式。

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

以下比較顯示在 PowerPoint 中儲存的簡報。請留意每個陣列旁的 `A=` 與 `=B` 位置。

![PowerPoint 中的方程式陣列，分別以頂部、中心與底部對齊，且鄰近元素相同](equation-array-alignment.png)

### **設定列間距**

[RowSpacingRule](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacingrule/) 選取陣列內列的間距規則。[RowSpacing](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imatharray/rowspacing/) 為明確的間距規則提供數值，預設規則會忽略此設定。

若使用精確間距，值以點為單位。若使用比例間距，則以半行為單位：範例中值 `3` 代表 1.5 行。指定明確值時，請同時設定兩個屬性；僅變更數值不會選擇間距規則。

若要使用比例間距，則以半行為單位：範例中值 `3` 代表 1.5 行。指定明確值時，請同時設定兩個屬性；僅變更數值不會選擇間距規則。

以下範例儲存五個簡報，方程式、對齊與字型設定相同。前三個使用預設，最後兩個顯示明確的數值。

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

陣列列間距獨立於段落間距。[SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) 與 [SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/) 為包含段落的上下添加空間，而非陣列列之間。類似地，[IMathParagraph.Justification](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/justification/) 以水平方式定位整個數學段落；它不會取代陣列的垂直對齊設定。

## **新增三角函數**

當參數是當前元素且函數名稱已知時，使用 [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/)。

![三角函數 cos 套用於 2x](powerpoint-math-equations_6.png)

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

使用下標與上標輔助函式來處理索引與次方。若索引必須顯示在基底的左側，請使用 [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/)。

![大寫 Y，左側有下標 1 與上標 n](powerpoint-math-equations_9.png)

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

## **新增分隔符號**

使用 [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) 將表達式放入分隔符號中。對於包含多個元素的分隔符號表達式，您也可以設定分隔字元。

![包含 x、y、z 的分隔符號表達式，以垂直線分隔](powerpoint-math-equations_13.png)

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

### **調整分隔符號的大小與對齊**

將 [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) 設為 `true`，使括號可依較高的運算元伸展；設為 `false` 則維持正常大小。[DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) 取兩個 [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) 值之一。`Centered` 使括號在數學軸上置中，該軸貫穿等號的中間。`Match` 使其與所包圍的內容對齊。這兩個設定僅影響分隔符號，內部表達式保持不變。

此範例將分數置於 `x` 的指數中，使表達式在基線上方的延伸大於下方。四個方程式均使用相同的括號與字型設定。

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

在 PowerPoint 中，比較各列可觀察伸展效果。上列的括號會伸展以包住指數，兩種形狀相同。下列則關閉伸展。左側較小的括號（`Centered`）與等號對齊，而右側（`Match`）則較高地包圍表達式。

![PowerPoint 中的四個方程式，分隔符號上方啟用伸展、下方停用，左側為 Centered，右側為 Match](delimiter-sizing.png)

## **新增邊框盒子**

在分數上呼叫 [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) 可為整個表達式加上框線。回傳的 [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) 預設顯示四個側面。使用 [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/)、[HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/)、[HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/) 與 [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) 可移除個別側面。

此範例在同一張投影片上放置相同分數的六個副本。若要顯示取消效果，隱藏四個側面，並設定 [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) 形成向上斜線 (↗) 或設定 [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) 形成向下斜線 (↘)。也可使用 [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) 或 [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) 搭配任意可見的側面。

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

![PowerPoint 中的六個可編輯分數。上列：完整邊框、底部與左側、向上斜線。下列：向下斜線、水平刪除線、垂直刪除線與完整邊框。](border-box-fractions.png)

在此分數上，水平刪除線與分數線重疊。垂直刪除線同時穿過分子與分母，而周圍的邊框仍然可見。這些線條裝飾整個表達式。普通文字的刪除線僅適用於文字執行序。重新在 PowerPoint 開啟簡報後，仍可獨立編輯分子與分母。

## **分組項目**

使用 [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) 在表達式上方或下方放置分組字元。加入限制以標記分組的項目。

![表達式 x 加 y 被分組，且下方有任意文字標籤](powerpoint-math-equations_15.png)

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

僅在需要說明公式時使用格式化輔助工具。例如，[Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) 會在數學元素上方加上一條條線。

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

### **格式化現有方程式中的文字**

若要格式化現有方程式中的全部文字，必須遍歷每個數學區塊的元素樹。[IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) 僅回傳直接子項，須遞迴呼叫以取得分數、上下標、根號及其他巢狀結構中的文字。檢查當前元素與其子項，以在起始元素為 [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) 時也包含在內。

此範例假設簡報中包含諸如 `z = xᵢ / ∛y` 的方程式，該方程式的分數分子含有下標，分母含有根號。僅處理區塊的頂層元素會遺漏分數內的文字。範例在投影片文字框中查找數學段落，透過 [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) 取得其區塊，並將每個文字元素的 [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) 屬性中的 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) 設為 28 點。

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

儲存的簡報在每個已處理方程式的所有層級上皆包含更新後的文字格式，同時保留其文字內容與數學結構。

## **快速參考**

| 任務 | 主要 API |
| --- | --- |
| 建立數學文字 | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| 組合元素 | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| 建立分數 | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| 新增上標或下標 | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| 新增函數 | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| 新增根號 | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| 新增極限 | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| 新增左側標記 | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| 新增求和與積分 | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| 新增矩陣 | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| 新增方程式陣列 | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| 新增分隔符號 | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| 新增上橫線與邊框 | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| 分組項目 | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **常見問答**

**我可以編輯現有的 PowerPoint 方程式嗎？**

可以。開啟簡報，找出包含 [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) 的形狀，取得其 [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/)，然後更新該段落中的數學區塊。

**方程式會儲存為可編輯的 PowerPoint 數學嗎？**

會。將檔案儲存為 PPTX 時，Aspose.Slides 會將方程式寫入為可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

可以。從其 [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) 取得方程式的 [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/)，並呼叫 [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) 直接匯出。完整範例請參閱 [從 .NET 簡報匯出數學方程式](/slides/zh-hant/net/exporting-math-equations/#export-math-equations-to-latex)。