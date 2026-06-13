---
title: تبدیل ارائه‌های PowerPoint به HTML در PHP
linktitle: PowerPoint به HTML
type: docs
weight: 30
url: /fa/php-java/convert-powerpoint-to-html/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به HTML
- ارائه به HTML
- اسلاید به HTML
- PPT به HTML
- PPTX به HTML
- ذخیره PowerPoint به صورت HTML
- ذخیره ارائه به صورت HTML
- ذخیره اسلاید به صورت HTML
- ذخیره PPT به صورت HTML
- ذخیره PPTX به صورت HTML
- صادرات PPT به HTML
- صادرات PPTX به HTML
- PHP
- Aspose.Slides
description: "PowerPoint ارائه‌ها را به HTML در PHP تبدیل کنید. از Aspose.Slides برای صادرات فایل‌های PPT و PPTX، اسلایدهای انتخابی، یادداشت‌ها، قلم‌ها، تصاویر، SVG و رسانه‌ها استفاده کنید."
---
## **بررسی اجمالی**

Aspose.Slides برای PHP از طریق Java می‌تواند ارائه‌های PowerPoint را به صورت HTML ذخیره کند بدون نیاز به Microsoft PowerPoint. تبدیل پایه شامل بارگذاری یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) و فراخوانی `save` با [SaveFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/) است. از [HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/) وقتی نیاز به کنترل چیدمان خروجی، قلم‌ها، تصاویر، یادداشت‌ها، نظرات، خروجی SVG یا منابع پیوندی دارید، استفاده کنید.

این راهنما بر روی سناریوهای عملی صادرات HTML متمرکز است:

- صادرات کل ارائه یا اسلایدهای انتخاب‌شده.
- تولید HTML با چیدمان ثابت، واکنشگر یا مبتنی بر SVG.
- گنجاندن یادداشت‌های سخنران و نظرات.
- کنترل کیفیت تصویر و داده‌های تصویر برش‌خورده.
- درج قلم‌ها یا ذخیره جداگانه فایل‌های قلم.
- انتخاب نحوه نوشتن و ارجاع به منابع خارجی و فایل‌های رسانه‌ای.

به‌صورت پیش‌فرض، صادرات HTML یک سند HTML خودکفا تولید می‌کند که بیشتر منابع در آن جاسازی می‌شوند. این برای به‌اشتراک‌گذاری یک فایل راحت است، اما می‌تواند اندازه خروجی را افزایش دهد. برای انتشار وب، منابع خارجی، DPI تصویر کمتر و تنها درج قلم‌هایی که به‌صورت قابل اعتماد در محیط هدف موجود نیستند، در نظر بگیرید.

## **تبدیل یک ارائه به HTML**

برای صادرات یک ارائه به HTML، آن را با [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) بارگذاری کنید و با [SaveFormat.Html](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/) ذخیره کنید.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

این مثال یک فایل HTML می‌نویسد. شیء ارائه در بلوک `finally` آزاد می‌شود، که پس از صادرات دستگیره‌های فایل و منابع رندرینگ را رها می‌کند.

## **استفاده از HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/) کلاس اصلی پیکربندی برای صادرات HTML است. تنظیمات رایج شامل:

- `SlidesLayoutOptions`: یادداشت‌ها، نظرات، جزوات یا سایر اطلاعات چیدمان را اضافه می‌کند.
- `HtmlFormatter`: ساختار سند HTML را تغییر می‌دهد یا قالب‌بندی را به یک کنترلر واگذار می‌کند.
- `SlideImageFormat`: نحوه نمایش اسلایدها را تغییر می‌دهد، برای مثال به صورت SVG.
- `PicturesCompression`: DPI تصویر و اندازه خروجی را کنترل می‌کند.
- `DeletePicturesCroppedAreas`: داده‌های تصویر برش‌خورده را نگه می‌دارد یا حذف می‌کند.
- `SvgResponsiveLayout`: محتوای SVG خروجی را طوری ساز می‌کند که به کانتینر خود سازگار شود.
- `ShowHiddenSlides`: در صورت نیاز اسلایدهای مخفی را شامل می‌شود.

