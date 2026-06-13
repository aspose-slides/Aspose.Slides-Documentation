---
title: ดึงและอัปเดตคุณสมบัติมุมมองการนำเสนอใน .NET
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/net/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- สแนปตัวแบ่งแนวตั้ง
- มุมมองเดี่ยว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- การซูมเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides for .NET เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX และ ODP — ปรับการจัดวาง, ระดับการซูม และการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองปกติมีพื้นที่เนื้อหาทั้งหมดสามส่วน: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติเกี่ยวกับตำแหน่งของแต่ละพื้นที่เนื้อหานี้ช่วยให้แอปพลิเคชันบันทึกสภาพมุมมองลงในไฟล์, เพื่อให้เมื่อเปิดใหม่มุมมองจะอยู่ในสภาพเดียวกันกับเมื่อบันทึกล่าสุด.

Property [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/iviewproperties/properties/normalviewproperties) ได้ถูกเพิ่มเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของพรีเซนเทชัน.

[INormalViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/net/aspose.slides/inormalviewrestoredproperties) interfaces และลูกของมัน, [SplitterBarStateType](https://reference.aspose.com/slides/th/net/aspose.slides/splitterbarstatetype) enum ได้ถูกเพิ่ม.

## **เกี่ยวกับ INormalViewProperties**

แสดงคุณสมบัติของมุมมองปกติ.

Property **ShowOutlineIcons** ระบุว่าแอปพลิเคชันควรแสดงไอคอนเมื่อแสดงโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติหรือไม่.

Property **SnapVerticalSplitter** ระบุว่าแถบแบ่งแนวตั้งควรสแนปไปยังสถานะย่อเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอ.

Property **PreferSingleView** ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดียวเต็มหน้าต่างแทนมุมมองปกติมาตรฐานที่มีสามพื้นที่หรือไม่. หากเปิดใช้งาน, แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาในหน้าต่างทั้งหมด.

Properties **VerticalBarState** และ **HorizontalBarState** ระบุสถานะที่แถบแบ่งแนวนอนหรือแนวตั้งควรแสดง. แถบแบ่งแนวนอนแยกสไลด์จากพื้นที่เนื้อหาที่อยู่ด้านล่างสไลด์, ส่วนแถบแบ่งแนวตั้งแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** และ **SplitterBarStateType.Restored**.

Properties **RestoredLeft** และ **RestoredTop** ระบุตัวแปรขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติ, เมื่อค่า **SplitterBarStateType.Restored** ถูกนำไปใช้กับ **VerticalBarState** และ **HorizontalBarState** ตามลำดับ.

## **เกี่ยวกับการกู้คืน INormalViewProperties**

ระบุตัวแปรขนาดของพื้นที่สไลด์ (กว้างเมื่อเป็นบุตรของ RestoredTop, สูงเมื่อเป็นบุตรของ RestoredLeft) ของมุมมองปกติ, เมื่อพื้นที่อยู่ในขนาดกู้คืนที่เปลี่ยนแปลงได้ (ไม่ย่อและไม่ขยาย).

Property **DimensionSize** ระบุขนาดของพื้นที่สไลด์ (กว้างเมื่อเป็นบุตรของ restoredTop, สูงเมื่อเป็นบุตรของ restoredLeft).

Property **AutoAdjust** ระบุว่าพื้นที่เนื้อหาด้านข้างควรปรับขนาดเพื่อชดเชยขนาดใหม่เมื่อปรับขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีเข้าถึงคุณสมบัติ **ViewProperties.NormalViewProperties** ของพรีเซนเทชัน.

```c#
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

## **ตั้งค่าค่าการซูมเริ่มต้น**

Aspose.Slides for .NET ขณะนี้รองรับการตั้งค่าค่าการซูมเริ่มต้นสำหรับพรีเซนเทชันเพื่อให้เมื่อเปิดพรีเซนเทชันแล้วการซูมจะถูกกำหนดไว้แล้ว. สามารถทำได้โดยการตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties) ของพรีเซนเทชัน. คุณสมบัติมุมมองสไลด์และ [NotesViewProperties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/properties/notesviewproperties) สามารถตั้งค่าได้โดยโปรแกรม. ในหัวข้อนี้เราจะดูตัวอย่างการตั้งค่าคุณสมบัตุมุมมองของพรีเซนเทชันใน Aspose.Slides.

ในการตั้งค่าคุณสมบัตุมุมมอง, โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)
1. ตั้งค่า View [Properties](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties) ของ Presentation
1. เขียนพรีเซนเทชันเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง, เราได้ตั้งค่าค่าการซูมสำหรับมุมมองสไลด์และมุมมองโน้ต.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // ตั้งค่าคุณสมบัติมุมมองของการนำเสนอ
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองโน้ต

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าการมองเห็นที่แตกต่างสำหรับส่วนต่าง ๆ ของพรีเซนเทชันได้หรือไม่?**

[View settings](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/viewproperties/) ถูกกำหนดระดับพรีเซนเทชัน ([Normal View](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/th/net/aspose.slides/viewproperties/slideviewproperties/)), ไม่ได้กำหนดต่อส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดล่วงหน้าสถานะมุมมองที่แตกต่างสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**

ไม่ได้. การตั้งค่าถูกเก็บในไฟล์และใช้ร่วมกัน. แอปพลิเคชันผู้ชมอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถเตรียมแม่แบบที่มี View Properties ที่กำหนดล่วงหน้าเพื่อให้พรีเซนเทชันใหม่เปิดในลักษณะเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/viewproperties/) ถูกเก็บระดับพรีเซนเทชัน, คุณจึงสามารถฝังมันในแม่แบบและสร้างเอกสารใหม่จากแม่แบบนั้นโดยมีการกำหนดค่ามุมมองเริ่มต้นเดียวกัน.