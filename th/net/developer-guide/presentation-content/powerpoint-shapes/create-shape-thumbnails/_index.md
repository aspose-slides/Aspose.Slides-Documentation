---
title: สร้างภาพขนาดย่อของรูปร่างงานนำเสนอใน .NET
linktitle: ภาพขนาดย่อของรูปร่าง
type: docs
weight: 70
url: /th/net/create-shape-thumbnails/
keywords:
- ภาพขนาดย่อของรูปร่าง
- รูปภาพของรูปร่าง
- เรนเดอร์รูปร่าง
- การเรนเดอร์รูปร่าง
- ขอบเขตภาพจริง
- ขอบเขตรูปร่าง
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างภาพขนาดย่อของรูปร่างคุณภาพสูงจากสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ .NET – สร้างและส่งออกรูปขนาดย่อของการนำเสนอได้อย่างง่ายดาย."
---
## **บทนำ**

Aspose.Slides for .NET ถูกใช้เพื่อสร้างไฟล์งานนำเสนอที่แต่ละหน้าเป็นสไลด์ สไลด์เหล่านี้สามารถดูได้โดยการเปิดไฟล์งานนำเสนอด้วย Microsoft PowerPoint แต่บางครั้งนักพัฒนาอาจต้องการดูรูปภาพของรูปร่างแยกกันในโปรแกรมแสดงรูป ในกรณีเช่นนี้ Aspose.Slides for .NET ช่วยคุณสร้างภาพขนาดย่อของรูปร่างสไลด์ วิธีการใช้คุณลักษณะนี้อธิบายไว้ในบทความนี้  
บทความนี้อธิบายวิธีสร้างภาพขนาดย่อของสไลด์ในหลายวิธี:

- สร้างภาพขนาดย่อของรูปร่างภายในสไลด์
- สร้างภาพขนาดย่อของรูปร่างสไลด์ด้วยมิติที่ผู้ใช้กำหนด
- สร้างภาพขนาดย่อของรูปร่างในขอบเขตของลักษณะการปรากฏของรูปร่าง

## **สร้างภาพขนาดย่อของรูปร่างจากสไลด์**
เพื่อสร้างภาพขนาดย่อของรูปร่างจากสไลด์ใด ๆ ด้วย Aspose.Slides for .NET:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. ดึงอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรืออินเดกซ์ของมัน.
3. รับภาพขนาดย่อของรูปร่างจากสไลด์ที่อ้างอิงโดยใช้สเกลค่าเริ่มต้น.
4. บันทึกภาพขนาดย่อไปยังรูปแบบภาพที่ต้องการ.

ตัวอย่างด้านล่างแสดงการสร้างภาพขนาดย่อของรูปร่าง.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **สร้างภาพขนาดย่อด้วยค่าปัจจัยสเกลที่กำหนดโดยผู้ใช้**
เพื่อสร้างภาพขนาดย่อของรูปร่างสไลด์ใด ๆ ด้วย Aspose.Slides for .NET:

1. สร้างอินสแตนซ์ของคลาส `Presentation`.
2. ดึงอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรืออินเดกซ์ของมัน.
3. รับภาพขนาดย่อของสไลด์ที่อ้างอิงพร้อมขอบเขตของรูปร่าง.
4. บันทึกภาพขนาดย่อไปยังรูปแบบภาพที่ต้องการ.

