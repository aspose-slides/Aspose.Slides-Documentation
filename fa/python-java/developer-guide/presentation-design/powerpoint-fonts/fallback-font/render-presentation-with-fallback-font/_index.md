---
title: رندر ارائه‌ها با فونت‌های جایگزین در پایتون از طریق جاوا
linktitle: رندر ارائه‌ها
type: docs
weight: 30
url: /fa/python-java/render-presentation-with-fallback-font/
keywords:
- فونت جایگزین
- رندر پاورپوینت
- رندر ارائه
- رندر اسلاید
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "رندر ارائه‌ها با فونت‌های جایگزین در Aspose.Slides برای پایتون از طریق جاوا – متن را در قالب‌های PPT، PPTX و ODP به صورت یکسان حفظ کنید با نمونه‌های کد پایتون گام‌به‌گام."
---
## **بررسی کلی**

Aspose.Slides به شما امکان رندر ارائه‌ها را با استفاده از قوانین فونت جایگزین می‌دهد. این مقاله نشان می‌دهد چگونه یک مجموعه قوانین فونت جایگزین ایجاد کنید، قوانین آن را با حذف یا افزودن فونت‌های جایگزین ویرایش کنید، و مجموعه را با استفاده از متد [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) اختصاص دهید.

پس از اختصاص مجموعه قوانین فونت جایگزین به [FontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/) ارائه، قوانین در طول عملیات‌هایی مانند ذخیره‌سازی، رندر و تبدیل ارائه اعمال می‌شوند. مثال نشان می‌دهد چگونه از قوانین پیکربندی‌شده هنگام رندر یک تصویر کوچک از اسلاید و ذخیره‌سازی آن به‌صورت تصویر JPEG استفاده شود.

## **رندر اسلاید با استفاده از قوانین فونت جایگزین**

مثال زیر شامل این مراحل است:

1. [Create a fallback font rules collection](/slides/fa/python-java/create-fallback-fonts-collection/).
2. [Remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontfallbackrule/#remove) یک فونت جایگزین از یک قانون و [add fallback fonts](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) به قانون دیگری.
3. Assign the rules collection using [setFontFallBackRulesCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) on the font manager returned by [getFontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getFontsManager).
4. از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) برای ذخیره‌سازی ارائه در همان قالب یا قالب دیگری استفاده کنید. پس از اختصاص مجموعه قوانین فونت جایگزین به [FontsManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fontsmanager/)، این قوانین در طول عملیات‌های مختلف روی ارائه اعمال می‌شوند: ذخیره‌سازی، رندر، تبدیل و غیره.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# ایجاد یک مجموعه قوانین جدید.
fallback_rules = FontFallBackRulesCollection()

# ایجاد چندین قانون.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # سعی کنید فونت جایگزین "Tahoma" را از قوانین حذف کنید.
    fallback_rule.remove("Tahoma")

    # به‌روزرسانی قوانین برای بازه مشخص‌شده.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# حذف یک قانون موجود، به‌طوری که حداقل یک قانون برای رندر باقی بماند.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # اختصاص مجموعه قوانین آماده‌شده.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # رندر تصویر کوچک با استفاده از مجموعه قوانین پیکربندی‌شده.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # ذخیره تصویر بر روی دیسک به فرمت JPEG.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
اطلاعات بیشتر در مورد نحوه تبدیل PPT و PPTX به JPG در پایتون از طریق جاوا را بخوانید.
{{% /alert %}}