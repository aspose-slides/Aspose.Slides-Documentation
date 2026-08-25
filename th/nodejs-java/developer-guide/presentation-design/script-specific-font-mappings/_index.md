---
title: จัดการฟอนต์ธีมตามสคริปต์ใน JavaScript
linktitle: ฟอนต์ธีมตามสคริปต์
type: docs
weight: 15
url: /th/nodejs-java/script-specific-font-mappings/
keywords:
- ฟอนต์ตามสคริปต์
- การแมปฟอนต์ธีม
- งานนำเสนอหลายภาษา
- ระบบการเขียน
- ฟอนต์ Cyrillic
- ฟอนต์ Arabic
- ฟอนต์ Japanese
- ฟอนต์ Georgian
- ฟอนต์ Thaana
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ตรวจสอบ, เพิ่ม, แทนที่และลบการแมปฟอนต์ตามสคริปต์ในธีม PowerPoint ด้วย Aspose.Slides สำหรับ Node.js."
---
## **ภาพรวม**

ธีมการนำเสนอสามารถเลือกฟอนต์ตระกูลที่แตกต่างกันสำหรับระบบการเขียนที่ต่างกัน ซึ่งทำให้ข้อความหลายภาษา ที่ยังใช้ฟอนต์จากธีม สามารถปฏิบัติตามโ_scheme ฟอนต์ที่สอดคล้องกันได้พร้อมกับใช้ฟอนต์ที่เหมาะสมสำหรับ Cyrillic, Arabic, Japanese, Georgian, Thaana และสคริปต์อื่น ๆ

[FontScheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontscheme/) ของธีมประกอบด้วยคอลเลกชันฟอนต์หลัก (major) ที่มักใช้สำหรับหัวเรื่อง และคอลเลกชันฟอนต์รอง (minor) ที่มักใช้สำหรับข้อความหลัก นอกจากการตั้งค่าฟอนต์ละตินและฟอนต์เอเชียตะวันออก ทั้งสองคอลเลกชันยังเปิดเผยการแมปจากแท็กระบบการเขียนไปยังชื่อฟอนต์ตระกูลผ่านคลาส [Fonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fonts/)

บทความนี้แสดงวิธีตรวจสอบและแก้ไขการแมปเหล่านั้นในธีมมาสเตอร์ของงานนำเสนอ และตรวจสอบว่าการเปลี่ยนแปลงนั้นคงอยู่หลังการบันทึกและเปิดใหม่

## **เข้าใจแท็กสคริปต์**

เมธอดฟอนต์สคริปต์ใช้แท็ສคริปต์ BCP 47 แบบสี่ตัวอักษรเพื่อระบุตัวระบบการเขียน ค่าที่พบบ่อยได้แก่:

| แท็กสคริปต์ | ระบบการเขียน |
|---|---|
| `Cyrl` | ซีริลลิก |
| `Arab` | อารบิก |
| `Hans` | จีนตัวย่อ |
| `Jpan` | ญี่ปุ่น |
| `Geor` | จอเจอร์เจียน |
| `Thaa` | ทานา |

การแมปเหล่านี้เป็นของสกีมฟอนต์ในธีม ไม่ได้เป็นของส่วนข้อความแต่ละส่วน งานนำเสนออาจกำหนดการแมปที่ต่างกันสำหรับคอลเลกชันหลักและรอง และอาจไม่มีการแมปสำหรับสคริปต์บางตัว

## **เข้าถึงและตรวจสอบการแมปฟอนต์สคริปต์**

ใช้เมธอด [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getmastertheme/) เพื่อเข้าถึงธีมระดับงานนำเสนอ เมธอด [FontScheme.getMajor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontscheme/) และ [FontScheme.getMinor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontscheme/) จะคืนคอลเลกชัน [Fonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fonts/) สองชุด

เรียกเมธอด [Fonts.getScriptFontMap](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fonts/) เพื่อดึงการแมปทั้งหมดจากคอลเลกชันหนึ่ง ๆ หากต้องการค้นหาระบบการเขียนหนึ่งระบบ ให้เรียก [Fonts.getScriptFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fonts/) พร้อมแท็กสคริปต์ของมัน `getScriptFont` จะคืนค่า `null` เมื่อคอลเลกชันนั้นไม่มีการแมปที่ร้องขอ

