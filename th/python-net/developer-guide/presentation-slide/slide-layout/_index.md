---
title: ใช้หรือเปลี่ยนเลย์เอาต์สไลด์ใน Python
linktitle: เลย์เอาต์สไลด์
type: docs
weight: 60
url: /th/python-net/slide-layout/
keywords:
- เลย์เอาต์สไลด์
- เลย์เอาต์เนื้อหา
- ตัวจัดตำแหน่ง
- การออกแบบงานนำเสนอ
- การออกแบบสไลด์
- เลย์เอาต์ที่ไม่ได้ใช้
- การมองเห็นส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- ส่วนหัวของหัวข้อ
- สองเนื้อหา
- การเปรียบเทียบ
- หัวเรื่องเท่านั้น
- เลย์เอาต์เปล่า
- เนื้อหาพร้อมคำบรรยาย
- รูปภาพพร้อมคำบรรยาย
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการและปรับแต่งเลย์เอาต์สไลด์ใน Aspose.Slides สำหรับ Python ผ่าน .NET สำรวจประเภทของเลย์เอาต์ การควบคุมตัวจัดตำแหน่ง การมองเห็นส่วนท้าย และการจัดการเลย์เอาต์โดยใช้ตัวอย่างโค้ดใน Python."
---
## **บทนำ**

เลย์เอาต์สไลด์กำหนดการจัดเรียงของกล่องตัวจัดตำแหน่งและรูปแบบของเนื้อหาบนสไลด์ มันควบคุมว่าตัวจัดตำแหน่งใดบ้างที่พร้อมใช้งานและปรากฏที่ไหน เลย์เอาต์สไลด์ช่วยให้คุณออกแบบงานนำเสนอได้อย่างรวดเร็วและสม่ำเสมอ—ไม่ว่าคุณจะสร้างสิ่งง่ายหรือซับซ้อนที่สุด ตัวอย่างของเลย์เอาต์สไลด์ที่พบบ่อยใน PowerPoint มีดังนี้:

**เลย์เอาต์สไลด์หัวเรื่อง** – มีตัวจัดตำแหน่งข้อความสองช่อง: หนึ่งสำหรับหัวเรื่องและอีกหนึ่งสำหรับหัวข้อย่อย

**เลย์เอาต์หัวเรื่องและเนื้อหา** – มีตัวจัดตำแหน่งหัวเรื่องขนาดเล็กที่ด้านบนและตัวจัดตำแหน่งเนื้อหาใหญ่ที่ด้านล่างสำหรับข้อความ, รายการหัวข้อย่อย, แผนภูมิ, รูปภาพ ฯลฯ

**เลย์เอาต์เปล่า** – ไม่มีตัวจัดตำแหน่งใด ๆ ให้คุณควบคุมการออกแบบสไลด์ตั้งแต่ต้นได้อย่างเต็มที่

เลย์เอาต์สไลด์เป็นส่วนหนึ่งของมาสเตอร์สไลด์ ซึ่งเป็นสไลด์ระดับบนสุดที่กำหนดรูปแบบเลย์เอาต์สำหรับงานนำเสนอทั้งหมด คุณสามารถเข้าถึงและแก้ไขเลย์เอาต์สไลด์ผ่านมาสเตอร์สไลด์—ไม่ว่าจะโดยประเภท, ชื่อ หรือรหัสเอกลักษณ์ หรือคุณอาจแก้ไขเลย์เอาต์สไลด์เฉพาะโดยตรงภายในงานนำเสนอ

เพื่อทำงานกับเลย์เอาต์สไลด์ใน Aspose.Slides for Python คุณสามารถใช้:

