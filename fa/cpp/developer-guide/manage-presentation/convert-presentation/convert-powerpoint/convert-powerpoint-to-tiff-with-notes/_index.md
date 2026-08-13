---
title: تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها در C++
linktitle: PowerPoint به TIFF با یادداشت‌ها
type: docs
weight: 100
url: /fa/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به TIFF
- ارائه به TIFF
- اسلاید به TIFF
- PPT به TIFF
- PPTX به TIFF
- ذخیره PPT به عنوان TIFF
- ذخیره PPTX به عنوان TIFF
- صدور PPT به TIFF
- صدور PPTX به TIFF
- PowerPoint با یادداشت‌ها
- ارائه با یادداشت‌ها
- اسلاید با یادداشت‌ها
- PPT با یادداشت‌ها
- PPTX با یادداشت‌ها
- TIFF با یادداشت‌ها
- C++
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به TIFF با یادداشت‌ها با استفاده از Aspose.Slides برای C++. یاد بگیرید چگونه اسلایدها را با یادداشت‌های سخنران به‌صورت کارآمد صادر کنید."
---
## **معرفی**

Aspose.Slides for C++ راه‌حلی ساده برای تبدیل ارائه‌های PowerPoint و OpenDocument (PPT، PPTX و ODP) همراه با یادداشت‌ها به قالب TIFF ارائه می‌دهد. این قالب برای ذخیره‌سازی تصاویر با کیفیت بالا، چاپ و بایگانی اسناد به‌طور گسترده استفاده می‌شود. با Aspose.Slides می‌توانید نه تنها کل ارائه‌ها را با یادداشت‌های سخنران صادر کنید، بلکه تصویرهای بندانگشتی اسلاید را در نمای Notes Slide نیز ایجاد نمایید. فرایند تبدیل ساده و کارآمد است و از متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) برای تبدیل کل ارائه به مجموعه‌ای از تصاویر TIFF در حالی که یادداشت‌ها و چیدمان حفظ می‌شود، استفاده می‌کند.

## **تبدیل یک ارائه به TIFF همراه با یادداشت‌ها**

ذخیره‌ی یک ارائه PowerPoint یا OpenDocument به TIFF با یادداشت‌ها با استفاده از Aspose.Slides for C++ شامل مراحل زیر است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید: فایل PowerPoint یا OpenDocument را بارگذاری کنید.  
2. گزینه‌های چیدمان خروجی را تنظیم کنید: از کلاس [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/notescommentslayoutingoptions/) برای تعیین نحوه نمایش یادداشت‌ها و نظرات استفاده کنید.  
3. ارائه را به TIFF ذخیره کنید: گزینه‌های پیکربندی‌شده را به متد [Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) منتقل کنید.

فرض کنید فایلی به نام «speaker_notes.pptx» داریم که حاوی اسلاید زیر است:

![اسلاید ارائه همراه با یادداشت‌های سخنران](slide_with_notes.png)

کد زیر نشان می‌دهد چگونه می‌توانید ارائه را به تصویر TIFF در نمای Notes Slide تبدیل کنید با استفاده از متد [set_SlidesLayoutOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// یک شیء از کلاس Presentation که نمایانگر فایل ارائه است ایجاد کنید.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // یادداشت‌ها را زیر اسلاید نمایش دهید.

// پیکربندی گزینه‌های TIFF با چیدمان یادداشت‌ها.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// ذخیره ارائه به TIFF همراه با یادداشت‌های سخنران.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

نتیجه:

![تصویر TIFF همراه با یادداشت‌های سخنران](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
به برنامه‌ی رایگان Aspose **تبدیل‌کننده PowerPoint به پوستر** مراجعه کنید: https://products.aspose.app/slides/fa/conversion/convert-ppt-to-poster-online
{{% /alert %}}

## **پرسش‌های متداول**

### آیا می‌توانم موقعیت ناحیه یادداشت‌ها را در TIFF نهایی کنترل کنم؟

بله. از [تنظیمات چیدمان یادداشت‌ها](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) استفاده کنید تا بین گزینه‌هایی مانند `None`، `BottomTruncated` یا `BottomFull` انتخاب کنید؛ که به ترتیب یادداشت‌ها را مخفی می‌کند، در یک صفحه جای می‌دهد، یا اجازه می‌دهد به صفحات اضافی جاری شوند.

### چگونه می‌توانم اندازه‌ی فایل TIFF با یادداشت‌ها را بدون کاهش قابل مشاهده کیفیت کاهش دهم؟

یک [فشرده‌سازی کارآمد](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (مثلاً `LZW` یا `RLE`) انتخاب کنید، DPI معقولی تنظیم کنید و در صورت امکان از یک [فرمت پیکسل](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) پایین‌تر (مانند 8 bpp یا 1 bpp برای تک‌رنگ) استفاده کنید. کمی کاهش [ابعاد تصویر](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/set_imagesize/) نیز می‌تواند بدون به‌هم‌ریختن خوانایی، به کاهش حجم کمک کند.

### آیا قلم در یادداشت‌ها بر نتیجه تأثیر می‌گذارد اگر قلم‌های اصلی در سیستم موجود نباشند؟

بله. قلم‌های گمشده موجب [جایگزینی](/slides/fa/cpp/font-selection-sequence/) می‌شوند که می‌تواند معیارهای متنی و ظاهر را تغییر دهد. برای جلوگیری از این موضوع، [قلم‌های مورد نیاز را فراهم کنید](/slides/fa/cpp/custom-font/) یا یک [قلم پیش‌فرض جایگزین](/slides/fa/cpp/fallback-font/) تنظیم کنید تا از استفاده قلم‌های موردنظر اطمینان حاصل شود.