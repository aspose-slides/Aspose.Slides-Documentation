---
title: تنسيق نص PowerPoint في PHP
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/php-java/text-formatting/
keywords:
- تمييز النص
- تعبير منتظم
- محاذاة الفقرة
- نمط النص
- خلفية النص
- شفافية النص
- تباعد الأحرف
- خصائص الخط
- عائلة الخط
- دوران النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الملاءمة التلقائية
- مرساة إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تنسيق وتزيين النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. تخصيص الخطوط والألوان والمحاذاة والمزيد."
---

## **تسليط الضوء على النص**
تمت إضافة طريقة [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/highlighttext/) إلى فئة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) .

تتيح لك تسليط الضوء على جزء من النص بلون الخلفية باستخدام عينة نصية، مشابهة لأداة تلوين النص في PowerPoint 2019.

يُظهر مقتطف الشيفرة أدناه كيفية استخدام هذه الميزة:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// تسليط الضوء على جميع الكلمات 'important'

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// تسليط الضوء على جميع تكرارات 'the' المنفصلة

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
توفر Aspose خدمة تحرير PowerPoint مجانية عبر الإنترنت بسيطة، [free online PowerPoint editing service](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **تسليط الضوء على النص باستخدام تعبير عادي**
تمت إضافة طريقة [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/highlightregex/) إلى فئة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) .

تتيح لك تسليط الضوء على جزء من النص بلون الخلفية باستخدام تعبير عادي، مشابهة لأداة تلوين النص في PowerPoint 2019.

يُظهر مقتطف الشيفرة أدناه كيفية استخدام هذه الميزة:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// تسليط الضوء على جميع الكلمات التي تحتوي على 10 رموز أو أكثر

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين لون خلفية النص**
تسمح لك Aspose.Slides بتحديد اللون المفضل لخلفية النص.

تُظهر لك شيفرة PHP هذه كيفية تعيين لون الخلفية لكامل النص:
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


تُظهر لك شيفرة PHP هذه كيفية تعيين لون الخلفية لجزء فقط من النص:
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
تنسيق النص هو أحد العناصر الأساسية عند إنشاء المستندات أو العروض التقديمية. نعلم أن Aspose.Slides for PHP via Java يدعم إضافة النص إلى الشرائح، وفي هذا الموضوع سنرى كيفية التحكم في محاذاة فقرات النص داخل الشريحة. يرجى اتباع الخطوات التالية لمحاذاة فقرات النص باستخدام Aspose.Slides for PHP via Java:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
3. الوصول إلى الأشكال النائبة (Placeholder) الموجودة في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) .
4. الحصول على الفقرة (التي تحتاج إلى محاذاة) من الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) التي يعرضها الـ [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) .
5. محاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين أو اليسار أو الوسط أو ضبطها بالتساوي.
6. كتابة العرض المعدل كملف PPTX.

التنفيذ العملي للخطوات أعلاه موضح أدناه.
```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويلهما إلى AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # تعديل النص في كلا العنصرين النائبين
    $tf1->setText("Center Align by Aspose");
    $tf2->setText("Center Align by Aspose");
    # الحصول على الفقرة الأولى من العناصر النائبة
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
يوضح هذا المقال كيفية تعيين خاصية الشفافية لأي شكل نصي باستخدام Aspose.Slides for PHP via Java. لتعيين الشفافية للنص، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة.
3. تعيين لون الظل.
4. كتابة العرض كملف PPTX.

التنفيذ العملي للخطوات أعلاه موضح أدناه.
```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - transparency is: " . $shadowColor->getAlpha() / 255.0 * 100);
    # تعيين الشفافية إلى صفر بالمئة
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين التباعد بين الحروف للنص**
تسمح لك Aspose.Slides بتعيين المسافة بين الأحرف داخل مربع النص. بهذه الطريقة يمكنك تعديل الكثافة البصرية لسطر أو كتلة نصية بزيادة أو تقليل التباعد بين الحروف.

تُظهر لك شيفرة PHP هذه كيفية توسيع التباعد لسطر نص واحد وتقليصه لسطر آخر:
```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// توسيع

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// تصغير

  $presentation->save("out.pptx", SaveFormat::Pptx);
```


## **إدارة خصائص الخط لفقرة**
عادةً ما تحتوي العروض التقديمية على كل من النصوص والصور. يمكن تنسيق النص بطرق متعددة، إما لتسليط الضوء على أقسام أو كلمات معينة، أو للامتثال لأنماط الشركة. يساعد تنسيق النص المستخدمين على تنويع مظهر محتوى العرض. يوضح هذا المقال كيفية استخدام Aspose.Slides for PHP via Java لتكوين خصائص الخط للفقرات النصية على الشرائح. لإدارة خصائص خط الفقرة باستخدام Aspose.Slides for PHP via Java:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى الأشكال النائبة في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) .
1. الحصول على الـ [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) من الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الذي يعرضه الـ [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) .
1. ضبط محاذاة الفقرة.
1. الوصول إلى جزء النص (Portion) في الفقرة.
1. تعريف الخط باستخدام FontData وتعيين الخط للجزء وفقًا لذلك.
   1. تعيين الخط إلى عريض.
   1. تعيين الخط إلى مائل.
