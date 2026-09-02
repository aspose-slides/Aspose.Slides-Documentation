---
title: จัดการส่วนหัวและส่วนล่างของการนำเสนอใน JavaScript
linktitle: ส่วนหัวและส่วนล่าง
type: docs
weight: 140
url: /th/nodejs-java/presentation-header-and-footer/
keywords:
- ส่วนหัว
- ข้อความส่วนหัว
- ส่วนล่าง
- ข้อความส่วนล่าง
- ตั้งค่าส่วนหัว
- ตั้งค่าส่วนล่าง
- เอกสารแจก
- บันทึก
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีจัดการตัวแทนส่วนท้าย, วันที่-เวลา, หมายเลขสไลด์, และส่วนหัวบนสไลด์, หน้าโน้ต, และเอกสารแจก ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

PowerPoint ใช้ส่วนหัวและส่วนล่างแบบตัวแทนที่แตกต่างกันขึ้นอยู่กับประเภทของหน้า. Aspose.Slides สำหรับ Node.js ผ่าน Java ให้คุณควบคุมข้อความและการมองเห็นของตัวแทนเหล่านี้ผ่านคลาสผู้จัดการส่วนหัว/ส่วนล่าง.

ตัวแทนที่ใช้ได้ขึ้นอยู่กับขอบเขต:

| ขอบเขต | ส่วนหัว | ส่วนท้าย | วันที่/เวลา | หมายเลขสไลด์/หน้า |
|---|---|---|---|---|
| สไลด์ปกติ | ไม่ | ใช่ | ใช่ | ใช่ |
| โน้ตมาสเตอร์ | ใช่ | ใช่ | ใช่ | ใช่ |
| สไลด์โน้ต | ใช่ | ใช่ | ใช่ | ใช่ |
| มาสเตอร์ของเอกสารแจก | ใช่ | ใช่ | ใช่ | ใช่ |

สไลด์นำเสนอแบบทั่วไปไม่มีตัวแทนส่วนหัว. ส่วนหัวใช้ได้บนหน้าบันทึกและเอกสารแจก. สำหรับสไลด์ปกติ, ให้ใช้ตัวแทนส่วนท้าย, วันที่/เวลา, และหมายเลขสไลด์แทน.

ขอบเขตของการเปลี่ยนแปลงขึ้นอยู่กับผู้จัดการที่คุณใช้. คลาส [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideheaderfootermanager/) ควบคุมสไลด์ปกติหนึ่งสไลด์. คลาส [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notesslideheaderfootermanager/) ควบคุมสไลด์โน้ตหนึ่งสไลด์. ผู้จัดการมาสเตอร์และเลย์เอาต์ยังสามารถกระจายการตั้งค่าไปยังสไลด์ที่ขึ้นอยู่ได้, ในขณะที่คลาส [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) ควบคุมมาสเตอร์ของเอกสารแจก.

## **ตั้งค่าภาคท้าย, วันที่/เวลา, และหมายเลขสไลด์บนสไลด์ปกติ**

สำหรับสไลด์ปกติ, ขั้นตอนพื้นฐานคือเข้าถึงผู้จัดการส่วนหัว/ส่วนล่างของแต่ละสไลด์, ตั้งค่าข้อความส่วนท้ายและวันที่/เวลา, เปิดตัวแทนที่ต้องการ, แล้วบันทึกการนำเสนอ. หมายเลขสไลด์สร้างโดยการนำเสนอ, ดังนั้นคุณเพียงต้องควบคุมการมองเห็นของมัน.

