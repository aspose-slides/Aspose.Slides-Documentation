---
title: Конвертировать презентации PowerPoint в Markdown на Android
linktitle: PowerPoint в Markdown
type: docs
weight: 140
url: /ru/androidjava/convert-powerpoint-to-markdown/
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
- экспорт изображений в Markdown
- ссылки на изображения CDN
- PowerPoint
- презентация
- Markdown
- Android
- Java
- Aspose.Slides
description: "Конвертировать презентации PPT и PPTX в Markdown на Android через Java и управлять местом сохранения и ссылками на экспортированные bitmap, metafile и SVG изображения."
---
## **Обзор**

Aspose.Slides for Android via Java может преобразовать презентации PPT и PPTX в Markdown для документирования, статических сайтов, миграции контента и процессов управления версиями. Вы можете выбрать вариант Markdown, контролировать способ рендеринга содержимого слайдов и решить, где сохранять экспортированные изображения и как генерировать ссылки в Markdown.

По умолчанию экспорт в Markdown использует только текстовый вывод. Чтобы экспортировать визуальное содержимое, задайте тип экспорта с помощью метода [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownsaveoptions/) и укажите значение `Sequential` или `Visual` из перечисления [MarkdownExportType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownexporttype/). `Sequential` рендерит элементы слайдов отдельно и в порядке их следования, тогда как `Visual` сохраняет сгруппированные элементы вместе, чтобы сохранить их визуальные взаимосвязи. Значение `TextOnly` не создает ресурсы изображений, поэтому обратные вызовы сохранения изображений не вызываются в этом режиме.

## **Конвертировать презентацию в Markdown**

Загрузите исходный файл с помощью класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и затем вызовите метод [Presentation.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) с параметром `Md` из перечисления [SaveFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/saveformat/).

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

Метод [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownsaveoptions/) задаёт спецификацию Markdown, используемую для вывода. Перечисление [Flavor](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/flavor/) включает CommonMark, GitHub Flavored Markdown и другие поддерживаемые варианты.

Следующий пример экспортирует презентацию в формате CommonMark:

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

Класс [MarkdownSaveOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownsaveoptions/) предоставляет два метода для настройки локального сохранения изображений:

- [setBasePath](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownsaveoptions/) указывает базовый каталог для документа Markdown и его ресурсов.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownsaveoptions/) задаёт подкаталог для изображений. Его значение по умолчанию — `Images`.

Следующий пример рендерит визуальное содержимое, записывает изображения в `output/assets` и создаёт относительные ссылки на изображения в документе Markdown:

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

Это поведение также служит резервным вариантом, когда пользовательский обработчик сохранения изображения возвращает `false`.

## **Настроить сохранение изображений и ссылки в Markdown**

Используйте метод [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownsaveoptions/) для регистрации обратного вызова для растровых битовых карт и metafile‑ресурсов, генерируемых при экспорте в Markdown. Его обратный вызов `MarkdownImageSavingHandler` получает объект [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/), значение [ImageFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imageformat/) и сгенерированную ссылку Markdown в виде одноэлементного массива `String[]`. Сохраните или загрузите изображение в указанном формате и замените `link[0]` на ссылку, которая должна появиться в выводе Markdown.

Ресурсы, генерируемые в формате SVG, обрабатываются отдельно. Зарегистрируйте обратный вызов с помощью метода [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownsaveoptions/). Его обратный вызов `MarkdownSvgImageSavingHandler` получает объект [ISvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/) и одноэлементный массив `String[] link`. У SVG нет аргумента `ImageFormat`; вместо этого запишите или загрузите его XML‑данные, полученные методом [ISvgImage.getSvgData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/). В зависимости от режима экспорта и визуального группирования SVG в исходной презентации может быть растеризован или объединён с другим содержимым; полученный неформатный ресурс затем передаётся в обратный вызов сохранения изображения. Регистрируйте оба обратных вызова, когда каждый экспортированный визуальный ресурс требует пользовательской обработки.

Значение, возвращаемое обработчиком, определяет, кто будет обрабатывать изображение:

- Верните `true`, если обработчик сохранил, загрузил, преобразовал или иначе обработал изображение и присвоил допустимое значение `link[0]`. Aspose.Slides запишет это значение в документ Markdown и не выполнит локальное сохранение по умолчанию.
- Верните `false`, чтобы позволить Aspose.Slides сохранить изображение локально и сгенерировать ссылку согласно значениям, установленным с помощью [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownsaveoptions/) и [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Обработчик, возвращающий `true`, берёт на себя ответственность за изображение. Если он возвращает `true`, не присвоив при этом действительную непустую ссылку, экспорт завершится ошибкой `InvalidOperationException`.
{{% /alert %}}

### **Сохранить изображения в каталог CDN‑origin и использовать внешние URL**

В следующем примере каталог `cdn-origin/presentations/quarterly-report` рассматривается как смонтированный или синхронизированный каталог CDN‑origin. Каждый обработчик извлекает сгенерированное имя файла, сохраняет изображение в этот пользовательский каталог и заменяет локальную ссылку на публичный URL CDN. Сам пример не выполняет загрузку по сети: URL станет действительным только после монтирования каталога как CDN‑origin или публикации его файлов в CDN. Для объектного хранилища замените запись в файловой системе на операцию загрузки SDK хранилища и присвойте `link[0]` только после успешной загрузки.

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

Обработчик битовой карты намеренно возвращает `false` для изображений меньше 128 × 128 пикселей, поэтому Aspose.Slides сохраняет такие изображения в `output/fallback-images` используя поведение по умолчанию. Большие битовые карты, metafile‑ресурсы и SVG‑ресурсы обрабатываются пользовательским кодом. Например, локальная ссылка `fallback-images/image1.png` может стать `https://cdn.example.com/presentations/quarterly-report/image1.png`. Обработчики используют пути ОС только при записи файлов; ссылки, записываемые в Markdown, используют прямые слэши и URL‑экранированные имена файлов. Применяйте то же правило при построении относительных ссылок: используйте `/`, а не разделитель каталогов, характерный для платформы.

## **FAQ**

**Можно ли одним обработчиком обрабатывать как растровые изображения, так и SVG?**

Нет. Используйте [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownsaveoptions/) для растровых битовых карт и metafile‑ресурсов и [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownsaveoptions/) для ресурсов, генерируемых в формате SVG. Первый предоставляет объект [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) и значение [ImageFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imageformat/); второй — объект [ISvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/), данные SVG которого можно прочитать с помощью [ISvgImage.getSvgData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/). Исходный SVG, который растеризуется во время экспорта, обрабатывается обратным вызовом сохранения изображения.

**Что происходит, когда обработчик сохранения изображения возвращает `false`?**

Aspose.Slides использует своё поведение сохранения по умолчанию. Расположение изображения и сгенерированная ссылка управляются значениями, установленными через [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownsaveoptions/) и [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/markdownsaveoptions/).

**Можно ли предоставить URL без локального сохранения изображения?**

Да. Обработчик может загрузить изображение в объектное хранилище или передать его другому сервису, присвоить полученный URL в `link[0]` и вернуть `true`. Обработчик обязан полностью выполнить обработку; возврат `true` отключает локальное сохранение по умолчанию.

**Почему экспорт Markdown бросает `InvalidOperationException` из обработчика?**

Это происходит, когда обработчик возвращает `true`, но не предоставляет действительную ссылку. Присвойте `link[0]` относительный путь или внешний URL, который должен быть записан в Markdown, перед возвратом `true`.

**Какой разделитель пути следует использовать в ссылках на изображения?**

В ссылках Markdown и URL используйте прямые слэши. `Path.resolve` применяйте только для путей файловой системы, а Markdown‑ссылку формируйте отдельно.

**Сохраняются ли гиперссылки при экспорте в Markdown?**

Да. Текстовые [гиперссылки](/slides/ru/androidjava/manage-hyperlinks/) сохраняются как обычные ссылки Markdown. [Переходы слайдов](/slides/ru/androidjava/slide-transition/) и [анимации](/slides/ru/androidjava/powerpoint-animation/) не конвертируются.

**Можно ли конвертировать презентации в Markdown параллельно?**

Можно обрабатывать разные файлы презентаций параллельно, но не делите один экземпляр [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) между потоками. Следуйте [рекомендациям по многопоточности](/slides/ru/androidjava/multithreading/) и используйте отдельный экземпляр для каждого файла.