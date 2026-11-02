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
- پیوند ویدیو
- پیوند قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "افزودن، قالب‌بندی، به‌روزرسانی و حذف پیوندها در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای PHP از طریق Java، با استفاده از مثال‌های PHP."
---
## **مقدمه**

یک پیوند (hyperlink) محتویات ارائه را به یک وب‌سایت یا مکانی درون ارائه متصل می‌کند. در PowerPoint، پیوندها معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از متن، یک شکل یا یک قاب رسانه‌ای.
* پیمایش به اسلاید دیگری، به عنوان مثال از فهرست مطالب.

Aspose.Slides برای PHP از طریق Java به شما امکان می‌دهد این پیوندها را اضافه کنید، ظاهر و صدای آن‌ها را کنترل کنید، خواصشان را به‌روزرسانی کنید و حذف کنید. مثال‌های زیر نشان می‌دهند چگونه بر روی عناصر منفرد با پیوندها کار کنید و چگونه به پیوندها در سطح ارائه، اسلاید یا فریم متن دسترسی داشته باشید. فرض می‌شود که PHP/Java Bridge و بسته‌بند Aspose.Slides برای PHP مقداردهی اولیه شده‌اند. اعضای API که صفحه مرجع PHP ندارند به API جاوا زیرین لینک می‌شوند.

{{% alert color="info" title="Note" %}}
همچنین می‌توانید ارائه‌ها را با [ویرایشگر رایگان آنلاین Aspose PowerPoint](https://products.aspose.app/slides/editor) ویرایش کنید.
{{% /alert %}} 

## **افزودن پیوندهای URL**

می‌توانید یک URL وب‌سایت را به متن، یک شکل یا یک قاب رسانه‌ای اختصاص دهید. عنصری که پیوند به آن اختصاص می‌یابد ناحیه قابل کلیک را تعیین می‌کند: بخشی از متن فقط متن انتخاب‌شده را لینک می‌کند، در حالی که یک شکل یا قاب کل شیء اسلاید را لینک می‌کند.

برای ارائه‌هایی که پیوندهای نسبی دارند، به [Manage the Hyperlink Base](/slides/fa/php-java/presentation-properties/#manage-the-hyperlink-base) مراجعه کنید تا پایه سطری سند را بخوانید، تغییر دهید یا پاک کنید.

### **افزودن پیوندهای URL به متن**

برای لینک کردن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) را به متد [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) بخش متن پاس می‌دهید، همان‌طور که در زیر نشان داده شده است. فقط همان بخش متن قابل کلیک می‌شود.

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

### **افزودن پیوندهای URL به اشکال و قاب‌های رسانه‌ای**

برای قابل کلیک کردن کردن یک شکل یا قاب، متد [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) آن را فراخوانی کنید. پیوند به خود شیء تعلق دارد نه به بخشی از متن داخل آن.

همین روش برای قاب‌های تصویر، صدا و ویدیو اعمال می‌شود: پیوند را به قاب اختصاص دهید و در صورت نیاز متد [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) را فراخوانی کنید.

مثال زیر یک مستطیل را قابل کلیک می‌کند:

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

## **استفاده از پیوندها برای ساخت فهرست مطالب**

پیوندهای داخلی به خوانندگان اجازه می‌دهند از فهرست مطالب به اسلاید خاصی پرش کنند. مثال زیر از متد [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) برای لینک کردن متن «صفحه 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

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

متد [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) کلاس [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) تعیین می‌کند که آیا پیوند از رنگ پیوندهای ارائه استفاده کند یا قالب‌بندی بخش متن. برای اعمال رنگ متن سفارشی، [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پر شدن بخش را تنظیم کنید. این ویژگی از PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو پیوند متنی را به همان اسلاید اضافه می‌کند. اولی با پر شدن متن قرمز است، در حالی که دومین رنگ پیش‌فرض پیوند را حفظ می‌کند.

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

یک پیوند می‌تواند هنگام فعال شدن صدا پخش کند یا صدای در حال پخش را متوقف کند. برای پیکربندی این رفتارها از متدهای زیر استفاده کنید:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) صدای مرتبط با پیوند را تعیین می‌کند.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) کنترل می‌کند که آیا فعال کردن پیوند صدای قبلی را متوقف می‌کند یا نه.

