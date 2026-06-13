---
title: ดึงและอัปเดตคุณสมบัติมุมมองการนำเสนอใน Python
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/python-net/presentation-view-properties/
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
- การนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides for Python via .NET เพื่อปรับแต่งรูปแบบ PPT, PPTX และ ODP—ปรับการจัดเรียง, ระดับการซูม และการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองปกติประกอบด้วยสามพื้นที่เนื้อหา: สไลด์เอง, พื้นที่เนื้อหาแบบด้านข้าง, และพื้นที่เนื้อหาแบบด้านล่าง. คุณสมบัติเกี่ยวกับการจัดตำแหน่งของพื้นที่เนื้อหาต่าง ๆ ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงในไฟล์ได้ ดังนั้นเมื่อเปิดใหม่มุมมองจะอยู่ในสถานะเดียวกันกับเมื่อการนำเสนอถูกบันทึกล่าสุด.

คุณสมบัติ [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/normal_view_properties/) ถูกเพิ่มเข้ามาเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของการนำเสนอ.  

คลาส [NormalViewProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/normalviewrestoredproperties/) และคลาสลูกของมัน, และ enum [SplitterBarStateType](https://reference.aspose.com/slides/th/python-net/aspose.slides/splitterbarstatetype/) ได้ถูกเพิ่มเข้ามา.

## **เกี่ยวกับ INormalViewProperties**

แสดงคุณสมบัติมุมมองปกติ.

คุณสมบัติ **ShowOutlineIcons** ระบุว่าจะให้แอปพลิเคชันแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติ.

คุณสมบัติ **SnapVerticalSplitter** ระบุว่าจะให้ตัวแบ่งแนวตั้งสแนปไปยังสถานะย่อเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอหรือไม่.

คุณสมบัติ **PreferSingleView** ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาแบบเต็มหน้าต่างหนึ่งส่วนแทนมุมมองปกติมาตรฐานที่มีสามพื้นที่หรือไม่ หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาในทั้งหน้าต่าง.

คุณสมบัติ **VerticalBarState** และ **HorizontalBarState** ระบุสถานะที่แถบแบ่งแนวนอนหรือแนวตั้งควรแสดง แถบแบ่งแนวนอนแยกสไลด์จากพื้นที่เนื้อหาที่อยู่ด้านล่างสไลด์, แถบแบ่งแนวตั้งแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง ค่าที่เป็นไปได้คือ: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** และ **SplitterBarStateType.Restored**.

คุณสมบัติ **RestoredLeft** และ **RestoredTop** ระบุขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติ เมื่อค่าของ **SplitterBarStateType.Restored** ถูกนำไปใช้กับ **VerticalBarState** และ **HorizontalBarState** ตามลำดับ.

## **เกี่ยวกับการคืนค่า INormalViewProperties**

ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ RestoredTop, ความสูงเมื่อเป็นลูกของ RestoredLeft) ของมุมมองปกติเมื่อพื้นที่มีขนาดที่คืนค่าได้แบบแปรผัน (ไม่ย่อและไม่ขยาย).

คุณสมบัติ **DimensionSize** ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

คุณสมบัติ **AutoAdjust** ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับตามขนาดใหม่เมื่อปรับขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงคุณสมบัติ **ViewProperties.NormalViewProperties** ของการนำเสนอ.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # คืนค่าคุณสมบัติมุมมองของการนำเสนอ
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการซูมเริ่มต้น**

Aspose.Slides for Python via .NET ตอนนี้สนับสนุนการตั้งค่าการซูมเริ่มต้นสำหรับการนำเสนอ เพื่อให้เมื่อเปิดการนำเสนอ การซูมจะตั้งค่าไว้แล้ว สามารถทำได้โดยการตั้งค่า [view_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/view_properties/) ของการนำเสนอ คุณสมบัติการดูสไลด์และ [notes_view_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/notes_view_properties/) สามารถตั้งค่าได้โดยโปรแกรม ในหัวข้อนี้ เราจะดูตัวอย่างวิธีตั้งค่าคุณสมบัติมุมมองของการนำเสนอใน Aspose.Slides.

เพื่อกำหนดคุณสมบัติมุมมอง กรุณาตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. ตั้งค่า [view properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/) ของการนำเสนอ
1. บันทึกการนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ตั้งค่าการซูมสำหรับมุมมองสไลด์และมุมมองบันทึกย่อ.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # ตั้งค่าคุณสมบัติมุมมองของการนำเสนอ
    presentation.view_properties.slide_view_properties.scale = 100 # ค่าการซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.view_properties.notes_view_properties.scale = 100 # ค่าการซูมเป็นเปอร์เซ็นต์สำหรับมุมมองบันทึกย่อ 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่ามุมมองที่แตกต่างสำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?**  
[View settings](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/view_properties/) ถูกกำหนดอยู่ในระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/slide_view_properties/)) ไม่ได้ต่อส่วน ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะมุมมองที่แตกต่างสำหรับผู้ใช้คนต่างๆ ได้ล่วงหน้าหรือไม่?**  
ไม่ การตั้งค่าถูกเก็บไว้ในไฟล์และใช้ร่วมกัน แอปพลิเคชันผู้ชมอาจเคารพความต้องการของผู้ใช้ แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถเตรียมเทมเพลตพร้อมคุณสมบัติมุมมองที่กำหนดล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดในลักษณะเดียวกันได้หรือไม่?**  
ได้ เพราะ [view properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/view_properties/) ถูกเก็บไว้ระดับการนำเสนอ คุณสามารถฝังมันในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นด้วยการกำหนดค่ามุมมองเริ่มต้นเดียวกัน.