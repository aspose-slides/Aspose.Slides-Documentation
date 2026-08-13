---
title: รับคุณสมบัติรูปร่างแบบ Effective จากงานนำเสนอบน Android
linktitle: คุณสมบัติ Effective
type: docs
weight: 50
url: /th/androidjava/shape-effective-properties/
keywords:
- คุณสมบัติของรูปร่าง
- คุณสมบัติกล้อง
- ระบบแสง
- รูปร่าง bevel
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงของฟอนต์
- รูปแบบการเติม
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีที่ Aspose.Slides สำหรับ Android ผ่าน Java คำนวณและใช้คุณสมบัติรูปร่างแบบ Effective เพื่อการเรนเดอร์ PowerPoint อย่างแม่นยำ."
---
## **ภาพรวม**

หัวข้อนี้อธิบายความแตกต่างระหว่างคุณสมบัติ **local** และ **effective** ค่าท้องถิ่นคือค่าที่ตั้งโดยตรงในระดับการจัดรูปแบบเฉพาะ เช่น:

1. คุณสมบัติของส่วนบนสไลด์.
1. ลุคแบบข้อความของรูปร่างต้นแบบบนเลย์เอาต์หรือสไลด์มาสเตอร์เมื่อรูปร่างกรอบข้อความของส่วนมีลุคแบบหนึ่ง.
1. การตั้งค่าข้อความระดับทั่วโลกในงานนำเสนอ.

ค่าท้องถิ่นสามารถกำหนดหรือละเว้นได้ในทุกระดับ เมื่อ Aspose.Slides ต้องการการจัดรูปแบบขั้นสุดท้ายที่ "as rendered" มันจะทำการแก้ไขโซ่การสืบทอดและคืนค่า **effective** คุณสามารถเรียกใช้เมธอด `getEffective()` บนวัตถุรูปแบบท้องถิ่นเพื่อรับค่าเหล่านั้น

ตัวอย่างต่อไปนี้แสดงวิธีการรับค่า effective โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ที่มีกรอบข้อความและอย่างน้อยหนึ่งส่วน.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
ข้อมูลการจัดรูปแบบ Effective แสดงการจัดรูปแบบที่คำนวณแล้วหลังจากใช้การสืบทอด ในการนำไปใช้ปัจจุบันบางวัตถุข้อมูล Effective เช่น [IPortionFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportionformateffectivedata/) อาจถูกแคชภายใน การเรียก `getEffective()` อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบของพาเรนท์หรือการสืบทอดสามารถรีเฟรชข้อมูลแคชได้และวัตถุที่ดึงมาก่อนหน้านี้อาจไม่แสดงสภาพเดิม หากต้องการเก็บค่าที่ Effective ไว้ใช้ต่อไป ให้คัดลอกคุณสมบัติที่ต้องการ เช่น ความสูงของฟอนต์ สีเติมสไตล์ฟอนต์หรือการจัดแนว ไปยังออบเจ็กต์ข้อมูลของคุณเอง.
{{% /alert %}}

## **รับคุณสมบัติ Effective ของกล้อง**

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติ Effective ของกล้อง อินเทอร์เฟซ [ICameraEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icameraeffectivedata/) แสดงออบเจ็กต์ไม่เปลี่ยนแปลงที่บรรจุคุณสมบัติกล้องแบบ Effective อินสแตนซ์ของ [ICameraEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icameraeffectivedata/) เปิดให้เข้าถึงผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ Effective ของ [IThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/).

```java
import com.aspose.slides.*;

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

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติ Effective ของ Light Rig อินเทอร์เฟซ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilightrigeffectivedata/) แสดงออบเจ็กต์ไม่เปลี่ยนแปลงที่บรรจุคุณสมบัติ Light Rig แบบ Effective อินสแตนซ์ของ [ILightRigEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilightrigeffectivedata/) เปิดให้เข้าถึงผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ Effective ของ [IThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/).

```java
import com.aspose.slides.*;

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

Aspose.Slides อนุญาตให้คุณรับคุณสมบัติ Effective ของ bevel รูปร่าง อินเทอร์เฟซ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapebeveleffectivedata/) แสดงออบเจ็กต์ไม่เปลี่ยนแปลงที่บรรจุคุณสมบัติ relief ของรูปร่าง อินสแตนซ์ของ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapebeveleffectivedata/) เปิดให้เข้าถึงผ่าน [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformateffectivedata/) ซึ่งให้ค่าที่ Effective ของ [IThreeDFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ithreedformat/).

```java
import com.aspose.slides.*;

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

โดยใช้ Aspose.Slides คุณสามารถรับคุณสมบัติ Effective ของ Text Frame อินเทอร์เฟซ [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformateffectivedata/) มีคุณสมบัติการจัดรูปแบบ Text Frame แบบ Effective

```java
import com.aspose.slides.*;

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

โดยใช้ Aspose.Slides คุณสามารถรับคุณสมบัติ Effective ของ Text Style อินเทอร์เฟซ [ITextStyleEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextstyleeffectivedata/) มีคุณสมบัติ Text Style แบบ Effective

