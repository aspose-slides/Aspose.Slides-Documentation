---
title: จัดการส่วนหัวและส่วนท้ายของงานนำเสนอใน .NET
linktitle: ส่วนหัวและส่วนท้าย
type: docs
weight: 140
url: /th/net/presentation-header-and-footer/
keywords:
- ส่วนหัว
- ข้อความส่วนหัว
- ส่วนท้าย
- ข้อความส่วนท้าย
- ตั้งค่าส่วนหัว
- ตั้งค่าส่วนท้าย
- เอกสารแจก
- โน้ต
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ใช้ Aspose.Slides สำหรับ .NET เพื่อเพิ่มและปรับแต่งส่วนหัวและส่วนท้ายในงานนำเสนอ PowerPoint และ OpenDocument เพื่อให้ดูเป็นมืออาชีพ."
---
## **ภาพรวม**

Aspose.Slides ให้คุณจัดการการตั้งค่าส่วนหัวและส่วนท้ายในงานนำเสนอ PowerPoint ได้ ส่วนหัวและส่วนท้ายจะถูกจัดการระดับมาสเตอร์ของงานนำเสนอ และ API มีเมธอดสำหรับตั้งค่าข้อความส่วนท้าย การเปลี่ยนการมองเห็นส่วนท้าย และการอัปเดตข้อความส่วนหัวบนสไลด์โน้ตมาสเตอร์

คุณยังสามารถจัดการส่วนหัวและส่วนท้ายสำหรับสไลด์ Handout และสไลด์โน้ตได้ ซึ่งรวมถึงการเปลี่ยนการมองเห็นและข้อความของตัวแทนส่วนหัว, ส่วนท้าย, หมายเลขสไลด์, และตัวแทนวันที่‑เวลา สำหรับโน้ตมาสเตอร์, สไลด์โน้ตทั้งหมดที่เป็นลูก, หรือสไลด์โน้ตแต่ละอัน

## **จัดการข้อความส่วนหัวและส่วนท้าย**

บันทึกของสไลด์ที่ระบุบางสไลด์สามารถอัปเดตได้ตามตัวอย่างด้านล่าง:

```c#
 // โหลดงานนำเสนอ
 Presentation pres = new Presentation("headerTest.pptx");

// ตั้งค่าส่วนท้าย
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// เข้าถึงและอัปเดตส่วนหัว
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
    UpdateHeaderFooterText(masterNotesSlide);
}

// บันทึกงานนำเสนอ
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
 // วิธีตั้งค่าข้อความส่วนหัว/ส่วนท้าย
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```




## **จัดการส่วนหัวและส่วนท้ายบนสไลด์ Handout และ Notes Slides**
Aspose.Slides for .NET รองรับส่วนหัวและส่วนท้ายในสไลด์ Handoutและโน้ต กรุณาทำตามขั้นตอนด้านล่าง:

- โหลด [Presentation ](https://reference.aspose.com/slides/th/net/aspose.slides/presentation)ที่มีวิดีโอ
- เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับโน้ตมาสเตอร์และสไลด์โน้ตทั้งหมด
- ตั้งค่าตัวแทนส่วนท้ายของสไลด์โน้ตมาสเตอร์และลูกทั้งหมดให้มองเห็นได้
- ตั้งค่าตัวแทนวันที่และเวลาในสไลด์โน้ตมาสเตอร์และลูกทั้งหมดให้มองเห็นได้
- เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับสไลด์โน้ตแรกเท่านั้น
- ตั้งค่าตัวแทนส่วนหัวของสไลด์โน้ตให้มองเห็นได้
- กำหนดข้อความให้กับตัวแทนส่วนหัวของสไลด์โน้ต
- กำหนดข้อความให้กับตัวแทนวันที่‑เวลาในสไลด์โน้ต
- เขียนไฟล์งานนำเสนอที่แก้ไขแล้ว

โค้ดสแนปที่ให้ในตัวอย่างด้านล่าง

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับโน้ตมาสเตอร์และสไลด์โน้ตทั้งหมด
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // ทำให้สไลด์โน้ตมาสเตอร์และตัวแทน Footer ลูกทั้งหมดมองเห็นได้
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // ทำให้สไลด์โน้ตมาสเตอร์และตัวแทน Header ลูกทั้งหมดมองเห็นได้
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // ทำให้สไลด์โน้ตมาสเตอร์และตัวแทน SlideNumber ลูกทั้งหมดมองเห็นได้
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // ทำให้สไลด์โน้ตมาสเตอร์และตัวแทน Date and time ลูกทั้งหมดมองเห็นได้

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // ตั้งค่าข้อความให้สไลด์โน้ตมาสเตอร์และตัวแทน Header ลูกทั้งหมด
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // ตั้งค่าข้อความให้สไลด์โน้ตมาสเตอร์และตัวแทน Footer ลูกทั้งหมด
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // ตั้งค่าข้อความให้สไลด์โน้ตมาสเตอร์และตัวแทน Date and time ลูกทั้งหมด
	}

	// เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับสไลด์โน้ตแรกเท่านั้น
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // ทำให้ตัวแทน Header ของสไลด์โน้ตนี้มองเห็นได้

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // ทำให้ตัวแทน Footer ของสไลด์โน้ตนี้มองเห็นได้

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // ทำให้ตัวแทน SlideNumber ของสไลด์โน้ตนี้มองเห็นได้

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // ทำให้ตัวแทน Date-time ของสไลด์โน้ตนี้มองเห็นได้

		headerFooterManager.SetHeaderText("New header text"); // ตั้งค่าข้อความให้ตัวแทน Header ของสไลด์โน้ต
		headerFooterManager.SetFooterText("New footer text"); // ตั้งค่าข้อความให้ตัวแทน Footer ของสไลด์โน้ต
		headerFooterManager.SetDateTimeText("New date and time text"); // ตั้งค่าข้อความให้ตัวแทน Date-time ของสไลด์โน้ต
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเพิ่ม “ส่วนหัว” ในสไลด์ทั่วไปได้หรือไม่?**

ใน PowerPoint “ส่วนหัว” มีเฉพาะสำหรับโน้ตและ Handout เท่านั้น; ในสไลด์ทั่วไปส่วนที่สนับสนุนจะมีเพียงส่วนท้าย, วันที่/เวลา, และหมายเลขสไลด์. ใน Aspose.Slides ข้อจำกัดนี้เหมือนกัน: ส่วนหัวมีเฉพาะสำหรับ Notes/Handout, และในสไลด์จะมี Footer/DateTime/SlideNumber

**ถ้าเลย์เอาต์ไม่มีพื้นที่ส่วนท้าย—ฉันสามารถ “เปิด” ให้มองเห็นได้หรือไม่?**

ได้. ตรวจสอบการมองเห็นผ่านตัวจัดการส่วนหัว/ส่วนท้ายและเปิดใช้งานหากจำเป็น. ตัวบ่งชี้และเมธอดของ API นี้ออกแบบมาสำหรับกรณีที่ตัวแทนไม่มีหรือถูกซ่อน

**ฉันจะทำให้หมายเลขสไลด์เริ่มจากค่าที่ไม่ใช่ 1 ได้อย่างไร?**

ตั้งค่า [first slide number](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/firstslidenumber/) ของงานนำเสนอ; หลังจากนั้นการนับทั้งหมดจะถูกคำนวณใหม่. ตัวอย่างเช่น คุณสามารถเริ่มที่ 0 หรือ 10 และซ่อนหมายเลขบนสไลด์หัวเรื่อง

**ส่วนหัว/ส่วนท้ายจะเกิดอะไรขึ้นเมื่อส่งออกเป็น PDF/รูปภาพ/HTML?**

พวกมันจะถูกเรนเดอร์เป็นองค์ประกอบข้อความปกติของงานนำเสนอ. ดังนั้น หากองค์ประกอบเหล่านั้นมองเห็นได้บนสไลด์/หน้าโน้ต, พวกมันก็จะปรากฏในรูปแบบผลลัพธ์พร้อมกับเนื้อหาอื่น ๆ