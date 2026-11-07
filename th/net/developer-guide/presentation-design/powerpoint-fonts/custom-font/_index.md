---
title: ปรับแต่งฟอนต์ PowerPoint บน .NET
linktitle: ฟอนต์กำหนดเอง
type: docs
weight: 20
url: /th/net/custom-font/
keywords:
- ฟอนต์
- ฟอนต์กำหนดเอง
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
## **Overview**

Aspose.Slides ช่วยให้คุณใช้ฟอนต์กำหนดเองในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบปฏิบัติการ คุณสามารถโหลดฟอนต์จากโฟลเดอร์กำหนดเอง, จัดหาฟอนต์สำหรับงานนำเสนอเฉพาะผ่าน document‑level font sources, หรือโหลดฟอนต์ภายนอกโดยตรงจากข้อมูลไบนารี

ฟอนต์ที่โหลดจะถูกใช้เมื่อเรนเดอร์หรือส่งออกงานนำเสนอ เช่น ไปเป็น PDF, รูปภาพ, และรูปแบบอื่นที่รองรับ ซึ่งช่วยให้ผลลัพธ์ของงานนำเสนอคงที่ในสภาพแวดล้อมต่าง ๆ บทความนี้ยังอธิบายวิธีตรวจสอบโฟลเดอร์ฟอนต์ที่ Aspose.Slides ใช้และวิธีล้างแคชฟอนต์หลังจากทำงานกับฟอนต์ภายนอก

การลงทะเบียนฟอนต์กำหนดเองสำหรับการเรนเดอร์แตกต่างจากการฝังฟอนต์ลงในไฟล์ PPTX หากต้องการให้ฟอนต์ถูกเก็บไว้ภายในงานนำเสนอเอง ให้ใช้คุณสมบัติการฝังฟอนต์อย่างชัดเจน

ธีมของงานนำเสนอสามารถอ้างอิงฟอนต์ตระกูลต่าง ๆ สำหรับระบบการเขียนแต่ละระบบ การแมปเหล่านี้เก็บชื่อฟอนต์แต่ไม่ได้ติดตั้งหรือโหลดไฟล์ฟอนต์ ดูที่[Script‑Specific Theme Fonts](/slides/th/net/script-specific-font-mappings/)เพื่อจัดการการแมป และใช้ตัวเลือกการโหลดด้านล่างเพื่อทำให้ฟอนต์ที่อ้างอิงพร้อมใช้งานสำหรับการเรนเดอร์ที่สอดคล้องกัน

{{% alert color="info" title="Note" %}}
Aspose Slides อนุญาตให้คุณโหลดฟอนต์เหล่านี้โดยใช้เมธอด[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) :

