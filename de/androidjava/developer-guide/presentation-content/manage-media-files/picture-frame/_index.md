---
title: Verwalten von Bildrahmen in Präsentationen unter Android
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/androidjava/picture-frame/
keywords:
- Bildrahmen
- Bildrahmen hinzufügen
- Bildrahmen erstellen
- eingebettetes Bild
- verlinktes Bild
- Bild extrahieren
- Rasterbild
- SVG-Bild
- Bild zuschneiden
- Beschnittene Bereiche löschen
- Bild komprimieren
- StretchOffset
- Bildrahmenformatierung
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen, formatieren, verlinken, zuschneiden, extrahieren und komprimieren von Bildrahmen in Präsentationen mit Aspose.Slides für Android über Java."
---
## **Übersicht**

Ein Bildrahmen ist eine Folienform, die ein Bild anzeigt. In Aspose.Slides sind die Bildressource und die Form, die das Bild anzeigt, separate Objekte: ein [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) besitzt eingebettete Bildressourcen über seine [IImageCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagecollection/), während ein [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) die Position, Größe, Linienformatierung, Drehung, Beschneidung, Bildeffekte und andere rahmenbezogene Einstellungen des Bildes steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehrmals angezeigt werden soll. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) und verwenden Sie diese Bildressource beim Erzeugen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie Vektor‑SVG‑Bilder enthalten. Sie können zudem auf verlinkte Bilder verweisen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl wirkt sich auf Portabilität, Dateigröße, Extraktion und Exportverhalten aus, sodass es sinnvoll ist, vor dem Anwenden von Formatierungen oder Optimierungen zu entscheiden, wie das Bild gespeichert werden soll.

## **Ein eingebettetes Bild hinzufügen und formatieren**

