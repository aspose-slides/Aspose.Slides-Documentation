---
title: مدیریت اشیاء جوهر ارائه در C++
linktitle: مدیریت جوهر
type: docs
weight: 95
url: /fa/cpp/manage-ink/
keywords:
- جوهر
- شیء جوهر
- ردپای جوهر
- مدیریت جوهر
- رسم جوهر
- رسم
- صادر کردن جوهر
- رندر جوهر
- مخفی کردن جوهر
- IInkOptions
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "اشیاء جوهر PowerPoint را مدیریت کنید، ردپاها و ویژگی‌های قلم مو را ویرایش کنید و ظاهر جوهر را در زمان خروجی PDF، HTML، SVG، TIFF و تصویر با استفاده از Aspose.Slides برای C++ کنترل کنید."
---
## **مقدمه**

PowerPoint یک ویژگی جوهر ارائه می‌دهد که به شما امکان رسم خطوط آزاد شکل را می‌دهد. می‌توان از جوهر برای برجسته‌سازی اشیاء دیگر، نشان دادن ارتباطات و فرآیندها و جلب توجه به موارد خاص در یک اسلاید استفاده کرد.

فضای نام [Aspose.Slides.Ink](https://reference.aspose.com/slides/fa/cpp/aspose.slides.ink/) شامل کلاس‌ها و رابط‌های لازم برای کار با اشیاء جوهر است. برای مثال، رابط [IInk](https://reference.aspose.com/slides/fa/cpp/aspose.slides.ink/iink/) نمایانگر یک شیء جوهر در یک اسلاید است.

## **تفاوت بین اشیاء معمولی و اشیاء جوهر**

اشیاء در اسلاید PowerPoint معمولاً توسط اشیاء شکل (shape) نمایان می‌شوند. در ساده‌ترین شکل، یک shape یک ظرف است که ناحیهٔ خود شیء (قاب آن) به همراه ویژگی‌هایی مانند اندازهٔ ظرف، شکل و پس‌زمینه را تعریف می‌کند. برای اطلاعات بیشتر، به [Shape Layout Format](https://docs.aspose.com/slides/fa/cpp/shape-manipulations/#access-layout-formats-for-shape) مراجعه کنید.

با این حال، هنگامی که PowerPoint یک شیء جوهر را پردازش می‌کند، تمام ویژگی‌های قاب شیء (ظرف) را به جز اندازهٔ آن نادیده می‌گیرد. اندازهٔ ناحیهٔ ظرف توسط متدهای استاندارد [IShape::get_Width](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_width/) و [IShape::get_Height](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_height/) تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **ردپاهای جوهر (Ink Traces)**

یک ردپای جوهر یک عنصر پایه‌ای است که مسیر قلم را هنگام نوشتن دیجیتال ضبط می‌کند. ردپا یک توالی از نقاط متصل را ذخیره می‌کند.

ساده‌ترین شکل کدگذاری، مختصات X و Y هر نقطه نمونه را مشخص می‌کند. هنگامی که تمامی نقاط متصل رندر شوند، تصویر زیر تولید می‌شود:

![ink_powerpoint2](ink_powerpoint2.png)

## **ویژگی‌های قلم مو برای رسم**

قلم مو برای رسم خطوطی که نقاط یک ردپای جوهر را به هم متصل می‌کند، استفاده می‌شود. قلم مو دارای رنگ و اندازهٔ خاص خود است که توسط متدهای [IInkBrush::get_Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides.ink/iinkbrush/get_color/) و [IInkBrush::get_Size](https://reference.aspose.com/slides/fa/cpp/aspose.slides.ink/iinkbrush/get_size/) ارائه می‌شود.

### **تنظیم رنگ قلم مو جوهر**

این کد C++ نشان می‌دهد که چگونه رنگ یک قلم مو جوهر را تنظیم کنید:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **تنظیم اندازه قلم مو جوهر**

این کد C++ نشان می‌دهد که چگونه اندازهٔ یک قلم مو جوهر را تنظیم کنید:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

به‌طور کلی، عرض و ارتفاع قلم مو مطابقت ندارند، بنابراین PowerPoint اندازهٔ قلم مو را نمایش نمی‌دهد (بخش مربوطه خاکستری است). وقتی عرض و ارتفاع قلم مو برابر باشند، PowerPoint اندازهٔ آن را به این شکل نمایش می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح بیشتر، ارتفاع شیء جوهر را افزایش می‌دهیم و ابعاد مهم را بررسی می‌کنیم:

![ink_powerpoint4](ink_powerpoint4.png)

ظرف (قاب) اندازهٔ قلم موها را در نظر نمی‌گیرد—همیشه فرض می‌کند که ضخامت خط صفر است (به تصویر قبلی مراجعه کنید).

بنابراین، برای تعیین ناحیهٔ قابل مشاهدهٔ کل شیء جوهر، باید اندازهٔ قلم موهای ردپاهای آن را در نظر گرفت. در اینجا، شیء هدف (ردپای متن دست‌نویس) به اندازهٔ ظرف (قاب) مقیاس‌بندی شده است. وقتی اندازهٔ ظرف تغییر می‌کند، اندازهٔ قلم مو ثابت می‌ماند و بالعکس.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint رفتار مشابهی را برای اشیاء متنی به کار می‌برد:

![ink_powerpoint6](ink_powerpoint6.png)

## **کنترل ظاهر جوهر هنگام خروجی و رندر**

Aspose.Slides رابط [IInkOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/iinkoptions/) را برای کنترل نحوهٔ نمایش اشیاء جوهر در خروجی یا رندر ارائه می‌دهد. می‌توانید با استفاده از متدهای آن جوهر را به‌طور کامل مخفی کنید یا نحوهٔ تفسیر عملیات ماسک قلم مو جوهر را تغییر دهید.

گزینه‌های جوهر از طریق گزینه‌های خروجی یا رندر برای چندین نوع خروجی در دسترس هستند:

| خروجی | متد گزینه‌های جوهر |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| تصویر اسلاید | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

دو تنظیم مشترک از طریق این متدها موجود است:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/iinkoptions/set_hideink/) تعیین می‌کند که آیا اشیاء جوهر در خروجی گنجانده شوند یا نه. مقدار پیش‌فرض `false` است.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) تعیین می‌کند که آیا یک عملیات ماسک به‌عنوان شفافیت تفسیر شود یا نه. مقدار پیش‌فرض `true` است؛ برای استفاده از عملیات ROP مقدار را به `false` تغییر دهید.

### **مخفی کردن اشیاء جوهر در خروجی PDF**

به‌صورت پیش‌فرض، اشیاء جوهر در هنگام خروجی قابل مشاهده‌اند. هنگام نیاز به خروجی تمیز بدون حاشیه‌نویسی یا سایر محتویات جوهر، `true` را به متد [IInkOptions::set_HideInk](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/iinkoptions/set_hideink/) پاس دهید.

مثال C++ زیر یک ارائه را به PDF صادر می‌کند در حالی که تمام اشیاء جوهر مخفی می‌شوند:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **مخفی کردن اشیاء جوهر هنگام رندر اسلاید به تصویر**

برای مخفی کردن اشیاء جوهر هنگام رندر اسلایدها به تصاویر بیت‌مپ، گزینه‌های [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) را پیکربندی کنید و گزینه‌های رندر را به متد [ISlide::GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage/) پاس دهید.

مثال C++ زیر اسلاید اول را به تصویر PNG بدون اشیاء جوهر رندر می‌کند:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **کنترل رندر ماسک جوهر**

متد [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) نحوهٔ تفسیر عملیات ماسک را هنگام رندر قلم موهای جوهر کنترل می‌کند. مقدار پیش‌فرض `true` است که از شفافیت استفاده می‌کند. برای استفاده از عملیات ROP، مقدار را به `false` تغییر دهید.

مثال C++ زیر یک اسلاید را به SVG صادر می‌کند و برای عملیات ماسک جوهر از رندر مبتنی بر ROP استفاده می‌کند:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

همین تنظیم می‌تواند از طریق [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) هنگام خروجی ارائه یا رندر اسلاید به TIFF اعمال شود.

### **انتخاب مخفی یا نگه‌داشتن جوهر**

از [IInkOptions::set_HideInk](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/iinkoptions/set_hideink/) همراه با `true` استفاده کنید وقتی فایل خروجی باید نسخهٔ تمیز یک ارائه حاوی حاشیه‌نویسی باشد، برای مثال نسخهٔ نهایی برای توزیع بدون علامت‌های بررسی.

وقتی جوهر باید قابل مشاهده بماند (تنظیم پیش‌فرض `false`)، از آن زمانی استفاده کنید که حاشیه‌نویسی جوهر بخشی از محتوا باشد، مانند نظرات بررسی، یادداشت‌های دست‌نویس، برجسته‌سازی یا رسم‌هایی که باید در نتیجهٔ خروجی قابل مشاهده باشند. این امکان را می‌دهد تا برنامه‌ها بدون تغییر در اشیاء جوهر منبع، خروجی‌های بررسی و نهایی جداگانه‌ای از یک ارائه تولید کنند.

## **سؤال‌های متداول**

**آیا می‌توانم رنگ یا اندازهٔ یک خط جوهر موجود را تغییر دهم؟**

بله. ردپا را از [IInk::get_Traces](https://reference.aspose.com/slides/fa/cpp/aspose.slides.ink/iink/get_traces/) دریافت کنید، سپس [IInkTrace::get_Brush](https://reference.aspose.com/slides/fa/cpp/aspose.slides.ink/iinktrace/get_brush/) را تغییر دهید. می‌توانید متدهای [IInkBrush::set_Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides.ink/iinkbrush/set_color/) و [IInkBrush::set_Size](https://reference.aspose.com/slides/fa/cpp/aspose.slides.ink/iinkbrush/set_size/) را روی قلم مو فراخوانی کنید.

**آیا مخفی کردن جوهر منبع ارائه را تغییر می‌دهد؟**

خیر. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/iinkoptions/set_hideink/) فقط بر نتایج رندر یا خروجی تأثیر می‌گذارد؛ اشیاء جوهر در ارائه منبع حذف یا تغییر نمی‌شوند.

**کدام فرمت‌های خروجی از گزینه‌های جوهر پشتیبانی می‌کنند؟**

می‌توانید گزینه‌های جوهر را برای PDF، HTML، SVG، TIFF و تصاویر بیت‌مپ اسلاید از طریق گزینه‌های خروجی یا رندری که در بالا نشان داده شد، پیکربندی کنید.

**مطالعهٔ بیشتر**

* برای آشنایی با اشکال به‌طور کلی، بخش [PowerPoint Shapes](https://docs.aspose.com/slides/fa/cpp/powerpoint-shapes/) را ببینید.
* برای اطلاعات بیشتر درباره مقادیر مؤثر، به [Shape Effective Properties](https://docs.aspose.com/slides/fa/cpp/shape-effective-properties/#get-effective-font-height-value) مراجعه کنید.
* برای جزئیات خروجی PDF، به [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/fa/cpp/convert-powerpoint-to-pdf/) نگاه کنید.
* برای جزئیات خروجی HTML، به [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/fa/cpp/convert-powerpoint-to-html/) مراجعه کنید.
* برای جزئیات خروجی SVG، به [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/fa/cpp/render-a-slide-as-an-svg-image/) مراجعه کنید.
* برای جزئیات خروجی TIFF، به [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/fa/cpp/convert-powerpoint-to-tiff/) نگاه کنید.
* برای جزئیات رندر اسلاید به تصویر، به [Convert Presentation Slides to Images](https://docs.aspose.com/slides/fa/cpp/convert-slide/) مراجعه کنید.