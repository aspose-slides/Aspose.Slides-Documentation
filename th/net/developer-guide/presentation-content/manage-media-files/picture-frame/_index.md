---
title: จัดการกรอบภาพในงานนำเสนอด้วย .NET
linktitle: กรอบภาพ
type: docs
weight: 10
url: /th/net/picture-frame/
keywords:
- กรอบภาพ
- เพิ่มกรอบภาพ
- สร้างกรอบภาพ
- เพิ่มรูปภาพ
- สร้างรูปภาพ
- สกัดรูปภาพ
- รูปภาพราสเตอร์
- รูปภาพเวคเตอร์
- ครอบรูปภาพ
- พื้นที่ที่ถูกครอบ
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบภาพ
- คุณสมบัติกรอบภาพ
- สเกลสัมพัทธ์
- เอฟเฟกต์ภาพ
- อัตราส่วนภาพ
- ความโปร่งใสของภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เพิ่มกรอบภาพในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET ปรับปรุงกระบวนการทำงานของคุณและยกระดับการออกแบบสไลด์"
---
## **บทนำ**

Picture frame คือรูปร่างที่บรรจุภาพ—มันเหมือนรูปในกรอบ  

คุณสามารถเพิ่มภาพลงในสไลด์ผ่าน picture frame ได้ วิธีนี้ทำให้คุณสามารถจัดรูปแบบภาพได้โดยจัดรูปแบบ picture frame  

{{% alert  title="Tip" color="info" %}} 
Aspose มีตัวแปลงฟรี—[JPEG ไปยัง PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG ไปยัง PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ทำให้ผู้ใช้สามารถสร้างงานนำเสนออย่างรวดเร็วจากภาพ  
{{% /alert %}} 

## **สร้าง Picture Frame**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/net/aspose.slides/iimagecollection) ที่เชื่อมโยงกับอ็อบเจกต์ presentation ที่จะใช้เติมรูปร่าง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe) โดยอิงจากความกว้างและความสูงของภาพผ่านเมธอด `AddPictureFrame` ที่เปิดให้ใช้โดยอ็อบเจกต์ shape ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่ม picture frame (ที่บรรจุภาพ) ลงในสไลด์  
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีการสร้าง picture frame:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
using (Presentation pres = new Presentation())
{
    // ดึงสไลด์แรก
    ISlide slide = pres.Slides[0];

    // โหลดภาพและเพิ่มลงในคอลเลกชันภาพของงานนำเสนอ
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // เพิ่มกรอบภาพที่มีความสูงและความกว้างเท่ากัน
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // ใช้การจัดรูปแบบบางอย่างกับกรอบภาพ
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
Picture frames ช่วยให้คุณสร้างสไลด์งานนำเสนอจากภาพได้อย่างรวดเร็ว เมื่อคุณรวม picture frame กับตัวเลือกการบันทึกของ Aspose.Slides คุณสามารถจัดการการทำงานเข้า/ออกเพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง คุณอาจต้องการดูหน้านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/net/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/net/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/net/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/net/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/net/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/net/conversion/svg-to-png/)  
{{% /alert %}}

## **สร้าง Picture Frame พร้อมการปรับขนาดสัมพัทธ์**

โดยการปรับสเกลสัมพัทธ์ของภาพ คุณสามารถสร้าง picture frame ที่ซับซ้อนได้มากขึ้น  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มภาพลงในคอลเลกชันภาพของ presentation  
4. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/net/aspose.slides/iimagecollection) ที่เชื่อมโยงกับอ็อบเจกต์ presentation ที่จะใช้เติมรูปร่าง  
5. ระบุความกว้างและความสูงสัมพัทธ์ของภาพใน picture frame  
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีการสร้าง picture frame พร้อมการปรับขนาดสัมพัทธ์:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
using (Presentation presentation = new Presentation())
{
    // โหลดภาพและเพิ่มลงในคอลเลกชันภาพของงานนำเสนอ
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // เพิ่มกรอบภาพไปยังสไลด์
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // กำหนดความกว้างและความสูงของสเกลสัมพัทธ์
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // บันทึกงานนำเสนอ
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **สกัดภาพ Raster จาก Picture Frames**

คุณสามารถสกัดภาพ raster จากอ็อบเจกต์ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe) และบันทึกเป็น PNG, JPG และรูปแบบอื่น ๆ ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดภาพจากเอกสาร “sample.pptx” แล้วบันทึกเป็นรูปแบบ PNG  

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **สกัดภาพ SVG จาก Picture Frames**

