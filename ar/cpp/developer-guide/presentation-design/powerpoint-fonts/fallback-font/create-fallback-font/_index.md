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
- نطاق يونيكود
- رمز مفقود
- رمز صحيح
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعرّف على Aspose.Slides للغة C++ لضبط الخطوط الاحتياطية في ملفات PPT و PPTX و ODP، لضمان عرض نص متسق على أي جهاز أو نظام تشغيل."
---

## **قواعد الخط الاحتياطي**

يدعم Aspose.Slides الواجهة [IFontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/) والفئة [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) لتحديد القواعد لتطبيق خط احتياطي. تمثل فئة [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) ارتباطًا بين نطاق Unicode المحدد، المستخدم للبحث عن الرموز المفقودة، وقائمة الخطوط التي قد تحتوي على الرموز المناسبة:
``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```


كما يمكن أيضًا [Remove()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/remove/) خطًا احتياطيًا أو [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/) موجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrulescollection/) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontfallbackrule/)، عندما تكون هناك حاجة إلى تحديد قواعد استبدال الخطوط الاحتياطية لنطاقات Unicode متعددة.

{{% alert color="primary" title="انظر أيضًا" %}}
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما هو الفرق بين الخط الاحتياطي، Font substitution، وFont embedding؟**

يُستخدم الخط الاحتياطي فقط للحروف المفقودة في الخط الأساسي. [Font substitution](/slides/ar/cpp/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [Font embedding](/slides/ar/cpp/embedded-font/) يضم الخطوط داخل ملف الإخراج حتى يتمكن المستلمون من مشاهدة النص كما هو مقصود.

**هل يتم تطبيق الخطوط الاحتياطية أثناء التصدير مثل PDF أو PNG أو SVG، أم فقط عند العرض على الشاشة؟**

نعم. يؤثر الخط الاحتياطي على جميع [rendering and export operations](/slides/ar/cpp/convert-presentation/) حيث يجب رسم الأحرف ولكنها غير موجودة في الخط المصدر.

**هل يؤدي تكوين الخط الاحتياطي إلى تغيير ملف العرض نفسه، وهل ستستمر الإعدادات في الفتحات المستقبلية؟**

لا. قواعد الخط الاحتياطي هي إعدادات عرض في وقت التشغيل في الكود الخاص بك؛ لا تُخزن داخل ملف .pptx ولن تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة أدلة الخطوط على اختيار الخط الاحتياطي؟**

نعم. يقوم المحرك بحل الخطوط من المجلدات النظامية المتاحة وأي [additional paths](/slides/ar/cpp/custom-font/) تقدمها. إذا لم يكن الخط موجودًا فعليًا، لا يمكن لقاعدة تشير إليه أن تُطبّق.

**هل يعمل الخط الاحتياطي مع WordArt وSmartArt والمخططات؟**

نعم. عندما تحتوي هذه الكائنات على نص، يُطبق نفس آلية استبدال الرموز لعرض الأحرف المفقودة.