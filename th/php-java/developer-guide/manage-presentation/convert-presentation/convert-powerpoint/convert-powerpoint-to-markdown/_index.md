---
title: แปลงการนำเสนอ PowerPoint เป็น Markdown ใน PHP
linktitle: PowerPoint เป็น Markdown
type: docs
weight: 140
url: /th/php-java/convert-powerpoint-to-markdown/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น MD
- การนำเสนอเป็น MD
- สไลด์เป็น MD
- PPT เป็น MD
- PPTX เป็น MD
- บันทึก PowerPoint เป็น Markdown
- บันทึกการนำเสนอเป็น Markdown
- บันทึกสไลด์เป็น Markdown
- บันทึก PPT เป็น MD
- บันทึก PPTX เป็น MD
- ส่งออก PPT เป็น MD
- ส่งออก PPTX เป็น MD
- การส่งออกรูปภาพ Markdown
- ลิงก์รูปภาพ CDN
- PowerPoint
- การนำเสนอ
- Markdown
- PHP
- Aspose.Slides
description: "แปลงการนำเสนอ PPT และ PPTX เป็น Markdown ใน PHP และควบคุมตำแหน่งที่บันทึกและอ้างอิงรูปภาพ bitmap, metafile และ SVG ที่ส่งออก."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java สามารถแปลงการนำเสนอ PPT และ PPTX เป็น Markdown เพื่อใช้ในงานเอกสาร, เว็บไซต์แบบสแตติก, การย้ายเนื้อหา, และกระบวนการควบคุมเวอร์ชันได้ คุณสามารถเลือกรูปแบบ Markdown, ควบคุมวิธีการเรนเดอร์เนื้อหาในสไลด์, และกำหนดตำแหน่งที่เก็บรูปภาพที่ส่งออกและวิธีที่ Markdown ที่สร้างขึ้นอ้างอิงรูปเหล่านั้น

โดยค่าเริ่มต้น การส่งออก Markdown จะใช้ผลลัพธ์เป็นข้อความเท่านั้น เพื่อส่งออกเนื้อหาภาพ ให้ตั้งค่าประเภทการส่งออกด้วยเมธอด [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/) เป็นค่า `Sequential` หรือ `Visual` จาก enumeration [MarkdownExportType](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownexporttype/) `Sequential` จะเรนเดอร์รายการสไลด์แยกกันและตามลำดับ ในขณะที่ `Visual` จะคงกลุ่มรายการไว้ด้วยกันเพื่อรักษาความสัมพันธ์เชิงภาพค่า `TextOnly` จะไม่สร้างทรัพยากรรูปภาพ ดังนั้นคอลแบ็กการบันทึกรูปภาพจะไม่ถูกเรียกในโหมดนั้น

## **แปลงการนำเสนอเป็น Markdown**

