---
title: ดึงและอัปเดตข้อมูลงานนำเสนอใน PHP
linktitle: ข้อมูลงานนำเสนอ
type: docs
weight: 30
url: /th/php-java/examine-presentation/
keywords:
- รูปแบบงานนำเสนอ
- คุณสมบัติงานนำเสนอ
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
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้างและเมตาดาทาในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ PHP เพื่อให้ได้ข้อมูลเชิงลึกที่รวดเร็วและการตรวจสอบเนื้อหาที่ฉลาดขึ้น"
---
## **ภาพรวม**

Aspose.Slides สามารถระบุรูปแบบของงานนำเสนอและอ่านเมทาดาทาเอกสารโดยไม่ต้องสร้างโมเดลอ็อบเจกต์ของงานนำเสนอทั้งหมด ซึ่งมีประโยชน์เมื่อคุณต้องการจัดประเภทไฟล์ สร้างรายการสินค้าคงคลัง หรือสอบถามคุณสมบัติก่อนตัดสินใจว่าจะโหลดและประมวลผลเนื้อหางานนำเสนอหรือไม่.

บทความนี้แสดงการตรวจสอบแบบเบาโดยใช้ [PresentationFactory](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/) และ [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/), รวมถึงการอัปเดตที่เจาะจงผ่าน [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/).

## **ตรวจสอบรูปแบบงานนำเสนอ**

ใช้ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/) เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/). วิธีการ [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#getLoadFormat) รายงานรูปแบบที่ตรวจพบ เช่น PPTX, PPT หรือ ODP.

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

## **สร้างรายการสินค้าคงคลังงานนำเสนอแบบเบา**

เมื่อต้องประมวลผลไฟล์งานนำเสนอจำนวนมาก คุณอาจต้องการรายการสินค้าคงคลังแบบกะทัดรัดสำหรับการตรวจสอบ การทำดัชนี หรือระบบการจัดการเอกสาร ในกรณีนี้ ให้ใช้ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/) เพื่อรับวัตถุ [PresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/) จากนั้นเรียก [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#readDocumentProperties) เพื่ออ่านเมตาดาทาเอกสาร วิธีนี้จะไม่สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) หรือจำเป็นต้องเดินผ่านโมเดลอ็อบเจกต์ของงานนำเสนอทั้งหมด.

คุณสมบัติขยายที่เปิดเผยโดย [DocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/) ให้ค่ารายการสินค้าคงคลังต่อไปนี้:

| วิธีการ | ค่ารายการสินค้าคงคลัง |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getSlides) | จำนวนสไลด์ทั้งหมด. |
| [getHiddenSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getHiddenSlides) | จำนวนสไลด์ที่ซ่อนอยู่. |
| [getNotes](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getNotes) | จำนวนสไลด์ที่มีบันทึกหมายเหตุ. |
| [getParagraphs](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getParagraphs) | จำนวนย่อหน้าทั้งหมด (เมื่อมีข้อมูล). |
| [getWords](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getWords) | จำนวนคำทั้งหมด. |
| [getMultimediaClips](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getMultimediaClips) | จำนวนคลิปเสียงและวิดีโอทั้งหมด. |

ตัวอย่างต่อไปนี้อ่านค่าดังกล่าวโดยไม่สร้างอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) และพิมพ์รายการสินค้าคงคลังแบบกะทัดรัด นอกจากนี้ยังผสาน [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getHeadingPairs) กับ [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getTitlesOfParts) เพื่อแสดงกลุ่มเนื้อหาเช่น ฟอนต์ ธีม และชื่อสไลด์.

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

