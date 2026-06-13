---
title: เปิดงานนำเสนอใน JavaScript
linktitle: เปิดงานนำเสนอ
type: docs
weight: 20
url: /th/nodejs-java/open-presentation/
keywords:
- เปิด PowerPoint
- เปิด OpenDocument
- เปิดงานนำเสนอ
- เปิด PPTX
- เปิด PPT
- เปิด ODP
- โหลดงานนำเสนอ
- โหลด PPTX
- โหลด PPT
- โหลด ODP
- งานนำเสนอที่มีการป้องกัน
- งานนำเสนอขนาดใหญ่
- ทรัพยากรภายนอก
- อ็อบเจ็กต์ไบนารี
- Node.js
- JavaScript
- Aspose.Slides
description: "เปิดงานนำเสนอ PowerPoint (.pptx, .ppt) และ OpenDocument (.odp) อย่างง่ายดายด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java—เร็ว น่าเชื่อถือ มีคุณสมบัติครบถ้วน."
---
## **บทนำ**

นอกเหนือจากการสร้างงานนำเสนอ PowerPoint ตั้งแต่ต้น Aspose.Slides ยังทำให้คุณเปิดงานนำเสนอที่มีอยู่ได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถดึงข้อมูลเกี่ยวกับมัน แก้ไขเนื้อหาสไลด์ เพิ่มสไลด์ใหม่ ลบสไลด์ที่มีอยู่ และอื่น ๆ อีกมาก

## **เปิดงานนำเสนอ**

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และส่งเส้นทางไฟล์ไปยังคอนสตรัคเตอร์ของมัน

ตัวอย่าง JavaScript ด้านล่างแสดงวิธีการเปิดงานนำเสนอและรับจำนวนสไลด์ของมัน:

```js
// สร้างอินสแตนซ์ของคลาส Presentation และส่งเส้นทางไฟล์ไปยังคอนสตรัคเตอร์ของมัน.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // แสดงจำนวนสไลด์ทั้งหมดในงานนำเสนอ.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **เปิดงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน**

เมื่อคุณต้องการเปิดงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน ให้ส่งรหัสผ่านผ่านเมธอด [setPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setPassword) ของคลาส [LoadOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/) เพื่อถอดรหัสและโหลดงานนำเสนอ ตัวอย่างโค้ด JavaScript ด้านล่างแสดงการดำเนินการนี้:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // ดำเนินการต่าง ๆ บนงานนำเสนอที่ถอดรหัสแล้ว.
} finally {
    presentation.dispose();
}
```

## **เปิดงานนำเสนอขนาดใหญ่**

Aspose.Slides มีตัวเลือก—โดยเฉพาะเมธอด [getBlobManagementOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) ในคลาส [LoadOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/)—เพื่อช่วยคุณโหลดงานนำเสนอขนาดใหญ่

โค้ด JavaScript ด้านล่างแสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// เลือกพฤติกรรม KeepLocked — ไฟล์งานนำเสนอจะยังคงถูกล็อกตลอดอายุของ
// อินสแตนซ์ Presentation, แต่ไม่จำเป็นต้องโหลดเข้าสู่หน่วยความจำหรือคัดลอกไปยังไฟล์ชั่วคราว.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // งานนำเสนอขนาดใหญ่ได้ถูกโหลดแล้วและสามารถใช้ได้ ขณะที่การใช้หน่วยความจือน้อย.
    
    // ทำการเปลี่ยนแปลงงานนำเสนอ.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // บันทึกงานนำเสนอไปยังไฟล์อื่น การใช้หน่วยความจำยังคงต่ำในระหว่างการดำเนินการนี้.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // อย่าทำเช่นนี้! จะเกิดข้อยกเว้น I/O เนื่องจากไฟล์ถูกล็อกจนกว่าอ็อบเจ็กต์ Presentation จะถูกทำลาย.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// สามารถทำได้ที่นี่ ฟイルต้นทางไม่ถูกล็อกโดยอ็อบเจ็กต์ Presentation อีกต่อไป.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
