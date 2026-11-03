---
title: จัดการ Placeholder ของการนำเสนอใน Python
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/python-net/manage-placeholder/
keywords:
- ตำแหน่งจอง
- placeholder ข้อความ
- placeholder รูปภาพ
- placeholder ชาร์ต
- placeholder เนื้อหา
- ข้อความ Prompt
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไข placeholder ของข้อความ, รูปภาพ, ชาร์ต, และเนื้อหา รวมถึงทำความเข้าใจการสืบทอดของ placeholder ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

Placeholder คือรูปทรงที่สงวนตำแหน่งสำหรับเนื้อหาแบบเฉพาะในเทมเพลตการนำเสนอ ตัวอย่างทั่วไปได้แก่ placeholder สำหรับหัวเรื่อง, เนื้อหา, รูปภาพ, ชาร์ต, และ placeholder เนื้อหาทั่วไปอื่น ๆ ไม่เหมือนรูปทรงทั่วไป Placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบ, และการตั้งค่าอื่น ๆ จากสไลด์เลเอาต์หรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านคุณสมบัติ [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) คุณสมบัตินี้จะคืนค่าออบเจ็กต์ [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) หรือ `None` สำหรับรูปทรงปกติ ใช้ [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) เพื่อตรวจสอบว่า placeholder มีจุดประสงค์เพื่อบรรจุอะไร

คลาสรูปทรงยังคงมีความสำคัญหลังจากที่คุณทราบประเภทของ placeholder:

- placeholder สำหรับข้อความ, รูปภาพ, ชาร์ต หรือเนื้อหาที่ว่างเปล่ามักถูกแทนด้วย [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)  
- placeholder รูปภาพที่มีเนื้อหาอยู่สามารถแทนด้วย [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)  
- placeholder ชาร์ตที่มีเนื้อหาอยู่สามารถแทนด้วย [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)  
- placeholder เนื้อหาอาจบรรจุหลายประเภท ตรวจสอบทั้ง [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) และคลาสรูปทรงขณะทำงาน แทนที่จะสันนิษฐานว่า placeholder ทุกตัวเป็น [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) บรรยายบทบาทของ placeholder; มันไม่รับประกันว่ารูปทรงขณะทำงานจะเป็นคลาสใด ควรทำการตรวจสอบประเภทก่อนเข้าถึงสมาชิกข้อความ, รูปภาพ, ชาร์ต, ตาราง หรือสื่ออื่น ๆ เสมอ
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder มีโครงสร้างเป็นลำดับขั้น:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่รีใช้ได้และในบางกรณีกำหนด placeholder ระดับมาสเตอร์  
2. สไลด์เลเอาต์กำหนดการจัดวางที่ใช้โดยสไลด์ปกติหนึ่งหรือหลายสไลด์ และสามารถสืบทอดจากมาสเตอร์ได้  
3. สไลด์ปกติมี placeholder ของสไลด์นั้นและสามารถสืบทอดจากเลเอาต์ของมันได้  

เรียกใช้ [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) เพื่อย้ายหนึ่งระดับขึ้นในลำดับขั้น สไลด์ placeholder ปกติจะคืนค่า placeholder ของเลเอาต์; placeholder ของเลเอาต์อาจคืนค่า placeholder ของมาสเตอร์ วิธีนี้จะคืนค่า `None` เมื่อรูปทรงไม่มี base placeholder

ตัวอย่างต่อไปนี้แสดงรายการ placeholder บนสไลด์แรกและรายงาน base placeholder ของแต่ละอัน:

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

การแก้ไข placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการแทนที่ระดับท้องถิ่นสำหรับสไลด์นั้น การแก้ไขเลเอาต์หรือมาสเตอร์ที่เกี่ยวข้องอาจส่งผลต่อทุกสไลด์ที่ยังคงสืบทอดการตั้งค่านั้น รูปทรงปกติระดับท้องถิ่นไม่มี base placeholder และจะไม่เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน

## **ลบสถานะ Placeholder**

