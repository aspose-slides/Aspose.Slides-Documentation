---
title: نصب
type: docs
weight: 70
url: /fa/net/installation/
keywords:
- نصب Aspose.Slides
- دریافت Aspose.Slides
- استفاده از Aspose.Slides
- نصب Aspose.Slides
- ویندوز
- لینوکس
- macOS
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides برای .NET را از NuGet بر روی ویندوز، لینوکس و macOS نصب کنید: بین دو بسته انتخاب کنید، یکی را با .NET CLI یا Visual Studio اضافه کنید و پیش‌نیازهای لینوکس را نصب کنید."
---
## **بررسی کلی**

این مقاله نحوه افزودن Aspose.Slides for .NET به یک پروژه در Windows، Linux و macOS را توضیح می‌دهد. Aspose.Slides از طریق NuGet توزیع می‌شود. می‌توانید آن را با .NET CLI در هر سیستم‌عامل یا با NuGet Package Manager یا Package Manager Console در Visual Studio در Windows اضافه کنید. مقاله همچنین توضیح می‌دهد کدام یک از دو بسته NuGet را انتخاب کنید و لینوکس به چه مواردی نیاز دارد.

قبل از نصب، سیستم‌عامل‌های پشتیبانی‌شده، پیاده‌سازی‌های .NET و وابستگی‌های اضافی را در [الزامات سیستم](/slides/fa/net/system-requirements/) مرور کنید.

## **انتخاب بسته**

Aspose.Slides for .NET به صورت دو بسته NuGet منتشر می‌شود. هر دو فضای‌نام و کلاس‌های Aspose.Slides یکسان را ارائه می‌دهند، بنابراین کد شما هنگام جابجایی بین آن‌ها تغییر نمی‌کند؛ فقط مرجع بسته و نیازمندی‌های پلتفرم متفاوت است.

| بسته | برای استفاده | نیازمندی‌های اضافی |
|---|---|---|
| [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) | برنامه‌های Windows و .NET Framework | در Linux و macOS: کتابخانه `libgdiplus` و سوئیچ `System.Drawing.EnableUnixSupport` که در زمان راه‌اندازی برنامه فعال باشد |
| [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) | .NET 6 یا بالاتر در Windows، Linux و macOS | در Linux: کتابخانه `fontconfig`، اگر قبلاً نصب نشده باشد |

اگر مطمئن نیستید، در Windows از Aspose.Slides.NET و در Linux و macOS از Aspose.Slides.NET6.CrossPlatform استفاده کنید. در Alpine Linux و در سیستم‌های لینوکس که glibc آن‌ها قدیمی‌تر از 2.23 (x64) یا 2.39 (ARM64) باشد، از Aspose.Slides.NET استفاده کنید. [الزامات سیستم](/slides/fa/net/system-requirements/) پلتفرم‌های پشتیبانی‌شده هر بسته را فهرست می‌کند.

## **نصب با .NET CLI**

این مراحل در Windows، Linux و macOS با .NET SDK 6 یا بالاتر کار می‌کند. یک برنامه کنسولی ایجاد کنید:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

سپس بسته متناسب با پلتفرم خود را اضافه کنید. فقط یکی از دو بسته را به پروژه اضافه کنید.

