---
title: ดึงและอัปเดตคุณสมบัติการแสดงผลการนำเสนอใน Python ผ่าน Java
linktitle: คุณสมบัติการแสดงผล
type: docs
weight: 80
url: /th/python-java/presentation-view-properties/
keywords:
- คุณสมบัติการแสดงผล
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
- Python
- Java
- Aspose.Slides
description: "ค้นพบคุณสมบัติการแสดงผลของ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อปรับแต่งสไลด์ PPT, PPTX, และ ODP — ปรับเลย์เอาต์ ระดับการซูม และการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองแบบปกติประกอบด้วยสามพื้นที่เนื้อหา: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติของมุมมองแบบปกติอธิบายตำแหน่งของพื้นที่เนื้อหาเหล่านี้. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงในไฟล์, เพื่อให้เมื่อเปิดใหม่มุมมองอยู่ในสถานะเดียวกับที่บันทึกครั้งสุดท้าย.

เมธอด [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getNormalViewProperties) ถูกเพิ่มเข้ามาเพื่อให้เข้าถึงคุณสมบัติของมุมมองแบบปกติของการนำเสนอ.

คลาส [NormalViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/) และ [NormalViewRestoredProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewrestoredproperties/) และ enumeration [SplitterBarStateType](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/) ถูกเพิ่มเข้ามา.

## **เกี่ยวกับ NormalViewProperties**

แทนคุณสมบัติของมุมมองแบบปกติ.

เมธอด [getShowOutlineIcons](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) ระบุว่าควรแสดงไอคอนเมื่อแสดงเนื้อหาแบบโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองแบบปกติหรือไม่.

เมธอด [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) ระบุว่าตัวแบ่งแนวตั้งควรสแนปไปสู่สถานะย่อลงเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอ.

เมธอด [getPreferSingleView](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) และ [setPreferSingleView](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดี่ยวเต็มหน้าต่างแทนมุมมองแบบปกติมาตรฐานที่มีสามพื้นที่หรือไม่. หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาในหน้าต่างทั้งหมด.

เมธอด [getVerticalBarState](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) ระบุสถานะที่แถบแบ่งแนวตั้งหรือแนวนอนควรแสดง. แถบแบ่งแนวนอนแยกสไลด์จากพื้นที่เนื้อหาด้านล่างสไลด์; แถบแบ่งแนวตั้งแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/#Maximized) และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/#Restored).

เมธอด [getRestoredLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) และ [getRestoredTop](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredTop) ระบุการกำหนดขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองแบบปกติ, เมื่อค่ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/#Restored) ถูกนำไปใช้กับ [getVerticalBarState](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) ตามลำดับ.

## **เกี่ยวกับการคืนค่า NormalViewProperties**

ระบุการกำหนดขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นบุตรของ [getRestoredTop](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredTop), ความสูงเมื่อเป็นบุตรของ [getRestoredLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) ของมุมมองแบบปกติ, เมื่อพื้นที่มีขนาดที่ปรับคืนได้ (ไม่ย่อลงและไม่ขยายเต็ม).

เมธอด [getDimensionSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นบุตรของ [getRestoredTop](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredTop), ความสูงเมื่อเป็นบุตรของ [getRestoredLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

เมธอด [getAutoAdjust](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) ระบุว่าพื้นที่เนื้อหาด้านข้างควรปรับขนาดเพื่อตอบสนองต่อขนาดใหม่เมื่อปรับขนาดหน้าต่างที่มีมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีเข้าถึง [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getNormalViewProperties) สำหรับการนำเสนอ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # กู้คืนคุณสมบัติการแสดงผลของการนำเสนอ.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าค่าการซูมเริ่มต้น**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java รองรับการตั้งค่าการซูมเริ่มต้นเพื่อให้มีผลแล้วเมื่อเปิดการนำเสนอ. สามารถทำได้โดยตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/) ของการนำเสนอ. เมธอด [getSlideViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getSlideViewProperties) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getNotesViewProperties) สามารถกำหนดโปรแกรมได้. ในบทความนี้ เราจะเห็นตัวอย่างการตั้งค่า [View Properties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/) ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ใน Aspose.Slides.

{{% /alert %}}

เพื่อกำหนดคุณสมบัติของมุมมอง, ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/).
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/) ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/).
1. เขียนการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/).

