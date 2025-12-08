---
title: PowerPoint zu HTML in JavaScript konvertieren
linktitle: Powerpoint zu HTML konvertieren
type: docs
weight: 30
url: /de/nodejs-java/convert-powerpoint-to-html/
keywords: "Java PowerPoint zu HTML, PowerPoint-Präsentation konvertieren, PPTX, PPT, PPT zu HTML, PPTX zu HTML, PowerPoint zu HTML, PowerPoint als HTML speichern, PPT als HTML speichern, PPTX als HTML speichern, Java, Aspose.Slides, HTML-Export"
description: "PowerPoint in HTML mit JavaScript konvertieren. PPTX oder PPT in JavaScript als HTML speichern. Folien in JavaScript als HTML speichern."
---

## **Übersicht**

Dieser Artikel erklärt, wie man PowerPoint‑Präsentationen mit JavaScript in das HTML‑Format konvertiert. Er behandelt die folgenden Themen.

- PowerPoint mit JavaScript in HTML konvertieren
- PPT mit JavaScript in HTML konvertieren
- PPTX mit JavaScript in HTML konvertieren
- ODP mit JavaScript in HTML konvertieren
- PowerPoint‑Folien mit JavaScript in HTML konvertieren

## **Java PowerPoint zu HTML**

Für Beispielcode in JavaScript zur Konvertierung von PowerPoint zu HTML siehe den Abschnitt unten, d.h.[PowerPoint zu HTML konvertieren](#convert-powerpoint-to-html). Der Code kann mehrere Formate wie PPT, PPTX und ODP im Presentation‑Objekt laden und in das HTML‑Format speichern.

## **Über die PowerPoint‑zu‑HTML‑Konvertierung**
Mit [**Aspose.Slides für Node.js via Java**](https://products.aspose.com/slides/nodejs-java/) können Anwendungen und Entwickler eine PowerPoint‑Präsentation in HTML konvertieren: **PPTX zu HTML** oder **PPT zu HTML**.

**Aspose.Slides** bietet viele Optionen (meist aus der Klasse [**HtmlOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) ) die den PowerPoint‑zu‑HTML‑Konvertierungsprozess definieren:

* Eine komplette PowerPoint‑Präsentation in HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint‑Präsentation in HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) in HTML konvertieren.
* Eine PowerPoint‑Präsentation in responsives HTML konvertieren.
* Eine PowerPoint‑Präsentation in HTML konvertieren, wobei Sprecher‑Notizen ein‑ oder ausgeschlossen werden.
* Eine PowerPoint‑Präsentation in HTML konvertieren, wobei Kommentare ein‑ oder ausgeschlossen werden.
* Eine PowerPoint‑Präsentation in HTML konvertieren, wobei originale oder eingebettete Schriftarten verwendet werden.
* Eine PowerPoint‑Präsentation in HTML konvertieren, wobei der neue CSS‑Stil verwendet wird.

{{% alert color="primary" %}} 

Mit seiner eigenen API hat Aspose kostenlose [Präsentation‑zu‑HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)‑Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html), usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vielleicht möchten Sie sich weitere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) ansehen.

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

Außer den hier beschriebenen Konvertierungsprozessen unterstützt Aspose.Slides auch die folgenden Konvertierungsoperationen im Zusammenhang mit dem HTML‑Format: 

