---
title: "จัดการ BLOB ของงานนำเสนอใน PHP เพื่อการใช้หน่วยความจำที่มีประสิทธิภาพ"
linktitle: "จัดการ BLOB"
type: docs
weight: 10
url: /th/php-java/manage-blob/
keywords:
- "วัตถุขนาดใหญ่"
- "รายการขนาดใหญ่"
- "ไฟล์ขนาดใหญ่"
- "เพิ่ม BLOB"
- "ส่งออก BLOB"
- "เพิ่มรูปภาพเป็น BLOB"
- "ลดการใช้หน่วยความจำ"
- "การใช้หน่วยความจำ"
- "งานนำเสนอขนาดใหญ่"
- "ไฟล์ชั่วคราว"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- "PHP"
- "Aspose.Slides"
description: "จัดการข้อมูล BLOB ใน Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อทำให้การดำเนินการไฟล์ PowerPoint และ OpenDocument มีประสิทธิภาพในการจัดการงานนำเสนอ"
---
## **ภาพรวม**

Aspose.Slides ให้การจัดการแบบ BLOB สำหรับข้อมูลไบนารีขนาดใหญ่ในงานนำเสนอ เพื่อช่วยลดการใช้หน่วยความจำเมื่อทำงานกับรูปภาพขนาดใหญ่, เสียง, วิดีโอ และไฟล์งานนำเสนอ

บทความนี้แสดงวิธีใช้การประมวลผลแบบ BLOB เพื่อเพิ่มสื่อขนาดใหญ่ในงานนำเสนอ, ส่งออกสื่อขนาดใหญ่จากงานนำเสนอ, และโหลดงานนำเสนอขนาดใหญ่ได้อย่างมีประสิทธิภาพ นอกจากนี้ยังอธิบายวิธีใช้ไฟล์ชั่วคราวระหว่างการประมวลผลและวิธีเปลี่ยนโฟลเดอร์ที่ใช้ในการจัดเก็บไฟล์เหล่านั้น

## **เกี่ยวกับ BLOB**

**BLOB** (**Binary Large Object**) มักหมายถึงรายการขนาดใหญ่ (ภาพถ่าย, งานนำเสนอ, เอกสาร หรือสื่อ) ที่บันทึกในรูปแบบไบนารี

Aspose.Slides for PHP via Java ให้คุณใช้ BLOB สำหรับวัตถุในลักษณะที่ลดการใช้หน่วยความจำเมื่อไฟล์ขนาดใหญ่มีส่วนเกี่ยวข้อง

{{% alert title="Info" color="info" %}}
เพื่อหลีกเลี่ยงข้อจำกัดบางประการเมื่อทำงานกับสตรีม, Aspose.Slides อาจคัดลอกเนื้อหาสตรีม การโหลดงานนำเสนอขนาดใหญ่ผ่านสตรีมจะทำให้เกิดการคัดลอกเนื้อหาของงานนำเสนอและทำให้การโหลดช้า ดังนั้นเมื่อคุณต้องการโหลดงานนำเสนอขนาดใหญ่ เราขอแนะนำให้ใช้เส้นทางไฟล์งานนำเสนอแทนการใช้สตรีม
{{% /alert %}}

## **ใช้ BLOB เพื่อลดการใช้หน่วยความจำ**

### **เพิ่มไฟล์ขนาดใหญ่ผ่าน BLOB ลงในงานนำเสนอ**

[Aspose.Slides](/slides/th/php-java/) for Java ให้คุณเพิ่มไฟล์ขนาดใหญ่ (ในกรณีนี้คือไฟล์วิดีโอขนาดใหญ่) ผ่านกระบวนการที่ใช้ BLOB เพื่อลดการใช้หน่วยความจำ

โค้ด Java นี้จะแสดงวิธีเพิ่มไฟล์วิดีโอขนาดใหญ่ผ่านกระบวนการ BLOB ลงในงานนำเสนอ:

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # สร้างงานนำเสนอใหม่ที่วิดีโอจะถูกเพิ่มเข้าไป
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # เพิ่มวิดีโอลงในงานนำเสนอ - เราเลือกพฤติกรรม KeepLocked เนื่องจากเราไม่ตั้งใจเข้าถึงไฟล์ "veryLargeVideo.avi"
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # บันทึกงานนำเสนอ ในขณะที่งานนำเสนอขนาดใหญ่กำลังถูกสร้าง การใช้หน่วยความจำจะคงที่ต่ำตลอดวงจรชีวิตของวัตถุ pres
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **ส่งออกไฟล์ขนาดใหญ่ผ่าน BLOB จากงานนำเสนอ**
Aspose.Slides for PHP via Java ให้คุณส่งออกไฟล์ขนาดใหญ่ (เช่นไฟล์เสียงหรือวิดีโอ) ผ่านกระบวนการที่ใช้ BLOB จากงานนำเสนอ ตัวอย่างเช่น คุณอาจต้องการสกัดไฟล์สื่อขนาดใหญ่จากงานนำเสนอแต่ไม่ต้องการให้ไฟล์ถูกโหลดเข้าสู่หน่วยความจำของคอมพิวเตอร์โดยตรง การส่งออกไฟล์ผ่านกระบวนการ BLOB จะทำให้การใช้หน่วยความจำต่ำลง

