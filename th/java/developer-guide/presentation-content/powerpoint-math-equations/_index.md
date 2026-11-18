---
title: เพิ่มสมการคณิตศาสตร์ไปยังงานนำเสนอ PowerPoint ใน Java
linktitle: สมการคณิตศาสตร์ PowerPoint
type: docs
weight: 80
url: /th/java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "แทรกและแก้ไขสมการคณิตศาสตร์ใน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ Java รองรับ OMML การควบคุมรูปแบบ และตัวอย่างโค้ด Java ที่ชัดเจน."
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการเป็น Office Math Markup Language (OMML) ด้วย Aspose.Slides for Java คุณสามารถสร้างเนื้อหาทางคณิตศาสตร์ในรูปแบบเดียวกันโดยโปรแกรม: เศษส่วน, ราก, ฟังก์ชัน, ขีดจำกัด, ตัวดำเนินการ N-ary, เมทริกซ์, อาร์เรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้ทั่วไปเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint พร้อมคำสั่ง Equation ที่เลือก](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่แก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่แก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านสามอ็อบเจกต์หลัก:

- รูปร่างคณิตศาสตร์, สร้างด้วย [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-), เป็นรูปร่างที่บรรจุสมการ.
- [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) จัดเก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปร่าง.
- [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) มีหนึ่งหรือหลายอ็อบเจกต์ [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/) 

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) และเมธอดแบบ fluent จาก [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/) เพื่อให้โค้ดสั้นและอ่านง่าย

สำหรับกรณีการส่งออก MathML, ดู [ส่งออกสมการคณิตศาสตร์จากการนำเสนอใน Java](/slides/th/java/exporting-math-equations/).

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มทฤษฎีพีทากอรัส:

![สมการ c² = a² + b²](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) สร้างรูปร่างที่มี MathParagraph อยู่แล้ว. เข้าถึง [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) ตัวแรก, เรียก [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), และเพิ่ม MathBlock หรือ MathElement เข้าไป.
{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) เพื่อสร้างเศษส่วน. คุณสามารถเลือกสไตล์ของเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/).

![เศษส่วนคณิตศาสตร์เอียงที่แสดง 1 หาร x](powerpoint-math-equations_4.png)

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

สำหรับเศษส่วนแบบซ้อนกัน, ใช้ [MathFractionTypes.Bar](https://reference.aspose.com/slides/java/com.aspose.slides/mathfractiontypes/#Bar):

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **เพิ่มราก**

ใช้ [radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) เพื่อสร้างรูทกำลังสอง, รูทกำลังสาม หรือรูทอื่น ๆ. อิลิเมนต์ปัจจุบันจะเป็นฐาน, และอาร์กูเมนต์จะเป็นดีกรี.

![นิพจน์รูทระดับ n ที่มี x อยู่ใต้เครื่องหมายราก](powerpoint-math-equations_5.png)

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

### **แสดงหรือซ่อนดีกรีของรูทกำลังสอง**

รูทกำลังสองสามารถแสดงเลข 2 อย่างชัดเจนหรือใช้สัญลักษณ์ √x ตามปกติ. เมธอด [setHideDegree](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/#setHideDegree-boolean-) ของ [IMathRadical](https://reference.aspose.com/slides/java/com.aspose.slides/imathradical/) ควบคุมว่าจะใช้รูปแบบใด. ทั้งสองรูปแบบยังคงดีกรี 2 และฐาน x ไว้ในสมการที่แก้ไขได้.

![รูทกำลังสองเดียวกันโดยดีกรีแสดงด้านซ้ายและซ่อนด้านขวา](square-root-degree.png)

ตัวอย่างบันทึกรูทกำลังสองเดียวกันสองครั้ง. ใน `visible-degree.pptx`, 2 แสดง. ใน `hidden-degree.pptx`, 2 ถูกซ่อน.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IMathRadical radical = new MathematicalText("x").radical("2");

    IAutoShape shape = slide.getShapes().addMathShape(20, 20, 200, 100);
    IMathPortion portion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getMathParagraph().add(new MathBlock(radical));

    radical.setHideDegree(false);
    presentation.save("visible-degree.pptx", SaveFormat.Pptx);

    radical.setHideDegree(true);
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มฟังก์ชันและขีดจำกัด**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) หรือ [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)`, หรือชื่อฟังก์ชันที่กำหนดเอง. สำหรับขีดจำกัด, ใส่ `lim` ใน [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/mathlimit/) หรือใช้ [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-).

![ขีดจำกัดของ x เมื่อ x ใกล้อนันต์](powerpoint-math-equations_8.png)

```java
import com.aspose.slides.*;

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

สำหรับชื่อฟังก์ชันที่กำหนดเอง, ตั้งชื่อฟังก์ชันเป็นอิลิเมนต์ปัจจุบันและเรียก [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) พร้อมอาร์กูเมนต์ของมัน:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิกรัล**

ใช้ [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) สำหรับผลบวก, ยูเนียน, อินเทอร์เซคชัน, และตัวดำเนินการขนาดใหญ่อื่น ๆ. ใช้ [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) สำหรับอินทิกรัล. ทั้งสองวิธีให้คุณตั้งค่าขีดจำกัดล่างและบน.

![ผลบวกที่มีขีดจำกัดล่างและบน](powerpoint-math-equations_7.png)

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

ตัวดำเนินการ N-ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่มีขีดจำกัดเป็นตัวเลือก. ตัวดำเนินการง่ายเช่น `+`, `-`, และ `=` มักเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) และรวมเข้ากับนิพจน์.

