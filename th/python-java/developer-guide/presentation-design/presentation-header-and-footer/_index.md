---
title: จัดการส่วนหัวและส่วนท้ายของการนำเสนอใน Python ผ่าน Java
linktitle: ส่วนหัวและส่วนท้าย
type: docs
weight: 140
url: /th/python-java/presentation-header-and-footer/
keywords:
- ส่วนหัว
- ข้อความส่วนหัว
- ส่วนท้าย
- ข้อความส่วนท้าย
- ตั้งส่วนหัว
- ตั้งส่วนท้าย
- เอกสารแจกมือ
- บันทึก
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการตัวเติมส่วนท้าย, วันที่-เวลา, หมายเลขสไลด์, และส่วนหัวบนสไลด์, หน้าบันทึก, และเอกสารแจกมือด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **Overview**

PowerPoint ใช้ตัวเติมหัวกระดาษและท้ายกระดาษที่แตกต่างกันตามประเภทของหน้า Aspose.Slides for Python via Java ให้คุณควบคุมข้อความและการมองเห็นของตัวเติมเหล่านี้ผ่านคลาสผู้จัดการหัวกระดาษ/ท้ายกระดาษ

ตัวเติมที่มีให้ใช้ขึ้นอยู่กับขอบเขต:

| Scope | Header | Footer | Date/time | Slide/page number |
|---|---|---|---|---|
| Regular slide | No | Yes | Yes | Yes |
| Notes master | Yes | Yes | Yes | Yes |
| Notes slide | Yes | Yes | Yes | Yes |
| Handout master | Yes | Yes | Yes | Yes |

สไลด์นำเสนอปกติไม่มีตัวเติมหัวกระดาษ หัวกระดาษจะปรากฏบนหน้าบันทึกและเอกสารแจกมือ สำหรับสไลด์ปกติให้ใช้ตัวเติมท้ายกระดาษ, วันที่/เวลา, และหมายเลขสไลด์แทน

ขอบเขตของการเปลี่ยนแปลงขึ้นอยู่กับผู้จัดการที่คุณใช้ คลาส [SlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideheaderfootermanager/) ควบคุมสไลด์ปกติหนึ่งสไลด์ คลาส [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/notesslideheaderfootermanager/) ควบคุมสไลด์บันทึกหนึ่งสไลด์ ผู้จัดการมาสเตอร์และเลย์เอาต์ยังสามารถกระจายการตั้งค่าให้กับสไลด์ที่ขึ้นกับได้ ในขณะที่คลาส [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) ควบคุมมาสเตอร์เอกสารแจกมือ

## **Set Footer, Date/Time, and Slide Numbers on Regular Slides**

สำหรับสไลด์ปกติ กระบวนการพื้นฐานคือเข้าถึงผู้จัดการหัวกระดาษ/ท้ายกระดาษของแต่ละสไลด์ ตั้งข้อความท้ายกระดาษและวันที่/เวลา เปิดใช้งานตัวเติมที่ต้องการ แล้วบันทึกการนำเสนอ หมายเลขสไลด์สร้างโดยการนำเสนอเอง ดังนั้นคุณเพียงแค่ควบคุมการมองเห็นของมัน

ใช้ [setFooterText](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) และ [setDateTimeText](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) เพื่อกำหนดข้อความ และใช้ [setFooterVisibility](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) และ [setSlideNumberVisibility](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) เพื่อแสดงตัวเติมที่สอดคล้องกัน

ตัวอย่างต่อไปนี้เป็นการประมวลผลแบบครบวงจร ที่ใช้ท้ายกระดาษ, ข้อความวันที่/เวลา, และการมองเห็นหมายเลขสไลด์เดียวกันกับสไลด์ปกติทั้งหมด:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

หากต้องการอัปเดตเพียงสไลด์เดียว ให้เข้าถึงสไลด์นั้นโดยตรงผ่านเมธอด [getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlides) แทนการวนลูปผ่านคอลเลกชันทั้งหมด

## **Set Headers and Footers on the Notes Master**

มาสเตอร์บันทึกกำหนดรูปแบบทั่วไปและพฤติกรรมของตัวเติมสำหรับหน้าบันทึก ใช้คลาส [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslideheaderfootermanager/) เมื่อคุณต้องการเปลี่ยนแปลงเฉพาะมาสเตอร์บันทึกเท่านั้น

ตัวอย่างต่อไปนี้ตั้งหัวกระดาษ, ท้ายกระดาษ, และข้อความวันที่/เวลา บนมาสเตอร์บันทึกและทำให้ตัวเติมที่รองรับทั้งหมดมองเห็นได้บนมาสเตอร์นั้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เมธอด `getMasterNotesSlide` จะคืนค่า `None` หากการนำเสนอไม่มีมาสเตอร์บันทึก

## **Apply Notes Master Settings to Child Notes Slides**

มาสเตอร์บันทึกสามารถนำการตั้งค่าหัวกระดาษและท้ายกระดาษไปใช้กับตนเองและสไลด์บันทึกที่ขึ้นกับทั้งหมด ใช้เมธอดการกระจายเฉพาะบน [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslideheaderfootermanager/) เมื่อต้องการให้การตั้งค่าเดียวกันถูกนำไปใช้ทั่วทั้งลำดับบันทึก

