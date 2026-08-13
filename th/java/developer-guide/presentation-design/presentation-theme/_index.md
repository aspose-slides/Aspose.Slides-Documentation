---
title: จัดการธีมการนำเสนอใน Java
linktitle: ธีมการนำเสนอ
type: docs
weight: 10
url: /th/java/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมการนำเสนอ
- ธีมสไลด์
- ตั้งค่าธีม
- เปลี่ยนธีม
- จัดการธีม
- สีธีม
- พาเลตเพิ่มเติม
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สอดคล้องกัน."
---
## **คำนำ**

ธีมการนำเสนอกำหนดคุณสมบัติขององค์ประกอบการออกแบบ เมื่อคุณเลือกธีมการนำเสนอ คุณกำลังเลือกชุดขององค์ประกอบภาพและคุณสมบัติเฉพาะของมัน

ใน PowerPoint ธีมประกอบด้วยสี, [แบบอักษร](/slides/th/java/powerpoint-fonts/), [สไตล์พื้นหลัง](/slides/th/java/presentation-background/), และเอฟเฟกต์

![theme-constituents](theme-constituents.png)

## **เปลี่ยนสีธีม**

ธีม PowerPoint ใช้ชุดสีเฉพาะสำหรับองค์ประกอบต่าง ๆ บนสไลด์ หากคุณไม่พอใจกับสีเหล่านั้น คุณสามารถเปลี่ยนสีโดยการกำหนดสีใหม่ให้กับธีม เพื่อให้คุณเลือกสีธีมใหม่ Aspose.Slides จัดเตรียมค่าต่าง ๆ ภายใต้การนับจำนวนของ [SchemeColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/SchemeColor) enumeration.

โค้ด Java นี้แสดงวิธีการเปลี่ยนสีเน้นสำหรับธีม:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

คุณสามารถกำหนดค่าที่มีผลของสีที่ได้โดยใช้วิธีนี้:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

เพื่อสาธิตการเปลี่ยนสีต่อไป เราจะสร้างองค์ประกอบอีกหนึ่งตัวและกำหนดสีเน้น (จากการดำเนินการแรก) ให้กับมัน จากนั้นเปลี่ยนสีในธีม:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

สีใหม่จะถูกนำไปใช้โดยอัตโนมัติในทั้งสององค์ประกอบ

### **ตั้งค่าสีธีมจากพาเลตเพิ่มเติม**

เมื่อคุณใช้การแปลงค่าความสว่างกับสีธีมหลัก(1) จะเกิดสีจากพาเลตเพิ่มเติม(2) ขึ้น คุณจึงสามารถตั้งค่าและรับค่าสีธีมเหล่านั้นได้

