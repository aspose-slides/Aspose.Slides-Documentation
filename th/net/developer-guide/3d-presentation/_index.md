---
title: สร้างเอฟเฟกต์ 3 มิติในงานนำเสนอโดยใช้ .NET
linktitle: งานนำเสนอ 3 มิติ
type: docs
weight: 232
url: /th/net/3d-presentation/
keywords:
- PowerPoint 3 มิติ
- งานนำเสนอ 3 มิติ
- การหมุน 3 มิติ
- ความลึก 3 มิติ
- การดึงลึก 3 มิติ
- ไล่สี 3 มิติ
- ข้อความ 3 มิติ
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3 มิติสำหรับรูปร่างและข้อความใน PowerPoint ด้วย .NET ผ่าน Aspose.Slides กำหนดค่ากล้อง, แสง, วัสดุ, การดึงลึก, การเติม, และข้อความ 3 มิติ"
---
## **ภาพรวม**

Aspose.Slides for .NET สามารถสร้าง แก้ไข รักษา และเรนเดอร์การจัดรูปแบบ 3 มิติในสไตล์ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน การดึงลึก (extrusion) bevels การจัดแสง material การไล่สีหรือการเติมรูปภาพ และข้อความ 3 มิติ

{{% alert color="info" %}}
This article is about 3D formatting effects on PowerPoint shapes and text. It is not about inserting or editing standalone 3D model files. When you export a slide to an image, PDF, or HTML, Aspose.Slides renders those 3D effects into the exported 2D output.
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้คุณสมบัติ [IShape.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/properties/threedformat) เพื่อใช้การจัดรูปแบบ 3 มิติบนรูปร่าง คุณสมบัตินี้เปิดเผย [IThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat) ซึ่งควบคุมฉาก 3 มิติสำหรับรูปร่างนั้น

สำหรับข้อความ ใช้คุณสมบัติ [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/properties/threedformat) นี้จะใช้การจัดรูปแบบ 3 มิติบนเฟรมข้อความแทนที่ส่วนเนื้อหาของรูปร่าง

คุณสมบัติที่สำคัญที่สุดมีดังนี้:

| Property | สิ่งที่ควบคุม | เมื่อควรใช้ |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/camera) | จุดมองเห็น, ประเภทกล้องตั้งล่วงหน้า, การหมุน, การซูม, และมุมมองเชิงลึก (perspective) | หมุนวัตถุในพื้นที่ 3 มิติหรือให้ตรงกับการตั้งค่าการหมุน 3 มิติของ PowerPoint |
| [LightRig](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/lightrig) | การตั้งค่าแสง, ทิศทาง, และการหมุนแสง | เปลี่ยนวิธีที่แสงสว่างและเงาปรากฏบนพื้นผิว 3 มิติ |
| [Material](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/material) | วัสดุพื้นผิว เช่น แบน, แม็ต, พลาสติก หรือ โลหะ | ทำให้รูปทรงเดียวกันดูแบนขึ้น, นุ่มขึ้น, มีเงามากขึ้น, หรือเป็นโลหะ |
| [ExtrusionHeight](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/extrusionheight) | ระยะที่รูปร่างยื่นออกมาหลังจากหน้าตัดหน้า | เปลี่ยนรูปร่างแบนให้กลายเป็นวัตถุ 3 มิติที่มีความหนาเห็นได้ชัด |
| [ExtrusionColor](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/extrusioncolor) | สีของด้านที่ยื่นออก | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับการเติมหน้าตัดหน้า |
| [Depth](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/depth) | ความลึก 3 มิติเพิ่มเติมที่ PowerPoint ใช้ในการจัดรูปแบบ | ปรับความลึกอย่างละเอียดสำหรับรูปร่างหรือข้อความ โดยเฉพาะเมื่อใช้ร่วมกับการตั้งค่า bevel และ material |
| [BevelTop](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/bevelbottom) | ขอบที่ยกขึ้นหรือโค้งบนหน้าตัดหน้าและหลัง | เพิ่มขอบที่นุ่มหรือขึ้นรูปแทนหน้าตัดแบนคม |
| [ContourColor](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/contourwidth) | เส้นขอบรอบวัตถุ 3 มิติ | เน้นเส้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปร่าง 3 มิติ**

