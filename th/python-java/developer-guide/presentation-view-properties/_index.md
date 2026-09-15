---
title: ดึงและอัปเดตคุณสมบัติมุมมองการนำเสนอใน Python ผ่าน Java
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
- ซูมเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อปรับแต่งสไลด์ PPT, PPTX, และ ODP — ปรับเลย์เอาต์, ระดับการซูม, และการตั้งค่าการแสดงผล."
---
## **บทนำ**

มุมมองปกติประกอบด้วยพื้นที่เนื้อหา 3 ส่วน: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติของมุมมองปกติอธิบายการจัดตำแหน่งของพื้นที่เนื้อหาเหล่านี้. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงในไฟล์ได้, เพื่อให้เมื่อเปิดใหม่มุมมองจะอยู่ในสภาพเดียวกับที่บันทึกครั้งสุดท้ายของการนำเสนอ.

เมธอด [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getNormalViewProperties) ได้ถูกเพิ่มเพื่อให้เข้าถึงคุณสมบัติการมุมมองปกติของการนำเสนอ.

คลาส [NormalViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/) และ [NormalViewRestoredProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewrestoredproperties/) และ enumeration [SplitterBarStateType](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/) ได้ถูกเพิ่มเข้ามา.

## **เกี่ยวกับ NormalViewProperties**

แสดงคุณสมบัติการมุมมองปกติ.

เมธอด [getShowOutlineIcons](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) และ [setShowOutlineIcons](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) ระบุว่าระบบควรแสดงไอคอนเมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติหรือไม่.

เมธอด [getSnapVerticalSplitter](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) และ [setSnapVerticalSplitter](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) ระบุว่าตัวแบ่งแนวตั้งควรสแนปไปยังสถานะย่อเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอ.

เมธอด [getPreferSingleView](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) และ [setPreferSingleView](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดี่ยวเต็มหน้าต่างเหนือมุมมองปกติแบบมาตรฐานที่มี 3 พื้นที่หรือไม่. หากเปิดใช้งาน, แอปพลิเคชันอาจเลือกแสดงหนึ่งจากพื้นที่เนื้อหาเต็มหน้าต่าง.

เมธอด [getVerticalBarState](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) ระบุสถานะที่แถบแบ่งแนวตั้งหรือแนวนอนควรจะแสดง. แถบแบ่งแนวนอนแยกสไลด์ออกจากพื้นที่เนื้อหาด้านล่างสไลด์; แถบแบ่งแนวตั้งแยกสไลด์ออกจากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้ ได้แก่ [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/#Maximized) และ [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/#Restored).

เมธอด [getRestoredLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) และ [getRestoredTop](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredTop) ระบุการกำหนดขนาดของส่วนด้านบนหรือด้านข้างของสไลด์ในมุมมองปกติ, เมื่อค่า [SplitterBarStateType.Restored](https://reference.aspose.com/slides/th/python-java/aspose.slides/splitterbarstatetype/#Restored) ถูกนำไปใช้กับ [getVerticalBarState](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) และ [getHorizontalBarState](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) ตามลำดับ.

## **เกี่ยวกับการกู้คืน NormalViewProperties**

ระบุการกำหนดขนาดของส่วนสไลด์ (ความกว้างเมื่อเป็นบุตรของ [getRestoredTop](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredTop), ความสูงเมื่อเป็นบุตรของ [getRestoredLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) ของมุมมองปกติ, เมื่อส่วนนั้นมีขนาดที่คืนค่าได้แบบแปรผัน (ไม่ย่อและไม่ขยาย).

เมธอด [getDimensionSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) ระบุขนาดของส่วนสไลด์ (ความกว้างเมื่อเป็นบุตรของ [getRestoredTop](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredTop), ความสูงเมื่อเป็นบุตรของ [getRestoredLeft](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

เมธอด [getAutoAdjust](https://reference.aspose.com/slides/th/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) ระบุว่าขนาดของพื้นที่เนื้อหาด้านข้างควรปรับตามขนาดใหม่เมื่อเปลี่ยนขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.

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

    # กู้คืนคุณสมบัติมุมมองของการนำเสนอ.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าค่าการซูมเริ่มต้น**

{{% alert color="info" title="หมายเหตุ" %}}
Aspose.Slides for Python via Java รองรับการตั้งค่าค่าการซูมเริ่มต้นเพื่อให้ถูกนำไปใช้เมื่อนำเสนอเปิดขึ้น. สิ่งนี้ทำได้โดยการตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/) ของการนำเสนอ. เมธอด [getSlideViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getSlideViewProperties) และ [getNotesViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getNotesViewProperties) สามารถกำหนดค่าได้โดยโปรแกรม. ในหัวข้อนี้, เราจะดูตัวอย่างการตั้งค่า [View Properties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/) ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ใน [Aspose.Slides](/slides/th/).
{{% /alert %}}

เพื่อกำหนดคุณสมบัติการมุมมอง, ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/).
1. ตั้งค่า [View Properties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/) ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/).
1. บันทึกการนำเสนอเป็นไฟล์ [PPTX](https://docs.fileformat.com/presentation/pptx/).

ในตัวอย่างด้านล่าง, เราตั้งค่าการซูมสำหรับทั้งมุมมองสไลด์และมุมมองบันทึกย่อ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # ตั้งค่าคุณสมบัติมุมมองของการนำเสนอ.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # เปอร์เซ็นต์การซูมสำหรับมุมมองสไลด์.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # เปอร์เซ็นต์การซูมสำหรับมุมมองบันทึกย่อ.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าการมองต่าง ๆ สำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?**

[View settings](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getViewProperties) ถูกกำหนดที่ระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), ไม่ได้ต่อแต่ละส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อตอบเปิด.

**ฉันสามารถกำหนดสถานะการมองล่วงหน้าสำหรับผู้ใช้คนต่าง ๆ ได้หรือไม่?**

ไม่ได้. การตั้งค่าจะถูกเก็บในไฟล์และใช้ร่วมกัน. แอปพลิเคชันผู้ดูอาจให้ความสำคัญกับการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติการมองเพียงหนึ่งชุด.

**ฉันสามารถเตรียมเทมเพลตที่มี View Properties ที่กำหนดล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดด้วยวิธีเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getViewProperties) ถูกเก็บที่ระดับการนำเสนอ, คุณสามารถฝังมันในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นโดยใช้การกำหนดค่ามุมมองเริ่มต้นเดียวกัน.