Für ein eingebettetes Bild fügen Sie die Bilddaten der Präsentation hinzu und erstellen einen Bildrahmen mit [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation selbständig bleibt, wenn sie auf einen anderen Computer verschoben wird.

Das folgende Beispiel fügt ein JPEG‑Bild hinzu, erstellt einen Rahmen in den nativen Abmessungen des Bildes und wendet Linienformatierung und Drehung an:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Bildrahmen steuert die angezeigte Geometrie; das Ändern der Rahmen‑Größe ändert nicht die ursprünglichen Pixelabmessungen, die in der eingebetteten Bildressource gespeichert sind. Diese Unterscheidung wird wichtig, wenn das Bild später beschnitten oder komprimiert wird.

## **Relative Skalierung verwenden**

[IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) stellt die relative Breiten‑ und Höhen‑Skalierung für den Rahmen über [setRelativeScaleWidth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) und [setRelativeScaleHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) bereit. Ein Wert von `1.0` entspricht 100 % der ursprünglichen Bildgröße. Relative Skalierung ist nützlich, wenn ein Workflow die Beziehung zur Quellbildgröße erhalten soll, anstatt die Endabmessungen manuell zu berechnen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Relative Skalierung ändert die Skalierungseinstellungen des Rahmens; sie führt nicht zu einer Resampling‑ oder Komprimierung des eingebetteten Bildes.

## **Eingebettete und verlinkte Bilder**

Ein eingebettetes Bild speichert Bilddaten innerhalb der Präsentation und ist daher die sicherste Wahl für Portabilität und vorhersehbare Darstellung. Ein verlinktes Bild speichert einen externen Pfad über die Methode [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) anstelle der Einbettung der Bilddaten.

Verlinkte Bilder können die Menge an Bilddaten im PPTX reduzieren, führen jedoch eine externe Abhängigkeit ein. Die verlinkte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, zugänglich bleiben. Ändert sich der Pfad, wird die Datei verschoben oder steht die Ressource nicht mehr zur Verfügung, wird das verlinkte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail verschickt, archiviert oder in isolierten Umgebungen gerendert werden sollen, sind eingebettete Bilder in der Regel zuverlässiger.

### **Ein verlinktes Bild hinzufügen**

Das folgende Beispiel erstellt einen Bildrahmen und verweist auf eine lokale Bilddatei. Es beschäftigt sich ausschließlich mit dem Bild‑Linking; Video‑Linking ist ein separater Medien‑Workflow und wird hier bewusst nicht gemischt.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verwenden Sie Links, wenn ein externer Dateimanagement‑Ansatz beabsichtigt ist. Nutzen Sie sie nicht einfach als Ersatz für Kompression: ein kleiner PPTX mit defekten Bildabhängigkeiten ist meist weniger brauchbar als eine größere, in sich geschlossene Präsentation.

## **Bilder aus Bildrahmen extrahieren**

Bevor Sie ein Bild aus einer bestehenden Präsentation extrahieren, prüfen Sie, ob eine Form tatsächlich ein [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) ist und ob sie ein eingebettetes Bild enthält. Verlinkte Bildrahmen enthalten möglicherweise keine Bildbytes, die auf dieselbe Weise extrahiert werden können.

### **Ein Rasterbild extrahieren**

Die moderne Bild‑API verwendet [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/) direkt und erfordert nicht mehr den veralteten Java‑Wrapper. Das folgende Beispiel findet das erste eingebettete Rasterbild auf einer Folie und speichert es als PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Das Speichern über [IImage.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) konvertiert das extrahierte Bild in das gewünschte Ausgabeformat. Wenn Sie die im Präsentations‑Container gespeicherten kodierten Bytes benötigen, verwenden Sie stattdessen die binären Daten der Bildressource.

### **Ein SVG‑Bild extrahieren**

Für ein SVG‑Bild stellt das [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) ein [ISvgImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgimage/)‑Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, ohne das Bild zuerst zu rasterisieren.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Das Beibehalten des SVG‑Inhalts als SVG bewahrt die Vektorquelle innerhalb der Präsentation. Rasterexporte wie PNG oder JPEG rendern diesen Vektorinhalt zwangsläufig zu Pixeln. PDF‑ oder SVG‑Folienexporte sind ebenfalls Rendering‑Operationen, sodass die exportierten Grafiken nicht als exakte Kopie des eingebetteten SVG betrachtet werden sollten; verwenden Sie die eingebetteten [ISvgImage.getSvgData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgimage/#getSvgData--)‑Daten, wenn die ursprüngliche Vektorressource selbst benötigt wird.

## **Ein Bild beschneiden**

Das Beschneiden verändert, welcher Bildteil im Rahmen sichtbar ist. Die Beschneidungswerte auf [IPictureFillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/) sind Prozentsätze der Quellbildabmessungen. Beim Beschneiden werden die verborgenen Pixel des eingebetteten Bildes zunächst nicht gelöscht; es wird lediglich der sichtbare Bereich geändert.

Das folgende Beispiel findet sicher einen Bildrahmen und wendet Beschneidungswerte an:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Da die versteckten Bilddaten weiterhin vorhanden sind, kann das Beschneiden später geändert werden, ohne die Originalpixel zu verlieren. Wenn die Dateigröße wichtiger ist als die Wiederherstellbarkeit, können die beschnittenen Bereiche wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Beschnittene Bilddaten entfernen**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) entfernt Bilddaten außerhalb des aktuellen Beschneidungsrechtecks und gibt die resultierende Bildressource zurück. Das kann die Dateigröße reduzieren, ist jedoch eine destruktive Optimierung: Nach dem Speichern der Präsentation stehen die entfernten Pixel nicht mehr für ein späteres „Uncrop“ zur Verfügung.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Die Methode kann eine neue Bildressource zur Präsentation hinzufügen. Wenn das Originalbild zudem von anderen Bildrahmen verwendet wird, benötigen diese weiterhin ihre bestehende Ressource, sodass das Löschen beschnittener Bereiche nicht zwangsläufig die Gesamtzahl der Bilder reduziert. Das Beschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rasterisiert das beschnittene Ergebnis zu PNG.

## **Rasterbilder komprimieren**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) reduziert die Auflösung von Rasterbildern relativ zu der Größe, in der das Bild angezeigt wird. Gleichzeitig kann es beschnittene Regionen entfernen. Die Methode gibt `true` zurück, wenn das Bild verkleinert oder beschnitten wurde, und `false`, wenn keine Änderung erforderlich war.

Verwenden Sie einen vordefinierten [PicturesCompression](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/picturescompression/)‑Wert, wenn eine Standard‑Zielauflösung ausreicht:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ein benutzerdefinierter positiver DPI‑Wert kann anstelle eines vordefinierten Werts übergeben werden, wenn ein spezifisches Ziel erforderlich ist.

Kompression ist für Rasterbilder gedacht. SVG‑ und Metadatei‑Inhalte werden durch diesen Raster‑Kompressions‑Workflow nicht reduziert. Denken Sie zudem daran, dass eine niedrigere Auflösung und gelöschte beschnittene Bereiche nicht aus der optimierten Präsentation wiederhergestellt werden können. Wählen Sie eine Zielauflösung basierend auf der größten Anzeige‑ oder Exportgröße, bei der das Bild tatsächlich betrachtet wird, anstatt global die niedrigste DPI zu verwenden.

## **Bildeffekte untersuchen**

Bildeffekte werden auf dem Bild gespeichert, das vom Rahmen verwendet wird. Die Bild‑Transformations‑Sammlung kann Effekte wie feste Alpha‑Modulation für Transparenz und Luminanz für Helligkeit und Kontrast enthalten. Das folgende Beispiel liest sicher beide Arten von Effekten vom ersten Bildrahmen einer Folie:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Diese Effekte verändern, wie das Bild im Rahmen gerendert wird; sie überschreiben nicht die ursprünglichen eingebetteten Bildbytes.

## **Geometrie des Bildrahmens sperren**

Die Einstellungen von [IPictureFrameLock](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframelock/) kontrollieren, welche Bearbeitungsoperationen für einen Bildrahmen deaktiviert sind. Beispielsweise bewahrt [setAspectRatioLocked](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) die Proportionen der Form, während sie skaliert wird.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Sperre gilt für die Bildrahmen‑Form. Sie zwingt das Quellbild nicht zu einem Resampling oder zu einer permanenten Änderung des Seitenverhältnisses.

## **StretchOffset‑Werte anpassen**

Wenn der Bildfüll‑Modus „stretch“ ist, definieren die stretch‑offset‑Werte auf [IPictureFillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/) das Füllrechteck relativ zur Begrenzungsbox des Bildrahmens. Positive Prozentsätze erzeugen einen Einschub von einer Kante, während negative Prozentsätze ein Herausstehen bewirken.

Das unterscheidet sich vom Beschneiden. Beschneidungswerte wählen, welcher Teil des Quellbilds sichtbar ist; stretch‑Offsets verändern das Rechteck, in das die sichtbare Bildfüllung gestreckt wird.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verwenden Sie stretch‑Offsets für die Platzierung der Füllung. Verwenden Sie Beschneidungseigenschaften, wenn das Ziel ist, Bildrandbereiche zu verbergen.

## **Speicherung, Dateigröße und Export‑Überlegungen**

Die wichtigsten Kompromisse lassen sich leichter managen, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt betrachtet werden:

- **Eingebettete Bilder** machen die Präsentation eigenständig und sind am zuverlässigsten für das Teilen und serverseitige Rendering, aber große Rasterbilder vergrößern die PPTX‑Größe und den Speicherverbrauch.
- **Verlinkte Bilder** können das Paket schlanker halten, aber die Präsentation ist von externen Dateien abhängig, die unter den gespeicherten Pfaden verfügbar bleiben müssen.
- **Beschneiden** ist zunächst nicht‑destruktiv. Die verborgenen Pixel bleiben eingebettet, bis beschnittene Bereiche explizit gelöscht oder während der Kompression entfernt werden.
- **Kompression** kann die Dateigröße bei zu großen Rasterbildern erheblich reduzieren, geht jedoch zulasten der Quellauflösung. Sie sollte erst nach Festlegung der gewünschten Anzeigegröße auf der Folie angewendet werden.
- **SVG‑Bilder** sollten als SVG erhalten bleiben, wenn die Vektorpreservation wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektor‑Ressource selbst benötigen. Raster‑Folienexporte konvertieren die gerenderte Folie immer zu Pixeln.
- **Wiederholte Bilder** sollten nach Möglichkeit eine vorhandene [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/)‑Ressource wiederverwenden, anstatt dieselbe Datei mehrfach in den Präsentations‑Workflow zu laden.

Bei großen Präsentationen ist eine gezielte Bildoptimierung meist am effektivsten: Logos und Diagramme als Vektor‑Inhalt behalten, Fotos gemäß ihrer tatsächlichen Anzeigengröße komprimieren, beschnittene Pixel nur entfernen, wenn nachträgliche Bearbeitung nicht mehr nötig ist, und externe Links nur einsetzen, wenn das Abhängigkeits‑Management Teil des Bereitstellungs‑Designs ist.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) stellt eine Bildressource dar, die mit der Präsentation verknüpft ist. Ein [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) ist eine Form auf einer Folie, die ein Bild anzeigt und rahmenbezogene Geometrie sowie Formatierung wie Größe, Drehung, Beschneidungswerte, Effekte und Sperren speichert.

