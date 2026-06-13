---
title: ระบุแบบอักษรสำรองสำหรับการนำเสนอใน C++
linktitle: แบบอักษรสำรอง
type: docs
weight: 10
url: /th/cpp/create-fallback-font/
keywords:
- แบบอักษรสำรอง
- กฎการสำรอง
- ใช้แบบอักษร
- แทนที่แบบอักษร
- ช่วง Unicode
- glyph ที่หาย
- glyph ที่ถูกต้อง
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "เชี่ยวชาญ Aspose.Slides สำหรับ C++ เพื่อกำหนดแบบอักษรสำรองในไฟล์ PPT, PPTX และ ODP โดยรับประกันการแสดงผลข้อความที่สอดคล้องบนอุปกรณ์หรือระบบปฏิบัติการใด ๆ"
---
## **ภาพรวม**

Aspose.Slides ให้คุณระบุแบบอักษรสำรองสำหรับการเรนเดอร์และการส่งออกงานพรีเซนเทชัน แบบอักษรสำรองจะถูกใช้เมื่อแบบอักษรหลักไม่มี glyph สำหรับอักขระบางตัว

พฤติกรรมการสำรองจะถูกกำหนดผ่านกฎการสำรอง แต่ละกฎจะเชื่อมโยงช่วง Unicode กับแบบอักษรหนึ่งแบบหรือหลายแบบที่อาจมี glyph ที่ต้องการ คุณสามารถกำหนดกฎสำหรับช่วงอักขระต่าง ๆ เพิ่มหรือเอาแบบอักษรสำรองออกจากกฎที่มีอยู่ และจัดระเบียบหลายกฎในคอลเลกชันกฎแบบอักษรสำรอง

กฎการสำรองเป็นการตั้งค่าการเรนเดอร์ในขณะรันไทม์ ไม่ได้แก้ไขไฟล์พรีเซนเทชันเองและไม่ได้ถูกบันทึกภายในไฟล์ PPTX

## **กฎการสำรอง**

Aspose.Slides รองรับอินเทอร์เฟซ [IFontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontfallbackrule/) และคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) เพื่อระบุกฎที่ใช้แบบอักษรสำรอง คลาส [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) แสดงความสัมพันธ์ระหว่างช่วง Unicode ที่กำหนดใช้ในการค้นหา glyph ที่ขาดหายและรายการแบบอักษรที่อาจมี glyph ที่ถูกต้อง:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// ใช้วิธีหลายแบบเพื่อเพิ่มรายการแบบอักษร:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

คุณยังสามารถ [Remove()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontfallbackrule/remove/) แบบอักษรสำรองหรือ [AddFallBackFonts()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) เข้าไปในวัตถุ [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) ที่มีอยู่

[FontFallBackRulesCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrulescollection/) สามารถใช้เพื่อจัดระเบียบรายการของวัตถุ [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) เมื่อจำเป็นต้องระบุกฎการแทนที่แบบอักษรสำรองสำหรับหลายช่วง Unicode

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [สร้างคอลเลกชันแบบอักษรสำรอง](/slides/th/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**อะไรคือความแตกต่างระหว่างแบบอักษรสำรอง, การทดแทนแบบอักษร, และการฝังแบบอักษร?**

แบบอักษรสำรองจะใช้เฉพาะกับอักขระที่ขาดหายในแบบอักษรหลัก [การทดแทนแบบอักษร](/slides/th/cpp/font-substitution/) แทนที่แบบอักษรที่ระบุทั้งหมดด้วยแบบอักษรอื่น [การฝังแบบอักษร](/slides/th/cpp/embedded-font/) จะบรรจุแบบอักษรไว้ในไฟล์ผลลัพธ์เพื่อให้ผู้รับสามารถดูข้อความตามที่ตั้งใจได้

**แบบอักษรสำรองถูกใช้ในการส่งออกเช่น PDF, PNG หรือ SVG หรือใช้แค่การเรนเดอร์บนหน้าจอเท่านั้น?**

ใช่. การสำรองส่งผลต่อ [การเรนเดอร์และการส่งออก](/slides/th/cpp/convert-presentation/) ทั้งหมดที่ต้องวาดอักขระแต่ไม่มีในแบบอักษรต้นทาง

**การกำหนดค่าการสำรองทำให้ไฟล์พรีเซนเทชันเปลี่ยนหรือไม่ และการตั้งค่านี้จะคงอยู่เมื่อตรวจเปิดไฟล์ครั้งต่อไปหรือไม่?**

ไม่มี. กฎการสำรองเป็นการตั้งค่าการเรนเดอร์ในขณะรันไทม์ในโค้ดของคุณ; ไม่ได้ถูกบันทึกภายในไฟล์ .pptx และจะไม่ปรากฏใน PowerPoint

**ระบบปฏิบัติการ (Windows/Linux/macOS) และชุดโฟลเดอร์แบบอักษรมีผลต่อการเลือกแบบอักษรสำรองหรือไม่?**

ใช่. เครื่องยนต์จะสแกนแบบอักษรจากโฟลเดอร์ระบบที่มีและ [เส้นทางเพิ่มเติม](/slides/th/cpp/custom-font/) ที่คุณระบุ หากแบบอักษรไม่มีอยู่จริง กฎที่อ้างอิงถึงมันจะไม่ทำงาน

**การสำรองทำงานกับ WordArt, SmartArt และแผนภูมิหรือไม่?**

ใช่. เมื่อวัตถุเหล่านี้มีข้อความ กลไกการแทนที่ glyph เดียวกันจะถูกนำไปใช้เพื่อเรนเดอร์อักขระที่ขาดหาย