---
title: จัดการฟอนต์ธีมที่กำหนดตามสคริปต์ใน Java
linktitle: ฟอนต์ธีมที่กำหนดตามสคริปต์
type: docs
weight: 15
url: /th/java/script-specific-font-mappings/
keywords:
- ฟอนต์ที่กำหนดตามสคริปต์
- การแมปฟอนต์ธีม
- การนำเสนอหลายภาษา
- ระบบการเขียน
- ฟอนต์ซีริลลิก
- ฟอนต์อาหรับ
- ฟอนต์ญี่ปุ่น
- ฟอนต์จอร์เจีย
- ฟอนต์ธานา
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบ, เพิ่ม, แทนที่และลบการแมปฟอนต์ที่กำหนดตามสคริปต์ในธีม PowerPoint ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

ธีมการนำเสนอสามารถเลือกฟอนต์ตระกูลที่ต่างกันสำหรับระบบการเขียนที่แตกต่างกันได้ สิ่งนี้ทำให้ข้อความหลายภาษาซึ่งยังคงใช้ฟอนต์ของธีมสามารถปฏิบัติตามโครงร่างฟอนต์ที่ประสานกันหนึ่งเดียวขณะใช้ฟอนต์ที่เหมาะสมสำหรับ Cyrillic, Arabic, Japanese, Georgian, Thaana และสคริปต์อื่น ๆ

ธีมของมี [IFontScheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontscheme/) ซึ่งประกอบด้วยคอลเลกชันฟอนต์หลักที่มักใช้สำหรับหัวเรื่อง และคอลเลกชันฟอนต์รองที่มักใช้สำหรับข้อความหลัก นอกเหนือจากการตั้งค่าฟอนต์ Latin และ East Asian ทั้งสองคอลเลกชันเปิดเผยการแมปจากแท็กระบบการเขียนไปยังชื่อฟอนต์ตระกูลผ่านอินเทอร์เฟซ [IFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifonts/) 

บทความนี้แสดงวิธีตรวจสอบและแก้ไขการแมปเหล่านั้นในธีมหลักของการนำเสนอและตรวจสอบว่าการเปลี่ยนแปลงยังคงอยู่หลังการบันทึกและโหลดใหม่

## **ทำความเข้าใจแท็กสคริปต์**

เมธอดฟอนต์สคริปต์ใช้ subtags สคริปต์ BCP 47 ที่มีสี่ตัวอักษรเพื่อระบุตัวระบบการเขียน ค่าที่พบบ่อยได้แก่:

| แท็กสคริปท์ | ระบบการเขียน |
|---|---|
| `Cyrl` | ซีริลลิก |
| `Arab` | อาหรับ |
| `Hans` | จีนแบบง่าย |
| `Jpan` | ญี่ปุ่น |
| `Geor` | จอร์เจีย |
| `Thaa` | ธานา |

การแมปเหล่านี้เป็นของโครงร่างฟอนต์ธีม ไม่ใช่ของส่วนข้อความแต่ละส่วน การนำเสนออาจกำหนดการแมปที่แตกต่างกันสำหรับคอลเลกชันหลักและรอง และอาจละเว้นการแมปสำหรับสคริปต์บางตัว

## **เข้าถึงและตรวจสอบการแมปฟอนต์สคริปต์**

