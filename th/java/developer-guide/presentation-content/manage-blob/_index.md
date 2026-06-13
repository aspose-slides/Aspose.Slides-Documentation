---
title: จัดการ BLOB ของพรีเซนเทชันใน Java เพื่อประหยัดหน่วยความจำ
linktitle: จัดการ BLOB
type: docs
weight: 10
url: /th/java/manage-blob/
keywords:
- วัตถุขนาดใหญ่
- รายการขนาดใหญ่
- ไฟล์ขนาดใหญ่
- เพิ่ม BLOB
- ส่งออก BLOB
- เพิ่มภาพเป็น BLOB
- ลดการใช้หน่วยความจำ
- การใช้หน่วยความจำ
- พรีเซนเทชันขนาดใหญ่
- ไฟล์ชั่วคราว
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Java
- Aspose.Slides
description: "จัดการข้อมูล BLOB ใน Aspose.Slides สำหรับ Java เพื่อปรับปรุงการดำเนินการไฟล์ PowerPoint และ OpenDocument ให้มีประสิทธิภาพในการจัดการพรีเซนเทชัน"
---
## **ภาพรวม**

Aspose.Slides มีการจัดการแบบ BLOB สำหรับข้อมูลไบนารีขนาดใหญ่ในงานพรีเซนเทชัน เพื่อช่วยลดการใช้หน่วยความจำเมื่อทำงานกับภาพขนาดใหญ่, ไฟล์เสียง, วิดีโอและไฟล์พรีเซนเทชันขนาดใหญ่

บทความนี้จะแสดงวิธีใช้การประมวลผลแบบ BLOB เพื่อเพิ่มสื่อขนาดใหญ่ลงในพรีเซนเทชัน, ส่งออกสื่อขนาดใหญ่จากพรีเซนเทชัน, และโหลดพรีเซนเทชันขนาดใหญ่อย่างมีประสิทธิภาพมากขึ้น นอกจากนี้ยังอธิบายวิธีการใช้ไฟล์ชั่วคราวระหว่างการประมวลผลและวิธีเปลี่ยนโฟลเดอร์ที่ใช้เก็บไฟล์เหล่านั้น

## **เกี่ยวกับ BLOB**

**BLOB** (**Binary Large Object**) โดยทั่วไปเป็นรายการขนาดใหญ่ (รูปถ่าย, พรีเซนเทชัน, เอกสาร หรือสื่อ) ที่บันทึกในรูปแบบไบนารี

Aspose.Slides for Java อนุญาตให้คุณใช้ BLOB สำหรับออบเจ็กต์ในวิธีที่ช่วยลดการใช้หน่วยความจำเมื่อไฟล์ขนาดใหญ่มีส่วนเกี่ยวข้อง

{{% alert title="Info" color="info" %}}
เพื่อหลีกเลี่ยงข้อจำกัดบางประการเมื่อทำงานกับสตรีม, Aspose.Slides อาจคัดลอกเนื้อหาของสตรีม การโหลดพรีเซนเทชันขนาดใหญ่ผ่านสตรีมจะทำให้เนื้อหาของพรีเซนเทชันถูกคัดลอกและทำให้การโหลดช้า ดังนั้นเมื่อคุณตั้งใจจะโหลดพรีเซนเทชันขนาดใหญ่ เราขอแนะนำอย่างยิ่งให้ใช้เส้นทางไฟล์พรีเซนเทชันแทนการใช้สตรีม
{{% /alert %}}

## **ใช้ BLOB เพื่อลดการใช้หน่วยความจำ**

### **เพิ่มไฟล์ขนาดใหญ่ผ่าน BLOB ไปยังพรีเซนเทชัน**

[Aspose.Slides](/slides/th/java/) for Java อนุญาตให้คุณเพิ่มไฟล์ขนาดใหญ่ (ในกรณีนี้คืไฟล์วิดีโอขนาดใหญ่) ผ่านกระบวนการที่เกี่ยวข้องกับ BLOB เพื่อช่วยลดการใช้หน่วยความจำ

โค้ด Java นี้จะแสดงวิธีเพิ่มไฟล์วิดีโอขนาดใหญ่ผ่านกระบวนการ BLOB ไปยังพรีเซนเทชัน:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// สร้างพรีเซนเทชันใหม่ที่วิดีโอจะถูกเพิ่มเข้าไป
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // เราจะเพิ่มวิดีโอลงในพรีเซนเทชัน - เราเลือกพฤติกรรม KeepLocked เนื่องจากเราต้องการ
        // ไม่ต้องการเข้าถึงไฟล์ "veryLargeVideo.avi" 
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // บันทึกพรีเซนเทชัน ขณะส่งออกพรีเซนเทชันขนาดใหญ่ การใช้หน่วยความจำ
        // คงที่อยู่ในระดับต่ำตลอดอายุการใช้งานของออบเจกต์ pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **ส่งออกไฟล์ขนาดใหญ่ผ่าน BLOB จากพรีเซนเทชัน**
