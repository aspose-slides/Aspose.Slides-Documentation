---
title: Formmanipulationen
type: docs
weight: 40
url: /de/nodejs-java/shape-manipulations/
---

## **Form in Folie finden**
Dieses Thema beschreibt eine einfache Methode, um Entwicklern das Auffinden einer bestimmten Form auf einer Folie zu erleichtern, ohne deren interne Id zu verwenden. Es ist wichtig zu wissen, dass PowerPoint‑Präsentationsdateien keine Möglichkeit besitzen, Formen auf einer Folie zu identifizieren, außer über eine interne eindeutige Id. Es scheint für Entwickler schwierig zu sein, eine Form anhand ihrer internen eindeutigen Id zu finden. Allen Formen, die zu den Folien hinzugefügt werden, ist ein Alternativtext zugewiesen. Wir empfehlen Entwicklern, den Alternativtext zu verwenden, um eine bestimmte Form zu finden. Sie können MS PowerPoint verwenden, um den Alternativtext für Objekte festzulegen, die Sie in Zukunft ändern möchten.

Nachdem Sie den Alternativtext einer gewünschten Form festgelegt haben, können Sie die Präsentation mit Aspose.Slides für Node.js via Java öffnen und durch alle zu einer Folie hinzugefügten Formen iterieren. Während jeder Iteration können Sie den Alternativtext der Form prüfen, und die Form mit dem passenden Alternativtext ist die von Ihnen gesuchte Form. Um diese Technik besser zu demonstrieren, haben wir eine Methode namens [findShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) erstellt, die das Auffinden einer bestimmten Form auf einer Folie übernimmt und anschließend einfach diese Form zurückgibt.
```javascript
// Instanziiere eine Presentation-Klasse, die die Präsentationsdatei repräsentiert
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


## **Form klonen**
Um eine Form auf einer Folie mit Aspose.Slides für Node.js via Java zu klonen:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Erhalten Sie die Referenz einer Folie, indem Sie deren Index verwenden.
3. Greifen Sie auf die Formsammlung der Quellfolie zu.
4. Fügen Sie der Präsentation eine neue Folie hinzu.
5. Klonen Sie Formen aus der Formsammlung der Quellfolie in die neue Folie.
6. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Das folgende Beispiel fügt einer Folie eine Gruppierungsform hinzu.
```javascript
// Instanziiere Presentation-Klasse
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // Schreibe die PPTX-Datei auf die Festplatte
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Form entfernen**
Aspose.Slides für Node.js via Java ermöglicht Entwicklern das Entfernen beliebiger Formen. Um eine Form von einer Folie zu entfernen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Suchen Sie die Form mit dem spezifischen AlternativeText.
4. Entfernen Sie die Form.
5. Speichern Sie die Datei auf dem Datenträger.
```javascript
// Presentation-Objekt erstellen
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie erhalten
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
Aspose.Slides für Node.js via Java ermöglicht Entwicklern das Ausblenden beliebiger Formen. Um eine Form auf einer Folie auszublenden, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Suchen Sie die Form mit dem spezifischen AlternativeText.
4. Blenden Sie die Form aus.
5. Speichern Sie die Datei auf dem Datenträger.
```javascript
// Presentation-Klasse instanziieren, die das PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie erhalten
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
Aspose.Slides für Node.js via Java ermöglicht Entwicklern das Neuanordnen von Formen. Durch das Neuanordnen wird festgelegt, welche Form im Vordergrund und welche im Hintergrund liegt. Um die Formen auf einer Folie neu zu ordnen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie eine Form hinzu.
4. Fügen Sie etwas Text in den Textbereich der Form ein.
5. Fügen Sie eine weitere Form mit denselben Koordinaten hinzu.
6. Ordnen Sie die Formen neu.
7. Speichern Sie die Datei auf dem Datenträger.
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


