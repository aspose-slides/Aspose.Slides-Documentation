---
title: เพิ่มสไลด์ลงในงานนำเสนอด้วย Java
linktitle: เพิ่มสไลด์
type: docs
weight: 10
url: /th/java/add-slide-to-presentation/
keywords:
- เพิ่มสไลด์
- สร้างสไลด์
- สไลด์เปล่า
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่มสไลด์ในงานนำเสนอ PowerPoint และ OpenDocument ของคุณได้อย่างง่ายดายด้วย Aspose.Slides for Java—การแทรกสไลด์ที่ราบรื่นและมีประสิทธิภาพภายในไม่กี่วินาที."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเพิ่มสไลด์ลงในงานนำเสนอ PowerPoint โดยอัตโนมัติ งานนำเสนอประกอบด้วยสไลด์ Master/Layout และสไลด์ปกติ โดยสไลด์ปกติจะถูกจัดเรียงตามดัชนีเริ่มจากศูนย์ แต่ละสไลด์มี ID ที่ไม่ซ้ำกัน และไฟล์งานนำเสนอที่ไม่มีสไลด์จะไม่รองรับ

บทความนี้อธิบายวิธีสร้างอ็อบเจกต์ `Presentation` การเข้าถึงคอลเลกชันสไลด์ การเพิ่มสไลด์เปล่า การทำงานกับสไลด์ที่เพิ่งเพิ่มใหม่ และการบันทึกงานนำเสนอที่อัปเดต รวมถึงหัวข้อที่เกี่ยวข้อง เช่น การแทรกสไลด์ในตำแหน่งเฉพาะ การใช้เลเอาต์ และการทำความเข้าใจสไลด์เปล่าที่มีอยู่ในงานนำเสนอใหม่ที่สร้างขึ้น

## **เพิ่มสไลด์ลงในงานนำเสนอ**

ก่อนจะพูดถึงการเพิ่มสไลด์ในไฟล์งานนำเสนอ เรามาพิจารณาข้อเท็จจริงเกี่ยวกับสไลด์กันก่อน งานนำเสนอ PowerPoint ใด ๆ จะมีสไลด์ **Master / Layout** และสไลด์ **Normal** อื่น ๆ หมายความว่าไฟล์งานนำเสนอจะต้องมีสไลด์อย่างน้อยหนึ่งสไลด์หรือมากกว่านั้น ซึ่งไฟล์งานนำเสนอที่ไม่มีสไลด์จะไม่รองรับโดย Aspose.Slides for Java แต่ละสไลด์มี Id ที่ไม่ซ้ำกันและสไลด์ Normal ทั้งหมดจะถูกจัดเรียงตามดัชนีเริ่มจากศูนย์

Aspose.Slides for Java อนุญาตให้ผู้พัฒนาเพิ่มสไลด์เปล่าในงานนำเสนอของตน เพื่อเพิ่มสไลด์เปล่าในงานนำเสนอ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) 
- สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection) โดยตั้งค่าอ้างอิงไปยังคุณสมบัติ [Slides](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation#getSlides--) (คอลเลกชันของอ็อบเจกต์ Slide) ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) 
- เพิ่มสไลด์เปล่าลงในงานนำเสนอที่ตำแหน่งท้ายของคอลเลกชันสไลด์เนื้อหาโดยเรียกเมธอด [**addEmptySlide**](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) ที่เปิดเผยโดยอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/ISlideCollection) 
- ทำงานบางอย่างกับสไลด์เปล่าที่เพิ่งเพิ่มใหม่ 
- สุดท้ายให้บันทึกไฟล์งานนำเสนอโดยใช้อ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) 

```java
// สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
Presentation pres = new Presentation();
try {
    // สร้างอ็อบเจกต์ SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // เพิ่มสไลด์เปล่าลงในคอลเลกชัน Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // ทำงานบางอย่างกับสไลด์ที่เพิ่งเพิ่มใหม่

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแทรกสไลด์ใหม่ในตำแหน่งที่เฉพาะเจาะจงได้หรือไม่ ไม่ใช่แค่ที่ส่วนท้าย?**

ใช่ ไลบรารีรองรับคอลเลกชันสไลด์และการทำงาน [insert](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) ดังนั้นคุณสามารถเพิ่มสไลด์ที่ดัชนีที่ต้องการได้ ไม่จำกัดแค่ส่วนท้าย

**ธีม/สไตล์จะคงไว้เมื่อเพิ่มสไลด์โดยใช้เลเอาต์หรือไม่?**

ใช่ เลเอาต์จะสืบทอดการจัดรูปแบบจากมาสเตอร์ของมัน และสไลด์ใหม่จะสืบทอดจากเลเอาต์ที่เลือกและมาสเตอร์ที่เชื่อมโยงกับเลเอาต์นั้น

**สไลด์ใดที่อยู่ในงานนำเสนอ “เปล่า” ใหม่ก่อนที่จะเพิ่มสไลด์?**

งานนำเสนอที่สร้างใหม่จะมีสไลด์เปล่าหนึ่งสไลด์ที่ดัชนีศูนย์อยู่แล้ว สิ่งนี้สำคัญเมื่อคำนวณดัชนีการแทรก

**ฉันจะเลือกเลเอาต์ “ที่เหมาะสม” สำหรับสไลด์ใหม่เมื่อมาสเตอร์มีตัวเลือกหลายแบบอย่างไร?**

โดยทั่วไปให้เลือก [LayoutSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/layoutslide/) ที่ตรงกับโครงสร้างที่ต้องการ (เช่น Title and Content, Two Content ฯลฯ) หากไม่มีเลเอาต์ดังกล่าว คุณสามารถ [add it to the master](/slides/th/java/slide-layout/) แล้วใช้เลเอาต์นั้นต่อไป