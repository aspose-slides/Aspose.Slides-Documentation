---
title: PowerPoint in HTML konvertieren mit Java
linktitle: PowerPoint in HTML konvertieren
type: docs
weight: 30
url: /de/java/convert-powerpoint-to-html/
keywords: "Java PowerPoint zu HTML, PowerPoint-Präsentation konvertieren, PPTX, PPT, PPT in HTML, PPTX in HTML, PowerPoint in HTML, PowerPoint als HTML speichern, PPT als HTML speichern, PPTX als HTML speichern, Java, Aspose.Slides, HTML-Export"
description: "PowerPoint HTML in Java konvertieren: Speichern Sie PPTX oder PPT als HTML in Java. Speichern Sie Folien als HTML in Java"
---

## **Übersicht**

Dieser Artikel erklärt, wie man eine PowerPoint-Präsentation im HTML-Format mit Java konvertiert. Die folgenden Themen werden behandelt.

- PowerPoint in HTML in Java konvertieren
- PPT in HTML in Java konvertieren
- PPTX in HTML in Java konvertieren
- ODP in HTML in Java konvertieren
- PowerPoint-Folie in HTML in Java konvertieren

## **Java PowerPoint zu HTML**

Für Beispielcode in Java zur Konvertierung von PowerPoint in HTML siehe den Abschnitt unten, d.h. [PowerPoint in HTML konvertieren](#convert-powerpoint-to-html). Der Code kann mehrere Formate wie PPT, PPTX und ODP im Präsentationsobjekt laden und es im HTML-Format speichern.

## **Über die PowerPoint zu HTML-Konvertierung**
Mit [**Aspose.Slides für Java**](https://products.aspose.com/slides/java/) können Anwendungen und Entwickler eine PowerPoint-Präsentation in HTML konvertieren: **PPTX zu HTML** oder **PPT zu HTML**. 

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der [**HtmlOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/HtmlOptions) Klasse), die den Konvertierungsprozess von PowerPoint zu HTML definieren:

* Konvertieren Sie eine gesamte PowerPoint-Präsentation in HTML.
* Konvertieren Sie eine spezifische Folie in einer PowerPoint-Präsentation in HTML.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Konvertieren Sie eine PowerPoint-Präsentation in responsives HTML. 
* Konvertieren Sie eine PowerPoint-Präsentation in HTML, wobei RedenNotizen ein- oder ausgeschlossen sind. 
* Konvertieren Sie eine PowerPoint-Präsentation in HTML, wobei Kommentare ein- oder ausgeschlossen sind. 
* Konvertieren Sie eine PowerPoint-Präsentation in HTML mit Original- oder eingebetteten Schriften. 
* Konvertieren Sie eine PowerPoint-Präsentation in HTML, während der neue CSS-Stil verwendet wird.

{{% alert color="primary" %}} 

Über ihre API hat Aspose kostenlose [Präsentation zu HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Sie möchten möglicherweise auch andere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) überprüfen.

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

Neben den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides auch diese Konvertierungsoperationen, die das HTML-Format betreffen: 

* [HTML in Bild](https://products.aspose.com/slides/java/conversion/html-to-image/)
* [HTML in JPG](https://products.aspose.com/slides/java/conversion/html-to-jpg/)
* [HTML in XML](https://products.aspose.com/slides/java/conversion/html-to-xml/)
* [HTML in TIFF](https://products.aspose.com/slides/java/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPoint in HTML konvertieren**
Mit Aspose.Slides können Sie eine gesamte PowerPoint-Präsentation auf folgende Weise in HTML konvertieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Verwenden Sie die [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode, um das Objekt als HTML-Datei zu speichern.

Dieser Code zeigt Ihnen, wie Sie eine PowerPoint in HTML in Java konvertieren:

```java
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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


## **PowerPoint in responsives HTML konvertieren**
Aspose.Slides bietet die [ResponsiveHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/ResponsiveHtmlController) Klasse, die es Ihnen ermöglicht, responsive HTML-Dateien zu generieren. Dieser Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in responsives HTML in Java konvertieren:

```java
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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

## **PowerPoint in HTML mit Notizen konvertieren**
Dieser Code zeigt Ihnen, wie Sie eine PowerPoint in HTML mit Notizen in Java konvertieren:

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    HtmlOptions opt = new HtmlOptions();
	
    INotesCommentsLayoutingOptions options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    // Speichern der Notizseiten
    pres.save("Output.html", SaveFormat.Html, opt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint in HTML mit Original-Schriften konvertieren**

Aspose.Slides stellt die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController) Klasse zur Verfügung, mit der Sie alle Schriften in einer Präsentation beim Konvertieren der Präsentation zu HTML einbetten können.

Um zu verhindern, dass bestimmte Schriften eingebettet werden, können Sie ein Array von Schriftartenamen an einen parameterisierten Konstruktor der [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController) Klasse übergeben. Beliebte Schriftarten wie Calibri oder Arial, die in einer Präsentation verwendet werden, müssen nicht eingebettet werden, da die meisten Systeme bereits solche Schriftarten enthalten. Wenn diese Schriftarten eingebettet sind, wird das resultierende HTML-Dokument unnötig groß.

Die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController) Klasse unterstützt Vererbung und stellt die [WriteFont](https://reference.aspose.com/slides/java/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) Methode zur Verfügung, die überschrieben werden soll. 

```java
Presentation pres = new Presentation("input.pptx");
try {
    // Standardpräsentationsschriften ausschließen
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter(embedFontsController));

    pres.save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint in HTML mit hochwertigen Bildern konvertieren**

Standardmäßig gibt Aspose.Slides beim Konvertieren von PowerPoint in HTML kleine HTML-Dateien mit Bildern bei 72 DPI und gelöschten zugeschnittenen Bereichen aus. Um HTML-Dateien mit höherwertigen Bildern zu erhalten, müssen Sie die Eigenschaft `PicturesCompression` (aus der `HtmlOptions` Klasse) auf 96 (d.h. `PicturesCompression.Dpi96`) oder höhere [Werte](https://reference.aspose.com/slides/java/com.aspose.slides/PicturesCompression) setzen.

Dieser Java-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in HTML konvertieren, während Sie hochwertige Bilder mit 150 DPI (d.h. `PicturesCompression.Dpi150`) erhalten:

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

Dieser Code in Java zeigt Ihnen, wie Sie HTML mit Bildern in voller Qualität ausgeben:

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

## **Folie in HTML konvertieren**
Um eine spezifische Folie in einer PowerPoint-Präsentation in HTML zu konvertieren, müssen Sie dieselbe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse instanziieren (die zuvor verwendet wurde, um gesamte Präsentationen in HTML zu konvertieren) und dann die [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode verwenden, um die Datei als HTML zu speichern. Die [HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/HtmlOptions) Klasse kann verwendet werden, um zusätzliche Konvertierungsoptionen anzugeben:

Dieser Java-Code zeigt Ihnen, wie Sie eine Folie in einer PowerPoint-Präsentation in HTML konvertieren:

```java
Presentation pres = new Presentation("Individual-Slide.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(new CustomFormattingController()));

    // Datei speichern
    for (int i = 0; i < pres.getSlides().size(); i++)
        pres.save("Individual Slide" + (i + 1) + "_out.html", new int[]{i + 1}, SaveFormat.Html, htmlOptions);
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


## **CSS und Bilder beim Export in HTML speichern**
Mit neuen CSS-Stil-Dateien können Sie den Stil der HTML-Datei, die aus dem PowerPoint zu HTML-Konvertierungsprozess resultiert, einfach ändern. 

Der Java-Code in diesem Beispiel zeigt Ihnen, wie Sie überschreibbare Methoden verwenden, um ein benutzerdefiniertes HTML-Dokument mit einem Link zu einer CSS-Datei zu erstellen:

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

    // Benutzerdefinierte Kopfzeilenvorlage
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
        generator.addHtml("<!-- Eingebettete Schriftarten -->");
        super.writeAllFonts(generator, presentation);
    }
}
```

## **Alle Schriften beim Konvertieren der Präsentation in HTML verlinken**

Wenn Sie keine Schriften einbetten möchten (um die Größe des resultierenden HTML zu vermeiden), können Sie alle Schriften verlinken, indem Sie Ihre eigene Version von `LinkAllFontsHtmlController` implementieren. 

Dieser Java-Code zeigt Ihnen, wie Sie eine PowerPoint in HTML konvertieren, während Sie alle Schriften verlinken und "Calibri" und "Arial" ausschließen (da sie bereits im System vorhanden sind): 

```java
Presentation pres = new Presentation("pres.pptx");
try
{
    // Standardpräsentationsschriften ausschließen
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

Dieser Java-Code zeigt Ihnen, wie `LinkAllFontsHtmlController` implementiert ist:

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
            String path = fontName + ".woff"; // eventuelle Pfadbereinigung könnte notwendig sein
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

## **PowerPoint in responsives HTML konvertieren**
Dieser Java-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in responsives HTML konvertieren:

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


## **Medien-Dateien in HTML exportieren**
Mit Aspose.Slides für Java können Sie Mediendateien auf folgende Weise exportieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich eine Referenz auf die Folie.
3. Fügen Sie ein Video zur Folie hinzu.
4. Schreiben Sie die Präsentation als HTML-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie ein Video zur Präsentation hinzufügen und es dann als HTML speichern: 

```java
// Eine Präsentation laden
Presentation pres = new Presentation();
try {
    String path = "./out/";
    final String fileName = "ExportMediaFiles_out.html";
    final String baseUri = "http://www.example.com/";

    byte[] videoData = Files.readAllBytes(Paths.get("my_video.avi"));
    IVideo video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path, fileName, baseUri);

    // Einstellung der HTML-Optionen
    HtmlOptions htmlOptions = new HtmlOptions(controller);
    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(SlideImageFormat.svg(svgOptions));

    // Speichern der Datei
    pres.save(fileName, SaveFormat.Html, htmlOptions);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```