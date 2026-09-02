---
title: ใช้หรือเปลี่ยนเค้าโครงสไลด์ใน Python
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/python-net/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตัวรับ
- การออกแบบการนำเสนอ
- การออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การแสดงส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- ส่วนหัวของหัวข้อ
- สองเนื้อหา
- การเปรียบเทียบ
- หัวเรื่องเท่านั้น
- เค้าโครงว่าง
- เนื้อหาพร้อมคำอธิบายภาพ
- รูปภาพพร้อมคำอธิบายภาพ
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ใช้, สร้างและแก้ไขเค้าโครงสไลด์ใน Aspose.Slides สำหรับ Python ผ่าน .NET, เพิ่มตัวรับ, ลบเค้าโครงที่ไม่ได้ใช้, และควบคุมการแสดงส่วนท้าย."
---
## **ภาพรวม**

เค้าโครงสไลด์กำหนดตำแหน่งและการจัดรูปแบบของตัวรับเป็นเช่นหัวเรื่อง ข้อความ รูปภาพ แผนภูมิ และตาราง การใช้เค้าโครงทำให้สไลด์มีโครงสร้างที่สอดคล้องกันขณะยังให้สไลด์แต่ละอันสามารถมีเนื้อหาเป็นของตนเองได้

เค้าโครงที่พบบ่อยที่สุดได้แก่:

- **สไลด์หัวเรื่อง**: มีตัวรับหัวเรื่องและหัวเรื่องย่อย
- **หัวเรื่องและเนื้อหา**: มีตัวรับหัวเรื่องและตัวรับเนื้อหาทั่วไป
- **ว่าง**: ไม่มีตัวรับเนื้อหาและเหมาะเมื่อทุกรูปทรงจะถูกจัดตำแหน่งด้วยตนเอง

## **ทำความเข้าใจการสืบทอดเค้าโครง**

การนำเสนอมีระดับที่เกี่ยวข้องสามระดับ:

1. หน้า [master slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslide/) กำหนดธีม การจัดรูปแบบที่ใช้ร่วมกัน พื้นหลัง และวัตถุทั่วไป
2. หน้า [layout slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/) อยู่ภายใต้ master และกำหนดการจัดวางตัวรับเฉพาะ
3. หน้า [normal slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/) ใช้เค้าโครงหนึ่งและเก็บเนื้อหาที่ป้อนสำหรับสไลด์นั้น

สไลด์ปกติสืบทอดธีมและการจัดรูปแบบจากเค้าโครงของมัน และเค้าโครงสืบทอดจาก master ค่าที่ตั้งโดยตรงบนสไลด์ปกติจะแทนที่ค่าที่สืบทอดในระดับนั้น เมื่อสร้างสไลด์ปกติ รูปร่างของตัวรับจะสร้างจากเค้าโครงที่เลือก ขณะที่เนื้อหาที่ป้อนลงในตัวรับเหล่านั้นเป็นของสไลด์ปกติ

เพิ่มตัวรับที่จำเป็นลงในเค้าโครงก่อนสร้างสไลด์จากเค้าโครงนั้น การเพิ่มตัวรับอื่นลงในเค้าโครงภายหลังจะไม่ทำให้รูปร่างตัวรับที่สอดคล้องกันถูกเพิ่มอัตโนมัติในสไลด์ปกติที่มีอยู่แล้ว

ความสัมพันธ์นี้มีผลสืบเนื่องสำคัญสองประการ:

- การเปลี่ยนการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวรับที่มีอยู่บนเค้าโครงสามารถอัปเดตสไลด์ทุกสไลด์ที่พึ่งพาเค้าโครงนั้นได้ ก่อนแก้ไขเค้าโครงที่ใช้อยู่แล้วให้ตรวจสอบสไลด์ที่พึ่งพาและตรวจสอบผลลัพธ์ของการนำเสนอ
- เค้าโครงที่ยังถูกสไลด์ใช้งานอยู่ไม่สามารถลบได้ ต้องโอนสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อน หรือให้ลบเฉพาะเค้าโครงที่ไม่ได้ใช้เท่านั้น

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนสุดของโครงสร้างนี้ ดูที่ [Slide Master](/slides/th/python-net/slide-master/)

## **เลือกและใช้เค้าโครงสไลด์**

