---
title: Преобразовать PowerPoint в HTML с помощью JavaScript
linktitle: Преобразовать PowerPoint в HTML
type: docs
weight: 30
url: /ru/nodejs-java/convert-powerpoint-to-html/
keywords: "Java PowerPoint в HTML, Преобразовать презентацию PowerPoint, PPTX, PPT, PPT в HTML, PPTX в HTML, PowerPoint в HTML, Сохранить PowerPoint как HTML, Сохранить PPT как HTML, Сохранить PPTX как HTML, Java, Aspose.Slides, экспорт HTML"
description: "Преобразовать PowerPoint в HTML с помощью JavaScript. Сохранить PPTX или PPT как HTML в JavaScript. Сохранить слайды как HTML в JavaScript"
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формат HTML с помощью JavaScript. Рассматриваются следующие темы.

- Преобразовать PowerPoint в HTML с помощью JavaScript
- Преобразовать PPT в HTML с помощью JavaScript
- Преобразовать PPTX в HTML с помощью JavaScript
- Преобразовать ODP в HTML с помощью JavaScript
- Преобразовать слайд PowerPoint в HTML с помощью JavaScript

## **Java PowerPoint в HTML**

Для примера кода JavaScript, преобразующего PowerPoint в HTML, см. раздел ниже, а именно [Convert PowerPoint to HTML](#convert-powerpoint-to-html). Код может загружать различные форматы, такие как PPT, PPTX и ODP, в объект Presentation и сохранять их в формат HTML.

## **О преобразовании PowerPoint в HTML**

С помощью [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), приложения и разработчики могут преобразовать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**.

**Aspose.Slides** предоставляет множество параметров (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions)), определяющих процесс преобразования PowerPoint в HTML:

* Преобразовать всю презентацию PowerPoint в HTML.
* Преобразовать конкретный слайд презентации PowerPoint в HTML.
* Преобразовать медиа презентации (изображения, видео и т.д.) в HTML.
* Преобразовать презентацию PowerPoint в адаптивный HTML.
* Преобразовать презентацию PowerPoint в HTML с включёнными или исключёнными заметками выступающего.
* Преобразовать презентацию PowerPoint в HTML с включёнными или исключёнными комментариями.
* Преобразовать презентацию PowerPoint в HTML с оригинальными или встроенными шрифтами.
* Преобразовать презентацию PowerPoint в HTML, используя новый стиль CSS.

{{% alert color="primary" %}} 

