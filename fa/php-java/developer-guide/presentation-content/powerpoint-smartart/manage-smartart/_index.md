---
title: مدیریت SmartArt در ارائه‌های PowerPoint با PHP
linktitle: مدیریت SmartArt
type: docs
weight: 10
url: /fa/php-java/manage-smartart/
keywords:
- SmartArt
- متن SmartArt
- نوع طرح‌بندی
- ویژگی مخفی
- نمودار سازمانی
- نمودار سازمانی تصویری
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "با Aspose.Slides برای PHP از طریق Java، نحوه ساخت و ویرایش SmartArt در PowerPoint را با نمونه کدهای واضحی که طراحی اسلاید و خودکارسازی را سرعت می‌بخشند، بیاموزید."
---
## **نمای کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، شکل‌های گره و یک طرح‌بندی ساخته شده است. با Aspose.Slides برای PHP از طریق Java می‌توانید SmartArt ایجاد کنید، متن را از گره‌های آن بخوانید، طرح‌بندی آن را تغییر دهید، گره‌های مخفی را بررسی کنید، طرح‌بندی‌های نمودار سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری ایجاد کنید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند یک یا چند شکل را شامل شود. برای خواندن متن قابل مشاهده، به‌صورت تکراری از [SmartArt::getAllNodes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/#getAllNodes) عبور کنید، سپس [TextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/) بازگردانده‌شده توسط [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartshape/#getTextFrame) را بخوانید.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **تغییر نوع طرح‌بندی یک شیء SmartArt**

طرح‌بندی SmartArt تعیین می‌کند گره‌ها چگونه مرتب و متصل شوند. مثال زیر یک شیء SmartArt را با مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **بررسی اینکه آیا یک گره SmartArt مخفی است**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnode/ishidden/) نشان می‌دهد آیا گره در مدل داده‌ای SmartArt مخفی است یا خیر. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی زمانی که طرح‌بندی انتخاب‌شده آن‌ها را به‌عنوان عناصر نمودار قابل مشاهده نمایش نمی‌دهد.

مثال زیر یک گره به شیء SmartArt که از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` استفاده می‌کند، اضافه می‌کند و وضعیت مخفی بودن گره را بررسی می‌کند.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **دریافت یا تنظیم طرح‌بندی نمودار سازمانی**

برای نمودارهای SmartArt که از طرح‌بندی نمودار سازمانی استفاده می‌کنند، [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) و [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) تعیین می‌کنند که گره‌های فرزند تحت یک گره والد چگونه مرتب شوند. به عنوان مثال، می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو طرف آویزان شوند، بسته به [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/organizationchartlayouttype/) انتخاب‌شده.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و طرح‌بندی گره اول را به مقدار [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` تنظیم می‌نماید.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ایجاد نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح‌بندی SmartArt است که برای نمودارهای سلسله‌مراتبی شامل جای‌گیری‌های تصویر طراحی شده است. هنگام افزودن شیء SmartArt به یک اسلاید، مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` را استفاده کنید.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **سوالات متداول**

**آیا SmartArt از آینه‌سازی یا برگرداندن برای زبان‌های راست به چپ پشتیبانی می‌کند؟**

بله. متد [SmartArt::setReversed](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/setreversed/) جهت نمودار را از چپ به راست به راست به چپ (یا برعکس) تغییر می‌دهد، وقتی که طرح‌بندی انتخاب‌شده SmartArt از برگردان پشتیبانی می‌کند.

**چگونه می‌توانم SmartArt را به همان اسلاید یا به ارائهٔ دیگری کپی کنم در حالی که قالب‌بندی حفظ شود؟**

می‌توانید [شکل SmartArt را کلون کنید](/slides/fa/php-java/shape-manipulations/) با استفاده از [ShapeCollection::addClone](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shapecollection/addclone/) یا تمام اسلاید حاوی SmartArt را [کلون کنید](/slides/fa/php-java/clone-slides/). هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به تصویر رستری برای پیش‌نمایش یا صادرات وب رندر کنم؟**

[اسلاید را رندر کنید](/slides/fa/php-java/convert-powerpoint-to-png/) یا کل ارائه را به PNG یا JPEG. SmartArt به‌عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توانم یک شیء SmartArt خاص را در یک اسلاید پیدا کنم اگر چندین شیء موجود باشد؟**

یک مقدار متمایز برای [Shape::getAlternativeText](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getalternativetext/) یا [Shape::getName](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/getname/) بر روی شکل SmartArt تنظیم کنید، سپس آن مقدار را در [BaseSlide::getShapes](https://reference.aspose.com/slides/fa/php-java/aspose.slides/baseslide/#getShapes) جستجو کنید و پس از آن بررسی کنید که شکل مطابق، یک [SmartArt](https://reference.aspose.com/slides/fa/php-java/aspose.slides/smartart/) است.