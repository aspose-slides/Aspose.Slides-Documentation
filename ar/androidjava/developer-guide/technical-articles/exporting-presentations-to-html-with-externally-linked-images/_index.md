---
title: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجية
type: docs
weight: 100
url: /ar/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- صورة مرتبطة خارجية
- مورد مرتبط
- مورد خارجي
- Android
- Java
- Aspose.Slides
description: "تصدير عروض PowerPoint وOpenDocument إلى HTML على Android عبر Java باستخدام Aspose.Slides مع حفظ الصور والموارد الأخرى كملفات مرتبطة خارجية."
---
## **نظرة عامة**

بشكل افتراضي، تقوم Aspose.Slides بتصدير العرض التقديمي إلى ملف HTML متكامل. تُكتب الصور والموارد الأخرى مباشرةً داخل ملف HTML، عادةً كبيانات Base64. هذا مفيد عندما تحتاج إلى ملف واحد قابل للنقل، لكنه ليس دائماً التنسيق الأفضل للعرض على الويب أو نظام إدارة المحتوى أو خط أنابيب التحويل من جانب الخادم الذي ينشر المخرجات لاحقاً.

استخدم الموارد المرتبطة خارجيًا عندما تريد:

- تقليل حجم مستند HTML؛
- تخزين الصور أو الخطوط أو الصوت أو الفيديو في متصفح أو شبكة توزيع محتوى (CDN) بشكل منفصل؛
- فحص الموارد المستُخرجة أو استبدالها أو ضغطها أو معالجتها لاحقاً بعد التصدير؛
- الحفاظ على بنية المخرجات أقرب إلى ما تتوقعه تطبيقات الويب.

لإجراءات التحويل العامة إلى HTML، راجع [Convert PowerPoint Presentations to HTML](/slides/ar/androidjava/convert-powerpoint-to-html/). يركّز هذا المقال على جزء ربط الموارد في عملية التصدير.

## **كيفية عمل تصدير الموارد المرتبطة**

[ILinkEmbedController](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilinkembedcontroller/) يسمح لتطبيقك بتحديد، لكل مورد على حدة، ما إذا كان المُصدّر سيضمن البيانات داخل HTML أو سيحفظها خارجيًا ويكتب رابطًا.

تحتوي الواجهة على ثلاث طرق:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilinkembedcontroller/) يحدد ما إذا كان يجب ربط المورد أو تضمينه.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilinkembedcontroller/) يُعيد عنوان URL الذي سيكتب في HTML المُولَّد أو في مورد مرتبط آخر.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilinkembedcontroller/) يكتب بيانات المورد المرتبط إلى القرص أو إلى هدف تخزين آخر.

مسار نظام الملفات وعنوان URL للمتصفح هما شأنين منفصلين. على سبيل المثال، يكتب العيّن التالي ملفات الموارد إلى `html-output/assets` في تخزين ملفات التطبيق، بينما يحتوي HTML على عناوين URL نسبية مثل `assets/resource-1.svg`. يقوم المتصفح بحل هذه العناوين نسبةً إلى الملف الذي يحتوي على الرابط. لذلك، يستخدم الرابط من `presentation.html` إلى ملف SVG العنوان `assets/resource-1.svg`، بينما يستخدم الرابط من ملف SVG نفسه إلى صورة محفوظة في نفس مجلد `assets` العنوان `resource-4.jpg`.

## **تصدير HTML مع موارد مرتبطة**

الأمثلة التالية بلغة Android Java تُنشئ مجلد إخراج، تحفظ ملف HTML هناك، وتخزن الموارد المرتبطة في مجلد فرعي `assets`. مرّر مجلدًا يمتلكه التطبيق مثل `context.getFilesDir()` كقيمة `applicationFilesDirectory`. يتجنب الكود واجهات برمجة تطبيقات `java.nio.file`، لذا يبقى متوافقًا مع Android `minSdk` 19.

يقوم المتحكم بربط موارد الصورة والخط والصوت والفيديو وCSS الشائعة عندما توفر Aspose.Slides أو يمكنها استنتاج امتداد ملف آمن. تُبقي الموارد غير المعروفة مضمَّنة.

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

بعد التصدير، يحتوي مجلد الإخراج على البنية التالية:

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

تختلف الملفات الدقيقة بحسب محتوى العرض التقديمي وخيارات التصدير. على سبيل المثال، تُصدر الصور النقطية عادةً كملفات JPEG أو PNG. قد تختار Aspose.Slides ترميزًا مختلفًا عن الموجود في العرض الأصلي إذا كان ذلك ينتج ملفًا أصغر أو أكثر ملاءمة. تُصدر الصور ذات الشفافية كملفات PNG.

