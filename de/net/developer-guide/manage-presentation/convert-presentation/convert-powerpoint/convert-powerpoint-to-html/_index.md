---
title: "PowerPoint-Präsentationen in HTML konvertieren in C#"
linktitle: "PowerPoint in HTML konvertieren"
type: docs
weight: 30
url: /de/net/convert-powerpoint-to-html/
keywords:
- PowerPoint zu HTML
- Präsentation zu HTML
- Folie zu HTML
- PPT zu HTML
- PPTX zu HTML
- ODP zu HTML
- PowerPoint-Präsentation konvertieren
- PowerPoint-Konvertierung
- Präsentationskonvertierung
- HTML-Konvertierung
- PowerPoint als HTML speichern
- Präsentation als HTML speichern
- Folie als HTML speichern
- PPT als HTML speichern
- PPTX als HTML speichern
- HTML-Export
- C#
- .NET
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET in HTML konvertieren. Dieser Leitfaden bietet Anweisungen, Codebeispiele und bewährte Methoden zum Konvertieren von Folien in ein web‑freundliches Format."
---

## **Übersicht**

Verbessern Sie Ihren Arbeitsablauf, indem Sie PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET in HTML konvertieren. Dieser Leitfaden bietet detaillierte Anleitungen, robuste Codebeispiele und getestete Methoden, um einen zuverlässigen und effizienten Konvertierungsprozess zu gewährleisten, der für die Anzeige im Web optimiert ist.

Aspose.Slides bietet viele Optionen - meist aus der [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) Klasse - die den Konvertierungsprozess vom PowerPoint-(oder OpenDocument-)Format zu HTML definieren:

* Eine gesamte PowerPoint-Präsentation in HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint-Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint-Präsentation in responsives HTML konvertieren.
* Eine PowerPoint-Präsentation in HTML mit eingeschlossenen oder ausgeschlossenen Sprecher-Notizen konvertieren.
* Eine PowerPoint-Präsentation in HTML mit eingeschlossenen oder ausgeschlossenen Kommentaren konvertieren.
* Eine PowerPoint-Präsentation in HTML mit originalen oder eingebetteten Schriftarten konvertieren.
* Eine PowerPoint-Präsentation in HTML unter Verwendung des neuen CSS-Stils konvertieren.

## **Präsentation in HTML konvertieren**

Mit Aspose.Slides können Sie eine gesamte PowerPoint‑ oder OpenDocument‑Präsentation wie folgt in HTML konvertieren:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Verwenden Sie die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) Methode, um das Objekt als HTML‑Datei zu speichern.

Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in C# in HTML konvertieren:
```c#
// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (z. B. PPT, PPTX, ODP usw.) darstellt.
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // Speichern Sie die Präsentation als HTML.
    presentation.Save("output.html", SaveFormat.Html);
}
```


## **Präsentation in responsives HTML konvertieren**

Aspose.Slides stellt die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller) bereit, mit der Sie responsive HTML‑Dateien erzeugen können. Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation in C# in responsives HTML konvertieren:
```c#
 // Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
 using (Presentation presentation = new Presentation("presentation.pptx"))
 {
     ResponsiveHtmlController controller = new ResponsiveHtmlController();

     HtmlOptions htmlOptions = new HtmlOptions 
     { 
         HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller) 
     };

     // Speichern Sie die Präsentation als HTML.
     presentation.Save("responsive.html", SaveFormat.Html, htmlOptions);
 }
```


## **Präsentation in HTML mit Sprecher-Notizen konvertieren**

Beim Konvertieren einer PowerPoint‑ oder OpenDocument‑Präsentation in HTML mit Sprecher-Notizen ist es wichtig, die gesamte Essenz des Originaldokuments zu erfassen. Dieser Prozess stellt sicher, dass nicht nur die visuellen Elemente der Folien exakt wiedergegeben werden, sondern auch die begleitenden Sprecher-Notizen erhalten bleiben, wodurch der Inhalt mit zusätzlichem Kontext und Einblicken angereichert wird.

Angenommen, wir haben eine PowerPoint‑Präsentation mit der folgenden Folie:

![Eine Präsentationsfolie mit Sprecher-Notizen](slide_with_notes.png)

Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation in C# in HTML mit Sprecher-Notizen konvertieren:
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // Optionen für Sprecher-Notizen festlegen.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Optionen für das Ausgabedokument HTML festlegen.
    HtmlOptions htmlOptions = new HtmlOptions
    {
        SlidesLayoutOptions = notesOptions
    };

    // Präsentation als HTML mit Sprecher-Notizen speichern.
    presentation.Save("slide_with_notes.html", SaveFormat.Html, htmlOptions);
}
```


Das Ergebnis:

![Ein HTML-Dokument mit der Folie und den Sprecher-Notizen](HTML_with_notes.png)

## **Präsentation in HTML mit Original-Schriftarten konvertieren**

Aspose.Slides stellt die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) zur Verfügung, die es ermöglicht, beim Konvertieren einer Präsentation in HTML alle Schriftarten einzubetten.

Um das Einbetten bestimmter Schriftarten zu verhindern, können Sie einem parametrisierten Konstruktor der Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) ein Array von Schriftartnamen übergeben. Beliebte Schriftarten wie Calibri oder Arial müssen nicht eingebettet werden, da die meisten Systeme diese bereits enthalten. Das Einbetten würde die Größe des resultierenden HTML-Dokuments unnötig erhöhen.

Die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) unterstützt Vererbung und stellt die Methode [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) bereit, die überschrieben werden soll.
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    // Standard-Schriftarten der Präsentation ausschließen.
    string[] excludeFonts = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(excludeFonts);

    HtmlOptions htmlOptions = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(fontController)
    };

    presentation.Save("embedded_fonts.html", SaveFormat.Html, htmlOptions);
}
```


