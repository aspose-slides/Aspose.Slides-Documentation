---
title: تخصيص خطوط PowerPoint على Android
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "خصص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides للـ Android عبر Java للحفاظ على عروضك التقديمية حادة ومتناسقة عبر أي جهاز."
---

{{% alert color="primary" %}} 

تتيح لك Aspose Slides تحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) ومجموعات TrueType (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

تتيح لك Aspose.Slides تحميل الخطوط التي يتم عرضها في العروض التقديمية دون الحاجة إلى تثبيت تلك الخطوط. يتم تحميل الخطوط من دليل مخصص. 

1. إنشاء نسخة من الفئة [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) واستدعاء طريقة [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. تحميل العرض التقديمي الذي سيتم عرضه.
3. [مسح الذاكرة المؤقتة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) في فئة [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader).

يعرض هذا الشيفرة Java عملية تحميل الخطوط:
```java
// المجلدات للبحث عن الخطوط
String[] folders = new String[] { externalFontsDir };

// يحمّل الخطوط من دليل الخطوط المخصص
FontsLoader.loadExternalFonts(folders);

// قم ببعض الأعمال وأجرِ عرض الشرائح/العرض التقديمي
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // يمسح ذاكرة الخط المؤقت
    FontsLoader.clearCache();
}
```


## **الحصول على مجلدات الخطوط المخصصة**

توفر Aspose.Slides الطريقة [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) لتمكينك من العثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي تمت إضافتها عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يعرض هذا الشيفرة Java كيف تستخدم [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):
```java
// يعرض هذا السطر المجلدات التي يتم البحث فيها عن ملفات الخطوط.
// هذه هي المجلدات المضافة عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**

توفر Aspose.Slides الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) لتمكينك من تحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

يعرض هذا الشيفرة Java كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي
    // الخطوط CustomFont1 و CustomFont2 والخطوط من مجلدي assets\fonts و global\fonts ومجلداتهما الفرعية متوفرة للعرض التقديمي
} finally {
    if (pres != null) pres.dispose();
}
```


## **إدارة الخطوط خارجيًا**

توفر Aspose.Slides الطريقة [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) لتمكينك من تحميل الخطوط الخارجية من بيانات بايتية.

يعرض هذا الشيفرة Java عملية تحميل الخطوط من مصفوفة بايت:
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // تم تحميل الخط الخارجي خلال مدة العرض التقديمي
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```


## **الأسئلة المتكررة**

**هل تؤثر الخطوط المخصصة على تصدير جميع الصيغ (PDF, PNG, SVG, HTML)؟**

نعم. يتم استخدام الخطوط المتصلة من قبل المُصِدر عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للاستخدام في العرض لا يعني تضمينه في ملف PPTX. إذا كنت بحاجة إلى تضمين الخط داخل ملف العرض، يجب عليك استخدام [ميزات التضمين](/slides/ar/androidjava/embedded-font/).

**هل يمكنني التحكم في سلوك الاحتياطي عندما لا يحتوي الخط المخصص على بعض الرموز؟**

نعم. قم بضبط [استبدال الخط](/slides/ar/androidjava/font-substitution/)، [قواعد الاستبدال](/slides/ar/androidjava/font-replacement/)، و[مجموعات الاحتياطي](/slides/ar/androidjava/fallback-font/) لتحديد الخط المستخدم عندما يكون الرمز المطلوب غير موجود.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. قم بالإشارة إلى مجلدات الخطوط الخاصة بك أو تحميل الخطوط من مصفوفات بايت. هذا يزيل أي اعتماد على مجلدات الخطوط النظامية في صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت مسؤول عن الالتزام بترخيص الخطوط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. يجب دائمًا مراجعة اتفاقية ترخيص المستخدم النهائي للخط قبل توزيع المخرجات.