#### **افزودن صدا به پیوند**

مثال زیر فایل `sampleaudio.wav` را بارگذاری می‌کند و آن را به دکمه‌ای در اسلاید اول اختصاص می‌دهد. کلیک روی دکمه صدا را پخش می‌کند و به اسلاید بعدی می‌برد. شکل دوم در همان اسلاید با کلیک صدا را متوقف می‌کند، بدون انجام عمل ناوبری.

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

#### **استخراج صدا از پیوند**

مثال زیر ارائه‌ای که در بالا ایجاد شد را باز می‌کند و صداهای پیوند اولین شکل را از طریق متدهای [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) و [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) به حافظه می‌خواند.

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

### **Tooltip و تنظیمات تعامل**

پس از اختصاص پیوند به متن یا شکل می‌توانید متدهای زیر کلاس [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) را فراخوانی کنید:

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) متنی را که بیننده می‌تواند به عنوان راهنمای لینک مشاهده کند تنظیم می‌گردد.
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) فریم هدف را در یک مجموعه فریم HTML والد، در صورت لزوم، مشخص می‌کند.
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) تعیین می‌کند که آیا فعال‌سازی لینک به فهرست پیوندهای مشاهده‌شده اضافه شود یا نه.
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) کنترل می‌کند که آیا پیوند هنگام کلیک برجسته شود یا نه.

## **حذف پیوندها از ارائه‌ها**

از متد [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) برای جمع‌آوری محفظه‌های پیوند، از جمله پیوندهای بخش متن، پیش از تغییر آن‌ها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط متد [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) یا [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) را فراخوانی کنید؛ حذف عمل کلیک، عمل mouse‑over را حذف نمی‌کند.

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

برای حذف بدون شرط، متد [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) هر دو نوع فعال‌سازی را در محدوده انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی گزینشی و شامل کردن مسترها، طرح‌بندی‌ها و نکات، به بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

## **ساخت فهرست کامل پیوندها**

قبل از توزیع یک ارائه، اقدامات تعاملی و لینک‌های وب آن را فهرست کنید. متد [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) اشیاء [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) را بر می‌گرداند، نه فهرست مسطحی از رشته‌های URL. بر روی هر محفظه هم [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) و هم [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) بررسی کنید. این دو مستقل هستند: یک محفظه می‌تواند هر دو عمل را در خود داشته باشد، بنابراین گزارش کامل ممکن است تا دو ردیف برای هر محفظه نیاز داشته باشد.

فقط بررسی پیوندهای سطح شکل می‌تواند پیوندهای اختصاص‌داده‌شده به بخش‌های متن را نادیده بگیرد. به جای آن، دامنه مناسب را کوئری کنید و محفظه‌های بازگشتی را نگهداری کنید تا بعداً بتوانید اعمال آن‌ها را به‌روزرسانی یا حذف کنید.

