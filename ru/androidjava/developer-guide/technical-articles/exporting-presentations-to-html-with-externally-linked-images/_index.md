---
title: Экспорт презентаций в HTML с внешними связанными изображениями
type: docs
weight: 100
url: /ru/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- Android
- Java
- Aspose.Slides
description: "Экспорт презентаций PowerPoint и OpenDocument в HTML на Android с помощью Java, используя Aspose.Slides, при этом изображения и другие ресурсы сохраняются как внешние связанные файлы."
---
## **Обзор**

По умолчанию Aspose.Slides экспортирует презентацию в автономный HTML‑файл. Изображения и другие ресурсы записываются непосредственно в HTML, обычно в виде данных Base64. Это удобно, когда нужен один переносимый файл, но не всегда является лучшим форматом для веб‑просмотра, CMS или конвейера серверного преобразования, который позже публикует результат.

Используйте внешне связанные ресурсы, когда нужно:

- снизить размер HTML‑документа;
- кэшировать изображения, шрифты, аудио или видео отдельно в браузере или CDN;
- проверить, заменить, сжать или выполнить пост‑обработку сгенерированных ресурсов после экспорта;
- сохранить структуру вывода ближе к тому, что ожидает веб‑приложение.

Для общего рабочего процесса конвертации в HTML см. [Преобразование презентаций PowerPoint в HTML](/slides/ru/androidjava/convert-powerpoint-to-html/). Эта статья сосредоточена на части экспорта, связанной с ресурсными ссылками.

## **Как работает экспорт связанных ресурсов**

[ILinkEmbedController](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/) позволяет вашему приложению решать для каждого ресурса, следует ли встраивать данные в HTML или сохранять их внешне и записывать ссылку.

Интерфейс содержит три метода:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/) определяет, должен ли ресурс быть связан или встроен.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/) возвращает URL, который будет записан в сгенерированный HTML или в другой связанный ресурс.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/) записывает данные связанного ресурса на диск или в другое хранилище.

Путь в файловой системе и URL в браузере — отдельные аспекты. Например, в образце ниже файлы ресурсов записываются в `html-output/assets` в файловом хранилище приложения, а HTML содержит относительные URL, такие как `assets/resource-1.svg`. Браузер разрешает эти URL относительно файла, содержащего ссылку. Поэтому ссылка из `presentation.html` на SVG‑файл выглядит как `assets/resource-1.svg`, а ссылка из этого SVG‑файла на изображение, сохранённое в той же папке `assets`, выглядит как `resource-4.jpg`.

## **Экспорт HTML со связанными ресурсами**

Следующий пример на Android Java создаёт каталог вывода, сохраняет в нём HTML‑файл и хранит связанные ресурсы в подпапке `assets`. Передайте каталог, принадлежащий приложению, например `context.getFilesDir()`, в параметр `applicationFilesDirectory`. Код избегает API `java.nio.file`, поэтому остаётся совместимым с Android `minSdk` 19.

Контроллер связывает общие изображения, шрифты, аудио, видео и CSS‑ресурсы, когда Aspose.Slides предоставляет или может вывести безопасное расширение файла. Неопознанные ресурсы остаются встроенными.

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

После экспорта в папке вывода будет такая структура:

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

Точные файлы зависят от содержания презентации и параметров экспорта. Например, растровые изображения обычно экспортируются как JPEG или PNG. Aspose.Slides может выбрать иной кодек изображения, чем использовался в исходной презентации, если это приводит к меньшему или более подходящему файлу. Изображения с прозрачностью экспортируются как PNG.

## **Выбор URL для развертывания**

В образце используется относительный префикс URL: `assets/`. Если `presentation.html` открывается из `html-output/presentation.html`, браузер загрузит `html-output/assets/resource-1.svg`.

Когда один связанный ресурс ссылается на другой, образец использует параметр `referrer` в [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/) и возвращает только имя файла. Например, если `resource-1.svg` и `resource-4.jpg` находятся в папке `assets`, SVG‑файл должен ссылаться на `resource-4.jpg`, а не на `assets/resource-4.jpg`.

Используйте иной префикс URL, когда файлы размещаются в другом месте:

- Используйте `assets/`, когда каталог ресурсов находится рядом с HTML‑файлом.
- Используйте `../assets/`, когда каталог ресурсов расположен на уровень выше HTML‑файла.
- Используйте `https://cdn.example.com/presentations/job-123/assets/`, когда файлы загружаются в CDN или на статический файловый сервер.

URL, возвращаемый [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/), должен соответствовать окончательному месту размещения файла, записанного [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/). В Android‑приложениях используйте хранилище, специфичное для приложения, каталог кэша или каталог, полученный через Storage Access Framework, в зависимости от вашего рабочего процесса публикации. В серверных приложениях используйте уникальный каталог вывода или префикс в объектном хранилище для каждой задачи конвертации, чтобы избежать перезаписи файлов от другого экспорта.

## **Когда следует встраивать вместо ссылок**

Встроенный Base64‑HTML всё ещё полезен, когда результат должен быть одним файлом, например вложением письма, офлайн‑предпросмотром или документом, который будет перемещён без поддерживающей папки ресурсов. Связанные ресурсы лучше подходят, когда HTML будет обслуживаться веб‑приложением, храниться в CMS, оптимизироваться сборочным конвейером или кэшироваться браузерами независимо от HTML.

## **Вопросы и ответы**

**Могу ли я вынести наружу только изображения и оставить другие ресурсы встроенными?**

Да. В [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/linkembeddecision/) возвращайте `Link` из [LinkEmbedDecision](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/linkembeddecision/) только для тех типов контента, которые хотите сохранять отдельными файлами, и возвращайте `Embed` для всего остального.

**Почему расширение экспортированного изображения отличается от исходной презентации?**

Aspose.Slides может перекодировать растровые изображения во время экспорта в HTML, чтобы уменьшить размер или повысить совместимость с браузерами. Например, изображение из исходного файла может быть записано как JPEG или PNG в зависимости от полученного результата.

**Работают ли относительные URL после перемещения HTML‑файла?**

Относительные URL работают только при сохранении той же относительной структуры папок. Если HTML ссылается на `assets/resource-1.png`, папка `assets` должна оставаться рядом с HTML‑файлом, если вы не генерируете иной префикс URL.

**Могу ли я записывать ресурсы во внешнее публичное хранилище на Android?**

Да, если у вашего приложения есть действительный путь назначения и модель разрешений для целевой версии Android. Для сгенерированного HTML, используемого только вашим приложением, обычно проще использовать файлы, специфичные для приложения, или каталоги кэша. Для пользовательского вывода используйте пользовательски выбранное место или другой подход к хранению, который подходит вашему приложению.

**Должны ли серверные приложения повторно использовать один и тот же каталог вывода?**

Нет. Используйте уникальный каталог вывода или префикс хранилища для каждой задачи конвертации. Это предотвращает конфликты имён файлов и защищает от перезаписи ресурсов, созданных другим экспортом.