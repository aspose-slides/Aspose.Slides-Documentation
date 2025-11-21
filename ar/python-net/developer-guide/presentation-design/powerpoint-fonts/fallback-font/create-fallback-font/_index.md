---
title: تحديد الخطوط الاحتياطية للعروض التقديمية في بايثون
linktitle: خط احتياطي
type: docs
weight: 10
url: /ar/python-net/create-fallback-font/
keywords:
- خط احتياطي
- قاعدة احتياطية
- تطبيق خط
- استبدال خط
- نطاق Unicode
- رموز مفقودة
- رموز صحيحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إتقان Aspose.Slides لـ Python عبر .NET لتعيين الخطوط الاحتياطية في ملفات PPT و PPTX و ODP، وضمان عرض نص متسق على أي جهاز أو نظام تشغيل."
---

## **تحديد الخطوط الاحتياطية**

يدعم Aspose.Slides واجهة [IFontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/iFontFallBackRule/) و‑فئة [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) لتحديد القواعد التي تُطبق الخط الاحتياطي. تمثّل فئة [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) ارتباطًا بين نطاق Unicode المحدد، والذي يُستخدَم للبحث عن الرموز المفقودة، وقائمة من الخطوط التي قد تحتوي على الرموز المناسبة:
```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```




يمكن أيضًا [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/ifontfallbackrule/) الخط الاحتياطي أو [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) موجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) عندما تحتاج إلى تحديد قواعد استبدال الخطوط الاحتياطية لعدة نطاقات Unicode.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/ar/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة المتداولة**

**ما الفرق بين الخط الاحتياطي، واستبدال الخط، وتضمين الخط؟**

يُستخدم الخط الاحتياطي فقط للأحرف المفقودة في الخط الأساسي. [استبدال الخط](/slides/ar/python-net/font-substitution/) يُستبدل الخط المحدد بالكامل بخط آخر. [تضمين الخط](/slides/ar/python-net/embedded-font/) يُضمن الخطوط داخل ملف الإخراج بحيث يمكن للمستلمين عرض النص كما هو مقصود.

**هل تُطبق الخطوط الاحتياطية أثناء التصدير مثل PDF أو PNG أو SVG، أم فقط عند العرض على الشاشة؟**

نعم. تؤثر الخطوط الاحتياطية على جميع عمليات [العرض والتصدير](/slides/ar/python-net/convert-presentation/) حيث يجب رسم الأحرف ولكنها غير موجودة في الخط الأصلي.

**هل يغيّر تكوين الخط الاحتياطي ملف العرض نفسه، وهل يبقى الإعداد محفوظًا للفتح المستقبلي؟**

لا. قواعد الخط الاحتياطي هي إعدادات عرض زمن تشغيل في الكود الخاص بك؛ لا تُحفظ داخل ملف .pptx ولن تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة دلائل الخطوط على اختيار الخط الاحتياطي؟**

نعم. المحرك يحدد الخطوط من المجلدات النظامية المتوفرة وأي [مسارات إضافية](/slides/ar/python-net/custom-font/) تقدّمها. إذا لم يكن الخط متاحًا فعليًا، لا يمكن للقاعدة التي تشير إليه أن تُفعَّل.

**هل يعمل الخط الاحتياطي مع WordArt وSmartArt والمخططات؟**

نعم. عند احتواء هذه الكائنات على نص، يُطبق نفس آلية استبدال الرموز لعرض الأحرف المفقودة.