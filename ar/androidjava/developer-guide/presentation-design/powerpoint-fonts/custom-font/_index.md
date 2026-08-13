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
description: "تخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides لأجهزة Android عبر Java للحفاظ على عروضك التقديمية حادة ومتسقة عبر أي جهاز."
---
## **نظرة عامة**

يتيح لك Aspose.Slides استخدام الخطوط المخصصة في العروض التقديمية دون تثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير الخطوط لعروض تقديمية معينة عبر مصادر الخط على مستوى المستند، أو تحميل الخطوط الخارجية مباشرةً من البيانات الثنائية.

تُستخدم الخطوط التي تم تحميلها عند عرض أو تصدير العرض التقديمي، مثل التحويل إلى PDF أو صور أو صيغ أخرى مدعومة. يساعد ذلك في الحفاظ على تناسق مخرجات العرض عبر بيئات مختلفة. توضح المقالة أيضاً كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد التعامل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للتص-render هو أمر منفصل عن تضمين الخطوط داخل ملف PPTX. إذا كان لابد من تخزين الخط داخل العرض نفسه، استخدم ميزات تضمين الخطوط صراحةً.

{{% alert color="info" %}} 
يسمح لك Aspose Slides بتحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **تحميل الخطوط المخصصة**

يتيح لك Aspose.Slides تحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير — مثل PDF، الصور، والصيغ المدعومة الأخرى — بحيث تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من دلائل مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الثابتة [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) لتحميل الخطوط من تلك المجلدات.
3. حمّل وقم بعرض/تصدير العرض التقديمي.
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontsLoader#clearCache--) لمسح ذاكرة التخزين المؤقت للخطوط.

يعرض مثال الشيفرة التالي عملية تحميل الخطوط:

```java
import com.aspose.slides.*;

// حدد المجلدات التي تحتوي على ملفات الخطوط المخصصة.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// حمّل الخطوط المخصصة من المجلدات المحددة.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // عرض/تصدير العرض التقديمي (مثل PDF أو صور أو صيغ أخرى) باستخدام الخطوط المُحمَّلة.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) يضيف مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط.
يتم تهيئة الخطوط بهذا الترتيب:

1. مسار الخط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**

توفر Aspose.Slides الطريقة [getFontFolders](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) للسماح لك باكتشاف مجلدات الخطوط. تُرجع هذه الطريقة المجلدات التي أضيفت عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يعرض هذا الشيفرة Java كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// هذا السطر يُخرج المجلدات التي يتم البحث فيها عن ملفات الخطوط.
// هذه هي المجلدات التي تمت إضافتها عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**

توفر Aspose.Slides الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) للسماح لك بتحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

يعرض هذا الشيفرة Java كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // العمل مع العرض التقديمي
    // CustomFont1, CustomFont2، والخطوط من مجلدات assets\fonts و global\fonts ومجلداتهما الفرعية متاحة للعرض التقديمي
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة الخطوط خارجيًا**

توفر Aspose.Slides الطريقة [loadExternalFont](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) للسماح لك بتحميل الخطوط الخارجية من بيانات ثنائية.

تُظهر هذه الشيفرة Java عملية تحميل الخط من مصفوفة بايت:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // تم تحميل الخط الخارجي أثناء عمر العرض التقديمي
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **الأسئلة الشائعة**

### هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF، PNG، SVG، HTML)؟

نعم. تُستخدم الخطوط المتصلة من قبل المُعالج عبر جميع صيغ التصدير.

### هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟

لا. تسجيل الخط للتص-render ليس هو نفسه تضمينه في ملف PPTX. إذا كنت تحتاج إلى حمل الخط داخل ملف العرض، يجب عليك استخدام ميزات [التضمين](/slides/ar/androidjava/embedded-font/) بشكل صريح.

### هل يمكنني التحكم في سلوك الاحتياطي عندما يفتقر الخط المخصص إلى بعض الرموز؟

نعم. يمكنك تكوين [استبدال الخط](/slides/ar/androidjava/font-substitution/)، [قواعد الاستبدال](/slides/ar/androidjava/font-replacement/)، و[مجموعات الاحتياطي](/slides/ar/androidjava/fallback-font/) لتحديد الخط المستخدم بالتحديد عندما تكون الرموز المطلوبة مفقودة.

### هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟

نعم. يمكنك الإشارة إلى مجلدات الخط الخاصة بك أو تحميل الخطوط من مصفوفات بايت. هذا يلغي أي اعتماد على أدلة الخط النظامية في صورة الحاوية.

### ماذا عن الترخيص — هل يمكنني تضمين أي خط مخصص دون قيود؟

أنت مسؤول عن الالتزام بترخيص الخط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. راجع دائمًا اتفاقية ترخيص الخط (EULA) قبل توزيع المخرجات.