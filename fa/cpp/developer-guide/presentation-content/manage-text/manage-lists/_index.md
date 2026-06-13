---
title: "مدیریت فهرست‌های نقطه‌دار و شماره‌دار در ارائه‌ها با C++"
linktitle: "مدیریت فهرست‌ها"
type: docs
weight: 70
url: /fa/cpp/manage-lists/
keywords:
- "نقطه"
- "فهرست نقطه‌دار"
- "فهرست شماره‌دار"
- "نقطه نمادین"
- "نقطه تصویری"
- "نقطه سفارشی"
- "فهرست چندسطحی"
- "ایجاد نقطه"
- "افزودن نقطه"
- "افزودن فهرست"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "C++"
- "Aspose.Slides"
description: "یاد بگیرید چگونه فهرست‌های نقطه‌دار، تصویری، چندسطحی و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ ایجاد و قالب‌بندی کنید."
---
## **بررسی کلی**

Aspose.Slides برای C++ به شما امکان می‌دهد لیست‌های نقطه‌دار و شماره‌دار را در ارائه‌های PowerPoint و OpenDocument ایجاد و قالب‌بندی کنید. یک مورد لیست یک پاراگراف است که تنظیمات نقطه آن از طریق قالب‌بندی پاراگراف کنترل می‌شود.

از متد [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/get_paragraphformat/) برای دسترسی به تنظیمات لیست در سطح پاراگراف استفاده کنید. نقطه ورودی اصلی [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/get_bullet/) است که یک شیء [IBulletFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/) برمی‌گرداند. با استفاده از این شیء می‌توانید نوع نقطه، نماد، تصویر، رنگ، اندازه، سبک شماره‌گذاری و عدد شروع را تنظیم کنید.

این مقاله نشان می‌دهد چگونه:

- لیست نقطه‌دار با نماد سفارشی ایجاد کنید
- بولت تصویر ایجاد کنید
- لیست چندسطحی را با تنظیم عمق پاراگراف ایجاد کنید
- لیست شماره‌دار ایجاد کنید
- قالب‌بندی لیست را در یک ارائه موجود بازبینی و تغییر دهید

## **ایجاد لیست نقطه‌دار**

