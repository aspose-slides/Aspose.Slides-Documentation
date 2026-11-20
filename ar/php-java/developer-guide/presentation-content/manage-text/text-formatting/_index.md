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
- تباعد السطر
- خاصية الملاءمة التلقائية
- مرساة إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تنسيق وتنسيق نصوص في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للغة PHP عبر Java. خصّص الخطوط والألوان والمحاذاة وغير ذلك."
---
## **نظرة عامة**

تُظهر هذه المقالة كيفية تنسيق النص في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. تُغطي ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، مواضع علامات التبويب، وإعدادات اللغة.

ما لم يُذكر خلاف ذلك، تستخدم الأمثلة [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو مربع نص، ويحتوي الفقرة الأولى على النص الموضح أدناه. كل من مؤشرات الشرائح والأشكال تبدأ من الصفر. الأمثلة التي تُحدِّد أجزاءً بالخط العريض تستخدم تنسيقًا فعالًا، بما في ذلك تنسيق الخط العريض الموروث:

![نص عينة](sample_text.png)

للعثور على النص الحرفي أو مطابقة التعبير النمطي وتظليله، راجع [Search and Replace Text](/slides/ar/php-java/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) لأجزاء النص الفردية.

المثال التالي يعيّن تظليلًا رماديًا فاتحًا كافتراضي للفقرة الأولى. تُعطى ألوان التظليل الصريحة على الأجزاء الفردية أولوية على هذا الافتراضي:

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

يوضح مثال الشيفرة أدناه كيفية تعيين لون الخلفية **لأجزاء النص ذات الخط العريض**:

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

استخدم [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزية، متمحرفة إلى اليسار، متمحرفة إلى اليمين، مبررة، وما إلى ذلك.

المثال التالي يوضح كيفية محاذاة الفقرة إلى **الوسط**:

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

## **محاذاة الخطوط داخل السطر**

استخدم [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) لمحاذاة أجزاء النص ذات الأحجام الخطية المختلفة عموديًا داخل سطر. يُطبق هذا الإعداد على الفقرة بأكملها ويتحكم في المحاذاة داخل كل سطر منها.

المثال التالي يخلق أربعة مربعات نص مُعنونة على شريحة واحدة. كل فقرة تحتوي على نفس النص بحجم 18، 36، و54 نقطة، مع محاذاة خط مختلفة. يستخدم الخط Arial، ويعطل الملاءمة التلقائية واللف، ويحافظ على إطارات النص كبيرة بما يكفي لسطر واحد.

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

![مقارنة بين محاذاة الخط القاعدية، العليا، الوسطى، والسفلية مع أحجام خطوط مختلطة](font_alignment.png)

محاذاة الخط تستخدم مقاييس الخط، لذا قد لا تتطابق الحواف المرئية للأحرف الفردية تمامًا. يتضمن المثال حرفًا كبيرًا وحرفًا منخفضًا لتوضيح الفرق بين المحاذاة القاعدية والسفلية. تتأثر النتيجة بتوفر الخطوط والاستبدال، الأحرف المستخدمة، والفرق في أحجام الخط. كما تؤثر أبعاد الإطار وهوامش الفقرة وتباعد السطر واللف والملاءمة التلقائية على التخطيط؛ استخدم نفس الخطوط وإعدادات التخطيط عند مقارنة الأوضاع.

يختلف هذا الإعداد عن [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) الذي يتحكم في محاذاة الفقرة الأفقية، وعن [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) الذي يحدد موضع كتلة النص عموديًا داخل الشكل. تنسيق النص العلوي والسفلي عبر [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) يُحَرّك الأجزاء الفردية نسبة إلى القاعدة بدلًا من تعيين محاذاة الخط لأسطر الفقرة.

## **تعيين الشفافية للنص**

تُتحكم شفافية النص من خلال مكوّن ألفا للون المعين إلى [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا بنظام ARGB على مقياس 0–255، وليس نسبة شفافية.

يوضح مثال الشيفرة أدناه كيفية تطبيق الشفافية على **الفقرة بأكملها**:

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

المثال التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط العريض**:

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

## **تعيين تباعد الأحرف للنص**

استخدم [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) لتوسيع أو تقليص التباعد بين الأحرف في مربع نص. تُضيف الأمثلة 3 نقاط من التباعد؛ القيم السالبة تُقلّص النص.

الكود PHP التالي يُظهر كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

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

مثال الشيفرة أدناه يُظهر كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

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

### **تعطيل الكيرنينغ للخطوط المحددة**

في بعض الحالات، قد يبدو النص المطبوع بواسطة Aspose.Slides أكثر ضيقًا قليلاً من النص نفسه المعروض في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات الكيرنينغ لبعض الخطوط، حتى عندما يحتوي الخط على معلومات كيرنينغ صالحة وتم تمكين الكيرنينغ في إعدادات PowerPoint.

لجعل المخرجات المرسومة أقرب إلى PowerPoint في مثل هذه الحالات، يمكنك تعطيل الكيرنينغ لأجزاء النص التي تستخدم الخط المتأثر. اضبط [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) على قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال ملف "presentation.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى. يتحقق من أسماء الخطوط الفعّالة، بما في ذلك الخطوط الموروثة، ويحدد حدًا قدره 100 نقطة للأجزاء التي تستخدم Roboto. هذا يعطل الكيرنينغ للأجزاء المطابقة ذات حجم الخط أقل من 100 نقطة:

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

بالنسبة للنص المطابق الذي يكون دون الحد، يمنع هذا الإعداد الكيرنينغ ويمكن أن يساعد في تقريب مخرجات Aspose.Slides إلى العرض البصري لـ PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) أو على الأجزاء الفردية عبر [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

المثال التالي يعيّن الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع تنسيق عريض، مائل، وتسطير منقط. يتفوق التنسيق الصريح على الأجزاء الفردية على هذه القيم الافتراضية.

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

استخدم [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) عند إعادة إنتاج طباعيات القالب أو فحص الاختلافات في ارتفاع الأحرف. في PowerPoint، يؤدي تمكين التطبيع إلى تمديد أو ضغط الأحرف الفردية رأسيًا لمنحها ارتفاع مرئي موحد داخل جزء النص. لا يضمن ذلك تساوي ارتفاع النص عبر خطوط مختلفة.

عيّن الخاصية إلى [NullableBool::True أو False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) لتمكين أو تعطيل التطبيع صراحة. يترك `NullableBool::NotDefined` الإعداد المحلي غير محدد بحيث يرث الجزء قيمته، على سبيل المثال من [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) الخاص بالفقرة. لا يعني ذلك `False`. استخدم [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) واقرأ `getNormaliseHeight` في البيانات الفعّالة للحصول على القيمة البوليانية المحلولة.

المثال التالي المستقل يتطلب تثبيت خط **Arial**. يخلق كتلتين نصيتين تحتويان على نفس الأحرف الكبيرة والصغيرة، الحروف السفلية، والحروف المتقطعة بحجم 54 نقطة. تُفعَّل التطبيع في كلتا الفقرتين افتراضيًا. تُعطَّل الجزء العلوي صراحةً، بينما يرث الجزء السفلي الإعداد. أحجام الإطار، الهوامش، وتباعد الفقرات متماثلة، مع تعطيل اللف والملاءمة التلقائية للحفاظ على مقارنة ثابتة. يطبع المثال `False: false` و `NotDefined: true`، ثم يحفظ "text_height_normalization.pptx".

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

المقارنة أدناه تم تصديرها من العرض المحفوظ. الصف العلوي لديه التطبيع معطل (`False`)؛ الصف السفلي يرث الإعداد المفعَّل (`NotDefined` → `True`). حافظ على تثبيت Arial لإعادة إنتاج هذا الشكل.

![نص Arial بحجم 54 نقطة مع التطبيع معطل في الأعلى ومُرث في الأسفل](text_height_normalization.png)

التطبيع يغيّر ارتفاع الأحرف دون تغيير قيمة [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight) المعينة، التي تحدد حجم الخط بالنقاط. يتحكم [setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) في الفقرة في تباعد السطر، بينما يتحكم [setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) لإطار النص في كيفية تعديل النص أو حاويته لتلائم. تخدم هذه الإعدادات أغراضًا مختلفة ويمكن أن تؤثر على التخطيط العام بشكل مستقل. للمزيد عن تنسيق الفقرات والوراثة، راجع [Manage Paragraph](/slides/ar/php-java/manage-paragraph/).

## **تطبيق وإزالة الخط المشطوب**

استخدم [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) على جزء نص لإظهار تصحيحات أو مصطلحات ملغاة أو أسعار سابقة دون حذف النص الأصلي. اضبطه إلى [TextStrikethroughType::Single أو Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) لسطر واحد أو مزدوج عبر النص.

لإزالة الخط المشطوب، مرّر [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None). هذا يعطل التأثير صراحةً، حتى إذا كان التنسيق المحيط يحدد الخط المشطوب. بالمقابل، يترك [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) الإعداد المحلي غير معرف، مما يسمح للجزء بوراثة التنسيق، على سبيل المثال من الفقرة. لا يضمن ذلك إزالة الخط المشطوب. استخدم [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) لقراءة التنسيق الناتج، بما في ذلك القيم الموروثة.

المثال المستقل التالي يُنشئ ثلاث مقارنات أسعار. كل فقرة لديها أجزاء منفصلة للملصق، السعر السابق، والسعر الحالي، بحيث يتأثر السعر السابق فقط. الصف الأول يطبق ثم يزيل الخط المشطوب؛ الصفوف الأخرى تحتفظ بالخط المشطوب الأحادي والمزدوج. تغيير هذا الإعداد يحافظ على النص وتنسيقه الآخر، بما في ذلك السعر السابق العريض.

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

    // تطبيق الخط المشطوب، ثم إزالته صراحة من السعر السابق الأول.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة، من الأعلى إلى الأسفل: بدون خط مشطوب، خط مشطوب أحادي، وخط مشطوب مزدوج.

![الأسعار السابقة بدون خط مشطوب، مع خط مشطوب أحادي، ومع خط مشطوب مزدوج](strikethrough.png)

## **تعيين دوران النص**

استخدم [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) لتعيين توجيه نص مُعرّف مسبقًا داخل شكل.

المثال التالي يعيّن توجيه النص في الشكل إلى [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/)، والذي يدور النص **90 درجة عكس عقارب الساعة**:

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

## **تعيين دوران مخصص لإطارات النص**

استخدم [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) لتعيين زاوية دوران مخصصة لـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

المثال التالي يدور إطار النص بمقدار 3 درجات باتجاه عقارب الساعة داخل الشكل:

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

![دوران النص المخصص](custom_text_rotation.png)

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore)، و[ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) للتحكم في تباعد الفقرات. تُستَخدم هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

المثال التالي يعيّن التباعد داخل الفقرة الأولى إلى 200% من ارتفاع السطر (تباعد مزدوج):

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

![تباعد السطر داخل الفقرة](line_spacing.png)

## **التحكم في كسر السطر**

قواعد كسر سطر الفقرة مفيدة في كتل نص ضيقة وعروض تقديمية تمزج بين النص اللاتيني والنص الآسيوي الشرقي. الطرق التالية تنتمي إلى [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/)، لذا فهي تنطبق على الفقرة بأكملها:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) يتحكم في قواعد كسر سطر النص اللاتيني. في النص المختلط، قد يغيّر هذا أيضًا موضع التفاف النص والرموز الشرقية المجاورة.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) يتحكم في قواعد كسر سطر النص الآسيوي الشرقي، بما في ذلك القيود على الأحرف في بداية ونهاية السطر.

