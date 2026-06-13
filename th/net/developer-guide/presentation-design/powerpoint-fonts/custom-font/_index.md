---
title: ปรับแต่งฟอนต์ PowerPoint ใน .NET
linktitle: ฟอนต์แบบกำหนดเอง
type: docs
weight: 20
url: /th/net/custom-font/
keywords:
- ฟอนต์
- ฟอนต์แบบกำหนดเอง
- ฟอนต์ภายนอก
- โหลดฟอนต์
- จัดการฟอนต์
- โฟลเดอร์ฟอนต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ปรับแต่งฟอนต์ในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ .NET เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันในทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides อนุญาตให้คุณใช้ฟอนต์แบบกำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดฟอนต์จากโฟลเดอร์ที่กำหนดเอง, ให้ฟอนต์สำหรับงานนำเสนอเฉพาะผ่านแหล่งฟอนต์ระดับเอกสาร, หรือโหลดฟอนต์ภายนอกโดยตรงจากข้อมูลไบต์

ฟอนต์ที่โหลดแล้วจะถูกใช้เมื่อทำการเรนเดอร์หรือส่งออกงานนำเสนอ เช่น เป็น PDF, รูปภาพ, และรูปแบบอื่น ๆ ที่สนับสนุน ซึ่งช่วยให้ผลลัพธ์ของงานนำเสมอภาคในสภาพแวดล้อมที่ต่างกัน บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์ฟอนต์ที่ Aspose.Slides ใช้และวิธีล้างแคชฟอนต์หลังจากทำงานกับฟอนต์ภายนอก

การลงทะเบียนฟอนต์แบบกำหนดเองสำหรับการเรนเดอร์จะแยกจากการฝังฟอนต์ลงในไฟล์ PPTX หากต้องการให้ฟอนต์ถูกเก็บอยู่ภายในงานนำเสนอเอง ให้ใช้คุณลักษณะการฝังฟอนต์โดยเฉพาะ

{{% alert color="primary" %}} 
Aspose Slides อนุญาตให้คุณโหลดฟอนต์เหล่านี้โดยใช้เมธอด [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/) :

* TrueType (.ttf) และ TrueType Collection (.ttc) ฟอนต์ ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType) .
* OpenType (.otf) ฟอนต์ ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType) .
{{% /alert %}}

## **โหลดฟอนต์แบบกำหนดเอง**

Aspose.Slides อนุญาตให้คุณโหลดฟอนต์ที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ การทำเช่นนี้มีผลต่อผลลัพธ์การส่งออก เช่น PDF, รูปภาพ, และรูปแบบอื่น ๆ ที่สนับสนุน ทำให้เอกสารที่ได้มีลักษณะสอดคล้องกันในสภาพแวดล้อมต่าง ๆ ฟอนต์จะถูกโหลดจากไดเรกทอรีที่กำหนดเอง

1. ระบุโฟลเดอร์หนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์ฟอนต์
2. เรียกเมธอดสแตติก [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/) เพื่อโหลดฟอนต์จากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.ClearCache](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/clearcache/) เพื่อล้างแคชฟอนต์

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดฟอนต์:

```cs
// กำหนดโฟลเดอร์ที่มีไฟล์ฟอนต์แบบกำหนดเอง.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// โหลดฟอนต์แบบกำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// เรนเดอร์/ส่งออกงานนำเสนอ (เช่น PDF, รูปภาพ หรือรูปแบบอื่น)โดยใช้ฟอนต์ที่โหลด.
presentation.Save("output.pdf", SaveFormat.Pdf);

// ล้างแคชฟอนต์หลังจากทำงานเสร็จ.
FontsLoader.ClearCache();
```

{{% alert color="info" title="หมายเหตุ" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/) เพิ่มโฟลเดอร์เพิ่มเติมไปยังเส้นทางค้นหาฟอนต์ แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นฟอนต์ ฟอนต์จะถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางฟอนต์เริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/) 
{{%/alert %}}

