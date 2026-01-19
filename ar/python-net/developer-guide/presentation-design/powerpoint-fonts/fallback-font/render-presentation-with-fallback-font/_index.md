---
title: عرض العروض مع خطوط احتياطية في بايثون
linktitle: عرض العروض
type: docs
weight: 30
url: /ar/python-net/render-presentation-with-fallback-font/
keywords:
- خط احتياطي
- عرض PowerPoint
- عرض العرض التقديمي
- عرض الشريحة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "عرض العروض مع خطوط احتياطية في Aspose.Slides لبايثون عبر .NET – حافظ على تناسق النص عبر PPT و PPTX و ODP مع أمثلة شفرة خطوة بخطوة."
---

المثال التالي يتضمن هذه الخطوات:

1. نقوم بـ[إنشاء مجموعة قواعد الخطوط الاحتياطية](/slides/ar/python-net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) قاعدة خط احتياطي و[AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) إلى قاعدة أخرى.
1. ضبط مجموعة القواعد إلى خاصية [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/).
1. باستخدام طريقة [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يمكننا حفظ العرض التقديمي بنفس الصيغة، أو حفظه بصيغة أخرى. بعد تعيين مجموعة قواعد الخطوط الاحتياطية إلى FontsManager، تُطبق هذه القواعد خلال أي عملية على العرض التقديمي: حفظ، تصيّر، تحويل، إلخ.
```py
import aspose.slides as slides

# إنشاء نسخة جديدة من مجموعة القواعد
rulesList = slides.FontFallBackRulesCollection()

# إنشاء عدد من القواعد
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# محاولة إزالة خط FallBack "Tahoma" من القواعد المحملة
	fallBackRule.remove("Tahoma")

	# ولتحديث القواعد للنطاق المحدد
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# يمكننا أيضًا إزالة أي قواعد موجودة من القائمة
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# تعيين قائمة القواعد المُحضرة للاستخدام
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# إنشاء صورة مصغرة باستخدام مجموعة القواعد المُهيأة وحفظها كملف PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```


{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [تحويل شرائح PowerPoint إلى PNG في Python](/slides/ar/python-net/convert-powerpoint-to-png/).
{{% /alert %}}