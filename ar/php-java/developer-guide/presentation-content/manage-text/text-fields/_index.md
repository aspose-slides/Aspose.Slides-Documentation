---
title: إدارة حقول النص في عروض PowerPoint التقديمية في PHP
linktitle: حقول النص
type: docs
weight: 52
url: /ar/php-java/text-fields/
keywords:
- حقل نص
- نص تلقائي
- رقم الشريحة
- التاريخ والوقت
- رأس
- تذييل
- جزء نص
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "إنشاء، فحص، تعديل، وإزالة حقول النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides for PHP عبر Java. الحفاظ على التنسيق والتحقق من ملفات PPTX و PPT المحفوظة."
---
## **نظرة عامة**

فقرة نصية تتكون من أجزاء. الجزء العادي [Portion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/) يحتوي على نص حرفي؛ الجزء الحقل يحتوي أيضًا على [Field](https://reference.aspose.com/slides/ar/php-java/aspose.slides/field/) يحدد نوعه قيمة يتم تحديثها تلقائيًا، مثل رقم الشريحة أو التاريخ. يمكن لجزءين عرض نفس الأحرف بينما يحتوي أحدهما فقط على حقل.

استخدم [Portion::getField](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/#getField) للتمييز بينها: تكون `null` للنص العادي. [Portion::addField](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/#addField) يحول الجزء الموجود إلى حقل. احتفظ بالملصق وقيمته الديناميكية في أجزاء منفصلة بحيث لا يؤدي تحويل القيمة إلى استبدال الملصق.

هذا الدليل يغطي الحقول داخل النص، تنسيقها، وحفظها في صيغة PPTX و PPT. للحصول على إطارات النص والفقرات، راجع [Manage Text](/slides/ar/php-java/manage-text/).

## **إنشاء حقل رقم الشريحة**

المثال الكامل التالي ينشئ مربع نص يحتوي على ملصق حرفي `Slide ` يليه رقم يتم تحديثه تلقائيًا. يضبط حجم الرقم ووزنه ولونه قبل إضافة الحقل، ثم يعيد فتح العرض المحفوظ ويتحقق من نوع الحقل والنص وتنسيقه. لا يلزم ملف إدخال.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

يبدأ العرض الجديد برقم الشريحة 1، لذا يكون النص `Slide 1`، وكلا الفحصين يطبعان `true`. يظل الرقم حقلًا بعد إعادة الفتح؛ ليس نصًا حرفيًا `1`. المؤشرات في التحقق تشير إلى الشكل والأجزاء التي أنشأها هذا المثال.

## **اختر نوع الحقل**

[FieldType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fieldtype/) يوفر الطرق التالية للحصول على قيم معرفة مسبقًا. مرر القيمة المناسبة إلى [addField](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/#addField).

| الطريقة | الغرض |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fieldtype/#getSlideNumber) | رقم الشريحة الحالي. |
| [getDateTime](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fieldtype/#getDateTime) | التاريخ/الوقت بتنسيق التطبيق الافتراضي. |
| [getDateTime1](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fieldtype/#getDateTime9) | تنسيقات تاريخ أو تاريخ/وقت محددة مسبقًا. |
| [getDateTime10](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fieldtype/#getDateTime13) | تنسيقات وقت محددة مسبقًا، مع خيارات للثواني وساعة 12. |
| [getHeader](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fieldtype/#getHeader) | حقل رأس؛ انظر قيود العنصر النائب والتنسيق أدناه. |
| [getFooter](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fieldtype/#getFooter) | حقل تذييل. |

على سبيل المثال، [getDateTime3](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fieldtype/#getDateTime3) يمثل اليوم، اسم الشهر بالكامل، والسنة بالإنجليزية. هذه تنسيقات حقل معرفة مسبقًا، وليست سلاسل تنسيق تاريخ PHP عشوائية. اللغة المحددة عبر [setLanguageId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setLanguageId) والتطبيق الذي يعالج العرض قد يؤثران على النتيجة المعروضة.

## **إنشاء حقل من سلسلة داخلية**

التحميل الزائد للسلسلة في [addField](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/#addField) يقبل معرف حقل داخلي. استخدمه عند الحفاظ على معرف قدمته تطبيق آخر لا يملك قيمة معرفة مسبقًا. يمكنك أيضًا إنشاء [FieldType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fieldtype/#FieldType) من المعرف. [FieldType::getInternalString](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fieldtype/#getInternalString) يكشف عن ذلك المعرف للفحص.

هذا المثال يخزن حقلًا خاصًا بالتطبيق `custom-report-id` مع النص الاحتياطي `Report-042`. المعرف لا يسجِّل حسابًا: Aspose.Slides لا يُنشئ معرفات تقارير لأنواع غير معروفة. يجب على التطبيق الذي يفهم هذا المعرف توفير معناه وتحديث قيمته.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

بعد جولة حفظ وفتح PPTX، يكون النوع `custom-report-id` والنص `Report-042`. تمرير سلسلة مثل `Y-m-d` سيُسمِّى نوع حقل؛ لن يُكوِّن تنسيق تاريخ مخصص. لتاريخ ثابت بتنسيق عشوائي، استخدم نصًا عاديًا.

## **فحص وتعديل وإزالة حقول التاريخ/الوقت**

غيّر حقلًا موجودًا عبر [Field::setType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/field/#setType). تحقق من وجود الحقل قبل الوصول إلى نوعه. لإيقاف التحديثات التلقائية، استدعِ [Portion::removeField](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/#removeField). هذا يحافظ على الجزء ونصه الحالي مع إزالة ارتباط الحقل. إذا كنت بحاجة إلى قيمة ثابتة معينة، عيّن ذلك النص بعد إزالة الحقل.

لإعداد API المتعلق بمعالجة حقول التاريخ/الوقت، راجع [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#setCurrentDateTime). المثال أدناه يستخدم تاريخ موافقة صريح عند تحويل حقل إلى نص عادي.

حمّل [sample.pptx](sample.pptx) وضعه في دليل عمل JavaBridge، أو مرّر مساره المطلق إلى مُنشئ العرض. يحتوي على شكلين نصيين مسميين، `UpdatedAt` و `ApprovedDate`، كل منهما يحوي حقل تاريخ/وقت، بالإضافة إلى ملصقات نصية عادية. المثال التالي يتجول عبر الأشكال النصية العليا في الشرائح العادية. يغيّر حقول التاريخ/الوقت إلى تنسيق تاريخ طويل ويجعلها مائلة، مع الحفاظ على باقي التنسيقات. فقط الحقول في `ApprovedDate` تتحول إلى نص ثابت.

العينة تتعرف على المعرفات الداخلية المدمجة `datetime` و `datetime1` إلى `datetime13`. المجموعات والجداول والملاحظات والتخطيطات والماستر تتطلب استعراض حاويات النص الخاصة بها وهي خارج نطاق هذا المثال.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

بعد إعادة الفتح، يكون لـ `UpdatedAt` النوع `datetime3` ويبقى ديناميكيًا. لا يحتوي `ApprovedDate` على حقل ويظهر النص `05 April 2030`. كلا الجزئين التاريخيين مائلان، وحجم الخط الأصلي وإعداد السُمك واللون يبقيان كما هما. ملصقات النص العادية لا تتغير. التحقق يقرأ الجزء الأول من الشكلين المعروفين في العينة المقدمة.

## **الحفاظ على تنسيق النص**

اعمل على الجزء الموجود عند إضافة حقل، أو تغيير نوعه، أو إزالته. هذه العمليات تحتفظ بتنسيق ذلك الجزء. استخدم [Portion::getPortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/#getPortionFormat) لتغيير الخصائص المطلوبة فقط، كما تفعل الأمثلة للون أو المائلة.

تجنب إعادة بناء إطار نص كامل لمجرد تحديث حقل واحد: قد يؤدي ذلك إلى فقدان حدود الأجزاء الأصلية وتنسيقها الفردي. كذلك ميز بين التنسيق المحدد صراحةً والتنسيق الموروث من الفقرة أو التخطيط أو السمة. انظر [Text Formatting](/slides/ar/php-java/text-formatting/) للحصول على خيارات تنسيق أوسع.

## **الحقول وعناصر النائب للرأس/التذييل**

الحقل هو جزء من جزء نصي. العنصر النائب هو شكل له دور في العرض، مثل تذييل أو رقم شريحة. إضافة حقل إلى صندوق نص عادي لا يُحوِّل هذا الشكل إلى عنصر نائب.

مديرو الرأس والتذييل يتحكمون بنص العنصر النائب ورؤيته على الشرائح، التخطيطات، والماستر، بما في ذلك الانتشار إلى الشرائح التابعة. لذلك قد يكون حقل رقم في صندوق نص مخصص مفيدًا حتى وإن لم تستخدم عنصر نائب رقم الشريحة. بالمقابل، تغيير رؤية العنصر النائب لا يزيل الحقل من صندوق نص غير مرتبط.

أنواع الرأس والتذييل المعرفة مسبقًا لا تُنشئ العناصر النائبة المقابلة ولا تزود محتواها. على وجه الخصوص، الشريحة العادية في PowerPoint لا تحتوي على عنصر نائب رأس؛ رؤوس الصفحات تخص صفحات الملاحظات والنشرات. لا تفترض أن حقل رأس أو تذييل في شكل عشوائي سيحصل تلقائيًا على النص المكوَّن عبر مدير العنصر النائب. لهذا السيناريو، راجع [Presentation Headers and Footers](/slides/ar/php-java/presentation-header-and-footer/).

## **قيود PPTX و PPT**

تحقق من كل من نوع الحقل والنص الناتج بعد الحفظ وإعادة الفتح. الحفاظ على معرف لا يثبت أن تطبيقًا ما يستطيع حساب أو عرض قيمته.

| الصيغة | سلوك الحقل والقيود |
|---|---|
| PPTX | يخزن معرفات الحقول الداخلية إلى جانب نص الحقل. في فحص الجولة، نجت الأنواع المعرفة مسبقًا والمعرف المخصص المستخدم أعلاه من الحفظ وإعادة الفتح. احتفظ النوع المخصص بنصه الاحتياطي؛ لم يكتسب منطق حساب تلقائي. قد يتعامل تطبيق آخر مع المعرفات غير المدعومة بشكل مختلف. |
| PPT | يستخدم تمثيلات حقل قديمة ويملك توافقية أقل. في فحص الجولة، نجت حقول رقم الشريحة والحقول الزمنية المعرفة مسبقًا من الحفظ وإعادة الفتح. حقل مخصص في مربع نص شريحة عادية أعيد فتحه بمعرفه لكن نصه أصبح `*`؛ حقل رأس في نفس السياق أيضًا أنتج `*`. لا تعتمد على بقاء النص المرئي للحقول المخصصة أو الحقول غير المدعومة. |

لإخراج ثابت ومحمول، حوّل الحقول غير المدعومة إلى نص عادي وعين القيمة المطلوبة صراحةً قبل الحفظ. هذا يحافظ على النص المختار لكنه يوقف التحديثات التلقائية عمدًا. اختبر التطبيق الهدف أيضًا عندما يكون إعادة حساب الحقول جزءًا من سير عملك.

## **الأسئلة المتكررة**

**كيف يمكنني معرفة ما إذا كان الرقم أو التاريخ المعروض حقلًا؟**  
افحص [Portion::getField](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/#getField). قيمة غير `null` تحدد وجود حقل؛ النص المعروض وحده لا يكفي.

**هل إزالة حقل تُزيل نصه أو تنسيقه؟**  
لا. [removeField](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/#removeField) يحول الجزء الموجود إلى نص عادي. عيّن قيمة صريحة بعد ذلك إذا كنت تحتاج إلى تاريخ ثابت أو نص احتياطي.

**هل يمكن لسلسلة داخلية تعريف تنسيق تاريخ جديد أو صيغة؟**  
لا. هي تحدد نوع الحقل. المعرف غير المعروف لا يوفر مُقيمًا ولا نمط تنسيق تاريخ PHP. استخدم نوعًا معرفًا مسبقًا أو صغ القيمة كنص عادي.

**لماذا أحتاج للتحقق من العرض مرة أخرى بعد حفظه؟**  
معرفات الحقول والنص المحسوب والتنسيق أشياء منفصلة تحتاج للتحقق منها. قد يغيّر تحويل الصيغة النتيجة المرئية حتى لو ظل معرف الحقل موجودًا.