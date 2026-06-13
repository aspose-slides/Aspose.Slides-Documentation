---
title: แปลงสไลด์พรีเซนเทชันเป็นรูปภาพใน .NET
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
- สไลด์เป็น bitmap
- สไลด์เป็น TIFF
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "แปลงสไลด์จาก PPT, PPTX และ ODP เป็นรูปภาพใน C# ด้วย Aspose.Slides สำหรับ .NET—เรนเดอร์ที่รวดเร็วและคุณภาพสูงพร้อมตัวอย่างโค้ดที่ชัดเจน."
---
## **บทนำ**

Aspose.Slides for .NET ช่วยให้คุณแปลงสไลด์ PowerPoint และ OpenDocument เป็นรูปภาพหลากหลายรูปแบบได้อย่างง่ายดาย เช่น BMP, PNG, JPG (JPEG), GIF และอื่น ๆ  

เพื่อแปลงสไลด์เป็นรูปภาพ ให้ทำตามขั้นตอนเหล่านี้:

1. กำหนดการตั้งค่าการแปลงที่ต้องการและเลือกสไลด์ที่ต้องการส่งออกโดยใช้  
   - อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/itiffoptions/) หรือ  
   - อินเทอร์เฟซ [IRenderingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/irenderingoptions/)  
2. สร้างรูปภาพของสไลด์โดยเรียกเมธอด [GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/)

ใน .NET, [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) คืออ็อบเจกต์ที่ให้คุณทำงานกับรูปภาพที่กำหนดโดยข้อมูลพิกเซล คุณสามารถใช้อินสแตนซ์ของคลาสนี้เพื่อบันทึกรูปภาพในรูปแบบต่าง ๆ (BMP, JPG, PNG ฯลฯ)

## **แปลงสไลด์เป็น Bitmap และบันทึกรูปภาพเป็น PNG**

คุณสามารถแปลงสไลด์เป็นอ็อบเจกต์ Bitmap แล้วใช้โดยตรงในแอปพลิเคชันของคุณ หรือแปลงสไลด์เป็น Bitmap แล้วบันทึกรูปภาพเป็น JPEG หรือรูปแบบอื่นที่ต้องการ

โค้ด C# ตัวอย่างนี้แสดงวิธีแปลงสไลด์แรกของพรีเซนเทชันเป็นอ็อบเจกต์ Bitmap แล้วบันทึกเป็นรูปแบบ PNG:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // แปลงสไลด์แรกในพรีเซนเทชันเป็น bitmap.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // บันทึกรูปภาพในรูปแบบ PNG.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **แปลงสไลด์เป็นรูปภาพด้วยขนาดกำหนดเอง**

บางครั้งคุณอาจต้องการรูปภาพที่มีขนาดเฉพาะ โดยใช้ overload ของเมธอด [GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/islide/getimage/) คุณสามารถแปลงสไลด์เป็นรูปภาพด้วยความกว้างและความสูงที่กำหนด

ตัวอย่างโค้ดนี้แสดงวิธีทำเช่นนั้น:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // แปลงสไลด์แรกในพรีเซนเทชันเป็น bitmap ด้วยขนาดที่ระบุ.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // บันทึกรูปภาพในรูปแบบ JPEG.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **แปลงสไลด์พร้อมโน๊ตและคอมเมนต์เป็นรูปภาพ**

สไลด์บางสไลด์อาจมีโน๊ตและคอมเมนต์

Aspose.Slides มีอินเทอร์เฟซสองตัว — [ITiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/itiffoptions/) และ [IRenderingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/irenderingoptions/) — ที่ให้คุณควบคุมการเรนเดอร์สไลด์เป็นรูปภาพ ทั้งสองอินเทอร์เฟซมี property `SlidesLayoutOptions` ซึ่งช่วยกำหนดการเรนเดอร์ของโน๊ตและคอมเมนต์เมื่อต้องการแปลงเป็นรูปภาพ

ด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/notescommentslayoutingoptions/) คุณสามารถระบุตำแหน่งที่ต้องการสำหรับโน๊ตและคอมเมนต์ในรูปภาพที่ได้

โค้ด C# ตัวอย่างนี้แสดงวิธีแปลงสไลด์พร้อมโน๊ตและคอมเมนต์:

```cs
float scaleX = 2;
float scaleY = scaleX;

// โหลดไฟล์พรีเซนเทชัน.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // สร้างตัวเลือกการเรนเดอร์.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // ตั้งค่าตำแหน่งของโน๊ต.
            CommentsPosition = CommentsPositions.Right,      // ตั้งค่าตำแหน่งของคอมเมนต์.
            CommentsAreaWidth = 500,                         // ตั้งค่าความกว้างของพื้นที่คอมเมนต์.
            CommentsAreaColor = Color.AntiqueWhite           // ตั้งค่าสีสำหรับพื้นที่คอมเมนต์.
        }
    };

    // แปลงสไลด์แรกของพรีเซนเทชันเป็นภาพ.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // บันทึกรรูปภาพในรูปแบบ GIF.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 
ในกระบวนการแปลงสไลด์เป็นรูปภาพใด ๆ, property [NotesPosition](https://reference.aspose.com/slides/th/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) ไม่สามารถตั้งค่าเป็น `BottomFull` (เพื่อระบุตำแหน่งของโน๊ต) ได้ เนื่องจากข้อความของโน๊ตอาจมีขนาดใหญ่เกินไป ทำให้ไม่สามารถใส่ลงในขนาดภาพที่กำหนดได้
{{% /alert %}} 

## **แปลงสไลด์เป็นรูปภาพโดยใช้ TIFF Options**

อินเทอร์เฟซ [ITiffOptions](https://reference.aspose.com/slides/th/net/aspose.slides.export/itiffoptions/) ให้การควบคุมที่ละเอียดขึ้นของภาพ TIFF ที่สร้างขึ้น โดยสามารถกำหนดพารามิเตอร์เช่น ขนาด, ความละเอียด, พาเลตสี ฯลฯ

โค้ด C# ตัวอย่างนี้แสดงกระบวนการแปลงที่ใช้ TIFF Options เพื่อสร้างภาพขาว-ดำที่ความละเอียด 300 DPI และขนาด 2160 × 2800:

```cs
// โหลดไฟล์พรีเซนเทชัน.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // ดึงสไลด์แรกจากพรีเซนเทชัน.
    ISlide slide = presentation.Slides[0];

    // กำหนดค่าการตั้งค่าของภาพ TIFF ที่จะส่งออก.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // ตั้งค่าขนาดของภาพ.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // ตั้งค่ารูปแบบพิกเซล (สีดำและขาว).
        DpiX = 300,                                        // ตั้งความละเอียดแนวนอน.
        DpiY = 300                                         // ตั้งความละเอียดแนวตั้ง.
    };

    // แปลงสไลด์เป็นภาพด้วยตัวเลือกที่ระบุ.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // บันทึกรูปภาพในรูปแบบ TIFF.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **แปลงสไลด์ทั้งหมดเป็นรูปภาพ**

Aspose.Slides ช่วยให้คุณแปลงสไลด์ทั้งหมดในพรีเซนเทชันเป็นรูปภาพได้อย่างง่ายดาย ซึ่งหมายถึงการแปลงพรีเซนเทชันทั้งหมดเป็นชุดของรูปภาพ

ตัวอย่างโค้ดนี้แสดงวิธีแปลงสไลด์ทั้งหมดในพรีเซนเทชันเป็นรูปภาพด้วย C#:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // เรนเดอร์พรีเซนเทชันเป็นภาพสไลด์ต่อสไลด์.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // ควบคุมสไลด์ที่ซ่อนอยู่ (ไม่เรนเดอร์สไลด์ที่ซ่อนอยู่).
        if (presentation.Slides[i].Hidden)
            continue;

        // แปลงสไลด์เป็นภาพ.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // บันทึกรูปภาพในรูปแบบ JPEG.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **คำถามที่พบบ่อย**

**1. Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมอนิเมชันหรือไม่?**

ไม่, เมธอด `GetImage` จะบันทึกรูปภาพแบบคงที่ของสไลด์เท่านั้น ไม่รวมอนิเมชัน

**2. สามารถส่งออกสไลด์ที่ซ่อนอยู่เป็นรูปภาพได้หรือไม่?**

ได้, สไลด์ที่ซ่อนอยู่สามารถประมวลผลได้เช่นเดียวกับสไลด์ปกติ เพียงตรวจสอบให้แน่ใจว่าถูกรวมอยู่ในลูปการประมวลผล

**3. สามารถบันทึกรูปภาพพร้อมเงาและเอฟเฟกต์ได้หรือไม่?**

ได้, Aspose.Slides รองรับการเรนเดอร์เงา, ความโปร่งแสงและเอฟเฟกต์กราฟิกอื่น ๆ เวลาบันทึกสไลด์เป็นรูปภาพ