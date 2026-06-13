---
title: مدیریت فراخوان‌ها در نمودارهای ارائه با C++
linktitle: فراخوان
type: docs
url: /fa/cpp/callout/
keywords:
- فراخوان نموداری
- استفاده از فراخوان
- برچسب داده
- قالب برچسب
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "فراخوان‌ها را در Aspose.Slides برای C++ ایجاد و استایل‌دهی کنید با مثال‌های کد مختصر، سازگار با PPT و PPTX برای خودکارسازی جریان کار ارائه‌ها."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با Callout‌ها برای برچسب‌های داده‌ نمودار در Aspose.Slides کار کنید. نشان می‌دهد که چگونه از متد `set_ShowLabelAsDataCallout` برای نمایش برچسب‌ها به‌صورت Callout استفاده کنید، چگونه تنظیمات مربوط به برچسب‌های Callout را برای نمودار دونات پیکربندی کنید، و اشاره می‌کند که Callout‌ها و ظاهر آن‌ها هنگام صادرات ارائه‌ها به PDF، HTML5، SVG و فرمت‌های تصویر رستر حفظ می‌شوند.

## **استفاده از Callouts**

ویژگی جدید **ShowLabelAsDataCallout** به کلاس **DataLabelFormat** و اینترفیس **IDataLabelFormat** اضافه شده است که تعیین می‌کند برچسب دادهٔ نمودار به‌صورت Callout یا به‌صورت برچسب داده نمایش داده شود. در مثال زیر ما Callout‌ها را تنظیم کرده‌ایم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **تنظیم Callout برای نمودار دونات**

Aspose.Slides برای C++ پشتیبانی از تنظیم شکل Callout برچسب دادهٔ سری برای نمودار دونات را فراهم می‌کند. نمونه کد زیر ارائه شده است.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **سوالات متداول**

**آیا Callout‌ها هنگام تبدیل ارائه به PDF، HTML5، SVG یا تصاویر حفظ می‌شوند؟**

بله. Callout‌ها بخشی از رندر نمودار هستند، بنابراین هنگام صادرات به [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)، [HTML5](/slides/fa/cpp/export-to-html5/)، [SVG](/slides/fa/cpp/render-a-slide-as-an-svg-image/)، یا [تصاویر رستر](/slides/fa/cpp/convert-powerpoint-to-png/)، همراه با قالب‌بندی اسلاید حفظ می‌شوند.

**آیا فونت‌های سفارشی در Callout‌ها کار می‌کنند و آیا ظاهر آن‌ها در هنگام صادرات حفظ می‌شود؟**

بله. Aspose.Slides از [فونت‌های جاسازی شده](/slides/fa/cpp/embedded-font/) در ارائه پشتیبانی می‌کند و در طول صادرات‌ها مانند [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/) کنترل می‌کند که Callout‌ها در سیستم‌های مختلف همان شکل را داشته باشند.