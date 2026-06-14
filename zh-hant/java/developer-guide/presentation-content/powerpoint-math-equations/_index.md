---
title: 在 Java 中為 PowerPoint 簡報新增數學方程式
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

PowerPoint 將方程式儲存為 Office Math Markup Language（OMML）。使用 Aspose.Slides for Java，您可以以程式方式建立相同類型的數學內容：分數、根號、函數、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常透過 **Insert > Equation** 新增方程式：

![PowerPoint 插入標籤已選取方程式指令](powerpoint-math-equations_1.png)

結果是在投影片上顯示可編輯的數學文字：

![包含可編輯數學方程式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建立此數學文字：

- 數學形狀，使用 [addMathShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) 建立，為包含方程式的形狀。
- [MathPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathportion/) 在形狀的文字框內儲存數學內容。
- [MathParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathblock/) 物件。

以下大多數範例使用 [MathematicalText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathematicaltext/) 與 [IMathElement](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/) 的流式方法，以保持程式碼簡潔且易讀。

如需 MathML 匯出情況，請參閱 [Export Math Equations from Presentations in Java](/slides/zh-hant/java/exporting-math-equations/)。

## **建立方程式**

此範例建立一個數學形狀並加入畢氏定理：

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
`addMathShape` 會建立一個已包含數學段落的形狀。存取第一個 `MathPortion`，取得其 `MathParagraph`，並向其新增數學區塊或數學元素。
{{% /alert %}}

## **新增分數**

使用 `divide` 來建立分數。您可以透過 [MathFractionTypes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathfractiontypes/) 選擇分數樣式。

![斜斜的數學分數，顯示 1 除以 x](powerpoint-math-equations_4.png)

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

## **新增根號**

使用 `radical` 建立平方根、立方根或其他根號。當前元素成為根號底數，參數則為次方。

![第 n 次根號表達式，x 位於根號符號下方](powerpoint-math-equations_5.png)

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

## **新增函數與極限**

使用 `asArgumentOfFunction` 或 `function` 來表示函數，例如 `sin(x)`、`log(x)`，或自訂函數名稱。對於極限，將 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathlimit/) 或使用 `setLowerLimit`。

![x 趨近於無限大時的極限](powerpoint-math-equations_8.png)

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

若使用自訂函數名稱，將函數名稱設為當前元素：

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **新增 N 元運算子與積分**

使用 `nary` 來表示總和、聯集、交集以及其他大型運算子。使用 `integral` 來表示積分。兩種方法皆可設定上下界限。

![帶有上下限的總和符號](powerpoint-math-equations_7.png)

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

N 元運算子用於具有可選上下限的大型運算子。像 `+`、`-`、`=` 這樣的簡單運算子通常以 `MathematicalText` 形式加入並串接於表達式中。

若要表示積分，使用 `integral`：

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **新增矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathmatrix/) 來建立列與欄。矩陣預設不包含括號，如需圓括號、方括號或大括號，須自行將矩陣包起來。

![兩列的數學矩陣，其中一格為空白](powerpoint-math-equations_10.png)

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

## **新增方程式陣列**

當需要對齊的方程式或垂直堆疊的表達式時，使用 `toMathArray`。

![垂直的數學陣列，x 在 y 之上](powerpoint-math-equations_11.png)

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

## **新增三角函數**

當參數為當前元素且函數名稱已知時，使用 `asArgumentOfFunction`。

![三角函數 cos 套用於 2x](powerpoint-math-equations_6.png)

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

## **新增下標與上標**

使用下標與上標輔助函式來處理索引與次方。若索引需顯示在基底的左側，請使用 `setSubSuperscriptOnTheLeft`。

![大寫 Y，左側下標 1 及上標 n](powerpoint-math-equations_9.png)

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

## **新增分界符**

使用 `enclose` 將表達式置於分界符內。對於包含多個元素的分界符表達式，亦可設定分隔符號。

![包含 x、y、z，且以直欄分隔的分界符表達式](powerpoint-math-equations_13.png)

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

## **新增邊框盒**

當方程式本身需要加框時，使用 `toBorderBox`。

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

使用 `group` 在表達式上方或下方放置分組符號。加入上下限以標記分組的項目。

![表達式 x 加 y 之上有分組符號，且下方標示任意文字](powerpoint-math-equations_15.png)

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

僅在能提升公式可讀性時使用格式化輔助函式。例如，`overbar` 會在數學元素上方加上一條橫線。

![帶上橫線的數學表達式 ABC](powerpoint-math-equations_14.png)

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
| 合併元素 | [IMathElement.join](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| 建立分數 | [IMathElement.divide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| 新增上標或下標 | [setSuperscript](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| 新增函數 | [function](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| 新增根號 | [IMathElement.radical](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| 新增極限 | [setLowerLimit](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| 新增左側上下標 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| 新增總和與積分 | [nary](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| 新增矩陣 | [MathMatrix](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/mathmatrix/) |
| 新增方程式陣列 | [toMathArray](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#toMathArray--) |
| 新增分界符 | [enclose](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| 新增橫線與邊框 | [overbar](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#toBorderBox--) |
| 分組項目 | [group](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **常見問題**

**我可以編輯現有的 PowerPoint 方程式嗎？**

是的。開啟簡報，尋找包含 `MathPortion` 的形狀，取得其 `MathParagraph`，並在該段落中更新數學區塊。

**方程式是否儲存為可編輯的 PowerPoint 數學內容？**

是的。儲存為 PPTX 時，Aspose.Slides 會將方程式寫入為可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

Aspose.Slides 會將數學方程式匯出為 MathML。若需要 LaTeX，請先匯出為 MathML，然後使用支援目標 LaTeX 方言的工具將 MathML 轉換為 LaTeX。