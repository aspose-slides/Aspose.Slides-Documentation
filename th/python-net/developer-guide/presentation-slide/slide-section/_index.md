---
title: จัดการส่วนสไลด์ในงานนำเสนอด้วย Python
linktitle: ส่วนสไลด์
type: docs
weight: 100
url: /th/python-net/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- ดึงสไลด์ส่วน
- ประมวลผลสไลด์ส่วน
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการส่วนสไลด์ด้วย Aspose.Slides for Python via .NET: สร้าง, เปลี่ยนชื่อ, จัดลำดับใหม่, ดึงข้อมูล, และประมวลผลสไลด์ส่วนในงานนำเสนอ PPTX."
---
## **บทนำ**

ส่วนจัดระเบียบสไลด์ต่อเนื่องเป็นกลุ่มที่มีชื่อโดยไม่เปลี่ยนแปลงเนื้อหาของสไลด์. ด้วย Aspose.Slides for Python via .NET คุณสามารถสร้าง, เปลี่ยนลำดับ, ตั้งชื่อใหม่, ตรวจสอบและลบส่วนได้ผ่านคุณสมบัติ [Presentation.sections](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/sections/)  

ส่วนมีประโยชน์เป็นพิเศษเมื่อ:

- งานนำเสนอขนาดใหญ่ต้องแบ่งเป็นหัวข้อหรือบทที่มีตรรกะ;
- กลุ่มสไลด์ต่าง ๆ ถูกมอบหมายให้ผู้ร่วมงานคนต่างกัน;
- สไลด์ต้องได้รับการประมวลผล, ย้ายหรือรวมเป็นกลุ่ม.

เลือกชื่อส่วนที่กระชับและอธิบายวัตถุประสงค์ของสไลด์ที่จัดกลุ่ม. เนื่องจากส่วนเป็นส่วนหนึ่งของโครงสร้างงานนำเสนอ, ให้ใช้ API ของส่วนเพื่อระบุตำแหน่งสมาชิกแทนการคำนวณจากตำแหน่งสไลด์.

## **สร้างและจัดการส่วน**

