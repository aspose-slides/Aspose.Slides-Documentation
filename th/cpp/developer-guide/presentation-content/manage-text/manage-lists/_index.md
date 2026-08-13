---
title: จัดการรายการสัญลักษณ์หัวข้อย่อยและรายการลำดับเลขในงานนำเสนอด้วย C++
linktitle: จัดการรายการ
type: docs
weight: 70
url: /th/cpp/manage-lists/
keywords:
- สัญลักษณ์หัวข้อย่อย
- รายการหัวข้อย่อย
- รายการลำดับเลข
- สัญลักษณ์หัวข้อย่อย
- หัวข้อย่อยรูปภาพ
- สัญลักษณ์หัวข้อย่อยกำหนดเอง
- รายการหลายระดับ
- สร้างหัวข้อย่อย
- เพิ่มหัวข้อย่อย
- เพิ่มรายการ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบรายการหัวข้อย่อย, รายการรูปภาพ, รายการหลายระดับ และรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides for C++ ให้คุณสร้างและจัดรูปแบบรายการแบบสัญลักษณ์หัวข้อย่อยและรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument รายการหนึ่งรายการคือย่อหน้าที่การตั้งค่าสัญลักษณ์หัวข้อย่อยถูกควบคุมผ่านรูปแบบย่อหน้า

ใช้เมธอด [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/get_paragraphformat/) เพื่อเข้าถึงการตั้งค่ารายการระดับย่อหน้า จุดเริ่มต้นหลักคือ [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/get_bullet/), ซึ่งจะคืนค่าออบเจกต์ [IBulletFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/) ด้วยออบเจกต์นี้คุณสามารถตั้งค่าประเภทสัญลักษณ์, สัญลักษณ์, รูปภาพ, สี, ขนาด, รูปแบบการลำดับเลขและหมายเลขเริ่มต้นได้

บทความนี้แสดงวิธี:

- สร้างรายการสัญลักษณ์หัวข้อย่อยด้วยสัญลักษณ์กำหนดเอง
- สร้างหัวข้อย่อยรูปภาพ
- สร้างรายการหลายระดับโดยตั้งค่าความลึกของย่อหน้า
- สร้างรายการลำดับเลข
- ตรวจสอบและเปลี่ยนแปลงรูปแบบรายการในงานนำเสนอที่มีอยู่

## **สร้างรายการสัญลักษณ์หัวข้อย่อย**

