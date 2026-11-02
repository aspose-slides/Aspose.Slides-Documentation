---
title: "مدیریت فهرست‌های بولت‌دار و شماره‌دار در ارائه‌ها با C++"
linktitle: "مدیریت فهرست‌ها"
type: docs
weight: 70
url: /fa/cpp/manage-lists/
keywords:
- "بولت"
- "فهرست بولت‌دار"
- "فهرست شماره‌دار"
- "بولت نمادین"
- "بولت تصویری"
- "بولت سفارشی"
- "فهرست چندسطحی"
- "ایجاد بولت"
- "افزودن بولت"
- "افزودن فهرست"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "C++"
- "Aspose.Slides"
description: "بیاموزید چگونه فهرست‌های بولت‌دار، تصویری، چندسطحی و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ ایجاد و قالب‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides برای C++ به شما امکان ایجاد و قالب‌بندی فهرست‌های بولت‌دار و شماره‌دار در ارائه‌های PowerPoint و OpenDocument را می‌دهد. یک مورد فهرست یک پاراگراف است که تنظیمات بولت آن از طریق قالب‌بندی پاراگراف کنترل می‌شود.

از متد [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) برای دسترسی به تنظیمات فهرست در سطح پاراگراف استفاده کنید. نقطه ورودی اصلی [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/) است که یک شیء [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) برمی‌گرداند. با این شیء می‌توانید نوع بولٹ، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شماره شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- ایجاد یک فهرست بولت‌دار با نماد سفارشی
- ایجاد یک بولت تصویری
- ایجاد فهرست چندسطحی با تنظیم عمق پاراگراف
- ایجاد فهرست شماره‌دار
- بازرسی و تغییر قالب‌بندی فهرست در یک ارائه موجود
- خواندن نشانگرها و شماره‌های واقعی فهرست همراه با متن پاراگراف

## **ایجاد فهرست بولت‌دار**

برای ایجاد یک فهرست بولت‌دار، اشیاء [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) را به یک [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) اضافه کنید و [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) را به [BulletType::Symbol](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/)، [IBulletFormat::get_Color](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_color/) و [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/) را برای کنترل ظاهر بولت تنظیم کنید.

کد C++ زیر نحوه ایجاد فهرست بولت‌دار در یک اسلاید را نشان می‌دهد:

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

نتیجه:

![بولت‌های نمادین](symbol_bullets.png)

## **ایجاد فهرست شماره‌دار**

از فهرست‌های شماره‌دار زمانی استفاده کنید که ترتیب موارد مهم باشد. [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) را به [BulletType::Numbered](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) تنظیم کنید. همچنین می‌توانید با [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) یک قالب شماره‌گذاری انتخاب کنید یا با [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) زمانی که فهرست باید از مقداری غیر از 1 شروع شود، مقدار شروع را تنظیم کنید.

کد C++ زیر نشان می‌دهد چگونه فهرست شماره‌دار در یک اسلاید ایجاد شود:

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

نتیجه:

![بولت‌های شماره‌دار](numbered_bullets.png)

## **ایجاد بولت تصویری**

Aspose.Slides به شما اجازه می‌دهد نماد بولت معمولی را با یک تصویر جایگزین کنید. بولت‌های تصویری بهترین عملکرد را با تصاویر ساده‌ای دارند که در اندازه کوچک نیز قابل خواندن باشند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک.

{{% alert color="info" title="Note" %}}
در حالت ایده‌آل، اگر قصد دارید نماد بولت معمولی را با یک تصویر جایگزین کنید، بهتر است یک گرافیک ساده با پس‌زمینه شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای بولت سفارشی به خوبی کار می‌کنند.
{{% /alert %}}

برای ایجاد یک بولت تصویری، یک تصویر را به [IPresentation::get_Images](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_images/) اضافه کنید و شیء [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) برگردانده‌شده را به [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/) اختصاص دهید. پیش از اختصاص تصویر، [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) را به [BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) تنظیم کنید.

فرض کنید فایلی به نام "image.png" داریم:

![تصویری برای بولت‌ها](picture_for_bullets.png)

کد C++ زیر نشان می‌دهد چگونه بولت‌های تصویری در یک اسلاید ایجاد شود:

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

نتیجه:

![بولت‌های تصویری](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیر آن تو در تو است و به همین ترتیب.

کد C++ زیر نشان می‌دهد چگونه فهرست بولت‌دار چندسطحی ایجاد شود:

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

نتیجه:

![فهرست چندسطحی](multilevel_list.png)

## **تغییر فهرست موجود**

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، پاراگراف هدف را دسترسی کنید و تنظیمات [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/) آن را به‌روزرسانی کنید. همان ویژگی‌هایی که برای ایجاد فهرست‌ها استفاده می‌شوند، می‌توانند برای بازرسی یا اصلاح فهرست‌های بارگذاری شده از فایل‌های PPT، PPTX یا ODP به کار روند.

کد C++ زیر اولین پاراگراف در یک فریم متن را به استفاده از سبک فهرست شماره‌دار تغییر می‌دهد:

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

## **خواندن مقادیر واقعی بولت**

هنگام استخراج محتوای ارائه، نشانگرهای فهرست را همراه با متن پاراگراف نگه دارید. با فراخوانی [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/) و دسترسی به [IParagraphFormatEffectiveData::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformateffectivedata/get_bullet/) قالب بولت مؤثر به‌دست می‌آید. قبل از خواندن [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) ویژگی [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_type/) را بررسی کنید.

برای فهرست‌های شماره‌دار، این سه مقدار را متمایز کنید:

- [get_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstyle/) قالب را تعیین می‌کند، مثلاً اعداد عربی به‌علاوه نقطه یا حروف کوچک لاتین به‌علاوه نقطه.
- [get_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstartwith/) شماره شروع برای یک گروه از پاراگراف‌های شماره‌دار را مشخص می‌کند.
- [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) نشانگر قالب‌بندی‌شده برای یک پاراگراف خاص را برمی‌گرداند. به عنوان مثال، دومین مورد در فهرستی که از 5 شروع می‌شود، `6.` را برمی‌گرداند.

با هر پاراگراف [IParagraphFormat::get_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_depth/) را حفظ کنید تا سطح تو در توی آن حفظ شود. نشانگر واقعی تمام سلسله‌مراتب را کدگذاری نمی‌کند: یک مورد تو در تو می‌تواند `c.` را به‌جای برچسب ترکیبی مانند `6.c.` برگرداند.

مثال خود‑کافی زیر فهرست‌ها را ایجاد می‌کند، آن‌ها را در یک ارائه ذخیره می‌کند و پس از بارگذاری مجدد، متن، عمق، نوع بولت و مقدار واقعی هر پاراگراف را گزارش می‌دهد. علامت تصویری کوچک آبی از SVG درون‌خطی ساخته شده است.

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

    // یک علامت تصویری بدون استفاده از فایل تصویر خارجی ایجاد کنید.
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

فهرست‌های منبع در زیر نشان داده شده‌اند.

![فهرست‌ها که از 5 شروع می‌شوند، آیتم‌های حروف تو در تو و اعداد رومی، یک علامت نمادین، یک پاراگراف بدون بولت، و یک علامت تصویری آبی](actual_bullet_values.png)

گزارش با نشانگرهای نمایش داده‌شده در PowerPoint مطابقت دارد:

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

برای [BulletType::None و BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/)، [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) یک `System::String` تهی برمی‌گرداند، نه یک رشته خالی. برای بررسی این مقدار از `IsNull` استفاده کنید. این انواع را به‌صورت جداگانه مدیریت کنید: اولین مورد نشانگری ندارد، در حالی که دومین مورد نیاز به استخراج تصویر بولت به‌صورت مجزا دارد. یک بولت تصویری نمی‌تواند تنها با استخراج نشانگر متن بازتولید شود.

## **سوالات متداول**

**آیا فهرست‌های بولت‌دار و شماره‌دار می‌توانند به PDF یا تصویر صادر شوند؟**

بله. Aspose.Slides قالب‌بندی فهرست را زمانی که قالب هدف از چینش متن و ویژگی‌های بولت مربوطه پشتیبانی کند، حفظ می‌کند.

**آیا می‌توانم فهرست‌ها را در ارائه‌های موجود ویرایش کنم؟**

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/) آن را بازرسی یا به‌روزرسانی کنید و سپس ارائه را ذخیره نمایید.

**آیا فهرست‌ها می‌توانند متن غیرلاتین داشته باشند؟**

بله. متن مورد فهرست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید که قلم‌های مورد استفاده در ارائه کاراکترهای مورد نیاز شما را پشتیبانی کنند.