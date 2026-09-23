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
- บังคับแยกแนวตั้ง
- มุมมองเดี่ยว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- ซูมเริ่มต้น
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX, และ ODP — ปรับการจัดวาง, ระดับการซูม, และการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองปกติประกอบด้วยพื้นที่เนื้อหา 3 ส่วน: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวกับการจัดตำแหน่งของพื้นที่เนื้อหาต่างๆ นี้ช่วยให้แอปพลิเคชันบันทึกสถานะมุมมองลงในไฟล์, เพื่อให้เมื่อเปิดใหม่มุมมองอยู่ในสถานะเดียวกับที่บันทึกครั้งล่าสุด.

คุณสมบัติ [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/normal_view_properties/) ได้ถูกเพิ่มเข้ามาเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของการนำเสนอ.  

คลาส [NormalViewProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/normalviewrestoredproperties/) และคลาสที่สืบทอดจากมัน, enum [SplitterBarStateType](https://reference.aspose.com/slides/th/python-net/aspose.slides/splitterbarstatetype/) ได้ถูกเพิ่มเข้ามา.

## **เกี่ยวกับ INormalViewProperties**

แสดงคุณสมบัติมุมมองปกติ.

คุณสมบัติ **ShowOutlineIcons** ระบุว่าปฏิบัติการควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาแบบโครงร่างในพื้นที่ใดๆ ของโหมดมุมมองปกติ.

คุณสมบัติ **SnapVerticalSplitter** ระบุว่าตัวแบ่งแนวตั้งควรบังคับให้อยู่ในสถานะย่อเมื่อพื้นที่ด้านข้างเล็กพอ.

คุณสมบัติ **PreferSingleView** ระบุว่าผู้ใช้ต้องการมองพื้นที่เนื้อหาแบบเต็มหน้าต่างเดียวแทนมุมมองปกติที่มี 3 พื้นที่หรือไม่. หากเปิดใช้งาน, แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาเต็มหน้าต่าง.

คุณสมบัติ **VerticalBarState** และ **HorizontalBarState** ระบุสถานะที่แถบแบ่งแนวตั้งหรือแนวนอนควรแสดง. แถบแบ่งแนวนอนแยกสไลด์จากพื้นที่เนื้อหาด้านล่าง, ส่วนแถบแบ่งแนวตั้งแยกสไลด์จากพื้นที่ด้านข้าง. ค่าที่เป็นไปได้คือ **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** และ **SplitterBarStateType.Restored**.

คุณสมบัติ **RestoredLeft** และ **RestoredTop** ระบุขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติ, เมื่อค่าของ **VerticalBarState** หรือ **HorizontalBarState** ตั้งเป็น **SplitterBarStateType.Restored**.

## **เกี่ยวกับการคืนค่า INormalViewProperties**

ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ RestoredTop, ความสูงเมื่อเป็นลูกของ RestoredLeft) ของมุมมองปกติ, เมื่อพื้นที่อยู่ในขนาดที่ฟื้นฟูได้ (ไม่ย่อและไม่ขยาย).

คุณสมบัติ **DimensionSize** ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

คุณสมบัติ **AutoAdjust** ระบุว่าพื้นที่เนื้อหาด้านข้างควรปรับตามขนาดใหม่เมื่อเปลี่ยนขนาดหน้าต่างที่แสดงมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างต่อไปนี้แสดงวิธีเข้าถึงคุณสมบัติ **ViewProperties.NormalViewProperties** ของการนำเสนอ.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # เรียกคืนคุณสมบัติมุมมองของการนำเสนอ
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าค่าการซูมเริ่มต้น**

Aspose.Slides for Python via .NET ขณะนี้รองรับการตั้งค่าค่าการซูมเริ่มต้นสำหรับการนำเสนอเพื่อให้เมื่อเปิดการนำเสนอแล้วค่า Zoom ถูกตั้งไว้แล้ว. สามารถทำได้โดยตั้งค่า [view_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/view_properties/) ของการนำเสนอ. คุณสมบัติ Slide View Properties รวมถึง [notes_view_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/notes_view_properties/) สามารถตั้งค่าโปรแกรมmatically. ในหัวข้อนี้ เราจะดูตัวอย่างการตั้งค่าคุณสมบัติมุมมองของ Presentation ใน Aspose.Slides.

เพื่อทำการตั้งค่าคุณสมบัติมุมมอง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. ตั้งค่า [view properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/) ของการนำเสนอ
1. บันทึกการนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ตั้งค่าค่าการซูมสำหรับ slide view และ notes view.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # ตั้งค่าคุณสมบัติมุมมองของการนำเสนอ
    presentation.view_properties.slide_view_properties.scale = 100 # ค่าการซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.view_properties.notes_view_properties.scale = 100 # ค่าการซูมเป็นเปอร์เซ็นต์สำหรับมุมมองโน๊ต

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าการเว้นระยะกริด**

ใช้ [Presentation.view_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/view_properties/) เพื่อเข้าถึงการตั้งค่ามุมมองระดับการนำเสนอทั้งหมด. คุณสมบัติ [ViewProperties.grid_spacing](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/grid_spacing/) จะอ่านหรือเปลี่ยนช่วงของกริดการแก้ไขพื้นฐาน. การตั้งค่านี้ใช้กับการนำเสนอทั้งหมด, ไม่ใช่กับสไลด์เดี่ยว. ระยะกริดระบุเป็นจุด, โดย 72 จุดเท่ากับหนึ่งนิ้ว. ใช้ค่าเป็นจำนวนบวกตามที่เอกสาร API ระบุ.

