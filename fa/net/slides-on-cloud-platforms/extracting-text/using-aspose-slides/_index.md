---
title: "چگونه متن را از PPT، PPTX و ODP با Aspose.Slides استخراج کنیم"
linktitle: "اسلایدها"
type: docs
weight: 30
url: /fa/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- "پلتفرم‌های ابری"
- "یکپارچه‌سازی ابری"
- "استخراج متن"
- "استخراج متن"
- "PPT"
- "PPTX"
- "ODP"
- "فایل‌های ارائه"
- "چندپلتفرمی"
- "مستقل از Office"
- "یادداشت‌ها و نظرات"
- "ایندکس‌گذاری سازمانی"
- "غنی‌سازی داده"
- ".NET"
- "Aspose.Slides"
description: "متن را از ارائه‌ها در پلتفرم‌های ابری محبوب با استفاده از APIهای Aspose.Slides استخراج کنید، جستجو، تحلیل و صادرات برای PPT، PPTX و ODP را خودکار می‌سازد."
---
## **مقدمه**

Aspose.Slides یک **API قدرتمند و سطح بالا** برای استخراج متن از فایل‌های ارائه، شامل **PPT، PPTX و ODP**، فراهم می‌کند. بر خلاف Open XML SDK که تنها از PPTX پشتیبانی می‌کند و نیاز به تجزیه‌وتحلیل پیچیده XML دارد، Aspose.Slides فرآیند استخراج متن را ساده می‌کند و به شما امکان می‌دهد تا تمرکز خود را بر یکپارچه‌سازی محتوای استخراج‌شده در جریان کاری‌تان بگذارید.

## **استخراج سریع متن با PresentationFactory.Instance.GetPresentationText**

برای استخراج متن از یک ارائه، **Aspose.Slides API** متد استاتیک `PresentationFactory.Instance.GetPresentationText` را ارائه می‌دهد. این متد چندین overload برای کار با فایل ارائه یا جریان داده دارد و متن را از **اسلایدها، اسلایدهای اصلی، طرح‌بندی‌ها، یادداشت‌ها و نظرات** استخراج می‌کند. متن استخراج‌شده از طریق رابط `IPresentationText` در دسترس است.

مثال استفاده:

```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```

## **حالت‌های عملکرد GetPresentationText**

متد `GetPresentationText` در `PresentationFactory` به شما امکان می‌دهد تا استخراج متن را با استفاده از پارامتر `TextExtractionArrangingMode` تنظیم کنید؛ این پارامتر نحوه سازماندهی متن در خروجی را کنترل می‌کند.

### **حالت‌های موجود**

- **TextExtractionArrangingMode.Unarranged** – متن را به صورت آزاد و بدون در نظر گرفتن طرح‌بندی اصلی اسلاید استخراج می‌کند.  
- **TextExtractionArrangingMode.Arranged** – ترتیب متن را بر اساس مکان آن در هر اسلاید حفظ می‌کند.

مثال استفاده:

```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```

## **مزایای کلیدی متدهای PresentationFactory**

- **نیازی به بارگذاری کامل ارائه‌ها نیست**: مصرف حافظه را به حداقل می‌رساند و سرعت پردازش را افزایش می‌دهد.  
- **بهینه برای فایل‌های بزرگ**: حتی ارائه‌های حجم‌دار را به‌طور کارآمدی مدیریت می‌کند و متن را به سرعت استخراج می‌نماید.  
- **استخراج یادداشت‌ها و نظرات**: حاوی حاشیه‌نویسی‌های کاربر برای پوشش جامع محتواست.  
- **ایده‌آل برای ایندکس‌گذاری و تحلیل محتوا**: مناسب برای سیستم‌های سازمانی که به **پردازش خودکار** و غنی‌سازی داده‌ها نیاز دارند.  
- **مستقل از Office**: بدون نیاز به نصب Microsoft PowerPoint کار می‌کند و راه‌حلی **استندالون** واقعی ارائه می‌دهد.  
- **پشتیبانی از فرمت‌های چندگانه**: به‌صورت یکپارچه با **PPT، PPTX و ODP** کار می‌کند.  
- **API انعطاف‌پذیر و قدرتمند**: متدهای متنوعی برای **استخراج متن ساختار یافته** فراهم می‌کند.  
- **پوشش کامل اسلایدها**: متن را از **طرح‌بندی‌ها، اسلایدهای اصلی، اسلایدهای استاندارد، پس‌زمینه‌ها، یادداشت‌های سخنران و نظرات** استخراج می‌کند.  
- **سازگاری چندپلتفرمی**: بر روی **Windows، Linux، macOS** و در محیط‌های ابری قابل اجراست.  
- **عملکرد بالا و مقیاس‌پذیری**: برای **برنامه‌های SaaS** و استقرارهای بزرگ سازمانی مناسب است.

## **سیستم‌عامل‌های پشتیبانی‌شده**

Aspose.Slides بر روی انواع مختلفی از سیستم‌عامل‌ها اجرا می‌شود:

- **Windows** (مانند Windows 7، 8، 10، 11 و نسخه‌های Server)  
- **Linux** (توزیع‌های مختلف شامل Ubuntu، Debian، Fedora، CentOS و غیره)  
- **macOS** (شامل نسخه‌های مدرن مانند 10.15 Catalina و بعد از آن)

## **زبان‌های برنامه‌نویسی پشتیبانی‌شده**

Aspose.Slides با چندین پلتفرم و زبان ادغام می‌شود:

- **C#** – عمدتاً از طریق Aspose.Slides برای .NET پشتیبانی می‌شود.  
- **Java** – API کامل با Aspose.Slides برای Java در دسترس است.  
- **C++** – از Aspose.Slides برای برنامه‌های حساس به عملکرد در C++ استفاده کنید.  
- **Python via .NET** – قابلیت استفاده از Aspose.Slides را از طریق قابلیت‌های تعاملی .NET فراهم می‌کند.  
- **سایر زبان‌های سازگار با .NET** – کتابخانه را در هر محیطی که .NET پشتیبانی می‌کند، قابل استفاده است.

## **نتیجه‌گیری**

Aspose.Slides **استخراج متن جامع** را برای ارائه‌های PowerPoint و OpenDocument فراهم می‌کند و از **فرمت‌های مختلف فایل، ساختاردهی متن بصری و پیاده‌سازی ساده** نسبت به Open XML SDK پشتیبانی می‌کند. از **اسلایدها و یادداشت‌ها تا محتوای قالب**، **Aspose.Slides** یک راه‌حل کارآمد، پر ویژگی و با کارایی بالا برای استخراج و مدیریت متن ارائه‌هاست.