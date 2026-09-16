---
title: مدیریت پیوندهای ارائه در PHP
linktitle: مدیریت پیوندها
type: docs
weight: 20
url: /fa/php-java/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن پیوند
- ایجاد پیوند
- قالب‌بندی پیوند
- حذف پیوند
- به‌روزرسانی پیوند
- پیوند متن
- پیوند اسلاید
- پیوند شکل
- پیوند تصویر
- پیوند ویدئو
- پیوند قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "افزودن، قالب‌بندی، به‌روزرسانی و حذف پیوندها در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای PHP از طریق Java، با استفاده از مثال‌های PHP."
---
## **مقدمه**

یک پیوند (hyperlink) محتویات ارائه را به یک وب‌سایت یا به مکانی درون ارائه متصل می‌کند. در PowerPoint، پیوندها معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از متن، یک شکل یا یک فریم رسانه‌ای.
* رفتن به اسلاید دیگری، به عنوان مثال از فهرست مطالب.

Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد این پیوندها را اضافه کنید، ظاهر و صدای آن‌ها را کنترل کنید، ویژگی‌هایشان را به‌روز کنید و حذف کنید. مثال‌های زیر نشان می‌دهند چگونه با پیوندها روی عناصر منفرد کار کنید و چگونه به پیوندها در سطح ارائه، اسلاید یا فریم متن دسترسی پیدا کنید. این مثال‌ها فرض می‌کنند که PHP/Java Bridge و بستهٔ Aspose.Slides برای PHP مقداردهی اولیه شده‌اند. اعضای API که صفحهٔ مرجع PHP ندارند به API پایهٔ Java لینک می‌شوند.

{{% alert color="info" title="Note" %}}
می‌توانید ارائه‌ها را با [ویرایشگر رایگان آنلاین Aspose PowerPoint](https://products.aspose.app/slides/fa/editor) ویرایش کنید.
{{% /alert %}} 

## **افزودن پیوندهای URL**

می‌توانید یک URL وب‌سایت را به متن، یک شکل یا یک فریم رسانه‌ای اختصاص دهید. عنصری که پیوند را به آن اختصاص می‌دهید، ناحیهٔ قابل کلیک را تعیین می‌کند: بخشی از متن به متن انتخاب شده لینک می‌شود، در حالی که یک شکل یا فریم به شیء اسلاید لینک می‌دهد.

### **افزودن پیوندهای URL به متن**

برای لینک کردن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/) را به متد [setHyperlinkClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/portionformat/sethyperlinkclick/) بخش متن پاس کنید، همان‌طور که در زیر نشان داده شده است. فقط آن بخش از متن قابل کلیک می‌شود.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **افزودن پیوندهای URL به اشکال و فریم‌های رسانه‌ای**

برای کلیک‌شدن یک شکل یا فریم، متد [setHyperlinkClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/shape/sethyperlinkclick/) آن را فراخوانی کنید. پیوند به خود شیء تعلق دارد نه به بخشی از متن داخل آن.

همین رویکرد برای فریم‌های تصویر، صدا و ویدئو اعمال می‌شود: پیوند را به فریم اختصاص دهید و در صورت نیاز متد [setTooltip](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/settooltip/) را صدا بزنید.

مثال زیر یک مستطیل را کلیک‌پذیر می‌کند:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **استفاده از پیوندها برای ایجاد فهرست مطالب**

پیوندهای داخلی به خوانندگان اجازه می‌دهند از فهرست مطالب به اسلاید خاصی پرش کنند. مثال زیر از متد [setInternalHyperlinkClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) برای لینک کردن متن «Page 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **قالب‌بندی پیوندها**

### **رنگ**

متد [setColorSource](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/setcolorsource/) در کلاس [Hyperlink](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/) تعیین می‌کند که آیا پیوند از رنگ پیوندهای ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ متن دلخواه، [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پر کردن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو پیوند متنی را به یک اسلاید اضافه می‌کند. اولین پیوند از پر کردن متن قرمز استفاده می‌کند، در حالی که دومین پیوند رنگ پیش‌فرض پیوند را حفظ می‌کند.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **صدا**

یک پیوند می‌تواند هنگام فعال شدن صدایی پخش کند یا صدایی که در حال پخش است را متوقف کند. از روش‌های زیر برای پیکربندی این رفتارها استفاده کنید:

- [Hyperlink::setSound](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/setsound/) صدایی که به پیوند مرتبط است را مشخص می‌کند.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/setstopsoundonclick/) کنترل می‌کند که آیا فعال‌سازی پیوند صداهای قبلی را متوقف می‌کند یا نه.

