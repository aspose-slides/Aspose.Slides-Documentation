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
- تم خارجی
- THMX
- رنگ تم
- پالت اضافه
- قلم تم
- سبک تم
- افکت تم
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت تم‌های ارائه اصلی در Aspose.Slides برای PHP از طریق Java برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکسان."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای آگاه از تم به جای ذخیره‌سازی هر ویژگی بصری به عنوان مقدار ثابت، به این تعاریف مشترک ارجاع می‌دهند، بنابراین تغییر تم می‌تواند بسیاری از اشیا را به‌صورت همزمان به‌روز کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) در دسترس است. یک ارائه می‌تواند همچنین بازنویسی‌های تم در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterthememanager/) بازنویسی کند، در حالی که یک لایه یا اسلاید منفرد می‌تواند تم ارث‌بری شده خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseoverridethememanager/) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره ارث‌بری حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لایه و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل ارث‌بری و بازنویسی‌ها.

## **بررسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/) طرح رنگ، طرح قلم و طرح قالب تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/) و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/) در دسترس می‌گذارد. بررسی این مجموعه‌ها قبل از تغییر آن‌ها به‌ویژه وقتی که ارائه‌ای از منبع خارجی می‌آید مفید است، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و تعداد سبک‌های پس‌زمینه، پرکننده، خط و افکت ذخیره‌شده در تم را گزارش می‌دهد:

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بررسی کنید و از جریان کاری تم مؤثر که در ادامه مقاله نشان داده شده است استفاده کنید وقتی که ممکن است بازنویسی‌های لایه یا اسلاید وجود داشته باشد.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از شمارش [SchemeColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی متناظر در [ColorScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colorscheme/) را تغییر می‌دهید، تمام اشیایی که هنوز به آن رنگ تم ارجاع می‌دهند بر اساس مقدار جدید حل می‌شوند. اشیائی که از یک رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال انتها‑به‑انتهای زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

چون مستطیل همچنان به `Accent4` مرتبط است، رنگ قابل رؤیت آن پس از تغییر تم به قرمز می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکننده تأثیر نخواهد گذاشت.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیل‌های رنگی، گونه‌های روشن‌تر و تیره‌تر را از یک رنگ تم تولید می‌کند. Aspose.Slides این تبدیل‌ها را از طریق شمارش [ColorTransformOperation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تر تولید شده از پالت اضافی](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.

**2** - گونه‌های روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، به پنج‌تای آن‌ها تبدیل‌های روشنایی اعمال می‌کند و نتیجه را ذخیره می‌نماید:

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

این گونه‌ها همچنان بر پایه رنگ تم هستند. اگر `Accent4` بعداً تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` بازمحاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به فضای `ColorScheme`**

شمارش [SchemeColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [ColorScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colorscheme/) همان فضاهای تم را به‌صورت `Dark1`، `Light1`، `Dark2` و `Light2` نشان می‌دهد. نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان فضاهای تم هستند؛ آن‌ها مقادیر دینامیکی نیستند که از یک فرم به فرم دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل مجموعه اصلی قلم برای عناوین و مجموعه فرعی قلم برای متن بدنه است. توابع [FontScheme.getMajor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontscheme/) و [FontScheme.getMinor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontscheme/) این مجموعه‌ها را در دسترس می‌گذارند.

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

عنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که نام قلم صریحی به جای شناسه تم داشته باشد، هنگام تغییر طرح قلم تم به‌صورت خودکار سوئیچ نمی‌شود.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری مختلف مانند سیریلیک، عربی، ژاپنی، گرجی و ثان هم باشند. برای بررسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به [Script‑Specific Theme Fonts](/slides/fa/php-java/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/php-java/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال یک تم**

جریان‌های کاری زیر مسائل مختلف مرتبط با تم را حل می‌کنند.

### **اعمال تم خارجی به اسلایدهای وابسته به یک مستر**

از [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) زمانی که فایل تم PowerPoint (`.thmx`) دارید و می‌خواهید استایل تمام اسلایدهایی را که به یک مستر خاص وابسته‌اند، تغییر دهید، استفاده کنید. مستر موردنظر را از مجموعه [Presentation::getMasters](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) که توسط [MasterSlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) نمایش داده می‌شود، انتخاب کنید و مسیر فایل تم را به متد پاس دهید.

این متد عملیات زیر را انجام می‌دهد:

1. یک اسلاید مستر جدید بر پایه مستر انتخاب‌شده می‌سازد.
1. تم خارجی را بر روی مستر جدید اعمال می‌کند.
1. مستر جدید را به تمام اسلایدهایی که قبلاً به مستر انتخاب‌شده وابسته بودند، اختصاص می‌دهد.
1. [MasterSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) جدید ساخته‌شده را برمی‌گرداند.

مثال زیر تم خارجی را بر اسلایدهایی که به اولین مستر وابسته‌اند اعمال می‌کند و ارائه را ذخیره می‌نماید:

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

تم نامعتبر، خراب یا غیرقابل پشتیبانی می‌تواند باعث [PptxReadException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxreadexception/) شود. مسیرهای ارائه‌شده توسط کاربران را اعتبارسنجی کنید، خطاهای دسترسی به سیستم فایل را مدیریت کنید و تنها پس از اعمال موفقیت‌آمیز تم، ارائه را ذخیره کنید.

فقط اسلایدهایی که به مستر انتخاب‌شده وابسته بودند مجدداً اختصاص می‌یابند. اسلایدهای مرتبط با مسترهای دیگر مسترها و تم‌های موجود خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط، پس‌زمینه‌ها و افکت‌های آگاه از تم بر اساس تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکننده‌ها و قالب‌بندی‌های صریحی که به‌صورت مستقیم اختصاص داده شده‌اند ممکن است بدون تغییر بمانند. بازنویسی‌های سطح لایه و اسلاید نیز می‌توانند بر مقادیر ارث‌بری شده از مستر جدید اولویت داشته باشند.

تم می‌تواند به قلم‌هایی ارجاع دهد که در محیط اجرایی موجود نیستند. برای رندر و خروجی ثابت، قلم‌های موردنیاز را نصب کنید، از [منابع قلم سفارشی](/slides/fa/php-java/custom-font/) فراهم کنید یا [جایگزینی قلم](/slides/fa/php-java/font-substitution/) را تنظیم کنید.

این یک جریان کاری مستقیم در سطح مستر است: متد مسیر فایل `.thmx` را می‌پذیرد و نیازی به ایجاد دستی بازنویسی‌های تم در سطح اسلاید یا لایه ندارد.

### **اعمال تم‌های خارجی متفاوت در یک ارائه چندمستر**

وقتی مستر مرتبط از پیش شناخته‌شده نیست، آن را از یک اسلاید نماینده از طریق [Slide::getLayoutSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/) و [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/) به‌دست آورید. قبل از اعمال هر تمی، مراجع مستر اصلی را ذخیره کنید زیرا هر فراخوانی یک مستر دیگر در ارائه ایجاد می‌کند.

مثال زیر از اسلایدهای دو بخش برای پیدا کردن مسترهایشان استفاده می‌کند و تم خارجی متفاوتی را برای هر گروه اعمال می‌کند:

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

فراخوانی اول فقط بر اسلایدهایی که به `$firstGroupMaster` وابسته بودند تأثیر می‌گذارد و فراخوانی دوم فقط بر اسلایدهایی که به `$secondGroupMaster` وابسته بودند. اسلایدهای متعلق به هر مستر دیگر دوباره استایل نمی‌شوند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائه دیگر منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) به ارائه هدف کلون کنید، سپس اسلاید را با [SlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) و مستر کلون‌شده کلون کنید. این کار مستر، لایه‌های آن و تم مربوطه را همراه می‌برد.

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

این روش ترجیحی است وقتی که اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. به‌سادگی کلون کردن محتوا روی مستری نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و لایه فعلی خود بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. توابع [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/) و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/) سه مؤلفه اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم ارث‌بری‌شده توسط اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌بری‌شده، [OverrideTheme.clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک لایه**

یک بازنویسی سطح لایه بر اسلایدهایی که از آن لایه استفاده می‌کنند اعمال می‌شود، مگر این‌که یک اسلاید خاص بازنویسی خود را داشته باشد. همان توابع مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslidethememanager/) استفاده شوند:

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

وقتی تعداد زیادی لایه و اسلاید باید طراحی پایه یکسانی را به‌اشتراک بگذارند، از تم سطح مستر یا ارائه استفاده کنید؛ زمانی که یک خانواده لایه نیاز به استایل متفاوت دارد، از بازنویسی لایه استفاده کنید و برای استثناهای واقعی تنها از بازنویسی اسلاید استفاده کنید. بازنویسی‌های بیش از حد در سطح اسلاید، تغییرات تم سراسری بعدی را پیش‌بینی‌پذیرتر می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری در رابط کاربری خود ارائه دهد نسبت به تعداد تعریف‌های پرکننده‌ای که فیزیکی در این مجموعه ذخیره شده‌اند، زیرا UI می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر ارجاعات سبک ترکیب کند.

![گالری سبک پس‌زمینه PowerPoint برای یک تم ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و مقدار فعلی [Background.getStyleIndex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) را بررسی کنید. یک شاخص سبک `0` به معنای عدم وجود پرکننده تم است؛ مقادیر مثبت مرجع‌های سبک پس‌زمینه تم هستند. این متفاوت از ایندکس‌گذاری مستقیم مجموعه PHP است، جایی که `get_Item(0)` اولین آیتم ذخیره‌شده را برمی‌گرداند. فرض نکنید که هر ارائه تعداد برابر از سبک‌های پرکننده پس‌زمینه دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌دهد، یک مرجع پس‌زمینه تم را به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجه قابل مشاهده به ورودی تمی که توسط مستر ارجاع داده شده و به هر بازنویسی پس‌زمینه در سطح لایه یا اسلاید بستگی دارد. اگر یک اسلاید پس‌زمینه خودش را داشته باشد، تغییر فقط پس‌زمینه مستر ممکن است آن اسلاید را تغییر ندهد. هنگام نیاز به دانستن پس‌زمینه نهایی پس از اعمال ارث‌بری، از [Background.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
شاخص سبک را به‌عنوان ایندکس صفر‑پایه مجموعه در نظر نگیرید. همچنین از کدنویسی ثابت یک شماره سبک از یک فایل و فرض اینکه در فایل دیگر همان ظاهر را دارد، پرهیز کنید؛ تعاریف سبک تم مخصوص هر ارائه‌اند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و ارث‌بری پس‌زمینه، به [Presentation Background](/slides/fa/php-java/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح قالب تم شامل مجموعه‌های جداگانه پرکننده، خط و افکت است که از طریق [FormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/) و [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/) در دسترس هستند. تم‌های معمولی Office اغلب سه ورودی سبک اصلی دارند که به‌صورت بصری با قالب‌بندی‌های Subtle، Moderate و Intense مطابقت دارند، اما کد باید هر مجموعه را بررسی کند به‌جای این‌که تعداد ثابت را فرض کند.

![افکت‌های تم Subtle، Moderate و Intense که بر یک شکل اعمال شده‌اند](presentation-design_10.png)

هنگامی که این مجموعه‌ها را در PHP دسترسی می‌یابید، ایندکس مجموعه صفر‑پایه است: `get_Item(0)` اولین سبک ذخیره‌شده و `get_Item(2)` سومین. ایندکس‌های ارجاع‑سبک یک شکل مفهوم جداگانه‌ای است که از طریق [ShapeStyle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapestyle/) افشا می‌شود. تغییر یک سبک تم بر شکل‌هایی که به آن سبک ارجاع می‌دهند تأثیر می‌گذارد؛ شکل‌های دارای قالب‌بندی مستقیم ممکن است بدون تغییر بمانند.

مثال زیر وجود ورودی‌های سبک موردنیاز را بررسی می‌کند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایه خارجی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای شکل‌هایی که به این فضاها ارجاع دارند، اولین سبک خط تم به قرمز تبدیل می‌شود، سومین سبک پرکننده تم به سبز جنگلی ثابت و سومین سبک افکت یک سایه خارجی با فاصله 10 پوینت می‌گیرد. نتیجه بصری دقیق همچنان به این‌که هر شکل به کدام فضاها ارجاع می‌دهد و آیا قالب‌بندی مستقیم بر تم اولویت دارد یا نه، بستگی دارد.

![سبک‌های افکت تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر تم مؤثر**

اشیای تم خام آنچه در سطح خاصی تعریف شده را به شما می‌گویند. مقادیر مؤثر آنچه یک اسلاید یا شکل پس از حل ارث‌بری و بازنویسی‌های محلی واقعاً استفاده می‌کند، نشان می‌دهند. برای یک اسلاید، [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseoverridethememanager/) را فراخوانی کنید. برای پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) و برای پرکننده، از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) استفاده کنید.

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

از داده‌های مؤثر برای دیابگ رندر، اعتبارسنجی و مقایسه استفاده کنید. اگر فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را بررسی کنید، ممکن است بازنویسی‌های مستر، لایه، اسلاید یا شکل که ظاهر نهایی را تغییر می‌دهند، از دست بروند.

## **سؤالات متداول**

**آیا اعمال تم خارجی بر تمام اسلایدهای ارائه تأثیر می‌گذارد؟**

خیر. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) تنها اسلایدهایی را که به مستر انتخاب‌شده وابسته‌اند مجدداً اختصاص می‌دهد. اسلایدهایی که از مسترهای دیگر استفاده می‌کنند تم‌های موجود خود را حفظ می‌کنند.

**آیا می‌توانم تم را فقط بر یک اسلاید بدون تغییر مستر اعمال کنم؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidethememanager/) اسلاید استفاده کنید و تم بازنویسی آن را مقداردهی اولیه کنید. این تغییر به‌صورت محلی بر همان اسلاید باقی می‌ماند؛ اسلایدهای دیگر همچنان تم‌های موجود خود را ارث می‌بندند.

**ایمن‌ترین راه برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**

هنگام جابجایی اسلاید و حفظ ظاهر منبع، مستر منبع را به مقصد کلون کنید و سپس اسلاید را با آن مستر با استفاده از [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) و [SlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) کلون کنید. این کار مستر، لایه‌ها و تم را همراه هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از ارث‌بری و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseoverridethememanager/) برای تم اسلاید یا لایه استفاده کنید و روش‌های داده‑مؤثر مربوط به اشیای قالب مانند [Background.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) را فراخوانی کنید. این APIها مقادیر حل‌شده پس از اعمال ارث‌بری و بازنویسی‌ها را برمی‌گردانند.