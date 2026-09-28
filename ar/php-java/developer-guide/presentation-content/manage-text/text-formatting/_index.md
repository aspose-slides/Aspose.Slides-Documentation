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
description: "تنسيق وتعديل مظهر النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. خصّص الخطوط والألوان والمحاذاة والمزيد."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. تغطي ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، مواضع التبويب وإعدادات اللغة.

ما لم يُذكر خلاف ذلك، تستخدم الأمثلة الملف [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو صندوق نص، والفقرة الأولى تحتوي على النص الموضح أدناه. كل من مؤشرات الشرائح والأشكال تبدأ من الصفر. الأمثلة التي تختار أجزاءً غامقة تستخدم التنسيق الفعّال، بما في ذلك تنسيق الغامق الموروث:

![نص مثال](sample_text.png)

للعثور على النص الحرفي أو مطابقة تعبيرات regex وتظليلها، انظر [Search and Replace Text](/slides/ar/php-java/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#getHighlightColor) لأجزاء النص الفردية.

المثال التالي يحدد تظليلًا رماديًا فاتحًا كافتراضي للفقرة الأولى. ألوان التظليل الصريحة على الأجزاء الفردية لها أولوية أعلى من هذا الافتراضي:

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

يوضح مثال الشيفرة أدناه كيفية تعيين لون الخلفية لـ **أجزاء النص ذات الخط الغامق**:

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

استخدم [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setAlignment) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة متمركزة، محاذية إلى اليسار، محاذية إلى اليمين، مبررة، وما إلى ذلك.

يوضح مثال الشيفرة التالي كيفية محاذاة الفقرة إلى **المركز**:

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

## **تعيين الشفافية للنص**

تتحكم شفافية النص من خلال مكوّن ألفا للون المعين إلى [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#getFillFormat). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0–255، وليس نسبة شفافية.

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

يوضح مثال الشيفرة التالي كيفية تطبيق الشفافية على **أجزاء النص ذات الخط الغامق**:

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

استخدم [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setSpacing) لتوسيع أو تقليص التباعد بين الأحرف في صندوق النص. الأمثلة تضيف 3 نقاط من التباعد؛ القيم السالبة تُقلّص النص.

يعرض الكود PHP التالي كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

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

يوضح مثال الشيفرة أدناه كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط الغامق**:

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

### **تعطيل Kerning لخطوط محددة**

في بعض الحالات، قد يبدو النص المُرسم بواسطة Aspose.Slides أكثر ضيقًا قليلًا من نفس النص المعروض في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات Kerning لبعض الخطوط، حتى عندما يحتوي الخط على معلومات Kerning صالحة وتم تمكين Kerning في إعدادات PowerPoint.

لجعل المخرجات المرسومة أقرب إلى PowerPoint في مثل هذه الحالات، يمكنك تعطيل Kerning لأجزاء النص التي تستخدم الخط المتأثر. عيِّن [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) إلى قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال وجود ملف "presentation.pptx" يحتوي على صندوق نص كشكل أول في الشريحة الأولى. يتحقق من أسماء الخطوط الفعّالة، بما في ذلك الخطوط الموروثة، ويضبط حدًا قدره 100 نقطة للأجزاء التي تستخدم Roboto. هذا يعطل Kerning للأجزاء المطابقة التي يكون حجم الخط أقل من 100 نقطة:

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

بالنسبة للنص المطابق الذي يكون أقل من الحد، يمنع هذا الإعداد Kerning ويمكن أن يساعد في مطابقة عرض Aspose.Slides مع مخرجات PowerPoint المرئية للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة من خلال [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) أو على الأجزاء الفردية من خلال [PortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/).

المثال التالي يضبط الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع تنسيق غامق ومائل وتسطير منقط. التنسيق الصريح على الأجزاء الفردية له أولوية أعلى من هذه القيم الافتراضية:

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

المثال التالي يطبّق Times New Roman بحجم 13 نقطة، تنسيق مائل، وتسطير منقط على الأجزاء التي يكون تنسيقها الفعّال غامقًا:

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

## **تعيين دوران النص**

استخدم [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setTextVerticalType) لتعيين اتجاه نص مسبق داخل الشكل.

المثال التالي يضبط اتجاه النص في الشكل إلى [TextVerticalType::Vertical270](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textverticaltype/)، وهو ما يدور النص **90 درجة عكس عقارب الساعة**:

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

استخدم [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setRotationAngle) لتعيين زاوية دوران مخصصة لإطار نص ([TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/)).

يقوم مثال الشيفرة أدناه بتدوير إطار النص بمقدار 3 درجات باتجاه عقارب الساعة داخل الشكل:

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

توفر Aspose.Slides الدوال [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setSpaceBefore) و[ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setSpaceWithin) للتحكم في تباعد الفقرات. تُستَخدم هذه الخصائص على النحو التالي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

المثال التالي يحدد التباعد داخل الفقرة الأولى إلى 200% من ارتفاع السطر (تباعد مزدوج):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $presentation->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة:

![تباعد الأسطر داخل الفقرة](line_spacing.png)

## **التحكم في كسر السطر**

قواعد كسر سطر الفقرة مفيدة في كتل نصية ضيقة وعروض تقديمية تمزج بين النص اللاتيني والنص الآسيوي الشرقي. الطرق التالية تنتمي إلى [ParagraphFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/)، لذا فهي تُطبق على الفقرة بأكملها:

- [setLatinLineBreak](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) يتحكم في قواعد كسر السطر للخط اللاتيني. في النص المختلط، يمكن لتغييره أيضًا تعديل موضع التفاف النص الآسيوي الشرقي وعلامات الترقيم المجاورة.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) يتحكم في قواعد كسر السطر للخط الآسيوي الشرقي، بما في ذلك القيود على الحروف في بداية السطر ونهايته.

هذه القواعد لا تحل محل [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setWrapText)، الذي يُفعل التفاف النص تلقائيًا داخل إطار النص. إنها تؤثر على التخطيط عندما يحدث التفاف؛ لا تُدرج أحرف كسر السطر. كسر السطر الصريح يُجبر سطرًا جديدًا داخل الفقرة بغض النظر عن العرض المتاح.

المثال المستقل التالي ينشئ كتلة نصية ضيقة تحتوي على نص صيني ولاتيني. يحدد كلا خيارَي كسر السطر صراحةً ويحفظ الملف باسم "line_breaking.pptx". لتجربة أي قاعدة، غير القيمة المقابلة مع إبقاء الإعدادات الأخرى ثابتة. يستخدم المثال خط Arial بحجم 24 نقطة وSimSun مع عرض إطار 160 نقطة وهوامش أفقية صفرية لإطار النص. يتم استدعاء [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setAutofitType) مع [TextAutofitType::None](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textautofittype/) بحيث يظل حجم النص وأبعاد الإطار ثابتين.

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

يتيح [ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) للعلامات الترقيمية المؤهلة أن تمتد إلى ما بعد الحافة اليمنى لسطر النص بدلاً من الانتقال إلى السطر التالي. ينطبق هذا على الفقرة بأكملها ويختلف عن المسافة المتدلية (hanging indent).

المثال المستقل التالي يُفعِّل علامات الترقيم المتدلية في إطار نص بعرض 100 نقطة ويحفظ الملف باسم "hanging_punctuation.pptx". مع خط Arial بحجم 24 نقطة وهوامش أفقية صفرية لإطار النص، يبقى النقطة النهائية بعد كلمة "sentence" وتمتد إلى ما بعد الحافة اليمنى للنص. اضبط الخاصية إلى [NullableBool::False](https://reference.aspose.com/slides/ar/php-java/aspose.slides/nullablebool/) للمقارنة: مع هذه الإعدادات، تحتل النقطة سطرًا منفصلًا. تم تمكين التفاف النص وتعطيل الملاءمة التلقائية للحفاظ على العرض المتاح ثابتًا.

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

ليس كل علامة ترقيم يمكنها التعليق. النتيجة الظاهرة تعتمد على توفر الخط وتخطيطه: قد يؤدي تغيير الخط أو العرض المتاح أو الهوامش أو إعدادات الملاءمة التلقائية إلى إزالة الاختلاف البصري.

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

يحدد [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setAutofitType) كيف يتصرف النص عندما يتجاوز حدود الحاوية الخاصة به. استخدمه للتحكم فيما إذا كان النص يُصغر، يفيض، أو يعيد تحجيم الشكل تلقائيًا. المثال التالي يضبط الشكل لإعادة التحجيم ليتناسب مع النص ويحفظ النتيجة في "autofit_type.pptx".

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

لحساب عدد الأسطر بعد التفاف النص التلقائي ورؤية كيف يغيّر عرض النص أو الشكل النتيجة، راجع [Count Rendered Lines](/slides/ar/php-java/manage-paragraph/). عدد الأسطر وحده لا يشير إلى ما إذا كان النص يفيض عن الحاوية.

## **تعيين موضع التثبيت لإطارات النص**

يحدد [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframeformat/#setAnchoringType) كيفية وضع النص عموديًا داخل الشكل، مثلًا في الأعلى أو الوسط أو الأسفل. المثال التالي يثبت النص في أسفل الشكل الأول ويحفظ النتيجة في "text_anchor.pptx".

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

## **تعيين التبويب للنص**

استخدم [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) و[ParagraphFormat::getTabs](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraphformat/#getTabs) لتكوين مواضع التبويب في الفقرة. المثال التالي يضبط الفاصل الافتراضي للتبويب إلى 100 نقطة ويضيف موضع تبويب محاذٍ إلى اليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.

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

توفر Aspose.Slides الدالة [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setLanguageId)، والتي تتيح لك تعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة للتدقيق الإملائي والنحوي في PowerPoint.

المثال التالي يتطلب ملف "presentation.pptx" يحتوي على صندوق نص كشكل أول في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتويات الفقرة الأولى بـ "1。"، يعيّن SimSun كخط لها، ويُعيّن لغة التدقيق الصينية المبسطة (`zh-CN`). ثم يحفظ النتيجة في "proofing_language.pptx":

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

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) لتحديد اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي ينشئ عرضًا تقديميًا باللغة الإنجليزية الأمريكية كلغة نص افتراضية، يضيف صندوق نص، ويطبع `en-US` للجزء النصي الأول.

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

    // فحص لغة الجزء الأول.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getDefaultTextStyle).

المثال التالي يضبط خطًا غامقًا بحجم 14 نقطة كافتراضي للفقرات العليا في عرض تقديمي جديد ويحفظه في "default_text_style.pptx". يمكن للنص أن يرث هذه القيم الافتراضية ما لم يتم تجاوزها بتنسيق أكثر تحديدًا.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // احصل على تنسيق الفقرة في المستوى الأعلى.
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

## **استخراج النص مع تأثير الأحرف الكبيرة**

في PowerPoint، يجعل تطبيق تأثير **All Caps** على الخط يظهر النص بأحرف كبيرة على الشريحة حتى لو كان مكتوبًا أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما كُتب بالضبط. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textcaptype/) وحوّل السلسلة المرجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

يتطلب هذا المثال وجود ملف "sample2.pptx" يحتوي على صندوق نص كشكل أول في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على النص "Hello, Aspose!" مع تطبيق تأثير All Caps، كما هو موضح أدناه.

![تأثير الأحرف الكبيرة](all_caps_effect.png)

يوضح مثال الشيفرة أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:

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

المخرجات:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **التعليمات المتكررة**

**كيف يمكنني تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [Table](https://reference.aspose.com/slides/ar/php-java/aspose.slides/table/). استعرض الخلايا وقم بتحديث كل خلية عبر [Cell::getTextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/cell/#getTextFrame) وتنسيق الفقرات عبر [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/#getParagraphFormat).

**كيف يمكنني تطبيق لون متدرج على النص في شريحة PowerPoint؟**

لتطبيق لون متدرج على النص، استخدم [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#getFillFormat). عيّن [FillFormat::setFillType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fillformat/#setFillType) إلى [FillType::Gradient](https://reference.aspose.com/slides/ar/php-java/aspose.slides/filltype/) وقم بإعداد نقاط التدرج، الاتجاه، والشفافية.