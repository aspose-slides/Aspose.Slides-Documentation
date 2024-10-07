---
title: إنشاء أو إدارة عقدة شكل سمارت آرت في باوربوينت
linktitle: إدارة عقدة شكل سمارت آرت
type: docs
weight: 30
url: /php-java/manage-smartart-shape-node/
keywords: سمارت آرت باوربوينت, عقد سمارت آرت, موضع سمارت آرت, إزالة سمارت آرت, إضافة عقد سمارت آرت, عرض باوربوينت, باوربوينت جافا, واجهة برمجة تطبيقات باوربوينت جافا
description: إدارة عقدة السمارت آرت والعقدة الفرعية في عروض باوربوينت
---

## **إضافة عقدة سمارت آرت في عرض باوربوينت باستخدام PHP**
لقد قدم Aspose.Slides لـ PHP عبر Java أبسط واجهة برمجة تطبيقات لإدارة أشكال السمارت آرت بطريقة أسهل. ستساعدك الشفرة الإرشادية التالية في إضافة عقدة وعقدة فرعية داخل شكل السمارت آرت.

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وقم بتحميل العرض مع شكل السمارت آرت.
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. تجول عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) وقم بإجراء تحويل نوع للشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) إذا كان سمارت آرت.
1. [أضف عقدة جديدة](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) في شكل السمارت آرت [**NodeCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt#getAllNodes--) وقم بتعيين النص في TextFrame.
1. الآن، [أضف](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--) [**عقدة فرعية**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) في عقدة [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) المضافة حديثًا وقم بتعيين النص في TextFrame.
1. احفظ العرض التقديمي.

```php
  # تحميل العرض المطلوب
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # تجول خلال كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # تحقق مما إذا كان الشكل من نوع سمارت آرت
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى سمارت آرت
        $smart = $shape;
        # إضافة عقدة سمارت آرت جديدة
        $TemNode = $smart->getAllNodes()->addNode();
        # إضافة نص
        $TemNode->getTextFrame()->setText("اختبار");
        # إضافة عقدة فرعية جديدة في العقدة الأم. سيتم إضافتها في نهاية المجموعة
        $newNode = $TemNode->getChildNodes()->addNode();
        # إضافة نص
        $newNode->getTextFrame()->setText("تم إضافة عقدة جديدة");
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

## **إضافة عقدة سمارت آرت في موضع محدد**
في الشفرة الإرشادية التالية، شرحنا كيفية إضافة العقد الفرعية الخاصة بالعقد المحددة من شكل السمارت آرت في موضع معين.

1. أنشئ مثيلًا من فئة Presentation.
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. أضف شكل سمارت آرت من نوع [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList) في الشريحة المنفتحة.
1. الوصول إلى العقدة الأولى في شكل السمارت آرت المضاف.
1. الآن، أضف [**عقدة فرعية**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) للعقدة المحددة [**Node**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode) في الموضع 2 واضبط نصها.
1. احفظ العرض التقديمي.

```php
  # إنشاء مثيل للعرض
  $pres = new Presentation();
  try {
    # الوصول إلى شريحة العرض
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل سمارت آرت
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # الوصول إلى عقدة السمارت آرت في الفهرس 0
    $node = $smart->getAllNodes()->get_Item(0);
    # إضافة عقدة فرعية جديدة في الموضع 2 في العقدة الأم
    $chNode = $node->getChildNodes()->addNodeByPosition(2);
    # إضافة نص
    $chNode->getTextFrame()->setText("نص تجريبي مضاف");
    # حفظ العرض
    $pres->save("AddSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **الوصول إلى عقدة سمارت آرت في عرض باوربوينت باستخدام PHP**
ستساعدك الشفرة الإرشادية التالية في الوصول إلى العقد داخل شكل السمارت آرت. يرجى ملاحظة أنك لا تستطيع تغيير LayoutType للسمارت آرت لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل السمارت آرت.

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وقم بتحميل العرض مع شكل السمارت آرت.
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. تجول عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) إذا كان سمارت آرت.
1. تجول عبر جميع [**العقد**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) داخل شكل السمارت آرت.
1. الوصول وعرض معلومات مثل موضع عقدة السمارت آرت ومستواها ونصها.

```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation("SmartArtShape.pptx");
  try {
    # احصل على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # تجول عبر كل شكل داخل الشريحة الأولى
    foreach($slide->getShapes() as $shape) {
      # تحقق من كون الشكل من نوع سمارت آرت
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى سمارت آرت
        $smart = $shape;
        # تجول عبر جميع العقد داخل السمارت آرت
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # الوصول إلى عقدة السمارت آرت في المؤشر i
          $node = $smart->getAllNodes()->get_Item($i);
          # طباعة معطيات عقدة السمارت آرت
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

## **الوصول إلى عقدة الطفل في سمارت آرت**
ستساعدك الشفرة الإرشادية التالية في الوصول إلى العقد الفرعية الخاصة بالعقد المحددة من شكل السمارت آرت.

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وقم بتحميل العرض مع شكل السمارت آرت.
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. تجول عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) إذا كان سمارت آرت.
1. تجول عبر جميع [**العقد**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt#getAllNodes--) داخل شكل السمارت آرت.
1. لكل شكل سمارت آرت محدد [**Node**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode)، تجول عبر جميع [**عقد الأطفال**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#getChildNodes--) داخل العقدة الخاصة.
1. الوصول وعرض معلومات مثل موضع [**عقدة الطفل**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) ومستواها ونصها.

```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation("AccessChildNodes.pptx");
  try {
    # احصل على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # تجول عبر كل شكل داخل الشريحة الأولى
    foreach($slide->getShapes() as $shape) {
      # تحقق من كون الشكل من نوع السمارت آرت
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى سمارت آرت
        $smart = $shape;
        # تجول عبر جميع العقد داخل السمارت آرت
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          # الوصول إلى عقدة السمارت آرت في الفهرس i
          $node0 = $smart->getAllNodes()->get_Item($i);
          # التجوال عبر العقد الفرعية في عقدة السمارت آرت في الفهرس i
          for($j = 0; $j < java_values($node0->getChildNodes()->size()) ; $j++) {
            # الوصول إلى العقدة الفرعية في عقدة السمارت آرت
            $node = $node0->getChildNodes()->get_Item($j);
            # طباعة معطيات عقدة السمارت آرت الفرعية
            System->out->print("j = " . $j . ", نص = " . $node->getTextFrame()->getText() . ",  المستوى = " . $node->getLevel() . ", الموضع = " . $node->getPosition());
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

## **الوصول إلى عقدة الطفل في موضع محدد**
في هذا المثال، سنتعلم كيفية الوصول إلى العقد الفرعية في موضع معين تتبع العقد المحددة من شكل السمارت آرت.

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. أضف شكل سمارت آرت من نوع [**StackedList**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#StackedList).
1. الوصول إلى شكل السمارت آرت المضاف.
1. الوصول إلى العقدة في الفهرس 0 لشكل السمارت آرت المنفتح.
1. الآن، الوصول إلى [**عقدة الطفل**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) في الموضع 1 للعقدة المتاحة باستخدام **get_Item()**.
1. الوصول وعرض معلومات مثل موضع [**عقدة الطفل**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNode#getChildNodes--) ومستواها ونصها.

```php
  # إنشاء مثيل العرض
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل السمارت آرت في الشريحة الأولى
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::StackedList);
    # الوصول إلى عقدة السمارت آرت في الفهرس 0
    $node = $smart->getAllNodes()->get_Item(0);
    # الوصول إلى العقدة الفرعية في الموضع 1 في العقدة الأم
    $position = 1;
    $chNode = $node->getChildNodes()->get_Item($position);
    # طباعة معطيات عقدة السمارت آرت الفرعية
    System->out->print("نص = " . $chNode->getTextFrame()->getText() . ",  المستوى = " . $chNode->getLevel() . ", الموضع = " . $chNode->getPosition());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إزالة عقدة سمارت آرت في عرض باوربوينت باستخدام PHP**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل السمارت آرت.

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وقم بتحميل العرض مع شكل السمارت آرت.
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. تجول عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) إذا كان سمارت آرت.
1. تحقق مما إذا كان [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) يحتوي على أكثر من 0 عقد.
1. حدد عقدة سمارت آرت المراد حذفها.
1. الآن، قم بإزالة العقدة المحددة باستخدام [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) method.
1. احفظ العرض التقديمي.

```php
  # تحميل العرض المطلوب
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # تجول عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # تحقق مما إذا كان الشكل من نوع سمارت آرت
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى سمارت آرت
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # الوصول إلى عقدة سمارت آرت في الفهرس 0
          $node = $smart->getAllNodes()->get_Item(0);
          # إزالة العقدة المحددة
          $smart->getAllNodes()->removeNode($node);
        }
      }
    }
    # حفظ العرض
    $pres->save("RemoveSmartArtNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إزالة عقدة سمارت آرت في موضع محدد**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل السمارت آرت في موضع معين.

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وقم بتحميل العرض مع شكل السمارت آرت.
1. احصل على مرجع الشريحة الأولى باستخدام فهرسها.
1. تجول عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) إذا كان سمارت آرت.
1. حدد شكل عقدة السمارت آرت في الفهرس 0.
1. الآن، تحقق مما إذا كانت العقدة المحددة تحتوي على أكثر من 2 عقدة فرعية.
1. الآن، قم بإزالة العقدة في **الموقع 1** باستخدام [**RemoveNode**](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#removeNode-int-) method.
1. احفظ العرض التقديمي.

```php
  # تحميل العرض المطلوب
  $pres = new Presentation("AddSmartArtNode.pptx");
  try {
    # تجول عبر كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # تحقق مما إذا كان الشكل من نوع سمارت آرت
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى سمارت آرت
        $smart = $shape;
        if (java_values($smart->getAllNodes()->size()) > 0) {
          # الوصول إلى عقدة سمارت آرت في الفهرس 0
          $node = $smart->getAllNodes()->get_Item(0);
          if (java_values($node->getChildNodes()->size()) >= 2) {
            # إزالة العقدة الفرعية في الموضع 1
            $node->getChildNodes()->removeNode(1);
          }
        }
      }
    }
    # حفظ العرض
    $pres->save("RemoveSmartArtNodeByPosition.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين موضع مخصص لعقدة الطفل في سمارت آرت**
الآن تدعم Aspose.Slides لـ PHP عبر Java تعيين خصائص [SmartArtShape](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setX-float-) و[Y](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setY-float-). يُظهر الجزء البرمجي أدناه كيفية تعيين موضع SmartArtShape المخصص، الحجم والدوران، ويرجى ملاحظة أن إضافة عقد جديدة تؤدي إلى إعادة حساب المواضع والأحجام لجميع العقد. أيضًا مع إعدادات الموضع المخصصة، يمكن للمستخدم تعيين العقد وفقًا لمتطلباته.

```php
  # إنشاء مثيل فئة Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(20, 20, 600, 500, SmartArtLayoutType::OrganizationChart);
    # نقل شكل السمارت آرت إلى موضع جديد
    $node = $smart->getAllNodes()->get_Item(1);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setX($shape->getX() + $shape->getWidth() * 2);
    $shape->setY($shape->getY() - $shape->getHeight() * 2);
    # تغيير عرض أشكال السمارت آرت
    $node = $smart->getAllNodes()->get_Item(2);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setWidth($shape->getWidth() + $shape->getWidth() * 2);
    # تغيير ارتفاع أشكال السمارت آرت
    $node = $smart->getAllNodes()->get_Item(3);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setHeight($shape->getHeight() + $shape->getHeight() * 2);
    # تغيير دوران أشكال السمارت آرت
    $node = $smart->getAllNodes()->get_Item(4);
    $shape = $node->getShapes()->get_Item(1);
    $shape->setRotation(90);
    $pres->save("SmartArt.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **تحقق من العقدة المساعدة**
{{% alert color="primary" %}} 

في هذه المقالة، سنحقق المزيد من ميزات أشكال السمارت آرت المضافة في شرائح العرض برمجيًا باستخدام Aspose.Slides لـ PHP عبر Java.

{{% /alert %}} 

سنستخدم شكل السمارت آرت المصدر التالي في تحقيقاتنا في أقسام مختلفة من هذه المقالة.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**الشكل: شكل سمارت آرت المصدر في الشريحة**|

في الشفرة الإرشادية التالية، سنتحقق من كيفية التعرف على **العقد المساعدة** في مجموعة عقد السمارت آرت وتغييراتها.

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وقم بتحميل العرض مع شكل السمارت آرت.
1. احصل على مرجع الشريحة الثانية باستخدام فهرسها.
1. تجول عبر كل شكل داخل الشريحة الأولى.
1. تحقق مما إذا كان الشكل من نوع [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) وقم بتحويل الشكل المحدد إلى [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) إذا كان سمارت آرت.
1. تجول عبر جميع العقد داخل شكل السمارت آرت وتحقق مما إذا كانت [**عقد مساعدة**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtNode#isAssistant--) .
1. قم بتغيير حالة العقدة المساعدة إلى عقدة عادية.
1. احفظ العرض.

```php
  # إنشاء مثيل العرض
  $pres = new Presentation("AddNodes.pptx");
  try {
    # تجول في كل شكل داخل الشريحة الأولى
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # تحقق مما إذا كان الشكل من نوع سمارت آرت
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # تحويل الشكل إلى سمارت آرت
        $smart = $shape;
        # التجوال عبر جميع العقد في شكل السمارت آرت
        for($i = 0; $i < java_values($smart->getAllNodes()->size()) ; $i++) {
          $node = $smart->getAllNodes()->get_Item($i);
          # تحقق مما إذا كانت العقدة هي عقدة مساعدة
          if ($node->isAssistant()) {
            # تعيين العقدة المساعدة إلى false وجعلها عقدة عادية.
            $node->isAssistant();
          }
        }
      }
    }
    # حفظ العرض
    $pres->save("ChangeAssitantNode.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**الشكل: تم تغيير العقود المساعدة في شكل السمارت آرت داخل الشريحة**|

## **تعيين تنسيق التعبئة للعقدة**
يجعل Aspose.Slides لـ PHP عبر Java من الممكن إضافة أشكال سمارت آرت مخصصة وتعيين تنسيق التعبئة الخاص بها. توضح هذه المقالة كيفية إنشاء والوصول إلى أشكال سمارت آرت وتعيين تنسيق التعبئة الخاص بها باستخدام Aspose.Slides لـ PHP عبر Java.

يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. احصل على مرجع شريحة باستخدام فهرسها.
1. أضف شكل [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArt) من خلال تعيين [**LayoutType**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess) الخاص به.
1. قم بتعيين [**FillFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getFillFormat--) لعقد شكل السمارت آرت.
1. اكتب العرض المعدل كملف PPTX.

```php
  # إنشاء مثيل للعرض
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل سمارت آرت والعقد
    $chevron = $slide->getShapes()->addSmartArt(10, 10, 800, 60, SmartArtLayoutType::ClosedChevronProcess);
    $node = $chevron->getAllNodes()->addNode();
    $node->getTextFrame()->setText("نص بعض النص");
    # تعيين لون ملء العقدة
    foreach($node->getShapes() as $item) {
      $item->getFillFormat()->setFillType(FillType::Solid);
      $item->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    }
    # حفظ العرض
    $pres->save("TestSmart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **توليد صورة مصغرة لعقدة الطفل في سمارت آرت**
يمكن للمطورين توليد صورة مصغرة لعقدة الطفل في سمارت آرت عن طريق اتباع الخطوات التالية:

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
1. [أضف سمارت آرت](https://reference.aspose.com/slides/php-java/aspose.slides/ISmartArtNodeCollection#addNode--).
1. احصل على مرجع عقدة باستخدام فهرسها.
1. احصل على صورة مصغرة.
1. احفظ صورة المصغرة بأي تنسيق صورة مرغوب.

```php
  # إنشاء مثيل فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # إضافة سمارت آرت
    $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
    # احصل على مرجع للعقدة باستخدام فهرسها
    $node = $smart->getNodes()->get_Item(1);
    # احصل على الصورة المصغرة
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