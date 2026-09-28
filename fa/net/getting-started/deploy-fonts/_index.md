---
title: استقرار قلم‌ها برای Aspose.Slides در لینوکس و Docker
linktitle: استقرار قلم‌ها
type: docs
weight: 145
url: /fa/net/deploy-fonts/
keywords:
- استقرار قلم‌ها
- نصب قلم‌ها
- قلم‌ها در Docker
- قلم‌ها در لینوکس
- قلم‌های گمشده
- جایگزینی قلم
- قلم‌های اصلی مایکروسافت
- ttf-mscorefonts-installer
- قلم‌های سفارشی
- قلم پیش‌فرض
- سرور
- کانتینر
- تبدیل PDF
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قلم‌ها را برای Aspose.Slides .NET بر روی سرورهای لینوکس و در کانتینرهای Docker استقرار دهید: بررسی کنید کدام قلم‌ها جایگزین می‌شوند، بسته‌های قلم را در Debian، Ubuntu و Alpine نصب کنید، فایل‌های قلم خود را اضافه کنید و یک قلم پیش‌فرض تنظیم کنید."
---
## **بررسی اجمالی**

Aspose.Slides متن را با قلم‌هایی که در دسترس آن هستند، هنگام رندر یک ارائه، برای مثال هنگام تبدیل اسلایدها به PDF یا به تصویر، رسم می‌کند. یک دسکتاپ ویندوز معمولاً قلم‌هایی که ارائه‌ها استفاده می‌کنند، دارد. سرورهای لینوکسی و کانتینرها اغلب دارای چند قلم یا هیچ قلمی نیستند، بنابراین Aspose.Slides متن را با یک قلم جایگزین رسم می‌کند. یک جایگزین شکل‌ها و عرض‌های حروف متفاوتی دارد، به‌طوری‌که خطوط می‌توانند به‌صورت متفاوتی بسته شوند و متن ممکن است از محدودهٔ خود بیرون بزند، و کاراکترهایی که جایگزین ندارند به‌درستی رسم نمی‌شوند. اگر هیچ قلمی نصب نشده باشد، تبدیل با خطایی متوقف می‌شود.

این مقاله نشان می‌دهد چگونه قلم‌هایی که Aspose.Slides جایگزین می‌کند را بررسی کنید، چگونه قلم‌ها را در Debian، Ubuntu و Alpine Linux نصب کنید، چگونه فایل‌های قلم خود را اضافه کنید، و چگونه قلمی را تنظیم کنید که هنگام عدم وجود قلم استفاده شود. مثال‌ها در Docker روی تصاویر رسمی .NET اجرا می‌شوند، همانند [Run Aspose.Slides for .NET in Docker](/slides/fa/net/how-to-run-aspose-slides-in-docker/). دستورات بسته، دستورالعمل‌های Dockerfile هستند؛ در یک سرور لینوکسی، همان دستورات را به‌عنوان root اجرا کنید.

برای خود API قلم، مانند درون‌ریزی قلم‌ها در یک ارائه و قوانین جایگزینی و بازگشت، به [PowerPoint Fonts](/slides/fa/net/powerpoint-fonts/) مراجعه کنید.

## **بررسی قلم‌های جایگزین‌شده**

برنامهٔ کنسولی زیر قلم‌هایی که Aspose.Slides در محیط کنونی جایگزین می‌کند، گزارش می‌دهد. یک پوشه به نام *FontCheck* ایجاد کنید و فایل‌های زیر را به آن اضافه کنید.

