---
title: Optimieren der Bildverwaltung in Präsentationen mit JavaScript
linktitle: Bilder verwalten
type: docs
weight: 10
url: /de/nodejs-java/image/
keywords:
- Bild hinzufügen
- Bild hinzufügen
- Bitmap hinzufügen
- Bild ersetzen
- Bild ersetzen
- aus dem Web
- Hintergrund
- PNG hinzufügen
- JPG hinzufügen
- SVG hinzufügen
- EMF hinzufügen
- WMF hinzufügen
- TIFF hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "Vereinfachen Sie die Bildverwaltung in PowerPoint und OpenDocument mit JavaScript und Aspose.Slides für Node.js, optimieren Sie die Leistung und automatisieren Sie Ihren Arbeitsablauf."
---

## **Bilder in Folien in Präsentationen**

Bilder machen Präsentationen ansprechender und interessanter. In Microsoft PowerPoint können Sie Bilder aus einer Datei, dem Internet oder anderen Orten auf Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Folien in Ihren Präsentationen durch verschiedene Verfahren. 

{{% alert  title="Tip" color="primary" %}} 

Aspose stellt kostenlose Konverter bereit—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es ermöglichen, Präsentationen schnell aus Bildern zu erstellen. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Wenn Sie ein Bild als Rahmenobjekt hinzufügen möchten – insbesondere wenn Sie beabsichtigen, Standardformatierungsoptionen zu verwenden, um seine Größe zu ändern, Effekte hinzuzufügen usw. – siehe [Picture Frame](https://docs.aspose.com/slides/nodejs-java/picture-frame/).

{{% /alert %}} 

Aspose.Slides unterstützt Operationen mit Bildern in diesen gängigen Formaten: JPEG, PNG, GIF und weitere. 

## **Hinzufügen von lokal gespeicherten Bildern zu Folien**

Sie können ein oder mehrere Bilder von Ihrem Computer zu einer Folie in einer Präsentation hinzufügen. Dieser Beispielcode in JavaScript zeigt, wie man ein Bild zu einer Folie hinzufügt:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Hinzufügen von Bildern aus einem Stream zu Folien**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, nicht auf Ihrem Computer verfügbar ist, können Sie das Bild direkt aus dem Web hinzufügen. 

Dieser Beispielcode zeigt, wie man ein Bild aus dem Web zu einer Folie in JavaScript hinzufügt:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Greift auf die erste Folie zu
    var sld = pres.getSlides().get_Item(0);
    // Lädt eine Excel-Datei in einen Stream
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Erstellt ein Datenobjekt zum Einbetten
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Fügt ein Ole-Object-Frame-Shape hinzu
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Hinzufügen von Bildern zu Folienmaster**

Ein Folienmaster ist die übergeordnete Folie, die Informationen (Design, Layout usw.) über alle darunterliegenden Folien speichert und steuert. Wenn Sie also ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf jeder Folie, die diesem Folienmaster zugeordnet ist. 

Dieser JavaScript-Beispielcode zeigt, wie man ein Bild zu einem Folienmaster hinzufügt:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Hinzufügen von Bildern als Folienhintergrund**

Sie können entscheiden, ein Bild als Hintergrund für eine bestimmte Folie oder mehrere Folien zu verwenden. In diesem Fall sollten Sie *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/nodejs-java/presentation-background/#setting-images-as-background-for-slides)* ansehen.

## **Hinzufügen von SVG zu Präsentationen**
Sie können jedes Bild in eine Präsentation einfügen, indem Sie die Methode [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) verwenden, die zur Klasse [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) gehört.

Um ein Bildobjekt basierend auf einem SVG-Bild zu erstellen, können Sie wie folgt vorgehen:

1. Erstellen Sie ein SvgImage-Objekt, um es in die ImageShapeCollection einzufügen.
2. Erstellen Sie ein PPImage-Objekt aus ISvgImage.
3. Erstellen Sie ein PictureFrame-Objekt mit der PPImage-Klasse.

Dieser Beispielcode zeigt, wie Sie die obigen Schritte implementieren, um ein SVG-Bild in eine Präsentation einzufügen:
```javascript
// Instanziieren der Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Konvertieren von SVG in ein Satz von Formen**
Die Konvertierung von SVG in ein Satz von Formen durch Aspose.Slides ist ähnlich der PowerPoint-Funktionalität, die zum Arbeiten mit SVG-Bildern verwendet wird:

![PowerPoint Popup Menu](img_01_01.png)

Die Funktion wird von einer der Überladungen der [addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-)‑Methode der Klasse [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) bereitgestellt, die ein [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SvgImage)-Objekt als erstes Argument erwartet.

Dieser Beispielcode zeigt, wie Sie die beschriebene Methode verwenden, um eine SVG‑Datei in ein Satz von Formen zu konvertieren:
```javascript
// Neue Präsentation erstellen
var presentation = new aspose.slides.Presentation();
try {
    // SVG-Dateiinhalt lesen
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // SvgImage-Objekt erstellen
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Foliengröße abrufen
    var slideSize = presentation.getSlideSize().getSize();
    // SVG-Bild in eine Gruppe von Formen konvertieren und an die Foliengröße anpassen
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Präsentation im PPTX-Format speichern
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Hinzufügen von Bildern als EMF in Folien**
Aspose.Slides für Node.js via Java ermöglicht das Erzeugen von EMF‑Bildern aus Excel‑Tabellen und das Hinzufügen dieser Bilder als EMF in Folien mit Aspose.Cells. 

Dieser Beispielcode zeigt, wie Sie die beschriebene Aufgabe ausführen:
```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
 // Speichert die Arbeitsmappe in einen Stream
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ersetzen von Bildern in der Bildersammlung**

Aspose.Slides ermöglicht das Ersetzen von Bildern, die in der Bildersammlung einer Präsentation gespeichert sind (einschließlich der von Folienformen verwendeten). Dieser Abschnitt zeigt verschiedene Ansätze zum Aktualisieren von Bildern in der Sammlung. Die API bietet einfache Methoden zum Ersetzen eines Bildes mithilfe von rohen Byte‑Daten, einer [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/)-Instanz oder eines anderen Bildes, das bereits in der Sammlung vorhanden ist.

Führen Sie die folgenden Schritte aus:

1. Laden Sie die Präsentationsdatei, die Bilder enthält, mit der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.
3. Ersetzen Sie das Zielbild durch das neue Bild mithilfe des Byte‑Arrays.
4. Im zweiten Ansatz laden Sie das Bild in ein [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/)-Objekt und ersetzen das Zielbild durch dieses Objekt.
5. Im dritten Ansatz ersetzen Sie das Zielbild durch ein Bild, das bereits in der Bildersammlung der Präsentation vorhanden ist.
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.
```js
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Der erste Weg.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Der zweite Weg.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Der dritte Weg.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Speichern Sie die Präsentation in einer Datei.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}

Mit dem kostenlosen Aspose [Text to GIF](https://products.aspose.app/slides/text-to-gif)-Konverter können Sie Texte leicht animieren, GIFs aus Texten erstellen usw. 

{{% /alert %}}

## **FAQ**

**Bleibt die ursprüngliche Bildauflösung nach dem Einfügen erhalten?**

Ja. Die ursprünglichen Pixeldaten bleiben erhalten, aber das endgültige Erscheinungsbild hängt davon ab, wie das [picture](/slides/de/nodejs-java/picture-frame/) auf der Folie skaliert wird und welche Kompression beim Speichern angewendet wird.

**Was ist der beste Weg, um dasselbe Logo gleichzeitig auf Dutzenden von Folien zu ersetzen?**

Platzieren Sie das Logo auf der Masterfolie oder einem Layout und ersetzen Sie es in der Bildersammlung der Präsentation – die Änderungen werden an alle Elemente, die diese Ressource verwenden, weitergegeben.

**Kann ein eingefügtes SVG in editierbare Formen konvertiert werden?**

Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren, wobei einzelne Teile anschließend mit den Standard-Shape-Eigenschaften editierbar sind.

**Wie kann ich ein Bild gleichzeitig als Hintergrund für mehrere Folien festlegen?**

[Weisen Sie das Bild als Hintergrund](/slides/de/nodejs-java/presentation-background/) auf der Masterfolie oder dem entsprechenden Layout zu – alle Folien, die diesen Master/Layout verwenden, übernehmen den Hintergrund.

**Wie verhindere ich, dass die Präsentation durch viele Bilder stark anwächst?**

Verwenden Sie eine einzelne Bildressource mehrfach anstelle von Duplikaten, wählen Sie angemessene Auflösungen, wenden Sie Kompression beim Speichern an und behalten Sie wiederholte Grafiken nach Möglichkeit im Master.