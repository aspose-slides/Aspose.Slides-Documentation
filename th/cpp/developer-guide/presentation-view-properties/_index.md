---
title: ดึงและอัปเดตคุณสมบัติมุมมองงานนำเสนอใน C++
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/cpp/presentation-view-properties/
keywords:
- คุณสมบัติมุมมอง
- มุมมองปกติ
- เนื้อหาโครงร่าง
- ไอคอนโครงร่าง
- สแน็ปตัวแบ่งแนวตั้ง
- มุมมองเดี่ยว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- การซูมเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides สำหรับ C++ เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX, และ ODP — ปรับการจัดวาง, ระดับการซูม, และการตั้งค่าการแสดงผล"
---
## **บทนำ**

มุมมองปกติประกอบด้วยพื้นที่เนื้อหา 3 ส่วน: สไลด์เอง, พื้นที่เนื้อหาแบบด้านข้าง, และพื้นที่เนื้อหาแบบด้านล่าง. คุณสมบัติที่เกี่ยวข้องกับการจัดตำแหน่งของแต่ละพื้นที่เนื้อหา. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงในไฟล์, เพื่อเมื่อเปิดใหม่มุมมองจะอยู่ในสภาพเดียวกับที่บันทึกครั้งสุดท้ายของงานนำเสนอ.

เมธอด [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) ได้เพิ่มเพื่อให้เข้าถึงคุณสมบัติมุมมองปกติของงานนำเสนอ.

ได้เพิ่มอินเทอร์เฟซ [INormalViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/inormalviewrestoredproperties/) และบุตรของพวกมัน, พร้อมกับ enum [SplitterBarStateType](https://reference.aspose.com/slides/th/cpp/aspose.slides/splitterbarstatetype/) 

## **เกี่ยวกับ INormalViewProperties**

แสดงคุณสมบัติมุมมองปกติ.

คุณสมบัติ **ShowOutlineIcons** ระบุว่าแอปพลิเคชันควรแสดงไอคอนหรือไม่เมื่อแสดงเนื้อหาโครงร่างในพื้นที่เนื้อหาใด ๆ ของโหมดมุมมองปกติ.

คุณสมบัติ **SnapVerticalSplitter** ระบุว่าตัวแบ่งแนวตั้งควรสแน็ปเข้าสู่สถานะย่อเมื่อพื้นที่ด้านข้างมีขนาดเล็กพอ.

คุณสมบัติ **PreferSingleView** ระบุว่าผู้ใช้ต้องการดูพื้นที่เนื้อหาเดียวเต็มหน้าต่างแทนมุมมองปกติมาตรฐานที่มีสามพื้นที่เนื้อหาหรือไม่. หากเปิดใช้งาน, แอปพลิเคชันอาจเลือกแสดงหนึ่งในพื้นที่เนื้อหาเต็มหน้าต่าง.

คุณสมบัติ **VerticalBarState** และ **HorizontalBarState** ระบุสถานะที่แถบสลับแนวตั้งหรือแนวนอนควรแสดง. แถบสลับแนวนอนแยกสไลด์ออกจากพื้นที่เนื้อหาด้านล่างสไลด์, แถบสลับแนวตั้งแยกสไลด์ออกจากพื้นที่เนื้อหาแบบด้านข้าง. ค่าที่เป็นไปได้คือ: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** และ **SplitterBarStateType.Restored.**

คุณสมบัติ **RestoredLeft** และ **RestoredTop** ระบุการกำหนดขนาดของพื้นที่สไลด์ด้านบนหรือด้านข้างของมุมมองปกติ, เมื่อค่ **SplitterBarStateType.Restored** ถูกใช้กับ **VerticalBarState** และ **HorizontalBarState** ตามลำดับ.

## **เกี่ยวกับการคืนค่า INormalViewProperties**

ระบุการกำหนดขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ RestoredTop, ความสูงเมื่อเป็นลูกของ RestoredLeft) ของมุมมองปกติ, เมื่อพื้นที่นั้นมีขนาดที่กู้คืนได้แบบแปรผัน (ไม่ได้ย่อหรือขยาย).

คุณสมบัติ **DimensionSize** ระบุขนาดของพื้นที่สไลด์ (ความกว้างเมื่อเป็นลูกของ restoredTop, ความสูงเมื่อเป็นลูกของ restoredLeft).

คุณสมบัติ **AutoAdjust** ระบุว่าขนาดของพื้นที่เนื้อหาแบบด้านข้างควรปรับเพื่อชดเชยขนาดใหม่เมื่อเปลี่ยนขนาดหน้าต่างที่บรรจุมุมมองภายในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีเข้าถึงคุณสมบัติ **ViewProperties.NormalViewProperties** ของงานนำเสนอ.