ใช้ [SectionCollection.add_section](https://reference.aspose.com/slides/th/python-net/aspose.slides/sectioncollection/add_section/) เพื่อสร้างส่วนโดยระบุชื่อและสไลด์เริ่มต้น. Aspose.Slides กำหนดว่าสไลด์ใดเป็นของส่วนจากโครงสร้างส่วนของงานนำเสนอในปัจจุบัน.

[SectionCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/sectioncollection/) ยังทำให้คุณสามารถ:

- ย้ายส่วนพร้อมสไลด์ของมันโดยใช้ [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/);
- ลบเพียงคำนิยามส่วนด้วย [SectionCollection.remove_section](https://reference.aspose.com/slides/th/python-net/aspose.slides/sectioncollection/remove_section/), ซึ่งจะคงสไลด์ไว้;
- ลบส่วนพร้อมสไลด์ของมันด้วย [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/sectioncollection/remove_section_with_slides/);
- เพิ่มส่วนเปล่าที่ท้ายด้วย [SectionCollection.append_empty_section](https://reference.aspose.com/slides/th/python-net/aspose.slides/sectioncollection/append_empty_section/).

ตัวอย่างต่อไปสร้างสองส่วน, ย้ายหนึ่งส่วน, ลบมันพร้อมสไลด์, แล้วเพิ่มส่วนเปล่า:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

หลังการดำเนินการเหล่านี้, งานนำเสนอจะมีส่วน `Introduction` พร้อมสไลด์ของมันและส่วนเปล่า `Appendix`. ส่วน `Results` และสไลด์ของมันถูกลบออกแล้ว.

## **เปลี่ยนชื่อส่วน**

เพื่อเปลี่ยนชื่อส่วน, ตั้งค่าคุณสมบัติ [Section.name](https://reference.aspose.com/slides/th/python-net/aspose.slides/section/name/) ของมัน. สไลด์และตำแหน่งของส่วนจะคงเดิม.

ตัวอย่างต่อไปสร้างส่วนแล้วเปลี่ยนชื่อของมัน:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **ดึงสไลด์จากส่วน**

คุณสมบัติ [Presentation.sections](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/sections/) คืนค่า [SectionCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/sectioncollection/) ซึ่งคุณสามารถวนซ้ำได้. สำหรับแต่ละ [Section](https://reference.aspose.com/slides/th/python-net/aspose.slides/section/), เรียก [Section.get_slides_list_of_section](https://reference.aspose.com/slides/th/python-net/aspose.slides/section/get_slides_list_of_section/) เพื่อรับสไลด์ที่อยู่ในขณะนั้น. วิธีนี้คืนค่า [SectionSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/sectionslidecollection/), ที่ให้จำนวน, การเข้าถึงโดยดัชนี, และการวนซ้ำ.

ตัวอย่างต่อไปสร้างสองส่วนที่มีข้อมูลและหนึ่งส่วนเปล่า, แล้วพิมพ์ [name](https://reference.aspose.com/slides/th/python-net/aspose.slides/section/name/), [identifier](https://reference.aspose.com/slides/th/python-net/aspose.slides/section/section_id/), [starting slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/section/started_from_slide/), จำนวนสไลด์, และหมายเลขสไลด์ของแต่ละส่วน. ตัวอย่างใช้การเข้าถึงโดยดัชนีเพื่ออ่านสไลด์แรกและลูป `for` เพื่อประมวลผลทุกสไลด์. สำหรับส่วนเปล่า, คอลเลกชันที่คืนค่ามีจำนวนเป็นศูนย์, ดัชนีไม่ถูกเข้าถึง, และการวนซ้ำไม่มีขั้นตอนใด ๆ.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

สมาชิกของส่วนถูกกำหนดโดยโครงสร้างส่วนของงานนำเสนอ. อย่าคำนวณช่วงของส่วนด้วยตนเองจาก [Section.started_from_slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/section/started_from_slide/), ดัชนีสไลด์, และสไลด์เริ่มต้นของส่วนถัดไป.

การแก้ไขเชิงโครงสร้างอาจเปลี่ยนสไลด์ที่คืนค่าให้กับส่วนและหมายเลขสไลด์ของมัน. สิ่งนี้รวมถึงการจัดลำดับสไลด์ใหม่, การคัดลอกสไลด์เข้าไปในส่วน, การย้ายส่วนพร้อมสไลด์, การลบสไลด์, และการลบส่วน. ตัวอย่างต่อไปเรียก [Section.get_slides_list_of_section](https://reference.aspose.com/slides/th/python-net/aspose.slides/section/get_slides_list_of_section/) หลังการเปลี่ยนแปลงแต่ละครั้งแทนการถือสมมติฐานเกี่ยวกับขอบเขตเดิมของส่วน.

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

เรียก [Section.get_slides_list_of_section](https://reference.aspose.com/slides/th/python-net/aspose.slides/section/get_slides_list_of_section/) อีกครั้งทุกครั้งที่สไลด์หรือส่วนถูกจัดลำดับใหม่, คัดลอก, ย้าย, หรือลบ. วิธีนี้ทำให้การประมวลผลต่อมาสอดคล้องกับโครงสร้างงานนำเสนอปัจจุบัน.

รูปแบบ PPT (PowerPoint 97–2003) ไม่รักษาข้อมูลเมตาดาต้าของส่วน. ใช้กระบวนการนี้กับรูปแบบที่สนับสนุนส่วน, เช่น PPTX; การแปลงเป็น PPT จะลบโครงสร้างส่วนที่จำเป็นสำหรับการวนซ้ำต่อไป.

## **คำถามที่พบบ่อย**

**ส่วนจะยังคงอยู่เมื่บันทึกเป็นรูปแบบ PPT (PowerPoint 97–2003) หรือไม่?**

ไม่. รูปแบบ PPT ไม่สนับสนุนเมตาดาต้าของส่วน, ดังนั้นการจัดกลุ่มส่วนจะหายไปเมื่อบันทึกเป็น .ppt.

**สามารถทำให้ส่วนทั้งหมด “ซ่อน” ได้หรือไม่?**

ไม่. ส่วนไม่มีสถานะการมองเห็น. เพื่อซ่อนเนื้อหาให้ตั้งค่าคุณสมบัติ [Slide.hidden](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/hidden/) สำหรับแต่ละสไลด์ในส่วนนั้น.

**ฉันจะค้นหาส่วนที่มีสไลด์ใดสไลด์หนึ่งอยู่ได้อย่างไร?**

วนซ้ำผ่าน [Presentation.sections](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/sections/), เรียก [Section.get_slides_list_of_section](https://reference.aspose.com/slides/th/python-net/aspose.slides/section/get_slides_list_of_section/) สำหรับแต่ละส่วน, แล้วเปรียบเทียบสไลด์ที่คืนค่ากับสไลด์เป้าหมาย. สำหรับส่วนที่ไม่ว่าง, [Section.started_from_slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/section/started_from_slide/) ให้สไลด์แรก; สำหรับส่วนว่าง, จะคืนค่า `None`.