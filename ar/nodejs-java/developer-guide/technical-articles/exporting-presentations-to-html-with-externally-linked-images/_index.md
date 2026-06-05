---
title: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجياً
type: docs
weight: 100
url: /ar/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
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
- صورة مرتبطة خارجياً
- مورد مرتبط
- مورد خارجي
- JavaScript
- Node.js
- Aspose.Slides
description: "تصدير عروض PowerPoint وOpenDocument إلى HTML في JavaScript باستخدام Aspose.Slides لـ Node.js عبر Java مع حفظ الصور والموارد الأخرى كملفات مرتبطة خارجياً."
---
## **نظرة عامة**

بشكل افتراضي، تقوم Aspose.Slides بتصدير العرض التقديمي إلى ملف HTML مستقل. تُكتب الصور والموارد الأخرى مباشرةً في HTML، عادةً كبيانات Base64. هذا ملائم عندما تحتاج إلى ملف واحد محمول، لكنه ليس دائماً أفضل تنسيق لموقع ويب أو نظام إدارة محتوى أو خط أنابيب تحويل من جانب الخادم.

استخدم الموارد المرتبطة خارجيًا عندما ترغب في:
- تقليل حجم مستند HTML;
- تخزين الصور أو الخطوط أو الصوت أو الفيديو مؤقتًا بشكل منفصل في المتصفح أو CDN;
- فحص، استبدال، ضغط، أو معالجة الموارد المُولدة بعد التصدير;
- الحفاظ على بنية الناتج أقرب إلى ما تتوقعه تطبيقات الويب.

للحصول على سير عمل التحويل العام إلى HTML، راجع [تحويل عروض PowerPoint إلى HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/). يركز هذا المقال على جزء ربط الموارد أثناء التصدير.

## **كيف يعمل تصدير الموارد المرتبطة**

يتيح وكيل Java لـ [ILinkEmbedController](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/) لتطبيقك اتخاذ القرار، موردًا بعد مورد، ما إذا كان المصدّر يضمّن البيانات داخل HTML أو يحفظها خارجيًا ويكتب رابطًا.

يحتوي المتحكم على ثلاث طرق:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/) يحدد ما إذا كان يجب ربط المورد أو تضمينه.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/) يعيد عنوان URL الذي سيُكتب في HTML المُولَّد أو إلى مورد مرتبط آخر.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/) يكتب بيانات المورد المرتبط إلى القرص أو إلى هدف تخزين آخر.

مسار نظام الملفات وعنوان URL الخاص بالمتصفح هما مسألان منفصلان. على سبيل المثال، يكتب المثال أدناه ملفات الموارد إلى `html-output/assets` على القرص، بينما يحتوي HTML على عناوين URL نسبية مثل `assets/resource-1.svg`. يقوم المتصفح بحل هذه العناوين نسبةً إلى الملف الذي يحتوي على الرابط. لذلك، يستخدم الرابط من `presentation.html` إلى ملف SVG `assets/resource-1.svg`، بينما يستخدم الرابط من ذلك الملف SVG إلى صورة محفوظة في نفس مجلد `assets` العنوان `resource-4.jpg`.

## **تصدير HTML مع الموارد المرتبطة**

يُنشئ مثال JavaScript التالي دليل إخراج، يحفظ ملف HTML هناك، ويخزن الموارد المرتبطة في دليل فرعي `assets`. يقوم المتحكم بربط الموارد الشائعة من صور، خطوط، صوت، فيديو، وCSS عندما توفر Aspose.Slides أو يمكنها استنتاج امتداد ملف آمن. الموارد التي لا يتم التعرف عليها تظل مضمَّنة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
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

الملفات الدقيقة تعتمد على محتوى العرض التقديمي وخيارات التصدير. على سبيل المثال، تُصدَّر الصور النقطية عادةً كـ JPEG أو PNG. قد تختار Aspose.Slides ترميز صورة مختلف عن المستخدم في العرض الأصلي عندما ينتج ملفًا أصغر أو أكثر ملاءمة. تُصدَّر الصور ذات الشفافية كـ PNG.

