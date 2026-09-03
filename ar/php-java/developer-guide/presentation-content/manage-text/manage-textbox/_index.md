---
title: إدارة صناديق النص في العروض التقديمية باستخدام PHP
linktitle: إدارة صندوق النص
type: docs
weight: 20
url: /ar/php-java/manage-textbox/
keywords:
- صندوق نص
- إطار نص
- إضافة نص
- تحديث نص
- إنشاء صندوق نص
- التحقق من صندوق النص
- إضافة عمود نص
- إضافة ارتباط تشعبي
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتحديد وتنسيق وتحديث صناديق النص في عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **المقدمة**

في Aspose.Slides للـ PHP عبر Java، يتم تخزين نص الشريحة في إطارات نصية تنتمي إلى الأشكال. تمثل الفئة [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) الشكل الأكثر شيوعًا الذي يحمل نصًا وتعرض نصه عبر الطريقة [AutoShape::getTextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
كل شكل تلقائي يُشتق من [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/)، لكن ليس كل شكل هو شكل تلقائي أو يدعم إطار نصي. عند معالجة عرض تقديمي موجود، استخدم `java_instanceof` للتحقق من أن الشكل هو [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/) قبل الوصول إلى نصه.
{{% /alert %}}

## **إنشاء مربع نص على شريحة**

لإنشاء مربع نص، أضِف شكلاً تلقائيًا إلى شريحة، أضف نصًا إلى إطار النص الخاص به، واحفظ العرض التقديمي. المثال التالي ينشئ مربع نص مستطيل:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

الإحداثيات والأبعاد التي تُمرَّر إلى [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/#addAutoShape) تُقاس بالنقاط. تقوم [AutoShape::addTextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/#addTextFrame) بتهيئة إطار النص بالنص المقدم.

## **التحقق من شكل مربع نص**

استخدم طريقة [AutoShape::isTextBox](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/#isTextBox) لتحديد ما إذا كان الشكل التلقائي يُعامل كمربع نص. يكون ذلك مفيدًا عندما يحتوي العرض التقديمي على أشكال تلقائية تحمل نصًا وأخرى رسومية بحتة.

![مربع نص وشكل](istextbox.png)

المثال التالي يفحص كل شكل تلقائي في عرض تقديمي:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

لا يُعتبر الشكل التلقائي المضاف حديثًا مربع نص حتى يحتوي على نص غير فارغ. يمكنك توفير ذلك النص عبر [AutoShape::addTextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/#addTextFrame) أو [TextFrame::setText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#setText). إضافة أو تعيين سلسلة فارغة يجعل [AutoShape::isTextBox](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/#isTextBox) تُعيد `false`:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

النداءان الأولان يطبعان `true`؛ والنداءان الأخيران يطبعان `false`.

## **إيجاد الشكل الذي يملك إطار نص**

قد يتلقى كود معالجة النص العامة كائنًا من نوع [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) دون معرفة أي كائن عرض تقديمي يحتويه. استخدم طريقة القراءة فقط [TextFrame::getParentShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentShape) للانتقال مرة أخرى إلى [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) المالكة.

لإطار نص مملوك لشكل تلقائي أو شكل آخر يحمل نصًا، تُعيد [TextFrame::getParentShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentShape) المالك وتُعيد [TextFrame::getParentCell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#getParentCell) القيمة `null`. تحقّق من القيمة المرجعة باستخدام `java_is_null` قبل الوصول إليها. لتحديد كل من مالكي الأشكال وخلايا الجداول، بما في ذلك الأشكال المرتبطة بعقد SmartArt، راجع [Search and Replace Text](/slides/ar/php-java/search-and-replace-text/).

## **إضافة أعمدة إلى مربع نص**

تقسِّم طريقة [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setColumnCount) إطار النص إلى أعمدة، بينما تحدد طريقة [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setColumnSpacing) الفاصل بين الأعمدة بالنقاط. كلا الإعدادين ينتميان إلى [TextFrameFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/) ويمكن تغييرهما من خلال إطار النص لمربع نص موجود. يُعاد تدفق النص بين الأعمدة داخل الشكل نفسه؛ ولا يستمر إلى شكل آخر.

المثال التالي ينشئ مربع نص ثلاثي الأعمدة مع مسافة 10 نقاط بين الأعمدة، يحفظ العرض التقديمي، ويقرأ الإعدادات المخزنة مرة أخرى من ملف الإخراج:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **استخراج النص من الأعمدة الفردية**

استخدم [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/#splitTextByColumns) لاسترجاع النص المخصص لكل عمود بصري في إطار نص موجود. تُعيد الطريقة سلسلة واحدة لكل عمود، وفق ترتيب القراءة العمودي. ينتج إطار نص أحادي العمود مصفوفة ذات عنصر واحد، والعمود الفارغ يُمثَّل بسلسلة فارغة. السلاسل تحتوي على نص عادي فقط؛ ولا يتم حفظ تنسيق المستوى الجزئي.

- استخراج النص مع الحفاظ على ترتيب القراءة العمودي.
- فهرسة أو مقارنة محتوى الشرائح متعددة الأعمدة.
- تصدير كل عمود إلى ملف منفصل، حقل قاعدة بيانات، أو هدف آخر.
- فحص كيفية إعادة توزيع النص بعد تعديل عدد الأعمدة باستخدام [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setColumnCount)، أو تعديل الفواصل باستخدام [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setColumnSpacing)، أو تعديل الخط، أو حجم إطار النص.

تُبلغ الطريقة عن النص الموزَّع داخل الـ [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الحالي؛ ولا تقوم تلقائيًا بتمرير النص بين أشكال أو مربعات نص منفصلة. قد يعتمد توزيع الأعمدة على الخطوط المتوفرة وإعدادات تخطيط النص الأخرى، لذا تأكد من توفر الخطوط المطلوبة عندما تكون النتائج المتسقة مهمة.

المثال التالي يحمل عرضًا تقديميًا، يجد أول شكل تلقائي متعدد الأعمدة يحتوي على إطار نص، يقرأ عدد الأعمدة المُكوَّن، ويكتب النص من كل عمود إلى ملف منفصل. يتم تخطي الأشكال التي لا توفر إطار نص.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **تحديث النص**

لتحديث النص في جميع أنحاء العرض التقديمي، قم بتكرار الشرائح والأشكال، اختر الأشكال التلقائية، ثم حرر أجزاء النص الخاصة بها. العمل على مستوى الجزء يسمح لك بتغيير كل من النص وتنسيق الأحرف.

المثال التالي يستبدل كل ظهور لـ `years` بـ `months` في نص الشكل التلقائي ويجعل كل جزء متأثر غامقًا:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

هذه العملية تُحدِّث النص فقط في الأشكال التلقائية. النص المخزن في الجداول أو المخططات أو SmartArt أو الأشكال المجمعة يتطلب استعراض مجموعات تلك الكائنات الخاصة.

## **إضافة مربع نص مع ارتباط تشعبي**

يمكن تعيين ارتباط تشعبي إلى جزء نصي محدد، بحيث يكون ذلك النص فقط هو القابل للنقر. استخدم [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/ar/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) لربط الجزء بعنوان URL خارجي.

المثال التالي ينشئ نصًا مرتبطًا ويحفظه في عرض تقديمي:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**ما هو الفرق بين مربع النص وعلامة النص النائبة على شريحة رئيسية أو تخطيطية؟**

يمكن لـ [placeholder](/slides/ar/php-java/manage-placeholder/) أن يرث موقعه وتنسيقه من [master slide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/) أو [layout slide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/). مربع النص العادي هو شكل مستقل على الشريحة التي تم إنشائه فيها ولا يكتسب سلوك العلامة النائبة عندما يتغير التخطيط.

**كيف يمكنني استبدال النص دون تغيير النص في المخططات أو الجداول أو SmartArt؟**

قصر الاستعراض على كائنات [AutoShape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/autoshape/)، كما هو موضح في مثال تحديث النص. تقوم المخططات والجداول وSmartArt بتخزين النص في نماذج الكائنات الخاصة بها، لذلك لا يتم تعديلها بواسطة تلك الحلقة.