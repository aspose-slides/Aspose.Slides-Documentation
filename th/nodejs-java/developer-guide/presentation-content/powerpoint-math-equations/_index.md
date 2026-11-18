---
title: เพิ่มสมการคณิตศาสตร์ในงานนำเสนอ PowerPoint ด้วย JavaScript
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
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แทรกและแก้ไขสมการคณิตศาสตร์ในไฟล์ PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java รองรับ OMML, การควบคุมการจัดรูปแบบ, และตัวอย่างโค้ด JavaScript ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint เก็บสมการเป็น Office Math Markup Language (OMML) โดยใช้ Aspose.Slides for Node.js ผ่าน Java คุณสามารถสร้างเนื้อหาคณิตศาสตร์แบบเดียวกันโดยอัตโนมัติ: เศษส่วน, ราก, ฟังก์ชัน, ขีด จำกัด, ตัวดำเนินการ N-ary, เมทริกซ์, อาเรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้มักเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint พร้อมคำสั่ง Equation ถูกเลือก](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่สามารถแก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่สามารถแก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านออบเจกต์หลักสามตัว:

- รูปร่างคณิตศาสตร์ที่สร้างด้วย [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) คือรูปร่างที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในเฟรมข้อความของรูปร่าง
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) มีออบเจกต์ [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) หนึ่งหรือหลายออบเจกต์

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) และเมธอดแบบ fluent จาก [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) เพื่อทำให้โค้ดสั้นและอ่านง่าย

สำหรับกรณีการส่งออก MathML ดูที่ [Export Math Equations from Presentations in Node.js via Java](/slides/th/nodejs-java/exporting-math-equations/)

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มทฤษฎีบทพีทาโกรัส:

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
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) สร้างรูปร่างที่มี MathParagraph อยู่แล้ว เข้าถึง [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) ตัวแรก, เรียก [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) แล้วเพิ่ม MathBlock หรือ MathElement ลงไป
{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) เพื่อสร้างเศษส่วน คุณสามารถเลือกสไตล์ของเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/)

![เศษส่วนคณิตศาสตร์เอียงแสดง 1 ÷ x](powerpoint-math-equations_4.png)

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

