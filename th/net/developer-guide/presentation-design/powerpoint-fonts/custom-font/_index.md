---
title: ปรับแต่งแบบอักษร PowerPoint ใน .NET
linktitle: แบบอักษรที่กำหนดเอง
type: docs
weight: 20
url: /th/net/custom-font/
keywords:
- แบบอักษร
- แบบอักษรที่กำหนดเอง
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
description: "ปรับแต่งแบบอักษรในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ .NET เพื่อให้การนำเสนอของคุณคมชัดและสอดคล้องกันบนอุปกรณ์ใดก็ได้."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณใช้แบบอักษรแบบกำหนดเองในงานนำเสนอได้โดยไม่ต้องติดตั้งบนระบบปฏิบัติการ  
คุณสามารถโหลดแบบอักษรจากโฟลเดอร์ที่กำหนดเอง, ให้แบบอักษรสำหรับงานนำเสนอเฉพาะผ่านแหล่งแบบอักษรระดับเอกสาร, หรือโหลดแบบอักษรภายนอกโดยตรงจากข้อมูลไบนารี  

แบบอักษรที่โหลดจะถูกใช้เมื่อทำการเรนเดอร์หรือส่งออกรายงานงานนำเสนอ เช่น เป็น PDF, รูปภาพ, และรูปแบบอื่นที่รองรับ  
สิ่งนี้ช่วยให้ผลลัพธ์ของงานนำเสนอคงที่สม่ำเสมอระหว่างสภาพแวดล้อมที่แตกต่างกัน  
บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์แบบอักษรที่ใช้โดย Aspose.Slides และวิธีล้างแคชแบบอักษรหลังจากทำงานกับแบบอักษรภายนอก  

การลงทะเบียนแบบอักษรแบบกำหนดเองสำหรับการเรนเดอร์จะแยกจากการฝังแบบอักษรลงในไฟล์ PPTX  
หากจำเป็นต้องเก็บแบบอักษรไว้ในงานนำเสนอเอง ให้ใช้คุณสมบัติการฝังแบบอักษรอย่างชัดเจน  

{{% alert color="info" %}} 
Aspose Slides ให้คุณโหลดแบบอักษรเหล่านี้โดยใช้เมธอด [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/) :

