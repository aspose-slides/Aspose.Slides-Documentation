---
title: افزودن اشکال خط به ارائه‌ها در C++
linktitle: خط
type: docs
weight: 50
url: /fa/cpp/line/
keywords:
- خط
- ایجاد خط
- افزودن خط
- خط ساده
- پیکربندی خط
- سفارشی‌سازی خط
- سبک خط‌چین
- سرپیکان
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه قالب‌بندی خطوط را در ارائه‌های PowerPoint با Aspose.Slides برای C++ مدیریت کنید. ویژگی‌ها، روش‌ها و مثال‌ها را کشف کنید."
---
## **مروری کلی**

Aspose.Slides به شما امکان می‌دهد تا اشکال خط را به اسلایدهای PowerPoint به‌صورت برنامه‌نویسی اضافه کنید. این مقاله نشان می‌دهد چگونه یک خط ساده ایجاد کنید و چگونه یک خط را طوری سفارشی کنید که به شکل یک پیکان ظاهر شود.

شما یاد خواهید گرفت چگونه یک شکل خط را به اسلاید اضافه کنید، ظاهر تصویری آن را تنظیم کنید و ارائهٔ به‌روز شده را ذخیره کنید. مثال‌ها بر روی تنظیمات عملی قالب‌بندی خط مانند سبک، عرض، الگوی خط‌چین، گزینه‌های سرپیکان و رنگ پر کردن تمرکز دارند.

## **ایجاد خط ساده**

برای افزودن یک خط ساده ساده به اسلاید انتخاب‌شدهٔ ارائه، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از [Presentation class](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از Index آن دریافت کنید.
- با استفاده از متد [AddAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addautoshape/) که توسط شی Shapes ارائه می‌شود، یک AutoShape از نوع Line اضافه کنید.
- ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

در مثال زیر، ما یک خط را به اولین اسلاید ارائه اضافه کرده‌ایم.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddPlainLineToSlide-AddPlainLineToSlide.cpp" >}}

## **ایجاد خط با شکل پیکان**

Aspose.Slides for C++ همچنین به توسعه‌دهندگان اجازه می‌دهد برخی از ویژگی‌های خط را تنظیم کنند تا ظاهر جذاب‌تری داشته باشد. بیایید چند ویژگی خط را طوری تنظیم کنیم که شبیه یک پیکان شود. لطفاً مراحل زیر را برای انجام این کار دنبال کنید:

- یک نمونه از [Presentation class](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
- مرجع یک اسلاید را با استفاده از Index آن دریافت کنید.
- با استفاده از متد AddAutoShape که توسط شی Shapes ارائه می‌شود، یک AutoShape از نوع Line اضافه کنید.
- قالب خط (Line Style) را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides for C++ تنظیم کنید.
- عرض خط (Width) را تنظیم کنید.
- الگوی خط‌چین (Dash Style) خط را به یکی از سبک‌های ارائه‌شده توسط Aspose.Slides for C++ تنظیم کنید. برای این کار می‌توانید از [Dash Style](https://reference.aspose.com/slides/fa/cpp/aspose.slides/linedashstyle/) استفاده کنید.
- سبک سرپیکان (Arrow Head Style) و طول نقطهٔ شروع خط را تنظیم کنید. برای این کار می‌توانید از [Arrow Head Style](https://reference.aspose.com/slides/fa/cpp/aspose.slides/lineformat/) استفاده کنید.
- سبک سرپیکان و طول نقطهٔ انتهای خط را تنظیم کنید.
- ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddArrowShapedLineToSlide-AddArrowShapedLineToSlide.cpp" >}}

## **سؤالات متداول**

**آیا می‌توانم یک خط معمولی را به یک کانکتور تبدیل کنم تا به اشکال “چسبیده” شود؟**

نه. یک خط معمولی (یک [AutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/autoshape/) از نوع [Line](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapetype/)) به‌صورت خودکار به یک کانکتور تبدیل نمی‌شود. برای اینکه به اشکال چسبیده شود، از نوع اختصاصی [Connector](https://reference.aspose.com/slides/fa/cpp/aspose.slides/connector/) و [API‌های مربوطه](/slides/fa/cpp/connector/) برای اتصال استفاده کنید.

**اگر ویژگی‌های یک خط از تم به ارث برده شوند و تعیین مقادیر نهایی دشوار باشد، چه کاری باید انجام دهم؟**

از طریق رابط‌های [ILineFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilineformateffectivedata/) / [ILineFillFormatEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilinefillformateffectivedata/) ویژگی‌های مؤثر را بخوانید—اینها پیشاپیش ارث‌بری و سبک‌های تم را در نظر می‌گیرند.

**آیا می‌توانم یک خط را در برابر ویرایش (جابه‌جایی، تغییر اندازه) قفل کنم؟**

بله. اشکال [lock objects](https://reference.aspose.com/slides/fa/cpp/aspose.slides/autoshape/get_autoshapelock/) را فراهم می‌کنند که به شما امکان می‌دهند عملیات‌های ویرایشی را [غیرفعال کنید](/slides/fa/cpp/applying-protection-to-presentation/).