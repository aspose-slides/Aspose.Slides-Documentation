---
title: "ขัดจังหวะการดำเนินการงานนำเสนอที่ใช้เวลานานใน PHP"
linktitle: "ขัดจังหวะการดำเนินการงานนำเสนอ"
type: docs
weight: 120
url: /th/php-java/support-for-interruptable-library/
keywords:
  - "โทเคนการขัดจังหวะ"
  - "การยกเลิก"
  - "เวลาจำกัดการแปลง"
  - "การส่งออกสไลด์"
  - "PowerPoint"
  - "PHP"
  - "Aspose.Slides"
description: "เรียนรู้วิธียกเลิกการแปลงงานนำเสนอด้วยตัวจับเวลาและส่งคืนสไลด์ที่ส่งออกก่อนการยกเลิกด้วย Aspose.Slides for PHP via Java."
---
## **ภาพรวม**

Aspose.Slides for PHP via Java สามารถขัดจังหวะการทำงานที่ใช้เวลานาน เช่น การโหลด การบันทึก และการเรนเดอร์งานนำเสนอได้ ในลูปที่ส่งออกสไลด์หนึ่งภาพต่อหนึ่งภาพ โทเคนเดียวกันจะทำให้แอปพลิเคชันของคุณหยุดก่อนสไลด์ถัดไปและส่งคืนรายการของการส่งออกที่เสร็จสมบูรณ์

ตัวอย่าง PHP ทั้งสองสันนิษฐานว่าการบูตสแตรปของคุณเรียก `define("JAVA_PREFER_VALUES", 1);` ก่อนโหลด `Java.inc` ของ bridge จากนั้นโหลด `aspose.slides.php`. การตั้งค่านี้ทำให้ PHP ดักจับข้อยกเว้นของ Java ระหว่างการเรียกใช้ ตัวอย่างตรวจสอบสาเหตุของข้อยกเว้นที่หุ้มห่อเพื่อให้ข้อผิดพลาดการแปลงอื่น ๆ ไปถึงผู้เรียกใช้

## **ขัดจังหวะการดำเนินการของงานนำเสนอ**

สร้าง [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), รับโทเคนของมันด้วย [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken) และส่งให้กับ [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). ส่งตัวเลือกเหล่านี้เมื่อสร้าง [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). การเรียก [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) จะร้องขอการยกเลิก งานที่กำลังทำอยู่จะหยุดเมื่อสังเกตเห็นคำขอนั้น

### **ตั้งเวลาจำกัดการแปลง**

ในขณะที่ PHP รอการโหลดหรือบันทึกแบบ synchronous ผ่าน PHP/Java Bridge, ตัวจับเวลา Java สามารถร้องขอยกเลิกบนเธรดแยกได้ บันทึกตัวช่วยต่อไปนี้เป็น `ConversionTimeout.java`, คอมไพล์ด้วย JAR ของ Aspose.Slides บนคลาสพาธ, และทำให้คลาสที่คอมไพล์แล้วพร้อมใช้งานกับ bridge ภายใต้ชื่อแพคเกจ `example.ConversionTimeout`.

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

เมื่อโหลด bridge และ wrapper ของ Aspose.Slides PHP แล้ว ให้เรียกตัวอย่างต่อนี้โดยใช้ `sample.pptx` ในไดเรกทอรีทำงานของกระบวนการ Java, หรือใช้เส้นทางแบบเต็มที่เข้าถึงได้โดยกระบวนการนั้น การจำกัดเวลา 20 วินาทีนั้นครอบคลุมการโหลดและการส่งออกเป็น PDF หากการแปลงเสร็จเร็วกว่า PHP จะยกเลิกตัวจับเวลา เพื่อแปลงเป็นรูปแบบ PowerPoint เก่ากว่าด้วยจำกัดเวลา 10 วินาที ให้ใช้ `sample.ppt`, `SaveFormat::Ppt` และ `10000` มิลลิวินาที

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **หยุดก่อนประมวลผลสไลด์ถัดไป**

ตรวจสอบ [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) ก่อนการส่งออกแต่ละครั้ง [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) overload สำหรับสไลด์ที่เลือกรับหมายเลขสไลด์ที่เริ่มจาก 1 ส่งอาร์เรย์ที่มีหนึ่งองค์ประกอบเพื่อเขียน PDF แยกสำหรับแต่ละสไลด์

ใช้ `sample.pptx` ที่มีอย่างน้อยสองสไลด์ เพื่อสาธิตการยกเลิกระหว่างการส่งออก ตัวอย่างจะร้องขอการยกเลิกทันทีหลังจากบันทึกสไลด์แรก

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

ตัวอย่างเขียนไฟล์ `slide-1.pdf` และพิมพ์ `Completed: [1]`. การทำซ้ำครั้งที่สองพบคำขอก่อนที่จะเริ่มการส่งออกครั้งต่อไป หากการยกเลิกเกิดขึ้นระหว่างการบันทึก รายการจะมีเฉพาะการส่งออกที่ยืนยันแล้วก่อนหน้า การบันทึกที่ถูกขัดจังหวะอาจทำให้ไฟล์ที่ดิสก์ไม่สมบูรณ์

เพื่อส่งต่อการยกเลิกไปยังผู้เรียก ให้เปลี่ยนการตรวจสอบที่จุดเริ่มต้นของลูปเป็น `$token->throwIfInterruptionRequested();` และลบ `try`/`catch` ภายในออก, รักษาการบันทึกและการตรวจสอบที่ตามมาด้วย ด้วยอินพุตเดียวกัน, [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) จะโยนข้อยกเว้นก่อนสไลด์ที่ 2 และผู้เรียกจะไม่ได้รับรายการ

## **คำถามที่พบบ่อย**

**เมื่อใดควรร้องขอยกเลิก?**

ร้องขอยกเลิกเมื่อเวลาจำกัดหมดหรือผู้เรียกไม่ต้องการผลลัพธ์แล้ว คำขอที่ทำหลังจากการดำเนินการเสร็จสิ้นจะไม่กระทบผลลัพธ์

**แหล่งที่มและโทเคนต่างกันอย่างไร?**

แหล่งที่มาช่วยให้แอปพลิเคชันร้องขอยกเลิก. โทเคนทำให้ Aspose.Slides และโค้ดของแอปพลิเคชันสังเกตเห็นคำนั้น

**หลายการดำเนินการสามารถใช้งานแหล่งที่มาร่วมกันได้หรือไม่?**

ได้. คำขอจะใช้กับการดำเนินการทั้งหมดที่ใช้โทเคนจากแหล่งที่มนั้น. สร้างแหล่งที่มาแยกต่างหากสำหรับการดำเนินการที่ต้องการการยกเลิกอิสระ.