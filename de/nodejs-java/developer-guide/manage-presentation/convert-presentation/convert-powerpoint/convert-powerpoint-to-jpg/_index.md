---
title: PPT und PPTX in JPG konvertieren in JavaScript
linktitle: PowerPoint zu JPG
type: docs
weight: 60
url: /de/nodejs-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu JPG
- Präsentation zu JPG
- Folie zu JPG
- PPT zu JPG
- PPTX zu JPG
- PowerPoint als JPG speichern
- Präsentation als JPG speichern
- Folie als JPG speichern
- PPT als JPG speichern
- PPTX als JPG speichern
- PPT nach JPG exportieren
- PPTX nach JPG exportieren
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie PowerPoint-Folien (PPT, PPTX) in hochwertige JPG-Bilder in JavaScript mit Aspose.Slides für Node.js über Java mittels schneller, zuverlässiger Codebeispiele."
---

## **Über die PowerPoint‑zu‑JPG‑Konvertierung**
Mit [**Aspose.Slides API**](https://products.aspose.com/slides/nodejs-java/) können Sie PowerPoint‑PPT‑ oder PPTX‑Präsentationen in ein JPG‑Bild konvertieren. Es ist außerdem möglich, PPT/PPTX in JPEG, PNG oder SVG zu konvertieren. Mit diesen Funktionen lässt sich leicht ein eigener Präsentations‑Viewer implementieren und das Miniaturbild für jede Folie erstellen. Dies kann nützlich sein, wenn Sie Folien vor dem Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus demonstrieren möchten. Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einer bestimmten Folie in Bildformate.  

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PowerPoint in JPG‑Bilder konvertiert, können Sie diese kostenlosen Online‑Konverter ausprobieren: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTX in JPG konvertieren**
Im Folgenden die Schritte zur Konvertierung von PPT/PPTX nach JPG:

1. Erzeugen Sie eine Instanz des Typs [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie das Folien‑Objekt vom Typ [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) aus der Sammlung [Presentation.getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--).
3. Erstellen Sie das Miniaturbild jeder Folie und konvertieren Sie es anschließend in JPG. Die Methode [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) wird verwendet, um ein Miniaturbild einer Folie zu erhalten; sie liefert ein [Imagess](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images)-Objekt zurück. Die Methode [getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) muss vom gewünschten [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)-Typ aus aufgerufen werden; die Skalierungswerte des resultierenden Miniaturbildes werden an die Methode übergeben.
4. Nachdem Sie das Folien‑Miniaturbild erhalten haben, rufen Sie die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) des Miniaturbild‑Objekts auf. Übergeben Sie den gewünschten Dateinamen und das Bildformat.  

{{% alert color="primary" %}}

**Hinweis**: Die Konvertierung von PPT/PPTX nach JPG unterscheidet sich von der Konvertierung in andere Formate in der Aspose.Slides API. Für andere Formate verwenden Sie in der Regel die Methode [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-), hier benötigen Sie jedoch die Methode [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). 

{{% /alert %}} 
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // Erzeugt ein Bild in voller Größe
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
Um die Abmessungen des resultierenden Miniaturbildes und JPG‑Bildes zu ändern, können Sie die *ScaleX*‑ und *ScaleY*‑Werte setzen, indem Sie sie an die Methode [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getImage-float-float-) übergeben:
```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // Definiert Abmessungen
    var desiredX = 1200;
    var desiredY = 800;
    // Ermittelt skalierte Werte von X und Y
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


## **Kommentare rendern beim Speichern der Präsentation als Bild**
Aspose.Slides für Node.js via Java bietet die Möglichkeit, Kommentare in den Folien einer Präsentation zu rendern, wenn diese Folien in Bilder konvertiert werden. Dieser JavaScript‑Code demonstriert die Vorgehensweise:
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

Aspose stellt eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage) bereit. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr. 

{{% /alert %}}

## **Siehe auch**

Weitere Optionen zum Konvertieren von PPT/PPTX in Bilder finden Sie unter:

- [PPT/PPTX‑zu‑SVG‑Konvertierung](/slides/de/nodejs-java/render-a-slide-as-an-svg-image/).

## **FAQ**

**Unterstützt diese Methode die Batch‑Konvertierung?**

Ja, Aspose.Slides ermöglicht die Batch‑Konvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

**Wird bei der Konvertierung SmartArt, Diagramme und andere komplexe Objekte unterstützt?**

Ja, Aspose.Slides rendert alle Inhalte, einschließlich SmartArt, Diagramme, Tabellen, Formen und mehr. Die Rendering‑Genauigkeit kann jedoch im Vergleich zu PowerPoint leicht variieren, insbesondere bei benutzerdefinierten oder fehlenden Schriftarten.

**Gibt es Beschränkungen hinsichtlich der Anzahl der verarbeitbaren Folien?**

Aspose.Slides selbst legt keine harten Grenzen für die Anzahl der zu verarbeitenden Folien fest. Bei sehr großen Präsentationen oder hochauflösenden Bildern können jedoch Out‑of‑Memory‑Fehler auftreten.