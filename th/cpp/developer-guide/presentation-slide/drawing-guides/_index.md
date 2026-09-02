---
title: จัดการแนวทางการวาดในงานนำเสนอด้วย C++
linktitle: แนวทางการวาด
type: docs
weight: 85
url: /th/cpp/drawing-guides/
keywords:
- แนวทางการวาด
- แนวทางแนวนอน
- แนวทางแนวดิ่ง
- แนวทางจัดตำแหน่ง
- มุมมองสไลด์
- มาสเตอร์สไลด์
- สไลด์เลย์เอาต์
- มาสเตอร์โน้ต
- มาสเตอร์แฮนด์เอาท์
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เพิ่ม เข้าถึง และลบแนวทางการวาดแนวนอนและแนวดิ่งในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

แนวทางการวาดเป็นเส้นแนวนอนและแนวตั้งที่ปรับได้ ซึ่งช่วยให้ผู้ใช้จัดตำแหน่งรูปร่างอย่างสม่ำเสมอขณะแก้ไขงานนำเสนอใน PowerPoint. โดยเฉพาะอย่างยิ่งเมื่อแอปพลิเคชันสร้างงานนำเสนอและจะถูกปรับแต่งด้วยมือต่อไป: แอปพลิเคชันสามารถบันทึกเครื่องมือจัดตำแหน่งเดียวกันที่ผู้เขียนควรปฏิบัติตามเมื่อเพิ่มหรือย้ายเนื้อหา.

