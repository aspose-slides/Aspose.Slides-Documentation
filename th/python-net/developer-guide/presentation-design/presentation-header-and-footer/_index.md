---
title: จัดการส่วนหัวและส่วนท้ายของงานนำเสนอด้วย Python
linktitle: ส่วนหัวและส่วนท้าย
type: docs
weight: 140
url: /th/python-net/presentation-header-and-footer/
keywords:
- ส่วนหัว
- ข้อความส่วนหัว
- ส่วนท้าย
- ข้อความส่วนท้าย
- ตั้งส่วนหัว
- ตั้งส่วนท้าย
- ใบกระจาย
- บันทึกย่อ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการตำแหน่งส่วนท้าย, วันที่-เวลา, หมายเลขสไลด์ และส่วนหัวบนสไลด์, หน้าบันทึกย่อ และใบกระจายด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

PowerPoint ใช้ตำแหน่งตัวอักษรหัวกระดาษและส่วนท้ายที่แตกต่างกันขึ้นอยู่กับประเภทของหน้า Aspose.Slides สำหรับ Python ผ่าน .NET ให้คุณควบคุมข้อความและการมองเห็นของตำแหน่งเหล่านี้ผ่านคลาสผู้จัดการหัวกระดาษ/ส่วนท้าย

ตำแหน่งที่พร้อมใช้งานขึ้นอยู่กับขอบเขต:

| ขอบเขต | หัวกระดาษ | ส่วนท้าย | วันที่/เวลา | หมายเลขสไลด์/หน้า |
|---|---|---|---|---|
| สไลด์ปกติ | ไม่มี | มี | มี | มี |
| Notes master | มี | มี | มี | มี |
| Notes slide | มี | มี | มี | มี |
| Handout master | มี | มี | มี | มี |

สไลด์การนำเสนอแบบปกติไม่มีตำแหน่งหัวกระดาษ หัวกระดาษพร้อมใช้งานบนหน้าบันทึกย่อและใบกระจาย สำหรับสไลด์ปกติให้ใช้ตำแหน่งส่วนท้าย วันที่/เวลา และหมายเลขสไลด์แทน

ขอบเขตของการเปลี่ยนแปลงขึ้นอยู่กับผู้จัดการที่คุณใช้ คลาส [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/th/python-net/aspose.slides/slideheaderfootermanager/) ควบคุมสไลด์ปกติหนึ่งสไลด์ คลาส [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/python-net/aspose.slides/notesslideheaderfootermanager/) ควบคุมสไลด์บันทึกย่อหนึ่งสไลด์ ผู้จัดการ master และ layout ยังสามารถกระจายการตั้งค่าไปยังสไลด์ที่ขึ้นกับได้ ในขณะที่คลาส [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) ควบคุม handout master

## **ตั้งส่วนท้าย วันที่/เวลา และหมายเลขสไลด์บนสไลด์ปกติ**

สำหรับสไลด์ปกติ กระบวนการพื้นฐานคือเข้าถึงผู้จัดการหัวกระดาษ/ส่วนท้ายของแต่ละสไลด์ ตั้งข้อความส่วนท้ายและวันที่/เวลา เปิดใช้งานตำแหน่งที่ต้องการ แล้วบันทึกการนำเสนอ หมายเลขสไลด์สร้างโดยการนำเสนอเอง ดังนั้นคุณเพียงแค่ควบคุมการมองเห็นของมันเท่านั้น

ใช้ [`set_footer_text`](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) และ [`set_date_time_text`](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) เพื่อตั้งข้อความ และใช้ [`set_footer_visibility`](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), และ [`set_slide_number_visibility`](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) เพื่อแสดงตำแหน่งที่สอดคล้องกัน

ตัวอย่างต่อไปนี้เป็นการประยุกต์ใช้ส่วนท้ายเดียวกัน ข้อความวันที่/เวลาเดียวกัน และการมองเห็นหมายเลขสไลด์กับสไลด์ปกติทั้งหมด:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

