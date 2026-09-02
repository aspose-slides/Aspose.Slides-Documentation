---
title: จัดการส่วนหัวและส่วนล่างของพรีเซนเทชันใน .NET
linktitle: ส่วนหัวและส่วนล่าง
type: docs
weight: 140
url: /th/net/presentation-header-and-footer/
keywords:
- ส่วนหัว
- ข้อความส่วนหัว
- ส่วนล่าง
- ข้อความส่วนล่าง
- ตั้งส่วนหัว
- ตั้งส่วนล่าง
- แฮนด์เอาต์
- โน้ต
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดการส่วนล่าง, วันที่-เวลา, หมายเลขสไลด์, และส่วนหัวของตัวเก็บตำแหน่งบนสไลด์, หน้าโน้ต, และแฮนด์เอาต์ด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

PowerPoint ใช้ส่วนหัวและส่วนล่างที่เป็นตัวเก็บตำแหน่ง (placeholder) แตกต่างกันตามประเภทของหน้า Aspose.Slides for .NET ให้คุณควบคุมข้อความและการแสดงของตัวเก็บตำแหน่งเหล่านี้ผ่านอินเทอร์เฟซตัวจัดการส่วนหัว/ส่วนล่าง

ตัวเก็บตำแหน่งที่มีให้ขึ้นอยู่กับขอบเขต:

| ขอบเขต | ส่วนหัว | ส่วนล่าง | วันที่/เวลา | หมายเลขสไลด์/หน้า |
|---|---|---|---|---|
| สไลด์ปกติ | ไม่ | ใช่ | ใช่ | ใช่ |
| โน้ตมาสเตอร์ | ใช่ | ใช่ | ใช่ | ใช่ |
| สไลด์โน้ต | ใช่ | ใช่ | ใช่ | ใช่ |
| มาสเตอร์แฮนด์เอาต์ | ใช่ | ใช่ | ใช่ | ใช่ |

สไลด์พรีเซนเทชันปกติไม่มีส่วนหัว ตัวหัวจะมีให้บนหน้าบันทึกย่อและแฮนด์เอาต์ สำหรับสไลด์ปกติ ให้ใช้ส่วนล่าง, วันที่/เวลา และส่วนเก็บหมายเลขสไลด์แทน

ขอบเขตของการเปลี่ยนแปลงขึ้นอยู่กับตัวจัดการที่คุณใช้ อินเทอร์เฟซ [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/th/net/aspose.slides/islideheaderfootermanager/) ควบคุมสไลด์ปกติหนึ่งสไลด์ อินเทอร์เฟซ [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/net/aspose.slides/inotesslideheaderfootermanager/) ควบคุมสไลด์โน้ตหนึ่งสไลด์ ตัวจัดการมาสเตอร์และเลเอาต์ยังสามารถกระจายการตั้งค่าไปยังสไลด์ที่ขึ้นกับได้ ในขณะที่อินเทอร์เฟซ [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/net/aspose.slides/imasterhandoutslideheaderfootermanager/) ควบคุมมาสเตอร์แฮนด์เอาต์

## **ตั้งค่าตัวล่าง, วันที่/เวลา, และหมายเลขสไลด์บนสไลด์ปกติ**

สำหรับสไลด์ปกติ กระบวนการพื้นฐานคือเข้าถึงตัวจัดการส่วนหัว/ส่วนล่างของแต่ละสไลด์ ตั้งค่าข้อความตัวล่างและวันที่/เวลา เปิดใช้งานตัวเก็บตำแหน่งที่ต้องการ แล้วบันทึกพรีเซนเทชัน หมายเลขสไลด์สร้างโดยพรีเซนเทชันเอง ดังนั้นคุณแค่ต้องควบคุมการมองเห็นของมัน

