---
title: تبدیل ارائه‌ها به HTML5 در C++
linktitle: ارائه به HTML5
type: docs
weight: 40
url: /fa/cpp/export-to-html5/
keywords:
- پاورپوینت به HTML5
- OpenDocument به HTML5
- ارائه به HTML5
- اسلاید به HTML5
- PPT به HTML5
- PPTX به HTML5
- ODP به HTML5
- ذخیره PPT به‌صورت HTML5
- ذخیره PPTX به‌صورت HTML5
- ذخیره ODP به‌صورت HTML5
- خروجی PPT به HTML5
- خروجی PPTX به HTML5
- خروجی ODP به HTML5
- C++
- Aspose.Slides
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML5 واکنش‌گرا با Aspose.Slides برای C++. حفظ قالب‌بندی، انیمیشن‌ها و تعامل."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به HTML5 تبدیل کنید. این مقاله پوشش می‌دهد صادرات پایه HTML5 بدون افزونه‌های وب یا وابستگی‌های اضافی، همچنین گزینه‌هایی برای کنترل انیمیشن‌های شکل و انتقال اسلایدها. مقاله همچنین فرایند استاندارد صادرات PowerPoint به HTML را نشان می‌دهد، توضیح می‌دهد چگونه خروجی HTML5 را در حالت نمای اسلاید تولید کنید، و نشان می‌دهد چگونه نظرات را در سند صادر شده با تنظیم چیدمان آن‌ها گنجانید.

## **صادرات PowerPoint به HTML5**

این کد C++ نشان می‌دهد چگونه یک ارائه را به HTML5 صادر کنید.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
در این حالت، HTML تمیزی دریافت می‌کنید. 
{{% /alert %}}

ممکن است بخواهید تنظیمات انیمیشن‌های شکل و انتقال اسلایدها را به این صورت مشخص کنید:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **صادرات PowerPoint به HTML**

این کد C++ فرآیند استاندارد تبدیل PowerPoint به HTML را نشان می‌دهد:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

در این حالت، محتوای ارائه از طریق SVG به شکل زیر رندر می‌شود:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="توجه" color="warning" %}} 
هنگامی که از این روش برای صادرات PowerPoint به HTML استفاده می‌کنید، به دلیل رندر SVG، قادر به اعمال استایل یا انیمیشن بر روی عناصر خاص نخواهید بود. 
{{% /alert %}}

## **صادرات PowerPoint به نمای اسلاید HTML5**

**Aspose.Slides** به شما امکان می‌دهد یک ارائه PowerPoint را به سند HTML5 تبدیل کنید که در آن اسلایدها به صورت نمای اسلاید نمایش داده می‌شوند. در این حالت، وقتی فایل HTML5 حاصل را در مرورگر باز می‌کنید، ارائه را در حالت نمای اسلاید بر روی صفحه وب می‌بینید.

این کد C++ فرآیند صادرات PowerPoint به نمای اسلاید HTML5 را نشان می‌دهد:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **تبدیل یک ارائه به سند HTML5 با نظرات**

نظرات در PowerPoint ابزاری هستند که به کاربران اجازه می‌دهند یادداشت یا بازخورد خود را بر اسلایدهای ارائه بگذارند. این نظرات به‌ویژه در پروژه‌های مشترک مفید هستند، جایی که افراد متعدد می‌توانند پیشنهادات یا توضیحاتی را برای عناصر خاص اسلاید اضافه کنند بدون اینکه محتوای اصلی را تغییر دهند. هر نظر نام نویسنده را نشان می‌دهد، که ردیابی شخصی که نظر را گذاشته آسان می‌شود.

فرض کنید فایل ارائه PowerPoint زیر را در فایل «sample.pptx» ذخیره کرده‌ایم.

![دو نظر بر روی اسلاید ارائه](two_comments_pptx.png)

هنگام تبدیل یک ارائه PowerPoint به سند HTML5، می‌توانید به‌راحتی تعیین کنید آیا نظرات ارائه در سند خروجی گنجانده شوند یا نه. برای انجام این کار، باید پارامترهای نمایش نظرات را در متد `get_NotesCommentsLayouting` کلاس [Html5Options](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/) مشخص کنید.

مثال کد زیر یک ارائه را به سند HTML5 تبدیل می‌کند که نظرات در سمت راست اسلایدها نمایش داده می‌شوند.
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

سند «output.html» در تصویر زیر نشان داده شده است.

![نظرات در سند خروجی HTML5](two_comments_html5.png)

## **سوالات متداول**

### آیا می‌توانم کنترل کنم که آیا انیمیشن‌های اشیا و انتقال اسلایدها در HTML5 اجرا شوند؟

بله، HTML5 گزینه‌های جداگانه‌ای برای فعال یا غیرفعال کردن [انیمیشن‌های شکل](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/set_animateshapes/) و [انتقال اسلایدها](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/set_animatetransitions/) فراهم می‌کند.

### آیا خروجی نظرات پشتیبانی می‌شود و می‌توان آن‌ها را نسبت به اسلاید کجا قرار داد؟

بله، نظرات می‌توانند در HTML5 اضافه شوند و از طریق تنظیمات چیدمان برای یادداشت‌ها و نظرات به‌عنوان مثال در سمت راست اسلاید قرار گیرند.

### آیا می‌توانم لینک‌هایی را که جاوااسکریپت فراخوانی می‌کنند به دلایل امنیتی یا CSP عبور دهم؟

بله، یک [تنظیم](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) وجود دارد که به شما اجازه می‌دهد در هنگام ذخیره‌سازی، لینک‌های دارای فراخوانی جاوااسکریپت را نادیده بگیرید. این به تطبیق با سیاست‌های امنیتی سخت کمک می‌کند.