---
title: 在 .NET 中將數學公式新增至 PowerPoint 簡報
linktitle: PowerPoint 數學公式
type: docs
weight: 80
url: /zh-hant/net/powerpoint-math-equations/
keywords:
- 數學公式
- 數學符號
- 數學式
- 數學文字
- 新增數學公式
- 新增數學符號
- 新增數學式
- 新增數學文字
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint PPT 與 PPTX 中插入與編輯數學公式，支援 OMML、格式控制，並提供清晰的 C# 程式碼範例。"
---
## **概述**

PowerPoint 將公式儲存為 Office Math Markup Language (OMML)。使用 Aspose.Slides for .NET，您可以以程式方式建立相同類型的數學內容：分數、根號、函數、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常透過 **插入 > 公式** 來新增公式：

![PowerPoint 插入標籤頁上已選取公式指令的畫面](powerpoint-math-equations_1.png)

結果是在投影片上呈現可編輯的數學文字：

![包含可編輯數學公式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建立此數學文字：

- 一個數學形狀，由 [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) 建立，用於容納公式的形狀。
- [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) 在形狀的文字框內儲存數學內容。
- [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/) 物件。

以下大多數範例使用 [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) 與 [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/) 的串接方法，以保持程式碼簡潔易讀。

如需 MathML 匯出情境，請參考 [從簡報匯出數學公式 (.NET)](/slides/zh-hant/net/exporting-math-equations/)。

## **建立公式**

此範例使用 [AddMathShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) 來建立數學形狀，並加入畢氏定理：

![c 平方等於 a 平方加 b 平方的公式](powerpoint-math-equations_3.png)

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
[*AddMathShape*](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addmathshape/) 會建立已包含數學段落的形狀。存取第一個 [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)，取得其 [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/)，並向其添加數學區塊或數學元素。
{{% /alert %}}

## **加入分數**

使用 [Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) 建立分數。您可以透過 [MathFractionTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/) 選擇分數樣式。

![呈現 1 除以 x 的傾斜分數](powerpoint-math-equations_4.png)

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

若要使用堆疊式分數，請利用 [MathFractionTypes.Bar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfractiontypes/):

```csharp
using Aspose.Slides.MathText;

var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **加入根號**

使用 [Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) 可建立平方根、立方根或其他次根。當前元素會成為底數，參數則為根次。

![一個 n 次根號，其根號下方為 x](powerpoint-math-equations_5.png)

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

## **加入函數與極限**

使用 [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) 或 [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/) 來處理如 `sin(x)`、`log(x)` 或自訂函數名稱等函數。若要表示極限，將 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit/) 或使用 [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/)。

![當 x 趨近於無限大時的極限](powerpoint-math-equations_8.png)

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

若要使用自訂函數名稱，將函數名稱設定為當前元素，然後以其參數呼叫 [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/)：

```csharp
using Aspose.Slides.MathText;

var customFunction = new MathematicalText("f").Function("x + 1");
```

## **加入 N 元運算子與積分**

使用 [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/) 來處理求和、聯集、交集以及其他大型運算子。使用 [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) 來表示積分。兩者皆可設定上下限。

![具有上下限的求和運算](powerpoint-math-equations_7.png)

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

N 元運算子用於可選上下限的大型運算子。像 `+`、`-`、`=` 這類簡單運算子通常以 [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) 加入並串接至表達式中。

若要表示積分，請使用 [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/)：

```csharp
using Aspose.Slides.MathText;

var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **加入矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) 以定義行與列。矩陣預設不包含括號，因此在需要括號、方括號或大括號時，請自行將矩陣包起來。

![具有兩列且有一個空格的數學矩陣](powerpoint-math-equations_10.png)

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

## **加入方程式陣列**

當需要對齊的方程式或垂直堆疊的表達式時，使用 [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/)。

![垂直排列的數學陣列，x 位於 y 之上](powerpoint-math-equations_11.png)

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

## **加入三角函數**

當參數為當前元素且函數名稱已知時，使用 [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/)。

![將三角函數 cos 套用於 2x](powerpoint-math-equations_6.png)

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

## **加入下標與上標**

使用下標與上標輔助方法來設定指數與次方。若指標需顯示在基底左側，請使用 [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/)。

![大寫 Y 左側帶有下標 1 以及上標 n](powerpoint-math-equations_9.png)

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

## **加入分界符號**

使用 [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) 可將表達式置於分界符號內。對於包含多個元素的分界符號表達式，亦可設定分隔字元。

![以直線分隔 x、y、z 的分界符號表達式](powerpoint-math-equations_13.png)

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

### **大小與對齊分界符號**

