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
- eingebettetes Bild
- verknüpftes Bild
- Bild extrahieren
- Rasterbild
- SVG-Bild
- Bild zuschneiden
- Beschnittene Bereiche löschen
- Bild komprimieren
- StretchOffset
- Bildrahmen-Formatierung
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erstellen, formatieren, verknüpfen, zuschneiden, extrahieren und komprimieren Sie Bildrahmen in Präsentationen mit Aspose.Slides für Android über Java."
---
## **Übersicht**

Ein Bildrahmen ist eine Folienform, die ein Bild anzeigt. In Aspose.Slides sind die Bildressource und die Form, die sie anzeigt, separate Objekte: eine [Präsentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) verwaltet eingebettete Bildressourcen über ihre [IImageCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimagecollection/), während ein [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) die Position, Größe, Linienformatierung, Drehung, Beschneidung, Bildeffekte und andere rahmenbezogene Einstellungen des Bildes steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehrmals angezeigt wird. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/), und verwenden Sie diese Bildressource beim Erstellen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie Vektor‑SVG‑Bilder enthalten. Sie können zudem auf verknüpfte Bilder verweisen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl wirkt sich auf Portabilität, Dateigröße, Extraktion und Exportverhalten aus, sodass es sinnvoll ist, vor dem Anwenden von Formatierungen oder Optimierungen zu entscheiden, wie das Bild gespeichert werden soll.

## **Einbetten und Formatieren eines eingebetteten Bildes**

