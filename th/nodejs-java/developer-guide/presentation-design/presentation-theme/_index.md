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
- พาเล็ตเพิ่มเติม
- ฟอนต์ธีม
- สไตล์ธีม
- เอฟเฟกต์ธีม
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ควบคุมธีมการนำเสนอใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint พร้อมการสร้างแบรนด์ที่สม่ำเสมอ."
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี, ฟอนต์, สไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่ประสานกัน. วัตถุที่รับรู้ธีมอ้างอิงถึงคำนิยามที่แชร์เหล่านี้แทนการเก็บคุณสมบัติภาพแต่ละอย่างเป็นค่าคงที่, ดังนั้นการเปลี่ยนธีมสามารถอัปเดตวัตถุหลาย ๆ ตัวพร้อมกัน.

ใน Aspose.Slides, ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getmastertheme/). การนำเสนออาจมีการแทนที่ธีมในระดับที่ต่ำกว่าได้ด้วย. Master สามารถแทนที่ธีมการนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterthememanager/), ขณะที่เลย์เอาต์หรือสไลด์เดี่ยวสามารถแทนที่ธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseoverridethememanager/). โดยปฏิบัติ, ธีมที่มีผลสำหรับสไลด์จะถูกแก้ไขตามสายการสืบทอดนี้: ธีมการนำเสนอ, การแทนที่ของ Master, การแทนที่ของเลย์เอาต์, และการแทนที่ของสไลด์.

![ส่วนประกอบของธีม: สี, ฟอนต์, สไตล์พื้นหลัง, และเอฟเฟกต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงขั้นตอนการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, ปรับปรุงสไตล์พื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการแทนที่ถูกแก้ไขแล้ว.

## **ตรวจสอบธีม**

วัตถุ [MasterTheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mastertheme/) เปิดเผยโครงร่างสีของธีม, โครงร่างฟอนต์, และโครงร่างรูปแบบผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/mastertheme/). การตรวจสอบคอลเลกชันเหล่านี้ก่อนเปลี่ยนแปลงมีประโยชน์อย่างยิ่งเมื่อการนำเสนอมาจากแหล่งภายนอกเพราะจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน.

ตัวอย่างต่อไปนี้อ่านคุณสมบัติธีมหลักและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่เก็บไว้ในธีม:

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

หากไฟล์ใช้หลาย Master, อย่าสมมติว่าสไลด์ทั้งหมดมีธีมที่มีผลเดียวกัน. ตรวจสอบ Master ที่เชื่อมโยงกับสไลด์, และใช้ขั้นตอนการทำงานธีมที่มีผลที่แสดงต่อไปในบทความเมื่ออาจมีการแทนที่ในเลย์เอาต์หรือสไลด์.

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงถึงสีตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/schemecolor/) ได้. เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [ColorScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/colorscheme/), วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะถูกแก้ไขให้ใช้ค่าที่ใหม่. วัตถุที่ใช้สี RGB โดยตรงจะไม่ถูกเปลี่ยนแปลงโดยการอัปเดตสีธีม.

ตัวอย่างต่อไปนี้สร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์สีการเติมที่มีผล:

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

เพราะสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4`, สีที่มองเห็นจะเป็นสีแดงหลังจากเปลี่ยนธีม. หากคุณแทนที่สีสกีมด้วยสีโดยตรงบนรูปทรง, การเปลี่ยนแปลงต่อมาใน `Accent4` จะไม่มีผลต่อการเติมนั้นอีกต่อไป.

### **ใช้สีจากพาเล็ตเพิ่มเติม**

PowerPoint สร้างเวอร์ชันสีอ่อนและเข้มจากสีธีมโดยใช้การแปลงสี. Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/colortransformoperation/).

![สีธีมหลักและสีอ่อนและสีเข้มที่สร้างจากพาเล็ตเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก.

**2** - เวอร์ชันสีอ่อนและสีเข้มที่ผลิตจากสีธีมหลัก.

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกส่วนโดยอิงจาก `Accent4`, ใช้การแปลงความสว่างกับห้าอัน, และบันทึกผลลัพธ์:

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

เวอร์ชันเหล่านี้ยังคงอิงจากสีธีม. หาก `Accent4` เปลี่ยนในภายหลัง, สีที่แปลงจะถูกคำนวณใหม่จากค่า `Accent4` ที่ใหม่.

### **แมปค่า `SchemeColor` ไปยังช่อง `ColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2`, ในขณะที่ [ColorScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/colorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2`. การแมปคงที่ดังนี้:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง.

## **เปลี่ยนฟอนต์ธีม**

โครงร่างฟอนต์ธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับข้อความเนื้อหา. วิธีการ [FontScheme.getMajor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontscheme/) และ [FontScheme.getMinor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontscheme/) เปิดเผยชุดเหล่านั้น.

ตัวระบุฟอนต์ธีมที่เข้ากันกับ PowerPoint สามารถใช้ในรูปแบบข้อความได้:

* `+mn-lt` - ฟอนต์ตัวอักษรหลัก (Minor Latin Font)
* `+mj-lt` - ฟอนต์หัวเรื่อง (Major Latin Font)
* `+mn-ea` - ฟอนต์ตัวอักษรเอเชียตะวันออก (Minor East Asian Font)
* `+mj-ea` - ฟอนต์หัวเรื่องเอเชียตะวันออก (Major East Asian Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้ฟอนต์ธีม Latin หลักและบรรทัดเนื้อหาหนึ่งที่ใช้ฟอนต์ธีม Latin รอง. จากนั้นเปลี่ยนฟอนต์ธีมและบันทึกผลลัพธ์:

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

หัวเรื่องจะใช้งานฟอนต์หลักและข้อความเนื้อหาจะใช้งานฟอนต์รอง. ข้อความที่ระบุชื่อฟอนต์โดยตรงแทนตัวระบุธีมจะไม่สลับโดยอัตโนมัติเมื่อโครงร่างฟอนต์ธีมเปลี่ยน.

คอลเลกชันฟอนต์หลักและรองยังสามารถมีการแมปฟอนต์สำหรับระบบเขียนแต่ละระบบได้, เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana. เพื่อดู, เพิ่ม, แทนที่, หรือเอาการแมปเหล่านี้ออก, ดู [Script-Specific Theme Fonts](/slides/th/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์ในการนำเสนอ, ดู [PowerPoint Fonts](/slides/th/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

มีขั้นตอนการทำงานสองแบบที่พบบ่อย, และพวกมันแก้ปัญหาที่แตกต่างกัน.

### **รักษาธีมต้นฉบับเมื่อนำสไลด์ไปยังการนำเสนออื่น**

หากต้องการย้ายสไลด์ไปยังการนำเสนออื่นและรักษาการออกแบบเดิม, ให้คัดลอก Master ต้นฉบับไปยังการนำเสนอเป้าหมายด้วย [MasterSlideCollection.addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslidecollection/), จากนั้นคัดลอกสไลด์ด้วย [SlideCollection.addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/) และ Master ที่คัดลอกไว้. วิธีนี้จะนำ Master, เลย์เอาต์ของมัน, และธีมที่เกี่ยวข้องไปด้วย.

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

นี่เป็นขั้นตอนที่แนะนำเมื่อสไลด์ต้นฉบับต้องการลักษณะเดียวกันในปลายทาง. การคัดลอกเนื้อหาไปยัง Master ปลายทางที่ไม่มีความเกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลงได้.

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่แล้ว**

หากสไลด์เป้าหมายต้องคงอยู่บน Master และเลย์เอาต์ปัจจุบัน, ให้เริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นฉบับ. วิธีการ [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/overridetheme/) คัดลอมูลส่วนธีมหลักสามส่วนเข้าสู่การแทนที่.

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

วิธีนี้เปลี่ยนธีมที่ใช้โดยสไลด์นั้นโดยไม่กระทบต่อธีมที่สืบทอดโดยสไลด์อื่น. เพื่อลบการแทนที่ในระดับท้องถิ่นและกลับไปใช้ค่าที่สืบทอด, เรียกใช้ [OverrideTheme.clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/overridetheme/).

### **ใช้การแทนที่ธีมกับเลย์เอาต์**

การแทนที่ระดับเลย์เอาต์จะใช้กับสไลด์ที่ใช้เลย์เอาต์นั้น, ยกเว้นกรณีที่สไลด์ใด ๆ มีการแทนที่ของตนเอง. วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslidethememanager/):

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

ใช้ธีมระดับ Master หรือการนำเสนอเมื่อหลายเลย์เอาต์และสไลด์ควรแชร์การออกแบบฐานเดียวกัน, ใช้การแทนที่ระดับเลย์เอาต์เมื่อกลุ่มเลย์เอาต์หนึ่งต้องการสไตล์ที่ต่างออกไป, และใช้การแทนที่ระดับสไลด์เฉพาะกรณีพิเศษ. การแทนที่ระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมทั่วโลกในภายหลังคาดเดาได้ยากขึ้น.

## **ปรับปรุงสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกเก็บไว้ใน [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/formatscheme/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการกำหนดการเติมที่เก็บจริงในคอลเลกชันนี้ เพราะ UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ.

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมการนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง, ตรวจสอบคอลเลกชันที่เก็บและค่า [Background.getStyleIndex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/background/) ปัจจุบัน. ดัชนีสไตล์ `0` หมายถึงไม่มีการเติมที่มีธีม; ค่าบวกหมายถึงการอ้างอิงสไตล์พื้นหลังของธีม. สิ่งนี้แตกต่างจากการอ้างอิงดัชนีคอลเลกชัน JavaScript โดยตรง, ที่ดัชนี `0` หมายถึงรายการแรกที่เก็บ. อย่าสมมติว่าการนำเสนอทุกไฟล์มีจำนวนสไตล์การเติมพื้นหลังเท่ากัน.

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังที่มีธีมให้กับ Master แรก, และบันทึกการนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่ Master อ้างอิงและการแทนที่พื้นหลังใด ๆ ที่อยู่ในระดับเลย์เอาต์หรือสไลด์. หากสไลด์ใช้พื้นหลังของตนเอง, การเปลี่ยนพื้นหลังของ Master อย่างเดียวอาจไม่เปลี่ยนสไลด์นั้น. ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/background/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอดถูกนำมาใช้.

{{% alert color="warning" title="คำเตือน" %}}
อย่าใช้ดัชนีสไตล์เป็นดัชนีคอลเลกชันที่เริ่มจากศูนย์. อีกทั้งหลีกเลี่ยงการกำหนดเลขสไตล์จากไฟล์หนึ่งและสมมติว่ามันมีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ธีมเป็นเอกลักษณ์ของการนำเสนอแต่ละไฟล์.
{{% /alert %}}

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับการกำหนดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง, ดู [Presentation Background](/slides/th/nodejs-java/presentation-background/).
{{% /alert %}}

## **ปรับปรุงเอฟเฟกต์ของธีม**

โครงร่างรูปแบบของธีมมีคอลเลกชันการเติม, เส้น, และเอฟเฟกต์แยกกันที่เปิดเผยผ่าน [FormatScheme.getFillStyles](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/formatscheme/), และ [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/formatscheme/). ธีม Office ทั่วไปมักมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการฟอร์แมตแบบละเอียด, ปานกลาง, และเข้ม, แต่โค้ดควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติจำนวนคงที่.

![เอฟเฟกต์ธีมแบบละเอียด, ปานกลาง, และเข้มที่ใช้กับรูปทรงเดียวกัน](presentation-design_10.png)

เมื่อเรียกเข้าคอลเลกชันเหล่านี้ใน JavaScript, ดัชนีคอลเลกชันเริ่มจากศูนย์: ดัชนี `0` คือสไตล์แรกที่เก็บและดัชนี `2` คือสไตล์ที่สาม. ดัชนีการอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกต่างหาก, เปิดเผยผ่าน [ShapeStyle](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapestyle/). การแก้ไขสไตล์ธีมจะส่งผลต่อรูปทรงที่อ้างอิงสไตล์ธีมนั้น; รูปทรงที่มีการฟอร์แมตโดยตรงอาจยังคงไม่เปลี่ยนแปลง.

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่ต้องการหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์การเติมที่สาม, เปิดเงานอกในสไตล์เอฟเฟกต์ที่สาม, และบันทึกผลลัพธ์:

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

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้, สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์การเติมธีมที่สามจะกลายเป็นสีเขียวป่าเนื้อแข็ง, และสไตล์เอฟเฟกต์ที่สามจะได้รับเงานอกที่มีระยะ 10 จุด. ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นกับว่ารูปทรงแต่ละอันอ้างอิงช่องสไตล์ใดและว่าการฟอร์แมตโดยตรงได้แทนที่ธีมหรือไม่.

![สไตล์เอฟเฟกต์ของธีมหลังจากการเปลี่ยนเส้น, การเติม, และการตั้งค่าเงา](presentation-design_11.png)

## **อ่านค่าธีมที่มีผล**

อ็อบเจ็กต์ธีมดิบบอกคุณว่าอะไรถูกกำหนดที่ระดับใด. ค่าที่มีผลบอกคุณว่าสไลด์หรือรูปทรงใช้ค่าอะไรจริงหลังจากการสืบทอดและการแทนที่ในระดับท้องถิ่นถูกแก้ไขแล้ว. สำหรับสไลด์, เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseoverridethememanager/). สำหรับพื้นหลัง, ใช้ [Background.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/background/), และสำหรับการเติม, ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/).

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมรูปแรกจากสไลด์:

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ. หากคุณตรวจสอบเพียง [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getmastertheme/), คุณอาจพลาดการแทนที่ของ Master, เลย์เอาต์, สไลด์, หรือรูปทรงที่เปลี่ยนลักษณะสุดท้าย.

## **คำถามที่พบบ่อย**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยน Master ได้หรือไม่?**

ได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นการแทนที่ธีมของมัน. การเปลี่ยนแปลงจะอยู่ในระดับท้องถิ่นของสไลด์นั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมที่มีอยู่.

**วิธีที่ปลอดภัยที่สุดในการย้ายธีมจากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และรักษาลักษณะต้นฉบับ, ให้คัดลอก Master ต้นฉบับไปยังปลายทางและคัดลอกสไลด์ด้วย Master นั้นโดยใช้ [MasterSlideCollection.addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslidecollection/) และ [SlideCollection.addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/). วิธีนี้จะเก็บ Master, เลย์เอาต์, และธีมไว้ด้วยกัน.

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือธีมเลย์เอาต์และวิธีการข้อมูลที่มีผลที่สอดคล้องสำหรับอ็อบเจ็กต์รูปแบบเช่น [Background.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/). API เหล่านี้จะคืนค่าที่ได้รับการแก้ไขหลังจากการสืบทอดและการแทนที่ถูกนำไปใช้.