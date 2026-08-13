---
title: รับคุณสมบัติ Shape แบบ Effective จากการนำเสนอใน Java
linktitle: คุณสมบัติ Effective
type: docs
weight: 50
url: /th/java/shape-effective-properties/
keywords:
- คุณสมบัติ shape
- คุณสมบัติ camera
- ระบบแสง
- รูปร่าง bevel
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงฟอนท์
- รูปแบบการเติม
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบว่า Aspose.Slides สำหรับ Java คำนวนและนำคุณสมบัติ shape แบบ effective ไปใช้เพื่อการเรนเดอร์ PowerPoint อย่างแม่นยำ."
---
## **ภาพรวม**

หัวข้อนี้อธิบายความแตกต่างระหว่างคุณสมบัติ **local** และ **effective** ค่า local คือค่าที่ตั้งโดยตรงที่ระดับการจัดรูปแบบเฉพาะ, เช่น:

1. คุณสมบัติ Portion บนสไลด์
1. รูปแบบข้อความของรูปร่างต้นแบบบนเลย์เอาต์หรือมาสเตอร์สไลด์, เมื่อรูปร่างกรอบข้อความของ Portion มีอยู่
1. การตั้งค่าข้อความระดับทั่วไประหว่างการนำเสนอ

ค่า local สามารถกำหนดหรือไม่กำหนดได้ที่ระดับใดก็ได้ เมื่อ Aspose.Slides ต้องการการจัดรูปแบบ “ตามที่แสดงผล” สุดท้าย มันจะทำการแก้ไขโซ่การสืบทอดและคืนค่า **effective** คุณสามารถรับค่าเหล่านั้นโดยเรียกเมธอด `getEffective` บนวัตถุฟอร์แมต local

ตัวอย่างต่อไปนี้แสดงวิธีการรับค่า effective โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) ที่มีกรอบข้อความและมีอย่างน้อยหนึ่ง Portion

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
ข้อมูลการจัดรูปแบบแบบ effective แสดงถึงรูปแบบที่คำนวณแล้วในปัจจุบันหลังจากที่ได้ใช้การสืบทอด ในการทำงานปัจจุบัน บางอ็อบเจ็กต์ข้อมูลแบบ effective เช่น [IPortionFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IPortionFormatEffectiveData) อาจถูกแคชภายใน การเรียก `getEffective` อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบพาเรนท์หรือการสืบทอดสามารถรีเฟรชข้อมูลที่แคชไว้ได้ และอ็อบเจ็กต์ที่เคยได้รับอาจไม่แสดงสถานะก่อนหน้าอีกต่อไป หากต้องการเก็บค่าที่เป็น effective ไว้ใช้ในภายหลัง ให้คัดลอกคุณสมบัติตามที่ต้องการ เช่น ความสูงฟอนท์, สีเติม, สไตล์ฟอนท์ หรือการจัดแนว ไปยังอ็อบเจ็กต์ข้อมูลของคุณเอง
{{% /alert %}}

## **รับคุณสมบัติ Effective ของกล้อง**

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติ effective ของกล้อง อินเทอร์เฟซ [ICameraEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICameraEffectiveData) แสดงอ็อบเจ็กต์ที่ไม่เปลี่ยนแปลงซึ่งบรรจุคุณสมบัติกล้องแบบ effective อินสแตนซ์ของ [ICameraEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICameraEffectiveData) ถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IThreeDFormatEffectiveData) ซึ่งให้ค่าที่เป็น effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IThreeDFormat)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติ effective สำหรับกล้อง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3D

