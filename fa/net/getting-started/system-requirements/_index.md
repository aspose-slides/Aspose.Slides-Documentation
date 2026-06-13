---
title: نیازهای سیستم
type: docs
weight: 60
url: /fa/net/system-requirements/
keywords:
- نیازهای سیستم
- سیستم‌عامل
- نصب
- وابستگی‌ها
- ویندوز
- لینوکس
- macOS
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نیازهای سیستم Aspose.Slides برای .NET را کشف کنید. اطمینان حاصل کنید که پشتیبانی یکپارچه PowerPoint و OpenDocument در ویندوز، لینوکس و macOS فراهم است."
---
## **مقدمه**

Aspose.Slides برای .NET نیازی به نصب Microsoft PowerPoint ندارد زیرا Aspose.Slides یک موتور مستقل برای ایجاد، تبدیل، چینش صفحه و رندر اسناد Microsoft PowerPoint است.

## **سیستم‌عامل‌های پشتیبانی‌شده**

Aspose.Slides برای .NET از هر سیستم‌عامل ۳۲‑بیتی یا ۶۴‑بیتی که فریمورک .NET یا Mono نصب شده باشد، پشتیبانی می‌کند، شامل (اما نه محدود به):

### **ویندوز**

- Microsoft Windows 2000 Server ( x64، x86)
- Microsoft Windows 2003 Server ( x64، x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64، x86)
- Microsoft Windows XP ( x64، x86)
- Microsoft Windows 7 ( x64، x86)
- Microsoft Windows 8، 8.1 ( x64، x86)
- Microsoft Windows 10 ( x64، x86)
- Microsoft Windows 11 ( x64، x86)
- Microsoft Azure

### **لینوکس**

- Linux (Ubuntu، OpenSUSE، CentOS، Alpine و سایر توزیع‌ها)

### **مک**

- Mac OS X

## **فریمورک‌های پشتیبانی‌شده**

Aspose.Slides برای .NET از فریمورک‌های .NET و Mono پشتیبانی می‌کند:

### **فریمورک‌های .NET**

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
- پشتیبانی COM Interop (COM، C++، VBScript)

### **فریمورک Mono**

- پشتیبانی MONO در پلتفرم‌های MAC و Linux

## **محیط‌های توسعه**

Aspose.Slides برای .NET می‌تواند در هر محیط توسعه‌ای که هدف آن پلتفرم .NET است استفاده شود، اما این محیط‌ها صریحاً پشتیبانی می‌شوند:

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
- در پلتفرم‌های غیر ویندوز، ممکن است نیاز باشد کتابخانه `libgdiplus` و وابستگی‌های آن را نصب کنید.
- پیش از نسخه Aspose.Slides 25.3، برای پلتفرم‌های غیر ویندوز لازم بود DLL استاندارد .NET Standard 2.0 از بسته ZIP Aspose.Slides استفاده شود.
- از نسخه Aspose.Slides 25.3 به بعد، بسته NuGet می‌تواند مستقیماً حتی در سیستم‌های غیر ویندوز مورد استفاده قرار گیرد.
- هنگام اجرا در سیستم‌های غیر ویندوز، برنامه شما باید خط زیر را در زمان شروع گنجانده باشد:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **از نسخه 25.3 به بعد، می‌توانید این بسته را بر روی پلتفرم‌هایی که .NET را پشتیبانی می‌کنند، مانند Linux aarch64 (ARM64) استفاده کنید.**

#### **بسته‌های اضافی برای Alpine Linux**

هنگام اجرای Aspose.Slides برای .NET در یک کانتینر Alpine Linux، نصب تنها `libgdiplus` ممکن است کافی نباشد. کانتینرهای Alpine معمولاً به‌طور پیش‌فرض فونت ندارند. اگر فونتی موجود نباشد، عملیات رندر یا تبدیل ممکن است با خطایی مشابه زیر شکست بخورد:

```text
System.ArgumentException: Font '?' cannot be found
```
برای استفاده از Aspose.Slides بر روی Alpine، `libgdiplus` را همراه با حداقل یک بسته فونت نصب کنید.

