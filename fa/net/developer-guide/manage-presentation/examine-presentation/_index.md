---
title: بازیابی و به‌روزرسانی اطلاعات ارائه در .NET
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/net/examine-presentation/
keywords:
- فرمت ارائه
- ویژگی‌های ارائه
- ویژگی‌های سند
- دریافت ویژگی‌ها
- خواندن ویژگی‌ها
- تغییر ویژگی‌ها
- اصلاح ویژگی‌ها
- به‌روزرسانی ویژگی‌ها
- بررسی PPTX
- بررسی PPT
- بررسی ODP
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: اسلایدها، ساختار و متادیتا را در ارائه‌های PowerPoint و OpenDocument با استفاده از .NET بررسی کنید تا بینش‌های سریع‌تر و ارزیابی‌های محتوا هوشمندانه‌تری داشته باشید.
---
## **بررسی اجمالی**

Aspose.Slides می‌تواند فرمت یک ارائه را شناسایی کرده و متادیتای سند آن را بدون ایجاد یک مدل شیء کامل ارائه بخواند. این کار وقتی نیاز به طبقه‌بندی فایل‌ها، ساخت موجودی یا بازرسی ویژگی‌ها پیش از تصمیم‌گیری در مورد بارگذاری و پردازش محتوای ارائه مفید است.

این مقاله بازرسی سبک وزن را از طریق [PresentationFactory](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/) و [IPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/) و همچنین به‌روزرسانی‌های هدفمند را از طریق [IDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/) نشان می‌دهد.

## **بررسی فرمت یک ارائه**

از [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/getpresentationinfo/) برای بررسی یک فایل بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) استفاده کنید. ویژگی [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/loadformat/) فرمت شناسایی‌شده را گزارش می‌دهد، مانند PPTX، PPT یا ODP.

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **ساخت موجودی سبک وزن برای ارائه**

هنگامی که تعداد زیادی فایل ارائه را پردازش می‌کنید، ممکن است به یک موجودی فشرده برای اعتبارسنجی، فهرست‌برداری یا سیستم مدیریت اسناد نیاز داشته باشید. در این سناریو از [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/getpresentationinfo/) برای به‌دست آوردن یک شیء [IPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/) استفاده کنید و سپس با فراخوانی [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/readdocumentproperties/) متادیتای سند را بخوانید. این روش هیچ نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد نمی‌کند و نیاز به پیمایش کامل مدل شیء ارائه نیست.

ویژگی‌های توسعه‌یافته‌ای که توسط [IDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/) ارائه می‌شود، مقادیر موجودی زیر را فراهم می‌کند:

| ویژگی | مقدار موجودی |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/slides/fa/) | تعداد کل اسلایدها. |
| [HiddenSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/hiddenslides/) | تعداد اسلایدهای پنهان. |
| [Notes](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/notes/) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [Paragraphs](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/paragraphs/) | تعداد کل پاراگراف‌ها، در صورت موجود بودن. |
| [Words](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/words/) | تعداد کل کلمات. |
| [MultimediaClips](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/multimediaclips/) | تعداد کل کلیپ‌های صوتی و ویدئویی. |

مثال زیر این مقادیر را بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) می‌خواند و یک موجودی فشرده را چاپ می‌کند. همچنین با ترکیب [HeadingPairs](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/headingpairs/) و [TitlesOfParts](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/titlesofparts/) گروه‌های محتوایی مانند قلم‌ها، تم‌ها و عناوین اسلایدها را نمایش می‌دهد.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

هر [IHeadingPair](https://reference.aspose.com/slides/fa/net/aspose.slides/iheadingpair/) نام گروه و تعداد موارد در آن گروه را فراهم می‌کند. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/titlesofparts/) یک آرایه صاف و مرتب است، بنابراین تعداد عناوین متوالی مشخص‌شده توسط هر جفت سرعنوان را مصرف کنید.

### **متادیتای ذخیره‌شده و محدودیت‌های فرمت**

ویژگی‌های موجودی که توسط [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/readdocumentproperties/) بازگردانده می‌شوند، متادیتای موجود در سند منبع را منعکس می‌کنند. Aspose.Slides برای این فراخوانی مدل شیء ارائه را بارگذاری و پیمایش نمی‌کند تا مقادیر را دوباره محاسبه کند. ویژگی‌های گمشده با مقادیر پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است منسوخ شوند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده بود ویژگی‌های سند را به‌روزرسانی نکرده باشد.

- **PPTX:** این فرمت ویژگی‌های سند توسعه‌یافته‌ای برای شمارش اسلاید، یادداشت، اسلاید پنهان، پاراگراف، کلمه و کلیپ‌های چندرسانه‌ای، همچنین جفت‌های سرعنوان و عناوین بخش‌ها فراهم می‌کند. در دسترس بودن آن بسته به این است که کدام ویژگی‌ها توسط تولیدکننده سند نوشته شده‌اند.
- **PPT:** فرمت باینری می‌تواند ویژگی‌های خلاصه‌سند متناظر را ذخیره کند. اگر یک ویژگی غیاب داشته باشد یا توسط تولیدکننده سند به‌روز نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را بر می‌گرداند و نه این‌که آن را از اسلایدها محاسبه کند.
- **ODP:** متادیتای OpenDocument آمارهای کلی سند مانند تعداد صفحه، پاراگراف و کلمه را فراهم می‌کند، اما این مقادیر به تمام ویژگی‌های توسعه‌یافته خاص PowerPoint نگاشت نمی‌شوند. متادیتای اسلاید پنهان، اسلاید یادداشت، چندرسانه‌ای، جفت سرعنوان و عنوان بخش ممکن است در دسترس نباشند و ویژگی‌های موجودی ممکن است مقادیر پیش‌فرض بازگردانند. مقدار صفر یا آرایه خالی را به‌عنوان اثبات قطعی عدم وجود محتوای مربوطه در نظر نگیرید.

از روش متادیتای سبک وزن برای موجودی‌ها و بررسی‌های اولیه استفاده کنید. زمانی که نتیجه باید تغییرات در حافظه را منعکس کند یا نیاز به تایید محتوای واقعی ارائه دارید، ارائه را بارگذاری و مدل شیء زنده آن را بررسی کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

ویژگی‌هایی که توسط [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/readdocumentproperties/) بازگردانده می‌شوند، می‌توانند بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) نیز تغییر کنند. تغییرات را با [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) اعمال کنید و سپس ارائه باند شده را با [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/writebindedpresentation/) بنویسید.

