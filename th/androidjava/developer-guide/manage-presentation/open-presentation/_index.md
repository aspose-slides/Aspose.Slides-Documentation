---
title: เปิดงานนำเสนอบน Android
linktitle: เปิดงานนำเสนอ
type: docs
weight: 20
url: /th/androidjava/open-presentation/
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
- อ็อบเจ็กต์ไบนารี
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเปิดงานนำเสนอ PowerPoint และ OpenDocument บน Android, ใส่รหัสผ่านเพื่อเปิด, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **บทนำ**

[Aspose.Slides สำหรับ Android ผ่าน Java](https://products.aspose.com/slides/th/androidjava/) สามารถโหลดงานนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้างของมัน แก้ไขสไลด์ จัดการทรัพยากร และบันทึกในรูปแบบเดิมหรือรูปแบบอื่นที่สนับสนุนได้

พฤติกรรมการโหลดสามารถปรับแต่งได้ผ่านคลาส [LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถระบุรหัสผ่านเพื่อเปิดไฟล์ เก็บอ็อบเจ็กต์ไบนารีขนาดใหญ่ให้อยู่นอกหน่วยความจำ heap ของ Java ควบคุมทรัพยากรภายนอก หรือละเว้นข้อมูลไบนารีที่ฝังอยู่

## **เปิดงานนำเสนอ**

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้ส่งพาธไฟล์ไปยังตัวสร้าง [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ปล่อยให้การทำงานของงานนำเสนอเสร็จสิ้นโดยการทำลาย (dispose) เพื่อลดการค้างของตัวจัดการไฟล์ ข้อมูลชั่วคราว และทรัพยากรอื่น ๆ อย่างทันท่วงที

ตัวอย่าง Java ต่อไปนี้แสดงวิธีเปิดงานนำเสนอและรับจำนวนสไลด์:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **เปิดงานนำเสนอที่ป้องกันด้วยรหัสผ่าน**

รหัสผ่านการเปิดทำให้เนื้อหางานนำเสนอดูเป็นรหัสลับ เพื่อโหลดงานนำเสนออย่างเต็มที่ ให้ส่งรหัสผ่านที่ถูกต้องไปยัง [LoadOptions.setPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) แล้วส่งอ็อบเจ็กต์ตัวเลือกไปยังตัวสร้าง [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) การโหลดจะล้มเหลือเมื่อไม่มีรหัสผ่านหรือรหัสผ่านไม่ถูกต้อง

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

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และเวิร์กโฟลว์การเข้ารหัส ให้ดูที่ [Password-Protect Presentations](/slides/th/androidjava/password-protected-presentation/) หากงานนำเสนอที่เข้ารหัสถูกบันทึกโดยเจตนาพร้อมกับคุณสมบัติของเอกสารสาธารณะ คุณสมบัตินั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดูที่ [Manage Presentation Properties](/slides/th/androidjava/presentation-properties/)

## **เปิดงานนำเสนอขนาดใหญ่**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) คืนค่าตัวเลือกที่ควบคุมวิธีที่ Aspose.Slides จัดการอ็อบเจ็กต์ไบนารีขนาดใหญ่ เช่น รูปภาพ, เสียง, และวิดีโอ คุณสามารถเก็บไฟล์ต้นทางไว้ล็อก อนุญาตไฟล์ชั่วคราว และจำกัดจำนวนข้อมูล BLOB ที่เก็บในหน่วยความจำ

โค้ด Java ต่อไปนี้แสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

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

{{% alert color="info" title="หมายเหตุ" %}}
ด้วย [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked) ไฟล์ต้นทางจะยังคงถูกล็อกจนกว่าตัวอย่าง Presentation จะถูกทำลาย อย่าย้าย แทนที่ หรือ 삭제 ไฟล์ต้นทางขณะตัวอย่างนั้นยังมีชีวิตอยู่

Aspose.Slides อาจคัดลอกเนื้อหาจากสตรีมอินพุตขณะกำลังโหลด สำหรับงานนำเสนอขนาดใหญ่ การใช้พาธไฟล์จึงมักมีประสิทธิภาพมากกว่าการใช้สตรีม ดูที่ [Manage BLOBs](/slides/th/androidjava/manage-blob/) สำหรับตัวเลือกการจัดเก็บและการจัดการหน่วยความจำเพิ่มเติม
{{% /alert %}}

## **ควบคุมทรัพยากรภายนอก**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) ยอมรับการนำไปใช้ของ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iresourceloadingcallback/) คอลแบ็คสามารถให้ข้อมูลสำรอง เปลี่ยนเส้นทางทรัพยากร ใช้ตัวโหลดค่าเริ่มต้น หรือข้ามทรัพยากรได้ ซึ่งเป็นประโยชน์เมื่องานนำเสนอมีรูปภาพภายนอกที่ต้องแก้ไขตามกฎความปลอดภัยหรือการจัดเก็บของแอปพลิเคชัน

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

## **โหลดงานนำเสนอโดยไม่มีอ็อบเจ็กต์ไบนารีฝัง**

งานนำเสนออาจมีข้อมูลไบนารีฝังที่แอปพลิเคชันไม่จำเป็นต้องใช้หรือไม่ต้องการเก็บ ตัวอย่างเช่น

- โครงการ VBA ที่เข้าถึงได้ผ่าน [IPresentation.getVbaProject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getVbaProject--)
- ข้อมูล OLE ฝังที่เข้าถึงได้ผ่าน [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--)
- ข้อมูลคอนโทรล ActiveX ที่เข้าถึงได้ผ่าน [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)

ตั้งค่า [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) เป็น `true` เพื่อเอาข้อมูลไบนารีเหล่านี้ออกขณะโหลด บันทึกงานนำเสนอที่โหลดแล้วเพื่อคงผลลัพธ์ที่ทำความสะอาดแล้ว

ตัวเลือกนี้ช่วยลดความเสี่ยงจากข้อมูลฝังอันไม่พึงประสงค์ แต่ไม่ใช่ระบบตรวจจับมัลแวร์หรือทำความสะอาดเนื้อหาอย่างครบถ้วน

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

**ฉันจะรู้ได้อย่างไรว่าไฟล์เสียหายและไม่สามารถเปิดได้?**

Aspose.Slides จะโยนข้อยกเว้นการพาร์สหรือรูปแบบขณะโหลด ให้จัดการความล้มเหลือนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้องเพื่อให้แอปพลิเคชันรายงานสาเหตุได้อย่างแม่นยำ

**จะเกิดอะไรขึ้นถ้าฟอนท์ที่จำเป็นหายไป?**

งานนำเสนอยังคงโหลดได้ แต่การเรนเดอร์และการส่งออกอาจแทนที่ฟอนท์ได้ คุณสามารถ [configure font substitution](/slides/th/androidjava/font-substitution/) หรือ [provide custom fonts](/slides/th/androidjava/custom-font/) เพื่อทำให้ผลลัพธ์คาดเดาได้มากขึ้น

**การโหลดงานนำเสนอจะทำให้สื่อที่ฝังอยู่ก็โหลดด้วยหรือไม่?**

เสียงและวิดีโอที่ฝังจะพร้อมใช้งานผ่านโมเดลอ็อบเจ็กต์ของงานนำเสนอ ทรัพยากรภายนอกจะถูกแก้ไขตามพฤติกรรมการโหลดที่กำหนดค่าและอาจไม่พร้อมใช้งานหากไม่สามารถเข้าถึงตำแหน่งของมันได้