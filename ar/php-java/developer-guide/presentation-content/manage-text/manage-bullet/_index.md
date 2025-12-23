---
title: إدارة القوائم النقطية والمرقمة في العروض التقديمية باستخدام PHP
linktitle: إدارة القوائم
type: docs
weight: 60
url: /ar/php-java/manage-bullet/
keywords:
- نقطة
- قائمة نقطية
- قائمة مرقمة
- نقطة رمزية
- نقطة صورة
- نقطة مخصصة
- قائمة متعددة المستويات
- إنشاء نقطة
- إضافة نقطة
- إضافة قائمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إدارة القوائم النقطية والمرقمة في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. دليل خطوة بخطوة."
---

في **Microsoft PowerPoint**، يمكنك إنشاء قوائم نقطية ومرقمة بنفس الطريقة التي تقوم بها في Word وغيرها من محررات النص. **Aspose.Slides for PHP via Java** يتيح لك أيضًا استخدام النقاط والأرقام في الشرائح في عروضك التقديمية.

## **لماذا نستخدم القوائم النقطية؟**

تساعد القوائم النقطية على تنظيم وعرض المعلومات بسرعة وكفاءة. 

**مثال على قائمة نقطية**

في معظم الحالات، تُؤدي قائمة نقطية إلى ثلاث وظائف رئيسية:

- يُلفت انتباه قرائك أو مشاهديك إلى المعلومات المهمة
- يسمح لقرائك أو مشاهديك بمسح النقاط الرئيسية بسهولة
- يتواصل ويوصل التفاصيل المهمة بكفاءة.

## **لماذا نستخدم القوائم المرقمة؟**