برای ایجاد لیست نقطه‌دار، اشیاء [Paragraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/paragraph/) را به یک [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) اضافه کنید و [IBulletFormat::set_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_type/) را به [BulletType::Symbol](https://reference.aspose.com/slides/fa/cpp/aspose.slides/bullettype/) تنظیم کنید. سپس می‌توانید [IBulletFormat::set_Char](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_char/)، [IBulletFormat::get_Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/get_color/) و [IBulletFormat::set_Height](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_height/) را برای کنترل ظاهر نقطه تنظیم کنید.

کد C++ زیر نشان می‌دهد چگونه یک لیست نقطه‌دار در یک اسلاید ایجاد شود:

```cpp
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

![نقطه‌های نماد](symbol_bullets.png)

## **ایجاد لیست شماره‌دار**

از لیست‌های شماره‌دار زمانی استفاده کنید که ترتیب موارد اهمیت دارد. [IBulletFormat::set_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_type/) را به [BulletType::Numbered](https://reference.aspose.com/slides/fa/cpp/aspose.slides/bullettype/) تنظیم کنید. همچنین می‌توانید با استفاده از [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) یک قالب شماره‌گذاری انتخاب کنید یا با [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) زمانی که لیست باید از مقداری غیر از 1 شروع شود، مقدار شروع را تنظیم کنید.

کد C++ زیر نشان می‌دهد چگونه یک لیست شماره‌دار در یک اسلاید ایجاد شود:

```cpp
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

![نقطه‌های شماره‌دار](numbered_bullets.png)

## **ایجاد بولت تصویر**

Aspose.Slides به شما امکان می‌دهد نماد نقطه معمولی را با یک تصویر جایگزین کنید. بولت‌های تصویری بهترین عملکرد را با تصاویر ساده‌ای که در اندازه کوچک نیز قابل خواندن هستند، مانند آیکون‌ها یا فایل‌های PNG شفاف کوچک، دارند.

{{% alert color="primary" %}}
در حالت ایده‌آل، اگر قصد دارید نماد نقطه معمولی را با یک تصویر جایگزین کنید، بهتر است یک گرافیک ساده با پس‌زمینه شفاف انتخاب کنید. چنین تصاویری به‌عنوان نمادهای سفارشی نقطه به‌خوبی عمل می‌کنند.

به‌خاطر داشته باشید که تصویر به‌صورت بسیار کوچک مقیاس خواهد یافت. به همین دلیل، قویاً توصیه می‌کنیم تصویری را برگزینید که در استفاده به‌عنوان نقطه در یک لیست واضح و بصری مؤثر باقی بماند.
{{% /alert %}}

برای ایجاد بولت تصویر، یک تصویر را به [IPresentation::get_Images](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_images/) اضافه کنید و شیء بازگشتی [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) را به [IBulletFormat::get_Picture](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/get_picture/) اختصاص دهید. قبل از اختصاص تصویر، [IBulletFormat::set_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibulletformat/set_type/) را به [BulletType::Picture](https://reference.aspose.com/slides/fa/cpp/aspose.slides/bullettype/) تنظیم کنید.

فرض کنید یک فایل «image.png» داریم:

![تصویری برای نقطه‌ها](picture_for_bullets.png)

کد C++ زیر نشان می‌دهد چگونه بولت‌های تصویری در یک اسلاید ایجاد شوند:

```cpp
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

![نقطه‌های تصویری](picture_bullets.png)

## **ایجاد لیست چندسطحی**

از [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_depth/) برای قرار دادن موارد لیست در سطوح مختلف استفاده کنید. سطح ۰ بالاترین سطح است، سطح ۱ زیر آن تو در توست و به همین ترتیب.

کد C++ زیر نشان می‌دهد چگونه یک لیست نقطه‌دار چندسطحی ایجاد شود:

```cpp
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

![لیست چندسطحی](multilevel_list.png)

## **تغییر لیست موجود**

برای تغییر قالب‌بندی لیست در یک ارائه موجود، به پاراگراف هدف دسترسی پیدا کنید و تنظیمات [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/get_bullet/) آن را به‌روزرسانی کنید. همان ویژگی‌هایی که برای ایجاد لیست‌ها استفاده می‌شوند، می‌توانند برای بازبینی یا اصلاح لیست‌های بارگذاری‌شده از فایل‌های PPT، PPTX یا ODP به کار روند.

کد C++ زیر اولین پاراگراف در یک فریم متنی را به سبک لیست شماره‌دار تغییر می‌دهد:

```cpp
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

## **سوالات متداول**

**آیا می‌توان لیست‌های نقطه‌دار و شماره‌دار را به PDF یا تصاویر صادر کرد؟**

بله. Aspose.Slides قالب‌بندی لیست را حفظ می‌کند زمانی که فرمت هدف ویژگی‌های متن و نقطه مربوطه را پشتیبانی کند.

**آیا می‌توانم لیست‌ها را در ارائه‌های موجود ویرایش کنم؟**

بله. ارائه را بارگذاری کنید، به پاراگراف هدف دسترسی پیدا کنید، تنظیمات [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/get_bullet/) آن را بازبینی یا به‌روزرسانی کنید و سپس ارائه را ذخیره کنید.

**آیا لیست‌ها می‌توانند متن‌های غیرلاتین داشته باشند؟**

بله. متن موارد لیست می‌تواند شامل کاراکترهای یونیکد باشد، بنابراین می‌توانید لیست‌ها را در ارائه‌های چند زبانه ایجاد کنید. اطمینان حاصل کنید که قلم‌های استفاده‌شده در ارائه از کاراکترهای مورد نیاز پشتیبانی می‌کنند.