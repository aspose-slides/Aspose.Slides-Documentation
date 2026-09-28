---
title: Verwalten von Folienmastern in Präsentationen mit JavaScript
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
- unbenutzte Masterfolie
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie Folienmaster in Aspose.Slides für Node.js via Java: Zugriff, Bearbeitung, Klonen, Vergleichen und Entfernen von Masterfolien in PowerPoint- und OpenDocument-Präsentationen."
---
## **Übersicht**

Ein **Folienmaster** definiert geteilte Design‑Einstellungen für eine Gruppe von Folien. Er kann gemeinsame Formen, Logos, Hintergründe, Textstile, Theme‑Einstellungen und Fußzeileneinstellungen enthalten. In PowerPoint ist das Bearbeiten eines Folienmasters der übliche Weg, eine Präsentation konsistent zu halten, ohne dieselbe Formatierung auf jeder Folie zu wiederholen.

Aspose.Slides für Node.js via Java unterstützt dasselbe Modell. Eine Präsentation kann einen oder mehrere Folienmaster enthalten, und jeder Folienmaster kann mehrere Layoutfolien enthalten. Normale Folien verweisen normalerweise nicht direkt auf einen Folienmaster. Stattdessen verwendet eine normale Folie eine Layoutfolie, und diese Layoutfolie gehört zu einem Folienmaster.

Die Hierarchie lautet:

1. **Folienmaster** – definiert das geteilte Design und Theme.  
1. **Layoutfolie** – definiert eine spezifische Anordnung von Platzhaltern und Layout‑Formatierungen.  
1. **Normale Folie** – enthält den eigentlichen Präsentationsinhalt und verwendet eine Layoutfolie.

![Die Hierarchie von Folienmastern, Layoutfolien und normalen Folien](slide-master_2.jpg)

In Aspose.Slides wird ein Folienmaster durch die [MasterSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/)‑Klasse repräsentiert. Alle Folienmaster in einer Präsentation sind über die `Presentation.getMasters()`‑Sammlung zugänglich.

{{% alert color="info" title="Vererbung" %}}
Wenn dieselbe Eigenschaft auf mehr als einer Ebene definiert ist, gewinnt die spezifischere Ebene. Beispiel: Wenn ein Folienmaster und eine Layoutfolie beide einen Hintergrund definieren, verwenden Folien, die auf diesem Layout basieren, den Layout‑Hintergrund. Weitere Informationen zu Layoutfolien finden Sie unter [Anwenden oder Ändern von Folienlayouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Zugriff auf Folienmaster**

In PowerPoint können Sie die Folienmaster‑Ansicht über **Ansicht** > **Folienmaster** öffnen.

![Der Befehl Folienmaster auf der Registerkarte Ansicht in PowerPoint](slide-master_3.jpg)

In Aspose.Slides verwenden Sie die `getMasters()`‑Sammlung, um Folienmaster zuzugreifen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Sie können auch den vom Layout einer normalen Folie verwendeten Folienmaster abrufen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Ein Folienmaster ist ein folienähnliches Objekt. Er erbt das gemeinsame Folienverhalten von [BaseSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslide/), sodass er viele derselben Folieneigenschaften bereitstellt, die von normalen und Layoutfolien verwendet werden. Masterspezifische Mitglieder sind auf der API‑Seite [MasterSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/) aufgelistet.

Häufig verwendete Folienmaster‑Mitglieder umfassen:

| Mitglied | Zweck |
| --- | --- |
| `getBackground()` | Legt den Folienhintergrund auf Masterebene fest. |
| `getShapes()` | Speichert Formen, die auf dem Master platziert sind, z. B. Logos, Bildrahmen und gemeinsamen Text. |
| `getLayoutSlides()` | Speichert die Layoutfolien, die zum Master gehören. |
| `getThemeManager()` | Stellt Zugriff auf die Master‑Theme‑APIs bereit. |
| `getHeaderFooterManager()` | Steuert Kopf‑ und Fußzeilen, Datumsangaben und Folienzahlen für den Master und seine untergeordneten Layouts. |
| `getDependingSlides()` | Gibt normale Folien zurück, die über ihre Layouts vom Master abhängen. |

## **Ein Bild zu einem Folienmaster hinzufügen**

Wenn Sie ein Bild zu einem Folienmaster hinzufügen, erscheint es auf Folien, die Layouts dieses Masters verwenden. Das ist nützlich für Logos, Wasserzeichen, dekorative Bänder und andere wiederholte Bildelemente.

Das folgende Beispiel fügt das Logo zur ersten Folienmaster‑Folien hinzu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Weitere Informationen zu Bildrahmen finden Sie unter [Bildrahmen](/nodejs-java/picture-frame/).

## **Sichtbarkeit von Master‑Grafiken steuern**

Verwenden Sie [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes), um geerbte Master‑Grafiken, wie Logos oder dekorative Formen, auszublenden, ohne sie vom Master zu löschen. Übergeben Sie `false` an [Slide.setShowMasterShapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#setShowMasterShapes) auf der Folie, die diese Grafiken weglassen soll, und belassen Sie es auf `true` bei Folien, die sie anzeigen sollen.

Das folgende eigenständige Beispiel erstellt ein blaues dekoratives Band auf einem Master und zwei Folien, die dasselbe leere Layout verwenden. Das Band ist auf der ersten Folie sichtbar und auf der zweiten ausgeblendet. Keine Eingabe‑Präsentation oder Bild ist erforderlich.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Beispiel verwendet das Layout **Blank**, das mit einer neuen Präsentation bereitgestellt wird, und entfernt die Platzhalter der ursprünglichen Folie.

### **Wählen Sie den Geltungsbereich der Einstellung**

Eine normale Folie verwendet ihren Master über [Slide.getLayoutSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#getLayoutSlide) und [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). Das Setzen der Eigenschaft auf einer einzelnen Folie wirkt nur auf diese Folie. Das Übergeben von `false` an [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) blendet Master‑Grafiken für Folien aus, die dieses geteilte Layout verwenden, selbst wenn deren eigene Einstellung `true` ist. Um Grafiken nur auf einer Folie zu verbergen, ändern Sie die Folien‑Eigenschaft und lassen das geteilte Layout unverändert.

Die Einstellung wird nicht als Sichtbarkeitssteuerung auf dem Folienmaster selbst unterstützt. Auf einem Master gibt [getShowMasterShapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) immer `false` zurück, und das Übergeben von `true` an [setShowMasterShapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) löst eine Ausnahme aus. Wenden Sie sie stattdessen auf eine normale Folie oder ein Layout an.

### **Grafiken vom Hintergrund unterscheiden**

| Vorgang | Effekt |
| --- | --- |
| Master‑Grafiken ausblenden | Steuert die Sichtbarkeit geerbter Master‑Formen, ohne sie zu löschen oder die eigenen Formen der Folie zu verändern. |
| Hintergrundfüllung der Folie ändern | Ändert die Hintergrundfarbe, den Farbverlauf oder das Bild. Master‑Grafiken sind separate Formen und können über diesem Hintergrund sichtbar bleiben. Siehe [Präsentationshintergrund](/slides/de/nodejs-java/presentation-background/). |
| Eine Form vom Master löschen | Entfernt die gemeinsam genutzte Quellform, sodass sie für keine Folie mehr verfügbar ist, die diesen Master verwendet. |

## **Arbeiten mit Platzhaltern**

Platzhalter werden normalerweise auf Layoutfolien definiert. Der Folienmaster liefert den geteilten Stil und das Theme, das diese Layouts erben, während jedes Layout entscheidet, welche Platzhalter verfügbar sind und wo sie platziert werden.

In PowerPoint stehen Platzhalterbefehle in der Folienmaster‑Ansicht zur Verfügung.

![Der Befehl „Platzhalter einfügen“ in der Folienmaster‑Ansicht von PowerPoint](slide-master_5.png)

Um neue Platzhalter mit Aspose.Slides hinzuzufügen, arbeiten Sie mit der Layoutfolie, die zum Master gehört:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Sie können auch Platzhalterformen formatieren, die bereits auf einem Folienmaster vorhanden sind. Das folgende Beispiel findet den Titel‑Platzhalter und wendet eine lineare Farbverlaufsfüllung an:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatierter Titel‑Platzhalter, der von normalen Folien geerbt wird](slide-master_8.png)

Weitere Optionen für Platzhalter‑ und Textformatierung finden Sie unter [Platzhalter‑Eingabetext festlegen](/nodejs-java/manage-placeholder/) und [Textformatierung](/nodejs-java/text-formatting/).

## **Hintergrund eines Folienmasters ändern**

Ein Master‑Hintergrund wird von Layouts und Folien geerbt, die ihn nicht überschreiben. Das folgende Beispiel setzt eine einfarbige Hintergrundfarbe für die erste Folienmaster‑Folie:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Verwandte Themen finden Sie unter [Präsentationshintergrund](/nodejs-java/presentation-background/) und [Präsentationsthema](/nodejs-java/presentation-theme/).

## **Einen Folienmaster in eine andere Präsentation klonen**

Verwenden Sie `MasterSlideCollection.addClone`, um einen Folienmaster in eine andere Präsentation zu kopieren. Der kopierte Master kann dann von Layouts und Folien in der Zielpräsentation verwendet werden.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Eine Präsentation kann mehrere Folienmaster enthalten. Das ist nützlich, wenn verschiedene Abschnitte unterschiedliche Markenführung, Seitenstruktur oder Theme‑Einstellungen benötigen.

![PowerPoint‑Befehle zum Einfügen und Verwalten von Folienmastern](slide-master_9.jpg)

Das folgende Beispiel klont den Standard‑Master, gibt dem Klon einen anderen Hintergrund, erstellt ein Layout unter diesem geklonten Master und fügt eine neue Folie basierend auf diesem Layout hinzu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Folienmaster können mit der vom [BaseSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/baseslide/) geerbten `equals`‑Methode verglichen werden. Der Vergleich prüft Struktur und statischen Inhalt, wie Formen, Text, Formatierung, Animationen und andere Folieneinstellungen. Er vergleicht nicht eindeutige Bezeichner wie Folien‑IDs oder dynamische Platzhalterwerte wie das aktuelle Datum.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Weitere Informationen finden Sie unter [Präsentationsfolien vergleichen](/slides/de/nodejs-java/compare-slides/).

## **Folienmaster‑Ansicht als Standardansicht festlegen**

Verwenden Sie die `setLastView`‑Methode auf [ViewProperties](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/viewproperties/), um die Ansicht zu steuern, die PowerPoint zuerst öffnet. Das folgende Beispiel öffnet die Präsentation in der Folienmaster‑Ansicht:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Weitere Ansichtseinstellungen finden Sie unter [Präsentation speichern](/slides/de/nodejs-java/save-presentation/).

## **Unbenutzte Folienmaster entfernen**

Präsentationen enthalten manchmal Folienmaster, die von keiner normalen Folie mehr verwendet werden. Das Entfernen unbenutzter Master kann die Dateigröße reduzieren und die Wartung von Vorlagen vereinfachen.

Verwenden Sie `removeUnused`, um unbenutzte Master aus der `getMasters()`‑Sammlung zu entfernen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
Ein Folienmaster definiert gemeinsame Design‑Einstellungen wie Theme, Hintergrund, gemeinsame Formen und Textstile. Eine Layoutfolie gehört zu einem Folienmaster und definiert eine spezifische Anordnung von Platzhaltern. Eine normale Folie verwendet eine Layoutfolie und erbt somit sowohl vom Layout als auch vom Master.

**Kann eine Präsentation mehrere Folienmaster enthalten?**  
Ja. Eine Präsentation kann mehrere Folienmaster enthalten. Verwenden Sie mehrere Master, wenn unterschiedliche Abschnitte unterschiedliche visuelle Systeme oder Markenführungen benötigen.

**Soll ich Platzhalter zu einem Folienmaster oder zu einer Layoutfolie hinzufügen?**  
In den meisten Fällen fügen Sie Platzhalter zu Layoutfolien hinzu. Legen Sie gemeinsam genutzte visuelle Elemente und Formatierungen auf den Folienmaster, und setzen Sie Inhalts‑Platzhalter auf die Layouts, die von den normalen Folien verwendet werden.

**Kann ich einen Folienmaster löschen, der noch verwendet wird?**  
Nein. Ein Folienmaster, der abhängige Folien hat, kann nicht sicher direkt entfernt werden. Verschieben Sie zunächst diese Folien zu Layouts unter einem anderen Master oder verwenden Sie eine Bereinigungs‑Methode, die nur ungenutzte Master entfernt.