---
title: จัดการรายการหัวข้อย่อยและลำดับเลขในงานนำเสนอด้วย C++
linktitle: จัดการรายการ
type: docs
weight: 70
url: /th/cpp/manage-lists/
keywords:
- จุดหัวข้อ
- รายการแบบหัวข้อย่อย
- รายการลำดับเลข
- สัญลักษณ์หัวข้อย่อย
- หัวข้อย่อยรูปภาพ
- หัวข้อย่อยกำหนดเอง
- รายการหลายระดับ
- สร้างหัวข้อย่อย
- เพิ่มหัวข้อย่อย
- เพิ่มรายการ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบรายการหัวข้อย่อย, รูปภาพ, หลายระดับ, และลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument โดยใช้ Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides for C++ ช่วยให้คุณสร้างและจัดรูปแบบรายการที่มีหัวข้อย่อยและรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument รายการหนึ่งเป็นย่อหน้าที่การตั้งค่าหัวข้อย่อยควบคุมผ่านรูปแบบย่อหน้า

ใช้เมธอด [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) เพื่อเข้าถึงการตั้งค่ารายการระดับย่อหน้า จุดเริ่มต้นหลักคือ [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/), ซึ่งจะคืนค่าอ็อบเจ็กต์ [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) ด้วยอ็อบเจ็กต์นี้ คุณสามารถตั้งค่าประเภทหัวข้อย่อย สัญลักษณ์ รูปภาพ สี ขนาด สไตล์การลำดับเลข และเลขเริ่มต้นได้

บทความนี้แสดงวิธีการ:
- สร้างรายการที่มีหัวข้อย่อยด้วยสัญลักษณ์กำหนดเอง
- สรึงหัวข้อย่อยแบบรูปภาพ
- สร้างรายการหลายระดับโดยตั้งค่าความลึกของย่อหน้า
- สร้างรายการลำดับเลข
- ตรวจสอบและเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่
- อ่านเครื่องหมายและหมายเลขรายการจริงพร้อมข้อความย่อหน้า

## **สร้างรายการที่มีหัวข้อย่อย**

เพื่อสร้างรายการที่มีหัวข้อย่อย ให้เพิ่มอ็อบเจ็กต์ [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) ไปยัง [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) และตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) เป็น [BulletType::Symbol](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/). จากนั้นคุณสามารถตั้งค่า [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_color/), และ [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/) เพื่อควบคุมลักษณะของหัวข้อย่อยได้

โค้ด C++ ด้านล่างแสดงวิธีการสร้างรายการที่มีหัวข้อย่อยในสไลด์:

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

ใช้รายการลำดับเลขเมื่อลำดับของรายการมีความสำคัญ ตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) เป็น [BulletType::Numbered](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/). คุณยังสามารถเลือกรูปแบบการลำดับเลขด้วย [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) หรือกำหนดค่าเริ่มต้นด้วย [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) เมื่อต้องการให้รายการเริ่มจากค่าที่ไม่ใช่ 1

โค้ด C++ ด้านล่างแสดงวิธีการสร้างรายการลำดับเลขในสไลด์:

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

![หัวข้อย่อยลำดับเลข](numbered_bullets.png)

## **สร้างหัวข้อย่อยแบบรูปภาพ**

Aspose.Slides อนุญาตให้คุณแทนที่สัญลักษณ์หัวข้อย่อยปกติด้วยรูปภาพ หัวข้อย่อยแบบรูปภาพทำงานได้ดีที่สุดกับภาพที่ง่ายและยังอ่านได้เมื่อขนาดเล็ก เช่น ไอคอนหรือไฟล์ PNG โปร่งใสขนาดเล็ก

{{% alert color="info" title="Note" %}}
โดยทั่วไป หากคุณกำลังวางแผนที่จะแทนที่สัญลักษณ์หัวข้อย่อยทั่วไปด้วยรูปภาพ ควรเลือกกราฟิกง่ายที่มีพื้นหลังโปร่งแสง ภาพดังกล่าวทำงานได้ดีเป็นสัญลักษณ์หัวข้อย่อยแบบกำหนดเอง  
โปรดจำไว้ว่า รูปภาพจะถูกย่อขนาดลงเป็นขนาดเล็กมาก ด้วยเหตุนี้เราขอแนะนำอย่างยิ่งให้เลือกภาพที่ยังคงชัดเจนและมีประสิทธิภาพทางสายตาเมื่อใช้เป็นหัวข้อย่อยในรายการ
{{% /alert %}}

