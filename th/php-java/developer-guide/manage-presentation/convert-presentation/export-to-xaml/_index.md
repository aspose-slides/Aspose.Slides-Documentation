---
title: ส่งออกงานนำเสนอเป็น XAML ใน PHP
linktitle: งานนำเสนอเป็น XAML
type: docs
weight: 30
url: /th/php-java/export-to-xaml/
keywords:
- ส่งออก PowerPoint
- ส่งออก OpenDocument
- ส่งออกงานนำเสนอ
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- PowerPoint เป็น XAML
- OpenDocument เป็น XAML
- งานนำเสนอเป็น XAML
- PPT เป็น XAML
- PPTX เป็น XAML
- ODP เป็น XAML
- บันทึก PPT เป็น XAML
- บันทึก PPTX เป็น XAML
- บันทึก ODP เป็น XAML
- ส่งออก PPT เป็น XAML
- ส่งออก PPTX เป็น XAML
- ส่งออก ODP เป็น XAML
- PHP
- Aspose.Slides
description: "แปลงสไลด์ PowerPoint และ OpenDocument เป็น XAML ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java — โซลูชันที่รวดเร็ว ไม่มี Office แต่คงรูปแบบการจัดวางของคุณไว้ครบถ้วน"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการส่งออกงานนำเสนอ PowerPoint ไปเป็น XAML โดยใช้ Aspose.Slides รวมถึงการแนะนำสั้น ๆ เกี่ยวกับ XAML แสดงวิธีการบันทึกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น และสาธิตวิธีการปรับแต่งการส่งออกผ่าน [XamlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/) รวมถึงการส่งออกสไลด์ที่ซ่อนอยู่ บทความยังตอบคำถามที่พบบ่อยบางข้อเกี่ยวกับฟอนท์สำรอง ความเข้ากันได้ของสแตก XAML และพฤติกรรมการส่งออกสไลด์ที่ซ่อนอยู่

## **เกี่ยวกับ XAML**

XAML เป็นภาษามาร์กอัปที่อิง XML ใช้อธิบายส่วนต่อประสานผู้ใช้ในเฟรมเวิร์กต่าง ๆ เช่น WPF (Windows Presentation Foundation) UWP (Universal Windows Platform) และ Xamarin.Forms

คุณสามารถทำงานกับไฟล์ XAML ในตัวออกแบบภาพหรือเขียนและแก้ไขมาร์กอัปโดยตรง

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกเริ่มต้น**

ตัวอย่าง PHP ด้านล่างแสดงวิธีการส่งออกงานนำเสนอเป็น XAML ด้วยการตั้งค่าเริ่มต้น เริ่มต้น PHP Java Bridge และโหลด `aspose.slides.php` ก่อนรันตัวอย่างในบทความนี้ วางไฟล์ `pres.pptx` ในไดเรกทอรีทำงานของเซิร์ฟเวอร์ Java Bridge หรือระบุเส้นทางเต็มที่เซิร์ฟเวอร์เข้าถึงได้

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

โดยค่าเริ่มต้น สไลด์ที่ส่งออกจะถูกบันทึกในโฟลเดอร์ย่อย `pres` ของไดเรกทอรีทำงานปัจจุบันของเซิร์ฟเวอร์ Java Bridge โฟลเดอร์จะสร้างอัตโนมัติ และรูปภาพที่ต้องการจะถูกบันทึกไว้ที่นั่นด้วย

ชื่อโฟลเดอร์ผลลัพธ์จะถูกนำมาจากชื่อไฟล์ต้นฉบับโดยไม่มีส่วนขยาย สำหรับ `pres.pptx` ไฟล์ผลลัพธ์จะมีชื่อ `pres/Slide_1.xaml` `pres/Slide_2.xaml` เป็นต้น แม้ว่าคุณจะระบุเส้นทางเต็มให้กับงานนำเข้าก็ตาม โฟลเดอร์ผลลัพธ์จะสร้างสัมพันธ์กับไดเรกทอรีทำงานปัจจุบันของเซิร์ฟเวอร์ Java Bridge ไม่ได้อยู่คู่กับไฟล์ต้นฉบับ

## **ส่งออกงานนำเสนอเป็น XAML ด้วยตัวเลือกที่กำหนดเอง**

ใช้อินเตอร์เฟส [IXamlOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ixamloptions/) เพื่อควบคุมวิธีที่ Aspose.Slides ส่งออกงานนำเสนอเป็น XAML

