---
title: تبدیل ارائه‌های PowerPoint به PDF با یادداشت‌ها در C++
linktitle: PowerPoint به PDF با یادداشت‌ها
type: docs
weight: 50
url: /fa/cpp/convert-powerpoint-to-pdf-with-notes/
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
- C++
- Aspose.Slides
description: "تبدیل فرمت‌های PPT و PPTX به PDF با یادداشت‌ها با استفاده از Aspose.Slides برای C++. حفظ چیدمان‌ها و یادداشت‌های گوینده برای ارائه‌های حرفه‌ای."
---
## **بررسی کلی**

در این مقاله، نحوه تبدیل ارائه‌های PowerPoint به فرمت PDF همراه با یادداشت‌های گوینده با استفاده از Aspose.Slides را خواهید آموخت. این راهنما گام‌های لازم را پوشش می‌دهد و مثال‌های کد را برای کمک به انجام کار به‌صورت کارآمد فراهم می‌کند. در پایان این مقاله، قادر خواهید بود:

- فرآیند تبدیل را برای تبدیل اسلایدهای PowerPoint به اسناد PDF در حالی که یادداشت‌های گوینده حفظ می‌شوند، پیاده‌سازی کنید.
- PDF خروجی را سفارشی کنید تا اطمینان حاصل شود که یادداشت‌های گوینده گنجانده شده و مطابق با نیازهای شما قالب‌بندی می‌شوند.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `Save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) می‌تواند برای تبدیل یک ارائه PPT یا PPTX به PDF همراه با یادداشت‌های گوینده استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/) پیکربندی می‌کنید تا یادداشت‌های گوینده گنجانده شوند و سپس فایل را به‌عنوان PDF ذخیره می‌کنید. قطعه کد زیر نشان می‌دهد چگونه یک ارائه نمونه را به PDF در نمای اسلاید یادداشت‌ها تبدیل کنید.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// پیکربندی گزینه‌های PDF برای رندر کردن یادداشت‌های گوینده.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // رندر کردن یادداشت‌های گوینده زیر اسلاید.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// ذخیره ارائه به PDF همراه با یادداشت‌های گوینده.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="primary" %}} 
ممکن است بخواهید مبدل آنلاین PowerPoint به PDF Aspose را بررسی کنید. 
{{% /alert %}}