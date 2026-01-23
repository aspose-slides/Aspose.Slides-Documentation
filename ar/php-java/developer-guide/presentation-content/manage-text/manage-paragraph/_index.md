---
title: إدارة فقرات النص في PowerPoint باستخدام PHP
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/php-java/manage-paragraph/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة النقاط
- إزاحة الفقرة
- إزاحة معلقة
- نقطة الفقرة
- قائمة مرقمة
- قائمة نقطية
- خصائص الفقرة
- استيراد HTML
- تحويل النص إلى HTML
- تحويل الفقرة إلى HTML
- تحويل الفقرة إلى صورة
- تحويل النص إلى صورة
- تصدير الفقرة
- PowerPoint
- OpenDocument
- العرض التقديمي
- PHP
- Aspose.Slides
description: "إتقان تنسيق الفقرات مع Aspose.Slides للـ PHP عبر Java — تحسين المحاذاة والتباعد والنمط في عروض PPT و PPTX و ODP."
---

Aspose.Slides تقدم جميع الفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء.

* Aspose.Slides توفر الفئة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) للسماح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `TextFame` أن يحتوي على فقرة واحدة أو عدة فقرات (كل فقرة تُنشأ عبر عودة سطر).
* Aspose.Slides توفر الفئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) للسماح لك بإضافة كائنات تمثل أجزاء. يمكن لكائن `Paragraph` أن يحتوي على جزء واحد أو عدة أجزاء (مجموعة من كائنات الجزء).
* Aspose.Slides توفر الفئة [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) للسماح لك بإضافة كائنات تمثل نصوصًا وخصائص تنسيقها.

كائن `Paragraph` قادر على معالجة النصوص ذات خصائص تنسيق مختلفة عبر كائنات `Portion` الأساسية الخاصة به.

## **Add Multiple Paragraphs Containing Multiple Portions**

توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الحصول على ITextFrame المرتبط بـ [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
5. إنشاء كائنين من الفئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) وإضافتهما إلى مجموعة الفقرات في [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
6. إنشاء ثلاثة كائنات من الفئة [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) لكل `Paragraph` جديد (جزأين للفقرة الافتراضية) وإضافة كل كائن `Portion` إلى مجموعة الأجزاء الخاصة بكل `Paragraph`.
7. تعيين بعض النص لكل جزء.
8. تطبيق ميزات التنسيق المفضلة على كل جزء باستخدام خصائص التنسيق التي توفرها كائن `Portion`.
9. حفظ العرض التقديمي المعدل.

هذا الكود PHP هو تنفيذ للخطوات لإضافة فقرات تحتوي على أجزاء:
```php
# إنشاء كائن من فئة Presentation يمثل ملف PPTX
$pres = new Presentation();
try {
    # الوصول إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape من نوع Rectangle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # الوصول إلى TextFrame الخاص بـ AutoShape
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
    # حفظ ملف PPTX على القرص
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```



## **Manage Paragraph Bullets**

قوائم الرصاص تساعدك على تنظيم وتقديم المعلومات بسرعة وكفاءة. الفقرات ذات الرصاص دائمًا أسهل في القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. تعيين `Type` للرصاص للفقرة إلى `Symbol` وتعيين حرف الرصاص.
8. تعيين `Text` للفقرة.
9. تعيين `Indent` للفقرة للرصاص.
10. تعيين لون للرصاص.
11. تعيين ارتفاع للرصاص.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات 7 إلى 13.
14. حفظ العرض التقديمي.

هذا الكود PHP يوضح كيفية إضافة رصاص فقرة:
```php
# ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
$pres = new Presentation();
try {
    # يصل إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # يضيف ويصل إلى AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # يصل إلى إطار النص للـ AutoShape
    $txtFrm = $aShp->getTextFrame();
    # يزيل الفقرة الافتراضية
    $txtFrm->getParagraphs()->removeAt(0);
    # ينشئ فقرة
    $para = new Paragraph();
    # يضبط نمط الرصاصة للفقرة والرمز
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # يضبط نص الفقرة
    $para->setText("Welcome to Aspose.Slides");
    # يضبط إزاحة الرصاصة
    $para->getParagraphFormat()->setIndent(25);
    # يضبط لون الرصاصة
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// ضبط IsBulletHardColor إلى true لاستخدام لون رصاص مخصص

    # يضبط ارتفاع الرصاصة
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # يضيف الفقرة إلى إطار النص
    $txtFrm->getParagraphs()->add($para);
    # ينشئ الفقرة الثانية
    $para2 = new Paragraph();
    # يضبط نوع الرصاصة للفقرة والنمط
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # يضيف نص الفقرة
    $para2->setText("This is numbered bullet");
    # يضبط إزاحة الرصاصة
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// ضبط IsBulletHardColor إلى true لاستخدام لون رصاص مخصص

    # يضبط ارتفاع الرصاصة
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # يضيف الفقرة إلى إطار النص
    $txtFrm->getParagraphs()->add($para2);
    # يحفظ العرض التقديمي المعدل
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```



## **Manage Picture Bullets**

قوائم الرصاص تساعدك على تنظيم وتقديم المعلومات بسرعة وكفاءة. فقرات الصور سهلة القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. تحميل الصورة في [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).
8. تعيين نوع الرصاص إلى [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) وتعيين الصورة.
9. تعيين `Text` للفقرة.
10. تعيين `Indent` للفقرة للرصاص.
11. تعيين لون للرصاص.
12. تعيين ارتفاع للرصاص.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض التقديمي المعدل.

هذا الكود PHP يوضح كيفية إضافة وإدارة رصاص الصور:
```php
# ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
$presentation = new Presentation();
try {
    # يصل إلى الشريحة الأولى
    $slide = $presentation->getSlides()->get_Item(0);
    # ينشئ الصورة للرصاصات
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # يضيف ويصل إلى AutoShape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # يصل إلى إطار النص الخاص بالـ AutoShape
    $textFrame = $autoShape->getTextFrame();
    # يزيل الفقرة الافتراضية
    $textFrame->getParagraphs()->removeAt(0);
    # ينشئ فقرة جديدة
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # يضبط نمط رصاصة الفقرة والصورة
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # يضبط ارتفاع الرصاصة
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # يضيف الفقرة إلى إطار النص
    $textFrame->getParagraphs()->add($paragraph);
    # يحفظ العرض التقديمي كملف PPTX
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # يحفظ العرض التقديمي كملف PPT
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```



## **Manage Multilevel Bullets**

قوائم الرصاص تساعدك على تنظيم وتقديم المعلومات بسرعة وكفاءة. رصاص المستويات المتعددة سهل القراءة والفهم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء مثال الفقرة الثاني عبر فئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء مثال الفقرة الثالث عبر فئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء مثال الفقرة الرابع عبر فئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض التقديمي المعدل.

هذا الكود PHP يوضح كيفية إضافة وإدارة رصاص متعدد المستويات:
```php
# ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
$pres = new Presentation();
try {
    # يصل إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # يضيف ويصل إلى AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # يصل إلى إطار النص للـ AutoShape المنشأ
    $text = $aShp->addTextFrame("");
    # يمسح الفقرة الافتراضية
    $text->getParagraphs()->clear();
    # يضيف الفقرة الأولى
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # يضبط مستوى الرصاصة
    $para1->getParagraphFormat()->setDepth(0);
    # يضيف الفقرة الثانية
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # يضبط مستوى الرصاصة
    $para2->getParagraphFormat()->setDepth(1);
    # يضيف الفقرة الثالثة
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # يضبط مستوى الرصاصة
    $para3->getParagraphFormat()->setDepth(2);
    # يضيف الفقرة الرابعة
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # يضبط مستوى الرصاصة
    $para4->getParagraphFormat()->setDepth(3);
    # يضيف الفقرات إلى المجموعة
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # يحفظ العرض التقديمي كملف PPTX
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```



## **Manage a Paragraph with a Custom Numbered List**

توفر فئة [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) الطريقة [setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) وغيرها التي تتيح لك إدارة الفقرات بقوائم مرقمة مخصصة أو تنسيق مخصص.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) إلى 2.
7. إنشاء مثال الفقرة الثاني عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء مثال الفقرة الثالث عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض التقديمي المعدل.

