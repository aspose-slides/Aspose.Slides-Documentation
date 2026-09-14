---
title: คัดลอกสไลด์การนำเสนอใน Python
linktitle: คัดลอกสไลด์
type: docs
weight: 35
url: /th/python-java/clone-slides/
keywords:
- คัดลอกสไลด์
- คัดลอกสไลด์
- บันทึกสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ทำซ้ำสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides for Python via Java ตามตัวอย่างโค้ดที่ชัดเจนของเราเพื่อสร้าง PPT อัตโนมัติในไม่กี่วินาทีและขจัดงานทำมือ"
---
## **บทนำ**

การโคลนคือกระบวนการทำสำเนาตรงหรือสำเนาที่เหมือนกันของบางสิ่ง Aspose.Slides for Python via Java ยังทำให้สามารถสร้างสำเนาหรือโคลนของสไลด์ใดๆ แล้วแทรกสไลด์ที่โคลนนั้นเข้าสู่การนำเสนอปัจจุบันหรือการนำเสนออื่นที่เปิดอยู่ กระบวนการโคลนสไลด์จะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่เปลี่ยนสไลด์เดิม มีวิธีการโคลนสไลด์หลายวิธีดังต่อไปนี้:

- โคลนที่ส่วนท้ายภายในการนำเสนอ
- โคลนที่ตำแหน่งอื่นภายในการนำเสนอ
- โคลนที่ส่วนท้ายในการนำเสนออื่น
- โคลนที่ตำแหน่งอื่นในการนำเสนออื่น
- โคลนพร้อมกับสไลด์มาสเตอร์ของมันเข้าสู่การนำเสนออื่น

ใน Aspose.Slides for Python via Java คอลเล็กชันสไลด์ (คอลเล็กชันของอ็อบเจกต์ [Slide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/) ) ที่เปิดให้โดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) มีเมธอด [addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) และ [insertClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#insertClone) เพื่อทำการโคลนสไลด์ตามประเภทที่กล่าวข้างต้น

## **โคลนสไลด์ที่ส่วนท้ายของการนำเสนอ**

หากคุณต้องการโคลนสไลด์แล้วใช้มันในไฟล์การนำเสนอเดียวกันที่ส่วนท้ายของสไลด์ที่มีอยู่ ใหใช้เมธอด [addClone] ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation]
2. รับอ็อบเจกต์ [SlideCollection] โดยอ้างอิงคอลเล็กชัน Slides ที่เปิดให้โดยอ็อบเจ็กต์ [Presentation]
3. เรียกเมธอด [addClone] ที่เปิดให้โดยอ็อบเจกต์ [SlideCollection] และส่งสไลด์ที่ต้องการโคลนเป็นพารามิเตอร์ให้เมธอด [addClone]
4. เขียนไฟล์การนำเสนอที่แก้ไขแล้ว

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # คัดลอกสไลด์ที่ต้องการไปยังส่วนท้ายของคอลเลกชันสไลด์ในการนำเสนอเดียวกัน
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # เขียนการนำเสนอที่แก้ไขแล้วลงดิสก์
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **โคลนสไลด์ไปยังตำแหน่งอื่นภายในการนำเสนอ**

หากคุณต้องการโคลนสไลด์แล้วใช้ในไฟล์การนำเสนอเดียวกันแต่ในตำแหน่งที่แตกต่างกัน ให้ใช้เมธอด [insertClone]:

1. สร้างอินสแตนซ์ของคลาส [Presentation]
2. รับการอ้างอิงถึงคอลเล็กชันสไลด์ที่คืนค่าจากเมธอด [getSlides] บนอ็อบเจ็กต์ [Presentation]
3. เรียกเมธอด [insertClone] ที่เปิดให้โดยอ็อบเจกต์ [SlideCollection] และส่งสไลด์ที่ต้องการโคลนพร้อมดัชนีตำแหน่งใหม่เป็นพารามิเตอร์ให้เมธอด [insertClone]
4. เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # รับคอลเลกชันของสไลด์ในการนำเสนอ
    slides = presentation.getSlides()

    # คัดลอกสไลด์ที่ต้องการไปยังตำแหน่งที่ระบุในการนำเสนอเดียวกัน
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # เขียนการนำเสนอที่แก้ไขแล้วลงดิสก์
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **โคลนสไลด์ที่ส่วนท้ายของการนำเสนออื่น**

หากคุณต้องการโคลนสไลด์จากการนำเสนอหนึ่งและใช้ในไฟล์การนำเสนออื่นที่ส่วนท้ายของสไลด์ที่มีอยู่:

1. สร้างอินสแตนซ์ของคลาส [Presentation] ที่บรรจุการนำเสนอที่สไลด์จะถูกโคลนจาก
2. สร้างอินสแตนซ์ของคลาส [Presentation] ที่บรรจุการนำเสนอปลายทางที่สไลด์จะถูกเพิ่มเข้าไป
3. รับอ็อบเจกต์ [SlideCollection] โดยอ้างอิงคอลเล็กชันสไลด์ที่คืนค่าจากเมธอด [getSlides] บนอ็อบเจกต์ [Presentation] ของการนำเสนอปลายทาง
4. เรียกเมธอด [addClone] ที่เปิดให้โดยอ็อบเจกต์ [SlideCollection] และส่งสไลด์จากการนำเสนอแหล่งเป็นพารามิเตอร์ให้เมธอด [addClone]
5. เขียนไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอแหล่ง
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ที่สไลด์จะถูกโคลน)
    destination_presentation = Presentation()
    try:
        # คัดลอกสไลด์ที่ต้องการจากการนำเสนอแหล่งไปยังส่วนท้ายของคอลเลกชันสไลด์ในการนำเสนอปลายทาง
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # เขียนการนำเสนอปลายทางลงดิสก์
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **โคลนสไลด์ไปยังตำแหน่งอื่นในการนำเสนออื่น**

หากคุณต้องการโคลนสไลด์จากการนำเสนอหนึ่งและใช้ในไฟล์การนำเสนออื่นที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation] ที่บรรจุการนำเสนอแหล่งที่สไลด์จะถูกโคลนจาก
2. สร้างอินสแตนซ์ของคลาส [Presentation] ที่บรรจุการนำเสนอที่สไลด์จะถูกเพิ่มเข้าไป
3. รับอ็อบเจกต์ [SlideCollection] โดยอ้างอิงคอลเล็กชัน Slides ที่เปิดให้โดยอ็อบเจกต์ [Presentation] ของการนำเสนอปลายทาง
4. เรียกเมธอด [insertClone] ที่เปิดให้โดยอ็อบเจกต์ [SlideCollection] และส่งสไลด์จากการนำเสนอแหล่งพร้อมตำแหน่งที่ต้องการเป็นพารามิเตอร์ให้เมธอด [insertClone]
5. เขียนไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอแหล่ง
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ที่สไลด์จะถูกโคลน)
    destination_presentation = Presentation()
    try:
        # คัดลอกสไลด์ที่ต้องการจากการนำเสนอแหล่งไปยังตำแหน่งที่ระบุในการนำเสนอปลายทาง
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # เขียนการนำเสนอปลายทางลงดิสก์
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **โคลนสไลด์พร้อมสไลด์มาสเตอร์ไปยังการนำเสนออื่น**

หากคุณต้องการโคลนสไลด์พร้อมมาสเตอร์สไลด์จากการนำเสนอหนึ่งและใช้ในการนำเสนออื่น คุณต้องโคลนมาสเตอร์สไลด์ที่ต้องการจากการนำเสนอแหล่งไปยังการนำเสนอปลายทางก่อน แล้วใช้มาสเตอร์สไลด์ที่โคลนเมื่อโคลนสไลด์ เมธอด [addClone] คาดหวังมาสเตอร์สไลด์จากการนำเสนอปลายทาง ไม่ใช่จากแหล่ง เพื่อโคลนสไลด์พร้อมมาสเตอร์ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation] ที่บรรจุการนำเสนอแหล่งที่สไลด์จะถูกโคลนจาก
2. สร้างอินสแตนซ์ของคลาส [Presentation] ที่บรรจุการนำเสนอปลายทางที่สไลด์จะถูกโคลนไป
3. เข้าถึงสไลด์ที่ต้องการโคลนพร้อมกับสไลด์มาสเตอร์
4. รับอ็อบเจกต์ [MasterSlideCollection] โดยอ้างอิงคอลเล็กชัน Masters ที่เปิดให้โดยอ็อบเจกต์ [Presentation] ของการนำเสนอปลายทาง
5. เรียกเมธอด [addClone] ที่เปิดให้โดยอ็อบเจกต์ [MasterSlideCollection] และส่งมาสเตอร์จากไฟล์ PPTX แหล่งที่ต้องการโคลนเป็นพารามิเตอร์ให้เมธอด [addClone]
6. รับอ็อบเจกต์ [SlideCollection] โดยอ้างอิงคอลเล็กชัน Slides ที่เปิดให้โดยอ็อบเจกต์ [Presentation] ของการนำเสนอปลายทาง
7. เรียกเมธอด [addClone] ที่เปิดให้โดยอ็อบเจกต์ [SlideCollection] และส่งสไลด์จากการนำเสนอแหล่งที่ต้องการโคลนพร้อมมาสเตอร์สไลด์เป็นพารามิเตอร์ให้เมธอด [addClone]
8. เขียนไฟล์การนำเสนอปลายทางที่แก้ไขแล้ว

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอแหล่ง
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # สร้างอินสแตนซ์ของคลาส Presentation สำหรับการนำเสนอปลายทาง (ที่สไลด์จะถูกโคลน)
    destination_presentation = Presentation()
    try:
        # สร้างอินสแตนซ์ของสไลด์จากคอลเลกชันสไลด์ในการนำเสนอแหล่งพร้อมกับ
        # สไลด์มาสเตอร์
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # คัดลอกมาสเตอร์สไลด์ที่ต้องการจากการนำเสนอแหล่งไปยังคอลเลกชันมาสเตอร์ใน
        # การนำเสนอปลายทาง
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # คัดลอกสไลด์ที่ต้องการจากการนำเสนอแหล่งพร้อมมาสเตอร์ที่ต้องการไปยังส่วนท้ายของ
        # คอลเลกชันสไลด์ในการนำเสนอปลายทาง
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # บันทึกการนำเสนอปลายทางลงดิสก์
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **โคลนสไลด์ที่ส่วนท้ายของส่วนที่ระบุ**

