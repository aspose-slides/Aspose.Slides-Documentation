---
title: สร้างเอฟเฟกต์ 3D ในการนำเสนอด้วย .NET
linktitle: การนำเสนอ 3D
type: docs
weight: 232
url: /th/net/3d-presentation/
keywords:
- PowerPoint 3 มิติ
- การนำเสนอ 3 มิติ
- การหมุน 3 มิติ
- ความลึก 3 มิติ
- การดึงออก 3 มิติ
- ไล่ระดับสี 3 มิติ
- ข้อความ 3 มิติ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3 มิติสำหรับรูปทรงและข้อความของ PowerPoint ใน .NET ด้วย Aspose.Slides ตั้งค่ากล้อง, แสง, วัสดุ, การดึงออก, การเติม, และข้อความ 3 มิติ."
---
## **ภาพรวม**

Aspose.Slides for .NET สามารถสร้าง, แก้ไข, คงไว้และแสดงผลการจัดรูปแบบ 3 มิติแบบ PowerPoint สำหรับรูปทรงและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ เช่น การหมุน, การดึงออก, การตัดขอบ, แสงสว่าง, วัสดุ, การไล่ระดับสีหรือการเติมภาพ, และข้อความ 3 มิติ.

{{% alert color="info" title="Note" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3 มิติบนรูปทรงและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3 มิติแบบสแตนด์อโลน เมื่อคุณส่งออกสไลด์เป็นภาพ, PDF หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3 มิติเหล่านั้นลงในผลลัพธ์ 2 มิติที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3 มิติ**

ใช้คุณสมบัติ [IShape.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/properties/threedformat) เพื่อนำการจัดรูปแบบ 3 มิติไปใช้กับรูปทรง คุณสมบัตินี้เปิดเผย [IThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat) ซึ่งควบคุมฉาก 3 มิติสำหรับรูปทรงนั้น

สำหรับข้อความ, ใช้คุณสมบัติ [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/properties/threedformat) ซึ่งนำการจัดรูปแบบ 3 มิติไปใช้กับกรอบข้อความแทนร่างกายรูปทรง

คุณสมบัติที่สำคัญที่สุดคือ:

| Property | สิ่งที่ควบคุม | เมื่อใดที่ควรใช้ |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/camera) | มุมมอง, ประเภทกลุ่มตั้งต้น, การหมุน, การซูม, และมุมมองเชิงลึก. | หมุนวัตถุในพื้นที่ 3 มิติหรือจับคู่กับการตั้งค่าการหมุน 3 มิติของ PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/lightrig) | การตั้งค่าการส่องแสง, ทิศทาง, และการหมุนแสง. | เปลี่ยนวิธีที่ไฮไลท์และเงาปรากฏบนพื้นผิว 3 มิติ. |
| [Material](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/material) | วัสดุพื้นผิว เช่น แบน, มีระดับ, พลาสติก หรือโลหะ. | ทำให้รูปร่างเดียวกันดูแบนกว่า, นุ่มกว่า, มันวาว หรือเป็นโลหะ. |
| [ExtrusionHeight](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/extrusionheight) | ระยะที่รูปทรงยืดออกไปด้านหลังจากด้านหน้าของมัน. | เปลี่ยนรูปทรงแบนให้เป็นวัตถุ 3 มิติที่ดูหนา. |
| [ExtrusionColor](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/extrusioncolor) | สีของด้านที่ยืดออก. | ทำให้ความลึกมองเห็นได้หรือปรับสีด้านให้สอดคล้องกับการเติมหน้าฝาก. |
| [Depth](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/depth) | ความลึก 3 มิติเพิ่มเติมที่ PowerPoint ใช้ในการจัดรูปแบบ. | ปรับความลึกสำหรับรูปทรงหรือข้อความ โดยเฉพาะเมื่อใช้ร่วมกับการตั้งค่า bevel และวัสดุ. |
| [BevelTop](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/bevelbottom) | ขอบที่ยกขึ้นหรือโค้งมนบนด้านหน้าและด้านหลัง. | เพิ่มขอบที่อ่อนหรือหล่อขึ้นแทนที่จะเป็นด้านแบนขอบคม. |
| [ContourColor](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/contourwidth) | เส้นขอบรอบวัตถุ 3 มิติ. | เน้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์. |

