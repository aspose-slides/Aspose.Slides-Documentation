---
title: ลบสไลด์จากการพรีเซนเทชันใน JavaScript
linktitle: ลบสไลด์
type: docs
weight: 30
url: /th/nodejs-java/remove-slide-from-presentation/
keywords:
- ลบสไลด์
- ลบสไลด์ออก
- ลบสไลด์ที่ไม่ได้ใช้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ลบสไลด์จากการพรีเซนเทชัน PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ Node.js รับตัวอย่างโค้ดที่ชัดเจนและเพิ่มประสิทธิภาพการทำงานของคุณ"
---
## **บทนำ**

หากสไลด์ (หรือเนื้อหาในสไลด์) กลายเป็นสิ่งที่ซ้ำซ้อน คุณสามารถลบออกได้ Aspose.Slides มีคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ที่ห่อหุ้ม [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/) ซึ่งเป็นคลังเก็บสไลด์ทั้งหมดในพรีเซนเทชัน ด้วยการใช้ตัวชี้ (อ้างอิงหรือดัชนี) สำหรับอ็อบเจ็กต์ [Slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/) ที่รู้จัก คุณสามารถระบุตำแหน่งสไลด์ที่ต้องการลบได้

## **ลบสไลด์โดยอ้างอิง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. รับอ้างอิงของสไลด์ที่คุณต้องการลบผ่าน ID หรือ Index ของมัน  
1. ลบสไลด์ที่อ้างอิงออกจากพรีเซนเทชัน  
1. บันทึกพรีเซนเทชันที่แก้ไขแล้ว  

โค้ด JavaScript นี้แสดงวิธีลบสไลด์โดยอ้างอิง:

```javascript
// สร้างอ็อบเจ็กต์ Presentation ที่แสดงไฟล์พรีเซนเทชัน
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // เข้าถึงสไลด์ผ่านดัชนีในคอลเลกชันสไลด์
    var slide = pres.getSlides().get_Item(0);
    // ลบสไลด์ผ่านการอ้างอิงของมัน
    pres.getSlides().remove(slide);
    // บันทึกพรีเซนเทชันที่แก้ไขแล้ว
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **ลบสไลด์โดยดัชนี**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. ลบสไลด์จากพรีเซนเทชันโดยใช้ตำแหน่งดัชนีของมัน  
1. บันทึกพรีเซนเทชันที่แก้ไขแล้ว  

โค้ด JavaScript นี้แสดงวิธีลบสไลด์โดยใช้ดัชนี:

```javascript
// สร้างอ็อบเจ็กต์ Presentation ที่แสดงไฟล์พรีเซนเทชัน
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // ลบสไลด์ผ่านดัชนีสไลด์ของมัน
    pres.getSlides().removeAt(0);
    // บันทึกพรีเซนเทชันที่แก้ไขแล้ว
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **ลบสไลด์เลย์เอาต์ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) (จากคลาส [Compress](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/)) เพื่อให้คุณลบสไลด์เลย์เอาต์ที่ไม่ต้องการและไม่ได้ใช้ โค้ด JavaScript นี้แสดงวิธีลบสไลด์เลย์เอาต์จากพรีเซนเทชัน PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ลบสไลด์มาสเตอร์ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [removeUnusedMasterSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (จากคลาส [Compress](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/)) เพื่อให้คุณลบสไลด์มาสเตอร์ที่ไม่ต้องการและไม่ได้ใช้ โค้ด JavaScript นี้แสดงวิธีลบสไลด์มาสเตอร์จากพรีเซนเทชัน PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**เกิดอะไรขึ้นกับดัชนีของสไลด์หลังจากที่ฉันลบสไลด์?**

หลังจากการลบ [collection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/) จะทำการจัดดัชนีใหม่: ทุกสไลด์ที่ตามมาจะเลื่อนไปทางซ้ายหนึ่งตำแหน่ง ดังนั้นหมายเลขดัชนีก่อนหน้าจะล้าสมัย หากต้องการอ้างอิงที่คงที่ ให้ใช้ ID คงที่ของแต่ละสไลด์แทนดัชนี

**ID ของสไลด์ต่างจากดัชนีหรือไม่ และจะเปลี่ยนเมื่อสไลด์ข้างเคียงถูกลบหรือไม่?**

ใช่ ดัชนีคือตำแหน่งของสไลด์และจะเปลี่ยนเมื่อสไลด์ถูกเพิ่มหรือเอาออก ส่วน ID ของสไลด์เป็นตัวระบุคงที่และจะไม่เปลี่ยนเมื่อสไลด์อื่นถูกลบ

**การลบสไลด์ส่งผลต่อส่วนของสไลด์อย่างไร?**

หากสไลด์นั้นเป็นส่วนหนึ่งของ Section ส่วนนั้นจะมีสไลด์น้อยลงหนึ่งสไลด์ โครงสร้าง Section ยังคงอยู่; หาก Section กลายเป็นว่างเปล่า คุณสามารถ [remove or reorganize sections](/slides/th/nodejs-java/slide-section/) ได้ตามต้องการ

**บันทึกและความคิดเห็นที่แนบกับสไลด์จะเกิดอะไรขึ้นเมื่อสไลด์นั้นถูกลบ?**

[Notes](/slides/th/nodejs-java/presentation-notes/) และ [comments](/slides/th/nodejs-java/presentation-comments/) ถูกผูกไว้กับสไลด์นั้นและจะถูกลบพร้อมกับสไลด์ เนื้อหาบนสไลด์อื่นจะไม่ถูกกระทบ

**การลบสไลด์แตกต่างจากการทำความสะอาดเลย์เอาต์/มาสเตอร์ที่ไม่ได้ใช้อย่างไร?**

การลบจะเอาสไลด์ปกติที่เฉพาะเจาะจงออกจากชุดสไลด์ ส่วนการทำความสะอาดเลย์เอาต์/มาสเตอร์ที่ไม่ได้ใช้จะลบสไลด์เลย์เอาต์หรือมาสเตอร์ที่ไม่มีอ้างอิงใดๆ อยู่ เพื่อลดขนาดไฟล์โดยไม่เปลี่ยนแปลงเนื้อหาสไลด์ที่เหลือ การกระทำเหล่านี้ทำงานร่วมกัน: โดยทั่วไปลบสไลด์ก่อน แล้วจึงทำความสะอาด​