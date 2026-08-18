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
description: "ทำสำเนาสไลด์ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ Node.js. ตามตัวอย่างโค้ดของเราเพื่ออัตโนมัติกระบวนการสร้าง PPT ในไม่กี่วินาทีและลบงานมือออก."
---
## **บทนำ**

การโคลนคือกระบวนการทำสำเนาที่สมบูรณ์หรือจำลองของสิ่งใดสิ่งหนึ่ง Aspose.Slides สำหรับ Node.js ผ่าน Java ยังทำให้สามารถสร้างสำเนาหรือโคลนของสไลด์ใดก็ได้แล้วแทรกสไลด์ที่โคลนแล้วลงในงานนำเสนอปัจจุบันหรือใด ๆ ที่เปิดอยู่ กระบวนการโคลนสไลด์จะสร้างสไลด์ใหม่ที่นักพัฒนาสามารถแก้ไขได้โดยไม่กระทบต่อสไลด์ต้นฉบับ มีหลายวิธีที่จะโคลนสไลด์:

- โคลนที่ตำแหน่งสุดท้ายภายในงานนำเสนอ
- โคลนที่ตำแหน่งอื่นภายในงานนำเสนอ
- โคลนที่ตำแหน่งสุดท้ายในงานนำเสนออื่น
- โคลนที่ตำแหน่งอื่นในงานนำเสนออื่น
- โคลนที่ตำแหน่งเฉพาะในงานนำเสนออื่น

ใน Aspose.Slides สำหรับ Node.js ผ่าน Java, (คอลเลกชันของอ็อบเจกต์ [Slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Slide) ) ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) มีเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) และ [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) เพื่อทำการโคลนสไลด์ตามประเภทที่กล่าวมาข้างต้น

