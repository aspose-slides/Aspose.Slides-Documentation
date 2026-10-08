---
title: กำหนดค่าการแทนที่แบบอักษรในงานนำเสนอด้วย .NET
linktitle: การแทนที่แบบอักษร
type: docs
weight: 70
url: /th/net/font-substitution/
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
- .NET
- C#
- Aspose.Slides
description: "กำหนดค่ากฎการแทนที่แบบอักษรและตรวจสอบแบบอักษรที่ถูกแทนที่ใน Aspose.Slides สำหรับ .NET เมื่อทำการเรนเดอร์หรือแปลงงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การแทนที่แบบอักษรทำให้ Aspose.Slides สามารถใช้แบบอักษรที่มีอยู่แทนแบบอักษรที่ไม่สามารถเข้าถึงได้เมื่อทำการเรนเดอร์หรือแปลงงานนำเสนอ การแทนที่มีผลต่อผลลัพธ์ที่เรนเดอร์; ไม่ได้เปลี่ยนแบบอักษรที่กำหนดให้กับเนื้อหาของงานนำเสนอ

คุณสามารถกำหนดแบบอักษรที่ใช้เมื่อแบบอักษรเฉพาะเจาะจงไม่มีอยู่ได้ และคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการเรนเดอร์ สิ่งนี้ช่วยให้ผลลัพธ์คงที่เมื่อทำงานในสภาพแวดล้อมที่มีแบบอักษรติดตั้งต่างกัน

หากแบบอักษรมีอยู่แต่ไม่มีรูปแบบตัวหนาเฉพาะ โปรดดูที่ [จัดการแบบอักษรที่ไม่มีตัวหนาเฉพาะ](/slides/th/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) ส่วนนั้นอธิบายวิธีเรสเตอร์ไอซ์ข้อความที่ได้รับผลกระทบระหว่างการส่งออกเป็น PDF และผลกระทบต่อการเลือกข้อความ การค้นหา และการสเกล

## **รับการแทนที่แบบอักษร**

ใช้เมธอด [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) เพื่อกำหนดว่าแบบอักษรใดจะถูกแทนที่เมื่อทำการเรนเดอร์งานนำเสนอ เมธอดจะคืนค่าอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) ที่ระบุชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่

ตัวอย่าง C# ต่อไปนี้แสดงการรายการการแทนที่แบบอักษรทั้งหมดสำหรับงานนำเสนอ:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **รับการแทนที่แบบอักษรสำหรับสไลด์ที่เลือก**

ใช้เมธอดโอเวอร์โหลดของ [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) พร้อมอาร์กิวเมนต์ `int[] slides` เพื่อตรวจสอบเฉพาะการแทนที่ที่จำเป็นสำหรับการเรนเดอร์สไลด์ที่ระบุ วิธีนี้มีประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกบางส่วนของงานนำเสนอ ตรวจสอบงานนำเสนอขนาดใหญ่แบบเป็นขั้นตอน ค้นหาสไลด์ที่ขึ้นอยู่กับแบบอักษรที่ไม่มีอยู่ เตรียมชุดแบบอักษรขนาดเล็กสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์ หรือวิเคราะห์ความแตกต่างของการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

อาร์เรย์ `slides` มีดัชนีสไลด์แบบเริ่มจากหนึ่ง: `1` ระบุสไลด์แรก ในทางตรงกันข้าม ตัวดัชนีของคอลเลกชัน [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) เริ่มจากศูนย์ ดังนั้นสไลด์เดียวกันจึงเข้าถึงได้โดยใช้ `presentation.Slides[0]` ควรจำความแตกต่างนี้เมื่อสร้างอาร์เรย์เพื่อหลีกเลี่ยงข้อผิดพลาด off-by-one

เรียกโอเวอร์โหลดผ่านคุณสมบัติ [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) จะคืนค่าการแทนที่ที่กำหนดขณะเรนเดอร์สไลด์ที่เลือกเท่านั้น แต่ละผลลัพธ์เป็นอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) ที่บรรจุชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมแบบอักษรปัจจุบันและ [แบบอักษรที่โหลดจากภายนอก](/slides/th/net/custom-font/) กฎการแทนที่ที่เก็บไว้ใน [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) จะเปลี่ยนผลลัพธ์ที่เรนเดอร์แต่จะไม่ปรากฏในผลลัพธ์

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ จึงควรลบข้อมูลซ้ำเมื่อสร้างรายการแบบอักษรหรือรายงานการตรวจสอบ ตัวอย่างต่อไปนี้รายงานการแทนที่ที่คืนค่าแต่ละรายการแล้วสร้างรายการแบบอักษรที่แมปแบบไม่ซ้ำกันเรียงลำดับ:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

อินเทอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) ให้โอเวอร์โหลดทั้งสองแบบ เลือกใช้ตามขอบเขตของการเรนเดอร์:

| วิธีโหลด | ใช้เมื่อ |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) ไม่มีอาร์กิวเมนต์ | คุณต้องการการแทนที่สำหรับงานนำเสนอทั้งหมด |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) พร้อม `int[] slides` | คุณต้องการการแทนที่สำหรับช่วงที่เลือก การตรวจสอบแบบเป็นขั้นตอน หรือการส่งออกส่วนหนึ่ง |

## **กำหนดกฎการแทนที่แบบอักษร**

