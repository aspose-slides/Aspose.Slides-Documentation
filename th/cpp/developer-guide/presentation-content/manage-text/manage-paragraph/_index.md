---
title: จัดการย่อหน้าข้อความ PowerPoint ใน C++
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
- จัดการหัวข้อ
- การเยื้องย่อหน้า
- การเยื้องแขวน
- หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อ
- คุณสมบัติจัดรูปแบบย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า ส่วนย่อย หัวข้อ รายการลำดับเลข การเยื้อง เนื้อหา HTML และรูปภาพย่อหน้าด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides for C++ แสดงข้อความเป็นลำดับขั้นของกรอบข้อความ ย่อหน้า และส่วนย่อย:

* [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) แสดงคอนเทนเนอร์ข้อความในรูปทรงและให้การเข้าถึงคอลเลกชันย่อหน้า
* [IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/) แสดงย่อหน้าเดียวในกรอบข้อความและให้การเข้าถึงส่วนย่อยและการจัดรูปแบบระดับย่อหน้า
* [IPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/) แสดงช่วงข้อความภายในย่อหน้า แต่ละส่วนย่อยสามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้น ย่อหน้าจึงสามารถมีข้อความที่ใช้ฟอนต์ สี ขนาด และการจัดรูปแบบอื่น ๆ ต่างกันได้โดยใช้หลายส่วนย่อย

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลายส่วนย่อย**

ขั้นตอนต่อไปนี้สร้างกรอบข้อความที่มีสามย่อหน้า โดยแต่ละย่อหน้ามีสามส่วนย่อย:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) สี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของรูปทรง
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มวัตถุ [IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/) เพิ่มอีกสองรายการไปยังกรอบข้อความ
6. เพิ่มวัตถุ [IPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/) จำนวนเพียงพอสำหรับแต่ละย่อหน้าเพื่อให้มีสามส่วนย่อย ส่วนย่อยเริ่มต้นมีหนึ่งส่วนย่อยว่างอยู่แล้ว
7. ตั้งค่าข้อความของแต่ละส่วนย่อย
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [IPortion::get_PortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/get_portionformat/)
9. บันทึกการพรีเซนเทชันที่แก้ไขแล้ว

ตัวอย่าง C++ นี้ดำเนินการตามขั้นตอน:

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
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
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

### **สร้างรายการแบบหัวข้อหรือรายการลำดับเลข**

