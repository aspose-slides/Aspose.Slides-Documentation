---
title: ระบุแบบอักษรสำรองสำหรับงานนำเสนอใน C++
linktitle: แบบอักษรสำรอง
type: docs
weight: 10
url: /th/cpp/create-fallback-font/
keywords:
- แบบอักษรสำรอง
- กฎสำรอง
- ใช้แบบอักษร
- แทนที่แบบอักษร
- ช่วง Unicode
- glyph ที่ขาดหาย
- glyph ที่เหมาะสม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เชี่ยวชาญ Aspose.Slides สำหรับ C++ เพื่อกำหนดแบบอักษรสำรองในไฟล์ PPT, PPTX และ ODP, เพื่อรักษาการแสดงข้อความที่สอดคล้องบนอุปกรณ์หรือระบบปฏิบัติการใด ๆ"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณกำหนดแบบอักษรสำรองสำหรับการเรนเดอร์และการส่งออกงานพรีเซนเทชัน แบบอักษรสำรองจะใช้เมื่อแบบอักษรหลักไม่มี glyph สำหรับอักขระบางตัว

พฤติกรรมสำรองถูกกำหนดผ่านกฎสำรอง แต่ละกฎเชื่อมช่วง Unicode กับแบบอักษรหนึ่งหรือหลายแบบที่อาจมี glyph ที่ต้องการ คุณสามารถกำหนดกฎสำหรับช่วงอักขระต่าง ๆ เพิ่มหรือเอาแบบอักษรสำรองออกจากกฎที่มีอยู่ และจัดระเบียบหลายกฎในคอลเลกชันกฎแบบอักษรสำรอง

กฎสำรองเป็นการตั้งค่าการเรนเดอร์ขณะทำงาน พวกมันไม่ได้แก้ไขไฟล์พรีเซนเทชันเองและไม่ถูกเก็บไว้ภายในไฟล์ PPTX

## **กฎการสำรองแบบอักษร**

Aspose.Slides รองรับอินเทอร์เฟซ [IFontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontfallbackrule/) และคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) เพื่อระบุกฎที่ใช้แบบอักษรสำรอง คลาส [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) แสดงการเชื่อมโยงระหว่างช่วง Unicode ที่ระบุซึ่งใช้ค้นหา glyph ที่ขาดหายไป กับรายการแบบอักษรที่อาจมี glyph ที่เหมาะสม:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

//โดยใช้หลายวิธีคุณสามารถเพิ่มรายการแบบอักษรได้:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

คุณยังสามารถ [Remove()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontfallbackrule/remove/) แบบอักษรสำรองหรือ [AddFallBackFonts()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) เข้าไปในวัตถุ [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) ที่มีอยู่ได้

[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrulescollection/) สามารถใช้เพื่อจัดระเบียบรายการของวัตถุ [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) เมื่อจำเป็นต้องกำหนดกฎการแทนที่แบบอักษรสำรองสำหรับหลายช่วง Unicode

{{% alert color="primary" title="See also" %}} 
- [สร้างคอลเลกชันแบบอักษรสำรอง](/slides/th/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**แบบอักษรสำรอง, การแทนที่แบบอักษร, และการฝังแบบอักษร มีความแตกต่างกันอย่างไร?**

แบบอักษรสำรองจะใช้เฉพาะสำหรับอักขระที่หายไปในแบบอักษรหลักการ [การแทนที่แบบอักษร](/slides/th/cpp/font-substitution/) จะเปลี่ยนแบบอักษรที่ระบุทั้งหมดเป็นแบบอักษรอื่น การ [การฝังแบบอักษร](/slides/th/cpp/embedded-font/) จะบรรจุแบบอักษรไว้ในไฟล์ผลลัพธ์เพื่อให้ผู้รับสามารถดูข้อความได้ตามที่ตั้งใจ

**แบบอักษรสำรองจะถูกใช้ในการส่งออกเช่น PDF, PNG หรือ SVG หรือใช้เฉพาะในการเรนเดอร์บนหน้าจอหรือไม่?**

ใช่ แบบอักษรสำรองมีผลต่อการ [การเรนเดอร์และการส่งออก](/slides/th/cpp/convert-presentation/) ทั้งหมดที่ต้องวาดอักขระแต่ไม่มีในแบบอักษรต้นทาง

**การกำหนดค่าแบบอักษรสำรองจะเปลี่ยนไฟล์พรีเซนเทชันเองหรือไม่ และการตั้งค่าจะคงอยู่เมื่อเปิดไฟล์ในครั้งต่อไปหรือไม่?**

ไม่ กฎสำรองเป็นการตั้งค่าการเรนเดอร์ขณะทำงานในโค้ดของคุณ พวกมันไม่ถูกเก็บไว้ในไฟล์ .pptx และจะไม่ปรากฏใน PowerPoint

**ระบบปฏิบัติการ (Windows/Linux/macOS) และชุดโฟลเดอร์แบบอักษรมีผลต่อการเลือกแบบอักษรสำรองหรือไม่?**

ใช่ เอนจินจะค้นหาแบบอักษรจากโฟลเดอร์ระบบที่มีอยู่และจาก [เส้นทางเพิ่มเติม](/slides/th/cpp/custom-font/) ที่คุณระบุ หากแบบอักษรไม่มีอยู่จริง กฎที่อ้างอิงถึงแบบอักษรนั้นจะไม่ทำงาน

**การสำรองแบบอักษรทำงานกับ WordArt, SmartArt และแผนภูมิหรือไม่?**

ใช่ เมื่อวัตถุเหล่านี้มีข้อความ กลไกการแทนที่ glyph เดียวกันจะถูกใช้เพื่อเรนเดอร์อักขระที่หายไป