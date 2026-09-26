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
- ذخیره PPT به عنوان PDF
- ذخیره PPTX به عنوان PDF
- صادرات PPT به PDF
- صادرات PPTX به PDF
- یادداشت‌های سخنران
- PDF با یادداشت‌ها
- C++
- Aspose.Slides
description: "فرمت‌های PPT و PPTX را با استفاده از Aspose.Slides برای C++ به PDF با یادداشت‌ها تبدیل کنید. چیدمان‌ها و یادداشت‌های سخنران را برای ارائه‌های حرفه‌ای حفظ کنید."
---
## **نمای کلی**

در این مقاله، نحوه تبدیل ارائه‌های PowerPoint به فرمت PDF با یادداشت‌های سخنران را با استفاده از Aspose.Slides می‌آموزید. این راهنما گام‌های لازم را پوشش می‌دهد و مثال‌های کد را برای انجام مؤثر این کار فراهم می‌کند. در پایان این مقاله، می‌توانید:

- فرآیند تبدیل را برای تبدیل اسلایدهای PowerPoint به اسناد PDF در حالی که یادداشت‌های سخنران حفظ می‌شوند، پیاده‌سازی کنید.
- خروجی PDF را سفارشی کنید تا اطمینان حاصل شود که یادداشت‌های سخنران گنجانده شده و مطابق نیازهای شما قالب‌بندی شده‌اند.

برای تنظیم ابعاد و جهت صفحه یادداشت‌ها قبل از استخراج، به [Notes Page Size](/slides/fa/cpp/notes-size/) مراجعه کنید.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `Save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) می‌تواند برای تبدیل یک ارائه PPT یا PPTX به PDF همراه با یادداشت‌های سخنران استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/) برای گنجاندن یادداشت‌های سخنران پیکربندی می‌کنید و سپس فایل را به صورت PDF ذخیره می‌کنید. قطعه کد زیر نشان می‌دهد چگونه یک ارائه نمونه را در نمای اسلایدهای یادداشت به PDF تبدیل کنید.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // نمایش یادداشت‌های سخنران زیر اسلاید.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
ممکن است بخواهید مبدل آنلاین پاورپوینت به PDF Aspose را بررسی کنید: Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fa/conversion). 
{{% /alert %}}