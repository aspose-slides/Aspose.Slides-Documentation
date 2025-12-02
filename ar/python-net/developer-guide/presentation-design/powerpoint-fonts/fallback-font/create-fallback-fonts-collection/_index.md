---
title: تكوين مجموعات خطوط الاحتياطي في بايثون
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
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides للبايثون عبر .NET للحفاظ على النص متسقًا وواضحًا في عروض PowerPoint وOpenDocument."
---

## **تطبيق قواعد الاحتياطي**

يمكن تنظيم كائنات [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) class في [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/)، التي تنفذ الواجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/). يمكن إضافة أو إزالة القواعد من المجموعة.

ثم يمكن تعيين هذه المجموعة إلى خاصية [FontFallBackRulesCollection ](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)property من فئة [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) . يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد من [About FontsManager and FontsLoader](/slides/ar/python-net/about-fontsmanager-and-fontsloader/).

كل [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يحتوي على خاصية [FontsManager ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) مع نسخة خاصة من فئة FontsManager.

فيما يلي مثال على كيفية إنشاء مجموعة قواعد خطوط الاحتياطي وتعيينها في FontsManager لعرض تقديمي معين:  
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


بعد تهيئة FontsManager بمجموعة خطوط الاحتياطي، يتم تطبيق خطوط الاحتياطي أثناء عرض التقديم.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [Render Presentation with Fallback Font](/slides/ar/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم تضمين قواعد الاحتياطي في ملف PPTX وستكون مرئية في PowerPoint بعد الحفظ؟**

لا. قواعد الاحتياطي هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق السقوط الاحتياطي على النص داخل SmartArt وWordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الحروف لأي نص في هذه الكائنات.

**هل تقوم Aspose بتوزيع أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتكون مسؤولاً عنها.

**هل يمكن استخدام الاستبدال/الاستبدال للخطوط المفقودة والسقوط الاحتياطي للرموز المفقودة معًا؟**

نعم. إنها مراحل مستقلة من نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توفر الخطوط ([replacement](/slides/ar/python-net/font-replacement/)/[substitution](/slides/ar/python-net/font-substitution/))، ثم يملأ السقوط الاحتياطي الفجوات للرموز المفقودة في الخطوط المتاحة.