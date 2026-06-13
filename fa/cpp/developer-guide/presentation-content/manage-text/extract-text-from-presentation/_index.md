---
title: استخراج پیشرفته متن از ارائه‌ها در C++
linktitle: استخراج متن
type: docs
weight: 90
url: /fa/cpp/extract-text-from-presentation/
keywords:
- استخراج متن
- استخراج متن از اسلاید
- استخراج متن از ارائه
- استخراج متن از PowerPoint
- استخراج متن از OpenDocument
- استخراج متن از PPT
- استخراج متن از PPTX
- استخراج متن از ODP
- بازیابی متن
- بازیابی متن از اسلاید
- بازیابی متن از ارائه
- بازیابی متن از PowerPoint
- بازیابی متن از OpenDocument
- بازیابی متن از PPT
- بازیابی متن از PPTX
- بازیابی متن از ODP
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "به‌سرعت متن را از ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای C++ استخراج کنید. راهنمای گام‌به‌گام ساده ما را دنبال کنید تا زمان صرفه‌جویی شود."
---
## **بررسی اجمالی**

استخراج متن از ارائه‌ها یک کار رایج اما ضروری برای توسعه‌دهندگانی است که با محتوای اسلایدها کار می‌کنند. چه با فایل‌های Microsoft PowerPoint در فرمت PPT یا PPTX، چه با ارائه‌های OpenDocument (ODP) سر و کار داشته باشید، دسترسی و بازیابی داده‌های متنی می‌تواند برای تجزیه و تحلیل، خودکارسازی، ایندکس‌گذاری یا مقاصد مهاجرت محتوا حیاتی باشد.

این مقاله راهنمای کاملی برای نحوه استخراج مؤثر متن از فرمت‌های مختلف ارائه، شامل PPT، PPTX و ODP، با استفاده از Aspose.Slides برای C++ ارائه می‌دهد. شما می‌آموزید چگونه به صورت سیستماتیک در عناصر ارائه پیمایش کنید تا به طور دقیق محتوای متنی مورد نیاز خود را بازیابی کنید.

## **استخراج متن از اسلاید**

Aspose.Slides for C++ یک فضای نام [Aspose.Slides.Util](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/) فراهم می‌کند که شامل کلاس [SlideUtil](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/) است. این کلاس چندین متد ایستا با بارگذاری (overloaded) برای استخراج تمام متن از یک ارائه یا اسلاید در دسترس قرار می‌دهد. برای استخراج متن از یک اسلاید در یک ارائه، از متد [GetAllTextBoxes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/getalltextboxes/) استفاده کنید. این متد یک شی از نوع [IBaseSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslide/) را به عنوان پارامتر می‌پذیرد. هنگام اجرا، این متد کل اسلاید را برای متن اسکن می‌کند و آرایه‌ای از اشیاء نوع [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) را باز می‌گرداند که قالب‌بندی متن را حفظ می‌کند.

قطعه کد زیر تمام متن اسلاید اول ارائه را استخراج می‌کند:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **استخراج متن از ارائه**

برای اسکن متن از کل ارائه، از متد ایستا [GetAllTextFrames](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/getalltextframes/) که توسط کلاس [SlideUtil](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/) ارائه می‌شود، استفاده کنید. این متد دو پارامتر می‌گیرد:

1. اولین پارامتر، شیء [IPresentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/) است که نمایانگر یک ارائه PowerPoint یا OpenDocument است که متن از آن استخراج می‌شود.
1. دومین پارامتر، مقدار `Boolean` است که تعیین می‌کند آیا اسلایدهای اصلی (master) هنگام اسکن متن از ارائه شامل شوند یا خیر.

این متد آرایه‌ای از اشیاء نوع [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) را بر می‌گرداند که شامل اطلاعات قالب‌بندی متن است. کد زیر متن و جزئیات قالب‌بندی را از یک ارائه، شامل اسلایدهای اصلی، اسکن می‌کند.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **استخراج متن دسته‌بندی‌شده و سریع**

کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentationfactory/) همچنین متدهایی برای استخراج تمام متن از ارائه‌ها فراهم می‌کند:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

آرگومان enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textextractionarrangingmode/) حالت سازماندهی نتایج استخراج متن را مشخص می‌کند و می‌تواند به مقادیر زیر تنظیم شود:
- `Unarranged` - متن خام بدون در نظر گرفتن موقعیت آن در اسلاید.
- `Arranged` - متن به همان ترتیب که در اسلید قرار دارد، سازماندهی می‌شود.

حالت بدون سازماندهی (Unarranged) می‌تواند زمانی استفاده شود که سرعت حیاتی است؛ این حالت از حالت سازماندهی‌شده (Arranged) سریع‌تر است.

[IPresentationText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationtext/) متن خام استخراج‌شده از ارائه را نشان می‌دهد. متد `get_SlidesText()` آن آرایه‌ای از اشیاء نوع [ISlideText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidetext/) را بر می‌گرداند. هر شیء متن اسلاید مربوطه را نمایندگی می‌کند. شیء نوع [ISlideText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidetext/) دارای متدهای زیر است:

- `get_Text()` - متن داخل شکل‌های اسلاید.
- `get_MasterText()` - متن داخل شکل‌های اسلاید اصلی (master) مرتبط با این اسلاید.
- `get_LayoutText()` - متن داخل شکل‌های اسلاید چیدمان (layout) مرتبط با این اسلاید.
- `get_NotesText()` - متن داخل شکل‌های اسلاید یادداشت‌ها (notes) مرتبط با این اسلاید.
- `get_CommentsText()` - متن داخل نظرات (comments) مرتبط با این اسلاید.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **پرسش‌های متداول**

**سرعت پردازش Aspose.Slides برای ارائه‌های بزرگ در هنگام استخراج متن چقدر است؟**

Aspose.Slides برای عملکرد بالا بهینه‌سازی شده و می‌تواند حتی [ارائه‌های بزرگ](/slides/fa/cpp/open-presentation/) را پردازش کند، که آن را برای سناریوهای پردازش زمان واقعی یا دسته‌ای مناسب می‌سازد.

**آیا Aspose.Slides می‌تواند متن را از جدول‌ها و نمودارها درون ارائه‌ها استخراج کند؟**

بله. Aspose.Slides می‌تواند متن را از بسیاری از عناصر اسلاید، از جمله جدول‌ها و اشیای مرتبط با نمودارها استخراج کند، بنابراین می‌توانید به محتوای متنی در ساختارهای رایج ارائه دسترسی داشته و آن را تجزیه و تحلیل کنید.

**آیا برای استخراج متن از ارائه‌ها به مجوز خاص Aspose.Slides نیاز دارم؟**

شما می‌توانید با نسخه آزمایشی رایگان Aspose.Slides متن را استخراج کنید، اگرچه این نسخه دارای [محدودیت‌های خاص](/slides/fa/cpp/licensing/) خواهد بود، مانند پردازش تنها تعداد محدودی اسلاید. برای استفاده بدون محدودیت و برای پردازش ارائه‌های بزرگ‌تر، خرید یک لایسنس کامل توصیه می‌شود.