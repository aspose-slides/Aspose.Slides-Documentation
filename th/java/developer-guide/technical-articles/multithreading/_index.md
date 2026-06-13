---
title: การทำงานหลายเธรดใน Aspose.Slides สำหรับ Java
linktitle: การทำงานหลายเธรด
type: docs
weight: 310
url: /th/java/multithreading/
keywords:
- การทำงานหลายเธรด
- หลายเธรด
- งานขนาน
- แปลงสไลด์
- สไลด์เป็นภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "การทำงานหลายเธรดใน Aspose.Slides สำหรับ Java ช่วยเพิ่มประสิทธิภาพการประมวลผล PowerPoint และ OpenDocument ค้นหาวิธีปฏิบัติที่ดีที่สุดสำหรับการทำงานกับการนำเสนออย่างมีประสิทธิภาพ."
---
## **บทนำ**

ในขณะที่การทำงานขนานกับงานนำเสนอเป็นไปได้ (นอกเหนือจากการแยกวิเคราะห์/โหลด/คัดลอก) และทุกอย่างทำได้ดี (ส่วนใหญ่) มีโอกาสเล็กน้อยที่คุณอาจได้รับผลลัพธ์ที่ไม่ถูกต้องเมื่อใช้ไลบรารีในหลายเธรด

เราขอแนะนำอย่างแรงกล้าว่า **ไม่** ใช้ instance ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) เพียงหนึ่งตัวในสภาพแวดล้อมการทำงานหลายเธรด เพราะอาจทำให้เกิดข้อผิดพลาดหรือความล้มเหลวที่ไม่สามารถคาดเดาได้และตรวจพบยาก

ไม่ปลอดภัยที่จะโหลด, บันทึก, และ/หรือคัดลอก instance ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ในหลายเธรด การดำเนินงานเช่นนี้ **ไม่** ได้รับการสนับสนุน หากคุณจำเป็นต้องทำเช่นนั้น คุณต้องทำงานแบบขนานโดยใช้หลายกระบวนการที่ทำงานแบบเดียวต่อหนึ่งเธรด — และแต่ละกระบวนการควรใช้ instance ของงานนำเสนอของตนเอง

## **แปลงสไลด์งานนำเสนอเป็นภาพแบบขนาน**

สมมติว่าเราต้องการแปลงสไลด์ทั้งหมดจากงานนำเสนอ PowerPoint ให้เป็นภาพ PNG แบบขนาน เนื่องจากไม่ปลอดภัยที่จะใช้ `Presentation` ตัวเดียวในหลายเธรด เราจึงแยกสไลด์งานนำเสนอเป็นงานนำเสนอแยกส่วนและแปลงสไลด์เป็นภาพแบบขนาน โดยใช้แต่ละงานนำเสนอในเธรดแยกกัน ตัวอย่างโค้ดต่อไปนี้แสดงวิธีทำ

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // ดึงสไลด์ i ออกเป็นงานนำเสนอแยก.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // แปลงสไลด์เป็นภาพในงานที่แยกกัน.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// รอให้ทุกงานเสร็จสมบูรณ์.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **คำถามที่พบบ่อย**

**ฉันต้องเรียกตั้งค่าใบอนุญาตในทุกเธรดหรือไม่?**

ไม่ จำเป็นต้องทำแค่ครั้งเดียวต่อกระบวนการ/โดเมนแอป ก่อนที่เธรดจะเริ่ม หาก [license setup](/slides/th/java/licensing/) อาจถูกเรียกใช้งานพร้อมกัน (เช่น ในระหว่างการเริ่มต้นแบบขี้เกียจ) ให้ซิงโครไนซ์การเรียกนั้นเนื่องจากเมธอดตั้งค่าใบอนุญาตเองไม่มีความปลอดภัยต่อหลายเธรด

**ฉันสามารถส่ง `Presentation` หรือ `Slide` ระหว่างเธรดได้หรือไม่?**

ไม่แนะนำให้ส่งออบเจกต์งานนำเสนอแบบ “live” ระหว่างเธรด: ควรใช้ instance แยกกันต่อแต่ละเธรดหรือสร้างงานนำเสนอ/คอนเทนเนอร์สไลด์แยกไว้ล่วงหน้าสำหรับแต่ละเธรด วิธีนี้สอดคล้องกับคำแนะนำทั่วไปคือไม่ควรแชร์ instance งานนำเสนอเดียวกันข้ามเธรด

**การทำงานส่งออกเป็นรูปแบบต่าง ๆ (PDF, HTML, images) แบบขนานปลอดภัยหรือไม่ หากแต่ละเธรดมี `Presentation` ของตนเอง?**

ใช่ เมื่อมี instance ที่แยกออกจากกันและเส้นทางผลลัพธ์ที่ต่างกัน งานเหล่านี้มักจะทำงานแบบขนานได้อย่างถูกต้อง; หลีกเลี่ยงการแชร์ออบเจกต์งานนำเสนอและสตรีม I/O ที่ใช้ร่วมกัน

**ควรทำอย่างไรกับการตั้งค่าแบบอักษรระดับโลก (โฟลเดอร์, การทดแทน) ในการทำงานหลายเธรด?**

ให้ทำการเริ่มต้น [font settings](/slides/th/java/powerpoint-fonts/) ทั้งหมดก่อนเริ่มเธรดและหลีกเลี่ยงการเปลี่ยนแปลงระหว่างการทำงานแบบขนาน ซึ่งจะขจัดการแข่งขันเมื่อเข้าถึงทรัพยากรฟอนต์ที่แชร์