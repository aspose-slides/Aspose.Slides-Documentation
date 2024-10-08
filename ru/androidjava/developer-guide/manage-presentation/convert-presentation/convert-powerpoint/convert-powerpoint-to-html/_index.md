---
title: Конвертировать PowerPoint в HTML на Java
linktitle: Конвертировать PowerPoint в HTML
type: docs
weight: 30
url: /ru/androidjava/convert-powerpoint-to-html/
keywords: "Java PowerPoint в HTML, Конвертировать презентацию PowerPoint, PPTX, PPT, PPT в HTML, PPTX в HTML, PowerPoint в HTML, Сохранить PowerPoint как HTML, Сохранить PPT как HTML, Сохранить PPTX как HTML, Java, Aspose.Slides, экспорт в HTML"
description: "Конвертировать PowerPoint в HTML на Java: Сохраните PPTX или PPT как HTML на Java. Сохраните слайды как HTML на Java"
---

## **Обзор**

В этой статье объясняется, как конвертировать презентацию PowerPoint в формат HTML с использованием Java. Рассматриваются следующие темы.

- Конвертация PowerPoint в HTML на Java
- Конвертация PPT в HTML на Java
- Конвертация PPTX в HTML на Java
- Конвертация ODP в HTML на Java
- Конвертация слайда PowerPoint в HTML на Java

## **Java PowerPoint в HTML**

Для примера кода на Java, чтобы конвертировать PowerPoint в HTML, смотрите раздел ниже т.е. [Конвертировать PowerPoint в HTML](#convert-powerpoint-to-html). Код может загружать различные форматы, такие как PPT, PPTX и ODP в объект Presentation и сохранять его в формат HTML.

## **О конверсии PowerPoint в HTML**
С помощью [**Aspose.Slides для Android через Java**](https://products.aspose.com/slides/androidjava/) приложения и разработчики могут конвертировать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**.

**Aspose.Slides** предоставляет множество опций (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions)), которые определяют процесс конверсии PowerPoint в HTML:

* Конвертировать всю презентацию PowerPoint в HTML.
* Конвертировать конкретный слайд в презентации PowerPoint в HTML.
* Конвертировать медиа-презентацию (изображения, видео и т. д.) в HTML.
* Конвертировать презентацию PowerPoint в адаптивный HTML.
* Конвертировать презентацию PowerPoint в HTML с включенными или исключенными заметками. 
* Конвертировать презентацию PowerPoint в HTML с включенными или исключенными комментариями. 
* Конвертировать презентацию PowerPoint в HTML с оригинальными или встроенными шрифтами. 
* Конвертировать презентацию PowerPoint в HTML с использованием нового CSS-стиля. 

{{% alert color="primary" %}} 

С помощью собственного API Aspose разработал бесплатные [конвертеры презентаций в HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP в HTML](https://products.aspose.app/slides/conversion/odp-to-html) и т.д. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Вы также можете ознакомиться с другими [бесплатными конвертерами от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}} 

Кроме описанных здесь процессов конверсии, Aspose.Slides также поддерживает эти операции конверсии, связанные с форматом HTML:

* [HTML в изображение](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}


## **Конвертировать PowerPoint в HTML**
С помощью Aspose.Slides вы можете конвертировать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Используйте метод [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) для сохранения объекта как HTML-файл.

Этот код показывает, как конвертировать PowerPoint в HTML на Java:

```java
// Создание экземпляра объекта Presentation, представляющего файл презентации
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


## **Конвертировать PowerPoint в адаптивный HTML**
Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ResponsiveHtmlController), который позволяет создавать адаптивные HTML-файлы. Этот код показывает, как конвертировать презентацию PowerPoint в адаптивный HTML на Java:

```java
// Создание экземпляра объекта Presentation, представляющего файл презентации
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

## **Конвертировать PowerPoint в HTML с заметками**
Этот код показывает, как конвертировать PowerPoint в HTML с заметками на Java:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    HtmlOptions opt = new HtmlOptions();
	
    INotesCommentsLayoutingOptions options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    // Сохранение страниц с заметками
    pres.save("Output.html", SaveFormat.Html, opt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Конвертировать PowerPoint в HTML с оригинальными шрифтами**

Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController), который позволяет встроить все шрифты в презентацию при конвертации презентации в HTML.

Чтобы предотвратить встраивание определенных шрифтов, вы можете передать массив имен шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController). Популярные шрифты, такие как Calibri или Arial, при использовании в презентации не должны быть встроены, так как большинство систем уже содержат такие шрифты. Когда эти шрифты встраиваются, результирующий HTML-документ становится ненужным большим.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) поддерживает наследование и предоставляет метод [WriteFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-), который предназначен для переопределения.

