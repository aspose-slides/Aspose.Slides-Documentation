---
title: ฝังฟอนต์ในงานนำเสนอโดยใช้ JavaScript
linktitle: ฝังฟอนต์
type: docs
weight: 40
url: /th/nodejs-java/embedded-font/
keywords:
- เพิ่มฟอนต์
- ฝังฟอนต์
- การฝังฟอนต์
- รับฟอนต์ที่ฝังไว้
- เพิ่มฟอนต์ที่ฝังไว้
- ลบฟอนต์ที่ฝังไว้
- บีบอัดฟอนต์ที่ฝังไว้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ฝังฟอนต์ TrueType ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อให้การเรนเดอร์ที่แม่นยำบนทุกแพลตฟอร์ม"
---
## **บทนำ**

**ฟอนต์ที่ฝังไว้ใน PowerPoint** มีประโยชน์เมื่อคุณต้องการให้การนำเสนอของคุณแสดงผลอย่างถูกต้องเมื่อนำไปเปิดบนระบบหรืออุปกรณ์ใดก็ได้ หากคุณใช้ฟอนต์จากบุคคลที่สามหรือฟอนต์ที่ไม่เป็นมาตรฐานเพราะคุณสร้างสรรค์งานของคุณเอง คุณก็จะมีเหตุผลเพิ่มเติมในการฝังฟอนต์ของคุณ มิฉะนั้น (หากไม่มีฟอนต์ที่ฝังไว้) ข้อความหรือตัวเลขบนสไลด์ของคุณ การจัดวาง การออกแบบ ฯลฯ อาจเปลี่ยนแปลงหรือกลายเป็นสี่เหลี่ยมที่สับสน  

คลาส [FontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontsManager) , คลาส [FontData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontdata/) , คลาส [Compress](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/) และคลาสของพวกเขามีคุณสมบัติและเมธอดส่วนใหญ่ที่คุณต้องการเพื่อทำงานกับฟอนต์ที่ฝังไว้ในงานนำเสนอ PowerPoint  

## **รับหรือเอาฟอนต์ที่ฝังไว้จากงานนำเสนอ**

Aspose.Slides มีเมธอด [getEmbeddedFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (ที่เปิดให้ใช้งานโดยคลาส [FontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontsManager)) เพื่อให้คุณสามารถรับ (หรือค้นหา) ฟอนต์ที่ฝังไว้ในงานนำเสนอได้ หากต้องการลบฟอนต์ ให้ใช้เมธอด [removeEmbeddedFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (ที่เปิดให้ใช้งานโดยคลาสเดียวกัน)  

โค้ด JavaScript ตัวนี้แสดงวิธีรับและลบฟอนต์ที่ฝังไว้จากงานนำเสนอ:

```javascript
// สร้างอ็อบเจ็กต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // เรนเดอร์สไลด์ที่มีกรอบข้อความที่ใช้ฟอนต์ฝัง "FunSized"
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // บันทึกรูปภาพลงดิสก์ในรูปแบบ JPEG
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // รับฟอนต์ที่ฝังทั้งหมด
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // ค้นหาฟอนต์ "Calibri"
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // ลบฟอนต์ "Calibri"
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // เรนเดอร์งานนำเสนอ; ฟอนต์ "Calibri" ถูกแทนที่ด้วยฟอนต์ที่มีอยู่
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // บันทึกรูปภาพลงดิสก์ในรูปแบบ JPEG
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // บันทึกงานนำเสนอโดยไม่มีฟอนต์ "Calibri" ที่ฝังลงดิสก์
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เพิ่มฟอนต์ที่ฝังไว้ในงานนำเสนอ**

โดยใช้ enum [EmbedFontCharacters](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/embedfontcharacters/) และออเวอร์โหลดสองแบบของเมธอด [addEmbeddedFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-) คุณสามารถเลือกกฎการฝังฟอนต์ที่ต้องการเพื่อฝังฟอนต์ในงานนำเสนอได้ โค้ด JavaScript ตัวนี้แสดงวิธีการฝังและเพิ่มฟอนต์ในงานนำเสนอ:

```javascript
// โหลดงานนำเสนอ
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **บีบอัดฟอนต์ที่ฝังไว้**

เพื่อให้คุณสามารถบีบอัดฟอนต์ที่ฝังไว้ในงานนำเสนอและลดขนาดไฟล์ได้ Aspose.Slides มีเมธอด [compressEmbeddedFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (ที่เปิดให้ใช้งานโดยคลาส [Compress](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/))  

โค้ด JavaScript ตัวนี้แสดงวิธีบีบอัดฟอนต์ PowerPoint ที่ฝังไว้:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันจะทราบได้อย่างไรว่าฟอนต์เฉพาะในงานนำเสนอจะยังถูกแทนที่ระหว่างการเรนเดอร์แม้ว่าจะฝังแล้ว?**  

ตรวจสอบ [ข้อมูลการแทนที่](/slides/th/nodejs-java/font-substitution/) ในตัวจัดการฟอนต์และ [กฎการสำรอง/การแทนที่](/slides/th/nodejs-java/fallback-font/): หากฟอนต์ไม่พร้อมใช้งานหรือถูกจำกัด จะมีการใช้ฟอนต์สำรอง  

**การฝังฟอนต์ “ระบบ” เช่น Arial/Calibri มีความคุ้มหรือไม่?**  

ส่วนใหญ่ไม่—ฟอนต์เหล่านี้มักจะมีอยู่แล้ว แต่สำหรับความพกพาเต็มรูปแบบในสภาพแวดล้อม “บาง” (เช่น Docker, เซิร์ฟเวอร์ Linux ที่ไม่มีฟอนต์ติดตั้งไว้) การฝังฟอนต์ระบบสามารถลดความเสี่ยงจากการแทนที่ที่ไม่คาดคิดได้