## **โคลนที่ตำแหน่งสุดท้ายภายในงานนำเสนอ**
หากคุณต้องการโคลนสไลด์และใช้ในไฟล์งานนำเสนอเดียวกันที่ตำแหน่งสุดท้ายของสไลด์ที่มีอยู่แล้ว ให้ใช้เมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
2. สร้างอินสแตนซ์ของคลาส [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
3. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) ที่เปิดเผยโดยอ็อบเจกต์ [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) และส่งสไลด์ที่ต้องการโคลนเป็นพารามิเตอร์ให้กับเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)
4. เขียนไฟล์งานนำเสนอที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์ (อยู่ที่ตำแหน่งแรก – ดัชนีศูนย์ – ของงานนำเสนอ) ไปยังตำแหน่งสุดท้ายของงานนำเสนอ

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // คัดลอกสไลด์ที่ต้องการไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // เขียนงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **โคลนที่ตำแหน่งอื่นภายในงานนำเสนอ**
หากคุณต้องการโคลนสไลด์และใช้ในไฟล์งานนำเสนอเดียวกันแต่ที่ตำแหน่งต่างออกไป ให้ใช้เมธอด [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) :

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. สร้างอินสแตนซ์ของคลาสโดยอ้างอิงคอลเลกชัน **[Slides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--)** ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. เรียกเมธอด [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) ที่เปิดเผยโดยอ็อบเจกต์ [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) และส่งสไลด์ที่ต้องการโคลนพร้อมดัชนีตำแหน่งใหม่เป็นพารามิเตอร์ให้กับเมธอด [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)
1. เขียนไฟล์งานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์ (อยู่ที่ดัชนี 1 – ตำแหน่ง 2 – ของงานนำเสนอ) ไปยังดัชนี 2 – ตำแหน่ง 3 – ของงานนำเสนอ

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // คัดลอกสไลด์ที่ต้องการไปยังตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในงานนำเสนอเดียวกัน
    var slds = pres.getSlides();
    // คัดลอกสไลด์ที่ต้องการไปยังดัชนีที่กำหนดในงานนำเสนอเดียวกัน
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // เขียนงานนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **โคลนที่ตำแหน่งสุดท้ายในงานนำเสนออื่น**
หากคุณต้องการโคลนสไลด์จากงานนำเสนอหนึ่งและใช้ในไฟล์งานนำเสนออื่นที่ตำแหน่งสุดท้ายของสไลด์ที่มีอยู่:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่มีงานนำเสนอซึ่งสไลด์จะถูกโคลนจากนั้น
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่เป็นงานนำหมายถึงปลายทางที่สไลด์จะถูกเพิ่มเข้าไป
1. สร้างอินสแตนซ์ของคลาส [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection) โดยอ้างอิงคอลเลกชัน **[Slides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--)** ที่เปิดเผยโดยอ็อบเจกต์ Presentation ของงานนำเสนอปลายทาง
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) ที่เปิดเผยโดยอ็อบเจกต์ [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) และส่งสไลด์จากงานนำเสนอแหล่งที่มาเป็นพารามิเตอร์ให้กับเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)
1. เขียนไฟล์งานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์ (จากดัชนีแรกของงานนำเสนอแหล่งที่มา) ไปยังตำแหน่งสุดท้ายของงานนำเสนอปลายทาง

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์การนำเสนอแหล่งที่มา
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับไฟล์ PPTX ปลายทาง (ซึ่งสไลด์จะถูกโคลน)
    var destPres = new aspose.slides.Presentation();
    try {
        // คัดลอกสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาสู่ตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในงานนำเสนอปลายทาง
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // เขียนงานนำเสนอปลายทางลงดิสก์
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **โคลนที่ตำแหน่งอื่นในงานนำเสนออื่น**
หากคุณต้องการโคลนสไลด์จากงานนำเสนอหนึ่งและใช้ในไฟล์งานนำเสนออื่นที่ตำแหน่งเฉพาะ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่มีงานนำเสนอแหล่งที่มาซึ่งสไลด์จะถูกโคลนจากนั้น
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่เป็นงานนำหมายถึงปลายทางที่สไลด์จะถูกเพิ่มเข้าไป
1. สร้างอินสแตนซ์ของคลาส [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) โดยอ้างอิงคอลเลกชัน Slides ที่เปิดเผยโดยอ็อบเจกต์ Presentation ของงานนำเสนอปลายทาง
1. เรียกเมธอด [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) ที่เปิดเผยโดยอ็อบเจกต์ [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) และส่งสไลด์จากงานนำเสนอแหล่งที่มาพร้อมตำแหน่งที่ต้องการเป็นพารามิเตอร์ให้กับเมธอด [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)
1. เขียนไฟล์งานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์ (จากดัชนีศูนย์ของงานนำเสนอแหล่งที่มา) ไปยังดัชนี 1 (ตำแหน่ง 2) ของงานนำเสนอปลายทาง

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับไฟล์ PPTX ปลายทาง (ซึ่งสไลด์จะถูกโคลน)
    var destPres = new aspose.slides.Presentation();
    try {
        // คัดลอกสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่สู่ตำแหน่งสุดท้ายของคอลเลกชันสไลด์ในงานนำเสนอปลายทาง
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // เขียนงานนำเสนอปลายทางลงดิสก์
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **โคลนที่ตำแหน่งเฉพาะในงานนำเสนออื่น**
หากคุณต้องการโคลนสไลด์พร้อมมาสเตอร์สไลด์จากงานนำเสนอหนึ่งและใช้ในงานนำเสนออื่น คุณต้องโคลนมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มามาไว้ในงานนำเสนอปลายทางก่อน จากนั้นจึงใช้มาสเตอร์สไลด์นั้นในการโคลนสไลด์ที่มีมาสเตอร์สไลด์ เมธอด [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) ต้องการมาสเตอร์สไลด์จากงานนำเสนอปลายทาง ไม่ใช่จากงานนำเสนอแหล่งที่มา เพื่อโคลนสไลด์พร้อมมาสเตอร์สไลด์ โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่มีงานนำเสนอแหล่งที่มาซึ่งสไลด์จะถูกโคลนจากนั้น
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่เป็นงานนำเสนอปลายทางซึ่งสไลด์จะถูกโคลนไป
1. เข้าถึงสไลด์ที่ต้องการโคลนพร้อมมาสเตอร์สไลด์
1. สร้างอินสแตนซ์ของคลาส [MasterSlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MasterSlideCollection) โดยอ้างอิงคอลเลกชัน Masters ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ของงานนำเสนอปลายทาง
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) ที่เปิดเผยโดยอ็อบเจกต์ [MasterSlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/MasterSlideCollection) และส่งมาสเตอร์จากไฟล์ PPTX แหล่งที่มาที่ต้องการโคลนเป็นพารามิเตอร์ให้กับเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)
1. สร้างอินสแตนซ์ของคลาส [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) โดยตั้งค่าอ้างอิงไปยังคอลเลกชัน Slides ที่เปิดเผยโดยอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ของงานนำเสนอปลายทาง
1. เรียกเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) ที่เปิดเผยโดยอ็อบเจกต์ [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) และส่งสไลด์จากงานนำเสนอแหล่งที่มาที่ต้องการโคลนพร้อมมาสเตอร์สไลด์เป็นพารามิเตอร์ให้กับเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)
1. เขียนไฟล์งานนำเสนอปลายทางที่แก้ไขแล้ว

