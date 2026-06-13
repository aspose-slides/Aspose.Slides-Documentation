---
title: จัดการสไลด์มาสเตอร์ของการนำเสนอใน Python
linktitle: สไลด์มาสเตอร์
type: docs
weight: 80
url: /th/python-net/slide-master/
keywords:
- สไลด์มาสเตอร์
- สไลด์มาสเตอร์
- สไลด์มาสเตอร์ PPT
- หลายสไลด์มาสเตอร์
- เปรียบเทียบสไลด์มาสเตอร์
- พื้นหลัง
- ตัวกักข้อมูล
- คัดลอกสไลด์มาสเตอร์
- คัดลอกสไลด์มาสเตอร์
- ทำสำเนาสไลด์มาสเตอร์
- สไลด์มาสเตอร์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดการสไลด์มาสเตอร์ใน Aspose.Slides สำหรับ Python ผ่าน .NET: เข้าถึง, แก้ไข, คัดลอก, เปรียบเทียบและลบสไลด์มาสเตอร์ในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

**สไลด์มาสเตอร์** กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์ สามารถประกอบด้วยรูปร่างทั่วไป, โลโก้, พื้นหลัง, สไตล์ข้อความ, การตั้งค่าธีม, และการตั้งค่าฝั่งด้านล่าง (footer) ใน PowerPoint การแก้ไขสไลด์มาสเตอร์เป็นวิธีปกติในการทำให้การนำเสนอสอดคล้องกันโดยไม่ต้องทำฟอร์แมตซ้ำในทุกสไลด์

Aspose.Slides for Python via .NET รองรับโมเดลเดียวกัน การนำเสนอสามารถมีสไลด์มาสเตอร์หนึ่งหรือหลายสไลด์ และแต่ละสไลด์มาสเตอร์สามารถมีสไลด์เค้าโครงหลายสไลด์ สไลด์ปกติโดยทั่วไปไม่ได้อ้างอิงสไลด์มาสเตอร์โดยตรง แต่สไลด์ปกติใช้สไลด์เค้าโครงและสไลด์เค้าโครงนั้นเป็นของสไลด์มาสเตอร์

ลำดับชั้นคือ:
1. **สไลด์มาสเตอร์** - กำหนดการออกแบบและธีมที่ใช้ร่วมกัน.
1. **สไลด์เค้าโครง** - กำหนดการจัดเรียงเฉพาะของตัวกักข้อมูลและการจัดรูปแบบระดับเค้าโครง.
1. **สไลด์ปกติ** - มีเนื้อหาการนำเสนอจริงและใช้สไลด์เค้าโครงหนึ่งสไลด์.

![ลำดับชั้นของสไลด์มาสเตอร์, สไลด์เค้าโครง, และสไลด์ปกติ](slide-master_2.jpg)

ใน Aspose.Slides, สไลด์มาสเตอร์จะแสดงโดยคลาส [MasterSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslide/) คอลเลกชัน `Presentation.masters` ให้เข้าถึงสไลด์มาสเตอร์ทั้งหมดในงานนำเสนอ

{{% alert color="info" title="การสืบทอด" %}}
เมื่อคุณสมบัติเหมือนกันถูกกำหนดในหลายระดับ ระดับที่เฉพาะเจาะจงมากกว่าจะชนะ ตัวอย่างเช่น หากสไลด์มาสเตอร์และสไลด์เค้าโครงทั้งสองกำหนดพื้นหลัง สไลด์ที่ใช้เค้าโครงนั้นจะใช้พื้นหลังของเค้าโครง สำหรับข้อมูลเพิ่มเติมเกี่ยวกับสไลด์เค้าโครง ดูที่ [ใช้หรือเปลี่ยนเค้าโครงสไลด์](/python-net/slide-layout/).
{{% /alert %}}

## **การเข้าถึงสไลด์มาสเตอร์**

ใน PowerPoint คุณสามารถเปิดมุมมองสไลด์มาสเตอร์ได้จาก **View** > **Slide Master**.

![คำสั่ง Slide Master บนแท็บ View ของ PowerPoint](slide-master_3.jpg)

ใน Aspose.Slides, ใช้คอลเลกชัน `masters` เพื่อเข้าถึงสไลด์มาสเตอร์:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

คุณยังสามารถดึงสไลด์มาสเตอร์ที่สไลด์ปกติใช้ผ่านเค้าโครงของมันได้:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **สิ่งที่สไลด์มาสเตอร์บรรจุ**

สไลด์มาสเตอร์เป็นวัตถุคล้ายสไลด์ มันสืบทอดพฤติกรรมสไลด์ทั่วไปจากคลาส [BaseSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/) ดังนั้นจึงแสดงคุณสมบัติของสไลด์หลายอย่างที่ใช้โดยสไลด์ปกติและสไลด์เค้าโครง สมาชิกเฉพาะของมาสเตอร์ถูกระบุในหน้า API ของ [MasterSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslide/)

