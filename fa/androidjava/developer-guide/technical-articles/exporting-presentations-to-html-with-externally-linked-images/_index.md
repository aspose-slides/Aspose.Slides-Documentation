---
title: صادرات ارائه‌ها به HTML با تصاویر لینک‌شده به‌صورت خارجی
type: docs
weight: 100
url: /fa/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- تصویر لینک‌شده به‌صورت خارجی
- منبع لینک‌شده
- منبع خارجی
- Android
- Java
- Aspose.Slides
description: "صادرات ارائه‌های PowerPoint و OpenDocument به HTML در اندروید از طریق جاوا با استفاده از Aspose.Slides که تصاویر و سایر منابع به‌صورت فایل‌های لینک‌شده خارجی ذخیره می‌شوند."
---
## **نمای کلی**

به طور پیش‌فرض، Aspose.Slides یک ارائه را به یک فایل HTML خودکفا صادر می‌کند. تصاویر و سایر منابع مستقیماً در HTML نوشته می‌شوند، معمولاً به صورت داده‌های Base64. این کار زمانی که به یک فایل قابل حمل نیاز دارید مفید است، اما همیشه بهترین قالب برای نمایش وب، یک CMS، یا یک خط لوله تبدیل سمت‑سرور که بعداً خروجی را منتشر می‌کند، نیست.

از منابع لینک‌شده به‌صورت خارجی استفاده کنید زمانی که می‌خواهید:

- حجم سند HTML را کاهش دهید؛
- تصاویر، قلم‌ها، صدا یا ویدئو را به‌صورت جداگانه در مرورگر یا CDN کش کنید؛
- منابع تولید‌شده پس از استخراج را بررسی، جایگزین، فشرده یا پس‌پردازش کنید؛
- ساختار خروجی را به‌نزدیکی آنچه یک برنامه وب انتظار دارد نگه دارید.

برای گردش کار عمومی تبدیل HTML، به [تبدیل ارائه‌های PowerPoint به HTML](/slides/fa/androidjava/convert-powerpoint-to-html/) مراجعه کنید. این مقاله بر روی بخش لینک‌دادن به منابع صادرات تمرکز دارد.

## **چگونه خروجی با منابع لینک‌شده کار می‌کند**

[ILinkEmbedController](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilinkembedcontroller/) به برنامه شما اجازه می‌دهد به‌صورت منبع به منبع تصمیم بگیرید که آیا استخراج‌کننده داده‌ها را در HTML جاسازی می‌کند یا به‌صورت خارجی ذخیره کرده و لینک می‌نویسد.

این رابط شامل سه روش است:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilinkembedcontroller/) تصمیم می‌گیرد که آیا یک منبع باید لینک شود یا جاسازی.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilinkembedcontroller/) URLی را برمی‌گرداند که در HTML تولیدی یا به منبع لینک‌شده دیگر نوشته می‌شود.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilinkembedcontroller/) داده منبع لینک‌شده را روی دیسک یا به هدف ذخیره‌سازی دیگری می‌نویسد.

مسیر سیستم فایل و URL مرورگر موارد جداگانه‌ای هستند. برای مثال، نمونه زیر فایل‌های منبع را در `html-output/assets` در فضای ذخیره‌سازی برنامه می‌نویسد، در حالی که HTML شامل URLهای نسبی مانند `assets/resource-1.svg` است. مرورگر این URLها را نسبت به فایلی که لینک را دارد حل می‌کند. بنابراین، لینکی از `presentation.html` به یک فایل SVG از `assets/resource-1.svg` استفاده می‌کند، در حالی که لینکی از همان فایل SVG به تصویری که در همان پوشه `assets` ذخیره شده است از `resource-4.jpg` استفاده می‌کند.

## **صدور HTML با منابع لینک‌شده**

