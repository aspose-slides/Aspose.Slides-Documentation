---
title: ส่งออกงานนำเสนอเป็น XAML ด้วย Python
linktitle: งานนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/python-net/export-to-xaml/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกงานนำเสนอ
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- PowerPoint เป็น XAML
- OpenDocument เป็น XAML
- งานนำเสนอเป็น XAML
- PPT เป็น XAML
- PPTX เป็น XAML
- ODP เป็น XAML
- บันทึก PPT เป็น XAML
- บันทึก PPTX เป็น XAML
- บันทึก ODP เป็น XAML
- ส่งออก PPT เป็น XAML
- ส่งออก PPTX เป็น XAML
- ส่งออก ODP เป็น XAML
- Python
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ด้วย Python โดยใช้ Aspose.Slides—โซลูชันที่รวดเร็ว ไม่ต้องใช้ Office ซึ่งรักษาการจัดวางของคุณไว้ครบถ้วน"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีส่งออกงานนำเสนอ PowerPoint ไปเป็น XAML ด้วย Aspose.Slides รวมถึงการแนะนำสั้น ๆ เกี่ยวกับ XAML แสดงวิธีบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น และสาธิตวิธีปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/), รวมถึงการส่งออกสไลด์ที่ซ่อนไว้ บทความยังตอบคำถามทั่วไปบางข้อที่เกี่ยวกับฟอนต์สำรอง ความเข้ากันได้ของสแต็ก XAML และพฤติกรรมการส่งออกสไลด์ที่ซ่อน

## **เกี่ยวกับ XAML**

XAML เป็นภาษามาร์กอัปที่ใช้ XML เป็นพื้นฐาน ใช้เพื่ออธิบายส่วนติดต่อผู้ใช้ในเฟรมเวิร์กต่าง ๆ เช่น WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin.Forms

คุณสามารถทำงานกับไฟล์ XAML ในเครื่องมือออกแบบเชิงภาพหรือเขียนและแก้ไขมาร์กอัปโดยตรง

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

ตัวอย่าง Python ด้านล่างแสดงวิธีส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

โดยค่าเริ่มต้น สไลด์ที่ส่งออกจะถูกบันทึกในโฟลเดอร์ย่อย `pres` ของไดเรกทอรีทำงานปัจจุบันของกระบวนการ ตามที่ [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd) คืนค่า โฟลเดอร์จะถูกสร้างโดยอัตโนมัติ และรูปภาพที่จำเป็นใด ๆ จะถูกบันทึกไว้ที่นั่นเช่นกัน

ชื่อโฟลเดอร์ผลลัพธ์จะถูกนำมาจากชื่อไฟล์ต้นฉบับโดยไม่มีส่วนขยาย สำหรับ `pres.pptx` ไฟล์ผลลัพธ์จะมีชื่อ `pres/Slide_1.xaml`, `pres/Slide_2.xaml` และต่อไป หากคุณระบุเส้นทางเต็มของไฟล์นำเข้า โฟลเดอร์ผลลัพธ์ก็ยังถูกสร้างแบบสัมพันธ์กับไดเรกทอรีทำงานปัจจุบัน ไม่ได้สร้างเคียงข้างไฟล์ต้นฉบับ

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกกำหนดเอง**

ใช้คลาส [XamlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/) เพื่อควบคุมวิธีที่ Aspose.Slides ส่งออกงานนำเสนอเป็น XAML

เพื่อรวมสไลด์ที่ซ่อนไว้ในผลลัพธ์ XAML ให้ตั้งค่าคุณสมบัติ [export_hidden_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) เป็น `True` ตามตัวอย่าง Python ด้านล่าง:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **รวบรวมศิลปวัตถุ XAML ที่สร้างทั้งหมด**

การส่งออก XAML สามารถสร้างเอกสาร XAML สำหรับแต่ละสไลด์ที่ส่งออกพร้อมกับรูปภาพและทรัพยากรสนับสนุนแยกต่างหาก ให้เก็บไฟล์เหล่านี้ทั้งหมดไว้เมื่อต้องการจัดเก็บหรือส่งต่อการส่งออก

