---
title: "مشخص کردن قلم‌های جایگزین برای ارائه‌ها در پایتون از طریق جاوا"
linktitle: "قلم جایگزین"
type: docs
weight: 10
url: /fa/python-java/create-fallback-font/
keywords:
- "قلم جایگزین"
- "قانون جایگزین"
- "اعمال قلم"
- "جایگزینی قلم"
- "بازه یونیکد"
- "گلیف گمشده"
- "گلیف صحیح"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Python"
- "Java"
- "Aspose.Slides"
description: "به‌کارگیری Aspose.Slides برای Python از طریق Java برای تنظیم قلم‌های جایگزین در فایل‌های PPT، PPTX و ODP به‌منظور حفظ نمایش ثابت متن بر روی هر دستگاه یا سیستم‌عامل."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد که قلم‌های جایگزین را برای رندرینگ و عملیات خروجی ارائه مشخص کنید. قلم‌های جایگزین زمانی استفاده می‌شوند که قلم اصلی گلیف‌های مربوط به برخی کاراکترها را نداشته باشد.

رفتار جایگزین از طریق قوانین جایگزین پیکربندی می‌شود. هر قانون یک بازه‌ی یونیکد را با یک یا چند قلم که ممکن است گلیف‌های مورد نیاز را داشته باشند، مرتبط می‌کند. می‌توانید قوانین برای بازه‌های کاراکتری مختلف تعریف کنید، قلم‌های جایگزین را به قوانین موجود اضافه یا حذف کنید، و چندین قانون را در یک مجموعه‌ی قوانین قلم‌های جایگزین سازماندهی کنید.

قوانین جایگزین تنظیمات رندرینگ زمان اجرا هستند. آن‌ها فایل ارائه را به‌صورت مستقیم تغییر نمی‌دهند و در فایل PPTX ذخیره نمی‌شوند.

## **قوانین جایگزین**

Aspose.Slides کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontfallbackrule/) را برای مشخص کردن قوانین اعمال قلم‌های جایگزین ارائه می‌دهد. این کلاس نشان‌دهنده‌ی ارتباطی بین بازه‌ی یونیکد برای جستجوی گلیف‌های گم‌گشته و فهرستی از قلم‌هاست که ممکن است گلیف‌های مورد نیاز را داشته باشند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# از چندین روش برای تعیین لیست قلم‌ها استفاده کنید.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

همچنین می‌توانید با استفاده از [remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontfallbackrule/#remove) یک قلم جایگزین را حذف کنید یا با استفاده از [addFallBackFonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) در یک شیء [FontFallBackRule](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontfallbackrule/) موجود، قلم‌های جایگزین اضافه کنید.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontfallbackrulescollection/) می‌تواند فهرستی از اشیاء [FontFallBackRule](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontfallbackrule/) را زمانی که نیاز به تعیین قوانین جایگزینی قلم برای بازه‌های یونیکد متعدد دارید، سازماندهی کند.

{{% alert color="info" title="موارد مرتبط" %}} 
- [ایجاد مجموعه قلم‌های جایگزین](/slides/fa/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **پرسش‌های متداول**

**تفاوت بین قلم جایگزین، جایگزینی قلم و جاسازی قلم چیست؟**

قلم جایگزین فقط برای کاراکترهایی که در قلم اصلی موجود نیستند، استفاده می‌شود. [جایگزینی قلم](/slides/fa/python-java/font-substitution/) کل قلم مشخص‌شده را با قلم دیگری جایگزین می‌کند. [جاسازی قلم](/slides/fa/python-java/embedded-font/) قلم‌ها را داخل فایل خروجی بسته‌بندی می‌کند تا گیرندگان بتوانند متن را همان‌گونه که منظور شده است، مشاهده کنند.

**آیا قلم‌های جایگزین در حین خروجی‌ها مانند PDF، PNG یا SVG اعمال می‌شوند یا فقط در رندرینگ روی صفحه نمایش؟**

بله. جایگزین بر تمام [عملیات رندرینگ و خروجی](/slides/fa/python-java/convert-presentation/) که در آن کاراکترها باید کشیده شوند ولی در قلم منبع موجود نیستند، تأثیر می‌گذارد.

**آیا پیکربندی جایگزین فایل ارائه را تغییر می‌دهد و آیا تنظیم برای بازکردن‌های آینده حفظ می‌شود؟**

خیر. قوانین جایگزین تنظیمات رندرینگ زمان اجرا در کد شما هستند؛ آن‌ها داخل فایل .pptx ذخیره نمی‌شوند و در PowerPoint نمایش داده نخواهند شد.

**آیا سیستم‌عامل (Windows/Linux/macOS) و مجموعهٔ مسیرهای قلم بر انتخاب جایگزین تأثیر می‌گذارد؟**

بله. موتور قلم‌ها را از پوشه‌های سیستم موجود و هر [مسیرهای اضافی](/slides/fa/python-java/custom-font/) که ارائه می‌دهید، پیدا می‌کند. اگر قلمی به طور فیزیکی در دسترس نباشد، قانونی که به آن اشاره دارد، اثر نخواهد کرد.

**آیا جایگزین برای WordArt، SmartArt و نمودارها کار می‌کند؟**

بله. زمانی که این اشیاء شامل متن می‌شوند، همان مکانیزم جایگزینی گلیف برای رندر کردن کاراکترهای گمشده اعمال می‌شود.