---
title: เรียกคืนและอัปเดตคุณสมบัติมุมมองการนำเสนอใน .NET
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/net/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- ตัวแยกแนวตั้งสแนป
- มุมมองเดี่ยว
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
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides สำหรับ .NET เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX, และ ODP — ปรับแต่งเลย์เอาต์ ระดับการซูม และการตั้งค่าการแสดงผล"
---
## **บทนำ**

มุมมองปกติมีสามส่วนของเนื้อหา ได้แก่ สไลด์เอง, ส่วนเนื้อหาด้านข้าง, และส่วนเนื้อหาที่ด้านล่าง. คุณสมบัติที่เกี่ยวกับการจัดตำแหน่งของส่วนเนื้อหาต่าง ๆ นี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงในไฟล์ได้ เพื่อให้เมื่อเปิดใหม่มุมมองอยู่ในสถานะเดียวกับที่บันทึกรอบสุดท้ายของการนำเสนอ.  
คุณสมบัติ [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/iviewproperties/properties/normalviewproperties) ได้ถูกเพิ่มเพื่อให้เข้าถึงคุณสมบัติของมุมมองปกติของการนำเสนอ.  
[INormalViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/net/aspose.slides/inormalviewrestoredproperties) อินเทอร์เฟซและคลาสที่สืบทอด, รวมถึง enum [SplitterBarStateType](https://reference.aspose.com/slides/th/net/aspose.slides/splitterbarstatetype) ได้ถูกเพิ่ม.

## **เกี่ยวกับ INormalViewProperties**

แทนคุณสมบัติของมุมมองปกติ.  

คุณสมบัติ **ShowOutlineIcons** ระบุว่ารายการแอปพลิเคชันควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในส่วนใดส่วนหนึ่งของมุมมองปกติ.  

คุณสมบัติ **SnapVerticalSplitter** ระบุว่าตัวแยกแนวตั้งควรสแนปเข้าสู่สถานะย่อเมื่อส่วนด้านข้างมีขนาดเล็กพอ.  

คุณสมบัติ **PreferSingleView** ระบุว่าผู้ใช้ต้องการดูส่วนเนื้อหาเดี่ยวเต็มหน้าต่างแทนมุมมองปกติมาตรฐานที่มีสามส่วนหรือไม่ หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงส่วนเนื้อหาหนึ่งในหน้าต่างทั้งหมด.  

คุณสมบัติ **VerticalBarState** และ **HorizontalBarState** ระบุสถานะที่แถบสไลด์แนวตั้งหรือแนวนอนควรแสดง. แถบสไลด์แนวนอนจะแยกสไลด์ออกจากส่วนเนื้อหาที่อยู่ด้านล่างสไลด์, ส่วนแถบสไลด์แนวตั้งจะแยกสไลด์ออกจากส่วนเนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** และ **SplitterBarStateType.Restored**.  

คุณสมบัติ **RestoredLeft** และ **RestoredTop** ระบุขนาดของส่วนสไลด์บนหรือด้านข้างของมุมมองปกติเมื่อค่า **SplitterBarStateType.Restored** ถูกนำไปใช้กับ **VerticalBarState** และ **HorizontalBarState** ตามลำดับ.

## **เกี่ยวกับการคืนค่า INormalViewProperties** 

ระบุขนาดของส่วนสไลด์ (ความกว้างเมื่อเป็นลูกของ RestoredTop, ความสูงเมื่อเป็นลูกของ RestoredLeft) ของมุมมองปกติเมื่อส่วนนั้นมีขนาดที่กู้คืนได้แบบตัวแปร (ไม่ได้ย่อหรือขยาย).  

คุณสมบัติ **DimensionSize** ระบุขนาดของส่วนสไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).  

คุณสมบัติ **AutoAdjust** ระบุว่าขนาดของส่วนเนื้อหาด้านข้างควรปรับตามขนาดใหม่เมื่อเปลี่ยนขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.  

ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงคุณสมบัติ **ViewProperties.NormalViewProperties** ของการนำเสนอ.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // คืนค่าคุณสมบัติมุมมองของการนำเสนอ
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **ตั้งค่าค่าซูมเริ่มต้น**

Aspose.Slides for .NET ตอนนี้รองรับการตั้งค่าซูมเริ่มต้นสำหรับการนำเสนอ เพื่อให้เมื่อเปิดการนำเสนอแล้วซูมจะถูกตั้งค่าไว้แล้ว สามารถทำได้โดยกำหนด [ViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties) ของการนำเสนอ ทั้งคุณสมบัติมุมมองสไลด์และ [NotesViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/properties/notesviewproperties) สามารถตั้งค่าผ่านโปรแกรมได้ ในหัวข้อนี้เราจะดูตัวอย่างการตั้งค่าคุณสมบัติมุมมองของการนำเสนอใน Aspose.Slides.  

เพื่อกำหนดคุณสมบัติมุมมอง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)  
1. ตั้งค่า View [Properties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties) ของการนำเสนอ  
1. เขียนการนำเสนอเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง เราได้ตั้งค่าซูมสำหรับมุมมองสไลด์และมุมมองโน้ต.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // กำหนดคุณสมบัติมุมมองของการนำเสนอ
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองโน้ต 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **ตั้งค่าความห่างของกริด**

