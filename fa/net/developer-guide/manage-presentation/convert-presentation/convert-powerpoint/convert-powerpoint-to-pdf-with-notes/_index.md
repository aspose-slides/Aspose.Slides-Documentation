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
- ذخیره ارائه به PDF
- ذخیره PPT به PDF
- ذخیره PPTX به PDF
- صادرات PPT به PDF
- صادرات PPTX به PDF
- یادداشت‌های سخنران
- PDF با یادداشت‌ها
- .NET
- C#
- Aspose.Slides
description: "فرمت‌های PPT و PPTX را با استفاده از Aspose.Slides برای .NET به PDF با یادداشت‌ها تبدیل کنید. چیدمان‌ها و یادداشت‌های سخنران را برای ارائه‌های حرفه‌ای حفظ می‌کند."
---
## **نمای کلی**

در این مقاله، یاد می‌گیرید چگونه ارائه‌های PowerPoint را با یادداشت‌های سخنران به فرمت PDF تبدیل کنید با استفاده از Aspose.Slides. این راهنما مراحل لازم را پوشش می‌دهد و مثال‌های کد را برای انجام مؤثر این کار فراهم می‌کند. در پایان این مقاله، می‌توانید:

- فرآیند تبدیل را برای تبدیل اسلایدهای PowerPoint به اسناد PDF در حالی که یادداشت‌های سخنران حفظ می‌شوند، پیاده‌سازی کنید.
- خروجی PDF را سفارشی کنید تا اطمینان حاصل شود که یادداشت‌های سخنران گنجانده شده و طبق نیازهای شما قالب‌بندی شده‌اند.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `Save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) می‌تواند برای تبدیل ارائه PPT یا PPTX به PDF با یادداشت‌های سخنران استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notescommentslayoutingoptions/) برای گنجاندن یادداشت‌های سخنران پیکربندی می‌کنید، و سپس فایل را به عنوان PDF ذخیره می‌کنید. قطعه کد زیر نشان می‌دهد چگونه یک ارائه نمونه را به PDF در نمای اسلایدهای یادداشت تبدیل کنید.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // پیکربندی گزینه‌های PDF برای رندر کردن یادداشت‌های سخنران.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // نمایش یادداشت‌های سخنران زیر اسلاید.
        }
    };

    // ذخیره ارائه به PDF با یادداشت‌های سخنران.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="primary" %}} 
ممکن است بخواهید به مبدل آنلاین PowerPoint به PDF Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fa/conversion) مراجعه کنید. 
{{% /alert %}}