---
title: กำหนดแบบอักษรสำรองสำหรับการนำเสนอใน Java
linktitle: แบบอักษรสำรอง
type: docs
weight: 10
url: /th/java/create-fallback-font/
keywords:
- แบบอักษรสำรอง
- กฎสำรอง
- ใช้แบบอักษร
- แทนที่แบบอักษร
- ช่วง Unicode
- glyph ที่หายไป
- glyph ที่ถูกต้อง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เชี่ยวชาญ Aspose.Slides for Java เพื่อกำหนดแบบอักษรสำรองในไฟล์ PPT, PPTX และ ODP, เพื่อรักษาการแสดงผลข้อความที่สอดคล้องบนอุปกรณ์หรือระบบปฏิบัติการใดก็ได้"
---
## **ภาพรวม**

Aspose.Slides ให้คุณกำหนดแบบอักษรสำรองสำหรับการแสดงผลและการส่งออกพรีเซนเทชันแบบอักษรสำรองจะถูกใช้เมื่อแบบอักษรหลักไม่มี glyph สำหรับอักขระบางตัว

พฤติกรรมการสำรองจะถูกกำหนดผ่านกฎสำรอง แต่ละกฎจะเชื่อมช่วง Unicode กับแบบอักษรหนึ่งหรือหลายแบบที่อาจมี glyph ที่ต้องการ คุณสามารถกำหนดกฎสำหรับช่วงอักขระต่าง ๆ เพิ่มหรือลบแบบอักษรสำรองจากกฎที่มีอยู่และจัดระเบียบบรรทัดหลายกฎในคอลเลกชันกฎแบบอักษรสำรอง

กฎสำรองเป็นการตั้งค่าการเรนเดอร์ระหว่างการทำงาน พวกมันไม่ได้แก้ไขไฟล์พรีเซนเทชันเองและไม่ได้ถูกจัดเก็บในไฟล์ PPTX

## **กฎการสำรอง**

Aspose.Slides รองรับอินเทอร์เฟซ [IFontFallBackRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/IFontFallBackRule) และคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule) เพื่อกำหนดกฎการใช้แบบอักษรสำรอง คลาส [FontFallBackRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule) แทนความสัมพันธ์ระหว่างช่วง Unicode ที่ระบุ (ใช้ในการค้นหา glyph ที่หายไป) กับรายการแบบอักษรที่อาจมี glyph ที่ถูกต้อง:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//โดยใช้หลายวิธีคุณสามารถเพิ่มรายการฟอนต์ได้:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

คุณยังสามารถ [remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) แบบอักษรสำรอง หรือ [addFallBackFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ลงในวัตถุ [FontFallBackRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule) ที่มีอยู่ได้

[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRulesCollection) สามารถใช้เพื่อจัดระเบียบบัญชีรายการของวัตถุ [FontFallBackRule](https://reference.aspose.com/slides/th/java/com.aspose.slides/FontFallBackRule) เมื่อจำเป็นต้องกำหนดกฎการแทนที่แบบอักษรสำรองสำหรับหลายช่วง Unicode

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [สร้างคอลเลกชันแบบอักษรสำรอง](/slides/th/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างแบบอักษรสำรอง การแทนที่แบบอักษร และการฝังแบบอักษรคืออะไร?**

แบบอักษรสำรองจะใช้เฉพาะกับอักขระที่หายไปในแบบอักษรหลักเท่านั้น [การแทนที่แบบอักษร](/slides/th/java/font-substitution/) จะเปลี่ยนแบบอักษรที่ระบุทั้งหมดเป็นแบบอักษรอื่น [การฝังแบบอักษร](/slides/th/java/embedded-font/) จะบรรจุแบบอักษรไว้ในไฟล์ผลลัพธ์เพื่อให้ผู้รับสามารถดูข้อความได้ตามที่ตั้งใจ

**แบบอักษรสำรองจะถูกนำไปใช้ระหว่างการส่งออกเช่น PDF, PNG หรือ SVG หรือเพียงการเรนเดอร์บนหน้าจอเท่านั้น?**

ใช่. การสำรองส่งผลต่อทุก [การเรนเดอร์และการส่งออก](/slides/th/java/convert-presentation/) ที่ต้องวาดอักขระแต่ไม่มีในแบบอักษรต้นฉบับ

**การกำหนดค่าแบบอักษรสำรองจะเปลี่ยนไฟล์พรีเซนเทชันเองหรือไม่ และการตั้งค่านั้นจะคงอยู่เมื่อเปิดไฟล์ในครั้งต่อไปหรือไม่?**

ไม่. กฎสำรองเป็นการตั้งค่าการเรนเดอร์ระหว่างรันไทม์ในโค้ดของคุณ; พวกมันไม่ได้ถูกเก็บไว้ในไฟล์ .pptx และจะไม่ปรากฏใน PowerPoint

**ระบบปฏิบัติการ (Windows/Linux/macOS) และชุดโฟลเดอร์แบบอักษรมีผลต่อการเลือกแบบอักษรสำรองหรือไม่?**

ใช่. เอนจินจะตรวจหาแบบอักษรจากโฟลเดอร์ระบบที่มีอยู่และ [เส้นทางเพิ่มเติม](/slides/th/java/custom-font/) ที่คุณระบุ หากแบบอักษรไม่มีอยู่จริง กฎที่อ้างอิงมันจะไม่ทำงาน

**การสำรองทำงานกับ WordArt, SmartArt และแผนภูมิหรือไม่?**

ใช่. เมื่อวัตถุเหล่านี้มีข้อความ กลไกการแทนที่ glyph เดียวกันจะถูกนำมาใช้เพื่อเรนเดอร์อักขระที่หายไป