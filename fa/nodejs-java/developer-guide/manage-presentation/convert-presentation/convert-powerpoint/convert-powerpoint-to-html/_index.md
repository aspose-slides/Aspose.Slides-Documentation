---
title: تبدیل ارائه‌های PowerPoint به HTML در Node.js
linktitle: PowerPoint به HTML
type: docs
weight: 30
url: /fa/nodejs-java/convert-powerpoint-to-html/
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
- ذخیره PowerPoint به عنوان HTML
- ذخیره ارائه به عنوان HTML
- ذخیره اسلاید به عنوان HTML
- ذخیره PPT به عنوان HTML
- ذخیره PPTX به عنوان HTML
- خروجی PPT به HTML
- خروجی PPTX به HTML
- Node.js
- JavaScript
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به HTML در Node.js. از Aspose.Slides برای Node.js از طریق Java استفاده کنید تا فایل‌های PPT و PPTX، اسلایدهای انتخابی، یادداشت‌ها، فونت‌ها، تصاویر، SVG و رسانه‌ها را صادر کنید."
---
## **نمای کلی**

Aspose.Slides for Node.js via Java می‌تواند ارائه‌های PowerPoint را به صورت HTML ذخیره کند بدون نیاز به Microsoft PowerPoint. تبدیل پایه شامل یک بار بارگذاری [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) و یک فراخوانی `save` با [SaveFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) است. از [HtmlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmloptions/) استفاده کنید وقتی نیاز به کنترل چیدمان، قلم‌ها، تصاویر، یادداشت‌ها، نظرات، خروجی SVG یا منابع لینک‌شدهٔ صادر شده دارید.

این راهنما بر سناریوهای عملی خروجی‌گیری HTML متمرکز است:

- صادَر کردن یک ارائهٔ کامل یا اسلایدهای انتخابی.
- تولید HTML با چیدمان ثابت، واکنش‌گرا یا مبتنی بر SVG.
- شامل کردن یادداشت‌های سخنران و نظرات.
- کنترل کیفیت تصویر و داده‌های تصویر برش‌خورده.
- درج فونت‌ها یا ذخیرهٔ فایل‌های فونت به‌صورت جداگانه.
- انتخاب نحوهٔ نوشتن و ارجاع به منابع خارجی و فایل‌های رسانه‌ای.

به‌صورت پیش‌فرض، خروجی HTML یک سند HTML خوددار ایجاد می‌کند که اکثر منابع درون‌فرمت شده‌اند. این برای به‌اشتراک‌گذاری یک فایل راحت است، اما می‌تواند حجم خروجی را افزایش دهد. برای انتشار وب، استفاده از منابع خارجی، کاهش DPI تصویر، و صرف‌نظر از درج فونت‌هایی که به‌طور قابل اعتمادی در محیط هدف موجود هستند، را در نظر بگیرید.

## **تبدیل یک ارائه به HTML**

