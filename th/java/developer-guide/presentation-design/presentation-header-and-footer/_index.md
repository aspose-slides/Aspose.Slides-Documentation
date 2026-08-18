---
title: จัดการหัวเรื่องและท้ายเรื่องของการนำเสนอใน Java
linktitle: หัวเรื่องและท้ายเรื่อง
type: docs
weight: 140
url: /th/java/presentation-header-and-footer/
keywords:
- หัวเรื่อง
- ข้อความหัวเรื่อง
- ท้ายเรื่อง
- ข้อความท้ายเรื่อง
- ตั้งค่าหัวเรื่อง
- ตั้งค่าท้ายเรื่อง
- เอกสารแจกจ่าย
- บันทึกย่อ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการตัวยึดท้ายเรื่อง, วันที่-เวลา, หมายเลขสไลด์, และหัวเรื่องบนสไลด์, หน้าใบบันทึกย่อ, และเอกสารแจกจ่ายด้วย Aspose.Slides for Java."
---
## **ภาพรวม**

PowerPoint ใช้ตัวยึดหัวเรื่องและท้ายเรื่องที่ต่างกันขึ้นอยู่กับประเภทของหน้า Aspose.Slides for Java ให้คุณควบคุมข้อความและการมองเห็นของตัวยึดเหล่านี้ผ่านอินเทอร์เฟซผู้จัดการหัวเรื่อง/ท้ายเรื่อง

ตัวยึดที่มีให้ขึ้นอยู่กับขอบเขต:

| ขอบเขต | หัวเรื่อง | ท้ายเรื่อง | วันที่/เวลา | หมายเลขสไลด์/หน้า |
|---|---|---|---|---|
| สไลด์ทั่วไป | ไม่มี | มี | มี | มี |
| มาสเตอร์บันทึกย่อ | มี | มี | มี | มี |
| สไลด์บันทึกย่อ | มี | มี | มี | มี |
| มาสเตอร์แจกจ่าย | มี | มี | มี | มี |

สไลด์การนำเสนอปกติจะไม่มีตัวยึดหัวเรื่อง หัวเรื่องจะมีอยู่บนหน้าบันทึกย่อและเอกสารแจกจ่าย สำหรับสไลด์ปกติให้ใช้ตัวยึดท้ายเรื่อง, วันที่/เวลา, และหมายเลขสไลด์แทน

ขอบเขตของการเปลี่ยนแปลงขึ้นอยู่กับผู้จัดการที่คุณใช้ อินเทอร์เฟซ [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideheaderfootermanager/) ควบคุมสไลด์ทั่วไปหนึ่งสไลด์ อินเทอร์เฟซ [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/java/com.aspose.slides/inotesslideheaderfootermanager/) ควบคุมสไลด์บันทึกย่อหนึ่งสไลด์ ผู้จัดการมาสเตอร์และเลย์เอาต์ยังสามารถกระจายการตั้งค่าไปยังสไลด์ที่ขึ้นอยู่ได้ ในขณะที่อินเทอร์เฟซ [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) ควบคุมมาสเตอร์เอกสารแจกจ่าย

## **ตั้งท้ายเรื่อง, วันที่/เวลา, และหมายเลขสไลด์บนสไลด์ทั่วไป**

สำหรับสไลด์ทั่วไป ขั้นตอนพื้นฐานคือการเข้าถึงผู้จัดการหัวเรื่อง/ท้ายเรื่องของแต่ละสไลด์ ตั้งค่าข้อความท้ายเรื่องและวันที่/เวลา เปิดใช้งานตัวยึดที่จำเป็น และบันทึกการนำเสนอ หมายเลขสไลด์จะถูกสร้างโดยการนำเสนอ ดังนั้นคุณเพียงต้องควบคุมการมองเห็นของมันเท่านั้น

ใช้ [`setFooterText`](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) และ [`setDateTimeText`](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) เพื่อตั้งค่าข้อความ และใช้ [`setFooterVisibility`](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), และ [`setSlideNumberVisibility`](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) เพื่อแสดงตัวยึดที่สอดคล้องกัน

