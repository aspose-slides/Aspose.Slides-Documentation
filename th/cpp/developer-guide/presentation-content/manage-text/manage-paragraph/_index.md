---
title: จัดการย่อหน้าข้อความ PowerPoint ด้วย C++
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการหัวข้อจุด
- เยื้องย่อหน้า
- เยื้องแขวน
- หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อจุด
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและกำหนดรูปแบบย่อหน้า, ส่วนข้อความ, จุดหัวข้อ, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และรูปภาพย่อหน้าด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides for C++ แสดงข้อความเป็นลำดับชั้นของกรอบข้อความ, ย่อหน้า, และส่วนข้อความ:

* [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) แสดงคอนเทนเนอร์ของข้อความในรูปทรงและให้เข้าถึงคอลเลกชันของย่อหน้า
* [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) แสดงย่อหน้าเดียวในกรอบข้อความและให้เข้าถึงส่วนข้อความและการจัดรูปแบบระดับย่อหน้า
* [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) แสดงรันข้อความภายในย่อหน้า แต่ละส่วนสามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้น ย่อหน้าจึงสามารถมีข้อความที่มีฟอนท์, สี, ขนาด, และการจัดรูปแบบอื่น ๆ แตกต่างกันโดยใช้หลายส่วน

## **สร้างและจัดรูปแบบย่อหน้า**

สร้างย่อหน้าในกรอบข้อความของรูปทรงและใช้ส่วนข้อความเพื่อจัดรูปแบบรันข้อความแต่ละส่วน ส่วนนี้แสดงวิธีการรวมหลายส่วนภายในแต่ละย่อหน้าและใช้สี, ขนาดฟอนท์, และสไตล์ที่ต่างกัน

### **สร้างย่อหน้าด้วยหลายส่วน**