แต่ละ [HeadingPair](https://reference.aspose.com/slides/th/php-java/aspose.slides/headingpair/) จะให้ชื่อกลุ่มและจำนวนรายการในกลุ่มนั้น [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getTitlesOfParts) คืนค่าเป็นอาร์เรย์แบนเรียงลำดับ ดังนั้นจึงใช้จำนวนชื่อที่ต่อเนื่องตามที่กำหนดโดยแต่ละ heading pair.

### **เมตาดาทาที่บันทึกและข้อจำกัดของรูปแบบ**

คุณสมบัติรายการสินค้าคงคลังที่ส่งกลับโดย [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#readDocumentProperties) สะท้อนเมตาดาทาที่มีอยู่ในเอกสารต้นทาง Aspose.Slides ไม่ได้โหลดและเดินผ่านโมเดลอ็อบเจกต์ของงานนำเสนอเพื่อคำนวณค่าเหล่านี้ใหม่สำหรับการเรียกนี้ คุณสมบัติที่ขาดจะถูกแทนด้วยค่าเริ่มต้น และค่าที่บันทึกอาจล้าสมัยหากแอปพลิเคชันที่บันทึกไฟล์ครั้งสุดท้ายไม่ได้อัปเดตเมตาดาทาเอกสาร

- **PPTX:** รูปแบบนี้ให้คุณสมบัติเอกสารขยายสำหรับจำนวนสไลด์, หมายเหตุ, สไลด์ที่ซ่อน, ย่อหน้า, คำ, และมัลติมีเดีย รวมถึง heading pairs และ part titles ความพร้อมใช้งานขึ้นกับว่าผู้ผลิตเอกสารได้เขียนคุณสมบัติเหล่านี้หรือไม่.
- **PPT:** รูปแบบไบนารีสามารถเก็บคุณสมบัติสรุปเอกสารที่สอดคล้องกันได้ หากคุณสมบัติเช่นนั้นไม่มีหรือไม่ได้รับการรีเฟรชโดยผู้ผลิตเอกสาร Aspose.Slides จะคืนค่าที่บันทึกหรือค่าเริ่มต้นแทนการคำนวณจากสไลด์.
- **ODP:** เมตาดาทา OpenDocument ให้สถิติโดยรวมของเอกสารเช่นจำนวนหน้า, ย่อหน้า, และคำ แต่ค่าดังกล่าวไม่สอดคล้องกับคุณสมบัติขยายของ PowerPoint ทั้งหมด เมตาดาทาเช่น hidden-slide, notes-slide, multimedia, heading-pair, และ part-title อาจไม่มีให้บริการ และคุณสมบัติรายการสินค้าคงคลังอาจคืนค่าเริ่มต้น อย่าพิจารณาค่าศูนย์หรืออาร์เรย์ว่างเป็นหลักฐานที่แน่นอนว่าเนื้อหาที่สอดคล้องไม่มีอยู่.

ใช้วิธีเมตาดาทาแบบเบาสำหรับการสร้างรายการสินค้าคงคลังและการตรวจสอบขั้นต้น โหลดงานนำเสนอและตรวจสอบโมเดลอ็อบเจกต์แบบเรียลไทม์เมื่อผลลัพธ์ต้องสะท้อนการเปลี่ยนแปลงในหน่วยความจำหรือเมื่อคุณต้องการยืนยันเนื้อหาจริงของงานนำเสนอ.

## **อัปเดตคุณสมบัติงานนำเสนอ**

คุณสมบัติที่ส่งกลับโดย [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#readDocumentProperties) สามารถเปลี่ยนแปลงได้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ใช้การเปลี่ยนแปลงด้วย [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#updateDocumentProperties) จากนั้นเขียนงานนำเสนอที่ผูกไว้ด้วย [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#writeBindedPresentation).

ภาพต่อไปนี้แสดงคุณสมบัติเอกสารดั้งเดิมของงานนำเสนอ PowerPoint.

![คุณสมบัติเอกสารดั้งเดิมของงานนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างต่อไปนี้เปลี่ยนชื่อเรื่องและเวลาบันทึกครั้งสุดท้ายและเขียนผลลัพธ์ไปยังไฟล์ใหม่:

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

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของงานนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

สำหรับการตรวจสอบความปลอดภัยที่เกี่ยวข้องและการตั้งค่าการปกป้อง ดูบทความต่อไปนี้:

- [การปกป้องงานนำเสนอด้วยรหัสผ่าน](/slides/th/php-java/password-protected-presentation/)
- [การปกป้องงานนำเสนอจากการเขียน](/slides/th/php-java/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าฟอนต์ถูกฝังและมีฟอนต์ใดบ้าง?**

โหลดงานนำเสนอและใช้ [Presentation::getFontsManager](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getFontsManager). เรียก [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) เพื่อรับฟอนต์ที่ฝังอยู่และ [FontsManager::getFonts](https://reference.aspose.com/slides/th/php-java/aspose.slides/fontsmanager/#getFonts) เพื่อรับฟอนต์ที่ใช้งานในงานนำเสนอ เปรียบเทียบผลลัพธ์สองชุดเพื่อหาฟอนต์ที่จำเป็นสำหรับการเรนเดอร์แต่ไม่ได้ฝังอยู่.

**ฉันจะตรวจสอบอย่างรวดเร็วได้หรือไม่ว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไหร่?**

เมื่อเมตาดาทาเอกสารที่เก็บไว้เพียงพอ ให้อ่าน [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/documentproperties/#getHiddenSlides) ผ่าน [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/) และ [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#readDocumentProperties). วิธีนี้เหมาะสำหรับการสร้างรายการสินค้าคงคลังแบบเบา หากงานนำเสนอถูกแก้ไขในหน่วยความจำ เมตาดาทาที่เก็บอาจหายหรือล้าสมัย หรือคุณต้องการตรวจสอบค่าจริง ให้วนผ่าน [Presentation::getSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSlides) และตรวจสอบแต่ละสไลด์ด้วยวิธี [Slide::getHidden](https://reference.aspose.com/slides/th/php-java/aspose.slides/slide/#getHidden) แทน.

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและแนวตั้งของสไลด์ที่กำหนดเองหรือไม่ และว่ามันแตกต่างจากค่าเริ่มต้นหรือไม่?**

ได้. โหลดงานนำเสนอและเรียก [Presentation::getSlideSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSlideSize). ใช้ [SlideSize::getType](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesize/#getSize) และ [SlideSize::getOrientation](https://reference.aspose.com/slides/th/php-java/aspose.slides/slidesize/#getOrientation) เพื่อเปรียบเทียบการตั้งค่าปัจจุบันกับค่าที่คาดหวังและมิติที่กำหนดไว้.

**มีวิธีที่รวดเร็วในการดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ได้. ค้นหาแต่ละ [Chart](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/) แล้วเรียก [ChartData::getDataSourceType](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#getDataSourceType). สำหรับสมุดงานภายนอก ให้เรียก [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdata/#getExternalWorkbookPath). ประเภทแหล่งข้อมูลและเส้นทางบ่งชี้การอ้างอิงภายนอก แต่การตรวจสอบว่ากลุ่มเป้าหมายพร้อมใช้งานหรือไม่ต้องทำการตรวจสอบแหล่งทรัพยากรแยกต่างหาก.

**ฉันจะประเมินสไลด์ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าลงได้อย่างไร?**

ไม่มีคุณสมบัติจำนวนความซับซ้อนเพียงอย่างเดียว ให้เดินผ่าน [Presentation::getSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSlides) และคอลเลกชัน [BaseSlide::getShapes](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslide/#getShapes) ของแต่ละสไลด์ ใช้จำนวนรูปร่างและการมีภาพขนาดใหญ่, เอฟเฟกต์, แอนิเมชัน หรือมัลติมีเดียเป็นสัญญาณคัดกรอง และทำการวัดการเรนเดอร์หรือการส่งออกตัวอย่างก่อนพิจารณาสไลด์เป็นคอขวดประสิทธิภาพที่ยืนยันแล้ว.