ใช้ประเภทเค้าโครงเมื่อการนำเสนอปฏิบัติตามคำนิยามเค้าโครงมาตรฐานของ PowerPoint ชื่อเค้าโครงสามารถแก้ไขได้โดยผู้ใช้และอาจแปลเป็นภาษาต่าง ๆ ดังนั้นการเลือกโดยชื่ออาจไม่น่าเชื่อถือถ้าไม่ได้ควบคุมเทมเพลตต้นฉบับ

ตัวอย่างต่อไปนี้มองหา **Title and Content** บน master แรก หากเค้าโครงนั้นไม่มีอยู่ ระบบจะย้อนกลับไปใช้ **Blank** อย่างตั้งใจ การตรวจสอบ null ครั้งที่สองจำเป็นเพราะการนำเสนออาจมีเฉพาะเค้าโครงที่กำหนดเองเท่านั้น เค้าโครงที่เลือกแล้วจะถูกนำไปใช้กับสไลด์ปกติแรกผ่านคุณสมบัติ [Slide.layout_slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/layout_slide/)

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

การเปลี่ยนเค้าโครงของสไลด์ไม่ได้ลบรูปร่างปกติที่เพิ่มโดยตรงบนสไลด์ อย่างไรก็ตามตำแหน่งของตัวรับ การจัดรูปแบบที่สืบทอด และความสัมพันธ์ระหว่างตัวรับที่มีอยู่กับเค้าโครงใหม่อาจเปลี่ยนแปลงได้ จึงควรตรวจสอบผลลัพธ์เมื่อสลับระหว่างเค้าโครงที่แตกต่างอย่างชัดเจน

## **เพิ่มเค้าโครงสไลด์**

การเลือกและการสร้างเป็นการดำเนินการแยกจากกัน ตัวอย่างก่อนหน้ากำหนดเค้าโครงที่มีอยู่; ไม่ได้สร้างเค้าโครงใหม่ เพื่อสร้างเค้าโครงให้เรียกเมธอด [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterlayoutslidecollection/add/) บนคอลเลกชันเค้าโครงของ master เป้าหมาย

ตัวอย่างต่อไปนี้จะเพิ่มเค้าโครง **Title and Content** ใหม่ที่ชื่อ `Report Title and Content` เสมอ จากนั้นเพิ่มสไลด์ปกติอ้างอิงเค้าโครงนั้น ชื่อเค้าโครงต้องไม่ซ้ำกันภายในคอลเลกชัน

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

เพิ่มเค้าโครงเฉพาะเมื่อเทมเพลตต้องการโครงสร้างที่นำกลับมาใช้ได้อีก ถ้าเค้าโครงที่เหมาะสมมีอยู่แล้วให้เลือกและใช้ซ้ำแทนการสร้างสำเนาใหม่

## **เพิ่มตัวรับในเค้าโครงสไลด์**

คุณสมบัติ [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/placeholder_manager/) ให้บริการ [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/) สำหรับเพิ่มรูปร่างตัวรับลงในเค้าโครง

