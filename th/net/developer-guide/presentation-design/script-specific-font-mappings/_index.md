---
title: จัดการแบบอักษรธีมที่เจาะจงสคริปต์ใน .NET
linktitle: แบบอักษรธีมที่เจาะจงสคริปต์
type: docs
weight: 15
url: /th/net/script-specific-font-mappings/
keywords:
- แบบอักษรที่เจาะจงสคริปต์
- การแมปแบบอักษรธีม
- พรีเซนเทชันหลายภาษา
- ระบบการเขียน
- แบบอักษร Cyrillic
- แบบอักษร Arabic
- แบบอักษร Japanese
- แบบอักษร Georgian
- แบบอักษร Thaana
- PowerPoint
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "ตรวจสอบ, เพิ่ม, แทนที่, และลบการแมปแบบอักษรที่เจาะจงสคริปต์ในธีม PowerPoint ด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

ธีมพรีเซนเทชันสามารถเลือกแบบอักษรที่แตกต่างกันสำหรับระบบการเขียนที่ต่างกันได้ สิ่งนี้ทำให้ข้อความหลายภาษา ที่ยังคงใช้แบบอักษรของธีม สามารถปฏิบัติตามแผนแบบอักษรที่ประสานกันเดียวกัน ขณะใช้แบบอักษรที่เหมาะสมสำหรับ Cyrillic, Arabic, Japanese, Georgian, Thaana และสคริปต์อื่น ๆ

