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
- إدارة نص
- إدارة فقرة
- إدارة نقط
- إزاحة الفقرة
- إزاحة معلقة
- نقط الفقرة
- قائمة مرقمة
- قائمة منقطة
- خصائص الفقرة
- استيراد HTML
- نص إلى HTML
- فقرة إلى HTML
- فقرة إلى صورة
- نص إلى صورة
- تصدير فقرة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إنشاء وتنسيق الفقرات، القطع، النقط، القوائم المرقمة، الإزاحات، محتوى HTML، وصور الفقرات باستخدام Aspose.Slides for PHP via Java."
---
## **نظرة عامة**

يمثل Aspose.Slides for PHP via Java النص كهرمية من إطارات النص والفقرات والقطع:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) يمثل حاوية النص داخل الشكل ويوفر الوصول إلى مجموعة الفقرات الخاصة به.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) يمثل فقرة واحدة في إطار النص ويوفر الوصول إلى قطعه وتنسيق مستوى الفقرة.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) يمثل تشغيل نص داخل فقرة. يمكن لكل قطعة أن تحتوي على نصها وتنسيق مستوى الحرف الخاص بها.

وبالتالي يمكن للفقرة أن تحتوي على نص بخطوط وألوان وأحجام وتنسيقات أخرى باستخدام قطع متعددة.

## **إنشاء وتنسيق الفقرات**

إنشاء فقرات في إطار النص الخاص بالشكل واستخدام القطع لتنسيق تشغيلات النص الفردية. يوضح هذا القسم كيفية دمج قطع متعددة داخل كل فقرة وتطبيق ألوان وأحجام خطوط وأنماط مختلفة.

### **إنشاء فقرات مع قطع متعددة**

يقوم المثال التالي بلغة PHP بإنشاء ثلاث فقرات، كل منها يحتوي على ثلاث تشغيلات نص في المجموعة التي تُرجعها [Paragraph::getPortions](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getPortions). يعيد استخدام الفقرة الافتراضية وقطعتها الفارغة، ثم يضيف الفقرات والقطع المتبقية. يتم تطبيق التنسيق عبر [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat): تكون القطعة الأولى في كل فقرة حمراء، غامقة، بحجم 15 نقطة؛ والثانية زرقاء، مائلة، بحجم 18 نقطة. تحافظ القطعة الثالثة على تنسيقها الافتراضي:

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

تنظيم نص الفقرة في قوائم باستخدام رموز أو أرقام أو صور مخصصة. تغطي الأمثلة في هذا القسم تنسيق الرموز النقطية، القوائم متعددة المستويات، وتحديد أرقام البدء المخصصة.

### **إنشاء قائمة نقطية أو مرقمة**

تسهل الرموز النقطية والترقيم مسح العناصر المرتبطة. في Aspose.Slides يتم تعريف إعدادات القائمة عبر [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/).

يضيف المثال التالي بلغة PHP رمزا نقطيًا وبندًا مرقمًا إلى نفس إطار النص. يختار [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) نوع الرمز، بينما يزود [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) الرمز و[BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) نمط الترقيم. يستخدم العنصران رموزًا سوداء بارتفاع 100 ٪ ومسافة إزاحة فقرة 25 نقطة:

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

### **استخدام رموز نقطية بصورة**

تتيح الرموز النقطية باستخدام صورة مخصصة بدلاً من رمز أو رقم.

يضيف المثال التالي بلغة PHP صورةً إلى مجموعة صور العرض كـ [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) ويستخدمها كرمز فقرة. يستدعي [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) لاستخدام رمز صورة ويعين الصورة عبر [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture). يتم ضبط [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) على 100 ٪ لتحديد حجم الرمز نسبةً إلى نص الفقرة:

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

ضع [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) لتحديد مستويات الفقرات في القائمة. المستوى العلوي له عمق `0`.

يعين المثال التالي بلغة PHP قيم [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) من 0 إلى 3 لأربع فقرات، مُنشئًا هرمًا داخل إطار نص واحد. تستخدم كل فقرة رمزًا نقطيًا، ويتناوب [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar) بين رمز دائري وشرطة لتفريق المستويات المتجاورة:

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

استخدم [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) لتعيين الرقم الأول المعروض لفقرة مرقمة.

يعين المثال التالي بلغة PHP [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) لاستخدام الترقيم لثلاث فقرات ويحدد قيم [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) بـ 2 و3 و7. يتم تكوين قيمة البدء لكل فقرة على حدة، مما يسمح بتخطي أرقام معينة:

