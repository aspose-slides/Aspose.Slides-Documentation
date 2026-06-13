---
title: เปิดงานนำเสนอใน Java
linktitle: เปิดงานนำเสนอ
type: docs
weight: 20
url: /th/java/open-presentation/
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
- งานนำเสนอที่ป้องกัน
- งานนำเสนอขนาดใหญ่
- ทรัพยากรภายนอก
- อ็อบเจ็กต์ไบนารี
- Java
- Aspose.Slides
description: "เปิดงานนำเสนอ PowerPoint (.pptx, .ppt) และ OpenDocument (.odp) อย่างง่ายดายด้วย Aspose.Slides สำหรับ Java—เร็ว, เชื่อถือได้, มีคุณสมบัติมือครบครัน."
---
## **บทนำ**

นอกเหนือจากการสร้างงานนำเสนอ PowerPoint ตั้งแต่ต้นแล้ว Aspose.Slides ยังช่วยให้คุณเปิดงานนำเสนอที่มีอยู่ได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถดึงข้อมูลเกี่ยวกับงานนำเสนอ แก้ไขเนื้อหาในสไลด์ เพิ่มสไลด์ใหม่ ลบสไลด์ที่มีอยู่ และอื่น ๆ อีกมากมาย

## **เปิดงานนำเสนอ**

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และส่งพาธของไฟล์ไปยังคอนสตรัคเตอร์ของมัน

ตัวอย่าง Java ด้านล่างแสดงวิธีการเปิดงานนำเสนอและรับจำนวนสไลด์ของมัน:

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

## **เปิดงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน**

เมื่อคุณต้องการเปิดงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน ให้ส่งรหัสผ่านผ่านเมธอด [setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) ของคลาส [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/) เพื่อถอดรหัสและโหลดงานนำเสนอ โค้ด Java ด้านล่างนี้แสดงการทำงานดังกล่าว:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // ดำเนินการต่าง ๆ บนงานนำเสนอที่ถอดรหัสแล้ว.
} finally {
    presentation.dispose();
}
```

## **เปิดงานนำเสนอขนาดใหญ่**

Aspose.Slides มีตัวเลือก—โดยเฉพาะเมธอด [getBlobManagementOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) ในคลาส [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/)—เพื่อช่วยคุณโหลดงานนำเสนอขนาดใหญ่

โค้ด Java ด้านล่างแสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// เลือกพฤติกรรม KeepLocked—ไฟล์งานนำเสนอจะยังคงถูกล็อกตลอดอายุของ
// อินสแตนซ์ Presentation, แต่ไม่จำเป็นต้องโหลดเข้าเมมโมรีหรือคัดลอกเป็นไฟล์ชั่วคราว.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // งานนำเสนอขนาดใหญ่ได้ถูกโหลดและสามารถใช้งานได้ ในขณะที่การใช้หน่วยความจำยังคงต่ำ.

    // แก้ไขงานนำเสนอ.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // บันทึกงานนำเสนอไปยังไฟล์อื่น การใช้หน่วยความจำยังคงต่ำระหว่างการดำเนินการนี้.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // อย่าทำเช่นนี้! จะเกิดข้อยกเว้น I/O เพราะไฟล์ถูกล็อกจนกว่าออบเจ็กต์ Presentation จะถูกทำลาย.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// สามารถทำได้ที่นี่ไฟล์ต้นทางไม่ถูกล็อกโดยออบเจ็กต์ Presentation อีกต่อไป.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}

เพื่อแก้ไขข้อจำกัดบางประการเมื่อทำงานกับสตรีม Aspose.Slides อาจทำสำเนาเนื้อหาของสตรีม การโหลดงานนำเสนอขนาดใหญ่จากสตรีมจะทำให้ต้องคัดลอกงานนำเสนอซึ่งอาจทำให้การโหลดช้าลง ดังนั้นเมื่อคุณต้องการโหลดงานนำเสนอขนาดใหญ่ เราขอแนะนำอย่างยิ่งให้ใช้พาธไฟล์ของงานนำเสนอแทนการใช้สตรีม

เมื่อสร้างงานนำเสนอที่มีวัตถุขนาดใหญ่ (วิดีโอ, เสียง, รูปภาพความละเอียดสูง ฯลฯ) คุณสามารถใช้การจัดการ [BLOB management](/slides/th/java/manage-blob/) เพื่อลดการใช้หน่วยความจำ

{{%/alert %}} 

## **ควบคุมทรัพยากรภายนอก**

Aspose.Slides มีอินเทอร์เฟซ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iresourceloadingcallback/) ที่ช่วยให้คุณจัดการทรัพยากรภายนอก โค้ด Java ด้านล่างแสดงวิธีใช้อินเทอร์เฟซ `IResourceLoadingCallback`:

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
                // โหลดภาพแทน.
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // ตั้งค่า URL แทน.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // ข้ามภาพอื่นทั้งหมด.
        return ResourceLoadingAction.Skip;
    }
}
```

## **โหลดงานนำเสนอโดยไม่มีออบเจ็กต์ไบนารีฝังอยู่**

งานนำเสนอ PowerPoint สามารถมีออบเจ็กต์ไบนารีฝังอยู่ประเภทต่อไปนี้:

- โปรเจกต์ VBA (เข้าถึงได้ผ่าน [IPresentation.getVbaProject](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getVbaProject--));
- ข้อมูลที่ฝังอยู่ของวัตถุ OLE (เข้าถึงได้ผ่าน [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ข้อมูลไบนารีของคอนโทรล ActiveX (เข้าถึงได้ผ่าน [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/th/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

โดยใช้เมธอด [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) คุณสามารถโหลดงานนำเสนอโดยไม่มีออบเจ็กต์ไบนารีฝังอยู่ใด ๆ

เมธอดนี้มีประโยชน์ในการลบเนื้อหาไบนารีที่อาจเป็นอันตราย ตัวอย่าง Java ด้านล่างแสดงวิธีโหลดงานนำเสนอโดยไม่มีเนื้อหาไบนารีฝังอยู่ใด ๆ:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // ดำเนินการต่าง ๆ บนงานนำเสนอ.
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะรู้ได้อย่างไรว่าไฟล์เสียและไม่สามารถเปิดได้?**

คุณจะได้รับข้อยกเว้นการตรวจสอบการแยกวิเคราะห์/รูปแบบในระหว่างการโหลด ข้อผิดพลาดเหล่านี้มักระบุโครงสร้าง ZIP ที่ไม่ถูกต้องหรือบันทึก PowerPoint ที่เสีย

**จะเกิดอะไรขึ้นหากฟอนต์ที่ต้องการหายไปเมื่อเปิด?**

ไฟล์จะเปิดได้ แต่ในขั้นตอนการเรนเดอร์/ส่งออกต่อมาอาจแทนที่ฟอนต์โดยอัตโนมัติ ให้กำหนดการแทนที่ฟอนต์หรือเพิ่มฟอนต์ที่ต้องการเข้าไปในสภาพแวดล้อมการทำงาน

**แล้วสื่อฝังอยู่ (วิดีโอ/เสียง) จะเป็นอย่างไรเมื่อเปิด?**

สื่อเหล่านี้จะกลายเป็นทรัพยากรของงานนำเสนอ หากสื่อถูกอ้างอิงผ่านพาธภายนอก ให้ตรวจสอบว่าพาธเหล่านั้นเข้าถึงได้ในสภาพแวดล้อมของคุณ มิฉะนั้นการเรนเดอร์/ส่งออกอาจละเว้นสื่อเหล่านั้น