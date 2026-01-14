---
title: "استخراج النص المتقدم من العروض التقديمية في PHP"
linktitle: "استخراج النص"
type: docs
weight: 90
url: /ar/php-java/extract-text-from-presentation/
keywords:
- استخراج النص
- استخراج النص من الشريحة
- استخراج النص من العرض التقديمي
- استخراج النص من PowerPoint
- استخراج النص من OpenDocument
- استخراج النص من PPT
- استخراج النص من PPTX
- استخراج النص من ODP
- استرداد النص
- استرداد النص من الشريحة
- استرداد النص من العرض التقديمي
- استرداد النص من PowerPoint
- استرداد النص من OpenDocument
- استرداد النص من PPT
- استرداد النص من PPTX
- استرداد النص من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ PHP عبر Java. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---

{{% alert color="primary" %}} 
ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، عليك استخراج النص من جميع الأشكال على جميع الشرائح في العرض التقديمي. تشرح هذه المقالة كيفية استخراج النص من عروض PowerPoint PPTX باستخدام Aspose.Slides. 
{{% /alert %}} 
## **استخراج النص من الشرائح**
توفر Aspose.Slides for PHP عبر Java فئة [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/). تُظهر هذه الفئة عددًا من الأساليب الثابتة المتعددة التحميل لاستخراج النص الكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX، استخدم الأسلوب الثابت المتعدد التحميل [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/getalltextboxes/) الذي توفره فئة [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/). يقبل هذا الأسلوب كائن Slide كمعامل.  
عند التنفيذ، يقوم أسلوب Slide بمسح النص الكامل من الشريحة التي تم تمريرها كمعامل ويعيد مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/). هذا يعني أن أي تنسيق نصي مرتبط بالنص متاح. الجزء التالي من الشيفرة يستخرج جميع النصوص على الشريحة الأولى من العرض التقديمي:
```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # المرور عبر مصفوفة TextFrames
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # المرور عبر الفقرات في ITextFrame الحالي
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # المرور عبر الأجزاء في IParagraph الحالي
          foreach($para->getPortions() as $port) {
            # عرض النص في الجزء الحالي
            echo($port->getText());
            # عرض ارتفاع الخط للنص
            echo($port->getPortionFormat()->getFontHeight());
            # عرض اسم الخط للنص
            if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
              echo($port->getPortionFormat()->getLatinFont()->getFontName());
            }
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **استخراج النص من العروض التقديمية**
لمسح النص من كامل العرض التقديمي، استخدم الأسلوب الثابت [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/getalltextframes/) الذي توفره فئة SlideUtil. يأخذ هذا الأسلوب معاملين:

1. أولًا، كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) يمثل العرض التقديمي الذي يتم استخراج النص منه.
1. ثانيًا، قيمة منطقية تحدد ما إذا كان يجب تضمين الشريحة الرئيسية عند مسح النص من العرض التقديمي.
   يعيد الأسلوب مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)، مع معلومات تنسيق النص. الشيفرة أدناه تمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.
```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # التكرار عبر مصفوفة TextFrames
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # التكرار عبر الفقرات في ITextFrame الحالي
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # التكرار عبر الأجزاء في IParagraph الحالي
        foreach($para->getPortions() as $port) {
          # عرض النص في الجزء الحالي
          echo($port->getText());
          # عرض ارتفاع الخط للنص
          echo($port->getPortionFormat()->getFontHeight());
          # عرض اسم الخط للنص
          if (!java_is_null($port->getPortionFormat()->getLatinFont())) {
            echo($port->getPortionFormat()->getLatinFont()->getFontName());
          }
        }
      }
    }
  } finally {
    $pres->dispose();
  }
```


## **استخراج النص المصنّف والسريع**
تم إضافة الأسلوب الثابت الجديد getPresentationText إلى فئة Presentation. هناك ثلاث تحميلات متعددة لهذا الأسلوب:
```php

``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/php-java/aspose.slides/textextractionarrangingmode/) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/php-java/aspose.slides/textextractionarrangingmode/#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/php-java/aspose.slides/textextractionarrangingmode/#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[PresentationText](https://reference.aspose.com/slides/php-java/aspose.slides/presentationtext/) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/php-java/aspose.slides/presentationtext/getslidestext/) method which returns an array of `SlideText` objects. Every object represent the text on the corresponding slide. `SlideText` object have the following methods:

- `SlideText.getText` - The text on the slide's shapes
- `SlideText.getMasterText` - The text on the master page's shapes for this slide
- `SlideText.getLayoutText` - The text on the layout page's shapes for this slide
- `SlideText.getNotesText` - The text on the notes page's shapes for this slide

The new API can be used like this:

```php
  $text1 = PresentationFactory->getInstance()->getPresentationText("presentation.pptx", TextExtractionArrangingMode->Unarranged);
  echo($text1->getSlidesText()[0]->getText());
  echo($text1->getSlidesText()[0]->getLayoutText());
  echo($text1->getSlidesText()[0]->getMasterText());
  echo($text1->getSlidesText()[0]->getNotesText());

```


## **الأسئلة المتكررة**

**ما مدى سرعة معالجة Aspose.Slides للعروض التقديمية الكبيرة أثناء استخراج النص؟**  
تم تحسين Aspose.Slides للأداء العالي ويعالج بفاعلية حتى [العروض التقديمية الكبيرة](/slides/ar/php-java/open-presentation/)، مما يجعله مناسبًا للسيناريوهات الوقت الحقيقي أو المعالجة بالجملة.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض التقديمية؟**  
نعم، يدعم Aspose.Slides استخراج النص من الجداول والرسوم البيانية والعناصر المعقدة الأخرى في الشرائح، مما يتيح لك الوصول إلى جميع المحتويات النصية وتحليلها بسهولة.

**هل أحتاج إلى ترخيص خاص لـ Aspose.Slides لاستخراج النص من العروض التقديمية؟**  
يمكنك استخراج النص باستخدام النسخة التجريبية المجانية من Aspose.Slides، على الرغم من وجود بعض القيود مثل معالجة عدد محدود من الشرائح فقط. لاستخدام غير محدود وللتعامل مع عروض تقديمية أكبر، يُنصح بشراء ترخيص كامل.