---
title: 在 JavaScript 中將數學方程式新增至 PowerPoint 簡報
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
description: "使用 Aspose.Slides for Node.js via Java 在 PowerPoint PPT 和 PPTX 中插入與編輯數學方程式，支援 OMML、格式控制，以及清晰的 JavaScript 程式碼範例。"
---
## **概述**

PowerPoint 將方程式儲存為 Office Math Markup Language（OMML）。使用 Aspose.Slides for Node.js via Java，您可以以程式方式建立相同類型的數學內容：分數、根號、函式、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常從 **插入 > 方程式** 添加方程式：

![PowerPoint 插入標籤已選取方程式指令](powerpoint-math-equations_1.png)

結果是投影片上的可編輯數學文字：

![包含可編輯數學方程式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建立該數學文字：

- 數學圖形，使用 [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) 建立，是包含方程式的圖形。
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) 將數學內容儲存在圖形文字框內。
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) 物件。

以下大多數範例使用 [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) 以及 [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) 的串接方法，以保持程式碼簡潔易讀。

若需 MathML 匯出情境，請參閱 [從簡報匯出數學方程式 (Node.js via Java)](/slides/zh-hant/nodejs-java/exporting-math-equations/)。

## **建立方程式**

此範例使用 [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) 建立數學圖形，並加入畢氏定理：

![c 平方等於 a 平方加 b 平方的方程式](powerpoint-math-equations_3.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) 建立已包含數學段落的圖形。存取第一個 [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) ，呼叫 [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) ，並將數學區塊或數學元素加入其中。
{{% /alert %}}

## **加入分數**

使用 [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) 建立分數。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/) 選擇分數樣式。

