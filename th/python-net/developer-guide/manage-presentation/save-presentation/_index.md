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
- รีเฟรช thumbnail
- บันทึกความคืบหน้า
- Python
- Aspose.Slides
description: "ค้นพบวิธีการบันทึกงานนำเสนอใน Python ด้วย Aspose.Slides—ส่งออกเป็น PowerPoint หรือ OpenDocument พร้อมรักษาเลเอาต์, ฟอนท์และเอฟเฟ็กต์."
---
## **ภาพรวม**

[เปิดงานนำเสนอใน Python](/slides/th/python-net/open-presentation/) อธิบายวิธีใช้คลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพื่อเปิดงานนำเสนอ บทความนี้อธิบายวิธีสร้างและบันทึกงานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) มีเนื้อหาของงานนำเสนอ ไม่ว่าคุณจะสร้างงานนำเสนอจากศูนย์หรือแก้ไขงานที่มีอยู่แล้ว คุณจะต้องบันทึกเมื่อทำเสร็จแล้ว ด้วย Aspose.Slides for Python คุณสามารถบันทึกเป็น **ไฟล์** หรือ **สตรีม** บทความนี้อธิบายวิธีต่าง ๆ ในการบันทึกงานนำเสนอ

## **บันทึกงานนำเสนอเป็นไฟล์**

บันทึกงานนำเสนอเป็นไฟล์โดยเรียกเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ส่งชื่อไฟล์และรูปแบบการบันทึกไปยังเมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอด้วย Aspose.Slides for Python

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:
    
    # ทำบางสิ่งบางอย่างที่นี่...

    # บันทึกงานนำเสนอไปยังไฟล์.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **บันทึกงานนำเสนอเป็นสตรีม**

คุณสามารถบันทึกงานนำเสนอเป็นสตรีมได้โดยส่งสตรีมเอาต์พุตไปยังเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) งานนำเสนอสามารถเขียนลงสตรีมหลายประเภท ได้ในตัวอย่างด้านล่าง เราจะสร้างงานนำเสนอใหม่และบันทึกลงสตรีมไฟล์

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # บันทึกงานนำเสนอไปยังสตรีม.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **บันทึกงานนำเสนอด้วยมุมมองที่กำหนดล่วงหน้า**

Aspose.Slides for Python ให้คุณตั้งค่ามุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดงานนำเสนอที่สร้างผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/) ตั้งค่าคุณสมบัติ `last_view` ให้เป็นค่าจาก enumeration [ViewType](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewtype/)

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

Aspose.Slides ให้คุณบันทึกงานนำเสนอในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pptxoptions/) และตั้งค่าคุณสมบัติ conformance เมื่อบันทึก หากคุณตั้งค่า `Conformance.ISO_29500_2008_STRICT` ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML

ตัวอย่างด้านล่างสร้างงานนำเสนอและบันทึกในรูปแบบ Strict Office Open XML

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:
    # บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ด้วยโหมด Zip64**

ไฟล์ Office Open XML เป็นไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดที่ไม่ได้บีบอัดของไฟล์ใด ๆ, ขนาดที่บีบอัดของไฟล์ใด ๆ, และขนาดรวมของไฟล์อาร์ไคฟ์เวอร์ รวมถึงจำกัดจำนวนไฟล์ในอาร์ไคฟ์เวอร์ที่ 65,535 (2^16‑1) ไฟล์ ส่วนส่วนขยายรูปแบบ ZIP64 จะยกขีดจำกัดเหล่านี้เป็น 2^64

คุณสมบัติ [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) ให้คุณเลือกว่าจะใช้ส่วนขยายรูปแบบ ZIP64 เมื่อบันทึกไฟล์ Office Open XML หรือไม่

คุณสมบัตินี้ให้โหมดต่อไปนี้:

- `IF_NECESSARY` ใช้ส่วนขยาย ZIP64 เฉพาะเมื่องานนำเสนอเกินขีดจำกัดข้างต้น นี่คือโหมดเริ่มต้น
- `NEVER` ไม่เคยใช้ส่วนขยาย ZIP64
- `ALWAYS` ใช้ส่วนขยาย ZIP64 เสมอ