สำหรับอินทิกรัล, ใช้ [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-):

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **เพิ่มเมทริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) สำหรับแถวและคอลัมน์. เมทริกซ์โดยค่าเริ่มต้นไม่มีวงเล็บ, ดังนั้นใส่วงเล็บเมื่อคุณต้องการวงกลม, วงเหลี่ยม, หรือวงเล็บปีกกา.

![เมทริกซ์คณิตศาสตร์สองแถวที่มีเซลล์ว่างหนึ่งช่อง](powerpoint-math-equations_10.png)

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

## **เพิ่มอาร์เรย์สมการ**

ใช้ [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) เมื่อคุณต้องการสมการที่จัดแนวหรือสแตกแนวตั้งของนิพจน์.

![อาร์เรย์คณิตศาสตร์แนวตั้งที่มี x อยู่เหนือ y](powerpoint-math-equations_11.png)

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

### **จัดแนวอาร์เรย์กับอิลิเมนต์โดยรอบ**

[setBaseJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setBaseJustification-int-) ควบคุมการจัดแนวแนวตั้งของอาร์เรย์สัมพันธ์กับอิลิเมนต์คณิตศาสตร์ข้าง ๆ. ตัวอย่างด้านล่างเปรียบเทียบการจัดแนวกับแถวแรก, ศูนย์กลางของอาร์เรย์, และแถวสุดท้าย.

ตัวอย่างต่อไปสร้างอาร์เรย์สามชุดที่เหมือนกัน, แต่ละชุดมีสามแถวและอิลิเมนต์ข้างเคียง `A=` และ `=B`. ข้อความคณิตศาสตร์ทั้งหมดใช้ Cambria Math ขนาด 24 พอยต์. มีเพียงการจัดแนวอาร์เรย์ที่เปลี่ยน.

