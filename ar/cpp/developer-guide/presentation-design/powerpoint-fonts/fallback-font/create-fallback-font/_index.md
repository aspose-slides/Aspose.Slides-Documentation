---
title: تحديد خطوط احتياطية للعرض التقديمي في C++
linktitle: خط احتياطي
type: docs
weight: 10
url: /ar/cpp/create-fallback-font/
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
- presentation
- C++
- Aspose.Slides
description: "تحكم في Aspose.Slides للغة C++ لتعيين الخطوط الاحتياطية في ملفات PPT و PPTX و ODP، مما يضمن عرض نص موحد على أي جهاز أو نظام تشغيل."
---
## **نظرة عامة**

Aspose.Slides يتيح لك تحديد خطوط احتياطية لعملية عرض الشرائح وعمليات التصدير. تُستخدم الخطوط الاحتياطية عندما لا يحتوي الخط الأساسي على رموز (glyphs) لأحرف معينة.

يتم تكوين سلوك الخط الاحتياطي من خلال قواعد الاحتياطي. كل قاعدة تربط نطاق Unicode بواحد أو أكثر من الخطوط التي قد تحتوي على الرموز المطلوبة. يمكنك تعريف قواعد لنطاقات أحرف مختلفة، إضافة أو إزالة خطوط احتياطية من القواعد الموجودة، وتنظيم عدة قواعد في مجموعة قواعد الخطوط الاحتياطية.

قواعد الاحتياطي هي إعدادات عرض في وقت التشغيل. هي لا تعدل ملف العرض نفسه ولا تُحفظ داخل ملف PPTX.

## **قواعد الاحتياطي**

Aspose.Slides يدعم واجهة [IFontFallBackRule](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontfallbackrule/) وفئة [FontFallBackRule](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/) لتحديد القواعد التي تُطبق الخط الاحتياطي. فئة [FontFallBackRule](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/) تمثل ارتباطًا بين نطاق Unicode المحدد، المستخدم للبحث عن الرموز المفقودة، وقائمة من الخطوط التي قد تحتوي على الرموز المناسبة:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

كما يمكن أيضًا [Remove()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontfallbackrule/remove/) الخط الاحتياطي أو [AddFallBackFonts()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/) الموجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrulescollection/) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/)، عندما يكون هناك حاجة لتحديد قواعد استبدال الخطوط الاحتياطية لعدة نطاقات Unicode.

{{% alert color="info" title="انظر أيضاً" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة الشائعة**

### ما الفرق بين الخط الاحتياطي، استبدال الخط، وتضمين الخط؟

الخط الاحتياطي يُستخدم فقط للأحرف المفقودة في الخط الأساسي. [استبدال الخط](/slides/ar/cpp/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [تضمين الخط](/slides/ar/cpp/embedded-font/) يمكّن من حزم الخطوط داخل ملف الإخراج بحيث يمكن للمتلقين عرض النص كما هو مقصود.

### هل تُطبق الخطوط الاحتياطية أثناء عمليات التصدير مثل PDF أو PNG أو SVG، أم فقط عند العرض على الشاشة؟

نعم. يؤثر الخط الاحتياطي على جميع [عمليات العرض والتصدير](/slides/ar/cpp/convert-presentation/) حيث يجب رسم الأحرف ولكنها غير موجودة في الخط المصدر.

### هل تغيير إعدادات الخط الاحتياطي يغيّر ملف العرض نفسه، وهل ستستمر الإعدادات في الفتحات المستقبلية؟

لا. قواعد الاحتياطي هي إعدادات عرض في وقت التشغيل في الكود الخاص بك؛ وهي لا تُحفظ داخل ملف .pptx ولن تظهر في PowerPoint.

### هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة دلائل الخطوط على اختيار الخط الاحتياطي؟

نعم. يقوم المحرك بحل الخطوط من المجلدات النظامية المتاحة وأي [مسارات إضافية](/slides/ar/cpp/custom-font/) تقوم بتوفيرها. إذا لم يكن الخط متاحًا فعليًا، لا يمكن للقاعدة التي تشير إليه أن تُطبق.

### هل يعمل الخط الاحتياطي مع WordArt وSmartArt والرسوم البيانية؟

نعم. عندما تحتوي هذه الكائنات على نص، تُطبق نفس آلية استبدال الرموز لعرض الأحرف المفقودة.