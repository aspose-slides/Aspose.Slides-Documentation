---
title: صادرات ارائه‌ها به XAML در .NET
linktitle: ارائه به XAML
type: docs
weight: 30
url: /fa/net/export-to-xaml/
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
- .NET
- C#
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint و OpenDocument به XAML در .NET با استفاده از Aspose.Slides—راه‌حل سریع و بدون Office که طرح‌بندی شما را دست‌نخورده نگه می‌دارد."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به XAML صادر کنید. در آن مقدمه‌ای کوتاه درباره XAML ارائه می‌شود، نشان داده می‌شود چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML ذخیره کنید و نحوه سفارشی‌سازی صادرات از طریق [XamlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/xamloptions/)، از جمله صادرات اسلایدهای مخفی، توضیح داده می‌شود. این مقاله همچنین به برخی سؤالات رایج مربوط به فونت‌های جایگزین، سازگاری با پشته‌های XAML و رفتار صادرات اسلایدهای مخفی پاسخ می‌دهد.

## **درباره XAML**

XAML یک زبان برنامه‌نویسی توصیفی است که به شما امکان می‌دهد واسط‌های کاربری برای برنامه‌ها بسازید یا بنویسید، به‌ویژه برنامه‌هایی که از WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin Forms استفاده می‌کنند.  

XAML که زبانی مبتنی بر XML است، نسخهٔ مایکروسافت برای توصیف رابط کاربری گرافیکی است. بیشتر اوقات از یک طراح برای کار با فایل‌های XAML استفاده می‌کنید، اما همچنان می‌توانید GUI خود را به‌صورت دستی بنویسید و ویرایش کنید.

## **صادر کردن ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

این کد C# نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## **صادر کردن ارائه‌ها به XAML با گزینه‌های سفارشی**

شما می‌توانید گزینه‌هایی را از رابط [IXamlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/ixamloptions) انتخاب کنید که فرآیند صادرات را کنترل می‌کنند و تعیین می‌دارند Aspose.Slides چگونه ارائه شما را به XAML صادر می‌کند.  

به‌عنوان مثال، اگر می‌خواهید Aspose.Slides هنگام صادرات به XAML اسلایدهای مخفی را نیز اضافه کند، می‌توانید ویژگی [ExportHiddenSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) را روی true تنظیم کنید. نمونه کد C# زیر را ببینید:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```

## **پرسش‌های متداول**

**چگونه می‌توانم فونت‌های پیش‌بینی‌پذیر داشته باشم اگر فونت اصلی در دستگاه موجود نباشد؟**  
در [XamlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/xamloptions/) ویژگی [DefaultRegularFont](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveoptions/defaultregularfont/) را تنظیم کنید — این فونت به‌عنوان فونت جایگزین استفاده می‌شود وقتی فونت اصلی موجود نباشد. این کار از جایگزینی‌های ناخواسته جلوگیری می‌کند.

**آیا XAML صادر شده تنها برای WPF است یا می‌توان آن را در دیگر پشته‌های XAML نیز استفاده کرد؟**  
XAML یک زبان علامت‌گذاری عمومی برای رابط کاربری است که در WPF، UWP و Xamarin.Forms به کار می‌رود. هدف صادرات، سازگاری با پشته‌های XAML مایکروسافت است؛ رفتار دقیق و پشتیبانی از ساختارهای خاص به پلتفرم هدف بستگی دارد. markup را در محیط خود آزمایش کنید.

**آیا اسلایدهای مخفی پشتیبانی می‌شوند و چگونه می‌توانم از صادرات پیش‌فرض آن‌ها جلوگیری کنم؟**  
به‌طور پیش‌فرض، اسلایدهای مخفی گنجانده نمی‌شوند. می‌توانید این رفتار را با ویژگی [ExportHiddenSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) در [XamlOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export.xaml/xamloptions/) کنترل کنید — اگر نیازی به صادرات آن‌ها ندارید، این گزینه را غیرفعال بگذارید.