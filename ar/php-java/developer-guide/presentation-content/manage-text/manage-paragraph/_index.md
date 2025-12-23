---
title: إدارة فقرات نص PowerPoint في PHP
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
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إتقان تنسيق الفقرات باستخدام Aspose.Slides لـ PHP عبر Java — تحسين المحاذاة، والمسافات، والأنماط في عروض PPT، PPTX، و ODT."
---

توفر Aspose.Slides جميع الواجهات والفئات التي تحتاجها للعمل مع نصوص PowerPoint والفقرات والأجزاء.

* توفر Aspose.Slides الواجهة [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) التي تسمح لك بإضافة كائنات تمثل فقرة. يمكن لكائن `ITextFame` أن يحتوي على فقرة واحدة أو عدة فقرات (كل فقرة تُنشأ عبر عودة السطر).
* توفر Aspose.Slides الواجهة [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) التي تسمح لك بإضافة كائنات تمثل أجزاء. يمكن لكائن `IParagraph` أن يحتوي على جزء واحد أو عدة أجزاء (مجموعة من كائنات iPortions).
* توفر Aspose.Slides الواجهة [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) التي تسمح لك بإضافة كائنات تمثل نصوصًا وخصائص تنسيقها.

يمكن لكائن `IParagraph` معالجة النصوص ذات خصائص تنسيق مختلفة من خلال كائنات `IPortion` الأساسية الخاصة به.

## **إضافة فقرات متعددة تحتوي على عدة أجزاء**
توضح هذه الخطوات كيفية إضافة إطار نص يحتوي على 3 فقرات، وكل فقرة تحتوي على 3 أجزاء:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرسها.
3. إضافة مستطيل [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة.
4. الحصول على `ITextFrame` المرتبط بـ [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/).
5. إنشاء كائنين من نوع [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) وإضافتهما إلى مجموعة `IParagraphs` الخاصة بـ [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
6. إنشاء ثلاثة كائنات من نوع [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) لكل `IParagraph` جديد (كائنان من نوع Portion للفقرة الافتراضية) وإضافة كل كائن `IPortion` إلى مجموعة IPortion الخاصة بكل `IParagraph`.
7. تعيين بعض النص لكل جزء.
8. تطبيق ميزات التنسيق المفضلة على كل جزء باستخدام خصائص التنسيق التي يوفرها كائن `IPortion`.
9. حفظ العرض التقديمي المعدل.

هذا الكود PHP هو تنفيذ للخطوات الخاصة بإضافة فقرات تحتوي على أجزاء:
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
    # إنشاء فقرات وأقسام (Portions) بتنسيقات نصية مختلفة
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


## **إدارة نقط الفقرة**
تساعد قوائم النقاط في تنظيم وعرض المعلومات بسرعة وكفاءة. الفقرات ذات النقاط تكون دائمًا أسهل في القراءة والفهم.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) الخاص بالشكل التلقائي.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال من الفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. ضبط `Type` النقطية للفقرة إلى `Symbol` وتحديد حرف النقطة.
8. تعيين `Text` للفقرة.
9. ضبط `Indent` الفقرة للنقطة.
10. تحديد لون للنقطة.
11. تعيين ارتفاع للنقطة.
12. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
13. إضافة الفقرة الثانية وتكرار العملية المذكورة في الخطوات 7 إلى 13.
14. حفظ العرض التقديمي.
```php
# ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
$pres = new Presentation();
try {
    # يصل إلى الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # يضيف ويصل إلى Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # يصل إلى إطار النص للـ autoshape
    $txtFrm = $aShp->getTextFrame();
    # يزيل الفقرة الافتراضية
    $txtFrm->getParagraphs()->removeAt(0);
    # ينشئ فقرة
    $para = new Paragraph();
    # يضبط نمط الفقرة النقطية والرمز
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # يضبط نص الفقرة
    $para->setText("Welcome to Aspose.Slides");
    # يضبط إزاحة النقطية
    $para->getParagraphFormat()->setIndent(25);
    # يضبط لون النقطية
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// ضبط IsBulletHardColor إلى true لاستخدام لون النقطية المخصص

    # يضبط ارتفاع النقطية
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # يضيف الفقرة إلى إطار النص
    $txtFrm->getParagraphs()->add($para);
    # ينشئ الفقرة الثانية
    $para2 = new Paragraph();
    # يضبط نوع الفقرة النقطية والنمط
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # يضيف نص الفقرة
    $para2->setText("This is numbered bullet");
    # يضبط إزاحة النقطية
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// ضبط IsBulletHardColor إلى true لاستخدام لون النقطية المخصص

    # يضبط ارتفاع النقطية
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


## **إدارة نقاط الصورة**
تساعد قوائم النقاط في تنظيم وعرض المعلومات بسرعة وكفاءة. فقرات الصورة سهلة القراءة والفهم.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) الخاص بالشكل التلقائي.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال من الفقرة باستخدام فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. تحميل الصورة في [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/).
8. ضبط نوع النقطة إلى [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) وتعيين الصورة.
9. تعيين `Text` للفقرة.
10. ضبط `Indent` للفقرة للنقطة.
11. تحديد لون للنقطة.
12. تعيين ارتفاع للنقطة.
13. إضافة الفقرة الجديدة إلى مجموعة فقرات `TextFrame`.
14. إضافة الفقرة الثانية وتكرار العملية بناءً على الخطوات السابقة.
15. حفظ العرض التقديمي المعدل.
```php
# إنشاء كائن من فئة Presentation يمثل ملف PPTX
$presentation = new Presentation();
try {
    # الوصول إلى الشريحة الأولى
    $slide = $presentation->getSlides()->get_Item(0);
    # إنشاء صورة للنقاط
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
    # الوصول إلى إطار النص الخاص بالـ AutoShape
    $textFrame = $autoShape->getTextFrame();
    # إزالة الفقرة الافتراضية
    $textFrame->getParagraphs()->removeAt(0);
    # إنشاء فقرة جديدة
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # تعيين نمط نقط الفقرة والصورة
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # تعيين ارتفاع النقطة
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


## **إدارة النقاط متعددة المستويات**
تساعد قوائم النقاط في تنظيم وعرض المعلومات بسرعة وكفاءة. النقاط متعددة المستويات سهلة القراءة والفهم.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) في الشريحة الجديدة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) الخاص بالشكل التلقائي.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال من الفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) وتعيين العمق إلى 0.
7. إنشاء الفقرة الثانية عبر فئة `Paragraph` وتعيين العمق إلى 1.
8. إنشاء الفقرة الثالثة عبر فئة `Paragraph` وتعيين العمق إلى 2.
9. إنشاء الفقرة الرابعة عبر فئة `Paragraph` وتعيين العمق إلى 3.
10. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
11. حفظ العرض التقديمي المعدل.
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
    # يضبط مستوى النقطة
    $para1->getParagraphFormat()->setDepth(0);
    # يضيف الفقرة الثانية
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # يضبط مستوى النقطة
    $para2->getParagraphFormat()->setDepth(1);
    # يضيف الفقرة الثالثة
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # يضبط مستوى النقطة
    $para3->getParagraphFormat()->setDepth(2);
    # يضيف الفقرة الرابعة
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # يضبط مستوى النقطة
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


