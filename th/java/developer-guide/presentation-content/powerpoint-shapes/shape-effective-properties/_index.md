---
title: รับคุณสมบัติรูปร่างที่มีประสิทธิภาพจากงานพรีเซนเทชันใน Java
linktitle: คุณสมบัติที่มีประสิทธิภาพ
type: docs
weight: 50
url: /th/java/shape-effective-properties/
keywords:
- คุณสมบัติรูปร่าง
- คุณสมบัติกล้อง
- ระบบแสง
- รูปร่างเบเวล
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงฟอนต์
- รูปแบบการเติม
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบว่า Aspose.Slides for Java คำนวณและนำคุณสมบัติรูปร่างแบบ Effective ไปใช้เพื่อการแสดงผล PowerPoint อย่างแม่นยำ."
---
## **ภาพรวม**

หัวข้อนี้อธิบายความแตกต่างระหว่าง **local** และ **effective** property. ค่าที่กำหนดไว้ในระดับท้องถิ่น (local) คือค่าที่ตั้งโดยตรงที่ระดับการจัดรูปแบบเฉพาะ เช่น:

1. คุณสมบัติส่วนของข้อความบนสไลด์
1. รูปแบบข้อความของรูปทรงต้นแบบบนเลย์เอาต์หรือสไลด์แม่เมื่อรูปทรงกรอบข้อความของส่วนนั้นมีอยู่
1. การตั้งค่าข้อความระดับโลกในงานพรีเซนเทชัน

ค่าท้องถิ่นสามารถกำหนดหรือละเว้นได้ที่ระดับใด ๆ เมื่อ Aspose.Slides ต้องการการจัดรูปแบบสุดท้าย “ตามที่แสดงผล” มันจะทำการแก้ไขโซ่การสืบทอดและคืนค่า **effective** ค่าต่าง ๆ คุณสามารถดึงค่าดังกล่าวได้โดยเรียกเมธอด `getEffective` บนวัตถุรูปแบบท้องถิ่น

ตัวอย่างต่อไปนี้แสดงวิธีการรับค่า effective โดยสมมติว่ารูปทรงแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) ที่มีกรอบข้อความและมีอย่างน้อยหนึ่งส่วน

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
ข้อมูลการจัดรูปแบบแบบ effective แทนค่าการจัดรูปแบบที่คำนวณแล้วหลังจากการสืบทอดถูกนำไปใช้ ในการดำเนินการปัจจุบันบางอ็อบเจกต์ข้อมูลแบบ effective เช่น [IPortionFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPortionFormatEffectiveData) อาจถูกแคชภายใน การเรียก `getEffective` อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบจากพาเรนต์หรือการสืบทอดจะทำให้แคชรีเฟรชและอ็อบเจกต์ที่ได้ก่อนหน้านี้อาจไม่สอดคล้องกับสถานะเดิม หากคุณต้องการเก็บค่าที่ได้เพื่อใช้งานในภายหลัง ให้คัดลอกคุณสมบัติที่ต้องการ เช่น ความสูงฟอนต์, สีเติม, สไตล์ฟอนต์ หรือการจัดแนว ไปยังอ็อบเจกต์ข้อมูลของคุณเอง
{{% /alert %}}

## **รับคุณสมบัติ Effective ของกล้อง**

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติ effective ของกล้อง อินเทอร์เฟซ [ICameraEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICameraEffectiveData) แสดงวัตถุที่ไม่เปลี่ยนแปลงซึ่งบรรจุคุณสมบัติกล้องที่เป็น effective ตัวอย่างของ [ICameraEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICameraEffectiveData) จะถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IThreeDFormatEffectiveData) ซึ่งให้ค่าที่เป็น effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IThreeDFormat)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีการรับคุณสมบัติ effective สำหรับกล้อง โดยสมมติว่ารูปทรงแรกบนสไลด์แรกมีการจัดรูปแบบ 3 มิติ

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติ Effective ของ Light Rig**

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติ effective ของ Light Rig อินเทอร์เฟซ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ILightRigEffectiveData) แสดงวัตถุที่ไม่เปลี่ยนแปลงซึ่งบรรจุคุณสมบัติ Light Rig ที่เป็น effective ตัวอย่างของ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ILightRigEffectiveData) จะถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IThreeDFormatEffectiveData) ซึ่งให้ค่าที่เป็น effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IThreeDFormat)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีการรับคุณสมบัติ effective สำหรับ Light Rig โดยสมมติว่ารูปทรงแรกบนสไลด์แรกมีการจัดรูปแบบ 3 มิติ

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติ Effective ของ Bevel Shape**

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติ effective ของ bevel รูปทรง อินเทอร์เฟซ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeBevelEffectiveData) แสดงวัตถุที่ไม่เปลี่ยนแปลงซึ่งบรรจุคุณสมบัติการยกแนวผิวของรูปทรง ตัวอย่างของ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeBevelEffectiveData) จะถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IThreeDFormatEffectiveData) ซึ่งให้ค่าที่เป็น effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IThreeDFormat)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีการรับคุณสมบัติ effective สำหรับ bevel ด้านบนของรูปทรง โดยสมมติว่ารูปทรงแรกบนสไลด์แรกมีการจัดรูปแบบ 3 มิติ

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติ Effective ของ Text Frame**

