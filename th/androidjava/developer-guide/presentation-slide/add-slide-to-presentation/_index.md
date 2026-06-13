---
title: เพิ่มสไลด์ให้กับงานนำเสนอบน Android
linktitle: เพิ่มสไลด์
type: docs
weight: 10
url: /th/androidjava/add-slide-to-presentation/
keywords:
- เพิ่มสไลด์
- สร้างสไลด์
- สไลด์เปล่า
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่มสไลด์ในงานนำเสนอ PowerPoint และ OpenDocument ของคุณได้อย่างง่ายดายด้วย Aspose.Slides for Android via Java—การแทรกสไลด์ที่ราบรื่นและมีประสิทธิภาพภายในไม่กี่วินาที"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถเพิ่มสไลด์ในงานนำเสนอ PowerPoint ด้วยโปรแกรมได้ งานนำเสนอประกอบด้วยสไลด์ Master/Layout และสไลด์แบบปกติ, โดยสไลด์แบบปกติจะเรียงตามดัชนีที่เริ่มจากศูนย์ แต่ละสไลด์มี ID เอกลักษณ์, และไฟล์งานนำเสนอที่ไม่มีสไลด์จะไม่ได้รับการสนับสนุน

บทความนี้อธิบายวิธีสร้างอ็อบเจกต์ `Presentation`, เข้าถึงคอลเลกชันสไลด์, เพิ่มสไลด์เปล่า, ทำงานกับสไลด์ใหม่ที่เพิ่มเข้าไป, และบันทึกงานนำเสนอที่อัปเดต นอกจากนี้ยังครอบคลุมประเด็นที่เกี่ยวข้อง เช่น การแทรกสไลด์ในตำแหน่งที่กำหนด, การใช้เลเอาต์, และความเข้าใจเกี่ยวกับสไลด์ว่างที่มีอยู่ในงานนำเสนอที่สร้างใหม่

## **เพิ่มสไลด์ในงานนำเสนอ**

ก่อนที่จะพูดถึงการเพิ่มสไลด์ในไฟล์งานนำเสนอ, ให้เราพิจารณาความจริงบางประการเกี่ยวกับสไลด์ แต่ละไฟล์งานนำเสนอ PowerPoint จะมีสไลด์ **Master / Layout** และสไลด์ **Normal** อื่น ๆ หมายความว่าไฟล์งานนำเสนอจะต้องมีสไลด์อย่างน้อยหนึ่งสไลด์หรือมากกว่า สิ่งสำคัญคือต้องทราบว่าไฟล์งานนำเสนอที่ไม่มีสไลด์จะไม่ได้รับการสนับสนุนโดย Aspose.Slides for Android via Java แต่ละสไลด์มี Id ที่ไม่ซ้ำกันและสไลด์ Normal ทั้งหมดจะถูกจัดเรียงตามลำดับที่กำหนดโดยดัชนีที่เริ่มจากศูนย์

Aspose.Slides for Android via Java อนุญาตให้ผู้พัฒนาสามารถเพิ่มสไลด์เปล่าในงานนำเสนอของตนได้ เพื่อเพิ่มสไลด์เปล่าในงานนำเสนอ, โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
- สร้างอินสแตนซ์ของคลาส [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection) โดยอ้างอิงถึงคุณสมบัติ [Slides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation#getSlides--) (คอลเลกชันของอ็อบเจกต์ Slide) ที่เผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
- เพิ่มสไลด์เปล่าลงในงานนำเสนอที่ตำแหน่งสุดท้ายของคอลเลกชันสไลด์เนื้อหาโดยเรียกใช้เมธอด [**addEmptySlide**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) ที่เผยโดยอ็อบเจกต์ [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ISlideCollection)
- ทำงานบางอย่างกับสไลด์เปล่าที่เพิ่มเข้าไปใหม่
- สุดท้าย, เขียนไฟล์งานนำเสนอโดยใช้อ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
Presentation pres = new Presentation();
try {
    // สร้างอินสแตนซ์ของคลาส SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // เพิ่มสไลด์เปล่าลงในคอลเลกชัน Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // ทำงานบางอย่างกับสไลด์ที่เพิ่มใหม่

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแทรกสไลด์ใหม่ในตำแหน่งที่ระบุได้หรือไม่, ไม่ใช่แค่ที่ท้ายสุด?**

ใช่. ไลบรารีรองรับคอลเลกชันสไลด์และการดำเนินการ [insert](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) ดังนั้นคุณสามารถเพิ่มสไลด์ที่ดัชนีที่ต้องการได้ ไม่จำกัดแค่ที่ท้ายสุด

**ธีมหรือสไตล์จะคงเดิมเมื่อเพิ่มสไลด์โดยอิงจากเลเอาต์หรือไม่?**

ใช่. เลเอาต์สืบทอดการจัดรูปแบบจากมาสเตอร์ของมัน, และสไลด์ใหม่จะสืบทอดจากเลเอาต์ที่เลือกและมาสเตอร์ที่เกี่ยวข้อง

**สไลด์ใดอยู่ในงานนำเสนอที่สร้างใหม่และว่างเปล่าก่อนที่จะเพิ่มสไลด์?**

งานนำเสนอที่สร้างใหม่จะมีสไลด์ว่างหนึ่งสไลด์อยู่แล้วโดยมีดัชนีศูนย์ สิ่งนี้สำคัญต่อการคำนวณดัชนีการแทรก

**ฉันจะเลือกเลเอาต์ที่ "ถูกต้อง" สำหรับสไลด์ใหม่ได้อย่างไรหาก Master มีตัวเลือกหลายอย่าง?**

โดยทั่วไปให้เลือก [LayoutSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/layoutslide/) ที่ตรงกับโครงสร้างที่ต้องการ ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidelayouttype/)) หากไม่มีเลเอาต์ดังกล่าว, คุณสามารถ [add it to the master](/slides/th/androidjava/slide-layout/) แล้วนำไปใช้ได้