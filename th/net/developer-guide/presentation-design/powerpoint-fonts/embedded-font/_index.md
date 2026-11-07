---
title: ฝังฟอนต์ในงานนำเสนอใน .NET
linktitle: ฟอนต์ที่ฝังไว้
type: docs
weight: 40
url: /th/net/embedded-font/
keywords:
- เพิ่มฟอนต์
- ฝังฟอนต์
- การฝังฟอนต์
- ดึงฟอนต์ที่ฝังไว้
- เพิ่มฟอนต์ที่ฝังไว้
- ลบฟอนต์ที่ฝังไว้
- บีบอัดฟอนต์ที่ฝังไว้
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการฟอนต์ที่ฝังไว้ใน PowerPoint ด้วย Aspose.Slides สำหรับ .NET ใช้ C# เพื่อเพิ่ม, ดึง, ลบ และบีบอัดฟอนต์เพื่อรักษารูปลักษณ์ของข้อความและลดขนาดไฟล์."
---
## **บทนำ**

การฝังฟอนต์จะเก็บข้อมูลฟอนต์ไว้ภายในงานนำเสนอ PowerPoint เมื่อโปรแกรมแสดงผลรองรับฟอนต์ที่ฝังไว้ มันสามารถแสดงข้อความด้วยฟอนต์เหล่านั้นแม้ว่าจะไม่ได้ติดตั้งบนระบบเป้าหมาย การทำเช่นนี้ช่วยรักษาการแบ่งบรรทัด, ระยะห่างของข้อความ, และรูปแบบสไลด์ได้

Aspose.Slides for .NET ให้คุณดึง, เพิ่ม, และลบฟอนต์ที่ฝังไว้ผ่านคุณสมบัติ [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) ของ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) คุณยังสามารถลดขนาดข้อมูลฟอนต์ที่ฝังได้โดยลบอักขระที่งานนำเสนอไม่ได้ใช้

ตัวอย่างต่อไปทำงานกับไฟล์ PPTX ก่อนทำการฝังฟอนต์ ให้ตรวจสอบว่าข้อมูลฟอนต์พร้อมใช้งานกับ Aspose.Slides และใบอนุญาตของคุณอนุญาตให้ฝังฟอนต์ได้

## **ดึงและลบฟอนต์ที่ฝังไว้**

ใช้ [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) เพื่อแสดงรายการฟอนต์ที่เก็บอยู่ในงานนำเสนอ เพื่อลบฟอนต์หนึ่ง ให้ส่งฟอนต์จากรายการนั้นไปยัง [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/), แล้วบันทึกงานนำเสนอ

ตัวอย่างต่อไปแสดงรายการฟอนต์ที่ฝังอยู่ใน `EmbeddedFonts.pptx` และลบ Calibri หากพบ:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

การลบฟอนต์ที่ฝังไว้จะลบข้อมูลฟอนต์ที่เก็บไว้; มันไม่ได้เปลี่ยนฟอนต์ที่กำหนดให้กับข้อความ หากฟอนต์ติดตั้งอยู่บนระบบเป้าหมาย ข้อความยังคงใช้ฟอนต์นั้นได้ มิฉะนั้น การแสดงผลอาจต้องอาศัย [font substitution](/slides/th/net/font-substitution/), ซึ่งอาจส่งผลต่อการจัดวาง

## **ตรวจสอบข้อมูลฟอนต์และสิทธิ์การฝัง**

ใช้อินเตอร์เฟส [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) เพื่อตรวจสอบฟอนต์ก่อนทำการฝัง เรียก [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) เพื่อดึงฟอนต์ที่ใช้งานในงานนำเสนอ สำหรับฟอนต์แต่ละตัว ให้ส่งอ็อบเจ็กต์ [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) และค่า [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) ที่ต้องการไปยัง [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/) เมธ็อดจะคืนค่าข้อมูลไบนารีของสไตล์ฟอนต์นั้น หรือ `null` หากฟอนต์หรือสไตล์ที่ร้องขอไม่มีอยู่ อย่าส่งผลลัพธ์ `null` ไปยัง [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/) เพราะเมธ็อดนั้นต้องการอาร์เรย์ไบต์

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) เป็นการกำหนดค่าแบบ flags ที่รายงานข้อจำกัดการฝังที่เก็บไว้ในฟอนต์:

- `Installable` อนุญาตให้ฝังและติดตั้งถาวรบนระบบอื่น ๆ ตามเงื่อนไขของใบอนุญาตฟอนต์
- `Restricted` ห้ามฝังยกเว้นได้รับอนุญาตจากเจ้าของลิขสิทธิ์ฟอนต์เมื่อเป็น flag การใช้สิทธิ์เดียว
- `PreviewPrint` อนุญาตการใช้ชั่วคราวเพื่อดูและพิมพ์; เอกสารที่มีฟอนต์ต้องเป็นแบบอ่านอย่างเดียว
- `Editable` อนุญาตการใช้ชั่วคราวและให้เอกสารสามารถแก้ไขและบันทึกได้
- `NoSubsetting` เป็นข้อจำกัดเพิ่มเติมที่ห้ามฝังเพียงส่วนย่อยของ glyphs; ฝังอักขระทั้งหมดเมื่อ flag นี้ปรากฏ
- `BitmapOnly` เป็นข้อจำกัดเพิ่มเติมที่อนุญาตฝังเฉพาะ bitmap strikes เท่านั้น, ไม่ใช่ข้อมูล outlines; หากฟอนต์ไม่มี bitmap strikes จะไม่สามารถฝังได้

สี่ค่าแรกอธิบายสิทธิ์การใช้, ส่วน `NoSubsetting` และ `BitmapOnly` สามารถผสานรวมกับพวกมันได้ ตรวจสอบ modifiers ด้วยการดำเนินการแบบบิต หาก `Installable` มีค่าเป็นศูนย์, อย่าใช้ `HasFlag` เพื่อตรวจจับ; ให้มาสก์บิตสิทธิ์การใช้และเปรียบเทียบผลลัพธ์กับ `Installable` ฟอนต์ปัจจุบันควรกำหนดบิตสิทธิ์การใช้ไม่เกินหนึ่งบิต สำหรับความเข้ากันได้กับฟอนต์เก่าที่กำหนดหลายบิต ตัวช่วยด้านล่างจะเลือกสิทธิ์ที่ผ่อนที่สุด: `Editable`, ตามด้วย `PreviewPrint`, แล้ว `Restricted`

ตัวอย่างต่อไปทำการตรวจสอบข้อมูลปกติ, ตัวหนา, ตัวเอียง, และตัวหนา‑เอียงสำหรับฟอนต์ทุกตัวที่คืนจาก `GetFonts` จะข้ามสไตล์ที่ไม่มี, ฟอนต์ที่ถูกจำกัด, ฟอนต์ bitmap‑only, ฟอนต์ที่จำกัดเฉพาะ preview‑print เพราะผลลัพธ์ยังคงแก้ไขได้, และฟอนต์ที่ฝังไว้แล้ว หากสไตล์ใดมี `NoSubsetting` จะฝังอักขระทั้งหมดสำหรับฟอนต์ชุดนั้น

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

การตรวจสอบนี้รายงานข้อจำกัดที่เข้ารหัสในแต่ละไฟล์ฟอนต์ ไม่ได้ให้ใบอนุญาต, แสดงว่าคุณได้มาฟอนต์อย่างถูกต้องตามกฎหมาย, หรือแทนที่การตรวจสอบสัญญาใบอนุญาตของฟอนต์ก่อนกระจายสำเนาที่ฝังไว้

## **เพิ่มฟอนต์ที่ฝังไว้**

