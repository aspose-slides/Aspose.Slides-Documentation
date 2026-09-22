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
- วัตถุไบนารี
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเปิดงานนำเสนอ PowerPoint และ OpenDocument บน Android, ระบุรหัสผ่านการเปิด, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **บทนำ**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/th/androidjava/) สามารถโหลดงานนำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกในรูปแบบเดิมหรือรูปแบบที่รองรับอื่นได้

พฤติกรรมการโหลดสามารถปรับแต่งได้ผ่านคลาส [LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถระบุรหัสผ่านในการเปิด, เก็บวัตถุไบนารีขนาดใหญ่นอกหน่วยความจำ heap ของ Java, ควบคุมทรัพยากรภายนอก, หรือละเว้นข้อมูลไบนารีที่ฝังอยู่

## **เปิดงานนำเสนอ**

หลังจากโหลดไฟล์หรือสตรีม คุณสามารถ [determine its original presentation format](/slides/th/androidjava/detect-presentation-source-format/) เพื่อเลือกวิธีการประมวลผลของแอปพลิเคชันของคุณ

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้ส่งพาธไฟล์ไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วทำการกำจัด (dispose) งานนำเสนอหลังการใช้งาน เพื่อให้ตัวจัดการไฟล์ ข้อมูลชั่วคราว และทรัพยากรอื่น ๆ ถูกปล่อยออกอย่างเร็ว

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

## **เปิดงานนำเสนอที่ป้องกันด้วยรหัสผ่าน**

รหัสผ่านการเปิดทำให้เนื้อหางานนำเสนอถูกเข้ารหัส เพื่อโหลดงานนำเสนอทั้งหมด ให้ส่งรหัสผ่านที่ถูกต้องไปยังเมธอด [LoadOptions.setPassword](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) และส่งตัวเลือกเหล่านั้นไปยังคอนสตรัคเตอร์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) การโหลดจะล้มเหลือเมื่อรหัสผ่านหายหรือไม่ถูกต้อง

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

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และกระบวนการเข้ารหัส ดูที่ [Password-Protect Presentations](/slides/th/androidjava/password-protected-presentation/) หากงานนำเสนอที่เข้ารหัสถูกบันทึกโดยตั้งค่าคุณสมบัติเอกสารสาธารณะ คุณสมบัติเหล่านั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดูที่ [Manage Presentation Properties](/slides/th/androidjava/presentation-properties/)

## **เปิดงานนำเสนอขนาดใหญ่**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) คืนค่าตัวเลือกที่ควบคุมวิธีที่ Aspose.Slides จัดการวัตถุไบนารีขนาดใหญ่ เช่น รูปภาพ, เสียง, และวิดีโอ คุณสามารถล็อคไฟล์ต้นฉบับ, อนุญาตไฟล์ชั่วคราว, และจำกัดจำนวนข้อมูล BLOB ที่เก็บในหน่วยความจำ

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
ด้วย [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked) ไฟล์ต้นทางจะถูกล็อคจนกว่าจะทำการกำจัดอินสแตนซ์ของงานนำเสนอ อย่าย้าย, เขียนทับ, หรือ ลบไฟล์ต้นทางในขณะที่อินสแตนซ์นั้นยังคงมีอยู่

Aspose.Slides อาจคัดลอกเนื้อหาของสตรีมอินพุตขณะโหลด สำหรับงานนำเสนอขนาดใหญ่ การใช้พาธไฟล์จึงมักมีประสิทธิภาพดีกว่าสตรีม ดูที่ [Manage BLOBs](/slides/th/androidjava/manage-blob/) สำหรับตัวเลือกเพิ่มเติมในการจัดเก็บและจัดการหน่วยความจำ
{{% /alert %}}

## **ควบคุมทรัพยากรภายนอก**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) ยอมรับการนำเข้า (implementation) ของ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iresourceloadingcallback/). คอลแบ็กสามารถให้ข้อมูลทดแทน, เปลี่ยนเส้นทางทรัพยากร, ใช้ตัวโหลดค่าเริ่มต้น, หรือข้ามทรัพยากรได้ ซึ่งมีประโยชน์เมื่องานนำเสนอมีภาพภายนอกที่ต้องแก้ไขตามกฎความปลอดภัยหรือการจัดเก็บเฉพาะแอปพลิเคชัน

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

## **โหลดงานนำเสนอโดยไม่มีวัตถุไบนารีฝังอยู่**

งานนำเสนออาจมีข้อมูลไบนารีฝังอยู่ที่แอปพลิเคชันไม่จำเป็นหรือไม่ต้องการเก็บ ตัวอย่างได้แก่:

- โปรเจ็กต์ VBA, สามารถเข้าถึงได้ผ่าน [IPresentation.getVbaProject](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- ข้อมูล OLE ฝังอยู่, สามารถเข้าถึงได้ผ่าน [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- ข้อมูลควบคุม ActiveX, สามารถเข้าถึงได้ผ่าน [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

ตั้งค่า [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) เป็น `true` เพื่อลบข้อมูลไบนารีนี้ระหว่างการโหลด บันทึกงานนำเสนอที่โหลดแล้วเพื่อเก็บผลลัพธ์ที่ทำความสะอาดไว้

ตัวเลือกนี้ลดความเสี่ยงจากข้อมูลฝังที่ไม่ต้องการ แต่ไม่ใช่ระบบตรวจจับมัลแวร์หรือทำความสะอาดเนื้อหาอย่างสมบูรณ์

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

**ฉันจะทราบได้อย่างไรว่าไฟล์เสียหายและเปิดไม่ได้?**

Aspose.Slides จะโยนข้อยกเว้นเกี่ยวกับการพาร์สหรือรูปแบบในระหว่างการโหลด ให้จัดการความล้มเหลวนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้อง เพื่อให้แอปพลิเคชันสามารถรายงานสาเหตุได้อย่างถูกต้อง

**เกิดอะไรขึ้นหากฟอนต์ที่ต้องการหายไป?**

งานนำเสนอยังสามารถโหลดได้ แต่การเรนเดอร์และการส่งออกอาจแทนที่ฟอนต์ได้ คุณสามารถ [configure font substitution](/slides/th/androidjava/font-substitution/) หรือ [provide custom fonts](/slides/th/androidjava/custom-font/) เพื่อทำให้ผลลัพธ์คาดเดาได้มากขึ้น

**การโหลดงานนำเสนอจะโหลดสื่อที่ฝังอยู่ด้วยหรือไม่?**

เสียงและวิดีโอที่ฝังอยู่จะพร้อมใช้งานผ่านโมเดลอ็อบเจ็กต์ของงานนำเสนอ ทรัพยากรภายนอกจะถูกแก้ไขตามพฤติกรรมการโหลดทรัพยากรที่กำหนดและอาจไม่สามารถใช้ได้หากไม่สามารถเข้าถึงตำแหน่งของมัน