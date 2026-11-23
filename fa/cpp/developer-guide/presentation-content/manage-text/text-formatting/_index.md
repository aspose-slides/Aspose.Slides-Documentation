---
title: قالب‌بندی متن ارائه در C++
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/cpp/text-formatting/
keywords:
- هم‌ترازی پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصلهٔ نویسه‌ها
- ویژگی‌های قلم
- خانوادهٔ قلم
- چرخش متن
- زاویهٔ چرخش
- قاب متن
- فاصلهٔ خطوط
- ویژگی خودکارمتناسب‌سازی
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ قالب‌بندی و استایل دهید. قلم‌ها، رنگ‌ها، هم‌ترازی و موارد بیشتر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نحوه قالب‌بندی متن در ارائه‌های PowerPoint و OpenDocument را با استفاده از Aspose.Slides برای C++ نشان می‌دهد. این مقاله شامل رنگ‌های پس‌زمینه، شفافیت، فاصلهٔ نویسه‌ها، ویژگی‌های قلم، چرخش، فاصلهٔ پاراگراف، رفتار خودکار متناسب‌سازی، لنگر متن، توقف‌های تب و تنظیمات زبان است.

مگر اینکه خلاف آن ذکر شده باشد، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید یک جعبه متن است و اولین پاراگراف آن شامل متنی است که در زیر نشان داده شده است. هر دو ایندکس اسلاید و شکل صفرپایه هستند. مثال‌هایی که بخش‌های بولد را انتخاب می‌کنند، از قالب‌بندی مؤثر شامل قالب‌بندی بولد ارث‌بری استفاده می‌کنند:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن به‌صورت دقیق یا تطبیق‌های عبارات منظم، به [جستجو و جایگزینی متن](/slides/fa/cpp/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا از [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) برای بخش‌های متنی جداگانه.

مثال زیر یک برجسته‌سازی خاکستری روشن را به عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح در بخش‌های جداگانه نسبت به این پیش‌فرض اولویت دارند:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
auto highlightColor = System::Drawing::Color::get_LightGray();

// رنگ برجسته را برای کل پاراگراف تنظیم کنید.
presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نحوه تنظیم رنگ پس‌زمینه برای **بخش‌های متنی با قلم بولد** را نشان می‌دهد:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto highlightColor = System::Drawing::Color::get_LightGray();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // رنگ برجسته را برای بخش متن تنظیم کنید.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **هم‌ترازی پاراگراف‌های متن**

از [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) برای تنظیم هم‌ترازی پاراگراف درون یک قاب متن استفاده کنید. مقدار می‌تواند مرکز، چپ‌تراز، راست‌تراز، چین‌دار و … باشد.

کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** هم‌ترازی کنید:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextAlignment.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// هم‌ترازی پاراگراف را به مرکز تنظیم کنید.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![پاراگراف هم‌تراز شده](aligned_paragraph.png)

## **هم‌ترازی قلم‌ها درون یک خط**

از [IParagraphFormat::set_FontAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_fontalignment/) برای هم‌ترازی عمودی بخش‌های متنی با اندازه‌های قلم متفاوت در یک خط استفاده کنید. این تنظیم برای کل پاراگراف اعمال می‌شود و هم‌ترازی را در هر یک از خطوط آن کنترل می‌کند.

مثال زیر یک مثال خودکفا است که چهار جعبه متن برچسب‌دار روی یک اسلاید می‌سازد. هر پاراگراف متن یکسانی را با اندازه‌های ۱۸، ۳۶ و ۵۴ پوینت دارد و هم‌ترازی قلم متفاوتی دارد. از Arial استفاده می‌کند، خودکارمتناسب‌سازی و پیچش را غیرفعال می‌کند و قاب‌ها را به اندازه‌ای بزرگ می‌گذارد که فقط یک خط را در بردارد.

```cpp
#include <DOM/FontAlignment.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

FontAlignment alignments[] = { FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom };
String labels[] = { u"Baseline", u"Top", u"Center", u"Bottom" };
float fontSizes[] = { 18.0f, 36.0f, 54.0f };
auto font = MakeObject<FontData>(u"Arial");

for (auto i = 0; i < 4; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 20 + i * 130, 660, 120);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);

    auto label = textFrame->get_Paragraph(0);
    label->set_Text(labels[i]);
    label->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto labelFormat = label->get_ParagraphFormat()->get_DefaultPortionFormat();
    labelFormat->set_FontHeight(14);
    labelFormat->set_LatinFont(font);
    labelFormat->get_FillFormat()->set_FillType(FillType::Solid);
    labelFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_FontAlignment(alignments[i]);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    auto portionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    portionFormat->set_LatinFont(font);
    portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
    portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    for (auto fontSize : fontSizes)
    {
        auto portion = MakeObject<Portion>(u"Ag ");
        portion->get_PortionFormat()->set_FontHeight(fontSize);
        paragraph->get_Portions()->Add(portion);
    }

    textFrame->get_Paragraphs()->Add(paragraph);
}

presentation->Save(u"font_alignment.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![مقایسه هم‌ترازی Baseline، Top، Center و Bottom با اندازه‌های قلم ترکیبی](font_alignment.png)

هم‌ترازی قلم بر پایهٔ معیارهای قلم است، بنابراین لبه‌های قابل مشاهدهٔ حروف لزوماً به‑دقت یک‌دیگر را تطابق نمی‌دهند. این مثال شامل یک حرف بزرگ و یک حروف پایین‌رونده است تا تفاوت بین هم‌ترازی پایه و پایین را نشان دهد. در دسترس بودن قلم و جایگزینی آن، نویسه‌های استفاده شده و تفاوت در اندازه‌های قلم بر نتیجه تأثیر می‌گذارند. ابعاد قاب، حاشیه‌ها، فاصلهٔ خطوط، پیچش و خودکارمتناسب‌سازی نیز بر چیدمان اثر می‌گذارند؛ برای مقایسه حالت‌ها از قلم‌ها و تنظیمات چیدمان یکسان استفاده کنید.

این تنظیم متفاوت از [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) است که هم‌ترازی افقی پاراگراف را کنترل می‌کند، و از [ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) که موقعیت بلوک متن را به صورت عمودی درون شکل تعیین می‌کند. قالب‌بندی سوپر و زیرنویس از طریق [IBasePortionFormat::set_Escapement](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_escapement/) بخش‌های جداگانه را نسبت به خط پایه جابه‌جا می‌کند به جای تنظیم هم‌ترازی قلم برای خطوط پاراگراف.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفهٔ آلفای رنگی که از طریق [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/) اختصاص داده می‌شود، کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار کانال آلفای ARGB بر مقیاس ۰–۲۵۵ است، نه درصد شفافیت.

کد زیر نحوه اعمال شفافیت به **تمام پاراگراف** را نشان می‌دهد:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// رنگ پر کردن متن را به رنگ شفاف تنظیم کنید.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد زیر نحوه اعمال شفافیت به **بخش‌های متنی با قلم بولد** را نشان می‌دهد:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // شفافیت بخش متن را تنظیم کنید.
        portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
        auto baseColor = System::Drawing::Color::get_Black();
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
        portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصلهٔ نویسه‌ها برای متن**

از [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_spacing/) برای افزایش یا کاهش فاصلهٔ بین نویسه‌ها در یک جعبه متن استفاده کنید. مثال‌ها ۳ پوینت فاصله اضافه می‌کنند؛ مقادیر منفی فشرده‌سازی متن را ایجاد می‌کنند.

کد زیر نشان می‌دهد چگونه فاصلهٔ نویسه‌ها را در **تمام پاراگراف** گسترش دهید:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// تذکر: برای فشرده‌سازی فاصلهٔ نویسه‌ها از مقادیر منفی استفاده کنید.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // فاصلهٔ نویسه‌ها را گسترش دهید.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![فاصلهٔ نویسه‌ها در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصلهٔ نویسه‌ها را در **بخش‌های متنی با قلم بولد** گسترش دهید:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // تذکر: برای فشرده‌سازی فاصلهٔ نویسه‌ها از مقادیر منفی استفاده کنید.
        portionFormat->set_Spacing(3.0f); // فاصلهٔ نویسه‌ها را گسترش دهید.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![فاصلهٔ نویسه‌ها در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی کرنینگ برای قلم‌های خاص**

در برخی موارد، متن رندر شده توسط Aspose.Slides ممکن است کمی فشرده‌تر از متن مشابه در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ برای برخی قلم‌ها را نادیده می‌گیرد، حتی اگر قلم شامل اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر شده به PowerPoint در این موارد، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم متاثر استفاده می‌کنند، غیرفعال کنید. از [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) برای تنظیم مقداری بزرگتر از اندازهٔ واقعی قلم استفاده کنید. این مثال به «presentation.pptx» که یک جعبه متن به عنوان اولین شکل در اولین اسلاید دارد، نیاز دارد. نام‌های قلم مؤثر، شامل قلم‌های ارث‌بری، بررسی می‌شود و آستانهٔ ۱۰۰ پوینت برای بخش‌هایی که از Roboto استفاده می‌کنند، تنظیم می‌شود. این کار کرنینگ را برای بخش‌های مطابق که اندازهٔ قلم زیر ۱۰۰ پوینت دارد، غیرفعال می‌کند:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IFontData.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
System::String targetFont = u"Roboto";
auto textFrame = autoShape->get_TextFrame();
auto paragraphs = textFrame->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto textFormat = portionFormat->GetEffective();
        auto latinFont = textFormat->get_LatinFont();
        auto eastAsianFont = textFormat->get_EastAsianFont();
        auto complexScriptFont = textFormat->get_ComplexScriptFont();

        bool isLatinFont = latinFont != nullptr && latinFont->get_FontName() == targetFont;
        bool isEastAsianFont = eastAsianFont != nullptr && eastAsianFont->get_FontName() == targetFont;
        bool isComplexScriptFont = complexScriptFont != nullptr && complexScriptFont->get_FontName() == targetFont;

        if (isLatinFont || isEastAsianFont || isComplexScriptFont)
        {
            portionFormat->set_KerningMinimalSize(100.0f);
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

برای متن‌های مطابق با آستانه، این تنظیم از کرنینگ جلوگیری می‌کند و می‌تواند کمک کند تا رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های متاثر از این رفتار خاص PowerPoint هماهنگ شود.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) یا بر روی بخش‌های جداگانه از طریق [IPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به ۱۲ پوینت Times New Roman با قالب بولد، ایتالیک و خط زیر نقطه‌دار تنظیم می‌کند. قالب‌بندی صریح بر بخش‌های جداگانه بر پیش‌فرض‌ها اولویت دارد.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// ویژگی‌های قلم را برای پاراگراف تنظیم کنید.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
auto font = System::MakeObject<FontData>(u"Times New Roman");
defaultPortionFormat->set_LatinFont(font);

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![ویژگی‌های قلم برای پاراگراف](font_properties_for_paragraph.png)

مثال زیر ۱۳ پوینت Times New Roman، قالب ایتالیک و خط زیر نقطه‌دار را بر بخش‌هایی که قالب مؤثر آن‌ها بولد است، اعمال می‌کند:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/TextUnderlineType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();
auto font = System::MakeObject<FontData>(u"Times New Roman");

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = paragraph->get_Portion(portionIndex);
    auto portionFormat = portion->get_PortionFormat();
    if (portionFormat->GetEffective()->get_FontBold())
    {
        // ویژگی‌های قلم را برای بخش متن تنظیم کنید.
        portionFormat->set_FontHeight(13.0f);
        portionFormat->set_FontItalic(NullableBool::True);
        portionFormat->set_FontUnderline(TextUnderlineType::Dotted);
        portionFormat->set_LatinFont(font);
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![ویژگی‌های قلم برای بخش‌های متنی](font_properties_for_text_portions.png)

## **کنترل نرمال‌سازی ارتفاع متن**

از [IBasePortionFormat::set_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_normaliseheight/) هنگام بازتولید تایپوگرافی الگو یا بررسی تفاوت‌های ارتفاع نویسه‌ها استفاده کنید. در PowerPoint، فعال کردن نرمال‌سازی نویسه‌های جداگانه را به صورت عمودی کشیده یا فشرده می‌کند تا ارتفاع قابل مشاهدهٔ آن‌ها درون بخش متن یکنواخت باشد. این کار تضمین نمی‌کند ارتفاع متن در قلم‌های مختلف برابر باشد.

خاصیت را به [NullableBool::True یا False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) تنظیم کنید تا نرمال‌سازی را به‌طور صریح فعال یا غیرفعال کنید. `NullableBool::NotDefined` تنظیم محلی را خالی می‌گذارد تا بخش مقدار را از پاراگراف (مثلاً از [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/)) به ارث ببرد. این به معنای `False` نیست. از [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) استفاده کنید و [IBasePortionFormatEffectiveData::get_NormaliseHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformateffectivedata/get_normaliseheight/) را بخوانید تا مقدار بولی حل‌شده را به دست آورید.

مثال خودکفا زیر به **Arial** نیاز دارد. این مثال دو بلوک متن شامل حروف بزرگ، حروف کوچک، حروف پایین‌رونده و کاراکترهای لهجه‌دار در اندازهٔ ۵۴ پوینت می‌سازد. هر دو پاراگراف به‌طور پیش‌فرض نرمال‌سازی را فعال می‌کنند. بخش بالا به‌صورت صریح آن را غیرفعال می‌کند؛ بخش پایین آن را ارث می‌برد. ابعاد قاب، حاشیه‌ها و فاصلهٔ پاراگراف یکسان هستند و پیچش و خودکارمتناسب‌سازی برای حفظ مقایسه غیرفعال هستند. مثال `False: False` و `NotDefined: True` را چاپ می‌کند و «text_height_normalization.pptx» را ذخیره می‌کند.

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

NullableBool settings[] = { NullableBool::False, NullableBool::NotDefined };

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 60 + i * 200, 660, 150);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(u"Hxgjpq ÅÉ 0123");
    textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
    textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::False);
    textFrame->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Top);
    textFrame->get_TextFrameFormat()->set_MarginTop(0);
    textFrame->get_TextFrameFormat()->set_MarginLeft(0);

    auto paragraph = textFrame->get_Paragraph(0);
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceBefore(0);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(0);
    paragraph->get_ParagraphFormat()->set_SpaceWithin(100);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_NormaliseHeight(NullableBool::True);

    auto portion = paragraph->get_Portion(0);
    auto font = MakeObject<FontData>(u"Arial");
    portion->get_PortionFormat()->set_LatinFont(font);
    portion->get_PortionFormat()->set_FontHeight(54);
    portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    portion->get_PortionFormat()->set_NormaliseHeight(settings[i]);

    Console::WriteLine(u"{0}: {1}", settings[i], portion->get_PortionFormat()->GetEffective()->get_NormaliseHeight());
}

presentation->Save(u"text_height_normalization.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

مقایسهٔ زیر از ارائه ذخیره‌شده استخراج شده است. ردیف بالایی نرمال‌سازی را غیرفعال (`False`) دارد؛ ردیف پایینی تنظیم فعال را ارث می‌برد (`NotDefined` → `True`). برای بازآفرینی این ظاهر، Arial باید نصب باشد.

![متن ۵۴ پوینت Arial با نرمال‌سازی غیرفعال در بالا و نرمال‌سازی ارث‌بری در زیر](text_height_normalization.png)

نرمال‌سازی ارتفاع نویسه‌ها را بدون تغییر مقدار [IBasePortionFormat::get_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fontheight/) (که اندازهٔ قلم را به پوینت مشخص می‌کند) تغییر می‌دهد. [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) فاصلهٔ خطوط را کنترل می‌کند، در حالی که [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) نحوهٔ تنظیم اندازهٔ متن یا محفظهٔ آن را برای پر شدن کنترل می‌کند. این تنظیمات اهداف متفاوتی دارند و می‌توانند به‌صورت مستقل بر چیدمان کلی تأثیر بگذارند. برای اطلاعات بیشتر درباره قالب‌بندی پاراگراف و ارث‌بری، به [مدیریت پاراگراف](/slides/fa/cpp/manage-paragraph/) مراجعه کنید.

## **اعمال و حذف خط‌کشی**

از [IBasePortionFormat::set_StrikethroughType](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_strikethroughtype/) بر یک بخش متنی استفاده کنید تا اصلاحات، اصطلاحات لغو شده یا قیمت‌های قبلی را بدون حذف متن اصلی نمایش دهید. برای یک یا دو خط روی متن، آن را به ترتیب به [TextStrikethroughType::Single یا Double](https://reference.aspose.com/slides/cpp/aspose.slides/textstrikethroughtype/) تنظیم کنید.

برای حذف خط‌کشی، `TextStrikethroughType::None` را اختصاص دهید. این به‌صورت صریح اثر را غیرفعال می‌کند، حتی اگر قالب‌بندی محیطی خط‌کشی داشته باشد. در مقابل، `TextStrikethroughType::NotDefined` تنظیم محلی را تعریف‌نشده می‌گذارد تا بخش قالب‌بندی را از پاراگراف به ارث ببرد. این به معنای حذف خط‌کشی نیست. از [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/) برای خواندن قالب‌بندی حاصل، از جمله مقادیر ارث‌بری، استفاده کنید.

مثال خودکفا زیر سه مقایسهٔ قیمتی ایجاد می‌کند. هر پاراگرف بخش‌های جداگانه‌ای برای برچسب، قیمت قبلی و قیمت فعلی دارد؛ بنابراین فقط قیمت قبلی تحت تأثیر قرار می‌گیرد. ردیف اول خط‌کشی را اعمال سپس حذف می‌کند؛ سایر ردیف‌ها به ترتیب خط‌کشی تک و دوخطی را حفظ می‌کنند. تغییر این خاصیت متن و قالب‌بندی دیگر، از جمله بولد بودن قیمت قبلی، را حفظ می‌کند.

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextStrikethroughType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

String labels[] = { u"None: ", u"Single: ", u"Double: " };

for (auto label : labels)
{
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Left);
    paragraph->get_ParagraphFormat()->set_SpaceAfter(20);

    auto format = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    format->set_FontHeight(28);
    auto font = MakeObject<FontData>(u"Arial");
    format->set_LatinFont(font);
    format->get_FillFormat()->set_FillType(FillType::Solid);
    format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    auto labelPortion = MakeObject<Portion>(label);
    paragraph->get_Portions()->Add(labelPortion);

    auto previousPrice = MakeObject<Portion>(u"$100");
    previousPrice->get_PortionFormat()->set_FontBold(NullableBool::True);
    paragraph->get_Portions()->Add(previousPrice);
    auto currentPrice = MakeObject<Portion>(u" → $80");
    paragraph->get_Portions()->Add(currentPrice);

    textFrame->get_Paragraphs()->Add(paragraph);
}

// اعمال خط‌کشی، سپس به‌ طور صریح آن را از اولین قیمت قبلی حذف کنید.
auto firstPriceFormat = textFrame->get_Paragraph(0)->get_Portion(1)->get_PortionFormat();
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::Single);
firstPriceFormat->set_StrikethroughType(TextStrikethroughType::None);

textFrame->get_Paragraph(1)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Single);
textFrame->get_Paragraph(2)->get_Portion(1)->get_PortionFormat()->set_StrikethroughType(TextStrikethroughType::Double);

presentation->Save(u"strikethrough.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه، از بالا به پایین: بدون خط‌کشی، خط‌کشی تک و خط‌کشی دوخطی.

![قیمت‌های قبلی بدون خط‌کشی، با خط‌کشی تک و با خط‌کشی دوخطی](strikethrough.png)


## **تنظیم چرخش متن**

از [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_textverticaltype/) برای تنظیم جهت پیش‌فرض متن درون یک شکل استفاده کنید.

کد زیر جهت متن در شکل را به [TextVerticalType::Vertical270](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **۹۰ درجه ضد ساعت‌گرد** می‌چرخاند:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![چرخش متن](text_rotation.png)

## **نمایش اعداد پشت سر هم در متن عمودی**

برای نگه‌داشتن یک عدد دورقمی به‌صورت کنار هم در یک برچسب ژاپنی عمودی، هر دو رقم را در یک بخش متنی قرار دهید و بر روی آن بخش از [IBasePortionFormat::set_Kumimoji](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_kumimoji/) استفاده کنید. مثال از [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/cpp/aspose.slides/textverticaltype/) و ۴۰ پوینت MS Gothic برای هر دو برچسب استفاده می‌کند. تنها مقدار [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) که برای بخش عددی پاس می‌شود متفاوت است.

```cpp
#include <DOM/FillType.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto addLabel = [&slide](float x, NullableBool kumimoji)
{
    auto label = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, 48, 120, 420);
    label->get_FillFormat()->set_FillType(FillType::NoFill);
    label->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto frame = label->AddTextFrame(u"");
    frame->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::EastAsianVertical);

    auto paragraph = frame->get_Paragraph(0);
    auto format = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    auto font = MakeObject<FontData>(u"MS Gothic");
    format->set_LatinFont(font);
    format->set_EastAsianFont(font);
    format->set_FontHeight(40);
    format->get_FillFormat()->set_FillType(FillType::Solid);
    format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    auto digits = MakeObject<Portion>(u"12");
    digits->get_PortionFormat()->set_Kumimoji(kumimoji);

    auto portions = paragraph->get_Portions();
    portions->Clear();
    portions->Add(MakeObject<Portion>(u"令和"));
    portions->Add(digits);
    portions->Add(MakeObject<Portion>(u"年"));
};

addLabel(120, NullableBool::True);
addLabel(360, NullableBool::False);

presentation->Save(u"vertical_date.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

در PowerPoint، برچسب چپ (`True`) ارقام را عمود و پشت سر هم بین 和 و 年 نشان می‌دهد. در برچسب راست (`False`) جفت ارقام ۹۰ درجه ساعت‌گرد می‌چرخد. کاراکترهای ژاپنی اطراف در هر دو برچسب عمود می‌مانند.

![مقایسه برچسب‌های تاریخ عمودی در PowerPoint با ارقام عمود در سمت چپ و ارقام چرخیده در سمت راست.](vertical_date.png)

## **تنظیم چرخش سفارشی برای قاب‌های متن**

از [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) برای تنظیم زاویهٔ چرخش سفارشی یک [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) استفاده کنید.

کد زیر قاب متن را به میزان ۳ درجه ساعت‌گرد درون شکل می‌چرخاند:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصلهٔ خطوط پاراگراف‌ها**

Aspose.Slides متدهای [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spaceafter/)، [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacebefore/) و [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_spacewithin/) را برای کنترل فاصلهٔ پاراگراف ارائه می‌دهد. این متدها به شرح زیر استفاده می‌شوند:

* برای تعیین فاصلهٔ خطوط به‌عنوان درصدی از ارتفاع خط، مقدار مثبت استفاده کنید.
* برای تعیین فاصلهٔ خطوط به پوینت، مقدار منفی استفاده کنید.

مثال زیر فاصلهٔ داخل اولین پاراگراف را به ۲۰۰٪ از ارتفاع خط (فاصلهٔ دوبرابر) تنظیم می‌کند:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![فاصلهٔ خطوط داخل پاراگراف](line_spacing.png)

## **کنترل شکست خط**

قواعد شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و شرق آسیا را ترکیب می‌کنند، مفید هستند. متدهای زیر متعلق به [IParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/) هستند و بنابراین بر تمام پاراگراف اعمال می‌شوند:

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) قواعد شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند محل پیچش متن شرق آسیا و علامت‌های نگارشی همجوار را نیز تغییر دهد.
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) قواعد شکست خط شرق آسیا را کنترل می‌کند، از جمله محدودیت‌های کاراکترها در ابتدا و انتهای خط.

