---
title: สนับสนุนไลบรารีที่สามารถขัดจังหวะได้
type: docs
weight: 120
url: /th/java/support-for-interruptable-library/
keywords:
- ไลบรารีที่สามารถขัดจังหวะได้
- โทเค็นการขัดจังหวะ
- โทเค็นการยกเลิก
- งานที่ใช้เวลานาน
- งานขัดจังหวะ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ทำให้งานที่ใช้เวลานานสามารถยกเลิกได้ด้วย Aspose.Slides สำหรับ Java. ขัดจังหวะการเรนเดอร์และการแปลงสำหรับ PowerPoint และ OpenDocument อย่างปลอดภัย พร้อมตัวอย่าง."
---
## **ภาพรวม**

Aspose.Slides มีกลไกการประมวลผลที่สามารถขัดจังหวะได้สำหรับงานนำเสนอที่ใช้เวลานาน เช่น การถอดรหัส (deserialization), การเข้ารหัส (serialization) และการเรนเดอร์ (rendering). กลไกนี้อ้างอิงจากคลาส `InterruptionToken` และ `InterruptionTokenSource`.

`InterruptionToken` สามารถกำหนดให้กับ `LoadOptions` และส่งต่อไปยังคอนสตรัคเตอร์ของ `Presentation`. เมื่อเรียก `InterruptionTokenSource.interrupt()` งานที่ดำเนินการระยะเวลานานที่เกี่ยวข้องจะถูกขัดจังหวะ.

## **ไลบรารีที่สามารถขัดจังหวะได้**

ใน [Aspose.Slides 18.4](https://releases.aspose.com/slides/th/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/), เราได้แนะนำคลาส [InterruptionToken](https://reference.aspose.com/slides/th/java/com.aspose.slides/interruptiontoken/) และ [InterruptionTokenSource](https://reference.aspose.com/slides/th/java/com.aspose.slides/interruptiontokensource/) . คลาสเหล่านี้ช่วยให้คุณสามารถขัดจังหวะงานที่ใช้เวลานาน เช่น การถอดรหัส, การเข้ารหัสและการเรนเดอร์.

- [InterruptionTokenSource](https://reference.aspose.com/slides/th/java/com.aspose.slides/interruptiontokensource/) เป็นแหล่งที่มาของโทเค็นที่ถูกส่งไปยัง [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- เมื่อกำหนดค่า [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/th/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) และส่งอินสแตนซ์ของ [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/) ไปยังคอนสตรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/), การเรียก [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/th/java/com.aspose.slides/interruptiontokensource/#interrupt--) จะขัดจังหวะงานใด ๆ ที่ใช้เวลานานที่เชื่อมโยงกับ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) นั้น.

The following code snippet demonstrates interrupting a running task:

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // เรียกใช้การทำงานในเธรดแยก
Thread.sleep(10000);     // หมดเวลา
tokenSource.interrupt(); // หยุดการแปลง
```

## **คำถามที่พบบ่อย**

**วัตถุประสงค์ของไลบรารีขัดจังหวะ Aspose.Slides คืออะไร?**

มันให้กลไกเพื่อขัดจังหวะการดำเนินการที่ใช้เวลานาน—เช่น การโหลด, การบันทึก หรือการเรนเดอร์การนำเสนอ—ก่อนที่จะเสร็จสิ้น. สิ่งนี้มีประโยชน์เมื่อต้องจำกัดเวลาในการประมวลผลหรือเมื่องานนั้นไม่จำเป็นต้องทำต่อ.

**ความแตกต่างระหว่าง [InterruptionToken](https://reference.aspose.com/slides/th/java/com.aspose.slides/interruptiontoken/) และ [InterruptionTokenSource](https://reference.aspose.com/slides/th/java/com.aspose.slides/interruptiontokensource/) คืออะไร?**

- `InterruptionToken` ถูกส่งไปยัง API ของ Aspose.Slides และจะถูกตรวจสอบระหว่างการดำเนินการที่ใช้เวลานาน.
- `InterruptionTokenSource` ถูกใช้ในโค้ดของคุณเพื่อสร้างโทเค็นและกระตุ้นการขัดจังหวะโดยการเรียก `Interrupt()`.

**งานใดสามารถขัดจังหวะได้?**

งานใด ๆ ของ Aspose.Slides ที่รับ [InterruptionToken](https://reference.aspose.com/slides/th/java/com.aspose.slides/interruptiontoken/)—เช่น การโหลดการนำเสนอด้วย `Presentation(path, loadOptions)` หรือการบันทึกด้วย `Presentation.save(...)`—สามารถถูกขัดจังหวะได้.

**การขัดจังหวะเกิดขึ้นทันทีหรือไม่?**

ไม่. การขัดจังหวะทำงานแบบร่วมมือ: การดำเนินการจะตรวจสอบโทเค็นเป็นระยะและหยุดทันทีเมื่อพบว่ามีการเรียก [Interrupt()](https://reference.aspose.com/slides/th/java/com.aspose.slides/interruptiontokensource/#interrupt--).

**จะเกิดอะไรขึ้นถ้าฉันเรียก [Interrupt()](https://reference.aspose.com/slides/th/java/com.aspose.slides/interruptiontokensource/#interrupt--) หลังจากงานเสร็จแล้ว?**

ไม่มีอะไรเกิดขึ้น—การเรียกนี้ไม่มีผลหากงานที่เกี่ยวข้องได้เสร็จสิ้นแล้ว.

**ฉันสามารถใช้ [InterruptionTokenSource](https://reference.aspose.com/slides/th/java/com.aspose.slides/interruptiontokensource/) เดียวกันสำหรับหลายงานได้หรือไม่?**

ได้—แต่หลังจากที่คุณเรียก [Interrupt()](https://reference.aspose.com/slides/th/java/com.aspose.slides/interruptiontokensource/#interrupt--) บนแหล่งนั้น งานทั้งหมดที่ใช้โทเค็นของมันจะถูกขัดจังหวะ. ควรใช้แหล่งโทเค็นแยกต่างหากเพื่อจัดการงานอย่างอิสระ.