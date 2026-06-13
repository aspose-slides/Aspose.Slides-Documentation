---
title: مدیریت اسلاید مسترهای ارائه در PHP
linktitle: اسلاید مستر
type: docs
weight: 70
url: /fa/php-java/slide-master/
keywords:
- اسلاید مستر
- اسلاید مستر
- اسلاید مستر PPT
- چندین اسلاید مستر
- مقایسه اسلایدهای مستر
- پس‌زمینه
- جای‌گیر
- کلون اسلاید مستر
- کپی اسلاید مستر
- تکثیر اسلاید مستر
- اسلاید مستر بلااستفاده
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "مدیریت اسلاید مسترها در Aspose.Slides برای PHP از طریق Java: دسترسی، ویرایش، کلون، مقایسه و حذف اسلایدهای مستر در ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی کلی**

یک **اسلاید مستر** تنظیمات طراحی مشترک برای یک گروه از اسلایدها را تعریف می‌کند. می‌تواند شامل شکل‌های عمومی، لوگوها، پس‌زمینه‌ها، سبک‌های متن، تنظیمات تم و تنظیمات فوتر باشد. در پاورپوینت، ویرایش اسلاید مستر روش معمول برای حفظ ثبات یک ارائه بدون تکرار همان قالب‌بندی در هر اسلاید است.

Aspose.Slides برای PHP via Java همان مدل را پشتیبانی می‌کند. یک ارائه می‌تواند یک یا چند اسلاید مستر داشته باشد و هر اسلاید مستر می‌تواند چندین اسلاید چیدمان داشته باشد. اسلایدهای معمولاً به‌طور مستقیم به اسلاید مستر ارجاع نمی‌دهند. در عوض، یک اسلاید معمولی از یک اسلاید چیدمان استفاده می‌کند و آن اسلاید چیدمان به یک اسلاید مستر تعلق دارد.

سطح‌های مختلف به ترتیب زیر هستند:

1. **اسلاید مستر** - طراحی و تم مشترک را تعریف می‌کند.  
1. **اسلاید چیدمان** - چینش خاصی از جای‌گیرها و قالب‌بندی سطح چیدمان را تعریف می‌کند.  
1. **اسلاید معمولی** - محتوای واقعی ارائه را شامل می‌شود و از یک اسلاید چیدمان استفاده می‌کند.

![ساختار سلسله‌مراتبی اسلایدهای مستر، اسلایدهای چیدمان و اسلایدهای معمولی](slide-master_2.jpg)

در Aspose.Slides، یک اسلاید مستر توسط کلاس [MasterSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) نمایش داده می‌شود. تمام اسلایدهای مستر موجود در یک ارائه از طریق متد [Presentation.getMasters](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getMasters) در دسترس هستند که یک شیء [MasterSlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) را برمی‌گرداند.

{{% alert color="info" title="Inheritance" %}}
هنگامی که یک ویژگی در بیش از یک سطح تعریف شود، سطح خاص‌تر برتری دارد. به عنوان مثال، اگر یک اسلاید مستر و یک اسلاید چیدمان هر دو پس‌زمینه‌ای تعریف کنند، اسلایدهای مبتنی بر آن چیدمان پس‌زمینه چیدمان را استفاده می‌کنند. برای اطلاعات بیشتر درباره اسلایدهای چیدمان، به مقاله [Apply or Change Slide Layouts](/slides/fa/php-java/slide-layout/) مراجعه کنید.
{{% /alert %}}

## **دسترسی به اسلایدهای مستر**

در پاورپوینت می‌توانید نمای اسلاید مستر را از **View** > **Slide Master** باز کنید.

![دستورات اسلاید مستر در برگه View پاورپوینت](slide-master_3.jpg)

در Aspose.Slides، برای دسترسی به اسلایدهای مستر از متد `getMasters` استفاده کنید:

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

همچنین می‌توانید اسلاید مستری که توسط یک اسلاید معمولی استفاده می‌شود را از طریق چیدمان آن به‌دست آورید:

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

## **محتویات یک اسلاید مستر**

یک اسلاید مستر شیئی شبیه اسلاید است. این شیء از [BaseSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/) ارث می‌برد، بنابراین بسیاری از همان خصوصیات اسلاید که در اسلایدهای معمولی و چیدمان استفاده می‌شود را در دسترس دارد. اعضای مخصوص مستر در صفحه API [MasterSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslide/) فهرست شده‌اند.

