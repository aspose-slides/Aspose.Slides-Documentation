---
title: กำหนดรูปแบบพรีเซนเทชันต้นฉบับใน Python ผ่าน Java
linktitle: รูปแบบแหล่งที่มา
type: docs
weight: 35
url: /th/python-java/detect-presentation-source-format/
keywords:
- รูปแบบแหล่งที่มา
- ตรวจจับรูปแบบพรีเซนเทชัน
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "อ่านรูปแบบต้นฉบับของพรีเซนเทชันที่โหลดใน Python ผ่าน Java ด้วย Aspose.Slides for Python via Java, เปรียบเทียบ API การตรวจจับ, และจัดการไฟล์, สตรีม, และรูปแบบรุ่นเก่า."
---
## **ภาพรวม**

หลังจากโหลดพรีเซนเทชันแล้ว ให้เรียกใช้เมธอด [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSourceFormat) เพื่อกำหนดรูปแบบเดิมของมัน ใช้เมธอดนี้เมื่อการประมวลผลต่อไปขึ้นอยู่กับรูปแบบที่อินสแตนซ์ปัจจุบันถูกโหลดมา

รูปแบบแหล่งที่มานั้นแตกต่างจาก [SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/) ที่เลือกสำหรับไฟล์ผลลัพธ์ การบันทึกเป็นรูปแบบอื่นจะไม่เปลี่ยนรูปแบบแหล่งที่มาของอินสแตนซ์ที่มีอยู่

ตัวอย่างเหล่านี้ต้องใช้ Aspose.Slides for Python via Java และ Java runtime ที่เข้ากันได้ แต่ละตัวอย่างจะเริ่ม JVM หากยังไม่ได้รันอยู่

## **อ่านรูปแบบแหล่งที่มาของไฟล์**

ตัวอย่างนี้ต้องอ้างอิงไฟล์ `sample.pptx` ที่มีอยู่แล้ว มันโหลดไฟล์และเลือกนโยบายการประมวลผลของแอปพลิเคชันโดยใช้ [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSourceFormat) แทนการใช้ชื่อไฟล์ เปลี่ยนเส้นทางอินพุตเพื่อทดลองรูปแบบอื่น ตัวอย่างจะแสดงนโยบายที่เลือก; ให้แทนข้อความเหล่านี้ด้วยตรรกะของแอปพลิเคชันของคุณ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **ระบุค่าที่รองรับ**

คลาส [SourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/sourceformat/) กำหนดค่าคงที่จำนวนเต็มที่แยกรูปแบบพรีเซนเทชันต่อไปนี้ ส่วนต่อขยายด้านล่างเป็นส่วนต่อขยายแบบทั่วไป ไม่ได้สร้างใหม่จากชื่อไฟล์เดิม

| ค่าของ SourceFormat | ส่วนต่อขยาย | รูปแบบ |
| --- | --- | --- |
| `Ppt` | `.ppt` | การนำเสนอ PowerPoint 97–2003 |
| `Pptx` | `.pptx` | การนำเสนอ Office Open XML |
| `Pptm` | `.pptm` | การนำเสนอ Office Open XML ที่เปิดใช้งานแมโคร |
| `Pps` | `.pps` | สไลด์โชว์ PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | สไลด์โชว์ Office Open XML |
| `Ppsm` | `.ppsm` | สไลด์โชว์ Office Open XML ที่เปิดใช้งานแมโคร |
| `Pot` | `.pot` | เทมเพลต PowerPoint 97–2003 |
| `Potx` | `.potx` | เทมเพลต Office Open XML |
| `Potm` | `.potm` | เทมเพลต Office Open XML ที่เปิดใช้งานแมโคร |
| `Odp` | `.odp` | การนำเสนอ OpenDocument |
| `Otp` | `.otp` | เทมเพลตการนำเสนอ OpenDocument |
| `Fodp` | `.fodp` | การนำเสนอ Flat XML ODF |
| `Xml` | `.xml` | การนำเสนอ PowerPoint XML |

