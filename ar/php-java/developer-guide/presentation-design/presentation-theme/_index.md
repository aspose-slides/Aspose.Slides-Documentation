---
title: إدارة سمات العروض في PHP
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
- سمة خارجية
- THMX
- لون السمة
- لوحة ألوان إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض
- PHP
- Aspose.Slides
description: "إدارة سمات العروض في Aspose.Slides للـ PHP عبر Java لإنشاء وتخصيص وتحويل ملفات PowerPoint بعلامة تجارية متسقة."
---
## **مقدمة**

يحدد سمة العرض مجموعة منسقة من الألوان، الخطوط، أنماط الخلفية، التعبئات، الخطوط، والتأثيرات. تُشير الكائنات المدركة للسمات إلى هذه التعريفات المشتركة بدلاً من تخزين كل خاصية بصرية كقيمة ثابتة، وبالتالي يمكن لتغيّر السمة أن يُحدّث العديد من الكائنات مرة واحدة.

في Aspose.Slides، تتوفر سمة مستوى العرض عبر [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). يمكن للعرض أيضًا أن يحتوي على تجاوزات للسمات في مستويات أدنى. يمكن للماستر أن يتجاوز سمة العرض عبر [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/)، بينما يمكن للتخطيط أو الشريحة الفردية أن يتجاوز سمة الموروثة عبر [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). عمليًا، يتم حل السمة الفعّالة لشريحة من خلال سلسلة الوراثة التالية: سمة العرض، تجاوز الماستر، تجاوز التخطيط، وتجاوز الشريحة.

![مكوّنات السمة: الألوان، الخطوط، أنماط الخلفية، والتأثيرات](theme-constituents.png)

تُظهر الأقسام أدناه أكثر سير عمل شائع للسمات: فحص سمة، تغيير الألوان والخطوط، نسخ أو تطبيق سمة، تحديث أنماط الخلفية والتأثيرات، وقراءة القيم الفعّالة بعد حل الوراثة والتجاوزات.

## **فحص سمة**

يُظهر كائن [MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) مخطط ألوان السمة، مخطط الخطوط، ومخطط التنسيق من خلال [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/)، [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/)، و[MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/). فحص هذه المجموعات قبل تعديلها مفيد بشكل خاص عندما يأتي العرض من مصدر خارجي لأن عدد ومحتوى مدخلات الأنماط قد يختلف.

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

إذا كان الملف يستخدم عدة ماستر، لا تفترض أن كل شريحة لها نفس السمة الفعّالة. افحص الماستر المرتبط بالشريحة، واستخدم سير عمل السمة الفعّالة الموضح لاحقًا في هذه المقالة عندما قد تكون هناك تجاوزات للتخطيط أو الشريحة.

## **تغيير ألوان السمة**

يمكن للتعبئات، الخطوط، والنصوص المدركة للسمات أن تشير إلى لون منطقي من تعداد [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/). عندما تغير المدخل المقابل في [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/)، تُحل جميع الكائنات التي لا تزال تشير إلى ذلك اللون السُمِيّ ضد القيمة الجديدة. الكائنات التي تستخدم لون RGB مباشر لا تتغيّر نتيجة تحديث لون السمة.

المثال الشامل التالي ينشئ شكلًا يستخدم `Accent4`، يغيّر لون `Accent4` في السمة إلى الأحمر، يحفظ العرض، يعيده للفتح، ويطبع لون التعبئة الفعّال:

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

نظرًا لأن المستطيل لا يزال مرتبطًا بـ `Accent4`، يصبح لونه المرئي أحمر بعد تغيير السمة. إذا استبدلت لون المخطط بلون مباشر على الشكل، فإن التغييرات اللاحقة على `Accent4` لن تؤثر بعد ذلك على تلك التعبئة.

### **استخدام الألوان من اللوحة الإضافية**

تستخرج PowerPoint متغيرات أفتح وأغمق من لون السمة عبر تطبيق تحولات اللون. تعرض Aspose.Slides هذه التحولات من خلال تعداد [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/).

![الألوان الرئيسية للثيم والألوان الأفتح والأغمق المولدة من اللوحة الإضافية](additional-palette-colors.png)

**1** - الألوان الرئيسية للثيم.

**2** - المتغيرات الأفتح والأغمق المنتجة من الألوان الرئيسية للثيم.

المثال التالي ينشئ ستة مستطيلات بناءً على `Accent4`، يطبق تحولات الإضاءة على خمسة منها، ويحفظ النتيجة:

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

هذه المتغيرات تظل مبنية على لون السمة. إذا تغيّر `Accent4` لاحقًا، تُعاد حساب الألوان المتحوّلة من القيمة الجديدة لـ `Accent4`.

### **ربط قيم `SchemeColor` بفتحات `ColorScheme`**

يستخدم تعداد [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) القيم `Text1`، `Background1`، `Text2`، و`Background2`، بينما يُظهر تعداد [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) نفس فتحات السمة كـ `Dark1`، `Light1`، `Dark2`، و`Light2`. الترابط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هذه أسماء بديلة لنفس فتحات السمة؛ ليست قيمًا تُحوّل ديناميكيًا من شكل إلى آخر.

## **تغيير خطوط السمة**

تحتوي مخطط خطوط السمة على مجموعة خطوط رئيسية للعناوين ومجموعة خطوط ثانوية للنص الأساسي. تُظهر طريقتا [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) و[FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) تلك المجموعات.

يمكن استخدام معرفات خطوط السمة المتوافقة مع PowerPoint في تنسيق النص:

* `+mn-lt` - خط النص الأساسي اللاتيني (Minor Latin Font)
* `+mj-lt` - خط العنوان اللاتيني (Major Latin Font)
* `+mn-ea` - خط النص الأساسي الآسيوي الشرقي (Minor East Asian Font)
* `+mj-ea` - خط العنوان الآسيوي الشرقي (Major East Asian Font)
* `+mn-cs` - خط النص الأساسي للنص المعقّد (Minor Complex Script Font)
* `+mj-cs` - خط العنوان للنص المعقّد (Major Complex Script Font)

المثال التالي ينشئ عنوانًا واحدًا يستخدم خط السمة اللاتيني الرئيسي وخطًا أساسيًا واحدًا يستخدم خط السمة اللاتيني الثانوي. ثم يغيّر خطوط السمة ويحفظ النتيجة:

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

العنوان يتبع الخط الرئيسي والنص الأساسي يتبع الخط الثانوي. النص الذي يحتوي على اسم خط صريح بدلاً من معرف السمة لن يتحول تلقائيًا عندما يتغيّر مخطط خطوط السمة.

