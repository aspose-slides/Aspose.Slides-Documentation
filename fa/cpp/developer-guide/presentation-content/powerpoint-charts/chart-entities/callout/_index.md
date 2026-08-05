---
title: مدیریت فراخوان‌ها در نمودارهای ارائه با C++
linktitle: فراخوان
type: docs
url: /fa/cpp/callout/
keywords:
- فراخوان نمودار
- استفاده از فراخوان
- برچسب داده
- قالب برچسب
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "فراخوان‌ها را در Aspose.Slides برای C++ ایجاد و استایل دهید با مثال‌های کد کوتاه، سازگار با PPT و PPTX برای خودکارسازی گردش کار ارائه‌ها."
---
## **بررسی کلی**

این مقاله نحوه کار با فراخوان‌ها برای برچسب‌های داده نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه از متد `set_ShowLabelAsDataCallout` برای نمایش برچسب‌ها به‌صورت فراخوان استفاده شود، چگونه تنظیمات مرتبط با فراخوان برای یک نمودار دونات پیکربندی شود، و اینکه فراخوان‌ها و ظاهر آن‌ها هنگام صادرات ارائه‌ها به PDF، HTML5، SVG و فرمت‌های تصویر raster حفظ می‌شوند.

## **استفاده از فراخوان‌ها**
ویژگی جدید **ShowLabelAsDataCallout** به کلاس **DataLabelFormat** و اینترفیس **IDataLabelFormat** اضافه شده است که تعیین می‌کند آیا برچسب دادهٔ نمودار مشخص شده به‌صورت فراخوان داده یا به‌صورت برچسب داده نمایش داده شود. در مثال زیر، ما فراخوان‌ها را تنظیم کرده‌ایم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **تنظیم یک فراخوان برای نمودار دونات**
Aspose.Slides برای C++ پشتیبانی از تنظیم شکل فراخوان برچسب دادهٔ سری برای نمودار دونات را فراهم می‌کند. مثال نمونه زیر ارائه شده است.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **سوالات متداول**

**آیا فراخوان‌ها هنگام تبدیل یک ارائه به PDF، HTML5، SVG یا تصاویر حفظ می‌شوند؟**

بله. فراخوان‌ها بخشی از رندر نمودار هستند، بنابراین هنگامی که به [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)، [HTML5](/slides/fa/cpp/export-to-html5/)، [SVG](/slides/fa/cpp/render-a-slide-as-an-svg-image/) یا [تصاویر رستری](/slides/fa/cpp/convert-powerpoint-to-png/) صادر می‌شوند، همراه با قالب‌بندی اسلاید حفظ می‌شوند.

**آیا فونت‌های سفارشی در فراخوان‌ها کار می‌کنند و آیا می‌توان ظاهر آنها را در خروجی حفظ کرد؟**

بله. Aspose.Slides از [گنجاندن فونت‌ها](/slides/fa/cpp/embedded-font/) در ارائه پشتیبانی می‌کند و در زمان صادرات مانند [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/) کنترل می‌کند که فونت‌ها گنجانده شوند، به‌طوری که فراخوان‌ها در سیستم‌های مختلف به‌یک‌سان نمایش داده شوند.