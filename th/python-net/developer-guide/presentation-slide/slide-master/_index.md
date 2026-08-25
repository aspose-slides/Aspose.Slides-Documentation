---
title: จัดการแม่แบบสไลด์ของการนำเสนอใน Python
linktitle: แม่แบบสไลด์
type: docs
weight: 80
url: /th/python-net/slide-master/
keywords:
- แม่แบบสไลด์
- สไลด์แม่แบบ
- สไลด์แม่แบบ PPT
- หลายสไลด์แม่แบบ
- เปรียบเทียบสไลด์แม่แบบ
- พื้นหลัง
- ตัวแทนตน
- คัดลอกสไลด์แม่แบบ
- ทำสำเนาสไลด์แม่แบบ
- ทำซ้ำสไลด์แม่แบบ
- สไลด์แม่แบบที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดการแม่แบบสไลด์ใน Aspose.Slides for Python via .NET: เข้าถึง แก้ไข คัดลอก เปรียบเทียบ และลบสไลด์แม่แบบในงานนำเสนอ PowerPoint และ OpenDocument."
---
## **ภาพรวม**

**แม่แบบสไลด์** กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์ สามารถประกอบด้วยรูปร่างทั่วไป โลโก้ ภาพพื้นหลัง สไตล์ข้อความ การตั้งค่าธีม และการตั้งค่าฝั่งล่าง (footer) ใน PowerPoint การแก้ไขแม่แบบสไลด์เป็นวิธีปกติเพื่อให้การนำเสนอมีความสอดคล้องโดยไม่ต้องทำการจัดรูปแบบเดียวกันบนแต่ละสไลด์

Aspose.Slides for Python via .NET รองรับโมเดลเดียวกัน การนำเสนอสามารถมีแม่แบบสไลด์หนึ่งหรือหลายแม่แบบ และแต่ละแม่แบบสไลด์สามารถมีสไลด์เลเอาต์หลายสไลด์ สไลด์ปกติส่วนใหญ่ไม่ได้อ้างอิงแม่แบบสไลด์โดยตรง แต่จะใช้สไลด์เลเอาต์ ซึ่งสไลด์เลเอาต์นั้นเป็นส่วนหนึ่งของแม่แบบสไลด์

ลำดับขั้นคือ:

1. **แม่แบบสไลด์** - กำหนดการออกแบบและธีมที่ใช้ร่วมกัน  
1. **สไลด์เลเอาต์** - กำหนดการจัดวางเฉพาะของตัวแทนตนและการจัดรูปแบบระดับเลเอาต์  
1. **สไลด์ปกติ** - มีเนื้อหาการนำเสนอจริงและใช้สไลด์เลเอาต์หนึ่งสไลด์

![ลำดับชั้นของแม่แบบสไลด์, สไลด์เลเอาต์, และสไลด์ปกติ](slide-master_2.jpg)

ใน Aspose.Slides, แม่แบบสไลด์ถูกแทนด้วยคลาส [MasterSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslide/) คอลเลกชัน `Presentation.masters` ให้เข้าถึงแม่แบบสไลด์ทั้งหมดในงานนำเสนอ

{{% alert color="info" title="Inheritance" %}}
เมื่อคุณสมบัติเช่นเดียวกันถูกกำหนดที่หลายระดับ ระดับที่เจาะจงมากกว่าจะมีลำดับความสำคัญ ตัวอย่างเช่น หากแม่แบบสไลด์และสไลด์เลเอาต์กำหนดพื้นหลังร่วมกัน สไลด์ที่สร้างจากเลเอาต์นั้นจะใช้พื้นหลังของเลเอาต์ สำหรับข้อมูลเพิ่มเติมเกี่ยวกับสไลด์เลเอาต์ โปรดดูที่ [Apply or Change Slide Layouts](/slides/th/python-net/slide-layout/)
{{% /alert %}}

## **การเข้าถึงแม่แบบสไลด์**

ใน PowerPoint คุณสามารถเปิดมุมมองแม่แบบสไลด์ได้จาก **View** > **Slide Master**  

![คำสั่ง Slide Master บนแท็บ View ของ PowerPoint](slide-master_3.jpg)

ใน Aspose.Slides ให้ใช้คอลเลกชัน `masters` เพื่อเข้าถึงแม่แบบสไลด์:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

คุณยังสามารถดึงแม่แบบสไลด์ที่สไลด์ปกติใช้ผ่านเลเอาต์ของสไลด์นั้นได้:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **สิ่งที่แม่แบบสไลด์ประกอบด้วย**

แม่แบบสไลด์เป็นอ็อบเจกต์คล้ายสไลด์ มันสืบทอดพฤติกรรมสไลด์ทั่วไปจากคลาส [BaseSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/) ดังนั้นจึงเปิดเผยคุณสมบัติของสไลด์หลายอย่างที่ใช้โดยสไลด์ปกติและสไลด์เลเอาต์ รายการสมาชิกที่เฉพาะเจาะจงกับแม่แบบสามารถดูได้บนหน้า API ของ [MasterSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslide/)

