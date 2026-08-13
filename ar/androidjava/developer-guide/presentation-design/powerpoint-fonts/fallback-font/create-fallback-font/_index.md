---
title: تحديد الخطوط الاحتياطية للعروض التقديمية على Android
linktitle: خط احتياطي
type: docs
weight: 10
url: /ar/androidjava/create-fallback-font/
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
- Android
- Java
- Aspose.Slides
description: "تعلّم Aspose.Slides لنظام Android عبر Java لتعيين الخطوط الاحتياطية في ملفات PPT و PPTX و ODP، وضمان عرض نص متسق على أي جهاز أو نظام تشغيل."
---
## **نظرة عامة**

Aspose.Slides يتيح لك تحديد خطوط احتياطية لعملية عرض الشرائح وعمليات التصدير. تُستخدم الخطوط الاحتياطية عندما لا يحتوي الخط الأساسي على أحرف معينة.

يتم تكوين سلوك الخطوط الاحتياطية من خلال قواعد الاحتياطي. كل قاعدة تربط نطاق Unicode بخط أو أكثر قد يحتوي على الأحرف المطلوبة. يمكنك تعريف قواعد لنطاقات أحرف مختلفة، إضافة أو إزالة خطوط احتياطية من القواعد الموجودة، وتنظيم عدة قواعد في مجموعة قواعد الخطوط الاحتياطية.

قواعد الخطوط الاحتياطية هي إعدادات عرض في وقت التشغيل. لا تقوم بتعديل ملف العرض نفسه ولا تُحفظ داخل ملف PPTX.

## **قواعد الخطوط الاحتياطية**

Aspose.Slides يدعم الواجهة [IFontFallBackRule](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IFontFallBackRule) والفئة [FontFallBackRule](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontFallBackRule) لتحديد القواعد التي يتم تطبيق الخط الاحتياطي من خلالها. الفئة [FontFallBackRule](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontFallBackRule) تمثل ارتباطًا بين نطاق Unicode المحدد، المستخدم للبحث عن الأحرف المفقودة، وقائمة من الخطوط التي قد تحتوي على الأحرف الصحيحة:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

كما يمكن [remove](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) الخط الاحتياطي أو [addFallBackFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontFallBackRule) موجود.

يمكن استخدام الفئة [FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontFallBackRulesCollection) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontFallBackRule) عندما يكون من الضروري تحديد قواعد استبدال خطوط احتياطية لعدة نطاقات Unicode.

{{% alert color="info" title="انظر أيضًا" %}} 
- [Create Fallback Fonts Collection](/slides/ar/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة الشائعة**

### ما الفرق بين الخط الاحتياطي، واستبدال الخط، وتضمين الخط؟

يُستخدم الخط الاحتياطي فقط للأحرف المفقودة في الخط الأساسي. [استبدال الخط](/slides/ar/androidjava/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [تضمين الخط](/slides/ar/androidjava/embedded-font/) يضمّن الخطوط داخل ملف الإخراج بحيث يمكن للمستلمين عرض النص كما هو مقصود.

### هل تُطبق الخطوط الاحتياطية أثناء عمليات التصدير مثل PDF أو PNG أو SVG أم فقط أثناء العرض على الشاشة؟

نعم. تؤثر الخطوط الاحتياطية على جميع [عمليات العرض والتصدير](/slides/ar/androidjava/convert-presentation/) حيث يجب رسم الأحرف لكنها غير موجودة في الخط المصدر.

### هل يؤثر تكوين الخطوط الاحتياطية على ملف العرض نفسه، وهل سيظل الإعداد محفوظًا للفتح المستقبلي؟

لا. قواعد الخطوط الاحتياطية هي إعدادات عرض وقت تشغيل في الشيفرة الخاصة بك؛ لا تُحفظ داخل ملف .pptx ولن تظهر في برنامج PowerPoint.

### هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة مجلدات الخطوط على اختيار الخطوط الاحتياطية؟

نعم. تقوم المحرك باستخلاص الخطوط من المجلدات النظامية المتوفرة وأي [مسارات إضافية](/slides/ar/androidjava/custom-font/) تقدمها. إذا لم يتوفر الخط فعليًا، فإن القاعدة التي تشير إليه لا يمكن أن تُطبق.

### هل تعمل الخطوط الاحتياطية مع WordArt وSmartArt والرسوم البيانية؟

نعم. عندما تحتوي هذه الكائنات على نص، يُطبق نفس آلية استبدال الأحرف لتصوير الأحرف المفقودة.