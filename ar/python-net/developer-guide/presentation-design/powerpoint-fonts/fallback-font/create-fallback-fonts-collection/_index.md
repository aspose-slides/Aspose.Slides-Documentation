---
title: تكوين خطوط الفولباك في بايثون
linktitle: تكوين خطوط الفولباك
type: docs
weight: 20
url: /ar/python-net/create-fallback-fonts-collection/
keywords:
- خط احتياطي
- قاعدة الفولباك
- مجموعة الخطوط
- إعداد الخط
- تهيئة الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "إعداد مجموعة خطوط الفولباك في Aspose.Slides للبايثون عبر .NET للحفاظ على تناسق النص ووضوحه في عروض PowerPoint و OpenDocument."
---

## **تطبيق قواعد الفولباك**

يمكن تنظيم مثيلات فئة [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/)، التي تقوم بتنفيذ واجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/). يمكن إضافة أو إزالة القواعد من المجموعة.

بعد ذلك يمكن تعيين هذه المجموعة إلى خاصية [FontFallBackRulesCollection ](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) في فئة [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد [About FontsManager and FontsLoader](/slides/ar/python-net/about-fontsmanager-and-fontsloader/).

كل [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لديه خاصية [FontsManager ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) مع نسخة خاصة من فئة FontsManager.

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
اقرأ المزيد حول كيفية [Render Presentation with Fallback Font](/slides/ar/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم تضمين قواعد الفولباك الخاصة بي في ملف PPTX وستكون مرئية في PowerPoint بعد الحفظ؟**

لا. قواعد الفولباك هي إعدادات عرض وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق الفولباك على النص داخل SmartArt وWordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الحروف لأي نص في هذه الكائنات.

**هل تقوم Aspose بتوزيع أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتكون مسؤولًا عنها.

**هل يمكن استخدام الاستبدال/البديل للخطوط المفقودة والفولباك للرموز المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توافر الخطوط ([replacement](/slides/ar/python-net/font-replacement/)/[substitution](/slides/ar/python-net/font-substitution/))، ثم يقوم الفولباك بملء الفجوات للرموز المفقودة في الخطوط المتاحة.