| ตัวรับ PowerPoint | `LayoutPlaceholderManager` วิธี |
| ----------------- | ------------------------------ |
| ![เนื้อหา](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![เนื้อหา (แนวตั้ง)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![ข้อความ](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![ข้อความ (แนวตั้ง)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![รูปภาพ](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![แผนภูมิ](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![ตาราง](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![สื่อ](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![รูปภาพออนไลน์](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีเค้าโครง **Blank** อยู่แล้ว เพิ่มตัวรับสี่ตัวรับลงในเค้าโครงนั้น แล้วสร้างสไลด์ปกติที่ใช้เค้าโครงที่แก้ไขแล้ว ลำดับการทำงานตั้งใจให้เพิ่มตัวรับก่อนสร้างสไลด์ปกติ เพื่อให้ Aspose.Slides สามารถสร้างรูปร่างตัวรับที่สอดคล้องบนสไลด์นั้นได้

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ตัวรับบนเค้าโครงสไลด์](add_placeholders.png)

{{% alert color="warning" title="คำเตือน" %}}
การเปลี่ยนการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวรับเค้าโครงที่มีอยู่สามารถส่งผลต่อสไลด์ที่พึ่งพาได้ ตัวรับเค้าโครงที่เพิ่มใหม่จะไม่ถูกเติมกลับเข้าไปในสไลด์ปกติที่มีอยู่ก่อนหน้า ให้ทดลองเปลี่ยนเค้าโครงในสำเนาของการนำเสนอและตรวจสอบสไลด์ที่พึ่งพาทุกสไลด์
{{% /alert %}}

## **ลบเค้าโครงสไลด์ที่ไม่ได้ใช้**

ใช้เมธอด [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) เพื่อลบเค้าโครงที่ไม่มีสไลด์ปกติอ้างอิง เมธอดจะคงเค้าโครงที่ยังถูกใช้ไว้

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

เพื่อจะลบเค้าโครงเฉพาะหนึ่งให้ใช้คุณสมบัติ [has_depending_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/has_depending_slides/) หรือเมธอด [get_depending_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/get_depending_slides/) ก่อน แล้วโอนสไลด์ที่พึ่งพาใด ๆ ก่อนเรียกเมธอด [LayoutSlide.remove](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/remove/) การพยายามลบเค้าโครงที่ยังถูกใช้จะทำให้เกิดข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/python-net/aspose.slides/pptxeditexception/)

## **ควบคุมการแสดงส่วนท้ายบนเค้าโครงสไลด์**

เค้าโครงมีส่วนท้ายของตนเอง, ตัวรับเลขสไลด์, และตัวรับวันที่‑เวลา ใช้คุณสมบัติ [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/header_footer_manager/) เพื่อควบคุมตัวรับเหล่านั้นสำหรับเค้าโครงเดียว ตัวอย่างเช่น เค้าโครงเนื้อหาอาจต้องแสดงส่วนท้ายแต่เค้าโครงหัวเรื่องไม่ต้องแสดง

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **ควบคุมการแสดงส่วนท้ายบน Master และเค้าโครงลูกของมัน**

เพื่อให้การตั้งค่าส่วนท้ายสม่ำเสมอทั่วทั้งลำดับชั้นของ master ให้ใช้คุณสมบัติ [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslide/header_footer_manager/) วิธีการแพร่กระจายของ [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslideheaderfootermanager/) ทำงานกับ master, เค้าโครงที่พึ่งพา, และสไลด์ปกติ; ไม่ได้เจาะจงเพียงสไลด์ปกติเดียว

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง Master Slide กับ Layout Slide คืออะไร?**

Master Slide กำหนดธีมและการจัดรูปแบบที่ใช้ร่วมกันของการนำเสนอ Layout Slide อยู่ภายใต้ master และกำหนดการจัดวางตัวรับที่นำกลับมาใช้ได้ หนึ่งสไลด์ปกติใช้เค้าโครงเหล่านั้นและเก็บเนื้อหาเฉพาะสไลด์

**ฉันสามารถคัดลอก Layout Slide จากการนำเสนอหนึ่งไปยังการนำเสนออื่นได้หรือไม่?**

ทำได้ ให้เพิ่มสำเนาไปยังคอลเลกชันปลายทางด้วยเมธอด [add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/globallayoutslidecollection/add_clone/) เมื่อตัวลำดับคัดลอกจากการนำเสนอหนึ่งไปยังอีกอันหนึ่ง ควรตรวจสอบฟอนต์, ธีม, รูปภาพ และทรัพยากรอื่น ๆ ที่ใช้ในเค้าโครงต้นฉบับด้วย

**จะเกิดอะไรขึ้นเมื่อฉันแก้ไขเค้าโครงที่กำลังใช้งานอยู่?**

สไลด์ที่พึ่งพาจะสืบทอดการเปลี่ยนแปลงของเค้าโครงนั้น เว้นแต่จะมีการเขียนทับรูปแบบหรือวัตถุที่ได้รับผลกระทบไว้ในระดับสไลด์โดยตรง รูปร่างของตัวรับและสไตล์ที่สืบทอดอาจเปลี่ยนแปลงบนหลายสไลด์พร้อมกัน ใช้เมธอด [get_depending_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/get_depending_slides/) เพื่อระบุสไลด์ที่ได้รับผลกระทบก่อนแก้ไขเค้าโครง

**จะเกิดอะไรขึ้นหากฉันลบเค้าโครงที่ยังถูกใช้อยู่?**

Aspose.Slides จะโยงข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/python-net/aspose.slides/pptxeditexception/) ให้โอนสไลด์ที่พึ่งพาก่อน หรือใช้เมธอด [remove_unused_layout_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) เพื่อลบเฉพาะเค้าโครงที่ไม่มีการอ้างอิงเท่านั้น