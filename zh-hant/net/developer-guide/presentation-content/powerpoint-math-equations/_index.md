---
title: 在 .NET 中為 PowerPoint 簡報新增數學方程式
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
description: "使用 Aspose.Slides for .NET 在 PowerPoint PPT 和 PPTX 中插入與編輯數學方程式，支援 OMML、格式控制，並提供清晰的 C# 程式碼範例。"
---
## **概觀**

PowerPoint 以 Office Math Markup Language (OMML) 儲存方程式。使用 Aspose.Slides for .NET，您可以以程式方式建立相同類型的數學內容：分數、根號、函式、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常透過 **Insert > Equation** 新增方程式：

![PowerPoint 插入索引表，已選取方程式指令](powerpoint-math-equations_1.png)

結果是在投影片上可編輯的數學文字：

![包含可編輯數學方程式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建立該數學文字：

- 使用 [AddMathShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addmathshape/) 建立的數學圖形，是包含方程式的圖形。
- [MathPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathportion/) 在圖形文字框中儲存數學內容。
- [MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathblock/) 物件。

以下大多數範例使用 [MathematicalText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathematicaltext/) 與來自 [IMathElement](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/) 的流暢方法，以保持程式碼簡潔易讀。

如需 MathML 匯出情境，請參閱 [Export Math Equations from Presentations in .NET](/slides/zh-hant/net/exporting-math-equations/)。

## **建立方程式**

此範例建立一個數學圖形並加入畢氏定理：

![c 平方等於 a 平方加 b 平方 的方程式](powerpoint-math-equations_3.png)

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
`AddMathShape` 會建立已包含數學段落的圖形。存取第一個 `MathPortion`，取得其 `MathParagraph`，並向其中加入數學區塊或數學元素。
{{% /alert %}}

## **新增分數**

使用 `Divide` 建立分數。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathfractiontypes/) 選擇分數樣式。

![顯示 1 除以 x 的傾斜分數](powerpoint-math-equations_4.png)

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

若需堆疊式分數，請使用 `MathFractionTypes.Bar`：

```csharp
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **新增根號**

使用 `Radical` 建立平方根、立方根或其他次方根。當前元素成為底部，參數則成為指數。

![一個 n 次根號，x 位於根號之下的表達式](powerpoint-math-equations_5.png)

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

## **新增函式與極限**

使用 `AsArgumentOfFunction` 或 `Function` 以建立函式，例如 `sin(x)`、`log(x)` 或自訂函式名稱。若要表示極限，將 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathlimit/) ，或使用 `SetLowerLimit`。

![x 趨近於無限大的極限](powerpoint-math-equations_8.png)

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

若使用自訂函式名稱，將函式名稱設為當前元素：

```csharp
var customFunction = new MathematicalText("f").Function("x + 1");
```

## **新增 N 元運算子與積分**

使用 `Nary` 來表示求和、聯集、交集及其他大型運算子。使用 `Integral` 來表示積分。這兩種方法皆可設定上下限。

![帶有上下限的求和符號](powerpoint-math-equations_7.png)

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

N 元運算子用於帶有可選上下限的大型運算子。像 `+`、`-`、`=` 等簡單運算子通常以 `MathematicalText` 加入並組合成表達式。

對於積分，使用 `Integral`：

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **新增矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathmatrix/) 來建立列與行。矩陣預設不包含括號，若需要圓括號、方括號或大括號，請自行將矩陣包起來。

![具有兩列且有一個空儲存格的數學矩陣](powerpoint-math-equations_10.png)

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

## **新增方程式陣列**

當需要對齊的方程式或垂直堆疊的表達式時，使用 `ToMathArray`。

![垂直數學陣列，x 位於 y 之上](powerpoint-math-equations_11.png)

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

## **新增三角函式**

當參數是當前元素且函式名稱已知時，使用 `AsArgumentOfFunction`。

![三角函式 cos 作用於 2x](powerpoint-math-equations_6.png)

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

## **新增下標與上標**

使用下標與上標輔助工具來處理索引與次方。若索引需顯示在基底的左側，請使用 `SetSubSuperscriptOnTheLeft`。

![左側有下標 1 及上標 n 的大寫 Y](powerpoint-math-equations_9.png)

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

## **新增分隔符號**

使用 `Enclose` 將表達式置於分隔符號內。若分隔符號表達式包含多個元素，亦可設定分隔字元。

![包含 x、y、z 並由直線分隔的分隔符號表達式](powerpoint-math-equations_13.png)

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

## **新增框線盒子**

當方程式本身需要加上框線時，使用 `ToBorderBox`。

![包含 a 平方等於 b 平方加 c 平方 的框線方程式](powerpoint-math-equations_12.png)

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

## **分組項目**

使用 `Group` 在表達式上方或下方放置分組字元。加入限制以標記分組的項目。

![將 x 加 y 分組，並在下方加上任意文字標籤的表達式](powerpoint-math-equations_15.png)

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

## **格式化數學元素**

僅在能說明公式時使用格式化輔助工具。例如，`Overbar` 會在數學元素上方加上一條橫線。

![帶有上橫線的數學表達式 ABC](powerpoint-math-equations_14.png)

```csharp
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(20, 20, 700, 100);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

var overbar = new MathematicalText("ABC").Overbar();

mathParagraph.Add(new MathBlock(overbar));

presentation.Save("overbar.pptx", SaveFormat.Pptx);
```

## **快速參考**

| 任務 | 主要 API |
| --- | --- |
| 建立數學文字 | [MathematicalText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathematicaltext/) |
| 合併元素 | [IMathElement.Join](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/join/) |
| 建立分數 | [IMathElement.Divide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/divide/) |
| 加入上標或下標 | [SetSuperscript](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/setsubscript/) |
| 加入函式 | [Function](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| 加入根號 | [IMathElement.Radical](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/radical/) |
| 加入極限 | [SetLowerLimit](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/setupperlimit/) |
| 加入左側腳本 | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| 加入求和與積分 | [Nary](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/integral/) |
| 加入矩陣 | [MathMatrix](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathmatrix/) |
| 加入方程式陣列 | [ToMathArray](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/tomatharray/) |
| 加入分隔符號 | [Enclose](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/enclose/) |
| 加入橫線與框線 | [Overbar](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| 分組項目 | [Group](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/group/) |

## **常見問題**

**我可以編輯現有的 PowerPoint 方程式嗎？**

是的。開啟簡報，找到包含 `MathPortion` 的圖形，取得其 `MathParagraph`，並更新該段落中的數學區塊。

**方程式會儲存為可編輯的 PowerPoint 數學嗎？**

是的。當您儲存為 PPTX 時，Aspose.Slides 會將方程式寫入為可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

是的。從其 [MathPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathportion/) 取得方程式的 [IMathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathparagraph/)，然後呼叫 [IMathParagraph.ToLatex](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathparagraph/tolatex/) 直接匯出。完整範例請參見 [Export Math Equations from Presentations in .NET](/slides/zh-hant/net/exporting-math-equations/#export-math-equations-to-latex)。