```java
import com.aspose.slides.*;
import java.awt.Color;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);
    
    int[] alignments = { MathVerticalAlignment.Top, MathVerticalAlignment.Center, MathVerticalAlignment.Bottom };
    String[] alignmentNames = { "Top", "Center", "Bottom" };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20 + i * 260, 10, 240, 30);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        label.getTextFrame().setText(alignmentNames[i]);
        IPortionFormat labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(16);
        labelFormat.getFillFormat().setFillType(FillType.Solid);
        labelFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        IAutoShape mathShape = slide.getShapes().addMathShape(20 + i * 260, 60, 240, 130);
        mathShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        IMathParagraph mathParagraph = ((IMathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(alignments[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);
    }

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเปรียบเทียบต่อไปนี้แสดงการนำเสนอที่บันทึกใน PowerPoint. สังเกตตำแหน่งของ `A=` และ `=B` ข้างแต่ละอาร์เรย์.

![อาร์เรย์สมการใน PowerPoint ที่มีการจัดแนวบน, กลาง, และล่างพร้อมอิลิเมนต์ข้างเคียงที่เหมือนกัน](equation-array-alignment.png)

### **กำหนดระยะห่างแถว**

[setRowSpacingRule](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacingRule-int-) เลือกกฎการเว้นระยะสำหรับแถวภายในอาร์เรย์. [setRowSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/imatharray/#setRowSpacing-long-) ให้ค่าตัวเลขสำหรับกฎการเว้นระยะโดยเฉพาะและจะถูกละเว้นโดยกฎที่ตั้งไว้.

สำหรับการเว้นระยะที่แน่นอน, ค่าใช้หน่วยเป็นพอยต์. สำหรับการเว้นระยะสัดส่วน, วัดเป็นครึ่งบรรทัด: ค่า `3` ในตัวอย่างหมายถึง 1.5 บรรทัด. ตั้งค่าทั้งสองคุณสมบัติเพื่อระบุค่าที่ชัดเจน; การเปลี่ยนค่าเลขอย่างเดียวจะไม่เลือกกฎการเว้นระยะ.

ตัวอย่างด้านล่างบันทึกห้านิพจน์ในไฟล์นำเสนอที่มีสมการ, การจัดแนว, และการตั้งค่าฟอนท์เดียวกัน. สามแรกใช้ค่าที่ตั้งไว้; สองสุดท้ายแสดงค่าที่ระบุโดยชัดเจน.

```java
import com.aspose.slides.*;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
int[] rules = { MathRowSpacingRule.SingleLineGap, MathRowSpacingRule.OneAndAHalfLineGap, MathRowSpacingRule.TwoLineGap, MathRowSpacingRule.Exactly, MathRowSpacingRule.Multiple };
int[] spacingValues = { 0, 0, 0, 20, 3 };
String[] ruleNames = { "SingleLineGap", "OneAndAHalfLineGap", "TwoLineGap", "Exactly", "Multiple" };