![顯示 1 除以 x 的傾斜分數](powerpoint-math-equations_4.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

若要堆疊分數，請使用 [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar)：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **加入根號**

使用 [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) 建立平方根、立方根或其他根。當前元素成為底部，參數成為指數。

![在根號下方有 x 的 n 次根表達式](powerpoint-math-equations_5.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **加入函式與極限**

使用 [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) 或 [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) 來處理 `sin(x)`、`log(x)` 或自訂函式名稱等函式。對於極限，可在 [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) 中放入 `lim`，或使用 [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit)。

![x 趨近於無限大的極限](powerpoint-math-equations_8.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

若要使用自訂函式名稱，將函式名稱設為當前元素，然後以其參數呼叫 [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function)：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **加入 N 元運算子與積分**

使用 [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) 進行總和、聯集、交集及其他大型運算子。使用 [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) 產生積分。兩者皆可設定上下限。

![帶有上下限的總和](powerpoint-math-equations_7.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

N 元運算子用於帶有選擇性上下限的大型運算子。像 `+`、`-`、`=` 這類簡單運算子通常以 [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) 加入至表達式中。

若要建立積分，請使用 [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral)：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **加入矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) 來建立列與行。預設矩陣不包含括號，若需要圓括號、方括號或大括號，請自行將矩陣包起來。

![具有兩列且其中一格為空的數學矩陣](powerpoint-math-equations_10.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

當需要對齊的方程式或垂直堆疊的表達式時，使用 [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray)。

![垂直數學陣列，x 位於 y 之上](powerpoint-math-equations_11.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **對齊陣列與周圍元素**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) 控制陣列相對於旁邊數學元素的垂直對齊方式。以下範例比較第一列、陣列中心與最後一列的對齊方式。

以下範例建立三個相同的陣列，每個都有三列，且旁邊的元素為 `A=` 與 `=B`。所有數學文字皆使用 24 點 Cambria Math。僅變更陣列的對齊方式。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [slides.MathVerticalAlignment.Top, slides.MathVerticalAlignment.Center, slides.MathVerticalAlignment.Bottom];
    const alignmentNames = ["Top", "Center", "Bottom"];

    for (let i = 0; i < alignments.length; i++) {
        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(alignmentNames[i]);
        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));
        const mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

以下比較顯示在 PowerPoint 中儲存的簡報。請注意每個陣列旁的 `A=` 與 `=B` 位置。

![PowerPoint 中的方程式陣列，包含上對齊、置中、下對齊，且旁邊元素相同](equation-array-alignment.png)

### **設定列間距**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) 選擇陣列內列的間距規則。[setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) 為明確的間距規則提供數值，且會被預設規則忽略。

若使用精確間距，值以點 (pt) 為單位。若使用比例間距，則以半行為單位：範例中的值 `3` 表示 1.5 行。指定明確值時需同時設定兩個屬性；僅更改數值不會選擇間距規則。

以下範例儲存五個簡報，內容相同的方程式、對齊與字型設定。前三個使用預設；後兩個顯示明確數值。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function createText(value) {
    const text = new slides.MathematicalText(value);
    text.getFormat().setFontHeight(24);
    text.getFormat().setLatinFont(new slides.FontData("Cambria Math"));
    return text;
}

const rules = [slides.MathRowSpacingRule.SingleLineGap, slides.MathRowSpacingRule.OneAndAHalfLineGap, slides.MathRowSpacingRule.TwoLineGap, slides.MathRowSpacingRule.Exactly, slides.MathRowSpacingRule.Multiple];
const spacingValues = [0, 0, 0, 20, 3];
const ruleNames = ["SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple"];

for (let i = 0; i < rules.length; i++) {
    const fileName = "equation-array-" + ruleNames[i] + ".pptx";
    const presentation = new slides.Presentation();
    try {
        const mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        const paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        const mathParagraph = paragraph.getPortions().get_Item(0).getMathParagraph();
        mathParagraph.setJustification(slides.MathJustification.LeftJustified);

        const rows = [createText("x+y=3"), createText("x-y=1"), createText("x=2")];
        const equationArray = new slides.MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(slides.MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(java.newLong(spacingValues[i]));
        const leftText = createText("A=");
        const rightText = createText("=B");
        const equation = new slides.MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

陣列列間距與段落間距分開。[setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) 與 [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) 會在包含段落的前後加入空間，而非在陣列列之間。同樣地，[MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) 會水平定位整個數學段落，並不會取代陣列的垂直對齊設定。

## **加入三角函式**

當參數是當前元素且函式名稱已知時，使用 [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction)。

![將三角函式 cos 套用於 2x](powerpoint-math-equations_6.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

使用下標與上標輔助函式來處理指數與次方。若指標必須出現在基底左側，請使用 [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)。

![左側有下標 1、上標 n 的大寫 Y](powerpoint-math-equations_9.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **加入分界符**

使用 [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) 將表達式放入分界符內。對於包含多個元素的分界符表達式，也可設定分隔字元。

![由 x、y、z 以直線分隔的分界符表達式](powerpoint-math-equations_13.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

### **調整分界符大小與對齊**

將 `true` 傳遞給 [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) 可讓括號隨較高的運算元伸長，傳遞 `false` 則保持原始大小。使用 [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) 搭配兩種 [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) 之一。`Centered` 使括號在數學軸上置中，該軸穿過等號的中間。`Match` 則與所包圍的內容對齊。兩種設定僅影響分界符，內部表達式保持不變。

此範例將分數放在 `x` 的指數上，使表達式在基線上方的延伸比下方更長。四個方程式皆使用相同的括號與字型設定。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    for (let row = 0; row < 2; row++) {
        for (let column = 0; column < 2; column++) {
            const fraction = new slides.MathematicalText("a + b").divide("c + d");
            const power = new slides.MathematicalText("x").setSuperscript(fraction);
            const delimiter = power.enclose(java.newChar('('), java.newChar(')'));
            delimiter.setGrowToMatchOperandHeight(row === 0);
            delimiter.setDelimiterShape(column === 0 ? slides.MathDelimiterShape.Centered : slides.MathDelimiterShape.Match);

            const mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            const portion = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            const equation = new slides.MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中，比較各列可見成長效果。上列的括號因指數而伸長，兩種形狀看起來相同。下列關閉成長。左側較小的括號（`Centered`）與等號對齊，而右側（`Match`）則在表達式上方較高。

![PowerPoint 中四個方程式，上方啟用分界符成長、下方未啟用，左側使用 Centered，右側使用 Match](delimiter-sizing.png)

## **加入框線盒**

對分數呼叫 [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) 可為整個表達式加上框線。回傳的 [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) 預設顯示四側。使用 [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop)、[setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom)、[setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) 以及 [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) 可隱藏個別側邊。

此範例在同一投影片上放置六個相同的分數。為顯示取消，隱藏四側並將 `true` 傳遞給 [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) 以產生向上對角線 (↗)，或傳遞給 [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) 產生向下對角線 (↘)。亦可使用 [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) 或 [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) 並搭配任意可見側邊的組合。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    function addFraction(x, y, hideBorder) {
        const fraction = new slides.MathematicalText("x+1").divide("y+2");
        const box = fraction.toBorderBox();
        box.setHideTop(hideBorder);
        box.setHideBottom(hideBorder);
        box.setHideLeft(hideBorder);
        box.setHideRight(hideBorder);

        const shape = slide.getShapes().addMathShape(x, y, 160, 90);
        const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        portion.getPortionFormat().setFontHeight(28);
        const block = new slides.MathBlock(box);
        portion.getMathParagraph().add(block);
        return box;
    }

    addFraction(10, 10, false);

    const partial = addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    addFraction(190, 120, true).setStrikethroughHorizontal(true);
    addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![PowerPoint 中六個可編輯的分數。上列：完整框線、底部與左側、向上對角線。下列：向下對角線、水平刪除線、垂直刪除線且保留完整框線。](border-box-fractions.png)

在此分數中，水平刪除線與分數線重疊。垂直刪除線穿過分子與分母，同時保留周圍框線。這些線條裝飾整個表達式。普通文字的刪除線僅作用於文字執行的字元。重新在 PowerPoint 開啟簡報後，仍可獨立編輯分子與分母。

## **分組項目**

使用 [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) 可在表達式上方或下方放置分組符號。加入極限以為分組項目加上標籤。

![將 x 加 y 的表達式分組，並在下方加上任意文字標籤](powerpoint-math-equations_15.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

僅在需要說明公式時使用格式化輔助函式。例如，[overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) 會在數學元素上方加上一條橫線。

![帶有上橫線的數學表達式 ABC](powerpoint-math-equations_14.png)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **格式化既有方程式中的文字**

若要在既有方程式中格式化文字，需遍歷每個數學區塊的元素樹。[MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) 僅回傳直接子項，故需遞迴呼叫以觸及分數、上下標、根號及其他巢狀結構內的文字。檢查當前元素與其子項，以在元素為 [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) 時亦包含起始元素。

此範例假設 `input.pptx` 包含如 `z = xᵢ / ∛y` 的方程式，其中分數的分子包含下標，分母包含根號。僅處理區塊的頂層元素會遺漏分數內的文字。範例在投影片文字框中找到數學區段，透過 [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) 取得其區塊，並使用 [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) 以 28 點設定每個文字元素的 [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) 方法的字型大小。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatMathText(element) {
    if (java.instanceOf(element, "com.aspose.slides.MathematicalText")) {
        element.getFormat().setFontHeight(28);
    }

    let children = element.getChildren();
    for (let i = 0; i < children.length; i++) {
        formatMathText(children[i]);
    }
}

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }

            let textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let k = 0; k < textFrame.getParagraphs().getCount(); k++) {
                let paragraph = textFrame.getParagraphs().get_Item(k);
                for (let l = 0; l < paragraph.getPortions().getCount(); l++) {
                    let portion = paragraph.getPortions().get_Item(l);
                    if (java.instanceOf(portion, "com.aspose.slides.IMathPortion")) {
                        let mathParagraph = portion.getMathParagraph();
                        for (let m = 0; m < mathParagraph.getCount(); m++) {
                            formatMathText(mathParagraph.get_Item(m));
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

儲存的簡報在每個已處理方程式的各層級中皆包含更新的文字格式，同時保留其文字內容與數學結構。

## **快速參考**

| 任務 | 主要 API |
| --- | --- |
| 建立數學文字 | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| 合併元素 | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 建立分數 | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入上標或下標 | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入函式 | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入根號 | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入極限 | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入左側上下標 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入總和與積分 | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入矩陣 | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| 加入方程式陣列 | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入分界符 | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入上橫線與框線 | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 分組項目 | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **常見問題**

**我可以編輯現有的 PowerPoint 方程式嗎？**

是的。開啟簡報，尋找包含 [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) 的圖形，呼叫 [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)，並更新該段落中的數學區塊。

**方程式會儲存為可編輯的 PowerPoint 數學嗎？**

是的。當儲存為 PPTX 時，Aspose.Slides 會將方程式寫入為可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

是的。從其 [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) 取得方程式的 [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)，然後呼叫 [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) 直接匯出。完整範例請參閱 [從簡報匯出數學方程式 (Node.js via Java) – 匯出為 LaTeX](/slides/zh-hant/nodejs-java/exporting-math-equations/#export-math-equations-to-latex)。