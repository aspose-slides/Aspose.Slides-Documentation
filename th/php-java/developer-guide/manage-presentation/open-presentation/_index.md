---
title: เปิดไฟล์นำเสนอใน PHP
linktitle: เปิดไฟล์นำเสนอ
type: docs
weight: 20
url: /th/php-java/open-presentation/
keywords:
- เปิด PowerPoint
- เปิดไฟล์นำเสนอ
- เปิด PPTX
- เปิด PPT
- เปิด ODP
- โหลดไฟล์นำเสนอ
- โหลด PPTX
- โหลด PPT
- โหลด ODP
- ไฟล์นำเสนอที่ป้องกัน
- ไฟล์นำเสนอขนาดใหญ่
- ทรัพยากรภายนอก
- ออบเจ็กต์ไบนารี
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีเปิดไฟล์นำเสนอ PowerPoint และ OpenDocument ใน PHP, ระบุรหัสผ่านการเปิด, ควบคุมการโหลดทรัพยากร, และลดการใช้หน่วยความจำด้วย Aspose.Slides for PHP via Java."
---
## **บทนำ**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/th/php-java/) สามารถโหลดไฟล์นำเสนอ PowerPoint และ OpenDocument จากไฟล์และสตรีมได้ หลังจากโหลดไฟล์นำเสนอแล้ว คุณสามารถตรวจสอบโครงสร้าง แก้ไขสไลด์ จัดการทรัพยากร และบันทึกในรูปแบบเดิมหรือรูปแบบอื่นที่สนับสนุนได้

พฤติกรรมการโหลดสามารถปรับแต่งได้ผ่านคลาส [LoadOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/) ตัวอย่างเช่น คุณสามารถระบุรหัสผ่านเปิดไฟล์ เก็บออบเจ็กต์ไบนารีขนาดใหญ่ให้อยู่ไกลจากหน่วยความจำ Heap ของ Java ควบคุมทรัพยากรภายนอก หรือละเว้นข้อมูลไบนารีที่ฝังอยู่

## **เปิดไฟล์นำเสนอ**

หลังจากโหลดไฟล์หรือสตรีมแล้ว คุณสามารถ [กำหนดรูปแบบไฟล์นำเสนอเดิม](/slides/th/php-java/detect-presentation-source-format/) เพื่อเลือกวิธีที่แอปพลิเคชันของคุณจะประมวลผล

เพื่อเปิดไฟล์นำเสนอที่มีอยู่ ให้ส่งพาธไฟล์ไปยังตัวสร้าง [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) หลังจากใช้งานเสร็จ ควรทำการกำจัด (dispose) ไฟล์นำเสนอเพื่อให้ตัวจัดการไฟล์ ข้อมูลชั่วคราว และทรัพยากรอื่น ๆ ถูกปล่อยออกอย่างรวดเร็ว

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

## **เปิดไฟล์นำเสนอที่มีการป้องกันด้วยรหัสผ่าน**

รหัสผ่านเปิดไฟล์ทำให้เนื้อหาไฟล์นำเสนอถูกเข้ารหัส เพื่อโหลดไฟล์นำเสนอเต็มรูปแบบ ให้ส่งรหัสผ่านที่ถูกต้องไปยัง [LoadOptions::setPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setPassword) แล้วให้ตัวเลือกเหล่านั้นกับตัวสร้าง [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) การโหลดจะล้มเหลวเมื่อรหัสผ่านหายหรือไม่ถูกต้อง

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

สำหรับการตรวจจับรหัสผ่าน การตรวจสอบความถูกต้อง และกระบวนการเข้ารหัส โปรดดูที่ [Password-Protect Presentations](/slides/th/php-java/password-protected-presentation/) หากไฟล์นำเสนอที่เข้ารหัสถูกบันทึกโดยเจตนาพร้อมกับคุณสมบัติเอกสารสาธารณะ คุณสมบัติเหล่านั้นสามารถอ่านได้โดยไม่ต้องใช้รหัสผ่าน; ดูที่ [Manage Presentation Properties](/slides/th/php-java/presentation-properties/)

## **เปิดไฟล์นำเสนอขนาดใหญ่**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) คืนค่าตัวเลือกที่ควบคุมวิธีที่ Aspose.Slides จัดการกับออบเจ็กต์ไบนารีขนาดใหญ่ เช่น ภาพ เสียง และวิดีโอ คุณสามารถล็อกไฟล์ต้นทาง ให้อนุญาตไฟล์ชั่วคราว และจำกัดปริมาณข้อมูล BLOB ที่เก็บไว้ในหน่วยความจำ

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
ด้วย [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) ไฟล์ต้นทางจะถูกล็อกจนกว่าตัวอย่างไฟล์นำเสนอจะถูกกำจัด อย่าเคลื่อนย้าย เขียนทับ หรือ ลบไฟล์ต้นทางขณะที่อินสแตนซ์นั้นยังอยู่

