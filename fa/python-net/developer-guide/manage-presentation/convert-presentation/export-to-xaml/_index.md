---
title: صادر کردن ارائه‌ها به XAML با Python
linktitle: صادر کردن به XAML
type: docs
weight: 30
url: /fa/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint و OpenDocument به XAML در Python با استفاده از Aspose.Slides—راه‌حل سریع، بدون نیاز به Office که چیدمان شما را دست نخورده نگه می‌دارد."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به XAML صادر کنید. این مقاله شامل مقدمه‌ای کوتاه درباره XAML است، نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML ذخیره کنید، و نحوه سفارشی‌سازی خروجی را از طریق [XamlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/) به نمایش می‌گذارد، از جمله صادر کردن اسلایدهای مخفی. همچنین مقاله به چند سؤال رایج در مورد قلم‌های پیش‌فرض، سازگاری پشته XAML و رفتار خروجی اسلایدهای مخفی پاسخ می‌دهد.

## **درباره XAML**

XAML یک زبان برنامه‌نویسی توصیفی است که به شما امکان می‌دهد رابط کاربری برنامه‌ها را بسازید یا بنویسید، به‌ویژه برنامه‌هایی که از WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin Forms استفاده می‌کنند.  

XAML که یک زبان مبتنی بر XML است، نسخه مایکروسافت برای توصیف GUI می‌باشد. معمولاً از یک ابزار طراحی برای کار با فایل‌های XAML استفاده می‌کنید، اما همچنان می‌توانید GUI خود را بنویسید و ویرایش کنید.

## **صادرات ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

این کد Python نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنید:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **صادرات ارائه‌ها به XAML با گزینه‌های سفارشی**

شما می‌توانید گزینه‌ها را از کلاس [XamlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/) انتخاب کنید که فرآیند خروجی را کنترل می‌کند و تعیین می‌کند Aspose.Slides چگونه ارائه شما را به XAML صادر می‌کند.

به‌عنوان مثال، اگر می‌خواهید Aspose.Slides هنگام صادر کردن به XAML اسلایدهای مخفی ارائه شما را اضافه کند، می‌توانید ویژگی [export_hidden_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) را روی `True` تنظیم کنید. نمونه کد Python زیر را ببینید:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **پرسش‌های متداول**

**چگونه می‌توانم اطمینان حاصل کنم که قلم‌های پیش‌بینی‌پذیر استفاده شوند اگر قلم اصلی روی دستگاه موجود نباشد؟**

مقدار [default_regular_font](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) را در [XamlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/) تنظیم کنید — این قلم به‌عنوان قلم پیش‌فرض در صورت عدم وجود قلم اصلی استفاده می‌شود. این کار به جلوگیری از جایگزینی‌های ناخواسته کمک می‌کند.

**آیا XAML صادر شده فقط برای WPF در نظر گرفته شده است یا می‌تواند در سایر پشته‌های XAML نیز استفاده شود؟**

XAML یک زبان نشانه‌گذاری عمومی برای رابط کاربری است که در WPF، UWP و Xamarin.Forms استفاده می‌شود. خروجی برای سازگاری با پشته‌های XAML مایکروسافت هدف‌گذاری شده است؛ رفتار دقیق و پشتیبانی از ساختارهای خاص به پلتفرم هدف بستگی دارد. نشانه‌گذاری را در محیط خود آزمایش کنید.

**آیا اسلایدهای مخفی پشتیبانی می‌شوند و چگونه می‌توانم از صادر شدن پیش‌فرض آن‌ها جلوگیری کنم؟**

به‌طور پیش‌فرض، اسلایدهای مخفی گنجانده نمی‌شوند. می‌توانید این رفتار را از طریق [export_hidden_slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) در [XamlOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export.xaml/xamloptions/) کنترل کنید — اگر نیاز به صادر کردن آن‌ها ندارید، این گزینه را غیرفعال نگه دارید.