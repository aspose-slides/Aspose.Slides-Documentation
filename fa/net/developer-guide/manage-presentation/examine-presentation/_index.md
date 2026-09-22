---
title: دریافت و به‌روزرسانی اطلاعات ارائه در .NET
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/net/examine-presentation/
keywords:
- قالب ارائه
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
description: "اسلایدها، ساختار و متادیتا را در ارائه‌های PowerPoint و OpenDocument با استفاده از .NET بررسی کنید تا بینش‌های سریع‌تر و ارزیابی‌های محتوا هوشمندانه‌تری داشته باشید."
---
## **بررسی کلی**

Aspose.Slides می‌تواند قالب یک ارائه را شناسایی کرده و متادیتای سند آن را بدون ایجاد یک مدل شیء کامل از ارائه بخواند. این برای زمانی که نیاز به طبقه‌بندی فایل‌ها، ساخت فهرست موجودی یا بررسی ویژگی‌ها پیش از تصمیم‌گیری درباره بارگذاری و پردازش محتوای ارائه دارید، مفید است.

این مقاله با استفاده از [PresentationFactory](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/) و [IPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/) بازرسی سبک را نشان می‌دهد و همچنین با استفاده از [IDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/) به‌روزرسانی هدفمند را نمایش می‌دهد.

## **بررسی قالب ارائه**

اگر قبلاً یک ارائه بارگذاری‌شده دارید، برای تشخیص پس از بارگذاری و محدودیت‌های جریان‌های PPT، PPS و POT قدیمی، به [تعیین قالب اصلی ارائه](/slides/fa/net/detect-presentation-source-format/) مراجعه کنید.

از [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/getpresentationinfo/) برای بازرسی یک فایل بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) استفاده کنید. ویژگی [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/loadformat/) قالب شناسایی‌شده را گزارش می‌دهد، مانند PPTX، PPT یا ODP.

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

## **ساخت فهرست موجودی سبک ارائه**

هنگامی که تعداد زیادی فایل ارائه را پردازش می‌کنید، ممکن است به فهرست موجودی فشرده‌ای برای اعتبارسنجی، ایندکس‌گذاری یا سیستم مدیریت سند نیاز داشته باشید. در این سناریو، از [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/getpresentationinfo/) برای به‌دست آوردن یک شیء [IPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/) استفاده کنید و سپس با فراخوانی [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/readdocumentproperties/) متادیتای سند را بخوانید. این روش نمونه‌ای از [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد نمی‌کند nor نیازی به پیمایش کامل مدل شیء ارائه ندارد.

ویژگی‌های گسترش‌یافته‌ای که توسط [IDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/) ارائه می‌شود، مقادیر موجودی زیر را فراهم می‌کند:

| ویژگی | مقدار موجودی |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/slides/fa/) | کل تعداد اسلایدها. |
| [HiddenSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/hiddenslides/) | تعداد اسلایدهای پنهان. |
| [Notes](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/notes/) | تعداد اسلایدهایی که دارای یادداشت هستند. |
| [Paragraphs](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/paragraphs/) | کل تعداد پاراگراف‌ها، در صورت موجود بودن. |
| [Words](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/words/) | کل تعداد کلمات. |
| [MultimediaClips](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/multimediaclips/) | کل تعداد کلیپ‌های صوتی و ویدئویی. |

مثال زیر این مقادیر را بدون ایجاد شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) می‌خواند و یک فهرست موجودی فشرده چاپ می‌کند. همچنین [HeadingPairs](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/headingpairs/) را با [TitlesOfParts](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/titlesofparts/) ترکیب می‌کند تا گروه‌های محتوا مانند قلم‌ها، تم‌ها و عناوين اسلاید را نمایش دهد.

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

هر [IHeadingPair](https://reference.aspose.com/slides/fa/net/aspose.slides/iheadingpair/) یک نام گروه و تعداد موارد در آن گروه را فراهم می‌کند. [IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/titlesofparts/) یک آرایهٔ صاف و مرتب است، بنابراین تعداد عناوین متوالی مشخص‌شده توسط هر جفت سرعنوان را مصرف کنید.

### **متادیتای ذخیره‌شده و محدودیت‌های قالب**

ویژگی‌های موجودی که توسط [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/readdocumentproperties/) بازگردانده می‌شوند، متادیتای موجود در سند منبع را منعکس می‌کند. Aspose.Slides مدل شیء ارائه را برای محاسبه مجدد این مقادیر بارگذاری و پیمایش نمی‌کند. ویژگی‌های گمشده با مقدارهای پیش‌فرض نشان داده می‌شوند و مقادیر ذخیره‌شده ممکن است منسوخ باشند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده است، ویژگی‌های سند را به‌روز نکرده باشد.

- **PPTX:** این قالب ویژگی‌های سند گسترش‌یافته برای شمارش اسلاید، یادداشت، اسلاید پنهان، پاراگراف، کلمه و چندرسانه‌ای، و همچنین جفت‌های سرعنوان و عناوین بخش‌ها را ارائه می‌دهد. در دسترس بودن آن بستگی به این دارد که کدام ویژگی‌ها توسط تولید‌کنندهٔ سند نوشته شده‌اند.
- **PPT:** قالب باینری می‌تواند ویژگی‌های خلاصه‌سند مربوطه را ذخیره کند. اگر ویژگی‌ای موجود نباشد یا توسط تولید‌کنندهٔ سند به‌روز نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را برمی‌گرداند نه اینکه آن را از اسلایدها محاسبه کند.
- **ODP:** متادیتای OpenDocument آمار کلی سند مانند شمارش صفحه، پاراگراف و کلمه را فراهم می‌کند، اما این مقادیر به تمام ویژگی‌های گسترش‌یافته مخصوص PowerPoint نگاشت نمی‌شوند. متادیتای اسلاید پنهان، اسلاید یادداشت، چندرسانه‌ای، جفت سرعنوان و عنوان بخش ممکن است در دسترس نباشد و ویژگی‌های موجودی ممکن است مقادیر پیش‌فرض برگردانند. مقدار صفر یا آرایهٔ خالی را به‌عنوان اثبات قطعی عدم وجود محتوای مربوطه درنظر نگیرید.

برای فهرست‌ها و بررسی‌های اولیه از روش متادیتای سبک استفاده کنید. زمانی که نتیجه باید تغییرات در حافظه را نشان دهد یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری کرده و مدل شیء زندهٔ آن را بازرسی کنید.

## **به‌روزرسانی ویژگی‌های ارائه**

ویژگی‌هایی که توسط [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/readdocumentproperties/) بازگردانده می‌شوند می‌توانند بدون ایجاد نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) نیز تغییر کنند. تغییرات را با [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) اعمال کنید و سپس ارائهٔ پیوست‌شده را با [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/writebindedpresentation/) بنویسید.

