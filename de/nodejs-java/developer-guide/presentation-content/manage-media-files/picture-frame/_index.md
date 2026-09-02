---
title: Bildrahmen in Präsentationen mit JavaScript verwalten
linktitle: Bildrahmen
type: docs
weight: 10
url: /de/nodejs-java/picture-frame/
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
- beschnittene Bereiche löschen
- Bild komprimieren
- StretchOffset
- Bildrahmen-Formatierung
- relative Skalierung
- Bildeffekt
- Seitenverhältnis
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erstellen, formatieren, verknüpfen, zuschneiden, extrahieren und komprimieren Sie Bildrahmen in Präsentationen mit Aspose.Slides für Node.js über Java."
---
## **Übersicht**

Ein Bildrahmen ist eine Folienform, die ein Bild anzeigt. In Aspose.Slides sind die Bildressource und die Form, die sie anzeigt, separate Objekte: eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) besitzt eingebettete Bildressourcen über ihre [ImageCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagecollection/), während ein [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) die Position, Größe, Linienformatierung, Drehung, Beschnitt, Bildeffekte und weitere rahmenbezogene Einstellungen des Bildes steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehr als einmal angezeigt wird. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) und verwenden Sie diese Bildressource beim Erstellen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie Vektor‑SVG‑Bilder enthalten. Sie können außerdem auf verknüpfte Bilder verweisen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl beeinflusst Portabilität, Dateigröße, Extraktion und Exportverhalten, daher ist es sinnvoll, vor der Formatierung oder Optimierung zu entscheiden, wie das Bild gespeichert werden soll.

## **Ein eingebettetes Bild hinzufügen und formatieren**

Für ein eingebettetes Bild fügen Sie die Bilddaten der Präsentation hinzu und erstellen einen Bildrahmen mit [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation selbständig bleibt, wenn sie auf einen anderen Computer verschoben wird.

Das folgende Beispiel fügt ein PNG‑Bild hinzu, erstellt einen Rahmen in den originalen Bildabmessungen und wendet Linienformatierung sowie Drehung an:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Bildrahmen steuert die angezeigte Geometrie; das Ändern der Rahmen­größe ändert nicht die ursprünglichen Pixelabmessungen, die in der eingebetteten Bildressource gespeichert sind. Diese Unterscheidung wird wichtig, wenn das Bild später beschnitten oder komprimiert wird.

## **Relative Skalierung verwenden**

[PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) stellt über [setRelativeScaleWidth](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) und [setRelativeScaleHeight](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) relative Breiten‑ bzw. Höhen‑Skalierung für den Rahmen bereit. Ein Wert von `1.0` entspricht 100 % der Originalgröße des Bildes. Relative Skalierung ist nützlich, wenn ein Workflow die Beziehung zur Quellbildgröße beibehalten muss, anstatt die endgültigen Abmessungen manuell zu berechnen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Relative Skalierung ändert die Skalierungseinstellungen des Rahmens; sie resampelt oder komprimiert das eingebettete Bild nicht.

## **Eingebettete und verknüpfte Bilder**

Ein eingebettetes Bild speichert die Bilddaten innerhalb der Präsentation und ist damit die sicherste Wahl für Portabilität und vorhersehbare Wiedergabe. Ein verknüpftes Bild speichert über die Methode [Picture.setLinkPathLong](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) einen externen Pfad, anstatt die Bilddaten einzubetten.

Verknüpfte Bilder können die Menge an Bilddaten im PPTX reduzieren, führen jedoch eine externe Abhängigkeit ein. Die verknüpfte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, erreichbar bleiben. Ändert sich der Pfad, wird die Datei verschoben oder ist die Ressource nicht verfügbar, wird das verknüpfte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail versendet, archiviert oder in isolierten Umgebungen gerendert werden, sind eingebettete Bilder in der Regel zuverlässiger.

### **Ein verknüpftes Bild hinzufügen**

Das folgende Beispiel erstellt einen Bildrahmen und verweist auf eine lokale Bilddatei. Es behandelt ausschließlich Bildverknüpfungen; Video‑Verknüpfungen sind ein separater Medien‑Workflow und werden hier bewusst nicht gemischt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verwenden Sie Verknüpfungen, wenn das externe Dateimanagement beabsichtigt ist. Verwenden Sie sie nicht lediglich als Ersatz für Kompression: ein kleiner PPTX mit kaputten Bildabhängigkeiten ist in der Regel weniger nützlich als eine größere, selbstständige Präsentation.

## **Bilder aus Bildrahmen extrahieren**

Bevor Sie ein Bild aus einer vorhandenen Präsentation extrahieren, prüfen Sie, ob eine Form tatsächlich ein [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) ist und ein eingebettetes Bild enthält. Verknüpfte Bildrahmen enthalten möglicherweise keine Bildbytes, die auf dieselbe Weise extrahiert werden können.

### **Ein Rasterbild extrahieren**

Die moderne Bild‑API verwendet [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/) direkt. Das folgende Beispiel findet das erste eingebettete Rasterbild auf einer Folie und speichert es als PNG:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Das Speichern über [IImage.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/#save) konvertiert das extrahierte Bild in das gewünschte Ausgabeformat. Wenn Sie die im Präsentationspaket gespeicherten kodierten Bytes benötigen, verwenden Sie stattdessen die Binärdaten der Bildressource.

### **Ein SVG‑Bild extrahieren**

Für ein SVG‑Bild stellt das [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) ein [SvgImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/)‑Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, anstatt das Bild zuerst zu rasterisieren.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

Das Beibehalten von SVG‑Inhalt als SVG bewahrt die Vektorquelle innerhalb der Präsentation. Raster‑Exporte wie PNG oder JPEG rendern den Vektorinhalt notwendigerweise zu Pixeln. PDF‑ oder SVG‑Folienexporte sind ebenfalls Rendering‑Operationen, sodass die exportierten Grafiken nicht als exakte Kopie des ursprünglichen eingebetteten SVG behandelt werden sollten; verwenden Sie die Daten aus [SvgImage.getSvgData](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/#getSvgData--) wenn die ursprüngliche Vektorressource selbst benötigt wird.

## **Ein Bild zuschneiden**

Der Zuschnitt ändert, welcher Teil eines Bildes im Rahmen sichtbar ist. Die Zuschneidewerte auf [PictureFillFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/) sind Prozentsätze der Quellbildabmessungen. Der Zuschnitt löscht die ausgeblendeten Pixel des eingebetteten Bildes zunächst nicht; er ändert nur den sichtbaren Bereich.

Das folgende Beispiel findet sicher einen Bildrahmen und wendet Zuschneidewerte an:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Da die ausgeblendeten Bilddaten weiterhin vorhanden sind, kann der Zuschnitt später geändert werden, ohne die Originalpixel zu verlieren. Wenn die Dateigröße wichtiger ist als die Wiederherstellbarkeit, können die beschnittenen Bereiche wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Beschnittene Bilddaten entfernen**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) entfernt Bilddaten außerhalb des aktuellen Zuschnittsrechtecks und liefert die resultierende Bildressource zurück. Das kann die Dateigröße reduzieren, ist aber eine destruktive Optimierung: Nach dem Speichern der Präsentation stehen die entfernten Pixel für ein späteres „Un‑Crop“ nicht mehr zur Verfügung.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Die Methode kann eine neue Bildressource zur Präsentation hinzufügen. Wenn das ursprüngliche Bild auch von anderen Bildrahmen verwendet wird, benötigen diese weiterhin ihre bestehende Ressource, sodass das Löschen beschnittener Bereiche nicht zwangsläufig die Gesamtzahl der Bilder reduziert. Das Zuschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rasterisiert das Ergebnis zu PNG.

## **Rasterbilder komprimieren**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) reduziert die Auflösung von Rasterbildern relativ zur Größe, in der das Bild angezeigt wird. Gleichzeitig können beschnittene Bereiche entfernt werden. Die Methode gibt `true` zurück, wenn das Bild skaliert oder beschnitten wurde, und `false`, wenn keine Änderung erforderlich war.

Verwenden Sie einen vordefinierten [PicturesCompression](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturescompression/)‑Wert, wenn eine Standard‑Zielauflösung ausreicht:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ein benutzerdefinierter positiver DPI‑Wert kann anstelle eines vordefinierten Werts übergeben werden, wenn ein spezifisches Ziel erforderlich ist.

Kompression ist für Rasterbilder gedacht. SVG‑ und Metadatei‑Inhalte werden durch diesen Raster‑Kompressions‑Workflow nicht reduziert. Denken Sie auch daran, dass niedrigere Auflösung und gelöschte beschnittene Bereiche nicht aus der optimierten Präsentation wiederhergestellt werden können. Wählen Sie eine Zielauflösung basierend auf der größten Größe, in der das Bild tatsächlich betrachtet oder exportiert wird, anstatt global die niedrigste DPI anzuwenden.

## **Bild‑Transformations‑Effekte verwalten**

Für einen vollständigen Workflow zu Helligkeit, Kontrast, Farb‑Transformationen, Unschärfe, Alpha‑Effekten, geordneten Ketten, Inspektion, Entfernung und Rundreise‑Verifikation siehe [Image Transform Effects](/nodejs-java/image-transform-effects/).

## **Geometrie des Bildrahmens sperren**

Die [PictureFrameLock](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframelock/)‑Einstellungen bestimmen, welche Bearbeitungsoperationen für einen Bildrahmen deaktiviert sind. Beispielsweise bewahrt [setAspectRatioLocked](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) die Proportionen der Form, während sie skaliert wird.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Sperrung gilt für die Bildrahmen‑Form. Sie zwingt das Quellbild nicht dazu, resampelt zu werden oder dauerhaft das gleiche Seitenverhältnis anzunehmen.

## **StretchOffset‑Werte anpassen**

Wenn der Bildfüllmodus „stretch“ ist, definieren die Stretch‑Offset‑Werte auf [PictureFillFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/) das Füllrechteck relativ zur Begrenzungsbox des Bildrahmens. Positive Prozentsätze erzeugen ein Inset von einer Kante, während negative Prozentsätze ein Outset erzeugen.

Dies unterscheidet sich vom Zuschneiden. Zuschneidewerte bestimmen, welcher Teil des Quellbildes sichtbar ist; Stretch‑Offsets ändern das Rechteck, in das die sichtbare Bildfüllung gedehnt wird.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Verwenden Sie Stretch‑Offsets für die Platzierung der Füllung. Verwenden Sie Zuschneide‑Eigenschaften, wenn das Ziel darin besteht, Kanten des Quellbildes zu verbergen.

## **Speicher, Dateigröße und Export‑Überlegungen**

Die wichtigsten Abwägungen lassen sich leichter managen, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt behandelt werden:

- **Eingebettete Bilder** machen die Präsentation selbstständig und sind am zuverlässigsten für das Teilen und serverseitige Rendern, aber große Rasterbilder erhöhen die PPTX‑Größe und den Speicherverbrauch.
- **Verknüpfte Bilder** können das Paket kleiner halten, jedoch hängt die Präsentation von externen Dateien ab, die an den gespeicherten Pfaden oder Orten verfügbar bleiben müssen.
- **Zuschneiden** ist zunächst nicht destruktiv. Die versteckten Pixel bleiben eingebettet, bis beschnittene Bereiche ausdrücklich gelöscht oder während der Kompression entfernt werden.
- **Kompression** kann die Dateigröße bei übergroßen Rasterbildern erheblich reduzieren, kostet jedoch die Quellauflösung. Sie sollte angewendet werden, nachdem die beabsichtigte Größe auf der Folie bekannt ist.
- **SVG‑Bilder** sollten als SVG erhalten bleiben, wenn die Vektor‑Erhaltung wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektor‑Ressource selbst benötigen. Raster‑Folienexporte konvertieren immer die gerenderte Folie zu Pixeln.
- **Wiederholte Bilder** sollten nach Möglichkeit eine vorhandene [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/)‑Ressource wiederverwenden, anstatt dieselbe Datei mehrfach in den Präsentations‑Workflow zu laden.

Bei großen Präsentationen ist die Bildoptimierung meist am effektivsten, wenn sie selektiv durchgeführt wird: Logos und Diagramme als Vektor‑Inhalt behalten, Fotos gemäß ihrer tatsächlichen Anzeigengröße komprimieren, beschnittene Pixel nur entfernen, wenn spätere Bearbeitung nicht nötig ist, und externe Links nur verwenden, wenn das Abhängigkeits‑Management Teil des Bereitstellungs‑Designs ist.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) stellt eine Bildressource dar, die mit der Präsentation verknüpft ist. Ein [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) ist eine Form auf einer Folie, die ein Bild anzeigt und rahmenbezogene Geometrie sowie Formatierungen wie Größe, Drehung, Zuschneidewerte, Effekte und Sperren speichert.

**Soll ich Bilder einbetten oder verknüpfen?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verknüpfen Sie Bilder nur, wenn das Auslagern der Bilddateien aus der PPTX bewusst ist und die externen Speicherorte zuverlässig verwaltet werden können.

**Reduziert Zuschneiden die PPTX‑Dateigröße?**

Nicht allein. Normale Zuschneide‑Einstellungen verbergen Teile des Quellbildes, behalten jedoch die zugrunde liegenden Pixel. Verwenden Sie [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) oder Bildkompression mit Entfernung beschnittener Bereiche, wenn diese Pixel dauerhaft verworfen werden können.

**Kann ich die Bildqualität nach einer Kompression wiederherstellen?**

Nein. Kompression kann die gespeicherte Rasterauflösung reduzieren, und das Entfernen beschnittener Regionen verwirft Bilddaten. Bewahren Sie das ursprüngliche Quellbild außerhalb der Präsentation auf, falls später hochauflösende Bearbeitungen erforderlich sein könnten.

**Wie sollten SVG‑Bilder behandelt werden?**

Behalten Sie SVG‑Inhalt als SVG, wenn die Vektortreue wichtig ist. Das eingebettete [SvgImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/) kann direkt extrahiert werden. Das Rendern einer Folie in ein Rasterformat wie PNG oder JPEG rasterisiert das SVG als Teil des Folienbildes.

**Wie kann ich unsichere Casts beim Lesen vorhandener Folien vermeiden?**

Prüfen Sie den Formtyp, bevor Sie bildrahmenspezifische Member verwenden. Ein `java.instanceOf`‑Check gegen [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) verhindert ungültige Casts und ermöglicht es dem Code, Folien zu behandeln, die keinen Bildrahmen enthalten.