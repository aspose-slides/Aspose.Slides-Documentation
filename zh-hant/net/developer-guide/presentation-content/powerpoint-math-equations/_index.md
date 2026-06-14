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
description: "使用 Aspose.Slides for .NET 在 PowerPoint PPT 與 PPTX 中插入與編輯數學方程式，支援 OMML、格式控制，並提供清晰的 C# 程式碼範例。"
---
## **概觀**

PowerPoint 以 Office Math Markup Language (OMML) 儲存方程式。使用 Aspose.Slides for .NET，您可以以程式方式建立相同類型的數學內容：分數、根號、函式、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常從 **插入 > 方程式** 加入方程式：

![PowerPoint 插入標籤，已選取方程式指令](powerpoint-math-equations_1.png)

結果是在投影片上可編輯的數學文字：

![包含可編輯數學方程式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建立該數學文字：

- 數學形狀，由 [AddMathShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addmathshape/) 建立，是包含方程式的形狀。
- [MathPortion](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathportion/) 在形狀的文字框內儲存數學內容。
- [MathParagraph](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathblock/) 物件。

大部分以下範例使用 [MathematicalText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathematicaltext/) 與來自 [IMathElement](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/) 的串流方法，以保持程式碼簡潔易讀。

欲了解 MathML 匯出情境，請參閱 [從簡報匯出數學方程式 (.NET)](/slides/zh-hant/net/exporting-math-equations/)。

## **建立方程式**

此範例建立一個數學形狀並加入畢氏定理：

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
`AddMathShape` 會建立一個已包含數學段落的形狀。取得第一個 `MathPortion`、取得其 `MathParagraph`，並向其中加入數學區塊或數學元素。
{{% /alert %}}

## **新增分數**

使用 `Divide` 建立分數。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathfractiontypes/) 選擇分數樣式。

![顯示 1 除以 x 的傾斜數學分數](powerpoint-math-equations_4.png)

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

若要堆疊式分數，使用 `MathFractionTypes.Bar`：

```csharp
var stackedFraction = new MathematicalText("x + 1").Divide("y - 1", MathFractionTypes.Bar);
```

## **新增根號**

使用 `Radical` 建立平方根、立方根或其他根號。當前元素成為底數，參數成為次方。

![n 次根號表達式，x 位於根號符號下方](powerpoint-math-equations_5.png)

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

使用 `AsArgumentOfFunction` 或 `Function` 來建立如 `sin(x)`、`log(x)` 或自訂函式名稱的函式。對於極限，將 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathlimit/) 或使用 `SetLowerLimit`。

![當 x 趨近無限大時的極限](powerpoint-math-equations_8.png)

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

使用 `Nary` 來建立求和、聯集、交集等大型運算子。使用 `Integral` 來建立積分。兩種方法都可以設定上下限。

![具有上下限的求和](powerpoint-math-equations_7.png)

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

N 元運算子適用於可選上下限的大型運算子。像 `+`、`-`、`=` 等簡單運算子通常以 `MathematicalText` 加入並組合成表達式。

若要建立積分，使用 `Integral`：

```csharp
var integralBase = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
var integral = integralBase.Integral(MathIntegralTypes.Simple, "0", "1");
```

## **新增矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/mathmatrix/) 來建立列與欄。矩陣預設不含括號，若需要括號、方括號或大括號，請自行包住矩陣。

![兩列的數學矩陣，其中有一個空儲存格](powerpoint-math-equations_10.png)

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

需要對齊的方程式或垂直堆疊的表達式時，使用 `ToMathArray`。

![垂直排列的數學陣列，x 在 y 之上](powerpoint-math-equations_11.png)

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

![將三角函式 cos 應用於 2x](powerpoint-math-equations_6.png)

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

使用下標與上標輔助方法來處理索引與次方。若索引必須出現在底部的左側，使用 `SetSubSuperscriptOnTheLeft`。

![大寫 Y，左側有下標 1 及上標 n](powerpoint-math-equations_9.png)

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

## **新增分隔符**

使用 `Enclose` 將表達式置於分隔符內。若分隔符表達式包含多個元素，亦可設定分隔字元。

![包含 x、y、z 並以直線分隔的分隔符表達式](powerpoint-math-equations_13.png)

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

## **新增框線框**

當方程式本身需要被框住時，使用 `ToBorderBox`。

![一個加框的方程式，a 平方等於 b 平方加 c 平方](powerpoint-math-equations_12.png)

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

使用 `Group` 將分組字符放在表達式上方或下方。加入上下限以標示分組的項目。

![將表達式 x 加 y 以分組字符包住，且在下方加上任意文字標籤](powerpoint-math-equations_15.png)

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

僅在有助於說明公式時使用格式化輔助方法。例如，`Overbar` 會在數學元素上方加一條橫線。

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
| 加入分隔符 | [Enclose](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/enclose/) |
| 加入上橫線與框線 | [Overbar](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/toborderbox/) |
| 分組項目 | [Group](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.mathtext/imathelement/group/) |

## **常見問題**

**我可以編輯現有的 PowerPoint 方程式嗎？**

是的。開啟簡報，找到包含 `MathPortion` 的形狀，取得其 `MathParagraph`，並在該段落中更新數學區塊。

**方程式是否儲存為可編輯的 PowerPoint 數學內容？**

是的。儲存為 PPTX 時，Aspose.Slides 會將方程式寫入為可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

Aspose.Slides 會將數學方程式匯出為 MathML。若需要 LaTeX，請先匯出為 MathML，然後使用支援目標 LaTeX 方言的工具將 MathML 轉換為 LaTeX。