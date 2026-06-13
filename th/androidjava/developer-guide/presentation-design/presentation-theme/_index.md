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
- พาเลตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟ็กต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน Aspose.Slides สำหรับ Android ผ่าน Java เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint โดยคงแบรนด์ดิ้งที่สอดคล้องกัน"
---
## **บทนำ**

ธีมการนำเสนอกำหนดคุณสมบัติขององค์ประกอบการออกแบบ เมื่อคุณเลือกธีมการนำเสนอ คุณกำลังเลือกชุดขององค์ประกอบภาพและคุณสมบัติเฉพาะของมัน

ใน PowerPoint ธีมประกอบด้วยสี, [ฟอนต์](/slides/th/androidjava/powerpoint-fonts/), [สไตล์พื้นหลัง](/slides/th/androidjava/presentation-background/), และเอฟเฟ็กต์

![theme-constituents](theme-constituents.png)

## **เปลี่ยนสีธีม**

ธีม PowerPoint ใช้ชุดสีเฉพาะสำหรับองค์ประกอบต่าง ๆ บนสไลด์ หากคุณไม่ชอบสีเหล่านั้น คุณสามารถเปลี่ยนสีโดยกำหนดสีใหม่ให้กับธีม เพื่อให้คุณเลือกสีธีมใหม่ Aspose.Slides ให้ค่าไว้ภายใต้การนับจำนวนของ enumeration [SchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/SchemeColor)

โค้ด Java นี้แสดงวิธีเปลี่ยนสีอักเซนท์สำหรับธีม:

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

คุณสามารถหาค่าที่แท้จริงของสีที่ได้จากการเปลี่ยนแปลงนี้ได้โดย:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

เพื่อสาธิตการเปลี่ยนสีเพิ่มเติม เราจะสร้างองค์ประกอบอีกหนึ่งอันและกำหนดสีอักเซนท์ (จากการดำเนินการแรก) ให้กับมัน แล้วจึงเปลี่ยนสีในธีม:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

สีใหม่จะถูกนำไปใช้โดยอัตโนมัติบนทั้งสององค์ประกอบ

### **กำหนดสีธีมจากพาเลตเพิ่มเติม**

เมื่อคุณทำการแปลงความสว่างของสีธีมหลัก (1) สีจากพาเลตเพิ่มเติม (2) จะถูกสร้างขึ้น จากนั้นคุณจึงสามารถตั้งค่าและรับค่าสีธีมเหล่านั้นได้

