---
title: ฝังแบบอักษรในงานนำเสนอใน .NET
linktitle: แบบอักษรที่ฝังไว้
type: docs
weight: 40
url: /th/net/embedded-font/
keywords:
- เพิ่มแบบอักษร
- ฝังแบบอักษร
- การฝังแบบอักษร
- รับแบบอักษรที่ฝังไว้
- เพิ่มแบบอักษรที่ฝังไว้
- ลบแบบอักษรที่ฝังไว้
- บีบอัดแบบอักษรที่ฝังไว้
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "จัดการแบบอักษรที่ฝังไว้ใน PowerPoint ด้วย Aspose.Slides for .NET ใช้ C# เพื่อเพิ่ม ดึงออก ลบและบีบอัดแบบอักษร เพื่อรักษาลักษณะของข้อความและลดขนาดไฟล์"
---
## **บทนำ**

การฝังแบบอักษรจะเก็บข้อมูลแบบอักษรไว้ภายในงานนำเสนอ PowerPoint เมื่อโปรแกรมแสดงผลรองรับแบบอักษรที่ฝังไว้ มันสามารถแสดงข้อความโดยใช้แบบอักษรเหล่านั้นแม้ว่าจะไม่ได้ติดตั้งบนระบบเป้าหมาย การทำเช่นนี้ช่วยรักษาการขึ้นบรรทัด การเว้นวรรคของข้อความ และการจัดรูปแบบสไลด์

Aspose.Slides for .NET ให้คุณเรียกคืน เพิ่ม และลบแบบอักษรที่ฝังอยู่ผ่านคุณสมบัติ [FontsManager](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/fontsmanager/) ของ [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) คุณยังสามารถลดขนาดข้อมูลแบบอักษรที่ฝังได้โดยลบอักขระที่งานนำเสนอไม่ใช้

## **รับและลบแบบอักษรที่ฝังอยู่**

ใช้ [GetEmbeddedFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/getembeddedfonts/) เพื่อแสดงรายการแบบอักษรที่เก็บไว้ในงานนำเสนอ เพื่อทำการลบให้ส่งแบบอักษรจากรายการนั้นให้กับ [RemoveEmbeddedFont](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/removeembeddedfont/) แล้วบันทึกงานนำเสนอ

ตัวอย่างต่อไปนี้จะแสดงรายการแบบอักษรที่ฝังอยู่ใน `EmbeddedFonts.pptx` และลบ Calibri หากพบ:

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

การลบแบบอักษรที่ฝังอยู่จะลบข้อมูลแบบอักษรที่เก็บไว้; ไม่ได้เปลี่ยนแบบอักษรที่กำหนดให้กับข้อความ หากแบบอักษรติดตั้งบนระบบเป้าหมาย ข้อความยังคงใช้ได้ มิฉะนั้น การเรนเดอร์อาจต้องอาศัย [font substitution](/slides/th/net/font-substitution/) ซึ่งอาจส่งผลต่อการจัดรูปแบบ

## **ตรวจสอบข้อมูลแบบอักษรและสิทธิการฝัง**