```java
import com.aspose.slides.*;

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

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติ effective ของ Light Rig อินเทอร์เฟซ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ILightRigEffectiveData) แสดงอ็อบเจ็กต์ที่ไม่เปลี่ยนแปลงซึ่งบรรจุคุณสมบัติ Light Rig แบบ effective อินสแตนซ์ของ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ILightRigEffectiveData) ถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IThreeDFormatEffectiveData) ซึ่งให้ค่าที่เป็น effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IThreeDFormat)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติ effective สำหรับ Light Rig โดยสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3D

```java
import com.aspose.slides.*;

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

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติ effective ของ bevel รูปร่าง อินเทอร์เฟซ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeBevelEffectiveData) แสดงอ็อบเจ็กต์ที่ไม่เปลี่ยนแปลงซึ่งบรรจุคุณสมบัติเพิ่มระดับของ bevel สำหรับรูปร่าง อินสแตนซ์ของ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeBevelEffectiveData) ถูกเปิดเผยผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IThreeDFormatEffectiveData) ซึ่งให้ค่าที่เป็น effective สำหรับ [IThreeDFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IThreeDFormat)

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติ effective ของ bevel ด้านบนของรูปร่าง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3D

```java
import com.aspose.slides.*;

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

โดยใช้ Aspose.Slides คุณสามารถรับคุณสมบัติ effective ของกรอบข้อความ อินเทอร์เฟซ [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextFrameFormatEffectiveData) มีคุณสมบัติการจัดรูปแบบกรอบข้อความแบบ effective

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติการจัดรูปแบบ Text Frame แบบ effective โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) ที่มีกรอบข้อความ

```java
import com.aspose.slides.*;

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

โดยใช้ Aspose.Slides คุณสามารถรับคุณสมบัติ effective ของสไตล์ข้อความ อินเทอร์เฟซ [ITextStyleEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITextStyleEffectiveData) มีคุณสมบัติสไตล์ข้อความแบบ effective

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติสไตล์ข้อความแบบ effective โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) ที่มีกรอบข้อความ

```java
import com.aspose.slides.*;

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

## **รับค่าความสูงฟอนท์ Effective**

โดยใช้ Aspose.Slides คุณสามารถรับความสูงฟอนท์แบบ effective ตัวอย่างโค้ดต่อไปนี้แสดงว่าความสูงฟอนท์ของ Portion แบบ effective จะเปลี่ยนแปลงอย่างไรหลังจากที่ตั้งค่าความสูงฟอนท์ระดับ local ที่ระดับโครงสร้างการนำเสนอที่ต่างกัน

```java
import com.aspose.slides.*;

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

## **รับรูปแบบการเติม Effective สำหรับตาราง**

โดยใช้ Aspose.Slides คุณสามารถรับการจัดรูปแบบการเติมแบบ effective สำหรับส่วนต่าง ๆ ของตาราง อินเทอร์เฟซ [IFillFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IFillFormatEffectiveData) มีคุณสมบัติการเติมแบบ effective การจัดรูปแบบเซลล์มีความสำคัญสูงกว่าการจัดรูปแบบแถว การจัดรูปแบบแถวมีความสำคัญสูงกว่าการจัดรูปแบบคอลัมน์ และการจัดรูปแบบคอลัมน์มีความสำคัญสูงกว่าการจัดรูปแบบทั้งตาราง

ผลลัพธ์คือคุณสมบัติของ [ICellFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ICellFormatEffectiveData) จะถูกใช้ในการวาดเซลล์ตาราง ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับการจัดรูปแบบการเติมแบบ effective สำหรับส่วนต่าง ๆ ของตาราง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides/ITable)

