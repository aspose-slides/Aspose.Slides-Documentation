---
title: จัดการส่วนหัวและส่วนท้ายของการนำเสนอใน C++
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
- บันทึกย่อ
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีจัดการส่วนท้าย, วันที่-เวลา, หมายเลขสไลด์, และตารางส่วนหัวบนสไลด์, หน้าโน้ต, และเอกสารแจกด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

PowerPoint ใช้ตารางหัวกระทูและส่วนท้ายต่างกันตามประเภทของหน้า Aspose.Slides for C++ ให้คุณควบคุมข้อความและการมองเห็นของตารางเหล่านี้ผ่านอินเทอร์เฟซตัวจัดการส่วนหัว/ส่วนท้าย

ตารางที่ใช้ได้ขึ้นอยู่กับขอบเขต:

| ขอบเขต | ส่วนหัว | ส่วนท้าย | วันที่/เวลา | หมายเลขสไลด์/หน้า |
|---|---|---|---|---|
| สไลด์ปกติ | ไม่ | มี | มี | มี |
| มาสเตอร์บันทึกย่อ | มี | มี | มี | มี |
| สไลด์บันทึกย่อ | มี | มี | มี | มี |
| มาสเตอร์แจกมือ | มี | มี | มี | มี |

สไลด์การนำเสนอปกติไม่มีตารางส่วนหัว ส่วนหัวจะมีบนหน้าบันทึกย่อและแจกมือ สำหรับสไลด์ปกติใช้ตารางส่วนท้าย วันที่/เวลา และหมายเลขสไลด์แทน

ขอบเขตของการเปลี่ยนแปลงขึ้นอยู่กับตัวจัดการที่คุณใช้ อินเทอร์เฟซ [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideheaderfootermanager/) ควบคุมสไลด์ปกติหนึ่งสไลด์ อินเทอร์เฟซ [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/cpp/aspose.slides/inotesslideheaderfootermanager/) ควบคุมสไลด์บันทึกย่อหนึ่งสไลด์ ตัวจัดการมาสเตอร์และเลย์เอาต์ยังสามารถแพร่ตั้งค่าไปยังสไลด์ที่ขึ้นต่อได้ ในขณะที่อินเทอร์เฟซ [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) ควบคุมมาสเตอร์แจกมือ

## **ตั้งค่าฝั่งท้าย วันที่/เวลา และหมายเลขสไลด์บนสไลด์ปกติ**

สำหรับสไลด์ปกติ กระบวนการพื้นฐานคือเข้าถึงตัวจัดการส่วนหัว/ส่วนท้ายของแต่ละสไลด์ ตั้งค่าฝั่งท้ายและข้อความวันที่/เวลา เปิดใช้ตารางที่ต้องการ และบันทึกการนำเสนอ หมายเลขสไลด์สร้างโดยการนำเสนอ ดังนั้นคุณเพียงแค่ควบคุมการมองเห็นของมัน

ใช้ [`SetFooterText`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) และ [`SetDateTimeText`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) เพื่อตั้งข้อความ และใช้ [`SetFooterVisibility`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/), และ [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) เพื่อแสดงตารางที่สอดคล้องกัน

ตัวอย่างต่อไปนี้เป็นตัวอย่างแบบครบวงจรที่ใช้ฝั่งท้ายเดียวกัน ข้อความวันที่/เวลา และการมองเห็นหมายเลขสไลด์บนสไลด์ปกติทั้งหมด:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

หากต้องการอัปเดตเพียงสไลด์เดียว ให้เข้าถึงสไลด์นั้นโดยตรงผ่าน [`Presentation::get_Slide`](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_slide/) แทนการวนลูปในคอลเลกชันสไลด์ทั้งหมด

## **ตั้งค่าส่วนหัวและส่วนท้ายบนมาสเตอร์บันทึกย่อ**

มาสเตอร์บันทึกย่อกำหนดรูปแบบทั่วไปและพฤติกรรมของตารางสำหรับหน้าบันทึกย่อ ใช้อินเทอร์เฟซ [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasternotesslideheaderfootermanager/) เมื่อคุณต้องการเปลี่ยนแปลงเพียงมาสเตอร์บันทึกย่อเท่านั้น

ตัวอย่างต่อไปนี้ตั้งค่าส่วนหัว ส่วนท้าย และข้อความวันที่/เวลาบนมาสเตอร์บันทึกย่อและทำให้ตารางที่สนับสนุนทั้งหมดมองเห็นได้บนมาสเตอร์นั้น:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

เมธอด [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) คืนค่า `nullptr` เมื่อการนำเสนอไม่มีมาสเตอร์บันทึกย่อ

## **ใช้การตั้งค่ามาสเตอร์บันทึกย่อกับสไลด์บันทึกย่อย่อย**

มาสเตอร์บันทึกย่อสามารถนำการตั้งค่าส่วนหัวและส่วนท้ายไปใช้กับตัวเองและสไลด์บันทึกย่อที่ขึ้นต่อได้ ใช้วิธีการแพร่การตั้งค่าที่มีบน [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasternotesslideheaderfootermanager/) เมื่อการตั้งค่าเดียวกันต้องการถูกนำไปใช้ทั่วทั้งโครงสร้างบันทึกย่อ

เช่น เมธอด [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) และ [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) จะอัปเดตส่วนหัวของมาสเตอร์บันทึกย่อและส่วนหัวของสไลด์ย่อยทั้งหมด วิธีการที่เทียบเท่ามีสำหรับส่วนท้าย วันที่/เวลา และหมายเลขสไลด์

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

วิธีการแพร่ที่ใช้ด้านบนได้แก่ [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), และ [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)

## **ตั้งค่าส่วนหัวและส่วนท้ายบนสไลด์บันทึกย่อเดี่ยว**

