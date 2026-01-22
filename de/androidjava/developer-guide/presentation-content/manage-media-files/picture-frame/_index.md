---
title: Verwalten von Bildrahmen in Präsentationen auf Android
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/androidjava/picture-frame/
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
- Zugeschnittener Bereich
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
- Android
- Java
- Aspose.Slides
description: "Fügen Sie PowerPoint- und OpenDocument-Präsentationen Bildrahmen mit Aspose.Slides für Android via Java hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design von Folien."
---

Ein Bildrahmen ist eine Form, die ein Bild enthält – es ist wie ein Bild in einem Rahmen. 

Sie können ein Bild über einen Bildrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tip" color="primary" %}} 
Aspose bietet kostenlose Konverter –[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) – die es ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 
{{% /alert %}} 

## **Bildrahmen erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Erstellen Sie ein [IPPImage]()‑Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.  
4. Geben Sie die Breite und Höhe des Bildes an.  
5. Erstellen Sie ein [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame) basierend auf der Breite und Höhe des Bildes über die `AddPictureFrame`‑Methode, die vom Formobjekt der referenzierten Folie bereitgestellt wird.  
6. Fügen Sie der Folie einen Bildrahmen (der das Bild enthält) hinzu.  
7. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.  

Dieser Java‑Code zeigt, wie Sie einen Bildrahmen erstellen:
```java
// Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Ruft die erste Folie ab
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziiert die Image-Klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Fügt einen Bildrahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Bildrahmen mit relativer Skalierung erstellen**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erstellen.  

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.  
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)‑Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.  
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.  
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.  

Dieser Java‑Code zeigt, wie Sie einen Bildrahmen mit relativer Skalierung erstellen:
```java
// Instanziiere die Presentation-Klasse, die das PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Hole die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziiere die Image-Klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Füge einen Bildrahmen mit Höhe und Breite entsprechend dem Bild hinzu
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Setze relative Skalierung für Breite und Höhe
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Schreibe die PPTX-Datei auf die Festplatte
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PictureFrame)‑Objekten extrahieren und sie im PNG-, JPG- und anderen Formaten speichern. Das folgende Beispiel demonstriert, wie Sie ein Bild aus dem Dokument "sample.pptx" extrahieren und im PNG‑Format speichern.
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

Wenn eine Präsentation SVG‑Grafiken enthält, die in [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/)‑Formen platziert sind, ermöglicht Aspose.Slides für Android via Java das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Durch Durchlaufen der Formsammlung der Folie können Sie jedes [PictureFrame] identifizieren, prüfen, ob das zugrunde liegende [IPPImage] SVG‑Inhalt enthält, und das Bild dann auf Datenträger oder in einen Stream im nativen SVG‑Format speichern.

Das folgende Codebeispiel demonstriert, wie Sie ein SVG‑Bild aus einem Bildrahmen extrahieren:
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


## **Transparenz eines Bildes ermitteln**

Aspose.Slides ermöglicht das Ermitteln des auf ein Bild angewendeten Transparenzeffekts. Dieser Java‑Code demonstriert den Vorgang:
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


## **Bildrahmenformatierung**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen anpassen, um bestimmte Anforderungen zu erfüllen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPPImage)‑Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.  
4. Geben Sie die Breite und Höhe des Bildes an.  
5. Erstellen Sie ein `PictureFrame` basierend auf der Breite und Höhe des Bildes über die [AddPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)‑Methode, die vom [IShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection)‑Objekt der referenzierten Folie bereitgestellt wird.  
6. Fügen Sie den Bildrahmen (der das Bild enthält) der Folie hinzu.  
7. Setzen Sie die Linienfarbe des Bildrahmens.  
8. Setzen Sie die Linienbreite des Bildrahmens.  
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.  
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn.  
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.  
10. Fügen Sie den Bildrahmen (der das Bild enthält) der Folie hinzu.  
11. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.  

Dieser Java‑Code demonstriert den Bildrahmenformatierungsprozess:
```java
// Instanziert die Presentation-Klasse, die das PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Ruft die erste Folie ab
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziert die Image-Klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Fügt einen Bildrahmen mit Höhe und Breite entsprechend dem Bild hinzu
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


{{% alert title="Tip" color="primary" %}}
Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie jemals [JPG/JPEG](https://products.aspose.app/slides/collage/jpg) oder PNG‑Bilder zusammenführen, [Raster aus Fotos erstellen](https://products.aspose.app/slides/collage/photo-grid) benötigen, können Sie diesen Dienst nutzen. 
{{% /alert %}}

## **Ein Bild als Link hinzufügen**

Um große Präsentationsdateien zu vermeiden, können Sie Bilder (oder Videos) über Links hinzufügen, anstatt die Dateien direkt in die Präsentation einzubetten. Dieser Java‑Code zeigt, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:
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


## **Bilder zuschneiden**

Dieser Java‑Code zeigt, wie Sie ein vorhandenes Bild auf einer Folie zuschneiden:
```java
Presentation pres = new Presentation();
// Erzeugt ein neues Bildobjekt
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt einen Bildrahmen zu einer Folie hinzu
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Zuschneiden des Bildes (Prozentwerte)
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


