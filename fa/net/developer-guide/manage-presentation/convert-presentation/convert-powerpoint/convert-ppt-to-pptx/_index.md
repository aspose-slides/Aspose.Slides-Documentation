---
title: تبدیل PPT به PPTX در .NET
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/net/convert-ppt-to-pptx/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- PPT به PPTX
- ذخیره PPT به‌صورت PPTX
- خروجی PPT به PPTX
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تبدیل ارائه‌های PPT قدیمی به PPTX مدرن به‑سرعت در .NET با Aspose.Slides — آموزش واضح، نمونه‌های رایگان C#، بدون نیاز به Microsoft Office."
---
## **بررسی کلی**

این مقاله نحوه تبدیل ارائه PowerPoint با فرمت PPT به فرمت PPTX را با استفاده از C# و اپلیکیشن آنلاین تبدیل PPT به PPTX توضیح می‌دهد. موضوعات زیر پوشش داده شده‌اند.

- [تبدیل PPT به PPTX در C#](#convert-ppt-to-pptx)

## **تبدیل PPT به PPTX در .NET**

برای کد نمونه C# جهت تبدیل PPT به PPTX، لطفاً به بخش زیر یعنی [Convert PPT to PPTX](#convert-ppt-to-pptx) مراجعه کنید. این کد فقط فایل PPT را بارگذاری کرده و در فرمت PPTX ذخیره می‌کند. با تعیین فرمت‌های ذخیره‌سازی مختلف، می‌توانید فایل PPT را به بسیاری از فرمت‌های دیگر مانند PDF، XPS، ODP، HTML و غیره نیز ذخیره کنید همان‌طور که در این مقالات بحث شده است.

- [تبدیل PPT به PDF در .NET](/slides/fa/net/convert-powerpoint-to-pdf/)
- [تبدیل PPT به XPS در .NET](/slides/fa/net/convert-powerpoint-to-xps/)
- [تبدیل PPT به HTML در .NET](/slides/fa/net/convert-powerpoint-to-html/)
- [تبدیل PPT به ODP در .NET](/slides/fa/net/save-presentation/)
- [تبدیل PPT به PNG در .NET](/slides/fa/net/convert-powerpoint-to-png/)

## **درباره تبدیل PPT به PPTX**
تبدیل فرمت قدیمی PPT به PPTX با استفاده از Aspose.Slides API. اگر نیاز دارید هزاران ارائه PPT را به فرمت PPTX تبدیل کنید، بهترین راه‌حل برنامه‌نویسی است. با Aspose.Slides API این کار فقط در چند خط کد امکان‌پذیر است. این API سازگاری کامل برای تبدیل ارائه PPT به PPTX را پشتیبانی می‌کند و می‌تواند:

- ساختارهای پیچیدهٔ مسترها، لایه‌ها و اسلایدها را تبدیل کند.
- ارائه‌های دارای چارت‌ها را تبدیل کند.
- ارائه‌های دارای شکل‌های گروهی، اشکال خودکار (مانند مستطیل و بیضی)، شکل‌های با هندسهٔ سفارشی را تبدیل کند.
- ارائه‌هایی که دارای بافت‌ها و سبک‌های پر کردن تصاویر برای اشکال خودکار هستند را تبدیل کند.
- ارائه‌هایی که شامل جای‌گیرها، فریم‌های متن و نگهدارنده‌های متن هستند را تبدیل کند.

{{% alert color="primary" %}} 

نگاهی به برنامهٔ [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) بیاندازید:

[](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx)

این برنامه بر پایهٔ **Aspose.Slides API** ساخته شده است، بنابراین می‌توانید مثال زندهٔ قابلیت‌های پایهٔ تبدیل PPT به PPTX را مشاهده کنید. Aspose.Slides Conversion یک برنامهٔ وب است که اجازه می‌دهد فایل ارائهٔ PPT را بکشید و سپس فایل تبدیل‌شده به PPTX را دانلود کنید.

نمونه‌های زندهٔ دیگر [**Aspose.Slides Conversion**](https://products.aspose.app/slides/fa/conversion/) را پیدا کنید.
{{% /alert %}} 


## **تبدیل PPT به PPTX**
برای تبدیل یک فایل PPT به PPTX کافیست نام فایل و فرمت ذخیره‌سازی را به متد [**Save**](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/methods/save/index) کلاس [**Presentation**](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) پاس دهید. نمونهٔ کد C# زیر یک ارائه را از PPT به PPTX با گزینه‌های پیش‌فرض تبدیل می‌کند.

```c#
// یک شی Presentation را ایجاد کنید که نمایانگر یک فایل PPTX است
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// ذخیرهٔ ارائه PPTX در قالب PPTX
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

بیشتر در مورد فرمت‌های ارائهٔ [**PPT vs PPTX**](/slides/fa/net/ppt-vs-pptx/) و نحوهٔ [**Aspose.Slides supports PPT to PPTX conversion**](/slides/fa/net/convert-ppt-to-pptx/) بخوانید.

## **سوالات متداول**

**تفاوت فرمت‌های PPT و PPTX چیست؟**

PPT فرمت باینری قدیمی مورد استفاده در Microsoft PowerPoint است، در حالی که PPTX فرمت جدید مبتنی بر XML است که از Microsoft Office 2007 معرفی شد. فایل‌های PPTX عملکرد بهتر، حجم کمتر و بهبود بازیابی داده‌ها را ارائه می‌دهند.

**آیا می‌توانم PPT را به PPTX با استفاده از .NET تبدیل کنم؟**

بله، با استفاده از کتابخانه Aspose.Slides برای .NET می‌توانید به سادگی یک فایل PPT را بارگذاری کرده و آن را با تنها چند خط کد در فرمت PPTX ذخیره کنید.

**آیا Aspose.Slides تبدیل دسته‌ای چندین فایل PPT به PPTX را پشتیبانی می‌کند؟**

بله، می‌توانید از Aspose.Slides در یک حلقه برای تبدیل برنامه‌نویسی چندین فایل PPT به PPTX استفاده کنید که برای سناریوهای تبدیل دسته‌ای مناسب است.

**آیا محتوا و قالب‌بندی پس از تبدیل حفظ می‌شوند؟**

Aspose.Slides در تبدیل ارائه‌ها دقت بالایی دارد. چیدمان اسلایدها، انیمیشن‌ها، اشکال، چارت‌ها و سایر عناصر طراحی در هنگام تبدیل از PPT به PPTX حفظ می‌شوند.

**آیا می‌توانم فرمت‌های دیگری مانند PDF یا HTML را از فایل‌های PPT تبدیل کنم؟**

بله، Aspose.Slides تبدیل PPT به فرمت‌های مختلفی از جمله PDF، XPS، HTML، ODP و فرمت‌های تصویری مانند PNG و JPEG را پشتیبانی می‌کند.

**آیا امکان تبدیل PPT به PPTX بدون نصب Microsoft PowerPoint وجود دارد؟**

بله، Aspose.Slides برای .NET یک API مستقل است و برای انجام تبدیل نیازی به Microsoft PowerPoint یا هیچ نرم‌افزار شخص ثالث دیگری ندارد.

**آیا ابزار آنلاین برای تبدیل PPT به PPTX موجود است؟**

بله، می‌توانید از برنامهٔ وب رایگان [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) برای انجام تبدیل مستقیماً در مرورگر خود بدون نوشتن کد استفاده کنید.