เช่นเมธอด [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) และ [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) จะอัปเดตหัวกระดาษของมาสเตอร์บันทึกและหัวกระดาษของสไลด์ลูกทั้งหมด เมธอดที่เทียบเท่ามีให้สำหรับท้ายกระดาษ, วันที่/เวลา, และหมายเลขสไลด์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เมธอดการกระจายที่ใช้ด้านบนคือ [setFooterAndChildFootersText](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility), และ [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility)

## **Set Headers and Footers on an Individual Notes Slide**

สไลด์บันทึกเป็นส่วนของสไลด์ปกติหนึ่งสไลด์ ใช้คลาส [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/notesslideheaderfootermanager/) เมื่อคุณต้องการปรับแต่งเพียงหน้าบันทึกนั้นเท่านั้น

เมธอด [addNotesSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/notesslidemanager/#addNotesSlide) คืนค่าสไลด์บันทึกสำหรับสไลด์ปัจจุบันและสร้างขึ้นใหม่หากยังไม่มี ตัวอย่างต่อไปนี้กำหนดค่าหน้าบันทึกที่เชื่อมกับสไลด์แรกของการนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

หากคุณกระจายการตั้งค่าจากมาสเตอร์บันทึกก่อน แล้วจึงเปลี่ยนสไลด์บันทึกแต่ละอัน การตั้งค่าตามสไลด์ในภายหลังจะทำให้คุณปรับแต่งหน้าบันทึกนั้นได้อย่างอิสระ

## **Set Headers and Footers on the Handout Master**

หน้ากระดาษแจกมือใช้มาสเตอร์เอกสารแจกมือสำหรับตัวเติมหัวกระดาษ, ท้ายกระดาษ, วันที่/เวลา, และหมายเลขหน้า ต่างจากหน้าบันทึก การตั้งค่าเอกสารแจกมือจัดการผ่านมาสเตอร์เอกสารแจกมือ ไม่ใช่ผ่านสไลด์เอกสารแจกมือแยกแต่ละอัน

ใช้เมธอด `getMasterHandoutSlide` เพื่อเข้าถึงมาสเตอร์เอกสารแจกมือ หากไม่มี ให้เรียก `setDefaultMasterHandoutSlide` เพื่อสร้างมาสเตอร์เอกสารแจกมือเริ่มต้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Understand Scope and Inheritance**

เลือกผู้จัดการหัวกระดาษ/ท้ายกระดาษที่ตรงกับขอบเขตที่คุณต้องการเปลี่ยนแปลง:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideheaderfootermanager/) เปลี่ยนการตั้งค่าท้ายกระดาษ, วันที่/เวลา, และหมายเลขสไลด์สำหรับสไลด์ปกติหนึ่งสไลด์
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslideheaderfootermanager/) ควบคุมสไลด์เลย์เอาต์และสามารถกระจายการตั้งค่าที่รองรับไปยังสไลด์ที่ขึ้นกับได้
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslideheaderfootermanager/) ควบคุมมาสเตอร์สไลด์ปกติและสามารถกระจายการตั้งค่าที่รองรับไปยังสไลด์ที่ขึ้นกับได้
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslideheaderfootermanager/) ควบคุมมาสเตอร์บันทึกและสามารถกระจายการตั้งค่าไปยังสไลด์บันทึกที่ขึ้นกับทั้งหมด
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/notesslideheaderfootermanager/) เปลี่ยนสไลด์บันทึกหนึ่งสไลด์และสนับสนุนตัวเติมหัวกระดาษนอกเหนือจากท้ายกระดาษ, วันที่/เวลา, และหมายเลขสไลด์
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) เปลี่ยนมาสเตอร์เอกสารแจกมือและสนับสนุนตัวเติมสี่ประเภททั้งหมด

ใช้การกระจายจากมาสเตอร์หรือเลย์เอาต์เมื่อการตั้งค่าเดียวกันควรใช้ทั่วทั้งลำดับชั้น ใช้ผู้จัดการสไลด์หรือสไลด์บันทึกแบบแยกเมื่อคุณต้องการการตั้งค่าท้องถิ่นสำหรับหนึ่งหน้า

## **FAQ**

**Can I add a header to a regular slide?**

No. PowerPoint does not define a header placeholder for regular slides. On regular slides, use the footer, date/time, and slide-number placeholders. Header placeholders are available on notes pages and handouts.

**What if a footer, date/time, or slide-number placeholder is not visible?**

Use the corresponding header/footer manager to check its visibility and enable it when needed. For example, [isFooterVisible](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) reports whether a footer placeholder is present, and [setFooterVisibility](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) changes its visibility.

**How do I start slide numbering from a value other than 1?**

Call the presentation's [setFirstSlideNumber](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#setFirstSlideNumber) method. The slide-number placeholders then use the updated numbering sequence.

**What happens to headers and footers when exporting to PDF, images, or HTML?**

Visible header and footer elements are rendered with the rest of the presentation content in the output format. Their appearance depends on the page type being exported and the corresponding placeholder visibility settings.