---
title: تحديد خطوط التعويض للعروض التقديمية في بايثون
linktitle: خط التعويض
type: docs
weight: 10
url: /ar/python-net/create-fallback-font/
keywords:
- خط التعويض
- قاعدة التعويض
- تطبيق الخط
- استبدال الخط
- نطاق يونيكود
- رمز مفقود
- رمز صحيح
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إتقان Aspose.Slides للبايثون عبر .NET لتعيين خطوط التعويض في ملفات PPT و PPTX و ODP، مع ضمان عرض نص متسق على أي جهاز أو نظام تشغيل."
---

## **تحديد خطوط التعويض**

يدعم Aspose.Slides الفئة [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) لتحديد القواعد التي تطبق خط التعويض. تمثل الفئة [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) ارتباطًا بين نطاق Unicode المحدد، المستخدم للبحث عن الرموز المفقودة، وقائمة من الخطوط التي قد تحتوي على الرموز الصحيحة:
```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```


من الممكن أيضًا [remove](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/remove/) خط التعويض أو [add_fall_back_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) في كائن [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) الموجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/)، عندما يكون هناك حاجة لتحديد قواعد استبدال خطوط التعويض لعدة نطاقات Unicode.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط التعويض](/slides/ar/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما الفرق بين خط التعويض، واستبدال الخط، وتضمين الخط؟**

يُستخدم خط التعويض فقط للأحرف التي لا توجد في الخط الأساسي. [Font substitution](/slides/ar/python-net/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [Font embedding](/slides/ar/python-net/embedded-font/) يضم الخطوط داخل ملف الإخراج بحيث يتمكن المستلمون من عرض النص كما هو مقصود.

**هل يتم تطبيق خطوط التعويض أثناء التصدير مثل PDF أو PNG أو SVG، أم فقط عند العرض على الشاشة؟**

نعم. يؤثر التعويض على جميع [rendering and export operations](/slides/ar/python-net/convert-presentation/) حيث يجب رسم الأحرف ولكنها غير موجودة في الخط المصدر.

**هل يؤدي تكوين التعويض إلى تغيير ملف العرض نفسه، وهل سيستمر الإعداد للفتح المستقبلي؟**

لا. قواعد التعويض هي إعدادات عرض وقت التشغيل في الكود الخاص بك؛ ليست مخزنة داخل ملف .pptx ولن تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة مجلدات الخطوط على اختيار التعويض؟**

نعم. تقوم الآلية بحل الخطوط من المجلدات النظامية المتاحة وأي [additional paths](/slides/ar/python-net/custom-font/) تقدمها. إذا لم يكن الخط متاحًا فعليًا، لا يمكن للقاعدة التي تشير إليه أن تُطبق.

**هل يعمل التعويض مع WordArt و SmartArt والرسوم البيانية؟**

نعم. عندما تحتوي هذه الكائنات على نص، يتم تطبيق نفس آلية استبدال الرموز لتصوير الأحرف المفقودة.