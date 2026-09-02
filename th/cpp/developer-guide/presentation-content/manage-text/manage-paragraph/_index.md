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
- ย่อหน้าเยื้อน
- ย่อหน้ายืดห้อย
- หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อ
- คุณสมบัติย่อหน้า
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
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, portion, bullet, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides for C++ แสดงข้อความเป็นโครงสร้างชั้นของ text frames, paragraphs, และ portions:

* [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) เป็นตัวบรรจุข้อความในรูปทรงและให้การเข้าถึงคอลเลกชันของย่อหน้า
* [IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/) แทนย่อหน้าเดียวใน text frame และให้การเข้าถึง portion และการจัดรูปแบบระดับย่อหน้า
* [IPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/) แทนการเรียกใช้ข้อความภายในย่อหน้า แต่ละ portion สามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้นย่อหน้าจึงสามารถประกอบด้วยข้อความที่มีแบบอักษร สี ขนาด และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันโดยใช้หลาย portion

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลาย Portion**

ขั้นตอนต่อไปนี้จะสร้าง text frame ที่มีสามย่อหน้า แต่ละย่อหน้ามีสาม portion:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) สี่เหลี่ยมมุมฉากลงในสไลด์  
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของรูปทรง  
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มอีกสองอ็อบเจกต์ [IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/) ลงใน text frame  
6. เพิ่มอ็อบเจกต์ [IPortion](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/) ให้เพียงพอเพื่อให้แต่ละย่อหน้ามีสาม portion ย่อหน้าเริ่มต้นมี portion ว่างหนึ่งออบเจกต์อยู่แล้ว  
7. ตั้งค่าข้อความของแต่ละ portion  
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [IPortion::get_PortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/get_portionformat/)  
9. บันทึกงานนำเสนอที่ปรับเปลี่ยนแล้ว  

ตัวอย่าง C++ ด้านล่างทำตามขั้นตอนเหล่านี้:

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

## **สร้างรายการแบบมีหัวข้อและลำดับเลข**

### **สร้างรายการแบบมีหัวข้อหรือเป็นลำดับเลข**

