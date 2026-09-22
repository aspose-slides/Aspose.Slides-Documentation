---
title: บันทึกงานนำเสนอใน Python
linktitle: บันทึกงานนำเสนอ
type: docs
weight: 80
url: /th/python-net/save-presentation/
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
- ประเภทมุมมองที่กำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชรูปย่อ
- ความคืบหน้าการบันทึก
- Python
- Aspose.Slides
description: "บันทึกงานนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีมใน Python ด้วย Aspose.Slides และกำหนดค่าตัวเลือกการส่งออก PPTX"
---
## **ภาพรวม**

หลังจากคุณสร้างงานนำเสนอหรือ [เปิดงานนำเสนอที่มีอยู่แล้ว](/slides/th/python-net/open-presentation/), ใช้เมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/ipresentation/save/) เพื่อเขียนผลลัพธ์ Aspose.Slides for Python via .NET สามารถบันทึกงานนำเสนอเป็นไฟล์หรือสตรีมในรูปแบบ PowerPoint, OpenDocument, PDF และรูปแบบอื่น ๆ ส่วนต่อไปนี้ครอบคลุมการบันทึกรูปแบบมาตรฐานและตัวเลือกที่มีสำหรับเอาต์พุต PPTX

## **บันทึกงานนำเสนอเป็นไฟล์**

เพื่อบันทึกงานนำเสนอเป็นไฟล์ ให้ส่งพาธออกและค่า [SaveFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/saveformat/) ไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/ipresentation/save/) ค่า format จะกำหนดประเภทไฟล์ที่ Aspose.Slides สร้าง

ตัวอย่างต่อไปนี้สร้างงานนำเสนอและบันทึกเป็นไฟล์ PPTX:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # เพิ่มหรือแก้ไขเนื้อหาของงานนำเสนอที่นี่.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **บันทึกงานนำเสนอในรูปแบบต้นฉบับ**

สำหรับตัวอย่างการตรวจจับไฟล์และสตรีม, พฤติกรรมของงานนำเสนอที่สร้างใหม่, และความแตกต่างระหว่างรูปแบบต้นทางและรูปแบบเอาต์พุต, ดู [Determine the Original Presentation Format](/slides/th/python-net/detect-presentation-source-format/)

ในแอปพลิเคชันการประมวลผลแบบเป็นชุด, รูปแบบอินพุตอาจไม่ทราบล่วงหน้า หลังจากโหลดไฟล์แล้ว ให้อ่านรูปแบบต้นฉบับจากคุณสมบัติ [Presentation.source_format](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/source_format/) ส่งค่าที่ได้จาก [SourceFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/sourceformat/) ไปยัง [SlideUtil.to_save_format](https://reference.aspose.com/slides/th/python-net/aspose.slides.util/slideutil/to_save_format/) เพื่อรับค่า [SaveFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/saveformat/) ที่สอดคล้องกัน, จากนั้นใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/ipresentation/save/) เพื่อเขียนงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างเต็มต่อไปนี้ประมวลผลทุกไฟล์ในโฟลเดอร์อินพุต, ปรับปรุงชื่อเรื่อง, และบันทึกไปยังโฟลเดอร์เอาต์พุตในรูปแบบที่โหลดมา:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format] จะแม็พ PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, และ PowerPoint XML ไปยังรูปแบบการบันทึกงานนำเสนอที่สอดคล้องกัน ซึ่งแม็พเฉพาะรูปแบบต้นฉบับของงานนำเสนอ ไม่ได้ออกแบบให้เลือกรูปแบบการส่งออกเช่น PDF, HTML, TIFF หรือรูปภาพ การส่งค่า [SourceFormat] ที่ไม่รองรับหรือไม่ถูกต้องจะทำให้เกิดข้อยกเว้น

ไฟล์ PPT, PPS, และ POT เก่าจะใช้คอนเทนเนอร์ไบนารีเดียวกัน เมื่อโหลดงานนำเสนอจากสตรีมโดยไม่มีส่วนขยายไฟล์ ไฟล์ PPS หรือ POT อาจถูกระบุเป็น PPT หากต้องการคงรักษาชนิดย่อยเหล่านี้ไว้ ให้เก็บชื่อไฟล์ต้นฉบับหรือเมตาดาต้ารูปแบบแยกต่างหากและใช้เมื่อเลือกชื่อไฟล์และรูปแบบเอาต์พุต

## **บันทึกงานนำเสนอเป็นสตรีม**

เพื่อเขียนงานนำเสนอโดยไม่พึ่งพาพาธไฟล์สุดท้าย ให้ส่งสตรีม [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) ที่เขียนได้และค่า [SaveFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/saveformat/) ไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/ipresentation/save/) วิธีการนี้มีประโยชน์เมื่อเอาต์พุตต้องส่งคืนจากเว็บเซอร์วิส, จัดเก็บในฐานข้อมูล, หรือประมวลผลในหน่วยความจำ

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอใหม่ไปยังสตรีมไฟล์:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **บันทึกงานนำเสนอด้วยประเภทมุมมองที่กำหนดไว้ล่วงหน้า**

