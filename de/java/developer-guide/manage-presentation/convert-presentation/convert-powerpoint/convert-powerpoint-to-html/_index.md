---
title: PowerPoint-Präsentationen in HTML in Java konvertieren
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "PowerPoint-Präsentationen in Java in responsives HTML konvertieren. Layout, Links und Bilder mit dem Aspose.Slides-Konvertierungsleitfaden für schnelle, fehlerfreie Ergebnisse erhalten."
---

## **Überblick**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen mit Java in das HTML‑Format konvertiert. Er behandelt die folgenden Themen.

- PowerPoint in HTML mit Java konvertieren
- PPT in HTML mit Java konvertieren
- PPTX in HTML mit Java konvertieren
- ODP in HTML mit Java konvertieren
- PowerPoint‑Folie in HTML mit Java konvertieren

## **Java PowerPoint zu HTML**

Für Beispielcode in Java zum Konvertieren von PowerPoint zu HTML siehe den Abschnitt unten, nämlich [Convert PowerPoint to HTML](#convert-powerpoint-to-html). Der Code kann mehrere Formate wie PPT, PPTX und ODP im Presentation‑Objekt laden und in das HTML‑Format speichern.

## **Über die PowerPoint‑zu‑HTML‑Konvertierung**
Mit [**Aspose.Slides for Java**](https://products.aspose.com/slides/java/) können Anwendungen und Entwickler eine PowerPoint‑Präsentation in HTML konvertieren: **PPTX zu HTML** oder **PPT zu HTML**. 

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der Klasse [**HtmlOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/HtmlOptions) ), die den PowerPoint‑zu‑HTML‑Konvertierungsprozess definieren:

* Eine komplette PowerPoint‑Präsentation in HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint‑Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint‑Präsentation in responsives HTML konvertieren.
* Eine PowerPoint‑Präsentation in HTML mit oder ohne Sprecher‑notizen konvertieren.
* Eine PowerPoint‑Präsentation in HTML mit oder ohne Kommentare konvertieren.
* Eine PowerPoint‑Präsentation in HTML mit Original‑ oder eingebetteten Schriftarten konvertieren.
* Eine PowerPoint‑Präsentation in HTML konvertieren und dabei den neuen CSS‑Stil verwenden.

{{% alert color="primary" %}} 

Mit seiner eigenen API hat Aspose kostenlose [Präsentation‑zu‑HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)‑Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vielleicht möchten Sie weitere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) ansehen.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Zusätzlich zu den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides auch die folgenden Konvertierungsoperationen im HTML‑Format: 

* [HTML zu Bild](https://products.aspose.com/slides/java/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/java/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/java/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/java/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPoint zu HTML konvertieren**
Mit Aspose.Slides können Sie eine komplette PowerPoint‑Präsentation wie folgt in HTML konvertieren:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Verwenden Sie die Methode [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) , um das Objekt als HTML‑Datei zu speichern.

Dieser Code zeigt, wie Sie ein PowerPoint in Java nach HTML konvertieren:
```java
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    HtmlOptions htmlOpt = new HtmlOptions();
	
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOpt.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));

    // Präsentation in HTML speichern
    pres.save("ConvertWholePresentationToHTML_out.html", SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) pres.dispose();
}
```



## **PowerPoint zu responsive HTML konvertieren**
Aspose.Slides stellt die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/ResponsiveHtmlController) zur Verfügung, mit der Sie responsive HTML‑Dateien erzeugen können. Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in Java zu responsive HTML konvertieren:
```java
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation("Convert_HTML.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));

    // Präsentation in HTML speichern
    pres.save("ConvertPresentationToResponsiveHTML_out.html", SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint zu HTML mit Notizen konvertieren**
Dieser Code zeigt, wie Sie ein PowerPoint in Java mit Notizen nach HTML konvertieren:
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    HtmlOptions opt = new HtmlOptions();
	
    INotesCommentsLayoutingOptions options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    // Notizenseiten speichern
    pres.save("Output.html", SaveFormat.Html, opt);
} finally {
    if (pres != null) pres.dispose();
}
```


