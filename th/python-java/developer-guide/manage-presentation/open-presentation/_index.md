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
- งานนำเสนอที่ป้องกัน
- งานนำเสนอขนาดใหญ่
- แหล่งทรัพยากรภายนอก
- วัตถุไบนารี
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเปิดงานนำเสนอ PowerPoint และ OpenDocument ใน Python ผ่าน Java, จัดหารหัสผ่านเปิดไฟล์, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **บทนำ**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/th/python-java/) สามารถโหลดงานนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกเป็นรูปแบบเดิมหรือรูปแบบอื่นที่รองรับ

พฤติกรรมการโหลดสามารถปรับแต่งได้ผ่านคลาส [LoadOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถระบุรหัสผ่านเปิดไฟล์, เก็บวัตถุไบนารีขนาดใหญ่ไว้ภายนอกหน่วยความจำ Java heap, ควบคุมทรัพยากรภายนอก, หรือละเว้นข้อมูลไบนารีที่ฝังอยู่

## **เปิดงานนำเสนอ**

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้ส่งเส้นทางไฟล์ไปยังคอนสตรักเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) แล้วทำการ Dispose งานนำเสนอหลังการใช้งานเพื่อให้ตัวจับไฟล์ ข้อมูลชั่วคราว และทรัพยากรอื่น ๆ ถูกปล่อยออกอย่างรวดเร็ว

ตัวอย่าง Python ต่อไปนี้แสดงวิธีการเปิดงานนำเสนอและรับจำนวนสไลด์:

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

รหัสผ่านเปิดไฟล์จะเข้ารหัสเนื้อหาของงานนำเสนอ เพื่อโหลดงานนำเสนอเต็มรูปแบบ ให้ส่งรหัสผ่านที่ถูกต้องไปยัง [LoadOptions.setPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setPassword) แล้วส่งออปชันเหล่านั้นไปยังคอนสตรักเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) หากรหัสผ่านหายไปหรือไม่ถูกต้อง การโหลดจะล้มเหลว

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

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และกระบวนการเข้ารหัส ดูที่ [Password-Protect Presentations](/slides/th/python-java/password-protected-presentation/) หากงานนำเสนอที่เข้ารหัสถูกบันทึกโดยเจตนาพร้อมคุณสมบัติเอกสารสาธารณะ คุณสมบัตินั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดูที่ [Manage Presentation Properties](/slides/th/python-java/presentation-properties/)

## **เปิดงานนำเสนอขนาดใหญ่**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) คืนค่าออปชันที่ควบคุมการที่ Aspose.Slides จัดการกับ Binary Large Object เช่น รูปภาพ เสียง และวิดีโอ คุณสามารถล็อกไฟล์ต้นฉบับ, อนุญาตไฟล์ชั่วคราว, และจำกัดจำนวนข้อมูล BLOB ที่เก็บไว้ในหน่วยความจำ

โค้ด Python ต่อไปนี้แสดงวิธีการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

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
โดยใช้ [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) ไฟล์ต้นฉบับจะยังคงถูกล็อกจนกว่าหนึ่งอินสแตนซ์ของงานนำเสนอจะถูก Dispose อย่าย้าย เขียนทับ หรือ ลบไฟล์ต้นฉบับในขณะที่อินสแตนซ์นั้นยังคงอยู่

Aspose.Slides อาจคัดลอกเนื้อหาของสตรีมอินพุตในระหว่างการโหลด สำหรับงานนำเสนอขนาดใหญ่ ดังนั้นการใช้เส้นทางไฟล์มักจะมีประสิทธิภาพมากกว่าสตรีม ดูที่ [Manage BLOBs](/slides/th/python-java/manage-blob/) เพื่อดูออปชันเพิ่มเติมเกี่ยวกับการจัดเก็บและการจัดการหน่วยความจำ
{{% /alert %}}

## **ควบคุมทรัพยากรภายนอก**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) รับ JPype proxy ที่ทำการ implement อินเทอร์เฟซ callback การโหลดทรัพยากรของ Java Callback นี้สามารถให้ข้อมูลทดแทน เปลี่ยนเส้นทางทรัพยากร ใช้ตัวโหลดเริ่มต้น หรือข้ามทรัพยากรได้ ซึ่งเป็นประโยชน์เมื่องานนำเสนอมีรูปภาพภายนอกที่ต้องแก้ไขตามกฎความปลอดภัยหรือการจัดเก็บของแอปพลิเคชัน

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

## **โหลดงานนำเสนอโดยไม่มีวัตถุไบนารีฝังอยู่**

งานนำเสนออาจมีข้อมูลไบนารีฝังอยู่ที่แอปพลิเคชันไม่จำเป็นหรือไม่ต้องการเก็บ ตัวอย่างได้แก่:

- โครงการ VBA, สามารถเข้าถึงได้ผ่าน [Presentation.getVbaProject](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getVbaProject);
- ข้อมูล OLE ฝังอยู่, สามารถเข้าถึงได้ผ่าน [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ข้อมูลควบคุม ActiveX, สามารถเข้าถึงได้ผ่าน [Control.getActiveXControlBinary](https://reference.aspose.com/slides/th/python-java/aspose.slides/control/#getActiveXControlBinary).

ตั้งค่า [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) เป็น `True` เพื่อเอาข้อมูลไบนารีนี้ออกขณะโหลด จากนั้นบันทึกงานนำเสนอที่โหลดแล้วเพื่อเก็บผลลัพธ์ที่ทำความสะอาดไว้

ออปชันนี้ลดความเสี่ยงจาก payload ฝังที่ไม่ต้องการ แต่ไม่ได้เป็นระบบตรวจหามัลแวร์หรือทำความสะอาดเนื้อหาอย่างครบถ้วน

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

**ฉันจะทราบได้อย่างไรว่าไฟล์เสียและไม่สามารถเปิดได้?**

Aspose.Slides จะทำการโยนข้อยกเว้นการพาร์เซอร์หรือรูปแบบระหว่างการโหลด ให้จัดการความล้มเหลวนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้อง เพื่อให้แอปพลิเคชันสามารถรายงานสาเหตุได้อย่างแม่นยำ

**จะเกิดอะไรขึ้นหากฟอนต์ที่ต้องการขาดหาย?**

งานนำเสนอยังคงสามารถโหลดได้ แต่การเรนเดอร์และการส่งออกอาจแทนที่ฟอนต์ คุณสามารถ [configure font substitution](/slides/th/python-java/font-substitution/) หรือ [provide custom fonts](/slides/th/python-java/custom-font/) เพื่อทำให้ผลลัพธ์คาดเดาได้มากขึ้น

**การโหลดงานนำเสนอจะโหลดสื่อที่ฝังอยู่ด้วยหรือไม่?**

เสียงและวิดีโอที่ฝังอยู่จะสามารถเข้าถึงได้ผ่านโมเดลอ็อบเจ็กต์ของงานนำเสนอ ทรัพยากรภายนอกจะถูกแก้ไขตามพฤติกรรมการโหลดทรัพยากรที่กำหนดและอาจไม่พร้อมใช้งานหากไม่สามารถเข้าถึงตำแหน่งที่ตั้งของมันได้