ใช้ [`SetFooterText`](https://reference.aspose.com/slides/th/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) และ [`SetDateTimeText`](https://reference.aspose.com/slides/th/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) เพื่อตั้งข้อความ และใช้ [`SetFooterVisibility`](https://reference.aspose.com/slides/th/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/th/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/), และ [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/th/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) เพื่อแสดงตัวเก็บตำแหน่งที่สอดคล้องกัน

ตัวอย่างต่อไปนี้เป็นแบบ end‑to‑end ที่ใช้ส่วนล่างเดียวกัน, ข้อความวันที่/เวลา, และการมองเห็นหมายเลขสไลด์บนสไลด์ปกติทั้งหมด:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

หากคุณต้องการอัปเดตเพียงสไลด์เดียว ให้เข้าถึงสไลด์นั้นโดยตรงผ่านคอลเลกชัน [`Slides`](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/slides/th/) แทนการวนลูปทั้งคอลเลกชัน

## **ตั้งค่าส่วนหัวและส่วนล่างบนโน้ตมาสเตอร์**

โน้ตมาสเตอร์กำหนดการจัดรูปแบบและพฤติกรรมของตัวเก็บตำแหน่งสำหรับหน้าบันทึกย่อ ใช้อินเทอร์เฟซ [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/net/aspose.slides/imasternotesslideheaderfootermanager/) เมื่อคุณต้องการเปลี่ยนแปลงเฉพาะโน้ตมาสเตอร์เท่านั้น

ตัวอย่างต่อไปนี้ตั้งค่าส่วนหัว, ส่วนล่าง, และข้อความวันที่/เวลาบนโน้ตมาสเตอร์และทำให้ตัวเก็บตำแหน่งที่สนับสนุนทั้งหมดมองเห็นได้บนมาสเตอร์นั้น:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

สมบัติ [`MasterNotesSlide`](https://reference.aspose.com/slides/th/net/aspose.slides/imasternotesslidemanager/masternotesslide/) จะคืนค่า `null` เมื่อพรีเซนเทชันไม่มีโน้ตมาสเตอร์

## **ใช้การตั้งค่าโน้ตมาสเตอร์กับสไลด์โน้ตลูก**

โน้ตมาสเตอร์สามารถนำการตั้งค่าส่วนหัวและส่วนล่างไปใช้กับตัวมันเองและสไลด์โน้ตที่ขึ้นกับทั้งหมด ใช้วิธีการกระจายเฉพาะบน [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/net/aspose.slides/imasternotesslideheaderfootermanager/) เมื่อต้องการใช้การตั้งค่าเดียวกันทั่วทั้งลำดับชั้นโน้ต

เช่นเมธอด [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/th/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) และ [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/th/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) จะอัปเดตส่วนหัวของโน้ตมาสเตอร์และส่วนหัวของสไลด์ลูกทั้งหมด เมธอดที่เทียบเท่ามีสำหรับส่วนล่าง, วันที่/เวลา, และหมายเลขสไลด์

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

เมธอดกระจายที่ใช้ข้างต้นได้แก่ [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/th/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/th/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/th/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/th/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), และ [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/th/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)

## **ตั้งค่าส่วนหัวและส่วนล่างบนสไลด์โน้ตเดี่ยว**

สไลด์โน้ตเป็นส่วนหนึ่งของสไลด์ปกติเฉพาะ ใช้อินเทอร์เฟซ [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/net/aspose.slides/inotesslideheaderfootermanager/) เมื่อคุณต้องการกำหนดค่าหน้าโน้ตเฉพาะนั้นเท่านั้น

เมธอด [`AddNotesSlide`](https://reference.aspose.com/slides/th/net/aspose.slides/inotesslidemanager/addnotesslide/) จะคืนค่าสไลด์โน้ตสำหรับสไลด์ปัจจุบันและสร้างสไลด์ใหม่หากยังไม่มี ตัวอย่างต่อไปนี้กำหนดค่าหน้าโน้ตที่เชื่อมต่อกับสไลด์พรีเซนเทชันแรก:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

หากคุณกระจายการตั้งค่าจากโน้ตมาสเตอร์ก่อนแล้วจึงเปลี่ยนสไลด์โน้ตเดี่ยว การตั้งค่าแบบต่อมาจะทำให้คุณปรับแต่งหน้าโน้ตนั้นได้โดยอิสระ

## **ตั้งค่าส่วนหัวและส่วนล่างบนมาสเตอร์แฮนด์เอาต์**

หน้าฮานด์เอาต์ใช้มาสเตอร์แฮนด์เอาต์สำหรับส่วนหัว, ส่วนล่าง, วันที่/เวลา, และตัวเก็บตำแหน่งหมายเลขหน้า ไม่เหมือนหน้าบันทึกย่อ การตั้งค่าแฮนด์เอาต์จะถูกจัดการผ่านมาสเตอร์แฮนด์เอาต์แทนสไลด์แฮนด์เอาต์แต่ละหน้า

ใช้สมบัติ [`MasterHandoutSlide`](https://reference.aspose.com/slides/th/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) เพื่อเข้าถึงมาสเตอร์แฮนด์เอาต์ หากไม่มี ให้เรียกเมธอด [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/th/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) เพื่อสร้างมาสเตอร์แฮนด์เอาต์ค่าเริ่มต้น

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **ทำความเข้าใจขอบเขตและการสืบทอด**

เลือกตัวจัดการส่วนหัว/ส่วนล่างที่ตรงกับขอบเขตที่คุณต้องการเปลี่ยนแปลง:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/th/net/aspose.slides/islideheaderfootermanager/) เปลี่ยนการตั้งค่าส่วนล่าง, วันที่/เวลา, และหมายเลขสไลด์สำหรับสไลด์ปกติหนึ่งสไลด์
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslideheaderfootermanager/) ควบคุมสไลด์เลเอาต์และสามารถกระจายการตั้งค่าที่สนับสนุนไปยังสไลด์ที่ขึ้นกับ
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslideheaderfootermanager/) ควบคุมมาสเตอร์สไลด์ปกติและสามารถกระจายการตั้งค่าที่สนับสนุนไปยังสไลด์ที่ขึ้นกับ
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/net/aspose.slides/imasternotesslideheaderfootermanager/) ควบคุมโน้ตมาสเตอร์และสามารถกระจายการตั้งค่าไปยังสไลด์โน้ตที่ขึ้นกับทั้งหมด
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/net/aspose.slides/inotesslideheaderfootermanager/) เปลี่ยนสไลด์โน้ตหนึ่งสไลด์และสนับสนุนตัวเก็บตำแหน่งส่วนหัวนอกจากส่วนล่าง, วันที่/เวลา, และหมายเลขสไลด์
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/net/aspose.slides/imasterhandoutslideheaderfootermanager/) เปลี่ยนมาสเตอร์แฮนด์เอาต์และสนับสนุนตัวเก็บตำแหน่งสี่ประเภททั้งหมด

