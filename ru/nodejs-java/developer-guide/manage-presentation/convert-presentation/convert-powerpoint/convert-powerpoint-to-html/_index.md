---
title: Преобразование презентаций PowerPoint в HTML в Node.js
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/nodejs-java/convert-powerpoint-to-html/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPT
- преобразовать PPTX
- PowerPoint в HTML
- презентация в HTML
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint в HTML в Node.js. Используйте Aspose.Slides для Node.js через Java для экспорта файлов PPT и PPTX, выбранных слайдов, заметок, шрифтов, изображений, SVG и медиа."
---
## **Обзор**

Aspose.Slides for Node.js via Java может сохранять презентации PowerPoint в формате HTML без Microsoft PowerPoint. Базовое преобразование представляет собой загрузку одного [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) и вызов `save` с [SaveFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/). Используйте [HtmlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmloptions/) когда необходимо контролировать экспортируемый макет, шрифты, изображения, заметки, комментарии, вывод SVG или связанные ресурсы.

Это руководство сосредоточено на практических сценариях экспорта HTML:

- Экспорт всей презентации или выбранных слайдов.
- Генерация фиксированного, адаптивного или SVG‑основанного HTML.
- Включение заметок докладчика и комментариев.
- Управление качеством изображения и данными обрезанных областей.
- Встраивание шрифтов или сохранение файлов шрифтов отдельно.
- Выбор способа записи и ссылки на внешние ресурсы и медиафайлы.

По умолчанию экспорт HTML создаёт самостоятельный HTML‑документ, в котором большинство ресурсов встроено. Это удобно для обмена одним файлом, но может увеличить размер результата. Для публикации в вебе рассмотрите использование внешних ресурсов, уменьшение DPI изображений и встраивание только тех шрифтов, которые не гарантированно доступны в целевом окружении.

## **Преобразовать презентацию в HTML**

