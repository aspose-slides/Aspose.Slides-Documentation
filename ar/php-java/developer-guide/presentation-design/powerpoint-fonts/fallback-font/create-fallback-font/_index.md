---
title: تحديد الخطوط الاحتياطية للعروض التقديمية في PHP
linktitle: خط احتياطي
type: docs
weight: 10
url: /ar/php-java/create-fallback-font/
keywords:
- خط احتياطي
- قاعدة احتياطي
- تطبيق الخط
- استبدال الخط
- نطاق Unicode
- حرف مفقود
- حرف صحيح
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اتقن Aspose.Slides لـ PHP عبر Java لتعيين الخطوط الاحتياطية في ملفات PPT و PPTX و ODP، مما يضمن عرض النص المتسق على أي جهاز أو نظام تشغيل."
---

## **قواعد الخط الاحتياطي**

Aspose.Slides يدعم واجهة [IFontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRule) وفئة [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) لتحديد القواعد التي تُطبق خطًا احتياطيًا. فئة [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) تمثل ارتباطًا بين نطاق Unicode المحدد، المستخدم للبحث عن الحروف المفقودة، وقائمة الخطوط التي قد تحتوي على الحروف المناسبة:
```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```


يمكن أيضًا [remove](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) خطًا احتياطيًا أو [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) قائم.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) لتنظيم قائمة كائنات [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) عند الحاجة إلى تحديد قواعد استبدال الخط الاحتياطي لعدة نطاقات Unicode.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين الخط الاحتياطي، استبدال الخط، وتضمين الخط؟**

يُستخدم الخط الاحتياطي فقط للأحرف التي لا توجد في الخط الأساسي. [استبدال الخط](/slides/ar/php-java/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [تضمين الخط](/slides/ar/php-java/embedded-font/) يضم الخطوط داخل ملف الإخراج بحيث يمكن للمستلمين عرض النص كما هو مقصود.

**هل يتم تطبيق الخطوط الاحتياطية أثناء التصدير مثل PDF أو PNG أو SVG، أم فقط عند العرض على الشاشة؟**

نعم. الخط الاحتياطي يؤثر على جميع [عمليات العرض والتصدير](/slides/ar/php-java/convert-presentation/) حيث يجب رسم الأحرف ولكنها غير موجودة في الخط الأصلي.

**هل تعديل إعدادات الخط الاحتياطي يغيّر ملف العرض نفسه، وهل يبقى الإعداد محفوظًا للفتح في المستقبل؟**

لا. قواعد الخط الاحتياطي هي إعدادات عرض وقت التشغيل في الشيفرة الخاصة بك؛ وهي لا تُخزن داخل ملف .pptx ولا تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة مجلدات الخطوط على اختيار الخط الاحتياطي؟**

نعم. المحرك يحدد الخطوط من المجلدات النظامية المتاحة وأي [مسارات إضافية](/slides/ar/php-java/custom-font/) تقدمها. إذا لم يكن الخط متاحًا فعليًا، لا يمكن لت rule التي تشير إليه أن تُطبق.

**هل يعمل الخط الاحتياطي مع WordArt وSmartArt والرسوم البيانية؟**

نعم. عندما تحتوي هذه الكائنات على نص، تُطبّق نفس آلية استبدال الأحرف لتصيير الأحرف المفقودة.