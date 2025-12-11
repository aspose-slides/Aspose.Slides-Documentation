---
title: PowerPoint-Präsentationen auf Android in HTML konvertieren
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/androidjava/convert-powerpoint-to-html/
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint-Präsentationen in responsives HTML in Java konvertieren. Layout, Links und Bilder mit Aspose.Slides für Android erhalten – Leitfaden für schnelle, fehlerfreie Ergebnisse."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen mit Java in das HTML‑Format konvertiert. Er behandelt die folgenden Themen.

- PowerPoint in HTML mit Java konvertieren
- PPT in HTML mit Java konvertieren
- PPTX in HTML mit Java konvertieren
- ODP in HTML mit Java konvertieren
- PowerPoint‑Folie in HTML mit Java konvertieren

## **PowerPoint zu HTML unter Android**

Für Beispielcode in Java zum Konvertieren von PowerPoint in HTML siehe den Abschnitt unten, d.h.[PowerPoint in HTML konvertieren](#convert-powerpoint-to-html). Der Code kann verschiedene Formate wie PPT, PPTX und ODP im Presentation‑Objekt laden und sie im HTML‑Format speichern.

## **Über die PowerPoint zu HTML Konvertierung**
Mit [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/) können Anwendungen und Entwickler eine PowerPoint‑Präsentation in HTML konvertieren: **PPTX zu HTML** oder **PPT zu HTML**.

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der Klasse [**HtmlOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions)), die den PowerPoint‑zu‑HTML‑Konvertierungsprozess definieren:

* Eine komplette PowerPoint‑Präsentation in HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint‑Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint‑Präsentation in responsives HTML konvertieren.
* Eine PowerPoint‑Präsentation in HTML mit oder ohne Lautsprechernotizen konvertieren.
* Eine PowerPoint‑Präsentation in HTML mit oder ohne Kommentare konvertieren.
* Eine PowerPoint‑Präsentation in HTML mit Original‑ oder eingebetteten Schriften konvertieren.
* Eine PowerPoint‑Präsentation in HTML konvertieren, wobei der neue CSS‑Stil verwendet wird.

{{% alert color="primary" %}} 

Mit seiner eigenen API hat Aspose kostenlose [Präsentation zu HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw.

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vielleicht möchten Sie weitere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) ansehen.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Zusätzlich zu den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides auch diese Konvertierungsoperationen im Zusammenhang mit dem HTML‑Format:

* [HTML zu Bild](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}

## **PowerPoint zu HTML konvertieren**
Mit Aspose.Slides können Sie eine komplette PowerPoint‑Präsentation auf folgende Weise in HTML konvertieren:

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Verwenden Sie die [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode, um das Objekt als HTML‑Datei zu speichern.

Dieser Code zeigt, wie man ein PowerPoint in HTML in Java konvertiert:
```java
// Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei repräsentiert
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    HtmlOptions htmlOpt = new HtmlOptions();
	
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));

    // Speichern der Präsentation als HTML
    pres.save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint zu Responsive HTML konvertieren**
Aspose.Slides stellt die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ResponsiveHtmlController) bereit, mit der Sie responsive HTML‑Dateien erzeugen können. Dieser Code zeigt, wie man eine PowerPoint‑Präsentation in responsives HTML in Java konvertiert:
```java
// Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

    // Speichern der Präsentation als HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint zu HTML mit Notizen konvertieren**
Dieser Code zeigt, wie man ein PowerPoint in HTML mit Notizen in Java konvertiert:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    HtmlOptions opt = new HtmlOptions();
	
    INotesCommentsLayoutingOptions options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    // Notizseiten speichern
    pres.save("Output.html", SaveFormat.Html, opt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint zu HTML mit Originalschriften konvertieren**
Aspose.Slides stellt die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) bereit, mit der Sie beim Konvertieren einer Präsentation zu HTML alle Schriften einbetten können.

Um das Einbetten bestimmter Schriften zu verhindern, können Sie dem parametrisierten Konstruktor der Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) ein Array von Schriftartnamen übergeben. Beliebte Schriften wie Calibri oder Arial müssen in einer Präsentation nicht eingebettet werden, da die meisten Systeme diese Schriften bereits enthalten. Werden diese Schriften eingebettet, wird das resultierende HTML‑Dokument unnötig groß.