## **اختيار عناوين URL للنشر**

يستخدم المثال بادئة URL نسبية: `assets/`. إذا تم فتح `presentation.html` من `html-output/presentation.html`، يحمل المتصفح `html-output/assets/resource-1.svg`.

عندما يشير مورد مرتبط إلى مورد مرتبط آخر، يستخدم المثال المعامل `referrer` في [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/) ويعيد فقط اسم الملف. على سبيل المثال، إذا كان كل من `resource-1.svg` و `resource-4.jpg` في مجلد `assets`، يجب أن يشير ملف SVG إلى `resource-4.jpg`، وليس إلى `assets/resource-4.jpg`.

استخدم بادئة URL مختلفة عندما يتم نشر الملفات في مكان آخر:
- استخدم `assets/` عندما يكون دليل الأصول بجوار ملف HTML.
- استخدم `../assets/` عندما يكون دليل الأصول مستوى واحد فوق ملف HTML.
- استخدم `https://cdn.example.com/presentations/job-123/assets/` عندما يتم تحميل الملفات إلى CDN أو خادم ملفات ثابت.

يجب أن يتطابق عنوان URL الذي تُعيده [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/) مع الموقع النهائي للنشر للملف الذي يكتبه [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/). في تطبيقات الخادم، استخدم دليل إخراج فريد أو بادئة تخزين كائن لكل وظيفة تحويل لتجنب الكتابة فوق الملفات من تصدير آخر.

## **متى يجب التضمين بدلاً من ذلك**

لا يزال HTML المدمج كـ Base64 مفيدًا عندما يجب أن يكون الناتج ملفًا واحدًا، مثل مرفق بريد إلكتروني، معاينة دون اتصال، أو مستند يُنقل دون مجلد أصول داعم. الموارد المرتبطة تُعدّ خيارًا أفضل عندما يتم تقديم HTML عبر تطبيق ويب، أو تخزينه في نظام إدارة محتوى، أو تحسينه عبر خط أنابيب بناء، أو تخزينه مؤقتًا في المتصفحات بشكل مستقل عن HTML.

## **الأسئلة المتكررة**

**هل يمكنني استخراج الصور فقط وإبقاء الموارد الأخرى مضمَّنة؟**

نعم. في [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ilinkembedcontroller/)، أعد `LinkEmbedDecision.Link` فقط لأنواع المحتوى التي تريد حفظها كملفات منفصلة، وأعد `LinkEmbedDecision.Embed` لبقية الأنواع.

**لماذا يختلف امتداد الصورة المصدَّرة عن العرض التقديمي الأصلي؟**

قد تقوم Aspose.Slides بإعادة ترميز الصور النقطية أثناء تصدير HTML لتحسين الحجم أو توافق المتصفح. على سبيل المثال، قد تُكتب صورة من الملف الأصلي كـ JPEG أو PNG اعتمادًا على النتيجة المعروضة.

**هل تعمل عناوين URL النسبية بعد نقل ملف HTML؟**

تعمل عناوين URL النسبية فقط عندما يتم الحفاظ على بنية المجلدات النسبية نفسها. إذا كان HTML يشير إلى `assets/resource-1.png`، يجب أن يبقى مجلد `assets` بجوار ملف HTML ما لم تقم بإنشاء بادئة URL مختلفة.

**هل يجب على تطبيقات الخادم إعادة استخدام نفس مجلد الإخراج؟**

لا. استخدم دليل إخراج فريد أو بادئة تخزين لكل وظيفة تحويل. هذا يجنب تصادم أسماء الملفات ويمنع تصديرًا واحدًا من الكتابة فوق الموارد التي تم إنشاؤها بواسطة تصدير آخر.