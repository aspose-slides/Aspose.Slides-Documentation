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
- ทรัพยากรภายนอก
- อ็อบเจกต์ไบนารี
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีเปิดงานนำเสนอ PowerPoint และ OpenDocument ใน JavaScript, จัดหารหัสผ่านเปิดไฟล์, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **บทนำ**

[Aspose.Slides สำหรับ Node.js ผ่าน Java](https://products.aspose.com/slides/th/nodejs-java/) สามารถโหลดงานนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกในรูปแบบเดิมหรือรูปแบบที่รองรับอื่นๆ

พฤติกรรมการโหลดสามารถปรับแต่งได้ผ่านคลาส LoadOptions ตัวอย่างเช่น คุณสามารถระบุรหัสผ่านเปิดไฟล์ เก็บอ็อบเจกต์ไบนารีขนาดใหญ่ให้อยู่ด้านนอกหน่วยความจำของ Node.js ควบคุมทรัพยากรภายนอก หรือละเว้นข้อมูลไบนารีที่ฝังอยู่

## **เปิดงานนำเสนอ**

หลังจากโหลดไฟล์หรือสตรีม คุณสามารถ [กำหนดรูปแบบงานนำเสนอต้นฉบับ](/slides/th/nodejs-java/detect-presentation-source-format/) เพื่อเลือกวิธีการที่แอปพลิเคชันของคุณจะประมวลผล

ในการเปิดงานนำเสนอที่มีอยู่ ให้ส่งพาธไฟล์ไปยังคอนสตรัคเตอร์ Presentation ปล่อยทรัพยากรงานนำเสนอหลังการใช้งานเพื่อให้ตัวจัดการไฟล์ ข้อมูลชั่วคราว และทรัพยากรอื่นๆ ถูกคืนค่าโดยเร็ว

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

## **เปิดงานนำเสนอที่ป้องกันด้วยรหัสผ่าน**

รหัสผ่านเปิดไฟล์จะเข้ารหัสเนื้อหาของงานนำเสนอ เพื่อโหลดงานนำเสนอเต็มรูปแบบ ให้ส่งรหัสผ่านที่ถูกต้องไปยัง LoadOptions.setPassword และส่งอ็อบเจกต์ตัวเลือกไปยังคอนสตรัคเตอร์ Presentation การโหลดจะล้มเหลวหากรหัสผ่านหายไปหรือไม่ถูกต้อง

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

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และเวิร์กโฟลว์การเข้ารหัส ดูงานนำเสนอที่ป้องกันด้วยรหัสผ่าน หากงานนำเสนอที่เข้ารหัสถูกบันทึกโดยกำหนดคุณสมบัติบันทึกสาธารณะ คุณสมบัติเหล่านั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดูจัดการคุณสมบัติงานนำเสนอ

## **เปิดงานนำเสนอขนาดใหญ่**

LoadOptions.getBlobManagementOptions คืนค่าตัวเลือกที่ควบคุมวิธีที่ Aspose.Slides จัดการวัตถุไบนารีขนาดใหญ่ เช่น รูปภาพ, เสียง, และวิดีโอ คุณสามารถล็อกไฟล์ต้นฉบับไว้, อนุญาตไฟล์ชั่วคราว, และจำกัดปริมาณข้อมูล BLOB ที่เก็บไว้ในหน่วยความจำ

โค้ด JavaScript ด้านล่างสาธิตการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

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

{{% alert color="info" title="Note" %}}
ด้วย PresentationLockingBehavior.KeepLocked ไฟล์ต้นฉบับจะคงถูกล็อกจนกว่าจะปล่อยอินสแตนซ์ของงานนำเสนอ อย่าย้าย, เขียนทับ, หรือ ลบไฟล์ต้นฉบับในขณะที่อินสแตนซ์ยังคงอยู่

Aspose.Slides อาจคัดลอกเนื้อหาของสตรีมอินพุตระหว่างการโหลด สำหรับงานนำเสนอขนาดใหญ่ การใช้พาธไฟล์จึงมักมีประสิทธิภาพกว่าสตรีม ดูจัดการ BLOBs สำหรับตัวเลือกการจัดเก็บและการจัดการหน่วยความจำเพิ่มเติม
{{% /alert %}}

## **ควบคุมทรัพยากรภายนอก**

LoadOptions.setResourceLoadingCallback ยอมรับการนำไปใช้ของ IResourceLoadingCallback คอลแบ็กสามารถให้ข้อมูลทดแทน, เปลี่ยนเส้นทางทรัพยากร, ใช้ตัวโหลดค่าเริ่มต้น, หรือข้ามทรัพยากร การทำเช่นนี้มีประโยชน์เมื่องานนำเสนอมีรูปภาพภายนอกที่ต้องแก้ไขตามกฎด้านความปลอดภัยหรือการจัดเก็บของแอปพลิเคชัน

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

## **โหลดงานนำเสนอโดยไม่มีอ็อบเจกต์ไบนารีฝังอยู่**

งานนำเสนออาจมีข้อมูลไบนารีฝังอยู่ที่แอปพลิเคชันไม่ต้องการหรือไม่ต้องการเก็บ ตัวอย่างเช่น:

- โครงการ VBA ที่เข้าถึงได้ผ่าน Presentation.getVbaProject;
- ข้อมูล OLE ฝังอยู่ ที่เข้าถึงได้ผ่าน OleEmbeddedDataInfo.getEmbeddedFileData;
- ข้อมูลควบคุม ActiveX ที่เข้าถึงได้ผ่าน Control.getActiveXControlBinary.

ตั้งค่า LoadOptions.setDeleteEmbeddedBinaryObjects เป็น `true` เพื่อเอาข้อมูลไบนารีนี้ออกขณะโหลด บันทึกงานนำเสนอที่โหลดแล้วเพื่อเก็บผลลัพธ์ที่ทำความสะอาด

ตัวเลือกนี้ช่วยลดการเปิดเผยต่อข้อมูลฝังที่ไม่ต้องการ แต่ไม่ได้เป็นระบบตรวจจับมัลแวร์หรือทำความสะอาดเนื้อหาที่ครบถ้วน

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

## **คำถามที่พบบ่อย**

**ฉันจะทราบได้อย่างไรว่าไฟล์เสียและไม่สามารถเปิดได้?**

Aspose.Slides จะทำการโยนข้อยกเว้นการแยกวิเคราะห์หรือรูปแบบระหว่างการโหลด ให้จัดการความล้มเหลวนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้อง เพื่อให้แอปพลิเคชันสามารถรายงานสาเหตุได้อย่างแม่นยำ

**จะเกิดอะไรขึ้นหากฟอนท์ที่จำเป็นหายไป?**

งานนำเสนอยังคงโหลดได้ แต่การเรนเดอร์และการส่งออกอาจใช้ฟอนท์ทดแทน คุณสามารถกำหนดค่าการทดแทนฟอนท์หรือจัดหาแบบอักษรแบบกำหนดเองเพื่อทำให้ผลลัพธ์คาดเดาได้มากขึ้น

**การโหลดงานนำเสนอจะโหลดสื่อที่ฝังอยู่ด้วยหรือไม่?**

เสียงและวิดีโอที่ฝังอยู่จะพร้อมใช้งานผ่านโมเดลอ็อบเจกต์ของงานนำเสนอ ทรัพยากรภายนอกจะถูกแก้ไขตามพฤติกรรมการโหลดทรัพยากรที่กำหนดและอาจไม่สามารถเข้าถึงได้หากตำแหน่งของมันไม่สามารถเข้าถึงได้