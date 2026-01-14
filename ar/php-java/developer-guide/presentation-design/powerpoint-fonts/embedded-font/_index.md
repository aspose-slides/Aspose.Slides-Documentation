---
title: دمج الخطوط في العروض التقديمية باستخدام PHP
linktitle: دمج الخط
type: docs
weight: 40
url: /ar/php-java/embedded-font/
keywords:
- إضافة خط
- دمج خط
- دمج الخط
- الحصول على الخط المدمج
- إضافة خط مدمج
- إزالة الخط المدمج
- ضغط الخط المدمج
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "دمج خطوط TrueType في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java، مع ضمان عرض دقيق على جميع المنصات."
---

**الخطوط المدمجة في PowerPoint** مفيدة عندما تريد أن تظهر عرضك التقديمي بشكل صحيح عند فتحه على أي نظام أو جهاز. إذا كنت قد استخدمت خطًا من طرف ثالث أو غير قياسي لأنك أبدعت في عملك، فستكون لديك أسباب إضافية لدمج الخط. وإلا (دون الخطوط المدمجة)، قد تتغير النصوص أو الأرقام في الشرائح، وتُغيّر التخطيطات والتنسيقات، أو تتحول إلى مستطيلات مربكة. 

فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)، فئة [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) وفئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) تحتوي على معظم الطرق التي تحتاجها للعمل مع الخطوط المدمجة في عروض PowerPoint.

## **الحصول على الخطوط المدمجة وإزالتها**

توفر Aspose.Slides الطريقة [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) (المعروضة بواسطة فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)) لتمكينك من الحصول (أو معرفة) الخطوط المدمجة في عرض تقديمي. لإزالة الخطوط، تُستخدم الطريقة [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) (المعروضة بواسطة نفس الفئة).

يعرض هذا الشيفرة PHP كيفية الحصول على الخطوط المدمجة وإزالتها من عرض تقديمي:
```php
  # يقوم بإنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # يعرض شريحة تحتوي على إطار نصي يستخدم الخط المدمج "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # يحفظ الصورة على القرص بصيغة JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # يحصل على جميع الخطوط المدمجة
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # يبحث عن خط "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # يزيل خط "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # يعرض العرض التقديمي؛ يتم استبدال خط "Calibri" بخط متوفر
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # يحفظ الصورة على القرص بصيغة JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # يحفظ العرض التقديمي دون خط "Calibri" المدمج على القرص
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```



## **إضافة خطوط مدمجة**

باستخدام الفئة [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) واثنين من التحميلات الزائدة للطريقة [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont)، يمكنك اختيار القاعدة (الدمج) المفضلة لدمج الخطوط في عرض تقديمي. يعرض هذا الشيفرة PHP كيفية دمج وإضافة خطوط إلى عرض تقديمي:
```php
  # تحميل العرض التقديمي
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # حفظ العرض التقديمي على القرص
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ضغط الخطوط المدمجة**

لتمكينك من ضغط الخطوط المدمجة في عرض تقديمي وتقليل حجمه، توفر Aspose.Slides الطريقة [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts) (المعروضة بواسطة فئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)).

يعرض هذا الشيفرة PHP كيفية ضغط خطوط PowerPoint المدمجة:
```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتداولة**

**كيف يمكنني معرفة أن خطًا معينًا في العرض سيستمر في الاستبدال أثناء العرض بالرغم من دمجه؟**

تحقق من [معلومات الاستبدال](/slides/ar/php-java/font-substitution/) في مدير الخطوط و[قواعد الاحتياطي/الاستبدال](/slides/ar/php-java/fallback-font/): إذا كان الخط غير متاح أو مقيد، سيتم استخدام احتياطي.

**هل من المجدي دمج خطوط "النظام" مثل Arial/Calibri؟**

عادة لا—فهي متوفرة تقريبًا دائمًا. لكن لضمان قابلية النقل الكاملة في بيئات "نحيفة" (Docker، خادم Linux بدون خطوط مثبتة مسبقًا)، قد يزيل دمج خطوط النظام خطر الاستبدالات غير المتوقعة.