Aspose.Slides อาจคัดลอกเนื้อหาของอินพุตสตรีมขณะโหลด สำหรับไฟล์นำเสนอขนาดใหญ่ ดังนั้นการใช้พาธไฟล์โดยทั่วไปจะมีประสิทธิภาพมากกว่าสตรีม ดูที่ [Manage BLOBs](/slides/th/php-java/manage-blob/) เพื่อดูตัวเลือกการจัดเก็บและการจัดการหน่วยความจำเพิ่มเติม
{{% /alert %}}

## **ควบคุมทรัพยากรภายนอก**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) ยอมรับการทำงานของอินเตอร์เฟส Java [IResourceLoadingCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iresourceloadingcallback/) ผ่าน PHP/Java Bridge คอลแบ็คนี้สามารถให้ข้อมูลทดแทน เปลี่ยนเส้นทางทรัพยากร ใช้โหลดเดฟอลต์ หรือข้ามทรัพยากรได้ ประโยชน์เมื่อไฟล์นำเสนอมีภาพภายนอกที่ต้อง resolve ตามกฎความปลอดภัยหรือกฎการจัดเก็บข้อมูลของแอปพลิเคชัน

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

## **โหลดไฟล์นำเสนอโดยไม่รวมออบเจ็กต์ไบนารีฝัง**

ไฟล์นำเสนออาจมีข้อมูลไบนารีฝังที่แอปพลิเคชันไม่จำเป็นต้องใช้หรือไม่ต้องการเก็บ ตัวอย่างเช่น:

- โครงการ VBA, สามารถเข้าถึงได้ผ่าน [Presentation::getVbaProject](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getVbaProject);
- ข้อมูล OLE ฝัง, สามารถเข้าถึงได้ผ่าน [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- ข้อมูลคอนโทรล ActiveX, สามารถเข้าถึงได้ผ่าน [Control::getActiveXControlBinary](https://reference.aspose.com/slides/th/php-java/aspose.slides/control/#getActiveXControlBinary).

ตั้งค่า [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) เป็น `true` เพื่อเอาข้อมูลไบนารีนี้ออกระหว่างการโหลด บันทึกไฟล์นำเสนอที่โหลดแล้วเพื่อให้ผลลัพธ์ที่ทำความสะอาดคงอยู่

ตัวเลือกนี้ช่วยลดความเสี่ยงจากข้อมูลฝังที่ไม่ต้องการ แต่ไม่ได้เป็นระบบตรวจจับมัลแวร์หรือการทำความสะอาดเนื้อหาอย่างสมบูรณ์

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

**ฉันจะรู้ได้อย่างไรว่าไฟล์เสียและไม่สามารถเปิดได้?**

Aspose.Slides จะโยนข้อยกเว้นการพาร์สหรือรูปแบบระหว่างการโหลด จัดการข้อผิดพลาดนี้แยกจากข้อผิดพลาดรหัสผ่านไม่ถูกต้อง เพื่อให้แอปพลิเคชันสามารถรายงานสาเหตุได้อย่างแม่นยำ

**จะเกิดอะไรขึ้นหากฟอนต์ที่จำเป็นไม่มีอยู่?**

ไฟล์นำเสนอยังสามารถโหลดได้ แต่การเรนเดอร์และการส่งออกอาจใช้ฟอนต์ทดแทน คุณสามารถ [กำหนดค่าการทดแทนฟอนต์](/slides/th/php-java/font-substitution/) หรือ [จัดหา ฟอนต์กำหนดเอง](/slides/th/php-java/custom-font/) เพื่อให้ผลลัพธ์คาดเดาได้มากขึ้น

**การโหลดไฟล์นำเสนอจะโหลดสื่อที่ฝังอยู่ด้วยหรือไม่?**

เสียงและวิดีโอที่ฝังอยู่จะพร้อมใช้งานผ่านโมเดลออบเจ็กต์ของไฟล์นำเสนอ ทรัพยากรภายนอกจะถูก resolve ตามพฤติกรรมการโหลดทรัพยากรที่กำหนดไว้และอาจไม่พร้อมใช้งานหากไม่สามารถเข้าถึงตำแหน่งของมันได้