## **สร้างรูปทรง 3 มิติ**

รูปทรงโดยปกติต้องการการตั้งค่า 4 ประเภทก่อนที่จะดูเหมือนเป็น 3 มิติอย่างสมจริง:

- การตั้งค่ากล้อง เนื่องจากมุมมองหน้าตั้งต้นอาจซ่อนการดึงออก.
- การตั้งค่าแสง เนื่องจากแสงทำให้ด้านและข้างสามารถมองเห็นได้.
- การตั้งค่าวัสดุ เนื่องจากพื้นผิวส่งผลต่อการเรนเดอร์แสง.
- การตั้งค่าการดึงออกหรือความลึก เนื่องจากรูปแบนต้องการความหนา.

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม, เพิ่มข้อความบนด้านหน้าของมัน, และนำการจัดรูปแบบ 3 มิติไปใช้ ค่าการหมุนของกล้องเป็นหน่วยองศาและความสูงการดึงออกเป็น 100 จุด ตัวอย่างนี้เรนเดอร์สไลด์เป็นภาพ PNG ขนาดสองเท่าของมิติเดิมและบันทึกการนำเสนอเป็น PPTX.

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

![สี่เหลี่ยม 3 มิติสีฟ้าระบายสีพร้อมข้อความ 3 มิติสีขาวบนด้านหน้า](img_01_01.png)

## **หมุนรูปทรงด้วยกล้อง**

ใน PowerPoint การหมุน 3 มิติตั้งค่าจากแผง 3-D Rotation ค่า X, Y, และ Z ที่หมุนสอดคล้องกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง.

![แผง 3-D Rotation ของ PowerPoint ที่ไฮไลท์ค่า X, Y, และ Z ที่หมุน](img_02_01.png)

ใน Aspose.Slides เข้าถึงกล้องผ่าน [IThreeDFormat.Camera](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/camera) ตัวอย่างนี้สร้างสี่เหลี่ยม, เลือกมุมมองหน้าแบบออโตกราฟิก, และตั้งค่าการหมุน X, Y, Z เป็น 20, 30, และ 40 องศาตามลำดับ มันกำหนดรูปทรงในหน่วยความจำโดยไม่บันทึกไฟล์:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองเห็นวัตถุ มันไม่ได้เปลี่ยนรูปทรง 2 มิติบนสไลด์ แต่เปลี่ยนมุมมอง 3 มิติที่ PowerPoint และ Aspose.Slides ใช้เมื่อเรนเดอร์.

## **เพิ่มการดึงออกและความลึก**

การดึงออกทำให้รูปทรงดูหนาด้วยการขยายต่อจากด้านหน้าถอยหลัง ใน PowerPoint การควบคุมความลึกตั้งค่าความหนาที่มองเห็นได้และการควบคุมสีตั้งค่าสีของด้านข้าง.

![การควบคุมความลึกของ PowerPoint ที่เชื่อมกับคุณสมบัติสีการดึงออกและความสูงการดึงออก](img_02_02.png)

ตั้งค่า [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/extrusionheight) สำหรับความหนาและ [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/extrusioncolor) สำหรับสีด้าน ตัวอย่างนี้ให้สี่เหลี่ยมการดึงออก 100 จุดพร้อมด้านสีม่วงและหมุนกล้องเพื่อเปิดเผยความหนา มันกำหนดรูปทรงในหน่วยความจำโดยไม่บันทึกไฟล์:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

คุณสมบัติ [IThreeDFormat.Depth](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/depth) กำหนดความลึกของรูปทรง 3 มิติ คุณสมบัติ [ExtrusionHeight](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/extrusionheight) ควบคุมความสูงของเอฟเฟกต์การดึงออก อย่างที่แสดงในตัวอย่างนี้.

## **ใช้การเติมไล่ระดับสีหรือรูปภาพกับเอฟเฟกต์ 3 มิติ**

การจัดรูปแบบ 3 มิติเป็นอิสระจากการเติมรูปทรง คุณสามารถใช้สีทึบ, ไล่ระดับสี, ลายหรือการเติมรูปภาพบนด้านหน้าและยังคงใช้การตั้งค่ากล้อง, แสง, วัสดุ, และการดึงออกเดียวกัน.

