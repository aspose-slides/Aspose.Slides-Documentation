---
title: เพิ่มสมการคณิตศาสตร์ลงในงานนำเสนอ PowerPoint ด้วย JavaScript
linktitle: สมการคณิตศาสตร์ PowerPoint
type: docs
weight: 80
url: /th/nodejs-java/powerpoint-math-equations/
keywords:
- สมการคณิตศาสตร์
- สัญลักษณ์คณิตศาสตร์
- สูตรคณิตศาสตร์
- ข้อความคณิตศาสตร์
- เพิ่มสมการคณิตศาสตร์
- เพิ่มสัญลักษณ์คณิตศาสตร์
- เพิ่มสูตรคณิตศาสตร์
- เพิ่มข้อความคณิตศาสตร์
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แทรกและแก้ไขสมการคณิตศาสตร์ในไฟล์ PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java รองรับ OMML การควบคุมการจัดรูปแบบ และตัวอย่างโค้ด JavaScript ที่ชัดเจน"
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML). ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java คุณสามารถสร้างเนื้อหาคณิตศาสตร์ประเภทเดียวกันโดยใช้โปรแกรมได้: เศษส่วน, ราก, ฟังก์ชัน, ขอบเขต, ตัวดำเนินการ N-ary, เมทริกซ์, อาเรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้มักเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint พร้อมคำสั่ง Equation ถูกเลือก](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่แก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่สามารถแก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านวัตถุหลักสามประเภท:

- รูปร่างคณิตศาสตร์, สร้างด้วย [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape), เป็นรูปร่างที่บรรจุสมการ.
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปร่าง.
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) มีหนึ่งหรือหลายวัตถุ [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/).

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) และวิธีการแบบ fluent ของ [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) เพื่อให้โค้ดสั้นและอ่านง่าย.

สำหรับสถานการณ์การส่งออก MathML, ดูที่ [Export Math Equations from Presentations in Node.js via Java](/slides/th/nodejs-java/exporting-math-equations/).

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มสูตรพีทากอรัส:

![สมการ c² = a² + b²](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) สร้างรูปร่างที่มีย่อหน้าคณิตศาสตร์อยู่แล้ว. เข้าถึง [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) ตัวแรก, เรียก [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), และเพิ่มบล็อกคณิตศาสตร์หรือองค์ประกอบคณิตย์ศาสตร์ลงไป.
{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) เพื่อสร้างส่วน. คุณสามารถเลือกสไตล์ส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/).

![ส่วนคณิตศาสตร์เอียงที่แสดง 1 ÷ x](powerpoint-math-equations_4.png)

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

