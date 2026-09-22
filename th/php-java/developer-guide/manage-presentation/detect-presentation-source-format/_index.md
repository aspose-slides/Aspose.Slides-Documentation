---
title: กำหนดรูปแบบพรีเซนเทชันต้นฉบับใน PHP
linktitle: รูปแบบแหล่งที่มา
type: docs
weight: 35
url: /th/php-java/detect-presentation-source-format/
keywords:
- รูปแบบแหล่งที่มา
- ตรวจจับรูปแบบพรีเซนเทชัน
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "อ่านรูปแบบดั้งเดิมของพรีเซนเทชันที่โหลดใน PHP ด้วย Aspose.Slides for PHP via Java, เปรียบเทียบ API การตรวจจับ, และจัดการไฟล์, สตรีม, และรูปแบบเก่า."
---
## **ภาพรวม**

หลังจากโหลดไฟล์พรีเซนเทชันแล้ว ให้เรียกเมธอด [Presentation::getSourceFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSourceFormat) เพื่อกำหนดรูปแบบดั้งเดิมของไฟล์ ใช้เมธอดนี้เมื่อการประมวลผลต่อไปต้องอิงรูปแบบที่อินสแตนซ์ปัจจุบันถูกโหลดมาจาก

รูปแบบแหล่งที่มาจะแตกต่างจาก [SaveFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/) ที่เลือกสำหรับไฟล์ผลลัพธ์ การบันทึกเป็นรูปแบบอื่นจะไม่เปลี่ยนรูปแบบแหล่งที่มาของอินสแตนซ์ที่มีอยู่

## **อ่านรูปแบบแหล่งที่มาของไฟล์**

ตัวอย่างนี้ต้องการไฟล์ `sample.pptx` ที่มีอยู่ มันโหลดไฟล์และเลือกนโยบายการประมวลผลของแอปพลิเคชันโดยใช้ [Presentation::getSourceFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSourceFormat) แทนชื่อไฟล์ เปลี่ยนเส้นทางเข้าเพื่อทดสอบรูปแบบอื่น ตัวอย่างจะแสดงนโยบายที่เลือก; ให้แทนที่ข้อความด้วยตรรกะของแอปของคุณ

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **รับรู้ค่าที่รองรับ**

The [SourceFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/sourceformat/) คลาสกำหนดค่าคงที่จำนวนเต็มที่แยกรูปแบบพรีเซนเทชันต่อไปนี้ ส่วนต่อขยายด้านล่างเป็นส่วนต่อขยายแบบทั่วไป ไม่ได้เป็นการสร้างใหม่ของชื่อไฟล์ดั้งเดิม

| ค่า SourceFormat | ส่วนต่อขยาย | รูปแบบ |
| --- | --- | --- |
| `Ppt` | `.ppt` | การนำเสนอ PowerPoint 97–2003 |
| `Pptx` | `.pptx` | การนำเสนอ Office Open XML |
| `Pptm` | `.pptm` | การนำเสนอ Office Open XML ที่เปิดใช้งานแมโคร |
| `Pps` | `.pps` | การแสดงสไลด์ PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | การแสดงสไลด์ Office Open XML |
| `Ppsm` | `.ppsm` | การแสดงสไลด์ Office Open XML ที่เปิดใช้งานแมโคร |
| `Pot` | `.pot` | แม่แบบ PowerPoint 97–2003 |
| `Potx` | `.potx` | แม่แบบ Office Open XML |
| `Potm` | `.potm` | แม่แบบ Office Open XML ที่เปิดใช้งานแมโคร |
| `Odp` | `.odp` | การนำเสนอ OpenDocument |
| `Otp` | `.otp` | แม่แบบการนำเสนอ OpenDocument |
| `Fodp` | `.fodp` | การนำเสนอ Flat XML ODF |
| `Xml` | `.xml` | การนำเสนอ PowerPoint XML |

## **อ่านรูปแบบแหล่งที่มาจากสตรีม**

