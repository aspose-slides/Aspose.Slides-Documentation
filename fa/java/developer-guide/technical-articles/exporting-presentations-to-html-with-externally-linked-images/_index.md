---
title: صادرات ارائه‌ها به HTML با تصاویر لینک‌شده خارجی
type: docs
weight: 100
url: /fa/java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- صادرات PowerPoint
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
- تصویر لینک‌شده
- تصویر لینک‌شده خارجی
- منبع لینک‌شده
- منبع خارجی
- Java
- Aspose.Slides
description: "ارائه‌های PowerPoint و OpenDocument را در Java به HTML صادر کنید با استفاده از Aspose.Slides به‌طوری که تصاویر و سایر منابع به‌عنوان فایل‌های لینک‌شده خارجی ذخیره شوند."
---
## **نمای کلی**

به طور پیش‌فرض، Aspose.Slides ارائه‌ای را به یک فایل HTML خودکفا صادر می‌کند. تصاویر و سایر منابع مستقیماً درون HTML نوشته می‌شوند، معمولاً به صورت داده‌های Base64. این برای زمانی که به یک فایل قابل حمل نیاز دارید، مناسب است، اما همیشه بهترین قالب برای یک وب‌سایت، CMS یا خط لوله تبدیل سمت سرور نیست.

از منابع لینک‌شده به‌صورت خارجی استفاده کنید هنگامی که می‌خواهید:

- حجم سند HTML را کاهش دهید؛
- تصاویر، فونت‌ها، صدا یا ویدئوها را به‌صورت جداگانه در مرورگر یا CDN کش کنید؛
- منابع تولید شده پس از خروجی گرفتن را بررسی، جایگزین، فشرده یا پس‌پردازش کنید؛
- ساختار خروجی را نزدیک‌تر به آنچه یک برنامه وب انتظار دارد نگه دارید.

برای جریان کاری عمومی تبدیل HTML، به [Convert PowerPoint Presentations to HTML](/slides/fa/java/convert-powerpoint-to-html/) مراجعه کنید. این مقاله بر بخش لینک‌کردن منابع در خروجی تمرکز دارد.

## **چگونه خروجی منابع لینک‌شده کار می‌کند**

`[ILinkEmbedController](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/)` به برنامه شما امکان می‌دهد به‌صورت منبع به منبع تصمیم بگیرد که آیا خروجی‌کننده داده‌ها را در HTML جاسازی کند یا به‌صورت خارجی ذخیره کرده و یک لینک بنویسد.

این رابط دارای سه متد است:

- `[ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/)` تصمیم می‌گیرد که آیا یک منبع باید لینک یا جاسازی شود.
- `[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/)` URLی را برمی‌گرداند که در HTML تولید شده یا به منبع لینک‌شده دیگر نوشته می‌شود.
- `[ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/)` داده‌های منبع لینک‌شده را بر روی دیسک یا به هدف ذخیره‌سازی دیگری می‌نویسد.

مسیر سیستم فایل و URL مرورگر موارد متفاوتی هستند. برای مثال، نمونه زیر فایل‌های منبع را در `html-output/assets` روی دیسک می‌نویسد، در حالی که HTML شامل URLهای نسبی مانند `assets/resource-1.svg` است. مرورگر این URLها را نسبت به فایلی که لینک را شامل می‌شود حل می‌کند. بنابراین، لینکی از `presentation.html` به یک فایل SVG از `assets/resource-1.svg` استفاده می‌کند، در حالی که لینکی از آن فایل SVG به یک تصویر ذخیره‌شده در همان پوشهٔ `assets` از `resource-4.jpg` استفاده می‌کند.

## **خروجی HTML با منابع لینک‌شده**