ตัวอย่างด้านล่างใช้ตัวเซฟแบบไฟล์ระบบเริ่มต้นในไดเรกทอรีชั่วคราว แล้วรวบรวมไฟล์ที่สร้าง

### **ทำความเข้าใจวงจรการส่งออก**

- เริ่มการส่งออกด้วยเมธอดเฉพาะ XAML [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) ที่รับพารามิเตอร์ XAML options อ่านไฟล์ที่สร้างขึ้นเฉพาะหลังจากเมธอดคืนค่าด้วยความสำเร็จ
- รักษาเส้นทางสัมพัทธ์ของแต่ละศิลปวัตถุไว้ เพราะ XAML อาจอ้างอิงทรัพยากรด้วยเส้นทางสัมพันธ์
- อ่านศิลปวัตถุเป็นไบต์ รูปภาพและทรัพยากรไบนารีอื่นไม่ควรถอดรหัสเป็นข้อความ
- รายงานความสำเร็จโดยรวมก็ต่อเมื่อตรวจกระบวนการรวบรวมและการจัดเก็บต่อไปเสร็จสมบูรณ์ ให้ข้อผิดพลาดการจัดเก็บส่งกลับไปยังผู้เรียกใช้ และทำความสะอาดผลลัพธ์บางส่วนหากการเก็บถาวรล้มเหลว

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) มีค่าเริ่มต้นเป็น `False` ซึ่งจะไม่รวมเอกสาร XAML ของสไลด์ที่ซ่อนไว้ การตั้งค่าเป็น `True` จะรวมเอกสารเหล่านี้และทรัพยากรที่จำเป็นสำหรับการส่งออก จำนวนทรัพยากรขึ้นกับงานนำเสนอ; อย่าเชื่อว่ามีไฟล์หนึ่งไฟล์ต่อสไลด์

{{% alert color="warning" title="Warning" %}}
ตัวอย่างเหล่านี้จะเปลี่ยนไดเรกทอรีทำงานปัจจุบันของกระบวนการชั่วคราว ซึ่งส่งผลกระทบต่อทุกเธรด ให้เรียกใช้การส่งออกแต่ละครั้งในกระบวนการทำงานแยกเฉพาะ หรือให้แน่ใจว่าไม่มีงานอื่นในกระบวนการที่พึ่งพาไดเรกทอรีปัจจุบันระหว่างการส่งออก ไดเรกทอรีชั่วคราวที่ไม่ซ้ำกันเองไม่ได้ทำให้การส่งออกพร้อมกันในกระบวนการเดียวปลอดภัย
{{% /alert %}}

### **ส่งออกไปยังหน่วยความจำและตรวจสอบศิลปวัตถุ**

ตัวอย่างเต็มนี้โหลด `pres.pptx`, ส่งออกไปยังไดเรกทอรีชั่วคราว, รวบรวมศิลปวัตถุทุกอย่างในพจนานุกรมของชื่อสัมพันธ์และไบต์, แล้วพิมพ์ชื่อ, ประเภท และจำนวนไบต์ของแต่ละรายการ มันยังรักษาโครงสร้างไดเรกทอรีที่สร้างและลบไฟล์ชั่วคราวหลังจากรวบรวมแล้ว เส้นทางเข้าไฟล์จะถูกแก้ก่อนเปลี่ยนไดเรกทอรีทำงาน

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # ถอดรหัสเฉพาะ XAML เท่านั้น และเฉพาะเมื่อจำเป็นต้องตรวจสอบเป็นข้อความ
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

