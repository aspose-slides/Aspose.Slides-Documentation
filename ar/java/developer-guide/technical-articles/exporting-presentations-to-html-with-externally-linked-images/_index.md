---
title: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا
type: docs
weight: 100
url: /ar/java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير عرض تقديمي
- تصدير شريحة
- تصدير PPT
- تصدير PPTX
- تصدير ODP
- PowerPoint إلى HTML
- OpenDocument إلى HTML
- عرض تقديمي إلى HTML
- شريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- ODP إلى HTML
- صورة مرتبطة
- صورة مرتبطة خارجيًا
- مورد مرتبط
- مورد خارجي
- Java
- Aspose.Slides
description: "تصدير عروض PowerPoint وOpenDocument إلى HTML في Java باستخدام Aspose.Slides مع حفظ الصور والموارد الأخرى كملفات مرتبطة خارجياً."
---
## **نظرة عامة**

بشكل افتراضي، يقوم Aspose.Slides بتصدير العرض التقديمي إلى ملف HTML ذاتي الاحتواء. تُكتب الصور والموارد الأخرى مباشرةً داخل HTML، عادةً كبيانات Base64. هذا ملائم عندما تحتاج إلى ملف واحد محمول، لكنه ليس دائماً الصيغة المثالية لموقع ويب أو نظام إدارة محتوى أو خط أنابيب تحويل من جانب الخادم.

استخدم الموارد المرتبطة خارجيًا عندما تريد:

- تقليل حجم مستند HTML؛
- تخزين الصور أو الخطوط أو الصوت أو الفيديو مؤقتًا في المتصفح أو شبكة توصيل المحتوى (CDN) بشكل منفصل؛
- فحص الموارد المُولدة أو استبدالها أو ضغطها أو معالجتها بعد التصدير؛
- الحفاظ على بنية المخرج أقرب إلى ما تتوقعه تطبيقات الويب.

للحصول على سير عمل التحويل العام إلى HTML، راجع [تحويل عروض PowerPoint إلى HTML](/slides/ar/java/convert-powerpoint-to-html/). يركز هذا المقال على جزء ربط الموارد في عملية التصدير.

## **كيفية عمل تصدير الموارد المرتبطة**

[ILinkEmbedController](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/) يتيح لتطبيقك أن يقرر، لكل مورد على حدة، ما إذا كان المُصدِّر سيضمّن البيانات داخل HTML أم سيحفظها خارجيًا ويكتب رابطًا.

تحتوي الواجهة على ثلاث طرق:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/) يحدّد ما إذا كان يجب ربط المورد أو تضمينه.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/) يُعيد عنوان URL الذي سيُكتب في HTML المُولَّد أو في مورد مرتبط آخر.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/) يكتب بيانات المورد المرتبط إلى القرص أو إلى هدف تخزين آخر.

مسار نظام الملفات وعنوان URL المتصفح هما اعتباران منفصلان. على سبيل المثال، يكتب المثال أدناه ملفات الموارد إلى `html-output/assets` على القرص، بينما يحتوي HTML على عناوين URL نسبية مثل `assets/resource-1.svg`. يقوم المتصفح بحل هذه العناوين نسبةً إلى الملف الذي يحتوي على الرابط. لذلك، يستخدم الرابط من `presentation.html` إلى ملف SVG العنوان `assets/resource-1.svg`، بينما يستخدم الرابط من ملف SVG نفسه إلى صورة محفوظة في نفس مجلد `assets` العنوان `resource-4.jpg`.

## **تصدير HTML مع موارد مرتبطة**

المثال التالي بلغة Java يُنشئ دليل إخراج، يحفظ ملف HTML هناك، ويخزن الموارد المرتبطة في مجلد فرعي `assets`. يقوم المتحكم بربط موارد الصورة، الخط، الصوت، الفيديو، وCSS الشائعة عندما يوفر Aspose.Slides أو يمكنه استنتاج امتداد ملف آمن. الموارد التي لا تُعَرَّف تظل مدمجة.

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

بعد التصدير، يكون هيكل المجلد الناتج كالتالي:

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

