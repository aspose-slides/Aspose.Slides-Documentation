---
title: پشتیبانی .NET 6
type: docs
weight: 235
url: /fa/net/net6/
keywords:
- پشتیبانی .NET 6
- راه حل ابری
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides را برای .NET 6 پیکربندی کنید تا در برنامه‌های مدرن و کراس‌پلتفرم C#، ارائه‌های PowerPoint PPT، PPTX و ODP را ایجاد، ویرایش و تبدیل کنید."
---
## **Introduction**

در نسخهٔ [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0) پشتیبانی از .NET6 اضافه شد. ویژگی این پشتیبانی این است که .NET6 دیگر از System.Drawing.Common برای Linux پشتیبانی نمی‌کند ([تغییر شکسته](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) و Slides این زیرسیستم گرافیکی را به‌عنوان یک مؤلفهٔ C++ خود اجرا می‌کند.

Aspose.Slides برای .NET اکنون بدون وابستگی به GDI/libgdiplus بر روی:
* ویندوز
* لینوکس

پشتیبانی از _MacOS_ در حال پیشرفت است.

## **Using Slides for .NET 6 on AWS and Azure**

.NET6 نسخهٔ ترجیحی برای Aspose.Slides است که در ابر (AWS، Azure یا دیگر راه‌حل‌های ابری) استفاده می‌شود.

قبلاً، هنگام استفاده از Aspose.Slides بر روی یک میزبان لینوکسی، وابستگی‌های اضافی (libgdiplus) باید نصب می‌شد و این اغلب ناخوشایند یا غیرعملی بود (به عنوان مثال هنگام استفاده از [AWS Lambda](https://aws.amazon.com/lambda)). با Slides برای .NET6، دیگر نیازی به این وابستگی‌ها نیست، لذا استقرار بسیار ساده‌تر می‌شود.

یکی دیگر از ملاحظات، مشکلاتی است که هنگام استفاده از Aspose.Slides در یک راه‌حل ابری با میزبان ویندوز رخ می‌داد. به‌عنوان مثال، [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) محدودیت‌هایی برای پردازش دارند و در زمان عملیات خروجی PDF منجر به مشکلات می‌شود (به [این](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). استفاده از Aspose.Slides برای .NET6 این مشکل را حل می‌کند.

## **Using the System.Drawing.Common Package and Slides for .NET 6 Classes (CS0433: The Type Exists in Both Slides and System.Drawing.Common Error)**

گاهی اوقات، هر دو وابستگی System.Drawing و Slides برای .NET6 باید در یک پروژه استفاده شوند (به‌عنوان مثال، زمانی که پروژهٔ .NET6 به بسته‌های دیگری وابسته است که به نوبت به System.Drawing وابسته‌اند). این می‌تواند خطاهای پیچیده‌ای مانند موارد زیر ایجاد کند:

* CS0433: نوع 'Image' در هر دو 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' و 'System.Drawing.Common, Version=6.0.0.0' موجود است
* CS0433: نوع 'Graphics' در هر دو 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' و 'System.Drawing.Common, Version=6.0.0.0' موجود است

در این حالت می‌توانید از [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) برای Aspose.Slides (نسخه کمتر از 24.8) استفاده کنید:
1) اسمبلی Aspose.Slides را از وابستگی‌های پروژه انتخاب کنید و سپس روی **Properties** کلیک کنید.
  ![Aspose Slides package properties](package_properties.png)
2) یک نام مستعار تنظیم کنید (به‌عنوان مثال، "Slides").
  ![Aspose Slides alias](set_alias.png)

اکنون انواع از System.Drawing.Common به طور پیش‌فرض استفاده می‌شوند. نام مستعار اسمبلی خارجی باید در جایی که انواع Aspose.Slides نیاز است، مشخص شود.

```c#
extern alias Slides;
using Slides::Aspose.Slides;
```

Full example:

```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```

از نسخهٔ 24.8 به بعد، API عمومی منسوخ‌شده‌ای که به System.Drawing وابسته بود حذف شده است. در رابطه با مثال کد بالا، می‌توانید تصویر اسلاید را به‌صورت زیر به‌دست آورید.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
API جدید به‌صورت جامع‌تر در [Modern API](/slides/fa/net/modern-api/) توضیح داده شده است.