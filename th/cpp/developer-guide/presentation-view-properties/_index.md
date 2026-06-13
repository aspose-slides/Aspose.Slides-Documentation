---
title: ดึงข้อมูลและอัปเดตคุณสมบัติมุมมองของการนำเสนอใน C++
linktitle: คุณสมบัติมุมมอง
type: docs
weight: 80
url: /th/cpp/presentation-view-properties/
keywords:
  - คุณสมบัติมุมมอง
  - มุมมองปกติ
  - เนื้อหาโครงร่าง
  - ไอคอนโครงร่าง
  - บาร์แยกแนวตั้งสแนป
  - มุมมองเดี่ยว
  - สถานะบาร์
  - ขนาดมิติ
  - ปรับอัตโนมัติ
  - ซูมเริ่มต้น
  - PowerPoint
  - OpenDocument
  - การนำเสนอ
  - C++
  - Aspose.Slides
description: "ค้นพบคุณสมบัติมุมมองของ Aspose.Slides สำหรับ C++ เพื่อปรับแต่งรูปแบบสไลด์ PPT, PPTX และ ODP — ปรับการจัดวาง, ระดับซูม และการตั้งค่าการแสดงผล"
---
## **บทนำ**

มุมมองปกติประกอบด้วยสามบริเวณเนื้อหา: สไลด์เอง, บริเวณเนื้อหาด้านข้าง, และบริเวณเนื้อหาด้านล่าง. คุณสมบัติเกี่ยวกับตำแหน่งของแต่ละบริเวณเนื้อหา. ข้อมูลนี้ทำให้แอปพลิเคชันสามารถบันทึกสถานะมุมมองลงในไฟล์, เพื่อให้เมื่อเปิดใหม่มุมมองอยู่ในสถานะเดียวกันกับเมื่อการนำเสนอถูกบันทึกครั้งสุดท้าย.

เมธอด [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) ได้ถูกเพิ่มเพื่อให้เข้าถึงคุณสมบัตุมุมมองปกติของการนำเสนอ.  

[INormalViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/inormalviewrestoredproperties/) อินเทอร์เฟซและคลาสที่สืบทอด, [SplitterBarStateType](https://reference.aspose.com/slides/th/cpp/aspose.slides/splitterbarstatetype/) enum ได้ถูกเพิ่ม.

## **เกี่ยวกับ INormalViewProperties**

เป็นตัวแทนของคุณสมบัตุมุมมองปกติ.

คุณสมบัติ **ShowOutlineIcons** กำหนดว่าต้องแสดงไอคอนเมื่อแสดงเนื้อหาโครงร่างในใดก็ของบริเวณเนื้อหาในโหมดมุมมองปกติหรือไม่.

คุณสมบัติ **SnapVerticalSplitter** กำหนดว่าบาร์แยกแนวตั้งควรสแนปไปสู่สถานะย่อเมื่อบริเวณด้านข้างมีขนาดเล็กพอ.

คุณสมบัติ **PreferSingleView** กำหนดว่าผู้ใช้ต้องการดูบริเวณเนื้อหาเดี่ยวเต็มหน้าต่างแทนมุมมองปกติแบบมาตรฐานที่มีสามบริเวณหรือไม่. หากเปิดใช้งาน แอปพลิเคชันอาจเลือกแสดงหนึ่งในบริเวณเนื้อหาเต็มหน้าต่าง.

คุณสมบัติ **VerticalBarState** และ **HorizontalBarState** กำหนดสถานะที่บาร์แยกแนวนอนหรือแนวตั้งควรแสดง. บาร์แยกแนวนอนแยกสไลด์จากบริเวณเนื้อหาด้านล่าง, ส่วนบาร์แยกแนวตั้งแยกสไลด์จากบริเวณเนื้อหาด้านข้าง. ค่าที่เป็นไปได้คือ **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** และ **SplitterBarStateType.Restored**.

คุณสมบัติ **RestoredLeft** และ **RestoredTop** กำหนดขนาดของบริเวณสไลด์ด้านบนหรือด้านข้างของมุมมองปกติ, เมื่อค่า **SplitterBarStateType.Restored** ถูกนำไปใช้กับ **VerticalBarState** และ **HorizontalBarState** ตามลำดับ.

## **เกี่ยวกับการกู้คืน INormalViewProperties**

กำหนดขนาดของบริเวณสไลด์ (ความกว้างเมื่อเป็นลูกของ RestoredTop, ความสูงเมื่อเป็นลูกของ RestoredLeft) ของมุมมองปกติ, เมื่อบริเวณมีขนาดที่กู้คืนได้แบบเปลี่ยนแปลงได้ (ไม่ย่อและไม่ขยาย).

คุณสมบัติ **DimensionSize** กำหนดขนาดของบริเวณสไลด์ (ความกว้างเมื่อเป็นลูกของ RestoredTop, ความสูงเมื่อเป็นลูกของ RestoredLeft).

คุณสมบัติ **AutoAdjust** กำหนดว่าบริเวณเนื้อหาด้านข้างควรปรับขนาดเพื่อชดเชยขนาดใหม่เมื่อปรับขนาดหน้าต่างที่มีมุมมองอยู่ในแอปพลิเคชันหรือไม่.

ตัวอย่างด้านล่างแสดงวิธีเข้าถึงคุณสมบัติ **ViewProperties.NormalViewProperties** ของการนำเสนอ.

``` cpp
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

Aspose.Slides for C++ ตอนนี้รองรับการตั้งค่าค่าซูมเริ่มต้นสำหรับการนำเสนอโดยที่เมื่อเปิดการนำเสนอ ซูมจะถูกตั้งค่าไว้แล้ว. สามารถทำได้โดยการตั้งค่า [ViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/) ของการนำเสนอ. คุณสมบัติมุมมองสไลด์รวมถึง [get_NotesViewProperties](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/get_notesviewproperties/) สามารถตั้งค่าได้โดยโปรแกรม. ในหัวข้อนี้ เราจะดูตัวอย่างวิธีตั้งค่าคุณสมบัติมุมมองของการนำเสนอใน Aspose.Slides.

เพื่อทำการตั้งค่าคุณสมบัตุมุมมอง โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
1. ตั้งค่า View [Properties](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/) ของการนำเสนอ
1. บันทึกการนำเสนอเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้ตั้งค่าค่าซูมสำหรับมุมมองสไลด์และมุมมองบันทึกหมายเหตุ.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// ตั้งค่าคุณสมบัติมุมมองของการนำเสนอ
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองสไลด์
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // ค่าซูมเป็นเปอร์เซ็นต์สำหรับมุมมองบันทึกหมายเหตุ 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่ามุมมองที่แตกต่างสำหรับส่วนต่าง ๆ ของการนำเสนอได้หรือไม่?**

[View settings](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_viewproperties/) ถูกกำหนดระดับการนำเสนอ ([Normal View](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/th/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), ไม่ได้ระดับส่วน, ดังนั้นชุดพารามิเตอร์เดียวจะใช้กับเอกสารทั้งหมดเมื่อเปิด.

**ฉันสามารถกำหนดสถานะมุมมองล่วงหน้าสำหรับผู้ใช้ต่าง ๆ ได้หรือไม่?**

ไม่ได้. การตั้งค่าถูกเก็บในไฟล์และแชร์กัน. แอปพลิเคชันผู้ชมอาจเคารพการตั้งค่าของผู้ใช้, แต่ไฟล์เองมีชุดคุณสมบัติมุมมองเดียว.

**ฉันสามารถเตรียมเทมเพลตที่มีคุณสมบัติมุมมองที่กำหนดล่วงหน้าเพื่อให้การนำเสนอใหม่เปิดในลักษณะเดียวกันได้หรือไม่?**

ได้. เนื่องจาก [view properties](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_viewproperties/) ถูกเก็บระดับการนำเสนอ, คุณสามารถฝังไว้ในเทมเพลตและสร้างเอกสารใหม่จากเทมเพลตนั้นโดยมีการกำหนดค่ามุมมองเริ่มต้นเดียวกัน.