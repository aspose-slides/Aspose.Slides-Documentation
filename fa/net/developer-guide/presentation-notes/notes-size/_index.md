---
title: تغییر اندازه و جهت صفحه یادداشت‌ها در .NET
linktitle: اندازه صفحه یادداشت
type: docs
weight: 10
url: /fa/net/notes-size/
keywords:
- اندازه صفحه یادداشت
- جهت یادداشت‌ها
- یادداشت‌های افقی
- یادداشت‌های عمودی
- اندازه برگه‌پخش
- PowerPoint
- ارائه
- PPT
- PPTX
- C#
- Aspose.Slides
description: "خواندن و تغییر ابعاد صفحه یادداشت‌ها در Aspose.Slides برای .NET، تغییر جهت، تأیید اندازه‌های ذخیره‌شده و خروجی گرفتن از یادداشت‌ها یا برگه‌پخش‌ها به PDF و تصویر."
---
## **نمای کلی**

از [Presentation.NotesSize](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/notessize/) برای دسترسی به تنظیمات صفحه یادداشت‌های ارائه استفاده کنید. این متد یک شیء [INotesSize](https://reference.aspose.com/slides/fa/net/aspose.slides/inotessize/) برمی‌گرداند که ویژگی [Size](https://reference.aspose.com/slides/fa/net/aspose.slides/inotessize/size/) آن قابل نوشتن است. اگرچه خود شیء تنظیمات فقط‑خواندنی است، می‌توانید ابعاد جدیدی را به ویژگی اندازه‌اش اختصاص دهید.

عرض و ارتفاع بر حسب **نقطه** (points) مشخص می‌شوند، با ۷۲ نقطه در هر اینچ. به عنوان مثال، ۹۰۰ × ۶۰۰ نقطه برابر با ۱۲٫۵ × ۸⅓ اینچ است. این تنظیمات بر تمام ارائه اعمال می‌شود، نه بر یادداشت‌های اسلایدهای منفرد.

| تنظیمات | هدف |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/notessize/) | ابعاد صفحه یادداشت‌ها و ابعادی که برای خروجی برگه‌پخش استفاده می‌شوند را کنترل می‌کند. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/slidesize/) | ابعاد اسلایدهای معمولی ارائه را از طریق [ISlideSize](https://reference.aspose.com/slides/fa/net/aspose.slides/islidesize/) کنترل می‌کند. |

تغییر هر یک از این تنظیمات به‌صورت خودکار تنظیم دیگر را تغییر نمی‌دهد. تغییر جهت صفحه یادداشت‌ها اسلایدهای معمولی را نیز نمی‌چرخاند. برای تغییر اندازه اسلایدهای معمولی، به [Slide Size](/slides/fa/net/slide-size/) مراجعه کنید.

مثال‌های زیر از یک فایل `sample.pptx` موجود استفاده می‌کنند. برای مثال‌های خروجی، از یک ارائه با حداقل یک اسلاید حاوی یادداشت‌های سخنران استفاده کنید. هر مثال می‌تواند به‌صورت مستقل اجرا شود.

## **خواندن اندازه و جهت صفحه یادداشت‌ها**

عرض و ارتفاع را بخوانید و برای تعیین جهت مقایسه کنید: صفحه‌ای که پهن‌تر است، افقی (landscape) است، صفحه‌ای که بلندتر است، عمودی (portrait) است و ابعاد برابر، صفحه‌ای مربعی را توصیف می‌کند. این مثال ابعاد واقعی را به‌صورت نقطه چاپ می‌کند، بدون فرض کردن اندازه کاغذ استاندارد.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **تغییر به حالت افقی بدون تغییر اندازه کاغذ**

برای تغییر فقط جهت، عرض و ارتفاع موجود را جابجا کنید. این کار طول هر دو طرف، از جمله اندازه‌های سفارشی کاغذ را حفظ می‌کند. شرط زیر از تغییر صفحه‌ای که هم‌اکنون افقی است به حالت عمودی جلوگیری می‌کند و صفحهٔ مربعی را دست نخورده می‌گذارد.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

برای جهت عمودی، همان انتساب را زمانی که `size.Width > size.Height` باشد استفاده کنید. مگر این‌که بخواهید اندازه کاغذ را نیز تغییر دهید، از ابعاد A4 یا Letter استفاده نکنید.

## **تنظیم و تأیید اندازه سفارشی صفحه یادداشت‌ها**

هر دو بعد را به‌صورت همزمان اختصاص دهید، سپس با استفاده از [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) ارائه را ذخیره کنید. این مثال یک صفحهٔ افقی ۹۰۰ × ۶۰۰‑نقطه‌ای تنظیم می‌کند، به‌صورت PPTX ذخیره می‌شود و سپس فایل ذخیره شده دوباره باز می‌شود تا مقادیر حفظ‑شده بررسی شوند. مقایسه با تحمل ۰٫۰۱‑نقطه برای مقادیر شناور انجام می‌شود؛ این به‌معنای تضمین دقت برای هر فرمت فایلی نیست.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

نتیجهٔ مورد انتظار `900 x 600 points` و `Size preserved: True` است. بررسی یک ارائهٔ تازه بازشده، فایل ذخیره‌شده را تأیید می‌کند نه فقط تنظیمات حافظه‌ای.

## **خروجی یادداشت‌ها و برگه‌پخش‌ها**

ابعاد صفحه، ناحیهٔ قابل استفاده برای چیدمان یادداشت‌ها یا برگه‌پخش‌ها را تعیین می‌کنند. این تنظیمات به تنهایی آن چیدمان‌ها را فعال نمی‌سازند: گزینه‌های خروجی را نیز پیکربندی کنید. خروجی اسلایدهای معمولی همچنان از ابعاد اسلاید استفاده می‌کند.

### **خروجی یادداشت‌ها به PDF و PNG**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notescommentslayoutingoptions/) را به [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) اختصاص دهید تا یادداشت‌ها در PDF گنجانده شوند. این مثال همچنین اولین اسلاید همراه با یادداشت‌ها را با استفاده از [Slide.GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/getimage/) و [RenderingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/renderingoptions/) به PNG تبدیل می‌کند.

حالت [BottomTruncated](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notespositions/) یادداشت‌ها را در یک صفحه نگه می‌دارد؛ یادداشت‌هایی که جا نمی‌شوند می‌توانند بریده شوند. PDF از صفحات ۹۰۰ × ۶۰۰‑نقطه‌ای استفاده می‌کند. در مقیاس تصویر ۱ × ۱ که در زیر استفاده شده، PNG نیز ۹۰۰ × ۶۰۰‑پیکسل است. نقاط، هندسهٔ صفحه را توصیف می‌کنند؛ پیکسل‌ها خروجی شطرنجی را بیان می‌کنند که ابعاد آن نیز به مقیاس رندر بستگی دارد.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

برای خروجی PDF با یادداشت‌های طولانی، حالت [BottomFull](https://reference.aspose.com/slides/fa/net/aspose.slides.export/notespositions/) صفحات اضافی را در صورت نیاز فراهم می‌کند. از آن حالت برای فراخوانی تصویر تک‑اسلاید بالا استفاده نکنید، زیرا پشتیبانی نمی‌شود. پس از تغییر اندازه، خروجی را برای قطع شدن یادداشت‌ها و مکان‌گذاری اشیای موجود در master‑ی یادداشت‌ها بررسی کنید؛ صرف تغییر ابعاد صفحه به‌تنهایی ضمانت نمی‌کند که تمام محتوا جا بگیرد. برای اطلاعات بیشتر دربارهٔ خروجی یادداشت‌ها به [Convert PowerPoint to PDF with Notes](/slides/fa/net/convert-powerpoint-to-pdf-with-notes/) مراجعه کنید.

### **خروجی برگه‌پخش‌ها به PDF**

از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/handoutlayoutingoptions/) برای قرار دادن چند تصویر کوچک اسلاید در یک صفحه استفاده کنید. مثال زیر یک صفحهٔ ۹۰۰ × ۶۰۰‑نقطه‌ای تنظیم می‌کند و با استفاده از [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/fa/net/aspose.slides.export/handouttype/) تا چهار اسلاید را در هر صفحه مرتب می‌کند. پیش‌تنظیم افقی ترتیب اسلایدها را کنترل می‌کند؛ جهت صفحه از عرض و ارتفاع آن گرفته می‌شود.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

تغییر اندازه صفحه، ناحیهٔ موجود برای شبکهٔ برگه‌پخش را بدون تغییر ابعاد اسلایدهای منبع تغییر می‌دهد. برای ایجاد تصاویر برگه‌پخش، از [Presentation.GetImages](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/getimages/) همراه با چیدمان برگه‌پخش استفاده کنید، نه از روش تصویر یک اسلاید منفرد. در Aspose.Slides، رندرینگ برگه‌پخش در سطح ارائه از ابعاد صفحه یادداشت‌ها استفاده می‌کند، در حالی که فراخوانی تصویر اسلاید منفرد صفحهٔ برگه‌پخش را تولید نمی‌کند. برای گزینه‌های چیدمان به [Handout Mode](/slides/fa/net/convert-powerpoint-in-handout-mode/) مراجعه کنید.

## **اندازه صفحه در نمایشگرها، خروجی و چاپ**

اندازهٔ ذخیره‌شدهٔ ارائه، اندازهٔ صفحهٔ خروجی و اندازهٔ کاغذ چاپی را متمایز کنید:

- **نمایشگرهای ارائه:** یک نمایشگر می‌تواند یادداشت‌ها را با قوانین چیدمان خود نمایش دهد یا چاپ کند. اگر برنامهٔ دیگری فایل را ذخیره کند، آن را دوباره باز کنید و ابعاد را بررسی کنید؛ تبدیل فرمت آن برنامه ممکن است آن‌ها را نرمال کند.
- **فرمت‌های خروجی:** مثال‌های PDF یادداشت‌ها و برگه‌پخش‌ها در بالا از ابعاد صفحهٔ پیکربندی‌شده استفاده می‌کنند. تصاویر شطرنجی از ابعاد پیکسل صحیح به‌همراه مقیاس رندر استفاده می‌کنند، بنابراین مقادیر نقطه‌ای کسری می‌توانند در خروجی تصویر گرد شوند. خروجی اسلایدهای معمولی از اندازهٔ صفحهٔ یادداشت‌ها استفاده نمی‌کند.
- **درایورهای چاپگر:** انتخاب کاغذ، چرخش خودکار و تنظیمات مطابقت با صفحه می‌توانند خروجی فیزیکی را بدون تغییر ابعاد ذخیره‌شده در ارائه یا PDF تغییر دهند. برای یک اندازهٔ کاغذ خاص، تنظیمات چاپگر را مطابقت دهید و پیش‑نمایش چاپ را بررسی کنید.

## **سؤالات متداول**

**آیا می‌توانم اندازه‌ی یادداشت‌ها را فقط برای یک اسلاید تنظیم کنم؟**

اندازهٔ صفحه یادداشت‌ها یک تنظیم سطح ارائه است. اسلایدهای منفرد می‌توانند محتوای یادداشت متفاوتی داشته باشند، اما این ویژگی اندازهٔ صفحهٔ جداگانه‌ای برای هر اسلاید فراهم نمی‌کند.

**چرا تغییر جهت یادداشت‌ها اسلایدهای من را تغییر نداد؟**

صفحات یادداشت‌ها و اسلایدهای معمولی ابعاد مستقلی دارند. وقتی می‌خواهید اندازهٔ خود اسلایدها را تغییر دهید، از تنظیمات اندازهٔ اسلاید معمولی استفاده کنید.

**چرا نتیجهٔ ذخیره‌شده یا چاپ‌شده من اندازهٔ متفاوتی دارد؟**

اولاً ارائهٔ ذخیره‌شده را دوباره باز کنید و ابعاد یادداشت‌های آن را مقایسه کنید. اگر تغییر کرده‌اند، بررسی کنید آیا ذخیره یا تبدیل فایل در برنامه‌ای دیگر تنظیمات صفحه را تغییر داده است یا نه. اگر نه، چیدمان خروجی، مقیاس تصویر، تنظیمات نمایشگر و انتخاب کاغذ چاپگر را بررسی کنید.