---
title: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا
type: docs
weight: 100
url: /ar/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تصدير الشريحة
- تصدير PPT
- تصدير PPTX
- تصدير ODP
- PowerPoint إلى HTML
- OpenDocument إلى HTML
- العرض التقديمي إلى HTML
- الشريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- ODP إلى HTML
- صورة مرتبطة
- صورة مرتبطة خارجيًا
- مورد مرتبط
- مورد خارجي
- PHP
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML في PHP عبر Java باستخدام Aspose.Slides مع حفظ الصور والموارد الأخرى كملفات مرتبطة خارجيًا."
---
## **نظرة عامة**

بشكل افتراضي، تقوم Aspose.Slides بتصدير عرض تقديمي إلى ملف HTML متكامل. تُكتب الصور والموارد الأخرى مباشرةً في HTML، عادةً كبيانات Base64. هذا مفيد عندما تحتاج إلى ملف واحد قابل للنقل، لكنه ليس دائمًا الصيغة المثلى لموقع ويب أو نظام إدارة محتوى أو خط أنابيب تحويل من جانب الخادم.

استخدم الموارد المرتبطة خارجيًا عندما تريد:
- تقليل حجم مستند HTML;
- تخزين الصور أو الخطوط أو الصوت أو الفيديو مؤقتًا بشكل منفصل في المتصفح أو CDN;
- فحص، استبدال، ضغط، أو ما بعد معالجة الموارد المُولدة بعد التصدير;
- الحفاظ على بنية المخرجات أقرب إلى ما تتوقعه تطبيقات الويب.

للحصول على سير عمل التحويل العام إلى HTML، راجع [Convert PowerPoint Presentations to HTML](/slides/ar/php-java/convert-powerpoint-to-html/). يركز هذا المقال على جزء ربط الموارد في عملية التصدير.

## **كيف يعمل تصدير الموارد المرتبطة**

يمكن لـ [HtmlOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/htmloptions/) استخدام وحدة تحكم مخصصة للربط/التضمين عندما تقوم Aspose.Slides بتصدير عرض تقديمي إلى HTML. في PHP عبر Java، عادةً ما يُنفّذ هذا السيناريو بفئة مساعد Java صغيرة. قم بترجمة تلك الفئة، أضفها إلى مسار فئة PHP Java Bridge، وأنشئ كائنًا منها في PHP باستخدام `new Java(...)`.

تقرر فئة المساعد، لكل مورد على حدة، ما إذا كان المُصدّر سيضمّن البيانات في HTML أو سيحفظها خارجيًا ويكتب رابطًا. تحتاج إلى ثلاث طرق رد نداء:
- `ExternalResourceController.getObjectStoringLocation` يحدد ما إذا كان يجب ربط المورد أو تضمينه.
- `ExternalResourceController.getUrl` يُعيد عنوان URL الذي سيُكتب في HTML المُنشأ أو في مورد مرتبط آخر.
- `ExternalResourceController.saveExternal` يكتب بيانات المورد المرتبط إلى القرص أو إلى هدف تخزين آخر.

مسار نظام الملفات وعنوان URL للمتصفح هما مسألان منفصلان. على سبيل المثال، يكتب العينة أدناه ملفات الموارد إلى `html-output/assets` على القرص، بينما يحتوي HTML على عناوين URL نسبية مثل `assets/resource-1.svg`. يقوم المتصفح بحل هذه العناوين نسبةً إلى الملف الذي يحتوي على الرابط. وبالتالي، يستخدم الرابط من `presentation.html` إلى ملف SVG العنوان `assets/resource-1.svg`، بينما يستخدم الرابط من ملف SVG إلى صورة محفوظة في نفس مجلد `assets` العنوان `resource-4.jpg`.

## **إنشاء فئة المساعد Java**

أنشئ فئة Java مثل `com.example.slides.ExternalResourceController`، وترجمها مع Aspose.Slides for Java ضمن مسار الفئة، واجعل الفئة المترجمة أو ملف JAR متاحًا لـ PHP Java Bridge.

الفئة المساعدة أدناه تربط الموارد الشائعة من صور، خطوط، صوت، فيديو، وCSS عندما توفر Aspose.Slides أو يمكنها استنتاج امتداد ملف آمن. الموارد غير المعروفة تبقى مضمَّنة.

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

## **تصدير HTML مع الموارد المرتبطة**

