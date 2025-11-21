---
title: تحديد خطوط التراجع للعرض التقديمي في .NET
linktitle: خط التراجع
type: docs
weight: 10
url: /ar/net/create-fallback-font/
keywords:
- خط التراجع
- قاعدة التراجع
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
description: "إتقان Aspose.Slides لـ .NET لتعيين خطوط التراجع في ملفات PPT و PPTX و ODP، مع ضمان عرض نص موثوق على أي جهاز أو نظام تشغيل."
---

## **قواعد الفونت الاحتياطي**

Aspose.Slides يدعم الواجهة [IFontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/iFontFallBackRule) والفئة [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) لتحديد القواعد لتطبيق خط احتياطي. فئة [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) تمثل ارتباطًا بين نطاق Unicode المحدد، المستخدم للبحث عن الرموز المفقودة، وقائمة بالخطوط التي قد تحتوي على الرموز الصحيحة:
```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


يمكن أيضًا [Remove()](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrule/methods/remove) خط التراجع أو [AddFallBackFonts()](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) الحالي.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule)، عندما يكون هناك حاجة لتحديد قواعد استبدال خطوط التراجع لعدة نطاقات Unicode.

{{% alert color="primary" title="See also" %}} 
- [إنشاء مجموعة خطوط التراجع](/slides/ar/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما الفرق بين خط التراجع، واستبدال الخط، وتضمين الخط؟**

يُستخدم خط التراجع فقط للأحرف المفقودة في الخط الأساسي. [استبدال الخط](/slides/ar/net/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [تضمين الخط](/slides/ar/net/embedded-font/) يضم الخطوط داخل ملف الإخراج بحيث يمكن للمستلمين عرض النص كما هو مقصود.

**هل يتم تطبيق خطوط التراجع أثناء تصدير مثل PDF أو PNG أو SVG، أم فقط أثناء العرض على الشاشة؟**

نعم. يؤثر التراجع على جميع عمليات [عمليات العرض والتصدير](/slides/ar/net/convert-presentation/) حيث يجب رسم الأحرف لكنها غير موجودة في الخط المصدر.

**هل تغيير إعدادات التراجع يغير ملف العرض نفسه، وهل سيستمر الإعداد في الفتحات المستقبلية؟**

لا. قواعد التراجع هي إعدادات عرض وقت التشغيل في الكود الخاص بك؛ فهي لا تُخزن داخل ملف .pptx ولن تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة دلائل الخطوط على اختيار التراجع؟**

نعم. يقوم المحرك باكتشاف الخطوط من المجلدات النظامية المتاحة وأي [مسارات إضافية](/slides/ar/net/custom-font/) تقوم بتوفيرها. إذا لم يكن الخط متوفرًا فعليًا، لا يمكن أن تُطبق القاعدة التي تُشير إليه.

**هل يعمل التراجع مع WordArt و SmartArt والرسوم البيانية؟**

نعم. عندما تحتوي هذه العناصر على نص، يتم تطبيق نفس آلية استبدال الرموز لتصوير الأحرف المفقودة.