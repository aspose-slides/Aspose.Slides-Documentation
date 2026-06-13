---
title: จัดการส่วนหัวและส่วนท้ายของงานนำเสนอบน Android
linktitle: ส่วนหัว & ส่วนท้าย
type: docs
weight: 140
url: /th/androidjava/presentation-header-and-footer/
keywords:
- ส่วนหัว
- ข้อความส่วนหัว
- ส่วนท้าย
- ข้อความส่วนท้าย
- ตั้งค่า ส่วนหัว
- ตั้งค่า ส่วนท้าย
- แฮนด์เอาต์
- หมายเหตุ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ใช้ Aspose.Slides สำหรับ Android ผ่าน Java เพื่อเพิ่มและปรับแต่งส่วนหัวและส่วนท้ายในงานนำเสนอ PowerPoint และ OpenDocument เพื่อให้ดูเป็นมืออาชีพ"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณจัดการการตั้งค่าส่วนหัวและส่วนท้ายในงานนำเสนอ PowerPoint ได้ ส่วนหัวและส่วนท้ายจะถูกจัดการระดับมาสเตอร์ของงานนำเสนอ และ API จะมีเมธอดสำหรับการตั้งค่าข้อความส่วนท้าย การเปลี่ยนการมองเห็นของส่วนท้าย และการอัปเดตข้อความส่วนหัวบนสไลด์หมายเหตุมาสเตอร์

คุณยังสามารถจัดการส่วนหัวและส่วนท้ายสำหรับสไลด์แฮนด์เอาต์และสไลด์บันทึกหมายเหตุได้ รวมถึงการเปลี่ยนการมองเห็นและข้อความของตัวแทนส่วนหัว ส่วนท้าย หมายเลขสไลด์ และวัน‑เวลา สำหรับมาสเตอร์หมายเหตุ สไลด์หมายเหตุทั้งหมดที่เป็นลูก หรือสไลด์หมายเหตุบุคคลใดบุคคลหนึ่ง

## **จัดการส่วนหัวและส่วนท้ายในงานนำเสนอ**
บันทึกหมายเหตุของสไลด์บางสไลด์อาจถูกลบตามตัวอย่างด้านล่าง:

```java
// โหลดงานนำเสนอ
Presentation pres = new Presentation("headerTest.pptx");
try {
    // ตั้งค่าส่วนท้าย
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // เข้าถึงและอัปเดตส่วนหัว
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // บันทึกงานนำเสนอ
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// วิธีตั้งข้อความส่วนหัว/ส่วนท้าย
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **จัดการส่วนหัวและส่วนท้ายบนสไลด์แฮนด์เอาต์และบันทึกหมายเหตุ**
Aspose.Slides สำหรับ Android ผ่าน Java รองรับส่วนหัวและส่วนท้ายในสไลด์แฮนด์เอาต์และสไลด์หมายเหตุ โปรดทำตามขั้นตอนด้านล่าง:

- โหลด [งานนำเสนอ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่มีวิดีโอ
- เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับมาสเตอร์หมายเหตุและสไลด์หมายเหตุทั้งหมด
- ตั้งให้สไลด์หมายเหตุมาสเตอร์และตัวแทนส่วนท้ายของลูกทั้งหมดมองเห็นได้
- ตั้งให้สไลด์หมายเหตุมาสเตอร์และตัวแทนวัน‑เวลา ของลูกทั้งหมดมองเห็นได้
- เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับสไลด์หมายเหตุแรกเท่านั้น
- ตั้งให้ตัวแทนส่วนหัวของสไลด์หมายเหตุมองเห็นได้
- ตั้งข้อความให้กับตัวแทนส่วนหัวของสไลด์หมายเหตุ
- ตั้งข้อความให้กับตัวแทนวัน‑เวลาของสไลด์หมายเหตุ
- เขียนไฟล์งานนำเสนอที่แก้ไขแล้ว

ตัวอย่างโค้ดที่ให้ไว้ด้านล่าง

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับมาสเตอร์หมายเหตุและสไลด์หมายเหตุทั้งหมด
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // ทำให้สไลด์หมายเหตุมาสเตอร์และตัวแทน Footer ลูกทั้งหมดมองเห็นได้
        headerFooterManager.setFooterAndChildFootersVisibility(true); // ทำให้สไลด์หมายเหตุมาสเตอร์และตัวแทน Header ลูกทั้งหมดมองเห็นได้
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // ทำให้สไลด์หมายเหตุมาสเตอร์และตัวแทน SlideNumber ลูกทั้งหมดมองเห็นได้
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // ทำให้สไลด์หมายเหตุมาสเตอร์และตัวแทน Date and time ลูกทั้งหมดมองเห็นได้

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // ตั้งข้อความให้สไลด์หมายเหตุมาสเตอร์และตัวแทน Header ลูกทั้งหมด
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // ตั้งข้อความให้สไลด์หมายเหตุมาสเตอร์และตัวแทน Footer ลูกทั้งหมด
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // ตั้งข้อความให้สไลด์หมายเหตุมาสเตอร์และตัวแทน Date and time ลูกทั้งหมด
    }

    // เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับสไลด์หมายเหตุแรกเท่านั้น
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // ทำให้ตัวแทน Header ของสไลด์หมายเหตุนี้มองเห็นได้

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // ทำให้ตัวแทน Footer ของสไลด์หมายเหตุนี้มองเห็นได้

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // ทำให้ตัวแทน SlideNumber ของสไลด์หมายเหตุนี้มองเห็นได้

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // ทำให้ตัวแทน Date-time ของสไลด์หมายเหตุนี้มองเห็นได้

        headerFooterManager.setHeaderText("New header text"); // ตั้งข้อความให้ตัวแทน Header ของสไลด์หมายเหตุ
        headerFooterManager.setFooterText("New footer text"); // ตั้งข้อความให้ตัวแทน Footer ของสไลด์หมายเหตุ
        headerFooterManager.setDateTimeText("New date and time text"); // ตั้งข้อความให้ตัวแทน Date-time ของสไลด์หมายเหตุ
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเพิ่ม "ส่วนหัว" ลงในสไลด์ปกติได้หรือไม่?**

ใน PowerPoint "ส่วนหัว" มีอยู่เฉพาะสำหรับหมายเหตุและแฮนด์เอาต์; บนสไลด์ปกติ จะสนับสนุนเพียงส่วนท้าย, วัน‑เวลา, และหมายเลขสไลด์เท่านั้น ใน Aspose.Slides จะตรงกับข้อจำกัดเดียวกัน: ส่วนหัวใช้ได้เฉพาะหมายเหตุ/แฮนด์เอาต์ และบนสไลด์—ส่วนท้าย/วัน‑เวลา/หมายเลขสไลด์

**ถ้าตัวแบบไม่มีพื้นที่ส่วนท้าย—ฉันสามารถ "เปิด" การมองเห็นได้หรือไม่?**

ได้ ตรวจสอบการมองเห็นผ่านผู้จัดการส่วนหัว/ส่วนท้ายและเปิดใช้งานหากจำเป็น API เหล่านี้ออกแบบมาสำหรับกรณีที่ตัวแทนหายไปหรือถูกซ่อนไว้

**ฉันจะทำให้หมายเลขสไลด์เริ่มจากค่าอื่นที่ไม่ใช่ 1 อย่างไร?**

ตั้งค่า [หมายเลขสไลด์แรก](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-); หลังจากนั้นการนับทั้งหมดจะถูกคำนวณใหม่ ตัวอย่างเช่น คุณสามารถเริ่มที่ 0 หรือ 10 และซ่อนหมายเลขบนสไลด์หัวเรื่องได้

**ส่วนหัว/ส่วนท้ายจะเป็นอย่างไรเมื่อส่งออกเป็น PDF/รูปภาพ/HTML?**

พวกมันจะถูกเรนเดอร์เป็นองค์ประกอบข้อความปกติของงานนำเสนอ นั่นหมายความว่า หากองค์ประกอบเหล่านั้นมองเห็นได้บนสไลด์หรือหน้าหมายเหตุ ก็จะปรากฏในรูปแบบผลลัพธ์พร้อมกับเนื้อหาอื่น ๆ.