สำหรับเศษส่วนแบบซ้อนกัน ใช้ [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **เพิ่มราก**

ใช้ [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) เพื่อสร้างรากที่สอง, รากที่สาม หรือรากอื่น ๆ องค์ประกอบปัจจุบันจะกลายเป็นฐานและอาร์กิวเมนต์จะเป็นดีกรี

![นิพจน์รากที่ n‑th โดยมี x อยู่ภายใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

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

### **แสดงหรือซ่อนดีกรีของรากที่สอง**

รากที่สองสามารถแสดงเลข 2 อย่างชัดเจนหรือใช้สัญลักษณ์ √x แบบดั้งเดิม วิธี [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) ของ [MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) ควบคุมรูปแบบที่ปรากฏ ทั้งสองรูปแบบยังคงมีดีกรี 2 และตัว radicand x อยู่ในสมการที่แก้ไขได้

![รากที่สองเดียวกันโดยด้านซ้ายมีดีกรีแสดงและด้านขวาซ่อน](square-root-degree.png)

ตัวอย่างบันทึกรากที่สองเดียวกันสองครั้ง ใน `visible-degree.pptx` ดีกรี 2 แสดงอยู่ ใน `hidden-degree.pptx` ดีกรี 2 ถูกซ่อน

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

## **เพิ่มฟังก์ชันและลิมิต**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) หรือ [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)` หรือชื่อฟังก์ชันที่กำหนดเอง สำหรับลิมิตให้ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) หรือใช้ [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit)

![ลิมิตของ x เมื่อ x เข้าใกล้อนันต์](powerpoint-math-equations_8.png)

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

สำหรับชื่อฟังก์ชันที่กำหนดเอง ทำให้ชื่อฟังก์ชันเป็นองค์ประกอบปัจจุบันและเรียก [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) พร้อมอาร์กิวเมนต์ของมัน:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **เพิ่มตัวดำเนินการ N‑ary และอินทิกรัล**

ใช้ [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) สำหรับผลบวก, union, intersection และตัวดำเนินการใหญ่อื่น ๆ ใช้ [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) สำหรับอินทิกรัล ทั้งสองเมธอดให้ตั้งค่าขีดล่างและขีดบนได้

![ผลบวกที่มีขีดล่างและขีดบน](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N‑ary ใช้สำหรับตัวดำเนินการใหญ่ที่มีขีดเลือกได้ ตัวดำเนินการง่าย ๆ เช่น `+`, `-`, `=` มักเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) และเชื่อมต่อเข้ากับนิพจน์

สำหรับอินทิกรัล ใช้ [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) สำหรับแถวและคอลัมน์ เมทริกซ์โดยค่าเริ่มต้นไม่รวมวงเล็บ ดังนั้นให้ใส่วงเล็บ, ยัติภังค์ หรือเครื่องหมายวงเล็บเมื่อจำเป็น

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

### **แก้ไขเมทริกซ์ที่มีอยู่**

สมมติว่าบทเรียนพีชคณิตเชิงเส้นเริ่มด้วยเมทริกซ์ค่าสัมประสิทธิ์ใน `matrix.pptx` ที่บันทึกโดยตัวอย่างก่อนหน้า สำหรับแบบฝึกหัดต่อไปให้คงสมการแรกไว้, แทนที่สมการที่สองด้วยสองสมการใหม่, และปรับชุดตัวแปร เปิดเมทริกซ์ที่มีอยู่ผ่าน [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) เพื่อคงค่าสัมประสิทธิ์ที่ยังใช้ได้

![เมทริกซ์ค่าสัมประสิทธิ์สองแถวดั้งเดิมที่มีค่า 1, x, เซลล์ว่างในแถวแรกและ x, 2, y ในแถวสอง](matrix-before-edit.png)

ดัชนีแถวและคอลัมน์เริ่มที่ศูนย์และอ้างอิงเมทริกซ์ตามสถานะในแต่ละครั้ง การแทรกแถวก่อนดัชนี 1 จะทำให้แถวที่สองเดิมย้ายไปเป็นดัชนี 2 การแทรกหลังดัชนี 2 จะเพิ่มแถวใหม่ การลบแถว 2 จะลบสมการที่สองเดิมและย้ายแถวที่เพิ่มเข้ามาขึ้นหนึ่งตำแหน่ง คอลัมน์ก็เลื่อนแบบเดียวกัน

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

    // เซลล์ใหม่เริ่มต้นเป็น null. ตั้งค่าสัมประสิทธิ์ที่ไม่เป็นศูนย์ก่อน.
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

[setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment) จัดแนวคอลัมน์แรกไปทางซ้าย [setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment) จัดแนวสามคอลัมน์ต่อเนื่องไปทางขวา ตั้งแต่ดัชนี 1 ใน `updated-matrix.pptx` เมทริกซ์มีสามสมการและสี่ตัวแปร ค่าสัมประสิทธิ์แถวแรก `1` และ `x` ปรากฏในคอลัมน์แรกและคอลัมน์ที่สาม

![เมทริกซ์สามแถวที่อัปเดตโดยแสดงแถว 1, 0, x, 0; 12, 1, 0, 0; และ 0, 0, 10, 1](matrix-after-edit.png)

## **เพิ่มอาเรย์สมการ**

ใช้ [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray) เมื่อคุณต้องการสมการที่จัดแนวกันหรือต้องการจัดเรียงแนวตั้งของนิพจน์หลาย ๆ ตัว

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

### **จัดแนวอาเรย์กับองค์ประกอบโดยรอบ**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) ควบคุมการจัดแนวแนวตั้งของอาเรย์เมื่อเทียบกับองค์ประกอบคณิตศาสตร์ที่อยู่ข้าง ๆ ตัวอย่างต่อไปนี้เปรียบเทียบการจัดแนวโดยใช้แถวแรก, ศูนย์กลางของอาเรย์, และแถวสุดท้าย

ตัวอย่างต่อไปนี้สร้างอาเรย์สามชุดที่เหมือนกัน แต่ละชุดมีสามแถวและองค์ประกอบใกล้เคียง `A=` และ `=B` ข้อความคณิตศาสตร์ทั้งหมดใช้ฟอนต์ Cambria Math ขนาด 24 pt มีเพียงการจัดแนวอาเรย์ที่เปลี่ยน

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

การเปรียบเทียบต่อไปนี้แสดงงานนำเสนอที่บันทึกใน PowerPoint สังเกตตำแหน่งของ `A=` และ `=B` ใกล้อาเรย์แต่ละอัน

![อาเรย์สมการใน PowerPoint กับการจัดแนวด้านบน, กลาง, และด้านล่าง พร้อมองค์ประกอบใกล้เคียงเดียวกัน](equation-array-alignment.png)

### **กำหนดค่าระยะห่างแถว**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) เลือกกฎการเว้นระยะสำหรับแถวภายในอาเรย์ [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) ให้ค่าตัวเลขสำหรับกฎการเว้นระยะเชิงกำหนดและจะถูกละเลยเมื่อใช้กฎสำเร็จรูป

สำหรับการเว้นระยะที่แน่นอนค่าจะวัดเป็น point สำหรับการเว้นระยะแบบสัดส่วนค่าจะวัดเป็นครึ่งบรรทัด: ค่า `3` ในตัวอย่างหมายถึง 1.5 บรรทัด ตั้งค่าทั้งสองคุณสมบัติเมื่อระบุมูลค่าเชิงกำหนด; การเปลี่ยนค่าเชิงตัวเลขอย่างเดียวจะไม่เลือกกฎการเว้นระยะ

ตัวอย่างด้านล่างบันทึกงานนำเสนอห้าชุดที่มีสมการเดียวกัน การจัดแนวเดียวกันและการตั้งค่าฟอนต์เดียวกัน สามชุดแรกใช้ค่าพรีเซ็ต สองชุดสุดท้ายใช้ค่าที่กำหนดอย่างชัดเจน

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

การเว้นระยะแถวของอาเรย์แยกจากการเว้นระยะของย่อหน้า [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) และ [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) เพิ่มช่องว่างรอบย่อหน้าที่บรรจุอาเรย์ ไม่ได้เพิ่มช่องว่างระหว่างแถวของอาเรย์เช่นเดียวกัน [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) จัดตำแหน่งแนวนอนของ MathParagraph ทั้งหมด; ไม่ได้แทนที่การตั้งค่าการจัดแนวแนวตั้งของอาเรย์

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) เมื่ออาร์กิวเมนต์เป็นองค์ประกอบปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบ

![ฟังก์ชันตรีโกณมิติ cos ใส่กับ 2x](powerpoint-math-equations_6.png)

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

ใช้ตัวช่วยสำหรับตัวห้อยและตัวยกเพื่อกำหนดดัชนีและกำลัง เมื่อดัชนีต้องแสดงทางด้านซ้ายของฐาน ให้ใช้ [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)

![ตัวอักษร Y ตัวพิมพ์ใหญ่ที่มีตัวห้อยด้านซ้าย 1 และตัวยก n](powerpoint-math-equations_9.png)

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

## **เพิ่มเครื่องหมายคั่น**

ใช้ [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) เพื่อใส่นิพจน์ไว้ในเครื่องหมายคั่น คุณยังสามารถตั้งค่าตัวอักษรคั่นสำหรับนิพจน์ที่มีหลายองค์ประกอบได้

![นิพจน์ที่มีเครื่องหมายคั่นรวม x, y, และ z แยกด้วยแถบแนวตั้ง](powerpoint-math-equations_13.png)

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

### **กำหนดขนาดและการจัดแนวเครื่องหมายคั่น**

ส่งค่า `true` ไปยัง [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) เพื่อให้วงเล็บขยายตามความสูงของออปเพอแรนด์ที่สูง หรือส่งค่า `false` เพื่อคงขนาดปกติ ใช้ [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) ร่วมกับค่าใดค่าหนึ่งของ [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) `Centered` ทำให้วงเล็บอยู่กึ่งกลางแกนคณิตศาสตร์ซึ่งวิ่งผ่านเครื่องหมายเท่ากลาง `Match` จัดแนวให้ตรงกับเนื้อหาที่ล้อมรอบ ทั้งสองการตั้งค่าใช้กับเครื่องหมายคั่นเท่านั้น นิพจน์ภายในคงเดิม

ตัวอย่างวางเศษส่วนในเลขชี้กำลังของ `x` ทำให้นิพจน์ขยายเหนือเส้นฐานมากกว่าข้างล่าง ทั้งสี่สมการใช้วงเล็บและการตั้งค่าฟอนต์เดียวกัน

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

ใน PowerPoint ให้เปรียบเทียบแถวต่าง ๆ เพื่อดูผลของการขยาย ในแถวบน วงเล็บขยายเพื่อครอบคลุมเลขชี้กำลังและดูเหมือนกันสำหรับสองรูปแบบ ในแถวล่าง การขยายถูกปิด วงเล็บเล็กทางซ้าย (`Centered`) จัดแนวกับเครื่องหมายเท่า ส่วนวงเล็บทางขวา (`Match`) ยกสูงขึ้นรอบนิพจน์

![สี่สมการใน PowerPoint โดยมีการขยายเครื่องหมายคั่นเปิดในแถวบนและปิดในแถวล่าง, `Centered` ทางซ้ายและ `Match` ทางขวา](delimiter-sizing.png)

## **เพิ่มกล่องขอบ**

เรียก [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) บนเศษส่วนเพื่อทำให้ทั้งนิพจน์มีกรอบ [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) แสดงสี่ด้านโดยค่าเริ่มต้น ใช้ [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft), และ [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) เพื่อลบด้านที่ต้องการ

ตัวอย่างวางสำเนาเดียวกันของเศษส่วนหกชุดบนสไลด์เดียว เพื่อแสดงการยกเลิก ให้ซ่อนสี่ด้านทั้งหมดและส่งค่า `true` ไปยัง [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) เพื่อสร้างเส้นทแยงมุมขึ้น (`↗`) หรือ [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) เพื่อสร้างเส้นทแยงมุมลง (`↘`) คุณยังสามารถใช้ [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) หรือ [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) ร่วมกับการแสดงด้านใดด้านหนึ่งตามต้องการ

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

![หกเศษส่วนที่แก้ไขได้ใน PowerPoint แถวบน: กรอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, เส้นขีดแนวนอน, เส้นขีดแนวตั้งพร้อมกรอบเต็ม](border-box-fractions.png)

บนเศษส่วนนี้ เส้นขีดแนวนอนซ้อนทับกับบาร์ของเศษส่วน เส้นขีดแนวตั้งตัดผ่านตัวเศษและตัวส่วนพร้อมกรอบรอบข้างยังคงมองเห็นได้ เส้นเหล่านี้ประดับให้กับนิพจน์ทั้งหมด ขีดเส้นข้อความทั่วไปจะใช้กับอักขระในรันข้อความ หลังจากเปิดงานนำเสนอใหม่ใน PowerPoint คุณยังสามารถแก้ไขตัวเศษและตัวส่วนแยกกันได้

## **ควบคุมการมองเห็นและการจัดวางด้วยองค์ประกอบ Phantom**

ห่อหุ้มนิพจน์ด้วย [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) เพื่อควบคุมการมองเห็นและพื้นที่ที่มันใช้ในสมการโดยอิสระ วิธีของ [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) ควบคุมดังนี้

| Method | Effect |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | ส่งค่า `false` เพื่อซ่อนนิพจน์ มิติต่าง ๆ ยังคงมีผลต่อการจัดวางเว้นแต่เมธอดต่อไปนี้ได้รับค่า `true` |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | ปรับความกว้างแนวนอนของนิพจน์เป็นศูนย์ ทำให้องค์ประกอบข้างเคียงเคลื่อนเข้ามาใกล้กัน |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | ปรับค่า ascent (ความสูงเหนือ baseline) เป็นศูนย์ เพื่อลดพื้นที่ด้านบนขององค์ประกอบข้างเคียง |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | ปรับค่า descent (ความลึกใต้ baseline) เป็นศูนย์ ทำให้บาร์ของเศษส่วนหรือเนื้อหาอื่น ๆ ใต้นิพจน์เคลื่อนเข้ามาใกล้กว่าเดิม |

Baseline คือเส้นอ้างอิงที่ตัวอักษรคณิตศาสตร์ปกติวางบนมัน การซ่อนเนื้อหาไม่ได้ลบมิติของมันออก และการตั้งค่ามิติเป็นศูนย์ไม่ได้ลบนิพจน์ออก นิพจน์พื้นฐานยังคงเข้าถึงได้ผ่าน [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase) ส่งค่า `true` ไปยัง [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) เพื่อแสดงอีกครั้ง; การตั้งค่ามิติจะคงเดิม

ตัวอย่างด้านล่างสร้างห้าแบบข้างเคียงกัน: เศษส่วนที่มองเห็นได้, เศษส่วนที่ซ่อนแต่จองพื้นที่, และสามเศษส่วนที่ซ่อนโดยตั้งค่ามิติเป็นศูนย์แต่ละแบบใช้นิพจน์รอบข้างเดียวกันและฟอนต์ Cambria Math ขนาด 24 pt รูปร่างสมการทั้งหมดมีตำแหน่งบนเดียวกันที่บันทึกด้วยเส้นนำสีเทา การใส่ phantom ไว้ในตัวเศษของเศษส่วนภายนอกทำให้การเปลี่ยนแปลงการจัดวางแนวตั้งเห็นได้ง่ายขึ้น

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

![ห้าสมการใน PowerPoint เปรียบเทียบเศษส่วนที่มองเห็นได้, เศษส่วนที่ซ่อนแต่จองพื้นที่, และเศษส่วนที่ซ่อนพร้อม ZeroWidth, ZeroAsc หรือ ZeroDesc เปิดใช้งาน](math-phantom.png)

## **จัดกลุ่มเทอม**

ใช้ [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) เพื่อวางอักขระการจัดกลุ่มเหนือหรือใต้นิพจน์ เพิ่มขีดจำกัดเพื่อระบุเทอมที่จัดกลุ่ม

![นิพจน์ x + y ที่จัดกลุ่มโดยมีป้ายกำกับข้อความใด ๆ ใต้มัน](powerpoint-math-equations_15.png)

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

ใช้ตัวช่วยการจัดรูปแบบเฉพาะเมื่อช่วยให้สูตรเข้าใจได้ง่ายขึ้น ตัวอย่างเช่น [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) วางบาร์เหนือองค์ประกอบคณิตศาสตร์

![นิพจน์คณิตศาสตร์ ABC ที่มีบาร์เหนือ](powerpoint-math-equations_14.png)

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

เพื่อจัดรูปแบบข้อความทั่วสมการที่มีอยู่ ให้ไล่ผ่านต้นไม้ของแต่ละ MathBlock [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) จะคืนเฉพาะลูกโดยตรง ดังนั้นให้เรียกแบบเรียกซ้ำจนถึงข้อความภายในเศษส่วน, สคริปต์, ราก, และโครงสร้างซ้อนอื่น ๆ ตรวจสอบองค์ประกอบปัจจุบันและลูกของมันเพื่อรวมองค์ประกอบเริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/)