С помощью собственного API Aspose разработала бесплатные конвертеры [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) и т.д.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Возможно, вам будет интересно ознакомиться с другими [бесплатными конвертерами от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Помимо описанных здесь процессов преобразования, Aspose.Slides также поддерживает следующие операции преобразования, связанные с форматом HTML:

* [HTML в изображение](https://products.aspose.com/slides/nodejs-java/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/nodejs-java/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/nodejs-java/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/nodejs-java/conversion/html-to-tiff/)

{{% /alert %}}

## **Преобразовать PowerPoint в HTML**

С помощью Aspose.Slides вы можете преобразовать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Вызовите метод [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) для сохранения объекта в виде HTML‑файла.

Этот код показывает, как преобразовать PowerPoint в HTML с помощью JavaScript:
```javascript
// Создать объект Presentation, представляющий файл презентации
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var htmlOpt = new aspose.slides.HtmlOptions();
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    htmlOpt.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
    // Сохранение презентации в HTML
    pres.save("ConvertWholePresentationToHTML_out.html", aspose.slides.SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Преобразовать PowerPoint в адаптивный HTML**

Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ResponsiveHtmlController), который позволяет генерировать адаптивные HTML‑файлы. Этот код показывает, как преобразовать презентацию PowerPoint в адаптивный HTML с помощью JavaScript:
```javascript
// Создать объект Presentation, который представляет файл презентации
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var controller = new aspose.slides.ResponsiveHtmlController();
    var htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    // Сохранение презентации в HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Преобразовать PowerPoint в HTML с заметками**

Этот код показывает, как преобразовать PowerPoint в HTML с заметками с помощью JavaScript:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var opt = new aspose.slides.HtmlOptions();
    var options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Сохранение страниц заметок
    pres.save("Output.html", aspose.slides.SaveFormat.Html, opt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Преобразовать PowerPoint в HTML с оригинальными шрифтами**

Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController), который позволяет внедрять все шрифты презентации при её преобразовании в HTML.

Чтобы предотвратить встраивание некоторых шрифтов, вы можете передать массив имён шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController). Популярные шрифты, такие как Calibri или Arial, используемые в презентации, не требуют встраивания, поскольку большинство систем уже содержат эти шрифты. Если такие шрифты будут встроены, полученный HTML‑документ станет избыточно большим.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) поддерживает наследование и предоставляет метод [WriteFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-aspose.slides.IHtmlGenerator-aspose.slides.IFontData-aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-), предназначенный для переопределения.
```javascript
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // исключить шрифты презентации по умолчанию
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var embedFontsController = new aspose.slides.EmbedAllFontsHtmlController(fontNameExcludeList);
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(embedFontsController));
    pres.save("input-PFDinDisplayPro-Regular-installed.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Преобразовать PowerPoint в HTML с изображениями высокого качества**

По умолчанию при преобразовании PowerPoint в HTML Aspose.Slides создает небольшие HTML‑файлы с изображениями 72 DPI и удалёнными обрезанными областями. Чтобы получить HTML‑файлы с изображениями более высокого качества, необходимо передать значение `96` в метод `setPicturesCompression` класса `HtmlOptions` (т.е. `PicturesCompression.Dpi96`) или более высокие [значения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PicturesCompression).

Этот код JavaScript показывает, как преобразовать презентацию PowerPoint в HTML, получая изображения высокого качества с разрешением 150 DPI (т.е. `PicturesCompression.Dpi150`):
```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);
    pres.save("OutputDoc-dpi150.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Этот код JavaScript показывает, как вывести HTML с изображениями полного качества:
```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);
    pres.save("Outputdoc-noCrop.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Преобразовать слайд в HTML**

Чтобы преобразовать конкретный слайд PowerPoint в HTML, необходимо создать экземпляр того же класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) (используемого для преобразования всей презентации в HTML), а затем вызвать метод [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) для сохранения файла в формате HTML. Класс [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) можно использовать для указания дополнительных параметров преобразования:
```javascript
var pres = new aspose.slides.Presentation("Individual-Slide.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    
    const CustomFormattingController = java.newProxy("com.aspose.slides.IHtmlFormattingController", {
        writeDocumentStart: function(generator, presentation) {

        },

        writeDocumentEnd: function(generator, presentation) {

        },

        writeSlideStart: function(generator, slide) {
            const slideIndex = generator.getSlideIndex() + 1;
            const slideHeaderHtml = `<div class="slide" name="slide" id="slide${slideIndex}">`;
            generator.addHtml(slideHeaderHtml);
        },

        writeSlideEnd: function(generator, slide) {
            const slideFooterHtml = "</div>";
            generator.addHtml(slideFooterHtml);
        },

        writeShapeStart: function(generator, shape) {
        },

        writeShapeEnd: function(generator, shape) {
        }
    });
    
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(CustomFormattingController));
    // Сохранение файла
    for (var i = 0; i < pres.getSlides().size(); i++) {
        pres.save(("Individual Slide" + (i + 1)) + "_out.html", java.newArray("int", [i + 1]), aspose.slides.SaveFormat.Html, htmlOptions);
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Сохранить CSS и изображения при экспорте в HTML**

С помощью новых файлов стилей CSS вы можете легко изменить стиль HTML‑файла, полученного в результате преобразования PowerPoint в HTML.

Код JavaScript в этом примере показывает, как использовать переопределяемые методы для создания пользовательского HTML‑документа со ссылкой на файл CSS:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var htmlController = java.newInstanceSync("CustomHeaderAndFontsController", "styles.css");
    var options = new aspose.slides.HtmlOptions();
    options.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(htmlController));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Вам потребуется реализовать CustomHeaderAndFontsController в Java, скомпилировать его и добавить в каталог модуля \aspose.slides.via.java\lib\.

Этот код Java показывает, как реализован `CustomHeaderAndFontsController`:
```java
public class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController
{
    private final int m_basePath = 0;

    // Пользовательский шаблон заголовка
    final static String Header = "<!DOCTYPE html>\n" +
            "<html>\n" +
            "<head>\n" +
            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" +
            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" +
            "<link rel=\"stylesheet\" type=\"text/css\" href=\"%s\">\n" +
            "</head>";

    private final String m_cssFileName;

    public CustomHeaderAndFontsController(String cssFileName)
    {
        m_cssFileName = cssFileName;
    }

    public void writeDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.addHtml(String.format(Header, m_cssFileName));
        writeAllFonts(generator, presentation);
    }

    public void writeAllFonts(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.addHtml("<!-- Embedded fonts -->");
        super.writeAllFonts(generator, presentation);
    }
}
```


## **Связать все шрифты при преобразовании презентации в HTML**

Если вы не хотите встраивать шрифты (чтобы избежать увеличения размера получаемого HTML), вы можете связать все шрифты, реализовав собственную версию `LinkAllFontsHtmlController`.

Этот код JavaScript показывает, как преобразовать PowerPoint в HTML, связывая все шрифты и исключая "Calibri" и "Arial" (поскольку они уже присутствуют в системе):
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Исключить шрифты презентации по умолчанию
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var linkcont = java.newInstanceSync("LinkAllFontsHtmlController", fontNameExcludeList, "C:/Windows/Fonts/");
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(linkcont));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Вам потребуется реализовать LinkAllFontsHtmlController в Java, скомпилировать его и добавить в каталог модуля \aspose.slides.via.java\lib\.

