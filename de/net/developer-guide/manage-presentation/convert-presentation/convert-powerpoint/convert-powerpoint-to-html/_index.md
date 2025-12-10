---
title: PowerPoint-Präsentationen in HTML konvertieren in .NET
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/net/convert-powerpoint-to-html/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu HTML
- Präsentation zu HTML
- Folie zu HTML
- PPT zu HTML
- PPTX zu HTML
- PowerPoint als HTML speichern
- Präsentation als HTML speichern
- Folie als HTML speichern
- PPT als HTML speichern
- PPTX als HTML speichern
- PPT nach HTML exportieren
- PPTX nach HTML exportieren
- .NET
- C#
- Aspose.Slides
description: "PowerPoint-Präsentationen in responsives HTML in .NET konvertieren. Layout, Links und Bilder mit dem Aspose.Slides-Konvertierungsleitfaden für schnelle, fehlerfreie Ergebnisse erhalten."
---

## **Übersicht**

Optimieren Sie Ihren Arbeitsablauf, indem Sie PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET in HTML konvertieren. Dieser Leitfaden bietet detaillierte Anweisungen, robuste Codebeispiele und getestete Methoden, um einen zuverlässigen und effizienten Konvertierungsprozess zu gewährleisten, der für die Anzeige im Web optimiert ist.

Aspose.Slides stellt viele Optionen – meist aus der [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions)-Klasse – zur Verfügung, die den Konvertierungsprozess von PowerPoint (oder OpenDocument) nach HTML definieren:

* Eine gesamte PowerPoint-Präsentation in HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint-Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint-Präsentation in responsives HTML konvertieren.
* Eine PowerPoint-Präsentation in HTML mit eingeschlossenen oder ausgeschlossenen Referenten-Notizen konvertieren.
* Eine PowerPoint-Präsentation in HTML mit eingeschlossenen oder ausgeschlossenen Kommentaren konvertieren.
* Eine PowerPoint-Präsentation in HTML mit Original- oder eingebetteten Schriften konvertieren.
* Eine PowerPoint-Präsentation in HTML mithilfe des neuen CSS‑Stils konvertieren.

## **Präsentation in HTML konvertieren**

Mit Aspose.Slides können Sie eine gesamte PowerPoint‑ oder OpenDocument‑Präsentation wie folgt in HTML konvertieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Verwenden Sie die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)-Methode, um das Objekt als HTML‑Datei zu speichern.

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

Aspose.Slides stellt die [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller)-Klasse bereit, mit der Sie responsive HTML‑Dateien erzeugen können. Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation in C# in responsives HTML konvertieren:
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


## **Präsentation in HTML mit Referenten‑Notizen konvertieren**

Beim Konvertieren einer PowerPoint‑ oder OpenDocument‑Präsentation in HTML mit Referenten‑Notizen ist es wichtig, das vollständige Wesen des Originaldokuments zu erfassen. Dieser Vorgang stellt sicher, dass nicht nur die visuellen Elemente der Folien exakt wiedergegeben werden, sondern auch die begleitenden Referenten‑Notizen erhalten bleiben und den Inhalt mit zusätzlichem Kontext und Einsichten anreichern.

Nehmen wir an, wir haben eine PowerPoint‑Präsentation mit der folgenden Folie:

