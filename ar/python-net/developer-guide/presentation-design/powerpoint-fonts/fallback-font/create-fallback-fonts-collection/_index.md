---
title: تكوين مجموعات خطوط الرجوع في Python
linktitle: مجموعة خطوط الرجوع
type: docs
weight: 20
url: /ar/python-net/create-fallback-fonts-collection/
keywords:
- خط رجوع
- قاعدة رجوع
- مجموعة خطوط
- تهيئة الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إعداد مجموعة خطوط الرجوع في Aspose.Slides لبايثون عبر .NET للحفاظ على تناسق النص وحدته في عروض PowerPoint وOpenDocument."
---

## **تطبيق قواعد الرجوع**

يمكن تنظيم مثيلات فئة [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/)، التي تنفّذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/). يمكن إضافة أو إزالة القواعد من المجموعة.

ثم يمكن تعيين هذه المجموعة إلى خاصية [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) في فئة [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد [About FontsManager and FontsLoader](/slides/ar/python-net/about-fontsmanager-and-fontsloader/).

كل [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يحتوي على خاصية [FontsManager ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) مع نسخة خاصة به من فئة FontsManager.

فيما يلي مثال على كيفية إنشاء مجموعة قواعد خطوط الرجوع وتعيينها في FontsManager لعرض تقديمي معين:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


بعد تهيئة FontsManager بمجموعة خطوط الرجوع، يتم تطبيق خطوط الرجوع أثناء عرض التقديم.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [Render Presentation with Fallback Font](/slides/ar/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل سيتم تضمين قواعد الرجوع في ملف PPTX وستظهر في PowerPoint بعد الحفظ؟**

لا. قواعد الرجوع هي إعدادات عرض في وقت التنفيذ؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق الرجوع على النص داخل SmartArt وWordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الحروف لأي نص في هذه العناصر.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط بنفسك وتتحمل المسؤولية.

**هل يمكن استخدام الاستبدال/الإحلال للخطوط المفقودة والرجوع للرموز المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان من نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توفر الخطوط ([replacement](/slides/ar/python-net/font-replacement/)/[substitution](/slides/ar/python-net/font-substitution/))، ثم يملأ الرجوع الفجوات للرموز المفقودة في الخطوط المتاحة.