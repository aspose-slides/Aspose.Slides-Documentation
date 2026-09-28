---
title: نیازمندی‌های سیستم
type: docs
weight: 60
url: /fa/net/system-requirements/
keywords:
- نیازمندی‌های سیستم
- پلتفرم‌های پشتیبانی‌شده
- چارچوب‌های هدف
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- ویندوز
- لینوکس
- macOS
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قبل از نصب Aspose.Slides for .NET بررسی کنید که چه چیزهایی نیاز دارد: چارچوب‌هایی که هر بستهٔ NuGet هدف‌گذاری می‌کند، سیستم‌عامل‌ها و پردازنده‌های پشتیبانی‌شده، و کتابخانه‌ها و فونت‌هایی که لینوکس نیاز دارد."
---
## **مقدمه**

Aspose.Slides for .NET یک کتابخانهٔ مستقل است: نیازی به Microsoft PowerPoint یا Microsoft Office ندارد. این کتابخانه به‌صورت دو بستهٔ NuGet منتشر می‌شود، [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) و [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). هر دو همان فضای‌نام و کلاس‌های Aspose.Slides را ارائه می‌دهند؛ تفاوت آن‌ها در چارچوب‌های هدف‌گذاری‌شده و نحوهٔ رسم اسلایدها است که تعیین‌کنندهٔ محیط اجرا و نیازهای آن‌ها می‌باشد.

این مقاله نسخه‌ها و بسترهای .NET که هر بسته از آن‌ها پشتیبانی می‌کند، کتابخانه‌های سیستمی و فونت‌های مورد نیاز لینوکس را فهرست می‌کند و در پایان برنامهٔ کوتاهی برای بررسی تنظیمات شما ارائه می‌دهد. برای افزودن بسته به یک پروژه، بخش [Installation](/slides/fa/net/installation/) را ببینید.

## **نسخه‌های .NET پشتیبانی‌شده**

هر بسته برای هر چارچوب هدف یک بیلد از Aspose.Slides دارد و NuGet بیلد متناسب با چارچوب هدف پروژهٔ شما را انتخاب می‌کند.

| بسته | چارچوب‌های هدف در بسته | پروژهٔ شما می‌تواند هدف بگذارد |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 یا بالاتر؛ .NET 6 یا بالاتر، شامل .NET 8، .NET 9 و .NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 یا بالاتر، شامل .NET 8، .NET 9 و .NET 10 |

بیلد `netstandard2.0` به کتابخانهٔ کلاس‌دار .NET Standard 2.0 اجازه می‌دهد که به Aspose.Slides.NET مراجعه کند. برنامه‌ای که از چنین کتابخانه‌ای استفاده می‌کند، بیلدی که با چارچوب هدف خود برنامه سازگار است اجرا می‌کند: به‌عنوان مثال، برنامهٔ .NET 8، بیلد `net6.0` را اجرا می‌کند.

## **سیستم‌عامل‌ها و پردازنده‌های پشتیبانی‌شده**

