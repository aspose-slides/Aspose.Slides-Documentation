---
title: مدیریت مسترهای اسلاید ارائه در PHP
linktitle: مستر اسلاید
type: docs
weight: 70
url: /fa/php-java/slide-master/
keywords:
- اسلاید مستر
- مستر اسلاید
- مستر اسلاید PPT
- مستر اسلایدهای چندگانه
- مقایسه مستر اسلایدها
- پس‌زمینه
- مکان‌گیر
- کلون مستر اسلاید
- کپی مستر اسلاید
- تکثیر مستر اسلاید
- مستر اسلاید استفاده نشده
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت مسترهای اسلاید در Aspose.Slides برای PHP از طریق Java: دسترسی، ویرایش، کلون، مقایسه و حذف مستر اسلایدها در ارائه‌های PowerPoint و OpenDocument."
---
## **نمای کلی**

یک **slide master** تنظیمات طراحی مشترک برای گروهی از اسلایدها را تعریف می‌کند. می‌تواند اشکال عمومی، لوگوها، پس‌زمینه‌ها، سبک‌های متنی، تنظیمات تم و تنظیمات پاورقی را شامل شود. در PowerPoint، ویرایش slide master معمول‌ترین روش برای حفظ سازگاری ارائه بدون تکرار همان قالب‌بندی در هر اسلاید است.

Aspose.Slides for PHP via Java از همان مدل پشتیبانی می‌کند. یک ارائه می‌تواند یک یا چند master slide داشته باشد و هر master slide می‌تواند چندین layout slide را شامل شود. اسلایدهای معمولاً به طور مستقیم به master slide ارجاع نمی‌دهند. در عوض، یک اسلاید معمولی از یک layout slide استفاده می‌کند و آن layout slide متعلق به یک master slide است.

سلسله‌مراتب به شرح زیر است:

1. **Slide master** - تنظیمات طراحی و تم مشترک را تعریف می‌کند.  
1. **Layout slide** - ترتیب خاصی از placeholderها و قالب‌بندی سطح layout را تعریف می‌کند.  
1. **Normal slide** - محتوای واقعی ارائه را در خود دارد و از یک layout slide استفاده می‌کند.

![سلسله‌مراتب master slideها، layout slideها و اسلایدهای معمولی](slide-master_2.jpg)

در Aspose.Slides، یک slide master توسط کلاس [MasterSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) نمایان می‌شود. تمام master slideهای موجود در یک ارائه از طریق روش [Presentation.getMasters](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getMasters) در دسترس هستند که یک شیء [MasterSlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) را برمی‌گرداند.

{{% alert color="info" title="وراثت" %}}
هنگامی که یک ویژگی در بیش از یک سطح تعریف شده باشد، سطح خاص‌تر برتری دارد. به عنوان مثال، اگر یک master slide و یک layout slide هر دو پس‌زمینه‌ای را تعریف کنند، اسلایدهای مبتنی بر آن layout از پس‌زمینه layout استفاده می‌کنند. برای اطلاعات بیشتر درباره layout slideها، به [Apply or Change Slide Layouts](/slides/fa/php-java/slide-layout/) مراجعه کنید.
{{% /alert %}}

## **دسترسی به Slide Masters**

در PowerPoint، می‌توانید نمای Slide Master را از **View** > **Slide Master** باز کنید.

![دستور Slide Master در برگه View برنامه PowerPoint](slide-master_3.jpg)

در Aspose.Slides، از متد `getMasters` برای دسترسی به master slideها استفاده کنید:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

همچنین می‌توانید master slide مورد استفاده توسط یک اسلاید معمولی را از طریق layout آن دریافت کنید:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **محتویات یک Slide Master**

یک master slide یک شیء شبیه اسلاید است. این شیء از [BaseSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/) ارث می‌گیرد، بنابراین بسیاری از همان ویژگی‌های اسلاید که توسط اسلایدهای معمولی و layout استفاده می‌شود، در دسترس است. اعضای مخصوص master در صفحه API [MasterSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) فهرست شده‌اند.

اعضای پرکاربرد master slide عبارتند از:

| Member | Purpose |
| --- | --- |
| `getBackground` | تنظیم پس‌زمینه سطح master. |
| `getShapes` | اشکالی که بر روی master قرار گرفته‌اند، مانند لوگوها، فریم‌های تصویر و متن مشترک را ذخیره می‌کند. |
| `getLayoutSlides` | layout slideهایی که به master تعلق دارند را ذخیره می‌کند. |
| `getThemeManager` | دسترسی به APIهای تم master را فراهم می‌کند. |
| `getHeaderFooterManager` | هدرها، فوترها، تاریخ‌ها و شماره اسلایدها را برای master و layoutهای فرزندش کنترل می‌کند. |
| `getDependingSlides` | اسلایدهای معمولی که از طریق layoutهای خود به master وابسته‌اند را برمی‌گرداند. |

