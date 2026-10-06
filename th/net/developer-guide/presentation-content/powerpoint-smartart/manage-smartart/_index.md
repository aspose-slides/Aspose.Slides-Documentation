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
- แผนผังองค์กรรูปภาพ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้การสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides สำหรับ .NET ด้วยตัวอย่างโค้ด C# ที่ชัดเจนซึ่งเร่งการออกแบบสไลด์และการทำงานอัตโนมัติ."
---
## **ภาพรวม**

SmartArt คือแผนภาพ PowerPoint ที่สร้างจากโหนด, รูปร่างของโหนด, และการจัดวาง. กับ Aspose.Slides สำหรับ .NET, คุณสามารถสร้าง SmartArt, อ่านข้อความจากโหนดของมัน, เปลี่ยนการจัดวาง, ตรวจสอบโหนดที่ซ่อน, กำหนดค่าการจัดวางแผนผังองค์กร, และสร้างแผนผังองค์กรแบบรูปภาพได้.

## **ดึงข้อความจากอ็อบเจกต์ SmartArt**

โหนด SmartArt สามารถมีรูปทรงหนึ่งหรือหลายรูปทรงได้ เพื่ออ่านข้อความจากรูปทรงของโหนด, ให้วนซ้ำผ่าน [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), จากนั้นอ่าน [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) ที่ส่งกลับโดย [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

ตัวอย่างนี้ต้องการพรีเซนเทชันที่มีสไลด์อย่างน้อยหนึ่งสไลด์และอ็อบเจกต์ SmartArt เป็นรูปทรงแรกบนสไลด์นั้น มันจะแสดงเฟรมข้อความที่มีอยู่แต่ละอันบนคอนโซล.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **เปลี่ยนประเภทการจัดวางของอ็อบเจกต์ SmartArt**

การจัดวาง SmartArt ควบคุมวิธีการจัดเรียงและเชื่อมต่อโหนด ตัวอย่างต่อไปนี้สร้างอ็อบเจกต์ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, เปลี่ยนเป็นค่า `BasicProcess`, และบันทึกพรีเซนเทชัน ตำแหน่งและขนาดที่ส่งให้ [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) จะวัดเป็นหน่วย point ตั้งค่า [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) เพื่อเปลี่ยนการจัดวาง.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **ตรวจสอบว่าโหนด SmartArt ถูกซ่อนหรือไม่**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) แสดงว่าโหนดนั้นถูกซ่อนอยู่ในโมเดลข้อมูล SmartArt หรือไม่ โหนดที่ซ่อนอยู่สามารถมีอยู่ในโครงสร้างได้แม้การจัดวางที่เลือกจะไม่แสดงเป็นองค์ประกอบแผนภาพที่มองเห็นได้.

ตัวอย่างต่อไปนี้เพิ่มโหนดลงในอ็อบเจกต์ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` และตรวจสอบสถานะการซ่อนของโหนดที่เพิ่มเข้ามา มันจะแสดงข้อความหากโหนดถูกซ่อนและบันทึกแผนภาพ.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **รับหรือกำหนดการจัดวางแผนผังองค์กร**

สำหรับแผนภาพ SmartArt ที่ใช้การจัดวางแผนผังองค์กร, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) กำหนดวิธีการจัดเรียงโหนดลูกภายใต้โหนดพาเรนต์ ตัวอย่างเช่น คุณสามารถกำหนดให้โหนดลูกแขวนจากซ้าย, ขวา หรือทั้งสองด้าน ขึ้นอยู่กับ [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) ที่เลือก.

ตัวอย่างต่อไปนี้สร้างแผนผังองค์กรและตั้งค่าการจัดวางสำหรับโหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`. ดัชนีเริ่มจากศูนย์ `0` เลือกโหนดระดับบนแรก; โหนดลูกของมันจะใช้การจัดเรียงที่เลือก พรีเซนเทชันที่แก้ไขแล้วจะถูกบันทึก.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **สร้างแผนผังองค์กรแบบรูปภาพ**