**Sollte ich Bilder einbetten oder verlinken?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verlinken Sie Bilder nur, wenn das Auslagern der Bilddateien aus der PPTX beabsichtigt ist und die externen Speicherorte zuverlässig verwaltet werden können.

**Reduziert Beschneiden die PPTX‑Dateigröße?**

Nicht von selbst. Normale Beschneidungseinstellungen verbergen Bildteile, behalten aber die zugrunde liegenden Pixel. Verwenden Sie [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) oder Bildkompression mit Entfernung beschnittener Bereiche, wenn diese Pixel dauerhaft verworfen werden können.

**Kann ich die Bildqualität nach der Kompression wiederherstellen?**

Nein. Die Kompression kann die gespeicherte Rasterauflösung reduzieren, und das Entfernen beschnittener Regionen verwirft Bilddaten. Halten Sie das ursprüngliche Quellbild außerhalb der Präsentation, falls später eine hochauflösende Bearbeitung nötig sein könnte.

**Wie sollten SVG‑Bilder behandelt werden?**

Bewahren Sie SVG‑Inhalte als SVG auf, wenn die Vektorreproduzierbarkeit wichtig ist. Das eingebettete [ISvgImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgimage/) kann direkt extrahiert werden. Das Rendern einer Folie zu einem Rasterformat wie PNG oder JPEG rasterisiert das SVG als Teil des Folien‑Bildes.

**Wie kann ich unsichere Casts beim Lesen vorhandener Folien vermeiden?**

Überprüfen Sie den Formtyp, bevor Sie bild‑rahmenspezifische Member verwenden. Ein `instanceof`‑Check gegen [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) verhindert ungültige Casts und ermöglicht dem Code, Folien zu behandeln, die keinen Bildrahmen enthalten.