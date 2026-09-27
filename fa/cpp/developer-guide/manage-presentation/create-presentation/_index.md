---
title: ایجاد ارائه‌ها در C++
linktitle: ایجاد ارائه
type: docs
weight: 10
url: /fa/cpp/create-presentation/
keywords:
- ایجاد ارائه
- ارائه جدید
- ایجاد PPT
- PPT جدید
- ایجاد PPTX
- PPTX جدید
- ایجاد ODP
- ODP جدید
- پاورپوینت
- سند باز
- ارائه
- C++
- Aspose.Slides
description: "با Aspose.Slides در C++ ارائه‌ها را ایجاد کنید—فایل‌های PPT، PPTX و ODP تولید کنید، از پشتیبانی سند باز بهره‌مند شوید و آن‌ها را به‌صورت برنامه‌نویسی‌شده ذخیره کنید تا نتایج قابل اعتمادی به دست آورید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه در Aspose.Slides یک ارائه ایجاد کنید، یک جعبه متن به اولین اسلاید آن اضافه کنید، و نتیجه را به عنوان یک فایل ذخیره کنید. یک بخش پرسش‌وپاسخ کوتاه در انتها به سؤالات رایج درباره فرمت‌ها، قالب‌ها، اندازه‌گذاری اسلاید، واحدها، استفاده از حافظه، چندنخی، لایسنس، امضای دیجیتال و پشتیبانی از VBA می‌پردازد.

قبل از شروع، Aspose.Slides را به پروژه خود اضافه کنید: از NuGet در یک پروژه Visual Studio در ویندوز، یا از بسته ZIP با CMake در لینوکس. برای جزئیات به [Installation](/slides/fa/cpp/installation/) مراجعه کنید.

## **ایجاد یک ارائه PowerPoint**

برای ایجاد یک ارائه و قرار دادن یک جعبه متن در اسلاید اول آن، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید. یک ارائه جدید از پیش حاوی یک اسلاید خالی است.
2. آن اسلاید را با متد [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) و شاخص آن، 0، دریافت کنید.
3. یک مستطیل را با متد [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) اضافه کنید و متن آن را با متد [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/) تنظیم کنید.
4. ارائه را به‌عنوان فایل PPTX با متد [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) ذخیره کنید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

گوشه بالا‑چپ مستطیل ۵۰ پوینت از لبهٔ چپ و ۵۰ پوینت از لبهٔ بالای اسلاید فاصله دارد و مستطیل ۴۰۰ پوینت عرض و ۱۰۰ پوینت ارتفاع دارد. برنامه فایل *hello.pptx* را در پوشهٔ کاری خود ذخیره می‌کند، که شامل یک اسلاید حاوی مستطیل و متن آن است. بدون لایسنس، Aspose.Slides همچنین یک واترمارک ارزیابی به هر اسلایدی که ذخیره می‌کند اضافه می‌کند؛ برای جزئیات به [Licensing](/slides/fa/cpp/licensing/) مراجعه کنید.

## **پرسش‌وپاسخ**

### چه فرمت‌هایی می‌توانم یک ارائه جدید را به آن‌ها ذخیره کنم؟

می‌توانید به فرمت‌های [PPTX, PPT, و ODP](/slides/fa/cpp/save-presentation/) ذخیره کنید و به فرمت‌های [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/cpp/convert-powerpoint-to-xps/)، [HTML](/slides/fa/cpp/convert-powerpoint-to-html/)، [SVG](/slides/fa/cpp/render-a-slide-as-an-svg-image/) و [images](/slides/fa/cpp/convert-powerpoint-to-png/) صادر کنید، و موارد دیگر.

### آیا می‌توانم از یک قالب (POTX/POTM) شروع کرده و به‌عنوان یک PPTX معمولی ذخیره کنم؟

بله. قالب را بارگذاری کنید و به فرمت موردنظر ذخیره کنید؛ فرمت‌های POTX/POTM/PPTM و مشابه آن‌ها [پشتیبانی می‌شوند](/slides/fa/cpp/supported-file-formats/).

### چگونه می‌توانم اندازه/نسبت ابعاد اسلاید را هنگام ایجاد یک ارائه کنترل کنم؟

اندازهٔ [slide size](/slides/fa/cpp/slide-size/) را تنظیم کنید (از جمله پیش‌تنظیم‌های 4:3 و 16:9 یا ابعاد سفارشی) و تعیین کنید محتوا چگونه مقیاس‌بندی شود.

### ابعاد و مختصات به چه واحدی اندازه‌گیری می‌شوند؟

به پوینت: ۱ اینچ برابر با ۷۲ واحد است.

### چگونه می‌توانم ارائه‌های بسیار بزرگ (با تعداد زیاد فایل‌های رسانه‌ای) را برای کاهش مصرف حافظه مدیریت کنم؟

از [BLOB management strategies](/slides/fa/cpp/manage-blob/) استفاده کنید، ذخیره‌سازی در حافظه را با بهره‌گیری از فایل‌های موقت محدود کنید و نسبت به جریان‌های کاملاً در‑حافظه، گردش‌کار مبتنی بر فایل را ترجیح دهید.

### آیا می‌توانم ارائه‌ها را به‌صورت موازی ایجاد/ذخیره کنم؟

نمی‌توانید از همان نمونهٔ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) از [چندین رشته](/slides/fa/cpp/multithreading/) استفاده کنید. برای هر رشته یا فرآیند یک نمونهٔ جداگانه و ایزوله راه‌اندازی کنید.

### چگونه واترمارک آزمایشی و محدودیت‌ها را حذف کنم؟

[Apply a license](/slides/fa/cpp/licensing/) را یک‌بار برای هر فرآیند اجرا کنید. فایل XML لایسنس باید تغییر نیابد و تنظیم لایسنس در صورت وجود چندین رشته باید همگام‌سازی شود.

### آیا می‌توانم PPTX ای که ایجاد می‌کنم را به‌صورت دیجیتال امضا کنم؟

بله. [Digital signatures](/slides/fa/cpp/digital-signature-in-powerpoint/) (اضافه کردن و تأیید) برای ارائه‌ها پشتیبانی می‌شوند.

### آیا ماکروها (VBA) در ارائه‌های ایجاد شده پشتیبانی می‌شوند؟

بله. می‌توانید [create/edit VBA projects](/slides/fa/cpp/presentation-via-vba/) انجام دهید و فایل‌های فعال‌ماکرو مانند PPTM/PPSM را ذخیره کنید.