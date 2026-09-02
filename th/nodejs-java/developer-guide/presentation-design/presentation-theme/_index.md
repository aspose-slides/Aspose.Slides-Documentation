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
- ธีมภายนอก
- THMX
- สีธีม
- พาเลตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟ็กต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint พร้อมการสร้างแบรนด์ที่สอดคล้องกัน"
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี, ฟอนต์, สไตล์พื้นหลัง, เติมสี, เส้น และเอฟเฟ็กต์ที่ประสานกัน วัตถุที่รับรู้ธีมจะอ้างอิงคำนิยามที่แชร์นี้แทนการเก็บค่าคุณสมบัติวิสูอัลแต่ละอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัปเดตวัตถุหลายรายการพร้อมกันได้

ใน Aspose.Slides ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getmastertheme/)。การนำเสนออาจมีการแทนที่ธีมในระดับที่ต่ำลงได้ มาสเตอร์สามารถแทนที่ธีมการนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterthememanager/)，ขณะที่เลเอาต์หรือสไลด์แต่ละสไลด์สามารถแทนที่ธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseoverridethememanager/)。โดยปฏิบัติ ธีมที่มีผลต่อสไลด์จะถูกกำหนดตามลำดับการสืบทอดนี้: ธีมการนำเสนอ → การแทนที่มาสเตอร์ → การแทนที่เลเอาต์ → การแทนที่สไลด์

![ส่วนประกอบของธีม: สี, ฟอนต์, สไตล์พื้นหลัง, และเอฟเฟ็กต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, อัปเดตสไตล์พื้นหลังและเอฟเฟ็กต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้รับการแก้ไขแล้ว

## **ตรวจสอบธีม**

อ็อบเจกต์ [MasterTheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mastertheme/) เปิดเผยสกีมสี, สกีมฟอนต์, และสกีมฟอร์แมตของธีมผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mastertheme/)。การตรวจสอบคอลเลกชันเหล่านี้ก่อนเปลี่ยนแปลงมีประโยชน์อย่างยิ่งเมื่อการนำมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์สามารถแตกต่างกันได้

ตัวอย่างต่อไปนี้อ่านคุณสมบัติธีมหลักและรายงานจำนวนสไตล์พื้นหลัง, เติมสี, เส้น, และเอฟเฟ็กต์ที่เก็บไว้ในธีม:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

หากไฟล์ใช้มาสเตอร์หลายตัว อย่าสรุปว่าแต่ละสไลด์มีธีมที่มีผลเท่ากัน ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์และใช้กระบวนการธีมที่มีผลตามที่แสดงต่อไปในบทความเมื่ออาจมีการแทนที่ที่เลเอาต์หรือสไลด์

## **เปลี่ยนสีของธีม**

การเติมสี, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [ColorScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/colorscheme/) วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะได้รับการแก้ไขด้วยค่าที่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัปเดตสีธีม

ตัวอย่างต่อจากต้นจนจบนี้สร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสีของธีม `Accent4` เป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, แล้วแสดงสีเติมที่มีผล:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจึงกลายเป็นสีแดงหลังจากเปลี่ยนธีม หากคุณเปลี่ยนสีสกีมเป็นสีโดยตรงบนรูปทรง การเปลี่ยนแปลงต่อไปของ `Accent4` จะไม่มีผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างสีที่อ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/colortransformoperation/)

