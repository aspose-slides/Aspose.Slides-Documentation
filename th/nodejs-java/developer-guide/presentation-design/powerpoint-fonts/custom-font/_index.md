---
title: ปรับแต่งแบบอักษร PowerPoint ใน JavaScript
linktitle: แบบอักษรที่กำหนดเอง
type: docs
weight: 20
url: /th/nodejs-java/custom-font/
keywords:
- แบบอักษร
- แบบอักษรที่กำหนดเอง
- แบบอักษรภายนอก
- โหลดแบบอักษร
- จัดการแบบอักษร
- โฟลเดอร์แบบอักษร
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ปรับแต่งแบบอักษรในสไลด์ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อทำให้งานนำเสนอของคุณคมชัดและสอดคล้องกันบนอุปกรณ์ใดก็ได้"
---
## **ภาพรวม**

Aspose.Slides ให้คุณใช้แบบอักษรที่กำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดแบบอักษรจากโฟลเดอร์ที่กำหนดเอง, ให้แบบอักษรสำหรับงานนำเสนอเฉพาะผ่านแหล่งแบบอักษรระดับเอกสาร, หรือโหลดแบบอักษรภายนอกโดยตรงจากข้อมูลไบต์

แบบอักษรที่โหลดแล้วจะถูกใช้เมื่อทำการเรนเดอร์หรือส่งออกงานนำเสนอ เช่น ไปเป็น PDF, รูปภาพ, และรูปแบบอื่นที่รองรับ ซึ่งช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ในสภาพแวดล้อมต่าง ๆ บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์แบบอักษรที่ Aspose.Slides ใช้และวิธีล้างแคชแบบอักษรหลังจากทำงานกับแบบอักษรภายนอก

การลงทะเบียนแบบอักษรที่กำหนดเองสำหรับการเรนเดอร์แตกต่างจากการฝังแบบอักษรลงในไฟล์ PPTX หากต้องการให้แบบอักษรถูกเก็บอยู่ภายในงานนำเสนอเอง ให้ใช้ฟีเจอร์การฝังแบบอักษรโดยเฉพาะ

ธีมของงานนำเสนอสามารถอ้างอิงฟอนต์แฟมิลีต่าง ๆ สำหรับระบบการเขียนที่แตกต่างกัน การแมปนี้บันทึกชื่อแบบอักษรแต่ไม่ทำการติดตั้งหรือโหลดไฟล์แบบอักษร ดูที่ [Script-Specific Theme Fonts](/slides/th/nodejs-java/script-specific-font-mappings/) เพื่อจัดการการแมปและใช้ตัวเลือกการโหลดด้านล่างเพื่อทำให้แบบอักษรที่อ้างอิงพร้อมใช้งานสำหรับการเรนเดอร์ที่สอดคล้องกัน

{{% alert color="info" title="หมายเหตุ" %}}

Aspose Slides ให้คุณโหลดแบบอักษรเหล่านี้โดยใช้เมธอด [loadExternalFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* แบบอักษร TrueType (.ttf) และ TrueType Collection (.ttc) ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType)  

* แบบอักษร OpenType (.otf) ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType)

{{% /alert %}}

## **โหลดแบบอักษรที่กำหนดเอง**

Aspose.Slides ให้คุณโหลดแบบอักษรที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ ระบบนี้มีผลต่อผลลัพธ์การส่งออก เช่น PDF, รูปภาพ, และรูปแบบอื่นที่รองรับ ทำให้เอกสารที่ได้มีลักษณะเหมือนกันในแต่ละสภาพแวดล้อม แบบอักษรจะถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์แบบอักษร  
2. เรียกเมธอดสแตติก [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) เพื่อโหลดแบบอักษรจากโฟลเดอร์เหล่านั้น  
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ  
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/clearcache/) เพื่อล้างแคชแบบอักษร

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดแบบอักษร:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// กำหนดโฟลเดอร์ที่มีไฟล์แบบอักษรกำหนดเอง.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// โหลดแบบอักษรกำหนดเองจากโฟลเดอร์ที่ระบุ.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // เรนเดอร์/ส่งออกงานนำเสนอ (เช่น PDF, รูปภาพ หรือรูปแบบอื่น) โดยใช้แบบอักษรถูกโหลด.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // ล้างแคชแบบอักษรหลังจากทำงานเสร็จ.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="หมายเหตุ" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) เพิ่มโฟลเดอร์เพิ่มเติมในเส้นทางค้นหาแบบอักษร แต่ไม่เปลี่ยนลำดับการเริ่มต้นแบบอักษร  
แบบอักษรถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางแบบอักษรเริ่มต้นของระบบปฏิบัติการ  
2. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/)