**Aspose.Slides.NET** شامل تنها کد مدیریتی مستقل از پردازنده (AnyCPU) است، بنابراین بر روی معماری پردازندهٔ زمان‌اجرای .NET که آن را بارگذاری می‌کند، اجرا می‌شود. این کتابخانه اسلایدها را از طریق کتابخانهٔ System.Drawing.Common مایکروسافت می‌کشد که مایکروسافت فقط بر روی Windows از آن پشتیبانی می‌کند[only on Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). بر روی Linux، Aspose.Slides.NET به کتابخانهٔ `libgdiplus` و یک سوئیچ استارتاپ احتیاج دارد که در بخش [Linux](#linux) توضیح داده شده است. این کتابخانه بر توزیع‌های لینوکسی که `libgdiplus` را فراهم می‌کنند، مانند Debian، Ubuntu و Alpine Linux، اجرا می‌شود.

**Aspose.Slides.NET6.CrossPlatform** اسلایدها را با موتور گرافیکی خود می‌کشد. این موتور یک کتابخانهٔ بومی است که بسته در هر بیلد برای یک پلتفرم آن را شامل می‌شود، بنابراین بسته فقط بر روی این پلتفرم‌ها اجرا می‌شود:

| سیستم‌عامل | پردازنده‌ها | یادداشت‌ها |
|---|---|---|
| ویندوز | x86, x64 | ویندوز بر روی ARM64 پشتیبانی نمی‌شود. |
| لینوکس | x64, ARM64 | نیاز به glibc 2.23 یا بالاتر بر روی x64 و glibc 2.39 یا بالاتر بر روی ARM64 دارد. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform بر روی Alpine Linux یا توزیع‌های دیگر که بر پایهٔ musl به جای glibc ساخته شده‌اند، یا بر روی توزیع‌هایی با glibc قدیمی‌تر (مانند CentOS 7) اجرا نمی‌شود. در این موارد از Aspose.Slides.NET استفاده کنید.

بر روی ویندوز، کتابخانهٔ بومی Aspose.Slides.NET6.CrossPlatform از زمان اجرای Microsoft Visual C++ (*MSVCP140.dll* و *VCRUNTIME140.dll*، به‌اضافه *VCRUNTIME140_1.dll* بر روی x64) استفاده می‌کند. اگر این فایل‌ها روی ماشین هدف موجود نباشند، بستهٔ [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170) را نصب کنید.

## **Linux**

هر دو بسته به کتابخانه‌های سیستمی اضافی در لینوکس نیاز دارند. بدون آن‌ها، اولین مثال در [Create Presentations](/slides/fa/net/create-presentation/) به‌جای ذخیرهٔ فایل، یک استثنا پرتاب می‌کند. دستورات زیر برای Debian و Ubuntu هستند؛ در این توزیع‌ها، هر کتابخانه همچنین فونت‌های DejaVu (`fonts-dejavu-core`) را نصب می‌کند، به‌طوری که متن بدون نیاز به بسته‌های فونت دیگر رندر می‌شود.

### **Aspose.Slides.NET6.CrossPlatform**

کتابخانهٔ لینوکسی این بسته به کتابخانهٔ `fontconfig` نیاز دارد:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

بدون آن، ایجاد یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) با `TypeInitializationException` که داخل آن `DllNotFoundException` می‌گوید `libfontconfig.so.1` قابل باز شدن نیست، شکست می‌خورد.

تصاویر پایهٔ حداقل ممکن ممکن است `fontconfig` را نیز نداشته باشند. به‌عنوان مثال، تصویر پایهٔ AWS Lambda برای .NET 8، نه `fontconfig` و نه فونت دارد. در یک تصویر کانتینری ساخته‌شده بر پایهٔ آن، دستور `dnf install -y fontconfig` را اجرا کنید که همچنین فونت‌های Noto Sans را نصب می‌کند.

### **Aspose.Slides.NET**

این بسته دو مورد را بر روی لینوکس نیاز دارد:

1. کتابخانهٔ `libgdiplus`:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. سوئیچ `System.Drawing.EnableUnixSupport` که باید در ابتدای برنامه قبل از هر فراخوانی Aspose.Slides فعال شود. در یک *Program.cs* با دستورات سطح‑بالا، آن را پس از دستورات `using` قرار دهید:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

بدون `libgdiplus`، ذخیرهٔ ارائه با `TypeInitializationException` که داخل آن `DllNotFoundException` می‌گوید `libgdiplus` قابل بارگذاری نیست، شکست می‌خورد. بدون این سوئیچ، استثنای داخلی `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms` رخ می‌دهد.

{{% alert color="warning" title="Warning" %}}
این سوئیچ تنها با System.Drawing.Common 6 کار می‌کند، نسخه‌ای که Aspose.Slides.NET به آن وابسته است. مایکروسافت این سوئیچ را در System.Drawing.Common 7 حذف کرده است. اگر پروژهٔ شما به System.Drawing.Common 7 یا نسخهٔ بالاتر ارجاع دارد، مستقیم یا از طریق بستهٔ دیگری، Aspose.Slides.NET بر روی لینوکس حتی با نصب `libgdiplus` و فعال‌سازی سوئیچ با `PlatformNotSupportedException` مواجه می‌شود. در این صورت، از Aspose.Slides.NET6.CrossPlatform استفاده کنید.
{{% /alert %}}

