---
title: نیازمندی‌های سیستم
type: docs
weight: 60
url: /fa/net/system-requirements/
keywords:
- نیازمندی‌های سیستم
- سیستم‌عامل
- نصب
- وابستگی‌ها
- ویندوز
- لینوکس
- macOS
- پاورپوینٹ
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مشخصات نیازمندی‌های Aspose.Slides for .NET را کشف کنید. اطمینان حاصل کنید که پشتیبانی یکپارچه PowerPoint و OpenDocument در ویندوز، لینوکس و macOS وجود دارد."
---
## **مقدمه**

Aspose.Slides for .NET نیازی به نصب Microsoft PowerPoint ندارد زیرا Aspose.Slides یک موتور مستقل برای ایجاد، تبدیل، چیدمان صفحه و رندر اسناد Microsoft PowerPoint است.

## **سیستم‌عامل‌های پشتیبانی‌شده**

Aspose.Slides for .NET هر سیستم‌عامل 32‑bit یا 64‑bit را که فریم‌ورک .NET یا Mono روی آن نصب شده باشد پشتیبانی می‌کند، از جمله (اما نه محدود به):

### **ویندوز**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **لینوکس**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, و سایر)

### **Mac**

- Mac OS X

## **فریم‌ورک‌های پشتیبانی‌شده**

Aspose.Slides for .NET فریم‌ورک‌های .NET و Mono را پشتیبانی می‌کند:

### **.NET Framework**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM Interop support (COM, C++, VBScript)

### **فریم‌ورک Mono**

- MONO Support in MAC and Linux platforms

## **محیط‌های توسعه**

Aspose.Slides for .NET می‌تواند در هر محیط توسعه‌ای که هدف آن پلتفرم .NET است استفاده شود، اما محیط‌های زیر به‌طور صریح پشتیبانی می‌شوند:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **ساخت‌های اصلی Aspose.Slides**

در حال حاضر دو ساخت اصلی از Aspose.Slides وجود دارد — Aspose.Slides.NET و Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides برای .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

این نسخه اصلی محصول است. از موتور گرافیکی استاندارد .NET استفاده می‌کند.
- در پلتفرم‌های غیر ویندوز، ممکن است نیاز به نصب کتابخانه `libgdiplus` و وابستگی‌های آن داشته باشید.
- پیش از نسخه Aspose.Slides 25.3، برای پلتفرم‌های غیر ویندوز لازم بود DLL استاندارد .NET 2.0 از بسته ZIP Aspose.Slides استفاده شود.
- از نسخه Aspose.Slides 25.3 به بعد، می‌توانید بسته NuGet را مستقیماً حتی در سیستم‌های غیر ویندوز استفاده کنید.
- هنگام اجرا در سیستم‌های غیر ویندوز، برنامه شما باید خط زیر را در زمان شروع گنجانده باشد:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **از نسخه 25.3 به بعد می‌توانید این بسته را بر روی پلتفرم‌هایی که از .NET پشتیبانی می‌کنند، مانند Linux aarch64 (ARM64) استفاده کنید.**

#### **بسته‌های اضافی برای Alpine لینوکس**

زمانی که Aspose.Slides for .NET را در یک کانتینر Alpine Linux اجرا می‌کنید، نصب تنها `libgdiplus` ممکن است کافی نباشد. کانتینرهای Alpine معمولاً به‌طور پیش‌فرض فونت ندارند. اگر فونتی موجود نباشد، عملیات رندر یا تبدیل ممکن است با خطایی مشابه زیر شکست بخورد:

```text
System.ArgumentException: Font '?' cannot be found
```
برای استفاده از Aspose.Slides در Alpine، `libgdiplus` را همراه با حداقل یک بسته فونت نصب کنید.

**گزینه 1: فونت‌های DejaVu**

گزینه پیشنهادی نصب بسته `ttf-dejavu` است:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

