---
title: ดึงและอัปเดตคุณสมบัติมุมมองของงานนำเสนอใน Python
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
- ซูมเริ่มต้น
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบ Aspose.Slides for Python via .NET คุณสมบัติมุมมองเพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX และ ODP — ปรับเลย์เอาต์ระดับซูมและการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองปกติประกอบด้วยพื้นที่เนื้อหา 3 ส่วน: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวข้องกับการจัดตำแหน่งของแต่ละพื้นที่เนื้อหา. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงไฟล์ได้, เพื่อให้เมื่อเปิดใหม่มุมมองอยู่ในสถานะเดียวกับที่บันทึกครั้งล่าสุด.

Property [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/normal_view_properties/) ได้ถูกเพิ่มเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของงานนำเสนอ.

คลาส [NormalViewProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/normalviewrestoredproperties/) และ enum [SplitterBarStateType](https://reference.aspose.com/slides/th/python-net/aspose.slides/splitterbarstatetype/) ได้ถูกเพิ่ม.

## **เกี่ยวกับ INormalViewProperties**

แสดงคุณสมบัติมุมมองปกติ.

Property **ShowOutlineIcons** กำหนดว่าแอปพลิเคชันควรแสดงไอคอนเมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติหรือไม่.

Property **SnapVerticalSplitter** กำหนดว่าตัวแบ่งแนวตั้งควรสแนปไปยังสถานะย่อเมื่อตัวพื้นที่ด้านข้างเล็กพอ.

Property **PreferSingleView** กำหนดว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดี่ยวเต็มหน้าต่างแทนมุมมองปกติมี 3 พื้นที่หรือไม่. หากเปิดใช้งาน, แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาเต็มหน้าต่าง.

Properties **VerticalBarState** และ **HorizontalBarState** กำหนดสถานะที่แถบตัวแบ่งแนวตั้งหรือแนวนอนควรแสดง. แถบตัวแบ่งแนวนอนจะแยกสไลด์จากพื้นที่เนื้อหาด้านล่าง, ส่วนแถบตัวแบ่งแนวตั้งจะแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** และ **SplitterBarStateType.Restored**.

Properties **RestoredLeft** และ **RestoredTop** กำหนดขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติ, เมื่อค่า **SplitterBarStateType.Restored** ถูกนำไปใช้กับ **VerticalBarState** และ **HorizontalBarState** ตามลำดับ.

## **เกี่ยวกับการคืนค่า INormalViewProperties**

กำหนดขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ RestoredTop, ความสูงเมื่อเป็นลูกของ RestoredLeft) ของมุมมองปกติ, เมื่อพื้นที่มีขนาดที่สามารถคืนค่าได้ (ไม่ย่อหรือขยาย).

Property **DimensionSize** กำหนดขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ RestoredTop, ความสูงเมื่อเป็นลูกของ RestoredLeft).

Property **AutoAdjust** กำหนดว่าพื้นที่เนื้อหาแบบด้านข้างควรปรับขนาดให้สอดคล้องกับขนาดใหม่เมื่อเปลี่ยนขนาดหน้าต่างที่บรรจุมุมมองในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีเข้าถึงคุณสมบัติ **ViewProperties.NormalViewProperties** ของงานนำเสนอ.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # คืนค่าคุณสมบัติมุมมองของงานนำเสนอ
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าค่าซูมเริ่มต้น**

Aspose.Slides for Python via .NET ตอนนี้สนับสนุนการตั้งค่าค่าซูมเริ่มต้นสำหรับงานนำเสนอเพื่อให้เมื่อเปิดงานนำเสนอแล้วซูมถูกตั้งค่าไว้แล้ว. สามารถทำได้โดยตั้งค่า [view_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/view_properties/) ของงานนำเสนอ. คุณสมบัติมุมมองสไลด์และ [notes_view_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/notes_view_properties/) สามารถตั้งค่าได้ด้วยโปรแกรม. ในหัวข้อนี้ เราจะดูตัวอย่างการตั้งค่าคุณสมบัติมุมมองของงานนำเสนอใน Aspose.Slides.

