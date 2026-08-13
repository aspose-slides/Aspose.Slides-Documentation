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
- Vektorbilder
- Bild zuschneiden
- Zugeschnittener Bereich
- StretchOff-Eigenschaft
- Bildrahmen-Formatierung
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
description: "Fügen Sie Bildrahmen zu PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Android via Java hinzu. Optimieren Sie Ihren Arbeitsablauf und verbessern Sie das Design von Folien."
---
## **Einleitung**

Ein Bildrahmen ist eine Form, die ein Bild enthält – er ist wie ein Bild in einem Rahmen.

Sie können ein Bild über einen Bildrahmen zu einer Folie hinzufügen. Auf diese Weise können Sie das Bild formatieren, indem Sie den Bildrahmen formatieren.

{{% alert  title="Tipp" color="info" %}} 
Aspose bietet kostenlose Konverter—[JPEG nach PowerPoint](https://products.aspose.app/slides/de/import/jpg-to-ppt) und [PNG nach PowerPoint](https://products.aspose.app/slides/de/import/png-to-ppt)—an, die es ermöglichen, schnell Präsentationen aus Bildern zu erstellen. 
{{% /alert %}} 

## **Bildrahmen erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation).
2. Holen Sie eine Referenz auf die Folie über ihren Index. 
3. Erstellen Sie ein [IPPImage]()‑Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IImageCollection) hinzufügen, das dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie ein [PictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/PictureFrame) basierend auf der Breite und Höhe des Bildes, über die Methode `AddPictureFrame`, die vom Form‑Objekt bereitgestellt wird, das mit der referenzierten Folie verknüpft ist.
6. Fügen Sie der Folie einen Bildrahmen (der das Bild enthält) hinzu.
7. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie einen Bildrahmen erstellen:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instanziiert die Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();
try {
    // Holt die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziiert die Image-Klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Fügt einen Bildrahmen mit der gleichen Höhe und Breite des Bildes hinzu
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Speichert die PPTX-Datei auf dem Datenträger
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bildrahmen mit relativer Skalierung erstellen**

Durch Ändern der relativen Skalierung eines Bildes können Sie einen komplexeren Bildrahmen erstellen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation).
2. Holen Sie eine Referenz auf die Folie über ihren Index. 
3. Fügen Sie ein Bild zur Bildsammlung der Präsentation hinzu.
4. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPPImage)‑Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IImageCollection) hinzufügen, das dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
5. Geben Sie die relative Breite und Höhe des Bildes im Bildrahmen an.
6. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code zeigt, wie Sie einen Bildrahmen mit relativer Skalierung erstellen:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instanziiert die Presentation-Klasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holt die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziiert die Image-Klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Fügt einen Bildrahmen mit gleicher Höhe und Breite des Bildes hinzu
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

Sie können Rasterbilder aus [PictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/PictureFrame)‑Objekten extrahieren und in PNG, JPG und anderen Formaten speichern. Das nachfolgende Codebeispiel demonstriert, wie Sie ein Bild aus dem Dokument „sample.pptx“ extrahieren und im PNG‑Format speichern.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
        try {
            slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
        } finally {
            if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}

```

## **SVG‑Bilder aus Bildrahmen extrahieren**

Wenn eine Präsentation SVG‑Grafiken enthält, die in [PictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pictureframe/)‑Formen platziert sind, ermöglicht Aspose.Slides für Android via Java das Abrufen der ursprünglichen Vektorbilder mit voller Treue. Sobald Sie ein [PictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pictureframe/) besitzen, dessen [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) SVG‑Inhalt enthält, können Sie dieses SVG‑Bild einlesen und im nativen SVG‑Format auf Datenträger oder in einen Stream speichern.

Das folgende Codebeispiel demonstriert, wie Sie ein SVG‑Bild aus einem Bildrahmen extrahieren:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

## **Transparenz eines Bildes abrufen**

Aspose.Slides ermöglicht das Abrufen des auf ein Bild angewendeten Transparenzeffekts. Dieser Java‑Code demonstriert die Vorgehensweise:

```java
import com.aspose.slides.*;

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

## **Helligkeit und Kontrast eines Bildes abrufen**

Aspose.Slides ermöglicht das Abrufen des Helligkeits‑ und Kontrasteffekts, der auf ein Bild angewendet wird. Das Interface [ILuminance](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iluminance/) stellt diesen Bildtransformations‑Effekt dar.

Dieser Java‑Code zeigt, wie Sie die Helligkeits‑ und Kontrasteinstellungen eines Bildrahmens abfragen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Bildrahmen formatieren**

