---
title: Bilderrahmen
type: docs
weight: 10
url: /java/picture-frame/
keywords: "Bilderrahmen hinzufügen, Bilderrahmen erstellen, Bild hinzufügen, Bild erstellen, Bild extrahieren, StretchOff-Eigenschaft, Bilderrahmenformatierung, Bilderrahmeneigenschaften, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Fügen Sie der PowerPoint-Präsentation in Java einen Bilderrahmen hinzu"

---

Ein Bilderrahmen ist eine Form, die ein Bild enthält - es ist wie ein Bild in einem Rahmen.

Sie können ein Bild über einen Bilderrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild durch die Formatierung des Bilderrahmens formatieren.

{{% alert  title="Tipp" color="primary" %}} 

Aspose bietet kostenlose Konverter—[JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—die es ermöglichen, Präsentationen schnell aus Bildern zu erstellen.

{{% /alert %}} 

## **Bilderrahmen erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Erstellen Sie ein [IPPImage]() Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist, das verwendet wird, um die Form auszufüllen.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) basierend auf der Breite und Höhe des Bildes durch die Methode `AddPictureFrame`, die vom Formobjekt, das mit der referenzierten Folie verknüpft ist, bereitgestellt wird.
6. Fügen Sie der Folie einen Bilderrahmen (der das Bild enthält) hinzu.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Bilderrahmen erstellen:

```java
// Instanziiert die Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziiert die Bildklasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Fügt einen Bilderrahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Bilderrahmen ermöglichen es Ihnen, Präsentationsfolien schnell basierend auf Bildern zu erstellen. Wenn Sie den Bilderrahmen mit den Speicheroptionen von Aspose.Slides kombinieren, können Sie Eingabe-/Ausgabeoperationen manipulieren, um Bilder von einem Format in ein anderes zu konvertieren. Sie möchten vielleicht diese Seiten sehen: konvertieren [Bild zu JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); konvertieren [JPG zu Bild](https://products.aspose.com/slides/java/conversion/jpg-to-image/); konvertieren [JPG zu PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), konvertieren [PNG zu JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); konvertieren [PNG zu SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), konvertieren [SVG zu PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

## **Bilderrahmen mit relativem Maßstab erstellen**

Durch Ändern des relativen Maßstabs eines Bildes können Sie einen komplizierteren Bilderrahmen erstellen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Fügen Sie ein Bild zur Bildersammlung der Präsentation hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist, das verwendet wird, um die Form auszufüllen.
5. Geben Sie die relative Breite und Höhe des Bildes im Bilderrahmen an.
6. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code zeigt Ihnen, wie Sie einen Bilderrahmen mit relativem Maßstab erstellen:

```java
// Instanziert die Präsentationsklasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holt sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziiert die Bildklasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Fügt einen Bilderrahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Setzt den relativen Maßstab für Breite und Höhe
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bild aus Bilderrahmen extrahieren**

Sie können Bilder aus [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) Objekten extrahieren und sie im PNG-, JPG- und anderen Formaten speichern. Das folgende Codebeispiel zeigt, wie man ein Bild aus dem Dokument "sample.pptx" extrahiert und im PNG-Format speichert.

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

## **Transparenz eines Bildes erhalten**

Aspose.Slides ermöglicht es Ihnen, die Transparenz eines Bildes zu erhalten. Dieser Java-Code zeigt den Vorgang:

```java
Presentation presentation = new Presentation(folderPath + "Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Bildtransparenz: " + transparencyValue);
    }
}
```

## **Bilderrahmenformatierung**

Aspose.Slides bietet viele Formatierungsoptionen, die auf einen Bilderrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bilderrahmen ändern, um bestimmte Anforderungen zu erfüllen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage) Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) hinzufügen, die mit dem Präsentationsobjekt verknüpft ist, das verwendet wird, um die Form auszufüllen.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie einen `PictureFrame` basierend auf der Breite und Höhe des Bildes durch die Methode [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) die vom [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection) Objekt bereitgestellt wird, das mit der referenzierten Folie verknüpft ist.
6. Fügen Sie der Folie den Bilderrahmen (der das Bild enthält) hinzu.
7. Setzen Sie die Linienfarbe des Bilderrahmens.
8. Setzen Sie die Linienbreite des Bilderrahmens.
9. Drehen Sie den Bilderrahmen, indem Sie einen positiven oder negativen Wert angeben.
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn. 
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.
10. Fügen Sie der Folie den Bilderrahmen (der das Bild enthält) hinzu.
11. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code demonstriert den Formatierungsprozess des Bilderrahmens:

```java
// Instanziiert die Präsentationsklasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holt sich die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziiert die Bildklasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Fügt einen Bilderrahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
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

{{% alert title="Tipp" color="primary" %}}

Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie jemals [JPG/JPEG](https://products.aspose.app/slides/collage/jpg) oder PNG-Bilder zusammenfügen, [Raster aus Fotos erstellen](https://products.aspose.app/slides/collage/photo-grid) müssen, können Sie diesen Dienst verwenden.

{{% /alert %}}

## **Bild als Link hinzufügen**

Um große Präsentationsgrößen zu vermeiden, können Sie Bilder (oder Videos) über Links hinzufügen, anstatt die Dateien direkt in die Präsentationen einzubetten. Dieser Java-Code zeigt Ihnen, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:

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

Dieser Java-Code zeigt Ihnen, wie Sie ein vorhandenes Bild auf einer Folie zuschneiden:

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

    // Fügt einen Bilderrahmen zu einer Folie hinzu
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Schneidet das Bild (Prozentwerte)
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

## **Zugeschnittene Bereiche des Bildes löschen**

Wenn Sie die zugeschnittenen Bereiche eines Bildes, das in einem Rahmen enthalten ist, löschen möchten, können Sie die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) verwenden. Diese Methode gibt das zugeschnittene Bild oder das Originalbild zurück, wenn das Zuschneiden nicht notwendig ist.

Dieser Java-Code demonstriert den Vorgang:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Holt sich den Bilderrahmen von der ersten Folie
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Löscht die zugeschnittenen Bereiche des Bildes aus dem Bilderrahmen und gibt das zugeschnittene Bild zurück
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Speichert das Ergebnis
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="HINWEIS" color="warning" %}} 

Die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) fügt das zugeschnittene Bild der Bildersammlung der Präsentation hinzu. Wenn das Bild nur im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) verwendet wird, kann diese Einstellung die Präsentationsgröße reduzieren. Andernfalls wird die Anzahl der Bilder in der resultierenden Präsentation erhöht.

Diese Methode konvertiert WMF/EMF-Metafile in Raster-PNG-Bilder im Zuschneidevorgang.

{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, auch nachdem Sie die Dimensionen des Bildes geändert haben, können Sie die Methode [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) verwenden, um die Einstellung *Seitenverhältnis sperren* festzulegen.

Dieser Java-Code zeigt Ihnen, wie Sie das Seitenverhältnis einer Form sperren:

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

    // Setzt die Form so, dass das Seitenverhältnis beim Ändern der Größe beibehalten wird
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="HINWEIS" color="warning" %}} 

Diese Einstellung *Seitenverhältnis sperren* bewahrt nur das Seitenverhältnis der Form und nicht des darin enthaltenen Bildes.

{{% /alert %}}

## **StretchOff-Eigenschaft verwenden**

Durch die Verwendung der Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) und [StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) von der [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) Schnittstelle und der [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) Klasse können Sie ein Füllrechteck angeben.

Wenn das Strecken für ein Bild angegeben wird, wird ein Quellrechteck skaliert, um in das angegebene Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante des Begrenzungsrahmens der Form definiert. Ein positiver Prozentsatz gibt einen Abstand nach innen an, während ein negativer Prozentsatz einen Abstand nach außen angibt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentatio) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie eine Rechteck `AutoShape` hinzu. 
4. Erstellen Sie ein Bild.
5. Legen Sie den Fülltyp der Form fest.
6. Legen Sie den Bildfüllmodus der Form fest.
7. Fügen Sie ein festgelegtes Bild zur Füllung der Form hinzu.
8. Geben Sie die Bildversätze von der entsprechenden Kante des Begrenzungsrahmens der Form an.
9. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser Java-Code demonstriert einen Prozess, in dem eine StretchOff-Eigenschaft verwendet wird:

```java
// Instanziiert die Präsentationsklasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Holt sich die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Instanziiert die Bildklasse
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt ein AutoShape hinzu, das auf Rechteck gesetzt ist
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Legt den Fülltyp der Form fest
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Legt den Bildfüllmodus der Form fest
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Legt das Bild fest, um die Form auszufüllen
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Gibt die Bildversätze von der entsprechenden Kante des Begrenzungsrahmens der Form an
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