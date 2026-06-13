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
- พาเล็ตเพิ่มเติม
- แบบอักษรธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยการบรรจุแบรนด์ที่สม่ำเสมอ."
---
## **บทนำ**

ธีมการนำเสนอกำหนดคุณสมบัติขององค์ประกอบการออกแบบ เมื่อคุณเลือกธีมการนำเสนอ คุณกำลังเลือกชุดขององค์ประกอบภาพและคุณสมบัติเฉพาะของมัน

ใน PowerPoint ธีมประกอบด้วยสี, [แบบอักษร](/slides/th/java/powerpoint-fonts/), [สไตล์พื้นหลัง](/slides/th/java/presentation-background/), และเอฟเฟกต์

![theme-constituents](theme-constituents.png)

## **เปลี่ยนสีธีม**

ธีม PowerPoint ใช้ชุดสีเฉพาะสำหรับองค์ประกอบต่าง ๆ บนสไลด์ หากคุณไม่ชอบสีเหล่านั้น คุณสามารถเปลี่ยนสีโดยการใช้สีใหม่สำหรับธีม Aspose.Slides มีค่าต่าง ๆ ภายใต้ enumeration [SchemeColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/SchemeColor)

โค้ด Java นี้แสดงวิธีเปลี่ยนสีสำเนียงของธีม:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

คุณสามารถกำหนดค่าที่มีผลของสีที่ได้ตามนี้:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

เพื่อแสดงการเปลี่ยนสีเพิ่มเติม เราจะสร้างองค์ประกอบอีกอันหนึ่งและกำหนดสีสำเนียง (จากการทำงานแรก) ให้กับมัน แล้วจึงเปลี่ยนสีในธีม:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

สีใหม่จะถูกนำไปใช้โดยอัตโนมัติบนทั้งสององค์ประกอบ

### **ตั้งค่าสีธีมจากพาเล็ตเพิ่มเติม**

เมื่อคุณทำการแปลงความสว่างให้กับสีธีมหลัก(1) จะได้สีจากพาเล็ตเพิ่มเติม(2) คุณจึงสามารถตั้งค่าและดึงค่าสีธีมเหล่านั้นได้

![additional-palette-colors](additional-palette-colors.png)

**1** - สีธีมหลัก  

**2** - สีจากพาเล็ตเพิ่มเติม

โค้ด Java นี้แสดงการดึงสีพาเล็ตเพิ่มเติมจากสีธีมหลักและนำไปใช้กับรูปร่าง:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // สีเน้น 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // สีเน้น 4, สว่างขึ้น 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // สีเน้น 4, สว่างขึ้น 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // สีเน้น 4, สว่างขึ้น 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // สีเน้น 4, มืดลง 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // สีเน้น 4, มืดลง 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **แมป `SchemeColor` ไปยังสี `IColorScheme`**

เมื่อคุณทำงานกับ [SchemeColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/schemecolor/) คุณอาจสังเกตว่ามีค่าธีมสีต่อไปนี้:

`Background1`, `Background2`, `Text1`, และ `Text2`.

แต่ `Presentation.getMasterTheme().getColorScheme()` จะคืนค่าเป็น [IColorScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/icolorscheme/) ซึ่งเปิดเผยสีที่สอดคล้องกันเป็น:

`Dark1`, `Dark2`, `Light1`, และ `Light2`.

ความแตกต่างนี้เป็นเพียงชื่อเท่านั้น ค่าต่าง ๆ อ้างอิงถึงตำแหน่งสีธีมเดียวกันและการแมปคงที่ดังนี้:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ไม่มีการแปลงแบบไดนามิกระหว่าง `Text`/`Background` กับ `Dark`/`Light` พวกเขาเป็นชื่อสลับกันของสีธีมเดียวกัน

ความแตกต่างของการตั้งชื่อนี้มาจากศัพท์ของ Microsoft Office รุ่นเก่าใช้ `Dark 1`, `Light 1`, `Dark 2`, `Light 2` ส่วน UI รุ่นใหม่แสดงตำแหน่งเดียวกันเป็น `Text 1`, `Background 1`, `Text 2`, `Background 2`

## **เปลี่ยนแบบอักษรธีม**

เพื่อให้คุณเลือกแบบอักษรสำหรับธีมและการใช้อื่น ๆ Aspose.Slides ใช้ตัวระบุพิเศษเหล่านี้ (คล้ายกับที่ใช้ใน PowerPoint):

