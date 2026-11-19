---
title: สร้างเอฟเฟกต์ 3D ในการนำเสนอด้วย .NET
linktitle: การนำเสนอ 3D
type: docs
weight: 232
url: /th/net/3d-presentation/
keywords:
- PowerPoint 3D
- การนำเสนอ 3D
- การหมุน 3D
- ความลึก 3D
- การดึงออก 3D
- ไล่สี 3D
- ข้อความ 3D
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้และเรนเดอร์เอฟเฟกต์ 3D สำหรับรูปร่างและข้อความใน PowerPoint ด้วย .NET และ Aspose.Slides กำหนดค่ากล้อง, แสง, วัสดุ, การดึงออก, การเติม, และข้อความ 3D"
---
## **ภาพรวม**

Aspose.Slides for .NET สามารถสร้าง, แก้ไข, คงไว้และเรนเดอร์การจัดรูปแบบ 3D แบบ PowerPoint สำหรับรูปร่างและข้อความได้ บทความนี้ครอบคลุมเอฟเฟกต์ 3D เช่น การหมุน, การดึงออกเป็นรูปร่าง (extrusion), การบีเวิล, แสง, วัสดุ, การไล่สีหรือการเติมภาพ, และข้อความ 3D

{{% alert color="info" title="หมายเหตุ" %}}
บทความนี้เกี่ยวกับเอฟเฟกต์การจัดรูปแบบ 3D บนรูปร่างและข้อความของ PowerPoint ไม่ได้เกี่ยวกับการแทรกหรือแก้ไขไฟล์โมเดล 3D แยกต่างหาก เมื่อคุณส่งออกสไลด์เป็นภาพ, PDF หรือ HTML, Aspose.Slides จะเรนเดอร์เอฟเฟกต์ 3D เหล่านั้นลงในผลลัพธ์ 2D ที่ส่งออก
{{% /alert %}}

## **แนวคิดการจัดรูปแบบ 3D**

ใช้คุณสมบัติ [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) เพื่อใช้การจัดรูปแบบ 3D กับรูปร่าง คุณสมบัตินี้เปิดเผย [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) ซึ่งควบคุมฉาก 3D สำหรับรูปร่างนั้น

สำหรับข้อความ, ให้ใช้คุณสมบัติ [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) ซึ่งจะจัดรูปแบบ 3D ให้กับเฟรมข้อความแทนส่วนเนื้อหาของรูปร่าง

คุณสมบัติที่สำคัญมีดังนี้

