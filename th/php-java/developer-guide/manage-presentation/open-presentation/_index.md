---
title: เปิดงานนำเสนอใน PHP
linktitle: เปิดงานนำเสนอ
type: docs
weight: 20
url: /th/php-java/open-presentation/
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
- วัตถุไบนารี
- PHP
- Aspose.Slides
description: "เปิดงานนำเสนอ PowerPoint (.pptx, .ppt) และ OpenDocument (.odp) อย่างง่ายดายด้วย Aspose.Slides สำหรับ PHP ผ่าน Java — เร็ว, เชื่อถือได้, มีคุณสมบัติครบถ้วน."
---
## **คำนำ**

นอกจากการสร้างงานนำเสนอ PowerPoint ตั้งแต่เริ่มต้นแล้ว Aspose.Slides ยังให้คุณเปิดงานนำเสนอที่มีอยู่ได้ หลังจากโหลดงานนำเสนอแล้ว คุณสามารถดึงข้อมูลของมันออกมา แก้ไขเนื้อหาในสไลด์ เพิ่มสไลด์ใหม่ ลบสไลด์ที่มีอยู่ และอื่น ๆ อีกมาก

## **เปิดงานนำเสนอ**

เพื่อเปิดงานนำเสนอที่มีอยู่ ให้สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) แล้วส่งพาธไฟล์ไปยังคอนสตรัคเตอร์ของมัน

ตัวอย่าง PHP ด้านล่างแสดงวิธีเปิดงานนำเสนอและรับจำนวนสไลด์:

```php
// สร้างอินสแตนซ์ของคลาส Presentation และส่งพาธไฟล์ไปยังคอนสตรัคเตอร์ของมัน.
$presentation = new Presentation("Sample.pptx");
try {
    // พิมพ์จำนวนสไลด์ทั้งหมดในงานนำเสนอ.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **เปิดงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน**

เมื่อคุณต้องการเปิดงานนำเสนอที่มีการป้องกันด้วยรหัสผ่าน ให้ส่งรหัสผ่านผ่านเมธอด [setPassword](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setPassword) ของคลาส [LoadOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/) เพื่อทำการถอดรหัสและโหลดงานนั้น ตัวอย่าง PHP ด้านล่างแสดงการทำงานนี้:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // ดำเนินการบนงานนำเสนอที่ถอดรหัสแล้ว.
} finally {
    $presentation->dispose();
}
```

## **เปิดงานนำเสนอขนาดใหญ่**

Aspose.Slides มีตัวเลือก—โดยเฉพาะเมธอด [getBlobManagementOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) ในคลาส [LoadOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/)—เพื่อช่วยคุณโหลดงานนำเสนอขนาดใหญ่

ตัวอย่าง PHP ด้านล่างแสดงการโหลดงานนำเสนอขนาดใหญ่ (เช่น 2 GB):

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Choose the KeepLocked behavior — ไฟล์งานนำเสนอจะถูกล็อกไว้ตลอดอายุของ
// อินสแตนซ์ Presentation, แต่ไม่จำเป็นต้องโหลดเข้าสู่หน่วยความจำหรือคัดลอกเป็นไฟล์ชั่วคราว.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // งานนำเสนอขนาดใหญ่ได้ถูกโหลดและสามารถใช้งานได้โดยที่การใช้หน่วยความจำน้อย.

    // ทำการเปลี่ยนแปลงงานนำเสนอ.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // บันทึกงานนำเสนอไปยังไฟล์อื่น การใช้หน่วยความจำยังคงต่ำระหว่างการดำเนินการนี้.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// อย่าทำเช่นนี้! จะเกิดข้อยกเว้น I/O เนื่องจากไฟล์ถูกล็อกจนกว่าอ็อบเจ็กต์ Presentation จะถูกปล่อย.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// สามารถทำได้ที่นี่ไฟล์ต้นฉบับไม่ถูกล็อกโดยอ็อบเจ็กต์ Presentation อีกต่อไป.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}

