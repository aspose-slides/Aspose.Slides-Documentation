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
description: "قُم بتخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides للـ PHP عبر Java للحفاظ على عروضك التقديمية حادة ومتسقة عبر أي جهاز."
---

{{% alert color="primary" %}} 

Aspose Slides يتيح لك تحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) وTrueType Collection (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

Aspose.Slides يتيح لك تحميل الخطوط المستخدمة في العرض التقديمي دون تثبيتها على النظام. هذا يؤثر على مخرجات التصدير — مثل PDF، الصور، وغيرها من الصيغ المدعومة — وبالتالي تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من أدلة مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخطوط.  
2. استدعي الطريقة الساكنة [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/) لتحميل الخطوط من تلك الأدلة.  
3. حمّل واعرض/صدّر العرض التقديمي.  
4. استدعِ [FontsLoader::clearCache](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/clearcache/) لمسح ذاكرة الخطوط المؤقتة.

يوضح المثال البرمجي التالي عملية تحميل الخطوط:
```php
// تحديد المجلدات التي تحتوي على ملفات الخطوط المخصصة.
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// تحميل الخطوط المخصصة من المجلدات المحددة.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentation = new Presentation("sample.pptx");
    
    // تصدير/رندر العرض التقديمي (مثل PDF أو صور أو صيغ أخرى) باستخدام الخطوط المحملة.
    $presentation->save("output.pdf", SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // مسح ذاكرة الخط المؤقتة بعد الانتهاء من العمل.
    FontsLoader::clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/) يضيف أدلة إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط.  
يتم تهيئة الخطوط بالترتيب التالي:

1. مسار الخط الافتراضي لنظام التشغيل.  
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **الحصول على أدلة الخطوط المخصصة**
Aspose.Slides توفر الطريقة [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) للعثور على أدلة الخطوط. تُعيد هذه الطريقة الأدلة التي أُضيفت عبر طريقة `LoadExternalFonts` وأدلة الخطوط النظامية.

يوضح هذا الكود PHP كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--):
```php
  # هذا السطر يطبع المجلدات التي يتم البحث فيها عن ملفات الخطوط.
  # هذه هي المجلدات التي أضيفت عبر طريقة LoadExternalFonts ومجلدات خطوط النظام.
  $fontFolders = FontsLoader->getFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**
Aspose.Slides توفر الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) لتحديد الخطوط الخارجية التي سيُستخدمها العرض التقديمي.

هذا الكود PHP يوضح كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
```php
  $Array = new JavaClass("java.lang.reflect.Array");
  $Byte = new JavaClass("java.lang.Byte");
  $file1 = new Java("java.io.File", "customfonts/CustomFont1.ttf");
  $memoryFont1 = $Array->newInstance($Byte, $Array->getLength($file1));
  try {
      $dis1 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file1));
      $dis1->readFully($memoryFont1);
  } finally {
      if (!java_is_null($dis1)) $dis1->close();
  }
  $file2 = new Java("java.io.File", "customfonts/CustomFont2.ttf");
  $memoryFont2 = $Array->newInstance($Byte, $Array->getLength($file2));
  try {
        $dis2 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file2));
        $dis2->readFully($memoryFont2);
  } finally {
        if (!java_is_null($dis2)) $dis2->close();
  }
  $loadOptions = new LoadOptions();
  $loadOptions->getDocumentLevelFontSources()->setFontFolders(array("assets/fonts", "global/fonts" ));
  $loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));
  $pres = new Presentation("MyPresentation.pptx", $loadOptions);
  try {
    # العمل مع العرض التقديمي
    # CustomFont1, CustomFont2، والخطوط من مجلدات assets\fonts و global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إدارة الخطوط خارجياً**

Aspose.Slides توفر الطريقة [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) لتحميل الخطوط الخارجية من بيانات بايتية.

هذا الكود PHP يوضح عملية تحميل الخط من مصفوفة بايت:
```php
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALN.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNBI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

  try {
    $pres = new Presentation("");
    try {
      # الخط الخارجي محمَّل أثناء عمر العرض التقديمي
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```


## **FAQ**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)؟**

نعم. تُستخدم الخطوط المتصلة من قبل المحرك عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للاستخدام في العرض لا يعني تضمينه داخل ملف PPTX. إذا كنت بحاجة إلى تضمين الخط داخل الملف، يجب استخدام ميزات [التضمين](/slides/ar/php-java/embedded-font/).

**هل يمكن التحكم بسلوك الاستبدال عندما يفتقر الخط المخصص إلى بعض الرموز؟**

نعم. يمكنك تكوين [استبدال الخطوط](/slides/ar/php-java/font-substitution/)، [قواعد الاستبدال](/slides/ar/php-java/font-replacement/)، و[مجموعات الاستبدال](/slides/ar/php-java/fallback-font/) لتحديد الخط الذي يُستخدم عندما يكون الرمز غير متوفر.

**هل يمكن استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على النظام؟**

نعم. يمكنك الإشارة إلى أدلة الخطوط الخاصة بك أو تحميل الخطوط من مصفوفات بايتية. هذا يلغي أي اعتماد على أدلة الخطوط النظامية داخل صورة الحاوية.

**ماذا عن الترخيص — هل يمكن تضمين أي خط مخصص دون قيود؟**

أنت مسؤول عن الالتزام بترخيص الخط. تختلف الشروط؛ بعض التراخيص تمنع التضمين أو الاستخدام التجاري. تأكد دائمًا من مراجعة اتفاقية الترخيص (EULA) الخاصة بالخط قبل توزيع المخرجات.