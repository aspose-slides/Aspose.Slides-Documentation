---
title: ขัดจังหวะการดำเนินการนำเสนอที่ใช้เวลานานบน Android
linktitle: ขัดจังหวะการดำเนินการนำเสนอ
type: docs
weight: 120
url: /th/androidjava/support-for-interruptable-library/
keywords:
- การดำเนินการที่สามารถขัดจังหวะได้
- โทเค็นการขัดจังหวะ
- โทเค็นการยกเลิก
- งานที่ใช้เวลานาน
- งานขัดจังหวะ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธียกเลิกการดำเนินการนำเสนอที่ใช้เวลานานใน Aspose.Slides สำหรับ Android ผ่าน Java และรับผลลัพธ์บางส่วนเมื่อส่งออกสไลด์ในลูป."
---
## **ภาพรวม**

Aspose.Slides for Android via Java สามารถขัดจังหวะการดำเนินการที่ใช้เวลานาน เช่นการโหลด การบันทึก และการแสดงผลสไลด์ การใช้งานของคุณสามารถใช้ token การขัดจังหวะเดียวกันเพื่อหยุดลูปก่อนที่มันจะเริ่มประมวลผลสไลด์ถัดไปได้

## **ขัดจังหวะการทำงานของการนำเสนอ**

สร้าง [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), รับ token ของมันด้วย [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), แล้วส่ง token นั้นไปยัง [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). ส่งตัวเลือกการโหลดไปยัง [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). เพื่อขอยกเลิก, เรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) บนแหล่งข้อมูล การดำเนินการที่สามารถขัดจังหวะจะหยุดเมื่อมันสังเกตเห็นคำขอ

ตัวอย่างจะแปลง `sample.pptx` เป็น `sample.ppt` บนเธรดพื้นหลัง เธรดที่เรียกจะรอสูงสุด 10 วินาทีจนการแปลงเสร็จ หากการแปลงยังดำเนินอยู่ จะขอยกเลิกและรอให้งานทำงานเสร็จ

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // เรียกจากเธรดพื้นหลังและส่ง context.getFilesDir() ซึ่งมี sample.pptx
    public static void run(File directory) throws InterruptedException {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.ppt");
        InterruptionTokenSource source = new InterruptionTokenSource();
        Thread worker = new Thread(() -> {
            LoadOptions options = new LoadOptions();
            options.setInterruptionToken(source.getToken());
            try {
                Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                try {
                    presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
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
    }
}
```
## **เชื่อมต่อการหมดเวลา Java กับ Aspose.Slides**

เพื่อกำหนดเวลาจำกัดสำหรับการดำเนินการของการนำเสนอ ใช้ [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) เพื่อเรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) เมื่อเวลาหมด ตัวอย่างอนุญาต 20 วินาทีเพื่อโหลด `sample.pptx` และส่งออกเป็น `sample.pdf` หากการส่งออกเสร็จเร็ว แอปพลิเคชันจะยกเลิกคำขอที่กำหนดไว้ล่วงหน้า

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // เรียกจากเธรดพื้นหลังและส่ง context.getFilesDir() ซึ่งมี sample.pptx.
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```
## **หยุดก่อนประมวลผลสไลด์ถัดไป**

ใช้ [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) เดียวกันสำหรับการนำเสนอและลูปที่ส่งออกสไลด์ของมัน ตรวจสอบ [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) ก่อนการส่งออกแต่ละครั้ง หากผู้เรียกสามารถใช้ผลลัพธ์บางส่วนได้ ให้ส่งคืนหมายเลขสไลด์ของการส่งออกที่สำเร็จ

ใช้การนำเสนอชื่อ `sample.pptx` ซึ่งมีอย่างน้อยสองสไลด์ เมธอด [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) ที่รับอาเรย์ของหมายเลขสไลด์จะเริ่มนับจาก 1 ตัวอย่างบันทึกแต่ละสไลด์เป็น PDF แยกไฟล์และขอยกเลิกทันทีหลังจากบันทึกการส่งออกแรกที่สำเร็จ

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
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

    // เรียกจากเธรดพื้นหลังและส่ง context.getFilesDir() ซึ่งมี sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```
ตัวอย่างเขียนไฟล์ `slide-1.pdf` และพิมพ์ `Starting slide 1` ตามด้วย `Completed: [1]` ลูปสังเกตคำขอก่อนเริ่มสไลด์ 2 หากการยกเลิกเกิดขึ้นขณะบันทึก ลูปจะออกก่อนบันทึกสไลด์นั้นเป็นสำเร็จ

หากผู้เรียกต้องการจัดการการยกเลิก ให้แทนที่การตรวจสอบและ `break` ที่ส่วนบนของลูปด้วย `token.throwIfInterruptionRequested()` ลบ `try`/`catch` รอบการบันทึกเพื่อให้การยกเลิกในระหว่างการส่งออกส่งไปยังผู้เรียกได้ด้วย อินพุตเดียวกัน ตัวอย่างจะพิมพ์เฉพาะ `Starting slide 1` และเขียน `slide-1.pdf` เมื่อเริ่มรอบที่สอง [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) จะโยน `com.aspose.slides.exceptions.OperationCanceledException` ก่อนที่การส่งออกถัดไปจะเริ่ม วิธีนี้จะไม่ส่งคืนรายการใด

## **คำถามที่พบบ่อย**

**เมื่อใดควรขอยกเลิก?**

ให้ขอยกเลิกเมื่อการดำเนินการเกินขีดจำกัดเวลาของคุณหรือเมื่อแอปพลิเคชันของคุณไม่ต้องการผลลัพธ์อีกต่อไป

**ความแตกต่างระหว่าง [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) และ [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

แหล่งข้อมูลทำให้แอปพลิเคชันของคุณสามารถขอยกเลิกได้ ส่วน token ทำให้ Aspose.Slides และแอปพลิเคชันของคุณตรวจสอบคำขอนั้น

**ฉันสามารถยกเลิกการดำเนินการจากตัวจับเวลาของ Java ได้หรือไม่?**

ใช่. กำหนดเวลาการเรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) บนแหล่งข้อมูลที่เชื่อมโยงกับการนำเสนอ

**ฉันสามารถขัดจังหวะการดำเนินการใดได้บ้าง?**

คุณสามารถขัดจังหวะการโหลด การบันทึก และการเรนเดอร์ได้ ส่ง token ไปยัง [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) ผ่าน [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) การนำเสนอจะสามารถสังเกตการยกเลิกในขั้นตอนต่อๆ ไป เช่นการบันทึกเป็น PDF

**การดำเนินการหยุดทันทีหรือไม่?**

การยกเลิกเป็นการทำงานร่วมกัน การดำเนินการจะตรวจสอบ token เป็นระยะและหยุดเมื่อมันสังเกตเห็นคำขอ

**จะเกิดอะไรขึ้นหากฉันเรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) หลังจากการดำเนินการเสร็จสิ้น?**

การดำเนินการที่เสร็จสิ้นจะคงผลลัพธ์ไว้

**หลายการดำเนินการสามารถแชร์ [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) ได้หรือไม่?**

ได้. การเรียก [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) จะขอยกเลิกสำหรับทุกการดำเนินการที่ใช้ token จากแหล่งข้อมูลนั้น ใช้แหล่งข้อมูลแยกกันสำหรับแต่ละการดำเนินการที่คุณต้องการยกเลิกอย่างอิสระ