Этот код Java показывает, как реализован `LinkAllFontsHtmlController`:
```java
public class LinkAllFontsHtmlController extends EmbedAllFontsHtmlController
{
    private final String m_basePath;

    public LinkAllFontsHtmlController(String[] fontNameExcludeList, String basePath)
    {
        super(fontNameExcludeList);
        m_basePath = basePath;
    }

    public void writeFont
    (
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData)
    {
        try {
            String fontName = substitutedFont == null ? originalFont.getFontName() : substitutedFont.getFontName();
            String path = fontName + ".woff"; // может потребоваться очистка пути
            Files.write(new File(m_basePath + path).toPath(), fontData, StandardOpenOption.CREATE);

            generator.addHtml("<style>");
            generator.addHtml("@font-face { ");
            generator.addHtml("font-family: '" + fontName + "'; ");
            generator.addHtml("src: url('" + path + "')");

            generator.addHtml(" }");
            generator.addHtml("</style>");
        } catch (IOException ex) {
            ex.printStackTrace();
        }
    }
}
```


## **Преобразовать PowerPoint в адаптивный HTML**

Этот код JavaScript показывает, как преобразовать презентацию PowerPoint в адаптивный HTML:
```javascript
var pres = new aspose.slides.Presentation("SomePresentation.pptx");
try {
    var saveOptions = new aspose.slides.HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", aspose.slides.SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Экспортировать медиа‑файлы в HTML**

С помощью Aspose.Slides for Node.js via Java вы можете экспортировать медиа‑файлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд.
3. Добавьте видео на слайд.
4. Запишите презентацию в виде HTML‑файла.

Этот код JavaScript показывает, как добавить видео в презентацию и затем сохранить её как HTML:
```javascript
// Загрузка презентации
var pres = new aspose.slides.Presentation();
try {
    var path = "./out/";
    final var fileName = "ExportMediaFiles_out.html";
    final var baseUri = "http://www.example.com/";
    var videoData = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "my_video.avi"));
    var video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    var controller = new aspose.slides.VideoPlayerHtmlController(path, fileName, baseUri);
    // Установка параметров HTML
    var htmlOptions = new aspose.slides.HtmlOptions(controller);
    var svgOptions = new aspose.slides.SVGOptions(controller);
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(aspose.slides.SlideImageFormat.svg(svgOptions));
    // Сохранение файла
    pres.save(fileName, aspose.slides.SaveFormat.Html, htmlOptions);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Вопросы и ответы**

**Какова производительность Aspose.Slides при преобразовании нескольких презентаций в HTML?**

Производительность зависит от размера и сложности презентаций. Aspose.Slides обладает высокой эффективностью и масштабируемостью для пакетных операций. Чтобы достичь оптимальной производительности при преобразовании большого количества презентаций, рекомендуется использовать многопоточность или параллельную обработку, когда это возможно.

**Поддерживает ли Aspose.Slides экспорт гиперссылок в HTML?**

Да, Aspose.Slides полностью поддерживает экспорт встроенных гиперссылок в HTML. При преобразовании презентаций в формат HTML гиперссылки автоматически сохраняются и остаются кликабельными.

**Существует ли ограничение на количество слайдов при преобразовании презентаций в HTML?**

При использовании Aspose.Slides нет ограничения на количество слайдов. Вы можете преобразовать презентации любого объёма. Однако для презентаций с очень большим числом слайдов производительность может зависеть от доступных ресурсов вашего сервера или системы.