Aspose.Slides bietet zahlreiche Formatierungsoptionen, die auf einen Bildrahmen angewendet werden können. Mit diesen Optionen können Sie einen Bildrahmen so anpassen, dass er bestimmte Anforderungen erfüllt.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation).
2. Holen Sie eine Referenz auf die Folie über ihren Index. 
3. Erstellen Sie ein [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPPImage)‑Objekt, indem Sie ein Bild zur [IImagescollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IImageCollection) hinzufügen, das dem Präsentationsobjekt zugeordnet ist und zum Füllen der Form verwendet wird.
4. Geben Sie die Breite und Höhe des Bildes an.
5. Erstellen Sie ein `PictureFrame` basierend auf der Breite und Höhe des Bildes über die Methode [AddPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) des [IShapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IShapeCollection)-Objekts, das mit der referenzierten Folie verknüpft ist.
6. Fügen Sie der Folie den Bildrahmen (der das Bild enthält) hinzu.
7. Setzen Sie die Rahmenfarbe des Bildrahmens.
8. Setzen Sie die Rahmenbreite des Bildrahmens.
9. Drehen Sie den Bildrahmen, indem Sie ihm einen positiven oder negativen Wert zuweisen.  
   * Ein positiver Wert dreht das Bild im Uhrzeigersinn.  
   * Ein negativer Wert dreht das Bild gegen den Uhrzeigersinn.
10. Fügen Sie den Bildrahmen (der das Bild enthält) erneut zur Folie hinzu.
11. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code demonstriert den Bildrahmen‑Formatierungsprozess:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;

// Instanziert die Presentation-Klasse, die die PPTX darstellt
Presentation pres = new Presentation();
try {
    // Holt die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Instanziert die Image-Klasse
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Fügt einen Bildrahmen mit gleicher Höhe und Breite des Bildes hinzu
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

{{% alert title="Tipp" color="info" %}}
Aspose hat kürzlich einen [kostenlosen Collage Maker](https://products.aspose.app/slides/de/collage) entwickelt. Wenn Sie jemals JPG/JPEG‑ oder PNG‑Bilder zusammenführen oder Raster aus Fotos erstellen möchten, können Sie diesen Dienst nutzen. 
{{% /alert %}}

## **Ein Bild als Link hinzufügen**

Um große Präsentationsdateien zu vermeiden, können Sie Bilder (oder Videos) über Links einbinden, anstatt die Dateien direkt in die Präsentation zu integrieren. Dieser Java‑Code zeigt, wie Sie ein Bild und ein Video in einen Platzhalter einfügen:

```java
import com.aspose.slides.*;
import java.util.ArrayList;

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
import com.aspose.slides.*;

Presentation pres = new Presentation();
// Erstellt ein neues Bildobjekt
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Fügt einen Bildrahmen zu einer Folie hinzu
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Schneidet das Bild zu (Prozentwerte)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Speichert das Ergebnis
    pres.save("cropped_image.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zugeschnittene Bereiche eines Bildes löschen**

Wenn Sie die zugeschnittenen Bereiche eines Bildes, das in einem Rahmen enthalten ist, löschen möchten, können Sie die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) verwenden. Die Methode gibt das zugeschnittene Bild zurück oder das ursprüngliche Bild, falls kein Zuschneiden nötig ist.

Dieser Java‑Code demonstriert die Vorgehensweise:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Holt den PictureFrame von der ersten Folie
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Löscht zugeschnittene Bereiche des PictureFrame‑Bildes und gibt das zugeschnittene Bild zurück
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Speichert das Ergebnis
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="Hinweis" color="warning" %}} 
Die Methode [deletePictureCroppedAreas()](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) fügt das zugeschnittene Bild zur Bildsammlung der Präsentation hinzu. Wird das Bild nur im verarbeiteten [PictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pictureframe/) verwendet, kann diese Vorgehensweise die Präsentationsgröße reduzieren. Andernfalls erhöht sich die Anzahl der Bilder in der resultierenden Präsentation.

Die Methode wandelt WMF/EMF‑Metadateien während des Zuschneidevorgangs in ein Raster‑PNG‑Bild um. 
{{% /alert %}}

## **Bilder komprimieren**

Sie können ein Bild in einer Präsentation mit der Methode [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) komprimieren. Diese Methode reduziert die Bildgröße basierend auf der Formgröße und einer angegebenen Auflösung, mit der Option, zugeschnittene Bereiche zu löschen.

Sie passt Größe und Auflösung des Bildes ähnlich der PowerPoint‑Funktion **Bildformat > Bilder komprimieren > Auflösung** an.

Die folgenden Java‑Beispiele zeigen, wie Sie ein Bild in einer Präsentation komprimieren, indem Sie eine Zielauflösung angeben und optional zugeschnittene Bereiche entfernen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Komprimiert das Bild mit einer Zielauflösung von 150 DPI (Web-Auflösung) und entfernt zugeschnittene Bereiche.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Überprüft das Ergebnis der Komprimierung.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Oder indem Sie direkt einen benutzerdefinierten DPI‑Wert verwenden:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Komprimiert das Bild auf 150 DPI (Web-Auflösung) und entfernt zugeschnittene Bereiche.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Hinweis" color="warning" %}} 
Die Methode konvertiert das Bild basierend auf der Formgröße und dem angegebenen DPI zu einer niedrigeren Auflösung. Zuge‑schneiderte Regionen können ebenfalls gelöscht werden, um die Dateigröße zu optimieren.  
Wird das Bild als Metadatei (WMF/EMF) oder SVG bereitgestellt, wird keine Kompression angewendet. Außerdem wird die JPEG‑Qualität je nach Auflösung erhalten oder leicht reduziert, ähnlich wie PowerPoint bei hochauflösenden JPEGs.
{{% /alert %}}

## **Seitenverhältnis sperren**

Wenn Sie möchten, dass eine Form, die ein Bild enthält, ihr Seitenverhältnis beibehält, selbst wenn Sie die Bildabmessungen ändern, können Sie die Methode [setAspectRatioLocked](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) verwenden, um die Einstellung *Lock Aspect Ratio* zu setzen.

Dieser Java‑Code zeigt, wie Sie das Seitenverhältnis einer Form sperren:

```java
import com.aspose.slides.*;

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
            ShapeType.Rectangle, 50, 150, picture.getWidth(), picture.getHeight(), picture);

    // Form so einstellen, dass das Seitenverhältnis beim Skalieren beibehalten wird
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Hinweis" color="warning" %}} 
Diese *Lock Aspect Ratio*‑Einstellung bewahrt nur das Seitenverhältnis der Form, nicht jedoch das des darin enthaltenen Bildes.
{{% /alert %}}

## **Die StretchOff‑Eigenschaft verwenden**

Mit den Eigenschaften [StretchOffsetLeft](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) und [StretchOffsetBottom](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) des Interfaces [IPictureFillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPictureFillFormat) und der Klasse [PictureFillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IPictureFillFormat) können Sie ein Füllrechteck angeben.

Wird das Strecken für ein Bild festgelegt, wird ein Quellrechteck skaliert, um in das angegebene Füllrechteck zu passen. Jede Kante des Füllrechtecks wird durch einen prozentualen Versatz von der entsprechenden Kante der Begrenzungsbox der Form definiert. Ein positiver Prozentsatz gibt einen Einzug an, ein negativer Prozentsatz einen Auszug.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation)-Klasse.
2. Holen Sie eine Referenz auf die Folie über ihren Index.
3. Fügen Sie ein Rechteck `AutoShape` hinzu. 
4. Erstellen Sie ein Bild.
5. Legen Sie den Fülltyp der Form fest.
6. Legen Sie den Bildfüllmodus der Form fest.
7. Fügen Sie ein Bild zum Füllen der Form hinzu.
8. Geben Sie Bildversätze von der entsprechenden Kante der Begrenzungsbox der Form an.
9. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Java‑Code demonstriert einen Vorgang, bei dem die StretchOff‑Eigenschaft verwendet wird:

```java
import com.aspose.slides.*;

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

    // Fügt eine AutoShape vom Typ Rectangle hinzu
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Setzt den Fülltyp der Form
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Setzt den Bildfüllmodus der Form
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Setzt das Bild, das die Form füllen soll
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Gibt die Bildversätze von der entsprechenden Kante der Begrenzungsbox der Form an
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);

    // Schreibt die PPTX-Datei auf die Festplatte
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Wie kann ich herausfinden, welche Bildformate für PictureFrame unterstützt werden?

Aspose.Slides unterstützt sowohl Rasterbilder (PNG, JPEG, BMP, GIF usw.) als auch Vektorbilder (z. B. SVG) über das Bildobjekt, das einem [PictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pictureframe/) zugewiesen ist. Die Liste der unterstützten Formate überschneidet sich im Allgemeinen mit den Fähigkeiten der Folien‑ und Bildkonvertierungs‑Engine.

### Wie wirkt sich das Hinzufügen von Dutzenden großer Bilder auf die PPTX‑Größe und -Leistung aus?

Das Einbetten großer Bilder erhöht Dateigröße und Speicherverbrauch; das Verlinken von Bildern hält die Präsentationsgröße klein, erfordert jedoch, dass die externen Dateien weiterhin erreichbar sind. Aspose.Slides bietet die Möglichkeit, Bilder per Link hinzuzufügen, um die Dateigröße zu reduzieren.

### Wie kann ich ein Bildobjekt vor versehentlichem Verschieben/Größenändern schützen?

Verwenden Sie [Form‑Sperren](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) für einen [PictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pictureframe/) (z. B. Verschieben oder Größenänderung deaktivieren). Der Sperrmechanismus wird für verschiedene Formtypen unterstützt, einschließlich [PictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pictureframe/).

### Wird die Vektor‑Treue von SVG beim Export einer Präsentation in PDF/Bilder erhalten?

Aspose.Slides ermöglicht das Extrahieren eines SVG aus einem [PictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/pictureframe/) als ursprünglichen Vektor. Beim [Exportieren nach PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/) oder in [Rasterformate](/slides/de/androidjava/convert-powerpoint-to-png/) kann das Ergebnis je nach Exporteinstellungen rasterisiert werden; die Tatsache, dass das ursprüngliche SVG als Vektor gespeichert ist, wird durch das Extraktionsverhalten bestätigt.