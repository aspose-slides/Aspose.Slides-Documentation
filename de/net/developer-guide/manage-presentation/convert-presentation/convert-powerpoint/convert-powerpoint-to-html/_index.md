---
title: PowerPoint in HTML konvertieren in C# .NET
linktitle: PowerPoint in HTML konvertieren
type: docs
weight: 30
url: /de/net/convert-powerpoint-to-html/
keywords: "C# PowerPoint in HTML, C# PPT in HTML, C# ODP in HTML, C# Folie in HTML, PowerPoint-Präsentation konvertieren, PPTX, PPT, PPT in HTML, PPTX in HTML, PowerPoint in HTML, PowerPoint als HTML speichern, PPT als HTML speichern, PPTX als HTML speichern, C#, Csharp, .NET, Aspose.Slides, HTML Export"
description: "PowerPoint HTML konvertieren: Speichern Sie PPTX oder PPT als HTML. Speichern Sie Folien als HTML"
---

## **Überblick**

Dieser Artikel erklärt, wie man eine PowerPoint-Präsentation im HTML-Format mit C# konvertiert. Es werden die folgenden Themen behandelt.

- [PowerPoint in HTML konvertieren in C#](#convert-powerpoint-to-html)
- [PPT in HTML konvertieren in C#](#convert-powerpoint-to-html)
- [PPTX in HTML konvertieren in C#](#convert-powerpoint-to-html)
- [ODP in HTML konvertieren in C#](#convert-powerpoint-to-html)
- [PowerPoint-Folie in HTML konvertieren in C#](#convert-slide-to-html)

## **C# PowerPoint in HTML**

Für C# Beispielcode zum Konvertieren von PowerPoint in HTML siehe den Abschnitt unten d.h. [PowerPoint in HTML konvertieren](#convert-powerpoint-to-html). Der Code kann eine Vielzahl von Formaten wie PPT, PPTX und ODP im Präsentationsobjekt laden und in das HTML-Format speichern.

## **Über die PowerPoint-zu-HTML-Konvertierung**
Mit [**Aspose.Slides für .NET**](https://products.aspose.com/slides/net/) können Anwendungen und Entwickler eine PowerPoint-Präsentation in HTML konvertieren: **PPTX in HTML** oder **PPT in HTML**.

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) Klasse), die den Konvertierungsprozess von PowerPoint in HTML definieren:

* Gesamte PowerPoint-Präsentation in HTML konvertieren.
* Eine spezifische Folie in einer PowerPoint-Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint-Präsentation in responsives HTML konvertieren.
* Eine PowerPoint-Präsentation in HTML mit eingeschlossenen oder ausgeschlossenen Sprecherhinweisen konvertieren.
* Eine PowerPoint-Präsentation in HTML mit eingeschlossenen oder ausgeschlossenen Kommentaren konvertieren.
* Eine PowerPoint-Präsentation in HTML mit originalen oder eingebetteten Schriftarten konvertieren.
* Eine PowerPoint-Präsentation in HTML konvertieren und den neuen CSS-Stil verwenden.

{{% alert color="primary" %}} 

Mit seiner eigenen API hat Aspose kostenlose [Präsentation zu HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Sie möchten vielleicht auch andere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) überprüfen.

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

Neben den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides auch diese Konvertierungsoperationen, die das HTML-Format betreffen: 

* [HTML zu Bild](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPoint in HTML konvertieren**
Mit Aspose.Slides können Sie eine gesamte PowerPoint-Präsentation auf diese Weise in HTML konvertieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Verwenden Sie die [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)Methode, um das Objekt als HTML-Datei zu speichern.

Dieser Code zeigt, wie man eine PowerPoint in HTML in C# konvertiert:

```c#
// Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei e.g. PPT, PPTX, ODP usw. darstellt.
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    HtmlOptions htmlOpt = new HtmlOptions();
    
    INotesCommentsLayoutingOptions options = htmlOpt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;
    
    htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

    // Speichert die Präsentation als HTML
    presentation.Save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
}
```


## **PowerPoint in responsives HTML konvertieren**
Aspose.Slides bietet die [ResponsiveHtmlController ](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller)Klasse, die es Ihnen ermöglicht, responsive HTML-Dateien zu generieren. Dieser Code zeigt, wie man eine PowerPoint-Präsentation in responsives HTML in C# konvertiert:

```c#
// Instanziiert ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("Convert_HTML.pptx"))
{
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions { HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) };

    // Speichert die Präsentation als HTML
    presentation.Save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
}
```

## **PowerPoint in HTML mit Notizen konvertieren**
Dieser Code zeigt, wie man eine PowerPoint in HTML mit Notizen in C# konvertiert:

```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    HtmlOptions opt = new HtmlOptions();

    INotesCommentsLayoutingOptions options = opt.NotesCommentsLayouting;
    options.NotesPosition = NotesPositions.BottomFull;

    // Speichert Notizseiten
    pres.Save("Output.html", SaveFormat.Html, opt);
}
```

## **PowerPoint in HTML mit originalen Schriftarten konvertieren**

Aspose.Slides bietet die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) Klasse, die es Ihnen ermöglicht, alle Schriftarten in einer Präsentation beim Konvertieren der Präsentation in HTML einzubetten.

Um zu verhindern, dass bestimmte Schriftarten eingebettet werden, können Sie ein Array von Schriftartnamen an einen parameterisierten Konstruktor der [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) Klasse übergeben. Beliebte Schriftarten, wie Calibri oder Arial, müssen in einer Präsentation nicht eingebettet werden, da die meisten Systeme bereits über solche Schriftarten verfügen. Wenn diese Schriftarten eingebettet werden, wird das resultierende HTML-Dokument unnötig groß.

Die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) Klasse unterstützt Vererbung und bietet die [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) Methode, die überschrieben werden soll. 

```c#
using (Presentation pres = new Presentation("input.pptx"))
{
    // Schließt Standard-Präsentationsschriftarten aus
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(embedFontsController)
    };

    pres.Save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

## **PowerPoint in HTML mit hochwertigen Bildern konvertieren**

Standardmäßig gibt Aspose.Slides beim Konvertieren von PowerPoint in HTML kleine HTML-Dokumente mit Bildern in 72 DPI und entfernten zugeschnittenen Bereichen aus. Um HTML-Dateien mit höherer Bildqualität zu erhalten, müssen Sie die `PicturesCompression`-Eigenschaft (aus der `HtmlOptions`-Klasse) auf 96 (d.h. `PicturesCompression.Dpi96`) oder höhere [Werte](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression) setzen.

Dieser C#-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in HTML konvertieren, während Sie Bilder in hoher Qualität mit 150 DPI (d.h. `PicturesCompression.Dpi150`) erhalten:

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};
pres.Save("OutputDoc-dpi150.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts); 
```

Dieser Code in C# zeigt Ihnen, wie Sie HTML mit Bildern in voller Qualität ausgeben:

```c#
Presentation pres = new Presentation("InputDoc.pptx");
HtmlOptions htmlOpts = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};
pres.Save("Outputdoc-noCrop.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpts);
```

## **Folie in HTML konvertieren**
Um eine spezifische Folie in einer PowerPoint in HTML zu konvertieren, müssen Sie dieselbe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse instanziieren (die verwendet wird, um ganze Präsentationen in HTML zu konvertieren) und dann die [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)Methode verwenden, um die Datei als HTML zu speichern. Die [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions**) Klasse kann verwendet werden, um zusätzliche Konvertierungsoptionen anzugeben:

Dieser C#-Code zeigt Ihnen, wie Sie eine Folie in einer PowerPoint-Präsentation in HTML konvertieren:

```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("Individual-Slide.pptx"))
    {
        HtmlOptions htmlOptions = new HtmlOptions();

        INotesCommentsLayoutingOptions options = htmlOptions.NotesCommentsLayouting;
        options.NotesPosition = NotesPositions.BottomFull;

        htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(new CustomFormattingController());

        // Speichert Datei              
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


## **CSS und Bilder beim Exportieren nach HTML speichern**
Mit neuen CSS-Stilvorlagen können Sie leicht den Stil der HTML-Datei ändern, die aus dem PowerPoint-zu-HTML-Konvertierungsprozess resultiert. 

Der C#-Code in diesem Beispiel zeigt Ihnen, wie Sie überschreibbare Methoden verwenden, um ein benutzerdefiniertes HTML-Dokument mit einem Link zu einer CSS-Datei zu erstellen:

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
    // Benutzerdefinierte Header-Vorlage
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
        generator.AddHtml("<!-- Eingebettete Schriftarten -->");
        base.WriteAllFonts(generator, presentation);
    }
}
```

## **Alle Schriftarten verlinken, wenn die Präsentation nach HTML konvertiert wird**

Wenn Sie Schriftarten nicht einbetten möchten (um die Größe des resultierenden HTML zu vermeiden), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene Version von `LinkAllFontsHtmlController` implementieren. 

Dieser C#-Code zeigt Ihnen, wie man eine PowerPoint in HTML konvertiert, während man alle Schriftarten verlinkt und "Calibri" und "Arial" ausschließt (da sie bereits im System vorhanden sind): 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Schließt Standard-Präsentationsschriftarten aus
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    Paragraph para = new Paragraph();
    ITextFrame txt;

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    pres.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```

Dieser C#-Code zeigt, wie `LinkAllFontsHtmlController` implementiert wird:

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
            string path = fontName + ".woff"; // Einige Pfadsanierungsmaßnahmen könnten erforderlich sein

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

## **PowerPoint in responsives HTML konvertieren**
Dieser C#-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in responsives HTML konvertieren:

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
HtmlOptions saveOptions = new HtmlOptions();
saveOptions.SvgResponsiveLayout = true;
presentation.Save("SomePresentation-out.html", SaveFormat.Html, saveOptions);
```


## **Medien-Dateien nach HTML exportieren**
Mit Aspose.Slides für .NET können Sie Medien-Dateien auf diese Weise exportieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Holen Sie sich eine Referenz auf die Folie.
1. Fügen Sie ein Video zur Folie hinzu.
1. Schreiben Sie die Präsentation als HTML-Datei.

Dieser C#-Code zeigt Ihnen, wie Sie ein Video zur Präsentation hinzufügen und es dann als HTML speichern: 

```c#
// Lädt eine Präsentation
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

    // Setzt HTML-Optionen
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // Speichert die Datei
    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```