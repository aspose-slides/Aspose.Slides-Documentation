---
title: ดึงและอัปเดตข้อมูลพรีเซนเทชันใน PHP
linktitle: ข้อมูลพรีเซนเทชัน
type: docs
weight: 30
url: /th/php-java/examine-presentation/
keywords:
- รูปแบบพรีเซนเทชัน
- คุณสมบัติพรีเซนเทชัน
- คุณสมบัติเอกสาร
- รับคุณสมบัติ
- อ่านคุณสมบัติ
- เปลี่ยนคุณสมบัติ
- แก้ไขคุณสมบัติ
- อัปเดตคุณสมบัติ
- ตรวจสอบ PPTX
- ตรวจสอบ PPT
- ตรวจสอบ ODP
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- PHP
- Aspose.Slides
description: "สำรวจสไลด์, โครงสร้างและเมตาดาต้าในพรีเซนเทชัน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ PHP เพื่อให้ได้ข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ฉลาดขึ้น"
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของพรีเซนเทชันและอ่านเมตาดาต้าเอกสารโดยไม่ต้องสร้างโมเดลวัตถุพรีเซนเทชันเต็มรูปแบบ ซึ่งเป็นประโยชน์เมื่อคุณต้องการจัดประเภทไฟล์ สร้างสินค้าคงคลัง หรือสอบถามคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหาพรีเซนเทชันหรือไม่.

บทความนี้แสดงการตรวจสอบแบบเบาโดยใช้ [PresentationFactory](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/) และ [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/), พร้อมทั้งการอัปเดตแบบเจาะจงผ่าน [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/).

## **ตรวจสอบรูปแบบพรีเซนเทชัน**

หากคุณมีพรีเซนเทชันที่โหลดไว้แล้ว ให้ดูที่ [กำหนดรูปแบบพรีเซนเทชันต้นฉบับ](/slides/th/php-java/detect-presentation-source-format/) สำหรับการตรวจจับหลังจากโหลดและข้อจำกัดของสตรีม PPT, PPS และ POT รุ่นเก่า.

ใช้ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/) เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) วิธี [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#getLoadFormat) จะรายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **สร้างสินค้าคงคลังพรีเซนเทชันแบบเบา**

เมื่อคุณประมวลผลไฟล์พรีเซนเทชันจำนวนมาก คุณอาจต้องการสินค้าคงคลังแบบกะทัดรัดสำหรับการตรวจสอบ การทำดัชนี หรือระบบจัดการเอกสาร ในสถานการณ์นี้ ให้ใช้ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/) เพื่อรับอ็อบเจกต์ [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/) แล้วเรียก [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#readDocumentProperties) เพื่ออ่านเมตาดาต้าเอกสาร วิธีการนี้ไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) หรือจำเป็นต้องเดินผ่านโมเดลวัตถุพรีเซนเทชันทั้งหมด.

คุณสมบัติเพิ่มเติมที่เปิดเผยโดย [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/) ให้ค่าต่อไปนี้สำหรับสินค้าคงคลัง:

| วิธี | ค่าที่บันทึกในสินค้าคงคลัง |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getSlides) | จำนวนสไลด์ทั้งหมด. |
| [getHiddenSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getHiddenSlides) | จำนวนสไลด์ที่ซ่อนอยู่. |
| [getNotes](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getNotes) | จำนวนสไลด์ที่มีโน้ต. |
| [getParagraphs](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getParagraphs) | จำนวนย่อหน้าทั้งหมด, หากมี. |
| [getWords](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getWords) | จำนวนคำทั้งหมด. |
| [getMultimediaClips](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getMultimediaClips) | จำนวนคลิปเสียงและวิดีโอทั้งหมด. |

ตัวอย่างต่อไปนี้อ่านค่าดังกล่าวโดยไม่สร้างอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และพิมพ์สินค้าคงคลังแบบกะทัดรัด อีกทั้งยังรวม [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getHeadingPairs) กับ [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getTitlesOfParts) เพื่อแสดงกลุ่มเนื้อหาเช่น ฟอนต์ ธีม และชื่อสไลด์.

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

