---
title: إدارة صناديق النص في العروض التقديمية باستخدام PHP
linktitle: إدارة صندوق النص
type: docs
weight: 20
url: /ar/php-java/manage-textbox/
keywords:
- صندوق نص
- إطار نص
- إضافة نص
- تحديث نص
- إنشاء صندوق نص
- التحقق من صندوق النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "يسهل Aspose.Slides للـ PHP إنشاء وتحرير واستنساخ صناديق النص في ملفات PowerPoint و OpenDocument، مما يعزز أتمتة عروضك التقديمية."
---

عادةً ما تكون النصوص على الشرائح موجودة في صناديق النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، يجب عليك إضافة صندوق نص ثم وضع بعض النص داخل صندوق النص. توفر Aspose.Slides for PHP عبر Java الفئة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) التي تسمح لك بإضافة شكل يحتوي على نص.

{{% alert title="معلومات" color="info" %}}
توفر Aspose.Slides أيضًا الفئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) التي تسمح لك بإضافة أشكال إلى الشرائح. ومع ذلك، ليس كل الأشكال التي تُضاف عبر الفئة `Shape` يمكنها احتواء نص. لكن الأشكال التي تُضاف عبر الفئة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) قد تحتوي على نص.
{{% /alert %}}

{{% alert title="ملاحظة" color="warning" %}} 
لذلك، عند التعامل مع شكل تريد إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر الفئة `AutoShape`. فقط عندئذٍ ستتمكن من العمل مع الفئة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/)، والتي هي خاصية تحت `AutoShape`. راجع قسم [Update Text](/slides/ar/php-java/manage-textbox/#update-text) في هذه الصفحة.
{{% /alert %}}

## **إنشاء صندوق نص على شريحة**

لإنشاء صندوق نص على شريحة، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. إضافة كائن [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) بنوع الشكل المحدد كـ [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/#Rectangle) في موضع محدد على الشريحة والحصول على مرجع إلى كائن `AutoShape` المضاف حديثًا.
4. إضافة `TextFrame` إلى كائن `AutoShape` الذي سيحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، كتابة ملف PPTX عبر كائن `Presentation`. 

يعرض لك هذا الكود PHP—تنفيذ للخطوات أعلاه—كيفية إضافة نص إلى شريحة:
```php
  # إنشاء كائن Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى في العرض التقديمي
    $sld = $pres->getSlides()->get_Item(0);
    # يضيف AutoShape مع تعيين النوع كـ Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # يضيف TextFrame إلى المستطيل
    $ashp->addTextFrame(" ");
    # الوصول إلى إطار النص
    $txtFrame = $ashp->getTextFrame();
    # إنشاء كائن Paragraph لإطار النص
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # إنشاء كائن Portion للفقرة
    $portion = $para->getPortions()->get_Item(0);
    # ضبط النص
    $portion->setText("Aspose TextBox");
    # حفظ العرض التقديمي إلى القرص
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **التحقق من شكل صندوق النص**

توفر Aspose.Slides الطريقة [isTextBox](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/istextbox/) من الفئة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)، مما يتيح لك فحص الأشكال وتحديد صناديق النص.

![صندوق النص والشكل](istextbox.png)

يعرض لك هذا الكود PHP كيفية التحقق مما إذا تم إنشاء الشكل كصندوق نص:
```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachSlideCallback"));
    ForEach::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```


لاحظ أنه إذا قمت ببساطة بإضافة شكل تلقائي باستخدام الطريقة `addAutoShape` من الفئة [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/)، فإن طريقة `isTextBox` للشكل التلقائي ستعيد `false`. ومع ذلك، بعد إضافة نص إلى الشكل التلقائي باستخدام الطريقة `addTextFrame` أو الطريقة `setText`، ستعيد خاصية `isTextBox` القيمة `true`.
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() يرجع false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() يرجع true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() يرجع false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() يرجع true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() يرجع false
$shape3->addTextFrame("");
// shape3->isTextBox() يرجع false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() يرجع false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() يرجع false
```


## **إضافة أعمدة إلى صندوق النص**

توفر Aspose.Slides الطريقتين [setColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumncount/) و [setColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumnspacing/) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/) التي تسمح لك بإضافة أعمدة إلى صناديق النص. يمكنك تحديد عدد الأعمدة في صندوق النص وتعيين مقدار التباعد بالنقاط بين الأعمدة.

يعرض هذا الكود العملية الموصوفة:
```php
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape مع تعيين النوع كـ Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # إضافة TextFrame إلى المستطيل
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # يحصل على تنسيق النص لإطار النص
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


## **إضافة أعمدة إلى إطار النص**

توفر Aspose.Slides for PHP عبر Java الطريقة [setColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setcolumncount/) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/) التي تسمح لك بإضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل لديك في إطار النص.

يعرض لك هذا الكود PHP كيفية إضافة عمود داخل إطار النص:
```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
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

تتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في صندوق النص أو جميع النصوص الموجودة في عرض تقديمي.

يعرض هذا الكود PHP عملية يتم فيها تحديث أو تغيير جميع النصوص في عرض تقديمي:
```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # يتحقق مما إذا كان الشكل يدعم إطار النص (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # يتنقل عبر الفقرات في إطار النص
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # يتنقل عبر كل جزء في الفقرة
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// يغيّر النص

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// يغيّر التنسيق

            }
          }
        }
      }
    }
    # يحفظ العرض التقديمي المعدل
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إضافة صندوق نص مع ارتباط تشعبي** 

يمكنك إدراج ارتباط داخل صندوق نص. عند النقر على صندوق النص، يتم توجيه المستخدمين لفتح الارتباط. 

لإضافة صندوق نص يحتوي على ارتباط، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة `Presentation`. 
2. الحصول على مرجع إلى الشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. إضافة كائن `AutoShape` مع `ShapeType` محدد كـ `Rectangle` في موضع محدد على الشريحة والحصول على مرجع إلى كائن AutoShape المضاف حديثًا.
4. إضافة `TextFrame` إلى كائن `AutoShape` الذي يحتوي على *Aspose TextBox* كنص افتراضي. 
5. إنشاء نسخة من الفئة `HyperlinkManager`. 
6. تعيين ارتباط باستخدام الطريقة [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) المرتبطة بالجزء المفضل لديك من `TextFrame`.
7. أخيرًا، كتابة ملف PPTX عبر كائن `Presentation`. 

يعرض لك هذا الكود PHP—تنفيذ للخطوات أعلاه—كيفية إضافة صندوق نص مع ارتباط تشعبي إلى شريحة:
```php
  # ينشئ كائن Presentation يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # يضيف كائن AutoShape مع تعيين النوع كـ Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # يحول الشكل إلى AutoShape
    $pptxAutoShape = $shape;
    # يصل إلى خاصية ITextFrame المرتبطة بـ AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # يضيف بعض النص إلى الإطار
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # يحدد الارتباط التشعبي لنص الجزء
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # يحفظ عرض PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**ما الفرق بين صندوق النص وعلامة العنصر النائب للنص عند العمل مع الشرائح الرئيسة؟**

يعتمد [placeholder](/slides/ar/php-java/manage-placeholder/) على النمط/الموضع من الـ[master](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) ويمكن تجاوزه في [layouts](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/)، بينما صندوق النص العادي هو كائن مستقل على شريحة معينة ولا يتغير عند تبديل التخطيطات.

**كيف يمكنني إجراء استبدال نصي جماعي عبر العرض التقديمي دون التأثير على النص داخل المخططات والجداول وSmartArt؟**

قصر التكرار على الأشكال التلقائية التي تحتوي على إطارات نصية واستبعاد الكائنات المضمنة ([charts](https://reference.aspose.com/slides/php-java/aspose.slides/chart/)، [tables](https://reference.aspose.com/slides/php-java/aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)) عن طريق استعراض مجموعاتهم بشكل منفصل أو تخطي تلك الأنواع من الكائنات.