## **อ่านรูปแบบแหล่งที่มาจากสตรีม**

ตัวอย่างนี้ต้องอ้างอิงไฟล์ `sample.pps` ที่มีอยู่ การอ่านไบต์ของไฟล์เข้ามาในสตรีมหน่วยความจำจำลองการรับข้อมูลโดยไม่มีชื่อไฟล์ เช่น ค่าจากฐานข้อมูลหรืออาร์เรย์ไบต์ที่อัปโหลด คอนสตรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) รับเพียงสตรีม Python อ่านไบต์ไฟล์และ JPype แปลงเป็นอาร์เรย์ไบต์ของ Java สำหรับสตรีมหน่วยความจำของ Java

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS และ POT ใช้รูปแบบไบนารีพื้นฐานเดียวกัน เมื่อโหลดโดยพาธไฟล์ ส่วนต่อขยายสามารถช่วยแยกสไลด์โชว์หรือเทมเพลตได้ หากไม่มีชื่อไฟล์ เนื้อหา PPS และ POT รุ่นเก่าอาจถูกระบุเป็น `SourceFormat.Ppt`; ตัวอย่าง PPS ด้านบนพิมพ์ค่าจำนวนเต็มของ `SourceFormat.Ppt`

หากแอปพลิเคชันของคุณต้องคงความแตกต่างนี้ไว้ ควรเก็บชื่อไฟล์ดั้งเดิมหรือเมตาดาต้าย่อยแยกต่างหาก ส่วนต่อขยายเป็นข้อมูลบ่งชี้ที่มีประโยชน์สำหรับย่อยแบบเก่าเหล่านี้ แต่ไม่ควรเป็นฐานเดียวในการระบุเนื้อหาพรีเซนเทชันใด ๆ

