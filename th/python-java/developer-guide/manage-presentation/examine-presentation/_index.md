---
title: ดึงและอัปเดตข้อมูลการนำเสนอใน Python ผ่าน Java
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/python-java/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- รับคุณสมบัติ
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
description: "สำรวจสไลด์ โครงสร้างและเมตาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Python ผ่าน Java เพื่อรับข้อมูลเชิงลึกที่รวดเร็วและการตรวจสอบเนื้อหาที่ฉลาดขึ้น"
---
## **ภาพรวม**

Aspose.Slides สามารถตรวจสอบรูปแบบของงานนำเสนอและอ่านเมตาดาต้าเอกสารได้โดยไม่ต้องสร้างโมเดลวัตถุของงานนำเสนออย่างสมบูรณ์ ซึ่งเป็นประโยชน์เมื่อคุณต้องการจัดประเภทไฟล์ สร้างรายการสินค้าคงคลัง หรือสำรวจคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหาของงานนำเสนอหรือไม่  

ตัวอย่างต้องการ Aspose.Slides สำหรับ Python ผ่าน Java และ Java runtime ที่เข้ากันได้ แต่ละตัวอย่างจะเริ่ม JVM หากยังไม่ได้รัน ให้จัดหาไฟล์งานนำเสนอที่มีอยู่ตามเส้นทางที่ใช้ในตัวอย่าง  

บทความนี้แสดงการตรวจสอบแบบเบาบางผ่าน [PresentationFactory](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/) และ [PresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/), รวมถึงการอัปเดตแบบเจาะจงผ่าน [DocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/).

## **ตรวจสอบรูปแบบงานนำเสนอ**

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

## **สร้างสินค้าคงคลังงานนำเสนอแบบเบาบาง**

เมื่อคุณประมวลผลไฟล์งานนำเสนอจำนวนมาก คุณอาจต้องการสินค้าคงคลังแบบกะทัดรัดเพื่อการตรวจสอบ การทำดัชนี หรือระบบจัดการเอกสาร ในสถานการณ์นี้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) เพื่อรับออบเจ็กต์ [PresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/) แล้วเรียก [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) เพื่ออ่านเมตาดาต้าเอกสาร วิธีการนี้ไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) หรือบังคับให้คุณต้องสำรวจโมเดลวัตถุของงานนำเสนอทั้งหมด  

คุณสมบัติเพิ่มเติมที่ [DocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/) เผยออกมาจะให้ค่าต่อไปนี้สำหรับสินค้าคงคลัง:

| วิธีการ | ค่าที่เก็บ |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getSlides) | จำนวนสไลด์ทั้งหมด |
| [getHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getHiddenSlides) | จำนวนสไลด์ที่ซ่อนอยู่ |
| [getNotes](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getNotes) | จำนวนสไลด์ที่มีบันทึกหมายเหตุ |
| [getParagraphs](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getParagraphs) | จำนวนย่อหน้าทั้งหมด หากมี |
| [getWords](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getWords) | จำนวนคำทั้งหมด |
| [getMultimediaClips](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getMultimediaClips) | จำนวนคลิปเสียงและวิดีโอทั้งหมด |

ตัวอย่างต่อไปนี้อ่านค่าดังกล่าวโดยไม่สร้างออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และพิมพ์สินค้าคงคลังแบบกะทัดรัด นอกจากนี้ยังรวม [getHeadingPairs](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getHeadingPairs) กับ [getTitlesOfParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getTitlesOfParts) เพื่อแสดงกลุ่มเนื้อหา เช่น แบบอักษร ธีม และชื่อสไลด์

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

