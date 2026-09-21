---
title: จัดการฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย C++
linktitle: ฟิลด์ข้อความ
type: docs
weight: 52
url: /th/cpp/text-fields/
keywords:
- ฟิลด์ข้อความ
- ข้อความอัตโนมัติ
- หมายเลขสไลด์
- วันและเวลา
- ส่วนหัว
- ส่วนล่าง
- ส่วนข้อความ
- PowerPoint
- PPT
- PPTX
- C++
- Aspose.Slides
description: "สร้าง, ตรวจสอบ, แก้ไข, และลบฟิลด์ข้อความในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ C++. รักษาการจัดรูปแบบและตรวจสอบไฟล์ PPTX และ PPT ที่บันทึกไว้."
---
## **ภาพรวม**

ย่อหน้าข้อความประกอบด้วยส่วนย่อย ส่วนปกติ [IPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/) มีข้อความตามตัวอักษร; ส่วนฟิลด์ยังมี [IField](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifield/) ที่ประเภทบ่งบอกค่าที่อัปเดตโดยอัตโนมัติ เช่น หมายเลขสไลด์หรือวันที่ ส่วนย่อยสองส่วนอาจแสดงอักขระเดียวกันในขณะที่มีเพียงส่วนเดียวที่มีฟิลด์

ใช้ [IPortion::get_Field](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/get_field/) เพื่อแยกแยะ: มันจะคืนค่า `nullptr` สำหรับข้อความปกติ. [IPortion::AddField](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/addfield/) แปลงส่วนที่มีอยู่ให้เป็นฟิลด์. เก็บป้ายกำกับและค่าที่เปลี่ยนแปลงอย่างไดนามิกในส่วนแยกต่างหากเพื่อให้การแปลงค่าจะไม่ทับป้ายกำกับด้วย

คู่มือนี้ครอบคลุมฟิลด์ภายในข้อความ, การจัดรูปแบบของมัน, และการบันทึกเป็น PPTX และ PPT. สำหรับกรอบข้อความและย่อหน้า, ดูที่ [Manage Text](/slides/th/cpp/manage-text/).

## **สร้างฟิลด์หมายเลขสไลด์**

ตัวอย่างต่อไปนี้สร้างกล่องข้อความที่มีป้ายกำกับ `Slide ` แบบตามตัวอักษรตามด้วยหมายเลขที่อัปเดตโดยอัตโนมัติ. มันกำหนดขนาด น้ำหนัก และสีของหมายเลขก่อนเพิ่มฟิลด์, แล้วเปิดการนำเสนอที่บันทึกไว้ใหม่และตรวจสอบประเภทฟิลด์, ข้อความ, และการจัดรูปแบบ. ไม่จำเป็นต้องใช้ไฟล์อินพุต.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

การนำเสนอใหม่เริ่มที่หมายเลขสไลด์ 1, ดังนั้นข้อความที่คาดว่าจะเป็น `Slide 1`และการตรวจสอบทั้งสองควรพิมพ์ `True`. หมายเลขยังคงเป็นฟิลด์หลังจากเปิดใหม่; มันไม่ใช่ข้อความตามตัวอักษร `1`. การแคสต์และดัชนีในการตรวจสอบอ้างอิงถึงรูปร่างและส่วนที่สร้างโดยตัวอย่างนี้.

## **เลือกประเภทฟิลด์**

