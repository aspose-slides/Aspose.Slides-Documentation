---
title: إدارة سمات العروض التقديمية في PHP
linktitle: سمة العرض التقديمي
type: docs
weight: 10
url: /ar/php-java/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض
- سمة الشريحة
- تعيين سمة
- تغيير سمة
- إدارة سمة
- سمة خارجية
- THMX
- لون السمة
- لوحة إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في Aspose.Slides للـ PHP عبر Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على هوية العلامة التجارية المتسقة."
---
## **المقدمة**

تعرف سمة العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والffects. تشير الكائنات الواعية بالسمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، وبالتالي يمكن لتغيير السمة أن يحدّث العديد من الكائنات مرة واحدة.

في Aspose.Slides، تتوفر سمة مستوى العرض من خلال [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/). يمكن للعرض أيضًا أن يحتوي على تجاوزات للسمة في مستويات أدنى. يمكن للماستر أن يتجاوز سمة العرض عبر [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterthememanager/)، بينما يمكن لتخطيط أو شريحة فردية أن تتجاوز سمتها الموروثة عبر [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseoverridethememanager/). عمليًا، يتم حل السمة الفعّالة لشريحة عبر سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكونات السمة: الألوان، الخطوط، أنماط الخلفية، والffects](theme-constituents.png)

توضح الأقسام أدناه أكثر سير عمل شائع للسمة: فحص السمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والffects، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

يُظهر كائن [MasterTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mastertheme/) مخطط الألوان، مخطط الخطوط، ومخطط الصيغ الخاص بالسمة عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mastertheme/). فحص هذه المجموعات قبل تعديلها مفيد خاصةً عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط قد يختلف.

المثال التالي يقرأ الخصائص الرئيسية للسمة ويُبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والffects المخزنة في السمة:

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

إذا كان الملف يستخدم عدة ماسترس، لا تفترض أن كل شريحة لها نفس السمة الفعّالة. فحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعّالة الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات في التخطيط أو الشريحة.

## **تغيير ألوان السمة**

يمكن للتعبئات، الخطوط، والنصوص الواعية بالسمة أن تشير إلى لونٍ منطقي من تعدد [SchemeColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/schemecolor/). عندما تغير الإدخال المقابل في [ColorScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/colorscheme/)، تُحَل جميع الكائنات التي لا تزال تشير إلى ذلك اللون السمي مع القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تُنتَج عنها أي تغيير عند تحديث لون السمة.

المثال التالي الشامل ينشئ شكلًا يستخدم `Accent4`، يغيّر لون `Accent4` في السمة إلى الأحمر، يحفظ العرض، يعيده، ويطبع لون التعبئة الفعّال:

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

نظرًا لأن المستطيل ما يزال مرتبطًا بـ `Accent4`، يصبح لونه الظاهر أحمر بعد تغيير السمة. إذا استبدلت اللون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة في `Accent4` لن تؤثر على تلك التعبئة.

### **استخدام ألوان من اللوحة الإضافية**

يستخرج PowerPoint متغيرات أفتح وأغمق من لون السمة عبر تطبيق تحويلات ألوان. تُظهر Aspose.Slides هذه التحويلات من خلال تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للسمة وألوان أفتح وأغمق مُولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للسمة.

**2** - المتغيرات الأفتح والأغمق المُنتَجة من الألوان الرئيسية للسمة.

المثال التالي ينشئ ستة مستطيلات بناءً على `Accent4`، يطبّق تحويلات إضاءة على خمسة منها، ويحفظ النتيجة:

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

تظل هذه المتغيرات مبنية على لون السمة. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المحوّلة من القيمة الجديدة لـ `Accent4`.

### **خرائط قيم `SchemeColor` إلى فتحات `ColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يعرِّف [ColorScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/colorscheme/) نفس فتحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الخريطة ثابتة:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط السمة**

تحتوي مخطط خطوط السمة على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية للنص الأساسي. تُظهر طُرُق [FontScheme.getMajor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontscheme/) و[FontScheme.getMinor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontscheme/) تلك المجموعات.

يمكن استخدام معرفات خطوط السمة المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان اللاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي شرق آسيوي (Minor East Asian Font)
* `+mj-ea` - خط العنوان شرق آسيوي (Major East Asian Font)

المثال التالي ينشئ عنوانًا يستخدم خط السمة اللاتيني الرئيسي وسطرًا أساسيًا يستخدم الخط اللاتيني الثانوي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

يتبع العنوان الخط الرئيسي ويتبع النص الأساسي الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف سمة لن يتحول تلقائيًا عندما تتغيّر مخطط خطوط السمة.