### **کوئری دامنه‌های ارائه، اسلاید و فریم متن**

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) از طریق متدهای [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/)، [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) و [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/) در دسترس است. هر دامنه همان پرس‌و‌جوها را پشتیبانی می‌کند:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) محفظه‌های دارای عمل کلیک را بر می‌گرداند.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) محفظه‌های دارای عمل mouse‑over را بر می‌گرداند.
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) محفظه‌های دارای هر یک یا هر دو عمل را بر می‌گرداند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` ایجاد می‌کند که شامل یک لینک کلیک خارجی، یک لینک mouse‑over فایل، ناوبری اسلاید داخلی، یک لینک mouse‑over متن و یک عمل ماکرو است. این مثال هیچ‌یک از این اعمال را اجرا نمی‌کند. همان سه کوئری در هر دامنه کار می‌کند؛ شمارش‌ها تعداد محفظه‌ها را نشان می‌دهد، نه مجموع اعمال. دامنه فریم متن لینک‌های شکل محاطی خود را شامل نمی‌شود.

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

برای این مثال، کوئری‌های ارائه و اسلاید هر کدام سه محفظه کلیک، دو محفظه mouse‑over و سه محفظه با هر یک از اعمال را گزارش می‌کنند. کوئری فریم متن در هر دسته یک محفظه گزارش می‌دهد.

### **دسته‌بندی اعمال و مقصدها**

از متد [Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) برای تفسیر یک عمل قبل از بررسی مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب شامل می‌شوند:

| مقدارها | معنی برای حسابرسی |
| --- | --- |
| `Hyperlink` | پیوند خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاص. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری پیش‌فرض اسلایدشو، در زمینه اسلایدشو حل می‌شود. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش فعلی یا شروع یک نمایش سفارشی. |
| `StartMacro` | اجرای ماکرو. |
| `StartProgram` | راه‌اندازی برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن فایل یا ارائه دیگر؛ جدا از URLهای وب بررسی شود. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری، یا عمل ناشناخته‌ای که نیاز به بررسی دارد. |

مقاصد خارجی را از متد [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) و مقاصد داخلی خاص را از متد [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/) بخوانید. اعمال داخلی و دستورات داخلی ممکن است URL خارجی نداشته باشند؛ URL خالی به این معنی نیست که محفظه هیچ عملی ندارد. وقتی مقدار بازگردانده‌شده توسط [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) با URL نرمال‌شده متفاوت باشد، آن را حفظ کنید و وقتی موجود باشد، متن tooltip بازگردانده‌شده توسط [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) را نیز شامل کنید.

### **گزارش، پاک‌سازی و اعتبارسنجی پیوندها**

مثال PHP زیر یک ارائه موجود (فایلی که در بالا ایجاد شد) را می‌خواند، `hyperlink-audit.json` می‌نویسد، سیاستی را اعمال می‌کند، `hyperlink-sanitized.pptx` را ذخیره می‌کند و دوباره باز می‌کند تا هر دو نوع فعال‌سازی را بررسی کند. قبل از تغییر، محفظه‌ها را جمع‌آوری می‌کند و برای جلوگیری از پردازش دوبار یکسان از برابری ارجاعی استفاده می‌کند. کوئری‌های ارائه اسلایدهای عادی را پوشش می‌دهند؛ برای فهرست‌کشی در سطوح بسته، به‌طور صریح مسترها، طرح‌بندی‌ها، نکات و مسترهای نکات و برگه‌های توزیع را نیز کوئری می‌کند.

گزارش، اندیس اسلاید یک‌پایه و [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) را وقتی موجود باشد، ذخیره می‌کند. [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) اسلاید مالک را برای محفظه‌های پشتیبانی‌شده فراهم می‌کند. مسترها، طرح‌بندی‌ها و نکات اندیس اسلاید معمولی ندارند و با دامنهٔ خود شناسایی می‌شوند. محفظه‌های شکل و محفظه‌های قالب‌بندی بخش متن به‌صورت جداگانه برچسب‌گذاری می‌شوند؛ انواع دیگر محفظه نام نوع زمان اجرا خود را حفظ می‌کنند. هر محفظه یک شناسه محلی گزارش دریافت می‌کند تا دو عمل آن بتوانند همبسته شوند. گزارش انواع عمل را به‌عنوان ثابت‌های عددی تعریف‌شده توسط شمارش PHP ذخیره می‌کند.

این سیاست کاربردی محدود، تنها URLهای مطلق HTTPS و هدف‌های اسلاید داخلی معتبر را می‌پذیرد. ماکروها، برنامه‌ها، عمل‌های فایل، سایر اعمال اسلایدشو، عمل‌های ناشناخته و سایر طرح‌های URL رد می‌شوند. این ردها تصمیمات سیاستی هستند، نه قضاوتی دربارهٔ ایمنی Aspose.Slides. تنها داشتن HTTPS کافی نیست؛ فهرست‌های سفید میزبان و بررسی‌های دیگر برای برنامهٔ شما اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. این مثال متادیتا را بدون دنبال کردن لینک‌ها یا اجرای اعمال حسابرسی می‌کند.

برای اصلاح، محفظهٔ [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) متدهای [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/)، [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) را پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی ممنوع با یک صفحه فرود ثابت HTTPS جایگزین می‌شوند؛ کلیک‌ها و اعمال mouse‑over ممنوع دیگر به‌طور مستقل حذف می‌شوند. مقدار `$replaceExternalClicks` را به `false` تنظیم کنید تا تمام نقض‌های سیاست حذف شوند. قبل از انتشار، صفحهٔ جایگزین متعلق به برنامهٔ خود را انتخاب کنید.

پرچم خروجی گزارش از سیاست بازبینی محافظه‌کارانه PDF استفاده می‌کند: اعمال mouse‑over و هر چیزی غیر از یک لینک خارجی یا پرش اسلاید خاص به‌عنوان احتمالا پشتیبانی‌نشده پرچم‌گذاری می‌شوند. این یک نکتهٔ بازبینی است، نه آزمون قابلیت یا ضمانتی که لینک‌های بدون پرچم بر خروجی حفظ می‌شوند. خروجی‌های پشتیبانی‌شدهٔ [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/php-java/convert-powerpoint-to-html/) ممکن است پیوندها را حفظ کنند، بسته به عمل، گزینه‌های خروجی و مرورگر. [تصاویر](/slides/fa/php-java/convert-powerpoint-to-png/) و [ویدیو](/slides/fa/php-java/convert-powerpoint-to-video/) رستری نمی‌توانند پیوندهای تعاملی را حفظ کنند؛ برای آن‌ها همهٔ اعمال را هنگام حسابرسی پرچم‌گذاری کنید.

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

با ورودی ساخته‌شده در بالا، گزارش شامل پنج ردیف عمل است. لینک mouse‑over فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری اسلاید داخلی باقی می‌مانند. اعتبارسنجی صفر عمل ممنوعی چاپ می‌کند. ورودی‌ای که شامل یک URL کلیک خارجی ممنوع است، شاخهٔ جایگزینی را نیز اجرا می‌کند. محفظه‌ای با کلیک مجاز و mouse‑over ممنوع کلیک خود را حفظ می‌کند.

این پاک‌سازی گزینشی با [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) تفاوت دارد؛ این آخرین متد هر دو نوع فعال‌سازی را در دامنهٔ انتخاب‌شده صرف‌نظر از سیاست حذف می‌کند. اعتبارسنجی اینجا فقط اعمال پیوندها را بررسی می‌کند؛ پروژه‌های VBA توکار، اشیای OLE یا سایر محتوای فعال را حذف نمی‌کند و همچنین صحت فایل‌های PDF یا HTML خروجی را اعتبارسنجی نمی‌کند.

## **پرسش‌های متداول**

**چگونه می‌توانم به یک بخش یا اسلاید اول آن لینک دهم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک پیوند داخلی به یک اسلاید منفرد هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اسلاید اول آن بخش لینک کنید.

**آیا می‌توان پیوند را به عناصر اسلاید مستر الصاق کرد تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید مستر و طرح‌بندی از پیوندها پشتیبانی می‌کنند. این لینک‌ها در زمان اجرا بر روی اسلایدهایی که از مستر یا طرح‌بندی مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا پیوندها هنگام خروجی به PDF، HTML، تصویر یا ویدیو حفظ می‌شوند؟**

خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است پیوندها را حفظ کنند؛ تصاویر رستری و ویدیو نمی‌توانند پیوندهای تعاملی را حفظ کنند. برای جزئیات بیشتر به ملاحظات خروجی در بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.