1. تعيين لون الخط باستخدام الـ [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat) المعروض من كائن الـ [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) .
1. كتابة العرض المعدل إلى ملف [PPTX](https://docs.fileformat.com/presentation/pptx/) .

التنفيذ العملي للخطوات أعلاه موضح أدناه. يأخذ عرضًا غير مزخرف ويقوم بتنسيق الخطوط على إحدى الشرائح.
```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # الوصول إلى شريحة باستخدام موضع الشريحة
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
    # تعيين خطوط جديدة إلى الجزء
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
يُستخدم الجزء (Portion) للاحتفاظ بنص له نمط تنسيق موحد داخل الفقرة. يوضح هذا المقال كيفية استخدام Aspose.Slides for PHP via Java لإنشاء مربع نص يحتوي على بعض النصوص ثم تعريف خط معين، بالإضافة إلى خصائص أخرى لفئة عائلة الخط. لإنشاء مربع نص وتعيين خصائص الخط للنص بداخله:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة باستخدام فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) من النوع [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/#Rectangle) إلى الشريحة.
4. إزالة نمط التعبئة المرتبط بالـ [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) .
5. الوصول إلى TextFrame الخاص بالـ AutoShape.
6. إضافة بعض النص إلى الـ TextFrame.
7. الوصول إلى كائن الـ Portion المرتبط بالـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) .
8. تعريف الخط المستخدم للـ [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) .
9. تعيين خصائص خط أخرى مثل العريض، المائل، تحت الخط، اللون والارتفاع باستخدام الخصائص المعروضة من كائن الـ Portion.
10. كتابة العرض المعدل كملف PPTX.

التنفيذ العملي للخطوات أعلاه موضح أدناه.
```php
  # إنشاء كائن Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع Rectangle
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
    # تعيين خاصية العريض للخط
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # تعيين خاصية المائل للخط
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين خاصية التسطير للخط
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
تسمح لك Aspose.Slides باختيار حجم الخط المفضل للنص الموجود في الفقرة والنصوص التي قد تُضاف إلى الفقرة لاحقًا.

تُظهر لك شيفرة PHP هذه كيفية تعيين حجم الخط للنصوص الموجودة في الفقرة:
```php
  $presentation = new Presentation("example.pptx");
  try {
    # يحصل على الشكل الأول، على سبيل المثال.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # يحصل على الفقرة الأولى، على سبيل المثال.
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # يحدد حجم الخط الافتراضي إلى 20 نقطة لجميع أجزاء النص في الفقرة.
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # يحدد حجم الخط إلى 20 نقطة لأجزاء النص الحالية في الفقرة.
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
يسمح Aspose.Slides for PHP via Java للمطورين بتدوير النص. يمكن ضبط النص ليظهر كـ [Horizontal](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Horizontal)، [Vertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Vertical)، [Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#Vertical270)، [WordArtVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#WordArtVertical)، [EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical)، [MongolianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#MongolianVertical) أو [WordArtVerticalRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#WordArtVerticalRightToLeft). لتدوير نص أي TextFrame، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) .
5. [Rotate the text](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) .
6. حفظ الملف إلى القرص.

```php
  # إنشاء مثال من فئة Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع Rectangle
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
يدعم Aspose.Slides for PHP via Java الآن تعيين زاوية دوران مخصصة لإطار النص. في هذا الموضوع سنرى مثالًا يوضح كيفية تعيين الخاصية RotationAngle في Aspose.Slides. تمت إضافة الطريقتين الجددتين [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setrotationangle/) و [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/getrotationangle/) إلى فئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/) ، مما يسمح بتعيين زاوية دوران مخصصة لإطار النص. لتعيين RotationAngle، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. إضافة مخطط بياني إلى الشريحة.
3. [Set a rotation angle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setrotationangle/) .
4. كتابة العرض كملف PPTX.

في المثال أدناه، نقوم بتعيين خاصية RotationAngle.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع Rectangle
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


## **تباعد الأسطر لفقرة**
توفر Aspose.Slides خصائص تحت [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/) — `SpaceAfter`، `SpaceBefore` و `SpaceWithin` — تتيح لك إدارة تباعد الأسطر لفقرة. تُستخدم الخصائص الثلاث بهذه الطريقة:

* لتحديد تباعد السطر للفقرة بالنسبة المئوية، استخدم قيمة موجبة. 
* لتحديد تباعد السطر للفقرة بالنقاط، استخدم قيمة سالبة.

على سبيل المثال، يمكنك تطبيق تباعد سطر 16pt لفقرة بتعيين خاصية `SpaceBefore` إلى -16.

إليك كيفية تحديد تباعد السطر لفقرة معينة:

1. تحميل عرض يحتوي على AutoShape به بعض النص.
2. الحصول على مرجع الشريحة عبر فهرستها.
3. الوصول إلى TextFrame.
4. الوصول إلى Paragraph.
5. تعيين خصائص الفقرة.
6. حفظ العرض.

