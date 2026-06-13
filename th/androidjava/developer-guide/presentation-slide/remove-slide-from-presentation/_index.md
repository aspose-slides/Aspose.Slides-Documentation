---
title: ลบสไลด์จากพรีเซนเทชันบน Android
linktitle: ลบสไลด์
type: docs
weight: 30
url: /th/androidjava/remove-slide-from-presentation/
keywords:
- ลบสไลด์
- ลบสไลด์ออก
- ลบสไลด์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: "ลบสไลด์จากพรีเซนเทชัน PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ Android. รับตัวอย่างโค้ด Java ที่ชัดเจนและเพิ่มประสิทธิภาพการทำงานของคุณ."
---
## **คำนำ**

หากสไลด์ (หรือเนื้อหาภายใน) ซ้ำซ้อน คุณสามารถลบออกได้ Aspose.Slides มีคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ที่บรรจุ [ISlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islidecollection/) ซึ่งเป็นที่เก็บสไลด์ทั้งหมดในพรีเซนเทชัน โดยใช้ตัวชี้ (อ้างอิงหรือดัชนี) ของวัตถุ [ISlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/) ที่ทราบ คุณสามารถระบุสไลด์ที่ต้องการลบได้

## **ลบสไลด์โดยอ้างอิง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
1. รับอ้างอิงของสไลด์ที่ต้องการลบผ่าน ID หรือ Index ของมัน  
1. ลบสไลด์ที่อ้างอิงจากพรีเซนเทชัน  
1. บันทึกพรีเซนเทชันที่แก้ไขแล้ว  

โค้ด Java นี้แสดงวิธีการลบสไลด์ผ่านอ้างอิงของมัน:

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("demo.pptx");
try {
    // เข้าถึงสไลด์ผ่านดัชนีในคอลเล็กชันสไลด์
    ISlide slide = pres.getSlides().get_Item(0);
    
    // ลบสไลด์ผ่านอ้างอิงของมัน
    pres.getSlides().remove(slide);
    
    // บันทึกพรีเซนเทชันที่แก้ไขแล้ว
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **ลบสไลด์ตามดัชนี**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
1. ลบสไลด์จากพรีเซนเทชันผ่านตำแหน่งดัชนีของมัน  
1. บันทึกพรีเซนเทชันที่แก้ไขแล้ว  

โค้ด Java นี้แสดงวิธีการลบสไลด์ผ่านดัชนีของมัน:

```java
// สร้างอ็อบเจ็กต์ Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("demo.pptx");
try {
    // ลบสไลด์ผ่านดัชนีสไลด์ของมัน
    pres.getSlides().removeAt(0);
    
    // บันทึกพรีเซนเทชันที่แก้ไขแล้ว
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **ลบสไลด์เค้าโครงที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (จากคลาส [Compress](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/)) เพื่อให้คุณสามารถลบสไลด์เค้าโครงที่ไม่ต้องการและไม่ได้ใช้ได้ โค้ด Java นี้แสดงวิธีการลบสไลด์เค้าโครงจากพรีเซนเทชัน PowerPoint:

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

Aspose.Slides มีเมธอด [removeUnusedMasterSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (จากคลาส [Compress](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/)) เพื่อให้คุณสามารถลบสไลด์มาสเตอร์ที่ไม่ต้องการและไม่ได้ใช้ได้ โค้ด Java นี้แสดงวิธีการลบสไลด์มาสเตอร์จากพรีเซนเทชัน PowerPoint:

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

**อะไรเกิดขึ้นกับดัชนีของสไลด์หลังจากที่ฉันลบสไลด์?**

หลังจากการลบ, [collection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/slidecollection/) จะจัดดัชนีใหม่: ทุกสไลด์ถัดไปจะเลื่อนซ้ายหนึ่งตำแหน่ง ดังนั้นหมายเลขดัชนีก่อนหน้าจะล้าสมัย หากคุณต้องการอ้างอิงที่คงที่, ใช้ ID คงที่ของแต่ละสไลด์แทนดัชนีของมัน

**ID ของสไลด์แตกต่างจากดัชนีหรือไม่, และมันเปลี่ยนเมื่อสไลด์ข้างเคียงถูกลบหรือไม่?**

ใช่ ดัชนีเป็นตำแหน่งของสไลด์และจะเปลี่ยนเมื่อสไลด์ถูกเพิ่มหรือเอาออก ส่วน ID ของสไลด์เป็นตัวระบุคงที่และจะไม่เปลี่ยนเมื่อสไลด์อื่นถูกลบ

**การลบสไลด์ส่งผลต่อส่วนของสไลด์อย่างไร?**

หากสไลด์อยู่ในส่วนใดส่วนหนึ่ง ส่วนนั้นจะมีสไลด์น้อยลงหนึ่งสไลด์ โครงสร้างส่วนยังคงอยู่; หากส่วนหนึ่งว่างเปล่า คุณสามารถ [remove or reorganize sections](/slides/th/androidjava/slide-section/) ตามต้องการ

**สิ่งที่เกิดขึ้นกับโน้ตและความคิดเห็นที่แนบกับสไลด์เมื่อมันถูกลบคืออะไร?**

[Notes](/slides/th/androidjava/presentation-notes/) และ [comments](/slides/th/androidjava/presentation-comments/) ถูกผูกกับสไลด์นั้นและจะถูกลบพร้อมกับสไลด์นั้น เนื้อหาในสไลด์อื่นไม่ถูกกระทบ

**การลบสไลด์ต่างจากการทำความสะอาดเค้าโครง/มาสเตอร์ที่ไม่ได้ใช้อย่างไร?**

การลบจะลบสไลด์ธรรมดาที่เฉพาะเจาะจงออกจากชุดสไลด์ การทำความสะอาดเค้าโครง/มาสเตอร์ที่ไม่ได้ใช้จะลบสไลด์เค้าโครงหรือมาสเตอร์ที่ไม่มีการอ้างอิงใดๆ ลดขนาดไฟล์โดยไม่เปลี่ยนแปลงเนื้อหาสไลด์ที่เหลือ การกระทำเหล่านี้ทำงานร่วมกัน: โดยปกติลบสไลด์ก่อน แล้วจึงทำความสะอาด.