## **แก้ไขการแมปและตรวจสอบการคงอยู่**

ใช้เมธอด [Fonts.setScriptFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fonts/) เพื่อสร้างการแมปหรือแทนที่ฟอนต์ตระกูลปัจจุบัน ใช้ [Fonts.removeScriptFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fonts/) เพื่อลบการแมป

ตัวอย่างต่อไปนี้เป็นการทำงานแบบครบวงจรที่อ่านการแมปหลักและรองทั้งหมด ค้นหา ฟอนต์หลักของญี่ปุ่น เปลี่ยนฟอนต์หลักของ Cyrillic ลบการแมป Thaana ของคอลเลกชันรอง บันทึกงานนำเสนอ แล้วเปิดใหม่เพื่อตรวจสอบว่าการเปลี่ยนแปลงทั้งสองเกิดขึ้น เพื่อให้ขั้นตอนการลบเป็นอิสระจากธีมเริ่มต้น ตัวอย่างจะสร้างการแมป Thaana เฉพาะเมื่อยังไม่มีการแมปนั้นอยู่

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

การตรวจสอบใช้พฤติกรรม `null` เช่นเดียวกับการค้นหาปกติ: หลังจากบันทึกการลบแล้ว `getScriptFont("Thaa")` จะคืนค่า `null` สำหรับคอลเลกชันรอง

## **แยกความแตกต่างระหว่างการแมปธีมกับการตั้งค่าอื่นของฟอนต์**

การแมปฟอนต์ธีมตามสคริปต์มีส่วนร่วมในการเลือกฟอนต์ แต่แก้ปัญหาแตกต่างจากการจัดรูปแบบข้อความโดยตรง การทดแทนฟอนต์ และการสำรองฟอนต์:

| กลไก | วัตถุประสงค์ | ผลของการเปลี่ยนแปลงการแมปธีม |
|---|---|---|
| การแมปฟอนต์ธีมตามสคริปต์ | เลือกฟอนต์ธีมหลักหรือรองสำหรับระบบการเขียน | ข้อความที่ยังใช้ฟอนต์ธีมที่สอดคล้องสามารถแก้ไขเป็นตระกูลฟอนต์ใหม่ที่แมปไว้ |
| ฟอนต์ที่กำหนดอย่างชัดเจนให้กับส่วนข้อความ | กำหนดตระกูลฟอนต์ที่ต้องการให้กับส่วนนั้นโดยไม่พึ่งธีม | ส่วนนั้นอาจไม่เปลี่ยนแปลงเนื่องจากการจัดรูปแบบโดยตรงทับการเลือกธีม |
| การทดแทนฟอนต์ | แทนที่ฟอนต์ที่ร้องขอเมื่อฟอนต์นั้นไม่มีอยู่หรือเมื่อนโยบายการทดแทนทำงาน | ทำงานหลังจากมีการร้องขอฟอนต์; ไม่เปลี่ยนแปลงการแมปสคริปต์ของธีม |
| การสำรองฟอนต์ | ให้ glyphs ที่ฟอนต์ที่เลือกไม่มีอยู่, มักสำหรับช่วงยูนิโค้ดเฉพาะ | เติมช่องว่างของ glyphs ที่หายไป; ไม่เปลี่ยนแปลงการแมปธีมที่เก็บไว้ |

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับสองกลไกสุดท้าย ดูที่ [การทดแทนฟอนต์](/slides/th/nodejs-java/font-substitution/) และ [ฟอนต์สำรอง](/slides/th/nodejs-java/fallback-font/)

การเปลี่ยนแปลงการแมปใน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getmastertheme/) มีผลต่อเนื้อหาเท่านั้นที่การจัดรูปแบบที่มีผลยังอ้างอิงถึงธีมนั้น ข้อความอาจสืบทอดการแก้ไขธีมจากมาสเตอร์, เลเอาต์ หรือสไลด์, หรือใช้ฟอนต์ที่กำหนดอย่างชัดเจน ตรวจสอบระดับเหล่านั้นเมื่อผลลัพธ์ที่เห็นไม่สอดคล้องกับการแมประดับงานนำเสนอ