## **إدارة فقرة مع قائمة مرقمة مخصصة**
توفر الواجهة [IBulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/) الخاصية [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) وغيرها التي تسمح لك بإدارة الفقرات مع ترقيم مخصص أو تنسيق.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة التي تحتوي على الفقرة.
3. إضافة [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) الخاص بالشكل التلقائي.
5. إزالة الفقرة الافتراضية في `TextFrame`.
6. إنشاء أول مثال من الفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) وتعيين [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) إلى 2.
7. إنشاء الفقرة الثانية عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 3.
8. إنشاء الفقرة الثالثة عبر فئة `Paragraph` وتعيين `NumberedBulletStartWith` إلى 7.
9. إضافة الفقرات الجديدة إلى مجموعة فقرات `TextFrame`.
10. حفظ العرض التقديمي المعدل.
```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # يصل إلى إطار النص للـ AutoShape المُنشأ
    $textFrame = $shape->getTextFrame();
    # يزيل الفقرة الافتراضية الموجودة
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


## **ضبط إزاحة الفقرة**
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
1. إضافة مستطيل [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) يحتوي على ثلاث فقرات إلى الشكل المستطيل.
1. إخفاء خطوط المستطيل.
1. ضبط الإزاحة لكل [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) عبر خاصية BulletOffset.
1. كتابة العرض التقديمي المعدل كملف PPT.
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
    # ضبط النص ليلائم الشكل
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # إخفاء خطوط المستطيل
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # الحصول على الفقرة الأولى في TextFrame وتعيين إزاحتها
    $para1 = $tf->getParagraphs()->get_Item(0);
    # ضبط نمط نقط الفقرة والرمز
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # الحصول على الفقرة الثانية في TextFrame وتعيين إزاحتها
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # الحصول على الفقرة الثالثة في TextFrame وتعيين إزاحتها
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


## **ضبط إزاحة معلقة لفقرة**
هذا الكود PHP يوضح لك كيفية ضبط الإزاحة المعلقة لفقرة:
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


## **إدارة خصائص تشغيل نهاية الفقرة**
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة التي تحتوي على الفقرة عبر موقعها.
1. إضافة مستطيل [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة.
1. إضافة [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) يحتوي على فقرتين إلى المستطيل.
1. ضبط `FontHeight` ونوع الخط للفقرات.
1. ضبط خصائص End للفقرات.
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
تقدم Aspose.Slides دعمًا محسنًا لاستيراد نص HTML إلى الفقرات.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. إضافة [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) إلى الشريحة.
4. إضافة والوصول إلى `autoshape` [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/).
5. إزالة الفقرة الافتراضية في `ITextFrame`.
6. قراءة ملف HTML المصدر باستخدام TextReader.
7. إنشاء أول مثال من الفقرة عبر فئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
8. إضافة محتوى ملف HTML المقروء من TextReader إلى [ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/) الخاص بـ TextFrame.
9. حفظ العرض التقديمي المعدل.
```php
# إنشاء نسخة فارغة من العرض التقديمي
$pres = new Presentation();
try {
    # الوصول إلى الشريحة الأولى الافتراضية في العرض التقديمي
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة الشكل التلقائي لاستيعاب محتوى HTML
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


## **تصدير نص الفقرة إلى HTML**
توفر Aspose.Slides دعمًا محسنًا لتصدير النصوص (الموجودة في الفقرات) إلى HTML.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى مرجع الشريحة ذات الصلة عبر فهرستها.
3. الوصول إلى الشكل الذي يحتوي على النص الذي سيتم تصديره إلى HTML.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بالشكل.
5. إنشاء مثال من `StreamWriter` وإضافة ملف HTML جديد.
6. توفير فهرس بدء إلى StreamWriter وتصدير الفقرات المفضلة.
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
    # إنشاء ملف HTML للمخرجات
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # استخراج الفقرة الأولى كـ HTML
    # كتابة بيانات الفقرات إلى HTML عبر توفير فهرس بداية الفقرة وإجمالي الفقرات التي سيتم نسخها
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **حفظ الفقرة كصورة**
في هذا القسم، سنستعرض مثالين يوضحان كيفية حفظ فقرة نصية، ممثلة بفئة [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)، كصورة. يتضمن كلا المثالين الحصول على صورة الشكل الذي يحتوي على الفقرة باستخدام طرق `getImage` من فئة [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), حساب حدود الفقرة داخل الشكل، وتصديرها كصورة bitmap. تسمح لك هذه الأساليب باستخراج أجزاء محددة من النص في عروض PowerPoint وحفظها كصور منفصلة، وهو ما قد يكون مفيدًا للاستخدام في سيناريوهات مختلفة.

لنفترض أن لدينا ملف عرض تقديمي يسمى sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![مربع النص مع ثلاث فقرات](paragraph_to_image_input.png)

**مثال 1**

في هذا المثال، نحصل على الفقرة الثانية كصورة. للقيام بذلك، نستخرج صورة الشكل من الشريحة الأولى للعرض التقديمي ثم نحسب حدود الفقرة الثانية في إطار النص الخاص بالشكل. يتم بعد ذلك إعادة رسم الفقرة على صورة bitmap جديدة، تُحفظ بصيغة PNG. هذه الطريقة مفيدة بشكل خاص عندما تحتاج إلى حفظ فقرة معينة كصورة منفصلة مع الحفاظ على الأبعاد الدقيقة وتنسيق النص.
```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // احفظ الشكل في الذاكرة كصورة bitmap.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // إنشاء صورة bitmap للشكل من الذاكرة.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // احسب حدود الفقرة الثانية.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // احسب الإحداثيات والحجم للصورة الناتجة (الحد الأدنى - بكسل واحد 1x1).
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


النتيجة:
![صورة الفقرة](paragraph_to_image_output.png)

**مثال 2**

في هذا المثال، نوسّع النهج السابق بإضافة عوامل تكبير إلى صورة الفقرة. يتم استخراج الشكل من العرض التقديمي وحفظه كصورة مع عامل تكبير `2`. يتيح ذلك إخراجًا بدقة أعلى عند تصدير الفقرة. ثم يتم حساب حدود الفقرة مع مراعاة التكبير. يمكن أن تكون عملية التكبير مفيدة عندما تكون هناك حاجة إلى صورة ذات تفاصيل أكثر، على سبيل المثال للاستخدام في مواد مطبوعة عالية الجودة.
```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // احفظ الشكل في الذاكرة كصورة bitmap مع التحجيم.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // إنشاء صورة bitmap للشكل من الذاكرة.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // احسب حدود الفقرة الثانية.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // احسب الإحداثيات والحجم للصورة الناتجة (الحد الأدنى - بكسل واحد 1x1).
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


## **الأسئلة الشائعة**
**هل يمكنني تعطيل الالتفاف داخل إطار النص بالكامل؟**
نعم. استخدم إعداد الالتفاف لإطار النص ([setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/)) لإيقاف الالتفاف بحيث لا تُقسَّم الأسطر عند حواف الإطار.

**كيف يمكنني الحصول على الحدود الدقيقة للفقرة على الشريحة؟**
يمكنك استرجاع المستطيل المحيط للفقرة (وحتى للجزء الواحد) لمعرفة موقعها وحجمها الدقيق على الشريحة.

**أين يتم التحكم في محاذاة الفقرة (يمين/يسار/وسط/ضبط)؟**
[Alignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) هو إعداد على مستوى الفقرة في [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/); يطبق على الفقرة كاملة بغض النظر عن تنسيق الأجزاء الفردية.

**هل يمكنني تحديد لغة تدقيق إملائي لجزء فقط من الفقرة (مثل كلمة واحدة)؟**
نعم. يتم تعيين اللغة على مستوى الجزء ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)), لذا يمكن أن تتواجد عدة لغات داخل فقرة واحدة.