## **اضافه‌کردن تصویر به Slide Master**

وقتی تصویری را به یک master slide اضافه می‌کنید، در اسلایدهایی که از layoutهای آن master استفاده می‌کنند نمایش داده می‌شود. این ویژگی برای لوگوها، واترمارک‌ها، نوارهای تزئینی و سایر عناصر بصری مکرر مفید است.

مثال زیر یک لوگو را به اولین master slide اضافه می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای اطلاعات بیشتر درباره فریم‌های تصویر، به [Picture Frame](/slides/fa/php-java/picture-frame/) مراجعه کنید.

## **کنترل نمایش گرافیک‌های Master**

از [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/#setShowMasterShapes) برای پنهان کردن گرافیک‌های ارث‌گیرفته از master (مانند لوگوها یا اشکال تزئینی) بدون حذف آن‌ها از master استفاده کنید. مقدار `false` را به [Slide::setShowMasterShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#setShowMasterShapes) در اسلایدی که می‌خواهید این گرافیک‌ها حذف شوند، پاس بدهید و در اسلایدهایی که می‌خواهید نمایش داده شوند مقدار `true` بگذارید.

مثال خودمحافظ زیر یک نوار تزئینی آبی را بر روی یک master و دو اسلاید که از همان layout خالی استفاده می‌کنند، ایجاد می‌کند. نوار در اولین اسلاید قابل مشاهده است و در دوم پنهان می‌شود. نیازی به ارائه ورودی یا تصویر نیست.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

این مثال از layout **Blank** که با یک ارائه جدید عرضه می‌شود استفاده می‌کند و placeholderهای اولیه اسلاید را حذف می‌کند.

### **انتخاب دامنه تنظیم**

یک اسلاید معمولی از master خود از طریق [Slide::getLayoutSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/#getLayoutSlide) و [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/#getMasterSlide) استفاده می‌کند. تنظیم ویژگی بر روی یک اسلاید تک‌تک تنها آن اسلاید را تحت تأثیر قرار می‌دهد. پاس دادن `false` به [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/layoutslide/#setShowMasterShapes) گرافیک‌های master را برای تمام اسلایدهایی که از همان layout مشترک استفاده می‌کنند، پنهان می‌کند، حتی اگر تنظیم خود اسلاید `true` باشد. برای پنهان کردن گرافیک فقط در یک اسلاید، ویژگی اسلاید را تغییر دهید و layout مشترک را دست‌نخورده بگذارید.

این تنظیم به عنوان کنترل نمایش بر روی خود master slide پشتیبانی نمی‌شود. در یک master، [getShowMasterShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/#getShowMasterShapes) همیشه `false` برمی‌گرداند و پاس دادن `true` به [setShowMasterShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/#setShowMasterShapes) موجب استثنا می‌شود. این متد را بر روی اسلاید معمولی یا layout اعمال کنید.

### **تمایز گرافیک‌ها از پس‌زمینه**

| Operation | Effect |
| --- | --- |
| Hide master graphics | نمایش گرافیک‌های ارث‌گیرفته از master را بدون حذف یا تغییر اشکال خود اسلاید کنترل می‌کند. |
| Change the slide background fill | رنگ، گرادیان یا تصویر پس‌زمینه را تغییر می‌دهد. گرافیک‌های master اشکال جداگانه‌ای هستند و می‌توانند بر روی آن پس‌زمینه باقی بمانند. برای جزئیات بیشتر به [Presentation Background](/slides/fa/php-java/presentation-background/) نگاه کنید. |
| Delete a shape from the master | شکل منبع مشترک را حذف می‌کند، به طوری که دیگر برای هیچ اسلایدی که از آن master استفاده می‌کند، در دسترس نیست. |

## **کار با Placeholderها**

Placeholderها معمولاً در layout slideها تعریف می‌شوند. master slide سبک و تم مشترکی را که آن layoutها ارث می‌برند، فراهم می‌کند؛ در حالی که هر layout تصمیم می‌گیرد چه placeholderهایی در دسترس هستند و کجا قرار گیرند.

در PowerPoint، دستورات placeholder در نمای Slide Master موجود است.

![دستورات Insert Placeholder در نمای Slide Master برنامه PowerPoint](slide-master_5.png)

برای اضافه کردن placeholderهای جدید با Aspose.Slides، با layout slideی که به master تعلق دارد کار کنید:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

همچنین می‌توانید اشکال placeholderهایی که از پیش در یک master slide وجود دارند را قالب‌بندی کنید. مثال زیر placeholder عنوان را پیدا کرده و یک پرکنش خطی گرادیان اعمال می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Placeholder عنوان قالب‌بندی شده که توسط اسلایدهای معمولی ارث‌برداری می‌شود](slide-master_8.png)

برای گزینه‌های بیشتر قالب‌بندی placeholder و متن، به [Set Prompt Text in Placeholder](/slides/fa/php-java/manage-placeholder/) و [Text Formatting](/slides/fa/php-java/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینه Slide Master**

پس‌زمینه master توسط layoutها و اسلایدهایی که آن را بازنویسی نمی‌کنند، به ارث می‌رسد. مثال زیر یک رنگ پس‌زمینه ثابت را برای اولین master slide تعیین می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای موضوعات مرتبط، به [Presentation Background](/slides/fa/php-java/presentation-background/) و [Presentation Theme](/slides/fa/php-java/presentation-theme/) نگاه کنید.

## **کلون کردن Slide Master به ارائه دیگری**

از `addClone` موجود در [MasterSlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) برای کپی کردن یک master slide به ارائه دیگری استفاده کنید. master کپی‌شده سپس می‌تواند توسط layoutها و اسلایدهای موجود در ارائه مقصد استفاده شود.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

اگر نیاز به کلون کردن اسلایدهای معمولی همراه با master آنها دارید، به [Clone Slides](/slides/fa/php-java/clone-slides/) مراجعه کنید.

## **اضافه‌کردن چند Slide Master**

یک ارائه می‌تواند چندین master slide داشته باشد. این ویژگی زمانی مفید است که بخش‌های مختلف نیاز به برندینگ، ساختار صفحه یا تنظیمات تم متفاوتی داشته باشند.

![دستورات PowerPoint برای درج و مدیریت master slideها](slide-master_9.jpg)

مثال زیر master پیش‌فرض را کلون می‌کند، به کلون پس‌زمینه متفاوتی می‌دهد، یک layout تحت آن master کلون شده ایجاد می‌کند و یک اسلاید جدید بر پایه آن layout اضافه می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **مقایسه Slide Masterها**

Slide masterها می‌توانند با متد `equals` که از [BaseSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/) به ارث برده شده است، مقایسه شوند. این مقایسه ساختار و محتویات ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های منحصر به فرد مثل slide IDها یا مقادیر پویا مانند تاریخ فعلی مقایسه نمی‌شوند.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

برای اطلاعات بیشتر به [Compare Presentation Slides](/slides/fa/php-java/compare-slides/) مراجعه کنید.

## **تنظیم Slide Master View به عنوان نمای پیش‌فرض**

از متد `setLastView` در [ViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/) برای کنترل نمایی که PowerPoint ابتدا باز می‌کند، استفاده کنید. مثال زیر ارائه را در نمای Slide Master باز می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای تنظیمات بیشتر نمای، به [Save Presentation](/slides/fa/php-java/save-presentation/) نگاه کنید.

## **حذف Slide Masterهای استفاده‌نشده**

گاهی ارائه‌ها شامل master slideهایی می‌شوند که دیگر توسط هیچ اسلاید معمولی استفاده نمی‌شوند. حذف masterهای استفاده‌نشده می‌تواند حجم فایل را کاهش داده و نگهداری قالب را ساده‌تر کند.

از `removeUnused` موجود در [MasterSlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) برای حذف masterهای استفاده‌نشده از مجموعه `getMasters` استفاده کنید:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

همچنین می‌توانید از متد کم‌کد `removeUnusedMasterSlides` در کلاس [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/) استفاده کنید:

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**تفاوت بین slide master و layout slide چیست؟**

یک slide master تنظیمات طراحی مشترکی مانند تم، پس‌زمینه، اشکال عمومی و سبک‌های متنی را تعریف می‌کند. یک layout slide به یک master slide تعلق دارد و ترتیب خاصی از placeholderها را تعیین می‌کند. یک اسلاید معمولی از یک layout slide استفاده می‌کند، بنابراین از هر دو layout و master ارث می‌برد.

**آیا یک ارائه می‌تواند چندین slide master داشته باشد؟**

بله. یک ارائه می‌تواند چندین slide master داشته باشد. هنگام نیاز به سیستم‌های بصری یا برندینگ متفاوت برای بخش‌های مختلف، از masterهای متعدد استفاده کنید.

**آیا باید placeholderها را به master slide اضافه کنم یا به layout slide؟**

در اکثر موارد placeholderها را به layout slideها اضافه کنید. عناصر بصری مشترک و قالب‌بندی مشترک را روی master slide بگذارید و placeholderهای محتوا را روی layoutهایی که اسلایدهای معمولی استفاده می‌کنند، قرار دهید.

**آیا می‌توانم یک master slide که هنوز استفاده می‌شود را حذف کنم؟**

نه. یک master slide که اسلایدهای وابسته دارد، نمی‌تواند به‌صورت مستقیم و ایمن حذف شود. ابتدا آن اسلایدها را به layoutهای یک master دیگر منتقل کنید یا از روش پاک‌سازی masterهای استفاده‌نشده که تنها masterهای بدون استفاده را حذف می‌کند، استفاده کنید.