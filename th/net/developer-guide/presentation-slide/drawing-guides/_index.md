---
title: จัดการ Drawing Guides ในงานนำเสนอใน .NET
linktitle: คู่มือการวาด
type: docs
weight: 85
url: /th/net/drawing-guides/
keywords:
- คู่มือการวาด
- คู่มือแนวนอน
- คู่มือแนวตั้ง
- คู่มือจัดตำแหน่ง
- มุมมองสไลด์
- มาสเตอร์สไลด์
- สไลด์เลเอาต์
- โน้ตมาสเตอร์
- มาสเตอร์เอกสารแจก
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เพิ่ม, เข้าถึง, และลบคู่มือการวาดแนวนอนและแนวตั้งในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for .NET."
---
## **ภาพรวม**

Guides การวาดเป็นเส้นแนวนอนและแนวตั้งที่ปรับได้ซึ่งช่วยให้ผู้ใช้จัดตำแหน่งรูปร่างได้อย่างสม่ำเสมอขณะแก้ไขงานนำเสนอใน PowerPoint พวกมันมีประโยชน์อย่างยิ่งเมื่อแอปพลิเคชันสร้างงานนำเสนอที่ต่อมาจะต้องปรับปรุงด้วยตนเอง: แอปพลิเคชันสามารถบันทึกเครื่องมือจัดตำแหน่งเดียวกันที่ผู้เขียนควรปฏิบัติตามเมื่อเพิ่มหรือย้ายเนื้อหา

Guides การวาดเป็นเครื่องมือช่วยการแก้ไข ไม่ใช่เนื้อหาในสไลด์ พวกมันจะไม่ปรากฏในการแสดงสไลด์หรือผลลัพธ์ที่เรนเดอร์ Aspose.Slides for .NET เปิดเผยพวกมันผ่านอินเตอร์เฟส [IDrawingGuidesCollection](https://reference.aspose.com/slides/th/net/aspose.slides/idrawingguidescollection/) A guide ถูกแทนด้วย [IDrawingGuide](https://reference.aspose.com/slides/th/net/aspose.slides/idrawingguide/) และมีการกำหนด orientation, position, และ color

ตำแหน่งจะวัดเป็น point จากมุมบนซ้ายของสไลด์หรือมาสเตอร์ที่เกี่ยวข้อง Guides แนวตั้งใช้ค่าแนวนอนโดยทั่วไปอยู่ระหว่างศูนย์ถึงความกว้างของสไลด์ Guides แนวนอนใช้ค่าแนวตั้งโดยทั่วไปอยู่ระหว่างศูนย์ถึงความสูงของสไลด์

## **เพิ่ม Guides ไปยังมุมมองสไลด์**

ใช้ [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/th/net/aspose.slides/icommonslideviewproperties/drawingguides/) เพื่อจัดการ Guides ที่แสดงขณะแก้ไขสไลด์ปกติ เรียกใช้ [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/th/net/aspose.slides/idrawingguidescollection/add/) พร้อมค่า [Orientation](https://reference.aspose.com/slides/th/net/aspose.slides/orientation/) และตำแหน่งเป็น point

ตัวอย่างต่อไปนี้เพิ่ม Guides แนวตั้งหนึ่งเส้นทางขวาของศูนย์สไลด์และ Guides แนวนอนหนึ่งเส้นด้านล่าง:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **เข้าถึง Drawing Guides**

คุณสมบัติ [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/th/net/aspose.slides/idrawingguidescollection/count/) และ indexer ให้เข้าถึง Guides ที่มีอยู่ คุณสมบัติ [IDrawingGuide.Orientation](https://reference.aspose.com/slides/th/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/th/net/aspose.slides/idrawingguide/position/), และ [IDrawingGuide.Color](https://reference.aspose.com/slides/th/net/aspose.slides/idrawingguide/color/) สามารถอ่านหรือเปลี่ยนค่าได้

ตัวอย่างต่อไปนี้อ่าน Guides ของมุมมองสไลด์จากงานนำเสนอที่สร้างข้างต้น:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **เพิ่ม Guides ไปยัง Master และ Layout Slides**

มาสเตอร์สไลด์และสไลด์ Layout แต่ละอันสามารถมีคอลเลกชัน Drawing Guides ของตนเอง ใช้ [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/drawingguides/) สำหรับมาสเตอร์สไลด์และ [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/drawingguides/) สำหรับสไลด์ Layout

ตัวอย่างต่อไปนี้เพิ่ม Guides แนวตั้งหนึ่งเส้นไปยังมาสเตอร์สไลด์แรกและ Guides แนวนอนหนึ่งเส้นไปยัง Layout สไลด์แรก:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **เพิ่ม Guides ไปยัง Notes และ Handout Masters**

Notes Masters และ Handout Masters รองรับ Drawing Guides ใช้ [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/th/net/aspose.slides/imasternotesslide/drawingguides/) และ [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/th/net/aspose.slides/imasterhandoutslide/drawingguides/) เพื่อเข้าถึงคอลเลกชันของพวกมัน หากงานนำเสนอไม่มีมาสเตอร์เหล่านี้ใด ๆ [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/th/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) หรือ [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/th/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) จะสร้างมาสเตอร์เริ่มต้นและคืนค่าให้

ตัวอย่างต่อไปนี้เพิ่ม Guides แนวนอนหนึ่งเส้นไปยัง Notes Master และ Guides แนวตั้งหนึ่งเส้นไปยัง Handout Master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **ลบ Drawing Guides**

เรียกใช้ [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/th/net/aspose.slides/idrawingguidescollection/clear/) เพื่อเอา Guides ทุกเส้นออกจากคอลเลกชันที่กำหนด การลบคอลเลกชันหนึ่งจะไม่ส่งผลต่อ Guides ที่เก็บไว้ในขอบเขตอื่น

ตัวอย่างต่อไปนี้ลบ Guides ของมุมมองสไลด์และ Guides ทั้งหมดบนมาสเตอร์สไลด์, Layout Slides, Notes Master, และ Handout Master โดยไม่สร้างมาสเตอร์ที่หายไป:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Drawing Guides ปรากฏในการแสดงสไลด์หรือภาพที่ส่งออกหรือไม่?**

ไม่ Guides การวาดเป็นเครื่องมือช่วยจัดตำแหน่งสำหรับการแก้ไขและไม่ถูกเรนเดอร์เป็นเนื้อหาในงานนำเสนอ

**สามารถเพิ่ม Drawing Guide ลงในสไลด์ปกติแต่ละสไลด์โดยตรงได้หรือไม่?**

Guides การแก้ไขสไลด์ปกติจะถูกเก็บในคุณสมบัติการมองเห็นสไลด์ของงานนำเสนอ คอลเลกชัน Guides แยกต่างหากพร้อมให้ใช้สำหรับมาสเตอร์สไลด์, Layout Slides, Notes Masters, และ Handout Masters

**หน่วยใดใช้สำหรับตำแหน่งของ Guide?**

ตำแหน่งระบุเป็น point โดยที่ 72 point เท่ากับหนึ่งนิ้ว ตำแหน่งแนวตั้งวัดจากขอบซ้ายและตำแหน่งแนวนอนวัดจากขอบบน

**การลบ Drawing Guides จะลบรูปร่างหรือเปลี่ยนเนื้อหาในสไลด์หรือไม่?**

ไม่ วิธี `Clear` จะลบเฉพาะ Guides ในคอลเลกชันที่เลือก รูปร่างและเนื้อหาอื่น ๆ ของสไลด์จะคงอยู่โดยไม่เปลี่ยนแปลง