แผนผังองค์กรแบบรูปภาพคือการจัดวาง SmartArt ที่ออกแบบมาสำหรับแผนภาพลำดับขั้นที่มีตัวแทนภาพ ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` ขณะเพิ่มอ็อบเจกต์ SmartArt ลงในสไลด์ ตัวอย่างนี้บันทึกแผนภาพที่มีตัวแทนภาพ; แต่ไม่ได้ใส่ภาพลงในตัวแทน.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **แปลงแผนภาพแบบเก่าเป็นกลุ่มของรูปร่าง**

เมื่อทำให้พรีเซนเทชันที่มีอยู่เป็นสมัยใหม่, คุณอาจต้องอัปเดตแผนผังองค์กรที่สร้างขึ้นใน PowerPoint 97–2003 ด้านล่าง Aspose.Slides แสดงแผนภาพแบบเก่าเหล่านี้เป็นอ็อบเจกต์ [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/). ใช้ [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) เพื่อแปลงแผนภาพเป็นกลุ่มของรูปร่างเพื่อให้คุณสามารถแก้ไของค์ประกอบภาพแต่ละอันได้ ดู [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) สำหรับรายละเอียด.

การแปลงจะเพิ่มกลุ่มใหม่ลงในคอลเลกชันของรูปร่างโดยไม่ลบแผนภาพต้นฉบับ หลังจากการแปลงสำเร็จ, ให้ลบต้นฉบับด้วย [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) เพื่อหลีกเลี่ยงเนื้อหาที่ซ้ำซ้อน รวบรวมแผนภาพแบบเก่าเป็นอาเรย์ก่อนทำการแปลงเพื่อให้การเพิ่มและลบรูปร่างไม่ทำให้การวนซ้ำขาดตอน.

ตัวอย่างต่อไปนี้เปิดพรีเซนเทชัน, ค้นหาทุกสไลด์, แปลงแผนภาพเป็นกลุ่มของรูปร่าง, และบันทึกพรีเซนเทชันที่อัปเดตเป็น PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

พรีเซนเทชันที่บันทึกไว้จะมีกลุ่มของรูปร่างที่แก้ไขได้แทนที่แผนภาพแบบเก้าที่แปลงแล้ว โดยไม่มีแผนภาพต้นฉบับเหลืออยู่ เปิดไฟล์ PPTX ใน PowerPoint เพื่อแก้ไของค์ประกอบแต่ละอันภายในแต่ละกลุ่ม เช่น ข้อความ, การเติมสี หรือ ตำแหน่ง.

## **คำถามที่พบบ่อย**

**SmartArt รองรับการสะท้อนหรือการกลับด้านสำหรับภาษาที่อ่านจากขวาไปซ้ายหรือไม่?**

ใช่. คุณสมบัติ [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) เปลี่ยนทิศทางของแผนภาพจากซ้ายไปขวาเป็นขวาไปซ้าย หรือกลับกัน เมื่อการจัดวาง SmartArt ที่เลือกรองรับการกลับด้าน.

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังพรีเซนเทชันอื่นโดยคงรูปแบบไว้ได้อย่างไร?**

คุณสามารถ [คัดลอกรูปร่าง SmartArt](/slides/th/net/shape-manipulations/) ด้วย [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) หรือ [คัดลอกสไลด์ทั้งหมด](/slides/th/net/clone-slides/) ที่มี SmartArt ทั้งสองวิธีจะคงขนาด, ตำแหน่ง, และรูปแบบไว้.

**ฉันจะเรนเดอร์ SmartArt ให้เป็นภาพเรสเตอร์เพื่อการแสดงตัวอย่างหรือส่งออกไปเว็บอย่างไร?**

[เรนเดอร์สไลด์](/slides/th/net/convert-powerpoint-to-png/) หรือพรีเซนเทชันทั้งหมดเป็น PNG หรือ JPEG. SmartArt จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์.

**ฉันจะค้นหาอ็อบเจกต์ SmartArt เฉพาะบนสไลด์ได้อย่างไร หากมีหลายอ็อบเจกต์?**

กำหนดค่า [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) หรือ [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) ที่แตกต่างบนรูปร่าง SmartArt, ค้นหาค่านั้นใน [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), แล้วตรวจสอบว่ารูปร่างที่ตรงกันเป็น [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/).