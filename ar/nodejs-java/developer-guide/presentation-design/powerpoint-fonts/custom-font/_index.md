---
title: خط مخصص لبوربوينت في JavaScript
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/nodejs-java/custom-font/
keywords: "الخطوط، خطوط مخصصة، عرض بوربوينت، جافا، Aspose.Slides لـ Node.js عبر Java"
description: "خطوط بوربوينت مخصصة في JavaScript"
---

{{% alert color="primary" %}} 
يتيح لك Aspose Slides تحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).

* خطوط TrueType (.ttf) و TrueType Collection (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

يتيح لك Aspose.Slides تحميل الخطوط التي تُظهر في العروض التقديمية دون الحاجة إلى تثبيت تلك الخطوط. يتم تحميل الخطوط من دليل مخصص. 

1. إنشاء كائن من الفئة [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/) واستدعاء طريقة [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. تحميل العرض التقديمي الذي سيتم عرضه.
3. [مسح الذاكرة المؤقتة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader#clearCache--) في الفئة [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader).

يظهر هذا الكود JavaScript عملية تحميل الخط:
```javascript
// مجلدات للبحث عن الخطوط
var folders = java.newArray("java.lang.String", [externalFontsDir]);
// تحميل خطوط دليل الخطوط المخصص
aspose.slides.FontsLoader.loadExternalFonts(folders);
// أداء بعض العمل وإجراء عرض الشرائح/التقديم
var pres = new aspose.slides.Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
        // يمسح ذاكرة التخزين المؤقت للخطوط
    aspose.slides.FontsLoader.clearCache();
}
```


## **الحصول على مجلد الخطوط المخصصة**
توفر Aspose.Slides طريقة [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) لتتيح لك العثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي أضيفت عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يعرض هذا الكود JavaScript كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):
```javascript
// يقوم هذا السطر بإخراج المجلدات التي يتم البحث فيها عن ملفات الخطوط.
// هذه هي المجلدات التي تمت إضافتها عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع العرض التقديمي**
توفر Aspose.Slides الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) لتتيح لك تحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

يعرض هذا الكود JavaScript كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):
```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي
    // CustomFont1 و CustomFont2 والخطوط من مجلدي assets\fonts و global\fonts ومجلداتهما الفرعية متاحة للعرض التقديمي
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إدارة الخطوط خارجيًا**

توفر Aspose.Slides الطريقة [loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) لتتيح لك تحميل الخطوط الخارجية من بيانات ثنائية.

يظهر هذا الكود JavaScript عملية تحميل الخط من مصفوفة بايت:
```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // تم تحميل الخط الخارجي خلال مدة تشغيل العرض التقديمي
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```


## **الأسئلة المتكررة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟**

نعم. تُستخدم الخطوط المتصلة من قبل المُصِغِّ في جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للعرض ليس هو نفسه تضمينه في ملف PPTX. إذا كنت بحاجة إلى احتواء الخط داخل ملف العرض التقديمي، يجب عليك استخدام [ميزات التضمين](/slides/ar/nodejs-java/embedded-font/).

**هل يمكنني التحكم في سلوك الاحتياطي عندما يفتقر الخط المخصص إلى بعض الحروف؟**

نعم. يمكنك تكوين [استبدال الخطوط](/slides/ar/nodejs-java/font-substitution/)، [قواعد الاستبدال](/slides/ar/nodejs-java/font-replacement/)، و[مجموعات الاحتياطي](/slides/ar/nodejs-java/fallback-font/) لتحديد الخط المحدد الذي يُستخدم عندما يكون الحرف المطلوب غير موجود.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. يمكن الإشارة إلى مجلدات الخطوط الخاصة بك أو تحميل الخطوط من مصفوفات البايت. هذا يزيل أي اعتماد على دلائل الخطوط النظامية في صورة الحاوية.

**ماذا عن الترخيص — هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت المسؤول عن الامتثال لتراخيص الخطوط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. دائمًا راجع اتفاقية ترخيص المستخدم النهائي للخط قبل توزيع المخرجات.