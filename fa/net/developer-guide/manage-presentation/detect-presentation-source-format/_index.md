---
title: تعیین قالب اصلی ارائه در .NET
linktitle: قالب منبع
type: docs
weight: 35
url: /fa/net/detect-presentation-source-format/
keywords:
- قالب منبع
- تشخیص قالب ارائه
- PowerPoint
- OpenDocument
- ارائه
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "قالب اصلی یک ارائهٔ بارگذاری‌شده را در C# با Aspose.Slides برای .NET بخوانید، APIهای تشخیص را مقایسه کنید و با فایل‌ها، جریان‌ها و قالب‌های قدیمی کار کنید."
---
## **نمای کلی**

پس از بارگذاری یک ارائه، ویژگی فقط‑خواندنی [Presentation.SourceFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sourceformat/) را بخوانید تا قالب اصلی آن را تعیین کنید. این ویژگی همچنین از طریق [IPresentation.SourceFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/sourceformat/) در دسترس است. از آن استفاده کنید زمانی که پردازش بعدی به قالبی که نمونهٔ جاری از آن بارگذاری شده بستگی دارد.

قالب منبع متفاوت از [SaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) است که برای فایل خروجی انتخاب می‌شود. ذخیره به قالب دیگری، قالب منبع نمونهٔ موجود را تغییر نمی‌دهد.

## **خواندن قالب منبع یک فایل**

این مثال به فایلی با نام `sample.pptx` موجود نیاز دارد. فایل را بارگذاری می‌کند و به جای نام فایل، از سیاست پردازشی برنامه با استفاده از [Presentation.SourceFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sourceformat/) استفاده می‌کند. مسیر ورودی را برای آزمایش قالب‌های دیگر تغییر دهید. مثال سیاست انتخاب‌شده را چاپ می‌کند؛ پیام‌ها را با منطق برنامهٔ خود جایگزین کنید.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **مقادیر پشتیبانی‌شده را شناسایی کنید**

شمارش [SourceFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/sourceformat/) قالب‌های ارائه زیر را متمایز می‌کند. پسوندهای زیر، پسوندهای متداول هستند و بازسازی نام فایل اصلی را نشان نمی‌دهند.

| مقدار SourceFormat | پسوند | قالب |
| --- | --- | --- |
| `Ppt` | `.ppt` | ارائهٔ PowerPoint 97–2003 |
| `Pptx` | `.pptx` | ارائهٔ Office Open XML |
| `Pptm` | `.pptm` | ارائهٔ Office Open XML با ماکرو |
| `Pps` | `.pps` | نمایش اسلاید PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | نمایش اسلاید Office Open XML |
| `Ppsm` | `.ppsm` | نمایش اسلاید Office Open XML با ماکرو |
| `Pot` | `.pot` | قالب PowerPoint 97–2003 |
| `Potx` | `.potx` | قالب Office Open XML |
| `Potm` | `.potm` | قالب Office Open XML با ماکرو |
| `Odp` | `.odp` | ارائهٔ OpenDocument |
| `Otp` | `.otp` | قالب ارائهٔ OpenDocument |
| `Fodp` | `.fodp` | ارائهٔ OpenDocument XML مسطح |
| `Xml` | `.xml` | ارائهٔ PowerPoint XML |

## **خواندن قالب منبع یک جریان**

این مثال به فایلی با نام `sample.pps` موجود نیاز دارد. خواندن بایت‌های آن به یک جریان حافظه، ورودی‌ای را شبیه‌سازی می‌کند که بدون نام فایل دریافت می‌شود، مانند مقدار ذخیره شده در پایگاه داده یا آرایهٔ بایتی بارگذاری‌شده. سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) تنها جریان را دریافت می‌کند.

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT، PPS و POT از یک قالب باینری زیرساختی استفاده می‌کنند. هنگام بارگذاری با مسیر فایل، پسوند می‌تواند به تمییز نمایش اسلاید یا قالب کمک کند. بدون نام فایل، محتوای PPS و POT قدیمی ممکن است به عنوان `SourceFormat.Ppt` گزارش شود؛ مثال PPS بالا `Ppt` را گزارش می‌کند.

اگر برنامهٔ شما باید این تمییز را حفظ کند، نام فایل اصلی یا فرادادهٔ زیرنوع را به‌طور جداگانه نگه دارید. پسوند یک نکتهٔ مفید برای این زیرنوع‌های قدیمی است، اما نباید تنها معیار شناسایی محتوای ارائهٔ دلخواه باشد.

## **مقایسهٔ تشخیص قبل و بعد از بارگذاری**

هنگامی که نیاز به بررسی فایل قبل از بارگذاری مدل شیء کامل ارائه دارید، از [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/getpresentationinfo/) و [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentationinfo/loadformat/) استفاده کنید. وقتی نمونه از قبل وجود دارد، از [Presentation.SourceFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sourceformat/) استفاده کنید.

این مثال به `sample.pptx` نیاز دارد و برای هر دو بررسی `Pptx` را چاپ می‌کند. در محیط تولید، API مناسب برای مرحلهٔ پردازش خود را انتخاب کنید؛ یک ارائهٔ بارگذاری‌شده نیازی به بازرسی دوم صرفاً برای دریافت قالب منبع ندارد.

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