เพื่อบันทึกผลลัพธ์ไปยังตำแหน่งที่กำหนดเอง ให้จัดเตรียมพร็อกซี Java ที่ดำเนินการตาม [IXamlOutputSaver](https://reference.aspose.com/slides/th/java/com.aspose.slides/ixamloutputsaver/) แล้วส่งอินสแตนซ์ของการดำเนินการของคุณไปยังเมธอด [setOutputSaver](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/#setOutputSaver) ของ [XamlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/)

เพื่อรวมสไลด์ที่ซ่อนอยู่ในผลลัพธ์ XAML ให้เรียก [setExportHiddenSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) ด้วยค่า `true` ตามตัวอย่าง PHP ด้านล่าง

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **เก็บรวบรวมศิลปะ XAML ที่สร้างทั้งหมด**

การส่งออก XAML สามารถสร้างเอกสาร XAML แยกแต่ละสไลด์พร้อมกับรูปภาพและทรัพยากรสนับสนุนอื่น ๆ ให้กำหนด [IXamlOutputSaver](https://reference.aspose.com/slides/th/java/com.aspose.slides/ixamloutputsaver/) ของคุณเองกับ [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/#setOutputSaver) เพื่อรับศิลปะเหล่านี้แทนการใช้ตัวเก็บไฟล์ระบบเริ่มต้น เริ่มการส่งออกด้วยเมธอด overload ของ [Presentation::save](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/#save) ที่รับ XAML options

ฟังก์ชัน `java_closure` ของ PHP Java Bridge ทำให้วัตถุ PHP ปรากฏเป็นอินเตอร์เฟส Java รักษาวัตถุ saver PHP และพร็อกซีของมันให้อยู่รอดจนการส่งออกเสร็จสมบูรณ์ ลิงก์อินเตอร์เฟสชี้ไปยัง API Java ที่พร็อกซีดำเนินการ

### **ทำความเข้าใจวงจรชีวิตของ Callback**

ตัวส่งออกเรียก [IXamlOutputSaver::save](https://reference.aspose.com/slides/th/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) แยกกันสำหรับศิลปะแต่ละรายการที่สร้าง:

- `path` ระบุศิลปะและอาจมีไดเรกทอรีสัมพันธ์ รักษาข้อมูลนี้ไว้เพราะ XAML อาจอ้างอิงทรัพยากรด้วยเส้นทางสัมพันธ์
- `data` มีไบต์ของศิลปะ รูปภาพและทรัพยากรไบนารีอื่น ๆ ต้องไม่ถูกแปลงเป็นข้อความ
- ตัว saver มีหน้าที่เก็บหรือคงข้อมูลก่อนคืนค่า ตัวอย่างแปลงอาร์เรย์ไบต์ของ Java เป็นสตริงไบนารีของ PHP ที่เป็นของแอปพลิเคชัน
- พิจารณาการส่งออกสำเร็จก็ต่อเมื่อเมธอดบันทึกงานนำเสนอคืนค่าและทุก callback ทำงานสำเร็จ อย่าเก็บข้อผิดพลาดของการจัดเก็บหรือเริ่มการเขียนในพื้นหลังโดยไม่ตรวจสอบ หากการคงข้อมูลเกิดภายหลัง ให้รายงานความสำเร็จโดยรวมหลังจากขั้นตอนนั้นสำเร็จเช่นกัน

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) ยังทำงานกับ saver ที่กำหนดเอง การตั้งค่าเริ่มต้น `false` จะไม่รวมเอกสาร XAML ของสไลด์ที่ซ่อนอยู่ การตั้งค่า `true` จะรวมสไลด์เหล่านั้นและทรัพยากรที่จำเป็นสำหรับการส่งออก จำนวนทรัพยากรขึ้นกับงานนำเสนอ; อย่าสมมติว่าแต่ละสไลด์มี callback หนึ่งครั้งหรือเรียงลำดับคงที่

### **ส่งออกไปยังหน่วยความจำและตรวจสอบศิลปะ**

ตัวอย่างเต็มนี้โหลด `pres.pptx` เก็บศิลปะทั้งหมดในอาร์เรย์เชิงสัมพันธ์ของสตริงไบนารีของ PHP และพิมพ์ชื่อ ประเภท และจำนวนไบต์โดยคงชื่อที่ให้มาไว้เหมือนเดิม ชื่อซ้ำทำให้การเก็บเป็นแบบไม่ถูกต้องแทนการเขียนทับศิลปะอย่างเงียบ ตัวอย่างจะตรวจสอบเรื่องนี้ก่อนใช้ผลลัพธ์

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // เฉพาะ XAML เท่านั้นที่ถือเป็นข้อความ UTF-8 สำหรับการตรวจสอบแบบเลือก.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

การตรวจสอบส่วนต่อขยายเป็นประโยชน์สำหรับการตรวจสอบ; เก็บศิลปะทั้งหมดรวมถึงประเภททรัพยากรที่ไม่คุ้นเคย อย่าแก้ไขไบต์เมื่อจัดเก็บหรือส่งออก สตริง PHP สามารถเก็บข้อมูลไบนารีรวมทั้งไบต์ศูนย์ได้ พิจารณาสตริงเป็นข้อความ UTF-8 เท่านั้นเมื่อตรวจสอบ XAML; ไม่ต้องแปลงไบต์ของรูปภาพหรือทรัพยากร

### **บรรจุศิลปะที่เก็บรวบรวมในไฟล์ ZIP**

ตัวอย่างอิสระนี้เก็บศิลปะการส่งออก ตรวจสอบชื่อ และเขียนไบต์ดั้งเดิมลงในไฟล์ ZIP ตัวไดเรกทอรีงานที่สร้างขึ้นเฉพาะแยกงานส่งออกที่ทำพร้อมกัน ตัวอย่างนี้ต้องใช้ส่วนขยาย PHP Phar ที่สนับสนุน ZIP รายการ ZIP ใช้เครื่องหมายทับหน้าและคงไดเรกทอรีสัมพันธ์ ชื่อที่ไม่ปลอดภัยหรือชื่อที่ชนกันหลังการทำให้เป็นมาตรฐานจะทำให้แพคเกจทั้งหมดถูกปฏิเสธก่อนเขียน

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

ตัวอย่างใช้ [PharData](https://www.php.net/manual/en/class.phardata.php) เพื่อเขียนไฟล์ ZIP หนึ่งไฟล์ในไดเรกทอรีทำงานของกระบวนการ PHP; ตัวส่งออกเองไม่เขียนไฟล์ XAML หรือรูปภาพแยกต่างหาก สำหรับการจัดเก็บระยะไกล ให้แทนที่ขั้นตอนการเขียนไฟล์ด้วยการอัปโหลดสตริงไบนารีที่เก็บรวบรวม ใช้ตัวระบุงานส่งออกบวกกับชื่อศิลปะสัมพันธ์เต็มเป็นคีย์ blob หรือเก็บตัวระบุงาน ชื่อสัมพันธ์ และข้อมูลไบนารีในแถวฐานข้อมูล เผยแพร่งานหลังจากอัปโหลดทั้งหมดเสร็จหรือการทำธุรกรรมฐานข้อมูลคอมมิท ทำความสะอาดผลลัพธ์บางส่วนหากการคงข้อมูลล้มเหลว

สำหรับงานนำเสนอขนาดใหญ่ saver ที่กำหนดเองอาจคงแต่ละศิลปะโดยตรงไปยังที่เก็บของแอปพลิเคชันเพื่อหลีกเลี่ยงการเก็บสำเนาเพิ่มเติมของการส่งออกทั้งหมดในหน่วยความจำของแอปพลิเคชัน รักษาแต่ละ callback ให้เป็นแบบ synchronous จากมุมมองของผู้ส่งออก: คืนค่าเฉพาะหลังจากปลายทางยอมรับไบต์และให้ข้อผิดพลาดถึงผู้เรียกใช้

### **คงชื่อทรัพยากรและตรวจสอบการอ้างอิง**

- ทำให้ตัวแบ่งพาธเป็นมาตรฐานเมื่อต้องการที่ปลายทาง แต่คงไดเรกทอรีสัมพันธ์ อย่าใช้เพียง [basename](https://www.php.net/manual/en/function.basename.php) เว้นแต่ทุกชื่อที่สร้างขึ้นจะเป็นเอกลักษณ์และการอ้างอิงทรัพยากรยังคงถูกต้อง
- ใช้การตรวจสอบชื่อที่เจาะจงปลายทาง เมื่อเขียนไฟล์แยก ให้ปฏิเสธพาธที่เป็นรากหรือส่วน traversal แก้เส้นทางปลายทางเป็นพาธเต็มและตรวจสอบให้แน่ใจว่าอยู่ใต้ไดเรกทอรีส่งออกที่กำหนด รวมเครื่องหมายแบ่งไดเรกทอรีในตรวจสอบ containment ใช้ไดเรกทอรีที่แอปพลิเคชันควบคุมโดยไม่มีลิงก์สัญลักษณ์ที่อาจเปลี่ยนเส้นทางการเขียน
- ใช้ saver และเนมสเปซการจัดเก็บแยกสำหรับแต่ละงานส่งออก ตรวจจับการชนกันหลังทำให้ตัวแบ่งเป็นมาตรฐานและตามกฎความไวต่อขนาดอักษรของปลายทาง
- ก่อนเผยแพร่ ให้พาร์สแต่ละเอกสาร XAML เป็น XML และตรวจสอบการอ้างอิงทรัพยากรแบบไฟล์ เช่น แอตทริบิวต์ `Source` หรือ `ImageSource` ของรูปภาพ แก้ URIสัมพันธ์โดยอ้างอิงไดเรกทอรีของศิลปะ XAML นั้น ปรับชื่อที่จัดเก็บให้เป็นมาตรฐานและยืนยันว่าคีย์แผนที่, รายการ ZIP หรือออบเจ็กต์ที่เก็บมีอยู่ พิจารณา URI ภายนอกและนิพจน์มาร์กอัป XAML แยกจากชื่อไฟล์สัมพันธ์

ตัวอย่างเช่น หาก `pres/Slide_1.xaml` อ้างอิง `images/image1.png` ทรัพยากรที่เก็บต้องมีอยู่ที่ `pres/images/image1.png` การเก็บแค่ `image1.png` จะทำให้ความสัมพันธ์นี้ขาดหาย สำหรับการเก็บใน object storage ให้คงโครงสร้างเดียวกันภายใต้คำนำหน้างานและทำให้ URL ของทรัพยากรเหล่านั้นเข้าถึงได้สำหรับผู้ใช้ XAML เปิด ZIP ที่เสร็จสมบูรณ์เพื่อตรวจสอบชื่อรายการและไบต์ของทรัพยากร และโหลดสไลด์ตัวอย่างในสภาพแวดล้อม XAML เป้าหมายเพื่อยืนยันว่ารูปภาพถูกแก้ไขอย่างถูกต้อง

## **คำถามที่พบบ่อย**

**ฉันจะทำให้ฟอนท์คาดการณ์ได้อย่างไรถ้าไม่มีฟอนท์ต้นฉบับบนเครื่อง?**

เรียก [setDefaultRegularFont](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) ใน [XamlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/) — มันจะถูกใช้เป็นฟอนท์สำรองระหว่างการส่งออกเมื่อฟอนท์ต้นฉบับหายไป อย่างไรก็ตาม สิ่งนี้ไม่รับรองว่า XAML ที่สร้างจะอ้างอิงฟอนท์สำรองหรือว่าฟอนท์นั้นมีบนเครื่องเป้าหมาย ตรวจสอบให้แน่ใจว่าฟอนท์ที่ XAML อ้างอิงมีอยู่ในสภาพแวดล้อมที่แสดงผล

**XAML ที่ส่งออกนี้ออกแบบสำหรับ WPF เท่านั้นหรือใช้ได้กับสแตก XAML อื่นด้วย?**

Aspose.Slides ส่งออก XAML สำหรับ WPF ผ่าน API สาธารณะ ความเข้ากันได้กับสแตก XAML อื่น เช่น UWPและ Xamarin.Forms ไม่ได้รับประกัน ควรทดสอบมาร์กอัปที่สร้างในสภาพแวดล้อมเป้าหมายของคุณ

**สไลด์ที่ซ่อนอยู่ได้รับการสนับสนุนหรือไม่และฉันจะป้องกันไม่ให้ส่งออกโดยค่าเริ่มต้นได้อย่างไร?**

โดยค่าเริ่มต้น สไลด์ที่ซ่อนจะไม่ถูกรวม คุณสามารถควบคุมพฤติกรรมนี้ได้ผ่าน [setExportHiddenSlides](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) ใน [XamlOptions](https://reference.aspose.com/slides/th/php-java/aspose.slides/xamloptions/) — ปิดการใช้งานหากไม่ต้องการส่งออกสไลด์ที่ซ่อนอยู่