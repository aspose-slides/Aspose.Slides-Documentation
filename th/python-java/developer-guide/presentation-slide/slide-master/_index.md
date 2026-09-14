---
title: จัดการสไลด์มาสเตอร์การนำเสนอใน Python via Java
linktitle: สไลด์มาสเตอร์
type: docs
weight: 70
url: /th/python-java/slide-master/
keywords:
- สไลด์มาสเตอร์
- สไลด์มาสเตอร์
- สไลด์มาสเตอร์ PPT
- สไลด์มาสเตอร์หลายอัน
- เปรียบเทียบสไลด์มาสเตอร์
- พื้นหลัง
- ตัวเก็บตำแหน่ง
- คัดลอกสไลด์มาสเตอร์
- สำเนาสไลด์มาสเตอร์
- ทำซ้ำสไลด์มาสเตอร์
- สไลด์มาสเตอร์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการสไลด์มาสเตอร์ใน Aspose.Slides สำหรับ Python via Java: เข้าถึง แก้ไข คัดลอก เปรียบเทียบ และลบสไลด์มาสเตอร์ในงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

**สไลด์มาสเตอร์** กำหนดการตั้งค่าออกแบบที่ใช้ร่วมกันสำหรับกลุ่มสไลด์ สามารถมีรูปทรงทั่วไป โลโก้ พื้นหลัง รูปแบบข้อความ การตั้งค่าธีม และการตั้งค่าฝักท้าย ใน PowerPoint การแก้ไขสไลด์มาสเตอร์เป็นวิธีปกติที่ทำให้การนำเสนอสอดคล้องโดยไม่ต้องทำรูปแบบเดียวกันซ้ำในแต่ละสไลด์  

Aspose.Slides for Python via Java รองรับโมเดลเดียวกัน การนำเสนอสามารถมีสไลด์มาสเตอร์หนึ่งหรือหลายสไลด์ และแต่ละสไลด์มาสเตอร์สามารถมีสไลด์เลย์เอาต์หลายสไลด์ สไลด์ปกติส่วนใหญ่จะไม่อ้างอิงสไลด์มาสเตอร์โดยตรง แต่สไลด์ปกติจะใช้สไลด์เลย์เอาต์ และสไลด์เลย์เอาต์นั้นเป็นส่วนหนึ่งของสไลด์มาสเตอร์  

ลำดับชั้นคือ  

1. **สไลด์มาสเตอร์** – กำหนดการออกแบบและธีมที่ใช้ร่วมกัน  
2. **สไลด์เลย์เอาต์** – กำหนดการจัดวางตัวเก็บตำแหน่งและการจัดรูปแบบระดับเลย์เอาต์  
3. **สไลด์ปกติ** – มีเนื้อหาเสนอจริงและใช้สไลด์เลย์เอาต์หนึ่งสไลด์  

![ลำดับชั้นของสไลด์มาสเตอร์ สไลด์เลย์เอาต์ และสไลด์ปกติ](slide-master_2.jpg)

ใน Aspose.Slides สไลด์มาสเตอร์ถูกแทนด้วยคลาส [MasterSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/) ทั้งหมดของสไลด์มาสเตอร์ในงานนำเสนอสามารถเข้าถึงได้ผ่านคอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getMasters) ซึ่งถูกแทนด้วย [MasterSlideCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslidecollection/)  

{{% alert color="info" title="Inheritance" %}}

เมื่อคุณสมบัติเช่นเดียวกันถูกกำหนดไว้ในหลายระดับ ระดับที่เจาะจงมากกว่าจะชนะ ตัวอย่างเช่น หากสไลด์มาสเตอร์และสไลด์เลย์เอาต์ทั้งสองกำหนดพื้นหลัง สไลด์ที่อิงจากเลย์เอื่อนั้นจะใช้พื้นหลังของเลย์เอาต์ สำหรับข้อมูลเพิ่มเติมเกี่ยวกับสไลด์เลย์เอาต์ ดูที่ [Apply or Change Slide Layouts](/slides/th/python-java/slide-layout/)  

{{% /alert %}}

## **การเข้าถึงสไลด์มาสเตอร์**

ใน PowerPoint คุณสามารถเปิดมุมมองสไลด์มาสเตอร์ได้จาก **View** > **Slide Master**  

![คำสั่ง Slide Master บนแท็บ View ของ PowerPoint](slide-master_3.jpg)

ใน Aspose.Slides ใช้คอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getMasters) เพื่อเข้าถึงสไลด์มาสเตอร์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

คุณยังสามารถดึงสไลด์มาสเตอร์ที่สไลด์ปกติเชื่อมต่ออยู่ผ่านเลย์เอาต์ของมันได้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **สไลด์มาสเตอร์ประกอบด้วยอะไร**

สไลด์มาสเตอร์เป็นออบเจกต์แบบสไลด์ มันสืบทอดจาก [BaseSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/) จึงเปิดเผยคุณสมบัติสไลด์หลายอย่างที่ใช้โดยสไลด์ปกติและเลย์เอาต์ สมาชิกเฉพาะสไลด์มาสเตอร์จะถูกแสดงบนหน้า API ของ [MasterSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/)  

