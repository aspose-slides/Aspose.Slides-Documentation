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
- beschnittener Bereich
- StretchOff-Eigenschaft
- Bildrahmenformatierung
- Bildrahmeneigenschaften
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- Bildtransparenz
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Fügen Sie Bildrahmen zu PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Java hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Foliendesign."
---

Ein Bildrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen. 

Sie können einem Folie über einen Bildrahmen ein Bild hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tip" color="primary" %}} 
Aspose bietet kostenlose Konverter –[JPEG zu PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) und [PNG zu PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) – die es ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 
{{% /alert %}} 

## **Bildrahmen erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Holen Sie die Referenz einer Folie über deren Index.  
3. Erstellen Sie ein [IPPImage]()‑Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.  
4. Geben Sie die Breite und Höhe des Bildes an.  
5. Erstellen Sie ein [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame) basierend auf der Bildbreite und -höhe über die Methode `AddPictureFrame`, die vom Formenobjekt der referenzierten Folie bereitgestellt wird.  
6. Fügen Sie der Folie einen Bildrahmen (der das Bild enthält) hinzu.  
7. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie ein Bildrahmen erstellt wird:
```java
// Instanziert die Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();
try {
    // Holt die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziert die Image-Klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Fügt einen Bildrahmen mit der entsprechenden Höhe und Breite des Bildes hinzu
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Speichert die PPTX-Datei auf die Festplatte
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="warning" %}} 
Bildrahmen ermöglichen es, schnell Präsentationsfolien auf Basis von Bildern zu erstellen. Kombiniert man Bildrahmen mit den Speicheroptionen von Aspose.Slides, kann man Ein‑ und Ausgangsoperationen manipulieren, um Bilder von einem Format in ein anderes zu konvertieren. Weitere Seiten können Sie hier einsehen: Bild zu [JPG konvertieren](https://products.aspose.com/slides/java/conversion/image-to-jpg/); [JPG zu Bild konvertieren](https://products.aspose.com/slides/java/conversion/jpg-to-image/); [JPG zu PNG konvertieren](https://products.aspose.com/slides/java/conversion/jpg-to-png/), [PNG zu JPG konvertieren](https://products.aspose.com/slides/java/conversion/png-to-jpg/); [PNG zu SVG konvertieren](https://products.aspose.com/slides/java/conversion/png-to-svg/), [SVG zu PNG konvertieren](https://products.aspose.com/slides/java/conversion/svg-to-png/). 
{{% /alert %}}

## **Bildrahmen mit relativer Skalierung erstellen**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erstellen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Holen Sie die Referenz einer Folie über deren Index.  
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.  
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.  
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.  
6. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie ein Bildrahmen mit relativer Skalierung erstellt wird:
```java
// Instanziert die Presentation-Klasse, die die PPTX repräsentiert
Presentation pres = new Presentation();
try {
    // Holt die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziert die Image-Klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Fügt einen Bildrahmen mit Höhe und Breite des Bildes hinzu
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Setzt relative Skalierung von Breite und Höhe
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Speichert die PPTX-Datei auf die Festplatte
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Rasterbilder aus Bildrahmen extrahieren**

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/PictureFrame)-Objekten extrahieren und sie im PNG‑, JPG‑ oder anderen Formaten speichern. Das nachfolgende Codebeispiel demonstriert, wie ein Bild aus dem Dokument „sample.pptx“ extrahiert und im PNG‑Format gespeichert wird.
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

Enthält eine Präsentation SVG‑Grafiken, die in [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/)-Formen eingebettet sind, ermöglicht Aspose.Slides for Java das Abrufen der ursprünglichen Vektor‑Bilder mit voller Treue. Durch Durchlaufen der Formsammlung der Folie können Sie jedes [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) identifizieren, prüfen, ob das zugrunde liegende [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) SVG‑Inhalt enthält, und das Bild dann im nativen SVG‑Format speichern.

Das folgende Codebeispiel demonstriert das Extrahieren eines SVG‑Bildes aus einem Bildrahmen:
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

Aspose.Slides ermöglicht das Abrufen des auf ein Bild angewendeten Transparenzeffekts. Dieser Java‑Code demonstriert die Vorgehensweise:
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

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen so anpassen, dass er spezifischen Anforderungen entspricht.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).  
2. Holen Sie die Referenz einer Folie über deren Index.  
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/IPPImage)-Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) hinzufügen, die dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.  
4. Geben Sie die Breite und Höhe des Bildes an.  
5. Erstellen Sie ein `PictureFrame` basierend auf der Bildbreite und -höhe über die Methode [AddPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) des [IShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection)-Objekts, das mit der referenzierten Folie verknüpft ist.  
6. Fügen Sie der Folie den Bildrahmen (mit dem Bild) hinzu.  
7. Setzen Sie die Linienfarbe des Bildrahmens.  
8. Setzen Sie die Linienstärke des Bildrahmens.  
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.  
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn.  
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.  
10. Fügen Sie den Bildrahmen (mit dem Bild) erneut zur Folie hinzu.  
11. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.

