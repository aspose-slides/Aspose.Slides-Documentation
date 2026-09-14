---
title: จัดการส่วนสไลด์ในงานนำเสนอด้วย Python ผ่าน Java
linktitle: ส่วนสไลด์
type: docs
weight: 90
url: /th/python-java/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- ดึงสไลด์ของส่วน
- ประมวลผลสไลด์ของส่วน
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการส่วนสไลด์ด้วย Aspose.Slides สำหรับ Python ผ่าน Java: สร้าง, เปลี่ยนชื่อ, จัดลำดับใหม่, ดึงข้อมูล, และประมวลผลสไลด์ของส่วนในงานนำเสนอ PPTX."
---
## **บทนำ**

ส่วนจะจัดสไลด์ต่อเนื่องเป็นกลุ่มที่มีชื่อโดยไม่เปลี่ยนเนื้อหาของสไลด์. ด้วย Aspose.Slides สำหรับ Python ผ่าน Java คุณสามารถสร้าง, จัดลำดับใหม่, ตั้งชื่อใหม่, ตรวจสอบและลบส่วนได้ผ่านเมธอด [Presentation.getSections](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSections) 

ส่วนมีประโยชน์อย่างยิ่งเมื่อ:

- การนำเสนอขนาดใหญ่ต้องการแบ่งเป็นหัวข้อหรือบทที่มีความหมาย;
- กลุ่มสไลด์ต่าง ๆ ถูกมอบหมายให้กับผู้ร่วมงานคนต่าง ๆ;
- สไลด์ต้องการประมวลผล, ย้าย หรือรวมกันเป็นกลุ่ม.

เลือกชื่อส่วนที่สั้นกระชับและอธิบายวัตถุประสงค์ของสไลด์ที่จัดกลุ่ม together. เนื่องจากส่วนเป็นส่วนหนึ่งของโครงสร้างการนำเสนอ ให้ใช้ API ของส่วนเพื่อกำหนดสมาชิกแทนการคำนวณจากตำแหน่งสไลด์.

## **สร้างและจัดการส่วน**

