---
title: "إدارة مربعات النص في العروض التقديمية باستخدام PHP"
linktitle: "إدارة مربع النص"
type: docs
weight: 20
url: /ar/php-java/manage-textbox/
keywords:
  - "مربع نص"
  - "إطار نص"
  - "إضافة نص"
  - "تحديث النص"
  - "إنشاء مربع نص"
  - "التحقق من مربع النص"
  - "إضافة عمود نص"
  - "إضافة ارتباط تشعبي"
  - PowerPoint
  - "عرض تقديمي"
  - PHP
  - Aspose.Slides
description: "يُسهل Aspose.Slides for PHP إنشاء وتحرير واستنساخ مربعات النص في ملفات PowerPoint وOpenDocument، مما يعزز أتمتة عروضك التقديمية."
---

تكون النصوص على الشرائح عادةً موجودة في مربعات النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة مربع نص ثم وضع بعض النص داخل مربع النص. توفر Aspose.Slides لـ PHP عبر Java واجهة [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) التي تتيح لك إضافة شكل يحتوي على نص.

{{% alert title="Info" color="info" %}}
كما توفر Aspose.Slides واجهة [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) التي تتيح لك إضافة أشكال إلى الشرائح. ومع ذلك، ليست كل الأشكال المضافة عبر واجهة `IShape` يمكنها احتواء نص. لكن الأشكال المضافة عبر واجهة [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) قد تحتوي على نص.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
لذلك، عندما تتعامل مع شكل تريد إضافة نص إليه، قد ترغب في التحقق والتأكد من أنه تم تحويله عبر واجهة `IAutoShape`. عندها فقط ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame)، وهو خاصية ضمن `IAutoShape`. راجع قسم [Update Text](https://docs.aspose.com/slides/php-java/manage-textbox/#update-text) في هذه الصفحة.
{{% /alert %}}

## **إنشاء مربع نص على شريحة**

لإنشاء مربع نص على شريحة، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
2. احصل على إشارة إلى الشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائنًا من النوع [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) مع [ShapeType](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setShapeType-int-) مضبوطًا على `Rectangle` في موضع محدد على الشريحة واحصل على إشارة إلى كائن `IAutoShape` المضاف حديثًا.
4. أضف خاصية `TextFrame` إلى كائن `IAutoShape` التي ستحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation` . 

يعرض هذا الكود PHP—تنفيذ للخطوات السابقة—كيفية إضافة نص إلى شريحة:
```php
  # إنشاء كائن Presentation
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى في العرض التقديمي
    $sld = $pres->getSlides()->get_Item(0);
    # يضيف AutoShape مع تعيين النوع كـ Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # يضيف TextFrame إلى المستطيل
    $ashp->addTextFrame(" ");
    # يوصل إلى إطار النص
    $txtFrame = $ashp->getTextFrame();
    # ينشئ كائن Paragraph لإطار النص
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # ينشئ كائن Portion للفقرة
    $portion = $para->getPortions()->get_Item(0);
    # يضبط النص
    $portion->setText("Aspose TextBox");
    # يحفظ العرض التقديمي إلى القرص
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **التحقق من وجود شكل مربع نص**

توفر Aspose.Slides الطريقة [isTextBox](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#isTextBox--) من فئة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) ، مما يتيح لك فحص الأشكال وتحديد مربعات النص.

![مربع نص وشكل](istextbox.png)

يعرض هذا الكود PHP كيفية التحقق مما إذا تم إنشاء الشكل كمربع نص:
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


لاحظ أنه إذا قمت بإضافة شكل تلقائي باستخدام طريقة `addAutoShape` من فئة [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) ، فإن طريقة `isTextBox` لهذا الشكل ستعيد `false`. ومع ذلك، بعد إضافة نص إلى الشكل التلقائي باستخدام طريقة `addTextFrame` أو طريقة `setText`، ستعيد الخاصية `isTextBox` القيمة `true`.
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


## **إضافة أعمدة إلى مربع نص**

توفر Aspose.Slides الخاصيتين [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) و[ColumnSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat) وفئة [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat)) التي تتيح لك إضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة في مربع النص وتعيين الفاصل بين الأعمدة بالنقاط.

هذا الكود يوضح العملية الموضحة:
```php
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape مع تعيين النوع كـ Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # إضافة TextFrame إلى المستطيل
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # يحصل على تنسيق النص في TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # يحدد عدد الأعمدة في TextFrame
    $format->setColumnCount(3);
    # يحدد المسافة بين الأعمدة
    $format->setColumnSpacing(10);
    # يحفظ العرض التقديمي
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إضافة أعمدة إلى إطار النص**

توفر Aspose.Slides لـ PHP عبر Java الخاصية [ColumnCount](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat#setColumnCount-int-) (من واجهة [ITextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormat)) التي تتيح لك إضافة أعمدة في إطارات النص. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل في إطار النص.

يعرض هذا الكود PHP كيفية إضافة عمود داخل إطار النص:
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

تسمح لك Aspose.Slides بتغيير أو تحديث النص الموجود في مربع النص أو جميع النصوص الموجودة في العرض التقديمي. 

يعرض هذا الكود PHP عملية يتم فيها تحديث أو تغيير جميع النصوص في العرض التقديمي:
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


## **إضافة مربع نص مع ارتباط تشعبي** 

يمكنك إدراج ارتباط داخل مربع نص. عندما يتم النقر على مربع النص، يتم توجيه المستخدمين لفتح الارتباط. 

لإضافة مربع نص يحتوي على ارتباط، اتبع الخطوات التالية:

1. إنشاء نسخة من فئة `Presentation` . 
2. احصل على إشارة إلى الشريحة الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. أضف كائن `AutoShape` مع `ShapeType` مضبوطًا على `Rectangle` في موضع محدد على الشريحة واحصل على إشارة إلى كائن AutoShape المضاف حديثًا.
4. أضف `TextFrame` إلى كائن `AutoShape` الذي يحتوي على *Aspose TextBox* كنص افتراضي. 
5. إنشاء نسخة من فئة `IHyperlinkManager` . 
6. تعيين كائن `IHyperlinkManager` إلى الخاصية [HyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getHyperlinkClick--) المرتبطة بالجزء المفضل من `TextFrame`.
7. أخيرًا، احفظ ملف PPTX عبر كائن `Presentation` . 

يعرض هذا الكود PHP—تنفيذ للخطوات السابقة—كيفية إضافة مربع نص مع ارتباط تشعبي إلى شريحة:
```php
  # ينشئ كائن من فئة Presentation يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # يضيف كائن AutoShape مع تعيين النوع كـ Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # يحوّل الشكل إلى AutoShape
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

**ما الفرق بين مربع النص وعناصر النائب النصية عند العمل مع الشرائح الرئيسة؟**

يُورِث [placeholder](/slides/ar/php-java/manage-placeholder/) النمط/الموضع من الـ[master](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) ويمكن تجاوزه في الـ[layouts](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/)، بينما يكون مربع النص العادي كائنًا مستقلاً على شريحة محددة ولا يتغير عند تغيير التخطيطات.

**كيف يمكنني إجراء استبدال نصي جماعي عبر العرض التقديمي دون تعديل النص داخل الرسوم البيانية والجداول وSmartArt؟**

قصر التكرار على الأشكال التلقائية التي تحتوي على إطارات نصية واستبعاد الكائنات المدمجة ([charts](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/)) من خلال استعراض مجموعاتها بشكل منفصل أو تخطي تلك الأنواع من الكائنات.