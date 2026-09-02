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
- تحميل خط
- إدارة الخطوط
- مجلد الخطوط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "خصص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides لل Java للحفاظ على عروضك التقديمية واضحة ومتسقة عبر أي جهاز."
---
## **نظرة عامة**

تتيح لك Aspose.Slides استخدام خطوط مخصصة في العروض التقديمية دون تثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير الخطوط لعروض تقديمية محددة عبر مصادر الخط على مستوى المستند، أو تحميل خطوط خارجية مباشرة من بيانات ثنائية.

تُستخدم الخطوط المحملة عند عرض أو تصدير العرض التقديمي، على سبيل المثال إلى PDF أو صور أو تنسيقات أخرى مدعومة. يساعد ذلك في الحفاظ على تناسق مخرجات العرض عبر بيئات مختلفة. تشرح المقالة أيضًا كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد العمل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للعرض مختلف عن تضمين الخطوط في ملف PPTX. إذا كان يجب تخزين الخط داخل العرض نفسه، استخدم ميزات تضمين الخطوط صراحة.

يمكن لثيم العرض أن يشير إلى عائلات خطوط مختلفة لأنظمة الكتابة الفردية. هذه التخطيطات تخزن أسماء الخطوط لكنها لا تثبت أو تحمّل ملفات الخط. راجع [خطوط الثيم المخصصة للسكريبت](/slides/ar/java/script-specific-font-mappings/) لإدارة التخطيطات، واستخدم خيارات التحميل أدناه لجعل الخطوط المشار إليها متاحة للعرض المتناسق.

{{% alert color="info" title="ملاحظة" %}}
تسمح لك Aspose Slides بتحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) :

* خطوط TrueType (.ttf) و TrueType Collection (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **تحميل الخطوط المخصصة**

تتيح لك Aspose.Slides تحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير — مثل PDF أو الصور أو تنسيقات أخرى مدعومة — بحيث تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من أدلة مخصصة.

1. حدّد مجلدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الثابتة [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) لتحميل الخطوط من تلك المجلدات.
3. حمّل العرض وقم بعرضه/تصديره.
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/ar/java/com.aspose.slides/FontsLoader#clearCache--) لمسح ذاكرة التخزين المؤقت للخطوط.

يظهر المثال البرمجي التالي عملية تحميل الخطوط:
```java
import com.aspose.slides.*;

// حدد المجلدات التي تحتوي على ملفات خطوط مخصصة.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// تحميل الخطوط المخصصة من المجلدات المحددة.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // عرض/تصدير العرض التقديمي (مثلاً إلى PDF أو صور أو صيغ أخرى) باستخدام الخطوط المحملة.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="ملاحظة" %}}
تضيف طريقة [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنها لا تغيّر ترتيب تهيئة الخطوط. يتم تهيئة الخطوط بالترتيب التالي:

1. مسار الخط الافتراضي في نظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**

توفر Aspose.Slides الطريقة [getFontFolders](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#getFontFolders--) لتسمح لك بالعثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي تمت إضافتها عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يعرض لك هذا الكود الجافا كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#getFontFolders--):
```java
import com.aspose.slides.*;

// يطبع هذا السطر المجلدات التي يتم البحث فيها عن ملفات الخطوط.
// هذه هي المجلدات التي تم إضافتها عبر طريقة LoadExternalFonts ومجلدات خطوط النظام.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**

توفر Aspose.Slides الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) لتسمح لك بتحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

يعرض لك هذا الكود الجافا كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
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
    // CustomFont1, CustomFont2، والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة الخطوط خارجيًا**

توفر Aspose.Slides الطريقة [loadExternalFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) لتحميل الخطوط الخارجية من بيانات ثنائية.

يعرض لك هذا الكود الجافا عملية تحميل الخط من مصفوفة بايت:
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

### هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟

نعم. تُستخدم الخطوط المرتبطة بواسطة عارض الرسوم عبر جميع صيغ التصدير.

### هل تُضمَّن الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟

لا. تسجيل الخط للعرض ليس نفسه كضمّه إلى ملف PPTX. إذا كنت بحاجة إلى حمل الخط داخل ملف العرض، يجب عليك استخدام [ميزات الضم](/slides/ar/java/embedded-font/).

### هل يمكنني التحكم في سلوك الاحتياطي عندما يفتقر الخط المخصص إلى بعض الحروف؟

نعم. قم بتهيئة [استبدال الخطوط](/slides/ar/java/font-substitution/)، [قواعد الاستبدال](/slides/ar/java/font-replacement/)، و[مجموعات الاحتياطي](/slides/ar/java/fallback-font/) لتحديد الخط المستخدم بالضبط عندما يكون الحرف المطلوب غير موجود.

### هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟

نعم. أشِر إلى مجلدات الخطوط الخاصة بك أو حمّل الخطوط من مصفوفات بايت. هذا يزيل أي اعتماد على دلائل الخطوط النظامية داخل صورة الحاوية.

### ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص بدون قيود؟

أنت مسؤول عن الامتثال لتراخيص الخطوط. الشروط تختلف؛ بعض الترخيصات تحظر الضم أو الاستخدام التجاري. تحقق دائمًا من اتفاقية ترخيص المستخدم النهائي للخط قبل توزيع المخرجات.