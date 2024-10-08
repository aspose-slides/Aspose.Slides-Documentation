---
title: استبدال الخط
type: docs
weight: 70
url: /ar/python-net/font-substitution/
keywords: "خط, استبدال الخط, عرض تقديمي PowerPoint, بايثون, Aspose.Slides لبايثون عبر .NET"
description: "استبدال الخط في PowerPoint باستخدام بايثون"
---

تتيح لك Aspose.Slides ضبط قواعد للخطوط تحدد ما يجب القيام به في ظروف معينة (على سبيل المثال، عندما لا يمكن الوصول إلى خط ما) بهذه الطريقة:

1. تحميل العرض التقديمي المعني.
2. تحميل الخط الذي سيتم استبداله.
3. تحميل الخط الجديد.
4. إضافة قاعدة للاستبدال.
5. إضافة القاعدة إلى مجموعة قواعد استبدال الخطوط في العرض التقديمي.
6. توليد صورة الشريحة لملاحظة التأثير.

هذا الشيفرة البرمجية في بايثون توضح عملية استبدال الخط:

```python
import aspose.slides as slides

# Loads a presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Loads the source font that will be replaced
    sourceFont = slides.FontData("SomeRareFont")

    # Load the new font
    destFont = slides.FontData("Arial")

    # Adds a font rule for font replacement
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Adds the rule to font substitute rules collection
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Adds the font rule collection to rule list
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial font will be used in place of SomeRareFont when the latter is inaccessible
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Saves the image to disk in the JPEG format
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="ملاحظة"  color="warning"   %}} 

قد ترغب في مشاهدة [**استبدال الخط**](/slides/ar/python-net/font-replacement/). 

{{% /alert %}}