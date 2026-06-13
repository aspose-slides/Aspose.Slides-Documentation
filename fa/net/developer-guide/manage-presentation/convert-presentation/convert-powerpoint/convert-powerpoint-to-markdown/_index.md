---
title: تبدیل ارائه‌های PowerPoint به Markdown در .NET
linktitle: PowerPoint به Markdown
type: docs
weight: 140
url: /fa/net/convert-powerpoint-to-markdown/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به MD
- ارائه به MD
- اسلاید به MD
- PPT به MD
- PPTX به MD
- ذخیره PowerPoint به عنوان Markdown
- ذخیره ارائه به عنوان Markdown
- ذخیره اسلاید به عنوان Markdown
- ذخیره PPT به عنوان MD
- ذخیره PPTX به عنوان MD
- صادرات PPT به MD
- صادرات PPTX به MD
- PowerPoint
- ارائه
- Markdown
- .NET
- C#
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint—PPT، PPTX—به Markdown تمیز با Aspose.Slides برای .NET، خودکارسازی مستندات و حفظ قالب‌بندی."
---
## **مقدمه**

Aspose.Slides به شما امکان می‌دهد ارائه‌های PowerPoint را به Markdown تبدیل کنید، که می‌تواند برای جریان‌های کاری سند‌نویسی، تولید سایت ایستا، مهاجرت محتوا و انتشار متن تحت کنترل نسخه مفید باشد. API صادرات مستقیم از ارائه‌های PPT و PPTX به فایل‌های MD را پشتیبانی می‌کند و گزینه‌های اضافی برای کنترل نحوه نمایش محتویات اسلاید در سند Markdown تولید شده فراهم می‌آورد.

می‌توانید ارائه‌ها را به صورت Markdown ساده صادر کنید، از میان انواع مختلف Markdown مانند CommonMark و GitHub Flavored Markdown انتخاب کنید و نحوهٔ پردازش تصاویر را در زمان صادرات پیکربندی کنید. برای ارائه‌هایی که محتویات بصری دارند، Aspose.Slides همچنین امکان ذخیرهٔ تصاویر در یک پوشهٔ جداگانه و ارجاع به آن‌ها از فایل Markdown تولید شده را می‌دهد.

{{% alert color="warning" %}}
صادرات PowerPoint به Markdown به‌طور پیش‌فرض **بدون تصاویر** است. اگر می‌خواهید یک سند PowerPoint حاوی تصاویر را صادر کنید، باید `ExportType = MarkdownExportType.Visual` تنظیم کنید و `BasePath` را مشخص کنید، جایی که تصاویر ارجاع‌شده در سند Markdown ذخیره می‌شوند.
{{% /alert %}}

## **تبدیل PowerPoint به Markdown**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید تا یک شیء ارائه را نمایند.
2. از متد [Save ](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/methods/save) برای ذخیرهٔ شی به عنوان یک فایل markdown استفاده کنید.

این کد C# نشان می‌دهد چگونه PowerPoint را به markdown تبدیل کنید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **تبدیل PowerPoint به انواع Markdown**

Aspose.Slides به شما امکان می‌دهد PowerPoint را به markdown (شامل نحو پایه)، CommonMark، GitHub flavored markdown، Trello، XWiki، GitLab و ۱۷ نوع دیگر markdown تبدیل کنید.

این کد C# نشان می‌دهد چگونه PowerPoint را به CommonMark تبدیل کنید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

۲۳ نوع markdown پشتیبانی‌شده در [Flavor enumeration](https://reference.aspose.com/slides/fa/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) از کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) هستند.

## **تبدیل یک ارائه حاوی تصاویر به Markdown**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) ویژگی‌ها و شمارش‌هایی فراهم می‌کند که به شما امکان می‌دهد گزینه‌ها یا تنظیمات خاصی را برای فایل markdown خروجی به کار ببرید. به‌عنوان مثال، شمارش [MarkdownExportType](https://reference.aspose.com/slides/fa/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) می‌تواند به مقادیری تنظیم شود که نحوهٔ نمایش یا پردازش تصاویر را تعیین می‌کند: `Sequential`، `TextOnly`، `Visual`.

### **تبدیل تصاویر به‌صورت ترتیبی**

اگر می‌خواهید تصاویر به‌صورت جداگانه یکی پس از دیگری در markdown خروجی ظاهر شوند، باید گزینهٔ sequential را انتخاب کنید. این کد C# نشان می‌دهد چگونه یک ارائه حاوی تصاویر را به markdown تبدیل کنید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **تبدیل تصاویر به‌صورت بصری**

اگر می‌خواهید تصاویر به‌صورت همزمان در markdown خروجی ظاهر شوند، باید گزینهٔ visual را انتخاب کنید. در این حالت، تصاویر در پوشهٔ جاری برنامه ذخیره می‌شوند (و مسیر نسبی برای آن‌ها در سند markdown ساخته می‌شود)، یا می‌توانید مسیر و نام پوشهٔ دلخواه خود را مشخص کنید.

این کد C# عملیات را نشان می‌دهد:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **سوالات متداول**

**آیا پیوندهای ابرمتنی پس از صادرات به Markdown باقی می‌مانند؟**

بله. متن [hyperlinks](/slides/fa/net/manage-hyperlinks/) به‌عنوان پیوندهای استاندارد Markdown حفظ می‌شوند. [transitions](/slides/fa/net/slide-transition/) و [animations](/slides/fa/net/powerpoint-animation/) اسلایدها تبدیل نمی‌شوند.

**آیا می‌توانم با اجرای تبدیل در چندین رشته (thread) سرعت را بالا ببرم؟**

می‌توانید پردازش را بین فایل‌ها موازی‌سازی کنید، اما [don’t share](/slides/fa/net/multithreading/) نمونهٔ یکسان [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) را بین رشته‌ها به‌اشتراک نگذارید. برای هر فایل از نمونه‌ها/فرآیندهای جداگانه استفاده کنید تا از تداخل جلوگیری شود.

**چه اتفاقی برای تصاویر می‌افتد—کجا ذخیره می‌شوند و آیا مسیرها نسبی هستند؟**

[Images](/slides/fa/net/image/) به یک پوشهٔ اختصاصی صادر می‌شوند و فایل Markdown به‌طور پیش‌فرض آن‌ها را با مسیرهای نسبی ارجاع می‌دهد. می‌توانید مسیر خروجی پایه و نام پوشهٔ دارایی‌ها را پیکربندی کنید تا ساختار مخزن پیش‌بینی‌پذیری داشته باشید.