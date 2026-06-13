---
title: จัดการ BLOB ของงานนำเสนอบน Android เพื่อการใช้หน่วยความจำที่มีประสิทธิภาพ
linktitle: จัดการ BLOB
type: docs
weight: 10
url: /th/androidjava/manage-blob/
keywords:
- วัตถุขนาดใหญ่
- รายการขนาดใหญ่
- ไฟล์ขนาดใหญ่
- เพิ่ม BLOB
- ส่งออก BLOB
- เพิ่มรูปภาพเป็น BLOB
- ลดหน่วยความจำ
- การใช้หน่วยความจำ
- งานนำเสนอขนาดใหญ่
- ไฟล์ชั่วคราว
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "จัดการข้อมูล BLOB ใน Aspose.Slides สำหรับ Android ผ่าน Java เพื่อทำให้การดำเนินการไฟล์ PowerPoint และ OpenDocument มีประสิทธิภาพและการจัดการงานนำเสนอที่มีประสิทธิผล"
---
## **ภาพรวม**

Aspose.Slides มีการจัดการแบบอิง BLOB สำหรับข้อมูลไบนารีขนาดใหญ่ในงานนำเสนอ เพื่อช่วยลดการใช้หน่วยความจำเมื่อทำงานกับภาพขนาดใหญ่, เสียง, วิดีโอและไฟล์งานนำเสนอ

บทความนี้แสดงวิธีใช้การประมวลผลแบบ BLOB เพื่อเพิ่มสื่อขนาดใหญ่ลงในงานนำเสนอ, ส่งออกสื่อขนาดใหญ่จากงานนำเสนอ, และโหลดงานนำเสนอขนาดใหญ่อย่างมีประสิทธิภาพมากขึ้น นอกจากนี้ยังอธิบายวิธีใช้ไฟล์ชั่วคราวระหว่างการประมวลผลและวิธีเปลี่ยนโฟลเดอร์ที่ใช้เก็บไฟล์เหล่านั้น

## **เกี่ยวกับ BLOB**

**BLOB** (**Binary Large Object**) ปกติหมายถึงรายการขนาดใหญ่ (รูปภาพ, งานนำเสนอ, เอกสาร หรือสื่อ) ที่บันทึกในรูปแบบไบนารี

Aspose.Slides for Android via Java อนุญาตให้คุณใช้ BLOBs สำหรับอ็อบเจกต์ในวิธีที่ลดการใช้หน่วยความจำเมื่อไฟล์ขนาดใหญ่มีส่วนเกี่ยวข้อง

{{% alert title="Info" color="info" %}}
เพื่อหลีกเลี่ยงข้อจำกัดบางประการเมื่อโต้ตอบกับสตรีม, Aspose.Slides อาจคัดลอกเนื้อหาของสตรีม การโหลดงานนำเสนอขนาดใหญ่ผ่านสตรีมจะทำให้เกิดการคัดลอกเนื้อหาของงานนำเสนอและทำให้การโหลดช้า ดังนั้นเมื่อคุณต้องการโหลดงานนำเสนอขนาดใหญ่, เราแนะนำอย่างยิ่งให้ใช้เส้นทางไฟล์งานนำเสนอแทนการใช้สตรีม
{{% /alert %}}

## **ใช้ BLOB เพื่อลดการใช้หน่วยความจำ**

### **เพิ่มไฟล์ขนาดใหญ่ผ่าน BLOB ไปยังงานนำเสนอ**

[Aspose.Slides](/slides/th/androidjava/) สำหรับ Java อนุญาตให้คุณเพิ่มไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์วิดีโอขนาดใหญ่) ผ่านกระบวนการที่เกี่ยวข้องกับ BLOB เพื่อให้การใช้หน่วยความจำลดลง

โค้ด Java นี้แสดงวิธีเพิ่มไฟล์วิดีโอขนาดใหญ่ผ่านกระบวนการ BLOB ไปยังงานนำเสนอ:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// สร้างงานนำเสนอใหม่เพื่อเพิ่มวิดีโอลงไป
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // ให้เพิ่มวิดีโอลงในงานนำเสนอ - เราเลือกพฤติกรรม KeepLocked เพราะเรา
        // ไม่ตั้งใจเข้าถึงไฟล์ "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // บันทึกงานนำเสนอ ขณะส่งออกงานนำเสนอขนาดใหญ่ การใช้หน่วยความจำ
        // คงที่ต่ำตลอดอายุการใช้งานของอ็อบเจ็กต์ pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **ส่งออกไฟล์ขนาดใหญ่ผ่าน BLOB จากงานนำเสนอ**

