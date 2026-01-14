---
title: تحديد الخطوط الاحتياطية للعروض التقديمية في PHP
linktitle: خط احتياطي
type: docs
weight: 10
url: /ar/php-java/create-fallback-font/
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
- PHP
- Aspose.Slides
description: "أتقن Aspose.Slides للـ PHP عبر Java لتعيين الخطوط الاحتياطية في ملفات PPT و PPTX و ODP، مما يضمن عرضًا ثابتًا للنص على أي جهاز أو نظام تشغيل."
---

## **قواعد الخطوط الاحتياطية**

يدعم Aspose.Slides الفئة [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) لتحديد القواعد التي يتم تطبيق خط احتياطي من خلالها. تمثل فئة [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) ارتباطًا بين نطاق Unicode المحدد، والذي يُستخدم للبحث عن الرموز المفقودة، وقائمة بالخطوط التي قد تحتوي على الرموز الصحيحة:
```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```


كما يمكن أيضًا [إزالة](https://reference.aspose.com/slides/php-java/aspose.slides/fontfallbackrule/remove/) الخط الاحتياطي أو [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) قائم.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) عندما يكون هناك حاجة إلى تحديد قواعد استبدال الخطوط الاحتياطية لنطاقات Unicode متعددة.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين الخط الاحتياطي، واستبدال الخط، وتضمين الخط؟**

يُستخدم الخط الاحتياطي فقط للأحرف المفقودة في الخط الأساسي. [Font substitution](/slides/ar/php-java/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [Font embedding](/slides/ar/php-java/embedded-font/) يضم الخطوط داخل ملف الإخراج بحيث يمكن للمستلمين عرض النص كما هو مقصود.

**هل تُطبق الخطوط الاحتياطية أثناء عمليات التصدير مثل PDF أو PNG أو SVG، أم فقط أثناء العرض على الشاشة؟**

نعم. يؤثر الخط الاحتياطي على جميع عمليات [rendering and export operations](/slides/ar/php-java/convert-presentation/) حيث يجب رسم الأحرف ولكنها غير موجودة في الخط المصدر.

**هل يغيّر تكوين الخط الاحتياطي ملف العرض نفسه، وهل سيظل الإعداد محفوظًا للفتح المستقبلي؟**

لا. تُعد قواعد الخط الاحتياطي إعدادات تصيير وقت التشغيل في شفرتك؛ فهي لا تُحفظ داخل ملف .pptx ولا تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة مجلدات الخطوط على اختيار الخط الاحتياطي؟**

نعم. يقوم المحرك بتحديد الخطوط من المجلدات النظامية المتاحة وأي [additional paths](/slides/ar/php-java/custom-font/) تقوم بتوفيرها. إذا لم يكن الخط متاحًا فعليًا، فإن القاعدة التي تشير إليه لا يمكن أن تُطبق.

**هل يعمل الخط الاحتياطي مع WordArt وSmartArt والرسوم البيانية؟**

نعم. عندما تحتوي هذه الكائنات على نص، تُطبق نفس آلية استبدال الرموز لتصrender الأحرف المفقودة.