สมาชิกของสไลด์มาสเตอร์ที่ใช้บ่อยรวมถึง:

| สมาชิก | วัตถุประสงค์ |
| --- | --- |
| `background` | กำหนดพื้นหลังของสไลด์ระดับมาสเตอร์ |
| `shapes` | เก็บรูปร่างที่วางบนมาสเตอร์ เช่น โลโก้, กรอบรูปภาพ, และข้อความที่ใช้ร่วมกัน |
| `layout_slides` | เก็บสไลด์เค้าโครงที่เป็นของมาสเตอร์ |
| `theme_manager` | ให้เข้าถึง API ธีมของมาสเตอร์ |
| `header_footer_manager` | ควบคุมหัวข้อ, ส่วนท้าย, วันที่, และหมายเลขสไลด์สำหรับมาสเตอร์และเค้าโครงลูกของมัน |
| `get_depending_slides` | คืนค่าสไลด์ปกติที่พึ่งพามาสเตอร์ผ่านเค้าโครงของพวกมัน |

## **เพิ่มรูปภาพลงในสไลด์มาสเตอร์**

เมื่อคุณเพิ่มรูปภาพลงในสไลด์มาสเตอร์ มันจะปรากฏบนสไลด์ที่ใช้เค้าโครงจากมาสเตอร์นั้น ซึ่งมีประโยชน์สำหรับโลโก้, ลายน้ำ, แถบตกแต่ง, และองค์ประกอบภาพอื่น ๆ ที่ทำซ้ำ

ตัวอย่างต่อไปนี้เพิ่มโลโก้ลงในสไลด์มาสเตอร์แรก:

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

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับกรอบรูปภาพ, ดูที่ [กรอบรูปภาพ](/python-net/picture-frame/).

## **ทำงานกับตัวกักข้อมูล**

ตัวกักข้อมูลโดยทั่วไปจะกำหนดบนสไลด์เค้าโครง สไลด์มาสเตอร์ให้สไตล์และธีมที่ใช้ร่วมกันที่สไลด์เค้าโครงสืบทอด ในขณะที่แต่ละเค้าโครงกำหนดว่าตัวกักข้อมูลใดมีและอยู่ที่ตำแหน่งใด

ใน PowerPoint คำสั่งตัวกักข้อมูลจะพร้อมใช้งานในมุมมอง Slide Master.

![คำสั่ง Insert Placeholder ในมุมมอง Slide Master ของ PowerPoint](slide-master_5.png)

เพื่อเพิ่มตัวกักข้อมูลใหม่ด้วย Aspose.Slides ให้ทำงานกับสไลด์เค้าโครงที่เป็นของมาสเตอร์:

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

คุณยังสามารถจัดรูปแบบรูปร่างตัวกักข้อมูลที่มีอยู่แล้วบนสไลด์มาสเตอร์ ตัวอย่างต่อไปนี้ค้นหาตัวกักข้อมูลหัวเรื่องและใช้การเติมสีไลเนียร์กราเดียนท์:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![ตัวกักข้อมูลหัวเรื่องที่จัดรูปแบบแล้วสืบทอดโดยสไลด์ปกติ](slide-master_8.png)

สำหรับตัวเลือกการจัดรูปแบบตัวกักข้อมูลและข้อความเพิ่มเติม, ดูที่ [ตั้งค่าข้อความพรอมท์ในตัวกักข้อมูล](/python-net/manage-placeholder/) และ [การจัดรูปแบบข้อความ](/python-net/text-formatting/).

## **เปลี่ยนพื้นหลังสไลด์มาสเตอร์**

พื้นหลังมาสเตอร์จะถูกสืบทอดโดยเค้าโครงและสไลด์ที่ไม่ได้กำหนดทับ ตัวอย่างต่อไปนี้ตั้งค่าสีพื้นหลังแบบสีเดียวสำหรับสไลด์มาสเตอร์แรก:

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

สำหรับหัวข้อที่เกี่ยวข้อง, ดูที่ [พื้นหลังการนำเสนอ](/python-net/presentation-background/) และ [ธีมการนำเสนอ](/python-net/presentation-theme/).

## **คัดลอกสไลด์มาสเตอร์ไปยังงานนำเสนออื่น**

ใช้เมธอด `add_clone` ของคลาส [MasterSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/) เพื่อคัดลอกสไลด์มาสเตอร์เข้าไปในงานนำเสนออื่น มาสเตอร์ที่คัดลอกแล้วสามารถนำไปใช้โดยเค้าโครงและสไลด์ในงานนำหมายที่ปลายทาง

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

หากคุณต้องการคัดลอกสไลด์ปกติพร้อมมาสเตอร์ ดูที่ [คัดลอกสไลด์](/python-net/clone-slides/).

## **เพิ่มหลายสไลด์มาสเตอร์**