برای خروجی‌گیری یک ارائه به HTML، آن را با [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بارگذاری کنید و با [SaveFormat.Html](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) ذخیره کنید.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

این مثال یک فایل HTML می‌نویسد. شیء presentation در بلوک `finally` آزاد می‌شود، که پس از خروجی‌گیری دستگیره‌های فایل و منابع رندر را آزاد می‌کند.

## **استفاده از HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmloptions/) کلاس اصلی پیکربندی برای خروجی‌گیری HTML است. تنظیمات رایج شامل:

- `SlidesLayoutOptions`: یادداشت‌ها، نظرات، جزوه‌ها یا سایر اطلاعات چیدمان را اضافه می‌کند.
- `HtmlFormatter`: ساختار سند HTML را تغییر می‌دهد یا قالب‌بندی را به یک کنترل‌کننده واگذار می‌کند.
- `SlideImageFormat`: نحوهٔ نمایش اسلایدها را تغییر می‌دهد، به‌عنوان مثال به عنوان SVG.
- `PicturesCompression`: DPI تصویر و اندازهٔ خروجی را کنترل می‌کند.
- `DeletePicturesCroppedAreas`: داده‌های تصویر برش‌خورده را نگه می‌دارد یا حذف می‌کند.
- `SvgResponsiveLayout`: محتوای SVG صادرشده را طوری تنظیم می‌کند که با کانتینر خود سازگار باشد.
- `ShowHiddenSlides`: در صورت نیاز اسلایدهای مخفی را شامل می‌شود.

بخش‌های زیر رایج‌ترین گزینه‌ها را به‌صورت جداگانه نشان می‌دهند تا فقط آن‌هایی را که جریان کاری شما نیاز دارد ترکیب کنید.

## **تبدیل اسلایدهای انتخابی به HTML**

بارگذاری `Presentation.save` که شماره اسلایدها را می‌پذیرد، از موقعیت‌های اسلاید 1‑مبنا استفاده می‌کند. حلقهٔ زیر هر اسلاید را به یک فایل HTML جداگانه ذخیره می‌کند.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

از این الگو زمانی استفاده کنید که یک وب‌سایت یا برنامه به یک صفحهٔ HTML برای هر اسلاید نیاز دارد. اگر هر اسلاید باید همان چیدمان را داشته باشد، یک نمونهٔ [HtmlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmloptions/) ایجاد کنید و آن را به هر فراخوانی `save` بدهید.

## **ایجاد HTML واکنش‌گرا**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/responsivehtmlcontroller/) خروجی HTML واکنش‌گرا را از طریق [HtmlFormatter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmlformatter/) فراهم می‌کند. زمانی که صفحهٔ صادرشده باید بهتر به عرض مرورگر سازگار شود، از آن استفاده کنید.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

برای چیدمان واکنش‌گرا مبتنی بر SVG، `SvgResponsiveLayout` را روی [HtmlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmloptions/) تنظیم کنید. این برای زمانی مفید است که محتوای اسلاید به‌صورت نشانه‌گذاری SVG مقیاس‌پذیر صادر شود.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **شامل کردن یادداشت‌های سخنران و نظرات**

از [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notescommentslayoutingoptions/) از طریق `HtmlOptions.setSlidesLayoutOptions` برای افزودن یادداشت‌های سخنران یا نظرات استفاده کنید. یادداشت‌ها و نظرات به‌صورت پیش‌فرض مخفی هستند مگر اینکه موقعیت آن‌ها را انتخاب کنید.

فرض کنید ارائهٔ منبع شامل یادداشت‌های سخنران باشد:

![اسلاید با یادداشت‌های سخنران در PowerPoint](slide_with_notes.png)

کد زیر محتوای اسلاید را به‌همراه یادداشت‌های سخنران در زیر اسلاید صادر می‌کند.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

خروجی HTML شامل ناحیهٔ یادداشت‌ها است:

![خروجی HTML با اسلاید و یادداشت‌های سخنران](HTML_with_notes.png)

برای صدور نظرات، `CommentsPosition` را تنظیم کنید، برای مثال به `CommentsPositions.Right` یا `CommentsPositions.Bottom`. اگر فقط به نظرات نیاز دارید، `NotesPosition` را حذف کنید. اگر به هر دو نیاز دارید، هر دو ویژگی را تنظیم کنید.

## **کنترل کیفیت تصویر و نواحی برش‌خورده**

خروجی HTML می‌تواند تصاویر اسلاید را برای کاهش حجم فشرده‌کند. وقتی به کیفیت تصویر بالاتر نیاز دارید، `PicturesCompression` را به مقدار دلخواه از [PicturesCompression](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturescompression/) تنظیم کنید.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

به‌صورت پیش‌فرض، نواحی برش‌خوردهٔ تصاویر ممکن است از خروجی حذف شوند. داده‌های برش‌خورده را فقط زمانی نگه دارید که کاربران باید بتوانند بخش‌های تصویر مخفی را بازسازی یا بررسی کنند. نگه داشتن آن می‌تواند حجم HTML را افزایش دهد.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **افزودن CSS**

برای استایل ساده، یک رشتهٔ CSS را به `HtmlFormatter.createDocumentFormatter` بدهید. این سند HTML اطراف را تغییر می‌دهد در حالی که Aspose.Slides به رندر محتوای اسلاید ادامه می‌دهد.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

برای هدر سند سفارشی، فایل CSS لینک‌شده یا نشانه‌گذاری سفارشی دور اسلایدها و اشکال، از [HtmlFormatter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmlformatter/) همراه با یک کنترل‌کنندهٔ قالب‌بندی استفاده کنید.

## **درج فونت‌ها**

اگر محیط هدف ممکن است فونت‌های ارائه نصب نشده باشند، با [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) فونت‌ها را در HTML درج کنید. درج باعث بهبود وفاداری بصری می‌شود اما حجم خروجی را افزایش می‌دهد.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

فقط زمانی فونت‌ها را حذف کنید که مطمئن باشید مرورگرها یا سیستم‌های هدف آن‌ها را در دسترس دارند. برای فونت‌های برند یا کمتر رایج، درج معمولاً ایمن‌تر است.

## **پیوند فایل‌های فونت به‌جای درج آن‌ها**

برای کاهش حجم فایل HTML، می‌توانید داده‌های فونت را به فایل‌های جداگانهٔ WOFF بنویسید و قوانین `@font-face` را به HTML اضافه کنید. در Node.js via Java این سناریو معمولاً با یک کلاس کمکی جاوا کوچک که از [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/embedallfontshtmlcontroller/) ارث‌بری می‌کند، پیاده‌سازی می‌شود؛ این کلاس بایت‌های فونت را به یک پوشهٔ خروجی می‌نویسد و قوانین `@font-face` را به HTML تولید شده تزریق می‌کند. آن کمکی را کامپایل کنید، به مسیر کلاس‌پث ماژول Node.js اضافه کنید و سپس با `java.newInstanceSync` از جاوااسکریپت نمونه‌سازی کنید.

هنگام ساخت چنین کمکی، دو مسیر را به‌دقت انتخاب کنید:

- مسیر خروجی سیستم‌فایل که در آن فایل‌های فونت تولید می‌شوند.
- مسیر URL که مرورگر از سند HTML برای بارگذاری آن فایل‌های فونت استفاده می‌کند.

## **ذخیره منابع به‌صورت خارجی**

HTML خوددار جابجایی آسان دارد، اما منابع Base64 جاسازی‌شده می‌توانند حجم فایل را زیاد کنند. اگر برنامهٔ شما به فایل‌های تصویر، فونت، صدا یا ویدیو خارجی نیاز دارد، از یک کنترل‌کنندهٔ خروجی استفاده کنید که منابع را در یک پوشهٔ انتخابی می‌نویسد و URL‌های قابل مشاهده برای مرورگر تولید می‌کند. مسیر سیستم‌فایل و مسیر URL را متناسب با طرح استقرارتان هم‌راستا نگه دارید.

## **صدور فایل‌های رسانه‌ای**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) ویدیو و صدا را صادر می‌کند و HTMLی می‌نویسد که می‌تواند آن‌ها را در مرورگر پخش کند. سازندهٔ آن پارامترهای زیر را دریافت می‌کند:

- `path`: پوشه‌ای که فایل‌های رسانه‌ای تولید‌شده در آن نوشته می‌شوند.
- `fileName`: نام فایل HTML که در حال تولید است.
- `baseUri`: پیشوند URI مطلقی که در لینک‌های HTML به فایل‌های رسانه‌ای استفاده می‌شود.

اگر فایل HTML `html-output/presentation.html` باشد و فایل‌های رسانه‌ای در `html-output/media` ذخیره شوند، `path` باید به پوشهٔ رسانه‌ای روی دیسک اشاره کند، در حالی که `baseUri` باید همان پوشه را از دید مرورگر نشان دهد. برای پیش‌نمایش محلی می‌توانید یک URI `file:///` از پوشهٔ رسانه بسازید. برای برنامهٔ مستقر، از URL مطلق پوشهٔ رسانه منتشر شده استفاده کنید.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

برای هر کار صادرات مسیرهای خروجی منحصربه‌فرد استفاده کنید، به‌ویژه در برنامه‌های سرور. مسیرهای خروجی مشترک می‌توانند باعث بازنویسی فایل‌های تبدیل‌های مختلف شوند.

## **عملکرد و مدیریت منابع**

تبدیل HTML یک عملیات رندر است، بنابراین زمان پردازش و استفاده از حافظه به تعداد اسلایدها، وضوح تصویر، فونت‌ها، افکت‌ها، نمودارها و رسانه‌های جاسازی‌شده وابسته است. مقادیر DPI بالاتر در `PicturesCompression`، فونت‌های جاسازی‌شده، خروجی SVG و نگه‌داشتن نواحی برش‌خورده می‌توانند وفاداری را بهبود بخشند اما معمولاً حجم خروجی را افزایش می‌دهند.

برای تبدیل دسته‌ای:

- هر نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) را بلافاصله آزاد کنید.
- برای کارهای مختلف پوشه‌های خروجی جداگانه استفاده کنید.
- مگر اینکه وفاداری نیاز داشته باشد، از درج فونت‌های رایج خودداری کنید.
- وقتی HTML برای پیش‌نمایش یا تصاویر بندانگشتی است، DPI تصویر را کاهش دهید.
- تا زمان نهایی شدن مسیرهای استقرار، ارائهٔ منبع، HTML تولیدی و منابع خارجی را همراه هم نگه دارید.

