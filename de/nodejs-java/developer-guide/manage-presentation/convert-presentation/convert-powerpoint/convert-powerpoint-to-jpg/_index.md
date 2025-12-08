---
title: PowerPoint zu JPG konvertieren
type: docs
weight: 60
url: /de/nodejs-java/convert-powerpoint-to-jpg/
keywords: "PowerPoint zu JPG konvertieren, PPTX zu JPEG, PPT zu JPEG"
description: "PowerPoint zu JPG konvertieren: PPT zu JPG, PPTX zu JPG in JavaScript"
---

## **Über die PowerPoint-zu-JPG-Konvertierung**
Mit [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) können Sie PowerPoint PPT oder PPTX Präsentationen in JPG Bild konvertieren. Es ist ebenfalls möglich, PPT/PPTX in JPEG, PNG oder SVG zu konvertieren. Mit diesen Funktionen lässt sich leicht ein eigener Präsentations Viewer implementieren und das Vorschaubild für jede Folie erstellen. Dies kann nützlich sein, wenn Sie Folien vor dem Kopieren schützen oder die Präsentation im Nurlese-Modus demonstrieren möchten. Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einer einzelnen Folie in Bildformate.

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PowerPoint in JPG-Bilder konvertiert, können Sie diese kostenlosen Online-Konverter ausprobieren: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX in JPG konvertieren**
Hier sind die Schritte, um PPT/PPTX in JPG zu konvertieren:

1. Erstellen Sie eine Instanz vom Typ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie das Folienobjekt vom Typ [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) aus der Sammlung [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--).
3. Erstellen Sie das Vorschaubild jeder Folie und konvertieren Sie es anschließend in JPG. Die Methode [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) wird verwendet, um ein Vorschaubild einer Folie zu erhalten; sie gibt ein [Imagess](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images)-Objekt zurück. Die Methode [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) muss vom gewünschten [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)-Objekt aufgerufen werden, wobei die Skalierungswerte des resultierenden Vorschaubildes an die Methode übergeben werden.
4. Nachdem Sie das Folien-Vorschaubild erhalten haben, rufen Sie die Methode [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)) vom Vorschaubild-Objekt auf. Übergeben Sie dabei den gewünschten Dateinamen und das Bildformat.

{{% alert color="primary" %}}

**Hinweis**: Die PPT/PPTX-zu-JPG-Konvertierung unterscheidet sich von der Konvertierung zu anderen Formaten in der Aspose.Slides API. Für andere Formate verwenden Sie normalerweise die Methode [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), hier benötigen Sie jedoch die Methode [**Image.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Image#save(String formatName, int imageFormat)).

{{% /alert %}} 
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Erstellt ein Bild in voller Größe
        var slideImage = sld.getImage(1.0, 1.0);
        // Speichert das Bild auf der Festplatte im JPEG-Format
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **PowerPoint PPT/PPTX in JPG mit benutzerdefinierten Abmessungen konvertieren**
Um die Abmessungen des resultierenden Vorschaubildes und JPG-Bildes zu ändern, können Sie die Werte *ScaleX* und *ScaleY* über die Methode [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) übergeben:
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Definiert Abmessungen
    var desiredX = 1200;
    var desiredY = 800;
    // Erhält skalierte Werte von X und Y
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Erstellt ein Bild in voller Größe
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // Speichert das Bild auf der Festplatte im JPEG-Format
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Kommentare rendern, wenn die Präsentation als Bild gespeichert wird**
Aspose.Slides für Node.js via Java bietet eine Funktion, mit der Sie Kommentare in den Folien einer Präsentation rendern können, wenn Sie diese Folien in Bilder konvertieren. Dieser JavaScript-Code demonstriert die Vorgehensweise:
```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Tip" color="primary" %}}

Aspose stellt eine [KOSTENLOSE Collage-Web-App](https://products.aspose.app/slides/collage) bereit. Mit diesem Online-Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [Foto-Raster](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr. 

Mit den gleichen in diesem Artikel beschriebenen Prinzipien können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: Konvertieren Sie [Bild zu JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/); Konvertieren Sie [JPG zu Bild](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/); Konvertieren Sie [JPG zu PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), Konvertieren Sie [PNG zu JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); Konvertieren Sie [PNG zu SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), Konvertieren Sie [SVG zu PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

## **Siehe auch**

Weitere Optionen zum Konvertieren von PPT/PPTX in ein Bild finden Sie z. B. unter:

- [PPT/PPTX zu SVG Konvertierung](/slides/de/nodejs-java/render-a-slide-as-an-svg-image/).

## **FAQ**

**Unterstützt diese Methode die Stapelkonvertierung?**

Ja, Aspose.Slides ermöglicht die Stapelkonvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

**Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?**

Ja, Aspose.Slides rendert alle Inhalte, einschließlich SmartArt, Diagramme, Tabellen, Formen und mehr. Die Rendergenauigkeit kann jedoch im Vergleich zu PowerPoint leicht variieren, insbesondere bei benutzerdefinierten oder fehlenden Schriftarten.

**Gibt es Einschränkungen hinsichtlich der Anzahl der verarbeitbaren Folien?**

Aspose.Slides selbst legt keine strengen Beschränkungen für die Anzahl der zu verarbeitenden Folien fest. Allerdings können bei großen Präsentationen oder hochauflösenden Bildern Speicher-Out-of-Memory-Fehler auftreten.