เมื่อการนำเสนอมีกราฟิก SVG ที่อยู่ภายในรูปร่าง [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) Aspose.Slides for .NET ให้คุณดึงภาพเวกเตอร์ดั้งเดิมออกมาพร้อมความคมชัดเต็มรูปแบบ โดยการวนผ่านคอลเลกชันรูปร่างของสไลด์ คุณสามารถระบุ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) แต่ละอัน ตรวจสอบว่า [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) มีเนื้อหา SVG หรือไม่ แล้วบันทึกภาพนั้นลงดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิม  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีสกัดภาพ SVG จาก picture frame:

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **รับค่าความโปร่งใสของภาพ**

Aspose.Slides ให้คุณดึงเอาผลกระทบความโปร่งใสที่ใช้กับภาพได้ โค้ด C# นี้แสดงการดำเนินการ:

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **รับค่าความสว่างและคอนทราสต์ของภาพ**

Aspose.Slides ให้คุณดึงเอาผลกระทบความสว่างและคอนทราสต์ที่ใช้กับภาพได้ อินเทอร์เฟซ [ILuminance](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iluminance/) แสดงถึงการแปลงภาพนี้  

โค้ด C# นี้แสดงวิธีดึงค่าความสว่างและคอนทราสต์จาก picture frame:

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="info" %}} 
เอฟเฟกต์ทั้งหมดที่ใช้กับภาพสามารถพบได้ใน [Aspose.Slides.Effects](https://reference.aspose.com/slides/th/net/aspose.slides.effects/)  
{{% /alert %}}

## **การกำหนดรูปแบบ Picture Frame**

Aspose.Slides มีตัวเลือกการกำหนดรูปแบบมากมายที่สามารถใช้กับ picture frame ได้ ด้วยตัวเลือกเหล่านี้คุณสามารถปรับ picture frame ให้ตรงกับข้อกำหนดเฉพาะได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](http://www.aspose.com/api/net/slides/th/aspose.slides/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/net/aspose.slides/iimagecollection) ที่เชื่อมโยงกับอ็อบเจกต์ presentation ที่จะใช้เติมรูปร่าง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง `PictureFrame` โดยอิงจากความกว้างและความสูงของภาพผ่านเมธอด [AddPictureFrame](http://www.aspose.com/api/net/slides/th/aspose.slides/ishapecollection/methods/addpictureframe) ที่เปิดให้ใช้โดยอ็อบเจกต์ [IShapes](http://www.aspose.com/api/net/slides/th/aspose.slides/ishapecollection) ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่ม picture frame (ที่บรรจุภาพ) ลงในสไลด์  
7. ตั้งค่าสีเส้นของ picture frame  
8. ตั้งค่าความกว้างของเส้น picture frame  
9. หมุน picture frame ด้วยค่าบวกหรือค่าลบ  
   * ค่าบวกหมุนภาพตามเข็มนาฬิกา  
   * ค่าลบหมุนภาพทวนเข็มนาฬิกา  
10. เพิ่ม picture frame (ที่บรรจุภาพ) ลงในสไลด์  
11. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงกระบวนการกำหนดรูปแบบ picture frame:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // โหลดภาพและเพิ่มลงในคอลเลกชันภาพของงานนำเสนอ
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // เพิ่มกรอบภาพที่มีความสูงและความกว้างเท่ากับภาพ
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // ใช้การจัดรูปแบบบางอย่างกับกรอบภาพ
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 
Aspose เพิ่งเปิดตัว [ฟรี Collage Maker](https://products.aspose.app/slides/th/collage) หากคุณต้องการ [รวม JPG/JPEG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG, หรือ [สร้างกริดจากภาพถ่าย](https://products.aspose.app/slides/th/collage/photo-grid) คุณสามารถใช้บริการนี้ได้  
{{% /alert %}}

## **เพิ่มภาพเป็นลิงก์**

เพื่อลดขนาดงานนำเสนอ คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์โดยตรงในงานนำเสนอ โค้ด C# นี้แสดงวิธีการเพิ่มภาพและวิดีโอลงใน placeholder:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **ครอบภาพ**

โค้ด C# นี้แสดงวิธีการครอบภาพที่มีอยู่บนสไลด์:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // สร้างอ็อบเจกต์ภาพใหม่
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // เพิ่ม PictureFrame ไปยังสไลด์
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // ครอบภาพ (ค่าร้อยละ)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // บันทึกผลลัพธ์
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **ลบพื้นที่ที่ถูกครอบของ Picture**

หากต้องการลบพื้นที่ที่ถูกครอบของภาพในกรอบ ให้ใช้เมธอด [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) เมธอดนี้จะคืนภาพที่ถูกครอบหรือภาพต้นฉบับหากไม่มีความจำเป็นต้องครอบ  

โค้ด C# นี้แสดงการดำเนินการ:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // ดึง PictureFrame จากสไลด์แรก
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // ลบพื้นที่ที่ถูกครอบของภาพใน PictureFrame และคืนภาพที่ถูกครอบ
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // บันทึกผลลัพธ์
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
เมธอด [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) จะเพิ่มภาพที่ถูกครอบเข้าไปในคอลเลกชันภาพของ presentation หากภาพนั้นใช้เฉพาะใน [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) ที่ประมวลผล การตั้งค่านี้อาจลดขนาดไฟล์งานนำเสนอได้ มิฉะนั้น จำนวนภาพในงานนำเสนอที่ได้จะเพิ่มขึ้น  

เมธอดนี้แปลงไฟล์ WMF/EMF เป็นภาพ raster PNG ในขั้นตอนการครอบภาพ  
{{% /alert %}}

## **บีบอัดภาพ**

คุณสามารถบีบอัดภาพในงานนำเสนอโดยใช้เมธอด [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/compressimage/) เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดรูปร่างและความละเอียดที่กำหนด พร้อมตัวเลือกเพื่อลบพื้นที่ที่ถูกครอบ  

มันปรับขนาดและความละเอียดของภาพคล้ายคุณลักษณะ **Picture Format → Compress Pictures → Resolution** ของ PowerPoint  

ตัวอย่าง C# ด้านล่างแสดงวิธีบีบอัดภาพในงานนำเสนอโดยกำหนดความละเอียดเป้าหมายและเลือกลบพื้นที่ที่ถูกครอบได้หรือไม่:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอบ
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // ตรวจสอบผลลัพธ์ของการบีบอัด
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

หรือใช้ค่า DPI ที่กำหนดเองโดยตรง:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอบ.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
เมธอดนี้แปลงภาพเป็นความละเอียดต่ำตามขนาดรูปร่างและ DPI ที่ระบุ พื้นที่ที่ถูกครอบสามารถลบได้เพื่อเพิ่มประสิทธิภาพขนาดไฟล์  
หากภาพเป็นเมต้าไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ นอกจากนี้ คุณภาพ JPEG จะถูกเก็บไว้หรือถูกลดลงเล็กน้อยตามความละเอียด เช่นเดียวกับที่ PowerPoint จัดการกับ JPEG ความละเอียดสูง  
{{% /alert %}}

## **ล็อกอัตราส่วนภาพ**

หากต้องการให้รูปร่างที่บรรจุภาพรักษาอัตราส่วนภาพแม้เมื่อเปลี่ยนขนาดภาพ คุณสามารถใช้คุณสมบัติ [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframelock/aspectratiolocked/) เพื่อตั้งค่า *Lock Aspect Ratio*  

โค้ด C# นี้แสดงวิธีล็อกอัตราส่วนของรูปร่าง:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // ตั้งค่ารูปร่างเพื่อรักษาอัตราส่วนภาพเมื่อเปลี่ยนขนาด
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 
การตั้งค่า *Lock Aspect Ratio* นี้จะรักษาอัตราส่วนของรูปร่างเท่านั้น ไม่ได้รักษาภาพที่บรรจุอยู่ภายใน  
{{% /alert %}}

## **ใช้คุณสมบัติ StretchOff**

โดยใช้คุณสมบัติ [StretchOffsetLeft](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/properties/stretchoffsetright) และ [StretchOffsetBottom](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) จากอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat) คุณสามารถกำหนดสี่เหลี่ยมเติมได้  

เมื่อกำหนดการยืดของภาพ สี่เหลี่ยมต้นฉบับจะถูกสเกลให้พอดีกับสี่เหลี่ยมเติมที่ระบุ แต่ละขอบของสี่เหลี่ยมเติมจะกำหนดโดยออฟเซ็ตเป็นเปอร์เซ็นต์จากขอบที่สอดคล้องของกล่องขอบรูปร่าง ออฟเซ็ตเปอร์เซ็นต์บวกหมายถึงการย่อเข้า ส่วนออฟเซ็ตเปอร์เซ็นต์ลบหมายถึงการขยายออก  

1. สร้างอินสแตนซ์ของคลาส [Presentation](http://www.aspose.com/api/net/slides/th/aspose.slides/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มสี่เหลี่ยม `AutoShape`  
4. สร้างภาพ  
5. ตั้งค่าประเภทการเติมของรูปร่าง  
6. ตั้งค่าโหมดเติมภาพของรูปร่าง  
7. เพิ่มภาพที่กำหนดให้เติมรูปร่าง  
8. ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบรูปร่าง  
9. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงกระบวนการที่ใช้คุณสมบัติ StretchOff:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // ตั้งค่าภาพให้ยืดจากแต่ละด้านในส่วนของรูปร่าง
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

### วิธีตรวจสอบว่ารูปแบบภาพใดบ้างที่รองรับสำหรับ PictureFrame?

Aspose.Slides รองรับทั้งภาพ raster (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านอ็อบเจกต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) รายการรูปแบบที่รองรับมักสอดคล้องกับความสามารถของเครื่องมือแปลงสไลด์และภาพ

### การเพิ่มภาพขนาดใหญ่หลายสิบภาพจะส่งผลต่อขนาดและประสิทธิภาพของ PPTX อย่างไร?

การฝังภาพขนาดใหญ่ทำให้ไฟล์ใหญ่และใช้หน่วยความจำเพิ่มขึ้น; การลิงก์ภาพช่วยลดขนาดงานนำเสนอแต่ต้องให้ไฟล์ภายนอกยังคงเข้าถึงได้ Aspose.Slides มีความสามารถในการเพิ่มภาพโดยลิงก์เพื่อลดขนาดไฟล์

### วิธีล็อกอ็อบเจกต์ภาพไม่ให้เคลื่อนย้ายหรือปรับขนาดโดยบังเอิญทำอย่างไร?

ใช้ [shape locks](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/pictureframelock/) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือการปรับขนาด) กลไกการล็อกอธิบายในบทความการป้องกันรูปร่างแยกต่างหาก [/slides/th/net/applying-protection-to-presentation/] และรองรับหลายประเภทของรูปร่างรวมถึง [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/)

### ความถูกต้องของเวกเตอร์ SVG จะถูกเก็บรักษาเมื่อส่งออกงานนำเสนอเป็น PDF/ภาพหรือไม่?

Aspose.Slides ให้คุณสกัด SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) เป็นเวกเตอร์ดั้งเดิม เมื่อ [ส่งออกเป็น PDF](/slides/th/net/convert-powerpoint-to-pdf/) หรือ [รูปแบบ raster](/slides/th/net/convert-powerpoint-to-png/) ผลลัพธ์อาจแปลงเป็น raster ขึ้นอยู่กับการตั้งค่าการส่งออก; การที่ SVG ดั้งเดิมถูกเก็บเป็นเวกเตอร์ได้รับการยืนยันโดยพฤติกรรมการสกัด  

{{% alert title="NOTE" color="warning" %}} 
วิธีการและผลลัพธ์อาจแตกต่างตามการตั้งค่าแปลงและประเภทไฟล์ปลายทาง  
{{% /alert %}}