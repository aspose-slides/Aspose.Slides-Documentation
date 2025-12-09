---
title: Преобразование презентаций PowerPoint в HTML в .NET
linktitle: PowerPoint в HTML
type: docs
weight: 30
url: /ru/net/convert-powerpoint-to-html/
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
- .NET
- C#
- Aspose.Slides
description: "Преобразуйте презентации PowerPoint в адаптивный HTML в .NET. Сохраняйте макет, ссылки и изображения с помощью руководства по конвертации Aspose.Slides для быстрых и безошибочных результатов."
---

## **Обзор**

Улучшите ваш рабочий процесс, преобразуя презентации PowerPoint и OpenDocument в HTML с помощью Aspose.Slides для .NET. Это руководство предлагает подробные инструкции, надёжные примеры кода и проверенные методы, обеспечивая надёжный и эффективный процесс конвертации, оптимизированный для веб‑просмотра.

Aspose.Slides предоставляет множество параметров — в основном из класса [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) — которые определяют процесс преобразования из формата PowerPoint (или OpenDocument) в HTML:

* Преобразовать всю презентацию PowerPoint в HTML.
* Преобразовать отдельный слайд в презентации PowerPoint в HTML.
* Преобразовать медиа‑файлы презентации (изображения, видео и т.д.) в HTML.
* Преобразовать презентацию PowerPoint в адаптивный HTML.
* Преобразовать презентацию PowerPoint в HTML с включёнными или исключёнными примечаниями докладчика.
* Преобразовать презентацию PowerPoint в HTML с включёнными или исключёнными комментариями.
* Преобразовать презентацию PowerPoint в HTML с оригинальными или встроенными шрифтами.
* Преобразовать презентацию PowerPoint в HTML, используя новый стиль CSS.

## **Преобразовать презентацию в HTML**

С помощью Aspose.Slides вы можете преобразовать всю презентацию PowerPoint или OpenDocument в HTML следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Используйте метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save), чтобы сохранить объект в файл HTML.

Этот код демонстрирует, как преобразовать презентацию PowerPoint в HTML на C#:
```c#
 // Создайте экземпляр класса Presentation, представляющего файл презентации (например, PPT, PPTX, ODP и т.д.).
 using (Presentation presentation = new Presentation("presentation.pptx"))
 {
     // Сохраните презентацию в формате HTML.
     presentation.Save("output.html", SaveFormat.Html);
 }
```


## **Преобразовать презентацию в адаптивный HTML**

Aspose.Slides предоставляет класс [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller), который позволяет генерировать адаптивные HTML‑файлы. Этот код демонстрирует, как преобразовать презентацию PowerPoint в адаптивный HTML на C#:
```c#
 // Создайте экземпляр класса Presentation, который представляет файл презентации.
 using (Presentation presentation = new Presentation("presentation.pptx"))
 {
     ResponsiveHtmlController controller = new ResponsiveHtmlController();

     HtmlOptions htmlOptions = new HtmlOptions 
     { 
         HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) 
     };

     // Сохраните презентацию в формате HTML.
     presentation.Save("responsive.html", SaveFormat.Html, htmlOptions);
 }
```


## **Преобразовать презентацию в HTML с примечаниями докладчика**

Когда вы преобразуете презентацию PowerPoint или OpenDocument в HTML с примечаниями докладчика, важно сохранить полную суть оригинального документа. Этот процесс гарантирует, что не только визуальные элементы слайдов точно отображаются, но и сопутствующие примечания докладчика сохраняются, обогащая контент дополнительным контекстом и инсайтами.

Предположим, у нас есть презентация PowerPoint со следующим слайдом:

![Слайд презентации с примечаниями докладчика](slide_with_notes.png)