ตัวอย่างนี้ต้องการไฟล์ `sample.pps` ที่มีอยู่ การอ่านไบต์ของไฟล์เข้าสู่ Memory Stream ทำให้จำลองการรับข้อมูลโดยไม่มีชื่อไฟล์ เช่น ค่าจากฐานข้อมูลหรืออาร์เรย์ไบต์ที่อัปโหลด คอนสตรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) จะรับสตรีมเท่านั้น

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT, PPS, และ POT ใช้รูปแบบไบนารีเดียวกัน เมื่อโหลดโดยใช้เส้นทางไฟล์ ส่วนต่อขยายอาจช่วยแยกการแสดงสไลด์หรือแม่แบบได้ หากไม่มีชื่อไฟล์ เนื้อหา PPS และ POT เก่าอาจรายงานเป็น `SourceFormat::Ppt`; ตัวอย่าง PPS ด้านบนพิมพ์ค่าตัวเลขของ `SourceFormat::Ppt`

หากแอปของคุณต้องการรักษาความแตกต่างนี้ ควรเก็บชื่อไฟล์ดั้งเดิมหรือเมทาดาทา subtype แยกต่างหาก ส่วนต่อขยายเป็นบ่งชี้ที่เป็นประโยชน์สำหรับ subtype เก่าเหล่านี้ แต่ไม่ควรใช้เป็นเกณฑ์หลักเดียวในการระบุเนื้อหาพรีเซนเทชันใด ๆ

## **เปรียบเทียบการตรวจจับก่อนและหลังการโหลด**

ใช้ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/#getPresentationInfo) และ [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationinfo/#getLoadFormat) เมื่อจำเป็นต้องตรวจสอบไฟล์ก่อนโหลดโมเดลอ็อบเจกต์พรีเซนเทชันเต็มรูปแบบ ใช้ [Presentation::getSourceFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSourceFormat) เมื่อตัวอินสแตนซ์มีอยู่แล้ว

ตัวอย่างนี้ต้องการ `sample.pptx` และพิมพ์ค่าตัวเลขของ `LoadFormat::Pptx` และ `SourceFormat::Pptx` ตามลำดับ ในการผลิต ให้เลือก API ที่เหมาะกับขั้นตอนการประมวลผลของคุณ; พรีเซนเทชันที่โหลดแล้วไม่จำเป็นต้องตรวจสอบสองครั้งเพื่อรับค่าแหล่งที่มา

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

ผลลัพธ์ใช้ค่าคงที่จากคลาสที่ต่างกัน: [LoadFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadformat/) และ [SourceFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/sourceformat/) อย่าเทียบค่าตัวเลขของพวกมันหรือสมมติว่าทุกรูปแบบมีผลการตรวจจับที่เหมือนกัน PowerPoint XML อาจรายงานเป็น `LoadFormat::Unknown` ก่อนโหลดและ `SourceFormat::Xml` หลังโหลด

## **แยกรูปแบบแหล่งที่มาและรูปแบบผลลัพธ์ออกจากกัน**

ตัวอย่างนี้ต้องการ `sample.pptx` และเขียนไฟล์ `converted.odp` มันพิมพ์ค่าตัวเลขของ `SourceFormat::Pptx` ทั้งก่อนและหลังบันทึกอินสแตนซ์ต้นฉบับ อินสแตนซ์ใหม่ที่โหลดจากผลลัพธ์ ODP จะรายงาน `Odp`

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

พรีเซนเทชันที่สร้างจากศูนย์ด้วย `new Presentation()` จะรายงาน `SourceFormat::Pptx` เนื่องจากไม่มีไฟล์เข้า: นี้เป็นค่าตั้งต้นสำหรับอินสแตนซ์ที่สร้างใหม่ ไม่ได้หมายความว่าไฟล์ PPTX ถูกโหลด ติดตามว่าแอปของคุณสร้างหรือโหลดอินสแตนซ์แยกต่างหากหากความแตกต่างนี้สำคัญ

