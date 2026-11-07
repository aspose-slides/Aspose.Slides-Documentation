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
- حذف اسلایدهای مستر استفاده‌نشده
- حذف اسلایدهای لایه استفاده‌نشده
- فشرده‌سازی فونت‌های جاسازی‌شده
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "از API کم‌کد Aspose.Slides در .NET برای تبدیل و ادغام ارائه‌ها، تکرار محتوا، جمع‌آوری اشکال و کاهش اندازهٔ ارائه استفاده کنید."
---
## **مرور کلی**

فضای‌نامی [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) کلاس‌های کمکی ایستای برای عملیات رایج ارائه را فراهم می‌کند. این کمکی‌ها گردش‌کارهای معمول مدل شی را در روش‌های متمرکز می‌پیچند تا بتوانید فایل‌ها را تبدیل یا ترکیب کنید، عناصر ارائه را پردازش کنید، اشکال را جمع‌آوری کنید و محتوای استفاده‌نشده را با کد کمتر حذف کنید.

کمکی‌های کدنویسی‌کم در زمانی که عملیات بر تمام فایل یا ارائه اعمال می‌شود و گردش‌کار پیش‌فرض با نیازهای شما مطابقت دارد، بیشترین مفیدیت را دارند. زمانی که به کنترل دقیق بر اسلایدهای منفرد، مسترها، لایه‌ها، اشکال، تنظیمات خروجی یا روابط بین عناصر ارائه نیاز دارید، از مدل کامل شیء [Aspose.Slides](https://reference.aspose.com/slides/net/aspose.slides/) استفاده کنید.

جدول زیر خلاصه‌ای از کمکی‌های موجود را ارائه می‌دهد:

| کمکی‌کننده | موارد استفاده |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | تبدیل یک ارائه به قالب دیگر با فراخوانی مستقیم فایل به فایل. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | ترکیب فایل‌های ارائه کامل با همان قالب. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | اجرای یک اقدام برای هر اسلاید، شکل، پاراگراف یا بخش متنی. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | بازیابی اشکال از کل ارائه برای پردازش یا تحلیل مکرر. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | حذف مستر/لایه‌های استفاده‌نشده، کاهش داده‌های فونت جاسازی‌شده و فشرده‌سازی تصاویر. |

## **تبدیل یک ارائه**

از [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) زمانی استفاده کنید که پسوند فایل خروجی به تنهایی برای انتخاب قالب خروجی کافی باشد. این روش ارائه منبع را باز می‌کند، قالب مورد نیاز را از مسیر خروجی تعیین می‌کند و نتیجه را می‌نویسد.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

کلاس [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) همچنین روش‌های اختصاصی برای خروجی PDF، SVG، JPEG، PNG و TIFF فراهم می‌کند. زمانی که نیاز به بازرسی یا اصلاح ارائه قبل از خروجی یا پیکربندی گزینه‌ای دارید که توسط کمکی انتخاب‌شده در دسترس نیست، از مدل کامل شیء استفاده کنید. برای گردش‌کارها و گزینه‌های اختصاصی قالب، به [Convert Presentation](/slides/fa/net/convert-presentation/) مراجعه کنید.

## **ترکیب ارائه‌ها**

از [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) برای ترکیب فایل‌های ارائه کامل در یک فراخوانی استفاده کنید. ارائه‌های ورودی باید همان قالب فایل را داشته باشند.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

این کمکی زمانی مناسب است که همه اسلایدها بدون انتخاب یا نگاشت جداگانه به یک نتیجه اضافه شوند. زمانی که نیاز به ترکیب اسلایدهای منتخب، اعمال مستر یا لایه مقصد، حفظ صریح بخش‌ها یا سازگار کردن اندازه‌های اسلاید متفاوت دارید، از مدل کامل شیء استفاده کنید. برای این سناریوها به [Merge Presentations](/slides/fa/net/merge-presentation/) مراجعه کنید.

## **تکرار بر عناصر ارائه**

کلاس [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) برای هر نوع عنصر درخواست‌شده یک کال‌بک فراخوانی می‌کند. این کار از حلقه‌های تو در تو جلوگیری می‌کند و برای بازرسی یا تغییرات سراسری ارائه مناسب است.

مثال زیر از [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/)، [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/)، [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/)، و [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) برای بازرسی عناصر مربوطه استفاده می‌کند:

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

به‌صورت پیش‌فرض، عبور سراسری بر اشکال و متن شامل اسلایدهای عادی، مستر و لایه می‌شود. بارگذاری‌های دارای پارامتر `includeNotes` می‌توانند اسلایدهای یادداشت‌ها را نیز پردازش کنند. وقتی ترتیب عبور، خروج زودهنگام، فیلتر قبل از فراخوانی کال‌بک یا کنترل دقیق والد‑فرزند مهم است، از حلقه‌های مستقیم استفاده کنید.

## **جمع‌آوری اشکال**

از [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) زمانی استفاده کنید که به مجموعه‌ای از تمام اشکال در یک ارائه نیاز دارید نه یک کال‌بک برای هر شکل. این کار هنگامی مفید است که همان مجموعه چندین بار فیلتر، شمارش یا پردازش شود.

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

به‌جای آن وقتی هر شکل می‌تواند بلافاصله در کال‌بک پردازش شود و نیازی به نگهداری نتیجه جمع‌آوری‌شده ندارید، از [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) استفاده کنید.

## **فشرده‌سازی محتوای ارائه**

کلاس [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) می‌تواند عناصر ساختاری استفاده‌نشده را حذف و داده‌های فونت جاسازی‌شده را کاهش دهد:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) اسلایدهای لایه‌ای را که هیچ اسلاید عادی به آن‌ها ارجاع نمی‌دهد حذف می‌کند.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) مسترهای استفاده‌نشده را حذف می‌کند.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) کاراکترهای استفاده‌نشده را از فونت‌های جاسازی‌شده حذف می‌کند.

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

