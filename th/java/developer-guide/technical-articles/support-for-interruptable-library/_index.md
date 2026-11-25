---
title: ขัดจังหวะการทำงานของการนำเสนอที่ใช้เวลานานใน Java
linktitle: ขัดจังหวะการทำงานของการนำเสนอ
type: docs
weight: 120
url: /th/java/support-for-interruptable-library/
keywords:
- การทำงานที่ขัดจังหวะได้
- โทเค็นการขัดจังหวะ
- โทเค็นการยกเลิก
- งานที่ใช้เวลานาน
- ขัดจังหวะงาน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธียกเลิกการทำงานของการนำเสนอที่ใช้เวลานานใน Aspose.Slides สำหรับ Java และคืนผลลัพธ์บางส่วนเมื่อส่งออกสไลด์ในลูป."
---
## **ภาพรวม**

Aspose.Slides for Java สามารถขัดจังหวะการทำงานที่ใช้เวลานาน เช่น การโหลด การบันทึก และการเรนเดอร์การนำเสนอได้ แอปพลิเคชันของคุณสามารถใช้ token การขัดจังหวะเดียวกันเพื่อหยุดลูปก่อนที่จะเริ่มประมวลผลสไลด์ถัดไป

## **ขัดจังหวะการทำงานของการนำเสนอ**

สร้าง [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), รับ token ของมันด้วย [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), แล้วส่ง token ไปยัง [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). ส่ง load options ไปยัง [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). เพื่อขอการยกเลิก ให้เรียกใช้ [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) บนแหล่งข้อมูล การทำงานที่สามารถขัดจังหวะจะหยุดเมื่อพบคำขอ

ตัวอย่างจะแปลง `sample.pptx` เป็น `sample.ppt` ในเธรดพื้นหลัง เธรดที่เรียกใช้จะรอสูงสุด 10 วินาทีเพื่อให้การแปลงเสร็จสมบูรณ์ หากการแปลงยังคงทำงานอยู่ จะขอการยกเลิกและรอให้เธรดทำงานเสร็จ

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
        } finally {
            presentation.dispose();
        }
    } catch (OperationCanceledException canceled) {
        System.out.println("Conversion canceled");
    }
});

worker.start();
worker.join(10000);
if (worker.isAlive()) {
    source.interrupt();
    worker.join();
}
```

## **เชื่อมต่อการตั้งเวลา Java กับ Aspose.Slides**

เพื่อกำหนดเวลาจำกัดบนการทำงานของการนำเสนอ ให้ใช้ [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) เพื่อเรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) เมื่อเวลาหมด ตัวอย่างจะให้เวลา 20 วินาทีเพื่อโหลด `sample.pptx` และส่งออกเป็น `sample.pdf` หากการส่งออกเสร็จเร็วเกินกว่าจะครบเวลา แอปพลิเคชันจะยกเลิกคำขอที่กำหนดไว้ล่วงหน้า

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **หยุดก่อนประมวลผลสไลด์ถัดไป**

ใช้ [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) เดียวกันสำหรับการนำเสนอและลูปที่ส่งออกสไลด์ ตรวจสอบ [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) ก่อนการส่งออกแต่ละครั้ง หากผู้เรียกสามารถใช้ผลลัพธ์บางส่วนได้ ให้คืนหมายเลขสไลด์สำหรับการส่งออกที่สำเร็จแล้ว

ใช้การนำเสนอชื่อ `sample.pptx` ที่มีอย่างน้อยสองสไลด์ [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) ที่รับอาร์เรย์ของหมายเลขสไลด์โดยเริ่มจาก 1 ตัวอย่างจะบันทึกแต่ละสไลด์เป็น PDF แยกไฟล์และขอยกเลิกทันทีหลังจากบันทึกสไลด์แรกสำเร็จ

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

ตัวอย่างจะเขียน `slide-1.pdf` และพิมพ์ `Starting slide 1` ตามด้วย `Completed: [1]` ลูปจะตรวจพบคำขอก่อนเริ่มสไลด์ที่ 2 หากการยกเลิกเกิดขึ้นระหว่างการบันทึก ลูปจะออกก่อนบันทึกสไลด์นั้นเป็นสำเร็จ

หากผู้เรียกต้องการจัดการการยกเลิก ให้แทนที่การตรวจสอบและ `break` ที่ด้านบนของลูปด้วย `token.throwIfInterruptionRequested()` ลบ `try`/`catch` รอบการบันทึกเพื่อให้การยกเลิกระหว่างการส่งออกถึงผู้เรียกได้ด้วย ตัวอย่างเดียวกันจะพิมพ์เฉพาะ `Starting slide 1` และเขียน `slide-1.pdf` ที่จุดเริ่มต้นของการทำซ้ำครั้งที่สอง [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) จะโยน `com.aspose.slides.exceptions.OperationCanceledException` ก่อนการส่งออกต่อไปเริ่มต้น เมธอดจะไม่คืนรายการใดเลย

## **คำถามที่พบบ่อย**

**เมื่อใดควรขอการยกเลิก?**

ขอการยกเลิกเมื่อการทำงานเกินเวลาที่กำหนดหรือเมื่อแอปพลิเคชันของคุณไม่ต้องการผลลัพธ์อีกต่อไป

**ความแตกต่างระหว่าง [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) และ [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) คืออะไร?**

แหล่งข้อมูลทำให้แอปพลิเคชันของคุณขอการยกเลิกได้ Token ทำให้ Aspose.Slides และแอปพลิเคชันของคุณตรวจสอบคำขอนั้นได้

**ฉันสามารถยกเลิกการทำงานจากตัวจับเวลา Java ได้หรือไม่?**

ได้ กำหนดการเรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) บนแหล่งข้อมูลที่เชื่อมกับการนำเสนอ

**ฉันสามารถขัดจังหวะการทำงานใดได้บ้าง?**

คุณสามารถขัดจังหวะการโหลด การบันทึก และการเรนเดอร์ได้ ส่ง token ไปยัง [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) ผ่าน [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) การนำเสนอจะตรวจสอบการยกเลิกในขั้นตอนต่อไปเช่นการบันทึกเป็น PDF

**การทำงานจะหยุดทันทีหรือไม่?**

การยกเลิกเป็นการทำงานร่วมกัน การทำงานจะตรวจสอบ token เป็นระยะและหยุดเมื่อพบคำขอ

**จะเกิดอะไรขึ้นหากฉันเรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) หลังจากการทำงานเสร็จแล้ว?**

การทำงานที่สำเร็จจะคงผลลัพธ์ไว้

**หลายการทำงานสามารถใช้ [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) เดียวกันได้หรือไม่?**

ได้ การเรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) จะขอการยกเลิกสำหรับทุกการทำงานที่ใช้ token จากแหล่งนั้น ใช้แหล่งข้อมูลแยกสำหรับแต่ละการทำงานที่ต้องการยกเลิกอย่างอิสระ