หัวข้อและการจัดลำดับทำให้รายการที่เกี่ยวข้องอ่านได้ง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดโดยใช้ [IBulletFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/)  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์ที่เลือก  
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของรูปทรง  
5. ลบย่อหน้าเริ่มต้นออกจาก text frame  
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraph/) สำหรับหัวข้อสัญลักษณ์  
7. ตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_type/) เป็น [BulletType::Symbol](https://reference.aspose.com/slides/th/cpp/aspose.slides/bullettype/) และระบุอักขระหัวข้อ  
8. ตั้งค่าข้อความย่อหน้า ระยะเยื้อง สีหัวข้อ และความสูงของหัวข้อ  
9. เพิ่มย่อหน้าไปยัง text frame  
10. สร้างย่อหน้าที่สองและตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_type/) เป็น [BulletType::Numbered](https://reference.aspose.com/slides/th/cpp/aspose.slides/bullettype/)  
11. กำหนดสไตล์หัวข้อเป็นลำดับเลขและเพิ่มย่อหน้าไปยัง text frame  
12. บันทึกงานนำเสนอ  

ตัวอย่าง C++ นี้สร้างหัวข้อสัญลักษณ์และหัวข้อเป็นลำดับเลข:

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

หัวข้อแบบภาพให้คุณใช้รูปภาพที่กำหนดเองแทนสัญลักษณ์หรือเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. เข้าถึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) และเข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของมัน  
4. ลบย่อหน้าเริ่มต้นออกจาก text frame  
5. โหลดภาพหัวข้อและเพิ่มลงในคอลเลกชันภาพของงานนำเสนอเป็น [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/)  
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraph/) และตั้งค่าข้อความของมัน  
7. ตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_type/) เป็น [BulletType::Picture](https://reference.aspose.com/slides/th/cpp/aspose.slides/bullettype/)  
8. กำหนดภาพผ่าน [ISlidesPicture::set_Image](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidespicture/set_image/) และตั้งค่าความสูงของหัวข้อ  
9. เพิ่มย่อหน้าไปยัง text frame  
10. บันทึกงานนำเสนอที่ปรับเปลี่ยนแล้ว  

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

ตั้งค่า [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_depth/) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึกเป็น `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่งสไลด์  
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) และลบย่อหน้าเริ่มต้นออกจาก text frame ของมัน  
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์หัวข้อให้แต่ละอัน  
4. ตั้งค่า [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_depth/) ของพวกมันเป็น `0`, `1`, `2`, และ `3`  
5. เพิ่มย่อหน้าเหล่านั้นไปยัง text frame และบันทึกงานนำเสนอ  

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

### **เริ่มรายการแบบลำดับเลขที่ค่าที่กำหน์เอง**

ใช้ [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) เพื่อกำหนดเลขเริ่มต้นที่จะแสดงสำหรับย่อหน้าแบบลำดับเลข

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ลงในสไลด์หนึ่งสไลด์  
2. ลบย่อหน้าเริ่มต้นออกจาก text frame ของรูปทรง  
3. สร้างย่อหน้าแบบลำดับเลขสามอัน  
4. ตั้งค่า [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) เป็น `2`, `3`, และ `7` ตามลำดับสำหรับย่อหน้าแต่ละอัน  
5. เพิ่มย่อหน้าเหล่านั้นไปยัง text frame และบันทึกงานนำเสนอ  

ตัวอย่าง C++ นี้กำหนดเลขเริ่มต้นที่กำหนดเองให้กับแต่ละย่อหน้า:

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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติ End**

### **ตั้งค่าการเยื้องบรรทัดแรก**

ใช้ [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า วิธีนี้จะย้ายบรรทัดแรกเท่านั้นเมื่อเทียบกับระยะขอบซ้ายของย่อหน้า ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ตรงตามเนื้อหาย่อหน้า

ใช้ [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_marginleft/) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรกเท่านั้น

ตัวอย่างด้านล่างสร้างย่อหน้าหลายอันและกำหนดค่า [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) ที่แตกต่างกันเพื่อแสดงว่าการเยื้องบรรทัดแรกมีผลต่อการจัดวางย่ออย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. เข้าถึงสไลด์เป้าหมาย  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) สี่เหลี่ยมมุมฉากลงในสไลด์  
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้นออก  
5. สร้างย่อหน้าหลายอันและตั้งค่า [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) ที่แตกต่างกันสำหรับแต่ละอัน  
6. เพิ่มย่อหน้าเหล่านั้นไปยัง text frame  
7. บันทึกงานนำเสนอที่ปรับเปลี่ยนแล้ว  

โค้ดนี้แสดงวิธีตั้งค่าเยื้องย่อหน้า:

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

### **ตั้งค่าการเยื้องแบบห้อย**

การเยื้องแบบห้อยคือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วย [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) ตั้งค่าการเยื้องเป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาย่อหน้า

โดยปฏิบัติ [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_marginleft/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้าและ [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับขอบซ้ายนั้น เพื่อสร้างการเยื้องแบบห้อย ให้ตั้งค่าขอบซ้าย (margin‑left) เป็นบวกและค่าการเยื้อง (indent) เป็นลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, แหล่งอ้างอิง, รายการสารานุกรมและย่อหน้าอื่น ๆ ที่ต้องให้บรรทัดหักพับอยู่ใต้เนื้อหาย่อหน้าแทนที่จะอยู่ใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. เข้าถึงสไลด์เป้าหมาย  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) สี่เหลี่ยมมุมฉากลงในสไลด์  
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้นออก  
5. สร้างย่อหน้าและตั้งค่า [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_marginleft/) ให้เป็นบวกสำหรับแต่ละย่อหน้า  
6. ตั้งค่า [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_indent/) เป็นค่าลบเพื่อสร้างเอฟเฟกต์การเยื้องแบบห้อย  
7. เพิ่มย่อหน้าเหล่านั้นไปยัง text frame  
8. บันทึกงานนำเสนอที่ปรับเปลี่ยนแล้ว  

โค้ดนี้แสดงวิธีตั้งค่าการเยื้องแบบห้อยสำหรับย่อหน้า:

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

![การเยื้องแบบห้อยของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติการรันของย่อหน้าสิ้นสุด**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) ควบคุมการจัดรูปแบบของเครื่องหมายจบย่อหน้า ตัวอย่างต่อไปนี้กำหนดขนาดตัวอักษรและแบบอักษร Latin ให้กับเครื่องหมายจบของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) แล้วเข้าถึงสไลด์หนึ่งสไลด์  
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) แล้วลบย่อหน้าเริ่มต้นของมันออก  
3. สร้างสองย่อหน้าและเพิ่ม portion ของข้อความลงไป  
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/portionformat/) สำหรับเครื่องหมายจบของย่อหน้าที่สอง  
5. ตั้งค่า [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_fontheight/) และ [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_latinfont/)  
6. ใช้รูปแบบด้วย [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) แล้วบันทึกงานนำเสนอ  

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

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้า HTML เป็นย่อหน้า**

ใช้ [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphcollection/addfromhtml/) เพื่อแปลงโค้ด HTML ให้เป็นย่อหน้าและ portion ใน text frame

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. เข้าถึงสไลด์และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/)  
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้นออก  
4. อ่านไฟล์ HTML ต้นฉบับ  
5. ส่งสตริง HTML ให้กับ [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphcollection/addfromhtml/)  
6. บันทึกงานนำเสนอที่ปรับเปลี่ยนแล้ว  

ตัวอย่าง C++ นี้นำเข้า HTML ไปยัง text frame:

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

### **ส่งออกรายความย่อหน้าสู่ HTML**

ใช้ [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphcollection/exporttohtml/) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) แล้วโหลดงานนำเสนอที่ต้องการ  
2. เข้าถึงสไลด์และค้นหา [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ที่มีข้อความอยู่  
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) ของรูปทรงนั้น  
4. เรียก [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphcollection/exporttohtml/) พร้อมดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก  
5. เขียนสตริง HTML ที่ได้ลงในไฟล์  

ตัวอย่าง C++ นี้ส่งออกย่อหน้าทั้งหมดจาก shape ข้อความแรก:

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

[IParagraph::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getimage/) แสดงย่อหน้าเดี่ยวโดยตรงและคืนค่าเป็น [IImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/) บันทึกผลลัพธ์ลงไฟล์หรือสตรีมด้วย [IImage::Save](https://reference.aspose.com/slides/th/cpp/aspose.slides/iimage/save/) คุณไม่จำเป็นต้องแสดง shape ทั้งหมดหรือครอบตัดบิทแมพด้วยตนเอง

[IParagraph::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getimage/) อาจคืนค่า `nullptr` หากไม่พบย่อหน้าในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายอ็อบเจกต์ภาพที่ได้หลังการใช้

#### **แสดงย่อหน้าที่สเกลเริ่มต้น**

สมมติว่ามีไฟล์งานนำเสนอชื่อ sample.pptx มีสไลด์หนึ่งสไลด์ ซึ่ง shape แรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้แสดงย่อหน้าที่สองใน shape ข้อความปกติที่สเกลเริ่มต้นและบันทึกภาพที่ได้เป็นรูปแบบ PNG

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

ใช้การโอเวอร์โหลดของ [IParagraph::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getimage/) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดค่าการสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, แสดงย่อหน้าในเซลล์แรกด้วยความกว้างและความสูงเป็นสองเท่าของค่าเริ่มต้น, แล้วบันทึกผลเป็นไฟล์ PNG

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

ค่าการสเกล `1` จะคงแกนนั้นไว้ที่ขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะให้ภาพที่กว้างและสูงประมาณสองเท่าของมิติเริ่มต้น ทำให้มีพิกเซลมากกว่าตั้งเท่า การสเกลที่ใหญ่กว่ามักทำให้ข้อความคมชัดขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ส่วนค่าที่ต่ำกว่า `1` จะให้ภาพที่เล็กลงและรายละเอียดน้อยลง ใช้ค่าการสเกลเท่ากันเพื่อคงอัตราส่วนของย่อหน้า; การสเกลแนวนอนและแนวตั้งที่ต่างกันจะยืดออกภาพแบบอิสระ

การแสดงรูปแบบของ shape ทั้งหมดด้วย [IShape::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/getimage/) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี, เส้นขอบ หรือบริบทภาพอื่นของ shape สำหรับภาพที่มีเฉพาะย่อหน้า ให้ใช้ [IParagraph::GetImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getimage/)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดภายใน text frame ได้อย่างสมบูรณ์หรือไม่?**

ใช่ ใช้ [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframeformat/set_wraptext/) เพื่อปิดการตัดบรรทัดเพื่อให้บรรทัดไม่ตัดที่ขอบของ text frame

**ฉันจะได้ขอบเขตที่แม่นยำบนสไลด์ของย่อหน้าเฉพาะได้อย่างไร?**

ใช้ [IParagraph::GetRect](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/getrect/) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า [IPortion::GetRect](https://reference.aspose.com/slides/th/cpp/aspose.slides/iportion/getrect/) ให้ขอบเขตของ portion แต่ละอัน

**การจัดแนวย่อหน้า (ซ้าย, ขวา, กลาง หรือจัดเต็ม) ควบคุมที่ไหน?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_alignment/) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของ portion แต่ละอัน

**ฉันสามารถตั้งค่าภาษาการตรวจสอบส่วนของย่อหน้าได้หรือไม่?**

ใช่ ใช้ [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseportionformat/set_languageid/) สำหรับ portion แต่ละอัน เพื่อให้ย่อหน้าหนึ่งสามารถมีข้อความหลายภาษาได้