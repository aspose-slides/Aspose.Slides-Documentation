---
title: กำหนดค่าการแทนที่ฟอนต์ในงานนำเสนอด้วย C++
linktitle: การแทนที่ฟอนต์
type: docs
weight: 70
url: /th/cpp/font-substitution/
keywords:
- ฟอนต์
- ฟอนต์ทดแทน
- การแทนที่ฟอนต์
- แทนที่ฟอนต์
- การเปลี่ยนฟอนต์
- กฎการแทนที่
- กฎการเปลี่ยน
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "กำหนดค่ากฎการแทนที่ฟอนต์และตรวจสอบฟอนต์ที่ถูกแทนที่ใน Aspose.Slides สำหรับ C++ เมื่อแสดงผลหรือแปลงงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การแทนที่ฟอนต์ทำให้ Aspose.Slides สามารถใช้ฟอนต์ที่มีอยู่แทนฟอนต์ที่ไม่สามารถเข้าถึงได้เมื่อการแสดงหรือการแปลงงานนำเสนอ กฎการแทนที่ส่งผลต่อผลลัพธ์ที่แสดงเท่านั้น; ไม่ได้เปลี่ยนฟอนต์ที่กำหนดให้กับเนื้อหาของงานนำเสนอ

คุณสามารถกำหนดฟอนต์ที่จะใช้เมื่อฟอนต์ใดฟอนต์หนึ่งไม่มีอยู่ได้ และคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการแสดงผล สิ่งนี้ช่วยให้ผลลัพธ์คงที่แม้ในสภาพแวดล้อมที่มีฟอนต์ติดตั้งแตกต่างกัน

หากฟอนต์มีอยู่แต่ไม่มีรูปแบบหนาเฉพาะ ให้ดูที่ [จัดการฟอนต์ที่ไม่มีรูปแบบหนาเฉพาะ](/slides/th/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). ส่วนนี้อธิบายวิธีการแรสเตอร์ข้อความที่ได้รับผลกระทบระหว่างการส่งออกเป็น PDF และผลกระทบต่อการเลือกข้อความ การค้นหา และการปรับขนาด

## **รับการแทนที่ฟอนต์**

ใช้เมธอด [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) เพื่อกำหนดว่าฟอนต์ใดจะถูกแทนที่เมื่อการแสดงงานนำเสนอ เมธอดนี้คืนค่าออบเจกต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) ที่ระบุชื่อฟอนต์ต้นฉบับและฟอนต์ที่แทนที่

ตัวอย่าง C++ ด้านล่างแสดงรายการการแทนที่ฟอนต์ทั้งหมดสำหรับงานนำเสนอ:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **รับการแทนที่ฟอนต์สำหรับสไลด์ที่เลือก**

ใช้เมธอดโอเวอร์โหลดของ [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) พร้อมอาร์กิวเมนต์ `System::ArrayPtr<int32_t> slides` เพื่อดูการแทนที่ที่จำเป็นสำหรับการแสดงสไลด์เฉพาะบางสไลด์เท่านั้น สิ่งนี้มีประโยชน์เมื่อคุณกำลังแสดงผลหรือส่งออกส่วนหนึ่งของงานนำเสนอ ตรวจสอบงานนำเสนอขนาดใหญ่แบบเพิ่มขึ้น ค้นหาสไลด์ที่พึ่งพาฟอนต์ที่ไม่พร้อมใช้งาน เตรียมชุดฟอนต์ขนาดเล็กสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์ หรือวิเคราะห์ความแตกต่างของการแสดงผลโดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

อาร์เรย์ `slides` มีดัชนีสไลด์แบบเริ่มต้นจากหนึ่ง: `1` ระบุสไลด์แรก ในทางตรงกันข้ามเมธอด [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) ใช้ดัชนีเริ่มจากศูนย์ ดังนั้นสไลด์เดียวกันจะถูกเรียกด้วย `presentation->get_Slide(0)`. จำไว้ว่าต้องสร้างอาร์เรย์ให้สอดคล้องเพื่อหลีกเลี่ยงข้อผิดพลาด off‑by‑one

เรียกโอเวอร์โหลดผ่านเมธอด [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) ซึ่งจะคืนค่าเฉพาะการแทนที่ที่กำหนดในระหว่างการแสดงสไลด์ที่เลือก ผลลัพธ์แต่ละรายการเป็นออบเจกต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) ที่บรรจุชื่อฟอนต์ต้นฉบับและฟอนต์ที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมฟอนต์ปัจจุบัน กฎ fallback ที่กำหนดไว้ กฎการแทนที่ที่จัดเก็บใน [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/) และ [ฟอนต์ที่โหลดจากภายนอก](/slides/th/cpp/custom-font/)

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ ให้ทำการดึงข้อมูลที่ซ้ำออกเมื่อคุณสร้างรายการตรวจสอบฟอนต์หรือรายงาน preflight ตัวอย่างต่อไปนี้รายงานการแทนที่ที่คืนค่าทุกรายการแล้วสร้างรายการจัดเรียงของการแมปฟอนต์ที่ไม่ซ้ำกัน:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

อินเทอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) ให้โอเวอร์โหลดทั้งสองแบบ เลือกใช้ตามขอบเขตของการดำเนินการแสดงผล:

| Overload | Use it when |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | คุณต้องการการแทนที่สำหรับงานนำเสนอทั้งหมด |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | คุณต้องการการแทนที่สำหรับช่วงที่เลือก การตรวจสอบแบบเพิ่มขึ้น หรือการส่งออกบางส่วน |

