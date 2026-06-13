---
title: จัดการ BLOB ในงานพรีเซนเทชันด้วย Python เพื่อการใช้หน่วยความจำที่มีประสิทธิภาพ
linktitle: จัดการ BLOB
type: docs
weight: 10
url: /th/python-net/manage-blob/
keywords:
- วัตถุขนาดใหญ่
- รายการขนาดใหญ่
- ไฟล์ขนาดใหญ่
- เพิ่ม BLOB
- ส่งออก BLOB
- เพิ่มรูปภาพเป็น BLOB
- ลดหน่วยความจำ
- การใช้หน่วยความจำ
- พรีเซนเทชันขนาดใหญ่
- ไฟล์ชั่วคราว
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Python
- Aspose.Slides
description: "จัดการข้อมูล BLOB ใน Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อปรับปรุงการดำเนินการไฟล์ PowerPoint และ OpenDocument ให้มีประสิทธิภาพในการจัดการพรีเซนเทชัน"
---
## **ภาพรวม**

Aspose.Slides ให้การจัดการแบบ BLOB สำหรับข้อมูลไบนารีขนาดใหญ่ในงานพรีเซนเทชัน เพื่อช่วยลดการใช้หน่วยความจำเมื่อต้องทำงานกับรูปภาพ ข้อเสียง วิดีโอ และไฟล์พรีเซนเทชันขนาดใหญ่

บทความนี้แสดงวิธีใช้การประมวลผลแบบ BLOB เพื่อเพิ่มสื่อขนาดใหญ่ลงในพรีเซนเทชัน, ส่งออกสื่อขนาดใหญ่จากพรีเซนเทชัน, และโหลดพรีเซนเทชันขนาดใหญ่ได้อย่างมีประสิทธิภาพมากขึ้น นอกจากนี้ยังอธิบายวิธีใช้ไฟล์ชั่วคราวระหว่างการประมวลผลและวิธีเปลี่ยนโฟลเดอร์ที่ใช้เก็บไฟล์เหล่านั้น

## **เกี่ยวกับ BLOB**

**BLOB** (**Binary Large Object**) ปกติหมายถึงรายการขนาดใหญ่ (รูปภาพ, พรีเซนเทชัน, เอกสาร หรือสื่อ) ที่บันทึกในรูปแบบไบนารี

Aspose.Slides for Python via .NET ช่วยให้คุณใช้ BLOB สำหรับอ็อบเจ็กต์ในวิธีที่ลดการใช้หน่วยความจำเมื่อไฟล์มีขนาดใหญ่

## **ใช้ BLOB เพื่อลดการใช้หน่วยความจำ**

### **เพิ่มไฟล์ขนาดใหญ่ผ่าน BLOB ไปยังพรีเซนเทชัน**

[Aspose.Slides](/slides/th/python-net/) for .NET อนุญาตให้คุณเพิ่มไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์วิดีโอขนาดใหญ่) ผ่านกระบวนการที่เกี่ยวกับ BLOB เพื่อลดการใช้หน่วยความจำ

ตัวอย่าง Python นี้แสดงวิธีเพิ่มไฟล์วิดีโอขนาดใหญ่ผ่านกระบวนการ BLOB ไปยังพรีเซนเทชัน:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# Creates a new presentation to which the video will be added
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # Let's add the video to the presentation - we chose the KeepLocked behavior because we do
        # not intend to access the "veryLargeVideo.avi" file.
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # Saves the presentation. While a large presentation gets outputted, the memory consumption
        # stays low through the pres object's lifecycle 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **ส่งออกไฟล์ขนาดใหญ่ผ่าน BLOB จากพรีเซนเทชัน**

Aspose.Slides for Python via .NET อนุญาตให้คุณส่งออกไฟล์ขนาดใหญ่ (เช่นไฟล์เสียงหรือวิดีโอ) ผ่านกระบวนการที่เกี่ยวกับ BLOB จากพรีเซนเทชัน  ตัวอย่างเช่น คุณอาจต้องการสกัดไฟล์สื่อขนาดใหญ่จากพรีเซนเทชันแต่ไม่ต้องการให้ไฟล์นั้นโหลดเข้าสู่หน่วยความจำของคอมพิวเตอร์ การส่งออกไฟล์ผ่านกระบวนการ BLOB จะทำให้การใช้หน่วยความจำคงที่ต่ำ

โค้ด Python นี้สาธิตการดำเนินการที่อธิบายไว้:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# ให้บันทึกวิดีโอแต่ละไฟล์ลงในไฟล์. เพื่อป้องกันการใช้หน่วยความจำสูง, เราต้องการบัฟเฟอร์ที่จะใช้
	# เพื่อโอนย้ายข้อมูลจากสตรีมวิดีโอของพรีเซนเทชันไปยังสตรีมสำหรับไฟล์วิดีโอที่สร้างใหม่.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# วนรอบวิดีโอต่าง ๆ
    index = 0
    # หากจำเป็น, คุณสามารถใช้ขั้นตอนเดียวกันสำหรับไฟล์เสียงได้.
    for video in pres.videos:
		# เปิดสตรีมวิดีโอของพรีเซนเทชัน. โปรดทราบว่าเราเจตนาหลีกเลี่ยงการเข้าถึงคุณสมบัติ
		# เช่น video.BinaryData - เนื่องจากคุณสมบัตินี้คืนค่าอาร์เรย์ไบท์ที่มีวิดีโอเต็ม, ซึ่ง
		# ทำให้ไบท์โหลดเข้าสู่หน่วยความจำ. เราใช้ video.GetStream, ซึ่งจะคืนค่า Stream - และไม่ได้
		#  ไม่จำเป็นให้เราต้องโหลดวิดีโอทั้งหมดเข้าสู่หน่วยความจำ.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **เพิ่มรูปภาพเป็น BLOB ในพรีเซนเทชัน**

ด้วยวิธีการจากคลาส [**ImageCollection**](https://reference.aspose.com/slides/th/python-net/aspose.slides/imagecollection/) คุณสามารถเพิ่มรูปภาพขนาดใหญ่เป็นสตรีมเพื่อให้ถูกจัดการเป็น BLOB

โค้ด Python นี้แสดงวิธีเพิ่มรูปภาพขนาดใหญ่ผ่านกระบวนการ BLOB:

```py
import aspose.slides as slides

# สร้างพรีเซนเทชันใหม่ที่รูปภาพจะถูกเพิ่มเข้าไป.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **หน่วยความจำและพรีเซนเทชันขนาดใหญ่**

โดยทั่วไป การโหลดพรีเซนเทชันขนาดใหญ่คอมพิวเตอร์จะต้องใช้หน่วยความจำชั่วคราวจำนวนมาก เนื้อหาทั้งหมดของพรีเซนเทชันจะถูกโหลดเข้าสู่หน่วยความจำและไฟล์ต้นทาง (ไฟล์ที่ใช้โหลดพรีเซนเทชัน) จะหยุดใช้งาน

ให้พิจารณาพรีเซนเทชัน PowerPoint ขนาดใหญ่ (large.pptx) ที่มีไฟล์วิดีโอขนาด 1.5 GB วิธีมาตรฐานในการโหลดพรีเซนเทชันนี้แสดงในโค้ด Python นี้:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

แต่วิธีนี้ใช้หน่วยความจำชั่วคราวประมาณ 1.6 GB

### **โหลดพรีเซนเทชันขนาดใหญ่เป็น BLOB**

ผ่านกระบวนการที่เกี่ยวกับ BLOB คุณสามารถโหลดพรีเซนเทชันขนาดใหญ่โดยใช้หน่วยความจำน้อย โค้ด Python นี้อธิบายการทำงานโดยใช้กระบวนการ BLOB เพื่อโหลดไฟล์พรีเซนเทชันขนาดใหญ่ (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **เปลี่ยนโฟลเดอร์สำหรับไฟล์ชั่วคราว**

เมื่อใช้กระบวนการ BLOB คอมพิวเตอร์ของคุณจะสร้างไฟล์ชั่วคราวในโฟลเดอร์เริ่มต้นสำหรับไฟล์ชั่วคราว หากคุณต้องการให้ไฟล์ชั่วคราวถูกเก็บในโฟลเดอร์อื่น คุณสามารถเปลี่ยนการตั้งค่าการจัดเก็บโดยใช้ `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
เมื่อคุณใช้ `temp_files_root_path` Aspose.Slides จะไม่สร้างโฟลเดอร์สำหรับเก็บไฟล์ชั่วคราวโดยอัตโนมัติ คุณต้องสร้างโฟลเดอร์นั้นด้วยตนเอง
{{% /alert %}}

### **ปล่อยอ็อบเจ็กต์ Presentation เพื่อคืนหน่วยความจำ**

เมื่อทำงานกับพรีเซนเทชันขนาดใหญ่ ควรตรวจสอบให้แน่ใจว่าอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ถูกทำลายอย่างถูกต้องเพื่อให้หน่วยความจำที่ใช้งานถูกปล่อยออก วิธีที่แนะนำคือใช้คอนเท็กซ์แมเนเจอร์ (`with slides.Presentation(...) as presentation:`) เหมือนในตัวอย่างด้านบน; มันจะปิดพรีเซนเทชันและปล่อยทรัพยากรที่ไม่ได้จัดการโดยอัตโนมัติเมื่อออกจากบล็อก

หากคุณสร้างพรีเซนเทชันโดยไม่ใช้บล็อก `with` ให้เรียก `presentation.dispose()` อย่างชัดเจนหลังจากใช้เสร็จ และลบการอ้างอิงที่เหลืออยู่ทั้งหมดเพื่อให้ garbage collector ของ Python สามารถกรีบหน่วยความจำคืนได้

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...ประมวลผลพรีเซนเทชัน...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# ปล่อยทรัพยากรโดยเจาะจง.
presentation.dispose()
```

## **FAQ**

**ข้อมูลใดในพรีเซนเทชัน Aspose.Slides ที่ถือเป็น BLOB และถูกควบคุมโดยตัวเลือก BLOB?**

ออบเจ็กต์ไบนารีขนาดใหญ่เช่นรูปภาพ, เสียง, และวิดีโอถูกจัดการเป็น BLOB ทั้งไฟล์พรีเซนเทชันทั้งหมดก็เกี่ยวข้องกับการจัดการ BLOB เมื่อมีการโหลดหรือบันทึก ออบเจ็กต์เหล่านี้อยู่ภายใต้นโยบาย BLOB ที่ช่วยให้คุณจัดการการใช้หน่วยความจำและสลับไปใช้ไฟล์ชั่วคราวเมื่อจำเป็น

**ฉันกำหนดกฎการจัดการ BLOB ระหว่างการโหลดพรีเซนเทชันได้ที่ไหน?**

ใช้ [LoadOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/) พร้อมกับ [BlobManagementOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/blobmanagementoptions/) ที่นั่นคุณสามารถตั้งค่าขีดจำกัดหน่วยความจำสำหรับ BLOB, เปิดหรือปิดการใช้ไฟล์ชั่วคราว, เลือกโฟลเดอร์รากสำหรับไฟล์ชั่วคราว, และกำหนดพฤติกรรมการล็อกแหล่งข้อมูล

**การตั้งค่า BLOB มีผลต่อประสิทธิภาพหรือไม่ และฉันจะปรับสมดุลระหว่างความเร็วกับหน่วยความจำอย่างไร?**

มีผล การเก็บ BLOB ในหน่วยความจำทำให้ความเร็วสูงสุดแต่ใช้ RAM มากขึ้น; การลดขีดจำกัดหน่วยความจำจะย้ายงานส่วนใหญ่ไปใช้ไฟล์ชั่วคราว ลด RAM แต่เพิ่ม I/O ปรับค่าเกณฑ์ [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/th/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) ให้เหมาะสมกับภาระงานและสภาพแวดล้อมของคุณ

**ตัวเลือก BLOB ช่วยเมื่อเปิดพรีเซนเทชันที่ใหญ่มาก (เช่นหลายกิกะไบต์) หรือไม่?**

ช่วย [BlobManagementOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/blobmanagementoptions/) ถูกออกแบบมาสำหรับสถานการณ์ดังกล่าว: การเปิดไฟล์ชั่วคราวและการล็อกแหล่งข้อมูลสามารถลดการใช้ RAM สูงสุดและทำให้การประมวลผลพรีเซนเทชันขนาดใหญ่มาก ๆ มีเสถียรภาพมากขึ้น

**ฉันสามารถใช้กฎ BLOB เมื่อต้องโหลดจากสตรีมแทนไฟล์บนดิสก์ได้หรือไม่?**

ได้ กฎเดียวกันใช้กับสตรีม: อินสแตนซ์พรีเซนเทชันสามารถเป็นเจ้าของและล็อกสตรีมอินพุต (ขึ้นอยู่กับโหมดล็อกที่เลือก) และไฟล์ชั่วคราวจะถูกใช้เมื่ออนุญาต ทำให้การใช้หน่วยความจำคาดเดาได้ตลอดการประมวลผล