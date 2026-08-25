---
title: عملیات ارائه کد‑کم در .NET
linktitle: API کد‑کم
type: docs
weight: 50
url: /fa/net/low-code-presentation-operations/
keywords:
  - API ارائه کد‑کم
  - تبدیل ارائه
  - ترکیب ارائه‌ها
  - تکرار اسلایدها
  - تکرار اشکال
  - تکرار متن
  - جمع‌آوری اشکال
  - فشرده‌سازی ارائه
  - حذف مسترهای استفاده‌نشده
  - حذف چینش‌های استفاده‌نشده
  - فشرده‌سازی فونت‌های جاسازی‌شده
  - PowerPoint
  - OpenDocument
  - ارائه
  - .NET
  - C#
  - Aspose.Slides
description: از API کد‑کم Aspose.Slides در .NET برای تبدیل و ترکیب ارائه‌ها، تکرار محتوا، جمع‌آوری اشکال و کاهش حجم ارائه استفاده کنید.
---
## **نمای کلی**

فضای نام [Aspose.Slides.LowCode](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/) کلاس‌های کمکی استاتیک برای عملیات‌های معمول ارائه فراهم می‌کند. این کمکی‌ها گردش کارهای متداول مدل شیء را در متدهای متمرکز می‌پیچند، به طوری که می‌توانید فایل‌ها را تبدیل یا ترکیب کنید، عناصر ارائه را پردازش کنید، اشکال را جمع‌آوری کنید و محتوای استفاده‌نشده را با کد کمتر حذف کنید.

کمک‌کننده‌های کدکم زمانی مفید هستند که عملیات روی یک فایل یا ارائه کامل اعمال شود و گردش کار پیش‌فرض با نیازهای شما منطبق باشد. هنگام نیاز به کنترل دقیق روی اسلایدهای تک تک، مسترها، چینش‌ها، اشکال، تنظیمات خروجی یا روابط بین عناصر ارائه، از مدل شیء کامل [Aspose.Slides](https://reference.aspose.com/slides/fa/net/aspose.slides/) استفاده کنید.

جدول زیر خلاصه‌ای از کمک‌کننده‌های موجود را نشان می‌دهد:

| کمک‌کننده | موارد استفاده |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/convert/) | تبدیل یک ارائه به قالب دیگر با فراخوانی مستقیم فایل‑به‑فایل. |
| [Merger](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/merger/) | ترکیب فایل‌های ارائه کامل از همان قالب. |
| [ForEach](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/) | اجرا کردن یک عمل برای هر اسلاید، شکل، پاراگراف یا بخش متنی. |
| [Collect](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/collect/) | بازیابی اشکال از کل ارائه برای پردازش یا تجزیه و تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/) | حذف مسترها و چینش‌های استفاده‌نشده و کاهش داده‌های فونت‌های جاسازی‌شده. |

## **تبدیل ارائه**

زمانی که پسوند فایل خروجی برای انتخاب قالب خروجی کافی باشد، از [Convert.AutoByExtension](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/convert/autobyextension/) استفاده کنید. این متد ارائه منبع را باز می‌کند، قالب مورد نیاز را از مسیر خروجی تعیین می‌کند و نتیجه را می‌نویسد.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

کلاس [Convert](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/convert/) همچنین متدهای اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF ارائه می‌دهد. وقتی نیاز به بازرسی یا اصلاح ارائه قبل از خروجی یا پیکربندی گزینه‌ای دارید که توسط کمک‌کننده منتخب در دسترس نیست، از مدل شیء کامل استفاده کنید. برای گردش کارها و گزینه‌های خاص قالب، به صفحه [Convert Presentation](/slides/fa/net/convert-presentation/) مراجعه کنید.

## **ترکیب ارائه‌ها**

برای ترکیب فایل‌های ارائه کامل با یک فراخوانی، از [Merger.Process](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/merger/process/) استفاده کنید. ارائه‌های ورودی باید همان قالب فایل را داشته باشند.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

این کمک‌کننده زمانی مناسب است که همه اسلایدها باید به‌صورت پیوسته به یک نتیجه اضافه شوند بدون اینکه نیاز به انتخاب یا نگاشت آنها به‌صورت فردی باشد. وقتی نیاز به ترکیب اسلایدهای انتخابی، اعمال مستر یا چینش مقصد، حفظ بخش‌ها به‌صورت صریح یا سازگاری اندازه اسلایدهای مختلف دارید، از مدل شیء کامل استفاده کنید. برای این سناریوها به صفحه [Merge Presentations](/slides/fa/net/merge-presentation/) مراجعه کنید.

## **تکرار بر عناصر ارائه**

کلاس [ForEach](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/) برای هر نوع عنصر درخواست‌شده یک فراخوانی‑پس‌زمینه (callback) اجرا می‌کند. این کار از حلقه‌های تو در توی مجموعه‌ها جلوگیری می‌کند و برای بازرسی یا تغییر فرمت در سطح کل ارائه مناسب است.

مثال زیر از [ForEach.Slide](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/slide/)، [ForEach.Shape](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/shape/)، [ForEach.Paragraph](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/paragraph/) و [ForEach.Portion](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/portion/) برای بازرسی عناصر مربوطه استفاده می‌کند:

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

به‌طور پیش‌فرض، عبور از اشکال و متن در سطح کل ارائه شامل اسلایدهای عادی، مستر و چینش می‌شود. نسخه‌های overload با پارامتر `includeNotes` می‌توانند اسلایدهای یادداشت‌ها را نیز پردازش کنند. وقتی ترتیب عبور، خروج زودهنگام، فیلتر کردن قبل از فراخوانی یا کنترل دقیق والد‑فرزند مهم است، از حلقه‌های مستقیم مجموعه استفاده کنید.

