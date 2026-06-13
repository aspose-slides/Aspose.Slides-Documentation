---
title: تبدیل ارائه‌های PowerPoint به HTML در Java
linktitle: PowerPoint به HTML
type: docs
weight: 30
url: /fa/java/convert-powerpoint-to-html/
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
- ذخیره PowerPoint به‌صورت HTML
- ذخیره ارائه به‌صورت HTML
- ذخیره اسلاید به‌صورت HTML
- ذخیره PPT به‌صورت HTML
- ذخیره PPTX به‌صورت HTML
- صدور PPT به HTML
- صدور PPTX به HTML
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به HTML در Java. از Aspose.Slides برای صدور فایل‌های PPT و PPTX، اسلایدهای انتخابی، یادداشت‌ها، قلم‌ها، تصاویر، SVG و رسانه‌ها استفاده کنید."
---
## **بررسی کلی**

Aspose.Slides for Java می‌تواند ارائه‌های PowerPoint را بدون Microsoft PowerPoint به HTML ذخیره کند. تبدیل پایه شامل یک بار بارگذاری [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) و یک فراخوانی `save` با [SaveFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) است. هنگام نیاز به کنترل چیدمان، قلم‌ها، تصاویر، یادداشت‌ها، نظرات، خروجی SVG یا منابع لینک‌شده خروجی، از [HtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmloptions/) استفاده کنید.

این راهنما بر سناریوهای عملی خروجی HTML متمرکز است:

- خروجی تمام ارائه یا اسلایدهای انتخابی.
- تولید HTML با چیدمان ثابت، پاسخگو یا مبتنی بر SVG.
- شامل کردن یادداشت‌های گوینده و نظرات.
- کنترل کیفیت تصویر و داده‌های تصویر برش‌خورده.
- جاسازی قلم‌ها یا ذخیره فایل‌های قلم به‌صورت جداگانه.
- انتخاب نحوه نوشتن و ارجاع به منابع خارجی و فایل‌های رسانه‌ای.

به‌طور پیش‌فرض، خروجی HTML یک سند HTML خودکفا تولید می‌کند که اکثر منابع درون‌گذاری شده‌اند. این برای به‌اشتراک‌گذاری یک فایل مناسب است، اما می‌تواند اندازه خروجی را افزایش دهد. برای انتشار وب، منابع خارجی، DPI تصویر کمتر و فقط جاسازی قلم‌هایی که در محیط هدف به‌صورت قابل اعتماد در دسترس نیستند را در نظر بگیرید.

## **تبدیل یک ارائه به HTML**

