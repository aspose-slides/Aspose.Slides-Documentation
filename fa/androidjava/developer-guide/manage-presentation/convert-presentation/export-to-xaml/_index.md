---
title: صدور ارائه‌ها به XAML در اندروید
linktitle: ارائه به XAML
type: docs
weight: 30
url: /fa/androidjava/export-to-xaml/
keywords:
- صادرات پاورپوینت
- صادرات OpenDocument
- صادرات ارائه
- تبدیل پاورپوینت
- تبدیل OpenDocument
- تبدیل ارائه
- پاورپوینت به XAML
- OpenDocument به XAML
- ارائه به XAML
- PPT به XAML
- PPTX به XAML
- ODP به XAML
- ذخیره PPT به عنوان XAML
- ذخیره PPTX به عنوان XAML
- ذخیره ODP به عنوان XAML
- صادرات PPT به XAML
- صادرات PPTX به XAML
- صادرات ODP به XAML
- اندروید
- جاوا
- Aspose.Slides
description: "اسلایدهای PowerPoint و OpenDocument را در جاوا با استفاده از Aspose.Slides برای اندروید به XAML تبدیل کنید — راه‌حل سریع و بدون Office که چیدمان شما را دست‌نخورده نگه می‌دارد."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه می‌توانید ارائه‌های PowerPoint را با استفاده از Aspose.Slides به XAML صادر کنید. شامل مقدمه‌ای کوتاه درباره XAML است، نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML ذخیره کنید و نحوهٔ سفارشی‌سازی خروجی را از طریق [XamlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xamloptions/) نشان می‌دهد، از جمله صادرات اسلایدهای مخفی. همچنین به چند سؤال رایج در مورد فونت‌های جایگزین، سازگاری استک XAML و رفتار صادرات اسلایدهای مخفی پاسخ می‌دهد.

## **درباره XAML**

XAML یک زبان برنامه‌نویسی توصیفی است که به شما امکان می‌دهد واسط‌های کاربری برای برنامه‌ها، به‌ویژه آنهایی که از WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin Forms استفاده می‌کنند، بسازید یا بنویسید.

XAML که زبانی مبتنی بر XML است، نسخهٔ مایکروسافت برای توصیف رابط گرافیکی کاربر است. اغلب برای کار با فایل‌های XAML از یک طراح استفاده می‌کنید، اما همچنان می‌توانید GUI خود را به‌صورت دستی بنویسید و ویرایش کنید.

## **صادرات ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

این کد Java نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **صادرات ارائه‌ها به XAML با گزینه‌های سفارشی**

شما می‌توانید گزینه‌هایی از رابط [IXamlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IXamlOptions) را انتخاب کنید که فرآیند صادرات را کنترل کرده و تعیین می‌کنند Aspose.Slides ارائه شما را چگونه به XAML صادر می‌کند.

به عنوان مثال، اگر می‌خواهید Aspose.Slides هنگام صادرات به XAML اسلایدهای مخفی ارائه شما را نیز اضافه کند، می‌توانید ویژگی [ExportHiddenSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) را روی true تنظیم کنید. این نمونه کد Java را ببینید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**چگونه می‌توانم فونت‌های قابل پیش‌بینی تضمین کنم اگر فونت اصلی در دستگاه موجود نباشد؟**  
فونت پیش‌فرض عادی را در [XamlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xamloptions/) تنظیم کنید — این فونت به‌عنوان فونت جایگزین هنگام عدم وجود فونت اصلی استفاده می‌شود. این کار از جایگزینی‌های ناخواسته جلوگیری می‌کند.

**آیا XAML صادر شده فقط برای WPF منظور شده است یا می‌تواند در سایر استک‌های XAML نیز استفاده شود؟**  
XAML یک زبان نشانه‌گذاری عمومی برای رابط کاربری است که در WPF، UWP و Xamarin.Forms به‌کار می‌رود. خروجی هدف‌گیری سازگاری با استک‌های XAML مایکروسافت است؛ رفتار دقیق و پشتیبانی از سازه‌های خاص به پلتفرم هدف بستگی دارد. markup را در محیط خود تست کنید.

**آیا اسلایدهای مخفی پشتیبانی می‌شوند و چگونه می‌توانم از صادر شدن پیش‌فرض آن‌ها جلوگیری کنم؟**  
به‌طور پیش‌فرض، اسلایدهای مخفی شامل نمی‌شوند. می‌توانید این رفتار را از طریق [setExportHiddenSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) در [XamlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xamloptions/) کنترل کنید — اگر نیازی به صادرات آن‌ها ندارید، این گزینه را غیرفعال نگه دارید.