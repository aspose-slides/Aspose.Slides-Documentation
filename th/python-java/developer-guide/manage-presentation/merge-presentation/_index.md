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
description: "เรียนรู้วิธีผสานการนำเสนอ PowerPoint และ OpenDocument ใน Python ผ่าน Java ด้วยการโคลนสไลด์ การควบคุมมาสเตอร์และเลเอาท์ การปรับขนาดเนื้อหาสไลด์ การรักษาเซคชัน และการจัดการไฟล์ที่มีการป้องกันหรือขนาดใหญ่"
---
## **Overview**

Aspose.Slides for Python via Java ผสานการนำเสนอโดยการโคลนสไลด์จากหนึ่ง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ไปยังอีกอันหนึ่ง การดำเนินการหลักคือ [SlideCollection.addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) ซึ่งสามารถรักษาการจัดรูปแบบของสไลด์ต้นทางหรือแนบสไลด์ที่โคลนไว้ไปยังมาสเตอร์หรือเลเอาท์ในการนำเสนอปลายทางได้

บทความนี้ครอบคลุมเวิร์กโฟลว์การผสานที่พบบ่อยที่สุด:

- ผสานสไลด์ทั้งหมดพร้อมรักษาการจัดรูปแบบของต้นทาง
- ผสานสไลด์ที่เลือกเท่านั้น
- ใช้มาสเตอร์จากการนำเสนอปลายทาง
- ใช้เลเอาท์เฉพาะจากการนำเสนอปลายทาง
- ปรับขนาดสไลด์ให้เท่ากันก่อนการผสาน
- เพิ่มสไลด์ที่โคลนเข้าไปในเซคชัน
- ผสานการนำเสนอหลายไฟล์ในเวิร์กโฟลว์แบบครบวงจร
- จัดการมาสเตอร์, ทรัพยากร, โน้ต, ความคิดเห็น, สื่อ, ฟอนต์, รหัสผ่าน, ไฟล์ขนาดใหญ่, และประเด็นการทำงานหลายเธรด

## **How Slide Cloning Affects Masters and Layouts**

สไลด์สืบทอดรูปลักษณ์ส่วนใหญ่จากเลเอาท์และมาสเตอร์ ดังนั้นการเลือกอับโหลดของการโคลนจะกำหนดวิธีที่สไลด์ที่ผสานเข้ากับการนำเสนอปลายทาง

ใช้ [SlideCollection.addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) อย่างใดอย่างหนึ่งต่อไปนี้:

- `addClone(source_slide)` — รักษาเลเอาท์และการจัดรูปแบบของสไลด์ต้นทาง เมื่อจำเป็น มาสเตอร์ต้นทางจะถูกโคลนเข้าสู่การนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะติดตามมาสเตอร์ที่โคลนโดยอัตโนมัติเพื่อไม่ให้สไลด์ที่ใช้มาสเตอร์เดียวกันถูกโคลนซ้ำหลายครั้ง
- `addClone(source_slide, destination_master, allow_clone_missing_layout)` — แนบสไลด์ที่โคลนไปยัง [MasterSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/) ปลายทางที่กำหนด Aspose.Slides จะค้นหาเลเอาท์ที่ตรงกันภายใต้มาสเตอร์นั้นโดยประเภทหรือชื่อของเลเอาท์
- `addClone(source_slide, destination_layout)` — แนบสไลด์ที่โคลนโดยตรงไปยัง [LayoutSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/) ปลายทางที่กำหนด

มาสเตอร์หรือเลเอาท์ที่ส่งให้กับอับโหลด `addClone` ต้องเป็นของ **การนำเสนอปลายทาง** ไม่ใช่ของการนำเสนอต้นทาง

## **Merge Entire Presentations and Preserve Source Formatting**

การผสานที่ง่ายที่สุดคือคัดลอกสไลด์ทุกสไลด์จากการนำเสนอต้นทางไปยังการนำเสนอปลายทาง วิธีนี้เหมาะเมื่อสไลด์ที่นำเข้าต้องรักษาธีม, มาสเตอร์, และความสัมพันธ์ของเลเอาท์เดิมไว้

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

ผลลัพธ์อาจมีมาสเตอร์หลายชุดเมื่อต้นทางและปลายทางใช้ดีไซน์ที่แตกต่างกัน ซึ่งเป็นพฤติกรรมที่คาดไว้เมื่อรักษาการจัดรูปแบบของต้นทางอย่างตั้งใจ

## **Merge Selected Slides**

