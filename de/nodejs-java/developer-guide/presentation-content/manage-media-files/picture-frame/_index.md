---
title: Verwalten von Bildrahmen in Präsentationen mit JavaScript
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
- Zugeschnittene Bereiche löschen
- Bild komprimieren
- StretchOffset
- Bildrahmenformatierung
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

Ein Bildrahmen ist ein Folien‑Shape, das ein Bild anzeigt. In Aspose.Slides sind die Bildressource und das Shape, das sie anzeigt, separate Objekte: Eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) besitzt eingebettete Bildressourcen über ihre [ImageCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagecollection/), während ein [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) die Position, Größe, Linienformatierung, Drehung, Beschnitt, Bildeffekte und andere rahmenbezogene Einstellungen des Bildes steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehrmals angezeigt wird. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/), und verwenden Sie diese Bildressource beim Erstellen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie Vektor‑SVG‑Bilder enthalten. Sie können außerdem auf verknüpfte Bilder verweisen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl wirkt sich auf Portabilität, Dateigröße, Extraktion und Exportverhalten aus, daher ist es sinnvoll, vor der Anwendung von Formatierungen oder Optimierungen zu entscheiden, wie das Bild gespeichert werden soll.

## **Einbetten und Formatieren eines Bildes**

Für ein eingebettetes Bild fügen Sie die Bilddaten der Präsentation hinzu und erstellen Sie einen Bildrahmen mit [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation beim Verschieben auf einen anderen Computer eigenständig bleibt.

Das folgende Beispiel fügt ein PNG‑Bild hinzu, erstellt einen Rahmen mit den nativen Abmessungen des Bildes und wendet Linienformatierung und Drehung an:

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

Der Bildrahmen steuert die angezeigte Geometrie; das Ändern der Rahmengröße verändert nicht die ursprünglichen Pixelabmessungen, die in der eingebetteten Bildressource gespeichert sind. Diese Unterscheidung wird wichtig, wenn ein Bild später beschnitten oder komprimiert wird.

## **Relative Skalierung verwenden**

[PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) stellt über [setRelativeScaleWidth](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) und [setRelativeScaleHeight](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) die relative Breiten‑ und Höhenskalierung für den Rahmen bereit. Ein Wert von `1.0` entspricht 100 % der ursprünglichen Bildgröße. Relative Skalierung ist nützlich, wenn ein Workflow die Beziehung zur Ausgangsbildgröße beibehalten muss, anstatt die endgültigen Abmessungen manuell zu berechnen.

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

Ein eingebettetes Bild speichert Bilddaten innerhalb der Präsentation und ist daher die sicherste Wahl für Portabilität und vorhersehbare Darstellung. Ein verknüpftes Bild speichert einen externen Speicherort über die Methode [Picture.setLinkPathLong](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) anstatt die Bilddaten einzubetten.

Verknüpfte Bilder können die Menge an Bilddaten im PPTX reduzieren, führen jedoch eine externe Abhängigkeit ein. Die verknüpfte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, zugänglich bleiben. Ändert sich der Pfad, wird die Datei verschoben oder die Ressource ist nicht verfügbar, wird das verknüpfte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail versendet, archiviert oder in isolierten Umgebungen gerendert werden müssen, sind eingebettete Bilder in der Regel zuverlässiger.

### **Ein verknüpftes Bild hinzufügen**

Das folgende Beispiel erstellt einen Bildrahmen und verweist ihn auf eine lokale Bilddatei. Es behandelt ausschließlich das Verknüpfen von Bildern; das Verknüpfen von Videos ist ein separater Medien‑Workflow und wurde bewusst nicht mit diesem Beispiel vermischt.

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

Verwenden Sie Links, wenn die externe Dateiverwaltung beabsichtigt ist. Nutzen Sie sie nicht lediglich als Ersatz für Kompression: ein kleines PPTX mit defekten Bildabhängigkeiten ist in der Regel weniger nützlich als eine größere, eigenständige Präsentation.

## **Bilder aus Bildrahmen extrahieren**

Bevor Sie ein Bild aus einer bestehenden Präsentation extrahieren, prüfen Sie, ob ein Shape tatsächlich ein [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) ist und ein eingebettetes Bild enthält. Verknüpfte Bildrahmen enthalten möglicherweise keine Bildbytes, die auf dieselbe Weise extrahiert werden können.

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

Das Speichern über [IImage.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/#save) konvertiert das extrahierte Bild in das gewünschte Ausgabeformat. Wenn Sie die im Präsentationspaket gespeicherten kodierten Bytes benötigen und nicht eine konvertierte Rasterdatei, verwenden Sie stattdessen die Binärdaten der Bildressource.

### **Ein SVG‑Bild extrahieren**

Für ein SVG‑Bild stellt das [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) ein [SvgImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/)-Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, anstatt das Bild zuerst zu rasterisieren.

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

Das Beibehalten von SVG‑Inhalt als SVG bewahrt die Vektorquelle innerhalb der Präsentation. Rasterexporte wie PNG oder JPEG rendern diesen Vektorinhalt notwendigerweise in Pixel. PDF‑ oder SVG‑Folienexporte sind ebenfalls Rendering‑Vorgänge, sodass die exportierten Grafiken nicht als exakte Kopie des ursprünglichen eingebetteten SVG behandelt werden sollten; verwenden Sie die eingebetteten [SvgImage.getSvgData](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/#getSvgData--)‑Daten, wenn die originale Vektorressource selbst benötigt wird.

## **Ein Bild zuschneiden**

Zuschneiden ändert, welcher Teil eines Bildes im Rahmen sichtbar ist. Die Zuschneidewerte im [PictureFillFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/) sind Prozentsätze der Quellbildabmessungen. Das Zuschneiden löscht die versteckten Pixel des eingebetteten Bildes zunächst nicht; es ändert nur den sichtbaren Bereich.

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

Da die versteckten Bilddaten weiterhin vorhanden sind, kann der Zuschnitt später geändert werden, ohne die Originalpixel zu verlieren. Wenn die Dateigröße wichtiger ist als die Wiederherstellbarkeit, können die zugeschnittenen Bereiche wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Zugeschnittene Bilddaten entfernen**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) entfernt Bilddaten außerhalb des aktuellen Zuschnittsrechtecks und gibt die resultierende Bildressource zurück. Das kann die Dateigröße verringern, ist jedoch eine destruktive Optimierung: Nach dem Speichern der Präsentation stehen die entfernten Pixel für eine spätere Entzuschneidung nicht mehr zur Verfügung.

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

Die Methode kann der Präsentation eine neue Bildressource hinzufügen. Wenn das Originalbild auch von anderen Bildrahmen verwendet wird, benötigen diese weiterhin ihre vorhandene Ressource, sodass das Löschen von zugeschnittenen Bereichen nicht zwangsläufig die Gesamtzahl der Bilder reduziert. Das Zuschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rastert das zugeschnittene Ergebnis in PNG.

## **Rasterbilder komprimieren**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) reduziert die Auflösung von Rasterbildern in Relation zur Anzeigegröße des Bildes. Es kann außerdem zugeschnittene Bereiche im selben Vorgang entfernen. Die Methode gibt `true` zurück, wenn das Bild skaliert oder zugeschnitten wurde, und `false`, wenn keine Änderung erforderlich war.

Verwenden Sie einen vordefinierten [PicturesCompression](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturescompression/)‑Wert, wenn eine standardisierte Zielauflösung ausreichend ist:

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

Ein benutzerdefinierter positiver DPI‑Wert kann anstelle eines vordefinierten Werts übergeben werden, wenn ein spezielles Ziel erforderlich ist.

Kompression ist für Rasterbilder vorgesehen. SVG‑ und Metadatei‑Inhalte werden durch diesen Rasterkompressions‑Workflow nicht reduziert. Denken Sie außerdem daran, dass niedrigere Auflösung und entfernte zugeschnittene Bereiche nicht aus der optimierten Präsentation wiederhergestellt werden können. Wählen Sie eine Zielauflösung basierend auf der größten Größe, in der das Bild tatsächlich angezeigt oder exportiert wird, anstatt global die niedrigste DPI zu verwenden.

## **Bild‑Effekte prüfen**

Bildeffekte werden am vom Rahmen genutzten Bild gespeichert. Die Bild‑Transformationssammlung kann Effekte wie feste Alpha‑Modulation für Transparenz und Luminanz für Helligkeit und Kontrast enthalten. Das folgende Beispiel liest beide Arten von Effekten sicher aus dem ersten Bildrahmen einer Folie:

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
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Diese Effekte ändern, wie das Bild im Rahmen gerendert wird; sie überschreiben nicht die ursprünglichen eingebetteten Bildbytes.

## **Geometrie des Bildrahmens sperren**

Die Einstellungen von [PictureFrameLock](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframelock/) bestimmen, welche Bearbeitungsvorgänge für einen Bildrahmen deaktiviert sind. Zum Beispiel bewahrt [setAspectRatioLocked](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) die Proportionen des Shapes, während es skaliert wird.

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

Die Sperre gilt für das Bildrahmen‑Shape. Sie zwingt das Quellbild nicht, neu zu sampeln oder dauerhaft auf dasselbe Seitenverhältnis geändert zu werden.

## **StretchOffset‑Werte anpassen**

Wenn der Bild‑Füllmodus „stretch“ ist, definieren die Stretch‑Offset‑Werte im [PictureFillFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/) das Füllrechteck relativ zur Begrenzungsbox des Bildrahmens. Positive Prozentsätze erzeugen einen Innenabstand von einer Kante, während negative Prozentsätze einen Außenabstand erzeugen.

Das ist anders als beim Zuschneiden. Zuschneidewerte bestimmen, welcher Teil des Quellbildes sichtbar ist; Stretch‑Offsets ändern das Rechteck, in das die sichtbare Bildfüllung gestreckt wird.

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

Verwenden Sie Stretch‑Offsets für die Platzierung der Füllung. Verwenden Sie Zuschneide‑Eigenschaften, wenn das Ziel darin besteht, die Kanten des Quellbildes zu verbergen.

## **Speicher, Dateigröße und Export‑Überlegungen**

Die wichtigsten Kompromisse lassen sich leichter handhaben, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt behandelt werden:

- **Eingebettete Bilder** machen die Präsentation eigenständig und sind am zuverlässigsten für das Teilen und serverseitige Rendern, jedoch vergrößern große Rasterbilder die PPTX‑Größe und den Speicherverbrauch.
- **Verknüpfte Bilder** können das Paket kleiner halten, jedoch hängt die Präsentation von externen Dateien ab, die an den gespeicherten Pfaden oder Standorten verfügbar bleiben müssen.
- **Zuschneiden** ist zunächst nicht destruktiv. Die versteckten Pixel bleiben eingebettet, bis zugeschnittene Bereiche ausdrücklich gelöscht oder während der Kompression entfernt werden.
- **Kompression** kann die Dateigröße bei übergroßen Rasterbildern erheblich reduzieren, verliert jedoch die Quellauflösung. Sie sollte nach Festlegung der geplanten Größe auf der Folie angewendet werden.
- **SVG‑Bilder** sollten als SVG bleiben, wenn die Vektorpreservation wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektorressource selbst benötigen. Raster‑Folienexporte konvertieren immer die gerenderte Folie in Pixel.
- **Wiederholte Bilder** sollten nach Möglichkeit eine vorhandene [PPImage]-Ressource wiederverwenden, anstatt dieselbe Datei mehrfach in den Präsentations‑Workflow zu laden.

Bei großen Präsentationen ist die Bildoptimierung in der Regel am effektivsten, wenn sie selektiv durchgeführt wird: Behalten Sie Logos und Diagramme als Vektorinhalt, komprimieren Sie Fotos gemäß ihrer tatsächlichen Anzeigengröße, entfernen Sie zugeschnittene Pixel nur, wenn eine spätere Bearbeitung nicht erforderlich ist, und vermeiden Sie externe Links, es sei denn, das Abhängigkeitsmanagement ist Teil des Bereitstellungsdesigns.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) stellt eine Bildressource dar, die mit der Präsentation verknüpft ist. Ein [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) ist ein Shape auf einer Folie, das ein Bild anzeigt und rahmenbezogene Geometrie und Formatierung wie Größe, Drehung, Zuschneidewerte, Effekte und Sperren speichert.

**Soll ich Bilder einbetten oder verknüpfen?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verknüpfen Sie Bilder nur, wenn das Auslagern von Bilddateien aus dem PPTX beabsichtigt ist und die externen Speicherorte zuverlässig verwaltet werden können.

**Reduziert das Zuschneiden die PPTX‑Dateigröße?**

Nicht von selbst. Normale Zuschneideinstellungen verbergen Teile des Quellbildes, behalten jedoch die zugrunde liegenden Pixel. Verwenden Sie [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) oder Bildkompression mit Entfernen zugeschnittener Bereiche, wenn diese Pixel dauerhaft verworfen werden können.

**Kann ich die Bildqualität nach der Kompression wiederherstellen?**

Nein. Die Kompression kann die gespeicherte Rasterauflösung reduzieren, und das Entfernen zugeschnittener Bereiche verwirft Bilddaten. Bewahren Sie das Originalbild außerhalb der Präsentation auf, falls später eine hochauflösende Bearbeitung nötig sein könnte.

**Wie sollten SVG‑Bilder behandelt werden?**

Behalten Sie SVG‑Inhalte als SVG, wenn die Vektor‑Treue wichtig ist. Das eingebettete [SvgImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/) kann direkt extrahiert werden. Das Rendern einer Folie in ein Rasterformat wie PNG oder JPEG rastert das SVG als Teil des Folienbildes.

**Wie kann ich unsichere Casts beim Lesen vorhandener Folien vermeiden?**

Prüfen Sie den Shape‑Typ, bevor Sie picture‑frame‑spezifische Member verwenden. Eine `java.instanceOf`‑Prüfung gegen [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) verhindert ungültige Casts und ermöglicht dem Code, Folien zu behandeln, die keinen Bildrahmen enthalten.