![A presentation slide with speaker notes](slide_with_notes.png)

Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation in C# in HTML mit Referenten‑Notizen konvertieren:
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // Optionen für Referenten-Notizen festlegen.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Optionen für das Ausgabedokument HTML festlegen.
    HtmlOptions htmlOptions = new HtmlOptions
    {
        SlidesLayoutOptions = notesOptions
    };

    // Präsentation als HTML mit Referenten-Notizen speichern.
    presentation.Save("slide_with_notes.html", SaveFormat.Html, htmlOptions);
}
```


Das Ergebnis:

![An HTML document with the slide and speaker notes](HTML_with_notes.png)

## **Präsentation in HTML mit Originalschriften konvertieren**

Aspose.Slides bietet die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller)-Klasse, mit der Sie beim Konvertieren einer Präsentation in HTML alle Schriften einbetten können.

Um bestimmte Schriften davon auszuschließen, können Sie ein Array von Schriftartnamen an den parametrisierten Konstruktor der [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller)-Klasse übergeben. Häufig genutzte Schriften wie Calibri oder Arial müssen nicht eingebettet werden, da die meisten Systeme diese bereits enthalten. Das Einbetten würde die Größe der resultierenden HTML‑Datei unnötig erhöhen.

Die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller)-Klasse unterstützt Vererbung und stellt die [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont)-Methode bereit, die überschrieben werden kann.
```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    // Standard-Präsentationsschriften ausschließen.
    string[] excludeFonts = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(excludeFonts);

    HtmlOptions htmlOptions = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(fontController)
    };

    presentation.Save("embedded_fonts.html", SaveFormat.Html, htmlOptions);
}
```


## **Präsentation in HTML mit hochqualitativen Bildern konvertieren**

Standardmäßig erzeugt Aspose.Slides beim Konvertieren einer PowerPoint‑Präsentation in HTML eine kleine HTML‑Datei mit Bildern von 72 DPI und entfernt beschnittene Bereiche. Um HTML‑Dateien mit Bildern höherer Qualität zu erhalten, müssen Sie die Eigenschaft `PicturesCompression` (aus der `HtmlOptions`‑Klasse) auf 96 (`PicturesCompression.Dpi96`) oder einen höheren Wert setzen, wie in [diesem Referenzdokument](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression) beschrieben.

Dieser C#‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in HTML konvertieren und dabei hochqualitative Bilder mit 150 DPI (`PicturesCompression.Dpi150`) erhalten:
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


Dieser C#‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in HTML konvertieren, ohne beschnittene Bereiche zu löschen:
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


## **Präsentationsfolie in HTML konvertieren**

Um eine bestimmte Folie einer PowerPoint‑Präsentation in HTML zu konvertieren, müssen Sie dieselbe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse instanziieren (die auch für die Konvertierung ganzer Präsentationen verwendet wird) und anschließend die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)-Methode zum Speichern als HTML aufrufen. Mit der [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions)-Klasse können zusätzliche Konvertierungsoptionen angegeben werden.

Dieser C#‑Code demonstriert, wie Sie eine Folie mit Referenten‑Notizen in einer PowerPoint‑Präsentation in HTML konvertieren:
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

Durch die Verwendung neuer CSS‑Stildateien können Sie das Erscheinungsbild der aus dem PowerPoint‑zu‑HTML‑Konvertierungsprozess erzeugten HTML‑Datei leicht ändern.

Der C#‑Code in diesem Beispiel zeigt, wie Sie überschreibbare Methoden nutzen, um ein benutzerdefiniertes HTML‑Dokument zu erstellen, das einen Verweis auf eine CSS‑Datei enthält:
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


## **Alle Schriften verlinken beim Konvertieren einer Präsentation in HTML**

Wenn Sie Schriften nicht einbetten möchten (um die Größe der resultierenden HTML‑Datei nicht zu erhöhen), können Sie alle Schriften verlinken, indem Sie Ihre eigene `LinkAllFontsHtmlController`‑Version implementieren.

Dieser C#‑Code zeigt, wie Sie eine PowerPoint‑Präsentation in HTML konvertieren, dabei alle Schriften verlinken und „Calibri“ sowie „Arial“ ausschließen (da sie bereits im System installiert sind):
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    // Standard-Präsentationsschriften ausschließen.
    string[] fontNameExcludeList = { "Calibri", "Arial" };

    LinkAllFontsHtmlController linkcont = new LinkAllFontsHtmlController(fontNameExcludeList, @"C:\Windows\Fonts\");;

    HtmlOptions htmlOptionsEmbed = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(linkcont)
    };

    presentation.Save("pres.html", SaveFormat.Html, htmlOptionsEmbed);
}
```


Dieser C#‑Code zeigt, wie der `LinkAllFontsHtmlController` implementiert wird:
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
            string path = fontName + ".woff"; // Einige Pfadbereinigungen könnten erforderlich sein.

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


## **Präsentation mit SVG‑Bildern in responsives HTML konvertieren**

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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasse.
1. Holen Sie eine Referenz zur Folie.
1. Fügen Sie ein Video zur Folie hinzu.
1. Schreiben Sie die Präsentation als HTML‑Datei.

Dieser C#‑Code zeigt, wie Sie ein Video zur Präsentation hinzufügen und anschließend als HTML speichern: 
```c#
// Eine neue Präsentation erstellen.
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

    // Die Präsentation als HTML-Datei speichern.
    presentation.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);
}
```


{{% alert color="primary" %}} 

Aspose hat kostenlose [Präsentation‑zu‑HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)-Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Weitere kostenlose Konverter von Aspose finden Sie unter [free converters from Aspose](https://products.aspose.app/slides/conversion).

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Neben den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides folgende Konvertierungsoperationen im HTML‑Format: 

* [HTML zu Bild](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

**Wie ist die Leistung von Aspose.Slides beim Konvertieren mehrerer Präsentationen in HTML?**

Die Leistung hängt von Größe und Komplexität der Präsentationen ab. Aspose.Slides ist sehr effizient und skalierbar für Batch‑Operationen. Für optimale Leistung beim Konvertieren vieler Präsentationen wird empfohlen, nach Möglichkeit Multithreading oder Parallel Processing zu nutzen.

**Unterstützt Aspose.Slides das Exportieren von Hyperlinks nach HTML?**

Ja, Aspose.Slides unterstützt das Exportieren eingebetteter Hyperlinks nach HTML vollständig. Beim Konvertieren von Präsentationen nach HTML bleiben Hyperlinks automatisch erhalten und anklickbar.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren von Präsentationen in HTML?**

Es gibt keine Begrenzung der Folienzahl bei der Verwendung von Aspose.Slides. Sie können Präsentationen jeder Größe konvertieren. Bei Präsentationen mit einer sehr großen Folienanzahl kann die Leistung jedoch von den verfügbaren Ressourcen Ihres Servers oder Systems abhängen.