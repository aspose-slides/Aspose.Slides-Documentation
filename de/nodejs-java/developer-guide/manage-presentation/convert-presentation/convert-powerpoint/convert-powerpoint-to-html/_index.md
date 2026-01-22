---
title: PowerPoint-Präsentationen mit JavaScript in HTML konvertieren
linktitle: PowerPoint zu HTML
type: docs
weight: 30
url: /de/nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint-Präsentationen in responsives HTML konvertieren. Layout, Links und Bilder mit dem Aspose.Slides-Konvertierungsleitfaden für schnelle, fehlerfreie Ergebnisse erhalten."
---

## **Übersicht**

Dieser Artikel erklärt, wie man eine PowerPoint‑Präsentation mit JavaScript in das HTML‑Format konvertiert. Er behandelt die folgenden Themen.

- PowerPoint nach HTML in JavaScript konvertieren
- PPT nach HTML in JavaScript konvertieren
- PPTX nach HTML in JavaScript konvertieren
- ODP nach HTML in JavaScript konvertieren
- PowerPoint‑Folie nach HTML in JavaScript konvertieren

## **Java PowerPoint zu HTML**

Für Beispielcode in JavaScript zum Konvertieren von PowerPoint zu HTML siehe bitte den Abschnitt unten, d.h.[Convert PowerPoint to HTML](#convert-powerpoint-to-html). Der Code kann eine Reihe von Formaten wie PPT, PPTX und ODP im Presentation‑Objekt laden und in das HTML‑Format speichern.

## **Über die Konvertierung von PowerPoint zu HTML**

Mit **Aspose.Slides for Node.js via Java** können Anwendungen und Entwickler eine PowerPoint‑Präsentation in HTML konvertieren: PPTX zu HTML oder PPT zu HTML.

**Aspose.Slides** bietet viele Optionen (hauptsächlich aus der [**HtmlOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions)‑Klasse), die den PowerPoint‑zu‑HTML‑Konvertierungsprozess definieren:

* Eine gesamte PowerPoint‑Präsentation nach HTML konvertieren.
* Eine bestimmte Folie einer PowerPoint‑Präsentation nach HTML konvertieren.
* Präsentationsmedien (Bilder, Videos usw.) nach HTML konvertieren.
* Eine PowerPoint‑Präsentation in responsives HTML konvertieren.
* Eine PowerPoint‑Präsentation nach HTML konvertieren, wobei Sprecher‑Notizen ein‑ oder ausgeschlossen werden.
* Eine PowerPoint‑Präsentation nach HTML konvertieren, wobei Kommentare ein‑ oder ausgeschlossen werden.
* Eine PowerPoint‑Präsentation nach HTML konvertieren, mit originalen oder eingebetteten Schriften.
* Eine PowerPoint‑Präsentation nach HTML konvertieren, wobei der neue CSS‑Stil verwendet wird.

{{% alert color="primary" %}} 

Mit seiner eigenen API hat Aspose kostenlose [Präsentation‑zu‑HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)‑Konverter entwickelt: [PPT zu HTML](https://products.aspose.app/slides/conversion/ppt-to-html), [PPTX zu HTML](https://products.aspose.app/slides/conversion/pptx-to-html), [ODP zu HTML](https://products.aspose.app/slides/conversion/odp-to-html), usw. 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

Vielleicht möchten Sie sich weitere [kostenlose Konverter von Aspose](https://products.aspose.app/slides/conversion) ansehen.

{{% /alert %}} 

## **PowerPoint nach HTML konvertieren**
Mit Aspose.Slides können Sie eine gesamte PowerPoint‑Präsentation folgendermaßen nach HTML konvertieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) Klasse.
1. Verwenden Sie die [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-)‑Methode, um das Objekt als HTML‑Datei zu speichern.

Dieser Code zeigt, wie man eine PowerPoint‑Präsentation in JavaScript nach HTML konvertiert:
```javascript
// Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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


## **PowerPoint zu responsivem HTML konvertieren**
Aspose.Slides stellt die Klasse [ResponsiveHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ResponsiveHtmlController) bereit, die das Erzeugen responsiver HTML‑Dateien ermöglicht. Dieser Code zeigt, wie man eine PowerPoint‑Präsentation in JavaScript zu responsivem HTML konvertiert:
```javascript
// Instanziiere ein Presentation-Objekt, das eine Präsentationsdatei darstellt
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


## **PowerPoint nach HTML mit Notizen konvertieren**
Dieser Code zeigt, wie man eine PowerPoint‑Präsentation in JavaScript nach HTML mit Notizen konvertiert:
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var opt = new aspose.slides.HtmlOptions();
    var options = opt.getNotesCommentsLayouting();
    options.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Speichern der Notizseiten
    pres.save("Output.html", aspose.slides.SaveFormat.Html, opt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint nach HTML mit Originalschriften konvertieren**
Aspose.Slides stellt die Klasse [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController) bereit, die es ermöglicht, während der Konvertierung einer Präsentation nach HTML alle Schriftarten in die Präsentation einzubetten.

Um zu verhindern, dass bestimmte Schriftarten eingebettet werden, können Sie ein Array mit Schriftartnamen an den parameterisierten Konstruktor der [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController)‑Klasse übergeben. Beliebte Schriftarten wie Calibri oder Arial müssen bei Verwendung in einer Präsentation nicht eingebettet werden, da die meisten Systeme diese bereits enthalten. Werden diese Schriftarten eingebettet, wird das resultierende HTML‑Dokument unnötig groß.

Die [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController)‑Klasse unterstützt Vererbung und stellt die [WriteFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/EmbedAllFontsHtmlController#writeFont-aspose.slides.IHtmlGenerator-aspose.slides.IFontData-aspose.slides.IFontData-java.lang.String-java.lang.String-byte:A-)‑Methode bereit, die überschrieben werden soll.
```javascript
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Standard-Schriften der Präsentation ausschließen
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


## **PowerPoint nach HTML mit hochqualitativen Bildern konvertieren**
Standardmäßig gibt Aspose.Slides beim Konvertieren von PowerPoint zu HTML ein kleines HTML mit Bildern bei 72 DPI und gelöschten Beschnittbereichen aus. Um HTML‑Dateien mit höherwertigen Bildern zu erhalten, müssen Sie `96` an die `setPicturesCompression`‑Methode der `HtmlOptions`‑Klasse übergeben (d. h. `PicturesCompression.Dpi96`) oder höhere Werte verwenden.

Dieser JavaScript‑Code zeigt, wie man eine PowerPoint‑Präsentation in HTML konvertiert und dabei hochqualitative Bilder mit 150 DPI erhält (d. h. `PicturesCompression.Dpi150`):
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


Dieser Code in JavaScript zeigt, wie man HTML mit Bildern in voller Qualität ausgibt:
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


## **Folie nach HTML konvertieren**
Um eine bestimmte Folie einer PowerPoint‑Präsentation nach HTML zu konvertieren, müssen Sie dieselbe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑Klasse instanziieren (wie beim Konvertieren ganzer Präsentationen) und anschließend die [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-)‑Methode verwenden, um die Datei als HTML zu speichern. Die [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HtmlOptions)‑Klasse kann verwendet werden, um zusätzliche Konvertierungsoptionen anzugeben:

Dieser JavaScript‑Code zeigt, wie man eine Folie einer PowerPoint‑Präsentation in HTML konvertiert:
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


## **CSS und Bilder beim Exportieren nach HTML speichern**
Mit neuen CSS‑Stildateien können Sie das Aussehen der HTML‑Datei, die aus dem PowerPoint‑zu‑HTML‑Konvertierungsprozess entsteht, leicht ändern. 

Der JavaScript‑Code in diesem Beispiel zeigt, wie Sie überschreibbare Methoden nutzen, um ein benutzerdefiniertes HTML‑Dokument mit einem Link zu einer CSS‑Datei zu erstellen:
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

Sie müssen `CustomHeaderAndFontsController` in Java implementieren, kompilieren und in das Modulverzeichnis \aspose.slides.via.java\lib\ einbinden.
Dieser Java‑Code zeigt, wie `CustomHeaderAndFontsController` implementiert wird:
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
        generator.addHtml("<!-- Embedded fonts -->");
        super.writeAllFonts(generator, presentation);
    }
}
```


## **Alle Schriften verlinken beim Konvertieren einer Präsentation zu HTML**

Wenn Sie Schriftarten nicht einbetten möchten (um die Größe des resultierenden HTML zu reduzieren), können Sie alle Schriften verlinken, indem Sie Ihre eigene Version des `LinkAllFontsHtmlController` implementieren. 

Dieser JavaScript‑Code zeigt, wie man eine PowerPoint‑Präsentation nach HTML konvertiert, dabei alle Schriftarten verlinkt und „Calibri“ sowie „Arial“ ausschließt (da diese bereits im System vorhanden sind):
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Standard-Schriften der Präsentation ausschließen
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


Sie müssen `LinkAllFontsHtmlController` in Java implementieren, kompilieren und in das Modulverzeichnis \aspose.slides.via.java\lib\ einbinden.
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
            String path = fontName + ".woff"; // einige Pfadbereinigungen können erforderlich sein
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


## **PowerPoint nach HTML konvertieren**
Dieser JavaScript‑Code zeigt, wie man eine PowerPoint‑Präsentation in responsives HTML konvertiert:
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


## **Mediendateien nach HTML exportieren**
Mit Aspose.Slides for Node.js via Java können Sie Mediendateien wie folgt exportieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑Klasse.
1. Holen Sie sich eine Referenz zur Folie.
1. Fügen Sie der Folie ein Video hinzu.
1. Schreiben Sie die Präsentation als HTML‑Datei.

Dieser JavaScript‑Code zeigt, wie man ein Video zur Präsentation hinzufügt und anschließend als HTML speichert:
```javascript
// Lade eine Präsentation
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

**Wie ist die Leistung von Aspose.Slides beim Konvertieren mehrerer Präsentationen nach HTML?**

Die Leistung hängt von Größe und Komplexität der Präsentationen ab. Aspose.Slides ist sehr effizient und skalierbar für Batch‑Operationen. Für optimale Leistung beim Konvertieren vieler Präsentationen wird empfohlen, Mehrfach‑Threading oder parallele Verarbeitung zu nutzen, wann immer möglich.

**Unterstützt Aspose.Slides das Exportieren von Hyperlinks nach HTML?**

Ja, Aspose.Slides unterstützt das vollständige Exportieren eingebetteter Hyperlinks nach HTML. Beim Konvertieren von Präsentationen nach HTML werden Hyperlinks automatisch erhalten und bleiben anklickbar.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren von Präsentationen nach HTML?**

Es gibt keine Begrenzung der Folienzahl bei der Verwendung von Aspose.Slides. Sie können Präsentationen jeder Größe konvertieren. Bei sehr großen Präsentationen kann die Leistung jedoch von den verfügbaren Ressourcen Ihres Servers oder Systems abhängen.