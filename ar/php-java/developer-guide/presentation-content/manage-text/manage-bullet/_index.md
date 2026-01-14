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
- نقطة رمز
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
description: "تعلم كيفية إدارة القوائم النقطية والمرقمة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for PHP عبر Java. دليل خطوة بخطوة."
---

في **Microsoft PowerPoint**، يمكنك إنشاء قوائم نقطية وقوائم مرقمة بنفس الطريقة التي تقوم بها في Word وغيرها من محررات النصوص. **Aspose.Slides for PHP via Java** يسمح لك أيضًا باستخدام النقاط والأرقام في الشرائح داخل عروضك التقديمية.

## **لماذا نستخدم القوائم النقطية؟**

القوائم النقطية تساعدك على تنظيم وتقديم المعلومات بسرعة وكفاءة.

**مثال على قائمة نقطية**

في معظم الحالات، تخدم القائمة النقطية هذه الوظائف الثلاث الرئيسية:

- تجذب انتباه القراء أو المشاهدين إلى المعلومات الهامة
- تسمح للقراء أو المشاهدين بمسح النقاط الرئيسية بسهولة
- تنقل وتقدم التفاصيل المهمة بكفاءة.

## **لماذا نستخدم القوائم المرقمة؟**

القوائم المرقمة تساعد أيضًا في تنظيم وتقديم المعلومات. من المثالي أن تستخدم الأرقام (بدلاً من النقاط) عندما يكون ترتيب العناصر (على سبيل المثال، *الخطوة 1، الخطوة 2*، إلخ) مهمًا أو عندما يحتاج عنصر إلى الإشارة إليه (على سبيل المثال، *انظر الخطوة 3*).

**مثال على قائمة مرقمة**

هذا ملخص للخطوات (من الخطوة 1 إلى الخطوة 15) في إجراء **Creating Bullets** أدناه:

1. إنشاء مثال من فئة العرض التقديمي.
2. تنفيذ عدة مهام (من الخطوة 3 إلى الخطوة 14).
3. حفظ العرض التقديمي.

## **إنشاء قوائم نقطية**

هذا الموضوع هو أيضًا جزء من سلسلة مواضيع إدارة فقرات النص. ستوضح هذه الصفحة كيفية إدارة نقاط الفقرات. تكون النقاط أكثر فائدة عندما يتم وصف شيء على خطوات. بالإضافة إلى ذلك، يظهر النص منظمًا جيدًا باستخدام النقاط. الفقرات النقطية دائمًا ما تكون أسهل في القراءة والفهم. سنرى كيف يمكن للمطورين استخدام هذه الميزة الصغيرة ولكن القوية من Aspose.Slides for PHP via Java. يرجى اتباع الخطوات أدناه لإدارة نقاط الفقرة باستخدام Aspose.Slides for PHP via Java:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/).
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة المحددة.
4. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) للشكل المضاف.
5. إزالة الفقرة الافتراضية في الـ TextFrame.
6. إنشاء مثال الفقرة الأولى باستخدام فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. تعيين نوع النقطة للفقرة.
8. تعيين نوع النقطة إلى [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol) وتحديد حرف النقطة.
9. تعيين نص الفقرة.
10. تحديد مسافة الفقرة لتعيين النقطة.
11. تعيين لون النقطة.
12. تعيين ارتفاع النقاط.
13. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات الـ TextFrame.
14. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات **7 إلى 13**.
15. حفظ العرض التقديمي.

