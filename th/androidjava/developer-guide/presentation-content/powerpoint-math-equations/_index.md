---
title: เพิ่มสมการคณิตศาสตร์ในงานนำเสนอ PowerPoint บน Android
linktitle: สมการคณิตศาสตร์ PowerPoint
type: docs
weight: 80
url: /th/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "แทรกและแก้ไขสมการคณิตศาสตร์ใน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ Android รองรับ OMML การควบคุมการจัดรูปแบบ และตัวอย่างโค้ด Java ที่ชัดเจน"
---
## **ภาพรวม**

PowerPoint จัดเก็บสมการในรูปแบบ Office Math Markup Language (OMML). ด้วย Aspose.Slides สำหรับ Android ผ่าน Java คุณสามารถสร้างเนื้อหาทางคณิตศาสตร์ประเภทเดียวกันได้โดยเขียนโปรแกรม: เศษส่วน, ราก, ฟังก์ชัน, ขีดจำกัด, ตัวดำเนินการ N-ary, เมตริกซ์, อาเรย์, และบล็อกคณิตศาสตร์ที่จัดรูปแบบ

ใน PowerPoint ผู้ใช้มักเพิ่มสมการจาก **Insert > Equation**:

![แท็บ Insert ของ PowerPoint พร้อมคำสั่ง Equation ที่เลือก](powerpoint-math-equations_1.png)

ผลลัพธ์คือข้อความคณิตศาสตร์ที่สามารถแก้ไขได้บนสไลด์:

![สไลด์ PowerPoint ที่มีสมการคณิตศาสตร์ที่สามารถแก้ไขได้](powerpoint-math-equations_2.png)

Aspose.Slides สร้างข้อความคณิตศาสตร์นั้นผ่านสามอ็อบเจ็กต์หลัก:

- รูปร่างคณิตศาสตร์, สร้างด้วย [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/), คือรูปร่างที่บรรจุสมการ.
- [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) เก็บเนื้อหาคณิตศาสตร์ภายในกรอบข้อความของรูปร่าง.
- [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) มีหนึ่งหรือหลายออบเจ็กต์ [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/).

ตัวอย่างส่วนใหญ่ด้านล่างใช้ [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) และเมธอดเชิงไหลจาก [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) เพื่อทำให้โค้ดสั้นและอ่านง่าย.

สำหรับกรณีการส่งออก MathML, ดู [ส่งออกสมการคณิตศาสตร์จากงานนำเสนอบน Android](/slides/th/androidjava/exporting-math-equations/).

## **สร้างสมการ**

ตัวอย่างนี้ใช้ [addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) เพื่อสร้างรูปร่างคณิตศาสตร์และเพิ่มทฤษฎีพีทาโกรัส:

![สมการ c กำลังสองเท่ากับ a กำลังสองบวก b กำลังสอง](powerpoint-math-equations_3.png)

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
[addMathShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) สร้างรูปร่างที่มี MathParagraph อยู่แล้ว. เข้าถึง [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) แรก, เรียก [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--), และเพิ่มบล็อกคณิตศาสตร์หรืออีลิเมนต์คณิตศาสตร์ลงไป.
{{% /alert %}}

## **เพิ่มเศษส่วน**

ใช้ [divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) เพื่อสร้างเศษส่วน. คุณสามารถเลือกสไตล์ของเศษส่วนด้วย [MathFractionTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/).

![เศษส่วนคณิตศาสตร์โน้มเอียงที่แสดงหนึ่งหารด้วย x](powerpoint-math-equations_4.png)

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