هذا الكود PHP يوضح كيفية إضافة وإدارة الفقرات بقوائم مرقمة مخصصة أو تنسيق مخصص:
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



## **Set Paragraph Indent**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) يحتوي على ثلاث فقرات إلى الشكل المستطيل.
1. إخفاء خطوط المستطيل.
1. تعيين المسافة البادئة لكل [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) عبر خاصية BulletOffset الخاصة بها.
1. كتابة العرض التقديمي المعدل كملف PPT.

هذا الكود PHP يوضح كيفية تعيين مسافة بادئة للفقرة:
```php
# إنشاء كائن من فئة Presentation
$pres = new Presentation();
try {
    # الحصول على الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إضافة شكل مستطيل
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # إضافة TextFrame إلى المستطيل
    $tf = $rect->addTextFrame("This is first line \rThis is second line \rThis is third line");
    # ضبط النص ليتناسب مع الشكل
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # إخفاء خطوط المستطيل
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # الحصول على الفقرة الأولى في TextFrame وضبط الإزاحة
    $para1 = $tf->getParagraphs()->get_Item(0);
    # ضبط نمط رصاصة الفقرة والرمز
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # الحصول على الفقرة الثانية في TextFrame وضبط الإزاحة
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # الحصول على الفقرة الثالثة في TextFrame وضبط الإزاحة
    $para3 = $tf->getParagraphs()->get_Item(2);
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para3->getParagraphFormat()->setDepth(2);
    $para3->getParagraphFormat()->setIndent(50);
    # حفظ العرض التقديمي إلى القرص
    $pres->save("InOutDent_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Set Hanging Indent for a Paragraph**

هذا الكود PHP يوضح كيفية تعيين المسافة البادئة المتدلية لفقرة:
```php
$pres = new Presentation();
try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("Example");
    $para2 = new Paragraph();
    $para2->setText("Set Hanging Indent for Paragraph");
    $para3 = new Paragraph();
    $para3->setText("This code shows you how to set the hanging indent for a paragraph: ");
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


## **Manage End Paragraph Run Properties**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موضعها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) يحتوي على فقرتين إلى المستطيل.
1. تعيين ارتفاع الخط ونوع الخط للفقرات.
1. تعيين خصائص End للفقرات.
1. كتابة العرض التقديمي المعدل كملف PPTX.

هذا الكود PHP يوضح كيفية تعيين خصائص End للفقرات في PowerPoint:
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



## **Import HTML Text into Paragraphs**

توفر Aspose.Slides دعمًا محسنًا لاستيراد نصوص HTML إلى الفقرات.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة.
4. إضافة والوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بـ `AutoShape`.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. قراءة ملف HTML المصدر في TextReader.
7. إنشاء أول مثال للفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء في TextReader إلى [ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/) الخاص بـ TextFrame.
9. حفظ العرض التقديمي المعدل.