ตัวอย่างด้านล่างแสดงการสร้างภาพขนาดย่อโดยใช้ค่าปัจจัยสเกลที่กำหนดโดยผู้ใช้.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // การสเกลตามแกน X และ Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **สร้างภาพขนาดย่อของรูปร่างตามขอบเขตของลักษณะการปรากฏ**
วิธีนี้สำหรับการสร้างภาพขนาดย่อของรูปร่างช่วยให้นักพัฒนาสามารถสร้างภาพขนาดย่อยภายในขอบเขตของลักษณะการปรากฏของรูปร่างได้ โดยจะคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปร่าง ภาพขนาดย่อของรูปร่างที่สร้างจะถูกจำกัดโดยขอบเขตของสไลด์ เพื่อสร้างภาพขนาดย่อของรูปร่างสไลด์ใด ๆ ภายในขอบเขตของลักษณะการปรากฏ ให้ใช้โค้ดตัวอย่างต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation`.
2. ดึงอ้างอิงของสไลด์ใด ๆ โดยใช้ ID หรืออินเดกซ์ของมัน.
3. รับภาพขนาดย่อของสไลด์ที่อ้างอิงโดยใช้ขอบเขตของรูปร่างเป็นลักษณะการปรากฏ.
4. บันทึกภาพขนาดย่อไปยังรูปแบบภาพที่ต้องการ.

ตัวอย่างด้านล่างแสดงการสร้างภาพขนาดย่อโดยใช้ค่าปัจจัยสเกลที่กำหนดโดยผู้ใช้.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // การสเกลตามแกน X และ Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **รับขอบเขตภาพจริงของรูปร่าง**

คุณสมบัติเฟรมของ [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) — `X`, `Y`, `Width`, และ `Height` — อธิบายสี่เหลี่ยมที่จัดเก็บในโมเดลงานนำเสนอ เนื้อหาที่ทำการเรนเดอร์จริงอาจขยายออกไปนอกเฟรมหรือครอบคลุมสี่เหลี่ยมที่จัดแนวแกนต่างกัน การหมุน, โครงร่าง, ลูกศรหัว, การจัดวางข้อความและการล้น, รูปร่าง SmartArt ที่สร้างขึ้น, และเอฟเฟกต์การเรนเดอร์อื่น ๆ ทั้งหมดสามารถเปลี่ยนแปลงพื้นที่ที่ใช้ได้

ใช้ [GetVisualBounds](https://reference.aspose.com/slides/th/net/aspose.slides/shape/getvisualbounds/) เพื่อคำนวณพื้นที่นั้นโดยไม่ต้องสร้างภาพ วิธีนี้จะคืนค่า [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) ในพิกัดของสไลด์ สี่เหลี่ยมที่คืนค่าไม่ถูกคลิปให้พอดีกับสไลด์ ดังนั้นพิกัดอาจเป็นค่าลบเมื่อเนื้อหาขยายเกินจุดกำเนิดของสไลด์

[GetVisualBounds](https://reference.aspose.com/slides/th/net/aspose.slides/shape/getvisualbounds/) ยังไม่ได้ถูกประกาศในอินเตอร์เฟส [IShape](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/) ดังนั้นให้เก็บรูปร่างที่ดึงมาจากคอลเลกชันรูปร่างของสไลด์เป็นค่าอินเตอร์เฟสและทำการแคสต์เฉพาะเมื่อเรียกใช้เมธอดนั้น

ตัวอย่างต่อไปนี้ดึงและเปรียบเทียบเฟรมกับขอบเขตภาพจริง:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

[RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) เดียวกันสามารถใช้จัดเรียงรูปร่างที่อยู่ใกล้เคียงให้ชิดด้าน `Left`, `Right`, `Top`, หรือ `Bottom` ของมัน; จองพื้นที่เพียงพอในเลย์เอาต์ที่สร้าง; หรือ ตรวจจับเนื้อหานอกพื้นที่ที่อนุญาต ขอบเขตภาพจริงมีประโยชน์อย่างยิ่งสำหรับ SmartArt, กล่องข้อความ, ลูกศร, รูปภาพ, รูปร่างที่หมุน, และกลุ่มรูปร่าง ซึ่งเฟรมที่จัดเก็บอาจไม่สอดคล้องกับผลลัพธ์ที่เรนเดอร์ทั้งหมด

ใช้ [GetVisualBounds](https://reference.aspose.com/slides/th/net/aspose.slides/shape/getvisualbounds/) เมื่อคุณต้องการพิกัดสำหรับการจัดวางหรือการตรวจสอบและไม่ต้องการบิตแมป ใช้ [IShape.GetImage](https://reference.aspose.com/slides/th/net/aspose.slides/ishape/getimage/) เมื่อคุณต้องการเรนเดอร์รูปร่าง ส่วนด้วย [ShapeThumbnailBounds](https://reference.aspose.com/slides/th/net/aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds.Shape` จะกำหนดขนาดภาพจากขอบเขตของรูปร่างรวมถึงการตั้งค่าโครงร่าง ส่วน `ShapeThumbnailBounds.Appearance` จะกำหนดขนาดจากลักษณะการปรากฏของรูปร่างและจำกัดผลลัพธ์ให้พอใส่ในขอบเขตของสไลด์ ตรงกันข้ามกับ [GetVisualBounds](https://reference.aspose.com/slides/th/net/aspose.slides/shape/getvisualbounds/) ที่คืนเพียงสี่เหลี่ยมที่คำนวณได้และไม่คลิปให้พอดีกับสไลด์

## **คำถามที่พบบ่อย**

**รูปแบบภาพใดบ้างที่สามารถใช้เมื่อบันทึกภาพขนาดย่อของรูปร่าง?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/net/aspose.slides/imageformat/), และอื่น ๆ รูปร่างยังสามารถ [exported as vector SVG](https://reference.aspose.com/slides/th/net/aspose.slides/shape/writeassvg/) ได้โดยบันทึกเนื้อหารูปร่างเป็น SVG

**ความแตกต่างระหว่างขอบเขต Shape และ Appearance คืออะไรเมื่อเรนเดอร์ภาพขนาดย่อ?**  
`Shape` ใช้เรขาคณิตของรูปร่าง; `Appearance` จะคำนึงถึง [visual effects](/slides/th/net/shape-effect/) (เงา, แสงเรืองแสง ฯลฯ)

**จะเกิดอะไรขึ้นถ้ารูปร่างได้รับการตั้งค่าเป็นซ่อน? จะยังคงสร้างภาพขนาดย่อได้หรือไม่?**  
รูปร่างที่ซ่อนยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธงซ่อนมีผลต่อการแสดงในโหมดสไลด์โชว์เท่านั้น ไม่ได้ป้องกันการสร้างภาพของรูปร่าง

**กลุ่มรูปร่าง, แผนภูมิ, SmartArt, และอ็อบเจกต์ซับซ้อนอื่น ๆ รองรับหรือไม่?**  
ใช่ ใด ๆ ที่เป็น [Shape](https://reference.aspose.com/slides/th/net/aspose.slides/shape/) (รวมถึง [GroupShape](https://reference.aspose.com/slides/th/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chart/), และ [SmartArt](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/smartart/)) สามารถบันทึกเป็นภาพขนาดย่อหรือเป็น SVG ได้

**ฟอนต์ที่ติดตั้งในระบบมีผลต่อคุณภาพของภาพขนาดย่อสำหรับรูปร่างข้อความหรือไม่?**  
มี คุณควร [provide the required fonts](/slides/th/net/custom-font/) (หรือ [configure font substitutions](/slides/th/net/font-substitution/)) เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรองที่ไม่ต้องการและการจัดเรียงข้อความใหม่.