รูปร่างโดยทั่วไปต้องการการตั้งค่าสี่ประเภทก่อนที่จะดูเหมือน 3 มิติอย่างน่าเชื่อถือ:
- การตั้งค่ากล้อง เนื่องจากมุมมองหน้าตาเริ่มต้นอาจซ่อนการดึงลึก
- การตั้งค่าแสง เนื่องจากแสงทำให้พื้นผิวและด้านด้านข้างอ่านได้
- การตั้งค่าวัสดุ เนื่องจากพื้นผิวมีผลต่อการแสดงผลของแสง
- การตั้งค่าการดึงลึกหรือความลึก เนื่องจากรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม เพิ่มข้อความลงบนหน้าตัดหน้า ใช้การจัดรูปแบบ 3 มิติ บันทึกงานนำเสนอเป็น PPTX และเรนเดอร์สไลด์เป็นภาพ PNG

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

ภาพสไลด์ที่เรนเดอร์แสดงสี่เหลี่ยมเป็นบล็อก 3 มิติที่หนา:

![สี่เหลี่ยม 3 มิติสีฟ้าเรนเดอร์พร้อมข้อความ 3 มิติสีขาวบนหน้าตัดหน้า](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3 มิติถูกกำหนดจากแผง 3‑D Rotation ค่า X, Y, และ Z correspond กับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง

![แผง PowerPoint 3‑D Rotation พร้อมค่าการหมุน X, Y, และ Z ที่ไฮไลต์](img_02_01.png)

ใน Aspose.Slides ตั้งค่าประเภทกล้องและการหมุนผ่าน [IThreeDFormat.Camera](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/camera):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองวัตถุ มันไม่เปลี่ยนรูปทรง 2 มิติบนสไลด์ แต่เปลี่ยนจุดมองเห็น 3 มิติที่ PowerPoint และ Aspose.Slides ใช้เมื่อเรนเดอร์

## **เพิ่มการดึงลึกและความลึก**

การดึงลึกทำให้รูปร่างดูหนาโดยการยืดออกไปด้านหลังของหน้าตัดหน้า ใน PowerPoint การควบคุมความลึกตั้งค่าความหนาแสดงผลนี้และการควบคุมสีตั้งค่าสีของด้านด้านข้าง

![การควบคุมความลึกของ PowerPoint ที่เชื่อมโยงกับคุณสมบัติ extrusion color และ extrusion height](img_02_02.png)

ตั้งค่า [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/extrusionheight) เพื่อกำหนดความหนาและ [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/extrusioncolor) เพื่อกำหนดสีด้าน:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

ใช้ [IThreeDFormat.Depth](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/depth) เมื่อต้องการทำงานกับค่าความลึกของ PowerPoint โดยตรงหรือรวมความลึกกับ bevel, material, และเอฟเฟกต์ข้อความ ในหลายกรณีของรูปร่าง `ExtrusionHeight` จะชัดเจนกว่าเพราะบ่งบอกการดึงลึกที่มองเห็นได้โดยตรง

## **ใช้การไล่สีหรือการเติมรูปภาพกับเอฟเฟกต์ 3 มิติ**

การจัดรูปแบบ 3 มิติเป็นอิสระจากการเติมรูปของรูปร่าง คุณสามารถใช้สีทึบ, การไล่สี, แบบลาย, หรือการเติมรูปภาพบนหน้าตัดหน้าได้พร้อมใช้การตั้งค่ากล้อง, แสง, วัสดุ, และการดึงลึกเดียวกัน

ตัวอย่างนี้ใช้การไล่สีบนรูปร่างและสีการดึงลึกที่เข้มกว่าบนด้านข้าง:

```csharp
using System.Drawing;
using Aspose.Slides;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

ผลลัพธ์ที่เรนเดอร์เก็บการไล่สีบนหน้าตัดหน้าและเรนเดอร์การดึงลึกแยกกัน:

![สี่เหลี่ยม 3 มิติที่มีการไล่สีจากสีฟ้าไปสีส้มและการดึงลึกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมรูปภาพแทน ให้เพิ่มภาพลงในงานนำเสนอและกำหนดให้เป็นการเติมรูปของรูปร่าง:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

รูปภาพจะถูกเรนเดอร์บนหน้าตัดหน้า ส่วนการดึงลึกจะเรนเดอร์เป็นพื้นผิวด้านข้าง 3 มิติ:

![สี่เหลี่ยม 3 มิติที่มีการเติมรูปภาพบนหน้าตัดหน้าและการดึงลึกสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3 มิติกับข้อความ**

การจัดรูปแบบ 3 มิติของรูปร่างมีผลต่อเนื้อหารูปร่าง การจัดรูปแบบ 3 มิติของข้อความมีผลต่อเฟรมข้อความ ซึ่งเป็นประโยชน์สำหรับเอฟเฟกต์ลักษณะ WordArt ที่ตัวอักษรต้องการการดึงลึก, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยการเติมลาย, ใช้การแปลง WordArt, แล้วกำหนดค่าการตั้งค่า 3 มิติบน [ITextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat):

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

ข้อความถูกเรนเดอร์เป็นอักษร 3 มิติที่โค้ง สะท้อนลายสีส้มและการดึงลึกสีเข้ม:

![ข้อความ 3 มิติที่เรนเดอร์พร้อมการแปลง WordArt โค้ง, การเติมลายสีส้ม, และการดึงลึกสีเข้ม](img_02_05.png)

## **การส่งออกและพฤติกรรมการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3 มิติเมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบแบบคงที่ 3D scene จะถูกแปลงเป็นภาพหรือวาดลงในผลลัพธ์เป็น 2D ซึ่งเกิดขึ้นเมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/net/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/net/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/net/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/net/convert-powerpoint-to-video/)

ควรจำจุดเหล่านี้:
- ภาพและ PDF ที่ส่งออกไม่เป็นเชิงโต้ตอบ วัตถุไม่สามารถหมุนโดยผู้ชมหลังการส่งออก
- รูปลักษณ์สุดท้ายขึ้นอยู่กับการผสมผสานของกล้อง, ระบบแสง, วัสดุ, การดึงลึก, การเติม, และการปรับขนาดสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม ให้อ่าน [effective shape properties](/slides/th/net/shape-effective-properties/)
- รูปแบบเอาต์พุตบางอย่างไม่สามารถเก็บการจัดรูปแบบ 3 มิติของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้นผลลัพธ์ที่มองเห็นจะถูกเรนเดอร์แทนที่จะถูกเก็บเป็นการตั้งค่า 3 มิติที่แก้ไขได้

## **FAQ**

### Aspose.Slides สามารถสร้างงานนำเสนอ 3 มิติแบบโต้ตอบได้หรือไม่?

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปร่างและข้อความ ไม่ทำให้ภาพ, PDF หรือหน้า HTML ที่ส่งออกเป็นฉาก 3 มิติที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3 มิติยังคงแก้ไขได้ใน PowerPoint หากรูปแบบนั้นรองรับ

### ความแตกต่างระหว่างโมเดล 3 มิติและเอฟเฟกต์ 3 มิติคืออะไร?

โมเดล 3 มิติคือวัตถุ 3 มิติแยกที่แทรกลงในงานนำเสนอ ส่วนเอฟเฟกต์ 3 มิติคือการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความทั่วไปของ PowerPoint เช่น การหมุน, การดึงลึก, bevel, แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ

### ต้องตั้งค่าอะไรบ้างเพื่อให้เห็นรูปร่าง 3 มิติ?

อย่างน้อยต้องตั้งค่าการหมุนกล้องและอย่างใดอย่างหนึ่งระหว่างการดึงลึกหรือความลึก โดยปกติยังควรตั้งค่าระบบแสงและวัสดุเพื่อให้พื้นผิวที่เรนเดอร์มีไฮไลท์และเงาที่ชัดเจน

### สามารถใช้เอฟเฟกต์ 3 มิติกับรูปร่างและข้อความได้หรือไม่?

ได้ ใช้ [IShape.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/properties/threedformat) สำหรับเนื้อหารูปร่างและ [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/properties/threedformat) สำหรับข้อความ

### เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?

ใช่ Aspose.Slides เรนเดอร์เอฟเฟกต์ 3 มิติเมื่อสร้างภาพสไลด์, เอาต์พุต PDF, HTML และเฟรมที่ใช้สำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์ ไม่ใช่วัตถุ 3 มิติที่แก้ไขได้

### สามารถอ่านค่าการจัดรูปแบบ 3 มิติสุดท้ายหลังจากการสืบทอดและธีมได้หรือไม่?

ได้ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายไว้ใน [Shape Effective Properties](/slides/th/net/shape-effective-properties/) เพื่ออ่านค่ากล้อง, ระบบแสง, bevel และค่าการจัดรูปแบบ 3 มิติที่เกี่ยวข้องสุดท้าย