```php
  # إنشاء كائن من فئة Presentation يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة والوصول إلى Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للـ Autoshape الذي تم إنشاؤه
    $txtFrm = $aShp->getTextFrame();
    # إزالة الفقرة الافتراضية الموجودة
    $txtFrm->getParagraphs()->removeAt(0);
    # إنشاء فقرة
    $para = new Paragraph();
    # تعيين نمط الفقرة النقطية والرمز
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # تعيين نص الفقرة
    $para->setText("Welcome to Aspose.Slides");
    # تعيين مسافة الفقرة للنقطة
    $para->getParagraphFormat()->setIndent(25);
    # تعيين لون النقطة
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # ضبط IsBulletHardColor على true لاستخدام لون نقطة مخصص
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


## **إنشاء نقاط بصورة**

Aspose.Slides for PHP via Java يتيح لك تغيير النقاط في القوائم النقطية. يمكنك استبدال النقاط برموز أو صور مخصصة. إذا أردت إضافة جاذبية بصرية إلى القائمة أو جذب انتباه أكبر إلى العناصر في القائمة، يمكنك استخدام صورتك الخاصة كنقطة.

{{% alert color="primary" %}} 
من الناحية المثالية، إذا كنت تنوي استبدال رمز النقطة العادي بصورة، قد ترغب في اختيار صورة رسومية بسيطة بخلفية شفافة. تعمل مثل هذه الصور بشكل أفضل كرموز نقطية مخصصة.  

في أي حال، ستُصغر الصورة التي تختارها إلى حجم صغير جدًا، لذا نوصي بشدة باختيار صورة تبدو جيدة (كبديل لرمز النقطة) في القائمة. 
{{% /alert %}} 

لإنشاء نقطة بصورة، اتبع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/).
3. إضافة autoshape إلى الشريحة المحددة.
4. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) لل形形 المضاف.
5. إزالة الفقرة الافتراضية في الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
6. إنشاء مثال الفقرة الأولى باستخدام فئة Paragraph.
7. تحميل الصورة من القرص إلى فئة [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).
8. تعيين نوع النقطة إلى Picture وتحديد الصورة.
9. تعيين نص الفقرة.
10. تحديد مسافة الفقرة لتعيين النقطة.
11. تعيين لون النقطة.
12. تعيين ارتفاع النقاط.
13. إضافة الفقرة التي تم إنشاؤها إلى مجموعة فقرات الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
14. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات السابقة.
15. حفظ العرض التقديمي.

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
    # إضافة والوصول إلى Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للشكل المُنشأ
    $txtFrm = $aShp->getTextFrame();
    # إزالة الفقرة الافتراضية الموجودة
    $txtFrm->getParagraphs()->removeAt(0);
    # إنشاء فقرة جديدة
    $para = new Paragraph();
    $para->setText("Welcome to Aspose.Slides");
    # تعيين نمط الفقرة النقطية والصورة
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


## **إنشاء نقاط متعددة المستويات**

لإنشاء قائمة نقطية تحتوي على عناصر في مستويات مختلفة—قوائم إضافية تحت القائمة النقطية الرئيسية—اتبع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/).
3. إضافة autoshape إلى الشريحة المحددة.
4. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) لل形形 المضاف.
5. إزالة الفقرة الافتراضية في الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
6. إنشاء مثال الفقرة الأولى باستخدام فئة Paragraph وتعيين العمق إلى 0.
7. إنشاء مثال الفقرة الثانية باستخدام فئة Paragraph وتعيين العمق إلى 1.
8. إنشاء مثال الفقرة الثالثة باستخدام فئة Paragraph وتعيين العمق إلى 2.
9. إنشاء مثال الفقرة الرابعة باستخدام فئة Paragraph وتعيين العمق إلى 3.
10. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
11. حفظ العرض التقديمي.

```php
  # إنشاء كائن من فئة Presentation يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة والوصول إلى Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للـ Autoshape المنشئ
    $txtFrm = $aShp->addTextFrame("");
    # إزالة الفقرة الافتراضية الموجودة
    $txtFrm->getParagraphs()->clear();
    # إنشاء الفقرة الأولى
    $para1 = new Paragraph();
    # تعيين نمط الفقرة النقطية والرمز
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى النقطة
    $para1->getParagraphFormat()->setDepth(0);
    # إنشاء الفقرة الثانية
    $para2 = new Paragraph();
    # تعيين نمط الفقرة النقطية والرمز
    $para2->setText("Second level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى النقطة
    $para2->getParagraphFormat()->setDepth(1);
    # إنشاء الفقرة الثالثة
    $para3 = new Paragraph();
    # تعيين نمط الفقرة النقطية والرمز
    $para3->setText("Third level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى النقطة
    $para3->getParagraphFormat()->setDepth(2);
    # إنشاء الفقرة الرابعة
    $para4 = new Paragraph();
    # تعيين نمط الفقرة النقطية والرمز
    $para4->setText("Fourth Level");
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


## **إنشاء قوائم مرقمة مخصصة**

Aspose.Slides for PHP via Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة الفقرات مع تنسيق أرقام مخصص. لإضافة قائمة أرقام مخصصة في فقرة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة في مجموعة الشرائح باستخدام كائن [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/).
3. إضافة autoshape إلى الشريحة المحددة.
4. الوصول إلى الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) لل形形 المضاف.
5. إزالة الفقرة الافتراضية في الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
6. إنشاء مثال الفقرة الأولى باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 2.
7. إنشاء مثال الفقرة الثانية باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 3.
8. إنشاء مثال الفقرة الثالثة باستخدام فئة Paragraph وتعيين **NumberedBulletStartWith** إلى 7.
9. إضافة الفقرات التي تم إنشاؤها إلى مجموعة فقرات الـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
10. حفظ العرض التقديمي.

```php
  # إنشاء كائن من فئة Presentation يمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة والوصول إلى Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للـ Autoshape المُنشأ
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


## **الأسئلة المتداولة**

**هل يمكن تصدير القوائم النقطية والمرقمة التي تم إنشاؤها باستخدام Aspose.Slides إلى صيغ أخرى مثل PDF أو الصور؟**  
نعم، Aspose.Slides يحافظ تمامًا على تنسيق وبنية القوائم النقطية والمرقمة عند تصدير العروض التقديمية إلى صيغ مثل PDF أو الصور وغيرها، مما يضمن نتائج متسقة.

**هل يمكن استيراد القوائم النقطية أو المرقمة من عروض تقديمية موجودة؟**  
نعم، Aspose.Slides يتيح لك استيراد وتعديل القوائم النقطية أو المرقمة من عروض تقديمية موجودة مع الحفاظ على تنسيقها ومظهرها الأصلي.

**هل يدعم Aspose.Slides القوائم النقطية والمرقمة في العروض التقديمية التي تم إنشاؤها بعدة لغات؟**  
نعم، Aspose.Slides يدعم بالكامل العروض التقديمية متعددة اللغات، مما يتيح لك إنشاء قوائم نقطية ومرقمة بأي لغة، بما في ذلك استخدام الأحرف الخاصة أو غير اللاتينية.