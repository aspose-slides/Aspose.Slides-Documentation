---
title: مدیریت تم‌های ارائه در PHP
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/php-java/presentation-theme/
keywords:
- تم PowerPoint
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- رنگ تم
- پالت اضافه
- قلم تم
- سبک تم
- اثر تم
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای PHP از طریق Java برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکنواخت."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و اثرات را تعریف می‌کند. اشیای آگاه از تم به جای ذخیره هر ویژگی بصری به‌صورت مقدار ثابت، به این تعاریف مشترک ارجاع می‌دهند، بنابراین یک تغییر تم می‌تواند بسیاری از اشیا را همزمان به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) در دسترس است. یک ارائه می‌تواند همچنین با تنظیمات بازنویسی تم در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterthememanager/) بازنویسی کند، در حالی که یک لِی‌آوت یا یک اسلاید منفرد می‌تواند تم ارث‌بری‌شده خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseoverridethememanager/) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره وراثت حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لِی‌آوت و بازنویسی اسلاید.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری تم را نشان می‌دهند: بازرسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روزرسانی سبک‌های پس‌زمینه و اثر، و خواندن مقادیر مؤثر پس از حل وراثت و بازنویسی‌ها.

## **بازرسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/) طرح رنگی، طرح قلمی و طرح فرمت تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/) و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/) در دسترس می‌گذارد. بازرسی این مجموعه‌ها پیش از تغییر آن‌ها به‌ویژه وقتی مفید است که ارائه‌ای از منبع خارجی می‌آید، چون تعداد و محتوای ورودی‌های سبک می‌تواند متغیر باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و تعداد سبک‌های پس‌زمینه، پرکننده، خط و اثر ذخیره‌شده در تم را گزارش می‌کند:

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بازرسی کنید و هنگام وجود بازنویسی‌های لِی‌آوت یا اسلاید، از جریان کاری تم مؤثر که در ادامه مقاله نشان داده می‌شود استفاده کنید.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از Enum [SchemeColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/schemecolor/) ارجاع دهند. زمانی که ورودی متناظر در [ColorScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colorscheme/) را تغییر می‌دهید، تمام اشیایی که هنوز به آن رنگ تم ارجاع می‌دهند، نسبت به مقدار جدید حل می‌شوند. اشیایی که از یک رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ تم تغییر نمی‌گیرند.

مثال انتها به انتهای زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، آن را باز می‌گرداند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

چون مستطیل همچنان به `Accent4` متصل است، رنگ قابل مشاهده‌اش پس از تغییر تم به قرمز می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی در `Accent4` دیگر آن پرکننده را تحت‌اثر قرار نخواهد داد.

### **استفاده از رنگ‌ها از پالت اضافه**

PowerPoint با اعمال تبدیل‌های رنگی، قالب‌های روشن‌تر و تیره‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیل‌ها را از طریق Enum [ColorTransformOperation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colortransformoperation/) در دسترس قرار می‌دهد.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.

**2** - قالب‌های روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، برای پنج‌تای آن‌ها تبدیل‌های روشنایی اعمال می‌کند و نتیجه را ذخیره می‌نماید:

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

