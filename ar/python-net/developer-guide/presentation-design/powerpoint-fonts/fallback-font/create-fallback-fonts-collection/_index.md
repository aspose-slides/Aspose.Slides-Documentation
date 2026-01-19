---
title: تهيئة مجموعات الخطوط الاحتياطية في بايثون
linktitle: مجموعة الخطوط الاحتياطية
type: docs
weight: 20
url: /ar/python-net/create-fallback-fonts-collection/
keywords:
- خط احتياطي
- قاعدة احتياطية
- مجموعة خطوط
- تهيئة الخط
- إعداد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides لبايثون عبر .NET للحفاظ على النص متسقًا وواضحًا في عروض PowerPoint وOpenDocument."
---

## **تطبيق قواعد الاستبدال**

يمكن تنظيم كائنات [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/). يمكن إضافة أو إزالة القواعد من المجموعة.

يمكن بعد ذلك تعيين هذه المجموعة إلى خاصية [font_fall_back_rules_collection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) للفئة [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/). يتحكم FontsManager في الخطوط عبر العرض التقديمي.

كل [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يحتوي على خاصية [fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) به واقعه الخاص من فئة FontsManager.

إليك مثالًا على كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها في FontsManager لعرض تقديمي معين:  
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
اقرأ المزيد حول كيفية [عرض العرض التقديمي مع الخط الاحتياطي](/slides/ar/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل سيتم تضمين قواعد الاستبدال في ملف PPTX وستكون مرئية في PowerPoint بعد الحفظ؟**

لا. قواعد الاستبدال هي إعدادات عرض وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل ينطبق الاستبدال على النص داخل SmartArt وWordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الرموز لأي نص في هذه الكائنات.

**هل تُوزِّع Aspose أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتتحمل المسؤولية الذاتية.

**هل يمكن استخدام الاستبدال/الاستبدال للخطوط المفقودة والاستبدال للرموز المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان في نفس خط أنابيب حل الخطوط: أولاً يقوم المحرك بحل توفر الخطوط ([replacement](/slides/ar/python-net/font-replacement/)/[substitution](/slides/ar/python-net/font-substitution/))، ثم يقوم الاستبدال بملء الفجوات للرموز المفقودة في الخطوط المتاحة.