---
title: รวมพรีเซนเทชันอย่างมีประสิทธิภาพใน JavaScript
linktitle: รวมพรีเซนเทชัน
type: docs
weight: 40
url: /th/nodejs-java/merge-presentation/
keywords:
- รวม PowerPoint
- รวมพรีเซนเทชัน
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- รวม PowerPoint
- รวมพรีเซนเทชัน
- รวมสไลด์
- รวม PPT
- รวม PPTX
- รวม ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "ผสานพรีเซนเทชัน PowerPoint (PPT, PPTX) และ OpenDocument (ODP) อย่างง่ายดายใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js เพื่อปรับกระบวนการทำงานของคุณให้ราบรื่น"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณรวมพรีเซนเทชันโดยทำการคัดลอกสไลด์จากพรีเซนเทชันหนึ่งไปยังอีกพรีเซนเทชันหนึ่ง บทความนี้อธิบายวิธีการรวมพรีเซนเทชันทั้งหมดหรือสไลด์ที่เลือกใช้ พรีเซนเทชันมาสเตอร์หรือเค้าโครงเฉพาะในระหว่างการรวม การจัดการพรีเซนเทชันที่มีขนาดสไลด์แตกต่างกัน และการเพิ่มสไลด์ที่รวมแล้วเข้าไปในส่วนของพรีเซนเทชัน นอกจากนี้ยังครอบคลุมโน้ตสำคัญที่เกี่ยวข้องกับเนื้อหาที่รวมไว้รวมถึงโน้ตผู้พูด ความคิดเห็น ไฟล์ต้นฉบับที่ป้องกันด้วยรหัสผ่าน และการใช้เธรด

## **การรวมพรีเซนเทชัน**

เมื่อคุณรวมพรีเซนเทชันหนึ่งไปยังอีกพรีเซนเทชันหนึ่ง คุณกำลังผสานสไลด์ของพวกมันเข้าด้วยกันในพรีเซนเทชันเดียวเพื่อให้ได้ไฟล์เดียว

{{% alert title="Info" color="info" %}}
หลายโปรแกรมพรีเซนเทชัน (PowerPoint หรือ OpenOffice) ขาดฟังก์ชันที่อนุญาตให้ผู้ใช้รวมพรีเซนเทชันในลักษณะนี้
[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/th/nodejs-java/), อย่างไรก็ตาม ให้คุณรวมพรีเซนเทชันในหลายรูปแบบ คุณสามารถรวมพรีเซนเทชันพร้อมกับรูปร่าง สไตล์ ข้อความ การจัดรูปแบบ ความคิดเห็น แอนิเมชัน ฯลฯ โดยไม่ต้องกังวลเรื่องการสูญเสียคุณภาพหรือข้อมูล
**See also**
[Clone Slides](https://docs.aspose.com/slides/th/nodejs-java/clone-slides/).
{{% /alert %}}

### **สิ่งที่สามารถรวมได้**

* พรีเซนเทชันทั้งหมด ทั้งหมดของสไลด์จากพรีเซนเทชันจะอยู่ในพรีเซนเทชันเดียว
* สไลด์เฉพาะ สไลด์ที่เลือกจะอยู่ในพรีเซนเทชันเดียว
* พรีเซนเทชันในรูปแบบเดียวกัน (PPT ไปยัง PPT, PPTX ไปยัง PPTX ฯลฯ) หรือในรูปแบบต่างกัน (PPT ไปยัง PPTX, PPTX ไปยัง ODP ฯลฯ) ไปยังกันและกัน

### **ตัวเลือกการรวม**

คุณสามารถกำหนดตัวเลือกที่บ่งบอกว่า

* สไลด์แต่ละสไลด์ในพรีเซนเทชันผลลัพธ์จะรักษาสไตล์ที่เป็นเอกลักษณ์
* หรือสไตล์เฉพาะจะใช้กับสไลด์ทั้งหมดในพรีเซนเทชันผลลัพธ์

เพื่อรวมพรีเซนเทชัน Aspose.Slides มีเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (จากคลาส [SlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection)) มีการนำไปใช้หลายรูปแบบที่กำหนดพารามิเตอร์ของกระบวนการรวมพรีเซนเทชัน ทุกอ็อบเจ็กต์ Presentation จะมีคอลเลกชัน [Slides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getSlides--) ดังนั้นคุณจึงสามารถเรียกเมธอด `addClone` จากพรีเซนเทชันที่ต้องการรวมสไลด์เข้าไป

เมธอด `addClone` จะคืนค่าอ็อบเจ็กต์ `Slide` ซึ่งเป็นสำเนาของสไลด์ต้นฉบับ สไลด์ในพรีเซนเทชันผลลัพธ์จึงเป็นสำเนาของสไลด์จากแหล่งต้นทาง ดังนั้นคุณจึงสามารถเปลี่ยนแปลงสไลด์ที่ได้ (เช่น ใช้สไตล์หรือออพชันการจัดรูปแบบหรือเค้าโครง) ได้โดยไม่กระทบต่อพรีเซนเทชันต้นฉบับ

## **รวมพรีเซนเทชัน**

Aspose.Slides มีเมธอด [**AddClone(ISlide)**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) ที่ให้คุณผสานสไลด์ในขณะที่สไลด์ยังคงเค้าโครงและสไตล์เดิม (พารามิเตอร์เริ่มต้น)

โค้ด JavaScript นี้แสดงวิธีการรวมพรีเซนเทชัน:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **รวมพรีเซนเทชันด้วย Slide Master**

Aspose.Slides มีเมธอด [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) ที่ให้คุณผสานสไลด์พร้อมกับการใช้เทมเพลต Slide Master ของพรีเซนเทชัน ดังนั้นหากต้องการคุณสามารถเปลี่ยนสไตล์ของสไลด์ในพรีเซนเทชันผลลัพธ์ได้

โค้ด JavaScript นี้แสดงการดำเนินการที่อธิบายไว้:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
เค้าโครงสไลด์สำหรับ Slide Master จะกำหนดโดยอัตโนมัติ หากไม่สามารถกำหนดเค้าโครงที่เหมาะสมได้ และพารามิเตอร์ `allowCloneMissingLayout` ของเมธอด `addClone` ถูกตั้งเป็น true จะใช้เค้าโครงของสไลด์ต้นทาง มิฉะนั้นจะเกิดข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PptxEditException)
{{% /alert %}}

