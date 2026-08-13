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
- صدور PPT به PDF
- صدور PPTX به PDF
- یادداشت‌های سخنران
- PDF با یادداشت‌ها
- C++
- Aspose.Slides
description: "قالب‌های PPT و PPTX را با یادداشت‌ها به PDF تبدیل کنید با استفاده از Aspose.Slides برای C++. طرح‌بندی‌ها و یادداشت‌های سخنران را برای ارائه‌های حرفه‌ای حفظ کنید."
---
## **نمای کلی**

در این مقاله، یاد می‌گیرید چگونه ارائه‌های PowerPoint را به فرمت PDF با یادداشت‌های سخنران تبدیل کنید با استفاده از Aspose.Slides. این راهنما گام‌های لازم را پوشش می‌دهد و مثال‌های کدی برای کمک به انجام کار به طور کارآمد ارائه می‌کند. در پایان این مقاله، می‌توانید:

- پیاده‌سازی فرآیند تبدیل برای تبدیل اسلایدهای PowerPoint به اسناد PDF در حالی که یادداشت‌های سخنران حفظ می‌شوند.
- سفارشی‌سازی PDF خروجی برای اطمینان از اینکه یادداشت‌های سخنران گنجانده شده و مطابق با نیازهای شما قالب‌بندی شوند.

## **تبدیل PowerPoint به PDF با یادداشت‌ها**

متد `Save` در کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) می‌تواند برای تبدیل یک ارائه PPT یا PPTX به PDF با یادداشت‌های سخنران استفاده شود. با Aspose.Slides، به سادگی ارائه را بارگذاری می‌کنید، گزینه‌های چیدمان را با استفاده از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/) پیکربندی می‌کنید تا یادداشت‌های سخنران گنجانده شوند، سپس فایل را به عنوان PDF ذخیره می‌کنید. قطعه کد زیر نشان می‌دهد چگونه یک ارائه نمونه را به PDF در نمایش اسلایدهای یادداشت تبدیل کنید.

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

// پیکربندی گزینه‌های PDF برای رندر کردن یادداشت‌های سخنران.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // یادداشت‌های سخنران را زیر اسلاید رندر می‌کند.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// ذخیره ارائه به PDF با یادداشت‌های سخنران.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
ممکن است بخواهید مبدل آنلاین PowerPoint به PDF Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/fa/conversion) را بررسی کنید. 
{{% /alert %}}