## **سوالات متداول**

**آیا پیوندهای هیپرمتن در خروجی HTML حفظ می‌شوند؟**

بله. پیوندهای ارائه به HTML صادر می‌شوند و وقتی URL مقصد معتبر باشد، کلیک‌پذیر می‌مانند.

**آیا می‌توانم ارائه‌ها را به‌صورت موازی به HTML تبدیل کنم؟**

بله، اما یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) را بین کارگرها به اشتراک نگذارید. فایل‌های مختلف را با نمونه‌های ارائهٔ جداگانه، جریان‌های جداگانه و پوشه‌های خروجی جداگانه پردازش کنید. برای جزئیات به [راهنمای چندنخی](/slides/fa/nodejs-java/multithreading/) مراجعه کنید.

**آیا شیء Presentation ایمن برای استفاده در چندنخ است؟**

خیر. یک نمونهٔ واحد [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) باید در یک کارگر بارگذاری، ویرایش، ذخیره و آزاد شود. برای کارهای موازی، یک نمونهٔ مستقل برای هر کارگر یا فرآیند ایجاد کنید.

**چرا فایل HTML تولید شده بزرگ است؟**

خروجی پیش‌فرض می‌تواند منابع را مستقیماً در HTML جاسازی کند. فونت‌های جاسازی‌شده، تصاویر با DPI بالا، رسانه‌ها، محتوای SVG و نگه‌داشتن نواحی برش‌خورده نیز حجم را افزایش می‌دهند. برای کاهش حجم، از منابع خارجی استفاده کنید، فونت‌های رایج را از درج حذف کنید و `PicturesCompression` را کاهش دهید وقتی که خروجی کوچک‌تر نسبت به حداکثر وفاداری مهم‌تر است.

