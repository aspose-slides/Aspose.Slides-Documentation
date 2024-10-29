---
title: عرض العرض التقديمي بخط احتياطي
type: docs
weight: 30
url: /ar/python-net/render-presentation-with-fallback-font/
keywords: "خط احتياطي، عرض PowerPoint، عرض تقديمي PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "عرض PowerPoint بخط احتياطي في بايثون"
---

يتضمن المثال التالي هذه الخطوات:

1. نحن [ننشئ مجموعة قواعد الخطوط الاحتياطية](/slides/ar/python-net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) قاعدة خط احتياطي و [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) لقاعدة أخرى.
1. تعيين مجموعة القواعد إلى خاصية [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) .
1. باستخدام طريقة [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يمكننا حفظ العرض التقديمي بنفس التنسيق، أو حفظه بتنسيق آخر. بعد تعيين مجموعة قواعد الخطوط الاحتياطية إلى FontsManager، يتم تطبيق هذه القواعد خلال أي عمليات على العرض التقديمي: الحفظ، والعرض، والتحويل، إلخ.

```py
import aspose.slides as slides

# إنشاء مثيل جديد من مجموعة القواعد
rulesList = slides.FontFallBackRulesCollection()

# إنشاء عدد من القواعد
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# محاولة إزالة خط الاحتياطي "Tahoma" من القواعد المحملة
	fallBackRule.remove("Tahoma")

	# وتحديث القواعد للنطاق المحدد
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# أيضًا يمكننا إزالة أي قواعد موجودة من القائمة
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# تعيين قائمة القواعد المعدة للاستخدام
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# عرض الصورة المصغرة باستخدام مجموعة القواعد المهيأة وحفظها بصيغة PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```


{{% alert color="primary" %}} 
اقرأ المزيد عن [الحفظ والتحويل في العرض التقديمي](/slides/ar/python-net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}