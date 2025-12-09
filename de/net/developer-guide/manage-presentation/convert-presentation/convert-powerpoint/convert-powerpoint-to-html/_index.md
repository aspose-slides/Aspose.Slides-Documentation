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

Verbessern Sie Ihren Arbeitsablauf, indem Sie PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für .NET in HTML konvertieren. Dieser Leitfaden bietet detaillierte Anweisungen, robuste Code‑Beispiele und getestete Methoden, um einen zuverlässigen und effizienten Konvertierungsprozess zu gewährleisten, der für die Webanzeige optimiert ist.

Aspose.Slides stellt viele Optionen bereit – hauptsächlich aus der Klasse [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) – die den Konvertierungsprozess vom PowerPoint‑ (oder OpenDocument‑)Format nach HTML definieren:

* Konvertieren Sie eine komplette PowerPoint‑Präsentation in HTML.
* Konvertieren Sie eine bestimmte Folie einer PowerPoint‑Präsentation in HTML.
* Konvertieren Sie Präsentationsmedien (Bilder, Videos usw.) in HTML.
* Konvertieren Sie eine PowerPoint‑Präsentation in responsives HTML.
* Konvertieren Sie eine PowerPoint‑Präsentation in HTML mit einbezogenen oder ausgeschlossenen Sprecher‑Notizen.
* Konvertieren Sie eine PowerPoint‑Präsentation in HTML mit einbezogenen oder ausgeschlossenen Kommentaren.
* Konvertieren Sie eine PowerPoint‑Präsentation in HTML mit originalen oder eingebetteten Schriftarten.
* Konvertieren Sie eine PowerPoint‑Präsentation in HTML unter Verwendung des neuen CSS‑Stils.

## **Eine Präsentation in HTML konvertieren**

Mit Aspose.Slides können Sie eine komplette PowerPoint‑ oder OpenDocument‑Präsentation wie folgt in HTML konvertieren:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save), um das Objekt als HTML‑Datei zu speichern.

```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (z. B. PPT, PPTX, ODP usw.) darstellt.
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // Speichern Sie die Präsentation als HTML.
    presentation.Save("output.html", SaveFormat.Html);
}
```


## **Eine Präsentation in responsives HTML konvertieren**

Aspose.Slides bietet die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller), die es ermöglicht, responsive HTML‑Dateien zu erzeugen. Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in responsives HTML in C# konvertieren:

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


## **Eine Präsentation in HTML mit Sprecher‑Notizen konvertieren**

Beim Konvertieren einer PowerPoint‑ oder OpenDocument‑Präsentation nach HTML mit Sprecher‑Notizen ist es wichtig, die vollständige Essenz des Originaldokuments zu erfassen. Dieser Prozess stellt sicher, dass nicht nur die visuellen Elemente der Folien exakt wiedergegeben werden, sondern auch die begleitenden Sprecher‑Notizen erhalten bleiben, wodurch der Inhalt mit zusätzlichem Kontext und Erkenntnissen angereichert wird.

Angenommen, wir haben eine PowerPoint‑Präsentation mit der folgenden Folie:

![Eine Präsentationsfolie mit Sprecher-Notizen](slide_with_notes.png)

Dieser Code demonstriert, wie Sie eine PowerPoint‑Präsentation in HTML mit Sprecher‑Notizen in C# konvertieren:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    // Optionen für Sprecher-Notizen festlegen.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Optionen für das Ausgabe‑HTML‑Dokument festlegen.
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

## **Eine Präsentation in HTML mit originalen Schriftarten konvertieren**

Aspose.Slides stellt die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) bereit, mit der Sie beim Konvertieren einer Präsentation nach HTML alle Schriftarten einbetten können.

Um zu verhindern, dass bestimmte Schriftarten eingebettet werden, können Sie einem parametrisierten Konstruktor der Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) ein Array von Schriftartnamen übergeben. Beliebte Schriftarten wie Calibri oder Arial müssen nicht eingebettet werden, da die meisten Systeme diese bereits enthalten. Das Einbetten würde die Größe des resultierenden HTML‑Dokuments unnötig vergrößern.

Die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller) unterstützt Vererbung und stellt die Methode [WriteFont](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/methods/writefont) bereit, die überschrieben werden kann.

```c#
using (Presentation presentation = new Presentation("input.pptx"))
{
    // Die Standardschriftarten der Präsentation ausschließen.
    string[] excludeFonts = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(excludeFonts);

    HtmlOptions htmlOptions = new HtmlOptions
    {
        HtmlFormatter = HtmlFormatter.CreateCustomFormatter(fontController)
    };

    presentation.Save("embedded_fonts.html", SaveFormat.Html, htmlOptions);
}
```


## **Eine Präsentation in HTML mit hochqualitativen Bildern konvertieren**