```php
use aspose\slides\BulletType;
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

ضبط هوامش الفقرة والمسافات لتحديد موضع السطر الأول والأسطر الملتفة. يمكنك أيضًا تنسيق علامة نهاية الفقرة بشكل منفصل عن قطع النص المرئية.

### **ضبط إزاحة السطر الأول**

استخدم طريقة [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) للتحكم في إزاحة السطر الأول في الفقرة. يتحرك هذا الإعداد السطر الأول فقط بالنسبة لهامش الفقرة الأيسر. القيمة الموجبة تحرك السطر الأول إلى اليمين، بينما تبقى الأسطر المتبقية محاذاة إلى متن الفقرة.

استخدم [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) عندما تحتاج إلى تحريك الفقرة بأكملها. واستخدم [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) عندما تحتاج إلى تحريك السطر الأول فقط.

يعطي المثال التالي ثلاث فقرات نفس قيمة [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) البالغة 20 نقطة و قيم [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) بـ 0 و20 و40 نقطة. تبدأ الأسطر الأولى بإزاحات متزايدة، بينما تحتفظ الأسطر الملتفة بنفس الهامش الأيسر:

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

![إزاحة السطر الأول للفقرات](first_line_indent.png)

### **ضبط إزاحة معلقة**

الإزاحة المعلقة هي تخطيط فقرة يبدأ فيه السطر الأول إلى اليسار من الأسطر المتبقية. في Aspose.Slides يمكنك إنشاء هذا التأثير بخصية [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent). اضبط `Indent` على قيمة سالبة لتحريك السطر الأول إلى اليسار نسبةً إلى متن الفقرة.

عمليًا، يحدد [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) موضع النص الأساسي، بينما يحدد [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) موضع السطر الأول بالنسبة لهذا الهامش. لإنشاء إزاحة معلقة، اضبط قيمة `MarginLeft` موجبة وقيمة `Indent` سالبة.

هذا التنسيق مفيد للببليوجرافيا، المراجع، مدخلات القاموس، وغيرها من الفقرات التي تحتاج إلى محاذاة الأسطر الملتفة تحت متن الفقرة بدلاً من تحت الحرف الأول للسطر الأول.

يضمّن المثال التالي بلغة PHP قيم [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft) بـ 40 و60 نقطة مع قيم [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent) بـ -20 و-30 نقطة. في كل فقرة يبدأ السطر الأول إلى اليسار من الأسطر الملتفة؛ الفقرة الثانية لها إزاحة معلقة أعمق:

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

![الإزاحة المعلقة للفقرات](hanging_indent.png)

### **ضبط خصائص تشغيل نهاية الفقرة**

تتحكم الطريقة [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) في تنسيق علامة نهاية الفقرة. ينشئ المثال التالي كائنًا من [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) يضبط [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) إلى 48 نقطة و[BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont) إلى Times New Roman. يُعيّن هذا التنسيق إلى علامة النهاية للفقرة الثانية، دون تغيير قطع النص المرئية:

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

للتعرف على قواعد الفقرة التي تؤثر على الالتفاف التلقائي وعلامات الترقيم عند نهاية الأسطر، راجع [Control Line Breaking](/slides/ar/php-java/text-formatting/#control-line-breaking) و[Control Hanging Punctuation](/slides/ar/php-java/text-formatting/#control-hanging-punctuation).

استخدم [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount) لحساب عدد الأسطر التي تشغلها الفقرة بعد تخطيط النص، بما في ذلك الالتفاف التلقائي. يفضّل ذلك عند فحص طول النص وتخطيطه في قوالب العرض.

الفقرة هي عنصر في [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs)، ويمكن أن تحتل عدة أسطر مرسومة. يكسر الفاصل السطر الصريح داخل الفقرة السطر دون إنشاء فقرة جديدة. يولّد الالتفاف التلقائي أسطرًا بناءً على العرض المتاح دون إدراج فواصل أسطر صريحة في النص. لذلك لا يعطي عدّ الفقرات أو أحرف الفاصل السطري عدد الأسطر المرسومة.

ينشئ المثال التالي شكلًا نصيًا، يعدّ أسطره، يضيق الشكل، ثم يستبدل النص بسلسلة أقصر. يفعّل الالتفاف عبر [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) ويعطل الملاءمة التلقائية عبر [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) بحيث يتحكم عرض الشكل في الالتفاف دون تقليل حجم النص أو تغيير أبعاد الشكل تلقائيًا. يستخدم كل قياس [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount). أبعاد الشكل بوحدات النقاط. أخيرًا، يضيف المثال فقرة أخرى ويجمع عدد الأسطر عبر إطار النص.

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

مع هذا النص وهذه الأبعاد، يؤدي تضييق الشكل إلى زيادة عدد الأسطر، بينما يقلل استبدال النص بالسلسلة القصيرة من العدد. قد تختلف العدادات بدقة حسب توفر الخطوط والاستبدال، حجم الخط، الهوامش، الإزاحة، الالتفاف، وإعدادات الملاءمة. استخدم الخطوط وإعدادات التخطيط المستهدفة عند فحص القالب.

عدد الأسطر وحده لا يحدِّد ما إذا كان النص يفيض عن حاويته. الارتفاع المتاح، ارتفاعات الأسطر، تباعد الفقرات والأسطر، وسلوك الملاءمة التلقائية مهمة أيضًا؛ فحتى سطرًا واحدًا قد يتجاوز العرض المتاح إذا كان الالتفاف معطلًا.

## **استيراد وتصدير محتوى الفقرة**

استخدم HTML لإدخال نص إلى عرض تقديمي أو لتصدير فقرات موجودة لاستخدامها خارجه. يوضح هذا القسم أيضًا كيفية تصيير الفقرات الفردية كصور، بما في ذلك الفقرات داخل خلايا الجداول.

### **استيراد نص HTML إلى فقرات**

استخدم [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml) لتحويل ترميز HTML إلى فقرات وقطع داخل إطار نص.

يقرأ المثال التالي بلغة PHP HTML من ملف ويمرره إلى [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml). يمسح الفقرة الافتراضية لإطار النص ليحتوي الإطار فقط على المحتوى المستورد. يترك الشكل المستطيل هامشًا قدره 10 نقاط على كل جانب من الشريحة:

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

استخدم [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml) لتصدير نطاق مختار من الفقرات كـ HTML. عند إعادة استخدام نص العرض على موقع ويب، قد ترغب في الحفاظ على التأكيد المحلي دون نقل خطوط أو أحجام أو أنماط صندوق النص. اضبط [TextToHtmlConversionOptions::setTextInheritanceLimit](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit) للتحكم في مدى اتباع المُصدِّر للوراثة التنسيقية.

حمل [العرض التوضيحي](text-inheritance.pptx) وضعه في دليل عمل التطبيق. يحتوي شريحةه الأولى على شكل نصي واحد بالنص "Inherited text; explicit red 18pt". يستخدم الإدخال مستويات تنسيق متعددة عن عمد:

- النمط النصي الافتراضي للعرض يزود بـ Calibri وحجم 28 pt.
- نمط النص من المستوى الأول لإطار النص يزود بنص أزرق ومائل.
- الفقرة تحدد صراحةً نصًا غامقًا.
- القطعة الثانية، "explicit red 18pt"، تحدد صراحةً نصًا أحمر وحجم 18 pt.

يصدّر المثال الكامل التالي الفقرات نفسها ثلاث مرات. يمرّر [TextToHtmlConversionOptions](https://reference.aspose.com/slides/php-java/aspose.slides/texttohtmlconversionoptions/) إلى طريقة التصدير ويكتب كل نتيجة كملف HTML UTF‑8 منفصل:

```php
use aspose\slides\Presentation;
use aspose\slides\TextInheritanceLimit;
use aspose\slides\TextToHtmlConversionOptions;