اعضای معمولاً استفاده‌شدهٔ اسلاید مستر عبارتند از:

| Member | Purpose |
| --- | --- |
| `getBackground` | تنظیم پس‌زمینهٔ سطح مستر اسلاید. |
| `getShapes` | اشکالی که بر روی مستر قرار می‌گیرند، مانند لوگوها، قاب‌های تصویر و متن‌های مشترک را ذخیره می‌کند. |
| `getLayoutSlides` | اسلایدهای چیدمان مربوط به مستر را ذخیره می‌کند. |
| `getThemeManager` | دسترسی به APIهای تم مستر را فراهم می‌کند. |
| `getHeaderFooterManager` | سرصفحه‌ها، پاورقی‌ها، تاریخ‌ها و شمارهٔ اسلایدها را برای مستر و چیدمان‌های فرعی کنترل می‌کند. |
| `getDependingSlides` | اسلایدهای معمولی که از طریق چیدمان‌های خود به مستر وابسته‌اند را برمی‌گرداند. |

## **افزودن تصویر به اسلاید مستر**

زمانی که تصویری را به اسلاید مستر اضافه می‌کنید، در اسلایدهای استفاده‌کننده از چیدمان‌های آن مستر ظاهر می‌شود. این برای لوگوها، واترمارک‌ها، نوارهای تزئینی و سایر عناصر بصری تکرارشونده مفید است.

مثال زیر یک لوگو را به اولین اسلاید مستر اضافه می‌کند:

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

برای اطلاعات بیشتر دربارهٔ قاب‌های تصویر، به مقاله [Picture Frame](/slides/fa/php-java/picture-frame/) مراجعه کنید.

## **کار با جای‌گیرها**

جای‌گیرها معمولاً در اسلایدهای چیدمان تعریف می‌شوند. اسلاید مستر سبک و تم مشترکی را که آن چیدمان‌ها به ارث می‌برند، فراهم می‌کند؛ در حالی که هر چیدمان تصمیم می‌گیرد کدام جای‌گیرها در دسترس هستند و در کجا قرار گیرند.

در پاورپوینت، دستورات جای‌گیر در نمای اسلاید مستر موجود است.

![دستورات Insert Placeholder در نمای اسلاید مستر پاورپوینت](slide-master_5.png)

برای افزودن جای‌گیرهای جدید با Aspose.Slides، با اسلاید چیدمانی که به مستر تعلق دارد کار کنید:

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

همچنین می‌توانید اشکال جای‌گیر موجود در یک اسلاید مستر را قالب‌بندی کنید. مثال زیر جای‌گیر عنوان را پیدا کرده و یک پرکن خطی گرادیان اعمال می‌کند:

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

![جای‌گیر عنوان قالب‌بندی‌شده که توسط اسلایدهای معمولی به ارث برده می‌شود](slide-master_8.png)