## **جمع‌آوری اشکال**

وقتی به یک مجموعه از تمام اشکال یک ارائه نیاز دارید نه یک فراخوانی برای هر شکل، از [Collect.Shapes](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/collect/shapes/) استفاده کنید. این کار وقتی مفید است که همان مجموعه برای فیلتر کردن، شمارش یا پردازش مکرر استفاده شود.

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

اگر هر شکل می‌تواند بلافاصله در فراخوانی پردازش شود و نیازی به حفظ نتیجه جمع‌آوری‌شده ندارید، به‌جای آن از [ForEach.Shape](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/shape/) استفاده کنید.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/) می‌تواند عناصر ساختاری استفاده‌نشده را حذف کند و داده‌های فونت جاسازی‌شده را کاهش دهد:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) اسلایدهای چینش که توسط هیچ اسلاید عادی ارجاع داده نشده‌اند، حذف می‌کند.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) مسترهایی که دیگر استفاده نمی‌شوند، حذف می‌کند.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/compressembeddedfonts/) کاراکترهای استفاده‌نشده را از فونت‌های جاسازی‌شده حذف می‌کند.

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

ابتدا چینش‌های استفاده‌نشده را حذف کنید، سپس مسترهای استفاده‌نشده؛ به‌طوری که مستری که پس از پاکسازی چینش‌ها دیگر ارجاع داده نمی‌شود، نیز حذف شود. اگر ممکن است بعداً به مسترها، چینش‌ها یا داده‌های کامل فونت‌های جاسازی‌شده اصلی نیاز داشته باشید، ارائه بهینه‌شده را در فایل جدید ذخیره کنید. برای جزئیات بیشتر، به صفحات [Slide Master](/slides/fa/net/slide-master/) و [Embedded Font](/slides/fa/net/embedded-font/) مراجعه کنید.

## **سوالات متداول**

**چه زمانی باید به‌جای مدل شیء کامل از API کد‑کم استفاده کنم؟**

وقتی یک عملیات استاندارد بر روی یک فایل یا ارائه کامل اعمال می‌شود و نیازی به کنترل دقیق بر عناصر تک‌تک نیست، از کمک‌کننده‌های کد‑کم استفاده کنید. وقتی بخواهید اسلایدهای خاصی را انتخاب کنید، روابط مستر و چینش را کنترل کنید، وضعیت میانی را بازرسی کنید یا رفتارهایی را تنظیم کنید که کمک‌کننده در معرضشان قرار نمی‌دهد، از مدل شیء کامل استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را در قالب‌های فایل متفاوت ترکیب کند؟**

خیر. [Merger.Process](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/merger/process/) نیاز دارد که ارائه‌های ورودی دارای یک قالب باشند. ابتدا فایل‌های ورودی را به قالب مشترک تبدیل کنید، برای مثال با [Convert.AutoByExtension](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/convert/autobyextension/)، سپس فایل‌های تبدیل‌شده را ترکیب کنید.

**آیا ForEach مستر، چینش و اسلایدهای یادداشت‌ها را پردازش می‌کند؟**

[ForEach.Slide](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/slide/) فقط اسلایدهای عادی ارائه را تکرار می‌کند. عملیات‌های سطح‑کل [ForEach.Shape](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/shape/)، [ForEach.Paragraph](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/paragraph/) و [ForEach.Portion](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/portion/) به‌طور پیش‌فرض اسلایدهای عادی، مستر و چینش را شامل می‌شوند. برای شامل کردن اسلایدهای یادداشت‌ها، overloadهای آنها را با `includeNotes` برابر `true` فراخوانی کنید.

**اختلاف بین ForEach.Shape و Collect.Shapes چیست؟**

از [ForEach.Shape](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/shape/) برای پردازش هر شکل بلافاصله از طریق یک فراخوانی‑پس‌زمینه استفاده کنید. وقتی به یک نتیجه قابل شمارش، فیلتر یا عبور چندبار نیاز دارید، از [Collect.Shapes](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/collect/shapes/) استفاده کنید.

**آیا Compress همیشه حجم فایل ارائه را کوچکتر می‌کند؟**

لزوماً نه. نتیجه به این بستگی دارد که آیا ارائه شامل چینش‌های استفاده‌نشده، مسترهای استفاده‌نشده یا فونت‌های جاسازی‌شده با کاراکترهای استفاده‌نشده باشد یا نه. اگر هیچ‌یک از این موارد موجود نباشد، عملیات‌های [Compress](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/) ممکن است حجم فایل را کاهش ندهند.

**آیا تغییرات ایجادشده توسط ForEach یا Compress به‌صورت خودکار ذخیره می‌شوند؟**

نه. این کمک‌کننده‌ها بر روی شیء [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بارگذاری‌شده در حافظه کار می‌کنند. پس از تغییر عناصر در فراخوانی [ForEach](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/foreach/) یا اجرای [Compress](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/)، برای نوشتن نتیجه باید متد [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) را فراخوانی کنید.

## **مقالات مرتبط**

- [Convert Presentation](/slides/fa/net/convert-presentation/)
- [Merge Presentations](/slides/fa/net/merge-presentation/)
- [Slide Master](/slides/fa/net/slide-master/)
- [Manage Text Box](/slides/fa/net/manage-textbox/)
- [Embedded Font](/slides/fa/net/embedded-font/)