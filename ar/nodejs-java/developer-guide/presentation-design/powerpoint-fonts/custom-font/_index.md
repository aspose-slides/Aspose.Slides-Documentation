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
- تحميل خط
- إدارة الخطوط
- مجلد الخطوط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تخصيص الخطوط في شرائح PowerPoint باستخدام JavaScript و Aspose.Slides لـ Node.js عبر Java للحفاظ على عروضك التقديمية حادة ومتسقة عبر أي جهاز."
---

{{% alert color="primary" %}} 

Aspose Slides يسمح لك بتحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) و TrueType Collection (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

Aspose.Slides يسمح لك بتحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير—مثل PDF والصور وغيرها من الصيغ المدعومة—بحيث تبدو المستندات الناتجة متسقة عبر بيئات مختلفة. يتم تحميل الخطوط من مجلدات مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخطوط.  
2. استدعِ الطريقة الساكنة [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) لتحميل الخطوط من تلك المجلدات.  
3. قم بتحميل العرض التقديمي وعرضه/تصديره.  
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/clearcache/) لمسح ذاكرة مخزن الخطوط.

المثال التالي يوضح عملية تحميل الخطوط:
```js
// تحديد المجلدات التي تحتوي على ملفات الخطوط المخصصة.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// تحميل الخطوط المخصصة من المجلدات المحددة.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // تصيير/تصدير العرض التقديمي (مثلاً إلى PDF أو صور أو صيغ أخرى) باستخدام الخطوط التي تم تحميلها.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
    aspose.slides.FontsLoader.clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) يضيف مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط. يتم تهيئة الخطوط بالترتيب التالي:

1. مسار الخط الافتراضي في نظام التشغيل.  
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **الحصول على مجلد الخطوط المخصصة**
Aspose.Slides يوفر الطريقة [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) للسماح لك باكتشاف مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي أضيفت من خلال طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يظهر هذا الكود JavaScript كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):
```javascript
// هذا السطر يعرض المجلدات التي يتم البحث فيها عن ملفات الخطوط.
// هذه هي المجلدات التي تم إضافتها عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع العرض التقديمي**
Aspose.Slides يوفر الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) للسماح لك بتحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

يظهر هذا الكود JavaScript كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):
```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // العمل على العرض التقديمي
    // CustomFont1، CustomFont2، والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إدارة الخطوط خارجياً**

Aspose.Slides يوفر الطريقة [loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) للسماح لك بتحميل خطوط خارجية من بيانات بايت.

هذا الكود JavaScript يوضح عملية تحميل الخط من مصفوفة بايت:
```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // خط خارجي تم تحميله خلال فترة عرض الشرائح
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```


## **الأسئلة المتكررة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟**

نعم. يتم استخدام الخطوط المتصلة بواسطة المحول عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للعرض لا يعني تضمينه في ملف PPTX. إذا كنت تحتاج الخط داخل ملف العرض، يجب استخدام ميزات [التضمين](/slides/ar/nodejs-java/embedded-font/).

**هل يمكن التحكم في سلوك fallback عندما يفتقر الخط المخصص إلى بعض الحروف؟**

نعم. يمكنك ضبط [استبدال الخط](/slides/ar/nodejs-java/font-substitution/)، [قواعد الاستبدال](/slides/ar/nodejs-java/font-replacement/)، و[مجموعات fallback](/slides/ar/nodejs-java/fallback-font/) لتحديد الخط الذي سيُستخدم عند فقدان الحرف المطلوب.

**هل يمكن استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على النظام؟**

نعم. يمكنك الإشارة إلى مجلدات الخطوط الخاصة بك أو تحميل الخطوط من مصفوفات بايت. هذا يزيل أي اعتماد على مجلدات الخطوط النظامية داخل صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت مسؤول عن الامتثال لترخيص الخطوط. تختلف الشروط؛ بعض الرخص تمنع التضمين أو الاستخدام التجاري. تأكد دائمًا من مراجعة اتفاقية ترخيص المستخدم النهائي (EULA) للخط قبل توزيع المخرجات.