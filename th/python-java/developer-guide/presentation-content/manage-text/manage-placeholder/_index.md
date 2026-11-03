---
title: จัดการ Placeholder ของการนำเสนอใน Python
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/python-java/manage-placeholder/
keywords:
- ตำแหน่งที่จอง
- ตำแหน่งที่จองข้อความ
- ตำแหน่งที่จองภาพ
- ตำแหน่งที่จองแผนภูมิ
- ตำแหน่งที่จองเนื้อหา
- ข้อความเชิญ
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไข placeholder ข้อความ, รูปภาพ, แผนภูมิและเนื้อหาและเข้าใจการสืบทอดของ placeholder ด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Placeholder คือรูปร่างที่สงวนตำแหน่งสำหรับประเภทเนื้อหาเฉพาะในเทมเพลตการนำเสนอ ตัวอย่างทั่วไปได้แก่ ตัวจารร์, เนื้อหา, รูปภาพ, แผนภูมิ, และ placeholder เนื้อหาทั่วไป ไม่เหมือนรูปร่างปกติ placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบ และการตั้งค่าอื่น ๆ จากสไลด์เลเอาต์หรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านเมธอด [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) เมธอดจะคืนค่าอ็อบเจ็กต์ [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) หรือ `None` สำหรับรูปร่างปกติ ใช้งาน [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) เพื่อกำหนดว่า placeholder มีจุดประสงค์เพื่อบรรจุอะไร

ประเภทของรูปร่างยังคงมีความสำคัญหลังจากคุณรู้ประเภทของ placeholder:

- Placeholder ของข้อความ, รูปภาพ, แผนภูมิ, หรือเนื้อหาที่ว่างเปล่ามักจะแสดงด้วย [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
- Placeholder รูปภาพที่มีเนื้อหาแล้วสามารถแสดงด้วย [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/).
- Placeholder แผนภูมิที่มีเนื้อหาแล้วสามารถแสดงด้วย [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/).
- Placeholder เนื้อหาอาจบรรจุหลายประเภทของเนื้อหา ตรวจสอบทั้ง [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) และประเภทของรูปร่างในเวลาเรียกใช้ แทนการสมมติว่า placeholder ทุกตัวเป็น [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) อธิบายบทบาทของ placeholder; มันไม่ได้รับประกันประเภทของรูปร่างในเวลาเรียกใช้ ควรตรวจสอบประเภทเสมอก่อนเข้าถึงสมาชิกที่เกี่ยวกับข้อความ, รูปภาพ, แผนภูมิ, ตาราง, หรือสื่อ
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder สร้างลำดับชั้น:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่ใช้ซ้ำได้และในบางกรณี placeholder ระดับมาสเตอร์
2. สไลด์เลเอาต์กำหนดการจัดวางที่ใช้โดยสไลด์ปกติหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์
3. สไลด์ปกติมี placeholder ของสไลด์นั้นและสามารถสืบทอดจากเลเอาต์ของมัน

เรียกใช้ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) เพื่อเลื่อนระดับหนึ่งขึ้นในลำดับชั้นนี้ Placeholder ของสไลด์โดยทั่วไปจะคืนค่า placeholder ของเลเอาต์; placeholder ของเลเอาต์สามารถคืนค่า placeholder ของมาสเตอร์ได้ เมธอดจะคืนค่า `None` เมื่อรูปร่างไม่มี base placeholder

ตัวอย่างต่อไปนี้แสดงรายการ placeholder บนสไลด์แรกและรายงาน base placeholder ของแต่ละรายการ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

การแก้ไข placeholder บนสไลด์ปกติสร้างหรือเปลี่ยนการแทนที่แบบโลคัลสำหรับสไลด์นั้น การแก้ไขเลเอาต์หรือมาสเตอร์ที่เกี่ยวข้องสามารถส่งผลต่อสไลด์ทั้งหมดที่ยังคงสืบทอดการตั้งค่านั้น รูปร่างปกติแบบโลคัลไม่มี base placeholder และไม่เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน

## **ลบสถานะ Placeholder**

เมื่อปรับเทมเพลต ใช้ [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) เพื่อเก็บอ็อบเจ็กต์ที่มีอยู่เป็นรูปร่างปกติ เมธอด [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) จะคืนค่า `None` แต่รูปร่างยังคงอยู่ในคอลเลกชันของสไลด์ ในทางกลับกัน [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) จะลบรูปร่างออกจากคอลเลกชันนั้น

ตัวอย่างต่อไปนี้ต้องมีไฟล์ `template.pptx` อย่างน้อยหนึ่งสไลด์และ placeholder ข้อความที่ไม่ว่างบนสไลด์แรก ใช้ placeholder ที่มีการจัดรูปแบบสืบทอดจากเลเอาต์หรือมาสเตอร์เพื่อดูผลของการลบความสัมพันธ์ ตัวอย่างตรวจสอบว่ารูปร่างเดียวกันยังคงอยู่, เรียกเมธอดอีกครั้งบนรูปร่างที่ตอนนี้เป็นปกติ, แล้วบันทึกผลลัพธ์

{{% alert color="warning" title="Warning" %}}
การลบสถานะ placeholder ไม่ได้รักษาการตั้งค่าการแสดงผลที่สืบทอดโดยอัตโนมัติ ตัวอย่างด้านล่างตั้งใจทิ้งการตั้งค่าเหล่านั้นไว้โดยไม่เปลี่ยนแปลง ดังนั้นผลลัพธ์อาจดูต่างออกไป รูปร่างที่ตำแหน่งและขนาดสืบทอดทั้งหมดอาจมีพิกัดและมิตศูนย์หลังจากเรียกและกลายเป็นไม่มองเห็นได้แม้ว่าจะยังคงอยู่ในคอลเลกชัน
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # การเรียกเมธอดบนรูปร่างปกติจะไม่มีผล
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

สำหรับ placeholder ที่ตรงกัน การตรวจสอบทั้งสามจะพิมพ์ `True` ข้อความยังคงอยู่ แต่ตำแหน่ง, ขนาด, การหมุน, ฟอนต์, การจัดย่อหน้า, ระยะขอบของ text‑frame, การยึดแนวตั้ง, การเติมสีและการตั้งค่าเส้นที่สืบทอดอาจเปลี่ยนเมื่อความสัมพันธ์ของ placeholder ถูกลบ ตัวอย่างเช่น การจัดรูปแบบหัวเรื่องที่สืบทอดอาจย้อนกลับไปเป็นการจัดรูปแบบข้อความปกติ ดู [เลเอาต์สไลด์](/slides/th/python-java/slide-layout/) เพื่อข้อมูลเพิ่มเติมเกี่ยวกับเลเอาต์

เพื่อรักษาลักษณะที่ตั้งใจไว้ ให้จับตำแหน่ง, ขนาดและการหมุนที่ได้ก่อนเรียกเมธอด และคัดลอกค่าการจัดรูปแบบที่มีประสิทธิผลที่ต้องการไปยังตัวแปรแยกต่างหาก ดึงค่าดังกล่าวผ่าน [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) และ [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) อย่าพึ่งพาแค่วัตถุ effective‑format เท่านั้น เพราะค่าการจัดรูปแบบข้อความอาจเปลี่ยนหลังจากความสัมพันธ์ถูกลบ ให้นำค่าที่จับได้ไปใช้กับรูปร่างปกติอย่างชัดเจนหลังจากนั้น รวมถึงครอบครัวฟอนต์, ขนาด, สไตล์, สี, การตั้งค่ย่อหน้า, การตั้งค่า text‑frame, การเติมสีและเส้นที่ใช้ในเทมเพลตของคุณ

