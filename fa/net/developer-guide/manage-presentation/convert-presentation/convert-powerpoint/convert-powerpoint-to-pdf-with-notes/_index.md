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
- صدور PPT به PDF
- صدور PPTX به PDF
- یادداشت‌های گوینده
- PDF با یادداشت‌ها
- .NET
- C#
- Aspose.Slides
description: "فرمت‌های PPT و PPTX را با استفاده از Aspose.Slides برای .NET به PDF با یادداشت‌ها تبدیل کنید. طرح‌بندی‌ها و یادداشت‌های گوینده را برای ارائه‌های حرفه‌ای حفظ کنید."
---
## **بررسی کلی**

در این مقاله، شما نحوه تبدیل ارائه‌های PowerPoint به فرمت PDF همراه با یادداشت‌های گوینده با استفاده از Aspose.Slides را یاد می‌گیرید. این راهنما مراحل لازم را پوشش می‌دهد و مثال‌های کد را ارائه می‌کند تا به شما در انجام این کار به‌صورت کارآمد کمک کند. در انتهای این مقاله، قادر خواهید بود:

- فرآیند تبدیل را پیاده‌سازی کنید تا اسلایدهای PowerPoint را به اسناد PDF تبدیل کنید در حالی که یادداشت‌های گوینده حفظ می‌شوند.
- خروجی PDF را سفارشی کنید تا اطمینان حاصل شود که یادداشت‌های گوینده گنجانده شده و بر اساس نیازهای شما قالب‌بندی می‌شوند.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `Save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) می‌تواند برای تبدیل ارائه PPT یا PPTX به PDF همراه با یادداشت‌های گوینده مورد استفاده قرار گیرد. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notescommentslayoutingoptions/) تنظیم می‌کنید تا یادداشت‌های گوینده گنجانده شوند، و سپس فایل را به صورت PDF ذخیره می‌کنید. قطعه کد زیر نشان می‌دهد چگونه یک ارائه نمونه را به PDF در نمای اسلاید یادداشت‌ها تبدیل کنید.

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
            NotesPosition = NotesPositions.BottomFull // رندر کردن یادداشت‌های گوینده زیر اسلاید.
        }
    };

    // ذخیره ارائه به PDF همراه با یادداشت‌های گوینده.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
ممکن است بخواهید Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fa/conversion) را بررسی کنید. 
{{% /alert %}}