## **Zugeschnittene Bereiche eines Bildes löschen**

Wenn Sie die zugeschnittenen Bereiche eines in einem Rahmen enthaltenen Bildes löschen möchten, können Sie die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) verwenden. Diese Methode gibt das zugeschnittene Bild oder das Originalbild zurück, falls kein Zuschnitt erforderlich ist.

Dieser Java‑Code demonstriert den Vorgang:
```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Holt den Bildrahmen von der ersten Folie
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Löscht zugeschnittene Bereiche des Bildrahmen-Bildes und gibt das zugeschnittene Bild zurück
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Speichert das Ergebnis
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
Die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) fügt das zugeschnittene Bild der Bildsammlung der Präsentation hinzu. Wenn das Bild nur im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) verwendet wird, kann diese Vorgehensweise die Präsentationsgröße reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Diese Methode konvertiert WMF/EMF‑Metadateien während des Zuschnitts in Raster‑PNG‑Bilder. 
{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, selbst wenn Sie die Bildabmessungen ändern, können Sie die Methode [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) verwenden, um die Einstellung *Seitenverhältnis sperren* zu aktivieren.

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

    // Form so festlegen, dass das Seitenverhältnis beim Ändern der Größe beibehalten wird
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
Diese Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form, nicht jedoch das des enthaltenen Bildes. 
{{% /alert %}}

## **Verwendung der StretchOff‑Eigenschaft**

Durch die Verwendung der Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) und [StretchOffsetBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) des [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat)‑Interfaces und der [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPictureFillFormat)‑Klasse können Sie ein Füllrechteck festlegen.

Wenn ein Stretch für ein Bild angegeben wird, wird ein Quellrechteck skaliert, um in das festgelegte Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz bedeutet einen Einzug, ein negativer Prozentsatz einen Ausbruch.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.  
2. Rufen Sie die Referenz einer Folie über deren Index ab.  
3. Fügen Sie ein Rechteck `AutoShape` hinzu.  
4. Erstellen Sie ein Bild.  
5. Legen Sie den Fülltyp der Form fest.  
6. Legen Sie den Bildfüllmodus der Form fest.  
7. Fügen Sie ein Bild hinzu, um die Form zu füllen.  
8. Geben Sie Bildversätze von der entsprechenden Kante der Begrenzungsbox der Form an.  
9. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.  

Dieser Java‑Code demonstriert einen Prozess, bei dem die StretchOff‑Eigenschaft verwendet wird:
```java
// Instanziert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Ruft die erste Folie ab
    ISlide slide = pres.getSlides().get_Item(0);

    // Instanziert die ImageEx-Klasse
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt eine AutoShape vom Typ Rectangle hinzu
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Setzt den Fülltyp der Form
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Setzt den Bildfüllmodus der Form
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Setzt das Bild, das die Form füllt
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Gibt die Bildversätze von den entsprechenden Kanten der Begrenzungsbox der Form an
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    //Schreibt die PPTX-Datei auf die Festplatte
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Wie kann ich herausfinden, welche Bildformate für PictureFrame unterstützt werden?**

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen von Dutzenden großer Bilder auf die PPTX‑Größe und -Leistung aus?**

Das Einbetten großer Bilder erhöht die Dateigröße und den Speicherverbrauch; das Verlinken von Bildern hilft, die Präsentationsgröße gering zu halten, erfordert jedoch, dass die externen Dateien zugänglich bleiben. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?**

Verwenden Sie [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) für einen [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) (z. B. zum Deaktivieren von Verschieben oder Größenändern). Der Sperrmechanismus wird für verschiedene Formtypen unterstützt, einschließlich [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/).

**Wird die Vektor‑Treue von SVG bei der Exportierung einer Präsentation in PDF/Bilder beibehalten?**

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe/) als das ursprüngliche Vektorbild. Beim [Exportieren zu PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/) oder zu [Rasterformaten](/slides/de/androidjava/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen rasterisiert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert ist, wird durch das Extraktionsverhalten bestätigt.