هذا الكود PHP هو تنفيذ للخطوات لاستيراد نصوص HTML إلى الفقرات:
```php
# إنشاء كائن عرض تقديمي فارغ
$pres = new Presentation();
try {
    # الوصول إلى الشريحة الأولى الافتراضية للعرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة AutoShape لاستيعاب محتوى HTML
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # إضافة إطار نص إلى الشكل
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



## **Export Paragraph Text to HTML**

توفر Aspose.Slides دعمًا محسنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيُصدر إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء مثيل من `StreamWriter` وإضافة ملف HTML جديد.
6. توفير فهرس بدء لـ StreamWriter وتصدير الفقرات المفضلة لديك.

هذا الكود PHP يوضح كيفية تصدير نصوص فقرات PowerPoint إلى HTML:
```php
# تحميل ملف العرض التقديمي
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # الوصول إلى الشريحة الأولى الافتراضية للعرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # الفهرس المطلوب
    $index = 0;
    # الوصول إلى الشكل الم-added
    $ashape = $slide->getShapes()->get_Item($index);
    # إنشاء ملف HTML الناتج
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # استخراج الفقرة الأولى كملف HTML
    # كتابة بيانات الفقرات إلى HTML بتحديد فهرس بدء الفقرة وإجمالي عدد الفقرات التي سيتم نسخها
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Save a Paragraph as an Image**

في هذا القسم، سنستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بفئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)، كصورة. يتضمن كلا المثالين الحصول على صورة الشكل الذي يحتوي الفقرة باستخدام طرق `getImage` من فئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)، حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تتيح هذه الأساليب استخراج أجزاء محددة من النص من عروض PowerPoint وحفظها كصور منفصلة، مما قد يكون مفيدًا لاستخدامها لاحقًا في سيناريوهات مختلفة.

لنفترض أن لدينا ملف عرض تقديمي يُدعى sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض التقديمي ثم نحسب حدود الفقرة الثانية في إطار النص الخاص بالشكل. يتم بعد ذلك إعادة رسم الفقرة على صورة bitmap جديدة، تُحفظ بصيغة PNG. هذه الطريقة مفيدة بشكل خاص عندما تحتاج إلى حفظ فقرة معينة كصورة منفصلة مع الحفاظ على الأبعاد والتنسيق الدقيق للنص.
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

    // حساب الإحداثيات والحجم للصورة الناتجة (الحد الأدنى - بكسل 1x1).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // قص صورة bitmap للشكل للحصول على صورة bitmap للفقرة فقط.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


الناتج:

![The paragraph image](paragraph_to_image_output.png)

**Example 2**

في هذا المثال، نُوسِّع النهج السابق بإضافة عوامل مقياس إلى صورة الفقرة. يتم استخراج الشكل من العرض التقديمي وحفظه كصورة بعامل مقياس `2`. يتيح ذلك إخراجًا بدقة أعلى عند تصدير الفقرة. ثم تُحسب حدود الفقرة مع الأخذ في الاعتبار المقياس. يمكن أن يكون المقياس مفيدًا عندما يلزم صورة أكثر تفصيلًا، على سبيل المثال للاستخدام في مواد مطبوعة عالية الجودة.
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

    // حساب الإحداثيات والحجم للصورة الناتجة (الحد الأدنى - 1×1 بكسل).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // قص صورة bitmap للشكل للحصول على صورة bitmap للفقرة فقط.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **FAQ**

**Can I completely disable line wrapping inside a text frame?**

نعم. استخدم إعداد التفاف إطار النص ([setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/)) لإيقاف التفاف الأسطر بحيث لا تنكسر عند حواف الإطار.

**How can I get the exact on-slide bounds of a specific paragraph?**

يمكنك استرداد المستطيل المحيط بالفقرة (بل وحتى الجزء الفردي) لمعرفة موقعها وحجمها الدقيق على الشريحة.

**Where is paragraph alignment (left/right/center/justify) controlled?**

[Alignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) هو إعداد على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/); ينطبق على الفقرة بأكملها بغض النظر عن تنسيق الأجزاء الفردية.

**Can I set a spell-check language for just part of a paragraph (e.g., one word)?**

نعم. اللغة تُحدد على مستوى الجزء ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId))، وبالتالي يمكن أن تت co-exist عدة لغات داخل فقرة واحدة.