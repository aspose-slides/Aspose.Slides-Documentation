---
title: استخراج النص المتقدم من العروض التقديمية في PHP
linktitle: استخراج النص
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
- استرجاع النص
- استرجاع النص من الشريحة
- استرجاع النص من العرض التقديمي
- استرجاع النص من PowerPoint
- استرجاع النص من OpenDocument
- استرجاع النص من PPT
- استرجاع النص من PPTX
- استرجاع النص من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ PHP عبر Java. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---

{{% alert color="primary" %}} 

ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، يجب استخراج النص من جميع الأشكال الموجودة في جميع الشرائح داخل العرض التقديمي. توضح هذه المقالة كيفية استخراج النص من عروض PowerPoint PPTX باستخدام Aspose.Slides. 

{{% /alert %}} 
## **استخراج النص من الشرائح**
توفر Aspose.Slides for PHP via Java الفئة [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). تكشف هذه الفئة عن عدد من الأساليب الساكنة المتعددة التحميل لاستخراج النص الكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX، استخدم الأسلوب الساكن المتعدد التحميل [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) المعرّف في الفئة [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). يقبل هذا الأسلوب كائن Slide كمعامل.
عند التنفيذ، يقوم أسلوب Slide بمسح النص بالكامل من الشريحة الممرَّرة كمعامل ويعيد مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame). هذا يعني أن أي تنسيق نصي مرتبط بالنص متاح. الجزء التالي من الشيفرة يستخرج كل النص في الشريحة الأولى من العرض التقديمي:
```php
  # إنشاء كائن Presentation الذي يمثل ملف PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
      # التجول عبر مصفوفة TextFrames
      for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
        # التجول عبر الفقرات في ITextFrame الحالي
        foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
          # التجول عبر الأقسام في IParagraph الحالي
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
لمسح النص من العرض التقديمي بالكامل، استخدم الأسلوب الساكن [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) المعرّف في فئة SlideUtil. يأخذ هذا الأسلوب معاملين:

1. أولاً، كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) يمثل العرض التقديمي الذي يُستخرج منه النص.
2. ثانيًا، قيمة منطقية تحدد ما إذا كان يجب تضمين الشريحة الرئيسة عند مسح النص من العرض التقديمي.
   يعيد الأسلوب مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) مع معلومات تنسيق النص. الشيفرة أدناه تمسح النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسة.
```php
  # إنشاء كائن Presentation الذي يمثل ملف PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
    $textFramesPPTX = SlideUtil->getAllTextFrames($pres, true);
    # التجول عبر مصفوفة TextFrames
    for($i = 0; $i < java_values($Array->getLength($textFramesPPTX)) ; $i++) {
      # التجول عبر الفقرات في ITextFrame الحالي
      foreach($textFramesPPTX[$i]->getParagraphs() as $para) {
        # التجول عبر الأجزاء في IParagraph الحالي
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


## **استخراج النص المصنف والسريع**
تم إضافة الأسلوب الساكن الجديد getPresentationText إلى فئة Presentation. هناك ثلاث عمليات تحميل لهذا الأسلوب:
```php

```


## **الأسئلة المتكررة**

**ما مدى سرعة معالجة Aspose.Slides للعروض التقديمية الكبيرة أثناء استخراج النص؟**

تم تحسين Aspose.Slides لأداء عالي وتقوم بمعالجة العروض التقديمية [الكبيرة](/slides/ar/php-java/open-presentation/) بكفاءة، مما يجعلها مناسبة لسيناريوهات المعالجة الفورية أو الضخمة.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض التقديمية؟**

نعم، يدعم Aspose.Slides بالكامل استخراج النص من الجداول والرسوم البيانية والعناصر المعقدة الأخرى في الشرائح، مما يتيح لك الوصول إلى جميع المحتويات النصية وتحليلها بسهولة.

**هل أحتاج إلى ترخيص خاص لـ Aspose.Slides لاستخراج النص من العروض التقديمية؟**

يمكنك استخراج النص باستخدام نسخة التجربة المجانية من Aspose.Slides، رغم أن لديها بعض القيود، مثل معالجة عدد محدود من الشرائح فقط. للحصول على استخدام غير مقيد وللتعامل مع عروض تقديمية أكبر، يُنصح بشراء ترخيص كامل.