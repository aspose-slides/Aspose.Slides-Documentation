---
title: จัดการคำเตือนการนำเสนอใน PHP
type: docs
weight: 90
url: /th/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- การเรียกคืนคำเตือน
- นโยบายการเตือน
- การสูญเสียข้อมูล
- ความเสียหายของแหล่ง
- ปัญหาความเข้ากันได้
- การแทนที่ฟอนต์
- ลายเซ็นดิจิทัล
- การโหลดการนำเสนอ
- การเรนเดอร์การนำเสนอ
- การแปลงการนำเสนอ
- การบันทึกการนำเสนอ
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีการรวบรวม แยกประเภท และดำเนินการกับคำเตือนขณะโหลด เรนเดอร์ แปลง และบันทึกการนำเสนอด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides สามารถรายงานปัญหาที่สามารถกู้คืนได้ขณะโหลด, เรนเดอร์, แปลง หรือบันทึกการนำเสนอ ตัวอย่างได้แก่เรคคอร์ดแหล่งที่เสียหาย, เนื้อหาที่ไม่สามารถคงไว้ได้, การแทนที่ฟอนท์, และข้อจำกัดของรูปแบบปลายทาง คอลแบ็กการแจ้งเตือนช่วยให้แอปพลิเคชันบันทึกเงื่อนไขเหล่านี้และตัดสินใจว่าปฏิบัติการปัจจุบันจะดำเนินต่อได้หรือไม่

