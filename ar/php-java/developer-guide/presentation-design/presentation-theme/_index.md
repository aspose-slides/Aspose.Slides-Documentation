---
title: إدارة سمات العرض في PHP
linktitle: سمة العرض
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
- لون السمة
- لوحة ألوان إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة سمات عروض الـ PowerPoint في Aspose.Slides للـ PHP عبر Java لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على هوية العلامة التجارية المتسقة."
---
## **المقدمة**

يحدد سمة العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. تُشير الكائنات التي تدعم السمة إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية مرئية كقيمة ثابتة، لذا يمكن لتغيير السمة تحديث العديد من الكائنات مرة واحدة.

في Aspose.Slides، تتوفر سمة مستوى العرض من خلال [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/). يمكن للعرض أيضًا أن يحتوي على تجاوزات سمة في مستويات أدنى. يمكن للماستر تجاوز سمة العرض من خلال [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterthememanager/)، بينما يمكن لتخطيط أو شريحة فردية تجاوز سمتها الموروثة من خلال [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseoverridethememanager/). عمليًا، تُحل السمة الفعلية للشريحة عبر سلسلة الوراثة هذه: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

الأقسام أدناه تُظهر أكثر سير عمل السمة شيوعًا: فحص السمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعلية بعد حل الوراثة والتجاوزات.

## **فحص سمة**

الكائن [MasterTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mastertheme/) يُظهر مخطط ألوان السمة، مخطط الخطوط، ومخطط التنسيق عبر [MasterTheme.getColorScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mastertheme/)، و[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mastertheme/). فحص هذه المجموعات قبل تعديلها مفيد جدًا عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى إدخالات الأنماط قد يختلف.

المثال التالي يقرأ خصائص السمة الرئيسية ويُبلغ عن عدد أنماط الخلفية، التعبئة، الخط، والتأثير المخزنة في السمة:

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

إذا كان الملف يستخدم عدة ماسترات، لا تفترض أن كل شريحة لها نفس السمة الفعلية. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعلية الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات في التخطيط أو الشريحة.

## **تغيير ألوان السمة**

يمكن أن تُشير التعبئات، الخطوط، والنصوص المدركة للسمة إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/schemecolor/). عند تغيير الإدخال المقابل في [ColorScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/colorscheme/)، تُحل جميع الكائنات التي لا تزال تُشير إلى ذلك اللون السمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغير بتحديث لون السمة.

المثال التالي الشامل ينشئ شكلًا يستخدم `Accent4`، يغير لون السمة `Accent4` إلى الأحمر، يحفظ العرض، يُعيد فتحه، ويطبع لون التعبئة الفعلي:

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

لأن المستطيل يظل مرتبطًا بـ `Accent4`، يصبح لونه المرئي أحمر بعد تغيير السمة. إذا قمت باستبدال لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر على تلك التعبئة.

### **استخدام الألوان من اللوحة الإضافية**

