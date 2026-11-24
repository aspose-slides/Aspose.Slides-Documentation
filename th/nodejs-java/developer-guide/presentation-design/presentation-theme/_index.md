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
- ธีมนอก
- THMX
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
description: "ควบคุมธีมการนำเสนอใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js เพื่อสร้าง ปรับแต่ง และแปลงไฟล์ PowerPoint พร้อมการสร้างแบรนด์ที่สอดคล้องกัน"
---
## **บทนำ**

ธีมของงานนำเสนอกำหนดชุดสี ฟอนต์ รูปแบบพื้นหลัง การเติม สี เส้น และเอฟเฟกต์ที่สอดคล้องกัน วัตถุที่รู้จักธีมจะอ้างอิงคำนิยามที่แชร์เหล่านี้แทนการเก็บคุณสมบัติวิสชวลแต่ละอย่างเป็นค่าคงที่ ดังนั้นการเปลี่ยนธีมจะสามารถอัปเดตวัตถุหลาย ๆ ตัวพร้อมกัน

ใน Aspose.Slides ธีมระดับงานนำเสนอสามารถเข้าถึงได้ผ่าน [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/). งานนำเสนอยังอาจมีการบันทึกการแทนที่ธีมในระดับที่ต่ำลงได้ มาสเตอร์สามารถบันทึกการแทนที่ธีมของงานนำเสนอผ่าน [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterthememanager/), ในขณะที่เลเอาท์หรือสไลด์แต่ละอันสามารถบันทึกการแทนที่ธีมที่สืบทอดมาผ่าน [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/). โดยปฏิบัติ การกำหนดธีมที่มีผลสำหรับสไลด์จะถูกแก้ไขผ่านโซ่การสืบทอดนี้: ธีมของงานนำเสนอ, การแทนที่ของมาสเตอร์, การแทนที่ของเลเอาท์, และการแทนที่ของสไลด์

![ส่วนประกอบของธีม: สี, ฟอนต์, รูปแบบพื้นหลัง, และเอฟเฟกท์](theme-constituents.png)

ส่วนต่อไปนี้แสดงกระบวนการทำงานที่พบบ่อยที่สุดของธีม: ตรวจสอบธีม, เปลี่ยนสีและฟอนต์, คัดลอกหรือใช้ธีม, ปรับปรุงรูปแบบพื้นหลังและเอฟเฟกต์, และอ่านค่าที่มีผลหลังจากการสืบทอดและการแทนที่ได้ถูกแก้ไข

## **ตรวจสอบธีม**

อ็อบเจ็กต์ [MasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) เปิดเผยโครงร่างสีกของธีม, โครงร่างฟอนต์, และโครงร่างรูปแบบผ่าน [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/), และ [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/). การตรวจสอบคอลเลกชันเหล่านี้ก่อนที่จะเปลี่ยนแปลงเป็นประโยชน์อย่างยิ่งเมื่อ งานนำเสนอมาจากแหล่งภายนอก เนื่องจากจำนวนและเนื้อหาของรายการสไตล์อาจแตกต่างกัน

ตัวอย่างต่อไปนี้อ่านคุณสมบัติเบื้องต้นของธีมและรายงานจำนวนสไตล์พื้นหลัง, การเติม, เส้น, และเอฟเฟกต์ที่จัดเก็บไว้ในธีม:

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

หากไฟล์ใช้มาสเตอร์หลายชุด อย่าสันนิษฐานว่าทุกสไลด์มีธีมที่มีผลเดียวกัน ตรวจสอบมาสเตอร์ที่เชื่อมกับสไลด์ และใช้กระบวนการทำงานธีมที่มีผลที่แสดงต่อไปในบทความนี้เมื่ออาจมีการแทนที่เลเอาท์หรือสไลด์

## **เปลี่ยนสีของธีม**

การเติม, เส้น, และข้อความที่รู้จักธีมสามารถอ้างอิงสีเชิงตรรกะจาก enumeration [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) เมื่อคุณเปลี่ยนรายการที่สอดคล้องใน [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/), ทุกวัตถุที่ยังอ้างอิงสีธีมนั้นจะได้รับการแก้ไขตามค่าที่ใหม่ วัตถุที่ใช้สี RGB ตรงจะไม่ได้รับผลโดยการอัปเดตสีของธีม

ตัวอย่างต่อไปนี้สร้างรูปร่างที่ใช้ `Accent4`, เปลี่ยนสี `Accent4` ของธีมเป็นสีแดง, บันทึกงานนำเสนอ, เปิดใหม่, และพิมพ์สีการเติมที่มีผล:

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