``` cpp
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

// กู้คืนคุณสมบัติมุมมองของงานนำเสนอ
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าค่าการซูมเริ่มต้น**

Aspose.Slides for C++ ตอนนี้รองรับการตั้งค่าค่าการซูมเริ่มต้นสำหรับงานนำเสนอ ดังนั้นเมื่อเปิดงานนำเสนอการซูมจะถูกตั้งล่วงหน้า. สามารถทำได้โดยตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/) ของงานนำเสนอ. คุณสมบัติมุมมองสไลด์และ [get_NotesViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/get_notesviewproperties/) สามารถตั้งค่าโปรแกรมได้. ในหัวข้อนี้เราจะดูตัวอย่างวิธีตั้งค่าคุณสมบัติมุมมองของงานนำเสนอใน Aspose.Slides.

เพื่อกำหนดค่ามุมมอง, โปรดทำตามขั้นตอนต่อไปนี้:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. ตั้งค่า View [Properties](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/) ของ Presentation 
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX 

ในตัวอย่างด้านล่างเราได้ตั้งค่าการซูมสำหรับมุมมองสไลด์และมุมมองบันทึกย่อ.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// ตั้งค่าคุณสมบัติมุมมองของงานนำเสนอ
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // ค่าการซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // ค่าการซูมเป็นเปอร์เซ็นต์สำหรับมุมมองบันทึกย่อ

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าการจัดช่องกริด**

ใช้ [Presentation::get_ViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_viewproperties/) เพื่อเข้าถึงการตั้งค่ามุมมองระดับงานนำเสนอ. เมธอด [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/th/cpp/aspose.slides/iviewproperties/get_gridspacing/) และ [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/th/cpp/aspose.slides/iviewproperties/set_gridspacing/) อ่านหรือเปลี่ยนช่วงของกริดการแก้ไขพื้นฐาน. การตั้งค่านี้ใช้กับงานนำเสนอทั้งหมด, ไม่ใช่สไลด์เดี่ยว. ระยะห่างกริดระบุเป็นจุด, โดย 72 จุดเท่ากับหนึ่งนิ้ว. ใช้ค่าบวกตามที่เอกสาร API กำหนด.

ตัวอย่างต่อไปเปิดไฟล์ `demo.pptx` ที่มีอยู่แล้ว, แสดงระยะห่างกริดปัจจุบัน, ตั้งค่าช่วงเป็นหนึ่งในสี่นิ้ว, และบันทึกผลลัพธ์.

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

กริดแตกต่างจาก [drawing guides](/slides/th/cpp/drawing-guides/). ระยะห่างกริดควบคุมช่วงแบบสม่ำเสมอ, ในขณะที่ drawing guides เป็นเส้นแนวนอนหรือแนวตั้งที่กำหนดตำแหน่งเป็นรายตัว. การเพิ่ม, ย้าย, หรือทำความสะอาด drawing guides ไม่ทำให้ระยะห่างกริดเปลี่ยน.

กริดและ drawing guides ทั้งสองเป็นเครื่องมือช่วยการแก้ไข. พวกมันไม่ถูกเรนเดอร์เป็นเนื้อหาสไลด์ใน PDF, ภาพ, SVG หรือการแสดงสไลด์โชว์. การเก็บระยะห่างกริดไม่ได้รับประกันว่าโปรแกรมแก้ไขจะแสดงกริด: การมองเห็นยังขึ้นกับการตั้งค่าของผู้ชมหรือผู้แก้ไข.

## **คำถามที่พบบ่อย**

**ทำไมกริดถึงไม่แสดงหลังจากเปิดงานนำเสนอใหม่?**  
ไฟล์บันทึกระยะห่างกริดไว้, แต่โปรแกรมแก้ไขเป็นผู้ควบคุมว่ากริดจะแสดงหรือไม่. ตรวจสอบการตั้งค่าการมองเห็นกริดของโปรแกรมแก้ไข.

**การลบ drawing guides จะทำให้ระยะห่างกริดเปลี่ยนหรือไม่?**  
ไม่. drawing guides และระยะห่างกริดเป็นการตั้งค่าแยกกัน. การลบ guides ทำให้ช่วงกริดที่เก็บไว้ไม่เปลี่ยนแปลง.

**ฉันสามารถตั้งค่ามุมมองต่าง ๆ สำหรับส่วนต่าง ๆ ของงานนำเสนอได้หรือไม่?**  
การตั้งค่า [View settings](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_viewproperties/) ถูกกำหนดระดับงานนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), ไม่ใช่ต่อส่วน, ดังนั้นชุดพารามิเตอร์เดียวจึงใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะมุมมองที่แตกต่างสำหรับผู้ใช้แต่ละคนได้หรือไม่?**  
ไม่. การตั้งค่าถูกเก็บในไฟล์และใช้ร่วมกัน. โปรแกรมดูอาจเคารพการตั้งค่าผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถสร้างเทมเพลตที่มี View Properties ที่กำหนดล่วงหน้าเพื่อให้งานนำเสนอใหม่เปิดด้วยวิธีเดียวกันได้หรือไม่?**  
ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_viewproperties/) ถูกเก็บระดับงานนำเสนอ, คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นด้วยการกำหนดมุมมองเริ่มต้นเดียวกัน.