مثال زیر در Java یک دایرکتوری خروجی ایجاد می‌کند، فایل HTML را در آن ذخیره می‌کند و منابع لینک‌شده را در یک زیردایرکتوری `assets` ذخیره می‌سازد. کنترل‌کننده منابع رایج تصویر، فونت، صدا، ویدئو و CSS را لینک می‌کند زمانی که Aspose.Slides پسوند فایل ایمنی را فراهم یا استنتاج می‌کند. منابعی که شناسایی نشده‌اند به صورت جاسازی باقی می‌مانند.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void main(String[] args) throws IOException {
        Path inputFilePath = Paths.get("presentation.pptx");
        Path outputDirectory = Paths.get("html-output");
        String assetDirectoryName = "assets";
        Path assetDirectory = outputDirectory.resolve(assetDirectoryName);

        Files.createDirectories(outputDirectory);
        Files.createDirectories(assetDirectory);

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFilePath.toString());
        try {
            Path htmlFilePath = outputDirectory.resolve("presentation.html");
            presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final Path assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

        private ExternalResourceController(Path assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            try {
                Files.createDirectories(assetDirectory);
                Path filePath = assetDirectory.resolve(fileName);
                Files.write(filePath, entityData);
            } catch (IOException exception) {
                throw new IllegalStateException("Failed to save external resource " + resourceId + ".", exception);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().isEmpty()) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.isEmpty()) {
                return null;
            }

            for (int index = 0; index < extensionCharacters.length(); index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
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
}
```

پس از خروجی گرفتن، پوشهٔ خروجی این ساختار را دارد:

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

فایل‌های دقیق به محتوای ارائه و گزینه‌های خروجی وابسته‌اند. به عنوان مثال، تصاویر رستری معمولاً به صورت JPEG یا PNG صادر می‌شوند. Aspose.Slides ممکن است کدک تصویری متفاوتی نسبت به آنچه در ارائهٔ منبع استفاده شده است، انتخاب کند هنگامی که فایل کوچکتر یا مناسب‌تری تولید می‌کند. تصاویری که شفافیت دارند به صورت PNG صادر می‌شوند.

## **انتخاب URLها برای استقرار**

نمونه از پیشوند URL نسبی استفاده می‌کند: `assets/`. اگر `presentation.html` از `html-output/presentation.html` باز شود، مرورگر `html-output/assets/resource-1.svg` را بارگذاری می‌کند.

زمانی که یک منبع لینک‌شده به منبع لینک‌شدهٔ دیگری ارجاع می‌دهد، نمونه از پارامتر `referrer` در `[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/)` استفاده می‌کند و فقط نام فایل را برمی‌گرداند. برای مثال، اگر `resource-1.svg` و `resource-4.jpg` هردو در پوشهٔ `assets` باشند، فایل SVG باید به `resource-4.jpg` ارجاع دهد، نه به `assets/resource-4.jpg`.

هنگامی که فایل‌ها در مکان دیگری استقرار می‌یابند، از پیشوند URL متفاوتی استفاده کنید:

- `assets/` را زمانی استفاده کنید که دایرکتوری دارایی کنار فایل HTML باشد.
- `../assets/` را زمانی استفاده کنید که دایرکتوری دارایی یک سطح بالاتر از فایل HTML باشد.
- `https://cdn.example.com/presentations/job-123/assets/` را زمانی استفاده کنید که فایل‌ها به یک CDN یا سرور فایل‌های ایستا بارگذاری شوند.

URLی که توسط `[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/)` برگردانده می‌شود باید با مکان نهایی استقرار فایل نوشته‌شده توسط `[ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/)` مطابقت داشته باشد. در برنامه‌های سروری، برای هر کار تبدیل یک دایرکتوری خروجی یا پیشوند ذخیره‌سازی شیء منحصر به‌فرد استفاده کنید تا از بازنویسی فایل‌های خروجی دیگر جلوگیری شود.

## **چه زمانی به‌جای آن جاسازی شود**

HTML جاسازی‌شده با Base64 همچنان زمانی مفید است که خروجی باید یک فایل تک باشد، مانند یک پیوست ایمیل، پیش‌نمایش آفلاین، یا سندی که بدون پوشه دارایی پشتیبان جابه‌جا می‌شود. منابع لینک‌شده وقتی بهتر مناسب هستند که HTML توسط یک برنامه وب سرویس‌دهی شود، در یک CMS ذخیره شود، توسط خط لوله ساخت بهینه‌سازی شود یا توسط مرورگرها به‌صورت مستقل از HTML کش شود.

## **FAQ**

**آیا می‌توانم فقط تصاویر را به‌صورت خارجی ذخیره کنم و سایر منابع را جاسازی بماند؟**

بله. در `[ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/)`، برای انواع محتواهایی که می‌خواهید به‌صورت فایل‌های جداگانه ذخیره شوند مقدار `LinkEmbedDecision.Link` را برگردانید و برای بقیه مقدار `LinkEmbedDecision.Embed` را برگردانید.

**چرا پسوند تصویر صادرشده با ارائهٔ منبع متفاوت است؟**

Aspose.Slides ممکن است در طول خروجی HTML تصاویر رستری را دوباره کدگذاری کند تا اندازه یا سازگاری مرورگر بهتر شود. برای مثال، یک تصویر از فایل منبع ممکن است بسته به نتیجه رندر به صورت JPEG یا PNG نوشته شود.

**آیا URLهای نسبی پس از جابجایی فایل HTML کار می‌کنند؟**

URLهای نسبی فقط زمانی کار می‌کنند که ساختار پوشه نسبی یکسان حفظ شود. اگر HTML به `assets/resource-1.png` ارجاع دهد، پوشهٔ `assets` باید کنار فایل HTML بماند مگر این که پیشوند URL متفاوتی تولید کنید.

**آیا برنامه‌های سروری باید از همان پوشهٔ خروجی استفاده مجدد کنند؟**

خیر. برای هر کار تبدیل یک دایرکتوری خروجی یا پیشوند ذخیره‌سازی منحصر به‌فرد استفاده کنید. این از تداخل نام فایل‌ها جلوگیری می‌کند و مانع بازنویسی منابع تولید‌شده توسط یک خروجی دیگر می‌شود.