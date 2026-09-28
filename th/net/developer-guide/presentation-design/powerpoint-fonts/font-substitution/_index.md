---
title: กำหนดการแทนที่ฟอนต์ในงานนำเสนอใน .NET
linktitle: การแทนที่ฟอนต์
type: docs
weight: 70
url: /th/net/font-substitution/
keywords:
- ฟอนต์
- ฟอนต์ที่แทน
- การแทนที่ฟอนต์
- เปลี่ยนฟอนต์
- การเปลี่ยนฟอนต์
- กฎการแทนที่
- กฎการเปลี่ยน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "กำหนดกฎการแทนที่ฟอนต์และตรวจสอบฟอนต์ที่ถูกแทนใน Aspose.Slides สำหรับ .NET เมื่อทำการเรนเดอร์หรือแปลงงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การแทนที่ฟอนต์ทำให้ Aspose.Slides สามารถใช้ฟอนต์ที่มีอยู่แทนฟอนต์ที่ไม่สามารถเข้าถึงได้เมื่อทำการเรนเดอร์หรือแปลงงานนำเสนอ การแทนที่จะส่งผลต่อผลลัพธ์ที่เรนเดอร์เท่านั้น; ไม่ได้เปลี่ยนฟอนต์ที่กำหนดให้กับเนื้อหาของงานนำเสนอ

คุณสามารถกำหนดฟอนต์ที่จะใช้เมื่อฟอนต์บางตัวไม่พร้อมใช้งานได้ และคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำระหว่างการเรนเดอร์ สิ่งนี้ช่วยให้ผลลัพธ์คงที่สม่ำเสมอระหว่างสภาพแวดล้อมที่มีฟอนต์ติดตั้งต่างกัน

## **รับการแทนที่ฟอนต์**

ใช้เมธอด [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getsubstitutions/) เพื่อระบุว่าฟอนต์ใดจะถูกแทนที่เมื่อทำการเรนเดอร์งานนำเสนอ เมธอดนี้จะคืนค่าอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/net/aspose.slides/fontsubstitutioninfo/) ที่ระบุชื่อฟอนต์ต้นฉบับและฟอนต์ที่แทน

ตัวอย่าง C# ด้านล่างนี้แสดงรายการการแทนที่ฟอนต์ทั้งหมดสำหรับงานนำเสนอ:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **รับการแทนที่ฟอนต์สำหรับสไลด์ที่เลือก**

ใช้โอเวอร์โหลดของ [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getsubstitutions/) พร้อมอาร์กิวเมนต์ `int[] slides` เพื่อตรวจสอบการแทนที่ที่จำเป็นสำหรับการเรนเดอร์สไลด์เฉพาะเท่านั้น สิ่งนี้มีประโยชน์เมื่อคุณกำลังเรนเดอร์หรือส่งออกส่วนของงานนำเสนอ, ตรวจสอบงานนำเสนอขนาดใหญ่เป็นขั้นตอน, ค้นหาสไลด์ที่ขึ้นอยู่กับฟอนต์ที่ไม่พร้อมใช้งาน, เตรียมชุดฟอนต์ขนาดเล็กสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์, หรือวินิจฉัยความแตกต่างในการเรนเดอร์โดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

อาร์เรย์ `slides` มีดัชนีสไลด์แบบเริ่มจากหนึ่ง: `1` ระบุสไลด์แรก ในทางตรงกันข้าม ตัวดัชนีของคอลเลกชัน [Presentation.Slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slides/th/) ใช้การเริ่มจากศูนย์ ดังนั้นสไลด์เดียวกันจะเข้าถึงได้ด้วย `presentation.Slides[0]` โปรดคำนึงถึงความแตกต่างนี้เมื่อตรวจสอบอาร์เรย์เพื่อหลีกเลี่ยงข้อผิดพลาดแบบ off-by-one

เรียกโอเวอร์โหลดผ่านคุณสมบัติ [Presentation.FontsManager](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/fontsmanager/) จะคืนค่าการแทนที่ที่กำหนดในระหว่างการเรนเดอร์สไลด์ที่เลือกเท่านั้น แต่ละผลลัพธ์เป็นอ็อบเจ็กต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/net/aspose.slides/fontsubstitutioninfo/) ที่บรรจุชื่อฟอนต์ต้นฉบับและฟอนต์ที่แทน ผลลัพธ์สะท้อนสภาพแวดล้อมฟอนต์ปัจจุบันและ [ฟอนต์ที่โหลดจากภายนอก](/slides/th/net/custom-font/) กฎการแทนที่ที่เก็บไว้ใน [IFontSubstRuleCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsubstrulecollection/) จะเปลี่ยนผลลัพธ์ที่เรนเดอร์แต่ไม่ได้สะท้อนในผลลัพธ์

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ ให้ลบรายการซ้ำของผลลัพธ์เมื่อคุณสร้างรายการตรวจเช็ครายการฟอนต์หรือรายงาน preflight ตัวอย่างต่อไปนี้แสดงการรายงานการแทนที่ที่คืนค่าแต่ละรายการและจากนั้นสร้างรายการเรียงลำดับของการแมปฟอนต์ที่ไม่ซ้ำกัน:

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

อินเทอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/) มีโอเวอร์โหลดทั้งสองแบบ ให้เลือกตามขอบเขตของการดำเนินการเรนเดอร์:

| โอเวอร์โหลด | ใช้เมื่อ |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | คุณต้องการการแทนที่สำหรับงานนำเสนอทั้งหมด. |
| [GetSubstitutions](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | คุณต้องการการแทนที่สำหรับช่วงที่เลือก, การตรวจสอบแบบขั้นตอน, หรือการส่งออกบางส่วน. |

## **ตั้งค่ากฎการแทนที่ฟอนต์**

เพื่อระบุฟอนต์ที่ Aspose.Slides ควรใช้เมื่อฟอนต์ต้นทางไม่พร้อมใช้งาน:

1. โหลดงานนำเสนอ
2. สร้างการกำหนดฟอนต์สำหรับฟอนต์ต้นทางและฟอนต์แทน
3. สร้าง [FontSubstRule](https://reference.aspose.com/slides/th/net/aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/th/net/aspose.slides/fontsubstcondition/)
4. เพิ่มกฎเข้าไปใน [FontSubstRuleCollection](https://reference.aspose.com/slides/th/net/aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันให้กับคุณสมบัติ [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/fontsubstrulelist/)
6. เรนเดอร์หรือแปลงงานนำเสนอ

ตัวอย่าง C# ด้านล่างนี้แทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่พร้อมใช้งาน และจากนั้นเรนเดอร์สไลด์แรกเพื่อยืนยันผลลัพธ์ ฟอนต์แทนที่ต้องมีอยู่ใน Aspose.Slides.

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
สำหรับการเปลี่ยนฟอนต์โดยไม่มีเงื่อนไขทั้งหมดในงานนำเสนอ ดูที่ [Font Replacement](/slides/th/net/font-replacement/).
{{% /alert %}}

## **ข้อจำกัดสำหรับฟอนต์สมการคณิตศาสตร์**

กฎการแทนที่ฟอนต์เป็นส่วนหนึ่งของกระบวนการเลือกฟอนต์มาตรฐานที่ใช้ระหว่างการเรนเดอร์และการแปลง ทำงานกับข้อความทั่วไปเมื่อ Aspose.Slides สามารถแทนที่ฟอนต์ที่ไม่สามารถเข้าถึงได้ด้วยฟอนต์ที่มีตามที่กฎระบุ

สมการ Office Math มีความต้องการเพิ่มเติม หากสมการใช้ **Cambria Math** Aspose.Slides อาจต้องการฟอนต์นั้นอย่างแม่นยำเพื่อคำนวณและเรนเดอร์โครงสร้างสมการ กฎที่แทนที่ด้วยฟอนต์คณิตศาสตร์อื่น เช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** เพื่อวัตถุประสงค์นี้ได้ และการเรนเดอร์อาจยังรายงานว่าต้องการ **Cambria Math**

เพื่อเรนเดอร์หรือแปลงงานนำเสนอที่มีลักษณะนี้ ให้ทำให้ **Cambria Math** พร้อมใช้งานกับ Aspose.Slides ติดตั้งในระบบปฏิบัติการหรือโหลดเป็น [external font](/slides/th/net/custom-font/).

ข้อจำกัดนี้ใช้กับการจัดรูปแบบสมการ ส่วนกฎการแทนที่ที่อธิบายข้างต้นยังคงใช้กับข้อความทั่วไปของงานนำเสนอ

## **คำถามที่พบบ่อย**

**อะไรคือความแตกต่างระหว่างการเปลี่ยนฟอนต์และการแทนที่ฟอนต์?**

[Font replacement](/slides/th/net/font-replacement/) เปลี่ยนฟอนต์จากหนึ่งเป็นอีกฟอนต์หนึ่งอย่างตั้งใจทั่วทั้งงานนำเสนอ การแทนที่ฟอนต์เลือกฟอนต์สำหรับผลลัพธ์ที่เรนเดอร์เมื่อเงื่อนไขที่กำหนดเป็นจริง เช่น เมื่อฟอนต์ต้นฉบับไม่พร้อมใช้งาน.

**กฎการแทนที่ฟอนต์จะถูกนำมาใช้เมื่อใด?**

กฎเหล่านี้มีส่วนร่วมใน [font selection sequence](/slides/th/net/font-selection-sequence/) ระหว่างการเรนเดอร์และการแปลง โดยใช้ `WhenInaccessible` กฎจะใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงฟอนต์ต้นทางได้.

**จะเกิดอะไรขึ้นเมื่อฟอนต์หายไปและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกฟอนต์ที่ใกล้เคียงที่สุดที่มีอยู่ตามกระบวนการเลือกฟอนต์ของมัน ผลลัพธ์ขึ้นอยู่กับฟอนต์ที่มีในสภาพแวดล้อมการทำงาน.

**ฉันสามารถโหลดฟอนต์จากภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**

ได้ คุณสามารถ [load external fonts](/slides/th/net/custom-font/) เพื่อให้ Aspose.Slides ใช้งานได้ในระหว่างการเรนเดอร์และการแปลง.

**Aspose แจกจ่ายฟอนต์พร้อมกับไลบรารีหรือไม่?**

ไม่มี คุณต้องรับผิดชอบในการจัดหาฟอนต์และปฏิบัติตามล licenses ของฟอนต์เหล่านั้น.

**ผลลัพธ์การแทนที่อาจแตกต่างกันระหว่าง Windows, Linux, และ macOS หรือไม่?**

ใช่ ฟอนต์ที่ติดตั้งและตำแหน่งการค้นหาฟอนต์จะแตกต่างกันตามระบบปฏิบัติการ ดังนั้นฟอนต์ที่มีบนเครื่องหนึ่งอาจต้องการการแทนที่บนเครื่องอื่น.

**ฉันจะทำให้การเลือกฟอนต์สม่ำเสมอในการแปลงแบบแบตช์ได้อย่างไร?**

ใช้ไฟล์ฟอนต์และรุ่นเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์, [load required external fonts](/slides/th/net/custom-font/), และ [embed fonts](/slides/th/net/embedded-font/) เมื่อได้รับอนุญาตตามลิขสิทธิ์ คุณยังสามารถเรียก [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getsubstitutions/) ก่อนการส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด.