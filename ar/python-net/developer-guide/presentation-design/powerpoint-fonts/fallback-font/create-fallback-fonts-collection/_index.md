---
title: تكوين مجموعات خطوط الاحتياطي في Python
linktitle: مجموعة خطوط الاحتياطي
type: docs
weight: 20
url: /ar/python-net/create-fallback-fonts-collection/
keywords:
- خط احتياطي
- قاعدة احتياطية
- مجموعة خطوط
- تكوين الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides لPython عبر .NET للحفاظ على تناسق النص وحدته في عروض PowerPoint و OpenDocument."
---

## **تطبيق قواعد الاحتياط**

يمكن تنظيم مثيلات فئة [FontFallBackRule] في [FontFallBackRulesCollection]. يمكن إضافة أو إزالة القواعد من المجموعة.

بعد ذلك يمكن تعيين هذه المجموعة إلى خاصية [font_fall_back_rules_collection] في فئة [FontsManager]. يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد عن [حول FontsManager و FontsLoader](/slides/ar/python-net/about-fontsmanager-and-fontsloader/).

كل [Presentation] يحتوي على خاصية [fonts_manager] مع مثيل خاص به من فئة FontsManager.

فيما يلي مثال على كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها إلى FontsManager لعرض تقديمي محدد:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


بعد تهيئة FontsManager بمجموعة قواعد الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء تصيير العرض التقديمي.

{{% alert color="primary" %}}
اقرأ المزيد حول كيفية [عرض تقديم مع خط احتياطي](/slides/ar/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم تضمين قواعد الاحتياط في ملف PPTX وستكون مرئية في PowerPoint بعد الحفظ؟**

لا. قواعد الاحتياط هي إعدادات تصيير في وقت التشغيل؛ لا يتم تسلسلها إلى PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق الاحتياط على النص داخل SmartArt و WordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الحروف لأي نص في هذه الكائنات.

**هل تقوم Aspose بتوزيع أي خط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتكون مسؤوليتك.

**هل يمكن استخدام الاستبدال/التعويض عن الخطوط المفقودة والاحتياط للرموز المفقودة معًا؟**

نعم. إنهما مرحلتان مستقلتان من نفس خط أنابيب حل الخطوط: أولًا يحل المحرك توافر الخطوط ([replacement](/slides/ar/python-net/font-replacement/)/[substitution](/slides/ar/python-net/font-substitution/)), ثم يملأ الاحتياط الفجوات للرموز المفقودة في الخطوط المتاحة.