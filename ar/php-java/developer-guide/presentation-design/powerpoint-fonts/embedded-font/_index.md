---
title: الخطوط المدمجة - واجهة برمجة التطبيقات PowerPoint Java
linktitle: الخطوط المدمجة
type: docs
weight: 40
url: /ar/php-java/embedded-font/
keywords: "الخطوط، الخطوط المدمجة، إضافة خطوط، عرض PowerPoint، جافا، Aspose.Slides لـ PHP عبر جافا"
description: "استخدام الخطوط المدمجة في عرض PowerPoint"

---

**الخطوط المدمجة في PowerPoint** مفيدة عندما تريد أن يظهر عرضك التقديمي بشكل صحيح عند فتحه على أي نظام أو جهاز. إذا استخدمت خطًا من طرف ثالث أو خطًا غير قياسي لأنك كنت مبدعًا في عملك، فلديك أسبابه إضافية لدمج خطك. بخلاف ذلك (بدون خطوط مدمجة)، قد تتغير النصوص أو الأرقام على شرائحك، والتخطيط، والتنسيق، وما إلى ذلك، أو تتحول إلى مستطيلات مربكة.

فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager) وفئة [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) وفئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) وواجهاتهم تحتوي على معظم الخصائص والطرق التي تحتاجها للعمل مع الخطوط المدمجة في العروض التقديمية PowerPoint.

## **الحصول على أو إزالة الخطوط المدمجة من العرض التقديمي**

توفر Aspose.Slides الطريقة [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (المكشوفة من قبل فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)) للسماح لك بالحصول على (أو معرفة) الخطوط المدمجة في عرض تقديمي. لإزالة الخطوط، تُستخدم الطريقة [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (المكشوفة من نفس الفئة).

تظهر لك هذه الشفرة PHP كيفية الحصول على وإزالة الخطوط المدمجة من عرض تقديمي:

```php
  # إنشاء كائن Presentation يمثل ملف عرض تقديمي
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # رسم شريحة تحتوي على إطار نص يستخدم "FunSized" المدمجة
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # حفظ الصورة على القرص بتنسيق JPEG
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # الحصول على جميع الخطوط المدمجة
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # العثور على خط "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # إزالة خط "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # رسم العرض التقديمي؛ خط "Calibri" تم استبداله بآخر موجود
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # حفظ الصورة على القرص بتنسيق JPEG
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # حفظ العرض التقديمي بدون خط "Calibri" المدمج على القرص
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة خطوط مدمجة إلى العرض التقديمي**

باستخدام القيم [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) وطريقتي التحميل المختلفة [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-)، يمكنك اختيار القاعدة المفضلة لديك (للدمج) لدمج الخطوط في عرض تقديمي. تظهر لك هذه الشفرة PHP كيفية دمج وإضافة الخطوط إلى عرض تقديمي:

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

للسماح لك بضغط الخطوط المدمجة في عرض تقديمي وتقليل حجم ملفه، توفر Aspose.Slides الطريقة [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (المكشوفة من قبل فئة [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)).

تظهر لك هذه الشفرة PHP كيفية ضغط الخطوط المدمجة في PowerPoint:

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