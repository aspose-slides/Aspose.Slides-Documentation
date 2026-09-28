---
title: ใช้หรือเปลี่ยนเลย์เอาต์สไลด์ใน Python
linktitle: เลย์เอาต์สไลด์
type: docs
weight: 60
url: /th/python-net/slide-layout/
keywords:
- เลย์เอาต์สไลด์
- เลย์เอาต์เนื้อหา
- ส่วนจัดตำแหน่ง
- การออกแบบการนำเสนอ
- การออกแบบสไลด์
- เลย์เอาต์ที่ไม่ได้ใช้
- การแสดงผลส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- หัวข้อส่วน
- สองเนื้อหา
- การเปรียบเทียบ
- หัวเรื่องเท่านั้น
- เลย์เอาต์เปล่า
- เนื้อหาพร้อมคำอธิบาย
- รูปภาพพร้อมคำอธิบาย
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ใช้, สร้าง, และแก้ไขเลย์เอาต์สไลด์ใน Aspose.Slides สำหรับ Python ผ่าน .NET, เพิ่มส่วนจัดตำแหน่ง, ลบเลย์เอาต์ที่ไม่ได้ใช้, และควบคุมการแสดงผลส่วนท้าย."
---
## **ภาพรวม**

เลย์เอาต์สไลด์กำหนดตำแหน่งและการจัดรูปแบบของส่วนจัดตำแหน่งเช่น ชื่อเรื่อง, ข้อความ, รูปภาพ, แผนภูมิ, และตาราง การใช้เลย์เอาต์ทำให้สไลด์มีโครงสร้างสอดคล้องกันขณะยังคงให้แต่ละสไลด์มีเนื้อหาเป็นของตนเอง

เลย์เอาต์ที่พบบ่อยที่สุดรวมถึง:

- **Title Slide**: มีส่วนจัดตำแหน่งชื่อเรื่องและชื่อเรื่องย่อย
- **Title and Content**: มีส่วนจัดตำแหน่งชื่อเรื่องและส่วนจัดตำแหน่งเนื้อหาทั่วไป
- **Blank**: ไม่มีส่วนจัดตำแหน่งเนื้อหาและเหมาะสมเมื่อทุกรูปร่างจะถูกจัดตำแหน่งด้วยตนเอง

## **เข้าใจการสืบทอดเลย์เอาต์**

การนำเสนอมีระดับที่เกี่ยวข้องสามระดับ:

1. A [master slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslide/) กำหนดธีม, การจัดรูปแบบที่ใช้ร่วมกัน, พื้นหลัง, และวัตถุทั่วไป
1. A [layout slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/) เป็นของมาสเตอร์และกำหนดการจัดเรียงส่วนจัดตำแหน่งเฉพาะ
1. A [normal slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/) ใช้เลย์เอาต์เดียวและเก็บเนื้อหาที่กรอกสำหรับสไลด์นั้น

สไลด์ปกติจะสืบทอดธีมและการจัดรูปแบบจากเลย์เอาต์ของมัน, และเลย์เอต์จะสืบทอดจากมาสเตอร์ ค่าใดที่ตั้งโดยตรงบนสไลด์ปกติจะทับค่าที่สืบทอดจากระดับนั้น เมื่อสร้างสไลด์ปกติ, รูปร่างส่วนจัดตำแหน่งของมันจะถูกสร้างจากเลย์เออต์ที่เลือก, ขณะที่เนื้อหาที่กรอกในส่วนจัดตำแหน่งเหล่านั้นเป็นของสไลด์ปกติ

เพิ่มส่วนจัดตำแหน่งที่จำเป็นลงในเลย์เออต์ก่อนสร้างสไลด์จากมัน การเพิ่มส่วนจัดตำแหน่งใหม่ในภายหลังจะไม่เพิ่มรูปร่างส่วนจัดตำแหน่งที่สอดคล้องให้กับสไลด์ปกติที่มีอยู่โดยอัตโนมัติ

ความสัมพันธ์นี้มีผลสำคัญสองประการ:

- การเปลี่ยนการจัดรูปแบบที่สืบทอดหรือรูปทรงของส่วนจัดตำแหน่งที่มีอยู่ในเลย์เออต์สามารถอัปเดตทุกสไลด์ที่พึ่งพาไปได้ ก่อนแก้ไขเลย์เอาต์ที่ใช้งานอยู่แล้ว, ควรตรวจสอบสไลด์ที่พึ่งพาและทบทวนการนำเสนอที่ได้
- เลย์เอาต์ที่ยังคงถูกสไลด์ใช้งานอยู่ไม่สามารถลบได้ ต้องย้ายสไลด์ที่พึ่งพาไปยังเลย์เอาต์อื่นก่อน, หรือเลือกลบเฉพาะเลย์เอาต์ที่ไม่มีการใช้งาน

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนของลำดับชั้นนี้, ดู [Slide Master](/slides/th/python-net/slide-master/)