เพื่อทำการตั้งค่าคุณสมบัติมุมมอง, โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. ตั้งค่า [view properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/) ของงานนำเสนอ
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ตั้งค่าค่าซูมสำหรับมุมมองสไลด์และมุมมองโน้ต.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # ตั้งค่าคุณสมบัติมุมมองของงานนำเสนอ
    presentation.view_properties.slide_view_properties.scale = 100 # ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
    presentation.view_properties.notes_view_properties.scale = 100 # ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองบันทึกย่อ 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าระยะห่างกริด**

ใช้ [Presentation.view_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/view_properties/) เพื่อเข้าถึงการตั้งค่ามุมมองระดับงานนำเสนอทั้งหมด. Property [ViewProperties.grid_spacing](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/grid_spacing/) อ่านหรือเปลี่ยนช่วงของกริดการแก้ไขพื้นฐาน. การตั้งค่านี้ใช้กับงานนำเสนอทั้งหมด, ไม่ใช่สไลด์แต่ละอัน. ระยะห่างกริดระบุเป็นจุด, โดย 72 จุดเท่ากับหนึ่งนิ้ว. ใช้ค่าบวกตามที่เอกสาร API กำหนด.

ตัวอย่างต่อไปนี้เปิด `demo.pptx` ที่มีอยู่, พิมพ์ระยะห่างกริดปัจจุบัน, ตั้งค่าช่วงสี่ส่วนหนึ่งของนิ้ว, และบันทึกผลลัพธ์.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

กริดแตกต่างจาก [drawing guides](/slides/th/python-net/drawing-guides/). ระยะห่างกริดควบคุมช่วงปกติ, ขณะที่ drawing guides เป็นเส้นแนวตั้งหรือแนวนอนที่วางตำแหน่งได้โดยอิสระ. การเพิ่ม, ย้าย, หรือ ลบ drawing guides ไม่เปลี่ยนระยะห่างกริด.

กริดและ drawing guides ทั้งสองเป็นเครื่องมือช่วยการแก้ไข. พวกมันไม่ได้ถูกเรนเดอร์เป็นเนื้อหาในสไลด์เมื่อแปลงเป็น PDF, รูปภาพ, SVG, หรือการสไลด์โชว์. การเก็บระยะห่างกริดไม่รับประกันว่าโปรแกรมแก้ไขจะแสดงกริด: การมองเห็นยังขึ้นอยู่กับการตั้งค่าของผู้ชมหรือโปรแกรมแก้ไข.

## **ถามตอบ**

**ทำไมกริดถึงไม่แสดงหลังจากเปิดงานนำเสนอใหม่?**

ไฟล์บันทึกระยะห่างกริดไว้, แต่โปรแกรมแก้ไขเป็นผู้ควบคุมว่ากริดจะแสดงหรือไม่. ตรวจสอบการตั้งค่าการมองเห็นกริดของโปรแกรมแก้ไข.

**การลบ drawing guides จะเปลี่ยนระยะห่างกริดหรือไม่?**

ไม่มี. drawing guides และระยะห่างกริดเป็นการตั้งค่าที่แยกกัน. การลบ guides จะไม่เปลี่ยนช่วงกริดที่เก็บไว้.

**ฉันสามารถตั้งค่าการมองเห็นต่าง ๆ สำหรับส่วนต่าง ๆ ของงานนำเสนอได้หรือไม่?**

[View settings](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/view_properties/) ถูกกำหนดในระดับงานนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/slide_view_properties/)), ไม่ได้ตามส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะมุมมองต่าง ๆ สำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**

ไม่ได้. การตั้งค่าถูกเก็บในไฟล์และใช้ร่วมกัน. แอปพลิเคชันผู้ชมอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถสร้างเทมเพลตที่มี View Properties ที่กำหนดไว้ล่วงหน้าเพื่อให้งานนำเสนอใหม่เปิดในลักษณะเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/view_properties/) ถูกเก็บในระดับงานนำเสนอ, คุณสามารถฝังลงในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นโดยใช้การกำหนดมุมมองเริ่มต้นเดียวกัน.