## **Präsentation in HTML mit Bildern hoher Qualität konvertieren**

Standardmäßig erzeugt Aspose.Slides beim Konvertieren einer PowerPoint‑Präsentation in HTML eine kleine HTML‑Datei mit Bildern in 72 DPI und entfernt beschnittene Bereiche. Um HTML‑Dateien mit höherwertigen Bildern zu erhalten, müssen Sie die Eigenschaft `PicturesCompression` (aus der Klasse `HtmlOptions`) auf 96 (d.h. `PicturesCompression.Dpi96`) oder einen höheren Wert setzen, wie in [dieser Referenz](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression) beschrieben.

Dieser C#‑Code demonstriert, wie Sie eine PowerPoint‑Präsentation in HTML konvertieren und dabei hochqualitative Bilder mit 150 DPI (d.h. `PicturesCompression.Dpi150`) erhalten:
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


Dieser C#‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in HTML konvertieren, ohne beschnittene Bereiche zu entfernen:
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


## **Folie einer Präsentation in HTML konvertieren**

Um eine bestimmte Folie einer PowerPoint‑Präsentation in HTML zu konvertieren, müssen Sie dieselbe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse (die für die Konvertierung ganzer Präsentationen in HTML verwendet wird) instanziieren und anschließend die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) Methode nutzen, um die Datei als HTML zu speichern. Die Klasse [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) kann verwendet werden, um zusätzliche Konvertierungsoptionen anzugeben.

Dieser C#‑Code demonstriert, wie Sie eine Folie mit Sprecher-Notizen einer PowerPoint‑Präsentation in HTML konvertieren:
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

            // Speichern Sie die Folie in einer HTML-Datei.
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


## **CSS und Bilder beim Export nach HTML speichern**

Mit neuen CSS-Stildateien können Sie das Erscheinungsbild der aus dem PowerPoint-zu-HTML-Konvertierungsprozess erzeugten HTML-Datei problemlos ändern.

Der C#-Code in diesem Beispiel demonstriert, wie Sie überschreibbare Methoden verwenden, um ein benutzerdefiniertes HTML-Dokument zu erstellen, das einen Link zu einer CSS-Datei enthält:
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
    // Benutzerdefinierte Header-Vorlage.
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


## **Alle Schriftarten verlinken beim Konvertieren einer Präsentation in HTML**

Wenn Sie Schriftarten nicht einbetten möchten (um die Größe des resultierenden HTML nicht zu erhöhen), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene `LinkAllFontsHtmlController`‑Version implementieren.

Dieser C#‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in HTML konvertieren, dabei alle Schriftarten verlinken und "Calibri" sowie "Arial" ausschließen (da diese bereits im System installiert sind):
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    // Standard‑Schriftarten der Präsentation ausschließen.
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    presentation.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```


Dieser C#‑Code zeigt, wie das `LinkAllFontsHtmlController` implementiert ist:
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
            string path = fontName + ".woff"; // Some path sanitaze may be needed.

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


## **Präsentation mit SVG-Bildern in responsives HTML konvertieren**

Dieser C#‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in responsives HTML konvertieren:
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


## **Mediendateien nach HTML exportieren**

Mit Aspose.Slides für .NET können Sie Mediendateien wie folgt exportieren:

1. Erzeugen Sie eine Instanz der [Presentation] Klasse.
1. Holen Sie sich eine Referenz auf die Folie.
1. Fügen Sie der Folie ein Video hinzu.
1. Schreiben Sie die Präsentation als HTML‑Datei.

Dieser C#‑Code zeigt, wie Sie ein Video zur Präsentation hinzufügen und anschließend als HTML speichern:
```c#
// Neue Präsentation erstellen.
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

    // HTML-Optionen festlegen.
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    // Präsentation als HTML-Datei speichern.
    presentation.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```


{{% alert color="primary" %}} 

Aspose hat kostenlose [Präsentation nach HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) Konverter entwickelt: [PPT nach HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX nach HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP nach HTML](https://products.aspose.app/slides/conversion/odp-to-html), usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Schauen Sie sich weitere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) an.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Neben den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides zudem diese Konvertierungsoperationen im Zusammenhang mit dem HTML-Format:

* [HTML zu Bild](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

**Wie ist die Leistung von Aspose.Slides bei der Konvertierung mehrerer Präsentationen nach HTML?**

Die Leistung hängt von Größe und Komplexität der Präsentationen ab. Aspose.Slides ist für Batch-Operationen hoch effizient und skalierbar. Um bei der Konvertierung vieler Präsentationen optimale Leistung zu erzielen, wird empfohlen, nach Möglichkeit Multithreading oder Parallelverarbeitung zu nutzen.

**Unterstützt Aspose.Slides das Exportieren von Hyperlinks nach HTML?**

Ja, Aspose.Slides unterstützt das Exportieren eingebetteter Hyperlinks nach HTML vollständig. Beim Konvertieren von Präsentationen in das HTML-Format werden Hyperlinks automatisch erhalten und bleiben anklickbar.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren von Präsentationen nach HTML?**

Es gibt keine Begrenzung der Folienzahl bei der Verwendung von Aspose.Slides. Sie können Präsentationen beliebiger Größe konvertieren. Bei sehr großen Präsentationen kann die Leistung jedoch von den verfügbaren Ressourcen Ihres Servers oder Systems abhängen.