## **اختيار عناوين URL للنشر**

العينة تستخدم بادئة URL نسبية: `assets/`. إذا تم فتح `presentation.html` من `html-output/presentation.html`، يقوم المتصفح بتحميل `html-output/assets/resource-1.svg`.

عند إشارة مورد مرتبط إلى مورد مرتبط آخر، تستخدم العينة معامل `referrer` في [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilinkembedcontroller/) وتُعيد اسم الملف فقط. على سبيل المثال، إذا كان كل من `resource-1.svg` و`resource-4.jpg` موجودين في مجلد `assets`، يجب أن يشير ملف SVG إلى `resource-4.jpg`، وليس إلى `assets/resource-4.jpg`.

استخدم بادئة URL مختلفة عندما تُنشر الملفات في موقع آخر:

- استخدم `assets/` عندما يكون دليل الأصول بجوار ملف HTML.
- استخدم `../assets/` عندما يكون دليل الأصول مستوىً واحدًا أعلى من ملف HTML.
- استخدم `https://cdn.example.com/presentations/job-123/assets/` عندما تُرفع الملفات إلى CDN أو خادم ملفات ثابت.

يجب أن يتطابق عنوان URL الذي تُعيده [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilinkembedcontroller/) مع الموقع النهائي للملف الذي يكتبه [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilinkembedcontroller/). في تطبيقات Android، استخدم تخزينًا خاصًا بالتطبيق، أو دليلًا مؤقتًا، أو دليلًا يحصل عليه عبر إطار عمل الوصول إلى التخزين وفقًا لسير عمل النشر الخاص بك. في تطبيقات الخادم، استخدم مجلد إخراج فريد أو بادئة تخزين كائن لكل مهمة تحويل لتجنب كتابة فوق ملفات تصدير أخرى.

## **متى يجب التضمين بدلاً من ذلك**

ما زال HTML المضمَّن بصيغة Base64 مفيدًا عندما يجب أن يكون الإخراج ملفًا واحدًا، مثل مرفق البريد الإلكتروني أو معاينة غير متصلة أو مستند سينتقل دون مجلد أصول داعم. تُعد الموارد المرتبطة أكثر ملاءمة عندما يُخدم HTML بواسطة تطبيق ويب، أو يُخزن في نظام إدارة محتوى، أو يُحسّن عبر خط أنابيب بناء، أو يُخزن مؤقتًا في المتصفحات بشكل مستقل عن HTML.

## **الأسئلة الشائعة**

**هل يمكنني إقراصية مجرد الصور وإبقاء باقي الموارد مضمَّنة؟**

نعم. في [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ilinkembedcontroller/)، أرجِع `Link` من [LinkEmbedDecision](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/linkembeddecision/) فقط لأنواع المحتوى التي تريد حفظها كملفات منفصلة، وأرجِع `Embed` للبقية.

**لماذا يختلف امتداد الصورة المُصدَّرة عن عرض الشرائح الأصلي؟**

قد تقوم Aspose.Slides بإعادة ترميز الصور النقطية أثناء تصدير HTML لتحسين الحجم أو توافق المتصفح. على سبيل المثال، قد يُكتب صورة من الملف الأصلي كـ JPEG أو PNG حسب النتيجة المعروضة.

**هل تعمل عناوين URL النسبية بعد نقل ملف HTML؟**

تعمل عناوين URL النسبية فقط إذا حافظت على نفس بنية المجلدات النسبية. إذا أشار HTML إلى `assets/resource-1.png`, يجب أن يبقى مجلد `assets` بجوار ملف HTML ما لم تُنشئ بادئة URL مختلفة.

**هل يمكنني كتابة الموارد إلى تخزين خارجي عام على Android؟**

نعم، إذا كان لتطبيقك وجهة صالحة ونموذج أذونات مناسب لإصدار Android المستهدف. بالنسبة لـ HTML المُولد الذي يُستخدم فقط من قبل تطبيقك، تكون الملفات الخاصة بالتطبيق أو أدلة التخزين المؤقت عادةً أبسط. بالنسبة للمخرجات التي يراها المستخدمون، استخدم موقعًا يختاره المستخدم أو نهج تخزين آخر يناسب تطبيقك.

**هل يجب على تطبيقات الخادم إعادة استخدام نفس مجلد الإخراج؟**

لا. استخدم دليل إخراج فريد أو بادئة تخزين لكل مهمة تحويل. هذا يمنع تصادم أسماء الملفات ويجنب كتابة موارد مهمة تحويل واحدة فوق موارد أخرى.