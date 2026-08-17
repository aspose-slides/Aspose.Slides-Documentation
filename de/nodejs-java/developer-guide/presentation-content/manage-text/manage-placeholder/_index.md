---
title: Verwalten von Präsentationsplatzhaltern in JavaScript
linktitle: Platzhalter verwalten
type: docs
weight: 10
url: /de/nodejs-java/manage-placeholder/
keywords:
- Platzhalter
- Textplatzhalter
- Bildplatzhalter
- Diagrammplatzhalter
- Inhaltsplatzhalter
- Hinweistext
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Text-, Bild-, Diagramm- und Inhaltsplatzhalter untersuchen und bearbeiten sowie die Platzhaltervererbung mit Aspose.Slides für Node.js über Java verstehen."
---
## **Übersicht**

Ein Platzhalter ist eine Form, die in einer Präsentationsvorlage eine Position für eine bestimmte Art von Inhalt reserviert. Häufige Beispiele sind Titel-, Text-, Bild-, Diagramm- und allgemeine Inhaltsplatzhalter. Im Gegensatz zu einer normalen Form kann ein Platzhalter seine Position, Größe, Formatierung und andere Einstellungen von einer Layout‑Folie oder einer Masterfolie erben.

Aspose.Slides stellt Platzhalterinformationen über die Methode [Shape.getPlaceholder](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getPlaceholder) zur Verfügung. Die Methode gibt ein [Placeholder](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/placeholder/)‑Objekt zurück oder `null` für eine normale Form. Verwenden Sie [Placeholder.getType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/placeholder/#getType), um zu bestimmen, welchen Inhalt der Platzhalter enthalten soll.

Die Formklasse bleibt auch nach Kenntnis des Platzhaltertyps relevant:

- Ein leerer Text-, Bild-, Diagramm- oder Inhaltsplatzhalter wird in der Regel durch ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) dargestellt.
- Ein befüllter Bildplatzhalter kann durch einen [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) dargestellt werden.
- Ein befüllter Diagrammplatzhalter kann durch ein [Chart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/) dargestellt werden.
- Ein Inhaltsplatzhalter kann mehrere Arten von Inhalten enthalten. Prüfen Sie sowohl [Placeholder.getType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/placeholder/#getType) als auch die Laufzeit‑Formklasse, anstatt anzunehmen, dass jeder Platzhalter ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) ist.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/placeholder/#getType) beschreibt die Rolle eines Platzhalters; sie garantiert nicht den Laufzeit‑Typ der Form. Verwenden Sie immer eine Typprüfung, bevor Sie auf Text-, Bild-, Diagramm-, Tabellen- oder medienspezifische Mitglieder zugreifen.
{{% /alert %}}

## **Verstehen der Platzhaltervererbung**

Platzhalter bilden eine Hierarchie:

1. Eine Masterfolie definiert wiederverwendbare Stile und, in einigen Fällen, Master‑Platzhalter.
2. Eine Layout‑Folie definiert das Layout, das von einer oder mehreren normalen Folien verwendet wird, und kann vom Master erben.
3. Eine normale Folie enthält die Platzhalter für diese Folie und kann von ihrem Layout erben.

Rufen Sie [Shape.getBasePlaceholder](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getBasePlaceholder) auf, um eine Ebene höher in dieser Hierarchie zu wechseln. Ein Folienplatzhalter gibt normalerweise seinen Layout‑Platzhalter zurück; ein Layout‑Platzhalter kann seinen Master‑Platzhalter zurückgeben. Die Methode liefert `null`, wenn die Form keinen Basis‑Platzhalter hat.

Das folgende Beispiel listet die Platzhalter auf der ersten Folie auf und gibt deren Basis‑Platzhalter aus:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Das Bearbeiten eines Platzhalters auf einer normalen Folie erstellt oder ändert eine lokale Überschreibung für diese Folie. Das Bearbeiten des zugehörigen Layouts oder Masters kann alle Folien beeinflussen, die diese Einstellung noch erben. Eine lokale normale Form hat keinen Basis‑Platzhalter und beginnt nicht zu erben, nur weil sie dieselben Koordinaten einnimmt.

## **Text in einem Platzhalter ändern**

Titel-, zentrierte‑Titel-, Untertitel-, Text‑ und Inhaltsplatzhalter unterstützen normalerweise Text. Prüfen Sie, ob es sich um ein [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/) handelt, bevor Sie dessen [getTextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/#getTextFrame)‑Methode verwenden.

Dieses Beispiel aktualisiert den ersten Titel‑Platzhalter auf der ersten Folie und speichert das Ergebnis:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dieses Muster vermeidet, Bild‑, Diagramm‑, Tabellen‑ oder Medien‑Platzhalter als [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/)‑Objekte zu behandeln. Es identifiziert den Platzhalter außerdem nach seiner Zweckbestimmung, anstatt sich auf einen fragilen Form‑Index zu verlassen.

## **Hinweistext auf einem Layout festlegen**

Hinweistext ist die Anweisung zur Entwurfszeit, die in einem leeren Platzhalter angezeigt wird, z. B. *Klicken, um Titel hinzuzufügen*. Legen Sie benutzerdefinierten Hinweistext am Layout‑Platzhalter fest, anstatt zu versuchen, ihn über die Form‑Sammlung einer normalen Folie zu erreichen. Greifen Sie über [Slide.getLayoutSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#getLayoutSlide) auf das Layout zu und iterieren Sie über die Sammlung, die von [BaseSlide.getShapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslide/#getShapes) zurückgegeben wird.

Das folgende Beispiel ändert die Titel‑ und Untertitel‑Hinweise im Layout, das von der ersten Folie verwendet wird:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hinweistext ist kein normaler Folieninhalt. Er ist für leere Platzhalter in Bearbeitungsanwendungen wie PowerPoint gedacht. Sobald ein Benutzer oder ein Programm echten Inhalt bereitstellt, wird der Hinweis nicht mehr angezeigt. Das Ändern eines Hinweises ersetzt außerdem nicht den vorhandenen Text auf Folien, die das Layout verwenden.

## **Ein Bild‑Platzhalter aktualisieren**

Es gibt zwei zu behandelnde Fälle:

- Wenn der Bild‑Platzhalter bereits befüllt ist und durch ein [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) dargestellt wird, ersetzen Sie das Bild über [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picturefillformat/#getPicture) und [Picture.setImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picture/#setImage).

- Wenn es noch ein leerer Platzhalter ist, fügen Sie an den Koordinaten des Platzhalters einen Bildrahmen mit [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) hinzu und entfernen Sie den leeren Platzhalter.

Das nächste Beispiel unterstützt beide Fälle und speichert die Präsentation:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der Ersatz, der für einen leeren Platzhalter erstellt wird, ist ein lokaler Bildrahmen, kein neuer Platzhalter, weil [Shape.getPlaceholder](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getPlaceholder) keinen Setter bietet. Er behält die reservierte Position bei, erbt jedoch nicht mehr das platzhalterspezifische Verhalten. Wenn das Beibehalten der Platzhalterbeziehung wichtig ist, erstellen und füllen Sie den Platzhalter zunächst in PowerPoint und aktualisieren anschließend das resultierende [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) mit Aspose.Slides.

Für Bildtransparenz, Zuschneiden und andere bildbezogene Effekte siehe [Manage Picture Frames](/slides/de/nodejs-java/picture-frame/). Diese Vorgänge betreffen den Bildrahmen oder das Bildfüllformat, nicht die Metadaten des Platzhalters.

## **Arbeiten mit Diagramm‑ und Inhaltsplatzhaltern**

Ein befüllter Diagramm‑Platzhalter kann durch ein [Chart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/) dargestellt werden. Dieses Beispiel findet ein solches Diagramm sowohl nach Platzhaltertyp als auch nach Laufzeitklasse, ändert dessen Titel und speichert die Datei:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ein allgemeiner Inhaltsplatzhalter hat in der Regel [PlaceholderType.Object](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/placeholdertype/#Object). In PowerPoint fungiert er als Auslöser für mehrere Inhaltstypen, darunter Diagramme, Tabellen, Diagramme, Bilder und Medien. Nachdem er befüllt wurde, prüfen Sie die tatsächliche Formklasse, um zu erfahren, was er enthält. Spezialisierte Layouts können zudem [PlaceholderType.Chart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/placeholdertype/#Media) oder [PlaceholderType.Diagram](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/placeholdertype/#Diagram) bereitstellen.

Aspose.Slides wandelt einen leeren [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/)‑Platzhalter nicht einfach durch Ändern von [Placeholder.getType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/placeholder/#getType) in ein [Chart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/) um; der Typ kann nicht über das Objekt geändert werden. Um ein leeres Diagramm‑ oder Inhaltsbereich programmgesteuert zu füllen, fügen Sie das erforderliche Objekt an den Koordinaten des Platzhalters hinzu und entfernen anschließend den leeren Platzhalter. Das folgende Beispiel erledigt das für ein Diagramm:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das hinzugefügte Diagramm ist ein gewöhnliches lokales Diagramm. Es belegt den Bereich des Platzhalters, erbt jedoch nicht vom Layout‑Platzhalter. Verwenden Sie die speziellen [chart management articles](/slides/de/nodejs-java/powerpoint-charts/), wenn Sie dessen Kategorien, Reihen oder Arbeitsblattdaten ersetzen müssen.

## **Vollständiges Beispiel: Text‑ oder Bildinhalt aktualisieren**

Das folgende End‑zu‑Ende‑Beispiel öffnet eine Vorlage, durchsucht die erste Folie nach einem Titel‑ oder Bild‑Platzhalter, prüft die Platzhalter‑ und Formtypen, aktualisiert den entsprechenden Inhalt und speichert das Ergebnis. Das Beispiel vermeidet bewusst die Annahme eines Form‑Indexes oder das Behandeln jedes Platzhalters als dieselbe Klasse.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Was ist ein Basis‑Platzhalter?**

Ein Basis‑Platzhalter ist die entsprechende Form auf dem Layout oder Master, von dem ein anderer Platzhalter erbt. Verwenden Sie [Shape.getBasePlaceholder](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#getBasePlaceholder), um ihn abzurufen. Eine gewöhnliche lokale Form gibt `null` zurück, weil sie nicht Teil der Platzhalterhierarchie ist.

**Kann ich alle Folientitel ändern, indem ich einen Layout‑Platzhalter bearbeite?**

Sie können über ein Layout die vererbte Formatierung oder den Hinweistext ändern, aber der vorhandene Titelinhalt ist auf den normalen Folien gespeichert. Um den tatsächlichen Titeltext in einer gesamten Präsentation zu ersetzen, iterieren Sie über die Folien und aktualisieren jeden Titel‑Platzhalter.

**Wie verwalte ich Datums‑, Folien‑Nummer‑, Kopf‑ und Fußzeilen‑Platzhalter?**

Verwenden Sie die Kopf‑ und Fußzeilen‑Manager im jeweiligen Folien‑, Layout‑, Master‑, Notizen‑ oder Handout‑Umfang. Siehe [Manage Presentation Header and Footer](/slides/de/nodejs-java/presentation-header-and-footer/) für vollständige Beispiele.