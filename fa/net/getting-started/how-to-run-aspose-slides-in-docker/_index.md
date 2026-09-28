---
title: اجرای Aspose.Slides برای .NET در Docker
linktitle: داکر
type: docs
weight: 140
url: /fa/net/how-to-run-aspose-slides-in-docker/
keywords:
- داکر
- Dockerfile
- کانتینر Docker
- ساخت چندمرحله‌ای
- تصویر کانتینر
- لینوکس
- اوبونتو
- آلپاین
- libfontconfig
- libgdiplus
- فونت‌ها
- تبدیل PDF
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ساخت و اجرای یک برنامهٔ کنسولی Aspose.Slides برای .NET در Docker: Dockerfile چندمرحله‌ای بر روی تصاویر رسمی .NET، کتابخانه‌ها و فونت‌های لینوکسی که نیاز دارد، و نحوهٔ کپی کردن فایل‌های تولید شده به ماشین شما."
---
## **بررسی کلی**

این مقاله نشان می‌دهد که چگونه Aspose.Slides for .NET را در یک کانتینر Docker اجرا کنید. شما یک برنامهٔ کوچک کنسولی می‌سازید که یک ارائه با جعبهٔ متن ایجاد کرده و به PDF تبدیل می‌کند، آن را با Dockerfile چندمرحله‌ای بر روی تصاویر رسمی .NET مایکروسافت بسته‌بندی می‌کند، اجرا می‌کند و فایل‌های تولید شده را به ماشین خود کپی می‌کند. مقاله همچنین کتابخانه‌ها و فونت‌های لینوکسی که Aspose.Slides در داخل کانتینر به آن‌ها نیاز دارد را فهرست می‌کند و با یک نسخه برای Alpine Linux پایان می‌یابد.

