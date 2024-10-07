---
title: إدارة فقرات PowerPoint
type: docs
weight: 40
url: /php-java/manage-paragraph/
keywords: "إضافة فقرة PowerPoint، إدارة الفقرات، مسافة الفقرات، خصائص الفقرات، نص HTML، تصدير نص الفقرة، عرض PowerPoint، Java، Aspose.Slides لـ PHP عبر Java"
description: "إنشاء وإدارة الفقرة والنص والمسافة والخصائص في عروض PowerPoint"
---

توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء.

* توفر Aspose.Slides الواجهة [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن أن يحتوي كائن `ITextFame` على فقرة واحدة أو أكثر (كل فقرة يتم إنشاؤها من خلال إدخال سطر جديد).
* توفر Aspose.Slides الواجهة [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) للسماح لك بإضافة كائنات تمثل الأجزاء. يمكن أن يحتوي كائن `IParagraph` على جزء واحد أو أكثر (مجموعة من كائنات iPortions).
* توفر Aspose.Slides الواجهة [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) للسماح لك بإضافة كائنات تمثل النصوص وخصائص التنسيق الخاصة بها.

يمكن لكائن `IParagraph` التعامل مع النصوص ذات خصائص التنسيق المختلفة من خلال كائناته الأساسية `IPortion`.

## **إضافة عدة فقرات تحتوي على عدة أجزاء**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة شكل مستطيل [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة.
4. الحصول على ITextFrame المرتبطة بـ [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/).
5. إنشاء كائنين [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` من [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
6. إنشاء ثلاثة كائنات [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) لكل `IParagraph` جديد (كائنين Portion للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion لكل `IParagraph`.
7. تعيين بعض النص لكل جزء.
8. تطبيق ميزات التنسيق المفضلة لديك على كل جزء باستخدام خصائص التنسيق المتاحة من كائن `IPortion`.
9. حفظ العرض المعدل.

كود PHP هذا هو تنفيذ للخطوات الخاصة بإضافة فقرات تحتوي على أجزاء:

```php
  # إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل AutoShape من نوع مستطيل
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # الوصول إلى TextFrame من AutoShape
    $tf = $ashp->getTextFrame();
    # إنشاء فقرات وأجزاء بتنسيقات نصية مختلفة
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
      for($j = 0; $j < 3; $j++) {
        $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
        $portion->setText("Portion0" . $j);
        if ($j == 0) {
          $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
          $portion->getPortionFormat()->setFontBold(NullableBool::True);
          $portion->getPortionFormat()->setFontHeight(15);
        } else if ($j == 1) {
          $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
          $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
          $portion->getPortionFormat()->setFontItalic(NullableBool::True);
          $portion->getPortionFormat()->setFontHeight(18);
        }
      }
    }
    # كتابة PPTX إلى القرص
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إدارة تعداد الفقرات**

قوائم التعداد تساعدك على تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات المرقمة تكون دائماً أسهل للقراءة والفهم.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) للأوتوشيب.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل أول فقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. تعيين `Type` التعداد للفقرة إلى `Symbol` وتعيين حرف التعداد.
8. تعيين `Text` الفقرة.
9. تعيين `Indent` الفقرة للتعداد.
10. تعيين لون للتعداد.
11. تعيين ارتفاع للتعداد.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية كما هو موضح في الخطوات من 7 إلى 13.
14. حفظ العرض التقديمي.

هذا كود PHP يوضح لك كيفية إضافة تعداد فقرة:

```php
  # إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة والوصول إلى AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار نص الأوتوشيب
    $txtFrm = $aShp->getTextFrame();
    # إزالة الفقرة الافتراضية
    $txtFrm->getParagraphs()->removeAt(0);
    # إنشاء فقرة
    $para = new Paragraph();
    # تعيين نمط التعداد ورمز الفقرة
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # تعيين نص الفقرة
    $para->setText("مرحباً بكم في Aspose.Slides");
    # تعيين التعداد
    $para->getParagraphFormat()->setIndent(25);
    # تعيين لون التعداد
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// تعيين IsBulletHardColor إلى true لاستخدام لون التعداد الخاص

    # تعيين ارتفاع التعداد
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # إضافة الفقرة إلى إطار النص
    $txtFrm->getParagraphs()->add($para);
    # إنشاء فقرة ثانية
    $para2 = new Paragraph();
    # تعيين نوع وعرض فقرة التعداد
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # إضافة نص الفقرة
    $para2->setText("هذا تعداد مرقم");
    # تعيين التعداد
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// تعيين IsBulletHardColor إلى true لاستخدام لون التعداد الخاص

    # تعيين ارتفاع التعداد
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # إضافة الفقرة إلى إطار النص
    $txtFrm->getParagraphs()->add($para2);
    # حفظ العرض التقديمي المعدل
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إدارة تعداد الصور**

قوائم التعداد تساعدك على تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات بالصور سهلة القراءة والفهم.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) للأوتوشيب.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل أول فقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/).
8. تعيين نوع التعداد إلى [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) وتعيين الصورة.
9. تعيين نص الفقرة.
10. تعيين `Indent` الفقرة للتعداد.
11. تعيين لون للتعداد.
12. تعيين ارتفاع للتعداد.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض التقديمي المعدل.

هذا كود PHP يوضح لك كيفية إضافة وإدارة تعداد الصور:

```php
  # إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
  $presentation = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $presentation->getSlides()->get_Item(0);
    # إنشاء الصورة للتعدادات
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
      $picture = $presentation->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # إضافة والوصول إلى AutoShape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للأوتوشيب
    $textFrame = $autoShape->getTextFrame();
    # إزالة الفقرة الافتراضية
    $textFrame->getParagraphs()->removeAt(0);
    # إنشاء فقرة جديدة
    $paragraph = new Paragraph();
    $paragraph->setText("مرحباً بكم في Aspose.Slides");
    # تعيين نمط التعداد والصورة للفقرة
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # تعيين ارتفاع التعداد
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # إضافة الفقرة إلى إطار النص
    $textFrame->getParagraphs()->add($paragraph);
    # حفظ العرض التقديمي كملف PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # حفظ العرض التقديمي كملف PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **إدارة تعداد متعدد المستويات**

قوائم التعداد تساعدك على تنظيم وتقديم المعلومات بسرعة وكفاءة. التعدادات المتعددة المستويات تكون سهلة القراءة والفهم.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) للأوتوشيب.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل أول فقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء مثيل ثانٍ من فقرة عبر فئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء مثيل ثالث عبر فئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء مثيل رابع عبر فئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض التقديمي المعدل.

هذا كود PHP يوضح لك كيفية إضافة وإدارة التعدادات متعددة المستويات:

