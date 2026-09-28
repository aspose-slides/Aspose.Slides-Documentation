---
title: จัดการมาสเตอร์สไลด์ใน Python
linktitle: มาสเตอร์สไลด์
type: docs
weight: 80
url: /th/python-net/slide-master/
keywords:
- มาสเตอร์สไลด์
- สไลด์มาสเตอร์
- สไลด์มาสเตอร์ PPT
- หลายมาสเตอร์สไลด์
- เปรียบเทียบมาสเตอร์สไลด์
- พื้นหลัง
- ตัวแทนจำลอง
- คัดลอกมาสเตอร์สไลด์
- ทำสำเนามาสเตอร์สไลด์
- ทำซ้ำมาสเตอร์สไลด์
- มาสเตอร์สไลด์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "จัดการมาสเตอร์สไลด์ใน Aspose.Slides สำหรับ Python ผ่าน .NET: เข้าถึง, แก้ไข, คัดลอก, เปรียบเทียบ และลบมาสเตอร์สไลด์ในการนำเสนอ PowerPoint และ OpenDocument."
---
## **ภาพรวม**

A **slide master** กำหนดการตั้งค่าออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์ มันสามารถมีรูปร่างทั่วไป โลโก้ พื้นหลัง รูปแบบข้อความ การตั้งค่าธีม และการตั้งค่าขอบเท้า ใน PowerPoint การแก้ไข **slide master** เป็นวิธีปกติในการทำให้การนำเสนอสอดคล้องกันโดยไม่ต้องทำซ้ำการจัดรูปแบบเดียวกันบนทุกสไลด์。

Aspose.Slides for Python via .NET รองรับโมเดลเดียวกัน การนำเสนอสามารถมี master slide หนึ่งหรือหลาย slide และแต่ละ master slide สามารถมี layout slide หลายสไลด์ สไลด์ปกติโดยทั่วไปไม่อ้างอิง master slide โดยตรง แต่สไลด์ปกติใช้ layout slide ซึ่ง layout slide นั้นเป็นของ master slide。

ลำดับชั้นคือ:

1. **Slide master** - กำหนดการออกแบบและธีมที่ใช้ร่วมกัน
1. **Layout slide** - กำหนดการจัดเรียงเฉพาะของตัวแทนจำลองและการจัดรูปแบบระดับเลย์เอาต์
1. **Normal slide** - มีเนื้อหาในการนำเสนอจริงและใช้เลย์เอาต์สไลด์หนึ่งเลย์เอาต์

![ลำดับชั้นของ master slides, layout slides, และ normal slides](slide-master_2.jpg)

In Aspose.Slides, a slide master is represented by the [MasterSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslide/) class. All master slides in a presentation are available through the `Presentation.masters` collection.

{{% alert color="info" title="Inheritance" %}}
เมื่อคุณสมบัติเหเดียวกันถูกกำหนดที่ระดับมากกว่าหนึ่งระดับ ระดับที่เฉพาะเจาะจงมากกว่าจะชนะ ตัวอย่างเช่น หาก master slide และ layout slide ทั้งสองกำหนดพื้นหลัง สไลด์ที่อิงตาม layout นั้นจะใช้พื้นหลังของ layout สำหรับข้อมูลเพิ่มเติมเกี่ยวกับ layout slides ดูที่ [Apply or Change Slide Layouts](/slides/th/python-net/slide-layout/) 
{{% /alert %}}

## **เข้าถึง Slide Masters**

ใน PowerPoint คุณสามารถเปิดมุมมอง Slide Master ได้จาก **View** > **Slide Master**.

![คำสั่ง Slide Master บนแท็บ View ของ PowerPoint](slide-master_3.jpg)

In Aspose.Slides, use the `masters` collection to access master slides:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

You can also get the master slide used by a normal slide through its layout:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **สิ่งที่ Slide Master มี**

A master slide is a slide-like object. It inherits common slide behavior from the [BaseSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/) class, so it exposes many of the same slide properties used by normal and layout slides. Master-specific members are listed on the [MasterSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslide/) API page.

Commonly used master slide members include:

| สมาชิก | วัตถุประสงค์ |
| --- | --- |
| `background` | กำหนดพื้นหลังของสไลด์ระดับ master |
| `shapes` | เก็บรูปร่างที่วางบน master เช่น โลโก้ กรอบรูปภาพและข้อความที่ใช้ร่วมกัน |
| `layout_slides` | เก็บ layout slides ที่เป็นของ master |
| `theme_manager` | ให้เข้าถึง API ธีมของ master |
| `header_footer_manager` | ควบคุมหัวกระดาษ, ท้ายกระดาษ, วันที่และหมายเลขสไลด์สำหรับ master และ layout ลูก |
| `get_depending_slides` | คืนค่าสไลด์ปกติที่พึ่งพา master ผ่าน layout ของพวกมัน |

## **เพิ่มภาพลงใน Slide Master**

เมื่อคุณเพิ่มภาพลงใน master slide มันจะปรากฏบนสไลด์ที่ใช้ layout จาก master นั้น ซึ่งมีประโยชน์สำหรับโลโก้, วอเตอร์มาร์ค, แถบตกแต่ง, และองค์ประกอบภาพที่ทำซ้ำอื่น ๆ

The following example adds a logo to the first master slide:

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

For more information about picture frames, see [Picture Frame](/slides/th/python-net/picture-frame/).

## **ควบคุมการมองเห็นของกราฟิก Master**

Use [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/show_master_shapes/) to hide inherited master graphics, such as logos or decorative shapes, without deleting them from the master. Set [Slide.show_master_shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/show_master_shapes/) to `False` on the slide that should omit those graphics and keep it `True` on slides that should display them.