ตัวอย่างต่อไปนี้เปิดไฟล์ `demo.pptx` ที่มีอยู่, พิมพ์ค่าการเว้นระยะกริดปัจจุบัน, ตั้งค่าช่วงเป็นหนึ่งในสี่นิ้ว, แล้วบันทึกผลลัพธ์.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

กริดแตกต่างจาก [drawing guides](/slides/th/python-net/drawing-guides/). การเว้นระยะกริดควบคุมช่วงแบบสม่ำเสมอ, ในขณะที่ drawing guides เป็นเส้นแนวนอนหรือแนวตั้งที่วางตำแหน่งได้ตามต้องการ. การเพิ่ม, ย้าย, หรือเคลียร์ drawing guides ไม่ส่งผลต่อการเว้นระยะกริด.

ทั้งกริดและ drawing guides เป็นเครื่องมือช่วยการแก้ไข. พวกมันไม่ได้แสดงเป็นเนื้อหาสไลด์ใน PDF, รูปภาพ, SVG, หรือการแสดงสไลด์โชว์. การบันทึกค่าการเว้นระยะกริดไม่รับประกันว่าโปรแกรมแก้ไขจะแสดงกริด; ความมองเห็นของกริดยังขึ้นอยู่กับการตั้งค่าของผู้ชมหรือโปรแกรมแก้ไขด้วย.

## **แสดงหรือซ่อนความคิดเห็นเมื่อเปิดการนำเสนอ**

ใช้ [Presentation.view_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/view_properties/) เพื่อเข้าถึงการตั้งค่ามุมมองระดับการนำเสนอทั้งหมด. อ่านหรือเปลี่ยนค่า [ViewProperties.show_comments](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/show_comments/) เพื่อเก็บความตั้งใจว่าควรแสดงความคิดเห็นเมื่อการนำเสนอเปิดใน PowerPoint หรือโปรแกรมแก้ไขที่เข้ากันได้หรือไม่.

การตั้งค่านี้ควบคุมเพียงความตั้งใจของมุมมองที่บันทึกไว้. มันไม่ได้เพิ่ม, ลบ, แก้ไข, หรือแก้ไขความเห็น. การซ่อนความคิดเห็นจะคงเนื้อหา, ผู้เขียน, ตำแหน่ง, การตอบกลับ, และสถานะไว้. ดู [Presentation Comments](/slides/th/python-net/presentation-comments/) สำหรับการดำเนินการที่เปลี่ยนแปลงความคิดเห็นเอง.

ตัวอย่างต่อไปนี้ต้องใช้ไฟล์ `comments.pptx` ที่มีความคิดเห็นอยู่แล้ว. มันจะพิมพ์การตั้งค่าการมองเห็นปัจจุบัน, ขอให้ซ่อนความคิดเห็น, แล้วบันทึก PPTX ใหม่โดยไม่ลบความคิดเห็นใดๆ. นอกจากนี้ยังตั้งค่า [ViewProperties.last_view](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/last_view/) เป็น [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewtype/) เพื่อกำหนดมุมมองการแก้ไขเริ่มต้นพร้อมกับการมองเห็นความคิดเห็น.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

การตั้งค่านี้ไม่ได้กำหนดว่าความคิดเห็นจะรวมอยู่ในไฟล์ PDF, HTML, รูปภาพ, โน้ต, หรือเอกสารแจกจ่ายหรือไม่. คอนฟิกตัวเลือกการส่งออกเฉพาะแต่ละประเภทแยกต่างหาก.

## **คำถามที่พบบ่อย**

**ทำไมกริดไม่แสดงหลังจากเปิดการนำเสนอใหม่?**  
ไฟล์บันทึกค่าการเว้นระยะกริดไว้, แต่โปรแกรมแก้ไขเป็นผู้ควบคุมว่ากริดจะแสดงหรือไม่. ตรวจสอบการตั้งค่าการมองเห็นกริดของโปรแกรมแก้ไข.

**การล้าง drawing guides จะเปลี่ยนค่าการเว้นระยะกริดหรือไม่?**  
ไม่. drawing guides และการเว้นระยะกริดเป็นการตั้งค่าอิสระกัน. การล้าง guides ไม่กระทบช่วงกริดที่บันทึกไว้.

**ฉันสามารถตั้งค่ามุมมองที่แตกต่างสำหรับส่วนต่างๆ ของการนำเสนอได้หรือไม่?**  
[View settings](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/view_properties/) ถูกกำหนดระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/slide_view_properties/)), ไม่ได้กำหนดตามส่วน, ดังนั้นชุดพารามิเตอร์เดียวใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะมุมมองที่ต่างกันสำหรับผู้ใช้ต่างๆ ได้หรือไม่?**  
ไม่ได้. การตั้งค่าถูกเก็บในไฟล์และแชร์กัน. แอปพลิเคชันอาจเคารพความตั้งใจของผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียวเท่านั้น.

**ฉันสามารถสร้างเทมเพลตพร้อมคุณสมบัติมุมมองที่กำหนดล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดในลักษณะเดียวกันได้หรือไม่?**  
ได้. เพราะ [view properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/view_properties/) ถูกเก็บระดับการนำเสนอ, คุณสามารถฝังมันในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นพร้อมการกำหนดค่ามุมมองเริ่มต้นเดียวกัน.