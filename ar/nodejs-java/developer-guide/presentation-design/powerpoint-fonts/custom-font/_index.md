---
title: تخصيص خطوط PowerPoint في JavaScript
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/nodejs-java/custom-font/
keywords:
- خط
- خط مخصص
- خط خارجي
- تحميل الخط
- إدارة الخطوط
- مجلد الخطوط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "قم بتخصيص الخطوط في شرائح PowerPoint باستخدام JavaScript و Aspose.Slides لـ Node.js عبر Java للحفاظ على عروضك التقديمية حادة ومتسقة عبر أي جهاز."
---
## **نظرة عامة**

Aspose.Slides يتيح لك استخدام خطوط مخصصة في العروض التقديمية دون حاجتها إلى تثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير الخطوط لعرض تقديمي معين عبر مصادر الخط على مستوى المستند، أو تحميل خطوط خارجية مباشرة من البيانات الثنائية.

تُستخدم الخطوط التي تم تحميلها عند تجسيد أو تصدير العرض التقديمي، مثل تصديره إلى PDF أو صور أو صيغ أخرى مدعومة. يساعد ذلك في الحفاظ على تناسق ناتج العرض عبر بيئات مختلفة. كما يوضح هذا المقال كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد التعامل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للتجسيد يتم بشكل منفصل عن تضمين الخطوط داخل ملف PPTX. إذا كان يجب تخزين الخط داخل العرض التقديمي نفسه، استخدم ميزات تضمين الخطوط صراحةً.

يمكن لمظهر العرض التقديمي الإشارة إلى عائلات خطوط مختلفة لأنظمة الكتابة الفردية. تقوم هذه التخطيطات بحفظ أسماء الخطوط لكنها لا تثبت أو تحمل ملفات الخط. راجع [Script-Specific Theme Fonts](/slides/ar/nodejs-java/script-specific-font-mappings/) لإدارة هذه التخطيطات، واستخدم خيارات التحميل أدناه لجعل الخطوط المشار إليها متاحة لتجسيد متسق.

{{% alert color="info" title="ملاحظة" %}}
يسمح لك Aspose Slides بتحميل هذه الخطوط باستخدام الطريقة [loadExternalFonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) وTrueType Collection (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **تحميل الخطوط المخصصة**

Aspose.Slides يتيح لك تحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير—مثل PDF أو صور أو صيغ مدعومة أخرى—بحيث تبدو المستندات الناتجة متسقة عبر البيئات. تُحمَّل الخطوط من أدلة مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الساكنة [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) لتحميل الخطوط من تلك المجلدات.
3. حمِّل العرض وقم بتجسيده/تصديره.
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsloader/clearcache/) لمسح ذاكرة التخزين المؤقت للخطوط.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// تعريف المجلدات التي تحتوي على ملفات الخطوط المخصصة.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// تحميل الخطوط المخصصة من المجلدات المحددة.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // تجسيد/تصدير العرض التقديمي (مثل PDF أو صور أو صيغ أخرى) باستخدام الخطوط التي تم تحميلها.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="ملاحظة" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) يضيف مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغير ترتيب تهيئة الخط. تُهيَّأ الخطوط بهذا الترتيب:

1. مسار الخط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **الحصول على مجلد الخطوط المخصصة**
Aspose.Slides توفر الطريقة [getFontFolders](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) لتُمكِّنك من العثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي أضيفت عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

هذا الكود JavaScript يظهر لك كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// هذا السطر يُظهر المجلدات التي يتم البحث فيها عن ملفات الخطوط.
// هذه هي المجلدات التي أضيفت عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع العرض**
Aspose.Slides توفر الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) لتتيح لك تحديد الخطوط الخارجية التي سيتم استخدامها مع العرض.

هذا الكود JavaScript يظهر لك كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // التعامل مع العرض التقديمي
    // خطوط CustomFont1 و CustomFont2، والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **إدارة الخطوط خارجيًا**

Aspose.Slides توفر الطريقة [loadExternalFont](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) لتحميل الخطوط الخارجية من البيانات الثنائية.

هذا الكود JavaScript يعرض عملية تحميل الخط من مصفوفة بايت:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // تم تحميل الخط الخارجي طوال مدة العرض التقديمي
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **الأسئلة الشائعة**

### هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟

نعم. تُستخدم الخطوط المتصلة بواسطة المُعالج عبر جميع صيغ التصدير.

### هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟

لا. تسجيل الخط للتجسيد ليس هو نفسه تضمينه في ملف PPTX. إذا كنت بحاجة إلى حمل الخط داخل ملف العرض، يجب عليك استخدام [ميزات التضمين](/slides/ar/nodejs-java/embedded-font/) بشكل صريح.

### هل يمكنني التحكم في سلوك الاحتياطي عندما يفتقر الخط المخصص إلى بعض الرموز؟

نعم. قم بتهيئة [font substitution](/slides/ar/nodejs-java/font-substitution/)، [replacement rules](/slides/ar/nodejs-java/font-replacement/)، و[fallback sets](/slides/ar/nodejs-java/fallback-font/) لتحديد الخط الذي يُستخدم بالضبط عندما تكون الرموز المطلوبة مفقودة.

### هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟

نعم. قم بالإشارة إلى مجلدات الخطوط الخاصة بك أو حمّل الخطوط من مصفوفات البايت. يزيل ذلك أي اعتماد على دلائل الخطوط النظامية في صورة الحاوية.

### ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟

أنت المسؤول عن الالتزام بترخيص الخطوط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. احرص دائمًا على مراجعة اتفاقية الترخيص (EULA) الخاصة بالخط قبل توزيع المخرجات.