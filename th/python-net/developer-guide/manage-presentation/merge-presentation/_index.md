---
title: รวมพรีเซนเทชั่นอย่างมีประสิทธิภาพด้วย Python
linktitle: รวมพรีเซนเทชั่น
type: docs
weight: 40
url: /th/python-net/merge-presentation/
keywords:
- รวม PowerPoint
- รวมพรีเซนเทชั่น
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- ผสาน PowerPoint
- ผสานพรีเซนเทชั่น
- ผสานสไลด์
- ผสาน PPT
- ผสาน PPTX
- ผสาน ODP
- Python
- Aspose.Slides
description: "เรียนรู้วิธีรวมพรีเซนเทชั่น PowerPoint และ OpenDocument ด้วย Python โดยการโคลนสไลด์, ควบคุมมาสเตอร์และเลเอาต์, ปรับขนาดเนื้อหาสไลด์, คงส่วนต่าง ๆ, และจัดการไฟล์ที่ป้องกันหรือขนาดใหญ่."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET รวมพรีเซนเทชั่นด้วยการโคลนสไลด์จาก [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) หนึ่งไปยังอีกพรีเซนเทชั่นหนึ่ง การดำเนินการหลักคือ [SlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_clone/), ซึ่งสามารถรักษาการจัดรูปแบบของสไลด์ต้นฉบับหรือแนบสไลด์ที่โคลนไปยังมาสเตอร์หรือเลเอาต์ในพรีเซนเทชั่นปลายทางได้

บทความนี้ครอบคลุมกระบวนการรวมที่พบบ่อยที่สุด:

- รวมสไลด์ทั้งหมดโดยคงการจัดรูปแบบต้นฉบับไว้
- รวมสไลด์ที่เลือกเท่านั้น
- ใช้มาสเตอร์จากพรีเซนเทชั่นปลายทาง
- ใช้เลเอาต์เฉพาะจากพรีเซนเทชั่นปลายทาง
- ปรับขนาดสไลด์ที่แตกต่างกันให้เท่ากันก่อนทำการรวม
- เพิ่มสไลด์ที่โคลนลงในเซกชัน
- รวมหลายพรีเซนเทชั่นในเวิร์กโฟลว์แบบครบวงจร
- จัดการมาสเตอร์, ทรัพยากร, โน้ต, ความคิดเห็น, สื่อ, ฟอนต์, รหัสผ่าน, ไฟล์ขนาดใหญ่, และประเด็นการทำงานหลายเธรด

## **ผลกระทบของการโคลนสไลด์ต่อมาสเตอร์และเลเอาต์**

สไลด์สืบทอดรูปลักษณ์ส่วนใหญ่จากเลเอาต์และมาสเตอร์ ดังนั้นการเลือกรูปแบบการโคลนที่ใช้จะกำหนดวิธีที่สไลด์ที่รวมจะถูกผนวกเข้ากับพรีเซนเทชั่นปลายทาง

ใช้ [SlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_clone/) อย่างใดอย่างหนึ่งต่อไปนี้:

