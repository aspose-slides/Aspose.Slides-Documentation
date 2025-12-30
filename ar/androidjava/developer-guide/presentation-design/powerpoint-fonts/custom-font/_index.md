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
- تحميل الخط
- إدارة الخطوط
- مجلد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides لأندرويد عبر جافا للحفاظ على وضوح وتناسق عروضك التقديمية على أي جهاز."
---

{{% alert color="primary" %}} 

تمكنك Aspose Slides من تحميل هذه الخطوط باستخدام الطريقة [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) و TrueType Collection (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

تمكنك Aspose.Slides من تحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. هذا يؤثر على مخرجات التصدير — مثل PDF، الصور، وغيرها من الصيغ المدعومة — بحيث تبدو المستندات الناتجة متسقة عبر البيئات المختلفة. يتم تحميل الخطوط من أدلة مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ طريقة [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) الثابتة لتحميل الخطوط من تلك المجلدات.
3. حمّل وعرض/صدّر العرض التقديمي.
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) لمسح ذاكرة التخزين المؤقت للخطوط.

يعرض المثال التالي عملية تحميل الخطوط:
```java
// تحديد المجلدات التي تحتوي على ملفات الخطوط المخصصة.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// تحميل الخطوط المخصصة من المجلدات المحددة.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // عرض/تصدير العرض التقديمي (مثل PDF أو صور أو صيغ أخرى) باستخدام الخطوط التي تم تحميلها.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
    FontsLoader.clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) يضيف مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط.
يتم تهيئة الخطوط بهذا الترتيب:

1. مسار الخط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**
توفر Aspose.Slides الطريقة [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) التي تتيح لك العثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي أُضيفت عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

هذا الكود Java يوضح كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):
```java
// هذا السطر يعرض المجلدات التي يتم البحث فيها عن ملفات الخطوط.
// هذه هي المجلدات التي أضيفت عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**
توفر Aspose.Slides الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) التي تتيح لك تحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

هذا الكود Java يوضح كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي
    // CustomFont1, CustomFont2، والخطوط من مجلدات assets\fonts & global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
} finally {
    if (pres != null) pres.dispose();
}
```


## **إدارة الخطوط خارجيًا**

توفر Aspose.Slides الطريقة [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) التي تتيح لك تحميل خطوط خارجية من بيانات ثنائية.

هذا الكود Java يوضح عملية تحميل الخط من مصفوفة بايت:
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // الخط الخارجي تم تحميله أثناء عمر العرض التقديمي
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```


## **الأسئلة المتكررة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF، PNG، SVG، HTML)؟**

نعم. تُستخدم الخطوط المتصلة بواسطة المصدر عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للاستخدام في العرض لا يعني تضمينه في ملف PPTX. إذا كنت بحاجة إلى تضمين الخط داخل ملف العرض، يجب عليك استخدام خصائص [embedding features](/slides/ar/androidjava/embedded-font/).

**هل يمكنني التحكم في سلوك الاحتياط عندما يفتقر الخط المخصص إلى بعض الرموز؟**

نعم. يمكنك تكوين [font substitution](/slides/ar/androidjava/font-substitution/)، [replacement rules](/slides/ar/androidjava/font-replacement/)، و[fallback sets](/slides/ar/androidjava/fallback-font/) لتحديد الخط المستخدم بالضبط عندما يكون الرمز المطلوب غير موجود.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. يمكنك الإشارة إلى مجلدات الخطوط الخاصة بك أو تحميل الخطوط من مصفوفات بايت. هذا يزيل أي اعتماد على أدلة الخطوط النظامية في صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت المسؤول عن الامتثال لترخيص الخطوط. تختلف الشروط؛ بعض التراخيص تمنع التضمين أو الاستخدام التجاري. احرص دائمًا على مراجعة اتفاقية الترخيص (EULA) الخاصة بالخط قبل توزيع المخرجات.