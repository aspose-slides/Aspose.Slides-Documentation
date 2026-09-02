---
title: แปลงสไลด์การนำเสนอเป็นภาพใน .NET
linktitle: สไลด์เป็นภาพ
type: docs
weight: 41
url: /th/net/convert-slide/
keywords:
- แปลงสไลด์
- ส่งออกสไลด์
- สไลด์เป็นภาพ
- บันทึกสไลด์เป็นภาพ
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมพ
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "แปลงสไลด์จาก PPT, PPTX และ ODP เป็นภาพใน C# ด้วย Aspose.Slides for .NET—เรนเดอร์ที่รวดเร็วและคุณภาพสูงพร้อมตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

Aspose.Slides for .NET ช่วยให้คุณสามารถแปลงสไลด์การนำเสนอ PowerPoint และ OpenDocument เป็นรูปแบบภาพต่าง ๆ ได้อย่างง่ายดาย รวมถึง BMP, PNG, JPG (JPEG), GIF และอื่น ๆ

เพื่อแปลงสไลด์เป็นรูปภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดค่าการแปลงที่ต้องการและเลือกสไลด์ที่คุณต้องการส่งออกโดยใช้:
    - อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/itiffoptions/)
    - อินเทอร์เฟซ [IRenderingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/irenderingoptions/)
2. สร้างภาพสไลด์โดยเรียกใช้เมธอด [GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/)

ใน .NET, [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) คืออ็อบเจกต์ที่ให้คุณทำงานกับภาพที่กำหนดโดยข้อมูลพิกเซล คุณสามารถใช้อินสแตนซ์ของคลาสนี้เพื่อบันทึกภาพในรูปแบบต่าง ๆ อย่างกว้างขวาง (BMP, JPG, PNG ฯลฯ).

## **แปลงสไลด์เป็นบิตแมพและบันทึกรูปภาพเป็น PNG**

คุณสามารถแปลงสไลด์เป็นออบเจกต์บิตแมพและใช้โดยตรงในแอปพลิเคชันของคุณ หรือคุณสามารถแปลงสไลด์เป็นบิตแมพแล้วบันทึกรูปภาพเป็น JPEG หรือรูปแบบใด ๆ ที่คุณต้องการ

โค้ด C# นี้แสดงวิธีการแปลงสไลด์แรกของการนำเสนอเป็นออบเจกต์บิตแมพและจากนั้นบันทึกภาพในรูปแบบ PNG:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // แปลงสไลด์แรกในงานนำเสนอเป็นบิตแมพ.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // บันทึกภาพในรูปแบบ PNG.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **แปลงสไลด์เป็นภาพด้วยขนาดกำหนดเอง**

คุณอาจต้องการภาพที่มีขนาดเฉพาะ โดยใช้การ overload จากเมธอด [GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/), คุณสามารถแปลงสไลด์เป็นภาพที่มีมิติที่กำหนด (ความกว้างและความสูง).

ตัวอย่างโค้ดนี้แสดงวิธีทำเช่นนี้:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // แปลงสไลด์แรกในงานนำเสนอเป็นบิตแมพด้วยขนาดที่ระบุ.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // บันทึกภาพในรูปแบบ JPEG.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **แปลงสไลด์ที่มีบันทึกและคอมเมนต์เป็นภาพ**

บางสไลด์อาจมีบันทึกและคอมเมนต์

Aspose.Slides มีอินเทอร์เฟซสองตัวคือ [ITiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/itiffoptions/) และ [IRenderingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/irenderingoptions/) ซึ่งช่วยให้คุณควบคุมการเรนเดอร์ของสไลด์การนำเสนอเป็นภาพ ทั้งสองอินเทอร์เฟซมีคุณสมบัติ `SlidesLayoutOptions` ที่ทำให้คุณตั้งค่าการเรนเดอร์ของบันทึกและคอมเมนต์บนสไลด์เมื่อต้องการแปลงเป็นภาพ

ด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/notescommentslayoutingoptions/) คุณสามารถระบุตำแหน่งที่ต้องการสำหรับบันทึกและคอมเมนต์ในภาพผลลัพธ์

โค้ด C# นี้แสดงวิธีการแปลงสไลด์ที่มีบันทึกและคอมเมนต์:

```cs
float scaleX = 2;
float scaleY = scaleX;

// โหลดไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // สร้างตัวเลือกการเรนเดอร์.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // ตั้งค่าตำแหน่งของบันทึก.
            CommentsPosition = CommentsPositions.Right,      // ตั้งค่าตำแหน่งของความคิดเห็น.
            CommentsAreaWidth = 500,                         // ตั้งค่าความกว้างของพื้นที่ความคิดเห็น.
            CommentsAreaColor = Color.AntiqueWhite           // ตั้งค่าสีของพื้นที่ความคิดเห็น.
        }
    };

    // แปลงสไลด์แรกของงานนำเสนอเป็นภาพ.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // บันทึกภาพในรูปแบบ GIF.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 
ในกระบวนการแปลงสไลด์เป็นภาพใด ๆ คุณสมบัติ [NotesPosition](https://reference.aspose.com/slides/th/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) ไม่สามารถตั้งค่าเป็น `BottomFull` (เพื่อระบุตำแหน่งของบันทึก) เนื่องจากข้อความของบันทึกอาจใหญ่เกินไป ทำให้ไม่สามารถใส่ลงในขนาดภาพที่กำหนด
{{% /alert %}} 

## **แปลงสไลด์เป็นภาพโดยใช้ TIFF Options**

อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/itiffoptions/) ให้การควบคุมที่มากขึ้นต่อภาพ TIFF ที่ได้โดยอนุญาตให้คุณระบุพารามิเตอร์เช่น ขนาด, ความละเอียด, พาเลตสี, และอื่น ๆ

โค้ด C# นี้แสดงกระบวนการแปลงที่ใช้ TIFF options เพื่อสร้างภาพขาว-ดำด้วยความละเอียด 300 DPI และขนาด 2160 × 2800:

```cs
// โหลดไฟล์งานนำเสนอ.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // ดึงสไลด์แรกจากงานนำเสนอ.
    ISlide slide = presentation.Slides[0];

    // กำหนดค่าการตั้งค่าของภาพ TIFF ที่ส่งออก.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // ตั้งค่าขนาดภาพ.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // ตั้งค่ารูปแบบพิกเซล (ขาว-ดำ).
        DpiX = 300,                                        // ตั้งค่าความละเอียดแนวนอน.
        DpiY = 300                                         // ตั้งค่าความละเอียดแนวตั้ง.
    };

    // แปลงสไลด์เป็นภาพด้วยตัวเลือกที่ระบุ.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // บันทึกภาพในรูปแบบ TIFF.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

Aspose.Slides ช่วยให้คุณสามารถแปลงสไลด์ทั้งหมดในการนำเสนอเป็นภาพได้อย่างมีประสิทธิภาพ ทำให้การนำเสนอทั้งหมดถูกแปลงเป็นชุดของภาพ

ตัวอย่างโค้ดนี้แสดงวิธีการแปลงสไลด์ทั้งหมดในการนำเสนอเป็นภาพด้วย C#:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // เรนเดอร์งานนำเสนอเป็นภาพสไลด์ต่อสไลด์.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // ควบคุมสไลด์ที่ซ่อน (ไม่เรนเดอร์สไลด์ที่ซ่อน).
        if (presentation.Slides[i].Hidden)
            continue;

        // แปลงสไลด์เป็นภาพ.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // บันทึกภาพในรูปแบบ JPEG.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **การเรนเดอร์อีโมจีสี**

{{% alert title="Note" color="warning" %}} 
เพื่อให้การเรนเดอร์อีโมจีสีทำงานถูกต้องเมื่อแปลงสไลด์การนำเสนอเป็นภาพ ฟอนต์อีโมจีที่ใช้ในการนำเสนอจำเป็นต้องติดตั้งและพร้อมใช้งานในระบบที่ทำการแปลง ตัวอย่างเช่น หากการนำเสนอใช้ **Segoe UI Emoji** แต่ฟอนต์นี้ไม่มีอยู่ อีโมจีอาจปรากฏเป็นสีเทาในภาพผลลัพธ์
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์ที่มีแอนิเมชันหรือไม่?**  
ไม่, เมธอด `GetImage` จะบันทึกเฉพาะภาพนิ่งของสไลด์เท่านั้น โดยไม่มีแอนิเมชัน.

**สไลด์ที่ซ่อนได้รับการส่งออกเป็นภาพหรือไม่?**  
ได้, สไลด์ที่ซ่อนสามารถประมวลผลได้เช่นเดียวกับสไลด์ทั่วไป เพียงตรวจสอบให้แน่ใจว่ามีการรวมไว้ในลูปการประมวลผล.

**สามารถบันทึกรูปภาพพร้อมกับเงาและเอฟเฟกต์ได้หรือไม่?**  
ได้, Aspose.Slides รองรับการเรนเดอร์เงา, ความโปร่งใส, และเอฟเฟกต์กราฟิกอื่น ๆ เมื่อบันทึกสไลด์เป็นภาพ.