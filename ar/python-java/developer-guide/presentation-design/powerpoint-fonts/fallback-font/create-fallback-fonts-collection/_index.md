---
title: "تكوين مجموعات خطوط الاحتياطي في بايثون عبر جافا"
linktitle: "مجموعة خطوط الاحتياطي"
type: docs
weight: 20
url: /ar/python-java/create-fallback-fonts-collection/
keywords:
- "خط احتياطي"
- "قاعدة احتياطي"
- "مجموعة خطوط"
- "تكوين الخط"
- "إعداد الخط"
- PowerPoint
- OpenDocument
- "عرض تقديمي"
- Python
- Java
- Aspose.Slides
description: "إعداد مجموعة خطوط احتياطية في Aspose.Slides لبايثون عبر جافا للحفاظ على تماسك النص ووضوحه في عروض PowerPoint و OpenDocument."
---
## **نظرة عامة**

Aspose.Slides يسمح لك بتكوين مجموعة من قواعد الخطوط الاحتياطية للعرض التقديمي. تمثل كل قاعدة احتياطية فئة [FontFallBackRule](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontfallbackrule/) ويمكن إضافتها إلى [FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontfallbackrulescollection/).

بعد إنشاء المجموعة، يمكنك تعيينها باستخدام طريقة [setFontFallBackRulesCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) الخاصة بـ [FontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/). يتحكم [FontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/) في الخطوط عبر العرض التقديمي، ولكل كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) مثيله الخاص من [FontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/).

بمجرد تهيئة [FontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/) بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية المحددة أثناء عرض تقديمي.

## **تطبيق قواعد الخطوط الاحتياطية**

يمكن تنظيم كائنات فئة [FontFallBackRule](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontfallbackrule/) في [FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontfallbackrulescollection/). يمكنك إضافة أو إزالة القواعد من المجموعة.

يمكن بعد ذلك تعيين هذه المجموعة باستخدام طريقة [setFontFallBackRulesCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) في فئة [FontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/)، التي تتحكم في الخطوط عبر العرض التقديمي.

لكل [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) طريقة [getFontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getFontsManager) التي تُرجع مثيلها الخاص من فئة [FontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/).

يوضح المثال التالي كيفية إنشاء مجموعة قواعد الخطوط الاحتياطية وتعيينها إلى [FontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/) للعرض التقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

بعد تهيئة [FontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/) بمجموعة الخطوط الاحتياطية، يتم تطبيق الخطوط الاحتياطية أثناء عرض تقديمي.

{{% alert color="info" title="ملاحظة" %}}
اقرأ المزيد حول كيفية [تقديم عرض تقديمي باستخدام خط احتياطي](/slides/ar/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل ستُدمج قواعد الخطوط الاحتياطية الخاصة بي في ملف PPTX وتظهر في PowerPoint بعد الحفظ؟**

لا. قواعد الخطوط الاحتياطية هي إعدادات عرض في وقت التشغيل؛ لا يتم تسلسلها إلى ملف PPTX ولن تظهر في واجهة PowerPoint.

**هل يُطبق الخط الاحتياطي على النص داخل SmartArt وWordArt والرسوم البيانية والجداول؟**

نعم. يتم استخدام نفس آلية استبدال الحروف لأي نص في هذه الكائنات.

**هل تقوم Aspose بتوزيع أي خطوط مع المكتبة؟**

لا. تقوم بإضافة واستخدام الخطوط من جانبك وتكون مسؤوليتك الخاصة.

**هل يمكن استخدام استبدال/بديل الخطوط المفقودة والاحتياطي للرموز المفقودة معًا؟**

نعم. هما مرحلتان مستقلتان من نفس خط أنابيب حل الخطوط: أولاً يحلّ المحرك توافر الخطوط ([replacement](/slides/ar/python-java/font-replacement/)/[substitution](/slides/ar/python-java/font-substitution/))، ثم يملأ الاحتياطي الفجوات للرموز المفقودة في الخطوط المتوفرة.