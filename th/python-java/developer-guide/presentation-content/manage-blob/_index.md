---
title: จัดการ Presentation BLOBs ใน Python ผ่าน Java เพื่อการใช้หน่วยความจำที่มีประสิทธิภาพ
linktitle: จัดการ BLOB
type: docs
weight: 10
url: /th/python-java/manage-blob/
keywords:
- วัตถุขนาดใหญ่
- รายการขนาดใหญ่
- ไฟล์ขนาดใหญ่
- เพิ่ม BLOB
- ส่งออก BLOB
- เพิ่มรูปภาพเป็น BLOB
- ลดการใช้หน่วยความจำ
- การใช้หน่วยจำ
- งานนำเสนอขนาดใหญ่
- ไฟล์ชั่วคราว
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการข้อมูล BLOB ใน Aspose.Slides สำหรับ Python ผ่าน Java เพื่อทำให้การดำเนินการไฟล์ PowerPoint และ OpenDocument มีประสิทธิภาพในการจัดการงานนำเสนอ"
---
## **ภาพรวม**

Aspose.Slides ให้การจัดการแบบ BLOB สำหรับข้อมูลไบนารีขนาดใหญ่ในงานนำเสนอเพื่อช่วยลดการใช้หน่วยความจำเมื่อทำงานกับภาพขนาดใหญ่, เสียง, วิดีโอ, และไฟล์งานนำเสนอ

บทความนี้แสดงวิธีใช้การประมวลผลแบบ BLOB เพื่อเพิ่มสื่อขนาดใหญ่ในงานนำเสนอ, ส่งออกสื่อขนาดใหญ่จากงานนำเสนอ, และโหลดงานนำเสนอขนาดใหญ่อย่างมีประสิทธิภาพ นอกจากนี้ยังอธิบายว่าการใช้ไฟล์ชั่วคราวระหว่างการประมวลผลทำได้อย่างไรและวิธีการเปลี่ยนโฟลเดอร์ที่ใช้เก็บไฟล์เหล่านั้น

## **เกี่ยวกับ BLOB**

**BLOB** (**Binary Large Object**) ปกติจะหมายถึงรายการขนาดใหญ่ (รูปภาพ, งานนำเสนอ, เอกสาร, หรือสื่อ) ที่บันทึกในรูปแบบไบนารี

Aspose.Slides for Python via Java ให้คุณใช้ BLOB สำหรับอ็อบเจกต์ในลักษณะที่ลดการใช้หน่วยความจำเมื่อไฟล์ขนาดใหญ่เข้ามาเกี่ยวข้อง

{{% alert color="info" title="Note" %}}
เพื่อหลีกเลี่ยงข้อจำกัดบางประการเมื่อทำงานกับสตรีม, Aspose.Slides อาจคัดลอกเนื้อหาของสตรีม การโหลดงานนำเสนอขนาดใหญ่ผ่านสตรีมจะทำให้เกิดการคัดลอกเนื้อหาของงานนำเสนอและทำให้การโหลดช้า ดังนั้นเมื่อคุณต้องการโหลดงานนำเสนอขนาดใหญ่ เราแนะนำอย่างยิ่งให้ใช้เส้นทางไฟล์งานนำเสนอแทนการใช้สตรีม
{{% /alert %}}

## **ใช้ BLOB เพื่อลดการใช้หน่วยความจำ**

### **เพิ่มไฟล์ขนาดใหญ่ไปยังงานนำเสนอโดยใช้ BLOB**

[Aspose.Slides](/slides/th/python-java/) for Python via Java ให้คุณเพิ่มไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์วิดีโอขนาดใหญ่) ผ่านกระบวนการที่ใช้ BLOB เพื่อลดการใช้หน่วยความจำ

