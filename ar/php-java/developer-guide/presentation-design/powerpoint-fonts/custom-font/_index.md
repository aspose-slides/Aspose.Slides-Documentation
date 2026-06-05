---
title: تخصيص خطوط PowerPoint في PHP
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/php-java/custom-font/
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
- PHP
- Aspose.Slides
description: "قم بتخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides للـ PHP عبر Java للحفاظ على عروضك التقديمية حادة ومتسقة عبر أي جهاز."
---
## **نظرة عامة**

Aspose.Slides يسمح لك باستخدام الخطوط المخصصة في العروض التقديمية دون الحاجة لتثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير خطوط لعروض تقديمية محددة عبر مصادر الخطوط على مستوى المستند، أو تحميل الخطوط الخارجية مباشرةً من بيانات ثنائية.

تُستخدم الخطوط التي تم تحميلها عند عرض أو تصدير العرض التقديمي، على سبيل المثال إلى PDF أو صور أو صيغ أخرى مدعومة. يساعد ذلك في الحفاظ على تناسق مخرجات العرض عبر بيئات مختلفة. توضح المقالة أيضًا كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد العمل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للتص Rendering مختلف عن تضمين الخطوط داخل ملف PPTX. إذا كان لابد من تخزين الخط داخل العرض نفسه، استخدم ميزات تضمين الخطوط صراحةً.

{{% alert color="primary" %}} 
Aspose Slides يسمح لك بتحميل هذه الخطوط باستخدام الطريقة [loadExternalFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) وTrueType Collection (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **تحميل الخطوط المخصصة**

Aspose.Slides يسمح لك بتحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير—مثل PDF، الصور، والصيغ المدعومة الأخرى—لذلك تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من دلائل مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخطوط.
2. استدعِ الطريقة الساكنة [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) لتحميل الخطوط من تلك المجلدات.
3. حمِّل وابدأ عرض/تصدير العرض التقديمي.
4. استدعِ [FontsLoader::clearCache](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#clearCache--) لمسح ذاكرة التخزين المؤقت للخطوط.

الكود التالي يوضح عملية تحميل الخطوط:

```php
// حدد المجلدات التي تحتوي على ملفات الخطوط المخصصة.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// حمل الخطوط المخصصة من المجلدات المحددة.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // عرض/تصدير العرض التقديمي (مثلاً إلى PDF أو صور أو صيغ أخرى) باستخدام الخطوط المحمَّلة.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) يضيف مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط. يتم تهيئة الخطوط بالترتيب التالي:

1. مسار الخط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**
Aspose.Slides يوفر الطريقة [getFontFolders](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#getFontFolders--) للسماح لك باكتشاف مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي أُضيفت عبر طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

هذا الكود PHP يوضح كيفية استعمال [getFontFolders](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# هذا السطر يعرض المجلدات التي يتم البحث فيها عن ملفات الخط.
# هذه هي المجلدات التي تمت إضافتها عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
$fontFolders = FontsLoader::getFontFolders();
```

## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**
Aspose.Slides يوفر الطريقة [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) للسماح لك بتحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

هذا الكود PHP يوضح كيفية استعمال [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    # الخطوط CustomFont1 و CustomFont2 والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **إدارة الخطوط خارجيًا**

Aspose.Slides يوفر الطريقة [loadExternalFont](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) للسماح لك بتحميل الخطوط الخارجية من بيانات ثنائية.

هذا الكود PHP يوضح عملية تحميل الخط من مصفوفة بايت:

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
        # تم تحميل الخط الخارجي أثناء مدة عرض الشرائح
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

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟**

نعم. الخطوط المتصلة تُستخدم من قبل المُعالج عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للتص Rendering ليس هو نفسه تضمينه في PPTX. إذا كنت بحاجة إلى أن يُحمل الخط داخل ملف العرض، يجب عليك استخدام ميزات [embedding features](/slides/ar/php-java/embedded-font/).

**هل يمكنني التحكم في سلوك التعويض عندما يفتقد الخط المخصص بعض الرموز؟**

نعم. اضبط [font substitution](/slides/ar/php-java/font-substitution/)، [replacement rules](/slides/ar/php-java/font-replacement/)، و[fallback sets](/slides/ar/php-java/fallback-font/) لتحديد الخط الذي يُستخدم عندما يكون الرمز المطلوب غير متوفر.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. أشر إلى مجلدات الخطوط الخاصة بك أو حمِّل الخطوط من مصفوفات بايت. هذا يُزيل أي اعتماد على دلائل الخطوط النظامية داخل صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت مسؤول عن الالتزام بترخيص الخط. تختلف الشروط؛ بعض الرخص تحظر التضمين أو الاستخدام التجاري. تحقق دائمًا