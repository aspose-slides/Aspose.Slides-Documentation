---
title: 在 Android 上為 PowerPoint 簡報新增數學公式
linktitle: PowerPoint 數學公式
type: docs
weight: 80
url: /zh-hant/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 PowerPoint PPT 與 PPTX 中插入與編輯數學公式，支援 OMML、格式控制，並提供清晰的 Java 程式碼範例。"
---
## **概觀**

PowerPoint 以 Office Math Markup Language (OMML) 儲存公式。使用 Aspose.Slides for Android via Java，您可以以程式方式建立相同類型的數學內容：分數、根號、函數、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常從 **插入 > 公式** 新增公式：

![PowerPoint 插入功能表標籤，已選取「公式」指令](powerpoint-math-equations_1.png)

結果是在投影片上呈現可編輯的數學文字：

![包含可編輯數學公式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建構這些數學文字：

- 一個數學形狀，使用 [addMathShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/) 建立，是包含公式的形狀。
- [MathPortion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathportion/) 儲存形狀文字框內的數學內容。
- [MathParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathblock/) 物件。

以下大多範例使用 [MathematicalText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathematicaltext/) 以及 [IMathElement](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) 的流暢方法，以保持程式碼簡潔易讀。

如需 MathML 匯出情境，請參閱 [Export Math Equations from Presentations on Android](/slides/zh-hant/androidjava/exporting-math-equations/)。

## **建立公式**

此範例建立一個數學形狀並加入畢氏定理：

![c 平方等於 a 平方加 b 平方的公式](powerpoint-math-equations_3.png)

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
`addMathShape` 會建立已包含數學段落的形狀。取得第一個 `MathPortion`，取得其 `MathParagraph`，然後將數學區塊或數學元素加入其中。
{{% /alert %}}

## **加入分數**

使用 `divide` 建立分數。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathfractiontypes/) 選擇分數樣式。

![顯示 1 除以 x 的斜分數](powerpoint-math-equations_4.png)

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **加入根號**

使用 `radical` 建立平方根、立方根或其他根。目前的元素成為基底，參數則成為次方。

![在根號符號下方有 x 的 n 次根表達式](powerpoint-math-equations_5.png)

```java
import com.aspose.slides.*;

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

使用 `asArgumentOfFunction` 或 `function` 來建立如 `sin(x)`、`log(x)` 或自訂函數名稱的函數。對於極限，將 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathlimit/) 或使用 `setLowerLimit`。

![x 趨近於無限大的極限](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

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

若要使用自訂函數名稱，將函數名稱設定為目前的元素：

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **加入 N 元運算子與積分**

使用 `nary` 來建立求和、聯集、交集等大型運算子。使用 `integral` 來建立積分。兩者皆可設定上下限制。

![具有上下限制的求和符號](powerpoint-math-equations_7.png)

```java
import com.aspose.slides.*;

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

N 元運算子用於可選上下限制的大型運算子。`+`、`-`、`=` 等簡單運算子通常以 `MathematicalText` 加入，然後串接成表達式。

若要建立積分，使用 `integral`：

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **加入矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathmatrix/) 來處理行與列。矩陣預設不包含括號，若需要括號、方括號或大括號，請自行在矩陣外加上。

![具有一個空儲存格的兩列矩陣](powerpoint-math-equations_10.png)

```java
import com.aspose.slides.*;

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

## **加入公式陣列**

當需要對齊的公式或垂直堆疊的表達式時，使用 `toMathArray`。

![上方為 x、下方為 y 的垂直數學陣列](powerpoint-math-equations_11.png)

```java
import com.aspose.slides.*;

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

當參數是目前的元素且函數名稱已知時，使用 `asArgumentOfFunction`。

![cos 函數套用於 2x 的示例](powerpoint-math-equations_6.png)

```java
import com.aspose.slides.*;

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

使用下標與上標輔助方法處理索引與次方。若索引必須出現在基底左側，使用 `setSubSuperscriptOnTheLeft`。

![左側下標 1 及上標 n 的大寫 Y](powerpoint-math-equations_9.png)

```java
import com.aspose.slides.*;

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

## **加入界定符**

使用 `enclose` 將表達式置於界定符之中。亦可設定分隔字元，以在包含多個元素的界定符表達式中使用。

![以直線分隔 x、y、z 的界定符表達式](powerpoint-math-equations_13.png)

```java
import com.aspose.slides.*;

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

## **加入邊框盒**

當整個公式需要被框起時，使用 `toBorderBox`。

![顯示 a 平方等於 b 平方加 c 平方的盒狀公式](powerpoint-math-equations_12.png)

```java
import com.aspose.slides.*;

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

使用 `group` 將分組字元放於表達式的上方或下方。加入限制以為分組項目加上標籤。

![x 加 y 的表達式下方附有「任何文字」的分組示例](powerpoint-math-equations_15.png)

```java
import com.aspose.slides.*;

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

僅在能提升公式可讀性的情況下使用格式化輔助方法。例如，`overbar` 會在數學元素上方加上一條橫線。

![帶上橫線的 ABC 數學表達式](powerpoint-math-equations_14.png)

```java
import com.aspose.slides.*;

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
| 合併元素 | [IMathElement.join](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 建立分數 | [IMathElement.divide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入上標或下標 | [setSuperscript](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入函數 | [function](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入根號 | [IMathElement.radical](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入極限 | [setLowerLimit](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入左側腳本 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入求和與積分 | [nary](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入矩陣 | [MathMatrix](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/mathmatrix/) |
| 加入公式陣列 | [toMathArray](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入界定符 | [enclose](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 加入上橫線與邊框 | [overbar](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |
| 分組項目 | [group](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathelement/) |

## **常見問題**

**我可以編輯已存在的 PowerPoint 公式嗎？**

可以。開啟簡報，找到包含 `MathPortion` 的形狀，取得其 `MathParagraph`，然後更新該段落中的數學區塊。

**公式會儲存為可編輯的 PowerPoint 數學嗎？**

會。存成 PPTX 時，Aspose.Slides 會將公式寫入為可編輯的 Office 數學內容。

**我可以將公式匯出為 LaTeX 嗎？**

可以。從其 [IMathPortion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathportion/) 取得公式的 [IMathParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathparagraph/)，然後呼叫 [IMathParagraph.toLatex](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imathparagraph/#toLatex--) 直接匯出。完整範例請參閱 [Export Math Equations from Presentations in Android via Java](/slides/zh-hant/androidjava/exporting-math-equations/#export-math-equations-to-latex)。