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
description: "แทรกและแก้ไขสมการคณิตศาสตร์ใน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java ที่รองรับ OMML, ควบคุมการจัดรูปแบบ, และตัวอย่างโค้ด JavaScript ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint เก็บสมการเป็น Office Math Markup Language (OMML). ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java คุณสามารถสร้างเนื้อหาคณิตศาสตร์รูปแบบเดียวกันได้โดยเขียนโปรแกรม: ส่วนเศษส่วน, รากลำดับ, ฟังก์ชัน, ลิมิต, ตัวดำเนินการ N-ary, เมทริกซ์, อาร์เรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้โดยปกติจะเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint พร้อมคำสั่ง Equation ที่เลือก](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่สามารถแก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่สามารถแก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านวัตถุหลักสามประเภท:

- รูปแบบคณิตศาสตร์, สร้างด้วย [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape), เป็นรูปแบบที่บรรจุสมการ
- [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปแบบ
- [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) บรรจุหนึ่งหรือหลายวัตถุ [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/)

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) และเมธอด fluent จาก [MathElementBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) เพื่อให้โค้ดย่อและอ่านง่าย

สำหรับกรณีส่งออก MathML ดูที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Node.js ผ่าน Java](/slides/th/nodejs-java/exporting-math-equations/)

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) เพื่อสร้างรูปแบบคณิตศาสตร์และเพิ่มสูตรพีทาโกรัส:

![สมการ c กำลังสองเท่ากับ a กำลังสองบวก b กำลังสอง](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addMathShape) สร้างรูปแบบที่มี MathParagraph อยู่แล้ว เข้าถึง [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) ตัวแรก, เรียก [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph), แล้วเพิ่มบล็อกคณิตศาสตร์หรือองค์ประกอบคณิตศาสตร์เข้าไป
{{% /alert %}}

### **รวมบล็อกคณิตศาสตร์**

