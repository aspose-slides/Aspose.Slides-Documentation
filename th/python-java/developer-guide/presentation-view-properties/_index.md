---
title: ดึงและอัปเดตคุณสมบัติมุมมองการนำเสนอใน Python ผ่าน Java
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/python-java/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาเค้าโครง
- ไอคอนเค้าโครง
- สแนปตัวแบ่งแนวตั้ง
- มุมมองเดียว
- สถานะแบบแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- การซูมเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อกำหนดค่าการจัดเรียงมุมมองปกติ, การซูมสไลด์และโน้ต, ระยะห่างกริด, และการแสดงคอมเมนต์ในงานนำเสนอ PowerPoint."
---
## **บทนำ**

ในมุมมองปกติของ PowerPoint สไลด์จะปรากฏระหว่างแถบด้านข้างสำหรับภาพย่อหรือเค้าโครงและแถบบันทึกด้านล่าง Aspose.Slides for Python via Java เปิดเผยการตั้งค่าการแก้ไขที่บันทึกไว้ของงานนำเสนอผ่าน [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) สิ่งเหล่านี้รวมถึงการจัดเรียงแถบ, ระดับการซูม, ระยะห่างของกริด, และการมองเห็นคอมเมนต์

## **เกี่ยวกับ NormalViewProperties**

ใช้ [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) เพื่อเข้าถึงคลาส [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/)  [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) ควบคุมว่ารูปไอคอนจะแสดงข้างหัวข้อสไลด์ในเค้าโครงหรือไม่ [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) ทำให้แถบด้านข้างล็อกที่สถานะย่อเมื่อผู้ใช้ทำให้แคบลง [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) ระบุความต้องการให้แสดงแถบเดียวในหน้าต่างเต็ม

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) ควบคุมตัวแบ่งระหว่างแถบด้านข้างและสไลด์ [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) ควบคุมตัวแบ่งเหนือแถบบันทึก ทั้งสองรับค่า [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) ที่เป็น `Minimized`, `Maximized`, หรือ `Restored`

## **เกี่ยวกับการคืนค่า NormalViewProperties**

เมื่อมีการคืนค่าตัวแบ่ง [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) จะคืนขนาดที่บันทึกของแถบด้านข้างและ [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) จะคืนขนาดที่บันทึกของพื้นที่สไลด์ด้านบน ทั้งสองจะคืนอินสแตนซ์ของ [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/) เมธอด [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) รับเปอร์เซ็นต์ตั้งแต่ 0 ถึง 100 และ [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) ควบคุมว่าผู้ออกแบบจะปรับขนาดอัตโนมัติเมื่อหน้าต่างถูกปรับขนาดหรือไม่

ตัวอย่างนี้อัปเดตงานนำเสนอที่มีอยู่ มันคืนค่าตัวแบ่งแนวนอน ตั้งค่าขนาดที่คืนจาก [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) เป็น 80 % พร้อมเปิดการปรับขนาดอัตโนมัติและขยายตัวแบ่งแนวตั้งให้เต็ม อีกทั้งยังเรียก [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) เพื่อแสดงไอคอนในมุมมองเค้าโครง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าระดับการซูมเริ่มต้น**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) และ [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) เก็บการตั้งค่าการซูมแบบอิสระสำหรับผู้ออกแบบ การตั้งค่าเหล่านี้ไม่ส่งผลต่อมิติของสไลด์ การเล่นสไลด์โชว์ หรือความละเอียดการส่งออกภาพ

ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และเรียก [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) เพื่อให้สไลด์พอดีกับหน้าต่างการแก้ไข สำหรับหน้าโน๊ต จะปิดการปรับสเกลอัตโนมัติและเรียก [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) เพื่อกำหนดการซูมคงที่ที่ 80 %

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าระยะห่างของกริด**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) กำหนดระยะห่างระหว่างเส้นกริดการแก้ไขทั่วทั้งงานนำเสนอ รับค่าบวกในหน่วยจุด โดย 72 จุดต่อหนึ่งนิ้ว ตัวอย่างนี้พิมพ์ระยะห่างปัจจุบันในงานนำเสนอที่มีอยู่และบันทึกกริดเป็นหนึ่งในสี่นิ้วโดยกำหนดช่วงเป็น 18 จุด

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

กริดจะทำซ้ำที่ช่วงคงที่ [Drawing guides](/slides/th/python-java/drawing-guides/) ทำเครื่องหมายตำแหน่งแนวนอนหรือแนวตั้งแต่ละตำแหน่ง ทั้งสองเป็นเครื่องมือช่วยการแก้ไขและปรากฏเฉพาะในโปรแกรมที่แสดงมัน การแสดงสไลด์โชว์และการส่งออกเป็น PDF, รูปภาพ หรือ SVG จะไม่แสดง

## **แสดงหรือซ่อนคอมเมนต์เมื่อเปิดงานนำเสนอ**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) เก็บค่าที่โปรแกรมที่เข้ากันได้ใช้เม้าเปิดงานนำเสนอ สำหรับงานนำเสนอที่มีคอมเมนต์ ตัวอย่างนี้พิมพ์ค่าปัจจุบันและบันทึกสำเนาที่ซ่อนคอมเมนต์โดยยังคงเนื้อหา, ผู้เขียน, ตำแหน่ง, คำตอบ, และสถานะไว้ด้วย อีกทั้งยังเรียก [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) กับ [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) เพื่อให้สำเนาเปิดในมุมมองสไลด์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การซ่อนคอมเมนต์จะคงข้อความ, ผู้เขียน, ตำแหน่ง, การตอบกลับ, และสถานะไว้ หากต้องการเปลี่ยนคอมเมนต์เอง ดูที่ [Presentation Comments](/slides/th/python-java/presentation-comments/) การตั้งค่าการส่งออกจะกำหนดว่าคอมเมนต์จะแสดงใน PDF, HTML, รูปภาพ, โน๊ต หรือเอกสารแจกหรือไม่

## **คำถามที่พบบ่อย**

**ทำไมกริดถึงหายไปเมื่อฉันเปิดงานนำเสนอใหม่?**

งานนำเสนอเก็บช่วงเวลาของกริด เพื่อดูกริดให้เปิดการแสดงกริดในโปรแกรมแก้ไข

**การลบแนวทางการวาดทำให้ระยะห่างของกริดเปลี่ยนหรือไม่?**

ไม่ การเพิ่ม, ย้าย หรือทำความสะอาดแนวทางจะไม่เปลี่ยนช่วงเวลาของกริด

**ส่วนต่าง ๆ ของงานนำเสนอสามารถมีการตั้งค่ามุมมองที่แตกต่างกันได้หรือไม่?**

ไม่ [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) ใช้กับงานนำเสนอทั้งหมด

**ฉันสามารถบันทึกการตั้งค่ามุมมองที่แตกต่างกันสำหรับผู้ใช้คนต่าง ๆ ได้หรือไม่?**

ไฟล์บันทึกชุดการตั้งค่ามุมมองเดียวสำหรับทุกคน โปรแกรมแก้ไขอาจใช้ค่าที่ผู้ใช้กำหนดไว้ในเครื่องของตนเพิ่มเติม

**ฉันสามารถบันทึกการตั้งค่ามุมมองในเทมเพลตได้หรือไม่?**

ได้ งานนำเสนอที่สร้างจากเทมเพลตจะสืบทอดการตั้งค่ามุมมองที่บันทึกไว้ในเทมเพลต