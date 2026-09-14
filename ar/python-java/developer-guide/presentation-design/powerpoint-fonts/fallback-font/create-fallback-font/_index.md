---
title: تحديد خطوط الاحتياطي للعروض التقديمية في Python عبر Java
linktitle: خط احتياطي
type: docs
weight: 10
url: /ar/python-java/create-fallback-font/
keywords:
- خط احتياطي
- قاعدة احتياطي
- تطبيق الخط
- استبدال الخط
- نطاق Unicode
- رموز مفقودة
- رموز صحيحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إتقان Aspose.Slides للـ Python عبر Java لتعيين خطوط الاحتياطي في ملفات PPT و PPTX و ODP، وضمان عرض نص متسق على أي جهاز أو نظام تشغيل."
---
## **نظرة عامة**

تسمح لك Aspose.Slides بتحديد خطوط احتياطية لتص rendering العروض التقديمية وعمليات التصدير. تُستخدم الخطوط الاحتياطية عندما لا يحتوي الخط الأساسي على الرموز لبعض الأحرف.

يتم تكوين سلوك الخطوط الاحتياطية عبر قواعد الاحتياطي. كل قاعدة تربط نطاق Unicode بواحد أو أكثر من الخطوط التي قد تحتوي على الرموز المطلوبة. يمكنك تعريف قواعد لنطاقات أحرف مختلفة، وإضافة أو إزالة خطوط احتياطية من القواعد الموجودة، وتنظيم عدة قواعد في مجموعة قواعد الخطوط الاحتياطية.

قواعد الخطوط الاحتياطية هي إعدادات عرض في وقت التشغيل. لا تقوم بتعديل ملف العرض نفسه ولا يتم تخزينها داخل ملف PPTX.

## **قواعد الخطوط الاحتياطية**

توفر Aspose.Slides الفئة [FontFallBackRule](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontfallbackrule/) لتحديد قواعد تطبيق الخطوط الاحتياطية. تمثل هذه الفئة ارتباطًا بين نطاق Unicode يُستخدم للبحث عن الرموز المفقودة وقائمة من الخطوط التي قد تحتوي على الرموز المطلوبة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# استخدم طرقًا متعددة لتحديد قائمة الخطوط.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

يمكنك أيضًا إزالة خط احتياطي باستخدام [remove](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontfallbackrule/#remove) أو إضافة خطوط احتياطية باستخدام [addFallBackFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) في كائن [FontFallBackRule](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontfallbackrule/) موجود.

يمكن لـ [FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontfallbackrulescollection/) تنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontfallbackrule/) عندما تحتاج إلى تحديد قواعد استبدال الخطوط الاحتياطية لعدة نطاقات Unicode.

{{% alert color="info" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما هو الفرق بين الخط الاحتياطي، واستبدال الخط، وتضمين الخط؟**

يُستخدم الخط الاحتياطي فقط للأحرف التي لا تتوافر في الخط الأساسي. [Font substitution](/slides/ar/python-java/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [Font embedding](/slides/ar/python-java/embedded-font/) يدمج الخطوط داخل ملف الإخراج بحيث يتمكن المتلقون من عرض النص كما هو مقصود.

**هل يتم تطبيق الخطوط الاحتياطية أثناء عمليات التصدير مثل PDF أو PNG أو SVG، أم فقط أثناء العرض على الشاشة؟**

نعم. تؤثر الخطوط الاحتياطية على جميع [عمليات العرض والتصدير](/slides/ar/python-java/convert-presentation/) حيث يلزم رسم الأحرف ولكنها غير موجودة في الخط المصدر.

**هل يغيّر تكوين الخطوط الاحتياطية ملف العرض نفسه، وهل ستستمر الإعدادات في الفتحات المستقبلية؟**

لا. قواعد الخطوط الاحتياطية هي إعدادات عرض في وقت التشغيل في الشفرة الخاصة بك؛ لا يتم تخزينها داخل ملف .pptx ولن تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة دلائل الخطوط على اختيار الخطوط الاحتياطية؟**

نعم. يقوم المحرك باستخراج الخطوط من المجلدات النظامية المتاحة وأي [مسارات إضافية](/slides/ar/python-java/custom-font/) تقوم بتوفيرها. إذا لم يكن الخط متاحًا فعليًا، فإن القاعدة التي تشير إليه لا يمكن أن تُطبق.

**هل يعمل الخط الاحتياطي مع WordArt وSmartArt والمخططات؟**

نعم. عندما تحتوي هذه الكائنات على نص، يُطبق نفس آلية استبدال الرموز لعرض الأحرف المفقودة.