- Properties such as [layout_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/layout_slides/) and [masters](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/masters/) under the [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) class
- Types like [LayoutSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutplaceholdermanager/), and [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับการทำงานกับมาสเตอร์สไลด์ โปรดดูบทความ [Manage PowerPoint Slide Masters in Python](/slides/th/python-net/slide-master/) 
{{% /alert %}}

## **เพิ่มเลย์เอาต์สไลด์ลงในงานนำเสนอ**

เพื่อปรับแต่งรูปลักษณ์และโครงสร้างของสไลด์ของคุณ คุณอาจต้องเพิ่มเลย์เอาต์สไลด์ใหม่ลงในงานนำเสนอ Aspose.Slides for Python อนุญาตให้คุณตรวจสอบว่าเลย์เอาต์ที่ต้องการมีอยู่แล้วหรือไม่ หากไม่มีให้เพิ่มเลย์เอาต์สไลด์ที่ต้องการและใช้มันเพื่อแทรกสไลด์ตามเลย์เอาต์นั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
1. เข้าถึง [MasterLayoutSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterlayoutslidecollection/) 
1. ตรวจสอบว่าเลย์เอาต์สไลด์ที่ต้องการมีอยู่ในคอลเลกชันหรือยัง หากไม่มีให้เพิ่มเลย์เอาต์สไลด์ที่ต้องการ 
1. เพิ่มสไลด์เปล่าตามเลย์เอาต์สไลด์ใหม่ 
1. บันทึกงานนำเสนอ

โค้ด Python ต่อไปนี้แสดงวิธีเพิ่มเลย์เอาต์สไลด์ลงในงานนำเสนอ PowerPoint:

```python
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อเปิดไฟล์งานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:
    # ไปยังประเภทเลย์เอาต์สไลด์เพื่อเลือกเลย์เอาต์สไลด์.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # สถานการณ์ที่งานนำเสนอไม่มีประเภทเลย์เอาต์ทั้งหมด.
        # ไฟล์งานนำเสนอมีเฉพาะประเภทเลย์เอาต์ Blank และ Custom.
        # อย่างไรก็ตาม เลย์เอาต์สไลด์ประเภท custom อาจมีชื่อที่รู้จัก,
        # เช่น "Title", "Title and Content", เป็นต้น ซึ่งสามารถใช้เลือกเลย์เอาต์สไลด์ได้.
        # คุณสามารถอิงตามชุดประเภทรูปทรงตัวจัดตำแหน่งได้เช่นกัน.
        # ตัวอย่างเช่น สไลด์ Title ควรมีเฉพาะประเภทตัวจัดตำแหน่ง Title เท่านั้น เป็นต้น.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # เพิ่มสไลด์เปล่าโดยใช้เลย์เอาต์สไลด์ที่เพิ่มไว้.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบเลย์เอาต์สไลด์ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [remove_unused_layout_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) จากคลาส [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) เพื่อให้คุณสามารถลบเลย์เอาต์สไลด์ที่ไม่ต้องการและไม่ได้ใช้ได้

โค้ด Python ต่อไปนี้แสดงวิธีลบเลย์เอาต์สไลด์จากงานนำเสนอ PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มตัวจัดตำแหน่งลงในเลย์เอาต์สไลด์**

Aspose.Slides มีคุณสมบัติ [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/placeholder_manager/) ซึ่งช่วยให้คุณเพิ่มตัวจัดตำแหน่งใหม่ลงในเลย์เอาต์สไลด์

ผู้จัดการนี้มีเมธอดสำหรับประเภทตัวจัดตำแหน่งต่อไปนี้:

| Placeholder ของ PowerPoint | วิธีการของ LayoutPlaceholderManager |
| --------------------------- | ----------------------------------- |
| ![Content](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Content (Vertical)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Text](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Text (Vertical)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Picture](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Chart](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Table](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Online Image](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

โค้ด Python ต่อไปนี้แสดงวิธีเพิ่มรูปทรงตัวจัดตำแหน่งใหม่ลงในเลย์เอาต์สไลด์ Blank:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # รับเลย์เอาต์สไลด์ Blank.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # รับตัวจัดการตัวจัดตำแหน่งของเลย์เอาต์สไลด์.
    placeholder_manager = layout.placeholder_manager

    # เพิ่มตัวจัดตำแหน่งต่าง ๆ ลงในเลย์เอาต์สไลด์ Blank.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # เพิ่มสไลด์ใหม่ด้วยเลย์เอาต์ Blank.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The placeholders on the layout slide](add_placeholders.png)

## **ตั้งค่าการมองเห็นส่วนท้ายสำหรับเลย์เอาต์สไลด์**

ในงานนำเสนอ PowerPoint ส่วนท้ายเช่น วันที่, เลขสไลด์, และข้อความกำหนดเองสามารถแสดงหรือซ่อนตามเลย์เอาต์สไลด์ Aspose.Slides for Python อนุญาตให้คุณควบคุมการมองเห็นของตัวจัดตำแหน่งส่วนท้ายเหล่านี้ ซึ่งมีประโยชน์เมื่อคุณต้องการให้บางเลย์เอาต์แสดงข้อมูลส่วนท้ายขณะที่เลย์เอาต์อื่นคงความเรียบง่าย

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
1. รับอ้างอิงเลย์เอาต์สไลด์ตามดัชนีของมัน 
1. ตั้งค่าตัวจัดตำแหน่งส่วนท้ายสไลด์ให้แสดง 
1. ตั้งค่าตัวจัดตำแหน่งเลขสไลด์ให้แสดง 
1. ตั้งค่าตัวจัดตำแหน่งวันที่‑เวลาให้แสดง 
1. บันทึกงานนำเสนอ

โค้ด Python ต่อไปนี้แสดงวิธีตั้งค่าการมองเห็นของส่วนท้ายสไลด์และทำงานที่เกี่ยวข้อง:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **ตั้งค่าการมองเห็นส่วนท้ายของสไลด์ลูก**

ในงานนำเสนอ PowerPoint ส่วนท้ายเช่น วันที่, เลขสไลด์, และข้อความกำหนดเองสามารถควบคุมได้ที่ระดับมาสเตอร์สไลด์เพื่อความสอดคล้องทั่วทั้งเลย์เอาต์สไลด์ Aspose.Slides for Python ให้คุณตั้งค่าการมองเห็นและเนื้อหาของตัวจัดตำแหน่งส่วนท้ายเหล่านี้บนมาสเตอร์สไลด์และกระจายการตั้งค่าเหล่านั้นไปยังเลย์เอาต์สไลด์ลูกทั้งหมด วิธีนี้ทำให้ข้อมูลส่วนท้ายสอดคล้องกันตลอดงานนำเสนอ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
1. รับอ้างอิงมาสเตอร์สไลด์ตามดัชนีของมัน 
1. ตั้งค่าตัวจัดตำแหน่งส่วนท้ายของมาสเตอร์และสไลด์ลูกทั้งหมดให้แสดง 
1. ตั้งค่าตัวจัดตำแหน่งเลขสไลด์ของมาสเตอร์และสไลด์ลูกทั้งหมดให้แสดง 
1. ตั้งค่าตัวจัดตำแหน่งวันที่‑เวลาของมาสเตอร์และสไลด์ลูกทั้งหมดให้แสดง 
1. บันทึกงานนำเสนอ

โค้ด Python ต่อไปนี้แสดงการทำงานนี้:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างมาสเตอร์สไลด์และเลย์เอาต์สไลด์คืออะไร?**

มาสเตอร์สไลด์กำหนดธีมโดยรวมและรูปแบบเริ่มต้น ส่วนเลย์เอาต์สไลด์กำหนดการจัดเรียงเฉพาะของตัวจัดตำแหน่งสำหรับประเภทเนื้อหาต่าง ๆ

**ฉันสามารถคัดลอกเลย์เอาต์สไลด์จากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งได้หรือไม่?**

ได้ คุณสามารถโคลนเลย์เอาต์สไลด์จากคอลเลกชัน [layout_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/layout_slides/) ของงานนำเสนอหนึ่งและแทรกลงในอีกงานนำเสนอหนึ่งโดยใช้เมธอด `add_clone`

**ถ้าฉันลบเลย์เอาต์สไลด์ที่ยังถูกสไลด์อื่นใช้งานจะเกิดอะไรขึ้น?**

หากคุณพยายามลบเลย์เอาต์สไลด์ที่ยังถูกสไลด์อย่างน้อยหนึ่งสไลด์อ้างอิงอยู่ Aspose.Slides จะโยนข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/python-net/aspose.slides/pptxeditexception/) เพื่อหลีกเลี่ยงปัญหา ให้ใช้เมธอด [remove_unused_layout_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) ซึ่งจะลบเลย์เอาต์สไลด์ที่ไม่ได้ใช้งานอย่างปลอดภัย