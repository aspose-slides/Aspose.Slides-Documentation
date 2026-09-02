---
title: จัดการแบบอักษรธีมที่เจาะจงสคริปต์ใน C++
linktitle: แบบอักษรธีมที่เจาะจงสคริปต์
type: docs
weight: 15
url: /th/cpp/script-specific-font-mappings/
keywords:
- แบบอักษรที่เจาะจงสคริปต์
- การแมปแบบอักษรธีม
- การนำเสนอหลายภาษา
- ระบบการเขียน
- แบบอักษรซีริลลิก
- แบบอักษรอารบิก
- แบบอักษรญี่ปุ่น
- แบบอักษรจอร์เจีย
- แบบอักษรธานา
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ตรวจสอบ, เพิ่ม, แทนที่และลบการแมปแบบอักษรที่เจาะจงสคริปต์ในธีม PowerPoint ด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

ธีมการนำเสนอสามารถเลือกแบบอักษรที่ต่างกันสำหรับระบบการเขียนที่ต่างกันได้ สิ่งนี้ทำให้ข้อความหลายภาษา ซึ่งยังคงใช้แบบอักษรของธีม สามารถปฏิบัติตามโครงการแบบอักษรที่สอดคล้องเดียวกันในขณะที่ใช้แบบอักษรที่เหมาะสมสำหรับ Cyrillic, Arabic, Japanese, Georgian, Thaana และสคริปต์อื่น ๆ

ธีมของ [IFontScheme](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/ifontscheme/) มีคอลเลกชันแบบอักษรหลักซึ่งมักใช้สำหรับหัวเรื่อง และคอลเลกชันแบบอักษรรองซึ่งมักใช้สำหรับข้อความส่วนหลัก นอกจากคุณสมบัติแบบอักษรละตินและเอเชียตะวันออกแล้ว ทั้งสองคอลเลกชันยังเปิดเผยการแมปจากแท็กระบบการเขียนไปยังชื่อแบบอักษรผ่านส่วนติดต่อ [IFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifonts/) 

บทความนี้แสดงวิธีตรวจสอบและแก้ไขการแมปเหล่านั้นในธีมหลักของการนำเสนอและตรวจสอบว่าการเปลี่ยนแปลงยังคงอยู่หลังจากบันทึกและโหลดใหม่

## **ทำความเข้าใจแท็กสคริปต์**

เมธอดแบบอักษรสคริปต์ใช้แท็กย่อยสคริปต์ BCP 47 ที่มีสี่ตัวอักษรเพื่อระบุตัวระบบการเขียน ค่าที่พบบ่อยได้แก่:

| แท็กสคริปต์ | ระบบการเขียน |
|---|---|
| `Cyrl` | ซีริลลิก |
| `Arab` | อารบิก |
| `Hans` | จีนแบบประยุกต์ |
| `Jpan` | ญี่ปุ่น |
| `Geor` | จอร์เจีย |
| `Thaa` | ธานา |

การแมปเหล่านี้เป็นของโครงการแบบอักษรธีม ไม่ใช่ของส่วนข้อความแยกต่างหาก การนำเสนออาจกำหนดการแมปที่แตกต่างกันสำหรับคอลเลกชันหลักและรอง และอาจละเว้นการแมปสำหรับสคริปต์บางอย่าง

## **เข้าถึงและตรวจสอบการแมปแบบอักษรสคริปต์**