ตัวอย่างนี้ใช้ไล่ระดับสีจากน้ำเงินไปส้มบนด้านหน้าและสีส้มเข้มบนการดึงออก 150 จุด ไล่ระดับสีหยุดที่ตำแหน่ง 0 และ 100 หมายถึงจุดเริ่มและจุดสิ้นสุดของไล่ระดับค่า การหมุนกล้องเป็นองศา สไลด์เรนเดอร์เป็นภาพ PNG ขนาดสองเท่ของมิติเดิม:

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

![สี่เหลี่ยม 3 มิติที่เติมไล่ระดับสีจากน้ำเงินไปส้มและการดึงออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมรูปภาพแทน, ให้เพิ่มรูปภาพไปยังงานนำเสนอและกำหนดเป็นการเติมรูปทรง ตัวอย่างนี้ต้องการไฟล์ที่มีชื่อ "image.jpg" อยู่ในไดเรกทอรีทำงาน มันยืดรูปภาพเพื่อเติมสี่เหลี่ยม, ใช้การดึงออก 150 จุด, และตั้งค่าการหมุนกล้องเป็นองศา มันกำหนดรูปทรงในหน่วยความจำโดยไม่บันทึกหรือเรนเดอร์ไฟล์:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

![สี่เหลี่ยม 3 มิติที่เติมรูปภาพบนด้านหน้าและการดึงออกสีส้ม](img_02_04.png)

## **ใช้การจัดรูปแบบ 3 มิติกับข้อความ**

การจัดรูปแบบ 3 มิติของรูปทรงมีผลต่อร่างกายของรูปทรง การจัดรูปแบบ 3 มิติของข้อความมีผลต่อกรอบข้อความ สิ่งนี้มีประโยชน์สำหรับเอฟเฟกต์แบบ WordArt ที่ต้องการให้ตัวอักษรเองมีการดึงออก, วัสดุ, แสงสว่าง, และการตั้งค่ากล้อง.

ตัวอย่างต่อไปนี้สร้างข้อความที่มีลายกริดสีส้มและสีขาว, ใส่การโค้งยืดขึ้น, และตั้งค่าการจัดรูปแบบ 3 มิติผ่าน [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/properties/threedformat) ความสูงการดึงออกและความลึกเป็นหน่วยจุด, การหมุนแสงเป็นองศา, การเติมรูปทรงและขอบถูกซ่อนเพื่อให้เห็นเฉพาะข้อความ ตัวอย่างนี้เรนเดอร์เป็นภาพ PNG ขนาดสองเท่ของสไลด์และบันทึกการนำเสนอเป็น PPTX:

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

![ข้อความ 3 มิติที่แปลงเป็น WordArt โค้ง, เติมลายสีส้ม, และดึงออกสีเข้ม](img_02_05.png)

## **คงข้อความให้แบนบนรูปทรง 3 มิติ**

เพื่อคงข้อความให้อ่านง่ายในขณะที่รักษาการแสดงผล 3 มิติของรูปทรง, ตั้งค่า [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/keeptextflat/) ผ่าน [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/textframeformat/). เมื่อค่าเป็น `true` ข้อความจะอยู่นอกฉาก 3 มิติ เมื่อเป็น `false` ข้อความจะอยู่ในฉากและตามการหมุน 3 มิติของมัน.

การตั้งค่านี้ไม่ได้ลบการจัดรูปแบบ 3 มิติของรูปทรง: กล้อง, แสง, วัสดุ, และการดึงออกยังคงกำหนดผ่าน [IShape.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/threedformat/). นอกจากนี้ยังแตกต่างจากการหมุนทั่วไป [IShape.Rotation](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/rotation/) ที่หมุนรูปทรงในระนาบสไลด์, ขณะที่ [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/rotationangle/) ควบคุมการหมุนแบบกำหนดของข้อความภายในกล่องขอบเขต การคงข้อความให้อยู่นอกฉาก 3 มิติไม่ได้รีเซ็ตมุมเหล่านั้น.

ตัวอย่างต่อไปนี้เป็นตัวอย่างแบบครบถ้วนที่สร้างสี่เหลี่ยมสีน้ำเงินพร้อมข้อความและทำสำเนาเคียงข้างต้นแบบ ดั้งเดิม ทั้งสองรูปทรงมีการจัดรูปแบบ 3 มิติเดียวกัน; เพียงการตั้งค่าข้อความต่างกัน: `false` ทางซ้ายและ `true` ทางขวา มุมกล้องเป็นองศาและความสูงการดึงออกเป็น 40 จุด ตัวอย่างบันทึกการนำเสนอเป็น PPTX และเรนเดอร์สไลด์เปรียบเทียบเป็น PNG ขนาดสองเท่ของมิติเริ่มต้น.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

![สี่เหลี่ยม 3 มิติข้างกัน: KeepTextFlat เป็น false ด้านซ้ายและ true ด้านขวา](keep_text_flat.png)

## **การส่งออกและพฤติกรรมการเรนเดอร์**

Aspose.Slides คงการจัดรูปแบบ 3 มิติเมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบแบบคงที่, ฉาก 3 มิติจะถูกเรซิส หรือวาดลงในผลลัพธ์เป็น 2 มิติ นี้ใช้เมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/net/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/net/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/net/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/net/convert-powerpoint-to-video/).