Die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) unterstützt Vererbung und stellt die Methode [WriteFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) bereit, die überschrieben werden soll.
```java
Presentation pres = new Presentation("input.pptx");
try {
    // Standard-Schriften der Präsentation ausschließen
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter(embedFontsController));

    pres.save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint zu HTML mit hochwertigen Bildern konvertieren**
Standardmäßig erzeugt Aspose.Slides beim Konvertieren von PowerPoint zu HTML ein kleines HTML mit Bildern mit 72 DPI und entfernten Beschnittbereichen. Um HTML‑Dateien mit höherwertigen Bildern zu erhalten, müssen Sie die Eigenschaft `PicturesCompression` (aus der Klasse `HtmlOptions`) auf 96 (d. h. `PicturesCompression.Dpi96`) oder höhere [Werte](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PicturesCompression) setzen.

Dieser Java‑Code zeigt, wie man eine PowerPoint‑Präsentation zu HTML konvertiert und dabei hochwertige Bilder mit 150 DPI (d. h. `PicturesCompression.Dpi150`) erhält:
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


Dieser Java‑Code zeigt, wie man HTML mit Bildern in voller Qualität ausgibt:
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


## **Eine Folie zu HTML konvertieren**
Um eine bestimmte Folie eines PowerPoint in HTML zu konvertieren, müssen Sie die gleiche Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) instanziieren (die zum Konvertieren ganzer Präsentationen zu HTML verwendet wird) und anschließend die Methode [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) nutzen, um die Datei als HTML zu speichern. Die Klasse [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) kann verwendet werden, um zusätzliche Konvertierungsoptionen anzugeben:

Dieser Java‑Code zeigt, wie man eine Folie in einer PowerPoint‑Präsentation zu HTML konvertiert:
```java
Presentation pres = new Presentation("Individual-Slide.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(new CustomFormattingController()));

    // Datei speichern
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


## **CSS und Bilder beim Exportieren nach HTML speichern**
Mit neuen CSS‑Stildateien können Sie das Erscheinungsbild der aus dem PowerPoint‑zu‑HTML‑Konvertierungsprozess entstehenden HTML‑Datei einfach ändern.

Der Java‑Code in diesem Beispiel zeigt, wie Sie überschreibbare Methoden verwenden, um ein benutzerdefiniertes HTML‑Dokument mit einem Link zu einer CSS‑Datei zu erstellen:
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

    // Benutzerdefinierte Header-Vorlage
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


## **Alle Schriften beim Konvertieren einer Präsentation zu HTML verlinken**
Wenn Sie Schriften nicht einbetten möchten (um die Größe des resultierenden HTML nicht zu vergrößern), können Sie alle Schriften verlinken, indem Sie Ihre eigene `LinkAllFontsHtmlController`‑Version implementieren.

Dieser Java‑Code zeigt, wie man ein PowerPoint zu HTML konvertiert, während alle Schriften verlinkt und „Calibri“ sowie „Arial“ ausgeschlossen werden (da sie bereits im System vorhanden sind):
```java
Presentation pres = new Presentation("pres.pptx");
try
{
    //Standard-Schriften der Präsentation ausschließen
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


Dieser Java‑Code zeigt, wie `LinkAllFontsHtmlController` implementiert wird:
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
            String path = fontName + ".woff"; // eventuell muss der Pfad bereinigt werden
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


## **PowerPoint zu Responsive HTML konvertieren**
Dieser Java‑Code zeigt, wie man eine PowerPoint‑Präsentation in responsives HTML konvertiert:
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


## **Mediendateien nach HTML exportieren**
Mit Aspose.Slides for Android via Java können Sie Mediendateien wie folgt exportieren:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Holen Sie eine Referenz auf die Folie.
3. Fügen Sie der Folie ein Video hinzu.
4. Schreiben Sie die Präsentation als HTML‑Datei.

Dieser Java‑Code zeigt, wie man ein Video zur Präsentation hinzufügt und sie dann als HTML speichert:
```java
// Präsentation laden
Presentation pres = new Presentation();
try {
    String path = "./out/";
    final String fileName = "ExportMediaFiles_out.html";
    final String baseUri = "http://www.example.com/";

    byte[] videoData = Files.readAllBytes(Paths.get("my_video.avi"));
    IVideo video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // HTML-Optionen setzen
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(SlideImageFormat.svg(svgOptions));

    // Datei speichern
    pres.save(fileName, SaveFormat.Html, htmlOptions);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wie ist die Leistung von Aspose.Slides beim Konvertieren mehrerer Präsentationen zu HTML?**

Die Leistung hängt von Größe und Komplexität der Präsentationen ab. Aspose.Slides ist hoch effizient und skalierbar für Batch‑Operationen. Für optimale Leistung beim Konvertieren vieler Präsentationen wird empfohlen, nach Möglichkeit Multithreading oder parallele Verarbeitung zu nutzen.

**Unterstützt Aspose.Slides das Exportieren von Hyperlinks nach HTML?**

Ja, Aspose.Slides unterstützt das Exportieren eingebetteter Hyperlinks nach HTML vollständig. Beim Konvertieren von Präsentationen ins HTML‑Format werden Hyperlinks automatisch erhalten und bleiben anklickbar.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren von Präsentationen zu HTML?**

Bei Verwendung von Aspose.Slides gibt es keine Begrenzung der Folienzahl. Sie können Präsentationen beliebiger Größe konvertieren. Bei Präsentationen mit sehr vielen Folien kann die Leistung jedoch von den verfügbaren Ressourcen Ihres Servers oder Systems abhängen.