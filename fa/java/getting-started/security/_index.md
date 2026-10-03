---
title: امنیت
type: docs
weight: 160
url: /fa/java/security/
keywords:
- امنیت
- وابستگی‌ها
- مؤلفه‌های شخص ثالث
- Maven
- امضای JAR
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "مروری بر نحوه پردازش ارائه‌ها توسط Aspose.Slides for Java، افزودن آن به وابستگی‌های پروژه شما، نحوه تأیید فایل JAR، و اجزای شخص ثالثی که شامل می‌شود."
---
## **مقدمه**

این مقاله اطلاعاتی را که یک بررسی امنیتی از یک برنامه که از Aspose.Slides for Java استفاده می‌کند معمولاً نیاز دارد، جمع‌آوری می‌کند: نحوه پردازش کتاب‌ها توسط کتابخانه، آنچه به وابستگی‌های پروژه شما اضافه می‌شود، چگونگی بررسی اینکه فایل JAR از Aspose آمده است، و چه اجزای ثالثی در فایل JAR موجود است.

## **امنیت در Aspose.Slides**

* Aspose.Slides for Java برای ایجاد، ویرایش و تبدیل ارائه‌ها استفاده می‌شود. این کتابخانه اسکریپت‌ها را در ارائه‌ها اجرا نمی‌کند. Aspose.Slides ساختار ارائه را تجزیه می‌کند و به کد شما امکان کار با مدل شیء را می‌دهد.
* Aspose.Slides به عنوان کتابخانه‌ای که اسناد را تجزیه و تفسیر می‌کند بدون اجرای کدهای از راه دور عمل می‌کند. تمامی محصولات Aspose بر روی ماشین‌های شما اجرا می‌شوند. آن‌ها هیچ داده‌ای را به Aspose ارسال نمی‌کنند. تنها استثنا [مجوز متره‌ای](/slides/fa/java/metered-licensing/): اگر از آن استفاده کنید، فقط اطلاعات استفاده از API شما پردازش می‌شود.
* مؤلفه‌های Aspose در همان زمینه کاربری که برنامه‌های معمولی اجرا می‌شوند، اجرا می‌شوند. بنابراین، مؤلفه‌های Aspose خطری برای منابع حیاتی سیستم ایجاد نمی‌کنند. علاوه بر این، زمانی که یک مؤلفه Aspose یک سند را باز می‌کند، ماکروها به‌صورت خودکار اجرا نمی‌شوند.

## **وابستگی‌های Maven**

آرتیفکت Maven Aspose.Slides for Java، `com.aspose:aspose-slides`، هیچ وابستگی‌ای اعلام نمی‌کند: فایل POM صرفاً مختصات خود این آرتیفکت را دارد. وقتی آن را به یک پروژه اضافه می‌کنید، Maven تنها این فایل JAR را اضافه می‌کند و هیچ چیز دیگری نیست. برای فهرست‌کردن تمام آرتیفکت‌هایی که پروژه شما حل می‌کند، شامل وابستگی‌های انتقالی، این فرمان را در پوشه پروژه اجرا کنید:

```bash
mvn dependency:tree
```

در پروژه‌ای که از [نصب](/slides/fa/java/installation/) گرفته شده، خروجی Aspose.Slides را به‌عنوان تنها وابستگی فهرست می‌کند:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **تأیید فایل JAR**

Aspose فایل JAR را امضا می‌کند. برای بررسی امضا، ابزار `jarsigner` را از JDK در پوشه‌ای که فایل JAR را دارد اجرا کنید:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

دستور `jar verified.` را چاپ می‌کند وقتی امضا معتبر باشد و هیچ مدخلی از زمان امضای فایل تغییر نکرده باشد. این پیام نام امضا کننده را نشان نمی‌دهد. برای تأیید اینکه Aspose فایل را امضا کرده است، گزینه‌های `-verbose` و `-certs` را اضافه کنید و بررسی کنید که گواهی امضا کننده به `CN=ASPOSE PTY LTD` صادر شده باشد. هنگامی که Maven فایل JAR را دانلود می‌کند، همچنین مجموع بررسی SHA-1 که مخزن در کنار فایل منتشر می‌کند را بررسی می‌نماید.

## **اجزای شخص ثالث**

Aspose.Slides for Java شامل کد و داده‌هایی از اجزای شخص ثالث است. این‌ها بخشی از فایل JAR هستند، نه آرتیفکت‌های جداگانه Maven، بنابراین `mvn dependency:tree` و سایر ابزارهای خواندن وابستگی‌های Maven آن‌ها را فهرست نمی‌کنند. فایل JAR حاوی اعلان *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf* است که اجزا و مجوزهای آن‌ها را فهرست می‌کند:

| کامپوننت | مجوز ذکر شده در اعلان |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT-style license |
| Mono | MIT license; some parts under other licenses that the notice lists |
| RSWOP.ICM color profile | Microsoft license terms |
| sRGB_v4_ICC_preference.icc color profile | ICC permission to use, copy, and distribute the unchanged file |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

برای استخراج اعلان از فایل JAR، ابزار `jar` را از JDK در پوشه‌ای که فایل JAR را دارد اجرا کنید:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **سؤالات متداول**

**آیا Aspose.Slides for Java از بسته‌های خارجی استفاده می‌کند؟**

این کتابخانه هیچ وابستگی Maven ندارد، همان‌طور که [وابستگی‌های Maven](#maven-dependencies) نشان می‌دهد، اما شامل اجزای شخص ثالثی است که در [اجزای شخص ثالث](#third-party-components) فهرست شده‌اند. هر دو فایل JAR و این اجزا را در بررسی امنیتی خود بگنجانید.

**آیا Aspose.Slides for Java به دسترسی به شبکه نیاز دارد؟**

خیر. ایجاد، ذخیره و رندر کردن ارائه‌ها بر روی سیستمی بدون هیچ اتصال شبکه‌ای کار می‌کند. تنها ویژگی که داده‌ها را به Aspose ارسال می‌کند، [مجوز متره‌ای](/slides/fa/java/metered-licensing/) است که استفاده از API را گزارش می‌دهد.

**آیا Aspose.Slides for Java شامل کد بومی است؟**

خیر. فایل JAR فقط شامل کلاس‌ها و منابع Java است، بنابراین کتابخانه‌های بومی به برنامه شما اضافه نمی‌کند. در لینوکس، پشتیبانی فونت‌های زمان اجرای Java به کتابخانه fontconfig و فونت‌های سیستم عامل نیاز دارد؛ برای جزئیات به [نیازمندی‌های سیستم](/slides/fa/java/system-requirements/#linux) مراجعه کنید.