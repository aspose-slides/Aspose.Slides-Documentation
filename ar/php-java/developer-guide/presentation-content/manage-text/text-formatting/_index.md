---
title: تنسيق نص PowerPoint في PHP
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/php-java/text-formatting/
keywords:
- تمييز النص
- تعبير نمطي
- محاذاة الفقرة
- نمط النص
- خلفية النص
- شفافية النص
- تباعد الأحرف
- خصائص الخط
- عائلة الخط
- تدوير النص
- زاوية الدوران
- إطار النص
- تباعد السطور
- خاصية Autofit
- تثبيت إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تنسيق وتنسيق النص في العروض التقديمية PowerPoint و OpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. تخصيص الخطوط والألوان والمحاذاة والمزيد."
---

## **تمييز النص**
تم إضافة الطريقة [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) وفئة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

يسمح بتمييز جزء من النص بلون الخلفية باستخدام عينة نصية، مشابه لأداة تمييز النص بلون الخلفية في PowerPoint 2019.

المقتطف البرمجي أدناه يوضح كيفية استخدام هذه الميزة:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// تظليل جميع الكلمات 'important'

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// تظليل جميع تكرارات 'the' المنفصلة

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
توفر Aspose خدمة بسيطة، [خدمة تحرير PowerPoint مجانية على الإنترنت](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **تمييز النص باستخدام تعبير نمطي**
تم إضافة الطريقة [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) وفئة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

يسمح بتمييز جزء من النص بلون الخلفية باستخدام تعبير نمطي، مشابه لأداة تمييز النص بلون الخلفية في PowerPoint 2019.

المقتطف البرمجي أدناه يوضح كيفية استخدام هذه الميزة:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// تظليل جميع الكلمات التي طولها 10 رموز أو أكثر

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين لون خلفية النص**
تتيح Aspose.Slides لك تحديد اللون المفضل لخلفية النص.

يعرض هذا الكود PHP كيف تُعيّن لون الخلفية لنص كامل:
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->spliterator(), false)->map(( p) -> $p->getPortions())->forEach(( c) -> $c->forEach(( ic) -> $ic->getPortionFormat()->getHighlightColor()->setColor($Color.BLUE)));
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


