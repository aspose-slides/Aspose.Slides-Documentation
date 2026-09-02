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
- zugeschnittene Bereiche löschen
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

Ein Bildrahmen ist eine Folienform, die ein Bild anzeigt. In Aspose.Slides sind die Bildressource und die Form, die sie anzeigt, separate Objekte: eine [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) besitzt eingebettete Bildressourcen über ihre [ImageCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagecollection/), während ein [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) die Position, Größe, Linienformatierung, Drehung, das Zuschneiden, Bildeffekte und andere rahmeneigene Einstellungen des Bildes steuert.

Diese Trennung ist nützlich, wenn dasselbe Bild mehr als einmal angezeigt wird. Fügen Sie das Bild einmal zur Präsentation hinzu, behalten Sie das zurückgegebene [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) und verwenden Sie diese Bildressource beim Erstellen von Bildrahmen.

Bildrahmen können Rasterbilder wie PNG oder JPEG sowie vektorielle SVG‑Bilder enthalten. Sie können außerdem auf verknüpfte Bilder verweisen, anstatt die Bildbytes in der Präsentation zu speichern. Die Wahl wirkt sich auf Portabilität, Dateigröße, Extraktion und Exportverhalten aus, sodass es sinnvoll ist, vor der Formatierung oder Optimierung zu entscheiden, wie das Bild gespeichert werden soll.

## **Ein eingebettetes Bild hinzufügen und formatieren**

