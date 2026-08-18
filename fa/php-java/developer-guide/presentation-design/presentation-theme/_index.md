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
- پالت اضافی
- فونت تم
- سبک تم
- افکت تم
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای PHP از طریق Java برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ ثابت."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، فونت‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای آگاه از تم به این تعاریف مشترک ارجاع می‌دهند به‌جای این‌که هر ویژگی بصری را به‌صورت مقدار ثابت ذخیره کنند، بنابراین تغییر تم می‌تواند به‌صورت یک‌باره بسیاری از اشیاء را به‌روز کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) در دسترس است. یک ارائه می‌تواند بازنویسی‌های تم در سطوح پایین‌تری نیز داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterthememanager/) بازنویسی کند، در حالی که یک لِی‌اوت یا یک اسلاید منفرد می‌تواند تم ارث‌بری شده خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseoverridethememanager/) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیر ارث‌بری حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لِی‌اوت و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، فونت‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری تم را نشان می‌دهند: بازبینی تم، تغییر رنگ‌ها و فونت‌ها، کپی یا اعمال تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل ارث‌بری و بازنویسی‌ها.

## **بازرسی تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/) طرح رنگی، طرح فونتی و طرح قالب تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/) و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/) در دسترس می‌کند. بازبینی این مجموعه‌ها پیش از تغییر آن‌ها به‌ویژه وقتی ارائه از منبع خارجی می‌آید مفید است، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و گزارش می‌دهد چند سبک پس‌زمینه، پرکننده، خط و افکت در تم ذخیره شده‌اند:

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بازبینی کنید و از جریان کاری تم مؤثر که در ادامه مقاله نشان داده شده استفاده کنید وقتی بازنویسی‌های لِی‌اوت یا اسلاید ممکن است وجود داشته باشند.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از شمارش [SchemeColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی متناظر در [ColorScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colorscheme/) را تغییر می‌دهید، همهٔ اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند بر اساس مقدار جدید حل می‌شوند. اشیائی که از رنگ RGB مستقیم استفاده می‌کنند توسط به‌روزرسانی رنگ تم تغییری نمی‌بینند.

مثال پایان‑به‑پایان زیر یک شکل را ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، مجدداً باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

از آنجا که مستطیل به `Accent4` متصل باقی می‌ماند، رنگ قابل مشاهدهٔ آن پس از تغییر تم به قرمز تبدیل می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکننده تأثیری نخواهد داشت.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیلات رنگ، انواع روشن‌تر و تیره‌تر را از یک رنگ تم تولید می‌کند. Aspose.Slides این تبدیلات را از طریق شمارش [ColorTransformOperation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تر تولید شده از پالت اضافی](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.

**2** - انواع روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایهٔ `Accent4` ایجاد می‌کند، تبدیلات روشنایی را به پنج مورد از آن‌ها اعمال می‌کند و نتیجه را ذخیره می‌نماید:

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

این انواع همچنان بر پایهٔ رنگ تم باقی می‌مانند. اگر `Accent4` بعداً تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` مجدداً محاسبه می‌شوند.

### **نقشه‌گذاری مقادیر `SchemeColor` به اسلات‌های `ColorScheme`**

شمارش [SchemeColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [ColorScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colorscheme/) همان اسلات‌های تم را به صورت `Dark1`، `Light1`، `Dark2` و `Light2` در اختیار می‌گذارد. نقشه‌گذاری ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ آن‌ها مقادیری که به‌صورت پویا از یک شکل به شکل دیگر تبدیل می‌شوند نیستند.

## **تغییر فونت‌های تم**

یک طرح فونت تم شامل یک مجموعهٔ فونت اصلی برای عناوین و یک مجموعهٔ فونت فرعی برای متن بدنه است. متدهای [FontScheme.getMajor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontscheme/) و [FontScheme.getMinor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontscheme/) این مجموعه‌ها را در دسترس می‌گذارند.

شناسه‌های فونت تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn‑lt` - فونت بدنه لاتین (فونت لاتین جزئی)
* `+mj‑lt` - فونت عنوان لاتین (فونت لاتین اصلی)
* `+mn‑ea` - فونت بدنه آسیای شرقی (فونت آسیای شرقی جزئی)
* `+mj‑ea` - فونت عنوان آسیای شرقی (فونت آسیای شرقی اصلی)

مثال زیر یک عنوان که از فونت لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از فونت لاتین جزئی تم استفاده می‌کند ایجاد می‌کند. سپس فونت‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

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

عنوان از فونت اصلی پیروی می‌کند و متن بدنه از فونت جزئی. متنی که نام فونت صریح دارد به‌جای شناسهٔ تم به‌صورت خودکار زمانی که طرح فونت تم تغییر کند، جابه‌جا نمی‌شود.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر دربارهٔ فونت‌های ارائه، به [PowerPoint Fonts](/slides/fa/php-java/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال تم**

دو جریان کاری رایج وجود دارد که هر یک مشکل متفاوتی را حل می‌کند.

### **حفظ تم منبع هنگام انتقال اسلایدها**

اگر می‌خواهید یک اسلاید را به ارائهٔ دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) به ارائهٔ مقصد اضافه کنید، سپس اسلاید را با استفاده از [SlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) و مستری که کلون شده است کلون کنید. این کار مستر، لِی‌اوت‌های آن و تم مرتبط را به‌صورت یک‌جا منتقل می‌کند.

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

این روش ترجیح داده می‌شود وقتی اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. سادهٔ کلون کردن محتوا بر روی مستر مقصد نامرتبط می‌تواند رنگ‌ها، فونت‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و لِی‌اوت فعلی خود بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/) و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/) سه مؤلفهٔ اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم مورد استفادهٔ آن اسلاید را بدون تغییر تم ارث‌بری شده توسط اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌بری شده، فراخوانی کنید [OverrideTheme.clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/).

