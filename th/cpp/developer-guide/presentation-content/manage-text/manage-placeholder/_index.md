---
title: จัดการ Placeholder ในการนำเสนอด้วย C++
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/cpp/manage-placeholder/
keywords:
- ตัวแทนตำแหน่ง
- ตัวแทนตำแหน่งข้อความ
- ตัวแทนตำแหน่งรูปภาพ
- ตัวแทนตำแหน่งแผนภูมิ
- ตัวแทนตำแหน่งเนื้อหา
- ข้อความแจ้งเตือน
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไขตัวแทนตำแหน่งข้อความ, รูปภาพ, แผนภูมิ และเนื้อหา รวมถึงทำความเข้าใจการสืบทอดของตัวแทนตำแหน่งด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Placeholder คือรูปทรงที่สงวนตำแหน่งไว้สำหรับประเภทเนื้อหาเฉพาะในเทมเพลตการนำเสนอ ตัวอย่างทั่วไปได้แก่ placeholder สำหรับหัวเรื่อง, เนื้อหา, รูปภาพ, แผนภูมิ, และ placeholder เนื้อหาทั่วไปอื่น ๆ ต่างจากรูปทรงทั่วไป placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบและการตั้งค่าอื่น ๆ จากสไลด์เลเอาท์หรือสไลด์มาสเตอร์ได้