مثال زیر در Android Java یک پوشه خروجی ایجاد می‌کند، فایل HTML را در آن ذخیره می‌کند و منابع لینک‌شده را در زیرپوشه `assets` نگه می‌دارد. یک پوشه متعلق به برنامه مانند `context.getFilesDir()` را به عنوان `applicationFilesDirectory` بگذرید. کد از APIهای `java.nio.file` استفاده نمی‌کند، بنابراین با Android `minSdk` 19 سازگار می‌ماند.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
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
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
        }
    }
}
```

پس از صادرات، پوشه خروجی این ساختار را دارد:

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

فایل‌های دقیق بسته به محتوای ارائه و گزینه‌های صادرات متفاوت هستند. برای مثال، تصاویر رستر معمولاً به صورت JPEG یا PNG صادر می‌شوند. Aspose.Slides ممکن است کدک تصویر متفاوتی نسبت به آنچه در ارائه منبع استفاده شده انتخاب کند وقتی که این کار فایل کوچکتر یا مناسب‌تری تولید می‌کند. تصاویر با شفافیت به صورت PNG صادر می‌شوند.

## **انتخاب URLها برای استقرار**

نمونه از پیشوند URL نسبی `assets/` استفاده می‌کند. اگر `presentation.html` از `html-output/presentation.html` باز شود، مرورگر `html-output/assets/resource-1.svg` را بارگذاری می‌کند.

هنگامی که یک منبع لینک‌شده به منبع لینک‌شده دیگری ارجاع می‌دهد، نمونه از پارامتر `referrer` در [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilinkembedcontroller/) استفاده می‌کند و فقط نام فایل را برمی‌گرداند. برای مثال، اگر `resource-1.svg` و `resource-4.jpg` هر دو در پوشه `assets` باشند، فایل SVG باید به `resource-4.jpg` اشاره کند، نه به `assets/resource-4.jpg`.

از پیشوند URL متفاوتی استفاده کنید وقتی فایل‌ها در جای دیگری مستقر می‌شوند:

- از `assets/` زمانی که پوشه دارایی کنار فایل HTML باشد استفاده کنید.
- از `../assets/` زمانی که پوشه دارایی یک سطح بالاتر از فایل HTML باشد استفاده کنید.
- از `https://cdn.example.com/presentations/job-123/assets/` زمانی که فایل‌ها به یک CDN یا سرور فایل استاتیک آپلود می‌شوند استفاده کنید.

URLی که توسط [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilinkembedcontroller/) برگردانده می‌شود باید با مکان نهایی استقرار فایلی که توسط [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilinkembedcontroller/) نوشته می‌شود مطابقت داشته باشد. در برنامه‌های Android، از ذخیره‌سازی مخصوص برنامه، یک پوشه کش، یا پوشه‌ای که از طریق Storage Access Framework به‌دست می‌آید مطابق با جریان کاری انتشار استفاده کنید. در برنامه‌های سرور، برای هر کار تبدیل یک پوشه خروجی یا پیشوند ذخیره‌سازی شی منحصر به فرد استفاده کنید تا از بازنویسی فایل‌ها توسط صادرات دیگر جلوگیری شود.

## **چه زمانی به‌جای آن جاسازی شود**

HTML جاسازی‌شده به صورت Base64 همچنان وقتی مفید است که خروجی باید یک فایل واحد باشد، مانند یک ضمیمه ایمیل، پیش‌نمایش آفلاین، یا سندی که بدون پوشه دارایی همراه جابه‌جا می‌شود. منابع لینک‌شده مناسب‌تر هستند وقتی HTML توسط یک برنامه وب سرویس می‌شود، در یک CMS ذخیره می‌شود، توسط یک خط لوله ساخت بهینه می‌شود، یا به‌صورت مستقل توسط مرورگرها کش می‌شود.

## **پرسش‌های متداول**

**آیا می‌توانم فقط تصاویر را به‌صورت خارجی ذخیره کنم و سایر منابع را جاسازی بمانم؟**

بله. در [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilinkembedcontroller/) برای انواع محتواهایی که می‌خواهید به‌صورت فایل‌های جداگانه ذخیره شوند `Link` از `LinkEmbedDecision` برگردانید و برای بقیه `Embed` برگردانید.

**چرا پسوند تصویر صادرشده با ارائه منبع متفاوت است؟**

Aspose.Slides ممکن است در هنگام صادرات HTML تصاویر رستر را دوباره کدگذاری کند تا اندازه یا سازگاری با مرورگر بهبود یابد. برای مثال، یک تصویر از فایل منبع ممکن است بسته به نتیجه رندر به صورت JPEG یا PNG نوشته شود.

**آیا URLهای نسبی پس از جابه‌جایی فایل HTML کار می‌کنند؟**

URLهای نسبی تنها وقتی کار می‌کنند که ساختار پوشه نسبی یکسان حفظ شود. اگر HTML به `assets/resource-1.png` ارجاع دهد، پوشه `assets` باید در کنار فایل HTML بماند مگر اینکه پیشوند URL متفاوتی تولید کنید.

**آیا می‌توانم منابع را در ذخیره‌سازی عمومی خارجی در Android بنویسم؟**

بله، اگر برنامه شما مقصد معتبر و مدل مجوز مناسب برای نسخه هدف Android داشته باشد. برای HTML تولید شده که فقط توسط برنامه شما استفاده می‌شود، فایل‌های مخصوص برنامه یا پوشه‌های کش معمولاً ساده‌تر هستند. برای خروجی قابل مشاهده توسط کاربر، از مکان انتخابی کاربر یا روش ذخیره‌سازی دیگری که با برنامه شما سازگار باشد استفاده کنید.

**آیا برنامه‌های سروری باید از همان پوشه خروجی مجدداً استفاده کنند؟**

نه. برای هر کار تبدیل یک پوشه خروجی یا پیشوند ذخیره‌سازی منحصر به فرد استفاده کنید. این کار از برخورد نام فایل‌ها جلوگیری می‌کند و مانع بازنویسی منابع تولید شده توسط صادرات دیگر می‌شود.