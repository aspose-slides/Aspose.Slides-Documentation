---
title: ฝังแบบอักษรในงานนำเสนอด้วย JavaScript
linktitle: แบบอักษรที่ฝังไว้
type: docs
weight: 40
url: /th/nodejs-java/embedded-font/
keywords:
- เพิ่มแบบอักษร
- ฝังแบบอักษร
- การฝังแบบอักษร
- รับแบบอักษรที่ฝังไว้
- เพิ่มแบบอักษรที่ฝังไว้
- ลบแบบอักษรที่ฝังไว้
- บีบอัดแบบอักษรที่ฝังไว้
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการแบบอักษรที่ฝังไว้ใน PowerPoint ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java. เพิ่ม ดึงคืน ลบ และบีบอัดแบบอักษรเพื่อรักษารูปแบบข้อความและลดขนาดไฟล์."
---
## **คำนำ**

การฝังแบบอักษรจะทำการเก็บข้อมูลแบบอักษรไว้ภายในไฟล์การนำเสนอ PowerPoint เมื่อโปรแกรมแสดงผลรองรับการฝังแบบอักษร มันจะสามารถแสดงข้อความโดยใช้แบบอักษรเหล่านั้นได้แม้ว่าแบบอักษรจะไม่ได้ติดตั้งบนระบบเป้าหมาย การทำเช่นนี้ช่วยรักษาการแบ่งบรรทัด การเว้นระยะห่างของข้อความ และการจัดวางสไลด์

Aspose.Slides สำหรับ Node.js ผ่าน Java ช่วยให้คุณดึงคืน เพิ่ม และลบแบบอักษรที่ฝังไว้ผ่านคลาส [FontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/) ที่ได้จาก [Presentation.getFontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getfontsmanager/). คุณยังสามารถลดขนาดข้อมูลแบบอักษรที่ฝังไว้โดยการลบอักขระที่การนำเสนอไม่ได้ใช้

ตัวอย่างต่อไปนี้ทำงานกับไฟล์ PPTX ก่อนทำการฝังแบบอักษร ให้ตรวจสอบว่าข้อมูลแบบอักษรนั้นพร้อมใช้งานสำหรับ Aspose.Slides และใบอนุญาตของแบบอักษรอนุญาตให้ฝังได้

## **รับและลบแบบอักษรที่ฝังไว้**

ใช้ [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) เพื่อแสดงรายการแบบอักษรที่เก็บไว้ในการนำเสนอ หากต้องการลบแบบอักษรหนึ่ง ให้ส่งแบบอักษรจากรายการนั้นไปยัง [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), แล้วบันทึกการนำเสนอ

ตัวอย่างต่อไปนี้จะแสดงรายการแบบอักษรที่ฝังไว้ใน `EmbeddedFonts.pptx` และลบ Calibri หากพบ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

การลบแบบอักษรที่ฝังไว้จะทำการลบข้อมูลแบบอักษรที่เก็บไว้; มันไม่ได้เปลี่ยนแบบอักษรที่กำหนดให้กับข้อความ หากแบบอักษรถูกติดตั้งบนระบบเป้าหมาย ข้อความยังสามารถใช้แบบอักษรนั้นได้ อย่างไรก็ตาม การแสดงผลอาจต้องการ [font substitution](/slides/th/nodejs-java/font-substitution/) ซึ่งอาจส่งผลต่อการจัดวาง

## **ตรวจสอบข้อมูลแบบอักษรและสิทธิ์การฝัง**

ใช้คลาส [FontsManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/) เพื่อตรวจสอบแบบอักษรก่อนทำการฝัง เรียก [FontsManager.getFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getfonts/) เพื่อดึงแบบอักษรที่ใช้ในการนำเสนอ สำหรับแต่ละแบบอักษร ให้ส่งอ็อบเจกต์ [FontData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontdata/) และค่าที่จำเป็นของ [FontStyleType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontstyletype/) ไปยัง [FontsManager.getFontBytes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). เมธอดนี้จะคืนข้อมูลไบนารีของสไตล์แบบอักษรนั้น หรือคืนค่า `null` หากแบบอักษรหรือสไตล์ที่ร้องขอไม่มีอยู่ อย่าส่งผลลัพธ์ `null` ไปยัง [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), เนื่องจากเมธอดนั้นต้องการอาเรย์ของไบต์ ใน Node.js ให้แปลงอาเรย์ JavaScript ที่คืนกลับเป็นอาเรย์ไบต์ของ Java ด้วย `java.newArray` ก่อนส่งให้ `getFontEmbeddingLevel`