![สีธีมหลักและสีอ่อน‑เข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** – สีธีมหลัก  

**2** – สีอ่อน‑เข้มที่สร้างจากสีธีมหลัก  

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปโดยอิงจาก `Accent4`, ใช้การแปลงความสว่างกับห้ารูปแล้วบันทึกผลลัพธ์:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

รูปแบบเหล่านี้ยังคงอิงตามสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงจะถูกคำนวณใหม่จากค่าของ `Accent4` ใหม่

### **แมปค่า `SchemeColor` ไปยังช่อง `ColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2` ในขณะที่ [ColorScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/colorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2` การแมปเป็นค่าคงที่:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกของช่องธีมเดียวกัน ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่ง

## **เปลี่ยนฟอนต์ของธีม**

สกีมฟอนต์ของธีมมีชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับข้อความตัว본문 วิธี [FontScheme.getMajor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontscheme/) และ [FontScheme.getMinor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontscheme/) เปิดเผยชุดเหล่านั้น

ตัวระบุฟอนต์ธีมที่เข้ากันกับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn‑lt` – ฟอนต์ตัว본문 ลาติน (Minor Latin Font)
* `+mj‑lt` – ฟอนต์หัวเรื่อง ลาติน (Major Latin Font)
* `+mn‑ea` – ฟอนต์ตัว본문 เอเชียตะวันออก (Minor East Asian Font)
* `+mj‑ea` – ฟอนต์หัวเรื่อง เอเชียตะวันออก (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งบรรทัดที่ใช้ฟอนต์ธีมลาตินหลักและบรรทัดข้อความตัว본문หนึ่งบรรทัดที่ใช้ฟอนต์ธีมลาตินรอง จากนั้นเปลี่ยนฟอนต์ธีมและบันทึกผลลัพธ์:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หัวเรื่องปฏิบัติตามฟอนต์หลักและข้อความตัว본문ปฏิบัติตามฟอนต์รอง ข้อความที่ระบุชื่อฟอนต์อย่างชัดเจนแทนตัวระบุธีมจะไม่สลับโดยอัตโนมัติเมื่อสกีมฟอนต์ธีมเปลี่ยน

คอลเลกชันฟอนต์หลักและรองยังสามารถบรรจุการแมปฟอนต์สำหรับระบบเขียนต่าง ๆ เช่น ซีริลลิก, อาหรับ, ญี่ปุ่น, จอร์เจีย, และทานา ดูวิธีตรวจสอบ, เพิ่ม, แทนที่ หรือเอาการแมปเหล่านี้ออกได้ที่ [Script‑Specific Theme Fonts](/slides/th/nodejs-java/script-specific-font-mappings/)

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์ในการนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/nodejs-java/powerpoint-fonts/) 
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

กระบวนการต่อไปนี้แก้ปัญหาต่าง ๆ ที่เกี่ยวกับธีม

### **ใช้ธีมภายนอกกับสไลด์ที่พึ่งพามาสเตอร์**

ใช้ [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการปรับสไตล์ทุกสไลด์ที่พึ่งพามาสเตอร์เฉพาะ เลือกมาสเตอร์จากคอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ซึ่งเป็นอ็อบเจกต์ [MasterSlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslidecollection/) แล้วส่งเส้นทางไฟล์ธีมไปยังเมธอด

เมธอดทำงานดังต่อไปนี้:

1. สร้างสไลด์มาสเตอร์ใหม่ตามมาสเตอร์ที่เลือก
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่
1. มอบมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่เคยพึ่งพามาสเตอร์ที่เลือก
1. คืนค่า [MasterSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/) ที่สร้างใหม่

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่พึ่งพามาสเตอร์แรกและบันทึกการนำเสนอ:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const selectedMaster = presentation.getMasters().get_Item(0);
    const themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    console.log("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxreadexception/) ตรวจสอบเส้นทางที่ผู้ใช้ระบุ, จัดการข้อผิดพลาดการเข้าถึงไฟล์ระบบ, แล้วบันทึกการนำเสนอเฉพาะหลังจากธีมถูกใช้สำเร็จ

เฉพาะสไลด์ที่พึ่งพามาสเตอร์ที่เลือกเท่านั้นที่ถูกกำหนดค่าใหม่ สไลด์ที่เชื่อมโยงกับมาสเตอร์อื่นจะคงมาสเตอร์และธีมเดิมไว้ สี, ฟอนต์, เติมสี, เส้น, พื้นหลัง, และเอฟเฟ็กต์ที่รับรู้ธีมจะถูกแก้ไขตามธีมภายนอก สี, ฟอนต์, เติมสี, และการจัดรูปแบบที่กำหนดโดยตรงอาจคงเดิม การแทนที่ระดับเลเอาต์และระดับสไลด์ก็อาจมีลำดับความสำคัญเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่

ธีมอาจอ้างอิงฟอนต์ที่ไม่มีในสภาพแวดล้อมรันไทม์ เพื่อให้การแสดงผลและการส่งออกสอดคล้องกัน ให้ติดตั้งฟอนต์ที่ต้องการ, ให้บริการผ่าน [custom font sources](/slides/th/nodejs-java/custom-font/), หรือกำหนดค่า [font substitution](/slides/th/nodejs-java/font-substitution/)

นี่เป็นกระบวนการทำงานระดับมาสเตอร์โดยตรง: เมธอดรับเส้นทางไฟล์ `.thmx` และไม่ต้องสร้างการแทนที่ธีมระดับสไลด์หรือเลเอาต์ด้วยตนเอง

### **ใช้ธีมภายนอกต่างกันในงานนำเสนอหลายมาสเตอร์**

เมื่อไม่ทราบมาสเตอร์ที่เกี่ยวข้องล่วงหน้า ให้ดึงมาสเตอร์จากสไลด์ตัวอย่างผ่าน [Slide.getLayoutSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/) และ [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/) เก็บอ้างอิงมาสเตอร์ดั้งเดิมไว้ก่อนใช้ธีมใด ๆ เพราะแต่ละครั้งที่เรียกจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อค้นหามาสเตอร์ของแต่ละส่วนและใช้ธีมภายนอกที่แตกต่างกันกับแต่ละกลุ่ม:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        console.log("The presentation does not contain the expected representative slides.");
    } else {
        const firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        const secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() === secondGroupMaster.getSlideId()) {
            console.log("The representative slides use the same master.");
        } else {
            const firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            const secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            console.log("First themed master: " + firstThemedMaster.getName());
            console.log("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

การเรียกครั้งแรกส่งผลต่อสไลด์ที่พึ่งพา `firstGroupMaster` เท่านั้น, การเรียกครั้งที่สองส่งผลต่อสไลด์ที่พึ่งพา `secondGroupMaster` เท่านั้น สไลด์ที่เชื่อมโยงกับมาสเตอร์อื่นจะไม่ถูกปรับสไตล์ใหม่

### **คงธีมต้นทางเมื่อนำสไลด์ไปยังงานนำเสนออื่น**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นและคงการออกแบบเดิมให้คัดลอกมาสเตอร์ต้นทางเข้าสู่งานนำเป้าหมายด้วย [MasterSlideCollection.addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslidecollection/), แล้วคัดลอกสไลด์ด้วย [SlideCollection.addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/) พร้อมมาสเตอร์ที่คัดลอกไว้ วิธีนี้จะพามาสเตอร์, เลเอาต์, และธีมที่เกี่ยวข้องไปด้วย

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

นี่เป็นกระบวนการทำงานที่แนะนำเมื่อสไลด์ต้นทางต้องแสดงผลเดียวกันในปลายทาง การคัดลอกเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่มีความสัมพันธ์อาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟ็กต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลงได้

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงมาสเตอร์และเลเอาต์ปัจจุบัน ให้เริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นทาง เมธอด [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/overridetheme/) จะคัดลอกส่วนประกอบธีมหลักสามส่วนเข้าสู่การแทนที่

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

การทำเช่นนี้เปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่กระทบต่อธีมที่สไลด์อื่นสืบทอด หากต้องการลบการแทนที่ระดับท้องถิ่นและคืนค่าเป็นค่าที่สืบทอด ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/overridetheme/)

### **ใช้การแทนที่ธีมกับเลเอาต์**

การแทนที่ระดับเลเอาต์จะใช้กับสไลด์ที่ใช้เลเอาต์นั้น เว้นแต่สไลด์ใดสไลด์หนึ่งจะมีการแทนที่ของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslidethememanager/):

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเลเอาต์และสไลด์ต้องการแชร์การออกแบบฐานเดียวกัน, ใช้การแทนที่เลเอาต์เมื่อครอบครัวเลเอาต์หนึ่งต้องการสไตล์ที่ต่างออกไป, และใช้การแทนที่สไลด์เฉพาะกรณีที่เป็นข้อยกเว้นจริง การแทนที่ระดับสไลด์มากเกินไปทำให้การเปลี่ยนแปลงธีมระดับทั่วโลกในภายหลังทำนายได้ยากขึ้น

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกเก็บไว้ใน [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/formatscheme/)。PowerPoint สามารถแสดงตัวเลือกพื้นหลังมากกว่าที่จำนวนคำนิยามการเติมที่เก็บอยู่ในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่นได้

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมการนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่เก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/background/) ปัจจุบัน ดัชนีสไตล์ `0` หมายถึงไม่มีการเติมที่มีธีม; ค่าบวกหมายถึงการอ้างอิงสไตล์พื้นหลังธีม นี่แตกต่างจากการอ้างอิงดัชนีของคอลเลกชัน JavaScript โดยตรงที่ดัชนี `0` หมายถึงรายการแรกที่เก็บไว้ อย่าสรุปว่าการนำเสนอทุกไฟล์มีจำนวนสไตล์เติมพื้นหลังเดียวกัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, มอบการอ้างอิงพื้นหลังธีมให้กับมาสเตอร์แรก, แล้วบันทึกการนำเสนอ:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการแทนที่พื้นหลังระดับเลเอตหรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนเฉพาะพื้นหลังมาสเตอร์อาจไม่กระทบต่อสไลด์นั้น ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/background/) เมื่อจำเป็นต้องทราบพื้นหลังสุดท้ายหลังจากการสืบทอดได้ถูกนำมาใช้

{{% alert color="warning" title="Warning" %}}
อย่าปฏิบัติดัชนีสไตล์เป็นดัชนีคอลเลกชันแบบศูนย์‑ฐาน นอกจากนี้ควรหลีกเลี่ยงการกำหนดหมายเลขสไตล์จากไฟล์หนึ่งและสันนิษฐานว่ามีลักษณะเดียวกันในไฟล์อื่น; คำนิยามสไตล์ธีมเป็นเอกลักษณ์ของการนำเสนอแต่ละไฟล์
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/nodejs-java/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟ็กต์ของธีม**

สกีมฟอร์แมตของธีมมีคอลเลกชันเติม, เส้น, และเอฟเฟ็กต์แยกกันที่เปิดเผยผ่าน [FormatScheme.getFillStyles](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/formatscheme/), และ [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/formatscheme/)。ธีมของ Office ทั่วไปมักมีสามรายการสไตล์หลักที่สอดคล้องกับการจัดรูปแบบแบบละเอียด, ปานกลาง, และเข้ม แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสันนิษฐานว่ามีจำนวนคงที่

![เอฟเฟ็กต์ธีมแบบละเอียด, ปานกลาง, และเข้มที่ใช้กับรูปทรงเดียวกัน](presentation-design_10.png)

เมื่อคุณเข้าถึงคอลเลกชันเหล่านี้ใน JavaScript ดัชนีคอลเลกชันเป็นศูนย์‑ฐาน: ดัชนี `0` คือสไตล์แรกที่เก็บ และดัชนี `2` คือสไตล์ที่สาม ดัชนีอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกต่างหาก เปิดเผยผ่าน [ShapeStyle](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapestyle/)。การแก้ไขสไตล์ธีมส่งผลต่อรูปทรงที่อ้างอิงสไตล์ธีมนั้น; รูปทรงที่กำหนดรูปแบบโดยตรงอาจคงเดิม

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดใช้งานเงานอกในสไตล์เอฟเฟ็กต์ที่สาม, แล้วบันทึกผลลัพธ์:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟ็กต์ที่สามจะเพิ่มเงานอกที่ระยะ 10 จุด ผลลัพธ์ที่เห็นอาจยังคงขึ้นกับว่ารูปทรงใดอ้างอิงช่องใดและว่าการจัดรูปแบบโดยตรงได้แทนที่ธีมหรือไม่

## **อ่านค่าธีมที่มีผล**

อ็อบเจกต์ธีมดิบบอกว่ามีการกำหนดอะไรที่ระดับใดระดับหนึ่ง ค่าที่มีผลบอกว่าสไลด์หรือรูปทรงใช้ค่าใดจริงหลังจากการสืบทอดและการแทนที่ในระดับท้องถิ่นได้รับการแก้ไขแล้ว สำหรับสไลด์ให้เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseoverridethememanager/)。สำหรับพื้นหลังใช้ [Background.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/background/), และสำหรับการเติมใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมของรูปทรงแรกจากสไลด์:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

ใช้ข้อมูลที่มีผลสำหรับการตรวจสอบการเรนเดอร์, การตรวจสอบความถูกต้อง, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getmastertheme/) คุณอาจพลาดมาสเตอร์, เลเอาต์, สไลด์, หรือการแทนที่รูปทรงที่เปลี่ยนลักษณะที่สุดท้าย

## **FAQ**

**การใช้ธีมภายนอกส่งผลต่อทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/) จะกำหนดใหม่เฉพาะสไลด์ที่พึ่งพามาสเตอร์ที่เลือก สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิมไว้

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นการแทนที่ธีมของมัน การเปลี่ยนแปลงจะอยู่เฉพาะสไลด์นั้น; สไลด์อื่นจะสืบทอดธีมตามที่มีอยู่

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และต้องคงลักษณะต้นฉบับ ให้คัดลอกมาสเตอร์ต้นทางเข้าสู่ปลายทางและคัดลอกสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [MasterSlideCollection.addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslidecollection/) และ [SlideCollection.addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/)。วิธีนี้จะรักษามาสเตอร์, เลเอาต์, และธีมไว้ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือธีมเลเอาต์และเมธอดข้อมูลที่มีผลที่สอดคล้องสำหรับอ็อบเจกต์ฟอร์แมต เช่น [Background.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/)。 API เหล่านี้คืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการแทนที่ถูกนำมาใช้  