بخش‌های زیر گزینه‌های پرکاربرد را به‌صورت جداگانه نشان می‌دهند تا فقط گزینه‌هایی را که جریان کاری شما به آن‌ها نیاز دارد ترکیب کنید.

## **تبدیل اسلایدهای انتخاب‌شده به HTML**

بارگذاری `save` که شماره اسلایدها را می‌پذیرد، موقعیت اسلایدها را به‌صورت 1‑پایه استفاده می‌کند. حلقه زیر هر اسلاید را در یک فایل HTML جداگانه ذخیره می‌کند.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slideNumber = $slideIndex + 1;
        $slideNumbers = array($slideNumber);
        $htmlFileName = "slide-" . $slideNumber . ".html";

        $presentation->save($htmlFileName, $slideNumbers, SaveFormat::Html);
    }
} finally {
    $presentation->dispose();
}
```

از این الگو زمانی استفاده کنید که یک وب‌سایت یا برنامه به یک صفحه HTML برای هر اسلاید نیاز دارد. اگر هر اسلاید باید همان چیدمان را داشته باشد، یک نمونه [HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/) ایجاد کنید و آن را به هر فراخوانی `save` منتقل کنید.

## **ایجاد HTML واکنشگر**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fa/php-java/aspose.slides/responsivehtmlcontroller/) خروجی HTML واکنشگر را از طریق [HtmlFormatter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmlformatter/) فراهم می‌کند. هنگامی که صفحه خروجی باید بهتر به عرض مرورگر سازگار شود، از آن استفاده کنید.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $controller = new ResponsiveHtmlController();
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

برای چیدمان واکنشگر مبتنی بر SVG، `SvgResponsiveLayout` را روی [HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/) تنظیم کنید. این زمانی مفید است که محتوای اسلاید به صورت نشانه‌گذاری SVG مقیاس‌پذیر صادر می‌شود.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSvgResponsiveLayout(true);

    $presentation->save("presentation-svg-responsive.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **گنجاندن یادداشت‌های سخنران و نظرات**

از [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/notescommentslayoutingoptions/) از طریق `HtmlOptions.SlidesLayoutOptions` برای گنجاندن یادداشت‌های سخنران یا نظرات استفاده کنید. یادداشت‌ها و نظرات به‌صورت پیش‌فرض مخفی هستند مگر آنکه موقعیت آن‌ها را انتخاب کنید.

فرض کنید ارائه منبع شامل یادداشت‌های سخنران باشد:

![اسلاید با یادداشت‌های سخنران در PowerPoint](slide_with_notes.png)

کد زیر محتوای اسلاید را به همراه یادداشت‌های سخنران زیر اسلاید صادر می‌کند.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $layoutOptions = new NotesCommentsLayoutingOptions();
    $layoutOptions->setNotesPosition(NotesPositions::BottomFull);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setSlidesLayoutOptions($layoutOptions);

    $presentation->save("presentation-with-notes.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

HTML صادر شده شامل ناحیه یادداشت‌ها می‌شود:

![خروجی HTML با اسلاید و یادداشت‌های سخنران](HTML_with_notes.png)

برای صادرات نظرات، `CommentsPosition` را تنظیم کنید، برای مثال به `CommentsPositions.Right` یا `CommentsPositions.Bottom`. اگر فقط به نظرات نیاز دارید، `NotesPosition` را حذف کنید. اگر هم یادداشت‌ها و هم نظرات لازم است، هر دو ویژگی را تنظیم کنید.

## **کنترل کیفیت تصویر و نواحی برش خورده**

صادرات HTML می‌تواند تصاویر اسلاید را فشرده کند تا اندازه خروجی کاهش یابد. وقتی به کیفیت تصویر بالاتری نیاز دارید، `PicturesCompression` را به مقدار از [PicturesCompression](https://reference.aspose.com/slides/fa/php-java/aspose.slides/picturescompression/) تنظیم کنید.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setPicturesCompression(PicturesCompression::Dpi150);

    $presentation->save("presentation-dpi-150.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

به‌صورت پیش‌فرض، نواحی برش‌خورده تصاویر ممکن است از خروجی حذف شوند. داده‌های برش‌خورده را فقط زمانی نگه دارید که کاربران باید بتوانند بخش‌های تصویر مخفی را بازیابی یا بررسی کنند. نگه داشتن آن می‌تواند اندازه HTML را افزایش دهد.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $htmlOptions = new HtmlOptions();
    $htmlOptions->setDeletePicturesCroppedAreas(false);

    $presentation->save("presentation-with-cropped-areas.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

## **افزودن CSS**

برای استایل‌گذاری ساده، یک رشته CSS را به [HtmlFormatter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmlformatter/) از طریق `createDocumentFormatter` پاس دهید. این سند HTML اطراف را تغییر می‌دهد در حالی که Aspose.Slides به رندر کردن محتوای اسلاید ادامه می‌دهد.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    $showSlideTitle = true;
    $formatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter($cssRules, $showSlideTitle);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-styled.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

برای هدر سفارشی سند، فایل CSS پیوند شده یا نشانه‌گذاری سفارشی دور اسلایدها و شکل‌ها، از یک کنترلر قالب‌بندی سفارشی استفاده کنید و آن را به [HtmlFormatter](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmlformatter/) با `createCustomFormatter` پاس دهید.

## **درج قلم‌ها**

اگر محیط هدف ممکن است قلم‌های استفاده‌شده در ارائه را نصب نکرده باشد، قلم‌ها را در HTML با [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/php-java/aspose.slides/embedallfontshtmlcontroller/) درج کنید. درج کیفیت بصری را بهبود می‌بخشد اما اندازه خروجی را افزایش می‌دهد.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $arrayClass = new JavaClass("java.lang.reflect.Array");
    $stringClass = new JavaClass("java.lang.String");

    $fontNamesToExclude = $arrayClass->newInstance($stringClass, 1);
    $arrayClass->set($fontNamesToExclude, 0, new Java("java.lang.String", "Calibri"));

    $fontController = new EmbedAllFontsHtmlController(java_values($fontNamesToExclude));
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($fontController);

    $htmlOptions = new HtmlOptions();
    $htmlOptions->setHtmlFormatter($formatter);

    $presentation->save("presentation-embedded-fonts.html", SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

قلم‌ها را فقط زمانی حذف کنید که مطمئن باشید مرورگرها یا سیستم‌های هدف آن‌ها را پیشاپیش دارند. برای قلم‌های برند یا کم‌استفاده، درج معمولاً ایمن‌تر است.

## **پیوند فایل‌های قلم به‌جای درج آن‌ها**

برای کاهش اندازه فایل HTML، می‌توانید داده‌های قلم را در فایل‌های WOFF جداگانه بنویسید و قوانین `@font-face` را به HTML اضافه کنید. در PHP از طریق Java این سناریو معمولاً با یک کلاس کمکی کوچک Java که از [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/php-java/aspose.slides/embedallfontshtmlcontroller/) ارث می‌برد، داده‌های قلم را در یک پوشه خروجی می‌نویسد و قوانین `@font-face` را به HTML تولید شده تزریق می‌کند، پیاده‌سازی می‌شود. آن کلاس کمکی را کامپایل کنید، به مسیر کلاس‌های PHP Java Bridge اضافه کنید و سپس از PHP با `new Java(...)` نمونه‌سازی کنید.

هنگامی که چنین کمکی می‌سازید، دو مسیر را عمداً انتخاب کنید:

- مسیر خروجی سیستم‌فایل، که فایل‌های قلم تولید شده در آن نوشته می‌شوند.
- مسیر URL، که مرورگر از سند HTML برای بارگذاری آن فایل‌های قلم استفاده می‌کند.

## **ذخیره منابع به‌صورت خارجی**

HTML خودکفا جابجایی آسان دارد، اما منابع Base64 جاسازی شده می‌تواند فایل را بزرگ کند. اگر برنامه شما به فایل‌های تصویر خارجی نیاز دارد، یک کنترلر لینک/درج سفارشی به سازنده [HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/) ارائه دهید.

وقتی منابع را به‌صورت خارجی می‌کنید، دو مسیر را عمداً انتخاب کنید:

- مسیر خروجی سیستم‌فایل، که برنامه شما تصاویر، قلم‌ها، صدا یا ویدئوهای تولید شده را در آن می‌نویسد.
- مسیر URL، که مرورگر از سند HTML برای بارگذاری آن فایل‌ها استفاده می‌کند.

این مسیرها را با چینش استقرار خود هماهنگ نگه دارید تا HTML تولید شده پس از انتقال به سرور وب یا پوشه دیگر بتواند منابع خارجی خود را بارگذاری کند.

## **صادرات فایل‌های رسانه‌ای**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fa/php-java/aspose.slides/videoplayerhtmlcontroller/) ویدئو و صدا را صادر می‌کند و HTMLی می‌نویسد که می‌تواند در مرورگر پخش شود. سازنده آن موارد زیر را می‌گیرد:

- `path`: پوشه خروجی که توسط HTML و فایل‌های رسانه‌ای تولید شده استفاده می‌شود.
- `fileName`: نام فایل HTML که در حال تولید است.
- `baseUri`: پیشوند URI مطلق که در لینک‌های HTML به فایل‌های رسانه‌ای استفاده می‌شود.

اگر فایل HTML `html-output/presentation.html` باشد، `path` باید به `html-output` اشاره کند و `baseUri` باید از دید مرورگر به همان پوشه اشاره کند. برای پیش‌نمایش محلی می‌توانید یک URI `file:///` از پوشه خروجی بسازید. برای برنامه منتشرشده، از URL مطلق پوشه خروجی منتشر شده استفاده کنید.

