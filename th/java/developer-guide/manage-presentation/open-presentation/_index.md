---
title: เปิดงานนำเสนอใน Java
linktitle: เปิดงานนำเสนอ
type: docs
weight: 20
url: /th/java/open-presentation/
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
- วัตถุไบนารี
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเปิดงานนำเสนอ PowerPoint และ OpenDocument ใน Java, จัดหารหัสผ่านการเปิด, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides for Java."
---
## **บทนำ**

[Aspose.Slides for Java](https://products.aspose.com/slides/th/java/) สามารถโหลดงานนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกในรูปแบบเดิมหรือรูปแบบที่สนับสนุนอื่นได้

พฤติกรรมการโหลดสามารถปรับแต่งได้ผ่านคลาส [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถระบุรหัสผ่านสำหรับการเปิด เก็บอ็อบเจ็กต์ไบนารี่ขนาดใหญ่แยกออกจากหน่วยความจำ Java heap ควบคุมทรัพยากรภายนอก หรือละเว้นข้อมูลไบนารีที่ฝังอยู่

## **เปิดงานนำเสนอ**

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้ส่งพาธไฟล์ไปยังคอนสตรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) แล้วทำการ Dispose งานนำเสนอหลังการใช้เพื่อให้แฮนด์เดลไฟล์ ข้อมูลชั่วคราว และทรัพยากรอื่น ๆ ถูกปล่อยออกโดยเร็ว

ตัวอย่าง Java ด้านล่างแสดงวิธีเปิดงานนำเสนอและรับจำนวนสไลด์:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **เปิดงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน**

รหัสผ่านที่ใช้ในการเปิดจะเข้ารหัสเนื้อหาของงานนำเสนอ เพื่อโหลดงานนำเสนอเต็มรูปแบบ ให้ส่งรหัสผ่านที่ถูกต้องไปยัง [LoadOptions.setPassword](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) แล้วให้ตัวเลือกเหล่านั้นแก่คอนสตรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) การโหลดจะล้มเหลือเมื่อรหัสผ่านไม่มีหรือไม่ถูกต้อง

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และกระบวนการเข้ารหัส โปรดดู [Password-Protect Presentations](/slides/th/java/password-protected-presentation/) หากงานนำเสนอที่เข้ารหัสถูกบันทึกโดยเจตนาพร้อมคุณสมบัติเอกสารสาธารณะ คุณสมบัติเหล่านั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดู [Manage Presentation Properties](/slides/th/java/presentation-properties/)

## **เปิดงานนำเสนอขนาดใหญ่**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) คืนค่าตัวเลือกที่ควบคุมวิธีที่ Aspose.Slides จัดการกับ Binary Large Object เช่น รูปภาพ, เสียง, และวิดีโอ คุณสามารถเก็บไฟล์ต้นทางให้ล็อกไว้ อนุญาตไฟล์ชั่วคราว และจำกัดปริมาณข้อมูล BLOB ที่เก็บในหน่วยความจำ

โค้ด Java ด้านล่างแสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
ด้วย [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) ไฟล์ต้นทางจะคงอยู่ในสถานะล็อกจนกว่าตัวอย่างงานนำเสนอจะถูก Dispose อย่าย้าย เขียนทับ หรือทำลายไฟล์ต้นทางขณะที่ตัวอย่างนั้นยังมีชีวิตอยู่

Aspose.Slides อาจคัดลอกเนื้อหาของสตรีมอินพุตขณะทำการโหลด สำหรับงานนำเสนอขนาดใหญ่ การใช้พาธไฟล์จึงมักจะมีประสิทธิภาพมากกว่าสตรีม ดูที่ [Manage BLOBs](/slides/th/java/manage-blob/) สำหรับตัวเลือกการจัดเก็บและการจัดการหน่วยความจำเพิ่มเติม
{{% /alert %}}

## **ควบคุมทรัพยากรภายนอก**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) ยอมรับการนำไปใช้งานของ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iresourceloadingcallback/) คอลแบ็กสามารถจัดหาข้อมูลทดแทน, เปลี่ยนเส้นทางทรัพยากร, ใช้ตัวโหลดเริ่มต้น, หรือข้ามทรัพยากรได้ สิ่งนี้มีประโยชน์เมื่องานนำเสนอประกอบด้วยรูปภาพภายนอกที่ต้องถูกแก้ไขตามกฎความปลอดภัยหรือการจัดเก็บของแอปพลิเคชัน

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **โหลดงานนำเสนอโดยไม่รวมอ็อบเจ็กต์ไบนารีฝังอยู่**

งานนำเสนออาจมีข้อมูลไบนารีฝังอยู่ที่แอปพลิเคชันไม่ต้องการหรือไม่ต้องการเก็บ ตัวอย่างได้แก่:

- โครงการ VBA ที่สามารถเข้าถึงได้ผ่าน [IPresentation.getVbaProject](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentation/#getVbaProject--);
- ข้อมูล OLE ฝังอยู่ที่สามารถเข้าถึงได้ผ่าน [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- ข้อมูลควบคุม ActiveX ที่สามารถเข้าถึงได้ผ่าน [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/th/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

ตั้งค่า [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) เป็น `true` เพื่อกำจัดข้อมูลไบนารีนี้ขณะโหลด บันทึกงานนำเสนอที่โหลดแล้วเพื่อคงผลลัพธ์ที่ทำความสะอาดไว้

ตัวเลือกนี้ลดความเสี่ยงต่อข้อมูลฝังที่ไม่ต้องการ แต่ไม่ใช่ระบบตรวจจับมัลแวร์หรือการทำความสะอาดเนื้อหาแบบสมบูรณ์

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะทราบว่าไฟล์เสียหายและไม่สามารถเปิดได้อย่างไร?**

Aspose.Slides จะโยนข้อยกเว้นการพาร์สหรือรูปแบบระหว่างการโหลด ให้จัดการความล้มเหลือนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้อง เพื่อให้แอปพลิเคชันสามารถรายงานสาเหตุได้อย่างแม่นยำ

**ถ้าตัวอักษรที่จำเป็นหายไปจะเกิดอะไรขึ้น?**

งานนำเสนอยังสามารถโหลดได้ แต่การเรนเดอร์และการส่งออกอาจแทนที่ตัวอักษรได้ คุณสามารถ [configure font substitution](/slides/th/java/font-substitution/) หรือ [provide custom fonts](/slides/th/java/custom-font/) เพื่อทำให้ผลลัพธ์คาดเดาได้มากขึ้น

**การโหลดงานนำเสนอจะโหลดสื่อที่ฝังอยู่ด้วยหรือไม่?**

เสียงและวิดีโอที่ฝังอยู่จะพร้อมใช้งานผ่านโมเดลอ็อบเจ็กต์ของงานนำเสนอ ทรัพยากรภายนอกจะถูกแก้ไขตามพฤติกรรมการโหลดทรัพยากรที่กำหนดค่าไว้และอาจไม่พร้อมใช้งานหากไม่สามารถเข้าถึงตำแหน่งของมันได้