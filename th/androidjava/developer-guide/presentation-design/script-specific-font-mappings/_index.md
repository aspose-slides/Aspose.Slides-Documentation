---
title: จัดการฟอนต์ธีมที่เจาะจงตามสคริปต์บน Android
linktitle: ฟอนต์ธีมที่เจาะจงตามสคริปต์
type: docs
weight: 15
url: /th/androidjava/script-specific-font-mappings/
keywords:
- ฟอนต์ที่เจาะจงตามสคริปต์
- การแม็พฟอนต์ธีม
- งานนำเสนอหลายภาษา
- ระบบการเขียน
- ฟอนต์ Cyrillic
- ฟอนต์ Arabic
- ฟอนต์ Japanese
- ฟอนต์ Georgian
- ฟอนต์ Thaana
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ตรวจสอบ, เพิ่ม, แทนที่และลบการแม็พฟอนต์ที่เจาะจงตามสคริปต์ในธีม PowerPoint ด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

ธีมงานนำเสนอสามารถเลือกชุดฟอนต์ที่แตกต่างกันสำหรับระบบการเขียนที่ต่างกันได้ ซึ่งทำให้ข้อความหลายภาษาที่ยังคงใช้ฟอนต์ของธีมสามารถใช้แผนฟอนต์ที่สอดคล้องกันในขณะที่ใช้ฟอนต์ที่เหมาะสมสำหรับ Cyrillic, Arabic, Japanese, Georgian, Thaana และสคริปต์อื่น ๆ

[IFontScheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontscheme/) ของธีมมีคอลเล็กชันฟอนต์หลักที่มักใช้สำหรับหัวข้อและคอลเล็กชันฟอนต์รองที่มักใช้สำหรับข้อความตัว본문 นอกจากการตั้งค่าฟอนต์ Latin และ East Asian แล้ว ทั้งสองคอลเล็กชันยังเปิดเผยการแม็พจากแท็กระบบการเขียนไปยังชื่อชุดฟอนต์ผ่านอินเทอร์เฟซ [IFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifonts/)

บทความนี้แสดงวิธีตรวจสอบและแก้ไขการแม็พเหล่านี้ในธีมมาสเตอร์ของงานนำเสนอและยืนยันว่าการเปลี่ยนแปลงยังคงอยู่หลังจากการบันทึกและโหลดใหม่

## **ทำความเข้าใจแท็กสคริปต์**

เมธอดฟอนต์สคริปต์ใช้แท่งสคริปต์ BCP 47 ที่มีสี่ตัวอักษรเพื่อระบุระบบการเขียน ค่าที่พบบ่อยมีดังนี้

| แท็กสคริปต์ | ระบบการเขียน |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

การแม็พเหล่านี้เป็นของโครงสร้างฟอนต์ธีม ไม่ใช่ของส่วนข้อความแต่ละส่วน งานนำเสนออาจกำหนดการแม็พที่แตกต่างกันสำหรับคอลเล็กชันหลักและรอง และอาจไม่มีการแม็พสำหรับสคริปต์บางอย่าง

## **เข้าถึงและตรวจสอบการแม็พฟอนต์สคริปต์**

ใช้ [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getMasterTheme--) เพื่อเข้าถึงธีมระดับงานนำเสนอ เมธอด [IFontScheme.getMajor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontscheme/#getMajor--) และ [IFontScheme.getMinor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifontscheme/#getMinor--) จะคืนคอลเล็กชัน [IFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ifonts/) สองชุด

เรียก [IFonts.getScriptFontMap](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) เพื่อดึงการแม็พทั้งหมดจากคอลเล็กชันหนึ่ง ๆ หากต้องการค้นหาระบบการเขียนหนึ่งระบบ ให้เรียก [IFonts.getScriptFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) พร้อมแท็กสคริปต์ `getScriptFont` จะคืนค่า `null` เมื่อคอลเล็กชันนั้นไม่ได้กำหนดการแม็พที่ร้องขอ

## **แก้ไขการแม็พและตรวจสอบความคงอยู่**

ใช้ [IFonts.setScriptFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) เพื่อสร้างการแม็พหรือแทนที่ชุดฟอนต์ปัจจุบัน ใช้ [IFonts.removeScriptFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) เพื่อลบการแม็พ

ตัวอย่างต่อไปนี้เป็นตัวอย่างครบวงจรที่อ่านการแม็พหลักและรองทั้งหมด ค้นหาฟอนต์หลักของ Japanese เปลี่ยนฟอนต์หลักของ Cyrillic ลบการแม็พรองของ Thaana บันทึกงานนำเสนอ แล้วเปิดใหม่เพื่อตรวจสอบการเปลี่ยนแปลงทั้งสอง เพื่อทำให้ขั้นตอนการลบเป็นอิสระจากธีมเริ่มต้น ตัวอย่างจะสร้างการแม็พ Thaana เท่านั้นเมื่อยังไม่มีการกำหนดไว้

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

การตรวจสอบใช้พฤติกรรม `null` เหมือนการค้นหาปกติ: หลังจากบันทึกขั้นตอนการลบแล้ว `getScriptFont("Thaa")` จะคืนค่า `null` สำหรับคอลเล็กชันรอง

## **แยกความแตกต่างระหว่างการแม็พธีมกับการตั้งค่าฟอนต์อื่น ๆ**

การแม็พธีมตามสคริปต์มีส่วนร่วมในการเลือกฟอนต์ แต่แก้ไขปัญหาอื่นที่ต่างจากการจัดรูปแบบข้อความโดยตรง การแทนที่ฟอนต์ และการสำรองฟอนต์:

| กลไก | วัตถุประสงค์ | ผลของการเปลี่ยนการแม็พธีม |
|---|---|---|
| การแม็พฟอนต์ธีมตามสคริปต์ | เลือกฟอนต์ธีมหลักหรือรองสำหรับระบบการเขียน | ข้อความที่ยังใช้ฟอนต์ธีมที่สอดคล้องสามารถแก้ไขเป็นชุดฟอนต์ที่แม็พใหม่ |
| ฟอนต์ที่กำหนดโดยตรงให้กับส่วนข้อความ | กำหนดชุดฟอนต์ที่ร้องขอบนส่วนนั้นแทนการพึ่งธีม | ส่วนนั้นอาจคงเดิมไว้เนื่องจากการจัดรูปแบบโดยตรงลบล้างการเลือกธีม |
| การแทนที่ฟอนต์ | แทนที่ฟอนต์ที่ร้องขอเมื่อฟอนต์นั้นไม่มีหรือมีกฎการแทนที่ | ทำงานหลังจากฟอนต์ถูกร้องขอ; ไม่เปลี่ยนการแม็พสคริปต์ของธีม |
| การสำรองฟอนต์ | ให้ glyph ที่ฟอนต์ที่เลือกไม่มีบ่อยสำหรับช่วง Unicode เฉพาะ | เติมเต็ม glyph ที่ขาด; ไม่เปลี่ยนการแม็พธีมที่บันทึกไว้ |

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับสองกลไกสุดท้าย ดูที่ [Font Substitution](/slides/th/androidjava/font-substitution/) และ [Fallback Fonts](/slides/th/androidjava/fallback-font/)

การเปลี่ยนการแม็พใน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getMasterTheme--) มีผลเฉพาะต่อเนื้อหาที่การจัดรูปแบบที่มีผลยังขึ้นอยู่กับธีมนั้น ข้อความอาจสืบทอดการเขียนทับจากมาสเตอร์ เลย์เอาต์ หรือสไลด์ หรือใช้ฟอนต์ที่กำหนดโดยตรง ตรวจสอบระดับเหล่านั้นเมื่อผลลัพธ์ที่เห็นไม่เป็นไปตามการแม็พระดับงานนำเสนอ

