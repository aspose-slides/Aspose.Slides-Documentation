---
title: บันทึกการนำเสนอใน PHP
linktitle: บันทึกการนำเสนอ
type: docs
weight: 80
url: /th/php-java/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกการนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- การนำเสนอเป็นไฟล์
- การนำเสนอเป็นสตรีม
- ประเภทมุมมองที่กำหนดไว้ล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชภาพย่อ
- บันทึกความคืบหน้า
- PHP
- Aspose.Slides
description: "บันทึกการนำเสนอ PowerPoint และ OpenDocument เป็นไฟล์หรือสตรีมใน PHP ด้วย Aspose.Slides และกำหนดการส่งออก PPTX รวมถึงการรายงานความคืบหน้า"
---
## **ภาพรวม**

หลังจากคุณสร้างการนำเสนอหรือ [เปิดการนำเสนอที่มีอยู่](/slides/th/php-java/open-presentation/), ใช้เมธอด [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) เพื่อเขียนผลลัพธ์ Aspose.Slides for PHP via Java สามารถบันทึกการนำเสนอเป็นไฟล์หรือสตรีมในรูปแบบ PowerPoint, OpenDocument, PDF และรูปแบบอื่น ๆ ส่วนต่อไปนี้จะครอบคลุมการดำเนินการบันทึกมาตรฐานและตัวเลือกที่มีสำหรับการส่งออก PPTX

## **บันทึกการนำเสนอเป็นไฟล์**

เพื่อบันทึกการนำเสนอเป็นไฟล์, ส่งพาธเอาต์พุตและค่าของ [SaveFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/) ไปยังเมธอด [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) ค่าฟอร์แมตจะกำหนดประเภทของไฟล์ที่ Aspose.Slides สร้าง

ตัวอย่างต่อไปนี้สร้างการนำเสนอและบันทึกเป็นไฟล์ PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // เพิ่มหรือแก้ไขเนื้อหาการนำเสนอที่นี่.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **บันทึกการนำเสนอในรูปแบบเดิม**

สำหรับตัวอย่างการตรวจจับไฟล์และสตรีม, พฤติกรรมของการนำเสนอที่สร้างใหม่, และความแตกต่างระหว่างรูปแบบต้นฉบับและเอาต์พุต, ดูที่ [Determine the Original Presentation Format](/slides/th/php-java/detect-presentation-source-format/)

