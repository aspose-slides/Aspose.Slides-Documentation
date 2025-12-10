---
title: تحديد خطوط الاحتياطي للعرض التقديمي في جافا
linktitle: خط احتياطي
type: docs
weight: 10
url: /ar/java/create-fallback-font/
keywords:
- خط احتياطي
- قاعدة احتياطية
- تطبيق الخط
- استبدال الخط
- نطاق يونيكود
- حرف مفقود
- حرف صحيح
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "ابدع في Aspose.Slides للـ Java لتعيين خطوط الاحتياطي في ملفات PPT و PPTX و ODP، مع ضمان عرض النص بشكل ثابت على أي جهاز أو نظام تشغيل."
---

## **قواعد الخط الاحتياطي**

Aspose.Slides يدعم واجهة [IFontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRule) وفئة [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) لتحديد القواعد التي تُطبق الخط الاحتياطي. فئة [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) تمثل ارتباطًا بين نطاق Unicode المحدد، المستخدم للبحث عن الحروف المفقودة، وقائمة بالخطوط التي قد تحتوي على الحروف الصحيحة:
```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//استخدام طرق متعددة لإضافة قائمة الخطوط:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```


كما يمكن [إزالة](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) الخط الاحتياطي أو [addFallBackFonts](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) في كائن [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) قائم.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) لتنظيم قائمة من [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) عند الحاجة إلى تحديد قواعد استبدال الخطوط الاحتياطية لمجالات Unicode متعددة.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين الخط الاحتياطي، واستبدال الخط، وتضمين الخط؟**

يُستخدم الخط الاحتياطي فقط للأحرف التي لا توجد في الخط الأساسي. [استبدال الخط](/slides/ar/java/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [تضمين الخط](/slides/ar/java/embedded-font/) يضم الخطوط داخل ملف الإخراج بحيث يمكن للمستلمين عرض النص كما هو مقصود.

**هل يتم تطبيق الخطوط الاحتياطية أثناء تصدير الملفات مثل PDF أو PNG أو SVG، أم أنها تُستخدم فقط في العرض على الشاشة؟**

نعم. تؤثر الخطوط الاحتياطية على جميع عمليات [عمليات العرض والتصدير](/slides/ar/java/convert-presentation/) حيث يجب رسم الأحرف ولكنها غير موجودة في الخط المصدر.

**هل يؤدي تكوين الخطوط الاحتياطية إلى تغيير ملف العرض نفسه، وهل سيظل الإعداد محفوظًا للفتح المستقبلي؟**

لا. قواعد الخط الاحتياطي هي إعدادات عرض في وقت التشغيل في الكود الخاص بك؛ لا يتم تخزينها داخل ملف .pptx ولن تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة مجلدات الخطوط على اختيار الخطوط الاحتياطية؟**

نعم. المُحرك يحدد الخطوط من المجلدات النظامية المتاحة وأي [مسارات إضافية](/slides/ar/java/custom-font/) تقوم بتوفيرها. إذا لم يكن الخط متاحًا فعليًا، لا يمكن للقاعدة التي تشير إليه أن تُطبق.

**هل يعمل الخط الاحتياطي مع WordArt وSmartArt والرسوم البيانية؟**

نعم. عندما تحتوي هذه الكائنات على نص، يُطبق نفس آلية استبدال الحروف لعرض الأحرف المفقودة.