نتایج دارای انواع شمارشی متفاوتی هستند: [LoadFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/loadformat/) و [SourceFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/sourceformat/). آن‌ها را با تبدیل مقدار عددی مقایسه نکنید و فرض نکنید هر قالب نتایج تشخیص یکسانی دارد. در بررسی «ذخیره‑کردن و باز‑گشایی» که در پایین توضیح داده شده است، PowerPoint XML قبل از بارگذاری به عنوان `LoadFormat.Unknown` گزارش شد و پس از بارگذاری به عنوان `SourceFormat.Xml`.

## **حفظ جداسازی قالب‌های منبع و خروجی**

این مثال به `sample.pptx` نیاز دارد و `converted.odp` را می‌نویسد. قبل و بعد از ذخیرهٔ نمونهٔ اصلی `Pptx` را چاپ می‌کند. تنها نمونهٔ جدید بارگذاری‌شده از خروجی ODP، `Odp` را گزارش می‌دهد.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat}");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

یک ارائهٔ ساخته‌شده از صفر با `new Presentation()` گزارش می‌دهد `SourceFormat.Pptx`. این نمونه ورودی ندارد: این مقدار پیش‌فرض برای یک شیء تازه ایجاد‌شده است، نه نشانه‌ای مبنی بر اینکه یک فایل PPTX بارگذاری شده است. اگر تمایز بین ایجاد یا بارگذاری برای برنامهٔ شما مهم است، به‌طور جداگانه آن را ردیابی کنید.

## **نقشه‌برداری یک قالب منبع به پسوند**

مثال زیر به `sample.pptx` نیاز دارد. هر مقدار فعلاً پشتیبانی‌شدهٔ [SourceFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/sourceformat/) را به پسوند متداولی نگاشت می‌کند، بدون آن‌که نام فایل ورودی را تجزیه‌وتحلیل کند. روش پیش‌فرض از اختصاص ساکن پسوند به مقادیری که شناخته نشده‌اند جلوگیری می‌کند.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

این نگاشت فایلی را تبدیل یا زیرنوع PPS/POT که در طول بارگذاری از جریان از دست رفته است، بازنشانی نمی‌کند. برای ذخیرهٔ واقعی، یک [SaveFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) را به‌وضوح انتخاب کنید یا از تبدیل نشان‌داده‌شده در [Save Presentations in Their Original Format](/slides/fa/net/save-presentation/#save-presentations-in-their-original-format) استفاده کنید.

## **تأیید قالب‌ها با ذخیره و باز‑گشایی**

این مثال خودکفا یک ارائه ایجاد می‌کند و سه فایل را در پوشهٔ کاری می‌نویسد، فایل‌های هم‌نام را بازنویسی می‌کند. هر خروجی هم از مسیر و هم از یک جریان حافظه باز می‌شود. برای PPTX و ODP، هر دو مسیر قالب ذخیره‌شده را گزارش می‌کند. برای PPS، بارگذاری از مسیر `Pps` را گزارش می‌کند، در حالی که بارگذاری همان بایت‌ها بدون نام فایل `Ppt` را گزارش می‌کند.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

همین بررسی برای تمام قالب‌های فهرست‌شده در بالا نتایج زیر را برای ارائه‌های تولیدشده با پسوندهای منطبق تولید کرد:

| قالب ذخیره‌شده | SourceFormat از مسیر فایل | SourceFormat از جریان بدون نام |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | به ترتیب `Pptx`، `Pptm` | همانند مسیر فایل |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | به ترتیب `Ppsx`، `Ppsm` | همانند مسیر فایل |
| POT | `Pot` | `Ppt` |
| POTX, POTM | به ترتیب `Potx`، `Potm` | همانند مسیر فایل |
| ODP, OTP | به ترتیب `Odp`، `Otp` | همانند مسیر فایل |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

در این بررسی‌ها، فقط نرمال‌سازی قالب منبع، تبدیل PPS/POT به `Ppt` برای جریان‌های بدون نام بود. جدول شناسایی قالب را توصیف می‌کند؛ نه حفظ هر ویژگی ارائه در حین تبدیل.

## **سوالات متداول**

**آیا ذخیره‌کردن به ODP قالب منبع ارائه‌ای که از PPTX بارگذاری شده است را تغییر می‌دهد؟**

خیر. نمونهٔ موجود همچنان `Pptx` را گزارش می‌کند. نمونه‌ای که از فایل ODP ذخیره‌شده بارگذاری می‌شود، `Odp` را گزارش می‌دهد.

**آیا یک جریان می‌تواند همیشه یک ارائهٔ قدیمی، نمایش اسلاید یا قالب را متمایز کند؟**

خیر. PPT، PPS و POT قالب باینری مشترکی دارند. وقتی این تمییز لازم است، نام فایل یا فرادادهٔ زیرنوع را به‌طور جداگانه نگه دارید.

**اگر ارائه از پیش بارگذاری شده باشد، باید از چه API‑ی استفاده کنم؟**

[Presentation.SourceFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/sourceformat/) را بخوانید. برای بازرسی قبل از بارگذاری، از [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fa/net/aspose.slides/presentationfactory/getpresentationinfo/) استفاده کنید.