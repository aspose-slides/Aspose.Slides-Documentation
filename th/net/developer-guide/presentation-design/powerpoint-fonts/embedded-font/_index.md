---
title: ฝังแบบอักษรในงานนำเสนอด้วย .NET
linktitle: การฝังแบบอักษร
type: docs
weight: 40
url: /th/net/embedded-font/
keywords:
- เพิ่มแบบอักษร
- ฝังแบบอักษร
- การฝังแบบอักษร
- ดึงแบบอักษรที่ฝังไว้
- เพิ่มแบบอักษรที่ฝังไว้
- ลบแบบอักษรที่ฝังไว้
- บีบอัดแบบอักษรที่ฝังไว้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ฝังแบบอักษร TrueType ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET เพื่อให้การเรนเดอร์ที่แม่นยำบนทุกแพลตฟอร์ม"
---
## **บทนำ**

**Embedding fonts in PowerPoint** ทำให้การนำเสนอของคุณคงรูปลักษณ์ตามที่ตั้งใจไว้บนระบบต่าง ๆ ไม่ว่าจะใช้แบบอักษรพิเศษเพื่อความสร้างสรรค์หรือแบบอักษรมาตรฐาน การฝังแบบอักษรจะช่วยป้องกันการบิดเบือนของข้อความและการจัดหน้า

หากคุณใช้แบบอักษรจากบุคคลที่สามหรือแบบอักษรที่ไม่เป็นมาตรฐานเพราะต้องการความสร้างสรรค์กับงานของคุณ คุณจะมีเหตุผลมากขึ้นในการฝังแบบอักษรของคุณ มิฉะนั้น (หากไม่มีการฝังแบบอักษร) ข้อความหรือจำนวนบนสไลด์ การจัดหน้า การจัดรูปแบบ ฯลฯ อาจเปลี่ยนแปลงหรือกลายเป็นสี่เหลี่ยมที่ทำให้สับสน

ใช้คลาส **FontsManager**, **FontData**, และ **Compress** เพื่อจัดการแบบอักษรที่ฝังไว้

## **ดึงและลบแบบอักษรที่ฝังไว้**

เรียกคืนหรือเอาแบบอักษรที่ฝังไว้จากการนำเสนอได้อย่างง่ายดายด้วยเมธอด **GetEmbeddedFonts** และ **RemoveEmbeddedFont**  

โค้ด C# นี้แสดงวิธีดึงและลบแบบอักษรที่ฝังไว้จากการนำเสนอ:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // แสดงสไลด์ที่มีกรอบข้อความซึ่งใช้ "FunSized" ที่ฝังไว้
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // ค้นหาแบบอักษร "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // ลบแบบอักษร "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // แสดงการนำเสนอ; แบบอักษร "Calibri" จะถูกแทนที่ด้วยแบบที่มีอยู่แล้ว
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // บันทึกการนำเสนอโดยไม่มีแบบอักษร "Calibri" ที่ฝังไว้ลงดิสก์
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **เพิ่มแบบอักษรที่ฝังไว้**

โดยใช้ enum **EmbedFontCharacters** และการโอเวอร์โหลดสองรูปแบบของเมธอด **AddEmbeddedFont** คุณสามารถเลือกกฎการฝังที่ต้องการเพื่อฝังแบบอักษรในงานนำเสนอได้ โค้ด C# นี้แสดงวิธีฝังและเพิ่มแบบอักษรในงานนำเสนอ:

```c#
// โหลดการนำเสนอ
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// บันทึกการนำเสนอลงดิสก์
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **บีบอัดแบบอักษรที่ฝังไว้**

เพิ่มประสิทธิภาพขนาดไฟล์โดยบีบอัดแบบอักษรที่ฝังไว้ด้วย **CompressEmbeddedFonts**  

ตัวอย่างโค้ดสำหรับการบีบอัด:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ฉันจะรู้ได้อย่างไรว่าฟอนต์เฉพาะในงานนำเสนอจะยังคงถูกแทนที่ระหว่างการเรนเดอร์แม้จะฝังไว้แล้ว?**  

ตรวจสอบ [ข้อมูลการแทนที่](/slides/th/net/font-substitution/) ในตัวจัดการฟอนต์และ [กฎการสำรอง/การแทนที่](/slides/th/net/fallback-font/): หากฟอนต์ไม่พร้อมใช้หรือถูกจำกัด จะใช้ฟอนต์สำรองแทน

**คุ้มค่าที่จะฝังฟอนต์ “ระบบ” เช่น Arial/Calibri หรือไม่?**  

โดยทั่วไปไม่—ฟอนต์เหล่านี้มักพร้อมใช้งานอยู่แล้ว แต่ในสภาพแวดล้อม “บาง” เช่น Docker หรือเซิร์ฟเวอร์ Linux ที่ไม่มีฟอนต์ติดตั้งล่วงหน้า การฝังฟอนต์ระบบสามารถกำจัดความเสี่ยงของการแทนที่โดยไม่ได้คาดคิดได้อย่างเต็มที่