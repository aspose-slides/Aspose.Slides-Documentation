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
description: "ควบคุมธีมการนำเสนอหลักใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint ด้วยแบรนด์ที่สอดคล้องกัน."
---
## **บทนำ**

ธีมการนำเสนอกำหนดชุดสี ฟอนต์ สไตล์พื้นหลัง การเติมสี เส้น และเอฟเฟ็กต์ที่ประสานกัน วัตถุที่รับรู้ธีมจะอ้างอิงคำนิยามร่วมเหล่านี้แทนการเก็บคุณสมบัติสภาพทุกอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจึงสามารถอัปเดตวัตถุหลาย ๆ ตัวพร้อมกันได้

ใน Aspose.Slides ธีมระดับการนำเสนอสามารถเข้าถึงได้ผ่าน Presentation.getMasterTheme การนำเสนอสามารถมีการแทนที่ธีมในระดับที่ต่ำกว่าได้ มาสเตอร์สามารถแทนที่ธีมการนำเสนอผ่าน MasterThemeManager.getOverrideTheme ในขณะที่เค้าโครงหรือสไลด์เดี่ยวสามารถแทนที่ธีมที่สืบทอดมาผ่าน BaseOverrideThemeManager.getOverrideTheme โดยปฏิบัติแล้วธีมที่มีผลสำหรับสไลด์จะได้รับการแก้ไขผ่านสายการสืบทอดนี้: ธีมการนำเสนอ, การแทนที่ของมาสเตอร์, การแทนที่ของเค้าโครง, และการแทนที่ของสไลด์

