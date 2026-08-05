---
title: تحديد الخطوط الاحتياطية للعروض التقديمية في C++
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
- عرض تقديمي
- C++
- Aspose.Slides
description: "اتقن Aspose.Slides للـ C++ لتعيين الخطوط الاحتياطية في ملفات PPT و PPTX و ODP، مع ضمان عرض نص ثابت على أي جهاز أو نظام تشغيل."
---
## **نظرة عامة**

يتيح لك Aspose.Slides تحديد خطوط احتياطية لعرض العروض التقديمية وعمليات التصدير. تُستخدم الخطوط الاحتياطية عندما لا يحتوي الخط الأساسي على رموز الأحرف الخاصة.

يتم تكوين سلوك الخط الاحتياطي من خلال قواعد الخط الاحتياطي. كل قاعدة تربط نطاق Unicode بخط أو أكثر قد يحتوي على الرموز المطلوبة. يمكنك تعريف قواعد لنطاقات أحرف مختلفة، إضافة أو إزالة خطوط احتياطية من القواعد الموجودة، وتنظيم عدة قواعد في مجموعة قواعد خطوط احتياطية.

قواعد الخط الاحتياطي هي إعدادات عرض في وقت التشغيل. لا تقوم بتعديل ملف العرض نفسه ولا يتم تخزينها داخل ملف PPTX.

## **قواعد الخط الاحتياطي**

تدعم Aspose.Slides الواجهة [IFontFallBackRule](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontfallbackrule/) والفئة [FontFallBackRule](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/) لتحديد القواعد لتطبيق خط احتياطي. الفئة [FontFallBackRule](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/) تمثل ارتباطًا بين نطاق Unicode المحدد، المستخدم للبحث عن الرموز المفقودة، وقائمة من الخطوط التي قد تحتوي على الرموز الصحيحة:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segue UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

كما يمكن أيضًا [Remove()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontfallbackrule/remove/) الخط الاحتياطي أو [AddFallBackFonts()](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/) الموجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrulescollection/) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontfallbackrule/)، عندما يكون هناك حاجة لتحديد قواعد استبدال الخطوط الاحتياطية لنطاقات Unicode متعددة.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما الفرق بين الخط الاحتياطي، استبدال الخط، وتضمين الخط؟**

يُستخدم الخط الاحتياطي فقط للأحرف الغائبة في الخط الأساسي. [Font substitution](/slides/ar/cpp/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [Font embedding](/slides/ar/cpp/embedded-font/) يضم الخطوط داخل ملف الإخراج حتى يتمكن المستلمون من عرض النص كما هو مقصود.

**هل يتم تطبيق الخطوط الاحتياطية أثناء عمليات التصدير مثل PDF أو PNG أو SVG، أم فقط عند العرض على الشاشة؟**

نعم. يؤثر الخط الاحتياطي على جميع [عمليات العرض والتصدير](/slides/ar/cpp/convert-presentation/) حيث يجب رسم الأحرف ولكنها غير موجودة في الخط المصدر.

**هل تغيير إعدادات الخط الاحتياطي يغير ملف العرض نفسه، وهل سيستمر الإعداد في الفتحات المستقبلية؟**

لا. قواعد الخط الاحتياطي هي إعدادات عرض في وقت التشغيل في الشيفرة الخاصة بك؛ لا يتم تخزينها داخل ملف .pptx ولن تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة أدلة الخطوط على اختيار الخط الاحتياطي؟**

نعم. يقوم المحرك بحل الخطوط من المجلدات النظامية المتاحة وأي [مسارات إضافية](/slides/ar/cpp/custom-font/) تقوم بتوفيرها. إذا لم يكن الخط متاحًا فعليًا، فإن القاعدة التي تشير إليه لا يمكن أن تُطبق.

**هل يعمل الخط الاحتياطي مع WordArt وSmartArt والرسوم البيانية؟**

نعم. عندما تحتوي هذه الكائنات على نص، يتم تطبيق نفس آلية استبدال الرموز لعرض الأحرف المفقودة.