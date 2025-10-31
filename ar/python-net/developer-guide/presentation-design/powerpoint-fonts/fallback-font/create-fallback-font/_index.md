---
title: تحديد خطوط بديلة للعروض التقديمية في بايثون
linktitle: خط بديل
type: docs
weight: 10
url: /ar/python-net/create-fallback-font/
keywords:
- خط بديل
- قاعدة بديلة
- تطبيق الخط
- استبدال الخط
- نطاق Unicode
- حرف مفقود
- حرف صحيح
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلّم Aspose.Slides لـ Python عبر .NET لتعيين خطوط بديلة في ملفات PPT و PPTX و ODP، مما يضمن عرض نص متسق على أي جهاز أو نظام تشغيل."
---

## **تحديد الخطوط البديلة**

يدعم Aspose.Slides واجهة [IFontFallBackRule] وفئة [FontFallBackRule] لتحديد القواعد التي تُطبق خطًا بديلًا. فئة [FontFallBackRule] تمثل ارتباطًا بين نطاق Unicode المحدد، المستخدم للبحث عن الحروف المفقودة، وقائمة من الخطوط التي قد تحتوي على الحروف الصحيحة:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

كما يمكن أيضًا [Remove()] الخط البديل أو [AddFallBackFonts()] في كائن [FontFallBackRule] الموجود.

يمكن استخدام [FontFallBackRulesCollection] لتنظيم قائمة من كائنات [FontFallBackRule]، عندما يكون هناك حاجة لتحديد قواعد استبدال الخطوط البديلة لعدة نطاقات Unicode.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط بديلة](/slides/ar/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما هو الفرق بين الخط البديل، واستبدال الخط، وتضمين الخط؟**

يُستخدم الخط البديل فقط للأحرف المفقودة في الخط الأساسي. تقوم [استبدال الخط](/slides/ar/python-net/font-substitution/) باستبدال الخط المحدد بالكامل بخط آخر. تقوم [تضمين الخط](/slides/ar/python-net/embedded-font/) بتعبئة الخطوط داخل ملف الإخراج بحيث يمكن للمستلمين عرض النص كما هو مقصود.

**هل يتم تطبيق الخطوط البديلة أثناء التصدير مثل PDF أو PNG أو SVG، أم فقط أثناء العرض على الشاشة؟**

نعم. تؤثر الخطوط البديلة على جميع [عمليات العرض والتصدير](/slides/ar/python-net/convert-presentation/) حيث يجب رسم الأحرف لكنها غير موجودة في الخط المصدر.

**هل يغيّر تكوين الخطوط البديلة ملف العرض نفسه، وهل سيستمر الإعداد في الفتحات المستقبلية؟**

لا. قواعد الخطوط البديلة هي إعدادات عرض وقت التشغيل في كودك؛ لا تُخزن داخل ملف .pptx ولن تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة مجلدات الخطوط على اختيار الخط البديل؟**

نعم. يقوم المحرك بحل الخطوط من المجلدات النظامية المتاحة وأي [مسارات إضافية](/slides/ar/python-net/custom-font/) توفرها. إذا لم يكن الخط متاحًا فعليًا، لا يمكن أن تُطبق القاعدة التي تشير إليه.

**هل يعمل الخط البديل مع WordArt و SmartArt والرسوم البيانية؟**

نعم. عندما تحتوي هذه الكائنات على نص، تُطبق نفس آلية استبدال الحروف لعرض الأحرف المفقودة.