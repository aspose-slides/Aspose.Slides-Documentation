---
title: Folienlayouts in Java anwenden oder ändern
linktitle: Folienlayout
type: docs
weight: 60
url: /de/java/slide-layout/
keywords:
- Folienlayout
- Inhaltslayout
- Platzhalter
- Präsentationsdesign
- Foliengestaltung
- ungenutztes Layout
- Fußzeilensichtbarkeit
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
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Verwalten und Anpassen von Folienlayouts in Aspose.Slides für Java. Erkunden Sie Layouttypen, die Steuerung von Platzhaltern und die Fußzeilensichtbarkeit anhand von Java-Codebeispielen."
---

## **Übersicht**

Ein Folienlayout definiert die Anordnung von Platzhalterkästchen und die Formatierung des Inhalts einer Folie. Es bestimmt, welche Platzhalter verfügbar sind und wo sie erscheinen. Folienlayouts helfen Ihnen, Präsentationen schnell und konsistent zu gestalten – egal, ob Sie etwas Einfaches oder Komplexeres erstellen. Zu den am häufigsten verwendeten Folienlayouts in PowerPoint gehören:

**Title Slide layout** – Enthält zwei Textplatzhalter: einen für den Titel und einen für den Untertitel.

**Title and Content layout** – Verfügt über einen kleineren Titelplatzhalter oben und einen größeren darunter für den Hauptinhalt (wie Text, Aufzählungspunkte, Diagramme, Bilder und mehr).

**Blank layout** – Enthält keine Platzhalter und gibt Ihnen die volle Kontrolle, die Folie von Grund auf zu gestalten.

Folienlayouts sind Teil einer Folienmaster, die die oberste Folie ist und Layout‑Stile für die Präsentation definiert. Sie können Layout‑Folien über den Folienmaster zugreifen und ändern – entweder nach Typ, Namen oder eindeutiger ID. Alternativ können Sie eine bestimmte Layout‑Folie direkt in der Präsentation bearbeiten.