for (int i = 0; i < rules.length; i++) {
    String fileName = "equation-array-" + ruleNames[i] + ".pptx";
    Presentation presentation = new Presentation();
    try {
        IAutoShape mathShape = presentation.getSlides().get_Item(0).getShapes().addMathShape(20, 20, 600, 300);
        IParagraph paragraph = mathShape.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        IMathParagraph mathParagraph = ((IMathPortion) paragraph.getPortions().get_Item(0)).getMathParagraph();
        mathParagraph.setJustification(MathJustification.LeftJustified);

        IMathElement[] rows = { factory.createText("x+y=3"), factory.createText("x-y=1"), factory.createText("x=2") };
        MathArray equationArray = new MathArray(rows[0]);
        equationArray.getArguments().add(rows[1]);
        equationArray.getArguments().add(rows[2]);
        equationArray.setBaseJustification(MathVerticalAlignment.Center);
        equationArray.setRowSpacingRule(rules[i]);
        equationArray.setRowSpacing(spacingValues[i]);
        MathematicalText leftText = factory.createText("A=");
        MathematicalText rightText = factory.createText("=B");
        IMathBlock equation = new MathBlock(leftText).join(equationArray).join(rightText);
        mathParagraph.add(equation);

        presentation.save(fileName, SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

ระยะห่างแถวของอาร์เรย์แยกจากระยะห่างย่อหน้า. [setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) และ [setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) เพิ่มช่องว่างรอบย่อหน้าที่บรรจุ, ไม่ใช่ระหว่างแถวของอาร์เรย์. เช่นเดียวกัน, [IMathParagraph.setJustification](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#setJustification-int-) กำหนดตำแหน่งแนวนอนของ MathParagraph ทั้งหมด; ไม่ได้แทนที่การตั้งค่าการจัดแนวแนวตั้งของอาร์เรย์.

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) เมื่ออาร์กูเมนต์เป็นอิลิเมนต์ปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบ.

![ฟังก์ชันตรีโกณมิติ cos ที่นำไปใช้กับ 2x](powerpoint-math-equations_6.png)

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

## **เพิ่มตัวห้อยและตัวเหนือ**

ใช้ตัวช่วย subscript และ superscript สำหรับดัชนีและกำลัง. เมื่อดัชนีต้องปรากฏทางด้านซ้ายของฐาน, ใช้ [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-).

![ตัว Y ตัวพิมพ์ใหญ่ที่มี subscript ด้านซ้าย 1 และ superscript n](powerpoint-math-equations_9.png)

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

## **เพิ่มตัวแบ่ง**

ใช้ [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) เพื่อใส่นิพจน์ภายในตัวแบ่ง. คุณยังสามารถตั้งอักขระคั่นสำหรับนิพจน์ที่มีหลายอิลิเมนต์.

![นิพจน์ตัวแบ่งที่มี x, y, และ z แยกด้วยบาร์แนวตั้ง](powerpoint-math-equations_13.png)

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

### **ขนาดและการจัดแนวตัวแบ่ง**

ส่งค่า `true` ไปยัง [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) เพื่อให้วงเล็บขยายตามอ็อปอเรนด์ที่สูง, หรือส่งค่า `false` เพื่อคงขนาดปกติ. ใช้ [setDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) กับหนึ่งในสองค่า [MathDelimiterShape](https://reference.aspose.com/slides/java/com.aspose.slides/mathdelimitershape/). `Centered` ทำให้วงเล็บอยู่กึ่งกลางแกนคณิตศาสตร์, ซึ่งผ่านกลางสัญลักษณ์เท่ากับ. `Match` จัดแนวให้ตรงกับเนื้อหาที่ใส่ไว้. ทั้งสองการตั้งค่าส่งผลเฉพาะตัวแบ่ง. นิพจน์ภายในคงเดิม.

ตัวอย่างวางเศษส่วนในเอ็กซ์พอเนนต์ของ `x` ทำให้นิพจน์ยืดออกไปเหนือ baseline มากกว่าต่ำกว่า. สมการสี่สมการใช้วงเล็บและการตั้งค่าฟอนท์เดียวกัน.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (int row = 0; row < 2; row++) {
        for (int column = 0; column < 2; column++) {
            IMathFraction fraction = new MathematicalText("a + b").divide("c + d");
            IMathSuperscriptElement power = new MathematicalText("x").setSuperscript(fraction);
            IMathDelimiter delimiter = power.enclose('(', ')');
            delimiter.setGrowToMatchOperandHeight(row == 0);
            delimiter.setDelimiterShape(column == 0 ? MathDelimiterShape.Centered : MathDelimiterShape.Match);

            IAutoShape mathShape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100);
            MathPortion portion = (MathPortion) mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(32);
            IMathBlock equation = new MathematicalText("y = ").join(delimiter);
            portion.getMathParagraph().add(equation);
        }
    }
    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ใน PowerPoint, เปรียบเทียบแถวเพื่อดูผลของการขยาย. ในแถวบน, วงเล็บขยายเพื่อครอบเอ็กซ์พอเนนต์และดูเหมือนกันสำหรับทั้งสองรูปแบบ. ในแถวล่าง, การขยายปิด. วงเล็บเล็กกว่าด้านซ้าย (`Centered`) จัดแนวกับเครื่องหมายเท่ากับ, ส่วนด้านขวา (`Match`) อยู่สูงกว่าเหนือนิพจน์.

![สี่สมการใน PowerPoint โดยที่การขยายตัวแบ่งเปิดใช้งานด้านบนและปิดด้านล่าง, และ Centered ด้านซ้ายและ Match ด้านขวา](delimiter-sizing.png)

## **เพิ่มกล่องขอบ**

เรียก [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) บนเศษส่วนเพื่อกรอบข้อความทั้งหมด. [IMathBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/) ที่คืนค่ามีสี่ด้านทั้งหมดโดยค่าเริ่มต้น. ใช้ [setHideTop](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), และ [setHideRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setHideRight-boolean-) เพื่อลบด้านที่ต้องการ.

ตัวอย่างวางสำเนาเศษส่วนเดียวกันหกครั้งบนสไลด์เดียว. เพื่อแสดงการขีดฆ่า, ซ่อนทั้งสี่ด้านและส่งค่า `true` ไปยัง [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) สำหรับเส้นทแยงขึ้น (↗) หรือ [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) สำหรับเส้นทแยงลง (↘). คุณยังสามารถใช้ [setStrikethroughHorizontal](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) หรือ [setStrikethroughVertical](https://reference.aspose.com/slides/java/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) กับการผสมผสานของด้านที่มองเห็น.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    class FractionBuilder {
        IMathBorderBox addFraction(float x, float y, boolean hideBorder) {
            IMathFraction fraction = new MathematicalText("x+1").divide("y+2");
            IMathBorderBox box = fraction.toBorderBox();
            box.setHideTop(hideBorder);
            box.setHideBottom(hideBorder);
            box.setHideLeft(hideBorder);
            box.setHideRight(hideBorder);

            IAutoShape shape = slide.getShapes().addMathShape(x, y, 160, 90);
            MathPortion portion = (MathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            portion.getPortionFormat().setFontHeight(28);
            portion.getMathParagraph().add(new MathBlock(box));
            return box;
        }
    }

    FractionBuilder builder = new FractionBuilder();
    builder.addFraction(10, 10, false);

    IMathBorderBox partial = builder.addFraction(190, 10, false);
    partial.setHideTop(true);
    partial.setHideRight(true);

    builder.addFraction(370, 10, true).setStrikethroughBottomLeftToTopRight(true);
    builder.addFraction(10, 120, true).setStrikethroughTopLeftToBottomRight(true);
    builder.addFraction(190, 120, true).setStrikethroughHorizontal(true);
    builder.addFraction(370, 120, false).setStrikethroughVertical(true);

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![หกเศษส่วนที่แก้ไขได้ใน PowerPoint. แถวบน: กรอบเต็ม, ด้านล่างและซ้าย, เส้นทแยงขึ้น. แถวล่าง: เส้นทแยงลง, ขีดแนวนอน, ขีดแนวตั้งพร้อมกรอบเต็ม.](border-box-fractions.png)

บนเศษส่วนนี้, เส้นขีดแนวนอนทับแถบเศษส่วน. เส้นขีดแนวตั้งข้ามทั้งตัวเศษและตัวส่วนในขณะที่กรอบรอบข้างยังคงมองเห็น. เส้นเหล่านี้ตกแต่งนิพจน์ทั้งหมด. การขีดเส้นผ่านข้อความทั่วไปใช้กับอักขระในรันข้อความ. หลังจากเปิดนำเสนอใน PowerPoint อีกครั้ง, คุณยังคงแก้ไขตัวเศษและตัวส่วนแยกจากกัน.

## **ควบคุมการมองและการจัดวางด้วย Phantom Elements**

ห่อหุ้มนิพจน์ด้วย [MathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/mathphantom/) เพื่อควบคุมการมองเห็นและพื้นที่ที่มันให้กับสมการแยกจากกัน. เมธอดของ [IMathPhantom](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/) ควบคุมดังต่อไปนี้:

| วิธีการ | ผลกระทบ |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-) | ส่งค่า `false` เพื่อซ่อนนิพจน์. มิติต่าง ๆ ยังมีผลต่อการจัดวาง เว้นแต่เมธอดต่อไปนี้ได้รับค่า `true` |
| [setZeroWidth](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroWidth-boolean-) | ถือความกว้างแนวนอนของนิพจน์เป็นศูนย์, ให้แอตเรเมนท์ข้างเคียงเคลื่อนใกล้กัน |
| [setZeroAsc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroAsc-boolean-) | ถือส่วนขึ้นของมัน (ความสูงเหนือ baseline) เป็นศูนย์. นี้สามารถลดพื้นที่ที่สงวนไว้เหนืออิลิเมนต์ข้างเคียง |
| [setZeroDesc](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setZeroDesc-boolean-) | ถือส่วนลงของมัน (ความลึกใต้ baseline) เป็นศูนย์. นี้ทำให้แถบเศษส่วนหรือเนื้อหาอื่นใต้ นิพจน์เคลื่อนเข้าหาอิลิเมนต์ข้างเคียง |

Baseline คือเส้นอ้างอิงที่อักษรคณิตศาสตร์ทั่วไปตั้งอยู่. การซ่อนเนื้อหาไม่ได้ลบมิติออก, และการถือมิติเป็นศูนย์ไม่ได้ลบนิพจน์. นิพจน์พื้นฐานยังคงเข้าถึงได้ผ่าน [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#getBase--). ส่งค่า `true` ไปยัง [setShow](https://reference.aspose.com/slides/java/com.aspose.slides/imathphantom/#setShow-boolean-) เพื่อแสดงอีกครั้ง; การตั้งค่ามิติยังคงเดิม.

ตัวอย่างต่อไปนี้สร้างห้าแบบข้างเคียงกัน: เศษส่วนที่มองเห็น, เศษส่วนที่ซ่อนแต่สงวนพื้นที่, และสามเศษส่วนที่ซ่อนโดยมิติหนึ่งเป็นศูนย์. แต่ละแบบใช้นิพจน์รอบข้างเดียวกันและ Cambria Math ขนาด 24 พอยต์. รูปร่างสมการทั้งหมดมีตำแหน่งบนเหมือนกัน, ทำเครื่องหมายด้วยไกด์สีเทา. การวาง phantom ในตัวเศษของเศษส่วนภายนอกทำให้การเปลี่ยนแปลงการจัดวางแนวตั้งเห็นได้ง่ายขึ้น.

```java
import com.aspose.slides.*;
import java.awt.Color;

class MathTextFactory {
    MathematicalText createText(String value) {
        MathematicalText text = new MathematicalText(value);
        text.getFormat().setFontHeight(24);
        text.getFormat().setLatinFont(new FontData("Cambria Math"));
        return text;
    }
}

MathTextFactory factory = new MathTextFactory();
Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    String[] labels = { "Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc" };

    IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0);
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY);

    for (int i = 0; i < labels.length; i++) {
        int left = 10 + i * 200;

        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        label.getTextFrame().setText(labels[i]);

        IPortionFormat labelFormat = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        labelFormat.setFontHeight(14);
        labelFormat.getFillFormat().setFillType(FillType.Solid);
        labelFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        MathematicalText fractionNumerator = factory.createText("a+b");
        MathematicalText fractionDenominator = factory.createText("c+d");
        MathFraction fraction = new MathFraction(fractionNumerator, fractionDenominator);
        MathPhantom phantom = new MathPhantom(fraction);
        phantom.setShow(i == 0);
        phantom.setZeroWidth(i == 2);
        phantom.setZeroAsc(i == 3);
        phantom.setZeroDesc(i == 4);

        MathematicalText leftText = factory.createText("x+");
        MathematicalText rightText = factory.createText("+y");
        IMathBlock numerator = new MathBlock(leftText).join(phantom).join(rightText);
        MathematicalText denominator = factory.createText("z");
        MathFraction equation = new MathFraction(numerator, denominator);

        IAutoShape shape = slide.getShapes().addMathShape(left, 60, 190, 100);
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top);

        IMathPortion mathPortion = (IMathPortion) shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IMathParagraph mathParagraph = mathPortion.getMathParagraph();
        mathParagraph.add(new MathBlock(equation));
    }

    presentation.save("math-phantom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ห้าสมการใน PowerPoint ที่เปรียบเทียบเศษส่วนที่มองเห็น, เศษส่วนที่ซ่อนแต่สงวนพื้นที่, และเศษส่วนที่ซ่อนโดยเปิดใช้งาน ZeroWidth, ZeroAsc, หรือ ZeroDesc](math-phantom.png)

## **จัดกลุ่มเทอม**

ใช้ [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) เพื่อวางอักขระจัดกลุ่มเหนือหรือใต้ไอเท็ม. เพิ่มขีดจำกัดเพื่อทำป้ายให้กับเทอมที่จัดกลุ่ม.

![นิพจน์ x + y ที่จัดกลุ่มพร้อมป้ายข้อความใด ๆ ด้านล่าง](powerpoint-math-equations_15.png)

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

## **จัดรูปแบบอิลิเมนต์คณิตศาสตร์**

ใช้ตัวช่วยการจัดรูปแบบเฉพาะเมื่อทำให้สูตรชัดเจน. ตัวอย่างเช่น, [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--) วางเส้นขีดเหนืออิลิเมนต์คณิตศาสตร์.

![นิพจน์คณิตศาสตร์ ABC ที่มี overbar](powerpoint-math-equations_14.png)

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

### **จัดรูปแบบข้อความในสมการที่มีอยู่**

เพื่อจัดรูปแบบข้อความทั่วทั้งสมการที่มีอยู่, เดินทางผ่านต้นไม้ของอิลิเมนต์แต่ละ MathBlock. [IMathElement.getChildren](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#getChildren--) คืนค่าเด็กโดยตรงเท่านั้น, ดังนั้นเรียกซ้ำเพื่อเข้าถึงข้อความภายในเศษส่วน, สคริปต์, ราก, และโครงสร้างซ้อนอื่น ๆ. ตรวจสอบอิลิเมนต์ปัจจุบันรวมถึงเด็กของมันเพื่อรวมอิลิเมนต์เริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/).

ตัวอย่างนี้ถือว่า `input.pptx` มีสมการเช่น `z = xᵢ / ∛y`, โดยมีเศษส่วนที่มี subscript ในตัวเศษและรากในตัวส่วน. การประมวลผลเฉพาะอิลิเมนต์ระดับบนของบล็อกจะพลาดข้อความภายในเศษส่วน. ตัวอย่างค้นหา MathPortion ในกรอบข้อความสไลด์, เข้าถึงบล็อกผ่าน [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), และใช้ [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) เพื่อตั้งค่าขนาดฟอนท์เป็น 28 พอยต์ผ่านเมธอด [getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/#getFormat--) ของแต่ละอิลิเมนต์ข้อความ.

```java
import com.aspose.slides.*;

class MathTextFormatter {
    void formatMathText(IMathElement element) {
        if (element instanceof MathematicalText) {
            MathematicalText text = (MathematicalText) element;
            text.getFormat().setFontHeight(28);
        }

        for (IMathElement child : element.getChildren()) {
            formatMathText(child);
        }
    }
}

MathTextFormatter formatter = new MathTextFormatter();
Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (portion instanceof IMathPortion) {
                        IMathPortion mathPortion = (IMathPortion) portion;
                        for (IMathBlock block : mathPortion.getMathParagraph()) {
                            formatter.formatMathText(block);
                        }
                    }
                }
            }
        }
    }

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ไฟล์นำเสนอที่บันทึกมีการจัดรูปแบบข้อความที่อัปเดตในทุกระดับของแต่ละสมการที่ประมวลผล, พร้อมคงเนื้อความและโครงสร้างคณิตศาสตร์ไว้.