Standardmäßig erzeugt Aspose.Slides beim Konvertieren einer PowerPoint‑Präsentation nach HTML eine kleine HTML‑Datei mit Bildern bei 72 DPI und entfernt beschnittene Bereiche. Um HTML‑Dateien mit höherwertigen Bildern zu erhalten, müssen Sie die Eigenschaft `PicturesCompression` (aus der Klasse `HtmlOptions`) auf 96 (d.h. `PicturesCompression.Dpi96`) oder einen höheren Wert setzen, wie in [dieser Referenz](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression) beschrieben.

Dieser C#‑Code demonstriert, wie Sie eine PowerPoint‑Präsentation in HTML konvertieren und dabei hochwertige Bilder mit 150 DPI (d.h. `PicturesCompression.Dpi150`) erhalten:

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


Dieser C#‑Code zeigt Ihnen, wie Sie eine PowerPoint‑Präsentation in HTML konvertieren, ohne beschnittene Bereiche zu entfernen:

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


## **Eine Präsentationsfolie in HTML konvertieren**

Um eine bestimmte Folie einer PowerPoint‑Präsentation in HTML zu konvertieren, müssen Sie dieselbe Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) (wie beim Konvertieren kompletter Präsentationen) instanziieren und anschließend die Methode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) verwenden, um die Datei als HTML zu speichern. Die Klasse [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions) kann verwendet werden, um zusätzliche Konvertierungsoptionen anzugeben.

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

            // Speichern Sie die Folie als HTML-Datei.
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

Mit neuen CSS‑Stildateien können Sie das Aussehen der aus dem PowerPoint‑zu‑HTML‑Konvertierungsprozess erzeugten HTML‑Datei leicht ändern.

Der C#‑Code in diesem Beispiel demonstriert, wie Sie überschreibbare Methoden verwenden, um ein benutzerdefiniertes HTML‑Dokument zu erstellen, das einen Link zu einer CSS‑Datei enthält:

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


## **Alle Schriftarten beim Konvertieren einer Präsentation nach HTML verlinken**

Wenn Sie Schriftarten nicht einbetten möchten (um die Größe des resultierenden HTML nicht zu erhöhen), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene Version von `LinkAllFontsHtmlController` implementieren.

Dieser C#‑Code zeigt Ihnen, wie Sie eine PowerPoint‑Präsentation in HTML konvertieren, während Sie alle Schriftarten verlinken und „Calibri“ sowie „Arial“ ausschließen (da sie bereits im System installiert sind):

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


Dieser C#‑Code zeigt, wie die `LinkAllFontsHtmlController`‑Klasse implementiert wird:

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
            string path = fontName + ".woff"; // Einige Pfadbereinigungen können erforderlich sein.

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


## **Eine Präsentation mit SVG‑Bildern in responsives HTML konvertieren**

Dieser C#‑Code zeigt Ihnen, wie Sie eine PowerPoint‑Präsentation in responsives HTML konvertieren:

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

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Holen Sie sich eine Referenz zur Folie.
1. Fügen Sie der Folie ein Video hinzu.
1. Schreiben Sie die Präsentation als HTML‑Datei.

```c#
// Erstelle eine neue Präsentation.
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

Aspose hat kostenlose [Präsentation nach HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)-Konverter entwickelt: [PPT nach HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX nach HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP nach HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Schauen Sie sich weitere kostenlose Konverter von Aspose an.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Neben den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides auch diese Konvertierungsoperationen, die das HTML‑Format betreffen: 

* [HTML zu Bild](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

**Wie ist die Leistung von Aspose.Slides beim Konvertieren mehrerer Präsentationen nach HTML?**

Die Leistung hängt von Größe und Komplexität der Präsentationen ab. Aspose.Slides ist hoch effizient und skalierbar für Batch‑Operationen. Für optimale Leistung bei der Konvertierung vieler Präsentationen empfiehlt sich, wenn möglich Multithreading oder Parallelverarbeitung zu nutzen.

**Unterstützt Aspose.Slides das Exportieren von Hyperlinks nach HTML?**

Ja, Aspose.Slides unterstützt das vollständige Exportieren eingebetteter Hyperlinks nach HTML. Beim Konvertieren von Präsentationen nach HTML bleiben Hyperlinks automatisch erhalten und bleiben anklickbar.

**Gibt es ein Limit für die Anzahl der Folien beim Konvertieren von Präsentationen nach HTML?**

Es gibt kein Limit für die Folienanzahl bei der Verwendung von Aspose.Slides. Sie können Präsentationen jeder Größe konvertieren. Bei sehr großen Präsentationen kann die Leistung jedoch von den verfügbaren Ressourcen Ihres Servers oder Systems abhängen.