يمكن أن تحتوي مجموعات الخطوط الرئيسية والثانوية أيضًا على تعيينات خطوط لأنظمة كتابة فردية، مثل السريلية، العربية، اليابانية، الجورجية، والثانا. لفحص، إضافة، استبدال أو إزالة هذه التعيينات، راجع [خطوط السمة الخاصة بالسكريبت](/slides/ar/php-java/script-specific-font-mappings/).

{{% alert color="info" title="نصيحة" %}}
لمزيد من المعلومات حول خطوط العرض، راجع [خطوط PowerPoint](/slides/ar/php-java/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

تحل سير العمل أدناه مشاكل مختلفة مرتبطة بالسمة.

### **تطبيق سمة خارجية على الشرائح التابعة للماستر**

استخدم [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation::getMasters](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/)، الممثلة بـ [MasterSlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/)، ومرّر مسار ملف السمة إلى الطريقة.

تنفّذ الطريقة العمليات التالية:

1. تنشئ شريحة ماستر جديدة بناءً على الماستر المحدد.
1. تطبق السمة الخارجية على الماستر الجديد.
1. تُعيّن الماستر الجديد إلى جميع الشرائح التي كانت تعتمد سابقًا على الماستر المختار.
1. تُعيد الـ [MasterSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/) الذي تم إنشاؤه حديثًا.

المثال التالي يطبق سمة خارجية على الشرائح التي تعتمد على أول ماستر ويحفظ العرض:

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

قد يتسبب سمة غير صالحة أو مCorrupt أو غير مدعومة في رمي [PptxReadException](https://reference.aspose.com/slides/ar/php-java/aspose.slides/pptxreadexception/). تحقق من صحة المسارات التي يقدمها المستخدمون، عالج فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق السمة بنجاح.

يُعاد تعيين الشرائح التي كانت تعتمد على الماستر المحدد فقط. الشرائح المرتبطة بماسترس أخرى تحتفظ بماسترها وسمةها الحالية. تُحل ألوان، خطوط، تعبئات، خطوط، خلفيات، وffects سمة-aware مقابل السمة الخارجية. قد تبقى الألوان، الخطوط، التعبئات، والتنسيقات الصريحة غير متغيّرة. قد تتفوّق تجاوزات مستوى التخطيط أو الشريحة على القيم الموروثة من الماستر الجديد.

قد تشير السمة إلى خطوط غير متوفرة في بيئة التشغيل. للحصول على عرض وتصدير متسقين، ثبّت الخطوط المطلوبة، وفّرها عبر [مصادر الخطوط المخصصة](/slides/ar/php-java/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/php-java/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: تقبل الطريقة مسار ملف `.thmx` ولا تتطلّب إنشاء تجاوزات سمة يدوية على مستوى الشريحة أو التخطيط.

### **تطبيق سمات خارجية مختلفة في عرض متعدد ماسترس**

عند عدم معرفة الماستر المناسب مسبقًا، احصل عليه من شريحة تمثيلية عبر [Slide::getLayoutSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/) و[LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslide/). احفظ مراجع الماستر الأصلية قبل تطبيق أي سمات لأن كل استدعاء يُنشئ ماسترًا جديدًا في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماسترسهم ويطبق سمة خارجية مختلفة على كل مجموعة:

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

النداء الأول يؤثّر فقط على الشرائح التي تعتمد على `$firstGroupMaster`، والنداء الثاني يؤثّر فقط على الشرائح التي تعتمد على `$secondGroupMaster`. الشرائح المرتبطة بأي ماستر آخر لا تُعاد تنسيقها.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا رغبت في نقل شريحة إلى عرض آخر والحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/)، ثم استنسخ الشريحة باستخدام [SlideCollection.addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/) مع الماستر المستنسخ. ينقل ذلك الماستر وتخطيطاته والسمة المرتبطة به معًا.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى على ماستر غير مرتبط قد يغيّر ألوان، خطوط، خلفيات، وffects التي تقودها السمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان يجب أن تظل الشريحة الهدف على ماسترها وتخطيطها الحالي، ابدأ بتجاوز سمة على مستوى الشريحة من السمة المصدر. تنسخ طرق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/overridetheme/) المكوّنات الثلاثة الرئيسية للسمة إلى التجاوز.

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

هذا يُغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/overridetheme/).

### **تطبيق تجاوز سمة على تخطيط**

يُطبق التجاوز على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، ما لم تُجرَ شريحة معينة تجاوزها الخاص. يمكن استخدام نفس طرق الإعداد عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslidethememanager/):

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

استخدم سمة ماستر أو عرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز تخطيط عندما يحتاج عائلة تخطيط إلى تنسيق مختلف، واستخدم تجاوز شريحة فقط للاستثناءات الحقيقية. التجاوزات الزائدة على مستوى الشريحة تجعل تغييرات السمة العامة لاحقًا أصعب في التنبؤ.