برای گزینه‌های بیشتر قالب‌بندی جای‌گیر و متن، به مقالات [Set Prompt Text in Placeholder](/slides/fa/php-java/manage-placeholder/) و [Text Formatting](/slides/fa/php-java/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینهٔ اسلاید مستر**

پس‌زمینهٔ مستر توسط چیدمان‌ها و اسلایدهایی که آن را بازنویسی نمی‌کنند به ارث می‌رسد. مثال زیر یک رنگ پس‌زمینهٔ ثابت برای اولین اسلاید مستر تنظیم می‌کند:

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

برای موضوعات مرتبط، به مقالات [Presentation Background](/slides/fa/php-java/presentation-background/) و [Presentation Theme](/slides/fa/php-java/presentation-theme/) نگاه کنید.

## **کلون کردن اسلاید مستر به ارائهٔ دیگر**

از متد `addClone` موجود در [MasterSlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) برای کپی کردن یک اسلاید مستر به ارائه‌ای دیگر استفاده کنید. مستر کپی‌شده سپس می‌تواند توسط چیدمان‌ها و اسلایدهای مقصد استفاده شود.

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

اگر نیاز دارید اسلایدهای معمولی را همراه با مسترشان کلون کنید، به مقاله [Clone Slides](/slides/fa/php-java/clone-slides/) مراجعه کنید.

## **افزودن چندین اسلاید مستر**

یک ارائه می‌تواند چندین اسلاید مستر داشته باشد. این موضوع برای بخش‌های مختلفی که نیاز به برندینگ، ساختار صفحه یا تنظیمات تم متفاوت دارند، مفید است.

![دستورات پاورپوینت برای درج و مدیریت اسلایدهای مستر](slide-master_9.jpg)

مثال زیر مستر پیش‌فرض را کلون می‌کند، به کلون پس‌زمینه‌ای متفاوت می‌دهد، یک چیدمان تحت آن مستر کلون‌شده ایجاد می‌کند و اسلاید جدیدی بر پایهٔ آن چیدمان اضافه می‌کند:

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

## **مقایسهٔ اسلایدهای مستر**

اسلایدهای مستر می‌توانند با متد `equals` که از [BaseSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/) ارث می‌برند، مقایسه شوند. این مقایسه ساختار و محتوای ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های یکتا مانند شناسهٔ اسلاید یا مقادیر دینامیک جای‌گیر (مانند تاریخ جاری) مورد مقایسه قرار نمی‌گیرند.

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

برای اطلاعات بیشتر، به مقاله [Compare Presentation Slides](/slides/fa/php-java/compare-slides/) مراجعه کنید.

## **تنظیم نمای اسلاید مستر به‌عنوان نمای پیش‌فرض**

از متد `setLastView` موجود در [ViewProperties](https://reference.aspose.com/slides/fa/php-java/aspose.slides/viewproperties/) برای کنترل نمایی که پاورپوینت ابتدا باز می‌کند استفاده کنید. مثال زیر ارائه را در نمای اسلاید مستر باز می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای تنظیمات نمای بیشتر، به مقاله [Save Presentation](/slides/fa/php-java/save-presentation/) نگاه کنید.

## **حذف اسلایدهای مستر بلااستفاده**

گاهی ارائه‌ها شامل اسلایدهای مستری می‌شوند که دیگر توسط هیچ اسلاید معمولی استفاده نمی‌شوند. حذف مسترهای بلااستفاده می‌تواند حجم فایل را کاهش داده و نگهداری الگوها را ساده‌تر کند.

از متد `removeUnused` موجود در [MasterSlideCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/masterslidecollection/) برای حذف مسترهای بلااستفاده از مجموعهٔ `getMasters` استفاده کنید:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

همچنین می‌توانید از متد کم‌کد `removeUnusedMasterSlides` موجود در کلاس [Compress](https://reference.aspose.com/slides/fa/php-java/aspose.slides/compress/) استفاده کنید:

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **سئوالات متداول**

**تفاوت اسلاید مستر و اسلاید چیدمان چیست؟**

اسلاید مستر تنظیمات طراحی مشترک مانند تم، پس‌زمینه، شکل‌های عمومی و سبک‌های متن را تعریف می‌کند. اسلاید چیدمان به یک اسلاید مستر تعلق دارد و چینش خاصی از جای‌گیرها را تعیین می‌کند. یک اسلاید معمولی از یک اسلاید چیدمان استفاده می‌کند، به این ترتیب از هر دو چیدمان و مستر ارث می‌برد.

**آیا یک ارائه می‌تواند چندین اسلاید مستر داشته باشد؟**

بله. یک ارائه می‌تواند چندین اسلاید مستر داشته باشد. زمانی که بخش‌های مختلف نیاز به سیستم‌های بصری یا برندینگ متفاوتی دارند، از چندین مستر استفاده کنید.

**آیا باید جای‌گیرها را به اسلاید مستر اضافه کنم یا به اسلاید چیدمان؟**

در اکثر موارد، جای‌گیرها را به اسلایدهای چیدمان اضافه کنید. عناصر بصری مشترک و قالب‌بندی‌های مشترک را روی اسلاید مستر بگذارید و سپس جای‌گیرهای محتوا را روی چیدمان‌ها که اسلایدهای معمولی از آن استفاده می‌کنند، قرار دهید.

**آیا می‌توانم اسلاید مستری را که هنوز استفاده می‌شود حذف کنم؟**

خیر. اسلاید مستری که اسلایدهای وابسته دارد را نمی‌توان به‌صورت مستقیم حذف کرد. ابتدا آن اسلایدها را به چیدمان‌های تحت مستر دیگری منتقل کنید یا از روش پاک‌سازی مسترهای بلااستفاده استفاده کنید که فقط مسترهای غیرقابل استفاده را حذف می‌کند.