---
title: ดึงและอัปเดตคุณสมบัติวิวของการนำเสนอใน .NET
linktitle: คุณสมบัติวิว
type: docs
weight: 80
url: /th/net/presentation-view-properties/
keywords:
- คุณสมบัติวิว
- มุมมองปกติ
- เนื้อหาเค้าโครง
- ไอคอนเค้าโครง
- สแนปตัวแบ่งแนวตั้ง
- มุมมองเดียว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- ซูมเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้ Aspose.Slides สำหรับ .NET เพื่อกำหนดค่าเค้าโครงมุมมองปกติ การซูมสไลด์และบันทึก ระยะห่างกริด และการแสดงความเห็นในงานนำเสนอ PowerPoint"
---
## **บทนำ**

ในมุมมองปกติของ PowerPoint สไลด์จะแสดงระหว่างแถบด้านข้างสำหรับภาพย่อหรือเค้าโครงและแถบบันทึกด้านล่าง Aspose.Slides for .NET เปิดเผยการตั้งค่าการแก้ไขที่บันทึกของการนำเสนอผ่าน [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). รวมถึงการจัดเรียงแถบ ระดับการซูม ระยะห่างของกริด และการแสดงความคิดเห็น

## **เกี่ยวกับ INormalViewProperties**

ใช้ [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) เพื่อเข้าถึงอินเทอร์เฟซ [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/). [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) ควบคุมว่าจะมีไอคอนปรากฏข้างชื่อสไลด์ในเค้าโครงหรือไม่. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) ทำให้แถบด้านข้างสแนปไปยังสถานะที่ย่อลงเมื่อผู้ใช้ลดขนาดมัน. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) บ่งบอกการตั้งค่าเพื่อแสดงแถบเดียวในหน้าต่างเต็ม

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) ควบคุมตัวแบ่งระหว่างแถบด้านข้างและสไลด์. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) ควบคุมตัวแบ่งเหนือแถบบันทึก. ทั้งสองรับค่า [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) ที่เป็น `Minimized`, `Maximized`, หรือ `Restored`.

## **เกี่ยวกับการกู้คืน INormalViewProperties**

เมื่อมีการกู้คืนตัวแบ่ง [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) จะให้ขนาดที่บันทึกของแถบด้านข้างและ [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) จะให้ขนาดที่บันทึกของพื้นที่สไลด์ด้านบน. ทั้งสองเปิดเผย [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). คุณสมบัติ [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) รับเปอร์เซ็นต์ตั้งแต่ 0 ถึง 100, และ [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) ควบคุมว่าตัวแก้ไขจะปรับขนาดเมื่อหน้าต่างถูกปรับขนาดหรือไม่

ตัวอย่างนี้อัปเดตการนำเสนอที่มีอยู่ โดยกู้คืนตัวแบ่งแนวนอน ตั้งค่า [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) เป็น 80% พร้อมเปิดการปรับอัตโนมัติ และขยายตัวแบ่งแนวตั้งให้เต็ม นอกจากนี้ยังเปิดใช้งาน [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) สำหรับมุมมองเค้าโครง

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าค่าการซูมเริ่มต้น**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) และ [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) เก็บการตั้งค่าการซูมที่แยกกันสำหรับตัวแก้ไข การตั้งค่าเหล่านี้ไม่กระทบต่อมิติของสไลด์ การเล่นสไลด์โชว์ หรือความละเอียดการส่งออกภาพ

ตัวอย่างนี้เปิดการนำเสนอที่มีอยู่และเปิด [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) เพื่อให้สไลด์พอดีกับหน้าต่างการแก้ไข สำหรับหน้าบันทึก จะปิดการปรับขนาดอัตโนมัติและตั้งค่า [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) เป็นการซูมคงที่ 80%

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าระยะห่างกริด**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) กำหนดระยะห่างระหว่างเส้นกริดการแก้ไขทั่วทั้งการนำเสนอ ค่าที่รับเป็นจำนวนบวกในหน่วยจุด โดยมี 72 จุดต่อหนึ่งนิ้ว ตัวอย่างนี้พิมพ์ระยะห่างปัจจุบันในการนำเสนอที่มีอยู่และบันทึกกริดความกว้างหนึ่งในสี่นิ้วโดยตั้งช่วงเป็น 18 จุด

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

กริดจะทำซ้ำที่ช่วงคงที่ [แนวทางการวาด](/slides/th/net/drawing-guides/) ทำเครื่องหมายตำแหน่งแนวนอนหรือแนวตั้งแต่ละจุด ทั้งสองเป็นเครื่องมือช่วยการแก้ไขและปรากฏเฉพาะในตัวแก้ไขที่แสดงมัน การแสดงสไลด์และการส่งออกเป็น PDF, ภาพ หรือ SVG จะละเว้นมัน

## **แสดงหรือซ่อนความคิดเห็นเมื่อตอนเปิดการนำเสนอ**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) เก็บค่าการตั้งค่าที่ตัวแก้ไขที่รองรับจะใช้เมื่อเปิดการนำเสนอ สำหรับการนำเสนอที่มีความคิดเห็น ตัวอย่างนี้พิมพ์การตั้งค่าปัจจุบันและบันทึกสำเนาที่ซ่อนความคิดเห็น นอกจากนี้ยังตั้งค่า [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) เป็น [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) เพื่อให้สำเนาเปิดในมุมมองสไลด์

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

การซ่อนความคิดเห็นจะคงรักษาข้อความ, ผู้เขียน, ตำแหน่ง, การตอบกลับ, และสถานะของมันไว้ หากต้องการเปลี่ยนแปลงความคิดเห็นเอง ดูที่ [ความคิดเห็นของการนำเสนอ](/slides/th/net/presentation-comments/). การตั้งค่าการส่งออกจะกำหนดว่าความคิดเห็นจะปรากฏใน PDF, HTML, ภาพ, บันทึก, หรือเอกสารสรุปหรือไม่

## **คำถามที่พบบ่อย**

**เหตุใดกริดถึงหายไปเมื่อฉันเปิดการนำเสนอใหม่?**  
การนำเสนอเก็บช่วงกริดไว้ เพื่อให้เห็นกริดให้เปิดการแสดงกริดในตัวแก้ไข

**การลบแนวทางการวาดทำให้ระยะห่างของกริดเปลี่ยนหรือไม่?**  
ไม่. การเพิ่ม, ย้าย หรือ ลบแนวทางไม่ทำให้ช่วงกริดเปลี่ยน

**ส่วนต่าง ๆ ของการนำเสนอสามารถมีการตั้งค่ามุมมองที่แตกต่างกันได้หรือไม่?**  
ไม่. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) ใช้กับการนำเสนอทั้งหมด

**ฉันสามารถบันทึกการตั้งค่ามุมมองที่แตกต่างสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**  
ไฟล์เก็บชุดการตั้งค่ามุมมองเดียวสำหรับทุกคน ตัวแก้ไขอาจนำการตั้งค่าท้องถิ่นของผู้ใช้ไปใช้เพิ่มเติม

**ฉันสามารถบันทึกการตั้งค่ามุมมองในแม่แบบได้หรือไม่?**  
ได้. การนำเสนอที่สร้างจากแม่แบบจะสืบทอดการตั้งค่ามุมมองที่บันทึกไว้