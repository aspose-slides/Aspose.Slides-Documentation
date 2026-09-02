---
title: จัดการส่วนหัวและส่วนท้ายของงานนำเสนอใน PHP
linktitle: ส่วนหัวและส่วนท้าย
type: docs
weight: 140
url: /th/php-java/presentation-header-and-footer/
keywords:
- ส่วนหัว
- ข้อความส่วนหัว
- ส่วนท้าย
- ข้อความส่วนท้าย
- ตั้งส่วนหัว
- ตั้งส่วนท้าย
- เอกสารแจก
- บันทึก
- PowerPoint
- OpenDocument
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดการส่วนท้าย, วันที่-เวลา, หมายเลขสไลด์, และส่วนหัวบนสไลด์, หน้าโน๊ต, และเอกสารแจกด้วย Aspose.Slides สำหรับ PHP ผ่าน Java."
---
## **ภาพรวม**

PowerPoint ใช้ส่วนหัวและส่วนท้ายที่เป็นตัวแทนต่างกันตามประเภทของหน้า Aspose.Slides for PHP ผ่าน Java ให้คุณควบคุมข้อความและการมองเห็นของตัวแทนเหล่านี้ผ่านคลาสผู้จัดการส่วนหัว/ส่วนท้าย

ตัวแทนที่มีให้เลือกขึ้นอยู่กับขอบเขต:

| ขอบเขต | ส่วนหัว | ส่วนท้าย | วันที่/เวลา | หมายเลขสไลด์/หน้า |
|---|---|---|---|---|
| สไลด์ปกติ | No | Yes | Yes | Yes |
| มาสเตอร์โน๊ต | Yes | Yes | Yes | Yes |
| สไลด์โน๊ต | Yes | Yes | Yes | Yes |
| มาสเตอร์เอกสารแจก | Yes | Yes | Yes | Yes |

สไลด์การนำเสนอปกติไม่มีตัวแทนส่วนหัว ส่วนหัวจะมีเฉพาะในหน้าบันทึกและเอกสารแจก สำหรับสไลด์ปกติให้ใช้ตัวแทนส่วนท้าย, วันที่/เวลา และหมายเลขสไลด์แทน

ขอบเขตของการเปลี่ยนแปลงขึ้นอยู่กับผู้จัดการที่คุณใช้ คลาส [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideheaderfootermanager/) ควบคุมสไลด์ปกติหนึ่งสไลด์ คลาส [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/php-java/aspose.slides/notesslideheaderfootermanager/) ควบคุมสไลด์โน๊ตหนึ่งสไลด์ ผู้จัดการมาสเตอร์และเลเอาต์ยังสามารถกระจายการตั้งค่าไปยังสไลด์ที่เกี่ยวข้องได้ ในขณะที่คลาส [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) ควบคุมมาสเตอร์เอกสารแจก

## **ตั้งค่าส่วนท้าย, วันที่/เวลา, และหมายเลขสไลด์ในสไลด์ปกติ**

สำหรับสไลด์ปกติ กระบวนการพื้นฐานคือเข้าถึงผู้จัดการส่วนหัว/ส่วนท้ายของแต่ละสไลด์ ตั้งข้อความส่วนท้ายและวันที่/เวลา เปิดใช้งานตัวแทนที่ต้องการ แล้วบันทึกการนำเสนอ หมายเลขสไลด์จะถูกสร้างโดยอัตโนมัติ ดังนั้นคุณเพียงแค่ควบคุมการมองเห็นของมัน

ใช้ [`setFooterText`](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) และ [`setDateTimeText`](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) เพื่อกำหนดข้อความ และใช้ [`setFooterVisibility`](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/), และ [`setSlideNumberVisibility`](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) เพื่อแสดงตัวแทนที่สอดคล้องกัน

ตัวอย่างต่อไปนี้เป็นการประยุกต์ใช้ส่วนท้ายเดียวกัน, ข้อความวันที่/เวลา, และการมองเห็นหมายเลขสไลด์กับสไลด์ปกติทั้งหมด:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

