---
title: Преобразование презентаций PowerPoint в HTML на Android
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint в адаптивный HTML на Java. Сохраните макет, ссылки и изображения с помощью Aspose.Slides для Android — руководство по конвертации для быстрых и безошибочных результатов."
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формат HTML с помощью Java. Она охватывает следующие темы.

- Преобразование PowerPoint в HTML в Java
- Преобразование PPT в HTML в Java
- Преобразование PPTX в HTML в Java
- Преобразование ODP в HTML в Java
- Преобразование слайда PowerPoint в HTML в Java

## **PowerPoint в HTML на Android**

Для примера кода Java, преобразующего PowerPoint в HTML, см. раздел ниже — [Преобразовать PowerPoint в HTML](#convert-powerpoint-to-html). Код может загрузить различные форматы, такие как PPT, PPTX и ODP, в объект Presentation и сохранить его в формате HTML.

## **О конвертации PowerPoint в HTML**
С помощью [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/) приложения и разработчики могут конвертировать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**.

**Aspose.Slides** предлагает множество параметров (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions)), определяющих процесс конвертации PowerPoint в HTML:

* Конвертировать всю презентацию PowerPoint в HTML.
* Конвертировать определённый слайд презентации PowerPoint в HTML.
* Конвертировать медиафайлы презентации (изображения, видео и т.д.) в HTML.
* Конвертировать презентацию PowerPoint в адаптивный HTML. 
* Конвертировать презентацию PowerPoint в HTML с включёнными или исключёнными заметками докладчика. 
* Конвертировать презентацию PowerPoint в HTML с включёнными или исключёнными комментариями. 
* Конвертировать презентацию PowerPoint в HTML с оригинальными или встроенными шрифтами. 
* Конвертировать презентацию PowerPoint в HTML, используя новый стиль CSS. 

{{% alert color="primary" %}} 

Используя собственный API, Aspose разработала бесплатные конвертеры [презентация в HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP в HTML](https://products.aspose.app/slides/conversion/odp-to-html) и т.д. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Вы можете ознакомиться с другими [бесплатными конвертерами от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}} 

Помимо описанных здесь процессов конвертации, Aspose.Slides также поддерживает следующие операции, связанные с форматом HTML: 

* [HTML в изображение](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}


## **Преобразовать PowerPoint в HTML**
С помощью Aspose.Slides вы можете преобразовать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). 
1. Вызовите метод [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) для сохранения объекта как HTML‑файла.

Этот код показывает, как преобразовать PowerPoint в HTML на Java:
```java
// Создать объект Presentation, представляющий файл презентации
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
Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ResponsiveHtmlController), который позволяет генерировать адаптивные HTML‑файлы. Этот код показывает, как преобразовать презентацию PowerPoint в адаптивный HTML на Java:
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
Этот код показывает, как преобразовать PowerPoint в HTML с заметками на Java:
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

Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController), который позволяет встроить все шрифты презентации при конвертации её в HTML.

Чтобы исключить из встраивания отдельные шрифты, можно передать массив имён шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController). Популярные шрифты, такие как Calibri или Arial, используемые в презентации, не необходимо встраивать, поскольку они уже присутствуют в большинстве систем. Встраивание этих шрифтов лишь увеличивает размер получаемого HTML‑документа.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) поддерживает наследование и предоставляет метод [WriteFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-), который следует переопределить.
```java
Presentation pres = new Presentation("input.pptx");
try {
    // исключить шрифты по умолчанию презентации
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

По умолчанию при конвертации PowerPoint в HTML Aspose.Slides генерирует небольшой HTML с изображениями 72 DPI и удалёнными обрезанными областями. Чтобы получить HTML‑файлы с изображениями более высокого качества, необходимо установить свойство `PicturesCompression` (из класса `HtmlOptions`) в значение 96 (т.е. `PicturesCompression.Dpi96`) или выше — [см. доступные значения](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PicturesCompression).

Этот Java‑код показывает, как преобразовать презентацию PowerPoint в HTML, получив изображения высокого качества 150 DPI (т.e. `PicturesCompression.Dpi150`):
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


Этот код на Java показывает, как вывести HTML с изображениями полной четкости:
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
Чтобы преобразовать определённый слайд PowerPoint в HTML, необходимо создать экземпляр того же класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation), который используется для конвертации целой презентации, а затем вызвать метод [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) для сохранения файла как HTML. Класс [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) может использоваться для указания дополнительных параметров конвертации:

Этот Java‑код показывает, как преобразовать слайд презентации PowerPoint в HTML:
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



## **Сохранить CSS и изображения при экспорте в HTML**
Используя новые файлы стилей CSS, вы можете легко изменить внешний вид HTML‑файла, полученного в результате конвертации PowerPoint в HTML. 

Java‑код в этом примере демонстрирует, как с помощью переопределяемых методов создать пользовательский HTML‑документ со ссылкой на файл CSS:
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

Если вы не хотите встраивать шрифты (чтобы избежать увеличения размера получаемого HTML), можно связать все шрифты, реализовав собственную версию `LinkAllFontsHtmlController`. 

Этот Java‑код показывает, как преобразовать PowerPoint в HTML, связывая все шрифты и исключая «Calibri» и «Arial» (поскольку они уже присутствуют в системе): 
```java
Presentation pres = new Presentation("pres.pptx");
try
{
    // Исключить шрифты по умолчанию презентации
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
Этот Java‑код показывает, как преобразовать презентацию PowerPoint в адаптивный HTML:
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
С помощью Aspose.Slides for Android via Java вы можете экспортировать медиафайлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). 
1. Получите ссылку на слайд. 
1. Добавьте видео на слайд. 
1. Запишите презентацию как HTML‑файл.

Этот Java‑код показывает, как добавить видео в презентацию и затем сохранить её как HTML: 
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

    // Установка параметров HTML
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

**Какова производительность Aspose.Slides при конвертации нескольких презентаций в HTML?**

Производительность зависит от размера и сложности презентаций. Aspose.Slides обладает высокой эффективностью и масштабируемостью для пакетных операций. Чтобы достичь оптимальной производительности при конвертации большого количества презентаций, рекомендуется использовать многопоточность или параллельную обработку, когда это возможно.

**Поддерживает ли Aspose.Slides экспорт гиперссылок в HTML?**

Да, Aspose.Slides полностью поддерживает экспорт встроенных гиперссылок в HTML. При конвертации презентаций в формат HTML гиперссылки сохраняются автоматически и остаются кликабельными.

**Существует ли ограничение на количество слайдов при конвертации презентаций в HTML?**

Ограничения на количество слайдов при использовании Aspose.Slides нет. Вы можете конвертировать презентации любого размера. Однако для презентаций с очень большим числом слайдов производительность может зависеть от доступных ресурсов вашего сервера или системы.