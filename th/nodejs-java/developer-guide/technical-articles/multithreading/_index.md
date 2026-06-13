---
title: การทำงานหลายเธรดใน Aspose.Slides สำหรับ Node.js ผ่าน Java
linktitle: การทำงานหลายเธรด
type: docs
weight: 310
url: /th/nodejs-java/multithreading/
keywords:
- การทำงานหลายเธรด
- หลายเธรด
- งานแบบขนาน
- แปลงสไลด์
- สไลด์เป็นภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "การทำงานหลายเธรดใน Aspose.Slides สำหรับ Node.js ผ่าน Java ช่วยเพิ่มประสิทธิภาพการประมวลผล PowerPoint และ OpenDocument ค้นหาวิธีปฏิบัติที่ดีที่สุดสำหรับกระบวนการทำงานการนำเสนอที่มีประสิทธิภาพ"
---
## **บทนำ**

แม้ว่าการทำงานแบบขนานกับการนำเสนอจะเป็นไปได้ (นอกเหนือจากการแยกวิเคราะห์/โหลด/สำเนา) และโดยส่วนใหญ่จะทำงานได้อย่างราบรื่น แต่ก็อาจมีโอกาสเล็กน้อยที่ผลลัพธ์จะไม่ถูกต้องเมื่อใช้ไลบรารีในหลายเธรดพร้อมกัน

เราขอแนะนำอย่างยิ่งว่า **ไม่** ควรใช้อ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ตัวเดียวในสภาพแวดล้อมแบบหลายเธรด เพราะอาจทำให้เกิดข้อผิดพลาดหรือความล้มเหลวที่คาดเดาไม่ได้และตรวจจับยาก

การโหลด, บันทึก, และ/หรือสำเนาอ็อบเจกต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ในหลายเธรด **ไม่** ปลอดภัย การดำเนินการดังกล่าว **ไม่ได้** รองรับ หากคุณต้องการทำงานเหล่านี้ คุณต้องทำงานแบบขนานโดยใช้หลายกระบวนการที่ทำงานแบบเดี่ยวเธรด และแต่ละกระบวนการควรใช้อินสแตนซ์ Presentation ของตนเอง

## **แปลงสไลด์ของ Presentation เป็นภาพพร้อมกัน**

สมมติว่าเราต้องการแปลงสไลด์ทั้งหมดจากไฟล์ PowerPoint เป็นภาพ PNG แบบขนาน เนื่องจากการใช้อินสแตนซ์ `Presentation` ตัวเดียวในหลายเธรดไม่ปลอดภัย เราจะแบ่งสไลด์ออกเป็น Presentation แยกกันและแปลงสไลด์เป็นภาพพร้อมกันโดยใช้แต่ละ Presentation ในเธรดแยกต่างหาก โค้ดตัวอย่างต่อไปนี้แสดงวิธีทำ

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // แยกสไลด์ i ไปเป็นการนำเสนอแยก
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // รอให้ทุกงานเสร็จสมบูรณ์
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **FAQ**

**จำเป็นต้องเรียกตั้งค่าลิขสิทธิ์ในแต่ละเธรดหรือไม่?**

ไม่จำเป็น เพียงตั้งค่า一次ต่อกระบวนการ/โดเมนแอปพลิเคชันก่อนที่เธรดจะเริ่มทำงาน หาก [การตั้งค่าลิขสิทธิ์](/slides/th/nodejs-java/licensing/) อาจถูกเรียกใช้พร้อมกัน (เช่น ระหว่างการเริ่มต้นแบบ lazy) ให้ทำการซิงโครไนซ์การเรียกนั้นเนื่องจากเมธอดตั้งค่าลิขสิทธิ์เองไม่เป็น thread‑safe

**ฉันสามารถส่งอ็อบเจกต์ `Presentation` หรือ `Slide` ระหว่างเธรดได้หรือไม่?**

ไม่แนะนำให้ส่งอ็อบเจกต์ Presentation ที่กำลังทำงานอยู่ระหว่างเธรด: ควรใช้อินสแตนซ์แยกกันต่อเธรดหรือสร้าง Presentation/Slide แยกไว้ล่วงหน้าสำหรับแต่ละเธรด วิธีนี้สอดคล้องกับคำแนะนำทั่วไปไม่ให้แชร์อินสแตนซ์ Presentation เพียงตัวเดียวข้ามเธรด

**การทำงานขนานเพื่อส่งออกเป็นฟอร์แมตต่าง ๆ (PDF, HTML, images) ปลอดภัยหรือไม่ หากแต่ละเธรดมีอินสแตนซ์ `Presentation` ของตนเอง?**

ปลอดภัย เมื่อใช้อินสแตนซ์แยกจากกันและกำหนดเส้นทางเอาต์พุตแยกต่างหาก งานเหล่านี้มักจะทำงานขนานได้อย่างถูกต้อง; เพียงหลีกเลี่ยงการแชร์อ็อบเจกต์ Presentation และสตรีม I/O ร่วมกัน

**ควรทำอย่างไรกับการตั้งค่าแบบอักษรระดับโลก (โฟลเดอร์, การแทนที่) ในหลายเธรด?**

ให้เริ่มต้นการตั้งค่าแบบอักษรระดับโลกทั้งหมดก่อนที่จะสตาร์ทเธรดและไม่เปลี่ยนแปลงในการทำงานแบบขนาน วิธีนี้จะขจัดการแข่งกันเมื่อเข้าถึงทรัพยากรแบบอักษรร่วมกัน