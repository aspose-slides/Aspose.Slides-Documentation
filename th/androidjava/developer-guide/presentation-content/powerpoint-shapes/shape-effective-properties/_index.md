---
title: "รับคุณสมบัติรูปร่างที่ Effective จากการนำเสนอใน Android"
linktitle: "คุณสมบัติ Effective"
type: docs
weight: 50
url: /th/androidjava/shape-effective-properties/
keywords:
- คุณสมบัติรูปร่าง
- คุณสมบัติกล้อง
- ระบบแสง
- รูปร่างบีเวล
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงฟอนต์
- รูปแบบเติม
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีที่ Aspose.Slides สำหรับ Android ผ่าน Java คำนวณและใช้คุณสมบัติรูปร่างที่ Effective เพื่อการแสดงผล PowerPoint อย่างแม่นยำ."
---
## **ภาพรวม**

หัวข้อนี้อธิบายความแตกต่างระหว่างคุณสมบัติ **local** และ **effective** ค่าท้องถิ่นคือค่าที่ถูกตั้งโดยตรงในระดับการจัดรูปแบบเฉพาะ เช่น:

1. คุณสมบัติ Portion บนสไลด์.  
1. สไตล์ข้อความของรูปร่างต้นแบบบนเลย์เอาต์หรือสไลด์มาสเตอร์, เมื่อรูปร่างกรอบข้อความของ Portion มีสไตล์หนึ่ง.  
1. การตั้งค่าข้อความระดับส่วนกลางในงานนำเสนอ.

ค่าท้องถิ่นสามารถกำหนดหรือละเว้นได้ในทุกระดับ เมื่อ Aspose.Slides ต้องการการจัดรูปแบบขั้นสุดท้ายที่แสดงผลจริง จะทำการแก้ไขโซ่การสืบทอดและส่งคืนค่าที่ **effective** คุณสามารถรับค่าเหล่านี้ได้โดยเรียกเมธอด `getEffective()` บนวัตถุรูปแบบท้องถิ่น

ตัวอย่างต่อไปนี้แสดงวิธีการรับค่าที่ effective โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ที่มีกรอบข้อความและอย่างน้อยหนึ่ง Portion.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
ข้อมูลการจัดรูปแบบที่ effective แสดงถึงการจัดรูปแบบที่คำนวณแล้วหลังจากนำการสืบทอดมาใช้ ในการทำงานปัจจุบันบางอ็อบเจกต์ข้อมูลที่ effective เช่น [IPortionFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportionformateffectivedata/) อาจถูกเก็บแคชภายใน การเรียก `getEffective()` อีกครั้งหลังจากเปลี่ยนรูปแบบของพาเรนต์หรือการสืบทอดสามารถรีเฟรชข้อมูลแคชได้และอ็อบเจกต์ที่ได้มาก่อนหน้าอาจไม่แสดงสถานะเดิมอีกต่อไป หากต้องการเก็บค่าที่ effective ไว้ใช้ใหม่ในภายหลัง ให้คัดลอกคุณสมบัติที่ต้องการ เช่น ความสูงของฟอนต์ สีเติม สไตล์ฟอนต์ หรือการจัดแนว ไปยังอ็อบเจกต์ข้อมูลของคุณเอง
{{% /alert %}}

## **รับคุณสมบัติ Effective ของกล้อง**

Aspose.Slides ให้คุณรับคุณสมบัติ effective ของกล้อง อินเทอร์เฟซ [ICameraEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icameraeffectivedata/) แสดงถึงอ็อบเจกต์ที่ไม่เปลี่ยนแปลงซึ่งบรรจุคุณสมบัติกล้องที่ effective อินสแตนซ์ของ [ICameraEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icameraeffectivedata/) ถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformateffectivedata/), ซึ่งให้ค่าที่ effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติ Effective ของ Light Rig**