| คุณสมบัติ | ควบคุมอะไร | เมื่อใดควรใช้ |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | มุมมอง, ประเภทกล้องตั้งค่าล่วงหน้า, การหมุน, ซูม, และการมองในมุมลึก | หมุนวัตถุในพื้นที่ 3D หรือใช้ค่าการหมุน 3D ของ PowerPoint ที่ตั้งค่าล่วงหน้า |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | แสงตั้งค่าล่วงหน้า, ทิศทาง, และการหมุนแสง | ปรับวิธีที่ไฮไลท์และเงาปรากฏบนพื้นผิว 3D |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | วัสดุผิว, เช่น แฟลต, แมต, พลาสติก หรือโลหะ | ทำให้รูปทรงเดียวกันดูแบน, นุ่ม, เงาหรือโลหะได้ |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | ระยะที่รูปร่างยืดออกไปด้านหลังจากพื้นหน้า | เปลี่ยนรูปร่างแบนให้เป็นวัตถุ 3D ที่มีความหนาเป็นที่มองเห็น |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | สีของด้านที่ดึงออก | ทำให้ความลึกมองเห็นได้หรือประสานสีด้านกับการเติมสีหน้า |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | ความลึก 3D เพิ่มเติมที่ PowerPoint ใช้ | ปรับความลึกอย่างละเอียดสำหรับรูปร่างหรือข้อความ, โดยเฉพาะเมื่อใช้ร่วมกับ bevel และ material |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) และ [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | ขอบยกหรือโค้งบนพื้นหน้าและพื้นหลัง | เพิ่มขอบที่อ่อนนุ่มหรือหล่อรูปแทนพื้นแบนที่คม |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) และ [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | เส้นขอบรอบวัตถุ 3D | เน้นขอบวัตถุในผลลัพธ์ที่เรนเดอร์ |

## **สร้างรูปทรง 3 มิติ**

รูปร่างมักต้องการการตั้งค่าสี่ประเภทก่อนที่จะดูเหมือน 3D อย่างเชื่อถือได้:

- การตั้งค่ากล้อง, เนื่องจากมุมมองหน้าเริ่มต้นอาจซ่อนการดึงออก
- การตั้งค่าแสง, เนื่องจากแสงทำให้ด้านและข้างของรูปร่างอ่านง่าย
- การตั้งค่าวัสดุ, เนื่องจากพื้นผิวส่งผลต่อการเรนเดอร์แสง
- การตั้งค่าการดึงออกหรือความลึก, เนื่องจากรูปร่างแบนต้องการความหนา

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยม, เพิ่มข้อความบนพื้นหน้า, และใช้การจัดรูปแบบ 3D ค่าการหมุนกล้องอยู่ในหน่วยองศา และความสูงการดึงออกคือ 100 จุด ตัวอย่างเรนเดอร์สไลด์เป็นภาพ PNG ขนาดสองเท่าของขนาดเริ่มต้นและบันทึกงานนำเสนอเป็น PPTX

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

ภาพสไลด์ที่เรนเดอร์แสดงสี่เหลี่ยมเป็นบล็อก 3D หนา:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **หมุนรูปทรงด้วยกล้อง**

ใน PowerPoint, การหมุน 3D ถูกกำหนดจากแผง 3-D Rotation ค่าการหมุน X, Y, Z สอดคล้องกับการหมุนที่คุณตั้งค่าผ่าน API ของกล้อง

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

ใน Aspose.Slides, เข้าถึงกล้องผ่าน [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) ตัวอย่างนี้สร้างสี่เหลี่ยม, เลือกมุมมองหน้าแบบ orthographic, และตั้งการหมุน X, Y, Z เป็น 20, 30, และ 40 องศาตามลำดับ มันกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

ใช้กล้องเมื่อคุณต้องการเปลี่ยนวิธีที่ผู้ชมมองวัตถุ มันไม่เปลี่ยนเรขาคณิต 2D ของรูปร่างบนสไลด์ แต่เปลี่ยนมุมมอง 3D ที่ PowerPoint และ Aspose.Slides ใช้เมื่อตีภาพ

### **คัดลอกการวางแนวกล้องจากรูปทรงแม่แบบ**

เพื่อให้ตรงกับรูปร่างในแม่แบบ, คัดลอกการตั้งค่า [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) ล่วงหน้าและอ่านมุมด้วย [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/) ตัวอย่างเปิด `template.pptx`, อ่านกล้องจากรูปร่างแรกบนสไลด์แรก, และนำการวางแนวไปใช้กับรูปร่างที่สอง ทั้งสองรูปร่างมีแสง 3D อยู่แล้วและรูปร่างที่สองไม่มีการหมุนกล้องโดยตรง

มุมอยู่ในหน่วยองศา ดัชนี `0` คือละติจูด, ดัชนี `1` คือลองจิจูด, ดัชนี `2` คือการปั่น ส่งค่าต่อไปยัง [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) ตามลำดับ หากแหล่งคืนค่า `null` หมายถึงไม่มีการหมุนโดยตรง จึงปล่อยให้มุมของรูปร่างที่สองไม่ตั้งค่า การหมุนโดยตรงของ `(0, 0, 0)` คืนค่าเป็นศูนย์สามค่าและควรคัดลอก

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

เมื่อคุณเปิด `camera-copy.pptx` อีกครั้ง, ทั้งสองรูปร่างจะมีการตั้งค่ากล้องและการหมุนเดียวกัน ใน PowerPoint, ลูกศรทางขวาใช้การวางแนวกล้องที่คัดลอกจากสี่เหลี่ยมด้านซ้าย ทั้งสองรูปร่างใช้แสงและความลึกการดึงออกเดียวกัน

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **เพิ่มการดึงออกและความลึก**

การดึงออกทำให้รูปร่างดูหนาด้วยการยืดส่วนที่อยู่ด้านหลังจากพื้นหน้า ใน PowerPoint, ควบคุมความลึกกำหนดความหนาที่มองเห็นได้, และการควบคุมสีกำหนดสีของด้านข้าง

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

ตั้งค่า [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) สำหรับความหนาและ [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) สำหรับสีด้าน ตัวอย่างนี้ให้สี่เหลี่ยมดึงออก 100 จุดด้วยสีด้านสีม่วงและหมุนกล้องเพื่อเปิดเผยความหนา มันกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกไฟล์:

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

คุณสมบัติ [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) กำหนดความลึกของรูปทรง 3D ส่วนคุณสมบัติ [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) ควบคุมความสูงของเอฟเฟกต์ดึงออก ตามที่แสดงในตัวอย่างนี้

## **ใช้การไล่สีหรือการเติมภาพกับเอฟเฟกต์ 3D**

การจัดรูปแบบ 3D แยกจากการเติมรูปร่าง คุณสามารถเติมสีทึบ, ไล่สี, ลวดลาย, หรือภาพบนพื้นหน้าและยังใช้กล้อง, แสง, วัสดุ, และการดึงออกเดียวกัน

ตัวอย่างนี้ใช้ไล่สีจากสีฟ้าไปส้มบนพื้นหน้าและสีส้มเข้มบนการดึงออก 150 จุด จุดไล่สีที่ 0 และ 100 แสดงจุดเริ่มและจบของไล่สี ค่าการหมุนกล้องอยู่ในหน่วยองศา สไลด์ถูกเรนเดอร์เป็นภาพ PNG ขนาดสองเท่าของขนาดเริ่มต้น:

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

ผลลัพธ์ที่เรนเดอร์ยังคงไล่สีบนพื้นหน้าและเรนเดอร์การดึงออกแยกกัน:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

เพื่อใช้การเติมภาพ, เพิ่มภาพลงในงานนำเสนอและกำหนดให้เป็นการเติมรูปร่าง ตัวอย่างนี้ต้องการไฟล์ชื่อ "image.jpg" อยู่ในไดเรกทอรีทำงาน มันขยายภาพให้เต็มสี่เหลี่ยม, ใช้การดึงออก 150 จุด, และตั้งค่าการหมุนกล้องในหน่วยองศา มันกำหนดค่ารูปร่างในหน่วยความจำโดยไม่บันทึกหรือเรนเดอร์ไฟล์:

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

ภาพจะถูกเรนเดอร์บนพื้นหน้า, ส่วนการดึงออกจะถูกเรนเดอร์เป็นพื้นผิวด้านข้างของ 3D:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **ใช้การจัดรูปแบบ 3D กับข้อความ**

การจัดรูปแบบ 3D ของรูปร่างส่งผลต่อส่วนเนื้อหาของรูปร่าง การจัดรูปแบบ 3D ของข้อความส่งผลต่อเฟรมข้อความ ซึ่งมีประโยชน์สำหรับเอฟเฟกต์คล้าย WordArt ที่ต้องการให้ตัวอักษรเองมีการดึงออก, วัสดุ, แสง, และการตั้งค่ากล้อง

ตัวอย่างต่อไปนี้สร้างข้อความด้วยลวดลายตารางสีส้ม-ขาว, ใช้การโค้งขึ้น, และตั้งค่าการจัดรูปแบบ 3D ผ่าน [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) ความสูงการดึงออกและความลึกอยู่ในหน่วยจุด, การหมุนแสงอยู่ในหน่วยองศา การเติมและเส้นขอบของรูปร่างถูกซ่อนไว้เพื่อให้เห็นเฉพาะข้อความ ตัวอย่างเรนเดอร์ภาพ PNG ที่สองเท่าของขนาดสไลด์เริ่มต้นและบันทึกงานนำเสนอเป็น PPTX:

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

ข้อความถูกเรนเดอร์เป็นอักษร 3D โค้งและดึงออก:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **คงข้อความให้แบนบนรูปทรง 3D**

เพื่อให้ข้อความอ่านง่ายขณะรักษารูปลักษณ์ 3D ของรูปร่าง, ตั้งค่า [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) ผ่าน [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/) เมื่อค่าเป็น `true` ข้อความจะอยู่นอกฉาก 3D เมื่อเป็น `false` ข้อความจะเข้าร่วมในฉากและตามทิศทาง 3D

การตั้งค่านี้ไม่ลบการจัดรูปแบบ 3D ของรูปร่าง: กล้อง, แสง, วัสดุ, และการดึงออกยังคงกำหนดผ่าน [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) และมันต่างจากการหมุนปกติ [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) หมุนรูปร่างในระนาบสไลด์, ในขณะที่ [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) ควบคุมการหมุนกำหนดเองของข้อความภายในกล่องขอบเขต การเก็บข้อความนอกฉาก 3D ไม่รีเซ็ตมุมใด ๆ เหล่านั้น

ตัวอย่างต่อไปนี้สร้างสี่เหลี่ยมสีน้ำเงินพร้อมข้อความและสำเนามาไว้ข้างๆ ทั้งสองรูปร่างมีการจัดรูปแบบ 3D เดียวกัน; เพียงการตั้งค่าข้อความต่างกัน: `false` ทางซ้ายและ `true` ทางขวา มุมกล้องอยู่ในหน่วยองศาและความสูงการดึงออกคือ 40 จุด ตัวอย่างบันทึกงานนำเสนอเป็น PPTX และเรนเดอร์สไลด์เปรียบเทียบเป็น PNG ที่สองเท่าของขนาดเริ่มต้น

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

ทางซ้ายข้อความตามทิศทาง 3D ทางขวาข้อความคงแบนและอ่านง่ายกว่า ทั้งสองสี่เหลี่ยมยังคงความหนาการดึงออกและทิศทาง 3D ที่มองเห็นได้

![Side-by-side 3D rectangles: KeepTextFlat is false on the left and true on the right](keep_text_flat.png)

## **พฤติกรรมการส่งออกและการเรนเดอร์**

Aspose.Slides รักษาการจัดรูปแบบ 3D เมื่อต Saving to PowerPoint formats เช่น PPTX เมื่อเรนเดอร์หรือส่งออกเป็นฟอร์แมตแบบคงที่, ฉาก 3D จะถูกแปลงเป็นภาพราสเตอร์หรือวาดลงในผลลัพธ์เป็น 2D สิ่งนี้ใช้เมื่อคุณเรนเดอร์สไลด์เป็น [PNG](/slides/th/net/convert-powerpoint-to-png/), ส่งออกเป็น [PDF](/slides/th/net/convert-powerpoint-to-pdf/), ส่งออกเป็น [HTML](/slides/th/net/convert-powerpoint-to-html/), หรือสร้างเฟรมสำหรับ [video conversion](/slides/th/net/convert-powerpoint-to-video/)

ควรจำ:

- ภาพและ PDF ที่ส่งออกจะไม่เป็นแบบโต้ตอบ วัตถุไม่สามารถหมุนได้โดยผู้ชมหลังการส่งออก
- ลักษณะสุดท้ายขึ้นอยู่กับการผสมผสานของกล้อง, light rig, material, extrusion, fill, และการสเกลสไลด์
- หากต้องการตรวจสอบค่าการจัดรูปแบบที่สืบทอดหรือจากธีม, อ่าน [effective shape properties](/slides/th/net/shape-effective-properties/)
- บางฟอร์แมตผลลัพธ์ไม่สามารถเก็บการจัดรูปแบบ 3D ของ PowerPoint ที่แก้ไขได้ ในฟอร์แมตเหล่านั้นผลลัพธ์จะถูกเรนเดอร์แทนที่จะเก็บเป็นการตั้งค่า 3D ที่แก้ไขได้

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถสร้างการนำเสนอ 3D แบบโต้ตอบได้หรือไม่?**

Aspose.Slides สร้างและเรนเดอร์เอฟเฟกต์ 3D ของ PowerPoint สำหรับรูปร่างและข้อความ ไม่ได้ทำให้ภาพ, PDF, หรือหน้า HTML ที่ส่งออกเป็นฉาก 3D ที่ผู้ชมสามารถหมุนได้ ใน PPTX การจัดรูปแบบ 3D ยังคงแก้ไขได้ใน PowerPoint ที่ฟอร์แมตรองรับ

**ความแตกต่างระหว่างโมเดล 3D กับเอฟเฟกต์ 3D คืออะไร?**

โมเดล 3D คือวัตถุ 3D แยกที่แทรกลงในงานนำเสนอ ส่วนเอฟเฟกต์ 3D คือการจัดรูปแบบที่ใช้กับรูปร่างหรือข้อความปกติของ PowerPoint เช่น การหมุน, ดึงออก, bevel, แสง, และวัสดุ บทความนี้ครอบคลุมเอฟเฟกต์ 3D

**ต้องตั้งค่าอะไรบ้างเพื่อให้รูปทรง 3D มองเห็นได้?**

อย่างน้อยต้องตั้งค่าการหมุนกล้องและอย่างใดอย่างหนึ่งระหว่างการดึงออกหรือความลึก ในการปฏิบัติจริงควรตั้งค่า light rig และ material เพื่อให้ด้านที่เรนเดอร์มีไฮไลท์และเงาชัดเจน

**ฉันสามารถใช้เอฟเฟกต์ 3D กับรูปร่างและข้อความได้หรือไม่?**

ได้ ใช้ [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) สำหรับส่วนเนื้อหารูปร่างและ [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) สำหรับข้อความ

**เอฟเฟกต์ 3D จะปรากฏเมื่อส่งออกเป็นภาพ, PDF, HTML หรือเฟรมวิดีโอหรือไม่?**

ใช่ Aspose.Slides เรนเดอร์เอฟเฟกต์ 3D ขณะสร้างภาพสไลด์, ผลลัพธ์ PDF, HTML, และเฟรมสำหรับการแปลงวิดีโอ ผลลัพธ์ที่ส่งออกจะมีลักษณะที่เรนเดอร์ ไม่ใช่วัตถุ 3D ที่แก้ไขได้

**ฉันสามารถอ่านค่าภาพสุดท้ายของ 3D หลังจากการสืบทอดและการตั้งค่าธีมหรือไม่?**

ได้ ใช้ API การจัดรูปแบบที่มีประสิทธิภาพที่อธิบายไว้ใน [Shape Effective Properties](/slides/th/net/shape-effective-properties/) เพื่ออ่านกล้อง, light rig, bevel, และค่าที่เกี่ยวข้องกับ 3D ที่สุดท้าย