เพราะสี่เหลี่ยมยังคงเชื่อมโยงกับ `Accent4` สีที่มองเห็นได้จะกลายเป็นสีแดงหลังจากธีมถูกเปลี่ยน หากคุณแทนที่สีสคีมด้วยสีโดยตรงบนรูปร่าง การเปลี่ยนแปลงต่อมาใน `Accent4` จะไม่ส่งผลต่อการเติมนั้นอีกต่อไป

### **ใช้สีจากพาเลตเพิ่มเติม**

PowerPoint สร้างรูปแบบสีอ่อนและเข้มจากสีธีมโดยใช้การแปลงสี Aspose.Slides เปิดเผยการแปลงเหล่านี้ผ่าน enumeration [ColorTransformOperation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colortransformoperation/).

![สีธีมหลักและสีอ่อน‑เข้มที่สร้างจากพาเลตเพิ่มเติม](additional-palette-colors.png)

**1** – สีธีมหลัก

**2** – รูปแบบสีอ่อนและเข้มที่สร้างจากสีธีมหลัก

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมหกอันโดยอิงจาก `Accent4`, ใช้การแปลงความสว่างกับห้าอัน, แล้วบันทึกผลลัพธ์:

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

รูปแบบเหล่านี้ยังคงอิงจากสีธีม หาก `Accent4` เปลี่ยนในภายหลัง สีที่แปลงแล้วจะถูกคำนวณใหม่จากค่า `Accent4` ที่ใหม่

### **แมพค่า `SchemeColor` ไปยังช่อง `ColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) ใช้ `Text1`, `Background1`, `Text2`, และ `Background2`, ขณะที่ [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) เปิดเผยช่องธีมเดียวกันเป็น `Dark1`, `Light1`, `Dark2`, และ `Light2`. การแมพคงที่ตามนี้:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

เหล่านี้เป็นชื่อทางเลือกของช่องธีมเดียวกัน; ไม่ใช่ค่าที่ถูกแปลงแบบไดนามิกจากรูปแบบหนึ่งไปอีกแบบหนึ่ง

## **เปลี่ยนฟอนต์ของธีม**

โครงร่างฟอนต์ของธีมประกอบด้วยชุดฟอนต์หลักสำหรับหัวเรื่องและชุดฟอนต์รองสำหรับข้อความตัว body. วิธีการ [FontScheme.getMajor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) และ [FontScheme.getMinor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) เปิดเผยชุดเหล่านั้น

ตัวระบุฟอนต์ของธีมที่เข้ากันได้กับ PowerPoint สามารถใช้ในการจัดรูปแบบข้อความได้:

* `+mn‑lt` – ฟอนต์ Body Latin (Minor Latin Font)
* `+mj‑lt` – ฟอนต์ Heading Latin (Major Latin Font)
* `+mn‑ea` – ฟอนต์ Body East Asian (Minor East Asian Font)
* `+mj‑ea` – ฟอนต์ Heading East Asian (Major East Asian Font)
* `+mn‑cs` – ฟอนต์ Body Complex Script (Minor Complex Script Font)
* `+mj‑cs` – ฟอนต์ Heading Complex Script (Major Complex Script Font)

ตัวอย่างต่อไปนี้สร้างหัวเรื่องหนึ่งที่ใช้ฟอนต์ Latin หลักของธีมและบรรทัดเนื้อหาหนึ่งที่ใช้ฟอนต์ Latin รองของธีม จากนั้นเปลี่ยนฟอนต์ของธีมและบันทึกผลลัพธ์:

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

หัวเรื่องใช้งานฟอนต์หลักและข้อความตัว body ใช้งานฟอนต์รอง ข้อความที่ระบุชื่อฟอนต์โดยตรงแทนตัวระบุของธีมจะไม่สลับอัตโนมัติเมื่อโครงร่างฟอนต์ของธีมเปลี่ยน

