---
title: إدارة القوائم النقطية والمرقمة في العروض التقديمية باستخدام PHP
linktitle: إدارة القوائم
type: docs
weight: 60
url: /ar/php-java/manage-lists/
keywords:
- نقطة
- قائمة نقطية
- قائمة مرقمة
- علامة رمزية
- علامة صورة
- علامة مخصصة
- قائمة متعددة المستويات
- إنشاء علامة
- إضافة علامة
- إضافة قائمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرف على كيفية إنشاء وتنسيق القوائم النقطية، وقوائم الصور، والقوائم متعددة المستويات، والقوائم المرقمة في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

يتيح Aspose.Slides for PHP via Java إنشاء وتنسيق القوائم النقطية والمرقمة في عروض PowerPoint وOpenDocument. عنصر القائمة هو فقرة يتم التحكم في إعدادات العلامة النقطية الخاصة به من خلال تنسيق الفقرة الخاص بها.

استخدم طريقة [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/#getParagraphFormat--) للوصول إلى إعدادات القائمة على مستوى الفقرة. النقطة الأساسية هي [ParagraphFormat.getBullet](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#getBullet--) التي تُرجع كائنًا من النوع [BulletFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/). باستخدام هذا الكائن يمكنك تعيين نوع العلامة النقطية، الرمز، الصورة، اللون، الحجم، نمط الترقيم، ورقم البداية.

توضح هذه المقالة كيفية:

- إنشاء قائمة نقطية برمز مخصص
- إنشاء علامة نقطية صورة
- إنشاء قائمة متعددة المستويات عن طريق ضبط عمق الفقرة
- إنشاء قائمة مرقمة
- فحص وتغيير تنسيق القوائم في عرض تقديمي موجود

## **إنشاء قائمة نقطية**

لإنشاء قائمة نقطية، أضف كائنات [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/) إلى [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) واضبط [BulletFormat.setType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#setType-int-) إلى [BulletType.Symbol](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bullettype/#Symbol). بعد ذلك يمكنك ضبط [BulletFormat.setChar](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#setChar-char-)، [BulletFormat.getColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#getColor--)، و[BulletFormat.setHeight](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#setHeight-float-) للتحكم في مظهر العلامة النقطية.

الكود PHP التالي يوضح كيفية إنشاء قائمة نقطية في شريحة:

```php
function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

النتيجة:

![الرموز النقطية](symbol_bullets.png)

## **إنشاء قائمة مرقمة**

استخدم القوائم المرقمة عندما يكون ترتيب العناصر مهمًا. اضبط [BulletFormat.setType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#setType-int-) إلى [BulletType.Numbered](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bullettype/#Numbered). يمكنك أيضًا اختيار تنسيق الترقيم باستخدام [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) أو ضبط [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) عندما يجب أن تبدأ القائمة من قيمة غير 1.

الكود PHP التالي يوضح كيفية إنشاء قائمة مرقمة في شريحة:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

النتيجة:

![العلامات المرقمة](numbered_bullets.png)

## **إنشاء علامة نقطية صورة**

يتيح Aspose.Slides استبدال الرمز النقطي العادي بصورة. تعمل العلامات النقطية الصورية بشكل أفضل مع الصور البسيطة التي تظل قابلة للقراءة بحجم صغير، مثل الأيقونات أو ملفات PNG الشفافة الصغيرة.

{{% alert color="primary" %}}
من الناحية المثالية، إذا كنت تخطط لاستبدال الرمز النقطي العادي بصورة، فمن الأفضل اختيار رسم بسيط بخلفية شفافة. تعمل هذه الصور جيدًا كرموز نقطية مخصصة.
{{% /alert %}}

لإنشاء علامة نقطية صورة، أضف صورة إلى [Presentation.getImages](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getImages--) وعيّن كائن [PPImage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/ppimage/) الذي تم إرجاعه إلى [BulletFormat.getPicture](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#getPicture--). اضبط [BulletFormat.setType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bulletformat/#setType-int-) إلى [BulletType.Picture](https://reference.aspose.com/slides/ar/php-java/aspose.slides/bullettype/#Picture) قبل تعيين الصورة.

لنفترض أن لدينا ملف "image.png":

![صورة للعلامات النقطية](picture_for_bullets.png)

الكود PHP التالي يوضح كيفية إنشاء علامات نقطية صورية في شريحة:

```php
function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

النتيجة:

![العلامات النقطية الصورية](picture_bullets.png)

## **إنشاء قائمة متعددة المستويات**

استخدم [ParagraphFormat.setDepth](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setDepth-short-) لوضع عناصر القائمة على مستويات مختلفة. المستوى 0 هو المستوى الأعلى، المستوى 1 هو المستوى الفرعي تحته، وهكذا.

الكود PHP التالي يوضح كيفية إنشاء قائمة نقطية متعددة المستويات:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

النتيجة:

![القائمة متعددة المستويات](multilevel_list.png)

## **تغيير قائمة موجودة**

لتغيير تنسيق القائمة في عرض تقديمي موجود، وصول إلى الفقرة المستهدفة وقم بتحديث إعدادات [ParagraphFormat.getBullet](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#getBullet--) الخاصة بها. يمكن استخدام نفس الخصائص المستخدمة لإنشاء القوائم لفحص أو تعديل القوائم التي تم تحميلها من ملف PPT أو PPTX أو ODP.

الكود PHP التالي يغيّر الفقرة الأولى في إطار النص لاستخدام نمط قائمة مرقمة:

```php
$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **الأسئلة المتكررة**

**هل يمكن تصدير القوائم النقطية والمرقمة إلى PDF أو صور؟**

نعم. يحتفظ Aspose.Slides بتنسيق القوائم عندما يدعم التنسيق المستهدف تخطيط النص وميزات العلامة النقطية المقابلة.

**هل يمكن تعديل القوائم في العروض التقديمية الموجودة؟**

نعم. حمّل العرض التقديمي، وصول إلى الفقرة المستهدفة، فحص أو تحديث إعدادات [ParagraphFormat.getBullet](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#getBullet--) الخاصة بها، ثم احفظ العرض التقديمي.

**هل يمكن أن تحتوي القوائم على نص غير لاتيني؟**

نعم. يمكن أن يحتوي نص عنصر القائمة على أحرف Unicode، وبالتالي يمكنك إنشاء قوائم في عروض تقديمية متعددة اللغات. تأكد من أن الخطوط المستخدمة في العرض تدعم الأحرف التي تحتاجها.