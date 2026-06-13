---
title: "قالب‌بندی متن ارائه در C++"
linktitle: "قالب‌بندی متن"
type: docs
weight: 50
url: /fa/cpp/text-formatting/
keywords:
  - "متن برجسته"
  - "عبارت منظم"
  - "تراز پاراگراف"
  - "سبک متن"
  - "پس‌زمینه متن"
  - "شفافیت متن"
  - "فاصله کاراکتر"
  - "ویژگی‌های قلم"
  - "خانواده قلم"
  - "چرخش متن"
  - "زاویه چرخش"
  - "قاب متن"
  - "فاصله خط"
  - "ویژگی Autofit"
  - "لنگر قاب متن"
  - "تب‌بندی متن"
  - "زبان پیش‌فرض"
  - "PowerPoint"
  - "OpenDocument"
  - "ارائه"
  - "C++"
  - "Aspose.Slides"
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ قالب‌بندی و استایل‌دهی کنید. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ قالب‌بندی کنید. این مقاله به برجسته‌سازی، رنگ‌های پس‌زمینه، شفافیت، فاصله‌گذاری کاراکترها، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار Autofit، لنگر متن، توقف‌های تب و تنظیمات زبان می‌پردازد.

در مثال‌های زیر، از فایلی به نام "sample.pptx" استفاده خواهیم کرد که حاوی یک جعبه متن واحد در اسلاید اول با متن زیر است:

![متن نمونه](sample_text.png)

## **برجسته‌سازی متن**

از روش [ITextFrame.HighlightText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlighttext/) زمانی که نیاز دارید متنی که با یک نمونه خاص در چارچوب متن مطابقت دارد را برجسته کنید، استفاده کنید. این روش رنگ برجسته را به بخش‌های متن مطابق اعمال می‌کند و می‌تواند همراه با [ITextSearchOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextsearchoptions/) برای کنترل نحوه جستجو استفاده شود، به‌عنوان مثال برای مطابقت تنها با کلمات کامل.

کد مثال زیر تمام وقوع‌های کاراکترهای **"try"** را برجسته می‌کند و سپس فقط کلمه کامل **"to"** را برجسته می‌نماید.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

// دریافت اولین شکل از اولین اسلاید.
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// برجسته‌سازی کلمه "try" در شکل.
shape->get_TextFrame()->HighlightText(u"try", System::Drawing::Color::get_LightBlue());

auto searchOptions = System::MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);

// برجسته‌سازی کلمه "to" در شکل.
shape->get_TextFrame()->HighlightText(u"to", System::Drawing::Color::get_Violet(), searchOptions, nullptr);

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![متن برجسته شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

روش [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/highlightregex/) متونی که توسط عبارت منظم یافت می‌شوند را برجسته می‌کند. در C++، این API بر روی [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) در دسترس است.

کد مثال زیر تمام کلماتی که شامل **هفت یا بیشتر کاراکتر** هستند را برجسته می‌کند:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto regex = System::MakeObject<System::Text::RegularExpressions::Regex>(u"\\b[^\\s]{7,}\\b");

// برجسته‌سازی تمام کلمات با هفت یا بیشتر کاراکتر.
shape->get_TextFrame()->HighlightRegex(regex, System::Drawing::Color::get_Yellow(), nullptr);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![متن برجسته شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **تنظیم رنگ پس‌زمینه متن**

از [IParagraphFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` برای تنظیم رنگ برجسته پیش‌فرض برای یک پاراگراف استفاده کنید، یا از [IPortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformat/)`.HighlightColor` برای بخش‌های متن تک‌تک استفاده کنید.

کد مثال زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **کل پاراگراف** تنظیم کنید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// Set the highlight color for the entire paragraph.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());

presentation->Save(u"gray_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

کد مثال زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **بخش‌های متن با قلم بولد** تنظیم کنید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // رنگ برجسته را برای بخش متن تنظیم کنید.
        portion->get_PortionFormat()->get_HighlightColor()->set_Color(System::Drawing::Color::get_LightGray());
    }
}

presentation->Save(u"gray_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![بخش‌های متن خاکستری](gray_text_portions.png)

## **تراز کردن پاراگراف‌های متن**

از [IParagraphFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/)`.Alignment` برای تنظیم تراز پاراگراف درون یک چارچوب متن استفاده کنید. مقدار می‌تواند به‌صورت مرکزی، چپ‌چین، راست‌چین، هم‌تراز و غیره باشد.

کد مثال زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// تنظیم تراز پاراگراف به مرکز.
paragraph->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);

presentation->Save(u"aligned_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگ اختصاص یافته به [IPortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformat/)`.FillFormat` کنترل می‌شود. در مثال‌های زیر، `alpha = 50` یک مقدار آلفا کانال ARGB در مقیاس 0‑255 است، نه درصد شفافیت.

کد مثال زیر نشان می‌دهد چگونه شفافیت را برای **کل پاراگراف** اعمال کنید:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// تنظیم رنگ پر کردن متن به رنگ شفاف.
defaultPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
defaultPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);

presentation->Save(u"transparent_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد مثال زیر نشان می‌دهد چگونه شفافیت را برای **بخش‌های متن با قلم بولد** اعمال کنید:

```cpp
int alpha = 50;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // تنظیم شفافیت بخش متن.
        portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        auto transparentColor = System::Drawing::Color::FromArgb(alpha, System::Drawing::Color::get_Black());
        portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(transparentColor);
    }
}

presentation->Save(u"transparent_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![بخش‌های متن شفاف](transparent_text_portions.png)

## **تنظیم فاصله کاراکتر برای متن**

از [IBasePortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseportionformat/)`.Spacing` برای گسترش یا فشرده‌سازی فاصله بین کاراکترها در یک جعبه متن استفاده کنید.

کد C++ زیر نشان می‌دهد چگونه فاصله کاراکتر را در **کل پاراگراف** گسترش دهید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

// توجه: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_Spacing(3.0f);

presentation->Save(u"character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![فاصله کاراکتر در پاراگراف](character_spacing_in_paragraph.png)

کد مثال زیر نشان می‌دهد چگونه فاصله کاراکتر را در **بخش‌های متن با قلم بولد** گسترش دهید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // توجه: برای فشرده‌سازی فاصله کاراکتر از مقادیر منفی استفاده کنید.
        portion->get_PortionFormat()->set_Spacing(3.0f);
    }
}

presentation->Save(u"character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![فاصله کاراکتر در بخش‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از همان متن در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint ممکن است داده‌های کرنینگ را برای برخی قلم‌ها نادیده بگیرد، حتی اگر قلم دارای اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم تحت‌تأثر استفاده می‌کنند، غیرفعال کنید. [IPortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformat/)`.KerningMinimalSize` را به مقداری بسیار بزرگ‌تر از اندازه واقعی قلم تنظیم کنید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
System::String targetFont = u"Roboto";
auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
int paragraphCount = paragraphs->get_Count();

for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = paragraphs->idx_get(paragraphIndex);
    auto portions = paragraph->get_Portions();
    int portionCount = portions->get_Count();

    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = portions->idx_get(portionIndex);
        auto portionFormat = portion->get_PortionFormat();
        auto latinFont = portionFormat->get_LatinFont();
        auto eastAsianFont = portionFormat->get_EastAsianFont();
        auto complexScriptFont = portionFormat->get_ComplexScriptFont();

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

این تنظیم مانع اعمال کرنینگ بر روی بخش‌های متن مطابق می‌شود و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت‌تأثر توسط این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [IParagraphFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/)`.DefaultPortionFormat` یا در بخش‌های تک‌تک از طریق [IPortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformat/) تنظیم شوند.

کد زیر قلم و سبک متن را برای **کل پاراگراف** تنظیم می‌کند: اندازه قلم، بولد، ایتالیک، زیرخط نقطه‌دار و قلم Times New Roman را برای تمام بخش‌های پاراگراف اعمال می‌کند.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto defaultPortionFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();

// تنظیم ویژگی‌های قلم برای پاراگراف.
defaultPortionFormat->set_FontHeight(12.0f);
defaultPortionFormat->set_FontBold(NullableBool::True);
defaultPortionFormat->set_FontItalic(NullableBool::True);
defaultPortionFormat->set_FontUnderline(TextUnderlineType::Dotted);
defaultPortionFormat->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));