Für ein eingebettetes Bild fügen Sie die Bilddaten zur Präsentation hinzu und erstellen Sie einen Bildrahmen mit [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation selbstständig bleibt, wenn sie auf einen anderen Computer verschoben wird.

Das folgende Beispiel fügt ein JPEG‑Bild hinzu, erstellt einen Rahmen mit den nativen Abmessungen des Bildes und wendet Linienformatierung sowie Drehung an:

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

[IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) stellt relative Breiten‑ und Höhen‑Skalierung für den Rahmen über [setRelativeScaleWidth](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) und [setRelativeScaleHeight](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) bereit. Ein Wert von `1.0` entspricht 100 % der Originalgröße des Bildes. Relative Skalierung ist nützlich, wenn ein Workflow das Verhältnis zur Originalbildgröße erhalten soll, anstatt die endgültigen Abmessungen manuell zu berechnen.

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

Relative Skalierung ändert die Skalierungseinstellungen des Rahmens; sie resampelt oder komprimiert das eingebettete Bild nicht.

## **Eingebettete und verknüpfte Bilder**

Ein eingebettetes Bild speichert Bilddaten innerhalb der Präsentation und ist daher die sicherste Wahl für Portabilität und vorhersehbare Darstellung. Ein verknüpftes Bild speichert einen externen Pfad über die Methode [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) anstelle der Einbettung der Bilddaten.

Verknüpfte Bilder können die Menge an Bilddaten im PPTX reduzieren, führen jedoch eine externe Abhängigkeit ein. Die verknüpfte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, erreichbar bleiben. Ändert sich der Pfad, wird die Datei verschoben oder die Ressource ist nicht verfügbar, wird das verknüpfte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail verschickt, archiviert oder in isolierten Umgebungen gerendert werden sollen, sind eingebettete Bilder in der Regel zuverlässiger.

### **Verknüpftes Bild hinzufügen**

Das folgende Beispiel erstellt einen Bildrahmen und verweist auf eine lokale Bilddatei. Es behandelt ausschließlich die Bildverknüpfung; das Verknüpfen von Videos ist ein separater Medien‑Workflow und wird in diesem Beispiel bewusst nicht gemischt.

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

Verwenden Sie Verknüpfungen, wenn die externe Dateiverwaltung beabsichtigt ist. Nutzen Sie sie nicht lediglich als Ersatz für Kompression: ein kleiner PPTX mit defekten Bildabhängigkeiten ist in der Regel weniger nützlich als eine größere, eigenständige Präsentation.

## **Bilder aus Bildrahmen extrahieren**

Bevor Sie ein Bild aus einer bestehenden Präsentation extrahieren, prüfen Sie, ob die Form tatsächlich ein [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) ist und ob sie ein eingebettetes Bild enthält. Verknüpfte Bildrahmen enthalten möglicherweise keine Bildbytes, die auf dieselbe Weise extrahiert werden können.

### **Rasterbild extrahieren**

Die moderne Bild‑API verwendet [IImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/) direkt und erfordert nicht mehr den älteren Java‑Bild‑Wrapper. Das folgende Beispiel findet das erste eingebettete Rasterbild auf einer Folie und speichert es als PNG:

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

Das Speichern über [IImage.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) konvertiert das extrahierte Bild in das gewünschte Ausgabeformat. Wenn Sie die codierten Bytes benötigen, die in der Präsentation gespeichert sind, anstatt einer konvertierten Rasterdatei, verwenden Sie stattdessen die Binärdaten der Bildressource.

### **SVG‑Bild extrahieren**

Für ein SVG‑Bild stellt das [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) ein [ISvgImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgimage/)‑Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, anstatt das Bild zuerst zu rasterisieren.

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

Das Beibehalten von SVG‑Inhalten als SVG bewahrt die Vektor‑Quelle innerhalb der Präsentation. Raster‑Exporte wie PNG oder JPEG rendern diesen Vektorinhalt zwangsläufig zu Pixeln. Der PDF‑ oder SVG‑Folien‑Export ist ebenfalls ein Rendering‑Vorgang, sodass die exportierten Grafiken nicht als exakte Kopie des ursprünglichen eingebetteten SVG behandelt werden sollten; verwenden Sie die Daten von [ISvgImage.getSvgData](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgimage/#getSvgData--) wenn die originale Vektor‑Ressource selbst benötigt wird.

## **Ein Bild zuschneiden**

Das Zuschneiden ändert, welcher Bildteil innerhalb des Rahmens sichtbar ist. Die Zuschneide‑Werte auf [IPictureFillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/) sind Prozentsätze der Quellbild‑Abmessungen. Beim Zuschneiden werden die verborgenen Pixel des eingebetteten Bildes zunächst nicht gelöscht; es wird nur der sichtbare Bereich geändert.

Das folgende Beispiel findet einen Bildrahmen sicher und wendet Zuschneide‑Werte an:

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

Da die verborgenen Bilddaten weiterhin vorhanden sind, kann das Zuschneiden später geändert werden, ohne die Originalpixel zu verlieren. Wenn die Dateigröße wichtiger ist als die Rückgängig‑Möglichkeit, können die beschnittenen Bereiche wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Zugeschnittene Bilddaten entfernen**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) entfernt Bilddaten außerhalb des aktuellen Beschnittrechtecks und gibt die resultierende Bildressource zurück. Dies kann die Dateigröße reduzieren, ist jedoch eine destruktive Optimierung: Nach dem Speichern der Präsentation sind die entfernten Pixel nicht mehr für einen späteren Un‑Crop‑Vorgang verfügbar.

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

Die Methode kann eine neue Bildressource zur Präsentation hinzufügen. Wird das Originalbild auch von anderen Bildrahmen verwendet, benötigen diese weiterhin ihre vorhandene Ressource, sodass das Löschen beschnittener Bereiche nicht zwingend die Gesamtzahl der Bilder verringert. Das Beschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rasterisiert das Ergebnis zu PNG.

## **Rasterbilder komprimieren**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) reduziert die Rasterbild‑Auflösung relativ zur Größe, mit der das Bild angezeigt wird. Es kann außerdem beschnittene Regionen im selben Vorgang entfernen. Die Methode liefert `true`, wenn das Bild verkleinert oder beschnitten wurde, und `false`, wenn keine Änderung erforderlich war.

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

Kompression ist für Rasterbilder gedacht. SVG‑ und Metadatei‑Inhalte werden durch diesen Raster‑Kompressions‑Workflow nicht reduziert. Denken Sie außerdem daran, dass eine niedrigere Auflösung und gelöschte Beschnittbereiche nicht aus der optimierten Präsentation wiederhergestellt werden können. Wählen Sie eine Zielauflösung basierend auf der größten Größe, in der das Bild tatsächlich betrachtet oder exportiert wird, anstatt global die niedrigste DPI zu verwenden.

## **Bildtransformations‑Effekte verwalten**

Für einen vollständigen Workflow, der Helligkeit, Kontrast, Farbtransformationen, Unschärfe, Alpha‑Effekte, geordnete Ketten, Inspektion, Entfernung und Rundreise‑Verifikation abdeckt, siehe [Image Transform Effects](/androidjava/image-transform-effects/).

## **Geometrie des Bildrahmens sperren**

Die Einstellungen von [IPictureFrameLock](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframelock/) steuern, welche Bearbeitungsoperationen für einen Bildrahmen deaktiviert sind. Zum Beispiel bewahrt [setAspectRatioLocked](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) die Proportionen der Form, während sie skaliert wird.

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

Die Sperre gilt für die Bildrahmen‑Form. Sie zwingt das Quellbild nicht, neu gesampelt oder dauerhaft auf dasselbe Seitenverhältnis geändert zu werden.

## **StretchOffset‑Werte anpassen**

Wenn der Bildfüll‑Modus „stretch“ ist, definieren die Stretch‑Offset‑Werte auf [IPictureFillFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/) das Füllrechteck relativ zur Begrenzungsbox des Bildrahmens. Positive Prozentsätze erzeugen einen Einschub von einer Kante, während negative Prozentsätze ein Herausragen erzeugen.

Dies unterscheidet sich vom Zuschneiden. Zuschneide‑Werte bestimmen, welcher Teil des Quellbildes sichtbar ist; Stretch‑Offsets ändern das Rechteck, in das die sichtbare Bildfüllung gestreckt wird.

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

Verwenden Sie Stretch‑Offsets für die Platzierung der Füllung. Nutzen Sie Zuschneide‑Eigenschaften, wenn das Ziel darin besteht, Bildrandbereiche zu verbergen.

## **Speicher, Dateigröße und Exportüberlegungen**

Die wichtigsten Abwägungen lassen sich leichter handhaben, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt betrachtet werden:

- **Eingebettete Bilder** machen die Präsentation eigenständig und sind am zuverlässigsten für das Teilen und serverseitige Rendern, aber große Rasterbilder erhöhen die PPTX‑Größe und den Speicherverbrauch.
- **Verknüpfte Bilder** können das Paket kleiner halten, jedoch hängt die Präsentation von externen Dateien ab, die an den gespeicherten Pfaden oder Standorten verfügbar bleiben müssen.
- **Zuschneiden** ist zunächst nicht destruktiv. Die verborgenen Pixel bleiben eingebettet, bis beschnittene Bereiche explizit gelöscht oder bei der Kompression entfernt werden.
- **Kompression** kann die Dateigröße bei übergroßen Rasterbildern deutlich reduzieren, geht jedoch mit einem Verlust der Quellauflösung einher. Sie sollte erst angewendet werden, wenn die gewünschte Größe auf der Folie bekannt ist.
- **SVG‑Bilder** sollten als SVG erhalten bleiben, wenn die Vektor‑Erhaltung wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektor‑Ressource selbst benötigen. Raster‑Slide‑Exporte wandeln das gerenderte Folienbild immer in Pixel um.
- **Wiederholte Bilder** sollten nach Möglichkeit eine vorhandene [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/)‑Ressource wiederverwenden, anstatt dieselbe Datei mehrfach in den Präsentations‑Workflow zu laden.

Bei großen Präsentationen ist Bildoptimierung in der Regel am effektivsten, wenn sie selektiv durchgeführt wird: Logos und Diagramme als Vektor‑Inhalt behalten, Fotos gemäß ihrer tatsächlichen Anzeigengröße komprimieren, beschnittene Pixel nur entfernen, wenn nachträgliche Bearbeitung nicht erforderlich ist, und externe Verknüpfungen vermeiden, sofern das Abhängigkeits‑Management nicht Teil des Deployments‑Designs ist.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [IPPImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ippimage/) repräsentiert eine Bildressource, die mit der Präsentation verbunden ist. Ein [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) ist eine Form auf einer Folie, die ein Bild anzeigt und rahmenbezogene Geometrie sowie Formatierungen wie Größe, Drehung, Zuschneide‑Werte, Effekte und Sperren speichert.

**Sollte ich Bilder einbetten oder verknüpfen?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verknüpfen Sie Bilder nur, wenn das Auslagern von Bilddateien aus dem PPTX beabsichtigt ist und die externen Speicherorte zuverlässig gepflegt werden können.

**Verringert Zuschneiden die PPTX‑Dateigröße?**

Nicht allein. Normale Zuschneide‑Einstellungen verbergen Teile des Quellbildes, behalten jedoch die zugrunde liegenden Pixel. Verwenden Sie [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) oder Bildkompression mit Entfernung beschnittener Bereiche, wenn diese Pixel dauerhaft verworfen werden können.

**Kann ich die Bildqualität nach der Kompression wiederherstellen?**

Nein. Kompression kann die gespeicherte Rasterauflösung reduzieren, und das Entfernen beschnittener Regionen verwirft Bilddaten. Bewahren Sie das Original‑Quellbild außerhalb der Präsentation auf, falls später eine hochauflösende Bearbeitung erforderlich sein könnte.

**Wie sollten SVG‑Bilder behandelt werden?**

Behalten Sie SVG‑Inhalte als SVG, wenn Vektor‑Treue wichtig ist. Das eingebettete [ISvgImage](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgimage/) kann direkt extrahiert werden. Das Rendern einer Folie in ein Rasterformat wie PNG oder JPEG rasterisiert das SVG als Teil des Folienbildes.

**Wie kann ich unsichere Casts beim Lesen vorhandener Folien vermeiden?**

Überprüfen Sie den Formtyp, bevor Sie bildrahmenspezifische Member verwenden. Ein `instanceof`‑Check gegen [IPictureFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipictureframe/) verhindert ungültige Casts und ermöglicht dem Code, Folien zu behandeln, die keinen Bildrahmen enthalten.