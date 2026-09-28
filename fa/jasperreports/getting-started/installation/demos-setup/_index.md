---
title: راه‌اندازی دموی‌ها
type: docs
weight: 70
url: /fa/jasperreports/demos-setup/
description: "پروژه‌های دموی موجود در دانلود Aspose.Slides for JasperReports را تنظیم کنید، کلاس خروجی‌گیر مورد استفاده آن‌ها را تغییر دهید و با Ant بسازید."
---
## **Demoها چه هستند**

پوشه *samples* در دانلود Aspose.Slides for JasperReports شامل هشت پروژه دموی است: *charts*، *fonts*، *images*، *landscape*، *shapes*، *subreport*، *text* و *xmldatasource*. این‌ها دموی استاندارد JasperReports هستند که برای اضافه کردن هدف ساخت `ppt` تغییر یافته‌اند تا گزارش پر شده را به PPT صادر کنند. دانلود شامل ارائه‌های صادر شده‌ای نیست؛ شما آنها را با ساخت یک دموی خاص ایجاد می‌کنید.

## **قبل از ساخت کلاس خروجی‌گیر را تغییر دهید**

به‌صورت پیش‌فرض، کدهای جاوای دموا از `com.aspose.slides.jasperreports.JRPptExporter` استفاده می‌کنند، کلاسی که در jarهای فعلی موجود نیست، بنابراین دموا کامپایل نمی‌شوند. در کلاس برنامه دموی مربوطه (به عنوان مثال *ShapesApp.java* در دموی *shapes*) `JRPptExporter` را با `ASPptExporter`، خروجی‌گیر PPT در همان بسته، جایگزین کنید. دموی *fonts* تمام بسته را ایمپورت می‌کند، بنابراین فقط نام کلاس در کد آن تغییر می‌یابد.

دموا همچنین از کلاس‌های JasperReports استفاده می‌کنند که در نسخه‌های بعدی حذف شده‌اند، مانند `JExcelApiExporter` و `JRExporterParameter.FONT_MAP`. با تغییر بالا، دموا به شکل زیر کامپایل می‌شوند:

| نسخه JasperReports | دمواهای قابل کامپایل |
| :- | :- |
| 5.5.1 | همه هشت |
| 5.5.2 و 6.4.0 | *charts*، *images*، *landscape*، *shapes* و *xmldatasource* |
| 6.16.0 | *charts* |

## **ساخت یک دموی**

هر *build.xml* دموی موردنظر انتظار دارد ساختار پوشه‌ای یک پروژه JasperReports باشد: نسبت به پوشه دموی، با *../../../build/classes* و jarهای موجود در *../../../lib* کامپایل می‌شود.

1. پوشه دموی موردنظر را به *demo/samples* در پوشه پروژه JasperReports خود کپی کنید.
2. فایل *aspose.slides.jasperreports.library-xx.x.jar* را از زیرپوشه *lib* دانلود که با نسخه JasperReports شما منطبق است، به پوشه *lib* پروژه JasperReports منتقل کنید. برای جزئیات بیشتر به [Installing Aspose.Slides for JasperReports](/slides/fa/jasperreports/installing-aspose-slides-for-jasperreports/) مراجعه کنید.
3. jar نسخه JasperReports خود و jarهای مورد نیاز آن را در همان پوشه *lib* قرار دهید. علاوه بر فایل‌های دموی، *build.xml* تنها *build/classes* و jarهای زیر پوشه *lib* را در مسیر کلاس قرار می‌دهد و *build/classes* پس از کامپایل سورس JasperReports فقط شامل کلاس‌های JasperReports می‌شود.
4. دمواهای *charts*، *subreport* و *text* پایگاه داده نمونه HSQLDB JasperReports (`jdbc:hsqldb:hsql://localhost`) را می‌خوانند، بنابراین ابتدا سرور آن را طبق توضیحات در *samples/Readme.txt* دانلود اجرا کنید. سایر دمواها نیازی به پایگاه داده ندارند.
5. در پوشه دموی موردنظر، برنامه را کامپایل کنید، طراحی گزارش را کامپایل کنید، آن را پر کنید و به PPT صادر کنید:

```bash
ant javac
ant compile
ant fill
ant ppt
```

هدف `ppt` ارائه را در کنار گزارش پر شده می‌نویسد و نام آن همان نام گزارش است (به عنوان مثال *LandscapeReport.ppt*).

دو دموا نیاز به مراحل بیشتری دارند:

- دموی *images* یک تصویر را از `http://jasperreports.sourceforge.net/jasperreports.png` هنگام خروجی‌گیری بارگذاری می‌کند. این آدرس اکنون به HTTPS تغییر مسیر می‌دهد، بنابراین مرحله `ppt` تا تغییر آدرس به `https://` در *ImagesReport.jrxml* هیچ ارائه‌ای تولید نمی‌کند. با JasperReports 6.4.0، خروجی‌گیری این تصویر حتی از طریق HTTPS نیز با خطا مواجه می‌شود.
- گزارش *xmldatasource* از فونت Arial استفاده می‌کند. در سیستمی که Arial ندارد، `ant fill` می‌گوید فونت «در JVM موجود نیست» و هیچ گزارش پر شده‌ای تولید نمی‌کند، بنابراین `ant ppt` چیزی برای صادر کردن ندارد. ساخت همچنان موفق گزارش می‌دهد، بنابراین خروجی هر مرحله را بررسی کنید.