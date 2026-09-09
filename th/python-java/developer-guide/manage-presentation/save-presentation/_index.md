---
title: บันทึกงานพรีเซนเทชันใน Python ผ่าน Java
linktitle: บันทึกงานพรีเซนเทชัน
type: docs
weight: 80
url: /th/python-java/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกงานพรีเซนเทชัน
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- งานพรีเซนเทชันเป็นไฟล์
- งานพรีเซนเทชันเป็นสตรีม
- ประเภทมุมมองกำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชรูปภาพย่อ
- ความคืบหน้าการบันทึก
- Python
- Java
- Aspose.Slides
description: "บันทึกงานพรีเซนเทชัน PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีมใน Python ผ่าน Java ด้วย Aspose.Slides และกำหนดการส่งออก PPTX รวมถึงการรายงานความคืบหน้า"
---
## **ภาพรวม**

หลังจากคุณสร้างงานพรีเซนเทชันหรือ[เปิดงานที่มีอยู่แล้ว](/slides/th/python-java/open-presentation/), ให้ใช้เมธอด[Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save)เพื่อเขียนผลลัพธ์ Aspose.Slides สำหรับ Python ผ่าน Java สามารถบันทึกงานพรีเซนเทชันไปยังไฟล์หรือสตรีมในรูปแบบ PowerPoint, OpenDocument, PDF และรูปแบบอื่น ๆ ส่วนต่อไปนี้จะครอบคลุมการบันทึกมาตรฐานและตัวเลือกที่มีสำหรับการส่งออกเป็น PPTX

## **บันทึกงานพรีเซนเทชันไปยังไฟล์**

