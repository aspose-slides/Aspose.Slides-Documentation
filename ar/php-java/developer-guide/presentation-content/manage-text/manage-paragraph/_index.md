---
title: إدارة فقرات النص في PowerPoint باستخدام PHP
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
- إدارة الرمز النقطي
- مسافة بادئة الفقرة
- مسافة بادئة معلقة
- رمز الفقرة النقطي
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
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق الفقرات، القطع، الرموز النقطية، القوائم المرقمة، المسافات البادئة، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides لـ PHP عبر Java."
---
## **نظرة عامة**

Aspose.Slides for PHP عبر Java تمثل النص كهرمية من إطارات النص، الفقرات، والقطع:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) يمثل حاوية النص داخل الشكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) يمثل فقرة واحدة داخل إطار النص ويوفر الوصول إلى قطعه وتنسيق الفقرة.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) يمثل مجموعة نص داخل الفقرة. يمكن لكل قطعة أن تحتوي على نصها الخاص وتنسيق مستوى الأحرف.

يمكن للفقرة لذلك أن تحتوي على نص بخطوط، ألوان، أحجام، وتنسيقات أخرى مختلفة باستخدام قطع متعددة.

## **إنشاء وتنسيق الفقرات**

### **إنشاء فقرات مع قطع متعددة**

الخطوات التالية تنشئ إطار نص يحتوي على ثلاث فقرات، كل منها يحتوي على ثلاث قطع:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بالشكل.
5. استخدام الفقرة الافتراضية وإضافة كائنين آخرين من نوع [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) إلى إطار النص.
6. إضافة عدد كافٍ من كائنات [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) لكل فقرة لتحتوي على ثلاث قطع. الفقرة الافتراضية تحتوي بالفعل على قطعة فارغة واحدة.
7. تعيين نص كل قطعة.
8. تطبيق تنسيق مستوى الأحرف عبر [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat--).
9. حفظ العرض التقديمي المعدل.

هذا المثال بلغة PHP يطبق الخطوات:

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

تسهل النقط والترقيم قراءة العناصر المرتبطة. في Aspose.Slides يتم تعريف إعدادات القوائم عبر [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/).

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى الشريحة المختارة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بالشكل.
5. إزالة الفقرة الافتراضية من إطار النص.
6. إنشاء [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) لعلامة نقطية رمزية.
7. تعيين [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) إلى [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/) وتحديد حرف الرمز.
8. تعيين نص الفقرة، والمسافة البادئة، ولون الرمز، وارتفاع الرمز.
9. إضافة الفقرة إلى إطار النص.
10. إنشاء فقرة ثانية وتعيين [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) إلى [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/).
11. تكوين نمط الرمز المرقم وإضافة الفقرة إلى إطار النص.
12. حفظ العرض التقديمي.

هذا المثال بلغة PHP ينشئ رمزًا رمزيًا ورمزًا مرقمًا:

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

### **استخدام رموز صور**

تتيح رموز الصور استخدام صورة مخصصة بدلاً من رمز أو رقم.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المطلوبة عبر فهرسها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) والوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص به.
4. إزالة الفقرة الافتراضية من إطار النص.
5. تحميل صورة الرمز وإضافتها إلى مجموعة صور العرض التقديمي كـ [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).
6. إنشاء [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) وتعيين نصها.
7. تعيين [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) إلى [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/).
8. تعيين الصورة عبر [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture--) وتحديد ارتفاع الرمز.
9. إضافة الفقرة إلى إطار النص.
10. حفظ العرض التقديمي المعدل.

هذا المثال بلغة PHP ينشئ رمز صورة:

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

تعيين [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth-short-) لوضع الفقرات في مستويات مختلفة من القائمة. المستوى الأعلى له عمق `0`.

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) وإزالة الفقرة الافتراضية من إطاره النصي.
3. إنشاء أربع فقرات وتكوين رموزها النقطية.
4. تعيين قيم [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth-short-) الخاصة بها إلى `0`، `1`، `2`، و`3`.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

هذا المثال بلغة PHP ينشئ قائمة نقطية بأربعة مستويات:

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

### **بدء عناصر القائمة المرقمة بقيم مخصصة**

استخدام [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) لتحديد الرقم الأولي المعروض للفقرة المرقمة.

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وإضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) إلى شريحة.
2. حذف الفقرة الافتراضية من إطار النص الخاص بالشكل.
3. إنشاء ثلاث فقرات مرقمة.
4. تعيين [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) إلى `2`، `3`، و`7` للفقرات المعنية.
5. إضافة الفقرات إلى إطار النص وحفظ العرض التقديمي.

هذا المثال بلغة PHP يحدد رقمًا مبدئيًا مخصصًا لكل فقرة:

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

### **تعيين مسافة بادئة للسطر الأول**

