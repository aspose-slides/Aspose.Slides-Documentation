---
title: คัดลอกสไลด์การนำเสนอใน JavaScript
linktitle: คัดลอกสไลด์
type: docs
weight: 35
url: /th/nodejs-java/clone-slides/
keywords:
- คัดลอกสไลด์
- สำเนาสไลด์
- บันทึกสไลด์
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "คัดลอกสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ Node.js. ปฏิบัติตามตัวอย่างโค้ดของเราเพื่ออัตโนมัติการสร้าง PPT ในไม่กี่วินาทีและขจัดงานที่ทำด้วยมือ."
---
## **บทนำ**

การคัดลอกคือกระบวนการสร้างสำเนาที่เหมือนกันหรือทำซ้ำของบางอย่าง Aspose.Slides for Node.js via Java ยังทำให้สามารถสร้างสำเนาหรือคัดลอกสไลด์ใด ๆ แล้วแทรกสไลด์ที่คัดลอกไว้ไปยังงานนำเสนอปัจจุบันหรือไฟล์งานนำเสนออื่นที่เปิดอยู่ได้ กระบวนการคัดลอกสไลด์จะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่กระทบสไลด์เดิม มีวิธีคัดลอกสไลด์หลายวิธีดังต่อไปนี้:

- คัดลอกที่ตำแหน่งท้ายภายในงานนำเสนอเดียวกัน
- คัดลอกที่ตำแหน่งอื่นภายในงานนำเสนอ
- คัดลอกที่ตำแหน่งท้ายในงานนำเสนออื่น
- คัดลอกที่ตำแหน่งอื่นในงานนำเสนออื่น
- คัดลอกที่ตำแหน่งเฉพาะในงานนำเสนออื่น

ใน Aspose.Slides for Node.js via Java (คอลเลกชันของอ็อบเจ็กต์ [Slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Slide) ) ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) จะให้เมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) และ [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) เพื่อดำเนินการคัดลอกสไลด์ตามประเภทที่กล่าวข้างต้น

