---
title: เข้าถึงสไลด์การนำเสนอใน JavaScript
linktitle: เข้าถึงสไลด์
type: docs
weight: 20
url: /th/nodejs-java/access-slide-in-presentation/
keywords:
- เข้าถึงสไลด์
- ดัชนีสไลด์
- ID สไลด์
- ตำแหน่งสไลด์
- เปลี่ยนตำแหน่ง
- คุณสมบัติของสไลด์
- หมายเลขสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีการเข้าถึงและจัดการสไลด์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js เพิ่มประสิทธิภาพการทำงานด้วยตัวอย่างโค้ด"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเข้าถึงและจัดการสไลด์ในงานนำเสนอโดยใช้ Aspose.Slides โดยแสดงวิธีดึงสไลด์ตามดัชนีที่เริ่มจากศูนย์จากคอลเลกชันสไลด์และวิธีเข้าถึงสไลด์โดยใช้ ID ที่ไม่ซ้ำกันด้วยเมธอด `getSlideById`  

คุณจะได้เรียนรู้วิธีเปลี่ยนตำแหน่งของสไลด์โดยใช้เมธอด `setSlideNumber` และวิธีกำหนดหมายเลขสไลด์เริ่มต้นสำหรับงานนำเสนอด้วยเมธอด `setFirstSlideNumber` ตัวอย่างจะแสดงการโหลดงานนำเสนอ, การรับอ้างอิงสไลด์, การอัปเดตลำดับหรือหมายเลขสไลด์, และการบันทึกงานนำเสนอที่แก้ไข  

## **เข้าถึงสไลด์โดยดัชนี**

สไลด์ทั้งหมดในงานนำเสนอจะเรียงลำดับตามตำแหน่งสไลด์โดยเริ่มจาก 0 สไลด์แรกสามารถเข้าถึงได้ผ่านดัชนี 0; สไลด์ที่สองเข้าถึงผ่านดัชนี 1; ฯลฯ  

คลาส Presentation ซึ่งเป็นตัวแทนไฟล์งานนำเสนอ จะเปิดเผยสไลด์ทั้งหมดเป็นคอลเลกชัน [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidecollection/) (คอลเลกชันของอ็อบเจกต์ [Slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/)) โค้ด JavaScript นี้จะแสดงวิธีเข้าถึงสไลด์ผ่านดัชนีของมัน:

```javascript
// สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // เข้าถึงสไลด์โดยใช้ดัชนีสไลด์
    var slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **เข้าถึงสไลด์โดย ID**

แต่ละสไลด์ในงานนำเสนอมี ID ที่ไม่ซ้ำกัน คุณสามารถใช้เมธอด [getSlideById](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSlideById-long-) (ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)) เพื่อระบุ ID นั้น โค้ด JavaScript นี้จะแสดงวิธีให้ ID สไลด์ที่ถูกต้องและเข้าถึงสไลด์นั้นผ่านเมธอด [getSlideById](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSlideById-long-):

```javascript
// สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // รับ ID ของสไลด์
    var id = pres.getSlides().get_Item(0).getSlideId();
    // เข้าถึงสไลด์ผ่าน ID ของมัน
    var slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **เปลี่ยนตำแหน่งสไลด์**

Aspose.Slides ให้คุณเปลี่ยนตำแหน่งสไลด์ได้ ตัวอย่างเช่น คุณสามารถระบุให้สไลด์แรกกลายเป็นสไลด์ที่สอง  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ (ตำแหน่งที่คุณต้องการเปลี่ยน) ผ่านดัชนีของมัน  
1. ตั้งค่าตำแหน่งใหม่ให้สไลด์ผ่านคุณสมบัติ [setSlideNumber](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#setSlideNumber-int-)  
1. บันทึกงานนำเสนอที่แก้ไข  

โค้ด JavaScript นี้แสดงการดำเนินการที่สไลด์ที่ตำแหน่ง 1 ถูกย้ายไปยังตำแหน่ง 2:

```javascript
// สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // รับสไลด์ที่ตำแหน่งจะถูกเปลี่ยน
    var sld = pres.getSlides().get_Item(0);
    // กำหนดตำแหน่งใหม่ให้สไลด์
    sld.setSlideNumber(2);
    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.save("helloworld_Pos.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

สไลด์แรกกลายเป็นสไลด์ที่สอง; สไลด์ที่สองกลายเป็นสไลด์แรก เมื่อคุณเปลี่ยนตำแหน่งของสไลด์ สไลด์อื่น ๆ จะปรับโดยอัตโนมัติ  

## **ตั้งหมายเลขสไลด์**

โดยใช้คุณสมบัติ [setFirstSlideNumber](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#setFirstSlideNumber-int-) (ที่เปิดเผยโดยคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)) คุณสามารถระบุหมายเลขใหม่สำหรับสไลด์แรกในงานนำเสนอ การดำเนินการนี้ทำให้หมายเลขสไลด์อื่น ๆ ถูกคำนวณใหม่  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. รับหมายเลขสไลด์  
1. ตั้งค่าหมายเลขสไลด์  
1. บันทึกงานนำเสนอที่แก้ไข  

โค้ด JavaScript นี้แสดงการดำเนินการที่กำหนดหมายเลขสไลด์แรกเป็น 10:

```javascript
// สร้างอ็อบเจกต์ Presentation ที่แสดงไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    // รับหมายเลขสไลด์
    var firstSlideNumber = pres.getFirstSlideNumber();
    // ตั้งค่าหมายเลขสไลด์
    pres.setFirstSlideNumber(10);
    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.save("Set_Slide_Number_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

หากคุณต้องการข้ามสไลด์แรก คุณสามารถเริ่มนับหมายเลขจากสไลด์ที่สอง (และซ่อนการแสดงหมายเลขสำหรับสไลด์แรก) ได้ดังนี้:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var layoutSlide = presentation.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    // กำหนดหมายเลขสำหรับสไลด์แรกของงานนำเสนอ
    // แสดงหมายเลขสไลด์สำหรับสไลด์ทั้งหมด
    // ซ่อนหมายเลขสไลด์สำหรับสไลด์แรก
    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**หมายเลขสไลด์ที่ผู้ใช้เห็นตรงกับดัชนีที่เริ่มจากศูนย์ของคอลเลกชันหรือไม่?**  
หมายเลขที่แสดงบนสไลด์สามารถเริ่มจากค่าที่กำหนดเอง (เช่น 10) และไม่จำเป็นต้องตรงกับดัชนี ความสัมพันธ์นี้ถูกควบคุมโดยการตั้งค่า [first slide number](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) ของงานนำเสนอ  

**สไลด์ที่ซ่อนอยู่มีผลต่อการจัดดัชนีหรือไม่?**  
ใช่ สไลด์ที่ซ่อนอยู่ยังคงอยู่ในคอลเลกชันและจะถูกนับในการจัดดัชนี; “ซ่อน” หมายถึงการแสดงผล ไม่ได้หมายถึงตำแหน่งในคอลเลกชัน  

**ดัชนีของสไลด์เปลี่ยนเมื่อมีการเพิ่มหรือเอาสไลด์อื่นออกหรือไม่?**  
ใช่ ดัชนีจะสะท้อนลำดับปัจจุบันของสไลด์และจะคำนวณใหม่เมื่อทำการแทรก, ลบ หรือย้ายสไลด์