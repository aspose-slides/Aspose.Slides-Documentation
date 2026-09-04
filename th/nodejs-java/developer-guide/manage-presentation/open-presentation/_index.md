---
title: เปิดงานนำเสนอใน JavaScript
linktitle: เปิดงานนำเสนอ
type: docs
weight: 20
url: /th/nodejs-java/open-presentation/
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
- แหล่งข้อมูลภายนอก
- วัตถุไบนารี
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีเปิดงานนำเสนอ PowerPoint และ OpenDocument ด้วย JavaScript, ระบุรหัสผ่านเปิดไฟล์, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **Introduction**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/th/nodejs-java/) สามารถโหลดงานนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกไฟล์ในรูปแบบเดิมหรือรูปแบบที่รองรับอื่นได้

พฤติกรรมการโหลดสามารถปรับแต่งได้ผ่านคลาส [LoadOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถกำหนดรหัสผ่านเปิดไฟล์ เก็บวัตถุไบนารีขนาดใหญ่ให้อยู่ไกลจากหน่วยความจำของ Node.js ควบคุมแหล่งข้อมูลภายนอก หรือละเว้นข้อมูลไบนารีฝังตัว

## **Open Presentations**

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้ส่งพาธไฟล์ไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) หลังจากใช้งานเสร็จควรทำการDisposeงานนำเสนอเพื่อให้การจัดการไฟล์ชั่วคราวและทรัพยากรอื่น ๆ ถูกปล่อยออกอย่างทันท่วงที

ตัวอย่าง JavaScript ด้านล่างแสดงวิธีเปิดงานนำเสนอและรับจำนวนสไลด์:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Open Password-Protected Presentations**

รหัสผ่านเปิดไฟล์จะเข้ารหัสเนื้อหาของงานนำเสนอ เพื่อโหลดงานนำเสนอทั้งหมดให้ส่งรหัสผ่านที่ถูกต้องไปที่ [LoadOptions.setPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setPassword) แล้วให้ตัวเลือกนั้นกับคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) หากไม่มีหรือรหัสผ่านไม่ถูกต้องการโหลดจะล้มเหลว

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และกระบวนการเข้ารหัส ดูที่ [Password-Protect Presentations](/slides/th/nodejs-java/password-protected-presentation/) หากงานนำเสนอที่เข้ารหัสถูกบันทึกโดยตั้งค่าคุณสมบัติเอกสารสาธารณะ คุณสมบัติเหล่านั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดูที่ [Manage Presentation Properties](/slides/th/nodejs-java/presentation-properties/)

## **Open Large Presentations**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) คืนค่าตัวเลือกที่ควบคุมวิธีที่ Aspose.Slides จัดการวัตถุไบนารีขนาดใหญ่เช่น รูปภาพ, เสียง และวิดีโอ คุณสามารถบังคับให้ไฟล์แหล่งที่มาถูกล็อก อนุญาตให้สร้างไฟล์ชั่วคราว และจำกัดปริมาณข้อมูล BLOB ที่เก็บในหน่วยความจำ

ตัวอย่าง JavaScript ด้านล่างแสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="หมายเหตุ" %}}
ด้วย [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) ไฟล์แหล่งที่มาจะยังคงถูกล็อกจนกว่าตัวอินสแตนซ์ Presentation จะถูกDispose อย่าย้าย เขียนทับ หรือทำลายไฟล์แหล่งที่มาขณะอินสแตนซ์นั้นยังคงอยู่

Aspose.Slides อาจคัดลอกเนื้อหาจากสตรีมอินพุตขณะโหลด สำหรับงานนำเสนอขนาดใหญ่ การใช้พาธไฟล์จึงโดยทั่วไปมีประสิทธิภาพมากกว่าสตรีม ดูที่ [Manage BLOBs](/slides/th/nodejs-java/manage-blob/) สำหรับตัวเลือกการจัดเก็บและการจัดการหน่วยความจำเพิ่มเติม
{{% /alert %}}

## **Control External Resources**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) รับการนำไปใช้ของ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iresourceloadingcallback/) คอลแบ็กสามารถจัดหาข้อมูลทดแทน เปลี่ยนเส้นทางของแหล่งข้อมูล ใช้ตัวโหลดเริ่มต้น หรือข้ามแหล่งข้อมูลได้ ซึ่งเป็นประโยชน์เมื่องานนำเสนอมีรูปภาพภายนอกที่ต้องถูกแก้ไขตามกฎความปลอดภัยหรือการจัดเก็บของแอปพลิเคชัน

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Load Presentations without Embedded Binary Objects**

งานนำเสนออาจมีข้อมูลไบนารีฝังตัวที่แอปพลิเคชันไม่ต้องการหรือไม่ต้องการเก็บ ตัวอย่างเช่น

- โปรเจกต์ VBA ที่เข้าถึงได้ผ่าน [Presentation.getVbaProject](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getVbaProject);
- ข้อมูล OLE ฝังตัวที่เข้าถึงได้ผ่าน [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ข้อมูลคอนโทรล ActiveX ที่เข้าถึงได้ผ่าน [Control.getActiveXControlBinary](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

ตั้งค่า [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) เป็น `true` เพื่อทำการลบข้อมูลไบนารีเหล่านี้ขณะโหลด จากนั้นบันทึกงานนำเสนอที่โหลดแล้วเพื่อให้ผลลัพธ์ที่ทำความสะอาดถูกบันทึก

ตัวเลือกนี้ช่วยลดการเปิดเผยต่อข้อมูลฝังตัวที่ไม่พึงประสงค์ แต่ไม่ได้เป็นระบบตรวจหามัลแวร์หรือทำความสะอาดเนื้อหาอย่างสมบูรณ์

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**ฉันจะรู้ได้อย่างไรว่าไฟล์เสียหายและไม่สามารถเปิดได้?**

Aspose.Slides จะโยนข้อยกเว้นการแปลงหรือรูปแบบขณะโหลด ให้จัดการความล้มเหลวนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้องเพื่อให้แอปพลิเคชันสามารถรายงานสาเหตุได้อย่างแม่นยำ

**จะเกิดอะไรขึ้นหากฟอนต์ที่จำเป็นหายไป?**

งานนำเสนอยังคงโหลดได้ แต่การเรนเดอร์และการส่งออกอาจใช้ฟอนต์ทดแทน คุณสามารถ [configure font substitution](/slides/th/nodejs-java/font-substitution/) หรือ [provide custom fonts](/slides/th/nodejs-java/custom-font/) เพื่อทำให้ผลลัพธ์คาดเดาได้มากขึ้น

**การโหลดงานนำเสนอจะโหลดสื่อฝังตัวด้วยหรือไม่?**

สื่อเสียงและวิดีโอที่ฝังอยู่จะพร้อมใช้งานผ่านโมเดลออบเจกต์ของงานนำเสนอ แหล่งข้อมูลภายนอกจะได้รับการแก้ไขตามพฤติกรรมการโหลดที่กำหนดและอาจไม่สามารถใช้งานได้หากไม่สามารถเข้าถึงตำแหน่งที่ตั้งของพวกมันได้