### **Alpine Linux**

در Alpine Linux، از Aspose.Slides.NET به همراه سوئیچ فوق استفاده کنید. تصاویر Alpine معمولاً هیچ فونتی ندارند و تنها نصب `libgdiplus` فونتی نصب نمی‌کند، بنابراین `libgdiplus` را به همراه حداقل یک بستهٔ فونت نصب کنید. بدون فونت، ذخیرهٔ ارائه با این خطا مواجه می‌شود:

```text
System.ArgumentException: Font '?' cannot be found.
```

**گزینهٔ 1: فونت‌های DejaVu**

گزینهٔ پیشنهادی بستهٔ `ttf-dejavu` است:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

در نسخه‌های جاری Alpine، `ttf-dejavu` بستهٔ `font-dejavu` را نصب می‌کند که همچنین `fontconfig` و ابزارهای فونتی که به آن‌ها وابسته است را در بر می‌گیرد.

**گزینهٔ 2: فونت‌های اصلی مایکروسافت**

اگر ارائه‌های شما از فونت‌های مایکروسافت مانند Arial، Times New Roman، Courier New یا Verdana استفاده می‌کنند، به‌جای آن فونت‌های اصلی مایکروسافت را نصب کنید. مرحلهٔ `update-ms-fonts` فونت‌ها را هنگام ساخت تصویر دانلود می‌کند، بنابراین ساخت نیاز به دسترسی به اینترنت دارد:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **پشتیبانی از بومی‌سازی**

هر دو بسته به پشتیبانی بومی‌سازی .NET نیاز دارند که .NET بر روی لینوکس از طریق کتابخانه‌های ICU فراهم می‌کند. در [حالت جهانی‌سازی-غیر‌متغیر](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization)، ایجاد یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) با `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode` شکست می‌خورد.

برخی تصاویر کانتینر این حالت را فعال می‌کنند. به‌عنوان مثال، تصاویر زمان‌اجرای .NET برای Alpine Linux (`runtime-deps`, `runtime` و `aspnet`) متغیر `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` را تنظیم می‌کنند و ICU را شامل نمی‌شوند. در یک تصویر ساخته‌شده بر پایهٔ آن‌ها، ICU را نصب کنید و حالت را غیرفعال کنید:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

همچنین اطمینان حاصل کنید که فایل پروژهٔ شما خصوصیت `InvariantGlobalization` را به `true` تنظیم نکرده باشد.

## **بررسی تنظیمات شما**

برای اطمینان از اینکه بسته و پیش‌نیازهای آن موجود هستند، برنامه‌ای که یک ارائه را ذخیره می‌کند و اسلایدی را به تصویر تبدیل می‌کند، اجرا کنید. ذخیره و رندر کردن از کتابخانهٔ گرافیکی و فونت‌ها استفاده می‌کند، یعنی همان مواردی که الزامات لینوکس بالا فراهم می‌کند.

