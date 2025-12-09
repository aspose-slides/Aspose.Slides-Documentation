---
title: Folienlayout in JavaScript anwenden oder ändern
linktitle: Folienlayout
type: docs
weight: 60
url: /de/nodejs-java/slide-layout/
keywords:
- Folienlayout
- Inhaltslayout
- Platzhalter
- Präsentationsdesign
- Foliengestaltung
- unbenutztes Layout
- Fußzeilen-Sichtbarkeit
- Titelfolie
- Titel und Inhalt
- Abschnittsüberschrift
- Zwei Inhalte
- Vergleich
- Nur Titel
- Leeres Layout
- Inhalt mit Beschriftung
- Bild mit Beschriftung
- Titel und vertikaler Text
- Vertikaler Titel und Text
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Folienlayouts in Aspose.Slides für Node.js verwalten und anpassen. Erkunden Sie Layout-Typen, die Steuerung von Platzhaltern, die Sichtbarkeit von Fußzeilen und die Manipulation von Layouts anhand von Code-Beispielen in JavaScript."
---

## **Übersicht**

Ein Folienlayout definiert die Anordnung von Platzhalterfeldern und die Formatierung des Inhalts einer Folie. Es steuert, welche Platzhalter verfügbar sind und wo sie erscheinen. Folienlayouts helfen Ihnen, Präsentationen schnell und einheitlich zu erstellen – egal, ob Sie etwas Einfaches oder Komplexeres gestalten. Einige der häufigsten Folienlayouts in PowerPoint sind:

**Titelfolienlayout** – Enthält zwei Textplatzhalter: einen für den Titel und einen für den Untertitel.

**Titel‑und‑Inhalt‑Layout** – Enthält einen kleineren Titelplatzhalter oben und darunter einen größeren für den Hauptinhalt (wie Text, Aufzählungspunkte, Diagramme, Bilder und mehr).

**Leeres Layout** – Enthält keine Platzhalter, sodass Sie die Folie von Grund auf selbst gestalten können.

Folienlayouts sind Teil einer Folienmaster, die die übergeordnete Folie ist und die Layout‑Stile für die Präsentation definiert. Sie können Layout‑Folien über den Folienmaster abrufen und ändern – entweder nach Typ, Name oder eindeutiger ID. Alternativ können Sie eine bestimmte Layout‑Folie direkt in der Präsentation bearbeiten.

Um mit Folienlayouts in Aspose.Slides für Node.js zu arbeiten, können Sie verwenden:

- Methoden wie [getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides) und [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) unter der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
- Typen wie [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/) und [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslideheaderfootermanager/).

{{% alert title="Info" color="info" %}}
Um mehr über die Arbeit mit Masterfolien zu erfahren, lesen Sie den Artikel [Slide Master](/slides/de/nodejs-java/slide-master/).
{{% /alert %}}

## **Folienlayouts zu Präsentationen hinzufügen**

Um das Aussehen und die Struktur Ihrer Folien anzupassen, müssen Sie möglicherweise neue Layout‑Folien zu einer Präsentation hinzufügen. Aspose.Slides für Node.js ermöglicht es Ihnen, zu prüfen, ob ein bestimmtes Layout bereits existiert, bei Bedarf ein neues hinzuzufügen und es zu verwenden, um Folien basierend auf diesem Layout einzufügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Greifen Sie auf die [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/) zu.
1. Überprüfen Sie, ob die gewünschte Layout‑Folie bereits in der Sammlung vorhanden ist. Falls nicht, fügen Sie die benötigte Layout‑Folie hinzu.
1. Fügen Sie eine leere Folie basierend auf der neuen Layout‑Folie hinzu.
1. Speichern Sie die Präsentation.

Der folgende JavaScript‑Code zeigt, wie ein Folienlayout zu einer PowerPoint‑Präsentation hinzugefügt wird:
```js
// Instanziiere die Presentation-Klasse, die eine PowerPoint-Datei darstellt.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Durchlaufe die Layout‑Folientypen, um eine Layout‑Folie auszuwählen.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Ein Fall, bei dem die Präsentation nicht alle Layout‑Typen enthält.
        // Die Präsentationsdatei enthält nur leere und benutzerdefinierte Layout‑Typen.
        // Allerdings können Layout‑Folien mit benutzerdefinierten Typen erkennbare Namen haben,
        // wie "Title", "Title and Content" usw., die für die Auswahl von Layout‑Folien verwendet werden können.
        // Sie können sich auch auf eine Menge von Platzhalter‑Formtypen verlassen.
        // Zum Beispiel sollte eine Titelfolie nur den Titel‑Platzhaltertyp besitzen, usw.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // Füge eine leere Folie mit der hinzugefügten Layout‑Folie ein.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Speichere die Präsentation auf die Festplatte.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Unbenutzte Layout‑Folien entfernen**

Aspose.Slides stellt die Methode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) aus der Klasse [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) bereit, mit der Sie unerwünschte und ungenutzte Layout‑Folien löschen können.

Der folgende JavaScript‑Code demonstriert, wie eine Layout‑Folie aus einer PowerPoint‑Präsentation entfernt wird:
```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Platzhalter zu Folienlayouts hinzufügen**

Aspose.Slides bietet die Methode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) mit der Sie neue Platzhalter zu einer Layout‑Folie hinzufügen können.

Dieser Manager enthält Methoden für die folgenden Platzhaltertypen:

| PowerPoint‑Platzhalter | [LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/) Methode |
| ---------------------- | ------------------------------------------------------------ |
| ![Inhalt](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Inhalt (vertikal)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (vertikal)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Bild](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagramm](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabelle](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Medien](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online‑Bild](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Der folgende JavaScript‑Code zeigt, wie neue Platzhalterformen zur leeren Layout‑Folie hinzugefügt werden:
```js
let presentation = new aspose.slides.Presentation();
try {
    // Hole die leere Layout-Folie.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Hole den Platzhalter-Manager der Layout-Folie.
    let placeholderManager = layout.getPlaceholderManager();

    // Füge verschiedene Platzhalter zur leeren Layout-Folie hinzu.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Füge eine neue Folie mit dem leeren Layout hinzu.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![Die Platzhalter auf der Layout‑Folie](add_placeholders.png)

## **Fußzeilen‑Sichtbarkeit für eine Layout‑Folie festlegen**

In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text je nach Folienlayout ein- oder ausgeblendet werden. Aspose.Slides für Node.js ermöglicht die Steuerung der Sichtbarkeit dieser Fußzeilen‑Platzhalter. Dies ist nützlich, wenn Sie möchten, dass bestimmte Layouts Fußzeileninformationen anzeigen, während andere sauber und minimal bleiben.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Holen Sie eine Referenz auf eine Layout‑Folie über ihren Index.
1. Setzen Sie den Fußzeilen‑Platzhalter der Folie auf sichtbar.
1. Setzen Sie den Foliennummer‑Platzhalter auf sichtbar.
1. Setzen Sie den Datum‑Uhrzeit‑Platzhalter auf sichtbar.
1. Speichern Sie die Präsentation.

Der folgende JavaScript‑Code zeigt, wie die Sichtbarkeit einer Folienfußzeile festgelegt und verwandte Aufgaben ausgeführt werden:
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **Fußzeilen‑Sichtbarkeit für untergeordnete Folien festlegen**

In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text auf der Ebene der Master‑Folie gesteuert werden, um Konsistenz über alle Layout‑Folien hinweg sicherzustellen. Aspose.Slides für Node.js ermöglicht es Ihnen, die Sichtbarkeit und den Inhalt dieser Fußzeilen‑Platzhalter auf der Master‑Folie festzulegen und diese Einstellungen auf alle untergeordneten Layout‑Folien zu übertragen. Dieser Ansatz gewährleistet einheitliche Fußzeileninformationen in Ihrer gesamten Präsentation.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Holen Sie eine Referenz auf die Master‑Folie über ihren Index.
1. Setzen Sie die Fußzeilen‑Platzhalter des Masters und aller untergeordneten Folien auf sichtbar.
1. Setzen Sie die Foliennummer‑Platzhalter des Masters und aller untergeordneten Folien auf sichtbar.
1. Setzen Sie die Datum‑Uhrzeit‑Platzhalter des Masters und aller untergeordneten Folien auf sichtbar.
1. Speichern Sie die Präsentation.

Der folgende JavaScript‑Code demonstriert diesen Vorgang:
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Was ist der Unterschied zwischen einer Master‑Folie und einer Layout‑Folie?**

Eine Master‑Folie definiert das Gesamtthema und die Standardformatierung, während Layout‑Folien spezifische Anordnungen von Platzhaltern für verschiedene Inhaltstypen festlegen.

**Kann ich eine Layout‑Folie von einer Präsentation in eine andere kopieren?**

Ja, Sie können eine Layout‑Folie aus der Layout‑Folien‑Sammlung einer Präsentation, die über die Methode [getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides) zugänglich ist, klonen und sie mit der Methode `addClone` in eine andere Präsentation einfügen.

**Was passiert, wenn ich eine Layout‑Folie lösche, die noch von einer Folie verwendet wird?**

Wenn Sie versuchen, eine Layout‑Folie zu löschen, die noch von mindestens einer Folie in der Präsentation referenziert wird, wirft Aspose.Slides eine [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/). Um dies zu vermeiden, verwenden Sie [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides), das nur die nicht verwendeten Layout‑Folien sicher entfernt.