เมื่อนำเทมเพลตไปใช้ ให้ใช้ [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) เพื่อเก็บออบเจ็กต์ที่มีอยู่เป็นรูปทรงปกติ คุณสมบัติ [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) จะกลายเป็น `None` แต่รูปทรงยังคงอยู่ในคอลเลกชันของสไลด์ ในขณะที่ [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) จะลบรูปทรงจากคอลเลกชันนั้น

ตัวอย่างต่อไปนี้ต้องมีไฟล์ `template.pptx` ที่มีอย่างน้อยหนึ่งสไลด์และ placeholder ข้อความที่ไม่ว่างเปล่าบนสไลด์แรก ใช้ placeholder ที่สืบทอดการจัดรูปแบบจากเลเอาต์หรือมาสเตอร์เพื่อดูผลของการลบความสัมพันธ์ ตัวอย่างจะตรวจสอบว่ารูปทรงเดียวกันยังคงอยู่ เรียกเมธอดนี้อีกครั้งบนรูปทรงที่กลายเป็นปกติ แล้วบันทึกผลลัพธ์

{{% alert color="warning" title="Warning" %}}
การลบสถานะ placeholder ไม่ได้ทำให้การตั้งค่าการแสดงผลที่สืบทอดโดยอัตโนมัติเสมอ ตัวอย่างด้านล่างจึงไม่ได้เปลี่ยนแปลงการตั้งค่าเหล่านั้น ดังนั้นผลลัพธ์อาจดูแตกต่างกัน รูปทรงที่สืบทอดตำแหน่งและขนาดอย่างเต็มที่อาจมีค่า координат และขนาดเป็นศูนย์หลังการเรียกและกลายเป็นไม่มองเห็นได้ แม้ว่าจะยังคงอยู่ในคอลเลกชัน
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # การเรียกเมธอดบนรูปทรงปกติไม่มีผล.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

สำหรับ placeholder ที่ตรงกัน การตรวจสอบทั้งสามจะพิมพ์ `True` ข้อความจะคงอยู่ แต่ตำแหน่ง, ขนาด, การหมุน, แบบอักษร, การจัดย่อหน้, ระยะขอบของ text‑frame, การยึดแนวตั้ง, การเติมสี, และการตั้งค่าเส้นสามารถเปลี่ยนแปลงได้เมื่อความสัมพันธ์ของ placeholder ถูกลบ ตัวอย่างเช่น การจัดรูปแบบหัวเรื่องที่สืบทอดอาจถอยกลับไปเป็นการจัดรูปแบบข้อความธรรมดา ดูเพิ่มเติมที่ [เค้าโครงสไลด์](/slides/th/python-net/slide-layout/) เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับเลเอาต์

เพื่อคงรูปลักษณ์ตามที่ตั้งใจ ควรบันทึกตำแหน่ง, ขนาด, และการหมุนที่ได้รับการคำนวณแล้วก่อนเรียกเมธอด แล้วคัดลอกค่าการจัดรูปแบบที่มีผลจริงที่ต้องการลงในตัวแปรแยกต่างหาก ดึงค่าต่าง ๆ ผ่าน [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/), และ [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/). อย่าอิงแค่วัตถุ effective‑format เท่านั้น เพราะค่าการจัดรูปแบบข้อความของพวกมันอาจเปลี่ยนแปลงหลังจากความสัมพันธ์ถูกลบ นำค่าที่บันทึกไว้ไปใช้กับรูปทรงปกติโดยตรงต่อไป รวมถึงครอบครัวฟอนต์, ขนาด, สไตล์, สี, การตั้งค่าประโยค, การตั้งค่า text‑frame, การเติมสี, และเส้นที่เทมเพลตของคุณใช้งาน

รูปทรงเรขาคณิตที่สืบทอดอาจต้องกำหนดด้วยตนเองผ่าน [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/). สำหรับ placeholder ข้อความสี่เหลี่ยม นี้หมายถึงการกำหนดค่าเป็น [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/); การคืนค่าเพียงการเติมสีและเส้นอาจไม่ทำให้สี่เหลี่ยมมองเห็นได้เท่าเดิม เทมเพลตที่มีเอฟเฟ็กต์เพิ่มเติมหรือการจัดรูปแบบที่ซับซ้อนกว่าจะต้องจัดการการตั้งค่าเหล่านั้นด้วยเช่นกัน

