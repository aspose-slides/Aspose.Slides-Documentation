---
title: ปรับขนาดรูปร่างบนสไลด์การนำเสนอ
type: docs
weight: 100
url: /th/cpp/re-sizing-shapes-on-slide/
keywords:
- ปรับขนาดรูปร่าง
- เปลี่ยนขนาดรูปร่าง
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument ได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ C++—ทำให้การปรับเลย์เอาต์สไลด์อัตโนมัติและเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

หนึ่งในคำถามที่พบบ่อยที่สุดจากลูกค้า Aspose.Slides for C++ คือวิธีการปรับขนาดรูปร่างให้เมื่อขนาดสไลด์เปลี่ยนแปลงแล้วข้อมูลไม่ถูกตัดออก บทความเชิงเทคนิคสั้นนี้จะแสดงวิธีทำ

## **ปรับขนาดรูปร่าง**

เพื่อป้องกันไม่ให้รูปร่างเรียงตำแหน่งผิดพลาดเมื่อขนาดสไลด์เปลี่ยนแปลง ให้ปรับตำแหน่งและมิติของแต่ละรูปร่างให้สอดคล้องกับเค้าโครงสไลด์ใหม่

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// โหลดไฟล์งานนำเสนอ.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// รับขนาดสไลด์ดั้งเดิม.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// เปลี่ยนขนาดสไลด์โดยไม่ปรับสเกลของรูปร่างที่มีอยู่.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// รับขนาดสไลด์ใหม่.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// ปรับขนาดและเปลี่ยนตำแหน่งรูปร่างบนทุกสไลด์.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // ปรับสเกลขนาดรูปร่าง.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // ปรับสเกลตำแหน่งรูปร่าง.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
ถ้าสไลด์มีตาราง โค้ดด้านบนจะทำงานไม่ถูกต้อง ในกรณีนั้นต้องปรับขนาดเซลล์แต่ละเซลล์ในตาราง
{{% /alert %}} 

ใช้โค้ดต่อไปนี้เพื่อปรับขนาดสไลด์ที่มีตาราง สำหรับตาราง การตั้งความกว้างหรือความสูงเป็นกรณีพิเศษ: คุณต้องปรับความสูงของแถวและความกว้างของคอลัมน์แต่ละรายการเพื่อเปลี่ยนขนาดโดยรวมของตาราง

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// รับขนาดสไลด์ดั้งเดิม.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// เปลี่ยนขนาดสไลด์โดยไม่ปรับสเกลของรูปร่างที่มีอยู่.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// รับขนาดสไลด์ใหม่.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // ปรับสเกลขนาดรูปร่าง.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // ปรับสเกลตำแหน่งรูปร่าง.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // ปรับสเกลขนาดรูปร่าง.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // ปรับสเกลตำแหน่งรูปร่าง.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // ปรับสเกลขนาดรูปร่าง.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // ปรับสเกลตำแหน่งรูปร่าง.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

### ทำไมรูปร่างถึงบิดเบี้ยวหรือถูกตัดออกหลังจากปรับขนาดสไลด์?

เมื่อปรับขนาดสไลด์ รูปร่างจะคงตำแหน่งและขนาดเดิมไว้ เว้นแต่จะมีการเปลี่ยนสเกลโดยชัดเจน ซึ่งอาจทำให้เนื้อหาถูกครอบหรือรูปร่างเรียงตำแหน่งผิดพลาด

### โค้ดที่ให้มาทำงานกับทุกประเภทของรูปร่างหรือไม่?

ตัวอย่างพื้นฐานทำงานกับรูปร่างส่วนใหญ่ (กล่องข้อความ, ภาพ, แผนภูมิ ฯลฯ) อย่างไรก็ตาม สำหรับตารางคุณต้องจัดการแถวและคอลัมน์แยกกัน เนื่องจากความสูงและความกว้างของตารางกำหนดโดยขนาดของเซลล์แต่ละเซลล์

### ฉันจะปรับขนาดตารางอย่างไรเมื่อปรับขนาดสไลด์?

คุณต้องวนลูปผ่านทุกแถวและคอลัมน์ของตารางและปรับความสูงและความกว้างของพวกมันอย่างสัดส่วนตามที่แสดงในตัวอย่างโค้ดที่สอง

### การปรับขนาดนี้จะใช้ได้กับสไลด์มาสเตอร์และสไลด์เลย์เอาต์หรือไม่?

ใช่ แต่คุณควรวนลูปผ่าน[Masters](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_masters/)และ[Layout slides](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_layoutslides/)และใช้ตรรกะสเกลเดียวกันกับรูปร่างของพวกเขาเพื่อให้การนำเสนอทั้งหมดมีความสอดคล้องกัน

### ฉันสามารถเปลี่ยนการวางแนวของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?

ใช่ คุณสามารถใช้[presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidesize/set_orientation/)เพื่อเปลี่ยนการวางแนว ตรวจสอบให้แน่ใจว่ากำหนดตรรกะสเกลให้สอดคล้องเพื่อรักษาเค้าโครง

### มีขีดจำกัดขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?

Aspose.Slides รองรับขนาดแบบกำหนดเอง แต่ขนาดที่ใหญ่เกินไปอาจส่งผลต่อประสิทธิภาพหรือความเข้ากันได้กับบางเวอร์ชันของ PowerPoint

### ฉันจะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?

คุณสามารถตรวจสอบเมธอด`get_AspectRatioLocked`ของรูปร่างก่อนทำการสเกล หากถูกล็อก ให้ปรับความกว้างหรือความสูงอย่างสัดส่วนแทนการสเกลแยกกัน