## **PowerPoint zu HTML mit Original‑Schriftarten konvertieren**

Aspose.Slides stellt die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController) zur Verfügung, mit der Sie beim Konvertieren einer Präsentation nach HTML alle Schriftarten einbetten können.

Um das Einbetten bestimmter Schriftarten zu verhindern, können Sie dem parametrisierten Konstruktor der Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController) ein Array von Schriftartnamen übergeben. Beliebte Schriftarten wie Calibri oder Arial müssen bei Verwendung in einer Präsentation nicht eingebettet werden, da die meisten Systeme diese bereits enthalten. Wenn diese Schriftarten eingebettet werden, wird das resultierende HTML‑Dokument unnötig groß.

Die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController) unterstützt Vererbung und stellt die Methode [WriteFont](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) bereit, die überschrieben werden soll. 
```java
Presentation pres = new Presentation("input.pptx");
try {
    // Standardschriftarten der Präsentation ausschließen
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

Standardmäßig erzeugt Aspose.Slides beim Konvertieren von PowerPoint zu HTML ein kompaktes HTML mit Bildern bei 72 DPI und entfernten beschnittenen Bereichen. Um HTML‑Dateien mit höherwertigen Bildern zu erhalten, müssen Sie die Eigenschaft `PicturesCompression` (aus der Klasse `HtmlOptions`) auf 96 (d. h. `PicturesCompression.Dpi96`) oder höhere [Werte](https://reference.aspose.com/slides/java/com.aspose.slides/PicturesCompression) setzen.

Dieser Java‑Code zeigt, wie Sie eine PowerPoint‑Präsentation nach HTML konvertieren und dabei hochwertige Bilder mit 150 DPI erhalten (d. h. `PicturesCompression.Dpi150`):
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


Dieser Java‑Code zeigt, wie Sie HTML mit Bildern in voller Qualität ausgeben:
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


## **Folie zu HTML konvertieren**
Um eine bestimmte Folie einer PowerPoint‑Präsentation in HTML zu konvertieren, müssen Sie dieselbe Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) (die zum Konvertieren ganzer Präsentationen nach HTML verwendet wird) instanziieren und anschließend die Methode [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) verwenden, um die Datei als HTML zu speichern. Die Klasse [HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/HtmlOptions) kann verwendet werden, um zusätzliche Konvertierungsoptionen anzugeben:

Dieser Java‑Code zeigt, wie Sie eine Folie einer PowerPoint‑Präsentation nach HTML konvertieren:
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
Mit neuen CSS‑Stildateien können Sie das Aussehen der aus dem PowerPoint‑zu‑HTML‑Konvertierungsprozess resultierenden HTML‑Datei leicht ändern. 

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


## **Alle Schriftarten verlinken beim Konvertieren einer Präsentation zu HTML**

Wenn Sie Schriftarten nicht einbetten möchten (um die Größe des resultierenden HTML zu vermeiden), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene Version des `LinkAllFontsHtmlController` implementieren. 

Dieser Java‑Code zeigt, wie Sie ein PowerPoint in HTML konvertieren, dabei alle Schriftarten verlinken und „Calibri“ und „Arial“ ausschließen (da sie bereits im System vorhanden sind):
```java
Presentation pres = new Presentation("pres.pptx");
try
{
    // Standard-Schriftarten der Präsentation ausschließen
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
            String path = fontName + ".woff"; // möglicherweise muss der Pfad bereinigt werden
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


## **PowerPoint zu responsive HTML konvertieren**
Dieser Java‑Code zeigt, wie Sie eine PowerPoint‑Präsentation zu responsive HTML konvertieren:
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
Mit Aspose.Slides für Java können Sie Mediendateien wie folgt exportieren:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Holen Sie eine Referenz auf die Folie.
3. Fügen Sie der Folie ein Video hinzu.
4. Schreiben Sie die Präsentation als HTML‑Datei.

Dieser Java‑Code zeigt, wie Sie ein Video zur Präsentation hinzufügen und sie anschließend als HTML speichern:
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

    // HTML-Optionen festlegen
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
