---
title: إدارة النقاط
type: docs
weight: 60
url: /ar/php-java/manage-bullet/
keywords: "نقاط, قوائم نقطية, أرقام, قوائم مرقمة, نقاط صور, نقاط متعددة المستويات, عرض بوربوينت, جافا, Aspose.Slides لـ PHP عبر جافا"
description: "إنشاء قوائم نقطية ومرقمة في عرض بوربوينت"
---

في **مايكروسوفت بوربوينت**، يمكنك إنشاء قوائم نقطية ومرقمة بنفس الطريقة التي تفعلها في وورد ومحررات النصوص الأخرى. **Aspose.Slides لـ PHP عبر جافا** يتيح لك أيضًا استخدام النقاط والأرقام في الشرائح في عروضك.

## لماذا تستخدم القوائم النقطية؟

تساعد القوائم النقطية على تنظيم وتقديم المعلومات بسرعة وكفاءة.

**مثال على قائمة نقطية**

في معظم الحالات، تخدم القائمة النقطية هذه الوظائف الثلاث الرئيسية:

- تجذب انتباه قرائك أو مشاهديك إلى المعلومات المهمة
- تتيح لقرائك أو مشاهديك مسح النقاط الرئيسية بسهولة
- تتواصل وتقدم التفاصيل المهمة بكفاءة.

## لماذا تستخدم القوائم المرقمة؟

