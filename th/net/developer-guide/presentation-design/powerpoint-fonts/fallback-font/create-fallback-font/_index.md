---
title: ระบุแบบอักษรสำรองสำหรับพรีเซนเทชันใน .NET
linktitle: แบบอักษรสำรอง
type: docs
weight: 10
url: /th/net/create-fallback-font/
keywords:
- แบบอักษรสำรอง
- กฎสำรอง
- ใช้แบบอักษร
- แทนที่แบบอักษร
- ช่วง Unicode
- glyph ที่ขาดหาย
- glyph ที่ถูกต้อง
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "ควบคุม Aspose.Slides สำหรับ .NET เพื่อกำหนดแบบอักษรสำรองในไฟล์ PPT, PPTX และ ODP ทำให้การแสดงผลข้อความคงที่บนอุปกรณ์หรือระบบปฏิบัติการใดก็ได้"
---
## **ภาพรวม**

Aspose.Slides ให้คุณระบุแบบอักษรสำรองสำหรับการแสดงผลและการส่งออกงานพรีเซนเทชัน แบบอักษรสำรองจะถูกใช้เมื่อแบบอักษรหลักไม่มี glyph สำหรับอักขระบางตัว

พฤติกรรมการสำรองกำหนดผ่านกฎสำรอง แต่ละกฎเชื่อมช่วง Unicode กับหนึ่งหรือหลายแบบอักษรที่อาจมี glyph ที่ต้องการ คุณสามารถกำหนดกฎสำหรับช่วงอักขระต่าง ๆ เพิ่มหรือลบแบบอักษรสำรองจากกฎที่มีอยู่ และจัดระเบียบหลายกฎในคอลเลกชันกฎแบบอักษรสำรอง

กฎสำรองเป็นการตั้งค่าการแสดงผลที่ทำงานขณะที่รัน ไม่ได้แก้ไขไฟล์พรีเซนเทชันเองและไม่ได้ถูกเก็บไว้ในไฟล์ PPTX

## **กฎสำรอง**

Aspose.Slides รองรับอินเตอร์เฟซ [IFontFallBackRule](https://reference.aspose.com/slides/th/net/aspose.slides/iFontFallBackRule) และคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/net/aspose.slides/FontFallBackRule) เพื่อระบุกฎการใช้แบบอักษรสำรอง คลาส [FontFallBackRule](https://reference.aspose.com/slides/th/net/aspose.slides/FontFallBackRule) แสดงความสัมพันธ์ระหว่างช่วง Unicode ที่ระบุ ใช้สำหรับค้นหา glyph ที่ขาดหาย กับรายการแบบอักษรที่อาจมี glyph ที่เหมาะสม:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//โดยใช้หลายวิธีคุณสามารถเพิ่มรายการแบบอักษร:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

คุณยังสามารถ [Remove()](https://reference.aspose.com/slides/th/net/aspose.slides/ifontfallbackrule/methods/remove) แบบอักษรสำรองหรือ [AddFallBackFonts()](https://reference.aspose.com/slides/th/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) ไปยังอ็อบเจกต์ [FontFallBackRule](https://reference.aspose.com/slides/th/net/aspose.slides/FontFallBackRule) ที่มีอยู่ได้

[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/th/net/aspose.slides/fontfallbackrulescollection)สามารถใช้เพื่อจัดระเบียบรายการอ็อบเจกต์ [FontFallBackRule](https://reference.aspose.com/slides/th/net/aspose.slides/FontFallBackRule) เมื่อจำเป็นต้องระบุกฎการแทนที่แบบอักษรสำรองสำหรับหลายช่วง Unicode

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [Create Fallback Fonts Collection](/slides/th/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างแบบอักษรสำรอง การแทนที่แบบอักษร และการฝังแบบอักษรคืออะไร?**

แบบอักษรสำรองจะใช้เฉพาะกับอักขระที่ไม่มีในแบบอักษรหลัก [การแทนที่แบบอักษร](/slides/th/net/font-substitution/) จะเปลี่ยนแบบอักษรที่ระบุทั้งหมดเป็นแบบอักษรอื่น [การฝังแบบอักษร](/slides/th/net/embedded-font/) จะบรรจุแบบอักษรภายในไฟล์ผลลัพธ์เพื่อให้ผู้รับสามารถดูข้อความตามที่ตั้งใจได้

**แบบอักษรสำรองถูกนำไปใช้ในการส่งออกเช่น PDF, PNG หรือ SVG หรือใช้เฉพาะการแสดงผลบนหน้าจอเท่านั้น?**

ใช่. การสำรองมีผลต่อทุก [การแสดงผลและการส่งออก](/slides/th/net/convert-presentation/) ที่ต้องวาดอักขระแต่ไม่มีในแบบอักษรต้นทาง

**การกำหนดค่าแบบอักษรสำรองทำให้ไฟล์พรีเซนเทชันเปลี่ยนแปลงหรือไม่ และการตั้งค่านี้จะคงอยู่ในการเปิดครั้งต่อไปหรือไม่?**

ไม่. กฎสำรองเป็นการตั้งค่าการแสดงผลที่ทำงานขณะที่รันในโค้ดของคุณ; ไม่ได้ถูกเก็บไว้ภายใน .pptx และจะไม่ปรากฏใน PowerPoint

**ระบบปฏิบัติการ (Windows/Linux/macOS) และชุดโฟลเดอร์แบบอักษรมีผลต่อการเลือกแบบอักษรสำรองหรือไม่?**

ใช่. เอนจิ้นจะค้นหาแบบอักษรจากโฟลเดอร์ระบบที่มีอยู่และจาก [เส้นทางเพิ่มเติม](/slides/th/net/custom-font/) ที่คุณระบุ หากแบบอักษรไม่มีอยู่จริง กฎที่อ้างอิงไปยังแบบอักษรนั้นจะไม่มีผล

**แบบอักษรสำรองทำงานกับ WordArt, SmartArt และแผนภูมิหรือไม่?**

ใช่. เมื่อวัตถุเหล่านี้มีข้อความ กลไกการแทนที่ glyph เดียวกันจะถูกใช้เพื่อแสดงอักขระที่ขาดหาย