ตัวอย่างนี้สมมติว่า `input.pptx` มีสมการเช่น `z = xᵢ / ∛y` ซึ่งมีเศษส่วนที่มีตัวห้อยในตัวเศษและรากในตัวส่วน การประมวลผลเฉพาะองค์ประกอบระดับบนของบล็อกจะพลาดข้อความในเศษส่วน ตัวอย่างค้นหาส่วนคณิตศาสตร์ในเฟรมข้อความของสไลด์, เข้าถึงบล็อกผ่าน [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) และใช้ [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) ตั้งขนาดฟอนต์เป็น 28 pt ผ่านเมธอด [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) ของแต่ละองค์ประกอบข้อความ

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

งานนำเสนอที่บันทึกไว้จะมีการอัปเดตการจัดรูปแบบข้อความในทุกระดับของแต่ละสมการที่ประมวลผล โดยยังคงรักษาเนื้อหาและโครงสร้างคณิตศาสตร์ไว้

## **อ้างอิงอย่างเร็ว**

| Task | Main API |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| ผสมผสานองค์ประกอบ | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| สร้างเศษส่วน | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มตัวยกหรือตัวห้อย | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มราก | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มลิมิต | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มสคริปต์ด้านซ้าย | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มผลบวกและอินทิกรัล | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มเครื่องหมายคั่น | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มบาร์และขอบ | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ได้ เปิดงานนำเสนอ ค้นหารูปร่างที่บรรจุ [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), เรียก [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) แล้วอัปเดต MathBlock ในพารากราฟนั้น

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ใช่ เมื่อบันทึกเป็น PPTX Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ใช่ ดึง [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) จาก [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) แล้วเรียก [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) เพื่อส่งออกโดยตรง สำหรับตัวอย่างครบถ้วน ดูที่ [Export Math Equations from Presentations in Node.js via Java](/slides/th/nodejs-java/exporting-math-equations/#export-math-equations-to-latex)