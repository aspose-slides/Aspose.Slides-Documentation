---
title: ปรับแต่งฟอนท์ PowerPoint ใน .NET
linktitle: ฟอนท์แบบกำหนดเอง
type: docs
weight: 20
url: /th/net/custom-font/
keywords:
- ฟอนท์
- ฟอนท์แบบกำหนดเอง
- ฟอนท์ภายนอก
- โหลดฟอนท์
- จัดการฟอนท์
- โฟลเดอร์ฟอนท์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ปรับแต่งฟอนท์ในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ .NET เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันในทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณใช้ฟอนท์แบบกำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดฟอนท์จากโฟลเดอร์ที่กำหนดเอง, ให้ฟอนท์สำหรับงานนำเสนอเฉพาะผ่านแหล่งฟอนท์ระดับเอกสาร, หรือโหลดฟอนท์ภายนอกจากข้อมูลไบนารีโดยตรง

ฟอนท์ที่โหลดจะถูกใช้เมื่อทำการเรนเดอร์หรือส่งออกงานนำเสนอ เช่น เป็น PDF, ภาพ, และรูปแบบที่สนับสนุนอื่น ๆ ซึ่งช่วยให้ผลลัพธ์ของงานนำเสมอภาคในสภาพแวดล้อมที่ต่างกัน บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์ฟอนท์ที่ Aspose.Slides ใช้และวิธีล้างแคชฟอนท์หลังจากทำงานกับฟอนท์ภายนอก

การลงทะเบียนฟอนท์แบบกำหนดเองสำหรับการเรนเดอร์แตกต่างจากการฝังฟอนท์ลงในไฟล์ PPTX หากต้องการให้ฟอนท์ถูกเก็บไว้ภายในงานนำเสนอให้ใช้คุณสมบัติการฝังฟอนท์อย่างชัดเจน

ธีมของงานนำเสนอสามารถอ้างอิงฟอนท์ฟAMILY ที่ต่างกันสำหรับระบบการเขียนแต่ละระบบ การแมปเหล่านี้เก็บชื่อฟอนท์แต่ไม่ได้ทำการติดตั้งหรือโหลดไฟล์ฟอนท์ ดูที่ [Script-Specific Theme Fonts](/slides/th/net/script-specific-font-mappings/) เพื่อจัดการการแมป และใช้ตัวเลือกการโหลดด้านล่างเพื่อให้ฟอนท์ที่อ้างอิงพร้อมใช้สำหรับการเรนเดอร์ที่สอดคล้องกัน

{{% alert color="info" title="Note" %}}
Aspose Slides อนุญาตให้คุณโหลดฟอนท์เหล่านี้โดยใช้วิธีการ [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/) :

* ฟอนท์ TrueType (.ttf) และ TrueType Collection (.ttc) ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType)
* ฟอนท์ OpenType (.otf) ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType)
{{% /alert %}}

## **โหลดฟอนท์แบบกำหนดเอง**

Aspose.Slides ช่วยให้คุณโหลดฟอนท์ที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ ซึ่งส่งผลต่อผลลัพธ์การส่งออก เช่น PDF, ภาพ, และรูปแบบที่สนับสนุนอื่น ๆ ทำให้เอกสารที่ได้ดูสอดคล้องกันในสภาพแวดล้อมต่าง ๆ ฟอนท์จะถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์ฟอนท์
2. เรียกเมธอดสแตติก [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/) เพื่อโหลดฟอนท์จากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.ClearCache](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/clearcache/) เพื่อล้างแคชฟอนท์

ตัวอย่างโค้ดต่อไปนี้สาธิตกระบวนการโหลดฟอนท์:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// กำหนดโฟลเดอร์ที่มีไฟล์ฟอนท์แบบกำหนดเอง.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// โหลดฟอนท์แบบกำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// เรนเดอร์/ส่งออกงานนำเสนอ (เช่น PDF, ภาพ หรือรูปแบบอื่น) โดยใช้ฟอนท์ที่โหลดแล้ว.
presentation.Save("output.pdf", SaveFormat.Pdf);

// ล้างแคชฟอนท์หลังจากทำงานเสร็จ.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/) เพิ่มโฟลเดอร์เพิ่มเติมในเส้นทางการค้นหาฟอนท์ แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นฟอนท์ ฟอนท์จะถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางฟอนท์เริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/)
{{%/alert %}}