เพื่อสร้างหัวข้อย่อยแบบรูปภาพ ให้เพิ่มรูปภาพลงใน [IPresentation::get_Images](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_images/) และกำหนดอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) ที่คืนค่าให้กับ [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/). ตั้งค่า [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) เป็น [BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) ก่อนกำหนดรูปภาพ

สมมุติว่าเรามีไฟล์ "image.png":

![รูปภาพสำหรับหัวข้อย่อย](picture_for_bullets.png)

โค้ด C++ ด้านล่างแสดงวิธีการสร้างหัวข้อย่อยแบบรูปภาพในสไลด์:

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

![หัวข้อย่อยแบบรูปภาพ](picture_bullets.png)

## **สร้างรายการหลายระดับ**

ใช้ [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) เพื่อวางรายการในระดับที่ต่างกัน ระดับ 0 คือระดับบนสุด ระดับ 1 อยู่ด้านในระดับนั้น และต่อไป

โค้ด C++ ด้านล่างแสดงวิธีการสร้างรายการหลายระดับที่มีหัวข้อย่อย:

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

เพื่อเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่ ให้เข้าถึงย่อหน้าที่ต้องการและอัปเดตการตั้งค่า [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/) ของมัน คุณสมบัติเหล่านั้นที่ใช้ในการสร้างรายการสามารถใช้เพื่อตรวจสอบหรือแก้ไขรายการที่โหลดจากไฟล์ PPT, PPTX หรือ ODP ได้เช่นกัน

โค้ด C++ ด้านล่างเปลี่ยนย่อหน้าตัวแรกในกรอบข้อความให้ใช้สไตล์รายการลำดับเลข:

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

## **อ่านค่าหัวข้อย่อยจริง**

เมื่อสกัดเนื้อหางานนำเสนอ ให้รักษาเครื่องหมายรายการไว้คู่กับข้อความย่อหน้า เรียก [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/) และเข้าถึง [IParagraphFormatEffectiveData::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformateffectivedata/get_bullet/) เพื่อรับรูปแบบหัวข้อย่อยที่มีผลตรวจสอบ [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_type/) ก่อนอ่าน [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/)

สำหรับรายการลำดับเลข ให้แยกแยะค่าสามค่าเหล่านี้:
- [get_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstyle/) กำหนดรูปแบบ เช่น ตัวเลขอาหรับตามด้วยจุด หรืออักษรเล็กตามด้วยจุด
- [get_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstartwith/) ระบุเลขเริ่มต้นสำหรับกลุ่มย่อหน้าที่เป็นลำดับเลข
- [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) คืนค่าเครื่องหมายที่จัดรูปแบบสำหรับย่อหน้าที่กำหนด ตัวอย่าง รายการที่สองในรายการที่เริ่มที่ 5 จะคืนค่า `6.`

เก็บรักษา [IParagraphFormat::get_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_depth/) กับแต่ละย่อหน้าเพื่อคงระดับการซ้อนกันของมัน เครื่องหมายจริงไม่ได้เข้ารหัสลำดับชั้นทั้งหมด: รายการที่ซ้อนอาจคืนค่า `c.` แทนการรวมเป็นป้ายเช่น `6.c.`

ตัวอย่างที่ทำงานอิสระต่อไปนี้สร้างรายการ บันทึกลงงานนำเสนอ และโหลดงานนำเสนอใหม่เพื่อรายงานข้อความย่อหน้า ความลึก ประเภทหัวข้อย่อยและค่าจริงของแต่ละรายการ สัญลักษณ์รูปภาพสีน้ำเงินขนาดเล็กสร้างจาก SVG ภายใน

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IBulletFormatEffectiveData.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

