---
title: "تخصيص خطوط PowerPoint في Java"
linktitle: "خط مخصص"
type: docs
weight: 20
url: /ar/java/custom-font/
keywords:
- "خط"
- "خط مخصص"
- "خط خارجي"
- "تحميل الخط"
- "إدارة الخطوط"
- "مجلد الخطوط"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- "Java"
- "Aspose.Slides"
description: "خصّص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides للـ Java لتبقى عروضك التقديمية واضحة ومتناسقة على أي جهاز."
---
## **نظرة عامة**

تتيح لك Aspose.Slides استخدام خطوط مخصصة في العروض التقديمية دون الحاجة لتثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير خطوط لعروض تقديمية معينة عبر مصادر الخطوط على مستوى المستند، أو تحميل خطوط خارجية مباشرة من بيانات ثنائية.

تُستخدم الخطوط التي تم تحميلها عند عرض أو تصدير العرض التقديمي، مثل PDF أو الصور أو الصيغ المدعومة الأخرى. يساعد ذلك في الحفاظ على مظهر المخرجات متسقًا عبر بيئات مختلفة. يشرح المقال أيضًا كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد العمل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للعرض منفصل عن تضمين الخطوط داخل ملف PPTX. إذا كان لابد من تخزين الخط داخل العرض نفسه، استخدم ميزات تضمين الخطوط صراحةً.

{{% alert color="info" %}} 
تمكنك Aspose Slides من تحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):
* خطوط TrueType (.ttf) وTrueType Collection (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **تحميل الخطوط المخصصة**

تتيح لك Aspose.Slides تحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير—مثل PDF والصور والصيغ المدعومة الأخرى—بحيث تبدو المستندات الناتجة متسقة عبر البيئة. تُحمَّل الخطوط من دلائل مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الساكنة [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) لتحميل الخطوط من تلك المجلدات.
3. حمّل العرض وقم بعملية العرض/التصدير.
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontsLoader#clearCache--) لمسح ذاكرة التخزين المؤقت للخطوط.

المثال البرمجي التالي يوضح عملية تحميل الخطوط:

```java
import com.aspose.slides.*;

// تعريف المجلدات التي تحتوي على ملفات الخطوط المخصصة.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// تحميل الخطوط المخصصة من المجلدات المحددة.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // عرض/تصدير العرض التقديمي (مثلاً إلى PDF، صور، أو صيغ أخرى) باستخدام الخطوط المحمّلة.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
يقوم [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) بإضافة مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط. يتم تهيئة الخطوط بالترتيب التالي:
1. مسار الخط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**

توفر Aspose.Slides الطريقة [getFontFolders](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#getFontFolders--) التي تسمح لك باكتشاف مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي تمت إضافتها عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

الكود التالي في جافا يوضح كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// هذا السطر يعرض المجلدات التي يتم البحث فيها عن ملفات الخطوط.
// تلك هي المجلدات التي تم إضافتها عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**

توفر Aspose.Slides الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) التي تسمح لك بتحديد الخطوط الخارجية التي سيُستخدم معها العرض التقديمي.

الكود التالي في جافا يوضح كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // الخطوط CustomFont1 و CustomFont2، والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة الخطوط خارجيًا**

توفر Aspose.Slides الطريقة [loadExternalFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) التي تسمح لك بتحميل خطوط خارجية من بيانات ثنائية.

الكود التالي في جافا يوضح عملية تحميل الخط من مصفوفة بايتات:

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
        // تم تحميل الخط الخارجي خلال فترة عرض العرض التقديمي
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **الأسئلة المتكررة**

### هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟

نعم. تُستخدم الخطوط المتصلة من قبل المُعالج عبر جميع صيغ التصدير.

### هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟

لا. تسجيل الخط للعرض ليس هو نفسه تضمينه في PPTX. إذا كنت بحاجة إلى أن يكون الخط موجودًا داخل ملف العرض، عليك استخدام [ميزات التضمين](/slides/ar/java/embedded-font/) صراحةً.

### هل يمكنني التحكم في سلوك fallback عندما يفتقد الخط المخصص بعض الرموز؟

نعم. قم بتهيئة [font substitution](/slides/ar/java/font-substitution/)، [replacement rules](/slides/ar/java/font-replacement/)، و[fallback sets](/slides/ar/java/fallback-font/) لتحديد الخط المحدد الذي يُستخدم عندما يكون الرمز المطلوب غير موجود.

### هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟

نعم. اشِر إلى مجلدات الخطوط الخاصة بك أو حمّل الخطوط من مصفوفات بايتات. يزيل ذلك أي اعتماد على دلائل الخطوط النظامية في صورة الحاوية.

### ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟

أنت المسؤول عن الامتثال لترخيص الخط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. راجع دائمًا اتفاقية ترخيص المستخدم النهائي (EULA) للخط قبل توزيع المخرجات.