ใช้ [Presentation.ViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/viewproperties/) เพื่อเข้าถึงการตั้งค่ามุมมองระดับการนำเสนอทั้งหมด. คุณสมบัติ [IViewProperties.GridSpacing](https://reference.aspose.com/slides/th/net/aspose.slides/iviewproperties/gridspacing/) อ่านหรือเปลี่ยนช่วงของกริดการแก้ไขพื้นฐาน การตั้งค่านี้ใช้กับการนำเสนอทั้งหมด ไม่ใช่สไลด์แต่ละอัน. ความห่างของกริดระบุเป็นจุด, โดย 72 จุดเท่ากับหนึ่งนิ้ว. ใช้ค่าบวกตามที่เอกสาร API กำหนด.  

ตัวอย่างต่อไปนี้เปิดไฟล์ `demo.pptx` ที่มีอยู่แล้ว, พิมพ์ค่าความห่างของกริดปัจจุบัน, ตั้งค่าช่วงหนึ่งในสี่นิ้ว, และบันทึกผลลัพธ์.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

กริดแตกต่างจาก [drawing guides](/slides/th/net/drawing-guides/). ความห่างของกริดควบคุมช่วงปกติ, ในขณะที่ drawing guides เป็นเส้นแนวนอนหรือแนวตั้งที่วางตำแหน่งเป็นชิ้นเดียว การเพิ่ม, ย้าย, หรือล้าง drawing guides จะไม่เปลี่ยนความห่างของกริด.  

ทั้งกริดและ drawing guides เป็นเครื่องมือช่วยการแก้ไข. พวกมันไม่ได้แสดงเป็นเนื้อหาสไลด์ใน PDF, รูปภาพ, SVG หรือการแสดงสไลด์. การบันทึกความห่างของกริดไม่รับประกันว่าโปรแกรมแก้ไขจะทำการแสดงกริด: การมองเห็นยังขึ้นอยู่กับการตั้งค่าของผู้ดูหรือผู้แก้ไข.

## **แสดงหรือซ่อนความคิดเห็นเมื่อเปิดการนำเสนอ**

ใช้ [Presentation.ViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/viewproperties/) เพื่อเข้าถึงการตั้งค่ามุมมองระดับการนำเสนอ. อ่านหรือเปลี่ยนค่า [IViewProperties.ShowComments](https://reference.aspose.com/slides/th/net/aspose.slides/iviewproperties/showcomments/) เพื่อตั้งค่าตัวเลือกว่าควรแสดงความคิดเห็นเมื่อการนำเสนอเปิดใน PowerPoint หรือโปรแกรมที่เข้ากันได้อื่นหรือไม่.  

การตั้งค่านี้ควบคุมเพียงตัวเลือกมุมมองที่เก็บไว้เท่านั้น. มันไม่ได้เพิ่ม, ลบ, แก้ไข, หรือแก้ไขความคิดเห็น. การซ่อนความคิดเห็นจะรักษาเนื้อหา, ผู้เขียน, ตำแหน่ง, การตอบกลับ, และสถานะของพวกมันไว้. ดู [Presentation Comments](/slides/th/net/presentation-comments/) สำหรับการดำเนินการที่เปลี่ยนแปลงความคิดเห็นเอง.  

ตัวอย่างต่อไปนี้ต้องการไฟล์ `comments.pptx` ที่มีความคิดเห็นอยู่แล้ว. มันพิมพ์ค่าการมองเห็นปัจจุบัน, ขอให้ซ่อนความคิดเห็น, และบันทึกไฟล์ PPTX ใหม่โดยไม่ลบความคิดเห็นใด ๆ. มันยังตั้งค่า [IViewProperties.LastView](https://reference.aspose.com/slides/th/net/aspose.slides/iviewproperties/lastview/) เป็น [ViewType.SlideView](https://reference.aspose.com/slides/th/net/aspose.slides/viewtype/) เพื่อกำหนดมุมมองการแก้ไขเริ่มต้นพร้อมกับการมองเห็นความคิดเห็น.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

การตั้งค่านี้ไม่ได้กำหนดว่าความคิดเห็นจะถูกรวมในไฟล์ PDF, HTML, รูปภาพ, โน้ต, หรือเอกสารแจกหรือไม่. ให้กำหนดตัวเลือกการส่งออกที่เกี่ยวข้องแยกต่างหาก.

## **คำถามที่พบบ่อย**

**ทำไมกริดถึงไม่แสดงเมื่อฉันเปิดการนำเสนอใหม่?**  
ไฟล์จะเก็บค่าความห่างของกริดไว้, แต่โปรแกรมแก้ไขเป็นผู้ควบคุมว่ากริดจะแสดงหรือไม่. ตรวจสอบการตั้งค่าการมองเห็นกริดของโปรแกรมแก้ไข.

**การล้าง drawing guides จะทำให้ความห่างของกริดเปลี่ยนหรือไม่?**  
ไม่. Drawing guides และความห่างของกริดเป็นการตั้งค่าที่แยกจากกัน. การล้าง guides จะไม่เปลี่ยนช่วงกริดที่เก็บไว้.

**ฉันสามารถตั้งค่ามุมมองที่ต่างกันสำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?**  
[View settings](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/viewproperties/) ถูกกำหนดที่ระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/slideviewproperties/)), ไม่ได้แยกตามส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะมุมมองที่ต่างกันสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**  
ไม่. การตั้งค่าถูกเก็บในไฟล์และใช้ร่วมกัน. โปรแกรมดูอาจเคารพการตั้งค่าของผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียวเท่านั้น.

**ฉันสามารถเตรียมเทมเพลตที่มี View Properties ที่กำหนดไว้ล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดด้วยวิธีเดียวกันได้หรือไม่?**  
ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/viewproperties/) ถูกเก็บระดับการนำเสนอ, คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นโดยมีการกำหนดมุมมองเริ่มต้นเดียวกัน.