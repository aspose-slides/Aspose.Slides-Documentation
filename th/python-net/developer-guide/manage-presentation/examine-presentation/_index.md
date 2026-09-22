---
title: ดึงข้อมูลและอัปเดตข้อมูลการนำเสนอใน Python
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/python-net/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- ดึงคุณสมบัติ
- อ่านคุณสมบัติ
- เปลี่ยนคุณสมบัติ
- แก้ไขคุณสมบัติ
- อัปเดตคุณสมบัติ
- ตรวจสอบ PPTX
- ตรวจสอบ PPT
- ตรวจสอบ ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้างและเมทาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Python เพื่อให้ได้ข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น."
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของการนำเสนอและอ่านเมตาดาต้าเอกสารโดยไม่ต้องสร้างอ็อบเจกต์โมเดลการนำเสนอเต็มรูปแบบ ซึ่งเป็นประโยชน์เมื่อต้องจัดประเภทไฟล์ สร้างรายการตรวจสอบ หรือสอบคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหาการนำเสนอหรือไม่

บทความนี้แสดงการตรวจสอบแบบน้ำหนักเบาผ่าน [PresentationFactory](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/) และ [PresentationInfo](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/) พร้อมกับการอัปเดตแบบเจาะจงผ่าน [DocumentProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/)

## **ตรวจสอบรูปแบบการนำเสนอ**

หากคุณมีการนำเสนอที่โหลดแล้วแล้ว ให้ดู [Determine the Original Presentation Format](/slides/th/python-net/detect-presentation-source-format/) เพื่อทำการตรวจจับหลังจากโหลดและดูข้อจำกัดของสตรีม PPT, PPS, และ POT รุ่นเก่า

ใช้ [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) เพื่อสำรวจไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) คุณสมบัติ [PresentationInfo.load_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/load_format/) จะรายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **สร้างรายการตรวจสอบการนำเสนอแบบเบา**

เมื่อคุณต้องประมวลผลไฟล์การนำเสนอจำนวนมาก อาจต้องการรายการตรวจสอบแบบคอมแพคสำหรับการตรวจสอบ ความจัดทำดัชนี หรือระบบจัดการเอกสาร ในกรณีนี้ให้ใช้ [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) เพื่อรับออบเจกต์ [PresentationInfo](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/) และจากนั้นเรียก [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/read_document_properties/) เพื่ออ่านเมตาดาต้าเอกสาร วิธีนี้จะไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) หรือทำให้ต้องเดินทางผ่านโมเดลอ็อบเจกต์การนำเสนอทั้งหมด

คุณสมบัติที่ขยายโดย [DocumentProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/) ให้ค่าต่อไปนี้สำหรับรายการตรวจสอบ:

| Property | ค่าที่เก็บไว้ |
| --- | --- |
| [slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/slides/th/) | จำนวนสไลด์ทั้งหมด |
| [hidden_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/hidden_slides/) | จำนวนสไลด์ที่ซ่อนอยู่ |
| [notes](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/notes/) | จำนวนสไลด์ที่มีบันทึกย่อย |
| [paragraphs](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/paragraphs/) | จำนวนย่อหน้าทั้งหมด (ถ้ามี) |
| [words](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/words/) | จำนวนคำทั้งหมด |
| [multimedia_clips](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/multimedia_clips/) | จำนวนคลิปเสียงและวิดีโอทั้งหมด |

ตัวอย่างต่อไปนี้อ่านค่าดังกล่าวโดยไม่สร้างออบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) แล้วพิมพ์รายการตรวจสอบแบบคอมแพค อีกทั้งยังรวม [heading_pairs](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/heading_pairs/) กับ [titles_of_parts](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/titles_of_parts/) เพื่อแสดงกลุ่มเนื้อหา เช่น ฟอนท์ ธีม และชื่อสไลด์

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
            if part_index >= len(titles_of_parts):
                break

            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