* ฟอนต์ TrueType (.ttf) และ TrueType Collection (.ttc) ดูที่[TrueType](https://en.wikipedia.org/wiki/TrueType)
* ฟอนต์ OpenType (.otf) ดูที่[OpenType](https://en.wikipedia.org/wiki/OpenType)
{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides ช่วยให้คุณโหลดฟอนต์ที่ใช้ในงานนำเสนอโดยไม่ต้องติดตั้งบนระบบ ซึ่งส่งผลต่อผลลัพธ์การส่งออก—เช่น PDF, รูปภาพ, และรูปแบบอื่นที่รองรับ—เพื่อให้เอกสารที่ได้มีลักษณะสม่ำเสมอในสภาพแวดล้อมต่าง ๆ ฟอนต์จะถูกโหลดจากไดเร็กทอรีกำหนดเอง

1. ระบุโฟลเดอร์หนึ่งหรือหลายโฟลเดอร์ที่มีไฟล์ฟอนต์
2. เรียกเมธอดสแตติก[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/)เพื่อโหลดฟอนต์จากโฟลเดอร์เหล่านั้น
3. โหลดและเรนเดอร์/ส่งออกงานนำเสนอ
4. เรียก[FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/)เพื่อล้างแคชฟอนต์

ตัวอย่างโค้ดต่อไปแสดงกระบวนการโหลดฟอนต์:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// กำหนดโฟลเดอร์ที่บรรจุไฟล์ฟอนต์กำหนดเอง.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// โหลดฟอนต์กำหนดเองจากโฟลเดอร์ที่ระบุ.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// เรนเดอร์/ส่งออกงานนำเสนอ (เช่น ไปยัง PDF, รูปภาพ, หรือรูปแบบอื่น) ด้วยฟอนต์ที่โหลดแล้ว.
presentation.Save("output.pdf", SaveFormat.Pdf);

// ล้างแคชฟอนต์หลังจากงานเสร็จสิ้น.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) เพิ่มโฟลเดอร์เพิ่มเติมไปยังเส้นทางค้นหาฟอนต์ แต่ไม่เปลี่ยนลำดับการเริ่มต้นฟอนต์ ฟอนต์จะถูกเริ่มต้นตามลำดับนี้ :

1. เส้นทางฟอนต์เริ่มต้นของระบบปฏิบัติการ
1. เส้นทางที่โหลดผ่าน[FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/)
{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides มีเมธอด[GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)เพื่อให้คุณค้นหาโฟลเดอร์ฟอนต์ เมธอดนี้คืนค่าโฟลเดอร์ที่เพิ่มผ่านเมธอด`LoadExternalFonts`และโฟลเดอร์ฟอนต์ของระบบ

โค้ด C# ด้านล่างแสดงวิธีใช้[GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// บรรทัดนี้แสดงโฟลเดอร์ที่ตรวจสอบไฟล์ฟอนต์.
// เหล่านั้นคือโฟลเดอร์ที่เพิ่มผ่านเมธอด LoadExternalFonts และโฟลเดอร์ฟอนต์ของระบบ.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides มีคุณสมบัติ[DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/)เพื่อให้คุณระบุฟอนต์ภายนอกที่ใช้กับงานนำเสนอ

โค้ด C# ด้านล่างแสดงวิธีใช้คุณสมบัติ[DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):

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
    // CustomFont1, CustomFont2, และฟอนต์จากโฟลเดอร์ assets\fonts และ global\fonts รวมถึงโฟลเดอร์ย่อยของพวกมัน สามารถใช้ได้ในงานนำเสนอ
}
```

## **Manage Fonts Externally**

Aspose.Slides มีเมธอด[LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data)เพื่อให้คุณโหลดฟอนต์ภายนอกจากข้อมูลไบนารี

โค้ด C# ด้านล่างแสดงกระบวนการโหลดฟอนต์จากอาร์เรย์ไบต์ :

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // ฟอนต์ภายนอกที่โหลดในช่วงอายุของงานนำเสนอ
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

หากต้องการให้ฟอนต์ที่ลงทะเบียนตรงกันได้รับความสำคัญสูงสุดระหว่างการส่งออกโดยไม่ต้องลบฟอนต์ที่ฝังอยู่ ให้ดูที่[Prefer Registered Fonts over Embedded Fonts](/slides/th/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 หรือใหม่กว่า)

## **FAQ**

**Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?**

Yes. Connected fonts are used by the renderer across all export formats.

**Are custom fonts automatically embedded into the resulting PPTX?**

No. Registering a font for rendering is not the same as embedding it into a PPTX. If you need the font carried inside the presentation file, you must use the explicit[embedding features](/slides/th/net/embedded-font/).

**Can I control fallback behavior when a custom font lacks certain glyphs?**

Yes. Configure[font substitution](/slides/th/net/font-substitution/),[replacement rules](/slides/th/net/font-replacement/), and[fallback sets](/slides/th/net/fallback-font/) to define exactly which font is used when the requested glyph is missing.

**Can I use fonts in Linux/Docker containers without installing them system‑wide?**

Yes. Point to your own font folders or load fonts from byte arrays. This removes any dependency on system font directories in the container image.

> **Note for Linux/Docker**: When calling `FontsLoader.LoadExternalFonts`, ensure that every entry in the `directories` array contains a non‑empty path to an existing directory. If an environment variable used to construct a font path is undefined or empty, Aspose.Slides may attempt to resolve the empty value as a full path, resulting in `System.ArgumentException`.

**What about licensing—can I embed any custom font without restrictions?**

You are responsible for font licensing compliance. Terms vary; some licenses prohibit embedding or commercial use. Always review the font’s EULA before distributing outputs.