ใช้ [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) เพื่อฝังฟอนต์ overloads ของมันรับอ็อบเจ็กต์ [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) หรืออาร์เรย์ไบต์ที่มีข้อมูลฟอนต์ ตัวกำหนดค่า [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) ควบคุมว่ารวมอักขระใดบ้าง:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) ฝังอักขระทั้งหมดในฟอนต์ ใช้ตัวเลือกนี้เมื่อผู้รับต้องการแก้ไขงานนำเสนอและพิมพ์ข้อความใหม่
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) ฝังเฉพาะอักขระที่ใช้ในงานนำเสนอเพื่อลดขนาดไฟล์เลือกตัวเลือกนี้สำหรับงานนำเสนอที่เสร็จสมบูรณ์และมีจุดประสงค์หลักเพื่อการดู

ตัวอย่างต่อไปใช้ [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) เพื่อดึงฟอนต์ที่ใช้ใน `Fonts.pptx` แล้วฝังฟอนต์ที่ยังไม่ถูกฝัง ฟอนต์ที่เพิ่มต้องพร้อมใช้งานบนเครื่องที่รันโค้ด ฟอนต์ที่ฝังไว้แล้วจะคงชุดอักขระปัจจุบันไว้

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **บีบอัดฟอนต์ที่ฝังไว้**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) ลดข้อมูลฟอนต์ที่ฝังโดยลบอักขระที่ไม่ได้ใช้ มันทำงานกับฟอนต์ที่ฝังแล้ว ดังนั้นการลดขนาดขึ้นอยู่กับข้อมูลฟอนต์ที่ไม่ได้ใช้ในงานนำเสนอเท่าใด

ตัวอย่างต่อไปบีบอัดฟอนต์ใน `EmbeddedFonts.pptx` และบันทึกผลลัพธ์เป็นไฟล์แยก

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

เก็บไฟล์ต้นฉบับไว้หากผู้รับอาจต้องเพิ่มข้อความในภายหลัง อักขระที่ถูกลบระหว่างการบีบอัดจะไม่สามารถใช้ได้จากฟอนต์ที่ฝังไว้ แม้ว่าคุณจะฝังอักขระทั้งหมดตั้งต้นก็ตาม

หากต้องการให้ฟอนต์ที่ลงทะเบียนไว้ตรงกันมีลำดับความสำคัญในการส่งออกโดยไม่ลบฟอนต์ที่ฝังไว้ ดูที่ [Prefer Registered Fonts over Embedded Fonts](/slides/th/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 หรือใหม่กว่า)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าฟอนต์ที่ฝังไว้จะยังคงถูกแทนที่ระหว่างการเรนเดอร์หรือไม่?**

เรียก [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) ในสภาพแวดล้อมที่คุณเรนเดอร์งานนำเสนอเพื่อดูฟอนต์ที่ Aspose.Slides จะเปลี่ยน นอกจากนี้ตรวจสอบการตั้งค่า [font substitution](/slides/th/net/font-substitution/) และกฎ [font fallback](/slides/th/net/fallback-font/) ด้วย Fallback จัดการอักขระที่ขาดหายไป ดังนั้นการฝังฟอนต์ไม่ได้แก้ปัญหาอักขระที่ฟอนต์นั้นไม่มี

**ฉันควรฝังฟอนต์ทั่วไปเช่น Arial และ Calibri หรือไม่?**

ให้ตัดสินใจตามสภาพแวดล้อมเป้าหมาย หากฟอนต์ที่ต้องการมีอยู่ในทุกเครื่องที่เปิดหรือเรนเดอร์งานนำเสนอ การฝังอาจเพิ่มขนาดไฟล์โดยไม่จำเป็น หากผู้รับหรือเซิร์ฟเวอร์อาจไม่มีฟอนต์เหล่านั้น การฝังสามารถช่วยรักษารูปแบบที่ตั้งใจไว้ได้ ตราบใดที่ใบอนุญาตของฟอนต์อนุญาตให้ทำเช่นนั้น.