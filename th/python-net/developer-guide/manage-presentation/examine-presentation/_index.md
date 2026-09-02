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
description: "สำรวจสไลด์ โครงสร้างและเมตาดาต้าในการนำเสนอ PowerPoint และ OpenDocument ด้วย Python เพื่อให้ได้ข้อมูลเชิงลึกที่รวดเร็วและการตรวจสอบเนื้อหาที่ชาญฉลาดขึ้น."
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของการนำเสนอและอ่านข้อมูลเมตาดาต้าเอกสารโดยไม่ต้องสร้างโมเดลวัตถุการนำเสนอที่สมบูรณ์ นี่มีประโยชน์เมื่อคุณต้องการจัดประเภทไฟล์ สร้างรายการสต็อก หรือสอบคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหาการนำเสนอหรือไม่.

บทความนี้แสดงการตรวจสอบแบบเบาโดยใช้ [PresentationFactory](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/) และ [PresentationInfo](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/), รวมถึงการอัปเดตแบบเจาะจงผ่าน [DocumentProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/).

## **ตรวจสอบรูปแบบการนำเสนอ**

ใช้ [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) คุณสมบัติ [PresentationInfo.load_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/load_format/) รายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **สร้างรายการสต็อกการนำเสนอแบบเบา**

เมื่อคุณประมวลผลไฟล์การนำเสนอจำนวนมาก คุณอาจต้องการรายการสต็อกที่กะทัดรัดสำหรับการตรวจสอบ ความจัดทำดัชนี หรือระบบการจัดการเอกสาร ในกรณีนี้ ใช้ [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) เพื่อรับอ็อบเจ็กต์ [PresentationInfo](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/) แล้วเรียก [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/read_document_properties/) เพื่ออ่านข้อมูลเมตาดาต้าเอกสาร วิธีนี้ไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) หรือบังคับให้คุณวนรอบโมเดลวัตถุการนำเสนอเต็มรูปแบบ.

คุณสมบัติเพิ่มเติมที่เปิดโดย [DocumentProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/) ให้ค่ารายการสต็อกต่อไปนี้:

| คุณสมบัติ | ค่ารายการสต็อก |
| --- | --- |
| [slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/slides/th/) | จำนวนสไลด์ทั้งหมด. |
| [hidden_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/hidden_slides/) | จำนวนสไลด์ที่ซ่อนอยู่. |
| [notes](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/notes/) | จำนวนสไลด์ที่มีบันทึกอธิบาย. |
| [paragraphs](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/paragraphs/) | จำนวนย่อหน้าทั้งหมด (ถ้ามี). |
| [words](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/words/) | จำนวนคำทั้งหมด. |
| [multimedia_clips](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/multimedia_clips/) | จำนวนคลิปเสียงและวิดีโอทั้งหมด. |

ตัวอย่างต่อไปนี้อ่านค่าเหล่านี้โดยไม่สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และพิมพ์รายการสต็อกแบบกะทัดรัด นอกจากนี้ยังรวม [heading_pairs](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/heading_pairs/) กับ [titles_of_parts](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/titles_of_parts/) เพื่อแสดงกลุ่มเนื้อหา เช่น แบบอักษร ธีม และชื่อสไลด์.

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