Aspose.Slides ให้ข้อมูล placeholder ผ่านเมธอด [IShape::get_Placeholder](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_placeholder/) เมธอดนี้จะคืนค่าอ็อบเจ็กต์ [IPlaceholder](https://reference.aspose.com/slides/th/cpp/aspose.slides/iplaceholder/) หรือ `nullptr` สำหรับรูปทรงปกติ ใช้ [IPlaceholder::get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/iplaceholder/get_type/) เพื่อระบุว่า placeholder มีจุดประสงค์เพื่อใส่สิ่งใด

อินเทอร์เฟซของรูปทรงยังคงสำคัญหลังจากคุณทราบประเภทของ placeholder แล้ว:

- Placeholder ที่ว่างเปล่าสำหรับข้อความ, รูปภาพ, แผนภูมิ หรือเนื้อหาอื่น ๆ มักจะแสดงด้วย [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/).
- Placeholder รูปภาพที่เต็มแล้วสามารถแสดงด้วย [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/).
- Placeholder แผนภูมิที่เต็มแล้วสามารถแสดงด้วย [IChart](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/).
- Placeholder เนื้อหาอาจมีหลายประเภทของเนื้อหา ตรวจสอบทั้ง [IPlaceholder::get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/iplaceholder/get_type/) และอินเทอร์เฟซรูปทรงขณะรันไทม์ แทนการสันนิษฐานว่า placeholder ทุกตัวเป็น [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/iplaceholder/get_type/) บรรยายบทบาทของ placeholder; ไม่ได้รับประกันประเภทของรูปทรงขณะรันไทม์ ควรตรวจสอบประเภทก่อนเข้าถึงสมาชิกที่เฉพาะเจาะจงสำหรับข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่ออื่น ๆ เสมอ
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder มีโครงสร้างแบบลำดับขั้น:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่ใช้ซ้ำและบางครั้งมี placeholder ระดับมาสเตอร์
2. สไลด์เลเอาท์กำหนดการจัดเรียงที่ใช้โดยสไลด์ปกติหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์ได้
3. สไลด์ปกติมี placeholder ของตนเองและสามารถสืบทอดจากเลเอาท์ได้

เรียก [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/getbaseplaceholder/) เพื่อย้ายหนึ่งระดับขึ้นในลำดับขั้นนี้ โดยทั่วไป placeholder ของสไลด์จะคืน placeholder ของเลเอาท์; placeholder ของเลเอาท์อาจคืน placeholder ของมาสเตอร์ เมธอดจะคืน `nullptr` เมื่อรูปทรงไม่มี base placeholder

ตัวอย่างต่อไปนี้แสดงรายการ placeholder บนสไลด์แรกและรายงาน base placeholder ของแต่ละอัน:

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

การแก้ไข placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการกำหนดท้องถิ่นสำหรับสไลด์นั้น การแก้ไขเลเอาท์หรือมาสเตอร์ที่เกี่ยวข้องอาจส่งผลต่อสไลด์ทั้งหมดที่ยังคงสืบทอดการตั้งคินั้น รูปทรงปกติธรรมดาที่เป็นรูปทรงท้องถิ่นไม่มี base placeholder และไม่เริ่มสืบทอดแค่เพราะมันอยู่ในพิกัดเดียวกัน

## **เปลี่ยนข้อความใน Placeholder**

Placeholder สำหรับหัวเรื่อง, centered‑title, subtitle, body, และข้อความทั่วไปมักจะรองรับข้อความ ตรวจสอบว่าเป็น [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ก่อนเรียกเมธอด [get_TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/get_textframe/)

ตัวอย่างนี้อัปเดต placeholder หัวเรื่องแรกบนสไลด์แรกและบันทึกผลลัพธ์:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

รูปแบบนี้หลีกเลี่ยงการ cast placeholder รูปภาพ, แผนภูมิ, ตาราง หรือสื่อเป็น [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) อีกทั้งยังระบุ placeholder ตามจุดประสงค์แทนการพึ่งพาดัชนีรูปทรงที่เปราะบาง

## **กำหนดข้อความ Prompt บน Layout**

Prompt text คือคำแนะนำที่ปรากฏใน placeholder ว่าง เช่น *Click to add title* การกำหนดข้อความ prompt ควรทำบน placeholder ของเลเอาท์แทนการพยายามเข้าถึงผ่านคอลเลกชันรูปทรงของสไลด์ปกติ เข้าถึงเลเอาท์ผ่าน [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islide/get_layoutslide/) แล้ววนลูปผ่าน [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslide/get_shapes/)

ตัวอย่างต่อไปนี้เปลี่ยน prompt ของหัวเรื่องและ subtitle บนเลเอาท์ที่ใช้โดยสไลด์แรก:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

Prompt text ไม่ได้เป็นเนื้อหาของสไลด์ปกติ มันมีไว้สำหรับ placeholder ว่างในแอปพลิเคชันการแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริงแล้ว prompt จะไม่แสดงอีกต่อไป การเปลี่ยน prompt ยังไม่ทำให้ข้อความที่มีอยู่ในสไลด์ที่ใช้เลเอาท์นั้นถูกแทนที่

## **อัปเดต Placeholder รูปภาพ**

มีสองกรณีให้จัดการ:

- หาก placeholder รูปภาพถูกเติมเต็มแล้วและแสดงด้วย [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/), ให้แทนที่รูปภาพผ่าน [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipicturefillformat/get_picture/) และ [ISlidesPicture::set_Image](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidespicture/set_image/)
- หากยังเป็น placeholder ว่าง, ให้เพิ่ม picture frame ที่พิกัดของ placeholder ผ่าน [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addpictureframe/) แล้วลบ placeholder ที่ว่าง

ตัวอย่างต่อไปนี้รองรับทั้งสองกรณีและบันทึกการนำเสนอ:

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

การแทนที่ที่สร้างสำหรับ placeholder ว่างเป็น picture frame แบบท้องถิ่น ไม่ได้สร้าง placeholder ใหม่ เนื่องจาก [IShape::get_Placeholder](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_placeholder/) เป็นแบบอ่านอย่างเดียว มันยังคงตำแหน่งที่สงวนไว้แต่ไม่สืบทอดพฤติกรรมเฉพาะของ placeholder หากต้องการรักษาความสัมพันธ์ของ placeholder ไว้ ควรเตรียมและเติม placeholder ใน PowerPoint ก่อน แล้วอัปเดต [IPictureFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับความโปร่งแสงของภาพ, การครอบและเอฟเฟกต์อื่น ๆ ที่เกี่ยวกับรูปภาพ ดูบทความ [Manage Picture Frames](/slides/th/cpp/picture-frame/) การดำเนินการเหล่านี้เป็นของ picture frame หรือ picture fill ไม่ใช่ของเมตาดาต้า placeholder

## **ทำงานกับ Placeholder แผนภูมิและเนื้อหา**

Placeholder แผนภูมิที่เต็มแล้วสามารถแสดงด้วย [IChart](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/) ตัวอย่างนี้ค้นหาแผนภูมินั้นโดยอ้างอิงทั้งประเภท placeholder และอินเทอร์เฟซขณะรันไทม์, แก้ไขหัวเรื่อง แล้วบันทึกไฟล์:

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

Placeholder เนื้อหาโดยทั่วไปมักมี [PlaceholderType::Object](https://reference.aspose.com/slides/th/cpp/aspose.slides/placeholdertype/) ใน PowerPoint ทำหน้าที่เป็นตัวเปิดหลายประเภทเนื้อหา ได้แก่ แผนภูมิ, ตาราง, แผนผัง, รูปภาพและสื่อ หลังจากถูกเติมเต็มแล้ว ให้ตรวจสอบอินเทอร์เฟซรูปทรงจริงเพื่อรู้ว่ามีอะไรอยู่ Layout เฉพาะบางอย่างอาจเปิดเผย [PlaceholderType::Chart](https://reference.aspose.com/slides/th/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/th/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/th/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/th/cpp/aspose.slides/placeholdertype/), หรือ [PlaceholderType::Diagram](https://reference.aspose.com/slides/th/cpp/aspose.slides/placeholdertype/)

Aspose.Slides ไม่ได้แปลง placeholder [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ที่ว่างให้เป็น [IChart](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/) เพียงเปลี่ยน [IPlaceholder::get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/iplaceholder/get_type/) เพราะประเภทเป็นแบบอ่านอย่างเดียว เพื่อเติมแผนภูมิหรือพื้นที่เนื้อหาแบบว่างโดยโปรแกรม ให้เพิ่มอ็อบเจ็กต์ที่พิกัดของ placeholder แล้วลบ placeholder ที่ว่าง ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับแผนภูมิ:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

แผนภูมิที่เพิ่มเข้ามาเป็นแผนภูมิท้องถิ่นทั่วไป มันครอบพื้นที่ของ placeholder แต่ไม่สืบทอดจาก placeholder ของเลเอาท์ ใช้บทความการจัดการแผนภูมิ [chart management articles](/slides/th/cpp/powerpoint-charts/) เมื่อคุณต้องการแทนที่ประเภท, ซีรีส์ หรือข้อมูลในเวิร์กบุ๊กของแผนภูมิ

## **ตัวอย่างครบวงจร: อัปเดตข้อความหรือรูปภาพเนื้อหา**

ตัวอย่างต่อไปนี้เป็นขั้นตอนเต็มที่เปิดเทมเพลต, ค้นหาสไลด์แรกสำหรับ placeholder ที่เป็นหัวเรื่องหรือรูปภาพ, ตรวจสอบประเภท placeholder และรูปทรง, อัปเดตเนื้อหาที่เหมาะสม, แล้วบันทึกผลลัพธ์ ตัวอย่างนี้หลีกเลี่ยงการสันนิษฐานดัชนีรูปทรงหรือการ cast placeholder ทุกตัวไปยังอินเทอร์เฟซเดียวกัน:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Base placeholder คืออะไร?**

Base placeholder คือรูปทรงที่สอดคล้องบนเลเอาท์หรือมาสเตอร์ซึ่ง placeholder อื่นสืบทอดจากมัน ใช้ [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/getbaseplaceholder/) เพื่อดึงค่า รูปทรงท้องถิ่นทั่วไปจะคืน `nullptr` เพราะไม่ได้เป็นส่วนของลำดับขั้น placeholder

**ฉันสามารถเปลี่ยนหัวเรื่องทั้งหมดของสไลด์โดยแก้ไข placeholder ของเลเอาท์ได้หรือไม่?**

คุณสามารถเปลี่ยนการจัดรูปแบบหรือข้อความ prompt ที่สืบทอดผ่านเลเอาท์ได้ แต่เนื้อหาหัวเรื่องที่มีอยู่ถูกเก็บไว้บนสไลด์ปกติ เพื่อเปลี่ยนข้อความหัวเรื่องจริงทั่วทั้งงานนำเสนอให้วนลูปผ่านสไลด์และอัปเดตแต่ละ placeholder ของหัวเรื่อง

**ฉันจะจัดการ placeholder ของวันที่, เลขสไลด์, ส่วนหัวและส่วนท้ายอย่างไร?**

ใช้ตัวจัดการส่วนหัวและส่วนท้ายในระดับสไลด์, เลเอาท์, มาสเตอร์, โน้ต หรือแบบแจกจ่าย ดูบทความ [Manage Presentation Header and Footer](/slides/th/cpp/presentation-header-and-footer/) สำหรับตัวอย่างเต็มรูปแบบ