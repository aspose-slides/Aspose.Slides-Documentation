---
title: แปลง PPT เป็น PPTX ใน PHP
linktitle: PPT เป็น PPTX
type: docs
weight: 20
url: /th/php-java/convert-ppt-to-pptx/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- PPT เป็น PPTX
- บันทึก PPT เป็น PPTX
- ส่งออก PPT ไปเป็น PPTX
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "แปลงไฟล์ PPT แบบเก่าเป็น PPTX ใน PHP ด้วย Aspose.Slides รวมตัวอย่าง PHP สำหรับการแปลงไฟล์เดี่ยวและเป็นกลุ่ม การจัดการข้อผิดพลาดและหมายเหตุความแม่นยำ"
---
## **ภาพรวม**

PPT เป็นรูปแบบไบนารีที่เก่าของ PowerPoint ในขณะที่ PPTX เป็นรูปแบบ Open XML ที่ใหม่กว่า Aspose.Slides สำหรับ PHP ผ่าน Java สามารถโหลดไฟล์ PPT และบันทึกเป็น PPTX ได้โดยไม่ต้องใช้ Microsoft PowerPoint บทความนี้แสดงวิธีแปลงไฟล์เดียวหรือไดเรกทอรีของไฟล์และอธิบายสิ่งที่ควรตรวจสอบหลังการแปลง

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นทางด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) แล้วเรียกใช้ [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) พร้อมอาร์กิวเมนต์ [SaveFormat::Pptx](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/#Pptx) บล็อก `finally` จะทำการยกเลิกการใช้งาน presentation และปล่อยทรัพยากรของมัน

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// โหลดงานนำเสนอ PPT แบบเก่า.
$presentation = new Presentation("presentation.ppt");
try {
    // บันทึกงานนำเสนอในรูปแบบ PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

นามสกุลไฟล์ไม่ได้เลือกรูปแบบการส่งออกด้วยตัวเอง; อาร์กิวเมนต์ [SaveFormat::Pptx](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/#Pptx) เป็นตัวกำหนด ให้รักษาเส้นทางอินพุตและเอาต์พุตแตกต่างกันหากคุณต้องการเก็บไฟล์ PPT ดั้งเดิมไว้

## **แปลงหลายไฟล์ PPT**

ตัวอย่างต่อไปนี้จะแปลงไฟล์ `.ppt` ทุกไฟล์ในไดเรกทอรีหนึ่ง แต่ละไฟล์จะถูกประมวลผลแยกกัน ดังนั้นการแปลงที่ล้มเหลวหนึ่งไฟล์จะไม่ทำให้ชุดทั้งหมดหยุดทำงาน

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

สำหรับงานในขั้นตอนการผลิต ให้บันทึกข้อยกเว้นทั้งหมด, ตัดสินใจว่าจะเขียนทับไฟล์เอาต์พุตที่มีอยู่หรือไม่, และเขียนชื่อไฟล์ที่ล้มเหลวไปยังคิวการลองใหม่หรือการตรวจสอบ ไฟล์ที่เสียหาย, ไฟล์ที่มีการป้องกันด้วยรหัสผ่านที่เปิดโดยไม่ได้ใส่รหัสผ่านที่จำเป็น, เส้นทางที่เข้าถึงไม่ได้, และเนื้อหาที่ไม่รองรับทั้งหมดอาจทำให้การแปลงล้มเหลว ดูที่ [Password-Protected Presentations](/php-java/password-protected-presentation/) สำหรับการโหลดไฟล์ที่เข้ารหัส

## **ความแม่นยำและคุณลักษณะเดิม**

การแปลงโดยทั่วไปจะรักษาสไลด์, มาสเตอร์, เลย์เอาต์, ข้อความ, รูปร่าง, ภาพ, ตาราง, และแผนภูมิไว้ แต่ PPT และ PPTX ไม่ได้แสดงคุณลักษณะทุกอย่างในลักษณะเดียวกัน คุณลักษณะเดิมที่ไม่มีเทียบเท่าใน PPTX หรือไม่รองรับโดยไลบรารีอาจถูกทำให้เป็นมาตรฐาน, ถูกละเว้น, หรือแสดงในรูปแบบที่ต่างออกไป

ให้ตรวจสอบไฟล์ที่แปลงแล้วเมื่อมีแอนิเมชัน, การเปลี่ยนฉาก, วัตถุ OLE ที่ฝังหรือเชื่อมโยง, ควบคุม ActiveX, สื่อที่ฝัง, ฟอนต์ที่ไม่ทั่วไป, หรือมาโคร VBA ไฟล์ PPTX ธรรมดาไม่ใช่รูปแบบที่รองรับมาโคร ดังนั้นให้ใช้ขั้นตอนการทำงานที่รองรับมาโครเมื่อ VBA จำเป็นต้องใช้ นอกจากนี้ตรวจสอบให้แน่ใจว่าฟอนต์ที่ต้องการและทรัพยากรภายนอกมีอยู่ในสภาพแวดล้อมที่จะแสดงหรือเรนเดอร์งานนำเสนอที่แปลงแล้ว

สำหรับเอกสารสำคัญ ให้เปิดไฟล์ PPTX ที่สร้างขึ้นใหม่ด้วยโปรแกรมและตรวจสอบจำนวนสไลด์และเนื้อหาที่สำคัญ, จากนั้นเปรียบเทียบรูปลักษณ์และพฤติกรรมการแสดงสไลด์ในผู้ชมที่กำหนดไว้ อย่าถือว่าการเรียก [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) ที่สำเร็จเป็นหลักฐานว่าทุกคุณลักษณะเดิมมีการแสดงผลที่ตรงกับ PPTX อย่างสมบูรณ์

## **เมื่อควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขในเวอร์ชัน PowerPoint ปัจจุบัน, แลกเปลี่ยนกับระบบที่ทำงานกับแพ็กเกจ Open XML, หรือเก็บในรูปแบบที่ตรวจสอบและกู้คืนได้ง่ายกว่ารูปแบบไบนารี PPT แบบเก่า เก็บไฟล์ PPT ดั้งเดิมเป็นสำเนาเก็บถาวรหรือสำเนาการกู้คืนจนกว่าการนำเสนอที่แปลงแล้วจะผ่านการตรวจสอบความแม่นยำของคุณ

หากคุณต้องการ PDF, HTML, ภาพ, XPS, หรือรูปแบบการส่งออกอื่นแทน, ให้ใช้คำแนะนำตามรูปแบบใน [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) แทนการสันนิษฐานว่าทุกเป้าหมายจะรักษาฟีเจอร์ PowerPoint ที่แก้ไขได้

## **เครื่องแปลงออนไลน์**

สำหรับไฟล์ที่ต้องการแปลงเป็นครั้งคราวหรือเปรียบเทียบอย่างรวดเร็ว คุณสามารถใช้ [online PPT to PPTX converter](https://products.aspose.app/slides/th/conversion/ppt-to-pptx) ได้ สำหรับการแปลงที่ทำเป็นประจำ, การประมวลผลเป็นกลุ่ม, หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน ให้ใช้ API ของ PHP

## **บทความที่เกี่ยวข้อง**

- [PPT กับ PPTX](/php-java/ppt-vs-pptx/)
- [บันทึกการนำเสนอใน PHP](/php-java/save-presentation/)
- [รูปแบบไฟล์ที่รองรับ](/php-java/supported-file-formats/)
- [เปิดการนำเสนอใน PHP](/php-java/open-presentation/)

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลง PPT เป็น PPTX ได้โดยไม่ต้องติดตั้ง Microsoft PowerPoint หรือไม่?**

ใช่ Aspose.Slides สำหรับ PHP ผ่าน Java สามารถโหลดและบันทึกไฟล์การนำเสนอได้โดยไม่ต้องใช้ Microsoft PowerPoint

**การแปลงจาก PPT ไปเป็น PPTX จะคงรักษาเนื้อหาทั้งหมดอย่างแม่นยำหรือไม่?**

มันจะคงรักษาเนื้อหาการนำเสนอทั่วไปไว้ได้ แต่ความแม่นยำอย่างสมบูรณ์ไม่สามารถรับประกันได้สำหรับทุกคุณลักษณะเดิมหรือคุณลักษณะที่ไม่รองรับ ให้ตรวจสอบไฟล์ที่สร้างขึ้นเมื่อมีมาโคร, วัตถุ OLE หรือ ActiveX, สื่อ, แอนิเมชันพิเศษ, หรือฟอนต์ที่ไม่ทั่วไป

**ฉันสามารถแปลงไฟล์ PPT ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช่ หากคุณระบุรหัสผ่านที่ถูกต้องเมื่อโหลดไฟล์ การไม่มีหรือรหัสผ่านที่ไม่ถูกต้องจะทำให้การโหลดล้มเหลว

**ควรลบไฟล์ PPT หลังการแปลงหรือไม่?**

ให้เก็บไฟล์ต้นฉบับไว้จนกว่าคุณจะตรวจสอบ PPTX ในผู้ชมและขั้นตอนการทำงานที่สำคัญสำหรับคุณ ซึ่งจะเป็นสำเนาสำรองในกรณีที่คุณลักษณะเดิมแปลงได้แตกต่าง