* [HTML zu Bild](https://products.aspose.com/slides/nodejs-java/conversion/html-to-image/)
* [HTML zu JPG](https://products.aspose.com/slides/nodejs-java/conversion/html-to-jpg/)
* [HTML zu XML](https://products.aspose.com/slides/nodejs-java/conversion/html-to-xml/)
* [HTML zu TIFF](https://products.aspose.com/slides/nodejs-java/conversion/html-to-tiff/)

{{% /alert %}}


## **PowerPoint zu HTML konvertieren**
Mit Aspose.Slides können Sie eine komplette PowerPoint‑Präsentation wie folgt in HTML konvertieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑Klasse.
2. Verwenden Sie die [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-)‑Methode, um das Objekt als HTML‑Datei zu speichern.

Dieser Code zeigt, wie Sie ein PowerPoint in JavaScript nach HTML konvertieren:
```javascript
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var htmlOpt = new aspose.slides.HtmlOptions();
    htmlOpt.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    htmlOpt.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
    // Speichern der Präsentation als HTML
    pres.save("ConvertWholePresentationToHTML_out.html", aspose.slides.SaveFormat.Html, htmlOpt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```



## **PowerPoint zu responsive HTML konvertieren**
Aspose.Slides stellt die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ResponsiveHtmlController) zur Verfügung, mit der Sie responsive HTML‑Dateien erzeugen können. Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in JavaScript zu responsive HTML konvertieren:
```javascript
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("Convert_HTML.pptx");
try {
    var controller = new aspose.slides.ResponsiveHtmlController();
    var htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    // Speichern der Präsentation als HTML
    pres.save("ConvertPresentationToResponsiveHTML_out.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint zu HTML mit Notizen konvertieren**
Dieser Code zeigt, wie Sie ein PowerPoint in JavaScript zu HTML mit Notizen konvertieren:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var opt = new aspose.slides.HtmlOptions();
    var options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Speichern von Notizseiten
    pres.save("Output.html", aspose.slides.SaveFormat.Html, opt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint zu HTML mit Original‑Schriftarten konvertieren**

Aspose.Slides stellt die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) zur Verfügung, die es ermöglicht, beim Konvertieren einer Präsentation in HTML alle Schriftarten einzubetten.

Um zu verhindern, dass bestimmte Schriftarten eingebettet werden, können Sie dem parametrisierten Konstruktor der Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) ein Array von Schriftartnamen übergeben. Beliebte Schriftarten wie Calibri oder Arial müssen nicht eingebettet werden, wenn sie in einer Präsentation verwendet werden, da die meisten Systeme diese bereits enthalten. Wenn diese Schriftarten eingebettet werden, wird das resultierende HTML‑Dokument unnötig groß.

Die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) unterstützt Vererbung und stellt die Methode [WriteFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-aspose.slides.IHtmlGenerator-aspose.slides.IFontData-aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-) bereit, die überschrieben werden soll.
```javascript
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Standard-Präsentationsschriften ausschließen
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var embedFontsController = new aspose.slides.EmbedAllFontsHtmlController(fontNameExcludeList);
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(embedFontsController));
    pres.save("input-PFDinDisplayPro-Regular-installed.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint zu HTML mit hochwertigen Bildern konvertieren**

Standardmäßig erzeugt Aspose.Slides beim Konvertieren von PowerPoint zu HTML ein kleines HTML mit Bildern bei 72 DPI und entfernten beschnittenen Bereichen. Um HTML‑Dateien mit höherwertigen Bildern zu erhalten, müssen Sie den Wert `96` an die Methode `setPicturesCompression` der Klasse `HtmlOptions` übergeben (d.h. `PicturesCompression.Dpi96`) oder höhere [Werte](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PicturesCompression).

Der JavaScript‑Code zeigt, wie Sie eine PowerPoint‑Präsentation zu HTML konvertieren und dabei hochwertige Bilder mit 150 DPI erhalten (d.h. `PicturesCompression.Dpi150`):
```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);
    pres.save("OutputDoc-dpi150.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Dieser JavaScript‑Code zeigt, wie Sie HTML mit Bildern in voller Qualität ausgeben:
```javascript
var pres = new aspose.slides.Presentation("InputDoc.pptx");
try {
    var htmlOpts = new aspose.slides.HtmlOptions();
    htmlOpts.setDeletePicturesCroppedAreas(false);
    pres.save("Outputdoc-noCrop.html", aspose.slides.SaveFormat.Html, htmlOpts);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Folien zu HTML konvertieren**
Um eine bestimmte Folie in einem PowerPoint zu HTML zu konvertieren, müssen Sie dieselbe Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) (die zum Konvertieren kompletter Präsentationen in HTML verwendet wird) instanziieren und dann die Methode [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) benutzen, um die Datei als HTML zu speichern. Die Klasse [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions) kann verwendet werden, um zusätzliche Konvertierungsoptionen anzugeben:

Der JavaScript‑Code zeigt, wie Sie eine Folie einer PowerPoint‑Präsentation zu HTML konvertieren:
```javascript
var pres = new aspose.slides.Presentation("Individual-Slide.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    
    const CustomFormattingController = java.newProxy("com.aspose.slides.IHtmlFormattingController", {
        writeDocumentStart: function(generator, presentation) {

        },

        writeDocumentEnd: function(generator, presentation) {

        },

        writeSlideStart: function(generator, slide) {
            const slideIndex = generator.getSlideIndex() + 1;
            const slideHeaderHtml = `<div class="slide" name="slide" id="slide${slideIndex}">`;
            generator.addHtml(slideHeaderHtml);
        },

        writeSlideEnd: function(generator, slide) {
            const slideFooterHtml = "</div>";
            generator.addHtml(slideFooterHtml);
        },

        writeShapeStart: function(generator, shape) {
        },

        writeShapeEnd: function(generator, shape) {
        }
    });
    
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(CustomFormattingController));
    // Datei speichern
    for (var i = 0; i < pres.getSlides().size(); i++) {
        pres.save(("Individual Slide" + (i + 1)) + "_out.html", java.newArray("int", [i + 1]), aspose.slides.SaveFormat.Html, htmlOptions);
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **CSS und Bilder beim Exportieren zu HTML speichern**
Mit neuen CSS‑Stildateien können Sie das Aussehen der aus dem PowerPoint‑zu‑HTML‑Konvertierungsprozess resultierenden HTML‑Datei leicht ändern.

Der JavaScript‑Code in diesem Beispiel zeigt, wie Sie überschreibbare Methoden verwenden, um ein benutzerdefiniertes HTML‑Dokument mit einem Link zu einer CSS‑Datei zu erstellen:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var htmlController = java.newInstanceSync("CustomHeaderAndFontsController", "styles.css");
    var options = new aspose.slides.HtmlOptions();
    options.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(htmlController));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Sie müssen CustomHeaderAndFontsController in Java implementieren, kompilieren und in das Modul‑Verzeichnis \aspose.slides.via.java\lib\ hinzufügen.
Dieser Java‑Code zeigt, wie `CustomHeaderAndFontsController` implementiert wird:
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
Wenn Sie Schriftarten nicht einbetten möchten (um die Größe des resultierenden HTML nicht zu erhöhen), können Sie alle Schriftarten verlinken, indem Sie Ihre eigene Version von `LinkAllFontsHtmlController` implementieren.

Der JavaScript‑Code zeigt, wie Sie ein PowerPoint zu HTML konvertieren, dabei alle Schriftarten verlinken und "Calibri" sowie "Arial" ausschließen (da sie bereits im System vorhanden sind):
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Standard-Präsentationsschriften ausschließen
    var fontNameExcludeList = java.newArray("java.lang.String", ["Calibri", "Arial"]));
    var linkcont = java.newInstanceSync("LinkAllFontsHtmlController", fontNameExcludeList, "C:/Windows/Fonts/");
    var htmlOptionsEmbed = new aspose.slides.HtmlOptions();
    htmlOptionsEmbed.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(linkcont));
    pres.save("pres.html", aspose.slides.SaveFormat.Html, htmlOptionsEmbed);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Sie müssen LinkAllFontsHtmlController in Java implementieren, kompilieren und in das Modul‑Verzeichnis \aspose.slides.via.java\lib\ hinzufügen.
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
Der JavaScript‑Code zeigt, wie Sie eine PowerPoint‑Präsentation zu responsive HTML konvertieren:
```javascript
var pres = new aspose.slides.Presentation("SomePresentation.pptx");
try {
    var saveOptions = new aspose.slides.HtmlOptions();
    saveOptions.setSvgResponsiveLayout(true);
    pres.save("SomePresentation-out.html", aspose.slides.SaveFormat.Html, saveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Medien‑Dateien zu HTML exportieren**
Mit Aspose.Slides für Node.js via Java können Sie Mediendateien wie folgt exportieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑Klasse.
2. Holen Sie sich eine Referenz zur Folie.
3. Fügen Sie ein Video zur Folie hinzu.
4. Schreiben Sie die Präsentation als HTML‑Datei.

Der JavaScript‑Code zeigt, wie Sie ein Video zur Präsentation hinzufügen und anschließend als HTML speichern:
```javascript
// Präsentation laden
var pres = new aspose.slides.Presentation();
try {
    var path = "./out/";
    final var fileName = "ExportMediaFiles_out.html";
    final var baseUri = "http://www.example.com/";
    var videoData = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "my_video.avi"));
    var video = pres.getVideos().addVideo(videoData);
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    var controller = new aspose.slides.VideoPlayerHtmlController(path, fileName, baseUri);
    // HTML-Optionen festlegen
    var htmlOptions = new aspose.slides.HtmlOptions(controller);
    var svgOptions = new aspose.slides.SVGOptions(controller);
    htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createCustomFormatter(controller));
    htmlOptions.setSlideImageFormat(aspose.slides.SlideImageFormat.svg(svgOptions));
    // Datei speichern
    pres.save(fileName, aspose.slides.SaveFormat.Html, htmlOptions);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Wie ist die Leistung von Aspose.Slides beim Konvertieren mehrerer Präsentationen zu HTML?**

Die Leistung hängt von Größe und Komplexität der Präsentationen ab. Aspose.Slides ist für Batch‑Operationen sehr effizient und skalierbar. Um optimale Leistung beim Konvertieren vieler Präsentationen zu erzielen, wird empfohlen, nach Möglichkeit Multithreading oder Parallelverarbeitung einzusetzen.

**Unterstützt Aspose.Slides den Export von Hyperlinks zu HTML?**

Ja, Aspose.Slides unterstützt den Export eingebetteter Hyperlinks nach HTML vollständig. Beim Konvertieren von Präsentationen in das HTML‑Format werden Hyperlinks automatisch erhalten und bleiben anklickbar.

**Gibt es ein Limit für die Anzahl der Folien beim Konvertieren von Präsentationen zu HTML?**

Es gibt kein Limit für die Folienanzahl bei der Verwendung von Aspose.Slides. Sie können Präsentationen jeder Größe konvertieren. Bei Präsentationen mit einer sehr großen Folienzahl kann die Leistung jedoch von den verfügbaren Ressourcen Ihres Servers oder Systems abhängen.
