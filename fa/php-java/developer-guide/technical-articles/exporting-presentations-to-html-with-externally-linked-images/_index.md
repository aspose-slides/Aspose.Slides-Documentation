---
title: صادر کردن ارائه‌ها به HTML با تصاویر پیوندی خارجی
type: docs
weight: 100
url: /fa/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- صادرات پاورپوینت
- صادرات OpenDocument
- صادرات ارائه
- صادرات اسلاید
- صادرات PPT
- صادرات PPTX
- صادرات ODP
- PowerPoint به HTML
- OpenDocument به HTML
- ارائه به HTML
- اسلاید به HTML
- PPT به HTML
- PPTX به HTML
- ODP به HTML
- تصویر پیوندی
- تصویر پیوندی خارجی
- منبع پیوندی
- منبع خارجی
- PHP
- Aspose.Slides
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML در PHP از طریق Java با استفاده از Aspose.Slides و ذخیره‌سازی تصاویر و سایر منابع به‌عنوان فایل‌های پیوندی خارجی."
---
## **نمای کلی**

به طور پیش‌فرض، Aspose.Slides ارائه‌ای را به یک فایل HTML خودکفا صادر می‌کند. تصاویر و سایر منابع مستقیماً در داخل HTML نوشته می‌شوند، معمولاً به‌صورت داده‌های Base64. این زمانی که به یک فایل قابل حمل نیاز دارید، مفید است، اما همیشه بهترین قالب برای وب‌سایت، یک CMS، یا یک خط لوله تبدیل سمت سرور نیست.

در صورتی که مایل باشید از منابع پیوندی خارجی استفاده کنید:
- حجم سند HTML را کاهش دهید؛
- تصاویر، قلم‌ها، صدا یا ویدیو را به صورت جداگانه در مرورگر یا CDN cache کنید؛
- منابع تولید شده پس از خروجی‌گیری را بررسی، جایگزین، فشرده یا پس‌پردازش کنید؛
- ساختار خروجی را نزدیک‌تر به آنچه یک برنامه وب انتظار دارد نگه دارید.

برای جریان کار عمومی تبدیل HTML، به [Convert PowerPoint Presentations to HTML](/slides/fa/php-java/convert-powerpoint-to-html/) مراجعه کنید. این مقاله بر بخش پیوند منابع در خروجی متمرکز است.

## **نحوه کار صدور منابع پیوندی**

[HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/) می‌تواند هنگام صدور یک ارائه به HTML توسط Aspose.Slides از یک کنترل‌کننده سفارشی لینک/جاسازی استفاده کند. در PHP از طریق Java، این سناریو معمولاً با یک کلاس کمکی کوچک Java پیاده‌سازی می‌شود. آن کلاس کمکی را کامپایل کنید، به مسیر کلاس PHP Java Bridge اضافه کنید و از PHP با `new Java(...)` نمونه‌سازی کنید.

کلاس کمکی، به ازای هر منبع، تصمیم می‌گیرد که آیا صادرکننده داده را در HTML جاسازی کند یا به‌صورت خارجی ذخیره کند و یک لینک بنویسد. این کلاس به سه متد بازگشت نیاز دارد:
- `ExternalResourceController.getObjectStoringLocation` تصمیم می‌گیرد که آیا منبع باید لینک شود یا جاسازی.
- `ExternalResourceController.getUrl` URL‌ای را برمی‌گرداند که در HTML تولید شده یا به منبع پیوندی دیگر نوشته می‌شود.
- `ExternalResourceController.saveExternal` داده‌های منبع پیوندی را بر روی دیسک یا هدف ذخیره‌سازی دیگری می‌نویسد.

مسیر سیستم فایل و URL مرورگر موارد جداگانه‌ای هستند. برای مثال، نمونه زیر فایل‌های منبع را در `html-output/assets` روی دیسک می‌نویسد، در حالی که HTML شامل URLهای نسبی مانند `assets/resource-1.svg` است. مرورگر این URLها را نسبت به فایلی که لینک را دارد حل می‌کند. بنابراین، لینک از `presentation.html` به یک فایل SVG از `assets/resource-1.svg` استفاده می‌کند، در حالی که لینک از همان فایل SVG به تصویری که در همان پوشه `assets` ذخیره شده است، از `resource-4.jpg` استفاده می‌کند.

## **ایجاد کلاس کمکی Java**

یک کلاس Java مانند `com.example.slides.ExternalResourceController` ایجاد کنید، آن را با Aspose.Slides for Java در مسیر کلاس کامپایل کنید و کلاس یا JAR کامپایل‌شده را برای PHP Java Bridge در دسترس قرار دهید.

کلاس کمکی زیر منابع رایج تصویر، قلم، صوت، ویدیو و CSS را پیوند می‌دهد زمانی که Aspose.Slides پسوند فایل ایمنی را فراهم یا استنتاج می‌کند. منابعی که شناسایی نشوند به صورت جاسازی باقی می‌مانند.

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **صدور HTML با منابع پیوندی**

