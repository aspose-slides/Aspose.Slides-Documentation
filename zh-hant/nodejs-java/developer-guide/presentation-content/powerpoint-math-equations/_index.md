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

PowerPoint 將方程式儲存為 Office Math Markup Language (OMML)。使用 Aspose.Slides for Node.js via Java，您可以以程式方式建立相同類型的數學內容：分數、根號、函數、極限、N 元運算子、矩陣、陣列以及格式化的數學區塊。

在 PowerPoint 中，使用者通常從 **Insert > Equation** 添加方程式：

![PowerPoint 插入索引標籤，已選取方程式指令](powerpoint-math-equations_1.png)

結果是在投影片上可編輯的數學文字：

![包含可編輯數學方程式的 PowerPoint 投影片](powerpoint-math-equations_2.png)

Aspose.Slides 透過三個主要物件建立此數學文字：

- 數學形狀，使用 [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) 建立，是包含方程式的形狀。
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) 在形狀文字框內儲存數學內容。
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) 包含一個或多個 [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) 物件。

以下大多數範例使用 [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) 與 [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) 的串接方法，以保持程式碼簡潔且易讀。

若需 MathML 匯出情境，請參閱 [從簡報匯出數學方程式（Node.js via Java）](/slides/zh-hant/nodejs-java/exporting-math-equations/).

## **建立方程式**

此範例使用 [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) 建立數學形狀，並加入畢氏定理：

![方程式 c² = a² + b²](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) 會建立已包含數學段落的形狀。存取第一個 [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/)，呼叫 [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)，並向其加入數學區塊或數學元素。
{{% /alert %}}

## **加入分數**

使用 [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) 建立分數。您可以使用 [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/) 選擇分數樣式。

![一個斜斜的數學分數，顯示 1 除以 x](powerpoint-math-equations_4.png)

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

若需堆疊式分數，使用 [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar)：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **加入根號**

使用 [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) 建立平方根、立方根或其他根號。當前元素成為底部，參數則成為指數。

![一個 n 次根號表達式，x 位於根號下方](powerpoint-math-equations_5.png)

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

### **顯示或隱藏平方根的指數**

平方根可以顯示明確的 2，或使用傳統的 √x 符號。[MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) 的 [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) 方法控制顯示哪種形式。兩種形式皆保留指數 2 與被開根號的 x，在可編輯的方程式中。

![相同的平方根，左側指數可見，右側指數隱藏](square-root-degree.png)

此範例將相同的平方根保存兩次。於 `visible-degree.pptx` 中，2 為可見；於 `hidden-degree.pptx` 中，2 為隱藏。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let radical = new aspose.slides.MathematicalText("x").radical("2");
    
    let shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    let portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new aspose.slides.MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", aspose.slides.SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **加入函數與極限**

使用 [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) 或 [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) 來建立如 `sin(x)`、`log(x)` 或自訂函數名稱的函數。對於極限，可將 `lim` 放入 [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/)，或使用 [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit)。

![當 x 趨近於無限大時的極限](powerpoint-math-equations_8.png)

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

若使用自訂函數名稱，將函數名稱設為當前元素，然後以其參數呼叫 [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function)：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **加入 N 元運算子與積分**

使用 [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) 進行總和、聯集、交集及其他大型運算子。使用 [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) 進行積分。兩個方法皆可設定上下限。

![帶有上下限的求和符號](powerpoint-math-equations_7.png)

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

N 元運算子用於帶有可選上下限的大型運算子。簡單運算子如 `+`、`-`、`=` 通常以 [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) 加入並串接到表達式中。

若要加入積分，使用 [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral)：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **加入矩陣**

使用 [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) 建立行與列。矩陣預設不包含括號，若需括號、方括號或大括號，請自行將矩陣包起來。

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

### **編輯現有矩陣**

假設線性代數課程以 `matrix.pptx` 中的係數矩陣開始，該檔案是前述範例所儲存。接下來的練習保留第一個方程式，將第二個方程式換成兩個新方程式，並重新調整變數集合。透過 [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) 開啟現有矩陣，以保留仍適用的係數。

![原始兩列係數矩陣，第一列為 1、x 與空格，第二列為 x、2 與 y](matrix-before-edit.png)