## **เปลี่ยนข้อความใน Placeholder**

หัวเรื่อง, centered‑title, subtitle, body, และ placeholder ข้อความโดยทั่วไปรองรับข้อความ ตรวจสอบว่ารูปเป็น [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ก่อนใช้คุณสมบัติ [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/)

ตัวอย่างต่อไปนี้อัปเดต placeholder หัวเรื่องแรกบนสไลด์แรกแล้วบันทึกผลลัพธ์:

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

รูปแบบนี้ช่วยหลีกเลี่ยงการจัดการกับ placeholder รูปภาพ, ชาร์ต, ตาราง หรือสื่อเป็นออบเจ็กต์ [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) อีกด้วย อีกทั้งยังระบุ placeholder ตามจุดประสงค์แทนการพึ่งพาดัชนีรูปทรงที่อ่อนไหว

## **ตั้งค่าข้อความ Prompt บน Layout**

ข้อความ Prompt คือข้อความคำแนะนำที่แสดงใน placeholder ว่าง เช่น *Click to add title* กำหนดข้อความ Prompt ปรับแต่งบน placeholder ของเลเอาต์แทนที่จะพยายามเข้าถึงผ่านคอลเลกชันรูปทรงของสไลด์ปกติ เข้าถึงเลเอาต์ผ่าน [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) แล้ววนลูปผ่าน [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/)

ตัวอย่างต่อไปนี้เปลี่ยน Prompt ของหัวเรื่องและหัวเรื่องรองบนเลเอาต์ที่สไลด์แรกใช้:

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

ข้อความ Prompt ไม่ถือเป็นเนื้อหาสไลด์ปกติ มันมีจุดประสงค์สำหรับ placeholder ที่ว่างในแอปพลิเคชันแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมเติมเนื้อหาจริงเข้ามา Prompt จะไม่แสดงอีกต่อไป การเปลี่ยน Prompt ยังไม่ทำให้ข้อความที่มีอยู่บนสไลด์ที่ใช้เลเอาต์นั้นถูกแทนที่

## **อัปเดต Picture Placeholder**

มีสองกรณีที่ต้องจัดการ:

- หาก picture placeholder มีเนื้อหาแล้วและเป็นออบเจ็กต์ [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) ให้แทนที่ภาพผ่าน [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) และ [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/)  
- หากยังเป็น placeholder ว่างเปล่า ให้เพิ่ม picture frame ที่พิกัดของ placeholder ด้วย [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) และลบ placeholder ว่างนั้น

ตัวอย่างต่อไปนี้รองรับทั้งสองกรณีและบันทึกการนำเสนอ:

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

การแทนที่ที่สร้างสำหรับ placeholder ว่างเปล่าเป็น picture frame ระดับท้องถิ่น ไม่ใช่ placeholder ใหม่ เนื่องจากคุณสมบัติ [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) เป็นแบบอ่าน‑อย่างเดียว มันยังคงตำแหน่งที่สงวนไว้แต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder หากการรักษาความสัมพันธ์ของ placeholder มีความสำคัญ ให้เตรียมและเติมข้อมูล placeholder ใน PowerPoint ก่อน แล้วอัปเดต [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับความโปร่งใสของภาพ, การครอบตัด, และเอฟเฟ็กต์เฉพาะของรูปภาพอื่น ๆ ดูที่ [Manage Picture Frames](/slides/th/python-net/picture-frame/). การทำงานเหล่านี้เป็นของ picture frame หรือ picture fill ไม่ใช่ของเมตาดาต้า placeholder

## **ทำงานกับ Chart และ Content Placeholder**

placeholder ชาร์ตที่มีเนื้อหาแล้วสามารถแทนด้วย [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) ตัวอย่างต่อไปนี้ค้นหา chart ดังกล่าวโดยใช้ทั้งประเภท placeholder และคลาสขณะทำงาน, เปลี่ยนหัวเรื่อง, แล้วบันทึกไฟล์:

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

placeholder เนื้อหาแบบทั่วไปมักมีค่า [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/). ใน PowerPoint มันทำหน้าที่เป็นตัวเรียกหลายประเภทเนื้อหา เช่น ชาร์ต, ตาราง, ไดอะแกรม, รูปภาพ, และสื่อ หลังจากถูกเติมแล้ว ให้ตรวจสอบคลาสรูปทรงจริงเพื่อทราบว่ามีอะไรบ้าง เลเอาต์เฉพาะบางอย่างอาจเปิดให้ใช้ [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), หรือ [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)

Aspose.Slides ไม่ได้แปลง placeholder [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ที่ว่างเปล่าให้เป็น [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) เพียงแค่เปลี่ยน [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/); ประเภทนี้เป็นแบบอ่าน‑อย่างเดียว เพื่อเติม chart หรือพื้นที่เนื้อหาที่ว่างเปล่าโดยโปรแกรม ให้เพิ่มออบเจ็กต์ที่ต้องการที่พิกัดของ placeholder แล้วลบ placeholder ที่ว่าง ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับ chart:

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

chart ที่เพิ่มเข้ามาเป็น chart ท้องถิ่นธรรมดา มันครอบพื้นที่ของ placeholder แต่ไม่สืบทอดจาก placeholder ของเลเอาต์ ใช้บทความการจัดการ chart เฉพาะที่ [chart management articles](/slides/th/python-net/powerpoint-charts/) เมื่อคุณต้องการแทนที่ประเภท, ซีรีส์ หรือข้อมูลเวิร์กบุ๊กของมัน

## **ตัวอย่างเต็ม: อัปเดตข้อความหรือภาพเนื้อหา**

ตัวอย่างต่อไปนี้เป็นแบบ end‑to‑end เปิดเทมเพลต, ค้นหาสไลด์แรกเพื่อหา placeholder ของหัวเรื่องหรือรูปภาพ, ตรวจสอบประเภท placeholder และรูปทรง, อัปเดตเนื้อหาที่เหมาะสม, แล้วบันทึกผลลัพธ์ ตัวอย่างตั้งใจหลีกเลี่ยงการสันนิษฐานดัชนีรูปทรงหรือการถือว่า placeholder ทุกตัวเป็นคลาสรูปทรงเดียวกัน

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

## **คำถามที่พบบ่อย**

**Placeholder พื้นฐานคืออะไร?**

Placeholder พื้นฐานคือรูปทรงที่สอดคล้องบนเลเอต์หรือมาสเตอร์ที่ placeholder อื่นสืบทอดมาจาก ใช้ [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) เพื่อดึงค่า placeholder พื้นฐาน รูปทรงท้องถิ่นทั่วไปจะคืนค่า `None` เนื่องจากไม่ได้เป็นส่วนหนึ่งของโครงสร้าง hierarchy ของ placeholder

**ฉันสามารถเปลี่ยนหัวเรื่องทั้งหมดของสไลด์ได้โดยการแก้ไข placeholder ของเลเอาต์หรือไม่?**

คุณสามารถเปลี่ยนการจัดรูปแบบที่สืบทอดหรือข้อความ Prompt ผ่านเลเอาต์ได้ แต่เนื้อหาหัวเรื่องที่มีอยู่จะถูกเก็บไว้บนสไลด์ปกติ เพื่อแทนที่ข้อความหัวเรื่องจริงทั่วทั้งงานนำเสนอ ให้วนลูปผ่านสไลด์และอัปเดตแต่ละ placeholder ของหัวเรื่อง

**ฉันจะจัดการกับ placeholder ของวันที่, หมายเลขสไลด์, ส่วนหัว, และส่วนท้ายอย่างไร?**

ใช้ผู้จัดการส่วนหัวและส่วนท้ายในขอบเขตของสไลด์, เลเอาต์, มาสเตอร์, โน้ต, หรือโฮนดเอาต์ที่เหมาะสม ดูที่ [Manage Presentation Header and Footer](/slides/th/python-net/presentation-header-and-footer/) สำหรับตัวอย่างครบถ้วน