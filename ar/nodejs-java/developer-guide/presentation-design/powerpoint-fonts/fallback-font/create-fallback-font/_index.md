---
title: إنشاء خط احتياطي
type: docs
weight: 10
url: /ar/nodejs-java/create-fallback-font/
---

## **قواعد الخط الاحتياطي**

تدعم Aspose.Slides فئة [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) وفئة [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) لتحديد القواعد التي يتم من خلالها تطبيق خط احتياطي. فئة [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) تمثل ارتباطًا بين نطاق Unicode المحدد، المستخدم للبحث عن الحروف المفقودة، وقائمة الخطوط التي قد تحتوي على الحروف المناسبة:
```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// باستخدام طرق متعددة يمكنك إضافة قائمة الخطوط:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoji UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```


من الممكن أيضًا [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) خط الاحتياطي أو [addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) داخل كائن [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule) القائم.

يمكن استخدام [FontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRulesCollection) لتنظيم قائمة من كائنات [FontFallBackRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule)، عندما تكون هناك حاجة إلى تحديد قواعد استبدال الخط الاحتياطي لعدة نطاقات Unicode.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [إنشاء مجموعة خطوط احتياطية](/slides/ar/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما هو الفرق بين الخط الاحتياطي، استبدال الخط، وتضمين الخط؟**

يُستخدم الخط الاحتياطي فقط للأحرف المفقودة في الخط الأساسي. [Font substitution](/slides/ar/nodejs-java/font-substitution/) يستبدل الخط المحدد بالكامل بخط آخر. [Font embedding](/slides/ar/nodejs-java/embedded-font/) يضمّن الخطوط داخل ملف الإخراج بحيث يمكن للمستلمين عرض النص كما هو مقصود.

**هل يتم تطبيق الخطوط الاحتياطية أثناء تصدير مثل PDF أو PNG أو SVG، أم فقط عند العرض على الشاشة؟**

نعم. يؤثر الخط الاحتياطي على جميع عمليات [rendering and export operations](/slides/ar/nodejs-java/convert-presentation/) حيث يجب رسم الأحرف ولكنها غير موجودة في الخط المصدر.

**هل يؤدي تكوين الخط الاحتياطي إلى تغيير ملف العرض نفسه، وهل سيظل الإعداد محفوظًا للفتح لاحقًا؟**

لا. قواعد الخط الاحتياطي هي إعدادات عرض في وقت التشغيل في الكود الخاص بك؛ لا يتم تخزينها داخل ملف .pptx ولن تظهر في PowerPoint.

**هل يؤثر نظام التشغيل (Windows/Linux/macOS) ومجموعة دلائل الخطوط على اختيار الخط الاحتياطي؟**

نعم. يقوم المحرك بحل الخطوط من المجلدات النظامية المتاحة وأي [additional paths](/slides/ar/nodejs-java/custom-font/) تقدمها. إذا لم يكن الخط متاحًا فعليًا، لا يمكن لتلك القاعدة التي تشير إليه أن تُطبق.

**هل يعمل الخط الاحتياطي مع WordArt و SmartArt والرسوم البيانية؟**

نعم. عندما تحتوي هذه الكائنات على نص، يُطبق نفس آلية استبدال الحروف لعرض الأحرف المفقودة.