---
title: تبدیل PPT به PPTX در .NET
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/net/convert-ppt-to-pptx/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- PPT به PPTX
- ذخیره PPT به عنوان PPTX
- خروجی PPT به PPTX
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تبدیل ارائه‌های PPT قدیمی به PPTX مدرن به سرعت در .NET با Aspose.Slides — آموزش واضح، نمونه‌ کدهای رایگان C#، بدون وابستگی به Microsoft Office."
---
## **مروری**

این مقاله توضیح می‌دهد که چگونه ارائه PowerPoint را از فرمت PPT به فرمت PPTX با استفاده از C# و برنامه آنلاین تبدیل PPT به PPTX تبدیل کنید. موضوع زیر پوشش داده شده است.

- [تبدیل PPT به PPTX در C#](#convert-ppt-to-pptx)

## **تبدیل PPT به PPTX در .NET**

برای کد نمونه C# جهت تبدیل PPT به PPTX، لطفاً به بخش زیر مراجعه کنید یعنی [Convert PPT to PPTX](#convert-ppt-to-pptx). این کد فقط فایل PPT را بارگذاری کرده و در فرمت PPTX ذخیره می‌کند. با مشخص کردن فرمت‌های ذخیره‌سازی مختلف، می‌توانید فایل PPT را به بسیاری از فرمت‌های دیگر مانند PDF، XPS، ODP، HTML و غیره نیز ذخیره کنید همان‌طور که در این مقالات بررسی شده است. 

- [تبدیل PPT به PDF در .NET](/slides/fa/net/convert-powerpoint-to-pdf/)
- [تبدیل PPT به XPS در .NET](/slides/fa/net/convert-powerpoint-to-xps/)
- [تبدیل PPT به HTML در .NET](/slides/fa/net/convert-powerpoint-to-html/)
- [تبدیل PPT به ODP در .NET](/slides/fa/net/save-presentation/)
- [تبدیل PPT به PNG در .NET](/slides/fa/net/convert-powerpoint-to-png/)

## **درباره تبدیل PPT به PPTX**

تبدیل فرمت قدیمی PPT به PPTX با Aspose.Slides API. اگر نیاز به تبدیل هزاران ارائه PPT به فرمت PPTX دارید، بهترین راه حل انجام این کار به‌صورت برنامه‌نویسی است. با Aspose.Slides API می‌توانید این کار را تنها در چند خط کد انجام دهید. این API پشتیبانی کامل سازگاری برای تبدیل ارائه PPT به PPTX را دارد و می‌تواند:

- تبدیل ساختارهای پیچیدهٔ مسترها، طرح‌بندی‌ها و اسلایدها.
- تبدیل ارائه حاوی نمودارها.
- تبدیل ارائه شامل اشکال گروهی، اشکال خودکار (مانند مستطیل و بیضی)، اشکالی با هندسهٔ سفارشی.
- تبدیل ارائه‌ای که دارای بافت‌ها و سبک‌های پرکردن تصویر برای اشکال خودکار است.
- تبدیل ارائه با محل‌های نگه‌دارنده، قاب‌های متن و نگهدارنده‌های متن.

{{% alert color="info" %}} 

نگاه کنید به برنامه [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx)

این برنامه بر پایه **Aspose.Slides API** ساخته شده است، بنابراین می‌توانید مثال زنده‌ای از قابلیت‌های تبدیل پایه‌ای PPT به PPTX را ببینید. Aspose.Slides Conversion یک برنامه وب است که امکان کشیدن فایل ارائه در فرمت PPT و دانلود آن به‌صورت تبدیل‌شده به PPTX را فراهم می‌کند.

سایر مثال‌های زندهٔ [**Aspose.Slides Conversion**](https://products.aspose.app/slides/fa/conversion/) را پیدا کنید.
{{% /alert %}} 

## **تبدیل PPT به PPTX**

برای تبدیل یک PPT به PPTX کافی است نام فایل و فرمت ذخیره را به متد [**Save**](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/methods/save/index) کلاس [**Presentation**](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) پاس دهید. نمونه کد C# زیر یک Presentation را از PPT به PPTX با استفاده از گزینه‌های پیش‌فرض تبدیل می‌کند.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شیء Presentation ایجاد می‌کند که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// ذخیرهٔ ارائه PPTX به قالب PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

بیشتر دربارهٔ قالب‌های ارائهٔ [**PPT vs PPTX**](/slides/fa/net/ppt-vs-pptx/) و نحوهٔ [**Aspose.Slides supports PPT to PPTX conversion**](/slides/fa/net/convert-ppt-to-pptx/) بخوانید.

## **سوالات متداول**

### تفاوت فرمت‌های PPT و PPTX چیست؟

PPT فرمت باینری قدیمی است که توسط Microsoft PowerPoint استفاده می‌شود، در حالی که PPTX فرمت مبتنی بر XML جدیدی است که با Microsoft Office 2007 معرفی شد. فایل‌های PPTX عملکرد بهتر، حجم فایل کمتر و بازیابی داده‌های پیشرفته‌تری ارائه می‌دهند.

### آیا می‌توانم PPT را به PPTX با .NET تبدیل کنم؟

بله، با استفاده از کتابخانه Aspose.Slides برای .NET می‌توانید به راحتی یک فایل PPT را بارگذاری کرده و تنها در چند خط کد آن را به فرمت PPTX ذخیره کنید.

### آیا Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT به PPTX پشتیبانی می‌کند؟

بله، می‌توانید از Aspose.Slides در یک حلقه برای تبدیل برنامه‌نویسی چندین فایل PPT به PPTX استفاده کنید، که این امر آن را برای سناریوهای تبدیل دسته‌ای مناسب می‌سازد.

### آیا محتوا و قالب‌بندی پس از تبدیل حفظ می‌شوند؟

Aspose.Slides در تبدیل ارائه‌ها دقت بالایی را حفظ می‌کند. طرح‌بندی اسلایدها، انیمیشن‌ها، شکل‌ها، نمودارها و سایر عناصر طراحی در طول تبدیل PPT به PPTX حفظ می‌شوند.

### آیا می‌توانم سایر فرمت‌ها مانند PDF یا HTML را از فایل‌های PPT تبدیل کنم؟

بله، Aspose.Slides پشتیبانی می‌کند از تبدیل فایل‌های PPT به چندین فرمت، از جمله PDF، XPS، HTML، ODP و فرمت‌های تصویری مانند PNG و JPEG.

### آیا امکان تبدیل PPT به PPTX بدون نصب Microsoft PowerPoint وجود دارد؟

بله، Aspose.Slides برای .NET یک API مستقل است و برای انجام تبدیل نیازی به Microsoft PowerPoint یا هیچ نرم‌افزار شخص ثالثی ندارد.

### آیا ابزار آنلاین برای تبدیل PPT به PPTX موجود است؟

بله، می‌توانید از برنامه وب رایگان [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) برای انجام تبدیل مستقیم در مرورگر خود بدون نیاز به نوشتن کد استفاده کنید.