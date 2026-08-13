---
title: ระบุฟอนต์สำรองสำหรับการนำเสนอใน Java
linktitle: ฟอนต์สำรอง
type: docs
weight: 10
url: /th/java/create-fallback-font/
keywords:
- ฟอนต์สำรอง
- กฎฟอนต์สำรอง
- ใช้ฟอนต์
- แทนที่ฟอนต์
- ช่วง Unicode
- glyph ที่ขาดหาย
- glyph ที่เหมาะสม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ใช้ Aspose.Slides สำหรับ Java เพื่อกำหนดฟอนต์สำรองในไฟล์ PPT, PPTX และ ODP, ทำให้การแสดงข้อความคงที่บนอุปกรณ์หรือระบบปฏิบัติการใดก็ได้"
---
## **ภาพรวม**

Aspose.Slides ให้คุณระบุฟอนต์สำรองสำหรับการเรนเดอร์และการส่งออกงานนำเสนอ ฟอนต์สำรองจะถูกใช้เมื่อฟอนต์หลักไม่มี glyph สำหรับอักขระบางตัว

พฤติกรรมฟอนต์สำรองถูกกำหนดผ่านกฎฟอนต์สำรอง แต่ละกฎจะเชื่อมต่อช่วง Unicode กับฟอนต์หนึ่งหรือหลายตัวที่อาจมี glyph ที่ต้องการ คุณสามารถกำหนดกฎสำหรับช่วงอักขระต่างๆ เพิ่มหรือเอาฟอนต์สำรองออกจากกฎที่มีอยู่ และจัดระเบียบหลายกฎในคอลเลกชันกฎฟอนต์สำรอง

กฎฟอนต์สำรองเป็นการตั้งค่าการเรนเดอร์ขณะรัน พวกมันไม่ได้แก้ไขไฟล์งานนำเสนอเองและไม่ได้ถูกจัดเก็บภายในไฟล์ PPTX

## **กฎฟอนต์สำรอง**

Aspose.Slides รองรับอินเทอร์เฟซ [IFontFallBackRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/IFontFallBackRule) และคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule) เพื่อระบุกฎการใช้ฟอนต์สำรอง คลาส [FontFallBackRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule) แทนความสัมพันธ์ระหว่างช่วง Unicode ที่กำหนด ใช้สำหรับค้นหา glyph ที่ขาดหาย และรายการฟอนต์ที่อาจมี glyph ที่เหมาะสม:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

คุณยังสามารถ [remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) ฟอนต์สำรองหรือ [addFallBackFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ลงในอ็อบเจ็กต์ [FontFallBackRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule) ที่มีอยู่

[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRulesCollection) สามารถใช้จัดระเบียบรายการอ็อบเจ็กต์ [FontFallBackRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule) ได้เมื่อจำเป็นต้องระบุกฎการแทนที่ฟอนต์สำรองสำหรับหลายช่วง Unicode

{{% alert color="info" title="ดูเพิ่มเติม" %}} 
- [Create Fallback Fonts Collection](/slides/th/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ความแตกต่างระหว่างฟอนต์สำรอง, การแทนที่ฟอนต์, และการฝังฟอนต์คืออะไร?

ฟอนต์สำรองจะใช้เฉพาะกับอักขระที่หายไปในฟอนต์หลัก [Font substitution](/slides/th/java/font-substitution/) แทนที่ฟอนต์ที่ระบุทั้งหมดด้วยฟอนต์อื่น [Font embedding](/slides/th/java/embedded-font/) จะบรรจุฟอนต์ภายในไฟล์ผลลัพธ์เพื่อให้ผู้รับสามารถดูข้อความได้ตามที่ต้องการ

### ฟอนต์สำรองถูกนำไปใช้ระหว่างการส่งออกเช่น PDF, PNG, หรือ SVG หรือใช้เฉพาะการแสดงผลบนหน้าจอเท่านั้น?

ใช่ ฟอนต์สำรองมีผลต่อทุก [rendering and export operations](/slides/th/java/convert-presentation/) ที่ต้องวาดอักขระแต่ฟอนต์ต้นทางไม่มี

### การกำหนดค่าฟอนต์สำรองทำให้ไฟล์งานนำเสนอเปลี่ยนแปลงหรือไม่ และการตั้งค่านั้นจะคงอยู่เมือเปิดไฟล์ในครั้งต่อไปหรือไม่?

ไม่ กฎฟอนต์สำรองเป็นการตั้งค่าการเรนเดอร์ขณะรันในโค้ดของคุณ ไม่ได้ถูกเก็บภายในไฟล์ .pptx และจะไม่ปรากฏใน PowerPoint

### ระบบปฏิบัติการ (Windows/Linux/macOS) และชุดโฟลเดอร์ฟอนต์มีผลต่อการเลือกฟอนต์สำรองหรือไม่?

ใช่ เอนจินจะค้นหาฟอนต์จากโฟลเดอร์ระบบที่มีอยู่และ [additional paths](/slides/th/java/custom-font/) ที่คุณระบุ หากฟอนต์ไม่มีอยู่จริง กฎที่อ้างอิงฟอนต์นั้นจะไม่ทำงาน

### ฟอนต์สำรองทำงานกับ WordArt, SmartArt และแผนภูมิหรือไม่?

ใช่ เมื่อวัตถุเหล่านี้มีข้อความ กลไกการแทนที่ glyph เดียวกันจะถูกใช้เพื่อเรนเดอร์อักขระที่ขาดหาย