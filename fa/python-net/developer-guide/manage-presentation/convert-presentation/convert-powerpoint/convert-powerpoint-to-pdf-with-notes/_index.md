---
title: تبدیل ارائه‌ها به PDF با یادداشت‌ها در پایتون
linktitle: ارائه به PDF با یادداشت‌ها
type: docs
weight: 50
url: /fa/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- تبدیل پاورپوینت
- تبدیل سند باز
- تبدیل ارائه
- تبدیل PPT
- تبدیل PPTX
- تبدیل ODP
- پاورپوینت به PDF
- سند باز به PDF
- ارائه به PDF
- PPT به PDF
- PPTX به PDF
- ODP به PDF
- یادداشت‌های سخنران
- PDF با یادداشت‌ها
- پایتون
- Aspose.Slides
description: "تبدیل فرمت‌های PPT، PPTX و ODP به PDF با یادداشت‌ها با استفاده از Aspose.Slides برای پایتون. حفظ چیدمان‌ها و یادداشت‌های سخنران برای ارائه‌های حرفه‌ای."
---
## **بررسی اجمالی**

در این مقاله، خواهید آموخت که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به فرمت PDF همراه با یادداشت‌های سخنران تبدیل کنید. این راهنما مراحل لازم را پوشش می‌دهد و مثال‌های کد را برای کمک به انجام کار به‌صورت کارآمد ارائه می‌دهد. در پایان این مقاله، قادر خواهید بود:

- فرایند تبدیل را برای تبدیل اسلایدهای PowerPoint به اسناد PDF با حفظ یادداشت‌های سخنران پیاده‌سازی کنید.
- خروجی PDF را سفارشی کنید تا اطمینان حاصل شود که یادداشت‌های سخنران گنجانده شده و بر اساس نیازهای شما قالب‌بندی شده‌اند.

## **تبدیل پاورپوینت به PDF با یادداشت‌ها**

متد `save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) می‌تواند برای تبدیل یک ارائه PPT یا PPTX به PDF همراه با یادداشت‌های سخنران استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notescommentslayoutingoptions/) برای گنجاندن یادداشت‌های سخنران پیکربندی می‌کنید، و سپس فایل را به‌عنوان PDF ذخیره می‌کنید. قطعه کد زیر نشان می‌دهد که چگونه یک ارائه نمونه را به PDF در نمای اسلایدهای یادداشت‌ها تبدیل کنید.

```py
with slides.Presentation("sample.pptx") as presentation:

    # پیکربندی گزینه‌های PDF برای رندر کردن یادداشت‌های سخنران.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # ذخیره ارائه به PDF همراه با یادداشت‌های سخنران.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="primary" %}} 
ممکن است بخواهید به Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fa/conversion) سر بزنید. 
{{% /alert %}}