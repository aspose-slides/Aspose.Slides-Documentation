---
title: Преобразование презентаций PowerPoint в HTML на Java
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/java/convert-powerpoint-to-html/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в HTML
- презентацию в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- сохранить PowerPoint как HTML
- сохранить презентацию как HTML
- сохранить слайд как HTML
- сохранить PPT как HTML
- сохранить PPTX как HTML
- экспортировать PPT в HTML
- экспортировать PPTX в HTML
- Java
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint в HTML на Java. Используйте Aspose.Slides для экспорта файлов PPT и PPTX, выбранных слайдов, заметок, шрифтов, изображений, SVG и медиа."
---
## **Обзор**

Aspose.Slides for Java может сохранять презентации PowerPoint в формате HTML без Microsoft PowerPoint. Основное преобразование состоит из единственной загрузки [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и вызова `save` с [SaveFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/). Используйте [HtmlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/htmloptions/), когда необходимо контролировать экспортированный макет, шрифты, изображения, заметки, комментарии, вывод SVG или связанные ресурсы.

Это руководство ориентировано на практические сценарии экспорта HTML:

- Экспорт всей презентации или выбранных слайдов.
- Создание HTML с фиксированным макетом, адаптивным или основанным на SVG.
- Включение заметок докладчика и комментариев.
- Контроль качества изображений и данных об обрезанных изображениях.
- Встраивание шрифтов или отдельное сохранение файлов шрифтов.
- Выбор способа записи и ссылки на внешние ресурсы и медиафайлы.

По умолчанию экспорт HTML создает автономный HTML‑документ, в котором большинство ресурсов встроены. Это удобно для обмена одним файлом, но может увеличить размер вывода. Для веб‑публикации рассмотрите возможность использования внешних ресурсов, снижения DPI изображений и встраивания только тех шрифтов, которые недоступны в целевой среде.

## **Преобразовать презентацию в HTML**

Чтобы экспортировать презентацию в HTML, загрузите её с помощью [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и сохраните её с помощью [SaveFormat.Html](https://reference.aspose.com/slides/ru/java/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Этот пример записывает один HTML‑файл. Объект презентации освобождается в блоке `finally`, что освобождает файловые дескрипторы и ресурсы рендеринга после экспорта.

## **Использовать HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/htmloptions/) — основной класс конфигурации для экспорта HTML. Общие настройки включают:

- `SlidesLayoutOptions`: добавляет заметки, комментарии, раздаточные материалы или другую информацию о макете.
- `HtmlFormatter`: изменяет структуру HTML‑документа или делегирует форматирование контроллеру.
- `SlideImageFormat`: изменяет способ представления слайдов, например в виде SVG.
- `PicturesCompression`: контролирует DPI изображений и размер вывода.
- `DeletePicturesCroppedAreas`: сохраняет или удаляет данные об обрезанных изображениях.
- `SvgResponsiveLayout`: заставляет экспортированный SVG‑контент адаптироваться к своему контейнеру.
- `ShowHiddenSlides`: включает скрытые слайды, если это необходимо.

В следующих разделах показаны наиболее часто используемые параметры отдельно, чтобы вы могли комбинировать только те, которые нужны вашему рабочему процессу.

## **Преобразовать выбранные слайды в HTML**

`Presentation.save` перегрузка, принимающая номера слайдов, использует 1‑based позиции слайдов. Цикл ниже сохраняет каждый слайд в отдельный HTML‑файл.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Используйте этот шаблон, когда веб‑сайт или приложение требует одну HTML‑страницу на каждый слайд. Если каждый слайд должен иметь одинаковый макет, создайте один экземпляр [HtmlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/htmloptions/) и передайте его каждому вызову `save`.

## **Создать адаптивный HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/responsivehtmlcontroller/) обеспечивает адаптивный вывод HTML через [HtmlFormatter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/htmlformatter/). Используйте его, когда экспортированная страница должна лучше адаптироваться к ширине браузера.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Для адаптивного макета на основе SVG установите `SvgResponsiveLayout` в [HtmlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/htmloptions/). Это полезно, когда содержимое слайда экспортируется как масштабируемая разметка SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Включить заметки докладчика и комментарии**

Используйте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/notescommentslayoutingoptions/) через `HtmlOptions.setSlidesLayoutOptions`, чтобы включить заметки докладчика или комментарии. Заметки и комментарии скрыты по умолчанию, если только вы не зададите их позиции.

Предположим, исходная презентация содержит заметки докладчика:

![Слайд с заметками докладчика в PowerPoint](slide_with_notes.png)

Следующий код экспортирует содержимое слайда с заметками докладчика под слайдом.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Экспортированный HTML включает область заметок:

![HTML‑вывод со слайдом и заметками докладчика](HTML_with_notes.png)

Чтобы экспортировать комментарии, задайте `CommentsPosition`, например `CommentsPositions.Right` или `CommentsPositions.Bottom`. Если нужны только комментарии, опустите `NotesPosition`. Если нужны и заметки, и комментарии, задайте оба свойства.

## **Управление качеством изображений и обрезанными областями**

Экспорт HTML может сжимать изображения слайдов для уменьшения размера вывода. Установите `PicturesCompression` в значение из [PicturesCompression](https://reference.aspose.com/slides/ru/java/com.aspose.slides/picturescompression/), когда требуется более высокое качество изображений.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

По умолчанию обрезанные области изображений могут быть удалены из экспортированного вывода. Сохраняйте обрезанные данные только тогда, когда пользователи должны иметь возможность восстановить или просмотреть эти скрытые части изображения. Сохранение увеличивает размер HTML.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Добавить CSS**

Для простого стилирования передайте строку CSS в `HtmlFormatter.createDocumentFormatter`. Это изменяет окружающий HTML‑документ, пока Aspose.Slides продолжает рендерить содержимое слайдов.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Для пользовательского заголовка документа, подключаемого CSS‑файла или пользовательской разметки вокруг слайдов и фигур реализуйте [IHtmlFormattingController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ihtmlformattingcontroller/) и передайте его в [HtmlFormatter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/htmlformatter/) с помощью `createCustomFormatter`.

## **Встроить шрифты**

Если в целевой среде шрифты презентации могут быть не установлены, встроите шрифты в HTML с помощью [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/embedallfontshtmlcontroller/). Встраивание повышает визуальную точность, но увеличивает размер вывода.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Исключайте шрифты только тогда, когда уверены, что целевые браузеры или системы уже их предоставляют. Для фирменных шрифтов или редких шрифтов встраивание обычно безопаснее.

## **Ссылка на файлы шрифтов вместо их встраивания**

Чтобы уменьшить размер HTML‑файла, вы можете записать данные шрифтов в отдельные файлы WOFF и добавить правила `@font-face` в HTML. Ниже приведенный помощник расширяет [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/embedallfontshtmlcontroller/) и переопределяет `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

В этом примере файлы шрифтов сохраняются в `html-output/fonts`, а HTML ссылается на них через URL‑ы, например `fonts/BrandFont-normal-400.woff`. Если HTML‑файл и шрифты развертываются в другом месте, выберите `fontUrlPrefix`, чтобы он соответствовал пути URL после развертывания.

## **Сохранить ресурсы внешне**

Автономный HTML легко перемещать, но встроенные ресурсы Base64 могут увеличить размер файла. Если вашему приложению нужны внешние файлы изображений, реализуйте [ILinkEmbedController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ilinkembedcontroller/) и передайте его в конструктор [HtmlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/htmloptions/).

При вынесении ресурсов наружу выбирайте два пути осознанно:

- Путь вывода в файловой системе, куда ваше приложение записывает сгенерированные изображения, шрифты, аудио или видео.
- URL‑путь, который браузер использует из HTML‑документа для загрузки этих файлов.

## **Экспортировать медиафайлы**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/videoplayerhtmlcontroller/) экспортирует видео и аудио файлы и создает HTML, который может воспроизводить их в браузере. Его конструктор принимает:

- `path`: каталог, в который будут записываться сгенерированные медиафайлы.
- `fileName`: имя генерируемого HTML‑файла.
- `baseUri`: абсолютный URI‑префикс, используемый в HTML‑ссылках на медиафайлы.

Если HTML‑файл находится в `html-output/presentation.html`, а медиафайлы сохраняются в `html-output/media`, `path` должен указывать на каталог медиафайлов на диске, а `baseUri` — на тот же каталог с точки зрения браузера. Для локального предпросмотра вы можете построить URI `file:///` из каталога медиа. Для развернутого приложения используйте абсолютный URL опубликованного каталога медиа.

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Используйте каталоги вывода, уникальные для каждой задачи экспорта, особенно в серверных приложениях. Общие пути вывода могут привести к перезаписи файлов различных конвертаций.

## **Производительность и управление ресурсами**

Преобразование HTML — это операция рендеринга, поэтому время обработки и использование памяти зависят от количества слайдов, разрешения изображений, шрифтов, эффектов, диаграмм и встроенных медиа. Более высокие значения DPI `PicturesCompression`, встроенные шрифты, вывод SVG и сохранённые обрезанные области изображений могут повысить точность, но обычно увеличивают размер вывода.

Для пакетного конвертирования:

- Своевременно освобождайте каждый экземпляр [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/).
- Используйте отдельные каталоги вывода для разных задач.
- Избегайте встраивания распространённых шрифтов, если только это не требуется для точности.
- Снижайте DPI изображений, когда HTML предназначен для превью или миниатюр.
- Держите исходную презентацию, сгенерированный HTML и внешние ресурсы вместе, пока не станут окончательными пути развертывания.

## **FAQ**

**Сохраняются ли гиперссылки в HTML‑выводе?**

Да. Гиперссылки презентации экспортируются в HTML и остаются кликабельными, если целевой URL действителен.

**Могу ли я преобразовывать презентации в HTML параллельно?**

Да, но не используйте один экземпляр [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) совместно между потоками. Обрабатывайте разные файлы с отдельными экземплярами презентаций, отдельными потоками и отдельными каталогами вывода. См. руководство по [многопоточности](/slides/ru/java/multithreading/) для деталей.

**Является ли объект Presentation потокобезопасным?**

Нет. Один экземпляр [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) должен быть загружен, изменён, сохранён и освобождён в одном потоке. Для параллельной работы создавайте отдельный экземпляр для каждого потока или процесса.

**Почему сгенерированный HTML‑файл большой?**

По умолчанию экспорт может встраивать ресурсы напрямую в HTML. Встроенные шрифты, изображения с высоким DPI, медиа, SVG‑контент и сохранённые обрезанные области изображений также увеличивают размер. Используйте внешние ресурсы, исключайте распространённые шрифты из встраивания и снижайте `PicturesCompression`, когда меньший размер важнее максимальной точности.

**Как следует выбирать baseUri для экспорта медиа?**

Выбирайте `baseUri` с точки зрения браузера и передавайте его как абсолютный URI. Для локального предпросмотра вы можете получить его из каталога вывода с помощью `mediaDirectory.toUri().toString()`. Для развертывания используйте абсолютный URL опубликованного каталога медиа. Файловый системный `path` и браузерный `baseUri` не обязаны быть одинаковой строкой, но должны описывать одно и то же расположение ресурса.

**Могу ли я включить скрытые слайды?**

Да. Установите `ShowHiddenSlides` в `true` на [HtmlOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/htmloptions/), когда скрытые слайды должны быть экспортированы.