คุณไม่จำเป็นต้องโคลนทุกสไลด์ ตัวอย่างต่อไปนี้นำเข้าเฉพาะสไลด์ที่เลือกจากการนำเสนอต้นทาง

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

ตรวจสอบดัชนีสไลด์ก่อนการโคลนเมื่อดัชนีมาจากการป้อนข้อมูลของผู้ใช้หรือการกำหนดค่าภายนอก

## **Merge Slides Using a Destination Master**

ใช้การอับโหลดของ [SlideCollection.addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) เมื่อสไลด์ที่นำเข้าควรทำตามมาสเตอร์ที่มีอยู่แล้วในการนำเสนอปลายทาง

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

Aspose.Slides จะเลือกเลเอาท์ที่เหมาะสมภายใต้มาสเตอร์ที่ระบุโดยการแมพประเภทหรือชื่อของเลเอาท์ต้นทาง หากไม่มีเลเอาท์ที่เหมาะสมและ `allow_clone_missing_layout` มีค่าเป็น `True` เลเอาท์ต้นทางจะถูกโคลนเพื่อให้สไลด์สามารถเพิ่มได้ หากเป็น `False` จะเกิด [PptxEditException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxeditexception/) ขึ้น

ใช้ค่า `False` เมื่อคุณต้องการให้การผสานล้มเหลวแทนที่จะเพิ่มเลเอาท์ใหม่เข้าไปในมาสเตอร์ปลายทาง

## **Merge Slides Using a Specific Destination Layout**

ใช้การอับโหลดของ [SlideCollection.addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) เมื่อคุณทราบเลเอาท์ปลายทางที่สไลด์ที่นำเข้าควรใช้อย่างชัดเจน

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

การใช้เลเอาท์ปลายทางจะเปลี่ยนความสัมพันธ์ของเลเอาท์ที่สืบทอด; ไม่ได้ออกแบบเนื้อหาของสไลด์ต้นทางใหม่ หากเลเอาท์ต้นทางและปลายทางมีโครงสร้าง placeholder ที่แตกต่างกัน ให้ตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบและพฤติกรรมของ placeholder ที่สืบทอดนั้นเหมาะสม

## **Merge Presentations with Different Slide Sizes**

การนำเสนอที่มีขนาดสไลด์ต่างกันสามารถผสานกันได้ แต่การโคลนสไลด์ลงในการนำเสนอที่มีขนาดสไลด์อื่นไม่ทำให้เนื้อหาออกแบบใหม่โดยอัตโนมัติสำหรับพื้นผิวใหม่ รูปร่างอาจปรากฏเป็นการย้าย, การยืดหรือหดที่ไม่คาดคิด, หรืออยู่นอกพื้นที่สไลด์ที่มองเห็นได้

วิธีปฏิบัติที่ใช้ได้คือปรับขนาดการนำเสนอต้นทางก่อนการโคลน วิธี `SlideSize.setSize` สามารถสเกลเนื้อหาที่มีอยู่ขณะเปลี่ยนขนาดสไลด์ได้ ส่วน `SlideSizeScaleType.EnsureFit` จะสเกลเนื้อหาให้พอดีกับขนาดที่กำหนด

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

การปรับขนาดจะเปลี่ยนวัตถุการนำเสนอต้นทางในหน่วยความจำ หากคุณต้องการให้การนำเสนอต้นทางต้นฉบับคงอยู่โดยไม่เปลี่ยนแปลงสำหรับการดำเนินการอื่น ให้เปิดอินสแตนซ์แยกสำหรับการผสาน

## **Merge Slides into a Presentation Section**

ลูปการโคลนสไลด์พื้นฐานจะไม่สร้างโครงสร้างเซคชันของการนำเสนอต้นทาง หากเซคชันมีความสำคัญในผลลัพธ์ ให้สร้างหรือเลือกเซคชันในการนำเสนอปลายทางและโคลนสไลด์เข้าไปในเซคชันโดยใช้ [SlideCollection.addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) อย่างชัดเจน

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