โค้ด Python นี้แสดงวิธีเพิ่มไฟล์วิดีโอขนาดใหญ่ผ่านกระบวนการ BLOB ไปยังงานนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# สร้างงานนำเสนอใหม่ที่วิดีโอจะถูกเพิ่มเข้าไป.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # ล็อคสตรีมไว้เนื่องจากเราไม่ได้ตั้งใจจะเข้าถึงไฟล์วิดีโอ.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # บันทึกงานนำเสนอในขณะที่ทำให้การใช้หน่วยความจำน้อยลง.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **ส่งออกไฟล์ขนาดใหญ่จากงานนำเสนอโดยใช้ BLOB**
Aspose.Slides for Python via Java ให้คุณส่งออกไฟล์ขนาดใหญ่ (เช่นไฟล์เสียงหรือวิดีโอ) ผ่านกระบวนการที่ใช้ BLOB จากงานนำเสนอ เช่นคุณอาจต้องการแยกไฟล์สื่อขนาดใหญ่จากงานนำเสนอแต่ไม่ต้องการให้ไฟล์นั้นถูกโหลดเข้าในหน่วยความจำของคอมพิวเตอร์โดยการส่งออกไฟล์ผ่านกระบวนการ BLOB คุณจะทำให้การใช้หน่วยความจำน้อยลง

โค้ด Python นี้สาธิตการดำเนินการที่อธิบายไว้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# ล็อคไฟล์ต้นทางแทนการโหลดเข้าในหน่วยความจำ.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # โอนข้อมูลวิดีโอผ่านบัฟเฟอร์เพื่อรักษาการใช้หน่วยความจำให้ต่ำ.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # ใช้สตรีมแทนการโหลดวิดีโอทั้งหมดเป็นอาเรย์ไบต์.
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # หากจำเป็นให้ใช้ขั้นตอนเดียวกันกับไฟล์เสียง.
finally:
    presentation.dispose()
