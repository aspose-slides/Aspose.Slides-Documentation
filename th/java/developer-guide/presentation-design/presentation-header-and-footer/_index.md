---
title: จัดการส่วนหัวและส่วนท้ายของพรีเซนเทชันใน Java
linktitle: ส่วนหัวและส่วนท้าย
type: docs
weight: 140
url: /th/java/presentation-header-and-footer/
keywords:
- ส่วนหัว
- ข้อความส่วนหัว
- ส่วนท้าย
- ข้อความส่วนท้าย
- ตั้งส่วนหัว
- ตั้งส่วนท้าย
- สไลด์แจก
- โน้ต
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Java
- Aspose.Slides
description: "ใช้ Aspose.Slides for Java เพื่อเพิ่มและปรับแต่งส่วนหัวและส่วนท้ายในพรีเซนเทชัน PowerPoint และ OpenDocument เพื่อให้ได้ลุคแบบมืออาชีพ"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณจัดการการตั้งค่าส่วนหัวและส่วนท้ายในงานนำเสนอ PowerPoint ได้ ส่วนหัวและส่วนท้ายจะถูกจัดการระดับมาสเตอร์ของพรีเซนเทชัน และ API มีเมธอดสำหรับตั้งค่าข้อความส่วนท้าย, เปลี่ยนการมองเห็นของส่วนท้าย, และอัปเดตข้อความส่วนหัวบนสไลด์โน้ตมาสเตอร์

คุณสามารถจัดการส่วนหัวและส่วนท้ายสำหรับสไลด์ Handout และ Notes ได้เช่นกัน ซึ่งรวมถึงการเปลี่ยนการมองเห็นและข้อความของส่วนหัว, ส่วนท้าย, หมายเลขสไลด์, และตัวแสดงวันที่‑เวลา สำหรับโน้ตมาสเตอร์, สไลด์โน้ตลูกทั้งหมด, หรือสไลด์โน้ตคนเดียว

## **จัดการส่วนหัวและส่วนท้ายในพรีเซนเทชัน**
บันทึกของสไลด์บางสไลด์อาจถูกลบตามที่แสดงในตัวอย่างด้านล่าง:

```java
// โหลดพรีเซนเทชัน
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

    // บันทึกพรีเซนเทชัน
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// วิธีการตั้งค่าข้อความส่วนหัว/ส่วนท้าย
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

## **จัดการส่วนหัวและส่วนท้ายในสไลด์ Handout และ Notes**
Aspose.Slides for Java รองรับส่วนหัวและส่วนท้ายในสไลด์ Handout และ Notes กรุณาปฏิบัติตามขั้นตอนด้านล่าง:

- โหลด [การพรีเซนเทชัน](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่มีวิดีโอ
- เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับโน้ตมาสเตอร์และสไลด์โน้ตทั้งหมด
- ทำให้ตัวแทนส่วนท้ายของโน้ตมาสเตอร์และลูกทั้งหมดมองเห็นได้
- ทำให้ตัวแทนวันที่และเวลาของโน้ตมาสเตอร์และลูกทั้งหมดมองเห็นได้
- เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับสไลด์โน้ตแรกเท่านั้น
- ทำให้ตัวแทนส่วนหัวของสไลด์โน้ตมองเห็นได้
- ตั้งค่าข้อความให้กับตัวแทนส่วนหัวของสไลด์โน้ต
- ตั้งค่าข้อความให้กับตัวแทนวันที่‑เวลา ของสไลด์โน้ต
- เขียนไฟล์พรีเซนเทชันที่แก้ไขแล้ว

โค้ดตัวอย่างที่ให้ไว้ในตัวอย่างด้านล่าง

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับโน้ตมาสเตอร์และสไลด์โน้ตทั้งหมด
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // ทำให้สไลด์โน้ตมาสเตอร์และตัวแทน Footer ของลูกทั้งหมดมองเห็นได้
        headerFooterManager.setFooterAndChildFootersVisibility(true); // ทำให้สไลด์โน้ตมาสเตอร์และตัวแทน Header ของลูกทั้งหมดมองเห็นได้
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // ทำให้สไลด์โน้ตมาสเตอร์และตัวแทน SlideNumber ของลูกทั้งหมดมองเห็นได้
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // ทำให้สไลด์โน้ตมาสเตอร์และตัวแทน Date and time ของลูกทั้งหมดมองเห็นได้

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // ตั้งค่าข้อความให้สไลด์โน้ตมาสเตอร์และตัวแทน Header ของลูกทั้งหมด
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // ตั้งค่าข้อความให้สไลด์โน้ตมาสเตอร์และตัวแทน Footer ของลูกทั้งหมด
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // ตั้งค่าข้อความให้สไลด์โน้ตมาสเตอร์และตัวแทน Date and time ของลูกทั้งหมด
    }

    // เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับสไลด์โน้ตแรกเท่านั้น
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // ทำให้ตัวแทน Header ของสไลด์โน้ตนี้มองเห็นได้

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // ทำให้ตัวแทน Footer ของสไลด์โน้ตนี้มองเห็นได้

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // ทำให้ตัวแทน SlideNumber ของสไลด์โน้ตนี้มองเห็นได้

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // ทำให้ตัวแทน Date-time ของสไลด์โน้ตนี้มองเห็นได้

        headerFooterManager.setHeaderText("New header text"); // ตั้งค่าข้อความให้ตัวแทน Header ของสไลด์โน้ต
        headerFooterManager.setFooterText("New footer text"); // ตั้งค่าข้อความให้ตัวแทน Footer ของสไลด์โน้ต
        headerFooterManager.setDateTimeText("New date and time text"); // ตั้งค่าข้อความให้ตัวแทน Date-time ของสไลด์โน้ต
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเพิ่ม “ส่วนหัว” ให้กับสไลด์ทั่วไปได้ไหม?**

ใน PowerPoint “ส่วนหัว” มีเฉพาะสำหรับโน้ตและ Handout; สำหรับสไลด์ทั่วไปที่รองรับคือส่วนท้าย, วันที่/เวลา, และหมายเลขสไลด์ เท่านั้น ใน Aspose.Slides จะมีข้อจำกัดเดียวกัน: ส่วนหัวใช้ได้เฉพาะกับโน้ต/Handout, ส่วนสไลด์ทั่วไป—ส่วนท้าย/DateTime/SlideNumber

**ถ้าเลเอาต์ไม่มีพื้นที่ส่วนท้าย—ฉันจะเปิดการมองเห็นได้หรือไม่?**

ได้ ตรวจสอบการมองเห็นผ่านผู้จัดการส่วนหัว/ส่วนท้ายและเปิดใช้งานหากต้องการ ตัวบ่งชี้และเมธอดของ API นี้ออกแบบมาสำหรับกรณีที่ตัวแทนหายไปหรือถูกซ่อน

**ฉันจะทำให้หมายเลขสไลด์เริ่มจากค่าที่ไม่ใช่ 1 ได้อย่างไร?**

ตั้งค่า [หมายเลขสไลด์แรก](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-); หลังจากนั้นหมายเลขทั้งหมดจะถูกคำนวณใหม่ ตัวอย่างเช่น สามารถเริ่มจาก 0 หรือ 10 และซ่อนหมายเลขบนสไลด์หัวเรื่องได้

**ส่วนหัว/ส่วนท้ายจะเกิดอะไรขึ้นเมื่อส่งออกเป็น PDF/รูปภาพ/HTML?**

พวกมันจะถูกเรนเดอร์เป็นองค์ประกอบข้อความทั่วไปของพรีเซนเทชัน นั่นหมายความว่าถ้าหน่วยเหล่านั้นมองเห็นได้บนสไลด์/หน้าโน้ต พวกมันก็จะปรากฏในรูปแบบผลลัพธ์พร้อมกับเนื้อหาอื่น ๆ