یک برنامهٔ کنسولی ایجاد کنید و بسته را همان‌طور که در [Installation](/slides/fa/net/installation/) توصیف شده اضافه کنید، محتوای *Program.cs* را با کد زیر جایگزین کنید و `dotnet run` را اجرا کنید. اگر از Aspose.Slides.NET بر روی لینوکس استفاده می‌کنید، عبارت سوئیچ `System.Drawing.EnableUnixSupport` را همان‌طور که در بخش [Linux](#linux) نشان داده شده پس از دستورات `using` اضافه کنید. برنامه از دستورات سطح‑بالا و اعلان‌های `using` استفاده می‌کند که به C# 9 یا بالاتر نیاز دارد. پروژه‌هایی که هدف .NET 6 یا بالاتر دارند به‌طور پیش‌فرض نسخهٔ جدیدتر C# را به‌کار می‌برند؛ در پروژه‌ای که هدف .NET Framework است، `<LangVersion>latest</LangVersion>` را به یک `PropertyGroup` در فایل پروژه اضافه کنید.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

این برنامه یک مستطیل با متن را به اولین اسلاید اضافه می‌کند و ارائه را با متد [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) به نام *hello.pptx* ذخیره می‌نماید. سپس اسلاید را با [GetImage](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/getimage/) رندر می‌کند و نتیجه را به نام *hello.png* با [IImage.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/save/) در قالب [ImageFormat.Png](https://reference.aspose.com/slides/fa/net/aspose.slides/imageformat/) ذخیره می‌کند. عوامل مقیاس ۱، یک پیکسل برای هر پوینت رندر می‌کند، بنابراین اسلاید پیش‌فرض ۷۲۰ × ۵۴۰ پوینت به تصویر ۷۲۰ × ۵۴۰ پیکسل تبدیل می‌شود و متن داخل مستطیل قابل مشاهده است. بدون لایسنس، هر دو فایل دارای واترمارک ارزیابی هستند؛ به [Licensing](/slides/fa/net/licensing/) مراجعه کنید. اگر پیش‌نیازی موجود نباشد، برنامه با یکی از استثناهای توصیف‌شده در بخش [Linux](#linux) متوقف می‌شود.

## **ابزارهای توسعه**

می‌توانید برنامه‌هایی که از Aspose.Slides استفاده می‌کنند را با هر ابزاری که چارچوب هدف پروژه شما را پشتیبانی می‌کند بسازید: .NET SDK و رابط خط فرمان `dotnet` آن روی Windows، Linux و macOS، یا Visual Studio روی Windows. بخش [Installation](/slides/fa/net/installation/) هر دو را توصیف می‌کند.

## **سوالات متداول**

**آیا برای تبدیل و رندر نیاز به نصب Microsoft PowerPoint دارم؟**

خیر، PowerPoint مورد نیاز نیست. Aspose.Slides یک موتور مستقل برای [ایجاد](/slides/fa/net/create-presentation/) ، اصلاح، [تبدیل](/slides/fa/net/convert-presentation/) و [رندر](/slides/fa/net/convert-powerpoint-to-png/) ارائه‌ها است.

**کدام بسته را باید استفاده کنم؟**

در ویندوز از Aspose.Slides.NET و در لینوکس و macOS از Aspose.Slides.NET6.CrossPlatform استفاده کنید. در Alpine Linux، در سیستم‌های لینوکسی که glibc قدیمی‌تر از نسخه‌های ذکر شده دارد و در پروژه‌هایی که هدف .NET Framework هستند، از Aspose.Slides.NET استفاده کنید. تنها یکی از این دو بسته را به پروژه اضافه کنید.

**برای رندر صحیح به چه فونت‌هایی نیاز است؟**

فونت‌های استفاده‌شده در ارائه یا جایگزین‌های مناسب باید در سیستم‌عامل موجود باشند. در لینوکس و macOS، بسته‌های فونتی که ارائه‌های شما به آن‌ها نیاز دارند نصب کنید تا رندر سازگار باشد. در Alpine Linux، حداقل یک بستهٔ فونت را علاوه بر `libgdiplus` نصب کنید، همان‌طور که در بخش [Alpine Linux](#alpine-linux) توضیح داده شد.

**چرا یک فونت سفارشی بر روی لینوکس به‌عنوان متن جایگزین یا گمشده رندر می‌شود؟**

اگر فایل فونت دارای ورودی‌های نام‑جدول ناسازگار یا خراب باشد، پشتهٔ تطبیق فونت لینوکس (FreeType/fontconfig) ممکن است رکورد نامعتبر را انتخاب کند و باعث عدم شناسایی فونت شود. استفاده از نسخه‌ای از فونت با رکوردهای نام‑جدول اصلاح‌شده یا نصب یک جایگزین سازگار این مشکل را برطرف می‌کند.