Dieser Java‑Code demonstriert den Bildrahmen‑Formatierungsprozess:
```java
// Instanziert die Presentation-Klasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holt die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziert die Image-Klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Fügt einen Bildrahmen mit Höhe und Breite des Bildes hinzu
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
Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/collage) entwickelt. Wenn Sie jemals [JPG/JPEG](https://products.aspose.app/slides/collage/jpg) oder PNG‑Bilder zusammenführen oder [Raster aus Fotos erstellen](https://products.aspose.app/slides/collage/photo-grid) müssen, können Sie diesen Dienst nutzen. 
{{% /alert %}}

## **Ein Bild als Link hinzufügen**

Um die Dateigröße von Präsentationen gering zu halten, können Sie Bilder (oder Videos) über Links einbinden, anstatt die Dateien direkt in die Präsentation zu integrieren. Dieser Java‑Code zeigt, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:
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
// Erstellt ein neues Bildobjekt
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt der Folie einen Bildrahmen hinzu
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Schneidet das Bild zu (Prozentwerte)
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


## **Zugeschnittene Bildbereiche löschen**

Wenn Sie zugeschnittene Bildbereiche in einem Rahmen löschen möchten, können Sie die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) verwenden. Diese Methode gibt das zugeschnittene Bild oder das Originalbild zurück, falls kein Zuschneiden nötig ist.

Dieser Java‑Code demonstriert die Vorgehensweise:
```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Holt das PictureFrame von der ersten Folie
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Löscht zugeschnittene Bereiche des PictureFrame-Bildes und gibt das zugeschnittene Bild zurück
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Speichert das Ergebnis
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
Die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) fügt das zugeschnittene Bild zur Bildsammlung der Präsentation hinzu. Wenn das Bild ausschließlich im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) verwendet wird, kann diese Vorgehensweise die Dateigröße reduzieren. Andernfalls erhöht sich die Bildanzahl in der resultierenden Präsentation.

Während des Zuschneidevorgangs werden WMF/EMF‑Metadateien in ein Raster‑PNG‑Bild konvertiert. 
{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, selbst wenn Sie die Bildabmessungen ändern, können Sie die Methode [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) verwenden, um die Einstellung *Lock Aspect Ratio* zu aktivieren.

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

    // Form so einstellen, dass das Seitenverhältnis beim Skalieren erhalten bleibt
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="NOTE" color="warning" %}} 
Diese Einstellung *Lock Aspect Ratio* bewahrt nur das Seitenverhältnis der Form, nicht jedoch das des darin enthaltenen Bildes. 
{{% /alert %}}

## **StretchOff‑Eigenschaft verwenden**

Durch die Verwendung der Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) und [StretchOffsetBottom](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) des Interfaces [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) sowie der Klasse [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/IPictureFillFormat) können Sie ein Füllrechteck festlegen. 

Wird ein Bild gestreckt, wird ein Quellrechteck so skaliert, dass es in das angegebene Füllrechteck passt. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz bedeutet „Einziehen“, ein negativer Prozentsatz „Ausdehnen“. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentatio)‑Klasse.  
2. Holen Sie die Referenz einer Folie über deren Index.  
3. Fügen Sie ein Rechteck `AutoShape` hinzu.  
4. Erstellen Sie ein Bild.  
5. Setzen Sie den Fülltyp der Form.  
6. Setzen Sie den Bildfüllmodus der Form.  
7. Fügen Sie ein Bild zum Ausfüllen der Form hinzu.  
8. Geben Sie Bildversätze relativ zu den entsprechenden Kanten der Begrenzungsbox der Form an.  
9. Schreiben Sie die modifizierte Präsentation als PPTX‑Datei.  

Dieser Java‑Code demonstriert einen Prozess, bei dem die StretchOff‑Eigenschaft verwendet wird:
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

    // Fügt eine AutoShape vom Typ Rechteck hinzu
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Setzt den Fülltyp der Form
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Setzt den Bildfüllmodus der Form
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Setzt das Bild, um die Form zu füllen
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Gibt die Bildversätze relativ zu den entsprechenden Kanten der Begrenzungsbox der Form an
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

**Wie finde ich heraus, welche Bildformate für PictureFrame unterstützt werden?**  
Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) zugewiesen wird. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

**Wie wirkt sich das Hinzufügen von Dutzenden großer Bilder auf die PPTX‑Größe und Performance aus?**  
Das Einbetten großer Bilder erhöht Dateigröße und Speicherverbrauch; das Verlinken von Bildern hält die Präsentationsgröße klein, benötigt jedoch, dass die externen Dateien weiterhin verfügbar sind. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

**Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?**  
Verwenden Sie [Form‑Sperren](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) für einen [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) (z. B. Verschieben oder Größenändern deaktivieren). Der Sperrmechanismus wird für Formen in einem separaten [Schutz‑Artikel](/slides/de/java/applying-protection-to-presentation/) beschrieben und wird für verschiedene Formtypen, einschließlich [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/), unterstützt.

**Wird die Vektor‑Treue von SVG beim Export einer Präsentation zu PDF/Bildern erhalten?**  
Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe/) als Originalvektor. Beim Export zu PDF (/slides/de/java/convert-powerpoint-to-pdf/) oder zu Rasterformaten (/slides/de/java/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen rasterisiert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert ist, wird durch das Extraktionsverhalten bestätigt.