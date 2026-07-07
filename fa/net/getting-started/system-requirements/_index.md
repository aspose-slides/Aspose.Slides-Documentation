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
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نیازمندی‌های سیستم Aspose.Slides برای .NET را کشف کنید. پشتیبانی یکپارچه از PowerPoint و OpenDocument را بر روی ویندوز، لینوکس و macOS تضمین کنید."
---
## **مقدمه**

Aspose.Slides for .NET نیازی به نصب Microsoft PowerPoint ندارد زیرا Aspose.Slides یک موتور مستقل برای ایجاد، تبدیل، چیدمان صفحه و رندر اسناد Microsoft PowerPoint است.

## **سیستم‌عامل‌های پشتیبانی‌شده**

Aspose.Slides for .NET از هر سیستم‌عامل 32‑bit یا 64‑bit که چارچوب .NET یا Mono نصب شده باشد پشتیبانی می‌کند، از جمله (اما نه محدود به):

### **ویندوز**

- Microsoft Windows 2000 Server (x64, x86)
- Microsoft Windows 2003 Server (x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)
- Microsoft Windows 11 (x64, x86)
- Microsoft Azure

### **لینوکس**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine, و دیگران)

### **مک**

- Mac OS X

## **چارچوب‌های پشتیبانی‌شده**

Aspose.Slides for .NET از چارچوب‌های .NET و Mono پشتیبانی می‌کند:

### **چارچوب‌های .NET**

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

### **چارچوب Mono**

- پشتیبانی MONO در پلتفرم‌های MAC و Linux

## **محیط‌های توسعه**

Aspose.Slides for .NET می‌تواند در هر محیط توسعه‌ای که هدف آن پلتفرم .NET است، برنامه‌ها را توسعه دهد، اما این محیط‌ها صریحاً پشتیبانی می‌شوند:

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

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

این نسخه اصلی محصول است. از موتور گرافیک استاندارد .NET استفاده می‌کند.
- در بسترهای غیر‑ویندوز ممکن است نیاز به نصب کتابخانه `libgdiplus` و وابستگی‌های آن داشته باشید.
- پیش از نسخه Aspose.Slides 25.3، برای بسترهای غیر‑ویندوز لازم بود DLL استاندارد .NET 2.0 را از بسته ZIP Aspose.Slides استفاده کنید.
- از نسخه Aspose.Slides 25.3 به بعد، می‌توانید بسته NuGet را مستقیماً حتی در سیستم‌های غیر‑ویندوز استفاده کنید.
- هنگام اجرا در سیستم‌های غیر‑ویندوز، برنامه شما باید خط زیر را در زمان راه‌اندازی گنجانده باشد:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **از نسخه 25.3 به بعد می‌توانید این بسته را بر روی پلتفرم‌هایی که .NET را پشتیبانی می‌کنند، مانند Linux aarch64 (ARM64) استفاده کنید.**

#### **پکیج‌های اضافی برای لینوکس Alpine**

زمانی که Aspose.Slides for .NET را در یک کانتینر Alpine Linux اجرا می‌کنید، نصب تنها `libgdiplus` ممکن است کافی نباشد. کانتینرهای Alpine معمولاً به‌صورت پیش‌فرض شامل فونت نیستند. اگر فونتی در دسترس نباشد، عملیات رندر یا تبدیل ممکن است با خطایی مشابه زیر با شکست مواجه شود:

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

بسته `ttf-dejavu` به‌طور خودکار وابستگی‌های مربوط به فونت مانند `fontconfig`، `encodings`، `mkfontscale` و `mkfontdir` را نصب می‌کند. برای اکثر موارد دیگر بسته فونت اضافی لازم نیست.

**گزینه 2: فونت‌های اصلی Microsoft**

اگر ارائه‌های شما از فونت‌های خاص Microsoft مانند Arial، Times New Roman، Courier New یا Verdana استفاده می‌کنند، به‌جای آن از Microsoft Core Fonts نصب کنید:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

از این گزینه فقط زمانی استفاده کنید که ارائه‌های پردازش‌شده به فونت‌های Microsoft نیاز داشته باشند. برای اکثر سناریوها نصب `ttf-dejavu` ساده‌تر و قابل‌اعتمادتر است.

**نیازمندی‌های اضافی برای جهانی‌سازی**

برای فعال‌سازی پشتیبانی مناسب جهانی‌سازی در Alpine، بسته `icu-libs` را نصب کرده و حالت invariant را غیرفعال کنید:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

این نسخه از Aspose.Slides است که از یک موتور گرافیک سفارشی چندپلتفرمی توسعه‌یافته توسط تیم Aspose.Slides استفاده می‌کند.  
در بسترهای غیر‑ویندوز ممکن است کتابخانه `fontconfig` مورد نیاز باشد.

**پلتفرم‌های پشتیبانی‌شده**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**پلتفرم‌های پشتیبانی‌نشده**
- *Windows 11 ARM* (ARM64) — *در حال حاضر در نظر گرفته نشده*

{{%  alert  title="Notes"  color="primary"  %}}  
برای لینوکس x64، GLIBC 2.23+ مورد نیاز است؛ برای لینوکس ARM64، GLIBC 2.39+ مورد نیاز است. سیستم‌هایی مانند CentOS 7 (GLIBC 2.14) پشتیبانی نمی‌شوند. اگر نیاز به اجرای Aspose.Slides بر روی CentOS 7 یا سایر سیستم‌های ناسازگار (مثلاً Alpine) دارید، لطفاً از بسته استاندارد استفاده کنید: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **سوالات متداول**

**آیا برای تبدیل و رندر کردن به Microsoft PowerPoint نیاز دارم؟**

خیر، PowerPoint مورد نیاز نیست؛ Aspose.Slides یک موتور مستقل برای [ایجاد](/slides/fa/net/create-presentation/)، ویرایش، [تبدیل](/slides/fa/net/convert-presentation/)، و [رندر](/slides/fa/net/convert-powerpoint-to-png/) ارائه‌ها است.

**کدام فونت‌ها برای رندر صحیح لازم هستند؟**

فونت‌های استفاده‌شده در ارائه، یا جایگزین‌های مناسب، باید در سیستم‌عامل موجود باشند. در لینوکس و macOS، برای اطمینان از رندر یکسان، پکیج‌های فونت متداول را نصب کنید.

برای کانتینرهای Alpine Linux، حداقل یک بسته فونت علاوه بر `libgdiplus` نصب کنید. تنظیمات پیشنهادی حداقل شامل `libgdiplus` به همراه `ttf-dejavu` است. اگر فونت‌های Microsoft مانند Arial، Times New Roman، Courier New یا Verdana لازم باشند، از `msttcorefonts-installer` همراه با `fontconfig` استفاده کنید.

**چرا یک فونت سفارشی به‌عنوان بازگشتی یا متن مفقود در لینوکس رندر می‌شود؟**

اگر جدول نام‌های فایل فونت ناسازگار یا خراب باشد، لایهٔ مطابقت فونت لینوکس (FreeType/fontconfig) ممکن است رکورد نامعتبر را انتخاب کند و باعث عدم شناسایی فونت شود. استفاده از نسخه‌ای از فونت با رکوردهای نام‌جدول اصلاح‌شده یا نصب یک جایگزین سازگار این مشکل را رفع می‌کند.