```java
import com.aspose.slides.*;

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

## **คำถามที่พบบ่อย**

### `getEffective` คืนค่า snapshot หรือไม่?

ไม่เสมอไป ข้อมูลแบบ effective แสดงถึงรูปแบบที่คำนวณแล้วหลังจากการสืบทอด แต่บางอ็อบเจ็กต์ข้อมูลแบบ effective อาจถูกแคชภายใน การเรียก `getEffective` อีกครั้งอาจทำการคำนวณรูปแบบใหม่และรีเฟรชข้อมูลที่แคชไว้ ดังนั้นอ็อบเจ็กต์ที่เคยได้รับไม่ควรถือว่าเป็น snapshot ที่คงที่

### ควรอ่านคุณสมบัติ effective อีกครั้งเมื่อไร?

ให้เรียก `getEffective` อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบระดับ local, สไตล์พาเรนท์, การจัดรูปแบบเลย์เอาต์, การจัดรูปแบบมาสเตอร์ หรือค่าตั้งต้นระดับการนำเสนอ การเรียกครั้งต่อไปจะประเมินลำดับการจัดรูปแบบใหม่และคืนค่าผลลัพธ์แบบ effective ปัจจุบัน

### การเปลี่ยนหรือทำลายสไลด์เลย์เอาต์/มาสเตอร์ทำให้คุณสมบัติ effective ที่ได้มาก่อนหน้านี้เปลี่ยนแปลงหรือไม่?

ใช่ แต่การเปลี่ยนแปลงจะสะท้อนในการเรียก `getEffective` ครั้งต่อไป หากแหล่งข้อมูลการจัดรูปแบบพาเรนท์ถูกเปลี่ยนหรือทำลาย ข้อมูล effective ที่เคยได้อาจล้าสมัย หลังจากเรียก `getEffective` อีกครั้ง Aspose.Slides จะประเมินต้นไม้การจัดรูปแบบใหม่และฟอนท์, สี, ขนาด หรือค่าต่าง ๆ ที่ได้อาจเปลี่ยนไป

### สามารถแก้ไขค่าผ่านอ็อบเจ็กต์ข้อมูลแบบ effective ได้หรือไม่?

ไม่ได้ อ็อบเจ็กต์ข้อมูลแบบ effective เปิดเผยค่าที่คำนวณแล้ว ให้ทำการเปลี่ยนแปลงในอ็อบเจ็กต์การจัดรูปแบบระดับ local แล้วจึงรับค่า effective อีกครั้ง

### ถ้าคุณสมบัติไม่ได้ถูกตั้งค่าที่ระดับรูปร่าง, เลย์เอาต์/มาสเตอร์ หรือการตั้งค่าระดับทั่วไปรายการจะเป็นอย่างไร?

ค่าที่เป็น effective จะถูกกำหนดโดยกลไกค่าเริ่มต้น ซึ่งรวมถึงค่าเริ่มต้นของ PowerPoint และ Aspose.Slides ค่าที่ได้จะเป็นส่วนหนึ่งของข้อมูลแบบ effective ปัจจุบัน

### จากค่าฟอนท์แบบ effective สามารถบอกได้ว่าค่ามาจากระดับใดหรือไม่?

ไม่โดยตรง ข้อมูลแบบ effective ให้ค่าที่สุดท้าย เพื่อหาที่มาของค่าให้ตรวจสอบค่าระดับ local ที่ Portion, Paragraph, Text Frame และ Text Styles ที่เลย์เอาต์, มาสเตอร์ และระดับการนำเสนอ เพื่อดูว่าเป็นการกำหนดที่ชัดเจนครั้งแรกที่พบอยู่ที่ระดับใด

### ทำไมค่าที่เป็น effective บางครั้งดูเหมือนกับค่าระดับ local?

เพราะค่าระดับ local กลายเป็นค่าที่สุดท้าย (ไม่มีการสืบทอดจากระดับที่สูงกว่า) ในกรณีดังกล่าวค่า effective จึงตรงกับค่า local

### ควรใช้คุณสมบัติ effective เมื่อไร และควรใช้ค่า local เท่านั้นเมื่อไร?

ใช้ข้อมูลแบบ effective เมื่อคุณต้องการผลลัพธ์ “ตามที่แสดงผล” หลังจากการสืบทอดทั้งหมดครบถ้วน เช่น เพื่อตรงกันของสี, ระยะเยื้อง หรือขนาด หากต้องการเก็บค่าที่ได้โดยไม่ให้การเปลี่ยนแปลงการจัดรูปแบบภายหลังส่งผลกระทบ ให้คัดลอกคุณสมบัติที่ต้องการไปยังอ็อบเจ็กต์ของคุณเอง หากต้องการเปลี่ยนการจัดรูปแบบที่ระดับใดระดับหนึ่ง ให้แก้ไขคุณสมบัติระดับ local แล้วหากจำเป็นอ่านข้อมูลแบบ effective อีกครั้งเพื่อยืนยันผลลัพธ์.