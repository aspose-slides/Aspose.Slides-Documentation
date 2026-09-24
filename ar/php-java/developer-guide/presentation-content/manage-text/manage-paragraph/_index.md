---
title: إدارة فقرات نص PowerPoint في PHP
linktitle: إدارة الفقرة
type: docs
weight: 40
url: /ar/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- إضافة نص
- إضافة فقرة
- إدارة النص
- إدارة الفقرة
- إدارة النقطة
- مسافة الفقرة
- مسافة معلقة
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
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق الفقرات والجزءات والنقاط والقوائم المرقمة والمسافات ومحتوى HTML وصور الفقرات باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

يمثل Aspose.Slides for PHP عبر Java النص على شكل تسلسل هرمي من إطارات النص والفقرات والجزءات:

* [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) يمثل حاوية النص داخل الشكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/) يمثل فقرة واحدة في إطار النص ويوفر الوصول إلى الجزءات وتنسيق الفقرة.
* [Portion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/) يمثل نصًا داخل فقرة. يمكن لكل جزء أن يملك نصه وتنسيق الأحرف الخاص به.

يمكن للفقرة بالتالي احتواء نص بخطوط وألوان وأحجام وتنسيقات أخرى مختلفة باستخدام جزءات متعددة.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات مع جزءات متعددة**

