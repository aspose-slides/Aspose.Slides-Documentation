---
title: إدارة قوالب العروض التقديمية في PHP
linktitle: قالب العرض التقديمي
type: docs
weight: 10
url: /ar/php-java/presentation-theme/
keywords:
- قالب PowerPoint
- قالب العرض التقديمي
- قالب الشريحة
- تعيين القالب
- تغيير القالب
- إدارة القالب
- قالب خارجي
- THMX
- لون القالب
- لوحة ألوان إضافية
- خط القالب
- نمط القالب
- تأثير القالب
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "قوالب العروض التقديمية الرئيسية في Aspose.Slides للـ PHP عبر Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على العلامة التجارية المتسقة."
---
## **المقدمة**

يحدد قالب العرض مجموعة منسقة من الألوان والخطوط وأنماط الخلفية والملئ والحدود والفعالات. تشير الكائنات المدركة للقالب إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، لذا يمكن لتغيّر القالب تحديث العديد من الكائنات دفعة واحدة.

في Aspose.Slides، يتوفر قالب المستوى التقديمي عبر [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/). يمكن للعرض أيضًا أن يحتوي على تجاوزات للقالب في مستويات أدنى. يمكن للقالب الرئيسي تجاوز قالب العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterthememanager/)، بينما يمكن لتخطيط أو شريحة فردية تجاوز القالب الموروث عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseoverridethememanager/). عمليًا، يتم حل القالب الفعّال للشرائح عبر سلسلة الوراثة هذه: قالب العرض، تجاوز القالب الرئيسي، تجاوز تخطيط، وتجاوز شريحة.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

تبين الأقسام أدناه أكثر سير عمل شائع للقالب: فحص القالب، تغيير الألوان والخطوط، نسخ أو تطبيق قالب، تحديث أنماط الخلفية والفعالات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص القالب**

كائن [MasterTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mastertheme/) يكشف عن مخطط ألوان القالب، مخطط الخطوط، ومخطط الصيغ عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mastertheme/). فحص هذه التجميعات قبل تعديلها مفيد بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط قد يختلف.

المثال التالي يقرأ خصائص القالب الرئيسي ويبلغ عن عدد أنماط الخلفية والملء والحد والفعالات المخزنة في القالب:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

إذا كان الملف يستخدم عدة قوالب رئيسية، لا تفترض أن كل شريحة لها نفس القالب الفعّال. افحص القالب الرئيسي المرتبط بالشفرة، واستخدم سير عمل القالب الفعّال الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات لتخطيط أو شريحة.

## **تغيير ألوان القالب**

يمكن للملء والحد والنص المدرك للقالب الإشارة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/schemecolor/). عندما تغير الإدخال المقابل في [ColorScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/colorscheme/)، تُسترجع جميع الكائنات التي لا تزال تشير إلى ذلك اللون القالب مقابل القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون القالب.

المثال التالي من البداية إلى النهاية ينشئ شكلاً يستخدم `Accent4`، يغيّر لون `Accent4` في القالب إلى الأحمر، يحفظ العرض، يعيده، ويطبع لون الملء الفعّال:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

نظرًا لأن المستطيل ما زال مرتبطًا بـ `Accent4`، يصبح لونه الظاهري أحمر بعد تغيير القالب. إذا استبدلت لون التعداد بلون مباشر على الشكل، فإن التغييرات اللاحقة لـ `Accent4` لن تؤثر على ذلك الملء.

### **استخدام ألوان من اللوحة الإضافية**

يستخرج PowerPoint متغيرات أفتح وأغمق من لون القالب بتطبيق تحويلات الألوان. تعرض Aspose.Slides هذه التحويلات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - ألوان القالب الرئيسية.

**2** - المتغيرات الأفتح والأغمق المشتقة من ألوان القالب الرئيسية.

المثال التالي ينشئ ستة مستطيلات تعتمد على `Accent4`، يطبّق تحويلات اللمعان على خمسة منها، ويحفظ النتيجة:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تظل هذه المتغيّرات مبنية على لون القالب. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المحوّلة من القيمة الجديدة لـ `Accent4`.

### **خريطة قيم `SchemeColor` إلى مواضع `ColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يكشف [ColorScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/colorscheme/) عن نفس مواضع القالب كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الخريطة ثابتة:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس مواضع القالب؛ ليست قيمًا يتم تحويلها ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط القالب**

يحتوي مخطط خطوط القالب على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط فرعية للنص الأساسي. تكشف طريقتا [FontScheme.getMajor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontscheme/) و[FontScheme.getMinor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontscheme/) هذه المجموعات.

