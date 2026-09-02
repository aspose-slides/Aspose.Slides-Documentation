---
title: 在 Java 中向 PowerPoint 簡報新增數學方程式
linktitle: PowerPoint 數學方程式
type: docs
weight: 80
url: /zh-hant/java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint PPT 與 PPTX 中插入與編輯數學方程式，支援 OMML、格式控制，並提供清晰的 Java 程式碼範例。"
---
## **概述**

PowerPoint 以 Office Math Markup Language (OMML) 儲存方程式。使用 Aspose.Slides for Java，您可以以程式方式建立相同類型的數學內容：分數、根號、函數、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常透過 **Insert > Equation** 新增方程式：

![PowerPoint 插入標籤，已選取 Equation 指令](powerpoint-math-equations_1.png)

結果是投影片上可編輯的數學文字：

![包含可編輯數學方程式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過下列三個主要物件建構此數學文字：

- 以 [addMathShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) 建立的數學形狀，該形狀內含方程式。
- [MathPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathportion/) 用於在形狀的文字框中儲存數學內容。
- [MathParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathblock/) 物件。

以下大多數範例使用 [MathematicalText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathematicaltext/) 以及 [IMathElement](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/) 的串接方法，以保持程式碼簡潔且易讀。

欲了解 MathML 匯出情境，請參閱 [Export Math Equations from Presentations in Java](/slides/zh-hant/java/exporting-math-equations/)。

## **建立方程式**

此範例建立一個數學形狀並加入畢氏定理：

![方程式 c² = a² + b² 的圖示](powerpoint-math-equations_3.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary"%}}
`addMathShape` 會建立已包含數學段落的形狀。存取第一個 `MathPortion`，取得其 `MathParagraph`，然後向其中加入數學區塊或數學元素。
{{% /alert %}}

## **加入分數**

使用 `divide` 建立分數。您可以透過 [MathFractionTypes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathfractiontypes/) 選擇分數樣式。

![顯示 1 除以 x 的斜置分數圖示](powerpoint-math-equations_4.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若要堆疊分數，使用 `MathFractionTypes.Bar`：

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **加入根號**

使用 `radical` 建立平方根、立方根或其他根號。當前元素成為底，參數則為指數。

![帶有根號符號且根號下方為 x 的 n 次根圖示](powerpoint-math-equations_5.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加入函數與極限**

使用 `asArgumentOfFunction` 或 `function` 來建立 `sin(x)`、`log(x)` 或自訂函數名稱。若要表示極限，將 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathlimit/) 或使用 `setLowerLimit`。

![當 x 趨近於無限大時的極限圖示](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若要使用自訂函數名稱，將函數名稱設為當前元素：

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **加入 N 元運算子與積分**

使用 `nary` 來表示求和、聯集、交集及其他大型運算子。使用 `integral` 來表示積分。兩者皆可設定上下限。

![帶有上下限的求和符號圖示](powerpoint-math-equations_7.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N 元運算子適用於帶有可選上下限的大型運算子。像 `+`、`-`、`=` 等簡單運算子通常以 `MathematicalText` 方式加入，並直接串接於表達式中。

若要加入積分，使用 `integral`：

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **加入矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathmatrix/) 來建立列與欄。矩陣預設不包含括號，若需要括號、方框或大括號，請自行將矩陣包圍起來。

![含有一個空格的兩列矩陣圖示](powerpoint-math-equations_10.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加入方程式陣列**

需要對齊的方程式或垂直堆疊的表達式時，使用 `toMathArray`。

![垂直排列，x 在上方、y 在下方的數學陣列圖示](powerpoint-math-equations_11.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加入三角函數**

當參數為當前元素且函數名稱已知時，使用 `asArgumentOfFunction`。

![三角函數 cos 作用於 2x 的圖示](powerpoint-math-equations_6.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加入下標與上標**

使用下標與上標輔助工具來表示索引與次方。若索引必須出現在基底左側，使用 `setSubSuperscriptOnTheLeft`。

![左側下標 1、右側上標 n 的大寫 Y 圖示](powerpoint-math-equations_9.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加入分隔符號**

使用 `enclose` 將表達式包於分隔符號內。亦可設定分隔字元，以在包含多個元素的分隔符號表達式中使用。

![以垂直條分隔的 x、y、z 分隔符號表達式圖示](powerpoint-math-equations_13.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加入外框盒**

若整個方程式需要被框住，使用 `toBorderBox`。

![帶有方框的方程式 a² = b² + c² 圖示](powerpoint-math-equations_12.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **分組項目**

使用 `group` 在表達式上方或下方放置分組字元。加入上下限以標註分組的項目。

![帶有「任意文字」標籤的 x 加 y 之分組圖示](powerpoint-math-equations_15.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **格式化數學元素**

僅在能提升公式可讀性時使用格式化輔助工具。例如，`overbar` 會在數學元素上方加上一條橫線。

![帶有上橫線的數學表達式 ABC 圖示](powerpoint-math-equations_14.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **快速參考**

| 任務 | 主要 API |
| --- | --- |
| 建立數學文字 | [MathematicalText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathematicaltext/) |
| 結合元素 | [IMathElement.join](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| 建立分數 | [IMathElement.divide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| 加入上標或下標 | [setSuperscript](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| 加入函數 | [function](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| 加入根號 | [IMathElement.radical](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| 加入極限 | [setLowerLimit](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| 加入左側標記 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| 加入求和與積分 | [nary](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| 加入矩陣 | [MathMatrix](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathmatrix/) |
| 加入方程式陣列 | [toMathArray](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#toMathArray--) |
| 加入分隔符號 | [enclose](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| 加入橫線與外框 | [overbar](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#toBorderBox--) |
| 分組項目 | [group](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **常見問題**

**我可以編輯已存在的 PowerPoint 方程式嗎？**

可以。開啟投影片，找到包含 `MathPortion` 的形狀，取得其 `MathParagraph`，然後更新該段落中的數學區塊。

**方程式會儲存為可編輯的 PowerPoint 數學嗎？**

會。當您儲存為 PPTX 時，Aspose.Slides 會將方程式寫入為可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

可以。從其 [IMathPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathportion/) 取得方程式的 [IMathParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathparagraph/)，然後呼叫 [IMathParagraph.toLatex](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathparagraph/#toLatex--) 直接匯出。完整範例請參閱 [Export Math Equations from Presentations in Java](/slides/zh-hant/java/exporting-math-equations/#export-math-equations-to-latex)。