การตรวจสอบนามสกุลไฟล์เป็นประโยชน์สำหรับการตรวจสอบ; เก็บศิลปวัตถุทั้งหมดไว้รวมถึงประเภททรัพยากรที่ไม่คุ้นเคย อย่าปเปลี่ยนไบต์เมื่อจัดเก็บหรือส่งต่อ ให้ถอดรหัส XAML เท่านั้นที่ต้องการการประมวลผลเป็นข้อความ วิธีนี้ใช้พื้นที่ดิสก์ชั่วคราวพร้อมกับหน่วยความจำสำหรับการส่งออกที่รวบรวมไว้

### **บรรจุศิลปวัตถุที่รวบรวมไว้ในไฟล์ ZIP**

ตัวอย่างอิสระนี้รวบรวมการส่งออก, ตรวจสอบความถูกต้องของชื่อ, แล้วเขียนไบต์ดั้งเดิมลงในไฟล์ ZIP ชื่อไฟล์ ZIP ที่ไม่ซ้ำกันจะทำให้การส่งออกแต่ละงานแยกจากกัน รายการใน ZIP ใช้เครื่องหมายทับหน้าและรักษาไดเรกทอรีสัมพันธ์ ชื่อที่ไม่ปลอดภัยหรือชื่อที่ชนกันหลังการทำให้เป็นปกติจะทำให้การบรรจุทั้งหมดถูกปฏิเสธก่อนเขียน

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # ไดเรกทอรี ZIP ได้รับการสรุปก่อนรายงานความสำเร็จ.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

ตัวอย่างใช้ [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) เพื่อเขียนไฟล์ ZIP ส่วนท้องถิ่นหนึ่งไฟล์หลังจากรวบรวมการส่งออกชั่วคราว สำหรับการจัดเก็บระยะไกล ให้แทนขั้นตอนการเขียนไฟล์ ZIP ด้วยการอัปโหลดไบต์ที่รวบรวม ใช้รหัสงานส่งออกพร้อมชื่อศิลปวัตถุสัมพันธ์ทั้งหมดเป็นคีย์ของอ็อบเจกต์ หรือเก็บรหัสงาน, ชื่อสัมพันธ์, และข้อมูลไบต์ในแถวฐานข้อมูล เผยแพร่งานหลังจากการอัปโหลดทั้งหมดเสร็จหรือธุรกรรมฐานข้อมูลคอมมิตแล้ว ทำความสะอาดผลลัพธ์บางส่วนหากการเก็บถาวรล้มเหลว

สำหรับงานนำเสนอขนาดใหญ่ ให้ประมวลผลไฟล์ชั่วคราวทีละไฟล์หลังการส่งออกแทนการรวบรวมไบต์ทั้งหมดในพจนานุกรม วิธีนี้ช่วยหลีกเลี่ยงการสำเนาในหน่วยความจำของการส่งออกทั้งหมดเพิ่มเติม แต่ไม่ได้ลดความต้องการหน่วยความจำของตัวส่งออกเอง

### **รักษาชื่อทรัพยากรและตรวจสอบการอ้างอิง**

- ทำให้เครื่องหมายแยกเส้นทางเป็นมาตรฐานเมื่อจุดหมายต้องการ แต่ให้รักษาไดเรกทอรีสัมพันธ์ อย่าเก็บเพียงชื่อไฟล์สุดท้าย เว้นแต่จะมั่นใจว่าชื่อที่สร้างทั้งหมดเป็นเอกลักษณ์และการอ้างอิงทรัพยากรยังคงถูกต้อง
- ใช้การตรวจสอบชื่อเฉพาะจุดหมาย เมื่อต้องเขียนไฟล์แยก ให้ปฏิเสธเส้นทางเต็มและส่วนที่ขึ้นไปข้างบน, ตรวจสอบจุดหมายให้แน่ใจว่าอยู่ภายใต้ไดเรกทอรีส่งออกที่ตั้งใจ ใช้ไดเรกทอรีที่แอปควบคุมโดยไม่มีลิงก์สัญลักษณ์ที่อาจเปลี่ยนเส้นทางการเขียน
- ใช้เนมสเปซการจัดเก็บแยกสำหรับแต่ละงานส่งออก ตรวจจับการชนกันหลังทำให้เครื่องหมายแยกเส้นทางเป็นมาตรฐานและตามกฎความแตกต่างตัวพิมพ์ของจุดหมาย
- ก่อนเผยแพร่ ให้พาร์สเอกสาร XAML แต่ละไฟล์เป็น XML แล้วตรวจสอบการอ้างอิงทรัพยากรแบบไฟล์ เช่น แอตทริบิวต์ `Source` หรือ `ImageSource` ของรูปภาพ แก้ไข URI สัมพัทธ์แต่ละอันกับไดเรกทอรีของศิลปวัตถุ XAML ที่เกี่ยวข้อง ทำให้ชื่อการจัดเก็บที่ได้เป็นมาตรฐานและยืนยันว่าคีย์พจนานุกรม, รายการ ZIP หรืออ็อบเจกต์ที่เก็บอยู่มีอยู่จริง แยกการจัดการ URI ภายนอกและนิพจน์มาร์กอัป XAML ออกจากชื่อไฟล์สัมพันธ์