يمكن استخدام معرفات خطوط القالب المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي لاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان لاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي شرق آسيوي (Minor East Asian Font)
* `+mj-ea` - خط العنوان شرق آسيوي (Major East Asian Font)

المثال التالي ينشئ عنوانًا يستخدم خط القالب اللاتيني الرئيسي وسطرًا نصيًا يستخدم خط القالب اللاتيني الفرعي. ثم يغيّر خطوط القالب ويحفظ النتيجة:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

يتبع العنوان الخط الرئيسي ويتبع النص الأساسي الخط الفرعي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف قالب لن يتبدل تلقائيًا عندما يتغيّر مخطط خطوط القالب.

يمكن لمجموعتي الخط الرئيسي والفرعي أيضًا أن تحتوي على تعيينات خطوط لأنظمة كتابة فردية، مثل السيريالية، العربية، اليابانية، الجورجية، والطحانية. لفحص هذه التعيينات أو إضافتها أو استبدالها أو إزالتها، راجع [Script-Specific Theme Fonts](/slides/ar/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض التقديمي، راجع [PowerPoint Fonts](/slides/ar/php-java/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق قالب**

تحل سير العمل أدناه مشاكل مختلفة متعلقة بالقالب.

### **تطبيق قالب خارجي على الشرائح التابعة لمالك**

استخدم [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/) عندما يكون لديك ملف قالب PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على مالك معين. حدد المالك من تجميع [Presentation::getMasters](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/)، وهو ممثل بـ [MasterSlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/)، ومرّر مسار ملف القالب إلى الطريقة.

تنفّذ الطريقة العمليات التالية:

1. تنشئ شريحة رئيسية جديدة بناءً على المالك المحدد.
1. تطبق القالب الخارجي على المالك الجديد.
1. تُعين المالك الجديد لجميع الشرائح التي كانت تعتمد مسبقًا على المالك المحدد.
1. تُعيد كائن [MasterSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/) الذي تم إنشاؤه حديثًا.

المثال التالي يطبق قالبًا خارجيًا على الشرائح التي تعتمد على أول مالك ويحفظ العرض:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

قد يتسبب قالب غير صالح، فاسد، أو غير مدعوم في حدوث استثناء [PptxReadException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxreadexception/). تحقق من صحة المسارات التي يزودها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد أن يُطبق القالب بنجاح.

يتم إعادة تعيين الشرائح التي كانت تعتمد على المالك المحدد فقط. الشرائح المرتبطة بمالكين آخرين تحتفظ بمالكيها وقوالبها الحالية. تُحل الألوان والخطوط والملء والحدوط والخلفيات والفعالات المدركة للقالب مقابل القالب الخارجي. قد تظل الألوان والخطوط والملء والتنسيق الصريح المعيّن مباشرةً دون تغيير. يمكن لتجاوزات على مستوى التخطيط أو الشريحة أن تتفوق على القيم الموروثة من المالك الجديد.

قد يشير القالب إلى خطوط غير متوفرة في بيئة التنفيذ. لضمان عرض وتصدير متسقين، ثبّت الخطوط المطلوبة، وقدّمها عبر [مصادر الخطوط المخصَّصة](/slides/ar/php-java/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/php-java/font-substitution/).

هذا سير عمل على مستوى المالك مباشرةً: تقبل الطريقة مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات قوالب على مستوى الشريحة أو التخطيط يدويًا.

### **تطبيق قوالب خارجية مختلفة في عرض متعدد المالكين**

عندما لا يكون المالك المعني معروفًا مسبقًا، احصل عليه من شريحة تمثيلية عبر [Slide::getLayoutSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/) و[LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/). احفظ مراجع المالك الأصلي قبل تطبيق أي قوالب لأن كل استدعاء يُنشئ مالكًا آخر في العرض.

المثال التالي يستخدم شرائح من قسميْن لتحديد مالكيهما ويطبق قالبًا خارجيًا مختلفًا على كل مجموعة:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

الاستدعاء الأول يؤثر فقط على الشرائح التي تعتمد على `$firstGroupMaster`، والاستدعاء الثاني يؤثر فقط على الشرائح التي تعتمد على `$secondGroupMaster`. الشرائح المرتبطة بأي مالك آخر لا تُعاد تنسيقها.

### **الحفاظ على قالب المصدر عند نقل الشرائح**

إذا أردت نقل شريحة إلى عرض آخر والحفاظ على تصميمها الأصلي، انسخ المالك المصدر إلى العرض الهدف باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/)، ثم انسخ الشريحة باستخدام [SlideCollection.addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/) والمالك المستنسخ. هذا يحمل المالك وتخطيطاته والقالب المرتبط به معًا.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية كما هي في الوجهة. مجرد نسخ المحتوى إلى مالك هدف غير مرتبط قد يغيّر الألوان والخطوط والخلفيات والفعالات المدفوعة بالقالب.

### **تطبيق قيم القالب على شريحة موجودة**

إذا كان على الشريحة الهدف البقاء على مالكها وتخطيطها الحاليين، ابدأ تجاوزًا على مستوى الشريحة من القالب المصدر. تنسخ طرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/overridetheme/) المكوّنات الثلاثة الرئيسية للقالب إلى التجاوز.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