ในตัวอย่างด้านล่าง เราตั้งค่าการซูมสำหรับมุมมองสไลด์และมุมมองบันทึกหมายเหตุทั้งสอง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # ตั้งค่าคุณสมบัติการแสดงผลของการนำเสนอ.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # เปอร์เซ็นต์การซูมสำหรับมุมมองสไลด์.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # เปอร์เซ็นต์การซูมสำหรับมุมมองบันทึกหมายเหตุ.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าการเว้นระยะตาราง**

ใช้ [Presentation.getViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getViewProperties) เพื่อเข้าถึงการตั้งค่ามุมมองทั่วทั้งการนำเสนอ. เมธอด [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getGridSpacing) และ [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#setGridSpacing) อ่านหรือเปลี่ยนช่วงของกริดการแก้ไขพื้นฐาน. การตั้งค่านี้ใช้กับการนำเสนอทั้งหมด, ไม่ใช่สไลด์แต่ละหน้า. ระยะตารางระบุเป็นจุด, โดย 72 จุดเท่ากับหนึ่งนิ้ว. ใช้ค่าบวกตามที่เอกสาร API กำหนด.

ตัวอย่างต่อไปเปิดไฟล์ `demo.pptx` ที่มีอยู่, พิมพ์ระยะตารางปัจจุบัน, ตั้งค่าช่วงเป็นหนึ่งในสี่นิ้ว, และบันทึกผลลัพธ์.

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

กริดต่างจาก [drawing guides](/slides/th/python-java/drawing-guides/). ระยะตารางควบคุมช่วงเป็นระยะสม่ำเสมอ, ส่วน drawing guides เป็นเส้นแนวนอนหรือแนวตั้งที่วางตำแหน่งได้ตามต้องการ. การเพิ่ม, ย้าย, หรือลบ drawing guides ไม่ทำให้ระยะตารางเปลี่ยนแปลง.

กริดและ drawing guides ทั้งสองเป็นเครื่องมือช่วยการแก้ไข. พวกมันไม่ถูกแสดงเป็นเนื้อหาสไลด์ใน PDF, รูปภาพ, SVG หรือการแสดงสไลด์โชว์. การจัดเก็บระยะตารางไม่ได้รับประกันว่าเครื่องมือแก้ไขจะทำการแสดงกริด: การมองเห็นยังขึ้นกับการตั้งค่าของผู้ดูหรือเครื่องมือแก้ไขด้วย.

## **คำถามที่พบบ่อย**

**ทำไมกริดถึงไม่ปรากฏเมื่อเปิดการนำเสนอใหม่?**

ไฟล์เก็บระยะตารางไว้, แต่เครื่องมือแก้ไขเป็นผู้ควบคุมว่ากริดจะแสดงหรือไม่. ตรวจสอบการตั้งค่าการมองเห็นกริดของเครื่องมือแก้ไข.

**การล้าง drawing guides มีผลต่อระยะตารางหรือไม่?**

ไม่มี. drawing guides และระยะตารางเป็นการตั้งค่าที่อิสระกัน. การลบ guides ไม่ทำให้ช่วงกริดที่เก็บไว้เปลี่ยนแปลง.

**ฉันสามารถตั้งค่า view ต่าง ๆ สำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?**

[View settings](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getViewProperties) ถูกกำหนดระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), ไม่ได้แยกตามส่วน, ดังนั้นพารามิเตอร์ชุดเดียวจึงใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะ view ที่แตกต่างสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**

ไม่ได้. การตั้งค่าถูกรับไว้ในไฟล์และแชร์กัน. แอปพลิเคชันผู้ดูอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติ view เพียงชุดเดียว.

**ฉันสามารถสร้างเทมเพลตพร้อม View Properties ที่กำหนดล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดในลักษณะเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getViewProperties) ถูกเก็บระดับการนำเสนอ, คุณจึงสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นด้วยการกำหนดมุมมองเริ่มต้นเดียวกัน.