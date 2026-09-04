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
- งานนำเสนอที่ป้องกัน
- งานนำเสนอขนาดใหญ่
- ทรัพยากรภายนอก
- วัตถุไบนารี
- Python
- Aspose.Slides
description: "เรียนรู้วิธีเปิดงานนำเสนอ PowerPoint และ OpenDocument ด้วย Python, ระบุรหัสผ่านการเปิด, และลดการใช้หน่วยความจำด้วย Aspose.Slides for Python via .NET."
---
## **บทนำ**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/th/python-net/) สามารถโหลดงานนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกในรูปแบบเดิมหรือรูปแบบที่รองรับอื่นๆ

พฤติกรรมการโหลดสามารถปรับแต่งได้ผ่านคลาส [LoadOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถระบุรหัสผ่านสำหรับการเปิดไฟล์ เก็บวัตถุไบนารีขนาดใหญ่ให้อยู่ไน่นอกหน่วยความจำ หรือไม่รวมข้อมูลไบนารีที่ฝังไว้

## **เปิดงานนำเสนอ**

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้ส่งพาธไฟล์ไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ใช้คำสั่ง `with` เพื่อให้จัดการไฟล์ แหล่งข้อมูลชั่วคราว และทรัพยากรอื่นๆ ได้อย่างทันที

ตัวอย่าง Python ด้านล่างแสดงวิธีการเปิดงานนำเสนอและรับจำนวนสไลด์:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **เปิดงานนำเสนอที่ป้องกันด้วยรหัสผ่าน**

รหัสผ่านสำหรับการเปิดไฟล์จะเข้ารหัสเนื้อหาของงานนำเสนอ เพื่อโหลดงานนำเสนอทั้งหมด ให้กำหนดรหัสผ่านที่ถูกต้องให้กับ [LoadOptions.password](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/password/) แล้วส่งอ็อบเจ็กต์ตัวเลือกไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) การโหลดจะล้มเหลือหากไม่มีรหัสผ่านหรือรหัสผ่านไม่ถูกต้อง

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และกระบวนการเข้ารหัส ดูที่ [Password-Protect Presentations](/slides/th/python-net/password-protected-presentation/) หากงานนำเสนอที่ถูกเข้ารหัสถูกบันทึกโดยเจตนาพร้อมคุณสมบัติเอกสารสาธารณะ คุณสมบัติเหล่านั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดูที่ [Manage Presentation Properties](/slides/th/python-net/presentation-properties/)

## **เปิดงานนำเสนอขนาดใหญ่**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/blob_management_options/) ควบคุมวิธีที่ Aspose.Slides จัดการกับวัตถุไบนารีขนาดใหญ่เช่นรูปภาพ, เสียง, และวิดีโอ คุณสามารถทำให้ไฟล์ต้นทางล็อกไว้, อนุญาตไฟล์ชั่วคราว, และจำกัดจำนวนข้อมูล BLOB ที่เก็บไว้ในหน่วยความจำ

โค้ด Python นี้แสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

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
ด้วย `PresentationLockingBehavior.KEEP_LOCKED` ไฟล์ต้นทางจะยังคงถูกล็อกจนกว่าอ็อบเจ็กต์ `Presentation` จะถูกทำลาย อย่าเคลื่อนย้าย, เขียนทับ หรือ ลบไฟล์ต้นทางขณะอ็อบเจ็กต์นั้นยังคงมีอยู่

Aspose.Slides อาจคัดลอกเนื้อหาของสตรีมอินพุตในระหว่างการโหลด สำหรับงานนำเสนอขนาดใหญ่ การใช้พาธไฟล์จึงมักมีประสิทธิภาพดีกว่าการใช้สตรีม ดูที่ [Manage BLOBs](/slides/th/python-net/manage-blob/) สำหรับตัวเลือกการจัดเก็บและการจัดการหน่วยความจำเพิ่มเติม
{{% /alert %}}

## **โหลดงานนำเสนอโดยไม่มีวัตถุไบนารีฝังอยู่**

งานนำเสนออาจมีข้อมูลไบนารีฝังอยู่ที่แอปพลิเคชันไม่จำเป็นต้องใช้หรือไม่ต้องการเก็บไว้ ตัวอย่างได้แก่:

- โครงการ VBA, สามารถเข้าถึงได้ผ่าน [Presentation.vba_project](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/vba_project/);
- ข้อมูล OLE ฝัง, สามารถเข้าถึงได้ผ่าน [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/th/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- ข้อมูลควบคุม ActiveX, สามารถเข้าถึงได้ผ่าน [Control.active_x_control_binary](https://reference.aspose.com/slides/th/python-net/aspose.slides/control/active_x_control_binary/).

กำหนดค่า [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) ให้เป็น `True` เพื่อทำการลบข้อมูลไบนารีนี้ขณะโหลด บันทึกงานนำเสนอที่โหลดแล้วเพื่อเก็บผลลัพธ์ที่ทำความสะอาด

ตัวเลือกนี้ช่วยลดความเสี่ยงจากข้อมูลฝังที่ไม่ต้องการ แต่ไม่ได้เป็นระบบตรวจจับมัลแวร์หรือการทำความสะอาดเนื้อหาแบบเต็มรูปแบบ

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**คุณจะทราบได้อย่างไรว่าไฟล์เสียหายและไม่สามารถเปิดได้?**

Aspose.Slides จะโยงข้อยกเว้นการวิเคราะห์หรือรูปแบบระหว่างการโหลด ให้จัดการความล้มเหลือนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้อง เพื่อให้แอปพลิเคชันสามารถรายงานสาเหตุได้อย่างแม่นยำ

**จะเกิดอะไรขึ้นหากฟอนต์ที่จำเป็นหายไป?**

งานนำเสนอยังสามารถโหลดได้ แต่การเรนเดอร์และการส่งออกอาจใช้ฟอนต์ทดแทน คุณสามารถ [configure font substitution](/slides/th/python-net/font-substitution/) หรือ [provide custom fonts](/slides/th/python-net/custom-font/) เพื่อทำให้ผลลัพธ์คาดการณ์ได้มากขึ้น

**การโหลดงานนำเสนอจะโหลดสื่อที่ฝังอยู่ด้วยหรือไม่?**

เสียงและวิดีโอที่ฝังอยู่จะเข้าถึงได้ผ่านโมเดลอ็อบเจ็กต์ของงานนำเสนอ แหล่งทรัพยากรภายนอกจะถูกจัดการตามพฤติกรรมการโหลดทรัพยากรเริ่มต้น และอาจไม่พร้อมใช้งานหากไม่สามารถเข้าถึงตำแหน่งของมันได้