قبل از حذف مسترها، لایه‌های استفاده‌نشده را حذف کنید تا مستری که پس از پاک‌سازی لایه‌ها ارجاع‌نشدنی می‌شود نیز حذف شود. ارائه بهینه‌شده را در فایلی جدید ذخیره کنید اگر ممکن است به مسترها، لایه‌ها یا داده‌های کامل فونت‌های جاسازی‌شده اولیه later نیاز داشته باشید. برای جزئیات بیشتر به [Slide Master](/slides/fa/net/slide-master/) و [Embedded Font](/slides/fa/net/embedded-font/) مراجعه کنید.

### **فشرده‌سازی کل ارائه**

Aspose.Slides for .NET 26.11 متد [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) را اضافه می‌کند. این متد ترکیب حذف اسلایدهای لایه/مستر استفاده‌نشده، زیرمجموعه‌سازی فونت‌های جاسازی‌شده به کاراکترهای مورد استفاده و فشرده‌سازی تصاویر با 150 DPI را انجام می‌دهد. برای کنترل دقیق اینکه کدام تغییرات اعمال شوند، از عملیات‌های جداگانه بالا استفاده کنید.

نسخه 26.11 یا بعد‌تر [Aspose.Slides for .NET](/slides/fa/net/installation/) را نصب کنید و `input.pptx` را ارائه دهید. به فایلی جداگانه ذخیره کنید: لایه‌های حذف‌شده، کاراکترهای فونت و پیکسل‌های تصویر برش‌خورده ممکن است برای ویرایش‌های بعدی مورد نیاز باشند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **فشرده‌سازی تصاویر با وضوح انتخابی**

از [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) برای پردازش تصاویر واجد شرایط بدون حذف لایه‌ها یا زیرمجموعه‌سازی فونت‌ها استفاده کنید. این مثال با وضوح 96 DPI است؛ برای نیازهای خروجی مقدار دیگری از [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) انتخاب کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

هر دو کمکی از دامنه پردازش تصویر زیر استفاده می‌کنند:

| محتوا | رفتار |
| --- | --- |
| تصاویر رستر و پرکننده‌های تصویر شکل در اسلایدهای عادی، مستر و لایه، شامل اشکال گروهی | واجد شرایط فشرده‌سازی. |
| تصاویری که در حال حاضر برابر یا زیر وضوح درخواست‌شده هستند | بزرگ‌نمایی نمی‌شوند. نواحی برش‌خورده هنوز می‌توانند حذف شوند. |
| نواحی تصویر برش‌خورده | پیکسل‌های مخفی به‌صورت دائمی حذف و آفست‌های برش بازنشانی می‌شوند. |
| پس‌زمینه‌های اسلاید و پرکننده‌های سلول جدول | توسط این کمکی‌ها پردازش نمی‌شوند. |
| داخلی نمودار/SmartArt، GIF و فرمت‌های برداری مانند SVG، EMF و WMF | خارج از دامنه فشرده‌سازی تصویر مستند شده‌اند. |

