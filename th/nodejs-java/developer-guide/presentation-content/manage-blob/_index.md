---
title: "จัดการ BLOB ของพรีเซนเทชันใน JavaScript เพื่อการใช้หน่วยความจำที่มีประสิทธิภาพ"
linktitle: "จัดการ BLOB"
type: docs
weight: 10
url: /th/nodejs-java/manage-blob/
keywords:
  - "วัตถุขนาดใหญ่"
  - "รายการขนาดใหญ่"
  - "ไฟล์ขนาดใหญ่"
  - "เพิ่ม BLOB"
  - "ส่งออก BLOB"
  - "เพิ่มภาพเป็น BLOB"
  - "ลดการใช้หน่วยความจำ"
  - "การใช้หน่วยความจำ"
  - "พรีเซนเทชันขนาดใหญ่"
  - "ไฟล์ชั่วคราว"
  - "PowerPoint"
  - "OpenDocument"
  - "พรีเซนเทชัน"
  - "Node.js"
  - "JavaScript"
  - "Aspose.Slides"
description: "จัดการข้อมูล BLOB ใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js เพื่อทำให้การดำเนินงานไฟล์ PowerPoint และ OpenDocument มีประสิทธิภาพในการจัดการพรีเซนเทชัน"
---
## **ภาพรวม**

Aspose.Slides ให้การจัดการแบบ BLOB สำหรับข้อมูลไบนารีขนาดใหญ่ในพรีเซนเทชันเพื่อช่วยลดการใช้หน่วยความจำเมื่อทำงานกับรูปภาพขนาดใหญ่, ไฟล์เสียง, วิดีโอและไฟล์พรีเซนเทชัน

บทความนี้แสดงวิธีการใช้การประมวลผลแบบ BLOB เพื่อเพิ่มสื่อขนาดใหญ่ในพรีเซนเทชัน, ส่งออกสื่อขนาดใหญ่จากพรีเซนเทชัน, และโหลดพรีเซนเทชันขนาดใหญ่อย่างมีประสิทธิภาพมากขึ้น นอกจากนี้ยังอธิบายวิธีใช้ไฟล์ชั่วคราวระหว่างการประมวลผลและวิธีเปลี่ยนโฟลเดอร์ที่ใช้เก็บไฟล์เหล่านั้น

## **เกี่ยวกับ BLOB**

**BLOB** (**Binary Large Object**) โดยทั่วไปหมายถึงรายการขนาดใหญ่ (รูปภาพ, พรีเซนเทชัน, เอกสาร หรือสื่อ) ที่บันทึกในรูปแบบไบนารี

Aspose.Slides for Node.js via Java อนุญาตให้คุณใช้ BLOB สำหรับอ็อบเจ็กต์ในลักษณะที่ลดการใช้หน่วยความจำเมื่อมีไฟล์ขนาดใหญ่เกี่ยวข้อง

{{% alert title="Info" color="info" %}}

เพื่อหลีกเลี่ยงข้อจำกัดบางอย่างเมื่อทำงานกับสตรีม, Aspose.Slides อาจคัดลอกเนื้อหาของสตรีม การโหลดพรีเซนเทชันขนาดใหญ่ผ่านสตรีมจะทำให้คัดลอกเนื้อหาของพรีเซนเทชันและทำให้การโหลดช้า ดังนั้นเมื่อคุณต้องการโหลดพรีเซนเทชันขนาดใหญ่ เราแนะนำอย่างยิ่งให้ใช้เส้นทางไฟล์พรีเซนเทชันแทนการใช้สตรีม

{{% /alert %}}

## **ใช้ BLOB เพื่อลดการใช้หน่วยความจำ**

### **เพิ่มไฟล์ขนาดใหญ่ผ่าน BLOB ไปยังพรีเซนเทชัน**

[Aspose.Slides](/slides/th/nodejs-java/) for Node.js via Java อนุญาตให้คุณเพิ่มไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์วิดีโอขนาดใหญ่) ผ่านกระบวนการที่ใช้ BLOB เพื่อ ลดการใช้หน่วยความจำ

โค้ด JavaScript นี้แสดงวิธีการเพิ่มไฟล์วิดีโอขนาดใหญ่ผ่านกระบวนการ BLOB ไปยังพรีเซนเทชัน:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// สร้างพรีเซนเทชันใหม่ที่วิดีโอจะถูกเพิ่มเข้าไป
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
            // มาดึงวิดีโอเข้าไปในพรีเซนเทชัน - เราเลือกพฤติกรรม KeepLocked เพราะเราต้องการ
            // ไม่ตั้งใจเข้าถึงไฟล์ "veryLargeVideo.avi" 
            var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
            pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
            // บันทึกพรีเซนเทชัน ระหว่างที่พรีเซนเทชันขนาดใหญ่ถูกสร้างออกมา การใช้หน่วยความจำ
            // จะคงอยู่ระดับต่ำตลอดวงจรอายุของวัตถุ pres
            pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ส่งออกไฟล์ขนาดใหญ่ผ่าน BLOB จากพรีเซนเทชัน**

