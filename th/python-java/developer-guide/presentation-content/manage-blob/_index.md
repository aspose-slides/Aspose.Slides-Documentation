---
title: จัดการ BLOB ของงานนำเสนอใน Python ผ่าน Java เพื่อการใช้หน่วยความจำที่มีประสิทธิภาพ
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
- การใช้หน่วยความจำ
- งานนำเสนอขนาดใหญ่
- ไฟล์ชั่วคราว
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการข้อมูล BLOB ใน Aspose.Slides สำหรับ Python ผ่าน Java เพื่อทำให้การดำเนินการไฟล์ PowerPoint และ OpenDocument มีประสิทธิภาพในการจัดการงานนำเสนอ"
---
## **ภาพรวม**

Aspose.Slides ให้การจัดการแบบอิง BLOB สำหรับข้อมูลไบนารีขนาดใหญ่ในงานนำเสนอ เพื่อช่วยลดการใช้หน่วยความจำเมื่อทำงานกับรูปภาพขนาดใหญ่, เสียง, วิดีโอและไฟล์งานนำเสนอ

บทความนี้แสดงวิธีใช้การประมวลผลแบบ BLOB เพื่อเพิ่มสื่อขนาดใหญ่ไปยังงานนำเสนอ, ส่งออกสื่อขนาดใหญ่จากงานนำเสนอ, และโหลดงานนำเสนอขนาดใหญ่อย่างมีประสิทธิภาพยิ่งขึ้น นอกจากนี้ยังอธิบายวิธีการใช้ไฟล์ชั่วคราวระหว่างการประมวลผลและวิธีเปลี่ยนโฟลเดอร์ที่ใช้เก็บไฟล์เหล่านั้น

## **เกี่ยวกับ BLOB**

**BLOB** (**Binary Large Object**) ปกติจะหมายถึงรายการขนาดใหญ่ (รูปภาพ, งานนำเสนอ, เอกสาร หรือสื่อ) ที่บันทึกในรูปแบบไบนารี

Aspose.Slides for Python via Java ช่วยให้คุณใช้ BLOB สำหรับวัตถุต่าง ๆ ในลักษณะที่ลดการใช้หน่วยความจำเมื่อไฟล์ขนาดใหญ่มีส่วนเกี่ยวข้อง

{{% alert color="info" title="Note" %}}
เพื่อหลีกเลี่ยงข้อจำกัดบางประการเมื่อทำงานกับสตรีม, Aspose.Slides อาจคัดลอกเนื้อหาของสตรีม การโหลดงานนำเสนอขนาดใหญ่ผ่านสตรีมจะทำให้เกิดการคัดลอกเนื้อหาของงานนำเสนอและทำให้การโหลดช้าลง ดังนั้นเมื่อคุณต้องการโหลดงานนำเสนอขนาดใหญ่ เราขอแนะนำอย่างยิ่งให้ใช้เส้นทางไฟล์งานนำเสนอแทนการใช้สตรีม
{{% /alert %}}

## **ใช้ BLOB เพื่อลดการใช้หน่วยความจำ**

### **เพิ่มไฟล์ขนาดใหญ่ผ่าน BLOB ไปยังงานนำเสนอ**

[Aspose.Slides](/slides/th/python-java/) for Python via Java ช่วยให้คุณเพิ่มไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์วิดีโอขนาดใหญ่) ผ่านกระบวนการที่เกี่ยวข้องกับ BLOB เพื่อลดการใช้หน่วยความจำ

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
        # เก็บสตรีมไว้ในสถานะล็อก เพราะเราไม่ได้ตั้งใจเข้าถึงไฟล์วิดีโอ.
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # บันทึกงานนำเสนอพร้อมรักษาการใช้หน่วยความจำให้ต่ำ.
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **ส่งออกไฟล์ขนาดใหญ่ผ่าน BLOB จากงานนำเสนอ**

Aspose.Slides for Python via Java ช่วยให้คุณส่งออกไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์เสียงหรือวิดีโอ) ผ่านกระบวนการที่เกี่ยวข้องกับ BLOB จากงานนำเสนอ ตัวอย่างเช่น คุณอาจต้องการสกัดไฟล์สื่อขนาดใหญ่จากงานนำเสนอแต่ไม่ต้องการให้ไฟล์ถูกโหลดเข้าไปในหน่วยความจำของคอมพิวเตอร์ การส่งออกไฟล์ผ่านกระบวนการ BLOB ช่วยให้การใช้หน่วยความจำต่ำลง

โค้ด Python นี้สาธิตการดำเนินการที่อธิบายไว้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# ล็อคไฟล์ต้นฉบับแทนการโหลดเข้าไปในหน่วยความจำ.
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # ส่งผ่านข้อมูลวิดีโอผ่านบัฟเฟอร์เพื่อรักษาการใช้หน่วยความจำให้ต่ำ.
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # ใช้สตรีมแทนการโหลดวิดีโอทั้งหมดเข้าเป็นอาร์เรย์ไบต์.
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
    # หากจำเป็น ให้นำขั้นตอนเดียวกันไปใช้กับไฟล์เสียง.
finally:
    presentation.dispose()
```

### **เพิ่มรูปภาพเป็น BLOB ไปยังงานนำเสนอ**

ด้วยเมธอดจากคลาส [ImageCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagecollection/) คุณสามารถเพิ่มรูปภาพขนาดใหญ่เป็นสตรีมเพื่อให้ถูกปฏิบัติเป็น BLOB

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
        # เก็บสตรีมไว้ในสถานะล็อกเนื่องจากเราไม่ได้ตั้งใจเข้าถึงไฟล์ภาพ.
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # บันทึกงานนำเสนอพร้อมรักษาการใช้หน่วยความจำให้ต่ำ.
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **หน่วยความจำและงานนำเสนอขนาดใหญ่**

โดยทั่วไปแล้ว การโหลดงานนำเสนอขนาดใหญ่ต้องใช้หน่วยความจำชั่วคราวจำนวนมาก เนื้อหาทั้งหมดของงานนำเสนอจะถูกโหลดเข้าไปในหน่วยความจำและไฟล์ที่ใช้ในการโหลดงานนำเสนอจะหยุดถูกใช้งาน

พิจารณางานนำเสนอ PowerPoint ขนาดใหญ่ (large.pptx) ที่มีไฟล์วิดีโอขนาด 1.5 GB วิธีมาตรฐานในการโหลดงานนำเสนอถูกอธิบายในโค้ด Python นี้:

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

ผ่านกระบวนการที่เกี่ยวข้องกับ BLOB คุณสามารถโหลดงานนำเสนอขนาดใหญ่โดยใช้หน่วยความจำเพียงเล็กน้อย โค้ด Python นี้อธิบายการนำกระบวนการ BLOB ไปใช้ในการโหลดไฟล์งานนำเสนอขนาดใหญ่ (large.pptx):

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

เมื่อใช้กระบวนการ BLOB คอมพิวเตอร์ของคุณจะสร้างไฟล์ชั่วคราวในโฟลเดอร์เริ่มต้นสำหรับไฟล์ชั่วคราว หากคุณต้องการให้ไฟล์เหล่านั้นถูกเก็บในโฟลเดอร์อื่น คุณสามารถเปลี่ยนการตั้งค่าการจัดเก็บโดยใช้ [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/th/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath):

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
เมื่อคุณใช้ [BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/th/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) Aspose.Slides จะไม่สร้างโฟลเดอร์สำหรับเก็บไฟล์ชั่วคราวโดยอัตโนมัติ คุณต้องสร้างโฟลเดอร์นั้นด้วยตนเอง
{{% /alert %}}

### **ลบวัตถุ Presentation เพื่อปล่อยหน่วยความจำ**

เมื่อประมวลผลงานนำเสนอขนาดใหญ่ ให้แน่ใจว่าอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ถูกทำลายอย่างถูกต้องเพื่อให้หน่วยความจำที่มันใช้ถูกปล่อยออกมา เรียกใช้ [Presentation.dispose](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#dispose) หลังจากที่คุณใช้งานนำเสนอเสร็จแล้วเพื่อปล่อยทรัพยากรที่ไม่ได้จัดการ

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
    # ปลดปล่อยทรัพยากรอย่างชัดเจน.
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ข้อมูลใดในงานนำเสนอ Aspose.Slides ที่ถือเป็น BLOB และถูกควบคุมโดยตัวเลือก BLOB?**

วัตถุไบนารีขนาดใหญ่เช่นรูปภาพ, เสียงและวิดีโอต่างถูกจัดเป็น BLOB ไฟล์งานนำเสนอทั้งไฟล์ก็มีการจัดการ BLOB เมื่อโหลดหรือบันทึก วัตถุเหล่านี้ถูกควบคุมโดยนโยบาย BLOB ที่ช่วยให้คุณจัดการการใช้หน่วยความจำและสลับไปใช้ไฟล์ชั่วคราวเมื่อจำเป็น

**ฉันกำหนดกฎการจัดการ BLOB ระหว่างการโหลดงานนำเสนอได้ที่ไหน?**

ใช้ [LoadOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/) ร่วมกับ [BlobManagementOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/blobmanagementoptions/) ที่นั่นคุณสามารถตั้งค่าขีดจำกัดหน่วยความจำในเครื่องสำหรับ BLOB, เปิดหรือปิดการใช้ไฟล์ชั่วคราว, กำหนดเส้นทางรากสำหรับไฟล์ชั่วคราว, และเลือกพฤติกรรมการล็อกแหล่งข้อมูล

**การตั้งค่า BLOB มีผลต่อประสิทธิภาพหรือไม่ และฉันจะปรับสมดุลระหว่างความเร็วกับหน่วยความจำอย่างไร?**

ใช่ การเก็บ BLOB ไว้ในหน่วยความจำเพิ่มความเร็วสูงสุดแต่เพิ่มการใช้ RAM; การลดขีดจำกัดหน่วยความจำจะทำให้ทำงานส่วนใหญ่ผ่านไฟล์ชั่วคราว ลด RAM แต่ต้องแลกกับ I/O เพิ่ม ใช้วิธี [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/th/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) เพื่อหาสมดุลที่เหมาะสมกับภาระงานและสภาพแวดล้อมของคุณ

**ตัวเลือก BLOB ช่วยเมื่อเปิดงานนำเสนอขนาดใหญ่มาก (เช่นหลายกิกะไบต์) หรือไม่?**

ใช่ [BlobManagementOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/blobmanagementoptions/) ถูกออกแบบมาสำหรับสถานการณ์เช่นนี้: การเปิดใช้งานไฟล์ชั่วคราวและการล็อกแหล่งข้อมูลสามารถลดการใช้ RAM สูงสุดได้อย่างมีนัยสำคัญและทำให้การประมวลผลของเด็คที่ใหญ่มากมีความเสถียรยิ่งขึ้น

**ฉันสามารถใช้แนวทาง BLOB เมื่อโหลดจากสตรีมแทนไฟล์ดิสก์ได้หรือไม่?**

ใช่ กฎเดียวกันใช้กับสตรีม: อินสแตนซ์ Presentation สามารถเป็นเจ้าของและล็อกสตรีมอินพุต (ขึ้นอยู่กับโหมดล็อกที่เลือก) และไฟล์ชั่วคราวจะถูกใช้เมื่ออนุญาต ทำให้การใช้หน่วยความจำคาดเดาได้ระหว่างการประมวลผล