این قالب‌ها همچنان بر پایه رنگ تم باقی می‌مانند. اگر `Accent4` بعدها تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` مجدداً محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `ColorScheme`**

Enum [SchemeColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [ColorScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colorscheme/) همان اسلات‌های تم را به صورت `Dark1`، `Light1`، `Dark2` و `Light2` نشان می‌دهد. این نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ آن‌ها مقادیر دینامیکی نیستند که از یک قالب به قالب دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل مجموعه‌ای اصلی برای عناوین و یک مجموعه فرعی برای متن بدنه است. متدهای [FontScheme.getMajor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontscheme/) و [FontScheme.getMinor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontscheme/) این مجموعه‌ها را نمایش می‌دهند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (Minor Latin Font)
* `+mj-lt` - قلم عنوان لاتین (Major Latin Font)
* `+mn-ea` - قلم بدنه آسیای شرقی (Minor East Asian Font)
* `+mj-ea` - قلم عنوان آسیای شرقی (Major East Asian Font)

مثال زیر یک عنوان ایجاد می‌کند که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

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

عنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که نام قلم صریحی به‌جای شناسه تم داشته باشد، به‌صورت خودکار هنگام تغییر طرح قلم تم سوئیچ نخواهد شد.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری فردی مانند سیریلیک، عربی، ژاپنی، گرجی و ثانا باشند. برای بازرسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به [Script-Specific Theme Fonts](/slides/fa/php-java/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/php-java/powerpoint-fonts/) نگاه کنید.
{{% /alert %}}

## **کپی یا اعمال یک تم**

دو جریان کاری رایج وجود دارد که مشکلات متفاوتی را حل می‌کنند.

### **حفظ تم منبع هنگام جابه‌جایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائه‌ای دیگر منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) به ارائه هدف اضافه کنید، سپس اسلاید را با استفاده از [SlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) و مستر کلون‌شده کپی کنید. این کار مستر، لِی‌آوت‌های آن و تم مربوطه را همراه می‌برد.

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

این کار زمانی ترجیح داده می‌شود که اسلاید منبع باید همان ظاهر را در مقصد داشته باشد. ساده‌وار کپی محتوا روی مستری نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و اثرات هدایت‌شده توسط تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و لِی‌آوت جاری خود بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/) و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/) سه مؤلفه اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم ارث‌بری‌شده توسط اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌بری‌شده، [OverrideTheme.clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/) را صدا بزنید.

### **اعمال بازنویسی تم به یک لِی‌آوت**

یک بازنویسی سطح لِی‌آوت بر روی اسلایدهایی که از آن لِی‌آوت استفاده می‌کنند اعمال می‌شود، مگر این‌که اسلاید خاصی بازنویسی خود را داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslidethememanager/) استفاده شوند:

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

از تم سطح مستر یا ارائه استفاده کنید وقتی که بسیاری از لِی‌آوت‌ها و اسلایدها باید طراحی پایه یکسانی را به اشتراک بگذارند؛ از بازنویسی لِی‌آوت وقتی یک خانواده لِی‌آوت نیاز به سبک متفاوت دارد استفاده کنید؛ و فقط برای استثناهای واقعی از بازنویسی اسلاید استفاده کنید. بازنویسی‌های بیش از حد سطح اسلاید باعث می‌شود پیش‌بینی تغییرات تم کلی بعدی دشوارتر شود.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری را در UI خود نمایش دهد نسبت به تعداد تعریف‌های پرکننده‌ای که به‌طور فیزیکی در این مجموعه ذخیره شده‌اند، زیرا UI می‌تواند پرکننده‌های تم را با رنگ‌های تم و دیگر ارجاعات سبک ترکیب کند.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و [Background.getStyleIndex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) فعلی را بررسی کنید. یک شاخص سبک `0` به معنای عدم وجود پرکننده تم است؛ مقادیر مثبت ارجاع‌های سبک پس‌زمینه تم هستند. این متفاوت از اندیس‌گذاری مستقیم مجموعه PHP است، جایی که `get_Item(0)` اولین مورد ذخیره‌شده را نشان می‌دهد. فرض نکنید که هر ارائه همان تعداد سبک پرکننده پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌کند، یک ارجاع پس‌زمینه تم را به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجه قابل مشاهده به تم ارجاع‌شده توسط مستر و هر بازنویسی پس‌زمینه در لِی‌آوت یا سطح اسلاید بستگی دارد. اگر اسلاید پس‌زمینه خودش را داشته باشد، تغییر تنها پس‌زمینه مستر ممکن است آن اسلاید را تغییر نداده باشد. هنگام نیاز به دانستن پس‌زمینه نهایی پس از اعمال وراثت، از [Background.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
شاخص سبک را به‌عنوان اندیس صفر‌پایه مجموعه در نظر نگیرید. همچنین از کدگذاری سخت یک شماره سبک از یک فایل و فرض اینکه همان ظاهر را در فایل دیگر دارد، خودداری کنید؛ تعاریف سبک تم به‌صورت خاص برای هر ارائه هستند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، به [Presentation Background](/slides/fa/php-java/presentation-background/) رجوع کنید.
{{% /alert %}}

## **به‌روزرسانی اثرهای تم**

یک طرح فرمت تم شامل مجموعه‌های جداگانه پرکننده، خط و اثر است که از طریق [FormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/) و [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/) در دسترس هستند. تم‌های Office معمولاً سه ورودی اصلی سبک دارند که به‌صورت بصری به فرمت‌های ملایم، متوسط و شدید متناظرند، اما کد باید هر مجموعه را بازرسی کند به‌جای اینکه تعداد ثابت را فرض کند.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

هنگامی که این مجموعه‌ها را در PHP دسترسی می‌کنید، ایندکس مجموعه صفر‑پایه است: `get_Item(0)` اولین سبک ذخیره‌شده و `get_Item(2)` سومین است. ایندکس‌های ارجاع‑سبک یک شکل مفهومی جداگانه است که از طریق [ShapeStyle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapestyle/) در دسترس است. تغییر یک سبک تم بر اشکالی که به آن سبک ارجاع می‌دهند اثر می‌گذارد؛ اشکالی که دارای قالب‌بندی مستقیم هستند ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های سبک مورد نیاز وجود دارند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، سایهٔ خارجی را در سومین سبک اثر فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای اشکالی که به این اسلات‌ها ارجاع می‌دهند، اولین سبک خط تم به رنگ قرمز تبدیل می‌شود، سومین سبک پرکننده تم به سبز جنگلی ثابت تبدیل می‌شود و سومین سبک اثر یک سایهٔ خارجی با فاصلهٔ 10 نقطه دریافت می‌کند. نتیجهٔ بصری دقیق همچنان به این‌که هر شکل به کدام اسلات‌های سبک ارجاع می‌دهد و آیا قالب‌بندی مستقیم بر تم ارجاع می‌کند یا خیر، بستگی دارد.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

اشیای خام تم به شما می‌گویند که در سطح خاصی چه چیزی تعریف شده است. مقادیر مؤثر به شما می‌گویند که یک اسلاید یا شکل پس از حل وراثت و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseoverridethememanager/) را صدا بزنید. برای یک پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) استفاده کنید و برای یک پرکننده، از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) بهره ببرید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکننده شکل را از یک اسلاید می‌خواند:

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را بازرسی کنید، ممکن است یک بازنویسی مستر، لِی‌آوت، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **سؤالات متداول**

**آیا می‌توانم یک تم را فقط بر یک اسلاید اعمال کنم بدون اینکه مستر را تغییر دهم؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidethememanager/) اسلاید استفاده کنید و بازنویسی تم آن را مقداردهی اولیه کنید. تغییر به‌صورت محلی بر آن اسلاید باقی می‌ماند؛ اسلایدهای دیگر به تم‌های موجود خود ادامه می‌دهند.

**ایمن‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**

هنگام جابه‌جایی یک اسلاید و حفظ ظاهر منبع آن، مستر منبع را به مقصد کلون کنید و اسلاید را با استفاده از [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) و [SlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) کلون کنید. این کار مستر، لِی‌آوت‌ها و تم را با هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از وراثت و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseoverridethememanager/) برای یک تم اسلاید یا لِی‌آوت و روش‌های داده‑مؤثر مربوط به اشیای فرمت مانند [Background.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) استفاده کنید. این APIها مقادیر حل‑شده پس از اعمال وراثت و بازنویسی‌ها را برمی‌گردانند.