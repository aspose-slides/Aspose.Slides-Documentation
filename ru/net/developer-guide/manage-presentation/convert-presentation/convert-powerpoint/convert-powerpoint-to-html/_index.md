---
title: Преобразование PowerPoint в HTML на C# .NET
linktitle: Преобразование PowerPoint в HTML
type: docs
weight: 30
url: /net/convert-powerpoint-to-html/
keywords: "C# PowerPoint в HTML, C# PPT в HTML, C# ODP в HTML, C# Слайд в HTML, Преобразовать презентацию PowerPoint, PPTX, PPT, PPT в HTML, PPTX в HTML, PowerPoint в HTML, Сохранить PowerPoint как HTML, Сохранить PPT как HTML, Сохранить PPTX как HTML, C#, Csharp, .NET, Aspose.Slides, экспорт HTML"
description: "Преобразование PowerPoint в HTML: Сохраните PPTX или PPT как HTML. Сохраните слайды как HTML"
---

## **Обзор**

В этой статье объясняется, как преобразовать презентацию PowerPoint в формат HTML с использованием C#. Внутри рассматриваются следующие темы.

- [Преобразование PowerPoint в HTML на C#](#convert-powerpoint-to-html)
- [Преобразование PPT в HTML на C#](#convert-powerpoint-to-html)
- [Преобразование PPTX в HTML на C#](#convert-powerpoint-to-html)
- [Преобразование ODP в HTML на C#](#convert-powerpoint-to-html)
- [Преобразование слайда PowerPoint в HTML на C#](#convert-slide-to-html)

## **C# PowerPoint в HTML**

Для примера кода на C# для преобразования PowerPoint в HTML смотрите раздел ниже, т.е. [Преобразование PowerPoint в HTML](#convert-powerpoint-to-html). Код может загружать множество форматов, таких как PPT, PPTX и ODP в объект Presentation и сохранять его в формате HTML.

## **О преобразовании PowerPoint в HTML**
Используя [**Aspose.Slides для .NET**](https://products.aspose.com/slides/net/), приложения и разработчики могут преобразовать презентацию PowerPoint в HTML: **PPTX в HTML** или **PPT в HTML**. 

**Aspose.Slides** предлагает множество опций (в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions)), которые определяют процесс преобразования PowerPoint в HTML:

* Преобразование всей презентации PowerPoint в HTML.
* Преобразование конкретного слайда в презентации PowerPoint в HTML.
* Преобразование мультимедиа презентации (изображения, видео и т.д.) в HTML.
* Преобразование презентации PowerPoint в адаптивный HTML. 
* Преобразование презентации PowerPoint в HTML с заметками спикера, включенными или исключенными. 
* Преобразование презентации PowerPoint в HTML с комментариями, включенными или исключенными. 
* Преобразование презентации PowerPoint в HTML с оригинальными или встроенными шрифтами. 
* Преобразование презентации PowerPoint в HTML с использованием нового CSS-стиля. 

{{% alert color="primary" %}} 

Используя свой собственный API, Aspose разработал бесплатные [конвертеры презентаций в HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT в HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX в HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP в HTML](https://products.aspose.app/slides/conversion/odp-to-html) и т.д. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Вы можете также посмотреть другие [бесплатные конвертеры от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}} 

Кроме описанных здесь процессов преобразования, Aspose.Slides также поддерживает операции преобразования, касающиеся формата HTML: 

* [HTML в изображение](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}


## **Преобразование PowerPoint в HTML**
С использованием Aspose.Slides вы можете преобразовать всю презентацию PowerPoint в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Используйте метод [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save), чтобы сохранить объект в виде HTML-файла.

Этот код показывает, как преобразовать PowerPoint в HTML на C#:

```c#
// Создание объекта презентации, представляющего файл презентации, например PPT, PPTX, ODP и т.д.
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    HtmlOptions htmlOpt = new HtmlOptions();
    
    INotesCommentsLayoutingOptions options = htmlOpt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;
    
    htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

    // Сохранение презентации в HTML
    presentation.Save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
}
```


## **Преобразование PowerPoint в адаптивный HTML**
Aspose.Slides предоставляет класс [ResponsiveHtmlController ](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller), который позволяет генерировать адаптивные HTML-файлы. Этот код показывает, как преобразовать презентацию PowerPoint в адаптивный HTML на C#:

```c#
// Создание объекта Presentation, представляющего файл презентации
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions { HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) };

    // Сохранение презентации в HTML
    presentation.Save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
}
```

## **Преобразование PowerPoint в HTML с заметками**
Этот код показывает, как преобразовать PowerPoint в HTML с заметками на C#:

```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    HtmlOptions opt = new HtmlOptions();

    INotesCommentsLayoutingOptions options = opt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;

    // Сохранение страниц с заметками
    pres.Save("Output.html", SaveFormat.Html, opt);
}
```

## **Преобразование PowerPoint в HTML с оригинальными шрифтами**

Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller), который позволяет встроить все шрифты в презентацию при преобразовании презентации в HTML.

Чтобы предотвратить встраивание определенных шрифтов, вы можете передать массив названий шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller). Популярные шрифты, такие как Calibri или Arial, при использовании в презентации не нужно встраивать, так как большинство систем уже содержат такие шрифты. Когда эти шрифты встраивают, результирующий HTML-документ становится ненужным образом большим.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) поддерживает наследование и предоставляет метод [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont), который предназначен для переопределения. 

```c#
using (Presentation pres = new Presentation("input.pptx"))
{
    // Исключает шрифты презентации по умолчанию
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(embedFontsController)
    };

    pres.Save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

## **Преобразование PowerPoint в HTML с изображениями высокого качества**

По умолчанию, когда вы преобразуете PowerPoint в HTML, Aspose.Slides выводит маленький HTML с изображениями при 72 DPI и удаленными обрезанными областями. Чтобы получить HTML-файлы с изображениями более высокого качества, вам необходимо установить свойство `PicturesCompression` (из класса `HtmlOptions`) на 96 (т.е. `PicturesCompression.Dpi96`) или более [высокие значения](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression).

Этот код на C# показывает, как преобразовать презентацию PowerPoint в HTML, получая изображения высокого качества при 150 DPI (т.е. `PicturesCompression.Dpi150`):

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};
pres.Save("OutputDoc-dpi150.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts); 
```

Этот код на C# показывает, как вывести HTML с изображениями полного качества:

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};
pres.Save("Outputdoc-noCrop.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts);
```

## **Преобразование слайда в HTML**
Чтобы преобразовать конкретный слайд в PowerPoint в HTML, вам необходимо создать экземпляр того же класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) (используемого для преобразования целых презентаций в HTML) и затем использовать метод [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save), чтобы сохранить файл в виде HTML. Класс [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions**) может использоваться для указания дополнительных параметров преобразования:

Этот код на C# показывает, как преобразовать слайд в презентации PowerPoint в HTML:

```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("Individual-Slide.pptx"))
    {
        HtmlOptions htmlOptions = new HtmlOptions();

        INotesCommentsLayoutingOptions options = htmlOptions.NotesCommentsLayouting;
        options.NotesPosition = NotesPositions.BottomFull;

        htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController());

        // Сохранение файла              
        for (int i = 0; i < presentation.Slides.Count; i++)
            presentation.Save("Individual Slide" + (i + 1) + "_out.html", new[] { i + 1 }, SaveFormat.Html, htmlOptions);
    }
}