Aspose.Slides for Node.js via Java อนุญาตให้คุณส่งออกไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์เสียงหรือวิดีโอ) ผ่านกระบวนการที่ใช้ BLOB จากพรีเซนเทชัน  ตัวอย่างเช่น คุณอาจต้องการแยกไฟล์สื่อขนาดใหญ่จากพรีเซนเทชันโดยไม่ต้องโหลดไฟล์เข้าสู่หน่วยความจำของคอมพิวเตอร์ การส่งออกไฟล์ผ่านกระบวนการ BLOB จะช่วยให้การใช้หน่วยความจำน้อยลง

โค้ด JavaScript นี้แสดงการทำงานที่อธิบายไว้:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// ล็อกไฟล์ต้นทางและไม่โหลดเข้าหน่วยความจำ
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// สร้างอินสแตนซ์ Presentation, ล็อกไฟล์ "hugePresentationWithAudiosAndVideos.pptx"
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // มาบันทึกวิดีโอแต่ละไฟล์ เพื่อป้องกันการใช้หน่วยความจำสูง เราจำเป็นต้องมีบัฟเฟอร์ที่จะใช้
    // เพื่อถ่ายโอนข้อมูลจากสตรีมวิดีโอของพรีเซนเทชันไปยังสตรีมของไฟล์วิดีโอที่สร้างใหม่
    var buffer = new byte[8 * 1024];
    // วนผ่านวิดีโอทั้งหมด
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // เปิดสตรีมวิดีโอของพรีเซนเทชัน โปรดทราบว่าเราตั้งใจหลีกเลี่ยงการเข้าถึงคุณสมบัติ
        // เช่น video.BinaryData - เพราะคุณสมบัตินี้จะคืนอาร์เรย์ไบต์ที่มีวิดีโอเต็ม ซึ่งจะทำให้
        // ไบต์ถูกโหลดเข้าหน่วยความจำ เราใช้ video.GetStream ซึ่งจะคืน Stream - และไม่ต้อง
        // โหลดวิดีโอทั้งหมดเข้าสู่หน่วยความจำ
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // การใช้หน่วยความจำจะคงอยู่ระดับต่ำไม่ว่า video หรือพรีเซนเทชันจะใหญ่แค่ไหน
    }
    // หากจำเป็น สามารถใช้ขั้นตอนเดียวกันกับไฟล์เสียงได้
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **เพิ่มรูปภาพเป็น BLOB ในพรีเซนเทชัน**

ด้วยเมธอดจากคลาส [**ImageCollection**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ImageCollection) และคลาส [**ImageCollection**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ImageCollection) คุณสามารถเพิ่มรูปภาพขนาดใหญ่เป็นสตรีมเพื่อให้ถือเป็น BLOB

โค้ด JavaScript นี้แสดงวิธีการเพิ่มรูปภาพขนาดใหญ่ผ่านกระบวนการ BLOB:

```javascript
var pathToLargeImage = "large_image.jpg";
// creates a new presentation to which the image will be added.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Let's add the image to the presentation - we choose KeepLocked behavior because we do
        // NOT intend to access the "largeImage.png" file.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Saves the presentation. While a large presentation gets outputted, the memory consumption
        // stays low through the pres object's lifecycle
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **หน่วยความจำและพรีเซนเทชันขนาดใหญ่**

โดยทั่วไป เพื่อลoadพรีเซนเทชันขนาดใหญ่ คอมพิวเตอร์จะต้องใช้หน่วยความจำชั่วคราวจำนวนมาก เนื้อหาทั้งหมดของพรีเซนเทชันจะถูกโหลดเข้าสู่หน่วยความจำและไฟล์ (ซึ่งพรีเซนเทชันถูกโหลดจากนั้น) จะหยุดใช้งาน

พิจารณาพรีเซนเทชัน PowerPoint ขนาดใหญ่ (large.pptx) ที่มีไฟล์วิดีโอขนาด 1.5 GB วิธีมาตรฐานในการโหลดพรีเซนเทชันถูกอธิบายในโค้ด JavaScript นี้:

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

แต่วิธีนี้ใช้หน่วยความจำชั่วคราวประมาณ 1.6 GB

### **โหลดพรีเซนเทชันขนาดใหญ่เป็น BLOB**

ผ่านกระบวนการที่ใช้ BLOB คุณสามารถโหลดพรีเซนเทชันขนาดใหญ่โดยใช้หน่วยความจำเพียงเล็กน้อย โค้ด JavaScript นี้อธิบายการใช้งานที่ใช้กระบวนการ BLOB เพื่อโหลดไฟล์พรีเซนเทชันขนาดใหญ่ (large.pptx):

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **เปลี่ยนโฟลเดอร์สำหรับไฟล์ชั่วคราว**

เมื่อใช้กระบวนการ BLOB คอมพิวเตอร์ของคุณจะสร้างไฟล์ชั่วคราวในโฟลเดอร์เริ่มต้นสำหรับไฟล์ชั่วคราว หากต้องการให้ไฟล์ชั่วคราวเก็บในโฟลเดอร์อื่น คุณสามารถเปลี่ยนการตั้งค่าการจัดเก็บโดยใช้ `setTempFilesRootPath`:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}

เมื่อคุณใช้ `setTempFilesRootPath` Aspose.Slides จะไม่สร้างโฟลเดอร์สำหรับเก็บไฟล์ชั่วคราวโดยอัตโนมัติ คุณต้องสร้างโฟลเดอร์นั้นด้วยตนเอง

{{% /alert %}}

### **ปล่อยวัตถุ Presentation เพื่อคืนหน่วยความจำ**

เมื่อประมวลผลพรีเซนเทชันขนาดใหญ่ ตรวจสอบให้แน่ใจว่าตัวอย่าง [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ถูกปล่อยอย่างเหมาะสมเพื่อให้หน่วยความจำที่ครอบครองถูกคืนค่า เรียก `dispose()` หลังจากใช้พรีเซนเทชันเสร็จเพื่อปลดปล่อยทรัพยากรที่ไม่ได้จัดการ

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...ประมวลผลพรีเซนเทชัน...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// ปล่อยทรัพยากรอย่างชัดเจน.
presentation.dispose();
```

## **FAQ**

**ข้อมูลใดในพรีเซนเทชัน Aspose.Slides ถือเป็น BLOB และถูกควบคุมโดยตัวเลือก BLOB?**

อ็อบเจ็กต์ไบนารีขนาดใหญ่เช่นรูปภาพ, เสียง และวิดีโอถือเป็น BLOB ทั้งไฟล์พรีเซนเทชันทั้งหมดก็เกี่ยวข้องกับการจัดการ BLOB เมื่อโหลดหรือบันทึก สิ่งเหล่านี้ถูกควบคุมโดยนโยบาย BLOB ที่ให้คุณจัดการการใช้หน่วยความจำและการสลับไปยังไฟล์ชั่วคราวเมื่อจำเป็น

**ฉันกำหนดกฎการจัดการ BLOB ระหว่างการโหลดพรีเซนเทชันได้ที่ไหน?**

ใช้ [LoadOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/) ร่วมกับ [BlobManagementOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/blobmanagementoptions/) ที่นั่นคุณตั้งค่าขีดจำกัดหน่วยความจำสำหรับ BLOB, อนุญาตหรือไม่อนุญาตไฟล์ชั่วคราว, เลือกเส้นทางรากสำหรับไฟล์ชั่วคราว, และกำหนดพฤติกรรมการล็อคแหล่งข้อมูล

**การตั้งค่า BLOB มีผลต่อประสิทธิภาพหรือไม่ และฉันจะปรับสมดุลความเร็วกับหน่วยความจำอย่างไร?**

มีผล การเก็บ BLOB ในหน่วยความจำทำให้ความเร็วสูงสุดแต่ใช้ RAM มากขึ้น; การลดขีดจำกัดหน่วยความจำจะย้ายงานไปยังไฟล์ชั่วคราว ลด RAM แต่เพิ่ม I/O ใช้เมธอด [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) เพื่อหาจุดสมดุลที่เหมาะกับงานและสภาพแวดล้อมของคุณ

**ตัวเลือก BLOB ช่วยเมื่อเปิดพรีเซนเทชันที่ใหญ่สุด (เช่นหลายกิกะไบต์) หรือไม่?**

ช่วย [BlobManagementOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/blobmanagementoptions/) ถูกออกแบบมาสำหรับสถานการณ์เช่นนี้: การเปิดไฟล์ชั่วคราวและการล็อคแหล่งข้อมูลสามารถลดการใช้ RAM สูงสุดและทำให้การประมวลผลเสถียรสำหรับเด็คที่ใหญ่มาก

**ฉันสามารถใช้กฎ BLOB เมื่อโหลดจากสตรีมแทนไฟล์บนดิสก์ได้หรือไม่?**

ได้ กฎเดียวกันใช้กับสตรีม: อินสแตนซ์พรีเซนเทชันสามารถเป็นเจ้าของและล็อคสตรีมอินพุต (ขึ้นอยู่กับโหมดล็อคที่เลือก) และไฟล์ชั่วคราวจะถูกใช้เมื่ออนุญาต ทำให้การใช้หน่วยความจำสามารถคาดเดาได้ระหว่างการประมวลผล