ชุดฟอนต์หลักและรองอาจมีการแมพฟอนต์สำหรับระบบเขียนที่แตกต่างกัน เช่น Cyrillic, Arabic, Japanese, Georgian, และ Thaana. เพื่อดู, เพิ่ม, แทนที่, หรือเอาแมพเหล่านี้ออก ให้ดูที่ [Script-Specific Theme Fonts](/slides/th/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
สำหรับข้อมูลเพิ่มเติมเกี่ยวกับฟอนต์ในงานนำเสนอ ดูที่ [PowerPoint Fonts](/slides/th/nodejs-java/powerpoint-fonts/).
{{% /alert %}}

### **แก้ไขการอ้างอิงฟอนต์ของธีม**

เมื่อทำการตรวจสอบข้อความ, [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) อาจคืนค่าการอ้างอิงธีมเช่น `+mn‑lt` แทนชื่อฟอนต์จริง เรียก [FontData.getFontName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) พร้อมธีมที่มีผลที่เหมาะสมเพื่อแก้ไขการอ้างอิงนั้น คำนำหน้า `+mj` และ `+mn` เลือกชุดฟอนต์หลักและรอง; ส่วนต่อท้าย `-lt`, `-ea`, `-cs` เลือกฟอนต์ Latin, East Asian, และ Complex Script ตามลำดับ

รับธีมที่มีผลผ่าน [Slide.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) บนวัตถุที่ธีมของมันใช้กับข้อความที่ตรวจสอบ สำหรับข้อความทั่วไปบนสไลด์ ให้เรียกเมธอดนี้บนสไลด์เพื่อให้คอนเทกซ์รวมธีมที่สืบทอดและการแทนที่ในระดับท้องถิ่น เมื่อตรวจสอบเลเอาท์หรือมาสเตอร์โดยตรง ให้ใช้ธีมที่มีผลของมันเอง อย่าสันนิษฐานว่าธีมของมาสเตอร์แรกใช้กับทุกสไลด์

ตัวอย่างต่อไปนี้สร้างส่วนข้อความที่อ้างอิงฟอนต์ Latin รองโดยเจาะจง เริ่มต้นโครงร่างฟอนต์ของสไลด์ผ่าน [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) และตั้งฟอนต์ Latin หลักและรองเป็น `Arial` และ `Calibri` ทำให้ผลลัพธ์สามารถทำซ้ำได้โดยไม่ต้องใช้ไฟล์อินพุต:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Calibri"));

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    const font = portion.getPortionFormat().getLatinFont();
    const effectiveTheme = slide.createThemeEffective();
    console.log(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    const explicitFont = new aspose.slides.FontData("Verdana");
    console.log(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

ผลลัพธ์คือ `+mn‑lt -> Calibri` ตามด้วย `Verdana -> Verdana` การอ้างอิงที่จัดเก็บยังคงไม่เปลี่ยนแปลง ส่วนชื่อฟอนต์ที่เจาะจงจะถูกส่งคืนตามเดิม หากส่วนข้อความใช้ `+mj‑lt` จะได้รับการแก้เป็น `Arial` ในธีมนี้

การแก้ไขการอ้างอิงธีมจะบ่งบอกฟอนต์ที่ธีมกำหนด ไม่ได้ตรวจสอบความพร้อมใช้งานของฟอนต์หรือไฟล์ฟอนต์ที่ใช้จริงหลังการทดแทนหรือ glyph fallback ระหว่างการเรนเดอร์ ดูที่ [Font Selection Sequence](/slides/th/nodejs-java/font-selection-sequence/) และ [Font Substitution](/slides/th/nodejs-java/font-substitution/) สำหรับขั้นตอนแยกเหล่านั้น

## **คัดลอกหรือใช้ธีม**

กระบวนการต่อไปนี้แก้ไขปัญหาที่เกี่ยวข้องกับธีมต่าง ๆ

### **ใช้ธีมภายนอกกับสไลด์ที่พึ่งพามาสเตอร์**

ใช้ [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) เมื่อคุณมีไฟล์ธีม PowerPoint (`.thmx`) และต้องการเปลี่ยนสไลด์ทั้งหมดที่พึ่งพามาสเตอร์ที่กำหนด เลือกมาสเตอร์จากคอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ซึ่งเป็น [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) และส่งพาธไฟล์ธีมไปยังเมธอด

เมธอดทำงานดังต่อไปนี้:

1. สร้างมาสเตอร์สไลด์ใหม่โดยอิงจากมาสเตอร์ที่เลือก
1. ใช้ธีมภายนอกกับมาสเตอร์ใหม่
1. กำหนดมาสเตอร์ใหม่ให้กับสไลด์ทั้งหมดที่เคยพึ่งพามาสเตอร์ที่เลือก
1. คืนค่า [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) ที่สร้างใหม่

ตัวอย่างต่อไปนี้ใช้ธีมภายนอกกับสไลด์ที่พึ่งพามาสเตอร์แรกและบันทึกงานนำเสนอ:

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

ธีมที่ไม่ถูกต้อง, เสียหาย, หรือไม่รองรับอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxreadexception/). ตรวจสอบพาธที่ผู้ใช้ป้อน, จัดการข้อผิดพลาดการเข้าถึงไฟล์ระบบ, และบันทึกงานนำเสนอหลังจากธีมถูกใช้สำเร็จ

เฉพาะสไลด์ที่พึ่งพามาสเตอร์ที่เลือกเท่านั้นที่ถูกเปลี่ยน มาสเตอร์อื่น ๆ ยังคงธีมและมาสเตอร์เดิม สี, ฟอนต์, การเติม, เส้น, พื้นหลัง, และเอฟเฟกต์ที่รู้จักธีมจะถูกแก้ไขตามธีมภายนอก สี, ฟอนต์, การเติม, และการจัดรูปแบบอื่น ๆ ที่กำหนดโดยตรงอาจไม่เปลี่ยน การแทนที่ในระดับเลเอาท์หรือสไลด์อาจยังคงมีลำดับสำคัญเหนือค่าที่สืบทอดจากมาสเตอร์ใหม่

ธีมอาจอ้างอิงฟอนต์ที่ไม่มีในสภาพแวดล้อมรันไทม์ เพื่อให้การเรนเดอร์และการส่งออกตรงกัน ควรติดตั้งฟอนต์ที่จำเป็น, ให้บริการผ่าน [custom font sources](/slides/th/nodejs-java/custom-font/), หรือกำหนด [font substitution](/slides/th/nodejs-java/font-substitution/)

นี่คือกระบวนการระดับมาสเตอร์โดยตรง: เมธอดรับพาธไฟล์ `.thmx` และไม่ต้องสร้างการแทนที่ธีมระดับสไลด์หรือเลเอาท์ด้วยตนเอง

### **ใช้ธีมภายนอกที่แตกต่างกันในงานนำเสนอหลายมาสเตอร์**

เมื่อมาสเตอร์ที่เกี่ยวข้องไม่ทราบล่วงหน้า ให้ดึงมันจากสไลด์ตัวอย่างผ่าน [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/) และ [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/). เก็บอ้างอิงมาสเตอร์เดิมไว้ก่อนทำการใช้ธีมใด ๆ เนื่องจากแต่ละครั้งจะสร้างมาสเตอร์ใหม่ในงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้สไลด์จากสองส่วนเพื่อค้นหามาสเตอร์ของพวกมันและใช้ธีมภายนอกที่แตกต่างกันกับแต่ละกลุ่ม:

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

การเรียกครั้งแรกมีผลต่อสไลด์ที่พึ่งพา `firstGroupMaster` เท่านั้น, การเรียกครั้งที่สองมีผลต่อสไลด์ที่พึ่งพา `secondGroupMaster` เท่านั้น สไลด์ที่เป็นของมาสเตอร์อื่น ๆ จะไม่ได้รับการเปลี่ยนสไตล์

### **รักษาธีมต้นฉบับเมื่อนำสไลด์ไปยังงานนำเสนออื่น**

หากต้องการย้ายสไลด์ไปยังงานนำเสนออื่นโดยรักษาการออกแบบเดิม ให้คัดลอกมาสเตอร์ต้นฉบับเข้าไปในงานนำหมายโดยใช้ [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), จากนั้นคัดลอกสไลด์ด้วย [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) พร้อมมาสเตอร์ที่คัดลอกไว้ วิธีนี้จะนำมาสเตอร์, เลเอาท์, และธีมที่เกี่ยวข้องไปด้วย

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

นี่เป็นวิธีที่แนะนำเมื่อสไลด์ต้นฉบับต้องการลักษณะเดียวกันในปลายทาง การคัดลอกเนื้อหาไปยังมาสเตอร์เป้าหมายที่ไม่เกี่ยวข้องอาจทำให้สี, ฟอนต์, พื้นหลัง, และเอฟเฟกต์ที่ขับเคลื่อนโดยธีมเปลี่ยนไป

### **ใช้ค่า ธีม กับสไลด์ที่มีอยู่**

หากสไลด์เป้าหมายต้องคงอยู่บนมาสเตอร์และเลเอาท์ปัจจุบัน ให้เริ่มต้นการแทนที่ระดับสไลด์จากธีมต้นฉบับ เมธอด [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/), และ [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) จะคัดลอกสามส่วนหลักของธีมเข้าสู่การแทนที่

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

การกระทำนี้เปลี่ยนธีมที่สไลด์ใช้โดยไม่กระทบธีมที่สืบทอดโดยสไลด์อื่น ๆ เพื่อลบการแทนที่ระดับท้องถิ่นและกลับสู่ค่าที่สืบทอด ให้เรียก [OverrideTheme.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/)

### **ใช้การแทนที่ธีมกับเลเอาท์**

การแทนที่ระดับเลเอาท์จะส่งผลกับสไลด์ที่ใช้เลเอาท์นั้น ยกเว้นสไลด์ที่มีการแทนที่ของตนเอง วิธีการเริ่มต้นเดียวกันสามารถใช้ผ่าน [LayoutSlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslidethememanager/):

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

ใช้ธีมระดับมาสเตอร์หรือระดับงานนำเสนอเมื่อหลายเลเอาท์และสไลด์ต้องการออกแบบฐานเดียวกัน, ใช้การแทนที่ระดับเลเอาท์เมื่อครอบครัวเลเอาท์ต้องการสไตล์ที่แตกต่าง, และใช้การแทนที่ระดับสไลด์เฉพาะกรณียกเว้น การแทนที่ระดับสไลด์มากเกินไปทำให้การเปลี่ยนธีมทั่วโลกในภายหลังคาดเดายาก

<!-- visual-explanation:presentation-theme:start -->
[![มาสเตอร์ธีมหนึ่งฟีดสองเลเอาท์; การแทนที่เลเอาท์ส่งผลต่อสไลด์ของมันยกเว้นสไลด์ที่มีการแทนที่ในระดับท้องถิ่นมากขึ้น.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*การแทนที่เลเอาท์ส่งผลต่อสไลด์ที่ใช้เลเอาท์นั้น เว้นแต่สไลด์จะมีการแทนที่ของตนเอง ค่าที่ได้จากธีมจะตามสคีมที่แก้ไขแล้ว; วัตถุที่จัดรูปแบบโดยตรงอาจคงลักษณะท้องถิ่นไว้. ควรทำการแทนที่ให้แคบตรงตามข้อยกเว้นของการออกแบบที่ต้องการ*
<!-- visual-explanation:presentation-theme:end -->

## **อัปเดตรูปแบบพื้นหลังของธีม**

การเติมพื้นหลังของธีมถูกเก็บใน [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). PowerPoint สามารถแสดงตัวเลือกพื้นหลังมากกว่าที่จริงมีการเก็บในคอลเลกชันนี้ เนื่องจาก UI สามารถผสานการเติมธีมกับสีธีมและการอ้างอิงสไตล์อื่น ๆ

![แกลเลอรีสไตล์พื้นหลังของ PowerPoint สำหรับธีมงานนำเสนอ](presentation-design_8.png)

ก่อนใช้สไตล์พื้นหลัง ควรตรวจสอบคอลเลกชันที่เก็บไว้และค่า [Background.getStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) ปัจจุบัน ดัชนีสไตล์ค่า `0` หมายถึงไม่มีการเติมที่มีธีม; ค่าบวกหมายถึงการอ้างอิงสไตล์พื้นหลังของธีม นี่แตกต่างจากการดัชนีคอลเลกชัน JavaScript ตรง ๆ ที่ดัชนี `0` หมายถึงรายการแรกที่เก็บไว้ อย่าสันนิษฐานว่าทุกงานนำเสนอมีจำนวนสไตล์เติมพื้นหลังเท่ากัน

ตัวอย่างต่อไปนี้รายงานจำนวนการเติมพื้นหลังที่มี, กำหนดการอ้างอิงพื้นหลังของธีมให้กับมาสเตอร์แรก, แล้วบันทึกงานนำเสนอ:

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

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับรายการธีมที่มาสเตอร์อ้างอิงและการแทนที่พื้นหลังระดับเลเอาท์หรือสไลด์ หากสไลด์ใช้พื้นหลังของตนเอง การเปลี่ยนพื้นหลังของมาสเตอร์อาจไม่เปลี่ยนสไลด์นั้น ใช้ [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) เมื่อคุณต้องการทราบพื้นหลังสุดท้ายหลังการสืบทอด

{{% alert color="warning" title="Warning" %}}
อย่ามองว่าดัชนีสไตล์เป็นดัชนีคอลเลกชันที่เริ่มจากศูนย์ อีกทั้งหลีกเลี่ยงการใส่ค่าดัชนีสไตล์จากไฟล์หนึ่งและสันนิษฐานว่ามันมีลักษณะเดียวกันในไฟล์อื่น; การกำหนดสไตล์ธีมเป็นเรื่องเฉพาะงานนำเสนอ
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
สำหรับการจัดรูปแบบพื้นหลังโดยตรงและการสืบทอดพื้นหลัง ดูที่ [Presentation Background](/slides/th/nodejs-java/presentation-background/)
{{% /alert %}}

## **อัปเดตเอฟเฟกต์ของธีม**

โครงร่างรูปแบบของธีมมีคอลเลกชันการเติม, เส้น, และเอฟเฟกต์แยกกัน ซึ่งเปิดเผยผ่าน [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/), และ [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). ธีมของ Office ปกติจะมีรายการสไตล์หลักสามรายการที่สอดคล้องกับการจัดรูปแบบแบบ Subtle, Moderate, และ Intense, แต่ควรตรวจสอบแต่ละคอลเลกชันแทนการสมมติว่ามีจำนวนคงที่

![เอฟเฟกต์ธีม Subtle, Moderate, และ Intense ที่ใช้กับรูปร่างเดียวกัน](presentation-design_10.png)

เมื่อเข้าถึงคอลเลกชันเหล่านี้ใน JavaScript ดัชนีคอลเลกชันเริ่มจากศูนย์: ดัชนี `0` คือสไตล์แรกที่เก็บ, ดัชนี `2` คือสไตล์ที่สาม. ดัชนีอ้างอิงสไตล์ของรูปร่างเป็นแนวคิดแยกต่างหาก, เปิดเผยผ่าน [ShapeStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/). การแก้ไขสไตล์ธีมจะส่งผลต่อรูปร่างที่อ้างอิงสไตล์นั้น; รูปร่างที่มีการจัดรูปแบบโดยตรงอาจไม่เปลี่ยน

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรายการสไตล์ที่จำเป็นหรือไม่, เปลี่ยนสไตล์เส้นแรก, เปลี่ยนสไตล์เติมที่สาม, เปิดใช้งานเงาภายนอกในสไตล์เอฟเฟกต์ที่สาม, แล้วบันทึกผลลัพธ์:

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

สำหรับรูปร่างที่อ้างอิงช่องเหล่านี้ สไตล์เส้นธีมแรกจะเป็นสีแดง, สไตล์เติมธีมที่สามจะเป็นสีเขียวป่าแบบ solid, และสไตล์เอฟเฟกต์ที่สามจะเพิ่มเงาภายนอกด้วยระยะ 10 จุด ผลลัพธ์ภาพที่แน่นอนยังคงขึ้นกับสไตล์ที่แต่ละรูปร่างอ้างอิงและว่าการจัดรูปแบบโดยตรงทับธีมหรือไม่

![สไตล์เอฟเฟกต์ของธีมหลังการเปลี่ยนเส้น, เติม, และเงา](presentation-design_11.png)

## **เลือกสไตล์การเติมและเส้นของธีมสำหรับรูปร่าง**

รูปร่างสามารถเลือกการเติมและเส้นขอบอย่างอิสระผ่าน [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setfillstyleindex/) และ [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/setlinestyleindex/). สำหรับแต่ละเมธอด ดัชนี `1` เลือกรายการแรกในคอลเลกชันธีมที่สอดคล้อง (`get_Item(0)`), ดัชนี `2` เลือกรายการที่สอง (`get_Item(1)`)

ตัวอย่างต่อไปนี้ตั้งค่าสไตล์การเติมสองแบบ (ทองและสีฟ้าอากาศ) และสไตล์เส้นสองแบบ (สีน้ำเงินเข้มที่ 6 pt และสีแดงเข้มที่ 12 pt) ในธีมเริ่มต้นของงานนำเสนอใหม่; จะบันทึกสไลด์ในสามขั้นตอนเพื่อให้คุณเปรียบเทียบผลลัพธ์ใน PowerPoint

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const styles = presentation.getMasterTheme().getFormatScheme();

    const goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));
    const blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    blueFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 135, 206, 235));

    const thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thinLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
    thinLine.setWidth(6);
    const thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thickLine.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 139, 0, 0));
    thickLine.setWidth(12);

    const shapes = presentation.getSlides().get_Item(0).getShapes();
    const left = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 205, 200, 130);
    const right = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex(java.newShort(1));
    right.getShapeStyle().setFillStyleIndex(java.newShort(2));
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", aspose.slides.SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", aspose.slides.SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 46, 139, 87));
    presentation.save("03-theme-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| สไตล์เริ่มต้น | เปลี่ยนเส้นขอบด้านขวา | แก้ไขการเติมธีมแรก |
|:---:|:---:|:---:|
| ![สี่เหลี่ยมทองและสีฟ้าอากาศที่มีเส้นขอบสีฟ้าเข้มบางตรงกัน](theme-style-initial.png) | ![สี่เหลี่ยมสีฟ้าอากาศตอนนี้มีเส้นขอบสีแดงเข้มหนา](theme-style-line-changed.png) | ![สี่เหลี่ยมซ้ายตอนนี้เป็นสีเขียวและเส้นขอบทั้งสองยังคงเดิม](theme-style-fill-changed.png) |

การเลือกสไตล์เส้นที่ต่างกันจะเปลี่ยนเฉพาะเส้นขอบของสี่เหลี่ยมด้านขวา การแก้ไขการเติมธีมแรกจะอัปเดตทุกรูปร่างที่ใช้มัน ที่นี่สี่เหลี่ยมซ้ายเท่านั้นที่เปลี่ยนเป็นสีเขียว

บนรูปร่างที่มีอยู่ สีเติมท้องถิ่น, สีเส้น, หรือความกว้างเส้นสามารถแทนที่ส่วนของสไตล์ธีมได้ หากการเปลี่ยนดัชนีสไตล์ไม่มีผลที่มองเห็นได้ ให้ตรวจสอบ [direct formatting](/slides/th/nodejs-java/shape-formatting/)

## **ตรวจสอบว่าการเติมแบบโซลิดที่มีผลใช้สีธีมหรือไม่**

การเติมสามารถเก็บโดยตรงบนวัตถุหรือสืบทอดจากย่อหน้า, เลเอาท์, มาสเตอร์, สไตล์ธีม, หรือระดับการจัดรูปแบบอื่น ๆ เรียก [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) เพื่อแก้ลำดับชั้นนั้นเป็นสแนปช็อตการเติมที่มีผล ถ้าค่า `getFillType` ไม่ใช่ `FillType.Solid` อย่าอ่านคุณสมบัติเพิ่มเติม

สำหรับการเติมแบบโซลิด, `getSolidFillColor` คืนค่าระดับ RGB สุดท้ายหลังจากสืบทอด, การค้นหาธีม, และการแปลงสี `getSolidFillSchemeColor` คืนค่าช่อง [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) ที่สอดคล้อง เช่น `Text1` หรือ `Accent6`. ค่า `SchemeColor.NotDefined` หมายความว่าการเติมโซลิดที่มีผลไม่ได้อิงจากสีสคีม ในกระบวนการที่เติมเป็นสีธีมหรือสี RGB ตรงค่านี้ระบุว่าการเติมเป็นสี RGB ตรง

อย่าใช้ค่า [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) ของท้องถิ่นเพียงอย่างเดียวเพื่อจำแนกการเติม ตัวอย่างเช่น ส่วนข้อความอาจไม่มีสีสคีมที่กำหนดในระดับท้องถิ่น ดังนั้นค่าท้องถิ่นจะเป็น `NotDefined` ในขณะที่การเติมที่มีผลสืบทอดสีธีมและแก้เป็น `Text1` หรือ `Accent6` การใช้ `getSolidFillSchemeColor` บอกว่าช่องสคีม logical ใดสร้างสีที่มีผล แต่ไม่ได้บอกว่าช่องนั้นมาจากวัตถุ, ย่อหน้า, เลเอาท์, มาสเตอร์ หรือระดับอื่น

ตัวอย่างต่อไปนี้โหลดงานนำเสนอ, ตรวจสอบการเติมของทั้งรูปร่างและส่วนข้อความ, พิมพ์ค่า RGB สุดท้ายและสคีมที่สัมพันธ์, แล้วทำเครื่องหมายการเติมโซลิดที่ไม่ติดตามการเปลี่ยนสีธีม:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function toHexColor(color) {
    const red = color.getRed().toString(16).padStart(2, "0");
    const green = color.getGreen().toString(16).padStart(2, "0");
    const blue = color.getBlue().toString(16).padStart(2, "0");
    return `#${red}${green}${blue}`.toUpperCase();
}

function auditFill(objectName, localFill) {
    const effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() !== aspose.slides.FillType.Solid) {
        console.log(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    const rgb = effectiveFill.getSolidFillColor();
    const effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    const localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    console.log(objectName + ": RGB = " + toHexColor(rgb));
    console.log(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor === aspose.slides.SchemeColor.NotDefined) {
        console.log(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        console.log(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
}

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        const shapeCount = slide.getShapes().size();
        for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            const shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill(shapeName, shape.getFillFormat());

            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const paragraphCount = shape.getTextFrame().getParagraphs().getCount();
                for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    const portionCount = paragraph.getPortions().getCount();
                    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        const portion = paragraph.getPortions().get_Item(portionIndex);
                        const portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

สาขา `NotDefined` ให้รายการตรวจสอบของการเติมโซลิดที่ไม่ตอบสนองต่อการเปลี่ยนช่องสีธีม ตรวจสอบวัตถุเหล่านั้นเมื่อ งานนำเสนอจำเป็นต้องสอดคล้องกับพาเลตแบรนด์ใหม่ ค่า RGB ที่รายงานยังแสดงลักษณะปัจจุบัน ในขณะที่ค่าสคีมอธิบายว่าลักษณะนั้นเชื่อมต่อกับธีมหรือไม่

วัตถุที่มีรูปแบบที่มีผลเป็นสแนปช็อต หลังจากเปลี่ยนธีมงานนำเสนอ, การแทนที่ธีม, หรือการจัดรูปแบบที่สืบทอดใด ๆ ให้เรียก `getEffective` อีกครั้งและอ่านวัตถุการเติมที่มีผลใหม่ก่อนเปรียบเทียบหรือรายงานสี

## **อ่านค่าธีมที่มีผล**

วัตถุธีมดิบบอกว่ามีอะไรกำหนดไว้ที่ระดับใดระดับหนึ่ง ค่าที่มีผลบอกว่ารูปร่างหรือสไลด์ใช้อะไรจริงหลังจากสืบทอดและการแทนที่ในระดับท้องถิ่นถูกแก้ไข สำหรับสไลด์ ให้เรียก [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/). สำหรับพื้นหลัง ให้ใช้ [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/), และสำหรับการเติมให้ใช้ [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/)

ตัวอย่างต่อไปนี้อ่านธีมที่มีผล, พื้นหลัง, และการเติมของรูปร่างแรกจากสไลด์:

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

ใช้ข้อมูลที่มีผลสำหรับการวินิจฉัยการเรนเดอร์, การตรวจสอบ, และการเปรียบเทียบ หากคุณตรวจสอบเฉพาะ [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/), คุณอาจพลาดมาสเตอร์, เลเอาท์, สไลด์, หรือการแทนที่รูปร่างที่เปลี่ยนลักษณะสุดท้าย

## **FAQ**

**การใช้ธีมภายนอกส่งผลต่อทุกสไลด์ในงานนำเสนอหรือไม่?**

ไม่. [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) จะกำหนดให้เฉพาะสไลด์ที่พึ่งพามาสเตอร์ที่เลือกเท่านั้น สไลด์ที่ใช้มาสเตอร์อื่นจะคงธีมเดิม

**ฉันสามารถใช้ธีมกับสไลด์เดียวโดยไม่เปลี่ยนมาสเตอร์ได้หรือไม่?**

ได้. ใช้ [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/) ของสไลด์และเริ่มต้นธีมแทนที่ การเปลี่ยนแปลงจะอยู่ในระดับสไลด์เท่านั้น; สไลด์อื่น ๆ ยังคงสืบทอดธีมเดิม

**วิธีที่ปลอดภัยที่สุดในการนำธีมจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งคืออะไร?**

เมื่อนำสไลด์และรักษาลักษณะต้นฉบับ ให้คัดลอกมาสเตอร์ต้นฉบับไปยังปลายทางและคัดลอกสไลด์ด้วยมาสเตอร์นั้นโดยใช้ [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) และ [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) วิธีนี้จะเก็บมาสเตอร์, เลเอาท์, และธีมไว้ด้วยกัน

**ฉันจะดูค่าที่มีผลหลังจากสืบทอดและการแทนที่ได้อย่างไร?**

ใช้ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) สำหรับสไลด์หรือธีมเลเอาท์และเมธอดข้อมูลที่มีผลที่สอดคล้องสำหรับวัตถุรูปแบบ เช่น [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) และ [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/). API เหล่านี้คืนค่าที่แก้ไขแล้วหลังจากสืบทอดและการแทนที่ถูกนำมาใช้.