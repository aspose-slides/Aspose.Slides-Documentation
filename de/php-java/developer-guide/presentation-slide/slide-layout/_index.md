---
title: Folienlayouts in PHP anwenden oder ändern
linktitle: Folienlayout
type: docs
weight: 60
url: /de/php-java/slide-layout/
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
- PHP
- Aspose.Slides
description: "Verwalten und passen Sie Folienlayouts in Aspose.Slides für PHP über Java an. Erkunden Sie Layouttypen, die Steuerung von Platzhaltern und die Fußzeilensichtbarkeit anhand von Codebeispielen."
---

## **Übersicht**

Ein Folienlayout definiert die Anordnung von Platzhalterkästchen und die Formatierung des Inhalts einer Folie. Es steuert, welche Platzhalter verfügbar sind und wo sie angezeigt werden. Folienlayouts helfen Ihnen, Präsentationen schnell und konsistent zu gestalten – egal, ob Sie etwas Einfaches oder Komplexeres erstellen. Zu den häufigsten Folienlayouts in PowerPoint gehören:

**Titelfolienlayout** – Enthält zwei Textplatzhalter: einen für den Titel und einen für den Untertitel.

**Titel‑ und Inhaltslayout** – Enthält einen kleineren Titelplatzhalter oben und einen größeren darunter für Hauptinhalte (wie Text, Aufzählungen, Diagramme, Bilder und mehr).

**Leeres Layout** – Enthält keine Platzhalter, sodass Sie die Folie von Grund auf neu gestalten können.

Folienlayouts sind Teil eines Folienmasters, der die Folie auf höchster Ebene ist und Layout‑Stile für die Präsentation definiert. Sie können Layout‑Folien über den Folienmaster zugreifen und ändern – entweder nach Typ, Name oder eindeutiger ID. Alternativ können Sie eine bestimmte Layout‑Folie direkt in der Präsentation bearbeiten.

Um mit Folienlayouts in Aspose.Slides für PHP zu arbeiten, können Sie verwenden:

- Methoden wie [getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides) und [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters) in der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
- Typen wie [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutplaceholdermanager/), und [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Erfahren Sie mehr über die Arbeit mit Masterfolien, indem Sie den Artikel [Slide Master](/slides/de/php-java/slide-master/) lesen.
{{% /alert %}}

## **Folienlayouts zu Präsentationen hinzufügen**

Um das Aussehen und die Struktur Ihrer Folien anzupassen, müssen Sie möglicherweise neue Layout‑Folien zu einer Präsentation hinzufügen. Aspose.Slides für PHP ermöglicht es Ihnen, zu prüfen, ob ein bestimmtes Layout bereits existiert, bei Bedarf ein neues hinzuzufügen und es zum Einfügen von Folien basierend auf diesem Layout zu verwenden.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Greifen Sie auf die [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/) zu.
3. Überprüfen Sie, ob die gewünschte Layout‑Folie bereits in der Sammlung existiert. Falls nicht, fügen Sie die benötigte Layout‑Folie hinzu.
4. Fügen Sie eine leere Folie basierend auf der neuen Layout‑Folie hinzu.
5. Speichern Sie die Präsentation.

Der folgende PHP‑Code demonstriert, wie man ein Folienlayout zu einer PowerPoint‑Präsentation hinzufügt:
```php
// Instanziieren Sie die Presentation-Klasse, die eine PowerPoint-Datei darstellt.
$presentation = new Presentation("Sample.pptx");
try {
    // Durchlaufen Sie die Layout-Folientypen, um eine Layout-Folie auszuwählen.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Eine Situation, in der die Präsentation nicht alle Layout-Typen enthält.
        // Die Präsentationsdatei enthält nur Blank- und Custom-Layout-Typen.
        // Allerdings können Layout-Folien mit benutzerdefinierten Typen erkennbare Namen haben,
        // wie „Title“, „Title and Content“ usw., die für die Auswahl von Layout-Folien verwendet werden können.
        // Sie können sich auch auf eine Menge von Platzhalter‑Formtypen stützen.
        // Zum Beispiel sollte eine Titelfolie nur den Titel‑Platzhaltertyp haben, und so weiter.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Fügen Sie eine leere Folie mit der hinzugefügten Layout‑Folie ein.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Speichern Sie die Präsentation auf dem Datenträger.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Entfernen nicht verwendeter Layout‑Folien**

Aspose.Slides stellt die Methode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) der Klasse [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) bereit, mit der Sie nicht benötigte und ungenutzte Layout‑Folien löschen können.

Der folgende PHP‑Code zeigt, wie man eine Layout‑Folie aus einer PowerPoint‑Präsentation entfernt:
```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Platzhalter zu Folienlayouts hinzufügen**

Aspose.Slides bietet die Methode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/#getPlaceholderManager) , mit der Sie neue Platzhalter zu einer Layout‑Folie hinzufügen können.

Dieser Manager enthält Methoden für die folgenden Platzhaltertypen:

| PowerPoint‑Platzhalter | [LayoutPlaceholderManager]-Methode |
| ---------------------- | ----------------------------------- |
| ![Inhalt](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Inhalt (Vertikal)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertikal)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Bild](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagramm](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabelle](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Medium](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online‑Bild](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Der folgende PHP‑Code demonstriert, wie man neue Platzhalterformen zum leeren Layout‑Folie hinzufügt:
```php
$presentation = new Presentation();
try {
    // Holen Sie die leere Layout-Folie.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Holen Sie den Platzhalter-Manager der Layout-Folie.
    $placeholderManager = $layout->getPlaceholderManager();

    // Fügen Sie verschiedene Platzhalter zur leeren Layout-Folie hinzu.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Fügen Sie eine neue Folie mit dem leeren Layout hinzu.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


Das Ergebnis:

![Die Platzhalter auf der Layout‑Folie](add_placeholders.png)

## **Footer‑Sichtbarkeit für eine Layout‑Folie festlegen**

In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text je nach Folienlayout ein- oder ausgeblendet werden. Aspose.Slides für PHP ermöglicht die Steuerung der Sichtbarkeit dieser Fußzeilen‑Platzhalter. Das ist nützlich, wenn bestimmte Layouts Fußzeileninformationen anzeigen sollen, während andere sauber und minimal bleiben.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Rufen Sie eine Layout‑Folie‑Referenz anhand ihres Index ab.
3. Setzen Sie den Fußzeilen‑Platzhalter der Folie auf sichtbar.
4. Setzen Sie den Folienzahl‑Platzhalter auf sichtbar.
5. Setzen Sie den Datums‑Zeit‑Platzhalter auf sichtbar.
6. Speichern Sie die Präsentation.

Der folgende PHP‑Code zeigt, wie man die Sichtbarkeit einer Folienfußzeile einstellt und verwandte Aufgaben ausführt:
```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```


## **Footer‑Sichtbarkeit für untergeordnete Folien festlegen**

In PowerPoint‑Präsentationen können Fußzeilenelemente wie Datum, Foliennummer und benutzerdefinierter Text auf Ebene der Masterfolie gesteuert werden, um Konsistenz über alle Layout‑Folien hinweg sicherzustellen. Aspose.Slides für PHP ermöglicht das Festlegen der Sichtbarkeit und des Inhalts dieser Fußzeilen‑Platzhalter auf der Masterfolie und das Übertragen dieser Einstellungen auf alle untergeordneten Layout‑Folien. Dieser Ansatz gewährleistet einheitliche Fußzeileninformationen in der gesamten Präsentation.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Rufen Sie eine Referenz zur Masterfolie anhand ihres Index ab.
3. Setzen Sie die Fußzeilen‑Platzhalter der Master‑ und aller untergeordneten Folien auf sichtbar.
4. Setzen Sie die Folienzahl‑Platzhalter der Master‑ und aller untergeordneten Folien auf sichtbar.
5. Setzen Sie die Datums‑Zeit‑Platzhalter der Master‑ und aller untergeordneten Folien auf sichtbar.
6. Speichern Sie die Präsentation.

Der folgende PHP‑Code demonstriert diesen Vorgang:
```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**Was ist der Unterschied zwischen einer Masterfolie und einer Layoutfolie?**

Eine Masterfolie definiert das gesamte Thema und die Standardformatierung, während Layout‑Folien spezifische Anordnungen von Platzhaltern für verschiedene Inhaltsarten festlegen.

**Kann ich eine Layout‑Folie von einer Präsentation in eine andere kopieren?**

Ja, Sie können eine Layout‑Folie aus der Layout‑Folie‑Sammlung einer Präsentation, die über die Methode [getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides) zugänglich ist, klonen und sie mit der Methode `addClone` in eine andere Präsentation einfügen.

**Was passiert, wenn ich eine Layout‑Folie lösche, die noch von einer Folie verwendet wird?**

Wenn Sie versuchen, eine Layout‑Folie zu löschen, die noch von mindestens einer Folie in der Präsentation referenziert wird, wirft Aspose.Slides eine [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/). Um dies zu vermeiden, verwenden Sie [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides), das sicher nur die nicht verwendeten Layout‑Folien entfernt.