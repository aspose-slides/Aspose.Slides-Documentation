---
title: تضمين الخطوط في العروض التقديمية باستخدام PHP
linktitle: تضمين الخط
type: docs
weight: 40
url: /ar/php-java/embedded-font/
keywords:
- إضافة خط
- تضمين خط
- تضمين الخط
- الحصول على الخط المضمّن
- إضافة خط مضمّن
- إزالة الخط المضمّن
- ضغط الخط المضمّن
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تضمين خطوط TrueType في عروض PowerPoint وOpenDocument مع Aspose.Slides لـ PHP عبر Java، لضمان عرض دقيق على جميع المنصات."
---

**الخطوط المضمَّنة في PowerPoint** مفيدة عندما تريد أن يظهر العرض التقديمي بشكل صحيح عند فتحه على أي نظام أو جهاز. إذا استخدمت خطًا من طرف ثالث أو غير قياسي لأنك أبدعت في عملك، فستكون لديك أسباب إضافية لتضمين الخط. خلاف ذلك (بدون خطوط مضمنة)، قد يتغير النص أو الأرقام على شرائحك، أو التخطيط، أو التنسيق، إلخ، وقد تتحول إلى مستطيلات مربكة.

تحتوي فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) وفئة [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) وفئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) وواجهاتهم على معظم الخصائص والأساليب التي تحتاجها للعمل مع الخطوط المضمَّنة في عروض PowerPoint التقديمية.

## **الحصول على الخطوط المضمَّنة وإزالتها**

توفر Aspose.Slides طريقة [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (المعروضة بواسطة فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)) لتتيح لك الحصول على (أو اكتشاف) الخطوط المضمَّنة في عرض تقديمي. لإزالة الخطوط، تُستخدم طريقة [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (المعروضة بواسطة نفس الفئة).

هذا الكود PHP يوضح لك كيفية الحصول على الخطوط المضمَّنة وإزالتها من عرض تقديمي:
```php
  # ينشئ كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # يُظهر شريحة تحتوي على إطار نصي يستخدم الخط المضمن "FunSized"
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # احفظ الصورة على القرص بتنسيق JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # يحصل على جميع الخطوط المضمنة
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # يبحث عن الخط "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # يزيل الخط "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # يُظهر العرض التقديمي؛ يتم استبدال خط "Calibri" بخط موجود
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # احفظ الصورة على القرص بتنسيق JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # يحفظ العرض التقديمي بدون الخط المضمن "Calibri" على القرص
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إضافة الخطوط المضمَّنة**

باستخدام تعداد [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) واثنين من التحميل المفرط لطريقة [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-)، يمكنك اختيار قاعدة التضمين المفضلة لديك لتضمين الخطوط في عرض تقديمي. هذا الكود PHP يوضح لك كيفية تضمين وإضافة الخطوط إلى عرض تقديمي:
```php
  # يحمّل العرض التقديمي
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
    # يحفظ العرض التقديمي إلى القرص
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ضغط الخطوط المضمَّنة**

لتتيح لك ضغط الخطوط المضمَّنة في عرض تقديمي وتقليل حجمه، توفر Aspose.Slides طريقة [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (المعروضة بواسطة فئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)).

هذا الكود PHP يوضح لك كيفية ضغط الخطوط المضمَّنة في PowerPoint:
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


## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن خطًا معينًا في العرض سيظل يُستبدل أثناء العرض بالرغم من تضمينه؟**  
تحقق من [معلومات الاستبدال](/slides/ar/php-java/font-substitution/) في مدير الخطوط و[قواعد الاحتياطي/الاستبدال](/slides/ar/php-java/fallback-font/): إذا كان الخط غير متوفر أو مقيد، سيتم استخدام احتياطي.

**هل يستحق تضمين الخطوط "النظامية" مثل Arial/Calibri؟**  
عادةً لا—فهذه الخطوط متاحة تقريبًا دائمًا. ولكن لضمان قابلية النقل الكاملة في البيئات "الخفيفة" (Docker، خادم Linux بدون خطوط مثبتة مسبقًا)، يمكن لتضمين الخطوط النظامية أن يقضي على خطر الاستبدالات غير المتوقعة.