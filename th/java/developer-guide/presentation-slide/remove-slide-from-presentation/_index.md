---
title: ลบสไลด์จากงานนำเสนอใน Java
linktitle: ลบสไลด์
type: docs
weight: 30
url: /th/java/remove-slide-from-presentation/
keywords:
- ลบสไลด์
- ลบสไลด์
- ลบสไลด์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ลบสไลด์จากการนำเสนอ PowerPoint และ OpenDocument ได้อย่างง่ายดายด้วย Aspose.Slides for Java. รับตัวอย่างโค้ดที่ชัดเจนและเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **บทนำ**

หากสไลด์ (หรือเนื้อหาภายใน) กลายเป็นซ้ำซ้อน คุณสามารถลบมันได้ Aspose.Slides มีคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) ที่รวบรวม [ISlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/islidecollection/) ซึ่งเป็นที่เก็บของสไลด์ทั้งหมดในงานนำเสนอ โดยใช้ตัวชี้ (อ้างอิงหรือดัชนี) ของอ็อบเจ็กต์ [ISlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/) ที่ทราบ คุณสามารถระบุสไลด์ที่ต้องการลบได้  

## **ลบสไลด์โดยอ้างอิง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)  
1. รับอ้างอิงของสไลด์ที่ต้องการลบโดยใช้ ID หรือ Index ของมัน  
1. ลบสไลด์ที่อ้างอิงออกจากงานนำเสนอ  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java นี้แสดงวิธีลบสไลด์โดยอ้างอิง:

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แสดงไฟล์งานนำเสนอ
Presentation pres = new Presentation("demo.pptx");
try {
    // เข้าถึงสไลด์ผ่านดัชนีในคอลเลกชันสไลด์
    ISlide slide = pres.getSlides().get_Item(0);
    
    // ลบสไลด์ผ่านการอ้างอิงของมัน
    pres.getSlides().remove(slide);
    
    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **ลบสไลด์โดยตำแหน่ง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)  
1. ลบสไลด์จากงานนำเสนอโดยใช้ตำแหน่งดัชนีของมัน  
1. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java นี้แสดงวิธีลบสไลด์โดยตำแหน่ง:

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แสดงไฟล์งานนำเสนอ
Presentation pres = new Presentation("demo.pptx");
try {
    // ลบสไลด์ผ่านดัชนีสไลด์ของมัน
    pres.getSlides().removeAt(0);
    
    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **ลบสไลด์เค้าโครงที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (จากคลาส [Compress](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/)) เพื่อให้คุณสามารถลบสไลด์เค้าโครงที่ไม่ต้องการและไม่ได้ใช้ โค้ด Java นี้แสดงวิธีลบสไลด์เค้าโครงจากงานนำเสนอ PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [removeUnusedMasterSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (จากคลาส [Compress](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/)) เพื่อให้คุณสามารถลบมาสเตอร์สไลด์ที่ไม่ต้องการและไม่ได้ใช้ โค้ด Java นี้แสดงวิธีลบมาสเตอร์สไลด์จากงานนำเสนอ PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **คำถามที่พบบ่อย**

**ดัชนีของสไลด์จะเกิดอะไรขึ้นหลังจากที่ฉันลบสไลด์?**  

หลังจากลบแล้ว [collection](https://reference.aspose.com/slides/th/java/com.aspose.slides/slidecollection/) จะทำการจัดดัชนีใหม่: สไลด์ต่อมาทุกสไลด์จะเลื่อนตำแหน่งไปทางซ้ายหนึ่งตำแหน่ง, ดังนั้นหมายเลขดัชนีก่อนหน้าจะล้าสมัย หากคุณต้องการอ้างอิงที่คงที่ ให้ใช้ ID ถาวรของสไลด์แทนการใช้ดัชนี  

**ID ของสไลด์ต่างจากดัชนีหรือไม่, และมันเปลี่ยนแปลงเมื่อสไลด์โดยรอบถูกลบหรือไม่?**  

ใช่. ดัชนีเป็นตำแหน่งของสไลด์และจะเปลี่ยนเมื่อมีการเพิ่มหรือเอาสไลด์ออก. ส่วน ID ของสไลด์เป็นตัวระบุถาวรและจะไม่เปลี่ยนเมื่อสไลด์อื่นถูกลบ  

**การลบสไลด์มีผลต่อส่วนของสไลด์อย่างไร?**  

หากสไลด์เป็นส่วนหนึ่งของเซคชัน, เซคชันนั้นจะมีสไลด์ลดลงหนึ่งสไลด์ โครงสร้างของเซคชันยังคงอยู่; หากเซคชันว่างเปล่า, คุณสามารถ [remove or reorganize sections](/slides/th/java/slide-section/) ตามต้องการ  

**บันทึกและความคิดเห็นที่แนบกับสไลด์จะเกิดอะไรขึ้นเมื่อสไลด์ถูกลบ?**  

[Notes](/slides/th/java/presentation-notes/) และ [comments](/slides/th/java/presentation-comments/) ถูกผูกกับสไลด์นั้นและจะถูกลบพร้อมกับสไลด์นั้น เนื้อหาบนสไลด์อื่นจะไม่ได้รับผลกระทบ  

**การลบสไลด์แตกต่างจากการทำความสะอาดเลเอาต์/มาสเตอร์ที่ไม่ได้ใช้อย่างไร?**  

การลบจะกำจัดสไลด์ปกติที่เฉพาะเจาะจงออกจากเด็ค. การทำความสะอาดเลเอาต์/มาสเตอร์ที่ไม่ได้ใช้จะลบสไลด์เค้าโครงหรือมาสเตอร์ที่ไม่มีการอ้างอิงใดๆ, ลดขนาดไฟล์โดยไม่เปลี่ยนแปลงเนื้อหาของสไลด์ที่เหลืออยู่ การกระทำเหล่านี้เสริมกัน: ปกติจะลบก่อนแล้วจึงทำความสะอาด.