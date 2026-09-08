---
title: บันทึกงานนำเสนอใน Python ผ่าน Java
linktitle: บันทึกงานนำเสนอ
type: docs
weight: 80
url: /th/python-java/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกงานนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- งานนำเสนอเป็นไฟล์
- งานนำเสนอเป็นสตรีม
- ชนิดมุมมองที่กำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชรูปย่อ
- บันทึกความคืบหน้า
- Python
- Java
- Aspose.Slides
description: "บันทึกงานนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีมใน Python ผ่าน Java ด้วย Aspose.Slides และกำหนดการส่งออก PPTX รวมถึงการรายงานความคืบหน้า."
---
## **บทสรุป**

หลังจากคุณสร้างงานนำเสนอหรือ[เปิดงานนำเสนอที่มีอยู่](/slides/th/python-java/open-presentation/), ใช้เมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) เพื่อบันทึกผลลัพธ์ Aspose.Slides for Python via Java สามารถบันทึกงานนำเสนอเป็นไฟล์หรือสตรีมในรูปแบบ PowerPoint, OpenDocument, PDF และรูปแบบอื่น ๆ ส่วนต่อไปนี้ครอบคลุมการบันทึกมาตรฐานและตัวเลือกที่ใช้ได้สำหรับการส่งออกเป็น PPTX

## **บันทึกงานนำเสนอเป็นไฟล์**

เพื่อบันทึกงานนำเสนอเป็นไฟล์ ให้ส่งพาธเอาต์พุตและค่าของ [SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/) ไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ค่าของรูปแบบจะกำหนดประเภทไฟล์ที่ Aspose.Slides สร้าง

ตัวอย่างต่อไปนี้สร้างงานนำเสนอและบันทึกเป็นไฟล์ PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # เพิ่มหรือแก้ไขเนื้อหาในงานนำเสนอที่นี่.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **บันทึกงานนำเสนอในรูปแบบดั้งเดิม**

ในแอปพลิเคชันประมวลผลเป็นกลุ่ม รูปแบบอินพุตอาจไม่ทราบล่วงหน้า หลังจากโหลดไฟล์แล้ว ให้อ่านรูปแบบดั้งเดิมจากเมธอด [Presentation.getSourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSourceFormat) ส่งค่าของ [SourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/sourceformat/) ที่ได้ไปยัง [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideutil/#toSaveFormat) เพื่อรับค่า [SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/) ที่สอดคล้องกัน แล้วใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) เพื่อเขียนงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างเต็มต่อไปนี้ประมวลผลทุกไฟล์ในไดเรกทอรีอินพุต, ปรับปรุงหัวเรื่อง, และบันทึกไปยังไดเรกทอรีเอาต์พุตในรูปแบบที่โหลดมา:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideutil/#toSaveFormat) จะแมป PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP และ PowerPoint XML ไปยังรูปแบบการบันทึกงานนำเสนอที่สอดคล้องกัน มันแมปเฉพาะรูปแบบแหล่งที่มาของงานนำเสนอ; ไม่ได้ออกแบบให้เลือกรูปแบบการส่งออกเช่น PDF, HTML, TIFF หรือภาพ การส่งค่าของ [SourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/sourceformat/) ที่ไม่รองรับหรือไม่ถูกต้องจะทำให้เกิด [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html)

ไฟล์ PPT, PPS, และ POT แบบ Legacy ใช้คอนเทนเนอร์ไบนารีเดียวกัน เมื่อโหลดงานนำเสนอจากสตรีมที่ไม่มีส่วนขยายไฟล์, ไฟล์ PPS หรือ POT อาจถูกระบุเป็น PPT หากต้องการรักษาชนิดย่อยแบบ Legacy นี้ไว้ ให้เก็บชื่อไฟล์หรือเมทาดาต้ารูปแบบดั้งเดิมแยกต่างหากและใช้เมื่อเลือกรายการชื่อไฟล์และรูปแบบเอาต์พุต

## **บันทึกงานนำเสนอเป็นสตรีม**

เพื่อเขียนงานนำเสนอโดยไม่ต้องอาศัยพาธไฟล์สุดท้าย ให้ส่งสตรีมที่เขียนได้และค่าของ [SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/) ไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) วิธีนี้มีประโยชน์เมื่อเอาต์พุตต้องส่งกลับจากเว็บเซอร์วิส, จัดเก็บในฐานข้อมูล, หรือประมวลผลในหน่วยความจำ

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอใหม่ไปยังสตรีมไฟล์:

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

