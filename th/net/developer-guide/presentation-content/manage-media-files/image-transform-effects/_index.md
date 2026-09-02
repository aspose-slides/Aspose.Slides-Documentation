---
title: จัดการเอฟเฟกต์การแปลงภาพในพรีเซ็นเทชันด้วย .NET
linktitle: เอฟเฟกต์การแปลงภาพ
type: docs
weight: 11
url: /th/net/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟกต์รูปภาพ
- ความสว่าง
- ความคอนทราสต์
- สีเทา
- โทนคู่
- การเติมสี
- HSL
- การแทนสี
- การเบลอ
- ความโปร่งใส
- เอฟเฟกต์อัลฟา
- โซ่เอฟเฟกต์
- PowerPoint
- พรีเซ็นเทชัน
- .NET
- C#
- Aspose.Slides
description: "ใช้, จัดเรียงโซ่, ตรวจสอบ, ลบ, และตรวจสอบความถูกต้องของเอฟเฟกต์การแปลงภาพสำหรับกรอบรูปภาพด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับภาพเป็นคอลเลกชันที่เรียงลำดับของการทำงานเปลี่ยนแปลงภาพ (image transform operations) สำหรับกรอบภาพ ให้เริ่มต้นด้วย [ISlidesPicture](https://reference.aspose.com/slides/th/net/aspose.slides/islidespicture/) ของกรอบ แล้วเข้าถึง [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/th/net/aspose.slides/islidespicture/imagetransform/). คอลเลกชันที่ส่งคืนคือ [IImageTransformOperationCollection](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/) ซึ่งช่วยให้คุณเพิ่ม, แสดงรายการ, ตรวจสอบ, ลบและล้างเอฟเฟกต์ได้โดยไม่ต้องเขียนไบต์ของภาพต้นฉบับใหม่

บทความนี้สาธิตกระบวนการทำงานครบวงจรสำหรับความสว่างและความคอนทราสต์, การแปลงสี, การเบลอ, ความโปร่งใส, โซ่เอฟเฟกต์ที่เรียงลำดับ, ค่าที่มีผล, การลบ, และการตรวจสอบการเดินทางรอบ PPTX

## **ทำความเข้าใจความเป็นเจ้าของเอฟเฟกต์และการใช้ภาพซ้ำ**

แหล่งภาพและรูปภาพที่แสดงภาพเป็นอ็อบเจ็กต์ที่แตกต่างกัน:

- [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นฉบับที่เป็นของพรีเซ็นเทชัน
- [ISlidesPicture](https://reference.aspose.com/slides/th/net/aspose.slides/islidespicture/) เป็นส่วนของการเติมรูปภาพและอ้างอิงไปยังแหล่งภาพพร้อมกับเก็บคอลเลกชันการแปลงภาพ
- [IPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ipictureframe/) คือรูปร่างบนสไลด์ที่เป็นเจ้าของการเติมรูป, รูปร่างเรขาตรณี, การครอปและการจัดรูปแบบระดับกรอบอื่น ๆ

ดังนั้น การทำงานเปลี่ยนแปลงภาพจะไม่แก้ไขไบต์ใน [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/). เมื่อ `IPPImage` เดียวกันถูกส่งเข้าไปที่ [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addpictureframe/) มากกว่าหนึ่งครั้ง แต่ละกรอบภาพใหม่จะได้รับ `ISlidesPicture` ของตนเองและคอลเลกชันการแปลงของตนเอง การใส่สีเทา (grayscale) ให้กับกรอบหนึ่งจะไม่ทำให้กรอบอื่นเป็นสีเทา แม้ว่าทั้งหมดจะใช้แหล่งภาพที่ฝังอยู่เดียวกัน

โมเดล `ISlidesPicture.ImageTransform` เดียวกันนี้ยังใช้กับการเติมรูปภาพอื่น ๆ เช่น รูปร่างหรือพื้นหลังสไลด์ ตัวอย่างด้านล่างมุ่งเน้นที่กรอบภาพ

## **ใช้ช่วงค่าพารามิเตอร์และหน่วยที่ถูกต้อง**

วิธีการที่แสดงใช้ช่วงค่าและหน่วยตามความหมายต่อไปนี้ รักษาค่าภายในช่วงเหล่านี้แม้ว่าเวอร์ชันไลบรารีบางรุ่นอาจไม่ปฏิเสธค่าที่อยู่นอกช่วงทันที; รูปแบบพรีเซ็นเทชันเป้าหมายอาจทำให้ค่าปกติ, ลบ, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| การดำเนินการ | พารามิเตอร์ | ช่วงค่าและหน่วยที่ถูกต้อง |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` ถึง `100`, เปอร์เซ็นต์; `0` ไม่เปลี่ยนแปลงส่วนประกอบ |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | ไม่มี | ไม่มีพารามิเตอร์เชิงจำนวน. ค่า Alpha ไม่เปลี่ยนแปลง |
| [AddDuotoneEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | สองสีสำหรับพิกเซลมืดและสว่าง. ช่องสี RGB และ Alpha ใน `System.Drawing.Color` ใช้ค่า `0` ถึง `255` |
| [AddTintEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | hue อยู่ระหว่าง `0` รวมถึง `360` ไม่รวม, หน่วยเป็นองศา; amount อยู่ระหว่าง `-100` ถึง `100`, เปอร์เซ็นต์ |
| [AddHSLEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | hue อยู่ระหว่าง `0` รวมถึง `360` ไม่รวม, หน่วยเป็นองศา; saturation และ luminance อยู่ระหว่าง `-100` ถึง `100`, เปอร์เซ็นต์ |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | สีที่แทนที่ใช้ค่าช่องจาก `0` ถึง `255`. ค่าความโปร่งใส (alpha) เดิมไม่เปลี่ยน |
| [AddBlurEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | radius ต้องเป็นค่าที่ไม่เป็นลบและหน่วยเป็น point; `grow` เป็น Boolean ที่กำหนดว่าจะให้เนื้อหาที่เบลอขยายออกนอกขอบเดิมหรือไม่ |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | เปอร์เซ็นต์ที่ไม่เป็นลบ. ใช้ `0` ถึง `100` สำหรับการปรับความทึบแบบปกติ: `0` คือโปร่งใสเต็มที่และ `100` คงค่า alpha เดิม |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` ถึง `100`, เปอร์เซ็นต์ความทึบ |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` ถึง `100`, เปอร์เซ็นต์ค่าเกณฑ์ alpha. ค่าที่ต่ำกว่าจะเป็นโปร่งใส; ค่าที่เท่าหรือสูงกว่าจะเป็นทึบ |

สำหรับการปรับค่า alpha แบบคงที่ ความโปร่งใสและความทึบเป็นค่าสำรองกัน ตัวอย่างเช่น ความโปร่งใส 35% เทียบกับค่า modulation ของ alpha ที่ 65%

## **ปรับความสว่างและความคอนทราสต์**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) จะคืนค่าออบเจ็กต์การทำงาน [IBrightnessContrast](https://reference.aspose.com/slides/th/net/aspose.slides.effects/ibrightnesscontrast/). ค่าตัวสเกลตั้งต้นจะถูกส่งเมื่อสร้างการทำงานนั้น [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/th/net/aspose.slides.effects/brightnesscontrast/geteffective/) จะคืนค่าที่คำนวนแล้วแบบอ่านอย่างเดียวซึ่งสามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และความคอนทราสต์ 20% แล้วแสดงตัวอย่างโดยไม่แก้ไขภาพที่ฝังไว้:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/th/net/aspose.slides.effects/brightnesscontrast/) เป็นส่วนขยายเอฟเฟกต์รูปภาพของ Office 2010 และมีพกพาน้อยกว่าเอฟเฟกต์ luminance ของ DrawingML มาตรฐาน หากต้องการให้ความสว่างและความคอนทราสต์ยังคงแก้ไขได้หลังการเดินทางรอบ PPTX ให้ใช้ [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) และตรวจสอบผลลัพธ์หลังจากเปิดไฟล์ใหม่ ส่วนข้อจำกัดของรูปแบบอธิบายความแตกต่างนี้อย่างละเอียดเพิ่มเติม

## **ปรับการแปลงสี**

เอฟเฟกต์สีสามารถนำไปใช้แยกกันกับกรอบภาพหลายกรอบที่ใช้แหล่งภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้ากรอบและใส่เอฟเฟกต์สีเทา, duotone, tint, การปรับ HSL, และการแทนสี

[IDuotone](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iduotone/) มีพารามิเตอร์สีสองตัวที่แก้ไขได้แยกกัน: `Color1` ใช้สำหรับพิกเซลมืด ส่วน `Color2` ใช้สำหรับพิกเซลสว่าง นี่เป็นตัวอย่างที่ดีของเอฟเฟกต์ที่การตั้งค่าซับซ้อนกว่าค่าตัวสเกลเดียว

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งสีขณะที่คงค่า alpha อยู่ ซึ่งแตกต่างจาก [AddColorChangeEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) ที่แมพสีต้นฉบับเป็นสีเป้าหมายและเปิดเผยรูปแบบสีต้นและเป้าหมายทั้งสอง

## **เพิ่มเอฟเฟกต์การเบลอ, ความโปร่งใสและ Alpha**

[AddBlurEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) มีผลต่อทุกช่องสีรวมถึง alpha. ตั้งค่า `grow` เป็น `true` เมื่อขอบที่เบลออาจขยายออกนอกขอบภาพเดิม

สำหรับความโปร่งใสแบบสม่ำเสมอให้ใช้ [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). มันคูณค่า alpha ปัจจุบันทุกค่า ทำให้พิกเซลที่มีความโปร่งใสบางส่วนยังคงแตกต่างกันตามสัดส่วน [AddAlphaReplaceEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) จะกำหนดค่า alpha หนึ่งค่าให้กับพิกเซลทั้งหมด [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) จะแปลงค่า alpha เป็นสองระดับตามเกณฑ์ที่กำหนด

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

เอฟเฟกต์ alpha ที่ไม่มีพารามิเตอร์อื่น ๆ รวมถึง [AddAlphaCeilingEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) ที่ทำให้ค่า alpha ที่ไม่เป็นศูนย์ทั้งหมดกลายเป็นทึบเต็ม, [AddAlphaFloorEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) ที่ทำให้ค่า alpha ใด ๆ ที่ต่ำกว่า 100% กลายเป็นโปร่งใสเต็ม, และ [AddAlphaInverseEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) ที่แปลง alpha เป็น `100% - alpha`

## **สร้างโซ่เอฟเฟกต์ที่เรียงลำดับ**

แต่ละเมธอด `Add...Effect` จะเพิ่มการทำงานใหม่ต่อท้ายคอลเลกชัน ตัวเรนเดอร์ใช้คอลเลกชันเป็นไปป์ไลน์ที่เรียงลำดับ: ผลลัพธ์จากการทำงาน 0 จะเป็นอินพุตของการทำงาน 1, ต่อไปเช่นนั้น ดังนั้นการจัดลำดับการทำงานต่างกันอาจให้ผลลัพธ์ภาพที่แตกต่างกัน

เช่น การทำ grayscale ตามด้วย tint จะลบข้อมูลสีแล้วทำสีใหม่บนผลลัพธ์ luminance ส่วนการทำ tint ตามด้วย grayscale จะลบ tint อีกครั้ง เช่นเดียวกับการแทนที่ค่า alpha สามารถเขียนทับค่าที่คำนวณโดยการทำงานก่อนหน้า ส่วนการปรับค่า alpha จะคงความแตกต่างเชิงสัมพัทธ์ไว้

ตัวอย่างต่อไปนี้สร้างโซ่ที่มีสี่การทำงาน, บันทึกเป็น PPTX, เปิดพรีเซ็นเทชันใหม่, ตรวจสอบประเภทการทำงานและลำดับของพวกมัน, แล้วเรนเดอร์ผลลัพธ์ที่เปิดใหม่:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

คอลเลกชันไม่ได้บังคับให้มีเมทริกซ์ความเข้ากันได้ที่จำกัดการทำงานสี, alpha และ blur ให้แยกกันเป็นโซ่ พวกมันสามารถรวมกันได้ แต่บางการผสมอาจไม่มีประโยชน์ การแทนที่สีคงที่จะลบความแปรผันของ RGB ที่เกิดจากเอฟเฟกต์สีก่อนหน้า; การทำ grayscale หลัง duotone จะลบสีที่เลือกสองสี; และการทำ alpha ceiling, floor, replacement หรือ bi‑level สามารถทิ้งรายละเอียด alpha ที่สร้างขึ้นก่อนหน้า สร้างโซ่ตามลำดับการประมวลผลพิกเซลที่ต้องการแทนที่จะมองรายการเป็นแฟล็กการจัดรูปแบบที่ไม่มีลำดับ

## **ตรวจสอบค่าที่แก้ไขได้และค่าที่มีผล**

การทำงานที่แก้ไขได้คือออบเจ็กต์ที่เก็บอยู่ใน `ISlidesPicture.ImageTransform`. ตามเอฟเฟกต์ อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง ตัวอย่างเช่น [IBlur](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iblur/) เปิดเผย `Radius` และ `Grow` ที่เขียนได้, [IAlphaModulateFixed](https://reference.aspose.com/slides/th/net/aspose.slides.effects/ialphamodulatefixed/) เปิดเผย `Amount`, และ [IAlphaBiLevel](https://reference.aspose.com/slides/th/net/aspose.slides.effects/ialphabilevel/) เปิดเผย `Threshold`. เอฟเฟกต์สีเช่น [IDuotone](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iduotone/) เปิดเผยออบเจ็กต์ [IColorFormat](https://reference.aspose.com/slides/th/net/aspose.slides/icolorformat/) ที่แก้ไขได้

บางอินเทอร์เฟซการทำงาน เช่น [IBrightnessContrast](https://reference.aspose.com/slides/th/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/th/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/th/net/aspose.slides.effects/itint/), และ [IAlphaReplace](https://reference.aspose.com/slides/th/net/aspose.slides.effects/ialphareplace/) ไม่เปิดเผยสเกลเมื่อนสร้างเป็นพร็อพเพอร์ตี้ที่เขียนได้ เพื่อเปลี่ยนการตั้งค่าเหล่านั้นให้ลบการทำงานนั้นและเพิ่มการทำงานใหม่ในตำแหน่งที่ต้องการ

ข้อมูลที่มีผลที่คืนโดย `GetEffective()` ถูกคำนวนและเป็นแบบอ่าน‑อย่างเดียว ใช้สำหรับแก้ไขสีที่ขึ้นกับธีมและอ่านค่าปกติที่เรนเดอร์ใช้ แต่ไม่ได้เป็นพื้นผิวการแก้ไขอีกชั้น ตัวอย่างต่อไปนี้แสดงรายการโซ่และตรวจสอบค่าที่มีผลในที่ที่ API ให้ข้อมูล:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

เอฟเฟกต์ที่ไม่มีพารามิเตอร์เช่น grayscale, alpha ceiling, และ alpha inverse ยังมีออบเจ็กต์ข้อมูลที่มีผล แต่ไม่มีการตั้งค่าสเกลให้พิมพ์ออกมา การมีอยู่และตำแหน่งในคอลเลกชันเป็นข้อมูลสำคัญ

## **ลบหรือทำความสะอาดการแปลงภาพ**

ใช้ [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) เพื่อลบการทำงานหนึ่งตามดัชนี เนื่องจากดัชนีจะเปลี่ยนเมื่อมีการลบ จึงควรค้นหาเป้าหมายก่อนและลบหลังจากแสดงรายการ ใช้ `Clear()` เพื่อลบโซ่ทั้งหมด

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

การลบหรือทำความสะอาดการแปลงจะเปลี่ยนเฉพาะการจัดรูปแบบของภาพเท่านั้น ไม่ได้ลบ, บีบอัดซ้ำ หรือแก้ไขแหล่งภาพ [IPPImage](https://reference.aspose.com/slides/th/net/aspose.slides/ippimage/) ที่ใช้ซ้ำ

## **พิจารณารูปแบบพรีเซ็นเทชันและจุดหมายการส่งออก**

การแปลงภาพมีต้นกำเนิดจาก DrawingML ดังนั้น PPTX จึงเป็นรูปแบบที่แนะนำสำหรับการแก้ไขโซ่เอฟเฟกต์ แม้กับ PPTX ก็ไม่ได้ทุกการทำงานมีความพกพาที่เท่าเทียมกัน:

- การทำงาน DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur และการทำงาน alpha ทั่วไป มีโอกาสรอดชีวิตจากการเดินทางรอบ PPTX มากที่สุด ควรเปิดไฟล์ที่สร้างใหม่และตรวจสอบคอลเลกชันเมื่อความคงที่เป็นข้อกำหนด
- [BrightnessContrast](https://reference.aspose.com/slides/th/net/aspose.slides.effects/brightnesscontrast/) เป็นส่วนขยายของ Office 2010 ไม่ใช่การทำงาน luminance ของ DrawingML มาตรฐาน สามารถใช้สำหรับเรนเดอร์ในหน่วยความจำได้ แต่ไม่รับประกันว่าจะยังคงเป็น [IBrightnessContrast](https://reference.aspose.com/slides/th/net/aspose.slides.effects/ibrightnesscontrast/) ที่แก้ไขได้หลังการบันทึกและเปิด PPTX ใหม่ ควรเลือกใช้ [AddLuminanceEffect](https://reference.aspose.com/slides/th/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) สำหรับการปรับความสว่างและความคอนทราสต์ที่คงที่
- รูปแบบไบนารี PPT มีมาตรฐานก่อนที่โมเดลเอฟเฟกต์ DrawingML จะสมบูรณ์ การบันทึกเป็น PPT อาจละเว้นการทำงานที่ไม่สนับสนุน ลดโซ่ให้เป็นส่วนย่อยที่สนับสนุน หรือประมาณลักษณะ อย่าใช้ PPT เป็นรูปแบบการตรวจสอบสำหรับโซ่ที่แก้ไขได้ซับซ้อน
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือรูปแบบภาพอื่น ๆ จะใช้โซ่ที่สนับสนุนในการสร้างภาพที่แสดงผล รูปแบบเหล่านี้ไม่บรรจุ `IImageTransformOperationCollection` ที่แก้ไขได้; รูปแบบเรสเตอร์ทำให้ผลลัพธ์แบนเป็นพิกเซล และการส่งออกเอกสาร/เวกเตอร์จะเก็บตัวแทนการเรนเดอร์ของตนเอง
- เอฟเฟกต์ไม่ได้ทำให้ภาพที่เชื่อมโยงเป็นไฟล์ที่อิสระ การเรนเดอร์ภาพที่เชื่อมโยงยังต้องพึ่งพาแหล่งที่เชื่อมโยงอยู่อย่างต่อเนื่องเมื่อพรีเซ็นเทชันถูกโหลด

ผู้บริโภคพรีเซ็นเทชันที่แตกต่างกันอาจเรนเดอร์กรณีขอบต่างกันโดยเฉพาะเมื่อรวมการทำงาน alpha หรือการควอนไทซ์สีหลายขั้นตอน สำหรับผลลัพธ์ที่สำคัญ ควรทดสอบทั้งการเดินทางรอบที่แก้ไขได้และรูปแบบการส่งออกสุดท้ายด้วย Aspose.Slides เวอร์ชันเดียวกับที่ใช้ในผลิตภัณฑ์

## **FAQ**

**การทำงานแปลงภาพเปลี่ยนแปลงข้อมูลภาพที่ฝังอยู่หรือไม่?**

ไม่มี. การทำงานเป็นของ `ISlidesPicture` ที่ใช้โดยการเติมรูปภาพ ไบต์ของ `IPPImage` พื้นฐานคงเดิมไม่เปลี่ยน

**สองกรอบภาพที่ใช้แหล่งภาพเดียวกันจะใช้เอฟเฟกต์ร่วมกันหรือไม่?**

ไม่มี. การใช้ `IPPImage` ซ้ำช่วยหลีกเลี่ยงข้อมูลภาพซ้ำกัน แต่แต่ละกรอบภาพโดยปกติมี `ISlidesPicture` และคอลเลกชันการแปลงของตนเอง

**สามารถรวมเอฟเฟกต์สี, เบลอและ alpha ได้หรือไม่?**

ได้. คอลเลกชันรับพวกมันในโซ่ที่เรียงลำดับ พิจารณาว่าแต่ละการทำงานส่งผลต่อผลลัพธ์ของการทำงานก่อนหน้าอย่างไร เพราะการแทนที่และการกำหนดเกณฑ์อาจลบรายละเอียดสีหรือ alpha ที่สร้างขึ้นก่อนหน้า

**ทำไมค่าที่มีผลจึงเป็นแบบอ่าน‑อย่างเดียว?**

ข้อมูลที่มีผลแสดงค่าที่คำนวนแล้วสำหรับการเรนเดอร์รวมถึงสีที่แก้ไขแล้ว ให้แก้ไขการทำงานที่เก็บในคอลเลกชันเมื่อมีสมาชิกรับการเขียน; หากไม่มีให้ลบการทำงานนั้นและเพิ่มการทำงานใหม่ด้วยพารามิเตอร์การสร้างใหม่

**ควรใช้รูปแบบใดเพื่อคงโซ่การแปลง?**

ใช้ PPTX แล้วตรวจสอบไฟล์โดยการเปิดใหม่ PPT แบบเก่าไม่สามารถแสดงโมเดลเอฟเฟกต์ DrawingML เต็มรูปแบบได้ และรูปแบบการส่งออกที่เรนเดอร์จะเก็บลักษณะการแสดงผลแทนการทำงานแปลงที่แก้ไขได้