ตัวอย่างเต็มขั้นต่อไปนี้นำการตั้งค่าส่วนท้าย, ข้อความวันที่/เวลา, และการมองเห็นหมายเลขสไลด์เดียวกันไปยังสไลด์ทั่วไปทั้งหมด:

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

หากคุณต้องการอัปเดตเพียงสไลด์เดียว ให้เข้าถึงสไลด์นั้นโดยตรงผ่านเมธอด [`getSlides`](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getSlides--) แทนการวนลูปผ่านคอลเลกชันทั้งหมด

## **ตั้งหัวเรื่องและท้ายเรื่องบนโน้ตมาสเตอร์**

โน้ตมาสเตอร์กำหนดรูปแบบทั่วไปและพฤติกรรมของตัวยึดสำหรับหน้าบันทึกย่อ ใช้อินเทอร์เฟซ [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasternotesslideheaderfootermanager/) เมื่อคุณต้องการเปลี่ยนแปลงเพียงโน้ตมาสเตอร์เท่านั้น

ตัวอย่างต่อไปนี้ตั้งหัวเรื่อง, ท้ายเรื่อง, และข้อความวันที่/เวลาในโน้ตมาสเตอร์และทำให้ตัวยึดที่รองรับทั้งหมดมองเห็นได้บนมาสเตอร์นั้น:

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

เมธอด [`getMasterNotesSlide`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) จะคืนค่า `null` เมื่อการนำเสนอไม่มีโน้ตมาสเตอร์

## **ใช้การตั้งค่าโน้ตมาสเตอร์กับสไลด์บันทึกย่อย**

โน้ตมาสเตอร์สามารถนำการตั้งค่าหัวเรื่องและท้ายเรื่องไปใช้กับตัวมันเองและกับสไลด์บันทึกย่อยทั้งหมดได้ ใช้วิธีการกระจายเฉพาะบน [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasternotesslideheaderfootermanager/) เมื่อการตั้งค่าเดียวกันควรใช้ทั่วทั้งระดับโน้ต

เช่น [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) และ [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) จะอัปเดตหัวเรื่องของโน้ตมาสเตอร์และหัวเรื่องของสไลด์ลูกทั้งหมด มีเมธอดที่เทียบเท่าสำหรับท้ายเรื่อง, วันที่/เวลา, และหมายเลขสไลด์

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

เมธอดกระจายที่ใช้ข้างต้นคือ [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), และ [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-)

## **ตั้งหัวเรื่องและท้ายเรื่องบนสไลด์บันทึกย่อเดี่ยว**

สไลด์บันทึกย่อเป็นของสไลด์ทั่วไปเฉพาะหนึ่งสไลด์ ใช้อินเทอร์เฟซ [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/java/com.aspose.slides/inotesslideheaderfootermanager/) เมื่อคุณต้องการปรับแต่งเพียงหน้าบันทึกย่อนั้นเท่านั้น