## **تحديث أنماط خلفية السمة**

تُخزن تعبئات خلفية السمة في [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/formatscheme/). يمكن لـ PowerPoint تقديم خيارات خلفية أكثر في واجهته مقارنةً بعدد تعريفات التعبئة المخزنة فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات السمة مع ألوان السمة ومراجع الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لسمة عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.getStyleIndex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/background/). مؤشر النمط `0` يعني عدم وجود تعبئة سمة؛ القيم الموجبة هي مراجع أنماط خلفية سمة. هذا يختلف عن فهرسة مجموعة PHP مباشرةً، حيث يعني `get_Item(0)` العنصر الأول المخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يُبلغ عن عدد تعبئات الخلفية المتاحة، يُعيّن إشارة خلفية سمة إلى الماستر الأول، ويحفظ العرض:

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

النتيجة الظاهرة تعتمد على إدخال السمة الذي يشير إليه الماستر وعلى أي تجاوزات خلفية في التخطيط أو مستوى الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يغيّر تغيير خلفية الماستر تلك الشريحة. استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/background/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="تحذير" %}}
لا تُعامل مؤشر النمط كفهرس مجموعة يبدأ من الصفر. أيضًا تجنّب الترميز الصلب لرقم نمط من ملف واحد وافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات أنماط السمة خاصة بكل عرض.
{{% /alert %}}

{{% alert color="info" title="نصيحة" %}}
للتنسيق المباشر للخلفية والوراثة الخلفية، راجع [خلفية العرض](/slides/ar/php-java/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

يحتوي مخطط صيغ السمة على مجموعات تعبئة، خط، وتأثير منفصلة تُعرض عبر [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/formatscheme/)، و[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/formatscheme/). غالبًا ما تحتوي سمات Office على ثلاث إدخالات أساسية تتCorrespond بصريًا إلى تنسيقات خفيفة، متوسطة، وشديدة، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من الافتراض بوجود عدد ثابت.

![تأثيرات سمة خفيفة، متوسطة، وشديدة مُطبقة على الشكل نفسه](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في PHP، يكون فهرس المجموعة يبدأ من الصفر: `get_Item(0)` هو النمط المخزن الأول و`get_Item(2)` هو الثالث. فهارس مراجع النمط للشكل مفهوم منفصل، يُعرض عبر [ShapeStyle](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تُشير إلى ذلك النمط؛ قد تبقى الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود إدخالات النمط المطلوبة، يغيّر نمط الخط الأول، يغيّر نمط التعبئة الثالث، يُفعّل ظلًا خارجيًا في نمط التأثير الثالث، ويحفظ النتيجة:

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

للأشكال التي تُشير إلى هذه الفتحات، يصبح نمط الخط السمة الأول أحمر، ونمط التعبئة السمة الثالث أخضر غابات صلب، وينال نمط التأثير الثالث ظلًا خارجيًا بمسافة 10 نقاط. لا يزال الناتج البصري النهائي يعتمد على الفتحات التي تُشير إليها كل شكل وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير إعدادات الخط، التعبئة، والظل](presentation-design_11.png)

## **قراءة قيم السمة الفعّالة**

تُظهر كائنات السمة الخام ما تم تعريفه على مستوى معين. القيم الفعّالة تُظهر ما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseoverridethememanager/). لخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/background/)، وللتعبئة، استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fillformat/).

المثال التالي يقرأ السمة الفعّالة، الخلفية، وتعبئة الشكل الأول من شريحة:

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

استخدم البيانات الفعّالة لتشخيص العرض، والتحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/)، قد تُفوتك تجاوزات ماستر، تخطيط، شريحة، أو شكل تُغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل يؤثر تطبيق سمة خارجية على كل شريحة في العرض؟**

لا. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslide/) يُعيد تعيين الشرائح التي تعتمد فقط على الماستر المحدد. الشرائح التي تستخدم ماسترس أخرى تحتفظ بسماتها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidethememanager/) الخاص بالشريحة وابدأ سمة التجاوز الخاصة بها. التغيير يبقى محليًا لتلك الشريحة؛ الشرائح الأخرى تستمر في وراثة سماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/) ثم استنسخ الشريحة مع ذلك الماستر باستخدام [SlideCollection.addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/). هذا يحافظ على الماستر، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseoverridethememanager/) لسمة شريحة أو تخطيط، واستخدم طرق البيانات الفعّالية المقابلة لكائنات الصيغ مثل [Background.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المَحَلَّة بعد تطبيق الوراثة والتجاوزات.