ใช้ [Presentation::get_MasterTheme](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_mastertheme/) เพื่อเข้าถึงธีมระดับการนำเสนอ เมธอด [FontScheme::get_Major](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/fontscheme/get_major/) และ [FontScheme::get_Minor](https://reference.aspose.com/slides/th/cpp/aspose.slides.theme/fontscheme/get_minor/) จะคืนคอลเลกชัน [IFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifonts/) ทั้งสองชุด

เรียก [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/th/cpp/aspose.slides/fonts/getscriptfontmap/) เพื่อดึงการแมปทั้งหมดจากคอลเลกชันหนึ่ง เพื่อค้นหาระบบการเขียนหนึ่ง ให้เรียก [Fonts::GetScriptFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/fonts/getscriptfont/) พร้อมกับแท็กสคริปต์ของมัน `GetScriptFont` จะคืนสตริงว่าง (null) เมื่อคอลเลกชันนั้นไม่ได้กำหนดการแมปที่ร้องขอ

## **แก้ไขการแมปและตรวจสอบการคงอยู่**

ใช้ [Fonts::SetScriptFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/fonts/setscriptfont/) เพื่อสร้างการแมปหรือแทนที่แบบอักษรที่ใช้อยู่ในปัจจุบัน ใช้ [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/fonts/removescriptfont/) เพื่อลบการแมป

ตัวอย่างแบบครบวงจรต่อไปนี้อ่านการแมปหลักและรองที่มีอยู่ทั้งหมด ค้นหาแบบอักษรหลักของญี่ปุ่น เปลี่ยนแบบอักษรหลักของซีริลลิก ลบการแมปรองของธานา บันทึกการนำเสนอ แล้วเปิดใหม่เพื่อยืนยันการเปลี่ยนแปลงทั้งสองขั้นตอน เพื่อทำให้ขั้นตอนการลบเป็นอิสระจากธีมเริ่มต้น ตัวอย่างจะสร้างการแมปธานาเฉพาะเมื่อยังไม่มีการกำหนดไว้ก่อน

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

การตรวจสอบใช้พฤติกรรมสตริงว่าง (null-string) แบบเดียวกับการค้นหาทั่วไป: หลังจากการลบถูกบันทึก `GetScriptFont(u"Thaa")` จะคืนสตริงว่างสำหรับคอลเลกชันรอง

## **แยกแยะการแมปธีมจากการตั้งค่าแบบอักษรอื่น**

การแมปธีมที่เจาะจงสคริปต์มีส่วนร่วมในกระบวนการเลือกแบบอักษร แต่พวกมันแก้ปัญหาแตกต่างจากการจัดรูปแบบข้อความโดยตรง การแทนที่แบบอักษร และการสำรองแบบอักษร:

| กลไก | จุดประสงค์ | ผลของการเปลี่ยนการแมปธีม |
|---|---|---|
| การแมปแบบอักษรธีมที่เจาะจงสคริปต์ | เลือกแบบอักษรธีมหลักหรือรองสำหรับระบบการเขียน | ข้อความที่ยังคงใช้ธีมแบบอักษรที่สอดคล้องสามารถแก้ไขเป็นครอบครัวแบบอักษรที่แมปใหม่ได้ |
| แบบอักษรที่กำหนดให้กับส่วนข้อความโดยตรง | กำหนดครอบครัวแบบอักษรที่ร้องขอบนส่วนนั้นแทนการพึ่งพาธีม | ส่วนนั้นอาจคงเดิมไม่ได้เปลี่ยนเพราะการจัดรูปแบบโดยตรงลบล้างการเลือกของธีม |
| การแทนที่แบบอักษร | แทนที่แบบอักษรที่ร้องขอเมื่อแบบอักษรนั้นไม่มีหรือกฎการแทนที่ทำงาน | มันทำงานหลังจากที่แบบอักษรถูกร้องขอ; ไม่ได้กำหนดการแมปสคริปต์ของธีมใหม่ |
| การสำรองแบบอักษร | จัดหา glyphs ที่แบบอักษรที่เลือกไม่มี โดยมักสำหรับช่วง Unicode เฉพาะ | มันเติมส่วนที่ขาดของ glyph; ไม่ได้เปลี่ยนการแมปธีมที่เก็บไว้ |

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับสองกลไกสุดท้าย ดูที่ [Font Substitution](/slides/th/cpp/font-substitution/) และ [Fallback Fonts](/slides/th/cpp/fallback-font/).

การเปลี่ยนการแมปใน [Presentation::get_MasterTheme](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_mastertheme/) มีผลต่อเนื้อหาเท่านั้นที่การจัดรูปแบบที่มีผลยังขึ้นอยู่กับธีมนั้น ข้อความอาจสืบทอดการแทนที่ธีมจากมาสเตอร์, เลย์เอาต์, หรือสไลด์, หรือใช้แบบอักษรที่กำหนดโดยตรง ตรวจสอบระดับเหล่านั้นเมื่อผลลัพธ์ที่มองเห็นไม่สอดคล้องกับการแมประดับการนำเสนอ

## **ทำให้แบบอักษรที่แมปพร้อมใช้งานและตรวจสอบผลลัพธ์**

การแมปสคริปต์เก็บชื่อแบบอักษร; มันไม่ได้ติดตั้งหรือโหลดไฟล์แบบอักษรที่สอดคล้องกัน เพื่อการเรนเดอร์และการส่งออกที่สอดคล้องทุกแบบอักษรที่แมปต้องถูกติดตั้งในสภาพแวดล้อมหรือจัดหามาให้ Aspose.Slides ผ่านแหล่งกำหนดเอง เช่น [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsloader/loadexternalfonts/) หรือ [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). ดูที่ [Custom Fonts](/slides/th/cpp/custom-font/) สำหรับตัวเลือกการโหลดที่มี

การยืนยันการแมปที่บันทึกไว้ยืนยันเพียงว่าการกำหนดธีมยังคงอยู่ ไม่ได้พิสูจน์ว่าแบบอักษรพร้อมใช้งาน, มี glyph ที่จำเป็นทั้งหมด, หรือสร้างการจัดวางตามที่ตั้งใจ ให้เรนเดอร์ข้อความตัวอย่างสำหรับทุกระบบการเขียนที่ต้องการเป็นภาพหรือ PDF แล้วตรวจสอบผลลัพธ์ สิ่งนี้ช่วยจับแบบอักษรที่หายไป, การครอบคลุม glyph ที่ไม่สมบูรณ์, พฤติกรรมการสำรอง, และการเปลี่ยนแปลงการจัดวางก่อนที่การนำเสนอจะถูกแจกจ่าย ดูที่ [Convert PowerPoint Presentations](/slides/th/cpp/convert-powerpoint/) สำหรับตัวอย่างการเรนเดอร์และส่งออก

## **คำถามที่พบบ่อย**

**`GetScriptFont` คืนค่าอะไรเมื่อสคริปต์ไม่ได้ถูกแมป?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/fonts/getscriptfont/) คืนสตริงว่าง (null) เมื่อการแมปสคริปต์ที่ร้องขอไม่ได้กำหนดในคอลเลกชันแบบอักษรหลักหรือรองนั้น

