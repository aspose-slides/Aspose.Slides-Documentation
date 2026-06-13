---
title: จัดการกรอบรูปในงานนำเสนอด้วย .NET
linktitle: กรอบรูป
type: docs
weight: 10
url: /th/net/picture-frame/
keywords:
- กรอบรูป
- เพิ่มกรอบรูป
- สร้างกรอบรูป
- เพิ่มภาพ
- สร้างภาพ
- สกัดภาพ
- ภาพเรสเตอร์
- ภาพเวกเตอร์
- ตัดภาพ
- พื้นที่ที่ถูกตัด
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบรูป
- คุณสมบัติของกรอบรูป
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
description: "เพิ่มกรอบรูปในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET ช่วยเร่งกระบวนการทำงานของคุณและเพิ่มประสิทธิภาพการออกแบบสไลด์"
---
## **บทนำ**

กรอบรูปเป็นรูปร่างที่บรรจุภาพ—คล้ายกับรูปภาพในกรอบ  

คุณสามารถเพิ่มภาพลงในสไลด์ผ่านกรอบรูปได้ วิธีนี้ทำให้คุณสามารถจัดรูปแบบภาพโดยจัดรูปแบบกรอบรูป  

{{% alert  title="เคล็ดลับ" color="primary" %}} 
Aspose มีเครื่องแปลงฟรี—[JPEG เป็น PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG เป็น PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ซึ่งช่วยให้ผู้ใช้สร้างงานนำเสนอจากภาพได้อย่างรวดเร็ว  
{{% /alert %}} 

## **สร้างกรอบรูป**

1. สร้างอินสแตนซ์ของคลาส [Presentation ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/net/aspose.slides/iimagecollection) ที่เชื่อมโยงกับอ็อบเจกต์ Presentation ที่จะใช้ในการเติมรูปร่าง  
4. กำหนดความกว้างและความสูงของภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe) โดยอิงจากความกว้างและความสูงของภาพผ่านเมธอด `AddPictureFrame` ที่เปิดให้ใช้โดยอ็อบเจ็กต์ shape ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์  
7. เขียนงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
using (Presentation pres = new Presentation())
{
    // ดึงสไลด์แรก
    ISlide slide = pres.Slides[0];

    // โหลดภาพและเพิ่มลงในคอลเลกชันภาพของงานนำเสนอ
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // เพิ่มกรอบรูปที่มีความสูงและความกว้างเท่ากัน
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // ใช้การจัดรูปแบบบางอย่างกับกรอบรูป
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
กรอบรูปช่วยให้คุณสร้างสไลด์งานนำเสนอจากภาพได้อย่างรวดเร็ว เมื่อคุณรวมกรอบรูปกับตัวเลือกการบันทึกของ Aspose.Slides คุณสามารถจัดการการใส่/ออกข้อมูลเพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง คุณอาจต้องการดูหน้าต่อไปนี้: แปลง [ภาพเป็น JPG](https://products.aspose.com/slides/th/net/conversion/image-to-jpg/); แปลง [JPG เป็นภาพ](https://products.aspose.com/slides/th/net/conversion/jpg-to-image/); แปลง [JPG เป็น PNG](https://products.aspose.com/slides/th/net/conversion/jpg-to-png/), แปลง [PNG เป็น JPG](https://products.aspose.com/slides/th/net/conversion/png-to-jpg/); แปลง [PNG เป็น SVG](https://products.aspose.com/slides/th/net/conversion/png-to-svg/), แปลง [SVG เป็น PNG](https://products.aspose.com/slides/th/net/conversion/svg-to-png/)  
{{% /alert %}}

## **สร้างกรอบรูปด้วยสเกลแบบสัมพัทธ์**

โดยการปรับสเกลสัมพัทธ์ของภาพ คุณสามารถสร้างกรอบรูปที่ซับซ้อนขึ้นได้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มภาพลงในคอลเลกชันภาพของงานนำเสนอ  
4. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/net/aspose.slides/iimagecollection) ที่เชื่อมโยงกับอ็อบเจกต์ Presentation ที่จะใช้เติมรูปร่าง  
5. กำหนดความกว้างและความสูงสัมพัทธ์ของภาพในกรอบรูป  
6. เขียนงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
using (Presentation presentation = new Presentation())
{
    // โหลดภาพและเพิ่มลงในคอลเลกชันภาพของงานนำเสนอ
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // เพิ่มกรอบรูปลงในสไลด์
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // ตั้งค่าความกว้างและความสูงของสเกลสัมพัทธ์
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // บันทึกงานนำเสนอ
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **สกัดภาพเรสเตอร์จากกรอบรูป**

คุณสามารถสกัดภาพเรสเตอร์จากอ็อบเจกต์ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe) และบันทึกเป็น PNG, JPG และรูปแบบอื่น ๆ ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดภาพจากเอกสาร "sample.pptx" และบันทึกเป็นรูปแบบ PNG  

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **สกัดภาพ SVG จากกรอบรูป**

เมื่อการนำเสนอมีกราฟิก SVG ที่วางอยู่ภายในรูปแบบ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) Aspose.Slides for .NET จะให้คุณดึงภาพเวกเตอร์ต้นฉบับพร้อมความแม่นยำเต็มที่ โดยการวนผ่านคอลเลกชันรูปร่างของสไลด์ คุณสามารถระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/), ตรวจสอบว่า [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) มีเนื้อหา SVG หรือไม่, แล้วบันทึกภาพนั้นลงดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิม  

