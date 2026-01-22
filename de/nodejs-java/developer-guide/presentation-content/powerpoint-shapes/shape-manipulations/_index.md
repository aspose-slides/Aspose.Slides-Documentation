---
title: Verwalten von Präsentationsformen in JavaScript
linktitle: Formbearbeitung
type: docs
weight: 40
url: /de/nodejs-java/shape-manipulations/
keywords:
- PowerPoint-Form
- Präsentationsform
- Form auf Folie
- Form finden
- Form duplizieren
- Form entfernen
- Form ausblenden
- Formreihenfolge ändern
- Interop-Form-ID abrufen
- Form-Alternativtext
- Form-Layoutformate
- Form als SVG
- Form zu SVG
- Form ausrichten
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Formen mit JavaScript und Aspose.Slides für Node.js via Java erstellen, bearbeiten und optimieren und leistungsstarke PowerPoint-Präsentationen bereitstellen."
---

## **Form in Folie finden**
Dieses Thema beschreibt eine einfache Methode, um es Entwicklern zu erleichtern, eine bestimmte Form auf einer Folie zu finden, ohne deren interne Id zu verwenden. Es ist wichtig zu wissen, dass PowerPoint‑Präsentationsdateien keine Möglichkeit haben, Formen auf einer Folie zu identifizieren, außer über eine interne eindeutige Id. Es scheint für Entwickler schwierig zu sein, eine Form anhand ihrer internen eindeutigen Id zu finden. Allen zu den Folien hinzugefügten Formen wird ein Alternativtext zugewiesen. Wir empfehlen Entwicklern, den Alternativtext zu verwenden, um eine bestimmte Form zu finden. Sie können MS PowerPoint nutzen, um den Alternativtext für Objekte festzulegen, die Sie in Zukunft ändern möchten.

Nachdem Sie den Alternativtext einer gewünschten Form festgelegt haben, können Sie die Präsentation mit Aspose.Slides für Node.js via Java öffnen und über alle Formen einer Folie iterieren. Bei jeder Iteration können Sie den Alternativtext der Form prüfen; die Form mit dem passenden Alternativtext ist die gesuchte Form. Um diese Technik besser zu demonstrieren, haben wir eine Methode [findShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) erstellt, die das Auffinden einer bestimmten Form in einer Folie übernimmt und dann einfach diese Form zurückgibt.
```javascript
// Instanziieren einer Presentation-Klasse, die die Präsentationsdatei darstellt
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Alternativtext der zu findenden Form
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```


## **Form duplizieren**
Um eine Form zu einer Folie zu duplizieren, verwenden Sie Aspose.Slides für Node.js via Java:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
1. Greifen Sie auf die Formensammlung der Quellfolie zu.
1. Fügen Sie der Präsentation eine neue Folie hinzu.
1. Duplizieren Sie Formen aus der Formensammlung der Quellfolie in die neue Folie.
1. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Das folgende Beispiel fügt einer Folie eine Gruppierung von Formen hinzu.
```javascript
// Instanziieren der Presentation-Klasse
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // PPTX-Datei auf die Festplatte schreiben
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Form entfernen**
Aspose.Slides für Node.js via Java ermöglicht Entwicklern das Entfernen beliebiger Formen. Um eine Form von einer beliebigen Folie zu entfernen, führen Sie die nachstehenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit dem angegebenen AlternativeText.
1. Entfernen Sie die Form.
1. Speichern Sie die Datei auf dem Datenträger.
```javascript
// Presentation-Objekt erstellen
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen
    var sld = pres.getSlides().get_Item(0);
    // Autoform vom Typ Rechteck hinzufügen
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Präsentation auf die Festplatte speichern
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Form ausblenden**
Aspose.Slides für Node.js via Java ermöglicht Entwicklern das Ausblenden beliebiger Formen. Um eine Form von einer beliebigen Folie auszublenden, führen Sie die nachstehenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Suchen Sie die Form mit dem angegebenen AlternativeText.
1. Blenden Sie die Form aus.
1. Speichern Sie die Datei auf dem Datenträger.
```javascript
// Instanziieren der Presentation‑Klasse, die die PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen
    var sld = pres.getSlides().get_Item(0);
    // Autoform vom Typ Rechteck hinzufügen
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Präsentation auf die Festplatte speichern
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Reihenfolge der Formen ändern**
Aspose.Slides für Node.js via Java ermöglicht Entwicklern das Neuordnen von Formen. Durch das Neuordnen wird festgelegt, welche Form im Vordergrund und welche im Hintergrund steht. Um die Formen einer Folie neu zu ordnen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine Form hinzu.
1. Fügen Sie einigen Text in den Textrahmen der Form ein.
1. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
1. Ordnen Sie die Formen neu.
1. Speichern Sie die Datei auf dem Datenträger.
```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Interop‑Shape‑ID abrufen**
Aspose.Slides für Node.js via Java ermöglicht Entwicklern, einen eindeutigen Formbezeichner im Geltungsbereich einer Folie zu erhalten, im Gegensatz zur Methode [getUniqueId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getUniqueId--) , die einen eindeutigen Bezeichner im Präsentationsumfang liefert. Die Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) wurde zur Klasse [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) hinzugefügt. Der von der Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) zurückgegebene Wert entspricht dem Id‑Wert des Microsoft.Office.Interop.PowerPoint.Shape‑Objekts. Im Folgenden wird ein Beispielcode gezeigt.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Einzigartige Shape-ID im Folienbereich abrufen
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Alternativtext für Form festlegen**
Aspose.Slides für Node.js via Java ermöglicht Entwicklern, den AlternateText beliebiger Formen zu setzen. Formen in einer Präsentation können über die Methoden [AlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) oder [Shape Name](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setName-java.lang.String-) unterschieden werden. Die Methoden [setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) und [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) können mit Aspose.Slides sowie Microsoft PowerPoint gelesen oder gesetzt werden. Durch die Verwendung dieser Methode können Sie eine Form kennzeichnen und verschiedene Vorgänge ausführen, wie das Entfernen, Ausblenden oder Neuordnen von Formen auf einer Folie. Um den AlternateText einer Form festzulegen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie eine beliebige Form zur Folie hinzu.
1. Arbeiten Sie mit der neu hinzugefügten Form.
1. Durchlaufen Sie die Formen, um eine bestimmte Form zu finden.
1. Setzen Sie den AlternativeText.
1. Speichern Sie die Datei auf dem Datenträger.
```javascript
// Instanziieren der Presentation-Klasse, die die PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen
    var sld = pres.getSlides().get_Item(0);
    // Autoform vom Typ Rechteck hinzufügen
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Präsentation auf die Festplatte speichern
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Layoutformate für Form zugreifen**
Aspose.Slides für Node.js via Java stellt eine einfache API bereit, um auf Layoutformate einer Form zuzugreifen. Dieser Artikel zeigt, wie Sie Layoutformate abrufen können.

Im Folgenden wird ein Beispielcode angegeben.
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Form als SVG rendern**
Nun unterstützt Aspose.Slides für Node.js via Java das Rendern einer Form als SVG. Die Methode [writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (und ihre Überladung) wurde der Klasse [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) hinzugefügt. Diese Methode ermöglicht das Speichern des Inhalts der Form als SVG‑Datei. Das untenstehende Code‑Snippet zeigt, wie Sie die Form einer Folie in eine SVG‑Datei exportieren können.
```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ausrichtung von Formen**
Aspose.Slides ermöglicht das Ausrichten von Formen entweder relativ zu den Folienrändern oder relativ zueinander. Zu diesem Zweck wurde die überladene Methode [SlidesUtil.alignShape()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) hinzugefügt. Die Aufzählung [ShapesAlignmentType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapesAlignmentType) definiert mögliche Ausrichtungsoptionen.

