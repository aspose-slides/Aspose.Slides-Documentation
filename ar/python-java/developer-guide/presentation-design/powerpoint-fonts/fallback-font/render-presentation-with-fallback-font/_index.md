---
title: عرض العروض التقديمية باستخدام الخطوط الاحتياطية في Python عبر Java
linktitle: عرض العروض التقديمية
type: docs
weight: 30
url: /ar/python-java/render-presentation-with-fallback-font/
keywords:
- خط احتياطي
- عرض PowerPoint
- عرض العرض التقديمي
- عرض الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "عرض العروض التقديمية باستخدام الخطوط الاحتياطية في Aspose.Slides لـ Python عبر Java – حافظ على تناسق النص عبر صيغ PPT و PPTX و ODP مع أمثلة شفرة Python خطوة بخطوة."
---
## **نظرة عامة**

تسمح لك Aspose.Slides بعرض العروض التقديمية باستخدام قواعد الخطوط الاحتياطية. تُظهر هذه المقالة كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية، وتعديل قواعدها بإزالة أو إضافة خطوط احتياطية، وتعيين المجموعة باستخدام طريقة [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection).

بمجرد تعيين مجموعة قواعد الخطوط الاحتياطية إلى [FontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/) الخاص بالعرض التقديمي، تُطبق القواعد أثناء عمليات مثل الحفظ، العرض، وتحويل العرض التقديمي. يوضح المثال كيفية استخدام القواعد المكوَّنة عند عرض صورة مصغرة للشريحة وحفظها كصورة JPEG.

## **عرض شريحة باستخدام قواعد الخطوط الاحتياطية**

يتضمن المثال التالي الخطوات التالية:

1. [إنشاء مجموعة قواعد الخطوط الاحتياطية](/slides/ar/python-java/create-fallback-fonts-collection/).
2. [إزالة]({{guid_remove}}) خط احتياطي من قاعدة و[إضافة خطوط احتياطية]({{guid_add}}) إلى قاعدة أخرى.
3. تعيين مجموعة القواعد باستخدام [setFontFallBackRulesCollection] على مدير الخطوط المسترجع بواسطة [getFontsManager].
4. استخدم طريقة [Presentation.save] لحفظ العرض التقديمي بنفس الصيغة أو بصيغة أخرى. بعد تعيين مجموعة قواعد الخطوط الاحتياطية إلى [FontsManager]، تُطبق هذه القواعد أثناء عمليات العرض التقديمي: الحفظ، العرض، التحويل، وغيرها.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# إنشاء مجموعة قواعد جديدة.
fallback_rules = FontFallBackRulesCollection()

# إنشاء عدة قواعد.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # محاولة إزالة الخط الاحتياطي "Tahoma" من القواعد.
    fallback_rule.remove("Tahoma")

    # تحديث القواعد للنطاق المحدد.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# إزالة قاعدة موجودة، مع الحفاظ على قاعدة واحدة على الأقل للعرض.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # تعيين مجموعة القواعد المُعدة.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # عرض صورة مصغرة باستخدام مجموعة القواعد المُكوَّنة.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # حفظ الصورة على القرص بتنسيق JPEG.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
اقرأ المزيد حول كيفية [تحويل PPT و PPTX إلى JPG باستخدام Python عبر Java](/slides/ar/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}