สไลด์บันทึกย่อเป็นของสไลด์ปกติเฉพาะ ใช้อินเทอร์เฟซ [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/cpp/aspose.slides/inotesslideheaderfootermanager/) เมื่อคุณต้องการปรับแต่งหน้าโน้ตนั้นเท่านั้น

เมธอด [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/th/cpp/aspose.slides/inotesslidemanager/addnotesslide/) คืนค่าสไลด์บันทึกย่อสำหรับสไลด์ปัจจุบันและสร้างใหม่หากยังไม่มี ตัวอย่างต่อไปนี้กำหนดค่าหน้าบันทึกย่อที่เชื่อมโยงกับสไลด์แรกของการนำเสนอ:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

หากคุณเริ่มต้นโดยการแพร่การตั้งค่าจากมาสเตอร์บันทึกย่อแล้วค่อยเปลี่ยนสไลด์บันทึกย่อเดี่ยว การตั้งค่าตามสไลด์ที่ทำในภายหลังจะทำให้คุณสามารถปรับแต่งหน้าบันทึกย่อดังกล่าวโดยอิสระ

## **ตั้งค่าส่วนหัวและส่วนท้ายบนมาสเตอร์แจกมือ**

หน้าจัดแจกมือใช้มาสเตอร์แจกมือสำหรับตารางส่วนหัว ส่วนท้าย วันที่/เวลา และหมายเลขหน้า แตกต่างจากบันทึกย่อ การตั้งค่าจัดแจกมือจัดการผ่านมาสเตอร์แจกมือแทนสไลด์แจกมือแต่ละหน้า

ใช้ [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) เพื่อเข้าถึงมาสเตอร์แจกมือ หากไม่มีให้เรียก [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) เพื่อสร้างมาสเตอร์แจกมือเริ่มต้น

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **ทำความเข้าใจขอบเขตและการสืบทอด**

เลือกตัวจัดการส่วนหัว/ส่วนท้ายที่ตรงกับขอบเขตที่คุณต้องการเปลี่ยนแปลง:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/th/cpp/aspose.slides/islideheaderfootermanager/) เปลี่ยนการตั้งค่าฝั่งท้าย วันที่/เวลา และหมายเลขสไลด์สำหรับสไลด์ปกติหนึ่งสไลด์
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslideheaderfootermanager/) ควบคุมสไลด์เลย์เอาต์และสามารถแพร่การตั้งค่าที่สนับสนุนไปยังสไลด์ที่ขึ้นต่อ
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslideheaderfootermanager/) ควบคุมมาสเตอร์สไลด์ปกติและสามารถแพร่การตั้งค่าที่สนับสนุนไปยังสไลด์ที่ขึ้นต่อ
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasternotesslideheaderfootermanager/) ควบคุมมาสเตอร์บันทึกย่อและสามารถแพร่การตั้งค่าไปยังสไลด์บันทึกย่อที่ขึ้นต่อทั้งหมด
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/cpp/aspose.slides/inotesslideheaderfootermanager/) เปลี่ยนสไลด์บันทึกย่อหนึ่งสไลด์และสนับสนุนตารางส่วนหัวเพิ่มเติมจากส่วนท้าย วันที่/เวลา และหมายเลขสไลด์
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) เปลี่ยนมาสเตอร์แจกมือและสนับสนุนตารางทั้งสี่ประเภท

ใช้การแพร่จากมาสเตอร์หรือเลย์เอาต์เมื่อการตั้งค่าเดียวกันต้องการใช้ทั่วทั้งลำดับชั้น ใช้ตัวจัดการสไลด์เดี่ยวหรือสไลด์บันทึกย่อเมื่อคุณต้องการการตั้งค่าท้องถิ่นสำหรับหน้าเดียว

## **FAQ**

**ฉันสามารถเพิ่มส่วนหัวให้สไลด์ปกติได้หรือไม่?**

ไม่ได้ PowerPoint ไม่ได้กำหนดตารางส่วนหัวสำหรับสไลด์ปกติ บนสไลด์ปกติให้ใช้ตารางส่วนท้าย วันที่/เวลา และหมายเลขสไลด์ ตารางส่วนหัวมีให้ใช้บนหน้าบันทึกย่อและแจกมือ

**ถ้าตารางส่วนท้าย วันที่/เวลา หรือหมายเลขสไลด์ไม่มองเห็นจะทำอย่างไร?**

ใช้ตัวจัดการส่วนหัว/ส่วนท้ายที่สอดคล้องกันเพื่อตรวจสอบการมองเห็นและเปิดใช้เมื่อจำเป็น ตัวอย่างเช่น เมธอด [`get_IsFooterVisible`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) รายงานว่าตารางส่วนท้ายมีอยู่หรือไม่ และเมธอด [`SetFooterVisibility`](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) เปลี่ยนการมองเห็นของมัน

**ฉันจะเริ่มนับหมายเลขสไลด์จากค่าอื่นที่ไม่ใช่ 1 ได้อย่างไร?**

ใช้เมธอด [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/set_firstslidenumber/) เพื่อกำหนดหมายเลขสไลด์แรก หลังจากนั้นตารางหมายเลขสไลด์จะใช้ลำดับหมายเลขที่อัปเดต

**ส่วนหัวและส่วนท้ายจะเกิดอะไรขึ้นเมื่อส่งออกเป็น PDF ภาพหรือ HTML?**

องค์ประกอบส่วนหัวและส่วนท้ายที่มองเห็นได้จะถูกรันเดอร์พร้อมกับเนื้อหาอื่นของการนำเสนอในรูปแบบผลลัพธ์ การแสดงผลขึ้นอยู่กับประเภทหน้าที่กำลังส่งออกและการตั้งค่าการมองเห็นของตารางที่สอดคล้องกัน