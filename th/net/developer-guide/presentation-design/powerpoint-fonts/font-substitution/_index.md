---
title: กำหนดการแทนที่แบบอักษรในงานนำเสนอด้วย .NET
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
description: "กำหนดกฎการแทนที่แบบอักษรและตรวจสอบแบบอักษรที่ถูกแทนที่ใน Aspose.Slides สำหรับ .NET เมื่อทำการแสดงผลหรือแปลงงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

การแทนที่แบบอักษรทำให้ Aspose.Slides สามารถใช้แบบอักษรที่มีอยู่แทนแบบอักษรที่ไม่สามารถเข้าถึงได้เมื่อมีการแสดงผลหรือแปลงการนำเสนอ การแทนที่มีผลต่อผลลัพธ์ที่แสดงออก; แต่ไม่ได้เปลี่ยนแบบอักษรที่กำหนดให้กับเนื้อหาของการนำเสนอ

คุณสามารถกำหนดแบบอักษรที่จะใช้เมื่อแบบอักษรบางตัวไม่พร้อมใช้งานได้ และคุณสามารถตรวจสอบการแทนที่ที่ Aspose.Slides จะทำในระหว่างการแสดงผลได้ สิ่งนี้ช่วยให้ผลลัพธ์คงที่แม้สภาพแวดล้อมที่มีแบบอักษรติดตั้งต่างกัน

## **รับการแทนที่แบบอักษร**

ใช้เมธอด [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getsubstitutions/) เพื่อระบุว่าแบบอักษรใดจะถูกแทนที่เมื่อการนำเสนอแสดงผล เมธอดจะคืนค่าออบเจกต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/net/aspose.slides/fontsubstitutioninfo/) ที่บ่งบอกชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่

ตัวอย่าง C# ด้านล่างแสดงรายการการแทนที่แบบอักษรทั้งหมดสำหรับการนำเสนอ:

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

ใช้เมธอดอีกรุ่นของ [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getsubstitutions/) ที่มีอาร์กิวเมนต์ `int[] slides` เพื่อทำการตรวจสอบเฉพาะการแทนที่ที่จำเป็นสำหรับสไลด์ที่เลือกเท่านั้น ซึ่งมีประโยชน์เมื่อคุณกำลังแสดงผลหรือส่งออกส่วนของการนำเสนอ, ตรวจสอบการนำเสนอขนาดใหญ่แบบขั้นบันได, ค้นหาสไลด์ที่ขึ้นอยู่กับแบบอักษรที่ไม่พร้อมใช้งาน, เตรียมแพ็คเกจแบบอักษรอย่างน้อยสำหรับเซิร์ฟเวอร์หรือคอนเทนเนอร์, หรือวินิจฉัยความแตกต่างในการแสดงผลโดยไม่ต้องประมวลผลสไลด์ที่ไม่เกี่ยวข้อง

อาเรย์ `slides` มีการจัดทำดัชนีสไลด์แบบหนึ่งฐาน: `1` ระบุสไลด์แรก ในทางตรงกันข้าม ตัวบ่งชี้ดัชนีของคอลเลกชัน [Presentation.Slides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slides/th/) เป็นศูนย์ฐาน ดังนั้นสไลด์เดียวกันจะเข้าถึงด้วย `presentation.Slides[0]` ควรคำนึงถึงความแตกต่างนี้เมื่อตั้งค่าอาเรย์เพื่อหลีกเลี่ยงข้อผิดพลาดแบบ off-by-one

