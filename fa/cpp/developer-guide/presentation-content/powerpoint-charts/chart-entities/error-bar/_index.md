---
title: سفارشی‌سازی نوارهای خطا در نمودارهای ارائه با استفاده از C++
linktitle: نوار خطا
type: docs
url: /fa/cpp/error-bar/
keywords:
- نوار خطا
- مقدار سفارشی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه نوارهای خطا را در نمودارها با Aspose.Slides برای C++ اضافه و سفارشی‌سازی کنید — نمایش داده‌ها را در ارائه‌های PowerPoint بهینه کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با استفاده از Aspose.Slides به نمودارهای ارائه خطاها (Error Bars) اضافه کنید. در آن نشان داده می‌شود چگونه خطاها را به یک سری نمودار اضافه کنید، تنظیمات خطاهای X و Y را پیکربندی کنید و انواع مختلف مقادیر مانند ثابت، درصدی و سفارشی را اعمال کنید.

همچنین نشان می‌دهد چگونه برای نقاط دادهٔ تک‌تک در یک سری، مقادیر خطای سفارشی را با استفاده از مجموعهٔ نقاط دادهٔ مربوطه اختصاص دهید. علاوه بر این، مقاله نکات مختصری دربارهٔ رفتار خطاها در هنگام استخراج، سازگاری آنها با نشانگرها و برچسب‌های داده، و مکان یافتن کلاس‌ها و enumهای مربوط به API ارائه می‌دهد.

## **Add Error Bars**
Aspose.Slides for C++ یک API ساده برای مدیریت مقادیر خطای بار فراهم می‌کند. کد نمونه زمانی اعمال می‌شود که از نوع مقدار سفارشی استفاده می‌کنید. برای تعیین مقدار، از ویژگی **ErrorBarCustomValues** یک نقطه دادهٔ خاص در مجموعهٔ **DataPoints** سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. یک نمودار حبابی (bubble chart) روی اسلاید مورد نظر اضافه کنید.
1. به اولین سری نمودار دسترسی پیدا کنید و فرمت خطای X را تنظیم کنید.
1. به اولین سری نمودار دسترسی پیدا کنید و فرمت خطای Y را تنظیم کنید.
1. مقادیر و فرمت نوارها را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به فایل PPTX بنویسید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Add Custom Error Bars**
Aspose.Slides for C++ یک API ساده برای مدیریت مقادیر خطای سفارشی فراهم می‌کند. کد نمونه زمانی اعمال می‌شود که ویژگی **IErrorBarsFormat.ValueType** برابر با **Custom** باشد. برای تعیین مقدار، از ویژگی **ErrorBarCustomValues** یک نقطه دادهٔ خاص در مجموعهٔ **DataPoints** سری استفاده کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. یک نمودار حبابی روی اسلاید مورد نظر اضافه کنید.
1. به اولین سری نمودار دسترسی پیدا کنید و فرمت خطای X را تنظیم کنید.
1. به اولین سری نمودار دسترسی پیدا کنید و فرمت خطای Y را تنظیم کنید.
1. به نقاط دادهٔ تک‌تک سری نمودار دسترسی پیدا کنید و مقادیر خطای بار را برای نقطهٔ دادهٔ موردنظر تنظیم کنید.
1. مقادیر و فرمت نوارها را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به فایل PPTX بنویسید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**What happens to error bars when exporting a presentation to PDF or images?**

آنها به عنوان بخشی از نمودار رندر می‌شوند و در حین تبدیل همراه با بقیه قالب‌بندی نمودار حفظ می‌گردند، مشروط بر اینکه نسخه یا رندرر سازگار باشد.

**Can error bars be combined with markers and data labels?**

بله. خطاها یک عنصر جداگانه هستند و با نشانگرها و برچسب‌های داده سازگارند؛ اگر عناصر با هم هم‌پوشانی داشتند، ممکن است نیاز به تنظیم قالب‌بندی داشته باشید.

**Where can I find the list of properties and enums for working with error bars in the API?**

در مستندات API: کلاس [ErrorBarsFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/errorbarsformat/) و enumهای مرتبط [ErrorBarType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/errorbartype/) و [ErrorBarValueType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/errorbarvaluetype/).