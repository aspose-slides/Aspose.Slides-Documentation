---
title: ส่งออกงานนำเสนอเป็น XAML ใน Python ผ่าน Java
linktitle: งานนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/python-java/export-to-xaml/
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
- Java
- Aspose.Slides
description: ส่งออกงานนำเสนอ PowerPoint และ OpenDocument เป็น XAML ด้วย Aspose.Slides สำหรับ Python ผ่าน Java ใช้ตัวเลือกเริ่มต้นหรือรวมสไลด์ที่ซ่อนอยู่
---
## **ภาพรวม**

บทความนี้อธิบายวิธีส่งออกงานนำเสนอ PowerPoint ไปเป็น XAML โดยใช้ Aspose.Slides for Python via Java รวมถึงการแนะนำสั้น ๆ เกี่ยวกับ XAML แสดงวิธีบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น และสาธิตวิธีปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/), รวมถึงการส่งออกสไลด์ที่ซ่อนอยู่ บทความยังให้คำตอบกับคำถามทั่วไปบางข้อเกี่ยวกับฟอนต์สำรอง, ความเข้ากันได้ของสแตก XAML, และพฤติกรรมการส่งออกสไลด์ที่ซ่อนอยู่

ตัวอย่างต้องการ Aspose.Slides for Python via Java และ Java runtime ที่เข้ากันได้ วางไฟล์ `pres.pptx` ในไดเรกทอรีทำงานปัจจุบัน แต่ละตัวอย่างจะเปิด JVM หากยังไม่ได้เปิดอยู่

## **เกี่ยวกับ XAML**

XAML คือภาษา markup ที่อิง XML ใช้เพื่ออธิบายส่วนต่อประสานผู้ใช้ในเฟรมเวิร์กต่าง ๆ เช่น WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) และ Xamarin.Forms

คุณสามารถทำงานกับไฟล์ XAML ในเครื่องมือออกแบบภาพ หรือเขียนและแก้ไข markup โดยตรง

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

ตัวอย่าง Python ต่อไปนี้แสดงวิธีส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

โดยค่าเริ่มต้น สไลด์ที่ส่งออกจะถูกบันทึกในโฟลเดอร์ย่อย `pres` ของไดเรกทอรีทำงานปัจจุบันของกระบวนการ โฟลเดอร์จะถูกสร้างโดยอัตโนมัติและรูปภาพที่จำเป็นจะถูกบันทึกไว้ในนั้นเช่นกัน

ชื่อโฟลเดอร์ผลลัพธ์จะมาจากชื่อไฟล์ต้นทางโดยไม่มีส่วนขยาย สำหรับไฟล์ `pres.pptx` ไฟล์ผลลัพธ์จะมีชื่อเป็น `pres/Slide_1.xaml`, `pres/Slide_2.xaml` เป็นต้น แม้ว่าคุณจะระบุพาธแบบสมบูรณ์ของงานนำเข้าก็ตาม โฟลเดอร์ผลลัพธ์จะถูกสร้างสัมพันธ์กับไดเรกทอรีทำงานปัจจุบัน ไม่ได้สร้างอยู่เคียงไฟล์ต้นทาง

## **ส่งออกงานนำเสนอเป็น XAMLด้วยตัวเลือกกำหนดเอง**

ใช้คลาส [XamlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/) เพื่อควบคุมวิธีที่ Aspose.Slides ส่งออกงานนำเสนอเป็น XAML

