---
title: تكوين مجموعات خطوط الاحتياطي في بايثون
linktitle: مجموعة خطوط الاحتياطي
type: docs
weight: 20
url: /ar/python-net/create-fallback-fonts-collection/
keywords:
- خط احتياطي
- قاعدة احتياطي
- مجموعة خطوط
- إعداد الخط
- تكوين الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "قم بإعداد مجموعة خطوط احتياطي في Aspose.Slides لبايثون عبر .NET للحفاظ على نص ثابت وواضح في عروض PowerPoint و OpenDocument."
---

## **تطبيق قواعد الاحتياطي**

يمكن تنظيم كائنات من الفئة [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) في مجموعة [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/)، التي تنفذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/). يمكن إضافة أو إزالة القواعد من المجموعة.

بعد ذلك يمكن تعيين هذه المجموعة إلى خاصية [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) في الفئة [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد [حول FontsManager و FontsLoader](/slides/ar/python-net/about-fontsmanager-and-fontsloader/).

كل [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يحتوي على خاصية [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) بمثابة مثيل خاص به من فئة FontsManager.

فيما يلي مثال على كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها في FontsManager لعرض تقديمي معين:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


بعد تهيئة FontsManager بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض التقديم.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض التقديمي مع خط احتياطي](/slides/ar/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل سيتم تضمين قواعد الاحتياطي في ملف PPTX وستكون مرئية في PowerPoint بعد الحفظ؟**

لا. قواعد الاحتياطي هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق الاحتياطي على النص داخل SmartArt و WordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الحروف لأي نص في هذه الكائنات.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. تقوم أنت بإضافة واستخدام الخطوط من جانبك وتتحمل المسؤولية عنها.

**هل يمكن استخدام الاستبدال/الإحلال للخطوط المفقودة والاحتياطي للرموز المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توفر الخطوط ([replacement](/slides/ar/python-net/font-replacement/)/[substitution](/slides/ar/python-net/font-substitution/))، ثم يملأ الاحتياطي الفجوات للرموز المفقودة في الخطوط المتاحة.