$presentation = new Presentation("text-inheritance.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();

            $modes = array(TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly);
            $fileNames = array("All.html", "TextBox.html", "ParagraphOnly.html");

            for ($i = 0; $i < count($modes); $i++) {
                $options = new TextToHtmlConversionOptions();
                $options->setTextInheritanceLimit($modes[$i]);

                $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), $options);
                if (file_put_contents($fileNames[$i], java_values($html)) === false) {
                    echo "The HTML file could not be written." . PHP_EOL;
                }
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

يحتوي HTML المُنتج على CSS التالي للقطعة الأولى "Inherited text; ". تُدرج الجدول الإعلانات ذات الصلة؛ تُستثنى الخصائص الأخرى لتوضيح العرض.

| النتيجة | CSS ذو الصلة للقطعة الأولى | المظهر |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، غامق، مائل بحجم 28 pt في Calibri، إذا كان الخط متاحًا. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | نص أزرق، غامق، مائل؛ يزود المتصفح أو الصفحة المحيطة عائلة الخط والحجم. |
| `ParagraphOnly.html` | `font-weight:bold` | نص غامق؛ يزود المتصفح أو الصفحة المحيطة عائلة الخط، الحجم، اللون، والنمط المائل. |

تحتفظ القطعة الثانية بـ `color:#ff0000`، `font-size:18pt`، و`font-weight:bold` في جميع المخرجات الثلاث. كما تحتفظ بالمائل في `All` و`TextBox`، لكن ليس في `ParagraphOnly`. لذلك لا يزيل تقييد الوراثة التنسيق المُعين صراحةً لفقرة أو قطعة.