ตัวอย่างเช่น หาก `pres/Slide_1.xaml` อ้างอิง `images/image1.png` ทรัพยากรที่เก็บไว้ต้องมีที่ `pres/images/image1.png` การเก็บเพียง `image1.png` จะทำให้ความสัมพันธ์นี้ขาดหาย สำหรับการจัดเก็บเป็นอ็อบเจกต์ ให้รักษาโครงสร้างเดียวกันภายใต้คำนำหน้างานและทำให้ URL ของทรัพยากรเหล่านั้นเข้าถึงได้โดยผู้ใช้ XAML เปิด ZIP ที่สร้างเสร็จแล้วเพื่อตรวจสอบชื่อรายการและไบต์ของทรัพยากร แล้วโหลดสไลด์ตัวอย่างในสภาพแวดล้อม XAML เป้าหมายเพื่อยืนยันว่ารูปภาพถูกแก้ได้อย่างถูกต้อง

## **คำถามที่พบบ่อย**

**ฉันจะทำให้แน่ใจว่าฟอนต์คาดการณ์ได้หากฟอนต์ต้นฉบับไม่มีในเครื่องอย่างไร?**

ตั้งค่า [default_regular_font](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) ใน [XamlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/) — ฟอนต์นี้จะถูกใช้เป็นฟอนต์สำรองระหว่างการส่งออกเมื่อฟอนต์ต้นฉบับหายไป อย่างไรก็ตาม สิ่งนี้ไม่ได้รับประกันว่า XAML ที่สร้างจะอ้างอิงฟอนต์สำรองหรือว่าฟอนต์นั้นมีในเครื่องเป้าหมาย ตรวจสอบให้แน่ใจว่าฟอนต์ที่ XAML อ้างอิงมีอยู่ในสภาพแวดล้อมที่จะแสดงผล

**XAML ที่ส่งออกออกแบบมาสำหรับ WPF เท่านั้นหรือสามารถใช้ในสแต็ก XAML อื่นได้ด้วย?**

Aspose.Slides ส่งออก XAML ของ WPF ผ่าน API สาธารณะของมัน ความเข้ากันได้กับสแต็ก XAML อื่น ๆ เช่น UWP และ Xamarin.Forms ไม่ได้รับการรับประกัน ควรทดสอบมาร์กอัปที่สร้างในสภาพแวดล้อมเป้าหมายของคุณ

**สไลด์ที่ซ่อนไว้ได้รับการสนับสนุนหรือไม่ และจะป้องกันไม่ให้ส่งออกโดยค่าเริ่มต้นได้อย่างไร?**

โดยค่าเริ่มต้น สไลด์ที่ซ่อนไว้จะไม่ถูกรวม คุณสามารถควบคุมพฤติกรรมนี้ได้ผ่าน [export_hidden_slides](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) ใน [XamlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export.xaml/xamloptions/) — ปิดฟีเจอร์นี้หากไม่ต้องการส่งออกสไลด์ที่ซ่อนไว้