เพื่อซ่อนโลโก้หรือรูปกราฟิกมาสเตอร์ที่สืบทอดบนสไลด์หนึ่งหรือผ่านเลย์เอาต์ที่ใช้ร่วมกัน, ดู [Control the Visibility of Master Graphics](/slides/th/python-net/slide-master/). ตัวอย่างเปรียบเทียบสองสไลด์ที่ใช้มาสเตอร์เดียวกัน

## **เลือกและใช้เลย์เอาต์สไลด์**

ใช้ประเภทเลย์เอาต์เมื่อการนำเสนอปฏิบัติตามคำนิยามเลย์เอาต์มาตรฐานของ PowerPoint ชื่อเลย์เอาต์สามารถแก้ไขได้โดยผู้ใช้และอาจแปลเป็นภาษาต่าง ๆ ดังนั้นการเลือกโดยอิงชื่อจึงน่าเชื่อถือน้อยลง เว้นแต่คุณจะควบคุมแม่แบบต้นฉบับ

ตัวอย่างต่อไปนี้ค้นหา **Title and Content** ในมาสเตอร์แรก หากเลย์เอาต์นั้นไม่มีอยู่, จะย้อนกลับไปใช้ **Blank** อย่างเจตนา การตรวจสอบค่า null ครั้งที่สองจำเป็นเพราะการนำเสนออาจมีเฉพาะเลย์เอาต์แบบกำหนดเองเท่านั้น เลย์เออต์ที่เลือกจากนั้นจะถูกนำไปใช้กับสไลด์ปกติแรกผ่านคุณสมบัติ [Slide.layout_slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/layout_slide/)

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

การเปลี่ยนเลย์เอาต์ของสไลด์จะไม่ลบรูปร่างปกติที่เพิ่มโดยตรงลงในสไลด์ อย่างไรก็ตาม ตำแหน่งส่วนจัดตำแหน่ง, การจัดรูปแบบที่สืบทอด, และความสอดคล้องระหว่างส่วนจัดตำแหน่งที่มีอยู่กับเลย์เออต์ใหม่อาจเปลี่ยนแปลงได้ ดังนั้นควรตรวจสอบผลลัพธ์เมื่อสลับระหว่างเลย์เอาต์ที่ต่างกันอย่างมีนัยสำคัญ

## **เพิ่มเลย์เอาต์สไลด์**

การเลือกและการสร้างเป็นขั้นตอนแยกกัน ตัวอย่างก่อนหน้านี้เลือกเลย์เอาต์ที่มีอยู่; ไม่ได้สร้างใหม่ เพื่อสร้างเลย์เอาต์, เรียกเมธอด [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterlayoutslidecollection/add/) บนคอลเลกชันเลย์เออต์ของมาสเตอร์เป้าหมาย

ตัวอย่างต่อไปนี้จะเพิ่มเลย์เอาต์ **Title and Content** ใหม่ชื่อ `Report Title and Content` เสมอ, จากนั้นเพิ่มสไลด์ปกติที่อิงจากเลย์เอาต์นั้น ชื่อเลย์เอาต์ต้องไม่ซ้ำกันในคอลเลกชัน

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

เพิ่มเลย์เอาต์เฉพาะเมื่อแม่แบบต้องการโครงสร้างที่ใช้ซ้ำได้จริง หากมีเลย์เอาต์ที่เหมาะสมอยู่แล้ว ให้เลือกและนำกลับมาใช้แทนการสร้างสำเนาใหม่

## **เพิ่มส่วนจัดตำแหน่งลงในเลย์เอาต์สไลด์**

คุณสมบัติ [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/placeholder_manager/) ให้บริการ [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/) สำหรับเพิ่มรูปร่างส่วนจัดตำแหน่งลงในเลย์เอาต์

| PowerPoint Placeholder              | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![Content](content.png)             | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Content (Vertical)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Text](text.png)                   | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Text (Vertical)](textV.png)       | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Picture](picture.png)             | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Chart](chart.png)                 | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Table](table.png)                 | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)           | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png)                 | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online Image](onlineImage.png)    | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

ตัวอย่างต่อไปนี้ตรวจสอบว่าเลย์เอาต์ **Blank** มีอยู่, เพิ่มส่วนจัดตำแหน่งสี่รายการลงในนั้น, แล้วสร้างสไลด์ปกติที่ใช้เลย์เอาต์ที่แก้ไขแล้ว การจัดลำดับเป็นเจตนา: ส่วนจัดตำแหน่งจะถูกเพิ่มก่อนสร้างสไลด์ปกติ, เพื่อให้ Aspose.Slides สามารถสร้างรูปร่างส่วนจัดตำแหน่งที่สอดคล้องบนสไลด์นั้นได้

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
การเปลี่ยนการจัดรูปแบบที่สืบทอดหรือรูปทรงของส่วนจัดตำแหน่งเลย์เออต์ที่มีอยู่สามารถส่งผลต่อสไลด์ที่พึ่งพาได้ ส่วนจัดตำแหน่งเลย์เออต์ที่เพิ่มใหม่จะไม่ถูกเติมกลับเข้าไปในสไลด์ปกติที่มีอยู่แล้ว ให้ทดสอบการเปลี่ยนแปลงเลย์เอาต์บนสำเนาของการนำเสนอและตรวจสอบทุกสไลด์ที่พึ่งพา
{{% /alert %}}

