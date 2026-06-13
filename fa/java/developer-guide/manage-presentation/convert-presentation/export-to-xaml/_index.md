---
title: صادرات ارائه‌ها به XAML در جاوا
linktitle: ارائه به XAML
type: docs
weight: 30
url: /fa/java/export-to-xaml/
keywords:
- صادرات PowerPoint
- صادرات OpenDocument
- صادرات ارائه
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- PowerPoint به XAML
- OpenDocument به XAML
- ارائه به XAML
- PPT به XAML
- PPTX به XAML
- ODP به XAML
- ذخیره PPT به صورت XAML
- ذخیره PPTX به صورت XAML
- ذخیره ODP به صورت XAML
- صادرات PPT به XAML
- صادرات PPTX به XAML
- صادرات ODP به XAML
- Java
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint و OpenDocument به XAML در جاوا با استفاده از Aspose.Slides — راه‌حلی سریع و بدون نیاز به Office که طرح‌بندی شما را حفظ می‌کند."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به XAML صادر کنید. این مقاله شامل مقدمه‌ای کوتاه درباره XAML است، نحوه ذخیره یک ارائه به XAML با تنظیمات پیش‌فرض را نشان می‌دهد و نحوه سفارشی‌سازی صادرات را از طریق [XamlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xamloptions/)، از جمله صادرات اسلایدهای مخفی، به تصویر می‌کشد. همچنین مقاله به چند سؤال رایج مربوط به قلم‌های جایگزین، سازگاری با پشته‌های XAML و رفتار صادرات اسلایدهای مخفی پاسخ می‌دهد.

## **درباره XAML**

XAML یک زبان برنامه‌نویسی توصیفی است که به شما امکان می‌دهد واسط کاربری برای برنامه‌ها بسازید یا بنویسید، به‌ویژه برنامه‌هایی که از WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin.Forms استفاده می‌کنند.  
XAML که زبانی مبتنی بر XML است، نسخه مایکروسافت برای توصیف رابط کاربری گرافیکی (GUI) می‌باشد. بیشتر اوقات احتمالاً از یک طراح برای کار با فایل‌های XAML استفاده می‌کنید، اما همچنان می‌توانید GUI خود را بنویسید و ویرایش کنید.

## **صادرات ارائه‌ها به XAML با تنظیمات پیش‌فرض**

این کد جاوا نشان می‌دهد که چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **صادرات ارائه‌ها به XAML با گزینه‌های سفارشی**

شما می‌توانید گزینه‌هایی را از رابط [IXamlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IXamlOptions) انتخاب کنید که فرایند صادرات را کنترل کرده و تعیین می‌کند Aspose.Slides چگونه ارائه شما را به XAML صادر می‌کند.  

به‌عنوان مثال، اگر می‌خواهید Aspose.Slides هنگام صادرات به XAML اسلایدهای مخفی ارائه شما را اضافه کند، می‌توانید ویژگی [ExportHiddenSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) را روی مقدار true تنظیم کنید. این کد نمونهٔ جاوا را ببینید:

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

## **سوالات متداول**

**چگونه می‌توانم فونت‌های پیش‌بینی‌پذیر را تضمین کنم اگر فونت اصلی بر روی ماشین موجود نباشد؟**  
یک [فونت معمولی پیش‌فرض](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) را در [XamlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xamloptions/) تنظیم کنید — این فونت به‌عنوان فونت جایگزین استفاده می‌شود وقتی فونت اصلی موجود نباشد. این کار از جایگزینی‌های غیرمنتظره جلوگیری می‌کند.

**آیا XAML صادرشده تنها برای WPF منظور شده است یا می‌تواند در سایر پشته‌های XAML نیز استفاده شود؟**  
XAML یک زبان نشانه‌گذاری عمومی UI است که در WPF، UWP و Xamarin.Forms استفاده می‌شود. هدف صادرات، سازگاری با پشته‌های XAML مایکروسافت است؛ رفتار دقیق و پشتیبانی از سازه‌های خاص بستگی به پلتفرم هدف دارد. نشانه‌گذاری را در محیط خود آزمایش کنید.

**آیا اسلایدهای مخفی پشتیبانی می‌شوند و چگونه می‌توانم از صادرات پیش‌فرض آن‌ها جلوگیری کنم؟**  
به‌صورت پیش‌فرض، اسلایدهای مخفی گنجانده نمی‌شوند. می‌توانید این رفتار را از طریق [setExportHiddenSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) در [XamlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/xamloptions/) کنترل کنید — اگر نیازی به صادرات آن‌ها ندارید، این گزینه را غیرفعال نگه دارید.