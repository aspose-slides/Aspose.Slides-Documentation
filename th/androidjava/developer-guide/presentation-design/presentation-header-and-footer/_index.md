---
title: จัดการส่วนหัวและส่วนท้ายของการนำเสนอบน Android
linktitle: ส่วนหัวและส่วนท้าย
type: docs
weight: 140
url: /th/androidjava/presentation-header-and-footer/
keywords:
- ส่วนหัว
- ข้อความส่วนหัว
- ส่วนท้าย
- ข้อความส่วนท้าย
- ตั้งส่วนหัว
- ตั้งส่วนท้าย
- เอกสารแจก
- บันทึกย่อ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการตำแหน่งส่วนท้าย, วันที่-เวลา, หมายเลขสไลด์, และส่วนหัวบนสไลด์, หน้าบันทึกย่อ, และเอกสารแจกด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

PowerPoint ใช้ตำแหน่งข้อความส่วนหัวและส่วนล่างที่แตกต่างกันตามประเภทของหน้า Aspose.Slides for Android ผ่าน Java ให้คุณควบคุมข้อความและการมองเห็นของตำแหน่งเหล่านี้ผ่านอินเทอร์เฟซผู้จัดการส่วนหัว/ส่วนล่าง

ตำแหน่งที่ใช้ได้ขึ้นอยู่กับขอบเขต:

| ขอบเขต | ส่วนหัว | ส่วนล่าง | วันที่/เวลา | หมายเลขสไลด์/หน้า |
|---|---|---|---|---|
| สไลด์ปกติ | ไม่ | ใช่ | ใช่ | ใช่ |
| มาสเตอร์บันทึกย่อ | ใช่ | ใช่ | ใช่ | ใช่ |
| สไลด์บันทึกย่อ | ใช่ | ใช่ | ใช่ | ใช่ |
| มาสเตอร์เอกสารแจก | ใช่ | ใช่ | ใช่ | ใช่ |

สไลด์การนำเสนอปกติไม่มีตำแหน่งข้อความส่วนหัว ส่วนหัวจะปรากฏบนหน้าบันทึกย่อและเอกสารแจก สำหรับสไลด์ปกติให้ใช้ตำแหน่งส่วนล่าง, วันที่/เวลา และหมายเลขสไลด์แทน

ขอบเขตของการเปลี่ยนแปลงขึ้นอยู่กับผู้จัดการที่คุณใช้ อินเทอร์เฟซ[`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideheaderfootermanager/) ควบคุมสไลด์ปกติหนึ่งสไลด์ อินเทอร์เฟซ[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) ควบคุมสไลด์บันทึกย่อหนึ่งสไลด์ ผู้จัดการมาสเตอร์และเค้าโครงสามารถแพร่กระจายการตั้งค่าไปยังสไลด์ที่ขึ้นอยู่ได้ ขณะที่อินเทอร์เฟซ[`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) ควบคุมมาสเตอร์เอกสารแจก

## **ตั้งส่วนล่าง, วันที่/เวลา, และหมายเลขสไลด์บนสไลด์ปกติ**

สำหรับสไลด์ปกติ กระบวนการพื้นฐานคือเข้าถึงผู้จัดการส่วนหัว/ส่วนล่างของแต่ละสไลด์ ตั้งข้อความส่วนล่างและวันที่/เวลา เปิดใช้งานตำแหน่งที่ต้องการ แล้วบันทึกการนำเสนอ หมายเลขสไลด์จะถูกสร้างโดยอัตโนมัติ ดังนั้นคุณเพียงแค่ควบคุมการแสดงผลของมัน

ใช้[`setFooterText`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-)และ[`setDateTimeText`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-)เพื่อกำหนดข้อความ และใช้[`setFooterVisibility`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-),[`setDateTimeVisibility`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-),และ[`setSlideNumberVisibility`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-)เพื่อแสดงตำแหน่งที่สอดคล้องกัน

