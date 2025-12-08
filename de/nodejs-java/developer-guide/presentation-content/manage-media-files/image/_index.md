---
title: Bild
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
- Aspose.Slides
description: "Optimieren Sie die Bildverwaltung in PowerPoint und OpenDocument mit Aspose.Slides für Node.js, verbessern Sie die Leistung und automatisieren Sie Ihren Workflow."
---

## **Bilder in Folien von Präsentationen**

Bilder machen Präsentationen ansprechender und interessanter. In Microsoft PowerPoint können Sie Bilder aus einer Datei, dem Internet oder anderen Quellen in Folien einfügen. Ebenso ermöglicht Aspose.Slides das Hinzufügen von Bildern zu Folien in Ihren Präsentationen über verschiedene Verfahren.

{{% alert  title="Tip" color="primary" %}} 
Aspose bietet kostenlose Konverter—[JPEG nach PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — mit denen Sie schnell Präsentationen aus Bildern erstellen können. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Wenn Sie ein Bild als Rahmenobjekt hinzufügen möchten — insbesondere, wenn Sie Standardformatierungsoptionen nutzen wollen, um Größe, Effekte usw. zu ändern — sehen Sie sich [Bildrahmen](https://docs.aspose.com/slides/nodejs-java/picture-frame/) an. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Sie können Ein- und Ausgabevorgänge mit Bildern und PowerPoint‑Präsentationen manipulieren, um ein Bild von einem Format in ein anderes zu konvertieren. Siehe diese Seiten: Konvertieren Sie [Bild zu JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/); konvertieren Sie [JPG zu Bild](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/); konvertieren Sie [JPG zu PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), konvertieren Sie [PNG zu JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); konvertieren Sie [PNG zu SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), konvertieren Sie [SVG zu PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides unterstützt Vorgänge mit Bildern in diesen gängigen Formaten: JPEG, PNG, GIF und weitere. 

## **Lokale Bilder zu Folien hinzufügen**

Sie können ein oder mehrere Bilder von Ihrem Computer zu einer Folie einer Präsentation hinzufügen. Der folgende Beispielcode in JavaScript zeigt, wie Sie ein Bild zu einer Folie hinzufügen:
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


## **Bilder aus einem Stream zu Folien hinzufügen**

Wenn das Bild, das Sie zu einer Folie hinzufügen möchten, nicht auf Ihrem Computer verfügbar ist, können Sie das Bild direkt aus dem Web hinzufügen. 

Der folgende Beispielcode zeigt, wie Sie ein Bild aus dem Web zu einer Folie in JavaScript hinzufügen:
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
    // Fügt ein Ole Object Frame Shape hinzu
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


## **Bilder zu Folienmaster hinzufügen**

Ein Folienmaster ist die übergeordnete Folie, die Informationen (Design, Layout usw.) für alle darunterliegenden Folien speichert und steuert. Wenn Sie also ein Bild zu einem Folienmaster hinzufügen, erscheint dieses Bild auf jeder Folie, die diesen Folienmaster verwendet. 

Der folgende JavaScript‑Beispielcode zeigt, wie Sie ein Bild zu einem Folienmaster hinzufügen:
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


## **Bilder als Folienhintergrund hinzufügen**

Sie können ein Bild als Hintergrund für eine bestimmte Folie oder mehrere Folien verwenden. In diesem Fall sollten Sie *[Bilder als Hintergrund für Folien festlegen](https://docs.aspose.com/slides/nodejs-java/presentation-background/#setting-images-as-background-for-slides)* ansehen.

## **SVG zu Präsentationen hinzufügen**
Sie können jedes Bild in eine Präsentation einfügen, indem Sie die Methode [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) der Klasse [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) verwenden.

Um ein Bildobjekt auf Basis einer SVG‑Datei zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie ein SvgImage‑Objekt, um es in die ImageShapeCollection einzufügen.
2. Erstellen Sie ein PPImage‑Objekt aus dem ISvgImage.
3. Erstellen Sie ein PictureFrame‑Objekt mithilfe der PPImage‑Klasse.

Der folgende Beispielcode zeigt, wie Sie die oben genannten Schritte umsetzen, um ein SVG‑Bild in eine Präsentation einzufügen:
```javascript
// Instanziiere die Presentation-Klasse, die eine PPTX-Datei darstellt
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


## **SVG in ein Satz von Formen konvertieren**
Die SVG‑Konvertierung von Aspose.Slides in einen Satz von Formen entspricht der PowerPoint‑Funktionalität zum Arbeiten mit SVG‑Bildern:

![PowerPoint Popup-Menü](img_01_01.png)

Die Funktion wird von einer der Überladungen der Methode [addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) der Klasse [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) bereitgestellt, die ein [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SvgImage)‑Objekt als erstes Argument akzeptiert.

Der folgende Beispielcode zeigt, wie Sie die beschriebene Methode verwenden, um eine SVG‑Datei in einen Satz von Formen zu konvertieren:
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
    // SVG-Bild in Gruppe von Formen konvertieren und auf Foliengröße skalieren
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


## **Bilder als EMF in Folien hinzufügen**
Aspose.Slides für Node.js via Java ermöglicht das Erzeugen von EMF‑Bildern aus Excel‑Tabellen und das Hinzufügen dieser Bilder als EMF in Folien mit Aspose.Cells.  

Der folgende Beispielcode zeigt, wie Sie die beschriebene Aufgabe ausführen:
```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Save the workbook to stream
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


## **Bilder in der Bildsammlung ersetzen**

Aspose.Slides erlaubt das Ersetzen von Bildern, die in der Bildsammlung einer Präsentation gespeichert sind (einschließlich der von Folienformen verwendeten Bilder). Dieser Abschnitt zeigt mehrere Ansätze zum Aktualisieren von Bildern in der Sammlung. Die API bietet unkomplizierte Methoden, um ein Bild mithilfe von rohen Byte‑Daten, einer [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/)-Instanz oder einem anderen bereits in der Sammlung vorhandenen Bild zu ersetzen.

Befolgen Sie die folgenden Schritte:

1. Laden Sie die Präsentationsdatei, die Bilder enthält, mit der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .  
2. Laden Sie ein neues Bild aus einer Datei in ein Byte‑Array.  
3. Ersetzen Sie das Zielbild durch das neue Bild mithilfe des Byte‑Arrays.  
4. Im zweiten Ansatz laden Sie das Bild in ein [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/)-Objekt und ersetzen das Zielbild durch dieses Objekt.  
5. Im dritten Ansatz ersetzen Sie das Zielbild durch ein Bild, das bereits in der Bildsammlung der Präsentation existiert.  
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.  
```js
// Instanziiere die Presentation-Klasse, die eine Präsentationsdatei darstellt.
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
    
    // Speichere die Präsentation in einer Datei.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}
Mit dem kostenlosen Aspose FREE‑Konverter [Text nach GIF](https://products.aspose.app/slides/text-to-gif) können Sie Texte leicht animieren, GIFs aus Texten erstellen usw. 
{{% /alert %}}

## **FAQ**

**Bleibt die ursprüngliche Bildauflösung nach dem Einfügen erhalten?**  
Ja. Die Quellpixel werden beibehalten, jedoch hängt das endgültige Erscheinungsbild davon ab, wie das [Bild](/slides/de/nodejs-java/picture-frame/) auf der Folie skaliert wird und welche Kompression beim Speichern angewendet wird.

**Wie ersetze ich dasselbe Logo gleichzeitig auf Dutzenden von Folien?**  
Platzieren Sie das Logo auf dem Master‑Slide oder einem Layout und ersetzen Sie es in der Bildsammlung der Präsentation — die Änderungen werden auf alle Elemente übertragen, die diese Ressource nutzen.

**Kann ein eingefügtes SVG in editierbare Formen konvertiert werden?**  
Ja. Sie können ein SVG in eine Gruppe von Formen konvertieren; danach können einzelne Teile mit den Standard‑Formeigenschaften bearbeitet werden.

**Wie setze ich ein Bild als Hintergrund für mehrere Folien gleichzeitig?**  
[Weisen Sie das Bild als Hintergrund](/slides/de/nodejs-java/presentation-background/) dem Master‑Slide oder dem entsprechenden Layout zu — alle Folien, die diesen Master/Layout verwenden, erben den Hintergrund.

**Wie verhindere ich, dass die Präsentation durch zu viele Bilder stark anwächst?**  
Verwenden Sie ein einzelnes Bild mehrfach anstatt Duplikaten, wählen Sie angemessene Auflösungen, aktivieren Sie Kompression beim Speichern und platzieren Sie wiederkehrende Grafiken nach Möglichkeit im Master.