## **ทำให้ฟอนต์ที่แมปพร้อมใช้งานและตรวจสอบผลลัพธ์**

การแมปสคริปต์จะเก็บชื่อฟอนต์ตระกูล; มันไม่ได้ติดตั้งหรือโหลดไฟล์ฟอนต์ที่สอดคล้องกัน เพื่อการเรนเดอร์และการส่งออกที่สอดคล้อง ทุกฟอนต์ที่แมปต้องถูกติดตั้งในสภาพแวดล้อมหรือจัดหาให้ Aspose.Slides ผ่านแหล่งกำเนิดแบบกำหนดเอง เช่น [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) หรือ [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/) ดูที่ [ฟอนต์กำหนดเอง](/slides/th/nodejs-java/custom-font/) เพื่อดูตัวเลือกการโหลดที่มี

การตรวจสอบการแมปที่บันทึกไว้เพียงยืนยันว่ากำหนดธีมยังคงอยู่ ไม่ได้พิสูจน์ว่าฟอนต์พร้อมใช้งาน มี glyphs ครบหรือให้ผลลัพธ์ตามที่ต้องการ เราควรเรนเดอร์ข้อความตัวอย่างสำหรับทุกระบบการเขียนที่ต้องการเป็นภาพหรือ PDF แล้วตรวจสอบผลลัพธ์ วิธีนี้จะช่วยจับฟอนต์ที่หายไป, coverage glyph ที่ไม่ครบ, พฤติกรรม fallback, และการเปลี่ยนแปลงการจัดวางก่อนที่งานนำเสนอจะเผยแพร่ ดูที่ [การแปลงงานนำเสนอ PowerPoint](/slides/th/nodejs-java/convert-powerpoint/) สำหรับตัวอย่างการเรนเดอร์และส่งออก

## **คำถามที่พบบ่อย**

**`getScriptFont` คืนค่าอะไรเมื่อสคริปต์ไม่มีการแมป?**  
[Fonts.getScriptFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fonts/) คืนค่า `null` เมื่อการแมปสคริปต์ที่ร้องขอไม่ได้กำหนดในคอลเลกชันฟอนต์หลักหรือรองนั้น

**`setScriptFont` เพิ่มการแมปที่สองเมื่อสคริปต์มีอยู่แล้วหรือไม่?**  
ไม่ใช่。[Fonts.setScriptFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fonts/) จะสร้างการแมปเมื่อไม่มีและจะแทนที่ฟอนต์ตระกูลที่แมปอยู่เมื่อแท็กสคริปต์นั้นมีอยู่แล้ว

**ทำไมการเปลี่ยนแปลงการแมปธีมถึงไม่ทำให้ข้อความบางส่วนเปลี่ยน?**  
ข้อความอาจมีฟอนต์ที่กำหนดอย่างชัดเจน, สืบทอดธีมที่แตกต่างผ่านการโอเวอร์ไรด์, หรือได้รับผลจากการทดแทนหรือสำรองฟอนต์ในระหว่างการเรนเดอร์ การแมปสคริปต์ระดับงานนำเสนอควบคุมเฉพาะข้อความที่การจัดรูปแบบที่มีผลยังอ้างอิงถึงคอลเลกชันฟอนต์ธีมนั้น

**การบันทึกและเปิดใหม่พอเพียงหรือไม่ในการตรวจสอบผลลัพธ์หลายภาษา?**  
ไม่พอ การเปิดใหม่เพียงยืนยันความคงอยู่ของข้อมูลธีมเท่านั้น ควรเรนเดอร์ข้อความตัวอย่างจากแต่ละระบบการเขียนที่ต้องการเพื่อยืนยันว่าฟอนต์ที่แมปพร้อมใช้งานและมี glyphs ที่จำเป็นครบถ้วน.