Aspose.Slides ให้คุณรับคุณสมบัติ effective ของ Light Rig อินเทอร์เฟซ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilightrigeffectivedata/) แสดงถึงอ็อบเจกต์ที่ไม่เปลี่ยนแปลงซึ่งบรรจุคุณสมบัติ Light Rig ที่ effective อินสแตนซ์ของ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilightrigeffectivedata/) ถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformateffectivedata/), ซึ่งให้ค่าที่ effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติ Effective ของ Bevel Shape**

Aspose.Slides ให้คุณรับคุณสมบัติ effective ของ bevel รูปร่าง อินเทอร์เฟซ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapebeveleffectivedata/) แสดงถึงอ็อบเจกต์ที่ไม่เปลี่ยนแปลงซึ่งบรรจุคุณสมบัติ face‑relief ของรูปร่าง อินสแตนซ์ของ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapebeveleffectivedata/) ถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformateffectivedata/), ซึ่งให้ค่าที่ effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติ Effective ของ Text Frame**

ด้วย Aspose.Slides คุณสามารถรับคุณสมบัติ effective ของกรอบข้อความได้ อินเทอร์เฟซ [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformateffectivedata/) มีคุณสมบัติการจัดรูปแบบกรอบข้อความที่ effective

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติ Effective ของ Text Style**

ด้วย Aspose.Slides คุณสามารถรับคุณสมบัติ effective ของสไตล์ข้อความได้ อินเทอร์เฟซ [ITextStyleEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextstyleeffectivedata/) มีคุณสมบัติสไตล์ข้อความที่ effective

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **รับค่าความสูงฟอนต์ Effective**

ด้วย Aspose.Slides คุณสามารถรับความสูงฟอนต์ที่ effective ได้ ตัวอย่างต่อไปนี้แสดงว่าความสูงฟอนต์ของ Portion ที่ effective จะเปลี่ยนอย่างไรหลังจากตั้งค่าความสูงฟอนต์ท้องถิ่นในระดับโครงสร้างงานนำเสนอที่ต่างกัน

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **รับ Fill Format Effective ของ Table**

ด้วย Aspose.Slides คุณสามารถรับการจัดรูปแบบเติมที่ effective สำหรับส่วนต่าง ๆ ของตารางได้ อินเทอร์เฟซ [IFillFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifillformateffectivedata/) มีคุณสมบัติการเติมที่ effective การจัดรูปแบบของเซลล์มีลำดับความสำคัญสูงกว่าการจัดรูปแบบของแถว, แถวนั้นมีลำดับความสำคัญสูงกว่าการจัดรูปแบบของคอลัมน์, และคอลัมน์มีลำดับความสำคัญสูงกว่าการจัดรูปแบบของทั้งตาราง

ผลลัพธ์คือคุณสมบัติของ [ICellFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icellformateffectivedata/) จะถูกใช้ในการวาดเซลล์ตาราง ตัวอย่างต่อไปนี้แสดงวิธีรับการจัดรูปแบบเติมที่ effective สำหรับส่วนต่าง ๆ ของตาราง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itable/)

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**`getEffective()` คืนค่าที่เป็นสแนปช็อตหรือไม่?**

ไม่เสมอ ข้อมูลที่ effective แสดงถึงการจัดรูปแบบที่คำนวณแล้วหลังจากนำการสืบทอดมาใช้ แต่บางอ็อบเจกต์ข้อมูลที่ effective อาจถูกแคชภายใน การเรียก `getEffective()` อีกครั้งหลังจากเปลี่ยนรูปแบบของพาเรนต์หรือการสืบทอดอาจทำให้คำนวณใหม่และรีเฟรชข้อมูลแคช ดังนั้นอ็อบเจกต์ที่ได้ก่อนหน้านี้ไม่ควรถือเป็นสแนปช็อตที่คงที่

**ควรอ่านคุณสมบัติ effective อีกครั้งเมื่อใด?**

ให้เรียก `getEffective()` อีกครั้งหลังจากเปลี่ยนรูปแบบท้องถิ่น, สไตล์พาเรนต์, การจัดรูปแบบเลย์เอาต์, การจัดรูปแบบมาสเตอร์ หรือค่าเริ่มต้นระดับงานนำเสนอ การเรียกครั้งต่อไปจะประเมินลำดับชั้นการจัดรูปแบบใหม่และคืนค่าที่ effective ปัจจุบัน

