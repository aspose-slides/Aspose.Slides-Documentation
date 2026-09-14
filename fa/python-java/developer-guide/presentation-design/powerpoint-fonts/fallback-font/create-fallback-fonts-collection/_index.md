---
title: پیکربندی مجموعه‌های فونت پیش‌زمینه در پایتون از طریق جاوا
linktitle: مجموعه فونت پیش‌زمینه
type: docs
weight: 20
url: /fa/python-java/create-fallback-fonts-collection/
keywords:
- فونت پیش‌زمینه
- قاعده پیش‌زمینه
- مجموعه فونت
- پیکربندی فونت
- تنظیم فونت
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "یک مجموعه فونت پیش‌زمینه را در Aspose.Slides برای پایتون از طریق جاوا تنظیم کنید تا متن در ارائه‌های PowerPoint و OpenDocument یکنواخت و واضح باقی بماند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد مجموعه‌ای از قوانین فونت پیش‌زمینه را برای یک ارائه پیکربندی کنید. هر قانون پیش‌زمینه توسط کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontfallbackrule/) نمایش داده می‌شود و می‌تواند به یک [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontfallbackrulescollection/) اضافه شود.

پس از ایجاد مجموعه، می‌توانید آن را با استفاده از متد [setFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) کلاس [FontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/) ارائه اختصاص دهید. [FontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/) کنترل‌کننده‌ی فونت‌ها در کل ارائه است و هر نمونه‌ی [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) دارای یک [FontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/) مخصوص به خود می‌باشد.

به‌محض اینکه [FontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/) با مجموعه‌ی فونت‌های پیش‌زمینه مقداردهی اولیه شود، فونت‌های پیش‌زمینه‌ی مشخص‌شده در زمان رندر ارائه اعمال می‌شوند.

## **اعمال قوانین پیش‌زمینه**

نمونه‌های کلاس [FontFallBackRule](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontfallbackrule/) می‌توانند در یک [FontFallBackRulesCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontfallbackrulescollection/) سازماندهی شوند. می‌توانید قوانین را به مجموعه اضافه یا از آن حذف کنید.

این مجموعه سپس می‌تواند با استفاده از متد [setFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) کلاس [FontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/) که فونت‌ها را در سراسر ارائه کنترل می‌کند، اختصاص یابد.

هر [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) دارای متد [getFontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getFontsManager) است که نمونه‌ی خود را از کلاس [FontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/) برمی‌گرداند.

مثال زیر نشان می‌دهد چگونه یک مجموعه قوانین فونت پیش‌زمینه ایجاد و آن را به [FontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/) یک ارائه اختصاص دهیم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

بعد از اینکه [FontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/) با مجموعه‌ی فونت پیش‌زمینه مقداردهی اولیه شد، فونت‌های پیش‌زمینه در زمان رندر ارائه اعمال می‌شوند.

{{% alert color="info" title="Note" %}}
بیشتر درباره نحوه‌ی [render a presentation with a fallback font](/slides/fa/python-java/render-presentation-with-fallback-font/) بخوانید.
{{% /alert %}}

## **سوالات متداول**

**آیا قوانین پیش‌زمینه من در فایل PPTX جاسازی می‌شوند و پس از ذخیره در PowerPoint قابل مشاهده خواهند بود؟**

خیر. قوانین پیش‌زمینه تنظیمات رندر در زمان اجرا هستند؛ آنها به‌صورت سریالی در PPTX ذخیره نمی‌شوند و در رابط کاربری PowerPoint نمایش داده نمی‌شوند.

**آیا پیش‌زمینه برای متن داخل SmartArt، WordArt، نمودارها و جداول اعمال می‌شود؟**

بله. همان مکانیزم جایگزینی گلیف برای تمام متون موجود در این اشیاء استفاده می‌شود.

**آیا Aspose فونتی را همراه کتابخانه توزیع می‌کند؟**

خیر. شما فونت‌ها را به‌صورت محلی اضافه و استفاده می‌کنید و مسئولیت آن بر عهده‌ی خود شماست.

**آیا می‌توان جایگزینی/جایگزینی برای فونت‌های غیرداسته و پیش‌زمینه برای گلیف‌های مفقود را همزمان استفاده کرد؟**

بله. آنها مراحل مستقلی از همان خط لوله‌ی حل فونت هستند: ابتدا موتور در دسترس بودن فونت‌ها را حل می‌کند ([replacement](/slides/fa/python-java/font-replacement/)/[substitution](/slides/fa/python-java/font-substitution/))، سپس پیش‌زمینه خلأهای گلیف‌های مفقود در فونت‌های موجود را پر می‌کند.