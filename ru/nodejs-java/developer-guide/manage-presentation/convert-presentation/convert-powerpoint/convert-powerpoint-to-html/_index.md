---
title: Конвертировать презентации PowerPoint в HTML на JavaScript
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/nodejs-java/convert-powerpoint-to-html/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
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
description: "Конвертируйте презентации PowerPoint в адаптивный HTML. Сохраните макет, ссылки и изображения с помощью руководства по конвертации Aspose.Slides для быстрых и безошибочных результатов."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формат HTML с помощью JavaScript. Она охватывает следующие темы.

- Преобразовать PowerPoint в HTML на JavaScript
- Преобразовать PPT в HTML на JavaScript
- Преобразовать PPTX в HTML на JavaScript
- Преобразовать ODP в HTML на JavaScript
- Преобразовать слайд PowerPoint в HTML на JavaScript

## **PowerPoint в HTML на JavaScript**

Для примера кода JavaScript, конвертирующего PowerPoint в HTML, см. раздел ниже, а именно [Convert PowerPoint to HTML](#convert-powerpoint-to-html). Код может загружать различные форматы, такие как PPT, PPTX и ODP, в объект Presentation и сохранять его в формате HTML.

## **О конвертации PowerPoint в HTML**

Используя [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), приложения и разработчики могут преобразовать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**.

**Aspose.Slides** предоставляет множество параметров (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions)), определяющих процесс конвертации PowerPoint в HTML:

* Преобразовать всю презентацию PowerPoint в HTML.
* Преобразовать конкретный слайд презентации PowerPoint в HTML.
* Преобразовать медиа презентации (изображения, видео и т.д.) в HTML.
* Преобразовать презентацию PowerPoint в адаптивный HTML.
* Преобразовать презентацию PowerPoint в HTML с включёнными или исключёнными заметками докладчика.
* Преобразовать презентацию PowerPoint в HTML с включёнными или исключёнными комментариями.
* Преобразовать презентацию PowerPoint в HTML с оригинальными или встроенными шрифтами.
* Преобразовать презентацию PowerPoint в HTML с использованием нового стиля CSS.

{{% alert color="primary" %}} 

С помощью собственного API Aspose разработала бесплатные конвертеры [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP в HTML](https://products.aspose.app/slides/conversion/odp-to-html) и т.д. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Возможно, вам будет интересно посмотреть другие [бесплатные конвертеры от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

## **Преобразовать PowerPoint в HTML**

С помощью Aspose.Slides вы можете преобразовать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Вызовите метод [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) чтобы сохранить объект в файл HTML.

Этот код демонстрирует, как преобразовать PowerPoint в HTML на JavaScript:
```javascript
// Создайте объект Presentation, представляющий файл презентации
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

Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ResponsiveHtmlController), который позволяет генерировать адаптивные HTML‑файлы. Этот код демонстрирует, как преобразовать презентацию PowerPoint в адаптивный HTML на JavaScript:
```javascript
// Создать объект Presentation, представляющий файл презентации
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

Этот код демонстрирует, как преобразовать PowerPoint в HTML с заметками на JavaScript:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var opt = new aspose.slides.HtmlOptions();
    var options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Сохранение страниц с заметками
    pres.save("Output.html", aspose.slides.SaveFormat.Html, opt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Преобразовать PowerPoint в HTML с оригинальными шрифтами**

Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController), который позволяет внедрять все шрифты презентации при конвертации в HTML.

Для предотвращения внедрения определённых шрифтов вы можете передать массив имён шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController). Популярные шрифты, такие как Calibri или Arial, используемые в презентации, не обязаны внедряться, так как большинство систем уже содержат такие шрифты. Если эти шрифты внедряются, получаемый HTML‑документ становится ненужно большим.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) поддерживает наследование и предоставляет метод [WriteFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-aspose.slides.IHtmlGenerator-aspose.slides.IFontData-aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-), который следует переопределять.
```javascript
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // исключить шрифты по умолчанию презентации
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

По умолчанию при конвертации PowerPoint в HTML Aspose.Slides выводит небольшие HTML‑файлы с изображениями 72 DPI и удалёнными обрезанными областями. Чтобы получить HTML‑файлы с изображениями более высокого качества, необходимо передать `96` в метод `setPicturesCompression` класса `HtmlOptions` (т.е. `PicturesCompression.Dpi96`) или более высокие [значения](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PicturesCompression).

Этот JavaScript‑код демонстрирует, как преобразовать презентацию PowerPoint в HTML, получая изображения высокого качества 150 DPI (т.е. `PicturesCompression.Dpi150`):
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


Этот код на JavaScript демонстрирует, как выводить HTML с изображениями полной чёткости:
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

Чтобы преобразовать конкретный слайд PowerPoint в HTML, необходимо создать экземпляр того же класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), который используется для конвертации целых презентаций, и затем вызвать метод [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) для сохранения файла в формате HTML. Класс [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) можно использовать для указания дополнительных параметров конвертации:

Этот JavaScript‑код демонстрирует, как преобразовать слайд презентации PowerPoint в HTML:
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

Используя новые файлы стилей CSS, вы можете легко изменить внешний вид HTML‑файла, полученного в результате конвертации PowerPoint в HTML.

JavaScript‑код в этом примере показывает, как использовать переопределяемые методы для создания пользовательского HTML‑документа со ссылкой на файл CSS:
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

Вам потребуется реализовать `CustomHeaderAndFontsController` на Java, скомпилировать его и добавить в каталог модуля \aspose.slides.via.java\lib\.
Этот Java‑код показывает, как реализован `CustomHeaderAndFontsController`:
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


## **Связывание всех шрифтов при конвертации презентации в HTML**

Если вы не хотите внедрять шрифты (чтобы не увеличивать размер получаемого HTML), вы можете связать все шрифты, реализовав собственную версию `LinkAllFontsHtmlController`.

Этот JavaScript‑код показывает, как преобразовать PowerPoint в HTML, связывая все шрифты и исключая «Calibri» и «Arial» (поскольку они уже присутствуют в системе):
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


Вам потребуется реализовать `LinkAllFontsHtmlController` на Java, скомпилировать его и добавить в каталог модуля \aspose.slides.via.java\lib\.
Этот Java‑код показывает, как реализован `LinkAllFontsHtmlController`:
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

Этот JavaScript‑код показывает, как преобразовать презентацию PowerPoint в адаптивный HTML:
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


## **Экспортировать медиафайлы в HTML**

Используя Aspose.Slides for Node.js via Java, вы можете экспортировать медиафайлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Получите ссылку на слайд.
1. Добавьте видео на слайд.
1. Запишите презентацию как HTML‑файл.

Этот JavaScript‑код демонстрирует, как добавить видео в презентацию и затем сохранить её как HTML:
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


## **FAQ**

**What is the performance of Aspose.Slides when converting multiple presentations to HTML?**  
Performance depends on the size and complexity of presentations. Aspose.Slides is highly efficient and scalable for batch operations. To achieve optimal performance when converting many presentations, it’s recommended to use multithreading or parallel processing whenever possible.

**Does Aspose.Slides support exporting hyperlinks to HTML?**  
Yes, Aspose.Slides fully supports exporting embedded hyperlinks to HTML. When you convert presentations to HTML format, hyperlinks are preserved automatically and remain clickable.

**Is there any limit on the number of slides when converting presentations to HTML?**  
There is no limit on the number of slides when using Aspose.Slides. You can convert presentations of any size. However, for presentations containing a very large number of slides, performance may depend on the available resources of your server or system.