### **اعمال یک بازنویسی تم به یک لِی‌اوت**

بازنویسی سطح لِی‌اوت بر اسلایدهایی که از آن لِی‌اوت استفاده می‌کنند اعمال می‌شود، مگر این‌که اسلاید خاصی بازنویسی خود را داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslidethememanager/) استفاده شوند:

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

از تم مستر یا سطح ارائه استفاده کنید وقتی بسیاری از لِی‌اوت‌ها و اسلایدها باید طراحی پایهٔ یکسانی را به‌اشتراک بگذارند؛ یک بازنویسی لِی‌اوت زمانی مناسب است که یک خانوادهٔ لِی‌اوت نیاز به استایل متفاوتی داشته باشد، و بازنویسی اسلاید فقط برای استثنای واقعی. بازنویسی‌های بیش از حد سطح اسلاید باعث می‌شود تغییرات تم سراسری بعدی پیش‌بینی‌پذیر نباشند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینهٔ بیشتری در UI خود نشان دهد نسبت به تعداد تعاریف پرکننده‌ای که فیزیکی در این مجموعه ذخیره شده‌اند، زیرا UI می‌تواند پرکننده‌های تم را با رنگ‌های تم و ارجاعات سبک دیگر ترکیب کند.

![گالری سبک پس‌زمینه پاورپوینت برای یک تم ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعهٔ ذخیره‌شده و مقدار فعلی [Background.getStyleIndex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) را بازبینی کنید. مقدار ایندکس سبک `0` به معنای عدم وجود پرکنندهٔ تمی است؛ مقادیر مثبت ارجاع به سبک پس‌زمینهٔ تم هستند. این متفاوت از ایندکس‌گذاری مستقیم مجموعهٔ PHP است، جایی که `get_Item(0)` اولین مورد ذخیره‌شده را نشان می‌دهد. فرض نکنید هر ارائه همان تعداد سبک پرکنندهٔ پس‌زمینه را دارد.

مثال زیر تعداد پرکنندهٔ پس‌زمینهٔ موجود را گزارش می‌دهد، یک ارجاع پس‌زمینهٔ تمی به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجهٔ قابل مشاهده به ورودی تمی که توسط مستر ارجاع داده شده و هر بازنویسی پس‌زمینه‌ای در سطح لِی‌اوت یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینهٔ خاص خود را داشته باشد، تغییر فقط پس‌زمینهٔ مستر ممکن است آن اسلاید را تغییر ندهد. هنگامی که نیاز به دانستن پس‌زمینهٔ نهایی پس از اعمال ارث‌بری دارید، از [Background.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
مقدار ایندکس سبک را به‌عنوان ایندکس صفر‑مبنا برای مجموعه در نظر نگیرید. همچنین از سخت‌کد کردن یک شمارهٔ سبک از یک فایل و فرض اینکه در فایل دیگر همان ظاهر را دارد خودداری کنید؛ تعاریف سبک تم مخصوص به هر ارائه هستند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و ارث‌بری پس‌زمینه، به [Presentation Background](/slides/fa/php-java/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح قالب تم شامل مجموعه‌های جداگانهٔ سبک پرکننده، خط و افکت است که از طریق [FormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/) و [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/) در دسترس هستند. تم‌های معمولی Office اغلب شامل سه ورودی سبک اصلی هستند که به‌صورت بصری متناظر با قالب‌بندی‌های ملایم، متوسط و پرشتاب هستند، اما کد باید هر مجموعه را بازبینی کند به‌جای این‌که فرض تعداد ثابت داشته باشد.

![افکت‌های تم ملایم، متوسط و پرشتاب بر روی یک شکل اعمال شده](presentation-design_10.png)

هنگامی که این مجموعه‌ها را در PHP دسترسی می‌کنید، ایندکس مجموعه صفر‑مبنا است: `get_Item(0)` اولین سبک ذخیره‌شده و `get_Item(2)` سومین است. ایندکس‌های ارجاع به سبک یک شکل مفهوم جداگانه‌ای هستند که از طریق [ShapeStyle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapestyle/) در دسترس است. تغییر یک سبک تم بر شکل‌هایی که به آن سبک ارجاع می‌دهند تأثیر می‌گذارد؛ شکل‌هایی که قالب‌بندی مستقیم دارند ممکن است بدون تغییر بمانند.

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

این مثال بررسی می‌کند که ورودی‌های سبک مورد نیاز وجود دارند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ خارجی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند.

برای شکل‌هایی که به این اسلات‌ها ارجاع می‌دهند، اولین سبک خط تم به قرمز، سومین سبک پرکننده تم به سبز جنگلی صلب و سومین سبک افکت یک سایهٔ خارجی با فاصلهٔ ۱۰ پوینت می‌گیرد. نتیجهٔ بصری دقیق همچنان به این‌که هر شکل به کدام اسلات‌ها ارجاع می‌دهد و آیا قالب‌بندی مستقیم بر تم ارجاع دارد یا نه، وابسته است.

![سبک‌های افکت تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

اشیای خام تم به شما می‌گویند چه چیزی در یک سطح خاص تعریف شده است. مقادیر مؤثر نشان می‌دهند یک اسلاید یا شکل پس از حل ارث‌بری و بازنویسی‌های محلی در واقع چه چیزی را استفاده می‌کند. برای یک اسلاید، فراخوانی کنید [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseoverridethememanager/). برای پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) استفاده کنید و برای پرکننده، از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکنندهٔ شکل را از یک اسلاید می‌خواند:

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را بازبینی کنید، ممکن است یک بازنویسی مستر، لِی‌اوت، اسلاید یا شکل که ظاهر نهایی را تغییر می‌دهد، از دست برود.

## **سوالات متداول**

**آیا می‌توانم تم را به یک اسلاید منفرد اعمال کنم بدون اینکه مستر را تغییر دهم؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidethememanager/) اسلاید استفاده کنید و تم بازنویسی آن را مقداردهی اولیه کنید. تغییر فقط برای آن اسلاید محلی می‌ماند؛ اسلایدهای دیگر به تم‌های موجود خود ارث می‌برند.

**ایمن‌ترین روش برای انتقال تم از یک ارائه به ارائهٔ دیگر چیست؟**

هنگام انتقال یک اسلاید و حفظ ظاهر منبع، مستر منبع را به مقصد کلون کنید و اسلاید را با همان مستر با استفاده از [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) و [SlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) کلون کنید. این کار مستر، لِی‌اوت‌ها و تم را همراه هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از ارث‌بری و بازنویسی‌ها مشاهده کنم؟**

از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseoverridethememanager/) برای یک تم اسلاید یا لِی‌اوت و متدهای دادهٔ مؤثر مربوطه برای اشیای قالب مانند [Background.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) استفاده کنید. این API‌ها مقادیر حل‌شده پس از اعمال ارث‌بری و بازنویسی‌ها را برمی‌گردانند.