public class CustomFormattingController : IHtmlFormattingController
{
    void IHtmlFormattingController.WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {}

    void IHtmlFormattingController.WriteDocumentEnd(IHtmlGenerator generator, IPresentation presentation)
    {}

    void IHtmlFormattingController.WriteSlideStart(IHtmlGenerator generator, ISlide slide)
    {
        generator.AddHtml(string.Format(SlideHeader, generator.SlideIndex + 1));
    }

    void IHtmlFormattingController.WriteSlideEnd(IHtmlGenerator generator, ISlide slide)
    {
        generator.AddHtml(SlideFooter);
    }

    void IHtmlFormattingController.WriteShapeStart(IHtmlGenerator generator, IShape shape)
    {}

    void IHtmlFormattingController.WriteShapeEnd(IHtmlGenerator generator, IShape shape)
    {}

    private const string SlideHeader = "<div class=\"slide\" name=\"slide\" id=\"slide{0}\">";
    private const string SlideFooter = "</div>";
}
```


## **Сохранение CSS и изображений при экспортировании в HTML**
Используя новые CSS-стили, вы можете легко изменить стиль HTML-файла, полученного в результате процесса преобразования PowerPoint в HTML. 

Код на C# из этого примера демонстрирует, как использовать переопределяемые методы для создания настраиваемого HTML-документа с ссылкой на CSS-файл:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");
	HtmlOptions options = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(htmlController),
	};
	pres.Save("pres.html", SaveFormat.Html, options);
}
```