## **คัดลอกที่ตำแหน่งท้ายภายในงานนำเสนอเดียวกัน**
หากต้องการคัดลอกสไลด์แล้วใช้ในไฟล์งานนำเสนอเดียวกันที่ตำแหน่งสุดท้ายของสไลด์ที่มีอยู่ ให้ใช้เมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
2. สร้างตัวอย่างของคลาส [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
3. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) และส่งสไลด์ที่ต้องการคัดลอกเป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)  
4. เขียนไฟล์งานนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์ (อยู่ที่ตำแหน่งแรก – ดัชนีศูนย์ – ของงานนำเสนอ) ไปยังตำแหน่งสุดท้ายของงานนำเสนอ

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // คัดลอกสไลด์ที่ต้องการไปยังตำแหน่งท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **คัดลอกที่ตำแหน่งอื่นภายในงานนำเสนอ**
หากต้องการคัดลอกสไลด์แล้วใช้ในไฟล์งานนำเสนอเดียวกันแต่ที่ตำแหน่งอื่น ให้ใช้เมธอด [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) :

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
2. สร้างตัวอย่างของคลาสโดยอ้างอิงคอลเลกชัน **[Slides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--)** ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
3. เรียกเมธอด [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) และส่งสไลด์ที่ต้องการคัดลอกพร้อมกับดัชนีของตำแหน่งใหม่เป็นพารามิเตอร์ให้เมธอด [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)  
4. เขียนงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์ (อยู่ที่ดัชนีศูนย์ – ตำแหน่ง 1 – ของงานนำเสนอ) ไปยังดัชนี 1 – ตำแหน่ง 2 – ของงานนำเสนอ

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // คัดลอกสไลด์ที่ต้องการไปยังตำแหน่งท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน
    var slds = pres.getSlides();
    // คัดลอกสไลด์ที่ต้องการไปยังตำแหน่งที่ระบุในงานนำเสนอเดียวกัน
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // บันทึกงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **คัดลอกที่ตำแหน่งท้ายในงานนำเสนออื่น**
หากต้องการคัดลอกจากสไลด์หนึ่งในงานนำเสนอแล้วใช้ในไฟล์งานนำเสนออื่นที่ตำแหน่งสุดท้ายของสไลด์ที่มีอยู่:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่ประกอบด้วยงานนำเสนอที่สไลด์จะถูกคัดลอกจากนั้น  
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่เป็นงานนำหมายที่สไลด์จะถูกเพิ่มเข้าไป  
3. สร้างตัวอย่างของคลาส [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection) โดยอ้างอิงคอลเลกชัน **[Slides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--)** ที่เปิดเผยโดยอ็อบเจ็กต์ Presentation ของงานนำหมายปลายทาง  
4. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) และส่งสไลด์จากงานนำเสนอแหล่งที่มเป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)  
5. เขียนไฟล์งานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์ (จากดัชนีแรกของงานนำเสนอแหล่งที่มา) ไปยังตำแหน่งสุดท้ายของงานนำเสนอปลายทาง

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ซึ่งสไลด์จะถูกคัดลอกไปยัง)
    var destPres = new aspose.slides.Presentation();
    try {
        // คัดลอกสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาถึงตำแหน่งท้ายของคอลเลกชันสไลด์ในงานนำเสนอปลายทาง
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // บันทึกงานนำเสนอปลายทางลงดิสก์
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **คัดลอกที่ตำแหน่งอื่นในงานนำเสนออื่น**
หากต้องการคัดลอกจากสไลด์หนึ่งในงานนำเสนอแล้วใช้ในไฟล์งานนำเสนออื่นที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่ประกอบด้วยงานนำเสนอแหล่งที่สไลด์จะถูกคัดลอกจากนั้น  
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่เป็นงานนำเสนอที่สไลด์จะถูกเพิ่มเข้าไป  
3. สร้างตัวอย่างของคลาส [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดเผยโดยอ็อบเจ็กต์ Presentation ของงานนำเสนอปลายทาง  
4. เรียกเมธอด [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) และส่งสไลด์จากงานนำเสนอแหล่งที่มาพร้อมตำแหน่งที่ต้องการเป็นพารามิเตอร์ให้เมธอด [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)  
5. เขียนไฟล์งานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์ (จากดัชนีศูนย์ของงานนำเสนอแหล่งที่มา) ไปยังดัชนี 1 (ตำแหน่ง 2) ของงานนำเสนอปลายทาง

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับ PPTX ปลายทาง (ซึ่งสไลด์จะถูกคัดลอกไปยัง)
    var destPres = new aspose.slides.Presentation();
    try {
        // คัดลอกสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาถึงตำแหน่งท้ายของคอลเลกชันสไลด์ในงานนำเสนอปลายทาง
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // บันทึกงานนำเสนอปลายทางลงดิสก์
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **คัดลอกที่ตำแหน่งเฉพาะในงานนำเสนออื่น**
หากต้องการคัดลอกสไลด์พร้อมมาสเตอร์สไลด์จากงานนำเสนอหนึ่งแล้วใช้ในงานนำเสนออื่น จำเป็นต้องคัดลอกมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มายังงานนำเสนอปลายทางก่อน แล้วจึงใช้มาสเตอร์สไลด์นั้นคัดลอกสไลด์พร้อมมาสเตอร์สไลด์เมธอด [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) คาดหวังมาสเตอร์สไลด์จากงานนำเสนอปลายทาง ไม่ใช่จากงานนำเสนอแหล่งที่มา เพื่อคัดลอกสไลด์พร้อมมาสเตอร์สไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่ประกอบด้วยงานนำเสนอแหล่งที่สไลด์จะถูกคัดลอกจากนั้น  
2. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่ประกอบด้วยงานนำเสนอปลายทางที่สไลด์จะถูกคัดลอกไป  
3. เข้าถึงสไลด์ที่ต้องการคัดลอกพร้อมมาสเตอร์สไลด์  
4. สร้างตัวอย่างของคลาส [MasterSlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MasterSlideCollection) โดยอ้างอิงคอลเลกชัน Masters ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ของงานนำเสนอปลายทาง  
5. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) ที่เปิดเผยโดยอ็อบเจ็กต์ [MasterSlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MasterSlideCollection) และส่งมาสเตอร์จากไฟล์ PPTX แหล่งที่มาที่ต้องการคัดลอกเป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)  
6. สร้างตัวอย่างของคลาส [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) โดยตั้งค่าอ้างอิงไปยังคอลเลกชัน Slides ที่เปิดเผยโดยอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ของงานนำเสนอปลายทาง  
7. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) ที่เปิดเผยโดยอ็อบเจ็กต์ [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) และส่งสไลด์จากงานนำเสนอแหล่งที่มาที่ต้องการคัดลอกพร้อมมาสเตอร์สไลด์เป็นพารามิเตอร์ให้เมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)  
8. เขียนไฟล์งานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้คัดลอกสไลด์พร้อมมาสเตอร์ (อยู่ที่ดัชนีศูนย์ของงานนำเสนอแหล่งที่มา) ไปยังตำแหน่งสุดท้ายของงานนำเสนอปลายทางโดยใช้มาสเตอร์จากสไลด์แหล่งที่มา

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับงานนำเสนอปลายทาง (ซึ่งสไลด์จะถูกคัดลอกไปยัง)
    var destPres = new aspose.slides.Presentation();
    try {
        // สร้าง ISlide จากคอลเลกชันสไลด์ในงานนำเสนอแหล่งที่มาพร้อมกับ
        // มาสเตอร์สไลด์
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // คัดลอกมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาถึงคอลเลกชันมาสเตอร์ใน
        // งานนำเสนอปลายทาง
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // คัดลอกมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาถึงคอลเลกชันมาสเตอร์ใน
        // งานนำเสนอปลายทาง
        var iSlide = masters.addClone(SourceMaster);
        // คัดลอกสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาพร้อมมาสเตอร์ที่ต้องการไปยังตำแหน่งสุดท้ายของ
        // คอลเลกชันสไลด์ในงานนำเสนอปลายทาง
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // บันทึกงานนำเสนอปลายทางลงดิสก์
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **คัดลอกที่ตำแหน่งท้ายในส่วนที่ระบุ**
หากต้องการคัดลอกสไลด์แล้วใช้ในไฟล์งานนำเสนอเดียวกันแต่ในส่วนที่แตกต่างกัน ให้ใช้เมธอด [**addClone**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) ที่เปิดเผยโดยคลาส [**SlideCollection**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection) Aspose.Slides for Node.js via Java ทำให้สามารถคัดลอกสไลด์จากส่วนแรกแล้วแทรกสไลด์ที่คัดลอกไว้ไปยังส่วนที่สองของงานนำเสนอเดียวกันได้

โค้ดตัวอย่างต่อไปนี้แสดงวิธีคัดลอกสไลด์และแทรกสไลด์ที่คัดลอกเข้าไปในส่วนที่ระบุ

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // บันทึกงานนำเสนอปลายทางลงดิสก์
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**บันทึกของผู้พูดและความคิดเห็นของผู้ตรวจสอบจะถูกคัดลอกหรือไม่?**  
ใช่. หน้าโน้ตและความคิดเห็นการตรวจสอบจะรวมอยู่ในสำเนาที่คัดลอก หากไม่ต้องการ ให้ [remove them](/slides/th/nodejs-java/presentation-notes/) หลังจากแทรก

**แผนภูมิและแหล่งข้อมูลของมันถูกจัดการอย่างไร?**  
อ็อบเจ็กต์แผนภูมิ การฟอร์แมต และข้อมูลที่ฝังอยู่จะถูกคัดลอก หากแผนภูมิกำหนดให้เชื่อมโยงกับแหล่งภายนอก (เช่น เวิร์กบุ๊กที่ฝัง OLE) การเชื่อมโยงนั้นจะคงอยู่เป็น [OLE object](/slides/th/nodejs-java/manage-ole/) หลังจากย้ายไฟล์ตรวจสอบความพร้อมใช้งานของข้อมูลและพฤติกรรมการรีเฟรช

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนของสำเนาที่คัดลอกได้หรือไม่?**  
ได้. คุณสามารถแทรกสำเนาที่คัดลอกที่ดัชนีสไลด์เฉพาะและวางไว้ใน [section](/slides/th/nodejs-java/slide-section/) ที่เลือก หากส่วนเป้าหมายไม่มีอยู่ ให้สร้างก่อนแล้วย้ายสไลด์เข้าไปในส่วนนั้น