สมาชิกสไลด์มาสเตอร์ที่ใช้บ่อยรวมถึง:

| Member | Purpose |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getBackground) | ตั้งค่าพื้นหลังระดับมาสเตอร์ของสไลด์ |
| [getShapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getShapes) | เก็บรูปทรงที่วางบนมาสเตอร์ เช่น โลโก้ กรอบรูปภาพ และข้อความที่ใช้ร่วมกัน |
| [getLayoutSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/#getLayoutSlides) | เก็บสไลด์เลย์เอาต์ที่เป็นส่วนหนึ่งของมาสเตอร์ |
| [getThemeManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/#getThemeManager) | ให้การเข้าถึง API ธีมของมาสเตอร์ |
| [getHeaderFooterManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | ควบคุมส่วนหัว ส่วนท้าย วันที่ และหมายเลขสไลด์สำหรับมาสเตอร์และเลย์เอาต์ลูกของมัน |
| [getDependingSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/#getDependingSlides) | คืนค่าสไลด์ปกติที่พึ่งพามาสเตอร์ผ่านเลย์เอาต์ของพวกเขา |

## **เพิ่มรูปภาพลงในสไลด์มาสเตอร์**

เมื่อคุณเพิ่มรูปภาพลงในสไลด์มาสเตอร์ รูปภาพนั้นจะปรากฏบนสไลด์ที่ใช้เลย์เอ็ตจากมาสเตอร์นั้น มีประโยชน์สำหรับโลโก้ วอเตอร์มาร์ก แถบตกแต่ง และองค์ประกอบภาพซ้ำอื่น ๆ  

ตัวอย่างต่อไปนี้เพิ่มโลโก้ลงในสไลด์มาสเตอร์แรก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับกรอบรูปภาพ ดูที่ [Picture Frame](/slides/th/python-java/picture-frame/)  

## **ทำงานกับตัวเก็บตำแหน่ง (Placeholder)**

ตัวเก็บตำแหน่งโดยทั่วไปจะถูกกำหนดบนสไลด์เลย์เอาต์ สไลด์มาสเตอร์ให้สไตล์และธีมร่วมที่เลย์เออต์เหล่านั้นสืบทอด ในขณะที่แต่ละเลย์เออต์กำหนดว่าตัวเก็บตำแหน่งใดพร้อมใช้งานและตำแหน่งใด  

ใน PowerPoint คำสั่งตัวเก็บตำแหน่งสามารถใช้ได้ในมุมมองสไลด์มาสเตอร์  

![คำสั่ง Insert Placeholder ในมุมมอง Slide Master ของ PowerPoint](slide-master_5.png)

เพื่อเพิ่มตัวเก็บตำแหน่งใหม่ด้วย Aspose.Slides ให้ทำงานกับสไลด์เลย์เอาต์ที่เป็นส่วนหนึ่งของมาสเตอร์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

คุณยังสามารถจัดรูปแบบรูปทรงตัวเก็บตำแหน่งที่มีอยู่แล้วบนสไลด์มาสเตอร์ ตัวอย่างต่อไปนี้ค้นหาตัวเก็บตำแหน่งหัวเรื่องและใช้การไล่สีเชิงเส้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![หัวเรื่องตัวเก็บตำแหน่งที่จัดรูปแบบแล้วสืบทอดโดยสไลด์ปกติ](slide-master_8.png)

สำหรับตัวเลือกการจัดรูปแบบตัวเก็บตำแหน่งและข้อความ ดูที่ [Set Prompt Text in Placeholder](/slides/th/python-java/manage-placeholder/) และ [Text Formatting](/slides/th/python-java/text-formatting/)  

## **เปลี่ยนพื้นหลังของสไลด์มาสเตอร์**

พื้นหลังมาสเตอร์จะถูกสืบทอดโดยเลย์เอตและสไลด์ที่ไม่ได้แก้ไขพื้นหลังของตนเอง ตัวอย่างต่อไปนี้ตั้งค่าสีพื้นหลังแบบสีทึบสำหรับสไลด์มาสเตอร์แรก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

หัวข้อที่เกี่ยวข้อง ดูที่ [Presentation Background](/slides/th/python-java/presentation-background/) และ [Presentation Theme](/slides/th/python-java/presentation-theme/)  

## **คัดลอกสไลด์มาสเตอร์ไปยังงานนำเสนออื่น**

ใช้ [MasterSlideCollection.addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslidecollection/#addClone) เพื่อคัดลอกสไลด์มาสเตอร์ไปยังงานนำเสนออื่น มาสเตอร์ที่คัดลอกแล้วสามารถใช้โดยเลย์เอตและสไลด์ในงานนำหมายที่ปลายทางได้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

หากต้องการคัดลอกสไลด์ปกติพร้อมมาสเตอร์ของมัน ดูที่ [Clone Slides](/slides/th/python-java/clone-slides/)  

## **เพิ่มสไลด์มาสเตอร์หลายอัน**

งานนำเสนอสามารถมีสไลด์มาสเตอร์หลายอัน ซึ่งมีประโยชน์เมื่อต้องการแบรนด์หรือโครงสร้างหน้าที่แตกต่างกันในแต่ละส่วน  

![คำสั่ง PowerPoint สำหรับแทรกและจัดการสไลด์มาสเตอร์](slide-master_9.jpg)

ตัวอย่างต่อไปนี้คัดลอกมาสเตอร์เริ่มต้น ให้คัดลอกนั้นมีพื้นหลังที่ต่างออกไป สร้างเลย์เอตภายใต้มาสเตอร์ที่คัดลอก และเพิ่มสไลด์ใหม่จากเลย์เอตนั้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เปรียบเทียบสไลด์มาสเตอร์**

สไลด์มาสเตอร์สามารถเปรียบเทียบด้วยเมธอด [equals](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#equals) ที่สืบทอดจาก [BaseSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/) การเปรียบเทียบจะตรวจสอบโครงสร้างและเนื้อหาคงที่ เช่น รูปทรง ข้อความ การจัดรูปแบบ แอนิเมชัน และการตั้งค่าอื่น ๆ ของสไลด์ จะไม่เปรียบเทียบตัวระบุเฉพาะ เช่น ID ของสไลด์ หรือค่าตัวเก็บตำแหน่งที่เปลี่ยนแปลงตามเวลา เช่น วันที่ปัจจุบัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

สำหรับข้อมูลเพิ่มเติม ดูที่ [Compare Presentation Slides](/slides/th/python-java/compare-slides/)  

## **ตั้งค่ามุมมองสไลด์มาสเตอร์เป็นมุมมองเริ่มต้น**

ใช้เมธอด [setLastView](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#setLastView) บน [ViewProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/) เพื่อควบคุมมุมมองที่ PowerPoint เปิดเป็นแรก ตัวอย่างต่อไปนี้เปิดงานนำเสนอในมุมมองสไลด์มาสเตอร์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สำหรับการตั้งค่ามุมมองเพิ่มเติม ดูที่ [Save Presentation](/slides/th/python-java/save-presentation/)  

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้**

งานนำเสนอบางครั้งอาจมีสไลด์มาสเตอร์ที่ไม่มีสไลด์ปกติใดใช้ การลบมาสเตอร์ที่ไม่ได้ใช้สามารถลดขนาดไฟล์และทำให้การดูแลเทมเพลตง่ายขึ้น  

ใช้เมธอด [removeUnused](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslidecollection/#removeUnused) เพื่อลบมาสเตอร์ที่ไม่ได้ใช้จากคอลเลกชัน [Presentation.getMasters](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getMasters):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

คุณยังสามารถใช้เมธอด low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/compress/#removeUnusedMasterSlides) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**สไลด์มาสเตอร์กับสไลด์เลย์เอตต่างกันอย่างไร?**  

สไลด์มาสเตอร์กำหนดการตั้งค่าออกแบบที่ใช้ร่วมกัน เช่น ธีม พื้นหลัง รูปทรงทั่วไป และรูปแบบข้อความ สไลด์เลย์เอตเป็นส่วนหนึ่งของสไลด์มาสเตอร์และกำหนดการจัดวางตัวเก็บตำแหน่งเฉพาะ สไลด์ปกติใช้สไลด์เลย์เอต ดังนั้นจึงสืบทอดจากทั้งเลย์เอตและมาสเตอร์  

**งานนำเสนอหนึ่งสามารถมีสไลด์มาสเตอร์หลายอันได้หรือไม่?**  

ได้ งานนำเสนอสามารถมีสไลด์มาสเตอร์หลายอัน ใช้หลายมาสเตอร์เมื่อส่วนต่าง ๆ ต้องการระบบภาพหรือแบรนด์ที่แตกต่างกัน  

**ควรเพิ่มตัวเก็บตำแหน่งในสไลด์มาสเตอร์หรือสไลด์เลย์เอต?**  

ส่วนใหญ่ควรเพิ่มตัวเก็บตำแหน่งในสไลด์เลย์เอต วางองค์ประกอบภาพและการจัดรูปแบบที่ใช้ร่วมกันบนสไลด์มาสเตอร์ แล้วใส่ตัวเก็บตำแหน่งเนื้อหาบนเลย์เอตที่สไลด์ปกติจะใช้  

**สามารถลบสไลด์มาสเตอร์ที่ยังถูกใช้ได้หรือไม่?**  

ไม่ สามารถลบสไลด์มาสเตอร์ที่มีสไลด์ขึ้นอยู่ได้โดยตรงไม่ได้ ควรย้ายสไลด์เหล่านั้นไปยังเลย์เอตของมาสเตอร์อื่นก่อน หรือใช้วิธีทำความสะอาดมาสเตอร์ที่ไม่ได้ใช้ซึ่งจะลบเฉพาะมาสเตอร์ที่ไม่มีสไลด์พึ่งพา  