เพื่อสร้างรายการสัญลักษณ์หัวข้อย่อยให้เพิ่มออบเจกต์ [Paragraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraph/) ไปยัง [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) และตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_type/) เป็น [BulletType::Symbol](https://reference.aspose.com/slides/th/cpp/aspose.slides/bullettype/). จากนั้นคุณสามารถตั้งค่า [IBulletFormat::set_Char](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/get_color/) และ [IBulletFormat::set_Height](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_height/) เพื่อควบคุมลักษณะของสัญลักษณ์หัวข้อย่อยได้

โค้ด C++ ด้านล่างแสดงวิธีสร้างรายการสัญลักษณ์หัวข้อย่อยในสไลด์:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![สัญลักษณ์หัวข้อย่อย](symbol_bullets.png)

## **สร้างรายการลำดับเลข**

ใช้รายการลำดับเลขเมื่อลำดับของรายการมีความสำคัญ ตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_type/) เป็น [BulletType::Numbered](https://reference.aspose.com/slides/th/cpp/aspose.slides/bullettype/). คุณยังสามารถเลือกรูปแบบการลำดับเลขด้วย [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) หรือกำหนดค่าเริ่มต้นด้วย [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) เมื่อรายการควรเริ่มจากค่าที่ไม่ใช่ 1

โค้ด C++ ด้านล่างแสดงวิธีสร้างรายการลำดับเลขในสไลด์:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![หัวข้อแบบลำดับเลข](numbered_bullets.png)

## **สร้างหัวข้อแบบรูปภาพ**

Aspose.Slides ทำให้คุณสามารถแทนที่สัญลักษณ์หัวข้อย่อทั่วไปด้วยภาพได้ หัวข้อรูปภาพทำงานได้ดีที่สุดกับภาพที่เรียบง่ายและยังคงอ่านได้เมื่อลดขนาดลง เช่น ไอคอนหรือไฟล์ PNG ที่มีพื้นหลังใส

{{% alert color="info" %}}
โดยแนวคิด, หากคุณต้องการแทนที่สัญลักษณ์หัวข้อย่อด้วยภาพ ควรเลือกกราฟิกที่เรียบง่ายและมีพื้นหลังโปร่งใส ภาพลักษณ์เช่นนี้ทำงานได้ดีเป็นสัญลักษณ์หัวข้อย่อแบบกำหนดเอง
{{% /alert %}}

ควรจำไว้ว่า ภาพจะถูกย่อให้เล็กลงมาก ดังนั้นเราแนะนำให้เลือกภาพที่ยังคงชัดเจนและมีประสิทธิภาพทางสายตามเมื่อนำไปใช้เป็นหัวข้อย่อในรายการ

เพื่อสร้างหัวข้อรูปภาพให้เพิ่มภาพไปยัง [IPresentation::get_Images](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_images/) และกำหนดออบเจกต์ [IPPImage](https://reference.aspose.com/slides/th/cpp/aspose.slides/ippimage/) ที่ได้ให้กับ [IBulletFormat::get_Picture](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/get_picture/). ตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibulletformat/set_type/) เป็น [BulletType::Picture](https://reference.aspose.com/slides/th/cpp/aspose.slides/bullettype/) ก่อนกำหนดภาพ

สมมติว่ามีไฟล์ \"image.png\":

![ภาพสำหรับหัวข้อย่อย](picture_for_bullets.png)

โค้ด C++ ด้านล่างแสดงวิธีสร้างหัวข้อรูปภาพในสไลด์:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![หัวข้อย่อยรูปภาพ](picture_bullets.png)

## **สร้างรายการหลายระดับ**

ใช้ [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_depth/) เพื่อวางรายการบนระดับที่ต่างกัน ระดับ 0 คือระดับบนสุด, ระดับ 1 อยู่ใต้ระดับนั้น, และต่อไป

โค้ด C++ ด้านล่างแสดงวิธีสร้างรายการสัญลักษณ์หัวข้อย่อยหลายระดับ:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![รายการหลายระดับ](multilevel_list.png)

## **เปลี่ยนรายการที่มีอยู่**

เพื่อเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่ ให้เข้าถึงย่อหน้าที่ต้องการและอัพเดตการตั้งค่า [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/get_bullet/) ของมัน คุณสามารถใช้คุณสมบัติเดียวกับที่ใช้สร้างรายการเพื่อสอบหรือแก้ไขรายการที่โหลดจากไฟล์ PPT, PPTX หรือ ODP

โค้ด C++ ด้านล่างเปลี่ยนย่อหน้าแรกในกรอบข้อความให้ใช้สไตล์รายการลำดับเลข:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

### สามารถส่งออกรายการสัญลักษณ์หัวข้อย่อยและรายการลำดับเลขเป็น PDF หรือภาพได้หรือไม่?

ใช่ Aspose.Slides รักษารูปแบบรายการเมื่อรูปแบบเป้าหมายสนับสนุนการจัดวางข้อความและคุณลักษณะหัวข้อย่อยที่สอดคล้องกัน

### ฉันสามารถแก้ไขรายการในงานนำเสนอที่มีอยู่ได้หรือไม่?

ได้ โหลดงานนำเสนอ, เข้าถึงย่อหน้าที่ต้องการ, ตรวจสอบหรืออัพเดตการตั้งค่า [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/get_bullet/) แล้วบันทึกงานนำเสนอ

### รายการสามารถมีข้อความที่ไม่ใช่ละตินได้หรือไม่?

ได้ ข้อความรายการสามารถมีอักขระ Unicode ได้ ดังนั้นคุณสามารถสร้างรายการในงานนำเสนอหลายภาษาได้ ตรวจสอบให้แน่ใจว่าแบบอักษรที่ใช้ในงานนำเสนอสนับสนุนอักขระที่คุณต้องการ