สร้างคลาส PHP ที่มีเมธอดสาธารณะ `warning` และเปิดเผยผ่าน PHP Java Bridge เป็นอินเทอร์เฟส Java [IWarningCallback](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarningcallback/) โดยใช้ `java_closure` ตรวจสอบค่าที่ให้ผ่าน [IWarningInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/) โดยดูที่ [getWarningType](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getWarningType--) และ [getDescription](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getDescription--) คืนค่า [ReturnAction::Continue](https://reference.aspose.com/slides/th/php-java/aspose.slides/returnaction/#Continue) เพื่อยอมรับการแจ้งเตือนหรือ [ReturnAction::Abort](https://reference.aspose.com/slides/th/php-java/aspose.slides/returnaction/#Abort) เพื่อหยุดการทำงาน

ใช้ [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/th/php-java/aspose.slides/loadoptions/#setWarningCallback) สำหรับคำเตือนที่เกิดขณะเปิดการนำเสนอ การเรนเดอร์และคลาสตัวเลือกการส่งออกสืบทอดจาก [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/th/php-java/aspose.slides/saveoptions/#setWarningCallback) ซึ่งรับคำเตือนจากการเรนเดอร์สไลด์, การแปลง, และการบันทึก เนื่องจากคำเตือนเองไม่ระบุการทำงานของแอปพลิเคชัน จึงควรผูกแต่ละอินสแตนซ์ของคอลแบ็กกับขั้นตอนการทำงานเมื่อสร้างรายงานรวม

## **คำเตือนและข้อยกเว้น**

ข้อยกเว้นของ Java จะถูกเปิดเผยต่อ PHP ผ่าน PHP Java Bridge; ให้จับข้อยกเว้นที่ขอบเขตการทำงานตามตัวอย่างด้านล่าง ลิงก์อินเทอร์เฟส Java ในบทความนี้อธิบายสัญญาโครงสร้างคอลแบ็กที่ใช้โดยบริดจ์

คำเตือนอธิบายเงื่อนไขที่ Aspose.Slides สามารถกู้คืนได้หากคอลแบ็กคืนค่า `ReturnAction::Continue` ข้อยกเว้นหมายถึงการทำงานที่ร้องขอไม่สามารถสำเร็จได้ตามปกติ; ข้อยกเว้นจะไม่ถูกแปลงเป็นคำเตือนและไม่สามารถจัดการโดยนโยบายคำเตือนได้

การคืนค่า `ReturnAction::Abort` จะสั่งให้ตัวกระจายคำเตือนยุติปฏิบัติการปัจจุบันโดยการโยนข้อยกเว้น ข้อยกเว้นสาธารณะจะขึ้นอยู่กับการทำงานและรูปแบบการนำเสนอ ตัวอย่างเช่น การโหลดอาจทำให้เกิด [PptxReadException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxreadexception/) หรือ [PptReadException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptreadexception/) ในขณะที่การบันทึกหรือการส่งออกอาจทำให้เกิด [PptxException](https://reference.aspose.com/slides/th/php-java/aspose.slides/pptxexception/) ให้จัดการข้อยกเว้นที่ขอบเขตของการทำงานและใช้รายงานคำเตือนเพื่อตรวจสอบว่านโยบายของแอปพลิเคชันทำให้การยุติเกิดขึ้นหรือไม่ แทนการพึ่งพาชนิดข้อยกเว่นย่อยหรือข้อความคอลแบ็กจะบันทึกคำเตือนก่อนคืนค่า `ReturnAction::Abort` เพื่อให้เหตุผลยังคงพร้อมให้แอปพลิเคชันเข้าถึง

## **ประเภทคำเตือน**

คลาส [WarningType](https://reference.aspose.com/slides/th/php-java/aspose.slides/warningtype/) ให้ค่าคงที่จำนวนเต็มสำหรับประเภทต่อไปนี้:

| ประเภทคำเตือน | ความหมาย | นโยบายโดยทั่วไป |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/th/php-java/aspose.slides/warningtype/#SourceFileCorruption) | แหล่งการนำเสนอมีการเสียหายซึ่งอาจทำให้เอกสารที่บันทึกในรูปแบบเดิมไม่สามารถใช้ได้ | ยกเลิก. |
| [DataLoss](https://reference.aspose.com/slides/th/php-java/aspose.slides/warningtype/#DataLoss) | ข้อความ, แผนภูมิ, รูปภาพ หรือข้อมูลอื่น ๆ อาจสูญหายหลังการโหลดหรือบันทึก | ยกเลิก. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/th/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | การนำเสนออาจสูญเสียการจัดรูปแบบที่สำคัญ | ยกเลิกในโหมดตรวจสอบที่เข้มงวด; หากไม่ใช่ให้บันทึกและดำเนินต่อ. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/th/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | อาจมีความแตกต่างในการจัดรูปแบบที่จำกัด | บันทึกเพื่อการวินิจฉัยและดำเนินต่อ. |
| [CompatibilityIssue](https://reference.aspose.com/slides/th/php-java/aspose.slides/warningtype/#CompatibilityIssue) | ผลลัพธ์อาจไม่เปิดหรือทำงานอย่างถูกต้องในบางแอปพลิเคชันหรือเวอร์ชันเก่า | บันทึกและดำเนินต่อ เว้นแต่ความเข้ากันได้เป็นสิ่งจำเป็น. |
| [UnexpectedContent](https://reference.aspose.com/slides/th/php-java/aspose.slides/warningtype/#UnexpectedContent) | แหล่งที่มามีเนื้อหาที่ไม่รองรับหรือไม่รู้จักซึ่งผลกระทบยังไม่ทราบ | บันทึกและดำเนินต่อ หรือถือเป็นข้อผิดพลาดในนโยบายที่เข้มงวด. |

ประเภทควรเป็นตัวกำหนดการตัดสินใจเชิงนโยบาย เก็บค่าที่คืนจาก [getDescription](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getDescription--) เพื่อการวินิจฉัย แต่ไม่ควรพึ่งพาข้อความนั้นในการตรึกตรองของแอปพลิเคชัน เนื่องจากข้อความอาจแตกต่างระหว่างสถานการณ์คำเตือนและเวอร์ชันของผลิตภัณฑ์

## **รวบรวมและจำแนกคำเตือน**

ตัวอย่างต่อไปนี้ใช้รายงานระดับแอปพลิเคชันเดียวสำหรับขั้นตอนการประมวลผลทั้งหมด อินสแตนซ์คอลแบ็กแยกแต่ละขั้นตอนจะระบุคำเตือนจากการโหลด, การเรนเดอร์, การแปลงเป็น PDF, และการบันทึกเป็น PPTX นโยบายจะยกเลิกเมื่อพบการเสียหายของแหล่งหรือการสูญเสียข้อมูล, สามารถเลือกยกเลิกเมื่อมีการสูญเสียการจัดรูปแบบที่สำคัญ, และดำเนินต่อสำหรับคำเตือนอื่น ๆ คอลแบ็กจะแปลงค่าคำเตือนเป็นค่า PHP เนทีฟด้วย `java_values` ก่อนบันทึกและเปรียบเทียบ

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

ส่งค่า `false` ให้กับ `abortOnMajorFormattingLoss` เมื่อสร้าง `WarningPolicy` หากความแตกต่างของการจัดรูปแบบที่สำคัญเป็นที่ยอมรับ ปัญหาความเข้ากันได้, การสูญเสียการจัดรูปแบบเล็กน้อย, และเนื้อหาที่ไม่คาดคิดยังคงถูกบันทึกในรายงานแม้การทำงานจะดำเนินต่อ หากแอปพลิเคชันต้องปฏิเสธหนึ่งในหมวดเหล่านั้น ให้ขยาย `WarningPolicy::getAction`

## **สถานการณ์คำเตือนทั่วไป**

คำเตือนสามารถปรากฏได้ในขั้นตอนต่าง ๆ ของเวิร์กโฟลว์:

- **ลายเซ็นดิจิทัล:** การนำเสนอที่ลงลายเซ็นอาจให้คำเตือนในขั้นตอนการโหลดว่าลายเซ็นจะหายไประหว่างการประมวลผล Aspose.Slides รายงานเงื่อนไข `DataLoss` นี้ผ่าน [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/ipresentationsignedwarninginfo/) คอลแบ็กระดับการโหลดช่วยให้แอปพลิเคชันปฏิเสธไฟล์หรือยอมรับการสูญเสียที่รายงานไว้โดยเจตนา
- **การแทนที่ฟอนท์:** ฟอนท์ที่ไม่มีอยู่สามารถถูกแทนที่ขณะเรนเดอร์หรือตอนส่งออก คำเตือนการแทนที่ฟอนท์จะรายงานเป็น `DataLoss` ดังนั้นนโยบายเข้มงวดด้านบนจะยกเลิกแม้แอปพลิเคชันอาจพิจารณาการแทนที่นั้นว่าดูดี เพื่อตรวจสอบพฤติกรรมนี้ ให้ใช้การนำเสนอที่มีข้อความในฟอนท์ที่รันไทม์ไม่สามารถเข้าถึงได้ คำอธิบายของคำเตือนจะระบุการแทนที่; กำหนดฟอนท์ที่ต้องการหรือ [กฎการแทนที่ฟอนท์](/slides/th/php-java/font-substitution/) ก่อนลองใหม่
- **เนื้อหาที่ไม่รองรับหรือไม่คาดคิด:** ตัวโหลดอาจพบเรคคอร์ดหรือฟีเจอร์ที่ไม่รู้จัก คำเตือนเหล่านี้อาจใช้ `UnexpectedContent` หรือหมวดที่รุนแรงกว่าเมื่อตรวจพบว่าข้อมูลหรือการจัดรูปแบบได้รับผลกระทบ
- **ความเข้ากันได้ของรูปแบบ:** การบันทึกเป็นรูปแบบการนำเสนออื่นอาจตัดคุณลักษณะหรือทำให้ผลลัพธ์ทำงานแตกต่างในบางแอปพลิเคชัน ตัวอย่างเช่น การบันทึกการนำเสนอที่มีเส้นนำวาดแนวนอนหรือแนวตั้งมากกว่าหนึ่งแปดรายการใน PPT รุ่นเก่า จะรายงาน `CompatibilityIssue` คอลแบ็กระดับการบันทึกสามารถบันทึกการสูญเสียและดำเนินต่อ หรือปฏิเสธหากต้องการรักษาแนวนำวาดทั้งหมดไว้
- **พฤติกรรมการโหลด:** ตัวเลือกการโหลดและพฤติกรรมเก่าอาจทำให้เกิดคำเตือนได้ ตัวอย่างเช่น [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/th/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) ระบุการใช้พฤติกรรมการล็อกการนำเสนอที่ล้าสมัยเป็น `CompatibilityIssue`

คำเตือนขึ้นอยู่กับเอกสารแหล่ง, รูปแบบปลายทาง, การดำเนินการ, และเวอร์ชันของ Aspose.Slides อย่าสมมติว่าทุกไฟล์จะสร้างคำเตือนหรือว่าสถานการณ์ใดจะสอดคล้องกับเพียงหนึ่งหมวดเท่านั้น

## **จัดการการดำเนินการที่ถูกยกเลิกอย่างปลอดภัย**

เมื่อคอลแบ็กคืนค่า `ReturnAction::Abort` อย่าใช้วัตถุที่โหลดไม่สำเร็จและอย่าอ้างว่าเอาต์พุตการเรนเดอร์หรือการบันทึกครบสมบูรณ์ การดำเนินการอาจสิ้นสุดหลังจากสร้างไฟล์เอาต์พุตแล้วแต่ก่อนที่จะเสร็จสิ้นเต็มรูปแบบ

บันทึกผลลัพธ์ที่ตรวจสอบแล้วไปยังเส้นทางแยก เช่น `validated-output.pptx` ให้แทนที่การนำเสนอที่มีอยู่เฉพาะเมื่อการดำเนินการเสร็จสมบูรณ์อย่างไม่มีข้อผิดพลาด, รายงานคำเตือนสอดคล้องกับนโยบายแอปพลิเคชัน, และไฟล์เอาต์พุตสามารถเปิดและตรวจสอบได้ วิธีนี้จะหลีกเลี่ยงการเขียนทับไฟล์แหล่งที่ถูกต้องด้วยผลลัพธ์ที่บางส่วนหรือถูกปฏิเสธ

รายงานคำเตือนที่ว่างเปล่าไม่ได้รับประกันว่าฟีเจอร์ทุกอย่างของแหล่งถูกเก็บรักษาไว้ ควรทำการตรวจสอบเนื้อหาและภาพเพิ่มเติมตามที่แอปพลิเคชันกำหนด ดูเพิ่มเติมที่ [เปิดการนำเสนอ](/slides/th/php-java/open-presentation/) และ [บันทึกการนำเสนอ](/slides/th/php-java/save-presentation/)

## **คำถามที่พบบ่อย**

**คอลแบ็กการแจ้งเตือนสามารถจัดการข้อผิดพลาดของ Aspose.Slides ทุกอย่างได้หรือไม่?**

ไม่ มันจัดการเฉพาะเงื่อนไขที่กู้คืนได้และรายงานเป็นคำเตือน ข้อยยกเว้นที่เกิดโดยอิสระจากคอลแบ็กต้องถูกจัดการโดยแอปพลิเคชันรอบ ๆ การเรียกโหลด, เรนเดอร์, แปลง หรือบันทึก

**การคืนค่า `ReturnAction::Continue` รับประกันว่าเอาต์พุตจะเหมือนเดิมหรือไม่?**

ไม่ มันเพียงอนุญาตให้การประมวลผลดำเนินต่อ เงื่อนไขที่รายงานอาจยังทำให้เกิดความแตกต่างของข้อมูล, การจัดรูปแบบ, หรือความเข้ากันได้ ดังนั้นต้องตรวจสอบประเภทและรายละเอียดของคำเตือนที่รวบรวมไว้

**แอปพลิเคชันจะระบุขั้นตอนที่ทำให้เกิดคำเตือนได้อย่างไร?**

สร้างอินสแตนซ์คอลแบ็กสำหรับแต่ละขั้นตอนและเก็บขั้นตอนที่กำหนดโดยแอปพลิเคชันพร้อมค่าที่คืนจาก [getWarningType](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getWarningType--) และ [getDescription](https://reference.aspose.com/slides/th/java/com.aspose.slides/iwarninginfo/#getDescription--) ตามที่แสดงในตัวอย่าง.