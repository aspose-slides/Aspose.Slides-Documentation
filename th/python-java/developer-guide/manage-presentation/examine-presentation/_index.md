---
title: ดึงและอัปเดตข้อมูลงานนำเสนอใน Python ผ่าน Java
linktitle: ข้อมูลงานนำเสนอ
type: docs
weight: 30
url: /th/python-java/examine-presentation/
keywords:
- รูปแบบงานนำเสนอ
- คุณสมบัติงานนำเสนอ
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
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สำรวจสไลด์, โครงสร้างและเมทาดาตาในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Python ผ่าน Java เพื่อให้ได้ข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ฉลาดขึ้น."
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของงานนำเสนอและอ่านเมทาดาทาเอกสารโดยไม่ต้องสร้างโมเดลวัตถุของงานนำเสนอทั้งหมด ซึ่งมีประโยชน์เมื่อคุณต้องการจัดประเภทไฟล์, สร้างรายการสินค้าคงคลัง, หรือ ตรวจสอบคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหาของงานนำเสนอหรือไม่

ตัวอย่างต้องการ Aspose.Slides สำหรับ Python ผ่าน Java และ Java runtime ที่เข้ากันได้ แต่ละตัวอย่างจะเริ่ม JVM หากยังไม่ได้ทำงาน ให้จัดเตรียมไฟล์งานนำเสนอที่มีอยู่ตามเส้นทางที่ใช้ในตัวอย่าง

บทความนี้แสดงการตรวจสอบแบบเบาโดยใช้ [PresentationFactory](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/) และ [PresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/), รวมถึงการอัปเดตแบบเจาะจงโดยใช้ [DocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/).

## **ตรวจสอบรูปแบบของงานนำเสนอ**

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เมธอด [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#getLoadFormat) รายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP

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

## **สร้างสินค้าคงคลังงานนำเสนอแบบเบา**

เมื่อคุณประมวลผลไฟล์งานนำเสนอจำนวนมาก คุณอาจต้องการรายการสินค้าคงคลังที่กะทัดรัดสำหรับการตรวจสอบ, การทำดัชนี, หรือระบบจัดการเอกสาร ในสถาณการณ์นี้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) เพื่อรับอ็อบเจกต์ [PresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/) แล้วเรียก [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) เพื่ออ่านเมทาดาทาเอกสาร วิธีการนี้ไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) หรือบังคับให้คุณเดินทางผ่านโมเดลวัตถุของงานนำเสนอทั้งหมด

คุณสมบัติขยายที่เปิดเผยโดย [DocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/) ให้ค่าต่อไปนี้สำหรับรายการสินค้าคงคลัง:

| เมธอด | ค่าที่บันทึก |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getSlides) | จำนวนสไลด์ทั้งหมด. |
| [getHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getHiddenSlides) | จำนวนสไลด์ที่ซ่อนอยู่. |
| [getNotes](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getNotes) | จำนวนสไลด์ที่มีโน้ต. |
| [getParagraphs](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getParagraphs) | จำนวนย่อหน้าทั้งหมด (หากมี). |
| [getWords](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getWords) | จำนวนคำทั้งหมด. |
| [getMultimediaClips](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getMultimediaClips) | จำนวนคลิปเสียงและวิดีโอทั้งหมด. |

ตัวอย่างต่อไปนี้อ่านค่าดังกล่าวโดยไม่สร้างอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และพิมพ์รายการสินค้าคงคลังแบบกะทัดรัด นอกจากนี้ยังรวม [getHeadingPairs](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getHeadingPairs) กับ [getTitlesOfParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getTitlesOfParts) เพื่อแสดงกลุ่มเนื้อหาเช่นแบบอักษร, ธีม, และชื่อสไลด์

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

