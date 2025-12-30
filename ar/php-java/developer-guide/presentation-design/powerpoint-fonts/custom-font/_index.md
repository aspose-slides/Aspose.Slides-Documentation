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
- مجلد الخطوط
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "قم بتخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides للـ PHP عبر Java للحفاظ على عروضك التقديمية حادة ومتسقة عبر أي جهاز."
---

{{% alert color="primary" %}}

يسمح Aspose Slides بتحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) وTrueType Collection (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).
* خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل الخطوط المخصصة**

يسمح Aspose.Slides بتحميل الخطوط التي تُعرض في العروض التقديمية دون الحاجة إلى تثبيت هذه الخطوط. يتم تحميل الخطوط من دليل مخصص.

1. أنشئ مثَلاً من الفئة [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) واستدعي طريقة [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. قم بتحميل العرض التقديمي الذي سيتم عرضه.
3. [مسح الذاكرة المؤقتة](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--) في الفئة [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

يعرض هذا الكود PHP عملية تحميل الخطوط:
```php
  # المجلدات للبحث عن الخطوط
  $folders = array($externalFontsDir );
  # تحميل خطوط دليل الخطوط المخصَّصة
  FontsLoader->loadExternalFonts($folders);
  # قم ببعض العمل وأجرِ عرض تقديمي/تقديم شريحة
  $pres = new Presentation("DefaultFonts.pptx");
  try {
    $pres->save("NewFonts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
    # يمسح ذاكرة الخط المؤقتة
    FontsLoader->clearCache();
  }
```


## **الحصول على مجلدات الخطوط المخصصة**

توفر Aspose.Slides طريقة [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) لتسمح لك بالعثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات المضافة عبر طريقة `LoadExternalFonts` ومجلدات خطوط النظام.

يعرض هذا الكود PHP كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--):
```php
  # يطبع هذا السطر المجلدات التي يتم البحث فيها عن ملفات الخطوط.
  # تلك هي المجلدات التي تمت إضافتها عبر طريقة LoadExternalFonts ومجلدات خطوط النظام.
  $fontFolders = FontsLoader->getFontFolders();
```


## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**

توفر Aspose.Slides الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) لتسمح لك بتحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

يعرض هذا الكود PHP كيفية استخدام الخاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
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
    # CustomFont1، CustomFont2، والخطوط من مجلدي assets\fonts & global\fonts ومجلداتهما الفرعية متاحة للعرض التقديمي
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إدارة الخطوط خارجيًا**

توفر Aspose.Slides طريقة [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) لتحميل الخطوط الخارجية من بيانات ثنائية.

يعرض هذا الكود PHP عملية تحميل الخطوط من مصفوفة البايت:
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
      # تم تحميل الخط الخارجي خلال مدة عرض الشرائح
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```


## **الأسئلة المتكررة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF، PNG، SVG، HTML)?**

نعم. تُستخدم الخطوط المتصلة بواسطة المُعالج في جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للعرض ليس هو نفسه تضمينه في PPTX. إذا كنت بحاجة إلى حمل الخط داخل ملف العرض التقديمي، يجب عليك استخدام [ميزات التضمين](/slides/ar/php-java/embedded-font/).

**هل يمكنني التحكم في سلوك الاحتياطي عندما يفتقر الخط المخصص إلى بعض الرموز؟**

نعم. يمكنك إعداد [استبدال الخط](/slides/ar/php-java/font-substitution/)، [قواعد الاستبدال](/slides/ar/php-java/font-replacement/)، و[مجموعات الاحتياطي](/slides/ar/php-java/fallback-font/) لتحديد الخط المستخدم بالضبط عندما يكون الرمز المطلوب غير موجود.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. قم بالإشارة إلى مجلدات الخطوط الخاصة بك أو حمل الخطوط من مصفوفات البايت. هذا يزيل أي اعتماد على مجلدات الخطوط النظامية في صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت مسؤول عن الامتثال لترخيص الخطوط. تختلف الشروط؛ بعض الترخيصات تحظر التضمين أو الاستخدام التجاري. احرص دائمًا على مراجعة اتفاقية ترخيص المستخدم النهائي للخط قبل توزيع المخرجات.