* ฟอนต์ TrueType (.ttf) และ TrueType Collection (.ttc) ดูที่ [TrueType](https://en.wikipedia.org/wiki/TrueType).
* ฟอนต์ OpenType (.otf) ดูที่ [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **โหลดแบบอักษรที่กำหนดเอง**

Aspose.Slides ช่วยให้คุณโหลดแบบอักษรที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ การนี้มีผลต่อผลลัพธ์การส่งออก เช่น PDF, รูปภาพ, และรูปแบบอื่นที่รองรับ เพื่อให้เอกสารที่ได้ดูสอดคล้องกันข้ามสภาพแวดล้อม แบบอักษรถูกโหลดจากไดเรกทอรีที่กำหนดเอง  

1. ระบุหนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์แบบอักษร  
2. เรียกเมธอดสแตติก [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/) เพื่อโหลดแบบอักษรจากโฟลเดอร์เหล่านั้น  
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ  
4. เรียก [FontsLoader.ClearCache](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/clearcache/) เพื่อล้างแคชแบบอักษร  

ตัวอย่างโค้ดต่อไปนี้แสดงกระบวนการโหลดแบบอักษร:  

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// กำหนดโฟลเดอร์ที่มีไฟล์แบบอักษรที่กำหนดเอง.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// โหลดแบบอักษรที่กำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// เรนเดอร์/ส่งออกงานนำเสนอ (เช่นเป็น PDF, รูปภาพ, หรือรูปแบบอื่น) ด้วยแบบอักษรที่โหลด.
presentation.Save("output.pdf", SaveFormat.Pdf");

// ล้างแคชแบบอักษรหลังจากทำงานเสร็จ.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

เมธอด [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfonts/) เพิ่มโฟลเดอร์เพิ่มเติมลงในเส้นทางการค้นหาแบบอักษร แต่ไม่ได้เปลี่ยนลำดับการเริ่มต้นแบบอักษร  
แบบอักษรถูกเริ่มต้นตามลำดับนี้:

1. เส้นทางแบบอักษรเริ่มต้นของระบบปฏิบัติการ  
1. เส้นทางที่โหลดผ่าน [FontsLoader](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/).  

{{%/alert %}}

## **รับโฟลเดอร์แบบอักษรที่กำหนดเอง**

Aspose.Slides มีเมธอด [GetFontFolders](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/getfontfolders/) เพื่อให้คุณค้นหาโฟลเดอร์แบบอักษร เมธอดนี้จะคืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด `LoadExternalFonts` และโฟลเดอร์แบบอักษรของระบบ  

โค้ด C# ตัวอย่างนี้แสดงวิธีใช้ [GetFontFolders](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/getfontfolders/):  

```c#
using Aspose.Slides;

// บรรทัดนี้แสดงโฟลเดอร์ที่ตรวจสอบสำหรับไฟล์แบบอักษร.
// เหล่านั้นเป็นโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์แบบอักษรของระบบ.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **ระบุแบบอักษรที่กำหนดเองที่ใช้กับงานนำเสนอ**

Aspose.Slides มีคุณสมบัติ [DocumentLevelFontSources](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/documentlevelfontsources/) เพื่อให้คุณระบุแบบอักษรภายนอกที่จะใช้กับงานนำเสนอ  

โค้ด C# ตัวอย่างนี้แสดงวิธีใช้ [DocumentLevelFontSources](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/documentlevelfontsources/):  

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
    // CustomFont1, CustomFont2, และแบบอักษรจากโฟลเดอร์ assets\fonts & global\fonts รวมถึงโฟลเดอร์ย่อยของมัน สามารถใช้ในงานนำเสนอได้
}
```

## **จัดการแบบอักษรจากภายนอก**

Aspose.Slides มีเมธอด [LoadExternalFont](https://reference.aspose.com/slides/th/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) เพื่อให้คุณโหลดแบบอักษรภายนอกจากข้อมูลไบนารี  

โค้ด C# ตัวอย่างนี้แสดงกระบวนการโหลดแบบอักษรจากอาร์เรย์ไบต์:  

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // แบบอักษรภายนอกที่โหลดระหว่างอายุการใช้งานของงานนำเสนอ
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **คำถามที่พบบ่อย**

**แบบอักษรที่กำหนดเองมีผลต่อการส่งออกไปยังทุกรูปแบบ (PDF, PNG, SVG, HTML) หรือไม่?**  
ใช่. แบบอักษรที่เชื่อมต่อจะถูกใช้โดยเรนเดอร์ในทุกรูปแบบการส่งออก.  

**แบบอักษรที่กำหนดเองจะถูกฝังโดยอัตโนมัติใน PPTX ที่ได้หรือไม่?**  
ไม่. การลงทะเบียนแบบอักษรเพื่อการเรนเดอร์ไม่เท่ากับการฝังลงใน PPTX หากคุณต้องการให้แบบอักษรถูกบรรจุอยู่ในไฟล์งานนำเสนอ ต้องใช้ [คุณสมบัติการฝัง](/slides/th/net/embedded-font/) อย่างชัดเจน.  

**ฉันสามารถควบคุมพฤติกรรม fallback เมื่อแบบอักษรที่กำหนดเองขาด glyph บางตัวได้หรือไม่?**  
ใช่. กำหนดค่า [การทดแทนแบบอักษร](/slides/th/net/font-substitution/), [กฎการแทนที่](/slides/th/net/font-replacement/), และ [ชุด fallback](/slides/th/net/fallback-font/) เพื่อระบุอย่างชัดเจนว่าแบบอักษรใดจะใช้เมื่อ glyph ที่ร้องขอไม่มีอยู่.  

**ฉันสามารถใช้แบบอักษรในคอนเทนเนอร์ Linux/Docker ได้โดยไม่ต้องติดตั้งระบบทั้งหมดหรือไม่?**  
ใช่. ชี้ไปที่โฟลเดอร์แบบอักษรของคุณเองหรือโหลดแบบอักษรจากอาร์เรย์ไบต์ วิธีนี้จะตัดการพึ่งพาไดเรกทอรีแบบอักษรของระบบในอิมเมจคอนเทนเนอร์ออกไป.  

> **หมายเหตุสำหรับ Linux/Docker**: เมื่อตัวเรียก `FontsLoader.LoadExternalFonts` ให้ตรวจสอบให้แน่ใจว่าทุกค่าในอาเรย์ `directories` มีเส้นทางไม่ว่างและชี้ไปยังไดเรกทอรีที่มีอยู่ หากตัวแปรสภาพแวดล้อมที่ใช้สร้างเส้นทางแบบอักษรถูกกำหนดเป็นค่าว่างหรือไม่ได้กำหนดค่า Aspose.Slides อาจพยายามแปลค่าว่างเป็นเส้นทางเต็ม ทำให้เกิด `System.ArgumentException`.  

**เรื่องลิขสิทธิ์ล่ะ—ฉันสามารถฝังแบบอักษรที่กำหนดเองใดก็ได้โดยไม่มีข้อจำกัดหรือไม่?**  
คุณต้องรับผิดชอบต่อการปฏิบัติตามลิขสิทธิ์ของแบบอักษร เงื่อนไขอาจแตกต่างกัน; บางลิขสิทธิ์ห้ามการฝังหรือการใช้ในเชิงพาณิชย์ ควรตรวจสอบ EULA ของแบบอักษรเสมอก่อนนำผลลัพธ์ไปเผยแพร่.