برای اجرای این کار فقط به Docker روی ماشین خود نیاز دارید. .NET SDK بخشی از تصویر ساخت است، بنابراین نیازی به نصب آن ندارید. برای نصب Docker، به [دریافت Docker](https://docs.docker.com/get-started/get-docker/) مراجعه کنید.

## **انتخاب بسته و تصویر پایه**

تصاویر پیش‌فرض کانتینر .NET 10 بر پایه Ubuntu 24.04 ساخته شده‌اند. در این تصاویر، از بسته [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) استفاده کنید. این بسته به کتابخانه `fontconfig` نیاز دارد و تصویر زمان اجرا .NET نه آن کتابخانه را دارد و نه هیچ فونتی، بنابراین Dockerfile این مقاله هر دو را نصب می‌کند.

Aspose.Slides.NET6.CrossPlatform بر روی Alpine Linux اجرا نمی‌شود. برای تصاویر مبتنی بر Alpine، از بسته [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) همراه با `libgdiplus` استفاده کنید، همان‌طور که در [اجرای بر روی Alpine Linux](#run-on-alpine-linux) توضیح داده شده است. [نصب](/slides/fa/net/installation/) دو بسته را مقایسه می‌کند.

## **ایجاد پروژه**

یک پوشه به نام *HelloSlidesDocker* ایجاد کنید و سه فایل زیر را به آن اضافه کنید.

*HelloSlidesDocker.csproj* یک برنامهٔ کنسولی برای .NET 10 توصیف می‌کند، نسخهٔ تصاویر کانتینر استفاده‌شده در زیر را مشخص می‌کند و به Aspose.Slides.NET6.CrossPlatform ارجاع می‌دهد. نسخهٔ بسته را به آخرین نسخهٔ موجود در [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) تنظیم کنید.

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
  </ItemGroup>

</Project>
```

*Program.cs* یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد می‌کند، یک مستطیل با متن به اسلاید اول اضافه می‌کند و ارائه را دو بار با روش [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) ذخیره می‌کند: به صورت PPTX و به صورت PDF. هر دو فایل در پوشهٔ *output* تحت پوشهٔ کاری قرار می‌گیرند. سپس برنامهٔ کاربردی فونت‌هایی را که در حین رندر PDF جایگزین شدند، با استفاده از [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontsmanager/getsubstitutions/) فهرست می‌کند تا بتوانید ببینید که آیا کانتینر فونت‌های مورد استفادهٔ ارائه را دارد یا خیر.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* پوشه‌های *bin* و *obj* یک ساخت محلی و خروجی اجراهای قبلی را از زمینهٔ ساخت Docker حذف می‌کند، بنابراین تصویر فقط از فایل‌های منبع ساخته می‌شود.

```text
bin/
obj/
output/
```

## **نوشتن Dockerfile**

فایلی به نام *Dockerfile* به همان پوشه اضافه کنید:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
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
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

فایل دو مرحله دارد:

- **مرحلهٔ ساخت** از تصویر .NET SDK شروع می‌شود. ابتدا فایل پروژه را کپی می‌کند و بسته‌های NuGet را بازنشانی می‌کند، بنابراین Docker این لایه را تا وقتی که فایل پروژه تغییر نکند، مجدداً استفاده می‌کند. سپس کد منبع را کپی کرده و برنامه را به */app* منتشر می‌کند.
- **مرحلهٔ زمان اجرا** از تصویر کوچکتر .NET runtime که SDK ندارد شروع می‌شود و فقط برنامهٔ منتشر شده را کپی می‌کند. دو بسته نصب می‌کند:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform این کتابخانه را هنگام شروع بارگذاری می‌کند. بدون آن، برنامه با `DllNotFoundException` که نام `libfontconfig.so.1` را دارد، متوقف می‌شود.
  - `fonts-dejavu-core`: تصویر زمان اجرا هیچ فونتی ندارد و Aspose.Slides برای رسم متن حداقل یک فونت نصب‌شده لازم دارد؛ بدون آن، تبدیل با `InvalidOperationException: Cannot find any fonts installed on the system.` متوقف می‌شود. متن با فونت‌های جایگزین رسم می‌شود. فونت‌های DejaVu مجموعهٔ کوچکی هستند که متن را رندر می‌کنند؛ برای رندر ارائه‌ها با فونت‌های اصلی، به [استقرار فونت‌ها](/slides/fa/net/deploy-fonts/) مراجعه کنید.

`--no-install-recommends` و حذف فهرست بسته‌ها تصویر را کوچک نگه می‌دارند. خطوط آخر پوشهٔ *output* را ایجاد می‌کنند، آن را به کاربر غیر ریشهٔ `app` می‑سپارند (شناسهٔ کاربر در متغیر `APP_UID` قرار دارد) و برنامه را به عنوان همان کاربر اجرا می‌کنند.

برای یک برنامهٔ ASP.NET Core، مرحلهٔ زمان اجرا را به جای آن از `mcr.microsoft.com/dotnet/aspnet:10.0` شروع کنید. این تصویر بر پایهٔ همان تصویر Ubuntu است، بنابراین بسته‌های مشابهی مورد نیاز است.

## **ساخت و اجرا کانتینر**

یک ترمینال را در پوشهٔ *HelloSlidesDocker* باز کنید. تصویر را بسازید، سپس یک کانتینر از آن اجرا کنید:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

ساخت اول، تصاویر پایه و بسته‌های NuGet را دانلود می‌کند، بنابراین زمان بیشتری نسبت به ساخت‌های بعدی می‌گیرد. کانتینر برنامه را اجرا می‌کند و متوقف می‌شود. خروجی چاپ می‌شود:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

خط اولین نشان می‌دهد که متن از فونت Calibri (فونت پیش‌فرض یک ارائهٔ جدید) استفاده می‌کند و Calibri در تصویر نصب نشده است، بنابراین Aspose.Slides متن را با DejaVu Sans رسم کرده است. متن در PDF متن واقعی و قابل انتخاب با همان فونت است. بدون لایسنس، Aspose.Slides همچنین یک علامت آب‌نشانی ارزیابی به هر اسلایدی که ذخیره می‌کند اضافه می‌کند؛ به [مجوزها](/slides/fa/net/licensing/) مراجعه کنید.

## **کپی خروجی به ماشین شما**

فایل‌ها در پوشهٔ */app/output* کانتینر متوقف‌شده قرار دارند. آن‌ها را به پوشهٔ *output* روی ماشین خود کپی کنید، سپس کانتینر را حذف کنید:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

این دو فرمان در Bash، PowerShell و Windows Command Prompt به همان شکل کار می‌کنند.

در لینوکس، می‌توانید به جای آن یک پوشه از ماشین خود را به کانتینر وصل کنید تا برنامهٔ کاربردی فایل‌ها را مستقیم در آنجا بنویسد:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

گزینه `--user` برنامه را با شناسه‌های کاربر و گروه شما اجرا می‌کند، بنابراین می‌تواند در پوشه‌ای که ایجاد کرده‌اید بنویسد و فایل‌ها متعلق به شما خواهند بود. `--rm` در زمان توقف، کانتینر را حذف می‌کند.

## **اجرای بر روی Alpine Linux**

برای اجرای برنامه در یک تصویر مبتنی بر Alpine، به بسته Aspose.Slides.NET تغییر دهید و مرحلهٔ زمان اجرا را تغییر دهید. مرحلهٔ ساخت همان‌گونه می‌ماند.

1. در *HelloSlidesDocker.csproj*، مرجع بسته را جایگزین کنید:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. در *Program.cs*، این عبارت را پس از دستورات `using` و قبل از اولین فراخوانی Aspose.Slides اضافه کنید. این عبارت پشتیبانی System.Drawing برای لینوکس را که Aspose.Slides.NET استفاده می‌کند فعال می‌سازد:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. در *Dockerfile*، مرحلهٔ زمان اجرا (تمامی محتوا از خط دوم `FROM`) را با موارد زیر جایگزین کنید:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

مرحلهٔ Alpine سه بسته نصب می‌کند و یک تنظیم را تغییر می‌دهد:

- `libgdiplus` کتابخانهٔ گرافیکی است که Aspose.Slides.NET در لینوکس استفاده می‌کند.
- `font-dejavu` فونت‌ها را فراهم می‌کند. بدون هر فونت، تبدیل با `System.ArgumentException: Font '?' cannot be found` متوقف می‌شود.
- `icu-libs` و `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` داده‌های فرهنگی را فراهم می‌کنند. تصاویر .NET بر پایه Alpine به‌صورت پیش‌فرض در حالت globalization‑invariant اجرا می‌شوند و در آن حالت Aspose.Slides با `CultureNotFoundException` برای `en-US` متوقف می‌شود.

با همان دستورات بالا برنامه را بسازید، اجرا کنید و خروجی را کپی نمایید. در این تصویر، برنامه تنها خط `Saved` را چاپ می‌کند: با Aspose.Slides.NET در لینوکس، fontconfig جایگزین فونت گمشده را انتخاب می‌کند و [GetSubstitutions](https://reference.aspose.com/slides/fa/net/aspose.slides/ifontsmanager/getsubstitutions/) آن را فهرست نمی‌کند. [استقرار فونت‌ها](/slides/fa/net/deploy-fonts/) نحوهٔ بررسی فونت استفاده‌شده را نشان می‌دهد.

## **سوالات متداول**

**برنامه با پیام «Unable to load shared library 'libaspose.slides.drawing.capi…'» متوقف می‌شود. چه چیزی کم است؟**

در تصاویر Ubuntu و Debian، بسته `libfontconfig1` نیاز است؛ پیام `libfontconfig.so.1` را به‌عنوان فایلی که نمی‌تواند باز شود، نشان می‌دهد. در Alpine Linux، این پیام به این معناست که Aspose.Slides.NET6.CrossPlatform در حال استفاده است؛ به Aspose.Slides.NET همان‌طور که در [اجرای بر روی Alpine Linux](#run-on-alpine-linux) توضیح داده شد، تغییر دهید.

**چرا متن در PDF با فونت متفاوتی نسبت به PowerPoint نمایش داده می‌شود؟**

فونت‌هایی که ارائه استفاده می‌کند در تصویر نصب نشده‌اند، بنابراین Aspose.Slides متن را با یک فونت جایگزین رسم می‌کند. خروجی برنامه نام هر فونت جایگزین‌شده را نشان می‌دهد. [استقرار فونت‌ها](/slides/fa/net/deploy-fonts/) توضیح می‌دهد چگونه فونت‌ها را در تصویر نصب کنید یا از پوشهٔ برنامه بارگذاری کنید.

**آیا به .NET SDK روی ماشین خود نیاز دارم؟**

خیر. مرحلهٔ ساخت برنامه را داخل تصویر SDK کامپایل می‌کند. شما فقط در صورتی به SDK نیاز دارید که بخواهید برنامه را خارج از Docker نیز بسازید و اجرا کنید؛ به [نصب](/slides/fa/net/installation/) مراجعه کنید.