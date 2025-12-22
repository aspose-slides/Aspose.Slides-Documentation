---
title: Folienlayouts auf Android anwenden oder ändern
linktitle: Folienlayout
type: docs
weight: 60
url: /de/androidjava/slide-layout/
keywords:
- Folienlayout
- Inhaltslayout
- Platzhalter
- Präsentationsdesign
- Foliendesign
- unbenutztes Layout
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
- Android
- Java
- Aspose.Slides
description: "Verwalten und Anpassen von Folienlayouts in Aspose.Slides für Android. Erkunden Sie Layouttypen, Platzhaltersteuerung und Fußzeilensichtbarkeit anhand von Java-Codebeispielen."
---

## **Übersicht**

Ein Folienlayout definiert die Anordnung von Platzhalterkästen und die Formatierung des Inhalts einer Folie. Es steuert, welche Platzhalter verfügbar sind und wo sie erscheinen. Folienlayouts helfen Ihnen, Präsentationen schnell und einheitlich zu gestalten – egal, ob Sie etwas Einfaches oder Komplexeres erstellen. Zu den gängigsten Folienlayouts in PowerPoint gehören:

**Titel‑Folienlayout** – Enthält zwei Textplatzhalter: einen für den Titel und einen für den Untertitel.

**Titel‑und‑Inhalt‑Layout** – Verfügt über einen kleineren Titelplatzhalter oben und einen größeren darunter für den Hauptinhalt (wie Text, Aufzählungspunkte, Diagramme, Bilder und mehr).

**Leeres Layout** – Enthält keine Platzhalter, sodass Sie die Folie von Grund auf neu gestalten können.

Folienlayouts sind Teil einer Folienmaster, die die oberste Folie ist und Layout‑Stile für die Präsentation definiert. Sie können Layout‑Folien über die Folienmaster – entweder nach Typ, Name oder eindeutiger ID – abrufen und ändern. Alternativ können Sie eine bestimmte Layout‑Folie direkt in der Präsentation bearbeiten.

Um mit Folienlayouts in Aspose.Slides für Android zu arbeiten, können Sie verwenden:

- Methoden wie [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) und [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) in der Klasse [Präsentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)
- Typen wie [ILayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) und [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Um mehr über die Arbeit mit Folienmastern zu erfahren, lesen Sie den Artikel [Folienmaster](/slides/de/androidjava/slide-master/).
{{% /alert %}}

## **Folienlayouts zu Präsentationen hinzufügen**

Um das Aussehen und die Struktur Ihrer Folien anzupassen, müssen Sie möglicherweise neue Layout‑Folien zu einer Präsentation hinzufügen. Aspose.Slides für Android ermöglicht es Ihnen, zu prüfen, ob ein bestimmtes Layout bereits existiert, bei Bedarf ein neues hinzuzufügen und es zum Einfügen von Folien basierend auf diesem Layout zu verwenden.

1. Erstellen Sie eine Instanz der Klasse [Präsentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Greifen Sie auf die [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/) zu.
1. Prüfen Sie, ob die gewünschte Layout‑Folie bereits in der Sammlung existiert. Falls nicht, fügen Sie das benötigte Layout hinzu.
1. Fügen Sie eine leere Folie basierend auf dem neuen Layout hinzu.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code zeigt, wie man ein Folienlayout zu einer PowerPoint‑Präsentation hinzufügt:
```java
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint-Datei darstellt.
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
        // wie "Titel", "Titel und Inhalt", usw., die für die Auswahl von Layout-Folien verwendet werden können.
        // Sie können sich auch auf ein Set von Platzhalterformen verlassen.
        // Zum Beispiel sollte eine Titelfolie nur den Titel-Platzhaltertyp haben, und so weiter.
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


## **Ungenutzte Layout‑Folien entfernen**

Aspose.Slides stellt die Methode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) aus der Klasse [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) bereit, um nicht mehr benötigte Layout‑Folien zu löschen.

Der folgende Java‑Code zeigt, wie man ein Layout‑Folie aus einer PowerPoint‑Präsentation entfernt:
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Platzhalter zu Layout‑Folien hinzufügen**

Aspose.Slides bietet die Methode [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) an, mit der Sie neue Platzhalter zu einer Layout‑Folie hinzufügen können.

Dieser Manager enthält Methoden für die folgenden Platzhaltertypen:

| PowerPoint‑Platzhalter               | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/)‑Methode |
| ------------------------------------ | ----------------------------------------------------------------------------------------------------------------------------------- |
| ![Inhalt](content.png)               | addContentPlaceholder(float x, float y, float width, float height)                                                               |
| ![Inhalt (Vertikal)](contentV.png)   | addVerticalContentPlaceholder(float x, float y, float width, float height)                                                       |
| ![Text](text.png)                    | addTextPlaceholder(float x, float y, float width, float height)                                                                   |
| ![Text (Vertikal)](textV.png)        | addVerticalTextPlaceholder(float x, float y, float width, float height)                                                          |
| ![Bild](picture.png)                 | addPicturePlaceholder(float x, float y, float width, float height)                                                               |
| ![Diagramm](chart.png)               | addChartPlaceholder(float x, float y, float width, float height)                                                                 |
| ![Tabelle](table.png)                | addTablePlaceholder(float x, float y, float width, float height)                                                                 |
| ![SmartArt](smartart.png)            | addSmartArtPlaceholder(float x, float y, float width, float height)                                                              |
| ![Medium](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height)                                                                 |
| ![Online‑Bild](onlineimage.png)      | addOnlineImagePlaceholder(float x, float y, float width, float height)                                                          |

Der folgende Java‑Code demonstriert, wie man neue Platzhalterformen zum leeren Layout‑Folie hinzufügt:
```java
Presentation presentation = new Presentation();
try {
    // Holen Sie die leere Layout-Folie.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Holen Sie den Platzhalter-Manager der Layout-Folie.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Fügen Sie verschiedene Platzhalter zur leeren Layout-Folie hinzu.
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

![Die Platzhalter auf der Layoutfolie](add_placeholders.png)

## **Fußzeilen‑Sichtbarkeit für eine Layout‑Folie festlegen**

In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text je nach Layout ein‑ oder ausgeblendet werden. Aspose.Slides für Android ermöglicht die Steuerung der Sichtbarkeit dieser Fußzeilen‑Platzhalter. Das ist nützlich, wenn bestimmte Layouts Fußzeileninformationen anzeigen sollen, während andere sauber und minimal bleiben.

1. Erstellen Sie eine Instanz der Klasse [Präsentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Holen Sie sich eine Layout‑Folie‑Referenz über deren Index.
1. Setzen Sie den Fußzeilen‑Platzhalter der Folie auf sichtbar.
1. Setzen Sie den Folien‑Nummern‑Platzhalter auf sichtbar.
1. Setzen Sie den Datum‑Zeit‑Platzhalter auf sichtbar.
1. Speichern Sie die Präsentation.

Der folgende Java‑Code zeigt, wie man die Sichtbarkeit einer Folienfußzeile einstellt und verwandte Aufgaben ausführt:
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


## **Fußzeilen‑Sichtbarkeit für untergeordnete Folien festlegen**

In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text auf der Ebene der Masterfolie gesteuert werden, um Konsistenz über alle Layout‑Folien hinweg sicherzustellen. Aspose.Slides für Android ermöglicht das Festlegen der Sichtbarkeit und des Inhalts dieser Fußzeilen‑Platzhalter auf der Master‑Folie und die Weitergabe dieser Einstellungen an alle untergeordneten Layout‑Folien. Dieser Ansatz sorgt für einheitliche Fußzeileninformationen in der gesamten Präsentation.

1. Erstellen Sie eine Instanz der Klasse [Präsentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Holen Sie sich eine Referenz zur Master‑Folie über deren Index.
1. Setzen Sie die Fußzeilen‑Platzhalter von Master und allen untergeordneten Folien auf sichtbar.
1. Setzen Sie die Folien‑Nummern‑Platzhalter von Master und allen untergeordneten Folien auf sichtbar.
1. Setzen Sie die Datum‑Zeit‑Platzhalter von Master und allen untergeordneten Folien auf sichtbar.
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

Eine Master‑Folie definiert das Gesamtthema und die Standardformatierung, während Layout‑Folien bestimmte Anordnungen von Platzhaltern für verschiedene Inhaltstypen festlegen.

**Kann ich eine Layout‑Folie von einer Präsentation in eine andere kopieren?**

Ja, Sie können eine Layout‑Folie aus der Layout‑Foliensammlung einer Präsentation (zugänglich über die Methode [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--)) klonen und sie mit der `addClone`‑Methode in eine andere Präsentation einfügen.

**Was passiert, wenn ich eine Layout‑Folie lösche, die noch von einer Folie verwendet wird?**

Wenn Sie versuchen, eine Layout‑Folie zu löschen, die mindestens von einer Folie in der Präsentation referenziert wird, wirft Aspose.Slides eine [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/). Verwenden Sie stattdessen [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-), um nur nicht genutzte Layout‑Folien sicher zu entfernen.