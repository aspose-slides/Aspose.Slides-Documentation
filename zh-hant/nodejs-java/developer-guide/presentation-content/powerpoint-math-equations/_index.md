---
title: 在 JavaScript 中為 PowerPoint 簡報新增數學方程式
linktitle: PowerPoint 數學方程式
type: docs
weight: 80
url: /zh-hant/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java，在 PowerPoint PPT 與 PPTX 中插入與編輯數學方程式，支援 OMML、格式控制，並提供清晰的 JavaScript 程式碼範例。"
---
## **概觀**

PowerPoint 以 Office Math Markup Language (OMML) 儲存方程式。使用 Aspose.Slides for Node.js via Java，您可以以程式方式建立相同類型的數學內容：分數、根號、函數、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常從 **Insert > Equation** 新增方程式：

![PowerPoint 插入標籤頁，已選取方程式指令](powerpoint-math-equations_1.png)

結果是在投影片上呈現可編輯的數學文字：

![包含可編輯數學方程式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過以下三個主要物件建立這些數學文字：

- 使用 [addMathShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/#addMathShape) 建立的數學圖形，負責容納方程式。
- [MathPortion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathportion/) 將數學內容存放於圖形的文字框中。
- [MathParagraph](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathblock/) 物件。

以下範例大多使用 [MathematicalText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathematicaltext/) 以及 [MathElementBase](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) 的流暢方法，以保持程式碼簡潔易讀。

欲了解 MathML 匯出情境，請參考 [Export Math Equations from Presentations in Node.js via Java](/slides/zh-hant/nodejs-java/exporting-math-equations/)。

## **建立方程式**

此範例建立一個數學圖形，並加入畢氏定理：

![方程式 c² = a² + b² 的圖示](powerpoint-math-equations_3.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equation = new aspose.slides.MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` 會建立已包含數學段落的圖形。存取第一個 `MathPortion`、取得其 `MathParagraph`，然後向其中新增數學區塊或數學元素。
{{% /alert %}}

## **加入分數**

使用 [`divide`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) 來建立分數。您可以透過 [MathFractionTypes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathfractiontypes/) 選擇分數樣式。

![顯示 1 除以 x 的斜分數圖示](powerpoint-math-equations_4.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let fraction = new aspose.slides.MathematicalText("1")
            .divide("x", aspose.slides.MathFractionTypes.Skewed);

    mathParagraph.add(new aspose.slides.MathBlock(fraction));

    presentation.save("fraction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

欲建立堆疊式分數，請使用 `MathFractionTypes.Bar`：

```javascript
let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **加入根號**

使用 [`radical`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) 來建立平方根、立方根或其他次方根。當前元素將成為根號底部，參數則為指數。

![帶有 x 的 n 次根號表達式圖示](powerpoint-math-equations_5.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let radical = new aspose.slides.MathematicalText("x")
            .radical("n");

    mathParagraph.add(new aspose.slides.MathBlock(radical));

    presentation.save("radical.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加入函數與極限**

使用 [`asArgumentOfFunction`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) 或 [`function`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) 來建立 `sin(x)`、`log(x)` 等函數，或自訂函數名稱。若要表示極限，請在 [MathLimit](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathlimit/) 中放入 `lim`，或使用 [`setLowerLimit`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/)。

![x 趨近於無限大的極限圖示](powerpoint-math-equations_8.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let limit = new aspose.slides.MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new aspose.slides.MathBlock(limit));

    presentation.save("functions-and-limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若要使用自訂函數名稱，只需將函數名稱設為當前元素：

```javascript
let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **加入 N 元運算子與積分符號**

使用 [`nary`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) 來建立總和、聯集、交集以及其他大型運算子。使用 [`integral`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) 來建立積分符號。這兩個方法皆可設定上下限。

![帶有上下限的總和符號圖示](powerpoint-math-equations_7.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let summationBase = new aspose.slides.MathematicalText("x")
            .setSuperscript("k")
            .join(new aspose.slides.MathematicalText("a").setSuperscript("n-k"));

    let summation = summationBase.nary(aspose.slides.MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new aspose.slides.MathBlock(summation));

    presentation.save("nary-operators.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N 元運算子用於帶有可選上下限的大型運算子。像 `+`、`-`、`=` 這類簡單運算子通常以 `MathematicalText` 形式加入，並串接至表達式。

若要建立積分，使用 `integral`：

```javascript
let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **加入矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathmatrix/) 來建立列與欄。矩陣預設不包含括號，若需要括號、方括號或大括號，請自行將矩陣包起來。

![兩列、一個空格的數學矩陣圖示](powerpoint-math-equations_10.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let matrix = new aspose.slides.MathMatrix(2, 3);
    matrix.set_Item(0, 0, new aspose.slides.MathematicalText("1"));
    matrix.set_Item(0, 1, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 0, new aspose.slides.MathematicalText("x"));
    matrix.set_Item(1, 1, new aspose.slides.MathematicalText("2"));
    matrix.set_Item(1, 2, new aspose.slides.MathematicalText("y"));

    mathParagraph.add(new aspose.slides.MathBlock(matrix));

    presentation.save("matrix.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加入方程式陣列**

當需要對齊的方程式或垂直堆疊的表達式時，使用 [`toMathArray`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/)。

![x 在上、y 在下的垂直數學陣列圖示](powerpoint-math-equations_11.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let equationArray = new aspose.slides.MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new aspose.slides.MathBlock(equationArray));

    presentation.save("equation-array.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加入三角函數**

當參數是當前元素且函數名稱已知時，使用 [`asArgumentOfFunction`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/)。

![cos 作用於 2x 的三角函數圖示](powerpoint-math-equations_6.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let cosine = new aspose.slides.MathematicalText("2x")
            .asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new aspose.slides.MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加入下標與上標**

使用下標與上標輔助方法處理索引與冪次。若索引須出現在基底的左側，請使用 [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/)。

![左側下標 1、上標 n 的大寫 Y 圖示](powerpoint-math-equations_9.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let scripts = new aspose.slides.MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new aspose.slides.MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加入分界符號**

使用 [`enclose`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) 將表達式放入分界符號內。若分界符號內包含多個元素，還可以設定分隔字元。

![以垂直線分隔 x、y、z 的分界符號表達式圖示](powerpoint-math-equations_13.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let delimiter = new aspose.slides.MathematicalText("x")
            .join("y")
            .join("z")
            .enclose(java.newChar('<'), java.newChar('>'));
    delimiter.setSeparatorCharacter(java.newChar('|'));

    mathParagraph.add(new aspose.slides.MathBlock(delimiter));

    presentation.save("delimiters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加入邊框盒**

當方程式本身需要被框住時，使用 [`toBorderBox`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/)。

![顯示 a² = b² + c² 的盒狀方程式圖示](powerpoint-math-equations_12.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let boxedEquation = new aspose.slides.MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new aspose.slides.MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new aspose.slides.MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new aspose.slides.MathBlock(boxedEquation));

    presentation.save("border-box.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **分組項目**

使用 [`group`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) 在表達式上方或下方放置分組符號。可加入上下限以標註分組的項目。

![將 x + y 以「任意文字」標註於下方的分組表達式圖示](powerpoint-math-equations_15.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let grouped = new aspose.slides.MathematicalText("x + y")
            .group(java.newChar('\u23DF'), aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new aspose.slides.MathBlock(grouped));

    presentation.save("grouped-terms.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **格式化數學元素**

僅在有助於說明公式時使用格式化輔助方法。例如，[`overbar`](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) 會在數學元素上方加上一條橫線。

![帶有上橫線的數學表達式 ABC 圖示](powerpoint-math-equations_14.png)

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    let mathParagraph = mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0).getMathParagraph();

    let overbar = new aspose.slides.MathematicalText("ABC").overbar();

    mathParagraph.add(new aspose.slides.MathBlock(overbar));

    presentation.save("overbar.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **快速參考**

| 任務 | 主要 API |
| --- | --- |
| 建立數學文字 | [MathematicalText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathematicaltext/) |
| 組合元素 | [join](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) |
| 建立分數 | [divide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) |
| 加入上標或下標 | [setSuperscript](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) |
| 加入函數 | [function](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) |
| 加入根號 | [radical](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) |
| 加入極限 | [setLowerLimit](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) |
| 加入左側上下標 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) |
| 加入總和與積分 | [nary](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) |
| 加入矩陣 | [MathMatrix](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathmatrix/) |
| 加入方程式陣列 | [toMathArray](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) |
| 加入分界符號 | [enclose](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) |
| 加入橫線與框線 | [overbar](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) |
| 分組項目 | [group](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/mathelementbase/) |

## **常見問題**

**我可以編輯既有的 PowerPoint 方程式嗎？**

可以。開啟簡報，找到含有 `MathPortion` 的圖形，取得其 `MathParagraph`，然後更新該段落中的數學區塊。

**方程式會以可編輯的 PowerPoint 數學形式儲存嗎？**

會。儲存為 PPTX 時，Aspose.Slides 會將方程式寫入可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

Aspose.Slides 會將數學方程式匯出為 MathML。若需要 LaTeX，請先匯出為 MathML，然後使用支援目標 LaTeX 方言的工具將 MathML 轉換為 LaTeX。