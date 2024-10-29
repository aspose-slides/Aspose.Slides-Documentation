---
title: إنشاء مجموعة خطوط احتياطية
type: docs
weight: 20
url: /ar/python-net/create-fallback-fonts-collection/
keywords: "مجموعة خطوط احتياطية، عرض PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "مجموعة خطوط احتياطية في PowerPoint باستخدام بايثون"
---

يمكن تنظيم كInstances من [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/)، التي تنفذ [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/) واجهة. من الممكن إضافة أو إزالة قواعد من المجموعة.

ثم يمكن تعيين هذه المجموعة إلى [FontFallBackRulesCollection ](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)خاصية من فئة [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) . يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد [حول FontsManager وFontsLoader](/slides/ar/python-net/about-fontsmanager-and-fontsloader/).

كل [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)لها خاصية [FontsManager ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) مع مثيل خاص بها من فئة FontsManager.

إليك مثال حول كيفية إنشاء مجموعة قواعد خطوط احتياطية وتعيينها إلى FontsManager لعرض تقديمي معين:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

بعد تهيئة FontsManager باستخدام مجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض العرض التقديمي.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض عرض تقديمي بخط احتياطي](/slides/ar/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}