เพื่อบันทึกงานพรีเซนเทชันไปยังไฟล์ ให้ส่งพาธของไฟล์ผลลัพธ์และค่า[SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/)ไปยังเมธอด[Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ค่ารูปแบบจะกำหนดชนิดของไฟล์ที่ Aspose.Slides สร้างขึ้น

ตัวอย่างต่อไปนี้สร้างงานพรีเซนเทชันและบันทึกเป็นไฟล์ PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # เพิ่มหรือแก้ไขเนื้อหางานพรีเซนเทชันที่นี่.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **บันทึกงานพรีเซนเทชันในรูปแบบเดิมของมัน**

ในแอปพลิเคชันการประมวลผลแบบแบตช์ รูปแบบอินพุตอาจไม่ทราบล่วงหน้า หลังจากโหลดไฟล์ ให้อ่านรูปแบบเดิมจากเมธอด[Presentation.getSourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSourceFormat) ส่งค่าที่ได้ของ[SourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/sourceformat/)ไปยังเมธอด[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideutil/#toSaveFormat)เพื่อรับค่า[SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/)ที่สอดคล้องกัน แล้วใช้เมธอด[Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save)เพื่อเขียนงานพรีเซนเทชันที่แก้ไขแล้ว

ตัวอย่างสมบูรณ์ต่อไปนี้จะประมวลผลทุกไฟล์ในไดเรกทอรีอินพุต, อัปเดตหัวเรื่องของไฟล์, และบันทึกไปยังไดเรกทอรีเอาต์พุตในรูปแบบที่โหลดมา:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideutil/#toSaveFormat) จะแมป PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP และ PowerPoint XML ไปยังรูปแบบการบันทึกงานพรีเซนเทชันที่สอดคล้องกัน มันแมปเฉพาะรูปแบบแหล่งของงานพรีเซนเทชันเท่านั้น; ไม่ได้ออกแบบให้เลือกรูปแบบการส่งออกเช่น PDF, HTML, TIFF หรือรูปภาพ การส่งค่[SourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/sourceformat/)ที่ไม่รองรับหรือไม่ถูกต้องจะทำให้เกิด[IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html)

ไฟล์ PPT, PPS, และ POT รุ่นเก่าใช้คอนเทนเนอร์ไบนารีเดียวกัน เมื่อโหลดงานพรีเซนเทชันแบบดังกล่าวจากสตรีมที่ไม่มีส่วนขยายของไฟล์, ไฟล์ PPS หรือ POT อาจถูกระบุว่าเป็น PPT หากต้องการรักษาชนิดย่อยรุ่นเก่าเหล่านี้ไว้ ควรเก็บชื่อไฟล์เดิมหรือเมทาดาต้ารูปแบบแยกจากกันและใช้เมื่อตั้งค่าชื่อไฟล์และรูปแบบเอาต์พุต

## **บันทึกงานพรีเซนเทชันไปยังสตรีม**

เพื่อเขียนงานพรีเซนเทชันโดยไม่ต้องอ้างอิงพาธไฟล์สุดท้าย ให้ส่งสตรีมที่เขียนได้และค่า[SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/)ไปยังเมธอด[Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) วิธีนี้มีประโยชน์เมื่อผลลัพธ์ต้องส่งกลับจากเว็บเซอร์วิส, เก็บไว้ในฐานข้อมูล, หรือประมวลผลในหน่วยความจำ

ตัวอย่างต่อไปนี้บันทึกงานพรีเซนเทชันใหม่ไปยังสตรีมไฟล์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **บันทึกงานพรีเซนเทชันด้วยมุมมองที่กำหนดล่วงหน้า**

คุณสามารถกำหนดมุมมองที่ PowerPoint จะเปิดงานพรีเซนเทชันที่บันทึกไว้เป็นค่าเริ่มต้นได้ ใช้เมธอด[ViewProperties.setLastView](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#setLastView)พร้อมกับค่า[ViewType](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewtype/)ก่อนบันทึก

ตัวอย่างต่อไปนี้กำหนดให้มุมมอง Slide Master เป็นมุมมองเริ่มต้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **บันทึกงานพรีเซนเทชันในรูปแบบ Strict Office Open XML**

เพื่อสร้างไฟล์ PPTX ที่สอดคล้องกับโปรไฟล์ Strict ของ Office Open XML ให้สร้างอินสแตนซ์ของ[PptxOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/)และใช้เมธอด[setConformance](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/#setConformance)พร้อมกับค่า[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) จากนั้นส่งตัวเลือกไปยังเมธอด[Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **บันทึกงานพรีเซนเทชันในรูปแบบ Office Open XML ในโหมด Zip64**

ไฟล์ ZIP มาตรฐานจำกัดขนาดบีบอัดและขนาดที่ไม่บีบอัดของแต่ละรายการ, ขนาดรวมของไฟล์ ZIP, และจำนวนรายการ เนื่องจากไฟล์ PPTX เป็นไฟล์ ZIP, งานพรีเซนเทชันขนาดใหญ่มากอาจเกินขีดจำกัดเหล่านี้ ส่วนขยาย ZIP64 จะเพิ่มขีดจำกัดขนาดและจำนวนรายการที่สามารถใช้ได้

ใช้เมธอด[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/#setZip64Mode)เพื่อควบคุมว่า Aspose.Slides จะเขียนส่วนขยาย ZIP64 หรือไม่:

- [IfNecessary](https://reference.aspose.com/slides/th/python-java/aspose.slides/zip64mode/#IfNecessary) ใช้ ZIP64 เฉพาะเมื่องานพรีเซนเทชันเกินขีดจำกัด ZIP มาตรฐาน นี่เป็นโหมดเริ่มต้น
- [Never](https://reference.aspose.com/slides/th/python-java/aspose.slides/zip64mode/#Never) ปิดการใช้งานส่วนขยาย ZIP64
- [Always](https://reference.aspose.com/slides/th/python-java/aspose.slides/zip64mode/#Always) เขียนส่วนขยาย ZIP64 เสมอ

ตัวอย่างต่อไปนี้เปิดใช้ส่วนขยาย ZIP64 เสมอสำหรับงานพรีเซนเทชันเอาต์พุต:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
หากใช้ Zip64Mode.Never และงานพรีเซนเทชันไม่สามารถอยู่ภายในขีดจำกัด ZIP มาตรฐาน การดำเนินการบันทึกจะโยน [PptxException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxexception/){{% /alert %}}

## **บันทึกงานพรีเซนเทชันในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

สำหรับการส่งออกเป็น PPTX คุณสามารถปรับสมดุลระหว่างความเร็วในการบันทึกและขนาดไฟล์โดยใช้เมธอด[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/#setCompressionLevel) คลาส[CompressionLevel](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/) ให้ค่าต่อไปนี้:

- [None](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#None) เก็บข้อมูลโดยไม่บีบอัด
- [Level1](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level1) ให้การบีบอัดที่เร็วที่สุดและผลลัพธ์บีบอัดที่มีขนาดใหญ่ที่สุด
- [Level2](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level2) ถึง [Level5](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level5) ลดขนาดผลลัพธ์อย่างค่อยเป็นค่อยไปโดยให้ความสำคัญกับขนาดไฟล์มากกว่าความเร็วในการบันทึก
- [Level6](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level6) สมดุลระหว่างความเร็วในการบันทึกและขนาดไฟล์ นี่เป็นระดับค่าเริ่มต้น
- [Level7](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level7) และ [Level8](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level8) ให้ความสำคัญกับขนาดไฟล์เล็กลงต่อไปเหนือความเร็วในการบันทึก
- [Level9](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level9) ให้การบีบอัดที่แรงที่สุดและต้องใช้เวลาประมวลผลมากที่สุด

ตัวอย่างต่อไปนี้บันทึกงานพรีเซนเทชันโดยไม่มีการบีบอัด:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

ตัวอย่างต่อไปนี้ใช้ระดับการบีบอัดสูงสุด:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **บันทึกงานพรีเซนเทชันโดยไม่รีเฟรชรูปภาพย่อ**

เมื่อบันทึกงานพรีเซนเทชันเป็น PPTX เมธอด[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) จะควบคุมรูปภาพย่อของเอกสาร:

- `True` สร้างรูปภาพย่อใหม่ระหว่างการบันทึก นี่เป็นค่าเริ่มต้น
- `False` รักษารูปภาพย่อเดิม หากงานพรีเซนเทชันไม่มีรูปภาพย่อ Aspose.Slides จะไม่สร้างขึ้น

ตัวอย่างต่อไปนี้บันทึกงานพรีเซนเทชันโดยไม่รีเฟรชรูปภาพย่อของมัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
การปิดการรีเฟรชรูปภาพย่อสามารถลดเวลาที่ใช้ในการบันทึกไฟล์ PPTX ได้{{% /alert %}}

## **รายงานความคืบหน้าการบันทึกเป็นเปอร์เซ็นต์**

เพื่อเฝ้าติดตามการดำเนินการบันทึก ให้ลงทะเบียนตัวจัดการความคืบหน้าของ Python ผ่าน `jpype.JProxy` และส่งให้เมธอด[SaveOptions.setProgressCallback](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveoptions/#setProgressCallback) Aspose.Slides จะเรียกเมธอด `reporting` ของตัวจัดการพร้อมค่าความคืบหน้าในระหว่างการส่งออก

ตัวอย่างต่อไปนี้รายงานความคืบหน้าของการส่งออก PDF ไปยังคอนโซล:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose มี [PowerPoint Splitter](https://products.aspose.app/slides/th/splitter) ฟรีซึ่งสร้างด้วย Aspose.Slides API มันบันทึกสไลด์ที่เลือกจากงานพรีเซนเทชันเป็นไฟล์ PPT หรือ PPTX แยกกัน{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการบันทึกแบบเพิ่มส่วนหรื “บันทึกเร็ว” หรือไม่?**

No. แต่ละการบันทึกจะเขียนไฟล์ผลลัพธ์เต็มรูปแบบแทนการอัปเดตเฉพาะส่วนที่เปลี่ยนแปลง

**สามารถหลายเธรดบันทึกอินสแตนซ์ Presentation เดียวกันได้หรือไม่?**

No. อินสแตนซ์[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) [ไม่ได้ออกแบบให้ใช้พร้อมกับหลายเธรด](/slides/th/python-java/multithreading/) ให้เข้าถึงและบันทึกแต่ละอินสแตนซ์จากหนึ่งเธรดเท่านั้น

**เกิดอะไรขึ้นกับไฮเปอร์ลิงก์และไฟล์ที่เชื่อมโยงภายนอกเมื่อฉันบันทึกงานพรีเซนเทชัน?**

[Hyperlinks](/slides/th/python-java/manage-hyperlinks/) คงอยู่ในงานพรีเซนเทชัน Aspose.Slides ไม่ทำการคัดลอกไฟล์ที่เชื่อมโยงภายนอก ดังนั้นงานพรีเซนเทชันที่บันทึกต้องสามารถเข้าถึงตำแหน่งของไฟล์เหล่านั้นได้

**ฉันสามารถบันทึกเมตาดาต้าเอกสารเช่น ผู้เขียน, ชื่อเรื่อง, บริษัท และวันที่สร้างได้หรือไม่?**

ใช่. ตั้งค่า[document properties](/slides/th/python-java/presentation-properties/) ที่เหมาะสมก่อนบันทึก แล้ว Aspose.Slides จะเขียนค่าเหล่านั้นลงในไฟล์เอาต์พุต