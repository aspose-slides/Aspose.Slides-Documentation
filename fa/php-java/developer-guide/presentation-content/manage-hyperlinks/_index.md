---
title: مدیریت لینک‌های ارائه در PHP
linktitle: مدیریت لینک‌ها
type: docs
weight: 20
url: /fa/php-java/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن لینک‌فراکن
- ایجاد لینک‌فراکن
- قالب‌بندی لینک‌فراکن
- حذف لینک‌فراکن
- به‌روزرسانی لینک‌فراکن
- لینک‌فراکن متن
- لینک‌فراکن اسلاید
- لینک‌فراکن شکل
- لینک‌فراکن تصویر
- لینک‌فراکن ویدئو
- لینک‌فراکن قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "افزودن، قالب‌بندی، به‌روزرسانی و حذف لینک‌فراکن‌ها در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای PHP از طریق Java، با استفاده از مثال‌های PHP."
---
## **معرفی**

یک لینک‌فراکن محتوای ارائه را به یک وب‌سایت یا موقعیتی درون ارائه متصل می‌کند. در PowerPoint، لینک‌فراکن‌ها معمولاً دو هدف را برآورده می‌کنند:

* از متن، یک شکل یا یک فریم رسانه‌ای یک وب‌سایت باز کنید.
* به اسلاید دیگری هدایت شوید، برای مثال، از فهرست مطالب.

Aspose.Slides for PHP via Java به شما امکان می‌دهد این لینک‌ها را اضافه کنید، ظاهر و صدای آنها را کنترل کنید، خصوصیاتشان را به‌روز کنید و آنها را حذف نمایید. مثال‌های زیر نشان می‌دهند چگونه با لینک‌فراکن‌ها بر روی عناصر منفرد کار کنید و چگونه به لینک‌فراکن‌ها در سطح ارائه، اسلاید یا قاب متن دسترسی پیدا کنید. آنها فرض می‌کنند که PHP/Java Bridge و wrapper PHP Aspose.Slides مقداردهی اولیه شده‌اند. اعضای API که صفحه مرجع PHP ندارند به API زیرین Java لینک می‌شوند.

{{% alert color="info" title="Note" %}}
همچنین می‌توانید ارائه‌ها را با [ویرایشگر آنلاین رایگان Aspose PowerPoint](https://products.aspose.app/slides/editor) ویرایش کنید.
{{% /alert %}}

## **افزودن لینک‌فراکن‌های URL**

می‌توانید یک URL وب‌سایت را به متن، یک شکل یا یک فریم رسانه‌ای اختصاص دهید. عنصری که به آن لینک‌فراکن اختصاص می‌دهید، ناحیه قابل کلیک را تعیین می‌کند: یک بخش متن، متن انتخاب‌شده را لینک می‌کند، در حالی که یک شکل یا فریم، شیء اسلاید را لینک می‌کند.

برای ارائه‌های حاوی لینک‌فراکن‌های نسبی، به [مدیریت پایه لینک‌فراکن](/slides/fa/php-java/presentation-properties/#manage-the-hyperlink-base) مراجعه کنید تا پایه سطوح سند را بخوانید، تغییر دهید یا پاک کنید.

### **افزودن لینک‌فراکن‌های URL به متن**

برای لینک کردن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) را به متد [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) بخش متن پاس بدهید، همان‌طور که در زیر نشان داده شده است. فقط آن بخش از متن قابل کلیک می‌شود.

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

### **افزودن لینک‌فراکن‌های URL به اشکال و فریم‌های رسانه‌ای**

برای اینکه کل ناحیه مستطیل قابل کلیک شود، متد [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) را صدا بزنید. برای نمایش یک نکته به خوانندگان درباره مقصد هنگام قرار گرفتن نشانگر بر روی مستطیل، از [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) استفاده کنید. هر دو متد همچنین برای فریم‌های تصویر، صوت و ویدئو قابل اعمال هستند.

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

## **استفاده از لینک‌فراکن‌ها برای ایجاد فهرست مطالب**

لینک‌فراکن‌های داخلی به خوانندگان امکان می‌دهند از فهرست مطالب به اسلاید خاصی پرش کنند. مثال زیر از [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) برای لینک کردن متن «Page 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

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

## **قالب‌بندی لینک‌فراکن‌ها**

می‌توانید رنگ متن لینک‌شده را تغییر دهید، هنگام فعال‌سازی لینک توسط خواننده صدا را پخش یا متوقف کنید و ابزارنمایی (tooltip)ی که در هنگام قرارگیری نشانگر نمایش می‌شود را تنظیم کنید.

### **رنگ**

متد [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) از کلاس [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) تعیین می‌کند که آیا یک لینک‌فراکن از رنگ لینک‌فراکن ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ متن سفارشی، [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پر کردن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

در این مثال، [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) باعث می‌شود اولین لینک از پر رنگ قرمز بخش متن استفاده کند. لینک دوم رنگ لینک‌فراکن ارائه را حفظ می‌کند.

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

یک لینک‌فراکن می‌تواند هنگام فعال‌سازی صدا پخش کند یا صدایی که در حال پخش است را متوقف کند. از متدهای زیر برای پیکربندی این رفتارها استفاده کنید:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) صدا (audio) مرتبط با لینک‌فراکن را مشخص می‌کند.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) کنترل می‌کند که آیا فعال‌سازی لینک‌فراکن صداهای قبلی را متوقف می‌کند یا خیر.

