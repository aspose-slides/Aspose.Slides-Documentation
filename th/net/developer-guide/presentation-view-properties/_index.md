---
title: ดึงและอัปเดตคุณสมบัติการแสดงผลของงานนำเสนอใน .NET
linktitle: คุณสมบัติการแสดงผล
type: docs
weight: 80
url: /th/net/presentation-view-properties/
keywords:
- คุณสมบัติการแสดงผล
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- ล็อกตัวแบ่งแนวตั้ง
- มุมมองเดียว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- ซูมเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบคุณสมบัติการแสดงผลของ Aspose.Slides สำหรับ .NET เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX และ ODP — ปรับการจัดวาง ระดับการซูม และการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองปกติประกอบด้วยพื้นที่เนื้อหา 3 ส่วน: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวกับการวางตำแหน่งของแต่ละพื้นที่เนื้อหา. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะการแสดงผลลงในไฟล์ได้, เพื่อให้เมื่อเปิดใหม่มุมมองจะอยู่ในสถานะเดียวกับที่บันทึกครั้งสุดท้ายของงานนำเสนอ.

เพิ่มคุณสมบัติ [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/iviewproperties/properties/normalviewproperties) เพื่อให้เข้าถึงคุณสมบัติของมุมมองปกติของงานนำเสนอ.

เพิ่มอินเทอร์เฟซ [INormalViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/net/aspose.slides/inormalviewrestoredproperties) พร้อมกับลูกสายของมัน, และ enum [SplitterBarStateType](https://reference.aspose.com/slides/th/net/aspose.slides/splitterbarstatetype) แล้ว

## **เกี่ยวกับ INormalViewProperties**

แทนคุณสมบัติของมุมมองปกติ.

คุณสมบัติ **ShowOutlineIcons** ระบุว่าแอปพลิเคชันควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติ.

คุณสมบัติ **SnapVerticalSplitter** ระบุว่าแถบแบ่งแนวตั้งควรล็อกเป็นสถานะย่อขนาดเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอ.

คุณสมบัติ **PreferSingleView** ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดียวเต็มหน้าต่างแทนมุมมองปกติแบบมาตรฐานที่มี 3 พื้นที่หรือไม่. หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาเต็มหน้าต่าง.

คุณสมบัติ **VerticalBarState** และ **HorizontalBarState** ระบุสถานะที่แถบแบ่งแนวนอนหรือแนวตั้งควรแสดง. แถบแบ่งแนวนอนแยกสไลด์จากพื้นที่เนื้อหาด้านล่างสไลด์, ส่วนแถบแบ่งแนวตั้งแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้ได้แก่: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** และ **SplitterBarStateType.Restored**.

คุณสมบัติ **RestoredLeft** และ **RestoredTop** ระบุขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติ เมื่อค่ **SplitterBarStateType.Restored** ถูกนำไปใช้กับ **VerticalBarState** และ **HorizontalBarState** ตามลำดับ.

## **เกี่ยวกับการคืนค่า INormalViewProperties**

ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นบุตรของ RestoredTop, ความสูงเมื่อเป็นบุตรของ RestoredLeft) ของมุมมองปกติ เมื่อพื้นที่มีขนาดที่กู้คืนได้แบบเปลี่ยนแปลง (ไม่ย่อขนาดและไม่ขยายเต็ม).

คุณสมบัติ **DimensionSize** ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นบุตรของ restoredTop, ความสูงเมื่อเป็นบุตรของ restoredLeft).

คุณสมบัติ **AutoAdjust** ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับให้สอดคล้องกับขนาดใหม่เมื่อปรับขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงคุณสมบัติ **ViewProperties.NormalViewProperties** ของงานนำเสนอ.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // คืนค่าคุณสมบัติการแสดงผลของงานนำเสนอ
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **ตั้งค่าการซูมเริ่มต้น**

Aspose.Slides for .NET รองรับการตั้งค่าการซูมเริ่มต้นสำหรับงานนำเสนอแล้ว โดยเมื่อเปิดงานนำเสนอการซูมจะถูกกำหนดไว้แล้ว. สามารถทำได้โดยตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties) ของงานนำเสนอ. ทั้งคุณสมบัติการแสดงสไลด์และ [NotesViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/properties/notesviewproperties) สามารถตั้งค่าแบบโปรแกรมได้. ในหัวข้อนี้เราจะดูตัวอย่างการตั้งค่าคุณสมบัติ View ของงานนำเสนอใน Aspose.Slides.

