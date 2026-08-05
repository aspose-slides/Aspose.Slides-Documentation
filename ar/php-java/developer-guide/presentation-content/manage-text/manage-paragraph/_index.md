---
title: إدارة فقرات نص PowerPoint في PHP
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة الرصاصة
- إزاحة الفقرة
- إزاحة متدلية
- رصاصة الفقرة
- قائمة مرقمة
- قائمة نقطية
- خصائص الفقرة
- استيراد HTML
- نص إلى HTML
- فقرة إلى HTML
- فقرة إلى صورة
- نص إلى صورة
- تصدير الفقرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحكم في تنسيق الفقرات باستخدام Aspose.Slides لـ PHP عبر Java — تحسين المحاذاة والمسافات والأسلوب في عروض PPT و PPTX و ODP."
---
## **مقدمة**

توفر Aspose.Slides جميع الفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأقسام.

* توفر Aspose.Slides الفئة [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) التي تسمح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `TextFame` أن يحتوي على فقرة واحدة أو متعددة (كل فقرة تُنشأ عبر إرجاع السطر).
* توفر Aspose.Slides الفئة [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/) التي تسمح لك بإضافة كائنات تمثل أقسام. يمكن لكائن `Paragraph` أن يحتوي على قسم واحد أو متعددة (مجموعة من كائنات القسم).
* توفر Aspose.Slides الفئة [Portion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/) التي تسمح لك بإضافة كائنات تمثل النصوص وخصائص التنسيق الخاصة بها.

كائن `Paragraph` قادر على معالجة النصوص ذات خصائص تنسيق مختلفة من خلال كائنات `Portion` التابعة له.

## **إضافة فقرات متعددة تحتوي على أقسام متعددة**

تظهر لك هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات وكل فقرة تحتوي على 3 أقسام:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الحصول على ITextFrame المرتبط بـ [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/).
5. إنشاء كائنين من الفئة [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/) وإضافتهما إلى مجموعة الفقرات في [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/).
6. إنشاء ثلاثة كائنات من الفئة [Portion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/) لكل `Paragraph` جديد (قسمين لفقرة الافتراضية) وإضافة كل كائن `Portion` إلى مجموعة الأقسام في كل `Paragraph`.
7. تعيين نص لكل قسم.
8. تطبيق خصائص التنسيق المفضلة على كل قسم باستخدام خصائص التنسيق المتاحة في كائن `Portion`.
9. حفظ العرض التقديمي المعدل.

```php
# إنشاء كائن من فئة Presentation يمثل ملف PPTX
$pres = new Presentation();
try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع مستطيل
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # الوصول إلى TextFrame الخاص بـ AutoShape
    $tf = $ashp->getTextFrame();
    # إنشاء فقرات وأقسام باستخدام تنسيقات نصية مختلفة
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
    # حفظ PPTX إلى القرص
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **إدارة نقاط الفقرة**

تساعد القوائم النقطية على تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات ذات النقاط دائمًا أسهل في القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص بالأوتوشيب.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول كائن فقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/).
7. تعيين `Type` للرصاصة للفقرة إلى `Symbol` وتعيين حرف الرصاصة.
8. تعيين `Text` للفقرة.
9. تعيين `Indent` للفقرة للرصاصة.
10. تعيين لون للرصاصة.
11. تعيين ارتفاع للرصاصة.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات من 7 إلى 13.
14. حفظ العرض التقديمي.

```php
# إنشاء كائن من فئة Presentation يمثل ملف PPTX
$pres = new Presentation();
try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة والوصول إلى AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص الخاص بـ AutoShape
    $txtFrm = $aShp->getTextFrame();
    # إزالة الفقرة الافتراضية
    $txtFrm->getParagraphs()->removeAt(0);
    # إنشاء فقرة
    $para = new Paragraph();
    # تعيين نمط رصاصة الفقرة والرمز
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # تعيين نص الفقرة
    $para->setText("Welcome to Aspose.Slides");
    # تعيين إزاحة الرصاصة
    $para->getParagraphFormat()->setIndent(25);
    # تعيين لون الرصاصة
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// تعيين IsBulletHardColor إلى true لاستخدام لون الرصاصة الخاص

    # تعيين ارتفاع الرصاصة
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # إضافة الفقرة إلى إطار النص
    $txtFrm->getParagraphs()->add($para);
    # إنشاء الفقرة الثانية
    $para2 = new Paragraph();
    # تعيين نوع الرصاصة للفقرة والنمط
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # إضافة نص الفقرة
    $para2->setText("This is numbered bullet");
    # تعيين إزاحة الرصاصة
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// تعيين IsBulletHardColor إلى true لاستخدام لون الرصاصة الخاص

    # تعيين ارتفاع الرصاصة
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

## **إدارة نقاط الصورة**

