---
title: จัดการส่วนสไลด์ในงานนำเสนอด้วย JavaScript
linktitle: ส่วนสไลด์
type: docs
weight: 90
url: /th/nodejs-java/slide-section/
keywords:
- สร้างส่วน
- เพิ่มส่วน
- แก้ไขส่วน
- เปลี่ยนส่วน
- ชื่อส่วน
- ดึงสไลด์ส่วน
- ประมวลผลสไลด์ส่วน
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการส่วนสไลด์ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java: สร้าง, เปลี่ยนชื่อ, จัดลำดับใหม่, ดึง, และประมวลผลสไลด์ส่วนในงานนำเสนอ PPTX."
---
## **บทนำ**

Sections จัดสไลด์ต่อเนื่องเป็นกลุ่มที่มีชื่อโดยไม่เปลี่ยนเนื้อหาของสไลด์. ด้วย Aspose.Slides for Node.js via Java, คุณสามารถสร้าง, จัดลำดับใหม่, เปลี่ยนชื่อ, ตรวจสอบ, และลบ sections ผ่านเมธอด [Presentation.getSections](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSections).

Sections มีประโยชน์เป็นพิเศษเมื่อ:

- การนำเสนอขนาดใหญ่ต้องแบ่งออกเป็นหัวข้อหรือบทที่มีตรรกะ;
- กลุ่มสไลด์ต่างๆ ถูกมอบหมายให้กับผู้ร่วมงานคนต่างๆ;
- สไลด์ต้องได้รับการประมวลผล, ย้าย, หรือรวมเข้าด้วยกันเป็นกลุ่ม.

เลือกชื่อ section ที่กระชับและอธิบายวัตถุประสงค์ของสไลด์ที่จัดกลุ่มไว้. เนื่องจาก sections เป็นส่วนหนึ่งของโครงสร้างการนำเสนอ, ควรใช้ API ของ section เพื่อกำหนดสมาชิกแทนการคำนวณจากตำแหน่งของสไลด์.

## **สร้างและจัดการ Sections**

