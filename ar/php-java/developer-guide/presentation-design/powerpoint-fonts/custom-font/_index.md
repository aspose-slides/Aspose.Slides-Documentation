---
title: تخصيص خطوط PowerPoint في PHP
linktitle: الخط المخصص
type: docs
weight: 20
url: /ar/php-java/custom-font/
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
- PHP
- Aspose.Slides
description: "تخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides للـ PHP عبر Java للحفاظ على عروضك حادة ومتسقة عبر أي جهاز."
---
## **نظرة عامة**

Aspose.Slides يتيح لك استخدام الخطوط المخصصة في العروض التقديمية دون تثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير خطوط لعروض تقديمية معينة من خلال مصادر خطوط على مستوى المستند، أو تحميل خطوط خارجية مباشرة من بيانات ثنائية.

يتم استخدام الخطوط التي تم تحميلها عندما يتم عرض أو تصدير العرض التقديمي، على سبيل المثال إلى PDF أو صور أو صيغ أخرى مدعومة. يساعد ذلك في الحفاظ على تناسق مخرجات العرض عبر بيئات مختلفة. توضح هذه المقالة أيضًا كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد العمل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للتصوير منفصل عن تضمين الخطوط في ملف PPTX. إذا كان يجب تخزين الخط داخل العرض نفسه، استخدم ميزات تضمين الخطوط صراحةً.

يمكن لمظهر العرض الإشارة إلى عائلات خطوط مختلفة لأنظمة كتابة منفصلة. هذه الربطيات تخزن أسماء الخطوط لكنها لا تقوم بتثبيت أو تحميل ملفات الخط. راجع [Script-Specific Theme Fonts](/slides/ar/php-java/script-specific-font-mappings/) لإدارة الربطيات، واستخدم خيارات التحميل أدناه لجعل الخطوط المشار إليها متاحة للتصوير المتسق.

{{% alert color="info" title="ملاحظة" %}}

Aspose Slides يتيح لك تحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) وTrueType Collection (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل خطوط مخصصة**

Aspose.Slides يتيح لك تحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر هذا على مخرجات التصدير—مثل PDF أو صور أو صيغ أخرى مدعومة—بحيث تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من دلائل مخصصة.

1. حدد مجلدًا واحدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الساكنة [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) لتحميل الخطوط من تلك المجلدات.
3. حمّل وقم بعرض/تصدير العرض التقديمي.
4. استدعِ [FontsLoader::clearCache](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#clearCache--) لمسح ذاكرة التخزين المؤقت للخطوط.

يظهر المثال البرمجي التالي عملية تحميل الخطوط:

```php
// تعريف المجلدات التي تحتوي على ملفات خطوط مخصصة.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// تحميل خطوط مخصصة من المجلدات المحددة.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // عرض/تصدير العرض التقديمي (مثل PDF أو صور أو صيغ أخرى) باستخدام الخطوط المحملة.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // مسح ذاكرة التخزين المؤقت للخطوط بعد انتهاء العمل.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="ملاحظة" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) يضيف مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط. تُهيّأ الخطوط بالترتيب التالي:

1. مسار الخط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**
Aspose.Slides يوفر الطريقة [getFontFolders](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#getFontFolders--) لتسمح لك بالعثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي أضيفت عبر طريقة `LoadExternalFonts` ومجلدات خطوط النظام.

يعرض هذا الكود PHP كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# هذا السطر يخرج المجلدات التي يتم البحث فيها عن ملفات الخط.
# هذه هي المجلدات التي أضيفت عبر طريقة LoadExternalFonts ومجلدات خطوط النظام.
$fontFolders = FontsLoader::getFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**
Aspose.Slides يوفر الطريقة [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) لتسمح لك بتحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

يعرض هذا الكود PHP كيفية استخدام الطريقة [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # العمل مع العرض التقديمي
    # الخطوط CustomFont1 و CustomFont2، وكذلك الخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **إدارة الخطوط خارجيًا**

Aspose.Slides يوفر الطريقة [loadExternalFont](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) لتسمح لك بتحميل خطوط خارجية من بيانات ثنائية.

يظهر هذا الكود PHP عملية تحميل الخط من مصفوفة بايت:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # الخط الخارجي تم تحميله أثناء مدة العرض التقديمي
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **الأسئلة المتكررة**

### هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟

نعم. تُستخدم الخطوط المتصلة بواسطة المُعالج عبر جميع صيغ التصدير.

### هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟

لا. تسجيل الخط للتصوير ليس هو نفسه تضمينه في PPTX. إذا كنت بحاجة إلى احتواء الخط داخل ملف العرض، يجب استخدام [ميزات التضمين](/slides/ar/php-java/embedded-font/).

### هل يمكنني التحكم في سلوك السقوط عندما يفتقر الخط المخصص إلى بعض الأحرف؟

نعم. اضبط [استبدال الخط](/slides/ar/php-java/font-substitution/)، [قواعد الاستبدال](/slides/ar/php-java/font-replacement/)، و[مجموعات السقوط](/slides/ar/php-java/fallback-font/) لتحديد الخط الذي سيُستخدم عندما تكون الحرف المطلوب غير موجود.

### هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟

نعم. اشِر إلى مجلدات الخط الخاصة بك أو حمّل الخطوط من مصفوفات بايت. يزيل ذلك أي اعتماد على دلائل خطوط النظام داخل صورة الحاوية.

### ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟

أنت المسؤول عن الالتزام بترخيص الخط. تختلف الشروط؛ بعض الترخيصات تحظر التضمين أو الاستخدام التجاري. تأكد دائمًا من مراجعة اتفاقية ترخيص المستخدم النهائي للخط قبل توزيع المخرجات.