ตัวอย่าง C++ ด้านล่างสร้างย่อหน้า 3 รายการ, แต่ละรายการมีรันข้อความ 3 ส่วนในคอลเลกชัน [IParagraph::get_Portions](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_portions/) โดยใช้ย่อหน้าเริ่มต้นและส่วนเปล่าที่มีอยู่เป็นค่าเริ่มต้น, จากนั้นเพิ่มย่อหน้าและส่วนที่เหลือ การจัดรูปแบบทำผ่าน [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_portionformat/): ส่วนแรกของแต่ละย่อหน้าเป็นสีแดง, หนา, ขนาด 15 จุด; ส่วนที่สองเป็นสีน้ำเงิน, เอียง, ขนาด 18 จุด; ส่วนที่สามคงการจัดรูปแบบเริ่มต้นไว้

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (auto paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (auto portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **สร้างรายการแบบหัวข้อและลำดับเลข**

จัดระเบียบข้อความย่อหน้าเป็นรายการด้วยสัญลักษณ์, ตัวเลข, หรือรูปภาพกำหนดเอง ตัวอย่างในส่วนนี้ครอบคลุมการจัดรูปแบบหัวข้อ, รายการหลายระดับ, และการกำหนดหมายเลขเริ่มต้นแบบกำหนดเอง

### **สร้างรายการหัวข้อหรือรายการลำดับเลข**

หัวข้อและการลำดับทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดผ่าน [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/)

ตัวอย่าง C++ นี้เพิ่มหัวข้อสัญลักษณ์และรายการลำดับเลขในกรอบข้อความเดียวกัน [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) เลือกประเภทหัวข้อ, ขณะที่ [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/) กำหนดสัญลักษณ์และ [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) เลือกสไตล์การลำดับ ทั้งสองรายการใช้หัวข้อสีดำ ความสูง 100% และระยะห่างย่อหน้าที่ 25 จุด

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **ใช้หัวข้อรูปภาพ**

หัวข้อรูปภาพให้คุณใช้รูปภาพกำหนดเองแทนสัญลักษณ์หรือหมายเลข

ตัวอย่างต้องการไฟล์ `bullets.png` อยู่ในไดเรกทอรีทำงาน ตัวอย่าง C++ นี้เพิ่มรูปภาพลงในคอลเลกชันรูปภาพของงานนำเสนอเป็น [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) แล้วใช้เป็นหัวข้อย่อหน้า โดยตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) ให้ใช้หัวข้อรูปภาพและกำหนดรูปภาพผ่าน [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/). [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/) ตั้งค่าเป็น 100% เพื่อขนาดหัวข้อเทียบกับข้อความย่อหน้า

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **สร้างรายการหลายระดับ**

ตั้งค่า [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึก `0`

ตัวอย่าง C++ นี้กำหนดค่า [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) ตั้งแต่ 0 ถึง 3 สำหรับย่อหน้า 4 รายการ, สร้างลำดับชั้นภายในกรอบข้อความเดียวแต่ละย่อหน้าใช้หัวข้อสัญลักษณ์, โดย [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/) สลับระหว่างหัวข้อกลมและขีดเพื่อแยกระดับข้างเคียง

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **เริ่มรายการลำดับเลขด้วยค่าแบบกำหนดเอง**

ใช้ [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) เพื่อกำหนดหมายเลขเริ่มต้นที่แสดงสำหรับย่อหน้าแบบลำดับเลข

ตัวอย่าง C++ นี้ตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) ให้ใช้การลำดับเลขสำหรับย่อหน้า 3 รายการและกำหนดค่า [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) เป็น 2, 3, และ 7 ค่าการเริ่มต้นกำหนดแยกสำหรับแต่ละย่อหน้า, ทำให้เลขที่แสดงข้ามค่าได้

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ควบคุมการจัดวางและคุณสมบัติสิ้นสุดของย่อหน้า**

ปรับระยะขอบและการเยื้องของย่อหน้าเพื่อควบคุมตำแหน่งของบรรทัดแรกและบรรทัดที่หักห่อ คุณยังสามารถจัดรูปแบบเครื่องหมายสิ้นสุดของย่อหน้าแยกจากส่วนข้อความที่มองเห็นได้

### **ตั้งค่าเยื้องบรรทัดแรก**

ใช้เมธอด [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) เพื่อควบคุมเยื้องบรรทัดแรกของย่อหน้า เมธอดนี้ย้ายบรรทัดแรกเทียบกับระยะขอบซ้ายของย่อหน้า ค่าบวกจะเลื่อนไปทางขวา, ส่วนบรรทัดที่เหลือคงตำแหน่งเดิม

ใช้ [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) เมื่อคุณต้องการย้ายทั้งย่อหน้า ใช้ [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างต่อไปนี้ให้ย่อหน้า 3 รายการมี [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) เท่ากับ 20 จุดและค่า [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) เป็น 0, 20, และ 40 จุด บรรทัดแรกจะเริ่มที่ระยะที่เพิ่มขึ้น, ส่วนบรรทัดที่หักห่อคงระยะขอบซ้ายเดียวกัน

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ระยะเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่าเยื้องแขวน**

เยื้องแขวนคือการจัดวางที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟ็กต์นี้ด้วยเมธอด [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) ให้ค่าติดลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเทียบกับเนื้อย่อหน้า

โดยปฏิบัติ, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) กำหนดตำแหน่งซ้ายของเนื้อย่อหน้าและ [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) กำหนดตำแหน่งบรรทัดแรกเทียบกับระยะขอบนั้น เพื่อสร้างเยื้องแขวน ให้ตั้งค่า `MarginLeft` เป็นบวกและ `Indent` เป็นลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการพจนานุกรม, และย่อหน้าที่ต้องให้บรรทัดที่หักห่อเรียงใต้เนื้อย่อหน้าแทนบรรทัดแรก

ตัวอย่าง C++ ต่อไปนี้จับคู่ค่า [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) เป็น 40 และ 60 จุดกับค่า [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) เป็น -20 และ -30 จุด ในแต่ละย่อหน้า บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่หักห่อ; ย่อหน้าที่สองมีเยื้องแขวนลึกกว่า

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![เยื้องแขวนของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติสิ้นสุดของย่อหน้า**

เมธอด [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) ควบคุมการจัดรูปแบบของเครื่องหมายสิ้นสุดย่อหน้า ตัวอย่างโหลด `Test.pptx` ที่ต้องมีอย่างน้อยหนึ่งสไลด์ ตัวอย่างต่อไปนี้สร้าง [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) โดยตั้งค่า [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_fontheight/) เป็น 48 จุดและ [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_latinfont/) เป็น Times New Roman จากนั้นกำหนดรูปแบบนี้ให้กับเครื่องหมายสิ้นสุดของย่อหน้าที่สองโดยไม่เปลี่ยนส่วนข้อความที่มองเห็น

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **นับจำนวนบรรทัดที่เรนเดอร์**

สำหรับกฎของย่อหน้าที่ส่งผลต่อการห่ออัตโนมัติและเครื่องหมายวรรคตอนที่ส่วนท้ายของบรรทัด ดูที่ [Control Line Breaking](/slides/th/cpp/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/cpp/text-formatting/#control-hanging-punctuation)

ใช้เมธอด [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/) เพื่อจำนวนบรรทัดที่ย่อหน้าใช้หลังจากการจัดวางข้อความ, รวมการห่ออัตโนมัติ ซึ่งมีประโยชน์เมื่อเช็คความยาวและการจัดวางของข้อความในแม่แบบพรีเซนเทชัน

ย่อหน้าเป็นรายการหนึ่งใน [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_paragraphs/), และอาจครอบคลุมหลายบรรทัดที่เรนเดอร์ การหยุดบรรทัดโดยตรงภายในย่อหน้าจะบังคับให้เกิดบรรทัดใหม่โดยไม่สร้างย่อหน้าใหม่ การห่ออัตโนมัติสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่แทรกการหยุดบรรทัดในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระหยุดบรรทัดจะไม่ให้จำนวนบรรทัดที่เรนเดอร์จริง

ตัวอย่างต่อไปนี้สร้างรูปทรงข้อความ, นับบรรทัด, ลดความกว้างของรูปทรง, แล้วแทนที่ข้อความด้วยสตริงสั้นกว่า ตัวอย่างเปิดใช้ [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) และปิด [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) เพื่อให้ความกว้างของรูปทรงควบคุมการห่อโดยไม่ย่อหรือปรับขนาดรูปทรงอัตโนมัติ การวัดแต่ละครั้งใช้ [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/). มิติของรูปทรงเป็นหน่วยจุด สุดท้ายตัวอย่างเพิ่มย่อหน้าอีกหนึ่งรายการและรวมจำนวนบรรทัดทั้งหมดในกรอบข้อความ

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
paragraph->set_Text(u"This text demonstrates how automatic wrapping changes the number of rendered lines.");
Console::WriteLine(u"Original width: {0}", paragraph->GetLinesCount());

shape->set_Width(150);
Console::WriteLine(u"Narrower shape: {0}", paragraph->GetLinesCount());

paragraph->set_Text(u"Short text.");
Console::WriteLine(u"Shorter text: {0}", paragraph->GetLinesCount());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Another paragraph.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto totalLineCount = 0;
for (auto currentParagraph : textFrame->get_Paragraphs())
{
    totalLineCount += currentParagraph->GetLinesCount();
}
Console::WriteLine(u"Total lines in the text frame: {0}", totalLineCount);
presentation->Dispose();
```

ด้วยข้อความและมิตินี้, การทำให้รูปทรงแคบลงจะเพิ่มจำนวนบรรทัด, ขณะแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แม่นยำอาจแตกต่างตามการมีฟอนท์และการแทนที่, ขนาดฟอนท์, ระยะขอบ, ระยะเยื้อง, การห่อ, และการตั้งค่า Autofit ใช้ฟอนท์และการตั้งค่าการจัดวางที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อตรวจสอบแม่แบบ

จำนวนบรรทัดอย่างเดียวไม่ได้บ่งบอกว่าข้อความล้นคอนเทนเนอร์หรือไม่ ความสูงที่มี, ความสูงของบรรทัด, ระยะห่างของย่อหน้าและบรรทัด, รวมถึงพฤติกรรม Autofit ก็สำคัญ; แม้แต่บรรทัดเดียวก็อาจเกินความกว้างที่มีเมื่อปิดการห่อ

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

ใช้ HTML เพื่อนำข้อความเข้ามาในพรีเซนเทชันหรือส่งออกย่อมาที่มีอยู่เพื่อใช้ภายนอก ส่วนนี้ยังแสดงวิธีการเรนเดอร์ย่อหน้าแต่ละอันเป็นรูปภาพ, รวมถึงย่อหน้าในเซลล์ตารางด้วย

### **นำเข้า HTML ไปยังย่อหน้า**

ใช้เมธอด [ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/) เพื่อแปลงมาร์คอัพ HTML เป็นย่อหน้าและส่วนข้อความในกรอบข้อความ

ตัวอย่าง C++ นี้อ่าน HTML จากไฟล์และส่งมาร์คอัพให้กับ [ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/). มันล้างย่อหน้าเริ่มต้นของกรอบข้อความเพื่อให้กรอบมีเฉพาะเนื้อหาที่นำเข้า รูปร่างสี่เหลี่ยมทิ้งระยะขอบ 10 จุดทั้งสี่ด้านของสไลด์

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **ส่งออกข้อความย่อหน้าเป็น HTML**

ใช้เมธอด [ParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/exporttohtml/) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML เมื่อนำข้อความจากพรีเซนเทชันไปใช้บนเว็บไซต์ คุณอาจต้องการคงการเน้นเฉพาะโดยไม่ต้องพกฟอนท์, ขนาด, หรือสไตล์ของกล่องข้อความของพรีเซนเทชัน ตั้งค่า [TextToHtmlConversionOptions::set_TextInheritanceLimit](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/set_textinheritancelimit/) เพื่อควบคุมความลึกที่ตัวส่งออกติดตามการสืบทอดรูปแบบ

ดาวน์โหลด [ตัวอย่างพรีเซนเทชัน](text-inheritance.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีรูปทรงข้อความหนึ่งรูปพร้อมข้อความ “Inherited text; explicit red 18pt”. อินพุตตั้งค่าแบบหลายระดับดังนี้:

- สไตล์ข้อความเริ่มต้นของพรีเซนเทชันใช้ Calibri ขนาด 28 pt
- สไตล์ระดับแรกของกรอบข้อความใช้ข้อความสีน้ำเงินและเอียง
- ย่อหน้ากำหนดข้อความหนาอย่างชัดเจน
- ส่วนที่สอง “explicit red 18pt” กำหนดข้อความสีแดงและขนาด 18 pt อย่างชัดเจน

ตัวอย่างต่อไปนี้ส่งออกย่อหน้าเดียวกันสามครั้ง ส่งค่า [TextToHtmlConversionOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/) ให้กับเมธอดส่งออกและบันทึกผลลัพธ์แต่ละไฟล์เป็น HTML UTF‑8 แยกไฟล์

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <Export/TextInheritanceLimit.h>
#include <Export/TextToHtmlConversionOptions.h>
#include <system/array.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"text-inheritance.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto modes = MakeArray<TextInheritanceLimit>({TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly});
    auto fileNames = MakeArray<String>({u"All.html", u"TextBox.html", u"ParagraphOnly.html"});

    for (auto i = 0; i < modes->get_Length(); i++)
    {
        auto options = MakeObject<TextToHtmlConversionOptions>();
        options->set_TextInheritanceLimit(modes[i]);

        auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), options);
        File::WriteAllText(fileNames[i], html, Encoding::get_UTF8());
    }
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

HTML ที่สร้างมี CSS ดังต่อไปนี้สำหรับส่วนแรก “Inherited text; ” ตารางแสดงการประกาศที่เกี่ยวข้อง; คุณสมบัติอื่นที่สร้างขึ้นจะถูกละเว้นเพื่อความชัดเจน

| ผลลัพธ์ | CSS ที่เกี่ยวข้องสำหรับส่วนแรก | ลักษณะ |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีฟ้า, หนา, เอียง ที่ 28 pt ใน Calibri หากฟอนท์นั้นพร้อมใช้งาน |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีฟ้า, หนา, เอียง; หน้าเว็บหรือเบราว์เซอร์จะจัดหาฟอนท์และขนาด |
| `ParagraphOnly.html` | `font-weight:bold` | ข้อความหนา; หน้าเว็บหรือเบราว์เซอร์จะจัดหาฟอนท์, ขนาด, สี, และสไตล์เอียง |

ส่วนที่สองยังคงมี `color:#ff0000`, `font-size:18pt`, และ `font-weight:bold` ในผลลัพธ์ทั้งสาม และยังคงเอียงใน `All` และ `TextBox` แต่ไม่ใน `ParagraphOnly` การจำกัดการสืบทอดจึงไม่ลบการจัดรูปแบบที่กำหนดโดยตรงให้กับย่อหน้าหรือส่วน

เปิดไฟล์ในเบราว์เซอร์เดียวกันเพื่อเปรียบเทียบ ในสองโหมดที่จำกัด, คุณสมบัติ CSS ที่ละเว้นจะถูกเติมด้วยสไตล์ของหน้าปลายทางหรือค่าเริ่มต้นของเบราว์เซอร์ ดังนั้นลักษณะที่แสดงขึ้นจะขึ้นกับที่ใช้ HTML

### **เรนเดอร์ย่อหน้าเป็นรูปภาพ**

เมธอด [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) เรนเดอร์ย่อหน้าเดียวโดยตรงและส่งคืน [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/). บันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). ไม่จำเป็นต้องเรนเดอร์รูปร่างทั้งหมดหรือครอปบิทแมพด้วยตนเอง

[IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) อาจคืนค่า `nullptr` หากไม่พบย่อหน้าในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายอิมเมจที่คืนหลังจากใช้

#### **เรนเดอร์ย่อหน้าที่สเกลค่าเริ่มต้น**

ตัวอย่างใช้ `sample.pptx`, พรีเซนเทชันที่มีสไลด์หนึ่งซึ่งรูปทรงแรกเป็นกล่องข้อความที่มีย่อหน้า 3 รายการ

![กล่องข้อความที่มีย่อหน้า 3 รายการ](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เลือกย่อหน้าที่สองที่ตำแหน่งดัชนี 1 และเรียก [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) โดยไม่มีพารามิเตอร์สเกล ตรวจสอบว่ารูปทรงมีย่อหน้าที่ต้องการและการเรนเดอร์คืนอิมเมจก่อนเรียก [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) เพื่อบันทึกเป็น PNG ตัวอย่างทำลายอิมเมจหลังบันทึก

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

ผลลัพธ์:

![รูปภาพย่อหน้า](paragraph_to_image_output.png)

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมการสเกล**

ใช้เมธอดโอเวอร์โหลดของ [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดอัตราส่วนแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกที่กว้างและสูงเป็นสองเท่าของค่าเริ่มต้น, และบันทึกผลเป็น PNG

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

ค่าอัตราส่วน `1` ทำให้แกนนั้นคงขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองอัตราส่วนจะให้ภาพที่กว้างและสูงประมาณสองเท่าของมิติเริ่มต้น, ผลลัพธ์คือสี่เท่าจำนวนพิกเซล ค่าอัตราส่วนที่สูงกว่าจะให้ข้อความคมชัดสำหรับการซูมหรือเอาต์พุตความละเอียดสูง, แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ค่าอัตราส่วนต่ำกว่า `1` จะให้ภาพขนาดเล็กและรายละเอียดน้อยกว่า ใช้อัตราส่วนเท่ากันเพื่อรักษาอัตราส่วนภาพของย่อหน้า; ค่าอัตราส่วนแนวนอนและแนวตั้งต่างกันจะทำให้ผลลัพธ์ขยายไม่สอดคล้องกัน

การเรนเดอร์รูปร่างทั้งหมดด้วย [IShape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getimage/) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี, เส้นขอบ, หรือบริบทภาพอื่นของรูปร่าง สำหรับภาพเฉพาะย่อหน้า ให้ใช้ [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการห่อบรรทัดภายในกรอบข้อความได้ทั้งหมดหรือไม่?**

ได้ ใช้เมธอด [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) เพื่อปิดการห่อเพื่อให้บรรทัดไม่ตัดที่ขอบของกรอบข้อความ

**ฉันจะรับขอบเขตบนสไลด์ของย่อหน้าเฉพาะได้อย่างแม่นยำอย่างไร?**

ใช้เมธอด [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getrect/) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า [IPortion::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/getrect/) ให้ขอบเขตของส่วนข้อความแต่ละส่วน

**ที่ไหนที่การจัดแนบย่อหน้า (ซ้าย, ขวา, กลาง, หรือจัดชิด) ถูกควบคุม?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของส่วนย่อย

เพื่อจัดแนวฟอนท์หลายขนาดภายในแต่ละบรรทัด ดูที่ [Align Fonts Within a Line](/slides/th/cpp/text-formatting/#align-fonts-within-a-line)

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนของย่อหน้าได้หรือไม่?**

ได้ ใช้เมธอด [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) สำหรับส่วนย่อยแต่ละส่วน เพื่อให้ย่อหน้าเดียวสามารถมีข้อความหลายภาษาได้