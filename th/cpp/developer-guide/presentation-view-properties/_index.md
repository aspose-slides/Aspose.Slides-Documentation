---
title: ดึงและอัปเดตคุณสมบัติมุมมองการนำเสนอใน C++
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/cpp/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- สแนปบาร์แบ่งแนวตั้ง
- มุมมองเดียว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- ซูมเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides สำหรับ C++ เพื่อกำหนดรูปแบบ PPT, PPTX และสไลด์ ODP - ปรับเลย์เอาต์ ระดับซูม และการตั้งค่าการแสดงผล"
---
## **บทนำ**

มุมมองแบบปกติประกอบด้วยสามบริเวณเนื้อหา: สไลด์เอง, พื้นที่เนื้อหาด้านข้าง, และพื้นที่เนื้อหาด้านล่าง. คุณสมบัติที่เกี่ยวกับตำแหน่งของแต่ละบริเวณเนื้อหา. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงไฟล์ได้, เพื่อให้เมื่อนำกลับมาเปิดใหม่มุมมองจะอยู่ในสถานะเดียวกันกับที่บันทึกครั้งสุดท้ายของการนำเสนอ.

เมธอด[IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) ได้ถูกเพิ่มเพื่อให้เข้าถึงคุณสมบัติมุมมองแบบปกติของการนำเสนอ.