โหลดไฟล์ต้นทางด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) แล้วเรียกเมธอด [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ด้วยค่า `Md` จาก enumeration [SaveFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/)

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **เลือกรูปแบบ Markdown**

เมธอด [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/) ควบคุมสเปค Markdown ที่ใช้สำหรับผลลัพธ์ enumeration [Flavor](https://reference.aspose.com/slides/th/php-java/aspose.slides/flavor/) มี CommonMark, GitHub Flavored Markdown, และรูปแบบที่รองรับอื่น ๆ

ตัวอย่างต่อไปนี้ส่งออกการนำเสนอเป็น CommonMark:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **ส่งออกรูปภาพโดยใช้พฤติกรรมการบันทึกแบบโลคัลเริ่มต้น**

คลาส [MarkdownSaveOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/) มีเมธอดสองตัวสำหรับกำหนดการบันทึกรูปภาพแบบโลคัล:

- [setBasePath](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/) ระบุไดเรกทอรีฐานสำหรับเอกสาร Markdown และทรัพยากรของมัน
- [setImagesSaveFolderName](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/) ระบุโฟลเดอร์ย่อยของรูปภาพ ค่าปริยายคือ `Images`

ตัวอย่างต่อไปนี้เรนเดอร์เนื้อหาภาพ, เขียนรูปภาพไปที่ `output/assets`, และสร้างการอ้างอิงรูปภาพแบบ relative ในเอกสาร Markdown:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

พฤติกรรมนี้ยังทำหน้าที่เป็นการสำรองเมื่อคอลแบ็กการบันทึกรูปภาพที่กำหนดเองคืนค่า `false`

## **กำหนดการบันทึกรูปภาพและลิงก์ Markdown**

ใช้เมธอด [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/) เพื่อลงทะเบียนคอลแบ็กสำหรับทรัพยากร bitmap และ metafile ที่ไม่ใช่ SVG ที่ถูกสร้างระหว่างการส่งออก Markdown คอลแบ็ก `MarkdownImageSavingHandler` จะรับอ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/), ค่า [ImageFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/imageformat/), และลิงก์ Markdown ที่สร้างขึ้นเป็นอาร์เรย์ Java ที่มีหนึ่งองค์ประกอบ ให้บันทึกหรืออัปโหลดรูปภาพพร้อมรูปแบบที่ระบุ และแทนที่ `$link[0]` ด้วยลิงก์ที่ควรปรากฏในผลลัพธ์ Markdown

ทรัพยากรที่ถูกสร้างในรูปแบบ SVG จะถูกจัดการแยกต่างหาก ลงทะเบียนคอลแบ็กด้วยเมธอด [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/) คอลแบ็ก `MarkdownSvgImageSavingHandler` จะรับอ็อบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/isvgimage/) และอาร์เรย์ Java `$link` ที่มีหนึ่งองค์ประกอบ SVG ไม่มีอาร์กิวเมนต์ `ImageFormat` ให้เขียนหรืออัปโหลดข้อมูล XML จากเมธอด [ISvgImage::getSvgData](https://reference.aspose.com/slides/th/php-java/aspose.slides/isvgimage/) แทน ขึ้นอยู่กับโหมดการส่งออกและการจัดกลุ่มเชิงภาพ SVG ในการนำเสนออาจถูกแปลงเป็น raster หรือรวมกับเนื้อหาอื่น; ทรัพยากรที่ไม่ใช่ SVG ที่ได้จะถูกส่งต่อให้คอลแบ็กการบันทึกรูปภาพ ลงทะเบียนคอลแบ็กทั้งสองเมื่อทรัพยากรภาพทุกอย่างต้องการการประมวลผลแบบกำหนดเอง

ใน PHP via Java ให้ทำคอลแบ็กแต่ละรายการในคลาส PHP และใช้ `java_closure` เพื่อเปิดเผยอ็อบเจกต์นั้นเป็นอินเทอร์เฟซ Java ที่สอดคล้องกัน

{{% alert color="info" title="Note" %}}
Initialize the PHP/Java Bridge with `JAVA_PREFER_VALUES` enabled before loading `Java.inc`. The [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) method returns `void`, and the bridge's default stream mode cannot invoke a PHP callback during that queued call. The complete example below includes the required initialization.
{{% /alert %}}

ค่าที่คอลแบ็กคืนจะกำหนดว่าผู้ใดจะประมวลผลรูปภาพ:

- คืนค่า `true` หลังจากคอลแบ็กบันทึก, อัปโหลด, แปลงหรือประมวลผลรูปภาพและกำหนดค่าที่ถูกต้องให้กับ `$link[0]` Aspose.Slides จะเขียนค่านั้นลงในเอกสาร Markdown และไม่ทำการบันทึกแบบโลคัลเริ่มต้น
- คืนค่า `false` ให้ Aspose.Slides บันทึกรูปภาพแบบโลคัลและสร้างลิงก์ตามค่าที่ตั้งด้วย [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/) และ [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/)

{{% alert color="warning" title="Important" %}}
A handler that returns `true` takes responsibility for the image. If it returns `true` without assigning a valid, nonempty link, the export fails with an `InvalidOperationException`.
{{% /alert %}}

### **บันทึกรูปภาพไปยังไดเรกทอรีต้นฉบับ CDN และใช้ URL ภายนอก**

ตัวอย่างต่อไปนี้ถือ `cdn-origin/presentations/quarterly-report` เป็นไดเรกทอรีต้นฉบับ CDN ที่ถูกเมานท์หรือซิงโครไนซ์ คอลแบ็กแต่ละรายการดึงชื่อไฟล์ที่สร้าง, บันทึกรูปภาพไปยังไดเรกทอรีที่กำหนดเอง, และแทนที่การอ้างอิงโลคัลที่สร้างด้วย URL สาธารณะของ CDN ตัวอย่างไม่ได้ทำการอัปโหลดผ่านเครือข่าย: URL จะเป็นค่าที่ใช้ได้เมื่อไดเรกทอรีถูกเมานท์เป็นต้นฉบับ CDN หรือไฟล์ถูกเผยแพร่ไปยัง CDN สำหรับการจัดเก็บอ็อบเจกต์ ให้แทนที่การเขียนไฟล์ระบบด้วยการอัปโหลดของ SDK storage และกำหนด `$link[0]` หลังจากอัปโหลดสำเร็จ

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

คอลแบ็ก bitmap ตั้งใจคืนค่า `false` สำหรับรูปภาพที่มีขนาดเล็กกว่า 128 × 128 พิกเซล ดังนั้น Aspose.Slides จะบันทึกรูปภาพเหล่านั้นไปยัง `output/fallback-images` ด้วยพฤติกรรมเริ่มต้น bitmap และ metafile ขนาดใหญ่ รวมถึงทรัพยากร SVG จะถูกจัดการโดยโค้ดกำหนดเอง ตัวอย่างเช่น การอ้างอิงโลคัลที่สร้างเช่น `fallback-images/image1.png` จะกลายเป็น `https://cdn.example.com/presentations/quarterly-report/image1.png` คอลแบ็กใช้เส้นทางของระบบปฏิบัติการเฉพาะเมื่อเขียนไฟล์; ลิงก์ที่เขียนใน Markdown จะใช้เครื่องหมายทับหน้า `/` และชื่อไฟล์ที่ถูก escape ตาม URL ใช้กฎเดียวกันเมื่อต้องสร้างลิงก์ relative: ใช้ `/` ไม่ใช่ตัวคั่นไดเรกทอรีของแพลตฟอร์ม

## **คำถามที่พบบ่อย**

**คอลแบ็กตัวเดียวสามารถประมวลผลทั้งรูป raster และ SVG ได้หรือไม่?**

ไม่ได้ ใช้ [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/) สำหรับทรัพยากร bitmap และ metafile ที่ส่งออก และ [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/) สำหรับทรัพยากรที่ส่งออกเป็น SVG ตัวแรกให้อ็อบเจกต์ [IImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/iimage/) และค่า [ImageFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/imageformat/) ส่วนตัวหลังให้อ็อบเจกต์ [ISvgImage](https://reference.aspose.com/slides/th/php-java/aspose.slides/isvgimage/) ที่สามารถอ่านข้อมูล SVG ได้ด้วย [ISvgImage::getSvgData](https://reference.aspose.com/slides/th/php-java/aspose.slides/isvgimage/) SVG ต้นทางที่ถูก rasterize ระหว่างการส่งออกจะถูกประมวลผลโดยคอลแบ็กการบันทึกรูปภาพแทน

**เกิดอะไรขึ้นเมื่อคอลแบ็กการบันทึกรูปภาพคืนค่า `false`?**

Aspose.Slides จะใช้พฤติกรรมการบันทึกแบบโลคัลเริ่มต้น ตำแหน่งรูปภาพและการอ้างอิงที่สร้างขึ้นจะถูกควบคุมโดยค่าที่ตั้งด้วย [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/) และ [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/th/php-java/aspose.slides/markdownsaveoptions/)

**คอลแบ็กสามารถให้ URL โดยไม่บันทึกรูปภาพโลคัลได้หรือไม่?**

ได้ คอลแบ็กสามารถอัปโหลดรูปภาพไปยัง object storage หรือส่งต่อให้บริการอื่น, กำหนด URL ที่ได้ให้กับ `$link[0]` แล้วคืนค่า `true` คอลแบ็กต้องทำการประมวลผลเอง; การคืนค่า `true` จะป้องกันการบันทึกแบบโลคัลเริ่มต้น

**ทำไมการส่งออก Markdown จึงโยน `InvalidOperationException` จากคอลแบ็ก?**

เกิดจากคอลแบ็กคืนค่า `true` แต่ไม่ได้ให้ลิงก์ที่ถูกต้อง ให้กำหนดเส้นทาง relative หรือ URL ภายนอกที่ควรเขียนลงใน Markdown ก่อนคืนค่า `true`

**ลิงก์รูปภาพควรใช้ตัวคั่นเส้นทางแบบใด?**

ใช้เครื่องหมายทับหน้า `/` ในลิงก์ Markdown และ URL ใช้ `DIRECTORY_SEPARATOR` เฉพาะสำหรับเส้นทางของระบบไฟล์ แล้วสร้างหรือตรวจสอบลิงก์ Markdown แยกต่างหาก

**ลิงก์ไฮเปอร์เท็กซ์ถูกเก็บไว้ระหว่างการส่งออก Markdown หรือไม่?**

ใช่ ข้อความ [hyperlinks](/slides/th/php-java/manage-hyperlinks/) จะถูกเก็บเป็นลิงก์ Markdown ปกติ สไลด์ [transitions](/slides/th/php-java/slide-transition/) และ [animations](/slides/th/php-java/powerpoint-animation/) จะไม่ถูกแปลง

**สามารถแปลงการนำเสนอเป็น Markdown แบบขนานได้หรือไม่?**

คุณสามารถประมวลผลไฟล์การนำเสนอหลายไฟล์พร้อมกันได้ แต่ไม่ควรแชร์ออบเจกต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ระหว่างเธรด ปฏิบัติตาม [multithreading guidelines](/slides/th/php-java/multithreading/) และใช้ออบเจกต์แยกสำหรับแต่ละไฟล์