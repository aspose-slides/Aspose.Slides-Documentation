---
title: จัดการ SmartArt ในงานนำเสนอ PowerPoint ด้วย C++
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/cpp/manage-smartart/
keywords:
- SmartArt
- ข้อความ SmartArt
- ประเภทเค้าโครง
- คุณสมบัติเชิงซ่อน
- แผนผังองค์กร
- แผนผังองค์กรรูปภาพ
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้การสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides สำหรับ C++ ด้วยตัวอย่างโค้ดที่ชัดเจนซึ่งช่วยเร่งการออกแบบสไลด์และการทำงานอัตโนมัติ."
---
## **ภาพรวม**

SmartArt คือแผนภูมิ PowerPoint ที่สร้างจากโหนด รูปร่างโหนด และเค้าโครง ด้วย Aspose.Slides สำหรับ C++ คุณสามารถสร้าง SmartArt อ่านข้อความจากโหนดของมัน เปลี่ยนเค้าโครง ตรวจสอบโหนดที่ซ่อนอยู่ กำหนดค่าเค้าโครงแผนผังองค์กร และสร้างแผนผังองค์กรรูปภาพได้

## **รับข้อความจากออบเจ็กต์ SmartArt**

โหนด SmartArt สามารถมีรูปทรงหนึ่งหรือมากกว่าหนึ่งรูปทรง เพื่ออ่านข้อความที่มองเห็นได้ ให้วนรอบผ่าน [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartart/get_allnodes/), จากนั้นอ่าน [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ที่ส่งคืนโดย [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartartshape/get_textframe/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **เปลี่ยนประเภทเค้าโครงของออบเจ็กต์ SmartArt**

เค้าโครง SmartArt ควบคุมการจัดเรียงและการเชื่อมต่อของโหนด ตัวอย่างต่อไปนี้สร้างออบเจ็กต์ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` จากนั้นเปลี่ยนเป็นค่า `BasicProcess` และบันทึกพรีเซนเทชัน

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ตรวจสอบว่าโหนด SmartArt ถูกซ่อนหรือไม่**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) ระบุว่าโหนดถูกซ่อนอยู่ในโมเดลข้อมูล SmartArt หรือไม่ โหนดที่ซ่อนอยู่สามารถมีอยู่ในโครงสร้างได้แม้ว่าเค้าโครงที่เลือกจะไม่แสดงเป็นองค์ประกอบแผนภูมิที่มองเห็นได้

ตัวอย่างต่อไปนี้เพิ่มโหนดลงในออบเจ็กต์ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` และตรวจสอบสถานะการซ่อนของโหนด

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **รับหรือกำหนดเค้าโครงแผนผังองค์กร**

สำหรับแผนภูมิ SmartArt ที่ใช้เค้าโครงแผนผังองค์กร [ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) และ [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) กำหนดวิธีการจัดเรียงโหนดลูกภายใต้โหนดพ่อแม่ ตัวอย่างเช่น คุณสามารถตั้งค่าให้โหนดลูกห้อยจากด้านซ้าย ด้านขวา หรือทั้งสองด้าน ขึ้นอยู่กับ [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/organizationchartlayouttype/)

ตัวอย่างต่อไปนี้สร้างแผนผังองค์กรและกำหนดเค้าโครงสำหรับโหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **สร้างแผนผังองค์กรรูปภาพ**

แผนผังองค์กรรูปภาพคือเค้าโครง SmartArt ที่ออกแบบมาสำหรับแผนภูมิชั้นลำดับที่มีที่วางรูปภาพ ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` เมื่อเพิ่มออบเจ็กต์ SmartArt ลงในสไลด์

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**SmartArt รองรับการสะท้อนหรือการกลับด้านสำหรับภาษาขวาไปซ้ายหรือไม่?**

ใช่. เมธอด [SmartArt::set_IsReversed](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartart/set_isreversed/) จะสลับทิศทางของแผนภูมิจากซ้ายไปขวาเป็นขวาไปซ้าย หรือกลับกัน เมื่อเค้าโครง SmartArt ที่เลือกรองรับการกลับด้าน

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังพรีเซนเทชันอื่นโดยคงรูปแบบไว้ได้อย่างไร?**

คุณสามารถ [clone the SmartArt shape](/slides/th/cpp/shape-manipulations/) ด้วย [ShapeCollection::AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapecollection/addclone/) หรือ [clone the whole slide](/slides/th/cpp/clone-slides/) ที่มี SmartArt ทั้งสองวิธีจะคงขนาด ตำแหน่ง และรูปแบบไว้

**ฉันจะเรนเดอร์ SmartArt เป็นภาพราสเตอร์เพื่อการแสดงตัวอย่างหรือส่งออกไปเว็บได้อย่างไร?**

[Render the slide](/slides/th/cpp/convert-powerpoint-to-png/) หรือพรีเซนเทชันทั้งหมดเป็น PNG หรือ JPEG. SmartArt จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์

**ฉันจะค้นหาออบเจ็กต์ SmartArt เฉพาะบนสไลด์เมื่อมีหลายออบเจ็กต์ได้อย่างไร?**

กำหนดค่า [Shape::set_AlternativeText](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/set_alternativetext/) หรือ [Shape::set_Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/set_name/) ที่เป็นเอกลักษณ์บนรูปทรง SmartArt แล้วค้นหาค่าดังกล่าวใน [BaseSlide::get_Shapes](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseslide/get_shapes/). จากนั้นตรวจสอบว่ารูปทรงที่ตรงกันเป็น [ISmartArt](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/ismartart/)