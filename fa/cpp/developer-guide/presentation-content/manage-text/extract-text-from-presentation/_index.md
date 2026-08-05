---
title: "استخراج پیشرفته متن از ارائه‌ها در C++"
linktitle: "استخراج متن"
type: docs
weight: 90
url: /fa/cpp/extract-text-from-presentation/
aliases:
  - /cpp/استخراج-متن-از-ارائه/
keywords:
  - "استخراج متن"
  - "استخراج متن از اسلاید"
  - "استخراج متن از ارائه"
  - "استخراج متن از پاورپوینت"
  - "استخراج متن از OpenDocument"
  - "استخراج متن از PPT"
  - "استخراج متن از PPTX"
  - "استخراج متن از ODP"
  - "بازیابی متن"
  - "بازیابی متن از اسلاید"
  - "بازیابی متن از ارائه"
  - "بازیابی متن از پاورپوینت"
  - "بازیابی متن از OpenDocument"
  - "بازیابی متن از PPT"
  - "بازیابی متن از PPTX"
  - "بازیابی متن از ODP"
  - "پاورپوینت"
  - "OpenDocument"
  - "ارائه"
  - "C++"
  - "Aspose.Slides"
description: "به‌سرعت متن را از ارائه‌های پاورپوینت و OpenDocument با استفاده از Aspose.Slides برای C++ استخراج کنید. راهنمای ساده و گام‌به‌گام ما را دنبال کنید تا زمان صرفه‌جویی کنید."
---
## **نمای کلی**

استخراج متن از ارائه‌ها یک کار رایج اما اساسی برای توسعه‌دهندگانی است که با محتوای اسلاید کار می‌کنند. چه با فایل‌های Microsoft PowerPoint با فرمت PPT یا PPTX کار کنید و چه با ارائه‌های OpenDocument (ODP)، دسترسی و بازیابی داده‌های متنی می‌تواند برای تجزیه و تحلیل، خودکارسازی، ایندکس‌گذاری یا مهاجرت محتوا حیاتی باشد.

این مقاله راهنمای جامعی برای استخراج مؤثر متن از فرمت‌های مختلف ارائه، شامل PPT، PPTX و ODP، با استفاده از Aspose.Slides for C++ ارائه می‌دهد. شما یاد خواهید گرفت چگونه به‌صورت سیستماتیک بر عناصر ارائه پیمایش کنید تا محتوای متنی مورد نیاز خود را به‌دقت بازیابی کنید.

## **استخراج متن از یک اسلاید**

Aspose.Slides for C++ فضای‌نام [Aspose.Slides.Util](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/) را فراهم می‌کند که شامل کلاس [SlideUtil](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/) است. این کلاس چندین متد ایستاتیک بارگذاری‌شده برای استخراج تمام متن از یک ارائه یا اسلاید ارائه می‌دهد. برای استخراج متن از یک اسلاید در یک ارائه، از متد [GetAllTextBoxes](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/getalltextboxes/) استفاده کنید. این متد یک شیء از نوع [IBaseSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslide/) را به عنوان پارامتر می‌پذیرد. هنگام اجرا، متد تمام اسلاید را برای پیدا کردن متن اسکن می‌کند و یک آرایه از اشیاء نوع [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) را بازمی‌گرداند که قالب‌بندی متن را حفظ می‌کند.

کد زیر تمام متن اولین اسلاید ارائه را استخراج می‌کند:

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

## **استخراج متن از یک ارائه**

برای اسکن متن از کل ارائه، از متد ایستاتیک [GetAllTextFrames](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/getalltextframes/) که توسط کلاس [SlideUtil](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/) ارائه می‌شود، استفاده کنید. این متد دو پارامتر می‌پذیرد:

1. ابتدا، یک شیء [IPresentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/) که نمایانگر یک ارائه PowerPoint یا OpenDocument است و از آن متن استخراج خواهد شد.
2. دوم، یک مقدار `Boolean` که نشان می‌دهد آیا اسلایدهای مستر هنگام اسکن متن از ارائه گنجانده شوند یا نه.

متد یک آرایه از اشیاء نوع [ITextFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframe/) را بازمی‌گرداند که شامل اطلاعات قالب‌بندی متن می‌شود. کد زیر متن و جزئیات قالب‌بندی را از یک ارائه اسکن می‌کند، از جمله اسلایدهای مستر.

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

کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentationfactory/) نیز متدهایی برای استخراج تمام متن از ارائه‌ها فراهم می‌کند:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

آرگومان enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textextractionarrangingmode/) حالت سازماندهی نتیجه استخراج متن را نشان می‌دهد و می‌تواند به مقادیر زیر تنظیم شود:
- `Unarranged` - متن خام بدون توجه به موقعیت آن در اسلاید.
- `Arranged` - متن به همان ترتیبی که در اسلاید ظاهر می‌شود، سازماندهی می‌شود.

حالت Unarranged می‌تواند زمانی استفاده شود که سرعت مهم باشد؛ این حالت سریع‌تر از حالت Arranged است.

[IPresentationText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationtext/) متنی خام استخراج‌شده از ارائه را نشان می‌دهد. متد `get_SlidesText()` آن یک آرایه از اشیاء نوع [ISlideText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidetext/) را بازمی‌گرداند. هر شیء متن مربوط به اسلاید معین را نمایان می‌کند. شیء نوع [ISlideText](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidetext/) متدهای زیر را دارد:

- `get_Text()` - متن داخل اشکال اسلاید.
- `get_MasterText()` - متن داخل اشکال اسلاید مستر مرتبط با این اسلاید.
- `get_LayoutText()` - متن داخل اشکال اسلاید چیدمان مرتبط با این اسلاید.
- `get_NotesText()` - متن داخل اشکال اسلاید یادداشت‌های مرتبط با این اسلاید.
- `get_CommentsText()` - متن داخل نظرات مرتبط با این اسلاید.

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

## **سوالات متداول**

**Aspose.Slides در حین استخراج متن از ارائه‌های بزرگ با چه سرعتی پردازش می‌کند؟**

Aspose.Slides برای عملکرد بالا بهینه‌سازی شده است و حتی می‌تواند [ارائه‌های بزرگ](/slides/fa/cpp/open-presentation/) را پردازش کند، که آن را برای سناریوهای پردازش زمان واقعی یا انبوه مناسب می‌سازد.

**آیا Aspose.Slides می‌تواند متن را از جداول و نمودارها در داخل ارائه‌ها استخراج کند؟**

بله. Aspose.Slides می‌تواند متن را از بسیاری از عناصر اسلاید، از جمله جداول و اشیاء مرتبط با نمودارها استخراج کند، به‌طوری که بتوانید محتوای متنی در ساختارهای معمول ارائه را دسترسی و تجزیه و تحلیل کنید.

**آیا برای استخراج متن از ارائه‌ها به مجوز خاصی از Aspose.Slides نیاز دارم؟**

می‌توانید متن را با نسخه آزمایشی رایگان Aspose.Slides استخراج کنید، هرچند که دارای [محدودیت‌های خاص](/slides/fa/cpp/licensing/) است، مانند پردازش تعداد محدودی اسلاید. برای استفاده بدون محدودیت و پردازش ارائه‌های بزرگتر، خرید یک مجوز کامل توصیه می‌شود.