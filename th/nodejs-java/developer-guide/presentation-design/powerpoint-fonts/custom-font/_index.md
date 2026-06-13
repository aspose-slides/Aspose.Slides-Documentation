---
title: ปรับแต่งฟอนต์ PowerPoint ใน JavaScript
linktitle: ฟอนต์แบบกำหนดเอง
type: docs
weight: 20
url: /th/nodejs-java/custom-font/
keywords:
- ฟอนต์
- ฟอนต์แบบกำหนดเอง
- ฟอนต์ภายนอก
- โหลดฟอนต์
- จัดการฟอนต์
- โฟลเดอร์ฟอนต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ปรับแต่งฟอนต์ในสไลด์ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันในทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณใช้ฟอนต์แบบกำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดฟอนต์จากโฟลเดอร์กำหนดเอง, ระบุฟอนต์สำหรับงานนำเสนอเฉพาะผ่านแหล่งฟอนต์ระดับเอกสาร, หรือโหลดฟอนต์ภายนอกโดยตรงจากข้อมูลไบนารี

ฟอนต์ที่โหลดแล้วจะถูกใช้เมื่อทำการเรนเดอร์หรือส่งออกงานนำเสนอ เช่นเป็น PDF, รูปภาพ, และรูปแบบอื่นที่สนับสนุน สิ่งนี้ช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ในสภาพแวดล้อมที่ต่างกัน บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์ฟอนต์ที่ Aspose.Slides ใช้และวิธีลบแคชฟอนต์หลังจากทำงานกับฟอนต์ภายนอก

การลงทะเบียนฟอนต์กำหนดเองสำหรับการเรนเดอร์แตกต่างจากการฝังฟอนต์ลงในไฟล์ PPTX หากต้องการให้ฟอนต์ถูกเก็บไว้ภายในงานนำเสนอ ใช้คุณลักษณะการฝังฟอนต์โดยเฉพาะ

{{% alert color="primary"%}} 

Aspose Slides ให้คุณโหลดฟอนต์เหล่านี้โดยใช้เมธอด [loadExternalFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* ฟอนต์ TrueType (.ttf) และ TrueType Collection (.ttc) ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType).

* ฟอนต์ OpenType (.otf) ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **โหลดฟอนต์กำหนดเอง**

Aspose.Slides ช่วยให้คุณโหลดฟอนต์ที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ สิ่งนี้มีผลต่อผลลัพธ์การส่งออก เช่น PDF, รูปภาพ, และรูปแบบอื่นที่สนับสนุน ทำให้เอกสารที่ได้ดูสม่ำเสมอข้ามสภาพแวดล้อม ฟอนต์จะโหลดจากไดเรกทอรีกำหนดเอง

1. ระบุโฟลเดอร์หนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์ฟอนต์
2. เรียกเมธอดสแตติก [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) เพื่อโหลดฟอนต์จากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.clearCache](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/clearcache/) เพื่อเคลียร์แคชฟอนต์

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดฟอนต์:

```js
// กำหนดโฟลเดอร์ที่มีไฟล์ฟอนต์แบบกำหนดเอง.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// โหลดฟอนต์แบบกำหนดเองจากโฟลเดอร์ที่ระบุ.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // เรนเดอร์/ส่งออกงานนำเสนอ (เช่นเป็น PDF, รูปภาพ, หรือรูปแบบอื่น) โดยใช้ฟอนต์ที่โหลดแล้ว.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // ลบแคชฟอนต์หลังจากงานเสร็จสิ้น.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note"%}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) เพิ่มโฟลเดอร์เพิ่มเติมเข้าไปในเส้นทางค้นหาฟอนต์ แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นฟอนต์
ฟอนต์จะเริ่มต้นตามลำดับนี้:

1. เส้นทางฟอนต์เริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/)

{{%/alert %}}

## **รับโฟลเดอร์ฟอนต์กำหนดเอง**
Aspose.Slides มีเมธอด [getFontFolders](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) ที่ให้คุณค้นหาโฟลเดอร์ฟอนต์ เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์ฟอนต์ของระบบ

โค้ด JavaScript ด้านล่างแสดงวิธีใช้ [getFontFolders](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
// บรรทัดนี้แสดงโฟลเดอร์ที่ค้นหาไฟล์ฟอนต์.
// เหล่านั้นคือโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์ฟอนต์ของระบบ.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **ระบุฟอนต์กำหนดเองที่ใช้ร่วมกับงานนำเสนอ**
Aspose.Slides มีคุณสมบัติ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) ให้คุณระบุฟอนต์ภายนอกที่จะใช้ร่วมกับงานนำเสนอ

โค้ด JavaScript ด้านล่างแสดงวิธีใช้คุณสมบัติ [setDocumentLevelFontSources](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // ทำงานกับงานนำเสนอ
    // CustomFont1, CustomFont2, และฟอนต์จากโฟลเดอร์ assets\fonts & global\fonts รวมถึงโฟลเดอร์ย่อยของมันสามารถใช้ได้ในงานนำเสนอ
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **จัดการฟอนต์จากภายนอก**

Aspose.Slides มีเมธอด [loadExternalFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) ให้คุณโหลดฟอนต์ภายนอกจากข้อมูลไบนารี

โค้ด JavaScript ด้านล่างแสดงกระบวนการโหลดฟอนต์จากอาเรย์ไบต์:

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // ฟอนต์ภายนอกที่โหลดในช่วงอายุการทำงานของงานนำเสนอ
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

**ฟอนต์กำหนดเองมีผลต่อการส่งออกไปยังทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?**

ใช่ ฟอนต์ที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก

**ฟอนต์กำหนดเองจะถูกฝังอัตโนมัติใน PPTX ที่ได้หรือไม่?**

ไม่ การลงทะเบียนฟอนต์สำหรับการเรนเดอร์ไม่เท่ากับการฝังลงใน PPTX หากต้องการให้ฟอนต์อยู่ภายในไฟล์งานนำเสนอ ต้องใช้ [คุณลักษณะการฝังฟอนต์](/slides/th/nodejs-java/embedded-font/)

**ฉันสามารถควบคุมพฤติกรรม fallback เมื่อฟอนต์กำหนดเองไม่มี glyph บางตัวได้หรือไม่?**

ใช่ สามารถกำหนดค่า [font substitution](/slides/th/nodejs-java/font-substitution/), [replacement rules](/slides/th/nodejs-java/font-replacement/), และ [fallback sets](/slides/th/nodejs-java/fallback-font/) เพื่อระบุว่าฟอนต์ใดจะใช้เมื่อ glyph ที่ต้องการไม่มีอยู่

**ฉันสามารถใช้ฟอนต์ในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งบนระบบได้หรือไม่?**

ได้ เพียงชี้ไปที่โฟลเดอร์ฟอนต์ของคุณเองหรือโหลดฟอนต์จากอาเรย์ไบต์ จะไม่พึ่งพาไดเรกทอรีฟอนต์ของระบบในอิมเมจคอนเทนเนอร์

**เรื่องการอนุญาตใช้งาน—ฉันสามารถฝังฟอนต์กำหนดเองใด ๆ ได้โดยไม่มีข้อจำกัดหรือไม่?**

คุณต้องรับผิดชอบต่อการปฏิบัติตามเงื่อนไขการใช้งานฟอนต์ เงื่อนไขอาจแตกต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้ในเชิงพาณิชย์ ควรตรวจสอบ EULA ของฟอนต์ก่อนเผยแพร่ผลลัพธ์.