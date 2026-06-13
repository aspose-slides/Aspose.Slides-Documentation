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

หนึ่งในคำถามที่พบบ่อยที่สุดจากลูกค้า Aspose.Slides สำหรับ C++ คือวิธีปรับขนาดรูปร่างให้เมื่อขนาดสไลด์เปลี่ยนแปลง ข้อมูลไม่ถูกตัดออก บทความเทคนิคสั้นนี้แสดงวิธีทำเช่นนั้น

## **ปรับขนาดรูปร่าง**

เพื่อป้องกันไม่ให้รูปร่างเบี่ยงเบนเมื่ขนาดสไลด์เปลี่ยนแปลง ให้ปรับตำแหน่งและมิติของแต่ละรูปร่างให้สอดคล้องกับรูปแบบสไลด์ใหม่

```cpp
// โหลดไฟล์การนำเสนอ.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// รับขนาดสไลด์เดิม.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// เปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่างที่มีอยู่.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// รับขนาดสไลด์ใหม่.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // สเกลขนาดรูปร่าง.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // สเกลตำแหน่งของรูปร่าง.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
หากสไลด์มีตาราง โค้ดข้างต้นจะไม่ทำงานอย่างถูกต้อง ในกรณีนั้นต้องปรับขนาดเซลล์แต่ละเซลล์ในตาราง
{{% /alert %}} 

ใช้โค้ดต่อไปนี้เพื่อปรับขนาดสไลด์ที่มีตาราง สำหรับตาราง การตั้งค่าความกว้างหรือความสูงเป็นกรณีพิเศษ: คุณต้องปรับความสูงของแถวและความกว้างของคอลัมน์แต่ละอันเพื่อเปลี่ยนขนาดโดยรวมของตาราง

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// รับขนาดสไลด์เดิม.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// เปลี่ยนขนาดสไลด์โดยไม่สเกลรูปร่างที่มีอยู่.
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
        // สเกลขนาดรูปร่าง.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // สเกลตำแหน่งของรูปร่าง.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // สเกลขนาดรูปร่าง.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // สเกลตำแหน่งของรูปร่าง.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // สเกลขนาดรูปร่าง.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // สเกลตำแหน่งของรูปร่าง.
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

**ทำไมรูปร่างถึงบิดเบี้ยวหรือถูกตัดออกหลังจากปรับขนาดสไลด์?**

เมื่อปรับขนาดสไลด์ รูปร่างจะคงตำแหน่งและขนาดเดิมไว้ เว้นแต่จะมีการเปลี่ยนสเกลอย่างชัดเจน สิ่งนี้อาจทำให้เนื้อหาโดนตัดหรือรูปร่างเบี่ยงเบน

**โค้ดที่ให้มาทำงานกับทุกประเภทของรูปร่างหรือไม่?**

ตัวอย่างพื้นฐานทำงานกับรูปแบบรูปร่างส่วนใหญ่ (กล่องข้อความ, รูปภาพ, แผนภูมิ ฯลฯ) อย่างไรก็ตาม สำหรับตารางคุณต้องจัดการแถวและคอลัมน์แยกกัน เนื่องจากความสูงและความกว้างของตารางกำหนดโดยมิติของเซลล์แต่ละเซลล์

**ฉันจะปรับขนาดตารางอย่างไรเมื่อปรับขนาดสไลด์?**

คุณต้องวนลูปผ่านทุกแถวและคอลัมน์ของตารางและปรับความสูงและความกว้างของพวกมันตามสัดส่วนตามที่แสดงในตัวอย่างโค้ดที่สอง

**การปรับขนาดนี้จะทำงานกับสไลด์มาสเตอร์และสไลด์เลเอาต์หรือไม่?**

ใช่ แต่คุณควรวนลูปผ่าน [Masters](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_masters/) และ [Layout slides](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_layoutslides/) แล้วใช้ตรรกะการสเกลเดียวกันกับรูปร่างของพวกมันเพื่อให้การนำเสนอมีความสอดคล้องกันทั่วทั้งไฟล์

**ฉันสามารถเปลี่ยนทิศทางของสไลด์ (แนวตั้ง/แนวนอน) พร้อมกับการปรับขนาดได้หรือไม่?**

ได้ คุณสามารถใช้ [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidesize/set_orientation/) เพื่อเปลี่ยนทิศทาง ตรวจสอบให้แน่ใจว่าคุณตั้งค่าตรรกะการสเกลให้เหมาะสมเพื่อคงรูปแบบเดิม

**มีขีดจำกัดขนาดสไลด์ที่ฉันสามารถตั้งค่าได้หรือไม่?**

Aspose.Slides รองรับขนาดที่กำหนดเอง แต่ขนาดที่ใหญ่มากอาจส่งผลต่อประสิทธิภาพหรือความเข้ากันได้กับบางเวอร์ชันของ PowerPoint

**ฉันจะป้องกันไม่ให้รูปร่างที่มีอัตราส่วนคงที่บิดเบี้ยวได้อย่างไร?**

คุณสามารถตรวจสอบเมธอด `get_AspectRatioLocked` ของรูปร่างก่อนทำการสเกล หากถูกล็อก ให้ปรับความกว้างหรือความสูงโดยสัดส่วนแทนการสเกลแยกกัน