เพื่อแก้ไขข้อจำกัดบางประการเมื่อทำงานกับสตรีม Aspose.Slides อาจคัดลอกเนื้อหาของสตรีม การโหลดงานนำเสนอขนาดใหญ่จากสตรีมจะทำให้งานนำเสนอถูกคัดลอกและอาจทำให้การโหลดช้าลง ดังนั้นเมื่อคุณต้องการโหลดงานนำเสนอขนาดใหญ่ เราแนะนำอย่างยิ่งให้ใช้พาธไฟล์ของงานนำเสนอแทนการใช้สตรีม

เมื่อสร้างงานนำเสนอที่มีวัตถุขนาดใหญ่ (วิดีโอ, เสียง, รูปภาพความละเอียดสูง ฯลฯ) คุณสามารถใช้ [BLOB management](/slides/th/php-java/manage-blob/) เพื่อลดการใช้หน่วยความจำ

{{%/alert %}}

## **ควบคุมทรัพยากรภายนอก**

Aspose.Slides มีอินเทอร์เฟซ [IResourceLoadingCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iresourceloadingcallback/) ที่ช่วยให้คุณจัดการทรัพยากรภายนอก ตัวอย่าง PHP ด้านล่างแสดงวิธีใช้อินเทอร์เฟซ `IResourceLoadingCallback`:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // โหลดรูปภาพทดแทน.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // ตั้งค่า URL ทดแทน.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // ข้ามรูปภาพอื่นทั้งหมด.
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **โหลดงานนำเสนอโดยไม่มีวัตถุไบนารีฝัง**

งานนำเสนอ PowerPoint สามารถมีวัตถุไบนารีฝังประเภทต่อไปนี้:

- โครงการ VBA (เข้าถึงได้ผ่าน [Presentation.getVbaProject](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getVbaProject));
- ข้อมูล OLE ที่ฝัง (เข้าถึงได้ผ่าน [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/th/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- ข้อมูลไบนารีของคอนโทรล ActiveX (เข้าถึงได้ผ่าน [Control.getActiveXControlBinary](https://reference.aspose.com/slides/th/php-java/aspose.slides/control/#getActiveXControlBinary)).

โดยใช้เมธอด [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) คุณสามารถโหลดงานนำเสนอโดยไม่มีวัตถุไบนารีฝังใด ๆ

เมธอดนี้มีประโยชน์สำหรับการลบเนื้อหาไบนารีที่อาจเป็นอันตราย ตัวอย่าง PHP ด้านล่างแสดงวิธีโหลดงานนำเสนอโดยไม่มีเนื้อหาไบนารีฝัง:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // ทำการดำเนินการบนงานนำเสนอ.
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะรู้ได้อย่างไรว่าไฟล์เสียหายและไม่สามารถเปิดได้?**

คุณจะได้รับข้อยกเว้นการตรวจสอบการพาร์สหรือรูปแบบในระหว่างการโหลด ข้อผิดพลาดนี้มักจะระบุโครงสร้าง ZIP ที่ไม่ถูกต้องหรือเรคคอร์ด PowerPoint ที่เสียหาย

**จะเกิดอะไรขึ้นหากฟอนต์ที่จำเป็นหายไปเมื่อต้องเปิดไฟล์?**

ไฟล์จะเปิดได้ แต่ภายหลังการ [rendering/export](/slides/th/php-java/convert-presentation/) อาจใช้ฟอนต์แทน คุณสามารถ [Configure font substitutions](/slides/th/php-java/font-substitution/) หรือ [add the required fonts](/slides/th/php-java/custom-font/) ในสภาพแวดล้อมการทำงาน

**จะทำอย่างไรกับสื่อที่ฝังอยู่ (วิดีโอ/เสียง) เมื่อต้องเปิดไฟล์?**

สื่อเหล่านั้นจะพร้อมใช้งานเป็นทรัพยากรของงานนำเสนอ หากสื่อถูกอ้างอิงผ่านพาธภายนอก ให้ตรวจสอบว่าพาธเหล่านั้นเข้าถึงได้ในสภาพแวดล้อมของคุณ มิฉะนั้นการ [rendering/export](/slides/th/php-java/convert-presentation/) อาจละเว้นสื่อดังกล่าว