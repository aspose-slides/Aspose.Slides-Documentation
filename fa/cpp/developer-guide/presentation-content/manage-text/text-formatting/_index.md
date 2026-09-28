---
title: قالب‌بندی متن ارائه در C++
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/cpp/text-formatting/
keywords:
- تراز پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله بین حروف
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله بین خطوط
- ویژگی خودتنظیم
- لنگر قاب متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ قالب‌بندی و سبک‌دهی کنید. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ قالب‌بندی کنید. این مقاله رنگ پس‌زمینه، شفافیت، فاصله بین حروف، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار خودتنظیم، تکیه‌گاه متن، ایستگاه‌های تب و تنظیمات زبان را پوشش می‌دهد.

مگر اینکه خلاف آن ذکر شده باشد، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید یک جعبه متن است و اولین پاراگراف آن شامل متنی است که در زیر نشان داده شده است. هر دو شاخص اسلاید و شکل به صورت صفر‑پایه هستند. مثال‌هایی که بخش‌های ضخیم را انتخاب می‌کنند از قالب‌بندی مؤثر استفاده می‌کنند، از جمله قالب‌بندی ضخیم به‌ارث‌برده‌شده:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن دقیق یا تطابق‌های عبارت منظم، به [Search and Replace Text](/slides/fa/cpp/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا از [IBasePortionFormat::get_HighlightColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/get_highlightcolor/) برای بخش‌های متنی منفرد.

مثال زیر یک برجسته‌سازی خاکستری روشن را به عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح بر بخش‌های منفرد بر پیش‌فرض اولویت دارند:

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

// تعیین رنگ برجسته برای تمام پاراگراف.
defaultPortionFormat->get_HighlightColor()->set_Color(highlightColor);

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **بخش‌های متنی با قلم ضخیم** تنظیم کنید:

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
        // تنظیم رنگ برجسته برای بخش متنی.
        portionFormat->get_HighlightColor()->set_Color(highlightColor);
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **تراز پاراگراف‌های متنی**

از [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_alignment/) برای تنظیم تراز پاراگراف داخل یک قاب متن استفاده کنید. مقدار می‌تواند centered، left‑aligned، right‑aligned، justified و غیره باشد.

کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

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

// تنظیم تراز پاراگراف به مرکز.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگ تنظیم می‌شود که از طریق [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/get_fillformat/) اختصاص داده می‌شود. در مثال‌های زیر، `alpha = 50` یک مقدار آلفا در مقیاس ۰‑۲۵۵ است، نه درصد شفافیت.

کد زیر نشان می‌دهد چگونه شفافیت را به **تمام پاراگراف** اعمال کنید:

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

// تنظیم رنگ پر متن به رنگ شفاف.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto baseColor = System::Drawing::Color::get_Black();
auto transparentColor = System::Drawing::Color::FromArgb(alpha, baseColor);
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد زیر نشان می‌دهد چگونه شفافیت را به **بخش‌های متنی با قلم ضخیم** اعمال کنید:

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
        // تنظیم شفافیت بخش متنی.
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

## **تنظیم فاصله بین حروف برای متن**

از [IBasePortionFormat::set_Spacing](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/set_spacing/) برای گسترش یا فشرده‌سازی فاصله بین حروف در یک جعبه متن استفاده کنید. مثال‌ها ۳ پوینت فاصله اضافه می‌کنند؛ مقادیر منفی فاصله را فشرده می‌کنند.

کد C++ زیر نشان می‌دهد چگونه فاصله بین حروف را در **تمام پاراگراف** گسترش دهید:

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

// توجه: برای فشرده‌سازی فاصله بین حروف از مقادیر منفی استفاده کنید.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f); // افزایش فاصله بین حروف.

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![فاصله بین حروف در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصله بین حروف را در **بخش‌های متنی با قلم ضخیم** گسترش دهید:

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
        // توجه: برای فشرده‌سازی فاصله بین حروف از مقادیر منفی استفاده کنید.
        portionFormat->set_Spacing(3.0f); // افزایش فاصله بین حروف.
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![فاصله بین حروف در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود می‌تواند کمی فشرده‌تر از همان متن در PowerPoint به نظر برسد. این ممکن است به این دلیل باشد که PowerPoint داده‌های کرنینگ برای برخی قلم‌ها را نادیده می‌گیرد، حتی زمانی که قلم حاوی اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر شده به PowerPoint در این شرایط، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم تحت تأثیر استفاده می‌کنند غیرفعال کنید. از [IBasePortionFormat::set_KerningMinimalSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/set_kerningminimalsize/) برای تنظیم مقدار بزرگتر از اندازهٔ واقعی قلم استفاده کنید. این مثال به فایل "presentation.pptx" با یک جعبه متن به عنوان اولین شکل در اولین اسلاید نیاز دارد. نام‌های قلم مؤثر، از جمله قلم‌های به‌ارث‌برده شده، بررسی می‌شوند و برای بخش‌هایی که از Roboto استفاده می‌کنند آستانهٔ ۱۰۰ پوینت تنظیم می‌شود. این کار کرنینگ را برای بخش‌های مطابقت‌دار با اندازهٔ قلم زیر ۱۰۰ پوینت غیرفعال می‌کند:

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

برای متونی که زیر آستانه هستند، این تنظیم جلوگیری از کرنینگ می‌کند و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat::get_DefaultPortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/get_defaultportionformat/) یا بر روی بخش‌های منفرد از طریق [IPortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض پاراگراف اول را به Times New Roman ۱۲ پوینت با قالب‌بندی ضخیم، ایتالیک و زیرخط نقطه‌دار تنظیم می‌کند. قالب‌بندی صریح بر بخش‌های منفرد بر این پیش‌فرض‌ها اولویت دارد:

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

// تنظیم ویژگی‌های قلم برای پاراگراف.
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

مثال زیر ۱۳ پوینت Times New Roman، قالب‌بندی ایتالیک و زیرخط نقطه‌دار را بر بخش‌هایی که قالب‌بندی مؤثر آن‌ها ضخیم است اعمال می‌کند:

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
        // تنظیم ویژگی‌های قلم برای بخش متنی.
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

## **تنظیم چرخش متن**

از [ITextFrameFormat::set_TextVerticalType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/set_textverticaltype/) برای تنظیم جهت پیش‌فرض متن در داخل یک شکل استفاده کنید.

کد زیر جهت متن در شکل را به [TextVerticalType::Vertical270](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **۹۰ درجه ضد ساعت‌گرد** می‌چرخاند:

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

## **تنظیم چرخش سفارشی برای قاب‌های متنی**

از [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/set_rotationangle/) برای تنظیم زاویهٔ چرخش سفارشی برای یک [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) استفاده کنید.

کد زیر قاب متن را درون شکل ۳ درجه ساعت‌گرد می‌چرخاند:

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

## **تنظیم فاصلهٔ خطی پاراگراف‌ها**

Aspose.Slides متدهای [IParagraphFormat::set_SpaceAfter](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_spaceafter/)، [IParagraphFormat::set_SpaceBefore](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_spacebefore/) و [IParagraphFormat::set_SpaceWithin](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_spacewithin/) را برای کنترل فاصلهٔ پاراگراف ارائه می‌دهد. این متدها به صورت زیر استفاده می‌شوند:

* برای تعیین فاصلهٔ خط به‌صورت درصدی از ارتفاع خط از مقدار مثبت استفاده کنید.
* برای تعیین فاصلهٔ خط به‌صورت پوینت از مقدار منفی استفاده کنید.

مثال زیر فاصلهٔ داخلی پاراگراف اول را به ۲۰۰٪ از ارتفاع خط (فاصلهٔ دوبل) تنظیم می‌کند:

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

![فاصلهٔ خطی داخل پاراگراف](line_spacing.png)

## **کنترل شکست خط**

قواعد شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و آسیای شرقی ترکیب می‌شوند مفید هستند. متدهای زیر متعلق به [IParagraphFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/) هستند و بر کل پاراگراف اعمال می‌شوند:

- [IParagraphFormat::set_LatinLineBreak](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_latinlinebreak/) قواعد شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند محل پیچ‌کردن متن و نقطه‌گذاری آسیای شرقی را نیز تغییر دهد.
- [IParagraphFormat::set_EastAsianLineBreak](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_eastasianlinebreak/) قواعد شکست خط آسیای شرقی را کنترل می‌کند، از جمله محدودیت‌های کاراکترهای ابتدای و انتهای خط.

این قواعد جایگزین [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/set_wraptext/) که بسته‌بندی خودکار داخل یک قاب متن را فعال می‌کند، نمی‌شوند. آنها بر چیدمان زمانی که بسته‌بندی رخ می‌دهد تأثیر می‌گذارند؛ کاراکترهای شکست خط را اضافه نمی‌کنند. یک شکست خط صریح یک خط جدید را داخل پاراگراف ایجاد می‌کند بدون توجه به عرض موجود.

مثال زیر یک بلوک متنی باریک شامل چینی و لاتین ایجاد می‌کند. هر دو قاعدهٔ شکست خط به‌صورت صریح تنظیم شده و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر قاعده، مقدار پاس‌شده به تنظیم‌کننده مربوطه را تغییر دهید در حالی که تنظیمات دیگر ثابت باقی می‌مانند. این مثال از Arial ۲۴ پوینت و SimSun با عرض قاب ۱۶۰ پوینت و حاشیه‌های افقی صفر استفاده می‌کند. [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/set_autofittype/) با [TextAutofitType::None](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازهٔ متن و ابعاد قاب ثابت بمانند.

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

## **کنترل علامت‌گذاری معلق**

[IParagraphFormat::set_HangingPunctuation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_hangingpunctuation/) به علامت‌گذاری‌های مجاز اجازه می‌دهد تا فراتر از لبهٔ راست خط متن امتداد یابند به‌جای این‌که در خط بعدی قرار گیرند. این تنظیم برای کل پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال زیر علامت‌گذاری معلق را در یک قاب متنی با عرض ۱۰۰ پوینت فعال می‌کند و «hanging_punctuation.pptx» ذخیره می‌نماید. با Arial ۲۴ پوینت و حاشیه‌های افقی صفر، نقطهٔ پایان پس از «sentence» می‌ماند و فراتر از لبهٔ راست متن امتداد می‌یابد. برای مقایسه [NullableBool::False](https://reference.aspose.com/slides/fa/cpp/aspose.slides/nullablebool/) را به تنظیم‌کننده پاس می‌دهید: با این تنظیمات، نقطه در خط جداگانه‌ای قرار می‌گیرد. بسته‌بندی فعال است و خودتنظیم غیرفعال شده تا عرض موجود ثابت بماند.

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

هر علامت‌گذاری‌ای نمی‌تواند معلق شود. نتیجهٔ قابل مشاهده به قلم و چیدمان بستگی دارد: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات خودتنظیم می‌تواند تفاوت قابل مشاهده را حذف کند.

## **تنظیم نوع خودتنظیم برای قاب‌های متنی**

[ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/set_autofittype/) تعیین می‌کند که متن وقتی از مرزهای محفظهٔ خود فراتر می‌رود چه رفتار داشته باشد. از آن برای کنترل اینکه متن کوچک شود، overflow کند یا به‌صورت خودکار شکل را تغییر اندازه دهد استفاده کنید. مثال زیر شکل را طوری پیکربندی می‌کند که برای متن خود تنظیم اندازه یابد و نتیجه را در «autofit_type.pptx» ذخیره می‌کند.

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

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهدهٔ چگونگی تغییر عرض متن یا شکل، به [Count Rendered Lines](/slides/fa/cpp/manage-paragraph/) مراجعه کنید. تنها شمارش خطوط نشانگر overflow متن نیست.

## **تنظیم نقطه تکیه‌گاه قاب‌های متنی**

[ITextFrameFormat::set_AnchoringType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/set_anchoringtype/) نحوهٔ قرارگیری عمودی متن داخل یک شکل را تعریف می‌کند، برای مثال در بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل تکیه می‌کند و نتیجه را در «text_anchor.pptx» ذخیره می‌کند.

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

از [IParagraphFormat::set_DefaultTabSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/set_defaulttabsize/) و [IParagraphFormat::get_Tabs](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/get_tabs/) برای پیکربندی ایستگاه‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصلهٔ پیش‌فرض تب را به ۱۰۰ پوینت تنظیم می‌کند و یک ایستگاه تب چپ‌تراز را در ۳۰ پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است تأثیر می‌گذارد.

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

![تب‌های پاراگراف](paragraph_tabs.png)

## **تنظیم زبان اصلاحی**

Aspose.Slides متد [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/set_languageid/) را فراهم می‌کند که به شما اجازه می‌دهد زبان اصلاحی یک بخش متنی را تنظیم کنید. زبان اصلاحی تعیین می‌کند که بررسی املا و دستور زبان در PowerPoint به کدام زبان انجام شود.

مثال زیر به «presentation.pptx» با یک جعبه متن به عنوان اولین شکل در اولین اسلاید و حداقل یک پاراگراف نیاز دارد. محتوای اولین پاراگراف را با «1。」» جایگزین می‌کند، SimSun را به‌عنوان قلم آن تنظیم می‌کند و زبان اصلاحی چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

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

// تنظیم زبان اصلاحی به چینی ساده.
portionFormat->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1。");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_defaulttextlanguage/) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ساخته می‌شود استفاده کنید. مثال زیر یک ارائه با زبان پیش‌فرض متن انگلیسی ایالات متحده ایجاد می‌کند، یک جعبه متن اضافه می‌کند و برای اولین بخش متنی `en-US` را چاپ می‌کند.

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

// Add a new rectangle shape with text.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// Check the first portion language.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto languageId = portion->get_PortionFormat()->get_LanguageId();
System::Console::WriteLine(languageId);

presentation->Dispose();
```

## **تنظیم سبک متنی پیش‌فرض**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [IPresentation::get_DefaultTextStyle](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_defaulttextstyle/) استفاده کنید.

مثال زیر یک قلم ضخیم ۱۴ پوینت را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالای یک ارائهٔ جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌کند. متن می‌تواند این پیش‌فرض‌ها را به ارث ببرد مگر اینکه قالب‌بندی خاص‌تری آن‌ها را بازنویسی کند.

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

// دریافت قالب پاراگراف سطح بالا.
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

## **استخراج متن با اثر تماماً بزرگ (All‑Caps)**

در PowerPoint، اعمال اثر **All Caps** باعث می‌شود متن روی اسلاید به حروف بزرگ نشان داده شود حتی اگر در ابتدا به حروف کوچک وارد شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides می‌خوانید، کتابخانه متن را دقیقاً همان‌طور که وارد شده برمی‌گرداند. برای هماهنگ‌سازی با متن نمایش داده‌شده، مقدار [TextCapType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textcaptype/) را بررسی کنید و وقتی مقدار آن [TextCapType::All](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textcaptype/) باشد، رشتهٔ بازگشتی را به حروف بزرگ تبدیل کنید.

این مثال به «sample2.pptx» با یک جعبه متن به عنوان اولین شکل در اولین اسلاید نیاز دارد. اولین بخش اولین پاراگراف شامل «Hello, Aspose!» با اثر All Caps است، همان‌طور که در زیر نشان داده شده.

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

## **FAQ**

**چگونه متن را در یک جدول در اسلاید ویرایش کنم؟**

برای ویرایش متن در یک جدول در اسلید، از [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) استفاده کنید. در سلول‌ها پیمایش کنید و هر سلول را از طریق [ICell::get_TextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icell/get_textframe/) و قالب‌بندی پاراگراف از طریق [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/get_paragraphformat/) به‌روزرسانی کنید.

**چگونه یک رنگ گرادیان به متن در اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [IBasePortionFormat::get_FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/get_fillformat/) استفاده کنید. [IFillFormat::set_FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifillformat/set_filltype/) را روی [FillType::Gradient](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) تنظیم کنید و سپس توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.