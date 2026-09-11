---
title: จัดการกราฟิก SmartArt ในงานนำเสนอโดยใช้ Python
linktitle: กราฟิก SmartArt
type: docs
weight: 20
url: /th/python-java/manage-smartart-shape/
keywords:
- วัตถุ SmartArt
- กราฟิก SmartArt
- สไตล์ SmartArt
- สี SmartArt
- สร้าง SmartArt
- เพิ่ม SmartArt
- แก้ไข SmartArt
- เปลี่ยน SmartArt
- เข้าถึง SmartArt
- ประเภทเค้าโครง SmartArt
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "อัตโนมัติกระบวนการสร้าง แก้ไข และออกแบบสไตล์ SmartArt ของ PowerPoint ใน Python ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดสั้น ๆ และแนวทางที่มุ่งเน้นประสิทธิภาพ"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถสร้างและจัดการกราฟิก SmartArt ในงานนำเสนอ PowerPoint ด้วยโปรแกรมได้ บทความนี้อธิบายวิธีการเพิ่มรูปร่าง SmartArt ลงในสไลด์, เข้าถึงรูปร่าง SmartArt ที่มีอยู่, ค้นหา SmartArt ตามประเภทเค้าโครงเฉพาะ, และปรับปรุงลักษณะภาพโดยการเปลี่ยนสไตล์ SmartArt หรือสไตล์สี

ตัวอย่างแสดงวิธีการทำงานกับรูปร่าง SmartArt ผ่านคอลเลกชันรูปร่างของสไลด์งานนำเสนอ, ตรวจสอบว่ารูปร่างเป็น SmartArt หรือไม่ แล้วทำการแก้ไขหรือสอบถามคุณสมบัติต่าง ๆ ของมัน

## **สร้างรูปแบบ SmartArt**

Aspose.Slides for Python via Java provides an API to create SmartArt shapes. To create a SmartArt shape in a slide, please follow the steps below:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. รับสไลด์ตามดัชนีของมัน  
3. [เพิ่มรูปร่าง SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addSmartArt) โดยระบุ [SmartArtLayoutType](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartlayouttype/)  
4. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # ดึงสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่าง SmartArt.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # บันทึกงานนำเสนอ.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![รูปร่าง SmartArt](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**รูป: รูปร่าง SmartArt ที่เพิ่มลงในสไลด์**|

## **เข้าถึงรูปแบบ SmartArt บนสไลด์**

ตัวอย่างต่อไปนี้เข้าถึงรูปร่าง SmartArt บนสไลด์งานนำเสนอ มันวนลูปผ่านรูปร่างทั้งหมดบนสไลด์และตรวจสอบว่ารูปร่างเป็นอินสแตนซ์ของ [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) หรือไม่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # วนลูปผ่านรูปร่างทั้งหมดบนสไลด์แรก.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **เข้าถึงรูปแบบ SmartArt ด้วยประเภทเค้าโครงเฉพาะ**

ตัวอย่างต่อไปนี้เข้าถึงรูปร่าง [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) ที่มีประเภทเค้าโครงเฉพาะ ซึ่งได้จากการเรียก [SmartArt.getLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/#getLayout).

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt  
2. รับสไลด์แรกตามดัชนีของมัน  
3. วนลูปผ่านรูปร่างทั้งหมดบนสไลด์แรก  
4. ตรวจสอบว่ารูปร่างเป็นอินสแตนซ์ของ [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) หรือไม่  
5. ตรวจสอบว่ารูปร่าง SmartArt มีประเภทเค้าโครงที่ระบุหรือไม่และดำเนินการที่ต้องการ  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # วนลูปผ่านรูปร่างทั้งหมดบนสไลด์แรก.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # ตรวจสอบเค้าโครง SmartArt.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **เปลี่ยนสไตล์ของรูปแบบ SmartArt**

ตัวอย่างนี้แสดงวิธีการเปลี่ยนสไตล์ด่วนของรูปร่าง SmartArt.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt  
2. รับสไลด์แรกตามดัชนีของมัน  
3. วนลูปผ่านรูปร่างทั้งหมดบนสไลด์แรก  
4. ตรวจสอบว่ารูปร่างเป็นอินสแตนซ์ของ [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) หรือไม่  
5. ค้นหารูปร่าง SmartArt ที่มีสไตล์ที่ระบุ  
6. กำหนดสไตล์ใหม่ให้กับรูปร่าง SmartArt  
7. บันทึกงานนำเสนอ  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # วนลูปผ่านรูปร่างทั้งหมดบนสไลด์แรก.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # ตรวจสอบและเปลี่ยนสไตล์ SmartArt.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![รูปร่าง SmartArt](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**รูป: รูปร่าง SmartArt ที่เปลี่ยนสไตล์**|

## **เปลี่ยนสไตล์สีของรูปแบบ SmartArt**

ตัวอย่างนี้เข้าถึงรูปร่าง SmartArt ที่มีสไตล์สีเฉพาะและเปลี่ยนสไตล์นั้น.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีรูปร่าง SmartArt  
2. รับสไลด์แรกตามดัชนีของมัน  
3. วนลูปผ่านรูปร่างทั้งหมดบนสไลด์แรก  
4. ตรวจสอบว่ารูปร่างเป็นอินสแตนซ์ของ [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) หรือไม่  
5. ค้นหารูปร่าง SmartArt ที่มีสไตล์สีที่ระบุ  
6. กำหนดสไตล์สีใหม่ให้กับรูปร่าง SmartArt  
7. บันทึกงานนำเสนอ  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # วนลูปผ่านรูปร่างทั้งหมดบนสไลด์แรก.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # ตรวจสอบและเปลี่ยนสไตล์ SmartArt.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![รูปร่าง SmartArt](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**รูป: รูปร่าง SmartArt ที่เปลี่ยนสไตล์สี**|

## **คำถามที่พบบ่อย**

**ฉันสามารถทำให้ SmartArt เคลื่อนไหวเป็นวัตถุเดียวได้หรือไม่?**

ใช่. SmartArt เป็นรูปร่าง ดังนั้นคุณจึงสามารถใช้ [การเคลื่อนไหวมาตรฐาน](/slides/th/python-java/powerpoint-animation/) ผ่าน API การเคลื่อนไหว (การเข้ามา, การออก, การเน้น, เส้นทางการเคลื่อนที่) เหมือนกับรูปร่างอื่น ๆ

**ฉันจะค้นหา SmartArt เฉพาะบนสไลด์ได้อย่างไรหากไม่รู้ ID ภายใน?**

ตั้งค่าและใช้ [alternative text](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#setAlternativeText) จากนั้นค้นหารูปร่างโดยค่าดังกล่าว—นี่เป็นวิธีที่แนะนำเพื่อค้นหารูปร่างเป้าหมาย

**ฉันสามารถจัดกลุ่ม SmartArt กับรูปร่างอื่นได้หรือไม่?**

ใช่. คุณสามารถจัดกลุ่ม SmartArt กับรูปร่างอื่น (รูปภาพ, ตาราง, ฯลฯ) แล้ว [จัดการกลุ่ม](/slides/th/python-java/group/)

**ฉันจะได้ภาพของ SmartArt เฉพาะ (เช่น สำหรับการแสดงตัวอย่างหรือรายงาน) อย่างไร?**

ส่งออกภาพย่อ/ภาพของรูปร่าง; ไลบรารีสามารถ [เรนเดอร์รูปร่างแยกแต่ละออกรูป](/slides/th/python-java/create-shape-thumbnails/) ไปเป็นไฟล์ raster (PNG/JPG/TIFF)

**รูปลักษณ์ของ SmartArt จะถูกเก็บไว้เมื่อแปลงงานนำเสนอทั้งหมดเป็น PDF หรือไม่?**

ใช่. เครื่องยนต์การเรนเดอร์มุ่งเน้นความแม่นยำสูงสำหรับ [การส่งออก PDF](/slides/th/python-java/convert-powerpoint-to-pdf/), พร้อมตัวเลือกคุณภาพและความเข้ากันได้หลายระดับ