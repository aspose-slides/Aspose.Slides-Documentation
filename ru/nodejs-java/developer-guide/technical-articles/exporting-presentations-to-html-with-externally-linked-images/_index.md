---
title: Экспорт презентаций в HTML с внешними связанными изображениями
type: docs
weight: 100
url: /ru/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- экспорт слайда
- экспорт PPT
- экспорт PPTX
- экспорт ODP
- PowerPoint в HTML
- OpenDocument в HTML
- презентация в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- ODP в HTML
- связанное изображение
- внешнее связанное изображение
- связанный ресурс
- внешний ресурс
- JavaScript
- Node.js
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в HTML с помощью JavaScript, используя Aspose.Slides для Node.js через Java, при этом изображения и другие ресурсы сохраняются как внешние связанные файлы."
---
## **Обзор**

По умолчанию Aspose.Slides экспортирует презентацию в самодостаточный HTML‑файл. Изображения и другие ресурсы записываются непосредственно в HTML, обычно в виде данных Base64. Это удобно, когда нужен один переносимый файл, но не всегда является лучшим форматом для веб‑сайта, CMS или серверного конвейера преобразования.

Используйте внешние ссылки на ресурсы, когда нужно:

- уменьшить размер HTML‑документа;
- кэшировать изображения, шрифты, аудио или видео отдельно в браузере или CDN;
- просматривать, заменять, сжимать или постобрабатывать сгенерированные ресурсы после экспорта;
- сохранить структуру вывода ближе к тому, что ожидает веб‑приложение.

Для общего рабочего процесса конвертации в HTML см. [Convert PowerPoint Presentations to HTML](/slides/ru/nodejs-java/convert-powerpoint-to-html/). Эта статья сосредоточена на части экспорта, связанной с ресурсными ссылками.

## **Как работает экспорт со связанными ресурсами**

Java‑прокси для [ILinkEmbedController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) позволяет вашему приложению решать для каждого ресурса, будет ли экспортёр встраивать данные в HTML или сохранять их внешне и записывать ссылку.

Контроллер содержит три метода:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) определяет, следует ли ресурс связывать или встраивать.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) возвращает URL, который будет записан в сгенерированный HTML или в другой связанный ресурс.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) записывает данные связанного ресурса на диск или в другое хранилище.

Путь в файловой системе и URL в браузере — это отдельные понятия. Например, пример ниже записывает файлы ресурсов в `html-output/assets` на диске, тогда как HTML содержит относительные URL, такие как `assets/resource-1.svg`. Браузер разрешает эти URL относительно файла, содержащего ссылку. Поэтому ссылка из `presentation.html` на SVG‑файл выглядит как `assets/resource-1.svg`, а ссылка из этого SVG‑файла на изображение, сохранённое в той же папке `assets`, выглядит как `resource-4.jpg`.

## **Экспорт HTML со связанными ресурсами**

Следующий пример JavaScript создаёт выходную директорию, сохраняет туда HTML‑файл и помещает связанные ресурсы в подпапку `assets`. Контроллер связывает общие изображения, шрифты, аудио, видео и CSS‑ресурсы, когда Aspose.Slides предоставляет или может вывести безопасное расширение файла. Неопознанные ресурсы остаются встроенными.

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

После экспорта структура выходной папки будет такой:

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

Точные файлы зависят от содержания презентации и параметров экспорта. Например, растровые изображения обычно экспортируются как JPEG или PNG. Aspose.Slides может выбрать иной кодек изображения, чем использовался в исходной презентации, если это позволяет получить меньший или более подходящий файл. Изображения с прозрачностью экспортируются как PNG.

## **Выбор URL для размещения**

В примере используется относительный префикс URL: `assets/`. Если `presentation.html` открывается из `html-output/presentation.html`, браузер загрузит `html-output/assets/resource-1.svg`.

Когда один связанный ресурс ссылается на другой, пример использует параметр `referrer` в [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) и возвращает только имя файла. Например, если `resource-1.svg` и `resource-4.jpg` находятся в папке `assets`, SVG‑файл должен ссылаться на `resource-4.jpg`, а не на `assets/resource-4.jpg`.

Используйте иной префикс URL, когда файлы размещаются в другом месте:

- `assets/` — когда каталог активов находится рядом с HTML‑файлом.
- `../assets/` — когда каталог активов находится на уровень выше HTML‑файла.
- `https://cdn.example.com/presentations/job-123/assets/` — когда файлы загружены в CDN или на статический файловый сервер.

URL, возвращаемый [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/), должен соответствовать окончательному размещению файла, записанного [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/). В серверных приложениях используйте уникальную выходную директорию или префикс в объектном хранилище для каждой задачи конвертации, чтобы избежать перезаписи файлов от другого экспорта.

## **Когда лучше встраивать**

Встроенный Base64‑HTML всё ещё полезен, когда вывод должен быть единым файлом, например вложением письма, офлайн‑превью или документом, который будет перемещён без поддерживающей папки активов. Связанные ресурсы лучше подходят, когда HTML будет обслуживаться веб‑приложением, храниться в CMS, оптимизироваться конвейером сборки или кэшироваться браузерами независимо от HTML.

## **FAQ**

**Могу ли я вынести наружу только изображения и оставить остальные ресурсы встроенными?**

Да. В [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) возвращайте `LinkEmbedDecision.Link` только для тех типов контента, которые вы хотите сохранять в отдельных файлах, а для остальных — `LinkEmbedDecision.Embed`.

**Почему расширение экспортированного изображения отличается от исходной презентации?**

Aspose.Slides может перекодировать растровые изображения во время экспорта в HTML, чтобы уменьшить размер или улучшить совместимость с браузерами. Например, изображение из исходного файла может быть записано как JPEG или PNG в зависимости от полученного результата.

**Работают ли относительные URL после перемещения HTML‑файла?**

Относительные URL работают только при сохранении той же относительной структуры папок. Если HTML ссылается на `assets/resource-1.png`, папка `assets` должна оставаться рядом с HTML‑файлом, если только вы не генерируете иной префикс URL.

**Должны ли серверные приложения переиспользовать одну и ту же выходную папку?**

Нет. Используйте уникальную выходную директорию или префикс хранилища для каждой задачи конвертации. Это предотвращает конфликты имён файлов и перезапись ресурсов, сгенерированных другим экспортом.