#### **اضافه کردن صدای لینک‌فراکن**

دکمه در اسلاید اول از [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) برای پخش صوت از `sampleaudio.wav` وقتی خواننده برای پیشروی کلیک می‌کند، استفاده می‌کند. در اسلاید دوم، یک دکمه جداگانه از [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) برای توقف پخش و ماندن خواننده در همان اسلاید استفاده می‌کند.

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

#### **استخراج صدای لینک‌فراکن**

مثال زیر ارائه ایجاد شده در بالا را باز می‌کند و صدای لینک‌فراکن اولین شکل را به‌وسیله [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) و [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) به حافظه می‌خواند.

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

### **تنظیمات ابزارنمایی و تعامل**

پس از اختصاص یک لینک‌فراکن به متن یا یک شکل، می‌توانید متدهای زیر از کلاس [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) را فراخوانی کنید:

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) متنی را که مرورگر می‌تواند به عنوان راهنمایی برای لینک نمایش دهد، تنظیم می‌کند.
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) چارچوب هدف را درون یک فریم‌ست HTML والد، در صورت اعمال، مشخص می‌کند.
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) کنترل می‌کند که آیا فعال‌سازی لینک مقصد آن را به فهرست لینک‌فراکن‌های مشاهده‌شده اضافه می‌کند یا خیر.
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) کنترل می‌کند که آیا لینک‌فراکن هنگام کلیک شدن هایلایت می‌شود یا خیر.

## **حذف لینک‌فراکن‌ها از ارائه‌ها**

از [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) برای جمع‌آوری کانتینرهای لینک‌فراکن، شامل لینک‌های بخش متن، پیش از تغییر آنها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) یا [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) را فراخوانی کنید؛ حذف عمل کلیک، معادل حذف عمل ماوس‌اور نیست.

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