## **Interop‑Form‑ID abrufen**
Aspose.Slides für Node.js via Java ermöglicht Entwicklern das Abrufen einer eindeutigen Form‑Kennung im Folien‑Umfang, im Gegensatz zur Methode [getUniqueId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getUniqueId--) , die eine eindeutige Kennung im Präsentations‑Umfang liefert. Die Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) wurde der Klasse [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) hinzugefügt. Der von der Methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) zurückgegebene Wert entspricht dem Id‑Wert des Microsoft.Office.Interop.PowerPoint.Shape‑Objekts. Unten ist ein Beispielcode angegeben.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Abrufen der eindeutigen Shape-Kennzeichnung im Folienbereich
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Alternativen Text für Form festlegen**
Aspose.Slides für Node.js via Java ermöglicht Entwicklern das Festlegen von AlternateText für jede Form. Formen in einer Präsentation können über die Methoden [AlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) oder [Shape Name](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setName-java.lang.String-) unterschieden werden. Die Methoden [setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) und [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) können sowohl mit Aspose.Slides als auch mit Microsoft PowerPoint gelesen bzw. gesetzt werden. Mit dieser Methode können Sie eine Form kennzeichnen und verschiedene Vorgänge ausführen, wie das Entfernen, Ausblenden oder Neuanordnen von Formen auf einer Folie. Um den AlternateText einer Form festzulegen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Greifen Sie auf die erste Folie zu.
3. Fügen Sie der Folie eine beliebige Form hinzu.
4. Arbeiten Sie mit der neu hinzugefügten Form.
5. Durchlaufen Sie die Formen, um eine bestimmte Form zu finden.
6. Setzen Sie den AlternativeText.
7. Speichern Sie die Datei auf dem Datenträger.
```javascript
// Instanziiere die Presentation-Klasse, die das PPTX darstellt
var pres = new aspose.slides.Presentation();
try {
    // Erhalte die erste Folie
    var sld = pres.getSlides().get_Item(0);
    // Füge eine Autoform vom Typ Rechteck hinzu
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
    // Speichere die Präsentation auf der Festplatte
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Layout‑Formate für Form abrufen**
Aspose.Slides für Node.js via Java bietet eine einfache API zum Zugriff auf Layout‑Formate einer Form. Dieser Artikel zeigt, wie Sie auf Layout‑Formate zugreifen können. Unten ist ein Beispielcode angegeben.
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
Now Aspose.Slides for Node.js via Java supports rendering a shape as SVG. Die Methode [writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (und ihre Überladung) wurde der Klasse [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) hinzugefügt. Diese Methode ermöglicht das Speichern des Inhalts einer Form als SVG‑Datei. Der folgende Code‑Abschnitt zeigt, wie man die Form einer Folie in eine SVG‑Datei exportiert.
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


## **Formen ausrichten**
Aspose.Slides ermöglicht das Ausrichten von Formen entweder relativ zu den Folienrändern oder zueinander. Zu diesem Zweck wurde die überladene Methode [SlidesUtil.alignShape()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) hinzugefügt. Die Aufzählung [ShapesAlignmentType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapesAlignmentType) definiert mögliche Ausrichtungsoptionen.

**Example 1**

Der nachstehende Quellcode richtet die Formen mit den Indizes 1, 2 und 4 entlang des oberen Randes der Folie aus.
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


**Example 2**

Das folgende Beispiel zeigt, wie die gesamte Formsammlung relativ zur untersten Form in der Sammlung ausgerichtet wird.
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


## **Spiegelungs‑Eigenschaften**
In Aspose.Slides bietet die Klasse [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) Kontrolle über horizontales und vertikales Spiegeln von Formen über die Eigenschaften `flipH` und `flipV`. Beide Eigenschaften sind vom Typ `byte` und erlauben die Werte `1` für ein Spiegeln, `0` für kein Spiegeln oder `-1` für das Standardverhalten. Diese Werte sind über den [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) einer Form zugänglich.

Um die Spiegel‑Einstellungen zu ändern, wird eine neue Instanz von [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) mit der aktuellen Position und Größe der Form, den gewünschten Werten für `flipH` und `flipV` sowie dem Rotationswinkel erstellt. Durch Zuweisen dieser Instanz zum [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) der Form und dem Speichern der Präsentation werden die Spiegel‑Transformationen angewendet und in die Ausgabedatei übernommen.

Angenommen, wir haben eine Datei sample.pptx, in der die erste Folie eine einzelne Form mit den Standard‑Spiegel‑Einstellungen enthält, wie unten gezeigt.

![The shape to be flipped](shape_to_be_flipped.png)

Das folgende Code‑Beispiel ruft die aktuellen Spiegel‑Eigenschaften der Form ab und spiegelt sie sowohl horizontal als auch vertikal.
```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Horizontale Spiegelungs‑Eigenschaft der Form abrufen.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Vertikale Spiegelungs‑Eigenschaft der Form abrufen.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Horizontal spiegeln.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Vertikal spiegeln.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


![The flipped shape](flipped_shape.png)

## **FAQ**

**Kann ich Formen (Vereinigung/Überschneidung/Subtraktion) auf einer Folie wie in einem Desktop‑Editor kombinieren?**

Es gibt keine integrierte API für boolesche Operationen. Sie können dies annähern, indem Sie die gewünschte Kontur selbst erstellen – z. B. die resultierende Geometrie über [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) berechnen und eine neue Form mit dieser Kontur erzeugen, optional die Originale entfernen.

**Wie kann ich die Stapel‑Reihenfolge (Z‑Order) steuern, sodass eine Form stets “oben” bleibt?**

Ändern Sie die Einfüge‑/Verschiebe‑Reihenfolge innerhalb der [shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes)‑Sammlung der Folie. Für vorhersehbare Ergebnisse sollten Sie den Z‑Order nach allen anderen Folien‑Modifikationen finalisieren.

**Kann ich eine Form “sperren”, um zu verhindern, dass Benutzer sie in PowerPoint bearbeiten?**

Ja. Setzen Sie [shape‑bezogene Schutz‑Flags](/slides/de/nodejs-java/applying-protection-to-presentation/) (z. B. Auswahl, Verschiebung, Größenänderung, Textbearbeitung sperren). Falls nötig, spiegeln Sie die Einschränkungen im Master oder Layout. Beachten Sie, dass dies ein UI‑Schutz ist und keine Sicherheitsfunktion; für stärkeren Schutz kombinieren Sie dies mit dateibezogenen Einschränkungen wie [Empfehlungen für schreibgeschützten Zugriff oder Passwörter](/slides/de/nodejs-java/password-protected-presentation/).