هذه القواعد لا تحل محل [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText)، الذي يُمكِّن اللف التلقائي داخل إطار النص. إنها تؤثر على التخطيط عندما يحدث اللف؛ لا تُدرج أحرف كسر السطر. كسر سطر صريح يفرض سطرًا جديدًا داخل الفقرة مستقلاً عن العرض المتاح.

المثال المستقل التالي يخلق كتلة نص ضيقة تحتوي على صيني ولاتيني. يحدد كلا خيارَي كسر السطر صراحةً ويحفظ "line_breaking.pptx". لتجربة أي قاعدة، غير القيمة المقابلة مع الحفاظ على الإعدادات الأخرى ثابتة. يستخدم المثال Arial بحجم 24 نقطة وSimSun مع عرض إطار 160 نقطة وهامش أفقي صفري لإطار النص. يُستدعى [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) مع [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) بحيث يبقى حجم النص وإطار الشكل ثابتين.

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

## **التحكم في علامات الترقيم المتدلية**

يتيح [ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) للعلامات الترقيمية المؤهلة أن تمتد إلى ما بعد الحافة اليمنى لسطر النص بدلاً من احتلال السطر التالي. ينطبق ذلك على الفقرة بأكملها ويختلف عن مسافة بادئة متدلية.

المثال المستقل التالي يُفعّل علامات الترقيم المتدلية في إطار نص بعرض 100 نقطة ويحفظ "hanging_punctuation.pptx". مع Arial بحجم 24 نقطة وهوامش أفقية صفريّة، يبقى النقطة النهائية بعد كلمة "sentence" وتمتد إلى ما بعد حافة النص اليمنى. اضبط الخاصية إلى [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) للمقارنة: مع هذه الإعدادات، تشغل النقطة سطرًا منفصلًا. تم تمكين اللف وتعطيل الملاءمة التلقائية للحفاظ على عرض ثابت.

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