ใช้ [`setFooterText`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) และ [`setDateTimeText`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) เพื่อกำหนดข้อความ, และใช้ [`setFooterVisibility`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [`setDateTimeVisibility`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility), และ [`setSlideNumberVisibility`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) เพื่อแสดงตัวแทนที่สอดคล้องกัน.

ตัวอย่างครบวงจรต่อไปนี้ใช้ส่วนท้าย, ข้อความวันที่/เวลา, และการมองเห็นหมายเลขสไลด์เดียวกันกับสไลด์ปกติทั้งหมด:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากคุณต้องการอัปเดตเพียงสไลด์เดียว, ให้เข้าถึงสไลด์นั้นโดยตรงผ่านเมธอด [`getSlides`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/getslides/) แทนการวนลูปผ่านคอลเลกชันทั้งหมด.

## **ตั้งค่าส่วนหัวและส่วนท้ายบนโน้ตมาสเตอร์**

โน้ตมาสเตอร์กำหนดการจัดรูปแบบและพฤติกรรมตัวแทนที่ใช้ร่วมกันสำหรับหน้าบันทึก. ใช้คลาส [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) เมื่อคุณต้องการเปลี่ยนแปลงเฉพาะโน้ตมาสเตอร์เท่านั้น.

ตัวอย่างต่อไปนี้ตั้งค่าส่วนหัว, ส่วนท้าย, และข้อความวันที่/เวลาในโน้ตมาสเตอร์และทำให้ตัวแทนทั้งหมดที่รองรับมองเห็นได้บนมาสเตอร์นั้น:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมธอด [`getMasterNotesSlide`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masternotesslidemanager/#getMasterNotesSlide) จะคืนค่า `null` เมื่อการนำเสนอไม่มีโน้ตมาสเตอร์.

## **ใช้การตั้งค่าโน้ตมาสเตอร์กับสไลด์โน้ตลูก**

โน้ตมาสเตอร์สามารถนำการตั้งค่าส่วนหัวและส่วนท้ายไปใช้กับตัวเองและสไลด์โน้ตที่ขึ้นอยู่ทั้งหมดได้. ใช้วิธีการกระจายเฉพาะบน [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) เมื่อต้องการใช้การตั้งค่าเดียวกันทั่วระดับโน้ต.

ตัวอย่างเช่น, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) และ [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) จะอัปเดตส่วนหัวของโน้ตมาสเตอร์และส่วนหัวของลูกทั้งหมด. มีเมธอดที่เทียบเท่าสำหรับส่วนท้าย, วันที่/เวลา, และหมายเลขสไลด์.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide !== null) {
        const headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมธอดกระจายที่ใช้ข้างต้นได้แก่ [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility), และ [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **ตั้งค่าส่วนหัวและส่วนท้ายบนสไลด์โน้ตเดี่ยว**

สไลด์โน้ตเป็นส่วนหนึ่งของสไลด์ปกติที่ระบุ. ใช้คลาส [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notesslideheaderfootermanager/) เมื่อคุณต้องการปรับแต่งเพียงหน้าบันทึกนั้นเท่านั้น.

เมธอด [`addNotesSlide`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notesslidemanager/#addNotesSlide) จะคืนค่าสไลด์โน้ตสำหรับสไลด์ปัจจุบันและสร้างใหม่หากยังไม่มี. ตัวอย่างต่อไปนี้ตั้งค่าหน้าบันทึกที่เชื่อมกับสไลด์แรกของการนำเสนอ:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const headerFooterManager = slide.getNotesSlideManager().addNotesSlide().getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากคุณกระจายการตั้งค่าจากโน้ตมาสเตอร์ก่อนแล้วทำการเปลี่ยนแปลงสไลด์โน้ตเดี่ยวต่อมา, การตั้งค่าเฉพาะสไลด์นั้นจะทำให้คุณปรับแต่งหน้าบันทึกได้อย่างอิสระ.

## **ตั้งค่าส่วนหัวและส่วนท้ายบนมาสเตอร์ของเอกสารแจก**

หน้าที่เอกสารแจกใช้มาสเตอร์ของเอกสารแจกสำหรับส่วนหัว, ส่วนท้าย, วันที่/เวลา, และตัวแทนหมายเลขหน้า. แตกต่างจากหน้าบันทึก, การตั้งค่าเอกสารแจกจัดการผ่านมาสเตอร์ของเอกสารแจกแทนการจัดการสไลด์เอกสารแจกแต่ละสไลด์.

ใช้ [`getMasterHandoutSlide`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterhandoutslidemanager/#getMasterHandoutSlide) เพื่อเข้าถึงมาสเตอร์ของเอกสารแจก. หากไม่มี, เรียก [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterhandoutslidemanager/#setDefaultMasterHandoutSlide) เพื่อสร้างมาสเตอร์เอกสารแจกเริ่มต้น.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    let masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide === null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide !== null) {
        const headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ทำความเข้าใจขอบเขตและการสืบทอด**

เลือกผู้จัดการส่วนหัว/ส่วนท้ายที่ตรงกับขอบเขตที่คุณต้องการเปลี่ยนแปลง:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideheaderfootermanager/) เปลี่ยนการตั้งค่าส่วนท้าย, วันที่/เวลา, และหมายเลขสไลด์สำหรับสไลด์ปกติหนึ่งสไลด์.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslideheaderfootermanager/) ควบคุมสไลด์เลย์เอาต์และสามารถกระจายการตั้งค่าที่รองรับไปยังสไลด์ที่ขึ้นอยู่.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslideheaderfootermanager/) ควบคุมมาสเตอร์ของสไลด์ปกติและสามารถกระจายการตั้งค่าที่รองรับไปยังสไลด์ที่ขึ้นอยู่.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masternotesslideheaderfootermanager/) ควบคุมโน้ตมาสเตอร์และสามารถกระจายการตั้งค่าไปยังสไลด์โน้ตที่ขึ้นอยู่ทั้งหมด.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/notesslideheaderfootermanager/) เปลี่ยนสไลด์โน้ตหนึ่งสไลด์และรองรับส่วนหัวเพิ่มเติมนอกเหนือจากส่วนท้าย, วันที่/เวลา, และหมายเลขสไลด์.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterhandoutslideheaderfootermanager/) เปลี่ยนมาสเตอร์ของเอกสารแจกและรองรับตัวแทนสี่ประเภททั้งหมด.

