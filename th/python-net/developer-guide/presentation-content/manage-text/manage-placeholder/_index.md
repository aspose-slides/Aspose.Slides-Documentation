---
title: จัดการตัวแทนตำแหน่งงานนำเสนอใน Python
linktitle: จัดการตัวแทนตำแหน่ง
type: docs
weight: 10
url: /th/python-net/manage-placeholder/
keywords:
- ตัวแทนตำแหน่ง
- ตัวแทนตำแหน่งข้อความ
- ตัวแทนตำแหน่งรูปภาพ
- ตัวแทนตำแหน่งแผนภูมิ
- ตัวแทนตำแหน่งเนื้อหา
- ข้อความตัวช่วย
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไขตัวแทนตำแหน่งข้อความ, รูปภาพ, แผนภูมิ, และเนื้อหา รวมถึงทำความเข้าใจการสืบทอดตัวแทนตำแหน่งด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Placeholder คือรูปทรงที่สงวนตำแหน่งสำหรับเนื้อหาประเภทหนึ่งในเทมเพลตงานนำเสนอ ตัวอย่างทั่วไปได้แก่ placeholder สำหรับหัวเรื่อง, เนื้อหา, รูปภาพ, แผนภูมิ และ placeholder เนื้อหาทั่วไป ไม่เหมือนรูปทรงทั่วไป Placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบ และการตั้งค่าอื่น ๆ จากสไลด์เลย์เอาต์หรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล Placeholder ผ่านคุณสมบัติ [Shape.placeholder](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/placeholder/) คุณสมบัตินี้คืนค่าออบเจ็กต์ [Placeholder](https://reference.aspose.com/slides/th/python-net/aspose.slides/placeholder/) หรือ `None` สำหรับรูปทรงปกติ ใช้ [Placeholder.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/placeholder/type/) เพื่อตรวจสอบว่า Placeholder มีจุดประสงค์ให้บรรจุอะไร

คลาสรูปทรงยังคงมีความสำคัญหลังจากคุณรู้ประเภทของ Placeholder แล้ว:

- Placeholder ที่ว่างเปล่าของข้อความ, รูปภาพ, แผนภูมิ หรือเนื้อหา มักจะแทนด้วย [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)  
- Placeholder รูปภาพที่มีข้อมูลแล้วสามารถแทนด้วย [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/)  
- Placeholder แผนภูมิที่มีข้อมูลแล้วสามารถแทนด้วย [Chart](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/)  
- Placeholder เนื้อหาอาจบรรจุประเภทของเนื้อหาหลายชนิด ตรวจสอบทั้ง [Placeholder.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/placeholder/type/) และคลาสรูปทรงขณะรันไทม์ แทนที่จะสันนิษฐานว่า Placeholder ทั้งหมดเป็น [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/placeholder/type/) บรรยายบทบาทของ Placeholder; ไม่ได้รับประกันคลาสรูปทรงขณะรันไทม์ เสมอให้ตรวจสอบประเภทก่อนเข้าถึงสมาชิกที่เกี่ยวกับข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่ออื่น ๆ
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder มีโครงสร้างชั้นลำดับ:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่นำไปใช้ซ้ำได้และบางกรณีอาจมี Placeholder ระดับมาสเตอร์  
2. สไลด์เลย์เอาต์กำหนดการจัดวางที่ใช้โดยสไลด์ปกติเพื่อหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์  
3. สไลด์ปกติมี Placeholder ของสไลด์นั้นและสามารถสืบทอดจากเลย์เอาต์ของมัน

เรียกใช้ [Shape.get_base_placeholder](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/get_base_placeholder/) เพื่อย้ายหนึ่งระดับขึ้นในลำดับชั้น Placeholder สไลด์ปกติมักคืนค่า Placeholder ของเลย์เอาต์; Placeholder ของเลย์เอาต์อาจคืนค่า Placeholder ของมาสเตอร์ วิธีนี้จะคืนค่า `None` เมื่อรูปทรงไม่มี Base Placeholder

ตัวอย่างต่อไปแสดงรายการ Placeholder ในสไลด์แรกและรายงาน Base Placeholder ของพวกมัน:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

การแก้ไข Placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการทับซ้อนแบบโลคัลสำหรับสไลด์นั้น การแก้ไขเลย์เอาต์หรือมาสเตอร์ที่เกี่ยวข้องสามารถส่งผลต่อสไลด์ทั้งหมดที่ยังสืบทอดการตั้งค่านี้ รูปทรงปกติแบบโลคัลไม่มี Base Placeholder และจะไม่เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน

## **เปลี่ยนข้อความใน Placeholder**

Placeholder สำหรับหัวเรื่อง, หัวเรื่องกึ่งกลาง, คำบรรยายย่อย, เนื้อหา, และข้อความโดยทั่วไปมักรองรับข้อความ ตรวจสอบว่ารูปทรงเป็น [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ก่อนใช้คุณสมบัติ [text_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/text_frame/)

ตัวอย่างนี้อัปเดต Placeholder หัวเรื่องแรกในสไลด์แรกและบันทึกผลลัพธ์:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

รูปแบบนี้หลีกเลี่ยงการถือว่า Placeholder ของรูปภาพ, แผนภูมิ, ตาราง หรือสื่อเป็นออบเจ็กต์ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) นอกจากนี้ยังระบุ Placeholder ตามวัตถุประสงค์แทนการพึ่งพาดัชนีรูปทรงที่เปราะบาง

## **กำหนดข้อความ Prompt บนเลย์เอาต์**

Prompt text คือคำแนะนำที่แสดงใน Placeholder ที่ว่างเปล่า เช่น *คลิกเพื่อเพิ่มหัวเรื่อง* ตั้งข้อความ Prompt แบบกำหนดเองบน Placeholder ของเลย์เอาต์แทนการพยายามเข้าถึงผ่านคอลเลคชันรูปทรงของสไลด์ปกติ เข้าถึงเลย์เอาต์ผ่าน [Slide.layout_slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/layout_slide/) แล้ววนลูปผ่าน [LayoutSlide.shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/shapes/)

ตัวอย่างต่อไปเปลี่ยน Prompt ของหัวเรื่องและหัวเรื่องย่อยบนเลย์เอาต์ที่ใช้โดยสไลด์แรก:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

Prompt text ไม่ใช่เนื้อหาสไลด์ปกติ มันถูกออกแบบสำหรับ Placeholder ที่ว่างเปล่าในแอปพลิเคชันการแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริง Prompt จะไม่แสดงอีกต่อไป การเปลี่ยน Prompt ยังไม่ได้แทนที่ข้อความที่มีอยู่บนสไลด์ที่ใช้เลย์เอต์นั้น

## **อัปเดต Placeholder รูปภาพ**

มีสองกรณีที่ต้องจัดการ:

- หาก Placeholder รูปภาพถูกเติมเต็มแล้วและแทนด้วย [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/), ให้แทนที่รูปโดยใช้ [PictureFillFormat.picture](https://reference.aspose.com/slides/th/python-net/aspose.slides/picturefillformat/picture/) และ [Picture.image](https://reference.aspose.com/slides/th/python-net/aspose.slides/picture/image/)  
- หากยังเป็น Placeholder ว่างเปล่า ให้เพิ่ม PictureFrame ที่พิกัดของ Placeholder ด้วย [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_picture_frame/) แล้วลบ Placeholder ที่ว่างเปล่าออก

ตัวอย่างต่อไปรองรับทั้งสองกรณีและบันทึกงานนำเสนอ:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

การแทนที่ที่สร้างขึ้นสำหรับ Placeholder ที่ว่างเปล่าเป็น PictureFrame แบบโลคัล ไม่ได้เป็น Placeholder ใหม่ เนื่องจาก [Shape.placeholder](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/placeholder/) เป็นแบบอ่านอย่างเดียว มันยังคงตำแหน่งที่สงวนไว้แต่ไม่สืบทอดพฤติกรรมเฉพาะของ Placeholder หากการรักษาความสัมพันธ์กับ Placeholder มีความสำคัญ ควรเตรียมและเติมข้อมูล Placeholder ใน PowerPoint ก่อน แล้วอัปเดต [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับการทำให้ภาพโปร่งแสง, การครอบภาพ, และเอฟเฟกต์เฉพาะรูปภาพอื่น ๆ ดูบทความ [Manage Picture Frames](/slides/th/python-net/picture-frame/) การดำเนินการเหล่านี้อยู่ในระดับ PictureFrame หรือ PictureFill ไม่ได้อยู่ในเมตาดาต้า Placeholder

## **ทำงานกับ Placeholder แผนภูมิและเนื้อหา**

Placeholder แผนภูมิที่เติมเต็มแล้วสามารถแทนด้วย [Chart](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/) ตัวอย่างนี้ค้นหาแผนภูมิที่ตรงตามประเภท Placeholder และคลาสขณะรันไทม์, เปลี่ยนหัวเรื่องของมัน, แล้วบันทึกไฟล์:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Placeholder เนื้อหาโดยทั่วไปมักมีประเภท [PlaceholderType.OBJECT](https://reference.aspose.com/slides/th/python-net/aspose.slides/placeholdertype/) ใน PowerPoint มันทำหน้าที่เป็นตัวเรียกหลายประเภทของเนื้อหา รวมถึงแผนภูมิ, ตาราง, ไดอะแกรม, รูปภาพ, และสื่อ หลังจากถูกเติมเต็มแล้ว ให้ตรวจสอบคลาสรูปทรงจริงเพื่อทราบว่ามันบรรจุอะไร เค้าโครงที่เฉพาะเจาะจงอาจเปิดเผยประเภท [PlaceholderType.CHART](https://reference.aspose.com/slides/th/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/th/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/th/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/th/python-net/aspose.slides/placeholdertype/), หรือ [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/th/python-net/aspose.slides/placeholdertype/)

Aspose.Slides ไม่ได้แปลง Placeholder [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ที่ว่างเปล่าให้เป็น [Chart](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/) เพียงโดยการเปลี่ยน [Placeholder.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/placeholder/type/); ประเภทนั้นเป็นแบบอ่านอย่างเดียว เพื่อเติมแผนภูมิหรือพื้นที่เนื้อหาที่ว่างเปล่าโดยโปรแกรม ให้เพิ่มออบเจ็กต์ที่ต้องการที่พิกัดของ Placeholder แล้วลบ Placeholder ที่ว่างเปล่าออก ตัวอย่างต่อไปทำเช่นนั้นสำหรับแผนภูมิ:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

แผนภูมิที่เพิ่มเข้ามาเป็นแผนภูมิโดยทั่วไปแบบโลคัล มันครอบพื้นที่ของ Placeholder แต่ไม่ได้สืบทอดจาก Placeholder ของเลย์เอาต์ ใช้บทความการจัดการแผนภูมิที่เฉพาะเจาะจง [/slides/th/python-net/powerpoint-charts/] เมื่อคุณต้องการเปลี่ยนหมวดหมู่, ซีรีส์ หรือข้อมูล workbook ของแผนภูมิ

## **ตัวอย่างครบวงจร: อัปเดตข้อความหรือภาพเนื้อหา**

ตัวอย่างต่อไปเป็นการทำงานตั้งแต่ต้นจนจบ เปิดเทมเพลต, ค้นหาสไลด์แรกสำหรับ Placeholder ของหัวเรื่องหรือรูปภาพ, ตรวจสอบประเภท Placeholder และรูปทรง, อัปเดตเนื้อหาที่เหมาะสม, แล้วบันทึกผลลัพธ์ ตัวอย่างนี้ตั้งใจหลีกเลี่ยงการสันนิษฐานดัชนีรูปทรงหรือการถือว่า Placeholder ทุกอันเป็นคลาสรูปทรงเดียวกัน

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**อะไรคือ base placeholder?**

Base placeholder คือรูปทรงที่สอดคล้องบนเลย์เอาต์หรือมาสเตอร์ซึ่ง Placeholder อื่นสืบทอดมาจากนั้น ใช้ [Shape.get_base_placeholder](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/get_base_placeholder/) เพื่อดึงข้อมูล Placeholder นั้น รูปทรงโลคัลทั่วไปจะคืนค่า `None` เนื่องจากไม่เป็นส่วนหนึ่งของลำดับชั้น Placeholder

**ฉันสามารถเปลี่ยนหัวเรื่องทั้งหมดของสไลด์โดยแก้ไข Placeholder บนเลย์เอาต์ได้หรือไม่?**

คุณสามารถเปลี่ยนการจัดรูปแบบหรือข้อความ Prompt ที่สืบทอดผ่านเลย์เอาต์ได้ แต่เนื้อหาหัวเรื่องที่มีอยู่จริงถูกเก็บไว้บนสไลด์ปกติ เพื่อแทนที่ข้อความหัวเรื่องจริงทั่วงานนำเสนอ ต้องวนลูปผ่านสไลด์แต่ละอันและอัปเดต Placeholder ของหัวเรื่องแต่ละอัน

**ฉันจัดการ Placeholder สำหรับวันที่, เลขสไลด์, ส่วนหัว, และส่วนท้ายอย่างไร?**

ใช้ตัวจัดการส่วนหัวและส่วนท้ายในสโคปที่เหมาะสม ไม่ว่าจะเป็นสไลด์, เลย์เอาต์, มาสเตอร์, โน้ต, หรือ Handout ดูบทความ [Manage Presentation Header and Footer](/slides/th/python-net/presentation-header-and-footer/) เพื่อดูตัวอย่างเต็มรูปแบบ