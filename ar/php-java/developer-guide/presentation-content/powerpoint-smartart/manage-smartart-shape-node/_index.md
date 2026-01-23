---
title: إدارة عقد أشكال SmartArt في العروض التقديمية باستخدام PHP
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
- عقدة المساعد
- تنسيق تعبئة
- عرض العقدة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة عقد أشكال SmartArt في ملفات PPT و PPTX باستخدام Aspose.Slides لـ PHP عبر Java. احصل على أمثلة شفرة واضحة ونصائح لتبسيط عروضك التقديمية."
---

## **إضافة عقدة SmartArt**
قدمت Aspose.Slides for PHP عبر Java أبسط واجهة برمجة تطبيقات لإدارة أشكال SmartArt بأبسط طريقة. سيساعدك الكود النموذجي التالي في إضافة عقدة وعقدة فرعية داخل شكل SmartArt.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتحميل العرض التقديمي مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
3. الانتقال عبر كل شكل داخل الشريحة الأولى.
4. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) وحول الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) إذا كان SmartArt.
5. [إضافة عقدة جديدة](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode) في شكل SmartArt [**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/#getAllNodes) وتعيين النص في TextFrame.
6. الآن، [إضافة](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode) [**عقدة فرعية**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes) في عقدة SmartArt المضافة حديثًا وتعيين النص في TextFrame.
7. احفظ العرض التقديمي.
```php
  # تحميل العرض التقديمي المطلوب
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # التنقل عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل النوع إلى SmartArt
        $smart = $shape;
        # إضافة عقدة SmartArt جديدة
        $TemNode = $smart->getAllNodes()->addNode();
        # إضافة نص
        $TemNode->getTextFrame()->setText("Test");
        # إضافة عقدة فرعية جديدة في العقدة الأم. سيتم إضافتها في نهاية المجموعة
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
في الكود النموذجي التالي شرحنا كيفية إضافة العقد الفرعية التابعة للعقد المقابلة في شكل SmartArt في موقع معين.

1. إنشاء مثال من فئة Presentation.
2. الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
3. إضافة شكل [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) من النوع [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) في الشريحة التي تم الوصول إليها.
4. الوصول إلى العقدة الأولى في شكل SmartArt المضاف.
5. الآن، أضف [**عقدة فرعية**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes) للعقدة [**المختارة**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) في الموضع 2 وقم بتعيين نصها.
6. احفظ العرض التقديمي.
```php
  # إنشاء مثيل عرض تقديمي
  $pres = new Presentation();
  try {
    # الوصول إلى شريحة العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل Smart Art IShape
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
سيساعدك الكود النموذجي التالي في الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType الخاص بـ SmartArt لأنه للقراءة فقط ولا يتم تعيينه إلا عند إضافة شكل SmartArt.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
3. الانتقال عبر كل شكل داخل الشريحة الأولى.
4. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) وحول الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) إذا كان SmartArt.
5. الانتقال عبر جميع [**العقد**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
6. الوصول وعرض معلومات مثل موضع عقدة SmartArt، المستوى والنص.
```php
  # إنشاء مثيل فئة Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # التنقل عبر كل شكل داخل الشريحة الأولى
    foreach($slide->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى SmartArt
        $smart = $shape;
        # التنقل عبر جميع العقد داخل SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # الوصول إلى عقدة SmartArt في الفهرس i
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
سيساعدك الكود النموذجي التالي في الوصول إلى العقد الفرعية التابعة للعقد المقابلة في شكل SmartArt.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
3. الانتقال عبر كل شكل داخل الشريحة الأولى.
4. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) وحول الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) إذا كان SmartArt.
5. الانتقال عبر جميع [**العقد**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) داخل شكل SmartArt.
6. لكل عقدة [**مختارة**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) داخل SmartArt، الانتقال عبر جميع [**العقد الفرعية**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--) داخل تلك العقدة.
7. الوصول وعرض معلومات مثل موضع [**العقدة الفرعية**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes) المستوى والنص.
```php
  # إنشاء مثيل فئة Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # التنقل عبر كل شكل داخل الشريحة الأولى
    foreach($slide->getShapes() as $shape) {
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى SmartArt
        $smart = $shape;
        # التنقل عبر جميع العقد داخل SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # الوصول إلى عقدة SmartArt في الفهرس i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # التنقل عبر العقد الفرعية في عقدة SmartArt في الفهرس i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # الوصول إلى العقدة الفرعية في عقدة SmartArt
            $node = $node0->getChildNodes()->get_Item($j);
            # طباعة معلمات العقدة الفرعية في SmartArt
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


## **الوصول إلى عقدة فرعية في SmartArt في موقع محدد**
في هذا المثال، سنتعلم كيفية الوصول إلى العقد الفرعية في موضع معين داخل العقد المقابلة في شكل SmartArt.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
3. إضافة شكل SmartArt من النوع [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList).
4. الوصول إلى شكل SmartArt المضاف.
5. الوصول إلى العقدة ذات الفهرس 0 داخل SmartArt.
6. الآن، الوصول إلى [**العقدة الفرعية**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes) في الموضع 1 باستخدام طريقة **get_Item()**.
7. الوصول وعرض معلومات مثل موضع [**العقدة الفرعية**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/#getChildNodes) المستوى والنص.
```php
  # إنشاء العرض التقديمي
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل SmartArt في الشريحة الأولى
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # الوصول إلى عقدة SmartArt في الفهرس 0
    $node = $smart->getAllNodes()->get_Item(0);
    # الوصول إلى العقدة الفرعية في الموضع 1 داخل العقدة الأم
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # طباعة معلمات العقدة الفرعية في SmartArt
    System->out->print("Text = " . $chNode->getTextFrame()->getText() . ",  Level = " . $chNode->getLevel() . ", Position = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إزالة عقدة SmartArt**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
3. الانتقال عبر كل شكل داخل الشريحة الأولى.
4. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) وحول الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) إذا كان SmartArt.
5. تحقق مما إذا كان SmartArt يحتوي على أكثر من 0 عقد.
6. اختيار عقدة SmartArt المراد حذفها.
7. الآن، إزالة العقدة المختارة باستخدام طريقة [**removeNode**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#removeNode).
8. احفظ العرض التقديمي.
```php
  # تحميل العرض التقديمي المطلوب
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # التنقل عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # الوصول إلى عقدة SmartArt في الفهرس 0
          $node = $smart->getAllNodes()->get_Item(0);
          # حذف العقدة المختارة
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


## **إزالة عقدة SmartArt من موقع محدد**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt في موضع معين.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
2. الحصول على مرجع الشريحة الأولى باستخدام فهرستها.
3. الانتقال عبر كل شكل داخل الشريحة الأولى.
4. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) وحول الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) إذا كان SmartArt.
5. اختيار عقدة شكل SmartArt ذات الفهرس 0.
6. الآن، تحقق مما إذا كانت العقدة المختارة تحتوي على أكثر من عقدتين فرعيتين.
7. الآن، إزالة العقدة في **الموقع 1** باستخدام طريقة [**removeNode**](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#removeNode).
8. احفظ العرض التقديمي.
```php
  # تحميل العرض التقديمي المطلوب
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # التنقل عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # التحقق مما إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى SmartArt
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # الوصول إلى عقدة SmartArt في الفهرس 0
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
يدعم Aspose.Slides for PHP عبر Java تعيين خصائص X و Y لكائن [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape). يوضح المقتطف البرمجي أدناه كيفية تعيين موضع، حجم وتدوير SmartArtShape مخصص، يرجى ملاحظة أن إضافة عقد جديدة يؤدي إلى إعادة حساب مواضع وأحجام جميع العقد. كما يمكن للمستخدم باستخدام إعدادات الموضع المخصصة تعيين العقد وفقًا للمتطلبات.
```php
  # إنشاء مثيل فئة Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # نقل شكل SmartArt إلى موضع جديد
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


## **التحقق من عقدة المساعد**
{{% alert color="primary" %}} 

في هذه المقالة سنستكشف المزيد من ميزات أشكال SmartArt المضافة إلى شرائح العروض التقديمية برمجيًا باستخدام Aspose.Slides for PHP عبر Java.

{{% /alert %}} 

سنستخدم شكل SmartArt المصدر التالي لبحثنا في أقسام مختلفة من هذه المقالة.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**الشكل: شكل SmartArt المصدر في الشريحة**|

في الكود النموذجي التالي سنستكشف كيفية تحديد **العقد المساعدة** في مجموعة عقد SmartArt وتغييرها.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض التقديمي مع شكل SmartArt.
2. الحصول على مرجع الشريحة الثانية باستخدام فهرستها.
3. الانتقال عبر كل شكل داخل الشريحة الأولى.
4. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) وحول الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) إذا كان SmartArt.
5. الانتقال عبر جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت [**عقد مساعدة**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--).
6. تغيير حالة عقدة المساعد إلى عقدة عادية.
7. احفظ العرض التقديمي.
```php
  # إنشاء مثيل عرض تقديمي
  $pres = new Presentation("AddNodes.pptx");
  try {
    # التنقل عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {)
      # التحقق إذا كان الشكل من نوع SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل النوع إلى SmartArt
        $smart = $shape;
        # التنقل عبر جميع عقد شكل SmartArt
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # التحقق إذا كانت العقدة عقدة مساعد
          if ($node->isAssistant()) {
            # تعيين عقدة المساعد إلى false وجعلها عقدة عادية
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
|**الشكل: تم تغيير عقد المساعد في شكل SmartArt داخل الشريحة**|

## **تعيين تنسيق تعبئة العقدة**
يتيح Aspose.Slides for PHP عبر Java إمكانية إضافة أشكال SmartArt مخصصة وتعيين تنسيق التعبئة الخاص بها. تُشرح هذه المقالة كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق تعبئتها باستخدام Aspose.Slides for PHP عبر Java.

يرجى اتباع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. الحصول على مرجع شريحة باستخدام فهرستها.
3. إضافة شكل [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) بتعيين [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) الخاص به.
4. تعيين [**Fill Format**](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFillFormat) لعقد شكل SmartArt.
5. كتابة العرض التقديمي المعدل كملف PPTX.
```php
  # إنشاء مثيل للعرض التقديمي
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل SmartArt والعقد
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("Some text");
    # ضبط لون تعبئة العقدة
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
يمكن للمطورين إنشاء صورة مصغرة لعقدة فرعية في SmartArt باتباع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
2. [إضافة SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnodecollection/#addNode).
3. الحصول على مرجع عقدة باستخدام فهرستها.
4. الحصول على صورة المصغرة.
5. حفظ صورة المصغرة بأي تنسيق صورة مطلوب.
```php
  # إنشاء فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # إضافة SmartArt
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # الحصول على مرجع عقدة باستخدام فهرستها
    $node = $smart->getNodes()->get_Item(1);
    # الحصول على الصورة المصغرة
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


## **FAQ**

**هل يتم دعم رسومات SmartArt المتحركة؟**

نعم. يُعامل SmartArt كشكل عادي، لذا يمكنك [تطبيق الرسوم المتحركة القياسية](/slides/ar/php-java/shape-animation/) (دخول، خروج، تأكيد، مسارات حركة) وضبط التوقيت. يمكنك أيضًا تحريك الأشكال داخل عقد SmartArt عند الحاجة.

**كيف يمكنني تحديد موقع SmartArt معين على شريحة إذا كان معرفه الداخلي غير معروف؟**

قم بتعيين والبحث باستخدام [النص البديل](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/). يتيح وضع AltText مميز على SmartArt العثور عليه برمجيًا دون الاعتماد على المعرفات الداخلية.

**هل سيحافظ مظهر SmartArt عند تحويل العرض التقديمي إلى PDF؟**

نعم. تقوم Aspose.Slides بتصدير SmartArt بدقة بصرية عالية أثناء [تحويل PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/)، مع الحفاظ على التخطيط والألوان والتأثيرات.

**هل يمكنني استخراج صورة لكامل SmartArt (للمعاينات أو التقارير)؟**

نعم. يمكنك تصيير شكل SmartArt إلى [تنسيقات نقطية](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) أو إلى [SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) للحصول على مخرجات فيكتور قابلة للتوسع، مما يجعله مناسبًا للصور المصغرة، التقارير أو الاستخدام على الويب.