```php
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "html-output";

if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$htmlFileName = "presentation.html";
$outputDirectoryPath = realpath($outputDirectory);
$outputDirectoryPath = str_replace("\\", "/", $outputDirectoryPath);
$outputBaseUri = "file:///" . ltrim($outputDirectoryPath, "/") . "/";

$presentation = new Presentation();
$videoStream = null;
try {
    $videoFilePath = getcwd() . DIRECTORY_SEPARATOR . "intro.mp4";
    $videoStream = new Java("java.io.FileInputStream", $videoFilePath);
    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addVideoFrame(20, 20, 480, 270, $video);

    $controller = new VideoPlayerHtmlController($outputDirectory, $htmlFileName, $outputBaseUri);
    $formatter = java("com.aspose.slides.HtmlFormatter")->createCustomFormatter($controller);
    $svgOptions = new SVGOptions($controller);
    $slideImageFormat = SlideImageFormat::svg($svgOptions);

    $htmlOptions = new HtmlOptions($controller);
    $htmlOptions->setHtmlFormatter($formatter);
    $htmlOptions->setSlideImageFormat($slideImageFormat);

    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . $htmlFileName;
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }

    $presentation->dispose();
}
```

از پوشه‌های خروجی استفاده کنید که برای هر کار صادراتی منحصراً منحصر به فرد باشند، به‌ویژه در برنامه‌های سرور. مسیرهای خروجی مشترک می‌تواند باعث بازنویسی فایل‌ها از تبدیل‌های مختلف شود.