برای خروجی یک ارائه به HTML، آن را با [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری کنید و با [SaveFormat.Html](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) ذخیره کنید.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

این مثال یک فایل HTML می‌نویسد. شیء ارائه در بلوک `finally` از بین می‌رود که پس از خروجی‌گیری، دستگیره‌های فایل و منابع رندر را آزاد می‌کند.

## **استفاده از HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmloptions/) کلاس پیکربندی اصلی برای خروجی HTML است. تنظیمات معمول شامل:

- `SlidesLayoutOptions`: افزودن یادداشت‌ها، نظرات، برگه‌های پخش یا سایر اطلاعات چیدمان.
- `HtmlFormatter`: تغییر ساختار سند HTML یا واگذاری قالب‌بندی به یک کنترلر.
- `SlideImageFormat`: تغییر نحوه نمایش اسلایدها، به‌عنوان مثال به‌صورت SVG.
- `PicturesCompression`: کنترل DPI تصویر و اندازه خروجی.
- `DeletePicturesCroppedAreas`: نگه داشتن یا حذف داده‌های تصویر برش‌خورده.
- `SvgResponsiveLayout`: سازگار شدن محتوای SVG خروجی با محفظهٔ خود.
- `ShowHiddenSlides`: شامل کردن اسلایدهای مخفی در صورت نیاز.

بخش‌های زیر رایج‌ترین گزینه‌ها را به‌صورت جداگانه نشان می‌دهند تا بتوانید فقط گزینه‌های مورد نیاز جریان کاری خود را ترکیب کنید.

## **تبدیل اسلایدهای انتخابی به HTML**

بارگذاری `Presentation.save` که شماره اسلایدها را می‌پذیرد، موقعیت‌های اسلاید را به‌صورت 1‑مبنا استفاده می‌کند. حلقه زیر هر اسلاید را به یک فایل HTML جداگانه ذخیره می‌کند.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

از این الگو وقتی که یک وب‌سایت یا برنامه به یک صفحه HTML برای هر اسلاید نیاز دارد، استفاده کنید. اگر هر اسلاید باید همان چیدمان را داشته باشد، یک نمونهٔ [HtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmloptions/) ایجاد کنید و به هر فراخوانی `save` پاس دهید.

## **ایجاد HTML پاسخگو**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fa/java/com.aspose.slides/responsivehtmlcontroller/) خروجی HTML پاسخگو را از طریق [HtmlFormatter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmlformatter/) فراهم می‌کند. وقتی صفحهٔ خروجی باید به عرض مرورگر بهتر سازگار شود، از آن استفاده کنید.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

برای چیدمان پاسخگو مبتنی بر SVG، `SvgResponsiveLayout` را بر روی [HtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmloptions/) تنظیم کنید. این گزینه زمانی مفید است که محتوای اسلاید به‌صورت علامت‌گذاری SVG مقیاس‌پذیر خروجی داده شود.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **شامل کردن یادداشت‌های گوینده و نظرات**

از [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/notescommentslayoutingoptions/) از طریق `HtmlOptions.setSlidesLayoutOptions` برای اضافه کردن یادداشت‌های گوینده یا نظرات استفاده کنید. یادداشت‌ها و نظرات به‌صورت پیش‌فرض مخفی هستند مگر آنکه موقعیت آن‌ها را انتخاب کنید.

فرض کنید ارائه منبع شامل یادداشت‌های گوینده باشد:

![اسلاید با یادداشت‌های گوینده در PowerPoint](slide_with_notes.png)

کد زیر محتوای اسلاید را به‌همراه یادداشت‌های گوینده زیر اسلاید خروجی می‌دهد.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

HTML خروجی شامل ناحیهٔ یادداشت‌ها خواهد بود:

![خروجی HTML با اسلاید و یادداشت‌های گوینده](HTML_with_notes.png)

برای خروجی نظرات، `CommentsPosition` را تنظیم کنید، برای مثال به `CommentsPositions.Right` یا `CommentsPositions.Bottom`. اگر فقط به نظرات نیاز دارید، `NotesPosition` را حذف کنید. اگر هر دو نیاز است، هر دو ویژگی را تنظیم کنید.

## **کنترل کیفیت تصویر و نواحی برش‌خورده**

خروجی HTML می‌تواند تصاویر اسلاید را فشرده کند تا اندازه خروجی کاهش یابد. زمانی که به کیفیت تصویر بالاتر نیاز دارید، `PicturesCompression` را به مقداری از [PicturesCompression](https://reference.aspose.com/slides/fa/java/com.aspose.slides/picturescompression/) تنظیم کنید.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

به‌صورت پیش‌فرض، نواحی برش‌خوردهٔ تصاویر ممکن است از خروجی حذف شوند. داده‌های برش‌خورده را فقط وقتی نگه دارید که کاربران باید قادر به بازیابی یا بررسی آن قسمت‌های مخفی تصویر باشند. نگه داشتن آن می‌تواند اندازه HTML را افزایش دهد.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **افزودن CSS**

برای سبک‌بندی ساده، رشتهٔ CSS را به `HtmlFormatter.createDocumentFormatter` پاس دهید. این کار سند HTML پیرامون را تغییر می‌دهد در حالی که Aspose.Slides به رندر محتوای اسلاید ادامه می‌دهد.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

برای افزودن سربرگ سفارشی سند، فایل CSS لینک‌شده یا علامت‌گذاری سفارشی دور اسلایدها و اشکال، [IHtmlFormattingController](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihtmlformattingcontroller/) را پیاده‌سازی کنید و به [HtmlFormatter](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmlformatter/) با `createCustomFormatter` پاس دهید.

## **جاسازی قلم‌ها**

اگر محیط هدف ممکن است قلم‌های استفاده‌شده در ارائه نصب نباشند، با [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/java/com.aspose.slides/embedallfontshtmlcontroller/) قلم‌ها را در HTML جاسازی کنید. جاسازی وفاداری بصری را بهبود می‌بخشد اما اندازه خروجی را افزایش می‌دهد.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

قلم‌ها را فقط زمانی حذف کنید که مطمئن باشید مرورگرها یا سیستم‌های هدف آن‌ها را در دسترس دارند. برای قلم‌های برند یا قلم‌های کمتر رایج، جاسازی معمولاً ایمن‌تر است.

## **لینک کردن فایل‌های قلم به‌جای جاسازی آن‌ها**

برای کاهش اندازه فایل HTML، می‌توانید داده‌های قلم را در فایل‌های WOFF جداگانه بنویسید و قواعد `@font-face` را به HTML اضافه کنید. راهنمای زیر [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/java/com.aspose.slides/embedallfontshtmlcontroller/) را گسترش می‌دهد و `writeFont` را بازنویسی می‌کند.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

در این مثال، فایل‌های قلم در `html-output/fonts` ذخیره می‌شوند و HTML آن‌ها را با URLهایی مانند `fonts/BrandFont-normal-400.woff` ارجاع می‌دهد. اگر فایل HTML و قلم‌ها در مکان دیگری مستقر می‌شوند، `fontUrlPrefix` را طوری انتخاب کنید که با مسیر URL مستقر منطبق باشد.

## **ذخیره منابع به‌صورت خارجی**

HTML خودکفا جابجایی آسان دارد، اما منابع Base64 جاسازی‌شده می‌توانند فایل را بزرگ کنند. اگر برنامهٔ شما به فایل‌های تصویر خارجی نیاز دارد، [ILinkEmbedController](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/) را پیاده‌سازی کنید و به سازندهٔ [HtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmloptions/) پاس دهید.

هنگام بیرون‌سپاری منابع، دو مسیر را به‌طور عمدی انتخاب کنید:

- مسیر خروجی سیستم فایل، که برنامهٔ شما فایل‌های تصویر، قلم، صدا یا ویدیو تولید شده را می‌نویسد.
- مسیر URL، که مرورگر از داخل سند HTML برای بارگذاری آن فایل‌ها استفاده می‌کند.

## **خروجی فایل‌های رسانه‌ای**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fa/java/com.aspose.slides/videoplayerhtmlcontroller/) فایل‌های ویدیو و صدا را خروجی می‌دهد و HTMLی می‌نویسد که می‌تواند در مرورگر پخش شود. سازندهٔ آن شامل می‌شود:

- `path`: دایرکتوری که فایل‌های رسانه‌ای تولید شده در آن نوشته می‌شوند.
- `fileName`: نام فایل HTML که در حال تولید است.
- `baseUri`: پیشوند URI مطلق که در لینک‌های HTML به فایل‌های رسانه‌ای استفاده می‌شود.

اگر فایل HTML `html-output/presentation.html` باشد و فایل‌های رسانه‌ای در `html-output/media` ذخیره شوند، `path` باید به دایرکتوری رسانه‌ها روی دیسک اشاره کند، در حالی که `baseUri` باید همان مسیر را از دید مرورگر نشان دهد. برای پیش‌نمایش محلی می‌توانید URI `file:///` را از دایرکتوری رسانه‌ها بسازید. برای برنامهٔ مستقر، از URL مطلق دایرکتوری رسانه‌های منتشر شده استفاده کنید.

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

برای هر کار تبدیل، پوشه‌های خروجی منحصربه‌فرد استفاده کنید، به‌ویژه در برنامه‌های سرور. مسیرهای خروجی مشترک می‌توانند باعث نوشتن روی فایل‌های تبدیل‌های مختلف شوند.

## **عملکرد و مدیریت منابع**

تبدیل HTML یک عملیات رندر است، بنابراین زمان پردازش و مصرف حافظه به تعداد اسلایدها، وضوح تصویر، قلم‌ها، افکت‌ها، نمودارها و رسانه‌های جاسازی‌شده بستگی دارد. مقادیر DPI بالاتر در `PicturesCompression`، قلم‌های جاسازی‌شده، خروجی SVG و نگه داشتن نواحی برش‌خوردهٔ تصویر می‌تواند وفاداری را بهبود بخشد اما معمولاً اندازه خروجی را افزایش می‌دهد.

برای تبدیل‌های دسته‌ای:

- هر نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را بلافاصله پس از استفاده از بین ببرید.
- برای کارهای جداگانه پوشه‌های خروجی جداگانه استفاده کنید.
- از جاسازی قلم‌های عمومی مگر آنکه وفاداری به آن‌ها نیاز باشد، خودداری کنید.
- DPI تصویر را برای پیش‌نمایش یا تصویرهای بندانگشتی کاهش دهید.
- ارائهٔ منبع، HTML تولید شده و منابع خارجی را تا زمانی که مسیرهای استقرار نهایی شوند، با هم نگه دارید.

## **سؤالات متداول**

**آیا پیوندهای ابرمتن در خروجی HTML حفظ می‌شوند؟**

بله. پیوندهای ابرمتن ارائه به HTML صادر می‌شوند و زمانی که URL هدف معتبر باشد، کلیک‑پذیر می‌مانند.

**آیا می‌توانم ارائه‌ها را به‌صورت موازی به HTML تبدیل کنم؟**

بله، اما یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را بین رشته‌ها به‌اشتراک نگذارید. فایل‌های مختلف را با نمونه‌های جداگانهٔ ارائه، جریان‌های جداگانه و پوشه‌های خروجی جداگانه پردازش کنید. برای جزئیات به [راهنمای چندرشته‌ای](/slides/fa/java/multithreading/) مراجعه کنید.

**آیا شیء Presentation ایمن برای استفاده در چند رشته است؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) باید در یک رشته بارگذاری، تغییر، ذخیره و از بین برود. برای کار موازی، یک نمونهٔ مستقل برای هر رشته یا فرآیند ایجاد کنید.

**چرا فایل HTML تولیدی بزرگ است؟**

خروجی پیش‌فرض می‌تواند منابع را مستقیماً در HTML جاسازی کند. قلم‌های جاسازی‌شده، تصاویر با DPI بالا، رسانه‌ها، محتوای SVG و نواحی برش‌خوردهٔ تصویر نیز اندازه را افزایش می‌دهند. برای کاهش اندازه، از منابع خارجی استفاده کنید، قلم‌های رایج را از جاسازی حذف کنید و `PicturesCompression` را هنگامیکه خروجی کوچک‌تر مهم‌تر از حداکثر وفاداری است، کاهش دهید.

**چرا اندازه قلم در PowerPoint مانند 24 pt در HTML به 17.999819 pt تبدیل می‌شود؟**

این به‌این دلیل است که PowerPoint و HTML از مدل‌های DPI متفاوتی استفاده می‌کنند. PowerPoint اندازه متن را بر پایهٔ نقاط تایپوگرافی 72 DPI ذخیره می‌کند، در حالی که چیدمان HTML بر پایهٔ پیکسل‌های CSS در مدل 96 DPI است. هنگام خروجی Aspose.Slides به HTML، اندازه قلم بین این دو سیستم ترجمه می‌شود و اختلاف کوچک گرد شدن ممکن است رخ دهد.

این مقادیر نشانگر تغییر واقعی در اندازه بصری قلم نیستند؛ تنها اثر جانبی ریاضیاتی تبدیل معیارهای متن بین PowerPoint و HTML است.

**چگونه باید baseUri را برای خروجی رسانه‌ها انتخاب کنم؟**

`baseUri` را از دید مرورگر انتخاب کنید و به‌صورت URI مطلق پاس دهید. برای پیش‌نمایش محلی می‌توانید از مسیر خروجی با `mediaDirectory.toUri().toString()` استفاده کنید. برای استقرار، URL مطلق دایرکتوری رسانه‌های منتشر شده را به‌کار ببرید. مسیر سیستم فایل `path` و `baseUri` مرورگر نیازی به داشتن همان رشته ندارند، اما باید به همان مکان منبع اشاره کنند.

**آیا می‌توانم اسلایدهای مخفی را شامل شوم؟**

بله. وقتی اسلایدهای مخفی باید خروجی شوند، `ShowHiddenSlides` را در [HtmlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/htmloptions/) به `true` تنظیم کنید.