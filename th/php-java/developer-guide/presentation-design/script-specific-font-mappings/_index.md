---
title: จัดการแบบอักษรธีมเฉพาะสคริปต์ใน PHP
linktitle: แบบอักษรธีมเฉพาะสคริปต์
type: docs
weight: 15
url: /th/php-java/script-specific-font-mappings/
keywords:
- แบบอักษรเฉพาะสคริปต์
- การแมปแบบอักษรธีม
- งานนำเสนอหลายภาษา
- ระบบการเขียน
- แบบอักษรซีริลลิก
- แบบอักษรอารบิก
- แบบอักษรญี่ปุ่น
- แบบอักษรจอร์เจีย
- แบบอักษรธานา
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ตรวจสอบ, เพิ่ม, แทนที่และลบการแมปแบบอักษรเฉพาะสคริปต์ในธีม PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

ธีมงานนำเสนอสามารถเลือกชุดแบบอักษรที่แตกต่างกันสำหรับระบบการเขียนที่แตกต่างกันได้ ซึ่งทำให้ข้อความหลายภาษา ที่ยังคงใช้แบบอักษรของธีม สามารถใช้รูปแบบแบบอักษรที่สอดคล้องกันได้ ในขณะเดียวกันก็ใช้แบบอักษรที่เหมาะสมสำหรับ Cyrillic, Arabic, Japanese, Georgian, Thaana และสคริปต์อื่น ๆ

ธีมของ [FontScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontscheme/) จะประกอบด้วยชุดแบบอักษรหลักซึ่งโดยทั่วไปใช้สำหรับหัวเรื่อง และชุดแบบอักษรรองซึ่งโดยทั่วไปใช้สำหรับข้อความหลัก นอกเหนือจากการตั้งค่าแบบอักษรสำหรับละตินและเอเชียตะวันออกแล้ว ทั้งสองชุด [Fonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fonts/) ยังเปิดเผยการแมปจากแท็กระบบการเขียนไปยังชื่อแบบอักษร

บทความนี้แสดงวิธีตรวจสอบและแก้ไขการแมปเหล่านั้นในธีมมาสเตอร์ของงานนำเสนอและตรวจสอบว่าการเปลี่ยนแปลงยังคงอยู่หลังจากการบันทึกและโหลดใหม่

## **ทำความเข้าใจแท็กสคริปต์**

เมธอดแบบอักษรสคริปต์ใช้ส่วนย่อยของสคริปต์ BCP 47 ที่มีสี่ตัวอักษรเพื่อระบุระบบการเขียน ค่าที่พบบ่อยได้แก่:

| แท็กสคริปต์ | ระบบการเขียน |
|---|---|
| `Cyrl` | ซีริลลิก |
| `Arab` | อารบิก |
| `Hans` | จีนแบบประยุกต์ |
| `Jpan` | ญี่ปุ่น |
| `Geor` | จอร์เจีย |
| `Thaa` | ธานา |

การแมปเหล่านี้เป็นของธีมฟอนต์สคีมของธีม ไม่ได้เป็นของส่วนข้อความแต่ละส่วน งานนำเสนออาจกำหนดการแมปที่ต่างกันสำหรับชุดหลักและชุดรอง และอาจไม่มีการแมปสำหรับสคริปต์บางอย่าง

## **เข้าถึงและตรวจสอบการแมปแบบอักษรสคริปต์**