## **อ้างอิงอย่างเร็ว**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/mathematicaltext/) |
| รวมอิลิเมนต์ | [IMathElement.join](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| สร้างเศษส่วน | [IMathElement.divide](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| เพิ่ม superscript หรือ subscript | [setSuperscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| เพิ่มราก | [IMathElement.radical](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| เพิ่มขีดจำกัด | [setLowerLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| เพิ่มสคริปต์ด้านซ้าย | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| เพิ่มผลบวกและอินทิกรัล | [nary](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| เพิ่มเมทริกซ์ | [MathMatrix](https://reference.aspose.com/slides/java/com.aspose.slides/mathmatrix/) |
| เพิ่มอาร์เรย์สมการ | [toMathArray](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toMathArray--) |
| เพิ่มตัวแบ่ง | [enclose](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| เพิ่มบาร์และขอบ | [overbar](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#toBorderBox--) |
| จัดกลุ่มเทอม | [group](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ได้. เปิดไฟล์นำเสนอ, หารูปร่างที่มี [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/), เรียก [getMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/#getMathParagraph--), และอัปเดต MathBlock ในพารากราฟนั้น.

**สมการถูกบันทึกเป็น Math ที่แก้ไขได้ใน PowerPoint หรือไม่?**

ได้. เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่แก้ไขได้.

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ได้. ดึง [IMathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/) ของสมการจาก [IMathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/imathportion/), แล้วเรียก [IMathParagraph.toLatex](https://reference.aspose.com/slides/java/com.aspose.slides/imathparagraph/#toLatex--) เพื่อส่งออกโดยตรง. สำหรับตัวอย่างเต็ม, ดู [ส่งออกสมการคณิตศาสตร์จากการนำเสนอใน Java](/slides/th/java/exporting-math-equations/#export-math-equations-to-latex).