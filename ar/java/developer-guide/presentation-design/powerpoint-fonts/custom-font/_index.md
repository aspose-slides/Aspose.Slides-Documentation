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
- مجلد الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides للـ Java للحفاظ على عرض تقديمك واضحًا ومتسقًا عبر أي جهاز."
---
## **نظرة عامة**

Aspose.Slides يتيح لك استخدام خطوط مخصصة في العروض التقديمية بدون تثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، توفير الخطوط لعروض تقديمية معينة عبر مصادر الخط على مستوى المستند، أو تحميل خطوط خارجية مباشرة من البيانات الثنائية.

يتم استخدام الخطوط المحملة عند عرض أو تصدير العرض التقديمي، على سبيل المثال إلى PDF أو صور أو صيغ أخرى مدعومة. يساعد ذلك في الحفاظ على اتساق ناتج العرض عبر بيئات مختلفة. توضح المقالة أيضًا كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة تخزين الخطوط المؤقتة بعد العمل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للتصوير مختلف عن دمج الخطوط في ملف PPTX. إذا كان يجب تخزين الخط داخل العرض نفسه، استخدم ميزات دمج الخطوط صراحةً.

يمكن لمظهر العرض الإشارة إلى عائلات خطوط مختلفة لأنظمة كتابة معينة. هذه الخرائط تخزن أسماء الخطوط ولكنها لا تثبت أو تحمل ملفات الخط. راجع [خطوط المظهر الخاصة بالنصوص](/slides/ar/java/script-specific-font-mappings/) لإدارة هذه الخرائط، واستخدم خيارات التحميل أدناه لجعل الخطوط المشار إليها متاحة للتصوير المتسق.

{{% alert color="info" title="Note" %}}
Aspose Slides يتيح لك تحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). انظر إلى [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). انظر إلى [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **تحميل الخطوط المخصصة**

Aspose.Slides يتيح لك تحميل الخطوط المستخدمة في العرض دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير — مثل PDF والصور وغيرها من الصيغ المدعومة — بحيث تظهر المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من أدلة مخصصة.

1. حدد مجلدًا واحدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الثابتة [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) لتحميل الخطوط من تلك المجلدات.
3. حمّل وقم بعرض/تصدير العرض.
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#clearCache--) لمسح ذاكرة تخزين الخط المؤقت.

```java
import com.aspose.slides.*;

// حدد المجلدات التي تحتوي على ملفات خطوط مخصصة.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// حمّل الخطوط المخصصة من المجلدات المحددة.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // اعرض/صدّر العرض التقديمي (مثل PDF أو صور أو صيغ أخرى) باستخدام الخطوط التي تم تحميلها.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // امسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) يضيف مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغيّر ترتيب تهيئة الخط.  
يتم تهيئة الخطوط بالترتيب التالي:

1. المسار الافتراضي لخط نظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**

Aspose.Slides توفر طريقة [getFontFolders](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#getFontFolders--) التي تسمح لك بالعثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي أضيفت عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يعرض هذا الكود Java كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// هذا السطر يعرض المجلدات التي يتم البحث فيها عن ملفات الخط.
 // هذه هي المجلدات التي أضيفت عبر طريقة LoadExternalFonts ومجلدات خطوط النظام.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**

Aspose.Slides توفر الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) التي تتيح لك تحديد الخطوط الخارجية التي سيتم استخدامها مع العرض.

يعرض هذا الكود Java كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // CustomFont1، CustomFont2، والخطوط من المجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
} finally {
    if (pres != null) pres.dispose();
}
```

## **إدارة الخطوط خارجيًا**

Aspose.Slides توفر الطريقة [loadExternalFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) التي تسمح لك بتحميل الخطوط الخارجية من بيانات ثنائية.

يعرض هذا الكود Java عملية تحميل الخط من مصفوفة بايت:

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
        // خط خارجي تم تحميله طوال فترة عمر العرض التقديمي
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF، PNG، SVG، HTML)؟

نعم. يتم استخدام الخطوط المرتبطة بواسطة المُعالج عبر جميع صيغ التصدير.

### هل يتم دمج الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟

لا. تسجيل الخط للتصوير لا يساوي دمجه في ملف PPTX. إذا كنت بحاجة إلى حمل الخط داخل ملف العرض، يجب عليك استخدام [ميزات الدمج](/slides/ar/java/embedded-font/) صراحةً.

### هل يمكنني التحكم في سلوك الاحتياطي عندما يفتقر الخط المخصص إلى بعض الأحرف؟

نعم. قم بتكوين [استبدال الخط](/slides/ar/java/font-substitution/)، [قواعد الاستبدال](/slides/ar/java/font-replacement/)، و[مجموعات الاحتياطي](/slides/ar/java/fallback-font/) لتحديد الخط المستخدم بالضبط عندما تكون الأحرف المطلوبة غير موجودة.

### هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟

جزئيًا. يمكن لـ Aspose.Slides استخدام الخطوط من المجلدات الخاصة أو من مصفوفات البايت دون تثبيتها، لكن دعم الخطوط في Java لا يزال يحتاج إلى وجود خط واحد مثبت على الأقل في الصورة. بدون ذلك، يفشل التحميل مع الخطأ "Fontconfig head is null, check your fonts or fonts configuration". راجع [نشر الخطوط](/slides/ar/java/deploy-fonts/).

### ماذا عن الترخيص — هل يمكنني دمج أي خط مخصص دون قيود؟

أنت المسؤول عن الامتثال لتراخيص الخطوط. تختلف الشروط؛ بعض الترخيصات تحظر الدمج أو الاستخدام التجاري. دائمًا راجع اتفاقية ترخيص المستخدم النهائي للخط قبل توزيع المخرجات.