คุณสามารถระบุมุมมองที่ PowerPoint จะเปิดงานนำเสนอที่บันทึกไว้เป็นค่าเริ่มต้น ตั้งค่าคุณสมบัติ [ViewProperties.last_view](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/last_view/) เป็นค่า [ViewType](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewtype/) ก่อนบันทึก

ตัวอย่างต่อไปนี้กำหนดให้มุมมอง Slide Master เป็นมุมมองเริ่มต้น:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

เพื่อสร้างไฟล์ PPTX ที่สอดคล้องกับโปรไฟล์ Strict ของ Office Open XML, สร้างอินสแตนซ์ [PptxOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pptxoptions/) แล้วตั้งค่าคุณสมบัติ [conformance](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pptxoptions/conformance/) เป็น `Conformance.ISO_29500_2008_STRICT` จากนั้นส่งอ็อปชันไปยังเมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/ipresentation/save/)

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ในโหมด Zip64**

ไฟล์ ZIP มาตรฐานจำกัดขนาดข้อมูลที่บีบอัดและไม่บีบอัดของแต่ละรายการ, ขนาดรวมของไฟล์ ZIP, และจำนวนรายการ เนื่องจากไฟล์ PPTX เป็นไฟล์ ZIP การนำเสนอที่มีขนาดใหญ่มากอาจเกินขีดจำกัดเหล่านี้ ส่วนขยาย ZIP64 จะเพิ่มขีดจำกัดด้านขนาดและจำนวนรายการที่ใช้ได้

ใช้คุณสมบัติ [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) เพื่อควบคุมว่า Aspose.Slides จะเขียนส่วนขยาย ZIP64 หรือไม่:

- `IF_NECESSARY` ใช้ ZIP64 เฉพาะเมื่องานนำเสนอเกินขีดจำกัด ZIP มาตรฐาน นี่คือโหมดเริ่มต้น
- `NEVER` ปิดการใช้งานส่วนขยาย ZIP64
- `ALWAYS` เขียนส่วนขยาย ZIP64 เสมอ