เพื่อระบุแบบอักษรที่ Aspose.Slides ควรใช้เมื่อแบบอักษรต้นทางไม่มีอยู่:

1. โหลดงานนำเสนอ
2. สร้างการกำหนดแบบอักษรสำหรับแบบอักษรต้นฉบับและแบบอักษรสำรอง
3. สร้างอ็อบเจ็กต์ [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/)
4. เพิ่มกฎลงใน [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันให้กับคุณสมบัติ [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/)
6. เรนเดอร์หรือแปลงงานนำเสนอ

ตัวอย่าง C# ต่อไปนี้แทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่มีอยู่ แล้วเรนเดอร์สไลด์แรกเพื่อยืนยันผลลัพธ์ แบบอักษรสำรองต้องมีอยู่ใน Aspose.Slides

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
สำหรับการเปลี่ยนแปลงแบบอักษรทั่วงานนำเสนอโดยไม่มีเงื่อนไข ให้ดูที่ [การแทนที่แบบอักษร](/slides/th/net/font-replacement/)
{{% /alert %}}

## **ข้อจำกัดสำหรับแบบอักษรสมการคณิตศาสตร์**

กฎการแทนที่แบบอักษรเป็นส่วนหนึ่งของกระบวนการเลือกแบบอักษรมาตรฐานที่ใช้ระหว่างการเรนเดอร์และการแปลง ทำงานได้กับข้อความธรรมดาเมื่อ Aspose.Slides สามารถแทนที่แบบอักษรที่เข้าถึงไม่ได้ด้วยแบบอักษรที่ระบุในกฎ

สมการ Office Math มีข้อกำหนดพิเศษ หากสมการใช้ **Cambria Math** Aspose.Slides อาจจำเป็นต้องใช้แบบอักษรนั้นอย่างแม่นยำเพื่อคำนวณและเรนเดอร์โครงสร้างสมการ กฎที่แทนที่ด้วยแบบอักษรคณิตศาสตร์อื่นเช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** สำหรับวัตถุประสงค์นี้ได้ และการเรนเดอร์อาจยังรายงานว่าต้องการ **Cambria Math**

ในการเรนเดอร์หรือแปลงงานนำเสนอดังกล่าว ให้ทำให้ **Cambria Math** มีอยู่ใน Aspose.Slides ติดตั้งแบบอักษรนี้ในระบบปฏิบัติการหรือโหลดเป็น [แบบอักษรภายนอก](/slides/th/net/custom-font/)

ข้อจำกัดนี้ใช้กับการจัดรูปแบบสมการเท่านั้น กฎการแทนที่ที่อธิบายข้างต้นยังคงใช้กับข้อความทั่วไปในงานนำเสนอ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างการแทนที่แบบอักษรและการแทนที่แบบอักษรคืออะไร?**

[Font replacement](/slides/th/net/font-replacement/) เปลี่ยนแบบอักษรหนึ่งเป็นอีกแบบหนึ่งทั่วงานนำเสนออย่างตั้งใจ การแทนที่แบบอักษรเลือกแบบอักษรสำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดตรงตามที่ตั้งค่า เช่น เมื่อแบบอักษรต้นฉบับไม่มีอยู่

**กฎการแทนที่ถูกนำไปใช้เมื่อใด?**

กฎเข้าร่วมใน [font selection sequence](/slides/th/net/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง ด้วย `WhenInaccessible` กฎจะใช้เฉพาะเมื่​อ Aspose.Slides ไม่สามารถเข้าถึงแบบอักษรต้นฉบับได้

**จะเกิดอะไรขึ้นเมื่อแบบอักษรหายและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกแบบอักษรที่ใกล้เคียงที่สุดตามกระบวนการเลือกแบบอักษรของมัน ผลลัพธ์ขึ้นอยู่กับแบบอักษรที่มีอยู่ในสภาพแวดล้อมการทำงาน

**ฉันสามารถโหลดแบบอักษรภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**

ใช่ คุณสามารถ [load external fonts](/slides/th/net/custom-font/) เพื่อให้ Aspose.Slides ใช้แบบอักษรเหล่านั้นระหว่างการเรนเดอร์และการแปลง

**Aspose แจกจ่ายแบบอักษรพร้อมไลบรารีหรือไม่?**

ไม่ คุณต้องรับผิดชอบในการจัดหาแบบอักษรและปฏิบัติตามใบอนุญาตของแบบอักษรเหล่านั้น

**ผลลัพธ์การแทนที่อาจแตกต่างกันระหว่าง Windows, Linux และ macOS หรือไม่?**

ใช่ แบบอักษรที่ติดตั้งและตำแหน่งการค้นหาแบบอักษรแตกต่างกันตามระบบปฏิบัติการ ดังนั้นแบบอักษรที่มีอยู่ในเครื่องหนึ่งอาจต้องการการแทนที่ในเครื่องอื่น

**จะทำให้การเลือกแบบอักษรสอดคล้องกันในการแปลงเป็นชุดได้อย่างไร?**

ใช้ไฟล์และเวอร์ชันแบบอักษรเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์ [load required external fonts](/slides/th/net/custom-font/), และ [embed fonts](/slides/th/net/embedded-font/) เมื่อใบอนุญาตอนุญาต คุณยังสามารถเรียกใช้ [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) ก่อนการส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด