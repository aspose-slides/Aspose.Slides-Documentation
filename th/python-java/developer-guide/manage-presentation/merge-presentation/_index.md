---
title: ผสานการนำเสนออย่างมีประสิทธิภาพใน Python ผ่าน Java
linktitle: ผสานการนำเสนอ
type: docs
weight: 40
url: /th/python-java/merge-presentation/
keywords:
- ผสาน PowerPoint
- ผสานการนำเสนอ
- ผสานสไลด์
- ผสาน PPT
- ผสาน PPTX
- ผสาน ODP
- รวม PowerPoint
- รวมการนำเสนอ
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีผสานการนำเสนอ PowerPoint และ OpenDocument ใน Python ผ่าน Java โดยการคัดลอกสไลด์, ควบคุม master และ layout, ปรับขนาดเนื้อหาสไลด์, คงส่วน, และจัดการไฟล์ที่ถูกป้องกันหรือขนาดใหญ่."
---
## **ภาพรวม**

Aspose.Slides for Python via Java ผสานการนำเสนอโดยการคัดลอกสไลด์จากหนึ่ง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ไปยังอีกหนึ่ง การทำงานหลักคือ [SlideCollection.addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) ซึ่งสามารถคงรูปแบบของสไลด์ต้นฉบับหรือเชื่อมสไลด์ที่คัดลอกกับ master หรือ layout ในการนำเสนอปลายทางได้

บทความนี้ครอบคลุมเวิร์กโฟลว์การผสานที่พบมากที่สุด:

- ผสานสไลด์ทั้งหมดพร้อมคงรูปแบบต้นฉบับของสไลด์  
- ผสานสไลด์ที่เลือก  
- ใช้ master จากการนำเสนอปลายทาง  
- ใช้ layout เฉพาะจากการนำเสนอปลายทาง  
- ทำให้ขนาดสไลด์ที่ต่างกันเป็นมาตรฐานก่อนผสาน  
- เพิ่มสไลด์ที่คัดลอกไปยังส่วน  
- ผสานการนำเสนอหลายไฟล์ในเวิร์กโฟลว์แบบครบวงจรหนึ่งขั้นตอน  
- จัดการกับ master, resource, notes, comments, media, fonts, passwords, ไฟล์ขนาดใหญ่, และข้อกังวลเกี่ยวกับการทำงานหลายเธรด  

## **การคัดลอกสไลด์ส่งผลต่อ Master และ Layout อย่างไร**

สไลด์สืบทอดลักษณะส่วนใหญ่จาก layout และ master ของมัน ด้วยเหตุนี้ overload ที่คุณเลือกในการคัดลอกจะกำหนดว่าการผสานสไลด์จะถูกบรรจุในการนำเสนอปลายทางอย่างไร  

ใช้ [SlideCollection.addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) อย่างใดอย่างหนึ่งต่อไปนี้:

- `addClone(source_slide)` — คง layout และ formatting ของสไลด์ต้นฉบับ หากจำเป็น master ของต้นฉบับจะถูกคัดลอกไปยังการนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะติดตาม master ที่คัดลอกโดยอัตโนมัติเพื่อไม่ให้สไลด์ที่ใช้ master เดียวกันถูกคัดลอกหลายครั้ง  
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — เชื่อมสไลด์ที่คัดลอกกับ [MasterSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/) เฉพาะในปลายทาง Aspose.Slides จะค้นหา layout ที่ตรงกันภายใต้ master นั้นตามประเภทหรือชื่อของ layout  
- `addClone(source_slide, destination_layout)` — เชื่อมสไลด์ที่คัดลอกโดยตรงกับ [LayoutSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/) เฉพาะในปลายทาง  

master หรือ layout ที่ส่งให้ overload `addClone` ต้องเป็นของการนำเสนอ **ปลายทาง** ไม่ใช่ของการนำเสนอต้นฉบับ  

## **ผสานการนำเสนอทั้งหมดและคงรูปแบบต้นฉบับ**

การผสานที่ง่ายที่สุดคือคัดลอกสไลด์ทุกสไลด์จากการนำเสนอต้นฉบับไปยังการนำเสนอปลายทาง นี่คือทางเลือกที่เหมาะสมเมื่อสไลด์ที่นำเข้าต้องรักษา theme, master และความสัมพันธ์ของ layout ดั้งเดิมไว้  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

การนำเสนอที่ได้อาจมีหลาย master หากต้นฉบับและปลายทางใช้ดีไซน์ที่ต่างกัน สิ่งนี้คาดหวังได้เมื่อต้องคงรูปแบบต้นฉบับไว้  

## **ผสานสไลด์ที่เลือก**

คุณไม่จำเป็นต้องคัดลอกสไลด์ทุกสไลด์ ตัวอย่างต่อไปนี้นำเข้าเฉพาะดัชนีสไลด์ที่เลือกจากการนำเสนอต้นฉบับ  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        slide_indexes = [0, 2, 4]
        for index in slide_indexes:
            if 0 <= index < source.getSlides().size():
                destination.getSlides().addClone(source.getSlides().get_Item(index))
            else:
                print(f"Skipping invalid slide index: {index}")
    finally:
        source.dispose()

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

ตรวจสอบดัชนีสไลด์ก่อนคัดลอกเมื่อดัชนีมาจากการป้อนข้อมูลของผู้ใช้หรือจากการกำหนดค่าภายนอก  

## **ผสานสไลด์โดยใช้ Master ของปลายทาง**

ใช้ overload ของ [SlideCollection.addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) เมื่อสไลด์ที่นำเข้าควรใช้ master ที่มีอยู่แล้วในการนำเสนอปลายทาง  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_master = destination.getMasters().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_master, True)
    finally:
        source.dispose()

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

Aspose.Slides จะเลือก layout ที่เหมาะสมภายใต้ master ที่ระบุโดยการจับคู่ประเภทหรือชื่อของ layout ต้นฉบับ หากไม่มี layout ที่เหมาะสมและ `allow_clone_missing_layout` เป็น `True` layout ของต้นฉบับจะถูกคัดลอกเพื่อให้สไลด์สามารถเพิ่มได้ หากเป็น `False` จะเกิด [PptxEditException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxeditexception/)  

ใช้ `False` เมื่อคุณต้องการให้การผสานล้มเหลวแทนที่จะเพิ่ม layout เพิ่มเติมใน master ของปลายทาง  

## **ผสานสไลด์โดยใช้ Layout เฉพาะของปลายทาง**

ใช้ overload ของ [SlideCollection.addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) เมื่อคุณทราบชัดเจนว่า layout ของปลายทางที่สไลด์ที่นำเข้าควรใช้  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        destination_layout = destination.getLayoutSlides().get_Item(0)
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, destination_layout)
    finally:
        source.dispose()

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

การใช้ layout ของปลายทางจะเปลี่ยนความสัมพันธ์ของ layout ที่สืบทอด แต่มิได้ออกแบบเนื้อหาสไลด์ต้นฉบับใหม่ หาก layout ของต้นฉบับและปลายทางมีโครงสร้าง placeholder ต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าการฟอร์แมตและพฤติกรรมของ placeholder ยังเหมาะสม  

## **ผสานการนำเสนอที่มีขนาดสไลด์ต่างกัน**

การนำเสนอที่มีมิติสไลด์ต่างกันสามารถผสานได้ แต่การคัดลอกสไลด์เข้าการนำเสนอที่มีขนาดสไลด์ต่างกันจะไม่ออกแบบเนื้อหาใหม่โดยอัตโนมัติเพื่อให้พอดีกับผ้าใบใหม่ ทำให้รูปทรงอาจเลื่อน, ย่อ/ขยายไม่คาดคิด หรืออยู่นอกพื้นที่สไลด์ที่มองเห็น  

วิธีการที่ practical คือปรับขนาดการนำเสนอต้นฉบับก่อนคัดลอก เมธอด [SlideSize.setSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/#setSize) สามารถสเกลเนื้อหาที่มีอยู่พร้อมเปลี่ยนมิติสไลด์ได้ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesizescaletype/) จะสเกลเนื้อหาให้พอดีกับขนาดที่ต้องการ  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        source_size = source.getSlideSize().getSize()
        destination_size = destination.getSlideSize().getSize()
        width = jpype.JFloat(destination_size.getWidth())
        height = jpype.JFloat(destination_size.getHeight())
        if source_size.getWidth() != width or source_size.getHeight() != height:
            source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

        for slide in source.getSlides():
            destination.getSlides().addClone(slide)
    finally:
        source.dispose()

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

การปรับขนาดจะเปลี่ยนวัตถุการนำเสนอต้นฉบับในหน่วยความจำ หากคุณต้องการให้การนำเสนอต้นฉบับต้นฉบับคงอยู่โดยไม่เปลี่ยนแปลงสำหรับการดำเนินการอื่น ให้เปิดอินสแตนซ์แยกสำหรับการผสาน  

## **ผสานสไลด์เข้าส่วนของการนำเสนอ**

ลูปคัดลอกสไลด์พื้นฐานไม่ได้สร้างลำดับชั้นของ section ของการนำเสนอต้นฉบับ หาก section มีความสำคัญในผลลัพธ์ ให้สร้างหรือเลือก section ในการนำเสนอปลายทางและคัดลอกสไลด์ไปยัง section นั้นโดยใช้ [SlideCollection.addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) อย่างชัดเจน  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

destination = Presentation("destination.pptx")
try:
    source = Presentation("source.pptx")
    try:
        imported_section = destination.getSections().appendEmptySection("Imported slides")
        for slide in source.getSlides():
            destination.getSlides().addClone(slide, imported_section)
    finally:
        source.dispose()

    destination.save("merged-with-section.pptx", SaveFormat.Pptx)
finally:
    destination.dispose()
```

สไลด์ที่คัดลอกจะถูกผนวกต่อท้าย section ของปลายทางที่ระบุ เพื่อคงหลาย section ของต้นฉบับ ให้เรียก [Presentation.getSections](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSections) , ดึงสไลด์ปัจจุบันของแต่ละ section ด้วย [Section.getSlidesListOfSection](https://reference.aspose.com/slides/th/python-java/aspose.slides/section/#getSlidesListOfSection) , สร้าง section ในปลายทางใหม่ แล้วคัดลอกสไลด์ที่คืนค่ามาเข้าสู่ section ที่สอดคล้องกัน ดูตัวอย่างการนับจำนวน section อย่างครบถ้วนใน [Manage Slide Sections](/slides/th/python-java/slide-section/) ซึ่งรวมถึง section ที่ว่างและการเปลี่ยนแปลงโครงสร้าง  

## **ผสานหลายการนำเสนออย่างปลอดภัย**

ตัวอย่าง end-to-end ด้านล่างใช้การนำเสนอแรกเป็นปลายทาง ทำให้ขนาดสไลด์ของแต่ละแหล่งเพิ่มเติมเป็นมาตรฐาน เปิดแหล่งแต่ละอันเฉพาะเมื่อทำการคัดลอกและบันทึกไฟล์สุดท้ายเพียงครั้งเดียว  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

merged = Presentation(input_files[0])
try:
    merged_size = merged.getSlideSize().getSize()
    width = jpype.JFloat(merged_size.getWidth())
    height = jpype.JFloat(merged_size.getHeight())

    for input_file in input_files[1:]:
        source = Presentation(input_file)
        try:
            source_size = source.getSlideSize().getSize()
            if source_size.getWidth() != width or source_size.getHeight() != height:
                source.getSlideSize().setSize(width, height, SlideSizeScaleType.EnsureFit)

            for slide in source.getSlides():
                merged.getSlides().addClone(slide)
        finally:
            source.dispose()

    merged.save("merged.pptx", SaveFormat.Pptx)
finally:
    merged.dispose()
```

นี่เป็น baseline ที่มีประโยชน์สำหรับการคงรูปแบบของสไลด์ที่นำเข้า หากผลลัพธ์ของคุณต้องใช้ theme ของปลายทางเดียวให้แทนที่การเรียก `addClone(slide)` อย่างง่ายด้วย overload ของ destination‑master หรือ destination‑layout ที่ได้แสดงไว้ก่อนหน้า  

## **ข้อควรพิจารณาเชิงปฏิบัติ**

### **Masters, Layouts, and Formatting Fidelity**

การคัดลอกสไลด์โดยค่าเริ่มต้นสามารถนำ master ที่ต้องการจากต้นฉบับเข้าสู่การนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะเก็บทะเบียนภายในสำหรับ master ที่คัดลอกโดยอัตโนมัติเพื่อหลีกเลี่ยงการคัดลอก master เดียวกันหลายครั้ง master ที่คัดลอกด้วยตนเองจะไม่ได้รับการติดตามในทะเบียนนั้น ดังนั้นหลีกเลี่ยงการคัดลอก master ล่วงหน้าหากไม่จำเป็นต้องควบคุมโครงสร้าง master อย่างชัดเจน  

อย่าเชื่อว่ามี master หรือ layout สองตัวที่มีชื่อเดียวกันจะเป็นภาพเหมือนกัน หากเทมเพลตองค์กรต้องควบคุมรูปลักษณ์สุดท้าย ให้เลือก master หรือ layout ของปลายทางอย่างเจาะจงและตรวจสอบผลลัพธ์หลังการผสาน  

### **Notes and Comments**

บันทึกของผู้พูดและคอมเมนต์ของสไลด์จะเชื่อมกับเนื้อหาสไลด์และจะถูกคัดลอกเมื่อสไลด์ถูกคัดลอก Aspose.Slides ยังมี API เฉพาะสำหรับ [presentation notes](/slides/th/python-java/presentation-notes/) และ [presentation comments](/slides/th/python-java/presentation-comments/)  

หากการจัดรูปแบบของหน้า notes มีความสำคัญ ให้ตรวจสอบการนำเสนอที่ผสานแล้วเนื่องจาก notes master เป็นออบเจ็กต์ระดับการนำเสนอและอาจแตกต่างกันระหว่างไฟล์ต้นฉบับ สำหรับกระบวนการตรวจสอบ ให้ตรวจสอบผู้เขียนคอมเมนต์และ threaded comments หลังการรวมไฟล์จากผู้เขียนหรือเทมเพลตที่ต่างกัน  

### **Images, Audio, Video, OLE Objects, and External Links**

สไลด์อาจอ้างอิงทรัพยากรระดับการนำเสนอเช่นรูปภาพ, audio ฝัง, video ฝัง, และข้อมูล OLE ให้คัดลอกสไลด์เองแทนการคัดลอกเฉพาะรูปทรงที่มองเห็น เพื่อให้ Aspose.Slides สามารถรักษาความสัมพันธ์ของสไลด์กับทรัพยากรเหล่านั้นได้  

ทรัพยากรที่ฝังและที่ลิงก์ควรจัดการแตกต่างกัน การลิงก์ audio, video, OLE object หรือ hyperlink จะยังคงพึ่งพาเป้าหมายภายนอก; การคัดลอกสไลด์ไม่ทำให้ลิงก์ภายนอกกลายเป็นเนื้อหาฝัง ให้ทดสอบเส้นทางและ URL ของทรัพยากรที่ลิงก์ในสภาพแวดล้อมที่การนำเสนอที่ผสานจะถูกเปิด  

Aspose.Slides ติดตาม master ที่คัดลอกโดยอัตโนมัติโดยชัดเจน แต่ไม่ควรถือว่าเป็นการรับประกันทั่วไปว่าทรัพยากรไบนารีที่เหมือนกันจากการนำเสนอแหล่งที่ไม่เกี่ยวข้องจะถูก deduplicate เสมอ หากขนาดไฟล์ผลลัพธ์สำคัญ ให้ตรวจสอบแพ็กเกจที่ผสานและวัดผลลัพธ์แทนการพึ่งพาการ deduplication แบบโดยอัตโนมัติ  

### **Embedded Fonts and Font Availability**

ฟอนต์จัดการระดับการนำเสนอ หากต้องการให้การพิมพ์แบบไดอะแกรมคงที่ข้ามเครื่อง ไม่ควรสันนิษฐานว่าการคัดลอกสไลด์อย่างเดียวรับประกันว่าฟอนต์ที่ต้องการทั้งหมดจะมีในสภาพแวดล้อมปลายทาง คุณสามารถตรวจสอบฟอนต์ที่ฝังด้วย [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) และจัดการการฝังอย่างชัดเจนตามที่อธิบายใน [Embed Fonts in Presentations](/slides/th/python-java/embedded-font/)  

เช่นนั้น ตรวจสอบว่าคุณได้รับอนุญาตให้ฝังฟอนต์ที่ใช้ในไฟล์ต้นฉบับหรือไม่ เนื่องจากสัญญาอนุญาตฟอนต์อาจจำกัดการฝัง  

### **Password-Protected Presentations**

แหล่งที่มีการป้องกันด้วยรหัสผ่านต้องเปิดสำเร็จก่อนที่สไลด์จะคัดลอกได้ ให้ใส่รหัสผ่านผ่าน [LoadOptions.setPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setPassword)  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setPassword("YOUR_PASSWORD")

source = Presentation("protected.pptx", load_options)
try:
    # ทำงานกับการนำเสนอที่ถอดรหัสแล้ว.
    print(f"Loaded {source.getSlides().size()} slides.")
finally:
    source.dispose()
```

การเปิดแหล่งที่เข้ารหัสไม่ได้ทำให้การป้องกันเดียวกันถูกนำไปใช้กับการนำเสนอปลายทางโดยอัตโนมัติ ให้กำหนดการป้องกันผลลัพธ์แยกต่างหากเมื่อจำเป็น  

### **Large Presentations and Memory Use**

การนำเสนอขนาดใหญ่ที่มีรูปภาพความละเอียดสูง, audio, video หรือวัตถุไบนารีขนาดใหญ่อื่น ๆ สามารถใช้หน่วยความจำมาก [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) มีการควบคุมการจัดการ BLOB และการใช้ไฟล์ชั่วคราว ดู [Manage Presentation BLOBs](/slides/th/python-java/manage-blob/) สำหรับกลยุทธ์ไฟล์ขนาดใหญ่  

สำหรับไฟล์ใหญ่ ควรโหลดจากพาธไฟล์เมื่อเป็นไปได้ ปล่อยการนำเสนอแหล่งโดยเร็วที่สุดหลังจากผสานเสร็จ และหลีกเลี่ยงการบันทึกผลลัพธ์กลางหลายครั้ง เว้นแต่เวิร์กโฟลว์ต้องการจุดตรวจสอบ  

### **Thread Safety**

ไม่ควรโหลด, แก้ไข, บันทึก หรือคัดลอกออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เดียวกันพร้อมกันจากหลายเธรด ให้จำกัดออบเจ็กต์การนำเสนอแต่ละอินสแตนซ์ให้ใช้งานกับการผสานหนึ่งครั้ง หากทำงานแบบขนาน ให้ใช้อินสแตนซ์การนำเสนออิสระและปฏิบัติตามแนวทาง [Aspose.Slides multithreading guidance](/slides/th/python-java/multithreading/)  

## **FAQ**

**ทำอย่างไรจึงจะคงการออกแบบดั้งเดิมของการนำเสนอแต่ละไฟล์?**

ใช้ [addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) โดยไม่ระบุ master หรือ layout ของปลายทาง Aspose.Slides สามารถคัดลอก master ของต้นฉบับโดยอัตโนมัติเมื่อสไลด์ที่นำเข้าต้องการ  

**ทำอย่างไรให้สไลด์ที่นำเข้าใช้ theme ของปลายทาง?**

ใช้ overload ที่รับ master ของปลายทาง ให้ใช้ master จากการนำเสนอปลายทาง ไม่ใช่จากต้นฉบับ Aspose.Slides จะพยายามแมปสไลด์ต้นฉบับกับ layout ที่เหมาะสมภายใต้ master นั้น  

**ควรใช้ layout ของปลายทางเฉพาะเมื่อใด แทนการใช้ master ของปลายทาง?**

ใช้ layout เฉพาะเมื่อทุกสไลด์ที่นำเข้าต้องใช้ layout หนึ่งที่รู้จัก ใช้ master เมื่อคุณต้องการให้ Aspose.Slides เลือก layout จาก master ตามประเภทหรือชื่อของ layout ต้นฉบับ  

**การผสานการนำเสนอที่มีขนาดสไลด์ต่างกันทำได้หรือไม่?**

ทำได้ แต่เนื้อหาสไลด์จะไม่ถูกออกแบบใหม่อัตโนมัติเพื่อให้สอดคล้องกับมิติปลายทาง ให้ปรับขนาดการนำเสนอต้นฉบับก่อน เช่น ใช้ [SlideSize.setSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/#setSize) และ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesizescaletype/)  

**สามารถผสานไฟล์ PPT, PPTX, และ ODP เป็นไฟล์เดียวได้หรือไม่?**

ทำได้ โหลดการนำเสนอแต่ละไฟล์ คัดลอกสไลด์ที่ต้องการไปยังการนำเสนอปลายทางหนึ่ง แล้วบันทึกในรูปแบบที่รองรับ อย่างไรก็ตาม เนื่องจากฟีเจอร์ต่างไฟล์อาจไม่เท่ากัน ควรตรวจสอบเนื้อหาซับซ้อนหลังการผสานข้ามรูปแบบ ดู [Supported File Formats](/slides/th/python-java/supported-file-formats/)  

**section ของต้นฉบับจะถูกคงไว้โดยอัตโนมัติหรือไม่?**

ไม่ หากใช้ลูปพื้นฐานที่คัดลอกสไลด์เท่านั้น ต้องสร้าง section ที่ต้องการในปลายทางและใช้ overload ของ [addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) เมื่อจำเป็นต้องคงโครงสร้าง section  

**บันทึกพูดและคอมเมนต์จะคงไว้หรือไม่?**

จะถูกคัดลอกพร้อมสไลด์ที่คัดลอก หากกระบวนการขึ้นอยู่กับสไตลิงของ notes‑master, ผู้เขียนคอมเมนต์, หรือข้อมูลการตรวจสอบแบบ threaded ควรตรวจสอบผลลัพธ์ที่ผสานเนื่องจากสถานการณ์เหล่านี้เกี่ยวข้องกับโครงสร้างระดับการนำเสนอและระดับสไลด์  

**เกิดอะไรขึ้นกับ audio, video, OLE objects, และ hyperlinks?**

เนื้อหาที่ฝังจะถูกรวมเป็นส่วนหนึ่งของความสัมพันธ์ทรัพยากรของสไลด์ที่คัดลอก ส่วนลิงก์ภายนอกจะยังคงเป็นลิงก์ภายนอก ดังนั้นไฟล์หรือ URL ที่เป้าหมายต้องยังคงเข้าถึงได้หลังการผสาน  

**ฟอนต์ที่ฝังจากทุกแหล่งจะถูกรับประกันว่ามีในการนำเสนอที่ผสานหรือไม่?**

ห้ามพึ่งพาการคัดลอกสไลด์อย่างเดียวสำหรับการจัดการฟอนต์ ตรวจสอบฟอนต์ที่ฝังในปลายทางและจัดการการฝังฟอนต์หรือความพร้อมใช้งานของฟอนต์ภายนอกอย่างชัดเจนเมื่อการพิมพ์เป็นสิ่งสำคัญ  

**ทำอย่างไรจึงจะผสานไฟล์ที่ป้องกันด้วยรหัสผ่าน?**

เปิดไฟล์ด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setPassword) ที่ถูกต้องแล้วคัดลอกสไลด์ตามปกติ การป้องกันผลลัพธ์ต้องกำหนดแยกต่างหาก  

**ควรจัดการกับการนำเสนอขนาดใหญ่อย่างไร?**

ใช้การจัดการ BLOB เมื่ออ็อบเจ็กต์ไบนารีขนาดใหญ่เป็นหลัก เลือกโหลดจากพาธไฟล์สำหรับไฟล์ขนาดใหญ่ ปล่อยการนำเสนอแหล่งโดยเร็วหลังการผสาน และบันทึกผลลัพธ์สุดท้ายเมื่อจำเป็นเท่านั้น  

**ฉันสามารถคัดลอกสไลด์จากหลายเธรดได้หรือไม่?**

ห้ามใช้ออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เดียวกันพร้อมกันจากหลายเธรด ให้แยกการดำเนินการผสานแต่ละงานออกเป็นอินสแตนซ์การนำเสนอของตนเอง.