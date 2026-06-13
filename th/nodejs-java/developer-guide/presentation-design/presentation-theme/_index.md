---
title: จัดการธีมการนำเสนอใน JavaScript
linktitle: ธีมการนำเสนอ
type: docs
weight: 10
url: /th/nodejs-java/presentation-theme/
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
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ให้มีการออกแบบที่สอดคล้องกัน"
---
## **แนะนำ**

ธีมการนำเสนอกำหนดคุณสมบัติขององค์ประกอบการออกแบบ เมื่อคุณเลือกธีมการนำเสนอ คุณกำลังเลือกชุดขององค์ประกอบภาพและคุณสมบัติเฉพาะของมัน

ใน PowerPoint ธีมประกอบด้วยสี, [fonts](/slides/th/nodejs-java/powerpoint-fonts/), [background styles](/slides/th/nodejs-java/presentation-background/), และเอฟเฟกต์

![theme-constituents](theme-constituents.png)

## **เปลี่ยนสีธีม**

ธีม PowerPoint ใช้ชุดสีเฉพาะสำหรับองค์ประกอบต่าง ๆ บนสไลด์ หากคุณไม่ชอบสีเหล่านั้น คุณสามารถเปลี่ยนสีโดยกำหนดสีใหม่ให้กับธีม เพื่อให้คุณเลือกสีธีมใหม่ Aspose.Slides มีค่าให้ใช้ภายใต้ enumeration [SchemeColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SchemeColor)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

คุณสามารถกำหนดค่าที่มีผลของสีที่ได้โดยวิธีนี้:

```javascript
var fillEffective = shape.getFillFormat().getEffective();
var effectiveColor = fillEffective.getSolidFillColor();
console.log(java.callStaticMethodSync("java.lang.String", "format", "Color [A=%d, R=%d, G=%d, B=%d]", effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

เพื่อสาธิตการเปลี่ยนสีเพิ่มเติม เราจะสร้างองค์ประกอบใหม่และกำหนดสี accent (จากการดำเนินการเริ่มต้น) ให้กับมัน จากนั้นเปลี่ยนสีในธีม:

```javascript
var otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 120, 100, 100);
otherShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
otherShape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
pres.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

สีใหม่จะถูกนำไปใช้โดยอัตโนมัติบนทั้งสององค์ประกอบ

### **ตั้งค่าสีธีมจากพาเลตเพิ่มเติม**

เมื่อคุณใช้การแปลงลูมินานซ์กับสีธีมหลัก(1) จะสร้างสีจากพาเลตเพิ่มเติม(2) คุณจึงสามารถตั้งค่าและรับค่าสีธีมเหล่านั้นได้