* **+mn-lt** - แบบอักษรตัวอักษรละติน (Minor Latin Font)
* **+mj-lt** - แบบอักษรหัวเรื่องละติน (Major Latin Font)
* **+mn-ea** - แบบอักษรเอเชียตะวันออก (Minor East Asian Font)
* **+mj-ea** - แบบอักษรเอเชียตะวันออก (Major East Asian Font)

โค้ด Java นี้แสดงวิธีกำหนดแบบอักษรละตินให้กับองค์ประกอบธีม:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

โค้ด Java นี้แสดงวิธีเปลี่ยนแบบอักษรธีมของการนำเสนอ:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

แบบอักษรในกล่องข้อความทั้งหมดจะได้รับการอัปเดต

{{% alert color="primary" title="TIP" %}} 
คุณอาจต้องการดู [แบบอักษร PowerPoint](/slides/th/java/powerpoint-fonts/).
{{% /alert %}}

## **เปลี่ยนสไตล์พื้นหลังธีม**

โดยค่าเริ่มต้น PowerPoint มีพื้นหลังสำเร็จรูป 12 แบบ แต่เพียง 3 แบบจาก 12 แบบนั้นจะถูกบันทึกในงานนำเสนอทั่วไป

![todo:image_alt_text](presentation-design_8.png)

ตัวอย่างเช่น หลังจากบันทึกงานนำเสนอใน PowerPoint คุณสามารถรันโค้ด Java นี้เพื่อค้นหาจำนวนพื้นหลังสำเร็จรูปในงานนำเสนอ:

```java
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

โค้ด Java นี้แสดงวิธีตั้งค่าพื้นหลังสำหรับงานนำเสนอ:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**คู่มือดัชนี**: 0 ใช้สำหรับไม่มีการเติม สีเริ่มต้นที่ 1

{{% alert color="primary" title="TIP" %}} 
คุณอาจต้องการดู [พื้นหลัง PowerPoint](/slides/th/java/presentation-background/).
{{% /alert %}}

## **เปลี่ยนเอฟเฟกต์ธีม**

ธีม PowerPoint ปกติมีค่า 3 ค่าในแต่ละอาร์เรย์สไตล์ อาร์เรย์เหล่านี้รวมกันเป็น 3 เอฟเฟกต์: Subtle, Moderate, และ Intense ตัวอย่างเช่น นี่คือผลลัพธ์เมื่อเอฟเฟกต์ถูกนำไปใช้กับรูปร่างเฉพาะ

![todo:image_alt_text](presentation-design_10.png)

โดยใช้คุณสมบัติ 3 อย่าง ([FillStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/th/java/com.aspose.slides/FormatScheme#getEffectStyles--)) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/FormatScheme) คุณสามารถเปลี่ยนองค์ประกอบในธีมได้อย่างยืดหยุ่นมากกว่าตัวเลือกใน PowerPoint

โค้ด Java นี้แสดงวิธีเปลี่ยนเอฟเฟกต์ธีมโดยการปรับส่วนต่าง ๆ ขององค์ประกอบ:

```java
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

## **FAQ**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้ Aspose.Slides รองรับการแทนที่ธีมในระดับสไลด์ ดังนั้นคุณสามารถใช้ธีมเฉพาะสำหรับสไลด์นั้นโดยคงธีมมาสเตอร์ไว้ (ผ่าน [SlideThemeManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidethememanager/))

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานหนึ่งคืออะไร?**

[Clone slides](/slides/th/java/clone-slides/) พร้อมกับมาสเตอร์ของมันไปยังงานนำเป้าหมาย วิธีนี้จะคงมาสเตอร์, เลย์เอาต์และธีมที่เชื่อมโยงไว้ทำให้ลักษณะการแสดงผลสอดคล้องกัน

**ฉันจะดูค่า “effective” หลังจากการสืบทอดและการแทนที่ทั้งหมดได้อย่างไร?**

ใช้ ["effective" views](/slides/th/java/shape-effective-properties/) ของ API สำหรับธีม/สี/แบบอักษร/เอฟเฟกต์ ค่าที่คืนมาจะเป็นคุณสมบัติที่สรุปและสุดท้ายหลังจากใช้มาสเตอร์รวมกับการแทนที่ระดับท้องถิ่น.