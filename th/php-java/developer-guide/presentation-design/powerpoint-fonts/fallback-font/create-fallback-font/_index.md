---
title: ระบุฟอนต์สำรองสำหรับงานนำเสนอใน PHP
linktitle: ฟอนต์สำรอง
type: docs
weight: 10
url: /th/php-java/create-fallback-font/
keywords:
- ฟอนต์สำรอง
- กฎฟอนต์สำรอง
- ใช้ฟอนต์
- แทนที่ฟอนต์
- ช่วง Unicode
- glyph ที่หาย
- glyph ที่เหมาะสม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เชี่ยวชาญ Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อกำหนดฟอนต์สำรองในไฟล์ PPT, PPTX และ ODP, เพื่อให้การแสดงผลข้อความสม่ำเสมอบนอุปกรณ์หรือระบบปฏิบัติการใดก็ได้"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณระบุฟอนต์สำรองสำหรับการเรนเดอร์และการส่งออกงานนำเสนอ ฟอนต์สำรองจะถูกใช้เมื่อฟอนต์หลักไม่มี glyph สำหรับอักขระบางตัว

พฤติกรรมฟอนต์สำรองถูกกำหนดผ่านกฎฟอนต์สำรอง แต่ละกฎจะเชื่อมโยงช่วง Unicode กับฟอนต์หนึ่งหรือหลายตัวที่อาจมี glyph ที่ต้องการ คุณสามารถกำหนดกฎสำหรับช่วงอักขระต่าง ๆ เพิ่มหรือถอนฟอนต์สำรองจากกฎที่มีอยู่ และจัดระเบียบหลายกฎในคอลเลกชันกฎฟอนต์สำรอง

กฎฟอนต์สำรองเป็นการตั้งค่าเรนเดอร์ในเวลารันไทม์ ไม่ได้แก้ไขไฟล์งานนำเสนอเองและไม่ได้ถูกจัดเก็บภายในไฟล์ PPTX

## **กฎฟอนต์สำรอง**

Aspose.Slides รองรับคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontFallBackRule) เพื่อระบุกฎการใช้ฟอนต์สำรอง คลาส [FontFallBackRule](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontFallBackRule) แสดงความสัมพันธ์ระหว่างช่วง Unicode ที่กำหนดใช้ในการค้นหา glyph ที่หายไป กับรายการฟอนต์ที่อาจมี glyph ที่เหมาะสม:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # โดยใช้หลายวิธีคุณสามารถเพิ่มรายการฟอนต์ได้:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

นอกจากนี้ยังสามารถ [remove](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontfallbackrule/remove/) ฟอนต์สำรองหรือ [addFallBackFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) เข้าไปในวัตถุ [FontFallBackRule](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontFallBackRule) ที่มีอยู่ได้

[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontFallBackRulesCollection) สามารถใช้เพื่อจัดระเบียบรายการของวัตถุ [FontFallBackRule](https://reference.aspose.com/slides/th/php-java/aspose.slides/FontFallBackRule) เมื่อจำเป็นต้องระบุกฎการแทนที่ฟอนต์สำรองสำหรับหลายช่วง Unicode

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/th/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฟอนต์สำรอง, การทดแทนฟอนต์, และการฝังฟอนต์ มีความแตกต่างกันอย่างไร?**

ฟอนต์สำรองจะใช้เฉพาะกับอักขระที่หายไปในฟอนต์หลักเท่านั้น [การทดแทนฟอนต์](/slides/th/php-java/font-substitution/) จะเปลี่ยนฟอนต์ที่ระบุทั้งหมดเป็นฟอนต์อื่น [การฝังฟอนต์](/slides/th/php-java/embedded-font/) จัดเก็บฟอนต์ไว้ภายในไฟล์ผลลัพธ์เพื่อให้ผู้รับสามารถดูข้อความตามที่ตั้งใจได้

**ฟอนต์สำรองถูกใช้ระหว่างการส่งออกเป็น PDF, PNG หรือ SVG หรือใช้เฉพาะการเรนเดอร์บนหน้าจอเท่านั้น?**

ใช่. ฟอนต์สำรองมีผลต่อทุกการ[เรนเดอร์และการส่งออก](/slides/th/php-java/convert-presentation/) ที่ต้องวาดอักขระแต่ฟอนต์ต้นทางไม่มีอักขระนั้น

**การกำหนดค่าฟอนต์สำรองจะเปลี่ยนแปลงไฟล์งานนำเสนอเองหรือไม่ และการตั้งค่าจะคงอยู่ในการเปิดครั้งต่อไปหรือไม่?**

ไม่. กฎฟอนต์สำรองเป็นการตั้งค่าเรนเดอร์ในเวลารันไทม์ในโค้ดของคุณ ไม่ได้ถูกจัดเก็บภายในไฟล์ .pptx และจะไม่ปรากฏใน PowerPoint

**ระบบปฏิบัติการ (Windows/Linux/macOS) และชุดโฟลเดอร์ฟอนต์มีผลต่อการเลือกฟอนต์สำรองหรือไม่?**

ใช่. เอนจินจะค้นหาฟอนต์จากโฟลเดอร์ระบบที่มีอยู่และ[เส้นทางเพิ่มเติม](/slides/th/php-java/custom-font/)ที่คุณระบุ หากฟอนต์ไม่มีอยู่จริง กฎที่อ้างอิงฟอนต์นั้นจะไม่ทำงาน

**ฟอนต์สำรองทำงานกับ WordArt, SmartArt และแผนภูมิหรือไม่?**

ใช่. เมื่อวัตถุเหล่านี้มีข้อความเดียวกัน กลไกการแทนที่ glyph จะทำงานเพื่อเรนเดอร์อักขระที่หายไป