แต่ละ [HeadingPair](https://reference.aspose.com/slides/th/python-java/aspose.slides/headingpair/) จะให้ชื่อกลุ่มและจำนวนรายการในกลุ่มนั้น [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getTitlesOfParts) คืนค่าเป็นอาเรย์แบนแบบเรียงลำดับ ดังนั้นให้ใช้จำนวนชื่อที่ต่อเนื่องตามที่ระบุโดยแต่ละ heading pair

### **เมตาดาทาที่เก็บไว้และข้อจำกัดของรูปแบบ**

คุณสมบัติสต็อกที่คืนค่าจาก [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) สะท้อนเมทาดาทาที่มีในเอกสารต้นทาง Aspose.Slides ไม่โหลดและเดินผ่านโมเดลวัตถุของงานนำเสนอเพื่อคำนวนค่าใหม่สำหรับการเรียกนี้ คุณสมบัติที่หายไปจะแสดงเป็นค่าตั้งต้น และค่าที่เก็บไว้อาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ครั้งสุดท้ายไม่ได้อัปเดตคุณสมบัติเข้าของเอกสาร

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเพิ่มเติมของเอกสารสำหรับจำนวนสไลด์, โน้ต, สไลด์ที่ซ่อน, ย่อหน้า, คำ, และสื่อมัลติมีเดีย รวมถึง heading pairs และ part titles ความพร้อมใช้งานขึ้นกับว่าผู้ผลิตเอกสารเขียนคุณสมบัตินั้นไว้หรือไม่
- **PPT:** รูปแบบไบนารีสามารถเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องกันได้ หากคุณสมบัติเก отсутств หรือไม่ได้รับการรีเฟรชจากผู้ผลิตเอกสาร Aspose.Slides จะคืนค่าที่เก็บไว้หรือค่าตั้งต้นแทนการคำนวนจากสไลด์
- **ODP:** เมทาดาทา OpenDocument ให้สถิติเอกสารทั่วไปเช่นจำนวนหน้า, ย่อหน้า, และคำ แต่ค่าดังกล่าวไม่สอดคล้องกับคุณสมบัติเพิ่มเติมเฉพาะ PowerPoint ทุกประการ เมทาดาทาเกี่ยวกับสไลด์ที่ซ่อน, โน้ตสไลด์, สื่อมัลติมีเดีย, heading‑pair, และ part‑title อาจไม่มีอยู่และคุณสมบัติรายการอาจคืนค่าตั้งต้น อย่าพิจารณาค่าศูนย์หรืออาเรย์ว่างเป็นหลักฐานที่แน่นอนว่าหัวข้อดังกล่าวไม่มีอยู่

ใช้วิธีเมทาดาทาแบบเบาสำหรับการสร้างรายการและการตรวจสอบเบื้องต้น โหลดงานนำเสนอและตรวจสอบโมเดลวัตถุแบบสดเมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องการตรวจสอบเนื้อหาจริงของงานนำเสนอ

## **อัปเดตคุณสมบัติงานนำเสนอ**

คุณสมบัติที่คืนค่าจาก [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) สามารถเปลี่ยนแปลงได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ใช้การเปลี่ยนแปลงด้วย [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) แล้วเขียนงานนำเสนอที่ผูกไว้ด้วย [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#writeBindedPresentation)

รูปภาพต่อไปนี้แสดงคุณสมบัติเอกสารดั้งเดิมของงานนำเสนอ PowerPoint

![Original document properties of the PowerPoint presentation](input_properties.png)

ตัวอย่างต่อไปนี้เปลี่ยนชื่อเรื่องและเวลาบันทึกล่าสุดแล้วเขียนผลลัพธ์ลงไฟล์ใหม่:

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

รูปภาพต่อไปนี้แสดงคุณสมบัติเอกสารที่อัปเดตของงานนำเสนอ PowerPoint

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยที่เกี่ยวข้องและการตั้งค่าการป้องกัน ดูบทความต่อไปนี้:

- [Password‑Protect Presentations](/slides/th/python-java/password-protected-presentation/)
- [Write‑Protect Presentations](/slides/th/python-java/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าแบบอักษรถูกฝังไว้หรือไม่และแบบอักษรใดบ้าง?**

โหลดงานนำเสนอและใช้ [Presentation.getFontsManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getFontsManager) เรียก [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) เพื่อรับแบบอักษรที่ฝังไว้และ [FontsManager.getFonts](https://reference.aspose.com/slides/th/python-java/aspose.slides/fontsmanager/#getFonts) เพื่อรับแบบอักษรที่งานนำเสนอใช้ เปรียบเทียบผลลัพธ์สองชุดเพื่อหาชนิดแบบอักษรที่จำเป็นสำหรับการแสดงผลแต่ไม่ได้ฝังไว้

**ฉันจะทราบได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไร?**

เมื่อเมทาดาทาเอกสารที่เก็บไว้เพียงพอ ให้เรียก [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getHiddenSlides) ผ่าน [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) และ [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) วิธีนี้เหมาะสำหรับรายการสินค้าคงคลังแบบเบา หากงานนำเสนอถูกแก้ไขในหน่วยความจำเมทาดาทาที่เก็บไว้อาจหายหรือล้าสมัย หรือหากต้องการตรวจสอบค่าที่ใช้งานจริง ให้วนลูปผ่าน [Presentation.getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlides) และตรวจสอบเมธอด [Slide.getHidden](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getHidden) ของแต่ละสไลด์แทน

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดสไลด์และการจัดแนวที่กำหนดเองหรือไม่ และว่ามันแตกต่างจากค่าเริ่มต้นหรือไม่?**

ได้ โหลดงานนำเสนอและเรียก [Presentation.getSlideSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlideSize) ใช้ [SlideSize.getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/#getSize) และ [SlideSize.getOrientation](https://reference.aspose.com/slides/th/python-java/aspose.slides/slidesize/#getOrientation) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับค่าพรีเซ็ตและมิติที่คาดหวัง

**มีวิธีที่เร็วในการตรวจสอบว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ได้ ค้นหากราฟแต่ละอันด้วย [Chart](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/) แล้วเรียก [ChartData.getDataSourceType](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getDataSourceType) หากเป็นเวิร์กบุ๊กภายนอก ให้เรียก [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ประเภทแหล่งข้อมูลและเส้นทางจะบ่งบอกถึงการอ้างอิงภายนอก แต่การตรวจสอบว่าเป้าหมายพร้อมใช้งานต้องทำการตรวจสอบทรัพยากรแยกต่างหาก

**ฉันจะประเมินสไลด์ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออก PDF ช้าได้อย่างไร?**

ไม่มีคุณสมบัติความซับซ้อนแบบเดียว ให้เดินผ่าน [Presentation.getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlides) และคอลเลกชัน [BaseSlide.getShapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getShapes) ของแต่ละสไลด์ ใช้จำนวนรูปร่างและการมีอยู่ของรูปภาพขนาดใหญ่, เอฟเฟกต์, แอนิเมชัน หรือสื่อมัลติมีเดียเป็นสัญญาณคัดกรอง และอาจทำการเรนเดอร์หรือส่งออกตัวอย่างเพื่อวัดประสิทธิภาพก่อนสรุปว่าสไลด์เป็นคอขวดของประสิทธิภาพอย่างแน่นอน