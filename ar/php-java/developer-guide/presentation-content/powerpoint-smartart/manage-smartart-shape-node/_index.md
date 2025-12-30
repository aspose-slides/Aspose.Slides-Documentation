---
title: إدارة عقد شكل SmartArt في العروض التقديمية باستخدام PHP
linktitle: عقدة شكل SmartArt
type: docs
weight: 30
url: /ar/php-java/manage-smartart-shape-node/
keywords:
- عقدة SmartArt
- عقدة فرعية
- إضافة عقدة
- موضع العقدة
- الوصول إلى العقدة
- إزالة العقدة
- موضع مخصص
- عقدة مساعدة
- تنسيق تعبئة
- تصيير العقدة
- PowerPoint
- العرض التقديمي
- PHP
- Aspose.Slides
description: "إدارة عقد شكل SmartArt في ملفات PPT و PPTX باستخدام Aspose.Slides لـ PHP عبر Java. احصل على عينات كود واضحة ونصائح لتبسيط عروضك التقديمية."
---

## **إضافة عقدة SmartArt**
قدمت Aspose.Slides لـ PHP عبر Java أبسط API لإدارة أشكال SmartArt بأبسط طريقة. سيساعدك كود العينة التالي على إضافة عقدة وعقدة فرعية داخل شكل SmartArt.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
1. المرور عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) إذا كان SmartArt.
1. [Add a new Node](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) في شكل SmartArt [**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#getAllNodes--) وتعيين النص في TextFrame.
1. الآن، [Add](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) a [**Child Node**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) في عقدة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) التي تم إضافتها حديثًا وتعيين النص في TextFrame.
1. حفظ العرض التقديمي.
```php
  # تحميل العرض التقديمي المطلوب
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # الانتقال عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل نوع الشكل إلى SmartArt
        $smart = $shape;
        # إضافة عقدة SmartArt جديدة
        $TemNode = $smart->getAllNodes()->addNode();
        # إضافة نص
        $TemNode->getTextFrame()->setText("Test");
        # إضافة عقدة فرعية جديدة في العقدة الأصلية. ستُضاف في نهاية المجموعة
        $newNode = $TemNode->getChildNodes()->addNode();
        # إضافة نص
        $newNode->getTextFrame()->setText("New Node Added");
      }
    }
    # حفظ العرض التقديمي
    $pres->save("AddSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إضافة عقدة SmartArt في موقع محدد**
في كود العينة التالي نشرح كيفية إضافة العقد الفرعية التابعة للعقد المحددة في شكل SmartArt في موقع معين.

1. إنشاء مثال من فئة Presentation.
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
1. إضافة شكل [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) من نوع SmartArt في الشريحة التي تم الوصول إليها.
1. الوصول إلى العقدة الأولى في شكل SmartArt المضاف.
1. الآن، إضافة [**Child Node**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) للعقدة المحددة في الموضع 2 وتعيين نصها.
1. حفظ العرض التقديمي.
```php
  # إنشاء مثيل للعرض التقديمي
  $pres = new Presentation();
  try {
    # الوصول إلى شريحة العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة Smart Art IShape
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # الوصول إلى عقدة SmartArt في الفهرس 0
    $node = $smart->getAllNodes()->get_Item(0);
    # إضافة عقدة فرعية جديدة في الموضع 2 داخل العقدة الأصلية
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # إضافة نص
    $chNode->getTextFrame()->setText("Sample Text Added");
    # حفظ العرض التقديمي
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الوصول إلى عقدة SmartArt**
سيساعدك كود العينة التالي على الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل SmartArt.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
1. المرور عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) إذا كان SmartArt.
1. المرور عبر جميع [**Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
1. الوصول إلى معلومات مثل موضع عقدة SmartArt، المستوى والنص.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # التجول عبر كل شكل داخل الشريحة الأولى
    foreach($slide->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل نوع الشكل إلى SmartArt
        $smart = $shape;
        # التجول عبر جميع العقد داخل SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # الوصول إلى عقدة SmartArt عند الفهرس i
          $node = $smart->getAllNodes()->get_Item($i);
          # طباعة معلمات عقدة SmartArt
          System->out->print($node->getTextFrame()->getText() . " " . $node->getLevel() . " " . $node->getPosition());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الوصول إلى عقدة فرعية في SmartArt**
سيساعدك كود العينة التالي على الوصول إلى العقد الفرعية التابعة للعقد المحددة في شكل SmartArt.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
1. المرور عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) إذا كان SmartArt.
1. المرور عبر جميع [**Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
1. لكل عقدة [**Node**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) مختارة، المرور عبر جميع [**Child Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--) داخل العقدة المحددة.
1. الوصول إلى معلومات مثل موضع العقدة الفرعية، المستوى والنص.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # التجول عبر كل شكل داخل الشريحة الأولى
    foreach($slide->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل نوع الشكل إلى SmartArt
        $smart = $shape;
        # التجول عبر جميع العقد داخل SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # الوصول إلى عقدة SmartArt عند الفهرس i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # التجول عبر العقد الفرعية في عقدة SmartArt عند الفهرس i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # الوصول إلى العقدة الفرعية في عقدة SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # طباعة معلمات العقدة الفرعية لـ SmartArt
            System->out->print("j = " . $j . ", Text = " . $node->getTextFrame()->getText() . ",  Level = " . $node->getLevel() . ", Position = " . $node->getPosition());
          }
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الوصول إلى عقدة فرعية في SmartArt في موضع محدد**
في هذا المثال سنتعلم كيفية الوصول إلى العقد الفرعية في مواضع معينة تابعة للعقد المحددة في شكل SmartArt.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
1. إضافة شكل SmartArt من نوع [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList).
1. الوصول إلى شكل SmartArt المضاف.
1. الوصول إلى العقدة عند الفهرس 0 للشكل المستند إليه.
1. الآن، الوصول إلى [**Child Node**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) في الموضع 1 للعقدة المستند إليها باستخدام طريقة **get_Item()**.
1. الوصول إلى معلومات مثل موضع العقدة الفرعية، المستوى والنص.
```php
  # إنشاء عرض تقديمي
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل SmartArt في الشريحة الأولى
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # الوصول إلى عقدة SmartArt في الفهرس 0
    $node = $smart->getAllNodes()->get_Item(0);
    # الوصول إلى العقدة الفرعية في الموضع 1 داخل العقدة الأصلية
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # طباعة معلمات العقدة الفرعية لـ SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إزالة عقدة SmartArt**
في هذا المثال سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
1. المرور عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) إذا كان SmartArt.
1. التحقق مما إذا كان لـ SmartArt أكثر من 0 عقد.
1. اختيار عقدة SmartArt التي سيتم حذفها.
1. الآن، إزالة العقدة المحددة باستخدام طريقة [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) .
1. حفظ العرض التقديمي.
```php
  # تحميل العرض التقديمي المطلوب
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # الانتقال عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل نوع الشكل إلى SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # الوصول إلى عقدة SmartArt عند الفهرس 0
          $node = $smart->getAllNodes()->get_Item(0);
          # إزالة العقدة المحددة
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # حفظ العرض التقديمي
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إزالة عقدة SmartArt من موضع محدد**
في هذا المثال سنتعلم كيفية إزالة العقد داخل شكل SmartArt في موضع معين.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
1. المرور عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) إذا كان SmartArt.
1. اختيار عقدة شكل SmartArt عند الفهرس 0.
1. الآن، التحقق مما إذا كانت العقدة المحددة لديها أكثر من عقدتين فرعيتين.
1. الآن، إزالة العقدة في **الموضع 1** باستخدام طريقة [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-int-) .
1. حفظ العرض التقديمي.
```php
  # تحميل العرض التقديمي المطلوب
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # التجول عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل نوع الشكل إلى SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # الوصول إلى عقدة SmartArt عند الفهرس 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # إزالة العقدة الفرعية في الموضع 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # حفظ العرض التقديمي
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين موضع مخصص لعقدة فرعية في كائن SmartArt**
الآن تدعم Aspose.Slides لـ PHP عبر Java إعداد خصائص [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) لـ [X](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setX-float-) و [Y](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setY-float-). يوضح الجزء البرمجي أدناه كيفية تعيين موضع وش Size ودوران SmartArtShape مخصص، يرجى ملاحظة أن إضافة عقد جديدة يؤدي إلى إعادة حساب مواضع وحجم جميع العقد. كذلك مع إعدادات الموضع المخصص، يمكن للمستخدم تعيين العقد وفقًا للمتطلبات.
```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # نقل شكل SmartArt إلى موقع جديد
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() . $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # تغيير عرض شكل SmartArt
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() . $shape->getWidth() * 2);
    # تغيير ارتفاع شكل SmartArt
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() . $shape->getHeight() * 2);
    # تغيير دوران شكل SmartArt
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **التحقق من عقدة مساعدة**
{{% alert color="primary" %}} 

