---
title: ดึงและอัปเดตคุณสมบัติมุมมองของงานนำเสนอใน C++
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
- มุมมองเดียว
- สถานะแถบ
- ขนาดมิติ
- ปรับอัตโนมัติ
- การขยายเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ใช้ Aspose.Slides สำหรับ C++ เพื่อกำหนดค่าเลย์เอาต์ของมุมมองปกติ, การขยายสไลด์และบันทึก, ระยะห่างของกริด, และการแสดงความเห็นในงานนำเสนอ PowerPoint."
---
## **บทนำ**

ในมุมมองปกติของ PowerPoint สไลด์จะแสดงระหว่างแผงด้านข้างสำหรับภาพย่อหรือโครงร่างและแผงบันทึกด้านล่าง Aspose.Slides for C++ เปิดเผยการตั้งค่าการแก้ไขที่บันทึกไว้ของงานนำเสนอผ่าน [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). รวมถึงการจัดเรียงแผง ระดับการขยาย ระยะห่างของกริด และการแสดงความเห็น

## **เกี่ยวกับ INormalViewProperties**

ใช้ [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) เพื่อเข้าถึงอินเทอร์เฟซ [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/). [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) ควบคุมว่าจะให้ไอคอนแสดงข้างชื่อสไลด์ในโครงร่างหรือไม่. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) ทำให้แผงด้านข้างสแน็ปไปสู่สถานะย่อตอนที่ผู้ใช้ปรับให้แคบ. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) บ่งบอกถึงความต้องการให้แสดงแผงเดียวในหน้าต่างเต็ม

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) ควบคุมตัวแบ่งระหว่างแผงด้านข้างและสไลด์. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) ควบคุมตัวแบ่งเหนือแผงบันทึก. ทั้งสองรับค่า [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) ที่เป็น `Minimized`, `Maximized`, หรือ `Restored`.

## **เกี่ยวกับการคืนค่า INormalViewProperties**

เมื่อตัวแบ่งถูกคืนค่า, [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) ให้ขนาดที่บันทึกของแผงด้านข้างและ [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) ให้ขนาดที่บันทึกของพื้นที่สไลด์ด้านบน. ทั้งสองเปิดเผย [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). วิธีการ [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) รับเปอร์เซ็นต์ตั้งแต่ 0 ถึง 100, และ [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) ควบคุมว่าจะให้โปรแกรมแก้ไขปรับขนาดเมื่อหน้าต่างถูกเปลี่ยนขนาดหรือไม่

ตัวอย่างนี้อัปเดตงานนำเสนอที่มีอยู่. มันคืนค่าตัวแบ่งแนวนอน, ตั้งค่าขนาดของพื้นที่สไลด์ด้านบนที่เปิดเผยโดย [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) ให้เป็น 80% พร้อมเปิดใช้งานการปรับอัตโนมัติ, และขยายตัวแบ่งแนวตั้งให้เต็ม. นอกจากนี้ยังเปิดใช้งานไอคอนโครงร่างด้วย [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) สำหรับมุมมองโครงร่าง

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าค่าการขยายเริ่มต้น**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) และ [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) เก็บการตั้งค่าการขยายแยกกันสำหรับโปรแกรมแก้ไข. การตั้งค่าเหล่านี้ไม่มีผลต่อมิติของสไลด์, การเล่นสไลด์โชว์, หรือความละเอียดของการส่งออกภาพ

ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และเปิดการปรับขนาดอัตโนมัติด้วย [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) เพื่อให้สไลด์พอดีกับหน้าต่างการแก้ไข. สำหรับหน้าบันทึก, มันปิดการปรับขนาดอัตโนมัติและใช้ [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) ตั้งค่าการขยายคงที่ที่ 80%

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าระยะห่างของกริด**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) ตั้งค่าระยะห่างระหว่างเส้นกริดการแก้ไขทั่วทั้งงานนำเสนอ. ค่าที่รับเป็นจำนวนบวกในหน่วยจุด, โดยมี 72 จุดต่อหนึ่งนิ้ว. ตัวอย่างนี้พิมพ์ระยะห่างปัจจุบันในงานนำเสนอที่มีอยู่และบันทึกกริดเป็นหนึ่งในสี่นิ้วโดยตั้งค่าช่วงเป็น 18 จุด

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

กริดจะทำซ้ำที่ช่วงคงที่. [Drawing guides](/slides/th/cpp/drawing-guides/) ทำเครื่องหมายตำแหน่งแนวนอนหรือแนวตั้งแต่ละตำแหน่ง. ทั้งสองเป็นเครื่องมือช่วยการแก้ไขและปรากฏเฉพาะในโปรแกรมแก้ไขที่แสดงมัน. การแสดงสไลด์โชว์และการส่งออกเป็น PDF, รูปภาพ หรือ SVG จะละเว้นมัน

## **แสดงหรือซ่อนความเห็นเมื่อเปิดงานนำเสนอ**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) เก็บค่าการตั้งค่าที่โปรแกรมแก้ไขที่เข้ากันได้ใช้เมื่อลองเปิดงานนำเสนอ. สำหรับงานนำเสนอที่มีความเห็นอยู่, ตัวอย่างนี้พิมพ์การตั้งค่าปัจจุบันและบันทึกสำเนาที่ซ่อนความเห็น. นอกจากนี้ยังเรียก [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) พร้อมกับ [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) เพื่อให้สำเนาเปิดในมุมมองสไลด์

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

การซ่อนความเห็นจะรักษาข้อความ, ผู้เขียน, ตำแหน่ง, การตอบกลับและสถานะของความเห็นไว้. หากต้องการเปลี่ยนความเห็นเอง, ดูที่ [Presentation Comments](/slides/th/cpp/presentation-comments/). การตั้งค่าการส่งออกรองว่าจะให้ความเห็นปรากฏใน PDF, HTML, รูปภาพ, บันทึกหรือเอกสารแจกจ่ายหรือไม่

## **คำถามที่พบบ่อย**

**ทำไมกริดถึงหายไปเมื่อฉันเปิดงานนำเสนอใหม่?**

งานนำเสนอจะบันทึกช่วงระยะห่างของกริด. ให้เปิดการแสดงกริดในโปรแกรมแก้ไขเพื่อดูกริด

**การล้าง drawing guides จะทำให้ระยะห่างของกริดเปลี่ยนหรือไม่?**

ไม่. การเพิ่ม, ย้ายหรือล้างไกด์จะไม่ทำให้ช่วงระยะห่างของกริดเปลี่ยน

**ส่วนต่าง ๆ ของงานนำเสนอสามารถมีการตั้งค่ามุมมองที่แตกต่างกันได้หรือไม่?**

ไม่ได้. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) ใช้กับงานนำเสนอทั้งหมด

**ฉันสามารถบันทึกการตั้งค่ามุมมองที่ต่างกันสำหรับผู้ใช้คนละคนได้หรือไม่?**

ไฟล์จะบันทึกชุดการตั้งค่ามุมมองเดียวสำหรับทุกคน. โปรแกรมแก้ไขอาจนำการตั้งค่าท้องถิ่นของผู้ใช้มาใช้เพิ่มเติม

**ฉันสามารถบันทึกการตั้งค่ามุมมองในแม่แบบได้หรือไม่?**

ได้. งานนำเสนอที่สร้างจากแม่แบบจะสืบทอดการตั้งค่ามุมมองที่บันทึกไว้ในแม่แบบ