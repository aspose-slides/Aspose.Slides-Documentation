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
- วัตถุไบต์
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเปิดงานนำเสนอ PowerPoint และ OpenDocument ใน Python ผ่าน Java, กำหนดรหัสผ่านเปิดไฟล์, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **บทนำ**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/th/python-java/) สามารถโหลดไฟล์งานนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดไฟล์งานนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกในรูปแบบดั้งเดิมหรือรูปแบบที่รองรับอื่นได้

พฤติกรรมการโหลดสามารถปรับแต่งได้โดยใช้คลาส [LoadOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถกำหนดรหัสผ่านเปิดไฟล์ เก็บวัตถุไบต์ขนาดใหญ่ไว้ภายนอกหน่วยความจำ heap ของ Java ควบคุมทรัพยากรภายนอก หรือละเว้นข้อมูลไบต์ที่ฝังอยู่

## **เปิดงานนำเสนอ**

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้ส่งพาธไฟล์ไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ปล่อยงานนำเสนอเมื่อใช้งานเสร็จเพื่อให้ตัวจัดการไฟล์ ข้อมูลชั่วคราว และทรัพยากรอื่น ๆ ถูกปล่อยออกอย่างทันที

ตัวอย่าง Python ด้านล่างแสดงวิธีเปิดงานนำเสนอและรับจำนวนสไลด์:

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

รหัสผ่านเปิดไฟล์จะเข้ารหัสเนื้อหาของงานนำเสนอ เพื่อโหลดงานนำเสนอเต็มรูปแบบ ให้ส่งรหัสผ่านที่ถูกต้องไปยังเมธอด [LoadOptions.setPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setPassword) แล้วส่งตัวเลือกนั้นไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) การโหลดจะล้มเหลือเมื่อไม่มีรหัสผ่านหรือรหัสผ่านไม่ถูกต้อง

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

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และกระบวนการเข้ารหัส ดูที่ [Password-Protect Presentations](/slides/th/python-java/password-protected-presentation/) หากงานนำเสนอที่เข้ารหัสถูกบันทึกอย่างตั้งใจพร้อมคุณสมบัติเอกสารสาธารณะ คุณสมบัติเหล่านั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดูที่ [Manage Presentation Properties](/slides/th/python-java/presentation-properties/)

## **เปิดงานนำเสนอขนาดใหญ่**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) คืนค่าตัวเลือกที่ควบคุมว่า Aspose.Slides จะจัดการวัตถุไบต์ขนาดใหญ่ (เช่น รูปภาพ, เสียง, วีดีโอ) อย่างไร คุณสามารถทำให้ไฟล์ต้นแหล่งถูกล็อค อนุญาตไฟล์ชั่วคราว และจำกัดปริมาณข้อมูล BLOB ที่เก็บไว้ในหน่วยความจำ

ตัวอย่างโค้ด Python ด้านล่างแสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

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
ด้วย [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) ไฟล์ต้นแหล่งจะยังคงถูกล็อคจนกว่าจะปล่อยอินสแตนซ์ของงานนำเสนอ อย่าย้าย ทับ หรือทำลายไฟล์ต้นแหล่งขณะที่อินสแตนซ์ยังอยู่

Aspose.Slides อาจคัดลอกเนื้อหาของสตรีมอินพุตขณะโหลด สำหรับงานนำเสนอขนาดใหญ่ การใช้พาธไฟล์จึงมักมีประสิทธิภาพดีกว่าสตรีม ดูที่ [Manage BLOBs](/slides/th/python-java/manage-blob/) เพื่อดูตัวเลือกเพิ่มเติมเกี่ยวกับการจัดเก็บและการจัดการหน่วยความจำ
{{% /alert %}}

## **ควบคุมทรัพยากรภายนอก**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) รับพร็อกซี่ JPype ที่ดำเนินการตามอินเทอร์เฟซการเรียกกลับการโหลดทรัพยากรของ Java คำเรียกกลับนี้สามารถให้ข้อมูลทดแทน เปลี่ยนเส้นทางทรัพยากร ใช้ตัวโหลดเริ่มต้น หรือข้ามทรัพยากร ซึ่งเป็นประโยชน์เมื่องานนำมีรูปภาพภายนอกที่ต้องแก้ไขตามกฎความปลอดภัยหรือการจัดเก็บเฉพาะแอปพลิเคชัน

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

## **โหลดงานนำเสนอโดยไม่มีวัตถุไบต์ที่ฝังอยู่**

งานนำเสนออาจมีข้อมูลไบต์ที่ฝังอยู่ซึ่งแอปพลิเคชันไม่จำเป็นต้องใช้หรือไม่ต้องการเก็บ ตัวอย่างได้แก่:

- โครงการ VBA ที่เข้าถึงได้ผ่าน [Presentation.getVbaProject](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getVbaProject);
- ข้อมูล OLE ที่ฝังอยู่ที่เข้าถึงได้ผ่าน [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ข้อมูลคอนโทรล ActiveX ที่เข้าถึงได้ผ่าน [Control.getActiveXControlBinary](https://reference.aspose.com/slides/th/python-java/aspose.slides/control/#getActiveXControlBinary).

ตั้งค่า [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) เป็น `True` เพื่อเอาข้อมูลไบต์ที่ฝังอยู่เหล่านี้ออกขณะโหลด บันทึกงานนำเสนอที่โหลดแล้วเพื่อให้ผลลัพธ์ที่ทำความสะอาดถูกเก็บไว้

ตัวเลือกนี้ลดความเสี่ยงต่อการเจอpayload ที่ฝังอยู่โดยไม่ต้องการ แต่ไม่ได้เป็นระบบตรวจจับมัลแวร์หรือทำความสะอาดเนื้อหาที่สมบูรณ์

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

**ฉันจะทราบได้อย่างไรว่าไฟล์เสียหายและเปิดไม่ได้?**

Aspose.Slides จะทำการโยนข้อยกเว้นการพาร์สหรือรูปแบบในระหว่างการโหลด ให้จัดการความล้มเหลือนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้อง เพื่อให้แอปพลิเคชันสามารถรายงานสาเหตุได้อย่างแม่นยำ

**จะเกิดอะไรขึ้นหากฟอนต์ที่จำเป็นหายไป?**

งานนำเสนอยังคงโหลดได้ แต่การเรนเดอร์และการส่งออกอาจแทนที่ฟอนต์ได้ คุณสามารถ [กำหนดค่าการแทนที่ฟอนต์](/slides/th/python-java/font-substitution/) หรือ [จัดหา ฟอนต์ที่กำหนดเอง](/slides/th/python-java/custom-font/) เพื่อทำให้ผลลัพธ์คาดเดาได้มากขึ้น

**การโหลดงานนำเสนอจะทำให้มีการโหลดสื่อที่ฝังอยู่ด้วยหรือไม่?**

เสียงและวิดีโอที่ฝังอยู่จะพร้อมใช้งานผ่านโมเดลวัตถุของงานนำเสนอ ทรัพยากรภายนอกจะถูกแก้ไขตามพฤติกรรมการโหลดทรัพยากรที่กำหนด และอาจไม่พร้อมใช้หากไม่สามารถเข้าถึงตำแหน่งที่ตั้งได้