แต่ละ [HeadingPair](https://reference.aspose.com/slides/th/python-java/aspose.slides/headingpair/) จะให้ชื่อกลุ่มและจำนวนรายการในกลุ่มนั้น [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getTitlesOfParts) จะคืนค่าอาร์เรย์แบนแบบเรียงลำดับ ดังนั้นจึงใช้จำนวนชื่อที่ต่อเนื่องตามที่แต่ละ HeadingPair ระบุ

### **ข้อมูลเมตาที่จัดเก็บและข้อจำกัดของรูปแบบ**

คุณสมบัติสินค้าคงคลังที่คืนโดย [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) สะท้อนเมตาดาต้าที่มีในเอกสารต้นทาง Aspose.Slides จะไม่โหลดและสำรวจโมเดลวัตถุของงานนำเสนอเพื่อคำนวณค่าที่เหล่านี้ใหม่สำหรับการเรียกนี้ คุณสมบัติที่หายไปจะแสดงเป็นค่าดีฟอลต์ และค่าที่จัดเก็บอาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ครั้งสุดท้ายไม่ได้อัปเดตคุณสมบัติเบื้องหลังของเอกสาร  

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเพิ่มเติมของเอกสารสำหรับจำนวนสไลด์, หมายเหตุ, สไลด์ที่ซ่อน, ย่อหน้า, คำและสื่อมัลติมีเดีย รวมถึง heading pairs และ part titles ความพร้อมใช้งานขึ้นอยู่กับว่าผู้ผลิตเอกสารได้เขียนคุณสมบัติใดบ้าง  
- **PPT:** รูปแบบไบนารีสามารถเก็บคุณสมบัติสรุปของเอกสารที่สอดคล้องกัน หากคุณสมบัติเข้าขาดหรือไม่ถูกรีเฟรชโดยผู้ผลิตเอกสาร Aspose.Slides จะคืนค่าที่จัดเก็บหรือค่าดีฟอลต์แทนการคำนวณจากสไลด์  
- **ODP:** เมตาดาต้า OpenDocument ให้สถิติทั่วไปของเอกสาร เช่น จำนวนหน้า, ย่อหน้าและคำ แต่ค่าต่าง ๆ เหล่านี้ไม่สอดคล้องกับคุณสมบัติเพิ่มเติมของ PowerPoint ทั้งหมด เมตาดาต้าสไลด์ที่ซ่อน, สไลด์บันทึกหมายเหตุ, สื่อมัลติมีเดีย, heading-pair และ part-title อาจไม่มีให้บริการ และคุณสมบัติสินค้าคงคลังอาจคืนค่าดีฟอลต์ อย่าใช้ค่าศูนย์หรืออาร์เรย์ว่างเป็นหลักฐานที่แน่ชัดว่ามีเนื้อหาที่สอดคล้องไม่มีอยู่  

ใช้วิธีเมตาดาต้าแบบเบาบางสำหรับสินค้าคงคลังและการตรวจสอบเบื้องต้น โหลดงานนำเสนอและตรวจสอบโมเดลวัตถุที่ทำงานอยู่เมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องการยืนยันเนื้อหาจริงของงานนำเสนอ  

## **อัปเดตคุณสมบัติงานนำเสนอ**

คุณสมบัติที่ได้รับจาก [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) สามารถเปลี่ยนแปลงได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ใช้ [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) เพื่อใช้การเปลี่ยนแปลงแล้วเขียนงานนำเสนอที่ผูกไว้ด้วย [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).  

รูปภาพต่อไปนี้แสดงคุณสมบัติเบื้องหลังของเอกสารต้นฉบับของงานนำเสนอ PowerPoint  
![คุณสมบัติเบื้องหลังเอกสารต้นฉบับของงานนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างต่อไปนี้เปลี่ยนชื่อเรื่องและเวลาการบันทึกล่าสุดและเขียนผลลัพธ์ไปยังไฟล์ใหม่:  

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

รูปภาพต่อไปนี้แสดงคุณสมบัติเบื้องหลังที่เปลี่ยนแปลงของงานนำเสนอ PowerPoint  
![คุณสมบัติเบื้องหลังที่เปลี่ยนแปลงของงานนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยที่เกี่ยวข้องและการตั้งค่าการปกป้อง ดูบทความต่อไปนี้:  

- [การปกป้องงานนำเสนอด้วยรหัสผ่าน](/slides/th/python-java/password-protected-presentation/)  
- [การปกป้องงานนำเสนอจากการเขียน](/slides/th/python-java/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าฟอนต์ถูกฝังไว้และเป็นฟอนต์อะไรบ้าง?**  

โหลดงานนำเสนอและใช้ [Presentation.getFontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getFontsManager) เรียก [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) เพื่อรับฟอนต์ที่ฝังอยู่และ [FontsManager.getFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#getFonts) เพื่อรับฟอนต์ที่งานนำใช้ เปรียบเทียบผลลัพธ์สองชุดเพื่อค้นหาฟอนต์ที่จำเป็นสำหรับการแสดงผลแต่ไม่ได้ฝังไว้  

**ฉันจะตรวจสอบได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และมีจำนวนเท่าไร?**  

เมื่อเมตาดาต้าเอกสารที่จัดเก็บไว้เพียงพอ ให้อ่านข้อความ [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getHiddenSlides) ผ่าน [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) และ [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) วิธีนี้เหมาะสำหรับสินค้าคงคลังแบบเบาบาง หากงานนำเสนอได้รับการแก้ไขในหน่วยความจำ เมตาดาต้าที่จัดเก็บอาจหายหรือเก่า หรือคุณต้องการตรวจสอบค่าปัจจุบัน ให้วนผ่าน [Presentation.getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlides) และตรวจสอบเมธอด [Slide.getHidden](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getHidden) ของแต่ละสไลด์แทน  

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและทิศทางสไลด์ที่กำหนดเองและว่ามันแตกต่างจากค่าเริ่มต้นหรือไม่?**  

ได้เลย โหลดงานนำเสนอและเรียก [Presentation.getSlideSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlideSize) ใช้ [SlideSize.getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/#getSize) และ [SlideSize.getOrientation](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/#getOrientation) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับค่าที่กำหนดไว้ล่วงหน้าและขนาดที่คาดหวัง  

**มีวิธีรวดเร็วในการตรวจสอบว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**  

ได้เลย ค้นหาแต่ละ [Chart](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/) แล้วเรียก [ChartData.getDataSourceType](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getDataSourceType) สำหรับสมุดงานภายนอก ให้เรียก [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ประเภทและเส้นทางของแหล่งข้อมูลบ่งชี้การอ้างอิงภายนอก แต่การตรวจสอบว่ามีเป้าหมายพร้อมใช้งานหรือไม่ต้องทำการตรวจสอบทรัพยากรแยกต่างหาก  

**ฉันจะประเมินสไลด์ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าลงได้อย่างไร?**  

ไม่มีคุณสมบัติความซับซ้อนแบบเดียวที่ใช้ได้ทั้งหมด ให้สำรวจ [Presentation.getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlides) และคอลlection ของ [BaseSlide.getShapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getShapes) ของแต่ละสไลด์ ใช้นับจำนวนรูปร่างและการมีอยู่ของภาพขนาดใหญ่ เอฟเฟกต์ แอนิเมชัน หรือมัลติมีเดียเป็นสัญญาณคัดกรอง และทำการวัดการเรนเดอร์หรือการส่งออกที่เป็นตัวอย่างก่อนที่จะถือว่าสไลด์นั้นเป็นคอขวดประสิทธิภาพที่ยืนยันแล้ว