---
title: تنسيق نص العرض التقديمي في PHP
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/php-java/text-formatting/
keywords:
- تمييز النص
- التعبير النمطي
- محاذاة الفقرة
- نمط النص
- خلفية النص
- شفافية النص
- تباعد الأحرف
- خصائص الخط
- عائلة الخط
- دوران النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الملاءمة التلقائية
- تثبيت إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. تخصيص الخطوط، الألوان، المحاذاة، والمزيد."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. تغطي الإبراز، ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، نقاط التبويب، وإعدادات اللغة.

في الأمثلة أدناه، سنستخدم ملفًا اسمه "sample.pptx"، يحتوي على صندوق نص واحد في الشريحة الأولى مع النص التالي:

![نص العينة](sample_text.png)

## **تسليط الضوء على النص**

استخدم طريقة [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/)`::highlightText` عندما تحتاج إلى إبراز النص الذي يطابق عينة محددة داخل إطار نص. تطبق الطريقة لون الإبراز على أجزاء النص المتطابقة ويمكن استخدامها مع [TextHighlightingOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/texthighlightingoptions/) للتحكم في طريقة البحث، على سبيل المثال لمطابقة الكلمات الكاملة فقط.

يعرض مثال الشيفرة أدناه إبراز جميع تكرارات الأحرف **"try"** ثم إبراز الكلمة الكاملة **"to"** فقط.

```php
$presentation = new Presentation("sample.pptx");
try {
    // احصل على الشكل الأول من الشريحة الأولى.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // تمييز كلمة "try" في الشكل.
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // تمييز كلمة "to" في الشكل.
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![النص المبرز](highlighted_text.png)

## **تسليط الضوء على النص باستخدام التعابير النمطية**

طريقة [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/)`::highlightRegex` تبرز مطابقات النص التي يتم العثور عليها باستخدام تعبير نمطي.

يعرض مثال الشيفرة أدناه إبراز جميع الكلمات التي تحتوي على **سبعة أحرف أو أكثر**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // تمييز جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![النص المبرز باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تعيين لون خلفية النص**

استخدم تنسيق الجزء الافتراضي في [ParagraphFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/) لتعيين لون الإبراز الافتراضي لفقرة، أو استخدم [PortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/) لأجزاء النص الفردية.

يوضح مثال الشيفرة التالي كيفية تعيين لون الخلفية للـ **فقرة كاملة**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // تعيين لون الإبراز للفقرة بأكملها.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

يوضح مثال الشيفرة أدناه كيفية تعيين لون الخلفية لـ **أجزاء النص ذات الخط العريض**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // تعيين لون الإضاءة لجزء النص.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم طريقة [ParagraphFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/)`::setAlignment` لتحديد محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة وسطية، محاذاة لليسار، محاذاة لليمين، مبررة، وما إلى ذلك.

يوضح مثال الشيفرة التالي كيفية محاذاة الفقرة إلى **الوسط**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // تعيين محاذاة الفقرة إلى الوسط.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الفقرة المحاذاة إلى الوسط](aligned_paragraph.png)

## **تعيين الشفافية للنص**

تتحكم شفافية النص من خلال المكوّن alfa للون المعيّن لتعبئة [PortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة alfa من نوع ARGB على مقياس 0-255، وليس نسبة شفافية.

يوضح مثال الشيفرة التالي كيفية تطبيق الشفافية على **الفقرة كاملة**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // تعيين لون تعبئة النص إلى لون شفاف.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

يوضح مثال الشيفرة التالي كيفية تطبيق الشفافية على **أجزاء النص ذات الخط العريض**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // تعيين شفافية جزء النص.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![أجزاء النص الشفافة](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

استخدم طريقة [BasePortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/)`::setSpacing` لتوسيع أو تقليص التباعد بين الأحرف في صندوق نص.

يوضح الكود PHP التالي كيفية توسيع تباعد الأحرف في **الفقرة كاملة**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // توسيع تباعد الأحرف.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

يوضح مثال الشيفرة التالي كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
            $portion->getPortionFormat()->setSpacing(3); // توسيع تباعد الأحرف.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **تعطيل الكيرنينغ للخطوط المحددة**

في بعض الحالات، قد يبدو النص الذي تم إنتاجه بواسطة Aspose.Slides أكثر ضيقًا قليلًا مقارنةً بالنص نفسه في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات الكيرنينغ لبعض الخطوط، حتى عندما يحتوي الخط على معلومات كيرنينغ صالحة وتم تمكين الكيرنينغ في إعدادات PowerPoint.

لجعل المخرجات المرسومة أقرب إلى PowerPoint في مثل هذه الحالات، يمكنك تعطيل الكيرنينغ لأجزاء النص التي تستخدم الخط المتأثر. اضبط طريقة [BasePortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` إلى قيمة أكبر بكثير من حجم الخط الفعلي:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