ใช้การกระจายจากมาสเตอร์หรือเลเอาต์เมื่อการตั้งค่าเดียวกันควรใช้ทั่วทั้งลำดับชั้น ใช้ตัวจัดการสไลด์หรือสไลด์โน้ตเดี่ยวเมื่อคุณต้องการการตั้งค่าท้องถิ่นสำหรับหน้าเดียว

## **คำถามที่พบบ่อย**

**ฉันสามารถเพิ่มส่วนหัวให้กับสไลด์ปกติได้หรือไม่?**

ไม่ได้ PowerPoint ไม่ได้กำหนดตัวเก็บตำแหน่งส่วนหัวสำหรับสไลด์ปกติ บนสไลด์ปกติให้ใช้ส่วนล่าง, วันที่/เวลา, และส่วนเก็บหมายเลขสไลด์ ตัวเก็บตำแหน่งส่วนหัวมีให้เฉพาะบนหน้าบันทึกย่อและแฮนด์เอาต์

**ถ้าตัวเก็บตำแหน่งส่วนล่าง, วันที่/เวลา, หรือหมายเลขสไลด์ไม่แสดงผลต้องทำอย่างไร?**

ใช้ตัวจัดการส่วนหัว/ส่วนล่างที่สอดคล้องกันเพื่อตรวจสอบการมองเห็นและเปิดใช้งานเมื่อจำเป็น ตัวอย่างเช่นเมธอด [`IsFooterVisible`](https://reference.aspose.com/slides/th/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) รายงานว่ามีตัวเก็บตำแหน่งส่วนล่างหรือไม่ และเมธอด [`SetFooterVisibility`](https://reference.aspose.com/slides/th/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) จะเปลี่ยนการมองเห็นของมัน

**ฉันจะเริ่มต้นลำดับหมายเลขสไลด์จากค่าที่ไม่ใช่ 1 อย่างไร?**

ตั้งสมบัติ [`FirstSlideNumber`](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/firstslidenumber/) ของพรีเซนเทชัน ตัวเก็บตำแหน่งหมายเลขสไลด์จะใช้ลำดับตัวเลขที่อัปเดตแล้ว

**ส่วนหัวและส่วนล่างจะเกิดอะไรขึ้นเมื่อส่งออกเป็น PDF, ภาพ, หรือ HTML?**

องค์ประกอบส่วนหัวและส่วนล่างที่มองเห็นได้จะถูกเรนเดอร์พร้อมกับเนื้อหาอื่นของพรีเซนเทชันในรูปแบบผลลัพธ์ การแสดงผลขึ้นอยู่กับประเภทของหน้าที่กำลังส่งออกและการตั้งค่าการมองเห็นของตัวเก็บตำแหน่งที่สอดคล้องกัน