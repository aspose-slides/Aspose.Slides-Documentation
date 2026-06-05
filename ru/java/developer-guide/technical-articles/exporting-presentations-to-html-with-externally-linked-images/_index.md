---
title: Экспорт презентаций в HTML с внешними связанными изображениями
type: docs
weight: 100
url: /ru/java/exporting-presentations-to-html-with-externally-linked-images/
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
- Java
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в HTML на Java с использованием Aspose.Slides, при этом изображения и другие ресурсы сохраняются как внешние связанные файлы."
---
## **Обзор**

По умолчанию Aspose.Slides экспортирует презентацию в автономный HTML‑файл. Изображения и другие ресурсы записываются непосредственно в HTML, обычно в виде данных Base64. Это удобно, когда нужен один переносимый файл, но не всегда является лучшим форматом для веб‑сайта, CMS или серверного конвейера преобразования.

Используйте внешне связанные ресурсы, когда вы хотите:

- уменьшить размер HTML‑документа;
- кешировать изображения, шрифты, аудио или видео отдельно в браузере или CDN;
- проверять, заменять, сжимать или постобрабатывать сгенерированные ресурсы после экспорта;
- сохранять структуру вывода ближе к тому, что ожидает веб‑приложение.

Для общего процесса конвертации HTML см. [Convert PowerPoint Presentations to HTML](/slides/ru/java/convert-powerpoint-to-html/). Эта статья сосредоточена на части экспорта, связанной с ресурсами.

## **Как работает экспорт со связанными ресурсами**

[ILinkEmbedController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) позволяет вашему приложению решать для каждого ресурса, встраивать ли данные в HTML или сохранять их внешне и записывать ссылку.

Интерфейс содержит три метода:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) определяет, должен ли ресурс быть связан или встроен.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) возвращает URL, который будет записан в сгенерированный HTML или в другой связанный ресурс.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) записывает данные связанного ресурса на диск или в другое хранилище.

Путь в файловой системе и URL в браузере — отдельные аспекты. Например, в примере ниже файлы ресурсов записываются в `html-output/assets` на диске, а HTML содержит относительные URL, такие как `assets/resource-1.svg`. Браузер разрешает эти URL относительно файла, содержащего ссылку. Поэтому ссылка из `presentation.html` на SVG‑файл использует `assets/resource-1.svg`, а ссылка из этого SVG‑файла на изображение, сохранённое в той же папке `assets`, использует `resource-4.jpg`.

## **Экспорт HTML с связанными ресурсами**

Следующий пример на Java создаёт выходной каталог, сохраняет туда HTML‑файл и хранит связанные ресурсы в подпапке `assets`. Контроллер связывает общие изображения, шрифты, аудио, видео и CSS‑ресурсы, когда Aspose.Slides предоставляет или может вывести безопасное расширение файла. Неопознанные ресурсы остаются встроенными.

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

После экспорта в выходной папке будет такая структура:

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

Точные файлы зависят от содержания презентации и параметров экспорта. Например, растровые изображения обычно экспортируются как JPEG или PNG. Aspose.Slides может выбрать иной кодек изображения, чем использовался в исходной презентации, если это даёт меньший или более подходящий файл. Изображения с прозрачностью экспортируются как PNG.

## **Выбор URL‑ов для развертывания**

Пример использует относительный префикс URL: `assets/`. Если `presentation.html` открывается из `html-output/presentation.html`, браузер загружает `html-output/assets/resource-1.svg`.

Когда один связанный ресурс ссылается на другой связанный ресурс, пример использует параметр `referrer` в [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) и возвращает только имя файла. Например, если `resource-1.svg` и `resource-4.jpg` находятся в папке `assets`, SVG‑файл должен ссылаться на `resource-4.jpg`, а не на `assets/resource-4.jpg`.

Используйте иной префикс URL, когда файлы развертываются в другом месте:

- Используйте `assets/`, когда каталог ассетов находится рядом с HTML‑файлом.
- Используйте `../assets/`, когда каталог ассетов находится на один уровень выше HTML‑файла.
- Используйте `https://cdn.example.com/presentations/job-123/assets/`, когда файлы загружены на CDN или статический файловый сервер.

URL, возвращаемый [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/), должен совпадать с окончательным расположением файла, записанного [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/). В серверных приложениях используйте уникальный каталог вывода или префикс объектного хранилища для каждой задачи конвертации, чтобы избежать перезаписи файлов от другого экспорта.

## **Когда следует встраивать вместо этого**

Встроенный Base64‑HTML всё ещё полезен, когда вывод должен быть одним файлом, например вложением в письмо, офлайн‑просмотром или документом, который будет перемещён без поддерживающей папки ассетов. Связанные ресурсы лучше подходят, когда HTML будет обслуживаться веб‑приложением, храниться в CMS, оптимизироваться конвейером сборки или кэшироваться браузерами независимо от HTML.

## **FAQ**

**Can I externalize only images and keep other resources embedded?**

Да. В [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) возвращайте `LinkEmbedDecision.Link` только для тех типов контента, которые вы хотите сохранять как отдельные файлы, и `LinkEmbedDecision.Embed` для всего остального.

**Why does the exported image extension differ from the source presentation?**

Aspose.Slides может перекодировать растровые изображения при экспорте в HTML, чтобы уменьшить размер или улучшить совместимость с браузерами. Например, изображение из исходного файла может быть записано как JPEG или PNG в зависимости от полученного результата.

**Do relative URLs work after I move the HTML file?**

Относительные URL работают только при сохранении той же относительной структуры папок. Если HTML ссылается на `assets/resource-1.png`, папка `assets` должна оставаться рядом с HTML‑файлом, если только вы не генерируете другой префикс URL.

**Should server applications reuse the same output folder?**

Нет. Используйте уникальный каталог вывода или префикс хранилища для каждой задачи конвертации. Это предотвращает столкновение имён файлов и перезапись ресурсов, созданных другим экспортом.