تصویر زیر ویژگی‌های سند اصلی ارائهٔ PowerPoint را نشان می‌دهد.

![ویژگی‌های سند اصلی ارائه پاورپوینت](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره را تغییر می‌دهد و نتیجه را در فایلی جدید می‌نویسد:

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

تصویر زیر ویژگی‌های سند به‌روزشده را نشان می‌دهد.

![ویژگی‌های سند تغییر یافتهٔ ارائه پاورپوینت](output_properties.png)

## **لینک‌های مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات حفاظت، مقالات زیر را ببینید:

- [حفاظت از ارائه با رمز عبور](/slides/fa/net/password-protected-presentation/)
- [حفاظت نوشتاری از ارائه‌ها](/slides/fa/net/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا فونت‌ها جاسازی شده‌اند و کدام‌اند؟**

ارائه را بارگذاری کنید و از [Presentation.FontsManager](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/fontsmanager/) استفاده کنید. با فراخوانی [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getembeddedfonts/) فونت‌های جاسازی‌شده را به‌دست آورید و با [FontsManager.GetFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsmanager/getfonts/) فونت‌های استفاده‌شده در ارائه را دریافت کنید. دو نتیجه را مقایسه کنید تا فونت‌های موردنیاز برای رندر اما غیرجاسازی‌شده را پیدا کنید.

**چگونه می‌توانم سریعاً تشخیص دهم فایل دارای اسلایدهای پنهان است و تعدادشان چقدر است؟**

هنگامی که متادیتای ذخیره‌شده سند کافی است، از [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/idocumentproperties/hiddenslides/) از طریق [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/getpresentationinfo/) و [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/readdocumentproperties/) بخوانید. این برای فهرست سبک مناسب است. اگر ارائه در حافظه تغییر یافته باشد، متادیتای ذخیره‌شده ممکن است گمشده یا منسوخ باشد یا نیاز به تأیید مقادیر زنده داشته باشید؛ در این صورت از طریق [Presentation.Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slides/fa/) پیمایش کنید و ویژگی [Slide.Hidden](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/hidden/) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم اندازه و جهت سفارشی اسلاید استفاده می‌شود و آیا با پیش‌فرض‌ها متفاوت است؟**

بله. ارائه را بارگذاری کنید و [Presentation.SlideSize](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slidesize/) را بخوانید. با بررسی [ISlideSize.Type](https://reference.aspose.com/slides/fa/net/aspose.slides/islidesize/type/)، [ISlideSize.Size](https://reference.aspose.com/slides/fa/net/aspose.slides/islidesize/size/) و [ISlideSize.Orientation](https://reference.aspose.com/slides/fa/net/aspose.slides/islidesize/orientation/) تنظیمات فعلی را با پیش‌تنظیمات و ابعاد پیش‌فرض مقایسه کنید.

**آیا راه سریعی برای دیدن این که نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chart/) را پیدا کنید و [ChartData.DataSourceType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/datasourcetype/) را بررسی کنید. برای یک کتاب‌کار خارجی، [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) را بخوانید. نوع منبع داده و مسیر یک ارجاع خارجی را شناسایی می‌کنند، اما تأیید در دسترس بودن هدف نیاز به بررسی منابع جداگانه دارد.

**چگونه می‌توانم اسلایدهای «سنگین» که ممکن است رندر یا خروجی PDF را کند کنند ارزیابی کنم؟**

هیچ ویژگی پیچیدگی واحدی وجود ندارد. با پیمایش [Presentation.Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slides/fa/) و مجموعهٔ [IBaseSlide.Shapes](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/shapes/) هر اسلاید، از شمارش اشکال و وجود تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای به‌عنوان سیگنال‌های فیلتر استفاده کنید و یک رندر یا خروجی نماینده را اندازه‌گیری کنید قبل از این که اسلاید را به‌عنوان گلوگاه عملکردی تأیید کنید.