สไลด์ที่โคลนจะถูกเพิ่มต่อท้ายในเซคชันปลายทางที่ระบุ เพื่อรักษาเซคชันต้นทางหลายเซคชัน ให้เรียกใช้ [Presentation.getSections](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSections) เพื่อวนลูปเซคชัน, ดึงสไลด์ในแต่ละเซคชันด้วย [Section.getSlidesListOfSection](https://reference.aspose.com/slides/th/python-java/aspose.slides/section/#getSlidesListOfSection), สร้างเซคชันใหม่ในปลายทาง, และโคลนสไลด์ที่ได้เข้าไปในเซคชันที่สอดคล้องกัน ดูตัวอย่างการจัดการเซคชันเต็มรูปแบบใน [Manage Slide Sections](/slides/th/python-java/slide-section/) รวมถึงเซคชันว่างและการเปลี่ยนแปลงโครงสร้าง

## **Merge Multiple Presentations Safely**

ตัวอย่างแบบครบวงจรต่อไปนี้ใช้การนำเสนอแรกเป็นปลายทาง, ปรับขนาดสไลด์ของแต่ละแหล่งเพิ่มเติม, เปิดแต่ละแหล่งเฉพาะขณะทำการคัดลอก, และบันทึกไฟล์สุดท้ายเมื่อเสร็จสิ้น

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

นี่เป็นจุดเริ่มต้นที่มีประโยชน์สำหรับการรักษาการจัดรูปแบบของสไลด์ที่นำเข้า หากผลลัพธ์ของคุณต้องใช้ธีมเดียวของปลายทาง ให้เปลี่ยนการเรียก `addClone(slide)` ธรรมดาเป็นอับโหลดมาสเตอร์หรือเลเอาท์ปลายทางที่แสดงไว้ข้างต้น

## **Practical Considerations**

### **Masters, Layouts, and Formatting Fidelity**

การโคลนสไลด์แบบเริ่มต้นสามารถนำมาสเตอร์ต้นทางที่จำเป็นเข้ามาในการนำเสนอปลายทางโดยอัตโนมัติ Aspose.Slides จะเก็บทะเบียนภายในสำหรับมาสเตอร์ที่โคลนโดยอัตโนมัติเพื่อหลีกเลี่ยงการโคลนมาสเตอร์เดียวกันหลายครั้ง มาสเตอร์ที่โคลนด้วยมือไม่ได้รับการติดตามในทะเบียนนั้น ดังนั้นหลีกเลี่ยงการโคลนมาสเตอร์ล่วงหน้าเว้นแต่คุณต้องการควบคุมโครงสร้างมาสเตอร์อย่างชัดเจน

อย่าสมมติว่ามาสเตอร์หรือเลเอาท์สองชุดที่มีชื่อเดียวกันมีลักษณะทางภาพเท่ากัน หากเทมเพลตองค์กรต้องควบคุมรูปลักษณ์สุดท้าย ให้เลือกมาสเตอร์หรือเลเอาท์ปลายทางอย่างชัดเจนและตรวจสอบผลลัพธ์หลังการผสาน

### **Notes and Comments**

โน้ตผู้บรรยายและความคิดเห็นสไลด์ถูกเชื่อมโยงกับเนื้อหาสไลด์และจะถูกคัดลอกเมื่อสไลด์ถูกโคลน Aspose.Slides ยังมี API เฉพาะสำหรับ [presentation notes](/slides/th/python-java/presentation-notes/) และ [presentation comments](/slides/th/python-java/presentation-comments/)

หากการจัดรูปแบบหน้าโน้ตสำคัญ ให้ตรวจสอบการนำเสนอที่ผสานแล้วเพราะโน้ตมาสเตอร์เป็นอ็อบเจ็กต์ระดับการนำเสนอและอาจแตกต่างกันระหว่างไฟล์ต้นทาง สำหรับกระบวนการตรวจสอบ ให้ตรวจสอบผู้เขียนความคิดเห็นและเธรดของความคิดเห็นหลังจากรวมไฟล์จากผู้เขียนหรือเทมเพลตต่างกัน

### **Images, Audio, Video, OLE Objects, and External Links**

สไลด์อาจอ้างอิงทรัพยากรระดับการนำเสนอ เช่น รูปภาพ, ไฟล์เสียงฝัง, วิดีโอฝัง, และข้อมูล OLE ให้โคลนสไลด์ทั้งหมดแทนการคัดลอกเฉพาะรูปร่างที่มองเห็นได้ เพื่อให้ Aspose.Slides รักษาความสัมพันธ์ของสไลด์ต่อทรัพยากรเหล่านั้น

ทรัพยากรที่ฝังและที่ลิงก์ควรจัดการแตกต่างกัน ลิงก์ไฟล์เสียง, วิดีโอ, OLE หรือไฮเปอร์ลิงก์ที่ลิงก์อยู่ยังคงพึ่งพาเป้าหมายภายนอก; การโคลนสไลด์ไม่ทำให้ลิงก์ภายนอกกลายเป็นเนื้อหาฝัง ทดสอบเส้นทางและ URL ของทรัพยากรลิงก์ในสภาพแวดล้อมที่การนำเสนอที่ผสานจะถูกเปิด

Aspose.Slides ติดตามมาสเตอร์ที่โคลนโดยอัตโนมัติ แต่ไม่ควรถือเป็นการรับประกันทั่วไปว่าทรัพยากรไบนารีที่เหมือนกันจากแหล่งต้นทางที่ไม่เกี่ยวข้องจะถูกทำซ้ำอัตโนมัติ หากขนาดไฟล์ผลลัพธ์สำคัญ ให้ตรวจสอบแพ็กเกจที่ผสานและวัดผลลัพธ์แทนการพึ่งพาการทำซ้ำโดยอัตโนมัติ

### **Embedded Fonts and Font Availability**

ฟอนต์จัดการระดับการนำเสนอ หากต้องการให้การพิมพ์แบบเดียวกันบนเครื่องต่าง ๆ อย่าสมมติว่าการโคลนสไลด์อย่างเดียวจะทำให้ฟอนต์ที่จำเป็นทั้งหมดพร้อมใช้งานในสภาพแวดล้อมปลายทาง คุณสามารถตรวจสอบฟอนต์ที่ฝังด้วย [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) และจัดการการฝังฟอนต์อย่างชัดเจนตามที่อธิบายใน [Embed Fonts in Presentations](/slides/th/python-java/embedded-font/)

นอกจากนี้ให้ตรวจสอบว่าคุณได้รับอนุญาตให้ฝังฟอนต์ที่ใช้ในไฟล์ต้นทางหรือไม่ เนื่องจากสัญญาอนุญาตฟอนต์อาจจำกัดการฝัง

### **Password-Protected Presentations**

แหล่งที่มีการป้องกันด้วยรหัสผ่านต้องเปิดสำเร็จก่อนจึงจะโคลนสไลด์ได้ ให้ใส่รหัสผ่านผ่าน [LoadOptions.setPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setPassword)

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

การเปิดไฟล์ที่เข้ารหัสไม่ได้ทำให้การป้องกันเดียวกันถูกนำไปใช้กับการนำเสนอปลายทางโดยอัตโนมัติ ให้กำหนดการป้องกันผลลัพธ์แยกต่างหากเมื่อจำเป็น

### **Large Presentations and Memory Use**

การนำเสนอขนาดใหญ่ที่มีรูปภาพความละเอียดสูง, ไฟล์เสียง, วิดีโอ, หรือวัตถุไบนารีขนาดใหญ่อาจใช้หน่วยความจำมาก [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) ให้ตัวเลือกควบคุมการจัดการ BLOB และการใช้ไฟล์ชั่วคราว ดู [Manage Presentation BLOBs](/slides/th/python-java/manage-blob/) สำหรับกลยุทธ์ไฟล์ขนาดใหญ่

สำหรับไฟล์ใหญ่ ให้โหลดจากเส้นทางไฟล์เมื่อเป็นไปได้, ปล่อยการนำเสนอแหล่งต้นทางโดยเร็วเมื่อนำมาผสานแล้ว, และหลีกเลี่ยงการบันทึกผลลัพธ์ระหว่างขั้นตอนหลายครั้ง เว้นแต่เวิร์กโฟลว์ต้องการจุดตรวจสอบ

### **Thread Safety**

อย่าโหลด, แก้ไข, บันทึก หรือโคลนอินสแตนซ์เดียวของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) พร้อมกันจากหลายเธรด ให้แต่ละอินสแตนซ์ของการนำเสนออยู่ในงานผสานหนึ่งงาน หากคุณทำงานแบบขนานให้ใช้อินสแตนซ์การนำเสนอแยกต่างหากและปฏิบัติตามแนวทาง [Aspose.Slides multithreading guidance](/slides/th/python-java/multithreading/)

