---
title: بستهٔ چند پلتفرمی برای .NET 6 و بالاتر
linktitle: بستهٔ چند پلتفرمی
type: docs
weight: 235
url: /fa/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- "چند-پلتفرمی"
- "پشتیبانی از .NET 6"
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چه زمانی باید بستهٔ Aspose.Slides.NET6.CrossPlatform را استفاده کنید: دلیل وجود آن، پلتفرم‌هایی که اجرا می‌شود و نیازهای آن در لینوکس به جای libgdiplus."
---
## **مقدمه**

Aspose.Slides برای .NET به‌صورت دو بسته NuGet منتشر می‌شود. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) اسلایدها را از طریق کتابخانه System.Drawing.Common مایکروسافت ترسیم می‌کند. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) به‌جای آن با موتور گرافیکی خود ترسیم می‌کند. این مقاله توضیح می‌دهد که چرا بسته دوم وجود دارد، کجا اجرا می‌شود، برای لینوکس چه نیازهایی دارد و چگونه همراه با System.Drawing.Common در یک پروژه مشترک می‌شود.

## **چرا یک بسته جداگانه**

از .NET 6 به بعد، مایکروسافت از System.Drawing.Common [فقط در ویندوز](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only) پشتیبانی می‌کند. در نتیجه، در لینوکس Aspose.Slides.NET به سوئیچ `System.Drawing.EnableUnixSupport` علاوه بر کتابخانه `libgdiplus` نیاز دارد و اگر پروژه System.Drawing.Common نسخه 7 یا بالاتر را ارجاع دهد، در آنجا شکست می‌خورد. [System Requirements](/slides/fa/net/system-requirements/) این شرایط را توصیف می‌کند.

Aspose.Slides.NET6.CrossPlatform از System.Drawing.Common یا `libgdiplus` استفاده نمی‌کند. موتور گرافیکی آن کتابخانهٔ بومی است که بسته در هر پلتفرم پشتیبانی‌شده یک بیلد را در خود دارد. هر دو بسته فضای‌نام‌ها و کلاس‌های Aspose.Slides را یکسان ارائه می‌دهند، بنابراین تغییر از یکی به دیگری تنها مرجع بسته را تغییر می‌دهد، نه کد شما.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| گرافیک | System.Drawing.Common | موتور گرافیکی بومی که در بسته گنجانده شده است |
| فریم‌ورک‌های هدف | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| نیازمندی‌های لینوکس | `libgdiplus` و سوئیچ `System.Drawing.EnableUnixSupport` | `fontconfig` |
| Alpine Linux | پشتیبانی می‌شود | پشتیبانی نمی‌شود |

## **پلتفرم‌های پشتیبانی‌شده**

Aspose.Slides.NET6.CrossPlatform با .NET 6 و نسخه‌های بعدی بر روی این پلتفرم‌ها کار می‌کند:

- **Windows**: x86 و x64. کتابخانه بومی از زمان اجرا Microsoft Visual C++ استفاده می‌کند؛ ببینید [System Requirements](/slides/fa/net/system-requirements/).
- **Linux**: x64 با glibc 2.23 یا بالاتر، و ARM64 با glibc 2.39 یا بالاتر.
- **macOS**: x64 (Intel) و ARM64 (سیلیکون اپل).

این بسته بر روی Windows ARM64، روی Alpine Linux یا دیگر توزیع‌هایی که بر پایه musl به‌جای glibc ساخته شده‌اند، یا توزیع‌هایی با glibc قدیمی‌تر مانند CentOS 7 اجرا نمی‌شود. در آن سیستم‌ها از Aspose.Slides.NET استفاده کنید.

## **نصب بر روی لینوکس**

در لینوکس، بسته به کتابخانه `fontconfig` نیاز دارد، اما به `libgdiplus` نیازی نیست. در Debian و Ubuntu، `fontconfig` را نصب کنید و سپس بسته را به پروژه‌تان اضافه کنید:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