ตัวอย่างต่อไปนี้เป็นการประยุกต์ใช้ส่วนล่าง, ข้อความวันที่/เวลา, และการมองเห็นหมายเลขสไลด์เดียวกันกับสไลด์ปกติทั้งหมด:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากคุณต้องการอัปเดตเพียงสไลด์เดียว ให้เข้าถึงสไลด์นั้นโดยตรงผ่านเมธอด[`getSlides`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getSlides--)แทนการวนลูปผ่านคอลเลกชันทั้งหมด

## **ตั้งส่วนหัวและส่วนล่างบนมาสเตอร์บันทึกย่อ**

มาสเตอร์บันทึกย่อกำหนดรูปแบบทั่วไปและพฤติกรรมตำแหน่งของหน้าบันทึกย่อ ใช้อินเทอร์เฟซ[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) เมื่อคุณต้องการเปลี่ยนแปลงเฉพาะมาสเตอร์บันทึกย่อเอง

ตัวอย่างต่อไปนี้ตั้งส่วนหัว, ส่วนล่าง, และข้อความวันที่/เวลาบนมาสเตอร์บันทึกย่อและทำให้ตำแหน่งที่รองรับทั้งหมดแสดงผลบนมาสเตอร์นั้น:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมธอด[`getMasterNotesSlide`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) จะคืนค่า `null` เมื่อการนำเสนอไม่มีมาสเตอร์บันทึกย่อ

## **ใช้การตั้งค่ามาสเตอร์บันทึกย่อกับสไลด์บันทึกย่อลูก**

มาสเตอร์บันทึกย่อสามารถประยุกต์ใช้การตั้งค่าส่วนหัวและส่วนล่างกับตัวมันเองและกับสไลด์บันทึกย่อที่ขึ้นอยู่ทั้งหมด ใช้เมธอดการแพร่กระจายเฉพาะบน[`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) เมื่อต้องการใช้การตั้งค่าเดียวกันทั่วทั้งระดับบันทึกย่อ

เช่น[`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-)และ[`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-)จะอัปเดตส่วนหัวของมาสเตอร์บันทึกย่อและส่วนหัวของสไลด์ลูกทั้งหมด มีเมธอดเทียบเคียงสำหรับส่วนล่าง, วันที่/เวลา, และหมายเลขสไลด์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เมธอดการแพร่กระจายที่ใช้ด้านบนได้แก่[`setFooterAndChildFootersText`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-),[`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-),[`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-),[`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-),และ[`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-)

## **ตั้งส่วนหัวและส่วนล่างบนสไลด์บันทึกย่อแต่ละรายการ**

สไลด์บันทึกย่อเป็นส่วนหนึ่งของสไลด์ปกติเฉพาะ ใช้อินเทอร์เฟซ[`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) เมื่อคุณต้องการปรับแต่งเพียงหน้าบันทึกย่อนั้น

เมธอด[`addNotesSlide`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) จะคืนค่าหน้าบันทึกย่อสำหรับสไลด์ปัจจุบันและสร้างใหม่หากยังไม่มี ตัวอย่างต่อไปนี้กำหนดค่าหน้าบันทึกย่อที่เชื่อมโยงกับสไลด์แรกของการนำเสนอ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากคุณแรกเริ่มแพร่กระจายการตั้งค่าจากมาสเตอร์บันทึกย่อแล้วจึงเปลี่ยนสไลด์บันทึกย่อรายบุคคล การตั้งค่าที่ทำภายหลังจะทำให้คุณปรับแต่งหน้านั้นได้อย่างอิสระ

## **ตั้งส่วนหัวและส่วนล่างบนมาสเตอร์เอกสารแจก**

หน้ากระดาษแจกใช้มาสเตอร์เอกสารแจกสำหรับส่วนหัว, ส่วนล่าง, วันที่/เวลา, และตำแหน่งหมายเลขหน้า ต่างจากหน้าบันทึกย่อ การตั้งค่าเอกสารแจกจัดการผ่านมาสเตอร์เอกสารแจกแทนสไลด์เอกสารแจกแต่ละหน้า

