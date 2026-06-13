---
title: "صادرات ارائه‌ها به XAML در PHP"
linktitle: "ارائه به XAML"
type: docs
weight: 30
url: /fa/php-java/export-to-xaml/
keywords:
- "صادرات پاورپوینت"
- "صادرات OpenDocument"
- "صادرات ارائه"
- "تبدیل پاورپوینت"
- "تبدیل OpenDocument"
- "تبدیل ارائه"
- "PowerPoint به XAML"
- "OpenDocument به XAML"
- "ارائه به XAML"
- "PPT به XAML"
- "PPTX به XAML"
- "ODP به XAML"
- "ذخیره PPT به صورت XAML"
- "ذخیره PPTX به صورت XAML"
- "ذخیره ODP به صورت XAML"
- "صادرات PPT به XAML"
- "صادرات PPTX به XAML"
- "صادرات ODP به XAML"
- PHP
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint و OpenDocument به XAML با استفاده از Aspose.Slides برای PHP از طریق Java — راه حل سریع، بدون نیاز به Office که طرح‌بندی شما را دست‌نخورده نگه می‌دارد."
---
## **نمایش کلی**

این مقاله توضیح می‌دهد چگونه می‌توان ارائه‌های PowerPoint را با استفاده از Aspose.Slides به XAML صادر کرد. این مقاله شامل مقدمه ای کوتاه درباره XAML است، نشان می دهد چگونه یک ارائه را با تنظیمات پیش فرض به XAML ذخیره کنیم، و نحوه سفارشی سازی صادرات را از طریق [XamlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/) نشان می دهد، از جمله صادرات اسلایدهای مخفی. همچنین به برخی سؤال های رایج در مورد قلم های جایگزین، سازگاری با پشته های XAML و رفتار صادرات اسلایدهای مخفی پاسخ می دهد.

## **درباره XAML**

XAML یک زبان برنامه نویسی توصیفی است که به شما امکان می دهد واسط های کاربری برای برنامه ها را بسازید یا بنویسید، به خصوص برنامه هایی که از WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin Forms استفاده می کنند.  
XAML که یک زبان مبتنی بر XML است، گونه مایکروسافت برای توصیف یک رابط کاربری گرافیکی (GUI) می باشد. احتمالاً بیشتر اوقات از یک طراح برای کار با فایل های XAML استفاده می کنید، اما همچنان می توانید GUI خود را بنویسید و ویرایش کنید.

## **صادرات ارائه ها به XAML با گزینه های پیش فرض**

این کد PHP نشان می دهد چگونه یک ارائه را با تنظیمات پیش هدف به XAML صادر کنید:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **صادرات ارائه ها به XAML با گزینه های سفارشی**

شما می توانید گزینه ها را از کلاس [XamlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/) انتخاب کنید که فرآیند صادرات را کنترل کرده و تعیین می کند Aspose.Slides چگونه ارائه شما را به XAML صادر می کند.

به عنوان مثال، اگر می خواهید Aspose.Slides هنگام صادرات به XAML اسلایدهای مخفی ارائه شما را اضافه کند، می توانید از متد [setExportHiddenSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/setexporthiddenslides/) با مقدار `true` استفاده کنید. نمونه کد PHP زیر را مشاهده کنید:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **سوالات متداول**

**چگونه می توانم اطمینان حاصل کنم که فونت ها پیش بینی پذیر هستند اگر فونت اصلی در دستگاه موجود نباشد؟**

یک [فونت پیش فرض معمولی](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) را در [XamlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/) تنظیم کنید — این فونت به عنوان فونت جایگزین زمانی که فونت اصلی موجود نباشد، استفاده می شود. این کار به جلوگیری از جایگزینی های ناخواسته کمک می کند.

**آیا XAML صادر شده فقط برای WPF منظور شده است یا می تواند در سایر پشته های XAML نیز استفاده شود؟**

XAML یک زبان نشانه گذاری عمومی UI است که در WPF، UWP و Xamarin.Forms استفاده می شود. هدف صادرات سازگاری با پشته های XAML مایکروسافت است؛ رفتار دقیق و پشتیبانی از سازه های خاص به پلتفرم هدف بستگی دارد. نشانه گذاری را در محیط خود تست کنید.

**آیا اسلایدهای مخفی پشتیبانی می شوند و چگونه می توانم از صادرات پیش فرض آن ها جلوگیری کنم؟**

به طور پیش فرض، اسلایدهای مخفی شامل نمی شوند. می توانید این رفتار را از طریق [setExportHiddenSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/setexporthiddenslides/) در [XamlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/xamloptions/) کنترل کنید — اگر نیازی به صادرات آن ها ندارید، غیرفعال بگذارید.