เพื่อกำหนดค่าคุณสมบัติการมอง, โปรดทำตามขั้นตอนต่อไปนี้:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
1. ตั้งค่า View [Properties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties) ของงานนำเสนอ
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ตั้งค่าการซูมสำหรับการแสดงสไลด์และการแสดงบันทึกย่อ.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // ตั้งค่าคุณสมบัติการแสดงผลของงานนำเสนอ
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // ค่าการซูมเป็นเปอร์เซ็นต์สำหรับการแสดงสไลด์
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // ค่าการซูมเป็นเปอร์เซ็นต์สำหรับการแสดงบันทึกย่อ 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **ตั้งค่าระยะห่างของตาราง**

ใช้ [Presentation.ViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/viewproperties/) เพื่อเข้าถึงการตั้งค่าการมองของงานนำเสนอทั้งหมด. คุณสมบัติ [IViewProperties.GridSpacing](https://reference.aspose.com/slides/th/net/aspose.slides/iviewproperties/gridspacing/) อ่านหรือเปลี่ยนช่วงของตารางการแก้ไขพื้นฐาน. การตั้งค่านี้ใช้กับงานนำเสนอทั้งหมด ไม่ใช่สไลด์เดียว. ระยะห่างของตารางระบุเป็นจุด, โดย 72 จุดเท่ากับหนึ่งนิ้ว. ใช้ค่าบวกตามที่เอกสาร API ระบุ.

ตัวอย่างต่อไปนี้เปิดไฟล์ `demo.pptx` ที่มีอยู่, แสดงระยะห่างของตารางปัจจุบัน, ตั้งค่าช่วงหนึ่งในสี่นิ้ว, แล้วบันทึกผลลัพธ์.

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

ตารางแตกต่างจาก [drawing guides](/slides/th/net/drawing-guides/). การกำหนดระยะห่างของตารางควบคุมช่วงเป็นประจำ, ส่วน drawing guides เป็นเส้นจัดตำแหน่งแนวนอนหรือแนวตั้งที่กำหนดตำแหน่งแยกกัน. การเพิ่ม, ย้าย หรือเคลียร์ drawing guides ไม่ทำให้ระยะห่างของตารางเปลี่ยนแปลง.

ทั้งตารางและ drawing guides เป็นเครื่องมือช่วยการแก้ไข. พวกมันจะไม่ถูกเรนเดอร์เป็นเนื้อหาสไลด์ใน PDF, รูปภาพ, SVG หรือการแสดงสไลด์. การเก็บระยะห่างของตารางไม่ได้รับประกันว่าเครื่องมือแก้ไขจะแสดงตาราง: ความมองเห็นของมันยังขึ้นอยู่กับการตั้งค่าของผู้ชมหรือโปรแกรมแก้ไข.

## **คำถามที่พบบ่อย**

**ทำไมตารางถึงไม่แสดงเมื่อฉันเปิดงานนำเสนอใหม่?**  
ไฟล์บันทึกระยะห่างของตารางไว้, แต่เครื่องมือแก้ไขควบคุมว่าตารางจะแสดงหรือไม่. ตรวจสอบการตั้งค่าการมองเห็นตารางของโปรแกรมแก้ไข.

**การลบ drawing guides จะทำให้ระยะห่างของตารางเปลี่ยนหรือไม่?**  
ไม่. drawing guides และระยะห่างของตารางเป็นการตั้งค่าอิสระกัน. การล้าง guides จะไม่ทำให้ช่วงตารางที่เก็บไว้เปลี่ยนแปลง.

**ฉันสามารถตั้งค่าการมองที่ต่างกันสำหรับส่วนต่าง ๆ ของงานนำเสนอได้หรือไม่?**  
[View settings](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/viewproperties/) ถูกกำหนดระดับงานนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/slideviewproperties/)), ไม่ได้ต่อส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะการมองที่ต่างกันสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**  
ไม่. การตั้งค่าถูกเก็บในไฟล์และใช้ร่วมกัน. โปรแกรมดูอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีเพียงชุดเดียวของคุณสมบัติการมอง.

**ฉันสามารถเตรียมเทมเพลตที่มี View Properties ที่กำหนดล่วงหน้าเพื่อให้การเปิดงานนำเสนอใหม่เป็นแบบเดียวกันได้หรือไม่?**  
ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/viewproperties/) ถูกเก็บระดับงานนำเสนอ, คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นด้วยการกำหนดค่าการมองเริ่มต้นเดียวกัน.