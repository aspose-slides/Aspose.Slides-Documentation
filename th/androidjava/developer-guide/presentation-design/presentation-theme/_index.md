---
title: จัดการธีมการนำเสนอบน Android
linktitle: ธีมการนำเสนอ
type: docs
weight: 10
url: /th/androidjava/presentation-theme/
keywords:
- ธีม PowerPoint
- ธีมการนำเสนอ
- ธีมสไลด์
- ตั้งค่าธีม
- เปลี่ยนธีม
- จัดการธีม
- สีธีม
- พาเล็ตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ Android ผ่าน Java เพื่อสร้าง ปรับแต่งและแปลงไฟล์ PowerPoint ด้วยการสร้างแบรนด์ที่สอดคล้องกัน"
---
## **บทนำ**

ธีมการนำเสนอกำหนดคุณสมบัติขององค์ประกอบการออกแบบ เมื่อคุณเลือกธีมการนำเสนอ คุณกำลังเลือกชุดขององค์ประกอบภาพและคุณสมบัติเฉพาะของมัน

ใน PowerPoint ธีมประกอบด้วยสี, [แบบอักษร](/slides/th/androidjava/powerpoint-fonts/), [รูปแบบพื้นหลัง](/slides/th/androidjava/presentation-background/), และเอฟเฟกต์

![ส่วนประกอบของธีม](theme-constituents.png)

## **เปลี่ยนสีธีม**

ธีม PowerPoint ใช้ชุดสีเฉพาะสำหรับองค์ประกอบต่าง ๆ บนสไลด์ หากคุณไม่ชอบสีเหล่านั้น คุณสามารถเปลี่ยนสีโดยกำหนดสีใหม่ให้ธีมได้ เพื่อให้คุณเลือกสีธีมใหม่ Aspose.Slides ให้ค่าต่าง ๆ ภายใต้ enumeration [SchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SchemeColor)

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

คุณสามารถกำหนดค่าที่แท้จริงของสีที่ได้อย่างนี้:

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

เพื่อแสดงการเปลี่ยนสีเพิ่มเติม เราสร้างองค์ประกอบใหม่และกำหนดสีเน้น (จากการทำงานครั้งแรก) ให้กับมัน แล้วจึงเปลี่ยนสีในธีม:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

สีใหม่จะถูกนำไปใช้โดยอัตโนมัติบนทั้งสององค์ประกอบ

### **ตั้งค่าสีธีมจากพาเล็ตเพิ่มเติม**

เมื่อคุณทำการแปลงค่าความสว่างกับสีธีมหลัก(1) จะได้สีจากพาเล็ตเพิ่มเติม(2) คุณจึงสามารถตั้งค่าและดึงค่าสีธีมเหล่านั้นได้

