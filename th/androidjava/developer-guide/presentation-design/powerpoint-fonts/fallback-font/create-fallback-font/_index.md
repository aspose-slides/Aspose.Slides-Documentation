---
title: ระบุฟอนต์สำรองสำหรับงานนำเสนอบน Android
linktitle: ฟอนต์สำรอง
type: docs
weight: 10
url: /th/androidjava/create-fallback-font/
keywords:
- ฟอนต์สำรอง
- กฎฟอนต์สำรอง
- ใช้ฟอนต์
- แทนที่ฟอนต์
- ช่วง Unicode
- glyph ที่หายไป
- glyph ที่เหมาะสม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เชี่ยวชาญ Aspose.Slides สำหรับ Android ด้วย Java เพื่อกำหนดฟอนต์สำรองในไฟล์ PPT, PPTX และ ODP, เพื่อรับประกันการแสดงข้อความที่สม่ำเสมอบนอุปกรณ์หรือระบบปฏิบัติการใดๆ"
---
## **ภาพรวม**

Aspose.Slides ให้คุณกำหนดฟอนต์สำรองสำหรับการแสดงผลและการส่งออกงานนำเสนอ ฟอนต์สำรองจะถูกใช้เมื่อฟอนต์หลักไม่มี glyph สำหรับอักขระบางตัว

พฤติกรรมการสำรองถูกกำหนดผ่านกฎการสำรองแต่ละกฎเชื่อมช่วง Unicode กับหนึ่งหรือหลายฟอนต์ที่อาจมี glyph ที่ต้องการ คุณสามารถกำหนดกฎสำหรับช่วงอักขระต่าง ๆ เพิ่มหรือลบฟอนต์สำรองจากกฎที่มีอยู่ และจัดเรียงหลายกฎในคอลเลกชันกฎฟอนต์สำรอง

กฎการสำรองเป็นการตั้งค่าการเรนเดอร์ขณะทำงาน พวกมันไม่ได้แก้ไขไฟล์งานนำเสนอและไม่ได้ถูกจัดเก็บภายในไฟล์ PPTX

## **กฎการสำรอง**

Aspose.Slides รองรับอินเทอร์เฟซ [IFontFallBackRule](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IFontFallBackRule) และคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule) เพื่อระบุกฎที่ใช้ฟอนต์สำรอง คลาส [FontFallBackRule](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule) แทนความสัมพันธ์ระหว่างช่วง Unicode ที่ระบุ ใช้ในการค้นหา glyph ที่หายไป และรายการฟอนต์ที่อาจมี glyph ที่เหมาะสม:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//ใช้หลายวิธีเพื่อเพิ่มรายการฟอนต์:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

นอกจากนี้ยังสามารถ [remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) ฟอนต์สำรองหรือ [addFallBackFonts](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) เข้าสู่วัตถุ [FontFallBackRule](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule) ที่มีอยู่ได้

[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRulesCollection) สามารถใช้เพื่อจัดระเบียบรายการของวัตถุ [FontFallBackRule](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FontFallBackRule) เมื่อจำเป็นต้องกำหนดกฎการแทนที่ฟอนต์สำรองสำหรับหลายช่วง Unicode

{{% alert color="info" title="ดูเพิ่มเติม" %}} 
- [สร้างคอลเลกชันฟอนต์สำรอง](/slides/th/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ความแตกต่างระหว่างฟอนต์สำรอง, การแทนที่ฟอนต์, และการฝังฟอนต์คืออะไร?

ฟอนต์สำรองจะใช้เฉพาะกับอักขระที่หายไปในฟอนต์หลัก [Font substitution](/slides/th/androidjava/font-substitution/) จะเปลี่ยนฟอนต์ที่ระบุทั้งหมดเป็นฟอนต์อื่น [Font embedding](/slides/th/androidjava/embedded-font/) จะบรรจุฟอนต์ไว้ในไฟล์ผลลัพธ์เพื่อให้ผู้รับสามารถดูข้อความได้ตามที่ตั้งใจ

### ฟอนต์สำรองจะถูกนำไปใช้ระหว่างการส่งออกเช่น PDF, PNG หรือ SVG หรือใช้เฉพาะการเรนเดอร์บนหน้าจอเท่านั้น?

ใช่ ฟอนต์สำรองมีผลต่อทุก [rendering and export operations](/slides/th/androidjava/convert-presentation/) ที่อักขระต้องถูกวาดแต่ไม่มีในฟอนต์ต้นทาง

### การกำหนดค่าฟอนต์สำรองจะทำให้ไฟล์งานนำเสนอเปลี่ยนแปลงหรือไม่ และการตั้งค่าจะคงอยู่ในการเปิดครั้งถัดไปหรือไม่?

ไม่ กฎการสำรองเป็นการตั้งค่าการเรนเดอร์ขณะทำงานในโค้ดของคุณ; พวกมันไม่ได้ถูกจัดเก็บในไฟล์ .pptx และจะไม่ปรากฏใน PowerPoint

### ระบบปฏิบัติการ (Windows/Linux/macOS) และชุดโฟลเดอร์ฟอนต์มีผลต่อการเลือกฟอนต์สำรองหรือไม่?

ใช่ เอนจินจะค้นหาฟอนต์จากโฟลเดอร์ระบบที่มีอยู่และจาก [additional paths](/slides/th/androidjava/custom-font/) ที่คุณระบุ หากฟอนต์ไม่มีจริง กฎที่อ้างอิงถึงฟอนต์นั้นจะไม่ทำงาน

### ฟอนต์สำรองทำงานกับ WordArt, SmartArt และแผนภูมิหรือไม่?

ใช่ เมื่อวัตถุเหล่านี้มีข้อความ กลไกการแทนที่ glyph เดียวกันจะถูกใช้เพื่อเรนเดอร์อักขระที่หายไป