หากต้องการให้สไลด์ในพรีเซนเทชันผลลัพธ์มีเค้าโครงสไลด์ที่แตกต่าง ให้ใช้เมธอด [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) แทนเมื่อต้องการรวม

## **รวมสไลด์เฉพาะจากพรีเซนเทชัน**

การรวมสไลด์เฉพาะจากหลายพรีเซนเทชันเป็นประโยชน์สำหรับการสร้างชุดสไลด์แบบกำหนดเอง Aspose.Slides for Node.js via Java อนุญาตให้คุณเลือกและนำเข้าเฉพาะสไลด์ที่ต้องการ API จะรักษาการจัดรูปแบบ เค้าโครง และการออกแบบของสไลด์ต้นฉบับไว้

โค้ด JavaScript ด้านล่างสร้างพรีเซนเทชันใหม่ เพิ่มสไลด์ชื่อเรื่องจากสองพรีเซนเทชันอื่น และบันทึกผลลัพธ์เป็นไฟล์:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **รวมพรีเซนเทชันด้วย Slide Layout**

โค้ด JavaScript นี้แสดงวิธีการผสานสไลด์จากพรีเซนเทชันพร้อมกับการใช้เค้าโครงสไลด์ที่คุณต้องการเพื่อให้ได้พรีเซนเทชันผลลัพธ์เดียว:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **รวมพรีเซนเทชันที่มีขนาดสไลด์ต่างกัน**

{{% alert title="Note" color="warning" %}} 
คุณไม่สามารถรวมพรีเซนเทชันที่มีขนาดสไลด์ต่างกันได้ 
{{% /alert %}}

เพื่อรวมพรีเซนเทชัน 2 ฉบับที่มีขนาดสไลด์ต่างกัน คุณต้องปรับขนาดหนึ่งในพรีเซนเทชันให้ตรงกับอีกฉบับหนึ่ง

ตัวอย่างโค้ดต่อไปนี้แสดงการดำเนินการดังกล่าว:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **รวมสไลด์ไปยังส่วนของพรีเซนเทชัน**

โค้ด JavaScript นี้แสดงวิธีการรวมสไลด์เฉพาะเข้าสู่ส่วนในพรีเซนเทชัน:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

สไลด์จะถูกเพิ่มที่ส่วนท้ายของเซ็กชันนั้น

## **FAQ**

**โน้ตผู้พูดจะถูกเก็บรักษาไว้ระหว่างการรวมหรือไม่?**

ใช่ เมื่อนำสไลด์มาโคล Clone, Aspose.Slides จะคัดลอกองค์ประกอบสไลด์ทั้งหมดรวมถึงโน้ต การจัดรูปแบบ และแอนิเมชัน

**ความคิดเห็นและผู้เขียนของความคิดเห็นจะถูกย้ายไปด้วยหรือไม่?**

ความคิดเห็นซึ่งเป็นส่วนหนึ่งของเนื้อหาสไลด์จะถูกคัดลอกพร้อมสไลด์ ป้ายผู้เขียนความคิดเห็นจะถูกเก็บเป็นอ็อบเจ็กต์คอมเมนต์ในพรีเซนเทชันผลลัพธ์

**หากพรีเซนเทชันต้นทางมีการป้องกันด้วยรหัสผ่านจะทำอย่างไร?**

ต้อง [เปิดด้วยรหัสผ่าน](/slides/th/nodejs-java/password-protected-presentation/) ผ่าน [LoadOptions.setPassword](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/setpassword/) หลังจากโหลดแล้วสไลด์เหล่านั้นสามารถโคล Clone ไปยังไฟล์ปลายทางที่ไม่มีการป้องกัน (หรือไฟล์ที่ป้องกันด้วยรหัสผ่านได้เช่นกัน)

**การดำเนินการรวมมีความปลอดภัยต่อเธรดแค่ไหน?**

ห้ามใช้อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) เดียวกันจากหลายเธรด (/slides/th/nodejs-java/multithreading/) คำแนะนำคือ “หนึ่งเอกสาร — หนึ่งเธรด” สามารถประมวลผลไฟล์ต่าง ๆ พร้อมกันในเธรดแยกต่างหากได้

## **ดูเพิ่มเติม**

Aspose ให้บริการ [FREE Online Collage Maker](https://products.aspose.app/slides/th/collage) ออนไลน์ ซึ่งคุณสามารถรวมภาพ [JPG ไปยัง JPG](https://products.aspose.app/slides/th/collage/jpg) หรือ PNG ไปยัง PNG, สร้าง [photo grids](https://products.aspose.app/slides/th/collage/photo-grid) และอื่น ๆ

ลองใช้ [Aspose FREE Online Merger](https://products.aspose.app/slides/th/merger) ซึ่งช่วยให้คุณรวมพรีเซนเทชัน PowerPoint ในรูปแบบเดียวกัน (เช่น PPT ไป PPT, PPTX ไป PPTX) หรือข้ามรูปแบบต่าง ๆ (เช่น PPT ไป PPTX, PPTX ไป ODP)

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/th/merger)