يمكن أن تحتوي مجموعات الخطوط الرئيسية والثانوية أيضًا على تعيينات خطوط لأنظمة كتابة فردية، مثل السيريالية، العربية، اليابانية، الجورجية، والثآنا. لفحص، إضافة، استبدال، أو إزالة هذه التعيينات، راجع [Script-Specific Theme Fonts](/slides/ar/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

لمزيد من المعلومات حول خطوط العرض، راجع [PowerPoint Fonts](/slides/ar/php-java/powerpoint-fonts/).

{{% /alert %}}

### **حل مراجع خطوط السمة**

عند فحص النص، يمكن أن تُعيد [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) مرجعًا للسمة مثل `+mn-lt` بدلاً من اسم عائلة الخط. استدعِ [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) ببيانات السمة الفعّالة المناسبة لحل ذلك المرجع. تُحدِّد البادئان `+mj` و`+mn` مجموعات الخطوط الرئيسية والثانوية؛ تُحدِّد اللاحقان `-lt`، `-ea`، و`-cs` خطوطهم اللاتينية، الآسيوية الشرقية، والنص المعقّد على التوالي.

احصل على السمة الفعّالة عبر [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) على الكائن الذي تُطبق سمةه على النص المفحوص. بالنسبة للنص العادي على شريحة، استدعِ هذه الطريقة على الشريحة بحيث يشمل السياق السمة الموروثة لتلك الشريحة وتجاوزاتها المحلية. عند فحص تخطيط أو ماستر نفسه، استخدم سمةه الفعّالة. لا تفترض أن سمة الماستر الأول تنطبق على كل شريحة.

المثال التالي ينشئ جزء نصي يُشير صراحةً إلى الخط اللاتيني الثانوي. يهيء مخطط خط شريحة عبر [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) ويعيّن عائلتي الخطوط اللاتينية الرئيسيتين والثانويتين إلى `Arial` و`Calibri`، مما يجعل النتيجة قابلة لإعادة الإنتاج بدون ملف إدخال.

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

الإخراج هو `+mn-lt -> Calibri` يليه `Verdana -> Verdana`. يبقى المرجع المخزن دون تغيير، بينما يُعاد إرجاع اسم العائلة الصريح كما هو. إذا استخدم الجزء `+mj-lt`، لكان سيُحل إلى `Arial` في هذه السمة.

حل مرجع السمة يحدد عائلة الخط المحددة بواسطة السمة. لا يتحقق من توفر الخط أو يحدد ملف الخط المستخدم نهائيًا بعد الاستبدال أو fallback للglyph أثناء التصيير. راجع [Font Selection Sequence](/slides/ar/php-java/font-selection-sequence/) و[Font Substitution](/slides/ar/php-java/font-substitution/) لتلك الخطوات المنفصلة.

## **نسخ أو تطبيق سمة**

تحلّ سير العمل أدناه مشاكل مختلفة متعلقة بالسمات.

### **تطبيق سمة خارجية على شرائح تعتمد على ماستر**

استخدم [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) عندما يكون لديك ملف سمة PowerPoint (`.thmx`) وتريد إعادة تنسيق كل شريحة تعتمد على ماستر معين. اختر الماستر من مجموعة [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، التي يُمثلها [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/)، ومرّر مسار ملف السمة إلى الطريقة.

تنفّذ الطريقة العمليات التالية:

1. تنشئ ماستر شريحة جديد بناءً على الماستر المحدد.
1. تطبق السمة الخارجية على الماستر الجديد.
1. تُعيّن الماستر الجديد لجميع الشرائح التي كانت تعتمد سابقًا على الماستر المحدد.
1. تُعيد كائن [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) المُنشأ حديثًا.

المثال التالي يطبق سمة خارجية على الشرائح التي تعتمد على الماستر الأول ويحفظ العرض:

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

قد يتسبب سمة غير صالحة، معطوبة، أو غير مدعومة في حدوث [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/). تحقق من صحة المسارات التي يُزودها المستخدمون، وتعامل مع فشل الوصول إلى نظام الملفات، واحفظ العرض فقط بعد تطبيق السمة بنجاح.

يُعاد تعيين الشرائح التي كانت تعتمد على الماستر المحدد فقط. الشرائح المرتبطة بماستر آخر تحتفظ بماستراتها الحالية وسيماتها. تُحلّ الألوان، الخطوط، التعبئات، الخطوط، الخلفيات، والتأثيرات المدرة للسمات ضد السمة الخارجية. قد تظل الألوان، الخطوط، التعبئات، والتنسيقات الصريحة التي تم تعيينها مباشرةً دون تغيير. يمكن لتجاوزات المستوى التخطيطي ومستوى الشريحة أيضًا أن تتفوّق على القيم الموروثة من الماستر الجديد.

قد تُشير السمة إلى خطوط غير متوفرة في بيئة وقت التشغيل. للحصول على تصيير وتصدير متسق، ثبّت الخطوط المطلوبة، وفرّها عبر [مصادر الخطوط المخصّصة](/slides/ar/php-java/custom-font/)، أو اضبط [استبدال الخطوط](/slides/ar/php-java/font-substitution/).

هذا سير عمل مباشر على مستوى الماستر: تقبل الطريقة مسار ملف `.thmx` ولا تتطلب إنشاء تجاوزات سمة يدوية على مستوى الشريحة أو التخطيط.

### **تطبيق سمات خارجية مختلفة في عرض متعدد الماسترات**

عندما لا يُعرف الماستر المناسب مسبقًا، احصل عليه من شريحة تمثيلية عبر [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) و[LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/). احفظ مراجع الماسترات الأصلية قبل تطبيق أي سمات لأن كل استدعاء يُنشئ ماسترًا آخر في العرض.

المثال التالي يستخدم شرائح من قسمين لتحديد ماستراتها ويطبق سمة خارجية مختلفة على كل مجموعة:

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

النداء الأول يؤثّر فقط على الشرائح التي كانت تعتمد على `$firstGroupMaster`، والنداء الثاني يؤثّر فقط على الشرائح التي كانت تعتمد على `$secondGroupMaster`. الشرائح التابعة لأي ماستر آخر لا تُعاد تنسيقها.

### **حفظ سمة المصدر عند نقل الشرائح**

إذا رغبت في نقل شريحة إلى عرض آخر مع الحفاظ على تصميمها الأصلي، استنسخ الماستر الأصلي إلى العرض الهدف باستخدام [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/)، ثم استنسخ الشريحة باستخدام [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) والماستر المستنسخ. هذا يحمل الماستر وتخطيطاتها والسمة المرتبطة معًا.

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

هذا هو سير العمل المفضَّل عندما يجب أن تبدو الشريحة المصدرية نفسها في الوجهة. النسخ البسيط للمحتوى على ماستر هدف غير مرتبط قد يغيّر الألوان، الخطوط، الخلفيات، والتأثيرات المدفوعة بالسمّة.

### **تطبيق قيم السمة على شريحة موجودة**

إذا كان يجب أن تبقى الشريحة الهدف على ماسترها وتخطيطها الحالي، ابدئ تجاوزًا على مستوى الشريحة من سمة المصدر. تقوم طرق [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/)، [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/)، و[OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) بنسخ المكوّنات الثلاثة الرئيسية للثيم إلى التجاوز.

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

هذا يغيّر السمة المستخدمة لتلك الشريحة دون تغيير السمة الموروثة للشرائح الأخرى. لإزالة التجاوز المحلي والعودة إلى القيم الموروثة، استدعِ [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/).

### **تطبيق تجاوز السمة على تخطيط**

تطبق التجاوزات على مستوى التخطيط على الشرائح التي تستخدم ذلك التخطيط، إلا إذا كان لشريحة معينة تجاوزها الخاص. يمكن استخدام نفس طرق التهيئة عبر [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/):

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

استخدم سمة ماستر أو سمة على مستوى العرض عندما يجب أن تشترك العديد من التخطيطات والشرائح في نفس التصميم الأساسي، واستخدم تجاوز التخطيط عندما تحتاج عائلة تخطيط واحدة إلى تنسيق مختلف، واستخدم تجاوز الشريحة فقط للاستثناءات الحقيقية. تجعل التجاوزات المفرطة على مستوى الشريحة من الصعب توقع تغييرات السمة العالمية لاحقًا.

## **تحديث أنماط خلفية السمة**

تُخزَّن تعبئات خلفية السمة في [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). يمكن لـ PowerPoint عرض خيارات خلفية أكثر في واجهتها من عدد تعريفات التعبئة المخزَّنة فعليًا في هذه المجموعة لأن الواجهة يمكنها دمج تعبئات السمة مع ألوان السمة ومراجع الأنماط الأخرى.

![معرض أنماط خلفية PowerPoint لسمة عرض](presentation-design_8.png)

قبل استخدام نمط خلفية، افحص المجموعة المخزَّنة و[Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/) الحالي. مؤشر النمط `0` يعني عدم وجود تعبئة م thème؛ القيم الموجبة تشير إلى مراجع أنماط خلفية السمة. هذا مختلف عن فهرسة مجموعة PHP مباشرةً، حيث يعني `get_Item(0)` العنصر الأول المخزَّن. لا تفترض أن كل عرض يحتوي على نفس عدد أنماط تعبئة الخلفية.

المثال التالي يُبلغ عن عدد تعبئات الخلفية المتاحة، يُعيّن مرجع خلفية م thème للماستر الأول، ويحفظ العرض:

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

النتيجة المرئية تعتمد على مدخل السمة الذي يُشير إليه الماستر وأي تجاوزات خلفية على مستوى التخطيط أو الشريحة. إذا استخدمت شريحة خلفيتها الخاصة، قد لا يُغيّر تغيير خلفية الماستر فقط تلك الشريحة. استخدم [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) عندما تحتاج إلى معرفة الخلفية النهائية بعد تطبيق الوراثة.

{{% alert color="warning" title="Warning" %}}

لا تعامل مؤشر النمط كفهرس مجموعة يبدأ من الصفر. كذلك تجنّب ترميز رقم نمط من ملف واحد وافتراض أنه سيظهر بنفس الشكل في ملف آخر؛ تعريفات نمط السمة خاصة بالعرض.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

للتنسيق المباشر للخلفية والوراثة، راجع [Presentation Background](/slides/ar/php-java/presentation-background/).

{{% /alert %}}

## **تحديث تأثيرات السمة**

يحتوي مخطط تنسيق السمة على مجموعات منفصلة لتعبئات، خطوط، وتأثيرات أنماط يُعرض من خلال [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/)، [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/)، و[FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). غالبًا ما تحتوي سمات Office على ثلاثة مدخلات أساسية تتCorrespond بصريًا إلى تنسيقات خفيفة، متوسطة، ومكثفة، لكن يجب على الشيفرة فحص كل مجموعة بدلاً من افتراض عدد ثابت.

![تأثيرات السمة الخفيفة، المتوسطة، والمكثفة مطبقة على نفس الشكل](presentation-design_10.png)

عند الوصول إلى هذه المجموعات في PHP، يكون فهرس المجموعة يبدأ من الصفر: `get_Item(0)` هو أول نمط مخزَّن و`get_Item(2)` هو الثالث. مؤشرات مرجع نمط الشكل هي مفهوم منفصل، يُعرض عبر [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/). تعديل نمط سمة يؤثر على الأشكال التي تُشير إلى ذلك النمط؛ قد تظل الأشكال ذات التنسيق المباشر دون تغيير.

المثال التالي يتحقق من وجود مدخلات النمط المطلوبة، يغيّر نمط الخط الأول، يغيّر نمط التعبئة الثالث، يُفعّل ظلًا خارجيًا في النمط التأثير الثالث، ويحفظ النتيجة:

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

للأشكال التي تُشير إلى هذه الفتحات، يصبح أول نمط خط سمة أحمر، ويصبح نمط التعبئة الثالث سمة خضراء صلبة، ويكتسب النمط التأثير الثالث ظلًا خارجيًا بمسافة 10 نقاط. لا يزال النتيجة البصرية الدقيقة تعتمد على أي فترات نمط كل شكل يُشير إليها وما إذا كان التنسيق المباشر يتجاوز السمة.

![أنماط تأثير السمة بعد تغيير الخط، التعبئة، وإعدادات الظل](presentation-design_11.png)

## **تحديد أنماط تعبئة وخط السمة لشكل**

يمكن للشكل اختيار تعبئته ومخططه المستقل عبر [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) و[ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex). لكل طريقة، المؤشر `1` يختار المدخل الأول في مجموعة السمة المقابلة (`get_Item(0)`)، والمؤشر `2` يختار الثاني (`get_Item(1)`).

المثال التالي يهيئ نمطين تعبئة (ذهب وسماء زرقاء) ونمطين خط (أزرق غامق 6 pt وأحمر غامق 12 pt) في السمة الافتراضية لعرض جديد. يحفظ الشريحة في ثلاث مراحل لتتمكّن من مقارنة النتائج في PowerPoint.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| الأنماط الأولية | تغيير المخطط الأيمن | تعديل أول تعبئة سمة |
|:---:|:---:|:---:|
| ![مستطيلات ذهبية وزرقاء سماوية مع مخططات زرقاء غامقة رقيقة متطابقة](theme-style-initial.png) | ![المستطيل الزرقاء السماوية الآن لديه مخطط أحمر غامق سميك](theme-style-line-changed.png) | ![المستطيل الأيسر الآن أخضر وكلا المخططات دون تغيير](theme-style-fill-changed.png) |

اختيار نمط خط مختلف يغيّر فقط مخطط المستطيل الأيمن. تعديل أول تعبئة سمة يُحدّث كل شكل يستخدمها. هنا، يصبح المستطيل الأيسر أخضر فقط.

على شكل موجود، يمكن للون تعبئة محلي، لون خط، أو سماكة خط أن يتجاوز ذلك الجزء من نمط السمة. إذا لم يُظهر تغيير مؤشر النمط تأثيرًا مرئيًا، تحقق من [التنسيق المباشر](/slides/ar/php-java/shape-formatting/) للشكل.

## **تحديد ما إذا كانت التعبئة الصلبة الفعّالة تستخدم لون سمة**

يمكن أن تُخزن التعبئة مباشرةً على كائن أو تُورَث من فقرة، تخطيط، ماستر، نمط سمة، أو مستوى تنسيق آخر. استدعِ [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) لحل تلك التسلسل الهرمي إلى بيانات تعبئة صلبة غير قابلة للتغيير. أولًا تحقق من نتيجة `getFillType`. فقط عندما تكون `FillType::Solid` يجب قراءة خصائص التعبئة الصلبة.

بالنسبة لتعبئة صلبة، تُعيد `getSolidFillColor` القيمة النهائية RGB بعد الوراثة، البحث في السمة، وتطبيق تحولات اللون. تُعيد طريقة `getSolidFillSchemeColor` الفتحة المنطقية المتCorrespond من [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) مثل `Text1` أو `Accent6`. قيمة `SchemeColor::NotDefined` تعني أن التعبئة الصلبة الفعّالة ليست مبنية على لون مخطط. في سير عمل حيث تكون التعبئات إما ألوان سمة أو ألوان RGB مباشرة، تحدد هذه القيمة تعبئة RGB مباشرة.

لا تستخدم قيمة [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) المحلية وحدها لتصنيف تعبئة. على سبيل المثال، قد لا تحتوي قطعة نص على لون مخطط معرف محليًا، لذا تكون قيمتها المحلية `NotDefined`، بينما تُورّث تعبئتها الفعّالة لون سمة وتُحل إلى `Text1` أو `Accent6`. وعلى العكس، تُظهر `getSolidFillSchemeColor` الفتحة المنطقية التي أنتجت اللون الفعّال، لكنها لا تخبرك ما إذا كانت تلك الفتحة جاءت من الكائن، الفقرة، التخطيط، الماستر، أو مستوى آخر.

المثال التالي يحمل عرضًا، يدقق كل تعبئات الأشكال وتعبئات قطع النص، يطبع كل قيمة RGB نهائية والقيمة المخططة المرتبطة، ويُعلِّم التعبئات الصلبة التي لن تتعقّب تغيّر ألوان السمة:

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

الفرع `NotDefined` يوفر قائمة تدقيق لتعبئات صلبة لن تستجيب لتغيّرات فتحة لون السمة. راجع تلك الكائنات عندما يجب أن يتبع العرض لوحة ألوان علامة تجارية جديدة. لا يزال قيمة RGB المبلغ عنها تُظهر المظهر الحالي، بينما تُوضح القيمة المخططة ما إذا كان هذا المظهر مرتبطًا بالسمة.

كائنات الصيغة الفعّالة هي لقطة. بعد تغيير سمة العرض، أو تجاوز سمة، أو أي تنسيق موروث، استدعِ `getEffective` مرة أخرى واقرأ بيانات التعبئة الفعّالة الجديدة قبل المقارنة أو الإبلاغ عن الألوان.

## **قراءة قيم السمة الفعّالة**

تخبرك كائنات السمة الخام بما تم تعريفه على مستوى معين. تُخبِرك القيم الفعّالة بما يستخدمه الشريحة أو الشكل فعليًا بعد حل الوراثة والتجاوزات المحلية. لشريحة، استدعِ [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). للخلفية، استخدم [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/)، وللتعبئة استخدم [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/).

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

استخدم البيانات الفعّالة للتشخيصات، التحقق من الصحة، والمقارنات. إذا فحصت فقط [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، قد تفوتك تجاوزات ماستر، تخطيط، شريحة، أو شكل تُغيّر المظهر النهائي.

## **الأسئلة المتكررة**

**هل تطبيق سمة خارجية يؤثر على كل شريحة في العرض؟**

لا. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) يُعيد تعيين الشرائح التي تعتمد على الماستر المحدد فقط. الشرائح التي تستخدم ماسترات أخرى تحتفظ بسمااتها الحالية.

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير الماستر؟**

نعم. استخدم [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) الخاص بالشريحة وابدأ سمة التجاوز الخاصة بها. يبقى التغيير محليًا لتلك الشريحة؛ تستمر الشرائح الأخرى في وراثة سماتها الحالية.

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟**

عند نقل شريحة والحفاظ على مظهر المصدر، استنسخ الماستر المصدر إلى الوجهة واستنسخ الشريحة مع ذلك الماستر باستخدام [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) و[SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/). هذا يحافظ على الماستر، التخطيطات، والسمة معًا.

**كيف يمكنني رؤية القيم الفعّالة بعد الوراثة والتجاوزات؟**

استخدم [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) لسمة شريحة أو تخطيط، والطُرُق الفعّالة المقابلة لكائنات التنسيق مثل [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) و[FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/). تُعيد هذه الواجهات القيم المحلولة بعد تطبيق الوراثة والتجاوزات.