الخطوات التالية تنشئ إطار نص يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاث جزءات:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة ذات الصلة عبر فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة كائنين آخرين من نوع [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/) إلى إطار النص.
6. إضافة ما يكفي من كائنات [Portion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/) لكل فقرة لتحتوي على ثلاث جزءات. الفقرة الافتراضية تحتوي بالفعل على جزء واحد فارغ.
7. ضبط نص كل جزء.
8. تطبيق تنسيق على مستوى الأحرف من خلال [Portion::getPortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/#getPortionFormat--).
9. حفظ العرض التقديمي المعدل.

يطبق مثال PHP الخطوات التالية:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **إنشاء قوائم نقطية ومرقمة**

### **إنشاء قائمة نقطية أو مرقمة**

تجعل النقاط والترقيم العناصر المرتبطة أسهل للقراءة. في Aspose.Slides، يتم تعريف إعدادات القوائم عبر [BulletFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/).

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة ذات الصلة عبر فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى الشريحة المحددة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/) للنقطة الرمزية.
7. ضبط [BulletFormat::setType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#setType-int-) على [BulletType::Symbol](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bullettype/) وتحديد حرف النقطة.
8. ضبط نص الفقرة، والمسافة البادئة، ولون النقطة، وارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وضبط [BulletFormat::setType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#setType-int-) على [BulletType::Numbered](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bullettype/).
11. تكوين نمط النقطة المرقمة وإضافة الفقرة إلى إطار النص.
12. حفظ العرض التقديمي.

ينشئ مثال PHP التالي نقطة رمزية ونقطة مرقمة:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **استخدام نقاط صورة**

تتيح لك نقاط الصورة استخدام صورة مخصصة بدلًا من رمز أو رقم.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة ذات الصلة عبر فهرستها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) والوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص به.
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة النقطة وإضافتها إلى مجموعة الصور في العرض التقديمي كـ [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/) وضبط نصه.
7. ضبط [BulletFormat::setType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#setType-int-) على [BulletType::Picture](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bullettype/).
8. تعيين الصورة عبر [BulletFormat::getPicture](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#getPicture--) وضبط ارتفاع النقطة.
9. إضافة الفقرة إلى إطار النص.
10. حفظ العرض التقديمي المعدل.

ينشئ مثال PHP التالي نقطة صورة:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **إنشاء قائمة متعددة المستويات**

ضبط [ParagraphFormat::setDepth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setDepth-short-) لتحديد مستوى الفقرات في القائمة. المستوى العلوي له عمق `0`.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) ومسح الفقرة الافتراضية من إطار النص الخاص به.
3. إنشاء أربع فقرات وتكوين رموز النقاط الخاصة بها.
4. ضبط قيم [ParagraphFormat::setDepth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setDepth-short-) إلى `0` و`1` و`2` و`3`.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

ينشئ مثال PHP التالي قائمة نقطية بأربع مستويات:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **بدء ترقيم العناصر بقيم مخصصة**

استخدم [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) لتحديد الرقم الأولي الذي يُعرض للفقرة المرقمة.

1. إنشاء [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) وإضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) إلى شريحة.
2. مسح الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات مرقمة.
4. ضبط [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) إلى `2` و`3` و`7` للفقرات المقابلة.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

يعين مثال PHP التالي رقمًا مبدئيًا مخصصًا لكل فقرة:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **التحكم في تخطيط الفقرة وخصائص النهاية**

### **ضبط مسافة أول سطر**

استخدم [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setIndent-float-) للتحكم في مسافة أول سطر للفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة إلى الهامش الأيسر للفقرة. القيمة الموجبة تُحرك السطر الأول إلى اليمين، بينما تبقى السطور المتبقية مُحاذاة مع جسم الفقرة.

استخدم [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setIndent-float-) عندما تحتاج إلى تحريك السطر الأول فقط.

يوضح المثال أدناه إنشاء عدة فقرات وتطبيق قيم مختلفة من [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setIndent-float-) لتوضيح تأثير مسافة أول سطر على تخطيط الفقرة.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة الهدف.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص بالشكل ومسح الفقرة الافتراضية.
5. إنشاء عدة فقرات وضبط قيم مختلفة من [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setIndent-float-) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

يعرض مثال PHP التالي كيفية ضبط مسافة الفقرة:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
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

![The first-line indent of the paragraphs](first_line_indent.png)

### **ضبط مسافة معلقة**

المسافة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من باقي السطور. في Aspose.Slides، يمكنك إنشاء هذا التأثير باستخدام [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setIndent-float-). مرّر قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

عمليًا، يحدد [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) الموضع الأيسر لجسم الفقرة، وتحدد [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setIndent-float-) موضع السطر الأول بالنسبة إلى ذلك الهامش. لإنشاء مسافة معلقة، مرّر قيمة موجبة إلى `setMarginLeft` وقيمة سالبة إلى `setIndent`.

هذا التنسيق مفيد للمراجع، والهوامش، ومدخلات القاموس، وغيرها من الفقرات التي يجب أن تكون السطور المتداخلة محاذية تحت جسم الفقرة بدلًا من تحت الحرف الأول للسطر الأول.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة الهدف.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص بالشكل ومسح الفقرة الافتراضية.
5. إنشاء فقرات وتمرير قيمة موجبة إلى [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) لكل فقرة.
6. تمرير قيمة سالبة إلى [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setIndent-float-) لإنشاء تأثير المسافة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

يعرض مثال PHP التالي كيفية ضبط مسافة معلقة لفقرة:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
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

![The hanging indent of the paragraphs](hanging_indent.png)

### **ضبط خصائص نهاية الفقرة**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) يتحكم في تنسيق علامة نهاية الفقرة. المثال التالي بلغة PHP يعيّن حجم خط وخط لاتيني لعلامة النهاية للفقرة الثانية:

1. تحميل [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) ومسح الفقرة الافتراضية.
3. إنشاء فقرتين وإضافة جزءات نصية لهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. ضبط [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) و[BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. إسناد التنسيق باستخدام [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) وحفظ العرض التقديمي.

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **عدد الأسطر المرسومة**

استخدم [Paragraph::getLinesCount](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/#getLinesCount--) لحساب عدد الأسطر التي يشغلها پاراغراف بعد تخطيط النص، بما في ذلك الالتفاف التلقائي. هذا مفيد عند فحص طول النص وتخطيطه في قوالب العروض التقديمية.

الفقرة هي عنصر واحد في [TextFrame::getParagraphs](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParagraphs--)، ويمكن أن تشغل عدة أسطر مرسومة. كسر السطر الصريح داخل الفقرة يُنشئ سطرًا جديدًا دون إنشاء فقرة أخرى. الالتفاف التلقائي يخلق أسطرًا بناءً على العرض المتاح دون إدراج كسر سطر صريح في النص. لذلك لا يعطي عدّ الفقرات أو أحرف كسر السطر عدد الأسطر المرسومة.

المثال التالي ينشئ شكل نص، يعدد أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. يتم تمكين الالتفاف وتعطيل الضبط التلقائي بحيث يتحكم عرض الشكل في الالتفاف دون تصغير النص أو تغيير أبعاد الشكل تلقائيًا. أبعاد الشكل تُقاس بالنقطة. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص.

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

بهذا النص وهذه الأبعاد، يزيد تضييق الشكل من عدد الأسطر، بينما يقلل استبدال النص بالسلسلة القصيرة العدد. قد تختلف الأعداد الدقيقة حسب توفر الخطوط والاستبدال، وحجم الخط، والهامش، والمسافات، والالتفاف، وإعدادات الضبط التلقائي. استخدم الخطوط وإعدادات التخطيط المقصودة للبيئة المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدد ما إذا كان النص يتجاوز حاويته. الارتفاع المتاح، وارتفاع الأسطر، وتباعد الفقرات والأسطر، وسلوك الضبط التلقائي كلها مهمة؛ حتى سطر واحد يمكن أن يتجاوز العرض المتاح عندما يكون الالتفاف معطلاً.

## **استيراد وتصدير محتوى الفقرة**

### **استيراد نص HTML إلى الفقرات**

استخدم [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) لتحويل ترميز HTML إلى فقرات وجزءات في إطار نص.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).
2. الوصول إلى شريحة وإضافة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/).
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص بالشكل ومسح الفقرة الافتراضية.
4. قراءة ملف HTML المصدر.
5. تمرير سلسلة HTML إلى [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. حفظ العرض التقديمي المعدل.

يستورد مثال PHP التالي HTML إلى إطار النص:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **تصدير نص الفقرة إلى HTML**

استخدم [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) لتصدير نطاق محدد من الفقرات كـ HTML.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى الشريحة وإيجاد [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) الذي يحتوي على النص.
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الخاص بالشكل.
4. استدعاء [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) مع مؤشر الفقرة الابتدائي وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المستلمة إلى ملف.

يصدر مثال PHP التالي جميع الفقرات من أول شكل نص:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **عرض الفقرة كصورة**

[Paragraph::getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/#getImage--) يرسم فقرة فردية مباشرة ويعيد كائنًا من نوع [IImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/). احفظ النتيجة في ملف أو تدفق باستخدام [IImage::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/iimage/#save-java.lang.String-int-). لا تحتاج إلى رسم الشكل الحاوي أو قص الصورة يدويًا.

[Paragraph::getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/#getImage--) يمكن أن يُعيد `null` إذا لم تُعثر على الفقرة في مجموعتها الأصلية، أو لا توجد حدود رسم صالحة، أو لا يمكن رسمها. تحقق من النتيجة قبل حفظها وتخلص من الصورة المرجعة بعد الاستخدام.

#### **عرض الفقرة بالمقياس الافتراضي**

لنفترض أن لدينا ملف عرض تقديمي يدعى `sample.pptx` به شريحة واحدة، حيث الشكل الأول هو مربع نص يحتوي على ثلاث فقرات.

![The text box with three paragraphs](paragraph_to_image_input.png)

يقوم مثال PHP التالي بعرض الفقرة الثانية في شكل نص عادي بالمقياس الافتراضي ويحفظ الصورة المرجعة بصيغة PNG. يضمن قسم `finally` تحرير الصورة بشكل صحيح.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

النتيجة:

![The paragraph image](paragraph_to_image_output.png)

#### **عرض الفقرة في خلية جدول مع تحجيم**

استخدم نسخة [Paragraph::getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/#getImage-float-float-) التي تقبل معلمتي `$scaleX` و`$scaleY` لتعيين عوامل التحجيم الأفقي والعمودي. مثال PHP التالي ينشئ جدولًا، يعرض الفقرة في خليةه الأولى بمضاعفة العرض والارتفاع الافتراضيين، ويحفظ النتيجة كصورة PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

عامل التحجيم `1` يحافظ على ذلك المحور بحجمه البكسلي الافتراضي. على سبيل المثال، `2` لكلا العاملين يُنتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، أي أربعة أضعاف عدد البكسلات. العوامل الأكبر عمومًا تُنتج نصًا أوضح للتكبير أو للإخراج عالي الدقة، لكنها تُزيد من استهلاك الذاكرة وحجم الملف. العوامل الأقل من `1` تُنتج صورًا أصغر بحدة أقل. استخدم عوامل متساوية للحفاظ على نسبة أبعاد الفقرة؛ العوامل الأفقية والعمودية المختلفة تُمدّد الناتج بشكل مستقل.

لا يزال رسم الشكل بالكامل باستخدام [Shape::getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/#getImage--) مفيدًا عندما يجب أن يتضمن الإخراج ملء الشكل أو حدوده أو سياقًا بصريًا آخر. للصور التي تحتوي الفقرة فقط، استخدم [Paragraph::getImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/#getImage--).

## **الأسئلة الشائعة**

**هل يمكنني تعطيل التفاف السطر بالكامل داخل إطار النص؟**

نعم. اضبط [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setWrapText-byte-) لتعطيل الالتفاف بحيث لا تنكسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة الدقيقة داخل الشريحة؟**

استخدم [Paragraph::getRect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/#getRect--) لاسترداد المستطيل الحدودي للفقرة. يقدّم [Portion::getRect](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/#getRect--) حدود الجزء الفردي.

**أين يتم التحكم في محاذاة الفقرة (اليسار أو اليمين أو الوسط أو الضبط التساوي)؟**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setAlignment-int-) هو إعداد على مستوى الفقرة ويُطبق على الفقرة بأكملها بغض النظر عن تنسيق الجزء الفردي.

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. اضبط [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) للجزءات الفردية، بحيث يمكن لفقرة واحدة أن تحتوي نصًا بأكثر من لغة.