## **บันทึกงานนำเสนอพร้อมชนิดมุมมองที่กำหนดไว้ล่วงหน้า**

คุณสามารถระบุมุมมองที่ PowerPoint เปิดงานนำเสนอที่บันทึกไว้โดยเริ่มต้นได้ ใช้เมธอด [ViewProperties.setLastView](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#setLastView) พร้อมค่าของ [ViewType](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewtype/) ก่อนทำการบันทึก

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

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

เพื่อสร้างไฟล์ PPTX ที่สอดคล้องกับโปรไฟล์ Strict ของ Office Open XML ให้สร้างอินสแตนซ์ของ [PptxOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/) แล้วใช้เมธอด [setConformance](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/#setConformance) กับ [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) จากนั้นส่งตัวเลือกไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save)

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

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML แบบโหมด Zip64**

ไฟล์ ZIP มาตรฐานจำกัดขนาดบีบอัดและไม่บีบอัดของแต่ละรายการ, ขนาดรวมของอาร์ไคฟ์, และจำนวนรายการ เนื่องจากไฟล์ PPTX เป็นอาร์ไคฟ์ ZIP งานนำเสนอขนาดใหญ่อาจเกินขอบเขตเหล่านี้ ส่วนขยาย ZIP64 จะเพิ่มขีดจำกัดขนาดและจำนวนรายการ

ใช้เมธอด [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/#setZip64Mode) เพื่อควบคุมว่า Aspose.Slides จะเขียนส่วนขยาย ZIP64 หรือไม่:

- [IfNecessary](https://reference.aspose.com/slides/th/python-java/aspose.slides/zip64mode/#IfNecessary) ใช้ ZIP64 เฉพาะเมื่องานนำเสนอเกินขีดจำกัด ZIP มาตรฐาน (เป็นโหมดเริ่มต้น)
- [Never](https://reference.aspose.com/slides/th/python-java/aspose.slides/zip64mode/#Never) ปิดการใช้ส่วนขยาย ZIP64
- [Always](https://reference.aspose.com/slides/th/python-java/aspose.slides/zip64mode/#Always) เขียนส่วนขยาย ZIP64 เสมอ

ตัวอย่างต่อไปนี้เปิดใช้งานส่วนขยาย ZIP64 สำหรับงานนำเสนอเอาต์พุตเสมอ:

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
หากใช้ [Zip64Mode.Never](https://reference.aspose.com/slides/th/python-java/aspose.slides/zip64mode/#Never) และงานนำเสนอไม่สามารถพอใส่ในขีดจำกัด ZIP มาตรฐาน การบันทึกจะโยน [PptxException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

สำหรับการส่งออกเป็น PPTX คุณสามารถปรับสมดุลระหว่างความเร็วในการบันทึกกับขนาดไฟล์โดยใช้เมธอด [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/#setCompressionLevel) คลาส [CompressionLevel](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/) มีค่าต่อไปนี้:

- [None](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#None) เก็บข้อมูลโดยไม่บีบอัด
- [Level1](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level1) ให้การบีบอัดที่เร็วที่สุดและผลลัพธ์ที่บีบอัดมากที่สุด
- [Level2](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level2) ถึง [Level5](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level5) ให้ความสำคัญกับผลลัพธ์ที่เล็กลงมากกว่าความเร็วในการบันทึก
- [Level6](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level6) สมดุลความเร็วและขนาดไฟล์ (เป็นระดับเริ่มต้น)
- [Level7](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level7) และ [Level8](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level8) ให้ความสำคัญกับผลลัพธ์ที่เล็กลงต่อเนื่อง
- [Level9](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level9) ให้การบีบอัดที่แรงที่สุดแต่ต้องการเวลาประมวลผลสูงสุด

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอโดยไม่บีบอัด:

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

## **บันทึกงานนำเสนอโดยไม่รีเฟรชรูปย่อ**

เมื่อบันทึกงานนำเสนอเป็น PPTX เมธอด [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) ควบคุมรูปย่อของเอกสาร:

- `True` สร้างรูปย่อใหม่ระหว่างการบันทึก (ค่าเริ่มต้น)
- `False` คงรูปย่อเดิมไว้ หากงานนำเสนอไม่มีรูปย่อ Aspose.Slides จะไม่สร้างใหม่

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอโดยไม่รีเฟรชรูปย่อ:

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
การปิดการรีเฟรชรูปย่อสามารถลดเวลาที่ใช้ในการบันทึกไฟล์ PPTX ได้
{{% /alert %}}

## **อัปเดตความคืบหน้าในการบันทึกเป็นเปอร์เซ็นต์**

เพื่อติดตามการบันทึก ลงทะเบียนตัวจัดการความคืบหน้าของ Python ผ่าน `jpype.JProxy` แล้วส่งให้เมธอด [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveoptions/#setProgressCallback) Aspose.Slides จะเรียกเมธอด `reporting` ของตัวจัดการพร้อมค่าความคืบหน้าในระหว่างการส่งออก

ตัวอย่างต่อไปนี้รายงานความคืบหน้าการส่งออกเป็น PDF ไปยังคอนโซล:

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
Aspose ให้บริการฟรี [PowerPoint Splitter](https://products.aspose.app/slides/th/splitter) ที่สร้างด้วย Aspose.Slides API ซึ่งบันทึกสไลด์ที่เลือกจากงานนำเสนอเป็นไฟล์ PPT หรือ PPTX แยกกัน
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการบันทึกเชิงเพิ่มหรื “fast save” หรือไม่?**

ไม่มี การบันทึกแต่ละครั้งจะเขียนไฟล์ผลลัพธ์เต็มชุดแทนการอัปเดตเฉพาะส่วนที่เปลี่ยนแปลง

**หลายเธรดสามารถบันทึกอินสแตนซ์ Presentation เดียวกันได้หรือไม่?**

ไม่ได้ อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) **ไม่ปลอดภัยต่อเธรด** (/slides/th/python-java/multithreading/) ให้เข้าถึงและบันทึกแต่ละอินสแตนซ์จากเธรดเดียวเท่านั้น

**ลิงก์และไฟล์ที่เชื่อมโยงภายนอกจะเป็นอย่างไรเมื่อบันทึกงานนำเสนอ?**

[Hyperlinks](/slides/th/python-java/manage-hyperlinks/) จะคงอยู่ในงานนำเสนอ Aspose.Slides ไม่คัดลอกไฟล์ที่เชื่อมโยงภายนอก ดังนั้นงานนำเสนอที่บันทึกต้องยังคงสามารถเข้าถึงตำแหน่งของไฟล์เหล่านั้นได้

**สามารถบันทึกเมทาดาต้าเอกสาร เช่น ผู้เขียน, ชื่อเรื่อง, บริษัท, และวันที่สร้างได้หรือไม่?**

ได้ ตั้งค่า [document properties](/slides/th/python-java/presentation-properties/) ที่เหมาะสมก่อนบันทึก แล้ว Aspose.Slides จะเขียนข้อมูลเหล่านั้นลงในไฟล์เอาต์พุต