## **รับโฟลเดอร์ฟอนต์แบบกำหนดเอง**

Aspose.Slides มีเมธอด [GetFontFolders](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/getfontfolders/) เพื่อให้คุณค้นหาโฟลเดอร์ฟอนต์ เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์ฟอนต์ระบบ

โค้ด C# นี้แสดงวิธีใช้ [GetFontFolders](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/getfontfolders/) :

```c#
// บรรทัดนี้แสดงโฟลเดอร์ที่ตรวจสอบสำหรับไฟล์ฟอนต์.
// โฟลเดอร์เหล่านั้นคือโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์ฟอนต์ของระบบ.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **ระบุฟอนต์แบบกำหนดเองที่ใช้กับงานนำเสนอ**

Aspose.Slides มีพร็อพเพอร์ตี้ [DocumentLevelFontSources](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/documentlevelfontsources/) เพื่อให้คุณระบุฟอนต์ภายนอกที่ใช้ร่วมกับงานนำเสนอ

โค้ด C# นี้แสดงวิธีใช้พร็อพเพอร์ตี้ [DocumentLevelFontSources](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/documentlevelfontsources/) :

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // ทำงานกับงานนำเสนอ
    // CustomFont1, CustomFont2 และฟอนต์จากโฟลเดอร์ assets\fonts และ global\fonts รวมถึงโฟลเดอร์ย่อยของมันพร้อมใช้งานในงานนำเสนอ
}
```

## **จัดการฟอนต์จากภายนอก**

Aspose.Slides มีเมธอด [LoadExternalFont](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) เพื่อให้คุณโหลดฟอนต์ภายนอกจากข้อมูลไบต์

โค้ด C# นี้แสดงกระบวนการโหลดฟอนต์จากอาร์เรย์ไบต์ :

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // ฟอนต์ภายนอกที่โหลดในระยะเวลาการนำเสนอ
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **คำถามที่พบบ่อย**

**ฟอนต์แบบกำหนดเองมีผลต่อการส่งออกไปยังรูปแบบทั้งหมด (PDF, PNG, SVG, HTML) หรือไม่?**

ใช่ ฟอนต์ที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในการส่งออกทุกรูปแบบ

**ฟอนต์แบบกำหนดเองจะถูกฝังอัตโนมัติในไฟล์ PPTX ที่ได้หรือไม่?**

ไม่ การลงทะเบียนฟอนต์เพื่อการเรนเดอร์ไม่เท่ากับการฝังฟอนต์ลงใน PPTX หากต้องการให้ฟอนต์อยู่ในไฟล์งานนำเสนอ ต้องใช้คุณลักษณะการฝังฟอนต์โดยชัดเจน ([embedding features](/slides/th/net/embedded-font/))

**ฉันสามารถควบคุมพฤติกรรม fallback เมื่อฟอนต์แบบกำหนดเองขาด glyph บางตัวได้หรือไม่?**

ได้ ตั้งค่า [font substitution](/slides/th/net/font-substitution/), [replacement rules](/slides/th/net/font-replacement/), และ [fallback sets](/slides/th/net/fallback-font/) เพื่อกำหนดฟอนต์ที่ใช้เมื่อ glyph ที่ต้องการไม่มีอยู่

**ฉันสามารถใช้ฟอนต์ในคอนเทนเนอร์ Linux/Docker โดยไม่ต้องติดตั้งบนระบบได้หรือไม่?**

ได้ เพียงระบุโฟลเดอร์ฟอนต์ของคุณเองหรือโหลดฟอนต์จากอาร์เรย์ไบต์ ซึ่งจะลบการพึ่งพาโฟลเดอร์ฟอนต์ระบบออกจากอิมเมจคอนเทนเนอร์

**เรื่องลิขสิทธิ์—ฉันสามารถฝังฟอนต์แบบกำหนดเองใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?**

คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์ฟอนต์ เงื่อนไขอาจต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้เชิงพาณิชย์ ควรตรวจสอบ EULA ของฟอนต์ก่อนเผยแพร่ผลลัพธ์