โค้ดต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX พร้อมเปิดใช้ส่วนขยายรูปแบบ ZIP64:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
เมื่อบันทึกด้วย `Zip64Mode.NEVER` จะเกิด [PptxException](https://reference.aspose.com/slides/th/python-net/aspose.slides/pptxexception/) หากงานนำเสนอไม่สามารถบันทึกในรูปแบบ ZIP32
{{% /alert %}}

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML ด้วยระดับการบีบอัด**

เมื่อทำงานกับงานนำเสนอขนาดใหญ่ คุณสามารถปรับระดับการบีบอัดเพื่อให้สมดุลระหว่างขนาดไฟล์และเวลาในการประมวลผล ตามความต้องการของคุณ คุณอาจต้องการการประมวลผลที่เร็วขึ้นหรือไฟล์ผลลัพธ์ที่เล็กลง

Aspose.Slides มีคุณสมบัติ [PptxOptions.compression_level](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pptxoptions/compression_level/) ซึ่งให้คุณระบุระดับการบีบอัดที่ใช้เมื่บันทึกงานนำเสนอในรูปแบบ Office Open XML

ระดับการบีบอัดต่อไปนี้พร้อมใช้งาน:

- [**NONE**](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/compressionlevel/): ไม่ทำการบีบอัด ไฟล์จะถูกเก็บไว้ตามเดิม
- [**LEVEL1**](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/compressionlevel/): การบีบอัดที่เร็วที่สุดแต่มีอัตราการบีบอัดต่ำที่สุด
- [**LEVEL2**](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/compressionlevel/): การบีบอัดที่เร็วกว่าและอัตราการบีบอัดดีกว่าเล็กน้อยเมื่อเทียบกับ LEVEL1
- [**LEVEL3**](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/compressionlevel/): ให้การบีบอัดที่ดีกว่า LEVEL2 โดยมีผลกระทบต่อเวลาในการประมวลผลระดับปานกลาง
- [**LEVEL4**](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/compressionlevel/): ให้การบีบอัดที่ดีกว่า LEVEL3
- [**LEVEL5**](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/compressionlevel/): ให้การบีบอัดที่ดีกว่า LEVEL4 พร้อมเพิ่มเวลาในการประมวลผล
- [**LEVEL6**](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/compressionlevel/): การบีบอัดมาตรฐานที่ให้สมดุลที่ดีระหว่างความเร็วในการประมวลผลและขนาดไฟล์ นี่คือ *ระดับการบีบอัดเริ่มต้น*
- [**LEVEL7**](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/compressionlevel/): ให้การบีบอัดที่ดีกว่า LEVEL6 โดยมีการประมวลผลช้าลง
- [**LEVEL8**](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/compressionlevel/): ให้การบีบอัดที่ดีกว่า LEVEL7
- [**LEVEL9**](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/compressionlevel/): การบีบอัดสูงสุด ทำให้ไฟล์มีขนาดเล็กที่สุดแต่ต้องใช้เวลาประมวลผลนานที่สุด

ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX *โดยไม่มีการบีบอัด*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

ตัวอย่างนี้แสดงวิธีบันทึกงานนำเสนอเป็นไฟล์ PPTX ด้วย *การบีบอัดสูงสุด*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **บันทึกงานนำเสนอโดยไม่รีเฟรช thumbnail**

คุณสมบัติ [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) ควบคุมการสร้าง thumbnail เมื่อบันทึกงานนำเสนอเป็น PPTX:

- `True` หากตั้งค่าไว้ thumbnail จะถูกรีเฟรชระหว่างการบันทึก นี่คือค่าเริ่มต้น
- `False` หากตั้งค่าไว้ thumbnail ปัจจุบันจะถูกเก็บไว้ หากงานนำไม่มี thumbnail จะไม่มีการสร้าง

ในโค้ดด้านล่าง งานนำเสนอจะถูกบันทึกเป็น PPTX โดยไม่รีเฟรช thumbnail ของมัน

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
ตัวเลือกนี้ช่วยลดเวลาที่ต้องใช้ในการบันทึกงานนำเสนอในรูปแบบ PPTX
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose ได้พัฒนาแอปพลิเคชัน [PowerPoint Splitter ฟรี](https://products.aspose.app/slides/th/splitter) โดยใช้ API ของตน แอปนี้ช่วยให้คุณแยกงานนำเสนอเป็นหลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รองรับการ "บันทึกเร็ว" (บันทึกแบบเพิ่มส่วน) ที่เขียนเฉพาะการเปลี่ยนแปลงหรือไม่?**

ไม่ การบันทึกจะสร้างไฟล์เป้าหมายเต็มทุกครั้ง; การ "บันทึกเร็ว" แบบเพิ่มส่วนไม่รองรับ

**สามารถบันทึกอินสแตนซ์ Presentation เดียวกันจากหลายเธรดได้อย่างปลอดภัยหรือไม่?**

ไม่ อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) [ไม่ปลอดภัยต่อหลายเธรด](/slides/th/python-net/multithreading/) ; ควรบันทึกจากเธรดเดียว

**อะไรเกิดขึ้นกับลิงก์ไฮเปอร์ลิงก์และไฟล์ที่เชื่อมโยงภายนอกเมื่อบันทึก?**

[Hyperlinks](/slides/th/python-net/manage-hyperlinks/) จะถูกเก็บไว้ ไฟล์ที่เชื่อมโยงภายนอก (เช่น วิดีโอที่ใช้เส้นทางสัมพันธ์) จะไม่ถูกคัดลอกโดยอัตโนมัติ — โปรดตรวจสอบให้แน่ใจว่าเส้นทางที่อ้างอิงยังคงเข้าถึงได้

**ฉันสามารถตั้งค่า/บันทึกข้อมูลเมตาดาต้าเอกสาร (ผู้เขียน, ชื่อเรื่อง, บริษัท, วันที่) ได้หรือไม่?**

ได้ สนับสนุน [คุณสมบัติเอกสารมาตรฐาน](/slides/th/python-net/presentation-properties/) และจะถูกเขียนลงไฟล์เมื่อบันทึก