สมาชิกของแม่แบบสไลด์ที่มักใช้รวมถึง:

| สมาชิก | วัตถุประสงค์ |
| --- | --- |
| `background` | ตั้งค่าพื้นหลังระดับแม่แบบ |
| `shapes` | เก็บรูปร่างที่วางบนแม่แบบ เช่น โลโก้, กรอบภาพ, และข้อความที่ใช้ร่วมกัน |
| `layout_slides` | เก็บสไลด์เลเอาต์ที่เป็นส่วนหนึ่งของแม่แบบ |
| `theme_manager` | ให้เข้าถึง API ธีมของแม่แบบ |
| `header_footer_manager` | ควบคุมส่วนหัว, ส่วนท้าย, วันที่, และหมายเลขสไลด์สำหรับแม่แบบและเลเอาต์ลูก |
| `get_depending_slides` | คืนค่าสไลด์ปกติที่พึ่งพาแม่แบบผ่านเลเอาต์ของตน |

## **เพิ่มรูปภาพไปยังแม่แบบสไลด์**

เมื่อคุณเพิ่มรูปภาพไปยังแม่แบบสไลด์ รูปนั้นจะปรากฏบนสไลด์ที่ใช้เลเอาต์จากแม่แบบนั้น ซึ่งมีประโยชน์สำหรับโลโก้,ลายน้ำ, แถบตกแต่ง, และองค์ประกอบภาพที่ต้องการทำซ้ำ

ตัวอย่างต่อไปนี้เพิ่มโลโก้ไปยังแม่แบบสไลด์แรก:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับกรอบภาพ โปรดดูที่ [Picture Frame](/slides/th/python-net/picture-frame/)

## **ทำงานกับตัวแทนตน (Placeholders)**

ตัวแทนตนส่วนใหญ่จะถูกกำหนดบนสไลด์เลเอาต์ แม่แบบสไลด์จัดให้มีสไตล์และธีมร่วมที่เลเอาต์เหล่านั้นสืบทอด ส่วนแต่ละเลเอาต์จะกำหนดว่าตัวแทนตนใดบ้างที่พร้อมใช้งานและตำแหน่งของมัน

ใน PowerPoint คำสั่งตัวแทนตนจะพร้อมใช้งานในมุมมองแม่แบบสไลด์

![คำสั่ง Insert Placeholder ในมุมมองแม่แบบสไลด์ของ PowerPoint](slide-master_5.png)

เพื่อเพิ่มตัวแทนตนใหม่ด้วย Aspose.Slides ให้ทำงานกับสไลด์เลเอาต์ที่เป็นของแม่แบบ:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

คุณยังสามารถจัดรูปแบบรูปร่างตัวแทนตนที่มีอยู่แล้วบนแม่แบบสไลด์ ตัวอย่างต่อไปนี้ค้นหาตัวแทนตนหัวเรื่องและใช้การเติมสีไลเนียร์กราเดียนต์:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![หัวเรื่องที่จัดรูปแบบแล้วซึ่งสืบทอดโดยสไลด์ปกติ](slide-master_8.png)

สำหรับตัวเลือกการจัดรูปแบบตัวแทนตนและข้อความเพิ่มเติม ดูที่ [Set Prompt Text in Placeholder](/slides/th/python-net/manage-placeholder/) และ [Text Formatting](/slides/th/python-net/text-formatting/)

## **เปลี่ยนพื้นหลังของแม่แบบสไลด์**

พื้นหลังของแม่แบบจะถูกสืบทอดโดยเลเอาต์และสไลด์ที่ไม่ได้แทนที่มัน ตัวอย่างต่อไปนี้ตั้งค่าสีพื้นหลังแบบทึบสำหรับแม่แบบสไลด์แรก:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

สำหรับหัวข้อที่เกี่ยวข้อง โปรดดูที่ [Presentation Background](/slides/th/python-net/presentation-background/) และ [Presentation Theme](/slides/th/python-net/presentation-theme/)

## **คัดลอกแม่แบบสไลด์ไปยังงานนำเสนออื่น**

ใช้เมธอด `add_clone` บนคลาส [MasterSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/) เพื่อคัดลอกแม่แบบสไลด์ไปยังงานนำเสนออื่น แม่แบบที่คัดลอกแล้วสามารถนำไปใช้โดยเลเอาต์และสไลด์ในงานนำหมายปลายได้

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

หากต้องการคัดลอกสไลด์ปกติกับแม่แบบของมันพร้อมกัน โปรดดูที่ [Clone Slides](/slides/th/python-net/clone-slides/)

## **เพิ่มหลายแม่แบบสไลด์**