ใช้อินเตอร์เฟส [IFontsManager](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/) เพื่อตรวจสอบแบบอักษรก่อนการฝัง เรียก [IFontsManager.GetFonts](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getfonts/) เพื่อรับแบบอักษรที่ใช้ในงานนำเสนอ สำหรับแต่ละแบบอักษร ให้ส่งอ็อบเจ็กต์ [IFontData](https://reference.aspose.com/slides/th/net/aspose.slides/ifontdata/) และค่าที่ต้องการของ [FontStyleType](https://reference.aspose.com/slides/th/net/aspose.slides/fontstyletype/) ไปยัง [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getfontbytes/) เมธอดจะคืนข้อมูลไบต์ของสไตล์แบบอักษรนั้น หรือ `null` หากแบบอักษรหรือสไตล์ที่ร้องขอไม่พร้อมใช้งาน อย่าส่งผลลัพธ์ `null` ไปยัง [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/th/net/aspose.slides/ifontsmanager/getfontembeddinglevel/) เพราะเมธอดนั้นต้องการอาร์เรย์ไบต์

[EmbeddingLevel](https://reference.aspose.com/slides/th/net/aspose.slides/embeddinglevel/) เป็น enumeration แบบ flags ที่รายงานข้อจำกัดการฝังที่เก็บไว้ในแบบอักษร:

- `Installable` อนุญาตให้ฝังและติดตั้งถาวรบนระบบอื่น ภายใต้เงื่อนไขของสัญญาอนุญาตแบบอักษร
- `Restricted` ห้ามฝังเว้นแต่จะได้รับอนุญาตจากเจ้าของลิขสิทธิ์ของแบบอักษรเมื่อเป็น flag การใช้สิทธิ์เดียว
- `PreviewPrint` อนุญาตให้ใช้ชั่วคราวเพื่อดูและพิมพ์; เอกสารที่มีแบบอักษรนี้ต้องเป็นแบบอ่านอย่างเดียว
- `Editable` อนุญาตให้ใช้ชั่วคราวและให้เอกสารสามารถแก้ไขและบันทึกได้
- `NoSubsetting` เป็นข้อจำกัดเพิ่มเติมที่ห้ามฝังเพียงส่วนย่อยของ glyphs. ให้ฝังอักขระทั้งหมดเมื่อมี flag นี้
- `BitmapOnly` เป็นข้อจำกัดเพิ่มเติมที่อนุญาตให้ฝังเฉพาะ bitmap strikes เท่านั้น ไม่ใช่ข้อมูล outline หากแบบอักษรไม่มี bitmap strikes จะไม่สามารถฝังได้

ค่าสี่ค่าแรกอธิบายสิทธิ์การใช้งาน ส่วน `NoSubsetting` และ `BitmapOnly` สามารถรวมกับพวกมันได้ ตรวจสอบ modifiers ด้วยการดำเนินการบิต หาก `Installable` มีค่าเป็นศูนย์ อย่าใช้ `HasFlag` เพื่อตรวจจับ; ให้ทำการ mask บิตสิทธิ์การใช้งานและเปรียบเทียบผลกับ `Installable` แบบอักษรปัจจุบันควรตั้งบิตสิทธิ์การใช้งานไม่เกินหนึ่งบิต สำหรับความเข้ากันได้กับแบบอักษรเก่าที่ตั้งมากกว่าหนึ่งบิต ตัวช่วยด้านล่างจะเลือกสิทธิ์ที่ผ่อนผันที่สุด: `Editable` แล้วตามด้วย `PreviewPrint` แล้ว `Restricted`

ตัวอย่างต่อไปนี้ตรวจสอบข้อมูลแบบอักษรปกติ หนา ตัวเอียง และหนาตัวเอียงสำหรับทุกแบบอักษรที่ `GetFonts` คืนค่า จะข้ามสไตล์ที่ไม่พร้อมใช้งาน แบบอักษรที่ถูกจำกัด bitmap‑only แบบอักษรที่จำกัดการพรีวิวและพิมพ์เนื่องจากผลลัพธ์ยังคงแก้ไขได้ และแบบอักษรที่ฝังอยู่แล้ว หากสไตล์ใดมี `NoSubsetting` จะฝังอักขระทั้งหมดของตระกูลแบบอักษรนั้น

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

การตรวจสอบนี้รายงานข้อจำกัดที่เข้ารหัสในแต่ละไฟล์แบบอักษร ไม่ได้ให้สิทธิ์ ใบอนุญาต หรือพิสูจน์ว่าคุณได้แบบอักษรมาจากแหล่งที่ถูกต้อง รวมถึงไม่ทดแทนการตรวจสอบสัญญาอนุญาตของแบบอักษรก่อนแจกจ่ายสำเนาที่ฝัง

## **เพิ่มแบบอักษรที่ฝังอยู่**

ใช้ [AddEmbeddedFont](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/addembeddedfont/) เพื่อฝังแบบอักษร การ overload ของมันรับอ็อบเจ็กต์ [IFontData](https://reference.aspose.com/slides/th/net/aspose.slides/ifontdata/) หรืออาร์เรย์ไบต์ที่มีข้อมูลแบบอักษร enumeration [EmbedFontCharacters](https://reference.aspose.com/slides/th/net/aspose.slides.export/embedfontcharacters/) ควบคุมว่าอักขระใดจะถูกรวม:

- [All](https://reference.aspose.com/slides/th/net/aspose.slides.export/embedfontcharacters/) ฝังอักขระทั้งหมดในแบบอักษร ใช้ตัวเลือกนี้เมื่อผู้รับต้องการแก้ไขงานนำเสนอและใส่ข้อความใหม่
- [OnlyUsed](https://reference.aspose.com/slides/th/net/aspose.slides.export/embedfontcharacters/) ฝังเฉพาะอักขระที่ใช้ในงานนำเสนอเพื่อให้ไฟล์มีขนาดเล็กลง เลือกตัวเลือกนี้สำหรับงานนำเสนอที่เสร็จสมบูรณ์และมีเป้าหมายหลักคือการดูเท่านั้น

ตัวอย่างต่อไปนี้ใช้ [GetFonts](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/getfonts/) เพื่อดึงแบบอักษรที่ใช้ใน `Fonts.pptx` แล้วฝังแบบอักษรที่ยังไม่ได้ฝังอยู่ แบบอักษรที่ต้องเพิ่มต้องพร้อมใช้งานบนเครื่องที่รันโค้ด แบบอักษรที่ฝังอยู่เดิมจะคงชุดอักขระปัจจุบันไว้

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

## **บีบอัดแบบอักษรที่ฝังอยู่**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/compressembeddedfonts/) ลดข้อมูลแบบอักษรที่ฝังโดยการลบอักขระที่ไม่ได้ใช้ มันทำงานกับแบบอักษรที่ฝังแล้ว ดังนั้นการลดขนาดจึงขึ้นอยู่กับข้อมูลแบบอักษรที่ไม่ได้ใช้ในงานนำเสนอเท่าใด

ตัวอย่างต่อไปนี้บีบอัดแบบอักษรใน `EmbeddedFonts.pptx` แล้วบันทึกผลลัพธ์เป็นไฟล์แยก

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

ควรรักษาไฟล์ต้นฉบับไว้หากผู้รับอาจต้องเพิ่มข้อความในภายหลัง อักขระที่ลบระหว่างการบีบอัดจะไม่สามารถใช้จากแบบอักษรที่ฝังได้ แม้ว่าคุณจะฝังอักขระทั้งหมดไว้ตั้งแต่แรกก็ตาม

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรที่ฝังอยู่จะยังถูกทดแทนระหว่างการเรนเดอร์หรือไม่?**

ให้เรียก [GetSubstitutions](https://reference.aspose.com/slides/th/net/aspose.slides/fontsmanager/getsubstitutions/) ในสภาพแวดล้อมที่คุณเรนเดอร์งานนำเสนอเพื่อดูว่า Aspose.Slides จะเปลี่ยนแบบอักษรใดบ้าง นอกจากนี้ตรวจสอบการตั้งค่า [font substitution](/slides/th/net/font-substitution/) และกฎ [font fallback](/slides/th/net/fallback-font/) ด้วย Fallback จัดการอักขระที่ขาดหายไป ดังนั้นการฝังแบบอักษรไม่ได้แก้ปัญหาอักขระที่แบบอักษรนั้นไม่มีอยู่

**ผมควรฝังแบบอักษรทั่วไปเช่น Arial และ Calibri หรือไม่?**

ให้พิจารณาตามสภาพแวดล้อมเป้าหมาย หากแบบอักษรที่ต้องการมีอยู่บนทุกเครื่องที่เปิดหรือเรนเดอร์งานนำเสนอ การฝังอาจเพิ่มขนาดไฟล์โดยไม่จำเป็น หากผู้รับหรือเซิร์ฟเวอร์อาจไม่มีแบบอักษรเหล่านั้น การฝังจะช่วยรักษาลักษณะที่ต้องการไว้ได้ อย่างไรก็ตามต้องตรวจสอบว่าลิขสิทธิ์ของแบบอักษรอนุญาตให้ฝังหรือไม่.