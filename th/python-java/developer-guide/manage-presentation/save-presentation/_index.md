---
title: บันทึกการนำเสนอใน Python ผ่าน Java
linktitle: บันทึกการนำเสนอ
type: docs
weight: 80
url: /th/python-java/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกการนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- การนำเสนอเป็นไฟล์
- การนำเสนอเป็นสตรีม
- ประเภทมุมมองที่กำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชภาพย่อ
- ความคืบหน้าการบันทึก
- Python
- Java
- Aspose.Slides
description: "บันทึกการนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีมใน Python ผ่าน Java ด้วย Aspose.Slides และกำหนดการส่งออก PPTX รวมถึงการรายงานความคืบหน้า."
---
## **ภาพรวม**

หลังจากที่คุณสร้างงานนำเสนอหรือ[เปิดงานนำเสนอที่มีอยู่](/slides/th/python-java/open-presentation/), ใช้เมธอด[Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save)เพื่อบันทึกผลลัพธ์ Aspose.Slides for Python via Java สามารถบันทึกงานนำเสนอเป็นไฟล์หรือสตรีมในรูปแบบ PowerPoint, OpenDocument, PDF และรูปแบบอื่น ๆ ส่วนต่อไปนี้จะอธิบายการบันทึกแบบมาตรฐานและตัวเลือกที่มีสำหรับการส่งออกเป็น PPTX

## **บันทึกการนำเสนอเป็นไฟล์**