หัวข้อและการจัดลำดับทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดผ่าน [IBulletFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ไปยังสไลด์ที่เลือก
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของรูปทรง
5. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraph/) สำหรับหัวข้อสัญลักษณ์
7. ตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_type/) เป็น [BulletType::Symbol](https://reference.aspose.com/slides/th/cpp/aspose.slides/bullettype/) และระบุอักขระหัวข้อ
8. ตั้งค่าข้อความย่อหน้า ระยะเยื้อง สีหัวข้อ และความสูงหัวข้อ
9. เพิ่มย่อหน้าไปยังกรอบข้อความ
10. สร้างย่อหน้าที่สองและตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_type/) เป็น [BulletType::Numbered](https://reference.aspose.com/slides/th/cpp/aspose.slides/bullettype/)
11. กำหนดสไตล์หัวข้อเลขและเพิ่มย่อหน้าไปยังกรอบข้อความ
12. บันทึกพรีเซนเทชัน

ตัวอย่าง C++ นี้สร้างหัวข้อสัญลักษณ์และหัวข้อเลข:

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

### **ใช้หัวข้อแบบภาพ**

หัวข้อแบบภาพทำให้คุณใช้รูปภาพกำหนดเองแทนสัญลักษณ์หรือเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) และเข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของมัน
4. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ
5. โหลดรูปภาพหัวข้อและเพิ่มลงในคอลเลกชันรูปภาพของพรีเซนเทชันเป็น [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraph/) และตั้งค่าข้อความของมัน
7. ตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_type/) เป็น [BulletType::Picture](https://reference.aspose.com/slides/th/cpp/aspose.slides/bullettype/)
8. กำหนดรูปภาพผ่าน [ISlidesPicture::set_Image](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidespicture/set_image/) และตั้งค่าความสูงหัวข้อ
9. เพิ่มย่อหน้าไปยังกรอบข้อความ
10. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

ตัวอย่าง C++ นี้สร้างหัวข้อแบบภาพ:

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

ตั้งค่า [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_depth/) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึก `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) และเข้าถึงสไลด์
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) และลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของมัน
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์หัวข้อให้แต่ละย่อหน้า
4. ตั้งค่าความลึกของพวกมันโดยใช้ [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_depth/) เป็น `0` `1` `2` และ `3`
5. เพิ่มย่อหน้าเหล่านั้นไปยังกรอบข้อความและบันทึกพรีเซนเทชัน

ตัวอย่าง C++ นี้สร้างรายการหัวข้อสี่ระดับ:

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

### **กำหนดค่าตัวเลขเริ่มต้นของรายการเลขแบบกำหนดเอง**

ใช้ [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) เพื่อกำหนดตัวเลขเริ่มต้นที่จะแสดงสำหรับย่อหน้าแบบลำดับเลข

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ไปยังสไลด์
2. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของรูปทรง
3. สร้างย่อหน้าเลขสามรายการ
4. ตั้งค่า [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) เป็น `2` `3` และ `7` สำหรับย่อหน้าแต่ละรายการ
5. เพิ่มย่อหน้าไปยังกรอบข้อความและบันทึกพรีเซนเทชัน

ตัวอย่าง C++ นี้กำหนดเลขเริ่มต้นแบบกำหนดให้แต่ละย่อหน้า:

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

## **ควบคุมการจัดวางและคุณสมบัติงานสิ้นสุดของย่อหน้า**

### **ตั้งค่าการเยื้องบรรทัดแรก**

ใช้ [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า วิธีนี้จะย้ายบรรทัดแรกเท่านั้นเมื่อเทียบกับขอบซ้ายของย่อหน้า ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ในตำแหน่งของเนื้อหาย่อหน้า

ใช้ [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_marginleft/) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) เมื่อต้องการย้ายเพียงบรรทัดแรกเท่านั้น

ตัวอย่างด้านล่างสร้างหลายย่อหน้าและใช้ค่า [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) ที่แตกต่างกันเพื่อแสดงว่าการเยื้องบรรทัดแรกส่งผลต่อการจัดวางอย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) สี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
5. สร้างหลายย่อหน้าและตั้งค่าค่า [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) ที่แตกต่างกันสำหรับแต่ละย่อหน้า
6. เพิ่มย่อหน้าเหล่านั้นไปยังกรอบข้อความ
7. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าการเยื้องย่อหน้า:

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

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่าการเยื้องแขวน**

การเยื้องแขวนคือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างผลนี้ด้วย [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) ตั้งค่าการเยือนไปเป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับส่วนของย่อหน้า

โดยปฏิบัติ [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_marginleft/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า ส่วน [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) กำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับขอบซ้ายนั้น เพื่อสร้างการเยื้องแขวน ให้ตั้งค่าขอบซ้ายเป็นค่าบวกและการเยื้องเป็นค่าลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม แหล่งอ้างอิง รายการสารานุกรม และย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดต่อเนื่องเรียงชิดใต้เนื้อหาย่อหน้าแทนที่จะชิดใต้อักขระตัวแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) สี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าและตั้งค่า [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_marginleft/) ให้เป็นค่าบวกสำหรับแต่ละย่อหน้า
6. ตั้งค่า [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) ให้เป็นค่าลบเพื่อสร้างผลการเยื้องแขวน
7. เพิ่มย่อหน้าเหล่านั้นไปยังกรอบข้อความ
8. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าการเยื้องแขวนสำหรับย่อหน้า:

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

presentation->Save(u"hhang_in
```

ผลลัพธ์:

![การเยื้องแขวนของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติงานสิ้นสุดของย่อหน้า**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) ควบคุมการจัดรูปแบบของเครื่องหมายจบย่อหน้า ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ละตินให้กับเครื่องหมายจบของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) และเข้าถึงสไลด์
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) แล้วลบย่อหน้าเริ่มต้นของมัน
3. สร้างย่อหน้า 2 รายการและเพิ่มส่วนข้อความให้กับแต่ละย่อหน้า
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/portionformat/) สำหรับเครื่องหมายจบของย่อหน้าที่สอง
5. ตั้งค่า [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_fontheight/) และ [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_latinfont/)
6. แปะรูปแบบด้วย [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) แล้วบันทึกพรีเซนเทชัน

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

