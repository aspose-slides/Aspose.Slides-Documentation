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

По умолчанию Aspose.Slides экспортирует презентацию в автономный HTML‑файл. Изображения и другие ресурсы записываются непосредственно в HTML, обычно как данные Base64. Это удобно, когда нужен один портативный файл, но не всегда является лучшим форматом для веб‑просмотра, CMS или конвейера серверного преобразования, который позже публикует результат.

Используйте внешние связанные ресурсы, когда вы хотите:

- уменьшить размер HTML‑документа;
- кешировать изображения, шрифты, аудио или видео отдельно в браузере или CDN;
- проверять, заменять, сжимать или пост‑обрабатывать сгенерированные ресурсы после экспорта;
- сохранять структуру вывода ближе к тому, что ожидает веб‑приложение.

Для общего процесса конвертации HTML см. в [Конвертировать презентации PowerPoint в HTML](/slides/ru/androidjava/convert-powerpoint-to-html/). Эта статья сосредоточена на части экспорта, связанной с ресурсами.

## **Как работает экспорт связанных ресурсов**

[ILinkEmbedController](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/) позволяет вашему приложению решать для каждого ресурса, будет ли экспортёр вставлять данные в HTML или сохранять их внешне и писать ссылку.

У интерфейса есть три метода:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/) определяет, следует ли ресурс ссылать или внедрять.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/) возвращает URL, который будет записан в сгенерированный HTML или в другой связанный ресурс.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/) записывает данные связанного ресурса на диск или в другое хранилище.

Путь в файловой системе и URL в браузере — отдельные понятия. Например, в образце ниже файлы ресурсов записываются в `html-output/assets` в файловом хранилище приложения, тогда как HTML содержит относительные URL, такие как `assets/resource-1.svg`. Браузер разрешает эти URL относительно файла, содержащего ссылку. Поэтому ссылка из `presentation.html` к SVG‑файлу использует `assets/resource-1.svg`, а ссылка из этого SVG‑файла к изображению, сохранённому в той же папке `assets`, использует `resource-4.jpg`.

## **Экспорт HTML с связанными ресурсами**

Следующий пример Android Java создаёт выходной каталог, сохраняет туда HTML‑файл и помещает связанные ресурсы в подпапку `assets`. Передайте каталог, принадлежащий приложению, например `context.getFilesDir()`, в параметр `applicationFilesDirectory`. Код избегает API `java.nio.file`, поэтому остаётся совместимым с Android `minSdk` 19.

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

После экспорта выходная папка имеет следующую структуру:

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

Точные файлы зависят от содержимого презентации и параметров экспорта. Например, растровые изображения обычно экспортируются как JPEG или PNG. Aspose.Slides может выбрать иной кодек изображения, отличный от используемого в исходной презентации, если это даёт меньший или более подходящий файл. Изображения с прозрачностью экспортируются как PNG.

## **Выбор URL‑ов для развертывания**

Образец использует относительный префикс URL: `assets/`. Если `presentation.html` открывается из `html-output/presentation.html`, браузер загрузит `html-output/assets/resource-1.svg`.

Когда один связанный ресурс ссылается на другой связанный ресурс, образец использует параметр `referrer` в [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/) и возвращает только имя файла. Например, если `resource-1.svg` и `resource-4.jpg` находятся в папке `assets`, SVG‑файл должен ссылаться на `resource-4.jpg`, а не на `assets/resource-4.jpg`.

Используйте иной префикс URL, когда файлы развертываются в другом месте:

- Используйте `assets/`, когда каталог ресурсов находится рядом с HTML‑файлом.
- Используйте `../assets/`, когда каталог ресурсов расположен на один уровень выше HTML‑файла.
- Используйте `https://cdn.example.com/presentations/job-123/assets/`, когда файлы загружаются в CDN или на статический файловый сервер.

URL, возвращаемый [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/), должен совпадать с окончательным местом размещения файла, записанного [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/). В Android‑приложениях используйте хранилище, специфичное для приложения, каталог кеша или каталог, полученный через Storage Access Framework, в соответствии с вашим рабочим процессом публикации. В серверных приложениях используйте уникальный выходной каталог или префикс в объектном хранилище для каждой задачи конвертации, чтобы избежать перезаписи файлов от другого экспорта.

## **Когда следует встраивать вместо этого**

Встроенный в HTML Base64‑контент всё ещё полезен, когда вывод должен быть единственным файлом, например, вложением письма, офлайн‑предпросмотром или документом, который будет перемещён без сопровождающей папки ресурсов. Связанные ресурсы лучше подходят, когда HTML будет обслуживаться веб‑приложением, храниться в CMS, оптимизироваться конвейером сборки или кешироваться браузерами независимо от HTML.

## **FAQ**

**Могу ли я вынести наружу только изображения и оставить другие ресурсы встроенными?**

Да. В [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ilinkembedcontroller/) возвращайте `Link` из [LinkEmbedDecision](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/linkembeddecision/) только для тех типов контента, которые хотите сохранять отдельными файлами, а для остальных возвращайте `Embed`.

**Почему расширение экспортированного изображения отличается от исходной презентации?**

Aspose.Slides может перекодировать растровые изображения во время экспорта HTML, чтобы уменьшить размер или улучшить совместимость с браузерами. Например, изображение из исходного файла может быть записано как JPEG или PNG в зависимости от результирующего отображения.

**Работают ли относительные URL после перемещения HTML‑файла?**

Относительные URL работают только при сохранении той же относительной структуры папок. Если HTML ссылается на `assets/resource-1.png`, папка `assets` должна оставаться рядом с HTML‑файлом, если только вы не генерируете иной префикс URL.

**Могу ли я записывать ресурсы во внешнее публичное хранилище на Android?**

Да, если у вашего приложения есть действительный путь назначения и модель разрешений для целевой версии Android. Для сгенерированного HTML, используемого только вашим приложением, обычно проще использовать файлы, специфичные для приложения, или каталоги кеша. Для пользовательски видимого вывода используйте расположение, выбранное пользователем, или иной подход к хранению, соответствующий вашему приложению.

**Должны ли серверные приложения переиспользовать один и тот же выходной каталог?**

Нет. Используйте уникальный выходной каталог или префикс хранилища для каждой задачи конвертации. Это предотвращает столкновения имён файлов и перезапись ресурсов, созданных другим экспортом.