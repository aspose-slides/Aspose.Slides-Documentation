---
title: خروجی ارائه‌ها به XAML در Python via Java
linktitle: ارائه به XAML
type: docs
weight: 30
url: /fa/python-java/export-to-xaml/
keywords:
- خروجی PowerPoint
- خروجی OpenDocument
- خروجی ارائه
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
- خروجی PPT به XAML
- خروجی PPTX به XAML
- خروجی ODP به XAML
- پایتون
- جاوا
- Aspose.Slides
description: "خروجی ارائه‌های PowerPoint و OpenDocument به XAML با Aspose.Slides برای Python via Java. از گزینه‌های پیش‌فرض استفاده کنید یا اسلایدهای مخفی را شامل شوید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint و OpenDocument را با استفاده از Aspose.Slides for Python via Java به XAML صادر کنید. این مقاله XAML را معرفی می‌کند، نحوه صادرات با تنظیمات پیش‌فرض را نشان می‌دهد و نحوه گنجاندن اسلایدهای مخفی با [XamlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/) را به نمایش می‌گذارد.

نمونه‌ها به Aspose.Slides for Python via Java و یک محیط اجرایی Java سازگار نیاز دارند. فایل `pres.pptx` را در دایرکتوری کاری فعلی قرار دهید. هر نمونه فقط در صورتی JVM را راه‌اندازی می‌کند که قبلاً در حال اجرا نباشد.

## **درباره XAML**

XAML (Extensible Application Markup Language) زبانی مبتنی بر XML برای توصیف رابط‌های کاربری است. این زبان توسط چارچوب‌هایی مانند Windows Presentation Foundation (WPF) استفاده می‌شود. می‌توانید XAML را با یک طراح بصری یا یک ویرایشگر متن ایجاد و ویرایش کنید.

## **صادر کردن ارائه‌ها به XAML با تنظیمات پیش‌فرض**

یک [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) را از فایل ورودی ایجاد کنید، سپس [XamlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/) را به [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) پاس دهید تا با تنظیمات پیش‌فرض صادر شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **صادر کردن ارائه‌ها به XAML با تنظیمات سفارشی**

از [XamlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/) برای پیکربندی خروجی استفاده کنید. برای گنجاندن اسلایدهای مخفی، قبل از ذخیره‌سازی، متد [setExportHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) را با مقدار `True` فراخوانی کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**چگونه می‌توانم یک فونت جایگزین انتخاب کنم وقتی فونت اصلی در دسترس نیست؟**

از متد [setDefaultRegularFont](https://reference.aspose.com/slides/fa/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) روی شیء [XamlOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/) خود استفاده کنید تا یک فونت جایگزین مشخص کنید. مطمئن شوید فونت انتخاب‌شده در محیط خروجی موجود است.

**آیا می‌توانم علامت‌گذاری صادرشده را در هر چارچوب XAML استفاده کنم؟**

چارچوب‌های XAML از نظر عناصر و ویژگی‌های پشتیبانی شده متفاوت هستند. قبل از یکپارچه‌سازی علامت‌گذاری صادرشده در برنامه، آن را در چارچوب هدف خود آزمایش کنید.

**آیا اسلایدهای مخفی به طور پیش‌فرض صادر می‌شوند؟**

خیر. برای گنجاندن آن‌ها، متد [setExportHiddenSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) را با مقدار `True` فراخوانی کنید. اگر می‌خواهید حذف شوند، مقدار آن را `False` نگه دارید.