- ภาพและ PDF ที่ส่งออกไม่เป็นแบบโต้ตอบ วัตถุไม่สามารถหมุนได้โดยผู้ชมหลังการส่งออก.
- ลักษณะสุดท้ายขึ้นอยู่กับการรวมกันของกล้อง, ชุดแสง, วัสดุ, การดึงออก, การเติม, และการปรับขนาดสไลด์.
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือพื้นฐานจากธีม, อ่าน [effective shape properties](/slides/th/net/shape-effective-properties/).
- บางรูปแบบผลลัพธ์ไม่สามารถเก็บการจัดรูปแบบ 3 มิติของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้น ผลลัพธ์ที่แสดงจะเป็นการเรนเดอร์แทนการเก็บเป็นการตั้งค่า 3 มิติที่แก้ไขได้.

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างการนำเสนอ 3 มิติที่โต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3 มิติของ PowerPoint สำหรับรูปทรงและข้อความ ไม่ทำให้ภาพ, PDF, หรือหน้า HTML ที่ส่งออกเป็นฉาก 3 มิติที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3 มิติยังคงแก้ไขได้ใน PowerPoint เมื่อรูปแบบรองรับ.

**โมเดล 3 มิติคือวัตถุ 3 มิติแยกที่แทรกเข้าในงานนำเสนอ หรือเอฟเฟกต์ 3 มิติเป็นการจัดรูปแบบที่นำไปใช้กับรูปทรงหรือข้อความ PowerPoint ปกติ เช่น การหมุน, การดึงออก, bevel, แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3 มิติ.**

**การตั้งค่าใดจำเป็นสำหรับรูปทรง 3 มิติที่มองเห็นได้?**

อย่างน้อยต้องตั้งค่าการหมุนของกล้องและการดึงออกหรือความลึก ในการปฏิบัติ ควรตั้งค่าชุดแสงและวัสดุด้วยเพื่อให้ด้านที่เรนเดอร์มีไฮไลท์และเงาชัดเจน.

**ฉันสามารถใช้เอฟเฟกต์ 3 มิติกับรูปทรงและข้อความได้หรือไม่?**

ได้ ใช้ [IShape.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/properties/threedformat) สำหรับร่างกายรูปทรงและ [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/properties/threedformat) สำหรับข้อความ.

**เอฟเฟกต์ 3 มิติจะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML, หรือเฟรมวิดีโอหรือไม่?**

ใช่ Aspose.Slides เรนเดอร์เอฟเฟกต์ 3 มิติเมื่อสร้างภาพสไลด์, PDF, HTML และเฟรมสำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์ ไม่ใช่วัตถุ 3 มิติที่แก้ไขได้.

**ฉันสามารถอ่านค่าจุด 3 มิติสุดท้ายหลังจากที่มีการสืบทอดและตั้งค่าธีมหรือไม่?**

ใช่ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายใน [Shape Effective Properties](/slides/th/net/shape-effective-properties/) เพื่ออ่านกล้อง, ชุดแสง, bevel, และค่ 3 มิติที่เกี่ยวข้อง.