[EmbeddingLevel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/embeddinglevel/) รายงานข้อจำกัดการฝังที่เก็บไว้ในแบบอักษรเป็นชุดของแฟล็ก:

- `Installable` อนุญาตให้ฝังและติดตั้งอย่างถาวรบนระบบอื่นได้ตามใบอนุญาตของแบบอักษร
- `Restricted` ห้ามฝังเว้นแต่จะได้รับอนุญาตจากเจ้าของสิทธิ์ของแบบอักษรเมื่อเป็นแฟล็กสิทธิ์การใช้เดียว
- `PreviewPrint` อนุญาตการใช้งานชั่วคราวเพื่อการดูและพิมพ์; เอกสารที่มีแบบอักษรนี้ต้องเป็นแบบอ่านอย่างเดียว
- `Editable` อนุญาตการใช้งานชั่วคราวและให้เอกสารสามารถแก้ไขและบันทึกได้
- `NoSubsetting` เป็นข้อจำกัดเพิ่มเติมที่ห้ามฝังเฉพาะส่วนย่อยของ glyphs. ต้องฝังอักขระทั้งหมดเมื่อมีแฟล็กนี้
- `BitmapOnly` เป็นข้อจำกัดเพิ่มเติมที่อนุญาตให้ฝังเฉพาะ bitmap strikes เท่านั้น ไม่ใช่ข้อมูลเค้าโครง. หากแบบอักษรไม่มี bitmap strikes จะไม่สามารถฝังได้

ค่าแรกสี่ค่าอธิบายสิทธิ์การใช้งาน ส่วน `NoSubsetting` และ `BitmapOnly` สามารถรวมกับค่าดังกล่าวได้ ตรวจสอบตัวปรับโดยใช้การดำเนินการบิตวายส์ เนื่องจาก `Installable` มีค่าเป็นศูนย์ ให้ทำการมาสก์บิตสิทธิ์การใช้งานและเปรียบเทียบผลลัพธ์กับ `Installable` แทนการตรวจสอบเป็นแฟล็ก แบบอักษรในปัจจุบันควรกำหนดบิตสิทธิ์การใช้งานไม่เกินหนึ่งบิต เพื่อความเข้ากันได้กับแบบอักษรเก่าที่กำหนดบิตหลายบิต ตัวช่วยด้านล่างจะเลือกสิทธิ์ที่ผ่อนปรนที่สุด: `Editable`, จากนั้น `PreviewPrint`, แล้ว `Restricted`

ตัวอย่างต่อไปนี้จะตรวจสอบข้อมูลปกติ, ตัวหนา, ตัวเอียง, และตัวหนา-เอียง ที่มีอยู่สำหรับทุกแบบอักษรที่ส่งคืนโดย `getFonts`. มันจะข้ามสไตล์ที่ไม่มี, แบบอักษรที่ถูกจำกัด, แบบอักษรแบบ bitmap‑only, แบบอักษรที่จำกัดเฉพาะการดูและพิมพ์เนื่องจากผลลัพธ์ยังคงแก้ไขได้, และแบบอักษรที่ฝังไว้แล้ว หากสไตล์ใดที่มี `NoSubsetting` อยู่ จะฝังอักขระทั้งหมดสำหรับตระกูลแบบอักษรนั้น

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การตรวจสอบนี้รายงานข้อจำกัดที่เข้ารหัสในแต่ละไฟล์แบบอักษร ไม่ได้ให้สิทธิ์ใบอนุญาต, ไม่ได้พิสูจน์ว่าคุณได้แบบอักษรมาอย่างถูกกฎหมาย, และไม่สามารถแทนที่การตรวจสอบข้อตกลงใบอนุญาตของแบบอักษรก่อนแจกจ่ายสำเนาที่ฝังไว้