*FontCheck.csproj* به [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) ارجاع می‌دهد، بسته‌ای برای Debian و Ubuntu. همچنین فایل‌های پوشهٔ اختیاری *fonts* را به خروجی برنامه کپی می‌کند؛ بخش [Load Fonts from the Application Folder](#load-fonts-from-the-application-folder) از آن استفاده می‌کند.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* برای هر نام قلم یک جعبهٔ متن به اسلاید اضافه می‌کند و قلم را از طریق ویژگی [LatinFont](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/latinfont/) اختصاص می‌دهد. نام‌های قلم از خط فرمان می‌آید؛ بدون آرگومان، برنامه Calibri، Arial و Times New Roman را بررسی می‌کند. پوشه‌هایی که Aspose.Slides در جستجوی قلم‌ها در آن‌ها می‌گردد را چاپ می‌کند ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/))، اسلاید را به *output/fonts.pdf* رندر می‌کند و جایگزین‌های گزارش‌شده توسط [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) را چاپ می‌کند. دو مرحلهٔ اختیاری در ابتدا، بارگذاری پوشهٔ *fonts* و خواندن متغیر `DEFAULT_FONT`، بعدا در این مقاله توضیح داده می‌شوند.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// قلم‌های مورد بررسی: آرگومان‌های خط فرمان، یا سه قلم رایج آفیس.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// قلم‌های فایل را از پوشهٔ fonts که در کنار برنامه قرار دارد، در صورت وجود، بارگذاری کنید.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// از قلم مشخص‌شده در متغیر محیطی DEFAULT_FONT، در صورتی که تنظیم شده باشد، برای متنی که قلم آن موجود نیست استفاده کنید.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* نتایج ساخت محلی را از زمینهٔ ساخت خارج می‌دارد:

```text
bin/
obj/
output/
```

*Dockerfile* برنامه را با تصویر .NET SDK می‌سازد و آن را بر روی تصویر .NET runtime اجرا می‌کند. مرحلهٔ runtime `libfontconfig1` را نصب می‌کند که Aspose.Slides.NET6.CrossPlatform به آن نیاز دارد، و قلم‌های DejaVu. [Run Aspose.Slides for .NET in Docker](/slides/fa/net/how-to-run-aspose-slides-in-docker/) هر دستور را توضیح می‌دهد.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

تصویر را بسازید و بررسی را اجرا کنید:

```bash
docker build -t font-check .
docker run --rm font-check
```

این تصویر فقط قلم‌های DejaVu را دارد، بنابراین هر سه قلم با DejaVu Sans جایگزین می‌شوند:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

برای بررسی قلم‌های ارائه‌های خود، نام‌های آن‌ها را به‌عنوان آرگومان منتقل کنید، برای مثال `docker run --rm font-check "Segoe UI" Consolas`. برای کپی کردن *output/fonts.pdf* خارج از کانتینر، از دستورات موجود در [Copy the Output to Your Machine](/slides/fa/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) استفاده کنید.

## **نصب قلم‌ها در Debian و Ubuntu**

### **قلم‌های اصلی مایکروسافت**

بستهٔ `ttf-mscorefonts-installer` قلم‌های اصلی مایکروسافت برای وب را دانلود و نصب می‌کند، که شامل Arial، Times New Roman، Courier New، Verdana، Georgia و Trebuchet MS می‌شود. این قلم‌ها تحت توافق‌نامهٔ کاربر نهایی (EULA) مایکروسفت مجوز دارند و بسته فقط پس از پذیرش EULA آن‌ها را نصب می‌کند. یک ساخت Docker نمی‌تواند به پیام پاسخ دهد، بنابراین نصب‌کننده EULA را رد می‌کند و هیچ قلمی نصب نمی‌شود، در حالی که `apt-get install` هنوز موفقیت را گزارش می‌دهد. قبل از نصب بسته، EULA را با `debconf-set-selections` **قبل از** نصب بپذیرید.

در *Dockerfile*، دستور `RUN` که بسته‌ها را در مرحلهٔ runtime نصب می‌کند، با موارد زیر جایگزین کنید:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

تصویر را بسازید و بررسی را دوباره با همان دو فرمان اجرا کنید. حالا Arial و Times New Roman نصب شده‌اند:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri، قلم پیش‌فرض یک ارائه‌ای که Aspose.Slides ایجاد می‌کند، یکی از قلم‌های اصلی نیست، بنابراین همچنان جایگزین می‌شود. به [تنظیم یک قلم پیش‌فرض برای قلم‌های از دست رفته](#set-a-default-font-for-missing-fonts) مراجعه کنید.

در Debian، بسته در بخش مخزن `contrib` قرار دارد که تصاویر Debian آن را فعال نمی‌کند؛ تصاویر پیش‌فرض .NET 8 و .NET 9 بر پایهٔ Debian 12 ساخته شده‌اند. `contrib` را در همان دستور فعال کنید:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

تصاویر .NET 10 مبتنی بر Ubuntu قبلاً `multiverse` را فعال کرده‌اند، بخشی از Ubuntu که این بسته را شامل می‌شود.

### **بقیهٔ بسته‌های قلم**

Debian و Ubuntu همچنین قلم‌های مجوز آزاد را بسته‌بندی می‌کنند، برای مثال:

| Package | قلم‌ها |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif و Mono، با متریک‌های مشابه Arial، Times New Roman و Courier New |
| `fonts-crosextra-carlito` | Carlito، با متریک‌های مشابه Calibri |
| `fonts-crosextra-caladea` | Caladea، با متریک‌های مشابه Cambria |

آن‌ها را با `apt-get install` در همان دستور `RUN` نصب کنید. Aspose.Slides.NET6.CrossPlatform از نام‌های مستعار قلم در پیکربندی قلم لینوکس استفاده نمی‌کند: حتی با نصب `fonts-liberation`، متن در Arial هنوز با قلم جایگزین عمومی رسم می‌شود، نه با Liberation Sans. برای استفاده از یک قلم متریک‌سازگار به‌جای قلم گمشده، آن را به‌عنوان [قلم پیش‌فرض](#set-a-default-font-for-missing-fonts) تنظیم کنید یا یک [قوانین جایگزینی قلم](/slides/fa/net/font-substitution/) اضافه کنید.

## **اضافه کردن فایل‌های قلم خود**

قلم‌هایی که توزیع‌کنندگان بسته‌بندی نکرده‌اند، مانند قلم‌های سازمان شما یا سایر قلم‌هایی که مجوز استفاده از آن‌ها را بر روی سرور دارید، می‌توانند به‌صورت فایل‌های قلم اضافه شوند. فایل‌های قلم، برای مثال فایل‌های *.ttf*، را در پوشه‌ای به نام *fonts* داخل پوشهٔ *FontCheck* قرار دهید. مثال‌های زیر از فایل‌های Carlito استفاده می‌کنند، قلمی با متریک‌های مشابه Calibri که می‌توانید آن را از [Google Fonts](https://fonts.google.com/specimen/Carlito) دانلود کنید.

### **نصب قلم‌ها در پوشهٔ قلم سیستم**

Aspose.Slides قلم‌ها را از پوشه‌هایی که در خط `Font folders` چاپ می‌شود می‌خواند. برای نصب قلم‌های خود برای تمام برنامه‌ها در تصویر، آن‌ها را به */usr/local/share/fonts*، پوشهٔ قلم‌های نصب‌ شده به‌صورت محلی، کپی کنید. این دستور را به مرحلهٔ runtime *Dockerfile*، بعد از دستور `RUN` که بسته‌ها را نصب می‌کند، اضافه کنید:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **بارگذاری قلم‌ها از پوشهٔ برنامه**

به‌جای نصب قلم‌ها در تصویر، می‌توانید آن‌ها را همراه برنامه بفرستید و با [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) بارگذاری کنید. سپس قلم‌ها فقط برای Aspose.Slides در دسترس خواهند بود و همراه با برنامه مستقر می‌شوند. *FontCheck* این کار را انجام می‌دهد: *FontCheck.csproj* پوشهٔ *fonts* را به خروجی برنامه کپی می‌کند و *Program.cs* قبل از ایجاد ارائه، آن پوشه را به `LoadExternalFonts` می‌فرستد. [Custom Font](/slides/fa/net/custom-font/) روش‌های دیگر تأمین قلم‌ها را توصیف می‌کند، مانند بارگذاری از حافظه.

تصویر را دوباره بسازید، سپس Calibri و Carlito را بررسی کنید:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

حالا پوشهٔ برنامه در میان پوشه‌های قلم ظاهر می‌شود و Carlito دیگر جایگزین نمی‌شود:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **تنظیم یک قلم پیش‌فرض برای قلم‌های گمشده**

وقتی قلمی وجود نداشته باشد، Aspose.Slides از یک جایگزین که خود انتخاب می‌کند استفاده می‌کند. برای انتخاب آن به‌صورت دستی، ویژگی [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultregularfont/) را در [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) تنظیم کنید و گزینه‌ها را به سازندهٔ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) پاس بدهید. *FontCheck* نام قلم را از متغیر محیطی `DEFAULT_FONT` می‌خواند. با بارگذاری Carlito، از آن برای قلم‌های گمشده استفاده کنید:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

اکنون Calibri با Carlito رسم می‌شود، که کاراکترهای آن دارای عرض‌های مشابه Calibri هستند، بنابراین متن خطوط خود را حفظ می‌کند:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

قلم پیش‌فرض هر قلم گمشده‌ای را جایگزین می‌کند. برای نگاشت قلم‌های منفرد، برای مثال Arial به Liberation Sans و Calibri به Carlito، از [قوانین جایگزینی قلم](/slides/fa/net/font-substitution/) استفاده کنید. قوانین خروجی رندر شده را تغییر می‌دهند، اما `GetSubstitutions` آن‌ها را نشان نمی‌دهد، بنابراین به‌جای آن قلم‌ها را در فایل خروجی بررسی کنید. برای متون آسیایی، همچنین [DefaultAsianFont] را تنظیم کنید؛ به [Default Font](/slides/fa/net/default-font/) مراجعه کنید.

## **نصب قلم‌ها بر روی Alpine Linux**

در Alpine Linux، از بستهٔ Aspose.Slides.NET استفاده کنید؛ [Run on Alpine Linux](/slides/fa/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) تغییرات پروژه را فهرست می‌کند. همان تغییرات را برای *FontCheck* اعمال کنید: مرجع بسته را جایگزین کنید، عبارت `SetSwitch` را به *Program.cs* اضافه کنید و از این مرحلهٔ runtime استفاده کنید که همچنین قلم‌های اصلی مایکروسافت را نصب می‌کند:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` همان قلم‌های اصلی مایکروسافت را همانند بستهٔ Debian و Ubuntu دانلود و نصب می‌کند و EULA آن‌ها به‌همین شکل اعمال می‌شود. `fc-cache` کش قلم‌ها را به‌روزرسانی می‌کند.

با Aspose.Slides.NET بر روی لینوکس، کتابخانهٔ پیکربندی قلم (fontconfig) جایگزین قلم گمشده را انتخاب می‌کند و `GetSubstitutions` آن را گزارش نمی‌دهد، بنابراین *FontCheck* `No font substitutions.` را چاپ می‌کند. برای دیدن اینکه کدام قلم برای نام قلم استفاده می‌شود، در کانتینر از fontconfig بپرسید:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

با نصب قلم‌های اصلی مایکروسافت، Arial برای Arial استفاده می‌شود:

```text
Arial.ttf: "Arial" "Regular"
```

بدون آن‌ها، زمانی که دستور `RUN` فقط `icu-libs libgdiplus font-dejavu` را نصب می‌کند، همان فرمان چاپ می‌کند:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **سوالات متداول**

**چرا یک ارائه هنگام تبدیل بر روی سرور متفاوت به نظر می‌رسد؟**

سرور قلم‌هایی که ارائه استفاده می‌کند را ندارد، بنابراین Aspose.Slides متن را با قلم جایگزینی می‌نویسد که حروف آن عرض‌های متفاوتی دارند. *FontCheck* را با نام‌های قلم‌های ارائه اجرا کنید تا ببینید کدام قلم‌ها جایگزین شده‌اند، سپس آن قلم‌ها را نصب کنید یا از پوشهٔ برنامه بارگذاری کنید.

**ساخت ttf-mscorefonts-installer را نصب کرد، اما هنوز Arial جایگزین می‌شود. چرا؟**

EULA قبل از نصب بسته پذیرفته نشده بود، بنابراین نصب‌کننده قلم‌ها را رد کرد. دستور `debconf-set-selections` را قبل از `apt-get install` اضافه کنید، همان‌طور که در [قلم‌های اصلی مایکروسافت](#microsoft-core-fonts) نشان داده شده است، و تصویر را دوباره بسازید.

**آیا کامپیوتری که PDF را باز می‌کند به قلم‌ها نیاز دارد؟**

خیر. در این مثال‌ها، PDF شامل قلم‌هایی است که برای رسم متن استفاده شده‌اند، بنابراین در هر کامپیوتری یکسان به‌نظر می‌رسد. قلم‌ها فقط در جایی که Aspose.Slides ارائه را رندر می‌کند، لازم هستند.