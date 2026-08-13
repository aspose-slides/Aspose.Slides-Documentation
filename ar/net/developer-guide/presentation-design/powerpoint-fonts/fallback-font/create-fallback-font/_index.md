---
title: تحديد الخطوط الاحتياطية للعروض التقديمية في .NET
linktitle: خط احتياطي
type: docs
weight: 10
url: /ar/net/create-fallback-font/
keywords:
- خط احتياطي
- قاعدة احتياطية
- تطبيق الخط
- استبدال الخط
- نطاق Unicode
- رمز مفقود
- رمز صحيح
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلّم Aspose.Slides لـ .NET لتعيين الخطوط الاحتياطية في ملفات PPT و PPTX و ODP، مما يضمن عرض نص متسق على أي جهاز أو نظام تشغيل."
---
## **نظرة عامة**

Aspose.Slides تتيح لك تحديد خطوط احتياطية لتصميم العرض وتصديره. تُستخدم الخطوط الاحتياطية عندما لا يحتوي الخط الأساسي على رموز الأحرف المطلوبة.

يتم تكوين سلوك الخط الاحتياطي من خلال قواعد الخط الاحتياطي. كل قاعدة تربط نطاق يونيكود بواحد أو أكثر من الخطوط التي قد تحتوي على الرموز المطلوبة. يمكنك تعريف قواعد لنطاقات أحرف مختلفة، إضافة أو إزالة خطوط احتياطية من القواعد الحالية، وتنظيم عدة قواعد في مجموعة قواعد الخطوط الاحتياطية.

قواعد الخط الاحتياطي هي إعدادات عرض زمن التنفيذ. لا تقوم بتعديل ملف العرض نفسه ولا يتم تخزينها داخل ملف PPTX.

## **قواعد الخطوط الاحتياطية**

Aspose.Slides يدعم الواجهة [IFontFallBackRule](https://reference.aspose.com/slides/ar/net/aspose.slides/iFontFallBackRule) والفئة [FontFallBackRule](https://reference.aspose.com/slides/ar/net/aspose.slides/FontFallBackRule) لتحديد القواعد التي تُطبق الخط الاحتياطي. الفئة [FontFallBackRule](https://reference.aspose.com/slides/ar/net/aspose.slides/FontFallBackRule) تمثل ارتباطًا بين نطاق يونيكود المحدد، المستخدم للبحث عن الرموز المفقودة، وقائمة بالخطوط التي قد تحتوي على الرموز المناسبة:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

كما يمكن أيضًا [Remove()](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontfallbackrule/methods/remove) الخط الاحتياطي أو [AddFallBackFonts()](https://reference.aspose.com/slides/ar/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/ar/net/aspose.slides/FontFallBackRule) الموجود.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/ar/net/aspose.slides/fontfallbackrulescollection) يمكن استخدامها لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/ar/net/aspose.slides/FontFallBackRule) عندما يكون هناك حاجة لتحديد قواعد استبدال الخطوط الاحتياطية لعدة نطاقات يونيكود.

{{% alert color="info" title="See also" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة الشائعة**

### ما الفرق بين الخط الاحتياطي، واستبدال الخط، وتضمين الخط؟

الخط الاحتياطي يُستخدم فقط للأحرف المفقودة في الخط الأساسي. [استبدال الخط](/slides/ar/net/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [تضمين الخط](/slides/ar/net/embedded-font/) يضمّن الخطوط داخل ملف الإخراج لكي يتمكن المستلمون من عرض النص كما هو مقصود.

### هل تُطبق الخطوط الاحتياطية أثناء تصدير ملفات مثل PDF أو PNG أو SVG، أم فقط أثناء العرض على الشاشة؟

نعم. الخط الاحتياطي يؤثر على جميع [عمليات العرض والتصدير](/slides/ar/net/convert-presentation/) حيث يجب رسم الأحرف ولكنها غير موجودة في الخط الأصلي.

### هل يؤدي تكوين الخط الاحتياطي إلى تعديل ملف العرض نفسه، وهل سيستمر الإعداد للمستقبل؟

لا. قواعد الخط الاحتياطي هي إعدادات عرض زمن التنفيذ في الشيفرة الخاصة بك؛ لا يتم تخزينها داخل ملف .pptx ولن تظهر في برنامج PowerPoint.

### هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعات مجلدات الخطوط على اختيار الخط الاحتياطي؟

نعم. المحرك يحدد الخطوط من مجلدات النظام المتاحة وأي [مسارات إضافية](/slides/ar/net/custom-font/) تقوم بتوفيرها. إذا لم يكن الخط موجودًا فعليًا، فلا يمكن للقاعدة التي تشير إليه أن تُطبق.

### هل يعمل الخط الاحتياطي مع WordArt وSmartArt والمخططات؟

نعم. عندما تحتوي هذه العناصر على نص، يتم تطبيق نفس آلية استبدال الرموز لعرض الأحرف المفقودة.