## **เปรียบเทียบการตรวจจับก่อนและหลังการโหลด**

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) และ [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#getLoadFormat) เมื่อคุณต้องตรวจสอบไฟล์ก่อนที่จะโหลดโมเดลออบเจ็กต์พรีเซนเทชันอย่างเต็มรูปแบบ ใช้ [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSourceFormat) เมื่ออินสแตนซ์มีอยู่แล้ว

ตัวอย่างนี้ต้องอ้างอิง `sample.pptx` และพิมพ์ค่าจำนวนเต็มของ `LoadFormat.Pptx` และ `SourceFormat.Pptx` ตามลำดับ ในการผลิต ให้เลือก API ที่เหมาะสมกับขั้นตอนการประมวลผลของคุณ; พรีเซนเทชันที่โหลดแล้วไม่จำเป็นต้องตรวจสอบครั้งที่สองเพื่อรับรูปแบบแหล่งที่มา

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

ผลลัพธ์ใช้ค่าคงที่จากคลาสต่างกัน: [LoadFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadformat/) และ [SourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/sourceformat/) อย่าเปรียบเทียบค่าจำนวนเต็มของพวกมันหรือสันนิษฐานว่าทุกรูปแบบมีผลการตรวจจับที่เหมือนกัน PowerPoint XML อาจรายงานเป็น `LoadFormat.Unknown` ก่อนโหลด และ `SourceFormat.Xml` หลังโหลด

## **แยกแยะรูปแบบแหล่งที่มาและรูปแบบผลลัพธ์**

ตัวอย่างนี้ต้องอ้างอิง `sample.pptx` และเขียนไฟล์ `converted.odp` มันพิมพ์ค่าจำนวนเต็มของ `SourceFormat.Pptx` ทั้งก่อนและหลังบันทึกอินสแตนซ์เดิม เฉพาะอินสแตนซ์ใหม่ที่โหลดจากผลลัพธ์ ODP เท่านั้นที่รายงาน `Odp`

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

พรีเซนเทชันที่สร้างจากศูนย์ด้วย `Presentation()` รายงาน `SourceFormat.Pptx` เนื่องจากไม่มีไฟล์อินพุต: นี่คือค่าดีฟอลต์สำหรับอินสแตนซ์ที่สร้างใหม่ ไม่ได้เป็นหลักฐานว่ามีการโหลดไฟล์ PPTX ติดตามว่าแอปพลิเคชันของคุณสร้างหรือโหลดอินสแตนซ์แยกต่างหากหากความแตกต่างนี้สำคัญ

## **แมปรูปแบบแหล่งที่มาเป็นส่วนขยาย**

ตัวอย่างต่อไปนี้ต้องอ้างอิง `sample.pptx` มันแมปค่า [SourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/sourceformat/) ที่รองรับทุกค่าปัจจุบันเป็นส่วนขยายแบบทั่วไปโดยไม่ต้องพิเคราะห์ชื่อไฟล์อินพุต การสำรองค่าจะหลีกเลี่ยงการกำหนดส่วนขยายให้กับค่าที่ไม่รู้จักโดยเงียบ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

การแมปนี้ไม่ได้แปลงไฟล์หรือกู้คืนย่อย PPS/POT รุ่นเก่าที่สูญหายระหว่างการโหลดสตรีม สำหรับการบันทึกจริง ให้เลือก [SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/) อย่างชัดเจน หรือใช้การแปลงที่แสดงใน [Save Presentations in Their Original Format](/slides/th/python-java/save-presentation/#save-presentations-in-their-original-format)

## **ยืนยันรูปแบบโดยการบันทึกและเปิดใหม่**

ตัวอย่างแบบสแตนด์อโลนนี้สร้างพรีเซนเทชันและเขียนไฟล์สามไฟล์ในไดเรกทอรีทำงาน ทับไฟล์ที่มีชื่อเดียวกันใหม่ ทั้งหมดจะเปิดผลลัพธ์แต่ละไฟล์ใหม่โดยพาธและโดยสตรีมหน่วยความจำ สำหรับ PPTX และ ODP ทั้งสองวิธีจะรายงานรูปแบบที่บันทึกไว้ สำหรับ PPS การโหลดโดยพาธรายงาน `Pps` ขณะที่การโหลดไบต์เดียวกันโดยไม่มีชื่อไฟล์รายงาน `Ppt`

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

| รูปแบบที่บันทึก | SourceFormat จากพาธไฟล์ | SourceFormat จากสตรีมไม่มีชื่อ |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` ตามลำดับ | เหมือนพาธไฟล์ |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` ตามลำดับ | เหมือนพาธไฟล์ |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` ตามลำดับ | เหมือนพาธไฟล์ |
| ODP, OTP | `Odp`, `Otp` ตามลำดับ | เหมือนพาธไฟล์ |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

เนื้อหา PPS/POT จะถูกระบุเป็น `Ppt` สำหรับสตรีมไม่มีชื่อ ตารางอธิบายการระบุรูปแบบ ไม่ได้หมายถึงการคงคุณลักษณะทุกอย่างของพรีเซนเทชันระหว่างการแปลง

## **คำถามที่พบบ่อย**

**การบันทึกเป็น ODP ทำให้รูปแบบแหล่งที่มาของพรีเซนเทชันที่โหลดจาก PPTX เปลี่ยนไหม?**

ไม่. อินสแตนซ์ที่มีอยู่ยังคงรายงาน `Pptx` อินสแตนซ์ที่โหลดจากไฟล์ ODP ที่บันทึกแล้วจะรายงาน `Odp`

**สตรีมสามารถแยกแยะพรีเซนเทชัน, สไลด์โชว์, และเทมเพลตแบบเก่าได้เสมอไหม?**

ไม่ได้. PPT, PPS และ POT ใช้รูปแบบไบนารีเดียวกัน เก็บชื่อไฟล์หรือเมตาดาต้าย่อยแยกต่างหากเมื่อความแตกต่างนี้จำเป็น

**ควรใช้ API ใดหากพรีเซนเทชันถูกโหลดแล้ว?**

อ่าน [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSourceFormat) ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) เพื่อทำการตรวจสอบก่อนโหลด