---
title: نصب
type: docs
weight: 70
url: /fa/nodejs-net/installation/
keywords:
- بارگیری Aspose.Slides
- نصب Aspose.Slides
- نصب Aspose.Slides
- ویندوز
- macOS
- لینوکس
- جاوااسکریپت
- Node.js
description: "نصب Aspose.Slides برای Node.js از طریق .NET از npm بر روی ویندوز یا لینوکس: پیش‌نیازها، جایگزینی edge-js، بازگردانی یک‌بار مصرف NuGet، و اولین برنامه‌ای که یک ارائه ایجاد می‌کند."
---
## **بررسی کلی**

Aspose.Slides for Node.js via .NET بسته npm `aspose.slides.via.net` است. این بسته کتابخانه Aspose.Slides .NET را در داخل Node.js از طریق رابط [edge-js](https://github.com/agracio/edge-js) اجرا می‌کند، بنابراین برای نصب صحیح به هر دو Node.js و .NET نیاز است.

این مقاله شما را از یک ماشین خالی به اولین برنامه‌ای که یک ارائه می‌سازد، راهنمایی می‌کند. چهار مرحله وجود دارد: ایجاد پروژه با یک override برای edge‑js، نصب بسته از npm، بازگردانی یک بار وابستگی‌های .NET بسته، و اجرای اسکریپт از پوشه پروژه.

## **پیش‌نیازها**

- **Node.js 22 یا 24 LTS**، ساخت x64، از [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 یا بالاتر**، از [dotnet.microsoft.com](https://dotnet.microsoft.com/download). فقط Runtime .NET کافی نیست: مرحله بازگردانی زیر به SDK نیاز دارد و همین‌طور پل زمانی که اسکریپت شما اجرا می‌شود. برای بررسی SDKهای نصب شده `dotnet --list-sdks` را اجرا کنید.
- **فقط در لینوکس**:
  - ابزارهای ساخت `python3`، `make` و `g++`، زیرا npm در هنگام نصب بر روی لینوکس edge‑js را کامپایل می‌کند؛
  - کتابخانه fontconfig که کتابخانه رسم بومی Aspose.Slides از آن بارگذاری می‌شود.

  در دبیان، این بسته‌ها `python3`، `make`، `g++` و `libfontconfig1` هستند.

مراحل این مقاله بر روی این پلتفرم‌ها تست شده‌اند:

| پلتفرم | نتیجه |
|---|---|
| Windows x64 با Node.js 22 یا 24 | کار می‌کند. با نصب Microsoft Visual C++ Redistributable تست شده است. |
| Linux x64 با Node.js 22 یا 24، که OpenSSL سیستم از همان خط انتشار OpenSSL موجود در Node.js است، مانند Debian 13 | کار می‌کند. |
| Linux که دو نسخه OpenSSL متفاوت هستند، مانند Debian 12 | Node.js هنگام ایجاد ارائه با خطای segmentation fault سقوط می‌کند. |
| macOS | تأیید نشده. |

در لینوکس، قبل از شروع دو نسخه را مقایسه کنید. اولین فرمان نسخه OpenSSL تعبیه شده در Node.js را چاپ می‌کند؛ دومین فرمان نسخه سیستم را. از سیستمی استفاده کنید که هر دو با یک شماره اصلی و فرعی شروع شوند، مثال `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

اگر فرمان `openssl` پیدا نشد، ابتدا بسته `openssl` را نصب کنید.

## **ایجاد پروژه**

یک پوشه برای پروژه خود ایجاد کنید، آن را مقداردهی اولیه کنید و یک override اضافه کنید که به npm بگوید کدام نسخهٔ edge‑js را نصب کند:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

بسته برای یک نسخهٔ قدیمی‌تر edge‑js درخواست می‌کند که باینری‌های پیش‌ساختهٔ ویندوز تا Node.js 20 را دارند، بنابراین بدون این override اولین اسکریپت در ویندوز با پیام «The edge module has not been pre-compiled for node.js version» متوقف می‌شود. این فرمان override را در بخش `overrides` فایل `package.json` می‌نویسد؛ قبل از نصب بسته آن را اضافه کنید.

## **نصب بسته**

Aspose.Slides for Node.js via .NET را از npm نصب کنید:

```sh
npm install aspose.slides.via.net
```

در طول نصب، بسته کتابخانه‌های رسم بومی خود (فایلی که نامشان شامل `aspose.slides.drawing.capi` است) را در کنار `package.json` در پوشه پروژه کپی می‌کند.

این بسته همچنین به صورت آرشیو ZIP در [releases.aspose.com](https://releases.aspose.com/slides/nodejs-net/) منتشر می‌شود. این مقاله فقط نصب از npm را پوشش می‌دهد.

## **بازگردانی وابستگی‌های .NET**

بسته شامل اسمبلی‌های Aspose.Slides .NET است، اما 20 بستهٔ NuGet که آن‌ها به آن‌ها وابسته‌اند را شامل نمی‌شود. در زمان اجرا، .NET به کش بسته‌های NuGet نگاه می‌کند: `%USERPROFILE%\.nuget\packages` در ویندوز، `~/.nuget/packages` در لینوکس، یا پوشه‌ای که در متغیر محیطی `NUGET_PACKAGES` تنظیم شده است. اگر موجود نباشند، اولین اسکریپت با پیام «assembly specified in the dependencies manifest was not found» متوقف می‌شود.

برای پر کردن کش، یک پوشه به نام `deps` در پوشهٔ پروژه ایجاد کنید و فایل زیر را به‌عنوان `deps.csproj` در آن ذخیره کنید. هر مورد `PackageDownload` یک بسته را دقیقاً با نسخهٔ درج شده در براکت دانلود می‌کند؛ هیچ چیزی ساخته نمی‌شود.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

سپس آن را از پوشهٔ پروژه بازگردانی کنید:

```sh
dotnet restore deps/deps.csproj
```

این گام را یک بار برای هر ماشین نیاز دارید، نه برای هر پروژه: بسته‌ها در کش NuGet می‌مانند و پروژه‌های بعدی روی همان ماشین از آن استفاده می‌کنند. پس از بازگردانی می‌توانید پوشهٔ `deps` را حذف کنید.

## **اجرای برنامهٔ اولیه**

فایلی به نام `hello.js` در پوشهٔ پروژه ایجاد کنید و کد زیر را در آن قرار دهید. این کد یک ارائه می‌سازد، یک مستطیل با متن «Hello, World! » به اسلاید اول اضافه می‌کند و نتیجه را به عنوان `hello.pptx` ذخیره می‌کند:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// یک ارائه جدید شامل یک اسلاید خالی است.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // موقعیت و اندازه بر حسب نقطه (1/72 اینچ) هستند: x، y، عرض، ارتفاع.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // شیء .NET که پشتیبان ارائه است را آزاد کنید.
    presentation.dispose();
}
```

آن را از پوشهٔ پروژه اجرا کنید:

```sh
node hello.js
```

اسکریپت `Saved hello.pptx` را چاپ می‌کند. فایل `hello.pptx` را باز کنید تا یک اسلاید با یک مستطیل پر شده که متن را در بر دارد ببینید. بدون لایسنس، Aspose.Slides همچنین یک علامت‌آبی ارزیابی اضافه می‌کند؛ برای جزئیات به [Evaluate Aspose.Slides](/slides/fa/nodejs-net/evaluate-aspose-slides/) و [Licensing](/slides/fa/nodejs-net/licensing/) مراجعه کنید.

{{% alert color="info" title="Note" %}}
اسکریپت‌های خود را از پوشهٔ پروژه اجرا کنید، یعنی پوشه‌ای که شامل `package.json` است. مسیرهای نسبی مانند `hello.pptx` نسبت به پوشهٔ فعلی حل می‌شوند و در برخی ماشین‌ها اسکریپتی که از پوشه‌ای دیگر اجرا شود نمی‌تواند ارائه‌ای ایجاد کند.
{{% /alert %}}

API جاوااسکریپت مرآتی از Aspose.Slides for .NET است: کلاس‌ها نام‌های .NET خود را حفظ می‌کنند، ویژگی‌ها و متدها از camelCase استفاده می‌کنند (`Slides` به `slides`، `AddAutoShape` به `addAutoShape`)، و آیتم‌های مجموعه با `get(index)` خوانده می‌شوند. مرجع API جداگانه‌ای برای این بسته وجود ندارد، بنابراین برای جزئیات کلاس‌ها و اعضا از [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) استفاده کنید، برای مثال [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) و [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/).

## **سؤالات متداول**

**پیام «The edge module has not been pre-compiled for node.js version» به چه معنی است؟**

npm نسخهٔ قدیمی‌تر edge‑js را که بسته درخواست می‌کند نصب کرده است. override را از بخش [ایجاد پروژه](#create-a-project) اضافه کنید و دوباره `npm install` را اجرا کنید.

**پیام «assembly specified in the dependencies manifest was not found» به چه معنی است؟**

وابستگی‌های .NET در کش NuGet موجود نیستند. همان اجرا همچنین پیام «edge.initializeClrFunc is not a function» را می‌دهد. یک بار مرحله [بازگردانی وابستگی‌های .NET](#restore-the-net-dependencies) را انجام دهید، سپس اسکریپت را دوباره اجرا کنید.

**در لینوکس پیام «The edge native module is not available» به چه معنی است؟**

edge‑js هنگام `npm install` کامپایل نشده است، برای مثال به دلیل عدم وجود `python3`، `make` یا `g++`. npm این را به‌عنوان خطا گزارش نمی‌دهد. ابزارهای ساخت را نصب کنید، سپس `npm rebuild edge-js` را در پوشهٔ پروژه اجرا کنید.

**چرا ایجاد یک ارائه با خطای خالی «Error» شکست می‌خورد؟**

در لینوکس بررسی کنید که کتابخانه fontconfig نصب باشد (`libfontconfig1` در دبیان)؛ بدون آن کتابخانه رسم بومی نمی‌تواند بارگذاری شود. در هر سیستم دیگری نیز اطمینان حاصل کنید که اسکریپت را از پوشهٔ پروژه اجرا می‌کنید.

**چرا Node.js در لینوکس با segmentation fault می‌سکند؟**

OpenSSL سیستم و OpenSSL تعبیه شده در Node.js از خطوط انتشار متفاوتی هستند. همان‌طور که در بخش [پیش‌نیازها](#prerequisites) نشان داده شد، آن‌ها را مقایسه کنید و از توزیعی یا ساخت Node.js استفاده کنید که نسخه‌ها مطابقت داشته باشند.

**آیا باید بازگردانی NuGet را برای هر پروژه تکرار کنم؟**

خیر. بازگردانی کش NuGet را برای حساب کاربری شما پر می‌کند و هر پروژه روی همان ماشین از همان کش استفاده می‌کند.