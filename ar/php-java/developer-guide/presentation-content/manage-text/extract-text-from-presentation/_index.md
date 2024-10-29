---
title: استخراج النص من العرض التقديمي
type: docs
weight: 90
url: /ar/php-java/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

ليس من غير المألوف أن يحتاج المطورون إلى استخراج النص من عرض تقديمي. للقيام بذلك، تحتاج إلى استخراج النص من جميع الأشكال على جميع الشرائح في العرض التقديمي. يشرح هذا المقال كيفية استخراج النص من عروض Microsoft PowerPoint PPTX باستخدام Aspose.Slides. 

{{% /alert %}} 
## **استخراج النص من الشريحة**
تقدم Aspose.Slides لـ PHP عبر Java الفئة [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). تعرض هذه الفئة عددًا من الطرق الثابتة المحملة لاستخراج النص الكامل من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض PPTX، استخدم الطريقة الثابتة المحملة [getAllTextBoxes](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) التي تعرضها فئة [SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil). تقبل هذه الطريقة كائن الشريحة كمعامل. عند التنفيذ، تقوم طريقة Slide بفحص النص الكامل من الشريحة الممررة كمعامل وتعيد مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame). وهذا يعني أن أي تنسيق نص مرتبط بالنص متوفر. يخرج قطعة الكود التالية جميع النصوص على الشريحة الأولى من العرض التقديمي:

```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation("demo.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    foreach($pres->getSlides() as $slide) {
      # الحصول على مصفوفة من كائنات ITextFrame من جميع الشرائح في PPTX
      $textFramesPPTX = SlideUtil->getAllTextBoxes($slide);
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
    }
  } finally {
    $pres->dispose();
  }
```

## **استخراج النص من العرض التقديمي**
لفحص النص من العرض التقديمي بالكامل، استخدم الطريقة الثابتة [getAllTextFrames](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) التي تعرضها فئة SlideUtil. تأخذ هذه الطريقة معاملين:

1. أولاً، كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) يمثل العرض التقديمي الذي يتم استخراج النص منه.
2. ثانياً، قيمة بوليانية تحدد ما إذا كان يجب تضمين الشريحة الرئيسية عند فحص النص من العرض التقديمي.
   تعيد الطريقة مصفوفة من كائنات [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) مكتملة بمعلومات تنسيق النص. الكود أدناه يفحص النص ومعلومات التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.

```php
  # إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
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

## **استخراج النص بشكل مصنف وسريع**
تم إضافة الطريقة الثابتة الجديدة getPresentationText إلى فئة Presentation. هناك ثلاث طرق محملة لهذه الطريقة:

```php

``` 

يعكس حجة [TextExtractionArrangingMode](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode) وضع تنظيم نتيجة النص ويمكن ضبطها على القيم التالية:
- [Unarranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - النص الخام دون مراعاة الموقف على الشريحة
- [Arranged](https://reference.aspose.com/slides/php-java/aspose.slides/TextExtractionArrangingMode#Arranged) - النص موضعه بنفس ترتيب وجوده على الشريحة

يمكن استخدام وضع **Unarranged** عندما تكون السرعة حاسمة، فهو أسرع من وضع Arranged.

يمثل [IPresentationText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) النص الخام المستخرج من العرض التقديمي. يحتوي على طريقة [getSlidesText](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText#getSlidesText--) والتي تعيد مصفوفة من كائنات [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText). يمثل كل كائن النص على الشريحة المقابلة. تحتوي كائنات [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText) على الطرق التالية:

- [ISlideText.getText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getText--) - النص على أشكال الشريحة
- [ISlideText.getMasterText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getMasterText--) - النص على أشكال الصفحة الرئيسية لهذه الشريحة
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getLayoutText--) - النص على أشكال صفحة التنسيق لهذه الشريحة
- [ISlideText.getNotesText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText#getNotesText--) - النص على أشكال صفحة الملاحظات لهذه الشريحة

هناك أيضًا فئة [SlideText](https://reference.aspose.com/slides/php-java/aspose.slides/SlideText) التي تنفذ واجهة [ISlideText](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideText).

يمكن استخدام واجهة برمجة التطبيقات الجديدة بهذا الشكل:

```php
  $text1 = PresentationFactory->getInstance()->getPresentationText("presentation.pptx", TextExtractionArrangingMode->Unarranged);
  echo($text1->getSlidesText()[0]->getText());
  echo($text1->getSlidesText()[0]->getLayoutText());
  echo($text1->getSlidesText()[0]->getMasterText());
  echo($text1->getSlidesText()[0]->getNotesText());

```