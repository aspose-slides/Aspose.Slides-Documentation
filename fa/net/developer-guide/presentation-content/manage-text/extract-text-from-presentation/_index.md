---
title: استخراج پیشرفته متن از ارائه‌ها در .NET
linktitle: استخراج متن
type: docs
weight: 90
url: /fa/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/fa/
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
- .NET
- C#
- Aspose.Slides
description: "به سرعت متن را از ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET استخراج کنید. راهنمای ساده گام به گام ما را دنبال کنید تا زمان را صرفه جویی کنید."
---
## **مروری کلی**

استخراج متن از ارائه‌ها یک کار رایج اما اساسی برای توسعه‌دهندگانی است که با محتوای اسلاید کار می‌کنند. چه با فایل‌های Microsoft PowerPoint در قالب PPT یا PPTX کار کنید و چه با ارائه‌های OpenDocument (ODP)، دسترسی و بازیابی داده‌های متنی می‌تواند برای تجزیه و تحلیل، خودکارسازی، ایندکس‌سازی یا اهداف مهاجرت محتوا حیاتی باشد.

این مقاله راهنمای جامعی برای استخراج کارآمد متن از فرمت‌های مختلف ارائه، از جمله PPT، PPTX و ODP، با استفاده از Aspose.Slides for .NET ارائه می‌دهد. شما یاد می‌گیرید چگونه به‌صورت سیستماتیک از عناصر ارائه عبور کنید تا محتوای متنی مورد نیاز خود را به‌دقت بازیابی کنید.

## **استخراج متن از یک اسلاید**

Aspose.Slides for .NET فضای نام [Aspose.Slides.Util](https://reference.aspose.com/slides/fa/net/aspose.slides.util/) را فراهم می‌کند که شامل کلاس [SlideUtil](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/) است. این کلاس چندین روش استاتیک overload شده برای استخراج تمام متن از یک ارائه یا اسلاید ارائه می‌دهد. برای استخراج متن از یک اسلاید در یک ارائه، از روش [GetAllTextBoxes](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/getalltextboxes/) استفاده کنید. این روش یک شیء از نوع [IBaseSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/) را به‌عنوان پارامتر دریافت می‌کند. هنگام اجرا، روش تمام اسلاید را برای متن اسکن می‌کند و آرایه‌ای از اشیاء نوع [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) را برمی‌گرداند که قالب‌بندی متن را حفظ می‌کند.

کد نمونه زیر تمام متن اسلاید اول ارائه را استخراج می‌کند:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **استخراج متن از یک ارائه**

برای اسکن متن از کل ارائه، از روش استاتیک [GetAllTextFrames](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/getalltextframes/) که توسط کلاس [SlideUtil](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/) ارائه می‌شود، استفاده کنید. این روش دو پارامتر دریافت می‌کند:

1. ابتدا یک شیء [IPresentation](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/) که نمایانگر یک ارائه PowerPoint یا OpenDocument است و متن آن استخراج خواهد شد.
2. سپس یک مقدار `Boolean` که نشان می‌دهد آیا اسلایدهای اصلی (master) هنگام اسکن متن از ارائه گنجانده شوند یا خیر.

این روش آرایه‌ای از اشیاء نوع [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) را برمی‌گرداند که شامل اطلاعات قالب‌بندی متن نیز می‌شود. کد زیر متن و جزئیات قالب‌بندی را از یک ارائه، از جمله اسلایدهای اصلی، اسکن می‌کند.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **استخراج متنی دسته‌بندی‌شده و سریع**

کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/) نیز روش‌هایی برای استخراج تمام متن از ارائه‌ها فراهم می‌کند:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

آرگومان enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/fa/net/aspose.slides/textextractionarrangingmode/) نشان‌دهنده حالت سازماندهی نتیجه استخراج متن است و می‌تواند به مقادیر زیر تنظیم شود:
- `Unarranged` - متن خام بدون توجه به موقعیت آن روی اسلاید.
- `Arranged` - متن به همان ترتیب که روی اسلاید قرار دارد، سازماندهی می‌شود.

حالت `Unarranged` زمانی که سرعت بحرانی است می‌تواند استفاده شود؛ این حالت سریع‌تر از حالت `Arranged` است.

رابط [IPresentationText](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationtext/) متن خام استخراج‌شده از ارائه را نشان می‌دهد. ویژگی `SlidesText` آن آرایه‌ای از اشیاء نوع [ISlideText](https://reference.aspose.com/slides/fa/net/aspose.slides/islidetext/) برمی‌گرداند. هر شیء متن اسلاید مربوطه را نمایش می‌دهد. شیء نوع [ISlideText](https://reference.aspose.com/slides/fa/net/aspose.slides/islidetext/) دارای ویژگی‌های زیر است:

- `Text` - متنی که در اشکال اسلاید قرار دارد.
- `MasterText` - متنی که در اشکال اسلاید اصلی مرتبط با این اسلاید قرار دارد.
- `LayoutText` - متنی که در اشکال اسلاید قالب مرتبط با این اسلاید قرار دارد.
- `NotesText` - متنی که در اشکال اسلاید یادداشت‌های مرتبط با این اسلاید قرار دارد.
- `CommentsText` - متنی که در نظرات مرتبط با این اسلاید قرار دارد.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **سوالات متداول**

**Aspose.Slides در هنگام استخراج متن از ارائه‌های بزرگ چه سرعتی دارد؟**

Aspose.Slides برای عملکرد پرسرعت بهینه‌سازی شده است و می‌تواند حتی [ارائه‌های بزرگ](/slides/fa/net/open-presentation/) را پردازش کند، به‌طوری که برای سناریوهای پردازش زمان واقعی یا حجیم مناسب است.

**آیا Aspose.Slides می‌تواند متن را از جداول و نمودارها درون ارائه‌ها استخراج کند؟**

بله. Aspose.Slides می‌تواند متن را از بسیاری از عناصر اسلاید، از جمله جداول و اشیای مرتبط با نمودارها، استخراج کند تا بتوانید به محتوای متنی در ساختارهای معمول ارائه دسترسی پیدا کنید و آن را تجزیه و تحلیل کنید.

**آیا برای استخراج متن از ارائه‌ها به یک لایسنس خاص Aspose.Slides نیاز دارم؟**

می‌توانید متن را با نسخه آزمایشی رایگان Aspose.Slides استخراج کنید، هرچند این نسخه دارای [محدودیت‌های خاص](/slides/fa/net/licensing/) است، مانند پردازش تعداد محدودی از اسلایدها. برای استفاده بدون محدودیت و کار با ارائه‌های بزرگ‌تر، خرید لایسنس کامل توصیه می‌شود.