تصویر زیر ویژگی‌های سند اصلی ارائه PowerPoint را نشان می‌دهد.

![ویژگی‌های سند اصلی ارائه PowerPoint](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره‌سازی را تغییر می‌دهد و نتیجه را در فایل جدیدی می‌نویسد:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

تصویر زیر ویژگی‌های سند به‌روزشدهٔ ارائه PowerPoint را نشان می‌دهد.

![ویژگی‌های سند به‌روزشدهٔ ارائه PowerPoint](output_properties.png)

## **پیوندهای مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات حفاظت، مقاله‌های زیر را ببینید:

- [محافظت با رمزنگاری ارائه‌ها](/slides/fa/net/password-protected-presentation/)
- [محافظت نوشتاری از ارائه‌ها](/slides/fa/net/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌ها هستند؟**

ارائه را بارگذاری کنید و از [Presentation.FontsManager](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/fontsmanager/) استفاده کنید. با فراخوانی [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getembeddedfonts/) قلم‌های جاسازی‌شده را و با فراخوانی [FontsManager.GetFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getfonts/) قلم‌های مورد استفاده در ارائه را به‌دست آورید. دو نتیجه را مقایسه کنید تا قلم‌هایی که برای رندر لازم‌اند اما جاسازی نشده‌اند، پیدا کنید.

**چگونه می‌توانم به‌سرعت بفهمم فایل اسلایدهای پنهان دارد و چند تا هستند؟**

زمانی که متادیتای ذخیره‌شده سند کافی باشد، [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/hiddenslides/) را از طریق [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/getpresentationinfo/) و [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/readdocumentproperties/) بخوانید. این روش برای یک موجودی سبک وزن مناسب است. اگر ارائه در حافظه تغییر کرده باشد، متادیتای ذخیره‌شده ممکن است مفقود یا منسوخ باشد؛ در این صورت باید از طریق پیمایش [Presentation.Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slides/fa/) و بررسی ویژگی [Slide.Hidden](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/hidden/) هر اسلاید استفاده کنید.

**آیا می‌توانم تشخیص دهم که اندازه و جهت سفارشی اسلاید استفاده می‌شود و آیا از پیش‌فرض‌ها متفاوت است؟**

بله. ارائه را بارگذاری کنید و [Presentation.SlideSize](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slidesize/) را بخوانید. ویژگی‌های [ISlideSize.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/islidesize/type/)، [ISlideSize.Size](https://reference.aspose.com/slides/fa/net/aspose.slides/islidesize/size/) و [ISlideSize.Orientation](https://reference.aspose.com/slides/fa/net/aspose.slides/islidesize/orientation/) را بررسی کنید تا تنظیمات فعلی را با تنظیمات پیش‌فرض و ابعاد مورد انتظار مقایسه کنید.

**آیا راه سریع برای دیدن این‌که نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/) را پیدا کنید و ویژگی [ChartData.DataSourceType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/datasourcetype/) را بررسی کنید. برای یک کتاب‌کار خارجی، [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) را بخوانید. نوع منبع داده و مسیر، ارجاع خارجی را شناسایی می‌کند، اما تأیید دسترس‌پذیری هدف نیاز به بررسی منابع جداگانه دارد.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا صادرات PDF را کند کنند ارزیابی کنم؟**

هیچ ویژگی پیچیدگی تک‌نقطه‌ای وجود ندارد. [Presentation.Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slides/fa/) و مجموعه [IBaseSlide.Shapes](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/shapes/) هر اسلاید را پیمایش کنید. از شمارش شکل‌ها و وجود تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای‌ها به‌عنوان سیگنال‌های فیلترینگ استفاده کنید و یک رندر یا صادرات نماینده را اندازه‌گیری کنید قبل از این‌که اسلاید را به‌عنوان گلوگاه عملکردی تأیید کنید.