![additional-palette-colors](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - สีจากพาเลตเพิ่มเติม

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // สีเน้น 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // สีเน้น 4, เบาขึ้น 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // สีเน้น 4, เบาขึ้น 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // สีเน้น 4, เบาขึ้น 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // สีเน้น 4, เข้มขึ้น 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // สีเน้น 4, เข้มขึ้น 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **แม็พ `SchemeColor` ไปยังสี `IColorScheme`**

เมื่อคุณทำงานกับ [SchemeColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/schemecolor/), คุณอาจสังเกตว่ามีค่าธีมสีต่อไปนี้: `Background1`, `Background2`, `Text1`, และ `Text2`.

อย่างไรก็ตาม `Presentation.getMasterTheme().getColorScheme()` จะคืนค่า [IColorScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/icolorscheme/), ซึ่งเปิดเผยสีที่สอดคล้องกันเป็น: `Dark1`, `Dark2`, `Light1`, และ `Light2`.

ความแตกต่างนี้เป็นเพียงชื่อเรียก ค่าดังกล่าวอ้างอิงถึงช่องสีธีมเดียวกันและการแมพเป็นค่าคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ไม่มีการแปลงแบบไดนามิกระหว่าง `Text`/`Background` กับ `Dark`/`Light` พวกมันเป็นแค่ชื่อเรียกที่แตกต่างกันของสีธีมเดียวกัน

ความแตกต่างด้านชื่อเรียกนี้มาจากคำศัพท์ของ Microsoft Office เวอร์ชันเก่าใช้ `Dark 1`, `Light 1`, `Dark 2`, `Light 2` ส่วน UI เวอร์ชันใหม่แสดงช่องเดียวกันเป็น `Text 1`, `Background 1`, `Text 2`, `Background 2`

## **เปลี่ยนแบบอักษรธีม**

เพื่อให้คุณเลือกแบบอักษรสำหรับธีมและวัตถุประสงค์อื่น ๆ Aspose.Slides ใช้ตัวระบุพิเศษเหล่านี้ (คล้ายกับที่ใช้ใน PowerPoint):

* **+mn-lt** – แบบอักษรหลัก Latin (แบบอักษร Latin ย่อย)
* **+mj-lt** – แบบอักษรหัวเรื่อง Latin (แบบอักษร Latin หลัก)
* **+mn-ea** – แบบอักษรหลัก East Asian (แบบอักษร East Asian ย่อย)
* **+mj-ea** – แบบอักษรหลัก East Asian (แบบอักษร East Asian หลัก)

โค้ด Java นี้แสดงวิธีการกำหนดแบบอักษร Latin ให้กับองค์ประกอบธีม:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

โค้ด Java นี้แสดงวิธีการเปลี่ยนแบบอักษรธีมของการนำเสนอ:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

แบบอักษรในกล่องข้อความทั้งหมดจะถูกอัปเดต

{{% alert color="info" title="TIP" %}} 
คุณอาจต้องการดู [แบบอักษร PowerPoint](/slides/th/java/powerpoint-fonts/).
{{% /alert %}}

## **เปลี่ยนสไตล์พื้นหลังธีม**

โดยค่าเริ่มต้น แอป PowerPoint มีพื้นหลังที่กำหนดไว้ล่วงหน้า 12 แบบ แต่จะบันทึกเพียง 3 แบบจาก 12 แบบนั้นในการนำเสนอทั่วไป

![todo:image_alt_text](presentation-design_8.png)

ตัวอย่างเช่น หลังจากคุณบันทึกการนำเสนอในแอป PowerPoint คุณสามารถรันโค้ด Java นี้เพื่อตรวจสอบจำนวนพื้นหลังที่กำหนดไว้ล่วงหน้าในการนำเสนอ:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
โดยใช้คุณสมบัติ [BackgroundFillStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/FormatScheme) คุณสามารถเพิ่มหรือเข้าถึงสไตล์พื้นหลังในธีม PowerPoint
{{% /alert %}} 

โค้ด Java นี้แสดงวิธีการตั้งค่าพื้นหลังสำหรับการนำเสนอ:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**Index guide**: 0 ใช้สำหรับไม่มีการเติม สี ดัชนีเริ่มจาก 1

{{% alert color="info" title="TIP" %}} 
คุณอาจต้องการดู [พื้นหลัง PowerPoint](/slides/th/java/presentation-background/).
{{% /alert %}}

## **เปลี่ยนเอฟเฟกต์ธีม**

ธีม PowerPoint โดยทั่วไปมีค่า 3 ค่าในแต่ละอาเรย์สไตล์ อาเรย์เหล่านั้นรวมกันเป็นเอฟเฟกต์ 3 แบบ: Subtle, Moderate, และ Intense ตัวอย่างเช่น นี่คือผลลัพธ์เมื่อเอฟเฟกต์ถูกนำไปใช้กับรูปร่างเฉพาะหนึ่ง:

![todo:image_alt_text](presentation-design_10.png)

โดยใช้ 3 คุณสมบัติ ([FillStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/FormatScheme#getEffectStyles--)) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/FormatScheme) คุณสามารถเปลี่ยนองค์ประกอบในธีมได้อย่างยืดหยุ่นกว่าตัวเลือกใน PowerPoint

โค้ด Java นี้แสดงวิธีการเปลี่ยนเอฟเฟกต์ธีมโดยการแก้ไขส่วนต่าง ๆ ขององค์ประกอบ:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

การเปลี่ยนแปลงที่เกิดขึ้นในสีเติม, ประเภทการเติม, เงา ฯลฯ:

![todo:image_alt_text](presentation-design_11.png)

## **คำถามที่พบบ่อย**

### ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?

ใช่ Aspose.Slides รองรับการแทนที่ธีมระดับสไลด์ ดังนั้นคุณสามารถใช้ธีมท้องถิ่นกับสไลด์นั้นโดยไม่กระทบต่อธีมมาสเตอร์ (ผ่าน [SlideThemeManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidethememanager/))

### วิธีที่ปลอดภัยที่สุดในการนำธีมจากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่งคืออะไร?

[Clone slides](/slides/th/java/clone-slides/) พร้อมกับมาสเตอร์ของพวกมันไปยังการนำเสนอเป้าหมาย วิธีนี้จะรักษามาสเตอร์, แม่แบบ, และธีมที่เกี่ยวข้องไว้ ทำให้ลักษณะการแสดงผลคงที่

### ฉันจะดูค่าที่ "มีผล" หลังจากการสืบทอดและการแทนที่ทั้งหมดได้อย่างไร?

ใช้มุมมอง ["effective"](/slides/th/java/shape-effective-properties/) ของ API สำหรับธีม/สี/แบบอักษร/เอฟเฟกต์ ซึ่งจะคืนค่าคุณสมบัติที่ได้รับการแก้ไขขั้นสุดท้ายหลังจากรวมมาสเตอร์และการแทนที่ในระดับท้องถิ่น