افتح الملفات في المتصفح نفسه للمقارنة. في الوضعين المُقيدين، تُحل الخصائص CSS المستبعدة بواسطة أنماط الصفحة الهدف أو القيم الافتراضية للمتصفح، لذا يعتمد المظهر النهائي على مكان استخدام HTML.

### **تصيير فقرة كصورة**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) يصيّر فقرة فردية مباشرةً ويُعيد كائنًا من [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/). احفظ النتيجة إلى ملف أو تدفق عبر [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). لا تحتاج لتصيير الشكل المتضمن أو قص صورة يدوياً.

قد يرجع [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) قيمة `null` إذا لم تُعثر الفقرة في المجموعة الأصلية، أو لا تحتوي على حدود تصيير صالحة، أو لا يمكن تصييرها. تحقّق من النتيجة قبل الحفظ وتخلص من الصورة المرتجعة بعد الاستخدام.

#### **تصيير الفقرة بالمقاس الافتراضي**

يستخدم المثال عرضًا يحتوي على شريحة واحدة وشكل نصي أول يحمل ثلاث فقرات.

![صندوق النص مع ثلاث فقرات](paragraph_to_image_input.png)

يختار المثال الفقرة الثانية بالمؤشر 1 ويستدعي [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) دون تمرير عوامل مقياس. يتحقق من وجود الفقرة المطلوبة في الشكل وأن التصيير أرجع صورة قبل استدعاء [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) لحفظها بصيغة PNG. يطلق كتلة `finally` لتحرير الصورة بعد الاستخدام.

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

![صورة الفقرة](paragraph_to_image_output.png)

#### **تصيير الفقرة في خلية جدول مع مقياس**

استخدم تجاوز [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage) الذي يقبل معاملات `$scaleX` و`$scaleY` لتحديد عوامل المقياس الأفقي والعمودي. ينشئ المثال جدولًا، يصيّر الفقرة في خليةه الأولى بمضاعفة العرض والارتفاع الافتراضيين، ويحوّل النتيجة إلى صورة PNG.

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

القيمة `1` تحافظ على هذا المحور بالحجم البكسلي الافتراضي. على سبيل المثال، `2` لكلا العاملين ينتج صورة عرضها وارتفاعها تقريبًا ضعف الأبعاد الافتراضية، أي أربعة أضعاف عدد البكسلات. العوامل الأكبر عادةً ما تُنتج نصًا أكثر حدة للتكبير أو الإخراج عالي الدقة، لكنها تزيد من استهلاك الذاكرة وحجم الملف. القيم الأقل من `1` تُنتج صورًا أصغر بتفاصيل أقل. استخدم عوامل متماثلة للحفاظ على نسبة أبعاد الفقرة؛ العوامل الأفقية والعمودية المختلفة تُمدد النتيجة بشكل مستقل.

يبقى تصيير شكل كامل عبر [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) مفيدًا عندما يجب تضمين التعبئة، الحد، أو سياق بصري آخر للشكل. للحصول على صورة للفقرة فقط، استخدم [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage).

## **الأسئلة الشائعة**

**هل يمكنني تعطيل الالتفاف داخل إطار النص تمامًا؟**

نعم. اضبط [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText) لتعطيل الالتفاف بحيث لا تنكسر الأسطر على حواف إطار النص.

**كيف يمكنني الحصول على حدود الفقرة المحددة على الشريحة؟**

استخدم [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect) لاسترجاع المستطيل المحيط بالفقرة. توفر [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect) حدود القطعة الفردية.

**أين يتم التحكم في محاذاة الفقرة (يسار، يمين، وسط، أو ضبط)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) هي إعداد على مستوى الفقرة وينطبق على الفقرة بأكملها بغض النظر عن تنسيق القطع الفردية.

للمحاذاة العمودية للقطع ذات الأحجام الخطية المختلفة داخل كل سطر، راجع [Align Fonts Within a Line](/slides/ar/php-java/text-formatting/#align-fonts-within-a-line).

**هل يمكنني ضبط لغة التدقيق لجزء من الفقرة؟**

نعم. اضبط [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) للقطع الفردية، بحيث يمكن للفقرة أن تحتوي نصًا بعدة لغات.