---
title: تحديد خطوط احتياطية للعروض التقديمية على Android
linktitle: خط احتياطي
type: docs
weight: 10
url: /ar/androidjava/create-fallback-font/
keywords:
- خط احتياطي
- قاعدة احتياطية
- تطبيق الخط
- استبدال الخط
- نطاق Unicode
- حرف مفقود
- حرف صحيح
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "أتقن Aspose.Slides لنظام Android عبر Java لتعيين خطوط احتياطية في ملفات PPT, PPTX و ODP، مما يحافظ على عرض النص بشكل متسق على أي جهاز أو نظام تشغيل."
---

## **قواعد الخط الاحتياطي**

يدعم Aspose.Slides الواجهة [IFontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IFontFallBackRule) والفئة [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) لتحديد القواعد لتطبيق خط احتياطي. تمثل فئة [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) ارتباطًا بين نطاق Unicode المحدد، المستخدم للبحث عن الأحرف المفقودة، وقائمة من الخطوط التي قد تحتوي على الأحرف الصحيحة:
```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


كما يمكن أيضًا [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) الخط الاحتياطي أو [addFallBackFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule) موجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRulesCollection) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontFallBackRule)، عندما تكون هناك حاجة لتحديد قواعد استبدال الخطوط الاحتياطية لنطاقات Unicode متعددة.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما هو الفرق بين الخط الاحتياطي، استبدال الخط، وتضمين الخط؟**

يُستخدم الخط الاحتياطي فقط للأحرف المفقودة في الخط الأساسي. [Font substitution](/slides/ar/androidjava/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [Font embedding](/slides/ar/androidjava/embedded-font/) يضمن الخطوط داخل ملف الإخراج بحيث يمكن للمستلمين عرض النص كما هو مقصود.

**هل يتم تطبيق الخطوط الاحتياطية أثناء تصدير المستندات مثل PDF أو PNG أو SVG، أم فقط أثناء العرض على الشاشة؟**

نعم. يؤثر الخط الاحتياطي على جميع [عمليات العرض والتصدير](/slides/ar/androidjava/convert-presentation/) حيث يجب رسم الأحرف ولكنها غير موجودة في الخط الأصلي.

**هل تغيير إعدادات الخط الاحتياطي يغيّر ملف العرض نفسه، وهل سيستمر الإعداد في الفتحات المستقبلية؟**

لا. قواعد الخط الاحتياطي هي إعدادات عرض وقت التشغيل في الكود الخاص بك؛ لا تُحفظ داخل ملف .pptx ولن تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة مجلدات الخطوط على اختيار الخط الاحتياطي؟**

نعم. يقوم المحرك باستخراج الخطوط من المجلدات النظامية المتاحة وأي [مسارات إضافية](/slides/ar/androidjava/custom-font/) تقوم بتوفيرها. إذا لم يكن الخط متاحًا فعليًا، لا يمكن تطبيق قاعدة تشير إليه.

**هل يعمل الخط الاحتياطي مع WordArt وSmartArt والرسوم البيانية؟**

نعم. عندما تحتوي هذه الكائنات على نص، يُطبق نفس آلية استبدال الأحرف لعرض الأحرف المفقودة.