งานนำเสนอสามารถมีสไลด์มาสเตอร์หลายสไลด์ ซึ่งมีประโยชน์เมื่อแต่ละส่วนต้องการแบรนด์ดิ้ง, โครงสร้างหน้า, หรือการตั้งค่าธีมที่แตกต่างกัน

![คำสั่ง PowerPoint สำหรับแทรกและจัดการสไลด์มาสเตอร์](slide-master_9.jpg)

ตัวอย่างต่อไปนี้คัดลอกมาสเตอร์เริ่มต้น, ให้คัดลอกนั้นมีพื้นหลังที่ต่างกัน, ดึงเค้าโครงเปล่าภายใต้มาสเตอร์ที่คัดลอก, และเพิ่มสไลด์ใหม่โดยอิงเค้าโครงนั้น:

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

## **เปรียบเทียบสไลด์มาสเตอร์**

สไลด์มาสเตอร์สามารถเปรียบเทียบด้วยเมธอด `equals` ที่สืบทอดมาจากคลาส [BaseSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/) การเปรียบเทียบตรวจสอบโครงสร้างและเนื้อหาคงที่ เช่น รูปร่าง, ข้อความ, การจัดรูปแบบ, แอนิเมชั่น, และการตั้งค่าสไลด์อื่น ๆ ไม่ได้เปรียบเทียบตัวระบุที่ไม่ซ้ำกัน เช่น slide ID หรือค่าตัวกักข้อมูลแบบไดนามิก เช่น วันที่ปัจจุบัน

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

สำหรับข้อมูลเพิ่มเติม, ดูที่ [เปรียบเทียบสไลด์การนำเสนอ](/python-net/compare-slides/).

## **ตั้งมุมมองสไลด์มาสเตอร์เป็นมุมมองเริ่มต้น**

ใช้คุณสมบัติ `last_view` ของงานนำเสนอในคลาส [ViewProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/) เพื่อควบคุมมุมมองที่ PowerPoint เปิดเป็นอันดับแรก ตัวอย่างต่อไปนี้เปิดงานนำเสนอในมุมมอง Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

สำหรับการตั้งค่ามุมมองเพิ่มเติม, ดูที่ [บันทึกงานนำเสนอ](/python-net/save-presentation/).

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้**

บางครั้งงานนำเสนออาจมีสไลด์มาสเตอร์ที่ไม่ถูกสไลด์ปกติใดใช้แล้ว การลบมาสเตอร์ที่ไม่ได้ใช้จะช่วยลดขนาดไฟล์และทำให้การดูแลเทมเพลตง่ายขึ้น

ใช้ `remove_unused` เพื่อลบมาสเตอร์ที่ไม่ได้ใช้จากคอลเลกชัน `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

คุณยังสามารถใช้เมธอด low-code `remove_unused_master_slides` จากคลาส [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**สไลด์มาสเตอร์กับสไลด์เค้าโครงมีความแตกต่างอย่างไร?**

สไลด์มาสเตอร์กำหนดการตั้งค่าการออกแบบที่ใช้ร่วมกัน เช่น ธีม, พื้นหลัง, รูปร่างทั่วไป, และสไตล์ข้อความ สไลด์เค้าโครงเป็นส่วนหนึ่งของสไลด์มาสเตอร์และกำหนดการจัดเรียงเฉพาะของตัวกักข้อมูล สไลด์ปกติใช้สไลด์เค้าโครง ดังนั้นจึงสืบทอดจากทั้งเค้าโครงและมาสเตอร์

**งานนำเสนอหนึ่งสามารถมีสไลด์มาสเตอร์หลายสไลด์ได้หรือไม่?**

ได้ งานนำเสนอสามารถมีสไลด์มาสเตอร์หลายสไลด์ได้ ใช้หลายมาสเตอร์เมื่อส่วนต่าง ๆ ต้องการระบบภาพหรือแบรนด์ที่แตกต่างกัน

**ควรเพิ่มตัวกักข้อมูลบนสไลด์มาสเตอร์หรือสไลด์เค้าโครง?**

ในหลายกรณีควรเพิ่มตัวกักข้อมูลบนสไลด์เค้าโครง ให้ใส่องค์ประกอบภาพและการจัดรูปแบบที่ใช้ร่วมกันบนสไลด์มาสเตอร์ แล้วใส่ตัวกักข้อมูลสำหรับเนื้อหาบนเค้าโครงที่สไลด์ปกติจะใช้

**ฉันสามารถลบสไลด์มาสเตอร์ที่ยังถูกใช้งานอยู่ได้หรือไม่?**

ไม่ได้ สไลด์มาสเตอร์ที่มีสไลด์ที่พึ่งพาอยู่อย่างปลอดภัยไม่สามารถลบโดยตรงได้ ต้องย้ายสไลด์เหล่านั้นไปยังเค้าโครงใต้มาสเตอร์อื่นก่อน หรือใช้วิธีทำความสะอาดมาสเตอร์ที่ไม่ได้ใช้ซึ่งลบเฉพาะมาสเตอร์ที่ไม่ถูกใช้งาน