**การเปลี่ยนหรือเอาเลย์เอาต์/มาสเตอร์สไลด์ออกส่งผลต่อคุณสมบัติ effective ที่ได้แล้วหรือไม่?**

ใช่ แต่การเปลี่ยนแปลงจะสะท้อนในการเรียก `getEffective()` ครั้งถัดไป หากแหล่งข้อมูลการจัดรูปแบบของพาเรนต์ถูกเปลี่ยนหรือเอาออก ข้อมูลที่ effective ที่ได้ก่อนหน้านี้อาจล้าสมัย เมื่อเรียก `getEffective()` อีกครั้ง Aspose.Slides จะประเมินต้นไม้การจัดรูปแบบใหม่และค่าต่าง ๆ เช่น ฟอนต์, สี, ขนาดอาจเปลี่ยนแปลง

**ฉันสามารถแก้ไขค่าโดยใช้ข้อมูลที่ effective ได้หรือไม่?**

ไม่ได้ ข้อมูลที่ effective เฉพาะการเปิดเผยค่าที่คำนวณแล้ว ให้ทำการเปลี่ยนแปลงในอ็อบเจกต์รูปแบบท้องถิ่น แล้วเรียกรับค่าที่ effective ใหม่อีกครั้ง

**หากคุณสมบัติไม่ได้ตั้งค่าในระดับรูปร่าง, เลย์เอาต์/มาสเตอร์, หรือการตั้งค่าระดับส่วนกลาง จะเกิดอะไรขึ้น?**

ค่าที่ effective จะถูกกำหนดโดยกลไกค่าเริ่มต้น ซึ่งรวมถึงค่าเริ่มต้นของ PowerPoint และ Aspose.Slides ค่าที่ได้จะเป็นส่วนหนึ่งของข้อมูลที่ effective ปัจจุบัน

**จากค่าฟอนต์ที่ effective ฉันจะทราบได้หรือไม่ว่ามาจากระดับใด?**

โดยตรงไม่ได้ ข้อมูลที่ effective คืนค่าที่สุดท้าย เพื่อหาต้นทางต้องตรวจสอบค่าท้องถิ่นที่ Portion, ย่อหน้า, Text Frame และสไตล์ข้อความที่เลย์เอาต์, มาสเตอร์, งานนำเสนอ เพื่อดูว่าการกำหนดที่ชัดเจนแรกปรากฏที่ระดับใด

**ทำไมค่าที่ effective บางครั้งจึงดูเหมือนเดียวกับค่าท้องถิ่น?**

เพราะค่าท้องถิ่นนั้นเป็นค่าที่สุดท้ายแล้ว (ไม่ต้องอ้างอิงจากระดับที่สูงกว่า) ในกรณีนั้นค่าที่ effective จะตรงกับค่าท้องถิ่น

**ควรใช้คุณสมบัติ effective เมื่อใดและควรใช้ค่าท้องถิ่นเท่านั้นเมื่อใด?**

ใช้ข้อมูลที่ effective เมื่อคุณต้องการผลลัพธ์ “ตามที่แสดง” หลังจากการสืบทอดทั้งหมดถูกนำมาใช้ เช่น การจัดสี, การเยื้อง, หรือขนาด หากต้องการเก็บค่าดังกล่าวไว้โดยไม่ให้การเปลี่ยนแปลงการจัดรูปแบบในภายหลังมีผล ให้คัดลอกคุณสมบัติที่ต้องการไปยังอ็อบเจกต์ของคุณเอง หากต้องการเปลี่ยนการจัดรูปแบบในระดับใดระดับหนึ่ง ให้แก้ไขค่าท้องถิ่นและจากนั้น (หากจำเป็น) อ่านข้อมูลที่ effective อีกครั้งเพื่อยืนยันผลลัพธ์.