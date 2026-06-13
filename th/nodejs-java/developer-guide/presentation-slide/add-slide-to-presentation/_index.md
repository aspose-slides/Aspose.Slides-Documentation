---
title: เพิ่มสไลด์ไปยังงานนำเสนอใน JavaScript
linktitle: เพิ่มสไลด์
type: docs
weight: 10
url: /th/nodejs-java/add-slide-to-presentation/
keywords:
- เพิ่มสไลด์
- สร้างสไลด์
- สไลด์ว่าง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เพิ่มสไลด์ลงในงานนำเสนอ PowerPoint และ OpenDocument ของคุณได้อย่างง่ายดายด้วย Aspose.Slides for Node.js via Java — การแทรกสไลด์ที่ราบรื่นและมีประสิทธิภาพภายในไม่กี่วินาที."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถเพิ่มสไลด์ไปยังงานนำเสนอ PowerPoint ได้โดยอัตโนมัติ งานนำเสนอประกอบด้วยสไลด์ Master / Layout และสไลด์ปกติ โดยสไลด์ปกติจะเรียงลำดับตามดัชนีที่เริ่มจากศูนย์ แต่ละสไลด์มี ID ที่เป็นเอกลักษณ์ และไฟล์งานนำเสนอที่ไม่มีสไลด์จะไม่ได้รับการสนับสนุน

บทความนี้อธิบายวิธีสร้างอ็อบเจกต์ `Presentation` การเข้าถึงคอลเลกชันสไลด์ การเพิ่มสไลด์ว่าง การทำงานกับสไลด์ที่เพิ่มใหม่ และการบันทึกงานนำเสนอที่อัปเดต นอกจากนี้ยังครอบคลุมประเด็นที่เกี่ยวข้องเช่น การแทรกสไลด์ในตำแหน่งที่ระบุ การใช้เลย์เอาต์ และการเข้าใจสไลด์ว่างที่มีอยู่ในงานนำเสนอที่สร้างขึ้นใหม่

## **เพิ่มสไลด์ไปยังงานนำเสนอ**

ก่อนจะพูดถึงการเพิ่มสไลด์ไปยังไฟล์งานนำเสนอ เรามาอธิบายข้อเท็จจริงเกี่ยวกับสไลด์กันก่อนแต่ละไฟล์งานนำเสนอ PowerPoint มีสไลด์ **Master / Layout** และสไลด์ **Normal** อื่น ๆ หมายความว่าไฟล์งานนำเสนอจะต้องมีอย่างน้อยหนึ่งสไลด์ขึ้นไป สิ่งสำคัญคือต้องทราบว่าไฟล์งานนำเสนอที่ไม่มีสไลด์ไม่รองรับโดย Aspose.Slides for Node.js via Java แต่ละสไลด์มี Id ที่เป็นเอกลักษณ์และสไลด์ Normal ทั้งหมดจะถูกจัดเรียงตามดัชนีที่เริ่มจากศูนย์

Aspose.Slides for Node.js via Java อนุญาตให้ผู้พัฒนาสามารถเพิ่มสไลด์ว่างลงในงานนำเสนอของตนได้ โดยทำตามขั้นตอนต่อไปนี้เพื่อเพิ่มสไลด์ว่างในงานนำเสนอ:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) 
- สร้างอินสแตนซ์ของคลาส [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection) โดยตั้งค่าอ้างอิงไปยังคุณสมบัติ [Slides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) (คอลเลกชันของอ็อบเจกต์ Slide ที่เป็นเนื้อหา) ที่เปิดให้ใช้โดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) 
- เพิ่มสไลด์ว่างไปยังงานนำเสนอที่ส่วนท้ายของคอลเลกชันสไลด์เนื้อหาโดยเรียกใช้เมธอด [**addEmptySlide**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) ที่เปิดให้ใช้โดยอ็อบเจกต์ [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection) 
- ทำการกระทำบางอย่างกับสไลด์ว่างที่เพิ่มใหม่ 
- สุดท้าย ให้บันทึกไฟล์งานนำเสนอโดยใช้วัตถุ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) 

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation();
try {
    // สร้างอินสแตนซ์ของคลาส SlideCollection
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // เพิ่มสไลด์ว่างไปยังคอลเลกชัน Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // ทำการทำงานบางอย่างกับสไลด์ที่เพิ่งเพิ่ม
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแทรกสไลด์ใหม่ในตำแหน่งที่ต้องการได้หรือไม่ ไม่ใช่แค่ที่ส่วนท้าย?**

ใช่ ไลบรารีสนับสนุนคอลเลกชันสไลด์และการดำเนินการ [insert]/[clone] ดังนั้นคุณสามารถเพิ่มสไลด์ที่ดัชนีที่ต้องการแทนที่จะเพิ่มเฉพาะที่ส่วนท้าย

**รูปแบบ/สไตล์จะคงไว้เมื่อเพิ่มสไลด์โดยอิงจากเลย์เอาต์หรือไม่?**

ใช่ เลย์เอาต์สืบทอดการฟอร์แมตจากมาสเตอร์ของมัน และสไลด์ใหม่จะสืบทอดจากเลย์เอาต์ที่เลือกและมาสเตอร์ที่เชื่อมโยงกับมัน

**สไลด์ใดอยู่ในงานนำเสนอ "ว่าง" ใหม่ก่อนที่จะเพิ่มสไลด์?**

งานนำเสนอที่สร้างใหม่จะมีสไลด์ว่างหนึ่งสไลด์ที่ตำแหน่งดัชนีศูนย์อยู่แล้ว สิ่งนี้สำคัญเมื่อคำนวณดัชนีการแทรก

**ฉันจะเลือกเลย์เอาต์ที่ "เหมาะสม" สำหรับสไลด์ใหม่ได้อย่างไร หากมาสเตอร์มีตัวเลือกมากมาย?**

โดยทั่วไปให้เลือก [LayoutSlide] ที่ตรงกับโครงสร้างที่ต้องการ ([Title and Content, Two Content, เป็นต้น]) หากไม่มีเลย์เอาต์ดังกล่าว คุณสามารถ [เพิ่มไปยังมาสเตอร์](/slides/th/nodejs-java/slide-layout/) แล้วใช้งานได้