เรียกใช้เมธอดอีกรุ่นผ่านคุณสมบัติ [Presentation.FontsManager](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/fontsmanager/) วิธีนี้จะคืนค่าการแทนที่ที่กำหนดในระหว่างการแสดงผลสไลด์ที่เลือกเท่านั้น แต่ละผลลัพธ์เป็นออบเจกต์ [FontSubstitutionInfo](https://reference.aspose.com/slides/th/net/aspose.slides/fontsubstitutioninfo/) ที่มีชื่อแบบอักษรต้นฉบับและแบบอักษรที่แทนที่ ผลลัพธ์สะท้อนสภาพแวดล้อมแบบอักษรปัจจุบัน, กฎ fallback ที่กำหนด, กฎการแทนที่ที่จัดเก็บใน [IFontSubstRuleCollection](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsubstrulecollection/), และ [externally loaded fonts](/slides/th/net/custom-font/).

การแทนที่เดียวกันอาจจำเป็นสำหรับสไลด์ที่เลือกหลายสไลด์ การกำจัดสำเนาซ้ำของผลลัพธ์จะเป็นประโยชน์เมื่อคุณสร้างรายการแบบอักษรหรือรายงานการตรวจสอบ ตัวอย่างด้านล่างแสดงการรายงานการแทนที่ที่คืนค่าแต่ละครั้งและจากนั้นสร้างรายการที่เรียงลำดับของการแมปแบบอักษรที่ไม่ซ้ำกัน:

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

อินเทอร์เฟซ [IFontsManager](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/) ให้บริการอีกรุ่นทั้งสองแบบ เลือกใช้ตามขอบเขตของการดำเนินการแสดงผล:

| รุ่นอีกรุ่น | ใช้เมื่อ |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | คุณต้องการการแทนที่สำหรับการนำเสนอทั้งหมด |
| [GetSubstitutions](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | คุณต้องการการแทนที่สำหรับช่วงที่เลือก, การตรวจสอบแบบขั้นบันได, หรือการส่งออกบางส่วน |

## **ตั้งค่ากฎการแทนที่แบบอักษร**

เพื่อกำหนดแบบอักษรที่ Aspose.Slides ควรใช้เมื่อแบบอักษรต้นทางไม่พร้อมใช้งาน:

1. โหลดการนำเสนอ
2. สร้างการกำหนดแบบอักษรสำหรับแบบอักษรต้นทางและแบบอักษรทดแทน
3. สร้าง [FontSubstRule](https://reference.aspose.com/slides/th/net/aspose.slides/fontsubstrule/) พร้อมเงื่อนไข [WhenInaccessible](https://reference.aspose.com/slides/th/net/aspose.slides/fontsubstcondition/)
4. เพิ่มกฎเข้าไปใน [FontSubstRuleCollection](https://reference.aspose.com/slides/th/net/aspose.slides/fontsubstrulecollection/)
5. กำหนดคอลเลกชันให้กับคุณสมบัติ [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/fontsubstrulelist/)
6. แสดงผลหรือแปลงการนำเสนอ

ตัวอย่าง C# ด้านล่างแทนที่ `Arial` ด้วย `SomeRareFont` เมื่อ `SomeRareFont` ไม่พร้อมใช้งาน จากนั้นแสดงสไลด์แรกเพื่อยืนยันผลลัพธ์ แบบอักษรทดแทนต้องพร้อมใช้งานสำหรับ Aspose.Slides

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
สำหรับการเปลี่ยนแบบอักษรอย่างไม่มีเงื่อนไขทั่วทั้งการนำเสนอ, ดูที่ [Font Replacement](/slides/th/net/font-replacement/).
{{% /alert %}}

## **ข้อจำกัดสำหรับแบบอักษรสมการคณิตศาสตร์**

กฎการแทนที่แบบอักษรเป็นส่วนหนึ่งของกระบวนการเลือกแบบอักษรมาตรฐานที่ใช้ระหว่างการแสดงผลและการแปลง พวกมันทำงานกับข้อความทั่วไปเมื่อ Aspose.Slides สามารถแทนที่แบบอักษรที่ไม่เข้าถึงได้ด้วยแบบอักษรที่พร้อมใช้งานตามกฎที่กำหนด

สมการ Office Math มีข้อกำหนดเพิ่มเติม หากสมการใช้ **Cambria Math**, Aspose.Slides อาจต้องการแบบอักษรนั้นอย่างแม่นยำเพื่อคำนวณและแสดงผลโครงสร้างของสมการ กฎที่แทนที่ด้วยแบบอักษรคณิตศาสตร์อื่นเช่น **STIX Two Math** ไม่สามารถแทนที่ **Cambria Math** ได้สำหรับวัตถุประสงค์นี้ และการแสดงผลอาจยังคงรายงานว่าต้องการ **Cambria Math**

เพื่อแสดงผลหรือแปลงการนำเสนอเช่นนี้ ให้ทำให้ **Cambria Math** พร้อมใช้งานสำหรับ Aspose.Slides ติดตั้งในระบบปฏิบัติการหรือโหลดเป็น [external font](/slides/th/net/custom-font/)

ข้อจำกัดนี้ใช้กับการจัดวางสมการเท่านั้น กฎการแทนที่ที่อธิบายข้างต้นยังคงใช้กับข้อความทั่วไปของการนำเสนอ

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างการเปลี่ยนแบบอักษรและการแทนที่แบบอักษรคืออะไร?**

[Font replacement](/slides/th/net/font-replacement/) เปลี่ยนแบบอักษรหนึ่งเป็นอีกแบบหนึ่งโดยเจตนาทั่วทั้งการนำเสนอ การแทนที่แบบอักษรเลือกแบบอักษรสำหรับผลลัพธ์ที่แสดงออกเมื่อเงื่อนไขที่กำหนดตรงตามที่ตั้งค่าไว้ เช่น เมื่อแบบอักษรต้นฉบับไม่พร้อมใช้งาน

**กฎการแทนที่จะถูกใช้เมื่อใด?**

กฎเหล่านี้เข้าร่วมใน [font selection sequence](/slides/th/net/font-selection-sequence/) ระหว่างการแสดงผลและการแปลง ด้วย `WhenInaccessible` กฎจะถูกใช้เฉพาะเมื่อ Aspose.Slides ไม่สามารถเข้าถึงแบบอักษรต้นทางได้

**จะเกิดอะไรขึ้นเมื่อแบบอักษรหายไปและไม่มีการกำหนดกฎการแทนที่?**

Aspose.Slides จะเลือกแบบอักษรที่ใกล้เคียงที่สุดที่มีอยู่ตามกระบวนการเลือกแบบอักษรของมัน ผลลัพธ์ขึ้นกับแบบอักษรที่มีในสภาพแวดล้อมรันไทม์

**ฉันสามารถโหลดแบบอักษรภายนอกเพื่อหลีกเลี่ยงการแทนที่ได้หรือไม่?**

ใช่ คุณสามารถ [load external fonts](/slides/th/net/custom-font/) เพื่อให้ Aspose.Slides ใช้ได้ระหว่างการแสดงผลและการแปลง

**Aspose แจกจ่ายแบบอักษรพร้อมไลบรารีหรือไม่?**

ไม่ Aspose ไม่ได้แจกจ่ายแบบอักษรพร้อมไลบรารี คุณต้องรับผิดชอบจัดหาแบบอักษรและปฏิบัติตามสัญญาอนุญาตของแบบอักษร

**การแทนที่อาจแตกต่างระหว่าง Windows, Linux, และ macOS หรือไม่?**

ใช่ แบบอักษรที่ติดตั้งและตำแหน่งการค้นหาแบบอักษรแตกต่างกันตามระบบปฏิบัติการ ดังนั้นแบบอักษรที่พร้อมใช้บนเครื่องหนึ่งอาจต้องการการแทนที่บนเครื่องอื่น

**ฉันทำให้การเลือกแบบอักษรสอดคล้องกันในการแปลงแบบชุดอย่างไร?**

ใช้ไฟล์แบบอักษรและเวอร์ชันเดียวกันบนทุกเครื่องหรือคอนเทนเนอร์, [load required external fonts](/slides/th/net/custom-font/), และ [embed fonts](/slides/th/net/embedded-font/) เมื่ออนุญาตตามสัญญาอนุญาต คุณยังสามารถเรียก [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getsubstitutions/) ก่อนการส่งออกเพื่อระบุการแทนที่ที่ไม่คาดคิด