Für ein eingebettetes Bild fügen Sie die Bilddaten der Präsentation hinzu und erstellen einen Bildrahmen mit [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Das Bild wird Teil des Präsentationspakets, sodass die Präsentation selbst­enthalten bleibt, wenn sie auf einen anderen Computer verschoben wird.

Das folgende Beispiel fügt ein PNG‑Bild hinzu, erstellt einen Rahmen in den ursprünglichen Bildabmessungen und wendet Linienformatierung und Drehung an:

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

Der Bildrahmen steuert die angezeigte Geometrie; das Ändern der Rahmen­größe ändert nicht die ursprünglichen Pixelabmessungen, die in der eingebetteten Bildressource gespeichert sind. Diese Unterscheidung wird wichtig, wenn das Bild später zugeschnitten oder komprimiert wird.

## **Relative Skalierung verwenden**

[PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) stellt relative Breiten‑ und Höhenskalierung für den Rahmen über [setRelativeScaleWidth](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) und [setRelativeScaleHeight](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) bereit. Ein Wert von `1.0` entspricht 100 % der Originalgröße des Bildes. Relative Skalierung ist nützlich, wenn ein Workflow die Beziehung zur Ausgangsbildgröße erhalten muss, anstatt die Endabmessungen manuell zu berechnen.

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

Relative Skalierung ändert die Skalierungseinstellungen des Rahmens; sie nimmt weder ein Resampling noch eine Kompression des eingebetteten Bildes vor.

## **Eingebettete und verknüpfte Bilder**

Ein eingebettetes Bild speichert Bilddaten innerhalb der Präsentation und ist damit die sicherste Wahl für Portabilität und vorhersehbares Rendering. Ein verknüpftes Bild speichert über die Methode [Picture.setLinkPathLong](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) einen externen Pfad, anstatt die Bilddaten einzubetten.

Verknüpfte Bilder können die im PPTX gespeicherte Datenmenge reduzieren, führen jedoch eine externe Abhängigkeit ein. Die verknüpfte Datei muss für die Anwendung, die die Präsentation öffnet oder rendert, erreichbar bleiben. Ändert sich der Pfad, wird die Datei verschoben oder die Ressource ist nicht mehr verfügbar, wird das verknüpfte Bild möglicherweise nicht wie erwartet angezeigt. Für Präsentationen, die per E‑Mail verschickt, archiviert oder in isolierten Umgebungen gerendert werden sollen, sind eingebettete Bilder in der Regel zuverlässiger.

### **Ein verknüpftes Bild hinzufügen**

Das folgende Beispiel erstellt einen Bildrahmen und verweist auf eine lokale Bilddatei. Es behandelt ausschließlich das Bild‑Linking; Video‑Linking ist ein separater Medien‑Workflow und wird bewusst nicht in dieses Beispiel gemischt.

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

Verwenden Sie Links, wenn das externe Dateimanagement beabsichtigt ist. Nutzen Sie sie nicht lediglich als Ersatz für Kompression: Eine kleine PPTX mit defekten Bildabhängigkeiten ist in der Regel weniger nützlich als eine größere, selbst­enthaltene Präsentation.

## **Bilder aus Bildrahmen extrahieren**

Bevor Sie ein Bild aus einer bestehenden Präsentation extrahieren, prüfen Sie, ob die Form tatsächlich ein [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) ist und ein eingebettetes Bild enthält. Verknüpfte Bildrahmen enthalten möglicherweise keine Bildbytes, die auf dieselbe Weise extrahiert werden können.

### **Ein Rasterbild extrahieren**

Die moderne Bild‑API verwendet direkt [IImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/). Das folgende Beispiel findet das erste eingebettete Rasterbild auf einer Folie und speichert es als PNG:

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

Das Speichern über [IImage.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/iimage/#save) konvertiert das extrahierte Bild in das gewünschte Ausgabeformat. Wenn Sie die in der Präsentation gespeicherten kodierten Bytes benötigen, verwenden Sie stattdessen die binären Daten der Bildressource.

### **Ein SVG‑Bild extrahieren**

Für ein SVG‑Bild stellt das [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) ein [SvgImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/)‑Objekt bereit. Damit können Sie die SVG‑Daten direkt abrufen, ohne das Bild zuerst zu rasterisieren.

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

SVG‑Inhalte als SVG zu behalten, bewahrt die Vektorquelle innerhalb der Präsentation. Rasterexporte wie PNG oder JPEG rendern diesen Vektorinhalt zwangsläufig zu Pixeln. Der PDF‑ oder SVG‑Folienexport ist ebenfalls ein Rendering‑Vorgang, sodass die exportierten Grafiken nicht als 1‑zu‑1‑Kopie des ursprünglichen eingebetteten SVG betrachtet werden sollten; verwenden Sie die eingebetteten [SvgImage.getSvgData](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/#getSvgData--)‑Daten, wenn die originale Vektor­ressource selbst benötigt wird.

## **Ein Bild zuschneiden**

Zuschneiden ändert, welcher Teil eines Bildes im Rahmen sichtbar ist. Die Zuschneidewerte auf [PictureFillFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/) sind Prozentsätze der Ausgangsbildabmessungen. Das Zuschneiden löscht die versteckten Pixel nicht sofort aus dem eingebetteten Bild; es ändert lediglich den sichtbaren Bereich.

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

Da die versteckten Bilddaten weiterhin vorhanden sind, kann der Zuschnitt später geändert werden, ohne die Originalpixel zu verlieren. Wenn die Dateigröße wichtiger ist als die Rückgängig‑Möglichkeit, können die zugeschnittenen Bereiche wie im nächsten Abschnitt beschrieben physisch entfernt werden.

## **Zugeschnittene Bilddaten entfernen**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) entfernt Bilddaten außerhalb des aktuellen Zuschneiderahmens und liefert die resultierende Bildressource zurück. Das kann die Dateigröße reduzieren, ist jedoch eine destruktive Optimierung: Nach dem Speichern der Präsentation sind die entfernten Pixel nicht mehr für ein späteres Rückgängigmachen verfügbar.

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

Die Methode kann der Präsentation eine neue Bildressource hinzufügen. Wenn das Originalbild auch von anderen Bildrahmen verwendet wird, benötigen diese weiterhin ihre bestehende Ressource, sodass das Löschen zugeschnittener Bereiche nicht zwingend die Gesamtzahl der Bilder verringert. Das Zuschneiden von WMF‑ oder EMF‑Inhalten mit dieser Methode rastert das zugeschnittene Ergebnis zu PNG.

## **Rasterbilder komprimieren**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) reduziert die Auflösung von Rasterbildern relativ zur Größe, in der das Bild angezeigt wird. Es kann zudem zugeschnittene Bereiche im selben Vorgang entfernen. Die Methode liefert `true`, wenn das Bild skaliert oder zugeschnitten wurde, und `false`, wenn keine Änderung nötig war.

Verwenden Sie einen vordefinierten [PicturesCompression](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturescompression/)‑Wert, wenn eine standardisierte Zielauflösung ausreicht:

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

Kompression ist für Rasterbilder gedacht. SVG‑ und Metadatei‑Inhalte werden durch diesen Raster‑Kompressions‑Workflow nicht reduziert. Denken Sie auch daran, dass niedrigere Auflösung und gelöschte zugeschnittene Bereiche nach der Optimierung nicht wiederhergestellt werden können. Wählen Sie eine Zielauflösung basierend auf der größten Größe, in der das Bild tatsächlich angezeigt oder exportiert wird, anstatt global die niedrigste DPI zu verwenden.

## **Bildtransformations‑Effekte verwalten**

Für einen vollständigen Workflow zu Helligkeit, Kontrast, Farbumwandlungen, Unschärfe, Alpha‑Effekten, geordneten Ketten, Inspektion, Entfernung und Rundreise‑Verifikation siehe [Image Transform Effects](/slides/de/nodejs-java/image-transform-effects/).

## **Geometrie des Bildrahmens sperren**

Die Einstellungen von [PictureFrameLock](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframelock/) kontrollieren, welche Bearbeitungsoperationen für einen Bildrahmen deaktiviert sind. Beispielsweise bewahrt [setAspectRatioLocked](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) die Proportionen der Form, während sie skaliert wird.

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

Die Sperre gilt für die Bildrahmen‑Form. Sie zwingt das Quellbild nicht dazu, erneut gesampelt oder dauerhaft auf dasselbe Seitenverhältnis geändert zu werden.

## **StretchOffset‑Werte anpassen**

Wenn der Bildfüllmodus „stretch“ ist, definieren die Stretch‑Offset‑Werte auf [PictureFillFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/) das Füllrechteck relativ zur Begrenzungsbox des Bildrahmens. Positive Prozentsätze erzeugen eine Einrückung von einer Kante, während negative Prozentsätze ein Ausstoßen erzeugen.

Das ist anders als Zuschneiden. Zuschneidewerte bestimmen, welcher Teil des Quellbildes sichtbar ist; Stretch‑Offsets ändern das Rechteck, in das die sichtbare Bildfüllung gestreckt wird.

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

Verwenden Sie Stretch‑Offsets zur Platzierung der Füllung. Verwenden Sie Zuschneide‑Eigenschaften, wenn das Ziel darin besteht, Bildrandbereiche zu verbergen.

## **Speicherung, Dateigröße und Export‑Überlegungen**

Die wichtigsten Kompromisse sind leichter zu handhaben, wenn Bildspeicherung und Bildrahmen‑Formatierung getrennt betrachtet werden:

- **Eingebettete Bilder** machen die Präsentation selbst­enthaltend und sind am zuverlässigsten für das Teilen und serverseitige Rendering, doch große Rasterbilder erhöhen die PPTX‑Größe und den Speicherverbrauch.
- **Verknüpfte Bilder** können das Paket kleiner halten, aber die Präsentation ist dann von externen Dateien abhängig, die an den gespeicherten Pfaden oder Orten verfügbar bleiben müssen.
- **Zuschneiden** ist zunächst nicht‑destruktiv. Die versteckten Pixel bleiben eingebettet, bis zugeschnittene Bereiche explizit gelöscht oder bei der Kompression entfernt werden.
- **Kompression** kann die Dateigröße bei zu großen Rasterbildern erheblich reduzieren, kostet jedoch die ursprüngliche Auflösung. Sie sollte erst nach Bekanntwerden der finalen Anzeigegröße angewendet werden.
- **SVG‑Bilder** sollten als SVG erhalten bleiben, wenn die Vektor‑Erhaltung wichtig ist. Extrahieren Sie das eingebettete SVG direkt, wenn Sie die Vektor‑Ressource selbst benötigen. Raster‑Folien‑Exporte konvertieren das gerenderte Bild immer zu Pixeln.
- **Wiederholte Bilder** sollten nach Möglichkeit eine existierende [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/)-Ressource wiederverwenden, anstatt dieselbe Datei mehrfach in den Workflow zu laden.

Bei großen Präsentationen ist Bildoptimierung meist am effektivsten, wenn sie selektiv durchgeführt wird: Logos und Diagramme als Vektor‑Inhalt behalten, Fotos gemäß ihrer tatsächlichen Anzeigengröße komprimieren, zugeschnittene Pixel nur entfernen, wenn nachträgliche Bearbeitung nicht nötig ist, und externe Links nur einsetzen, wenn das Abhängigkeits‑Management Teil des Bereitstellungs‑Designs ist.

## **FAQ**

**Was ist der Unterschied zwischen einem Bildrahmen und einer Bildressource?**

Ein [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) stellt eine Bildressource dar, die mit der Präsentation verknüpft ist. Ein [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) ist eine Form auf einer Folie, die ein Bild anzeigt und rahmeneigene Geometrie sowie Formatierungen wie Größe, Drehung, Zuschneidewerte, Effekte und Sperren speichert.

**Soll ich Bilder einbetten oder verknüpfen?**

Betten Sie Bilder ein, wenn die Präsentation portabel, archiviert oder ohne Zugriff auf externe Ressourcen gerendert werden muss. Verknüpfen Sie Bilder nur, wenn das Auslagern von Bilddateien aus der PPTX beabsichtigt ist und die externen Speicherorte zuverlässig verwaltet werden können.

**Reduziert Zuschneiden die PPTX‑Dateigröße?**

Nicht allein. Normale Zuschneide‑Einstellungen verbergen Teile des Quellbildes, behalten aber die zugrunde liegenden Pixel. Verwenden Sie [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) oder Bildkompression mit Entfernen zugeschnittener Bereiche, wenn diese Pixel dauerhaft verworfen werden dürfen.

**Kann ich die Bildqualität nach der Kompression wiederherstellen?**

Nein. Kompression kann die gespeicherte Rasterauflösung reduzieren, und das Entfernen zugeschnittener Bereiche verwirft Bilddaten. Bewahren Sie das Originalbild außerhalb der Präsentation auf, wenn später eine hochwertige Bearbeitung erforderlich sein könnte.

**Wie sollten SVG‑Bilder behandelt werden?**

Behalten Sie SVG‑Inhalte als SVG, wenn die Vektor‑Treue wichtig ist. Das eingebettete [SvgImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/svgimage/) kann direkt extrahiert werden. Das Rendern einer Folie in ein Rasterformat wie PNG oder JPEG rasterisiert das SVG als Teil des Folienbildes.

**Wie kann ich unsichere Casts beim Lesen vorhandener Folien vermeiden?**

Prüfen Sie den Formtyp, bevor Sie bildrahmenspezifische Member verwenden. Ein `java.instanceOf`‑Check gegen [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) verhindert ungültige Casts und ermöglicht es Ihrem Code, Folien zu behandeln, die keinen Bildrahmen enthalten.