ใช้การกระจายจากมาสเตอร์หรือเลย์เอาต์เมื่อการตั้งค่าเดียวกันควรใช้ตลอดระดับของมัน. ใช้สไลด์เดี่ยวหรือผู้จัดการสไลด์โน้ตเมื่อคุณต้องการการตั้งค่าท้องถิ่นสำหรับหน้าหนึ่ง.

## **คำถามที่พบบ่อย**

**ฉันสามารถเพิ่มส่วนหัวให้กับสไลด์ปกติได้หรือไม่?**

ไม่ได้. PowerPoint ไม่ได้กำหนดตัวแทนส่วนหัวสำหรับสไลด์ปกติ. บนสไลด์ปกติ, ให้ใช้ตัวแทนส่วนท้าย, วันที่/เวลา, และหมายเลขสไลด์. ตัวแทนส่วนหัวมีให้ใช้บนหน้าบันทึกและเอกสารแจก.

**หากตัวแทนส่วนท้าย, วันที่/เวลา, หรือหมายเลขสไลด์ไม่ปรากฏจะทำอย่างไร?**

ใช้ผู้จัดการส่วนหัว/ส่วนท้ายที่สอดคล้องกันเพื่อตรวจสอบการมองเห็นและเปิดใช้งานเมื่อจำเป็น. ตัวอย่างเช่น, [`isFooterVisible`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) แสดงว่าตัวแทนส่วนท้ายมีอยู่หรือไม่, และ [`setFooterVisibility`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) เปลี่ยนการมองเห็นของมัน.

**ฉันจะเริ่มนับหมายเลขสไลด์จากค่าที่ไม่ใช่ 1 ได้อย่างไร?**

เรียกเมธอด [`setFirstSlideNumber`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) ของการนำเสนอ. ตัวแทนหมายเลขสไลด์จะใช้ลำดับการนับที่อัปเดตแล้ว.

**ส่วนหัวและส่วนท้ายจะเกิดอะไรขึ้นเมื่อส่งออกเป็น PDF, รูปภาพ หรือ HTML?**

องค์ประกอบส่วนหัวและส่วนท้ายที่มองเห็นจะถูกเรนเดอร์พร้อมกับเนื้อหาการนำเสนอในรูปแบบผลลัพธ์. รูปลักษณ์ของมันขึ้นอยู่กับประเภทหน้าที่กำลังส่งออกและการตั้งค่าการมองเห็นของตัวแทนที่เกี่ยวข้อง.