หากต้องการอัปเดตเพียงสไลด์เดียว ให้เข้าถึงสไลด์นั้นโดยตรงผ่านเมธอด [`getSlides`](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/getslides/) แทนการวนลูปผ่านคอลเลกชันทั้งหมด

## **ตั้งค่าส่วนหัวและส่วนท้ายในมาสเตอร์โน๊ต**

มาสเตอร์โน๊ตกำหนดการจัดรูปแบบและพฤติกรรมตัวแทนสำหรับหน้าบันทึก ใช้คลาส [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masternotesslideheaderfootermanager/) เมื่อคุณต้องการเปลี่ยนแปลงเฉพาะมาสเตอร์โน๊ตเท่านั้น

ตัวอย่างต่อไปนี้ตั้งค่าส่วนหัว, ส่วนท้าย, และข้อความวันที่/เวลาในมาสเตอร์โน๊ต และทำให้ตัวแทนที่รองรับทั้งหมดมองเห็นได้บนมาสเตอร์นั้น:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

เมธอด [`getMasterNotesSlide`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) จะคืนค่า `null` เมื่อการนำเสนอไม่มีมาสเตอร์โน๊ต

## **นำการตั้งค่ามาสเตอร์โน๊ตไปใช้กับสไลด์โน๊ตชิลด์**

มาสเตอร์โน๊ตสามารถนำการตั้งค่าส่วนหัวและส่วนท้ายไปใช้กับตัวเองและสไลด์โน๊ตที่เกี่ยวข้องทั้งหมด ใช้วิธีการกระจายที่กำหนดไว้ใน [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masternotesslideheaderfootermanager/) เมื่อการตั้งค่าเดียวกันต้องใช้ทั่วทั้งโครงสร้างโน๊ต

เช่นเมธอด [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) และ [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) จะอัปเดตส่วนหัวของมาสเตอร์โน๊ตและส่วนหัวของสไลด์ลูกทั้งหมด วิธีการที่เทียบเคียงกันก็มีสำหรับส่วนท้าย, วันที่/เวลา, และหมายเลขสไลด์

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

วิธีการกระจายที่ใช้ด้านบนคือ [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), และ [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)

## **ตั้งค่าส่วนหัวและส่วนท้ายในสไลด์โน๊ตแต่ละหน้า**

สไลด์โน๊ตเป็นของสไลด์ปกติเฉพาะ ใช้คลาส [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/php-java/aspose.slides/notesslideheaderfootermanager/) เมื่อคุณต้องการปรับแต่งเพียงหน้าบันทึกนั้นเท่านั้น

เมธอด [`addNotesSlide`](https://reference.aspose.com/slides/th/php-java/aspose.slides/notesslidemanager/addnotesslide/) คืนค่าสไลด์โน๊ตของสไลด์ปัจจุบันและสร้างใหม่หากยังไม่มี ตัวอย่างต่อไปนี้กำหนดค่าหน้าบันทึกที่เชื่อมกับสไลด์แรกของการนำเสนอ:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

หากคุณกระจายการตั้งค่าจากมาสเตอร์โน๊ตก่อน แล้วเปลี่ยนแปลงสไลด์โน๊ตแต่ละหน้า การตั้งค่าต่อมาจะทำให้คุณปรับแต่งหน้าบันทึกนั้นได้อย่างอิสระ

## **ตั้งค่าส่วนหัวและส่วนท้ายในมาสเตอร์เอกสารแจก**

หน้าจำนวนใช้มาสเตอร์เอกสารแจกสำหรับส่วนหัว, ส่วนท้าย, วันที่/เวลา, และตัวแทนหมายเลขหน้า ต่างจากหน้าบันทึก การตั้งค่าเอกสารแจกจะจัดการผ่านมาสเตอร์เอกสารแจก ไม่ใช่ผ่านสไลด์เอกสารแจกแต่ละหน้า

ใช้เมธอด [`getMasterHandoutSlide`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) เพื่อเข้าถึงมาสเตอร์เอกสารแจก หากไม่มีให้เรียกเมธอด [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) เพื่อสร้างมาสเตอร์เอกสารแจกเริ่มต้น

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ทำความเข้าใจขอบเขตและการสืบทอด**

เลือกผู้จัดการส่วนหัว/ส่วนท้ายที่ตรงกับขอบเขตที่คุณต้องการเปลี่ยนแปลง:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/th/php-java/aspose.slides/slideheaderfootermanager/) เปลี่ยนการตั้งค่าส่วนท้าย, วันที่/เวลา, และหมายเลขสไลด์สำหรับสไลด์ปกติหนึ่งสไลด์
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/php-java/aspose.slides/layoutslideheaderfootermanager/) ควบคุมสไลด์เลเอาต์และสามารถกระจายการตั้งค่าที่รองรับไปยังสไลด์ที่เกี่ยวข้อง
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterslideheaderfootermanager/) ควบคุมมาสเตอร์สไลด์ปกติและสามารถกระจายการตั้งค่าที่รองรับไปยังสไลด์ที่เกี่ยวข้อง
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masternotesslideheaderfootermanager/) ควบคุมมาสเตอร์โน๊ตและสามารถกระจายการตั้งค่าไปยังสไลด์โน๊ตที่เกี่ยวข้องทั้งหมด
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/php-java/aspose.slides/notesslideheaderfootermanager/) เปลี่ยนสไลด์โน๊ตหนึ่งสไลด์และสนับสนุ.partsrumันส่วนหัวนอกเหนือจากส่วนท้าย, วันที่/เวลา, และหมายเลขสไลด์
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) เปลี่ยนมาสเตอร์เอกสารแจกและสนับสนุนตัวแทนสี่ประเภททั้งหมด

