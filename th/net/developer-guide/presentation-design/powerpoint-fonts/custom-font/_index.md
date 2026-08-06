---
title: กำหนดรูปแบบแบบอักษร PowerPoint ใน .NET
linktitle: แบบอักษรกำหนดเอง
type: docs
weight: 20
url: /th/net/custom-font/
keywords:
- แบบอักษร
- แบบอักษรกำหนดเอง
- แบบอักษรภายนอก
- โหลดแบบอักษร
- จัดการแบบอักษร
- โฟลเดอร์แบบอักษร
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "กำหนดแบบอักษรในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ .NET เพื่อทำให้งานนำเสนอของคุณคมชัดและสอดคล้องกันในทุกอุปกรณ์."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณใช้แบบอักษรกำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดแบบอักษรจากโฟลเดอร์กำหนดเอง ให้แบบอักษรสำหรับงานนำเสนอเฉพาะผ่านแหล่งแบบอักษรระดับเอกสาร หรือโหลดแบบอักษรภายนอกจากข้อมูลไบต์โดยตรง

แบบอักษรที่โหลดจะถูกใช้เมื่องานนำเสนอถูกเรนเดอร์หรือส่งออก เช่นเป็น PDF, ภาพ และรูปแบบที่รองรับอื่น ๆ สิ่งนี้ช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ในสภาพแวดล้อมที่ต่างกัน บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์แบบอักษรที่ Aspose.Slides ใช้และวิธีล้างแคชแบบอักษรหลังจากทำงานกับแบบอักษรภายนอก

การลงทะเบียนแบบอักษรกำหนดเองสำหรับการเรนเดอร์แยกจากการฝังแบบอักษรลงในไฟล์ PPTX หากต้องการให้แบบอักษรถูกเก็บอยู่ในงานนำเสนอเอง จำเป็นต้องใช้คุณสมบัติการฝังแบบอักษรอย่างชัดเจน

{{% alert color="primary" %}} 
Aspose Slides ช่วยให้คุณโหลดแบบอักษรเหล่านี้โดยใช้เมธอด [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/) :