หากคุณต้องการอัปเดตเพียงสไลด์เดียว ให้เข้าถึงสไลด์นั้นโดยตรงผ่านคอลเลกชัน [`slides`](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slides/th/) แทนการวนลูปผ่านคอลเลกชันทั้งหมด

## **ตั้งหัวกระดาษและส่วนท้ายบน Notes Master**

Notes master กำหนดรูปแบบทั่วไปและพฤติกรรมตำแหน่งของหน้าบันทึกย่อ ใช้คลาส [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslideheaderfootermanager/) เมื่อคุณต้องการเปลี่ยนแปลงเฉพาะ notes master เท่านั้น

ตัวอย่างต่อไปนี้ตั้งหัวกระดาษ ส่วนท้าย และข้อความวันที่/เวลาใน notes master และทำให้ตำแหน่งที่รองรับทั้งหมดมองเห็นได้บน master นั้น:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

การนำเสนออาจไม่มี notes master ดังนั้นตรวจสอบค่าที่คืนกลับว่าเป็น `None` ก่อนทำการเปลี่ยนแปลง

## **นำการตั้งค่า Notes Master ไปใช้กับ Notes Slides ลูก**

Notes master สามารถประยุกต์ใช้การตั้งค่าหัวกระดาษและส่วนท้ายกับตัวมันเองและกับ notes slides ลูกทั้งหมด ใช้วิธีการกระจายที่กำหนดไว้ใน [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslideheaderfootermanager/) เมื่อต้องการใช้การตั้งค่าเดียวกันทั่วทั้งลำดับชั้นของ notes

ตัวอย่างเช่น [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) และ [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) จะอัปเดตหัวกระดาษของ notes master และหัวกระดาษของทุก notes slide ลูก วิธีการที่เทียบเท่ามีสำหรับส่วนท้าย วันที่/เวลา และหมายเลขสไลด์

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

วิธีการกระจายที่ใช้ข้างต้นได้แก่ [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), และ [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/)

## **ตั้งหัวกระดาษและส่วนท้ายบน Notes Slide รายบุคคล**

Notes slide เชื่อมโยงกับสไลด์ปกติเฉพาะ ใช้คลาส [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/python-net/aspose.slides/notesslideheaderfootermanager/) เมื่อคุณต้องการปรับแต่งเพียงหน้า notes นั้น