เพื่อบันทึกงานนำเสนอเป็นไฟล์, ให้ส่งพาธเอาต์พุตและค่า[SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/)ไปยังเมธอด[Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ค่ารูปแบบจะกำหนดประเภทของไฟล์ที่ Aspose.Slides จะสร้าง

ตัวอย่างต่อไปนี้สร้างงานนำเสนอและบันทึกเป็นไฟล์ PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # เพิ่มหรือแก้ไขเนื้อหาการนำเสนอที่นี่.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **บันทึกการนำเสนอในรูปแบบเดิม**

สำหรับตัวอย่างการตรวจจับไฟล์และสตรีม, พฤติกรรมของงานนำเสนอที่สร้างใหม่, และความแตกต่างระหว่างรูปแบบต้นฉบับและรูปแบบเอาต์พุต, ดูที่[Determine the Original Presentation Format](/slides/th/python-java/detect-presentation-source-format/)

ในแอปพลิเคชันการประมวลผลเป็นชุด, รูปแบบอินพุตอาจยังไม่ทราบล่วงหน้า หลังจากโหลดไฟล์, อ่านรูปแบบเดิมจากเมธอด[Presentation.getSourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSourceFormat) แล้วส่งค่า[SourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/sourceformat/)ที่ได้ไปยัง[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideutil/#toSaveFormat)เพื่อรับค่า[SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/)ที่สอดคล้อง, แล้วใช้[Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save)เพื่อบันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างเต็มด้านล่างนี้จะประมวลผลทุกไฟล์ในโฟลเดอร์อินพุต, อัปเดตชื่อเรื่อง, และบันทึกไปยังโฟลเดอร์เอาต์พุตในรูปแบบที่โหลดมาจากไฟล์เดิม:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideutil/#toSaveFormat) จะแมป PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, และ PowerPoint XML ไปยังรูปแบบการบันทึกงานนำเสนอที่สอดคล้อง มันแมปเฉพาะรูปแบบต้นฉบับของงานนำเสนอ; ไม่ได้ออกแบบให้เลือกรูปแบบการส่งออกเช่น PDF, HTML, TIFF หรือรูปภาพ การส่งค่า[SourceFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/sourceformat/)ที่ไม่สนับสนุนหรือไม่ถูกต้องจะทำให้เกิด[IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html)

ไฟล์ PPT, PPS, และ POT แบบเก่าใช้คอนเทนเนอร์ไบนารีเดียวกัน เมื่อโหลดงานนำเสนอจากสตรีมโดยไม่มีส่วนขยายไฟล์, ไฟล์ PPS หรือ POT อาจถูกระบุว่าเป็น PPT หากต้องการคงสภาพความแตกต่างของรูปแบบเก่าเหล่านี้, ควรเก็บชื่อไฟล์หรือเมตาดาต้ารูปแบบต้นฉบับแยกต่างหากและใช้เมื่อกำหนดชื่อไฟล์และรูปแบบเอาต์พุต

## **บันทึกการนำเสนอเป็นสตรีม**

เพื่อเขียนงานนำเสนอโดยไม่ต้องอ้างอิงพาธไฟล์สุดท้าย, ให้ส่งสตรีมที่เขียนได้และค่า[SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/)ไปยังเมธอด[Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) วิธีนี้มีประโยชน์เมื่อเอาต์พุตต้องคืนค่าให้กับเว็บเซอร์วิส, เก็บในฐานข้อมูล, หรือประมวลผลในหน่วยความจำ

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

## **บันทึกการนำเสนอพร้อมประเภทมุมมองที่กำหนดไว้ล่วงหน้า**

คุณสามารถระบุมุมมองที่ PowerPoint จะเปิดงานนำเสนอที่บันทึกไว้โดยแรกใช้เมธอด[ViewProperties.setLastView](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewproperties/#setLastView)พร้อมค่า[ViewType](https://reference.aspose.com/slides/th/python-java/aspose.slides/viewtype/)ก่อนบันทึก

ตัวอย่างต่อไปนี้ตั้งค่ามุมมอง Slide Master ให้เป็นมุมมองเริ่มต้น:

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

## **บันทึกการนำเสนอในรูปแบบ Strict Office Open XML**

เพื่อสร้างไฟล์ PPTX ที่เป็นไปตามโปรไฟล์ Strict ของ Office Open XML, สร้างอินสแตนซ์ [PptxOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/) และใช้เมธอด[setConformance](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/#setConformance) พร้อมค่า[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/th/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) แล้วส่งอ็อบเจ็กต์ตัวเลือกไปยังเมธอด[Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save)

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

## **บันทึกการนำเสนอในรูปแบบ Office Open XML ด้วยโหมด Zip64**

ไฟล์ ZIP มาตรฐานจำกัดขนาดบีบอัดและขนาดที่ไม่ได้บีบอัดของแต่ละรายการ, ขนาดรวมของไฟล์ ZIP, และจำนวนรายการ เนื่องจากไฟล์ PPTX เป็นไฟล์ ZIP, งานนำเสนอขนาดใหญ่อาจเกินขีดจำกัดเหล่านี้ ส่วนขยาย Zip64 จะเพิ่มขีดจำกัดขนาดและจำนวนรายการที่ใช้ได้

ใช้เมธอด[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/#setZip64Mode)เพื่อควบคุมว่าการเขียน Zip64 จะเปิดใช้หรือไม่:

- [IfNecessary](https://reference.aspose.com/slides/th/python-java/aspose.slides/zip64mode/#IfNecessary) จะใช้ Zip64 ก็ต่อเมื่องานนำเสนอเกินขีดจำกัด ZIP มาตรฐาน (เป็นค่าเริ่มต้น)
- [Never](https://reference.aspose.com/slides/th/python-java/aspose.slides/zip64mode/#Never) ปิดการใช้ Zip64
- [Always](https://reference.aspose.com/slides/th/python-java/aspose.slides/zip64mode/#Always) เปิดใช้ Zip64 เสมอ

ตัวอย่างต่อไปนี้เปิดใช้ส่วนขยาย Zip64 เสมอสำหรับงานนำเข้าส่งออก:

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
หากใช้[Zip64Mode.Never](https://reference.aspose.com/slides/th/python-java/aspose.slides/zip64mode/#Never) และงานนำเสนอไม่สามารถอยู่ในขีดจำกัด ZIP มาตรฐาน, การบันทึกจะโยนข้อผิดพลาด[PptxException](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **บันทึกการนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

สำหรับการส่งออก PPTX, คุณสามารถปรับสมดุลระหว่างความเร็วในการบันทึกกับขนาดไฟล์โดยใช้เมธอด[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/#setCompressionLevel) คลาส[CompressionLevel](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/) ให้ค่าต่อไปนี้:

- [None](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#None) บันทึกข้อมูลโดยไม่มีการบีบอัด
- [Level1](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level1) ให้การบีบอัดที่เร็วที่สุดและไฟล์บีบอัดขนาดใหญ่ที่สุด
- [Level2](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level2) ถึง [Level5](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level5) ให้ไฟล์บีบอัดที่เล็กลงเรื่อย ๆ แต่ช้าลง
- [Level6](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level6) สมดุลระหว่างความเร็วและขนาดไฟล์ (ค่าเริ่มต้น)
- [Level7](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level7) และ [Level8](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level8) เน้นไฟล์บีบอัดที่เล็กกว่าแม้จะช้าลง
- [Level9](https://reference.aspose.com/slides/th/python-java/aspose.slides/compressionlevel/#Level9) ให้การบีบอัดที่แรงที่สุด แต่ต้องใช้เวลาประมวลผลมากที่สุด

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอโดยไม่มีการบีบอัด:

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

## **บันทึกการนำเสนอโดยไม่รีเฟรชภาพย่อ**

เมื่อบันทึกงานนำเสนอเป็น PPTX, เมธอด[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/th/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) จะควบคุมภาพย่อของเอกสาร:

- `True` สร้างภาพย่อใหม่ระหว่างการบันทึก (ค่าเริ่มต้น)
- `False` รักษาภาพย่อเดิมไว้ หากงานนำไม่มีภาพย่อ Aspose.Slides จะไม่สร้างภาพย่อใหม่

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอโดยไม่รีเฟรชภาพย่อ:

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
การปิดการรีเฟรชภาพย่อสามารถลดเวลาที่ใช้ในการบันทึกไฟล์ PPTX ได้
{{% /alert %}}

## **รายงานความคืบหน้าการบันทึกเป็นเปอร์เซ็นต์**

เพื่อติดตามการบันทึก, ลงทะเบียนตัวจัดการความคืบหน้าภาษาพายทอนผ่าน `jpype.JProxy` แล้วส่งไปยังเมธอด[SaveOptions.setProgressCallback](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveoptions/#setProgressCallback) Aspose.Slides จะเรียกเมธอด `reporting` ของตัวจัดการพร้อมค่าความคืบหน้าในระหว่างการส่งออก

ตัวอย่างต่อไปนี้แสดงความคืบหน้าการส่งออก PDF ไปยังคอนโซล:

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
Aspose มีเครื่องมือ[PowerPoint Splitter](https://products.aspose.app/slides/th/splitter) ฟรีที่สร้างด้วย Aspose.Slides API สามารถแยกสไลด์ที่เลือกจากงานนำเสนอเป็นไฟล์ PPT หรือ PPTX แยกกัน
{{% /alert %}}

## **FAQ**

**Aspose.Slides รองรับการบันทึกแบบเพิ่มส่วนหรือ “fast save” หรือไม่?**

ไม่ รองรับ การบันทึกแต่ละครั้งจะเขียนไฟล์เอาต์พุตทั้งหมดแทนการอัปเดตเฉพาะส่วนที่เปลี่ยนแปลง

**หลายเธรดสามารถบันทึกอินสแตนซ์ Presentation เดียวกันได้หรือไม่?**

ไม่ได้ อินสแตนซ์[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) **ไม่ปลอดภัยต่อเธรด** (/slides/th/python-java/multithreading/) ให้เข้าถึงและบันทึกแต่ละอินสแตนซ์จากเธรดเดียวเท่านั้น

**ลิงก์และไฟล์ที่เชื่อมโยงภายนอกจะเกิดอะไรขึ้นเมื่อลบการบันทึกงานนำเสนอ?**

[Hyperlinks](/slides/th/python-java/manage-hyperlinks/) จะคงอยู่ในงานนำเสนอ Aspose.Slides ไม่คัดลอกไฟล์ที่เชื่อมโยงภายนอก ดังนั้นงานนำเสนอที่บันทึกแล้วต้องยังคงสามารถเข้าถึงตำแหน่งไฟล์เหล่านั้นได้

**ฉันสามารถบันทึกเมทาดาต้าเอกสาร เช่น ผู้สร้าง, ชื่อเรื่อง, บริษัท, และวันที่สร้างได้หรือไม่?**

ได้ ให้ตั้งค่า[document properties](/slides/th/python-java/presentation-properties/) ที่เหมาะสมก่อนบันทึก แล้ว Aspose.Slides จะเขียนค่าเหล่านั้นลงในไฟล์เอาต์พุต