```php
  # إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة والوصول إلى AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للأوتوشيب الذي تم إنشاؤه
    $text = $aShp->addTextFrame("");
    # مسح الفقرة الافتراضية
    $text->getParagraphs()->clear();
    # إضافة الفقرة الأولى
    $para1 = new Paragraph();
    $para1->setText("المحتوى");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى التعداد
    $para1->getParagraphFormat()->setDepth(0);
    # إضافة الفقرة الثانية
    $para2 = new Paragraph();
    $para2->setText("المستوى الثاني");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى التعداد
    $para2->getParagraphFormat()->setDepth(1);
    # إضافة الفقرة الثالثة
    $para3 = new Paragraph();
    $para3->setText("المستوى الثالث");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى التعداد
    $para3->getParagraphFormat()->setDepth(2);
    # إضافة الفقرة الرابعة
    $para4 = new Paragraph();
    $para4->setText("المستوى الرابع");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى التعداد
    $para4->getParagraphFormat()->setDepth(3);
    # إضافة الفقرات إلى المجموعة
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # كتابة العرض كملف PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إدارة فقرة بقائمة مرقمة مخصصة**

توفر الواجهة [IBulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/) خاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) وغيرها التي تسمح لك بإدارة الفقرات مع ترقيم أو تنسيق مخصص.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) للأوتوشيب.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء مثيل أول فقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) إلى 2.
7. إنشاء مثيل ثانٍ من فقرة عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء مثيل ثالث عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض التقديمي المعدل.

هذا كود PHP يوضح لك كيفية إضافة وإدارة الفقرات مع الترقيم أو التنسيق المخصص:

```php
  $presentation = new Presentation();
  try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للأوتوشيب الذي تم إنشاؤه
    $textFrame = $shape->getTextFrame();
    # إزالة الفقرة الافتراضية الموجودة
    $textFrame->getParagraphs()->removeAt(0);
    # القائمة الأولى
    $paragraph1 = new Paragraph();
    $paragraph1->setText("عدد 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("عدد 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("عدد 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **تعيين مسافة الفقرة**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) مع ثلاث فقرات إلى الشكل المستطيل.
5. إخفاء خطوط المستطيل.
6. تعيين المسافة لكل [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) من خلال خاصية BulletOffset الخاصة بها.
7. كتابة العرض التقديمي المعدل كملف PPT.

هذا كود PHP يوضح لك كيفية تعيين مسافة الفقرة:

```php
  # إنشاء مثيل من فئة Presentation
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل مستطيل
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # إضافة TextFrame إلى المستطيل
    $tf = $rect->addTextFrame("هذه هي السطر الأول\rهذه هي السطر الثاني\rهذه هي السطر الثالث");
    # تعيين النص ليتناسب مع الشكل
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # إخفاء خطوط المستطيل
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # الحصول على الفقرة الأولى في إطار النص وتعيين مسافاتها
    $para1 = $tf->getParagraphs()->get_Item(0);
    # تعيين نمط التعداد ورمز الفقرة
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # الحصول على الفقرة الثانية في إطار النص وتعيين مسافاتها
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # الحصول على الفقرة الثالثة في إطار النص وتعيين مسافاتها
    $para3 = $tf->getParagraphs()->get_Item(2);
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para3->getParagraphFormat()->setDepth(2);
    $para3->getParagraphFormat()->setIndent(50);
    # كتابة العرض على القرص
    $pres->save("InOutDent_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين مسافة معلقة للفقرة**

هذا كود PHP يوضح لك كيفية تعيين المسافة المعلقة لفقرة:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("مثال");
    $para2 = new Paragraph();
    $para2->setText("تعيين مسافة معلقة للفقرة");
    $para3 = new Paragraph();
    $para3->setText("هذا كود C# يوضح لك كيفية تعيين المسافة المعلقة لفقرة:");
    $para2->getParagraphFormat()->setMarginLeft(10.0);
    $para3->getParagraphFormat()->setMarginLeft(20.0);
    $autoShape->getTextFrame()->getParagraphs()->add($para1);
    $autoShape->getTextFrame()->getParagraphs()->add($para2);
    $autoShape->getTextFrame()->getParagraphs()->add($para3);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **إدارة خصائص نهاية الفقرة للفقرات**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على المرجع للشريحة التي تحتوي على الفقرة من خلال موضعها.
3. إضافة شكل مستطيل [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) مع فقرتين إلى المستطيل.
5. تعيين `FontHeight` ونوع الخط للفقرات.
6. تعيين الخصائص النهاية للفقرات.
7. كتابة العرض المعدل كملف PPTX.

هذا كود PHP يوضح لك كيفية تعيين الخصائص النهاية للفقرات في PowerPoint:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("نص عينة"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("نص عينة 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **استيراد نص HTML إلى الفقرات**

توفر Aspose.Slides دعمًا محسّنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. إضافة [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة والوصول إلى `autoshape` [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) .
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر في TextReader.
7. إنشاء مثيل أول فقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) .
8. إضافة محتوى الملف HTML في TextReader المقروء إلى مجموعة الفقرات في TextFrame .
9. حفظ العرض التقديمي المعدل.

هذا كود PHP هو تنفيذ للخطوات الخاصة باستيراد نصوص HTML في الفقرات:

```php
  # إنشاء مثيل عرض فارغ
  $pres = new Presentation();
  try {
    # الوصول إلى الشريحة الافتراضية الأولى للعروض
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape لاستيعاب محتوى HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # إضافة إطار النص إلى الشكل
    $ashape->addTextFrame("");
    # مسح جميع الفقرات في إطار النص المضاف
    $ashape->getTextFrame()->getParagraphs()->clear();
    # تحميل ملف HTML باستخدام قارئ التدفق
    $tr = new StreamReader("file.html");
    # إضافة النص من قارئ تدفق HTML إلى إطار النص
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # حفظ العرض التقديمي
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تصدير نص الفقرات إلى HTML**

توفر Aspose.Slides دعمًا محسّنًا لتصدير النصوص (المحتواة في الفقرات) إلى HTML.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي المرغوب.
2. الوصول إلى مرجع الشريحة ذات الصلة من خلال فهرسها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيتم تصديره إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) للشكل.
5. إنشاء مثيل من `StreamWriter` وإضافة ملف HTML الجديد.
6. تقديم فهرس بدء لـ StreamWriter وتصدير الفقرات المفضلة لديك.

هذا كود PHP يوضح لك كيفية تصدير نصوص فقرات PowerPoint إلى HTML:

```php
  # تحميل ملف العرض
  $pres = new Presentation("ExportingHTMLText.pptx");
  try {
    # الوصول إلى الشريحة الافتراضية الأولى في العرض
    $slide = $pres->getSlides()->get_Item(0);
    # الفهرس المرغوب
    $index = 0;
    # الوصول إلى الشكل المضاف
    $ashape = $slide->getShapes()->get_Item($index);
    # إنشاء ملف HTML جديد
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # استخراج الفقرة الأولى كـ HTML
    # كتابة بيانات الفقرات إلى HTML من خلال تقديم فهرس الفقرة البدائية، وعدد الفقرات التي سيتم نسخها
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```