هذا يغيّر القالب المستخدم لتلك الشريحة دون تغيير القالب الموروث للشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/overridetheme/).

### **تطبيق تجاوز قالب على تخطيط**

تطبيق تجاوز على مستوى التخطيط يؤثر على الشرائح التي تستخدم ذلك التخطيط، ما لم تكن شريحة معينة لديها تجاوز خاص بها. يمكن استعمال نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslidethememanager/):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

استخدم قالبًا على مستوى المالك أو العرض عندما يجب أن تشترك الكثير من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيطات واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للحالات الاستثنائية الحقيقية. تؤدي التجاوزات المفرطة على مستوى الشريحة إلى صعوبة توقع تغييرات القالب العامة لاحقًا.

## **تحديث أنماط خلفية القالب**

تُخزن ملء خلفية القالب في [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/formatscheme/). يمكن لـ PowerPoint تقديم خيارات خلفية أكثر في واجهته مقارنة بعدد تعريفات الملء المخزنة فعليًا في هذه المجموعة لأن الواجهة يمكن أن تجمع ملء القالب مع ألوان القالب ومراجع أنماط أخرى.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

قبل استخدام نمط الخلفية، افحص المجموعة المخزنة و[Background.getStyleIndex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/background/) الحالي. يعني الفهرس `0` عدم وجود ملء مموضوع؛ القيم الموجبة تشير إلى مراجع نمط خلفية القالب. هذا يختلف عن فهرسة مجموعة PHP مباشرةً، حيث يعني `get_Item(0)` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط ملء الخلفية.

المثال التالي يبلغ عن عدد ملء الخلفية المتاح، يُعيّن مرجع خلفية مموضوع للمالك الأول، ويحفظ العرض:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

النتيجة الظاهرة تعتمد على إدخال القالب الذي يشير إليه المالك وأي تجاوزات خلفية في مستوى التخطيط أو الشريحة. إذا كانت شريحة تستخدم خلفيتها الخاصة، قد لا يتغيّر مظهرها بتغيير خلفية المالك فقط. استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/background/) عندما تحتاج معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}
لا تتعامل مع فهرس النمط كفهرس مجموعة يبدأ من الصفر. كما تجنّب ترقيم ثابت لرقم النمط من ملف واحد والافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط القالب خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية ووراثة الخلفية، راجع [Presentation Background](/slides/ar/php-java/presentation-background/).
{{% /alert %}}

## **تحديث فعالات القالب**

يحتوي مخطط صيغ القالب على تجميعات منفصلة للملء والحد والفعالية يتم كشفها عبر [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/formatscheme/)، و[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/formatscheme/). غالبًا ما تحتوي القوالب المكتبية على ثلاثة مداخل أساسية تتطابق بصريًا مع تنسيق خفيف، متوسط، ومكثف، لكن يجب على الشيفرة فحص كل تجميع بدلاً من افتراض عدد ثابت.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

عند الوصول إلى هذه التجميعات في PHP، يكون فهرس التجميع صفرًا أساسًا: `get_Item(0)` هو أول نمط مخزن و`get_Item(2)` هو النمط الثالث. فهارس مراجع النمط للشكلة مفهوم منفصل، يُكشف عبر [ShapeStyle](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapestyle/). تعديل نمط القالب يؤثر على الأشكال التي تشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر غير متغيرة.

المثال التالي يتحقق من وجود مداخل النمط المطلوبة، يغيّر النمط الخط الأول، يغيّر النمط الملء الثالث، يُفعّل ظلًا خارجيًا في النمط الفعالية الثالث، ويحفظ النتيجة:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

للأشكال التي تشير إلى هذه المواضع، يصبح نمط الخط القالب الأول أحمر، والنمط الملء القالب الثالث يصبح أخضر غابوي صلب، ويكتسب النمط الفعالية الثالث ظلًا خارجيًا بمسافة 10 نقاط. لا يزال المظهر النهائي يعتمد على أي مواضع نمط كل شكل يشير إليها وما إذا كان التنسيق المباشر يتجاوز القالب.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **تحديد ما إذا كان الملء الصلب الفعّال يستخدم لون القالب**

