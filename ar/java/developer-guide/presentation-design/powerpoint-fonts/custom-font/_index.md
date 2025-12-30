---
title: تخصيص خطوط PowerPoint في جافا
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/java/custom-font/
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
  - Java
  - Aspose.Slides
description: "قم بتخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides للـ Java للحفاظ على عروضك التقديمية واضحة ومتسقة عبر أي جهاز."
---

{{% alert color="primary" %}} 

تتيح لك Aspose Slides تحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) و TrueType Collection (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

تتيح لك Aspose.Slides تحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. هذا يؤثر على مخرجات التصدير—مثل PDF والصور وغيرها من الصيغ المدعومة—بحيث تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من أدلة مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الثابتة [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) لتحميل الخطوط من تلك المجلدات.
3. حمل وعرض/صدّر العرض التقديمي.
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) لمسح ذاكرة التخزين المؤقت للخطوط.

يوضح المثال البرمجي التالي عملية تحميل الخطوط:
```java
// تعريف المجلدات التي تحتوي على ملفات الخطوط المخصصة.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// تحميل الخطوط المخصصة من المجلدات المحددة.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // عرض/تصدير العرض التقديمي (مثل إلى PDF أو صور أو صيغ أخرى) باستخدام الخطوط المحملة.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
    FontsLoader.clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) يضيف مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط. يتم تهيئة الخطوط بهذا الترتيب:

1. مسار الخط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**
Aspose.Slides توفر طريقة [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) للسماح لك بالعثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات المضافة عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يعرض هذا الكود Java كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--):
```java
// هذا السطر يخرج المجلدات التي يتم البحث فيها عن ملفات الخط.
// هذه هي المجلدات التي تمت إضافتها عبر طريقة LoadExternalFonts ومجلدات خطوط النظام.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع العرض التقديمي**
Aspose.Slides توفر الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) لتحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي. 

يعرض هذا الكود Java كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي
    // CustomFont1 و CustomFont2 والخطوط الموجودة في مجلدات assets\fonts و global\fonts ومجلداتهما الفرعية متاحة للعرض التقديمي
} finally {
    if (pres != null) pres.dispose();
}
```


## **إدارة الخطوط خارجيًا**

Aspose.Slides توفر طريقة [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) لتحميل الخطوط الخارجية من بيانات ثنائية.

يعرض هذا الكود Java عملية تحميل الخطوط من مصفوفة بايت:
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // تم تحميل الخط الخارجي أثناء فترة عرض الشرائح
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```


## **الأسئلة المتكررة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)?**

نعم. تُستخدم الخطوط المتصلة من قبل المُعرِّض عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للعرض ليس هو نفسه تضمينه في PPTX. إذا كنت تحتاج إلى أن يكون الخط مُضمّنًا داخل ملف العرض التقديمي، يجب عليك استخدام [ميزات التضمين](/slides/ar/java/embedded-font/).

**هل يمكنني التحكم في سلوك الاحتياطي عندما يفتقر الخط المخصص إلى بعض الرموز؟**

نعم. قم بتكوين [استبدال الخط](/slides/ar/java/font-substitution/)، [قواعد الاستبدال](/slides/ar/java/font-replacement/)، و[مجموعات الاحتياطي](/slides/ar/java/fallback-font/) لتحديد الخط المحدد الذي يُستخدم عندما تكون الرموز المطلوبة غير موجودة.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. يمكنك الإشارة إلى مجلدات الخط الخاصة بك أو تحميل الخطوط من مصفوفات بايت. هذا يزيل أي اعتماد على دلائل الخطوط النظامية في صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت المسؤول عن الالتزام بترخيص الخطوط. الشروط تختلف؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. عليك دائمًا مراجعة اتفاقية ترخيص المستخدم النهائي للخط قبل توزيع المخرجات.