Этот код демонстрирует, как преобразовать презентацию PowerPoint в HTML с примечаниями докладчика на C#:
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // Установить параметры для примечаний докладчика.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Установить параметры для выходного HTML-документа.
    HtmlOptions htmlOptions = new HtmlOptions
    {
        SlidesLayoutOptions = notesOptions
    };

    // Сохранить презентацию в HTML с примечаниями докладчика.
    presentation.Save("slide_with_notes.html", SaveFormat.Html, htmlOptions);
}
```


Результат:

![HTML‑документ со слайдом и примечаниями докладчика](HTML_with_notes.png)

## **Преобразовать презентацию в HTML с оригинальными шрифтами**

Aspose.Slides предоставляет класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller), который позволяет включать все шрифты презентации при её преобразовании в HTML.

Чтобы предотвратить включение определённых шрифтов, вы можете передать массив имён шрифтов в параметризованный конструктор класса [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller). Популярные шрифты, такие как Calibri или Arial, не нуждаются в включении, поскольку большинство систем уже содержат эти шрифты. Их включение лишь необязательно увеличит размер получаемого HTML‑документа.

Класс [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) поддерживает наследование и предоставляет метод [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont), который предназначен для переопределения.
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    // Исключить шрифты презентации по умолчанию.
    string[] excludeFonts = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(excludeFonts);

    HtmlOptions htmlOptions = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(fontController)
    };

    presentation.Save("embedded_fonts.html", SaveFormat.Html, htmlOptions);
}
```


## **Преобразовать презентацию в HTML с изображениями высокого качества**

По умолчанию при конвертации презентации PowerPoint в HTML Aspose.Slides создаёт небольшой HTML‑файл с изображениями в 72 DPI и удаляет обрезанные области. Чтобы получить HTML‑файлы с изображениями более высокого качества, необходимо установить свойство `PicturesCompression` (из класса `HtmlOptions`) в 96 (т.е. `PicturesCompression.Dpi96`) или более высокое значение, как описано в [этой ссылке](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression).

Этот код на C# демонстрирует, как преобразовать презентацию PowerPoint в HTML, получив изображения высокого качества в 150 DPI (т.е. `PicturesCompression.Dpi150`):
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    HtmlOptions htmlOptions = new HtmlOptions
    {
        PicturesCompression = PicturesCompression.Dpi150
    };

    presentation.Save("output_dpi_150.html", SaveFormat.Html, htmlOptions);
}
```


Этот код на C# показывает, как преобразовать презентацию PowerPoint в HTML без удаления обрезанных областей:
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    HtmlOptions htmlOptions = new HtmlOptions
    {
        DeletePicturesCroppedAreas = false
    };

    presentation.Save("output_no_crop.html", SaveFormat.Html, htmlOptions);
}
```


## **Преобразовать слайд презентации в HTML**

Чтобы преобразовать отдельный слайд в презентации PowerPoint в HTML, необходимо создать экземпляр того же класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), который используется для конвертации всей презентации, а затем вызвать метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) для сохранения файла в формате HTML. Класс [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) можно использовать для указания дополнительных параметров конвертации.

Этот код на C# демонстрирует, как преобразовать слайд с примечаниями докладчика в презентации PowerPoint в HTML:
```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("sample.pptx"))
    {
        NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull
        };

        HtmlOptions htmlOptions = new HtmlOptions
        {
            SlidesLayoutOptions = notesOptions,
            HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController())
        };

        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            int slideIndex = i + 1;

            // Сохранить слайд в HTML-файл.
            string fileName = $"output_slide_{slideIndex}.html";
            presentation.Save(fileName, new[] { slideIndex }, SaveFormat.Html, htmlOptions);
        }
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


## **Сохранить CSS и изображения при экспорте в HTML**

Используя файлы новых стилей CSS, вы можете легко изменить внешний вид HTML‑файла, созданного в процессе конвертации PowerPoint в HTML.

Код на C# в этом примере демонстрирует, как использовать переопределяемые методы для создания пользовательского HTML‑документа, включающего ссылку на файл CSS:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
	CustomHeaderAndFontsController htmlController = new CustomHeaderAndFontsController("styles.css");

	HtmlOptions options = new HtmlOptions
	{
		HtmlFormatter = HtmlFormatter.CreateCustomFormatter(htmlController),
	};
	presentation.Save("pres.html", SaveFormat.Html, options);
}
```