**گزینه 1: فونت‌های DejaVu**

گزینه پیشنهادی نصب بسته `ttf-dejavu` است:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

بسته `ttf-dejavu` به‌طور خودکار وابستگی‌های مربوط به فونت مانند `fontconfig`، `encodings`، `mkfontscale` و `mkfontdir` را نصب می‌کند. برای اکثر موارد دیگر نیازی به بسته فونت اضافی نیست.

**گزینه 2: Microsoft Core Fonts**

اگر ارائه‌های شما از فونت‌های خاص مایکروسافت مانند Arial، Times New Roman، Courier New یا Verdana استفاده می‌کنند، به‌جای آن می‌توانید Microsoft Core Fonts را نصب کنید:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

از این گزینه فقط زمانی استفاده کنید که ارائه‌های پردازش‌شده به فونت‌های مایکروسافت نیاز داشته باشند. برای اکثر سناریوها نصب `ttf-dejavu` ساده‌تر و قابل اعتمادتر است.

### **[Aspose.Slides برای .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

این نسخه از Aspose.Slides است که از یک موتور گرافیکی سفارشی چندپلتفرمی استفاده می‌کند که توسط تیم Aspose.Slides توسعه یافته است.  
در پلتفرم‌های غیر ویندوز، ممکن است کتابخانه `fontconfig` مورد نیاز باشد.

**پلتفرم‌های پشتیبانی‌شده**
- *Windows*: x86، x86_64  
- *Linux*: x86_64، ARM64 (aarch64)
- *macOS*: x86_64، ARM64 (aarch64)

**پلتفرم‌های نامپشتیبانی‌شده**
- *Windows 11 ARM* (ARM64) — *در حال حاضر در نظر گرفته نشده است*

{{%  alert  title="Notes"  color="primary"  %}}  
برای Linux x64، نیاز به GLIBC 2.23+ است؛ برای Linux ARM64، نیاز به GLIBC 2.39+ است. سیستم‌هایی مانند CentOS 7 (GLIBC 2.14) پشتیبانی نمی‌شوند. اگر نیاز به اجرای Aspose.Slides بر روی CentOS 7 یا سیستم‌های ناسازگار دیگر (مثلاً Alpine) دارید، لطفاً از بسته استاندارد استفاده کنید: [Aspose.Slides برای .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **پرسش‌های متداول**

**آیا برای تبدیل و رندر کردن نیاز به نصب Microsoft PowerPoint دارم؟**

نه، نیازی به PowerPoint نیست؛ Aspose.Slides یک موتور مستقل برای [ایجاد](/slides/fa/net/create-presentation/)، اصلاح، [تبدیل](/slides/fa/net/convert-presentation/) و [رندر](/slides/fa/net/convert-powerpoint-to-png/) ارائه‌ها است.

**برای رندر صحیح به چه فونت‌هایی نیاز است؟**

فونت‌های استفاده‌شده در ارائه یا جایگزین‌های مناسب باید در سیستم‌عامل موجود باشند. در Linux و macOS، بسته‌های فونت رایج را نصب کنید تا رندر یکنواخت باشد.

برای کانتینرهای Alpine Linux، علاوه بر `libgdiplus` حداقل یک بسته فونت نصب کنید. تنظیمات حداقلی پیشنهادی `libgdiplus` به همراه `ttf-dejavu` است. اگر به فونت‌های مایکروسافت مانند Arial، Times New Roman، Courier New یا Verdana نیاز دارید، از `msttcorefonts-installer` همراه با `fontconfig` استفاده کنید.

**چرا یک فونت سفارشی در Linux به‌عنوان جایگزین یا متن گمشده نمایش داده می‌شود؟**

اگر ورودی‌های جدول name در فایل فونت ناهمگن یا خراب باشند، لایهٔ مطابقت فونت در Linux (FreeType/fontconfig) ممکن است رکورد نامعتبر را انتخاب کند و باعث عدم شناسایی فونت شود. استفاده از نسخه‌ای از فونت با رکوردهای نام اصلاح‌شده یا نصب یک جایگزین سازگار این مشکل را برطرف می‌کند.