## **ลบเลย์เอาต์สไลด์ที่ไม่ได้ใช้**

ใช้เมธอด [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) เพื่อลบเลย์เอาต์ที่ไม่มีสไลด์ปกติใดอ้างอิง เมธอดจะคงเลย์เอาต์ที่ยังใช้งานอยู่ไว้ไม่ถูกลบ

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

เพื่อคลีบเลย์เอาต์เฉพาะหนึ่งรายการ, ก่อนอื่นให้ตรวจสอบคุณสมบัติ [has_depending_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/has_depending_slides/) หรือเมธอด [get_depending_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/get_depending_slides/) ของมัน ย้ายสไลด์ที่พึ่งพาใด ๆ ก่อนเรียก [LayoutSlide.remove](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/remove/) การพยายามลบเลย์เออต์ที่กำลังถูกใช้จะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/python-net/aspose.slides/pptxeditexception/)

## **ควบคุมการแสดงผล Footer บนเลย์เอาต์สไลด์**

เลย์เอาต์มี Footer, ตัวเลขสไลด์, และส่วนจัดตำแหน่งวันที่/เวลา ของตนเอง ใช้คุณสมบัติ [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/header_footer_manager/) เพื่อควบคุมส่วนจัดตำแหน่งเหล่านี้สำหรับเลย์เอาต์หนึ่ง นี่เป็นประโยชน์เมื่อเช่น เลย์เอาต์เนื้อหาควรแสดง Footer แต่เลย์เอาต์ชื่อเรื่องไม่ควรแสดง

ตัวอย่างต่อไปนี้เลือกเลย์เอาต์อย่างปลอดภัยและทำให้ส่วน Footer ของมันแสดงผล

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

## **ควบคุมการแสดงผล Footer บนมาสเตอร์และเลย์เออต์ลูกของมัน**

เพื่อให้ตั้งค่า Footer สอดคล้องกันทั่วทั้งลำดับชั้นมาสเตอร์, ใช้คุณสมบัติ [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslide/header_footer_manager/) วิธีการแพร่กระจายของ [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslideheaderfootermanager/) ทำงานกับมาสเตอร์, เลย์เออต์สไลด์ที่พึ่งพา, และสไลด์ปกติ; ไม่ได้จำกัดเพียงสไลด์ปกติเดียว

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

## **FAQ**

**ความแตกต่างระหว่าง Master Slide กับ Layout Slide คืออะไร?**

มาสเตอร์สไลด์กำหนดธีมและการจัดรูปแบบที่ใช้ร่วมกันของการนำเสนอ เลย์เอาต์สไลด์เป็นของมาสเตอร์และกำหนดการจัดเรียงส่วนจัดตำแหน่งที่ใช้ซ้ำได้ สไลด์ปกติใช้เลย์เอาต์เหล่านั้นและเก็บเนื้อหาเฉพาะสไลด์

**ฉันสามารถคัดลอก Layout Slide จากการนำเสนอหนึ่งไปยังอีกการนำเสนอได้หรือไม่?**

ได้. ใช้เมธอด [add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/globallayoutslidecollection/add_clone/) เพื่อเพิ่มสำเนาไปยังคอลเลกชันปลายทาง เมื่อคัดลอกจากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่ง ควรตรวจสอบฟอนต์, ธีม, รูปภาพ, และทรัพยากรอื่น ๆ ที่ใช้โดยเลย์เอาต์ต้นทางด้วย

**จะเกิดอะไรขึ้นเมื่อฉันแก้ไขเลย์เอาต์ที่กำลังใช้งานอยู่?**

สไลด์ที่พึ่งพาจะสืบทอดการเปลี่ยนแปลงของเลย์เอาต์ เว้นแต่จะมีการทับค่าการจัดรูปแบบหรือวัตถุที่เกี่ยวข้องในระดับสไลด์เอง รูปร่างส่วนจัดตำแหน่งและการจัดสไตล์ที่สืบทอดจึงอาจเปลี่ยนแปลงบนหลายสไลด์พร้อมกัน ใช้ [get_depending_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/get_depending_slides/) เพื่อระบุสไลด์ที่ได้รับผลกระทบก่อนแก้ไขเลย์เอาต์

**จะเกิดอะไรขึ้นหากฉันลบเลย์เออต์ที่ยังคงถูกใช้?**

Aspose.Slides จะโยน [PptxEditException](https://reference.aspose.com/slides/th/python-net/aspose.slides/pptxeditexception/) ให้ย้ายสไลด์ที่พึ่งพาออกก่อน, หรือใช้ [remove_unused_layout_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) เพื่อลบเฉพาะเลย์เออต์ที่ไม่มีการอ้างอิงเท่านั้น