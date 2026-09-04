---
title: เปิดการนำเสนอใน PHP
linktitle: เปิดการนำเสนอ
type: docs
weight: 20
url: /th/php-java/open-presentation/
keywords:
- เปิด PowerPoint
- เปิดการนำเสนอ
- เปิด PPTX
- เปิด PPT
- เปิด ODP
- โหลดการนำเสนอ
- โหลด PPTX
- โหลด PPT
- โหลด ODP
- การนำเสนอที่ได้รับการป้องกัน
- การนำเสนอขนาดใหญ่
- ทรัพยากรภายนอก
- ออบเจกต์ไบนารี
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีเปิดไฟล์นำเสนอ PowerPoint และ OpenDocument ใน PHP, ระบุรหัสผ่านเปิดไฟล์, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **บทนำ**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/th/php-java/) สามารถโหลดไฟล์นำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากที่ไฟล์นำเสนอโหลดแล้ว คุณสามารถตรวจสอบโครงสร้างของมัน แก้ไขสไลด์ จัดการทรัพยากร และบันทึกเป็นรูปแบบเดิมหรือรูปแบบที่รองรับอื่นๆ

พฤติกรรมการโหลดสามารถกำหนดค่าได้ผ่านคลาส [LoadOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถระบุรหัสผ่านเปิดไฟล์ เก็บออบเจ็กต์ไบนารีขนาดใหญ่ให้อยู่ภายนอกหน่วยความจำ heap ของ Java ควบคุมทรัพยากรภายนอก หรือละเว้นข้อมูลไบนารีที่ฝังอยู่

## **เปิดไฟล์นำเสนอ**

เพื่อเปิดไฟล์นำเสนอที่มีอยู่ ให้ส่งพาธไฟล์ไปยังคอนสตรักเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) อย่าลืมทำการ Dispose ไฟล์นำเสนอหลังการใช้งานเพื่อให้การจัดการไฟล์ชั่วคราวและทรัพยากรอื่นๆ ถูกปล่อยอย่างรวดเร็ว

ตัวอย่าง PHP ด้านล่างแสดงวิธีเปิดไฟล์นำเสนอและรับจำนวนสไลด์:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **เปิดไฟล์นำเสนอที่ป้องกันด้วยรหัสผ่าน**

รหัสผ่านเปิดไฟล์ทำให้เนื้อหาไฟล์นำเสนอถูกเข้ารหัส เพื่อโหลดไฟล์นำเสนออย่างเต็มรูปแบบ ให้ส่งรหัสผ่านที่ถูกต้องไปยัง [LoadOptions::setPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setPassword) และให้ตัวเลือกนี้กับคอนสตรักเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) การโหลดจะล้มเหลือหากรหัสผ่านหายไปหรือไม่ถูกต้อง

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

สำหรับการตรวจจับ รหัสผ่าน การตรวจสอบความถูกต้อง และกระบวนการเข้ารหัส โปรดดูที่ [Password-Protect Presentations](/slides/th/php-java/password-protected-presentation/) หากไฟล์นำเสนอที่เข้ารหัสถูกบันทึกโดยเจตนาด้วยคุณสมบัติของเอกสารสาธารณะ คุณสมบัติเหล่านั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดูที่ [Manage Presentation Properties](/slides/th/php-java/presentation-properties/)

## **เปิดไฟล์นำเสนอขนาดใหญ่**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) คืนค่าตัวเลือกที่ควบคุมวิธีที่ Aspose.Slides จัดการออบเจ็กต์ไบนารีขนาดใหญ่ เช่น รูปภาพ เสียง และวิดีโอ คุณสามารถทำให้ไฟล์ต้นทางถูกล็อก อนุญาตไฟล์ชั่วคราว และจำกัดจำนวนข้อมูล BLOB ที่เก็บไว้ในหน่วยความจำ

โค้ด PHP ด้านล่างแสดงการโหลดไฟล์นำเสนอขนาดใหญ่ (เช่น 2 GB):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
ด้วย [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) ไฟล์ต้นทางจะถูกล็อกจนกว่าจะทำการ Dispose อินสแตนซ์ของไฟล์นำเสนอ อย่าย้าย เขียนทับ หรือทำลายไฟล์ต้นทางขณะที่อินสแตนซ์นั้นยังคงอยู่