สำหรับเศษส่วนแบบซ้อน, ใช้ [MathFractionTypes.Bar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathfractiontypes/#Bar):

```java
import com.aspose.slides.*;

IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **เพิ่มรูท**

ใช้ [radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) เพื่อสร้างรากกำลังสอง, รากกำลังสาม, หรือรากอื่น. อิลิเมนต์ปัจจุบันจะเป็นฐาน, และอาร์กิวเมนต์จะเป็นดีกรี.

![นิพจน์รากชั้น n ที่มี x อยู่ใต้สัญลักษณ์ราก](powerpoint-math-equations_5.png)

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

## **เพิ่มฟังก์ชันและขีดจำกัด**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) หรือ [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) สำหรับฟังก์ชันเช่น `sin(x)`, `log(x)`, หรือชื่อฟังก์ชันที่กำหนดเอง. สำหรับขีดจำกัด, ใส่ `lim` ลงใน [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathlimit/) หรือใช้ [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-).

![ขีดจำกัดของ x เมื่อ x เข้าใกล้อนันต์](powerpoint-math-equations_8.png)

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

สำหรับชื่อฟังก์ชันที่กำหนดเอง, ทำให้ชื่อฟังก์ชันเป็นอิลิเมนต์ปัจจุบันและเรียก [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-) พร้อมอาร์กิวเมนต์ของมัน:

```java
import com.aspose.slides.*;

IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **เพิ่มตัวดำเนินการ N-ary และอินทิกรัล**

ใช้ [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) สำหรับผลบวก, การรวม, การตัดกัน, และตัวดำเนินการขนาดใหญ่อื่น ๆ. ใช้ [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) สำหรับอินทิกรัล. ทั้งสองเมธอดให้คุณกำหนดขีดจำกัดล่างและบน.

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

ตัวดำเนินการ N-ary ใช้สำหรับตัวดำเนินการขนาดใหญ่ที่มีขีดจำกัดตามต้องการ. ตัวดำเนินการง่ายเช่น `+`, `-`, และ `=` มักเพิ่มเป็น [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) และรวมเข้ากับนิพจน์.

สำหรับอินทิกรัล, ใช้ [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-):

```java
import com.aspose.slides.*;

IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **เพิ่มเมตริกซ์**

ใช้ [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) สำหรับแถวและคอลัมน์. เมตริกซ์โดยค่าเริ่มต้นไม่มีวงเล็บ, ดังนั้นให้ล้อมเมตริกซ์ด้วยวงเล็บ, วงสี่เหลี่ยม, หรือกรอบเมื่อคุณต้องการ.

![เมตริกซ์คณิตศาสตร์สองแถวที่มีเซลล์ว่างหนึ่งช่อง](powerpoint-math-equations_10.png)

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

## **เพิ่มอาเรย์สมการ**

ใช้ [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toMathArray--) เมื่อคุณต้องการสมการที่จัดแนวหรืออาเรย์แนวตั้งของนิพจน์.

![อาเรย์คณิตศาสตร์แนวตั้งที่มี x เหนือ y](powerpoint-math-equations_11.png)

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

### **จัดแนวอาเรย์กับอิลิเมนต์โดยรอบ**

[setBaseJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setBaseJustification-int-) ควบคุมการจัดแนวแนวตั้งของอาเรย์สัมพันธ์กับอิลิเมนต์คณิตศาสตร์ด้านข้าง. ตัวอย่างด้านล่างเปรียบเทียบการจัดแนวกับแถวแรก, ศูนย์กลางของอาเรย์, และแถวสุดท้าย.

ตัวอย่างต่อไปนี้สร้างอาเรย์สามอาเรย์ที่เหมือนกัน, แต่ละอาเรย์มีสามแถวและอิลิเมนต์ข้างเคียง `A=` และ `=B`. ข้อความคณิตศาสตร์ทั้งหมดใช้ Cambria Math ขนาด 24 จุด. มีเพียงการจัดแนวอาเรย์ที่เปลี่ยน.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

การเปรียบเทียบต่อไปนี้แสดงงานนำเสนอที่บันทึกใน PowerPoint. โปรดสังเกตตำแหน่งของ `A=` และ `=B` ข้างแต่ละอาเรย์.

![อาเรย์สมการใน PowerPoint พร้อมการจัดแนวบน, กลาง, และล่าง และอิลิเมนต์ข้างเคียงที่เหมือนกัน](equation-array-alignment.png)

### **กำหนดระยะห่างแถว**

[setRowSpacingRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacingRule-int-) เลือกกฎการเว้นระยะสำหรับแถวภายในอาเรย์. [setRowSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imatharray/#setRowSpacing-long-) ให้ค่าตัวเลขสำหรับกฎการเว้นระยะที่ระบุโดยตรงและจะถูกละเลยโดยกฎตั้งต้น.

สำหรับการเว้นระยะที่แน่นอน, ค่าจะวัดเป็นจุด. สำหรับการเว้นระยะตามสัดส่วน, จะวัดเป็นครึ่งบรรทัด: ค่า `3` ในตัวอย่างหมายถึง 1.5 บรรทัด. ตั้งค่าทั้งสองคุณสมบัติเพื่อระบุค่าที่ชัดเจน; การเปลี่ยนค่าเลขเดียวไม่ทำให้เลือกกฎการเว้นระยะ.

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอห้าฉบับที่มีสมการเดียวกัน, การจัดแนว, และการตั้งค่าฟอนต์เดียวกัน. สามฉบับแรกใช้ค่าที่ตั้งไว้ล่วงหน้า; สองฉบับสุดท้ายแสดงค่าที่ระบุโดยตรง.

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

ระยะห่างแถวของอาเรย์แยกจากระยะห่างของย่อหน้า. [setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) และ [setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) เพิ่มช่องว่างรอบย่อหน้าที่บรรจุ, ไม่ได้ระหว่างแถวของอาเรย์. เช่นเดียวกับ [IMathParagraph.setJustification](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#setJustification-int-) ที่กำหนดตำแหน่งของย่อหน้าคณิตศาสตร์ทั้งหมดในแนวนอน; ไม่ได้แทนที่การตั้งค่าการจัดแนวแนวตั้งของอาเรย์.

## **เพิ่มฟังก์ชันตรีโกณมิติ**

ใช้ [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) เมื่ออาร์กิวเมนต์เป็นอิลิเมนต์ปัจจุบันและชื่อฟังก์ชันเป็นที่ทราบ.

![ฟังก์ชันตรีโกณมิติ cos ที่ประยุกต์กับ 2x](powerpoint-math-equations_6.png)

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

## **เพิ่มตัวห้อยและตัวสูง**

ใช้ตัวช่วยตัวห้อยและตัวสูงสำหรับดัชนีและกำลัง. เมื่อดัชนีต้องแสดงทางซ้ายของฐาน, ใช้ [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-).

![อักษร Y ตัวพิมพ์ใหญ่ที่มีตัวห้อยด้านซ้าย 1 และตัวสูง n](powerpoint-math-equations_9.png)

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

## **เพิ่มเครื่องหมายคั่น**

ใช้ [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#enclose-char-char-) เพื่อใส่นิพจน์ภายในเครื่องหมายคั่น. คุณยังสามารถตั้งอักขระคั่นสำหรับนิพจน์ที่มีหลายอิลิเมนต์.

![นิพจน์ที่มีเครื่องหมายคั่นที่ประกอบด้วย x, y, และ z แยกด้วยเครื่องหมายตั้งฉาก](powerpoint-math-equations_13.png)

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

### **ขนาดและการจัดแนวเครื่องหมายคั่น**

ส่งค่า `true` ไปยัง [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setGrowToMatchOperandHeight-boolean-) เพื่อให้วงเล็บขยายรอบออพอแรนด์ที่สูง, หรือส่งค่า `false` เพื่อเก็บขนาดปกติ. ใช้ [setDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathdelimiter/#setDelimiterShape-int-) กับค่าหนึ่งจากสองค่าใน [MathDelimiterShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathdelimitershape/). `Centered` จัดศูนย์วงเล็บบนแกนคณิตศาสตร์ซึ่งผ่านจุดกึ่งกลางของเครื่องหมายเท่ากับ. `Match` จัดแนวให้ตรงกับเนื้อหาที่ล้อม. ทั้งสองการตั้งค่าส่งผลต่อเครื่องหมายคั่นเท่านั้น. นิพจน์ภายในคงเดิม.

ตัวอย่างนี้ใส่เศษส่วนในเลขชี้กำลังของ `x` ทำให้นิพจน์ยืดออกเหนือเส้นฐานมากกว่าด้านล่าง. ทั้งสี่สมการใช้วงเล็บและการตั้งค่าฟอนต์เดียวกัน.

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

ใน PowerPoint, เปรียบเทียบแถวเพื่อดูผลของการขยาย. ในแถวบน, วงเล็บขยายเพื่อคลุมเลขชี้กำลังและดูคล้ายกันสำหรับทั้งสองรูปแบบ. ในแถวล่าง, การขยายปิด. วงเล็บเล็กทางซ้าย (`Centered`) จัดกับเครื่องหมายเท่ากับ, ส่วนวงเล็บทางขวา (`Match`) อยู่สูงกว่าเหนือนิพจน์.

![สี่สมการใน PowerPoint ที่เปิดการขยายเครื่องหมายคั่นด้านบนและปิดด้านล่าง, และ Centered ทางซ้ายและ Match ทางขวา](delimiter-sizing.png)

## **เพิ่มกล่องกรอบ**

เรียก [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#toBorderBox--) บนเศษส่วนเพื่อกำหนดกรอบให้กับนิพจน์ทั้งหมด. [IMathBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/) ที่ส่งกลับจะแสดงสี่ด้านโดยค่าเริ่มต้น. ใช้ [setHideTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideTop-boolean-), [setHideBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideBottom-boolean-), [setHideLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideLeft-boolean-), และ [setHideRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setHideRight-boolean-) เพื่อลบด้านแต่ละด้าน.

ตัวอย่างนี้วางสำเนาเดียวกันของเศษส่วนหกชุดบนสไลด์หนึ่ง. เพื่อแสดงการยกเลิก, ซ่อนสี่ด้านทั้งหมดและส่งค่า `true` ไปยัง [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughBottomLeftToTopRight-boolean-) เพื่อเส้นทแยงมุมขึ้น (↗) หรือ [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughTopLeftToBottomRight-boolean-) เพื่อเส้นทแยงมุมลง (↘). คุณยังสามารถใช้ [setStrikethroughHorizontal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughHorizontal-boolean-) หรือ [setStrikethroughVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathborderbox/#setStrikethroughVertical-boolean-) พร้อมการผสมผสานของด้านที่มองเห็นได้.

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

![หกเศษส่วนที่สามารถแก้ไขได้ใน PowerPoint. แถวบน: ขอบเต็ม, ด้านล่างและด้านซ้าย, เส้นทแยงมุมขึ้น. แถวล่าง: เส้นทแยงมุมลง, เส้นขวางแนวนอน, เส้นขวางแนวตั้งพร้อมขอบเต็ม](border-box-fractions.png)

บนเศษส่วนนี้, เส้นขวางแนวนอนทับบาร์ของเศษส่วน. เส้นขวางแนวตั้งตัดทั้งเศษและส่วนโดยที่กรอบรอบข้างยังมองเห็นได้. เส้นเหล่านี้ตกแต่งนิพจน์ทั้งหมด. การขีดฆ่าในข้อความทั่วไปใช้กับอักขระในรันข้อความ. หลังจากเปิดงานนำเสนอใหม่ใน PowerPoint, คุณยังสามารถแก้ไขเศษและส่วนได้อย่างอิสระ.

## **จัดกลุ่มเงื่อนไข**

ใช้ [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#group-char-int-int-) เพื่อวางอักขระจัดกลุ่มเหนือหรือใต้นิพจน์. เพิ่มขีดจำกัดเพื่อทำป้ายให้กับเงื่อนไขที่จัดกลุ่ม.

![นิพจน์ x บวก y ที่จัดกลุ่มพร้อมป้ายข้อความใด ๆ ใต้มัน](powerpoint-math-equations_15.png)

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

ใช้ตัวช่วยการจัดรูปแบบเฉพาะเมื่อช่วยอธิบายสูตร. ตัวอย่างเช่น, [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#overbar--) วางแถบเหนืออิลิเมนต์คณิตศาสตร์.

![นิพจน์คณิตศาสตร์ ABC ที่มีแถบเหนือ](powerpoint-math-equations_14.png)

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

เพื่อจัดรูปแบบข้อความทั่วสมการที่มีอยู่, ให้เดินทางผ่านต้นไม้ของอิลิเมนต์ในแต่ละบล็อกคณิตศาสตร์. [IMathElement.getChildren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/#getChildren--) คืนค่าเฉพาะลูกโดยตรง, ดังนั้นต้องเรียกซ้ำเพื่อเข้าถึงข้อความภายในเศษส่วน, ตัวห้อย, ราก, และโครงสร้างซ้อนอื่น ๆ. ตรวจสอบอิลิเมนต์ปัจจุบันรวมถึงลูกของมันเพื่อรวมอิลิเมนต์เริ่มต้นเมื่อเป็น [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/).

ตัวอย่างนี้สมมติว่า `input.pptx` มีสมการเช่น `z = xᵢ / ∛y`, โดยมีเศษส่วนที่มีตัวห้อยในส่วนบนและรากในส่วนล่าง. การประมวลผลเฉพาะอิลิเมนต์ระดับบนของบล็อกจะทำให้พลาดข้อความภายในเศษส่วน. ตัวอย่างค้นหา MathPortion ในกรอบข้อความของสไลด์, เข้าถึงบล็อกผ่าน [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--), และใช้ [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) เพื่อกำหนดขนาดฟอนต์เป็น 28 จุดผ่านเมธอด [getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/#getFormat--) ของแต่ละอิลิเมนต์ข้อความ.

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

งานนำเสนอที่บันทึกแล้วมีการจัดรูปแบบข้อความที่อัปเดตในทุกระดับของแต่ละสมการที่ประมวลผล, พร้อมคงเนื้อความและโครงสร้างคณิตศาสตร์.

## **อ้างอิงด่วน**

| งาน | API หลัก |
| --- | --- |
| สร้างข้อความคณิตศาสตร์ | [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathematicaltext/) |
| รวมอิลิเมนต์ | [IMathElement.join](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| สร้างเศษส่วน | [IMathElement.divide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| เพิ่มตัวสูงหรือฐาน | [setSuperscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| เพิ่มฟังก์ชัน | [function](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| เพิ่มราก | [IMathElement.radical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| เพิ่มขีดจำกัด | [setLowerLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| เพิ่มสคริปต์ด้านซ้าย | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| เพิ่มผลบวกและอินทิกรัล | [nary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| เพิ่มเมตริกซ์ | [MathMatrix](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathmatrix/) |
| เพิ่มอาเรย์สมการ | [toMathArray](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| เพิ่มเครื่องหมายคั่น | [enclose](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| เพิ่มแถบและขอบ | [overbar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |
| จัดกลุ่มเงื่อนไข | [group](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/) |

## **คำถามที่พบบ่อย**

**ฉันสามารถแก้ไขสมการ PowerPoint ที่มีอยู่ได้หรือไม่?**

ได้. เปิดงานนำเสนอ, ค้นหารูปร่างที่บรรจุ [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/), เรียก [getMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/#getMathParagraph--), และอัปเดตบล็อกคณิตศาสตร์ในย่อหน้านั้น.

**สมการถูกบันทึกเป็นคณิตศาสตร์ PowerPoint ที่แก้ไขได้หรือไม่?**

ได้. เมื่อบันทึกเป็น PPTX, Aspose.Slides จะเขียนสมการเป็นเนื้อหา Office Math ที่สามารถแก้ไขได้.

**ฉันสามารถส่งออกสมการเป็น LaTeX ได้หรือไม่?**

ได้. รับ [IMathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/) ของสมการจาก [IMathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathportion/), แล้วเรียก [IMathParagraph.toLatex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathparagraph/#toLatex--) เพื่อส่งออกโดยตรง. ตัวอย่างเต็มดูที่ [ส่งออกสมการคณิตย์ศาสตร์จากงานนำเสนอใน Android ผ่าน Java](/slides/th/androidjava/exporting-math-equations/#export-math-equations-to-latex).