ใช้เมธอด[`getMasterHandoutSlide`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) เพื่อเข้าถึงมาสเตอร์เอกสารแจก หากไม่มีให้เรียก[`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) เพื่อสร้างมาสเตอร์เอกสารแจกเริ่มต้น

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เข้าใจขอบเขตและการสืบทอด**

เลือกผู้จัดการส่วนหัว/ส่วนล่างที่ตรงกับขอบเขตที่คุณต้องการเปลี่ยนแปลง:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islideheaderfootermanager/) เปลี่ยนการตั้งค่าส่วนล่าง, วันที่/เวลา, และหมายเลขสไลด์สำหรับสไลด์ปกติหนึ่งสไลด์
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) ควบคุมสไลด์เค้าโครงและสามารถแพร่กระจายการตั้งค่าที่รองรับไปยังสไลด์ที่ขึ้นอยู่
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) ควบคุมมาสเตอร์สไลด์ปกติและสามารถแพร่กระจายการตั้งค่าที่รองรับไปยังสไลด์ที่ขึ้นอยู่
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) ควบคุมมาสเตอร์บันทึกย่อและสามารถแพร่กระจายการตั้งค่าไปยังสไลด์บันทึกย่องทั้งหมด
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) เปลี่ยนสไลด์บันทึกย่อหนึ่งสไลด์และรองรับส่วนหัวนอกเหนือจากส่วนล่าง, วันที่/เวลา, และหมายเลขสไลด์
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) เปลี่ยนมาสเตอร์เอกสารแจกและรองรับตำแหน่งสี่ประเภททั้งหมด

ใช้การแพร่กระจายจากมาสเตอร์หรือเค้าโครงเมื่อการตั้งค่าเดียวกันควรใช้ทั่วทั้งระดับ ใช้ผู้จัดการสไลด์หรือสไลด์บันทึกย่อแยกเมื่อต้องการการตั้งค่าท้องถิ่นสำหรับหน้าเดียว

## **คำถามที่พบบ่อย**

**ฉันสามารถเพิ่มส่วนหัวในสไลด์ปกติได้หรือไม่?**

ไม่ PowerPoint ไม่ได้กำหนดตำแหน่งส่วนหัวสำหรับสไลด์ปกติ บนสไลด์ปกติให้ใช้ส่วนล่าง, วันที่/เวลา, และหมายเลขสไลด์ ส่วนหัวจะมีเฉพาะบนหน้าบันทึกย่อและเอกสารแจก

**ถ้าตำแหน่งส่วนล่าง, วันที่/เวลา, หรือหมายเลขสไลด์ไม่แสดงผลจะทำอย่างไร?**

ใช้ผู้จัดการส่วนหัว/ส่วนล่างที่เกี่ยวข้องเพื่อตรวจสอบการมองเห็นและเปิดใช้งานเมื่อจำเป็น ตัวอย่างเช่น[`isFooterVisible`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) จะรายงานว่ามีส่วนล่างอยู่หรือไม่, และ[`setFooterVisibility`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) จะเปลี่ยนการมองเห็นของมัน

**ฉันจะเริ่มหมายเลขสไลด์จากค่าที่ไม่ใช่ 1 ได้อย่างไร?**

เรียกเมธอด[`setFirstSlideNumber`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) ของการนำเสนอ หมายเลขสไลด์จะใช้ลำดับที่อัปเดตแล้ว

**ส่วนหัวและส่วนล่างจะเป็นอย่างไรเมื่อส่งออกเป็น PDF, รูปภาพ หรือ HTML?**

ส่วนหัวและส่วนล่างที่มองเห็นได้จะถูกเรนเดอร์พร้อมกับเนื้อหาการนำเสนอในรูปแบบผลลัพธ์ การปรากฏของพวกมันขึ้นอยู่กับประเภทของหน้าที่กำลังส่งออกและการตั้งค่าการมองเห็นของตำแหน่งเหล่านั้น