---
title: تبدیل ارائه‌های PowerPoint به HTML در Android
linktitle: PowerPoint به HTML
type: docs
weight: 30
url: /fa/androidjava/convert-powerpoint-to-html/
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
- صادرات PPT به HTML
- صادرات PPTX به HTML
- Android
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به HTML در Android. از Aspose.Slides برای Android از طریق Java برای صادرات فایل‌های PPT و PPTX، اسلایدهای انتخابی، یادداشت‌ها، قلم‌ها، تصاویر، SVG و رسانه‌ها استفاده کنید."
---
## **بررسی کلی**

Aspose.Slides برای Android از طریق Java می‌تواند ارائه‌های PowerPoint را به‌صورت HTML ذخیره کند بدون نیاز به Microsoft PowerPoint. تبدیل پایه شامل یک بارگذاری واحد از [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) و یک فراخوانی `save` با [SaveFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/) است. وقتی نیاز به کنترل چیدمان خروجی، قلم‌ها، تصاویر، یادداشت‌ها، نظرات، خروجی SVG یا منابع پیوندی دارید، از [HtmlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/htmloptions/) استفاده کنید.

این راهنما بر سناریوهای عملی صادر کردن HTML متمرکز است:

- صادر کردن کل ارائه یا اسلایدهای انتخابی.
- تولید HTML با چیدمان ثابت، واکنش‌گرا یا مبتنی بر SVG.
- شامل کردن یادداشت‌های گوینده و نظرات.
- کنترل کیفیت تصویر و داده‌های تصویر بریده‌شده.
- جاسازی قلم‌ها یا ذخیرهٔ فایل‌های قلم به‌صورت جداگانه.
- انتخاب نحوه نوشتن و ارجاع به منابع خارجی و فایل‌های رسانه‌ای.

به‌صورت پیش‌فرض، صادرات HTML یک سند HTML خود-مستقل تولید می‌کند که بیشتر منابع درون‌خط (embedded) هستند. این برای به‌اشتراک‌گذاری یک فایل مناسب است، اما می‌تواند اندازه خروجی را افزایش دهد. برای انتشار وب، به استفاده از منابع خارجی، کاهش DPI تصویر و فقط جاسازی قلم‌هایی که به‌طور قابل‌اعتمادی در محیط هدف موجود نیستند، فکر کنید.

## **تبدیل یک ارائه به HTML**