يستخرج PowerPoint متغيرات أفتح وأغمق من لون السمة بتطبيق تحولات اللون. تُظهر Aspose.Slides هذه التحولات عبر تعداد [ColorTransformOperation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - الألوان الرئيسية للسمة.  
**2** - المتغيرات الفاتحة والداكنة المشتقة من ألوان السمة الرئيسية.

المثال التالي ينشئ ستة مستطيلات تعتمد على `Accent4`، يطبق تحولات اللمعان على خمسة منها، ويحفظ النتيجة:

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

هذه المتغيرات تظل مبنية على لون السمة. إذا تغير `Accent4` لاحقًا، تُعاد حساب الألوان المحوَّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بفتحات `ColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر تعداد [ColorScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/colorscheme/) نفس فتحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الربط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا تُحوَّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط السمة**

يتضمن مخطط خطوط السمة مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية لنص الجسم. تُظهر طُرُق [FontScheme.getMajor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontscheme/) و[FontScheme.getMinor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontscheme/) تلك المجموعات.

يمكن استخدام معرفات خطوط السمة المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان اللاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي الآسيوي الشرقي (Minor East Asian Font)
* `+mj-ea` - خط العنوان الآسيوي الشرقي (Major East Asian Font)

المثال التالي ينشئ عنوانًا واحدًا يستخدم خط السمة اللاتيني الرئيسي وسطرًا نصيًا يستخدم خط السمة اللاتيني الثانوي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلًا من معرف سمة لن يتحول تلقائيًا عندما يتغيّر مخطط خطوط السمة.

{{% alert color="info" title="Tip" %}}
لمزيد من المعلومات حول خطوط العرض،参见 [PowerPoint Fonts](/slides/ar/php-java/powerpoint-fonts/).
{{% /alert %}}

## **نسخ أو تطبيق سمة**

هناك سير عملان شائعان، ويحلان مشاكل مختلفة.

### **الحفاظ على سمة المصدر عند نقل الشرائح**

إذا رغبت في نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ الماستر المصدر إلى العرض الهدف باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/)، ثم استنسخ الشريحة باستخدام [SlideCollection.addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/) والماستر المستنسخ. هذا يحمل الماستر وتخطيطاته والسمة المرتبطة معًا.

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

هذا هو سير العمل المفضل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. مجرد استنساخ المحتوى إلى ماستر غير مرتبط قد يغيّر الألوان والخطوط والخلفيات والتأثيرات المدفوعة بالسمة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان على الشريحة المستهدفة البقاء على الماستر والتخطيط الحاليين، ابدء تجاوزًا على مستوى الشريحة من السمة المصدر. تقوم طُرُق [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/overridetheme/)، و[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ar/php-java/aspose.slides/overridetheme/) بنسخ مكونات السمة الثلاث الرئيسية إلى التجاوز.

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

هذا يغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة من الشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme.clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/overridetheme/).

### **تطبيق تجاوز سمة على تخطيط**

تطبيق تجاوز على مستوى التخطيط ينعكس على الشرائح التي تستخدم ذلك التخطيط، ما لم يكن لشريحة معينة تجاوز خاص بها. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/layoutslidethememanager/):

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

استخدم سمة على مستوى الماستر أو العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تُعقّد التجاوزات المتعددة على مستوى الشريحة تغييرات السمة العامة اللاحقة.

## **تحديث أنماط خلفية السمة**

يُخزن ملء خلفية السمة في [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/formatscheme/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهته مقارنةً بعدد تعريفات التعبئة المخزنة فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات السمة بألوان السمة ومراجع أنماط أخرى.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزنة و[Background.getStyleIndex](https://reference.aspose.com/slides/ar/php-java/aspose.slides/background/) الحالي. قيمة الفهرس `0` تعني عدم وجود تعبئة مُمَثلة؛ القيم الموجبة هي مراجع أنماط خلفية سمة. هذا يختلف عن فهرسة مجموعة PHP مباشرةً، حيث يعني `get_Item(0)` أول عنصر مخزن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يُبلغ عن عدد تعبئات الخلفية المتاحة، يُعيّن مرجع خلفية مُمَثل للماستر الأول، ويحفظ العرض:

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

{{% alert color="warning" title="Warning" %}}
لا تُعامل فهرس النمط كفهرس مجموعة صفرية. وتجنب أيضًا ترميز رقم نمط من ملف واحد وافتراض أن له نفس المظهر في ملف آخر؛ تعريفات أنماط السمة خاصة بالعرض.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
للتنسيق المباشر للخلفية والوراثة الخلفية، راجع [Presentation Background](/slides/ar/php-java/presentation-background/).
{{% /alert %}}

## **تحديث تأثيرات السمة**

يحتوي مخطط تنسيق السمة على مجموعات منفصلة من تعبئات الخطوط، الخطوط، وأنماط التأثير تُعرض عبر [FormatScheme.getFillStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/formatscheme/)، و[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ar/php-java/aspose.slides/formatscheme/). غالبًا ما تحتوي سمات Office على ثلاثة إدخالات أساسية تتطابق بصريًا مع تنسيقات خفيفة، معتدلة، وشديدة، لكن يجب على الكود فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في PHP، يكون فهرس المجموعة صفرًا مبنيًا: `get_Item(0)` هو أول نمط مخزن و`get_Item(2)` هو الثالث. فهارس مراجع النمط في الشكل مفهوم منفصل، تُعرض عبر [ShapeStyle](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تُشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود الإدخالات المطلوبة، يغيّر أول نمط خط، يغيّر ثالث نمط تعبئة، يفعّل ظلًا خارجيًا في ثالث نمط تأثير، ويحفظ النتيجة:

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

للأشكال التي تُشير إلى هذه الفتحات، يصبح أول خط سمة أحمر، وثالث تعبئة سمة خضراء غابية صلبة، والثالث تأثير يكتسب ظلًا خارجيًا بمسافة 10 نقاط. لا يزال المظهر البصري الدقيق يعتمد على أي فترات نمط كل شكل يُشير إليها وما إذا كان التنسيق المباشر يتجاوز السمة.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **قراءة قيم السمة الفعلية**

تخبرك كائنات السمة الخام بما تم تعريفه على مستوى معين. تُظهر القيم الفعلية ما تستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. للشريحة، استدعِ [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/background/)، وللتعبئة، استخدم [FillFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fillformat/).

المثال التالي يقرأ السمة الفعلية، الخلفية، وتعبئة الشكل الأول من شريحة:

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

استخدم البيانات الفعلية لتشخيص العرض، التحقق، والمقارنات. إذا فحصت فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/)، قد تفوتك ماستر أو تخطيط أو شريحة أو تجاوز شكل يغيّر المظهر النهائي.

## **الأسئلة الشائعة**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidethememanager/) الخاص بالشريحة وابدأ سمة التجاوز الخاصة بها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة سماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهرها الأصلي، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة باستخدام [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/masterslidecollection/) و[SlideCollection.addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slidecollection/). هذا يحافظ على الماستر، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعلية بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseoverridethememanager/) لسمة شريحة أو تخطيط والطرق الفعلية المقابلة لكائنات التنسيق مثل [Background.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/background/) و[FillFormat.getEffective](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المُحَلَّة بعد تطبيق الوراثة والتجاوزات.