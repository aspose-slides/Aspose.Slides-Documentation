---
title: แปลง PPT เป็น PPTX ด้วย PHP
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
- ส่งออก PPT ไปยัง PPTX
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "แปลงไฟล์ PPT แบบเก่าเป็น PPTX ด้วย PHP และ Aspose.Slides รวมตัวอย่าง PHP สำหรับการแปลงไฟล์เดี่ยวและแบบกลุ่ม การจัดการข้อผิดพลาด และโน๊ตเกี่ยวกับความเที่ยงตรง"
---
## **ภาพรวม**

PPT คือรูปแบบไบนารีเก่าของ PowerPoint ในขณะที่ PPTX เป็นรูปแบบ Open XML ล่าสุด Aspose.Slides for PHP via Java สามารถโหลดไฟล์ PPT แล้วบันทึกเป็น PPTX ได้โดยไม่ต้องใช้ Microsoft PowerPoint บทความนี้แสดงวิธีแปลงไฟล์เดี่ยวหรือหลายไฟล์ในโฟลเดอร์และอธิบายสิ่งที่ควรตรวจสอบหลังการแปลง

## **แปลงไฟล์ PPT เป็น PPTX**

โหลดไฟล์ต้นฉบับด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) จากนั้นเรียก [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) พร้อมอาร์กิวเมนต์ [SaveFormat::Pptx](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/#Pptx) ส่วน `finally` จะทำการยกเลิกการใช้งาน presentation และปล่อยทรัพยากร

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

ส่วนขยายของไฟล์ไม่ได้เป็นตัวกำหนดรูปแบบผลลัพธ์เอง; ตัวอาร์กิวเมนต์ [SaveFormat::Pptx](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/#Pptx) เป็นตัวกำหนด ควรตั้งค่าเส้นทางอินพุตและเอาต์พุตให้ต่างกันหากต้องการเก็บไฟล์ PPT ดั้งเดิมไว้

## **แปลงไฟล์ PPT หลายไฟล์**

ตัวอย่างต่อไปนี้จะแปลงทุกไฟล์ `.ppt` ในโฟลเดอร์หนึ่ง แต่ละไฟล์จะถูกประมวลผลแยกกัน ดังนั้นการแปลงล้มเหลวหนึ่งไฟล์จะไม่ส่งผลต่อไฟล์ที่เหลือ

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

สำหรับงานในสภาพการผลิต ควรบันทึกข้อยกเว้นทั้งหมด, ตัดสินใจว่าควรเขียนทับไฟล์เอาต์พุตที่มีอยู่หรือไม่, และบันทึกชื่อไฟล์ที่ล้มเหลวไปยังคิวรีไทรหรือคิวตรวจสอบ ไฟล์เสีย, ไฟล์ที่ป้องกันด้วยรหัสผ่านแต่เปิดโดยไม่ได้ใส่รหัส, เส้นทางที่เข้าถึงไม่ได้, หรือเนื้อหาที่ไม่รองรับ ทั้งหมดนี้อาจทำให้การแปลงล้มเหลว ดูข้อมูลเพิ่มเติมที่ [Password‑Protected Presentations](/slides/th/php-java/password-protected-presentation/) สำหรับการโหลดไฟล์ที่เข้ารหัส

## **ความเที่ยงตรงและคุณลักษณะเก่า**

โดยทั่วไปการแปลงจะคงสไลด์, มาสเตอร์, เลย์เอาต์, ข้อความ, รูปร่าง, ภาพ, ตาราง, และแผนภูมิไว้ แต่ PPT และ PPTX ไม่ได้แสดงคุณลักษณะทุกอย่างในลักษณะที่เหมือนกัน คุณลักษณะเก่าที่ไม่มีเทียบเท่าใน PPTX หรือที่ไลบรารีไม่รองรับอาจถูกทำให้อยู่ในรูปแบบมาตรฐาน, ถูกละเว้น, หรือแสดงแตกต่างกัน

ตรวจสอบไฟล์ที่แปลงแล้วเมื่อมีการใช้แอนิเมชัน, การเปลี่ยนฉาก, วัตถุ OLE ฝังหรือเชื่อมโยง, คอนโทรล ActiveX, สื่อฝัง, ฟอนต์ที่หายาก, หรือแมโคร VBA ไฟล์ PPTX ธรรมดาไม่ได้เป็นรูปแบบที่รองรับแมโคร ดังนั้นหากต้องการให้ VBA ยังคงใช้งานได้ ควรใช้กระบวนการทำงานที่รองรับแมโคร ตรวจสอบให้แน่ใจว่าฟอนต์ที่จำเป็นและทรัพยากรภายนอกมีอยู่ในสภาพแวดล้อมที่นำเสนอที่แปลงแล้วจะถูกเปิดหรือเรนเดอร์

สำหรับเอกสารสำคัญ ควรเปิด PPTX ที่สร้างขึ้นโดยโปรแกรมและตรวจสอบจำนวนสไลด์และเนื้อหาที่สำคัญ จากนั้นเปรียบเทียบลักษณะการแสดงผลและพฤติกรรมการสไลด์โชว์ในตัวดูที่ตั้งใจ อย่าพิจารณาว่าการเรียก [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) สำเร็จเป็นหลักฐานว่าทุกคุณลักษณะเก่ามีการแสดงผลใน PPTX อย่างสมบูรณ์

## **เมื่อควรใช้ PPTX**

ใช้ PPTX เมื่อการนำเสนอจะถูกแก้ไขในเวอร์ชัน PowerPoint ปัจจุบัน, ต้องแลกเปลี่ยนกับระบบที่ทำงานกับแพคเกจ Open XML, หรือเก็บในรูปแบบที่ตรวจสอบและกู้คืนได้ง่ายกว่ารูปแบบไบนารีเก่า ควรเก็บไฟล์ PPT ดั้งเดิมเป็นสำเนาสำรองหรือสำเนากลับจนกว่าการตรวจสอบความเที่ยงตรงของการแปลงจะผ่าน

หากต้องการ PDF, HTML, ภาพ, XPS หรือรูปแบบเอาต์พุตอื่น ให้ใช้แนวทางตามรูปแบบใน [Convert Presentations to Multiple Formats](/slides/th/php-java/convert-presentation/) แทนการสมมติว่าทั้งหมดจะคงคุณลักษณะที่แก้ไขได้ของ PowerPoint

## **เครื่องแปลงออนไลน์**

สำหรับไฟล์เป็นครั้งคราวหรือการเปรียบเทียบอย่างรวดเร็ว สามารถใช้ [online PPT to PPTX converter](https://products.aspose.app/slides/th/conversion/ppt-to-pptx) แต่สำหรับการแปลงที่ทำซ้ำ, การประมวลผลเป็นชุด, หรือการจัดการข้อผิดพลาดระดับแอปพลิเคชัน ให้ใช้ PHP API

## **บทความเกี่ยวข้อง**

- [PPT vs PPTX](/slides/th/php-java/ppt-vs-pptx/)
- [Save Presentations in PHP](/slides/th/php-java/save-presentation/)
- [Supported File Formats](/slides/th/php-java/supported-file-formats/)
- [Open Presentations in PHP](/slides/th/php-java/open-presentation/)

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลง PPT เป็น PPTX ได้โดยไม่ต้องติดตั้ง Microsoft PowerPoint หรือไม่?**

ได้ Aspose.Slides for PHP via Java สามารถโหลดและบันทึกไฟล์งานนำเสนอได้โดยไม่ต้องใช้ Microsoft PowerPoint

**การแปลง PPT ไป PPTX จะคงเนื้อหาทั้งหมดอย่างแม่นยำหรือไม่?**

จะคงเนื้อหาทั่วไปของงานนำเสนอไว้ แต่ความเที่ยงตรงแบบสมบูรณ์ไม่สามารถรับประกันได้สำหรับทุกคุณลักษณะเก่าหรือคุณลักษณะที่ไม่รองรับ ควรตรวจสอบไฟล์ที่สร้างเมื่อมีแมโคร, วัตถุ OLE หรือ ActiveX, สื่อ, แอนิเมชันพิเศษ, หรือฟอนต์ที่หายาก

**ฉันสามารถแปลงไฟล์ PPT ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้ หากคุณระบุรหัสผ่านที่ถูกต้องเมื่อตอนโหลดไฟล์ การขาดหรือรหัสผ่านผิดพลาดจะทำให้การโหลดล้มเหลว

**ฉันควรลบไฟล์ PPT หลังจากแปลงหรือไม่?**

ควรเก็บไฟล์ต้นฉบับไว้จนกว่าจะตรวจสอบ PPTX ในตัวดูและกระบวนการที่สำคัญสำหรับคุณ ซึ่งจะเป็นสำเนากลับหากคุณลักษณะเก่าแปลงได้แตกต่างกัน