The following self-contained example creates a blue decorative band on a master and two slides that use the same blank layout. The band is visible on the first slide and hidden on the second. No input presentation or image is required.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

The example uses the **Blank** layout supplied with a new presentation and removes the initial slide's own placeholders.

### **เลือกขอบเขตของการตั้งค่า**

A normal slide uses its master through [Slide.layout_slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/layout_slide/) and [LayoutSlide.master_slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/master_slide/). Setting the property on an individual slide affects only that slide. Setting [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/show_master_shapes/) to `False` hides master graphics for slides that use that shared layout, even if their own setting is `True`. To hide graphics on just one slide, change the slide property and leave the shared layout unchanged.

The setting is not supported as a visibility control on the master slide itself. On a master it always returns `False`, and assigning `True` raises an exception. Apply it to a normal slide or a layout instead.

### **แยกแยะกราฟิกจากพื้นหลัง**

| การดำเนินการ | ผล |
| --- | --- |
| Hide master graphics | ควบคุมการมองเห็นของรูปร่าง master ที่สืบทอดมาโดยไม่ลบหรือเปลี่ยนแปลงรูปร่างของสไลด์เอง |
| Change the slide background fill | เปลี่ยนการเติมสีพื้นหลังของสไลด์ เช่น สี, การไล่สี หรือรูปภาพ. กราฟิก master เป็นรูปร่างแยกต่างหากและสามารถมองเห็นอยู่เหนือพื้นหลังนั้นได้. ดูที่ [Presentation Background](/slides/th/python-net/presentation-background/) |
| Delete a shape from the master | ลบรูปร่างจาก master ซึ่งทำให้รูปแบบที่แชร์ไม่สามารถใช้ได้กับสไลด์ใดๆ ที่ใช้ master นั้น |

## **ทำงานกับ Placeholders**

Placeholders are normally defined on layout slides. The master slide provides the shared style and theme that those layouts inherit, while each layout decides which placeholders are available and where they are placed.

In PowerPoint, placeholder commands are available in Slide Master view.

![คำสั่ง Insert Placeholder ในมุมมอง Slide Master ของ PowerPoint](slide-master_5.png)

To add new placeholders with Aspose.Slides, work with the layout slide that belongs to the master:

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

You can also format placeholder shapes that already exist on a master slide. The following example finds the title placeholder and applies a linear gradient fill:

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

![Placeholder ชื่อเรื่องที่จัดรูปแบบแล้วสืบทอดโดยสไลด์ปกติ](slide-master_8.png)

For more placeholder and text formatting options, see [Set Prompt Text in Placeholder](/slides/th/python-net/manage-placeholder/) and [Text Formatting](/slides/th/python-net/text-formatting/).

## **เปลี่ยนพื้นหลัง Slide Master**

A master background is inherited by layouts and slides that do not override it. The following example sets a solid background color for the first master slide:

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

For related topics, see [Presentation Background](/slides/th/python-net/presentation-background/) and [Presentation Theme](/slides/th/python-net/presentation-theme/).

## **คัดลอก Slide Master ไปยังการนำเสนออื่น**

Use the `add_clone` method on the [MasterSlideCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslidecollection/) class to copy a master slide into another presentation. The copied master can then be used by layouts and slides in the destination presentation.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

If you need to clone normal slides together with their master, see [Clone Slides](/slides/th/python-net/clone-slides/).

## **เพิ่มหลาย Slide Master**

A presentation can contain multiple master slides. This is useful when different sections require different branding, page structure, or theme settings.

![คำสั่ง PowerPoint สำหรับแทรกและจัดการ master slides](slide-master_9.jpg)

The following example clones the default master, gives the clone a different background, gets a blank layout under that cloned master, and adds a new slide based on that layout:

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

## **เปรียบเทียบ Slide Masters**

Master slides can be compared with the `equals` method inherited from the [BaseSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/) class. The comparison checks structure and static content, such as shapes, text, formatting, animations, and other slide settings. It does not compare unique identifiers, such as slide IDs, or dynamic placeholder values, such as the current date.

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

For more information, see [Compare Presentation Slides](/slides/th/python-net/compare-slides/).

## **ตั้งค่า Slide Master View เป็นมุมมองเริ่มต้น**

Use the `last_view` property on the presentation [ViewProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/) to control the view that PowerPoint opens first. The following example opens the presentation in Slide Master view:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

For more view settings, see [Save Presentation](/slides/th/python-net/save-presentation/).

## **ลบ Master Slides ที่ไม่ได้ใช้**

Presentations sometimes contain master slides that are no longer used by any normal slides. Removing unused masters can reduce file size and simplify template maintenance.

Use `remove_unused` to remove unused masters from the `masters` collection:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

You can also use the low-code `remove_unused_master_slides` method from the [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) class:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ความแตกต่างระหว่าง slide master และ layout slide คืออะไร?**

A slide master defines shared design settings such as theme, background, common shapes, and text styles. A layout slide belongs to a master slide and defines a specific arrangement of placeholders. A normal slide uses a layout slide, so it inherits from both the layout and the master.

**การนำเสนอหนึ่งสามารถมีหลาย slide master ได้หรือไม่?**

Yes. A presentation can contain several slide masters. Use multiple masters when different sections need different visual systems or branding.

**ควรเพิ่ม placeholders บน master slide หรือ layout slide?**

In most cases, add placeholders to layout slides. Put shared visual elements and shared formatting on the master slide, then put content placeholders on the layouts that normal slides will use.

**ฉันสามารถลบ master slide ที่ยังถูกใช้อยู่ได้หรือไม่?**

No. A master slide that has dependent slides cannot be safely removed directly. First move those slides to layouts under another master, or use an unused‑master cleanup method that removes only masters that are not in use.