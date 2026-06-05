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
description: "Экспорт презентаций PowerPoint и OpenDocument в HTML на Java с использованием Aspose.Slides, при сохранении изображений и других ресурсов во внешние связанные файлы."
---
## **Обзор**

По умолчанию Aspose.Slides экспортирует презентацию в самодостаточный HTML‑файл. Изображения и другие ресурсы записываются напрямую в HTML, обычно в виде данных Base64. Это удобно, когда нужен один переносимый файл, но не всегда лучший вариант для веб‑сайта, CMS или конвейера серверного преобразования.

Используйте внешне связанные ресурсы, когда требуется:

- уменьшить размер HTML‑документа;
- кэшировать изображения, шрифты, аудио или видео отдельно в браузере или CDN;
- проверять, заменять, сжимать или пост‑обрабатывать сгенерированные ресурсы после экспорта;
- сохранить структуру вывода ближе к ожидаемой веб‑приложением.

Для общего рабочего процесса конвертации HTML см. [Преобразование презентаций PowerPoint в HTML](/slides/ru/java/convert-powerpoint-to-html/). Эта статья сосредоточена на части экспорта, связанной с ресурсами.

## **Как работает экспорт связанных ресурсов**

[ILinkEmbedController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) позволяет вашему приложению решать для каждого ресурса, будет ли экспортер встраивать данные в HTML или сохранять их внешне и писать ссылку.

Интерфейс имеет три метода:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) решает, следует ли ресурс связывать или встраивать.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) возвращает URL, который будет записан в сгенерированный HTML или в другой связанный ресурс.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) записывает данные связанного ресурса на диск или в другое место хранения.

Путь в файловой системе и URL в браузере — это отдельные аспекты. Например, в приведённом ниже примере файлы ресурсов записываются в `html-output/assets` на диске, а HTML содержит относительные URL‑ы вроде `assets/resource-1.svg`. Браузер разрешает эти URL‑ы относительно файла, в котором находится ссылка. Поэтому ссылка из `presentation.html` к SVG‑файлу использует `assets/resource-1.svg`, а ссылка из этого SVG‑файла к изображению, сохранённому в той же папке `assets`, использует `resource-4.jpg`.

## **Экспорт HTML с связанными ресурсами**

Следующий пример на Java создаёт выходной каталог, сохраняет туда HTML‑файл и помещает связанные ресурсы в подпапку `assets`. Контроллер связывает обычные изображения, шрифты, аудио, видео и CSS‑ресурсы, когда Aspose.Slides предоставляет или может вывести безопасное расширение файла. Нераспознанные ресурсы остаются встроенными.

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

Точные файлы зависят от содержимого презентации и параметров экспорта. Например, растровые изображения обычно экспортируются как JPEG или PNG. Aspose.Slides может выбрать другой кодек изображения, чем использовался в исходной презентации, если это приводит к меньшему или более подходящему файлу. Изображения с прозрачностью экспортируются как PNG.

## **Выбор URL‑ов для развёртывания**

В примере используется относительный префикс URL: `assets/`. Если `presentation.html` открывается из `html-output/presentation.html`, браузер загружает `html-output/assets/resource-1.svg`.

Когда один связанный ресурс ссылается на другой, пример использует параметр `referrer` в [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) и возвращает только имя файла. Например, если `resource-1.svg` и `resource-4.jpg` находятся в папке `assets`, SVG‑файл должен ссылаться на `resource-4.jpg`, а не на `assets/resource-4.jpg`.

Используйте другой префикс URL, когда файлы развёртываются в другом месте:

- Используйте `assets/`, когда каталог с ресурсами находится рядом с HTML‑файлом.
- Используйте `../assets/`, когда каталог с ресурсами на один уровень выше HTML‑файла.
- Используйте `https://cdn.example.com/presentations/job-123/assets/`, когда файлы загружены в CDN или на статический файловый сервер.

URL, возвращаемый [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/), должен соответствовать окончательному месту размещения файла, записанного [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/). В серверных приложениях используйте уникальный выходной каталог или префикс в объектном хранилище для каждой задачи конвертации, чтобы избежать перезаписи файлов от другого экспорта.

## **Когда лучше встраивать**

Встроенный Base64‑HTML всё ещё полезен, когда вывод должен быть одним файлом, например, вложением письма, офлайн‑просмотром или документом, который будет перемещаться без папки с ресурсами. Связанные ресурсы лучше подходят, когда HTML будет обслуживаться веб‑приложением, храниться в CMS, оптимизироваться конвейером сборки или кэшироваться браузерами независимо от HTML.

## **FAQ**

**Можно ли вынести наружу только изображения и оставить остальные ресурсы встроенными?**

Да. В [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) возвращайте `LinkEmbedDecision.Link` только для тех типов содержимого, которые хотите сохранять в отдельные файлы, а `LinkEmbedDecision.Embed` — для всего остального.

**Почему расширение экспортированного изображения отличается от исходной презентации?**

Aspose.Slides может пере‑кодировать растровые изображения при экспорте в HTML, чтобы улучшить размер или совместимость с браузером. Например, изображение из исходного файла может быть записано как JPEG или PNG в зависимости от результата рендеринга.

**Работают ли относительные URL после перемещения HTML‑файла?**

Относительные URL работают только при сохранении той же относительной структуры папок. Если HTML ссылается на `assets/resource-1.png`, папка `assets` должна оставаться рядом с HTML‑файлом, если только вы не генерируете другой префикс URL.

**Должны ли серверные приложения повторно использовать один и тот же выходной каталог?**

Нет. Используйте уникальный выходной каталог или префикс хранения для каждой задачи конвертации. Это предотвращает конфликты имён файлов и перезапись ресурсов, созданных другим экспортом.
