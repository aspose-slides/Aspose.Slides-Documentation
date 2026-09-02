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
- پالت افزوده
- قلم تم
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

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای آگاه به تم به این تعاریف مشترک ارجاع می‌دهند به جای این‌که هر ویژگی بصری را به‌عنوان مقدار ثابت ذخیره کنند، بنابراین تغییر تم می‌تواند بسیاری از اشیا را به‌صورت هم‌زمان به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) در دسترس است. یک ارائه می‌تواند همچنین حاوی جایگزینی‌های تم در سطوح پایین‌تری باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterthememanager/) بازنویسی کند، در حالی که یک طرح‌بندی یا اسلاید منفرد می‌تواند تم ارث‌بری‌شده خود را از طریق [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseoverridethememanager/) بازنویسی کند. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره وراثت حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی طرح‌بندی و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین گردش کارهای تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل وراثت و بازنویسی‌ها.

## **بررسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/) طرح رنگ، طرح قلم و طرح فرمت تم را از طریق [MasterTheme.getColorScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/)، [MasterTheme.getFontScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/) و [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/mastertheme/) ارائه می‌دهد. بررسی این مجموعه‌ها قبل از تغییر آنها به‌ویژه زمانی مفید است که ارائه‌ای از منبع خارجی آمده باشد، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و گزارش می‌دهد که چند سبک پس‌زمینه، پرکننده، خط و افکت در تم ذخیره شده است:

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بررسی کنید و از گردش کار تم مؤثر که در ادامه مقاله نشان داده شده است استفاده کنید وقتی که بازنویسی‌های طرح‌بندی یا اسلاید ممکن است وجود داشته باشند.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه به تم می‌توانند به یک رنگ منطقی از شمارش [SchemeColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی متناظر در [ColorScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colorscheme/) را تغییر می‌دهید، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند، بر اساس مقدار جدید حل می‌شوند. اشیائی که از یک رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ تم تغییر نمی‌شوند.

مثال زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

چون مستطیل همچنان به `Accent4` لینک شده است، رنگ قابل مشاهده‌اش پس از تغییر تم به قرمز تبدیل می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر آن پرکننده را تحت تأثیر قرار نمی‌دهد.

### **استفاده از رنگ‌ها از پالت افزوده**

PowerPoint از یک رنگ تم، انواع روشن‌تر و تیره‌تر را با اعمال تبدیلات رنگی تولید می‌کند. Aspose.Slides این تبدیلات را از طریق شمارش [ColorTransformOperation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colortransformoperation/) ارائه می‌دهد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تر تولید شده از پالت افزوده](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.  
**2** - انواع روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، پنج مورد از آنها را با تبدیلات روشنایی تغییر می‌دهد و نتیجه را ذخیره می‌کند:

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

این انواع بر پایه رنگ تم باقی می‌مانند. اگر `Accent4` بعداً تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` بازمحاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `ColorScheme`**

شمارش [SchemeColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/schemecolor/) از `Text1`, `Background1`, `Text2` و `Background2` استفاده می‌کند، در حالی که [ColorScheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colorscheme/) همان اسلات‌های تم را به عنوان `Dark1`, `Light1`, `Dark2` و `Light2` ارائه می‌دهد. نقشه به‌صورت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ مقادیری که به صورت پویا از یک فرم به فرم دیگر تبدیل می‌شوند نیستند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل یک مجموعه قلم اصلی برای سرعنوان‌ها و یک مجموعه قلم فرعی برای متن بدنه است. روش‌های [FontScheme.getMajor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontscheme/) و [FontScheme.getMinor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fontscheme/) این مجموعه‌ها را باز می‌گردانند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (Minor Latin Font)
* `+mj-lt` - قلم سرعنوان لاتین (Major Latin Font)
* `+mn-ea` - قلم بدنه آسیای شرقی (Minor East Asian Font)
* `+mj-ea` - قلم سرعنوان آسیای شرقی (Major East Asian Font)

مثال زیر یک سرعنوان که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند ایجاد می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

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

سرعنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی پیروی می‌کند. متنی که به‌وضوح نام قلم دارد به‌جای شناسه تم، هنگام تغییر طرح قلم تم به‌طور خودکار تغییر نخواهد کرد.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نقشه‌برداری‌های قلم برای سیستم‌های نوشتاری فردی مانند سیریلیک، عربی، ژاپنی، گرجی و ثانا باشند. برای بررسی، افزودن، جایگزینی یا حذف این نقشه‌برداری‌ها، به [فونت‌های تم مخصوص اسکریپت](/slides/fa/php-java/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="نکته" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/php-java/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال تم**

گردش کارهای زیر مسائل مختلف مرتبط با تم را حل می‌کنند.

### **اعمال تم خارجی به اسلایدهای وابسته به یک مستر**

از [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) وقتی که یک فایل تم PowerPoint (`.thmx`) دارید و می‌خواهید تمام اسلایدهایی که به یک مستر خاص وابسته‌اند را دوباره‌طراحی کنید، استفاده کنید. مستر را از مجموعه [Presentation::getMasters](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) که توسط [MasterSlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) نشان داده می‌شود، انتخاب کنید و مسیر فایل تم را به متد بدهید.

متد عملیات زیر را انجام می‌دهد:

1. یک مستر اسلاید جدید بر پایه مستر انتخاب‌شده ایجاد می‌کند.  
1. تم خارجی را بر روی مستر جدید اعمال می‌کند.  
1. مستر جدید را به تمام اسلایدهایی که قبلاً به مستر انتخاب‌شده وابسته بودند اختصاص می‌دهد.  
1. مستر اسلاید جدید ایجاد‌شده را بر می‌گرداند.

مثال زیر تم خارجی را به اسلایدهایی که به اولین مستر وابسته هستند اعمال می‌کند و ارائه را ذخیره می‌کند:

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

یک تم نامعتبر، خراب یا پشتیبانی‌نشده می‌تواند موجب [PptxReadException](https://reference.aspose.com/slides/fa/php-java/aspose.slides/pptxreadexception/) شود. مسیرهای ارائه‌شده توسط کاربران را اعتبارسنجی کنید، خطاهای دسترسی به سیستم‌فایل را مدیریت کنید و ارائه را فقط پس از اعمال موفق تم ذخیره کنید.

فقط اسلایدهایی که به مستر انتخاب‌شده وابسته بودند مجدداً اختصاص داده می‌شوند. اسلایدهای مرتبط با سایر مسترها مستر و تم فعلی خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط، پس‌زمینه‌ها و افکت‌های آگاه به تم بر خلاف تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکننده‌ها و سایر قالب‌بندی‌های صریح که به‌صورت مستقیم اختصاص داده شده‌اند ممکن است بدون تغییر باقی بمانند. بازنویسی‌های سطح طرح‌بندی و سطح اسلاید نیز می‌توانند بر مقادیر وراثت‌شده از مستر جدید اولویت داشته باشند.

تم می‌تواند به قلم‌هایی اشاره داشته باشد که در محیط زمان اجرا موجود نیستند. برای رندر و خروجی سازگار، قلم‌های مورد نیاز را نصب کنید، از [منابع قلم سفارشی](/slides/fa/php-java/custom-font/) استفاده کنید یا [جایگزینی قلم](/slides/fa/php-java/font-substitution/) را تنظیم کنید.

این یک گردش کار مستقیم در سطح مستر است: متد مسیر فایل `.thmx` را می‌پذیرد و نیازی به ایجاد دستی بازنویسی‌های تم در سطح اسلاید یا طرح‌بندی ندارد.

### **اعمال تم‌های خارجی متفاوت در یک ارائه چند‑مستر**

وقتی مستر مربوطه از پیش شناخته نشده باشد، آن را از یک اسلاید نماینده از طریق [Slide::getLayoutSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/) و [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/) به‌دست آورید. قبل از اعمال هر تمی، مراجع مستر اصلی را ذخیره کنید زیرا هر فراخوانی یک مستر دیگر در ارائه ایجاد می‌کند.

مثال زیر اسلایدهای دو بخش را برای یافتن مسترهایشان استفاده می‌کند و برای هر گروه تم خارجی متفاوتی اعمال می‌کند:

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

فراخوانی اول فقط بر اسلایدهایی که به `$firstGroupMaster` وابسته بودند تأثیر می‌گذارد و فراخوانی دوم فقط بر اسلایدهایی که به `$secondGroupMaster` وابسته بودند. اسلایدهای متعلق به هر مستر دیگری دوباره‌طراحی نمی‌شوند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائه دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) به ارائه مقصد اضافه کنید، سپس اسلاید را با استفاده از [SlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) و مستر کلون‌شده اضافه کنید. این کار مستر، طرح‌بندی‌های آن و تم مرتبط را به همراه خود می‌برد.

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

این گردش کار ترجیحی است وقتی که اسلاید منبع باید در مقصد همان ظاهر را داشته باشد. فقط کلون کردن محتوا روی یک مستر مقصد نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید روی مستر و طرح‌بندی فعلی خود بماند، یک بازنویسی سطح اسلاید از تم منبع را مقداردهی اولیه کنید. متدهای [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/)، [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/) و [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/) سه مؤلفه اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم ارث‌بری‌شده توسط اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌بری‌شده، متد [OverrideTheme.clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/overridetheme/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک طرح‌بندی**

یک بازنویسی سطح طرح‌بندی بر اسلایدهایی که از آن طرح‌بندی استفاده می‌کنند اعمال می‌شود، مگر این‌که اسلاید خاصی بازنویسی خود را داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslidethememanager/) استفاده شوند:

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

زمانی که بسیاری از طرح‌بندی‌ها و اسلایدها باید همان طراحی پایه را به اشتراک بگذارند، از تم سطح مستر یا ارائه استفاده کنید؛ برای یک خانواده طرح‌بندی که به سبک متفاوتی نیاز دارد از بازنویسی طرح‌بندی استفاده کنید و برای استثنای واقعی فقط از بازنویسی اسلاید استفاده کنید. بازنویسی‌های بیش از حد سطح اسلاید، اعمال تغییرات تم سراسری را در آینده دشوارتر می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری را در رابط کاربری خود ارائه دهد نسبت به تعداد تعریف‌های پرکننده‌ای که فیزیکی در این مجموعه ذخیره شده‌اند، زیرا رابط کاربری می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر مراجع سبک ترکیب کند.

![گالری سبک پس‌زمینه PowerPoint برای یک تم ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و ایندکس سبک فعلی را از طریق [Background.getStyleIndex](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) بررسی کنید. یک ایندکس سبک `0` به معنی عدم وجود پرکننده تم است؛ مقادیر مثبت ارجاع به سبک‌های پس‌زمینه تم هستند. این متفاوت از ایندکس‌گذاری مستقیم مجموعه PHP است که در آن `get_Item(0)` اولین مورد ذخیره‌شده را یعنی آیتم اول نشان می‌دهد. فرض نکنید که هر ارائه همان تعداد سبک پرکننده پس‌زمینه را دارد.

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

نتیجه قابل مشاهده به ورودی تم ارجاع‌شده توسط مستر و هر بازنویسی پس‌زمینه در سطح طرح‌بندی یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینه خاص خود را داشته باشد، فقط تغییر پس‌زمینه مستر ممکن است آن اسلاید را تغییر ندهد. برای دانستن پس‌زمینه نهایی پس از اعمال وراثت، از [Background.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) استفاده کنید.

{{% alert color="warning" title="هشدار" %}}
ایندکس سبک را به‌عنوان یک ایندکس صفر‑پایه مجموعه در نظر نگیرید. همچنین از کدنویسی سخت‌گیرانه یک شماره سبک از یک فایل و فرض یک ظاهر مشابه در فایل دیگر خودداری کنید؛ تعریف‌های سبک تم مخصوص ارائه هستند.
{{% /alert %}}

{{% alert color="info" title="نکته" %}}
برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، به [Presentation Background](/slides/fa/php-java/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح فرمت تم مجموعه‌های جداگانه پرکننده، خط و افکت را از طریق [FormatScheme.getFillStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/)، [FormatScheme.getLineStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/) و [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/fa/php-java/aspose.slides/formatscheme/) ارائه می‌دهد. تم‌های معمولی Office اغلب دارای سه ورودی سبک اصلی هستند که بصورت بصری متناظر با قالب‌بندی‌های Subtle، Moderate و Intense هستند، اما کد باید هر مجموعه را بررسی کند به‌جای این‌که تعداد ثابت را فرض کند.

![افکت‌های تم Subtle، Moderate و Intense که بر همان شکل اعمال شده‌اند](presentation-design_10.png)

هنگامی که این مجموعه‌ها را در PHP دسترسی می‌دهید، ایندکس مجموعه صفر‑پایه است: `get_Item(0)` اولین سبک ذخیره‌شده و `get_Item(2)` سومین سبک است. ایندکس‌های ارجاع سبک یک شکل یک مفهوم جداگانه است که از طریق [ShapeStyle](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapestyle/) ارائه می‌شود. تغییر یک سبک تم بر شکل‌هایی که به آن سبک ارجاع می‌دهند تأثیر می‌گذارد؛ شکل‌هایی که دارای قالب‌بندی مستقیم هستند ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های سبک مورد نیاز موجود باشند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایه خارجی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای شکل‌هایی که به این اسلات‌ها ارجاع می‌دهند، اولین سبک خط تم قرمز می‌شود، سومین سبک پرکننده تم به سبز جنگل ثابت تبدیل می‌شود و سومین سبک افکت یک سایه خارجی با فاصله 10 پوینت می‌گیرد. نتیجه بصری دقیق هنوز به این بستگی دارد که هر شکل به کدام اسلات‌ها ارجاع می‌دهد و آیا قالب‌بندی مستقیم بر تم غالب است یا خیر.

![سبک‌های افکت تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **تعیین اینکه آیا یک پرکنندهٔ جامد مؤثر از رنگ تم استفاده می‌کند**

یک پرکننده می‌تواند مستقیماً بر روی یک شیء ذخیره شود یا از یک پاراگراف، طرح‌بندی، مستر، سبک تم یا سطح قالب‌بندی دیگری ارث‌بری شود. برای حل این سلسله مراتب به دادهٔ پرکننده مؤثر غیرقابل تغییر، متد [FillFormat::getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) را فراخوانی کنید. ابتدا نتیجهٔ `getFillType` را بررسی کنید. فقط وقتی که مقدار `FillType::Solid` باشد، باید ویژگی‌های پرکنندهٔ جامد را بخوانید.

برای یک پرکنندهٔ جامد، `getSolidFillColor` مقدار نهایی RGB رندر شده پس از وراثت، جستجوی تم و اعمال تبدیلات رنگی را برمی‌گرداند. متد `getSolidFillSchemeColor` اسلات منطقی مربوط به [SchemeColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/schemecolor/) مانند `Text1` یا `Accent6` را برمی‌گرداند. مقدار `SchemeColor::NotDefined` به این معناست که پرکنندهٔ جامد مؤثر بر پایهٔ یک رنگ طرح نیست. در یک گردش کاری که در آن پرکننده‌ها یا رنگ‌های تم یا رنگ‌های RGB مستقیم هستند، این مقدار یک پرکنندهٔ RGB مستقیم را شناسایی می‌کند.

از مقدار محلی [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/fa/php-java/aspose.slides/colorformat/) به‌تنهایی برای دسته‌بندی یک پرکننده استفاده نکنید. به عنوان مثال، یک بخش متن ممکن است رنگ طرح محلی نداشته باشد، بنابراین مقدار محلی آن `NotDefined` است، در حالی که پرکنندهٔ مؤثر آن یک رنگ تم ارث‌بری می‌کند و به `Text1` یا `Accent6` حل می‌شود. برعکس، `getSolidFillSchemeColor` به شما می‌گوید کدام اسلات منطقی تم رنگ نهایی را تولید کرده است، اما نمی‌گوید آن اسلات از شیء، پاراگراف، طرح‌بندی، مستر یا سطح دیگری از سلسله مراتب قالب‌بندی آمده است.

مثال زیر یک ارائه را بارگذاری می‌کند، هر دو پرکنندهٔ شکل و پرکنندهٔ بخش متن را بررسی می‌کند، هر مقدار نهایی RGB و رنگ طرح مرتبط را چاپ می‌کند و پرکننده‌های جامدی را پرچم می‌زند که تغییر رنگ‌های تم را دنبال نخواهند کرد:

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

شاخه `NotDefined` فهرستی از پرکننده‌های جامد که به تغییرات در اسلات‌های رنگ تم پاسخ نمی‌دهند، فراهم می‌کند. هنگام نیاز به پیروی از یک پالت برند جدید، آن اشیا را مرور کنید. مقدار RGB گزارش‌شده هنوز ظاهر کنونی را نشان می‌دهد، در حالی که مقدار طرح توضیح می‌دهد که آیا آن ظاهر به تم متصل است یا خیر.

اشیای قالب مؤثر اسنپ‌شات هستند. پس از تغییر تم ارائه، بازنویسی تم یا هر قالب‌بندی ارث‌بری‌شده، دوباره `getEffective` را فراخوانی کنید و داده‌های پرکنندهٔ مؤثر جدید را پیش از مقایسه یا گزارش رنگ‌ها بخوانید.

## **خواندن مقادیر مؤثر تم**

اشیای تم خام آنچه در یک سطح خاص تعریف شده است را می‌گویند. مقادیر مؤثر آنچه یک اسلاید یا شکل پس از حل وراثت و بازنویسی‌های محلی استفاده می‌کند را نشان می‌دهد. برای یک اسلاید، متد [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseoverridethememanager/) را فراخوانی کنید. برای یک پس‌زمینه، از [Background.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) استفاده کنید و برای یک پرکننده، از [FillFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) استفاده کنید.

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.getMasterTheme](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را بررسی کنید، ممکن است یک بازنویسی مستر، طرح‌بندی، اسلاید یا شکل که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **سوالات متداول**

**آیا اعمال تم خارجی بر همه اسلایدهای ارائه تأثیر می‌گذارد؟**

خیر. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) فقط اسلایدهایی را که به مستر انتخاب‌شده وابسته‌اند، مجدداً اختصاص می‌دهد. اسلایدهایی که از مسترهای دیگر استفاده می‌کنند تم موجود خود را حفظ می‌کنند.

**آیا می‌توانم تم را به یک اسلاید منفرد اعمال کنم بدون اینکه مستر تغییر یابد؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidethememanager/) اسلاید استفاده کنید و تم بازنویسی‌شدهٔ آن را مقداردهی اولیه کنید. تغییر تنها به همان اسلاید محلی می‌ماند؛ سایر اسلایدها تم‌های موجود خود را ارث‌بری می‌کنند.

**ایمنی‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**

هنگامی که اسلایدی را جابجا می‌کنید و ظاهر منبع آن را حفظ می‌کنید، مستر منبع را در مقصد کلون کنید و سپس اسلاید را با آن مستر با استفاده از [MasterSlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) و [SlideCollection.addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slidecollection/) کلون کنید. این کار مستر، طرح‌بندی‌ها و تم را با هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از وراثت و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseoverridethememanager/) برای یک اسلاید یا تم طرح‌بندی و از متدهای دادهٔ مؤثر مربوطه برای اشیای قالب مانند [Background.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/background/) و [FillFormat.getEffective](https://reference.aspose.com/slides/fa/php-java/aspose.slides/fillformat/) استفاده کنید. این APIها مقادیر حل‌شده پس از اعمال وراثت و بازنویسی‌ها را برمی‌گردانند.