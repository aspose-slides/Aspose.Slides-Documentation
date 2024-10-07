---
title: تنسيق النص
type: docs
weight: 50
url: /php-java/text-formatting/
---


## **تسليط الضوء على النص**
تم إضافة الطريقة [highlightText](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightText-java.lang.String-java.awt.Color-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) وفئة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

تتيح تسليط الضوء على جزء من النص بلون خلفية باستخدام عينة نص، مشابه لأداة لون تسليط الضوء النص في PowerPoint 2019.

توضح مقتطف الشيفرة أدناه كيفية استخدام هذه الميزة:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $textHighlightingOptions = new TextHighlightingOptions();
    $textHighlightingOptions->setWholeWordsOnly(true);
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("title", java("java.awt.Color")->BLUE);// تسليط الضوء على جميع الكلمات "مهمة"

    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightText("to", java("java.awt.Color")->MAGENTA, $textHighlightingOptions);// تسليط الضوء على جميع حالات "the" المنفصلة

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

تقدم Aspose خدمة [تحرير PowerPoint مجانية عبر الإنترنت](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **تسليط الضوء على النص باستخدام التعبير العادي**

تم إضافة الطريقة [highlightRegex](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#highlightRegex-java.lang.String-java.awt.Color-com.aspose.slides.ITextHighlightingOptions-) إلى واجهة [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) وفئة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame).

تتيح تسليط الضوء على جزء من النص بلون الخلفية باستخدام تعبير عادي، مشابه لأداة لون تسليط الضوء النص في PowerPoint 2019.

توضح مقتطف الشيفرة أدناه كيفية استخدام هذه الميزة:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $options = new TextHighlightingOptions();
    $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getTextFrame()->highlightRegex("\\b[^\\s]{4}\\b", java("java.awt.Color")->YELLOW, $options);// تسليط الضوء على جميع الكلمات التي تحتوي على عشرة أحرف أو أكثر

    $pres->save("OutputPresentation-highlight.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين لون خلفية النص**

تسمح Aspose.Slides لك بتحديد اللون المفضل لديك لخلفية النص.

يوضح الشيفرة PHP أدناه كيفية تعيين لون الخلفية لنص كامل:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("أسود");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" أحمر ");
    $portion3 = new Portion("أسود");
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

يوضح الشيفرة PHP أدناه كيفية تعيين لون الخلفية لجزء فقط من النص:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $autoShape->getTextFrame()->getParagraphs()->clear();
    $para = new Paragraph();
    $portion1 = new Portion("أسود");
    $portion1->getPortionFormat()->setFontBold(NullableBool::True);
    $portion2 = new Portion(" أحمر ");
    $portion3 = new Portion("أسود");
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
    $redPortion = StreamSupport->stream($autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->spliterator(), false)->filter(( p) -> $p->getText()->contains("أحمر"))->findFirst();
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

يعد تنسيق النص أحد العناصر الأساسية عند إنشاء أي نوع من الوثائق أو العروض التقديمية. نحن نعلم أن Aspose.Slides لـ PHP عبر Java يدعم إضافة النصوص إلى الشرائح، ولكن في هذا الموضوع، سنرى كيف يمكننا التحكم في محاذاة فقرات النص في الشريحة. يرجى اتباع الخطوات أدناه لمحاذاة فقرات النص باستخدام Aspose.Slides لـ PHP عبر Java:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع للشريحة باستخدام فهرسها.
3. الوصول إلى أشكال العنصر النائبة الموجودة في الشريحة وتحويلها إلى [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
4. الحصول على الفقرة (التي تحتاج إلى المحاذاة) من [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape#getTextFrame--) المعروضة بواسطة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. محاذاة الفقرة. يمكن محاذاة الفقرة إلى اليمين، إلى اليسار، إلى الوسط و التبرير.
6. كتابة العرض التقديمي المعدل كملف PPTX.

تنفيذ الخطوات أعلاه موضح أدناه.

```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $pres = new Presentation("ParagraphsAlignment.pptx");
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويلها إلى AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # تغيير النص في كلا العنصرين النائبين
    $tf1->setText("محاذاة مركزية بواسطة Aspose");
    $tf2->setText("محاذاة مركزية بواسطة Aspose");
    # الحصول على الفقرة الأولى من العنصرين النائبين
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
توضح هذه المقالة كيفية تعيين خاصية الشفافية لأي شكل نص باستخدام Aspose.Slides لـ PHP عبر Java. لتعيين الشفافية للنص، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع للشريحة.
3. تعيين لون الظل.
4. كتابة العرض التقديمي كملف PPTX.

تنفيذ الخطوات أعلاه موضح أدناه.

```php
  $pres = new Presentation("transparency.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effects = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getEffectFormat();
    $outerShadowEffect = $effects->getOuterShadowEffect();
    $shadowColor = $outerShadowEffect->getShadowColor()->getColor();
    echo($shadowColor->toString() . " - الشفافية هي: " . $shadowColor->getAlpha() / 255.0 * 100);
    # تعيين الشفافية إلى صفر في المئة
    $outerShadowEffect->getShadowColor()->setColor(new java("java.awt.Color", $shadowColor->getRed(), $shadowColor->getGreen(), $shadowColor->getBlue(), 255));
    $pres->save("transparency-2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين تباعد الأحرف للنص**

تسمح Aspose.Slides لك بتعيين المسافة بين الحروف في مربع النص. بهذه الطريقة، يمكنك ضبط الكثافة البصرية لخط أو كتلة نص من خلال توسيع أو تقليص المسافة بين الأحرف.

يوضح الشيفرة PHP أدناه كيفية توسيع المسافة لخط نص واحد وتقليص المسافة لخط آخر:

```php
  $presentation = new Presentation("in.pptx");
  $textBox1 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textBox2 = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(1);
  $textBox1->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(20);// توسيع

  $textBox2->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(-2);// تقليص

  $presentation->save("out.pptx", SaveFormat::Pptx);

```

## **إدارة خصائص خط الفقرات**

تحتوي العروض التقديمية عادةً على نصوص وصور. يمكن تنسيق النص بعدة طرق، إما لتسليط الضوء على أقسام وكلمات معينة، أو للامتثال للأنماط المؤسسية. يساعد تنسيق النص المستخدمين على تغيير الشكل والمظهر لمحتوى العرض التقديمي. توضح هذه المقالة كيفية استخدام Aspose.Slides لـ PHP عبر Java لتكوين خصائص الخط لفقرات النص على الشرائح. لإدارة خصائص الخط لفقرات باستخدام Aspose.Slides لـ PHP عبر Java:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. الحصول على مرجع شريحة باستخدام فهرسها.
1. الوصول إلى أشكال العنصر النائبة في الشريحة وتحويلها إلى [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. الحصول على [فقرة](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) من [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) المعروضة بواسطة [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
1. تبرير الفقرة.
1. الوصول إلى جزء نص الفقرة.
1. تعريف الخط باستخدام FontData وضبط الخط لجزء النص وفقًا لذلك.
   1. ضبط الخط ليكون عريضًا.
   1. ضبط الخط ليكون مائلًا.
1. تعيين لون الخط باستخدام [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#getFillFormat--) المعروض بواسطة كائن [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
1. كتابة العرض التقديمي المعدل إلى ملف [PPTX](https://docs.fileformat.com/presentation/pptx/).

تنفيذ الخطوات أعلاه موضح أدناه. يأخذ عرض تقديمي غير مزين ويقوم بتنسيق الخطوط في إحدى الشرائح.

```php
  # إنشاء كائن Presentation يمثل ملف PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # الوصول إلى شريحة باستخدام موضعها في الشرائح
    $slide = $pres->getSlides()->get_Item(0);
    # الوصول إلى العنصر النائب الأول والثاني في الشريحة وتحويلها إلى AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # الوصول إلى أول فقرة
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # الوصول إلى الجزء الأول
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # تعريف خطوط جديدة
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # تعيين الخطوط الجديدة إلى الجزء
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # ضبط الخط ليكون عريضًا
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # ضبط الخط ليكون مائلًا
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # ضبط لون الخط
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
يستخدم الجزء للاحتفاظ بالنص الذي له نمط تنسيق مماثل في فقرة. توضح هذه المقالة كيفية استخدام Aspose.Slides لـ PHP عبر Java لإنشاء مربع نص ببعض النصوص ثم تحديد خط معين، والخصائص الأخرى لفئة الخط. لإنشاء مربع نص وتعيين خصائص الخط للنص فيه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة باستخدام فهرسها.
3. إضافة [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) من نوع [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) إلى الشريحة.
4. إزالة نمط التعبئة المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. الوصول إلى TextFrame المرتبطة بـ AutoShape.
6. إضافة بعض النص إلى TextFrame.
7. الوصول إلى كائن Portion المرتبط بـ [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
8. تعريف الخط المستخدم لـ [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/IPortion).
9. تعيين خصائص الخط الأخرى مثل العريض، المائل، التسطير، اللون والارتفاع باستخدام الخصائص ذات الصلة كما تعرضها كائن Portion.
10. كتابة العرض التقديمي المعدل كملف PPTX.

تنفيذ الخطوات أعلاه موضح أدناه.

```php
  # إنشاء Presentation
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
    $tf->setText("مربع نص Aspose");
    # الوصول إلى الجزء المرتبط بـ TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # تعيين الخط للجزء
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # تعيين خاصية عريض للخط
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # تعيين خاصية مائل للخط
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # تعيين خاصية تسطير للخط
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

تسمح Aspose.Slides لك باختيار حجم الخط المفضل لديك للنصوص الموجودة في فقرة والنصوص الأخرى التي قد تُضاف إلى الفقرة لاحقًا.

يوضح الشيفرة PHP أدناه كيفية تعيين حجم الخط للنص الموجود في فقرة:

```php
  $presentation = new Presentation("example.pptx");
  try {
    # الحصول على الشكل الأول، على سبيل المثال.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
      $autoShape = $shape;
      # الحصول على الفقرة الأولى، على سبيل المثال.
      $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
      # تعيين حجم الخط الافتراضي إلى 20 نقطة لجميع أجزاء النص في الفقرة.
      $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
      # تعيين حجم الخط إلى 20 نقطة لأجزاء النص الحالية في الفقرة.
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

تتيح Aspose.Slides لـ PHP عبر Java للمطورين تدوير النص. يمكن تعيين النص ليظهر كـ [أفقي](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Horizontal)، [عمودي](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical)، [عمودي 270](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#Vertical270)، [فن الكتابة العمودي](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVertical)، [عمودي شرق آسيوي](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#EastAsianVertical)، [عمودي منغولي](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#MongolianVertical) أو [فن الكتابة العمودي من اليمين إلى اليسار](https://reference.aspose.com/slides/php-java/aspose.slides/TextVerticalType#WordArtVerticalRightToLeft). لتدوير نص أي TextFrame، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [تدوير النص](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setTextVerticalType-byte-).
6. حفظ الملف على القرص.

```php
  # إنشاء مثيل من فئة Presentation
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
    $txtFrame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);
    # إنشاء كائن الفقرة لإطار النص
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # إنشاء كائن الجزء للفقرة
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("ثعلب بني سريع يقفز فوق الكلب الكسول. ثعلب بني سريع يقفز فوق الكلب الكسول.");
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
يدعم Aspose.Slides لـ PHP عبر Java الآن، تعيين زاوية دوران مخصصة لـ TextFrame. في هذا الموضوع، سنرى من خلال مثال كيفية تعيين خاصية RotationAngle في Aspose.Slides. تمت إضافة الطرق الجديدة [setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) و [getRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#getRotationAngle--) إلى واجهات [IChartTextBlockFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IChartTextBlockFormat) و [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) ، وتسمح بتعيين زاوية دوران مخصصة لـ TextFrame. لتعيين RotationAngle ، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. إضافة مخطط على الشريحة.
3. [تعيين خاصية RotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setRotationAngle-float-) .
4. كتابة العرض التقديمي كملف PPTX.

في المثال أدناه، نقوم بتعيين خاصية RotationAngle.

```php
  # إنشاء مثيل من فئة Presentation
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
    # إنشاء كائن الفقرة لإطار النص
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # إنشاء كائن الجزء للفقرة
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("مثال على دوران النص.");
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

## **تباعد الأسطر للفقرة**
توفر Aspose.Slides خصائص تحت [`ParagraphFormat`](https://reference.aspose.com/slides/php-java/aspose.slides/IParagraphFormat) — `SpaceAfter` ، `SpaceBefore` و `SpaceWithin` — التي تتيح لك إدارة تباعد الأسطر لفقرة. يتم استخدام الخصائص الثلاث بهذه الطريقة:

* لتحديد تباعد الأسطر لفقرة كنسبة مئوية، استخدم قيمة إيجابية.
* لتحديد تباعد الأسطر لفقرة بالنقاط، استخدم قيمة سالبة.

على سبيل المثال، يمكنك تطبيق تباعد بمقدار 16 نقطة لفقرة عن طريق تعيين خاصية `SpaceBefore` إلى -16.

هذا هو كيف تحدد تباعد الأسطر لفقرة معينة:

1. تحميل عرض تقديمي يحتوي على AutoShape به نص في داخله.
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. الوصول إلى TextFrame.
4. الوصول إلى الفقرة.
5. تعيين خصائص الفقرة.
6. حفظ العرض التقديمي.

يوضح الشيفرة PHP أدناه كيفية تحديد تباعد الأسطر لفقرة:

```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # الحصول على مرجع الشريحة من خلال فهرسها
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

## **تعيين خاصية AutofitType لـ TextFrame**
في هذا الموضوع، نستكشف خصائص التنسيق المختلفة لإطار النص. تغطي هذه المقالة كيفية تعيين خاصية AutofitType لإطار النص، وتثبيت النص وتدوير النص في العرض التقديمي. تسمح Aspose.Slides لـ PHP عبر Java للمطورين بتعيين خاصية AutofitType لأي إطار نص. يمكن تعيين AutofitType إلى [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) أو [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape). إذا تم تعيينه على [Normal](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Normal) فسوف يبقى الشكل كما هو بينما سيتم ضبط النص دون تغيير الشكل نفسه، بينما إذا تم تعيين AutofitType إلى [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/TextAutofitType#Shape) ، فسيتم تعديل الشكل بحيث يحتوي فقط على النص المطلوب فيه. لتعيين خاصية AutofitType لإطار نص، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [تعيين AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAutofitType-byte-) لإطار النص.
6. حفظ الملف على القرص.

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
    # إنشاء كائن الفقرة لإطار النص
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # إنشاء كائن الجزء للفقرة
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("ثعلب بني سريع يقفز فوق الكلب الكسول. ثعلب بني سريع يقفز فوق الكلب الكسول.");
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

## **تعيين تثبيت إطار النص**
تسمح Aspose.Slides لـ PHP عبر Java للمطورين بتثبيت أي إطار نص. يحدد TextAnchorType مكان وضع النص في الشكل. يمكن تعيين AnchorType إلى [أعلى](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Top)، [مركز](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Center)، [أسفل](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Bottom)، [مبرر](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Justified) أو [موزع](https://reference.aspose.com/slides/php-java/aspose.slides/TextAnchorType#Distributed). لتعيين تثبيت أي إطار نص، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. الوصول إلى الشريحة الأولى.
3. إضافة أي شكل إلى الشريحة.
4. الوصول إلى [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
5. [تعيين TextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setAnchoringType-byte-) لإطار النص.
6. حفظ الملف على القرص.

```php
  # إنشاء مثيل من فئة Presentation
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
    # إنشاء كائن الفقرة لإطار النص
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # إنشاء كائن الجزء للفقرة
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("ثعلب بني سريع يقفز فوق الكلب الكسول. ثعلب بني سريع يقفز فوق الكلب الكسول.");
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

## **شريط المسافات والتبويبات الفعالة في العرض التقديمي**
تتم جميع تبويبات النص في وحدات البكسل.

|![todo:image_alt_text](http://i.imgur.com/POpc1Lw.png)|
| :- |
|**الشكل: 2 تبويبات صريحة و 2 تبويبات افتراضية**|
- خاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- تتضمن مجموعة EffectiveTabs جميع التبويبات (من مجموعة Tabs والتبويبات الافتراضية).
- خاصية EffectiveTabs.ExplicitTabCount (2 في حالتنا) تساوي Tabs.Count.
- خاصية EffectiveTabs.DefaultTabSize (294) تظهر المسافة بين التبويبات الافتراضية (3 و 4 في مثالنا).
- EffectiveTabs.GetTabByIndex(index) مع index = 0 ستعيد أول تاب صريح (الموقع = 731)، index = 1 - التاب الثاني (الموقع = 1241). إذا حاولت الحصول على التاب التالي مع index = 2 فسوف تعيد أول تاب افتراضي (الموقع = 1470) ... إلخ.
- EffectiveTabs.GetTabAfterPosition(pos) يستخدم للحصول على التبويبة التالية بعد نص معين. على سبيل المثال لديك نص: "مرحبا بالعالم!". لرسم هذا النص، يجب أن تعرف من أين تبدأ رسم "العالم!". أولاً، يجب عليك حساب طول كلمة "مرحبا" بوحدات البكسل واستدعاء GetTabAfterPosition بالقيمة تلك. ستستلم موقع التبويبة التالية لرسم "العالم!".
