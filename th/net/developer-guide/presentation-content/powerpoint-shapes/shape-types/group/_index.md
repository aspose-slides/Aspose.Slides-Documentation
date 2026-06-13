---
title: รูปทรงการนำเสนอแบบกลุ่มใน .NET
linktitle: กลุ่มรูปร่าง
type: docs
weight: 40
url: /th/net/group/
keywords:
- กลุ่มรูปทรง
- กลุ่มรูปร่าง
- เพิ่มกลุ่ม
- ข้อความแทน
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้การจัดกลุ่มและยกเลิกการจัดกลุ่มรูปทรงในชุด PowerPoint โดยใช้ Aspose.Slides สำหรับ .NET—คู่มือเร็ว ครบขั้นตอน พร้อมโค้ด C# ฟรี."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับกลุ่มรูปทรงใน Aspose.Slides แสดงวิธีการเพิ่มกลุ่มรูปทรงลงในสไลด์ ใส่รูปทรงภายในกลุ่ม และบันทึกการนำเสนอที่อัปเดต รวมถึงการเข้าถึงรูปทรงที่จัดเก็บในกลุ่มและอ่านค่าของ `AlternativeText` นอกจากนี้บทความยังครอบคลุมความสามารถที่เกี่ยวข้องกับกลุ่มรูปทรง เช่น การซ้อนกลุ่ม, การจัดลำดับ z-order, และตัวเลือกการล็อก

## **เพิ่มกลุ่มรูปทรง**
Aspose.Slides รองรับการทำงานกับกลุ่มรูปทรงบนสไลด์ ฟีเจอร์นี้ช่วยให้นักพัฒนาสร้างการนำเสนอที่มีความหลากหลายมากขึ้น Aspose.Slides for .NET รองรับการเพิ่มหรือเข้าถึงกลุ่มรูปทรง สามารถเพิ่มรูปทรงลงในกลุ่มรูปทรงที่สร้างขึ้นเพื่อเติมข้อมูลหรือเข้าถึงคุณสมบัติต่าง ๆ ของกลุ่มรูปทรงได้ เพื่อเพิ่มกลุ่มรูปทรงลงในสไลด์โดยใช้ Aspose.Slides for .NET:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
1. เพิ่มกลุ่มรูปทรงลงในสไลด์
1. เพิ่มรูปทรงลงในกลุ่มรูปทรงที่เพิ่มไว้
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างด้านล่างเพิ่มกลุ่มรูปทรงลงในสไลด์

```c#
 // สร้างอินสแตนซ์ของคลาส Presentation 
 using (Presentation pres = new Presentation())
 {
     // รับสไลด์แรก 
     ISlide sld = pres.Slides[0];
 
     // เข้าถึงคอลเลกชันรูปทรงของสไลด์ 
     IShapeCollection slideShapes = sld.Shapes;
 
     // เพิ่มกลุ่มรูปทรงลงในสไลด์ 
     IGroupShape groupShape = slideShapes.AddGroupShape();
 
     // เพิ่มรูปทรงภายในกลุ่มรูปทรงที่เพิ่มไว้ 
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
     groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);
 
     // เพิ่มกรอบของกลุ่มรูปทรง 
     groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);
 
     // เขียนไฟล์ PPTX ไปยังดิสก์ 
     pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
 }
```

## **เข้าถึงคุณสมบัติ AltText**
หัวข้อนี้แสดงขั้นตอนง่าย ๆ พร้อมตัวอย่างโค้ด สำหรับการเพิ่มกลุ่มรูปทรงและการเข้าถึงคุณสมบัติ AltText ของกลุ่มรูปทรงบนสไลด์ เพื่อเข้าถึง AltText ของกลุ่มรูปทรงในสไลด์โดยใช้ Aspose.Slides for .NET:

1. สร้างอินสแตนซ์ของคลาส `Presentation` ที่เป็นไฟล์ PPTX
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
1. เข้าถึงคอลเลกชันรูปทรงของสไลด์
1. เข้าถึงกลุ่มรูปทรง
1. เข้าถึงคุณสมบัติ AltText

ตัวอย่างด้านล่างเข้าถึงข้อความแทนของกลุ่มรูปทรง

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
Presentation pres = new Presentation("AltText.pptx");

// รับสไลด์แรก
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // เข้าถึงคอลเลกชันรูปทรงของสไลด์
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // เข้าถึงกลุ่มรูปทรง.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // เข้าถึงคุณสมบัติ AltText
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **คำถามที่พบบ่อย**

**รองรับการจัดกลุ่มแบบซ้อนกัน (กลุ่มภายในกลุ่ม) หรือไม่?**

Yes. [GroupShape](https://reference.aspose.com/slides/th/net/aspose.slides/groupshape/) มีคุณสมบัติ [ParentGroup](https://reference.aspose.com/slides/th/net/aspose.slides/shape/parentgroup/) ซึ่งบ่งชี้การสนับสนุนโครงสร้างแบบลำดับชั้นโดยตรง (กลุ่มหนึ่งสามารถเป็นลูกของกลุ่มอื่นได้)

**ฉันจะควบคุมลำดับ z-order ของกลุ่มสัมพันธ์กับวัตถุอื่นบนสไลด์ได้อย่างไร?**

ใช้คุณสมบัติ [ZOrderPosition](https://reference.aspose.com/slides/th/net/aspose.slides/shape/zorderposition/) ของ [GroupShape](https://reference.aspose.com/slides/th/net/aspose.slides/groupshape/) เพื่อดูตำแหน่งของมันในสแตกการแสดงผล

**ฉันสามารถป้องกันการย้าย/แก้ไข/ยกเลิกการกลุ่มได้หรือไม่?**

Yes. ส่วนล็อกของกลุ่มเปิดเผยผ่าน [GroupShapeLock](https://reference.aspose.com/slides/th/net/aspose.slides/groupshape/groupshapelock/) ซึ่งทำให้คุณสามารถจำกัดการดำเนินการบนอ็อบเจกต์ได้