แต่ละ [HeadingPair](https://reference.aspose.com/slides/th/python-net/aspose.slides/headingpair/) ให้ชื่อกลุ่มและจำนวนรายการในกลุ่มนั้น [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/titles_of_parts/) เป็นคอลเลกชันแบบแบนที่เรียงลำดับ ดังนั้นให้ใช้จำนวนชื่อที่ต่อเนื่องตามที่กำหนดโดยแต่ละ heading pair.

### **เมตาดาต้าจัดเก็บและข้อจำกัดของรูปแบบ**

คุณสมบัติรายการสต็อกที่ส่งคืนโดย [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/read_document_properties/) สะท้อนเมตาดาต้าที่มีในเอกสารต้นทาง Aspose.Slides ไม่โหลดและวนรอบโมเดลวัตถุการนำเสนอเพื่อคำนวณค่าตามใหม่สำหรับการเรียกนี้ คุณสมบัติที่ขาดหายจะถูกแทนด้วยค่ามาตรฐาน และค่าที่จัดเก็บอาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ล่าสุดไม่ได้อัปเดตคุณสมบัติของเอกสาร.

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเพิ่มเติมของเอกสารสำหรับจำนวนสไลด์, โน้ต, สไลด์ที่ซ่อน, ย่อหน้า, คำ, และมัลติมีเดีย รวมถึง heading pairs และ part titles ความพร้อมใช้งานขึ้นอยู่กับว่าคุณสมบัติเหล่านั้นถูกเขียนโดยผู้ผลิตเอกสารหรือไม่.
- **PPT:** รูปแบบไบนารีนี้สามารถจัดเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องกัน หากคุณสมบัติเช่นนั้นไม่มีหรือไม่ได้รับการอัปเดตโดยผู้ผลิตเอกสาร Aspose.Slides จะคืนค่าที่จัดเก็บหรือค่าเริ่มต้นแทนที่จะคำนวณจากสไลด์.
- **ODP:** เมตาดาต้า OpenDocument ให้สถิติทั่วไปของเอกสาร เช่น จำนวนหน้า, ย่อหน้า, และคำ แต่ค่าต่าง ๆ นี้ไม่สอดคล้องกับคุณสมบัติเพิ่มเติมเฉพาะ PowerPoint บางอย่าง เช่น hidden-slide, notes-slide, multimedia, heading-pair, และ part-title อาจไม่มีให้ใช้งาน และคุณสมบัติสต็อกอาจคืนค่ามาตรฐาน อย่ามองว่าค่าเป็นศูนย์หรือคอลเลกชันว่างเป็นหลักฐานที่แน่นอนว่าข้อมูลที่สอดคล้องไม่มีอยู่.

ใช้วิธีเมตาดาต้าแบบเบาสำหรับการสร้างสต็อกและการตรวจสอบเบื้องต้น โหลดการนำเสนอและตรวจสอบโมเดลวัตถุแบบเรียลไทม์เมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องการตรวจสอบเนื้อหาการนำเสนอจริง.

## **อัปเดตคุณสมบัติการนำเสนอ**

คุณสมบัติที่ส่งคืนโดย [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/read_document_properties/) สามารถเปลี่ยนแปลงได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ใช้การเปลี่ยนแปลงด้วย [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/update_document_properties/), แล้วเขียนการนำเสนอที่ผูกไว้ด้วย [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

ภาพต่อไปนี้แสดงคุณสมบัติเอกสารต้นฉบับของการนำเสนอ PowerPoint.

![คุณสมบัติเอกสารต้นฉบับของการนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างต่อไปนี้เปลี่ยนชื่อเรื่องและเวลาการบันทึกล่าสุดและเขียนผลลัพธ์ไปยังไฟล์ใหม่:

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

ภาพต่อไปนี้แสดงคุณสมบัติเอกสารที่อัปเดต.

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยและการตั้งค่าการปกป้องที่เกี่ยวข้อง ดูบทความต่อไปนี้:

- [การปกป้องการนำเสนอด้วยรหัสผ่าน](/slides/th/python-net/password-protected-presentation/)
- [การปกป้องการเขียนการนำเสนอ](/slides/th/python-net/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรถูกฝังอยู่หรือไม่และมีแบบใดบ้าง?**

โหลดการนำเสนอและใช้ [Presentation.fonts_manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/fonts_manager/). เรียก [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) เพื่อรับแบบอักษรที่ฝังอยู่และ [FontsManager.get_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_fonts/) เพื่อรับแบบอักษรที่การนำใช้เปรียบเทียบผลลัพธ์ทั้งสองเพื่อค้นหาแบบอักษรที่จำเป็นสำหรับการเรนเดอร์แต่ไม่ได้ฝัง.

**ฉันจะตรวจสอบอย่างรวดเร็วได้ไหมว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าใด?**

เมื่อเมตาดาต้าเอกสารที่จัดเก็บเพียงพอ ให้อ่าน [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/hidden_slides/) ผ่าน [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) และ [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/read_document_properties/). วิธีนี้เหมาะสำหรับการสร้างสต็อกแบบเบา หากการนำเสนอได้รับการแก้ไขในหน่วยความจำ เมตาดาต้าที่จัดเก็บอาจขาดหายหรือล้าสมัย หรือคุณต้องการตรวจสอบค่าที่เป็นจริง ให้วนรอบผ่าน [Presentation.slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slides/th/) และตรวจสอบคุณสมบัติ [Slide.hidden](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/hidden/) ของแต่ละสไลด์แทน.

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและการวางแนวสไลด์ที่กำหนดเองหรือไม่ และว่าต่างจากค่าเริ่มต้นหรือไม่?**

ได้เลย โหลดการนำเสนอและอ่าน [Presentation.slide_size](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slide_size/). ตรวจสอบ [SlideSize.type](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidesize/size/), และ [SlideSize.orientation](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidesize/orientation/) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับค่าที่กำหนดล่วงหน้าและมิติที่คาดหวัง.

**มีวิธีรวดเร็วในการตรวจสอบว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ได้เลย ค้นหาแต่ละ [Chart](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/) และตรวจสอบ [ChartData.data_source_type](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/data_source_type/). หากเป็นเวิร์กบุ๊กภายนอก ให้อ่าน [ChartData.external_workbook_path](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/external_workbook_path/). ประเภทแหล่งข้อมูลและเส้นทางบ่งชี้การอ้างอิงภายนอก แต่การตรวจสอบว่าตำแหน่งเป้าหมายพร้อมใช้งานหรือไม่ต้องทำการตรวจสอบทรัพยากรแยกต่างหาก.

**ฉันจะประเมินสไลด์ที่ 'หนัก' ซึ่งอาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าได้อย่างไร?**

ไม่มีคุณสมบัติความซับซ้อนเดียวที่ใช้ได้ ให้วนรอบ [Presentation.slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slides/th/) และคอลเลกชัน [BaseSlide.shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/shapes/) ของแต่ละสไลด์ ใช้จำนวนรูปทรงและการมีอยู่ของภาพขนาดใหญ่ เอฟเฟกต์ แอนิเมชัน หรือมัลติมีเดียเป็นสัญญาณคัดกรอง และทำการวัดการเรนเดอร์หรือการส่งออกตัวอย่างก่อนที่จะถือว่าสไลด์เป็นคอขวดด้านประสิทธิภาพที่ยืนยันได้.