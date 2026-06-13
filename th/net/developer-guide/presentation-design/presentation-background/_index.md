---
title: "จัดการพื้นหลังการนำเสนอใน .NET"
linktitle: "พื้นหลังสไลด์"
type: docs
weight: 20
url: /th/net/presentation-background/
keywords:
- "พื้นหลังการนำเสนอ"
- "พื้นหลังสไลด์"
- "สีทึบ"
- "สีไล่ระดับ"
- "พื้นหลังภาพ"
- "ความโปร่งแสงของพื้นหลัง"
- "คุณสมบัติพื้นหลัง"
- "PowerPoint"
- "OpenDocument"
- "การนำเสนอ"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "เรียนรู้วิธีตั้งค่าพื้นหลังแบบไดนามิกในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ .NET พร้อมเคล็ดลับโค้ดที่จะยกระดับการนำเสนอของคุณ"
---
## **บทนำ**

สีทึบ, ไล่ระดับสี, และรูปภาพมักถูกใช้เป็นพื้นหลังของสไลด์ คุณสามารถกำหนดพื้นหลังสำหรับ **สไลด์ปกติ** (สไลด์เดียว) หรือ **สไลด์หลัก** (ใช้กับหลายสไลด์พร้อมกัน)

![PowerPoint background](powerpoint-background.png)

## **ตั้งค่าพื้นหลังสีทึบสำหรับสไลด์ปกติ**

Aspose.Slides อนุญาตให้คุณตั้งค่าสีทึบเป็นพื้นหลังของสไลด์เฉพาะในงานนำเสนอ แม้ว่างานนำเสนอจะใช้สไลด์หลัก การเปลี่ยนแปลงจะส่งผลเฉพาะกับสไลด์ที่เลือกเท่านั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
2. ตั้งค่า [BackgroundType] ของสไลด์เป็น `OwnBackground`  
3. ตั้งค่า [FillType] ของพื้นหลังสไลด์เป็น `Solid`  
4. ใช้คุณสมบัติ [SolidFillColor](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/solidfillcolor/) บน [FillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/) เพื่อระบุสีพื้นหลังทึบ  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C# ด้านล่างแสดงวิธีตั้งค่าสีทึบสีน้ำเงินเป็นพื้นหลังของสไลด์ปกติ:

```cs
// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // ตั้งค่าสีพื้นหลังของสไลด์เป็นสีน้ำเงิน.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // บันทึกงานนำเสนอลงดิสก์.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **ตั้งค่าพื้นหลังสีทึบสำหรับสไลด์หลัก**

Aspose.Slides อนุญาตให้คุณตั้งค่าสีทึบเป็นพื้นหลังของสไลด์หลักในงานนำเสนอ สไลด์หลักทำหน้าที่เป็นแม่แบบที่ควบคุมการจัดรูปแบบของสไลด์ทั้งหมด ดังนั้นเมื่อคุณเลือกสีทึบสำหรับพื้นหลังของสไลด์หลัก สีนี้จะใช้กับทุกสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
2. ตั้งค่า [BackgroundType] ของสไลด์หลัก (ผ่าน `masters`) เป็น `OwnBackground`  
3. ตั้งค่า [FillType] ของพื้นหลังสไลด์หลักเป็น `Solid`  
4. ใช้ [SolidFillColor] เพื่อระบุสีพื้นหลังทึบ  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C# ด้านล่างแสดงวิธีตั้งค่าสีทึบ (สีเขียวป่า) เป็นพื้นหลังของสไลด์หลัก:

```cs
// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // ตั้งค่าสีพื้นหลังของสไลด์ Master เป็นสีเขียวป่า.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // บันทึกงานนำเสนอลงดิสก์.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **ตั้งค่าพื้นหลังไล่ระดับสีสำหรับสไลด์**

ไล่ระดับสีเป็นเอฟเฟกต์กราฟิกที่สร้างจากการเปลี่ยนแปลงสีอย่างค่อยเป็นค่อยไป เมื่อใช้เป็นพื้นหลังของสไลด์ ไล่ระดับสีสามารถทำให้งานนำเสนอดูศิลป์และเป็นมืออาชีพมากขึ้น Aspose.Slides อนุญาตให้คุณตั้งค่าสีไล่ระดับเป็นพื้นหลังของสไลด์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
2. ตั้งค่า [BackgroundType] ของสไลด์เป็น `OwnBackground`  
3. ตั้งค่า [FillType] ของพื้นหลังสไลด์เป็น `Gradient`  
4. ใช้คุณสมบัติ [GradientFormat](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/gradientformat/) บน [FillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/) เพื่อกำหนดการตั้งค่าไล่ระดับที่ต้องการ  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C# ด้านล่างแสดงวิธีตั้งค่าสีไล่ระดับเป็นพื้นหลังของสไลด์:

```cs
// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // ใช้เอฟเฟกต์ไล่ระดับสีกับพื้นหลัง.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // บันทึกงานนำเสนอลงดิสก์.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **ตั้งค่าภาพเป็นพื้นหลังของสไลด์**

นอกจากการเติมสีทึบและไล่ระดับแล้ว Aspose.Slides ยังอนุญาตให้คุณใช้รูปภาพเป็นพื้นหลังของสไลด์ได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
2. ตั้งค่า [BackgroundType] ของสไลด์เป็น `OwnBackground`  
3. ตั้งค่า [FillType] ของพื้นหลังสไลด์เป็น `Picture`  
4. โหลดภาพที่ต้องการใช้เป็นพื้นหลังของสไลด์  
5. เพิ่มภาพลงในคอลเลกชันภาพของงานนำเสนอ  
6. ใช้คุณสมบัติ [PictureFillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/picturefillformat/) บน [FillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/fillformat/) เพื่อกำหนดภาพเป็นพื้นหลัง  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่าง C# ด้านล่างแสดงวิธีตั้งค่าภาพเป็นพื้นหลังของสไลด์:

```c#
// Create an instance of the Presentation class.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Set background image properties.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Load the image.
    IImage image = Images.FromFile("Tulips.jpg");
    // Add the image to the presentation's image collection.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Save the presentation to disk.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตั้งค่าชนิดการเติมพื้นหลังเป็นภาพที่ทำเป็นลายกระเบื้องและแก้ไขคุณสมบัติลายกระเบื้อง:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // ตั้งค่าภาพที่ใช้สำหรับเติมพื้นหลัง.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // ตั้งค่าโหมดเติมภาพเป็นแบบกระเบื้องและปรับคุณสมบัติของกระเบื้อง.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

อ่านเพิ่มเติม: [**ภาพต่อเป็นพื้นผิว**](/slides/th/net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **เปลี่ยนความโปร่งใสของภาพพื้นหลัง**

คุณอาจต้องการปรับความโปร่งใสของภาพพื้นหลังของสไลด์เพื่อให้เนื้อหาในสไลด์โดดเด่นขึ้น โค้ด C# ด้านล่างแสดงวิธีเปลี่ยนความโปร่งใสของภาพพื้นหลังสไลด์:

```cs
var transparencyValue = 30; // ตัวอย่างเช่น.

// ดึงคอลเลกชันของการแปลงรูปภาพ.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// ค้นหาเอฟเฟกต์ความโปร่งใสแบบเปอร์เซ็นต์คงที่ที่มีอยู่.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// ตั้งค่าความโปร่งใสใหม่.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```

## **ดึงค่าพื้นหลังของสไลด์**

Aspose.Slides มีอินเทอร์เฟซ [IBackgroundEffectiveData](https://reference.aspose.com/slides/th/net/aspose.slides/ibackgroundeffectivedata/) สำหรับดึงค่าพื้นหลังที่มีผลของสไลด์ อินเทอร์เฟซนี้เปิดเผย [FillFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ibackgroundeffectivedata/fillformat/) และ [EffectFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ibackgroundeffectivedata/effectformat/) ที่มีผล

โดยใช้คุณสมบัติ `background` ของคลาส [BaseSlide](https://reference.aspose.com/slides/th/net/aspose.slides/baseslide/) คุณสามารถรับพื้นหลังที่มีผลของสไลด์ได้

ตัวอย่าง C# ด้านล่างแสดงวิธีดึงค่าพื้นหลังที่มีผลของสไลด์:

```cs
// สร้างอินสแตนซ์ของคลาส Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // ดึงพื้นหลังที่มีผลโดยคำนึงถึง master, layout และ theme.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถรีเซ็ตพื้นหลังที่กำหนดเองและคืนค่าเป็นพื้นหลังของธีม/เลย์เอาต์ได้หรือไม่?**

ได้ค่ะ เพียงลบการเติมที่กำหนดเองของสไลด์ แล้วพื้นหลังจะสืบทอดจากสไลด์ [layout](/slides/th/net/slide-layout/)/[master](/slides/th/net/slide-master/) ที่สอดคล้อง (คือ [theme background](/slides/th/net/presentation-theme/))

**ถ้าฉันเปลี่ยนธีมของงานนำเสนอภายหลัง พื้นหลังจะเกิดอะไรขึ้น?**

หากสไลด์มีการเติมของตนเอง มันจะคงอยู่โดยไม่เปลี่ยนแปลง หากพื้นหลังสืบทอดจาก [layout](/slides/th/net/slide-layout/)/[master](/slides/th/net/slide-master/) จะอัปเดตให้ตรงกับ [theme ใหม่](/slides/th/net/presentation-theme/)