![additional-palette-colors](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - สีจากพาเลตเพิ่มเติม

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    // สี Accent 4
    var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    // Accent 4, เบาขึ้น 80%
    var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.2);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.8);
    // Accent 4, เบาขึ้น 60%
    var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.6);
    // Accent 4, เบาขึ้น 40%
    var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.6);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, 0.4);
    // Accent 4, มืดลง 25%
    var shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.75);
    // Accent 4, มืดลง 50%
    var shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, 0.5);
    presentation.save(path + "example_accent4.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **แมป `SchemeColor` ไปยังสี `ColorScheme`**

เมื่อคุณทำงานกับ [SchemeColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/schemecolor/) คุณอาจสังเกตว่ามีค่าธีมสีต่อไปนี้:

`Background1`, `Background2`, `Text1`, และ `Text2`.

อย่างไรก็ตาม `Presentation.getMasterTheme().getColorScheme()` คืนค่า [ColorScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/colorscheme/) ซึ่งเปิดเผยสีที่สอดคล้องกันเป็น:

`Dark1`, `Dark2`, `Light1`, และ `Light2`.

ความแตกต่างนี้เป็นเพียงเรื่องชื่อเท่านั้น ค่าต่าง ๆ นี้อ้างอิงถึงช่องสีธีมเดียวกันและการแมปคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ไม่มีการแปลงแบบไดนามิกระหว่าง `Text`/`Background` กับ `Dark`/`Light` พวกมันเป็นเพียงชื่อทางเลือกของสีธีมเดียวกัน

ความแตกต่างของชื่อมาจากคำศัพท์ของ Microsoft Office เวอร์ชันเก่าของ Office ใช้ `Dark 1`, `Light 1`, `Dark 2`, และ `Light 2` ส่วน UI เวอร์ชันใหม่แสดงช่องเดียวกันเป็น `Text 1`, `Background 1`, `Text 2`, และ `Background 2`

## **เปลี่ยนแบบอักษรธีม**

เพื่อให้คุณเลือกฟอนต์สำหรับธีมและวัตถุประสงค์อื่น ๆ Aspose.Slides ใช้ตัวระบุพิเศษเหล่านี้ (คล้ายกับที่ใช้ใน PowerPoint):

* **+mn-lt** - ฟอนต์ตัวอักษรหลัก Latin (Minor Latin Font)
* **+mj-lt** - ฟอนต์หัวข้อ Latin (Major Latin Font)
* **+mn-ea** - ฟอนต์ตัวอักษรหลัก East Asian (Minor East Asian Font)
* **+mj-ea** - ฟอนต์หัวข้อ East Asian (Major East Asian Font)

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
var paragraph = new aspose.slides.Paragraph();
var portion = new aspose.slides.Portion("Theme text format");
paragraph.getPortions().add(portion);
shape.getTextFrame().getParagraphs().add(paragraph);
portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));
```

โค้ด JavaScript นี้แสดงวิธีกำหนดฟอนต์ Latin ให้กับองค์ประกอบของธีม:

```javascript
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
```

ฟอนต์ในกล่องข้อความทั้งหมดจะถูกอัปเดต

{{% alert color="primary" title="TIP" %}} 
คุณอาจต้องการดู [PowerPoint fonts](/slides/th/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **เปลี่ยนสไตล์พื้นหลังของธีม**

โดยค่าเริ่มต้น แอป PowerPoint มีพื้นหลังที่กำหนดล่วงหน้า 12 แบบ แต่ในงานนำเสนอทั่วไปจะบันทึกเพียง 3 แบบจาก 12 แบบเท่านั้น

![todo:image_alt_text](presentation-design_8.png)

เช่น หลังจากบันทึกงานนำเสนอในแอป PowerPoint คุณสามารถรันโค้ด JavaScript นี้เพื่อหาจำนวนพื้นหลังที่กำหนดล่วงหน้าในงานนำเสนอได้:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();
    console.log("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="warning" %}} 
โดยใช้คุณสมบัติ [BackgroundFillStyles](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FormatScheme) คุณสามารถเพิ่มหรือเข้าถึงสไตล์พื้นหลังในธีม PowerPoint
{{% /alert %}} 

โค้ด JavaScript นี้แสดงวิธีตั้งค่าพื้นหลังสำหรับงานนำเสนอ:

```javascript
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Index guide**: 0 ใช้สำหรับไม่มีการเติม สีเริ่มจาก 1

{{% alert color="primary" title="TIP" %}} 
คุณอาจต้องการดู [PowerPoint Background](/slides/th/nodejs-java/presentation-background/).
{{% /alert %}}

## **เปลี่ยนเอฟเฟกต์ธีม**

ธีม PowerPoint ปกติมีค่า 3 ค่าในแต่ละอาเรย์สไตล์ ค่าเหล่านี้จะถูกรวมเป็น 3 เอฟเฟกต์: Subtle, Moderate, และ Intense ตัวอย่างผลลัพธ์เมื่อเอฟเฟกต์ถูกนำไปใช้กับรูปทรงเฉพาะ:

![todo:image_alt_text](presentation-design_10.png)

โดยใช้ 3 คุณสมบัติ ([FillStyles](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FormatScheme#getEffectStyles--)) จากคลาส [FormatScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FormatScheme) คุณสามารถเปลี่ยนองค์ประกอบในธีมได้อย่างยืดหยุ่นกว่าตัวเลือกใน PowerPoint

```javascript
var pres = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10.0);
    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

การเปลี่ยนแปลงที่เกิดขึ้นในสีเติม, ประเภทเติม, เอฟเฟกต์เงา ฯลฯ:

![todo:image_alt_text](presentation-design_11.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนแม่แบบได้หรือไม่?**

ใช่ Aspose.Slides รองรับการแทนที่ธีมระดับสไลด์ ดังนั้นคุณสามารถใช้ธีมท้องถิ่นกับสไลด์นั้นโดยคงธีมแม่แบบไว้ (ผ่าน [SlideThemeManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidethememanager/))

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งคืออะไร?**

คลิก [Clone slides](/slides/th/nodejs-java/clone-slides/) พร้อมกับแม่แบบของพวกมันเข้าสู่งานนำหมายที่ต้องการ วิธีนี้คงรักษาแม่แบบเดิม, เค้าโครง, และธีมที่เชื่อมโยงไว้ ทำให้ลักษณะการแสดงผลคงที่

**ฉันจะดูค่าที่ “effective” หลังจากการสืบทอดและการแทนที่ทั้งหมดได้อย่างไร?**

ใช้ ["effective" views](/slides/th/nodejs-java/shape-effective-properties/) ของ API สำหรับธีม/สี/ฟอนต์/เอฟเฟกต์ ค่าต่าง ๆ จะถูกแก้ไขและแสดงผลสุดท้ายหลังจากนำแม่แบบและการแทนที่ท้องถิ่นมาประมวลผล```