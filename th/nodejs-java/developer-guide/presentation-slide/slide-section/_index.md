---
title: "จัดการส่วนสไลด์ในงานนำเสนอด้วย JavaScript"
linktitle: "ส่วนสไลด์"
type: docs
weight: 90
url: /th/nodejs-java/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ปรับปรุงการจัดการส่วนสไลด์ใน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js — แยก, เปลี่ยนชื่อ และจัดลำดับใหม่เพื่อเพิ่มประสิทธิภาพการทำงานของไฟล์ PPTX และ ODP"
---
## **Introduction**

ด้วย Aspose.Slides for Node.js via Java คุณสามารถจัดระเบียบการนำเสนอ PowerPoint เป็นส่วนต่าง ๆ ได้ คุณสามารถสร้างส่วนที่ประกอบด้วยสไลด์ที่เจาะจงได้

คุณอาจต้องการสร้างส่วนและใช้เพื่อจัดระเบียบหรือแบ่งสไลด์ในงานนำเสนอเป็นส่วนที่มีเหตุผลในสถานการณ์ต่อไปนี้:

- เมื่อคุณทำงานบนการนำเสนอขนาดใหญ่ร่วมกับคนอื่นหรือทีม—และคุณต้องมอบหมายสไลด์บางส่วนให้กับเพื่อนร่วมงานหรือสมาชิกในทีม  
- เมื่อคุณกำลังจัดการกับการนำเสนอที่มีสไลด์จำนวนมาก—และคุณประสบปัญหาในการจัดการหรือแก้ไขเนื้อหาในครั้งเดียว  

โดยทั่ว ๆ ไป คุณควรสร้างส่วนที่บรรจุสไลด์ที่คล้ายคลึงกัน—สไลด์เหล่านั้นมีความเชื่อมโยงหรือสามารถจัดกลุ่มตามกฎได้—และตั้งชื่อส่วนที่อธิบายสไลด์ภายใน

## **Creating Sections in Presentations**

เพื่อเพิ่มส่วนที่บรรจุสไลด์ในงานนำเสนอ Aspose.Slides for Node.js via Java มีเมธอด [addSection()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) ที่ให้คุณระบุชื่อส่วนที่ต้องการสร้างและสไลด์ที่ส่วนเริ่มต้นจาก

โค้ดตัวอย่างนี้จะแสดงวิธีสร้างส่วนในงานนำเสนอด้วย JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 จะสิ้นสุดที่ newSlide2 และหลังจากนั้น section2 จะเริ่มต้น
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Changing the Names of Sections**

หลังจากที่คุณสร้างส่วนในงานนำเสนอ PowerPoint แล้ว คุณอาจต้องการเปลี่ยนชื่อของมัน  

โค้ดตัวอย่างนี้จะแสดงวิธีเปลี่ยนชื่อของส่วนในงานนำเสนอด้วย JavaScript โดยใช้ Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**  
**ส่วนจะคงไว้เมื่อบันทึกเป็นรูปแบบ PPT (PowerPoint 97–2003) หรือไม่?**

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.  
ไม่ รูปแบบ PPT ไม่รองรับเมตาดาทาของส่วน ดังนั้นการจัดกลุ่มส่วนจะหายไปเมื่อตัวไฟล์บันทึกเป็น .ppt.

**Can an entire section be "hidden"?**  
**สามารถซ่อนส่วนทั้งหมดได้หรือไม่?**

No. Only individual slides can be hidden. A section as an entity has no "hidden" state.  
ไม่ สามารถซ่อนได้เฉพาะสไลด์แต่ละอันเท่านั้น ส่วนในฐานะเอนทิตี้ไม่มีสถานะ "ซ่อน".

**Can I quickly find a section by a slide and, conversely, the first slide of a section?**  
**ฉันสามารถค้นหาส่วนโดยอิงจากสไลด์ได้อย่างรวดเร็วหรือไม่ และในทางกลับกันค้นหาสไลด์แรกของส่วนได้หรือไม่?**

Yes. A section is uniquely defined by its starting slide; given a slide you can determine which section it belongs to, and for a section you can access its first slide.  
ได้ ส่วนจะถูกกำหนดโดยสไลด์เริ่มต้นของมันเป็นเอกลักษณ์; เมื่อทราบสไลด์แล้วคุณสามารถระบุได้ว่ามันอยู่ในส่วนใด และสำหรับส่วนหนึ่งคุณสามารถเข้าถึงสไลด์แรกของมันได้.