เรขาคณิตของรูปร่างที่สืบทอดอาจต้องกำหนดอย่างชัดเจนผ่าน [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType) สำหรับ placeholder ข้อความสี่เหลี่ยมผืนผ้า นั่นหมายถึงการกำหนดค่า [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle); การคืนค่าเฉพาะการเติมสีและเส้นอาจไม่ทำให้สี่เหลี่ยมที่มองเห็นได้กลับมาเท่าเดิม เทมเพลตที่มีเอฟเฟกต์เพิ่มเติมหรือการจัดรูปแบบที่ซับซ้อนกว่าต้องจัดการการตั้งค่าเหล่านั้นด้วย

## **เปลี่ยนข้อความใน Placeholder**

Title, centered‑title, subtitle, body, และ placeholder ข้อความโดยทั่วไปรองรับข้อความ ตรวจสอบให้มี [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ก่อนใช้เมธอด [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame)

ตัวอย่างนี้อัปเดต placeholder ชื่อเรื่องแรกบนสไลด์แรกและบันทึกผลลัพธ์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

รูปแบบนี้หลีกเลี่ยงการถือว่า picture, chart, table หรือ media placeholder เป็น [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) อีกทั้งยังระบุ placeholder ตามวัตถุประสงค์แทนการพึ่งพาดัชนีรูปร่างที่เปราะบาง

## **ตั้งข้อความ Prompt บนเลเอาต์**

Prompt text คือคำแนะนำที่แสดงในเวลาออกแบบใน placeholder ว่าง เช่น *Click to add title* ตั้งข้อความ Prompt ที่กำหนดเองบน placeholder ของเลเอาต์แทนการพยายามเข้าถึงผ่านคอลเลกชันรูปร่างของสไลด์ปกติ เข้าถึงเลเอาต์ผ่าน [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) และวนลูปคอลเลกชันที่คืนค่ามาจาก [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes)

ตัวอย่างต่อไปนี้เปลี่ยน prompt ของชื่อเรื่องและหัวข้อรองบนเลเอาต์ที่ใช้โดยสไลด์แรก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Prompt text ไม่ใช่เนื้อหาสไลด์ปกติ มันตั้งใจสำหรับ placeholder ว่างในแอปพลิเคชันการแก้ไขเช่น PowerPoint เมื่อลูกค้า หรือโปรแกรมใส่เนื้อหาจริงแล้ว prompt จะไม่แสดงอีก การเปลี่ยน prompt ยังไม่ได้แทนที่ข้อความที่มีอยู่บนสไลด์ที่ใช้เลเอาต์นั้น

## **อัปเดต Picture Placeholder**

มีสองกรณีที่ต้องจัดการ:

- หาก picture placeholder มีเนื้อหาแล้วและแสดงด้วย [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) ให้แทนที่รูปภาพผ่าน [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) และ [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage)
- หากยังเป็น placeholder ว่าง ให้เพิ่ม picture frame ที่พิกัดของ placeholder ด้วย [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) และลบ placeholder ว่างออก

ตัวอย่างต่อไปสนับสนุนทั้งสองกรณีและบันทึกงานนำเสนอ:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การแทนที่ที่สร้างสำหรับ placeholder ว่างเป็น picture frame แบบโลคัล ไม่ใช่ placeholder ใหม่ เพราะ [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) ไม่ให้ setter มันเก็บตำแหน่งที่สงวนไว้แต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder หากต้องการรักษาความสัมพันธ์ของ placeholder เป็นสิ่งสำคัญ ให้เตรียมและเติม placeholder ใน PowerPoint ก่อน แล้วอัปเดต [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับความโปร่งใสของรูปภาพ, การครอป, และเอฟเฟกต์เฉพาะของรูปภาพอื่น ๆ ดู [จัดการเฟรมรูปภาพ](/slides/th/python-java/picture-frame/) การดำเนินการเหล่านี้เป็นของ picture frame หรือ picture fill ไม่ใช่ของ metadata ของ placeholder

## **ทำงานกับ Chart และ Content Placeholder**

Placeholder แผนภูมิที่มีเนื้อหาแล้วสามารถแสดงด้วย [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) ตัวอย่างนี้ค้นหาแผนภูมินั้นโดยทั้งประเภท placeholder และประเภทรูปร่างในเวลาเรียกใช้ เปลี่ยนชื่อเรื่องและบันทึกไฟล์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Placeholder เนื้อหาทั่วไปโดยทั่วไปมี [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object) ใน PowerPoint มันทำหน้าที่เป็นตัวเปิดสำหรับหลายประเภทของเนื้อหา รวมถึงแผนภูมิ, ตาราง, ไดอะแกรม, รูปภาพ, และสื่อ หลังจากถูกเติมแล้ว ให้ตรวจสอบประเภทของรูปร่างจริงเพื่อทราบว่าเก็บอะไรไว้เลเอาต์พิเศษบางอย่างยังอาจเผย [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) หรือ [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram)

Aspose.Slides ไม่ได้แปลง placeholder [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ว่างให้เป็น [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) เพียงแค่เปลี่ยน [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType); ไม่สามารถเปลี่ยนประเภทผ่าน API ได้ เพื่อเติมแผนภูมิหรือพื้นที่เนื้อหาว่างแบบโปรแกรม ให้เพิ่มอ็อบเจ็กต์ที่ต้องการที่พิกัดของ placeholder แล้วลบ placeholder ว่าง ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับแผนภูมิ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

แผนภูมิที่เพิ่มเข้ามาเป็นแผนภูมิโลคัลทั่วไป มันครอบคลุมพื้นที่ของ placeholder แต่ไม่สืบทอดจาก placeholder ของเลเอาต์ ใช้ [บทความการจัดการแผนภูมิ](/slides/th/python-java/powerpoint-charts/) เมื่อจำเป็นต้องแทนที่ประเภท, ชุดข้อมูล หรือข้อมูลสมุดงานของแผนภูมิ

## **ตัวอย่างเต็ม: อัปเดตข้อความหรือเนื้อหารูปภาพ**

ตัวอย่างแบบครบวงจรต่อไปนี้เปิดเทมเพลต, ค้นหาสไลด์แรกสำหรับ placeholder ชื่อเรื่องหรือรูปภาพ, ตรวจสอบประเภทของ placeholder และรูปร่าง, อัปเดตเนื้อหาที่เหมาะสม, และบันทึกผลลัพธ์. ตัวอย่างนี้ตั้งใจหลีกเลี่ยงการสมมติอินเด็กซ์ของรูปร่างหรือการถือว่า placeholder ทุกตัวเป็นประเภทเดียวกัน.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**Placeholder พื้นฐานคืออะไร?**

Placeholder พื้นฐานคือรูปร่างที่สอดคล้องบนเลเออต์หรือมาสเตอร์ซึ่ง placeholder อื่นสืบทอดจากนั้น ใช้ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) เพื่อดึงคืน มรูปร่างโลคัลปกติจะคืนค่า `None` เพราะไม่เป็นส่วนหนึ่งของลำดับชั้น placeholder

**ฉันสามารถเปลี่ยนหัวเรื่องทั้งหมดของสไลด์โดยการแก้ไข layout placeholder ได้หรือไม่?**

คุณสามารถเปลี่ยนการจัดรูปแบบหรือข้อความ Prompt ที่สืบทอดผ่านเลเอาต์ได้ แต่เนื้อหาหัวเรื่องที่มีอยู่ถูกเก็บไว้บนสไลด์ปกติ การแทนที่ข้อความหัวเรื่องจริงในงานนำเสนอทั้งหมดต้องวนลูปสไลด์และอัปเดตแต่ละ placeholder ของหัวเรื่อง

**ฉันจัดการ placeholder ของวันที่, หมายเลขสไลด์, ส่วนหัวและส่วนท้ายอย่างไร?**

ใช้ผู้จัดการส่วนหัวและส่วนท้ายในระดับสไลด์, เลเอาต์, มาสเตอร์, โน้ต หรือแจกจ่ายตามความต้องการ ดู [Manage Presentation Header and Footer](/slides/th/python-java/presentation-header-and-footer/) สำหรับตัวอย่างครบถ้วน