ใช้ [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getMasterTheme--) เพื่อเข้าถึงธีมระดับการนำเสนอ เมธอด [IFontScheme.getMajor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontscheme/#getMajor--) และ [IFontScheme.getMinor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontscheme/#getMinor--) จะส่งคืนคอลเลกชัน [IFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifonts/) สองชุด

เรียก [IFonts.getScriptFontMap](https://reference.aspose.com/slides/th/java/com.aspose.slides/fonts/#getScriptFontMap--) เพื่อดึงการแมปทั้งหมดจากคอลเลกชันหนึ่ง เพื่อค้นหาระบบการเขียนหนึ่ง ให้เรียก [IFonts.getScriptFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) พร้อมแท็กสคริปต์ของมัน `getScriptFont` จะคืนค่า `null` เมื่อคอลเลกชันนั้นไม่ได้กำหนดการแมปที่ร้องขอ

## **แก้ไขการแมปและตรวจสอบการคงอยู่**

ใช้ [IFonts.setScriptFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) เพื่อสร้างการแมปหรือแทนที่ฟอนต์ตระกูลปัจจุบัน ใช้ [IFonts.removeScriptFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) เพื่อลบการแมป

ตัวอย่างแบบ end-to-end ด้านล่างอ่านการแมปหลักและรองที่มีอยู่ทั้งหมด ค้นหาฟอนต์หลักของญี่ปุ่น เปลี่ยนฟอนต์หลักของซีริลลิก ลบการแมปรองของธานา บันทึกการนำเสนอและเปิดใหม่เพื่อยืนยันการเปลี่ยนแปลงทั้งสอง เพื่อทำให้ขั้นตอนการลบเป็นอิสระจากธีมเริ่มต้น ตัวอย่างจะสร้างการแมปธานาเฉพาะเมื่อยังไม่มีการกำหนดไว้

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

การตรวจสอบใช้พฤติกรรม `null` เช่นเดียวกับการค้นหาแบบทั่วไป: หลังจากบันทึกการลบ `getScriptFont("Thaa")` จะคืนค่า `null` สำหรับคอลเลกชันรอง

## **แยกแยะการแมปธีมจากการตั้งค่าอื่นของฟอนต์**

การแมปธีมที่เฉพาะเจาะจงสคริปต์มีส่วนร่วมในการเลือกฟอนต์ แต่พวกมันแก้ปัญหาอื่นจากการจัดรูปแบบข้อความโดยตรง การแทนที่ และการสำรอง:

| กลไก | จุดประสงค์ | ผลของการเปลี่ยนการแมปธีม |
|---|---|---|
| การแมปฟอนต์ธีมที่เฉพาะเจาะจงสคริปต์ | เลือกฟอนต์ธีมหลักหรือรองสำหรับระบบการเขียน | ข้อความที่ยังคงใช้ฟอนต์ธีมที่สอดคล้องสามารถแก้ไขเป็นตระกูลฟอนต์ที่ใหม่ที่แมปไว้ |
| ฟอนต์ที่กำหนดให้ส่วนข้อความโดยชัดเจน | กำหนดฟอนต์ตระกูลที่ต้องการบนส่วนนั้นแทนการพึ่งพาธีม | ส่วนนั้นอาจคงที่ไม่เปลี่ยนแปลงเพราะการจัดรูปแบบโดยตรงเหนือการเลือกธีม |
| การแทนที่ฟอนต์ | แทนที่ฟอนต์ที่ร้องขอเมื่อฟอนต์นั้นไม่มีหรือเมื่อมีกฎการแทนที่ | ทำงานหลังจากฟอนต์ถูกร้องขอ; ไม่ทำการกำหนดการแมปสคริปต์ของธีมใหม่ |
| การสำรองฟอนต์ | ให้ glyphs ที่ฟอนต์ที่เลือกไม่มี บ่อยครั้งสำหรับช่วง Unicode เฉพาะ | เติมการครอบคลุม glyph ที่ขาด; ไม่เปลี่ยนการแมปธีมที่เก็บไว้ |

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับกลไกสองสุดท้าย ดูที่ [Font Substitution](/slides/th/java/font-substitution/) และ [Fallback Fonts](/slides/th/java/fallback-font/).

การเปลี่ยนการแมปใน [Presentation.getMasterTheme](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getMasterTheme--) มีผลต่อเนื้อหาเท่านั้นที่รูปแบบมีประสิทธิภาพยังคงพึ่งพาธีมนั้น ข้อความอาจสืบทอดการบังคับธีมจากมาสเตอร์, layout หรือสไลด์, หรือใช้ฟอนต์ที่กำหนดโดยชัดเจน ให้ตรวจสอบระดับเหล่านั้นเมื่อผลลัพธ์ที่มองเห็นไม่ได้ตามการแมประดับการนำเสนอ

## **ทำให้ฟอนต์ที่แมปพร้อมใช้งานและตรวจสอบผลลัพธ์**

การแมปสคริปต์เก็บชื่อฟอนต์ตระกูล; ไม่ได้ติดตั้งหรือโหลดไฟล์ฟอนต์ที่สอดคล้องกัน เพื่อให้การเรนเดอร์และการส่งออกสอดคล้อง ทุกฟอนต์ที่แมปต้องติดตั้งในสภาพแวดล้อมหรือจัดหาให้กับ Aspose.Slides ผ่านแหล่งกำเนิดแบบกำหนดเองเช่น [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) หรือ [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--) . ดูที่ [Custom Fonts](/slides/th/java/custom-font/) สำหรับตัวเลือกการโหลดที่มี

การตรวจสอบการแมปที่บันทึกไว้ยืนยันเพียงว่าการกำหนดธีมยังคงอยู่ ไม่ได้พิสูจน์ว่าฟอนต์พร้อมใช้งาน มี glyph ที่ต้องการทั้งหมด หรือให้การจัดวางตามที่ตั้งใจ เรนเดอร์ข้อความตัวอย่างสำหรับทุกระบบการเขียนที่ต้องการเป็นภาพหรือ PDF แล้วตรวจสอบผลลัพธ์ สิ่งนี้จะจับฟอนต์ที่หายไป, การครอบคลุม glyph ที่ไม่สมบูรณ์, พฤติกรรม fallback, และการเปลี่ยนแปลง layout ก่อนที่การนำเสนอจะเผยแพร่ ดูที่ [Convert PowerPoint Presentations](/slides/th/java/convert-powerpoint/) สำหรับตัวอย่างการเรนเดอร์และส่งออก

## **คำถามที่พบบ่อย**

**`getScriptFont` คืนค่าอะไรเมื่อสคริปต์ไม่ได้รับการแมป?**

`[IFonts.getScriptFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-)` คืนค่า `null` เมื่อการแมปสคริปต์ที่ร้องขอไม่ได้กำหนดในคอลเลกชันฟอนต์หลักหรือรองนั้น

**`setScriptFont` เพิ่มการแมปที่สองเมื่อสคริปต์มีอยู่แล้วหรือไม่?**

ไม่มี. `[IFonts.setScriptFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-)` สร้างการแมปเมื่อไม่มีและแทนที่ฟอนต์ตระกูลที่แมปไว้เมื่อแท็กสคริปต์เดียวกันมีอยู่แล้ว

**ทำไมการเปลี่ยนการแมปธีมไม่ทำให้ข้อความบางส่วนเปลี่ยน?**

ข้อความอาจมีฟอนต์ที่กำหนดโดยชัดเจน, สืบทอดธีมที่แตกต่างผ่านการบังคับทับ, หรือได้รับผลจากการแทนที่หรือ fallback ขณะเรนเดอร์ การแมปสคริปต์ระดับการนำเสนอควบคุมเฉพาะข้อความที่รูปแบบมีประสิทธิภาพยังคงอ้างอิงคอลเลกชันฟอนต์ของธีมนั้น

**การบันทึกและเปิดใหม่เพียงพอที่จะตรวจสอบผลลัพธ์หลายภาษาไหม?**

ไม่มี. การเปิดใหม่ตรวจสอบการคงอยู่ของข้อมูลธีมเท่านั้น นอกจากนี้ต้องเรนเดอร์ข้อความตัวอย่างจากแต่ละระบบการเขียนที่ต้องการเพื่อยืนยันว่าฟอนต์ที่แมปพร้อมใช้งานและมี glyph ที่จำเป็น