หากคุณต้องการโคลนสไลด์แล้วใช้ในไฟล์การนำเสนอเดียวกันแต่ในส่วนที่แตกต่างกัน ให้ใช้เมธอด [**addClone**] ที่เปิดให้โดยคลาส [**SlideCollection**] Aspose.Slides for Python via Java ทำให้สามารถโคลนสไลด์จากส่วนแรกแล้วแทรกสไลด์ที่โคลนนั้นเข้าสู่ส่วนที่สองของการนำเสนอเดียวกัน

โค้ดตัวอย่างต่อไปนี้จะแสดงวิธีโคลนสไลด์และแทรกสไลด์ที่โคลนเข้าไปในส่วนที่ระบุ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # บันทึกการนำเสนอปลายทางลงดิสก์
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตรวจสอบให้ขนาดสไลด์ตรงกัน**

เมื่อทำการโคลนสไลด์ไปยังการนำเสนออื่น ต้องตรวจสอบให้การนำเสนอปลายทางมีขนาดสไลด์เดียวกับแหล่ง หากขนาดสไลด์แตกต่างกัน Aspose.Slides จะไม่ปรับขนาดรูปร่างที่โคลนอัตโนมัติ—พิกัดและมิติเดิมของรูปจะถูกเก็บไว้ ซึ่งอาจทำให้เนื้อหาแสดงเบี่ยงเบนหรือเกินขอบสไลด์

คุณสามารถตั้งค่าขนาดสไลด์ของการนำเสนอปลายทางให้ตรงกับแหล่งก่อนการโคลนมาสเตอร์และสไลด์ได้ดังนี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

ทำเช่นนี้ก่อนการโคลนมาสเตอร์และสไลด์

## **คำถามที่พบบ่อย**

**บันทึกผู้พูดและความคิดเห็นของผู้ตรวจสอบจะถูกโคลนหรือไม่?**

ใช่. หน้าบันทึกและความคิดเห็นของผู้ตรวจสอบจะถูกรวมอยู่ในโคลน หากคุณไม่ต้องการให้ลบออกหลังจากแทรกโดยใช้ลิงก์ [remove them](/slides/th/python-java/presentation-notes/) 

**แผนภูมิและแหล่งข้อมูลของมันถูกจัดการอย่างไร?**

อ็อบเจกต์แผนภูมิ การจัดรูปแบบ และข้อมูลที่ฝังอยู่จะถูกคัดลอก หากแผนภูมิเชื่อมโยงกับแหล่งข้อมูลภายนอก (เช่น เวิร์กบุ๊กที่ฝังด้วย OLE) การเชื่อมโยงนั้นจะยังคงเป็น [OLE object](/slides/th/python-java/manage-ole/) หลังจากย้ายไฟล์ ควรตรวจสอบความพร้อมของข้อมูลและพฤติกรรมการรีเฟรช

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนของโคลนได้หรือไม่?**

ได้. คุณสามารถแทรกโคลนที่ดัชนีสไลด์เฉพาะและวางเข้าใน [section](/slides/th/python-java/slide-section/) ที่เลือก หากส่วนเป้าหมายไม่มีอยู่ ให้สร้างก่อนแล้วค่อยย้ายสไลด์เข้าไป