برای صادر کردن یک ارائه به HTML، آن را با [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگذاری کنید و با [SaveFormat.Html](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/) ذخیره کنید.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

این مثال یک فایل HTML می‌نویسد. شیء presentation در بلوک `finally` آزاد می‌شود که دستگیره‌های فایل و منابع رندر را پس از صادرات آزاد می‌کند.

## **استفاده از HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/htmloptions/) کلاس اصلی پیکربندی برای صادرات HTML است. تنظیمات متداول شامل:

- `SlidesLayoutOptions`: افزودن یادداشت‌ها، نظرات، جزوه‌ها یا سایر اطلاعات چیدمان.
- `HtmlFormatter`: تغییر ساختار سند HTML یا واگذاری قالب‌بندی به یک کنترلر.
- `SlideImageFormat`: تغییر نحوهٔ نمایش اسلایدها، به‌عنوان مثال به‌صورت SVG.
- `PicturesCompression`: کنترل DPI تصویر و اندازه خروجی.
- `DeletePicturesCroppedAreas`: نگه داشتن یا حذف داده‌های تصویر بریده‌شده.
- `SvgResponsiveLayout`: سازگار کردن محتوای SVG خروجی با محفظهٔ خود.
- `ShowHiddenSlides`: شامل کردن اسلایدهای مخفی در صورت نیاز.

بخش‌های زیر رایج‌ترین گزینه‌ها را به صورت جداگانه نشان می‌دهند تا فقط آن‌هایی را که گردش کار شما به آن نیاز دارد ترکیب کنید.

## **صادرات اسلایدهای انتخابی به HTML**

بارگذاری `Presentation.save` که شماره اسلایدها را می‌پذیرد، موقعیت‌های اسلاید را بر پایهٔ 1 استفاده می‌کند. حلقهٔ زیر هر اسلاید را به یک فایل HTML جداگانه ذخیره می‌کند.

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

از این الگو زمانی استفاده کنید که یک وب‌سایت یا برنامه به یک صفحه HTML برای هر اسلاید نیاز دارد. اگر هر اسلاید باید همان چیدمان را داشته باشد، یک شیء [HtmlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/htmloptions/) ایجاد کنید و آن را به هر فراخوانی `save` پاس دهید.

## **ایجاد HTML واکنش‌گرا**

[ResponsiveHtmlController](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/responsivehtmlcontroller/) خروجی HTML واکنش‌گرا را از طریق [HtmlFormatter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/htmlformatter/) فراهم می‌کند. وقتی صفحهٔ صادر شده باید بهتر با عرض مرورگر سازگار شود، از آن استفاده کنید.

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

برای چیدمان واکنش‌گرا مبتنی بر SVG، `SvgResponsiveLayout` را روی [HtmlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/htmloptions/) تنظیم کنید. این زمانی مفید است که محتوای اسلاید به‌صورت نشانه‌گذاری SVG مقیاس‌پذیر صادر شده باشد.

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

از [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/notescommentslayoutingoptions/) از طریق `HtmlOptions.SlidesLayoutOptions` برای شامل کردن یادداشت‌های گوینده یا نظرات استفاده کنید. یادداشت‌ها و نظرات به‌صورت پیش‌فرض مخفی هستند مگر اینکه موقعیت آن‌ها را انتخاب کنید.

فرض کنید ارائه منبع شامل یادداشت‌های گوینده باشد:

![اسلاید با یادداشت‌های گوینده در PowerPoint](slide_with_notes.png)

کد زیر محتوای اسلاید را همراه با یادداشت‌های گوینده زیر اسلاید صادر می‌کند.

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

HTML صادر شده شامل ناحیهٔ یادداشت‌ها می‌شود:

![خروجی HTML با اسلاید و یادداشت‌های گوینده](HTML_with_notes.png)

برای صادر کردن نظرات، `CommentsPosition` را تنظیم کنید، به‌عنوان مثال به `CommentsPositions.Right` یا `CommentsPositions.Bottom`. اگر فقط به نظرات نیاز دارید، `NotesPosition` را حذف کنید. اگر به هر دو نیاز دارید، هر دو خصوصیت را تنظیم کنید.

## **کنترل کیفیت تصویر و نواحی بریده‌شده**

صادرات HTML می‌تواند تصاویر اسلاید را برای کاهش اندازه خروجی فشرده کند. وقتی به کیفیت بالاتر تصویر نیاز دارید، `PicturesCompression` را به مقدار مناسب از [PicturesCompression](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/picturescompression/) تنظیم کنید.

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

به‌صورت پیش‌فرض، نواحی بریده‌شدهٔ تصاویر ممکن است از خروجی حذف شوند. فقط زمانی داده‌های بریده‌شده را نگه دارید که کاربران باید بتوانند آن بخش‌های پنهان تصویر را بازیابی یا بررسی کنند. نگه داشتن آن می‌تواند اندازهٔ HTML را افزایش دهد.

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

برای استایل‌گذاری ساده، یک رشتهٔ CSS را به `HtmlFormatter.createDocumentFormatter` پاس دهید. این کار سند HTML پیرامونی را تغییر می‌دهد در حالی‌که Aspose.Slides به رندر محتوی اسلاید ادامه می‌دهد.

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

برای سربرگ سند سفارشی، یک فایل CSS پیوندی یا نشانه‌گذاری سفارشی دور اسلایدها و اشکال، پیاده‌سازی [IHtmlFormattingController](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihtmlformattingcontroller/) را انجام دهید و آن را به [HtmlFormatter](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/htmlformatter/) با `createCustomFormatter` پاس کنید.

## **جاسازی قلم‌ها**

اگر محیط هدف ممکن است قلم‌های ارائه نصب نشده باشند، قلم‌ها را در HTML با [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) جاسازی کنید. جاسازی بهبود وفاداری بصری می‌دهد اما اندازه خروجی را افزایش می‌دهد.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial", "Calibri" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

قلم‌ها را فقط زمانی حذف کنید که مطمئن هستید مرورگرها یا سیستم‌های هدف آن‌ها را در اختیار دارند. برای قلم‌های برند یا قلم‌های کمتر رایج، معمولا جاسازی امن‌تر است.

## **پیوند به فایل‌های قلم به‌جای جاسازی آن‌ها**

برای کاهش اندازهٔ فایل HTML، می‌توانید داده‌های قلم را به فایل‌های جداگانهٔ WOFF بنویسید و قواعد `@font-face` را به HTML اضافه کنید. کد کمکی زیر [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/embedallfontshtmlcontroller/) را گسترش می‌دهد و `writeFont` را بازنویسی می‌کند.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final String fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            String fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";
        
        File dirs = new File(fontOutputDirectory);
        dirs.mkdirs();
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
            String fontFilePath = fontOutputDirectory + "/" + fontFileName;

            FileOutputStream fos = new FileOutputStream(fontFilePath);
            fos.write(fontData);
            fos.close();

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

String outputDirectory = System.getProperty("user.dir") + "/html-output";
String fontsDirectory = outputDirectory + "/fonts";
File dir = new File("path/to/folder");
dir.mkdir();

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    String htmlFilePath = outputDirectory + "/presentation.html";
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

در این مثال، فایل‌های قلم در `html-output/fonts` ذخیره می‌شوند و HTML با آدرس‌هایی مانند `fonts/BrandFont-normal-400.woff` به آن‌ها ارجاع می‌دهد. اگر فایل HTML و قلم‌ها در مکان دیگری مستقر شوند، `fontUrlPrefix` را طوری انتخاب کنید که با مسیر URL منتشر شده مطابقت داشته باشد.

## **ذخیرهٔ منابع به‌صورت خارجی**

HTML خود-مستقل جابجایی آسانی دارد، اما منابع Base64 جاسازی‌شده می‌توانند فایل را بزرگ کنند. اگر برنامهٔ شما به فایل‌های تصویری خارجی نیاز دارد، [ILinkEmbedController](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilinkembedcontroller/) را پیاده‌سازی کنید و به سازندهٔ [HtmlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/htmloptions/) پاس دهید.

هنگام خارجی‌سازی منابع، دو مسیر را به‌دقت انتخاب کنید:

- مسیر خروجی سیستم فایل، جایی که برنامهٔ شما تصاویر، قلم‌ها، صدا یا ویدیوهای تولید‌شده را می‌نویسد.
- مسیر URL، که مرورگر از سند HTML برای بارگذاری آن فایل‌ها استفاده می‌کند.

## **صادرات فایل‌های رسانه‌ای**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/videoplayerhtmlcontroller/) ویدیوها و فایل‌های صوتی را صادر می‌کند و HTMLی می‌نویسد که می‌تواند آن‌ها را در مرورگر پخش کند. سازندهٔ آن شامل:

- `path`: پوشه‌ای که فایل‌های رسانه‌ای تولید‌شده در آن نوشتند.
- `fileName`: نام فایل HTML در حال تولید.
- `baseUri`: پیشوند URI مطلق که در لینک‌های HTML به فایل‌های رسانه‌ای استفاده می‌شود.

اگر فایل HTML `html-output/presentation.html` باشد و فایل‌های رسانه‌ای در `html-output/media` ذخیره شوند، `path` باید به پوشهٔ رسانه‌ای روی دیسک اشاره کند، در حالی که `baseUri` باید از دید مرورگر به همان پوشه اشاره داشته باشد. برای پیش‌نمایش محلی می‌توانید URI `file:///` را از پوشهٔ رسانه‌ای بسازید. برای برنامهٔ مستقر، از URL مطلق پوشهٔ رسانه‌ای منتشرشده استفاده کنید.

```java
String outputDirectory = System.getProperty("user.dir") + "/html-output";
String mediaDirectory = outputDirectory + "/media";
File outDir = new File(outputDirectory);
outDir.mkdir();
File mediaDir = new File(mediaDirectory);
mediaDir.mkdir();

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory;

Presentation presentation = new Presentation();
try {
    byte[] videoData = ...;// intro.mp4

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory;
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    String htmlFilePath = outputDirectory + "/" + htmlFileName;
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

از پوشه‌های خروجی که برای هر کار تبدیل منحصر به فرد هستند استفاده کنید، به‌ویژه در برنامه‌های سرور. مسیرهای خروجی مشترک می‌توانند باعث نوشتن روی فایل‌های تبدیل‌های مختلف شوند.

## **کارایی و مدیریت منابع**

تبدیل HTML یک عملیات رندر است، بنابراین زمان پردازش و مصرف حافظه به تعداد اسلایدها، وضوح تصویر، قلم‌ها، افکت‌ها، نمودارها و رسانه‌های جاسازی‌شده بستگی دارد. مقادیر DPI بالاتر در `PicturesCompression`، قلم‌های جاسازی‌شده، خروجی SVG و نگه داشتن نواحی بریده‌شدهٔ تصویر می‌توانند وفاداری را بهبود دهند اما معمولاً اندازه خروجی را افزایش می‌دهند.

برای تبدیل دسته‌ای:

- هر نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را به‌سرعت آزاد کنید.
- برای کارهای جداگانه پوشهٔ خروجی جداگانه استفاده کنید.
- قلم‌های عمومی را مگر آنکه وفاداری نیاز داشته باشد، جاسازی نکنید.
- DPI تصویر را وقتی HTML برای پیش‌نمایش یا تصاویر کوچک است، کاهش دهید.
- ارائهٔ منبع، HTML تولیدشده و منابع خارجی را تا زمان نهایی شدن مسیرهای استقرار با هم نگه دارید.

## **پرسش‌های متداول**

**آیا پیوندهای ابرمتن در خروجی HTML حفظ می‌شوند؟**

بله. پیوندهای ابرمتن ارائه به HTML صادر می‌شوند و وقتی URL مقصد معتبر باشد، کلیک‌پذیر می‌مانند.

**آیا می‌توانم ارائه‌ها را به‌صورت موازی به HTML تبدیل کنم؟**

بله، اما یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را بین رشته‌ها به‌اشتراک نگذارید. فایل‌های مختلف را با نمونه‌های ارائهٔ جداگانه، جریان‌های جداگانه و پوشه‌های خروجی جداگانه پردازش کنید. برای جزئیات به [راهنمای چندنخی](/slides/fa/androidjava/multithreading/) مراجعه کنید.

**آیا شیء Presentation ایمن برای استفاده در چندنخ است؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) باید در یک نخ بارگذاری، تغییر، ذخیره و آزاد شود. برای کار موازی، یک نمونهٔ مستقل برای هر نخ یا فرآیند ایجاد کنید.

**چرا فایل HTML تولید شده بزرگ است؟**

صادرات پیش‌فرض می‌تواند منابع را مستقیماً در HTML جاسازی کند. قلم‌های جاسازی‌شده، تصاویر با DPI بالا، رسانه‌ها، محتوای SVG و نگه داشتن نواحی بریده‌شدهٔ تصویر نیز اندازه را افزایش می‌دهند. برای کاهش حجم، از منابع خارجی استفاده کنید، قلم‌های عمومی را از جاسازی حذف کنید و `PicturesCompression` را کاهش دهید وقتی که حجم کمتر مهم‌تر از حداکثر وفاداری باشد.

**چرا اندازهٔ قلم PowerPoint مثل 24 pt در HTML به 17.999819 pt تبدیل می‌شود؟**

این می‌تواند به دلیل مدل‌های DPI متفاوت بین PowerPoint و HTML باشد. PowerPoint اندازه متن را بر پایهٔ نقطه‌های قلم‌شناسی با 72 DPI ذخیره می‌کند، در حالی که چیدمان HTML بر پایهٔ پیکسل‌های CSS در مدل 96 DPI است. وقتی Aspose.Slides ارائه‌ای را به HTML صادر می‌کند، اندازهٔ قلم بین این دو سیستم ترجمه می‌شود و ممکن است اختلافات گردشی کوچک ایجاد کند.

این مقدارها نشان‌دهندهٔ تغییر واقعی در اندازهٔ قلم بصری نیستند؛ تنها اثر جانبی ریاضی تبدیل معیارهای متنی بین PowerPoint و HTML هستند.

**چگونه باید baseUri را برای صادرات رسانه انتخاب کنم؟**

`baseUri` را از دید مرورگر انتخاب کنید و به‌عنوان URI مطلق پاس دهید. برای پیش‌نمایش محلی می‌توانید آن را از پوشهٔ خروجی با `mediaDirectory.toUri().toString()` به‌دست آورید. برای استقرار، از URL مطلق پوشهٔ رسانه‌ای منتشرشده استفاده کنید. مسیر سیستم فایل `path` و `baseUri` مرورگر لازم نیست که یک رشتهٔ یکسان باشند، اما باید به همان مکان منبع اشاره کنند.

**آیا می‌توانم اسلایدهای مخفی را شامل کنم؟**

بله. وقتی اسلایدهای مخفی باید صادر شوند، `ShowHiddenSlides` را روی `true` در [HtmlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/htmloptions/) تنظیم کنید.