---
title: เปิดงานนำเสนอบน Android
linktitle: เปิดงานนำเสนอ
type: docs
weight: 20
url: /th/androidjava/open-presentation/
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
- งานนำเสนอที่ป้องกันด้วยรหัสผ่าน
- งานนำเสนอขนาดใหญ่
- ทรัพยากรภายนอก
- วัตถุไบนารี
- Android
- Java
- Aspose.Slides
description: "เปิดงานนำเสนอ PowerPoint (.pptx, .ppt) และ OpenDocument (.odp) อย่างง่ายดายด้วย Aspose.Slides สำหรับ Android ผ่าน Java—รวดเร็ว เชื่อถือได้ และมีคุณสมบัติครบถ้วน."
---
## **บทนำ**

นอกเหนือจากการสร้างงานนำเสนอ PowerPoint ตั้งแต่เริ่มต้น Aspose.Slides ยังอนุญาตให้คุณเปิดงานนำเสนอที่มีอยู่แล้ว หลังจากโหลดงานนำเสนอ คุณสามารถดึงข้อมูลเกี่ยวกับงานนำเสนอ แก้ไขเนื้อหาสไลด์ เพิ่มสไลด์ใหม่ ลบสไลด์ที่มีอยู่ และทำสิ่งอื่น ๆ ได้อีกมากมาย

## **เปิดงานนำเสนอ**

ในการเปิดงานนำเสนอที่มีอยู่ ให้สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วส่งพาธไฟล์ไปยังคอนสตรัคเตอร์ของมัน

ตัวอย่าง Java ต่อไปนี้แสดงวิธีเปิดงานนำเสนอและดึงจำนวนสไลด์:

```java
// สร้างอินสแตนซ์ของคลาส Presentation และส่งพาธไฟล์ไปยังคอนสตรัคเตอร์ของมัน.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // พิมพ์จำนวนสไลด์ทั้งหมดในงานนำเสนอ.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **เปิดงานนำเสนอที่ป้องกันด้วยรหัสผ่าน**

เมื่อคุณต้องการเปิดงานนำเสนอที่ป้องกันด้วยรหัสผ่าน ให้ส่งรหัสผ่านผ่านเมธอด [setPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ของคลาส [LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/) เพื่อถอดรหัสและโหลด งานนำเสนอ ตัวอย่างโค้ด Java ด้านล่างแสดงการทำงานนี้:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // ดำเนินการต่าง ๆ กับงานนำเสนอที่ถอดรหัสแล้ว.
} finally {
    presentation.dispose();
}
```

## **เปิดงานนำเสนอขนาดใหญ่**

Aspose.Slides มีตัวเลือก—โดยเฉพาะเมธอด [getBlobManagementOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) ในคลาส [LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/)—เพื่อช่วยคุณโหลดงานนำเสนอขนาดใหญ่

โค้ด Java ต่อไปนี้สาธิตการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// เลือกพฤติกรรม KeepLocked—ไฟล์งานนำเสนอจะถูกล็อกตลอดอายุการใช้งานของ
// อินสแตนซ์ Presentation, แต่ไม่จำเป็นต้องโหลดเข้าสู่หน่วยความจำหรือคัดลอกไปยังไฟล์ชั่วคราว.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // งานนำเสนอขนาดใหญ่ถูกโหลดแล้วและสามารถใช้งานได้ ในขณะที่การใช้งานหน่วยความจำนั้นยังคงต่ำ.

    // ทำการแก้ไขงานนำเสนอ.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // บันทึกงานนำเสนอไปยังไฟล์อื่น การใช้หน่วยความจำยังคงต่ำระหว่างดำเนินการนี้.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // ห้ามทำเช่นนี้! จะเกิดข้อยกเว้น I/O เนื่องจากไฟล์ยังคงถูกล็อกจนกว่าออบเจกต์ Presentation จะถูกทำลาย.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// สามารถทำได้ที่นี่ ไฟล์ต้นฉบับไม่ได้ถูกล็อกโดยออบเจกต์ Presentation อีกต่อไป.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