ในแอปพลิเคชันที่ประมวลผลเป็นชุด, รูปแบบอินพุตอาจไม่ทราบล่วงหน้า หลังจากโหลดไฟล์, อ่านรูปแบบต้นฉบับจากเมธอด [Presentation::getSourceFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSourceFormat) ส่งค่าของ [SourceFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/sourceformat/) ที่ได้ไปยังเมธอด [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideutil/#toSaveFormat) เพื่อรับค่าของ [SaveFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/) ที่สอดคล้อง, แล้วใช้ [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) เพื่อเขียนการนำเสนอที่แก้ไขแล้ว

ตัวอย่างเต็มต่อไปนี้ทำการประมวลผลทุกไฟล์ในไดเรกทอรีอินพุต, อัปเดตหัวเรื่อง, และบันทึกไปยังไดเรกทอรีเอาต์พุตในรูปแบบที่โหลดมา:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideutil/#toSaveFormat) จะแมป PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, และ PowerPoint XML ไปยังรูปแบบการบันทึกการนำเสนอที่สอดคล้อง มันแมปเฉพาะรูปแบบแหล่งของการนำเสนอเท่านั้น; ไม่ได้ออกแบบให้เลือกรูปแบบการส่งออกเช่น PDF, HTML, TIFF หรือรูปภาพ การส่งค่าของ [SourceFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/sourceformat/) ที่ไม่รองรับหรือไม่ถูกต้องจะทำให้เกิด [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html)

ไฟล์ PPT, PPS, และ POT รุ่นเก่ามีคอนเทนเนอร์ไบนารีเดียวกัน เมื่อการนำเสนอแบบนี้ถูกโหลดจากสตรีมโดยไม่มีส่วนขยายไฟล์, ไฟล์ PPS หรือ POT อาจถูกระบุเป็น PPT หากจำเป็นต้องรักษาชนิดย่อยของรุ่นเก่าไว้, ให้เก็บชื่อไฟล์หรือเมตาดาต้ารูปแบบเดิมแยกต่างหากและใช้เมื่อตั้งชื่อไฟล์และรูปแบบเอาต์พุต

## **บันทึกการนำเสนอเป็นสตรีม**

เพื่อเขียนการนำเสนอโดยไม่ต้องอ้างอิงพาธไฟล์สุดท้าย, ส่งสตรีมที่เขียนได้และค่าของ [SaveFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/) ไปยังเมธอด [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) วิธีนี้มีประโยชน์เมื่อเอาต์พุตต้องส่งคืนจากเว็บเซอร์วิส, เก็บในฐานข้อมูล, หรือประมวลผลในหน่วยความจำ

ตัวอย่างต่อไปนี้บันทึกการนำเสนอใหม่ไปยังสตรีมไฟล์:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **บันทึกการนำเสนอด้วยมุมมองที่กำหนดไว้ล่วงหน้า**

คุณสามารถกำหนดมุมมองที่ PowerPoint จะเปิดการนำเสนอที่บันทึกไว้ได้ ใช้เมธอด [ViewProperties::setLastView](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewproperties/#setLastView) พร้อมค่าของ [ViewType](https://reference.aspose.com/slides/th/php-java/aspose.slides/viewtype/) ก่อนบันทึก

ตัวอย่างต่อไปนี้ตั้งค่าให้มุมมอง Slide Master เป็นมุมมองเริ่มต้น:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **บันทึกการนำเสนอในรูปแบบ Strict Office Open XML**

เพื่อสร้างไฟล์ PPTX ที่สอดคล้องกับโปรไฟล์ Strict ของ Office Open XML, สร้างอินสแตนซ์ของ [PptxOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxoptions/) แล้วใช้เมธอด [PptxOptions::setConformance](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxoptions/#setConformance) พร้อมค่า [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/th/php-java/aspose.slides/conformance/#Iso29500-2008-Strict) จากนั้นส่งตัวเลือกไปยังเมธอด [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save)

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **บันทึกการนำเสนอในรูปแบบ Office Open XML ในโหมด Zip64**

ไฟล์ ZIP มาตรฐานจำกัดขนาดบีบอัดและขนาดไม่บีบอัดของแต่ละรายการ, ขนาดทั้งหมดของอาร์ไคฟ์, และจำนวนรายการ เนื่องจากไฟล์ PPTX เป็นอาร์ไคฟ์ ZIP, การนำเสนอที่มีขนาดใหญ่มากอาจเกินข้อจำกัดเหล่านี้ ส่วนขยาย ZIP64 จะยกข้อจำกัดขนาดและจำนวนรายการที่ใช้ได้

ใช้เมธอด [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxoptions/#setZip64Mode) เพื่อควบคุมว่าการเขียน ZIP64 จะเปิดหรือไม่:

- [IfNecessary](https://reference.aspose.com/slides/th/php-java/aspose.slides/zip64mode/#IfNecessary) ใช้ ZIP64 เฉพาะเมื่อการนำเสนอเกินขีดจำกัด ZIP มาตรฐาน นี่คือโหมดเริ่มต้น
- [Never](https://reference.aspose.com/slides/th/php-java/aspose.slides/zip64mode/#Never) ปิดการใช้ส่วนขยาย ZIP64
- [Always](https://reference.aspose.com/slides/th/php-java/aspose.slides/zip64mode/#Always) เขียนส่วนขยาย ZIP64 เสมอ

ตัวอย่างต่อไปนี้เปิดใช้งานส่วนขยาย ZIP64 อย่างต่อเนื่องสำหรับการนำเสนอเอาต์พุต:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="คำเตือน" %}}
หากใช้ [Zip64Mode::Never](https://reference.aspose.com/slides/th/php-java/aspose.slides/zip64mode/#Never) และการนำเสนอไม่สามารถพอดีในขีดจำกัด ZIP มาตรฐาน, การบันทึกจะโยนข้อยกเว้น [PptxException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **บันทึกการนำเสนอในรูปแบบ Office Open XML พร้อมระดับการบีบอัด**

สำหรับเอาต์พุต PPTX, คุณสามารถปรับสมดุลระหว่างความเร็วในการบันทึกและขนาดไฟล์โดยใช้เมธอด [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxoptions/#setCompressionLevel) คลาส [CompressionLevel](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/) มีค่าดังนี้:

- [None](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#None) เก็บข้อมูลโดยไม่มีการบีบอัด
- [Level1](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level1) ให้การบีบอัดที่เร็วที่สุดและผลลัพธ์ที่บีบอัดมากที่สุด
- [Level2](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level2) ถึง [Level5](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level5) ให้ความสำคัญกับขนาดไฟล์ที่เล็กลงมากกว่าความเร็วในการบันทึก
- [Level6](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level6) สมดุลระหว่างความเร็วและขนาดไฟล์ นี้คือระดับเริ่มต้น
- [Level7](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level7) และ [Level8](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level8) ให้ความสำคัญกับขนาดไฟล์ที่เล็กลงต่อไป
- [Level9](https://reference.aspose.com/slides/th/php-java/aspose.slides/compressionlevel/#Level9) ให้การบีบอัดที่แรงที่สุดแต่ต้องใช้เวลาประมวลผลมากที่สุด

ตัวอย่างต่อไปนี้บันทึกการนำเสนอโดยไม่มีการบีบอัด:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

ตัวอย่างต่อไปนี้ใช้ระดับการบีบอัดสูงสุด:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **บันทึกการนำเสนอโดยไม่รีเฟรชภาพย่อ**

เมื่อบันทึกการนำเสนอเป็น PPTX, เมธอด [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) จะควบคุมภาพย่อของเอกสาร:

- `true` สร้างภาพย่อใหม่ระหว่างการบันทึก นี่คือค่าเริ่มต้น
- `false` รักษาภาพย่อที่มีอยู่ หากการนำไม่มีภาพย่อ Aspose.Slides จะไม่สร้างภาพย่อ

ตัวอย่างต่อไปนี้บันทึกการนำเสนอโดยไม่รีเฟรชภาพย่อ:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="หมายเหตุ" %}}
การปิดการรีเฟรชภาพย่อสามารถลดเวลาที่ใช้ในการบันทึกไฟล์ PPTX ได้
{{% /alert %}}

## **อัปเดตความคืบหน้าในการบันทึกเป็นเปอร์เซ็นต์**

เพื่อเฝ้าติดตามกระบวนการบันทึก, จัดหาโปรกซี Java ที่ implements อินเทอร์เฟซ [IProgressCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/) แล้วส่งโปรกซีไปยังเมธอด [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveoptions/#setProgressCallback) Aspose.Slides จะเรียกเมธอด [IProgressCallback::reporting](https://reference.aspose.com/slides/th/java/com.aspose.slides/iprogresscallback/#reporting-double-) พร้อมค่าความคืบหน้าในระหว่างการส่งออก

ตัวอย่างต่อไปนี้แสดงความคืบหน้าของการส่งออก PDF ไปยังคอนโซล:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="หมายเหตุ" %}}
Aspose มีเครื่องมือฟรี [PowerPoint Splitter](https://products.aspose.app/slides/th/splitter) ที่สร้างด้วย API ของ Aspose.Slides มันบันทึกสไลด์ที่เลือกจากการนำเสนอเป็นไฟล์ PPT หรือ PPTX แยกกัน
{{% /alert %}}

## **FAQ**

**Aspose.Slides รองรับการบันทึกแบบ incremental หรือ “fast save” หรือไม่?**

ไม่รองรับ การบันทึกแต่ละครั้งจะเขียนไฟล์เอาต์พุตเต็มแทนการอัปเดตเฉพาะส่วนที่เปลี่ยนแปลง

**หลายเธรดสามารถบันทึกอินสแตนซ์ Presentation เดียวกันได้หรือไม่?**

ไม่ได้ อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) **ไม่ปลอดภัยต่อเธรด** (/slides/th/php-java/multithreading/) ควรเข้าถึงและบันทึกแต่ละอินสแตนซ์จากเธรดเดียวเท่านั้น

**จะเกิดอะไรขึ้นกับไฮเปอร์ลิงก์และไฟล์ที่ลิงก์ภายนอกเมื่อบันทึกการนำเสนอ?**

[Hyperlinks](/slides/th/php-java/manage-hyperlinks/) จะคงอยู่ในการนำเสนอ Aspose.Slides ไม่ทำการคัดลอกไฟล์ที่ลิงก์ภายนอก ดังนั้นการนำเสนอที่บันทึกแล้วยังต้องสามารถเข้าถึงตำแหน่งไฟล์เหล่านั้นได้

**ฉันสามารถบันทึกเมตาดาต้าเอกสาร เช่น ผู้เขียน, ชื่อเรื่อง, บริษัท, และวันที่สร้างได้หรือไม่?**

ได้ ตั้งค่า [document properties](/slides/th/php-java/presentation-properties/) ที่เหมาะสมก่อนบันทึก แล้ว Aspose.Slides จะเขียนข้อมูลเหล่านั้นลงในไฟล์เอาต์พุต