برای حذف بدون قید، [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) هر دو نوع فعال‌سازی را در محدوده انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، طرح‌بندی‌ها و یادداشت‌ها، به [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

### **پاک‌سازی لینک‌فراکن‌ها پیش از جایگزینی متن SmartArt**

زمانی که یک پاراگراف را در یک نود SmartArt موجود جایگزین می‌کنید، پاک کردن بخش‌های متنی می‌تواند یک لینک‌فراکن قدیمی را فعال بگذارد. پاراگراف را از طریق [SmartArtNode::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/gettextframe/) دریافت کنید. قبل از پاک کردن بخش‌ها، روی فریم متن شکل نود که پاراگراف را نمایش می‌دهد، متد [getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/) را صدا بزنید، سپس بر روی شیء بازگشتی [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) را فراخوانی کنید. این کار تمام لینک‌فراکن‌های آن فریم، از جمله لینک‌های موجود در پاراگراف‌های دیگر را حذف می‌کند.

مثال فرض می‌کند که سومین شکل در اسلاید اول فایل `SmartArtHyperlink.pptx` یک گرافیک SmartArt است. این مثال اولین پاراگراف نود چهارم را جایگزین می‌کند. در این ارائه، اولین شکل نود آن پاراگراف را نمایش می‌دهد.

پس از افزودن هر دو بخش، مثال قالب‌بندی موثر آنها را با [getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/) می‌خواند. در آن قالب‌بندی، [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) لینک‌فراکن جدید را برای بخش اول و `null` برای بخش دوم برمی‌گرداند.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Portion;
use aspose\slides\Presentation;

$presentation = new Presentation("SmartArtHyperlink.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $smartArt = $slide->getShapes()->get_Item(2);
    $node = $smartArt->getAllNodes()->get_Item(3);
    $paragraph = $node->getTextFrame()->getParagraphs()->get_Item(0);

    $node->getShapes()->get_Item(0)->getTextFrame()->getHyperlinkQueries()->removeAllHyperlinks();
    $paragraph->getPortions()->clear();

    $link = new Portion("New reference");
    $link->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://example.com/new"));
    $paragraph->getPortions()->add($link);
    $text = new Portion(" (updated)");
    $paragraph->getPortions()->add($text);

    echo java_values($link->getPortionFormat()->getEffective()->getHyperlinkClick()->getExternalUrl()), PHP_EOL; // https://example.com/new
    var_dump(java_is_null($text->getPortionFormat()->getEffective()->getHyperlinkClick())); // bool(true): بخش دوم هیچ لینک‌فراکنی ندارد.
} finally {
    $presentation->dispose();
}
```

## **ساخت موجودی کامل لینک‌فراکن‌ها**

قبل از توزیع یک ارائه، اقدامات تعاملی و لینک‌های وب آن را موجودی کنید. [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) اشیای [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) را برمی‌گرداند، نه یک لیست ساده از رشته‌های URL. هم [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) و هم [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) را برای هر کانتینر بررسی کنید. این‌ها مستقل هستند: همان کانتینر می‌تواند هر دو عمل را افشا کند، بنابراین یک گزارش کامل ممکن است تا دو ردیف برای هر کانتینر نیاز داشته باشد.

اسکن تنها لینک‌فراکن‌های سطح شکل می‌تواند لینک‌های پیوست‌شده به بخش‌های متن را از دست بدهد. به‌جای آن محدوده مناسب را جستجو کنید و کانتینرهای حاصل را نگه دارید تا بعداً بتوانید اقدامات آنها را به‌روزرسانی یا حذف کنید.

### **پرس‌وجو در محدوده‌های ارائه، اسلاید و فریم‑متن**

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) از طریق [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), و [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/) در دسترس است. هر محدوده همان پرس‌وجوها را پشتیبانی می‌کند:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) کانتینرهایی را برمی‌گرداند که عمل کلیک دارند.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) کانتینرهایی را برمی‌گرداند که عمل ماوس‌اور دارند.
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) کانتینرهایی را برمی‌گرداند که یکی یا هر دو عمل را دارند.

این مثال عمل کلیک و ماوس‌اور را به یک شکل و متن آن اختصاص می‌دهد و یک عمل ماکرو را به یک دکمه جداگانه. تعداد کانتینرهای بازگردانده‌شده توسط [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) را با شمارش هر نوع فعال‌سازی مقایسه می‌کند. یک پرس‌وجوی فریم‑متن تنها لینک‌های موجود در متن را شمارش می‌کند. اعمال خود شکل محاط‌کننده در پرس‌وجوهای اسلاید و ارائه ظاهر می‌شوند.

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

در این مثال، پرس‌وجوهای ارائه و اسلاید هر یک سه کانتینر کلیک، دو کانتینر ماوس‌اور و سه کانتینر با هر یک از اعمال را گزارش می‌دهند. پرس‌وجوی فریم‑متن یک کانتینر در هر دسته‌بندی گزارش می‌کند.

### **دسته‌بندی اقدامات و مقاصد**

از [Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) برای تفسیر یک عمل قبل از تفسیر مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب را پوشش می‌دهند:

| مقادیر | معنی برای حسابرسی |
| --- | --- |
| `Hyperlink` | لینک‌فراکن خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاصی. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری داخلی پیش‌ساخته اسلایدشو، در زمینه اسلایدشو حل می‌شود. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش جاری یا شروع یک نمایش سفارشی. |
| `StartMacro` | اجرای یک ماکرو. |
| `StartProgram` | اجرای یک برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن یک فایل یا ارائه دیگر؛ به‌صورت جداگانه از URLهای وب بررسی شود. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری، یا عمل ناشناخته‌ای که نیاز به بررسی دارد. |

مقاصد خارجی را از [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) و مقاصد داخلی خاص را از [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/) بخوانید. اقدامات داخلی و دستورات پیش‌ساخته ممکن است URL خارجی نداشته باشند؛ یک URL خالی به این معنی نیست که کانتینر عملی ندارد. مقدار بازگردانده‌شده توسط [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) را زمانی که با URL نرمال‌شده متفاوت است، حفظ کنید و ابزارنمایی بازگردانده‌شده توسط [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) را در صورت موجود بودن شامل کنید.

### **گزارش، پاک‌سازی و تأیید لینک‌فراکن‌ها**

این مثال ارائه‌ای را که در مثال قبلی ایجاد شد باز می‌کند و برای هر عمل یک رکورد JSON می‌نویسد. از [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) برای جمع‌آوری کانتینرها در اسلایدهای معمولی، مسترها، طرح‌بندی‌ها و یادداشت‌ها (از جمله مسترهای یادداشت و برگه‌اطلاعات در صورت موجود بودن) استفاده می‌کند. برای شمارش هر کانتینر یک بار از برابری ارجاع استفاده می‌کند، سیاست زیر را اعمال می‌کند و پس از ذخیره ارائه، آن را دوباره باز می‌کند تا هر دو عمل کلیک و ماوس‌اور را بررسی کند.

گزارش، یک ایندکس اسلاید یک‌پایه و [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) را در صورت موجود بودن ثبت می‌کند. [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) اسلاید صاحب را برای کانتینرهای پشتیبانی‌شده فراهم می‌کند. مسترها، طرح‌بندی‌ها و یادداشت‌ها ایندکس اسلاید معمولی ندارند و با محدوده خود شناسایی می‌شوند. کانتینرهای شکل و کانتینرهای قالب‌بندی بخش متن به‌صورت جداگانه برچسب‌گذاری می‌شوند؛ سایر انواع کانتینر نام نوع زمان اجرا خود را حفظ می‌کنند. هر کانتینر یک شناسه محلی در گزارش دریافت می‌کند تا دو عمل آن قابل همبستگی باشد. گزارش انواع عمل را به‌عنوان ثابت‌های عددی تعریف‌شده توسط شمارش‌گر (enumeration) PHP ذخیره می‌کند.

این سیاست کاربردی به‌صورت عمدی محدود است و فقط URLهای HTTPS مطلق و هدف‌های اسلاید داخلی معتبر را می‌پذیرد. ماکروها، برنامه‌ها، اقدامات فایل، سایر اقدامات اسلایدشو، عملکردهای ناشناخته و دیگر طرح‌های URL را رد می‌کند. این ردها تصمیمات سیاستی هستند، نه حکم ایمنی Aspose.Slides. فقط HTTPS به تنهایی اعتماد را تضمین نمی‌کند: فهرست‌های سفید میزبان و سایر بررسی‌ها را برای برنامه خود اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال متادیتا را بدون دنبال کردن لینک‌ها یا اجرای عملیات‌ها حسابرسی می‌کند.

برای اصلاح، [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) کانتینر از [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/), و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی ممنوع با یک صفحه فرود ثابت HTTPS جایگزین می‌شوند؛ کلیک‌ها و ماوس‌اورهای ممنوع دیگر به‌صورت مستقل حذف می‌شوند. برای حذف تمام تخلفات سیاست، `$replaceExternalClicks` را به `false` تنظیم کنید. قبل از استقرار، یک صفحه جایگزین متعلق به برنامه انتخاب کنید.

پرچم خروجی گزارش از سیاست مرور PDF محتاطانه استفاده می‌کند: اعمال ماوس‑اور و هر چیز غیر از لینک خارجی یا پرش اسلاید خاص را به‌عنوان احتمالا پشتیبانی‌نشده علامت‌گذاری می‌کند. این یک نکته مرور است، نه آزمون توانایی یا تضمینی که لینک‌های بدون علامت هنگام خروجی‌گیری باقی می‌مانند. خروجی‌های PDF [PDF](/slides/fa/php-java/convert-powerpoint-to-pdf/) و HTML [HTML](/slides/fa/php-java/convert-powerpoint-to-html/) ممکن است لینک‌فراکن‌ها را حفظ کنند، بسته به عمل، گزینه‌های خروجی و نمایشگر. تصاویر رستری [images](/slides/fa/php-java/convert-powerpoint-to-png/) و [video](/slides/fa/php-java/convert-powerpoint-to-video/) نمی‌توانند لینک‌های تعاملی را حفظ کنند؛ هنگام حسابرسی برای این خروجی‌ها، تمام اعمال را علامت‌گذاری کنید.

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

با ورودی ایجاد شده در بالا، گزارش شامل پنج ردیف عمل است. لینک ماوس‑اور فایل و کلیک ماکرو حذف شده‌اند، در حالی که لینک‌های HTTPS و ناوبری داخلی اسلاید باقی می‌مانند. تأیید صفر عمل ممنوع را چاپ می‌کند. ورودی شامل یک URL کلیک خارجی ممنوع نیز مسیر جایگزینی را آزمایش می‌کند. یک کانتینر با کلیک مجاز و ماوس‑اور ممنوع عمل کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی با [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) متفاوت است؛ که هر دو نوع فعال‌سازی را در تمام محدوده انتخاب‌شده صرف‌نظر از سیاست حذف می‌کند. تأیید در این جا تنها اقدامات لینک‌فراکن را بررسی می‌کند؛ پروژه‌های VBA جاسازی‌شده، اشیاء OLE یا سایر محتوای فعال را حذف نمی‌کند و فایل‌های خروجی PDF یا HTML را اعتبارسنجی نمی‌کند.

## **پرسش‌های متداول**

**چگونه می‌توانم به یک بخش یا اسلاید اول آن لینک دهم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بند می‌کنند، اما یک لینک‌فراکن داخلی به یک اسلاید منفرد هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اسلاید اول آن بخش لینک دهید.

**آیا می‌توانم لینک‌فراکن را به عناصر اسلاید مستر وصل کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید مستر و طرح‌بندی از لینک‌فراکن پشتیبانی می‌کنند. لینک‌های این عناصر در طول نمایش اسلاید بر روی اسلایدهایی که از مستر یا طرح‌بندی مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا لینک‌فراکن‌ها در هنگام خروجی به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است لینک‌فراکن‌ها را حفظ کنند؛ تصاویر رستری و ویدئو نمی‌توانند. ملاحظات خروجی را در [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) ببینید.