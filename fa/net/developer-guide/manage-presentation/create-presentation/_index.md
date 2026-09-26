---
title: ایجاد ارائه‌ها در .NET
linktitle: ایجاد ارائه
type: docs
weight: 10
url: /fa/net/create-presentation/
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
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ایجاد ارائه‌ها در .NET با Aspose.Slides — تولید فایل‌های PPT، PPTX و ODP، بهره‌گیری از پشتیبانی OpenDocument و ذخیره برنامه‌نویسی‌شده آن‌ها برای نتایج قابل اعتماد."
---
## **نمای کلی**

این مقاله نشان می‌دهد که چگونه یک ارائه در Aspose.Slides ایجاد کنید، یک جعبه متن به اسلاید اول آن اضافه کنید و نتیجه را به عنوان یک فایل ذخیره کنید. همچنین نحوه ایجاد و ذخیره یک ارائه خالی و نحوه باز کردن یک ارائه موجود در قالب پشتیبانی شده و ذخیره آن در قالب دیگر را نشان می‌دهد. یک بخش پرسش‌های متداول کوتاه در انتها به سؤالات رایج درباره قالب‌ها، الگوها، اندازه‌گیری اسلاید، واحدها، مصرف حافظه، چندنخی، مجوزها، امضاهای دیجیتال و پشتیبانی از VBA می‌پردازد.

قبل از شروع، Aspose.Slides را از NuGet به پروژه خود اضافه کنید. برای بسته‌ای که در ویندوز، لینوکس و macOS استفاده می‌شود به [Installation](/slides/fa/net/installation/) مراجعه کنید.

## **ایجاد ارائه پاورپوینت**

برای ایجاد یک ارائه و قرار دادن یک جعبه متن در اسلاید اول آن، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید. یک ارائه جدید از پیش شامل یک اسلاید خالی است.
2. آن اسلاید را از مجموعه [Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slides/fa/) با استفاده از اندیس 0 دریافت کنید.
3. یک مستطیل را با روش [AddAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addautoshape/) اضافه کنید و متن آن را با [text](https://reference.aspose.com/slides/fa/net/aspose.slides/itextframe/text/) تنظیم کنید.
4. ارائه را به عنوان فایل PPTX با استفاده از روش [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) ذخیره کنید.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

گوشه بالا‑چپ مستطیل 50 نقطه از لبه چپ و 50 نقطه از لبه بالای اسلاید فاصله دارد و مستطیل به عرض 400 نقطه و ارتفاع 100 نقطه است. فایل ذخیره‌شده شامل یک اسلاید با آن مستطیل و متن آن می‌شود. بدون داشتن لایسنس، Aspose.Slides همچنین یک علامت آب‌نشان ارزیابی به هر اسلایدی که ذخیره می‌کند اضافه می‌کند؛ برای جزئیات به [Licensing](/slides/fa/net/licensing/) مراجعه کنید.

## **ایجاد و ذخیره یک ارائه**

<a name="csharp-create-save-presentation"></a>

برای ایجاد یک ارائه خالی و ذخیره آن، یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید و آن را در هر قالبی از enumeration [SaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) ذخیره کنید. نتیجه یک ارائه با یک اسلاید خالی است.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **باز کردن و ذخیره یک ارائه**

<a name="csharp-open-save-presentation"></a>

برای تبدیل یک ارائه از یک قالب به قالب دیگر، با عبور مسیر آن به سازنده [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/presentation/) باز کنید، سپس آن را در قالب هدف ذخیره کنید. Aspose.Slides قالب ورودی را، مانند PPT، PPTX یا ODP، از خود فایل تشخیص می‌دهد.

مثال زیر انتظار دارد یک ارائه OpenDocument به نام *Sample.odp* در پوشه کاری موجود باشد و آن را به صورت PPTX ذخیره می‌کند.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **پرسش‌های متداول**

### چه قالب‌هایی می‌توانم یک ارائه جدید را به آن‌ها ذخیره کنم؟

می‌توانید به [PPTX, PPT, and ODP](/slides/fa/net/save-presentation/) ذخیره کنید و به [PDF](/slides/fa/net/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/net/convert-powerpoint-to-xps/)، [HTML](/slides/fa/net/convert-powerpoint-to-html/)، [SVG](/slides/fa/net/render-a-slide-as-an-svg-image/) و [images](/slides/fa/net/convert-powerpoint-to-png/) و دیگر قالب‌ها صادر کنید.

### آیا می‌توانم از یک الگو (POTX/POTM) شروع کنم و به عنوان PPTX معمولی ذخیره کنم؟

بله. الگو را بارگذاری کنید و به قالب موردنظر ذخیره کنید؛ قالب‌های POTX/POTM/PPTM و مشابه آن‌ها [پشتیبانی می‌شود](/slides/fa/net/supported-file-formats/).

### چگونه می‌توانم اندازه/نسبت ابعاد اسلاید را هنگام ایجاد یک ارائه کنترل کنم؟

اندازه [slide size](/slides/fa/net/slide-size/) را تنظیم کنید (شامل پیش‌تنظیم‌هایی مانند 4:3 و 16:9 یا ابعاد سفارشی) و انتخاب کنید که محتوا چگونه مقیاس‌بندی شود.

### اندازه‌ها و مختصات به چه واحدهایی اندازه‌گیری می‌شوند؟

در واحد نقطه: یک اینچ برابر با 72 واحد است.

### چگونه می‌توانم ارائه‌های بسیار بزرگ (با فایل‌های رسانه‌ای متعدد) را برای کاهش مصرف حافظه مدیریت کنم؟

از [BLOB management strategies](/slides/fa/net/manage-blob/) استفاده کنید، ذخیره‌سازی در حافظه را با بهره‌گیری از فایل‌های موقت محدود کنید و به‌جای جریان‌های کاملاً در‑حافظه، گردش‌کار مبتنی بر فایل را ترجیح دهید.

### آیا می‌توانم ارائه‌ها را به‌صورت موازی ایجاد/ذخیره کنم؟

نمی‌توانید از همان نمونه [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) در [multiple threads](/slides/fa/net/multithreading/) استفاده کنید. برای هر رشته یا فرآیند یک نمونه جداگانه و ایزوله اجرا کنید.

### چگونه می‌توانم علامت آب‌نشان آزمایشی و محدودیت‌ها را حذف کنم؟

[Apply a license](/slides/fa/net/licensing/) را یک بار برای هر فرآیند اعمال کنید. XML لایسنس باید بدون تغییر باقی بماند و تنظیم لایسنس باید همگام‌سازی شود اگر چندین رشته درگیر باشند.

### آیا می‌توانم PPTX ایجاد شده را به‌صورت دیجیتالی امضا کنم؟

بله. [Digital signatures](/slides/fa/net/digital-signature-in-powerpoint/) (اضافه کردن و تأیید) برای ارائه‌ها پشتیبانی می‌شود.

### آیا ماکروها (VBA) در ارائه‌های ایجاد شده پشتیبانی می‌شوند؟

بله. می‌توانید [create/edit VBA projects](/slides/fa/net/presentation-via-vba/) را انجام دهید و فایل‌های فعال‑ماکرو مانند PPTM/PPSM را ذخیره کنید.