เมื่อส่วนของสมการถูกสร้างแยกเป็นวัตถุ [MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/) ให้ใช้ [joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock) เพื่อรวมพวกมัน ตัวอย่างสร้าง `c² =` ในบล็อกซ้ายและ `a² + b²` ในบล็อกขวา [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSuperscript) สร้างตัวเหนือคณิตศาสตร์ที่แก้ไขได้สำหรับพลังทั้งหมดสามตัว

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addMathShape(20, 20, 600, 100);
    const mathPortion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    const mathParagraph = mathPortion.getMathParagraph();

    const leftBlock = new slides.MathBlock();
    leftBlock.add(new slides.MathematicalText("c").setSuperscript("2"));
    leftBlock.add(new slides.MathematicalText("="));

    const rightBlock = new slides.MathBlock();
    rightBlock.add(new slides.MathematicalText("a").setSuperscript("2"));
    rightBlock.add(new slides.MathematicalText("+"));
    rightBlock.add(new slides.MathematicalText("b").setSuperscript("2"));

    const combinedBlock = leftBlock.joinBlock(rightBlock);
    mathParagraph.add(combinedBlock);

    presentation.save("equation.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[joinBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#joinBlock) คืนค่า `leftBlock` เองซึ่งตอนนี้บรรจุส่วนทั้งสองตามลำดับและทำให้ `rightBlock` ว่างเปล่า เพิ่มบล็อกที่รวมแล้วเข้าไปใน [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) เพียงครั้งเดียว หลังจากเปิด `equation.pptx` ใหม่ ย่อหน้าจะมีบล็อกเดียวที่เป็นตัวแทนของ `c² = a² + b²` โดยคงตัวเหนือทั้งสามไว้

การเรียก [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/#add) เป็น `leftBlock.add(rightBlock)` พยายามฝังบล็อกหนึ่งลงในอีกบล็อกหนึ่งโดยตรงและจะส่ง `InvalidOperationException`

## **เพิ่มส่วนเศษส่วน**

ใช้ [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#divide) เพื่อสร้างส่วนเศษส่วน คุณสามารถเลือกสไตล์ส่วนเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/)

![ส่วนเศษส่วนคณิตศาสตร์ที่เอียงแสดงหนึ่งหารด้วย x](powerpoint-math-equations_4.png)

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

สำหรับส่วนเศษส่วนแบบซ้อนกัน ให้ใช้ [MathFractionTypes.Bar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathfractiontypes/#Bar):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let stackedFraction = new aspose.slides.MathematicalText("x + 1").divide("y - 1", aspose.slides.MathFractionTypes.Bar);
```

## **เพิ่มรูท**

ใช้ [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#radical) เพื่อสร้างรากกำลังสอง, รากกำลังสาม หรือรากอื่น ๆ องค์ประกอบปัจจุบันจะกลายเป็นฐานและอาร์กิวเมนต์จะเป็นดีกรี

![นิพจน์รูทลำดับที่ n โดยมี x อยู่ใต้สัญลักษณ์รูท](powerpoint-math-equations_5.png)

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

### **แสดงหรือซ่อนดีกรีของรากกำลังสอง**

รากกำลังสองสามารถแสดงเลข 2 อย่างชัดเจนหรือใช้สัญลักษณ์ √x ตามปกติ [setHideDegree](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/#setHideDegree) ของ [MathRadical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathradical/) ควบคุมรูปแบบที่จะปรากฏ ทั้งสองรูปแบบคงดีกรี 2 และตัว radicand x ไว้ในสมการที่แก้ไขได้

![รากกำลังสองเดียวกันที่ด้านซ้ายแสดงดีกรีและด้านขวาซ่อนดีกรี](square-root-degree.png)

ตัวอย่างบันทึกรากกำลังสองเดียวกันสองครั้ง ใน `visible-degree.pptx` ดีกรี 2 แสดงผล ใน `hidden-degree.pptx` ดีกรีถูกซ่อน

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

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction) หรือ [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)`, หรือชื่อฟังก์ชันกำหนดเอง สำหรับลิมิต ใส่ `lim` เข้าใน [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathlimit/) หรือใช้ [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setLowerLimit)

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

สำหรับชื่อฟังก์ชันกำหนดเอง ทำให้ชื่อฟังก์ชันเป็นองค์ประกอบปัจจุบันและเรียก [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#function) พร้อมอาร์กิวเมนต์ของมัน:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let customFunction = new aspose.slides.MathematicalText("f").function("x + 1");
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิกรัล**

ใช้ [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#nary) สำหรับผลบวก, ยูเนียน, อินเตอร์เซคชัน และตัวดำเนินการขนาดใหญ่อื่น ๆ ใช้ [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral) สำหรับอินทิกรัล ทั้งสองเมธอดให้คุณตั้งลิมิตล่างและลิมิตบน

![การบวกแบบรวมที่มีลิมิตล่างและลิมิตบน](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N-ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่มีลิมิตแบบเลือกได้ ตัวดำเนินการง่าย ๆ เช่น `+`, `-`, `=` มักเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) และต่อเข้ากับนิพจน์

สำหรับอินทิกรัล ให้ใช้ [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#integral):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let integralBase = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
let integral = integralBase.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) สำหรับแถวและคอลัมน์ เมทริกซ์โดยค่าเริ่มต้นไม่มีวงเล็บ ดังนั้นให้ใส่วงเล็บหรือวงโค้งเมื่อต้องการ

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

สมมติว่าบทเรียนพีชคณิตเชิงเส้นเริ่มด้วยเมทริกซ์สัมประสิทธิ์ใน `matrix.pptx` ตามตัวอย่างก่อนหน้า สำหรับแบบฝึกหัดต่อไป ให้คงสมการแรกไว้, แทนที่สมการที่สองด้วยสมการใหม่สองสมการ, และปรับชุดตัวแปร เปิดเมทริกซ์ที่มีอยู่ผ่าน [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) เพื่อคงสัมประสิทธิ์ที่ยังใช้ได้

![เมทริกซ์สัมประสิทธิ์สองแถวดั้งเดิมที่มีค่า 1, x, และเซลล์ว่างในแถวแรก และ x, 2, y ในแถวที่สอง](matrix-before-edit.png)

ดัชนีแถวและคอลัมน์เริ่มที่ศูนย์และอ้างอิงเมทริกซ์ตามสภาพ ณ เวลาแต่ละการเรียก แทรกแถวก่อนดัชนี 1 จะย้ายแถวที่สองเดิมไปเป็นดัชนี 2 แทรกหลังดัชนี 2 แล้วเพิ่มแถวใหม่ การลบแถว 2 จะลบสมการที่สองเดิมและย้ายแถวที่เพิ่มขึ้นไปหนึ่งตำแหน่ง คอลัมน์ก็เปลี่ยนเช่นกัน

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

    // เซลล์ใหม่เริ่มต้นเป็น null. ตั้งค่าสัมประสิทธิ์ที่ไม่เป็นศูนย์ก่อน
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

[setColumnAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnAlignment) จัดแนวคอลัมน์แรกไปทางซ้าย [setColumnsAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/#setColumnsAlignment) จัดแนวสามคอลัมน์ต่อเนื่องไปทางขวาตั้งแต่ดัชนี 1 ใน `updated-matrix.pptx` เมทริกซ์มีสามสมการและสี่ตัวแปร สัมประสิทธิ์แถวแรกเดิม `1` และ `x` ปรากฏในคอลัมน์แรกและคอลัมน์ที่สาม

![เมทริกซ์สามแถวที่อัปเดตแสดงแถว 1, 0, x, 0; 12, 1, 0, 0; และ 0, 0, 10, 1](matrix-after-edit.png)

## **เพิ่มอาร์เรย์สมการ**

เมื่อคุณต้องการสมการที่เรียงแนวหรือสแต็กแนวตั้งของนิพจน์ ให้ใช้ [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toMathArray)

![อาร์เรย์คณิตศาสตร์แนวตั้งที่มี x อยู่เหนือ y](powerpoint-math-equations_11.png)

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

### **จัดแนวอาร์เรย์กับองค์ประกอบรอบข้าง**

[setBaseJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setBaseJustification) ควบคุมการจัดแนวแนวตั้งของอาร์เรย์เทียบกับองค์ประกอบคณิตศาสตร์ข้างเคียง ตัวอย่างเปรียบเทียบการจัดแนวกับแถวแรก, ศูนย์ของอาร์เรย์, และแถวสุดท้าย

ตัวอย่างต่อไปสร้างอาร์เรย์สามชุดที่เหมือนกัน แต่ละชุดมีสามแถวและองค์ประกอบเพื่อนบ้าน `A=` และ `=B` ข้อความคณิตศาสตร์ทั้งหมดใช้ฟอนต์ Cambria Math ขนาด 24 pt มีเพียงการจัดแนวอาร์เรย์ที่เปลี่ยน

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

การเปรียบเทียบต่อไปแสดงการนำเสนอที่บันทึกไว้ใน PowerPoint สังเกตตำแหน่งของ `A=` และ `=B` ข้างแต่ละอาร์เรย์

![อาร์เรย์สมการใน PowerPoint ที่มีการจัดแนวบน, กลาง, และล่างพร้อมองค์ประกอบข้างเคียงที่เหมือนกัน](equation-array-alignment.png)

### **กำหนดระยะระหว่างแถว**

[setRowSpacingRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacingRule) เลือกกฎระยะห่างระหว่างแถวในอาร์เรย์ [setRowSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/matharray/#setRowSpacing) ให้ค่าตัวเลขสำหรับกฎระยะห่างที่ชัดเจนและจะถูกละเลยเมื่อใช้กฎ preset

สำหรับระยะห่างที่แน่นอน ค่าจะวัดเป็นจุด สำหรับระยะห่างสัดส่วน ค่าจะวัดเป็นครึ่งบรรทัด: ค่า `3` ในตัวอย่างหมายถึง 1.5 บรรทัด ตั้งค่าทั้งสองคุณสมบัติเมื่อต้องการค่าที่ชัดเจน; การเปลี่ยนค่าเลขอย่างเดียวไม่เลือกกฎระยะ

ตัวอย่างต่อไปบันทึกงานนำเสนอห้าชุดที่มีสมการ, การจัดแนว, และการตั้งค่าฟอนต์เหมือนกัน สามชุดแรกใช้ preset; สองชุดสุดท้ายแสดงค่าชัดเจน

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

ระยะห่างแถวของอาร์เรย์แยกจากระยะห่างของย่อหน้า [setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) และ [setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter) เพิ่มระยะรอบย่อหน้า ไม่ใช่ระหว่างแถวอาร์เรย์ เช่นเดียวกัน [MathParagraph.setJustification](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#setJustification) กำหนดตำแหน่งแนวนอนของย่อหน้าคณิตศาสตร์ทั้งหมด; ไม่ได้แทนที่การตั้งค่าการจัดแนวแนวตั้งของอาร์เรย์

## **เพิ่มฟังก์ชันตรีโกณมิติ**

เมื่ออาร์กิวเมนต์เป็นองค์ประกอบปัจจุบันและรู้ชื่อฟังก์ชัน ให้ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#asArgumentOfFunction)

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

## **เพิ่มตัวห้อยและตัวเหนือ**

ใช้ตัวช่วยสำหรับตัวห้อยและตัวเหนือเพื่อแสดงดัชนีและพลังงานเมื่อดัชนีต้องอยู่ทางซ้ายของฐาน ให้ใช้ [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft)

![ตัว Y พิมพ์ใหญ่ที่มีตัวห้อยด้านซ้าย 1 และตัวเหนือ n](powerpoint-math-equations_9.png)

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

## **เพิ่มตัวคั่น**

ใช้ [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#enclose) เพื่อใส่นิพจน์ในตัวคั่น คุณยังสามารถตั้งค่าตัวคั่นแยกสำหรับนิพจน์ที่มีหลายองค์ประกอบได้

![นิพจน์ตัวคั่นที่ประกอบด้วย x, y, และ z ที่คั่นด้วยบาร์แนวตั้ง](powerpoint-math-equations_13.png)

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

### **ขนาดและการจัดแนวตัวคั่น**

ส่ง `true` ให้ [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) เพื่อให้วงเล็บขยายตามออปเดรนด์สูง, หรือส่ง `false` เพื่อคงขนาดปกติ ใช้ [setDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimiter/#setDelimiterShape) กับค่าหนึ่งจาก [MathDelimiterShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathdelimitershape/) `Centered` จัดตำแหน่งวงเล็บกึ่งกลางแกนคณิตศาสตร์ที่ผ่านสัญลักษณ์เท่ากับ `Match` จัดตำแหน่งให้สอดคล้องกับเนื้อหาที่ห่อหุ้ม ทั้งสองตั้งค่าใช้ได้เฉพาะกับตัวคั่น ส่วนนิพจน์ภายในคงเดิม

ตัวอย่างใส่ส่วนเศษส่วนในดีกรีของ `x` ทำให้นิพจน์ขยายสูงกว่าฐานมากกว่าเดิม ทั้งสี่สมการใช้วงเล็บและการตั้งค่าฟอนต์เดียวกัน

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

ใน PowerPoint ให้เปรียบเทียบแถวเพื่อดูผลของการขยาย แถวบนวงเล็บขยายเพื่อห่อดีกรีและดูเหมือนกันสำหรับทั้งสองรูปร่าง แถวล่างการขยายปิด ตัววงเล็บเล็กซ้าย (`Centered`) จัดตำแหน่งกับสัญลักษณ์เท่ากัน, ส่วนขวา (`Match`) อยู่สูงกว่าอยู่รอบนิพจน์

![สี่สมการใน PowerPoint ที่เปิดการขยายตัวคั่นด้านบนและปิดด้านล่าง, และ Centered ด้านซ้ายและ Match ด้านขวา](delimiter-sizing.png)

## **เพิ่มกรอบขอบ**

เรียก [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#toBorderBox) บนส่วนเศษส่วนเพื่อกรอบนิพจน์ทั้งหมด [MathBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/) จะแสดงสี่ด้านโดยค่าเริ่มต้น ใช้ [setHideTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideLeft), และ [setHideRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setHideRight) เพื่อลบด้านเฉพาะ

ตัวอย่างวางส่วนเศษส่วนแบบเดียวกันหกครั้งบนสไลด์เดียว เพื่อแสดงการยกเลิก ให้ซ่อนสี่ด้านและส่ง `true` ไปที่ [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) เพื่อสร้างเส้นทแยงขึ้น (↗) หรือ [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) เพื่อสร้างเส้นทแยงลง (↘) คุณยังสามารถใช้ [setStrikethroughHorizontal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) หรือ [setStrikethroughVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathborderbox/#setStrikethroughVertical) พร้อมการผสมผสานด้านที่มองเห็น

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

![หกส่วนเศษส่วนที่สามารถแก้ไขได้ใน PowerPoint. แถวบน: กรอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, เส้นขีดแนวนอน, เส้นขีดแนวตั้งกับกรอบเต็ม](border-box-fractions.png)

บนส่วนนี้ เส้นขีดแนวนอนทับบาร์ส่วนเศษส่วน เส้นขีดแนวตั้งตัดทั้งตัวเศษและตัวส่วนในขณะที่กรอบโดยรอบยังคงมองเห็นได้ เส้นเหล่านี้ตกแต่งนิพจน์ทั้งหมด การขีดเส้นทางปกติใช้กับอักขระในรันข้อความ หลังจากเปิดงานนำเสนอใน PowerPoint อีกครั้ง คุณยังแก้ไขตัวเศษและตัวส่วนแยกกันได้

## **ควบคุมการมองเห็นและการจัดวางด้วยองค์ประกอบ Phantom**

ห่อใส่นิพจน์ใน [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) เพื่อควบคุมการมองเห็นและพื้นที่ที่มันทำให้สมการเปลี่ยนแปลงโดยอิสระ วิธีการของ [MathPhantom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/) ควบคุมดังต่อไปนี้

| วิธี | ผล |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) | ส่ง `false` เพื่อซ่อนนิพจน์ มิติยังคงมีผลต่อการจัดวางจนกว่าจะมีการตั้งค่า `true` ในเมธอดที่เกี่ยวข้องด้านล่าง |
| [setZeroWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroWidth) | ปฏิบัติตามความกว้างแนวนอนของนิพจน์เป็นศูนย์ ทำให้องค์ประกอบข้างเคียงเคลื่อนเข้าใกล้กัน |
| [setZeroAsc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroAsc) | ปฏิบัติตามความสูงเหนือบรรทัดของนิพจน์เป็นศูนย์ ซึ่งสามารถลดพื้นที่ที่สงวนไว้เหนือองค์ประกอบใกล้เคียง |
| [setZeroDesc](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setZeroDesc) | ปฏิบัติตามความลึกต่ำกว่าบรรทัดของนิพจน์เป็นศูนย์ ซึ่งอาจทำให้บาร์ส่วนเศษส่วนหรือเนื้อหาอื่น ๆ ใต้นิพจน์เข้ามาใกล้กับเพื่อนร่วมกันมากขึ้น |

Baseline คือเส้นอ้างอิงที่ตัวอักษรคณิตศาสตร์ปกติวางอยู่ การซ่อนเนื้อหาไม่ได้ลบมิติออก และการตั้งค่ามิติเป็นศูนย์ไม่ได้ลบนิพจน์ออก นิพจน์พื้นฐานยังคงเข้าถึงได้ผ่าน [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#getBase) ส่ง `true` ไปที่ [setShow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathphantom/#setShow) เพื่อแสดงอีกครั้ง; การตั้งค่ามิติก็ยังคงเหมือนเดิม

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

![ห้าสมการใน PowerPoint เปรียบเทียบส่วนเศษส่วนที่มองเห็น, ส่วนเศษส่วนที่ซ่อนแต่เก็บพื้นที่, และส่วนเศษส่วนที่ซ่อนพร้อม ZeroWidth, ZeroAsc หรือ ZeroDesc ทำงาน](math-phantom.png)

## **จัดกลุ่มเทอม**

ใช้ [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#group) เพื่อวางอักขระการจัดกลุ่มเหนือหรือใต้นิพจน์ เพิ่มลิมิตเพื่อทำป้ายให้กับเทอมที่จัดกลุ่ม

![นิพจน์ x บวก y ที่จัดกลุ่มและมีป้าย any text ด้านล่าง](powerpoint-math-equations_15.png)

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

ใช้ตัวช่วยจัดรูปแบบเฉพาะที่ทำให้สูตรชัดเจน ตัวอย่างเช่น [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#overbar) ใส่บาร์เหนือองค์ประกอบคณิตศาสตร์

![นิพจน์คณิตศาสตร์ ABC ที่มีเส้นบาร์เหนือ](powerpoint-math-equations_14.png)

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

เพื่อจัดรูปแบบข้อความทั่วสมการที่มีอยู่ ให้วนผ่านต้นไม้ขององค์ประกอบแต่ละบล็อกคณิตศาสตร์ [MathElementBase.getChildren](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/#getChildren) คืนค่าเฉพาะลูกโดยตรง จึงต้องเรียกอย่างวนซ้ำเพื่อเข้าถึงข้อความภายในส่วนเศษส่วน, สคริปต์, รากลำดับ, และโครงสร้างซ้อนอื่น ๆ ตรวจสอบองค์ประกอบปัจจุบันและลูกของมันเพื่อรวมองค์ประกอบเริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/)

ตัวอย่างสมมติว่า `input.pptx` มีสมการเช่น `z = xᵢ / ∛y` โดยส่วนเศษส่วนมีตัวห้อยในตัวเศษและรูทในตัวส่วน การประมวลผลเฉพาะองค์ประกอบระดับบนของบล็อกจะพลาดข้อความภายในส่วนเศษส่วน ตัวอย่างค้นหาส่วนคณิตศาสตร์ในกรอบข้อความของสไลด์ เข้าถึงบล็อกผ่าน [MathPortion.getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) แล้วใช้ [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) ตั้งขนาดฟอนต์เป็น 28 pt ผ่านเมธอด [getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/#getFormat) ของแต่ละข้อความ

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

งานนำเสนอที่บันทึกไว้จะมีการจัดรูปแบบข้อความที่อัปเดตที่ทุกระดับของสมการที่ประมวลผลไว้ โดยคงเนื้อหาและโครงสร้างคณิตศาสตร์ไว้

## **อ้างอิงอย่างรวดเร็ว**

| งาน | Main API |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathematicaltext/) |
| รวมองค์ประกอบ | [join](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| สร้างส่วนเศษส่วน | [divide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มตัวเหนือหรือห้อย | [setSuperscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มรูท | [radical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มลิมิต | [setLowerLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มสคริปต์ด้านซ้าย | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มผลบวกและอินทิกรัล | [nary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathmatrix/) |
| เพิ่มอาร์เรย์สมการ | [toMathArray](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มตัวคั่น | [enclose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| เพิ่มบาร์และกรอบ | [overbar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathelementbase/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ได้ คุณเปิดงานนำเสนอ ค้นหารูปแบบที่บรรจุ [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/), เรียก [getMathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/#getMathParagraph) และอัปเดตบล็อกคณิตศาสตร์ในย่อหนนนั้น

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ใช่ เมื่อบันทึกเป็น PPTX Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ได้ รับ [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) ของสมการจาก [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) แล้วเรียก [MathParagraph.toLatex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/#toLatex) เพื่อส่งออกโดยตรง ดูตัวอย่างเต็มที่ [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอใน Node.js ผ่าน Java](/slides/th/nodejs-java/exporting-math-equations/#export-math-equations-to-latex)