---
title: Конвертировать презентации PowerPoint в Markdown на Java
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/java/convert-powerpoint-to-markdown/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в MD
- презентация в MD
- слайд в MD
- PPT в MD
- PPTX в MD
- сохранить PowerPoint как Markdown
- сохранить презентацию как Markdown
- сохранить слайд как Markdown
- сохранить PPT как MD
- сохранить PPTX как MD
- экспортировать PPT в MD
- экспортировать PPTX в MD
- Экспорт изображений в Markdown
- Ссылки на изображения CDN
- PowerPoint
- презентация
- Markdown
- Java
- Aspose.Slides
description: "Конвертировать презентации PPT и PPTX в Markdown на Java и контролировать, где сохраняются и как ссылаются экспортированные bitmap, metafile и SVG изображения."
---
## **Обзор**

Aspose.Slides for Java может конвертировать презентации PPT и PPTX в Markdown для документации, статических сайтов, миграции контента и процессов контроля версий. Вы можете выбрать вариант Markdown, управлять тем, как отображается содержимое слайдов, и решить, где сохранять экспортированные изображения и как генерируемый Markdown будет ссылаться на них.

По умолчанию экспорт в Markdown использует только текстовый вывод. Чтобы экспортировать визуальное содержимое, задайте тип экспорта с помощью метода [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownsaveoptions/) значением `Sequential` или `Visual` из перечисления [MarkdownExportType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownexporttype/). `Sequential` рендерит элементы слайда отдельно и последовательно, тогда как `Visual` сохраняет сгруппированные элементы вместе, чтобы сохранить их визуальные отношения. Значение `TextOnly` не генерирует ресурсы изображений, поэтому обратные вызовы сохранения изображений не вызываются в этом режиме.

## **Преобразовать презентацию в Markdown**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/), а затем вызовите метод [Presentation.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) с параметром `Md` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/).

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Выбрать вариант Markdown**

Метод [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownsaveoptions/) управляет спецификацией Markdown, используемой для вывода. Перечисление [Flavor](https://reference.aspose.com/slides/ru/java/com.aspose.slides/flavor/) включает CommonMark, GitHub Flavored Markdown и другие поддерживаемые варианты.

Ниже приведён пример экспорта презентации в формате CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Экспорт изображений с использованием поведения сохранения по умолчанию**

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownsaveoptions/) предоставляет два метода для настройки локального сохранения изображений:

- [setBasePath](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownsaveoptions/) задаёт базовый каталог для документа Markdown и его ресурсов.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownsaveoptions/) задаёт подпапку для изображений. Значение по умолчанию — `Images`.

Ниже пример, который рендерит визуальное содержание, сохраняет изображения в `output/assets` и создаёт относительные ссылки на изображения в документе Markdown:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Это поведение также используется как резервный вариант, когда пользовательский обработчик сохранения изображений возвращает `false`.

## **Настроить сохранение изображений и ссылки Markdown**

Используйте метод [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownsaveoptions/) для регистрации обратного вызова для растровых bitmap‑ и metafile‑ресурсов, генерируемых при экспорте в Markdown. Его обратный вызов `MarkdownImageSavingHandler` получает объект [IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/), его значение [ImageFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imageformat/) и сгенерированную ссылку Markdown в виде одноэлементного массива `String[]`. Сохраните или загрузите изображение в указанном формате и замените `link[0]` ссылкой, которую необходимо разместить в выводе Markdown.

Ресурсы, сформированные в формате SVG, обрабатываются отдельно. Зарегистрируйте обратный вызов с помощью метода [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownsaveoptions/). Его обратный вызов `MarkdownSvgImageSavingHandler` получает объект [ISvgImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgimage/) и одноэлементный массив `String[] link`. У SVG нет аргумента `ImageFormat`; вместо этого запишите или загрузите его XML‑данные, полученные методом [ISvgImage.getSvgData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgimage/). В зависимости от режима экспорта и визуального группирования, SVG из исходной презентации может быть растеризован или объединён с другим содержимым; полученный нерисованный ресурс затем передаётся в обратный вызов сохранения изображения. Региструйте оба обратных вызова, когда каждый экспортируемый визуальный ресурс требует пользовательской обработки.

Значение, возвращаемое обработчиком, определяет, кто будет обрабатывать изображение:

- Верните `true`, если обработчик уже сохранил, загрузил, преобразовал или иным образом обработал изображение и присвоил допустимое значение `link[0]`. Aspose.Slides запишет это значение в документ Markdown и не выполнит сохранения по умолчанию.
- Верните `false`, чтобы позволить Aspose.Slides сохранить изображение локально и сгенерировать ссылку на основе значений, заданных методами [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownsaveoptions/) и [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}

Обработчик, возвращающий `true`, берёт на себя ответственность за изображение. Если он возвращает `true`, не присвоив при этом валидную, непустую ссылку, экспорт завершится с `InvalidOperationException`.

{{% /alert %}}

### **Сохранить изображения в директорию CDN‑origin и использовать внешние URL**

Ниже пример, в котором `cdn-origin/presentations/quarterly-report` рассматривается как смонтированная или синхронизированная директория CDN‑origin. Каждый обработчик извлекает сгенерированное имя файла, сохраняет изображение в эту пользовательскую директорию и заменяет локальную ссылку на публичный CDN‑URL. Сам пример не выполняет сетевую загрузку: URL становится действительным только после монтирования директории как CDN‑origin или публикации её файлов в CDN. Для объектного хранилища замените запись в файловой системе на операцию загрузки SDK хранилища и присвойте `link[0]` только после успешной загрузки.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Обработчик bitmap‑изображений сознательно возвращает `false` для изображений размером менее 128 × 128 пикселей, поэтому Aspose.Slides сохраняет такие изображения в `output/fallback-images`, используя поведение по умолчанию. Большие bitmap‑ и metafile‑ресурсы, а также SVG‑ресурсы обрабатываются пользовательским кодом. Например, локальная ссылка `fallback-images/image1.png` преобразуется в `https://cdn.example.com/presentations/quarterly-report/image1.png`. Обработчики используют путь файловой системы только при записи файлов; ссылки, записываемые в Markdown, используют прямые слеши и URL‑экранированные имена файлов. Применяйте то же правило при построении относительных ссылок: используйте `/`, а не разделитель каталогов, характерный для платформы.

## **FAQ**

**Можно ли одним обработчиком обрабатывать как растровые изображения, так и SVG?**

Нет. Используйте [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownsaveoptions/) для bitmap‑ и metafile‑ресурсов и [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownsaveoptions/) для ресурсов, генерируемых как SVG. Первый предоставляет объект [IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/) и значение [ImageFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imageformat/); второй предоставляет объект [ISvgImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgimage/), данные SVG которого можно прочитать через [ISvgImage.getSvgData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgimage/). SVG‑изображение, растеризованное во время экспорта, обрабатывается обработчиком сохранения изображений.

**Что происходит, когда обработчик сохранения изображения возвращает `false`?**

Aspose.Slides использует своё поведение сохранения по умолчанию. Расположение изображения и сгенерированная ссылка контролируются значениями, установленными через [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownsaveoptions/) и [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ru/java/com.aspose.slides/markdownsaveoptions/).

**Может ли обработчик предоставить URL без локального сохранения изображения?**

Да. Обработчик может загрузить изображение в объектное хранилище или передать его другому сервису, присвоить полученный URL `link[0]` и вернуть `true`. Обработчик обязан полностью выполнить обработку; возврат `true` отменяет локальное сохранение по умолчанию.

**Почему при экспорте в Markdown возникает `InvalidOperationException` из‑за обработчика?**

Это происходит, когда обработчик возвращает `true`, но не предоставляет корректную ссылку. Присвойте относительный путь или внешний URL, который должен быть записан в Markdown, перед возвратом `true`.

**Каким разделителем путей должны пользоваться ссылки на изображения?**

В ссылках Markdown и URL используйте прямые слеши. Для путей файловой системы применяйте `Path.resolve`, а затем отдельно формируйте или нормализуйте ссылку Markdown.

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [гиперссылки](/slides/ru/java/manage-hyperlinks/) сохраняются как обычные ссылки Markdown. Переходы слайдов [transitions](/slides/ru/java/slide-transition/) и [animations](/slides/ru/java/powerpoint-animation/) не конвертируются.

**Можно ли конвертировать презентации в Markdown параллельно?**

Можно обрабатывать разные файлы презентаций одновременно, но не делите один и тот же объект [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) между потоками. Следуйте [мультипоточным рекомендациям](/slides/ru/java/multithreading/) и используйте отдельный экземпляр для каждого файла.