ด้วย Aspose.Slides คุณสามารถรับคุณสมบัติ effective ของกรอบข้อความได้ อินเทอร์เฟซ [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrameFormatEffectiveData) มีคุณสมบัติการจัดรูปแบบกรอบข้อความที่เป็น effective

โค้ดตัวอย่างต่อไปนี้แสดงวิธีการรับคุณสมบัติการจัดรูปแบบกรอบข้อความแบบ effective โดยสมมติว่ารูปทรงแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) ที่มีกรอบข้อความ

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติ Effective ของ Text Style**

ด้วย Aspose.Slides คุณสามารถรับคุณสมบัติ effective ของสไตล์ข้อความได้ อินเทอร์เฟซ [ITextStyleEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextStyleEffectiveData) มีคุณสมบัติสไตล์ข้อความที่เป็น effective

โค้ดตัวอย่างต่อไปนี้แสดงวิธีการรับคุณสมบัติสไตล์ข้อความแบบ effective โดยสมมติว่ารูปทรงแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) ที่มีกรอบข้อความ

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **รับค่าความสูงฟอนต์ Effective**

ด้วย Aspose.Slides คุณสามารถรับความสูงฟอนต์แบบ effective ได้ โค้ดต่อไปนี้สาธิตว่าความสูงฟอนต์ของส่วนที่เป็น effective จะเปลี่ยนแปลงอย่างไรหลังจากตั้งค่าความสูงฟอนต์ท้องถิ่นที่ระดับโครงสร้างพรีเซนเทชันต่าง ๆ

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

## **รับ Fill Format Effective สำหรับตาราง**

ด้วย Aspose.Slides คุณสามารถรับการจัดรูปแบบเติมแบบ effective สำหรับส่วนต่าง ๆ ของตารางได้ อินเทอร์เฟซ [IFillFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IFillFormatEffectiveData) มีคุณสมบัติการเติมแบบ effective การจัดรูปแบบเซลล์มีลำดับความสำคัญสูงกว่าการจัดรูปแบบแถว, การจัดรูปแบบแถวสูงกว่าการจัดรูปแบบคอลัมน์, และการจัดรูปแบบคอลัมน์สูงกว่าการจัดรูปแบบตารางทั้งหมด

ผลลัพธ์คือคุณสมบัติของ [ICellFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICellFormatEffectiveData) จะถูกใช้ในการวาดเซลล์ของตาราง โค้ดตัวอย่างต่อไปนี้แสดงวิธีการรับการจัดรูปแบบเติมแบบ effective สำหรับส่วนต่าง ๆ ของตาราง โดยสมมติว่ารูปทรงแรกบนสไลด์แรกเป็น [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable)

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**`getEffective` คืนค่า snapshot หรือไม่?**

ไม่เสมอไป ข้อมูลแบบ effective แทนค่าการจัดรูปแบบที่คำนวณแล้วหลังจากการสืบทอด แต่บางอ็อบเจกต์ข้อมูลแบบ effective อาจถูกแคชภายใน การเรียก `getEffective` ถัดไปอาจคำนวณการจัดรูปแบบใหม่และรีเฟรชแคช ดังนั้นอ็อบเจกต์ที่ได้ก่อนหน้านี้ไม่ควรถือเป็น snapshot ที่คงที่