```c#
public class CustomHeaderAndFontsController : EmbedAllFontsHtmlController
{
    // Шаблон пользовательского заголовка
    const string Header = "<!DOCTYPE html>\n" +
                            "<html>\n" +
                            "<head>\n" +
                            "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n" +
                            "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9\">\n" +
                            "<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\">\n" +
                            "</head>";


    private readonly string m_cssFileName;

    public CustomHeaderAndFontsController(string cssFileName)
    {
        m_cssFileName = cssFileName;
    }

    public override void WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.AddHtml(string.Format(Header, m_cssFileName));
        WriteAllFonts(generator, presentation);
    }

    public override void WriteAllFonts(IHtmlGenerator generator, IPresentation presentation)
    {
        generator.AddHtml("<!-- Встроенные шрифты -->");
        base.WriteAllFonts(generator, presentation);
    }
}
```

## **Ссылка на все шрифты при преобразовании презентации в HTML**

Если вы не хотите встраивать шрифты (чтобы избежать увеличения размера результирующего HTML), вы можете ссылаться на все шрифты, реализовав собственную версию `LinkAllFontsHtmlController`. 

Этот код на C# показывает, как преобразовать PowerPoint в HTML, ссылаясь на все шрифты и исключая "Calibri" и "Arial" (так как они уже существуют в системе): 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Исключает шрифты презентации по умолчанию
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    Paragraph para = new Paragraph();
    ITextFrame txt;

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    pres.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

Этот код на C# показывает, как реализован `LinkAllFontsHtmlController`:

```c#
public class LinkAllFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string m_basePath;

    public LinkAllFontsHtmlController(string[] fontNameExcludeList, string basePath) : base(fontNameExcludeList)
    {
        m_basePath = basePath;
    }

    public override void WriteFont
    (
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            string fontStyle,
            string fontWeight,
            byte[] fontData)
    {
        try
        {
            string fontName = substitutedFont == null ? originalFont.FontName : substitutedFont.FontName;
            string path = fontName + ".woff"; // Возможно, потребуется санитация пути

            File.WriteAllBytes(Path.Combine(m_basePath, path), fontData);
            
            generator.AddHtml("<style>");
            generator.AddHtml("@font-face { ");
            generator.AddHtml("font-family: '" + fontName + "'; ");
            generator.AddHtml("src: url('" + path + "')");

            generator.AddHtml(" }");
            generator.AddHtml("</style>");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
```

## **Преобразование PowerPoint в адаптивный HTML**
Этот код на C# показывает, как преобразовать презентацию PowerPoint в адаптивный HTML:

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
HtmlOptions saveOptions = new HtmlOptions();
saveOptions.SvgResponsiveLayout = true;
presentation.Save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
```


## **Экспорт медиафайлов в HTML**
С использованием Aspose.Slides для .NET вы можете экспортировать медиафайлы таким образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд.
1. Добавьте видео на слайд.
1. Запишите презентацию в виде HTML-файла.

Этот код на C# показывает, как добавить видео в презентацию и затем сохранить ее как HTML: 

```c#
// Загружает презентацию
using (Presentation pres = new Presentation())
{
    string path = "C:/out/";
    const string fileName = "ExportMediaFiles_out.html";
    const string baseUri = "http://www.example.com/";

    using (FileStream fileStream = new FileStream("my_video.avi", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.ReadStreamAndRelease);
        
        ISlide slide = pres.Slides[0];
        slide.Shapes.AddVideoFrame(10, 10, 100, 100, video);
    }
        
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // Устанавливает параметры HTML
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // Сохранение файла
    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```