เพื่อแก้ไขข้อจำกัดบางประการเมื่อทำงานกับสตรีม Aspose.Slides อาจคัดลอกเนื้อหาของสตรีม การโหลดงานนำเสนอขนาดใหญ่จากสตรีมจะทำให้ต้องคัดลอกงานนำเสนอและอาจทำให้การโหลดช้าลง ดังนั้นเมื่อคุณต้องการโหลดงานนำเสนอขนาดใหญ่ เราแนะนำอย่างยิ่งให้ใช้เส้นทางไฟล์ของงานนำเสนอแทนการใช้สตรีม

เมื่อสร้างงานนำเสนอที่มีวัตถุขนาดใหญ่ (วิดีโอ, เสียง, รูปภาพความละเอียดสูง ฯลฯ) คุณสามารถใช้ [BLOB management](/slides/th/nodejs-java/manage-blob/) เพื่อลดการใช้หน่วยความจำ
{{%/alert %}}

## **ควบคุมแหล่งข้อมูลภายนอก**

Aspose.Slides มีอินเทอร์เฟซ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iresourceloadingcallback/) ที่ให้คุณจัดการแหล่งข้อมูลภายนอก โค้ด JavaScript ด้านล่างแสดงวิธีการใช้อินเทอร์เฟซ `IResourceLoadingCallback` :

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // โหลดภาพทดแทน.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // ตั้งค่า URL ทดแทน.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // ข้ามภาพอื่นทั้งหมด.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **โหลดงานนำเสนอโดยไม่มีอ็อบเจ็กต์ไบนารีที่ฝังอยู่**

PowerPoint งานนำเสนออาจมีอ็อบเจ็กต์ไบนารีที่ฝังอยู่ประเภทต่อไปนี้:

- โครงการ VBA (เข้าถึงได้ผ่าน [Presentation.getVbaProject](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getVbaProject));
- ข้อมูลที่ฝังอยู่ของวัตถุ OLE (เข้าถึงได้ผ่าน [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- ข้อมูลไบนารีของคอนโทรล ActiveX (เข้าถึงได้ผ่าน [Control.getActiveXControlBinary](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

โดยใช้เมธอด [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) คุณสามารถโหลดงานนำเสนอโดยไม่มีอ็อบเจ็กต์ไบนารีที่ฝังอยู่ใด ๆ

เมธอดนี้มีประโยชน์สำหรับการลบเนื้อหาไบนารีที่อาจเป็นอันตราย ตัวอย่างโค้ด JavaScript ด้านล่างแสดงวิธีโหลดงานนำเสนอโดยไม่มีเนื้อหาไบนารีที่ฝังอยู่ใด ๆ:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // ดำเนินการต่าง ๆ บนงานนำเสนอ.
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะรู้ว่าไฟล์เสียหายและไม่สามารถเปิดได้อย่างไร?**

คุณจะได้รับข้อยกเว้นการตรวจสอบการแยกวิเคราะห์/รูปแบบระหว่างการโหลด ข้อผิดพลาดเหล่านี้มักระบุว่าโครงสร้าง ZIP ไม่ถูกต้องหรือบันทึก PowerPoint ผิดพลาด

**จะเกิดอะไรขึ้นถ้าฟอนต์ที่ต้องการหายไปขณะเปิด?**

ไฟล์จะเปิดได้ แต่ภายหลังการ [rendering/export](/slides/th/nodejs-java/convert-presentation/) อาจแทนที่ฟอนต์โดยอัตโนมัติ ให้ [กำหนดการแทนที่ฟอนต์](/slides/th/nodejs-java/font-substitution/) หรือ [เพิ่มฟอนต์ที่จำเป็น](/slides/th/nodejs-java/custom-font/) ในสภาพแวดล้อมการทำงาน

**แล้วสื่อที่ฝังอยู่ (วิดีโอ/เสียง) จะเป็นอย่างไรเมื่อเปิด?**

สื่อเหล่านั้นจะพร้อมใช้งานเป็นทรัพยากรของงานนำเสนอ หากสื่อถูกอ้างอิงผ่านเส้นทางภายนอก ให้ตรวจสอบว่าเส้นทางนั้นเข้าถึงได้ในสภาพแวดล้อมของคุณ มิฉะนั้นการ [rendering/export](/slides/th/nodejs-java/convert-presentation/) อาจละเว้นสื่อเหล่านั้น