- در Windows: `dotnet add package Aspose.Slides.NET`
- در Linux و macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` (در Linux، پیش‌نیاز آن را ابتدا نصب کنید؛ ببینید [Linux](#linux))

برای اطمینان از کارکرد بسته، محتویات *Program.cs* را با اولین مثال در [Create Presentations](/slides/fa/net/create-presentation/) جایگزین کنید و `dotnet run` را اجرا کنید. این کار فایل *hello.pptx* را در پوشه پروژه ذخیره می‌کند.

## **ویندوز**

### **روش ۱: نصب یا به‌روزرسانی Aspose.Slides از NuGet Package Manager**

1. Microsoft Visual Studio را باز کنید.
2. یک برنامه کنسولی ایجاد کنید یا پروژه موجود را باز کنید.
3. در **Solution Explorer**، روی پروژه راست‌کلیک کنید و **Manage NuGet Packages** را انتخاب کنید (یا به **Project** > **Manage NuGet Packages** بروید).
4. در **Browse**، به دنبال *Aspose.Slides* بگردید.
{{% image img="installation_1.png" alt="نصب Aspose.Slides از NuGet Package Manager - 1" %}}
5. **Aspose.Slides.NET** را انتخاب کنید و سپس روی **Install** کلیک کنید.  
   * اگر قبلاً Aspose.Slides را نصب کرده‌اید و می‌خواهید آن را به‌روزرسانی کنید، به‌جای آن روی **Update** کلیک کنید.

بسته دانلود شده و در پروژه شما مرجع می‌شود.

### **روش ۲: نصب یا به‌روزرسانی Aspose.Slides از طریق Package Manager Console**

این روش نشان می‌دهد چگونه بسته [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) را از طریق Package Manager Console مرجع کنید:

1. Microsoft Visual Studio را باز کنید.
2. یک برنامه کنسولی ایجاد کنید یا پروژه موجود را باز کنید.
3. به **Tools** > **NuGet Package Manager** > **Package Manager Console** بروید.
![باز کردن Package Manager Console](installation_2.png)
4. این فرمان را اجرا کنید: `Install-Package Aspose.Slides.NET`
![اجرای فرمان Install-Package](installation_3.png)
آخرین نسخه در پروژه شما نصب می‌شود.

پیغام **Installing Aspose.Slides.NET** در نزدیکی پایین پنجره ظاهر می‌شود.
![پیشرفت نصب در Package Manager Console](installation_4.png)

پس از تکمیل دانلود، پیام‌های تأیید ظاهر می‌شوند. بسته تحت [Aspose EULA](https://about.aspose.com/legal/eula) منتشر شده است.
![پیام‌های تأیید نصب](installation_5.png)

Aspose.Slides اکنون به پروژه شما اضافه و مرجع شده است.
![Aspose.Slides در پروژه مرجع شده](installation_6.png)

برای به‌روزرسانی بسته، در Package Manager Console `Update-Package Aspose.Slides.NET` را اجرا کنید.

## **لینوکس**

از مراحل .NET CLI بالا استفاده کنید. بسته را انتخاب کنید و پیش‌نیاز آن را با مدیر بسته توزیع خود نصب کنید. در Debian و Ubuntu:

- **Aspose.Slides.NET6.CrossPlatform**: `fontconfig` را نصب کنید.

  ```bash
  sudo apt-get update && sudo apt-get install -y libfontconfig1
  dotnet add package Aspose.Slides.NET6.CrossPlatform
  ```

- **Aspose.Slides.NET**: `libgdiplus` را نصب کنید و پیش از استفاده از Aspose.Slides، پشتیبانی Unix برای System.Drawing را فعال کنید.

  ```bash
  sudo apt-get update && sudo apt-get install -y libgdiplus
  dotnet add package Aspose.Slides.NET
  ```

این دستور را در ابتدا، قبل از هر فراخوانی Aspose.Slides، اضافه کنید. در *Program.cs* با دستورات سطح‑بالا (top‑level statements)، آن را پس از دستورات `using` قرار دهید:

```c#
  System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
  ```

از این بسته در Alpine Linux و در سیستم‌هایی که glibc آن‌ها برای Aspose.Slides.NET6.CrossPlatform خیلی قدیمی است، استفاده کنید.

فونت‌های مورد استفاده در ارائه‌های شما یا جایگزین‌های مناسب آن‌ها باید روی سیستم نصب شوند تا متن به‌درستی رندر شود. [الزامات سیستم](/slides/fa/net/system-requirements/) بسته‌های مورد نیاز Aspose.Slides.NET در Alpine Linux را شامل فونت‌ها توضیح می‌دهد.

## **macOS**

از مراحل .NET CLI بالا با بسته **Aspose.Slides.NET6.CrossPlatform** استفاده کنید که از هر دو Mac Intel (x86_64) و Apple silicon (ARM64) پشتیبانی می‌کند:

```bash
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

## **سوالات متداول**

**آیا نسخه رایگان یا محدودیت آزمایشی وجود دارد؟**

بله. بدون داشتن لایسنس، Aspose.Slides در حالت ارزیابی اجرا می‌شود: برای هر اسلایدی که ذخیره می‌کند، یک واترمارک ارزیابی اضافه می‌کند و متن خوانده‌شده از ارائه‌ها را قطع می‌کند. برای حذف این محدودیت‌ها، یک [لایسنس](/slides/fa/net/licensing/) معتبر اعمال کنید.