ธีมมี [IFontScheme](https://reference.aspose.com/slides/th/net/aspose.slides.theme/ifontscheme/) ที่ประกอบด้วยคอลเลกชันแบบอักษรหลัก ซึ่งมักใช้สำหรับหัวเรื่อง และคอลเลกชันแบบอักษรรอง ซึ่งมักใช้สำหรับข้อความส่วนหลัก นอกจากนี้ ทั้งสองคอลเลกชันยังเปิดเผยการแมปจากแท็กของระบบการเขียนไปยังชื่อแบบอักษรผ่านอินเทอร์เฟซ [IFonts](https://reference.aspose.com/slides/th/net/aspose.slides/ifonts/)

บทความนี้แสดงวิธีตรวจสอบและแก้ไขการแมปเหล่านั้นในธีมมาสเตอร์ของพรีเซนเทชันและตรวจสอบว่าการเปลี่ยนแปลงเหล่านั้นคงอยู่หลังการบันทึกและโหลดใหม่

## **ทำความเข้าใจแท็กสคริปต์**

เมธอดแบบอักษรสคริปต์ใช้ subtags สคริปต์ BCP 47 ที่มีสี่ตัวอักษรเพื่อระบุตระบบการเขียน ค่าที่พบบ่อยได้แก่:

| Script tag | ระบบการเขียน |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

การแมปเหล่านี้เป็นของโครงการแบบอักษรธีม ไม่ใช่ของส่วนข้อความแต่ละส่วน พรีเซนเทชันอาจกำหนดการแมปที่แตกต่างกันสำหรับคอลเลกชันหลักและรอง และอาจละเว้นการแมปสำหรับสคริปต์บางตัว

## **เข้าถึงและตรวจสอบการแมปแบบอักษรสคริปต์**

ใช้ [Presentation.MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/mastertheme/) เพื่อเข้าถึงธีมระดับพรีเซนเทชัน คุณสมบัติ [FontScheme.Major](https://reference.aspose.com/slides/th/net/aspose.slides.theme/fontscheme/major/) และ [FontScheme.Minor](https://reference.aspose.com/slides/th/net/aspose.slides.theme/fontscheme/minor/) จะคืนค่าคอลเลกชัน [IFonts](https://reference.aspose.com/slides/th/net/aspose.slides/ifonts/) สองชุด

เรียก [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/th/net/aspose.slides/fonts/getscriptfontmap/) เพื่อดึงการแมปทั้งหมดจากคอลเลกชันหนึ่ง เพื่อค้นหาระบบการเขียนหนึ่ง ให้เรียก [IFonts.GetScriptFont](https://reference.aspose.com/slides/th/net/aspose.slides/fonts/getscriptfont/) พร้อมแท็กสคริปต์ของมัน `GetScriptFont` จะคืนค่า `null` เมื่อคอลเลกชันนั้นไม่ได้กำหนดการแมปที่ร้องขอ

## **แก้ไขการแมปและตรวจสอบการคงอยู่**

ใช้ [IFonts.SetScriptFont](https://reference.aspose.com/slides/th/net/aspose.slides/fonts/setscriptfont/) เพื่อสร้างการแมปหรือแทนที่แบบอักษรปัจจุบันของมัน ใช้ [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/th/net/aspose.slides/fonts/removescriptfont/) เพื่อลบการแมป

ตัวอย่างครบวงจรต่อไปนี้จะอ่านการแมปหลักและรองที่มีอยู่ทั้งหมด ค้นหาแบบอักษรหลักของญี่ปุ่น เปลี่ยนแบบอักษรหลักของ Cyrillic ลบการแมปรองของ Thaana บันทึกพรีเซนเทชันและเปิดใหม่เพื่อตรวจสอบการเปลี่ยนแปลงทั้งสอง เพื่อทำให้ขั้นตอนการลบเป็นอิสระจากธีมเริ่มต้น ตัวอย่างจะสร้างการแมป Thaana ก่อนเฉพาะเมื่อยังไม่มีการกำหนดไว้

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

การตรวจสอบใช้พฤติกรรม `null` เดียวกับการค้นหาปกติ: หลังจากการลบถูกบันทึก `GetScriptFont("Thaa")` จะคืนค่า `null` สำหรับคอลเลกشنรอง

## **แยกแยะการแมปธีมจากการตั้งค่าแบบอักษรอื่น ๆ**

การแมปธีมที่เจาะจงสคริปต์มีส่วนร่วมในการเลือกแบบอักษร แต่พวกมันแก้ปัญหาที่แตกต่างจากการจัดรูปแบบข้อความโดยตรง การแทนที่ และการสำรอง:

| กลไก | วัตถุประสงค์ | ผลของการเปลี่ยนแปลงการแมปธีม |
|---|---|---|
| การแมปแบบอักษรธีมที่เจาะจงสคริปต์ | เลือกแบบอักษรธีมหลักหรือรองสำหรับระบบการเขียน | ข้อความที่ยังใช้แบบอักษรธีมที่สอดคล้องสามารถแก้ไขให้เป็นครอบครัวแบบอักษรที่ใหม่ที่แมปไว้ |
| แบบอักษรที่กำหนดโดยชัดเจนให้กับส่วนข้อความ | กำหนดครอบครัวแบบอักษรที่ต้องการบนส่วนนั้นแทนการพึ่งพาธีม | ส่วนนั้นอาจคงที่ไม่เปลี่ยนแปลงเนื่องจากการจัดรูปแบบโดยตรงของมันบังคับเหนือการเลือกของธีม |
| การแทนที่แบบอักษร | แทนที่แบบอักษรที่ร้องขอเมื่อแบบอักษรนั้นไม่มีอยู่หรือเมื่อมีกฎการแทนที่ใช้ | ทำงานหลังจากที่มีการร้องขอแบบอักษร; ไม่ทำการกำหนดการแมปสคริปต์ของธีมใหม่ |
| การสำรองแบบอักษร | จัดหา glyphs ที่แบบอักษรที่เลือกไม่มีอยู่ บ่อยครั้งสำหรับช่วง Unicode เฉพาะ | มันเติมส่วนที่ขาดของ glyph; ไม่เปลี่ยนแปลงการแมปธีมที่จัดเก็บ |

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับสองกลไกสุดท้าย ดูที่ [Font Substitution](/slides/th/net/font-substitution/) และ [Fallback Fonts](/slides/th/net/fallback-font/).

การเปลี่ยนการแมปใน [Presentation.MasterTheme](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/mastertheme/) มีผลต่อเนื้อหาเท่านั้นที่การจัดรูปแบบที่มีผลยังขึ้นอยู่กับธีมนั้น ข้อความอาจสืบทอดการ override ของธีมจากมาสเตอร์, เลย์เอาต์ หรือสไลด์, หรือใช้แบบอักษรที่กำหนดโดยชัดเจน ตรวจสอบระดับเหล่านั้นเมื่อผลลัพธ์ที่แสดงไม่เป็นไปตามการแมประดับพรีเซนเทชัน

## **ทำให้แบบอักษรที่แมปพร้อมใช้งานและตรวจสอบผลลัพธ์**

การแมปสคริปต์จะเก็บชื่อแบบอักษร; ไม่ได้ติดตั้งหรือโหลดไฟล์แบบอักษรที่สอดคล้องกัน สำหรับการเรนเดอร์และการส่งออกที่สม่ำเสมอ แบบอักษรที่แมปทั้งหมดต้องถูกติดตั้งในสภาพแวดล้อมหรือจัดหาให้กับ Aspose.Slides ผ่านแหล่งกำหนดเอง เช่น [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/) หรือ [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/documentlevelfontsources/) ดูที่ [Custom Fonts](/slides/th/net/custom-font/) สำหรับตัวเลือกการโหลดที่มี

การตรวจสอบการแมปที่บันทึกไว้ยืนยันเพียงว่ากำหนดธีมถูกเก็บไว้ ไม่ได้พิสูจน์ว่าแบบอักษรพร้อมใช้งาน, มี glyph ที่ต้องการทั้งหมด, หรือสร้างการจัดวางตามที่ต้องการ แสดงข้อความตัวอย่างสำหรับทุกระบบการเขียนที่ต้องการเป็นภาพหรือ PDF แล้วตรวจสอบผลลัพธ์ สิ่งนี้จะจับแบบอักษรที่หายไป, การครอบคลุม glyph ที่ไม่สมบูรณ์, พฤติกรรม fallback, และการเปลี่ยนแปลงการจัดวางก่อนที่พรีเซนเทชันจะเผยแพร่ ดูที่ [Convert PowerPoint Presentations](/slides/th/net/convert-powerpoint/) สำหรับตัวอย่างการเรนเดอร์และส่งออก

## **คำถามที่พบบ่อย**

**เมธอด `GetScriptFont` คืนค่าอะไรเมื่อสคริปต์ไม่ได้ถูกแมป?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/th/net/aspose.slides/fonts/getscriptfont/) คืนค่า `null` เมื่อการแมปสคริปต์ที่ร้องขอไม่ได้กำหนดในคอลเลกชันแบบอักษรหลักหรือรองนั้น

**`SetScriptFont` เพิ่มการแมปครั้งที่สองเมื่อสคริปต์มีอยู่แล้วหรือไม่?**

ไม่. [IFonts.SetScriptFont](https://reference.aspose.com/slides/th/net/aspose.slides/fonts/setscriptfont/) จะสร้างการแมปเมื่อไม่มีและแทนที่ครอบครัวแบบอักษรที่แมปไว้เมื่อแท็กสคริปต์เดียวกันมีอยู่แล้ว

**ทำไมการเปลี่ยนการแมปธีมไม่ได้เปลี่ยนข้อความบางส่วน?**

ข้อความอาจมีแบบอักษรที่กำหนดโดยชัดเจน, สืบทอดธีมที่แตกต่างผ่านการ override, หรือได้รับผลกระทบจากการแทนที่หรือ fallback ระหว่างการเรนเดอร์ การแมปสคริปต์ระดับพรีเซนเทชันควบคุมเฉพาะข้อความที่การจัดรูปแบบที่มีผลยังอ้างอิงถึงคอลเลกชันแบบอักษรของธีมนั้น

**การบันทึกและเปิดใหม่เพียงพอที่จะตรวจสอบผลลัพธ์หลายภาษาหรือไม่?**

ไม่. การเปิดใหม่ตรวจสอบการคงอยู่ของข้อมูลธีมเท่านั้น นอกจากนี้ให้เรนเดอร์ข้อความตัวอย่างจากแต่ละระบบการเขียนที่ต้องการเพื่อยืนยันว่าแบบอักษรที่แมปไว้พร้อมใช้งานและมี glyph ที่จำเป็น