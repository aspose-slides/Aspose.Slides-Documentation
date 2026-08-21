---
title: عملیات ارائه کم‌کد در .NET
linktitle: API کم‌کد
type: docs
weight: 50
url: /fa/net/low-code-presentation-operations/
keywords:
- API ارائه کم‌کد
- تبدیل ارائه
- ادغام ارائه‌ها
- تکرار اسلایدها
- تکرار اشکال
- تکرار متن
- جمع‌آوری اشکال
- فشرده‌سازی ارائه
- حذف استادهای استفاده‌نشده
- حذف طرح‌بندی‌های استفاده‌نشده
- فشرده‌سازی قلم‌های جاسازی‌شده
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "از API کم‌کد Aspose.Slides در .NET برای تبدیل و ادغام ارائه‌ها، تکرار محتوا، جمع‌آوری اشکال و کاهش حجم ارائه استفاده کنید."
---
## **مروری کلی**

فضای‌نامی [Aspose.Slides.LowCode](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/) کلاس‌های کمکی استاتیک برای عملیات رایج ارائه اسلاید فراهم می‌کند. این کمکی‌ها جریان‌های کاری مدل شیء که به‌طور مکرر استفاده می‌شوند را در روش‌های متمرکز می‌پوشانند، به‌طوری که می‌توانید فایل‌ها را تبدیل یا ترکیب کنید، عناصر ارائه را پردازش کنید، اشکال را جمع‌آوری کنید و محتوای استفاده‌نشده را با کد کمتر حذف نمایید.

کمک‌های کم‌کد زمانی مفیدترند که عملیات بر کل فایل یا ارائه اعمال شود و جریان کاری پیش‌فرض با نیازهای شما منطبق باشد. در صورتی که نیاز به کنترل دقیق‌تر روی اسلایدهای فردی، استادها، طرح‌بندی‌ها، اشکال، تنظیمات خروجی یا روابط بین عناصر ارائه داشته باشید، از مدل شیء کامل [Aspose.Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/) استفاده کنید.

جدول زیر خلاصه‌ای از کمک‌های موجود را ارائه می‌دهد:

| کمک‌کننده | استفاده برای |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/convert/) | تبدیل یک ارائه به قالب دیگر با فراخوانی مستقیم فایل‑به‑فایل. |
| [Merger](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/merger/) | ترکیب کامل فایل‌های ارائه با همان فرمت. |
| [ForEach](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/) | اجرای یک عمل برای هر اسلاید، شکل، پاراگراف یا بخش متن. |
| [Collect](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/collect/) | بازیابی اشکال از کل ارائه برای پردازش یا تجزیه و تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/) | حذف استادها و طرح‌بندی‌های استفاده‌نشده و کاهش داده‌های قلم‌های جاسازی‌شده. |

## **تبدیل یک ارائه**

از [Convert.AutoByExtension](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/convert/autobyextension/) استفاده کنید زمانی که پسوند فایل خروجی به‌تنهایی کافی باشد تا فرمت خروجی انتخاب شود. این متد ارائه منبع را باز می‌کند، فرمت مورد نیاز را از مسیر خروجی تعیین می‌کند و نتیجه را می‌نویسد.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

کلاس [Convert](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/convert/) همچنین روش‌های اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF فراهم می‌کند. وقتی نیاز به بازرسی یا تغییر ارائه قبل از خروجی یا پیکربندی گزینه‌ای دارید که توسط کمک‌کننده منتخب در دسترس نیست، از مدل شیء کامل استفاده کنید. برای جریان‌های کاری و گزینه‌های خاص فرمت، به صفحه [Convert Presentation](/net/convert-presentation/) مراجعه کنید.

## **ترکیب ارائه‌ها**

از [Merger.Process](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/merger/process/) برای ترکیب کامل فایل‌های ارائه با یک فراخوانی استفاده کنید. ارائه‌های ورودی باید همان فرمت فایل را داشته باشند.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

این کمک‌کننده زمانی مناسب است که تمام اسلایدها باید به‌صورت پیوسته به یک نتیجه اضافه شوند بدون این‌که به‌صورت فردی انتخاب یا بازنقشه شوند. وقتی نیاز به ترکیب اسلایدهای انتخابی، اعمال استاد یا طرح‌بندی مقصد، نگهداری صریح بخش‌ها یا تطبیق اندازه‌های متفاوت اسلاید دارید، از مدل شیء کامل استفاده کنید. برای این سناریوها به صفحه [Merge Presentations](/net/merge-presentation/) مراجعه کنید.

## **تکرار در عناصر ارائه**

کلاس [ForEach](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/) یک فراخوانی‌گری (callback) برای هر نوع عنصر درخواستی ارائه فراخوانی می‌کند. این روش از تو در تو شدن حلقه‌های جمع‌آوری جلوگیری می‌کند و برای بازرسی یا اعمال تغییرات فرمت در سطح کل ارائه مناسب است.

مثال زیر از [ForEach.Slide](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/slide/)، [ForEach.Shape](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/shape/)، [ForEach.Paragraph](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/paragraph/)، و [ForEach.Portion](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/portion/) برای بازرسی عناصر مربوطه استفاده می‌کند:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

