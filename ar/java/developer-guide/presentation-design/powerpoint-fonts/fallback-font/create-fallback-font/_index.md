---
title: تحديد الخطوط الاحتياطية للعروض التقديمية في Java
linktitle: خط احتياطي
type: docs
weight: 10
url: /ar/java/create-fallback-font/
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
- Java
- Aspose.Slides
description: "إجادة Aspose.Slides للغة Java لتعيين الخطوط الاحتياطية في ملفات PPT و PPTX و ODP، وضمان عرض نص ثابت على أي جهاز أو نظام تشغيل."
---
## **نظرة عامة**

Aspose.Slides يسمح لك بتحديد خطوط احتياطية لتصيير العروض التقديمية وعمليات التصدير. تُستخدم الخطوط الاحتياطية عندما لا يحتوي الخط الأساسي على رموز الأحرف المطلوبة.

يتم تكوين سلوك الخط الاحتياطي من خلال قواعد احتياطية. كل قاعدة تربط نطاق Unicode بخط أو أكثر قد يحتوي على الرموز المطلوبة. يمكنك تعريف قواعد لنطاقات أحرف مختلفة، إضافة أو إزالة خطوط احتياطية من القواعد الموجودة، وتنظيم قواعد متعددة في مجموعة قواعد الخطوط الاحتياطية.

قواعد الخطوط الاحتياطية هي إعدادات تصيير وقت التشغيل. فهي لا تعدل ملف العرض نفسه ولا تُخزن داخل ملف PPTX.

## **قواعد الخطوط الاحتياطية**

Aspose.Slides يدعم الواجهة [IFontFallBackRule](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IFontFallBackRule) والفئة [FontFallBackRule](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontFallBackRule) لتحديد القواعد التي تُطبق خطًا احتياطيًا. الفئة [FontFallBackRule](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontFallBackRule) تمثل علاقة بين نطاق Unicode المحدد، المستخدم للبحث عن الرموز المفقودة، وقائمة خطوط قد تحتوي على الرموز المناسبة:

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

كما يمكن [remove](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) خطًا احتياطيًا أو [addFallBackFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) إلى كائن [FontFallBackRule](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontFallBackRule) موجود.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontFallBackRulesCollection) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontFallBackRule) عندما يكون هناك حاجة لتحديد قواعد استبدال خطوط احتياطية لعدة نطاقات Unicode.

{{% alert color="info" title="See also" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة المتكررة**

### ما الفرق بين الخط الاحتياطي، واستبدال الخط، وتضمين الخط؟

الخط الاحتياطي يُستخدم فقط للأحرف المفقودة في الخط الأساسي. [Font substitution](/slides/ar/java/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [Font embedding](/slides/ar/java/embedded-font/) يضم الخطوط داخل ملف الإخراج بحيث يمكن للمستلمين عرض النص كما هو مقصود.

### هل تُطبق الخطوط الاحتياطية أثناء تصدير الملفات مثل PDF أو PNG أو SVG، أم فقط أثناء التصيير على الشاشة؟

نعم. الخطوط الاحتياطية تؤثر على جميع [rendering and export operations](/slides/ar/java/convert-presentation/) حيث يجب رسم الأحرف لكن لا توجد في الخط المصدر.

### هل يؤثر تكوين الخطوط الاحتياطية على ملف العرض نفسه، وهل سيبقى الإعداد محفوظًا للفتح المستقبلي؟

لا. قواعد الخطوط الاحتياطية هي إعدادات تصيير وقت التشغيل في كودك؛ لا تُخزن داخل ملف .pptx ولن تظهر في PowerPoint.

### هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة مجلدات الخطوط على اختيار الخط الاحتياطي؟

نعم. المحرك يحل الخطوط من المجلدات النظامية المتاحة وأي [additional paths](/slides/ar/java/custom-font/) تقوم بتحديدها. إذا لم يكن الخط متوفرًا فعليًا، فإن القاعدة التي تشير إليه لا يمكن أن تُطبق.

### هل تعمل الخطوط الاحتياطية مع WordArt وSmartArt والرسوم البيانية؟

نعم. عندما تحتوي هذه العناصر على نص، تُطبق نفس آلية استبدال الرموز لتصيير الأحرف المفقودة.