อินเทอร์เฟซ[INormalViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/inormalviewrestoredproperties/) และลูกของมัน, รวมถึง enum[SplitterBarStateType](https://reference.aspose.com/slides/th/cpp/aspose.slides/splitterbarstatetype/) ได้ถูกเพิ่ม.

## **เกี่ยวกับ INormalViewProperties**

เป็นตัวแทนของคุณสมบัติมุมมองแบบปกติ.

Property **ShowOutlineIcons** กำหนดว่าแอปพลิเคชันควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในใดๆ ของบริเวณเนื้อหาในโหมดมุมมองแบบปกติ.

Property **SnapVerticalSplitter** กำหนดว่าบาร์แบ่งแนวตั้งควรสแนปไปสู่สถานะย่อเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอ.

Property **PreferSingleView** กำหนดว่าผู้ใช้ต้องการดูบริเวณเนื้อหาเดียวเต็มหน้าต่างแทนมุมมองแบบปกติที่มีสามบริเวณหรือไม่. หากเปิดใช้งาน, แอปพลิเคชันอาจเลือกแสดงหนึ่งในบริเวณเนื้อหาในหน้าต่างทั้งหมด.

Properties **VerticalBarState** and **HorizontalBarState** กำหนดสถานะที่แถบแบ่งแนวตั้งหรือแนวนอนควรแสดง. แถบแบ่งแนวนอนแยกสไลด์จากพื้นที่เนื้อหาทัดล่าง, แถบแบ่งแนวตั้งแยกสไลด์จากพื้นที่เนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** และ **SplitterBarStateType.Restored**.

Properties **RestoredLeft** and **RestoredTop** กำหนดขนาดของบริเวณสไลด์ด้านบนหรือด้านข้างของมุมมองแบบปกติ, เมื่อค่า **SplitterBarStateType.Restored** ถูกนำไปใช้กับ **VerticalBarState** และ **HorizontalBarState** ตามลำดับ.

## **เกี่ยวกับการคืนค่า INormalViewProperties**

กำหนดขนาดของบริเวณสไลด์ (ความกว้างเมื่อเป็นลูกของ RestoredTop, ความสูงเมื่อเป็นลูกของ RestoredLeft) ของมุมมองแบบปกติ, เมื่อบริเวณอยู่ในขนาดที่คืนค่าได้ (ไม่ย่อและไม่ขยาย).

Property **DimensionSize** กำหนดขนาดของบริเวณสไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

Property **AutoAdjust** กำหนดว่าบริเวณเนื้อหาด้านข้างควรปรับขนาดอัตโนมัติเพื่อชดเชยขนาดใหม่เมื่อเปลี่ยนขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีเข้าถึงคุณสมบัติ **ViewProperties.NormalViewProperties** ของการนำเสนอ.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// กู้คืนคุณสมบัติมุมมองของการนำเสนอ
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าค่าซูมเริ่มต้น**

Aspose.Slides for C++ ตอนนี้รองรับการตั้งค่าค่าซูมเริ่มต้นสำหรับการนำเสนอ เพื่อให้เมื่อเปิดการนำเสนอแล้วซูมจะถูกตั้งค่าไว้แล้ว. สามารถทำได้โดยการตั้งค่า[ViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/)ของการนำเสนอ. คุณสมบัติของมุมมองสไลด์และ[ get_NotesViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/get_notesviewproperties/)สามารถตั้งค่าได้โดยโปรแกรม. ในหัวข้อนี้ เราจะดูตัวอย่างการตั้งค่าคุณสมบัติมุมมองของการนำเสนอใน Aspose.Slides.

เพื่อกำหนดค่าคุณสมบัตุมุมมอง โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
1. ตั้งค่า[Properties](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/)ของการนำเสนอ
1. เขียนการนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ตั้งค่าค่าซูมสำหรับมุมมองสไลด์และมุมมองบันทึกย่อ.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// ตั้งค่าคุณสมบัติมุมมองของการนำเสนอ
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองบันทึกย่อ

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าการเว้นระยะของตาราง**

ใช้[Presentation::get_ViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_viewproperties/)เพื่อเข้าถึงการตั้งค่ามุมมองทั่วทั้งการนำเสนอ. เมธอด[IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/th/cpp/aspose.slides/iviewproperties/get_gridspacing/)และ[IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/th/cpp/aspose.slides/iviewproperties/set_gridspacing/)อ่านหรือเปลี่ยนช่วงของกริดแก้ไขพื้นฐาน. การตั้งค่านี้ใช้กับการนำเสนอทั้งหมด, ไม่ได้ใช้กับสไลด์แต่ละสไลด์. การเว้นระยะของกริดกำหนดเป็นจุด, โดย 72 จุดเท่ากับหนึ่งนิ้ว. ใช้ค่าบวกตามที่เอกสาร API กำหนด.

ตัวอย่างต่อไปนี้เปิด `demo.pptx` ที่มีอยู่, พิมพ์ช่วงกริดปัจจุบัน, ตั้งค่าช่วงเป็นหนึ่งในสี่นิ้ว, แล้วบันทึกผลลัพธ์.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

กริดแตกต่างจาก[drawing guides](/slides/th/cpp/drawing-guides/). การเว้นระยะของกริดควบคุมช่วงที่สม่ำเสมอ, ในขณะที่ drawing guides เป็นเส้นแนวนอนหรือแนวตั้งที่กำหนดตำแหน่งแบบอิสระ. การเพิ่ม, ย้าย หรือ ลบ drawing guides ไม่ทำให้การเว้นระยะของกริดเปลี่ยนแปลง.

ทั้งกริดและ drawing guides เป็นเครื่องมือช่วยแก้ไข. พวกมันจะไม่ถูกเรนเดอร์เป็นเนื้อหาสไลด์ใน PDF, รูปภาพ, SVG หรือการแสดงผลสไลด์โชว์. การจัดเก็บการเว้นระยะของกริดไม่ได้รับประกันว่าโปรแกรมแก้ไขจะแสดงกริด: ความมองเห็นยังขึ้นอยู่กับการตั้งค่าของผู้ดูหรือโปรแกรมแก้ไขด้วย.

## **แสดงหรือซ่อนคอมเมนต์เมื่อเปิดการนำเสนอ**

ใช้[Presentation::get_ViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_viewproperties/)เพื่อเข้าถึงการตั้งค่ามุมมองทั่วการนำเสนอ. ใช้[IViewProperties::get_ShowComments](https://reference.aspose.com/slides/th/cpp/aspose.slides/iviewproperties/get_showcomments/)และ[IViewProperties::set_ShowComments](https://reference.aspose.com/slides/th/cpp/aspose.slides/iviewproperties/set_showcomments/)เพื่อเก็บค่าที่กำหนดว่าควรแสดงคอมเมนต์เมื่อการนำเสนอเปิดใน PowerPoint หรือโปรแกรมที่เข้ากันได้อื่นหรือไม่.

การตั้งค่านี้จะควบคุมเพียงความพึงพอใจของมุมมองที่เก็บไว้. มันจะไม่เพิ่ม, ลบ, แก้ไข หรือแก้ข้อคิดเห็น. การซ่อนคอมเมนต์จะคงเนื้อหา, ผู้เขียน, ตำแหน่ง, คำตอบและสถานะไว้. ดู[Presentation Comments](/slides/th/cpp/presentation-comments/)สำหรับการดำเนินการที่เปลี่ยนคอมเมนต์เอง.

ตัวอย่างต่อไปนี้ต้องการ `comments.pptx` ที่มีคอมเมนต์อยู่แล้ว. มันพิมพ์การตั้งค่าการมองเห็นปัจจุบัน, ขอให้ซ่อนคอมเมนต์, และบันทึก PPTX ใหม่โดยไม่ลบคอมเมนต์ใดๆ. นอกจากนี้ยังใช้[IViewProperties::set_LastView](https://reference.aspose.com/slides/th/cpp/aspose.slides/iviewproperties/set_lastview/)กับ[ViewType::SlideView](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewtype/)เพื่อกำหนดมุมมองการแก้ไขเริ่มต้นพร้อมกับการมองเห็นคอมเมนต์.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

การตั้งค่านี้ไม่ได้กำหนดว่าคอมเมนต์จะถูกรวมอยู่ในการส่งออกเป็น PDF, HTML, ภาพ, โน้ต หรือเอกสารแจกมือหรือไม่. โปรดตั้งค่าตัวเลือกการส่งออกเฉพาะที่เกี่ยวข้องแยกต่างหาก.

## **FAQ**

**ทำไมกริดถึงไม่แสดงหลังจากเปิดการนำเสนอใหม่?**

ไฟล์บันทึกการเว้นระยะของกริดไว้, แต่การแสดงกริดขึ้นอยู่กับการตั้งค่าของโปรแกรมแก้ไข. ตรวจสอบการตั้งค่าการมองเห็นของกริดในโปรแกรมแก้ไขของคุณ.

**การลบ drawing guides มีผลต่อการเว้นระยะของกริดหรือไม่?**

ไม่. drawing guides และการเว้นระยะของกริดเป็นการตั้งค่าอิสระกัน. การลบ guides จะไม่ทำให้ช่วงกริดที่บันทึกเปลี่ยนแปลง.

**ฉันสามารถตั้งค่าการมองต่างกันสำหรับส่วนต่างๆ ของการนำเสนอได้หรือไม่?**

[View settings](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_viewproperties/) ถูกกำหนดที่ระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), ไม่ได้กำหนดต่อแต่ละส่วน, ดังนั้นค่าพารามิเตอร์ชุดเดียวจึงใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะมุมมองที่แตกต่างกันสำหรับผู้ใช้ต่างๆ ได้หรือไม่?**

ไม่ได้. การตั้งค่าถูกเก็บในไฟล์และใช้ร่วมกัน. โปรแกรมผู้ดูอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถเตรียมเทมเพลตที่มี View Properties ที่กำหนดไว้ล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดในลักษณะเดียวกันหรือไม่?**

ทำได้. เนื่องจาก[view properties](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_viewproperties/)ถูกเก็บที่ระดับการนำเสนอ, คุณสามารถฝังมันในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นเพื่อให้มีการกำหนดมุมมองเริ่มต้นเดียวกัน.