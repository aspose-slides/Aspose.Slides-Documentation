---
title: สร้างภาพย่อของรูปร่างการนำเสนอใน .NET
linktitle: ภาพย่อของรูปร่าง
type: docs
weight: 70
url: /th/net/create-shape-thumbnails/
keywords:
- ภาพย่อของรูปร่าง
- รูปภาพของรูปร่าง
- เรนเดอร์รูปร่าง
- การเรนเดอร์รูปร่าง
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างภาพย่อของรูปร่างคุณภาพสูงจากสไลด์ PowerPoint ด้วย Aspose.Slides for .NET – สร้างและส่งออกภาพย่อของการนำเสนอได้อย่างง่ายดาย."
---
## **บทนำ**

Aspose.Slides for .NET ถูกใช้เพื่อสร้างไฟล์นำเสนอซึ่งแต่ละหน้าคือสไลด์ สไลด์เหล่านี้สามารถดูได้โดยการเปิดไฟล์นำเสนอด้วย Microsoft PowerPoint แต่บางครั้งนักพัฒนาอาจต้องการดูภาพของรูปร่างแยกกันในโปรแกรมดูภาพ ในกรณีเช่นนี้ Aspose.Slides for .NET ช่วยคุณสร้างภาพย่อของรูปร่างในสไลด์ วิธีการใช้คุณลักษณะนี้อธิบายไว้ในบทความนี้  
บทความนี้อธิบายวิธีการสร้างภาพย่อของสไลด์ในรูปแบบต่างๆ:

- สร้างภาพย่อของรูปร่างภายในสไลด์
- สร้างภาพย่อของรูปร่างสำหรับรูปร่างในสไลด์โดยกำหนดขนาดโดยผู้ใช้
- สร้างภาพย่อของรูปร่างในขอบเขตของการปรากฏของรูปร่าง

## **สร้างภาพย่อของรูปร่างจากสไลด์**
เพื่อสร้างภาพย่อของรูปร่างจากสไลด์ใดก็ได้โดยใช้ Aspose.Slides for .NET:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
1. รับอ้างอิงของสไลด์ใดก็ได้โดยใช้ ID หรือดัชนีของมัน.
1. รับภาพย่อของรูปร่างจากสไลด์ที่อ้างถึงโดยใช้สเกลค่าเริ่มต้น.
1. บันทึกภาพย่อเป็นรูปแบบภาพที่ต้องการใดก็ได้.

ตัวอย่างด้านล่างสร้างภาพย่อของรูปร่าง.

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

## **สร้างภาพย่อด้วยปัจจัยสเกลที่กำหนดโดยผู้ใช้**
เพื่อสร้างภาพย่อของรูปร่างจากสไลด์ใดก็ได้โดยใช้ Aspose.Slides for .NET:

1. สร้างอินสแตนซ์ของคลาส `Presentation`.
1. รับอ้างอิงของสไลด์ใดก็ได้โดยใช้ ID หรือดัชนีของมัน.
1. รับภาพย่อของสไลด์ที่อ้างถึงพร้อมขอบเขตของรูปร่าง.
1. บันทึกภาพย่อเป็นรูปแบบภาพที่ต้องการใดก็ได้.

ตัวอย่างด้านล่างสร้างภาพย่อด้วยปัจจัยสเกลที่กำหนดโดยผู้ใช้.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // การปรับขนาดตามแกน X และ Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **สร้างภาพย่อของรูปร่างตามขอบเขตการปรากฏ**
วิธีนี้สำหรับการสร้างภาพย่อของรูปร่างช่วยให้นักพัฒนาสามารถสร้างภาพย่อในขอบเขตการปรากฏของรูปร่างได้โดยคำนึงถึงเอฟเฟกต์ทั้งหมดของรูปร่าง ภาพย่อที่สร้างจะถูกจำกัดด้วยขอบเขตของสไลด์ เพื่อสร้างภาพย่อของรูปร่างใดก็ได้ในขอบเขตการปรากฏของมัน ให้ใช้โค้ดตัวอย่างต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation`.
1. รับอ้างอิงของสไลด์ใดก็ได้โดยใช้ ID หรือดัชนีของมัน.
1. รับภาพย่อของสไลด์ที่อ้างถึงพร้อมขอบเขตของรูปร่างเป็นการปรากฏ.
1. บันทึกภาพย่อเป็นรูปแบบภาพที่ต้องการใดก็ได้.

ตัวอย่างด้านล่างสร้างภาพย่อโดยอ้างอิงขอบเขตการปรากฏของรูปร่าง.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // การปรับขนาดตามแกน X และ Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **คำถามที่พบบ่อย**

**รูปแบบภาพใดบ้างที่สามารถใช้เมื่อต้องการบันทึกภาพย่อของรูปร่าง?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/th/net/aspose.slides/imageformat/), และอื่นๆ รูปร่างยังสามารถ [ส่งออกเป็นเวกเตอร์ SVG](https://reference.aspose.com/slides/th/net/aspose.slides/shape/writeassvg/) โดยบันทึกเนื้อหารูปร่างเป็น SVG.

**ความแตกต่างระหว่างขอบเขต Shape และ Appearance เมื่อเรนเดอร์ภาพย่อคืออะไร?**

`Shape` ใช้เรขาคณิตของรูปร่าง; `Appearance` พิจารณา [เอฟเฟกต์ภาพ](/slides/th/net/shape-effect/) (เงา, แสงเรือง, ฯลฯ) ด้วย.

**จะเกิดอะไรขึ้นหากรูปร่างถูกทำเครื่องหมายว่าเป็นซ่อน? มันยังจะถูกเรนเดอร์เป็นภาพย่อหรือไม่?**

รูปร่างที่ซ่อนอยู่ยังคงเป็นส่วนหนึ่งของโมเดลและสามารถเรนเดอร์ได้; ธงซ่อนมีผลต่อการแสดงสไลด์โชว์แต่ไม่ป้องกันการสร้างภาพของรูปร่าง.

**รูปร่างกลุ่ม, แผนภูมิ, SmartArt, และวัตถุซับซ้อนอื่นๆ รองรับหรือไม่?**

ใช่ วัตถุใดก็ได้ที่แทนด้วย [Shape](https://reference.aspose.com/slides/th/net/aspose.slides/shape/) (รวมถึง [GroupShape](https://reference.aspose.com/slides/th/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chart/), และ [SmartArt](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/smartart/)) สามารถบันทึกเป็นภาพย่อหรือเป็น SVG ได้.

**ฟอนต์ที่ติดตั้งในระบบมีผลต่อคุณภาพของภาพย่อสำหรับรูปร่างข้อความหรือไม่?**

ใช่ คุณควร [จัดหาแบบอักษรที่จำเป็น](/slides/th/net/custom-font/) (หรือ [กำหนดการแทนที่แบบอักษร](/slides/th/net/font-substitution/)) เพื่อหลีกเลี่ยงการสลับแบบอักษรที่ไม่ต้องการและการเปลี่ยนแปลงการจัดรูปแบบข้อความ.