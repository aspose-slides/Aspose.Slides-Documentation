---
title: ปรับขนาดรูปร่างบนสไลด์พรีเซนเทชันใน C++
type: docs
weight: 130
url: /th/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /th/cpp/re-sizing-shapes-on-slide/
keywords:
  - ปรับขนาดรูปร่าง
  - เปลี่ยนขนาดรูปร่าง
  - PowerPoint
  - OpenDocument
  - พรีเซนเทชัน
  - C++
  - Aspose.Slides
description: "ปรับขนาดรูปร่างบนสไลด์ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ C++—ทำงานอัตโนมัติการปรับเลเอาต์สไลด์และเพิ่มประสิทธิภาพการทำงาน."
---
## **ภาพรวม**

เมื่อคุณเปลี่ยนขนาดสไลด์ของงานพรีเซนเทชัน คุณอาจต้องปรับขนาดและตำแหน่งของรูปร่างให้พอดีกับมิติใหม่ บทความนี้แสดงวิธีสเกลรูปร่างด้วยตนเองและวิธีจัดการตารางบนสไลด์ มาสเตอร์ และเลเอาต์

## **ปรับขนาดรูปร่าง**

เพื่อรักษาตำแหน่งและขนาดสัมพัทธ์ของแต่ละรูปร่าง ให้คูณพิกัดแนวนอนและความกว้างของมันด้วยอัตราส่วนของความกว้างสไลด์ใหม่ต่อความกว้างเดิม แล้วใช้อัตราส่วนความสูงที่สอดคล้องกับพิกัดแนวตั้งและความสูงของมัน

ตัวอย่างแรกโหลดงานพรีเซนเทชันที่สไลด์ไม่มีตาราง เปลี่ยนขนาดสไลด์เป็น A4 และบันทึกผลลัพธ์ มันใช้ [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) กับ [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) เพื่อให้ลูปต่อไปควบคุมการสเกล อัตราส่วนไม่มีหน่วย; ตำแหน่งและมิติของรูปร่างวัดเป็น points อัตราส่วนความกว้างและความสูงที่ต่างกันอาจทำให้รูปร่างบิดเบี้ยว และการเปลี่ยนมิติของรูปร่างไม่สเกลขนาดฟอนต์

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

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
ตารางต้องการการจัดการแยกต่างหาก: สเกลความกว้างของคอลัมน์และความสูงของแถวแทนการกำหนดความกว้างและความสูงรวมของตาราง ความสูงของแถวอาจใหญ่กว่าที่ร้องขอหากเนื้อหาในเซลล์ต้องการพื้นที่เพิ่ม
{{% /alert %}}

ตัวอย่างที่สองรองรับตารางและประมวลผลรูปร่างบนมาสเตอร์และเลเอาต์รวมถึงสไลด์แต่ละอันก่อนบันทึกงานพรีเซนเทชันที่ปรับขนาด ตัวช่วยของมันจัดการแต่ละ [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) โดยสเกล [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) และ [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) จากนั้นสเกลตำแหน่งของตารางโดยไม่สเกลมิติรวมแยกออก

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
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// คำนวนอัตราส่วนสเกลแนวนอนและแนวตั้งแยกกัน.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // มิติของตารางถูกควบคุมโดยความกว้างของคอลัมน์และความสูงของแถว.
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// ปรับขนาดรูปร่างที่กำหนดบนมาสเตอร์และเลเอาต์รวมถึงสไลด์แต่ละอัน.
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**ทำไมรูปร่างถึงดูบิดเบี้ยวหรือถูกตัดออกหลังจากปรับขนาดสไลด์?**

หากคุณเปลี่ยนขนาดสไลด์โดยไม่ได้สเกลรูปร่าง พวกมันจะคงตำแหน่งและมิติเดิมและอาจยืดออกนอกสไลด์ การสเกลความกว้างและความสูงด้วยอัตราส่วนที่ต่างกันก็อาจทำให้รูปร่างบิดเบี้ยวได้

**โค้ดที่ให้มาสามารถทำงานกับทุกประเภทของรูปร่างได้หรือไม่?**

ตัวอย่างแรกเปลี่ยนขอบเขตของรูปร่างโดยตรงและออกแบบมาสำหรับสไลด์ที่ไม่มีตาราง ตัวอย่างที่สองจัดการตารางแยกต่างหาก ควรตรวจสอบเลเอาต์ที่ได้ โดยเฉพาะข้อความและตาราง เนื่องจากตัวอย่างเหล่านี้ไม่ได้สเกลขนาดฟอนต์และเนื้อหาตารางอาจจำกัดความสูงของแถว

**ฉันจะปรับขนาดตารางอย่างไรเมื่อปรับขนาดสไลด์?**

สเกลความกว้างของคอลัมน์ด้วยอัตราส่วนความกว้างและความสูงขั้นต่ำของแถวด้วยอัตราส่วนความสูง จากนั้นสเกลตำแหน่งของตารางตามที่แสดงในตัวอย่างที่สอง

**การปรับขนาดนี้จะทำงานกับสไลด์มาสเตอร์และสไลด์เลเอาต์หรือไม่?**

ใช่ ตัวอย่างที่สองวนรอบผ่าน [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) และ [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) ของแต่ละมาสเตอร์ แล้วใช้ตรรกะการปรับขนาดเดียวกันกับรูปร่างของพวกมัน

**ฉันสามารถเปลี่ยนการจัดวางของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**

ใช่ ตั้งค่า [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) หลังจากเปลี่ยนขนาดสไลด์และก่อนอ่านมิติเป้าหมาย เพื่อให้ค่าอัตราส่วนสอดคล้องกับการจัดวางสุดท้าย

**มีขีดจำกัดของขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**

คุณสามารถกำหนดมิติสไลด์แบบกำหนดเองด้วย [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) ได้ ขนาดที่สนับสนุนยังขึ้นอยู่กับรูปแบบพรีเซนเทชันและแอปพลิเคชันที่ใช้เปิดไฟล์

**ฉันจะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?**

ใช้ค่าอัตราส่วนสเกลเดียวกันสำหรับความกว้างและความสูง เพื่อให้เลเอาต์เดิมพอดีกับมิติสไลด์ใหม่ ให้ใช้ค่าอัตราส่วนที่เล็กกว่าระหว่างความกว้างและความสูงสำหรับทั้งสองมิติและตำแหน่ง วิธีนี้จะรักษาสัดส่วนไว้แต่อาจทำให้เกิดพื้นที่ว่างที่ด้านหนึ่ง