يقوم الشيفرة PHP التالية بإنشاء دليل إخراج، يحفظ ملف HTML هناك، ويخزن الموارد المرتبطة في دليل فرعي `assets`. يجمع بين [HtmlOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/htmloptions/)، [SVGOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideimageformat/)، و[SaveFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/saveformat/) لعملية التصدير.

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

بعد التصدير، يحتوي مجلد الإخراج على هذه البنية:

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

الملفات الدقيقة تعتمد على محتوى العرض التقديمي وخيارات التصدير. على سبيل المثال، عادةً ما تُصدر الصور النقطية كـ JPEG أو PNG. قد تختار Aspose.Slides ترميز صورة مختلف عن المستخدم في العرض الأصلي إذا أدى ذلك إلى ملف أصغر أو أكثر ملاءمة. تُصدر الصور ذات الشفافية كـ PNG.

## **اختيار عناوين URL للنشر**

تستخدم العينة بادئة URL نسبية: `assets/`. إذا تم فتح `presentation.html` من `html-output/presentation.html`، يقوم المتصفح بتحميل `html-output/assets/resource-1.svg`.

عندما يشير مورد مرتبط إلى مورد مرتبط آخر، تستخدم العينة معامل `referrer` في `ExternalResourceController.getUrl` وتُعيد اسم الملف فقط. على سبيل المثال، إذا كان كل من `resource-1.svg` و `resource-4.jpg` في مجلد `assets`, يجب على ملف SVG الإشارة إلى `resource-4.jpg`، وليس إلى `assets/resource-4.jpg`.

استخدم بادئة URL مختلفة عندما تُنشر الملفات في مكان آخر:
- استخدم `assets/` عندما يكون دليل الأصول بجوار ملف HTML.
- استخدم `../assets/` عندما يكون دليل الأصول مستوى واحد فوق ملف HTML.
- استخدم `https://cdn.example.com/presentations/job-123/assets/` عندما يتم رفع الملفات إلى CDN أو خادم ملفات ثابتة.

يجب أن يتطابق عنوان URL الذي تُعيده `ExternalResourceController.getUrl` مع الموقع النهائي للملف الذي يكتبه `ExternalResourceController.saveExternal`. في تطبيقات الخادم، استخدم دليل إخراج فريد أو بادئة تخزين كائنات لكل وظيفة تحويل لتجنب الكتابة فوق ملفات تصدير أخرى.

## **متى يجب التضمين بدلاً من ذلك**

ما يزال HTML المضمَّن كـ Base64 مفيدًا عندما يكون الإخراج ملفًا واحدًا، مثل مرفق بريد إلكتروني، معاينة دون اتصال، أو مستند سيُنقل دون مجلد أصول داعم. الموارد المرتبطة تكون أنسب عندما يُقدَّم HTML عبر تطبيق ويب، يُخزن في نظام إدارة محتوى، يُحسّن عبر خط أنابيب بناء، أو يُخزن مؤقتًا في المتصفحات بشكل مستقل عن HTML.

## **FAQ**

**هل يمكنني إخراج الصور فقط وجعل الموارد الأخرى مضمَّنة؟**

نعم. في `ExternalResourceController.getObjectStoringLocation`، أعد قيمة `Link` من [LinkEmbedDecision](https://reference.aspose.com/slides/ar/php-java/aspose.slides/linkembeddecision/) فقط لأنواع المحتوى التي ترغب في حفظها كملفات منفصلة، وأعد قيمة `Embed` للبقية.

**لماذا يختلف امتداد الصورة المُصدَّرة عن العرض التقديمي الأصلي؟**

قد تقوم Aspose.Slides بإعادة ترميز الصور النقطية أثناء تصدير HTML لتحسين الحجم أو توافق المتصفح. على سبيل المثال، قد تُكتب صورة من الملف الأصلي كـ JPEG أو PNG اعتمادًا على النتيجة المعروضة.

**هل تعمل عناوين URL النسبية بعد نقل ملف HTML؟**

تعمل عناوين URL النسبية فقط عندما يتم الحفاظ على نفس بنية المجلدات النسبية. إذا كان HTML يُشير إلى `assets/resource-1.png`، يجب أن يبقى مجلد `assets` بجوار ملف HTML ما لم تُنشئ بادئة URL مختلفة.

**هل ينبغي لتطبيقات الخادم إعادة استخدام نفس مجلد الإخراج؟**

لا. استخدم دليل إخراج فريد أو بادئة تخزين لكل وظيفة تحويل. هذا يُجنب تصادم أسماء الملفات ويمنع أن يكتب تصدير واحد فوق موارد تم إنشاؤها بواسطة تصدير آخر.