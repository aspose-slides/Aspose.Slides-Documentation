---
title: مدیریت فهرست‌های نقطه‌ای و عددی در ارائه‌ها در C++
linktitle: مدیریت فهرست‌ها
type: docs
weight: 70
url: /fa/cpp/manage-lists/
keywords:
- نقطه
- فهرست نقطه‌ای
- فهرست عددی
- نقطه نمادین
- نقطه تصویری
- نقطه سفارشی
- فهرست چندسطحی
- ایجاد نقطه
- افزودن نقطه
- افزودن فهرست
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه فهرست‌های نقطه‌ای، تصویری، چندسطحی و عددی را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ ایجاد و قالب‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides for C++ به شما امکان می‌دهد فهرست‌های نقطه‌ای و عددی را در ارائه‌های PowerPoint و OpenDocument ایجاد و قالب‌بندی کنید. یک مورد فهرست یک پاراگراف است که تنظیمات نقطه‌گذاری آن از طریق قالب‌بندی پاراگراف کنترل می‌شود.

از متد [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/get_paragraphformat/) برای دسترسی به تنظیمات فهرست سطح پاراگراف استفاده کنید. نقطه ورودی اصلی [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/get_bullet/) است که یک شیء [IBulletFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/) برمی‌گرداند. با این شیء می‌توانید نوع نقطه، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و شماره شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- یک فهرست نقطه‌ای با نماد سفارشی ایجاد کنید
- یک نقطه تصویری ایجاد کنید
- با تنظیم عمق پاراگراف یک فهرست چندسطحی ایجاد کنید
- یک فهرست عددی ایجاد کنید
- قالب‌بندی فهرست موجود در یک ارائه را بررسی و تغییر دهید

## **ایجاد فهرست نقطه‌ای**

برای ایجاد فهرست نقطه‌ای، شیءهای [Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraph/) را به یک [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) اضافه کنید و [IBulletFormat::set_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_type/) را به [BulletType::Symbol](https://reference.aspose.com/slides/fa/cpp/aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید [IBulletFormat::set_Char](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_char/)، [IBulletFormat::get_Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/get_color/) و [IBulletFormat::set_Height](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_height/) را برای کنترل ظاهر نقطه تنظیم نمایید.

کد C++ زیر نحوه ایجاد فهرست نقطه‌ای در یک اسلاید را نشان می‌دهد:

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

![The symbol bullets](symbol_bullets.png)

## **ایجاد فهرست عددی**

از فهرست‌های عددی زمانی استفاده کنید که ترتیب موارد مهم باشد. [IBulletFormat::set_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_type/) را به [BulletType::Numbered](https://reference.aspose.com/slides/fa/cpp/aspose.slides/bullettype/) تنظیم کنید. همچنین می‌توانید قالب شماره‌گذاری را با [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) انتخاب کنید یا زمانی که فهرست باید از مقداری غیر از 1 شروع شود، [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) را تنظیم کنید.

کد C++ زیر نحوه ایجاد فهرست عددی در یک اسلاید را نشان می‌دهد:

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

![The numbered bullets](numbered_bullets.png)

## **ایجاد نقطه تصویری**

Aspose.Slides به شما اجازه می‌دهد نماد نقطه عادی را با تصویر جایگزین کنید. نقطه‌های تصویری بهترین کارایی را با تصاویری ساده که در اندازه کوچک نیز قابل خواندن باشند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک، دارند.

{{% alert color="info" %}}
در ideal، اگر قصد دارید نماد نقطه عادی را با تصویر جایگزین کنید، بهتر است گرافیک ساده‌ای با پس‌زمینه شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای نقطه سفارشی به‌خوبی عمل می‌کنند.
{{% /alert %}}

برای ایجاد نقطه تصویری، یک تصویر را به [IPresentation::get_Images](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_images/) اضافه کنید و شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) بازگشتی را به [IBulletFormat::get_Picture](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/get_picture/) اختصاص دهید. قبل از اختصاص تصویر، [IBulletFormat::set_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_type/) را به [BulletType::Picture](https://reference.aspose.com/slides/fa/cpp/aspose.slides/bullettype/) تنظیم کنید.

فرض کنید فایل «image.png» داریم:

![A picture for the bullets](picture_for_bullets.png)

کد C++ زیر نحوه ایجاد نقطه‌های تصویری در یک اسلاید را نشان می‌دهد:

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

![The picture bullets](picture_bullets.png)

## **ایجاد فهرست چندسطحی**

از [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_depth/) برای قرار دادن موارد فهرست در سطوح مختلف استفاده کنید. سطح 0 بالاترین سطح است، سطح 1 زیر آن تو در تو می‌شود و به همین ترتیب.

کد C++ زیر نحوه ایجاد فهرست نقطه‌ای چندسطحی را نشان می‌دهد:

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

![The multilevel list](multilevel_list.png)

## **تغییر فهرست موجود**

برای تغییر قالب‌بندی فهرست در یک ارائه موجود، به پاراگراف هدف دسترسی پیدا کرده و تنظیمات [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/get_bullet/) آن را به‌روزرسانی کنید. همان خصوصیت‌هایی که برای ایجاد فهرست‌ها استفاده می‌شوند، می‌توانند برای بررسی یا اصلاح فهرست‌های بارگذاری‌شده از فایل‌های PPT، PPTX یا ODP به‌کار روند.

کد C++ زیر اولین پاراگراف در یک فریم متن را طوری تغییر می‌دهد که از سبک فهرست عددی استفاده کند:

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

## **سؤالات متداول**

### آیا می‌توان فهرست‌های نقطه‌ای و عددی را به PDF یا تصاویر صادر کرد؟

بله. Aspose.Slides قالب‌بندی فهرست را حفظ می‌کند وقتی قالب هدف ویژگی‌های متن و نقطه مربوطه را پشتیبانی کند.

### آیا می‌توان فهرست‌ها را در ارائه‌های موجود ویرایش کرد؟

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/get_bullet/) آن را بررسی یا به‌روزرسانی کنید و سپس ارائه را ذخیره کنید.

### آیا فهرست‌ها می‌توانند متن غیرلاتین داشته باشند؟

بله. متن موارد فهرست می‌تواند کاراکترهای یونیکد داشته باشد، بنابراین می‌توانید فهرست‌ها را در ارائه‌های چندزبانه ایجاد کنید. اطمینان حاصل کنید که فونت‌های مورد استفاده در ارائه، کاراکترهای مورد نیاز شما را پشتیبانی می‌کنند.