```java
Presentation pres = new Presentation("input.pptx");
try {
    // исключить стандартные шрифты презентации
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter(embedFontsController));

    pres.save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Конвертировать PowerPoint в HTML с изображениями высокого качества**

По умолчанию, когда вы конвертируете PowerPoint в HTML, Aspose.Slides выводит маленький HTML с изображениями разрешением 72 DPI и удаленными обрезанными областями. Чтобы получить HTML-файлы с изображениями более высокого качества, вам необходимо установить свойство `PicturesCompression` (из класса `HtmlOptions`) на 96 (т.е. `PicturesCompression.Dpi96`) или выше [значений](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PicturesCompression).

Этот код на Java показывает, как конвертировать презентацию PowerPoint в HTML, получая изображения высокого качества при 150 DPI (т.е. `PicturesCompression.Dpi150`):

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

Этот код на Java показывает, как вывести HTML с полными качественными изображениями:

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

## **Конвертировать слайд в HTML**
Чтобы конвертировать конкретный слайд из PowerPoint в HTML, вам нужно создать экземпляр того же класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) (используемого для конвертации целых презентаций в HTML), а затем использовать метод [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) для сохранения файла в формате HTML. Класс [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) можно использовать для указания дополнительных опций конверсии:

Этот код на Java показывает, как конвертировать слайд в презентации PowerPoint в HTML:

```java
Presentation pres = new Presentation("Individual-Slide.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(new CustomFormattingController()));

    // Сохранение файла
    for (int i = 0; i < pres.getSlides().size(); i++)
        pres.save("Индивидуальный Слайд" + (i + 1) + "_out.html", new int[]{i + 1},SaveFormat.Html, htmlOptions);
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


## **Сохранить CSS и изображения при экспорте в HTML**
Используя новые файлы стилей CSS, вы можете легко изменить стиль HTML-файла, полученного в результате процесса конверсии PowerPoint в HTML. 

Код на Java в этом примере показывает, как использовать переопределяемые методы для создания пользовательского HTML-документа со ссылкой на файл CSS:

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
        generator.addHtml("<!-- Встроенные шрифты -->");
        super.writeAllFonts(generator, presentation);
    }
}
```

## **Ссылаться на все шрифты при конвертации презентации в HTML**

Если вы не хотите встраивать шрифты (чтобы избежать увеличения размера результирующего HTML), вы можете ссылаться на все шрифты, реализовав собственную версию `LinkAllFontsHtmlController`.

Этот код на Java показывает, как конвертировать PowerPoint в HTML, ссылаясь на все шрифты и исключая "Calibri" и "Arial" (так как они уже существуют в системе):

```java
Presentation pres = new Presentation("pres.pptx");
try
{
    // Исключить стандартные шрифты презентации
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
            String path = fontName + ".woff"; // может понадобиться некоторая санитария пути
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

## **Конвертировать PowerPoint в адаптивный HTML**
Этот код на Java показывает, как конвертировать презентацию PowerPoint в адаптивный HTML:

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


## **Экспорт медиафайлов в HTML**
С помощью Aspose.Slides для Android через Java вы можете экспортировать медиафайлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Получите ссылку на слайд.
1. Добавьте видео на слайд.
1. Запишите презентацию как HTML-файл.

Этот код на Java показывает, как добавить видео в презентацию и затем сохранить его как HTML: 

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

    // Установка опций HTML
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