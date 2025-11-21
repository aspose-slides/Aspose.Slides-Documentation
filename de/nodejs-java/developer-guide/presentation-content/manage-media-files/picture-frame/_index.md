---
title: Bildrahmen
type: docs
weight: 10
url: /de/nodejs-java/picture-frame/
keywords:
- Bildrahmen
- Bildrahmen hinzufügen
- Bildrahmen erstellen
- Bild hinzufügen
- Bild erstellen
- Bild extrahieren
- Bild zuschneiden
- StretchOff-Eigenschaft
- Bildrahmen-Formatierung
- Bildrahmen-Eigenschaften
- Bildeffekt
- Seitenverhältnis
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides für Node.js via Java
description: "Ein Bildrahmen zu einer PowerPoint-Präsentation in JavaScript hinzufügen"
---

Ein Bildrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen. 

Sie können einem Folie ein Bild über einen Bildrahmen hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tip" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG nach PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 

{{% /alert %}} 

## **Bildrahmen erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Erstellen Sie ein `PPImage`-Objekt, indem Sie ein Bild zur [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie ein [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) basierend auf der Breite und Höhe des Bildes, über die Methode `addPictureFrame`, die vom Form-Objekt bereitgestellt wird, das mit der referenzierten Folie verknüpft ist.
6. Fügen Sie der Folie einen Bildrahmen (der das Bild enthält) hinzu.
7. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieses JavaScript‑Codebeispiel zeigt, wie Sie einen Bildrahmen erstellen:
```javascript
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Liest die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Instanziiert die Image-Klasse
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Fügt einen Bildrahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="warning" %}} 

Bildrahmen ermöglichen es Ihnen, schnell Präsentationsfolien auf Basis von Bildern zu erstellen. Wenn Sie den Bildrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie Ein‑ und Ausgabevorgänge steuern, um Bilder von einem Format in ein anderes zu konvertieren. Möglicherweise möchten Sie diese Seiten ansehen: konvertieren [Bild zu JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), konvertieren [PNG zu JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), konvertieren [SVG zu PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

## **Bildrahmen mit relativer Skalierung erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.
4. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage)-Objekt, indem Sie ein Bild zur [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.
6. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieses JavaScript‑Codebeispiel zeigt, wie Sie einen Bildrahmen mit relativer Skalierung erstellen:
```javascript
// Instanziere die Presentation-Klasse, die die PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Hole die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Instanziere die Image-Klasse
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Füge einen Bildrahmen mit Höhe und Breite des Bildes hinzu
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Relative Skalierung von Breite und Höhe festlegen
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Schreibe die PPTX-Datei auf die Festplatte
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame)-Objekten extrahieren und in PNG, JPG und anderen Formaten speichern. Das untenstehende Codebeispiel zeigt, wie Sie ein Bild aus dem Dokument „sample.pptx“ extrahieren und im PNG-Format speichern.
```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```


## **SVG‑Bilder aus Bildrahmen extrahieren**

Wenn eine Präsentation SVG‑Grafiken enthält, die in [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)-Formen platziert sind, ermöglicht Aspose.Slides für Node.js über Java das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Durch Durchlaufen der Formensammlung der Folie können Sie jedes [PictureFrame]‑Objekt identifizieren, prüfen, ob das zugrunde liegende [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) SVG‑Inhalte enthält, und das Bild anschließend auf dem Datenträger oder in einem Stream im nativen SVG‑Format speichern.

Der folgende Code demonstriert, wie ein SVG‑Bild aus einem Bildrahmen extrahiert wird:
```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```


## **Transparenz eines Bildes erhalten**

Aspose.Slides ermöglicht es Ihnen, den auf ein Bild angewendeten Transparenzeffekt abzurufen. Dieser JavaScript‑Code demonstriert die Vorgehensweise:
```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```


## **Bildrahmenformatierung**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen anpassen, um spezifische Anforderungen zu erfüllen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Erstellen Sie ein [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage)-Objekt, indem Sie ein Bild zur [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie ein `PictureFrame` basierend auf der Breite und Höhe des Bildes über die Methode [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) , die vom [Shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection)-Objekt bereitgestellt wird, das mit der referenzierten Folie verknüpft ist.
6. Fügen Sie den Bildrahmen (der das Bild enthält) der Folie hinzu.
7. Legen Sie die Linienfarbe des Bildrahmens fest.
8. Legen Sie die Linienbreite des Bildrahmens fest.
9. Rotieren Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn. 
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.
10. Fügen Sie den Bildrahmen (der das Bild enthält) der Folie hinzu.
11. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

Dieser JavaScript‑Code demonstriert den Bildrahmenformatierungsprozess:
```javascript
// Instanziert die Presentation-Klasse, die die PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Holt die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Instanziert die Image-Klasse
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Fügt einen Bildrahmen mit Höhe und Breite des Bildes hinzu
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Wendet einige Formatierungen auf PictureFrameEx an
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="Tip" color="primary" %}}

Aspose hat kürzlich einen [kostenlosen Collage‑Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie jemals [JPG/JPEG zusammenführen](https://products.aspose.app/slides/collage/jpg) oder PNG‑Bilder, [Raster aus Fotos erstellen](https://products.aspose.app/slides/collage/photo-grid), benötigen, können Sie diesen Dienst nutzen. 

{{% /alert %}}

## **Bild als Link hinzufügen**

Um große Präsentationsgrößen zu vermeiden, können Sie Bilder (oder Videos) über Links hinzufügen, anstatt die Dateien direkt in die Präsentation einzubetten. Dieser JavaScript‑Code zeigt, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:
```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Bild zuschneiden**