[FieldType](https://reference.aspose.com/slides/th/cpp/aspose.slides/fieldtype/) ทำงานร่วมกับ [IFieldType](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifieldtype/) และให้ค่าที่กำหนดไว้ล่วงหน้าต่อไปนี้. ส่งค่าที่เหมาะสมไปยัง [AddField](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/addfield/).

| ตัวเข้าถึง | วัตถุประสงค์ |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/th/cpp/aspose.slides/fieldtype/get_slidenumber/) | หมายเลขสไลด์ปัจจุบัน |
| [get_DateTime](https://reference.aspose.com/slides/th/cpp/aspose.slides/fieldtype/get_datetime/) | วัน/เวลาในรูปแบบค่าเริ่มต้นของแอปพลิเคชันที่เรนเดอร์ |
| [get_DateTime1](https://reference.aspose.com/slides/th/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/th/cpp/aspose.slides/fieldtype/get_datetime9/) | รูปแบบวันที่ที่กำหนดไว้ล่วงหน้าหรือรูปแบบวันที่/เวลาผสม |
| [get_DateTime10](https://reference.aspose.com/slides/th/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/th/cpp/aspose.slides/fieldtype/get_datetime13/) | รูปแบบเวลาที่กำหนดไว้ล่วงหน้า, มีตัวเลือกสำหรับวินาทีและนาฬิกา 12 ชั่วโมง |
| [get_Header](https://reference.aspose.com/slides/th/cpp/aspose.slides/fieldtype/get_header/) | ฟิลด์ส่วนหัว; ดูข้อจำกัดของตัวแทนและรูปแบบด้านล่าง |
| [get_Footer](https://reference.aspose.com/slides/th/cpp/aspose.slides/fieldtype/get_footer/) | ฟิลด์ส่วนล่าง |

ตัวอย่างเช่น, [get_DateTime3](https://reference.aspose.com/slides/th/cpp/aspose.slides/fieldtype/get_datetime3/) ให้วัน, ชื่อเดือนเต็ม, และปีเป็นภาษาอังกฤษ. นี่เป็นรูปแบบฟิลด์ที่กำหนดไว้ล่วงหน้า, ไม่ใช่สตริงฟอร์แมตวันที่แบบใดก็ได้. ภาษาของส่วนที่ตั้งค่าโดย [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_languageid/), และแอปพลิเคชันที่ประมวลผลการนำเสนอ สามารถมีผลต่อผลลัพธ์ที่แสดง

## **สร้างฟิลด์จากสตริงภายใน**

โอเวอร์โหลดแบบสตริงของ [AddField](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/addfield/) ยอมรับตัวระบุฟิลด์ภายใน. ใช้เมื่อรักษาตัวระบุที่มาจากแอปพลิเคชันอื่นที่ไม่มีค่าที่กำหนดไว้ล่วงหน้า. คุณสามารถสร้าง [FieldType](https://reference.aspose.com/slides/th/cpp/aspose.slides/fieldtype/fieldtype/) จากตัวระบุได้. [IFieldType::get_InternalString](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifieldtype/get_internalstring/) เปิดเผยตัวระบุนั้นเพื่อการตรวจสอบ.

ตัวอย่างนี้เก็บฟิลด์ `custom-report-id` ที่เฉพาะสำหรับแอปพลิเคชันพร้อมข้อความสำรอง `Report-042`. ไม่จำเป็นต้องใช้ไฟล์อินพุต. ตัวระไม่ได้ลงทะเบียนการคำนวณ: Aspose.Slides ไม่สร้าง ID รายงานสำหรับประเภทที่ไม่รู้จัก. แอปพลิเคชันที่เข้าใจตัวระบุต้องให้ความหมายและอัปเดตค่าของมัน.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

หลังจากการเดินทางรอบ PPTX นี้, ประเภทที่คาดว่าจะเป็น `custom-report-id` และข้อความที่คาดว่าจะเป็น `Report-042`. การส่งสตริงเช่น `yyyy-MM-dd` จะตั้งชื่อประเภทฟิลด์; มันจะไม่กำหนดรูปแบบวันที่ที่กำหนดเอง. สำหรับวันที่ที่คงที่ในรูปแบบใดก็ได้, ใช้ข้อความปกติ.

## **ตรวจสอบ, แก้ไข, และลบฟิลด์วันที่/เวลา**

อ่านประเภทฟิลด์ที่มีอยู่ผ่าน [IField::get_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifield/get_type/) และเปลี่ยนผ่าน [IField::set_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/ifield/set_type/). ตรวจสอบว่าฟิลด์มีอยู่ก่อนเข้าถึงประเภทของมัน. เพื่อหยุดการอัปเดตอัตโนมัติ, เรียก [IPortion::RemoveField](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/removefield/). การกระทำนี้เก็บส่วนและข้อความปัจจุบันไว้ขณะลบการเชื่อมโยงฟิลด์. หากต้องการค่าคงที่เฉพาะ, กำหนดข้อความนั้นหลังจากลบฟิลด์.

สำหรับการตั้งค่า API ที่เกี่ยวข้องกับการประมวลผลฟิลด์วันที่/เวลา, ดูที่ [Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/set_currentdatetime/). ตัวอย่างด้านล่างใช้วันที่อนุมัติที่ระบุอย่างชัดเจนเมื่อแปลงฟิลด์เป็นข้อความปกติ.

ดาวน์โหลด [sample.pptx](sample.pptx) และวางไว้ในไดเรกทอรีทำงาน. ไฟล์นี้มีรูปร่างข้อความที่มีชื่อสองอัน, `UpdatedAt` และ `ApprovedDate`, แต่ละอันมีฟิลด์วันที่/เวลา, พร้อมป้ายกำกับข้อความปกติ. ตัวอย่างต่อไปนี้เดินผ่านรูปร่างข้อความระดับบนในสไลด์ปกติ. มันเปลี่ยนฟิลด์วันที่/เวลาเป็นรูปแบบวันที่เต็มและทำให้เป็นตัวเอียง, พร้อมคงรูปแบบอื่นไว้. ฟิลด์ใน `ApprovedDate` เท่านั้นที่กลายเป็นข้อความคงที่.

ตัวอย่างนี้รับรู้ตัวระบุภายในที่สร้างมาแล้ว `datetime` และ `datetime1` ถึง `datetime13`. กลุ่ม, ตาราง, โน้ต, เลย์เอาต์, และมาสเตอร์ต้องการการเดินทางผ่านคอนเทนเนอร์ข้อความของตนเองและอยู่นอกขอบเขตของตัวอย่างนี้.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

หลังจากเปิดใหม่, `UpdatedAt` ควรมีประเภท `datetime3` และยังคงเป็นแบบไดนามิก. `ApprovedDate` ควรไม่มีฟิลด์และมีข้อความ `05 April 2030`. ทั้งสองส่วนวันที่เป็นตัวเอียง, และขนาดฟอนต์, การตั้งค่าหนังสือหนา, สีต้นฉบับยังคงอยู่. ป้ายกำกับข้อความปกติไม่ได้เปลี่ยนแปลง. การตรวจสอบอ่านส่วนแรกของสองรูปร่างที่รู้จักในตัวอย่างที่ให้มา.

## **คงรูปแบบข้อความ**

ทำงานกับส่วนที่มีอยู่เมื่อต้องเพิ่มฟิลด์, เปลี่ยนประเภท, หรือเอาออก. การดำเนินการเหล่านี้คงรูปแบบของส่วนนั้นไว้. ใช้ [IPortion::get_PortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/get_portionformat/) เพื่อเปลี่ยนเฉพาะคุณสมบัติต้องการ, เช่นตัวอย่างที่ทำสำหรับสีหรือการเอียง.

หลีกเลี่ยงการสร้างกรอบข้อความทั้งหมดใหม่เพียงเพื่ออัปเดตฟิลด์เดียว: การทำเช่นนั้นอาจทำให้สูญเสียขอบเขตส่วนต้นฉบับและรูปแบบแยกของมัน. นอกจากนี้ควรแยกแยะรูปแบบที่ตั้งค่าโดยเจตนาจากรูปแบบที่สืบทอดมาจากย่อหน้า, เลย์เอาต์, หรือธีม. ดูที่ [Text Formatting](/slides/th/cpp/text-formatting/) สำหรับตัวเลือกการจัดรูปแบบที่กว้างขึ้น.

## **ฟิลด์และตัวแทนส่วนหัว/ส่วนล่าง**

ฟิลด์เป็นส่วนหนึ่งของส่วนข้อความ. ตัวแทนคือรูปร่างที่มีบทบาทในงานนำเสนอ, เช่น ส่วนล่างหรือหมายเลขสไลด์. การเพิ่มฟิลด์ลงในกล่องข้อความปกติไม่ได้ทำให้รูปร่างนั้นกลายเป็นตัวแทน.

ผู้จัดการส่วนหัว/ส่วนล่างควบคุมข้อความตัวแทนและการมองเห็นบนสไลด์, เลย์เอาต์, และมาสเตอร์, รวมถึงการกระจายไปยังสไลด์ที่พึ่งพา. ฟิลด์ตัวเลขในกล่องข้อความกำหนดเองจึงอาจเป็นประโยชน์แม้ไม่ได้ใช้ตัวแทนหมายเลขสไลด์. ในทางตรงกันข้าม, การเปลี่ยนการมองเห็นของตัวแทนจะไม่ลบฟิลด์จากกล่องข้อความที่ไม่เกี่ยวข้อง.

ประเภทส่วนหัวและส่วนล่างที่กำหนดไว้ล่วงหน้าไม่ได้สร้างตัวแทนที่สอดคล้องกันหรือจัดหาเนื้อหาให้. โดยเฉพาะ, สไลด์ PowerPoint ปกติไม่มีตัวแทนส่วนหัว; ส่วนหัวเป็นของหน้าบันทึกและเอกสารแจก. อย่าสันนิษฐานว่าฟิลด์ส่วนหัวหรือส่วนล่างในรูปร่างใด ๆ จะได้รับข้อความที่กำหนดผ่านผู้จัดการตัวแทนโดยอัตโนมัติ. สำหรับกระบวนการทำงานนั้น, ดูที่ [Presentation Headers and Footers](/slides/th/cpp/presentation-header-and-footer/).

## **ข้อจำกัดของ PPTX และ PPT**

ตรวจสอบทั้งประเภทฟิลด์และข้อความที่ได้หลังจากบันทึกและเปิดใหม่. การคงตัวระบุไม่พิสูจน์ว่าแอปพลิเคชันสามารถคำนวณหรือแสดงค่าของมันได้.

| รูปแบบ | พฤติกรรมของฟิลด์และข้อจำกัด |
|---|---|
| PPTX | จัดเก็บตัวระบุฟิลด์ภายในพร้อมกับข้อความฟิลด์. ใช้ตัวอย่างด้านบนเพื่อเช็คประเภทที่กำหนดไว้ล่วงหน้าและตัวระบุแบบกำหนดเองหลังจากบันทึกและเปิดใหม่. ประเภทกำหนดเองที่ไม่รู้จักจะไม่ได้รับตรรกะการคำนวณอัตโนมัติ. แอปพลิเคชันอื่นอาจจัดการตัวระบุที่ไม่รองรับอย่างแตกต่าง. |
| PPT | ใช้การแสดงฟิลด์แบบเก่าและมีความเข้ากันได้จำกัดกว่า. ฟิลด์หมายเลขสไลด์และฟิลด์วันที่/เวลาที่กำหนดไว้ล่วงหน้ามีการแสดงแบบเก่า. ฟิลด์กำหนดเองที่ไม่รองรับหรือฟิลด์ส่วนหัวในกล่องข้อความสไลด์ปกติอาจแสดง `*` เป็นข้อความ. อย่าพึ่งพาฟิลด์กำหนดเองหรือบริบทฟิลด์ที่ไม่รองรับในการคงข้อความที่มองเห็นได้. |

สำหรับผลลัพธ์ที่พกพาและคงที่, แปลงฟิลด์ที่ไม่รองรับเป็นข้อความปกติและกำหนดค่าที่ต้องการอย่างชัดเจนก่อนบันทึก. วิธีนี้คงข้อความที่เลือกไว้แต่หยุดการอัปเดตอัตโนมัติโดยเจตนา. ตรวจสอบแอปพลิเคชันเป้าหมายด้วยเมื่อการคำนวณฟิลด์ของมันเป็นส่วนหนึ่งของกระบวนการทำงานของคุณ.

## **คำถามที่พบบ่อย**

**How can I tell whether a displayed number or date is a field?**  
ตรวจสอบ [IPortion::get_Field](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/get_field/). ค่าที่ไม่เป็น null ระบุว่เป็นฟิลด์; ข้อความที่แสดงเพียงอย่างเดียวไม่สามารถบอกได้.

**Does removing a field remove its text or formatting?**  
ไม่. [RemoveField](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/removefield/) แปลงส่วนที่มีอยู่เป็นข้อความปกติ. กำหนดค่าที่ชัดเจนหลังจากนั้นหากต้องการวันที่หรือค่าสำรองที่คงที่เฉพาะ.

**Can an internal string define a new date format or formula?**  
ไม่. มันระบุประเภทฟิลด์. ตัวระบุที่ไม่รู้จักไม่ให้ตัวประเมินหรือรูปแบบวันที่. ใช้ประเภทที่กำหนดไว้ล่วงหน้าที่สนับสนุนหรือจัดรูปแบบค่าด้วยตนเองเป็นข้อความปกติ.

**Why check a presentation again after saving it?**  
เพราะตัวระบุฟิลด์, ข้อความที่คำนวณ, และการจัดรูปแบบเป็นสิ่งที่แตกต่างกันต้องตรวจสอบ. การแปลงรูปแบบอาจทำให้ผลลัพธ์ที่มองเห็นเปลี่ยนแปลงได้แม้ว่าตัวระบุฟิลด์ยังคงอยู่.