![สีจากพาเล็ตเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก  
**2** - สีจากพาเล็ตเพิ่มเติม

โค้ด Java นี้แสดงการทำงานที่ดึงสีจากพาเล็ตเพิ่มเติมจากสีธีมหลักแล้วนำไปใช้ในรูปทรง:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Accent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Accent 4, สีอ่อน 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, สีอ่อน 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, สีอ่อน 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, สีเข้ม 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, สีเข้ม 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **แมพ `SchemeColor` ไปยังสี `IColorScheme`**

เมื่อคุณทำงานกับ [SchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/schemecolor/), คุณอาจสังเกตว่ามีค่าของสีธีมต่อไปนี้:

`Background1`, `Background2`, `Text1`, and `Text2`.

อย่างไรก็ตาม `Presentation.getMasterTheme().getColorScheme()` จะคืนค่า [IColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icolorscheme/), ซึ่งแสดงสีที่สอดคล้องกันเป็น:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

ความแตกต่างนี้เป็นเพียงการตั้งชื่อ ค่าเหล่านี้อ้างอิงถึงช่องสีธีมเดียวกันและการแมพจะคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ไม่มีการแปลงแบบไดนามิกระหว่าง `Text`/`Background` กับ `Dark`/`Light` พวกมันเป็นเพียงชื่อทางเลือกของสีธีมเดียวกัน

ความแตกต่างในการตั้งชื่อนี้มาจากคำศัพท์ของ Microsoft Office รุ่นเก่าใช้ `Dark 1`, `Light 1`, `Dark 2`, และ `Light 2` ในขณะที่ UI รุ่นใหม่แสดงช่องเดียวกันเป็น `Text 1`, `Background 1`, `Text 2`, และ `Background 2`.

## **เปลี่ยนฟอนต์ธีม**

เพื่อให้คุณเลือกฟอนต์สำหรับธีมและการใช้อื่น Aspose.Slides ใช้ตัวระบุพิเศษเหล่านี้ (คล้ายกับที่ใช้ใน PowerPoint):

* **+mn-lt** - ฟอนต์ข้อความหลัก Latin (ฟอนต์ Latin ย่อย)
* **+mj-lt** - ฟอนต์หัวเรื่อง Latin (ฟอนต์ Latin หลัก)
* **+mn-ea** - ฟอนต์ข้อความหลัก East Asian (ฟอนต์ East Asian ย่อย)
* **+mj-ea** - ฟอนต์ข้อความหลัก East Asian (ฟอนต์ East Asian หลัก)

โค้ด Java นี้แสดงวิธีการกำหนดฟอนต์ Latin ให้กับองค์ประกอบของธีม:

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

โค้ด Java นี้แสดงวิธีการเปลี่ยนฟอนต์ธีมการนำเสนอ:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

ฟอนต์ในกล่องข้อความทั้งหมดจะได้รับการอัปเดต

{{% alert color="info" title="TIP" %}} 
คุณอาจต้องการดู [ฟอนต์ PowerPoint](/slides/th/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **เปลี่ยนสไตล์พื้นหลังธีม**

โดยค่าเริ่มต้น แอป PowerPoint มีพื้นหลังที่กำหนดไว้ล่วงหน้า 12 รายการ แต่เพียง 3 จาก 12 รายการนั้นจะถูกบันทึกในงานนำเสนอทั่วไป

![todo:image_alt_text](presentation-design_8.png)

ตัวอย่างเช่น หลังจากคุณบันทึกงานนำเสนอในแอป PowerPoint คุณสามารถรันโค้ด Java นี้เพื่อหาจำนวนพื้นหลังที่กำหนดไว้ล่วงหน้าในงานนำเสนอ:

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
โดยใช้คุณสมบัติ [BackgroundFillStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FormatScheme) คุณสามารถเพิ่มหรือเข้าถึงสไตล์พื้นหลังในธีม PowerPoint ได้.
{{% /alert %}} 

โค้ด Java นี้แสดงวิธีการตั้งค่าพื้นหลังสำหรับงานนำเสนอ:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**แนวทางการใช้ดัชนี**: 0 ใช้สำหรับไม่เติม สี ดัชนีเริ่มจาก 1.

{{% alert color="info" title="TIP" %}} 
คุณอาจต้องการดู [พื้นหลัง PowerPoint](/slides/th/androidjava/presentation-background/).
{{% /alert %}}

## **เปลี่ยนเอฟเฟกต์ธีม**

ธีม PowerPoint ปกติจะมีค่า 3 ค่าสำหรับแต่ละชุดสไตล์ ชุดสไตล์เหล่านั้นจะถูกรวมเป็น 3 เอฟเฟกต์: เบา, ปานกลาง, และเข้ม ตัวอย่างเช่น นี่คือผลลัพธ์เมื่อเอฟเฟกต์ถูกนำไปใช้กับรูปร่างเฉพาะ:

![todo:image_alt_text](presentation-design_10.png)

โดยใช้ 3 คุณสมบัติ ([FillStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FormatScheme) คุณสามารถเปลี่ยนองค์ประกอบในธีมได้ (ยืดหยุ่นกว่าตัวเลือกใน PowerPoint).

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

การเปลี่ยนแปลงที่ได้ในสีเติม, ประเภทการเติม, เอฟเฟกต์เงา ฯลฯ:

![todo:image_alt_text](presentation-design_11.png)

## **ถาม‑ตอบ**

### ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?

ได้ Aspose.Slides รองรับการแทนที่ธีมระดับสไลด์ ดังนั้นคุณสามารถใช้ธีมเฉพาะสไลด์นั้นโดยคงธีมมาสเตอร์ไว้ (ผ่าน [SlideThemeManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidethememanager/)).

### วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอคืออะไร?

[Clone slides](/slides/th/androidjava/clone-slides/) พร้อมกับมาสเตอร์ของพวกเขาเข้าสู่การนำเสนอเป้าหมาย วิธีนี้จะรักษามาสเตอร์เดิม, เลย์เอาต์, และธีมที่เชื่อมโยงไว้เพื่อให้ลักษณะการแสดงผลคงที่.

### ฉันจะดูค่าที่ "effective" หลังจากการสืบทอดและการแทนที่ทั้งหมดได้อย่างไร?

ใช้มุมมอง ["effective"](/slides/th/androidjava/shape-effective-properties/) ของ API สำหรับธีม/สี/ฟอนต์/เอฟเฟกต์ ค่าที่คืนมาคือคุณสมบัติที่ได้รับการแก้ไขขั้นสุดท้ายหลังจากใช้มาสเตอร์และการแทนที่ในระดับท้องถิ่น.