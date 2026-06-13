---
title: صادر کردن ارائه‌ها به XAML در جاوااسکریپت
linktitle: ارائه به XAML
type: docs
weight: 30
url: /fa/nodejs-java/export-to-xaml/
keywords:
- صادر کردن PowerPoint
- صادر کردن OpenDocument
- صادر کردن ارائه
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- PowerPoint به XAML
- OpenDocument به XAML
- ارائه به XAML
- PPT به XAML
- PPTX به XAML
- ODP به XAML
- ذخیره PPT به عنوان XAML
- ذخیره PPTX به عنوان XAML
- ذخیره ODP به عنوان XAML
- صادر کردن PPT به XAML
- صادر کردن PPTX به XAML
- صادر کردن ODP به XAML
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "اسلایدهای PowerPoint و OpenDocument را به XAML در جاوااسکریپت با استفاده از Aspose.Slides برای Node.js—راه‌حلی سریع و بدون نیاز به Office که طرح‌بندی شما را دست نخورده نگه می‌دارد."
---
## **بررسی اجمالی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به XAML صادر کنیم. این مقاله شامل مقدمه‌ای کوتاه درباره XAML است، نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML ذخیره کنیم، و نحوه سفارشی‌سازی صادرات را از طریق [XamlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xamloptions/) نشان می‌دهد، از جمله صدور اسلایدهای مخفی. همچنین به چند سؤال رایج در مورد قلم‌های جایگزین، سازگاری پشته XAML و رفتار صادرات اسلایدهای مخفی پاسخ می‌دهد.

## **درباره XAML**

XAML یک زبان برنامه‌نویسی توصیفی است که به شما امکان می‌دهد کلاس‌های کاربری برای برنامه‌ها ایجاد یا بنویسید، به‌ویژه برنامه‌هایی که از WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin Forms استفاده می‌کنند.

XAML که زبانی مبتنی بر XML است، نسخه مایکروسافت برای توصیف رابط گرافیکی کاربر (GUI) می‌باشد. بیشتر اوقات احتمالاً از یک طراح برای کار با فایل‌های XAML استفاده می‌کنید، اما همچنان می‌توانید GUI خود را بنویسید و ویرایش کنید.

## **صادرات ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

این کد JavaScript به شما نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **صادرات ارائه‌ها به XAML با گزینه‌های سفارشی**

شما می‌توانید گزینه‌ها را از کلاس [XamlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/XamlOptions) انتخاب کنید که فرآیند صادرات را کنترل می‌کند و تعیین می‌کند Aspose.Slides چگونه ارائه شما را به XAML صادر می‌کند.

به‌عنوان مثال، اگر می‌خواهید Aspose.Slides هنگام صادرات به XAML اسلایدهای مخفی را از ارائه شما اضافه کند، می‌توانید متد [setExportHiddenSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) را روی true تنظیم کنید. نمونه کد JavaScript زیر را ببینید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**چگونه می‌توانم فونت‌های پیش‌بینی‌شده را تضمین کنم اگر فونت اصلی روی دستگاه موجود نباشد؟**

از [setDefaultRegularFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) در [XamlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xamloptions/) استفاده کنید — این متد به عنوان فونت جایگزین زمانی که فونت اصلی موجود نباشد، به کار می‌رود. این کار از جایگزینی‌های غیرمنتظره جلوگیری می‌کند.

**آیا XAML صادر شده فقط برای WPF در نظر گرفته شده است یا می‌تواند در سایر پشته‌های XAML نیز استفاده شود؟**

XAML یک زبان نشانه‌گذاری عمومی برای رابط کاربری است که در WPF، UWP و Xamarin.Forms استفاده می‌شود. هدف صادرات، سازگاری با پشته‌های XAML مایکروسافت است؛ رفتار دقیق و پشتیبانی از سازه‌های خاص به پلتفرم هدف بستگی دارد. مارکاپ را در محیط خود تست کنید.

**آیا اسلایدهای مخفی پشتیبانی می‌شوند و چگونه می‌توانم از صادرات پیش‌فرض آنها جلوگیری کنم؟**

به‌طور پیش‌فرض، اسلایدهای مخفی گنجانده نمی‌شوند. می‌توانید این رفتار را از طریق [setExportHiddenSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) در [XamlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/xamloptions/) کنترل کنید — اگر نیازی به صادرات آنها ندارید، این گزینه را غیرفعال نگه دارید.