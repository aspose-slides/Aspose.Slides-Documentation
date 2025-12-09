---
title: Verwalten von Bildrahmen in Präsentationen mit Java
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/java/picture-frame/
keywords:
- Bildrahmen
- Bildrahmen hinzufügen
- Bildrahmen erstellen
- Bild hinzufügen
- Bild erstellen
- Bild extrahieren
- Rasterbild
- Vektorbild
- Bild zuschneiden
- zugeschnittener Bereich
- StretchOff-Eigenschaft
- Bildrahmenformatierung
- Bildrahmen-Eigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Fügen Sie Bildrahmen zu PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design Ihrer Folien."
---

Ein Bildrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen.

Sie können einem Folienabschnitt über einen Bildrahmen ein Bild hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Hinweis" color="primary" %}} 

Aspose bietet kostenlose Konverter — [JPEG nach PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — die es ermöglichen, Präsentationen schnell aus Bildern zu erstellen. 

{{% /alert %}} 

## **Bildrahmen erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Holen Sie sich über den Index eine Referenz auf eine Folie. 
3. Erzeugen Sie ein [IPPImage]()‑Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie über die Methode `AddPictureFrame`, die vom Formobjekt der referenzierten Folie bereitgestellt wird, ein [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) basierend auf Breite und Höhe des Bildes.
6. Fügen Sie der Folie einen Bildrahmen (mit dem Bild) hinzu.
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie ein Bildrahmen erstellt wird:
```java
// Instanziert die Presentation‑Klasse, die einer PPTX‑Datei entspricht
Presentation pres = new Presentation();
try {
    // Ruft die erste Folie ab
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziert die Image‑Klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Fügt einen Bildrahmen mit der gleichen Höhe und Breite des Bildes hinzu
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Schreibt die PPTX‑Datei auf die Festplatte
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 

Bildrahmen ermöglichen das schnelle Erstellen von Präsentationsfolien basierend auf Bildern. In Kombination mit den Speichereinstellungen von Aspose.Slides können Sie Ein‑ und Ausgabevorgänge manipulieren, um Bilder von einem Format in ein anderes zu konvertieren. Weitere Informationen finden Sie hier: Bild nach JPG konvertieren ([image to JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/)); JPG nach Bild konvertieren ([JPG to image](https://products.aspose.com/slides/java/conversion/jpg-to-image/)); JPG nach PNG konvertieren ([JPG to PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)), PNG nach JPG konvertieren ([PNG to JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/)); PNG nach SVG konvertieren ([PNG to SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)), SVG nach PNG konvertieren ([SVG to PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/)).

{{% /alert %}}

## **Bildrahmen mit relativer Skalierung erstellen**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erzeugen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Holen Sie sich über den Index eine Referenz auf eine Folie. 
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.
4. Erzeugen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.
6. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie ein Bildrahmen mit relativer Skalierung erstellt wird:
```java
// Instanziert die Presentation-Klasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holt die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziert die Image-Klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Fügt einen Bildrahmen mit gleicher Höhe und Breite wie das Bild hinzu
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Setzt relative Skalierung für Breite und Höhe
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame)-Objekten extrahieren und in PNG, JPG und anderen Formaten speichern. Das folgende Beispiel demonstriert das Extrahieren eines Bildes aus der Datei „sample.pptx“ und das Speichern im PNG‑Format.
```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```


## **SVG‑Bilder aus Bildrahmen extrahieren**

Enthält eine Präsentation SVG‑Grafiken, die in [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/)-Formen eingebettet sind, ermöglicht Aspose.Slides für Java das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Durch Durchlaufen der Formsammlung der Folie können Sie jede [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) erkennen, prüfen, ob das zugrunde liegende [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) SVG‑Inhalt enthält, und das Bild dann im nativen SVG‑Format auf Datenträger oder in einen Stream speichern.

Der folgende Code demonstriert das Extrahieren eines SVG‑Bildes aus einem Bildrahmen:
```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```


## **Transparenz des Bildes ermitteln**

Aspose.Slides ermöglicht das Auslesen des auf ein Bild angewendeten Transparenzeffekts. Dieser Java‑Code demonstriert den Vorgang:
```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```


## **Bildrahmen formatieren**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen so anpassen, dass er bestimmte Anforderungen erfüllt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Holen Sie sich über den Index eine Referenz auf eine Folie. 
3. Erzeugen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie über die Methode [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) ein `PictureFrame` basierend auf Breite und Höhe des Bildes, das vom [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection)-Objekt der referenzierten Folie bereitgestellt wird.
6. Fügen Sie den Bildrahmen (mit dem Bild) der Folie hinzu.
7. Setzen Sie die Linienfarbe des Bildrahmens.
8. Setzen Sie die Linienbreite des Bildrahmens.
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn. 
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.
10. Fügen Sie den Bildrahmen (mit dem Bild) erneut der Folie hinzu.
11. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code demonstriert den Formatierungsprozess für Bildrahmen:
```java
// Instanziert die Presentation-Klasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Ruft die erste Folie ab
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziert die Image-Klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Fügt einen Bildrahmen mit gleicher Höhe und Breite wie das Bild hinzu
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Wendet einige Formatierungen auf PictureFrameEx an
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Hinweis" color="primary" %}}

Aspose hat vor kurzem einen [kostenlosen Collage‑Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie jemals [JPG/JPEG](https://products.aspose.app/slides/collage/jpg) oder PNG‑Bilder zusammenführen ([merge]) oder Fotogitter erstellen ([create grids from photos]) möchten, können Sie diesen Service nutzen. 

{{% /alert %}}

## **Bild als Link hinzufügen**

Um die Dateigröße von Präsentationen zu reduzieren, können Sie Bilder (oder Videos) über Links einbinden, anstatt die Dateien direkt in die Präsentation zu integrieren. Dieser Java‑Code zeigt, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:
```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Bild zuschneiden**