**چرا اندازهٔ فونت PowerPoint مانند 24 pt در HTML به 17.999819 pt تبدیل می‌شود؟**

این به دلیل استفاده از مدل‌های DPI متفاوت بین PowerPoint و HTML است. PowerPoint اندازهٔ متن را بر مبنای نقاط تایپوگرافی با 72 DPI ذخیره می‌کند، در حالی که چیدمان HTML بر پایه پیکسل‌های CSS در مدل 96 DPI است. وقتی Aspose.Slides یک ارائه را به HTML صادر می‌کند، اندازهٔ فونت بین این دو سیستم ترجمه می‌شود و ممکن است اختلافات کوچک گرد شدن ایجاد کند.

این مقادیر نشانگر تغییر واقعی در ظاهر فونت نیستند؛ فقط اثر جانبی ریاضی تبدیل معیارهای متن بین PowerPoint و HTML است.

**چگونه باید baseUri را برای خروجی رسانه‌ها انتخاب کنم؟**

`baseUri` را از دید مرورگر انتخاب کنید و به‌صورت URI مطلق پاس دهید. برای پیش‌نمایش محلی می‌توانید آن را از پوشهٔ خروجی با یک URI `file:///` استخراج کنید. برای استقرار، از URL مطلق پوشهٔ رسانهٔ منتشر شده استفاده کنید. مسیر سیستم‌فایل `path` و `baseUri` مرورگر لازم نیست دقیقاً یک رشته باشند، اما باید به یک مکان منبع اشاره کنند.

**آیا می‌توانم اسلایدهای مخفی را شامل کنم؟**

بله. وقتی اسلایدهای مخفی باید صادر شوند، `ShowHiddenSlides` را روی `true` در [HtmlOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/htmloptions/) تنظیم کنید.