ใช้ [Presentation::getMasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getMasterTheme) เพื่อเข้าถึงธีมระดับงานนำเสนอ เมธอด [MasterTheme::getFontScheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontscheme/#getMajor), และ [FontScheme::getMinor](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontscheme/#getMinor) ให้การเข้าถึงชุด [Fonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fonts/) ทั้งสองชุด

เรียก [Fonts::getScriptFontMap](https://reference.aspose.com/slides/th/php-java/aspose.slides/fonts/#getScriptFontMap) เพื่อดึงการแมปทั้งหมดจากชุดหนึ่ง เพื่อค้นหาระบบการเขียนหนึ่ง ให้เรียก [Fonts::getScriptFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/fonts/#getScriptFont) พร้อมแท็กสคริปต์ของมัน `Fonts::getScriptFont` จะคืนค่า `null` เมื่อชุดนั้นไม่ได้กำหนดการแมปที่ต้องการ

## **แก้ไขการแมปและตรวจสอบความคงที่**

ใช้ [Fonts::setScriptFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/fonts/#setScriptFont) เพื่อสร้างการแมปหรือแทนที่แบบอักษรครอบครัวปัจจุบัน ใช้ [Fonts::removeScriptFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/fonts/#removeScriptFont) เพื่อลบการแมป

ตัวอย่างต่อไปนี้เป็นแบบ End‑to‑End ที่อ่านการแมปหลักและรองทั้งหมด ค้นหาแบบอักษรหลักของญี่ปุ่น เปลี่ยนแบบอักษรหลักของ Cyrillic ลบการแมป Thaana ในชุดรอง บันทึกงานนำเสนอและเปิดใหม่เพื่อยืนยันการเปลี่ยนแปลงทั้งสอง เพื่อทำให้ขั้นตอนการลบเป็นอิสระจากธีมเริ่มต้น ตัวอย่างจะสร้างการแมป Thaana แค่เมื่อยังไม่มีการแมปนั้น

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

การตรวจสอบใช้พฤติกรรม `null` แบบเดียวกับการค้นหาปกติ: หลังจากบันทึกการลบแล้ว `Fonts::getScriptFont("Thaa")` จะคืนค่า `null` สำหรับชุดรอง

## **แยกแยะการแมปของธีมจากการตั้งค่าแบบอักษรอื่น ๆ**

การแมปธีมที่ระบุสคริปต์มีส่วนร่วมในการเลือกแบบอักษร แต่แก้ปัญหาแตกต่างจากการจัดรูปแบบข้อความโดยตรง การแทนที่แบบอักษรและการสำรองแบบอักษร:

| กลไก | วัตถุประสงค์ | ผลของการเปลี่ยนแปลงการแมปของธีม |
|---|---|---|
| การแมปแบบอักษรสคริปต์‑เฉพาะของธีม | เลือกแบบอักษรธีมหลักหรือรองสำหรับระบบการเขียนหนึ่ง | ข้อความที่ยังคงใช้แบบอักษรธีมที่สอดคล้องสามารถแก้ไขเป็นครอบครัวแบบอักษรที่แมปใหม่ได้ |
| แบบอักษรที่กำหนดโดยตรงให้กับส่วนของข้อความ | กำหนดครอบครัวแบบอักษรที่ต้องการให้กับส่วนนั้นโดยไม่พึ่งพาธีม | ส่วนนั้นอาจไม่เปลี่ยนแปลงเพราะการจัดรูปแบบโดยตรงเหนือกว่าการเลือกของธีม |
| การแทนที่แบบอักษร | แทนที่แบบอักษรที่ขอเมื่อแบบอักษรนั้นไม่มีหรือกฎการแทนที่มีผล | ทำงานหลังจากที่แบบอักษรถูกขอ; ไม่ได้กำหนดการแมปสคริปต์ของธีมใหม่ |
| การสำรองแบบอักษร | จัดหา glyph ที่แบบอักษรที่เลือกไม่มีบ่อยสำหรับช่วง Unicode เฉพาะ | เติมการครอบคลุม glyph ที่หายไป; ไม่เปลี่ยนการแมปของธีมที่เก็บไว้ |

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับสองกลไกสุดท้าย ให้ดู [Font Substitution](/slides/th/php-java/font-substitution/) และ [Fallback Fonts](/slides/th/php-java/fallback-font/)

การเปลี่ยนการแมปใน [Presentation::getMasterTheme](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getMasterTheme) มีผลต่อเนื้อหาเท่านั้นที่การจัดรูปแบบที่มีผลยังคงพึ่งพาธีมนั้น ข้อความอาจแทนที่ด้วยการสืบทอดการบังคับธีมจากมาสเตอร์, เลย์เอาต์ หรือสไลด์, หรือใช้แบบอักษรที่กำหนดโดยตรง ตรวจสอบระดับเหล่านั้นเมื่อผลลัพธ์ที่มองเห็นไม่ได้เป็นไปตามการแมประดับงานนำเสนอ

## **ทำให้แบบอักษรที่แมปพร้อมใช้งานและตรวจสอบผลลัพธ์**

การแมปสคริปต์เก็บชื่อแบบอักษรครอบครัว; ไม่ได้ติดตั้งหรือโหลดไฟล์แบบอักษรที่สอดคล้องกัน เพื่อการเรนเดอร์และส่งออกที่สม่ำเสมอ แบบอักษรที่แมปทุกตัวต้องถูกติดตั้งในสภาพแวดล้อนหรือจัดหาให้กับ Aspose.Slides ผ่านแหล่งกำหนดเอง เช่น [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsloader/#loadExternalFonts) หรือ [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) ดู [Custom Fonts](/slides/th/php-java/custom-font/) เพื่อดูตัวเลือกการโหลดที่มี

การตรวจสอบการแมปที่บันทึกไว้ยืนยันแค่ว่าข้อมูลธีมถูกเก็บรักษาไว้เท่านั้น ไม่ได้พิสูจน์ว่าแบบอักษรพร้อมใช้งาน มี glyph ที่จำเป็นครบหรือสร้างเลย์เอาต์ตามที่ตั้งใจ เราแนะนำให้เรนเดอร์ข้อความตัวอย่างสำหรับทุกระบบการเขียนที่ต้องการเป็นภาพหรือ PDF แล้วตรวจสอบผลลัพธ์ วิธีนี้จะจับแบบอักษรที่หายไป การครอบคลุม glyph ที่ไม่สมบูรณ์ พฤติกรรมสำรอง และการเปลี่ยนแปลงเลย์เอาต์ก่อนแจกจ่ายงานนำเสนอ ดู [Convert PowerPoint Presentations](/slides/th/php-java/convert-powerpoint/) เพื่อดูตัวอย่างการเรนเดอร์และส่งออก

## **คำถามที่พบบ่อย**

**`Fonts::getScriptFont` คืนค่าอะไรเมื่อสคริปต์ไม่ได้ถูกแมป?**

`Fonts::getScriptFont` จะคืนค่า `null` เมื่อการแมปสคริปต์ที่ขอไม่ได้ถูกกำหนดในชุดแบบอักษรหลักหรือรองนั้น

**`Fonts::setScriptFont` เพิ่มการแมปที่สองเมื่อสคริปต์มีอยู่แล้วหรือไม่?**

ไม่มี. `Fonts::setScriptFont` จะสร้างการแมปเมื่อไม่มีและจะแทนที่แบบอักษรครอบครัวที่แมปไว้เมื่อแท็กสคริปต์เดียวกันมีอยู่แล้ว

**ทำไมการเปลี่ยนแปลงการแมปของธีมถึงไม่เปลี่ยนข้อความบางส่วน?**

ข้อความอาจมีแบบอักษรที่กำหนดโดยตรง, สืบทอดธีมที่แตกต่างผ่านการบังคับ, หรือได้รับผลกระทบจากการแทนที่หรือการสำรองระหว่างการเรนเดอร์ การแมปสคริปต์ระดับงานนำเสนอควบคุมเฉพาะข้อความที่การจัดรูปแบบที่มีผลยังคงอ้างอิงถึงชุดแบบอักษรธีมนั้น

**การบันทึกและเปิดใหม่เพียงพอที่จะตรวจสอบผลลัพธ์หลายภาษาใช่หรือไม่?**

ไม่. การเปิดใหม่จะตรวจสอบความคงอยู่ของข้อมูลธีมเท่านั้น ควรเรนเดอร์ข้อความตัวอย่างจากแต่ละระบบการเขียนที่ต้องการเพื่อยืนยันว่าแบบอักษรที่แมปพร้อมใช้งานและมี glyph ที่จำเป็นครบถ้วน**