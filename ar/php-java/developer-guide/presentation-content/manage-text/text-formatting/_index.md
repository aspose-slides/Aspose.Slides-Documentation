---
title: تنسيق نص العرض التقديمي في PHP
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/php-java/text-formatting/
keywords:
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
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة PHP عبر Java. خصّص الخطوط والألوان والمحاذاة والمزيد."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ PHP عبر Java. تغطي ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، نقاط التبويب، وإعدادات اللغة.

ما لم يذكر خلاف ذلك، تستخدم الأمثلة الملف [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو صندوق نص، ويحتوي الفقرة الأولى على النص الموضح أدناه. كل من فهارس الشرائح والأشكال تبدأ من الصفر. الأمثلة التي تحدد أجزاء بالخط العريض تستخدم تنسيقًا فعالًا، بما في ذلك تنسيق الخط العريض الموروث:

![نص العينة](sample_text.png)

للعثور على النص الحرفي أو مطابقة تعبيرات عادية وتظليلهما، راجع [البحث واستبدال النص](/slides/ar/php-java/search-and-replace-text/).

## **ضبط لون خلفية النص**

استخدم [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) لأجزاء النص الفردية.

المثال التالي يضبط تظليلًا رماديًا فاتحًا كافتراضي للفقرة الأولى. الألوان المحددة صراحةً لأجزاء النص الفردية لها أولوية على هذا الافتراضي:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // تعيين لون التظليل للفقرة بأكملها.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

يوضح مثال الشيفرة أدناه كيفية ضبط لون الخلفية **لأجزاء النص ذات الخط العريض**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // تعيين لون التظليل لجزء النص.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
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

استخدم [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزية، محاذية إلى اليسار، محاذية إلى اليمين، مبررة، وما إلى ذلك.

المثال التالي يظهر كيفية محاذاة الفقرة إلى **المركز**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // تعيين محاذاة الفقرة إلى الوسط.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الفقرة المحاذاة](aligned_paragraph.png)

## **محاذاة الخطوط داخل سطر**

استخدم [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) لمحاذاة أجزاء النص ذات الأحجام المختلفة للخط عمودياً داخل سطر. ينطبق هذا الإعداد على الفقرة بأكملها ويتحكم في محاذاة كل سطر منها.

المثال المستقل التالي ينشئ أربعة صناديق نصية معنونة على شريحة واحدة. كل فقرة تحتوي على نفس النص بأحجام 18، 36، و54 نقطة، مع محاذاة خط مختلفة. يستخدم Arial، ويعطل الملاءمة التلقائية واللف، ويحافظ على إطارات النص كبيرة بما يكفي لسطر واحد.

```php
use aspose\slides\FillType;
use aspose\slides\FontAlignment;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $alignments = [FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom];
    $alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    $fontSizes = [18, 36, 54];
    $font = new FontData("Arial");
    $gray = java("java.awt.Color")->GRAY;
    $black = java("java.awt.Color")->BLACK;

    for ($i = 0; $i < count($alignments); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20 + $i * 130, 660, 120);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);

        $label = $textFrame->getParagraphs()->get_Item(0);
        $label->setText($alignmentNames[$i]);
        $label->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($gray);

        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setFontAlignment($alignments[$i]);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

        foreach ($fontSizes as $fontSize) {
            $portion = new Portion("Ag ");
            $portion->getPortionFormat()->setFontHeight($fontSize);
            $paragraph->getPortions()->add($portion);
        }

        $textFrame->getParagraphs()->add($paragraph);
    }

    $presentation->save("font_alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![مقارنة بين محاذاة الخط من الخط الأساسي، الأعلى، الوسط، والأسفل مع أحجام خطوط مختلطة](font_alignment.png)

تستخدم محاذاة الخط مقاييس الخط، لذا قد لا تتطابق الحواف المرئية للأحرف الفردية بشكل تام. يتضمن المثال حرفًا كبيرًا وحرفًا منخفضًا لتوضيح الفرق بين محاذاة الخط الأساسي والمحاذاة السفلية. توافر الخط واستبداله، الأحرف المستخدمة، واختلاف أحجام الخط تؤثر على النتيجة. أبعاد الإطار، الهوامش، تباعد الأسطر، اللف، والملاءمة التلقائية تؤثر أيضًا على التخطيط؛ استخدم نفس الخطوط وإعدادات التخطيط عند مقارنة الأنماط.

هذا الإعداد يختلف عن [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment)، الذي يتحكم في محاذاة الفقرة أفقياً، و[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType)، الذي يضع كتلة النص رأسياً داخل الشكل. تنسيق الأس superscript وsubscript عبر [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) يزيح أجزاء النص الفردية بالنسبة للخط الأساسي بدلاً من ضبط محاذاة الخط لأسطر الفقرة.

## **ضبط شفافية النص**

تُتحكم شفافية النص عبر المكوّن ألفا للون المعين إلى [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0–255، وليس نسبة شفافية.

مثال الشيفرة التالي يوضح كيفية تطبيق شفافية على **الفقرة بأكملها**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // تعيين لون تعبئة النص إلى لون شفاف.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

المثال التالي يوضح كيفية تطبيق شفافية على **أجزاء النص ذات الخط العريض**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // تعيين شفافية جزء النص.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![أجزاء النص الشفافة](transparent_text_portions.png)

## **ضبط تباعد الأحرف للنص**

استخدم [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) لتوسيع أو تقليل التباعد بين الأحرف في صندوق نص. تضيف الأمثلة 3 نقاط من التباعد؛ القيم السالبة تقلل من التباعد.

الكود PHP التالي يوضح كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
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

مثال الشيفرة أدناه يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

### **تعطيل Kerning لبعض الخطوط**

في بعض الحالات، قد يبدو النص المُنتج بواسطة Aspose.Slides أكثر ضغطًا قليلًا مقارنةً بالنص نفسه في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات الـ kerning لبعض الخطوط، حتى عندما يحتوي الخط على معلومات kerning صالحة وتكون الـ kerning مفعلة في إعدادات PowerPoint.

لجعل الإخراج المطبوع أقرب إلى PowerPoint في مثل هذه الحالات، يمكنك تعطيل الـ kerning لأجزاء النص التي تستخدم الخط المتأثر. اضبط [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) إلى قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال ملف "presentation.pptx" يحتوي على صندوق نص كشكل أول في الشريحة الأولى. يتحقق من أسماء الخطوط الفعالة، بما في ذلك الخطوط الموروثة، ويضبط عتبة 100 نقطة للأجزاء التي تستخدم Roboto. هذا يعطل الـ kerning للأجزاء المطابقة التي يقل حجم الخط عنها 100 نقطة:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

بالنسبة للنص المطابق الذي يقل عن العتبة، يمنع هذا الإعداد الـ kerning ويمكن أن يساعد في تقارب مخرجات Aspose.Slides مع مظهر PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن ضبط خصائص الخط على مستوى الفقرة عبر [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) أو على أجزاء فردية عبر [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

المثال التالي يضبط الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع تنسيق عريض، مائل، وتسطير منقط. التنسيق الصريح على أجزاء النص الفردية له أولوية على هذه القيم الافتراضية:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // تعيين خصائص الخط للفقرة.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![خصائص الخط للفقرة](font_properties_for_paragraph.png)

المثال التالي يطبق Times New Roman بحجم 13 نقطة، تنسيق مائل، وتسطير منقط على الأجزاء التي يكون تنسيقها الفعّال عريضًا:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // تعيين خصائص الخط لجزء النص.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![خصائص الخط لأجزاء النص](font_properties_for_text_portions.png)

## **التحكم في تطبيع ارتفاع النص**

استخدم [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) عند إعادة إنتاج طباعة القالب أو دراسة اختلافات ارتفاع الأحرف. في PowerPoint، تمكين التطبيع يمدد أو يضغط الأحرف فرديًا عموديًا لتمنحها ارتفاعًا مرئيًا موحدًا داخل جزء النص. لا يضمن ذلك تساوي ارتفاع النص عبر خطوط مختلفة.

اضبط الخاصية إلى [NullableBool::True أو False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) لتمكين أو تعطيل التطبيع صراحةً. `NullableBool::NotDefined` يترك الإعداد المحلي غير محدد بحيث يرث الجزء قيمته، مثالًا من [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) للفقرة. لا يعني ذلك `False`. استخدم [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) واقرأ `getNormaliseHeight` على بيانات التنسيق الفعّال المسترجعة للحصول على القيمة المنطقية المحسوبة.

المثال المستقل التالي يتطلب تثبيت **Arial**. ينشئ كُتلتي نص تحتويان على نفس الحروف الكبيرة، الصغيرة، الأحرف ذات الخطّ المتدلي، والحروف المشكولة بحجم 54 نقطة. تمكّن الفقرتان التطبيع افتراضيًا. الجزء العلوي يعطل التطبيع صراحةً؛ الجزء السفلي يرثه. أبعاد الإطارات، الهوامش، وتباعد الفقرات متماثلة، مع تعطيل اللف والملاءمة التلقائية للحفاظ على المقارنة ثابتة. يطبع المثال `False: false` و`NotDefined: true`، ثم يحفظ "text_height_normalization.pptx".

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $settings = [NullableBool::False, NullableBool::NotDefined];
    $settingNames = ["False", "NotDefined"];

    for ($i = 0; $i < count($settings); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 60 + $i * 200, 660, 150);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->setText("Hxgjpq ÅÉ 0123");
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setMarginTop(0);
        $textFrame->getTextFrameFormat()->setMarginLeft(0);

        $paragraph = $textFrame->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $paragraph->getParagraphFormat()->setSpaceWithin(100);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setNormaliseHeight(NullableBool::True);

        $portion = $paragraph->getPortions()->get_Item(0);
        $font = new FontData("Arial");
        $portion->getPortionFormat()->setLatinFont($font);
        $portion->getPortionFormat()->setFontHeight(54);
        $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $portion->getPortionFormat()->setNormaliseHeight($settings[$i]);

        $normaliseHeight = java_values($portion->getPortionFormat()->getEffective()->getNormaliseHeight());
        echo $settingNames[$i], ": ", $normaliseHeight ? "true" : "false", PHP_EOL;
    }

    $presentation->save("text_height_normalization.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

المقارنة أدناه تم تصديرها من العرض المحفوظ. الصف العلوي به التطبيع معطل (`False`)؛ الصف السفلي يرث الإعداد الممكّن (`NotDefined` → `True`). حافظ على تثبيت Arial لتعيد إنشاء هذا الشكل.

![نص Arial بحجم 54 نقطة مع التطبيع معطل في الأعلى ومُمكّن بالوراثة في الأسفل](text_height_normalization.png)

يغيّر التطبيع ارتفاع الأحرف دون تغيير قيمة [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight) المعينة، التي تحدد حجم الخط بالنقاط. يتحكم [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) في تباعد الأسطر، بينما يتحكم [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) في كيفية تعديل حجم النص أو حاويته للتناسب. لهذه الإعدادات أغراض مختلفة ويمكن أن تؤثر على التخطيط العام بصورة مستقلة. لمزيد من المعلومات حول تنسيق الفقرات والوراثة، راجع [إدارة الفقرات](/slides/ar/php-java/manage-paragraph/).

## **تطبيق وإزالة الخط عبر النص (Strikethrough)**

استخدم [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) على جزء نص لتظهر التصحيحات أو المصطلحات الملغى أو الأسعار السابقة دون حذف النص الأصلي. اضبطه إلى [TextStrikethroughType::Single أو Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) للحصول على خط واحد أو مزدوج عبر النص.

لإزالة الخط عبر النص، مرّر [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None). هذا يعطل التأثير صراحةً، حتى وإن كان التنسيق المحيط يحدده. بالمقابل، [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) يترك الإعداد المحلي غير معرف، ما يسمح للجزء بورث التنسيق، مثالًا من الفقرة. لا يضمن ذلك إزالة الخط عبر النص. استخدم [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) لقراءة التنسيق الناتج، بما في ذلك القيم الموروثة.

المثال المستقل التالي ينشئ ثلاث مقارنات أسعار. كل فقرة تحتوي على أجزاء منفصلة للعلامة، السعر السابق، والسعر الحالي، بحيث يتأثر السعر السابق فقط. الصف الأول يطبق ثم يزيل الخط عبر النص؛ الصفوف الأخرى تحتفظ بخط عبر نص أحد أو مزدوج. تغيير هذا الإعداد يحافظ على النص وتنسيقه الآخر، بما في ذلك السعر السابق العريض.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextStrikethroughType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $labels = [ "None: ", "Single: ", "Double: " ];

    foreach ($labels as $label) {
        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceAfter(20);

        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $format->setFontHeight(28);
        $font = new FontData("Arial");
        $format->setLatinFont($font);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $blackColor = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($blackColor);

        $labelPortion = new Portion($label);
        $paragraph->getPortions()->add($labelPortion);

        $previousPrice = new Portion("$100");
        $previousPrice->getPortionFormat()->setFontBold(NullableBool::True);
        $paragraph->getPortions()->add($previousPrice);
        $currentPrice = new Portion(" → $80");
        $paragraph->getPortions()->add($currentPrice);

        $shape->getTextFrame()->getParagraphs()->add($paragraph);
    }

    $paragraphs = $shape->getTextFrame()->getParagraphs();

    // تطبيق خط عبر النص، ثم إزالته صراحةً من السعر السابق الأول.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة من الأعلى إلى الأسفل: لا خط عبر النص، خط عبر نص واحد، وخط عبر نص مزدوج.

![الأسعار السابقة بدون خط عبر النص، بخط واحد، وبخط مزدوج](strikethrough.png)

## **ضبط دوران النص**

استخدم [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) لتعيين اتجاه نص مسبق التعريف داخل شكل.

المثال التالي يضبط اتجاه النص في الشكل إلى [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/)، مما يدير النص **90 درجة عكس عقارب الساعة**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![دوران النص](text_rotation.png)

## **عرض الأرقام جنبًا إلى جنب في النص العمودي**

لإبقاء رقم مكوّن من رقمين معًا في تسمية يابانية عمودية، ضع كلا الرقمان في جزء نص واحد واستدعِ [BasePortionFormat::setKumimoji](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKumimoji) على ذلك الجزء. يستخدم المثال [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical) وخط MS Gothic بحجم 40 نقطة لكلا التسميتين. يختلف فقط قيمة [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) الممررة إلى الجزء الرقمي.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 120;

    foreach ([NullableBool::True, NullableBool::False] as $kumimoji) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 48, 120, 420);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $frame = $label->addTextFrame("");
        $frame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::EastAsianVertical);

        $paragraph = $frame->getParagraphs()->get_Item(0);
        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $font = new FontData("MS Gothic");
        $format->setLatinFont($font);
        $format->setEastAsianFont($font);
        $format->setFontHeight(40);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($black);

        $digits = new Portion("12");
        $digits->getPortionFormat()->setKumimoji($kumimoji);

        $portions = $paragraph->getPortions();
        $portions->clear();
        $portions->add(new Portion("令和"));
        $portions->add($digits);
        $portions->add(new Portion("年"));

        $x += 240;
    }
    $presentation->save("vertical_date.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

في PowerPoint، يظهر التسمية اليسرى (`True`) الأرقام واقفةً جنبًا إلى جنب بين 和 و 年. في التسمية اليمنى (`False`)، يتم تدوير الزوج 90 درجة مع اتجاه عقارب الساعة. تظل الأحرف اليابانية المحيطة واقفةً في كلا التسميتين.

![مقارنة PowerPoint لتسميات التاريخ العمودية مع أرقام قائمة على اليسار ومائلة على اليمين](vertical_date.png)

## **ضبط دوران مخصص لإطارات النص**

استخدم [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) لتعيين زاوية دوران مخصصة لـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

مثال الشيفرة التالي يدور إطار النص بمقدار 3 درجات في اتجاه عقارب الساعة داخل الشكل:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![الدوران المخصص للنص](custom_text_rotation.png)

## **ضبط تباعد الأسطر للفقرات**

توفر Aspose.Slides [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore)، و[ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) للتحكم في تباعد الفقرات. تُستخدم هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد الأسطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد الأسطر بالنقاط.

المثال التالي يضبط التباعد داخل الفقرة الأولى إلى 200٪ من ارتفاع السطر (تباعد مزدوج):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![تباعد الأسطر داخل الفقرة](line_spacing.png)

## **التحكم في كسر الأسطر**

قواعد كسر الأسطر للفقرة مفيدة في كُتل نص ضيقة وعروض تقديمية تمزج بين النص اللاتيني والآسيوي الشرقي. الطرق التالية تنتمي إلى [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/)، لذا فهي تنطبق على الفقرة بأكملها:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) يتحكم في قواعد كسر الأسطر للخط اللاتيني. في النص المختلط، قد يغيّر ذلك موضع كسر الأسطر للنص الآسيوي الشرقي وعلامات الترقيم المجاورة.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) يتحكم في قواعد كسر الأسطر للآسيوي الشرقي، بما في ذلك القيود على الأحرف في بداية أو نهاية السطر.

لا تحل هذه القواعد محل [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText)، الذي يفعِّل اللف التلقائي داخل إطار النص. هي تؤثر على التخطيط عندما يحدث اللف؛ لا تُدرج أحرف كسر السطر. كسر سطر صريح يُضيف سطرًا جديدًا داخل الفقرة بغض النظر عن العرض المتاح.

المثال المستقل التالي ينشئ كتلة نصية ضيقة تحتوي على صيني ولاتيني. يضبط كلا خيارَي كسر الأسطر صراحةً ويحفظ "line_breaking.pptx". لتجربة أي من القاعدتين، غير القيمة المقابلة مع الإبقاء على الأخرى ثابتة. يستخدم المثال Arial بحجم 24 نقطة وSimSun، وعرض إطار 160 نقطة وهوامش أفقية صفرية. يُستدعى [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) مع [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) حتى يبقى حجم النص وأبعاد الإطار ثابتين.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **التحكم في علامات الترقيم المعلقة**

يتيح [ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) للعلامات المؤهلة أن تمتد إلى ما وراء الحافة اليمنى لسطر النص بدلاً من الانتقال إلى السطر التالي. ينطبق على الفقرة بأكملها وهو مختلف عن الهوامش المعلقة.

المثال المستقل التالي يُفعِّل علامات الترقيم المعلقة في إطار نص عرضه 100 نقطة ويحفظ "hanging_punctuation.pptx". مع Arial بحجم 24 نقطة وهوامش أفقية صفرية، يبقى النقطة الأخيرة بعد كلمة "sentence" وتمتد إلى ما وراء حافة النص اليمنى. اضبط الخاصية إلى [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) للمقارنة: بهذه الإعدادات، تشغل النقطة سطرًا منفصلًا. تمكين اللف وتعطيل الملاءمة التلقائية للحفاظ على العرض المتاح ثابتًا.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ليس كل رمز ترقيم يمكنه التعليق. تنطبق شروط الخط والتخطيط المذكورة في [التحكم في كسر الأسطر](#control-line-breaking) أيضًا على هذه المقارنة: تغيير الخط، العرض المتاح، الهوامش، أو إعدادات الملاءمة التلقائية يمكن أن يزيل الفرق المرئي.

## **ضبط نوع الملاءمة التلقائية لإطارات النص**

يحدد [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص ينكمش، يتجاوز، أو يغيّر حجم الشكل تلقائيًا. المثال التالي يضبط الشكل ليتغيّر حجمه ليتناسب مع النص ويحفظ النتيجة إلى "autofit_type.pptx".

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

لحساب عدد السطور بعد اللف التلقائي ومعرفة كيف يتغير عرض النص أو الشكل، راجع [Count Rendered Lines](/slides/ar/php-java/manage-paragraph/). عدد السطور لا يُظهر إن كان النص يتجاوز حاويته أم لا.

## **ضبط تثبيت إطارات النص**

يُعرّف [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) كيفية وضع النص عموديًا داخل الشكل، مثل الأعلى، الوسط، أو الأسفل. المثال التالي يثبت النص إلى أسفل الشكل الأول ويحفظ النتيجة إلى "text_anchor.pptx".

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ضبط تبويب النص**

استخدم [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) و[ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) لتكوين نقاط التبويب في فقرة. المثال التالي يضبط الفاصل الافتراضي إلى 100 نقطة ويضيف نقطة تبويب محاذية إلى اليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![نقاط تبويب الفقرة](paragraph_tabs.png)

## **ضبط لغة التدقيق**

توفر Aspose.Slides [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)، والتي تسمح بتعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لفحص الإملاء والقواعد النحوية في PowerPoint.

المثال التالي يتطلب "presentation.pptx" مع صندوق نص كشكل أول في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتوى الفقرة الأولى بـ "1。"، يضبط SimSun كخط لها، ويُعيّن لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة إلى "proofing_language.pptx":

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // تعيين معرف لغة التدقيق.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **نسخ بيانات اللغة الوصفية**

عند نسخ نص متعدد اللغات من قالب، احفظ كلًّا من [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) و[BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). المثال المستقل التالي ينشئ جزء مصدر بلغة إنجليزية أمريكية كلغة أساسية وفرنسية كلغة بديلة، وينسخ النص والمعرفات إلى جزء في عرض تقديمي جديد.

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$source = new Portion("Hello! Bonjour!");
$source->getPortionFormat()->setLanguageId("en-US");
$source->getPortionFormat()->setAlternativeLanguageId("fr-FR");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $destination = new Portion();
    $destination->setText($source->getText());
    $destination->getPortionFormat()->setLanguageId($source->getPortionFormat()->getLanguageId());
    // إذا لم يكن للمصدر لغة بديلة، فإن null يمسح قيمة الوجهة.
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

لتجربة مصدر بدون لغة بديلة، احذف تعيين `"fr-FR"`. يصبح المعرف البديل `null`، ويحافظ بيان النسخ نفسه على غيابه دون إدخال قيمة افتراضية، حتى إذا كانت الوجهة قد عيّنت لغة بديلة مسبقًا.

هذه المعرفات تُخزَّن كبيانات وصفية للغة. حفظها لا يحدِّد أي معجم سيختاره PowerPoint للتدقيق الإملائي أو النحوي.

## **ضبط اللغة الافتراضية**

استخدم [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) لتعريف اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي ينشئ عرضًا تقديميًا بلغة إنجليزية أمريكية كنص افتراضي، يضيف صندوق نص، ويطبع `en-US` للجزء النصي الأول.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // إضافة شكل مستطيل جديد مع نص.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // تحقق من لغة الجزء الأول.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **ضبط نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض، استخدم [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle).

المثال التالي يضبط خطًا عريضًا بحجم 14 نقطة كإعداد افتراضي للفقرات من المستوى العلوي في عرض تقديمي جديد ويحفظه إلى "default_text_style.pptx". يمكن للنص أن يرث هذه الإعدادات ما لم يتجاوزها تنسيق أكثر تحديدًا.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **استخراج النص مع تأثير All-Caps**

في PowerPoint، يجعل تطبيق تأثير الخط **All Caps** النص يظهر بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عندما تسترجع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما أُدخل. لمطابقة النص المعروض، راجع [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) وحوّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

هذا المثال يتطلب "sample2.pptx" مع صندوق نص كشكل أول في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على "Hello, Aspose!" مع تطبيق تأثير All Caps، كما هو موضح أدناه.

![تأثير All Caps](all_caps_effect.png)

مثال الشيفرة أدناه يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
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

لتعديل النص في جدول على شريحة، استخدم [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). قم بالتكرار عبر الخلايا وقم بتحديث كل خلية عبر [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) وتنسيق الفقرة عبر [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat).

**كيف يمكن تطبيق لون تدرج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). اضبط [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) إلى [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) وقم بتكوين نقاط التدرج، الاتجاه، والشفافية.