```c#
public class CustomHeaderAndFontsController : EmbedAllFontsHtmlController
{
    // Шаблон пользовательского заголовка.
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
        generator.AddHtml("<!-- Embedded fonts -->");
        base.WriteAllFonts(generator, presentation);
    }
}
```


## **Подключить все шрифты при преобразовании презентации в HTML**

Если вы не хотите включать шрифты (чтобы не увеличивать размер получаемого HTML), вы можете подключить все шрифты, реализовав собственную версию `LinkAllFontsHtmlController`.

Этот код на C# показывает, как преобразовать презентацию PowerPoint в HTML, подключив все шрифты и исключив «Calibri» и «Arial» (поскольку они уже установлены в системе):
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    // Исключить шрифты презентации по умолчанию.
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    presentation.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
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
            string path = fontName + ".woff"; // Возможно, потребуется очистка пути.

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


## **Преобразовать презентацию с SVG‑изображениями в адаптивный HTML**

Этот код на C# показывает, как преобразовать презентацию PowerPoint в адаптивный HTML:
```c#
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    HtmlOptions saveOptions = new HtmlOptions
    {
        SvgResponsiveLayout = true
    };

    presentation.Save("SvgResponsiveLayout-out.html", SaveFormat.Html, saveOptions);
}
```


## **Экспортировать медиа‑файлы в HTML**

С помощью Aspose.Slides for .NET вы можете экспортировать медиа‑файлы следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд.
3. Добавьте видео на слайд.
4. Запишите презентацию в файл HTML.

Этот код на C# показывает, как добавить видео в презентацию и затем сохранить её в HTML:
```c#
// Создать новую презентацию.
using (Presentation presentation = new Presentation())
{
    string path = "C:/out/";
    const string fileName = "ExportMediaFiles_out.html";
    const string baseUri = "http://www.example.com/";

    using (FileStream fileStream = new FileStream("my_video.avi", FileMode.Open, FileAccess.Read))
    {
        IVideo video = presentation.Videos.AddVideo(fileStream, LoadingStreamBehavior.ReadStreamAndRelease);
        
        ISlide slide = presentation.Slides[0];
        slide.Shapes.AddVideoFrame(10, 10, 100, 100, video);
    }
        
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // Установить параметры HTML.
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // Сохранить презентацию в HTML-файл.
    presentation.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```


{{% alert color="primary" %}} 

Aspose разработала бесплатные конвертеры [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html): [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) и т.д.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Ознакомьтесь с другими [бесплатными конвертерами от Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Помимо описанных здесь процессов конвертации, Aspose.Slides также поддерживает следующие операции преобразования, связанные с форматом HTML:

* [HTML в изображение](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML в JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML в XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML в TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

**Какова производительность Aspose.Slides при конвертации нескольких презентаций в HTML?**

Производительность зависит от размера и сложности презентаций. Aspose.Slides обладает высокой эффективностью и масштабируемостью для пакетных операций. Чтобы достичь оптимальной производительности при конвертации большого количества презентаций, рекомендуется использовать многопоточность или параллельную обработку, когда это возможно.

**Поддерживает ли Aspose.Slides экспорт гиперссылок в HTML?**

Да, Aspose.Slides полностью поддерживает экспорт встроенных гиперссылок в HTML. При конвертации презентаций в формат HTML гиперссылки сохраняются автоматически и остаются кликабельными.

**Есть ли ограничение на количество слайдов при конвертации презентаций в HTML?**

Ограничений на количество слайдов при использовании Aspose.Slides нет. Вы можете конвертировать презентации любого размера. Однако для презентаций, содержащих очень большое число слайдов, производительность может зависеть от доступных ресурсов вашего сервера или системы.