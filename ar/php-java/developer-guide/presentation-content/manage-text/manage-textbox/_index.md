---
title: إدارة صندوق النص
type: docs
weight: 20
url: /php-java/manage-textbox/
description: إنشاء صندوق نص في شرائح PowerPoint باستخدام PHP. إضافة عمود في صندوق نص أو إطار نص في شرائح PowerPoint باستخدام PHP. إضافة صندوق نص مع رابط في شرائح PowerPoint باستخدام PHP.
---

النصوص في الشرائح عادةً ما تكون موجودة في صناديق نص أو أشكال. لذلك، لإضافة نص إلى شريحة، يجب عليك إضافة صندوق نص ثم وضع بعض النص داخل صندوق النص. توفر Aspose.Slides لـ PHP عبر Java واجهة [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) التي تسمح لك بإضافة شكل يحتوي على بعض النص.

{{% alert title="معلومات" color="info" %}}

توفر Aspose.Slides أيضًا واجهة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) التي تسمح لك بإضافة أشكال إلى الشرائح. ومع ذلك، ليس كل الأشكال المضافة من خلال واجهة `IShape` يمكن أن تحمل نصًا. لكن الأشكال المضافة من خلال واجهة [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) قد تحتوي على نص.

{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}} 

لذلك، عند التعامل مع شكل ترغب في إضافة نص له، قد ترغب في التحقق والتأكيد أنه تم تحويله من خلال واجهة `IAutoShape`. فقط عندئذٍ ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame)، والذي هو خاصية تحت `IAutoShape`. انظر قسم [تحديث النص](https://docs.aspose.com/slides/php-java/manage-textbox/#update-text) في هذه الصفحة.

{{% /alert %}}

## **إنشاء صندوق نص في الشريحة**

لإنشاء صندوق نص في شريحة، اتبع هذه الخطوات:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. احصل على مرجع للشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائن [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) مع تعيين [ShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setShapeType-int-) كـ `Rectangle` في موقع محدد على الشريحة واحصل على مرجع للكائن `IAutoShape` الذي تمت إضافته حديثًا.
4. أضف خاصية `TextFrame` إلى كائن `IAutoShape` الذي سيحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، احفظ ملف PPTX من خلال كائن `Presentation`. 

هذا هو كود PHP - تنفيذ الخطوات أعلاه - يوضح لك كيفية إضافة نص إلى شريحة:

```php
  # إنشاء مثيل من Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى في العرض التقديمي
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape مع تعيين النوع كـ Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # إضافة TextFrame إلى المستطيل
    $ashp->addTextFrame(" ");
    # الوصول إلى إطار النص
    $txtFrame = $ashp->getTextFrame();
    # إنشاء كائن Paragraph لإطار النص
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # إنشاء كائن Portion للفقرة
    $portion = $para->getPortions()->get_Item(0);
    # تعيين النص
    $portion->setText("Aspose TextBox");
    # حفظ العرض التقديمي على القرص
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **التحقق من شكل صندوق النص**

توفر Aspose.Slides خاصية [isTextBox()](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#isTextBox--) (من فئة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)) للسماح لك بفحص الأشكال والعثور على صناديق النص.

![صندوق النص والشكل](istextbox.png)

هذا هو كود PHP يوضح لك كيفية التحقق مما إذا كان الشكل قد تم إنشاؤه كصندوق نص:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index){
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape")))
        $autoShape = $shape;
        echo(java_is_true($autoShape->isTextBox()) ? "الشكل هو صندوق نص" : "الشكل ليس صندوق نص");
    }
}

  $pres = new Presentation("pres.pptx");
  try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($pres, $forEachShapeCallback);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة عمود في صندوق النص**

توفر Aspose.Slides خاصيتي [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) و [ColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) وفئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) التي تسمح لك بإضافة أعمدة إلى صناديق النص. يمكنك تحديد عدد الأعمدة في صندوق النص وتعيين مقدار التباعد بالنقاط بين الأعمدة.

هذا الكود يوضح العملية الموصوفة:

```php
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape مع تعيين النوع كـ Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # إضافة TextFrame إلى المستطيل
    $aShape->addTextFrame("كل هذه الأعمدة محددة لتكون ضمن حاوية نص واحدة - " . "يمكنك إضافة أو حذف نص وسيتم ضبط النص الجديد أو المتبقي تلقائيًا " . "لتدفق داخل الحاوية. لا يمكنك التدفق من حاوية إلى أخرى - " . "لأن خيارات الأعمدة للنص في PowerPoint محدودة!");
    # الحصول على تنسيق نص إطار TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # تحديد عدد الأعمدة في TextFrame
    $format->setColumnCount(3);
    # تحديد التباعد بين الأعمدة
    $format->setColumnSpacing(10);
    # حفظ العرض التقديمي
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة عمود في إطار النص**

توفر Aspose.Slides لـ PHP عبر Java خاصية [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat)) التي تسمح لك بإضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المرجح في إطار النص.

هذا هو كود PHP يوضح لك كيفية إضافة عمود داخل إطار نص:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("كل هذه الأعمدة مجبرة على البقاء ضمن حاوية نص واحدة - " . "يمكنك إضافة أو حذف نص - وسيتم ضبط النص الجديد أو المتبقي تلقائيًا " . "لتبقى داخل الحاوية. لا يمكنك أن يتدفق النص من حاوية إلى أخرى، مع ذلك - " . "لأن خيارات الأعمدة للنص في PowerPoint محدودة!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحديث النص**

تتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في صندوق نص أو جميع النصوص الموجودة في عرض تقديمي.

هذا هو كود PHP يوضح عملية يتم فيها تحديث جميع النصوص في عرض تقديمي:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # التحقق مما إذا كان الشكل يدعم إطار النص (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # التكرار من خلال الفقرات في إطار النص
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # التكرار من خلال كل جزء في الفقرة
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// تغيير النص

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// تغيير التنسيق

            }
          }
        }
      }
    }
    # حفظ العرض التقديمي المعدل
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إضافة صندوق نص مع رابط** 

يمكنك إدراج رابط داخل صندوق نص. عند النقر على صندوق النص، يتم توجيه المستخدمين لفتح الرابط.

لإضافة صندوق نص يحتوي على رابط، اتبع هذه الخطوات:

1. أنشئ مثيلًا من فئة `Presentation`. 
2. احصل على مرجع للشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائن `AutoShape` مع تعيين `ShapeType` كـ `Rectangle` في موقع محدد على الشريحة واحصل على مرجع للكائن AutoShape الذي تمت إضافته حديثًا.
4. أضف `TextFrame` إلى كائن `AutoShape` يحتوي على *Aspose TextBox* كنص افتراضي له. 
5. إنشاء مثيل من فئة `IHyperlinkManager`. 
6. تخصيص كائن `IHyperlinkManager` لخاصية [HyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getHyperlinkClick--) المرتبطة بجزءك المفضل من `TextFrame`.
7. أخيرًا، احفظ ملف PPTX من خلال كائن `Presentation`. 

هذا هو كود PHP - تنفيذ الخطوات أعلاه - يوضح لك كيفية إضافة صندوق نص مع رابط إلى شريحة:

```php
  # إنشاء مثيل من فئة Presentation التي تمثل PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة كائن AutoShape مع تعيين النوع كـ Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # تحويل الشكل إلى AutoShape
    $pptxAutoShape = $shape;
    # الوصول إلى خاصية ITextFrame المرتبطة بـ AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # إضافة بعض النص إلى الإطار
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # تعيين الرابط للجزء النصي
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # حفظ عرض PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```