Dieser JavaScript‑Code zeigt, wie Sie ein vorhandenes Bild auf einer Folie zuschneiden:
```javascript
var pres = new aspose.slides.Presentation();
// Erstellt ein neues Bildobjekt
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Fügt einen Bildrahmen zu einer Folie hinzu
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Schneidet das Bild zu (Prozentwerte)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Speichert das Ergebnis
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Zugeschnittene Bereiche des Bildes löschen**

Wenn Sie die zugeschnittenen Bereiche eines Bildes, das in einem Rahmen enthalten ist, löschen möchten, können Sie die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) verwenden. Diese Methode gibt das zugeschnittene Bild zurück oder das Originalbild, falls ein Zuschnitt nicht erforderlich ist.

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Holt den Bildrahmen von der ersten Folie
    var picFrame = slide.getShapes().get_Item(0);
    // Löscht zugeschnittene Bereiche des Bildes im Bildrahmen und gibt das zugeschnittene Bild zurück
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Speichert das Ergebnis
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


{{% alert title="NOTE" color="warning" %}} 

Die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) fügt das zugeschnittene Bild zur Bildsammlung der Präsentation hinzu. Wird das Bild nur im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) verwendet, kann diese Vorgehensweise die Präsentationsgröße reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Diese Methode konvertiert WMF/EMF‑Metadateien im Zuschnittsvorgang in ein rasterisiertes PNG‑Bild. 

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, selbst wenn Sie die Bildabmessungen ändern, können Sie die Methode [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) verwenden, um die Einstellung *Seitenverhältnis sperren* zu aktivieren.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // Form so einstellen, dass das Seitenverhältnis beim Skalieren beibehalten wird
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="NOTE" color="warning" %}} 

Diese Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form, nicht jedoch das darin enthaltene Bild. 
{{% /alert %}}

## **StretchOff‑Eigenschaft verwenden**

Durch die Verwendung der Methoden [setStretchOffsetLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) und [setStretchOffsetBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) aus der Klasse [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat) können Sie ein Füllrechteck festlegen.

Wenn ein Bild gestreckt werden soll, wird ein Quellrechteck so skaliert, dass es in das angegebene Füllrechteck passt. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz bedeutet eine Einbuchtung, ein negativer Prozentsatz bedeutet ein Aufsatz.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentatio).
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Rechteck `AutoShape` hinzu. 
4. Erstellen Sie ein Bild. 
5. Legen Sie den Fülltyp der Form fest. 
6. Legen Sie den Bildfüllmodus der Form fest. 
7. Fügen Sie ein festgelegtes Bild hinzu, um die Form zu füllen. 
8. Geben Sie Bildversätze von der entsprechenden Kante der Begrenzungsbox der Form an. 
9. Speichern Sie die modifizierte Präsentation als PPTX-Datei. 

Dieser JavaScript‑Code demonstriert einen Prozess, in dem eine StretchOff‑Eigenschaft verwendet wird:
```javascript
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
var pres = new aspose.slides.Presentation();
try {
    // Holt die erste Folie
    var slide = pres.getSlides().get_Item(0);
    // Instanziert die ImageEx-Klasse
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Fügt eine AutoShape vom Typ Rechteck hinzu
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Setzt den Fülltyp der Form
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Setzt den Bildfüllmodus der Form
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Setzt das Bild zum Füllen der Form
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Gibt die Bildversätze relativ zur entsprechenden Kante des Begrenzungsrahmens der Form an
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Wie kann ich herausfinden, welche Bildformate für PictureFrame unterstützt werden?**

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen Dutzender großer Bilder auf die PPTX‑Größe und die Leistung aus?**

Das Einbetten großer Bilder vergrößert die Dateigröße und den Speicherverbrauch; das Verlinken von Bildern hilft, die Präsentationsgröße klein zu halten, erfordert jedoch, dass die externen Dateien weiterhin zugänglich sind. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern sperren?**

Verwenden Sie [Shape‑Locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) für ein [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) (z. B. zum Deaktivieren von Verschieben oder Größentransformation). Der Sperrmechanismus wird für Formen in einem separaten [Schutz‑Artikel](/slides/de/nodejs-java/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen, einschließlich [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), unterstützt.

**Wird die Vektor‑Treue von SVG beim Export einer Präsentation nach PDF/Bildern beibehalten?**

Aspose.Slides ermöglicht das Extrahieren eines SVGs aus einem [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) als ursprünglichen Vektor. Beim [Export nach PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/) oder in [Rasterformate](/slides/de/nodejs-java/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen rasterisiert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert ist, wird durch das Extraktionsverhalten bestätigt.