แต่ละ [HeadingPair](https://reference.aspose.com/slides/th/python-net/aspose.slides/headingpair/) จะให้ชื่อกลุ่มและจำนวนรายการในกลุ่มนั้น [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/titles_of_parts/) เป็นคอลเลกชั่นที่จัดลำดับแบบแฟลต จึงควรดึงจำนวนชื่อที่ต่อเนื่องตามที่กำหนดโดยแต่ละ heading pair

### **เมตาดาต้าที่จัดเก็บและข้อจำกัดรูปแบบ**

คุณสมบัติรายการตรวจสอบที่คืนค่าจาก [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/read_document_properties/) แสดงเมตาดาต้าที่มีในเอกสารต้นทาง Aspose.Slides ไม่ได้โหลดและเดินทางผ่านโมเดลอ็อบเจกต์การนำเสนอเพื่อคำนวนค่าเหล่านี้ใหม่สำหรับการเรียกนี้ คุณสมบัติที่หายจะถูกแทนค่าด้วยค่าเริ่มต้น และค่าที่เก็บไว้อาจเป็นข้อมูลเก่า หากแอปพลิเคชันที่บันทึกไฟล์ครั้งสุดท้ายไม่ได้อัปเดตคุณสมบัติเอกสาร

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเอกสารขยายสำหรับจำนวนสไลด์, โน้ต, สไลด์ที่ซ่อน, ย่อหน้า, คำ และมัลติมีเดีย รวมทั้ง heading pairs และ part titles ความพร้อมใช้งานขึ้นอยู่กับว่าผลิตภัณฑ์เอกสารเขียนคุณสมบัติเหล่านี้หรือไม่
- **PPT:** รูปแบบไบนารีสามารถเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องได้ หากคุณสมบัติเช่นนั้นไม่มีหรือไม่ได้รับการรีเฟรชโดยผู้ผลิตเอกสาร Aspose.Slides จะคืนค่าที่เก็บไว้หรือค่าเริ่มต้นแทนการคำนวนจากสไลด์
- **ODP:** เมตาดาต้า OpenDocument ให้สถิติเอกสารทั่วไป เช่น จำนวนหน้า, ย่อหน้า, คำ แต่ค่าเหล่านี้ไม่แมปกับคุณสมบัติขยายเฉพาะ PowerPoint ทุกอย่าง เมตาดาต้าเกี่ยวกับสไลด์ที่ซ่อน, โน้ต, มัลติมีเดีย, heading‑pair, และ part‑title อาจไม่มีและคุณสมบัติรายการตรวจสอบอาจคืนค่าดีฟอลต์ อย่าพิจารณาค่า 0 หรือคอลเลกชันว่างเป็นหลักฐานแน่นอนว่าข้อมูลดังกล่าวไม่มีอยู่

ใช้วิธีเมตาดาต้าน้ำหนักเบาสำหรับรายการตรวจสอบและการตรวจสอบเบื้องต้น โหลดการนำเสนอและสำรวจโมเดลอ็อบเจกต์แบบสดเมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อจำเป็นต้องตรวจสอบเนื้อหาการนำเสนอจริง

## **อัปเดตคุณสมบัติการนำเสนอ**

คุณสมบัติที่คืนค่าจาก [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/read_document_properties/) สามารถเปลี่ยนแปลงได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ใช้ [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/update_document_properties/) เพื่อบันทึกการเปลี่ยนแปลง แล้วเขียนการนำเสนอที่เชื่อมโยงด้วย [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/write_binded_presentation/)

รูปภาพต่อไปนี้แสดงคุณสมบัติเอกสารต้นฉบับ

![คุณสมบัติเอกสารต้นฉบับของงานนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างต่อไปนี้เปลี่ยนชื่อเรื่องและเวลาบันทึกครั้งสุดท้าย แล้วเขียนผลลัพธ์ไปยังไฟล์ใหม่:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

รูปภาพต่อไปนี้แสดงคุณสมบัติเอกสารที่อัปเดตแล้ว

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของงานนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยและการตั้งค่าการป้องกันที่เกี่ยวข้อง ดูบทความต่อไปนี้:

- [Password‑Protect Presentations](/slides/th/python-net/password-protected-presentation/)
- [Write‑Protect Presentations](/slides/th/python-net/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรถูกฝังและมีอะไรบ้าง?**

โหลดการนำเสนอและใช้ [Presentation.fonts_manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/fonts_manager/) เรียก [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) เพื่อรับแบบอักษรที่ฝังไว้และ [FontsManager.get_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_fonts/) เพื่อรับแบบอักษรที่การนำใช้ เปรียบเทียบผลลัพธ์สองชุดเพื่อหารูปแบบที่จำเป็นต่อการเรนเดอร์แต่ไม่ได้ฝังไว้

**ฉันจะบอกได้อย่างรวดเร็วว่ามีสไลด์ที่ซ่อนอยู่หรือไม่และมีเท่าไหร่?**

เมื่อเมตาดาต้าเอกสารที่เก็บไว้เพียงพอ ให้อ่าน [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/hidden_slides/) ผ่าน [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) และ [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/read_document_properties/) วิธีนี้เหมาะสำหรับรายการตรวจสอบแบบเบา หากการนำเสนอถูกแก้ไขในหน่วยความจำเมตาดาต้าอาจหายหรือล้าสมัย หรือหากต้องการตรวจสอบค่าที่เป็นสด ให้วนลูปผ่าน [Presentation.slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slides/th/) และตรวจสอบคุณสมบัติ [Slide.hidden](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/hidden/) ของแต่ละสไลด์

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดสไลด์และการจัดแนวแบบกำหนดเองและว่าแตกต่างจากค่าตั้งต้นหรือไม่?**

ทำได้ โหลดการนำเสนอและอ่าน [Presentation.slide_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slide_size/) ตรวจสอบ [SlideSize.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidesize/size/) และ [SlideSize.orientation](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidesize/orientation/) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับค่าตั้งต้นที่คาดหวังและมิติที่กำหนดไว้

**มีวิธีง่าย ๆ ที่จะดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ทำได้ ค้นหาทุก [Chart](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/) และตรวจสอบ [ChartData.data_source_type](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/data_source_type/) หากเป็น workbook ภายนอก ให้อ่าน [ChartData.external_workbook_path](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ชนิดของแหล่งข้อมูลและเส้นทางจะบ่งชี้ว่ามีการอ้างอิงภายนอก แต่การตรวจสอบว่าไฟล์เป้าหมายพร้อมใช้งานหรือไม่ต้องทำตรวจสอบทรัพยากรแยกต่างหาก

**ฉันจะประเมินสไลด์ ‘หนัก’ ที่อาจทำให้การเรนเดอร์หรือการส่งออก PDF ช้าได้อย่างไร?**

ไม่มีคุณสมบัติความซับซ้อนเพียงอย่างเดียว ให้เดินทางผ่าน [Presentation.slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slides/th/) และคอลเลกชั่น [BaseSlide.shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/shapes/) ของแต่ละสไลด์ ใช้จำนวนรูปทรงและการมีภาพขนาดใหญ่, เอฟเฟกต์, แอนิเมชัน หรือมัลติมีเดียเป็นสัญญาณการคัดกรอง แล้ววัดการเรนเดอร์หรือการส่งออกตัวอย่างก่อนที่จะสรุปว่าสไลด์เป็นคอขวดประสิทธิภาพที่ยืนยันได้