แต่ละ [HeadingPair](https://reference.aspose.com/slides/th/php-java/aspose.slides/headingpair/) ให้ชื่อกลุ่มและจำนวนรายการในกลุ่มนั้น [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getTitlesOfParts) คืนค่าอาเรย์แบนแบบเรียงลำดับ ดังนั้นให้ใช้จำนวนชื่อที่ต่อเนื่องตามที่ระบุโดยแต่ละ heading pair.

### **เมตาดาต้าที่จัดเก็บและข้อจำกัดของรูปแบบ**

คุณสมบัติสินค้าคงคลังที่คืนโดย [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#readDocumentProperties) สะท้อนเมตาดาต้าที่มีอยู่ในเอกสารต้นทาง Aspose.Slides ไม่ได้โหลดและเดินทางผ่านโมเดลวัตถุพรีเซนเทชันเพื่อคำนวณค่าต่าง ๆ ใหม่สำหรับการเรียกนี้ คุณสมบัติที่ไม่มีจะถูกแทนด้วยค่าเริ่มต้น และค่าที่จัดเก็บอาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ครั้งสุดท้ายไม่ได้อัปเดตคุณสมบัติดัชนีเอกสาร

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเพิ่มเติมของเอกสารสำหรับการนับสไลด์, โน้ต, สไลด์ซ่อน, ย่อหน้า, คำและสื่อมัลติมีเดีย รวมถึง heading pairs และ part titles ความพร้อมใช้งานขึ้นอยู่กับว่าคุณสมบัติเหล่านั้นถูกเขียนโดยผู้ผลิตเอกสารหรือไม่
- **PPT:** รูปแบบไบนารีสามารถจัดเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องกันได้ หากคุณสมบัตหาไม่พบหรือไม่ได้รับการรีเฟรชโดยผู้ผลิตเอกสาร Aspose.Slides จะคืนค่าที่จัดเก็บหรือค่าเริ่มต้นแทนการคำนวณจากสไลด์
- **ODP:** เมตาดาต้า OpenDocument ให้สถิติเอกสารทั่วไป เช่น จำนวนหน้า, ย่อหน้าและคำ แต่ค่าดังกล่าวไม่สอดคล้องกับคุณสมบัติเพิ่มเติมของ PowerPoint ทุกอย่าง เมทาดาต้าเกี่ยวกับสไลด์ซ่อน, โน้ตสไลด์, มัลติมีเดีย, heading‑pair และ part‑title อาจไม่มีอยู่และคุณสมบัติสินค้าคงคลังอาจคืนค่าเริ่มต้น อย่าพิจารณาค่า 0 หรืออาเรย์ว่างเป็นหลักฐานแน่นอนที่บ่งชี้เนื้อหาที่สอดคล้องไม่มีอยู่

ใช้วิธีเมตาดาต้าแบบเบาสำหรับสินค้าคงคลังและการตรวจสอบเบื้องต้น โหลดพรีเซนเทชันและตรวจสอบโมเดลวัตถุแบบสดเมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องการยืนยันเนื้อหาพรีเซนเทชันจริง

## **อัปเดตคุณสมบัติของพรีเซนเทชัน**

คุณสมบัติที่คืนโดย [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#readDocumentProperties) สามารถเปลี่ยนได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ใช้การเปลี่ยนแปลงด้วย [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) แล้วเขียนพรีเซนเทชันที่ผูกไว้ด้วย [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

![คุณสมบัติต้นฉบับของพรีเซนเทชัน PowerPoint](input_properties.png)

ตัวอย่างต่อไปนี้เปลี่ยนชื่อเรื่องและเวลาที่บันทึกล่าสุดและเขียนผลลัพธ์ไปยังไฟล์ใหม่:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

![คุณสมบัติที่เปลี่ยนแปลงของพรีเซนเทชัน PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยและการตั้งค่าการปกป้องที่เกี่ยวข้อง ดูบทความต่อไปนี้:

- [ป้องกันพรีเซนเทชันด้วยรหัสผ่าน](/slides/th/php-java/password-protected-presentation/)
- [ป้องกันการเขียนพรีเซนเทชัน](/slides/th/php-java/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าฟอนต์ฝังอยู่หรือไม่และมีฟอนต์ใดบ้าง?**

โหลดพรีเซนเทชันและใช้ [Presentation::getFontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getFontsManager). เรียก [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) เพื่อรับฟอนต์ที่ฝังอยู่และ [FontsManager::getFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#getFonts) เพื่อรับฟอนต์ที่ใช้ในพรีเซนเทชัน เปรียบเทียบผลลัพธ์สองชุดเพื่อหาฟอนต์ที่จำเป็นสำหรับการเรนเดอร์แต่ไม่ได้ฝังอยู่.

**ฉันจะบอกได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไร?**

เมื่อเมตาดาต้าเอกสารที่จัดเก็บเพียงพอ ให้อ่าน [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getHiddenSlides) ผ่าน [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/) และ [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#readDocumentProperties). วิธีนี้เหมาะสำหรับสินค้าคงคลังแบบเบา หากพรีเซนเทชันถูกแก้ไขในหน่วยความจำ เมทาดาต้าอาจหายหรือเก่า หรือคุณต้องการตรวจสอบค่าจริง ให้วนผ่าน [Presentation::getSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSlides) และตรวจสอบเมธอด [Slide::getHidden](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getHidden) ของแต่ละสไลด์แทน.

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและการวางแนวของสไลด์ที่กำหนดเองหรือไม่ และว่าต่างจากค่าตั้งต้นหรือไม่?**

ใช่. โหลดพรีเซนเทชันและเรียก [Presentation::getSlideSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSlideSize). ใช้ [SlideSize::getType](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesize/#getSize) และ [SlideSize::getOrientation](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesize/#getOrientation) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับค่าที่กำหนดไว้ล่วงหน้าและขนาด.

**มีวิธีที่เร็วในการตรวจสอบว่าชาร์ตอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ใช่. ค้นหาแต่ละ [Chart](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/) และเรียก [ChartData::getDataSourceType](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#getDataSourceType). สำหรับเวิร์กบุ๊กภายนอก ให้เรียก [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). ประเภทแหล่งข้อมูลและเส้นทางบ่งบอกถึงการอ้างอิงภายนอก แต่การตรวจสอบว่ามีเป้าหมายอยู่จริงต้องทำการตรวจสอบทรัพยากรแยกต่างหาก.

**ฉันจะประเมินสไลด์ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าได้อย่างไร?**

ไม่มีคุณสมบัติความซับซ้อนเพียงค่าเดียวให้ตรวจสอบ ให้เดินผ่าน [Presentation::getSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSlides) และคอลเลกชัน [BaseSlide::getShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/#getShapes) ของแต่ละสไลด์ ใช้จำนวนรูปร่างและการมีอยู่ของภาพขนาดใหญ่, เอฟเฟกต์, แอนิเมชัน หรือมัลติมีเดียเป็นสัญญาณคัดกรอง และอาจทำการวัดการเรนเดอร์หรือการส่งออกตัวอย่างก่อนที่จะสรุปว่าสไลด์เป็นคอขวดประสิทธิภาพที่ยืนยันได้.