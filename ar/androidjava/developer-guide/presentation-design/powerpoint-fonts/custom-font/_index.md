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
description: "تخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides لنظام Android عبر Java لضمان وضوح وتناسق عروضك التقديمية على أي جهاز."
---
## **نظرة عامة**

Aspose.Slides يسمح لك باستخدام خطوط مخصصة في العروض التقديمية دون تثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير خطوط لعرض تقديمي محدد عبر مصادر الخط على مستوى المستند، أو تحميل خطوط خارجية مباشرة من بيانات ثنائية.

يتم استخدام الخطوط المحملة عند عرض تقديمي يتم تصييره أو تصديره، على سبيل المثال إلى PDF أو صور أو صيغ أخرى مدعومة. يساعد ذلك في الحفاظ على اتساق مخرجات العرض عبر بيئات مختلفة. توضح المقالة أيضًا كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد العمل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للتص rendering هو أمر منفصل عن تضمين الخطوط في ملف PPTX. إذا كان يجب حفظ الخط داخل العرض التقديمي نفسه، استخدم ميزات تضمين الخطوط بشكل صريح.

يمكن لمظهر العرض التقديمي الإشارة إلى عائلات خطوط مختلفة لأنظمة الكتابة الفردية. تخزن هذه المخططات أسماء الخطوط لكنها لا تقوم بتثبيت أو تحميل ملفات الخط. راجع [Script-Specific Theme Fonts](/slides/ar/androidjava/script-specific-font-mappings/) لإدارة المخططات، واستخدم خيارات التحميل أدناه لجعل الخطوط المشار إليها متاحة للتص rendering المتسق.

{{% alert color="info" title="ملاحظة" %}}
Aspose Slides يسمح لك بتحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):
* خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **تحميل خطوط مخصصة**

Aspose.Slides يسمح لك بتحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. هذا يؤثر على مخرجات التصدير—مثل PDF، الصور، والصيغ المدعومة الأخرى—بحيث تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من مجلدات مخصصة.

1. حدد مجلدًا واحدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الساكنة [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) لتحميل الخطوط من تلك المجلدات.
3. حمّل وقم بعرض أو تصدير العرض التقديمي.
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/FontsLoader#clearCache--) لمسح ذاكرة التخزين المؤقت للخطوط.

المثال البرمجي التالي يوضح عملية تحميل الخطوط:

```java
import com.aspose.slides.*;

// تحديد المجلدات التي تحتوي على ملفات خطوط مخصصة.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Load custom fonts from the specified folders.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // عرض/تصدير العرض التقديمي (مثل PDF أو صور أو صيغ أخرى) باستخدام الخطوط المحملة.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // مسح ذاكرة التخزين المؤقت للخطوط بعد انتهاء العمل.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="ملاحظة" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) يضيف مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط.
يتم تهيئة الخطوط بالترتيب التالي:
1. مسار الخط الافتراضي في نظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**

Aspose.Slides يوفر الطريقة [getFontFolders](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) لتتيح لك العثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي أضيفت عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

هذا الكود Java يوضح كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// هذا السطر يعرض المجلدات التي يتم البحث فيها عن ملفات الخطوط.
// تلك هي المجلدات التي تم إضافتها عبر طريقة LoadExternalFonts ومجلدات خطوط النظام.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع العرض التقديمي**

Aspose.Slides يوفر الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) لتتيح لك تحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

هذا الكود Java يوضح كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // CustomFont1، CustomFont2، والخطوط من مجلدات assets\fonts وglobal\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة الخطوط خارجيًا**

Aspose.Slides يوفر الطريقة [loadExternalFont](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) لتتيح لك تحميل الخطوط الخارجية من بيانات ثنائية.

هذا الكود Java يوضح عملية تحميل الخط من مصفوفة بايت:

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
        // تم تحميل الخط الخارجي طوال عمر العرض التقديمي
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

نعم. يتم استخدام الخطوط المتصلة بواسطة أداة التص rendering عبر جميع صيغ التصدير.

### هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟

لا. تسجيل الخط للتص rendering ليس هو نفسه تضمينه في ملف PPTX. إذا كنت بحاجة إلى حمل الخط داخل ملف العرض التقديمي، يجب عليك استخدام [ميزات التضمين](/slides/ar/androidjava/embedded-font/) صراحةً.

### هل يمكنني التحكم في سلوك الاحتياطي عندما يفتقر الخط المخصص إلى بعض الرموز؟

نعم. قم بتهيئة [استبدال الخط](/slides/ar/androidjava/font-substitution/)، [قواعد الاستبدال](/slides/ar/androidjava/font-replacement/)، و[مجموعات الاحتياطي](/slides/ar/androidjava/fallback-font/) لتحديد الخط الذي يُستخدم بالضبط عندما يكون الرمز المطلوب مفقودًا.

### هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟

نعم. اشِر إلى مجلدات الخطوط الخاصة بك أو حمّل الخطوط من مصفوفات البايت. هذا يزيل أي اعتماد على مجلدات الخطوط النظامية في صورة الحاوية.

### ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص بدون قيود؟

أنت مسؤول عن الالتزام بترخيص الخط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. تحقق دائمًا من اتفاقية ترخيص المستخدم النهائي للخط قبل توزيع المخرجات.