هذا الإعداد يمنع تطبيق الكيرنينغ على أجزاء النص المتطابقة ويمكن أن يساعد في مواءمة عرض Aspose.Slides مع النتائج البصرية في PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة من خلال تنسيق الجزء الافتراضي في [ParagraphFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/) أو على الأجزاء الفردية عبر [PortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/).

يعين الكود التالي الخط ونمط النص للفقرة كاملة: يطبّق حجم الخط، العريض، المائل، تسطير نقطي، وخط Times New Roman على جميع الأجزاء في الفقرة.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // تعيين خصائص الخط للفقرة.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![خصائص الخط للفقرة](font_properties_for_paragraph.png)

يوضح مثال الشيفرة أدناه تطبيق خصائص مشابهة على **أجزاء النص ذات الخط العريض**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // تعيين خصائص الخط لجزء النص.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![خصائص الخط لأجزاء النص](font_properties_for_text_portions.png)

## **تعيين دوران النص**

استخدم طريقة [TextFrameFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` لتعيين اتجاه نص مسبق داخل الشكل.

يعين مثال الشيفرة التالي اتجاه النص في الشكل إلى `Vertical270`، مما يدير النص **90 درجة عكس اتجاه عقارب الساعة**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![دوران النص](text_rotation.png)

## **تعيين دوران مخصص لإطارات النص**

استخدم طريقة [TextFrameFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/)`::setRotationAngle` لتعيين زاوية دوران مخصصة لـ [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/).

يدور مثال الشيفرة أدناه إطار النص بمقدار 3 درجات مع اتجاه عقارب الساعة داخل الشكل:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![دوران النص المخصص](custom_text_rotation.png)

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides طرق [ParagraphFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`، `ParagraphFormat::setSpaceBefore`، و `ParagraphFormat::setSpaceWithin` للتحكم في تباعد الفقرات. تُستخدم هذه الطرق كالتالي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

يعرض مثال الشيفرة التالي كيفية تحديد تباعد السطر داخل الفقرة:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![تباعد الأسطر داخل الفقرة](line_spacing.png)

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

طريقة [TextFrameFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/)`::setAutofitType` تحدد سلوك النص عندما يتجاوز حدود حاويته. استخدمها للتحكم فيما إذا كان النص سيصغر، سيتدفق، أو سيعيد حجم الشكل تلقائيًا.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعيين تثبيت إطارات النص**

طريقة [TextFrameFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/)`::setAnchoringType` تحدد كيف يتم وضع النص عموديًا داخل الشكل، على سبيل المثال في الأعلى، الوسط، أو الأسفل.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعيين تبويب النص**

استخدم طريقة [ParagraphFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` ومجموعتها من التبويبات لتكوين نقاط التبويب في الفقرة.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![تبويبات الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides طريقة [BasePortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/)`::setLanguageId` التي تتيح لك تعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والقواعد في PowerPoint.

يعرض مثال الشيفرة التالي كيفية تعيين لغة التدقيق لجزء النص:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // تعيين معرف لغة التدقيق.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعيين اللغة الافتراضية**

استخدم طريقة [LoadOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` لتحديد اللغة الافتراضية للنص الذي يتم إنشاؤه أثناء تحميل أو إنشاء عرض تقديمي.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل مستطيل جديد مع نص.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // فحص لغة الجزء الأول.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم نمط النص الافتراضي في [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/).

يعرض مثال الشيفرة التالي كيفية تعيين خط عريض افتراضي بحجم 14 نقطة لجميع النصوص عبر الشرائح في عرض تقديمي جديد.

```php
$presentation = new Presentation();
try {
    // احصل على تنسيق الفقرة المستوى الأعلى.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **استخراج النص مع تأثير الأحرف الكبيرة كلها**

في PowerPoint، تطبيق تأثير الخط **All Caps** يجعل النص يظهر بأحرف كبيرة على الشريحة حتى وإن تم كتابته أصلاً بأحرف صغيرة. عند استرجاع جزء نص كهذا باستخدام Aspose.Slides، تُرجع المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textcaptype/) وحول السلسلة المرجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

لنفترض أن لدينا صندوق النص التالي في الشريحة الأولى من ملف sample2.pptx.

![تأثير الأحرف الكبيرة كلها](all_caps_effect.png)

يعرض مثال الشيفرة التالي كيفية استخراج النص مع تطبيق تأثير **All Caps**:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

الناتج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة المتكررة**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/table/). قم بالتنقل عبر الخلايا وتحديث كل خلية عبر إطار النص الخاص بـ [Cell](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cell/) وتنسيق الفقرة عبر تنسيق الفقرة لـ [Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/).

**كيف يتم تطبيق لون متدرج على النص في شريحة PowerPoint؟**

لتطبيق لون متدرج على النص، استخدم تنسيق التعبئة في [PortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/). اضبط نوع التعبئة في [FillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fillformat/) إلى [FillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/) `Gradient` وقم بتكوين نقاط التدرج، الاتجاه، والشفافية.