將 [GrowToMatchOperandHeight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/growtomatchoperandheight/) 設為 `true`，即可讓括號依高大的運算元自動增大；設為 `false` 則保持原始大小。[DelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter/delimitershape/) 接受兩種 [MathDelimiterShape](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimitershape/) 值之一。`Centered` 使括號置於數學軸的中間（即等號的中線）; `Match` 則與內部內容對齊。這兩種設定僅影響括號本身，內部表達式保持不變。

將分數放置於 `x` 的指數位置，使得表達式在基線之上延伸較多。四組公式皆使用相同的括號與字型設定。

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

在 PowerPoint 中，可比較各列以觀察增長效果。上列的括號會隨指數而增大，兩個形狀看起來相同；下列則關閉增長。左側較小的括號（`Centered`）與等號對齊，而右側（`Match`）則在表達式上方位置較高。

![PowerPoint 中四個公式，左側括號啟用增長且居中，右側括號關閉增長且匹配](delimiter-sizing.png)

## **加入邊框盒**

對分數呼叫 [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) 可為整個表達式加上框線。返回的 [IMathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/) 預設顯示四側。使用 [HideTop](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidetop/)、[HideBottom](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hidebottom/)、[HideLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideleft/)，以及 [HideRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/hideright/) 可隱藏個別側邊。

此範例在同一投影片上放置六個相同的分數。為了顯示刪除效果，先隱藏四側，接著設定 [StrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughbottomlefttotopright/) 產生向上對角線 (↗) 或 [StrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughtoplefttobottomright/) 產生向下對角線 (↘)。亦可使用 [StrikethroughHorizontal](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughhorizontal/) 或 [StrikethroughVertical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathborderbox/strikethroughvertical/) 並搭配任意可見的側邊。

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

![PowerPoint 中六個可編輯的分數。上列：完整邊框、底部與左側、向上對角線。下列：向下對角線、水平刪除線、垂直刪除線並附完整邊框。](border-box-fractions.png)

在此分數中，水平刪除線會與分數線重疊。垂直刪除線則穿過分子與分母，而外圍邊框仍保持可見。這些線條裝飾整個表達式。普通的文字刪除線僅作用於文字執行的字元。重新於 PowerPoint 開啟簡報後，仍可分別編輯分子與分母。

## **分組項目**

使用 [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) 可將分組符號置於表達式之上或之下，且可加入限制以為分組項目加上標籤。

![將 x 加 y 的表達式分組，且在其下方加入任意文字標籤](powerpoint-math-equations_15.png)

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

僅在有助於說明公式時才使用格式化輔助功能。例如，[Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/) 會在數學元素上方加入橫線。

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

### **格式化現有公式中的文字**

若要在既有公式中格式化文字，需遍歷每個數學區塊的元素樹。[IMathElement.GetChildren](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/getchildren/) 僅返回直接子項，必須遞迴呼叫以取得分數、上下標、根號及其他巢狀結構內的文字。也要檢查當前元素及其子項，以在其為 [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) 時包含起始元素。

此範例假設簡報中含有如 `z = xᵢ / ∛y` 的公式，分數的分子含有下標，分母含有根號。僅處理區塊的頂層元素會遺漏分數內的文字。該範例在投影片文字框中尋找數學段落，透過 [IMathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathportion/mathparagraph/) 取得其區塊，並將每個文字元素的 [Format](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/format/) 屬性中的 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) 設為 28 點。

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

儲存後的簡報在每個已處理公式的各層級皆套用更新的文字格式，且保留其文字內容與數學結構。

## **快速參考**

| 任務 | 主要 API |
| --- | --- |
| 建立數學文字 | [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext/) |
| 結合元素 | [IMathElement.Join](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/join/) |
| 建立分數 | [IMathElement.Divide](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/divide/) |
| 新增上標或下標 | [SetSuperscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| 新增函數 | [Function](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| 新增根號 | [IMathElement.Radical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/radical/) |
| 新增極限 | [SetLowerLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| 新增左側上下標 | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| 新增求和與積分 | [Nary](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/) |
| 新增矩陣 | [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix/) |
| 新增方程式陣列 | [ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| 新增分界符號 | [Enclose](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/enclose/) |
| 新增橫線與邊框 | [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| 分組項目 | [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/group/) |

## **常見問題**

**我可以編輯現有的 PowerPoint 公式嗎？**

可以。開啟簡報，找到包含 [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) 的形狀，取得其 [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/)，然後更新該段落中的數學區塊。

**公式會儲存為可編輯的 PowerPoint 數學嗎？**

可以。當您儲存為 PPTX 時，Aspose.Slides 會將公式寫入可編輯的 Office 數學內容。

**我可以將公式匯出為 LaTeX 嗎？**

可以。從其 [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) 取得公式的 [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/)，然後呼叫 [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/) 直接匯出。完整範例請參考 [從簡報匯出數學公式 (.NET)](/slides/zh-hant/net/exporting-math-equations/#export-math-equations-to-latex)。