ตัวอย่างต่อไปนี้เปิดใช้งานส่วนขยาย ZIP64 สำหรับงานนำเสนอเอาต์พุตเสมอ:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
หากใช้ `Zip64Mode.NEVER` และงานนำเสนอไม่สามารถพอดีกับขีดจำกัด ZIP มาตรฐาน, การบันทึกจะทำให้เกิดข้อยกเว้น [PptxException](https://reference.aspose.com/slides/th/python-net/aspose.slides/pptxexception/)
{{% /alert %}}

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ด้วยระดับการบีบอัด**

สำหรับเอาต์พุต PPTX คุณสามารถปรับสมดุลระหว่างความเร็วในการบันทึกและขนาดไฟล์โดยตั้งค่าคุณสมบัติ [PptxOptions.compression_level](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pptxoptions/compression_level/) ตัวนับจำนวน [CompressionLevel] มีค่าดังนี้:

- `NONE` เก็บข้อมูลโดยไม่มีการบีบอัด
- `LEVEL1` ให้การบีบอัดที่เร็วที่สุดและขนาดไฟล์บีบอัดมากที่สุด
- `LEVEL2` ถึง `LEVEL5` ช่วยให้ได้ไฟล์ขนาดเล็กลงโดยยอมรับความเร็วในการบันทึกที่ช้าลงอย่างต่อเนื่อง
- `LEVEL6` สมดุลระหว่างความเร็วและขนาดไฟล์ นี่คือระดับเริ่มต้น
- `LEVEL7` และ `LEVEL8` ให้ความสำคัญกับไฟล์ขนาดเล็กกว่ามากกว่าความเร็วในการบันทึก
- `LEVEL9` ให้การบีบอัดที่แรงที่สุดแต่ต้องใช้เวลาประมวลผลมากที่สุด

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอโดยไม่มีการบีบอัด:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

ตัวอย่างต่อไปนี้ใช้ระดับการบีบอัดสูงสุด:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **บันทึกงานนำเสนอโดยไม่รีเฟรชรูปย่อ**

เมื่องานนำเสนอถูกบันทึกเป็น PPTX, คุณสมบัติ [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) จะควบคุมรูปย่อของเอกสาร:

- `True` สร้างรูปย่อใหม่ระหว่างการบันทึก นี่เป็นค่าเริ่มต้น
- `False` คงรูปย่อเดิมไว้ หากงานนำเสนอไม่มีรูปย่อ Aspose.Slides จะไม่สร้างใหม่

ตัวอย่างต่อไปนี้บันทึกงานนำเสนอโดยไม่รีเฟรชรูปย่อ:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
การปิดการรีเฟรชรูปย่อสามารถลดเวลาที่ต้องใช้ในการบันทึกไฟล์ PPTX ได้
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose มี [PowerPoint Splitter](https://products.aspose.app/slides/th/splitter) ฟรีที่สร้างด้วย Aspose.Slides API ซึ่งสามารถบันทึกสไลด์ที่เลือกจากงานนำเสนอเป็นไฟล์ PPT หรือ PPTX แยกกัน
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการบันทึกแบบเพิ่มทีละส่วนหรือ “บันทึกอย่างเร็ว” หรือไม่?**

ไม่. การบันทึกแต่ละครั้งจะเขียนไฟล์ผลลัพธ์เต็มรูปแบบแทนการอัปเดตเฉพาะส่วนที่เปลี่ยนแปลง

**หลาย Thread สามารถบันทึกอินสแตนซ์ Presentation เดียวกันได้หรือไม่?**

ไม่. อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) [is not thread-safe](/slides/th/python-net/multithreading/) การเข้าถึงและบันทึกแต่ละอินสแตนซ์ควรทำจาก Thread เพียงหนึ่งเท่านั้น

**ลิงก์และไฟล์ที่เชื่อมภายนอกจะเกิดอะไรขึ้นเมื่อบันทึกงานนำเสนอ?**

[Hyperlinks](/slides/th/python-net/manage-hyperlinks/) จะคงอยู่ในงานนำเสนอ Aspose.Slides ไม่คัดลอกไฟล์ที่เชื่อมภายนอก ดังนั้นงานนำเสนอที่บันทึกไว้ต้องสามารถเข้าถึงตำแหน่งไฟล์เหล่านั้นได้

**ฉันสามารถบันทึกเมตาดาต้าเอกสาร เช่น ผู้เขียน, ชื่อเรื่อง, บริษัท, และวันที่สร้างได้หรือไม่?**

ได้. ตั้งค่าคุณสมบัติเอกสารที่เหมาะสม [/slides/th/python-net/presentation-properties/] ก่อนบันทึก และ Aspose.Slides จะเขียนค่าต่าง ๆ ลงในไฟล์เอาต์พุต