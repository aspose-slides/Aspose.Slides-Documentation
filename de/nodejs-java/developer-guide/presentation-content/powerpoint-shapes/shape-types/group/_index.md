---
title: Gruppe
type: docs
weight: 40
url: /de/nodejs-java/group/
---

## **Gruppenform hinzufügen**
Aspose.Slides unterstützt die Arbeit mit Gruppenformen auf Folien. Diese Funktion hilft Entwicklern, reichhaltigere Präsentationen zu erstellen. Aspose.Slides für Node.js via Java unterstützt das Hinzufügen oder Zugreifen auf Gruppenformen. Es ist möglich, Formen zu einer hinzugefügten Gruppenform hinzuzufügen, um sie zu füllen, oder auf beliebige Eigenschaften der Gruppenform zuzugreifen. So fügen Sie einer Folie eine Gruppenform mit Aspose.Slides für Node.js via Java hinzu:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Holen Sie die Referenz einer Folie über ihren Index.
1. Fügen Sie der Folie eine Gruppenform hinzu.
1. Fügen Sie der hinzugefügten Gruppenform Formen hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Das folgende Beispiel fügt einer Folie eine Gruppenform hinzu.
```javascript
// Instanziieren der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen
    var sld = pres.getSlides().get_Item(0);
    // Zugriff auf die Formensammlung der Folien
    var slideShapes = sld.getShapes();
    // Hinzufügen einer Gruppenform zur Folie
    var groupShape = slideShapes.addGroupShape();
    // Hinzufügen von Formen in die hinzugefügte Gruppenform
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Hinzufügen des Gruppenformrahmens
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Die PPTX-Datei auf die Festplatte schreiben
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **AltText‑Eigenschaft zugreifen**
Dieses Thema zeigt einfache Schritte, komplett mit Codebeispielen, zum Hinzufügen einer Gruppenform und zum Zugriff auf die AltText‑Eigenschaft von Gruppenformen auf Folien. So greifen Sie mit Aspose.Slides für Node.js via Java auf AltText einer Gruppenform in einer Folie zu:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation), die eine PPTX‑Datei darstellt.
1. Holen Sie die Referenz einer Folie über ihren Index.
1. Greifen Sie auf die Formensammlung der Folien zu.
1. Greifen Sie auf die Gruppenform zu.
1. Rufen Sie die Eigenschaft [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) auf.

Das folgende Beispiel greift auf den Alternativtext der Gruppenform zu.
```javascript
// Instanziieren der Presentation-Klasse, die die PPTX-Datei darstellt
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Erste Folie abrufen
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Zugriff auf die Formensammlung der Folien
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Zugriff auf die Gruppenform.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Zugriff auf die AltText-Eigenschaft
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Wird verschachteltes Gruppieren (eine Gruppe innerhalb einer Gruppe) unterstützt?**

Ja. [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) hat eine [getParentGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getparentgroup/)‑Methode, die direkt die Hierarchieunterstützung anzeigt (eine Gruppe kann Kind einer anderen Gruppe sein).

**Wie steuere ich die Z‑Reihenfolge der Gruppe im Verhältnis zu anderen Objekten auf der Folie?**

Verwenden Sie die [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/)‑Methode [getZOrderPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getzorderposition/), um ihre Position im Anzeigestapel zu prüfen.

**Kann ich das Verschieben/Bearbeiten/Entgruppieren verhindern?**

Ja. Der Sperrbereich der Gruppe wird über [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/getgroupshapelock/) bereitgestellt, wodurch Sie Vorgänge an dem Objekt einschränken können.