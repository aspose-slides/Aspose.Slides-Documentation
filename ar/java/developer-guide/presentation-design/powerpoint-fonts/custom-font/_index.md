---
title: تخصيص خطوط PowerPoint في Java
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
- مجلد الخطوط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بتخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides for Java للحفاظ على عروضك التقديمية حادة ومتسقة عبر أي جهاز."
---

{{% alert color="primary" %}} 

يسمح Aspose Slides بتحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) و TrueType Collection (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

Aspose.Slides يسمح لك بتحميل الخطوط التي يتم عرضها في العروض التقديمية دون الحاجة لتثبيت هذه الخطوط. يتم تحميل الخطوط من دليل مخصص.

1. إنشاء مثيل من الفئة [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) واستدعاء طريقة [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. تحميل العرض التقديمي الذي سيتم عرضه.
3. [مسح الذاكرة المؤقتة](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) في الفئة [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader).

هذا الكود Java يوضح عملية تحميل الخطوط:
```java
// المجلدات للبحث عن الخطوط
String[] folders = new String[] { externalFontsDir };

// تحميل خطوط دليل الخطوط المخصص
FontsLoader.loadExternalFonts(folders);

// تنفيذ بعض الأعمال وإجراء عرض الشرائح/العرض التقديمي
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // مسح ذاكرة الخط المؤقت
    FontsLoader.clearCache();
}
```


## **الحصول على مجلدات الخطوط المخصصة**

Aspose.Slides يوفر طريقة [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) للسماح لك بالعثور على مجلدات الخطوط. تُرجع هذه الطريقة المجلدات التي تمت إضافتها عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

هذا الكود Java يوضح كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--):
```java
// تقوم هذه السطر بإخراج المجلدات التي يتم فيها البحث عن ملفات الخطوط.
// هذه هي المجلدات التي تم إضافتها عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**

Aspose.Slides يوفر الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) للسماح لك بتحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

هذا الكود Java يوضح كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي
    // CustomFont1, CustomFont2، والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
} finally {
    if (pres != null) pres.dispose();
}
```


## **إدارة الخطوط خارجيًا**

Aspose.Slides يوفر طريقة [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) للسماح لك بتحميل الخطوط الخارجية من بيانات ثنائية.

هذا الكود Java يوضح عملية تحميل الخط من مصفوفة البايت:
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // تم تحميل الخط الخارجي خلال عمر العرض التقديمي
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```


## **الأسئلة المتكررة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟**

نعم. يتم استخدام الخطوط المتصلة من قبل المُصَدِّر عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للعرض ليس هو نفسه تضمينه في PPTX. إذا كنت تحتاج إلى حمل الخط داخل ملف العرض التقديمي، يجب عليك استخدام [ميزات التضمين](/slides/ar/java/embedded-font/).

**هل يمكنني التحكم في سلوك الاحتياطي عندما يفتقر الخط المخصص إلى بعض الرموز؟**

نعم. قم بتكوين [استبدال الخط](/slides/ar/java/font-substitution/)، [قواعد الاستبدال](/slides/ar/java/font-replacement/)، و[مجموعة الاحتياطي](/slides/ar/java/fallback-font/) لتحديد بالضبط أي خط يُستخدم عندما تكون الرموز المطلوبة غير موجودة.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. أشِر إلى مجلدات الخطوط الخاصة بك أو حمِّل الخطوط من مصفوفات البايت. يزيل هذا أي اعتماد على دلائل الخطوط النظامية في صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت المسؤول عن الامتثال لتراخيص الخطوط. الشروط تختلف؛ بعض الرخص تحظر التضمين أو الاستخدام التجاري. احرص دائمًا على مراجعة اتفاقية ترخيص المستخدم النهائي (EULA) للخط قبل توزيع المخرجات.