{{%/alert %}}

## **รับโฟลเดอร์แบบอักษรที่กำหนดเอง**
Aspose.Slides มีเมธอด [getFontFolders](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) เพื่อให้คุณค้นหาโฟลเดอร์แบบอักษร เมธอดนี้จะคืนค่าโฟลเดอร์ที่ถูกเพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์แบบอักษรของระบบ

โค้ด JavaScript ด้านล่างแสดงวิธีใช้ [getFontFolders](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// บรรทัดนี้แสดงโฟลเดอร์ที่ค้นหาไฟล์แบบอักษร.
// นั่นคือโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์แบบอักษรของระบบ.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **ระบุแบบอักษรที่กำหนดใช้กับงานนำเสนอ**
Aspose.Slides มีคุณสมบัติ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) เพื่อให้คุณระบุแบบอักษรภายนอกที่จะใช้กับงานนำเสนอ

โค้ด JavaScript ด้านล่างแสดงวิธีใช้คุณสมบัติ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // ทำงานกับงานนำเสนอ
    // CustomFont1, CustomFont2, และแบบอักษรจากโฟลเดอร์ assets\fonts และ global\fonts รวมถึงโฟลเดอร์ย่อยของมัน สามารถใช้ได้ในงานนำเสนอ
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **จัดการแบบอักษรภายนอก**

Aspose.Slides มีเมธอด [loadExternalFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) เพื่อให้คุณโหลดแบบอักษรภายนอกจากข้อมูลไบต์

โค้ด JavaScript ด้านล่างแสดงกระบวนการโหลดแบบอักษรจากอาเรย์ไบต์:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // แบบอักษรภายนอกถูกโหลดระหว่างอายุการทำงานของงานนำเสนอ
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **คำถามที่พบบ่อย**

### แบบอักษรกำหนดเองส่งผลต่อการส่งออกไปยังรูปแบบทั้งหมด (PDF, PNG, SVG, HTML) หรือไม่?

ใช่. แบบอักษรที่เชื่อมต่อจะถูกใช้โดยตัวเรนเดอร์ในรูปแบบส่งออกทุกประเภท

### แบบอักษรกำหนดเองจะถูกฝังอัตโนมัติใน PPTX ที่ได้หรือไม่?

ไม่. การลงทะเบียนแบบอักษรเพื่อการเรนเดอร์ไม่เท่ากับการฝังลงใน PPTX หากต้องการให้แบบอักษรถูกเก็บไว้ในไฟล์งานนำเสนอ ต้องใช้ [ฟีเจอร์การฝัง](/slides/th/nodejs-java/embedded-font/)

### สามารถควบคุมพฤติกรรม fallback เมื่อแบบอักษรกำหนดเองไม่มี glyph บางตัวได้หรือไม่?

ใช่. กำหนดค่า [การแทนที่แบบอักษร](/slides/th/nodejs-java/font-substitution/), [กฎการแทนที่](/slides/th/nodejs-java/font-replacement/), และ [ชุด fallback](/slides/th/nodejs-java/fallback-font/) เพื่อระบุอย่างชัดเจนว่าจะแทนที่ด้วยแบบอักษรใดเมื่อ glyph ที่ต้องการไม่มีอยู่

### สามารถใช้แบบอักษรในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งระบบได้หรือไม่?

ใช่. ชี้ไปยังโฟลเดอร์แบบอักษรของคุณเองหรือโหลดแบบอักษรจากอาเรย์ไบต์ วิธีนี้จะทำให้ไม่มีการพึ่งพาโฟลเดอร์แบบอักษรของระบบในอิมเมจคอนเทนเนอร์

### เรื่องลิขสิทธิ์—สามารถฝังแบบอักษรกำหนดเองใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?

คุณต้องรับผิดชอบต่อการปฏิบัติตามเงื่อนไขลิขสิทธิ์ของแบบอักษร เงื่อนไขจะแตกต่างกัน; บางลิขสิทธิ์ห้ามฝังหรือห้ามใช้เชิงพาณิชย์ ควรตรวจสอบ EULA ของแบบอักษรก่อนนำผลลัพธ์ไปเผยแพร่