โค้ดต่อไปนี้แสดงการดำเนินการที่อธิบายไว้:

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # ล็อกไฟล์ต้นทางและไม่โหลดเข้าไปในหน่วยความจำ
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # สร้างอินสแตนซ์ Presentation และล็อกไฟล์ "hugePresentationWithAudiosAndVideos.pptx"
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # ให้บันทึกวิดีโอแต่ละไฟล์ลงในไฟล์ เพื่อป้องกันการใช้หน่วยความจำมากเกินไป เราต้องมีบัฟเฟอร์ที่จะใช้
    # เพื่อถ่ายโอนข้อมูลจากสตรีมวิดีโอของงานนำเสนอไปยังสตรีมของไฟล์วิดีโอที่สร้างใหม่
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # วนรอบผ่านวิดีโอทั้งหมด
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # เปิดสตรีมวิดีโอของงานนำเสนอ โปรดทราบว่าเราตั้งใจหลีกเลี่ยงการเข้าถึงคุณลักษณะ
      # เช่น video.BinaryData - เนื่องจากคุณลักษณะนี้คืนค่ารายการไบต์ที่มีวิดีโอเต็ม ซึ่ง
      # ทำให้ไบต์ถูกโหลดเข้าในหน่วยความจำ เราใช้ video.GetStream ซึ่งจะคืนค่าเป็น Stream - และไม่
      # ต้องโหลดวิดีโอทั้งหมดเข้าสู่หน่วยความจำ
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # การใช้หน่วยความจำจะคงต่ำไม่ว่าไฟล์วิดีโอหรือการนำเสนอจะมีขนาดเท่าใด
    }
    # หากจำเป็น คุณสามารถทำตามขั้นตอนเดียวกันสำหรับไฟล์เสียงได้
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **เพิ่มรูปภาพเป็น BLOB ลงในงานนำเสนอ**
ด้วยเมธอดจากคลาส [ImageCollection](https://reference.aspose.com/slides/th/php-java/aspose.slides/imagecollection/) คุณสามารถเพิ่มรูปภาพขนาดใหญ่เป็นสตรีมเพื่อให้ถือเป็น BLOB

โค้ด PHP นี้จะแสดงวิธีเพิ่มรูปภาพขนาดใหญ่ผ่านกระบวนการ BLOB:

```php
  $pathToLargeImage = "large_image.jpg";
  # สร้างงานนำเสนอใหม่ที่ภาพจะถูกเพิ่มเข้าไป.
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # เราจะเพิ่มภาพลงในงานนำเสนอ - เราเลือกพฤติกรรม KeepLocked เนื่องจากเรา
      # ไม่ได้ตั้งใจเข้าถึงไฟล์ "largeImage.png" .
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # บันทึกงานนำเสนอ ในขณะที่งานนำเสนอขนาดใหญ่กำลังถูกสร้าง การใช้หน่วยความจำ
      # จะคงต่ำตลอดอายุการทำงานของวัตถุ pres
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **หน่วยความจำและงานนำเสนอขนาดใหญ่**

โดยทั่วไป การโหลดงานนำเสนอขนาดใหญ่อยู่ต้องการหน่วยความจำชั่วคราวจำนวนมาก เนื้อหาทั้งหมดของงานนำเสนอจะถูกโหลดเข้าสู่หน่วยความจำและไฟล์ต้นทาง (ไฟล์ที่งานนำเสนอนั้นถูกโหลดมาจาก) จะหยุดถูกใช้งาน

พิจารณางานนำเสนอ PowerPoint ขนาดใหญ่ (large.pptx) ที่มีไฟล์วิดีโอขนาด 1.5 GB วิธีมาตรฐานในการโหลดงานนำเสนอแสดงในโค้ด PHP นี้:

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

แต่วิธีนี้ใช้หน่วยความจำชั่วคราวประมาณ 1.6 GB

### **โหลดงานนำเสนอขนาดใหญ่เป็น BLOB**

ผ่านกระบวนการที่ใช้ BLOB คุณสามารถโหลดงานนำเสนอขนาดใหญ่โดยใช้หน่วยความจำน้อย โค้ด PHP นี้อธิบายการนำ BLOB มาใช้ในการโหลดไฟล์งานนำเสนอขนาดใหญ่ (large.pptx):

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **เปลี่ยนโฟลเดอร์สำหรับไฟล์ชั่วคราว**

เมื่อใช้กระบวนการ BLOB คอมพิวเตอร์ของคุณจะสร้างไฟล์ชั่วคราวในโฟลเดอร์เริ่มต้น หากต้องการให้ไฟล์ชั่วคราวถูกเก็บในโฟลเดอร์อื่น คุณสามารถเปลี่ยนการตั้งค่าเก็บไฟล์โดยใช้ `setTempFilesRootPath`:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
เมื่อคุณใช้ `setTempFilesRootPath` Aspose.Slides จะไม่สร้างโฟลเดอร์สำหรับเก็บไฟล์ชั่วคราวโดยอัตโนมัติ คุณต้องสร้างโฟลเดอร์นั้นด้วยตนเอง
{{% /alert %}}

### **ทำลายออบเจกต์ Presentation เพื่อปล่อยหน่วยความจำ**

เมื่อประมวลผลงานนำเสนอขนาดใหญ่ ให้แน่ใจว่าอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ถูกทำลายอย่างเหมาะสมเพื่อปล่อยหน่วยความจำที่ออบเจกต์ใช้งานแล้ว ให้เรียก `dispose()` หลังจากใช้งานนำเสนอเสร็จแล้วเพื่อคืนทรัพยากรที่ไม่ได้จัดการ

```php
$presentation = new Presentation("large.pptx");

# ...ประมวลผลงานนำเสนอ...
$presentation->save("large.pdf", SaveFormat::Pdf);

# ปล่อยทรัพยากรโดยชัดเจน.
$presentation->dispose();
```

## **FAQ**

**อะไรบ้างที่ในงานนำเสนอ Aspose.Slides ถือเป็น BLOB และถูกควบคุมโดยตัวเลือก BLOB?**

วัตถุไบนารีขนาดใหญ่ เช่น รูปภาพ, เสียง, และวิดีโอ จะถือเป็น BLOB ไฟล์งานนำเสนอทั้งหมดก็เกี่ยวข้องกับการจัดการ BLOB เมื่อมีการโหลดหรือบันทึก วัตถุเหล่านี้อยู่ภายใต้นโยบาย BLOB ที่ให้คุณจัดการการใช้หน่วยความจำและการสลับไปยังไฟล์ชั่วคราวเมื่อจำเป็น

**ฉันกำหนดกฏการจัดการ BLOB ระหว่างการโหลดงานนำเสนอได้ที่ไหน?**

ใช้ [LoadOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/) พร้อมกับ [BlobManagementOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/blobmanagementoptions/) ที่นั่นคุณตั้งค่าขีดจำกัดหน่วยความจำสำหรับ BLOB, เปิดหรือปิดการใช้ไฟล์ชั่วคราว, เลือกเส้นทางรากสำหรับไฟล์ชั่วคราว, และกำหนดพฤติกรรมการล็อกแหล่งข้อมูล

**การตั้งค่า BLOB มีผลต่อประสิทธิภาพหรือไม่ และฉันจะสมดุลความเร็วกับหน่วยความจำอย่างไร?**

มีผล การเก็บ BLOB ในหน่วยความจำจะให้ความเร็วสูงสุดแต่ใช้ RAM มากขึ้น; การลดขีดจำกัดหน่วยความจำจะย้ายงานไปยังไฟล์ชั่วคราว ลด RAM แต่เพิ่ม I/O ใช้เมธอด [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/th/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) เพื่อหาจุดสมดุลที่เหมาะกับโหลดงานและสภาพแวดล้อมของคุณ

**ตัวเลือก BLOB ช่วยเมื่อเปิดงานนำเสนอที่ใหญ่มาก (เช่นหลายกิกะไบต์) หรือไม่?**

ใช่ [BlobManagementOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/blobmanagementoptions/) ถูกออกแบบมาสำหรับสถานการณ์เช่นนี้: การเปิดใช้ไฟล์ชั่วคราวและการล็อกแหล่งข้อมูลสามารถลดการใช้ RAM สูงสุดและทำให้การประมวลผลงานนำเสนอขนาดใหญ่มากเป็นไปอย่างเสถียร

**ฉันสามารถใช้แนวทาง BLOB เมื่อโหลดจากสตรีมแทนไฟล์ดิสก์ได้หรือไม่?**

ได้ กฎเดียวกันใช้กับสตรีม: อินสแตนซ์งานนำเสนอสามารถเป็นเจ้าของและล็อกสตรีมอินพุต (ขึ้นกับโหมดล็อกที่เลือก) และไฟล์ชั่วคราวจะถูกใช้เมื่ออนุญาต ทำให้การใช้หน่วยความจำคาดการณ์ได้ในระหว่างการประมวลผล