در نسخه 26.11، [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) از زیرنمونه‌سازی بر پایه وضوح برای تصویر غیربرش‌خورده جلوگیری می‌کند، اما **پیکسل‌های برش‌خورده را حفظ نمی‌کند**. تصویر برش‌خورده همچنان می‌تواند با حذف نواحی مخفی بازنویسی شود. هیچ‌یک از کمکی‌ها گزینه حفظ برش را ارائه نمی‌دهند. برای کنترل فردی، به مثال [فشرده‌سازی به‌صورت تک‑تصویر](/slides/fa/net/examples/optimization-batch/compression/) مراجعه کنید.

ظاهر خروجی و اندازه فایل را قبل از جایگزینی اصلی مقایسه کنید. صرفه‌جویی‌ها به تصاویر منبع، اندازه نمایش آن‌ها و محتوای استفاده‌نشده بستگی دارد؛ فشرده‌سازی تضمین‌کنندهٔ کوچک‌تر شدن فایل نیست. برای پیامدهای زیرمجموعه‌سازی فونت به [Embedded Fonts](/slides/fa/net/embedded-font/) نگاه کنید.

## **سؤالات متداول**

**کی باید به جای مدل کامل شیء از API کدنویسی‌کم استفاده کنم؟**

وقتی یک عملیات استاندارد بر روی یک فایل یا ارائه کامل اعمال می‌شود و نیازی به کنترل دقیق بر عناصر منفرد نیست، از کمکی‌های کدنویسی‌کم استفاده کنید. وقتی نیاز به انتخاب اسلایدهای خاص، کنترل روابط مستر و لایه، بازرسی وضعیت میانی یا پیکربندی رفتاری دارید که کمکی آن را افشا نمی‌کند، از مدل کامل شیء استفاده کنید.

**آیا Merger می‌تواند ارائه‌ها را در قالب‌های فایل متفاوت ترکیب کند؟**

خیر. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) نیاز به ارائه‌های ورودی با همان قالب دارد. ابتدا فایل‌های ورودی را به قالب مشترک تبدیل کنید، برای مثال با [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/)، سپس فایل‌های تبدیل‌شده را ترکیب کنید.

**آیا ForEach مستر، لایه و اسلایدهای یادداشت را پردازش می‌کند؟**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) فقط اسلایدهای عادی ارائه را می‌گرداند. عملیات سراسری [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/)، [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) و [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) به‌طور پیش‌فرض اسلایدهای عادی، مستر و لایه را شامل می‌شوند. برای شامل کردن اسلایدهای یادداشت، از بارگذاری‌هایشان با مقدار `includeNotes` برابر `true` استفاده کنید.

**تفاوت بین ForEach.Shape و Collect.Shapes چیست؟**

از [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) برای پردازش هر شکل بلافاصله از طریق کال‌بک استفاده کنید. وقتی به نتیجه‌ای قابل شمارش، فیلتر یا پیمایش چندباره نیاز دارید، از [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) استفاده کنید.

**آیا Compress همیشه اندازه فایل ارائه را کوچکتر می‌کند؟**

صرفاً نیست. صرفه‌جویی به لایه‌ها/مسترهای استفاده‌نشده، فونت‌های جاسازی‌شده با کاراکترهای بی‌استفاده و تصاویری که از فشرده‌سازی بهره می‌برند وابسته است. کمکی‌های [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) ممکن است اندازه را ثابت بگذارند یا حتی برای برخی ورودی‌ها بزرگ‌تر شوند. هر دو اندازه و کیفیت رندر شده را مقایسه کنید و نسخه اصلی را نگه دارید.

**آیا تغییرات انجام‌شده توسط ForEach یا Compress به‌صورت خودکار ذخیره می‌شود؟**

خیر. این کمکی‌ها بر روی شیء [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بارگذاری‌شده در حافظه کار می‌کنند. پس از تغییر عناصر در کال‌بک [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) یا اجرای [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)، برای نوشتن نتیجه [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) را فراخوانی کنید.

## **مقالات مرتبط**

- [Convert Presentation](/slides/fa/net/convert-presentation/)
- [Merge Presentations](/slides/fa/net/merge-presentation/)
- [Slide Master](/slides/fa/net/slide-master/)
- [Manage Text Box](/slides/fa/net/manage-textbox/)
- [Embedded Font](/slides/fa/net/embedded-font/)