Aspose.Slides for Java อนุญาตให้คุณส่งออกไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์เสียงหรือวิดีโอ) ผ่านกระบวนการที่เกี่ยวข้องกับ BLOB จากพรีเซนเทชัน ตัวอย่างเช่น คุณอาจต้องการแยกไฟล์สื่อขนาดใหญ่จากพรีเซนเทชัน แต่ไม่ต้องการให้ไฟล์นั้นโหลดเข้าไปในหน่วยความจำของคอมพิวเตอร์ การส่งออกไฟล์ผ่านกระบวนการ BLOB ทำให้การใช้หน่วยความจำคงที่อยู่ในระดับต่ำ

โค้ด Java นี้สาธิตการดำเนินการที่อธิบายไว้:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// ล็อกไฟล์แหล่งข้อมูลและไม่โหลดเข้าไปในหน่วยความจำ
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// สร้างอินสแตนซ์ Presentation และล็อกไฟล์ "hugePresentationWithAudiosAndVideos.pptx"
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // เราจะบันทึกวิดีโอแต่ละไฟล์ลงในไฟล์ เพื่อป้องกันการใช้หน่วยความจำสูง เราต้องการบัฟเฟอร์ที่ใช้
    // เพื่อถ่ายโอนข้อมูลจากสตรีมวิดีโอของพรีเซนเทชันไปยังสตรีมของไฟล์วิดีโอที่สร้างใหม่
    byte[] buffer = new byte[8 * 1024];

    // วนรอบผ่านวิดีโอทั้งหมด
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // เปิดสตรีมวิดีโอของพรีเซนเทชัน โปรดทราบว่าเราหลีกเลี่ยงการเข้าถึงคุณสมบัติ
        // เช่น video.BinaryData - เพราะคุณสมบัตินี้คืนอาเรย์ไบต์ที่มีวิดีโอเต็มรูปแบบ ซึ่งจะทำให้ไบต์ถูกโหลดเข้าไปในหน่วยความจำ
        // เราใช้ video.GetStream ซึ่งจะคืน Stream - และไม่
        //  ต้องการให้เราผลิตโหลดวิดีโอทั้งหมดเข้าไปในหน่วยความจำ
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
        // การใช้หน่วยความจำจะคงที่ต่ำไม่ว่าจะเป็นขนาดของวิดีโอหรือพรีเซนเทชันก็ตาม
    }
    // หากจำเป็น คุณสามารถทำขั้นตอนเดียวกันสำหรับไฟล์เสียงได้
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **เพิ่มภาพเป็น BLOB ไปยังพรีเซนเทชัน**
ด้วยเมธอดจากอินเทอร์เฟซ [**IImageCollection**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IImageCollection) และคลาส [**ImageCollection** ](https://reference.aspose.com/slides/th/java/com.aspose.slides/ImageCollection) คุณสามารถเพิ่มภาพขนาดใหญ่เป็นสตรีมเพื่อให้ถูกจัดการเป็น BLOB

โค้ด Java นี้จะแสดงวิธีเพิ่มภาพขนาดใหญ่ผ่านกระบวนการ BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// สร้างพรีเซนเทชันใหม่ที่ภาพจะถูกเพิ่มเข้าไป.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// เราจะเพิ่มภาพลงในพรีเซนเทชัน - เราเลือกพฤติกรรม KeepLocked เนื่องจากเราต้องการ
		// ไม่ต้องการเข้าถึงไฟล์ "largeImage.png" file.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// บันทึกพรีเซนเทชัน ขณะส่งออกพรีเซนเทชันขนาดใหญ่ การใช้หน่วยความจำ
		// คงที่อยู่ในระดับต่ำตลอดอายุการใช้งานของออบเจกต์ pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **หน่วยความจำและพรีเซนเทชันขนาดใหญ่**

โดยปกติการโหลดพรีเซนเทชันขนาดใหญ่ คอมพิวเตอร์จะต้องใช้หน่วยความจำชั่วคราวจำนวนมาก เนื้อหาทั้งหมดของพรีเซนเทชันจะถูกโหลดเข้าสู่หน่วยความจำและไฟล์ต้นฉบับ (ที่พรีเซนเทชันโหลดมาจาก) จะหยุดถูกใช้งาน

ลองพิจารณาพรีเซนเทชัน PowerPoint ขนาดใหญ่ (large.pptx) ที่มีไฟล์วิดีโอขนาด 1.5 GB วิธีมาตรฐานในการโหลดพรีเซนเทชันถูกอธิบายในโค้ด Java นี้:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

แต่วิธีนี้ใช้หน่วยความจำชั่วคราวประมาณ 1.6 GB

### **โหลดพรีเซนเทชันขนาดใหญ่เป็น BLOB**

ผ่านกระบวนการที่เกี่ยวข้องกับ BLOB คุณสามารถโหลดพรีเซนเทชันขนาดใหญ่โดยใช้หน่วยความจำน้อย โค้ด Java นี้อธิบายการนำ BLOB มาใช้ในการโหลดไฟล์พรีเซนเทชันขนาดใหญ่ (large.pptx):

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

เมื่อใช้กระบวนการ BLOB คอมพิวเตอร์ของคุณจะสร้างไฟล์ชั่วคราวในโฟลเดอร์เริ่มต้นสำหรับไฟล์ชั่วคราว หากคุณต้องการให้ไฟล์ชั่วคราวถูกเก็บไว้ในโฟลเดอร์อื่น คุณสามารถเปลี่ยนการตั้งค่าที่จัดเก็บโดยใช้ `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
เมื่อคุณใช้ `TempFilesRootPath` Aspose.Slides จะไม่สร้างโฟลเดอร์สำหรับเก็บไฟล์ชั่วคราวโดยอัตโนมัติ คุณต้องสร้างโฟลเดอร์นั้นด้วยตนเอง
{{% /alert %}}

### **ทำลายออบเจ็กต์ Presentation เพื่อปล่อยหน่วยความจำ**

เมื่อประมวลผลพรีเซนเทชันขนาดใหญ่ ให้ตรวจสอบว่าอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ถูกทำลายอย่างถูกต้องเพื่อให้หน่วยความจำที่ใช้งานถูกปล่อยออกมา เรียก `dispose()` หลังจากที่คุณใช้พรีเซนเทชันเสร็จสิ้นเพื่อปล่อยทรัพยากรที่ไม่ได้จัดการ

```java
Presentation presentation = new Presentation("large.pptx");

// ...ดำเนินการพรีเซนเทชัน...
presentation.save("large.pdf", SaveFormat.Pdf);

// ปล่อยทรัพยากรโดยเจตนาชัดเจน.
presentation.dispose();
```

## **คำถามที่พบบ่อย**

**ข้อมูลใดในพรีเซนเทชัน Aspose.Slides ถูกจัดการเป็น BLOB และควบคุมโดยตัวเลือก BLOB?**  
วัตถุไบนารีขนาดใหญ่เช่นรูปภาพ, ไฟล์เสียงและวิดีโอจะถูกจัดการเป็น BLOB ไฟล์พรีเซนเทชันทั้งหมดก็มีส่วนเกี่ยวข้องกับการจัดการ BLOB เมื่อมีการโหลดหรือบันทึก วัตถุเหล่านี้จะถูกควบคุมโดยนโยบาย BLOB ที่ช่วยให้คุณจัดการการใช้หน่วยความจำและการเขียนลงไฟล์ชั่วคราวเมื่อจำเป็น

**ฉันตั้งค่าเงื่อนไขการจัดการ BLOB ระหว่างการโหลดพรีเซนเทชันได้ที่ไหน?**  
ใช้ [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/) ร่วมกับ [BlobManagementOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/blobmanagementoptions/) ที่นั่นคุณสามารถกำหนดขีดจำกัดการเก็บ BLOB ในหน่วยความจำ, เปิดหรือปิดการใช้ไฟล์ชั่วคราว, ระบุเส้นทางรากสำหรับไฟล์ชั่วคราว, และเลือกพฤติกรรมการล็อกแหล่งข้อมูล

**การตั้งค่า BLOB มีผลต่อประสิทธิภาพหรือไม่ และฉันจะปรับสมดุลระหว่างความเร็วกับหน่วยความจำอย่างไร?**  
มีผล การเก็บ BLOB ไว้ในหน่วยความจำทำให้ความเร็วสูงสุดแต่ใช้ RAM มาก; การลดขีดจำกัดหน่วยความจำจะทำให้งานบางส่วนย้ายไปยังไฟล์ชั่วคราว ลด RAM แต่เพิ่ม I/O ใช้เมธอด [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/th/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) เพื่อหาจุดสมดุลที่เหมาะกับการทำงานและสภาพแวดล้อมของคุณ

**ตัวเลือก BLOB ช่วยเมื่อเปิดพรีเซนเทชันที่ใหญ่มาก (เช่นหลายกิกะไบต์) หรือไม่?**  
ใช่ [BlobManagementOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/blobmanagementoptions/) ถูกออกแบบมาสำหรับสถานการณ์เช่นนี้: การเปิดใช้งานไฟล์ชั่วคราวและการล็อกแหล่งข้อมูลสามารถลดการใช้ RAM สูงสุดและทำให้การประมวลผลพรีเซนเทชันขนาดใหญ่อยู่ในสภาพเสถียรได้อย่างมาก

**ฉันสามารถใช้นโยบาย BLOB เมื่อโหลดจากสตรีมแทนไฟล์บนดิสก์ได้หรือไม่?**  
ได้ กฎเดียวกันใช้กับสตรีม: อินสแตนซ์พรีเซนเทชันสามารถเป็นเจ้าของและล็อกสตรีมอินพุต (ขึ้นอยู่กับโหมดล็อกที่เลือก) และไฟล์ชั่วคราวจะถูกใช้เมื่อได้รับอนุญาต ทำให้การใช้หน่วยความจำคาดการณ์ได้ระหว่างการประมวลผล.