## **นับจำนวนบรรทัดที่แสดงผล**

ใช้ [IParagraph::GetLinesCount](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getlinescount/) เพื่อนับจำนวนบรรทัดที่ย่อหน้าใช้หลังจากการจัดรูปแบบข้อความรวมถึงการตัดบรรทัดอัตโนมัติ ซึ่งมีประโยชน์เมื่อพิจารณาความยาวและการจัดวางของข้อความในเทมเพลตพรีเซนเทชัน

ย่อหน้าเป็นรายการหนึ่งใน [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_paragraphs/) และอาจใช้หลายบรรทัดที่แสดงผล การใส่การตัดบรรทัดโดยตรงภายในย่อหน้าจะบังคับให้ขึ้นบรรทัดใหม่โดยไม่ต้องสร้างย่อหน้าใหม่ การตัดบรรทัดอัตโนมัติจะสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่แทรกอักขระตัดบรรทัดลงในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระตัดบรรทัดจะไม่ได้ให้จำนวนบรรทัดที่แสดงผล

ตัวอย่างต่อไปนี้สร้างรูปข้อความ นับบรรทัดของมัน ลดความกว้างของรูปแล้วแทนที่ข้อความด้วยสตริงสั้นกว่า การตัดบรรทัดเปิดอยู่และการปรับขนาดอัตโนมัติปิดเพื่อให้ความกว้างของรูปควบคุมการตัดบรรทัดโดยไม่ให้ข้อความหรือรูปปรับขนาดอัตโนมัติ มิติของรูปใช้หน่วยจุด สุดท้าย ตัวอย่างเพิ่มย่อหน้าอีกหนึ่งรายการและรวมจำนวนบรรทัดทั้งหมดของกรอบข้อความ

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

ด้วยข้อความและมิติเหล่านี้ การทำให้รูปแคบลงจะเพิ่มจำนวนบรรทัด ส่วนการแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แน่นอนอาจแตกต่างกันตามฟอนต์ที่มีและการทดแทน ขนาดฟอนต์ ขอบ ระยะเยื้อง การตัดบรรทัด และการตั้งค่าการปรับขนาดอัตโนมัติ ควรใช้ฟอนต์และการตั้งค่าการจัดวางที่กำหนดสำหรับสภาพแวดล้อมเป้าหมายเมื่อตรวจสอบเทมเพลต

จำนวนบรรทัดเพียงอย่างเดียวไม่ได้บ่งบอกว่าข้อความล้นพื้นที่หรือไม่ ความสูงที่ใช้ได้ ความสูงบรรทัด ระยะห่างย่อหน้าและบรรทัด และพฤติกรรมการปรับขนาดอัตโนมัติก็สำคัญเช่นกัน แม้กระทั่งบรรทัดเดียวก็อาจเกินความกว้างที่มีได้เมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้า HTML ไปยังย่อหน้า**

ใช้ [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphcollection/addfromhtml/) เพื่อแปลงมาร์กอัป HTML ให้เป็นย่อหน้าและส่วนย่อยในกรอบข้อความ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/)
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
4. อ่านไฟล์ HTML ต้นฉบับ
5. ส่งสตริง HTML ไปยัง [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphcollection/addfromhtml/)
6. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

ตัวอย่าง C++ นี้นำเข้า HTML ไปยังกรอบข้อความ:

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

