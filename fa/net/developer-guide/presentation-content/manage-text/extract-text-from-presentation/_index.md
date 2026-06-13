---
title: استخراج پیشرفته متن از ارائه‌ها در .NET
linktitle: استخراج متن
type: docs
weight: 90
url: /fa/net/extract-text-from-presentation/
keywords:
- استخراج متن
- استخراج متن از اسلاید
- استخراج متن از ارائه
- استخراج متن از پاورپوینت
- استخراج متن از OpenDocument
- استخراج متن از PPT
- استخراج متن از PPTX
- استخراج متن از ODP
- بازیابی متن
- بازیابی متن از اسلاید
- بازیابی متن از ارائه
- بازیابی متن از پاورپوینت
- بازیابی متن از OpenDocument
- بازیابی متن از PPT
- بازیابی متن از PPTX
- بازیابی متن از ODP
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌سرعت متن را از ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET استخراج کنید. راهنمای ساده و گام‌به‌گام ما را برای صرفه‌جویی در زمان دنبال کنید."
---
## **بررسی کلی**

استخراج متن از ارائه‌ها کار رایجی است که برای توسعه‌دهندگانی که با محتوای اسلایدها کار می‌کنند، ضروری می‌باشد. چه با فایل‌های Microsoft PowerPoint در فرمت PPT یا PPTX، چه با ارائه‌های OpenDocument (ODP) سر و کار داشته باشید، دسترسی و بازیابی داده‌های متنی می‌تواند برای تحلیل، خودکارسازی، ایندکس‌گذاری یا مهاجرت محتوا حیاتی باشد.

این مقاله راهنمای جامعی برای استخراج مؤثر متن از فرمت‌های مختلف ارائه، از جمله PPT، PPTX و ODP، با استفاده از Aspose.Slides for .NET ارائه می‌دهد. شما یاد خواهید گرفت که چگونه به‌صورت سیستماتیک بر عناصر ارائه پیمایش کنید تا محتوای متنی مورد نیاز خود را به‌دقت بازیابی کنید.

## **استخراج متن از یک اسلاید**

Aspose.Slides for .NET فضای‌نامی [Aspose.Slides.Util](https://reference.aspose.com/slides/fa/net/aspose.slides.util/) را فراهم می‌کند که شامل کلاس [SlideUtil](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/) است. این کلاس چندین متد استاتیک بارگذاری‌شده برای استخراج تمام متن از یک ارائه یا اسلاید ارائه می‌دهد. برای استخراج متن از یک اسلاید در ارائه، از متد [GetAllTextBoxes](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/getalltextboxes/) استفاده کنید. این متد یک شیء از نوع [IBaseSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/) را به‌عنوان پارامتر می‌پذیرد. هنگام اجرا، متد کل اسلاید را برای متن اسکن می‌کند و یک آرایه از اشیاء نوع [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) را برمی‌گرداند که قالب‌بندی متن را حفظ می‌کند.

کد زیر تمام متن اولین اسلاید ارائه را استخراج می‌کند:

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

برای اسکن متن از کل ارائه، از متد استاتیک [GetAllTextFrames](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/getalltextframes/) که توسط کلاس [SlideUtil](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/) ارائه شده است، استفاده کنید. این متد دو پارامتر می‌گیرد:

1. ابتدا، یک شیء [IPresentation](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/) که نمایانگر یک ارائه PowerPoint یا OpenDocument است و متن از آن استخراج خواهد شد.
1. دوم، یک مقدار `Boolean` که نشان می‌دهد آیا اسلایدهای مستر هنگام اسکن متن از ارائه شامل شوند یا نه.

متد یک آرایه از اشیاء نوع [ITextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/) را برمی‌گرداند که شامل اطلاعات قالب‌بندی متن است. کد زیر متن و جزئیات قالب‌بندی را از یک ارائه اسکن می‌کند، از جمله اسلایدهای مستر.

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

## **استخراج متن دسته‌بندی‌شده و سریع**

کلاس [PresentationFactory](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/) نیز متدهایی برای استخراج تمام متن از ارائه‌ها فراهم می‌کند:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

آرگومان enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/fa/net/aspose.slides/textextractionarrangingmode/) حالت سازماندهی نتایج استخراج متن را مشخص می‌کند و می‌تواند به مقادیر زیر تنظیم شود:
- `Unarranged` - متن خام بدون در نظر گرفتن موقعیت آن در اسلاید.
- `Arranged` - متن به همان ترتیب که در اسلاید قرار دارد، سازماندهی می‌شود.

حالت unarranged می‌تواند وقتی سرعت حائز اهمیت است، استفاده شود؛ این حالت سریع‌تر از حالت arranged است.

[IPresentationText](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationtext/) متن خام استخراج‌شده از ارائه را نمایندگی می‌کند. ویژگی `SlidesText` آن یک آرایه از اشیاء نوع [ISlideText](https://reference.aspose.com/slides/fa/net/aspose.slides/islidetext/) را برمی‌گرداند. هر شیء متن اسلاید مربوطه را نشان می‌دهد. شیء نوع [ISlideText](https://reference.aspose.com/slides/fa/net/aspose.slides/islidetext/) دارای ویژگی‌های زیر است:

- `Text` - متن داخل شکل‌های اسلاید.
- `MasterText` - متن داخل شکل‌های اسلاید مستر مرتبط با این اسلاید.
- `LayoutText` - متن داخل شکل‌های اسلاید لایه‌بندی مرتبط با این اسلاید.
- `NotesText` - متن داخل شکل‌های اسلاید یادداشت‌های این اسلاید.
- `CommentsText` - متن داخل نظرات مرتبط با این اسلاید.

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

**Aspose.Slides تا چه حد سریع می‌تواند ارائه‌های بزرگ را هنگام استخراج متن پردازش کند؟**

Aspose.Slides برای عملکرد بالا بهینه‌سازی شده است و حتی می‌تواند [ارائه‌های بزرگ](/slides/fa/net/open-presentation/) را پردازش کند، بنابراین برای سناریوهای پردازش زمان واقعی یا دسته‌ای مناسب است.

**آیا Aspose.Slides می‌تواند متن را از جداول و نمودارها درون ارائه‌ها استخراج کند؟**

بله. Aspose.Slides می‌تواند متن را از بسیاری از عناصر اسلاید، از جمله جداول و اشیاء مرتبط با نمودارها، استخراج کند، بنابراین می‌توانید به محتوای متنی در ساختارهای رایج ارائه دسترسی داشته و آن را تجزیه و تحلیل کنید.

**آیا برای استخراج متن از ارائه‌ها به یک لایسنس خاص Aspose.Slides نیاز دارم؟**

می‌توانید با نسخه آزمایشی رایگان Aspose.Slides متن را استخراج کنید، هرچند که محدودیت‌های [معینی](/slides/fa/net/licensing/) دارد، مانند پردازش تعداد محدودی اسلاید. برای استفاده بدون محدودیت و پردازش ارائه‌های بزرگ‌تر، خرید یک لایسنس کامل توصیه می‌شود.