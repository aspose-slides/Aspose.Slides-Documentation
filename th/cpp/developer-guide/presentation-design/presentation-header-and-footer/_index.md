---
title: จัดการส่วนหัวและส่วนท้ายของงานนำเสนอใน C++
linktitle: ส่วนหัวและส่วนท้าย
type: docs
weight: 140
url: /th/cpp/presentation-header-and-footer/
keywords:
- ส่วนหัว
- ข้อความส่วนหัว
- ส่วนท้าย
- ข้อความส่วนท้าย
- ตั้งค่าส่วนหัว
- ตั้งค่าส่วนท้าย
- เอกสารแจก
- หมายเหตุ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ใช้ Aspose.Slides สำหรับ C++ เพื่อเพิ่มและปรับแต่งส่วนหัวและส่วนท้ายในงานนำเสนอ PowerPoint และ OpenDocument ให้ดูเป็นมืออาชีพ"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณจัดการการตั้งค่าส่วนหัวและส่วนท้ายในงานนำเสนอ PowerPoint ได้ ส่วนหัวและส่วนท้ายถูกจัดการระดับ master ของงานนำเสนอ และ API มีเมธอดสำหรับตั้งค่าข้อความส่วนท้าย, การเปลี่ยนการมองเห็นของส่วนท้าย, และการอัปเดตข้อความส่วนหัวบนสไลด์ master notes

คุณยังสามารถจัดการส่วนหัวและส่วนท้ายสำหรับสไลด์ handout และ notes ได้ ซึ่งรวมถึงการเปลี่ยนการมองเห็นและข้อความของส่วนหัว, ส่วนท้าย, ตัวเลขสไลด์, และตัว占位符วัน-เวลา สำหรับ notes master, สไลด์ notes ทั้งหมดที่เป็น child, หรือสไลด์ notes เฉพาะรายการเดียว

## **จัดการข้อความส่วนหัวและส่วนท้าย**

บันทึกของสไลด์เฉพาะบางสไลด์สามารถอัปเดตได้ตามตัวอย่างด้านล่าง:

``` cpp
// ฟังก์ชันเพื่อกำหนดข้อความส่วนหัว/ส่วนท้าย
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// โหลดงานนำเสนอ
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// ตั้งค่าส่วนท้าย
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// เข้าถึงและอัปเดตส่วนหัว
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// บันทึกงานนำเสนอ
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **จัดการส่วนหัวและส่วนท้ายในสไลด์ Handout และ Notes**
Aspose.Slides สำหรับ C++ รองรับส่วนหัวและส่วนท้ายในสไลด์ Handout และ notes โปรดทำตามขั้นตอนต่อไปนี้:

- โหลด [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) ที่มีวิดีโอ
- เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับ notes master และสไลด์ notes ทั้งหมด
- ตั้งค่าให้ placeholder ส่วนท้ายของ master notes slide และ child ทั้งหมดมองเห็นได้
- ตั้งค่าให้ placeholder วันและเวลา ของ master notes slide และ child ทั้งหมดมองเห็นได้
- เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับสไลด์ notes แรกเท่านั้น
- ตั้งค่าให้ placeholder ส่วนหัวของสไลด์ notes มองเห็นได้
- ตั้งค่าข้อความให้กับ placeholder ส่วนหัวของสไลด์ notes
- ตั้งค่าข้อความให้กับ placeholder วัน-เวลา ของสไลด์ notes
- เขียนไฟล์งานนำเสนอที่แก้ไขแล้ว

ตัวอย่างโค้ดที่ให้ไว้ด้านล่าง

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับ notes master และสไลด์ notes ทั้งหมด
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    // ทำให้ master notes slide และ placeholder Footer ของลูกทั้งหมดมองเห็นได้
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
    // ทำให้ master notes slide และ placeholder Header ของลูกทั้งหมดมองเห็นได้
    headerFooterManager->SetFooterAndChildFootersVisibility(true);
    // ทำให้ master notes slide และ placeholder SlideNumber ของลูกทั้งหมดมองเห็นได้
    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
    // ทำให้ master notes slide และ placeholder Date and time ของลูกทั้งหมดมองเห็นได้
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    // ตั้งข้อความให้ master notes slide และ placeholder Header ของลูกทั้งหมด
    headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
    // ตั้งข้อความให้ master notes slide และ placeholder Footer ของลูกทั้งหมด
    headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
    // ตั้งข้อความให้ master notes slide และ placeholder Date and time ของลูกทั้งหมด
    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// เปลี่ยนการตั้งค่าส่วนหัวและส่วนท้ายสำหรับสไลด์ notes แรกเท่านั้น
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
    auto headerFooterManager = notesSlide->get_HeaderFooterManager();
    if (!headerFooterManager->get_IsHeaderVisible())
    {
        // ทำให้ placeholder Header ของสไลด์ notes นี้มองเห็นได้
        headerFooterManager->SetHeaderVisibility(true);
    }

    if (!headerFooterManager->get_IsFooterVisible())
    {
        // ทำให้ placeholder Footer ของสไลด์ notes นี้มองเห็นได้
        headerFooterManager->SetFooterVisibility(true);
    }

    if (!headerFooterManager->get_IsSlideNumberVisible())
    {
        // ทำให้ placeholder SlideNumber ของสไลด์ notes นี้มองเห็นได้
        headerFooterManager->SetSlideNumberVisibility(true);
    }
    
    if (!headerFooterManager->get_IsDateTimeVisible())
    {
        // ทำให้ placeholder Date-time ของสไลด์ notes นี้มองเห็นได้
        headerFooterManager->SetDateTimeVisibility(true);
    }
    
    // ตั้งข้อความให้ placeholder Header ของสไลด์ notes
    headerFooterManager->SetHeaderText(u"New header text");
    // ตั้งข้อความให้ placeholder Footer ของสไลด์ notes
    headerFooterManager->SetFooterText(u"New footer text");
    // ตั้งข้อความให้ placeholder Date-time ของสไลด์ notes
    headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**Can I add a "header" to regular slides?**

ใน PowerPoint, “Header” มีอยู่เฉพาะสำหรับ notes และ handouts; บนสไลด์ปกติ, สิ่งที่สนับสนุนคือส่วนท้าย, วันที่/เวลา, และหมายเลขสไลด์. ใน Aspose.Slides ข้อจำกัดนี้เหมือนกัน: header มีเฉพาะสำหรับ Notes/Handout, ส่วนบนสไลด์มี Footer/DateTime/SlideNumber

**What if the layout doesn’t contain a footer area—can I "turn on" its visibility?**

ได้. ตรวจสอบการมองเห็นผ่านผู้จัดการส่วนหัว/ส่วนท้ายและเปิดใช้งานหากจำเป็น. ตัวชี้และเมธอดของ API นี้ออกแบบมาเพื่อกรณีที่ placeholder ขาดหายหรือถูกซ่อน

**How do I make the slide number start from a value other than 1?**

ตั้งค่า [first slide number](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/set_firstslidenumber/) ของงานนำเสนอ; หลังจากนั้นหมายเลขทั้งหมดจะถูกคำนวณใหม่. ตัวอย่างเช่น เริ่มที่ 0 หรือ 10, และซ่อนหมายเลขบนสไลด์หัวเรื่อง

**What happens to headers/footers when exporting to PDF/images/HTML?**

พวกมันจะถูกเรนเดอร์เป็นองค์ประกอบข้อความปกติของงานนำเสนอ. นั่นหมายความว่าถ้าองค์ประกอบมองเห็นได้บนสไลด์/หน้า notes, พวกมันจะปรากฏในรูปแบบผลลัพธ์พร้อมกับเนื้อหาอื่น ๆ.