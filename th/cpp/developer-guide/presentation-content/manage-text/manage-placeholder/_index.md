---
title: จัดการ Placeholder การนำเสนอใน C++
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/cpp/manage-placeholder/
keywords:
- ตัวเก็บตำแหน่ง
- ตัวเก็บตำแหน่งข้อความ
- ตัวเก็บตำแหน่งภาพ
- ตัวเก็บตำแหน่งแผนภูมิ
- ตัวเก็บตำแหน่งเนื้อหา
- ข้อความแจ้งเตือน
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีตรวจสอบและแก้ไข placeholder สำหรับข้อความ, รูปภาพ, แผนภูมิและเนื้อหา รวมถึงทำความเข้าใจการสืบทอดของ placeholder ด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Placeholder คือรูปร่างที่สำรองตำแหน่งสำหรับประเภทของเนื้อหาเฉพาะในแม่แบบการนำเสนอ ตัวอย่างทั่วไปได้แก่ title, body, picture, chart และ placeholder เนื้อหาทั่วไป ไม่เหมือนรูปร่างธรรมดา placeholder สามารถสืบทอดตำแหน่ง, ขนาด, การจัดรูปแบบ และการตั้งค่าอื่น ๆ จากสไลด์เลเอาต์หรือสไลด์มาสเตอร์ได้

Aspose.Slides เปิดเผยข้อมูล placeholder ผ่านเมธอด [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) เมธอดจะคืนค่าอ็อบเจ็กต์ [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) หรือ `nullptr` สำหรับรูปร่างปกติ ใช้ [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) เพื่อกำหนดว่าตัว placeholder มีจุดประสงค์จะบรรจุอะไร

อินเทอร์เฟซของรูปร่างยังคงมีความสำคัญหลังจากคุณทราบประเภทของ placeholder:

- Placeholder ที่ว่างเปล่า (ข้อความ, รูปภาพ, แผนภูมิ หรือเนื้อหา) มักจะแทนด้วย [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
- Placeholder รูปภาพที่มีเนื้อหาแล้วสามารถแทนด้วย [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/).
- Placeholder แผนภูมิที่มีเนื้อหาแล้วสามารถแทนด้วย [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/).
- Placeholder เนื้อหาอาจบรรจุประเภทหลายอย่าง ตรวจสอบทั้ง [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) และอินเทอร์เฟซรูปร่างขณะรันไทม์ แทนที่จะสันนิษฐานว่า placeholder ทุกตัวเป็น [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) บรรยายบทบาทของ placeholder; แต่ไม่ได้รับประกันประเภทของรูปร่างขณะรันไทม์ ควรตรวจสอบประเภทก่อนเข้าถึงสมาชิกของข้อความ, รูปภาพ, แผนภูมิ, ตาราง หรือสื่ออื่น ๆ เสมอ
{{% /alert %}}

## **ทำความเข้าใจการสืบทอด Placeholder**

Placeholder สร้างเป็นลำดับขั้น:

1. สไลด์มาสเตอร์กำหนดสไตล์ที่นำกลับมาใช้ใหม่และบางครั้งกำหนด placeholder ระดับมาสเตอร์
2. สไลด์เลเอาต์กำหนดการจัดเรียงที่ใช้โดยสไลด์ปกติหนึ่งหรือหลายสไลด์และสามารถสืบทอดจากมาสเตอร์ได้
3. สไลด์ปกติมี placeholder ของสไลด์นั้นและสามารถสืบทอดจากเลเอาต์ของมันได้

เรียกใช้ [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) เพื่อย้ายหนึ่งระดับขึ้นในลำดับขั้นนี้ สไลด์ placeholder จะคืนค่า placeholder ของเลเอาต์; placeholder ของเลเอาต์อาจคืนค่า placeholder ของมาสเตอร์ เมธอดจะคืนค่า `nullptr` เมื่อรูปร่างไม่มี base placeholder

ตัวอย่างต่อไปนี้แสดงรายการ placeholder บนสไลด์แรกและรายงาน base placeholder ของพวกมัน:

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

การแก้ไข placeholder บนสไลด์ปกติจะสร้างหรือเปลี่ยนการแทนที่แบบโลคัลสำหรับสไลด์นั้น การแก้ไขเลเอาต์หรือมาสเตอร์ที่เกี่ยวข้องอาจส่งผลต่อสไลด์ทั้งหมดที่ยังสืบทอดการตั้งคินั้น รูปร่างธรรมดาแบบโลคัลไม่มี base placeholder และจะไม่เริ่มสืบทอดเพียงเพราะอยู่ในพิกัดเดียวกัน

## **ลบสถานะ Placeholder**

เมื่อต้องปรับเทมเพลต ให้ใช้ [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) เพื่อเก็บอ็อบเจ็กต์ที่มีอยู่เป็นรูปร่างธรรมดาเมธอด [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) จะคืนค่า `nullptr` แต่รูปร่างยังคงอยู่ในคอลเลกชันของสไลด์ ตรงกันข้าม [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) จะลบรูปร่างนั้นออกจากคอลเลกชัน

ตัวอย่างต่อไปนี้ต้องใช้ไฟล์ `template.pptx` ที่มีอย่างน้อยหนึ่งสไลด์และ placeholder ข้อความที่ไม่ว่างเปล่าในสไลด์แรก ใช้ placeholder ที่สืบทอดการจัดรูปแบบจากเลเอาต์หรือมาสเตอร์เพื่อดูผลของการลบความสัมพันธ์ ตัวอย่างตรวจสอบว่ารูปร่างเดียวกันยังคงอยู่ แล้วเรียกเมธอดอีกครั้งบนรูปร่างที่กลายเป็นธรรมดาและบันทึกผลลัพธ์

{{% alert color="warning" title="Warning" %}}
การลบสถานะ placeholder ไม่ได้รักษาการตั้งค่าการแสดงผลที่สืบทอดโดยอัตโนมัติ ตัวอย่างด้านล่างตั้งใจให้การตั้งค่าเหล่านั้นคงอยู่ ดังนั้นผลลัพธ์อาจดูต่างออกไป รูปร่างที่ตำแหน่งและขนาดสืบทอดมาทั้งหมดอาจมีพิกัดและขนาดเป็นศูนย์หลังการเรียกและกลายเป็นไม่มองเห็นได้ แม้ว่ายังอยู่ในคอลเลกชัน
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // การเรียกเมธอดบนรูปร่างปกติจะไม่มีผล.
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

สำหรับ placeholder ที่ตรงกัน การตรวจสอบทั้งสามข้อจะพิมพ์ `True` ข้อความยังคงอยู่ แต่ตำแหน่ง, ขนาด, การหมุน, ฟอนต์, การจัดย่อหน้า, ระยะขอบของ text‑frame, การยึดแนวตั้ง, การเติมสี และการตั้งค่าเส้นอาจเปลี่ยนเมื่อความสัมพันธ์ของ placeholder ถูกลบ ตัวอย่างเช่น การจัดรูปแบบหัวข้อที่สืบทอดอาจกลับไปใช้การจัดรูปแบบข้อความปกติ ดูเพิ่มเติมที่ [เค้าโครงสไลด์](/slides/th/cpp/slide-layout/) เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับเลเอาต์

เพื่อรักษาลักษณะที่ตั้งใจไว้ ให้บันทึกตำแหน่ง, ขนาด, และการหมุนที่แก้ไขแล้วก่อนเรียกเมธอด แล้วคัดลอกค่าการจัดรูปแบบที่มีผลจริงไปยังตัวแปรแยกต่างหาก ดึงค่าดังกล่าวผ่าน [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/), [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/), [IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/), และ [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/). อย่าอาศัยอ็อบเจ็กต์ effective‑format เพียงอย่างเดียว เพราะค่าการจัดรูปแบบข้อความของมันอาจเปลี่ยนหลังจากความสัมพันธ์ถูกลบ ให้ใช้ค่าที่บันทึกไว้กำหนดให้รูปร่างธรรมดาโดยชัดเจนหลังจากนั้น รวมถึงฟอนต์, ขนาด, สไตล์, สี, การตั้งค่าการจัดย่อหน้า, การตั้งค่า text‑frame, การเติมสี, และเส้นที่ใช้ในเทมเพลตของคุณ

รูปทร้างของรูปร่างที่สืบทอดอาจต้องกำหนดอย่างชัดเจนผ่าน [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/). สำหรับ placeholder ข้อความสี่เหลี่ยมจัตุรัสหมายถึงการกำหนด [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/); การคืนค่าเพียงการเติมสีและเส้นอาจไม่ทำให้สี่เหลี่ยมที่มองเห็นกลับมาเท่าเดิม เทมเพลตที่มีเอฟเฟกต์เพิ่มเติมหรือการจัดรูปแบบซับซ้อนต้องจัดการการตั้งค่าเหล่านั้นด้วย

## **เปลี่ยนข้อความใน Placeholder**

Title, centered‑title, subtitle, body, และ placeholder ข้อความมักสนับสนุนข้อความ ตรวจสอบว่ารูปร่างเป็น [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ก่อนใช้เมธอด [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/)

ตัวอย่างต่อไปนี้อัปเดต placeholder title แรกในสไลด์แรกและบันทึกผลลัพธ์:

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

รูปแบบนี้หลีกเลี่ยงการแคสต์ placeholder รูปภาพ, แผนภูมิ, ตาราง หรือสื่อเป็น [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). นอกจากนี้ยังระบุ placeholder ตามวัตถุประสงค์แทนการพึ่งพาดัชนีรูปร่างที่เปราะบาง

## **กำหนดข้อความ Prompt บน Layout**

Prompt text คือข้อความแนะนำในขั้นตอนออกแบบที่แสดงใน placeholder ว่าง เช่น *Click to add title* ให้กำหนดข้อความ prompt แบบกำหนดเองบน placeholder ของเลเอาต์แทนการพยายามเข้าถึงผ่านคอลเลกชันรูปร่างของสไลด์ปกติ เข้าถึงเลเอาต์ผ่าน [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) และวนลูปผ่าน [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/)

ตัวอย่างต่อไปนี้เปลี่ยน prompt ของ title และ subtitle บนเลเอาต์ที่ใช้โดยสไลด์แรก:

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

Prompt text ไม่ใช่เนื้อหาสไลด์ปกติ มุ่งหมายสำหรับ placeholder ว่างในแอปพลิเคชันการแก้ไขเช่น PowerPoint เมื่อผู้ใช้หรือโปรแกรมใส่เนื้อหาจริงแล้ว prompt จะไม่แสดงอีกแล้ว การเปลี่ยน prompt ก็ไม่แทนที่ข้อความที่มีอยู่บนสไลด์ที่ใช้เลเอาต์นั้น

## **อัปเดต Picture Placeholder**

มีสองกรณีที่ต้องจัดการ:

- หาก picture placeholder มีเนื้อหาแล้วและเป็น [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/), แทนที่ภาพผ่าน [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) และ [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/)
- หากยังเป็น placeholder ว่าง ให้เพิ่ม picture frame ที่พิกัดของ placeholder ด้วย [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) แล้วลบ placeholder ที่ว่างออก

ตัวอย่างต่อไปนี้สนับสนุนทั้งสองกรณีและบันทึกการนำเสนอ:

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

การแทนที่ที่สร้างขึ้นสำหรับ placeholder ว่างเป็น picture frame แบบโลคัล ไม่ใช่ placeholder ใหม่ เพราะ [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) เป็นแบบอ่าน‑อย่างเท่านั้น มันยังคงตำแหน่งที่สำรองไว้แต่ไม่สืบทอดพฤติกรรมของ placeholder หากต้องการรักษาความสัมพันธ์ของ placeholder เป็นสิ่งสำคัญ ให้เตรียมและเติม placeholder ใน PowerPoint ก่อน แล้วอัปเดต [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) ที่ได้ด้วย Aspose.Slides

สำหรับความโปร่งใสของภาพ, การครอป, และเอฟเฟกต์อื่น ๆ ของ picture โปรดดูที่ [จัดการกรอบรูปภาพ](/slides/th/cpp/picture-frame/). การดำเนินการเหล่านั้นเป็นของ picture frame หรือ picture fill ไม่ใช่เมตาดาต้า placeholder

## **ทำงานกับ Chart และ Content Placeholder**

Chart placeholder ที่มีเนื้อหาแล้วสามารถแทนด้วย [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/). ตัวอย่างต่อไปนี้ค้นหา chart ดังกล่าวโดยใช้ประเภท placeholder และอินเทอร์เฟซขณะรันไทม์, แก้ไขชื่อเรื่อง, แล้วบันทึกไฟล์:

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

Content placeholder ทั่วไปมักมี [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/). ใน PowerPoint มันทำหน้าที่เป็นตัวเรียกหลายประเภทของเนื้อหา รวมถึง chart, ตาราง, ไดอะแกรม, รูปภาพ, และสื่อ หลังจากถูกเติมแล้ว ให้ตรวจสอบอินเทอร์เฟซรูปร่างจริงเพื่อทราบว่าเก็บอะไรไว้ เลเอาต์เฉพาะอาจเปิดเผย [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/), หรือ [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)

Aspose.Slides ไม่ได้แปลง placeholder [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ที่ว่างให้เป็น [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) เพียงเปลี่ยน [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/); ประเภทนั้นอ่าน‑อย่างเท่านั้น เพื่อเติม chart หรือพื้นที่เนื้อหาที่ว่างโดยโปรแกรม ให้เพิ่มอ็อบเจ็กต์ที่ต้องการที่พิกัดของ placeholder แล้วลบ placeholder ที่ว่างออก ตัวอย่างต่อไปนี้ทำเช่นนั้นสำหรับ chart:

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

Chart ที่เพิ่มเข้ามาจะเป็น chart โลคัลทั่วไป มันครอบพื้นที่ของ placeholder แต่ไม่สืบทอดจาก placeholder ของเลเอาต์ ใช้บทความการจัดการ chart เฉพาะ ([chart management articles](/slides/th/cpp/powerpoint-charts/)) เมื่อคุณต้องการแทนที่หมวดหมู่, series, หรือข้อมูล workbook ของมัน

## **ตัวอย่างสมบูรณ์: อัปเดตข้อความหรือรูปภาพ**

ตัวอย่างต่อไปนี้เป็นการทำงานแบบ end‑to‑end เพื่อเปิดเทมเพลต, ค้นหาสไลด์แรกสำหรับ placeholder ของ title หรือ picture, ตรวจสอบประเภท placeholder และรูปร่าง, อัปเดตเนื้อหาที่เหมาะสม, แล้วบันทึกผลลัพธ์ ตัวอย่างตั้งใจหลีกเลี่ยงการสันนิษฐานดัชนีรูปร่างหรือการแคสต์ทุก placeholder ไปยังอินเทอร์เฟซเดียวกัน

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

**Placeholder ฐานคืออะไร?**

Placeholder ฐานคือรูปร่างที่สอดคล้องบนเลเอาต์หรือมาสเตอร์ซึ่ง placeholder อื่นสืบทอดมา ใช้ [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) เพื่อดึงมัน รูปร่างโลคัลธรรมดาจะคืนค่า `nullptr` เนื่องจากไม่ได้เป็นส่วนหนึ่งของลำดับขั้น placeholder

**ฉันสามารถเปลี่ยนหัวข้อทั้งหมดของสไลด์โดยแก้ไข placeholder ของเลเอาต์ได้หรือไม่?**

คุณสามารถเปลี่ยนการจัดรูปแบบที่สืบทอดหรืข้อความ prompt ผ่านเลเอาต์ได้ แต่เนื้อหาหัวข้อที่มีอยู่จะถูกเก็บไว้บนสไลด์ปกติ เพื่อเปลี่ยนข้อความหัวข้อจริง ๆ ในการนำเสนอทั้งหมด จำเป็นต้องวนลูปสไลด์และอัปเดตแต่ละ placeholder ของหัวข้อ

**ฉันจะจัดการ placeholder ของวันที่, หมายเลขสไลด์, ส่วนหัว, และส่วนท้ายอย่างไร?**

ใช้ผู้จัดการส่วนหัวและส่วนท้ายในขอบเขตของสไลด์, เลเออต์, มาสเตอร์, โน้ต, หรือแจกจ่าย ดูที่ [Manage Presentation Header and Footer](/slides/th/cpp/presentation-header-and-footer/) เพื่อดูตัวอย่างเต็มรูปแบบ