الملفات الدقيقة تعتمد على محتوى العرض التقديمي وخيارات التصدير. على سبيل المثال، يُصدر عادةً الصور النقطية كـ JPEG أو PNG. قد يختار Aspose.Slides ترميز صورة مختلف عن المستخدم في العرض الأصلي إذا كان ذلك ينتج ملفًا أصغر أو أكثر ملاءمة. تُصدر الصور ذات الشفافية كـ PNG.

## **اختيار عناوين URL للنشر**

يستخدم المثال بادئة URL نسبية: `assets/`. إذا تم فتح `presentation.html` من `html-output/presentation.html`، سيحمّل المتصفح `html-output/assets/resource-1.svg`.

عند إشارة مورد مرتبط إلى مورد مرتبط آخر، يستخدم المثال معامل `referrer` في [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/) ويُعيد فقط اسم الملف. على سبيل المثال، إذا كان `resource-1.svg` و `resource-4.jpg` كلاهما في مجلد `assets`، يجب أن يشير ملف SVG إلى `resource-4.jpg` وليس إلى `assets/resource-4.jpg`.

استخدم بادئة URL مختلفة عندما تُنشر الملفات في موقع آخر:

- استخدم `assets/` عندما يكون دليل الأصول بجوار ملف HTML.
- استخدم `../assets/` عندما يكون دليل الأصول مستوىً واحدًا فوق ملف HTML.
- استخدم `https://cdn.example.com/presentations/job-123/assets/` عندما تُحمَّل الملفات إلى شبكة توصيل محتوى (CDN) أو خادم ملفات ثابتة.

يجب أن يتطابق عنوان URL الذي تُعيده [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/) مع الموقع النهائي الذي تُكتبه [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/). في تطبيقات الخادم، استخدم دليل خرج فريد أو بادئة تخزين كائن لكل مهمة تحويل لتجنب الكتابة فوق ملفات تصدير أخرى.

## **متى يجب تضمين الموارد بدلاً من ربطها**

ما زال HTML المضمّن بصيغة Base64 مفيدًا عندما يجب أن يكون الناتج ملفًا واحدًا، مثل مرفق بريد إلكتروني، أو معاينة بدون اتصال، أو مستند سينتقل دون مجلد أصول داعم. تكون الموارد المرتبطة أكثر ملاءمة عندما يُقدم HTML عبر تطبيق ويب، أو يُخزن في نظام إدارة محتوى، أو يُحسّن عبر خط أنابيب بناء، أو يُخزّن مؤقتًا في المتصفحات بشكل مستقل عن HTML.

## **الأسئلة المتكررة**

**هل يمكنني خارجيّة الصور فقط مع إبقاء الموارد الأخرى مدمجة؟**

نعم. في [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/)، أعد `LinkEmbedDecision.Link` فقط لأنواع المحتوى التي تريد حفظها كملفات منفصلة، وأعد `LinkEmbedDecision.Embed` لكل ما هو آخر.

**لماذا يختلف امتداد الصورة المُصدَّرة عن العرض التقديمي الأصلي؟**

قد يُعيد Aspose.Slides ترميز الصور النقطية أثناء تصدير HTML لتحسين الحجم أو توافق المتصفح. على سبيل المثال، قد تُكتب صورة من الملف الأصلي كـ JPEG أو PNG حسب النتيجة المعروضة.

**هل تعمل عناوين URL النسبية بعد نقل ملف HTML؟**

تعمل عناوين URL النسبية فقط عندما تُحافظ على هيكل المجلدات النسبية نفسه. إذا كان HTML يشير إلى `assets/resource-1.png`، يجب أن يبقى مجلد `assets` بجوار ملف HTML إلا إذا أنشأت بادئة URL مختلفة.

**هل ينبغي لتطبيقات الخادم إعادة استخدام نفس مجلد الإخراج؟**

لا. استخدم دليل إخراج فريد أو بادئة تخزين لكل مهمة تحويل. هذا يُجنب تصادم أسماء الملفات ويمنع كتابة مورد من تصدير واحد فوق موارد تم توليدها في تصدير آخر.