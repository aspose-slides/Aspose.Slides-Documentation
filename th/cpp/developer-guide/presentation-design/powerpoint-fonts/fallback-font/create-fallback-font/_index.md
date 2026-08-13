---
title: ระบุฟอนต์สำรองสำหรับการนำเสนอใน C++
linktitle: ฟอนต์สำรอง
type: docs
weight: 10
url: /th/cpp/create-fallback-font/
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
- การนำเสนอ
- C++
- Aspose.Slides
description: "เชี่ยวชาญ Aspose.Slides สำหรับ C++ เพื่อกำหนดฟอนต์สำรองในไฟล์ PPT, PPTX และ ODP, เพื่อรับประกันการแสดงผลข้อความที่สอดคล้องบนอุปกรณ์หรือระบบปฏิบัติการใดก็ได้."
---
## **ภาพรวม**

Aspose.Slides ให้คุณระบุฟอนต์สำรองสำหรับการแสดงผลและการส่งออกงานนำเสนอ ฟอนต์สำรองจะถูกใช้เมื่อฟอนต์หลักไม่มี glyph สำหรับอักขระบางตัว

พฤติกรรมของฟอนต์สำรองจะถูกกำหนดผ่านกฎฟอนต์สำรอง แต่ละกฎจะผูกช่วง Unicode กับฟอนต์หนึ่งหรือหลายฟอนต์ที่อาจมี glyph ที่ต้องการ คุณสามารถกำหนดกฎสำหรับช่วงอักขระต่าง ๆ เพิ่มหรือลบฟอนต์สำรองจากกฎที่มีอยู่ และจัดระเบียบหลายกฎในคอลเลกชันกฎฟอนต์สำรอง

กฎฟอนต์สำรองเป็นการตั้งค่าการแสดงผลขณะทำงาน ไม่ได้แก้ไขไฟล์งานนำเสนอเองและไม่ได้ถูกจัดเก็บภายในไฟล์ PPTX

## **กฎฟอนต์สำรอง**

Aspose.Slides รองรับอินเทอร์เฟซ [IFontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontfallbackrule/) และคลาส [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) เพื่อระบุกฎการใช้ฟอนต์สำรอง คลาส [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) แทนความสัมพันธ์ระหว่างช่วง Unicode ที่ใช้ค้นหา glyph ที่ขาดหายกับรายการฟอนต์ที่อาจมี glyph ที่เหมาะสม:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

นอกจากนี้ยังสามารถเรียกใช้เมธอด [Remove()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontfallbackrule/remove/) เพื่อลบฟอนต์สำรองหรือเมธอด [AddFallBackFonts()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) เพื่อเพิ่มฟอนต์สำรองในอ็อบเจกต์ [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) ที่มีอยู่ได้

คลาส [FontFallBackRulesCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrulescollection/) สามารถใช้จัดระเบียบรายการอ็อบเจกต์ [FontFallBackRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontfallbackrule/) เมื่อต้องการระบุกฎการแทนที่ฟอนต์สำรองสำหรับหลายช่วง Unicode

{{% alert color="info" title="See also" %}} 
- [สร้างคอลเลกชันฟอนต์สำรอง](/slides/th/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

### ฟอนต์สำรอง, การแทนที่ฟอนต์, และการฝังฟอนต์ แตกต่างกันอย่างไร?

ฟอนต์สำรองจะใช้เฉพาะกับอักขระที่ไม่มีในฟอนต์หลัก [การแทนที่ฟอนต์](/slides/th/cpp/font-substitution/) จะเปลี่ยนฟอนต์ที่ระบุทั้งหมดด้วยฟอนต์อื่น [การฝังฟอนต์](/slides/th/cpp/embedded-font/) จะบรรจุฟอนต์ไว้ในไฟล์ผลลัพธ์เพื่อให้ผู้รับสามารถดูข้อความตามที่ต้องการได้

### ฟอนต์สำรองจะถูกนำไปใช้ในระหว่างการส่งออกเช่น PDF, PNG หรือ SVG หรือใช้เฉพาะการแสดงผลบนหน้าจอเท่านั้น?

ใช่ ฟอนต์สำรองมีผลต่อทุก [การแสดงผลและการส่งออก](/slides/th/cpp/convert-presentation/) ที่ต้องวาดอักขระแต่ฟอนต์ต้นแบบไม่มี

### การกำหนดค่าฟอนต์สำรองจะทำให้ไฟล์งานนำเสนอเปลี่ยนแปลงหรือไม่ และการตั้งค่านี้จะคงอยู่เมื่อเปิดไฟล์ในครั้งต่อไปหรือไม่?

ไม่ กฎฟอนต์สำรองเป็นการตั้งค่าการแสดงผลขณะทำงานในโค้ดของคุณ ไม่ได้ถูกบันทึกไว้ในไฟล์ .pptx และจะไม่ปรากฏใน PowerPoint

### ระบบปฏิบัติการ (Windows/Linux/macOS) และชุดโฟลเดอร์ฟอนต์มีผลต่อการเลือกฟอนต์สำรองหรือไม่?

ใช่ เngine จะค้นหาฟอนต์จากโฟลเดอร์ระบบที่มีและจาก [เส้นทางเพิ่มเติม](/slides/th/cpp/custom-font/) ที่คุณระบุ หากฟอนต์ไม่มีอยู่จริง กฎที่อ้างอิงฟอนต์นั้นจะไม่ทำงาน

### ฟอนต์สำรองทำงานได้กับ WordArt, SmartArt และแผนภูมิหรือไม่?

ใช่ เมื่อวัตถุเหล่านี้มีข้อความ กลไกการแทนที่ glyph จะทำงานเช่นเดียวกันเพื่อแสดงอักขระที่หายไป