## **کارایی و مدیریت منابع**

تبدیل HTML یک عملیات رندر است، بنابراین زمان پردازش و مصرف حافظه به تعداد اسلایدها، وضوح تصویر، قلم‌ها، افکت‌ها، نمودارها و رسانه‌های جاسازی‌شده بستگی دارد. مقادیر DPI بالاتر `PicturesCompression`، قلم‌های جاسازی‌شده، خروجی SVG و نگه‌داشتن نواحی برش‌خورده می‌تواند دقت را افزایش دهد اما معمولاً اندازه خروجی را بزرگ می‌کند.

برای تبدیل دسته‌ای:

- به‌سرعت هر نمونه از [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را آزاد کنید.
- برای هر کار، پوشه خروجی جداگانه استفاده کنید.
- از درج قلم‌های عمومی خودداری کنید مگر اینکه دقت بالا ضروری باشد.
- DPI تصویر را هنگام استفاده برای پیش‌نمایش یا تصویرهای کوچک کاهش دهید.
- تا زمان نهایی شدن مسیرهای استقرار، ارائه منبع، HTML تولید شده و منابع خارجی را همراه هم نگه دارید.

## **FAQ**

**آیا پیوندهای هایپرلینک در خروجی HTML حفظ می‌شوند؟**

بله. پیوندهای هایپرلینک ارائه به HTML صادر می‌شوند و زمانی که URL هدف معتبر باشد، قابل کلیک باقی می‌مانند.

**آیا می‌توانم ارائه‌ها را به صورت همزمان به HTML تبدیل کنم؟**

بله، اما یک نمونه [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) را بین نخ‌ها به اشتراک نگذارید. فایل‌های مختلف را با نمونه‌های ارائه جداگانه، جریان‌های جداگانه و پوشه‌های خروجی جداگانه پردازش کنید.

**آیا شیء Presentation ایمن برای استفاده در چندین نخ است؟**

نه. یک نمونه واحد [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) باید در یک نخ بارگذاری، اصلاح، ذخیره و آزاد شود. برای کار موازی، یک نمونه مستقل برای هر نخ یا فرآیند ایجاد کنید.

**چرا فایل HTML تولید شده بزرگ است؟**

صادرات پیش‌فرض می‌تواند منابع را مستقیماً در HTML جاسازی کند. قلم‌های جاسازی‌شده، تصاویر با DPI بالا، رسانه‌ها، محتوای SVG و نگه‌داشتن نواحی برش‌خورده تصویر نیز اندازه را افزایش می‌دهند. برای کاهش اندازه، از منابع خارجی استفاده کنید، قلم‌های رایج را از درج حذف کنید و `PicturesCompression` را هنگام نیاز به خروجی کوچکتر کاهش دهید.

**چرا اندازه قلم در PowerPoint مانند 24 pt در HTML به 17.999819 pt تبدیل می‌شود؟**

این می‌تواند به دلیل مدل‌های DPI متفاوت بین PowerPoint و HTML باشد. PowerPoint اندازه‌های متن را بر پایه نقاط تایپوگرافی با 72 DPI ذخیره می‌کند، در حالی که چیدمان HTML بر پایه پیکسل‌های CSS در مدل 96 DPI است. زمانی که Aspose.Slides ارائه را به HTML صادر می‌کند، اندازه قلم بین این سیستم‌ها ترجمه می‌شود و تبدیل ممکن است تفاوت‌های رند کردن کوچکی ایجاد کند.

این مقادیر نشان‌دهنده تغییر واقعی در اندازه ظاهری قلم نیستند؛ فقط اثر جانبی ریاضیاتی تبدیل معیارهای متن بین PowerPoint و HTML است.

**چگونه باید baseUri را برای صادرات رسانه انتخاب کنم؟**

`baseUri` را از دید مرورگر انتخاب کرده و به صورت URI مطلق پاس دهید. برای پیش‌نمایش محلی می‌توانید آن را از پوشه خروجی با یک URI فایل Java استخراج کنید. برای استقرار، از URL مطلق پوشه رسانه‌ای منتشر شده استفاده کنید. مسیر سیستم‌فایل `path` و `baseUri` مرورگر لازم نیست یک رشته یکسان باشند، اما باید به همان مکان منبع اشاره داشته باشند.

**آیا می‌توانم اسلایدهای مخفی را شامل شوم؟**

بله. وقتی اسلایدهای مخفی باید صادر شوند، `ShowHiddenSlides` را بر روی `true` در [HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/) تنظیم کنید.