تُظهر لك شيفرة PHP هذه كيفية تحديد تباعد السطر لفقرة:
```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # الحصول على مرجع الشريحة حسب الفهرس
    $sld = $pres->getSlides()->get_Item(0);
    # الوصول إلى TextFrame
    $tf1 = $sld->getShapes()->get_Item(0)->getTextFrame();
    # الوصول إلى الفقرة
    $para = $tf1->getParagraphs()->get_Item(0);
    # ضبط خصائص الفقرة
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


## **تعيين خاصية AutofitType لـ TextFrame**
في هذا الموضوع، نستعرض خصائص تنسيق مختلفة لإطار النص. يغطي المقال كيفية تعيين خاصية AutofitType لإطار النص، وثبيت النص وتدويره في العرض. يسمح Aspose.Slides for PHP via Java للمطورين بتعيين خاصية AutofitType لأي إطار نص. يمكن تعيين AutofitType إلى [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Normal) أو [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Shape). إذا تم تعيينه إلى [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Normal) سيبقى الشكل كما هو بينما يتم تعديل النص دون تغيير الشكل، أما إذا تم تعيينه إلى [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/#Shape) فسيتم تعديل الشكل لاحتواء النص المطلوب فقط. لتعيين خاصية AutofitType لإطار نص، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) .
5. [Set the autofit type](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setautofittype/) للـ TextFrame.
6. حفظ الملف إلى القرص.
```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع Rectangle
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


## **تعيين موضع تثبيت (Anchor) لإطار النص**
يسمح Aspose.Slides for PHP via Java للمطورين بتعيين موضع تثبيت (Anchor) لأي TextFrame. يحدد TextAnchorType موضع النص داخل الشكل. يمكن تعيين AnchorType إلى [Top](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Top)، [Center](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Center)، [Bottom](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Bottom)، [Justified](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Justified) أو [Distributed](https://reference.aspose.com/slides/php-java/aspose.slides/textanchortype/#Distributed). لتعيين موضع تثبيت أي TextFrame، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) .
5. [Set the text anchor type](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setanchoringtype/) للـ TextFrame.
6. حفظ الملف إلى القرص.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع Rectangle
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


## **المسافات البادئة (Tabs) و EffectiveTabs في العرض**
جميع مسافات التبويب للنص تُعطى بالبكسل.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**الشكل: 2 علامات تبويب صريحة و2 علامات تبويب افتراضية**|

- الخاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- مجموعة EffectiveTabs تشمل جميع علامات التبويب (من مجموعة Tabs وعلامات التبويب الافتراضية).
- الخاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- الخاصية EffectiveTabs.DefaultTabSize (294) تُظهر المسافة بين علامات التبويب الافتراضية (3 و4 في مثالنا).
- الدالة EffectiveTabs.GetTabByIndex(index) مع index = 0 تُعيد أول علامة تبويب صريحة (Position = 731)، index = 1 تُعيد الثانية (Position = 1241). إذا حاولت الحصول على علامة تبويب تالية مع index = 2 ستُعيد أول علامة تبويب افتراضية (Position = 1470) وهكذا.
- الدالة EffectiveTabs.GetTabAfterPosition(pos) تُستخدم للحصول على علامة تبويب تالية بعد نص معين. على سبيل المثال لديك النص: "Hello World!". لتصيير هذا النص تحتاج معرفة من أين تبدأ رسم كلمة "world!". أولًا تحسب طول كلمة "Hello" بالبكسل ثم تستدعي GetTabAfterPosition بهذه القيمة. ستحصل على موقع علامة التبويب التالية لرسم "world!".

## **استخراج النص مع تأثير الأحرف الكبيرة (All-Caps)**
في PowerPoint، يؤدي تطبيق تأثير الخط **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عند استرداد جزء نصي بهذا الشكل باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمعالجة ذلك، تحقق من [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/)— إذا أشار إلى `All`، قم ببساطة بتحويل السلسلة المسترجعة إلى أحرف كبيرة حتى يتطابق الإخراج مع ما يراه المستخدمون على الشريحة.

لنفترض أن لدينا صندوق نص following على الشريحة الأولى من ملف sample2.pptx.

![The All Caps effect](all_caps_effect.png)

تُظهر الشيفرة أدناه كيفية استخراج النص مع تأثير **All Caps** المطبق:
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


## **الأسئلة المتكررة**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، تحتاج إلى استخدام فئة [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). يمكنك التنقل عبر جميع الخلايا في الجدول وتغيير النص في كل خلية بالوصول إلى خصائص `TextFrame` و `ParagraphFormat` الخاصة بها داخل كل خلية.

**كيف يمكن تطبيق لون تدرج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم طريقة `getFillFormat` في [BasePortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/). عيّن `FilFormat` إلى `Gradient`، حيث يمكنك تحديد ألوان البداية والنهاية للتدرج، بالإضافة إلى خصائص أخرى مثل الاتجاه والشفافية لإنشاء تأثير التدرج على النص.