Aspose.Slides อาจคัดลอกเนื้อหาของสตรีมอินพุตขณะโหลดสำหรับไฟล์นำเสนอขนาดใหญ่ ดังนั้นการใช้พาธไฟล์มักจะมีประสิทธิภาพกว่าสตรีม โปรดดูที่ [Manage BLOBs](/slides/th/php-java/manage-blob/) เพื่อดูตัวเลือกการจัดเก็บและการจัดการหน่วยความจำเพิ่มเติม
{{% /alert %}}

## **ควบคุมทรัพยากรภายนอก**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) รับการทำงานของอินเทอร์เฟซ Java [IResourceLoadingCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iresourceloadingcallback/) ผ่าน PHP/Java Bridge คอลแบ็กสามารถให้ข้อมูลทดแทน เปลี่ยนเส้นทางทรัพยากร ใช้โหลดเดฟอลต์ หรือข้ามทรัพยากรได้ ซึ่งเป็นประโยชน์เมื่อไฟล์นำเสนอมีรูปภาพภายนอกที่ต้องแก้ไขตามกฎความปลอดภัยหรือการจัดเก็บของแอปพลิเคชัน

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **โหลดไฟล์นำเสนอโดยไม่ต้องมีออบเจ็กต์ไบนารีที่ฝังอยู่**

ไฟล์นำเสนออาจมีข้อมูลไบนารีที่ฝังอยู่ซึ่งแอปพลิเคชันไม่ต้องการหรือไม่ต้องการเก็บไว้ ตัวอย่างได้แก่:

- โครงการ VBA ที่เข้าถึงได้ผ่าน [Presentation::getVbaProject](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getVbaProject);
- ข้อมูล OLE ที่ฝังอยู่ที่เข้าถึงได้ผ่าน [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ข้อมูลคอนโทรล ActiveX ที่เข้าถึงได้ผ่าน [Control::getActiveXControlBinary](https://reference.aspose.com/slides/th/php-java/aspose.slides/control/#getActiveXControlBinary).

กำหนด [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) ให้เป็น `true` เพื่อลบข้อมูลไบนารีเหล่านี้ขณะโหลด บันทึกไฟล์นำเสนอที่โหลดแล้วเพื่อให้ผลลัพธ์ที่ผ่านการทำความสะอาดคงอยู่

ตัวเลือกนี้ช่วยลดความเสี่ยงจาก payload ที่ฝังอยู่โดยไม่ต้องการ แต่ไม่ได้เป็นระบบตรวจจับมัลแวร์หรือทำความสะอาดเนื้อหาอย่างสมบูรณ์

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**How can I tell that a file is corrupted and cannot be opened?**  
Aspose.Slides จะโยนข้อยกเว้นการพาร์สหรือรูปแบบระหว่างการโหลด ให้จัดการความล้มเหลือนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้องเพื่อให้แอปพลิเคชันสามารถรายงานสาเหตุได้อย่างแม่นยำ

**What happens if required fonts are missing?**  
ไฟล์นำเสนอยังคงโหลดได้ แต่การเรนเดอร์และการส่งออกอาจใช้ฟอนต์สำรอง คุณสามารถ [configure font substitution](/slides/th/php-java/font-substitution/) หรือ [provide custom fonts](/slides/th/php-java/custom-font/) เพื่อทำให้ผลลัพธ์คาดเดาได้มากขึ้น

**Does loading a presentation also load its embedded media?**  
สื่อเสียงและวิดีโอที่ฝังอยู่จะพร้อมใช้งานผ่านโมเดลอ็อบเจ็กต์ของไฟล์นำเสนอ ส่วนทรัพยากรภายนอกจะถูกแก้ไขตามพฤติกรรมการโหลดทรัพยากรที่กำหนด และอาจไม่สามารถเข้าถึงได้หากตำแหน่งไฟล์ไม่สามารถเข้าถึงได้