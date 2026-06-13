---
title: ระบุแบบอักษรสำรองสำหรับการนำเสนอใน JavaScript
linktitle: แบบอักษรสำรอง
type: docs
weight: 10
url: /th/nodejs-java/create-fallback-font/
keywords:
- แบบอักษรสำรอง
- กฎแบบอักษรสำรอง
- ใช้แบบอักษร
- แทนที่แบบอักษร
- ช่วง Unicode
- glyph ที่หายไป
- glyph ที่ถูกต้อง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้การใช้ Aspose.Slides สำหรับ Node.js เพื่อกำหนดแบบอักษรสำรองในไฟล์ PPT, PPTX และ ODP ด้วย JavaScript ให้ข้อความแสดงอย่างสม่ำเสมอบนอุปกรณ์หรือระบบปฏิบัติการใดก็ได้"
---
## **ภาพรวม**

Aspose.Slides ให้คุณกำหนดแบบอักษรสำรองสำหรับการเรนเดอร์และการส่งออกการนำเสนอ แบบอักษรสำรองจะถูกใช้เมื่อแบบอักษรหลักไม่มี glyph สำหรับอักขระบางตัว

พฤติกรรมของแบบอักษรสำรองกำหนดค่าได้ผ่านกฎสำรอง แต่ละกฎเชื่อมโยงช่วง Unicode กับแบบอักษรหนึ่งแบบหรือหลายแบบที่อาจมี glyph ที่ต้องการ คุณสามารถกำหนดกฎสำหรับช่วงอักขระต่าง ๆ เพิ่มหรือเอาแบบอักษรสำรองออกจากกฎที่มีอยู่ และจัดระเบียบหลายกฎในคอลเลกชันกฎแบบอักษรสำรอง

กฎแบบอักษรสำรองเป็นการตั้งค่าการเรนเดอร์ขณะรัน พวกมันไม่ได้แก้ไขไฟล์การนำเสนอเองและไม่ได้ถูกเก็บไว้ภายในไฟล์ PPTX

## **กฎแบบอักษรสำรอง**

Aspose.Slides รองรับคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontFallBackRule) เพื่อระบุกฎการใช้แบบอักษรสำรอง คลาส [FontFallBackRule](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontFallBackRule) แสดงความสัมพันธ์ระหว่างช่วง Unicode ที่ระบุซึ่งใช้ในการค้นหา glyph ที่ขาดหาย และรายการแบบอักษรที่อาจมี glyph ที่เหมาะสม:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// โดยใช้หลายวิธีคุณสามารถเพิ่มรายการแบบอักษรได้:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segue UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

คุณยังสามารถ [remove](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) แบบอักษรสำรอง หรือ [addFallBackFonts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) เข้าในอ็อบเจ็กต์ [FontFallBackRule](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontFallBackRule) ที่มีอยู่ได้

[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontFallBackRulesCollection) สามารถใช้เพื่อจัดระเบียบรายการของอ็อบเจ็กต์ [FontFallBackRule](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FontFallBackRule) เมื่อจำเป็นต้องระบุกฎการเปลี่ยนแบบอักษรสำรองสำหรับหลายช่วง Unicode

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [สร้างคอลเลกชันแบบอักษรสำรอง](/slides/th/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างแบบอักษรสำรอง, การแทนที่แบบอักษร, และการฝังแบบอักษรคืออะไร?**

แบบอักษรสำรองจะใช้เฉพาะกับอักขระที่หายไปในแบบอักษรหลักเท่านั้น [Font substitution](/slides/th/nodejs-java/font-substitution/) จะเปลี่ยนแบบอักษรที่ระบุทั้งหมดเป็นแบบอักษรอื่น [Font embedding](/slides/th/nodejs-java/embedded-font/) จะบรรจุแบบอักษรไว้ในไฟล์ผลลัพธ์ เพื่อให้ผู้รับสามารถดูข้อความตามที่ตั้งใจได้

**แบบอักษรสำรองจะถูกนำไปใช้ระหว่างการส่งออกเช่น PDF, PNG, หรือ SVG หรือเฉพาะการเรนเดอร์บนหน้าจอเท่านั้น?**

ใช่. แบบอักษรสำรองมีผลต่อทุก [rendering and export operations](/slides/th/nodejs-java/convert-presentation/) ที่ต้องวาดอักขระแต่แบบอักษรต้นทางไม่มี

**การกำหนดค่าแบบอักษรสำรองจะเปลี่ยนไฟล์การนำเสนอเองหรือไม่ และการตั้งค่านี้จะคงอยู่เมื่อตัวไฟล์ถูกเปิดในครั้งต่อไปหรือไม่?**

ไม่. กฎแบบอักษรสำรองเป็นการตั้งค่าการเรนเดอร์ขณะรันในโค้ดของคุณ; พวกมันไม่ได้ถูกเก็บไว้ในไฟล์ .pptx และจะไม่ปรากฏใน PowerPoint

**ระบบปฏิบัติการ (Windows/Linux/macOS) และชุดไดเรกทอรีแบบอักษรมีผลต่อการเลือกแบบอักษรสำรองหรือไม่?**

ใช่. เครื่องมือจะค้นหาแบบอักษรจากโฟลเดอร์ระบบที่มีและจาก [additional paths](/slides/th/nodejs-java/custom-font/) ที่คุณระบุ หากแบบอักษรไม่มีอยู่จริง กฎที่อ้างอิงถึงมันจะไม่ทำงาน

**แบบอักษรสำรองทำงานกับ WordArt, SmartArt และแผนภูมิหรือไม่?**

ใช่. เมื่อวัตถุเหล่านี้มีข้อความ กลไกการแทนที่ glyph เดียวกันจะถูกนำมาใช้เพื่อเรนเดอร์อักขระที่หายไป