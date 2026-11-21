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
- یادداشت‌های گوینده
- PDF با یادداشت‌ها
- پایتون
- Aspose.Slides
description: "قالب‌های PPT، PPTX و ODP را با استفاده از Aspose.Slides برای پایتون به PDF با یادداشت‌ها تبدیل کنید. چیدمان‌ها و یادداشت‌های گوینده را برای ارائه‌های حرفه‌ای حفظ کنید."
---
## **بررسی کلی**

در این مقاله، نحوه تبدیل ارائه‌های PowerPoint به فرمت PDF با یادداشت‌های گوینده با استفاده از Aspose.Slides را یاد خواهید گرفت. این راهنما مراحل لازم را پوشش می‌دهد و مثال‌های کد را برای انجام مؤثر این کار ارائه می‌کند. در پایان این مقاله، قادر خواهید شد:

- فرایند تبدیل را پیاده‌سازی کنید تا اسلایدهای PowerPoint به اسناد PDF تبدیل شوند و یادداشت‌های گوینده حفظ شوند.
- خروجی PDF را سفارشی کنید تا اطمینان حاصل شود که یادداشت‌های گوینده گنجانده شده و مطابق نیازهای شما قالب‌بندی شده‌اند.

برای تنظیم ابعاد صفحه یادداشت‌ها و جهت قبل از خروجی، به [Notes Page Size](/slides/fa/python-net/notes-size/) مراجعه کنید.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) می‌تواند برای تبدیل ارائه PPT یا PPTX به PDF با یادداشت‌های گوینده استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notescommentslayoutingoptions/) پیکربندی می‌کنید تا یادداشت‌های گوینده درج شوند، و سپس فایل را به‌صورت PDF ذخیره می‌کنید. قطعه کد زیر نشان می‌دهد چگونه یک ارائه نمونه را به PDF در نمای اسلاید یادداشت‌ها تبدیل کنید.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # تنظیم گزینه‌های PDF برای رندر کردن یادداشت‌های گوینده.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # ذخیره ارائه به PDF با یادداشت‌های گوینده.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
ممکن است بخواهید مبدل آنلاین PowerPoint به PDF Aspose را بررسی کنید: [مبدل آنلاین PowerPoint به PDF](https://products.aspose.app/slides/fa/conversion).
{{% /alert %}}