Dieser Java‑Code zeigt, wie Sie ein vorhandenes Bild auf einer Folie zuschneiden:
```java
Presentation pres = new Presentation();
// Erstellt ein neues Bildobjekt
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt einem Folienobjekt einen Bildrahmen hinzu
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Beschneidet das Bild (Prozentwerte)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Speichert das Ergebnis
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zugespitzte Bildbereiche entfernen**

Wenn Sie die zugeschnittenen Bereiche eines Bildes in einem Rahmen entfernen möchten, können Sie die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) verwenden. Diese Methode gibt das zugeschnittene Bild zurück oder das Originalbild, falls ein Zuschneiden nicht erforderlich ist.

Dieser Java‑Code demonstriert den Vorgang:
```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Holt den PictureFrame von der ersten Folie
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Löscht zugeschnittene Bereiche des PictureFrame-Bildes und gibt das zugeschnittene Bild zurück
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Speichert das Ergebnis
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


{{% alert title="HINWEIS" color="warning" %}} 

Die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) fügt das zugeschnittene Bild der Bildsammlung der Präsentation hinzu. Wird das Bild ausschließlich im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) verwendet, kann diese Einstellung die Dateigröße der Präsentation reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Während des Zuschneidens wird die WMF/EMF‑Metadatei in ein Raster‑PNG‑Bild umgewandelt. 

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, selbst wenn Sie die Bildabmessungen ändern, können Sie die Methode [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) verwenden, um die Einstellung *Seitenverhältnis sperren* zu aktivieren. 

Dieser Java‑Code zeigt, wie Sie das Seitenverhältnis einer Form sperren:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // Form so einstellen, dass das Seitenverhaeltnis beim Aendern der Groesse erhalten bleibt
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="HINWEIS" color="warning" %}} 

Die Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form, nicht jedoch das des darin enthaltenen Bildes.

{{% /alert %}}

## **StretchOffset‑Eigenschaft verwenden**

Mit den Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) und [StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) des [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat)-Interfaces bzw. der [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat)-Klasse können Sie ein Füllrechteck festlegen. 

Wird für ein Bild das Strecken angegeben, wird ein Quellrechteck skaliert, sodass es in das definierte Füllrechteck passt. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz bedeutet ein Einrücken, ein negativer Prozentsatz ein Auseinanderziehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentatio)-Klasse.
2. Holen Sie sich über den Index eine Referenz auf eine Folie.
3. Fügen Sie ein Rechteck `AutoShape` hinzu. 
4. Erzeugen Sie ein Bild.
5. Setzen Sie den Fülltyp der Form.
6. Setzen Sie den Bildfüllmodus der Form.
7. Fügen Sie ein Bild hinzu, um die Form zu füllen.
8. Geben Sie Bildversätze relativ zu den entsprechenden Kanten der Begrenzungsbox der Form an.
9. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code demonstriert einen Prozess, bei dem eine StretchOffset‑Eigenschaft verwendet wird:
```java
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Holt die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Instanziert die ImageEx-Klasse
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt eine AutoShape hinzu, festgelegt auf Rechteck
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Setzt den Fülltyp der Form
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Setzt den Bildfüllmodus der Form
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Setzt das Bild, um die Form zu füllen
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Gibt die Bildversätze relativ zur jeweiligen Kante der Begrenzungsbox der Form an
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wie kann ich herausfinden, welche Bildformate für PictureFrame unterstützt werden?**

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Möglichkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen dutlicher großer Bilder auf die PPTX‑Größe und Performance aus?**

Das Einbetten großer Bilder erhöht die Dateigröße und den Speicherverbrauch; das Verlinken von Bildern hält die Präsentationsgröße klein, erfordert jedoch, dass die externen Dateien erreichbar bleiben. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt davor schützen, versehentlich verschoben oder skaliert zu werden?**

Verwenden Sie [Form‑Sperren](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) für ein [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) (z. B. Verschieben oder Skalieren deaktivieren). Der Sperrmechanismus wird für Formen in einem separaten [Schutz‑Artikel](/slides/de/java/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen, einschließlich [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/), unterstützt.

**Wird die Vektor‑Treue von SVG beim Export einer Präsentation nach PDF/Bilder erhalten?**

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) als ursprünglichen Vektor. Beim [Export nach PDF](/slides/de/java/convert-powerpoint-to-pdf/) oder in [Rasterformate](/slides/de/java/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen gerastert werden; das ursprüngliche SVG bleibt jedoch als Vektor erhalten, was durch das Extraktionsverhalten bestätigt wird.