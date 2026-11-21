---
title: تبدیل ارائه‌های PowerPoint به PDF با یادداشت‌ها در .NET
linktitle: PowerPoint به PDF با یادداشت‌ها
type: docs
weight: 50
url: /fa/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به PDF
- ارائه به PDF
- اسلاید به PDF
- PPT به PDF
- PPTX به PDF
- ذخیره ارائه به عنوان PDF
- ذخیره PPT به PDF
- ذخیره PPTX به PDF
- صادر کردن PPT به PDF
- صادر کردن PPTX به PDF
- یادداشت‌های گوینده
- PDF با یادداشت‌ها
- .NET
- C#
- Aspose.Slides
description: "تبدیل فرمت‌های PPT و PPTX به PDF با یادداشت‌ها با استفاده از Aspose.Slides برای .NET. نگهداری چیدمان‌ها و یادداشت‌های گوینده برای ارائه‌های حرفه‌ای."
---
## **نمای کلی**

در این مقاله، خواهید آموخت که چگونه ارائه‌های PowerPoint را به فرمت PDF با یادداشت‌های گوینده با استفاده از Aspose.Slides تبدیل کنید. این راهنما مراحل لازم را پوشش می‌دهد و مثال‌های کد ارائه می‌دهد تا بتوانید این کار را به‌کارآمدی انجام دهید. در پایان این مقاله، قادر خواهید بود:

- فرآیند تبدیل را پیاده‌سازی کنید تا اسلایدهای PowerPoint را به اسناد PDF تبدیل کنید و یادداشت‌های گوینده را حفظ کنید.
- خروجی PDF را سفارشی کنید تا مطمئن شوید یادداشت‌های گوینده گنجانده شده و طبق نیازهای شما قالب‌بندی می‌شوند.

برای تنظیم ابعاد و جهت‌گیری صفحه یادداشت‌ها قبل از صادرات، به [اندازه صفحه یادداشت](/slides/fa/net/notes-size/) مراجعه کنید.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

`Save` متد در کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) می‌تواند برای تبدیل یک ارائه PPT یا PPTX به PDF با یادداشت‌های گوینده استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notescommentslayoutingoptions/) پیکربندی می‌کنید تا یادداشت‌های گوینده گنجانده شوند و سپس فایل را به‌عنوان PDF ذخیره می‌کنید. قطعه کد زیر نمایش می‌دهد که چگونه یک ارائه نمونه را به PDF در نمای اسلاید یادداشت‌ها تبدیل کنید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // پیکربندی گزینه‌های PDF برای رندر کردن یادداشت‌های گوینده.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // رندر یادداشت‌های گوینده در زیر اسلاید.
        }
    };

    // ذخیره ارائه به صورت PDF با یادداشت‌های گوینده.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
ممکن است بخواهید [مبدل آنلاین PowerPoint به PDF Aspose](https://products.aspose.app/slides/fa/conversion) را بررسی کنید. 
{{% /alert %}}