## **ตั้งค่ากฎการแทนที่ฟอนต์**

เพื่อระบุฟอนต์ที่ Aspose.Slides ควรใช้เมื่อฟอนต์ต้นฉบับไม่มีอยู่:

1. โหลดงานนำเสนอ
2. สร้างการกำหนดฟอนต์สำหรับฟอนต์ต้นฉบับและฟอนต์แทนที่
3. สร้าง [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/)
4. เพิ่มกฎเข้าไปใน [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันโดยใช้เมธอด [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/)
6. แสดงผลหรือแปลงงานนำเสนอ

ตัวอย่าง C++ ด้านล่างแทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่มีอยู่ แล้วแสดงสไลด์แรกเพื่อยืนยันผลลัพธ์ ฟอนต์แทนที่ต้องพร้อมใช้งานสำหรับ Aspose.Slides

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
สำหรับการเปลี่ยนแปลงฟอนต์ทั่วทั้งงานนำเสนอโดยไม่มีเงื่อนไข ให้ดูที่ [การแทนที่ฟอนต์](/slides/th/cpp/font-replacement/).
{{% /alert %}}

## **ข้อจำกัดสำหรับฟอนต์สมการคณิตศาสตร์**

กฎการแทนที่ฟอนต์เป็นส่วนหนึ่งของกระบวนการเลือกฟอนต์มาตรฐานที่ใช้ระหว่างการแสดงผลและการแปลง พวกมันทำงานกับข้อความทั่วไปเมื่อ Aspose.Slides สามารถแทนที่ฟอนต์ที่เข้าถึงไม่ได้ด้วยฟอนต์ที่ระบุไว้ในกฎ

สมการ Office Math มีความต้องการเพิ่มเติม หากสมการใช้ **Cambria Math** Aspose.Slides อาจต้องใช้ฟอนต์นั้นอย่างตรงตัวเพื่อคำนวณและแสดงเค้าโครงสมการ กฎที่แทนที่ฟอนต์คณิตศาสตร์อื่น เช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** เพื่อวัตถุประสงค์นี้ได้ และการแสดงผลอาจยังคงรายงานว่าต้องการ **Cambria Math**

เพื่อแสดงผลหรือแปลงงานนำเสนอเช่นนี้ ให้ทำให้ **Cambria Math** พร้อมใช้งานสำหรับ Aspose.Slides ติดตั้งฟอนต์ในระบบปฏิบัติการหรือโหลดเป็น [ฟอนต์ภายนอก](/slides/th/cpp/custom-font/)

ข้อจำกัดนี้ใช้กับการจัดเรียงสมการเท่านั้น กฎการแทนที่ที่อธิบายข้างต้นยังคงใช้กับข้อความทั่วไปในงานนำเสนอ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างการแทนที่ฟอนต์และการแทนที่ฟอนต์คืออะไร?**

[Font replacement](/slides/th/cpp/font-replacement/) เปลี่ยนฟอนต์หนึ่งเป็นอีกฟอนต์หนึ่งทั่วทั้งงานนำเสนอโดยเจตนา ส่วนการแทนที่ฟอนต์เลือกฟอนต์สำหรับผลลัพธ์ที่แสดงเมื่อเงื่อนไขที่กำหนดตรงกัน เช่น ฟอนต์ต้นฉบับไม่มีอยู่

**กฎการแทนที่ฟอนต์ทำงานเมื่อใด?**

กฎเหล่านี้เข้าร่วมใน [ลำดับการเลือกฟอนต์](/slides/th/cpp/font-selection-sequence/) ระหว่างการแสดงผลและการแปลง ด้วย `WhenInaccessible` กฎจะใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงฟอนต์ต้นฉบับได้

**จะเกิดอะไรขึ้นเมื่อฟอนต์หายไปและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกฟอนต์ที่ใกล้เคียงที่สุดที่มีอยู่ตามกระบวนการเลือกฟอนต์ ผลลัพธ์ขึ้นอยู่กับฟอนต์ที่มีในสภาพแวดล้อมการทำงาน

**ฉันสามารถโหลดฟอนต์ภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**

ได้ คุณสามารถ [load external fonts](/slides/th/cpp/custom-font/) เพื่อให้ Aspose.Slides ใช้ฟอนต์เหล่านั้นระหว่างการแสดงผลและการแปลง

**Aspose แจกจ่ายฟอนต์พร้อมไลบรารีหรือไม่?**

ไม่ คุณต้องรับผิดชอบในการจัดหา ฟอนต์และปฏิบัติตามเงื่อนไขการใช้ของฟอนต์เหล่านั้น

**ผลการแทนที่อาจแตกต่างระหว่าง Windows, Linux และ macOS หรือไม่?**

ใช่ ฟอนต์ที่ติดตั้งและตำแหน่งการค้นหาฟอนต์แตกต่างกันตามระบบปฏิบัติการ ดังนั้นฟอนต์ที่มีอยู่บนเครื่องหนึ่งอาจต้องการการแทนที่บนเครื่องอื่น

**ฉันจะทำให้การเลือกฟอนต์สอดคล้องกันในการแปลงเป็นชุดได้อย่างไร?**

ใช้ไฟล์ฟอนต์และเวอร์ชันเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์ [โหลดฟอนต์ภายนอกที่จำเป็น](/slides/th/cpp/custom-font/) และ [ฝังฟอนต์](/slides/th/cpp/embedded-font/) เมื่อใบอนุญาตอนุญาต คุณยังสามารถเรียกใช้ [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) ก่อนส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด