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
- ครอบตัดภาพ
- พื้นที่ที่ถูกครอบตัด
- คุณสมบัติ StretchOff
- การจัดรูปแบบกรอบรูป
- คุณสมบัติกรอบรูป
- สเกลสัมพันธ์
- เอฟเฟกต์ภาพ
- อัตราส่วนภาพ
- ความโปร่งใสของภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เพิ่มกรอบรูปลงในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET. ทำให้กระบวนการทำงานของคุณเป็นระบบและเพิ่มประสิทธิภาพการออกแบบสไลด์."
---
## **บทนำ**

กรอบรูปคือรูปทรงที่บรรจุภาพ—มันคล้ายรูปภาพในกรอบ  

คุณสามารถเพิ่มภาพลงในสไลด์ผ่านกรอบรูปได้ วิธีนี้คุณสามารถจัดรูปแบบภาพโดยการจัดรูปแบบกรอบรูป  

{{% alert  title="เคล็ดลับ" color="primary" %}} 
Aspose มีตัวแปลงฟรี—[JPEG to PowerPoint](https://products.aspose.app/slides/th/import/jpg-to-ppt) และ [PNG to PowerPoint](https://products.aspose.app/slides/th/import/png-to-ppt)—ที่ช่วยให้ผู้ใช้สร้างงานนำเสนอได้อย่างรวดเร็วจากภาพ.  
{{% /alert %}} 

## **สร้างกรอบรูป**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/net/aspose.slides/iimagecollection) ที่เชื่อมโยงกับอ็อบเจ็กต์ presentation ซึ่งจะใช้เติมรูปทรง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe) โดยอิงความกว้างและความสูงของภาพผ่านเมธอด `AddPictureFrame` ที่เปิดให้ใช้โดยอ็อบเจ็กต์ shape ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบรูป (ที่บรรจุรูปภาพ) ลงในสไลด์  
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างกรอบรูป:  

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
 using (Presentation pres = new Presentation())
 {
     // รับสไลด์แรก
     ISlide slide = pres.Slides[0];

     // โหลดภาพและเพิ่มลงในคอลเลกชันภาพของงานนำเสนอ
     IImage image = Images.FromFile("aspose-logo.jpg");
     IPPImage ppImage = pres.Images.AddImage(image);
     image.Dispose();

     // เพิ่มกรอบรูปด้วยความสูงและความกว้างเดียวกัน
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
กรอบรูปช่วยให้คุณสร้างสไลด์การนำเสนอจากภาพได้อย่างรวดเร็ว เมื่อคุณผสมกรอบรูปกับตัวเลือกการบันทึกของ Aspose.Slides คุณสามารถจัดการการป้อนเข้า/ออกเพื่อแปลงภาพจากรูปแบบหนึ่งเป็นอีกรูปแบบหนึ่ง คุณอาจต้องการดูหน้านี้: แปลง [image to JPG](https://products.aspose.com/slides/th/net/conversion/image-to-jpg/); แปลง [JPG to image](https://products.aspose.com/slides/th/net/conversion/jpg-to-image/); แปลง [JPG to PNG](https://products.aspose.com/slides/th/net/conversion/jpg-to-png/), แปลง [PNG to JPG](https://products.aspose.com/slides/th/net/conversion/png-to-jpg/); แปลง [PNG to SVG](https://products.aspose.com/slides/th/net/conversion/png-to-svg/), แปลง [SVG to PNG](https://products.aspose.com/slides/th/net/conversion/svg-to-png/).  
{{% /alert %}}

## **สร้างกรอบรูปด้วยการปรับสเกลสัมพันธ์**

โดยการปรับสเกลสัมพันธ์ของภาพ คุณสามารถสร้างกรอบรูปที่ซับซ้อนได้มากขึ้น  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มภาพลงในคอลเลกชันภาพของ presentation  
4. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/net/aspose.slides/iimagecollection) ที่เชื่อมโยงกับอ็อบเจ็กต์ presentation ซึ่งจะใช้เติมรูปทรง  
5. ระบุความกว้างและความสูงสัมพันธ์ของภาพในกรอบรูป  
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงวิธีสร้างกรอบรูปด้วยการปรับสเกลสัมพันธ์:  

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
 using (Presentation presentation = new Presentation())
 {
     // โหลดภาพและเพิ่มลงในคอลเลกชันภาพของงานนำเสนอ
     IImage image = Images.FromFile("aspose-logo.jpg");
     IPPImage ppImage = presentation.Images.AddImage(image);
     image.Dispose();

     // เพิ่มกรอบรูปลงในสไลด์
     IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

     // ตั้งค่าความกว้างและความสูงสเกลสัมพันธ์
     pictureFrame.RelativeScaleHeight = 0.8f;
     pictureFrame.RelativeScaleWidth = 1.35f;

     // บันทึกงานนำเสนอ
     presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
 }
```

## **สกัดภาพเรสเตอร์จากกรอบรูป**

คุณสามารถสกัดภาพเรสเตอร์จากอ็อบเจ็กต์ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe) และบันทึกเป็น PNG, JPG และรูปแบบอื่น ๆ ตัวอย่างโค้ดด้านล่างแสดงวิธีสกัดภาพจากเอกสาร "sample.pptx" และบันทึกเป็นรูปแบบ PNG  

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

เมื่อการนำเสนอมีกราฟิก SVG ที่วางอยู่ภายในรูปทรง [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) Aspose.Slides for .NET จะให้คุณดึงภาพเวกเตอร์ดั้งเดิมพร้อมความเที่ยงตรงเต็มที่โดยการเดินผ่านคอลเลกชันรูปทรงของสไลด์ คุณสามารถระบุแต่ละ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/), ตรวจสอบว่า [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ที่อยู่ภายในมีเนื้อหา SVG หรือไม่ แล้วบันทึกภาพนั้นลงดิสก์หรือสตรีมในรูปแบบ SVG ดั้งเดิม  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีสกัดภาพ SVG จากกรอบรูป:  

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

Aspose.Slides อนุญาตให้คุณรับค่าเอฟเฟกต์ความโปร่งใสที่ใช้กับภาพ โค้ด C# นี้แสดงการทำงาน:  

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

## **รับค่าแสงสว่างและคอนทราสต์ของภาพ**

Aspose.Slides อนุญาตให้คุณรับค่าเอฟเฟกต์แสงสว่างและคอนทราสต์ที่ใช้กับภาพ อินเทอร์เฟซ [ILuminance](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iluminance/) แทนการแปลงภาพนี้  

โค้ด C# นี้แสดงวิธีรับการตั้งค่าแสงสว่างและคอนทราสต์จากกรอบรูป:  

```csharp
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

{{% alert color="primary" %}} 
เอฟเฟกต์ทั้งหมดที่ใช้กับภาพสามารถพบได้ใน [Aspose.Slides.Effects](https://reference.aspose.com/slides/th/net/aspose.slides.effects/).  
{{% /alert %}}

## **การจัดรูปแบบกรอบรูป**

Aspose.Slides มีตัวเลือกการจัดรูปแบบหลายอย่างที่สามารถนำไปใช้กับกรอบรูปได้ ด้วยตัวเลือกเหล่านั้นคุณสามารถปรับกรอบรูปให้ตรงตามข้อกำหนดเฉพาะ  

1. สร้างอินสแตนซ์ของคลาส [Presentation](http://www.aspose.com/api/net/slides/th/aspose.slides/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage) โดยเพิ่มภาพลงใน [IImagescollection](https://reference.aspose.com/slides/th/net/aspose.slides/iimagecollection) ที่เชื่อมโยงกับอ็อบเจ็กต์ presentation ซึ่งจะใช้เติมรูปทรง  
4. ระบุความกว้างและความสูงของภาพ  
5. สร้าง `PictureFrame` โดยอิงความกว้างและความสูงของภาพผ่านเมธอด [AddPictureFrame](http://www.aspose.com/api/net/slides/th/aspose.slides/ishapecollection/methods/addpictureframe) ที่เปิดให้ใช้โดยอ็อบเจ็กต์ [IShapes](http://www.aspose.com/api/net/slides/th/aspose.slides/ishapecollection) ที่เชื่อมโยงกับสไลด์ที่อ้างอิง  
6. เพิ่มกรอบรูป (ที่บรรจุรูปภาพ) ลงในสไลด์  
7. ตั้งค่าสีเส้นของกรอบรูป  
8. ตั้งค่าความกว้างของเส้นกรอบรูป  
9. หมุนกรอบรูปโดยกำหนดค่าเป็นบวกหรือเป็นลบ  
   * ค่าบวกจะหมุนภาพตามเข็มนาฬิกา  
   * ค่าลบจะหมุนภาพย้อนเข็มนาฬิกา  
10. เพิ่มกรอบรูป (ที่บรรจุรูปภาพ) ลงในสไลด์ (ขั้นตอนนี้ซ้ำเพื่อย้ำ)  
11. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงกระบวนการจัดรูปแบบกรอบรูป:  

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
using (Presentation presentation = new Presentation())
{
    // รับสไลด์แรก
    ISlide slide = presentation.Slides[0];

    // โหลดภาพและเพิ่มลงในคอลเลกชันภาพของงานนำเสนอ
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // เพิ่มกรอบรูปด้วยความสูงและความกกว้างที่เท่ากับของภาพ
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
Aspose เพิ่งพัฒนา [Collage Maker ฟรี](https://products.aspose.app/slides/th/collage) หากคุณต้องการรวมภาพ JPG/JPEG หรือ PNG, สร้างกริดจากรูปภาพ, คุณสามารถใช้บริการนี้ได้.  
{{% /alert %}}

## **เพิ่มภาพเป็นลิงก์**

เพื่อหลีกเลี่ยงขนาดงานนำเสนอที่ใหญ่เกินไป คุณสามารถเพิ่มภาพ (หรือวิดีโอ) ผ่านลิงก์แทนการฝังไฟล์ลงในงานนำเสนอโดยตรง โค้ด C# นี้แสดงวิธีเพิ่มภาพและวิดีโอลงในตัวแทรก:  

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

## **ครอบตัดภาพ**

โค้ด C# นี้แสดงวิธีครอบตัดภาพที่มีอยู่บนสไลด์:  

```c#
using (Presentation presentation = new Presentation())
{
    // สร้างอ็อบเจ็กต์ภาพใหม่
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

## **ลบพื้นที่ที่ถูกครอบตัดของภาพ**

หากต้องการลบพื้นที่ที่ถูกครอบตัดของภาพที่อยู่ในกรอบ คุณสามารถใช้เมธอด [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ซึ่งเมธอดนี้จะคืนภาพที่ถูกครอบตัดหรือภาพต้นฉบับหากไม่ต้องการครอบตัด  

โค้ด C# นี้แสดงการทำงานดังกล่าว:  

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // รับ PictureFrame จากสไลด์แรก
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // ลบพื้นที่ที่ถูกครอบตัดของภาพ PictureFrame และคืนภาพที่ถูกครอบตัด
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // บันทึกผลลัพธ์
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 
เมธอด [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) จะเพิ่มภาพที่ถูกครอบตัดไปยังคอลเลกชันภาพของ presentation หากภาพใช้งานเฉพาะใน [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) การตั้งค่านี้จะช่วยลดขนาดไฟล์งานนำเสนอ มิฉะนั้นจำนวนภาพในงานนำเสนอที่ได้จะเพิ่มขึ้น  

เมธอดนี้แปลงไฟล์เมต้าไฟล์ WMF/EMF เป็นภาพ PNG แบบเรสเตอร์ในขั้นตอนการครอบตัด.  
{{% /alert %}}

## **บีบอัดภาพ**

คุณสามารถบีบอัดรูปภาพในงานนำเสนอโดยใช้เมธอด [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat/compressimage/) เมธอดนี้บีบอัดภาพโดยลดขนาดตามขนาดรูปทรงและความละเอียดที่ระบุ พร้อมตัวเลือกลบพื้นที่ที่ถูกครอบตัด  

การทำงานนี้ปรับขนาดและความละเอียดของภาพคล้ายกับคุณลักษณะ **Picture Format → Compress Pictures → Resolution** ของ PowerPoint  

ตัวอย่าง C# ด้านล่างแสดงวิธีบีบอัดภาพในงานนำเสนอโดยระบุความละเอียดเป้าหมายและลบพื้นที่ที่ถูกครอบตัด (ถ้าต้องการ):  

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // บีบอัดภาพด้วยความละเอียดเป้าหมาย 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอบตัด.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // ตรวจสอบผลลัพธ์การบีบอัด.
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

หรือใช้ค่าความละเอียด DPI ที่กำหนดเองโดยตรง:  

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // บีบอัดภาพเป็น 150 DPI (ความละเอียดเว็บ) และลบพื้นที่ที่ถูกครอบตัด.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 
เมธอดจะเปลี่ยนภาพเป็นความละเอียดต่ำกว่าโดยอิงตามขนาดรูปทรงและ DPI ที่กำหนด พื้นที่ที่ถูกครอบตัดก็สามารถลบได้เพื่อเพิ่มประสิทธิภาพขนาดไฟล์  
หากภาพเป็นเมต้าไฟล์ (WMF/EMF) หรือ SVG การบีบอัดจะไม่ถูกนำมาใช้เช่นกัน นอกจากนี้คุณภาพ JPEG จะถูกเก็บไว้หรือถูกลดลงเล็กน้อยตามความละเอียด ซึ่งคล้ายกับการจัดการของ PowerPoint ต่อ JPEG ความละเอียดสูง.  
{{% /alert %}}

## **ล็อกอัตราส่วนภาพ**

หากต้องการให้รูปทรงที่บรรจุภาพคงอัตราส่วนเดิมแม้จะเปลี่ยนขนาดภาพ คุณสามารถใช้คุณสมบัติ [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframelock/aspectratiolocked/) เพื่อกำหนดการตั้งค่า *Lock Aspect Ratio*  

โค้ด C# นี้แสดงวิธีล็อกอัตราส่วนของรูปทรง:  

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // ตั้งค่ารูปร่างให้คงอัตราส่วนเมื่อปรับขนาด
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="หมายเหตุ" color="warning" %}} 
การตั้งค่า *Lock Aspect Ratio* นี้จะคงอัตราส่วนของรูปทรงเท่านั้น ไม่ได้คงอัตราส่วนของภาพที่บรรจุอยู่.  
{{% /alert %}}

## **ใช้คุณสมบัติ StretchOff**

โดยใช้คุณสมบัติ [StretchOffsetLeft](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/properties/stretchoffsetright) และ [StretchOffsetBottom](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) จากอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ipicturefillformat) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/picturefillformat) คุณสามารถกำหนดสี่เหลี่ยมเติม  

เมื่อกำหนดการยืดสำหรับภาพ สี่เหลี่ยมต้นฉบับจะถูกสเกลให้พอดีกับสี่เหลี่ยมเติมที่ระบุ แต่ละขอบของสี่เหลี่ยมเติมถูกกำหนดโดยเปอร์เซ็นต์ออฟเซ็ตจากขอบที่สอดคล้องของกล่องขอบเขตรูปทรง ค่าเปอร์เซ็นต์บวกหมายถึงการย่อเข้ามา ขนาดลบหมายถึงการขยายออกไป  

1. สร้างอินสแตนซ์ของคลาส [Presentation](http://www.aspose.com/api/net/slides/th/aspose.slides/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มสี่เหลี่ยม `AutoShape`  
4. สร้างภาพ  
5. ตั้งค่าชนิดการเติมของรูปทรง  
6. ตั้งค่าโหมดเติมรูปภาพของรูปทรง  
7. เพิ่มภาพชุดเพื่อเติมรูปทรง  
8. ระบุออฟเซ็ตของภาพจากขอบที่สอดคล้องของกล่องขอบเขตรูปทรง  
9. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้แสดงกระบวนการที่ใช้คุณสมบัติ StretchOff:  

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // ตั้งค่าการยืดภาพจากทุกด้านในเนื้อหารูปร่าง
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ฉันจะค้นหารูปแบบไฟล์ภาพที่รองรับสำหรับ PictureFrame ได้อย่างไร?**  

Aspose.Slides รองรับทั้งภาพเรสเตอร์ (PNG, JPEG, BMP, GIF ฯลฯ) และภาพเวกเตอร์ (เช่น SVG) ผ่านอ็อบเจ็กต์ภาพที่กำหนดให้กับ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/). รายการรูปแบบที่รองรับโดยทั่วไปตรงกับความสามารถของเอ็นจินการแปลงสไลด์และภาพ.

**การเพิ่มภาพขนาดใหญ่หลายสิบรูปจะส่งผลต่อขนาดและประสิทธิภาพของไฟล์ PPTX อย่างไร?**  

การฝังภาพขนาดใหญ่จะเพิ่มขนาดไฟล์และใช้หน่วยความจำมากขึ้น; การลิงก์ภาพช่วยให้ขนาดงานนำเสนอเล็กลงแต่ต้องให้ไฟล์ภายนอกสามารถเข้าถึงได้. Aspose.Slides มีความสามารถในการเพิ่มภาพแบบลิงก์เพื่อลดขนาดไฟล์.

**ฉันจะล็อกอ็อบเจ็กต์ภาพจากการย้ายหรือปรับขนาดโดยไม่ได้ตั้งใจได้อย่างไร?**  

ใช้ [shape locks](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/pictureframelock/) สำหรับ [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) (เช่น ปิดการย้ายหรือการปรับขนาด). กลไกการล็อกนี้อธิบายไว้ในบทความการปกป้องรูปทรงแยกต่างหาก [/slides/th/net/applying-protection-to-presentation/] และรองรับหลายประเภทรูปทรงรวมถึง [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/).

**ความเที่ยงตรงของเวกเตอร์ SVG จะถูกเก็บไว้เมื่อนำออกเป็น PDF/ภาพหรือไม่?**  

Aspose.Slides อนุญาตให้สกัด SVG จาก [PictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/pictureframe/) เป็นเวกเตอร์ดั้งเดิม เมื่อ [exporting to PDF](/slides/th/net/convert-powerpoint-to-pdf/) หรือ [raster formats](/slides/th/net/convert-powerpoint-to-png/) ผลลัพธ์อาจถูกเรสเตอร์ขึ้นอยู่กับการตั้งค่าเอ็กซ์พอร์ท; การสกัดยืนยันว่า SVG ดั้งเดิมยังคงเป็นเวกเตอร์.