ใช้การกระจายจากมาสเตอร์หรือเลเอาต์เมื่อการตั้งค่าเดียวกันควรใช้ทั่วทั้งโครงสร้าง ใช้ผู้จัดการสไลด์หรือนโน๊ต-สไลด์เฉพาะเมื่อคุณต้องการการตั้งค่าท้องถิ่นสำหรับหนึ่งหน้า

## **คำถามที่พบบ่อย**

**ฉันสามารถเพิ่มส่วนหัวให้กับสไลด์ปกติได้หรือไม่?**

ไม่ได้ PowerPoint ไม่ได้กำหนดตัวแทนส่วนหัวสำหรับสไลด์ปกติ ในสไลด์ปกติให้ใช้ส่วนท้าย, วันที่/เวลา, และหมายเลขสไลด์ ตัวแทนส่วนหัวมีอยู่ในหน้าบันทึกและเอกสารแจก

**ถ้าตัวแทนส่วนท้าย, วันที่/เวลา, หรือหมายเลขสไลด์ไม่มองเห็นจะทำอย่างไร?**

ใช้ผู้จัดการส่วนหัว/ส่วนท้ายที่สอดคล้องกันเพื่อตรวจสอบการมองเห็นและเปิดใช้งานเมื่อจำเป็น ตัวอย่างเช่นเมธอด [`isFooterVisible`](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) รายงานว่าตัวแทนส่วนท้ายมีอยู่หรือไม่ และเมธอด [`setFooterVisibility`](https://reference.aspose.com/slides/th/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) เปลี่ยนการมองเห็นของมัน

**ฉันจะเริ่มต้นการนับหมายเลขสไลด์จากค่าที่ไม่ใช่ 1 ได้อย่างไร?**

เรียกเมธอด [`setFirstSlideNumber`](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/setfirstslidenumber/) ของการนำเสนอ ตัวแทนหมายเลขสไลด์จะใช้ลำดับหมายเลขที่อัปเดตแล้ว

**ส่วนหัวและส่วนท้ายจะเกิดอะไรขึ้นเมื่อส่งออกเป็น PDF, รูปภาพ, หรือ HTML?**

องค์ประกอบส่วนหัวและส่วนท้ายที่มองเห็นได้จะถูกเรนเดอร์พร้อมกับเนื้อหาการนำเสนอในรูปแบบผลลัพธ์ การแสดงผลขึ้นอยู่กับประเภทของหน้าที่กำลังส่งออกและการตั้งค่าการมองเห็นของตัวแทนที่สอดคล้องกัน