ใช้ [SectionCollection.addSection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sectioncollection/#addSection) เพื่อสร้าง section โดยระบุชื่อและสไลด์เริ่มต้น. Aspose.Slides กำหนดสไลด์ใดบ้างที่เป็นของ section จากโครงสร้าง section ปัจจุบันของการนำเสนอ.

ส่วนของ [SectionCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sectioncollection/) เดียวกันยังให้คุณทำสิ่งต่อไปนี้:

- ย้าย section ไปพร้อมกับสไลด์โดยใช้ [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- ลบเฉพาะการกำหนดของ section ด้วย [SectionCollection.removeSection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sectioncollection/#removeSection), ซึ่งจะคงสไลด์ไว้;
- ลบ section พร้อมสไลด์ด้วย [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- เพิ่ม section ว่างที่ท้ายด้วย [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

ตัวอย่างต่อไปนี้สร้างสอง section, ย้ายหนึ่งในนั้น, ลบมันพร้อมสไลด์, และเพิ่ม section ว่าง:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

หลังจากการดำเนินการเหล่านี้, การนำเสนอจะมี section `Introduction` พร้อมสไลด์และ section ว่าง `Appendix`. section `Results` และสไลด์ของมันถูกลบออกแล้ว.

## **เปลี่ยนชื่อ Sections**

เพื่อเปลี่ยนชื่อ section, เรียกเมธอด [Section.setName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/section/#setName). สไลด์และตำแหน่งของ section จะคงเดิม.

ตัวอย่างต่อไปนี้สร้าง section และเปลี่ยนชื่อของมัน:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **ดึงสไลด์จาก Sections**

เมธอด [Presentation.getSections](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSections) คืนค่า [SectionCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sectioncollection/) ที่คุณสามารถเข้าถึงโดยดัชนี. สำหรับแต่ละ [Section](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/section/), เรียก [Section.getSlidesListOfSection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/section/#getSlidesListOfSection) เพื่อรับสไลด์ที่ปัจจุบันเป็นของมัน. เมธอดนี้คืนค่า [SectionSlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sectionslidecollection/), ซึ่งให้จำนวนและการเข้าถึงตามดัชนี.

ตัวอย่างต่อไปนี้สร้างสอง section ที่มีเนื้อหาและหนึ่ง section ว่าง, แล้วพิมพ์ [name](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/section/#getStartedFromSlide), จำนวนสไลด์, และหมายเลขสไลด์ของแต่ละ section. มันใช้ [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) เพื่ออ่านสไลด์แรกและทุกสไลด์ในคอลเลกชัน. สำหรับ section ว่าง, คอลเลกชันที่คืนค่ามีขนาดเป็นศูนย์, การเข้าถึงตามดัชนีจะถูกข้าม, และลูปจะไม่ทำการใดๆ.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

Section membership ถูกกำหนดโดยโครงสร้าง section ของการนำเสนอ. อย่าคำนวนช่วงของ section ด้วยตนเองจาก [Section.getStartedFromSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/section/#getStartedFromSlide), ดัชนีสไลด์, และสไลด์เริ่มต้นของ section ถัดไป.

การแก้ไขเชิงโครงสร้างสามารถเปลี่ยนทั้งสไลด์ที่คืนค่ามาสำหรับ section และหมายเลขสไลด์ของพวกมัน. นี้รวมถึงการจัดลำดับสไลด์ใหม่, การโคลนสไลด์เข้าไปใน section, การย้าย section พร้อมสไลด์, การลบสไลด์, และการลบ sections. ตัวอย่างต่อไปนี้เรียก [Section.getSlidesListOfSection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/section/#getSlidesListOfSection) หลังจากการเปลี่ยนแปลงแต่ละครั้งแทนการเก็บสมมติฐานเกี่ยวกับขอบเขตเดิมของ section.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

เรียก [Section.getSlidesListOfSection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/section/#getSlidesListOfSection) อีกครั้ง whenever slides or sections are reordered, cloned, moved, or removed. This keeps subsequent processing aligned with the current presentation structure.

รูปแบบ PPT (PowerPoint 97–2003) ไม่เก็บเมตาดาทา section. ใช้กระบวนการทำงานนี้กับรูปแบบที่รองรับ sections, เช่น PPTX; การแปลงเป็น PPT จะลบโครงสร้าง section ที่จำเป็นสำหรับการวนซ้ำต่อไป.

## **คำถามที่พบบ่อย**

**Section จะถูกเก็บไว้เมื่อตัวบันทึกเป็นรูปแบบ PPT (PowerPoint 97–2003) หรือไม่?**

ไม่. รูปแบบ PPT ไม่รองรับเมตาดาทา section, ดังนั้นการจัดกลุ่ม section จะสูญหายเมื่อบันทึกเป็น .ppt.

**สามารถซ่อน section ทั้งหมดได้หรือไม่?**

ไม่. Section ไม่มีสถานะการมองเห็น. เพื่อซ่อนเนื้อหาให้เรียก [Slide.setHidden](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#setHidden) สำหรับสไลด์แต่ละสไลด์ใน section.

**จะหาว่า slide อยู่ใน section ใดได้อย่างไร?**

เข้าถึงแต่ละ section ในคอลเลกชันที่คืนค่ามาจาก [Presentation.getSections](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getSections), เรียก [Section.getSlidesListOfSection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/section/#getSlidesListOfSection) สำหรับแต่ละ section, แล้วเปรียบเทียบสไลด์ที่คืนค่ากับสไลด์เป้าหมาย. สำหรับ section ที่ไม่ว่าง, [Section.getStartedFromSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/section/#getStartedFromSlide) จะคืนสไลด์แรก; ส่วน section ว่างจะคืนค่า `null`.