![additional-palette-colors](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - สีจากพาเลตเพิ่มเติม

โค้ด Java นี้แสดงการดำเนินการที่รับสีจากพาเลตเพิ่มเติมจากสีธีมหลักและนำไปใช้ในรูปทรง:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Accent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Accent 4, สว่างขึ้น 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, สว่างขึ้น 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, สว่างขึ้น 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, สีเข้มขึ้น 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, สีเข้มขึ้น 50%
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

เมื่อคุณทำงานกับ [SchemeColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/schemecolor/) คุณอาจสังเกตว่าในนั้นมีค่าธีมสีต่อไปนี้:

`Background1`, `Background2`, `Text1`, และ `Text2`

อย่างไรก็ตาม `Presentation.getMasterTheme().getColorScheme()` จะคืนค่า [IColorScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icolorscheme/) ซึ่งเปิดเผยสีที่สอดคล้องกันเป็น:

`Dark1`, `Dark2`, `Light1`, และ `Light2`

ความแตกต่างนี้อยู่ที่ชื่อเท่านั้น ค่าต่าง ๆ นี้อ้างอิงถึงสล็อตสีธีมเดียวกันและการแมปถูกกำหนดไว้คงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ไม่มีการแปลงแบบไดนามิกระหว่าง `Text`/`Background` และ `Dark`/`Light` พวกมันเป็นเพียงชื่อทางเลือกของสีธีมเดียวกัน

ความแตกต่างของชื่อมาจากศัพท์ของ Microsoft Office รุ่นเก่าจะใช้ `Dark 1`, `Light 1`, `Dark 2`, และ `Light 2` ส่วน UI รุ่นใหม่จะแสดงสล็อตเดียวกันเป็น `Text 1`, `Background 1`, `Text 2`, และ `Background 2`

## **เปลี่ยนฟอนต์ธีม**

เพื่อให้คุณสามารถเลือกฟอนต์สำหรับธีมและวัตถุประสงค์อื่น ๆ Aspose.Slides ใช้ตัวระบุพิเศษเหล่านี้ (คล้ายกับที่ใช้ใน PowerPoint):

* **+mn-lt** - ฟอนต์ข้อความหลัก Latin (Minor Latin Font)
* **+mj-lt** - ฟอนต์หัวเรื่อง Latin (Major Latin Font)
* **+mn-ea** - ฟอนต์ข้อความหลัก East Asian (Minor East Asian Font)
* **+mj-ea** - ฟอนต์หัวเรื่อง East Asian (Major East Asian Font)

โค้ด Java นี้แสดงวิธีกำหนดฟอนต์ Latin ให้กับองค์ประกอบธีม:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

โค้ด Java นี้แสดงวิธีเปลี่ยนฟอนต์ธีมการนำเสนอ:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

ฟอนต์ในกล่องข้อความทั้งหมดจะถูกอัปเดต

{{% alert color="primary" title="TIP" %}} 
คุณอาจต้องการดู [ฟอนต์ PowerPoint](/slides/th/androidjava/powerpoint-fonts/)
{{% /alert %}}

## **เปลี่ยนสไตล์พื้นหลังธีม**

โดยค่าเริ่มต้น แอป PowerPoint ให้พื้นหลังที่กำหนดล่วงหน้า 12 รูป แต่เพียง 3 รูปจาก 12 รูปนี้จะถูกบันทึกในงานนำเสนอทั่วไป

![todo:image_alt_text](presentation-design_8.png)

ตัวอย่างเช่น หลังจากคุณบันทึกงานนำเสนอในแอป PowerPoint คุณสามารถรันโค้ด Java นี้เพื่อค้นหาจำนวนพื้นหลังที่กำหนดล่วงหน้าในงานนำเสนอ:

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
โดยใช้คุณสมบัติ [BackgroundFillStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FormatScheme) คุณสามารถเพิ่มหรือเข้าถึงสไตล์พื้นหลังในธีม PowerPoint
{{% /alert %}} 

โค้ด Java นี้แสดงวิธีตั้งค่าพื้นหลังสำหรับงานนำเสนอ:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**คู่มือดัชนี**: 0 ใช้สำหรับไม่มีการเติม สี ดัชนีเริ่มจาก 1

{{% alert color="primary" title="TIP" %}} 
คุณอาจต้องการดู [พื้นหลัง PowerPoint](/slides/th/androidjava/presentation-background/)
{{% /alert %}}

## **เปลี่ยนเอฟเฟ็กต์ธีม**

ธีม PowerPoint ปกติมีค่าต่าง ๆ 3 ค่า สำหรับแต่ละอาร์เรย์สไตล์ ค่าพวกนี้ถูกรวมเป็น 3 เอฟเฟ็กต์: ละมุน (subtle), กลาง (moderate) และเข้ม (intense) ตัวอย่างเช่น นี่คือผลลัพธ์เมื่อเอฟเฟ็กต์เหล่านั้นถูกนำไปใช้กับรูปทรงเฉพาะ:

![todo:image_alt_text](presentation-design_10.png)

โดยใช้ 3 คุณสมบัติ ([FillStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FormatScheme) คุณสามารถเปลี่ยนองค์ประกอบในธีม (ยืดหยุ่นกว่าตัวเลือกใน PowerPoint)

โค้ด Java นี้แสดงวิธีเปลี่ยนเอฟเฟ็กต์ธีมโดยการปรับส่วนต่าง ๆ ขององค์ประกอบ:

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

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่ต้องเปลี่ยน Master ได้หรือไม่?**

ได้ Aspose.Slides รองรับการแทนที่ธีมในระดับสไลด์ ดังนั้นคุณสามารถใช้ธีมเฉพาะท้องถิ่นกับสไลด์นั้นได้โดยที่ยังคงธีม Master อยู่ (ผ่าน [SlideThemeManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidethememanager/))

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานหนึ่งคืออะไร?**

[คัดลอกสไลด์](/slides/th/androidjava/clone-slides/) พร้อมกับ Master ของมันไปยังงานนำเป้าหมาย วิธีนี้จะคง Master, Layouts และธีมที่เกี่ยวข้องไว้ ทำให้รูปลักษณ์สอดคล้องกัน

**ฉันจะดูค่าที่ “effective” หลังจากการสืบทอดและการแทนที่ทั้งหมดได้อย่างไร?**

ใช้ “effective” view ของ API [/slides/th/androidjava/shape-effective-properties/] สำหรับธีม/สี/ฟอนต์/เอฟเฟ็กต์ วิธีนี้จะคืนค่าคุณสมบัติที่ได้รับการแก้ไขขั้นสุดท้ายหลังจากนำ Master และการแทนที่ท้องถิ่นมาประยุกต์ใช้.