เมธอด [`addNotesSlide`](https://reference.aspose.com/slides/th/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) จะคืนค่าสไลด์บันทึกย่อสำหรับสไลด์ปัจจุบันและสร้างขึ้นหากยังไม่มี ตัวอย่างต่อไปนี้กำหนดค่าหน้าบันทึกย่อที่เชื่อมโยงกับสไลด์แรกของการนำเสนอ:

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

หากคุณแรกทำการกระจายการตั้งค่าจากโน้ตมาสเตอร์แล้วจึงเปลี่ยนแปลงสไลด์บันทึกย่อเดี่ยว การตั้งค่าแบบต่อสไลด์ภายหลังจะทำให้คุณปรับแต่งหน้าบันทึกย่อที่สอดคล้องได้อย่างอิสระ

## **ตั้งหัวเรื่องและท้ายเรื่องบนมาสเตอร์เอกสารแจกจ่าย**

หน้าการแจกจ่ายใช้มาสเตอร์การแจกจ่ายสำหรับตัวยึดหัวเรื่อง, ท้ายเรื่อง, วันที่/เวลา, และหมายเลขหน้า แตกต่างจากหน้าบันทึกย่อ การตั้งค่าการแจกจ่ายจะจัดการผ่านมาสเตอร์การแจกจ่ายไม่ใช่ผ่านสไลด์การแจกจ่ายแต่ละสไลด์

ใช้เมธอด [`getMasterHandoutSlide`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) เพื่อเข้าถึงมาสเตอร์การแจกจ่าย หากไม่มีให้เรียก [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) เพื่อสร้างมาสเตอร์การแจกจ่ายเริ่มต้น

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

เลือกผู้จัดการหัวเรื่อง/ท้ายเรื่องที่ตรงกับขอบเขตที่คุณต้องการเปลี่ยนแปลง:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/th/java/com.aspose.slides/islideheaderfootermanager/) เปลี่ยนการตั้งค่าท้ายเรื่อง, วันที่/เวลา, และหมายเลขสไลด์สำหรับสไลด์ทั่วไปหนึ่งสไลด์
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslideheaderfootermanager/) ควบคุมสไลด์เลย์เอาต์และสามารถกระจายการตั้งค่าที่รองรับไปยังสไลด์ที่ขึ้นอยู่
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslideheaderfootermanager/) ควบคุมมาสเตอร์สไลด์ทั่วไปและสามารถกระจายการตั้งค่าที่รองรับไปยังสไลด์ที่ขึ้นอยู่
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasternotesslideheaderfootermanager/) ควบคุมโน้ตมาสเตอร์และสามารถกระจายการตั้งค่าไปยังสไลด์บันทึกย่อที่ขึ้นอยู่ทั้งหมด
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/java/com.aspose.slides/inotesslideheaderfootermanager/) เปลี่ยนสไลด์บันทึกย่อหนึ่งสไลด์และสนับสนุนตัวยึดหัวเรื่องนอกจากท้ายเรื่อง, วันที่/เวลา, และหมายเลขสไลด์
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) เปลี่ยนมาสเตอร์การแจกจ่ายและสนับสนุนประเภทตัวยึดสี่ประเภททั้งหมด

ใช้การกระจายจากมาสเตอร์หรือเลย์เอาต์เมื่อการตั้งค่าเดียวกันควรใช้ทั่วทั้งลำดับชั้นของมัน ใช้ผู้จัดการสไลด์เดี่ยวหรือสไลด์บันทึกย่อเมื่อคุณต้องการการตั้งค่าท้องถิ่นสำหรับหนึ่งหน้า

## **คำถามที่พบบ่อย**

**ฉันสามารถเพิ่มหัวเรื่องในสไลด์ทั่วไปได้หรือไม่?**

ไม่ PowerPoint ไม่ได้กำหนดตัวยึดหัวเรื่องสำหรับสไลด์ทั่วไป ในสไลด์ทั่วไปให้ใช้ตัวยึดท้ายเรื่อง, วันที่/เวลา, และหมายเลขสไลด์ ตัวยึดหัวเรื่องมีอยู่บนหน้าบันทึกย่อและเอกสารแจกจ่าย

**ถ้าตัวยึดท้ายเรื่อง, วันที่/เวลา, หรือหมายเลขสไลด์ไม่ปรากฏเห็นจะทำอย่างไร?**

ใช้ผู้จัดการหัวเรื่อง/ท้ายเรื่องที่สอดคล้องเพื่อเช็คการมองเห็นและเปิดใช้งานตามความต้องการ ตัวอย่างเช่น [`isFooterVisible`](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) รายงานว่าตัวยึดท้ายเรื่องมีอยู่หรือไม่ และ [`setFooterVisibility`](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) เปลี่ยนการมองเห็นของมัน

**จะเริ่มหมายเลขสไลด์จากค่าที่ไม่ใช่ 1 ได้อย่างไร?**

เรียกเมธอด [`setFirstSlideNumber`](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) ของการนำเสนอ หมายเลขสไลด์จะใช้ลำดับเลขที่อัพเดต

**หัวเรื่องและท้ายเรื่องจะเป็นอย่างไรเมื่อส่งออกเป็น PDF, รูปภาพ หรือ HTML?**

ตัวยึดหัวเรื่องและท้ายเรื่องที่มองเห็นได้จะถูกเรนเดอร์พร้อมกับเนื้อหาการนำเสนออื่น ๆ ในรูปแบบผลลัพธ์ การแสดงผลขึ้นอยู่กับประเภทหน้าที่กำลังส่งออกและการตั้งค่าการมองเห็นของตัวยึดที่สอดคล้องกัน