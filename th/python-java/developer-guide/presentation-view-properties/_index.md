---
title: ดึงข้อมูลและอัปเดตคุณสมบัติมุมมองการนำเสนอใน Python ผ่าน Java
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/python-java/presentation-view-properties/
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
- การขยายเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อปรับแต่งสไลด์ PPT, PPTX, และ ODP — ปรับรูปแบบ, ระดับการขยาย, และการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองปกติประกอบด้วยพื้นที่เนื้อหา 3 พื้นที่: สไลด์เอง, พื้นที่เนื้อหาข้างด้าน และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติของมุมมองปกติอธิบายการจัดตำแหน่งของพื้นที่เนื้อหาเหล่านี้. ข้อมูลนี้ทำให้แอปพลิเคชันบันทึกสถานะมุมมองลงในไฟล์, เพื่อให้เมื่อเปิดใหม่มุมมองจะอยู่ในสถานะเดียวกับเมื่อการนำเสนอถูกบันทึกล่าสุด.

ได้เพิ่มเมธอด [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getNormalViewProperties) เพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของการนำเสนอ.

ได้เพิ่มคลาส [NormalViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/) และ [NormalViewRestoredProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewrestoredproperties/) รวมถึง enumeration [SplitterBarStateType](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/)

## **เกี่ยวกับ NormalViewProperties**

แทนคุณสมบัติมุมมองปกติ.

เมธอด [getShowOutlineIcons](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) ระบุว่าผู้แอปพลิเคชันควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติ.

เมธอด [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) ระบุว่าตัวแบ่งแนวตั้งควรสแนปไปยังสถานะย่อเมื่อพื้นที่ด้านเป็นขนาดเล็กพอ.

เมธอด [getPreferSingleView](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) และ [setPreferSingleView](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดี่ยวเต็มหน้าต่างแทนมุมมองปกติมาตรฐานที่มีสามพื้นที่หรือไม่. หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาเต็มหน้าต่าง.

เมธอด [getVerticalBarState](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) ระบุสถานะที่แถบแบ่งแนวนอนหรือแนวตั้งควรแสดง. แถบแบ่งแนวนอนแยกสไลด์จากพื้นที่เนื้อหาด้านล่างสไลด์; แถบแบ่งแนวตั้งแยกสไลด์จากพื้นที่เนื้อหาข้าง. ค่าได้แก่: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/#Maximized) และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/#Restored).

เมธอด [getRestoredLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) และ [getRestoredTop](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredTop) ระบุการกำหนดขนาดของพื้นที่สไลด์ด้านซ้ายหรือด้านบนของมุมมองปกติเมื่อค่ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/#Restored) ถูกนำไปใช้กับ [getVerticalBarState](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) ตามลำดับ.

## **เกี่ยวกับการกู้คืน NormalViewProperties**

ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredTop), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) ของมุมมองปกติเมื่อพื้นที่มีขนาดที่กู้คืนแบบปรับตัว (ไม่ย่อและไม่ขยาย).

เมธอด [getDimensionSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ [getRestoredTop](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredTop), ความสูงเมื่อเป็นลูกของ [getRestoredLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

เมธอด [getAutoAdjust](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) ระบุว่าขนาดของพื้นที่เนื้อหาข้างควรปรับให้สอดรับกับขนาดใหม่เมื่อปรับขนาดหน้าต่างที่มีมุมมองอยู่ในแอปพลิเคชันหรือไม่.

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

    # คืนค่าคุณสมบัติมุมมองของการนำเสนอ.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าการขยายเริ่มต้น**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java รองรับการตั้งค่าการขยายเริ่มต้นเพื่อให้ใช้โดยอัตโนมัติเมื่อเปิดการนำเสนอ. สามารถทำได้โดยตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/) ของการนำเสนอ. ทั้งเมธอด [getSlideViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getSlideViewProperties) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getNotesViewProperties) สามารถกำหนดค่าได้โดยโปรแกรม. ในบทนี้เราจะดูตัวอย่างวิธีตั้งค่า [View Properties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/) ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ใน Aspose.Slides.
{{% /alert %}}

เพื่อกำหนดคุณสมบัติมุมมอง ทำตามขั้นตอนต่อไปนี้:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/).
2. กำหนด [View Properties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/) ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/).
3. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/).

ในตัวอย่างด้านล่าง เราตั้งค่าการขยายสำหรับทั้งมุมมองสไลด์และมุมมองโน้ต.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # ตั้งค่าคุณสมบัติมุมมองของการนำเสนอ.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # เปอร์เซ็นต์การขยายสำหรับมุมมองสไลด์.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # เปอร์เซ็นต์การขยายสำหรับมุมมองโน้ต.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าระยะห่างของกริด**