สำหรับส่วนแบบซ้อนกัน, ใช้ [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **เพิ่มราก**

ใช้ [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) เพื่อสร้างรากที่สอง, รากที่สาม หรือรากอื่นๆ. องค์ประกอบปัจจุบันจะเป็นฐาน, และอากรูเมนต์จะเป็นระดับ.

![นิพจกราก n-th ที่มี x ใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

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

## **เพิ่มฟังก์ชันและขอบเขต**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) หรือ [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)`, หรือชื่อฟังก์ชันที่กำหนดเอง. สำหรับขอบเขต, ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) หรือใช้ [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit).

![ขอบเขตของ x เมื่อ x เข้าใกล้อนันต์](powerpoint-math-equations_8.png)

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

สำหรับชื่อฟังก์ชันที่กำหนดเอง, ทำให้ชื่อฟังก์ชันเป็นองค์ประกอบปัจจุบันและเรียก [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) พร้อมอากรูเมนต์ของมัน:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิกรัล**

ใช้ [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) สำหรับการบวก, การรวม, การตัดกัน, และตัวดำเนินการขนาดใหญ่อื่นๆ. ใช้ [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) สำหรับอินทิกรัล. ทั้งสองวิธีให้คุณตั้งค่าขอบเขตล่างและบน.

![ผลรวมที่มีขอบล่างและขอบบน](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N-ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่มีขอบเขตเลือกได้. ตัวดำเนินการง่ายเช่น `+`, `-`, และ `=` มักจะเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) แล้วเชื่อมต่อเป็นส่วนของนิพจน์.

สำหรับอินทิกรัล, ใช้ [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) สำหรับแถวและคอลัมน์. เมทริกซ์โดยปกติไม่มีวงเล็บ, ดังนั้นให้ล้อมเมทริกซ์ด้วยวงกลม, วงเหลี่ยม, หรือวงโค้งเมื่อจำเป็น.

![เมทริกซ์คณิตศาสตร์สองแถวที่มีเซลล์ว่างหนึ่งช่อง](powerpoint-math-equations_10.png)

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

## **เพิ่มอาเรย์สมการ**

ใช้ [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) เมื่อคุณต้องการสมการที่เรียงแนวหรือตามแนวตั้งของนิพจน์หลายๆ ตัว.

![อาเรย์คณิตศาสตร์แนวตั้งที่มี x อยู่เหนือ y](powerpoint-math-equations_11.png)

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

### **จัดแนวอาเรย์กับองค์ประกอบรอบข้าง**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) ควบคุมการจัดแนวแนวตั้งของอาเรย์เทียบกับองค์ประกอบคณิตศาสตร์ที่อยู่ข้างเคียง. ตัวอย่างด้านล่างเปรียบเทียบการจัดแนวกับแถวแรก, ศูนย์กลางของอาเรย์, และแถวสุดท้าย.

ตัวอย่างต่อไปนี้สร้างอาเรย์สามชุดที่เหมือนกัน, แต่ละชุดมีสามแถวและองค์ประกอบเพื่อนบ้าน `A=` และ `=B`. ข้อความคณิตศาสตร์ทั้งหมดใช้ Cambria Math ขนาด 24 จุด. มีการเปลี่ยนแปลงเพียงการจัดแนวอาเรย์.

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

การเปรียบเทียบต่อไปนี้แสดงการบันทึกงานนำเสนอใน PowerPoint. โปรดสังเกตตำแหน่งของ `A=` และ `=B` ข้างแต่ละอาเรย์.

![อาเรย์สมการใน PowerPoint ที่จัดแนวบน, กลาง, และล่างพร้อมองค์ประกอบเพื่อนบ้านที่เหมือนกัน](equation-array-alignment.png)

### **กำหนดระยะห่างแถว**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) เลือกกฎการจัดระยะห่างสำหรับแถวภายในอาเรย์. [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) ให้ค่าตัวเลขสำหรับกฎระยะห่างที่ชัดเจนและจะถูกละเลยโดยกฎที่กำหนดไว้ล่วงหน้า.

สำหรับระยะห่างที่แน่นอน, ค่าจะวัดเป็นจุด. สำหรับระยะห่างแบบสัดส่วน, จะวัดเป็นครึ่งบรรทัด: ค่า `3` ในตัวอย่างหมายถึง 1.5 บรรทัด. ตั้งค่าทั้งสองคุณสมบัติเมื่อกำหนดค่าอย่างชัดเจน; การเปลี่ยนแค่ค่าตัวเลขอย่างเดียวจะไม่เลือกกฎระยะห่าง.

ตัวอย่างด้านล่างบันทึกงานนำเสนอห้าฉบับที่มีสมการ, การจัดแนว, และการตั้งค่าแบบอักษรเดียวกัน. สามฉบับแรกใช้การตั้งค่าเริ่มต้น; สองฉบับสุดท้ายแสดงค่าที่กำหนดอย่างชัดเจน.

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

ระยะห่างแถวของอาเรย์แยกจากระยะห่างของย่อหน้า. [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) และ [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) เพิ่มระยะห่างรอบย่อหน้าที่บรรจุ, ไม่ได้ระหว่างแถวของอาเรย์. เช่นเดียวกับ, [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) กำหนดตำแหน่งแนวนอนของย่อหน้าคณิตศาสตร์ทั้งหมด; ไม่ได้แทนที่การตั้งค่าการจัดแนวแนวตั้งของอาเรย์.

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) เมื่ออากรูเมนต์เป็นองค์ประกอบปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบ.

![ฟังก์ชันตรีโกณมิติ cos ที่นำไปใช้กับ 2x](powerpoint-math-equations_6.png)

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

## **เพิ่มตัวห้อยและตัวยก**

ใช้ตัวช่วยตัวห้อยและตัวยกสำหรับดัชนีและกำลัง. เมื่อดัชนีต้องแสดงทางด้านซ้ายของฐาน, ใช้ [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![อักษร Y ตัวพิมพ์ใหญ่ที่มีดัชนีซ้าย 1 และตัวยก n](powerpoint-math-equations_9.png)

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

## **เพิ่มเครื่องหมายขอบ**

ใช้ [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) เพื่อใส่นิพจน์ไว้ภายในเครื่องหมายขอบ. คุณยังสามารถกำหนดอักขระคั่นสำหรับนิพจน์ที่มีหลายองค์ประกอบได้.

![นิพจน์เครื่องหมายขอบที่มี x, y, และ z แยกด้วยเส้นตั้ง](powerpoint-math-equations_13.png)

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

### **ขนาดและจัดแนวเครื่องหมายขอบ**

ส่งค่า `true` ไปยัง [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) เพื่อให้วงเล็บขยายให้เข้ากับความสูงของตัวดำเนินการที่สูง, หรือส่งค่า `false` เพื่อให้คงขนาดปกติ. ใช้ [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) กับค่าหนึ่งจาก [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) สองค่า. `Centered` จะทำให้วงเล็บอยู่กลางแกนคณิตศาสตร์, ซึ่งวิ่งผ่านกลางเครื่องหมายเท่า. `Match` จะจัดให้ตรงกับเนื้อหาที่ล้อม. ทั้งสองการตั้งค่าให้ผลกับเครื่องหมายขอบเท่านั้น. นิพจน์ภายในคงเดิม.

ตัวอย่างวางส่วนในตัวชี้กำลังของ `x` ทำให้นิพจน์ขยายออกเหนือ baseline มากกว่าตำแหน่งล่าง. สมการสี่ข้อต่างใช้วงเล็บและการตั้งค่าแบบอักษรเดียวกัน.

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

ใน PowerPoint, เปรียบเทียบแถวเพื่อดูผลของการขยาย. ในแถวบน, วงเล็บขยายเพื่อครอบตัวชี้กำลังและดูเหมือนกันทั้งสองรูปแบบ. ในแถวล่าง, การขยายปิด. วงเล็บเล็กด้านซ้าย (`Centered`) จัดกับเครื่องหมายเท่า, ในขณะที่ด้านขวา (`Match`) อยู่สูงกว่ารอบนิพจน์.

![สี่สมการใน PowerPoint ที่เปิดการขยายเครื่องหมายขอบด้านบนและปิดด้านล่าง, และ Centered ด้านซ้าย Match ด้านขวา](delimiter-sizing.png)

## **เพิ่มกล่องขอบ**

เรียก [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) บนส่วนเพื่อกรอบนิพจน์ทั้งหมด. [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) ที่ส่งกลับจะแสดงสี่ด้านโดยปกติ. ใช้ [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft), และ [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) เพื่อซ่อนด้านแต่ละด้าน.

ตัวอย่างวางสำเนาหกชุดของส่วนเดียวกันบนสไลด์เดียว. เพื่อแสดงการตัด, ซ่อนสี่ด้านทั้งหมดและส่งค่า `true` ไปยัง [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) สำหรับเส้นทแยงขึ้น (↗) หรือ [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) สำหรับเส้นทแยงลง (↘). คุณยังสามารถใช้ [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) หรือ [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) ร่วมกับด้านที่มองเห็นได้ตามต้องการ.

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

![หกส่วนที่แก้ไขได้ใน PowerPoint. แถวบน: ขอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, ขีดแนวนอน, ขีดแนวตั้งพร้อมขอบเต็ม.](border-box-fractions.png)

บนส่วนนี้, เส้นขีดแนวนอนทับบาร์ส่วน. เส้นขีดแนวตั้งข้ามตัวเศษและส่วนล่างในขณะที่กรอบรอบยังคงมองเห็นได้. เส้นเหล่านี้ประดับนิพจน์ทั้งหมด. การขีดเส้นธรรมดาจะใช้กับอักขระในรันข้อความ. หลังจากเปิดงานนำเสนอใน PowerPoint อีกครั้ง, คุณยังสามารถแก้ไขตัวเศษและส่วนได้อย่างอิสระ.

## **จัดกลุ่มเทอม**

ใช้ [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) เพื่อวางอักขระจัดกลุ่มเหนือหรือใต้นิพจน์. เพิ่มขอบเขตเพื่อระบุเทอมที่จัดกลุ่ม.

![นิพจน์ x + y ที่จัดกลุ่มพร้อมป้าย any text ด้านล่าง](powerpoint-math-equations_15.png)

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

## **จัดรูปแบบองค์ประกอบคณิตศาสตร์**

ใช้ตัวช่วยการจัดรูปแบบเฉพาะเมื่อช่วยให้สูตรชัดเจน. ตัวอย่างเช่น, [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) ใส่บาร์เหนือองค์ประกอบคณิตศาสตร์.

![นิพจน์คณิตศาสตร์ ABC พร้อมบาร์เหนือ](powerpoint-math-equations_14.png)

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

### **จัดรูปแบบข้อความในสมการที่มีอยู่**

เพื่อจัดรูปแบบข้อความทั่วสมการที่มีอยู่, ให้สำรวจต้นไม้ขององค์ประกอบในแต่ละบล็อกคณิตศาสตร์. [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) ให้เฉพาะลูกโดยตรง, ดังนั้นเรียกแบบเรียกซ้ำเพื่อเข้าถึงข้อความในส่วน, ตัวห้อย/ยก, ราก, และโครงสร้างซ้อนอื่น. ตรวจสอบองค์ประกอบปัจจุบันและลูกของมันเพื่อรวมองค์ประกอบเริ่มต้นเมื่อมันเป็น [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/).

ตัวอย่างนี้สมมติว่า `input.pptx` มีสมการเช่น `z = xᵢ / ∛y`, โดยส่วนมีตัวห้อยในตัวเศษและรากในตัวส่วน. การประมวลผลเพียงระดับบนของบล็อกจะพลาดข้อความในส่วน. ตัวอย่างค้นหาส่วนคณิตศาสตร์ในกรอบข้อความสไลด์, เข้าถึงบล็อกผ่าน [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), และใช้ [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) เพื่อตั้งค่าขนาดฟอนต์เป็น 28 จุดผ่านแต่ละองค์ประกอบข้อความโดยใช้เมธอด [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat).

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

งานนำเสนอที่บันทึกไว้มีการอัปเดตรูปแบบข้อความในทุกระดับของแต่ละสมการที่ประมวลผล, พร้อมคงเนื้อหาข้อความและโครงสร้างคณิตศาสตร์เดิม.

## **อ้างอิงอย่างรวดเร็ว**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| รวมองค์ประกอบ | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| สร้างส่วน | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มตัวยกหรือห้อย | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มราก | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มขอบเขต | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มสคริปต์ด้านซ้าย | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มการบวกและอินทิกรัล | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มเครื่องหมายขอบ | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มบาร์และขอบ | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ใช่. เปิดงานนำเสนอ, ค้นหารูปร่างที่บรรจุ [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), เรียก [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), และอัปเดตบล็อกคณิตศาสตร์ในย่อหน้านั้น.

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ใช่. เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office math ที่แก้ไขได้.

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ใช่. รับ [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) จาก [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), แล้วเรียก [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) เพื่อส่งออกโดยตรง. สำหรับตัวอย่างครบถ้วน, ดูที่ [Export Math Equations from Presentations in Node.js via Java](/slides/th/nodejs-java/exporting-math-equations/#export-math-equations-to-latex).