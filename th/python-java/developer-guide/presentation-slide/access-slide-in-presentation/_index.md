---
title: เข้าถึงสไลด์งานนำเสนอใน Python
linktitle: เข้าถึงสไลด์
type: docs
weight: 20
url: /th/python-java/access-slide-in-presentation/
keywords:
- เข้าถึงสไลด์
- ดัชนีสไลด์
- ไอดีสไลด์
- ตำแหน่งสไลด์
- เปลี่ยนตำแหน่ง
- คุณสมบัติของสไลด์
- หมายเลขสไลด์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการเข้าถึงและจัดการสไลด์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน Java เพิ่มประสิทธิภาพการทำงานด้วยตัวอย่างโค้ด"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเข้าถึงและจัดการสไลด์ในงานนำเสนอโดยใช้ Aspose.Slides จะอธิบายวิธีการดึงสไลด์โดยใช้ดัชนีเริ่มจากศูนย์จากคอลเลกชันสไลด์และวิธีการเข้าถึงสไลด์โดยใช้รหัสที่ไม่ซ้ำกันด้วยเมธอด [getSlideById](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlideById)

คุณจะได้เรียนรู้วิธีการเปลี่ยนตำแหน่งของสไลด์โดยใช้เมธอด [setSlideNumber](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#setSlideNumber) และวิธีการกำหนดหมายเลขสไลด์เริ่มต้นสำหรับการนำเสนอด้วยเมธอด [setFirstSlideNumber](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#setFirstSlideNumber) ตัวอย่างจะแสดงการโหลดการนำเสนอ, การอ้างอิงสไลด์, การอัปเดตลำดับหรือหมายเลขสไลด์, และการบันทึกการนำเสนอที่แก้ไข

## **เข้าถึงสไลด์ด้วยดัชนี**

สไลด์ทั้งหมดในงานนำเสนอจะถูกจัดเรียงตามลำดับตัวเลขโดยอิงจากตำแหน่งสไลด์เริ่มจาก 0 สไลด์แรกสามารถเข้าถึงได้ผ่านดัชนี 0; สไลด์ที่สองผ่านดัชนี 1; ฯลฯ

คลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ที่เป็นตัวแทนไฟล์งานนำเสนอ เปิดเผยสไลด์ทั้งหมดเป็นคอลเลกชัน [SlideCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/) (คอลเลกชันของอ็อบเจกต์ [Slide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/)) โค้ด Python นี้แสดงวิธีเข้าถึงสไลด์ผ่านดัชนีของมัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
presentation = Presentation("demo.pptx")
try:
    # เข้าถึงสไลด์โดยใช้ดัชนีของมัน
    slide = presentation.getSlides().get_Item(0)
finally:
    presentation.dispose()
```

## **เข้าถึงสไลด์ด้วย ID**

แต่ละสไลด์ในงานนำเสนอมีรหัสที่ไม่ซ้ำกันเชื่อมโยงกับมัน คุณสามารถใช้เมธอด [getSlideById](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlideById) (ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)) เพื่อระบุรหัสนั้น โค้ด Python นี้แสดงวิธีใส่รหัสสไลด์ที่ถูกต้องและเข้าถึงสไลด์ผ่านเมธอด [getSlideById](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlideById):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
presentation = Presentation("demo.pptx")
try:
    # ดึงไอดีสไลด์
    slide_id = presentation.getSlides().get_Item(0).getSlideId()

    # เข้าถึงสไลด์ผ่านไอดีของมัน
    slide = presentation.getSlideById(slide_id)
finally:
    presentation.dispose()
```

## **เปลี่ยนตำแหน่งสไลด์**

Aspose.Slides ให้คุณเปลี่ยนตำแหน่งของสไลด์ ตัวอย่างเช่น คุณสามารถกำหนดให้สไลด์แรกกลายเป็นสไลด์ที่สอง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ (ที่ตำแหน่งที่คุณต้องการเปลี่ยน) ผ่านดัชนีของมัน  
3. กำหนดตำแหน่งใหม่ให้สไลด์ผ่านเมธอด [setSlideNumber](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#setSlideNumber)  
4. บันทึกงานนำเสนอที่แก้ไข  

โค้ด Python นี้แสดงการดำเนินการที่สไลด์ในตำแหน่ง 1 ถูกย้ายไปยังตำแหน่ง 2:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
presentation = Presentation("Presentation.pptx")
try:
    # ดึงสไลด์ที่ตำแหน่งจะถูกเปลี่ยน.
    slide = presentation.getSlides().get_Item(0)

    # กำหนดตำแหน่งใหม่ให้สไลด์.
    slide.setSlideNumber(2)

    # บันทึกงานนำเสนอที่แก้ไข.
    presentation.save("helloworld_Pos.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สไลด์แรกกลายเป็นสไลด์ที่สอง; สไลด์ที่สองกลายเป็นสไลด์แรก เมื่อคุณเปลี่ยนตำแหน่งของสไลด์ สไลด์อื่นๆ จะถูกปรับอัตโนมัติ

## **กำหนดหมายเลขสไลด์**

โดยใช้เมธอด [setFirstSlideNumber](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#setFirstSlideNumber) (ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)) คุณสามารถกำหนดหมายเลขใหม่ให้กับสไลด์แรกในงานนำเสนอ การดำเนินการนี้จะทำให้หมายเลขสไลด์อื่นๆ ถูกคำนวณใหม่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. รับหมายเลขสไลด์  
3. ตั้งหมายเลขสไลด์  
4. บันทึกงานนำเสนอที่แก้ไข  

โค้ด Python นี้แสดงการดำเนินการที่ตั้งหมายเลขสไลด์แรกเป็น 10:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
presentation = Presentation("HelloWorld.pptx")
try:
    # ดึงหมายเลขสไลด์.
    first_slide_number = presentation.getFirstSlideNumber()

    # กำหนดหมายเลขสไลด์.
    presentation.setFirstSlideNumber(10)

    # บันทึกงานนำเสนอที่แก้ไข.
    presentation.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

หากคุณต้องการข้ามสไลด์แรก คุณสามารถเริ่มนับหมายเลขจากสไลด์ที่สอง (และซ่อนการแสดงหมายเลขสำหรับสไลด์แรก) ดังนี้:

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    # กำหนดหมายเลขสำหรับสไลด์แรกของงานนำเสนอ.
    presentation.setFirstSlideNumber(0)

    # แสดงหมายเลขสไลด์สำหรับทุกสไลด์.
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(True)

    # ซ่อนหมายเลขสไลด์สำหรับสไลด์แรก.
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(False)

    # บันทึกงานนำเสนอที่แก้ไข.
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**หมายเลขสไลด์ที่ผู้ใช้เห็นตรงกับดัชนีเริ่มจากศูนย์ของคอลเลกชันหรือไม่?**

หมายเลขที่แสดงบนสไลด์สามารถเริ่มจากค่าใดค่าหนึ่ง (เช่น 10) และไม่จำเป็นต้องตรงกับดัชนี ความสัมพันธ์นี้ควบคุมโดยการตั้งค่า [first slide number](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#setFirstSlideNumber) ของงานนำเสนอ

**สไลด์ที่ถูกซ่อนมีผลต่อการจัดดัชนีหรือไม่?**

ใช่ สไลด์ที่ถูกซ่อนยังคงอยู่ในคอลเลกชันและนับในกระบวนการจัดดัชนี; “hidden” หมายถึงการแสดงผล ไม่ได้หมายถึงตำแหน่งในคอลเลกชัน

**ดัชนีของสไลด์จะเปลี่ยนเมื่อมีการเพิ่มหรือเอาสไลด์อื่นออกหรือไม่?**

ใช่ ดัชนีจะสะท้อนลำดับปัจจุบันของสไลด์เสมอและจะคำนวณใหม่เมื่อตัวดำเนินการแทรก, ลบ หรือย้ายเกิดขึ้น