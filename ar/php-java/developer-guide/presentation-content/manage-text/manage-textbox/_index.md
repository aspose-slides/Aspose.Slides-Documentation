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
- إضافة رابط تشعبي
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP يجعل من السهل إنشاء وتحرير واستنساخ صناديق النص في ملفات PowerPoint وOpenDocument، مما يعزز أتمتة العروض التقديمية الخاصة بك."
---
## **المقدمة**

عادةً ما تكون النصوص على الشرائح موجودة في مربعات النص أو الأشكال. لذلك، لإضافة نص إلى شريحة، عليك إضافة مربع نص ثم وضع بعض النص داخل مربع النص. توفر Aspose.Slides for PHP عبر Java الفئة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) التي تتيح لك إضافة شكل يحتوي على نص.

{{% alert title="Info" color="info" %}}

كما توفر Aspose.Slides الفئة [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) التي تتيح لك إضافة أشكال إلى الشرائح. ومع ذلك، ليس كل الأشكال التي تُضاف عبر الفئة `Shape` يمكنها احتواء نص. ولكن الأشكال التي تُضاف عبر الفئة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) قد تحتوي على نص.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

لذلك، عند التعامل مع شكل تريد إضافة نص إليه، قد تحتاج إلى التحقق والتأكد من أنه تم تحويله عبر الفئة `AutoShape`. فقط عند ذلك ستتمكن من العمل مع [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/)، وهي خاصية ضمن `AutoShape`. راجع قسم [Update Text](/slides/ar/php-java/manage-textbox/#update-text) في هذه الصفحة.

{{% /alert %}}

## **إنشاء مربع نص على شريحة**

لإنشاء مربع نص على شريحة، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الحصول على مرجع للشرائح الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. إضافة كائن [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) بنوع الشكل [Rectangle](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapetype/#Rectangle) في موقع محدد على الشريحة والحصول على مرجع لكائن `AutoShape` المضاف حديثًا.
4. إضافة `TextFrame` إلى كائن `AutoShape` الذي سيحتوي على نص. في المثال أدناه، أضفنا هذا النص: *Aspose TextBox*
5. أخيرًا، كتابة ملف PPTX عبر كائن `Presentation`. 

يُظهر لك هذا الكود PHP — تنفيذ للخطوات السابقة — كيفية إضافة نص إلى شريحة:

```php
  # ينشئ كائن Presentation
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى في العرض التقديمي
    $sld = $pres->getSlides()->get_Item(0);
    # يضيف AutoShape بنوع مُحدد كـ Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # يضيف TextFrame إلى الـ Rectangle
    $ashp->addTextFrame(" ");
    # يصل إلى إطار النص
    $txtFrame = $ashp->getTextFrame();
    # ينشئ كائن Paragraph لإطار النص
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # ينشئ كائن Portion للفقرة
    $portion = $para->getPortions()->get_Item(0);
    # يحدد النص
    $portion->setText("Aspose TextBox");
    # يحفظ العرض التقديمي إلى القرص
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **التحقق من شكل مربع النص**

توفر Aspose.Slides الطريقة [isTextBox](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/istextbox/) من الفئة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/)، مما يتيح لك فحص الأشكال وتحديد مربعات النص.

![مربع نص وشكل](istextbox.png)

يُظهر لك هذا الكود PHP كيفية التحقق ما إذا تم إنشاء الشكل كمربع نص:

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
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

لاحظ أنه إذا قمت ببساطة بإضافة AutoShape باستخدام الطريقة `addAutoShape` من الفئة [ShapeCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/)، فإن طريقة `isTextBox` لـ AutoShape ستُعيد `false`. ومع ذلك، بعد إضافة نص إلى AutoShape باستخدام الطريقة `addTextFrame` أو الطريقة `setText`، ستُعيد الخاصية `isTextBox` القيمة `true`.

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

## **العثور على الشكل الذي يملك TextFrame**

في شفرة معالجة النص العامة، قد تستقبل [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) دون معرفة أي كائن عرض تقديمي يحتويه. استخدم الطريقة [TextFrame::getParentShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentShape) للانتقال مرة أخرى إلى الـ [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) (المالك).

بالنسبة إلى TextFrame الذي ينتمي إلى [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) أو شكل آخر يحتوي على نص، تُعيد [TextFrame::getParentShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentShape) المالك وتُعيد [TextFrame::getParentCell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentCell) القيمة `null`. توفر الطريقتان تنقلًا للقراءة فقط، لذا لا يغيّر استدعاؤهما الملكية. تحقق دائمًا من القيمة المرجعة باستخدام `java_is_null` قبل الوصول إلى الشكل.

للحصول على مثال كامل يحدد مالكي الشكل وخلايا الجدول، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [Search and Replace Text](/slides/ar/php-java/search-and-replace-text/).

## **إضافة أعمدة إلى مربع النص**

توفر Aspose.Slides الطريقتين [setColumnCount](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/setcolumncount/) و [setColumnSpacing](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/setcolumnspacing/) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/) التي تسمح لك بإضافة أعمدة إلى مربعات النص. يمكنك تحديد عدد الأعمدة في مربع النص وتعيين المسافة بين الأعمدة بالنقاط.

يعرض هذا الكود العملية الموصوفة:

```php
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # يضيف AutoShape بنوع محدد كـ Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # يضيف TextFrame إلى الـ Rectangle
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

## **إضافة أعمدة إلى TextFrame**

توفر Aspose.Slides for PHP عبر Java طريقة [setColumnCount](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/setcolumncount/) من الفئة [TextFrameFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/) التي تتيح لك إضافة أعمدة داخل TextFrames. من خلال هذه الخاصية، يمكنك تحديد عدد الأعمدة المفضل لديك داخل TextFrame.

يُظهر لك هذا الكود PHP كيفية إضافة عمود داخل TextFrame:

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

تتيح لك Aspose.Slides تغيير أو تحديث النص الموجود في مربع النص أو جميع النصوص الموجودة في عرض تقديمي. 

يعرض هذا الكود PHP عملية حيث يتم تحديث أو تغيير جميع النصوص في عرض تقديمي:

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
              $portion->setText($portion->getText()->replace("years", "months"));// يغير النص

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// يغير التنسيق

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

## **إضافة مربع نص مع رابط تشعبي** 

يمكنك إدراج رابط داخل مربع نص. عند النقر على مربع النص، يتم توجيه المستخدمين لفتح الرابط. 

لإضافة مربع نص يحتوي على رابط، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة `Presentation`. 
2. الحصول على مرجع للشرائح الأولى في العرض التقديمي الذي تم إنشاؤه حديثًا. 
3. إضافة كائن `AutoShape` مع `ShapeType` محدد كـ `Rectangle` في موقع معين على الشريحة والحصول على مرجع لكائن AutoShape المضاف حديثًا.
4. إضافة `TextFrame` إلى كائن `AutoShape` الذي يحتوي على *Aspose TextBox* كنص افتراضي. 
5. إنشاء نسخة من الفئة `HyperlinkManager`. 
6. تعيين رابط تشعبي باستخدام الطريقة [setExternalHyperlinkClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) المرتبطة بالجزء المفضل من `TextFrame`.
7. أخيرًا، كتابة ملف PPTX عبر كائن `Presentation`. 

يُظهر لك هذا الكود PHP — تنفيذ للخطوات السابقة — كيفية إضافة مربع نص مع رابط تشعبي إلى شريحة:

```php
  # ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # يحصل على الشريحة الأولى في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # يضيف كائن AutoShape بنوع محدد كـ Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # يحوّل الشكل إلى AutoShape
    $pptxAutoShape = $shape;
    # يتحصل على خاصية ITextFrame المرتبطة بـ AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # يضيف بعض النص إلى الإطار
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # يضبط الارتباط التشعبي لنص الجزء
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

## **الأسئلة المتكررة**

**ما هو الفرق بين مربع النص وعنصر النائب للنص عند العمل مع الشرائح الرئيسية؟**

يُورّث [placeholder](/slides/ar/php-java/manage-placeholder/) النمط/الموقع من الـ [master](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/) ويمكن تجاوزه في [layouts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/)، بينما مربع النص العادي هو كائن مستقل على شريحة محددة ولا يتغير عند تغيير التخطيطات.

**كيف يمكنني إجراء استبدال نصي جماعي عبر العرض التقديمي دون تعديل النص داخل الرسوم البيانية، الجداول، وSmartArt؟**

قصر تكرارك على الـ auto-shapes التي تحتوي على TextFrames واستبعاد الكائنات المدمجة ([charts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/ar/php-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartart/)) عن طريق استعراض مجموعاتهم بشكل منفصل أو تخطي تلك الأنواع من الكائنات.