เพื่อหลีกเลี่ยงข้อจำกัดบางประการเมื่อทำงานกับสตรีม Aspose.Slides อาจคัดลอกเนื้อหาของสตรีม การโหลดงานนำเสนอขนาดใหญ่จากสตรีมจะทำให้มีการคัดลอกงานนำเสนอและทำให้การโหลดช้าลง ดังนั้นเมื่อคุณต้องการโหลดงานนำเสนอขนาดใหญ่ เราขอแนะนำอย่างยิ่งให้ใช้พาธไฟล์ของงานนำเสนอแทนการใช้สตรีม

เมื่อสร้างงานนำเสนอที่มีวัตถุขนาดใหญ่ (วิดีโอ, เสียง, ภาพความละเอียดสูง ฯลฯ) คุณสามารถใช้ [การจัดการ BLOB](/slides/th/androidjava/manage-blob/) เพื่อลดการใช้หน่วยความจำ
{{%/alert %}}

## **ควบคุมทรัพยากรภายนอก**

Aspose.Slides มีอินเทอร์เฟซ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iresourceloadingcallback/) ที่ให้คุณจัดการทรัพยากรภายนอก ตัวอย่างโค้ด Java ด้านล่างแสดงวิธีใช้อินเทอร์เฟซ `IResourceLoadingCallback`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // โหลดรูปภาพสำรอง.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // ใช้วิธีใดก็ได้เพื่อรับไบต์
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // ตั้งค่า URL สำรอง.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // ข้ามรูปภาพอื่น ๆ ทั้งหมด.
        return ResourceLoadingAction.Skip;
    }
}
```

## **โหลดงานนำเสนอโดยไม่มีวัตถุไบนารีที่ฝังอยู่**

งานนำเสนอ PowerPoint อาจประกอบด้วยวัตถุไบนารีที่ฝังอยู่ประเภทต่าง ๆ ดังนี้

- โครงการ VBA (เข้าถึงได้ผ่าน [IPresentation.getVbaProject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- ข้อมูลที่ฝังอยู่ของวัตถุ OLE (เข้าถึงได้ผ่าน [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ข้อมูลไบนารีของคอนโทรล ActiveX (เข้าถึงได้ผ่าน [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

โดยใช้เมธอด [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) คุณสามารถโหลดงานนำเสนอโดยไม่มีวัตถุไบนารีที่ฝังอยู่ใด ๆ

เมธอดนี้มีประโยชน์สำหรับการลบเนื้อหาไบนารีที่อาจเป็นอันตราย ตัวอย่างโค้ด Java ด้านล่างแสดงวิธีโหลดงานนำเสนอโดยไม่มีเนื้อหาไบนารีใด ๆ:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // ดำเนินการต่าง ๆ กับงานนำเสนอ.
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะรู้ได้อย่างไรว่าไฟล์เสียหายและไม่สามารถเปิดได้?**

คุณจะได้รับข้อยกเว้นเกี่ยวกับการพาร์สหรือการตรวจสอบรูปแบบระหว่างการโหลด ข้อผิดพลาดเหล่านี้มักระบุโครงสร้าง ZIP ที่ไม่ถูกต้องหรือบันทึก PowerPoint ที่เสียหาย

**เกิดอะไรขึ้นหากฟอนต์ที่จำเป็นหายไปขณะเปิด?**

ไฟล์จะเปิดได้ แต่ภายหลังการ [เรนเดอร์/ส่งออก](/slides/th/androidjava/convert-presentation/) อาจแทนที่ฟอนต์ด้วยฟอนต์อื่น คุณสามารถ [กำหนดค่าการทดแทนฟอนต์](/slides/th/androidjava/font-substitution/) หรือ [เพิ่มฟอนต์ที่จำเป็น](/slides/th/androidjava/custom-font/) ใส่ในสภาพแวดล้อมการทำงาน

**สื่อที่ฝังอยู่ (วิดีโอ/เสียง) จะเป็นอย่างไรเมื่อเปิด?**

สื่อเหล่านั้นจะพร้อมใช้งานเป็นทรัพยากรของงานนำเสนอ หากสื่อถูกอ้างถึงผ่านเส้นทางภายนอก โปรดตรวจสอบให้แน่ใจว่าเส้นทางเหล่านั้นเข้าถึงได้ในสภาพแวดล้อมของคุณ มิฉะนั้นการ [เรนเดอร์/ส่งออก](/slides/th/androidjava/convert-presentation/) อาจละเว้นสื่อเหล่านั้น