## **เพิ่มแบบอักษรที่ฝังไว้**

ใช้ [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) เพื่อฝังแบบอักษร การโอเวอร์โหลดรับออบเจกต์ [FontData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontdata/) หรืออาเรย์ไบต์ที่บรรจุข้อมูลแบบอักษร [EmbedFontCharacters](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/embedfontcharacters/) ควบคุมอักขระที่รวมอยู่:

- `All` ฝังอักขระทั้งหมดในแบบอักษร ใช้ตัวเลือกนี้เมื่อผู้รับต้องการแก้ไขการนำเสนอและใส่ข้อความใหม่
- `OnlyUsed` ฝังเฉพาะอักขระที่ใช้ในการนำเสนอเพื่อทำให้ไฟล์เล็กลง เลือกตัวเลือกนี้สำหรับการนำเสนอที่เสร็จสมบูรณ์และมีวัตถุประสงค์หลักเพื่อการดู

ตัวอย่างต่อไปนี้ใช้ [FontsManager.getFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getfonts/) เพื่อดึงแบบอักษรที่ใช้ใน `Fonts.pptx` และฝังแบบอักษรที่ยังไม่ถูกฝังไว้แบบอักษรที่ต้องเพิ่มต้องมีอยู่บนเครื่องที่รันโค้ด แบบอักษรที่ฝังอยู่แล้วจะคงชุดอักขระปัจจุบัน

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **บีบอัดแบบอักษรที่ฝังไว้**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/compressembeddedfonts/) ลดข้อมูลแบบอักษรที่ฝังโดยการลบอักขระที่ไม่ได้ใช้ ทำงานกับแบบอักษรที่ฝังไว้แล้ว ดังนั้นการลดขนาดขึ้นอยู่กับปริมาณข้อมูลแบบอักษรที่ไม่ได้ใช้ในการนำเสนอ

ตัวอย่างต่อไปนี้บีบอัดแบบอักษรใน `EmbeddedFonts.pptx` และบันทึกผลลัพธ์เป็นไฟล์แยก:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เก็บไฟล์ต้นฉบับไว้หากผู้รับอาจต้องเพิ่มข้อความในภายหลัง อักขระที่ลบระหว่างการบีบอัดจะไม่มีอยู่ในแบบอักษรที่ฝังแล้ว แม้ว่าคุณจะฝังอักขระทั้งหมดตั้งแต่แรก

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรที่ฝังไว้จะยังถูกแทนที่ในการเรนเดอร์หรือไม่?**

เรียก [FontsManager.getSubstitutions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) ในสภาพแวดล้อมที่คุณเรนเดอร์การนำเสนอเพื่อดูว่า Aspose.Slides จะแทนที่แบบอักษรใดบ้าง นอกจากนี้ให้ตรวจสอบการตั้งค่า [font substitution](/slides/th/nodejs-java/font-substitution/) และกฎ [font fallback](/slides/th/nodejs-java/fallback-font/) การ fallback จัดการกับอักขระที่ขาดหาย ดังนั้นการฝังแบบอักษรจะไม่ทำให้ได้อักขระที่แบบอักษรนั้นเองไม่มี

**ควรฝังแบบอักษรทั่วไปเช่น Arial และ Calibri หรือไม่?**

ตัดสินใจโดยอิงจากสภาพแวดล้อมเป้าหมาย หากแบบอักษรที่ต้องการมีอยู่บนทุกเครื่องที่เปิดหรือเรนเดอร์การนำเสนอ การฝังอาจเพิ่มขนาดไฟล์โดยไม่จำเป็น หากผู้รับหรือเซิร์ฟเวอร์อาจไม่มีแบบอักษรเหล่านั้น การฝังสามารถช่วยรักษาลักษณะตามที่ตั้งใจไว้ได้ หากใบอนุญาตของแบบอักษรอนุญาตให้```