---
title: 在 Android 上於 PowerPoint 簡報中加入數學方程式
linktitle: PowerPoint 數學方程式
type: docs
weight: 80
url: /zh-hant/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 PowerPoint PPT 與 PPTX 中插入與編輯數學方程式，支援 OMML、格式控制，並提供清晰的 Java 程式碼範例。"
---
## **概觀**

PowerPoint 將方程式儲存為 Office Math Markup Language (OMML)。使用 Aspose.Slides for Android via Java，您可以以程式方式建立相同類型的數學內容：分數、根號、函數、極限、N 元運算子、矩陣、陣列，以及格式化的數學區塊。

在 PowerPoint 中，使用者通常從 **插入 > 方程式** 加入方程式：

![PowerPoint 插入索引標籤，已選取方程式指令](powerpoint-math-equations_1.png)

結果是在投影片上可編輯的數學文字：

![包含可編輯數學方程式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建立此數學文字：

- 數學圖形，由 [addMathShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/) 建立，是包含方程式的圖形。
- [MathPortion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathportion/) 在圖形的文字框中儲存數學內容。
- [MathParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathblock/) 物件。

以下大部分範例使用 [MathematicalText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathematicaltext/) 與 [IMathElement](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) 的串流方法，以保持程式碼簡潔易讀。

如需 MathML 匯出情境，請參閱 [Export Math Equations from Presentations on Android](/slides/zh-hant/androidjava/exporting-math-equations/)。

## **建立方程式**

此範例建立一個數學圖形並加入畢氏定理：

![c 平方等於 a 平方加 b 平方的方程式](powerpoint-math-equations_3.png)

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

{{% alert color="primary" %}}
`addMathShape` 會建立已包含數學段落的圖形。取得第一個 `MathPortion`，取得其 `MathParagraph`，並向其加入數學區塊或數學元素。
{{% /alert %}}

## **加入分數**

使用 `divide` 建立分數。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathfractiontypes/) 選擇分數樣式。

![顯示 1 除以 x 的傾斜分數](powerpoint-math-equations_4.png)

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

若要堆疊式分數，使用 `MathFractionTypes.Bar`：

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **加入根號**

使用 `radical` 建立平方根、立方根或其他根號。當前元素成為底部，參數成為指數。

![在根號符號下方有 x 的 n 次根表達式](powerpoint-math-equations_5.png)

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

使用 `asArgumentOfFunction` 或 `function` 來建立 `sin(x)`、`log(x)` 或自訂函數名稱等函數。若要建立極限，將 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathlimit/)，或使用 `setLowerLimit`。

![當 x 趨近於無限大時的極限](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若使用自訂函數名稱，將函數名稱設為當前元素：

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **加入 N 元運算子與積分**

使用 `nary` 處理求和、聯集、交集以及其他大型運算子。使用 `integral` 處理積分。兩者皆可設定上下限。

![帶有上下限的求和符號](powerpoint-math-equations_7.png)

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

N 元運算子用於可選上下限的大型運算子。`+`、`-`、`=` 等簡單運算子通常使用 `MathematicalText` 加入並串接於表達式中。

若要建立積分，使用 `integral`：

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **加入矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathmatrix/) 來處理行與列。矩陣預設不包含括號，如需括號、方括號或大括號，請自行將矩陣包起來。

![有兩列且其中一格為空的數學矩陣](powerpoint-math-equations_10.png)

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

![垂直排列的數學陣列，x 位於 y 之上](powerpoint-math-equations_11.png)

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

當參數是當前元素且已知函數名稱時，使用 `asArgumentOfFunction`。

![三角函數 cos 作用於 2x](powerpoint-math-equations_6.png)

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

使用下標與上標輔助方法處理索引與次方。若索引必須顯示在基底左側，使用 `setSubSuperscriptOnTheLeft`。

![左側帶有下標 1 與上標 n 的大寫 Y](powerpoint-math-equations_9.png)

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

使用 `enclose` 將表達式置於分隔符號內。亦可為包含多個元素的分隔符號設定分隔字元。

![包含 x、y、z 並以直線分隔的分隔符號表達式](powerpoint-math-equations_13.png)

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

## **加入邊框盒子**

當方程式本身需要被框住時，使用 `toBorderBox`。

![帶框的方程式，a 平方等於 b 平方加 c 平方](powerpoint-math-equations_12.png)

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

使用 `group` 在表達式上方或下方放置分組字元。加入上下限以為分組項目加上標籤。

![將表達式 x 加 y 加上分組字元，並在下方加上任意文字標籤](powerpoint-math-equations_15.png)

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

僅在有助於清晰表達公式時使用格式化輔助方法。例如，`overbar` 會在數學元素上方加上一條橫線。

![帶有上橫線的數學表達式 ABC](powerpoint-math-equations_14.png)

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
| 建立數學文字 | [MathematicalText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathematicaltext/) |
| 組合元素 | [IMathElement.join](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 建立分數 | [IMathElement.divide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入上標或下標 | [setSuperscript](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入函數 | [function](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入根號 | [IMathElement.radical](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入極限 | [setLowerLimit](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入左側標記 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入求和與積分 | [nary](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入矩陣 | [MathMatrix](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathmatrix/) |
| 加入方程式陣列 | [toMathArray](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入分隔符號 | [enclose](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入橫線與邊框 | [overbar](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 分組項目 | [group](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |

## **常見問題**

**我可以編輯現有的 PowerPoint 方程式嗎？**

可以。開啟簡報後，找到包含 `MathPortion` 的圖形，取得其 `MathParagraph`，即可更新該段落中的數學區塊。

**方程式會儲存為可編輯的 PowerPoint 數學嗎？**

會。將簡報儲存為 PPTX 時，Aspose.Slides 會將方程式寫入可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

Aspose.Slides 只能將數學方程式匯出為 MathML。如需 LaTeX，先匯出為 MathML，然後使用支援 LaTeX 轉換的工具將 MathML 轉換為目標 LaTeX 方言。