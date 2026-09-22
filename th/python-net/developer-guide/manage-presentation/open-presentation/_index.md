---
title: เปิดงานนำเสนอใน Python
linktitle: เปิดงานนำเสนอ
type: docs
weight: 20
url: /th/python-net/open-presentation/
keywords:
- เปิด PowerPoint
- เปิดงานนำเสนอ
- เปิด PPTX
- เปิด PPT
- เปิด ODP
- โหลดงานนำเสนอ
- โหลด PPTX
- โหลด PPT
- โหลด ODP
- งานนำเสนอที่ป้องกันด้วยรหัสผ่าน
- งานนำเสนอขนาดใหญ่
- ทรัพยากรภายนอก
- วัตถุไบนารี
- Python
- Aspose.Slides
description: "เรียนรู้วิธีเปิดงานนำเสนอ PowerPoint และ OpenDocument ใน Python, จัดหารหัสผ่านเปิด, และลดการใช้หน่วยความจำด้วย Aspose.Slides for Python via .NET."
---
## **บทนำ**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/th/python-net/) สามารถโหลดงานนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกในรูปแบบเดิมหรือรูปแบบที่รองรับอื่นได้

Loading behavior can be customized through the [LoadOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/) class. For example, you can supply an opening password, keep large binary objects outside memory, or omit embedded binary data.

## **เปิดงานนำเสนอ**

After loading a file or stream, you can [ตรวจสอบรูปแบบเดิมของงานนำเสนอ](/slides/th/python-net/detect-presentation-source-format/) to choose how your application processes it.

To open an existing presentation, pass its file path to the [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) constructor. Use a `with` statement so that file handles, temporary data, and other resources are released promptly.

The following Python example shows how to open a presentation and get its slide count:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **เปิดงานนำเสนอที่ป้องกันด้วยรหัสผ่าน**

An opening password encrypts presentation content. To load the complete presentation, assign the correct password to [LoadOptions.password](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/password/) and pass the options to the [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) constructor. Loading fails when the password is missing or incorrect.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

For password detection, validation, and encryption workflows, see [การป้องกันงานนำเสนอด้วยรหัสผ่าน](/slides/th/python-net/password-protected-presentation/). If an encrypted presentation was deliberately saved with public document properties, those properties can be read without a password; see [การจัดการคุณสมบัติงานนำเสนอ](/slides/th/python-net/presentation-properties/).

## **เปิดงานนำเสนอขนาดใหญ่**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/blob_management_options/) ควบคุมว่าการ Aspose.Slides จัดการวัตถุไบนารีขนาดใหญ่ (เช่น รูปภาพ, เสียง, วิดีโอ) อย่างไร คุณสามารถทำให้ไฟล์ต้นทางถูกล็อค อนุญาตไฟล์ชั่วคราว และจำกัดปริมาณข้อมูล BLOB ที่เก็บไว้ในหน่วยความจำ

This Python code demonstrates loading a large presentation (for example, 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
ด้วย `PresentationLockingBehavior.KEEP_LOCKED` ไฟล์ต้นทางจะยังคงถูกล็อคจนกว่าอ็อบเจกต์ `Presentation` จะถูกกำจัด อย่าย้าย เขียนทับ หรือ ลบไฟล์ต้นทางในขณะที่อ็อบเจกต์ยังคงอยู่

Aspose.Slides อาจคัดลอกเนื้อหาของสตรีมอินพุตขณะโหลด สำหรับงานนำเสนอขนาดใหญ่ การใช้เส้นทางไฟล์จึงมักมีประสิทธิภาพมากกว่าสตรีม ดูที่ [จัดการ BLOBs](/slides/th/python-net/manage-blob/) เพื่อดูตัวเลือกการจัดเก็บและการจัดการหน่วยความจำเพิ่มเติม.
{{% /alert %}}

## **โหลดงานนำเสนอโดยไม่มีวัตถุไบนารีฝังอยู่**

A presentation may contain embedded binary data that an application does not need or does not want to retain. Examples include:

- โปรเจกต์ VBA ที่เข้าถึงได้ผ่าน [Presentation.vba_project](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/vba_project/);
- ข้อมูล OLE ฝังอยู่ที่เข้าถึงได้ผ่าน [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/th/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- ข้อมูลการควบคุม ActiveX ที่เข้าถึงได้ผ่าน [Control.active_x_control_binary](https://reference.aspose.com/slides/th/python-net/aspose.slides/control/active_x_control_binary/).

Set [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) to `True` to remove this binary data while loading. Save the loaded presentation to persist the sanitized result.

This option reduces exposure to unwanted embedded payloads, but it is not a complete malware-detection or content-sanitization system.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันจะทราบได้อย่างไรว่าไฟล์เสียและไม่สามารถเปิดได้?**

Aspose.Slides จะโยนข้อยกเว้นการพาร์สหรือรูปแบบระหว่างการโหลด ให้จัดการความล้มเหลวนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้องเพื่อให้แอปพลิเคชันสามารถรายงานสาเหตุได้อย่างแม่นยำ.

**เกิดอะไรขึ้นหากฟอนต์ที่จำเป็นหายไป?**

งานนำเสนอยังคงสามารถโหลดได้ แต่การเรนเดอร์และการส่งออกอาจใช้ฟอนต์ทดแทน คุณสามารถ [กำหนดค่าการแทนที่ฟอนต์](/slides/th/python-net/font-substitution/) หรือ [จัดหาฟอนต์แบบกำหนดเอง](/slides/th/python-net/custom-font/) เพื่อทำให้ผลลัพธ์คาดการณ์ได้ง่ายขึ้น.

**การโหลดงานนำเสนอจะโหลดสื่อที่ฝังอยู่ด้วยหรือไม่?**

เสียงและวิดีโอที่ฝังอยู่จะสามารถเข้าถึงได้ผ่านโมเดลอ็อบเจกต์ของงานนำเสนอ ทรัพยากรภายนอกจะถูกเรียกตามพฤติกรรมการโหลดทรัพยากรเริ่มต้นและอาจไม่สามารถใช้ได้หากไม่สามารถเข้าถึงตำแหน่งของมัน.