این قواعد جایگزین [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) که پیچش خودکار را درون یک قاب متن فعال می‌سازد، نمی‌شوند. آن‌ها هنگام پیچش بر چیدمان تأثیر می‌گذارند؛ کاراکترهای شکست خط را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید را درون پاراگراف مستقل از عرض موجود ایجاد می‌کند.

مثال خودکفا زیر یک بلوک متن باریک شامل چینی و لاتین می‌سازد. هر دو قانون شکست خط به‌وضوح تنظیم می‌شوند و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر یک از قوانین، مقدار عبور به تنظیم‌کننده مربوطه را تغییر دهید در حالی که دیگر تنظیمات ثابت باقی می‌مانند. مثال از Arial ۲۴ پوینت و SimSun با عرض قاب ۱۶۰ پوینت و حاشیهٔ افقی صفر استفاده می‌کند. [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) با [TextAutofitType::None](https://reference.aspose.com/slides/cpp/aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازهٔ متن و ابعاد قاب ثابت بمانند.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 160.0f, 300.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"中文排版测试，PowerPoint 中文演示。");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
auto eastAsianFont = System::MakeObject<FontData>(u"SimSun");
portionFormat->set_EastAsianFont(eastAsianFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_LatinLineBreak(NullableBool::False);
format->set_EastAsianLineBreak(NullableBool::True);

presentation->Save(u"line_breaking.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **کنترل علائم نگارشی معلق**

[IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) اجازه می‌دهد علائم نگارشی واجد شرایط فراتر از لبهٔ راست خط متن ادامه یابند به‌جای این که در خط بعدی جای بگیرند. این تنظیم برای تمام پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال خودکفا زیر علامت‌گذاری معلق را در یک قاب متن با عرض ۱۰۰ پوینت فعال می‌کند و «hanging_punctuation.pptx» ذخیره می‌کند. با Arial ۲۴ پوینت و حاشیهٔ افقی صفر، نقطهٔ نهایی پس از «sentence» می‌ماند و فراتر از لبهٔ راست متن ادامه می‌یابد. برای مقایسه، به تنظیم‌کننده مقدار [NullableBool::False](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) را بدهید: در این حالت نقطه در خط جداگانه‌ای قرار می‌گیرد. پیچش فعال و خودکارمتناسب‌سازی غیرفعال شده‌اند تا عرض در دسترس ثابت بماند.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 200.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);
textFrame->get_TextFrameFormat()->set_MarginLeft(0);
textFrame->get_TextFrameFormat()->set_MarginRight(0);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->set_Text(u"Simple text, next sentence.");

auto format = paragraph->get_ParagraphFormat();
format->set_Alignment(TextAlignment::Left);
auto portionFormat = format->get_DefaultPortionFormat();
portionFormat->set_FontHeight(24.0f);
auto latinFont = System::MakeObject<FontData>(u"Arial");
portionFormat->set_LatinFont(latinFont);
portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
format->set_HangingPunctuation(NullableBool::True);

presentation->Save(u"hanging_punctuation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

همهٔ علائم نگارشی قابلیت معلق شدن را ندارند. شرایط قلم و چیدمان شرح داده‌شده در [کنترل شکست خط](#control-line-breaking) نیز برای این مقایسه اعمال می‌شود: تغییر قلم، عرض در دسترس، حاشیه‌ها یا تنظیمات خودکارمتناسب‌سازی می‌تواند تفاوت قابل مشاهده را از بین ببرد.

## **تنظیم نوع خودکارمتناسب‌سازی برای قاب‌های متن**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) تعیین می‌کند که متن هنگام عبور از مرزهای محفظهٔ خود چگونه رفتار کند. از آن برای کنترل این‌که آیا متن کوچک می‌شود، سرریز می‌کند یا شکل به‌صورت خودکار تغییر اندازه می‌دهد، استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متن خود تغییر اندازه دهد و نتیجه را در «autofit_type.pptx» ذخیره می‌کند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

برای شمارش خطوط پس از پیچش خودکار و مشاهدهٔ چگونگی تغییر عرض متن یا شکل، به [شمارش خطوط رندر شده](/slides/fa/cpp/manage-paragraph/) مراجعه کنید. تنها شمارش خطوط نشانگر سرریز بودن متن نیست.

## **تنظیم لنگر قاب‌های متن**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_anchoringtype/) تعیین می‌کند متن به‌صورت عمودی داخل یک شکل چگونه موقعیت‌یابی شود، به‌عنوان مثال در بالا، وسط یا پایین. مثال زیر متن را به پایین‌ترین شکل اول لنگر می‌دهد و نتیجه را در «text_anchor.pptx» ذخیره می‌کند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/TextAnchorType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم تب‌های متن**

از [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) و [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_tabs/) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر اندازه پیش‌فرض تب را به ۱۰۰ پوینت تنظیم می‌کند و یک توقف تب چپ‌تراز شده در ۳۰ پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب باشد تأثیر می‌گذارد.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITabCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TabAlignment.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![تب‌های پاراگرف](paragraph_tabs.png)

## **تنظیم زبان اصلاح املایی**

Aspose.Slides متد [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) را فراهم می‌کند که به شما امکان می‌دهد زبان اصلاح املایی برای یک بخش متنی را تنظیم کنید. زبان اصلاح املایی تعیین می‌کند کدام زبان برای بررسی املا و دستور زبان در PowerPoint استفاده شود.

مثال زیر به «presentation.pptx» که یک جعبه متن به عنوان اولین شکل در اولین اسلاید و حداقل یک پاراگراف دارد، نیاز دارد. ابتدا محتوای اولین پاراگرف را با «1。» جایگزین می‌کند، SimSun را به‌عنوان قلم آن تنظیم می‌نماید و زبان اصلاح املایی چینی ساده (`zh-CN`) را اختصاص می‌دهد. سپس نتیجه را در «proofing_language.pptx» ذخیره می‌کند:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
auto portionFormat = textPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

// زبان اصلاح املایی را به چینی ساده تنظیم کنید.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **کپی کردن متادیتا زبان**

هنگام کپی متن چندزبانه از یک الگو، هر دو شناسهٔ زبان را با استفاده از [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) و [IBasePortionFormat::set_AlternativeLanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_alternativelanguageid/) حفظ کنید. مثال خودکفا زیر یک بخش منبع با زبان انگلیسی (ایالات متحده) به عنوان زبان اصلی و فرانسوی به‌عنوان زبان جایگزین ایجاد می‌کند و متن و شناسه‌ها را به یک بخش در ارائهٔ جدید کپی می‌کند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto source = System::MakeObject<Portion>(u"Hello! Bonjour!");
source->get_PortionFormat()->set_LanguageId(u"en-US");
source->get_PortionFormat()->set_AlternativeLanguageId(u"fr-FR");

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto destination = System::MakeObject<Portion>();
destination->set_Text(source->get_Text());
destination->get_PortionFormat()->set_LanguageId(source->get_PortionFormat()->get_LanguageId());
// اگر منبع زبان جایگزین نداشته باشد، رشتهٔ null مقدار مقصد را پاک می‌کند.
destination->get_PortionFormat()->set_AlternativeLanguageId(source->get_PortionFormat()->get_AlternativeLanguageId());
paragraph->get_Portions()->Add(destination);

presentation->Save(u"copied_language_metadata.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

برای امتحان منبع بدون زبان جایگزین، اختصاص `u"fr-FR"` را حذف کنید. شناسهٔ جایگزین سپس یک رشتهٔ تهی خواهد بود و همان عبارت کپی غیاب آن را بدون وارد کردن مقدار پیش‌فرض حفظ می‌کند، حتی اگر مقصد قبلاً زبان جایگزین داشته باشد.

این شناسه‌ها متادیتای زبان را ذخیره می‌کنند. حفظ آن‌ها تعیین نمی‌کند که PowerPoint برای بررسی املا یا دستور زبان از کدام واژه‌نامه استفاده کند.

## **تنظیم زبان پیش‌فرض**

از [LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ایجاد می‌شود، استفاده کنید. مثال زیر یک ارائه با زبان پیش‌فرض متن انگلیسی (ایالات متحده) ایجاد می‌کند، یک جعبه متن اضافه می‌کند و `en-US` را برای اولین بخش متنی‌اش چاپ می‌کند.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// یک شکل مستطیل جدید با متن اضافه کنید.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// زبان اولین بخش متن را بررسی کنید.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_defaulttextstyle/) استفاده کنید.

مثال زیر یک قلم بولد ۱۴ پوینت را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالا در یک ارائه جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌کند. متن می‌تواند این پیش‌فرض‌ها را به ارث ببرد مگر اینکه قالب‌بندی خاص‌تری آنها را بازنویسی کند.

```cpp
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

// دریافت قالب پاراگراف سطح بالایی.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    auto defaultPortionFormat = paragraphFormat->get_DefaultPortionFormat();
    defaultPortionFormat->set_FontHeight(14.0f);
    defaultPortionFormat->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **استخراج متن با اثر تماماً حروف بزرگ (All-Caps)**

در PowerPoint، اعمال اثر **All Caps** به قلم باعث می‌شود متن در اسلاید با حروف بزرگ ظاهر شود حتی اگر در ابتدا با حروف کوچک نوشته شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides استخراج می‌کنید، کتابخانه متن را دقیقاً همان‌طور که وارد شده است باز می‌گرداند. برای مطابقت با متن نمایش‌داده‌شده، [TextCapType](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) را بررسی کنید و هنگام مقدار [TextCapType::All](https://reference.aspose.com/slides/cpp/aspose.slides/textcaptype/) باشد، رشتهٔ بازگشتی را به حروف بزرگ تبدیل کنید.

این مثال به «sample2.pptx» که یک جعبه متن به عنوان اولین شکل در اولین اسلاید دارد، نیاز دارد. اولین پاراگرافِ آن اولین بخشش شامل «Hello, Aspose!» با اثر All Caps اعمال‌شده است، همان‌طور که در زیر نشان داده شده است.

![اثر All Caps](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متن را با اثر **All Caps** استخراج کنید:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextCapType.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");
auto firstShape = presentation->get_Slide(0)->get_Shape(0);

auto autoShape = System::ExplicitCast<IAutoShape>(firstShape);
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

auto originalText = textPortion->get_Text();
System::Console::WriteLine(u"Original text: " + originalText);

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto uppercaseText = originalText.ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + uppercaseText);
}

presentation->Dispose();
```

خروجی:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **سوالات متداول**

**چگونه متن در یک جدول روی اسلاید را اصلاح کنم؟**

برای اصلاح متن در یک جدول روی اسلاید، از [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) استفاده کنید. سلول‌ها را بررسی کنید و هر سلول را از طریق [ICell::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) و قالب‌بندی پاراگراف از طریق [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) به‌روزرسانی کنید.

**چگونه رنگ گرادیان به متن در یک اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/get_fillformat/) استفاده کنید. [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) را به [FillType::Gradient](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) تنظیم کنید و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.

ویژگی مرتبط: [قالب‌بندی متن درون اسلایدها](/slides/fa/features/text-formatting/).