```cs
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

Aspose.Slides ช่วยให้คุณรับเอฟเฟกต์ความโปร่งใสที่ใช้กับภาพนี้ได้ ตัวอย่างโค้ด C# แสดงการดำเนินการ  

```c#
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

{{% alert color="primary" %}} 
เอฟเฟกต์ทั้งหมดที่ใช้กับภาพสามารถพบได้ใน [Aspose.Slides.Effects](https://reference.aspose.com/slides/th/net/aspose.slides.effects/)  
{{% /alert %}}

## **การจัดรูปแบบกรอบรูป**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลายแบบที่สามารถนำไปใช้กับกรอบรูปได้ โดยใช้ตัวเลือกเหล่านั้นคุณสามารถปรับกรอบรูปให้ตรงตามความต้องการเฉพาะ  

1. สร้างอินสแตนซ์ของคลาส [Presentation](http://www.aspose.com/api/net/slides/th/aspose.slides/)  
2. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/net/aspose.slides/iimagecollection) ที่เชื่อมโยงกับอ็อบเจ็กต์ Presentation ที่จะใช้เติมรูปร่าง  
4. กำหนดความกว้างและความสูงของภาพ  
5. สร้าง `PictureFrame` โดยอิงจากความกว้างและความสูงของภาพผ่านเมธอด [AddPictureFrame](http://www.aspose.com/api/net/slides/th/aspose.slides/ishapecollection/methods/addpictureframe) ที่เปิดให้ใช้โดยอ็อบเจกต์ [IShapes](http://www.aspose.com/api/net/slides/th/aspose.slides/ishapecollection) ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์  
7. ตั้งค่าสีเส้นของกรอบรูป  
8. ตั้งค่าความกว้างของเส้นกรอบรูป  
9. หมุนกรอบรูปโดยกำหนดค่าเป็นบวกหรือเป็นลบ  
   * ค่าบวกจะหมุนภาพตามเข็มนาฬิกา  
   * ค่าลบจะหมุนภาพทวนเข็มนาฬิกา  
10. เพิ่มกรอบรูป (ที่บรรจุภาพ) ลงในสไลด์  
11. เขียนงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
using (Presentation presentation = new Presentation())
{
    // ดึงสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // โหลดภาพและเพิ่มลงในคอลเลกชันภาพของงานนำเสนอ
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // เพิ่มกรอบรูปที่มีความสูงและความกว้างเท่ากับภาพ
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // ใช้การจัดรูปแบบบางอย่างกับกรอบรูป
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 
Aspose เพิ่งพัฒนา [Collage Maker ฟรี](https://products.aspose.app/slides/th/collage) หากคุณต้องการ [รวม JPG/JPEG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG, หรือ [สร้างกริดจากรูปภาพ](https://products.aspose.app/slides/th/collage/photo-grid) คุณสามารถใช้บริการนี้ได้  
{{% /alert %}}

## **เพิ่มภาพเป็นลิงก์**

เพื่อหลีกเลี่ยงขนาดงานนำเสนอที่ใหญ่ คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์โดยตรงในงานนำเสนอ ตัวอย่างโค้ด C# นี้แสดงวิธีเพิ่มภาพและวิดีโอลงในตัวตำแหน่งเก็บข้อมูล  

```c#
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

## **ตัดภาพ**

ตัวอย่างโค้ด C# นี้แสดงวิธีตัดภาพที่มีอยู่บนสไลด์  

```c#
using (Presentation presentation = new Presentation())
{
    // สร้างอ็อบเจกต์ภาพใหม่
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // เพิ่ม PictureFrame ลงในสไลด์
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // ครอบตัดภาพ (ค่าร้อยละ)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // บันทึกผลลัพธ์
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **ลบพื้นที่ที่ถูกตัดของภาพ**

หากต้องการลบพื้นที่ที่ถูกตัดของภาพที่อยู่ในกรอบ คุณสามารถใช้เมธอด [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) เมธอดนี้จะคืนภาพที่ถูกตัดหรือภาพต้นฉบับหากไม่จำเป็นต้องตัด  

ตัวอย่างโค้ด C# แสดงการดำเนินการ  

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // ดึง PictureFrame จากสไลด์แรก
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // ลบพื้นที่ที่ถูกตัดของภาพใน PictureFrame และคืนภาพที่ถูกตัด
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // บันทึกผลลัพธ์
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 
เมธอด [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) จะเพิ่มภาพที่ถูกตัดลงในคอลเลกชันภาพของงานนำเสนอ หากภาพใช้เฉพาะใน [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) ที่ประมวลผล การตั้งค่านี้สามารถลดขนาดงานนำเสนอได้ มิฉะนั้น จำนวนภาพในงานนำเสนอที่ได้จะเพิ่มขึ้น  

เมธอดนี้แปลงไฟล์เมตาฟाइल WMF/EMF ให้เป็นภาพ PNG เรสเตอร์ในกระบวนการตัด  
{{% /alert %}}

## **บีบอัดภาพ**

คุณสามารถบีบอัดรูปภาพในงานนำเสนอโดยใช้เมธอด [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/compressimage/) เมธอดนี้จะบีบอัดภาพโดยลดขนาดตามขนาดรูปร่างและความละเอียดที่ระบุ พร้อมตัวเลือกให้ลบพื้นที่ที่ถูกตัด  

มันปรับขนาดและความละเอียดของภาพเช่นเดียวกับฟีเจอร์ **Picture Format → Compress Pictures → Resolution** ของ PowerPoint  

ตัวอย่าง C# ต่อไปนี้แสดงวิธีบีบอัดภาพในงานนำเสนอโดยระบุความละเอียดเป้าหมายและอาจลบพื้นที่ที่ถูกตัด  

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกตัด
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

หรือใช้ค่า DPI ที่กำหนดเองโดยตรง  

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกตัด
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 
เมธอดจะปรับภาพให้มีความละเอียดต่ำลงตามขนาดของรูปร่างและ DPI ที่ให้ไว้ พื้นที่ที่ถูกตัดสามารถลบเพื่อเพิ่มประสิทธิภาพขนาดไฟล์  
หากภาพเป็นเมตาฟाइल (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำไปใช้ นอกจากนี้คุณภาพ JPEG จะถูกเก็บไว้หรือถูกลดลงเล็กน้อยตามความละเอียด เหมือนกับที่ PowerPoint จัดการ JPEG ความละเอียดสูง  
{{% /alert %}}

## **ล็อกอัตราส่วนภาพ**

ถ้าต้องการให้รูปร่างที่บรรจุภาพรักษาอัตราส่วนภาพแม้จะเปลี่ยนขนาดภาพ คุณสามารถใช้คุณสมบัติ [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframelock/aspectratiolocked/) เพื่อตั้งค่า *Lock Aspect Ratio*  

ตัวอย่างโค้ด C# นี้แสดงวิธีล็อกอัตราส่วนของรูปร่าง  

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // ตั้งค่ารูปร่างให้รักษาอัตราส่วนภาพเมื่อปรับขนาด
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 
การตั้งค่า *Lock Aspect Ratio* นี้จะรักษาอัตราส่วนของรูปร่างเท่านั้น ไม่ได้รักษาภาพที่บรรจุอยู่ภายใน  
{{% /alert %}}

## **ใช้คุณสมบัติ StretchOff**

โดยใช้คุณสมบัติ [StretchOffsetLeft](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/properties/stretchoffsetright) และ [StretchOffsetBottom](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) จากอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat) คุณสามารถระบุสี่เหลี่ยมเติมได้  

เมื่อกำหนดการยืดสำหรับภาพ สี่เหลี่ยมต้นฉบับจะถูกสเกลเพื่อพอดีกับสี่เหลี่ยมเติมที่ระบุ แต่ละขอบของสี่เหลี่ยมเติมจะกำหนดโดยเปอร์เซ็นต์ออฟเซ็ตจากขอบที่สอดคล้องของกล่องขอบเขตรูปร่าง ค่าเปอร์เซ็นต์บวกหมายถึงการย่อเข้า ส่วนค่าเปอร์เซ็นต์ลบหมายถึงการขยายออก  

1. สร้างอินสแตนซ์ของ [Presentation](http://www.aspose.com/api/net/slides/th/aspose.slides/) class.  
2. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มสี่เหลี่ยม `AutoShape`  
4. สร้างภาพ  
5. ตั้งค่าชนิดการเติมของรูปร่าง  
6. ตั้งค่าโหมดการเติมรูปของรูปร่าง  
7. เพิ่มภาพที่ตั้งค่าเพื่อเติมรูปร่าง  
8. ระบุการเยื้องของภาพจากขอบที่สอดคล้องของกล่องขอบเขตรูปร่าง  
9. เขียนงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // ตั้งค่าภาพให้ยืดจากแต่ละด้านในรูปร่าง
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**ฉันจะหาว่ารูปแบบภาพใดบ้างที่รองรับสำหรับ PictureFrame?**  
Aspose.Slides รองรับทั้งภาพเรสเตอร์ (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านอ็อบเจกต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) รายการรูปแบบที่รองรับโดยทั่วไปจะสอดคล้องกับความสามารถของเอนจินการแปลงสไลด์และภาพ  

**การเพิ่มรูปภาพขนาดใหญ่หลายสิบรูปจะส่งผลต่อขนาดและประสิทธิภาพของ PPTX อย่างไร?**  
การฝังภาพขนาดใหญ่จะเพิ่มขนาดไฟล์และการใช้หน่วยความจำ; การลิงก์ภาพช่วยให้ขนาดงานนำเสนอคงที่แต่ต้องมีไฟล์ภายนอกที่เข้าถึงได้ Aspose.Slides มีความสามารถในการเพิ่มภาพโดยลิงก์เพื่อบีบอัดขนาดไฟล์  

**ฉันจะล็อกอ็อบเจกต์ภาพไม่ให้ถูกย้ายหรือปรับขนาดโดยบังเอิญได้อย่างไร?**  
ใช้ [shape locks](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/pictureframelock/) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือการปรับขนาด) กลไกการล็อกอธิบายไว้ในบทความ [protection article](/slides/th/net/applying-protection-to-presentation/) แยกต่างหากและรองรับรูปแบบรูปร่างต่าง ๆ รวมถึง [PictureFrame]  

**ความแม่นยำของเวกเตอร์ SVG จะถูกเก็บไว้เมื่อนำงานนำเสนอส่งออกเป็น PDF/รูปภาพหรือไม่?**  
Aspose.Slides อนุญาตให้สกัด SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) เป็นเวกเตอร์ดั้งเดิม เมื่อ [exporting to PDF](/slides/th/net/convert-powerpoint-to-pdf/) หรือ [raster formats](/slides/th/net/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกเรสเตอร์ขึ้นอยู่กับการตั้งค่าการส่งออก; การที่ SVG ดั้งเดิมยังคงเป็นเวกเตอร์ได้รับการยืนยันจากพฤติกรรมการสกัด 