**`SetScriptFont` จะเพิ่มการแมปที่สองเมื่อสคริปต์มีอยู่แล้วหรือไม่?**

ไม่. [Fonts::SetScriptFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/fonts/setscriptfont/) จะสร้างการแมปเมื่อไม่มีและแทนที่แบบอักษรที่แมปเมื่อแท็กสคริปต์เดียวกันมีอยู่แล้ว

**ทำไมการเปลี่ยนการแมปธีมถึงไม่ทำให้ข้อความบางส่วนเปลี่ยนแปลง?**

ข้อความอาจมีแบบอักษรที่กำหนดโดยตรง, สืบทอดธีมที่ต่างออกไปผ่านการแทนที่, หรือได้รับผลกระทบจากการแทนที่หรือการสำรองระหว่างการเรนเดอร์ การแมปสคริปต์ระดับการนำเสนอควบคุมเฉพาะข้อความที่การจัดรูปแบบที่มีผลยังอ้างอิงคอลเลกชันแบบอักษรของธีมนั้น

**การบันทึกและเปิดใหม่เพียงพอที่จะตรวจสอบผลลัพธ์หลายภาษาไหม?**

ไม่. การเปิดใหม่ตรวจสอบความคงอยู่ของข้อมูลธีม นอกจากนี้ให้เรนเดอร์ข้อความตัวอย่างจากแต่ละระบบการเขียนที่ต้องการเพื่อยืนยันว่าแบบอักษรที่แมปพร้อมใช้งานและมี glyph ที่จำเป็น