در Debian و Ubuntu، `libfontconfig1` همچنین فونت‌های DejaVu را نصب می‌کند، بنابراین متن بدون بسته‌های فونت اضافی رندر می‌شود. بدون `fontconfig`، ایجاد یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) با `TypeInitializationException` که `DllNotFoundException` داخلی آن گزارش می‌دهد `libfontconfig.so.1` باز نشد، شکست می‌خورد. [System Requirements](/slides/fa/net/system-requirements/) برنامهٔ کوتاهی شامل می‌شود که تنظیمات را بررسی می‌کند.

## **پلتفرم‌های ابری و میزبانی کانتینر**

به‌دلیل عدم نیاز به `libgdiplus`، Aspose.Slides.NET6.CrossPlatform بسته‌ای است که در میزبانی‌های لینوکس که نمی‌توانید `libgdiplus` نصب کنید، استفاده می‌شود. همچنان به `fontconfig` و فونت‌ها نیاز دارد، که ممکن است در تصویرهای پایهٔ حداقل موجود نباشند. برای مثال، تصویر پایهٔ AWS Lambda برای .NET 8 هیچ‌یک از آن‌ها را شامل نمی‌شود. در یک تصویر کانتینر ساخته‌شده بر پایهٔ آن، دستور `dnf install -y fontconfig` را اجرا کنید که همچنین فونت‌های Noto Sans را نصب می‌کند.

برای راهنماهای مربوط به پلتفرم‌های ابری خاص، به [Aspose.Slides on Cloud Platforms](/slides/fa/net/slides-on-cloud-platforms/) مراجعه کنید.

## **استفاده از System.Drawing.Common در همان پروژه (CS0433)**

پروژه‌ای که از Aspose.Slides.NET6.CrossPlatform استفاده می‌کند می‌تواند همچنین System.Drawing.Common را مستقیماً یا از طریق بستهٔ دیگری ارجاع دهد. نسخهٔ فعلی Aspose.Slides هیچ نوع عمومی در فضاهای‌نام `System` ارائه نمی‌دهد، بنابراین دو کتابخانه تداخل ندارند و می‌توانید فضای‌نام‌های `Aspose.Slides` و `System.Drawing` را در یک فایل وارد کنید.

اگر کامپایر خطای CS0433 را گزارش دهد زیرا نوعی مانند `Image` یا `Graphics` هم در Aspose.Slides و هم در System.Drawing.Common وجود دارد، پروژهٔ شما از نسخهٔ قدیمی Aspose.Slides استفاده می‌کند. بسته را به آخرین نسخه به‌روز کنید. Aspose.Slides تصاویر رندر شده را به‌صورت اشیای [IImage](https://reference.aspose.com/slides/fa/net/aspose.slides/iimage/) برمی‌گرداند که در [Modern API](/slides/fa/net/modern-api/) توصیف شده‌اند.

## **سوالات متداول**

**آیا هنگام تغییر از Aspose.Slides.NET به Aspose.Slides.NET6.CrossPlatform نیاز به تغییر کد دارم؟**

خیر. هر دو بسته همان فضاهای‌نام و کلاس‌های Aspose.Slides را ارائه می‌دهند، بنابراین فقط مرجع بسته را تعویض می‌کنید. Aspose.Slides.NET6.CrossPlatform به سوئیچ `System.Drawing.EnableUnixSupport` نیازی ندارد. فقط یکی از دو بسته را به پروژه اضافه کنید.

**آیا می‌توانم Aspose.Slides.NET6.CrossPlatform را در یک پروژهٔ .NET Framework استفاده کنم؟**

خیر. این بسته فقط برای .NET 6 و نسخه‌های بعدی هدف‌گذاری شده است. برای .NET Framework 4.6.2 و بالاتر، از Aspose.Slides.NET استفاده کنید.