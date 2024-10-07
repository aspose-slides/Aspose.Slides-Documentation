---
title: PowerPoint in HTML konvertieren mit Java
linktitle: PowerPoint in HTML konvertieren
type: docs
weight: 30
url: /androidjava/convert-powerpoint-to-html/
keywords: "Java PowerPoint in HTML, PowerPoint-Präsentation konvertieren, PPTX, PPT, PPT in HTML, PPTX in HTML, PowerPoint in HTML, PowerPoint als HTML speichern, PPT als HTML speichern, PPTX als HTML speichern, Java, Aspose.Slides, HTML-Export"
description: "PowerPoint HTML in Java konvertieren: Speichern Sie PPTX oder PPT als HTML in Java. Speichern Sie Folien als HTML in Java"
---

## **Übersicht**

In diesem Artikel wird erklärt, wie man eine PowerPoint-Präsentation im HTML-Format mit Java konvertiert. Es werden die folgenden Themen behandelt.

- PowerPoint in HTML in Java konvertieren
- PPT in HTML in Java konvertieren
- PPTX in HTML in Java konvertieren
- ODP in HTML in Java konvertieren
- PowerPoint-Folie in HTML in Java konvertieren

## **Java PowerPoint in HTML**

Für Java-Beispielcode zur Konvertierung von PowerPoint in HTML siehe den Abschnitt unten, d.h. [PowerPoint in HTML konvertieren](#convert-powerpoint-to-html). Der Code kann mehrere Formate wie PPT, PPTX und ODP im Präsentationsobjekt laden und in HTML-Format speichern.

## **Über die PowerPoint in HTML-Konvertierung**
Mit [**Aspose.Slides für Android via Java**](https://products.aspose.com/slides/androidjava/) können Anwendungen und Entwickler eine PowerPoint-Präsentation in HTML konvertieren: **PPTX in HTML** oder **PPT in HTML**.

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der [**HtmlOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) Klasse), die den Konvertierungsprozess von PowerPoint zu HTML definieren:

* Konvertieren Sie eine gesamte PowerPoint-Präsentation in HTML.
* Konvertieren Sie eine bestimmte Folie in einer PowerPoint-Präsentation in HTML.
* Konvertieren Sie Medien der Präsentation (Bilder, Videos usw.) in HTML.
* Konvertieren Sie eine PowerPoint-Präsentation in responsives HTML. 
* Konvertieren Sie eine PowerPoint-Präsentation in HTML mit eingeschlossenen oder ausgeschlossenen Notizen. 
* Konvertieren Sie eine PowerPoint-Präsentation in HTML mit eingeschlossenen oder ausgeschlossenen Kommentaren. 
* Konvertieren Sie eine PowerPoint-Präsentation in HTML mit Original- oder eingebetteten Schriftarten. 
* Konvertieren Sie eine PowerPoint-Präsentation in HTML unter Verwendung des neuen CSS-Stils. 

{{% alert color="primary" %}} 

Mit einer eigenen API hat Aspose kostenlose [Präsentation in HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) Konverter entwickelt: [PPT in HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX in HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP in HTML](https://products.aspose.app/slides/conversion/odp-to-html) usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Sie möchten möglicherweise andere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) überprüfen.

{{% /alert %}} 

{{% alert title="Hinweis" color="warning" %}} 

Neben den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides auch diese Konvertierungsoperationen, die das HTML-Format betreffen: 

* [HTML zu Bild](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPoint in HTML konvertieren**
Mit Aspose.Slides können Sie eine gesamte PowerPoint-Präsentation auf folgende Weise in HTML konvertieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Verwenden Sie die [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode, um das Objekt als HTML-Datei zu speichern.

Dieser Code zeigt Ihnen, wie Sie eine PowerPoint in HTML mit Java konvertieren:

```java
// Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
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
Aspose.Slides bietet die [ResponsiveHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ResponsiveHtmlController) Klasse, die es Ihnen ermöglicht, responsive HTML-Dateien zu generieren. Dieser Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in responsives HTML mit Java konvertieren:

```java
// Instanziieren Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
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

## **PowerPoint in HTML mit Original-Schriftarten konvertieren**

Aspose.Slides bietet die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) Klasse, die es Ihnen ermöglicht, alle Schriftarten in einer Präsentation einzubetten, während die Präsentation in HTML konvertiert wird.

Um zu verhindern, dass bestimmte Schriftarten eingebettet werden, können Sie ein Array von Schriftartnamen an einen parameterisierten Konstruktor der [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) Klasse übergeben. Beliebte Schriftarten wie Calibri oder Arial, die in einer Präsentation verwendet werden, müssen nicht eingebettet werden, da die meisten Systeme diese Schriftarten bereits enthalten. Wenn diese Schriftarten eingebettet werden, wird das resultierende HTML-Dokument unnötig groß.

Die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController) Klasse unterstützt die Vererbung und bietet die [WriteFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EmbedAllFontsHtmlController#writeFont-com.aspose.slides.IHtmlGenerator-com.aspose.slides.IFontData-com.aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) Methode, die überschrieben werden soll.

```java
Presentation pres = new Presentation("input.pptx");
try {
    // Standard-Präsentationsschriftarten ausschließen
    String[] fontNameExcludeList = { "Calibri", "Arial" };

    EmbedAllFontsHtmlController embedFontsController = new EmbedAllFontsHtmlController(fontNameExcludeList);

    HtmlOptions htmlOptionsEmbed = new HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(HtmlFormatter.createCustomFormatter(embedFontsController));

    pres.save("input-PFDinDisplayPro-Regular-installed.html", SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint in HTML mit Bildern hoher Qualität konvertieren**

Standardmäßig gibt Aspose.Slides beim Konvertieren von PowerPoint in HTML kleine HTML-Dateien mit Bildern von 72 DPI aus und entfernt zugeschnittene Bereiche. Um HTML-Dateien mit Bildern höherer Qualität zu erhalten, müssen Sie die `PicturesCompression`-Eigenschaft (aus der `HtmlOptions`-Klasse) auf 96 (d.h. `PicturesCompression.Dpi96`) oder höhere [Werte](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PicturesCompression) setzen.

Dieser Java-Code zeigt Ihnen, wie Sie eine PowerPoint-Präsentation in HTML konvertieren können, während Sie Bilder in hoher Qualität mit 150 DPI (d.h. `PicturesCompression.Dpi150`) erhalten:

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

Dieser Code in Java zeigt Ihnen, wie Sie HTML mit Bildern voller Qualität ausgeben:

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
Um eine bestimmte Folie in einer PowerPoint-Präsentation in HTML zu konvertieren, müssen Sie dieselbe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse instanziieren (die für die Konvertierung von gesamten Präsentationen in HTML verwendet wird) und dann die [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode verwenden, um die Datei als HTML zu speichern. Die [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/HtmlOptions) Klasse kann verwendet werden, um zusätzliche Konvertierungsoptionen anzugeben:

Dieser Java-Code zeigt Ihnen, wie Sie eine Folie in einer PowerPoint-Präsentation in HTML konvertieren:

```java
Presentation pres = new Presentation("Individual-Slide.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
	
    htmlOptions.setHtmlFormatter(HtmlFormatter.createCustomFormatter(new CustomFormattingController()));

    // Speichern der Datei
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


## **CSS und Bilder beim Export nach HTML speichern**
Mit neuen CSS-Stil-Dateien können Sie den Stil der HTML-Datei, die aus dem PowerPoint-in-HTML-Konvertierungsprozess resultiert, einfach ändern. 

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
        generator.addHtml("<!-- Eingebettete Schriftarten -->");
        super.writeAllFonts(generator, presentation);
    }
}
```

## **Alle Schriftarten beim Konvertieren der Präsentation zu HTML verlinken**

Wenn Sie keine Schriftarten einbetten möchten (um die Größe des resultierenden HTML zu vermeiden), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene `LinkAllFontsHtmlController`-Version implementieren. 

Dieser Java-Code zeigt Ihnen, wie Sie eine PowerPoint in HTML konvertieren, während Sie alle Schriftarten verlinken und "Calibri" und "Arial" ausschließen (da sie bereits im System vorhanden sind): 

```java
Presentation pres = new Presentation("pres.pptx");
try
{
    //Standard-Präsentationsschriftarten ausschließen
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

Dieser Java-Code zeigt Ihnen, wie `LinkAllFontsHtmlController` implementiert wird:

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
            String path = fontName + ".woff"; // Möglicherweise ist eine einige Pfadbereinigung erforderlich
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


## **Medien Dateien nach HTML exportieren**
Mit Aspose.Slides für Android via Java können Sie Medien-Dateien auf diese Weise exportieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
1. Holen Sie sich eine Referenz auf die Folie.
1. Fügen Sie der Folie ein Video hinzu.
1. Schreiben Sie die Präsentation als HTML-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie ein Video zur Präsentation hinzufügen und dann als HTML speichern: 

```java
// Laden einer Präsentation
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

    // Speichern der Datei
    pres.save(fileName, SaveFormat.Html, htmlOptions);
} catch(Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```