---
title: ดึงข้อมูลและอัปเดตข้อมูลการนำเสนอใน Python ผ่าน Java
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/python-java/examine-presentation/
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
- Java
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้าง และเมตาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Python ผ่าน Java เพื่อให้ได้ข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น"
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของการนำเสนอและอ่านเมตาดาต้าเอกสารโดยไม่ต้องสร้างโมเดลวัตถุการนำเสนอเต็มรูปแบบ ซึ่งเป็นประโยชน์เมื่อต้องการจัดประเภทไฟล์ สร้างรายการสินค้าคงคลัง หรือตรวจสอบคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหาการนำเสนอหรือไม่

ตัวอย่างเหล่านี้ต้องใช้ Aspose.Slides สำหรับ Python ผ่าน Java และ runtime ของ Java ที่เข้ากันได้ แต่ละตัวอย่างจะเริ่ม JVM หากยังไม่ได้ทำงาน ให้จัดเตรียมไฟล์การนำเสนอที่มีอยู่ตามเส้นทางที่ใช้ในตัวอย่าง

บทความนี้แสดงการตรวจสอบแบบเบาโดยใช้ [PresentationFactory](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/) และ [PresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/), รวมถึงการอัปเดตที่เจาะจงผ่าน [DocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/).

## **ตรวจสอบรูปแบบการนำเสนอ**

หากคุณมีการนำเสนอที่โหลดแล้ว ให้ดูที่ [Determine the Original Presentation Format](/slides/th/python-java/detect-presentation-source-format/) สำหรับการตรวจจับหลังจากโหลดและข้อจำกัดของสตรีม PPT, PPS และ POT รุ่นเก่า

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) วิธีการ [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#getLoadFormat) จะรายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **สร้างรายการสินค้าคงคลังการนำเสนอแบบเบา**

เมื่อคุณประมวลผลไฟล์การนำเสนอจำนวนมาก คุณอาจต้องการรายการสินค้าคงคลังที่กะทัดรัดสำหรับการตรวจสอบ การทำดัชนี หรือระบบจัดการเอกสาร ในกรณีนี้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) เพื่อรับอ็อบเจกต์ [PresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/) แล้วเรียก [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) เพื่ออ่านเมตาดาต้าเอกสาร วิธีนี้ไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) หรือจำเป็นต้องเรียกผ่านโมเดลวัตถุการนำเสนอทั้งหมด

คุณสมบัติเพิ่มเติมที่เปิดเผยโดย [DocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/) ให้ค่าในรายการสินค้าคงคลังดังต่อไปนี้:

| วิธีการ | ค่าในรายการสินค้าคงคลัง |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getSlides) | จำนวนสไลด์ทั้งหมด |
| [getHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getHiddenSlides) | จำนวนสไลด์ที่ซ่อนอยู่ |
| [getNotes](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getNotes) | จำนวนสไลด์ที่มีโน้ต |
| [getParagraphs](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getParagraphs) | จำนวนย่อหน้าทั้งหมด (หากมี) |
| [getWords](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getWords) | จำนวนคำทั้งหมด |
| [getMultimediaClips](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getMultimediaClips) | จำนวนคลิปเสียงและวิดีโอทั้งหมด |

ตัวอย่างต่อไปนี้อ่านค่าดังกล่าวโดยไม่สร้างอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และพิมพ์รายการสินค้าคงคลังแบบกะทัดรัด นอกจากนี้ยังรวม [getHeadingPairs](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getHeadingPairs) กับ [getTitlesOfParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getTitlesOfParts) เพื่อแสดงกลุ่มเนื้อหาเช่น แบบอักษร ธีม และหัวข้อสไลด์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
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