## **รับโฟลเดอร์ฟอนท์ที่กำหนดเอง**

Aspose.Slides มีเมธอด [GetFontFolders](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/getfontfolders/) เพื่อให้คุณค้นหาโฟลเดอร์ฟอนท์ เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์ฟอนท์ของระบบ

โค้ด C# ตัวอย่างต่อไปนี้แสดงวิธีใช้ [GetFontFolders](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// บรรทัดนี้แสดงโฟลเดอร์ที่ตรวจสอบสำหรับไฟล์ฟอนท์.
// โฟลเดอร์เหล่านี้เป็นโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์ฟอนท์ของระบบ.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **ระบุฟอนท์ที่กำหนดเองที่ใช้กับงานนำเสนอ**

Aspose.Slides มีคุณสมบัติ [DocumentLevelFontSources](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/documentlevelfontsources/) เพื่อให้คุณระบุฟอนท์ภายนณะที่จะใช้กับงานนำเสนอ

โค้ด C# ตัวอย่างต่อไปนี้แสดงวิธีใช้คุณสมบัติ [DocumentLevelFontSources](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // ทำงานกับงานนำเสนอ
    // CustomFont1, CustomFont2, และฟอนท์จากโฟลเดอร์ assets\fonts & global\fonts รวมถึงโฟลเดอร์ย่อย มีให้ใช้งานในงานนำเสนอ
}
```

## **จัดการฟอนท์จากภายนอก**

Aspose.Slides มีเมธอด [LoadExternalFont](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) เพื่อให้คุณโหลดฟอนท์ภายนอกจากข้อมูลไบนารี

โค้ด C# ตัวอย่างต่อไปนี้สาธิตกระบวนการโหลดฟอนท์จากอาเรย์ไบต์:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // ฟอนท์ภายนอกที่โหลดในช่วงอายุของงานนำเสนอ
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **คำถามที่พบบ่อย**

**ฟอนท์แบบกำหนดเองมีผลต่อการส่งออกเป็นทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?**

ใช่ ฟอนท์ที่ลงทะเบียนจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก

**ฟอนท์แบบกำหนดเองจะถูกฝังโดยอัตโนมัติในไฟล์ PPTX ที่ได้หรือไม่?**

ไม่ การลงทะเบียนฟอนท์เพื่อการเรนเดอร์ไม่เท่ากับการฝังฟอนท์ลงใน PPTX หากต้องการให้ฟอนท์อยู่ภายในไฟล์งานนำเสนอต้องใช้คุณสมบัติการ [embedding features](/slides/th/net/embedded-font/) อย่างชัดเจน

**ฉันสามารถควบคุมพฤติกรรม fallback เมื่อฟอนท์แบบกำหนดเองไม่มี glyph บางตัวได้หรือไม่?**

ได้ กำหนดค่า [font substitution](/slides/th/net/font-substitution/), [replacement rules](/slides/th/net/font-replacement/), และ [fallback sets](/slides/th/net/fallback-font/) เพื่อระบุฟอนท์ที่ใช้เมื่อ glyph ที่ต้องการไม่มีอยู่

**ฉันสามารถใช้ฟอนท์ในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งบนระบบได้หรือไม่?**

ได้ ชี้ไปยังโฟลเดอร์ฟอนท์ของคุณเองหรือโหลดฟอนท์จากอาเรย์ไบต์ วิธีนี้จะไม่พึ่งพาโฟลเดอร์ฟอนท์ของระบบในภาพคอนเทนเนอร์

> **Note for Linux/Docker**: เมื่อเรียก `FontsLoader.LoadExternalFonts` ให้ตรวจสอบให้แน่ใจว่าแต่ละรายการในอาเรย์ `directories` มีพาธที่ไม่ว่างและชี้ไปยังไดเรกทอรีที่มีอยู่ หากตัวแปรสภาพแวดล้อมที่ใช้สร้างพาธฟอนท์ไม่มีค่าหรือเป็นค่าว่าง Aspose.Slides อาจพยายามตีความค่าว่างเป็นพาธเต็ม ส่งผลให้เกิด `System.ArgumentException`

**เรื่องลิขสิทธิ์—ฉันสามารถฝังฟอนท์แบบกำหนดเองใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?**

คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์ของฟอนท์ เงื่อนไขจะแตกต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้เพื่อการค้า ตรวจสอบ EULA ของฟอนท์ก่อนแจกจ่ายผลลัพธ์เสมอ