يعرض هذا الكود PHP كيف تُعيّن لون الخلفية لجزء فقط من النص:
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("Black");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" Red ");
    $portion3 = new Portion("Black");
    $portion3->getPortionFormat()->setFontBold(NullableBool::True);
    $para->getPortions()->add($portion1);
    $para->getPortions()->add($portion2);
    $para->getPortions()->add($portion3);
    $autoShape->getTextFrame()->getParagraphs()->add($para);
    $pres->save("text.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
  $presentation = new Presentation("text.pptx");
  try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $redPortion = StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->spliterator(), false)->filter(( p) -> $p->getText()->contains("Red"))->findFirst();
    if ($redPortion->isPresent()) {
      $redPortion->get()->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->RED);
    }
    $presentation->save("text-red.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **محاذاة فقرات النص**
تنسيق النص يُعد أحد العناصر الأساسية عند إنشاء أي مستند أو عرض تقديمي. نعلم أن Aspose.Slides لـ PHP عبر Java يدعم إضافة النص إلى الشرائح، وفي هذا الموضوع سنوضح كيفية التحكم في محاذاة فقرات النص داخل شريحة. يرجى اتباع الخطوات أدناه لمحاذاة فقرات النص باستخدام Aspose.Slides لـ PHP عبر Java:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة باستخدام فهرستها.
3. الوصول إلى الأشكال النائبة الموجودة في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
4. الحصول على الفقرة (التي تحتاج إلى محاذاة) من [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#getTextFrame--) المعروضة بواسطة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. محاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين أو اليسار أو الوسط أو ضبطها.
6. كتابة العرض التقديمي المعدل كملف PPTX.

التنفيذ للخطوات السابقة موضح أدناه.
```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويلهما إلى AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # تغيير النص في كلا العنصريّن النائبين
    $tf1->setText("Center Align by Aspose");
    $tf2->setText("Center Align by Aspose");
    # الحصول على الفقرة الأولى من العناصر النائبية
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # محاذاة فقرة النص إلى الوسط
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Center);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Center);
    # كتابة العرض التقديمي كملف PPTX
    $pres->save("Centeralign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين الشفافية للنص**
يوضح هذا المقال كيفية تعيين خاصية الشفافية لأي شكل نص باستخدام Aspose.Slides لـ PHP عبر Java. لتعيين الشفافية للنص، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة.
3. تعيين لون الظل.
4. كتابة العرض التقديمي كملف PPTX.

التنفيذ للخطوات السابقة موضح أدناه.
```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - transparency is: " . $shadowColor->getAlpha() / 255.0 * 100);
    # ضبط الشفافية إلى صفر بالمائة
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين التباعد بين الأحرف للنص**
تتيح Aspose.Slides لك ضبط المسافة بين الأحرف داخل صندوق النص. بهذه الطريقة يمكنك تعديل الكثافة البصرية لسطر أو كتلة نصية عن طريق توسيع أو تقليص التباعد بين الأحرف.

يعرض هذا الكود PHP كيفية توسيع التباعد لسطر نص واحد وتقليصه لسطر آخر:
```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// توسيع

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// تكثيف

  $presentation->save("out.pptx", SaveFormat::Pptx);
```


## **إدارة خصائص الخط للفقرة**
عادةً ما تحتوي العروض التقديمية على كل من النصوص والصور. يمكن تنسيق النص بطرق مختلفة إما لتسليط الضوء على أقسام وكلمات معينة، أو للامتثال لأساليب الشركة. يساعد تنسيق النص المستخدمين على تنويع مظهر المحتوى. يوضح هذا المقال كيفية استخدام Aspose.Slides لـ PHP عبر Java لتكوين خصائص الخط للفقرات النصية على الشرائح. لإدارة خصائص الخط لفقرة باستخدام Aspose.Slides لـ PHP عبر Java:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع شريحة باستخدام فهرستها.
1. الوصول إلى الأشكال النائبة في الشريحة وتحويلها إلى [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. الحصول على [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) من [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) المعروضة بواسطة [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. ضبط الفقرة لتكون مبررة.
1. الوصول إلى جزء النص داخل الفقرة.
1. تعريف الخط باستخدام FontData وتعيين خط الجزء وفقًا لذلك.
   1. جعل الخط عريض.
   1. جعل الخط مائل.
1. تعيين لون الخط باستخدام [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#getFillFormat--) المعرض من كائن [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
1. كتابة العرض التقديمي المعدل إلى ملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

التنفيذ للخطوات السابقة موضح أدناه. يأخذ عرضًا تقديميًا غير مزين ويقوم بتنسيق الخطوط على إحدى الشرائح.
```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # الوصول إلى شريحة باستخدام موضعها
    $slide = $pres->getSlides()->get_Item(0);
    # الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويلهما إلى AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # الوصول إلى الفقرة الأولى
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # الوصول إلى الجزء الأول
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # تعريف خطوط جديدة
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # تعيين الخطوط الجديدة للجزء
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # تعيين الخط إلى عريض
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # تعيين الخط إلى مائل
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين لون الخط
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # كتابة ملف PPTX إلى القرص
    $pres->save("WelcomeFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إدارة عائلة الخط للنص**
يُستخدم الجزء (Portion) لحفظ نص بتنسيق موحد داخل الفقرة. يوضح هذا المقال كيفية استخدام Aspose.Slides لـ PHP عبر Java لإنشاء صندوق نص يحتوي على بعض النص ثم تعريف خط معين، بالإضافة إلى خصائص أخرى لعائلة الخط. لإنشاء صندوق نص وتعيين خصائص الخط للنص داخله:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع شريحة باستخدام فهرستها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) من النوع [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) إلى الشريحة.
4. إزالة نمط التعبئة المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. الوصول إلى TextFrame الخاص بـ AutoShape.
6. إضافة بعض النص إلى TextFrame.
7. الوصول إلى كائن Portion المرتبط بـ [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
8. تعريف الخط لاستخدامه في [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
9. تعيين خصائص الخط الأخرى مثل العريض، المائل، التسطير، اللون والارتفاع باستخدام الخصائص ذات الصلة المعروضة من كائن Portion.
10. كتابة العرض التقديمي المعدل كملف PPTX.

التنفيذ للخطوات السابقة موضح أدناه.
```php
  # إنشاء كائن Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من النوع Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # إزالة أي نمط تعبئة مرتبط بـ AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # الوصول إلى TextFrame المرتبط بـ AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # الوصول إلى Portion المرتبط بـ TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # تعيين الخط للجزء
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # تعيين خاصية الخط العريض
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # تعيين خاصية الخط المائل
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين خاصية تسطير الخط
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # تعيين ارتفاع الخط
    $port->getPortionFormat()->setFontHeight(25);
    # تعيين لون الخط
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # كتابة ملف PPTX إلى القرص
    $pres->save("SetTextFontProperties_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين حجم الخط للنص**
تتيح Aspose.Slides لك اختيار حجم الخط المفضل للنص الموجود في الفقرة وأي نص قد يضاف لاحقًا إلى الفقرة.

يعرض هذا الكود PHP كيفية تعيين حجم الخط للنصوص داخل فقرة:
```php
  $presentation = new Presentation("example.pptx");
  try {
    # يحصل على الشكل الأول، على سبيل المثال.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # يحصل على الفقرة الأولى، على سبيل المثال.
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # يضبط حجم الخط الافتراضي إلى 20 نقطة لجميع أجزاء النص في الفقرة.
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # يضبط حجم الخط إلى 20 نقطة لأجزاء النص الحالية في الفقرة.
      foreach($paragraph->getPortions() as $portion) {
        $portion->getPortionFormat()->setFontHeight(20);
      }
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **تعيين دوران النص**
يسمح Aspose.Slides لـ PHP عبر Java للمطورين بتدوير النص. يمكن ضبط النص ليظهر كـ [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Horizontal)، [Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical)، [Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical270)، [WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVertical)، [EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#EastAsianVertical)، [MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#MongolianVertical) أو [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). لتدوير نص أي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Rotate the text](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. حفظ الملف إلى القرص.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من النوع Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # إضافة TextFrame إلى الشكل المستطيل
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # الوصول إلى إطار النص
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # إنشاء كائن Paragraph لإطار النص
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # إنشاء كائن Portion للفقرة
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # حفظ العرض التقديمي
    $pres->save("RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين زاوية دوران مخصصة لـ TextFrame**
يدعم Aspose.Slides لـ PHP عبر Java الآن تعيين زاوية دوران مخصصة لإطار النص. في هذا الموضوع، سنوضح بالمثال كيفية تعيين خاصية RotationAngle في Aspose.Slides. تمت إضافة الطرق الجديدة [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) و [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#getRotationAngle--) إلى واجهات [IChartTextBlockFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IChartTextBlockFormat) و [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat)، مما يسمح بتعيين زاوية دوران مخصصة لإطار النص. لتعيين RotationAngle، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. إضافة مخطط إلى الشريحة.
3. [Set RotationAngle property](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-).
4. كتابة العرض التقديمي كملف PPTX.

في المثال أدناه، نقوم بتعيين خاصية RotationAngle.
```php
  # إنشاء نسخة من فئة Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من النوع Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # إضافة TextFrame إلى المستطيل
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # الوصول إلى إطار النص
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setRotationAngle(25);
    # إنشاء كائن Paragraph لإطار النص
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # إنشاء كائن Portion للفقرة
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Text rotation example.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # حفظ العرض التقديمي
    $pres->save($resourcesOutputPath . "RotateText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تباعد السطور للفقرة**
توفر Aspose.Slides خصائص تحت [`ParagraphFormat`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat)—`SpaceAfter`، `SpaceBefore` و `SpaceWithin`—تسمح لك بإدارة تباعد السطر للفقرة. تُستخدم الخصائص الثلاث بهذه الطريقة:

* لتحديد تباعد السطر للفقرة بالنسبة المئوية، استخدم قيمة موجبة.
* لتحديد تباعد السطر للفقرة بالنقاط، استخدم قيمة سالبة.

على سبيل المثال، يمكنك تطبيق تباعد سطر 16pt للفقرة بتعيين خاصية `SpaceBefore` إلى -16.

هذا هو طريقة تحديد تباعد السطر لفقرة معينة:

1. تحميل عرض تقديمي يحتوي على AutoShape به بعض النص.
2. الحصول على مرجع شريحة عبر فهرستها.
3. الوصول إلى TextFrame.
4. الوصول إلى Paragraph.
5. تعيين خصائص الفقرة.
6. حفظ العرض التقديمي.

يعرض هذا الكود PHP كيفية تحديد تباعد السطر لفقرة:
```php
  # إنشاء نسخة من فئة Presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # الحصول على مرجع الشريحة بواسطة فهرستها
    $sld = $pres->getSlides()->get_Item(0);
    # الوصول إلى TextFrame
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # الوصول إلى الفقرة
    $para = $tf1->getParagraphs()->get_Item(0);
    # تعيين خصائص الفقرة
    $para->getParagraphFormat()->setSpaceWithin(80);
    $para->getParagraphFormat()->setSpaceBefore(40);
    $para->getParagraphFormat()->setSpaceAfter(40);
    # حفظ العرض التقديمي
    $pres->save("LineSpacing_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين خاصية AutofitType لإطار النص**
في هذا الموضوع، سنستكشف خصائص تنسيق مختلفة لإطار النص. يغطي هذا المقال كيفية تعيين خاصية AutofitType لإطار النص، وتثبيت النص وتدويره في العرض التقديمي. يسمح Aspose.Slides لـ PHP عبر Java للمطورين بتعيين خاصية AutofitType لأي إطار نص. يمكن تعيين AutofitType إلى [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) أو [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape). إذا تم تعيينه إلى [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) فإن الشكل سيبقى كما هو بينما يتم تعديل النص دون تعديل الشكل. أما إذا تم تعيينه إلى [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape) فسيتم تعديل الشكل بحيث يحتوي فقط على النص المطلوب. لتعيين خاصية AutofitType لإطار النص، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)class.
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Set the AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAutofitType-byte-) لإطار النص.
6. حفظ الملف إلى القرص.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من النوع Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 150);
    # إضافة TextFrame إلى المستطيل
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # الوصول إلى إطار النص
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # إنشاء كائن Paragraph لإطار النص
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # إنشاء كائن Portion للفقرة
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # حفظ العرض التقديمي
    $pres->save($resourcesOutputPath . "formatText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين تثبيت النص لإطار النص**
يسمح Aspose.Slides لـ PHP عبر Java للمطورين بتثبيت أي TextFrame. يحدد TextAnchorType موضع النص داخل الشكل. يمكن تعيين AnchorType إلى [Top](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Top)، [Center](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Center)، [Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Bottom)، [Justified](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Justified) أو [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Distributed). لتعيين تثبيت أي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [Set TextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAnchoringType-byte-) لإطار النص.
6. حفظ الملف إلى القرص.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من النوع Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 350, 350);
    # إضافة TextFrame إلى المستطيل
    $ashp->addTextFrame("");
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # الوصول إلى إطار النص
    $txtFrame = $ashp->getTextFrame();
    $txtFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);
    # إنشاء كائن Paragraph لإطار النص
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # إنشاء كائن Portion للفقرة
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog.");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # حفظ العرض التقديمي
    $pres->save("AnchorText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **العلامات (Tabs) و EffectiveTabs في عرض تقديمي**
جميع المسافات بين العلامات تُعطى بالبيكسل.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**الشكل: 2 علامة صريحة و2 علامات افتراضية**|
- خاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- مجموعة EffectiveTabs تشمل جميع العلامات (من مجموعة Tabs والعلامات الافتراضية).
- خاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- خاصية EffectiveTabs.DefaultTabSize (294) تُظهر المسافة بين العلامات الافتراضية (3 و4 في مثالنا).
- EffectiveTabs.GetTabByIndex(index) مع index = 0 سيعيد العلامة الصريحة الأولى (Position = 731)، index = 1 – العلامة الثانية (Position = 1241). إذا حاولت الحصول على العلامة التالية مع index = 2 سيعيد أول علامة افتراضية (Position = 1470) وهكذا.
- EffectiveTabs.GetTabAfterPosition(pos) يُستخدم للحصول على العلامة التالية بعد بعض النص. على سبيل المثال لديك النص: "Hello World!". لتخطيط هذا النص تحتاج إلى معرفة مكان بدء رسم "world!". أولاً، احسب طول "Hello" بالبيكسل واستدعِ GetTabAfterPosition بهذه القيمة. ستحصل على موقع العلامة التالية لرسم "world!".

## **استخراج النص مع تأثير الأحرف الكبيرة (All-Caps)**
في PowerPoint، تطبيق تأثير الخط **All Caps** يجعل النص يظهر بأحرف كبيرة على الشريحة حتى لو كتب أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء من النص باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمعالجة ذلك، تحقق من [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/)—إذا أشار إلى `All`، حوّل السلسلة المسترجعة إلى أحرف كبيرة حتى يتطابق المخرَج مع ما يراه المستخدمون على الشريحة.

لنفترض أن لدينا صندوق النص التالي على الشريحة الأولى من الملف sample2.pptx.

![The All Caps effect](all_caps_effect.png)

يوضح المثال البرمجي أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:
```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $textPortion = $paragraph->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = $textPortion->getText()->toUpperCase();
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```


الناتج:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **الأسئلة الشائعة**

**كيف يتم تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، تحتاج إلى استخدام فئة [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). يمكنك遍历所有单元格并通过访问每个单元格的 `TextFrame` 和 `ParagraphFormat` 属性来更改其中的文本。

**كيف يتم تطبيق تدرج لوني على نص في شريحة PowerPoint؟**

لتطبيق تدرج لوني على النص، استخدم طريقة `getFillFormat` في [BasePortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/). عيّن `FilFormat` إلى `Gradient`، حيث يمكنك تعريف ألوان البداية والنهاية للتدرج، بالإضافة إلى خصائص أخرى مثل الاتجاه والشفافية لإنشاء تأثير التدرج على النص.