ในตัวอย่างด้านล่าง เราได้โคลนสไลด์พร้อมมาสเตอร์ (อยู่ที่ดัชนีศูนย์ของงานนำเสนอแหล่งที่มา) ไปยังตำแหน่งสุดท้ายของงานนำเสนอปลายทางโดยใช้มาสเตอร์จากสไลด์แหล่งที่มา

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation เพื่อโหลดไฟล์งานนำเสนอแหล่งที่มา
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // สร้างอินสแตนซ์ของคลาส Presentation สำหรับงานนำเสนอปลายทาง (ซึ่งสไลด์จะถูกโคลน)
    var destPres = new aspose.slides.Presentation();
    try {
        // สร้างอ็อบเจกต์ ISlide จากคอลเลกชันสไลด์ในงานนำเสนอแหล่งที่มาพร้อมกับ
        // มาสเตอร์สไลด์
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // คัดลอกมาสเตอร์สไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาสู่คอลเลกชันของมาสเตอร์ใน
        // งานนำเสนอปลายทาง
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // คัดลอกสไลด์ที่ต้องการจากงานนำเสนอแหล่งที่มาพร้อมมาสเตอร์ที่ต้องการไปยังตำแหน่งสุดท้ายของ
        // คอลเลกชันสไลด์ในงานนำเสนอปลายทาง
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // บันทึกงานนำเสนอปลายทางลงดิสก์
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **โคลนที่ตำแหน่งสุดท้ายในส่วนที่กำหนด**
หากคุณต้องการโคลนสไลด์และใช้ในไฟล์งานนำเสนอเดียวกันแต่ในส่วนที่แตกต่าง ให้ใช้เมธอด [**addClone**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) ที่เปิดเผยโดยคลาส [**SlideCollection**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection) Aspose.Slides สำหรับ Node.js ผ่าน Java ทำให้สามารถโคลนสไลด์จากส่วนแรกแล้วแทรกสไลด์ที่โคลนนั้นไปยังส่วนที่สองของงานนำเสนอเดียวกันได้

โค้ดตัวอย่างต่อไปนี้แสดงวิธีการโคลนสไลด์และแทรกสไลด์ที่โคลนลงในส่วนที่กำหนด

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // บันทึกงานนำเสนอปลายทางลงดิสก์
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **ตรวจสอบให้ขนาดสไลด์ตรงกัน**

เมื่อโคลนสไลด์ไปยังงานนำเสนออื่น ให้ตรวจสอบให้แน่ใจว่าขนาดสไลด์ของงานนำเสนอปลายทางตรงกับขนาดของแหล่งที่มา หากขนาดสไลด์แตกต่างกัน Aspose.Slides จะไม่ปรับสเกลรูปร่างที่โคลนโดยอัตโนมัติ – พิกัดและขนาดเดิมจะถูกเก็บไว้ ซึ่งอาจทำให้เนื้อหาแสดงออกนอกขอบสไลด์หรือเรียงตำแหน่งไม่ตรง

คุณสามารถตั้งค่าขนาดสไลด์ของงานนำเสนอปลายทางให้ตรงกับแหล่งที่มาก่อนทำการโคลนมาสเตอร์และสไลด์ได้:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

ทำเช่นนี้ก่อนโคลนมาสเตอร์และสไลด์

## **FAQ**

**บันทึกผู้บรรยายและความคิดเห็นผู้ตรวจทานจะถูกโคลนหรือไม่?**

ใช่ หน้าโน้ตและความคิดเห็นการตรวจทานจะถูกรวมไว้ในการโคลน หากคุณไม่ต้องการให้มีเหล่านี้ ให้ [ลบออก](/slides/th/nodejs-java/presentation-notes/) หลังจากแทรก

**แผนภูมิและแหล่งข้อมูลของมันจะถูกจัดการอย่างไร?**

อ็อบเจกต์แผนภูมิ การจัดรูปแบบและข้อมูลที่ฝังอยู่จะถูกคัดลอก หากแผนภูมิมีการเชื่อมโยงกับแหล่งภายนอก (เช่น โฟลเดอร์งานที่ฝัง OLE) การเชื่อมโยงนั้นจะคงไว้เป็น [อ็อบเจกต์ OLE](/slides/th/nodejs-java/manage-ole/) หลังจากย้ายไฟล์ ตรวจสอบความพร้อมใช้งานของข้อมูลและพฤติกรรมการรีเฟรช

**ฉันสามารถควบคุมตำแหน่งการแทรกและส่วนของการโคลนได้หรือไม่?**

ได้ คุณสามารถแทรกโคลนที่ดัชนีสไลด์เฉพาะและวางไว้ใน [ส่วน](/slides/th/nodejs-java/slide-section/) ที่เลือก หากส่วนเป้าหมายไม่มีอยู่ ให้สร้างส่วนนั้นก่อนแล้วค่อยย้ายสไลด์เข้าไป