## **แมปรูปแบบแหล่งที่มาเป็นส่วนต่อขยาย**

ตัวอย่างต่อไปนี้ต้องการ `sample.pptx` มันแมปค่าของ [SourceFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/sourceformat/) ที่สนับสนุนในปัจจุบันทุกค่าเป็นส่วนต่อขยายแบบทั่วไป โดยไม่ต้องพาร์สชื่อไฟล์อินพุต การสำรองจะป้องกันการกำหนดส่วนต่อขยายให้กับค่าที่ไม่รู้จักโดยเงียบ ๆ

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

การแมปนี้ไม่ได้แปลงไฟล์หรือกู้คืน subtype PPS/POT เก่าที่หายไประหว่างการโหลดสตรีม สำหรับการบันทึกจริง ให้เลือก [SaveFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveformat/) อย่างชัดเจน หรือใช้การแปลงที่แสดงใน [Save Presentations in Their Original Format](/slides/th/php-java/save-presentation/#save-presentations-in-their-original-format)

## **ตรวจสอบรูปแบบโดยการบันทึกและเปิดใหม่**

ตัวอย่างอิสระนี้สร้างพรีเซนเทชันและเขียนไฟล์สามไฟล์ในไดเรกทอรีทำงาน โดยเขียนทับไฟล์ที่มีชื่อเดียวกัน มันเปิดแต่ละไฟล์ผลลัพธ์ใหม่ทั้งโดยเส้นทางและผ่าน Memory Stream สำหรับ PPTX และ ODP ทั้งสองวิธีรายงานรูปแบบที่บันทึกไว้ สำหรับ PPS การโหลดโดยเส้นทางรายงาน `Pps` ส่วนการโหลดไบต์เดียวกันโดยไม่มีชื่อไฟล์รายงาน `Ppt`

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

ตารางต่อไปสรุปการระบุรูปแบบแหล่งที่มาสำหรับพรีเซนเทชันที่มีส่วนต่อขยายตรงกัน ชื่อแสดงค่าคงที่; ตัวอย่าง PHP พิมพ์ค่าตัวเลขของมัน:

| รูปแบบที่บันทึก | SourceFormat จากเส้นทางไฟล์ | SourceFormat จากสตรีมไม่มีชื่อ |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | เช่นเดียวกับไฟล์เส้นทาง |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | เช่นเดียวกับไฟล์เส้นทาง |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | เช่นเดียวกับไฟล์เส้นทาง |
| ODP, OTP | `Odp`, `Otp` respectively | เช่นเดียวกับไฟล์เส้นทาง |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

เนื้อหา PPS/POT จะระบุเป็น `Ppt` สำหรับสตรีมที่ไม่มีชื่อ ตารางอธิบายการระบุรูปแบบ ไม่ได้หมายถึงการคงลักษณะทุกอย่างของพรีเซนเทชันในการแปลง

## **คำถามที่พบบ่อย**

**การบันทึกเป็น ODP ทำให้รูปแบบแหล่งที่มาของพรีเซนเทชันที่โหลดจาก PPTX เปลี่ยนหรือไม่?**

ไม่. อินสแตนซ์ที่มีอยู่ยังคงรายงาน `Pptx`. อินสแตนซ์ที่โหลดจากไฟล์ ODP ที่บันทึกไว้รายงาน `Odp`.

**สตรีมสามารถแยกความแตกต่างระหว่างพรีเซนเทชันเก่า, การแสดงสไลด์และแม่แบบได้เสมอหรือไม่?**

ไม่. PPT, PPS, และ POT ใช้รูปแบบไบนารีเดียวกัน เก็บชื่อไฟล์หรือเมทาดาทา subtype แยกต่างหากเมื่อจำเป็น

**ควรใช้ API ใดเมื่อพรีเซนเทชันโหลดแล้ว?**

อ่าน [Presentation::getSourceFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#getSourceFormat) ใช้ [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentationfactory/#getPresentationInfo) สำหรับการตรวจสอบก่อนโหลด