#### **افزودن صدای پیوند**

مثال زیر فایل `sampleaudio.wav` را بارگذاری می‌کند و آن را به یک دکمه در اسلاید اول مرتبط می‌سازد. کلیک بر دکمه صدای موردنظر را پخش می‌کند و به اسلاید بعدی می‌رود. شکل دوم در همان اسلاید با کلیک صدا را متوقف می‌کند، بدون انجام عمل پیمایش.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **استخراج صدای پیوند**

مثال زیر ارائه‌ای که بالا ایجاد شده را باز می‌کند و صدای پیوند شکل اول را از طریق متدهای [getSound](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/getsound/) و [getBinaryData](https://reference.aspose.com/slides/fa/php-java/aspose.slides/audio/getbinarydata/) به حافظه می‌خواند.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **تنظیمات Tooltip و تعامل**

پس از اختصاص پیوند به متن یا شکل می‌توانید روش‌های زیر کلاس [Hyperlink](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/) را فراخوانی کنید:

- [setTooltip](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/settooltip/) متنی را که بیننده می‌تواند به‌عنوان راهنمای پیوند نمایش دهد، تنظیم می‌کند.
- [setTargetFrame](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/settargetframe/) فریم هدف درون یک فریم‌ست HTML والد را (در صورت امکان) مشخص می‌کند.
- [setHistory](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/sethistory/) کنترل می‌کند که آیا فعال‌سازی پیوند مقصد آن را به لیست پیوندهای مشاهده‌شده اضافه می‌کند یا نه.
- [setHighlightClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/sethighlightclick/) کنترل می‌کند که آیا پیوند هنگام کلیک برجسته شود یا خیر.

## **حذف پیوندها از ارائه‌ها**

از متد [getAnyHyperlinks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) برای جمع‌آوری کانتینرهای پیوند، از جمله پیوندهای بخش متن، قبل از تغییر آنها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف فقط یک نوع، تنها [removeHyperlinkClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) یا [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) را صدا بزنید؛ حذف عمل کلیک، معادل حذف عمل موس‑بالای آن نیست.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

برای حذف بدون شرط، متد [removeAllHyperlinks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) هر دو نوع فعال‌سازی را در حوزهٔ انتخابی در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، طرح‌بندی‌ها و یادداشت‌ها، به بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

## **ساخت یک فهرست کامل از پیوندها**

قبل از توزیع یک ارائه، اقدامات تعاملی و وب‌لینک‌های آن را فهرست کنید. متد [getAnyHyperlinks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) اشیای [IHyperlinkContainer](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkcontainer/) را برمی‌گرداند، نه یک فهرست صاف از رشته‌های URL. بر روی هر کانتینر هر دو متد [getHyperlinkClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) و [getHyperlinkMouseOver](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) را بررسی کنید. آن‌ها مستقل‌اند: یک کانتینر می‌تواند هر دو عمل را نشان دهد، بنابراین یک گزارش کامل ممکن است تا دو ردیف برای هر کانتینر نیاز داشته باشد.

اسکن فقط پیوندهای سطح شکل ممکن است پیوندهای متصل به بخش‌های متن را از دست بدهد. به‌جای آن، حوزه مناسب را پرس‌وجو کنید و کانتینرهای بازگردانده‌شده را نگه‌دارید تا بعداً بتوانید اعمال آن‌ها را به‌روز یا حذف کنید.

### **پرس‌وجو حوزه‌های ارائه، اسلاید و فریم متن**

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/) از طریق متدهای [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/gethyperlinkqueries/)، [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) و [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/fa/php-java/aspose.slides/textframe/gethyperlinkqueries/) در دسترس است. هر حوزه همان پرس‌وجوها را پشتیبانی می‌کند:

- [getHyperlinkClicks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) کانتینرهایی را برمی‌گرداند که عمل کلیک دارند.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) کانتینرهایی را برمی‌گرداند که عمل موس‑بالا دارند.
- [getAnyHyperlinks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) کانتینرهایی را برمی‌گرداند که هر یک یا هر دو عمل را دارند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` ایجاد می‌کند که شامل یک لینک کلیک خارجی، یک لینک موس‑بالای فایل، یک پیمایش اسلاید داخلی، یک لینک موس‑بالای متن و یک عمل ماکرو است. این مثال هیچ‌یک از این اعمال را اجرا نمی‌کند. هر سه پرس‌وجو در هر حوزه‌ای کار می‌کند؛ شمارش‌ها نشان‌دهندهٔ کانتینرها است، نه مجموع اعمال. حوزهٔ فریم متن، پیوندهای خود شکل ظرفی را شامل نمی‌شود.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

برای این مثال، پرس‌وجوهای ارائه و اسلاید هر کدام سه کانتینر کلیک، دو کانتینر موس‑بالا و سه کانتینر دارای هر یک از این اعمال را گزارش می‌کنند. پرس‌وجوی فریم متن یک کانتینر در هر دسته گزارش می‌دهد.

### **دسته‌بندی اعمال و مقاصد**

از متد [Hyperlink::getActionType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/getactiontype/) برای تفسیر یک عمل قبل از تفسیر مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب را پوشش می‌دهند:

| مقادیر | معنی برای حسابرسی |
| --- | --- |
| `Hyperlink` | پیوند خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به یک اسلاید خاص. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری داخلی پیش‌ساختهٔ نمایش اسلاید، در زمینهٔ نمایش اسلاید حل می‌شود. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش جاری یا شروع یک نمایش سفارشی. |
| `StartMacro` | اجرای یک ماکرو. |
| `StartProgram` | راه‌اندازی یک برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن یک فایل یا ارائهٔ دیگر؛ جداگانه از URLهای وب بررسی کنید. |
| `StartStopMedia` | آغاز یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری، یا عمل ناشناخته‌ای که نیاز به بررسی دارد. |

مقاصد خارجی را با استفاده از متد [getExternalUrl](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/getexternalurl/) بخوانید و مقاصد داخلی خاص را با متد [getTargetSlide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/gettargetslide/) به‌دست آورید. اعمال داخلی و دستورهای پیش‌ساخته ممکن است URL خارجی نداشته باشند؛ URL خالی به این معنی نیست که کانتینر هیچ عملی ندارد. مقدار بازگردانده‌شده توسط [getExternalUrlOriginal](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) را هنگامی که با URL نرمال‌شده متفاوت است، حفظ کنید و tooltip بازگردانده‌شده توسط [getTooltip](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlink/gettooltip/) را در صورت موجود بودن شامل کنید.

### **گزارش، پاک‌سازی و بررسی پیوندها**

مثال PHP زیر یک ارائهٔ موجود را می‌خواند (از فایلی که بالا ایجاد شد استفاده کنید)، `hyperlink-audit.json` می‌نویسد، یک سیاست را اعمال می‌کند، `hyperlink-sanitized.pptx` را ذخیره می‌کند و برای بررسی دوباره هر دو نوع فعال‌سازی آن را باز می‌گیرد. پیش از تغییر، کانتینرها را جمع‌آوری می‌کند و برای جلوگیری از پردازش دوبارهٔ همان کانتینر از برابری مرجع استفاده می‌کند. پرس‌وجوهای ارائه اسلایدهای عادی را شامل می‌شود؛ برای فهرست‌گذاری در سطح بسته، به‌صورت صریح مسترها، طرح‌بندی‌ها، یادداشت‌ها و مسترهای یادداشت و بروشور را نیز پرس‌وجو می‌کند.

گزارش، شاخص اسلاید یک‌پایه و [getSlideId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/#getSlideId--) را در صورت موجود بودن ثبت می‌کند. [ISlideComponent::getSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecomponent/#getSlide--) اسلاید مالک را برای کانتینرهای پشتیبانی‌شده فراهم می‌کند. مسترها، طرح‌بندی‌ها و یادداشت‌ها شاخص اسلاید عادی ندارند و بر اساس حوزهٔ خود شناسایی می‌شوند. کانتینرهای شکل و کانتینرهای قالب‌بندی بخش متن به‌صورت جداگانه برچسب‌گذاری می‌شوند؛ سایر انواع کانتینر نام نوع زمان اجرا خود را حفظ می‌کنند. هر کانتینر یک شناسه گزارش‑محلی دریافت می‌کند تا دو عمل آن مرتبط شوند. گزارش انواع عمل را به‌عنوان ثابت‌های عددی تعریف‌شده توسط enum PHP ذخیره می‌کند.

این سیاست کاربردی به‌صورت عمدی محدود، فقط URLهای مطلق HTTPS و اهداف اسلاید داخلی معتبر را اجازه می‌دهد. ماکروها، برنامه‌ها، عملیات فایل، سایر عملیات نمایش اسلاید، اعمال ناشناخته و سایر طرح‌های URL را رد می‌کند. این ردها تصمیمات سیاسی هستند، نه قضاوتی دربارهٔ امنیت Aspose.Slides. تنها HTTPS اعتماد را تضمین نمی‌کند: فهرست‌های مجاز میزبانی و بررسی‌های دیگر برای برنامهٔ خود اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال متادیتا را بدون دنبال‌کردن لینک‌ها یا اجرای اعمال بررسی می‌کند.

برای رفع مشکلات، کانتینر از طریق [getHyperlinkManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) متدهای [setExternalHyperlinkClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/)، [removeHyperlinkClick](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) را پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی ممنوع با یک صفحه ثابت HTTPS جایگزین می‌شوند؛ کلیک‌ها و عمل‌های موس‑بالای ممنوع دیگر به‌صورت مستقل حذف می‌شوند. برای حذف تمام تخلفات سیاست، مقدار `$replaceExternalClicks` را به `false` تنظیم کنید. قبل از استقرار، یک صفحهٔ جایگزین تحت مالکیت برنامه انتخاب کنید.

پرچم خروجی گزارش از سیاست بازبینی PDF محتاطانه استفاده می‌کند: عمل‌های موس‑بالا و هر چیزی به‌جز یک لینک خارجی یا پرش اسلاید خاص به‌عنوان احتمال ناپشتیبانی شده پرچم‌گذاری می‌شود. این یک نکتهٔ بازبینی است، نه آزمونی برای قابلیت یا تضمینی که لینک‌های بدون پرچم در خروجی باقی بمانند. خروجی‌های PDF [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) و HTML [HTML](/slides/fa/php-java/convert-powerpoint-to-html/) پشتیبانی‌شده ممکن است پیوندها را حفظ کنند، بسته به عمل، گزینه‌های خروجی و مشاهده‌کننده. تصاویر رستری [images](/slides/fa/php-java/convert-powerpoint-to-png/) و ویدئو [video](/slides/fa/php-java/convert-powerpoint-to-video/) نمی‌توانند پیوندهای تعاملی را حفظ کنند؛ هنگام حسابرسی برای این خروجی‌ها تمام اعمال را پرچم‌گذاری کنید.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

با ورودی‌ای که در بالا ایجاد شد، گزارش شامل پنج ردیف عمل است. لینک موس‑بالای فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و پیمایشی داخلی اسلاید باقی می‌مانند. تاییدیه صفر عمل ممنوع چاپ می‌کند. ورودی‌ای که شامل یک URL کلیک خارجی ممنوع است نیز شاخهٔ جایگزینی را اجرا می‌کند. یک کانتینر با کلیک مجاز و موس‑بالای ممنوع عمل کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی با متد [removeAllHyperlinks](https://reference.aspose.com/slides/fa/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) متفاوت است که هر دو نوع فعال‌سازی را در کل حوزهٔ انتخابی صرف‌نظر از سیاست حذف می‌کند. بررسی در اینجا فقط اعمال پیوند را بررسی می‌کند؛ پروژه‌های VBA توکار، اشیاء OLE یا سایر محتویات فعال را حذف نمی‌کند و یک فایل PDF یا HTML خروجی را نیز اعتبارسنجی نمی‌کند.

## **سوالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک کنم؟**

بخش‌ها در PowerPoint اسلایدها را گروهبندی می‌کنند، اما یک پیوند داخلی به یک اسلاید فردی هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک کنید.

**آیا می‌توانم یک پیوند را به عناصر اسلاید اصلی (master) الصاق کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید اصلی و طرح‌بندی از پیوندها پشتیبانی می‌کنند. پیوندهای موجود بر روی این عناصر در حین نمایش اسلایدهای استفاده‌کننده از مستر یا طرح‌بندی مربوطه قابل دسترسی هستند.

**آیا پیوندها هنگام خروجی به فرمت‌های PDF، HTML، تصویر یا ویدئو حفظ می‌شوند؟**

خروجی‌های پشتیبانی‌شده PDF و HTML ممکن است پیوندها را حفظ کنند؛ اما تصاویر رستری و ویدئوها نمی‌توانند. نکات مربوط به خروجی در بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) را ببینید.