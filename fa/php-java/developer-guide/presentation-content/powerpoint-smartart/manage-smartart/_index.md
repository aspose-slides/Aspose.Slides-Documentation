---
title: "مدیریت SmartArt در ارائه‌های PowerPoint با استفاده از PHP"
linktitle: "مدیریت SmartArt"
type: docs
weight: 10
url: /fa/php-java/manage-smartart/
keywords:
  - SmartArt
  - متن SmartArt
  - نوع چیدمان
  - ویژگی مخفی
  - نمودار سازمانی
  - نمودار سازمانی تصویری
  - PowerPoint
  - ارائه
  - PHP
  - Aspose.Slides
description: "یاد بگیرید چگونه SmartArt PowerPoint را با Aspose.Slides برای PHP از طریق Java بسازید و ویرایش کنید، با استفاده از نمونه‌های کد واضح که طراحی اسلاید و خودکارسازی را سرعت می‌بخشند."
---
## **بررسی کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، شکل‌های گره و یک چیدمان ساخته می‌شود. با Aspose.Slides for PHP via Java می‌توانید SmartArt ایجاد کنید، متن را از گره‌های آن بخوانید، چیدمان آن را تغییر دهید، گره‌های مخفی را بررسی کنید، چیدمان‌های نمودار سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری بسازید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند یک یا چند شکل داشته باشد. برای خواندن متن از شکل‌های گره، از طریق [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/) تکرار کنید، سپس [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) بازگردانده شده توسط [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/) را بخوانید.

این مثال به یک ارائه با حداقل یک اسلاید و یک شیء SmartArt به‌عنوان اولین شکل در آن اسلاید نیاز دارد. هر فریم متن موجود را در کنسول چاپ می‌کند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **تغییر نوع چیدمان شیء SmartArt**

چیدمان SmartArt نحوهٔ ترتیب و اتصال گره‌ها را کنترل می‌کند. مثال زیر یک شیء SmartArt با مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند. موقعیت و اندازه‌ای که به [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) پاس داده می‌شود بر حسب پوینت است. برای تغییر چیدمان از [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) استفاده کنید.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **بررسی مخفی بودن یک گره SmartArt**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) نشان می‌دهد آیا گره در مدل داده SmartArt مخفی است یا نه. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی زمانی که چیدمان انتخاب‌شده آن‌ها را به‌عنوان عناصر نمودار قابل رؤیت نمایش نمی‌دهد.

مثال زیر یک گره به شیء SmartArt که از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` استفاده می‌کند، اضافه می‌کند و وضعیت مخفی بودن گره افزوده‌شده را بررسی می‌نماید. اگر گره مخفی باشد یک پیام چاپ می‌کند و نمودار را ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **دریافت یا تنظیم چیدمان نمودار سازمانی**

برای نمودارهای SmartArt که از چیدمان نمودار سازمانی استفاده می‌کنند، [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) و [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) تعریف می‌کنند که گره‌های فرزند زیر گره والد چگونه ترتیب داده شوند. به‌عنوان مثال می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو طرف آویزان شوند، بسته به [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) انتخاب‌شده.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و چیدمان گرهٔ اول را به مقدار [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` تنظیم می‌کند. اندیس صفر‑پایه `0` گرهٔ سطح بالای اول را انتخاب می‌کند؛ گره‌های فرزند آن از ترتیب انتخاب‌شده استفاده می‌کنند. ارائهٔ تغییر یافته سپس ذخیره می‌شود.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ایجاد نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک چیدمان SmartArt است که برای نمودارهای سلسله‌مراتبی شامل مکان‌گیرهای تصویر طراحی شده است. هنگام افزودن شیء SmartArt به یک اسلاید، مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` را استفاده کنید. این مثال یک نمودار با مکان‌گیرهای تصویر ذخیره می‌کند؛ اما تصویرها را در این مکان‌گیرها قرار نمی‌دهد.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تبدیل نمودارهای قدیمی به گروهی از اشکال**

هنگام به‌روز رسانی یک ارائه موجود، ممکن است نیاز داشته باشید نمودار سازمانی‌ای که در PowerPoint 97–2003 ایجاد شده است را به‌روزرسانی کنید. Aspose.Slides این نمودارهای قدیمی را به عنوان اشیاء [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) نمایش می‌دهد. برای تبدیل یک نمودار به گروهی از اشکال که بتوانید عناصر بصری جداگانه را ویرایش کنید، از [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) استفاده کنید. برای جزئیات به [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) مراجعه کنید.

تبدیل یک گروه جدید به مجموعهٔ اشکال اضافه می‌کند بدون اینکه نمودار اصلی حذف شود. پس از تبدیل موفق، برای جلوگیری از محتوای تکراری، اصل را با [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) حذف کنید. قبل از تبدیل، نمودارهای قدیمی را در یک فهرست جمع‌آوری کنید تا افزودن و حذف اشکال باعث اختلال در تکرار نشود.

مثال زیر یک ارائه را باز می‌کند، هر اسلاید را جستجو می‌کند، نمودارها را به گروهی از اشکال تبدیل می‌کند و ارائه به‌روزشده را به صورت PPTX ذخیره می‌کند.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ارائهٔ ذخیره‌شده حاوی گروه‌های قابل ویرایش از اشکال به‌جای نمودارهای قدیمی تبدیل‌شده است و دیگر نمودارهای اصلی در کنار آن‌ها وجود ندارند. فایل PPTX را در PowerPoint باز کنید تا عناصر جداگانهٔ هر گروه، مانند متن، پرشدن یا موقعیت آن‌ها را ویرایش نمایید.

## **پرسش‌های متداول**

**آیا SmartArt از آینه‌برداری یا معکوس‌سازی برای زبان‌های راست به چپ پشتیبانی می‌کند؟**

بله. متد [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) جهت نمودار را از چپ به راست به راست به چپ یا برعکس تغییر می‌دهد، زمانی که چیدمان SmartArt انتخاب‌شده از معکوس‌سازی پشتیبانی کند.

**چگونه می‌توانم SmartArt را در همان اسلاید یا در ارائهٔ دیگری کپی کنم در حالی که قالب‌بندی حفظ شود؟**

می‌توانید [شکل SmartArt را کلون کنید](/slides/fa/php-java/shape-manipulations/) با استفاده از [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) یا [کلون کل اسلاید](/slides/fa/php-java/clone-slides/) که شامل SmartArt است، انجام دهید. هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به یک تصویر رستر برای پیش‌نمایش یا صادرات وب تبدیل کنم؟**

[رندر اسلاید](/slides/fa/php-java/convert-powerpoint-to-png/) یا کل ارائه را به PNG یا JPEG تبدیل کنید. SmartArt به‌عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توانم یک شیء SmartArt خاص را در یک اسلاید پیدا کنم اگر چندین مورد وجود داشته باشد؟**

از [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) یا [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) استفاده کنید تا متن جایگزین یا نام متمایزی به شکل SmartArt اختصاص دهید، سپس آن مقدار را در [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) جستجو کنید و سپس بررسی کنید که شکل یافت‌شده یک [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) باشد.