ليس كل علامة ترقيم يمكن أن تتدلى. تنطبق شروط الخط والتخطيط المذكورة أعلاه ([التحكم في كسر السطر](#control-line-breaking)) على هذه المقارنة أيضًا: تغيير الخط أو العرض المتاح أو الهوامش أو إعدادات الملاءمة التلقائية يمكن أن يزيل الفارق المرئي.

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

يحدد [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص يصغر، يتدفق، أو يعيد تحجيم الشكل تلقائيًا. المثال التالي يضبط الشكل لإعادة تحجيمه ليناسب النص ويحفظ النتيجة إلى "autofit_type.pptx".

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

لحساب عدد الأسطر بعد اللف التلقائي ورؤية كيف يتغيّر عرض النص أو الشكل، راجع [Count Rendered Lines](/slides/ar/php-java/manage-paragraph/). عدد الأسطر وحده لا يدل على ما إذا كان النص يتجاوز حاويته.

## **تعيين مرساة إطارات النص**

يحدد [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) كيفية توضع النص عموديًا داخل الشكل، مثلاً في الأعلى أو الوسط أو الأسفل. المثال التالي يرسخ النص إلى أسفل الشكل الأول ويحفظ النتيجة إلى "text_anchor.pptx".

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

## **تعيين تبويب النص**

استخدم [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) و[ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) لتكوين مواضع التبويب في فقرة. المثال التالي يعيّن الفاصل الافتراضي إلى 100 نقطة ويضيف موضع تبويب محاذى إلى اليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.

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

![تبويبات الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

تُوفر Aspose.Slides [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)، الذي يتيح لك تعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتصحيح الإملاء والقواعد في PowerPoint.

المثال التالي يتطلب "presentation.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتويات الفقرة الأولى بـ "1。"، يعيّن SimSun كخط لها، ويُحدد لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة إلى "proofing_language.pptx":

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

عند نسخ نص متعدد اللغات من قالب، احفظ كلًا من [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) و[BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). المثال المستقل التالي يُنشئ جزء مصدر باللغة الإنجليزية الأمريكية كلغة أساسية والفرنسية كلغة بديلة، ثم ينسخ النص والمعرفات إلى جزء في عرض تقديمي جديد.

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

لتجربة مصدر بدون لغة بديلة، احذف إسناد `"fr-FR"`. يصبح المعرف البديل `null`، ويحافظ أمر النسخ نفسه على غيابه دون إدخال قيمة افتراضية، حتى لو كان الوجهة قد عُيّنت لها لغة بديلة مسبقًا.

هذه المعرفات تُخزن بيانات لغة وصفية. حفظها لا يحدد أي قاموس سيختاره PowerPoint للتدقيق الإملائي أو القواعدي.

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) لتحديد اللغة الافتراضية للنص المُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي يُنشئ عرضًا تقديميًا باللغة الإنجليزية الأمريكية كلغة نص افتراضية، يضيف مربع نص، ويطبع `en-US` للجزء النصي الأول.

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

    // التحقق من لغة الجزء الأول.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle).

المثال التالي يعيّن خطًا عريضًا بحجم 14 نقطة كافتراضي للفقرات العليا في عرض تقديمي جديد ويحفظه إلى "default_text_style.pptx". يمكن للنص وراثة هذه القيم الافتراضية ما لم يتجاوزها تنسيق أكثر تحديدًا.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // الحصول على تنسيق الفقرة المستوى الأعلى.
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

## **استخراج النص مع تأثير الحروف الكبيرة كلها**

في PowerPoint، يُظهر تطبيق تأثير الخط **All Caps** النص بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي بـ Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، افحص [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) وحوِّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

يتطلب هذا المثال "sample2.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على "Hello, Aspose!" مع تطبيق تأثير All Caps، كما هو موضح أدناه.

![تأثير الحروف الكبيرة كلها](all_caps_effect.png)

المثال التالي يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

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

الإخراج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة المتكررة**

**كيف يمكنني تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). استعرض الخلايا وحدّث كل خلية عبر [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) وتنسيق الفقرة عبر [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat).

**كيف يمكنني تطبيق لون تدرج على نص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). اضبط [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) إلى [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) ثم قم بتكوين نقاط التدرج، الاتجاه، والشفافية.