งานนำเสนอสามารถมีแม่แบบสไลด์หลายชุดได้ ซึ่งเหมาะสำหรับส่วนต่าง ๆ ที่ต้องการการแบรนด์ดิ้ง โครงสร้างหน้า หรือการตั้งค่าธีมที่แตกต่างกัน

![คำสั่งของ PowerPoint สำหรับแทรกและจัดการแม่แบบสไลด์](slide-master_9.jpg)

ตัวอย่างต่อไปนี้คัดลอกแม่แบบเริ่มต้น, ตั้งค่าพื้นหลังที่ต่างออกไปสำหรับคัดลอก, ดึงเลเอาต์เปล่าจากแม่แบบที่คัดลอก, และเพิ่มสไลด์ใหม่โดยอิงจากเลเอมาตนั้น:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **เปรียบเทียบแม่แบบสไลด์**

แม่แบบสไลด์สามารถเปรียบเทียบได้ด้วยเมธอด `equals` ที่สืบทอดจากคลาส [BaseSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/) การเปรียบเทียบตรวจสอบโครงสร้างและเนื้อหาคงที่ เช่น รูปร่าง, ข้อความ, การจัดรูปแบบ, แอนิเมชัน, และการตั้งค่าสไลด์อื่น ๆ ไม่ได้เปรียบเทียบตัวระบุที่เป็นเอกลักษณ์ เช่น ID สไลด์ หรือค่าตัวแทนตนแบบไดนามิก เช่น วันที่ปัจจุบัน

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

สำหรับข้อมูลเพิ่มเติม โปรดดูที่ [Compare Presentation Slides](/slides/th/python-net/compare-slides/)

## **ตั้งค่ามุมมองแม่แบบสไลด์เป็นมุมมองเริ่มต้น**

ใช้คุณสมบัติ `last_view` บนคลาส [ViewProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/) ของงานนำเสนอเพื่อควบคุมมุมมองที่ PowerPoint เปิดแรก ตัวอย่างต่อไปนี้เปิดงานนำเสนอในมุมมองแม่แบบสไลด์:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

สำหรับการตั้งค่ามุมมองเพิ่มเติม โปรดดูที่ [Save Presentation](/slides/th/python-net/save-presentation/)

## **ลบแม่แบบสไลด์ที่ไม่ได้ใช้**

บางครั้งงานนำเสนออาจมีแม่แบบสไลด์ที่ไม่มีสไลด์ปกติใด ๆ ใช้งาน การลบแม่แบบที่ไม่ได้ใช้จะช่วยลดขนาดไฟล์และทำให้การบำรุงรักษาเทมเพลตง่ายขึ้น

ใช้เมธอด `remove_unused` เพื่อลบแม่แบบสไลด์ที่ไม่ได้ใช้จากคอลเลกชัน `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

คุณยังสามารถใช้เมธอด low‑code `remove_unused_master_slides` จากคลาส [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) ได้เช่นกัน:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

### แม่แบบสไลด์กับสไลด์เลเอาต์ต่างกันอย่างไร?

แม่แบบสไลด์กำหนดการออกแบบที่ใช้ร่วมกัน เช่น ธีม, พื้นหลัง, รูปร่างทั่วไป, และสไตล์ข้อความ สไลด์เลเอาต์เป็นส่วนหนึ่งของแม่แบบสไลด์และกำหนดการจัดวางเฉพาะของตัวแทนตน สไลด์ปกติใช้สไลด์เลเอาต์ ดังนั้นจึงสืบทอดจากทั้งเลเอาต์และแม่แบบ

### งานนำเสนอหนึ่งสามารถมีแม่แบบสไลด์หลายอันได้หรือไม่?

ได้ งานนำเสนอสามารถมีแม่แบบสไลด์หลายอันได้ ใช้หลายแม่แบบเมื่อส่วนต่าง ๆ ต้องการระบบภาพหรือแบรนด์ดิ้งที่แตกต่างกัน

### ควรเพิ่มตัวแทนตนที่แม่แบบสไลด์หรือสไลด์เลเอาต์?

ในกรณีส่วนใหญ่ให้เพิ่มตัวแทนตนบนสไลด์เลเอาต์ เก็บองค์ประกอบภาพและการจัดรูปแบบที่ใช้ร่วมกันบนแม่แบบสไลด์ แล้วใส่ตัวแทนตนสำหรับเนื้อหาบนเลเออต์ที่สไลด์ปกติจะใช้

### สามารถลบแม่แบบสไลด์ที่ยังถูกใช้งานอยู่ได้หรือไม่?

ไม่ได้ แม่แบบสไลด์ที่มีสไลด์ขึ้นอยู่ไม่สามารถลบได้โดยตรง ต้องย้ายสไลด์เหล่านั้นไปยังเลเออต์ภายใต้แม่แบบอื่นก่อน หรือใช้วิธีทำความสะอาดแม่แบบที่ไม่ถูกใช้ซึ่งจะลบเฉพาะแม่แบบที่ไม่มีสไลด์อ้างอิงเท่านั้น