presentation->Save(u"font_properties_for_paragraph.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![ویژگی‌های قلم برای پاراگراف](font_properties_for_paragraph.png)

کد مثال زیر ویژگی‌های مشابهی را برای **بخش‌های متن با قلم بولد** اعمال می‌کند:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
auto portions = paragraph->get_Portions();
int portionCount = portions->get_Count();

for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
{
    auto portion = portions->idx_get(portionIndex);
    if (portion->get_PortionFormat()->GetEffective()->get_FontBold())
    {
        // تنظیم ویژگی‌های قلم برای بخش متن.
        portion->get_PortionFormat()->set_FontHeight(13.0f);
        portion->get_PortionFormat()->set_FontItalic(NullableBool::True);
        portion->get_PortionFormat()->set_FontUnderline(TextUnderlineType::Dotted);
        portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"Times New Roman"));
    }
}

presentation->Save(u"font_properties_for_text_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![ویژگی‌های قلم برای بخش‌های متن](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/)`.TextVerticalType` برای تنظیم جهت متن از پیش تعریف شده درون یک شکل استفاده کنید.

کد مثال زیر جهت متن در شکل را به `Vertical270` تنظیم می‌کند که متن را **90 درجه خلاف جهت ساعت‌گرد** می‌چرخاند:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای فریم‌های متن**

از [ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/)`.RotationAngle` برای تنظیم زاویه چرخش سفارشی برای یک [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) استفاده کنید.

کد مثال زیر فریم متن را به‌صورت ساعت‌گرد 3 درجه درون شکل می‌چرخاند:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_RotationAngle(3.0f);

presentation->Save(u"custom_text_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله خط پاراگراف‌ها**

Aspose.Slides [IParagraphFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/)`.SpaceAfter`، `IParagraphFormat.SpaceBefore` و `IParagraphFormat.SpaceWithin` را برای کنترل فاصله پاراگراف‌ها فراهم می‌کند. این خصوصیات به‌صورت زیر استفاده می‌شوند:

* از مقدار مثبت برای تعیین فاصله خط به عنوان درصدی از ارتفاع خط استفاده کنید.
* از مقدار منفی برای تعیین فاصله خط بر حسب پوینت استفاده کنید.

کد مثال زیر نشان می‌دهد چگونه فاصله خط را درون پاراگراف مشخص کنید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_SpaceWithin(200.0f);

presentation->Save(u"line_spacing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![فاصله خط درون پاراگراف](line_spacing.png)

## **تنظیم نوع Autofit برای فریم‌های متن**

[ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/)`.AutofitType` تعیین می‌کند که متن هنگام فراسوی مرزهای مخزن خود چگونه رفتار کند. از آن برای کنترل اینکه متن کوچک شود، overflow داشته باشد یا به‌طور خودکار شکل را تغییر اندازه دهد، استفاده کنید.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);

presentation->Save(u"autofit_type.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم لنگر فریم‌های متن**

[ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/)`.AnchoringType` تعیین می‌کند متن به صورت عمودی داخل یک شکل چگونه موقعیت یابد، به عنوان مثال در بالا، وسط یا پایین.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

autoShape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Bottom);

presentation->Save(u"text_anchor.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم تب‌بندی متن**

از [IParagraphFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraphformat/)`.DefaultTabSize` و `IParagraphFormat.Tabs` برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

paragraph->get_ParagraphFormat()->set_DefaultTabSize(100.0f);
paragraph->get_ParagraphFormat()->get_Tabs()->Add(30.0f, TabAlignment::Left);

presentation->Save(u"paragraph_tabs.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![تب‌های پاراگراف](paragraph_tabs.png)

## **تنظیم زبان تصحیح املایی**

Aspose.Slides [IPortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformat/)`.LanguageId` را فراهم می‌کند که به شما اجازه می‌دهد زبان تصحیح املایی برای یک بخش متن را تنظیم کنید. زبان تصحیح املایی زبانی را که برای بررسی املا و گرامر در PowerPoint استفاده می‌شود، تعیین می‌کند.

کد زیر نشان می‌دهد چگونه زبان تصحیح املایی را برای یک بخش متن تنظیم کنید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto font = System::MakeObject<FontData>(u"SimSun");

auto textPortion = System::MakeObject<Portion>();
textPortion->get_PortionFormat()->set_ComplexScriptFont(font);
textPortion->get_PortionFormat()->set_EastAsianFont(font);
textPortion->get_PortionFormat()->set_LatinFont(font);

// Set the Id of a proofing language.
textPortion->get_PortionFormat()->set_LanguageId(u"zh-CN");

textPortion->set_Text(u"1.");
paragraph->get_Portions()->Add(textPortion);

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم زبان پیش‌فرض**

از [ILoadOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iloadoptions/)`.DefaultTextLanguage` برای تعریف زبان پیش‌فرض برای متنی که هنگام بارگذاری یا ایجاد ارائه ایجاد می‌شود، استفاده کنید.

```cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);

// یک شکل مستطیل جدید با متن اضافه کنید.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"Sample text");

// زبان اولین بخش متن را بررسی کنید.
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
System::Console::WriteLine(portion->get_PortionFormat()->get_LanguageId());

presentation->Dispose();
```

## **تنظیم سبک پیش‌فرض متن**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [IPresentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/)`.DefaultTextStyle` استفاده کنید.

کد زیر نشان می‌دهد چگونه قلم بولد پیش‌فرض با اندازه 14 pt را برای تمام متن در تمام اسلایدها در یک ارائه جدید تنظیم کنید.

```cpp
auto presentation = System::MakeObject<Presentation>();

// دریافت قالب پاراگراف سطح بالا.
auto paragraphFormat = presentation->get_DefaultTextStyle()->GetLevel(0);

if (paragraphFormat != nullptr)
{
    paragraphFormat->get_DefaultPortionFormat()->set_FontHeight(14.0f);
    paragraphFormat->get_DefaultPortionFormat()->set_FontBold(NullableBool::True);
}

presentation->Save(u"default_text_style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **استخراج متن با اثر تمام حروف بزرگ**

در PowerPoint، اعمال افکت **All Caps** باعث می‌شود متن روی اسلاید به صورت حروف بزرگ نمایش داده شود حتی اگر به‌صورت حروف کوچک تایپ شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه متن را دقیقاً همان‌طور که وارد شده است برمی‌گرداند. برای مطابقت با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textcaptype/) بررسی کنید و وقتی مقدار `All` است، رشتهٔ بازگردانده‌شده را به حروف بزرگ تبدیل کنید.

به‌عنوان مثال یک جعبه متن در اسلاید اول فایل sample2.pptx را در نظر بگیرید.

![اثر All Caps](all_caps_effect.png)

کد مثال زیر نشان می‌دهد چگونه متن با اثر **All Caps** اعمال‌شده را استخراج کنید:

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample2.pptx");

auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto textPortion = autoShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);

System::Console::WriteLine(u"Original text: " + textPortion->get_Text());

auto textFormat = textPortion->get_PortionFormat()->GetEffective();
if (textFormat->get_TextCapType() == TextCapType::All)
{
    auto text = textPortion->get_Text().ToUpper();
    System::Console::WriteLine(u"All-Caps effect: " + text);
}

presentation->Dispose();
```

خروجی:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **سؤالات متداول**

**چگونه متن داخل جدول در یک اسلاید را اصلاح کنیم؟**

برای اصلاح متن در جدول یک اسلاید، از [ITable](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itable/) استفاده کنید. در سلول‌ها پیمایش کنید و هر سلول را از طریق [ICell](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icell/)`.TextFrame` و قالب‌بندی پاراگراف از طریق [IParagraph](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iparagraph/)`.ParagraphFormat` به‌روز کنید.

**چگونه رنگ گرادیان را به متن در یک اسلاید PowerPoint اعمال کنیم؟**

برای اعمال رنگ گرادیان به متن، از [IPortionFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iportionformat/)`.FillFormat` استفاده کنید. [IFillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ifillformat/)`.FillType` را به [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/)`.Gradient` تنظیم کنید و نقاط توقف گرادیان، جهت و شفافیت را پیکربندی کنید.