Um mit Folienlayouts in Aspose.Slides für Java zu arbeiten, können Sie verwenden:
- Methoden wie [getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) und [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) in der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)
- Typen wie [ILayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/), und [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Um mehr über die Arbeit mit Masterfolien zu erfahren, lesen Sie den Artikel [Slide Master](/slides/de/java/slide-master/).
{{% /alert %}}

## **Folienlayouts zu Präsentationen hinzufügen**

Um das Aussehen und die Struktur Ihrer Folien anzupassen, müssen Sie möglicherweise neue Layout‑Folien zu einer Präsentation hinzufügen. Aspose.Slides für Java ermöglicht es Ihnen, zu prüfen, ob ein bestimmtes Layout bereits existiert, ggf. ein neues hinzuzufügen und es zu verwenden, um Folien basierend auf diesem Layout einzufügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Greifen Sie auf die [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/) zu.
1. Überprüfen Sie, ob die gewünschte Layout‑Folie bereits in der Sammlung existiert. Falls nicht, fügen Sie die benötigte Layout‑Folie hinzu.
1. Fügen Sie eine leere Folie basierend auf der neuen Layout‑Folie hinzu.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code zeigt, wie ein Folienlayout zu einer PowerPoint‑Präsentation hinzugefügt wird:
```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint-Datei repräsentiert.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Durchlaufen Sie die Layout-Folientypen, um eine Layout-Folie auszuwählen.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Eine Situation, in der die Präsentation nicht alle Layout-Typen enthält.
        // Die Präsentationsdatei enthält nur leere und benutzerdefinierte Layout-Typen.
        // Allerdings können Layout-Folien mit benutzerdefinierten Typen erkennbare Namen haben,
        // wie "Titel", "Titel und Inhalt" usw., die für die Auswahl von Layout-Folien verwendet werden können.
        // Sie können sich auch auf eine Menge von Platzhalterformen verlassen.
        // Beispielsweise sollte eine Titelfolie nur den Platzhaltertyp Titel haben, usw.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Fügen Sie eine leere Folie mit der hinzugefügten Layout-Folie ein.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Unbenutzte Layout‑Folien entfernen**

Aspose.Slides stellt die Methode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) aus der Klasse [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) bereit, mit der Sie unerwünschte und ungenutzte Layout‑Folien löschen können.

Der folgende Java‑Code zeigt, wie eine Layout‑Folie aus einer PowerPoint‑Präsentation entfernt wird:
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Platzhalter zu Folienlayouts hinzufügen**

Aspose.Slides bietet die Methode [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) , mit der Sie neue Platzhalter zu einer Layout‑Folie hinzufügen können.

Dieser Manager enthält Methoden für die folgenden Platzhalter‑Typen:

| PowerPoint‑Platzhalter | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/) Methode |
| ---------------------- | ------------------------------------------------------------ |
| ![Inhalt](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Inhalt (Vertikal)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertikal)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Bild](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagramm](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabelle](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Medium](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online-Bild](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Der folgende Java‑Code demonstriert, wie neue Platzhalter‑Formen zur Blank‑Layout‑Folie hinzugefügt werden:
```java
Presentation presentation = new Presentation();
try {
    // Holen Sie die leere Layout‑Folie.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Holen Sie den Platzhalter‑Manager der Layout‑Folie.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Fügen Sie verschiedene Platzhalter zur leeren Layout‑Folie hinzu.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Fügen Sie eine neue Folie mit dem leeren Layout hinzu.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![The placeholders on the layout slide](add_placeholders.png)

## **Footer‑Sichtbarkeit für eine Layout‑Folie festlegen**

In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text je nach Folienlayout angezeigt oder ausgeblendet werden. Aspose.Slides für Java ermöglicht es Ihnen, die Sichtbarkeit dieser Fußzeilen‑Platzhalter zu steuern. Das ist nützlich, wenn Sie möchten, dass bestimmte Layouts Fußzeileninformationen anzeigen, während andere sauber und minimal bleiben.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Holen Sie eine Referenz auf die Layout‑Folie über ihren Index.
1. Setzen Sie den Fußzeilen‑Platzhalter der Folie auf sichtbar.
1. Setzen Sie den Foliennummer‑Platzhalter auf sichtbar.
1. Setzen Sie den Datum‑Uhrzeit‑Platzhalter auf sichtbar.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code zeigt, wie die Sichtbarkeit einer Folienfußzeile gesetzt und verwandte Aufgaben ausgeführt werden:
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **Footer‑Sichtbarkeit für untergeordnete Folien festlegen**

In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text auf Ebene der Master‑Folie gesteuert werden, um Konsistenz über alle Layout‑Folien hinweg zu gewährleisten. Aspose.Slides für Java ermöglicht es Ihnen, die Sichtbarkeit und den Inhalt dieser Fußzeilen‑Platzhalter auf der Master‑Folie festzulegen und diese Einstellungen an alle untergeordneten Layout‑Folien zu propagieren. Dieser Ansatz sorgt für einheitliche Fußzeileninformationen in Ihrer gesamten Präsentation.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Holen Sie eine Referenz auf die Master‑Folie über ihren Index.
1. Setzen Sie die Fußzeilen‑Platzhalter des Masters und aller untergeordneten Folien auf sichtbar.
1. Setzen Sie die Foliennummer‑Platzhalter des Masters und aller untergeordneten Folien auf sichtbar.
1. Setzen Sie die Datum‑Uhrzeit‑Platzhalter des Masters und aller untergeordneten Folien auf sichtbar.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code demonstriert diesen Vorgang:
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Was ist der Unterschied zwischen einer Master‑Folie und einer Layout‑Folie?**

Ein Master‑Folie definiert das übergeordnete Thema und die Standardformatierung, während Layout‑Folien spezifische Anordnungen von Platzhaltern für verschiedene Inhaltsarten definieren.

**Kann ich eine Layout‑Folie von einer Präsentation in eine andere kopieren?**

Ja, Sie können eine Layout‑Folie aus der Layout‑Foliensammlung einer Präsentation klonen, zugänglich über die Methode [getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) , und sie mit der Methode `addClone` in eine andere Präsentation einfügen.

**Was passiert, wenn ich eine Layout‑Folie lösche, die noch von einer Folie verwendet wird?**

Wenn Sie versuchen, eine Layout‑Folie zu löschen, die noch von mindestens einer Folie in der Präsentation referenziert wird, wirft Aspose.Slides eine [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/). Um dies zu vermeiden, verwenden Sie [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) , das sicher nur die nicht verwendeten Layout‑Folien entfernt.