## **FAQ**

**How do I keep each source presentation's original design?**

ใช้ [addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) โดยไม่ระบุมาสเตอร์หรือเลเอาท์ปลายทาง Aspose.Slides สามารถโคลนมาสเตอร์ต้นทางโดยอัตโนมัติเมื่อสไลด์ที่นำเข้าต้องการ

**How do I make imported slides use the destination theme?**

ใช้การอับโหลดที่รับมาสเตอร์ปลายทาง ส่งมาสเตอร์จากการนำเสนอปลายทาง ไม่ใช่จากต้นทาง Aspose.Slides จะพยายามแมพสไลด์แต่ละอันไปยังเลเอาท์ที่เหมาะสมภายใต้มาสเตอร์นั้น

**When should I use a specific destination layout instead of a destination master?**

ใช้เลเอาท์เฉพาะเมื่อสไลด์ที่นำเข้าทุกสไลด์ต้องใช้เลเอาท์ที่ทราบล่วงหน้า ใช้มาสเตอร์เมื่อคุณต้องการให้ Aspose.Slides เลือกเลเอาท์จากมาสเตอร์นั้นตามประเภทหรือชื่อของเลเอาท์ต้นทาง

**Can presentations with different slide sizes be merged?**

ได้ แต่เนื้อหาสไลด์จะไม่ถูกออกแบบใหม่อัตโนมัติสำหรับมิติปลายทาง ให้ปรับขนาดการนำเสนอต้นทางก่อนเมื่อจำเป็นต้องการตำแหน่งที่คาดเดาได้ เช่นใช้ [SlideSize.setSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/#setSize) และ [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesizescaletype/)

**Can I merge PPT, PPTX, and ODP presentations into one file?**

ได้ โหลดแต่ละการนำเสนอต้นทาง, โคลนสไลด์ที่ต้องการเข้าสู่ปลายทางหนึ่งไฟล์, แล้วบันทึกปลายทางในฟอร์แมตที่รองรับ เนื่องจากฟอร์แมตการนำเสนออาจไม่มีคุณลักษณะเดียวกันทั้งหมด ให้ตรวจสอบเนื้อหาซับซ้อนหลังการผสานข้ามฟอร์แมต ดู [Supported File Formats](/slides/th/python-java/supported-file-formats/)

**Are source sections preserved automatically?**

ไม่ด้วยลูปพื้นฐานที่โคลนสไลด์เท่านั้น ต้องสร้างเซคชันที่ต้องการในปลายทางและใช้การอับโหลดของ [addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidecollection/#addClone) เมื่อโครงสร้างเซคชันต้องถูกรักษา

**Are speaker notes and comments preserved?**

พวกเขาถูกคัดลอกพร้อมสไลด์ที่โคลน สำหรับเวิร์กโฟลว์ที่พึ่งพาการจัดรูปแบบโน้ตมาสเตอร์, ผู้เขียนความคิดเห็น, หรือข้อมูลการรีวิวแบบเธรด ให้ตรวจสอบผลลัพธ์ที่ผสานเนื่องจากสถานการณ์เหล่านั้นเกี่ยวข้องกับโครงสร้างระดับการนำเสนอเช่นเดียวกับระดับสไลด์

**What happens to audio, video, OLE objects, and hyperlinks?**

เนื้อหาที่ฝังจะถูกพกพาเป็นส่วนหนึ่งของความสัมพันธ์ทรัพยากรของสไลด์ที่โคลน ลิงก์ภายนอกจะคงอยู่เป็นลิงก์ภายนอก ดังนั้นไฟล์หรือ URL ปลายทางต้องยังคงพร้อมใช้หลังการผสาน

**Are embedded fonts from every source guaranteed to be available in the merged presentation?**

อย่าพึ่งพาการโคลนสไลด์เท่านั้นสำหรับการจัดจำหน่ายฟอนต์ ตรวจสอบฟอนต์ที่ฝังในปลายทางและจัดการการฝังฟอนต์หรือความพร้อมของฟอนต์ภายนอกอย่างชัดเจนเมื่อการพิมพ์แบบสำคัญ

**How do I merge a password-protected file?**

เปิดไฟล์ด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setPassword) ที่ถูกต้อง แล้วโคลนสไลด์ตามปกติ การป้องกันผลลัพธ์ต้องกำหนดแยกต่างหาก

**How should I handle very large presentations?**

ใช้การจัดการ BLOB เมื่อวัตถุไบนารีขนาดใหญ่เป็นส่วนใหญ่ของการใช้หน่วยความจำ, เลือกโหลดจากเส้นทางไฟล์สำหรับไฟล์ขนาดใหญ่อย่างเต็มที่, ปล่อยการนำเสนอแหล่งต้นทางโดยเร็วหลังการผสาน, และบันทึกผลลัพธ์สุดท้ายเมื่อจำเป็นเท่านั้น

**Can I merge slides from multiple threads?**

อย่าใช้อินสแตนซ์เดียวของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) พร้อมกันจากหลายเธรด ให้แต่ละงานผสานแยกกันโดยใช้อินสแตนซ์การนำเสนอของตนเอง