تساعد القوائم النقطية على تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات المصورة سهلة القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص بالأوتوشيب.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول كائن فقرة باستخدام الفئة [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/).
7. تحميل الصورة في [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/).
8. تعيين نوع الرصاصة إلى [Picture](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bullettype/#Picture) وتعيين الصورة.
9. تعيين `Text` للفقرة.
10. تعيين `Indent` للفقرة للرصاصة.
11. تعيين لون للرصاصة.
12. تعيين ارتفاع للرصاصة.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض التقديمي المعدل.

```php
# إنشاء كائن من فئة Presentation يمثل ملف PPTX
$presentation = new Presentation();
try {
    # الوصول إلى الشريحة الأولى
    $slide = $presentation->getSlides()->get_Item(0);
    # إنشاء الصورة للرصاصات
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
    # الوصول إلى إطار النص الخاص بـ AutoShape
    $textFrame = $autoShape->getTextFrame();
    # إزالة الفقرة الافتراضية
    $textFrame->getParagraphs()->removeAt(0);
    # إنشاء فقرة جديدة
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # تعيين نمط رصاصة الفقرة والصورة
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # تعيين ارتفاع الرصاصة
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

## **إدارة نقاط متعددة المستويات**

تساعد القوائم النقطية على تنظيم وعرض المعلومات بسرعة وكفاءة. النقاط متعددة المستويات سهلة القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص بالأوتوشيب.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول كائن فقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء كائن الفقرة الثاني عبر الفئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء كائن الفقرة الثالث عبر الفئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء كائن الفقرة الرابع عبر الفئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض التقديمي المعدل.

```php
# إنشاء كائن من فئة Presentation يمثل ملف PPTX
$pres = new Presentation();
try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة والوصول إلى AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للـ AutoShape المُنشأ
    $text = $aShp->addTextFrame("");
    # مسح الفقرة الافتراضية
    $text->getParagraphs()->clear();
    # إضافة الفقرة الأولى
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى الرصاصة
    $para1->getParagraphFormat()->setDepth(0);
    # إضافة الفقرة الثانية
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى الرصاصة
    $para2->getParagraphFormat()->setDepth(1);
    # إضافة الفقرة الثالثة
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى الرصاصة
    $para3->getParagraphFormat()->setDepth(2);
    # إضافة الفقرة الرابعة
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # تعيين مستوى الرصاصة
    $para4->getParagraphFormat()->setDepth(3);
    # إضافة الفقرات إلى المجموعة
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # حفظ العرض التقديمي كملف PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **إدارة فقرة مع قائمة مرقمة مخصصة**

توفر الفئة [BulletFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/) الطريقة [setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) وغيرها التي تسمح لك بإدارة الفقرات ذات الترقيم أو التنسيق المخصص.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص بالأوتوشيب.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول كائن فقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) إلى 2.
7. إنشاء كائن الفقرة الثاني عبر الفئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء كائن الفقرة الثالث عبر الفئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض التقديمي المعدل.

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # الوصول إلى إطار النص للـ AutoShape المُنشأ
    $textFrame = $shape->getTextFrame();
    # إزالة الفقرة الافتراضية الموجودة
    $textFrame->getParagraphs()->removeAt(0);
    # القائمة الأولى
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
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

## **ضبط مسافة السطر الأول للفقرة**

استخدم الطريقة [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/setindent/) للتحكم في مسافة السطر الأول للفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة إلى هامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذية إلى جسم الفقرة.

استخدم [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/setmarginleft/) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/setindent/) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مسافة مختلفة لتوضيح كيف تؤثر مسافة السطر الأول على تخطيط الفقرة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [Indent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/setindent/) لكل منها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![مسافة السطر الأول للفقرات](first_line_indent.png)

## **ضبط المسافة المتدلية للفقرة**

المسافة المتدلية هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من بقية الأسطر. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام الطريقة [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/setindent/). عيّن المسافة إلى قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

في الواقع، [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/setmarginleft/) يحدد الموضع الأيسر لجسم الفقرة، و[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/setindent/) يحدد موضع السطر الأول بالنسبة إلى ذلك الهامش. لإنشاء مسافة متدلية، عيّن قيمة `MarginLeft` موجبة وقيمة `Indent` سالبة.

هذا التنسيق مفيد للمراجع، والفهارس، وإدخالات القواميس، وغيرها من الفقرات التي يجب أن تكون الأسطر المغلّفة محاذية تحت جسم الفقرة بدلاً من الحرف الأول للسطر الأول.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. إضافة [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) فارغ إلى الشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتعيين قيمة موجبة لـ [MarginLeft](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/setmarginleft/) لكل فقرة.
6. تعيين قيمة سالبة لـ [Indent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/setindent/) لإنشاء تأثير المسافة المتدلية.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![المسافة المتدلية للفقرات](hanging_indent.png)

## **إدارة خصائص تشغيل نهاية الفقرة**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موضعها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) يحتوي على فقرتين إلى المستطيل.
1. تعيين ارتفاع الخط ونوع الخط للفقرات.
1. تعيين خصائص End للفقرات.
1. كتابة العرض التقديمي المعدل كملف PPTX.

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
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