**ควรอ่านคุณสมบัติ effective อีกครั้งเมื่อใด?**

เรียก `getEffective` อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบท้องถิ่น, สไตล์พาเรนต์, การจัดรูปแบบเลย์เอาต์, การจัดรูปแบบแม่, หรือค่าปริยายระดับพรีเซนเทชัน การเรียกครั้งต่อไปจะประเมินลำดับการจัดรูปแบบใหม่และคืนค่าผลลัพธ์ที่เป็น effective ปัจจุบัน

**การเปลี่ยนหรือการลบสไลด์เลย์เอาต์/แม่มีผลต่อคุณสมบัติ effective ที่ได้รับแล้วหรือไม่?**

ใช่ แต่การเปลี่ยนแปลงจะปรากฏในการเรียก `getEffective` ครั้งถัดไป หากแหล่งข้อมูลการจัดรูปแบบพาเรนต์ถูกเปลี่ยนหรือถูกลบ ข้อมูล effective ที่ได้ก่อนหน้านี้อาจล้าสมัย เมื่อเรียก `getEffective` อีกครั้ง Aspose.Slides จะประเมินต้นไม้การจัดรูปแบบใหม่และฟอนต์, สี, ขนาด หรือค่าอื่น ๆ อาจเปลี่ยนแปลง

**สามารถแก้ไขค่าผ่านอ็อบเจกต์ข้อมูลแบบ effective ได้หรือไม่?**

ไม่ได้ อ็อบเจกต์ข้อมูลแบบ effective ให้ค่าที่คำนวณแล้ว เปลี่ยนแปลงในอ็อบเจกต์การจัดรูปแบบท้องถิ่น แล้วดึงค่าที่เป็น effective อีกครั้ง

**ถ้าคุณสมบัติไม่ได้ถูกตั้งค่าที่ระดับรูปทรง, เลย์เอาต์/แม่ หรือการตั้งค่าระดับทั่วโลก จะเกิดอะไรขึ้น?**

ค่าที่เป็น effective จะถูกกำหนดโดยกลไกค่าเริ่มต้น ซึ่งรวมถึงค่าเริ่มต้นของ PowerPoint และ Aspose.Slides ค่า resolved นี้จะเป็นส่วนหนึ่งของข้อมูล effective ปัจจุบัน

**จากค่าฟอนต์แบบ effective สามารถบอกได้หรือไม่ว่ามาจากระดับใด?**

ไม่โดยตรง ข้อมูลแบบ effective ให้ค่าที่สุดท้าย เพื่อค้นหาแหล่งที่มาให้ตรวจสอบค่าท้องถิ่นที่ส่วน, ย่อหน้า, กรอบข้อความ, และสไตล์ข้อความที่เลย์เอาต์, แม่, และระดับพรีเซนเทชัน เพื่อดูว่าการกำหนดที่ชัดเจนครั้งแรกอยู่ที่ระดับใด

**ทำไมค่าที่เป็น effective บางครั้งดูเหมือนกับค่าท้องถิ่น?**

เพราะค่าท้องถิ่นนั้นกลายเป็นค่าต้นสุด (ไม่มีการสืบทอดจากระดับที่สูงกว่า) ในกรณีนั้นค่าที่เป็น effective จะตรงกับค่าท้องถิ่น

**ควรใช้คุณสมบัติ effective เมื่อไหร่และควรใช้ค่าท้องถิ่นเท่านั้นเมื่อไหร่?**

ใช้ข้อมูลแบบ effective เมื่อคุณต้องการผลลัพธ์ “ตามที่แสดงผล” หลังจากการสืบทอดทั้งหมด เช่น การจัดสี, การเยื้อง, หรือขนาด หากคุณต้องการเก็บค่าที่ได้รับไว้โดยไม่ต้องการให้การเปลี่ยนแปลงการจัดรูปแบบในภายหลังส่งผลกระทบ ใหคัดลอกคุณสมบัติที่ต้องการไปยังอ็อบเจกต์ของคุณเอง หากต้องการเปลี่ยนการจัดรูปแบบที่ระดับใดระดับหนึ่ง ให้แก้ไขค่าท้องถิ่นแล้วอ่านข้อมูลแบบ effective อีกครั้งเพื่อตรวจสอบผลลัพธ์