行與列索引從零開始，並指向呼叫時的矩陣狀態。在索引 1 前插入行會將原本的第二行移至索引 2。於索引 2 後插入則會附加新行。刪除第 2 行會移除原始的第二個方程式，並使附加的行上移一個位置。欄位也以相同方式移動。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("matrix.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const matrix = portion.getMathParagraph().get_Item(0).get_Item(0);

    matrix.insertRowBefore(1);
    matrix.insertRowAfter(2);
    matrix.deleteRow(2);

    matrix.insertColumnBefore(1);
    matrix.insertColumnAfter(3);
    matrix.deleteColumn(3);

    // 新的儲存格最初為 null。先設定非零係數。
    matrix.set_Item(1, 0, new slides.MathematicalText("12"));
    matrix.set_Item(1, 1, new slides.MathematicalText("1"));
    matrix.set_Item(2, 2, new slides.MathematicalText("10"));
    matrix.set_Item(2, 3, new slides.MathematicalText("1"));
    for (let row = 0; row < matrix.getRowCount(); row++) {
        for (let column = 0; column < matrix.getColumnCount(); column++) {
            if (matrix.get_Item(row, column) == null) {
                matrix.set_Item(row, column, new slides.MathematicalText("0"));
            }
        }
    }

    matrix.setColumnAlignment(0, slides.MathHorizontalAlignment.Left);
    matrix.setColumnsAlignment(1, 3, slides.MathHorizontalAlignment.Right);

    presentation.save("updated-matrix.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment) 將第一欄對齊左側。[setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment) 則將從索引 1 開始的三個連續欄位對齊右側。在 `updated-matrix.pptx` 中，矩陣有三個方程式與四個變數。原本第一列的係數 `1` 與 `x` 現在出現在第一與第三欄位。

![更新後的三列矩陣，顯示列 1,0,x,0；12,1,0,0；以及 0,0,10,1](matrix-after-edit.png)

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

### **將陣列與周圍元素對齊**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) 控制陣列相對於旁邊數學元素的垂直對齊方式。以下範例比較第一列、陣列中心與最後一列的對齊效果。

以下範例建立三個相同的陣列，每個皆有三列，且相鄰元素為 `A=` 與 `=B`。所有數學文字皆採用 Cambria Math 24 點。僅變更陣列的對齊方式。

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

以下比較圖示於 PowerPoint 中儲存的簡報。請留意每個陣列旁的 `A=` 與 `=B` 位置。

![在 PowerPoint 中，方程式陣列的上、中心、下對齊，且相鄰元素相同](equation-array-alignment.png)

### **設定列間距**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) 選取陣列內列的間距規則。[setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) 為明確的間距規則提供數值，預設規則會忽略此設定。

若使用精確間距，數值以點 (point) 為單位。若使用比例間距，則以半行為單位：範例中的值 `3` 表示 1.5 行。指定明確數值時同時設定兩個屬性；僅變更數值而不設定間距規則不會生效。

若要在整個方程式中設定列間距，請在 `setRowSpacingRule` 與 `setRowSpacing` 兩個屬性同時設定。

以下範例將相同的方程式、對齊與字型設定保存為五個簡報。前三個使用預設；最後兩個顯示明確的數值。

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

陣列列間距與段落間距分開設定。[setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) 與 [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) 為包含段落加上前後空白，並不影響陣列列之間的間距。同樣地，[MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) 會水平定位整個數學段落；不會取代陣列的垂直對齊設定。

## **加入三角函數**

當參數是當前元素且函數名稱已知時，使用 [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction)。

![三角函數 cos 套用於 2x](powerpoint-math-equations_6.png)

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

使用下標與上標輔助函式來處理索引與次方。當索引必須出現在基底的左側時，使用 [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)。

![大寫 Y，左側下標 1 與上標 n](powerpoint-math-equations_9.png)

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

## **加入分隔符號**

使用 [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) 將表達式放入分隔符號中。對於包含多個元素的分隔符號表達式，亦可設定分隔字元。

![包含 x、y、z，並以垂直線分隔的分隔符號表達式](powerpoint-math-equations_13.png)

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

### **調整分隔符號大小與對齊**

將 `true` 傳給 [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight)，讓括號依照較高的運算元自動伸長；傳 `false` 則保持正常大小。使用 [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) 搭配兩個 [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) 之一。`Centered` 使括號居中於數學軸（穿過等號中線），`Match` 則與被包圍內容對齊。這兩個設定僅影響分隔符號本身，內部表達式保持不變。

此範例將分數放於 `x` 的指數上，使表達式在基線上方的延伸超過下方。四個方程式皆使用相同的括號與字型設定。

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

在 PowerPoint 中，比較各列即可看出伸長效果。上列的括號會伸長以包住指數，兩種形狀看起來相同。下列則關閉伸長。左側較小的括號（`Centered`）與等號對齊，右側的（`Match`）則在表達式上方較高。

![PowerPoint 中四個方程式，上方啟用分隔符號伸長、下方關閉，左側為 Centered，右側為 Match](delimiter-sizing.png)

## **加入邊框盒子**

對分數呼叫 [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) 以為整個表達式加上框線。回傳的 [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) 預設顯示四個邊。使用 [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop)、[setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom)、[setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft) 與 [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) 可移除個別邊。

此範例在同一投影片上放置相同分數的六個副本。若要顯示抵消，先隱藏四個邊，然後將 `true` 傳給 [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) 以產生上升對角線 (↗)，或傳給 [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) 以產生下降對角線 (↘)。亦可使用 [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) 或 [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) 搭配任意可見邊的組合。

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

![PowerPoint 中六個可編輯的分數。上列：完整邊框、底部與左側、上升對角線。下列：下降對角線、水平刪除線、垂直刪除線加完整邊框。](border-box-fractions.png)

在此分數上，水平刪除線會與分數線重疊。垂直刪除線穿過分子與分母，同時周圍的邊框仍保持可見。這些線條會裝飾整個表達式。普通文字的刪除線僅套用於文字串中的字元。重新在 PowerPoint 開啟簡報後，仍可分別編輯分子與分母。

## **使用幻影元素控制可見性與版面配置**

將表達式包裹於 [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) 中，以獨立控制其可見性與對方程式所佔的空間。[MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) 方法可控制以下項目：

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | 傳入 `false` 以隱藏表達式。除非下面相應的方法傳入 `true`，否則其尺寸仍會影響版面配置。 |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | 將表達式的水平寬度視為 0，使相鄰元素可更靠近。 |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | 將其上升度（基線以上的高度）視為 0。這可減少相鄰元素上方保留的空間。 |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | 將其下降度（基線以下的深度）視為 0。這可使分數線或其他表達式下方的內容更貼近相鄰元素。 |

基線是普通數學字母所坐落的參考線。隱藏內容不會移除其尺寸，將尺寸視為零亦不會刪除表達式。底層表達式仍可透過 [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase) 存取。傳入 `true` 給 [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) 可再次顯示；尺寸設定會保持不變。

以下範例建立五個並排變體：一個可見的分數、一個保留空間的隱藏分數，以及三個將單一尺寸視為零的隱藏分數。每個變體皆使用相同的周圍表達式與 24 點 Cambria Math。所有方程式形狀的頂部位置相同，以灰色參考線標示。將幻影放在外層分數的分子中，可更容易觀察垂直版面配置的變化。

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
    presentation.getSlideSize().setSize(1000, 180, slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const labels = [ "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" ];

    const guide = slide.getShapes().addAutoShape(slides.ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    for (let i = 0; i < labels.length; i++) {
        const left = 10 + i * 200;

        const label = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(slides.FillType.NoFill));
        label.getTextFrame().setText(labels[i]);

        const labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
        labelFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        const fractionNumerator = createText("a+b");
        const fractionDenominator = createText("c+d");
        const fraction = new slides.MathFraction(fractionNumerator, fractionDenominator);
        const phantom = new slides.MathPhantom(fraction);
        phantom.setShow(i === 0);
        phantom.setZeroWidth(i === 2);
        phantom.setZeroAsc(i === 3);
        phantom.setZeroDesc(i === 4);

        const leftText = createText("x+");
        const rightText = createText("+y");
        const numerator = new slides.MathBlock(leftText).join(phantom).join(rightText);
        const denominator = createText("z");
        const equation = new slides.MathFraction(numerator, denominator);

        const shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(slides.TextAnchorType.Top));

        const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new slides.MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![PowerPoint 中的五個方程式，比較可見分數、保留空間的隱藏分數，以及啟用 ZeroWidth、ZeroAsc 或 ZeroDesc 的隱藏分數](math-phantom.png)

## **組合項目**

使用 [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) 將分組字元放於表達式上方或下方。加入極限以為分組的項目標籤。

![將表達式 x + y 分組，並在下方加上任意文字標籤](powerpoint-math-equations_15.png)

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

僅在有助於說明公式時使用格式化輔助函式。例如，[overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) 可在數學元素上方加上橫線。

![數學表達式 ABC 加上上橫線](powerpoint-math-equations_14.png)

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

### **格式化現有方程式中的文字**

若要在整個現有方程式中格式化文字，需遍歷每個數學區塊的元素樹。[MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) 只回傳直接子項目，必須遞迴呼叫以取得分數、上下標、根號及其他巢狀結構中的文字。亦需檢查當前元素與其子項目，以在起始元素為 [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) 時將其納入。

此範例假設 `input.pptx` 包含如 `z = xᵢ / ∛y` 的方程式，分數的分子帶有下標，分母帶有根號。若僅處理區塊的頂層元素，會遺漏分數內的文字。範例在投影片文字框中尋找數學區段，透過 [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) 取得其區塊，並使用 [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) 將每個文字元素的 [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) 方法中的字型大小設為 28 點。

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

儲存的簡報在每個處理過的方程式的各層級都包含已更新的文字格式，且保留其文字內容與數學結構。

## **快速參考**

| 任務 | 主要 API |
| --- | --- |
| 建立數學文字 | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| 結合元素 | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 建立分數 | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入上標或下標 | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入函數 | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入根號 | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入極限 | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入左側上下標 | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入總和與積分 | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入矩陣 | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| 加入方程式陣列 | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入分隔符號 | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 加入橫線與邊框 | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| 組合項目 | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **常見問題**

**我可以編輯既有的 PowerPoint 方程式嗎？**

可以。開啟簡報，找出包含 [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) 的形狀，呼叫 [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph)，並更新該段落中的數學區塊。

**方程式會保存為可編輯的 PowerPoint 數學嗎？**

是的。儲存為 PPTX 時，Aspose.Slides 會將方程式寫入為可編輯的 Office 數學內容。

**我可以將方程式匯出為 LaTeX 嗎？**

可以。從其 [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) 取得方程式的 [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)，然後呼叫 [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) 直接匯出。完整範例請參閱 [從簡報匯出數學方程式（Node.js via Java）](/slides/zh-hant/nodejs-java/exporting-math-equations/#export-math-equations-to-latex)。