توفر Aspose.Slides دعمًا محسنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. إضافة والوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص بـ `AutoShape`.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. قراءة ملف HTML المصدر في TextReader.
7. إنشاء أول كائن فقرة عبر الفئة [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء من TextReader إلى [ParagraphCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphcollection/) الخاص بـ TextFrame.
9. حفظ العرض التقديمي المعدل.

```php
# إنشاء مثيل عرض تقديمي فارغ
$pres = new Presentation();
try {
    # الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape لاستيعاب محتوى HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # إضافة إطار نص إلى الشكل
    $ashape->addTextFrame("");
    # مسح جميع الفقرات في إطار النص المضاف
    $ashape->getTextFrame()->getParagraphs()->clear();
    # تحميل ملف HTML باستخدام StreamReader
    $tr = new StreamReader("file.html");
    # إضافة النص من StreamReader للـ HTML إلى إطار النص
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # حفظ العرض التقديمي
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **تصدير نص الفقرة إلى HTML**

توفر Aspose.Slides دعمًا محسنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيُصدّر إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء مثيل من `StreamWriter` وإضافة ملف HTML الجديد.
6. توفير فهرس بدء إلى StreamWriter وتصدير الفقرات المفضلة لديك.

```php
# تحميل ملف العرض التقديمي
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # الفهرس المطلوب
    $index = 0;
    # الوصول إلى الشكل المضاف
    $ashape = $slide->getShapes()->get_Item($index);
    # إنشاء ملف HTML خرج
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # استخراج الفقرة الأولى كـ HTML
    # كتابة بيانات الفقرات إلى HTML بتوفير فهرس بداية الفقرة وإجمالي عدد الفقرات التي سيتم نسخها
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **حفظ فقرة كصورة**

في هذا القسم، نستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بالفئة [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/)، كصورة. يتضمن كلا المثالين الحصول على صورة الشكل الذي يحتوي على الفقرة باستخدام طرق `getImage` من الفئة [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تتيح لك هذه الأساليب استخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، مما قد يكون مفيدًا للاستخدام في سيناريوهات مختلفة.

لنفترض أن لدينا ملف عرض تقديمي اسمه sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض التقديمي ثم نحسب حدود الفقرة الثانية في إطار النص الخاص بالشكل. تُعاد رسم الفقرة على صورة bitmap جديدة، تُحفظ بصيغة PNG. هذه الطريقة مفيدة عندما تحتاج إلى حفظ فقرة معينة كصورة منفصلة مع الحفاظ على الأبعاد وتنسيق النص الدقيق.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // حفظ الشكل في الذاكرة كصورة bitmap.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // إنشاء صورة bitmap للشكل من الذاكرة.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // حساب حدود الفقرة الثانية.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // حساب الإحداثيات والحجم للصورة الناتجة (الحد الأدنى - بكسل واحد × بكسل واحد).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // قص صورة bitmap للشكل للحصول فقط على صورة bitmap للفقرة.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

النتيجة:

![صورة الفقرة](paragraph_to_image_output.png)

**مثال 2**

في هذا المثال، نوسّع النهج السابق بإضافة عوامل مقياس إلى صورة الفقرة. يتم استخراج الشكل من العرض التقديمي وحفظه كصورة بمعامل مقياس `2`. يتيح ذلك إخراجًا بدقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع مراعاة المقياس. يمكن أن يكون المقياس مفيدًا عندما يلزم صورة أكثر تفصيلاً، على سبيل المثال للاستخدام في مواد مطبوعة عالية الجودة.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // حفظ الشكل في الذاكرة كصورة bitmap مع التحجيم.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // إنشاء صورة bitmap للشكل من الذاكرة.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // حساب حدود الفقرة الثانية.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // حساب الإحداثيات والحجم للصورة الناتجة (الحجم الأدنى - بكسل واحد × بكسل واحد).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // قص صورة bitmap للشكل للحصول فقط على صورة bitmap للفقرة.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**هل يمكنني تعطيل التفاف الأسطر داخل إطار النص بالكامل؟**

نعم. استخدم إعداد التفاف إطار النص ([setWrapText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/setwraptext/)) لإيقاف التفاف الأسطر بحيث لا تنكسر عند حواف الإطار.

**كيف يمكنني الحصول على الحدود الدقيقة للفقرة على الشريحة؟**

يمكنك استرداد مستطيل الحدود للفقرة (وحتى لقسم واحد) لمعرفة موقعها وحجمها الدقيق على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يمين/يسار/وسط/مساواة)?**

[Alignment](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/setalignment/) هو إعداد على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/); يطبق على الفقرة بأكملها بغض النظر عن تنسيق الأقسام الفردية.

**هل يمكنني تعيين لغة تدقيق إملائي لجزء فقط من الفقرة (مثل كلمة واحدة)?**

نعم. تُعدّ اللغة على مستوى القسم ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setLanguageId))، لذا يمكن أن تتواجد لغات متعددة داخل فقرة واحدة.