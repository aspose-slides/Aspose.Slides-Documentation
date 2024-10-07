---
title: خط مخصص ل PowerPoint
linktitle: خط مخصص
type: docs
weight: 20
url: /php-java/custom-font/
keywords: "خطوط، خطوط مخصصة، عرض PowerPoint، Java، Aspose.Slides لـ PHP عبر Java"
description: "خطوط PowerPoint المخصصة"
---

{{% alert color="primary" %}} 

تتيح لك Aspose Slides تحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل خطوط مخصصة**

تتيح لك Aspose.Slides تحميل خطوط تظهر في العروض التقديمية دون الحاجة إلى تثبيت تلك الخطوط. يتم تحميل الخطوط من دليل مخصص. 

1. أنشئ مثيلًا من فئة [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) واستدعِ طريقة [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. قم بتحميل العرض التقديمي الذي سيتم تصوُّره.
3. [امسح ذاكرة التخزين المؤقت](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--) في فئة [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

يوضح هذا الكود PHP عملية تحميل الخطوط:

```php
  # المجلدات للبحث عن الخطوط
  $folders = array($externalFontsDir );
  # تحميل خطوط الدليل المخصص
  FontsLoader->loadExternalFonts($folders);
  # القيام ببعض العمل وإجراء تعديل العرض/الشريحة
  $pres = new Presentation("DefaultFonts.pptx");
  try {
    $pres->save("NewFonts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
    # مسح ذاكرة التخزين المؤقت للخطوط
    FontsLoader->clearCache();
  }
```

## **الحصول على مجلدات الخطوط المخصصة**
توفر Aspose.Slides طريقة [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) للسماح لك بالعثور على مجلدات الخطوط. ترجع هذه الطريقة المجلدات المضافة من خلال طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يوضح هذا الكود PHP كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
  # هذه السطر يخرج المجلدات التي يتم البحث فيها عن ملفات الخطوط.
  # هذه هي المجلدات المضافة عبر طريقة LoadExternalFonts ومجلدات الخطوط النظامية.
  $fontFolders = FontsLoader->getFontFolders();

```

## **تحديد الخطوط المخصصة المستخدمة مع العرض التقديمي**
توفر Aspose.Slides خاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) للسماح لك بتحديد الخطوط الخارجية التي سيتم استخدامها مع العرض التقديمي.

يوضح هذا الكود PHP كيفية استخدام خاصية [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    # الخطوط CustomFont1 و CustomFont2 والخطوط من المجلدات assets\fonts & global\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إدارة الخطوط خارجيًا**

توفر Aspose.Slides طريقة [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) للسماح لك بتحميل خطوط خارجية من بيانات ثنائية.

يوضح هذا الكود PHP عملية تحميل الخطوط من مصفوفة بايت:

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
      # الخط الخارجي محمل خلال مدة العرض التقديمي
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```