- `add_clone(source_slide)` — รักษาเลเอาต์และการจัดรูปแบบของสไลด์ต้นฉบับ เมื่อจำเป็น มาสเตอร์ต้นฉบับจะถูกโคลนเข้าสู่พรีเซนเทชั่นปลายทางโดยอัตโนมัติ Aspose.Slides จะติดตามมาสเตอร์ที่โคลนโดยอัตโนมัติเพื่อหลีกเลี่ยงการโคลนมาสเตอร์เดียวกันหลายครั้ง
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — แนบสไลด์ที่โคลนไปยัง [IMasterSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/imasterslide/) ปลายทางที่ระบุ Aspose.Slides จะค้นหาเลเอาต์ที่ตรงกันภายใต้มาสเตอร์นั้นตามประเภทหรือชื่อของเลเอาต์
- `add_clone(source_slide, destination_layout)` — แนบสไลด์ที่โคลนโดยตรงไปยัง [ILayoutSlide](https://reference.aspose.com/slides/th/python-net/aspose.slides/ilayoutslide/) ปลายทางที่ระบุ

มาสเตอร์หรือเลเอาต์ที่ส่งให้กับ overload `add_clone` ต้องเป็นของ **พรีเซนเทชั่นปลายทาง** ไม่ใช่พรีเซนเทชั่นต้นฉบับ

## **รวมพรีเซนเทชั่นทั้งหมดและคงการจัดรูปแบบต้นฉบับ**

การรวมแบบง่ายที่สุดคือคัดลอกสไลด์ทุกสไลด์จากพรีเซนเทชั่นต้นฉบับไปยังพรีเซนเทชั่นปลายทาง วิธีนี้เหมาะเมื่อสไลด์ที่นำเข้าควรคงธีม, มาสเตอร์, และความสัมพันธ์ของเลเอาต์เดิมไว้

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์อาจมีมาสเตอร์หลายตัวเมื่อพรีเซนเทชั่นต้นฉบับและปลายทางใช้ดีไซน์ที่แตกต่างกัน ซึ่งเป็นเรื่องปกติเมื่อต้องการคงการจัดรูปแบบของต้นฉบับ

## **รวมสไลด์ที่เลือก**

คุณไม่จำเป็นต้องโคลนทุกสไลด์ ตัวอย่างต่อไปนี้นำเข้าตำแหน่งสไลด์ที่เลือกจากพรีเซนเทชั่นต้นฉบับเท่านั้น

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

ตรวจสอบตำแหน่งสไลด์ก่อนทำการโคลนเมื่อมาจากการป้อนข้อมูลของผู้ใช้หรือการกำหนดค่าจากภายนอก

## **รวมสไลด์โดยใช้มาสเตอร์ปลายทาง**

ใช้ overload [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_clone/) เมื่อต้องการให้สไลด์ที่นำเข้าตรงตามมาสเตอร์ที่มีอยู่แล้วในพรีเซนเทชั่นปลายทาง

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides จะเลือกเลเอาต์ที่เหมาะสมภายใต้มาสเตอร์ที่ระบุโดยการจับคู่ประเภทหรือชื่อของเลเอาต์ต้นฉบับ หากไม่มีเลเอาต์ที่เหมาะสมและ `allow_clone_missing_layout` เป็น `True` เลเอาต์ต้นฉบับจะถูกโคลนเพื่อให้สไลด์สามารถเพิ่มได้ หากเป็น `False` จะเกิด [PptxEditException](https://reference.aspose.com/slides/th/python-net/aspose.slides/pptxeditexception/) ขึ้น

ใช้ค่า `False` เมื่อคุณต้องการให้การรวมล้มเหลวแทนที่จะเพิ่มเลเอาต์เพิ่มเติมเข้าไปในมาสเตอร์ปลายทาง

## **รวมสไลด์โดยใช้เลเอาต์ปลายทางเฉพาะ**

ใช้ overload [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_clone/) เมื่อคุณทราบแน่ชัดว่าเลเอาต์ปลายทางใดที่สไลด์ที่นำเข้าควรใช้

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

การใช้เลเอาต์ปลายทางจะเปลี่ยนความสัมพันธ์ของเลเอาต์ที่สืบทอด; มันไม่ทำการออกแบบเนื้อหาสไลด์ต้นฉบับใหม่ หากเลเอาต์ต้นฉบับและปลายทางมีโครงสร้าง placeholder ที่ต่างกัน ควรตรวจสอบผลลัพธ์เพื่อยืนยันว่าการจัดรูปแบบและพฤติกรรม placeholder ที่สืบทอดนั้นเหมาะสม

## **รวมพรีเซนเทชั่นที่มีขนาดสไลด์ต่างกัน**

พรีเซนเทชั่นที่มีมิติสไลด์แตกต่างกันสามารถรวมกันได้ แต่การโคลนสไลด์เข้าสู่พรีเซนเทชั่นที่มีขนาดสไลด์อื่นจะไม่ทำการออกแบบเนื้อหาใหม่อัตโนมัติ รูปร่างอาจปรากฏถูกย้าย, ยืดหรือหดโดยไม่คาดคิด, หรืออยู่นอกพื้นที่สไลด์ที่มองเห็นได้

วิธีที่เป็นประโยชน์คือปรับขนาดพรีเซนเทชั่นต้นฉบับก่อนทำการโคลน วิธี [SlideSize.set_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidesize/set_size/) สามารถสเกลเนื้อหาที่มีอยู่พร้อมกับการเปลี่ยนขนาดสไลด์ได้ [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidesizescaletype/) จะสเกลเนื้อหาให้พอดีกับขนาดที่ร้องขอ

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

การปรับขนาดจะเปลี่ยนวัตถุพรีเซนเทชั่นต้นฉบับในหน่วยความจำ หากคุณต้องการให้พรีเซนเทชั่นต้นฉบับคงเดิมสำหรับการดำเนินการอื่น ๆ ให้เปิดอินสแตนซ์แยกสำหรับการรวม

## **รวมสไลด์เข้าสู่เซกชันของพรีเซนเทชั่น**

ลูปพื้นฐานที่โคลนสไลด์จะไม่สร้างโครงสร้างเซกชันของพรีเซนเทชั่นต้นฉบับ หากเซกชันสำคัญในผลลัพธ์ ให้สร้างหรือเลือกเซกชันในพรีเซนเทชั่นปลายทางและโคลนสไลด์เข้าไปโดยใช้ [SlideCollection.add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_clone/)

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

สไลด์ที่โคลนจะถูกเพิ่มต่อท้ายเซกชันปลายทางที่กำหนดไว้ เพื่คงหลายเซกชันของต้นฉบับ ให้สร้างเซกชันเหล่านั้นในปลายทางด้วย [SectionCollection.append_empty_section](https://reference.aspose.com/slides/th/python-net/aspose.slides/sectioncollection/append_empty_section/) แล้วแมพสไลด์ต้นฉบับแต่ละสไลด์ไปยังเซกชันปลายทางที่สอดคล้องกัน

## **รวมหลายพรีเซนเทชั่นอย่างปลอดภัย**

ตัวอย่างต่อไปนี้เป็นเวิร์กโฟลว์แบบครบวงจรที่ใช้พรีเซนเทชั่นแรกเป็นปลายทาง, ทำการปรับขนาดสไลด์ของแต่ละแหล่งเพิ่มเติม, เปิดแหล่งแต่ละอันเฉพาะในช่วงที่ทำการคัดลอก, และบันทึกไฟล์สุดท้ายเมื่อเสร็จสิ้น

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

นี่เป็นแนวทางพื้นฐานที่มีประโยชน์สำหรับการคงการจัดรูปแบบของสไลด์ที่นำเข้า หากผลลัพธ์ของคุณต้องใช้ธีมเดียวในปลายทาง ให้แทนที่การเรียก `add_clone(slide)` แบบง่ายด้วย overload มาสเตอร์หรือเลเอาต์ปลายทางที่แสดงไว้ก่อนหน้า

## **ข้อควรพิจารณาเชิงปฏิบัติ**

### **มาสเตอร์, เลเอาต์, และความแม่นยำของการจัดรูปแบบ**

การโคลนสไลด์แบบเริ่มต้นอาจนำมาสเตอร์ที่จำเป็นจากต้นฉบับเข้ามาในพรีเซนเทชั่นปลายทางโดยอัตโนมัติ Aspose.Slides จะเก็บรีจิสทรีภายในสำหรับมาสเตอร์ที่โคลนโดยอัตโนมัติเพื่อหลีกเลี่ยงการโคลนมาสเตอร์เดียวกันหลายครั้ง มาสเตอร์ที่โคลนด้วยตนเองจะไม่ได้รับการติดตามในรีจิสทรีนี้ ดังนั้นควรหลีกเลี่ยงการโคลนมาสเตอร์ล่วงหน้า เว้นแต่คุณต้องการควบคุมโครงสร้างมาสเตอร์อย่างชัดเจน

อย่ากลับคิดว่ามาสเตอร์หรือเลเอาต์สองตัวที่มีชื่อเดียวกันมีลักษณะทางสายตาเท่ากัน หากเทมเพลตขององค์กรต้องควบคุมรูปลักษณ์ขั้นสุดท้าย ให้เลือกมาสเตอร์หรือเลเอาต์ปลายทางอย่างชัดเจนและตรวจสอบผลลัพธ์หลังการรวม

### **โน้ตและความคิดเห็น**

โน้ตของผู้พูดและความคิดเห็นของสไลด์เชื่อมโยงกับเนื้อหาสไลด์และจะถูกคัดลอกเมื่อตัวสไลด์ถูกโคลน Aspose.Slides ยังมี API เฉพาะสำหรับ [presentation notes](https://docs.aspose.com/slides/th/python-net/presentation-notes/) และ [presentation comments](https://docs.aspose.com/slides/th/python-net/presentation-comments/)

หากการจัดรูปแบบของหน้าโน้ตสำคัญ ให้ตรวจสอบพรีเซนเทชั่นที่รวมแล้ว เนื่องจากโน้ตมาสเตอร์เป็นออบเจกต์ระดับพรีเซนเทชั่นและอาจแตกต่างกันระหว่างไฟล์ต้นฉบับ สำหรับกระบวนการตรวจสอบ ควรตรวจสอบผู้เขียนของความคิดเห็นและโครงสร้างการตอบโต้แบบเธรดหลังจากรวมไฟล์จากผู้เขียนหรือเทมเพลตที่แตกต่างกัน

### **ภาพ, เสียง, วิดีโอ, วัตถุ OLE, และลิงก์ภายนอก**

สไลด์อาจอ้างอิงถึงทรัพยากรระดับพรีเซนเทชั่น เช่น ภาพ, เสียงฝัง, วิดีโอฝัง, และข้อมูล OLE ให้โคลนสไลด์เองแทนการคัดลอ形แค่รูปร่างที่มองเห็น เพื่อให้ Aspose.Slides สามารถรักษาความสัมพันธ์ของสไลด์กับทรัพยากรได้

ทรัพยากรที่ฝังและที่ลิงก์ควรจัดการแยกกัน ลิงก์เสียง, วิดีโอ, วัตถุ OLE หรือไฮเปอร์ลิงก์ที่เป็นลิงก์จะยังคงพึ่งพาเป้าหมายภายนอก; การโคลนสไลด์ไม่ได้เปลี่ยนลิงก์ภายนอกเป็นเนื้อหาที่ฝัง ทดสอบเส้นทางและ URL ของทรัพยากรที่ลิงก์ในสภาพแวดล้อมที่พรีเซนเทชั่นที่รวมจะถูกเปิด

Aspose.Slides ติดตามมาสเตอร์ที่โคลนโดยอัตโนมัติ อย่างไรก็ตาม ไม่ควรถือว่าเป็นการรับประกันทั่วไปว่าทรัพยากรไบนารีที่เหมือนกันจากพรีเซนเทชั่นแหล่งที่ไม่เกี่ยวข้องจะถูกตัดซ้ำเสมอ หากขนาดไฟล์ผลลัพธ์เป็นสิ่งสำคัญ ให้ตรวจสอบแพ็กเกจที่รวมและวัดผลลัพธ์เองแทนการพึ่งพาการตัดซ้ำโดยนัย

### **ฟอนต์ที่ฝังและการพร้อมใช้งานของฟอนต์**

ฟอนต์จัดการในระดับพรีเซนเทชั่น หากต้องการให้การพิมพ์ตัวอักษรคงที่บนเครื่องต่าง ๆ อย่าถือว่าเพียงการโคลนสไลด์จะรับประกันว่าฟอนต์ที่จำเป็นทั้งหมดจะพร้อมใช้งานในสภาพแวดล้อมปลายทาง คุณสามารถตรวจสอบฟอนต์ที่ฝังด้วย [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) และจัดการการฝังอย่างชัดเจนตามที่อธิบายใน [Embed Fonts in Presentations](https://docs.aspose.com/slides/th/python-net/embedded-font/)

นอกจากนี้ควรตรวจสอบว่าคุณมีสิทธิ์ในการฝังฟอนต์ที่ใช้ในไฟล์ต้นฉบับ เนื่องจากใบอนุญาตฟอนต์อาจจำกัดการฝัง

### **พรีเซนเทชั่นที่มีรหัสผ่าน**

พรีเซนเทชั่นต้นฉบับที่ถูกป้องกันด้วยรหัสผ่านต้องถูกเปิดสำเร็จก่อนจึงจะโคลนสไลด์ได้ ให้ระบุรหัสผ่านผ่าน [LoadOptions.password](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/password/)

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

การเปิดไฟล์ที่เข้ารหัสจะไม่ทำให้พรีเซนเทชั่นปลายทางถูกป้องกันด้วยรหัสผ่านเดียวกันโดยอัตโนมัติ ให้กำหนดการป้องกันผลลัพธ์แยกต่างหากเมื่อจำเป็น

### **พรีเซนเทชั่นขนาดใหญ่และการใช้หน่วยความจำ**

พรีเซนเทชั่นขนาดใหญ่ที่มีภาพความละเอียดสูง, เสียง, วิดีโอ หรือวัตถุไบนารีขนาดใหญ่สามารถใช้หน่วยความจำอย่างมาก [LoadOptions.blob_management_options](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/blob_management_options/) ให้การควบคุมการจัดการ BLOB และการใช้ไฟล์ชั่วคราว ดู [Manage Presentation BLOBs](https://docs.aspose.com/slides/th/python-net/manage-blob/) สำหรับกลยุทธ์ไฟล์ขนาดใหญ่

สำหรับไฟล์ขนาดใหญ่ ควรโหลดจากเส้นทางไฟล์เมื่อตามความเป็นไปได้ ปิดพรีเซนเทชั่นต้นแต่ละอันทันทีหลังรวมเสร็จ และหลีกเลี่ยงการบันทึกผลลัพธ์กลางหลายครั้ง เว้นแต่เวิร์กโฟลว์ต้องการจุดตรวจสอบ ใช้ `with slides.Presentation(...)` เพื่อให้ทรัพยากรพรีเซนเทชั่นถูกปล่อยเมื่อลบคอนเท็กซ์

### **ความปลอดภัยของเธรด**

ห้ามโหลด, บันทึก หรือโคลนอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) พร้อมกันจากหลายเธรด ให้ทำการรวมแต่ละงานในโหมดเดียวสตรีม หากต้องการทำงานหลายงานพร้อมกัน ให้ใช้กระบวนการสตรีมเดี่ยวแยกกันและอินสแตนซ์พรีเซนเทชั่นอิสระตามที่แนะนำใน [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/th/python-net/multithreading/)

## **คำถามที่พบบ่อย**

**ฉันจะรักษาการออกแบบเดิมของแต่ละพรีเซนเทชั่นได้อย่างไร?**

ใช้ [`add_clone(source_slide)`](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_clone/) โดยไม่ระบุมาสเตอร์หรือเลเอาต์ปลายทาง Aspose.Slides สามารถโคลนมาสเตอร์ต้นฉบับโดยอัตโนมัติเมื่อสไลด์ที่นำเข้าต้องการ

**ฉันจะทำให้สไลด์ที่นำเข้าใช้ธีมของปลายทางได้อย่างไร?**

ใช้ overload ที่รับมาสตาร์ปลายทาง ส่งมาสตาร์จากพรีเซนเทชั่นปลายทาง ไม่ใช่จากต้นฉบับ Aspose.Slides จะพยายามแมพสไลด์ต้นฉบับแต่ละสไลด์ไปยังเลเอาต์ที่เหมาะสมภายใต้มาสตาร์นั้น

**เมื่อใดที่ควรใช้เลเอาต์ปลายทางเฉพาะแทนมาสตาร์ปลายทาง?**

ใช้เลเอาต์เฉพาะเมื่อสไลด์ที่นำเข้าทุกสไลด์ต้องใช้เลเอาต์ที่รู้จักไว้ล่วงหน้า ใช้มาสตาร์เมื่อคุณต้องการให้ Aspose.Slides เลือกเลเอาต์จากมาสตาร์นั้นตามประเภทหรือชื่อของเลเอาต์ต้นฉบับ

**พรีเซนเทชั่นที่มีขนาดสไลด์ต่างกันสามารถรวมกันได้หรือไม่?**

ได้ แต่เนื้อหาสไลด์จะไม่ถูกออกแบบใหม่อัตโนมัติสำหรับมิติปลายทาง ควรปรับขนาดพรีเซนเทชั่นต้นฉบับก่อน เช่น ด้วย [SlideSize.set_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidesize/set_size/) และ [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidesizescaletype/)

**ฉันสามารถรวมไฟล์ PPT, PPTX, และ ODP เป็นไฟล์เดียวได้หรือไม่?**

ได้ โหลดพรีเซนเทชั่นต้นฉบับแต่ละไฟล์, โคลนสไลด์ที่ต้องการเข้าสู่พรีเซนเทชั่นปลายทางหนึ่ง, แล้วบันทึกผลลัพธ์ในรูปแบบที่รองรับ เนื่องจากฟีเจอร์ของแต่ละรูปแบบไฟล์อาจแตกต่างกัน ควรตรวจสอบเนื้อหาซับซ้อนหลังการรวมข้ามรูปแบบ ดู [Supported File Formats](https://docs.aspose.com/slides/th/python-net/supported-file-formats/)

**ส่วนของต้นฉบับจะถูกคงไว้โดยอัตโนมัติหรือไม่?**

ไม่ หากใช้ลูปพื้นฐานที่โคลนสไลด์เท่านั้น ต้องสร้างส่วนที่ต้องการในปลายทางและใช้ overload ของ [add_clone](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/add_clone/) เพื่อคงโครงสร้างส่วน

**โน้ตของผู้พูดและความคิดเห็นจะถูกคงไว้หรือไม่?**

พวกมันจะถูกคัดลอกพร้อมกับสไลด์ที่โคลน สำหรับเวิร์กโฟลว์ที่พึ่งพาการจัดรูปแบบของโน้ตมาสตาร์, ผู้เขียนความคิดเห็น, หรือข้อมูลการตรวจสอบแบบเธรด ควรตรวจสอบผลลัพธ์ที่รวมแล้วเนื่องจากสถานการณ์เหล่านี้เกี่ยวข้องกับโครงสร้างระดับพรีเซนเทชั่นเช่นกันกับเนื้อหาระดับสไลด์

**เสียง, วิดีโอ, วัตถุ OLE, และไฮเปอร์ลิงก์จะเกิดอะไรขึ้น?**

เนื้อหาที่ฝังจะถูกนำมาพร้อมกับความสัมพันธ์ของทรัพยากรของสไลด์ที่โคลน ลิงก์ภายนอกจะคงอยู่เป็นลิงก์ภายนอก ดังนั้นไฟล์หรือ URL เป้าหมายต้องยังคงสามารถเข้าถึงได้หลังการรวม

**ฟอนต์ที่ฝังจากทุกต้นฉบับจะถูกรับประกันว่าจะมีอยู่ในพรีเซนเทชั่นที่รวมหรือไม่?**

อย่าพึ่งพาการโคลนสไลด์อย่างเดียวสำหรับการจัดจำหน่ายฟอนต์ ตรวจสอบฟอนต์ที่ฝังในปลายทางและจัดการการฝังหรือการให้บริการฟอนต์ภายนอกอย่างชัดเจนเมื่อการจัดพิมพ์เป็นสิ่งสำคัญ

**ฉันจะรวมไฟล์ที่ป้องกันด้วยรหัสผ่านได้อย่างไร?**

เปิดไฟล์ด้วย [LoadOptions.password](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/password/) ที่ถูกต้อง แล้วโคลนสไลด์ตามปกติ การป้องกันผลลัพธ์ต้องกำหนดแยกต่างหาก

**ฉันควรจัดการพรีเซนเทชั่นขนาดใหญอย่างไร?**

ใช้การจัดการ BLOB เมื่อวัตถุไบนารีขนาดใหญ่เป็นส่วนนำของหน่วยความจำ, โหลดจากเส้นทางไฟล์เมื่อทำได้, ปิดพรีเซนเทชั่นต้นฉบับทันทีหลังการรวม, และบันทึกผลลัพธ์สุดท้ายเมื่อต้องการ

**ฉันสามารถโคลนสไลด์จากหลายเธรดได้หรือไม่?**

ห้ามโหลด, บันทึก, หรือโคลนอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) จากหลายเธรดพร้อมกัน ให้ทำการรวมแต่ละงานแบบสตรีมเดียว; หากต้องการทำงานหลายงานพร้อมกัน ให้ใช้กระบวนการสตรีมเดี่ยวแยกกันและอินสแตนซ์พรีเซนเทชั่นอิสระ.