استخدام [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) للتحكم في مسافة البادئة للسطر الأول من الفقرة. هذه الطريقة تحرك السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذية إلى جسم الفقرة.

استخدم [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) عندما تحتاج إلى تحريك الفقرة بأكملها. استخدم [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) عندما تحتاج إلى تحريك السطر الأول فقط.

المثال أدناه ينشئ عدة فقرات ويطبق قيم مختلفة لـ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) لتوضيح تأثير مسافة البادئة للسطر الأول على تخطيط الفقرة.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء عدة فقرات وتعيين قيم مختلفة لـ [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) لها.
6. إضافة الفقرات إلى إطار النص.
7. حفظ العرض التقديمي المعدل.

هذا الكود بلغة PHP يوضح كيفية تعيين مسافة بادئة للفقرة:

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

### **تعيين مسافة بادئة معلقة**

المسافة البادئة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من الأسطر المتبقية. في Aspose.Slides يمكنك إنشاء هذا التأثير باستخدام [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-). مرر قيمة سالبة لتحريك السطر الأول إلى اليسار بالنسبة إلى جسم الفقرة.

في الممارسة العملية، يحدد [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) موضع جسم الفقرة الأيسر، ويحدد [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) موضع السطر الأول بالنسبة إلى هذا الهامش. لإنشاء مسافة بادئة معلقة، مرر قيمة موجبة إلى `setMarginLeft` وقيمة سالبة إلى `setIndent`.

هذا التنسيق مفيد للمراجع، القوائم الببليوغرافية، مدخلات القواميس، وغيرها من الفقرات التي يجب أن تكون الأسطر المترافقة محاذية تحت جسم الفقرة بدلاً من تحت أول حرف من السطر الأول.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى الشريحة المستهدفة.
3. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) مستطيل إلى الشريحة.
4. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
5. إنشاء فقرات وتمرير قيمة موجبة إلى [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) لكل فقرة.
6. تمرير قيمة سالبة إلى [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) لإنشاء تأثير المسافة البادئة المعلقة.
7. إضافة الفقرات إلى إطار النص.
8. حفظ العرض التقديمي المعدل.

هذا الكود بلغة PHP يوضح كيفية تعيين مسافة بادئة معلقة لفقرة:

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

### **تعيين خصائص نهاية الفقرة**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) يتحكم في تنسيق علامة نهاية الفقرة. المثال التالي بلغة PHP يعيّن حجم الخط وخط اللاتينية لعلامة النهاية للفقرة الثانية:

1. تحميل [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) والوصول إلى شريحة.
2. إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) وحذف فقرةه الافتراضية.
3. إنشاء فقرتين وإضافة قطع نصية لهما.
4. إنشاء [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) لعلامة نهاية الفقرة الثانية.
5. تعيين [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) و[BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. ربط التنسيق عبر [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) وحفظ العرض التقديمي.

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

لقواعد الفقرات التي تؤثر على الالتفاف التلقائي وعلامات الترقيم في نهايات الأسطر، راجع [Control Line Breaking](/slides/ar/php-java/text-formatting/#control-line-breaking) و[Control Hanging Punctuation](/slides/ar/php-java/text-formatting/#control-hanging-punctuation).

استخدام [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount--) لحساب عدد الأسطر التي يشغلها الفقرة بعد تخطيط النص، بما في ذلك الالتفاف التلقائي. هذا مفيد عند فحص طول النص وتخطيطه في قوالب العروض التقديمية.

الفقرة هي عنصر في [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs--)، ويمكن أن تشغل عدة أسطر مرسومة. كسر السطر الصريح داخل الفقرة يفرض سطرًا جديدًا دون إنشاء فقرة أخرى. الالتفاف التلقائي ينشئ أسطرًا بناءً على العرض المتاح دون إدخال كسر سطر صريح في النص. لذلك، عد الفقرات أو أحرف كسر السطر لا يعطي عدد الأسطر المرسومة.

المثال التالي ينشئ شكل نص، يحسب أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. الالتفاف مفعل والملاءمة التلقائية معطلة بحيث يتحكم عرض الشكل في الالتفاف دون تقليص النص أو تغيير حجم الشكل تلقائيًا. أبعاد الشكل بالنقاط. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص.

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

مع هذا النص وهذه الأبعاد، تضيق الشكل يزيد عدد الأسطر، بينما استبدال النص بالسلسلة القصيرة يقلل العدد. قد تختلف الأعداد الدقيقة حسب توفر الخطوط والاستبدال، حجم الخط، الهوامش، المسافات البادئة، الالتفاف، وإعدادات الملاءمة التلقائية. استخدم الخطوط وإعدادات التخطيط المقصودة للبيئة المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدد ما إذا كان النص سيتجاوز الحاوية. الارتفاع المتاح، ارتفاع الأسطر، تباعد الفقرات والأسطر، وسلوك الملاءمة التلقائية أيضًا مهم؛ حتى سطر واحد يمكن أن يتجاوز العرض المتاح عندما يكون الالتفاف معطلاً.

## **استيراد وتصدير محتوى الفقرة**

### **استيراد نص HTML إلى فقرات**

استخدام [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) لتحويل ترميز HTML إلى فقرات وقطع داخل إطار النص.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. الوصول إلى شريحة وإضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بالشكل وإزالة الفقرة الافتراضية.
4. قراءة ملف HTML المصدر.
5. تمرير سلسلة HTML إلى [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. حفظ العرض التقديمي المعدل.

هذا المثال بلغة PHP يستورد HTML إلى إطار نص:

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

استخدام [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) لتصدير مجموعة محددة من الفقرات كـ HTML.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل العرض التقديمي المطلوب.
2. الوصول إلى الشريحة والعثور على [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) الذي يحتوي على النص.
3. الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الخاص بالشكل.
4. استدعاء [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) مع فهرس الفقرة البداية وعدد الفقرات المراد تصديرها.
5. كتابة سلسلة HTML المرجعة إلى ملف.

هذا المثال بلغة PHP يصدر جميع الفقرات من أول شكل نصي:

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

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--) يعرض فقرة منفردة مباشرةً ويعيد كائنًا من نوع [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/). احفظ النتيجة إلى ملف أو تيار باستخدام [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save-java.lang.String-int-). لا تحتاج إلى عرض الشكل الحاوي أو قص صورة bitmap يدويًا.

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--) قد يعيد `null` إذا لم يتم العثور على الفقرة في مجموعة الأصل، أو لا توجد حدود رسم صالحة، أو لا يمكن عرضها. تحقق من النتيجة قبل حفظها وتخلص من الصورة المرتجعة بعد الاستخدام.

#### **عرض الفقرة بالحجم الافتراضي**

لنفترض أن لدينا ملف عرض تقديمي باسم sample.pptx يحتوي على شريحة واحدة، حيث الشكل الأول هو صندوق نص يحتوي على ثلاث فقرات.

![The text box with three paragraphs](paragraph_to_image_input.png)

المثال التالي بلغة PHP يعرض الفقرة الثانية في شكل نص عادي بالحجم الافتراضي ويحفظ الصورة المرجعة بصيغة PNG. يضمن قسم `finally` تحرير الصورة بشكل صحيح.

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

#### **عرض الفقرة في خلية جدول مع التكبير**

استخدم نسخة [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage-float-float-) التي تقبل المتغيرين `$scaleX` و`$scaleY` لتحديد عوامل التكبير الأفقي والعمودي. المثال التالي بلغة PHP ينشئ جدولًا، يعرض الفقرة في خليةه الأولى بمضاعفة العرض والارتفاع الافتراضيين، ويحفظ النتيجة كصورة PNG.

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

عامل التكبير `1` يحافظ على ذلك المحور بحجمه البكسلي الافتراضي. على سبيل المثال، `2` لكلا العاملين ينتج صورة يصبح عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، مما ينتج أربعة أضعاف عدد البكسلات. العوامل الأكبر عمومًا تنتج نصًا أكثر حدة للتكبير أو الإخراج عالي الدقة، لكنها تزيد أيضًا من استهلاك الذاكرة وحجم الملف. العوامل الأقل من `1` تنتج صورًا أصغر مع تفاصيل أقل. استخدم عوامل متساوية للحفاظ على نسبة العرض إلى الارتفاع للفقرة؛ العوامل الأفقية والعمودية المختلفة تمتد الناتج بشكل مستقل.

عرض شكل كامل باستخدام [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage--) يبقى مفيدًا عندما يجب أن يتضمن الإخراج ملء الشكل، حدوده، أو سياقه البصري الآخر. للحصول على صورة للفقرة فقط، استخدم [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--).

## **الأسئلة الشائعة**

**هل يمكنني تعطيل التفاف السطر بالكامل داخل إطار النص؟**

نعم. تعيين [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText-byte-) إلى تعطيل الالتفاف سيمنع كسر الأسطر عند حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة على الشريحة بدقة؟**

استخدم [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect--) لاسترجاع مستطيل الحدود الخاص بالفقرة. [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect--) يوفر حدود القطعة الفردية.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط أو توسيط)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment-int-) هو إعداد على مستوى الفقرة ويطبق على الفقرة بأكملها بغض النظر عن تنسيق القطع الفردية.

للمحاذاة العمودية للقطع ذات الأحجام الخطية المختلفة داخل كل سطر، انظر [Align Fonts Within a Line](/slides/ar/php-java/text-formatting/#align-fonts-within-a-line).

**هل يمكنني تعيين لغة التدقيق لجزء من الفقرة؟**

نعم. تعيين [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) للقطع الفردية، بحيث يمكن لفقرة واحدة أن تحتوي على نص بعدة لغات.