เมธอด [`add_notes_slide`](https://reference.aspose.com/slides/th/python-net/aspose.slides/notesslidemanager/add_notes_slide/) คืนค่า notes slide สำหรับสไลด์ปัจจุบันและสร้างใหม่หากยังไม่มี ตัวอย่างต่อไปนี้กำหนดค่าหน้า notes ที่เชื่อมกับสไลด์แรกของการนำเสนอ:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

หากคุณกระจายการตั้งค่าจาก notes master ก่อนแล้วจึงเปลี่ยนแปลง notes slide รายบุคคล การตั้งค่าในแต่ละสไลด์ภายหลังจะทำให้คุณสามารถปรับแต่งหน้า notes นั้นอย่างอิสระ

## **ตั้งหัวกระดาษและส่วนท้ายบน Handout Master**

หน้าจัดทำคู่มือใช้ handout master สำหรับตำแหน่งหัวกระดาษ ส่วนท้าย วันที่/เวลา และหมายเลขหน้า ต่างจาก notes page การตั้งค่า handout จัดการผ่าน handout master ไม่ใช่ผ่านสไลด์ handout รายบุคคล

ใช้คุณสมบัติ [`master_handout_slide`](https://reference.aspose.com/slides/th/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) เพื่อเข้าถึง handout master หากไม่มีให้เรียกเมธอด [`set_default_master_handout_slide`](https://reference.aspose.com/slides/th/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) เพื่อสร้าง handout master เริ่มต้น

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **ทำความเข้าใจขอบเขตและการสืบทอด**

เลือกผู้จัดการหัวกระดาษ/ส่วนท้ายที่ตรงกับขอบเขตที่คุณต้องการเปลี่ยนแปลง:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/th/python-net/aspose.slides/slideheaderfootermanager/) เปลี่ยนการตั้งค่าส่วนท้าย วันที่/เวลา และหมายเลขสไลด์สำหรับสไลด์ปกติหนึ่งสไลด์
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslideheaderfootermanager/) ควบคุมสไลด์เค้าโครงและสามารถกระจายการตั้งค่าที่รองรับไปยังสไลด์ที่ขึ้นกับได้
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslideheaderfootermanager/) ควบคุม master ของสไลด์ปกติและสามารถกระจายการตั้งค่าที่รองรับไปยังสไลด์ที่ขึ้นกับได้
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/python-net/aspose.slides/masternotesslideheaderfootermanager/) ควบคุม notes master และสามารถกระจายการตั้งค่าไปยัง notes slide ลูกทั้งหมด
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/python-net/aspose.slides/notesslideheaderfootermanager/) เปลี่ยน notes slide หนึ่งสไลด์และสนับสนุนตำแหน่งหัวกระดาษเพิ่มเติมจากส่วนท้าย วันที่/เวลา และหมายเลขสไลด์
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) เปลี่ยน handout master และสนับสนุนตำแหน่งสี่ประเภททั้งหมด

ใช้การกระจายจาก master หรือ layout เมื่อการตั้งค่าเดียวกันควรใช้ทั่วทั้งลำดับชั้น ใช้ผู้จัดการสไลด์หรือ notes-slide รายบุคคลเมื่อคุณต้องการการตั้งค่าเฉพาะสำหรับหนึ่งหน้า

## **คำถามที่พบบ่อย**

**ฉันสามารถเพิ่มหัวกระดาษให้กับสไลด์ปกติได้หรือไม่?**

ไม่ได้ PowerPoint ไม่ได้กำหนดตำแหน่งหัวกระดาษสำหรับสไลด์ปกติ บนสไลด์ปกติให้ใช้ส่วนท้าย วันที่/เวลา และหมายเลขสไลด์ ส่วนหัวกระดาษพร้อมใช้งานบนหน้าบันทึกย่อและ handout

**ถ้าตำแหน่งส่วนท้าย วันที่/เวลา หรือหมายเลขสไลด์ไม่มองเห็นควรทำอย่างไร?**

ใช้ผู้จัดการหัวกระดาษ/ส่วนท้ายที่สอดคล้องกันเพื่อตรวจสอบการมองเห็นและเปิดใช้งานเมื่อจำเป็น ตัวอย่างเช่น [`is_footer_visible`](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) รายงานว่าตำแหน่งส่วนท้ายปรากฏหรือไม่ และ [`set_footer_visibility`](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) เปลี่ยนการมองเห็นของมัน

**ฉันจะเริ่มต้นการนับหมายเลขสไลด์จากค่าที่ไม่ใช่ 1 ได้อย่างไร?**

ตั้งค่าคุณสมบัติ [`first_slide_number`](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/first_slide_number/) ของการนำเสนอแล้วตำแหน่งหมายเลขสไลด์จะใช้ลำดับหมายเลขที่อัปเดตนั้น

**หัวกระดาษและส่วนท้ายจะเป็นอย่างไรเมื่อส่งออกเป็น PDF ภาพหรือ HTML?**

องค์ประกอบหัวกระดาษและส่วนท้ายที่มองเห็นจะถูกรวมกับเนื้อหาอื่นของการนำเสนอในรูปแบบเอาต์พุต การแสดงผลขึ้นอยู่กับประเภทหน้าที่กำลังส่งออกและการตั้งค่าการมองเห็นของตำแหน่งที่สอดคล้องกัน