Aspose.Slides for Android via Java อนุญาตให้คุณส่งออกไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์เสียงหรือวิดีโอ) ผ่านกระบวนการที่เกี่ยวข้องกับ BLOB จากงานนำเสนอ ตัวอย่างเช่น คุณอาจต้องการแยกไฟล์สื่อขนาดใหญ่จากงานนำเสนอโดยไม่ต้องให้ไฟล์โหลดเข้าสู่หน่วยความจำของคอมพิวเตอร์ การส่งออกไฟล์ผ่านกระบวนการ BLOB จะช่วยให้การใช้หน่วยความจำต่ำลง

โค้ด Java นี้แสดงการทำงานที่อธิบายไว้ข้างต้น:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Locks the source file and does NOT load it into memory
// ล็อกไฟล์ต้นฉบับและไม่โหลดเข้าไปในหน่วยความจำ
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// create the Presentation's instance, lock the "hugePresentationWithAudiosAndVideos.pptx" file.
    // สร้างอินสแตนซ์ของ Presentation และล็อกไฟล์ "hugePresentationWithAudiosAndVideos.pptx"
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
    // ให้บันทึกวิดีโอแต่ละไฟล์ลงไฟล์ เพื่อป้องกันการใช้หน่วยความจำสูง เราต้องการบัฟเฟอร์ที่ใช้
    // to transfer the data from the presentation's video stream to a stream for a newly created video file.
    // เพื่อโอนข้อมูลจากสตรีมวิดีโอของงานนำเสนอไปยังสตรีมของไฟล์วิดีโอใหม่ที่สร้างขึ้น
    byte[] buffer = new byte[8 * 1024];

    // Iterates through the videos
    // วนลูปผ่านวิดีโอทั้งหมด
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
        // เปิดสตรีมวิดีโอของงานนำเสนอ โปรดทราบว่าเราตั้งใจหลีกเลี่ยงการเข้าถึงคุณสมบัติ
        // like video.BinaryData - because this property returns a byte array containing a full video, which then
        // เช่น video.BinaryData - เนื่องจากคุณสมบัตินี้คืนอาเรย์ไบต์ที่ประกอบด้วยวิดีโอเต็ม, ซึ่ง
        // causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
        // ทำให้ไบต์ถูกโหลดเข้าสู่หน่วยความจำ เราใช้ video.GetStream ซึ่งจะคืนค่า Stream - และไม่
        //  require us to load the whole video into the memory.
        //  ต้องให้เราต้องโหลดวิดีโอทั้งหมดเข้าสู่หน่วยความจำ
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Memory consumption will remain low regardless of the size of the video or presentation.
        // การใช้หน่วยความจำจะคงต่ำไม่ว่าขนาดของวิดีโอหรือของงานนำเสนอจะเท่าใด
    }
    // If necessary, you can apply the same steps for audio files. 
    // หากจำเป็น คุณสามารถใช้ขั้นตอนเดียวกันกับไฟล์เสียงได้
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **เพิ่มรูปภาพเป็น BLOB ในงานนำเสนอ**

ด้วยเมธอดจากอินเทอร์เฟซ [**IImageCollection**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IImageCollection) และคลาส [**ImageCollection**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ImageCollection) คุณสามารถเพิ่มรูปภาพขนาดใหญ่เป็นสตรีมเพื่อให้ถือว่าเป็น BLOB

โค้ด Java นี้แสดงวิธีเพิ่มรูปภาพขนาดใหญ่ผ่านกระบวนการ BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// สร้างงานนำเสนอใหม่เพื่อเพิ่มรูปภาพลงไป.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// ให้เพิ่มรูปภาพลงในงานนำเสนอ - เราเลือกพฤติกรรม KeepLocked เพราะเรา
		// ไม่ตั้งใจเข้าถึงไฟล์ "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// บันทึกงานนำเสนอ. ขณะส่งออกงานนำเสนอขนาดใหญ่ การใช้หน่วยความจำ
		// คงต่ำตลอดอายุการใช้งานของอ็อบเจ็กต์ pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **หน่วยความจำและงานนำเสนอขนาดใหญ่**

โดยทั่วไปเพื่อโหลดงานนำเสนอขนาดใหญ่ คอมพิวเตอร์ต้องการหน่วยความจำชั่วคราวจำนวนมาก เนื้อหาทั้งหมดของงานนำเสนอจะถูกโหลดเข้าสู่หน่วยความจำและไฟล์ (ที่งานนำเสนอถูกโหลดจากนั้น) จะหยุดถูกใช้งาน

พิจารณางานนำเสนอ PowerPoint ขนาดใหญ่ (large.pptx) ที่มีไฟล์วิดีโอขนาด 1.5 GB วิธีมาตรฐานในการโหลดงานนำเสนอได้อธิบายไว้ในโค้ด Java นี้:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

แต่วิธีนี้ใช้หน่วยความจำชั่วคราวประมาณ 1.6 GB

### **โหลดงานนำเสนอขนาดใหญ่เป็น BLOB**

ผ่านกระบวนการที่เกี่ยวข้องกับ BLOB คุณสามารถโหลดงานนำเสนอขนาดใหญ่โดยใช้หน่วยความจำน้อย โค้ด Java นี้อธิบายการใช้กระบวนการ BLOB เพื่อโหลดไฟล์งานนำเสนอขนาดใหญ่ (large.pptx):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **เปลี่ยนโฟลเดอร์สำหรับไฟล์ชั่วคราว**

เมื่อใช้กระบวนการ BLOB คอมพิวเตอร์ของคุณจะสร้างไฟล์ชั่วคราวในโฟลเดอร์เริ่มต้นสำหรับไฟล์ชั่วคราว หากคุณต้องการให้ไฟล์ชั่วคราวถูกเก็บในโฟลเดอร์อื่น สามารถเปลี่ยนการตั้งค่าการจัดเก็บโดยใช้ `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
เมื่อคุณใช้ `TempFilesRootPath`, Aspose.Slides จะไม่สร้างโฟลเดอร์สำหรับเก็บไฟล์ชั่วคราวโดยอัตโนมัติ คุณต้องสร้างโฟลเดอร์นั้นด้วยตนเอง
{{% /alert %}}

### **ทำลายอ็อบเจกต์ Presentation เพื่อปล่อยหน่วยความจำ**

เมื่อประมวลผลงานนำเสนอขนาดใหญ่ ให้แน่ใจว่าตัวอย่าง [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ถูกทำลายอย่างถูกต้องเพื่อให้หน่วยความจำที่ครอบครองถูกปล่อยออกมาเรียก `dispose()` หลังจากใช้งานนำเสนอเสร็จเพื่อคืนทรัพยากรที่ไม่อยู่ภายใต้การจัดการ

```java
Presentation presentation = new Presentation("large.pptx");

// ...ประมวลผลงานนำเสนอ...
presentation.save("large.pdf", SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **คำถามที่พบบ่อย**

**ข้อมูลใดในงานนำเสนอ Aspose.Slides ที่ถือเป็น BLOB และถูกควบคุมโดยตัวเลือก BLOB?**

วัตถุไบนารีขนาดใหญ่เช่นรูปภาพ, เสียงและวิดีโอถือเป็น BLOB ทั้งไฟล์งานนำเสนอทั้งหมดก็เกี่ยวข้องกับการจัดการ BLOB เมื่อมีการโหลดหรือบันทึก วัตถุเหล่านี้อยู่ภายใต้นโยบาย BLOB ที่ให้คุณจัดการการใช้หน่วยความจำและการสลับไปยังไฟล์ชั่วคราวเมื่อจำเป็น

**ฉันกำหนดกฎการจัดการ BLOB ที่ไหนระหว่างการโหลดงานนำเสนอ?**

ใช้ [LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/) กับ [BlobManagementOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/blobmanagementoptions/) ที่นั่นคุณตั้งค่าขีดจำกัดในหน่วยความจำสำหรับ BLOB, เปิดหรือปิดไฟล์ชั่วคราว, เลือกเส้นทางรากสำหรับไฟล์ชั่วคราว, และกำหนดพฤติกรรมการล็อกแหล่งข้อมูล

**การตั้งค่า BLOB มีผลต่อประสิทธิภาพหรือไม่ และฉันจะปรับสมดุลความเร็วกับหน่วยความจำอย่างไร?**

ใช่ การเก็บ BLOB ในหน่วยความจำทำให้ความเร็วสูงสุดแต่เพิ่มการใช้ RAM; การลดขีดจำกัดหน่วยความจำจะย้ายงานไปยังไฟล์ชั่วคราว, ลด RAM แต่เพิ่ม I/O ใช้เมธอด [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) เพื่อหาสมดุลที่เหมาะสมกับภาระงานและสภาพแวดล้อมของคุณ

**ตัวเลือก BLOB ช่วยเมื่อเปิดงานนำเสนอขนาดใหญ่มาก (เช่นหลายกิกะไบต์) หรือไม่?**

ใช่ [BlobManagementOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/blobmanagementoptions/) ถูกออกแบบมาสำหรับสถานการณ์เช่นนั้น: การเปิดไฟล์ชั่วคราวและการล็อกแหล่งข้อมูลสามารถลดการใช้ RAM สูงสุดอย่างมากและทำให้การประมวลผลของชุดสไลด์ขนาดใหญ่มั่นคงขึ้น

**ฉันสามารถใช้โนบัย BLOB เมื่อโหลดจากสตรีมแทนไฟล์ดิสก์ได้หรือไม่?**

ได้ กฎเดียวกันใช้กับสตรีม: อินสแตนซ์ Presentation สามารถเป็นเจ้าของและล็อกสตรีมอินพุต (ตามโหมดการล็อกที่เลือก) และไฟล์ชั่วคราวจะถูกใช้เมื่ออนุญาต ทำให้การใช้หน่วยความจำคาดการณ์ได้ระหว่างการประมวลผล