ใช้ [SectionCollection.addSection](https://reference.aspose.com/slides/th/python-java/aspose.slides/sectioncollection/#addSection) เพื่อสร้างส่วนโดยระบุชื่อและสไลด์เริ่มต้น. Aspose.Slides จะกำหนดสไลด์ที่เป็นของส่วนจากโครงสร้างส่วนปัจจุบันของการนำเสนอ

[SectionCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/sectioncollection/) เดียวกันยังทำให้คุณสามารถ:

- ย้ายส่วนพร้อมกับสไลด์ของมันโดยใช้ [reorderSectionWithSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- ลบเพียงคำนิยามของส่วนด้วย [removeSection](https://reference.aspose.com/slides/th/python-java/aspose.slides/sectioncollection/#removeSection), ซึ่งจะคงสไลด์ไว้;
- ลบส่วนและสไลด์ของมันด้วย [removeSectionWithSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- เพิ่มส่วนว่างที่ส่วนท้ายด้วย [appendEmptySection](https://reference.aspose.com/slides/th/python-java/aspose.slides/sectioncollection/#appendEmptySection).

ตัวอย่างต่อไปนี้สร้างสองส่วน, ย้ายหนึ่งส่วน, ลบส่วนพร้อมกับสไลด์ของมัน, และเพิ่มส่วนว่างที่ส่วนท้าย:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

หลังจากดำเนินการเหล่านี้ การนำเสนอจะมีส่วน `Introduction` พร้อมสไลด์ของมันและส่วนว่าง `Appendix`. ส่วน `Results` และสไลด์ของมันได้ถูกลบออกไปแล้ว.

## **เปลี่ยนชื่อส่วน**

เพื่อเปลี่ยนชื่อส่วน, เรียกเมธอด [Section.setName](https://reference.aspose.com/slides/th/python-java/aspose.slides/section/#setName) ของส่วนนั้น. สไลด์และตำแหน่งของส่วนจะไม่เปลี่ยนแปลง

ตัวอย่างต่อไปนี้สร้างส่วนและเปลี่ยนชื่อของมัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **ดึงสไลด์จากส่วน**

เมธอด [Presentation.getSections](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSections) คืนค่า [SectionCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/sectioncollection/) ที่คุณสามารถวนซ้ำได้. สำหรับแต่ละ [Section](https://reference.aspose.com/slides/th/python-java/aspose.slides/section/), เรียก [Section.getSlidesListOfSection](https://reference.aspose.com/slides/th/python-java/aspose.slides/section/#getSlidesListOfSection) เพื่อรับสไลด์ที่ยังเป็นของส่วนนั้น. เมธอดจะคืนค่า [SectionSlideCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/sectionslidecollection/), ซึ่งให้จำนวน, การเข้าถึงตามดัชนี, และการวนซ้ำ

ตัวอย่างต่อไปนี้สร้างสองส่วนที่มีเนื้อหาและหนึ่งส่วนว่าง, แล้วพิมพ์ [name](https://reference.aspose.com/slides/th/python-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/th/python-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/th/python-java/aspose.slides/section/#getStartedFromSlide), จำนวนสไลด์, และหมายเลขสไลด์ของแต่ละส่วน. ตัวอย่างใช้ [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/th/python-java/aspose.slides/sectionslidecollection/#get_Item) เพื่ออ่านสไลด์แรกและใช้คำสั่ง `for` เพื่อประมวลผลสไลด์ทั้งหมด. สำหรับส่วนว่าง, คอลเลกชันที่คืนค่ามีขนาดเป็นศูนย์, เมธอดจะไม่ถูกเรียก, และการวนซ้ำจะไม่มีการทำงานใด ๆ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

การเป็นสมาชิกของส่วนถูกกำหนดโดยโครงสร้างส่วนของการนำเสนอ. อย่าคำนวนช่วงของส่วนด้วยตนเองจาก [Section.getStartedFromSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/section/#getStartedFromSlide), ดัชนีสไลด์, และสไลด์เริ่มต้นของส่วนถัดไป

การแก้ไขเชิงโครงสร้างอาจเปลี่ยนทั้งสไลด์ที่คืนค่าสำหรับส่วนและเลขลำดับสไลด์ของมัน. สิ่งนี้รวมถึงการจัดลำดับสไลด์ใหม่, การคัดลอกสไลด์เข้ามาในส่วน, การย้ายส่วนพร้อมสไลด์, การลบสไลด์, และการลบส่วน. ตัวอย่างต่อไปนี้เรียก [Section.getSlidesListOfSection](https://reference.aspose.com/slides/th/python-java/aspose.slides/section/#getSlidesListOfSection) หลังจากการเปลี่ยนแปลงแต่ละครั้งแทนการสันนิษฐานขอบเขตเดิมของส่วน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

เรียก [Section.getSlidesListOfSection](https://reference.aspose.com/slides/th/python-java/aspose.slides/section/#getSlidesListOfSection) อีกครั้งทุกครั้งที่สไลด์หรือส่วนถูกจัดลำดับใหม่, คัดลอก, ย้าย, หรือหลุดออก. วิธีนี้ทำให้การประมวลผลต่อไปสอดคล้องกับโครงสร้างการนำเสนอปัจจุบัน

รูปแบบ PPT (PowerPoint 97–2003) ไม่เก็บ metadata ของส่วน. ใช้ขั้นตอนนี้กับรูปแบบที่สนับสนุนส่วน, เช่น PPTX; การแปลงเป็น PPT จะลบโครงสร้างส่วนที่จำเป็นสำหรับการวนซ้ำในภายหลัง

## **คำถามที่พบบ่อย**

**ส่วนจะถูกเก็บไว้เมื่อตบลงเป็นรูปแบบ PPT (PowerPoint 97–2003) หรือไม่?**

ไม่. รูปแบบ PPT ไม่สนับสนุน metadata ของส่วน, ดังนั้นการจัดกลุ่มส่วนจะสูญหายเมื่อบันทึกเป็น .ppt

**สามารถซ่อนทั้งส่วนได้หรือไม่?**

ไม่. ส่วนไม่มีสถานะการมองเห็น. เพื่ ซ่อนเนื้อหาของมัน, ให้เรียก [Slide.setHidden](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#setHidden) สำหรับสไลด์แต่ละใบในส่วนนั้น

**ทำอย่างไรจึงจะหา section ที่ประกอบด้วยสไลด์ได้?**

วนซ้ำคอลเลกชันที่คืนค่าจาก [Presentation.getSections](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSections), เรียก [Section.getSlidesListOfSection](https://reference.aspose.com/slides/th/python-java/aspose.slides/section/#getSlidesListOfSection) สำหรับแต่ละส่วน, แล้วเปรียบเทียบสไลด์ที่ได้กับสไลด์เป้าหมาย. สำหรับส่วนที่ไม่ว่าง, [Section.getStartedFromSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/section/#getStartedFromSlide) จะคืนสไลด์แรก; สำหรับส่วนว่างจะคืนค่า `None`.