```java
import com.aspose.slides.*;

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

โดยใช้ Aspose.Slides คุณสามารถรับความสูงฟอนต์ Effective ตัวอย่างต่อไปนี้แสดงการเปลี่ยนแปลงความสูงฟอนต์ Effective ของส่วนหลังจากตั้งค่าความสูงฟอนต์ท้องถิ่นที่ระดับโครงสร้างงานนำเสนอต่าง ๆ

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

## **รับ Fill Format Effective สำหรับ Table**

โดยใช้ Aspose.Slides คุณสามารถรับการจัดรูปแบบ Fill แบบ Effective สำหรับส่วนต่าง ๆ ของตาราง อินเทอร์เฟซ [IFillFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifillformateffectivedata/) มีคุณสมบัติการเติมแบบ Effective การจัดรูปแบบเซลล์มีระดับความสำคัญสูงกว่าการจัดรูปแบบแถว แถวมีระดับความสำคัญสูงกว่าการจัดรูปแบบคอลัมน์ และคอลัมน์มีระดับความสำคัญสูงกว่าการจัดรูปแบบทั้งตาราง

ดังนั้นคุณสมบัติของ [ICellFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icellformateffectivedata/) ถูกใช้ในการวาดเซลล์ตาราง ตัวอย่างต่อไปนี้แสดงวิธีการรับการเติมแบบ Effective สำหรับส่วนต่าง ๆ ของตาราง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itable/).

```java
import com.aspose.slides.*;

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

## **คำถามที่พบบ่อย**

### `getEffective()` คืนค่า snapshot หรือไม่?

ไม่เสมอไป ข้อมูล Effective แสดงการจัดรูปแบบที่คำนวณแล้วหลังการสืบทอด แต่บางออบเจ็กต์ข้อมูล Effective อาจถูกแคชภายใน การเรียก `getEffective()` อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบของพาเรนท์หรือการสืบทอดอาจคำนวณใหม่และรีเฟรชแคช ดังนั้นออบเจ็กต์ที่ดึงมาก่อนหน้านี้ไม่ควรถือเป็น snapshot ถาวร

### ควรอ่านคุณสมบัติ Effective อีกครั้งเมื่อใด?

เรียก `getEffective()` อีกครั้งหลังจากเปลี่ยนแปลงการจัดรูปแบบท้องถิ่น สไตล์พาเรนท์ การจัดรูปแบบเลย์เอาต์ การจัดรูปแบบมาสเตอร์ หรือค่าตั้งต้นระดับงานนำเสนอ การเรียกครั้งต่อไปจะประเมินลำดับการจัดรูปแบบใหม่และคืนค่าผลลัพธ์ Effective ปัจจุบัน

### การเปลี่ยนหรือเอาเลย์เอาต์/มาสเตอร์สไลด์ออกมีผลต่อคุณสมบัติ Effective ที่ดึงแล้วหรือไม่?

มีผล แต่การเปลี่ยนแปลงจะปรากฏในการเรียก `getEffective()` ถัดไป หากแหล่งการจัดรูปแบบพาเรนท์เปลี่ยนหรือถูกลบ ข้อมูล Effective ที่ได้รับก่อนหน้าอาจล้าสมัย เมื่อเรียก `getEffective()` อีกครั้ง Aspose.Slides จะประเมินต้นไม้การจัดรูปแบบใหม่และฟอนต์ สี ขนาด หรือค่าต่าง ๆ อาจเปลี่ยนแปลง

### สามารถแก้ไขค่าได้ผ่านออบเจ็กต์ Effective หรือไม่?

ไม่ได้ ออบเจ็กต์ Effective ให้ค่าที่คำนวณแล้ว ทำการเปลี่ยนแปลงในออบเจ็กต์การจัดรูปแบบท้องถิ่น แล้วดึงค่า Effective ใหม่อีกครั้ง

### หากคุณสมบัติไม่ได้ตั้งค่าในระดับรูปร่าง ไม่ได้ตั้งค่าในเลย์เอาต์/มาสเตอร์ และไม่ได้ตั้งค่าในระดับทั่วโลก จะเป็นอย่างไร?

ค่าที่ Effective จะถูกกำหนดโดยกลไกค่าเริ่มต้น ซึ่งรวมถึงค่าเริ่มต้นของ PowerPoint และ Aspose.Slides ค่าที่ได้จะเป็นส่วนหนึ่งของข้อมูล Effective ปัจจุบัน

### จากค่าฟอนต์ Effective สามารถบอกได้หรือไม่ว่ามาจากระดับใด?

ไม่ได้โดยตรง ข้อมูล Effective ให้ค่าที่สุดท้ายเท่านั้น หากต้องการทราบแหล่งที่มาให้ตรวจสอบค่าท้องถิ่นที่ Portion, Paragraph, Text Frame และ Text Styles ที่เลย์เอาต์, มาสเตอร์ และระดับงานนำเสนอเพื่อหาการกำหนดที่ชัดเจนแรกที่ปรากฏ

### ทำไมค่าที่ Effective บางครั้งดูเหมือนกับค่าท้องถิ่น?

เพราะค่าท้องถิ่นกลายเป็นค่าต finale (ไม่มีการสืบทอดจากระดับที่สูงกว่า) ดังนั้นค่าที่ Effective จึงตรงกับค่าท้องถิ่น

### ควรใช้คุณสมบัติ Effective เมื่อใด และควรใช้ค่าท้องถิ่นเท่านั้นเมื่อใด?

ใช้ข้อมูล Effective เมื่อคุณต้องการผลลัพธ์ \"as rendered\" หลังจากการสืบทอดทั้งหมด เช่น การจัดสี การเยื้อง หรือขนาด หากต้องการเก็บค่าดังกล่าวไว้แม้การจัดรูปแบบจะเปลี่ยนในภายหลัง ให้คัดลอกคุณสมบัติที่ต้องการไปยังออบเจ็กต์ของคุณเอง หากต้องการเปลี่ยนการจัดรูปแบบที่ระดับใดระดับหนึ่ง ให้แก้ไขค่าท้องถิ่นแล้วหากจำเป็นให้อ่านข้อมูล Effective อีกครั้งเพื่อยืนยันผลลัพธ์.