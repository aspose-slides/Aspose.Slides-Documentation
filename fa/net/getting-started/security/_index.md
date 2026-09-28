---
title: امنیت
type: docs
weight: 160
url: /fa/net/security/
keywords:
- امنیت
- وابستگی‌ها
- اجزای شخص ثالث
- NuGet
- اسکن آسیب‌پذیری
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بررسی کنید Aspose.Slides برای .NET چگونه ارائه‌ها را پردازش می‌کند، بسته‌های NuGet که برای هر چارچوب هدف به آن وابسته است، و اجزای شخص ثالثی که شامل می‌شود."
---
## **امنیت در Aspose.Slides**

Aspose بهترین روش‌ها را هنگام توسعه محصولات خود اعمال می‌کند.

* Aspose.Slides برای .NET برای دستکاری ارائه‌ها و تبدیل آن‌ها به سایر فرمت‌ها استفاده می‌شود. این ابزار اسکریپت‌ها را در ارائه‌ها اجرا نمی‌کند. Aspose.Slides ساختار ارائه را تجزیه می‌کند و به کد کاربر نهایی اجازه می‌دهد مدل شیء را به روشی راحت دستکاری کند.
* Aspose.Slides به عنوان کتابخانه‌ای عمل می‌کند که اسناد را بدون اجرای کدهای راه دور تجزیه و تفسیر می‌کند. تمام محصولات Aspose بر روی ماشین‌های شما اجرا می‌شوند. آنها هیچ داده‌ای را به Aspose منتقل نمی‌کنند. تنها استثنا یک [مجوز متری](https://purchase.aspose.com/faqs/licensing/metered) است: اگر از آن استفاده کنید، تنها اطلاعات استفاده از API شما پردازش می‌شود.
* مؤلفه‌های Aspose در همان زمینه کاربری برنامه‌های عادی اجرا می‌شوند. بنابراین، مؤلفه‌های Aspose خطری برای منابع حیاتی سیستم ایجاد نمی‌کنند. علاوه بر این، وقتی یک مؤلفه Aspose سندی را باز می‌کند، ماکروها به‌صورت خودکار اجرا نمی‌شوند.
* خطرات ذاتی یا مرتبط با بسته Microsoft Office بر مؤلفه‌های Aspose اعمال نمی‌شود، بنابراین محصولات Aspose بسیار امن هستند.

## **وابستگی‌های NuGet**

Aspose.Slides برای .NET به بسته‌هایی که مایکروسافت در NuGet منتشر می‌کند وابسته است. وابستگی‌ها بر حسب بسته و چارچوب هدف متفاوت هستند:

| بسته | چارچوب هدف | وابستگی‌ها |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

بخش **Dependencies** در صفحات [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) و [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) در NuGet نسخهٔ حداقل هر وابستگی را برای هر انتشار فهرست می‌کند.

هنگامی که Aspose.Slides را به یک پروژه اضافه می‌کنید، NuGet همچنین وابستگی‌های این بسته‌ها را بازگردانده (restore) می‌کند. برای فهرست کردن هر بسته‌ای که پروژه شما بازگردانی می‌کند، از جمله این وابستگی‌های انتقالی، این فرمان را در پوشهٔ پروژه اجرا کنید:

```bash
dotnet list package --include-transitive
```

برای بررسی همان مجموعهٔ بسته‌ها در مقابل آسیب‌پذیری‌های شناخته‌شده، اجرا کنید:

```bash
dotnet list package --vulnerable --include-transitive
```

برای روش‌های دیگر بررسی بسته‌های NuGet، به [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages) مراجعه کنید.

## **اجزای شخص ثالث**

Aspose.Slides شامل کدی از اجزای متن‌باز شخص ثالث است. این‌ها بخشی از محصول هستند، نه بسته‌های جداگانهٔ NuGet، بنابراین ابزارهایی که فقط وابستگی‌های NuGet را می‌خوانند، آن‌ها را فهرست نمی‌کنند. هر دو بسته شامل فایل *thirdpartylicenses.Aspose.Slides.for.NET.pdf* هستند که اجزا و مجوزهای آن‌ها را فهرست می‌کند:

| اجزا | مجوز ذکر شده در اطلاعیه |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **سوالات متداول**

**چه سیستم‌هایی برای نظارت بر آسیب‌پذیری‌ها در کد Aspose استفاده می‌شود؟**

ما برای هر انتشار Aspose.Slides تجزیه و تحلیل کد ایستای (static) انجام می‌دهیم. می‌توانیم گزارش‌های امنیتی ارائه کنیم که نشان می‌دهد کد Aspose.Slides الزامات OWASP Top 10 را پاس می‌کند.

**آیا Aspose.Slides از بسته‌های خارجی استفاده می‌کند؟**

بله. این ابزار به بسته‌های NuGet مایکروسافت اشاره شده در [NuGet Dependencies](#nuget-dependencies) وابسته است و شامل اجزای شخص ثالث ذکر شده در [Third-Party Components](#third-party-components) می‌شود. هر دو را در بررسی امنیتی خود بگنجانید و از `dotnet list package --vulnerable --include-transitive` برای بررسی بسته‌های NuGet که پروژه شما بازگردانی می‌کند استفاده کنید.