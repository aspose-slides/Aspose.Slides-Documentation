---
title: صادرات ارائه‌ها به XAML در C++
linktitle: ارائه به XAML
type: docs
weight: 30
url: /fa/cpp/export-to-xaml/
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
- C++
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint و OpenDocument به XAML در C++ با استفاده از Aspose.Slides — راه‌حلی سریع و بدون Office که طرح‌بندی شما را دست‌نخورده نگه می‌دارد."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به XAML صادر کنید. این مقاله شامل مقدمه‌ای کوتاه درباره XAML است، نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML ذخیره کنید و نحوه سفارشی‌سازی صادرات را از طریق [XamlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/xamloptions/)، شامل صادرات اسلایدهای مخفی، نشان می‌دهد. همچنین به برخی پرسش‌های متداول مربوط به فونت‌های جایگزین، سازگاری با پشته XAML و رفتار صادرات اسلایدهای مخفی پاسخ می‌دهد.

## **درباره XAML**

XAML یک زبان برنامه‌نویسی توصیفی است که به شما امکان می‌دهد رابط‌های کاربری برای برنامه‌ها، به‌ویژه برنامه‌هایی که از WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin Forms استفاده می‌کنند، بسازید یا بنویسید.  
XAML که زبانی مبتنی بر XML است، نسخه مایکروسافت برای توصیف یک GUI می‌باشد. احتمالاً بیشتر زمان از یک طراح برای کار با فایل‌های XAML استفاده می‌کنید، اما همچنان می‌توانید GUI خود را بنویسید و ویرایش کنید.

## **صادرات ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

این کد C++ نشان می‌دهد که چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنید:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **صادرات ارائه‌ها به XAML با گزینه‌های سفارشی**

شما می‌توانید گزینه‌ها را از رابط [IXamlOptions](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.xaml.i_xaml_options) انتخاب کنید که فرآیند صادرات را کنترل کرده و تعیین می‌کند Aspose.Slides چگونه ارائه شما را به XAML صادر می‌کند.  

به‌عنوان مثال، اگر می‌خواهید Aspose.Slides هنگام صادرات به XAML، اسلایدهای مخفی را از ارائه شما اضافه کند، می‌توانید مقدار true را به متد [set_ExportHiddenSlides()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) پاس دهید. نمونه کد C++ زیر را ببینید:

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **سوالات متداول**

**چگونه می‌توانم فونت‌های قابل پیش‌بینی داشته باشم اگر فونت اصلی در دستگاه موجود نباشد؟**  
از [set_DefaultRegularFont](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) در [XamlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/xamloptions/) استفاده کنید — این گزینه به‌عنوان فونت جایگزین زمانی که فونت اصلی موجود نیست، به کار می‌رود. این کار به جلوگیری از جایگزینی‌های ناخواسته کمک می‌کند.

**آیا XAML صادر شده فقط برای WPF هدف‌گذاری شده است یا می‌تواند در سایر پشته‌های XAML نیز استفاده شود؟**  
XAML یک زبان علامت‌گذاری عمومی برای رابط کاربری است که در WPF، UWP و Xamarin.Forms استفاده می‌شود. صادرات با هدف سازگاری با پشته‌های XAML مایکروسافت انجام می‌شود؛ رفتار دقیق و پشتیبانی از سازه‌های خاص به پلتفرم هدف بستگی دارد. علامت‌گذاری را در محیط خود آزمایش کنید.

**آیا اسلایدهای مخفی پشتیبانی می‌شوند و چگونه می‌توانم از صادرات پیش‌فرض آن‌ها جلوگیری کنم؟**  
به‌صورت پیش‌فرض، اسلایدهای مخفی شامل نمی‌شوند. می‌توانید این رفتار را از طریق [set_ExportHiddenSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) در [XamlOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export.xaml/xamloptions/) کنترل کنید — اگر نیازی به صادرات آن‌ها ندارید، این گزینه را غیرفعال نگه دارید.