في هذه المقالة سنستكشف المزيد من ميزات أشكال SmartArt التي تم إضافتها إلى شرائح العرض التقديمي برمجيًا باستخدام Aspose.Slides لـ PHP عبر Java.

{{% /alert %}} 

سنستخدم شكل SmartArt المصدر التالي للتحقق في الأقسام المختلفة من هذه المقالة.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**شكل: شكل SmartArt المصدر في الشريحة**|

في كود العينة التالي سنبحث عن كيفية التعرف على **العقد المساعدة** في مجموعة عقد SmartArt وتغييرها.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
1. الحصول على مرجع الشريحة الثانية باستخدام الفهرس الخاص بها.
1. المرور عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) إذا كان SmartArt.
1. المرور عبر جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت [**Assistant Nodes**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--) .
1. تغيير حالة عقدة المساعدة إلى عقدة عادية.
1. حفظ العرض التقديمي.
```php
  # إنشاء مثيل للعرض التقديمي
  $pres = new Presentation("AddNodes.pptx");
  try {
    # التجول عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل نوع الشكل إلى SmartArt
        $smart = $shape;
        # التجول عبر جميع العقد في شكل SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # التحقق مما إذا كانت العقدة عقدة مساعدة
          if ($node->isAssistant()) {
            # تعيين عقدة المساعدة إلى false وجعلها عقدة عادية
            $node->isAssistant();
          }
        }
      }
    }
    # حفظ العرض التقديمي
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**شكل: تم تغيير العقد المساعدة في شكل SmartArt داخل الشريحة**|

## **تعيين تنسيق تعبئة للعقدة**
تجعل Aspose.Slides لـ PHP عبر Java من الممكن إضافة أشكال SmartArt مخصصة وتعيين تنسيق التعبئة لها. يوضح هذا المقال كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق تعبئتها باستخدام Aspose.Slides لـ PHP عبر Java.

يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
1. إضافة شكل [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) عن طريق تعيين [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) الخاص به.
1. تعيين [**FillFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getFillFormat--) لعقد شكل SmartArt.
1. كتابة العرض التقديمي المعدل كملف PPTX.
```php
  # إنشاء العرض التقديمي
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل SmartArt والعقد
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # تعيين لون تعبئة العقدة
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # حفظ العرض التقديمي
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إنشاء صورة مصغرة لعقدة فرعية في SmartArt**
يمكن للمطورين إنشاء صورة مصغرة لعقدة فرعية في SmartArt باتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
1. [Add SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) .
1. الحصول على مرجع عقدة باستخدام الفهرس الخاص بها.
1. الحصول على صورة المصغرة.
1. حفظ صورة المصغرة بأي تنسيق صورة مطلوب.
```php
  # إنشاء كائن من فئة Presentation يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # إضافة SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # الحصول على مرجع عقدة باستخدام فهرستها
    $node = $smart->getNodes()->get_Item(1);
    # الحصول على صورة مصغرة
    $slideImage = $node->getShapes()->get_Item(0)->getImage();
    # حفظ الصورة المصغرة
    try {
      $slideImage->save("SmartArt_ChildNote_Thumbnail.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتكررة**

**هل يدعم SmartArt الرسوم المتحركة؟**

نعم. يُعامل SmartArt كشكل عادي، لذا يمكنك [تطبيق الرسوم المتحركة القياسية](/slides/ar/php-java/shape-animation/) (الدخول، الخروج، التأكيد، مسارات الحركة) وضبط التوقيت. يمكنك أيضًا تحريك الأشكال داخل عقد SmartArt عند الحاجة.

**كيف يمكنني تحديد موقع SmartArt معين على الشريحة إذا كان معرفه الداخلي غير معروف؟**

قم بالتعيين والبحث باستخدام [النص البديل](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/). يسمح تعيين AltText مميز على SmartArt بالعثور عليه برمجيًا دون الاعتماد على المعرفات الداخلية.

**هل سيتم الحفاظ على مظهر SmartArt عند تحويل العرض التقديمي إلى PDF؟**

نعم. تقوم Aspose.Slides بتصدير SmartArt بدقة بصرية عالية أثناء [تصدير PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)، مع الحفاظ على التخطيط والألوان والتأثيرات.

**هل يمكنني استخراج صورة لكامل SmartArt (للمعاينات أو التقارير)؟**

نعم. يمكنك تصيير شكل SmartArt إلى [صيغ نقطية raster formats](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) أو إلى [SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) للحصول على مخرجات متجهية قابلة للتوسع، مما يجعله مناسبًا للصور المصغرة أو التقارير أو الاستخدام على الويب.