---
title: จัดการแนวทางการวาดในงานนำเสนอด้วย Python
linktitle: แนวทางการวาด
type: docs
weight: 85
url: /th/python-net/drawing-guides/
keywords:
- แนวทางการวาด
- แนวทางแนวนอน
- แนวทางแนวตั้ง
- แนวทางจัดตำแหน่ง
- มุมมองสไลด์
- สไลด์มาสเตอร์
- สไลด์เลย์เอาต์
- โน้ตมาสเตอร์
- มาสเตอร์แฮนด์เอาท์
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่ม, เข้าถึง และลบแนวทางการวาดแนวนอนและแนวตั้งในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

แนวทางการวาดเป็นเส้นแนวนอนและแนวตั้งที่ปรับได้ซึ่งช่วยผู้ใช้จัดตำแหน่งรูปทรงอย่างสม่ำเสมอขณะแก้ไขงานนำเสนอใน PowerPoint. พวกมันมีประโยชน์เป็นพิเศษเมื่อแอปพลิเคชันสร้างงานนำเสนอที่ต่อมาจะถูกปรับแต่งด้วยตนเอง: แอปพลิเคชันสามารถบันทึกเครื่องมือจัดตำแหน่งเดียวกันที่ผู้เขียนควรปฏิบัติตามเมื่อเพิ่มหรือย้ายเนื้อหา.