ใช้ [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphcollection/exporttohtml/) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) และโหลดพรีเซนเทชันที่ต้องการ
2. เข้าถึงสไลด์และค้นหา [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ที่มีข้อความ
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของรูปทรง
4. เรียก [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphcollection/exporttohtml/) พร้อมดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก
5. เขียนสตริง HTML ที่ได้ลงไฟล์

ตัวอย่าง C++ นี้ส่งออกย่อหน้าทั้งหมดจากรูปข้อความแรก:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **แสดงย่อหน้าเป็นภาพ**

[IParagraph::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getimage/) แสดงย่อหน้าเดี่ยวโดยตรงและคืนค่า [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) ให้บันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/save/) คุณไม่จำเป็นต้องแสดงรูปทรงทั้งหมดหรือทำการครอปบิทแมพด้วยตนเอง

[IParagraph::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getimage/) อาจคืนค่า `nullptr` หากย่อหาไม่พบในคอลเลกชันแม่ ไม่มีขอบเขตการแสดงผลที่ถูกต้อง หรือไม่สามารถแสดงผลได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังใช้งาน

#### **แสดงย่อหน้าโดยสเกลเริ่มต้น**

สมมติว่ามีไฟล์พรีเซนเทชันชื่อ sample.pptx ที่มีหนึ่งสไลด์ โดยรูปแรกเป็นกล่องข้อความที่มีย่อหน้า 3 รายการ

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้แสดงย่อหน้าที่สองในรูปข้อความปกติโดยสเกลเริ่มต้นและบันทึกภาพที่ได้ในรูปแบบ PNG

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

![ภาพย่อหน้า](paragraph_to_image_output.png)

#### **แสดงย่อหน้าในเซลล์ตารางพร้อมการสเกล**

ใช้โอเวอร์โหลดของ [IParagraph::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getimage/) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดอัตราส่วนการสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง แสดงย่อหน้าในเซลล์แรกด้วยความกว้างและความสูงเป็นสองเท่าของค่าเริ่มต้น แล้วบันทึกผลเป็นภาพ PNG

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

ค่าสเกล `1` คงขนาดพิกเซลเริ่มต้นของแกนนั้น ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะทำให้ภาพที่ได้กว้างและสูงประมาณสองเท่า ของมิติเริ่มต้น ทำให้จำนวนพิกเซลเป็นสี่เท่า ปัจจัยสเกลที่ใหญ่กว่าจะให้ข้อความคมชัดขึ้นสำหรับการซูมหรือการส่งออกความละเอียดสูง แต่จะเพิ่มการใช้หน่วยความจำและขนาดไฟล์ ปัจจัยที่ต่ำกว่า `1` จะให้ภาพเล็กลงและรายละเอียดน้อยลง ใช้ค่าปัจจัยเท่ากันเพื่อคงอัตราส่วนของย่อหน้า; ปัจจัยแนวนอนและแนวตั้งที่ต่างกันจะยืดรูปภาพโดยอิสระ

การแสดงรูปทั้งหมดด้วย [IShape::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/getimage/) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี เส้นขอบ หรือบริบทภาพอื่นของรูป แต่สำหรับภาพที่มีเฉพาะย่อหน้าให้ใช้ [IParagraph::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getimage/)

## **FAQ**

**ฉันสามารถปิดการตัดบรรทัดภายในกรอบข้อความได้อย่างสมบูรณ์หรือไม่?**

ได้ ใช้ [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/set_wraptext/) เพื่อปิดการตัดบรรทัดให้บรรทัดไม่ตัดที่ขอบกรอบข้อความ

**ฉันจะรับพิกัดที่แน่นอนของย่อหน้าที่กำหนดบนสไลด์ได้อย่างไร?**

ใช้ [IParagraph::GetRect](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getrect/) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า [IPortion::GetRect](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/getrect/) ให้พิกัดของส่วนย่อยแต่ละส่วน

**การจัดแนวของย่อหน้า (ซ้าย ขวา กลาง หรือจัดเต็ม) ควบคุมที่ไหน?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_alignment/) เป็นการตั้งค่าระดับย่อหน้าและจะนำไปใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของส่วนย่อยแต่ละส่วน

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนของย่อหน้าได้หรือไม่?**

ได้ ใช้ [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_languageid/) สำหรับส่วนย่อยแต่ละส่วน เพื่อให้ย่อหน้าหนึ่งสามารถมีข้อความหลายภาษาได้.