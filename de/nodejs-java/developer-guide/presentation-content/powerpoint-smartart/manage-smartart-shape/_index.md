---
title: SmartArt-Form verwalten
type: docs
weight: 20
url: /de/nodejs-java/manage-smartart-shape/
---

## **SmartArt-Form erstellen**
Aspose.Slides for Node.js via Java stellt eine API zum Erstellen von SmartArt-Formen bereit. Um eine SmartArt-Form in einer Folie zu erstellen, befolgen Sie bitte die nachstehenden Schritte:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Holen Sie sich die Referenz einer Folie, indem Sie deren Index verwenden.
3. [SmartArt-Form hinzufügen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) durch Festlegen des [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType).
4. Speichern Sie die modifizierte Präsentation als PPTX-Datei.
```javascript
// Präsentationsklasse instanziieren
var pres = new aspose.slides.Presentation();
try {
    // Erste Folie abrufen
    var slide = pres.getSlides().get_Item(0);
    // SmartArt-Form hinzufügen
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Präsentation speichern
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Abbildung: SmartArt-Form zur Folie hinzugefügt**|

## **Zugriff auf SmartArt-Form in Folie**
Der folgende Code wird verwendet, um auf die in der Präsentationsfolie hinzugefügten SmartArt-Formen zuzugreifen. Im Beispielcode durchlaufen wir jede Form in der Folie und prüfen, ob es sich um eine [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt)-Form handelt. Ist die Form vom Typ SmartArt, casten wir sie in eine [**SmartArt**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt)-Instanz um.
```javascript
// Laden der gewünschten Präsentation
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Durchlaufen jeder Form in der ersten Folie
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Form zu SmartArtEx casten
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Zugriff auf SmartArt-Form mit bestimmtem Layouttyp**
Der folgende Beispielcode hilft beim Zugriff auf die [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt)-Form mit einem bestimmten LayoutType. Bitte beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er schreibgeschützt ist und nur gesetzt wird, wenn die [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt)-Form hinzugefügt wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) und laden Sie die Präsentation mit SmartArt-Form.
2. Holen Sie sich die Referenz der ersten Folie, indem Sie deren Index verwenden.
3. Durchlaufen Sie jede Form in der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
5. Überprüfen Sie die SmartArt-Form mit dem gewünschten LayoutType und führen Sie anschließend die erforderlichen Aktionen aus.
```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Durchlaufen jeder Form in der ersten Folie
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Form zu SmartArtEx casten
            var smart = shape;
            // Überprüfen des SmartArt-Layouts
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt-Formstil ändern**
In diesem Beispiel lernen wir, den Schnellstil für eine beliebige SmartArt-Form zu ändern.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) und laden Sie die Präsentation mit SmartArt-Form.
2. Holen Sie sich die Referenz der ersten Folie, indem Sie deren Index verwenden.
3. Durchlaufen Sie jede Form in der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) ist, und casten Sie sie zu SmartArt, falls sie SmartArt ist.
5. Suchen Sie die SmartArt-Form mit einem bestimmten Stil.
6. Setzen Sie den neuen Stil für die SmartArt-Form.
7. Speichern Sie die Präsentation.
```javascript
// Präsentationsklasse instanziieren
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Erste Folie abrufen
    var slide = pres.getSlides().get_Item(0);
    // Durchlaufen jeder Form in der ersten Folie
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Form zu SmartArtEx casten
            var smart = shape;
            // Überprüfen des SmartArt-Stils
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // Ändern des SmartArt-Stils
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Präsentation speichern
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Abbildung: SmartArt-Form mit geändertem Stil**|

## **SmartArt-Formfarbstil ändern**
In diesem Beispiel lernen wir, den Farbstil für eine beliebige SmartArt-Form zu ändern. Im folgenden Beispielcode greifen wir auf die SmartArt-Form mit einem bestimmten Farbstil zu und ändern ihren Stil.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) und laden Sie die Präsentation mit SmartArt-Form.
2. Holen Sie sich die Referenz der ersten Folie, indem Sie deren Index verwenden.
3. Durchlaufen Sie jede Form in der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) ist, und casten Sie sie zu SmartArt, falls sie SmartArt ist.
5. Suchen Sie die SmartArt-Form mit einem bestimmten Farbstil.
6. Setzen Sie den neuen Farbstil für die SmartArt-Form.
7. Speichern Sie die Präsentation.
```javascript
// Präsentationsklasse instanziieren
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Erste Folie abrufen
    var slide = pres.getSlides().get_Item(0);
    // Durchlaufen jeder Form in der ersten Folie
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Prüfen, ob die Form vom Typ SmartArt ist
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Form zu SmartArtEx casten
            var smart = shape;
            // Überprüfen des SmartArt-Farbtyps
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // Ändern des SmartArt-Farbtyps
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Präsentation speichern
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Abbildung: SmartArt-Form mit geändertem Farbstil**|

## **FAQ**

**Kann ich SmartArt als einzelnes Objekt animieren?**

Ja. SmartArt ist eine Form, daher können Sie über die Animations‑API [Standardanimationen](/slides/de/nodejs-java/powerpoint-animation/) (Eingang, Ausgang, Hervorhebung, Bewegungsbahnen) genauso wie bei anderen Formen anwenden.

**Wie kann ich ein bestimmtes SmartArt auf einer Folie finden, wenn ich seine interne ID nicht kenne?**

Legen Sie den Alternativtext (AltText) fest und verwenden Sie ihn, um nach der Form zu suchen – dies ist ein empfohlener Weg, die Ziel‑Form zu finden.

**Kann ich SmartArt mit anderen Formen gruppieren?**

Ja. Sie können SmartArt mit anderen Formen (Bildern, Tabellen usw.) gruppieren und dann die Gruppe [manipulieren](/slides/de/nodejs-java/group/).

**Wie erhalte ich ein Bild eines bestimmten SmartArt (z. B. für eine Vorschau oder einen Bericht)?**

Exportieren Sie eine Miniatur-/Bilddatei der Form; die Bibliothek kann einzelne Formen [rendern](/slides/de/nodejs-java/create-shape-thumbnails/) zu Rasterdateien (PNG/JPG/TIFF).

**Wird das Aussehen von SmartArt beim Konvertieren der gesamten Präsentation in PDF beibehalten?**

Ja. Die Rendering‑Engine zielt bei [PDF‑Export](/slides/de/nodejs-java/convert-powerpoint-to-pdf/) auf hohe Treue ab und bietet verschiedene Qualitäts‑ und Kompatibilitätsoptionen.