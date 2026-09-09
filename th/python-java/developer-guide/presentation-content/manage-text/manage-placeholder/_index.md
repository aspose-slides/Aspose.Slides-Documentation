---
title: จัดการ Placeholder ของการนำเสนอด้วย Python
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/python-java/manage-placeholder/
keywords:
  - ตัวจัดตำแหน่ง
  - ตัวจัดตำแหน่งข้อความ
  - ตัวจัดตำแหน่งภาพ
  - ตัวจัดตำแหน่งแผนภูมิ
  - ตัวจัดตำแหน่งเนื้อหา
  - ข้อความ Prompt
  - PowerPoint
  - การนำเสนอ
  - Python
  - Java
  - Aspose.Slides
description: "เรียนรู้วิธีการตรวจสอบและแก้ไขตัวจัดตำแหน่งข้อความ, รูปภาพ, แผนภูมิ และเนื้อหา, รวมถึงทำความเข้าใจการสืบทอดของตัวจัดตำแหน่งด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Placeholder คือรูปทรงที่สงวนตำแหน่งสำหรับประเภทเนื้อหาที่กำหนดในเทมเพลตการนำเสนอ ตัวอย่างทั่วไปได้แก่ placeholder สำหรับหัวเรื่อง, เนื้อหา, รูปภาพ, แผนภูมิ และ placeholder เนื้อหาทั่วไป ไม่เหมือนรูปทรงทั่วไป placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบ และการตั้งค่าอื่น ๆ จากสไลด์เลเอาต์หรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านเมธอด [Shape.getPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getPlaceholder) เมธอดนี้จะคืนค่าอ็อบเจกต์ [Placeholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/placeholder/) หรือ `None` สำหรับรูปทรงปกติ ใช้ [Placeholder.getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/placeholder/#getType) เพื่อตรวจสอบ placeholder นั้นตั้งใจจะบรรจุอะไร

ประเภทของรูปทรงยังคงสำคัญหลังจากคุณทราบประเภทของ placeholder:

- Placeholder ที่ว่างเปล่าสำหรับข้อความ, รูปภาพ, แผนภูมิ หรือเนื้อหามักจะแสดงเป็น [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/).
- Placeholder รูปภาพที่มีเนื้อหาแล้วสามารถแสดงเป็น [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/).
- Placeholder แผนภูมิที่มีเนื้อหาแล้วสามารถแสดงเป็น [Chart](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/).
- Placeholder เนื้อหาอาจบรรจุหลายประเภทของเนื้อหา ตรวจสอบทั้ง [Placeholder.getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/placeholder/#getType) และประเภทของรูปทรงขณะรันไทม์ แทนการสันนิษฐานว่า placeholder ทุกอันเป็น [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/placeholder/#getType) อธิบายบทบาทของ placeholder; แต่ไม่ได้รับประกันประเภทของรูปทรงขณะรันไทม์ ควรตรวจสอบประเภทเสมอก่อนเข้าถึงสมาชิกที่เกี่ยวกับข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่อ.
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder มีโครงสร้างลำดับขั้น:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่สามารถนำกลับใช้ได้และในบางกรณี placeholder ระดับมาสเตอร์.
2. สไลด์เลเอาต์กำหนดการจัดวางที่ใช้โดยสไลด์ปกติหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์.
3. สไลด์ปกติมี placeholder ของสไลด์นั้นและสามารถสืบทอดจากเลเอาต์ของมัน.

ใช้เมธอด [Shape.getBasePlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getBasePlaceholder) เพื่อขึ้นหนึ่งระดับในลำดับชั้นนี้ placeholder ของสไลด์ปกติจะคืนค่า placeholder ของเลเอาต์; placeholder ของเลเออต์อาจคืนค่า placeholder ของมาสเตอร์ เมธอดจะคืนค่า `None` เมื่อรูปทรงไม่มี base placeholder.

ตัวอย่างต่อไปนี้จะแสดงรายการ placeholder บนสไลด์แรกและรายงาน base placeholder ของพวกมัน:

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

การแก้ไข placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการแทนที่ในระดับท้องถิ่นสำหรับสไลด์นั้น การแก้ไขเลเอาต์หรือมาสเตอร์ที่เกี่ยวข้องสามารถส่งผลต่อสไลด์ทั้งหมดที่ยังคงสืบทอดการตั้งคีนั้น รูปทรงปกติทั่วไปในระดับท้องถิ่นไม่มี base placeholder และจะไม่ได้เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน.

## **เปลี่ยนข้อความใน Placeholder**

Placeholder สำหรับหัวเรื่อง, หัวเรื่องกึ่งกลาง, หัวเรื่องรอง, เนื้อหา, และข้อความส่วนใหญ่สนับสนุนข้อความ ตรวจสอบว่าเป็น [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ก่อนใช้เมธอด [getTextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/#getTextFrame) ของมัน.

ตัวอย่างนี้อัปเดต placeholder หัวเรื่องแรกบนสไลด์แรกและบันทึกผลลัพธ์:

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

รูปแบบนี้ช่วยหลีกเลี่ยงการพิจารณา placeholder ของรูปภาพ, แผนภูมิ, ตาราง หรือสื่อเป็น [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) อีกทั้งยังระบุ placeholder ตามวัตถุประสงค์แทนพึ่งพาดัชนีรูปทรงที่เปราะบาง.

## **กำหนดข้อความ Prompt บนเลเอาต์**

ข้อความ Prompt คือคำสั่งในเวลาการออกแบบที่แสดงใน placeholder ว่าง เช่น *คลิกเพื่อเพิ่มหัวเรื่อง* ให้กำหนดข้อความ Prompt ที่กำหนดเองบน placeholder ของเลเอาต์แทนการพยายามเข้าถึงผ่านคอลเลกชันรูปทรงของสไลด์ปกติ เข้าถึงเลเอาต์ผ่าน [Slide.getLayoutSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getLayoutSlide) และวนลูปคอลเลกชันที่คืนค่าจาก [BaseSlide.getShapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getShapes).

ตัวอย่างต่อไปนี้จะเปลี่ยน Prompt ของหัวเรื่องและหัวเรื่องรองบนเลเอาต์ที่ใช้โดยสไลด์แรก:

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

ข้อความ Prompt ไม่ใช่เนื้อหาสไลด์ปกติ มันมีจุดประสงค์สำหรับ placeholder ว่างในแอปพลิเคชันการแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริง Prompt จะไม่แสดงอีกต่อไป การเปลี่ยน Prompt ยังไม่แทนที่ข้อความที่มีอยู่ในสไลด์ที่ใช้เลเอต์นั้น.

## **อัพเดท Placeholder รูปภาพ**

มีสองกรณีที่ต้องจัดการ:

- หาก placeholder รูปภาพมีเนื้อหาแล้วและแสดงเป็น [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/), ให้แทนที่รูปภาพผ่าน [PictureFillFormat.getPicture](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#getPicture) และ [Picture.setImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/picture/#setImage).
- หากยังเป็น placeholder ว่าง ให้เพิ่ม picture frame ที่พิกัดของ placeholder ด้วย [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addPictureFrame) และลบ placeholder ว่างนั้น.

ตัวอย่างต่อไปนี้รองรับทั้งสองกรณีและบันทึกพรีเซนเทชัน:

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

การแทนที่ที่สร้างสำหรับ placeholder ว่างเป็น picture frame ระดับท้องถิ่น ไม่ใช่ placeholder ใหม่ เนื่องจาก [Shape.getPlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getPlaceholder) ไม่มีตัวเซตเตอร์ มันจะคงตำแหน่งที่สงวนไว้แต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder หากต้องการรักษาความสัมพันธ์ของ placeholder ไว้ จำเป็นต้องเตรียมและเติมข้อมูล placeholder ใน PowerPoint ก่อน แล้วอัปเดต [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) ที่ได้ด้วย Aspose.Slides.

สำหรับความโปร่งแสงของภาพ, การครอป, และเอฟเฟกต์เฉพาะของรูปภาพอื่น ๆ ดูที่ [Manage Picture Frames](/slides/th/python-java/picture-frame/). การดำเนินการเหล่านั้นเป็นของ picture frame หรือ picture fill ไม่ใช่เมตาดาต้า placeholder.

## **ทำงานกับ Chart และ Content Placeholder**

Placeholder แผนภูมิที่มีเนื้อหาแล้วสามารถแสดงเป็น [Chart](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/). ตัวอย่างนี้ค้นหา chart ดังกล่าวโดยใช้ทั้งประเภท placeholder และประเภทรูปทรงขณะรันไทม์, เปลี่ยนหัวเรื่องของมัน, และบันทึกไฟล์:

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

Content placeholder ทั่วไปมักมีค่า [PlaceholderType.Object](https://reference.aspose.com/slides/th/python-java/aspose.slides/placeholdertype/#Object). ใน PowerPoint มันทำหน้าที่เป็นตัวเปิดให้กับหลายประเภทของเนื้อหา เช่น แผนภูมิ, ตาราง, ไดอะแกรม, รูปภาพ, และสื่อ หลังจากที่มันถูกเติมแล้ว ให้ตรวจสอบประเภทของรูปทรงจริงเพื่อทราบว่ามีอะไรบ้าง เลเยาต์พิเศษสามารถเปิดเผย [PlaceholderType.Chart](https://reference.aspose.com/slides/th/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/th/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/th/python-java/aspose.slides/placeholdertype/#Media), หรือ [PlaceholderType.Diagram](https://reference.aspose.com/slides/th/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides ไม่ได้แปลง placeholder [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ที่ว่างเป็น [Chart](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/) เพียงแค่เปลี่ยน [Placeholder.getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/placeholder/#getType); ประเภทไม่สามารถเปลี่ยนได้ผ่าน API เพื่อเติม chart หรือพื้นที่เนื้อหาที่ว่างโดยอัตโนมัติ ให้เพิ่มอ็อบเจกต์ที่ต้องการที่พิกัดของ placeholder แล้วลบ placeholder ที่ว่าง ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับ chart:

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

Chart ที่เพิ่มเป็น chart ท้องถิ่นธรรมดา มันครอบคลุมพื้นที่ของ placeholder แต่ไม่ได้สืบทอดจาก placeholder ของเลเอต์ ใช้บทความ [chart management articles](/slides/th/python-java/powerpoint-charts/) ที่แยกไว้เมื่อจำเป็นต้องแทนที่หมวดหมู่, ซีรีส์, หรือข้อมูลเวิร์กบุ๊กของมัน.

## **ตัวอย่างสมบูรณ์: อัปเดตข้อความหรือเนื้อหารูปภาพ**

ตัวอย่างครบวงจรต่อไปนี้เปิดเทมเพลต, ค้นหาสไลด์แรกสำหรับ placeholder ของหัวเรื่องหรือรูปภาพ, ตรวจสอบประเภทของ placeholder และรูปทรง, อัปเดตเนื้อหาที่เหมาะสม, และบันทึกผลลัพธ์ ตัวอย่างตั้งใจหลีกเลี่ยงการสันนิษฐานว่ามีดัชนีรูปทรงหรือการพิจารณา placeholder ทุกอันเป็นประเภทเดียวกัน.

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

**Placeholder ฐานคืออะไร?**

Placeholder ฐานคือรูปทรงที่สอดคล้องบนเลเอาต์หรือมาสเตอร์ซึ่ง placeholder อื่นสืบทอดจากมัน ใช้ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getBasePlaceholder) เพื่อดึงค่า Placeholder ฐาน รูปทรงทั่วไประดับท้องถิ่นจะคืนค่า `None` เนื่องจากไม่ได้อยู่ในโครงสร้างลำดับของ placeholder.

**ฉันสามารถเปลี่ยนหัวเรื่องของสไลด์ทั้งหมดโดยแก้ไข layout placeholder ได้ไหม?**

คุณสามารถเปลี่ยนการจัดรูปแบบที่สืบทอดหรือข้อความ Prompt ผ่านเลเอตได้ แต่เนื้อหาหัวเรื่องที่มีอยู่จะเก็บอยู่ในสไลด์ปกติ เพื่อแทนที่ข้อความหัวเรื่องจริงในพรีเซนเทชันทั้งหมด ให้วนลูปสไลด์และอัปเดต placeholder ของหัวเรื่องแต่ละอัน.

**ฉันจะจัดการ placeholder ของวันที่, หมายเลขสไลด์, ส่วนหัว, และส่วนท้ายอย่างไร?**

ใช้ตัวจัดการส่วนหัวและส่วนท้ายในสไลด์, เลเอต, มาสเตอร์, โน้ต, หรือสรุปที่เหมาะสม ดูที่ [Manage Presentation Header and Footer](/slides/th/python-java/presentation-header-and-footer/) สำหรับตัวอย่างครบถ้วน.