---
title: กำหนดการแทนที่แบบอักษรในงานนำเสนอด้วย C++
linktitle: การแทนที่แบบอักษร
type: docs
weight: 70
url: /th/cpp/font-substitution/
keywords:
- แบบอักษร
- แบบอักษรทดแทน
- การแทนที่แบบอักษร
- แทนที่แบบอักษร
- การเปลี่ยนแบบอักษร
- กฎการแทนที่
- กฎการเปลี่ยน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "กำหนดกฎการแทนที่แบบอักษรและตรวจสอบแบบอักษรที่ถูกแทนที่ใน Aspose.Slides สำหรับ C++ เมื่อทำการเรนเดอร์หรือแปลงงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การแทนที่แบบอักษรทำให้ Aspose.Slides สามารถใช้แบบอักษรที่มีอยู่แทนแบบอักษรที่ไม่สามารถเข้าถึงได้เมื่อทำการแสดงผลหรือแปลงงานนำเสนอ การแทนที่จะส่งผลต่อผลลัพธ์ที่แสดงผลเท่านั้น; ไม่ทำการเปลี่ยนแบบอักษรที่กำหนดให้กับเนื้อหาของงานนำเสนอ

คุณสามารถกำหนดแบบอักษรที่จะใช้เมื่อแบบอักษรเฉพาะไม่มีอยู่ได้ และคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการเรนเดอร์ ซึ่งช่วยให้ผลลัพธ์คงที่สม่ำเสมอระหว่างสภาพแวดล้อมที่มีแบบอักษรติดตั้งแตกต่างกัน

## **รับการแทนที่แบบอักษร**

ใช้เมธอด [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/getsubstitutions/) เพื่อระบุว่าแบบอักษรใดจะถูกแทนที่เมื่อทำการแสดงผลงานนำเสนอ เมธอดนี้จะคืนค่าอ็อบเจกต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsubstitutioninfo/) ที่บ่งบอกชื่อแบบอักษรเดิมและแบบอักษรที่แทนที่

ตัวอย่าง C++ ด้านล่างจะแสดงรายการการแทนที่แบบอักษรทั้งหมดสำหรับงานนำเสนอหนึ่งรายการ:

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

## **รับการแทนที่แบบอักษรสำหรับสไลด์ที่เลือก**

ใช้เมธอดโอเวอร์โหลดของ [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/getsubstitutions/) พร้อมอาร์กิวเมนต์ `System::ArrayPtr<int32_t> slides` เพื่อดูการแทนที่ที่จำเป็นต่อการเรนเดอร์สไลด์เฉพาะเท่านั้น สิ่งนี้มีประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกส่วนของงานนำเสนอ ตรวจสอบงานนำเสนอขนาดใหญ่เป็นช่วงๆ ค้นหาสไลด์ที่พึ่งพาแบบอักษรที่ไม่มีอยู่ เตรียมชุดแบบอักษรขั้นต่ำสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์ หรือวิเคราะห์ความแตกต่างของการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่ได้เกี่ยวข้อง

อาร์เรย์ `slides` มีดัชนีสไลด์แบบอิงหนึ่ง: `1` ระบุสไลด์แรก ในขณะที่เมธอด [Presentation::get_Slide](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_slide/) ใช้ดัชนีเริ่มต้นที่ศูนย์ ดังนั้นสไลด์เดียวกันจะถูกเข้าถึงเป็น `presentation->get_Slide(0)` โปรดคำนึงถึงความแตกต่างนี้เมื่อตั้งค่าอาร์เรย์เพื่อหลีกเลี่ยงข้อผิดพลาด off‑by‑one

เรียกโอเวอร์โหลดผ่านเมธอด [Presentation::get_FontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_fontsmanager/) ซึ่งจะคืนค่าเฉพาะการแทนที่ที่กำหนดระหว่างการเรนเดอร์สไลด์ที่เลือก แต่ละผลลัพธ์เป็นอ็อบเจกต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsubstitutioninfo/) ที่บรรจุชื่อแบบอักษรเดิมและแบบอักษรที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมแบบอักษรปัจจุบัน กฎ fallback ที่กำหนดไว้ กฎการแทนที่ที่จัดเก็บใน [IFontSubstRuleCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsubstrulecollection/) และ [แบบอักษรที่โหลดจากภายนอก](/slides/th/cpp/custom-font/)

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ ให้ทำการกำจัดข้อมูลซ้ำเมื่อคุณสร้างรายการสินทรัพย์แบบอักษรหรือรายงาน preflight ตัวอย่างต่อไปนี้จะแสดงการรายงานการแทนที่ทุกรายการที่คืนค่าแล้วสร้างรายการแบบอักษรที่ไม่ซ้ำกันและเรียงลำดับ:

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

อินเทอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/) มีโอเวอร์โหลดทั้งสองแบบ ให้เลือกตามขอบเขตของการดำเนินการเรนเดอร์:

| Overload | Use it when |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | You need substitutions for the entire presentation. |
| [GetSubstitutions](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | You need substitutions for a selected range, incremental check, or partial export. |

## **ตั้งค่ากฎการแทนที่แบบอักษร**

เพื่อระบุแบบอักษรที่ Aspose.Slides ควรใช้เมื่อแบบอักษรต้นทางไม่มีอยู่:

1. โหลดงานนำเสนอ
2. สร้างการกำหนดแบบอักษรสำหรับแบบอักษรต้นทางและแบบอักษรทดแทน
3. สร้างอ็อบเจกต์ [FontSubstRule](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsubstcondition/)
4. เพิ่มกฎลงใน [FontSubstRuleCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันโดยใช้เมธอด [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/)
6. เรนเดอร์หรือแปลงงานนำเสนอ

ตัวอย่าง C++ ด้านล่างแทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่มีอยู่ แล้วเรนเดอร์สไลด์แรกเพื่อยืนยันผลลัพธ์ แบบอักษรทดแทนต้องมีอยู่ใน Aspose.Slides

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
สำหรับการเปลี่ยนแบบอักษรโดยไม่ต้องมีเงื่อนไขในทั้งงานนำเสนอ ดูที่ [Font Replacement](/slides/th/cpp/font-replacement/) 
{{% /alert %}}

## **ข้อจำกัดสำหรับแบบอักษรสมการคณิตศาสตร์**

กฎการแทนที่แบบอักษรเป็นส่วนหนึ่งของกระบวนการเลือกแบบอักษรมาตรฐานที่ใช้ระหว่างการเรนเดอร์และการแปลง พวกมันทำงานกับข้อความทั่วไปเมื่อ Aspose.Slides สามารถแทนที่แบบอักษรที่ไม่เข้าถึงได้ด้วยแบบอักษรที่กำหนดโดยกฎ

สมการ Office Math มีข้อกำหนดเพิ่มเติม หากสมการใช้ **Cambria Math** Aspose.Slides อาจต้องการแบบอักษรนั้นอย่างแม่นยำเพื่อคำนวณและเรนเดอร์เลย์เอาต์ของสมการ กฎที่แทนที่ด้วยแบบอักษรคณิตศาสตร์อื่น เช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** ได้สำหรับวัตถุประสงค์นี้ และการเรนเดอร์อาจยังแจ้งว่า **Cambria Math** จำเป็น

เพื่อเรนเดอร์หรือแปลงงานนำเสนอเช่นนั้น ให้ทำให้ **Cambria Math** มีอยู่ใน Aspose.Slides โดยติดตั้งในระบบปฏิบัติการหรือโหลดเป็น [แบบอักษรภายนอก](/slides/th/cpp/custom-font/)

ข้อจำกัดนี้ใช้กับการจัดเรียงสมการเท่านั้น กฎการแทนที่ที่อธิบายข้างต้นยังคงใช้กับข้อความทั่วไปของงานนำเสนอ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างการแทนที่แบบอักษรและการเปลี่ยนแบบอักษรคืออะไร?**

[Font replacement](/slides/th/cpp/font-replacement/) เปลี่ยนแบบอักษรหนึ่งเป็นอีกแบบหนึ่งทั่วงานนำเสนออย่างตั้งใจ ส่วนการแทนที่แบบอักษรจะเลือกแบบอักษรสำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดตรงกัน เช่น เมื่อแบบอักษรเดิมไม่มีอยู่

**กฎการแทนที่ถูกใช้เมื่อไหร่?**

กฎเหล่านี้เข้าร่วมใน [font selection sequence](/slides/th/cpp/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง โดยใช้ `WhenInaccessible` กฎจะใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงแบบอักษรต้นทางได้

**จะเกิดอะไรขึ้นเมื่อแบบอักษรหายและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกแบบอักษรที่ใกล้เคียงที่สุดตามกระบวนการเลือกแบบอักษรของมัน ผลลัพธ์ขึ้นอยู่กับแบบอักษรที่มีอยู่ในสภาพแวดล้อมการทำงาน

**ฉันสามารถโหลดแบบอักษรภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**

ได้ คุณสามารถ [load external fonts](/slides/th/cpp/custom-font/) เพื่อให้ Aspose.Slides ใช้ได้ระหว่างการเรนเดอร์และการแปลง

**Aspose มีการแจกจ่ายแบบอักษรพร้อมกับไลบรารีหรือไม่?**

ไม่มี คุณต้องรับผิดชอบในการจัดหาแบบอักษรและปฏิบัติตามใบอนุญาตของแต่ละแบบอักษร

**ผลลัพธ์ของการแทนที่อาจแตกต่างระหว่าง Windows, Linux และ macOS หรือไม่?**

ใช่ แบบอักษรที่ติดตั้งและตำแหน่งการค้นหาแบบอักษรแตกต่างกันตามระบบปฏิบัติการ ดังนั้นแบบอักษรที่มีในเครื่องหนึ่งอาจต้องการการแทนที่ในเครื่องอื่น

**จะทำให้การเลือกแบบอักษรสม่ำเสมอในการแปลงเป็นชุดได้อย่างไร?**

ใช้ไฟล์และเวอร์ชันแบบอักษรเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์, [load required external fonts](/slides/th/cpp/custom-font/), และ [embed fonts](/slides/th/cpp/embedded-font/) เมื่อใบอนุญาตอนุญาต คุณยังสามารถเรียก [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifontsmanager/getsubstitutions/) ก่อนทำการส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด