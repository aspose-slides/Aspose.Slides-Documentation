---
title: Präsentations-Folienmaster in JavaScript verwalten
linktitle: Folienmaster
type: docs
weight: 70
url: /de/nodejs-java/slide-master/
keywords:
- Folienmaster
- Masterfolie
- PPT-Masterfolie
- mehrere Masterfolien
- Masterfolien vergleichen
- Hintergrund
- Platzhalter
- Masterfolie klonen
- Masterfolie kopieren
- Masterfolie duplizieren
- ungenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie Folienmaster in Aspose.Slides für Node.js via Java: Zugriff, Bearbeitung, Klonen, Vergleich und Entfernen von Masterfolien in PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Ein **Folienmaster** definiert freigegebene Designeinstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Theme‑Einstellungen und Fußzeileneinstellungen enthalten. In PowerPoint ist das Bearbeiten eines Folienmasters die übliche Methode, eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides für Node.js via Java unterstützt dasselbe Modell. Eine Präsentation kann einen oder mehrere Masterfolien enthalten, und jede Masterfolie kann mehrere Layoutfolien enthalten. Normale Folien verweisen normalerweise nicht direkt auf eine Masterfolie. Stattdessen verwendet eine normale Folie eine Layoutfolie, und diese Layoutfolie gehört zu einer Masterfolie.

Die Hierarchie ist:

1. **Folienmaster** – definiert das gemeinsame Design und Theme.
1. **Layoutfolie** – definiert eine spezifische Anordnung von Platzhaltern und layoutbezogener Formatierung.
1. **Normale Folie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layoutfolie.

![Die Hierarchie von Masterfolien, Layoutfolien und normalen Folien](slide-master_2.jpg)

In Aspose.Slides wird ein Folienmaster durch die Klasse [MasterSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/) repräsentiert. Alle Masterfolien in einer Präsentation sind über die Sammlung `Presentation.getMasters()` verfügbar.

{{% alert color="info" title="Vererbung" %}}

Wenn dieselbe Eigenschaft auf mehr als einer Ebene definiert ist, gewinnt die spezifischere Ebene. Wenn beispielsweise eine Masterfolie und eine Layoutfolie beide einen Hintergrund definieren, verwenden Folien, die auf diesem Layout basieren, den Layout‑Hintergrund. Weitere Informationen zu Layoutfolien finden Sie unter [Layoutfolien anwenden oder ändern](/nodejs-java/slide-layout/).

{{% /alert %}}

## **Zugriff auf Folienmaster**

In PowerPoint können Sie die Folienmaster‑Ansicht über **Ansicht** > **Folienmaster** öffnen.

![Der Folienmaster‑Befehl auf der Registerkarte Ansicht in PowerPoint](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die Sammlung `getMasters()`, um Masterfolien zuzugreifen:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Sie können auch die Masterfolie, die von einer normalen Folie verwendet wird, über ihr Layout holen:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Was ein Folienmaster enthält**

Eine Masterfolie ist ein folienähnliches Objekt. Sie erbt das gemeinsame Folienverhalten von [BaseSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslide/), sodass sie viele der gleichen Folieneigenschaften bereitstellt, die von normalen und Layoutfolien verwendet werden. Master‑spezifische Member werden auf der API‑Seite [MasterSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/) aufgelistet.

Häufig verwendete Masterfolie‑Member umfassen:

| Member | Zweck |
| --- | --- |
| `getBackground()` | Legt den Hintergrund der Masterfolie fest. |
| `getShapes()` | Speichert Formen, die auf dem Master platziert sind, wie Logos, Bildrahmen und gemeinsamen Text. |
| `getLayoutSlides()` | Speichert die Layoutfolien, die zum Master gehören. |
| `getThemeManager()` | Stellt Zugriff auf die Master‑Theme‑APIs bereit. |
| `getHeaderFooterManager()` | Steuert Kopf‑ und Fußzeilen, Datumsangaben und Foliennummern für den Master und seine untergeordneten Layouts. |
| `getDependingSlides()` | Gibt normale Folien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einer Masterfolie hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederholte Bildelemente.

Das folgende Beispiel fügt der ersten Masterfolie ein Logo hinzu:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für weitere Informationen zu Bildrahmen siehe [Bildrahmen](/nodejs-java/picture-frame/).

## **Arbeiten mit Platzhaltern**

Platzhalter werden normalerweise auf Layoutfolien definiert. Die Masterfolie liefert den gemeinsamen Stil und das Theme, das diese Layouts erben, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint sind Platzhalterbefehle in der Folienmaster‑Ansicht verfügbar.

![Der Befehl 'Platzhalter einfügen' in der Folienmaster‑Ansicht von PowerPoint](slide-master_5.png)

Um mit Aspose.Slides neue Platzhalter hinzuzufügen, arbeiten Sie mit der Layoutfolie, die zum Master gehört:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sie können auch Platzhalterformen formatieren, die bereits auf einer Masterfolie vorhanden sind. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Farbverlauf‑Füllung an:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatierter Titelplatzhalter, der von normalen Folien geerbt wird](slide-master_8.png)

Für weitere Platzhalter‑ und Textformatierungsoptionen siehe [Platzhalter‑Prompt‑Text festlegen](/nodejs-java/manage-placeholder/) und [Textformatierung](/nodejs-java/text-formatting/).

## **Hintergrund eines Folienmasters ändern**

Ein Master‑Hintergrund wird von Layouts und Folien geerbt, die ihn nicht überschreiben. Das folgende Beispiel setzt eine einfarbige Hintergrundfarbe für die erste Masterfolie:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für verwandte Themen siehe [Präsentationshintergrund](/nodejs-java/presentation-background/) und [Präsentationstheme](/nodejs-java/presentation-theme/).

## **Einen Folienmaster in eine andere Präsentation klonen**

Verwenden Sie `MasterSlideCollection.addClone`, um eine Masterfolie in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

```javascript
let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Wenn Sie normale Folien zusammen mit ihrem Master klonen müssen, siehe [Folien klonen](/nodejs-java/clone-slides/).

## **Mehrere Folienmaster hinzufügen**

Eine Präsentation kann mehrere Masterfolien enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Markenauftritte, Seitenstrukturen oder Theme‑Einstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Masterfolien](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, erstellt ein Layout unter diesem geklonten Master und fügt eine neue Folie basierend auf diesem Layout hinzu:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Folienmaster vergleichen**

Masterfolien können mit der von [BaseSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslide/) geerbten `equals`‑Methode verglichen werden. Der Vergleich prüft Struktur und statische Inhalte wie Formen, Text, Formatierung, Animationen und andere Folienschutzeinstellungen. Er vergleicht nicht eindeutige Kennungen wie Folien‑IDs oder dynamische Platzhalterwerte wie das aktuelle Datum.

```javascript
let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Für weitere Informationen siehe [Präsentationsfolien vergleichen](/nodejs-java/compare-slides/).

## **Folienmaster‑Ansicht als Standardansicht festlegen**

Verwenden Sie die Methode `setLastView` auf [ViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Folienmaster‑Ansicht:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Für weitere Ansichtseinstellungen siehe [Präsentation speichern](/nodejs-java/save-presentation/).

## **Unbenutzte Masterfolien entfernen**

Präsentationen enthalten manchmal Masterfolien, die von keinen normalen Folien mehr verwendet werden. Das Entfernen ungenutzter Master kann die Dateigröße reduzieren und die Wartung von Vorlagen vereinfachen.

Verwenden Sie `removeUnused`, um ungenutzte Master aus der Sammlung `getMasters()` zu entfernen:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sie können außerdem die Low‑Code‑Methode `Compress.removeUnusedMasterSlides` verwenden:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Was ist der Unterschied zwischen einem Folienmaster und einer Layoutfolie?**

Ein Folienmaster definiert gemeinsame Designeinstellungen wie Theme, Hintergrund, gemeinsame Formen und Textstile. Eine Layoutfolie gehört zu einem Folienmaster und definiert eine spezifische Anordnung von Platzhaltern. Eine normale Folie verwendet eine Layoutfolie, sodass sie sowohl vom Layout als auch vom Master erbt.

**Kann eine Präsentation mehrere Folienmaster enthalten?**

Ja. Eine Präsentation kann mehrere Folienmaster enthalten. Verwenden Sie mehrere Master, wenn verschiedene Abschnitte unterschiedliche visuelle Systeme oder Markenauftritte benötigen.

**Sollte ich Platzhalter zu einer Masterfolie oder zu einer Layoutfolie hinzufügen?**

In den meisten Fällen sollten Platzhalter zu Layoutfolien hinzugefügt werden. Gemeinsame visuelle Elemente und gemeinsame Formatierungen auf die Masterfolie legen, dann Inhalte‑Platzhalter auf die Layouts setzen, die von normalen Folien verwendet werden.

**Kann ich eine Masterfolie löschen, die noch verwendet wird?**

Nein. Eine Masterfolie, die abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zunächst diese Folien zu Layouts unter einem anderen Master oder verwenden Sie eine Bereinigungsmethode für ungenutzte Master, die nur Master entfernt, die nicht verwendet werden.