به‌طور پیش‌فرض، عبور از اشکال و متن در سطح کل ارائه شامل اسلایدهای معمولی، استاد و طرح‌بندی می‌شود. بارگذاری‌های دارای پارامتر `includeNotes` می‌توانند اسلایدهای یادداشت‌ها را نیز پردازش کنند. وقتی ترتیب عبور، خروج زودهنگام، فیلتر کردن قبل از فراخوانی یا کنترل دقیق والد‑فرزند مهم است، از حلقه‌های جمع‌آوری مستقیم استفاده کنید.

## **جمع‌آوری اشکال**

از [Collect.Shapes](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/collect/shapes/) استفاده کنید وقتی که به‌جای فراخوانی برای هر شکل، به یک مجموعه از تمام اشکال در یک ارائه نیاز دارید. این موارد زمانی مفید است که همان مجموعه باید چند بار فیلتر، شمارش یا پردازش شود.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

اگر می‌توانید هر شکل را بلافاصله پردازش کنید و نیازی به نگهداری نتیجه جمع‌آوری‌شده ندارید، به‌جای آن از [ForEach.Shape](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/shape/) استفاده کنید.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/) می‌تواند عناصر ساختاری استفاده‌نشده را حذف کرده و داده‌های قلم‌های جاسازی‌شده را کاهش دهد:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) اسلایدهای طرح‌بندی را که هیچ اسلاید معمولی به آن‌ها ارجاع نمی‌دهد حذف می‌کند.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) استادهای استفاده‌نشده را حذف می‌کند.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/compressembeddedfonts/) کاراکترهای استفاده‌نشده را از قلم‌های جاسازی‌شده حذف می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

ابتدا طرح‌بندی‌های استفاده‌نشده را حذف کنید و سپس استادهای استفاده‌نشده؛ به‌طوری که یک استاد که پس از پاک‌سازی طرح‌بندی ارجاعی از دست داد، نیز حذف شود. ارائه بهینه‌شده را در فایلی جدید ذخیره کنید اگر ممکن است بعداً به استادها، طرح‌بندی‌ها یا داده‌های کامل قلم‌های جاسازی‌شده اصلی نیاز داشته باشید. برای جزئیات بیشتر به صفحات [Slide Master](/net/slide-master/) و [Embedded Font](/net/embedded-font/) مراجعه کنید.

## **سوالات متداول**

**چه مواقعی باید به‌جای مدل شیء کامل از API کم‌کد استفاده کنم؟**

وقتی یک عملیات استاندارد بر کل فایل یا ارائه اعمال می‌شود و نیازی به کنترل دقیق بر عناصر فردی نیست، از کمک‌کننده‌های کم‌کد استفاده کنید. وقتی نیاز به انتخاب اسلایدهای خاص، کنترل روابط استاد‑طرح‌بندی، بازرسی وضعیت میانی یا پیکربندی رفتاری که کمک‌کننده در برنمی‌گیرد داشته باشید، از مدل شیء کامل استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را در قالب‌های فایل متفاوت ترکیب کند؟**

خیر. [Merger.Process](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/merger/process/) برای ورودی‌هایی که در یک قالب باشند طراحی شده است. ابتدا فایل‌های ورودی را به یک قالب مشترک تبدیل کنید، برای مثال با استفاده از [Convert.AutoByExtension](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/convert/autobyextension/)، سپس فایل‌های تبدیل‌شده را ترکیب کنید.

**آیا ForEach استاد، طرح‌بندی و اسلایدهای یادداشت را پردازش می‌کند؟**

[ForEach.Slide](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/slide/) بر اسلایدهای معمولی ارائه تکرار می‌کند. عملیات سطح‑کل [ForEach.Shape](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/shape/)، [ForEach.Paragraph](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/paragraph/)، و [ForEach.Portion](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/portion/) به‌صورت پیش‌فرض شامل اسلایدهای معمولی، استاد و طرح‌بندی می‌شوند. برای شامل‌کردن اسلایدهای یادداشت، بارگذاری‌هایشان را با `includeNotes` برابر `true` صدا بزنید.

**تفاوت Between ForEach.Shape و Collect.Shapes چیست؟**

از [ForEach.Shape](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/shape/) برای پردازش فوری هر شکل از طریق یک فراخوانی استفاده کنید. زمانی که نیاز به نتایج قابل شمارش، فیلتر یا تکرار چندباره دارید، از [Collect.Shapes](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/collect/shapes/) استفاده کنید.

**آیا Compress همیشه باعث کوچکتر شدن فایل ارائه می‌شود؟**

ضروری نیست. نتیجه بستگی دارد به اینکه آیا ارائه شامل طرح‌بندی‌های استفاده‌نشده، استادهای استفاده‌نشده یا قلم‌های جاسازی‌شده با کاراکترهای استفاده‌نشده باشد یا نه. اگر هیچ‌یک از این موارد موجود نباشد، عملیات‌های مربوط به [Compress](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/) ممکن است اندازه فایل را کاهش ندهند.

**آیا تغییرات اعمال‌شده توسط ForEach یا Compress به‌صورت خودکار ذخیره می‌شوند؟**

خیر. این کمکی‌ها بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بارگذاری‌شده در حافظه عمل می‌کنند. پس از تغییر عناصر در فراخوانی یک [ForEach](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/) یا اجرای [Compress](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/)، برای نوشتن نتیجه باید متد [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) را فراخوانی کنید.

## **مقالات مرتبط**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)