**Beispiel 1**

Der nachstehende Quellcode richtet die Formen mit den Indizes 1, 2 und 4 an der oberen Folienkante aus.
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**Beispiel 2**

Das folgende Beispiel zeigt, wie Sie die gesamte Formensammlung relativ zur untersten Form in der Sammlung ausrichten.
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Flip‑Eigenschaften**
In Aspose.Slides bietet die Klasse [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) Kontrolle über das horizontale und vertikale Spiegeln von Formen über die Eigenschaften `flipH` und `flipV`. Beide Eigenschaften sind vom Typ `byte` und erlauben die Werte `1` für ein Spiegeln, `0` für kein Spiegeln oder `-1` für das Standardverhalten. Diese Werte sind über den [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) einer Form zugänglich.

Um die Flip‑Einstellungen zu ändern, wird eine neue [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/)‑Instanz mit der aktuellen Position und Größe der Form, den gewünschten Werten für `flipH` und `flipV` sowie dem Rotationswinkel erstellt. Durch das Zuweisen dieser Instanz zum [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) der Form und anschließendem Speichern der Präsentation werden die Spiegel‑Transformationen angewendet und in die Ausgabedatei übernommen.

Angenommen, wir haben eine Datei **sample.pptx**, in der die erste Folie eine einzelne Form mit den Standard‑Flip‑Einstellungen enthält, wie unten gezeigt.

![Die zu drehende Form](shape_to_be_flipped.png)

Der folgende Code‑Beispiel ruft die aktuellen Flip‑Eigenschaften der Form ab und dreht sie sowohl horizontal als auch vertikal.
```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Abrufen der horizontalen Flip‑Eigenschaft der Form.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Abrufen der vertikalen Flip‑Eigenschaft der Form.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Flip horizontally.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Flip vertically.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![Die gedrehte Form](flipped_shape.png)

## **FAQ**

**Kann ich Formen (Vereinigung/Schnittmenge/Subtraktion) auf einer Folie wie in einem Desktop‑Editor kombinieren?**

Es gibt keine integrierte API für Boolesche Operationen. Sie können dies annähern, indem Sie die gewünschte Kontur selbst erzeugen – z. B. die resultierende Geometrie über [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) berechnen und eine neue Form mit diesem Umriss erstellen, wobei die Originalformen optional entfernt werden.

**Wie kann ich die Stapelreihenfolge (Z‑Order) steuern, sodass eine Form immer „oben“ bleibt?**

Ändern Sie die Einfüge‑/Verschiebe‑Reihenfolge innerhalb der [shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes)-Sammlung der Folie. Für vorhersehbare Ergebnisse sollten Sie die Z‑Order nach allen anderen Folienänderungen finalisieren.

**Kann ich eine Form „sperren“, um zu verhindern, dass Benutzer sie in PowerPoint bearbeiten?**

Ja. Setzen Sie schutzbezogene Flags auf Form‑Ebene (z. B. Auswahl, Bewegung, Größenänderung, Textbearbeitung). Bei Bedarf können Sie ähnliche Einschränkungen auf dem Master oder Layout setzen. Beachten Sie, dass dies nur UI‑Schutz ist, keinen umfassenden Sicherheitsschutz; für stärkeren Schutz kombinieren Sie ihn mit Dateibeschränkungen wie [read‑only Empfehlungen oder Passwörtern](/slides/de/nodejs-java/password-protected-presentation/).