```

### **เพิ่มรูปภาพเป็น BLOB ไปยังงานนำเสนอ**
ด้วยเมธอดจากคลาส [ImageCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagecollection/) คุณสามารถเพิ่มรูปภาพขนาดใหญ่เป็นสตรีมเพื่อให้ถือเป็น BLOB

โค้ด Python นี้แสดงวิธีเพิ่มรูปภาพขนาดใหญ่ผ่านกระบวนการ BLOB:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# สร้างงานนำเสนอใหม่ที่ภาพจะถูกเพิ่มเข้าไป.
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # ล็อคสตรีมไว้เนื่องจากเราไม่ได้ตั้งใจจะเข้าถึงไฟล์ภาพ.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # บันทึกงานนำเสนอในขณะที่ทำให้การใช้หน่วยความจำน้อยลง.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **หน่วยความจำและงานนำเสนอขนาดใหญ่**

โดยปกติการโหลดงานนำเสนอขนาดใหญ่ คอมพิวเตอร์ต้องใช้หน่วยความจำชั่วคราวมาก รายการทั้งหมดของงานนำเสนอจะถูกโหลดเข้าสู่หน่วยความจำและไฟล์ต้นทาง (ไฟล์ที่โหลดงานนำเสนอจากนั้น) จะหยุดถูกใช้

พิจารณางานนำเสนอ PowerPoint ขนาดใหญ่ (large.pptx) ที่มีไฟล์วิดีโอขนาด 1.5 GB วิธีมาตรฐานสำหรับการโหลดงานนำเสนออธิบายไว้ในโค้ด Python นี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

แต่วิธีนี้ใช้หน่วยความจำชั่วคราวประมาณ 1.6 GB

### **โหลดงานนำเสนอขนาดใหญ่เป็น BLOB**

โดยใช้การจัดการ BLOB คุณสามารถโหลดงานนำเสนอขนาดใหญ่โดยใช้หน่วยความจำน้อย โค้ด Python นี้แสดงวิธีใช้การจัดการ BLOB เพื่อโหลดไฟล์งานนำเสนอขนาดใหญ่ (large.pptx):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **เปลี่ยนโฟลเดอร์สำหรับไฟล์ชั่วคราว**

เมื่อใช้กระบวนการ BLOB คอมพิวเตอร์ของคุณจะสร้างไฟล์ชั่วคราวในโฟลเดอร์เริ่มต้นสำหรับไฟล์ชั่วคราว หากต้องการให้ไฟล์ชั่วคราวเก็บในโฟลเดอร์อื่น คุณสามารถเปลี่ยนการตั้งค่าเก็บโดยใช้ [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/th/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}
เมื่อคุณใช้ [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/th/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) Aspose.Slides จะไม่สร้างโฟลเดอร์เพื่อเก็บไฟล์ชั่วคราวโดยอัตโนมัติ คุณต้องสร้างโฟลเดอร์นั้นด้วยตนเอง
{{% /alert %}}

### **ปล่อยอ็อบเจกต์ Presentation เพื่อคืนหน่วยความจำ**

เมื่อประมวลผลงานนำเสนอขนาดใหญ่ ตรวจสอบให้แน่ใจว่าอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ถูกทำลายอย่างถูกต้องเพื่อให้หน่วยความจำที่ครอบครองถูกปล่อยออกมา เรียก [Presentation.dispose](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#dispose) หลังจากที่คุณใช้งานนำเสร็จเพื่อปล่อยทรัพยากรที่ไม่จัดการได้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...ประมวลผลงานนำเสนอ...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # ปล่อยทรัพยากรอย่างชัดเจน.
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ข้อมูลใดในงานนำเสนอ Aspose.Slides ที่ถือเป็น BLOB และถูกควบคุมโดยตัวเลือก BLOB?**

วัตถุไบนารีขนาดใหญ่เช่นภาพ, เสียง, และวิดีโอถือเป็น BLOB ไฟล์งานนำเสนอทั้งหมดก็เกี่ยวข้องกับการจัดการ BLOB เมื่อมีการโหลดหรือบันทึก สิ่งเหล่านี้ถูกควบคุมด้วยนโยบาย BLOB ที่ให้คุณจัดการการใช้หน่วยความจำและการส่งต่อไปยังไฟล์ชั่วคราวตามความต้องการ

**ฉันกำหนดกฎการจัดการ BLOB ขณะโหลดงานนำเสนอได้ที่ไหน?**

ใช้ [LoadOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/) พร้อมกับ [BlobManagementOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/blobmanagementoptions/) ที่นั่นคุณตั้งค่าขีดจำกัดหน่วยความจำสำหรับ BLOB, อนุญาตหรือไม่อนุญาตไฟล์ชั่วคราว, เลือกเส้นทางรากสำหรับไฟล์ชั่วคราว, และเลือกพฤติกรรมการล็อคแหล่งข้อมูล

**การตั้งค่า BLOB มีผลต่อประสิทธิภาพหรือไม่ และฉันจะปรับสมดุลระหว่างความเร็วกับหน่วยความจำอย่างไร?**

มีผล การเก็บ BLOB ในหน่วยความจำทำให้ความเร็วสูงสุดแต่ใช้ RAM มาก; ลดขีดจำกัดหน่วยความจำทำให้ทำงานส่วนใหญ่ผ่านไฟล์ชั่วคราว ลด RAM แต่เพิ่ม I/O ใช้เมธอด [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/th/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) เพื่อหาสมดุลที่เหมาะกับงานและสภาพแวดล้อมของคุณ

**ตัวเลือก BLOB ช่วยเมื่อเปิดงานนำเสนอที่ใหญ่มาก (เช่นหลายกิกะไบต์) หรือไม่?**

ช่วยได้ [BlobManagementOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/blobmanagementoptions/) ถูกออกแบบมาสำหรับสถานการณ์เหล่านั้น: การเปิดใช้ไฟล์ชั่วคราวและการล็อคแหล่งข้อมูลสามารถลดการใช้ RAM สูงสุดและทำให้การประมวลผลเสถียรสำหรับชุดสไลด์ขนาดใหญ่มาก

**ฉันสามารถใช้นโยบาย BLOB เมื่อโหลดจากสตรีมแทนไฟล์ดิสก์ได้หรือไม่?**

ได้ กฎเดียวกันใช้กับสตรีม: อินสแตนซ์ Presentation สามารถเป็นเจ้าของและล็อคสตรีมอินพุต (ตามโหมดล็อคที่เลือก) และไฟล์ชั่วคราวจะถูกใช้เมื่ออนุญาต ทำให้การใช้หน่วยความจำคาดการณ์ได้ระหว่างการประมวลผล