تساعد القوائم المرقمة أيضًا في تنظيم وتقديم المعلومات. من الناحية المثالية، يجب عليك استخدام الأرقام (بدلاً من النقاط) عندما يكون ترتيب الإدخالات (على سبيل المثال، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يتعين الإشارة إلى إدخال (على سبيل المثال، *انظر الخطوة 3*).

**مثال على قائمة مرقمة**

هذه هي ملخص للخطوات (من الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء النقاط** أدناه:

1. قم بإنشاء مثيل من فئة العرض التقديمي.
2. قم بتنفيذ عدة مهام (من الخطوة 3 إلى الخطوة 14).
3. احفظ العرض التقديمي.

## إنشاء النقاط
هذا الموضوع هو أيضًا جزء من سلسلة مواضيع إدارة فقرة النص. ستوضح هذه الصفحة كيف يمكننا إدارة نقاط الفقرات. النقاط أكثر فائدة حيث يتم وصف شيء ما في خطوات. علاوة على ذلك، يبدو النص منظمًا جيدًا مع استخدام النقاط. الفقرات النقطية دائمًا ما تكون أسهل قراءة وفهمًا. سنرى كيف يمكن للمطورين استخدام هذه الميزة الصغيرة ولكنها قوية من Aspose.Slides لـ PHP عبر جافا. يرجى اتباع الخطوات أدناه لإدارة نقاط الفقرة باستخدام Aspose.Slides لـ PHP عبر جافا:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide) object.
1. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) للشكل المضاف.
1. إزالة الفقرة الافتراضية في TextFrame.
1. قم بإنشاء مثيل الفقرة الأولى باستخدام [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph) class.
1. قم بتعيين نوع النقطة للفقرة.
1. قم بتعيين نوع النقطة إلى [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/BulletType#Symbol) وتحديد رمز النقطة.
1. تعيين نص الفقرة.
1. تعيين مسافة الفقرة لضبط النقطة.
1. تعيين لون النقطة.
1. تعيين ارتفاع النقاط.
1. إضافة الفقرة المنشأة إلى مجموعة فقرة TextFrame.
1. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات **7 إلى 13**.
1. حفظ العرض التقديمي.

هذا الكود النموذجي —تنفيذ الخطوات أعلاه— يوضح لك كيفية إنشاء قائمة نقطية في شريحة:

```php
  # إنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة والوصول إلى الشكل التلقائي
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للشكل التلقائي المنشأ
    $txtFrm = $aShp->getTextFrame();
    # إزالة الفقرة الافتراضية الموجودة
    $txtFrm->getParagraphs()->removeAt(0);
    # إنشاء فقرة
    $para = new Paragraph();
    # تعيين نمط النقطة للفقرة والرمز
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # تعيين نص الفقرة
    $para->setText("مرحبًا بك في Aspose.Slides");
    # تعيين مسافة النقطة
    $para->getParagraphFormat()->setIndent(25);
    # تعيين لون النقطة
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين IsBulletHardColor إلى true لاستخدام لون النقطة الخاص
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # تعيين ارتفاع النقطة
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # إضافة الفقرة إلى إطار النص
    $txtFrm->getParagraphs()->add($para);
    # حفظ العرض التقديمي كملف PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## إنشاء النقاط بالصورة

Aspose.Slides لـ PHP عبر جافا يتيح لك تغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا كنت ترغب في إضافة اهتمام بصري لقائمة أو جذب المزيد من الانتباه للإدخالات في قائمة، يمكنك استخدام صورتك الخاصة كنقطة.

{{% alert color="primary" %}} 

من الناحية المثالية، إذا كنت تنوي استبدال رمز النقطة العادية بصورة، قد ترغب في اختيار صورة رسومية بسيطة بخلفية شفافة. تعمل مثل هذه الصور بشكل أفضل كرموز نقاط مخصصة.

في أي حال، سيتم تقليل الصورة التي تختارها إلى حجم صغير جدًا، لذلك نوصي بشدة أن تختار صورة تبدو جيدة (كبديل لرمز النقطة) في قائمة.

{{% /alert %}} 

لإنشاء نقطة بالصورة، اذهب من خلال هذه الخطوات:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide) object
1. إضافة شكل تلقائي في الشريحة المحددة
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) للشكل المضاف
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)
1. إنشاء مثيل الفقرة الأولى باستخدام Paragraph class
1. تحميل الصورة من القرص في [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPPImage)
1. تعيين نوع النقطة إلى الصورة وتعيين الصورة
1. تعيين نص الفقرة
1. تعيين مسافة الفقرة لضبط النقطة
1. تعيين لون النقطة
1. تعيين ارتفاع النقاط
1. إضافة الفقرة المنشأة في مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)
1. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات السابقة
1. حفظ العرض التقديمي

هذا الكود PHP يوضح لك كيفية إنشاء نقطة بالصورة في شريحة:

```php
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إنشاء الصورة للنقاط
    $picture;
    $image = Images->fromFile("asp1.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # إضافة والوصول إلى الشكل التلقائي
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للشكل التلقائي المنشأ
    $txtFrm = $aShp->getTextFrame();
    # إزالة الفقرة الافتراضية الموجودة
    $txtFrm->getParagraphs()->removeAt(0);
    # إنشاء فقرة جديدة
    $para = new Paragraph();
    $para->setText("مرحبًا بك في Aspose.Slides");
    # تعيين نمط النقطة للفقرة والصورة
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # تعيين ارتفاع النقطة
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # إضافة الفقرة إلى إطار النص
    $txtFrm->getParagraphs()->add($para);
    # كتابة العرض التقديمي كملف PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## إنشاء النقاط متعددة المستويات

لإنشاء قائمة نقطية تحتوي على عناصر لمستويات مختلفة—قوائم إضافية تحت القائمة النقطية الرئيسية—اذهب خلال هذه الخطوات:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide) object.
1. إضافة شكل تلقائي في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. قم بإنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph مع تعميق تعيينه إلى 0.
1. قم بإنشاء مثيل الفقرة الثانية باستخدام فئة Paragraph مع تعميق تعيينه إلى 1.
1. قم بإنشاء مثيل الفقرة الثالثة باستخدام فئة Paragraph مع تعميق تعيينه إلى 2.
1. قم بإنشاء مثيل الفقرة الرابعة باستخدام فئة Paragraph مع تعميق تعيينه إلى 3.
1. إضافة الفقرات المنشأة في مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. حفظ العرض التقديمي.

هذا الكود، الذي هو تنفيذ الخطوات أعلاه، يوضح لك كيفية إنشاء قائمة نقطية متعددة المستويات:

```php
  # إنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة والوصول إلى الشكل التلقائي
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للشكل التلقائي المنشأ
    $txtFrm = $aShp->addTextFrame("");
    # إزالة الفقرة الافتراضية الموجودة
    $txtFrm->getParagraphs()->clear();
    # إنشاء الفقرة الأولى
    $para1 = new Paragraph();
    # تعيين نمط النقطة للفقرة والرمز
    $para1->setText("المحتوى");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى النقطة
    $para1->getParagraphFormat()->setDepth(0);
    # إنشاء الفقرة الثانية
    $para2 = new Paragraph();
    # تعيين نمط النقطة للفقرة والرمز
    $para2->setText("المستوى الثاني");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى النقطة
    $para2->getParagraphFormat()->setDepth(1);
    # إنشاء الفقرة الثالثة
    $para3 = new Paragraph();
    # تعيين نمط النقطة للفقرة والرمز
    $para3->setText("المستوى الثالث");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى النقطة
    $para3->getParagraphFormat()->setDepth(2);
    # إنشاء الفقرة الرابعة
    $para4 = new Paragraph();
    # تعيين نمط النقطة للفقرة والرمز
    $para4->setText("المستوى الرابع");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى النقطة
    $para4->getParagraphFormat()->setDepth(3);
    # إضافة الفقرة إلى إطار النص
    $txtFrm->getParagraphs()->add($para1);
    $txtFrm->getParagraphs()->add($para2);
    $txtFrm->getParagraphs()->add($para3);
    $txtFrm->getParagraphs()->add($para4);
    # حفظ العرض التقديمي كملف PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## إنشاء قائمة مرقمة مخصصة
Aspose.Slides لـ PHP عبر جافا يوفر واجهة برمجة تطبيقات بسيطة لإدارة الفقرات بتنسيقات أرقام مخصصة. لإضافة قائمة أرقام مخصصة في فقرة، يرجى اتباع الخطوات أدناه:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) class.
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide) object.
1. إضافة شكل تلقائي في الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. قم بإنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 2
1. قم بإنشاء مثيل الفقرة الثانية باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 3
1. قم بإنشاء مثيل الفقرة الثالثة باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 7
1. إضافة الفقرات المنشأة في مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. حفظ العرض التقديمي.

هذا الكود PHP يوضح لك كيفية إنشاء قائمة مرقمة في شريحة:

```php
  # إنشاء مثيل لفئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة والوصول إلى الشكل التلقائي
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للشكل التلقائي المنشأ
    $txtFrm = $aShp->addTextFrame("");
    # إزالة الفقرة الافتراضية الموجودة
    $txtFrm->getParagraphs()->clear();
    # القائمة الأولى
    $paragraph1 = new Paragraph();
    $paragraph1->setText("نقطة 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("نقطة 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # القائمة الثانية
    $paragraph5 = new Paragraph();
    $paragraph5->setText("نقطة 5");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(5);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph5);
    $pres->save($resourcesOutputPath . "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```