{
    auto presentation = System::MakeObject<Presentation>();
    presentation->get_SlideSize()->SetSize(720, 440, SlideSizeScaleType::DoNotScale);
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->get_Paragraphs()->Clear();

    // สร้างเครื่องหมายรูปภาพโดยไม่ใช้ไฟล์ภาพภายนอก.
    auto svg = System::MakeObject<SvgImage>(u"<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    auto bulletImage = presentation->get_Images()->AddImage(svg);

    auto addParagraph = [&](System::String text, int16_t depth, BulletType type, int16_t start = 1, NumberedBulletStyle style = NumberedBulletStyle::BulletArabicPeriod)
    {
        auto paragraph = System::MakeObject<Paragraph>();
        paragraph->set_Text(text);

        auto format = paragraph->get_ParagraphFormat();
        format->set_Depth(depth);
        format->set_MarginLeft(30 + depth * 40);
        format->set_Indent(-28);
        format->set_SpaceAfter(8);
        format->get_DefaultPortionFormat()->set_FontHeight(22);
        format->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        format->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
        auto bullet = format->get_Bullet();
        bullet->set_Type(type);
        bullet->set_IsBulletHardColor(NullableBool::True);
        bullet->get_Color()->set_Color(Color::get_Black());
        if (type == BulletType::Numbered)
        {
            bullet->set_NumberedBulletStyle(style);
            bullet->set_NumberedBulletStartWith(start);
        }
        else if (type == BulletType::Symbol)
        {
            bullet->set_Char(u'\u2022');
        }
        else if (type == BulletType::Picture)
        {
            bullet->get_Picture()->set_Image(bulletImage);
        }

        textFrame->get_Paragraphs()->Add(paragraph);
    };

    addParagraph(u"First item", 0, BulletType::Numbered, 5);
    addParagraph(u"Second item", 0, BulletType::Numbered, 5);
    addParagraph(u"Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    addParagraph(u"Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    addParagraph(u"Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    addParagraph(u"Back to top level", 0, BulletType::Numbered, 5);
    addParagraph(u"Symbol marker", 0, BulletType::Symbol);
    addParagraph(u"No bullet", 0, BulletType::None);
    addParagraph(u"Picture marker", 0, BulletType::Picture);
    presentation->Save(u"actual_bullet_values.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}

auto loadedPresentation = System::MakeObject<Presentation>(u"actual_bullet_values.pptx");
auto loadedShape = System::ExplicitCast<IAutoShape>(loadedPresentation->get_Slide(0)->get_Shape(0));
System::Console::WriteLine(u"Text | Depth | Type | Actual value");
for (auto paragraph : loadedShape->get_TextFrame()->get_Paragraphs())
{
    auto bullet = paragraph->get_ParagraphFormat()->GetEffective()->get_Bullet();
    auto actualValue = bullet->get_ActualBulletValue();
    System::String marker;
    switch (bullet->get_Type())
    {
        case BulletType::Numbered:
        case BulletType::Symbol:
            marker = actualValue;
            break;
        case BulletType::None:
            marker = (actualValue.IsNull() ? System::String(u"null") : actualValue) + u" (no bullet)";
            break;
        case BulletType::Picture:
            marker = (actualValue.IsNull() ? System::String(u"null") : actualValue) + u" (image required)";
            break;
        default:
            marker = u"unsupported bullet type";
            break;
    }
    System::Console::WriteLine(u"{0} | {1} | {2} | {3}", paragraph->get_Text(), paragraph->get_ParagraphFormat()->get_Depth(), bullet->get_Type(), marker);
}
loadedPresentation->Dispose();
```

รายการต้นฉบับแสดงด้านล่าง.

![รายการเริ่มที่ 5 รายการย่อยตัวอักษรและโรมัน สัญลักษณ์สัญลักษณ์ ย่อหน้าที่ไม่มีหัวข้อย่อย และสัญลักษณ์รูปภาพสีฟ้า](actual_bullet_values.png)

รายงานตรงกับเครื่องหมายที่แสดงใน PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

สำหรับ [BulletType::None and BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) , [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) คืนค่า `System::String` เป็น null ไม่ใช่สตริงว่าง ใช้ `IsNull` เพื่อตรวจสอบค่าดังกล่าว จัดการประเภทเหล่านี้แยกกัน: ตัวแรกไม่มีเครื่องหมาย ในขณะที่ตัวหลังต้องดึงรูปภาพหัวข้อย่อยออกมาแยกต่างหาก หัวข้อย่อยแบบรูปภาพไม่สามารถทำซ้ำได้โดยการสกัดเครื่องหมายข้อความอย่างเดียว

## **คำถามที่พบบ่อย**

**Can bulleted and numbered lists be exported to PDF or images?**

Yes. Aspose.Slides preserves list formatting when the target format supports the corresponding text layout and bullet features.

**Can I edit lists in existing presentations?**

Yes. Load the presentation, access the target paragraph, inspect or update its [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/) settings, and save the presentation.

**Can lists contain non-Latin text?**

Yes. List item text can contain Unicode characters, so you can create lists in multilingual presentations. Make sure the fonts used in the presentation support the characters you need.