القوائم المرقمة تساعد أيضًا في تنظيم وعرض المعلومات. يُفضَّل استخدام الأرقام (بدلاً من النقاط) عندما يكون ترتيب العناصر (على سبيل المثال، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يلزم الإشارة إلى عنصر ما (على سبيل المثال، *انظر الخطوة 3*).

**مثال على قائمة مرقمة**

هذه ملخص للخطوات (من الخطوة 1 إلى الخطوة 15) في إجراء **إنشاء النقاط** أدناه:

1. إنشاء مثيل من فئة Presentation. 
2. تنفيذ عدة مهام (من الخطوة 3 إلى الخطوة 14).
3. حفظ العرض التقديمي. 

## **إنشاء النقاط**
هذا الموضوع هو أيضًا جزء من سلسلة المواضيع لإدارة فقرات النص. ستوضح هذه الصفحة كيف يمكننا إدارة نقاط الفقرات. تكون النقاط أكثر فائدة عندما يتم وصف شيء على خطوات. علاوة على ذلك، يبدو النص منظمًا جيدًا باستخدام النقاط. فقرات النقاط دائمًا أسهل في القراءة والفهم. سنرى كيف يمكن للمطورين الاستفادة من هذه الميزة الصغيرة ولكن القوية في Aspose.Slides for PHP via Java. يرجى اتباع الخطوات أدناه لإدارة نقاط الفقرات باستخدام Aspose.Slides for PHP via Java:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) إلى الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) للشكل المضاف.
1. إزالة الفقرة الافتراضية في TextFrame.
1. إنشاء مثيل الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph).
1. تعيين نوع النقطة للفقرة.
1. تعيين نوع النقطة إلى [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/BulletType#Symbol) وتحديد حرف النقطة.
1. تحديد نص الفقرة.
1. تحديد مسافة الفقرة لضبط النقطة.
1. تعيين لون النقطة.
1. تحديد ارتفاع النقاط.
1. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات TextFrame.
1. إضافة الفقرة الثانية وإعادة العملية المذكورة في الخطوات **7 إلى 13**.
1. حفظ العرض التقديمي.

```php
  # إنشاء كائن من فئة Presentation يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة والوصول إلى الشكل التلقائي
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للشكل التلقائي الذي تم إنشاؤه
    $txtFrm = $aShp->getTextFrame();
    # إزالة الفقرة الافتراضية الموجودة
    $txtFrm->getParagraphs()->removeAt(0);
    # إنشاء فقرة
    $para = new Paragraph();
    # ضبط نمط الرصاصة للفقرة والرمز
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # ضبط نص الفقرة
    $para->setText("Welcome to Aspose.Slides");
    # ضبط مسافة إزاحة الرصاصة
    $para->getParagraphFormat()->setIndent(25);
    # ضبط لون الرصاصة
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين IsBulletHardColor إلى true لاستخدام لون الرصاصة المخصص
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # ضبط ارتفاع الرصاصة
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # إضافة الفقرة إلى إطار النص
    $txtFrm->getParagraphs()->add($para);
    # حفظ العرض التقديمي كملف PPTX
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **إنشاء نقاط بصورة**

يتيح لك Aspose.Slides for PHP via Java تغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا رغبت في إضافة عنصر بصري إلى القائمة أو جذب المزيد من الانتباه إلى العناصر في القائمة، يمكنك استخدام صورتك الخاصة كنقطة.

{{% alert color="primary" %}} 

من الناحية المثالية، إذا كنت تنوي استبدال رمز النقطة العادي بصورة، قد ترغب في اختيار صورة رسومية بسيطة ذات خلفية شفافة. تعمل مثل هذه الصور بأفضل شكل كرموز نقطية مخصصة. 

على أي حال، سيتم تقليل حجم الصورة التي تختارها إلى حجم صغير جدًا، لذا نوصي بشدة باختيار صورة تبدو جيدة (كبديل لرمز النقطة) في القائمة. 

{{% /alert %}} 

لإنشاء نقطة بصورة، اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)
1. إضافة autoshape إلى الشريحة المحددة
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) للشكل المضاف
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph
1. تحميل صورة من القرص في [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPPImage)
1. تعيين نوع النقطة إلى Picture وتحديد الصورة
1. تحديد نص الفقرة
1. تحديد مسافة الفقرة لضبط النقطة
1. تعيين لون النقطة
1. تحديد ارتفاع النقاط
1. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)
1. إضافة الفقرة الثانية وإعادة العملية المذكورة في الخطوات السابقة
1. حفظ العرض التقديمي

```php
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إنشاء الصورة للرصاصات
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
    # الوصول إلى إطار النص للشكل التلقائي الذي تم إنشاؤه
    $txtFrm = $aShp->getTextFrame();
    # إزالة الفقرة الافتراضية الموجودة
    $txtFrm->getParagraphs()->removeAt(0);
    # إنشاء فقرة جديدة
    $para = new Paragraph();
    $para->setText("Welcome to Aspose.Slides");
    # ضبط نمط رصاصة الفقرة والصورة
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # ضبط ارتفاع الرصاصة
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


## **إنشاء نقاط متعددة المستويات**

لإنشاء قائمة نقطية تحتوي على عناصر بمستويات مختلفة—قوائم إضافية تحت القائمة النقطية الرئيسية—اتبع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. إضافة autoshape إلى الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph وتعيين العمق إلى 0.
1. إنشاء مثيل الفقرة الثانية باستخدام فئة Paragraph وتعيين العمق إلى 1.
1. إنشاء مثيل الفقرة الثالثة باستخدام فئة Paragraph وتعيين العمق إلى 2.
1. إنشاء مثيل الفقرة الرابعة باستخدام فئة Paragraph وتعيين العمق إلى 3.
1. إضافة الفقرات التي تم إنشائها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. حفظ العرض التقديمي.

```php
  # إنشاء فئة Presentation تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة والوصول إلى الشكل التلقائي
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للشكل التلقائي الذي تم إنشاؤه
    $txtFrm = $aShp->addTextFrame("");
    # إزالة الفقرة الافتراضية الموجودة
    $txtFrm->getParagraphs()->clear();
    # إنشاء الفقرة الأولى
    $para1 = new Paragraph();
    # ضبط نمط رصاصة الفقرة والرمز
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # ضبط مستوى الرصاصة
    $para1->getParagraphFormat()->setDepth(0);
    # إنشاء الفقرة الثانية
    $para2 = new Paragraph();
    # ضبط نمط رصاصة الفقرة والرمز
    $para2->setText("Second level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # ضبط مستوى الرصاصة
    $para2->getParagraphFormat()->setDepth(1);
    # إنشاء الفقرة الثالثة
    $para3 = new Paragraph();
    # ضبط نمط رصاصة الفقرة والرمز
    $para3->setText("Third level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # ضبط مستوى الرصاصة
    $para3->getParagraphFormat()->setDepth(2);
    # إنشاء الفقرة الرابعة
    $para4 = new Paragraph();
    # ضبط نمط رصاصة الفقرة والرمز
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # ضبط مستوى الرصاصة
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


## **إنشاء قوائم مرقمة مخصصة**
Aspose.Slides for PHP via Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة الفقرات بتنسيق أرقام مخصص. لإضافة قائمة أرقام مخصصة في فقرة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide).
1. إضافة autoshape إلى الشريحة المحددة.
1. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) للشكل المضاف.
1. إزالة الفقرة الافتراضية في [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. إنشاء مثيل الفقرة الأولى باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 2
1. إنشاء مثيل الفقرة الثانية باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 3
1. إنشاء مثيل الفقرة الثالثة باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 7
1. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. حفظ العرض التقديمي.

```php
  # إنشاء كائن من فئة Presentation يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة والوصول إلى الشكل التلقائي
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للشكل التلقائي الذي تم إنشاؤه
    $txtFrm = $aShp->addTextFrame("");
    # إزالة الفقرة الافتراضية الموجودة
    $txtFrm->getParagraphs()->clear();
    # القائمة الأولى
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # القائمة الثانية
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 5");
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


## **الأسئلة المتكررة**

**هل يمكن تصدير القوائم النقطية والمرقمة التي تم إنشاؤها باستخدام Aspose.Slides إلى تنسيقات أخرى مثل PDF أو الصور؟**

نعم، يقوم Aspose.Slides بالحفاظ بالكامل على تنسيق وبنية القوائم النقطية والمرقمة عند تصدير العروض التقديمية إلى تنسيقات مثل PDF أو الصور وغيرها، مما يضمن نتائج متسقة.

**هل من الممكن استيراد قوائم نقطية أو مرقمة من عروض تقديمية موجودة؟**

نعم، يسمح Aspose.Slides لك باستيراد وتحرير القوائم النقطية أو المرقمة من عروض تقديمية موجودة مع الحفاظ على تنسيقها ومظهرها الأصلي.

**هل يدعم Aspose.Slides القوائم النقطية والمرقمة في العروض التقديمية التي تم إنشاؤها بلغات متعددة؟**

نعم، يدعم Aspose.Slides تمامًا العروض التقديمية متعددة اللغات، مما يتيح لك إنشاء قوائم نقطية ومرقمة بأي لغة، بما في ذلك استخدام الأحرف الخاصة أو غير اللاتينية.