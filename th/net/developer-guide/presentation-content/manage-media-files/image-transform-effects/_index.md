---
title: จัดการเอฟเฟ็กต์การแปลงภาพในการนำเสนอด้วย .NET
linktitle: เอฟเฟ็กต์การแปลงภาพ
type: docs
weight: 11
url: /th/net/image-transform-effects/
keywords:
- การแปลงภาพ
- เอฟเฟ็กต์รูปภาพ
- ความสว่าง
- คอนทราสต์
- ระดับสีเทา
- โทนคู่
- สีอ่อน
- HSL
- การแทนที่สี
- เบลอ
- ความโปร่งใส
- เอฟเฟ็กต์อัลฟ่า
- ห่วงโซ่เอฟเฟ็กต์
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้, สร้างห่วงโซ่, ตรวจสอบ, ลบ, และตรวจสอบความถูกต้องของเอฟเฟ็กต์การแปลงภาพสำหรับกรอบรูปภาพด้วย Aspose.Slides for .NET."
---
## **ภาพรวม**

Aspose.Slides แสดงการปรับภาพเป็นคอลเลกชันที่เรียงลำดับของการดำเนินการแปลงภาพ (image transform operations) สำหรับกรอบรูปภาพ ให้เริ่มต้นด้วย [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) ของกรอบและเข้าถึง [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/) คอลเลกชันที่ส่งคืนคือ [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) ซึ่งให้คุณเพิ่ม, ลำดับ, ตรวจสอบ, ลบ และล้างเอฟเฟ็กต์โดยไม่ต้องเขียนข้อมูลไบต์ของภาพต้นฉบับใหม่

บทความนี้แสดงกระบวนการทำงานเต็มรูปแบบสำหรับความสว่างและคอนทราสต์, การแปลงสี, ความเบลอ, ความโปร่งใส, การจัดลำดับเอฟเฟ็กต์, ค่าที่มีผล, การลบ, และการตรวจสอบความถูกต้องของการรอบรอบ PPTX

## **ทำความเข้าใจความเป็นเจ้าของเอฟเฟ็กต์และการใช้ซ้ำภาพ**

ทรัพยากรภาพและรูปภาพที่แสดงภาพนั้นเป็นออบเจ็กต์ที่แตกต่างกัน:

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) เก็บหรืออ้างอิงข้อมูลภาพต้นฉบับซึ่งเป็นของงานนำเสนอ
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) เป็นส่วนของการเติมรูปภาพและอ้างถึงทรัพยากรภาพในขณะที่เก็บคอลเลกชันการแปลงภาพ
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) คือรูปร่างบนสไลด์ที่เป็นเจ้าของการเติมรูปภาพ, เรขาคณิต, การครอป, และการจัดรูปแบบระดับกรอบอื่น ๆ

ดังนั้น การดำเนินการแปลงภาพจะไม่แก้ไขไบต์ใน [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) เมื่อ `IPPImage` เดียวกันถูกส่งผ่านไปยัง [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) มากกว่าหนึ่งครั้ง แต่ละกรอบรูปภาพใหม่จะรับ `ISlidesPicture` ของตนเองและคอลเลกชันการแปลงของตนเอง การทำให้กรอบหนึ่งเป็นระดับสีเทา (grayscale) จะไม่ทำให้กรอบอื่นเป็นระดับสีเทา แม้ว่าโดยทั้งหมดจะใช้ทรัพยากรภาพที่ฝังอยู่เดียวกัน

โมเดล `ISlidesPicture.ImageTransform` เดียวกันนี้ยังใช้โดยการเติมรูปภาพอื่น ๆ เช่น รูปร่างหรือพื้นหลังสไลด์ ตัวอย่างด้านล่างมุ่งเน้นที่กรอบรูปภาพ

## **ใช้ช่วงพารามิเตอร์และหน่วยที่ถูกต้อง**

วิธีการที่สาธิตใช้ช่วงเชิงความหมายและหน่วยต่อไปนี้ เก็บค่าภายในช่วงเหล่านี้แม้ว่าเวอร์ชันไลบรารีบางเวอร์ชันอาจไม่ปฏิเสธค่าที่อยู่นอกช่วงโดยทันที; รูปแบบการนำเสนอเป้าหมายอาจทำให้ค่าปกติ, ลบ, หรือปฏิเสธข้อมูลที่ไม่ถูกต้องระหว่างการบันทึกหรือเมื่อ PowerPoint เปิดไฟล์