ใช้ [Presentation.getViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getViewProperties) เพื่อเข้าถึงการตั้งค่ามุมมองทั้งหมดของการนำเสนอ. เมธอด [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getGridSpacing) และ [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#setGridSpacing) อ่านหรือเปลี่ยนช่วงของกริดการแก้ไขพื้นฐาน. การตั้งค่านี้ใช้กับการนำเสนอทั้งหมด ไม่ใช่สไลด์เดี่ยว. ระยะห่างของกริดกำหนดเป็นพ้อยต์ โดย 72 พ้อยต์เท่ากับหนึ่งนิ้ว. ใช้ค่าบวกตามที่เอกสาร API กำหนด.

ตัวอย่างต่อไปนี้เปิดไฟล์ `demo.pptx` ที่มีอยู่แล้ว, พิมพ์ระยะห่างกริดปัจจุบัน, ตั้งค่าเป็นช่วงสี่ส่วนของนิ้ว, แล้วบันทึกผลลัพธ์.

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

กริดแตกต่างจาก [drawing guides](/slides/th/python-java/drawing-guides/). ระยะห่างของกริดควบคุมช่วงปกติในขณะที่ drawing guides เป็นเส้นแนวนอนหรือแนวตั้งที่กำหนดตำแหน่งแยกกัน. การเพิ่ม, ย้าย หรือล้าง drawing guides ไม่ทำให้ระยะห่างของกริดเปลี่ยน.

ทั้งกริดและ drawing guides เป็นเครื่องมือช่วยการแก้ไข. พวกมันไม่ได้แสดงเป็นเนื้อหาสไลด์ใน PDF, ภาพ, SVG หรือการแสดงสไลด์. การบันทึกระยะห่างของกริดไม่ได้รับประกันว่าโปรแกรมแก้ไขจะแสดงกริด: ความสามารถในการมองเห็นยังขึ้นอยู่กับการตั้งค่าของผู้ชมหรือโปรแกรมแก้ไข.

## **แสดงหรือซ่อนความคิดเห็นเมื่อเปิดการนำเสนอ**

ใช้ [Presentation.getViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getViewProperties) เพื่อเข้าถึงการตั้งค่ามุมมองของการนำเสนอทั้งหมด. ใช้ [ViewProperties.getShowComments](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getShowComments) และ [ViewProperties.setShowComments](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#setShowComments) เพื่ออ่านหรือเปลี่ยนการตั้งค่าที่บันทึกไว้ว่าให้แสดงความคิดเห็นหรือไม่เมื่อการนำเสนอเปิดใน PowerPoint หรือโปรแกรมที่เข้ากันได้อื่น.

การตั้งค่านี้ควบคุมเฉพาะการตั้งค่ามุมมองที่บันทึกไว้. มันไม่ได้เพิ่ม, ลบ, แก้ไขหรือแก้ปัญหาความคิดเห็น. การซ่อนความคิดเห็นยังคงรักษาเนื้อหา, ผู้เขียน, ตำแหน่ง, การตอบกลับและสถานะของความคิดเห็นไว้. ดู [Presentation Comments](/slides/th/python-java/presentation-comments/) สำหรับการดำเนินการที่เปลี่ยนแปลงความคิดเห็นเอง.

ตัวอย่างต่อไปนี้ต้องมีไฟล์ `comments.pptx` ที่มีความคิดเห็นอยู่แล้ว. มันพิมพ์การตั้งค่าการมองเห็นปัจจุบัน, ขอให้ซ่อนความคิดเห็น, แล้วบันทึก PPTX ใหม่โดยไม่ลบความคิดเห็นใด ๆ. นอกจากนี้ยังใช้ [ViewProperties.setLastView](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#setLastView) พร้อมกับ [ViewType.SlideView](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewtype/#SlideView) เพื่อกำหนดมุมมองการแก้ไขเริ่มต้นพร้อมกับการมองเห็นความคิดเห็น.

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

การตั้งค่านี้ไม่ได้กำหนดว่าความคิดเห็นจะรวมอยู่ในการส่งออกเป็น PDF, HTML, ภาพ, โน้ต หรือเอกสารแจกหรือไม่. ให้กำหนดตัวเลือกการส่งออกที่เกี่ยวข้องแยกต่างหาก.

## **คำถามที่พบบ่อย**

**ทำไมกริดไม่แสดงเมื่อฉันเปิดการนำเสนออีกครั้ง?**  
ไฟล์บันทึกระยะห่างของกริดไว้แต่โปรแกรมแก้ไขเป็นผู้ควบคุมว่ากริดจะแสดงหรือไม่. ตรวจสอบการตั้งค่าการมองเห็นกริดของโปรแกรมแก้ไข.

**การลบ drawing guides จะเปลี่ยนระยะห่างของกริดหรือไม่?**  
ไม่. drawing guides และระยะห่างของกริดเป็นการตั้งค่าที่แยกจากกัน. การล้าง guides จะไม่ทำให้ช่วงกริดที่บันทึกเปลี่ยนแปลง.

**ฉันสามารถตั้งค่ามุมมองที่แตกต่างสำหรับแต่ละส่วนของการนำเสนอได้หรือไม่?**  
การตั้งค่ามุมมองถูกกำหนดระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getSlideViewProperties)) ไม่ได้ระดับส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดล่วงหน้าสถานะมุมมองที่แตกต่างสำหรับผู้ใช้คนต่างได้หรือไม่?**  
ไม่. การตั้งค่าถูกบันทึกในไฟล์และใช้ร่วมกัน. โปรแกรมดูอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถเตรียมเทมเพลตที่มี View Properties ที่กำหนดไว้ล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดด้วยวิธีเดียวกันได้หรือไม่?**  
ได้. เนื่องจาก view properties ถูกเก็บระดับการนำเสนอ, คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นเพื่อให้มุมมองเริ่มต้นเหมือนเดิม.