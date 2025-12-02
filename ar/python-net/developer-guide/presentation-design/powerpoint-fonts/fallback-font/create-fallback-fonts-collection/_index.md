---
title: تكوين مجموعات خطوط الاحتياطي في Python
linktitle: مجموعة خطوط الاحتياطي
type: docs
weight: 20
url: /ar/python-net/create-fallback-fonts-collection/
keywords:
- خط احتياطي
- قاعدة الاحتياطي
- مجموعة خطوط
- تكوين الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "قم بإعداد مجموعة خطوط احتياطية في Aspose.Slides لPython عبر .NET للحفاظ على النص متسقًا وواضحًا في عروض PowerPoint و OpenDocument."
---

## **تطبيق قواعد الاستدعاء الاحتياطي**

يمكن تنظيم مثيلات فئة [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/)، التي تنفذ الواجهة [IFontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrulescollection/). يمكن إضافة أو إزالة القواعد من المجموعة.

ثم يمكن تعيين هذه المجموعة إلى خاصية [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) للفئة [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). يتحكم FontsManager في الخطوط عبر العرض التقديمي. اقرأ المزيد [حول FontsManager و FontsLoader](/slides/ar/python-net/about-fontsmanager-and-fontsloader/).

كل [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يحتوي على خاصية [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) مع نسخة خاصة به من فئة FontsManager.

فيما يلي مثال على كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها في FontsManager لعرض تقديمي معين:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```


بعد تهيئة FontsManager بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض العرض التقديمي.

{{% alert color="primary" %}} 
اقرأ المزيد حول كيفية [عرض تقديمي مع خط احتياطي](/slides/ar/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل سيتم تضمين قواعد الاستدعاء الاحتياطي في ملف PPTX وستظهر في PowerPoint بعد الحفظ؟**

لا. قواعد الاستدعاء الاحتياطي هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولا ستظهر في واجهة PowerPoint.

**هل يُطبق الاستدعاء الاحتياطي على النص داخل SmartArt و WordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الحروف لأي نص في هذه الكائنات.

**هل توزع Aspose أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتكون مسؤولاً عنها.

**هل يمكن استخدام الاستبدال/البديل للخطوط المفقودة والرجوع للخطوط الاحتياطية للرموز المفقودة معًا؟**

نعم. إنهما مراحل مستقلة من نفس خط أنابيب حل الخطوط: أولاً تقوم المحرك بحل توافر الخطوط ([الاستبدال](/slides/ar/python-net/font-replacement/)/[البديل](/slides/ar/python-net/font-substitution/))، ثم يملأ الاستدعاء الاحتياطي الفجوات للرموز المفقودة في الخطوط المتاحة.