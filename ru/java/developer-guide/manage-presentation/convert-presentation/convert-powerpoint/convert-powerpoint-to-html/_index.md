---
title: Конвертировать презентации PowerPoint в HTML на Java
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
- Java
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в адаптивный HTML на Java. Сохранить макет, ссылки и изображения с помощью руководства по конвертации Aspose.Slides для быстрого и безошибочного результата."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формат HTML с использованием Java. Она охватывает следующие темы.

- Преобразовать PowerPoint в HTML на Java
- Преобразовать PPT в HTML на Java
- Преобразовать PPTX в HTML на Java
- Преобразовать ODP в HTML на Java
- Преобразовать слайд PowerPoint в HTML на Java

## **PowerPoint на Java в HTML**

Для примера кода на Java, преобразующего PowerPoint в HTML, см. раздел ниже, а именно [Преобразовать PowerPoint в HTML](#convert-powerpoint-to-html). Код может загружать различные форматы, такие как PPT, PPTX и ODP, в объект Presentation и сохранять их в формате HTML.

## **О преобразовании PowerPoint в HTML**

С помощью [**Aspose.Slides for Java**](https://products.aspose.com/slides/java/) приложения и разработчики могут преобразовать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**.

**Aspose.Slides** предоставляет множество вариантов (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/HtmlOptions)), которые определяют процесс преобразования PowerPoint в HTML:

* Преобразовать целую презентацию PowerPoint в HTML.
* Преобразовать определённый слайд презентации PowerPoint в HTML.
* Преобразовать медиа презентации (изображения, видео и т.д.) в HTML.
* Преобразовать презентацию PowerPoint в адаптивный HTML.
* Преобразовать презентацию PowerPoint в HTML с включенными или исключёнными заметками докладчика.
* Преобразовать презентацию PowerPoint в HTML с включёнными или исключёнными комментариями.
* Преобразовать презентацию PowerPoint в HTML с оригинальными или внедрёнными шрифтами.
* Преобразовать презентацию PowerPoint в HTML, используя новый стиль CSS.

{{% alert color="primary" %}} 

С помощью собственного API компания Aspose разработала бесплатные конвертеры [презентаций в HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP в HTML](https://products.aspose.app/slides/conversion/odp-to-html) и др.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Возможно, вам будет интересен другой [бесплатный конвертер от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Кроме описанных здесь процессов преобразования, Aspose.Slides также поддерживает следующие операции преобразования, связанные с форматом HTML:

* [HTML в изображение](https://products.aspose.com/slides/java/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/java/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/java/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/java/conversion/html-to-tiff/)

{{% /alert %}}

## **Преобразовать PowerPoint в HTML**

С помощью Aspose.Slides вы можете преобразовать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Вызовите метод [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) для сохранения объекта в виде HTML‑файла.

Этот код демонстрирует, как преобразовать PowerPoint в HTML на Java:
```java
// Инстанцировать объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    HtmlOptions htmlOpt = new HtmlOptions();
	
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));

    // Сохранение презентации в HTML
    pres.save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Преобразовать PowerPoint в адаптивный HTML**

Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/ResponsiveHtmlController), позволяющий генерировать адаптивные HTML‑файлы. Этот код демонстрирует, как преобразовать презентацию PowerPoint в адаптивный HTML на Java:
```java
// Создать объект Presentation, представляющий файл презентации
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

    // Сохранение презентации в HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Преобразовать PowerPoint в HTML с заметками**

Этот код демонстрирует, как преобразовать PowerPoint в HTML с заметками на Java:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    HtmlOptions opt = new HtmlOptions();
	
    INotesCommentsLayoutingOptions options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    // Сохранение страниц заметок
    pres.save("Output.html", SaveFormat.Html, opt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Преобразовать PowerPoint в HTML с оригинальными шрифтами**

Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController), позволяющий внедрять все шрифты презентации при её преобразовании в HTML.

Чтобы предотвратить встраивание определённых шрифтов, вы можете передать массив имён шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController). Популярные шрифты, такие как Calibri или Arial, используемые в презентации, не нужно встраивать, поскольку большинство систем уже содержат такие шрифты. При встраивании этих шрифтов конечный HTML‑документ становится неоправданно большим.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController) поддерживает наследование и предоставляет метод [WriteFont](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-), который предназначен для переопределения. 
```java
Presentation pres = new Presentation("input.pptx");
try {
    // исключить шрифты презентации по умолчанию
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter(embedFontsController));

    pres.save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Преобразовать PowerPoint в HTML с изображениями высокого качества**

По умолчанию при преобразовании PowerPoint в HTML Aspose.Slides генерирует небольшой HTML с изображениями 72 DPI и удалёнными обрезанными областями. Чтобы получить HTML‑файлы с изображениями более высокого качества, необходимо установить свойство `PicturesCompression` (из класса `HtmlOptions`) в значение 96 (т.е. `PicturesCompression.Dpi96`) или выше [значений](https://reference.aspose.com/slides/java/com.aspose.slides/PicturesCompression).

Этот код на Java показывает, как преобразовать презентацию PowerPoint в HTML, получая изображения высокого качества с разрешением 150 DPI (т.е. `PicturesCompression.Dpi150`):
```java
Presentation pres = new Presentation("InputDoc.pptx");
try {
    HtmlOptions htmlOpts = new HtmlOptions();
    htmlOpts.setPicturesCompression(PicturesCompression.Dpi150);
    
    pres.save("OutputDoc-dpi150.html", SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) pres.dispose();
}
```


Этот код на Java показывает, как вывести HTML с изображениями полного качества:
```java
Presentation pres = new Presentation("InputDoc.pptx");
try {
    HtmlOptions htmlOpts = new HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);

    pres.save("Outputdoc-noCrop.html", SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Преобразовать слайд в HTML**

Чтобы преобразовать определённый слайд PowerPoint в HTML, необходимо создать экземпляр того же класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) (используемого для преобразования целых презентаций в HTML), а затем вызвать метод [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISSaveOptions-) для сохранения файла в формате HTML. Класс [HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/HtmlOptions) можно использовать для указания дополнительных параметров преобразования:

```java
Presentation pres = new Presentation("Individual-Slide.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(new CustomFormattingController()));

    // Сохранение файла
    for (int i = 0; i < pres.getSlides().size(); i++)
        pres.save("Individual Slide" + (i + 1) + "_out.html", new int[]{i + 1},SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public class CustomFormattingController implements IHtmlFormattingController
{
    @Override
    public void writeDocumentStart(IHtmlGenerator generator, IPresentation presentation) { }

    @Override
    public void writeDocumentEnd(IHtmlGenerator generator, IPresentation presentation) { }

    @Override
    public void writeSlideStart(IHtmlGenerator generator, ISlide slide) 
	{
        generator.addHtml(String.format(SlideHeader, generator.getSlideIndex() + 1));
    }

    @Override
    public void writeSlideEnd(IHtmlGenerator generator, ISlide slide) 
	{
        generator.addHtml(SlideFooter);
    }

    @Override
    public void writeShapeStart(IHtmlGenerator generator, IShape shape) { }

    @Override
    public void writeShapeEnd(IHtmlGenerator generator, IShape shape) { }

    private final String SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide%d\">";
    private final String SlideFooter = "</div>";
}
```


## **Сохранение CSS и изображений при экспорте в HTML**

Используя новые CSS‑файлы стилей, вы можете легко изменить стиль HTML‑файла, получаемого в результате преобразования PowerPoint в HTML.

Код на Java в этом примере демонстрирует, как использовать переопределяемые методы для создания пользовательского HTML‑документа со ссылкой на CSS‑файл:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");
    HtmlOptions options = new HtmlOptions();
    options.setHtmlFormatter(HtmlFormatter.createCustomFormatter(htmlController));

    pres.save("pres.html", SaveFormat.Html, options);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public class CustomHeaderAndFontsController extends EmbedAllFontsHtmlController
{
    private final int m_basePath = 0;

    // Шаблон пользовательского заголовка
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


## **Связывание всех шрифтов при преобразовании презентации в HTML**

Если вы не хотите внедрять шрифты (чтобы избежать увеличения размера получаемого HTML), вы можете связать все шрифты, реализовав свою версию `LinkAllFontsHtmlController`.

Этот код на Java показывает, как преобразовать PowerPoint в HTML, связывая все шрифты и исключая "Calibri" и "Arial" (поскольку они уже присутствуют в системе):
```java
Presentation pres = new Presentation("pres.pptx");
try
{
    // Исключить шрифты презентации по умолчанию
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList,"C:/Windows/Fonts/");

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter((IHtmlFormattingController) linkcont));

    pres.save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
finally {
    if (pres != null) pres.dispose();
}
```


Этот код на Java показывает, как реализован `LinkAllFontsHtmlController`:
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

Этот код на Java показывает, как преобразовать презентацию PowerPoint в адаптивный HTML:
```java
Presentation pres = new Presentation("SomePresentation.pptx");
try {
    HtmlOptions saveOptions = new HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Экспорт медиа‑файлов в HTML**

С помощью Aspose.Slides for Java вы можете экспортировать медиа‑файлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Получите ссылку на слайд.
3. Добавьте видео на слайд.
4. Запишите презентацию в виде HTML‑файла.

Этот код на Java демонстрирует, как добавить видео в презентацию и затем сохранить её в HTML:
```java
// Загрузка презентации
Presentation pres = new Presentation();
try {
    String path = "./out/";
    final String fileName = "ExportMediaFiles_out.html";
    final String baseUri = "http://www.example.com/";

    byte[] videoData = Files.readAllBytes(Paths.get("my_video.avi"));
    IVideo video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // Настройка параметров HTML
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(SlideImageFormat.svg(svgOptions));

    // Сохранение файла
    pres.save(fileName, SaveFormat.Html, htmlOptions);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Какова производительность Aspose.Slides при преобразовании нескольких презентаций в HTML?**

Производительность зависит от размера и сложности презентаций. Aspose.Slides обладает высокой эффективностью и масштабируемостью для пакетных операций. Для достижения оптимальной производительности при преобразовании большого количества презентаций рекомендуется использовать многопоточность или параллельную обработку, когда это возможно.

**Поддерживает ли Aspose.Slides экспорт гиперссылок в HTML?**

Да, Aspose.Slides полностью поддерживает экспорт встроенных гиперссылок в HTML. При преобразовании презентаций в формат HTML гиперссылки автоматически сохраняются и остаются кликабельными.

**Существует ли ограничение на количество слайдов при преобразовании презентаций в HTML?**

При использовании Aspose.Slides нет ограничения на количество слайдов. Вы можете преобразовать презентации любого размера. Однако для презентаций, содержащих очень большое количество слайдов, производительность может зависеть от доступных ресурсов вашего сервера или системы.