بسته `ttf-dejavu` به‌صورت خودکار وابستگی‌های مرتبط با فونت مانند `fontconfig`، `encodings`، `mkfontscale` و `mkfontdir` را نصب می‌کند. برای اکثر موارد دیگر نیازی به بسته‌های فونت اضافی نیست.

**گزینه 2: فونت‌های اصلی مایکروسافت**

اگر ارائه‌های شما از فونت‌های اختصاصی مایکروسافت مانند Arial، Times New Roman، Courier New یا Verdana استفاده می‌کنند، به‌جای آن فونت‌های Core Fonts مایکروسافت را نصب کنید:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

این گزینه فقط زمانی استفاده شود که ارائه‌های پردازش‌شده به فونت‌های مایکروسافت نیاز داشته باشند. برای بیشتر سناریوها، نصب `ttf-dejavu` ساده‌تر و قابل اطمینان‌تر است.

**نیازمندی‌های اضافی برای جهانی‌سازی**

برای فعال‌سازی پشتیبانی مناسب جهانی‌سازی در Alpine، بسته `icu-libs` را نصب کنید و حالت invariant را غیرفعال کنید:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides برای .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

این نسخه از Aspose.Slides است که از یک موتور گرافیکی سفارشی چند‌پلتفرمی توسعه‌یافته توسط تیم Aspose.Slides استفاده می‌کند. در پلتفرم‌های غیر ویندوز ممکن است کتابخانه `fontconfig` لازم باشد.

**پلتفرم‌های پشتیبانی‌شده**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**پلتفرم‌های پشتیبانی‌نشده**
- *Windows 11 ARM* (ARM64) — *در حال حاضر در نظر گرفته نشده است*

{{%  alert  title="Notes"  color="info"  %}}  
برای Linux x64، GLIBC 2.23+ مورد نیاز است؛ برای Linux ARM64، GLIBC 2.39+ مورد نیاز است. سیستم‌هایی مانند CentOS 7 (GLIBC 2.14) پشتیبانی نمی‌شوند. اگر نیاز به اجرای Aspose.Slides بر روی CentOS 7 یا سیستم‌های ناسازگار دیگر (مثلاً Alpine) دارید، لطفاً از بسته استاندارد استفاده کنید: [Aspose.Slides برای .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **سوالات متداول**

### **آیا برای تبدیل و رندرینگ نیاز به نصب Microsoft PowerPoint دارم؟**

نه، PowerPoint لازم نیست؛ Aspose.Slides یک موتور مستقل برای [ایجاد](/slides/fa/net/create-presentation/)، ویرایش، [تبدیل](/slides/fa/net/convert-presentation/) و [رندر](/slides/fa/net/convert-powerpoint-to-png/) ارائه‌ها است.

### **کدام فونت‌ها برای رندرینگ درست لازم هستند؟**

فونت‌های استفاده‌شده در ارائه یا جایگزین‌های مناسب باید در سیستم‌عامل موجود باشند. در Linux و macOS، بسته‌های فونت رایج را نصب کنید تا رندرینگ سازگار باشد.

برای کانتینرهای Alpine Linux، علاوه بر `libgdiplus` حداقل یک بسته فونت نصب کنید. تنظیم پیشنهادی حداقل `libgdiplus` همراه با `ttf-dejavu` است. اگر به فونت‌های مایکروسافت مانند Arial، Times New Roman، Courier New یا Verdana نیاز دارید، از `msttcorefonts-installer` به همراه `fontconfig` استفاده کنید.

### **چرا یک فونت سفارشی به‌عنوان جایگزین یا متن گم‌شده در لینوکس رندر می‌شود؟**

اگر جدول نام‑های فونت فایل ناهماهنگ یا خراب باشد، پشتهٔ تطابق فونت لینوکس (FreeType/fontconfig) ممکن است رکورد نامعتبر را انتخاب کند؛ در نتیجه فونت به‑درستی شناسایی نمی‌شود. استفاده از نسخه‌ای از فونت با جدول نام تصحیح‌شده یا نصب یک جایگزین سازگار این مشکل را رفع می‌کند.