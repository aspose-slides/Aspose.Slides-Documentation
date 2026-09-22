---
title: เปิดงานนำเสนอใน Python ผ่าน Java
linktitle: เปิดงานนำเสนอ
type: docs
weight: 20
url: /th/python-java/open-presentation/
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
- งานนำเสนอที่ได้รับการป้องกัน
- งานนำเสนอขนาดใหญ่
- ทรัพยากรภายนอก
- อ็อบเจ็กต์ไบนารี
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเปิดงานนำเสนอ PowerPoint และ OpenDocument ใน Python ผ่าน Java, ตั้งรหัสผ่านสำหรับการเปิด, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **บทนำ**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/th/python-java/) สามารถโหลดงานนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากที่โหลดงานนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกในรูปแบบเดิมหรือรูปแบบที่รองรับอื่นได้.

พฤติกรรมการโหลดสามารถปรับแต่งได้ผ่านคลาส [LoadOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถกำหนดรหัสผ่านสำหรับการเปิด, เก็บอ็อบเจ็กต์ไบนารีขนาดใหญ่ไว้ภายนอกหน่วยความจำ Java heap, ควบคุมทรัพยากรภายนอก หรือละเว้นข้อมูลไบนารีที่ฝังอยู่.

## **เปิดงานนำเสนอ**

หลังจากโหลดไฟล์หรือสตรีมแล้ว คุณสามารถ [กำหนดรูปแบบงานนำเสนอเดิมของมัน](/slides/th/python-java/detect-presentation-source-format/) เพื่อเลือกวิธีที่แอปพลิเคชันของคุณจะประมวลผลมัน.

เพื่อเปิดงานนำเสนอที่มีอยู่แล้ว ให้ส่งพาธไฟล์ไปยังตัวสร้าง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) หลังจากใช้เสร็จควรทำการจัดเก็บ (Dispose) งานนำเสนอเพื่อให้ตัวจัดการไฟล์ ข้อมูลชั่วคราว และทรัพยากรอื่นๆ ถูกปล่อยออกอย่างเร็ว.

ตัวอย่าง Python ต่อไปนี้แสดงวิธีเปิดงานนำเสนอและรับจำนวนสไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **เปิดงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน**

รหัสผ่านสำหรับการเปิดจะทำการเข้ารหัสเนื้อหาของงานนำเสนอ เพื่อโหลดงานนำเสนอทั้งหมด ให้ส่งรหัสผ่านที่ถูกต้องไปยัง [LoadOptions.setPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setPassword) และให้ตัวเลือกนั้นกับตัวสร้าง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) การโหลดจะล้มเหลือเมื่อไม่มีรหัสผ่านหรือรหัสผ่านไม่ถูกต้อง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และกระบวนการเข้ารหัส ดูที่ [Password-Protect Presentations](/slides/th/python-java/password-protected-presentation/) หากงานนำเสนอที่เข้ารหัสถูกบันทึกโดยตั้งค่าคุณสมบัติเอกสารสาธารณะไว้ คุณสามารถอ่านคุณสมบัติเหล่านั้นได้โดยไม่ต้องใช้รหัสผ่าน; ดูที่ [Manage Presentation Properties](/slides/th/python-java/presentation-properties/).

## **เปิดงานนำเสนอขนาดใหญ่**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) คืนค่าตัวเลือกที่ควบคุมวิธีที่ Aspose.Slides จัดการกับวัตถุไบนารีขนาดใหญ่ เช่น รูปภาพ, เสียง, และวิดีโอ คุณสามารถทำให้ไฟล์ต้นฉบับล็อคไว้, อนุญาตไฟล์ชั่วคราว, และจำกัดปริมาณข้อมูล BLOB ที่เก็บในหน่วยความจำ.

โค้ด Python ต่อไปนี้แสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
ด้วย [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) ไฟล์ต้นฉบับจะคงถูกล็อคจนกว่าตัวอย่างงานนำเสนอจะถูกจัดเก็บ (Dispose) อย่าย้าย, เขียนทับ, หรือทำลายไฟล์ต้นฉบับขณะที่ตัวอย่างนั้นยังมีชีวิตอยู่.

Aspose.Slides อาจคัดลอกเนื้อหาของสตรีมอินพุตขณะโหลด สำหรับงานนำเสนอขนาดใหญ่ การระบุพาธไฟล์จึงโดยทั่วไปมีประสิทธิภาพมากกว่าการใช้สตรีม ดูที่ [Manage BLOBs](/slides/th/python-java/manage-blob/) สำหรับตัวเลือกการจัดเก็บและการจัดการหน่วยความจำเพิ่มเติม.
{{% /alert %}}

## **ควบคุมทรัพยากรภายนอก**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) ยอมรับ JPype proxy ที่ทำตามอินเทอร์เฟซ callback การโหลดทรัพยากรของ Java callback สามารถให้ข้อมูลทดแทน, เปลี่ยนเส้นทางของทรัพยากร, ใช้ตัวโหลดเริ่มต้น, หรือข้ามทรัพยากรได้ สิ่งนี้มีประโยชน์เมื่องานนำเสนอมีภาพภายนอกที่ต้องถูกแก้ไขตามกฎความปลอดภัยหรือการจัดเก็บของแอปพลิเคชัน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **โหลดงานนำเสนอโดยไม่มีอ็อบเจ็กต์ไบนารีฝังอยู่**

งานนำเสนออาจมีข้อมูลไบนารีฝังอยู่ที่แอปพลิเคชันไม่จำเป็นต้องใช้หรือไม่ต้องการเก็บไว้ ตัวอย่างได้แก่:

- โปรเจ็กต์ VBA, สามารถเข้าถึงได้ผ่าน [Presentation.getVbaProject](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getVbaProject);
- ข้อมูล OLE ฝัง, สามารถเข้าถึงได้ผ่าน [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ข้อมูลควบคุม ActiveX, สามารถเข้าถึงได้ผ่าน [Control.getActiveXControlBinary](https://reference.aspose.com/slides/th/python-java/aspose.slides/control/#getActiveXControlBinary).

ตั้งค่า [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) เป็น `True` เพื่อเอาข้อมูลไบนารีนี้ออกขณะโหลด บันทึกงานนำเสนอที่โหลดแล้วเพื่อบันทึกผลลัพธ์ที่ทำความสะอาดแล้ว

ตัวเลือกนี้ลดความเสี่ยงจากข้อมูลฝังที่ไม่ต้องการ แต่ไม่ใช่ระบบตรวจจับมัลแวร์หรือทำความสะอาดเนื้อหาอย่างครบถ้วน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**How can I tell that a file is corrupted and cannot be opened?**

Aspose.Slides จะโยนข้อยกเว้นการพาร์สหรือรูปแบบระหว่างการโหลด จัดการความล้มเหลวนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้อง เพื่อให้แอปพลิเคชันสามารถรายงานสาเหตุได้อย่างแม่นยำ.

**What happens if required fonts are missing?**

งานนำเสนอยังสามารถโหลดได้ แต่การเรนเดอร์และการส่งออกอาจใช้ฟอนต์แทน คุณสามารถ [configure font substitution](/slides/th/python-java/font-substitution/) หรือ [provide custom fonts](/slides/th/python-java/custom-font/) เพื่อทำให้ผลลัพธ์คาดเดาได้มากขึ้น.

**Does loading a presentation also load its embedded media?**

เสียงและวิดีโอที่ฝังอยู่จะพร้อมใช้งานผ่านโมเดลอ็อบเจ็กต์ของงานนำเสนอ ทรัพยากรภายนอกจะถูกแก้ไขตามพฤติกรรมการโหลดทรัพยากรที่กำหนดและอาจไม่สามารถเข้าถึงได้หากตำแหน่งของมันไม่สามารถเข้าถึงได้.