เพื่อบันทึกผลลัพธ์ลงในตำแหน่งที่กำหนดเอง ให้ทำการ implement `IXamlOutputSaver` และส่งออบเจกต์ของการ implement ของคุณไปยังเมธอด [setOutputSaver](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/#setOutputSaver) ของ [XamlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/)

เพื่อรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ XAML ให้เรียก [setExportHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) พร้อมค่า `True` อย่างที่แสดงในตัวอย่าง Python ต่อไปนี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **บันทึกศิลปะ XAML ทั้งหมดที่สร้างขึ้น**

การส่งออก XAML สามารถสร้างเอกสาร XAML แยกสำหรับแต่ละสไลด์ที่ส่งออกพร้อมกับรูปภาพและทรัพยากรสนับสนุนอื่น ๆ กำหนด `IXamlOutputSaver` ปรับแต่งให้กับ [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/#setOutputSaver) เพื่อรับศิลปะเหล่านี้แทนการใช้ตัวบันทึกไฟล์ระบบเริ่มต้น เริ่มการส่งออกด้วย overload ของ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ที่รับ XAML options

ใน Python ใช้ `jpype.JProxy` เพื่อ implement อินเตอร์เฟส Java `IXamlOutputSaver` แปลงพาธ callback เป็น `str` และคัดลอกอาเรย์ไบต์ของ Java เป็น `bytes` ของ Python ก่อนคืนค่า ตามที่แสดงด้านล่าง

### **ทำความเข้าใจวงจรชีวิตของ Callback**

ตัวส่งออกจะเรียก `IXamlOutputSaver.save` แยกต่างหากสำหรับแต่ละศิลปะที่สร้างขึ้น:

- `path` ระบุศิลปะและอาจรวมไดเรกทอรีสัมพันธ์ เก็บข้อมูลนี้ไว้เพราะ XAML อาจอ้างอิงทรัพยากรโดยใช้พาธสัมพันธ์
- `data` มีไบต์ของศิลปะ รูปภาพและทรัพยากรไบนารีอื่น ๆ ต้องไม่ถูกถอดรหัสเป็นข้อความ
- ตัวบันทึกรับผิดชอบการเก็บหรือคงข้อมูลไว้ก่อนคืนค่า ตัวอย่างจะคัดลอกแต่ละอาเรย์ไบต์ไปยังหน่วยความจำของแอปพลิเคชัน
- ถือว่าการส่งออกสำเร็จก็ต่อเมื่อเมธอดบันทึกงานนำเสนอคืนค่าและทุก callback ทำงานสำเร็จ อย่าดมความผิดพลาดของการจัดเก็บหรือเริ่มการเขียนเบื้องหลังโดยไม่ได้ตรวจสอบ หากการคงข้อมูลเกิดขึ้นหลังจากนั้น ให้รายงานความสำเร็จโดยรวมเฉพาะเมื่อตอนนั้นสำเร็จด้วย

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) ยังใช้กับ saver ที่กำหนดเองด้วย ค่าเริ่มต้น `False` จะยกเว้นเอกสาร XAML ของสไลด์ที่ซ่อนอยู่ การกำหนดค่า `True` จะรวมสไลด์เหล่านี้และทรัพยากรที่จำเป็นสำหรับการส่งออก จำนวนทรัพยากรขึ้นกับงานนำเสนอ; อย่าสมมติว่าแต่ละสไลด์มี callback หนึ่งหรือมีลำดับ callback คงที่

### **ส่งออกไปยังหน่วยความจำและตรวจสอบศิลปะ**

ตัวอย่างสมบัตินี้โหลด `pres.pptx`, รวบรวมศิลปะทั้งหมดในพจนานุกรม Python ที่มีชื่อและค่า `bytes` ที่ไม่เปลี่ยนแปลง, แล้วพิมพ์ชื่อ, ชนิด, และจำนวนไบต์ของแต่ละรายการ เก็บชื่อที่กำหนดไว้โดยตรง ชื่อที่ซ้ำจะทำให้การรวบรวมเป็นข้อมูลไม่ถูกต้องแทนการเขียนทับโดยเงียบ ตัวอย่างตรวจสอบสิ่งนี้ก่อนใช้ผลลัพธ์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # ถอดรหัสเฉพาะ XAML และเฉพาะเมื่อจำเป็นต้องตรวจสอบข้อความ.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

การตรวจสอบนามสกุลไฟล์มีประโยชน์สำหรับการตรวจสอบ; เก็บศิลปะทั้งหมดรวมถึงประเภททรัพยากรที่ไม่ได้คุ้นเคย อย่ากระทำการเปลี่ยนแปลงไบต์เมื่อเก็บหรือส่งต่อ ใช้ `bytes.decode` กับ UTF-8 เฉพาะสำหรับ XAML ที่ต้องการการประมวลผลข้อความ

### **บรรจุศิลปะที่รวบรวมในไฟล์ ZIP**

ตัวอย่างอิสระนี้รวบรวมการส่งออก, ตรวจสอบชื่อ, และเขียนไบต์ดั้งเดิมลงในไฟล์ ZIP ชื่อไฟล์ ZIP ที่ไม่ซ้ำกันจะแยกงานส่งออกที่ทำพร้อมกัน รายการใน ZIP ใช้สแลชและเก็บไดเรกทอรีสัมพันธ์ ชื่อที่ไม่ปลอดภัยหรือชื่อที่ชนกันหลังจากการทำให้เป็นมาตรฐานจะทำให้แพ็คเกจทั้งหมดถูกปฏิเสธก่อนเขียน

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # การปิดไฟล์จะสรุปไดเรกทอรี ZIP ก่อนที่จะรายงานความสำเร็จ.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

ตัวอย่างใช้ `zipfile.ZipFile` ของ Python เพื่อเขียนไฟล์เก็บถาวรหนึ่งไฟล์; ตัวส่งออกเองไม่เขียนไฟล์ XAML หรือรูปภาพแยก หากต้องการจัดเก็บระยะไกล ให้แทนขั้นตอนการเขียนไฟล์ด้วยการอัปโหลดอาเรย์ไบต์ที่รวบรวม ใช้รหัสงานส่งออกบวกกับชื่อศิลปะสัมพันธ์เต็มเป็นคีย์บล็อบ, หรือเก็บรหัสงาน, ชื่อสัมพันธ์, และข้อมูลไบต์ในแถวฐานข้อมูล เผยแพร่งานเฉพาะหลังจากอัปโหลดทั้งหมดเสร็จหรือการทำธุรกรรมฐานข้อมูลคอมมิท ทำความสะอาดเอาต์พุตบางส่วนหากการคงข้อมูลล้มเหลว

สำหรับงานนำเสนอขนาดใหญ่ saver ที่กำหนดเองสามารถคงศิลปะแต่ละรายการโดยตรงลงในที่เก็บของแอปพลิเคชันเพื่อหลีกเลี่ยงการเก็บสำเนาเพิ่มเติมของการส่งออกทั้งหมดในหน่วยความจำของแอปพลิเคชัน เก็บ callback ให้ทำงานแบบซิงโครนัสจากมุมมองของตัวส่งออก: คืนค่าเฉพาะเมื่อตำแหน่งปลายทางรับไบต์แล้ว, และให้ความล้มเหลวถึงผู้เรียกใช้

### **คงชื่อทรัพยากรและตรวจสอบการอ้างอิง**

- ทำให้ตัวคั่นพาธเป็นมาตรฐานเมื่อจุดหมายต้องการ, แต่คงไดเรกทอรีสัมพันธ์ อย่าใช้เฉพาะ `pathlib.Path.name` เว้นแต่ชื่อที่สร้างทุกชื่อจะเป็นเอกลักษณ์และการอ้างอิงทรัพยากรยังคงถูกต้อง
- ใช้การตรวจสอบชื่อเฉพาะจุดหมาย เมื่อเขียนไฟล์แยก ให้ปฏิเสธพาธที่เริ่มต้นด้วยรูทและส่วนที่เดินทางย้อนกลับ, แก้จุดหมายด้วย `pathlib.Path.resolve`, และตรวจสอบให้แน่ใจว่ามันอยู่ภายใต้ไดเรกทอรีส่งออกที่กำหนด, รวมตัวคั่นไดเรกทอรีในการตรวจสอบการครอบครอง ใช้ไดเรกทอรีที่แอปพลิเคชันควบคุมโดยไม่มีลิงก์สัญลักษณ์ที่อาจเปลี่ยนเส้นทางการเขียน
- ใช้ saver และเนมสเปซการจัดเก็บแยกแต่ละงานส่งออก ตรวจจับการชนกันหลังจากทำให้ตัวคั่นเป็นมาตรฐานและตามกฎความไวต่อกรณีของจุดหมาย
- ก่อนเผยแพร่ ให้พาร์สแต่ละเอกสาร XAML เป็น XML และตรวจสอบการอ้างอิงทรัพยากรที่อิงไฟล์ เช่น แอตทริบิวต์ `Source` หรือ `ImageSource` ของรูปภาพ แก้ URI สัมพัทธ์แต่ละรายการเทียบกับไดเรกทอรีของศิลปะ XAML ที่บรรจุ, ทำให้ชื่อการจัดเก็บที่ได้เป็นมาตรฐาน, และยืนยันว่าคีย์แมพที่สอดคล้อง, รายการ ZIP, หรืออ็อบเจกต์ที่จัดเก็บมีอยู่ ถือ URI ภายนอกและนิพจน์ markup XAML แยกต่างหากจากชื่อไฟล์สัมพันธ์

เช่น หาก `pres/Slide_1.xaml` อ้างอิง `images/image1.png`, ทรัพยากรที่จัดเก็บต้องมีอยู่เป็น `pres/images/image1.png` การเก็บเฉพาะ `image1.png` จะทำให้ความสัมพันธ์นี้เสียหาย สำหรับการจัดเก็บออบเจกต์, คงโครงสร้างเดียวกันใต้พรีฟิกซ์งานและทำให้ URL ของทรัพยากรเหล่านั้นเข้าถึงได้สำหรับผู้ใช้ XAML เปิดไฟล์ ZIP ที่เสร็จแล้วเพื่อตรวจสอบชื่อรายการและไบต์ของทรัพยากร, แล้วโหลดสไลด์ตัวอย่างในสภาพแวดล้อม XAML เป้าหมายเพื่อยืนยันว่ารูปภาพถูกแก้ไขอย่างถูกต้อง

## **คำถามที่พบบ่อย**

**ฉันจะทำอย่างไรให้ฟอนต์คาดการณ์ได้เมื่อฟอนต์ต้นทางไม่มีในเครื่อง?**

เรียกใช้ [setDefaultRegularFont](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) ใน [XamlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/) — ฟอนต์นี้จะถูกใช้เป็นฟอนต์สำรองในระหว่างการส่งออกเมื่อฟอนต์ต้นทางหายไป อย่างไรก็ตามไม่รับประกันว่า XAML ที่สร้างจะอ้างอิงฟอนต์สำรองหรือว่าฟอนต์นั้นมีในเครื่องเป้าหมาย ตรวจสอบให้แน่ใจว่าฟอนต์ที่ XAML อ้างอิงมีอยู่ในสภาพแวดล้อมที่จะแสดงผล

**XAML ที่ส่งออกออกแบบมาสำหรับ WPF เท่านั้นหรือสามารถใช้ในสแตก XAML อื่นได้ด้วย?**

Aspose.Slides ส่งออก XAML ของ WPF ผ่าน API สาธารณะของมัน ความเข้ากันได้กับสแตก XAML อื่น ๆ เช่น UWP และ Xamarin.Forms ไม่ได้รับการรับประกัน ควรทดสอบ markup ที่สร้างขึ้นในสภาพแวดล้อมเป้าหมายของคุณ

**สไลด์ที่ซ่อนอยู่ได้รับการสนับสนุนหรือไม่, และฉันจะป้องกันไม่ให้มันถูกส่งออกโดยค่าเริ่มต้นได้อย่างไร?**

โดยค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ถูกรวม คุณสามารถควบคุมพฤติกรรมนี้ได้ผ่าน [setExportHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) ใน [XamlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/xamloptions/) — ปิดการใช้งานหากคุณไม่ต้องการส่งออกสไลด์ที่ซ่อนไว้.