يمكن أن يُخزن الملء مباشرةً على كائن أو يُورث من فقرة أو تخطيط أو مالك أو نمط قالب أو مستوى تنسيق آخر. استدعِ [FillFormat::getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fillformat/) لحل هذه الهرمية إلى بيانات ملء صلبة غير قابلة للتغيير. أولًا تحقق من نتيجة `getFillType`. فقط عندما تكون `FillType::Solid` يجب قراءة خصائص الملء الصلب.

لملء صلب، تُعيد `getSolidFillColor` القيمة النهائية للـ RGB بعد تطبيق الوراثة والبحث في القالب وتحويلات الألوان. تُعيد الطريقة `getSolidFillSchemeColor` الفتحة المنطقية لـ [SchemeColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/schemecolor/) المقابلة، مثل `Text1` أو `Accent6`. قيمة `SchemeColor::NotDefined` تعني أن الملء الصلب الفعّال ليس مبنيًا على لون التعداد. في سير عمل حيث تكون الملء إما ألوان قالب أو ألوان RGB مباشرة، تُظهر هذه القيمة ملء RGB مباشر.

لا تستخدم قيمة [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/colorformat/) المحلية بمفردها لتصنيف الملء. على سبيل المثال، قد لا يحتوي مقطع نص على لون تعداد معرف محليًا، فيكون قيمته المحلية `NotDefined`، بينما يرث ملءه الفعّال لون قالب ويحل إلى `Text1` أو `Accent6`. على العكس، تُظهر `getSolidFillSchemeColor` الفتحة المنطقية التي أنتجت اللون الفعّالي، لكنها لا تخبرك ما إذا كانت تلك الفتحة جاءت من الكائن أو الفقرة أو التخطيط أو المالك أو مستوى آخر في شجرة التنسيق.

المثال التالي يحمل عرضًا، يراجع كل من ملء الأشكال وملء مقاطع النص، يطبع كل قيمة RGB نهائية والفتحة المرتبطة، ويُعلّم الملء الصلب الذي لن يتتبع تغيّر ألوان القالب:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

يقدِّم الفرع `NotDefined` قائمة تدقيق للملء الصلب الذي لن يستجيب لتغييرات فتحات ألوان القالب. راجع تلك الكائنات عندما يجب أن يتبع العرض لوحة ألوان علامة تجارية جديدة. لا يزال قيمة RGB المعروضة تُظهر المظهر الحالي، بينما تشرح قيمة الفتحة ما إذا كان ذلك المظهر مرتبطًا بالقالب.

الكائنات ذات الصيغة الفعّالة هي لقطات. بعد تغيير قالب العرض أو تجاوز القالب أو أي تنسيق موروث، استدعِ `getEffective` مرة أخرى واقرأ بيانات الملء الفعّالية الجديدة قبل المقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم القالب الفعّالية**

تخبرك كائنات القالب الخام بما هو معرف في مستوى معين. تُظهر القيم الفعّالية ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. للشفرة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/background/)، وللملء استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fillformat/).

المثال التالي يقرأ القالب الفعّالي، الخلفية، والملء الأول للشكل من شريحة:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

استخدم البيانات الفعّالية لتشخيص العرض، التحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/)، قد تغفُل عن تجاوزات المالك أو التخطيط أو الشريحة أو الشكل التي تُغيّر المظهر النهائي.

## **الأسئلة المتداولة**

**هل يؤثر تطبيق قالب خارجي على كل شريحة في العرض؟**

لا. تعيد [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/) تعيين الشرائح التي تعتمد فقط على المالك المحدد. الشرائح التي تستخدم أصحاب مالكين آخرين تحتفظ بقوامها القالبية الحالية.

**هل يمكنني تطبيق قالب على شريحة واحدة دون تغيير المالك؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidethememanager/) الخاص بالشريحة وابدأ تعديل قالبها التجاوزي. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة قوالبها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل قالب من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، انسخ المالك المصدر إلى الوجهة وانسخ الشريحة مع ذلك المالك باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/) و[SlideCollection.addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/). هذا يحافظ على المالك والتخطيطات والقالب معًا.

**كيف يمكنني رؤية القيم الفعّالية بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseoverridethememanager/) لشريحة أو تخطيط قالب، والطرق المقابلة للبيانات الفعّالية لكائنات الصيغ مثل [Background.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المحلولة بعد تطبيق الوراثة والتجاوزات.