แนวทางการวาดเป็นเครื่องมือช่วยแก้ไข ไม่ใช่เนื้อหาสไลด์. พวกมันไม่ปรากฏในการแสดงสไลด์หรือผลลัพธ์ที่เรนเดอร์. Aspose.Slides for Python via .NET เปิดเผยผ่านอินเทอร์เฟซ [IDrawingGuidesCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/idrawingguidescollection/) . แนวทางหนึ่งแสดงโดย [IDrawingGuide](https://reference.aspose.com/slides/th/python-net/aspose.slides/idrawingguide/) และมีการกำหนดทิศทาง, ตำแหน่ง, และสี.

ตำแหน่งวัดเป็นหน่วยจุดจากมุมซ้ายบนของสไลด์หรือมาสเตอร์ที่เกี่ยวข้อง. แนวทางแนวตั้งใช้พิกัดแนวนอนซึ่งโดยทั่วไปอยู่ระหว่างศูนย์ถึงความกว้างของสไลด์. แนวทางแนวนอนใช้พิกัดแนวตั้งซึ่งโดยทั่วไปอยู่ระหว่างศูนย์ถึงความสูงของสไลด์.

## **เพิ่มแนวทางการวาดในมุมมองสไลด์**

ใช้ [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/th/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) เพื่อจัดการแนวทางที่แสดงขณะแก้ไขสไลด์ทั่วไป เรียกใช้ [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/th/python-net/aspose.slides/idrawingguidescollection/add/) โดยระบุค่า [Orientation](https://reference.aspose.com/slides/th/python-net/aspose.slides/orientation/) และตำแหน่งเป็นหน่วยจุด.

ตัวอย่างต่อไปนี้เพิ่มแนวทางแนวตั้งหนึ่งเส้นทางด้านขวาของศูนย์กลางสไลด์และแนวทางแนวนอนหนึ่งเส้นด้านล่าง:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงแนวทางการวาด**

คุณสมบัติและอินเด็กซ์ [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/th/python-net/aspose.slides/idrawingguidescollection/count/) ให้เข้าถึงแนวทางที่มีอยู่. คุณสมบัติ [IDrawingGuide.orientation](https://reference.aspose.com/slides/th/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/th/python-net/aspose.slides/idrawingguide/position/), และ [IDrawingGuide.color](https://reference.aspose.com/slides/th/python-net/aspose.slides/idrawingguide/color/) สามารถอ่านหรือเปลี่ยนแปลงได้.

ตัวอย่างต่อไปนี้อ่านแนวทางในมุมมองสไลด์จากงานนำเสนอที่สร้างด้านบน:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **เพิ่มแนวทางการวาดในสไลด์มาสเตอร์และเลย์เอาต์**

มาสเตอร์สไลด์และสไลด์เลย์เอาต์ของมันแต่ละอันสามารถมีคอลเลกชันแนวทางการวาดของตนเอง. ใช้ [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/th/python-net/aspose.slides/imasterslide/drawing_guides/) สำหรับสไลด์มาสเตอร์และ [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/th/python-net/aspose.slides/ilayoutslide/drawing_guides/) สำหรับสไลด์เลย์เอาต์.

ตัวอย่างต่อไปนี้เพิ่มแนวทางแนวตั้งหนึ่งเส้นในสไลด์มาสเตอร์แรกและแนวทางแนวนอนหนึ่งเส้นในสไลด์เลย์เอาต์แรก:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มแนวทางการวาดในโน้ตและมาสเตอร์ของแฮนด์เอาท์**

มาสเตอร์ของโน้ตและมาสเตอร์ของแฮนด์เอาท์ก็รองรับแนวทางการวาดเช่นกัน. ใช้ [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/th/python-net/aspose.slides/imasternotesslide/drawing_guides/) และ [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/th/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) เพื่อเข้าถึงคอลเลกชันของพวกมัน. หากงานนำเสนอไม่มีมาสเตอร์เหล่านี้ใด ๆ [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) หรือ [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) จะสร้างมาสเตอร์เริ่มต้นและส่งคืนมัน.

ตัวอย่างต่อไปนี้เพิ่มแนวทางแนวนอนหนึ่งเส้นในโน้ตมาสเตอร์และแนวทางแนวตั้งหนึ่งเส้นในแฮนด์เอาท์มาสเตอร์:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบแนวทางการวาด**

เรียกใช้ [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/th/python-net/aspose.slides/idrawingguidescollection/clear/) เพื่อเอาแนวทางทั้งหมดออกจากคอลเลกชันที่ระบุ. การลบคอลเลกชันหนึ่งไม่ได้ส่งผลต่อแนวทางที่เก็บอยู่ในสโคปอื่น.

ตัวอย่างต่อไปนี้ลบแนวทางในมุมมองสไลด์และแนวทางทั้งหมดบนมาสเตอร์สไลด์, สไลด์เลย์เอาต์, โน้ตมาสเตอร์, และแฮนด์เอาท์มาสเตอร์โดยไม่สร้างมาสเตอร์ที่หายไป:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**แนวทางการวาดปรากฏในการแสดงสไลด์หรือภาพที่ส่งออกหรือไม่?**

ไม่. แนวทางการวาดเป็นเครื่องมือช่วยจัดตำแหน่งสำหรับการแก้ไขและไม่ถูกเรนเดอร์เป็นเนื้อหาของงานนำเสนอ.

**สามารถเพิ่มแนวทางการวาดลงในสไลด์ปกติแต่ละสไลด์โดยตรงได้หรือไม่?**

แนวทางการแก้ไขของสไลด์ปกติจะถูกจัดเก็บในคุณสมบัติการมองเห็นสไลด์ของงานนำเสนอ. คอลเลกชันแนวทางแยกต่างหากมีให้สำหรับมาสเตอร์สไลด์, สไลด์เลย์เอาต์, โน้ตมาสเตอร์, และแฮนด์เอาท์มาสเตอร์.

**หน่วยใดใช้สำหรับตำแหน่งของแนวทาง?**

ตำแหน่งระบุเป็นหน่วยจุด โดย 72 จุดเท่ากับหนึ่งนิ้ว. ตำแหน่งแนวตั้งวัดจากขอบซ้าย และตำแหน่งแนวนอนวัดจากขอบบน.

**การลบแนวทางการวาดทำให้รูปทรงหายไปหรือเปลี่ยนแปลงเนื้อหาสไลด์หรือไม่?**

ไม่. เมธอด `clear` จะลบเฉพาะแนวทางในคอลเลกชันที่เลือก เท่านั้น. รูปร่างและเนื้อหาอื่น ๆ ของสไลด์จะคงเดิม.