| Operation | Parameters | ช่วงและหน่วยที่ถูกต้อง |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` ถึง `100`, เปอร์เซ็นต์; `0` ไม่เปลี่ยนค่า |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | ไม่มีพารามิเตอร์เชิงตัวเลข. Alpha ไม่เปลี่ยน |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | สองสีสำหรับพิกเซลมืดและสว่าง. ช่องสี RGB และ alpha ใน `System.Drawing.Color` ใช้ค่า `0` ถึง `255` |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue เป็น `0` รวมถึง `360` ไม่รวม, หน่วยเป็นองศา; amount เป็น `-100` ถึง `100`, เปอร์เซ็นต์ |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue เป็น `0` รวมถึง `360` ไม่รวม, หน่วยเป็นองศา; saturation และ luminance เป็น `-100` ถึง `100`, เปอร์เซ็นต์ |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | สีที่แทนที่ใช้ค่าชาแนลจาก `0` ถึง `255`. ค่า alpha ที่มีอยู่ไม่เปลี่ยน |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius ต้องเป็นค่าไม่ลบและหน่วยเป็น points; `grow` เป็น Boolean ที่ควบคุมว่าภาพเบลออาจขยายออกนอกขอบเดิมหรือไม่ |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | เปอร์เซ็นต์ไม่ลบ. ใช้ `0` ถึง `100` สำหรับการปรับความทึบตามปกติ: `0` หมายถึงโปร่งใสเต็ม, `100` คงค่า alpha เดิม |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` ถึง `100`, เปอร์เซ็นต์ความทึบ |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` ถึง `100`, เปอร์เซ็นต์ค่าเกณฑ์ alpha. ค่าต่ำกว่ากลายเป็นโปร่งใส; ค่าที่เท่ากับหรือสูงกว่าจะเป็นทึบ |

สำหรับการมอดูเลต alpha แบบคงที่ ความโปร่งใสและความทึบเป็นค่าตรงกันข้าม ตัวอย่างเช่น ความโปร่งใส 35% มีค่า alpha modulation 65%

## **ปรับความสว่างและคอนทราสต์**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) คืนค่าอ็อบเจ็กต์ [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) การตั้งค่าสเกลาร์จะถูกส่งเมื่อสร้างอ็อบเจ็กต์นั้น [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) คืนค่าอ่านอย่างเดียวที่คำนวณแล้วซึ่งสามารถตรวจสอบหรือบันทึกได้

ตัวอย่างต่อไปนี้เพิ่มความสว่าง 15% และคอนทราสต์ 20% แล้วแสดงพรีวิวโดยไม่แก้ไขภาพที่ฝังไว้:

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

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) เป็นส่วนขยายเอฟเฟ็กต์ภาพของ Office 2010 และมีพกพาน้อยกว่ามาตรฐาน DrawingML luminance หากต้องการให้ความสว่างและคอนทราสต์ยังคงแก้ไขได้หลังจากรอบรอบ PPTX ให้ใช้ [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) และตรวจสอบผลลัพธ์หลังจากเปิดไฟล์ใหม่ ส่วนของข้อจำกัดรูปแบบอธิบายความแตกต่างนี้อย่างละเอียด

## **ปรับการแปลงสี**

เอฟเฟ็กต์สีสามารถนำไปใช้แยกกันกับกรอบรูปภาพต่าง ๆ ที่ใช้ทรัพยากรภาพเดียวกัน ตัวอย่างต่อไปนี้สร้างห้ากรอบและใช้ grayscale, duotone, tint, การปรับ HSL, และการแทนที่สี

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) มีพารามิเตอร์สีสองตัวที่แก้ไขได้อย่างอิสระ: `Color1` จัดการพิกเซลมืด, `Color2` จัดการพิกเซลสว่าง ซึ่งเป็นตัวอย่างที่ดีของเอฟเฟ็กต์ที่การตั้งค่ามีความซับซ้อนกว่าค่าทางสเกลาร์เดียว

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) แทนที่สีของทุกพิกเซลด้วยสีคงที่หนึ่งสีโดยคงค่า alpha ไว้ แตกต่างจาก [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) ที่แมปสีต้นทางหนึ่งไปยังสีเป้าหมายและเปิดเผยรูปแบบสีทั้งต้นและเป้าหมาย

### **ใช้เกณฑ์ Luminance**

เกณฑ์ luminance สามารถทำให้รอยบางบนหน้าสแกนมองเห็นได้ง่ายขึ้นจากพื้นหลัง [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) คงระดับสีเทากลาง [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) แปลง luminance เป็นสีดำหรือสีขาว, ในขณะที่ [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) ใช้เกณฑ์ต่อ opacity

เกณฑ์ luminance มีค่า 0% ถึง 100% รวม ทั้งพิกเซลที่ต่ำกว่าจะกลายเป็นสีดำ, พิกเซลที่เท่ากับหรือสูงกว่าจะกลายเป็นสีขาว การเพิ่มเกณฑ์ทำให้เงาต่าง ๆ กลายเป็นสีดำมากขึ้นเนื่องจากพิกเซลมากขึ้นอยู่ต่ำกว่าขอบเกณฑ์

ดาวน์โหลด [grayscale-swatches.png](grayscale-swatches.png) ไปยังไดเรกทอรีทำงาน แต่ละป้ายกำกับบอกระดับสีเทาต้นฉบับบนสเกล 0 ถึง 255 ตัวอย่างวางต้นฉบับข้างสำเนาสองฉบับและบันทึกค่าเกณฑ์ของแต่ละสำเนาในงานนำเสนอ

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

เปิดงานนำเสนอผลลัพธ์ใน PowerPoint เพื่อเปรียบเทียบสามกรอบ ตัวอย่างที่มีป้ายกำกับ 96 มี luminance ประมาณ 38% (96 จาก 255) จะแปลงเป็นสีขาวที่เกณฑ์ 20% และสีดำที่เกณฑ์ 60%

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **เพิ่ม Blur, Transparency และ Alpha Effects**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) มีผลต่อทุกช่องสีรวมถึง alpha ตั้งค่า `grow` เป็น `true` เมื่อขอบเบลออาจขยายออกนอกขอบภาพเดิม

สำหรับความโปร่งใสสม่ำเสมอให้ใช้ [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) ซึ่งคูณค่า alpha ที่มีอยู่ทุกค่า ทำให้พิกเซลที่โปร่งใสบางส่วนยังคงแตกต่างในสัดส่วน [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) แทนที่จะคูณจะกำหนดค่า alpha เดียวให้กับทุกพิกเซล [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) แปลง alpha เป็นสองระดับตามเกณฑ์

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

ออปเจกต์ alpha ที่ไม่มีพารามิเตอร์อื่น ๆ ได้แก่ [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) ที่ทำให้ทุกค่า alpha ที่ไม่เป็นศูนย์กลายเป็นทึบเต็ม, [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) ที่ทำให้ทุกค่า alpha ที่ต่ำกว่า 100% กลายเป็นโปร่งใสเต็ม, และ [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) ที่เปลี่ยนค่า alpha เป็น `100% - alpha`

## **สร้างเชนเอฟเฟ็กต์ที่เรียงลำดับ**

ทุกเมธอด `Add...Effect` จะผนวกอ็อบเจ็กต์ใหม่ไปที่ท้ายคอลเลกชัน ตัวเรนเดอร์ใช้คอลเลกชันเป็นสายการผลิตที่เรียงลำดับ: เอาต์พุตของอ็อบเจ็กต์ 0 คืออินพุตของอ็อบเจ็กต์ 1, และต่อไป ดังนั้นการใช้เอฟเฟ็กต์เดียวกันในลำดับต่าง ๆ สามารถให้ผลลัพธ์ภาพที่ต่างกัน

เช่น การทำ grayscale แล้วตามด้วย tint จะลบข้อมูลสีก่อนแล้วเติมสีใหม่ให้กับผลลัพธ์ luminance ส่วนการทำ tint แล้วตามด้วย grayscale จะลบ tint อีกครั้ง ในลักษณะเดียวกัน การแทนที่ alpha สามารถเขียนทับค่า alpha ที่คำนวณโดยอ็อบเจ็กต์ก่อนหน้าได้, ส่วนการมอดูเลต alpha จะคงความต่างสัมพัทธ์เดิม

ตัวอย่างต่อไปนี้สร้างเชนสี่อ็อบเจ็กต์, บันทึกเป็น PPTX, เปิดไฟล์อีกครั้ง, ตรวจสอบทั้งประเภทอ็อบเจ็กต์และลำดับ, แล้วเรนเดอร์ผลลัพธ์ที่เปิดใหม่:

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

คอลเลกชันไม่ได้บังคับให้สร้างเมทริกซ์ความเข้ากันได้ที่แยกเอฟเฟ็กต์สี, alpha, และ blur ออกจากกัน พวกมันสามารถรวมกันได้ แต่การผสมอาจไม่ค่อยมีประโยชน์ การแทนที่สีคงที่จะลบความแปรผัน RGB ที่เกิดจากเอฟเฟ็กต์สีก่อนหน้า; การทำ grayscale หลังจาก duotone จะลบสีสองสีที่เลือก; และการทำ ceiling, floor, replacement หรือ bi‑level ของ alpha สามารถลบรายละเอียด alpha ที่สร้างไว้ก่อนหน้า สร้างเชนตามลำดับการประมวลผลพิกเซลที่ต้องการ แทนที่จะมองว่าเป็นธงฟอร์แมตที่ไม่เรียงลำดับ

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*ในภาพอธิบาย Aspose.Slides for .NET 26.11 นี้ การทำ tint 220° ที่ 25% หลังจาก grayscale จะทำให้ภาพ grayscale ไม่เปลี่ยนแปลง การทำ tint ก่อน grayscale จะให้โทนสีที่ต่างกัน*
<!-- visual-explanation:image-transform-effects:end -->

## **ตรวจสอบค่า Editable และ Effective**

อ็อบเจ็กต์ที่แก้ไขได้คืออ็อบเจ็กต์ที่จัดเก็บใน `ISlidesPicture.ImageTransform` ขึ้นอยู่กับเอฟเฟ็กต์ อาจเปิดเผยสมาชิกที่เขียนได้โดยตรง ตัวอย่างเช่น [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) เปิดเผย `Radius` และ `Grow` ที่เขียนได้, [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) เปิดเผย `Amount`, และ [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) เปิดเผย `Threshold` เอฟเฟ็กต์สีเช่น [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) เปิดเผยอ็อบเจ็กต์ [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/) ที่แก้ไขได้

อินเทอร์เฟซอ็อบเจ็กต์บางอย่าง เช่น [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/), และ [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/) ไม่เปิดเผยสเกลาร์การสร้างเป็นคุณสมบัติที่เขียนได้ เพื่อเปลี่ยนการตั้งค่าเหล่านั้น ให้ลบเอฟเฟ็กต์แล้วเพิ่มอ็อบเจ็กต์ใหม่ในตำแหน่งที่ต้องการ

ข้อมูลที่มีผลที่คืนจาก `GetEffective()` ถูกคำนวณและเป็นอ่าน‑อย่างเดียว ใช้ตรวจสอบสีที่ขึ้นกับธีมและอ่านค่าที่ทำให้เรนเดอร์ใช้ได้ แต่ไม่ได้เป็นพื้นผิวการแก้ไขเพิ่มเติม ตัวอย่างต่อไปนี้ลำดับเชนและตรวจสอบค่า effective ที่ API ให้มา:

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

เอฟเฟ็กต์ที่ไม่มีพารามิเตอร์เช่น grayscale, alpha ceiling, และ alpha inverse ยังคงมีอ็อบเจ็กต์ effective‑data แต่ไม่มีการตั้งค่าสเกลาร์ให้พิมพ์ ผลลัพธ์ของการมีอยู่และตำแหน่งในคอลเลกชันเป็นข้อมูลสำคัญ

## **ลบหรือเคลียร์การแปลงภาพ**

ใช้ [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) เพื่อลบอ็อบเจ็กต์หนึ่งตามดัชนี เนื่องจากดัชนีจะเลื่อนตำแหน่งหลังการลบ, ควรค้นหาเป้าหมายก่อนแล้วลบหลังจากลำดับ ตรวจสอบ `Clear()` เพื่อเคลียร์เชนทั้งหมด

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

การลบหรือเคลียร์การแปลงส่งผลเฉพาะต่อการจัดรูปแบบรูปภาพเท่านั้น ไม่ได้ลบ, บีบอัดใหม่, หรือแก้ไขทรัพยากร [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) ที่ใช้ซ้ำ

## **พิจารณารูปแบบงานนำเสนอและเป้าหมายการส่งออก**

การแปลงภาพมีต้นกำเนิดจาก DrawingML ดังนั้น PPTX เป็นรูปแบบที่แนะนำสำหรับการแก้ไขเชนเอฟเฟ็กต์ แม้กับ PPTX ทุกอ็อบเจ็กต์อาจไม่มีความพกพาเท่าเทียมกัน:

- เอฟเฟ็กต์ DrawingML มาตรฐานเช่น luminance, grayscale, duotone, tint, HSL, blur, และเอฟเฟ็กต์ alpha ปกติมีโอกาสรอดที่สุดจากรอบรอบ PPTX ควรเปิดไฟล์ที่สร้างใหม่และตรวจสอบคอลเลกชันเมื่อการเก็บรักษาเป็นข้อกำหนด
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) เป็นส่วนขยาย Office 2010 ไม่ใช่เอฟเฟ็กต์ luminance ของ DrawingML มันอาจใช้สำหรับเรนเดอร์ในหน่วยความจำ, แต่ไม่รับประกันว่าจะคงเป็น [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) ที่แก้ไขได้หลังการบันทึกและเปิด PPTX อีกครั้ง แนะนำให้ใช้ [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) สำหรับการปรับความสว่างและคอนทราสต์ที่คงที่
- รูปแบบ PPT แบบไบนารีเกิดมานานก่อนโมเดลเอฟเฟ็กต์ DrawingML สมบูรณ์ การบันทึกเป็น PPT อาจละทิ้งอ็อบเจ็กต์ที่ไม่สนับสนุน, ลดเชนลงเป็นส่วนที่สนับสนุน, หรือประมาณภาพ ไม่ควรใช้ PPT เพื่อตรวจสอบความถูกต้องของเชนที่แก้ไขได้ซับซ้อน
- การเรนเดอร์เป็น PNG, JPEG, TIFF, PDF, SVG, HTML หรือรูปแบบภาพอื่น ๆ จะใช้เชนที่สนับสนุนเพื่อสร้างลักษณะภาพผลลัพธ์ รูปแบบเหล่านั้นไม่มี `IImageTransformOperationCollection` ที่แก้ไขได้; รูปแบบราสเตอร์จะทำให้ผลลัพธ์แบนเป็นพิกเซล, ส่วนการส่งออกเอกสาร/เวกเตอร์จะเก็บการแสดงผลของตนเอง
- เอฟเฟ็กต์ไม่ทำให้ภาพที่เชื่อมโยงกลายเป็นไฟล์เดียวกัน การเรนเดอร์ภาพที่เชื่อมโยงยังคงต้องอาศัยทรัพยากรที่เชื่อมโยงอยู่เมื่อเปิดงานนำเสนอ

ผู้ใช้งานนำเสนอที่ต่างกันอาจเรนเดอร์กรณีที่ขอบเขตต่างกัน โดยเฉพาะเมื่อรวมเอฟเฟ็กต์ alpha หรือการปรับสีหลายขั้นตอนไว้ด้วยกัน สำหรับผลลัพธ์ที่สำคัญ ควรทดสอบทั้งรอบรอบที่แก้ไขได้และรูปแบบส่งออกสุดท้ายด้วย Aspose.Slides เวอร์ชันเดียวกันที่ใช้ในผลิตภัณฑ์

## **คำถามที่พบบ่อย**

**เอฟเฟ็กต์การแปลงภาพทำให้ข้อมูลภาพที่ฝังไว้เปลี่ยนแปลงหรือไม่?**

ไม่ การดำเนินการเป็นของ `ISlidesPicture` ที่ใช้โดยการเติมรูปภาพ ไบต์ของ `IPPImage` พื้นฐานคงไม่ถูกเปลี่ยน

**กรอบรูปภาพสองกรอบที่ใช้ภาพเดียวกันจะแชร์เอฟเฟ็กต์กันหรือไม่?**

ไม่ การใช้ `IPPImage` ลดข้อมูลภาพซ้ำ แต่ละกรอบรูปภาพโดยปกติมี `ISlidesPicture` และคอลเลกชันการแปลงภาพของตนเองแยกกัน

**สามารถรวมเอฟเฟ็กต์สี, blur, และ alpha ได้หรือไม่?**

ได้ คอลเลกชันรับเอฟเฟ็กต์เหล่านี้ในเชนเดียวที่เรียงลำดับ ควรพิจารณาผลของแต่ละการดำเนินการต่อผลลัพธ์ของการดำเนินการก่อนหน้า เนื่องจากการแทนที่และการกำหนดเกณฑ์อาจลบรายละเอียดสีหรือ alpha ที่สร้างไว้ก่อนหน้า

**ทำไมค่าที่มีผลจึงเป็นอ่าน‑อย่างเดียว?**

ข้อมูลที่มีผลเป็นค่าที่คำนวณแล้วใช้สำหรับการเรนเดอร์รวมถึงสีที่ได้รับการแก้ไข ควรแก้ไขอ็อบเจ็กต์ในคอลเลกชันที่มีสมาชิกเขียนได้; หากไม่มีให้ลบแล้วเพิ่มอ็อบเจ็กต์ใหม่ด้วยพารามิเตอร์การสร้างที่ต้องการ

**ควรใช้รูปแบบใดเพื่อเก็บรักษาเชนการแปลง?**

ใช้ PPTX แล้วตรวจสอบไฟล์โดยการเปิดใหม่ PPT รุ่นเก่าไม่สามารถแสดงโมเดลเอฟเฟ็กต์ DrawingML เต็มรูปแบบได้, และรูปแบบส่งออกที่เรนเดอร์จะเก็บลักษณะภาพเท่านั้น ไม่ได้เก็บการแปลงที่แก้ไขได้