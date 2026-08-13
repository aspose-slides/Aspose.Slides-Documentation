---
title: ระบุฟอนต์สำรองสำหรับงานนำเสนอใน .NET
linktitle: ฟอนต์สำรอง
type: docs
weight: 10
url: /th/net/create-fallback-font/
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
- .NET
- C#
- Aspose.Slides
description: "เชี่ยวชาญ Aspose.Slides สำหรับ .NET เพื่อกำหนดฟอนต์สำรองในไฟล์ PPT, PPTX และ ODP, เพื่อให้การแสดงผลข้อความสม่ำเสมอบนอุปกรณ์หรือระบบปฏิบัติการใดก็ได้"
---
## **ภาพรวม**

Aspose.Slides ให้คุณกำหนดฟอนต์สำรองสำหรับการเรนเดอร์และการส่งออกงานนำเสนอ ฟอนต์สำรองจะถูกใช้เมื่อฟอนต์หลักไม่มี glyph สำหรับอักขระบางตัว

พฤติกรรมฟอนต์สำรองถูกกำหนดผ่านกฎฟอนต์สำรอง แต่ละกฎจะจับคู่ช่วง Unicode กับหนึ่งหรือหลายฟอนต์ที่อาจมี glyph ที่ต้องการ คุณสามารถกำหนดกฎสำหรับช่วงอักขระต่าง ๆ เพิ่มหรือเอาฟอนต์สำรองออกจากกฎที่มีอยู่ และจัดระเบียบหลายกฎในคอลเลกชันกฎฟอนต์สำรองได้

กฎฟอนต์สำรองเป็นการตั้งค่าเรนเดอร์ขณะรัน ไม่ได้แก้ไขไฟล์งานนำเสนอเองและไม่ได้ถูกบันทึกภายในไฟล์ PPTX

## **กฎฟอนต์สำรอง**

Aspose.Slides รองรับอินเตอร์เฟส [IFontFallBackRule](https://reference.aspose.com/slides/th/net/aspose.slides/iFontFallBackRule) และคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/net/aspose.slides/FontFallBackRule) เพื่อกำหนดกฎการใช้ฟอนต์สำรอง คลาส [FontFallBackRule](https://reference.aspose.com/slides/th/net/aspose.slides/FontFallBackRule) แทนความสัมพันธ์ระหว่างช่วง Unicode ที่ระบุ (ใช้สำหรับค้นหา glyph ที่ขาด) กับรายการฟอนต์ที่อาจมี glyph ที่เหมาะสม:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//ใช้หลายวิธีเพื่อเพิ่มรายการฟอนต์:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

คุณยังสามารถใช้เมธอด [Remove()](https://reference.aspose.com/slides/th/net/aspose.slides/ifontfallbackrule/methods/remove) เพื่อลบฟอนต์สำรองหรือเมธอด [AddFallBackFonts()](https://reference.aspose.com/slides/th/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) เพื่อเพิ่มฟอนต์สำรองในวัตถุ [FontFallBackRule](https://reference.aspose.com/slides/th/net/aspose.slides/FontFallBackRule) ที่มีอยู่ได้

[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/th/net/aspose.slides/fontfallbackrulescollection)สามารถใช้จัดระเบียบรายการของวัตถุ [FontFallBackRule](https://reference.aspose.com/slides/th/net/aspose.slides/FontFallBackRule) เมื่อจำเป็นต้องกำหนดกฎการแทนที่ฟอนต์สำรองสำหรับหลายช่วง Unicode

{{% alert color="info" title="ดูเพิ่มเติม" %}} 
- [สร้างคอลเลกชันฟอนต์สำรอง](/slides/th/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ฟอนต์สำรอง, การแทนที่ฟอนต์ และการฝังฟอนต์ต่างกันอย่างไร?

ฟอนต์สำรองใช้เฉพาะกับอักขระที่หายไปในฟอนต์หลักเท่านั้น [การแทนที่ฟอนต์](/slides/th/net/font-substitution/) จะเปลี่ยนฟอนต์ที่ระบุทั้งหมดเป็นฟอนต์อื่น [การฝังฟอนต์](/slides/th/net/embedded-font/) จะบรรจุฟอนต์ไว้ในไฟล์ผลลัพธ์ เพื่อให้ผู้รับสามารถดูข้อความได้ตามที่ตั้งใจ

### ฟอนต์สำรองถูกนำไปใช้ในการส่งออกเช่น PDF, PNG หรือ SVG หรือเฉพาะการเรนเดอร์บนหน้าจอเท่านั้น?

ใช่ ฟอนต์สำรองส่งผลต่อทุก [การเรนเดอร์และการส่งออก](/slides/th/net/convert-presentation/) ที่ต้องวาดอักขระแต่ฟอนต์ต้นทางไม่มี

### การกำหนดค่าฟอนต์สำรองทำให้ไฟล์งานนำเสนอเปลี่ยนแปลงหรือไม่ และการตั้งค่าจะคงอยู่เมื่อตีเปิดไฟล์ครั้งถัดไปหรือไม่?

ไม่ กฎฟอนต์สำรองเป็นการตั้งค่าเรนเดอร์ขณะรันในโค้ดของคุณ; ไม่ได้ถูกบันทึกไว้ในไฟล์ .pptx และจะไม่ปรากฏใน PowerPoint

### ระบบปฏิบัติการ (Windows/Linux/macOS) และตำแหน่งโฟลเดอร์ฟอนต์มีผลต่อการเลือกฟอนต์สำรองหรือไม่?

ใช่ เอนจินจะค้นหาฟอนต์จากโฟลเดอร์ระบบที่มีอยู่และจาก [เส้นทางเพิ่มเติม](/slides/th/net/custom-font/) ที่คุณระบุ หากฟอนต์ไม่มีอยู่จริง กฎที่อ้างถึงฟอนต์นั้นจะไม่ได้ผล

### ฟอนต์สำรองทำงานกับ WordArt, SmartArt และแผนภูมิหรือไม่?

ใช่ เมื่อตัวเหล่านี้มีข้อความ กลไกการแทนที่ glyph จะทำงานเช่นเดียวกันเพื่อเรนเดอร์อักขระที่ขาดอยู่