* TrueType (.ttf) และ TrueType Collection (.ttc) แบบอักษร ดูข้อมูลเพิ่มเติมที่ [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) แบบอักษร ดูข้อมูลเพิ่มเติมที่ [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **โหลดแบบอักษรกำหนดเอง**

Aspose.Slides ช่วยให้คุณโหลดแบบอักษรที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ สิ่งนี้ส่งผลต่อผลลัพธ์การส่งออก—เช่นเป็น PDF, ภาพ และรูปแบบที่รองรับอื่น ๆ—เพื่อให้เอกสารที่ได้มีลักษณะคงที่ในสภาพแวดล้อมต่าง ๆ แบบอักษรถูกโหลดจากไดเรกทอรีกำหนดเอง

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์แบบอักษร
2. เรียกเมธอด static [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/) เพื่อโหลดแบบอักษรจากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก [FontsLoader.ClearCache](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/clearcache/) เพื่อทำความสะอาดแคชแบบอักษร

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// กำหนดโฟลเดอร์ที่มีไฟล์แบบอักษรกำหนดเอง.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// โหลดแบบอักษรกำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// เรนเดอร์/ส่งออกงานนำเสนอ (เช่นเป็น PDF, ภาพ, หรือรูปแบบอื่น) โดยใช้แบบอักษรที่โหลดไว้.
presentation.Save("output.pdf", SaveFormat.Pdf);

// ล้างแคชแบบอักษรหลังจากงานเสร็จสิ้น.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/) เพิ่มโฟลเดอร์เพิ่มเติมไปยังเส้นทางค้นหาแบบอักษร แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นแบบอักษร
แบบอักษรถูกเริ่มต้นตามลำดับดังนี้:

1. เส้นทางแบบอักษรเริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **รับโฟลเดอร์แบบอักษรกำหนดเอง**
Aspose.Slides มีเมธอด [GetFontFolders](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/getfontfolders/) เพื่อให้คุณค้นหาโฟลเดอร์แบบอักษร เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์แบบอักษรของระบบ

โค้ด C# นี้แสดงวิธีใช้ [GetFontFolders](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// บรรทัดนี้แสดงโฟลเดอร์ที่ตรวจสอบสำหรับไฟล์แบบอักษร.
// เหล่านั้นคือโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์แบบอักษรของระบบ.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **ระบุแบบอักษรกำหนดเองที่ใช้กับงานนำเสนอ**
Aspose.Slides มีคุณสมบัติ [DocumentLevelFontSources](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/documentlevelfontsources/) เพื่อให้คุณระบุแบบอักษรภายนอกที่ใช้กับงานนำเสนอ

โค้ด C# นี้แสดงวิธีใช้คุณสมบัติ [DocumentLevelFontSources](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/documentlevelfontsources/):

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
    // CustomFont1, CustomFont2, และแบบอักษรจากโฟลเดอร์ assets\fonts & global\fonts รวมถึงโฟลเดอร์ย่อยของมันสามารถใช้ในงานนำเสนอได้
}
```

## **จัดการแบบอักษรจากภายนอก**

Aspose.Slides มีเมธอด [LoadExternalFont](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) เพื่อให้คุณโหลดแบบอักษรภายนอกจากข้อมูลไบต์

โค้ด C# นี้สาธิตกระบวนการโหลดแบบอักษรจากอาร์เรย์ไบต์: 

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // แบบอักษรภายนอกที่โหลดระหว่างอายุการทำงานของงานนำเสนอ
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **คำถามที่พบบ่อย**

**แบบอักษรกำหนดเองส่งผลต่อการส่งออกเป็นทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?**

**ใช่**. แบบอักษรที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก

**แบบอักษรกำหนดเองจะถูกฝังโดยอัตโนมัติในไฟล์ PPTX ที่ได้หรือไม่?**

**ไม่**. การลงทะเบียนแบบอักษรเพื่อการเรนเดอร์ไม่เท่ากับการฝังลงใน PPTX หากต้องการให้แบบอักษรถูกเก็บในไฟล์งานนำเสนอ จำเป็นต้องใช้ [คุณสมบัติการฝัง](/slides/th/net/embedded-font/)อย่างชัดเจน

**ฉันสามารถควบคุมพฤติกรรม fallback เมื่อแบบอักษรกำหนดเองไม่มี glyph บางตัวได้หรือไม่?**

**ได้**. กำหนดค่า [การทดแทนแบบอักษร](/slides/th/net/font-substitution/), [กฎการแทนที่](/slides/th/net/font-replacement/), และ [ชุด fallback](/slides/th/net/fallback-font/) เพื่อระบุอย่างชัดเจนว่าแบบอักษรใดจะใช้เมื่อ glyph ที่ร้องขอไม่พบ

**ฉันสามารถใช้แบบอักษรในคอนเทนเนอร์ Linux/Docker ได้โดยไม่ต้องติดตั้งแบบอักษรทั่วระบบหรือไม่?**

**ได้**. ชี้ไปยังโฟลเดอร์แบบอักษรของคุณเองหรือโหลดแบบอักษรจากอาร์เรย์ไบต์ วิธีนี้จะลบการพึ่งพาโฟลเดอร์แบบอักษรของระบบในภาพคอนเทนเนอร์ออก

> **หมายเหตุสำหรับ Linux/Docker**: เมื่อเรียก `FontsLoader.LoadExternalFonts` ให้ตรวจสอบว่าแต่ละรายการในอาร์เรย์ `directories` มีพาธที่ไม่ว่างและชี้ไปยังไดเรกทอรีที่มีอยู่ หากตัวแปรสภาพแวดล้อมที่ใช้สร้างพาธแบบอักษรถูกกำหนดค่าเป็นค่าว่างหรือไม่มีค่า Aspose.Slides อาจพยายามตีความค่าว่างเป็นพาธเต็ม ทำให้เกิด `System.ArgumentException`.

**เรื่องลิขสิทธิ์ล่ะ—ฉันสามารถฝังแบบอักษรกำหนดเองใด ๆ ได้โดยไม่มีข้อจำกัดหรือไม่?**

**คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์แบบอักษร**. เงื่อนไขต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้ในเชิงพาณิชย์ ควรตรวจสอบข้อตกลงการใช้งาน (EULA) ของแบบอักษรก่อนเผยแพร่ผลลัพธ์