## **ทำให้ฟอนต์ที่แม็พพร้อมใช้งานและตรวจสอบผลลัพธ์**

การแม็พสคริปต์จะเก็บชื่อชุดฟอนต์เท่านั้น ไม่ได้ติดตั้งหรือโหลดไฟล์ฟอนต์ที่สอดคล้องกันเพื่อให้แสดงผลและส่งออกอย่างสม่ำเสมอ ฟอนต์ที่แม็พทุกตัวต้องถูกติดตั้งในสภาพแวดล้อมหรือถูกจัดหาให้กับ Aspose.Slides ผ่านแหล่งกำเนิดแบบกำหนดเอง เช่น [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) หรือ [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--) ดูที่ [Custom Fonts](/slides/th/androidjava/custom-font/) สำหรับตัวเลือกการโหลดที่มี

การตรวจสอบการแม็พที่บันทึกไว้ยืนยันเพียงว่าการกำหนดธีมถูกเก็บไว้ ไม่ได้พิสูจน์ว่าฟอนต์นั้นพร้อมใช้งาน มี glyph ครบหรือให้ผลลัพธ์ตามที่ต้องการ ให้เรนเดอร์ข้อความตัวอย่างสำหรับแต่ละระบบการเขียนที่ต้องการเป็นภาพหรือ PDF แล้วตรวจสอบผลลัพธ์ สิ่งนี้จะจับฟอนต์ที่หายไป การครอบคลุม glyph ที่ไม่สมบูรณ์ พฤติกรรมสำรอง และการเปลี่ยนแปลงเลย์เอาต์ก่อนแจกจ่ายงานนำเสนอ ดูที่ [Convert PowerPoint Presentations](/slides/th/androidjava/convert-powerpoint/) สำหรับตัวอย่างการเรนเดอร์และส่งออก

## **FAQ**

**`getScriptFont` คืนค่าอะไรเมื่อสคริปต์ไม่มีการแม็พ?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) คืนค่า `null` เมื่อการแม็พสคริปต์ที่ร้องขอไม่ได้ถูกกำหนดในคอลเล็กชันหลักหรือรองนั้น

**`setScriptFont` เพิ่มการแม็พที่สองเมื่อสคริปต์มีอยู่แล้วหรือไม่?**

ไม่. [IFonts.setScriptFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) จะสร้างการแม็พเมื่อไม่มีและแทนที่ชุดฟอนต์ที่แม็พเมื่อแท็กสคริปต์นั้นมีอยู่แล้ว

**ทำไมการเปลี่ยนการแม็พธีมถึงไม่เปลี่ยนข้อความบางส่วน?**

ข้อความอาจมีฟอนต์ที่กำหนดโดยตรง สืบทอดธีมที่แตกต่างผ่านการเขียนทับ หรือได้รับผลจากการแทนที่หรือสำรองในระหว่างการเรนเดอร์ การแม็พสคริปต์ระดับงานนำเสนอควบคุมเฉพาะข้อความที่การจัดรูปแบบที่มีผลยังอ้างอิงถึงคอลเล็กชันฟอนต์ธีมนั้น

**การบันทึกและเปิดใหม่เพียงพอที่จะตรวจสอบผลลัพธ์หลายภาษาหรือไม่?**

ไม่. การเปิดใหม่ยืนยันความคงอยู่ของข้อมูลธีมเท่านั้น ควรเรนเดอร์ข้อความตัวอย่างจากแต่ละระบบการเขียนที่ต้องการเพื่อยืนยันว่าฟอนต์ที่แม็พพร้อมใช้และมี glyph ที่จำเป็นครบถ้วน