แนวทางการวาดเป็นเครื่องมือช่วยแก้ไข ไม่ใช่เนื้อหาของสไลด์. มันจะไม่ปรากฏในการนำเสนอหรือผลลัพธ์ที่เรนเดอร์. Aspose.Slides for C++ เปิดเผยพวกมันผ่านอินเทอร์เฟซ [IDrawingGuidesCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/idrawingguidescollection/) . แนวทางหนึ่งแทนด้วย [IDrawingGuide](https://reference.aspose.com/slides/th/cpp/aspose.slides/idrawingguide/) และมีการกำหนดทิศทาง, ตำแหน่ง, และสี.

ตำแหน่งถูกวัดเป็นจุดจากมุมด้านบนซ้ายของสไลด์หรือมาสเตอร์ที่เกี่ยวข้อง. แนวตั้งใช้พิกัดแนวนอน, ปกติอยู่ระหว่างศูนย์ถึงความกว้างของสไลด์. แนวนอนใช้พิกัดแนวตั้ง, ปกติอยู่ระหว่างศูนย์ถึงความสูงของสไลด์.

## **เพิ่มแนวทางการวาดในมุมมองสไลด์**

ใช้ [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/th/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) เพื่อจัดการแนวทางที่แสดงขณะแก้ไขสไลด์ปกติ. เรียก [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/th/cpp/aspose.slides/idrawingguidescollection/add/) พร้อมค่าของ [Orientation](https://reference.aspose.com/slides/th/cpp/aspose.slides/orientation/) และตำแหน่งเป็นจุด.

ตัวอย่างต่อไปนี้เพิ่มแนวตั้งหนึ่งเส้นทางด้านขวากลางสไลด์และแนวนอนหนึ่งเส้นทางด้านล่างของมัน:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เข้าถึงแนวทางการวาด**

เมธอด [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/th/cpp/aspose.slides/idrawingguidescollection/get_count/) และเมธอด [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/th/cpp/aspose.slides/idrawingguidescollection/idx_get/) ให้การเข้าถึงแนวทางที่มีอยู่. เมธอด [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/th/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/th/cpp/aspose.slides/idrawingguide/get_position/), และ [IDrawingGuide::get_Color](https://reference.aspose.com/slides/th/cpp/aspose.slides/idrawingguide/get_color/) คืนค่าคุณสมบัติปัจจุบันของแนวทาง. เมธอด setter ที่สอดคล้องสามารถเปลี่ยนแปลงคุณสมบัติเหล่านั้นได้.

ตัวอย่างต่อไปนี้อ่านแนวทางของมุมมองสไลด์จากงานนำเสนอที่สร้างข้างต้น:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **เพิ่มแนวทางการวาดในมาสเตอร์และสไลด์เลย์เอาต์**

มาสเตอร์สไลด์และสไลด์เลย์เอาต์แต่ละอันสามารถมีคอลเลกชันแนวทางการวาดของตนเอง. ใช้ [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterslide/get_drawingguides/) สำหรับมาสเตอร์สไลด์และ [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/get_drawingguides/) สำหรับสไลด์เลย์เอาต์.

ตัวอย่างต่อไปนี้เพิ่มแนวตั้งหนึ่งเส้นในมาสเตอร์สไลด์แรกและแนวนอนหนึ่งเส้นในสไลด์เลย์เอาต์แรก:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เพิ่มแนวทางการวาดในมาสเตอร์โน้ตและแฮนด์เอาท์**

มาสเตอร์โน้ตและมาสเตอร์แฮนด์เอาท์ก็รองรับแนวทางการวาดเช่นกัน. ใช้ [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasternotesslide/get_drawingguides/) และ [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) เพื่อเข้าถึงคอลเลกชันของพวกมัน. หากงานนำเสนอไม่มีมาสเตอร์ใดมาสเตอร์เหล่านี้, [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) หรือ [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) จะสร้างมาสเตอร์เริ่มต้นและคืนค่าให้.

ตัวอย่างต่อไปนี้เพิ่มแนวนอนหนึ่งเส้นในมาสเตอร์โน้ตและแนวตั้งหนึ่งเส้นในมาสเตอร์แฮนด์เอาท์:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ลบแนวทางการวาด**

เรียก [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides/idrawingguidescollection/clear/) เพื่อลบแนวทางทุกเส้นจากคอลเลกชันที่ระบุ. การลบคอลเลกชันหนึ่งจะไม่ส่งผลต่อแนวทางที่จัดเก็บในขอบเขตอื่น.

ตัวอย่างต่อไปนี้ลบแนวทางของมุมมองสไลด์และแนวทางทั้งหมดบนมาสเตอร์สไลด์, สไลด์เลย์เอาต์, มาสเตอร์โน้ต, และมาสเตอร์แฮนด์เอาท์โดยไม่สร้างมาสเตอร์ที่ขาดหายไป:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**แนวทางการวาดปรากฏในการนำเสนอหรือภาพที่ส่งออกหรือไม่?**

ไม่มี. แนวทางการวาดเป็นเครื่องมือช่วยจัดตำแหน่งสำหรับการแก้ไขและไม่ได้แสดงเป็นเนื้อหาของงานนำเสนอ.

**สามารถเพิ่มแนวทางการวาดโดยตรงไปยังสไลด์ปกติแต่ละสไลด์ได้หรือไม่?**

แนวทางการแก้ไขสไลด์ปกติจะถูกเก็บในคุณสมบัติของมุมมองสไลด์ของงานนำเสนอ. มีคอลเลกชันแนวทางแยกต่างหากสำหรับมาสเตอร์สไลด์, สไลด์เลย์เอาต์, มาสเตอร์โน้ต, และมาสเตอร์แฮนด์เอาท์.

**หน่วยใดถูกใช้สำหรับตำแหน่งของแนวทางการวาด?**

ตำแหน่งระบุเป็นจุด, โดย 72 จุดเท่ากับหนึ่งนิ้ว. ตำแหน่งแนวตั้งวัดจากด้านซ้าย, และตำแหน่งแนวนอนวัดจากด้านบน.

**การลบแนวทางการวาดทำให้รูปทรงหรือเนื้อหาสไลด์เปลี่ยนแปลงหรือไม่?**

ไม่มี. เมธอด `Clear` จะลบเฉพาะแนวทางในคอลเลกชันที่เลือก. รูปร่างและเนื้อหาอื่นของสไลด์คงที่โดยไม่เปลี่ยนแปลง.