![ส่วนประกอบของธีม: สี, ฟอนต์, สไตล์พื้นหลัง, และเอฟเฟ็กต์](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานกับธีมที่พบบ่อยที่สุด: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, ปรับปรุงสไตล์พื้นหลังและเอฟเฟ็กต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้รับการแก้ไขแล้ว

## **ตรวจสอบธีม**

MasterTheme object เปิดเผยโครงร่างสีของธีม, โครงร่างฟอนต์, และโครงร่างรูปแบบผ่าน MasterTheme.getColorScheme, MasterTheme.getFontScheme, และ MasterTheme.getFormatScheme การตรวจสอบคอลเลกชันเหล่านี้ก่อนทำการเปลี่ยนแปลงมีประโยชน์อย่างยิ่งเมื่อการนำเสนอมาจากแหล่งภายนอกเพราะจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

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

หากไฟล์ใช้มาสเตอร์หลายตัว อย่ากำหนดว่าทุกสไลด์มีธีมที่มีผลเหมือนกัน ตรวจสอบมาสเตอร์ที่เชื่อมโยงกับสไลด์และใช้กระบวนการทำงานธีมที่มีผลที่แสดงต่อมาภายในบทความนี้เมื่ออาจมีการแทนที่จากเค้าโครงหรือสไลด์

## **เปลี่ยนสีธีม**

การเติม, เส้น, และข้อความที่รับรู้ธีมสามารถอ้างอิงสีเชิงตรรกะจาก SchemeColor enumeration เมื่อคุณเปลี่ยนรายการที่สอดคล้องกันใน ColorScheme, วัตถุทั้งหมดที่ยังอ้างอิงสีธีมนั้นจะได้รับการประมวลผลกับค่าที่ใหม่ วัตถุที่ใช้สี RGB โดยตรงจะไม่เปลี่ยนแปลงจากการอัปเดตสีธีม

ตัวอย่างต่อไปนี้สร้างรูปทรงที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, แล้วพิมพ์สีการเติมที่มีผล:

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

เนื่องจากสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นจะแปลงเป็นสีแดงหลังจากธีมเปลี่ยน หากคุณแทนที่สีเชิงตรรกะด้วยสีโดยตรงในรูปทรง การเปลี่ยนแปลงต่อไปของ `Accent4` จะไม่มีผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างสีที่อ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน ColorTransformOperation enumeration

![สีธีมหลักและสีที่อ่อนและเข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** - สีธีมหลัก

**2** - สีอ่อนและเข้มที่ผลิตจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกรูปที่อิงจาก `Accent4`, ใช้การแปลงความสว่างกับห้ารูป, แล้วบันทึกผลลัพธ์:

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

รูปแบบเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงจะถูกคำนวณใหม่จากค่า `Accent4` ใหม่

### **แมปค่า `SchemeColor` ไปยังช่อง `ColorScheme`**

SchemeColor enumeration ใช้ `Text1`, `Background1`, `Text2`, และ `Background2` ในขณะที่ ColorScheme เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2` การแมปคงที่ดังนี้:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกสำหรับช่องธีมเดียวกัน; ไม่ได้เป็นค่าที่แปลงแบบไดนามิกจากรูปแบบหนึ่งไปยังอีกรูปแบบหนึ่ง

## **เปลี่ยนฟอนต์ธีม**

โครงร่างฟอนต์ธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวข้อและชุดฟอนต์รองสำหรับเนื้อหา วิธีการ FontScheme.getMajor และ FontScheme.getMinor เปิดเผยชุดเหล่านั้น

ตัวระบุฟอนต์ธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในรูปแบบข้อความได้:

* `+mn-lt` - ฟอนต์เนื้อหา Latin (ฟอนต์ Latin รอง)
* `+mj-lt` - ฟอนต์หัวข้อ Latin (ฟอนต์ Latin หลัก)
* `+mn-ea` - ฟอนต์เนื้อหา East Asian (ฟอนต์ East Asian รอง)
* `+mj-ea` - ฟอนต์หัวข้อ East Asian (ฟอนต์ East Asian หลัก)

ตัวอย่างต่อไปนี้สร้างหัวข้อหนึ่งที่ใช้ฟอนต์ Latin หลักของธีมและบรรทัดเนื้อหาหนึ่งที่ใช้ฟอนต์ Latin รองของธีม จากนั้นเปลี่ยนฟอนต์ธีมและบันทึกผลลัพธ์:

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

หัวข้อจะใช้ฟอนต์หลักและข้อความเนื้อหาจะใช้ฟอนต์รอง คำที่มีชื่อฟอนต์โดยตรงแทนตัวระบุธีมจะไม่สลับอัตโนมัติเมื่อโครงร่างฟอนต์ธีมเปลี่ยน

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์การนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

## **คัดลอกหรือใช้ธีม**

มีสองกระบวนการทำงานที่พบบ่อย และพวกมันแก้ปัญหาต่างกัน

### **รักษาธีมต้นฉบับขณะย้ายสไลด์**

หากต้องการย้ายสไลด์ไปยังการนำเสนออีกฉบับหนึ่งและรักษาการออกแบบเดิมไว้ ให้คลอนมาสเตอร์ต้นฉบับไปยังการนำเสนอเป้าหมายด้วย MasterSlideCollection.addClone, แล้วคลอนสไลด์ด้วย SlideCollection.addClone และมาสเตอร์ที่คลอนไว้ วิธีนี้จะนำมาสเตอร์, เค้าโครงและธีมที่เชื่อมโยงมาด้วยกัน

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

นี่เป็นกระบวนการที่แนะนำเมื่อสไลด์ต้นฉบับต้องแสดงผลเหมือนเดิมในปลายทาง การคลอนเนื้อหาไปยังมาสเตอร์ปลายทางที่ไม่เกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลังและเอฟเฟ็กต์ที่ขับเคลื่อนด้วยธีมเปลี่ยนแปลงได้

### **ใช้ค่าธีมกับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเค้าโครงปัจจุบัน ให้เริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นฉบับ วิธี OverrideTheme.initColorSchemeFrom, OverrideTheme.initFontSchemeFrom, และ OverrideTheme.initFormatSchemeFrom คัดลอกส่วนประกอบธีมหลักสามส่วนเข้าสู่การแทนที่

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

การทำเช่นนี้จะเปลี่ยนธีมที่สไลด์นั้นใช้โดยไม่เปลี่ยนธีมที่สไลด์อื่นสืบทอด หากต้องการลบการแทนที่ในระดับท้องถิ่นและกลับไปใช้ค่าที่สืบทอด ให้เรียก OverrideTheme.clear

### **ใช้การแทนที่ธีมกับเค้าโครง**

การแทนที่ระดับเค้าโครงใช้กับสไลด์ที่ใช้เค้าโครงนั้น เว้นแต่สไลด์บางรายการจะมีการแทนที่ของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน LayoutSlideThemeManager:

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

ใช้ธีมระดับมาสเตอร์หรือการนำเสนอเมื่อหลายเค้าโครงและสไลด์ควรแชร์การออกแบบฐานเดียวกัน, ใช้การแทนที่เค้าโครงเมื่อครอบครัวเค้าโครงหนึ่งต้องการสไตล์แตกต่าง, และใช้การแทนที่สไลด์เฉพาะกรณีพิเศษ การแทนที่ระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมทั่วโลกในภายหลังคาดเดาได้ยาก

## **อัปเดตสไตล์พื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกจัดเก็บใน FormatScheme.getBackgroundFillStyles PowerPoint สามารถแสดงตัวเลือกพื้นหลังได้มากกว่าจำนวนการกำหนดการเติมที่จัดเก็บในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและอ้างอิงสไตล์อื่น ๆ

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมการนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ให้ตรวจสอบคอลเลกชันที่จัดเก็บและค่า Background.getStyleIndex ปัจจุบัน ดัชนีสไตล์ `0` หมายถึงไม่มีการเติมธีม; ค่าบวกหมายถึงอ้างอิงสไตล์พื้นหลังของธีม นี่แตกต่างจากการจัดทำดัชนีคอลเลกชัน JavaScript โดยตรงที่ `0` หมายถึงรายการแรกที่จัดเก็บ อย่ากำหนดว่าการนำเสนอทุกไฟล์มีจำนวนสไตล์การเติมพื้นหลังเท่ากัน

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการแทนที่พื้นหลังที่อาจมีในระดับเค้าโครงหรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังของมาสเตอร์อย่างเดียวอาจไม่เปลี่ยนสไลด์นั้น ใช้ Background.getEffective เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังจากการสืบทอดถูกนำไปใช้

{{% alert color="warning" title="คำเตือน" %}}
ไม่ควรถือดัชนีสไตล์เป็นดัชนีคอลเลกชันที่เริ่มจากศูนย์ อีกทั้งหลีกเลี่ยงการกำหนดหมายเลขสไตล์จากไฟล์หนึ่งแล้วสมมติว่ามีลักษณะเดียวกันในไฟล์อื่น; คำจำกัดความสไตล์ธีมเป็นแบบเฉพาะการนำเสนอ
{{% /alert %}}

{{% alert color="info" title="เคล็ดลับ" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/nodejs-java/presentation-background/).
{{% /alert %}}

## **อัปเดตเอฟเฟ็กต์ของธีม**

โครงร่างรูปแบบของธีมมีคอลเลกชันการเติม, เส้น, และเอฟเฟ็กต์แยกกันที่เปิดเผยผ่าน FormatScheme.getFillStyles, FormatScheme.getLineStyles, และ FormatScheme.getEffectStyles ธีมออฟฟิศทั่วไปมักมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบแบบละเอียด, ปานกลาง, และเข้ม แต่ควรตรวจสอบแต่ละคอลเลกชันแทนการสันนิษฐานว่ามีจำนวนคงที่

![เอฟเฟ็กต์ธีมแบบละเอียด ปานกลาง และเข้มที่ใช้กับรูปร่างเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน JavaScript ดัชนีคอลเลกชันเริ่มจากศูนย์: ดัชนี `0` คือสไตล์แรกที่จัดเก็บและดัชนี `2` คือสไตล์ที่สาม ดัชนีอ้างอิงสไตล์ของรูปทรงเป็นแนวคิดแยกต่างหากที่เปิดเผยผ่าน ShapeStyle การแก้ไขสไตล์ธีมจะส่งผลต่อรูปทรงที่อ้างอิงสไตล์ธีมนั้น; รูปร่างที่มีการจัดรูปแบบโดยตรงอาจไม่ได้เปลี่ยนแปลง

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

สำหรับรูปทรงที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะกลายเป็นสีแดง, สไตล์เติมธีมที่สามจะกลายเป็นสีเขียวป่าแบบทึบ, และสไตล์เอฟเฟ็กต์ที่สามจะได้รับเงานอกโดยระยะ 10 จุด ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นอยู่กับว่ารูปร่างแต่ละรูปอ้างอิงช่องสไตล์ใดและการจัดรูปแบบโดยตรงอาจแทนที่ธีมหรือไม่

![สไตล์เอฟเฟ็กต์ของธีมหลังจากเปลี่ยนการตั้งค่าเส้น การเติม และเงา](presentation-design_11.png)

## **อ่านค่าธีมที่มีผล**

อ็อบเจกต์ธีมดิบบอกคุณว่ามีการกำหนดอะไรในระดับใดระดับหนึ่ง ค่าที่มีผลบอกคุณว่าสไลด์หรือรูปทรงใช้ค่าอะไรหลังจากการสืบทอดและการแทนที่ในท้องถิ่นได้รับการแก้ไขแล้ว สำหรับสไลด์ให้เรียก BaseOverrideThemeManager.createThemeEffective สำหรับพื้นหลังใช้ Background.getEffective และสำหรับการเติมใช้ FillFormat.getEffective

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการแสดงผล, การตรวจสอบ และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ Presentation.getMasterTheme คุณอาจพลาดมาสเตอร์, เค้าโครง, สไลด์, หรือการแทนที่ของรูปทรงที่เปลี่ยนลักษณะสุดท้าย

## **FAQ**

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่ต้องเปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้ ใช้ SlideThemeManager ของสไลด์และเริ่มต้นธีมการแทนที่ของมัน การเปลี่ยนแปลงจะอยู่ในระดับสไลด์นั้นเท่านั้น; สไลด์อื่นจะยังคงสืบทอดธีมที่มีอยู่

**วิธีที่ปลอดภัยที่สุดในการนำธีมจากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่งคืออะไร?**

เมื่อย้ายสไลด์และรักษาการออกแบบต้นฉบับ ให้คลอนมาสเตอร์ต้นฉบับไปยังปลายทางและคลอนสไลด์ด้วยมาสเตอร์นั้นโดยใช้ MasterSlideCollection.addClone และ SlideCollection.addClone วิธีนี้จะเก็บมาสเตอร์, เค้าโครง, และธีมไว้ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้อย่างไร?**

ใช้ BaseOverrideThemeManager.createThemeEffective สำหรับสไลด์หรือธีมเค้าโครงและใช้วิธีการได้ผลลัพธ์ที่มีผลสำหรับอ็อบเจกต์รูปแบบเช่น Background.getEffective และ FillFormat.getEffective API เหล่านี้จะคืนค่าที่แก้ไขแล้วหลังจากการสืบทอดและการแทนที่ถูกนำไปใช้