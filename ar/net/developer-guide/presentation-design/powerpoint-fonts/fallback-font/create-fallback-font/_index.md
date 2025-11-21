---
title: إنشاء خط احتياطي
type: docs
weight: 10
url: /ar/net/create-fallback-font/
keywords: "الخطوط, الخط الاحتياطي, عرض بوربوينت C#, Csharp, Aspose.Slides for .NET"
description: "خط احتياطي في بوربوينت في C# أو .NET"
---

## **قواعد الخطوط الاحتياطية**

تدعم Aspose.Slides واجهة [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) وفئة [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) لتحديد القواعد لتطبيق خط احتياطي. فئة [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) تمثل ارتباطًا بين نطاق Unicode المحدد، المستخدم للبحث عن الرموز المفقودة، وقائمة الخطوط التي قد تحتوي على الرموز الصحيحة:
```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


يمكن أيضًا [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) الخط الاحتياطي أو [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) في كائن [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) موجود.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) يمكن استخدامها لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule)، عندما يكون هناك حاجة لتحديد قواعد استبدال الخطوط الاحتياطية لنطاقات Unicode متعددة.

{{% alert color="primary" title="انظر أيضا" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما هو الفرق بين الخط الاحتياطي واستبدال الخط وتضمين الخط؟**

يُستخدم الخط الاحتياطي فقط للأحرف المفقودة في الخط الأساسي. [استبدال الخط](/slides/ar/net/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [تضمين الخط](/slides/ar/net/embedded-font/) يضع الخطوط داخل ملف الإخراج بحيث يستطيع المستقبلون عرض النص كما هو مقصود.

**هل يتم تطبيق الخطوط الاحتياطية أثناء تصدير الملفات مثل PDF أو PNG أو SVG، أم فقط أثناء العرض على الشاشة؟**

نعم. الخطوط الاحتياطية تؤثر على جميع [عمليات العرض والتصدير](/slides/ar/net/convert-presentation/) حيث يجب رسم الأحرف ولكنها غير موجودة في الخط الأصلي.

**هل يؤدي تكوين الخطوط الاحتياطية إلى تغيير ملف العرض نفسه، وهل سيظل الإعداد محفوظًا للفتح المستقبلي؟**

لا. قواعد الخطوط الاحتياطية هي إعدادات عرض في وقت التشغيل في الكود الخاص بك؛ لا يتم تخزينها داخل ملف .pptx ولا تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة مجلدات الخطوط على اختيار الخطوط الاحتياطية؟**

نعم. المحرك يحدد الخطوط من المجلدات النظامية المتاحة وأي [مسارات إضافية](/slides/ar/net/custom-font/) تقوم بتوفيرها. إذا لم يكن الخط متوفرًا فعليًا، فإن القاعدة التي تشير إليه لا يمكن أن تُطبق.

**هل يعمل الخط الاحتياطي مع WordArt وSmartArt والمخططات؟**

نعم. عندما تحتوي هذه الكائنات على نص، يُطبق نفس آلية استبدال الرموز لتصوير الأحرف المفقودة.