---
title: สร้างเอฟเฟกต์ 3D ในการนำเสนอโดยใช้ .NET
linktitle: การนำเสนอ 3D
type: docs
weight: 232
url: /th/net/3d-presentation/
keywords:
- PowerPoint 3D
- การนำเสนอ 3D
- การหมุน 3D
- ความลึก 3D
- การดันออก 3D
- การไล่สี 3D
- ข้อความ 3D
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3D สำหรับรูปทรงและข้อความใน PowerPoint ด้วย .NET และ Aspose.Slides กำหนดค่ากล้อง, แสง, วัสดุ, การดันออก, การเติม, และข้อความ 3D"
---
## **ภาพรวม**

Aspose.Slides for .NET สามารถสร้าง, แก้ไข, รักษา และเรนเดอร์การจัดรูปแบบ 3D แบบ PowerPoint สำหรับรูปทรงและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3D เช่น การหมุน, การดันออก, bevels, การให้แสง, วัสดุ, การไล่สีหรือการเติมรูปภาพ, และข้อความ 3D

{{% alert color="primary" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3D บนรูปทรงและข้อความของ PowerPoint ไม่เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3D แยกต่างหาก เมื่อนำสไลด์ออกเป็นภาพ, PDF หรือ HTML Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3D เหล่านั้นลงในผลลัพธ์ 2D ที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3D**

ใช้คุณสมบัติ [IShape.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/properties/threedformat) เพื่อใช้การจัดรูปแบบ 3D กับรูปทรง คุณสมบัตินี้เปิดเผย [IThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat) ซึ่งควบคุมฉาก 3D สำหรับรูปทรงนั้น

สำหรับข้อความ ใช้คุณสมบัติ [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/properties/threedformat) สิ่งนี้จะใช้การจัดรูปแบบ 3D กับกรอบข้อความแทนส่วนของรูปทรง

คุณสมบัติที่สำคัญที่สุดคือ:

| คุณสมบัติ | สิ่งที่ควบคุม | เมื่อควรใช้ |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/camera) | จุดมองเห็น, ประเภทกล้องตั้งล่วงหน้า, การหมุน, การซูม, และมุมมองแบบ perspective. | หมุนวัตถุในพื้นที่ 3D หรือใช้ค่ากล้องหมุน 3D ของ PowerPoint ที่ตั้งไว้ล่วงหน้า. |
| [LightRig](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/lightrig) | การตั้งค่าแสง, ทิศทาง, และการหมุนแสง. | เปลี่ยนวิธีที่ไฮไลท์และเงาปรากฏบนพื้นผิว 3D. |
| [Material](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/material) | วัสดุพื้นผิว เช่น แบน, แมตต์, พลาสติก, หรือโลหะ. | ทำให้รูปทรงเดียวกันดูแบน, นุ่ม, มันวาว, หรือเงาโลหะ. |
| [ExtrusionHeight](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/extrusionheight) | ระยะที่รูปทรงยืดออกไปด้านหลังจากด้านหน้า. | เปลี่ยนรูปทรงแบนให้เป็นวัตถุ 3D ที่มีความหนาเห็นได้ชัด. |
| [ExtrusionColor](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/extrusioncolor) | สีของด้านที่ยื่นออก. | ทำให้มองเห็นความลึกหรือปรับสีด้านให้สอดคล้องกับสีเติมด้านหน้า. |
| [Depth](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/depth) | ความลึก 3D เพิ่มเติมที่ PowerPoint ใช้ในการจัดรูปแบบ 3D. | ปรับความลึกสำหรับรูปทรงหรือข้อความ, โดยเฉพาะเมื่อใช้ร่วมกับ bevel และการตั้งค่าวัสดุ. |
| [BevelTop](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/bevelbottom) | ขอบที่ยกขึ้นหรือโค้งมนบนด้านหน้าและด้านหลัง. | เพิ่มขอบที่นุ่มหรือเจลแบบหล่อแทนหน้าตัดแบนคม. |
| [ContourColor](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/contourwidth) | เส้นขอบรอบวัตถุ 3D. | เน้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์. |

## **สร้างรูปร่าง 3D**

โดยทั่วไปรูปทรงต้องการการตั้งค่าสี่ประเภทก่อนที่จะดูเหมือน 3D อย่างเชื่อถือได้:

- การตั้งค่ากล้อง, เนื่องจากมุมมองหน้าเริ่มต้นอาจทำให้การดันออกไม่เห็น.
- การตั้งค่าแสง, เนื่องจากแสงทำให้ด้านและข้างอ่านง่าย.
- การตั้งค่าวัสดุ, เนื่องจากพื้นผิวมีผลต่อการเรนเดอร์แสง.
- การตั้งค่าการดันออกหรือความลึก, เนื่องจากรูปแบนต้องการความหนา.

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมผืนผ้า, เพิ่มข้อความบนด้านหน้า, ใช้การจัดรูปแบบ 3D, บันทึกงานนำเสนอเป็น PPTX, และเรนเดอร์สไลด์เป็นภาพ PNG

```csharp
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

สไลด์ที่เรนเดอร์แสดงสี่เหลี่ยมผืนผ้าเป็นบล็อก 3D ที่หนา:

![สไลด์ที่เรนเดอร์รูปสี่เหลี่ยม 3D สีน้ำเงินพร้อมข้อความ 3D สีขาวบนด้านหน้า](img_01_01.png)

## **หมุนรูปร่างด้วยกล้อง**

ใน PowerPoint การหมุน 3D ถูกกำหนดจากแผง 3‑D Rotation ค่า X, Y, และ Z ของการหมุนสอดคล้องกับการหมุนที่ตั้งผ่าน API ของกล้อง

![แผง PowerPoint 3‑D Rotation พร้อมค่าการหมุน X, Y, และ Z ที่ไฮไลท์](img_02_01.png)

ใน Aspose.Slides ให้ตั้งค่าประเภทกล้องและการหมุนผ่าน [IThreeDFormat.Camera](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/camera):

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ดูมองเห็นวัตถุ ซึ่งไม่ได้เปลี่ยนรูปทรง 2D บนสไลด์ แต่เปลี่ยนมุมมอง 3D ที่ PowerPoint และ Aspose.Slides ใช้ในการเรนเดอร์

## **เพิ่มการดันออกและความลึก**

การดันออกทำให้รูปทรงดูหนาโดยขยายออกไปด้านหลังจากด้านหน้า ใน PowerPoint ตัวควบคุมความลึกกำหนดความหนาที่มองเห็นได้ และตัวควบคุมสีกำหนดสีของด้านข้าง

![ตัวควบคุมความลึกของ PowerPoint ที่เชื่อมโยงกับคุณสมบัติ extrusion color และ extrusion height](img_02_02.png)

ตั้งค่า [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/extrusionheight) สำหรับความหนาและ [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/extrusioncolor) สำหรับสีด้านข้าง:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

ใช้ [IThreeDFormat.Depth](https://reference.aspose.com/slides/th/net/aspose.slides/ithreedformat/properties/depth) เมื่อคุณต้องการทำงานกับค่าความลึกของ PowerPoint ตรง ๆ หรือรวมความลึกกับ bevel, material, และเอฟเฟกต์ข้อความ ในหลายกรณี `ExtrusionHeight` จะชัดเจนกว่าเพราะบ่งบอกความหนาที่มองเห็นโดยตรง

## **ใช้การไล่สีหรือการเติมรูปภาพกับเอฟเฟกต์ 3D**

การจัดรูปแบบ 3D ทำงานแยกจากการเติมรูปทรง คุณสามารถใช้สีทึบ, การไล่สี, รูปแบบ, หรือการเติมรูปภาพบนด้านหน้าและยังใช้การตั้งค่ากล้อง, แสง, วัสดุ, และการดันออกเดียวกันได้

ตัวอย่างนี้ใช้การไล่สีบนรูปทรงและสีดันออกที่เข้มขึ้นบนด้านข้าง:

```csharp
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

ผลลัพธ์ที่เรนเดอร์ยังคงการไล่สีบนด้านหน้าและเรนเดอร์การดันออกเป็นส่วนแยกต่างหาก:

![สไลด์ที่เรนเดอร์รูปสี่เหลี่ยม 3D พร้อมการไล่สีจากน้ำเงินไปส้มและดันออกสีส้ม](img_02_03.png)

หากต้องการใช้การเติมรูปภาพ ให้เพิ่มภาพลงในงานนำเสนอและกำหนดให้เป็นการเติมรูปทรง:

```csharp
var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

รูปภาพจะเรนเดอร์บนด้านหน้า ขณะที่การดันออกจะเรนเดอร์เป็นพื้นผิวด้านข้าง 3D:

![สไลด์ที่เรนเดอร์รูปสี่เหลี่ยม 3D พร้อมการเติมรูปถ่ายบนด้านหน้าและดันออกสีส้ม](img_02_04.png)

## **นำการจัดรูปแบบ 3D ไปใช้กับข้อความ**

การจัดรูปแบบ 3D ของรูปทรงมีผลต่อส่วนของรูปทรง ส่วนการจัดรูปแบบ 3D ของข้อความมีผลต่อกรอบข้อความ ซึ่งมีประโยชน์สำหรับเอฟเฟกต์ลักษณะ WordArt ที่ต้องการให้ตัวอักษรเองมีการดันออก, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยการเติมลายแบบ, ใช้การแปลง WordArt, และกำหนดค่าการตั้งค่า 3D บน [ITextFrameFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat):

```csharp
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

ข้อความจะเรนเดอร์เป็นตัวอักษร 3D ที่โค้งและดันออก:

![ข้อความ 3D ที่เรนเดอร์พร้อมการแปลง WordArt โค้ง, การเติมลายสีส้ม, และการดันออกสีเข้ม](img_02_05.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3D เมื่อบันทึกเป็นรูปแบบ PowerPoint เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นรูปแบบที่มีเลย์เอาต์คงที่ ฉาก 3D จะถูกแปลงเป็นภาพหรือวาดลงในผลลัพธ์เป็นรูปแบบ 2D ซึ่งเกิดขึ้นเมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/net/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/net/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/net/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/net/convert-powerpoint-to-video/)

ควรจำจุดเหล่านี้:

- ภาพและ PDF ที่ส่งออกไม่สามารถโต้ตอบได้ วัตถุไม่สามารถหมุนโดยผู้ชมหลังการส่งออก
- ลักษณะที่สุดท้ายขึ้นอยู่กับการผสมผสานของกล้อง, light rig, material, extrusion, fill, และการสเกลสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรืออิงธีม ให้อ่าน [effective shape properties](/slides/th/net/shape-effective-properties/)
- รูปแบบผลลัพธ์บางอย่างไม่สามารถเก็บการจัดรูปแบบ 3D ของ PowerPoint ที่แก้ไขได้ ในรูปแบบเหล่านั้นผลลัพธ์จะถูกเรนเดอร์แทนการเก็บเป็นการตั้งค่า 3D ที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างการนำเสนอ 3D ที่โต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3D ของ PowerPoint สำหรับรูปทรงและข้อความ ไม่ทำให้ภาพ, PDF, หรือหน้า HTML ที่ส่งออกเป็นฉาก 3D ที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3D ยังคงสามารถแก้ไขได้ใน PowerPoint ที่รองรับฟีเจอร์นี้

**ความแตกต่างระหว่างโมเดล 3D กับเอฟเฟกต์ 3D คืออะไร?**

โมเดล 3D เป็นวัตถุ 3D แยกที่แทรกลงในงานนำเสนอ ส่วนเอฟเฟกต์ 3D เป็นการจัดรูปแบบที่นำไปใช้กับรูปทรงหรือข้อความธรรมดาของ PowerPoint เช่น การหมุน, การดันออก, bevel, แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3D

**ต้องตั้งค่าอะไรบ้างเพื่อให้เห็นรูปทรง 3D?**

อย่างน้อยต้องตั้งค่าการหมุนของกล้องและตั้งค่าการดันออกหรือความลึก ในการปฏิบัติจริงควรตั้งค่า light rig และ material ด้วยเพื่อให้ด้านที่เรนเดอร์มีไฮไลท์และเงาชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3D กับรูปทรงและข้อความได้หรือไม่?**

ได้ ใช้ [IShape.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/properties/threedformat) สำหรับส่วนของรูปทรงและ [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/th/net/aspose.slides/itextframeformat/properties/threedformat) สำหรับข้อความ

**เอฟเฟกต์ 3D จะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

จะปรากฏ Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3D เมื่อสร้างภาพสไลด์, ผลลัพธ์ PDF, HTML, หรือเฟรมที่ใช้สำหรับแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะเป็นภาพที่เรนเดอร์ ไม่ใช่วัตถุ 3D ที่แก้ไขได้

**ฉันสามารถอ่านค่าการจัดรูปแบบ 3D สุดท้ายหลังจากการสืบทอดและการตั้งค่าธีมหรือไม่?**

ได้ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายไว้ใน [Shape Effective Properties](/slides/th/net/shape-effective-properties/) เพื่ออ่านค่ากล้อง, light rig, bevel, และค่าการจัดรูปแบบ 3D อื่น ๆ ที่สุดท้าย.