---
title: จัดการ SmartArt ในการนำเสนอ PowerPoint ด้วย .NET
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/net/manage-smartart/
keywords:
- SmartArt
- ข้อความ SmartArt
- ประเภทการจัดวาง
- คุณสมบัติซ่อน
- แผนผังองค์กร
- แผนผังองค์กรแบบรูปภาพ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้การสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides สำหรับ .NET โดยใช้ตัวอย่างโค้ด C# ที่ชัดเจนซึ่งช่วยเร่งการออกแบบสไลด์และการทำงานอัตโนมัติ"
---
## **ภาพรวม**

SmartArt คือแผนภูมิ PowerPoint ที่สร้างจากโหนด, รูปร่างของโหนด, และการจัดวาง. ด้วย Aspose.Slides for .NET, คุณสามารถสร้าง SmartArt, อ่านข้อความจากโหนดของมัน, เปลี่ยนการจัดวาง, ตรวจสอบโหนดที่ซ่อนอยู่, กำหนดค่าการจัดวางแผนผังองค์กร, และสร้างแผนผังองค์กรแบบรูปภาพ.

## **ดึงข้อความจากอ็อบเจกต์ SmartArt**

โหนด SmartArt สามารถมีรูปร่างหนึ่งหรือหลายรูป. เพื่ออ่านข้อความที่มองเห็นได้ ให้วนซ้ำผ่าน [ISmartArt.AllNodes](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/ismartart/allnodes/), จากนั้นอ่าน [ITextFrame](https://reference.aspose.com/slides/th/net/aspose.slides/itextframe/) ที่ส่งคืนโดย [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/ismartartshape/textframe/).

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **เปลี่ยนประเภทการจัดวางของอ็อบเจกต์ SmartArt**

การจัดวาง SmartArt ควบคุมวิธีการจัดเรียงและเชื่อมต่อโหนด. ตัวอย่างต่อไปนี้สร้างอ็อบเจกต์ SmartArt ด้วยค่าของ [SmartArtLayoutType](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, จากนั้นเปลี่ยนเป็นค่า `BasicProcess`, และบันทึกการนำเสนอ.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **ตรวจสอบว่าโหนด SmartArt ถูกซ่อนหรือไม่**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/ismartartnode/ishidden/) บ่งบอกว่าโหนดถูกซ่อนอยู่ในโมเดลข้อมูล SmartArt หรือไม่. โหนดที่ซ่อนอยู่สามารถอยู่ในโครงสร้างได้แม้ว่าแบบการจัดวางที่เลือกจะไม่แสดงเป็นองค์ประกอบแผนภูมิที่มองเห็นได้.

ตัวอย่างต่อไปนี้เพิ่มโหนดเข้าไปในอ็อบเจกต์ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` และตรวจสอบสถานะการซ่อนของโหนดนั้น.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **รับหรือกำหนดการจัดวางแผนผังองค์กร**

สำหรับแผนภูมิ SmartArt ที่ใช้การจัดวางแผนผังองค์กร, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) กำหนดวิธีการจัดเรียงโหนดลูกภายใต้โหนดพาเรนต์. ตัวอย่างเช่น คุณสามารถตั้งค่าให้โหนดลูกห้อยจากด้านซ้าย, ด้านขวา หรือทั้งสองด้าน, ขึ้นอยู่กับ [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/organizationchartlayouttype/) ที่เลือก.

ตัวอย่างต่อไปนี้สร้างแผนผังองค์กรและตั้งค่าการจัดวางสำหรับโหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **สร้างแผนผังองค์กรแบบรูปภาพ**

แผนผังองค์กรแบบรูปภาพคือการจัดวาง SmartArt ที่ออกแบบมาสำหรับแผนผังลำดับชั้นที่มีช่องวางรูปภาพ. ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` เมื่อเพิ่มอ็อบเจกต์ SmartArt ลงในสไลด์.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**SmartArt รองรับการสะท้อนหรือการกลับด้านสำหรับภาษาขวาไปซ้ายหรือไม่?**

ใช่. คุณสมบัติ [IsReversed](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/smartart/isreversed/) สลับทิศทางของแผนภูมิจากซ้ายไปขวาเป็นขวาไปซ้าย หรือกลับกัน เมื่อการจัดวาง SmartArt ที่เลือกสนับสนุนการกลับด้าน.

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังงานนำเสนออื่นโดยยังคงรูปแบบไว้ได้อย่างไร?**

คุณสามารถ [คัดลอกรูปร่าง SmartArt](/slides/th/net/shape-manipulations/) ด้วย [ShapeCollection.AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/shapecollection/addclone/) หรือ [คัดลอกสไลด์ทั้งหมด](/slides/th/net/clone-slides/) ที่มี SmartArt อยู่ ทั้งสองวิธีจะคงขนาด, ตำแหน่ง, และรูปแบบไว้.

**ฉันจะแสดงผล SmartArt เป็นรูปภาพเรสเตอร์สำหรับการดูตัวอย่างหรือการส่งออกเว็บได้อย่างไร?**

[เรนเดอร์สไลด์](/slides/th/net/convert-powerpoint-to-png/) หรือการนำเสนอทั้งหมดเป็น PNG หรือ JPEG. SmartArt ถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์.

**ฉันจะหาอ็อบเจกต์ SmartArt ที่เฉพาะเจาะจงบนสไลด์ได้อย่างไรหากมีหลายอ็อบเจกต์?**

กำหนดค่า [AlternativeText](https://reference.aspose.com/slides/th/net/aspose.slides/shape/alternativetext/) หรือ [Name](https://reference.aspose.com/slides/th/net/aspose.slides/shape/name/) ที่เป็นเอกลักษณ์บนรูปร่าง SmartArt, ค้นหาค่าดังกล่าวใน [Slide.Shapes](https://reference.aspose.com/slides/th/net/aspose.slides/baseslide/shapes/), จากนั้นตรวจสอบว่ารูปร่างที่ตรงกันเป็น [ISmartArt](https://reference.aspose.com/slides/th/net/aspose.slides.smartart/ismartart/).