کد PHP زیر یک پوشه خروجی ایجاد می‌کند، فایل HTML را در آن ذخیره می‌کند و منابع پیوندی را در یک زیرپوشه `assets` نگه می‌دارد. این کد برای صدور ترکیبی از [HtmlOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/htmloptions/)، [SVGOptions](https://reference.aspose.com/slides/fa/php-java/aspose.slides/svgoptions/)، [SlideImageFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slideimageformat/) و [SaveFormat](https://reference.aspose.com/slides/fa/php-java/aspose.slides/saveformat/) استفاده می‌کند.

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

بعد از صدور، پوشه خروجی این ساختار را دارد:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

فایل‌های دقیق به محتوای ارائه و گزینه‌های صدور بستگی دارند. برای مثال، تصاویر رستری معمولاً به صورت JPEG یا PNG صادر می‌شوند. Aspose.Slides ممکن است کدک تصویری متفاوتی نسبت به آنچه در ارائه منبع استفاده شده است، انتخاب کند اگر این کار منجر به فایل کوچکتر یا مناسب‌تر شود. تصاویر با شفافیت به صورت PNG صادر می‌شوند.

## **انتخاب URLها برای استقرار**

نمونه یک پیشوند URL نسبی استفاده می‌کند: `assets/`. اگر `presentation.html` از `html-output/presentation.html` باز شود، مرورگر `html-output/assets/resource-1.svg` را بارگذاری می‌کند.

زمانی که یک منبع پیوندی به منبع پیوندی دیگری ارجاع می‌دهد، نمونه از پارامتر `referrer` در `ExternalResourceController.getUrl` استفاده می‌کند و فقط نام فایل را برمی‌گرداند. برای مثال، اگر `resource-1.svg` و `resource-4.jpg` هر دو در پوشه `assets` باشند، فایل SVG باید به `resource-4.jpg` ارجاع دهد، نه به `assets/resource-4.jpg`.

در صورتی که فایل‌ها در مکان دیگری مستقر شوند، پیشوند URL متفاوتی استفاده کنید:
- `assets/` را زمانی استفاده کنید که پوشه دارایی در کنار فایل HTML باشد.
- `../assets/` را زمانی استفاده کنید که پوشه دارایی یک سطح بالاتر از فایل HTML باشد.
- `https://cdn.example.com/presentations/job-123/assets/` را زمانی استفاده کنید که فایل‌ها به یک CDN یا سرور فایل‌های ایستای بارگذاری شوند.

URL برگشتی توسط `ExternalResourceController.getUrl` باید با مکان نهایی مستقر شده فایل نوشته شده توسط `ExternalResourceController.saveExternal` مطابقت داشته باشد. در برنامه‌های سرور، برای هر کار تبدیل یک پوشه خروجی منحصر به فرد یا پیشوند ذخیره‌سازی شیء استفاده کنید تا از بازنویسی فایل‌های صادر شده توسط دیگر کارها جلوگیری شود.

## **چه زمانی به‌جای لینک کردن جاسازی کنیم**

HTML جاسازی‌شده به‌صورت Base64 همچنان مفید است زمانی که خروجی باید یک فایل تک باشد، مانند یک پیوست ایمیل، پیش‌نمایش آفلاین، یا سندی که بدون پوشه دارایی همراه جابجا می‌شود. منابع پیوندی گزینه بهتری هستند زمانی که HTML توسط یک برنامه وب سرو شود، در یک CMS ذخیره شود، توسط یک خط لوله ساخت بهینه‌سازی شود یا مرورگرها به‌طور مستقل از HTML آن را cache کنند.

## **پرسش‌های متداول**

**آیا می‌توانم فقط تصاویر را خارج‌سازی کنم و سایر منابع را جاسازی بمانند؟**

بله. در `ExternalResourceController.getObjectStoringLocation`، مقدار `Link` را از [LinkEmbedDecision](https://reference.aspose.com/slides/fa/php-java/aspose.slides/linkembeddecision/) فقط برای انواع محتوا که می‌خواهید به‌صورت فایل‌های جداگانه ذخیره شوند برگردانید و برای سایر موارد مقدار `Embed` را برگردانید.

**چرا پسوند تصویر صادر شده با ارائه منبع متفاوت است؟**

Aspose.Slides ممکن است در طول خروجی HTML تصاویر رستری را دوباره کدگذاری کند تا حجم یا سازگاری مرورگر بهبود یابد. برای مثال، یک تصویر از فایل منبع ممکن است بسته به نتیجه رندر به صورت JPEG یا PNG ذخیره شود.

**آیا URLهای نسبی پس از جابجایی فایل HTML کار می‌کنند؟**

URLهای نسبی فقط زمانی کار می‌کنند که ساختار پوشه نسبی یکسان حفظ شود. اگر HTML به `assets/resource-1.png` ارجاع دهد، پوشه `assets` باید در کنار فایل HTML بماند مگر این‌که پیشوند URL متفاوتی تولید کنید.

**آیا برنامه‌های سرور باید پوشه خروجی یکسان را مجدداً استفاده کنند؟**

خیر. برای هر کار تبدیل یک پوشه خروجی یا پیشوند ذخیره‌سازی منحصربه‌فرد استفاده کنید. این کار از تداخل نام فایل‌ها جلوگیری می‌کند و مانع از اینکه یک خروجی منابع تولید شده توسط خروجی دیگر را بازنویسی کند، می‌شود.