แต่ละ [HeadingPair](https://reference.aspose.com/slides/th/python-java/aspose.slides/headingpair/) ให้ชื่อกลุ่มและจำนวนรายการในกลุ่มนั้น [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getTitlesOfParts) คืนค่าเป็นอาเรย์แบนเรียงลำดับ ดังนั้นจึงต้องใช้จำนวนชื่อที่ต่อเนื่องตามที่ระบุในแต่ละ heading pair

### **เมทาดาต้าที่เก็บไว้และข้อจำกัดของรูปแบบ**

คุณสมบัติตามรายการสินค้าคงคลังที่คืนค่าจาก [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) สะท้อนเมทาดาต้าที่มีในเอกสารต้นทาง Aspose.Slides ไม่ได้โหลดและเรียกผ่านโมเดลวัตถุการนำเสนอเพื่อคำนวนค่าเหล่านี้ใหม่สำหรับการเรียกนี้ คุณสมบัติที่หายไปจะถูกแทนด้วยค่ามาตรฐาน และค่าที่เก็บอาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ครั้งล่าสุดไม่ได้อัปเดตคุณสมบัติเอกสาร

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเพิ่มเติมของเอกสารสำหรับจำนวนสไลด์, โน้ต, สไลด์ที่ซ่อน, ย่อหน้า, คำ, และสื่อมัลติมีเดีย รวมถึง heading pairs และ part titles ความพร้อมใช้งานขึ้นอยู่กับว่าคุณสมบัติเหล่านี้ถูกเขียนโดยผู้ผลิตเอกสารหรือไม่
- **PPT:** รูปแบบไบนารีนี้สามารถเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องกันได้ หากคุณสมบัติใดหายไปหรือไม่ได้รับการรีเฟรชโดยผู้ผลิตเอกสาร Aspose.Slides จะคืนค่าที่เก็บไว้หรือค่ามาตรฐานแทนที่จะคำนวนจากสไลด์
- **ODP:** เมทาดาต้า OpenDocument ให้สถิติเอกสารทั่วไป เช่น จำนวนหน้า, ย่อหน้า, และคำ แต่ค่าต่างๆ ไม่ได้แมปกับคุณสมบัติเพิ่มเติมของ PowerPoint ทุกประการ เมทาดาต้าเกี่ยวกับสไลด์ที่ซ่อน, สไลด์โน้ต, มัลติมีเดีย, heading-pair, และ part-title อาจไม่มี และคุณสมบัติในรายการสินค้าคงคลังอาจคืนค่ามาตรฐาน อย่าพิจารณาค่า 0 หรืออาเรย์ว่างเป็นหลักฐานยืนยันว่內容ที่สอดคล้องไม่มีอยู่

ใช้วิธีเมทาดาต้าแบบเบาสำหรับการสร้างรายการสินค้าคงคลังและการตรวจสอบเบื้องต้น โหลดการนำเสนอและตรวจสอบโมเดลวัตถุแบบเรียลไทม์เมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อต้องการตรวจสอบเนื้อหาการนำเสนอจริง

## **อัปเดตคุณสมบัติการนำเสนอ**

คุณสมบัติที่คืนค่าจาก [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) สามารถเปลี่ยนแปลงได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ใช้ [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) เพื่อทำการเปลี่ยนแปลง แล้วเขียนการนำเสนอที่ผูกไว้ด้วย [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#writeBindedPresentation)

ภาพต่อไปนี้แสดงคุณสมบัติเอกสารต้นฉบับของงานนำเสนอ PowerPoint
![คุณสมบัติเอกสารต้นฉบับของงานนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างต่อไปนี้เปลี่ยนชื่อเรื่องและเวลาการบันทึกครั้งสุดท้าย แล้วเขียนผลลัพธ์ไปยังไฟล์ใหม่:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

ภาพต่อไปนี้แสดงคุณสมบัติเอกสารที่อัปเดตแล้ว
![คุณสมบัติเอกสารที่เปลี่ยนแปลงของงานนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยที่เกี่ยวข้องและการตั้งค่าการป้องกัน ดูบทความต่อไปนี้:
- [ป้องกันการนำเสนอด้วยรหัสผ่าน](/slides/th/python-java/password-protected-presentation/)
- [ป้องกันการเขียนการนำเสนอ](/slides/th/python-java/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรรูปแบบอักษรถูกฝังไว้หรือไม่และมีอะไรบ้าง?**

โหลดการนำเสนอและใช้ [Presentation.getFontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getFontsManager). เรียก [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) เพื่อรับรูปแบบอักษรที่ฝังไว้และ [FontsManager.getFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#getFonts) เพื่อรับรูปแบบอักษรที่การนำเสนอใช้ เปรียบเทียบผลลัพธ์ทั้งสองเพื่อหาฟอนต์ที่จำเป็นสำหรับการเรนเดอร์แต่ไม่ได้ฝังไว้

**ฉันจะตรวจสอบได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าใด?**

เมื่อเมทาดาต้าเอกสารที่เก็บไว้เพียงพอ ให้อ่าน [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getHiddenSlides) ผ่าน [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) และ [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) วิธีนี้เหมาะสำหรับรายการสินค้าคงคลังแบบเบา หากการนำเสนอถูกแก้ไขในหน่วยความจำ เมทาดาต้าที่เก็บอาจหายหรือเก่า หรือคุณต้องการตรวจสอบค่าปัจจุบัน ให้วนผ่าน [Presentation.getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlides) และตรวจสอบวิธีการ [Slide.getHidden](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getHidden) ของแต่ละสไลด์แทน

**ฉันจะตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและการวางแนวสไลด์ที่กำหนดเองหรือไม่และว่ามีความแตกต่างจากค่ามาตรฐานหรือไม่?**

ใช่ โหลดการนำเสนอและเรียก [Presentation.getSlideSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlideSize). ใช้ [SlideSize.getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/#getSize), และ [SlideSize.getOrientation](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/#getOrientation) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับค่าที่กำหนดไว้ล่วงหน้าและขนาดที่คาดหวัง

**มีวิธีรวดเร็วในการตรวจสอบว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ใช่ ค้นหาแต่ละ [Chart](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/) แล้วเรียก [ChartData.getDataSourceType](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getDataSourceType). สำหรับสมุดงานภายนอก ให้เรียก [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). ประเภทและเส้นทางของแหล่งข้อมูลระบุการอ้างอิงภายนอก แต่การตรวจสอบว่ามีเป้าหมายอยู่หรือไม่ต้องทำการตรวจสอบแหล่งทรัพยากรแยกต่างหาก

**ฉันจะประเมินสไลด์ที่ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าลงได้อย่างไร?**

ไม่มีคุณสมบัติเพียงอย่างเดียวที่บ่งชี้ความซับซ้อน ให้เรียกผ่าน [Presentation.getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlides) และคอลเลกชัน [BaseSlide.getShapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getShapes) ของแต่ละสไลด์ ใช้จำนวนรูปทรงและการมีอยู่ของภาพขนาดใหญ่ เอฟเฟกต์ แอนิเมชัน หรือมัลติมีเดียเป็นสัญญาณคัดกรอง และทำการวัดการเรนเดอร์หรือการส่งออกตัวอย่างก่อนที่จะพิจารณาสไลด์เป็นคอขวดด้านประสิทธิภาพที่ยืนยันได้