Чтобы экспортировать презентацию в HTML, загрузите её с помощью [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) и сохраните с помощью [SaveFormat.Html](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

Этот пример записывает один HTML‑файл. Объект презентации освобождается в блоке `finally`, что закрывает файловые дескрипторы и освобождает ресурсы рендеринга после экспорта.

## **Использовать HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmloptions/) — основной класс конфигурации экспорта HTML. Распространённые настройки включают:

- `SlidesLayoutOptions`: добавляет заметки, комментарии, раздаточные материалы или другую информацию о макете.
- `HtmlFormatter`: изменяет структуру HTML‑документа или делегирует форматирование контроллеру.
- `SlideImageFormat`: меняет способ представления слайдов, например как SVG.
- `PicturesCompression`: управляет DPI изображений и размером вывода.
- `DeletePicturesCroppedAreas`: сохраняет или удаляет данные обрезанных изображений.
- `SvgResponsiveLayout`: делает экспортированный SVG‑контент адаптивным к контейнеру.
- `ShowHiddenSlides`: включает скрытые слайды при необходимости.

В следующих разделах показаны наиболее часто используемые параметры отдельно, чтобы вы могли комбинировать только те, которые нужны вашему рабочему процессу.

## **Преобразовать выбранные слайды в HTML**

Перегрузка `Presentation.save`, принимающая номера слайдов, использует 1‑based индексацию. Цикл ниже сохраняет каждый слайд в отдельный HTML‑файл.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Используйте этот шаблон, когда веб‑сайт или приложение требует одну HTML‑страницу на каждый слайд. Если каждый слайд должен иметь одинаковый макет, создайте один экземпляр [HtmlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmloptions/) и передайте его каждому вызову `save`.

## **Создать адаптивный HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/responsivehtmlcontroller/) предоставляет адаптивный вывод HTML через [HtmlFormatter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmlformatter/). Используйте его, когда экспортируемая страница должна лучше подстраиваться под ширину браузера.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Для SVG‑основанного адаптивного макета установите `SvgResponsiveLayout` в [HtmlOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmloptions/). Это полезно, когда содержимое слайда экспортируется как масштабируемая SVG‑разметка.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Включить заметки докладчика и комментарии**

Используйте [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notescommentslayoutingoptions/) через `HtmlOptions.setSlidesLayoutOptions`, чтобы добавить заметки докладчика или комментарии. По умолчанию заметки и комментарии скрыты, если только вы не зададите их позицию.

Предположим, что исходная презентация содержит заметки докладчика:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Следующий код экспортирует содержимое слайда с заметками докладчика под слайдом.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Экспортированный HTML включает область заметок:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Чтобы экспортировать комментарии, задайте `CommentsPosition`, например `CommentsPositions.Right` или `CommentsPositions.Bottom`. Если нужны только комментарии, опустите `NotesPosition`. Если требуются и заметки, и комментарии, задайте оба свойства.

## **Управление качеством изображений и обрезанными областями**

Экспорт HTML может сжимать изображения слайдов для уменьшения размера результата. Установите `PicturesCompression` в значение из [PicturesCompression](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturescompression/), когда требуется более высокое качество изображений.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

По умолчанию обрезанные области изображений могут быть удалены из экспортируемого вывода. Сохраняйте обрезанные данные только тогда, когда пользователям необходимо восстанавливать или просматривать эти скрытые части изображения. Сохранение их может увеличить размер HTML.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Добавить CSS**

Для простого стилизования передайте строку CSS в `HtmlFormatter.createDocumentFormatter`. Это изменит внешнюю оболочку HTML‑документа, пока Aspose.Slides продолжает рендерить содержимое слайда.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Для пользовательского заголовка документа, подключённого CSS‑файла или пользовательской разметки вокруг слайдов и фигур используйте [HtmlFormatter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/htmlformatter/) с контроллером форматирования.

## **Встроить шрифты**

Если в целевом окружении шрифты презентации могут быть не установлены, встраивайте их в HTML с помощью [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). Встраивание повышает визуальную точность, но увеличивает размер результата.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Исключайте шрифты только тогда, когда вы уверены, что целевые браузеры или системы уже их предоставляют. Для фирменных или менее распространённых шрифтов встраивание обычно надёжнее.

## **Связать файлы шрифтов вместо их встраивания**

Чтобы уменьшить размер HTML‑файла, можно записать данные шрифтов в отдельные файлы WOFF и добавить правила `@font-face` в HTML. В Node.js via Java такой сценарий обычно реализуется небольшим Java‑помощником, который расширяет [EmbedAllFontsHtmlController], записывает байты шрифта в каталог вывода и внедряет правила `@font-face` в сгенерированный HTML. Скомпилируйте помощник, добавьте его в classpath модуля Node.js и затем создайте его экземпляр из JavaScript с помощью `java.newInstanceSync`.

При построении такого помощника явно укажите два пути:

- Путь вывода в файловой системе, куда будут записаны сгенерированные файлы шрифтов.
- URL‑путь, который браузер использует из HTML‑документа для загрузки этих файлов шрифтов.

## **Сохранить ресурсы внешне**

Самодостаточный HTML удобно перемещать, но встроенные ресурсы в формате Base64 могут сильно увеличить файл. Если вашему приложению нужны внешние изображения, шрифты, аудио или видео, используйте контроллер экспорта, который записывает ресурсы в выбранный каталог и генерирует URL‑адреса, видимые браузеру. Согласуйте путь в файловой системе и URL‑путь с размещением вашего развертывания.

## **Экспортировать медиафайлы**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) экспортирует видео‑ и аудиофайлы и генерирует HTML, способный воспроизводить их в браузере. Его конструктор принимает:

- `path`: каталог, в котором будут записаны сгенерированные медиафайлы.
- `fileName`: имя создаваемого HTML‑файла.
- `baseUri`: абсолютный префикс URI, используемый в HTML‑ссылках на медиафайлы.

Если HTML‑файл находится по пути `html-output/presentation.html`, а медиафайлы сохраняются в `html-output/media`, то `path` должен указывать на каталог медиа на диске, а `baseUri` — на тот же каталог с точки зрения браузера. Для локального превью можно построить URI `file:///` из каталога медиа. Для развернутого приложения используйте абсолютный URL опубликованного каталога медиа.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Используйте каталоги вывода, уникальные для каждой задачи экспорта, особенно в серверных приложениях. Общие пути вывода могут приводить к перезаписи файлов разных конвертаций.

## **Производительность и управление ресурсами**

Конвертация в HTML — это операция рендеринга, поэтому время обработки и использование памяти зависят от количества слайдов, разрешения изображений, шрифтов, эффектов, диаграмм и встроенных медиа. Более высокие значения DPI в `PicturesCompression`, встраивание шрифтов, вывод SVG и сохранение обрезанных областей изображений могут повысить точность, но обычно увеличивают размер результата.

Для пакетного конвертирования:

- Осуществляйте своевременное освобождение каждого экземпляра [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
- Используйте отдельные каталоги вывода для разных задач.
- Избегайте встраивания распространённых шрифтов, если в этом нет необходимости для точности.
- Снижайте DPI изображений, когда HTML предназначен для превью или миниатюр.
- Храните исходную презентацию, сгенерированный HTML и внешние ресурсы вместе до окончательного развертывания.

## **FAQ**

**Сохраняются ли гиперссылки в HTML‑выводе?**

Да. Гиперссылки презентации экспортируются в HTML и остаются кликабельными, пока целевой URL действителен.

**Можно ли конвертировать презентации в HTML параллельно?**

Да, но не делитесь одним экземпляром [Presentation] между рабочими потоками. Обрабатывайте разные файлы в отдельных экземплярах презентаций, отдельных потоках и отдельных каталогах вывода. См. руководство по [multithreading guidance](/slides/ru/nodejs-java/multithreading/) для деталей.

**Является ли объект Presentation потокобезопасным?**

Нет. Один экземпляр [Presentation] должен быть загружен, изменён, сохранён и освобождён в одном рабочем потоке. Для параллельной работы создавайте независимый экземпляр для каждого потока или процесса.

**Почему сгенерированный HTML‑файл большой?**

По умолчанию экспорт может встраивать ресурсы непосредственно в HTML. Встроенные шрифты, изображения с высоким DPI, медиа, SVG‑контент и сохранённые обрезанные области изображений также увеличивают размер. Используйте внешние ресурсы, исключайте встраивание распространённых шрифтов и снижайте `PicturesCompression`, когда важен меньший размер, а не максимальная точность.

**Как выбрать baseUri для экспорта медиа?**

Выберите `baseUri` с точки зрения браузера и передайте его как абсолютный URI. Для локального превью можно сформировать его из каталога вывода с помощью `file:///` URI. Для развертывания используйте абсолютный URL опубликованного каталога медиа. Путь в файловой системе (`path`) и URL‑путь (`baseUri`) не обязаны быть одинаковыми строками, но должны описывать одно и то же расположение ресурса.

**Можно ли включать скрытые слайды?**

Да. Установите `ShowHiddenSlides` в `true` в [HtmlOptions] при необходимости экспортировать скрытые слайды.