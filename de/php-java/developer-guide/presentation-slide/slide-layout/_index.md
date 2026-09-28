---
title: Anwenden oder Ändern von Folienlayouts in PHP
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
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Anwenden, Erstellen und Ändern von Folienlayouts in Aspose.Slides für PHP über Java, Platzhalter hinzufügen, ungenutzte Layouts entfernen und die Sichtbarkeit von Fußzeilen steuern."
---
## **Übersicht**

Ein Folienlayout definiert die Positionen und Formatierungen von Platzhaltern wie Titeln, Text, Bildern, Diagrammen und Tabellen. Das Anwenden eines Layouts verleiht Folien eine konsistente Struktur, während jede Folie ihren eigenen Inhalt enthalten kann.

Die häufigsten Layouts umfassen:

- **Titel‑Folie**: Enthält Platzhalter für Titel und Untertitel.
- **Titel und Inhalt**: Enthält einen Titel‑Platzhalter und einen allgemeinen Inhalts‑Platzhalter.
- **Leer**: Enthält keine Inhalts­platzhalter und ist nützlich, wenn jede Form manuell positioniert wird.

## **Verstehen der Layout‑Vererbung**

Eine Präsentation hat drei miteinander verbundene Ebenen:

1. Eine [master slide](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/) definiert das Design, gemeinsame Formatierungen, Hintergründe und gemeinsame Objekte.
1. Eine [layout slide](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/) gehört zu einem Master und definiert eine bestimmte Anordnung von Platzhaltern.
1. Eine [normal slide](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/) verwendet ein Layout und speichert den für diese Folie eingegebenen Inhalt.

Eine normale Folie erbt Design und Formatierung von ihrem Layout, und das Layout erbt vom Master. Ein direkt auf einer normalen Folie festgelegter Wert überschreibt den vererbten Wert auf dieser Ebene. Wenn eine normale Folie erstellt wird, werden ihre Platzhalter‑Formen aus dem ausgewählten Layout generiert, während der in diese Platzhalter eingegebene Inhalt zur normalen Folie gehört.

Fügen Sie einem Layout die erforderlichen Platzhalter hinzu, bevor Sie Folien daraus erstellen. Das spätere Hinzufügen eines weiteren Platzhalters zu einem Layout fügt nicht automatisch die entsprechende Platzhalter‑Form zu bestehenden normalen Folien hinzu.

Diese Beziehung hat zwei wichtige Konsequenzen:

- Das Ändern von vererbten Formatierungen oder der vorhandenen Platzhaltergeometrie in einem Layout kann jede davon abhängige Folie aktualisieren. Vor dem Bearbeiten eines bereits verwendeten Layouts sollten Sie dessen abhängige Folien prüfen und die resultierende Präsentation überprüfen.
- Ein Layout, das noch von einer Folie verwendet wird, kann nicht entfernt werden. Ordnen Sie seine abhängigen Folien zuerst einem anderen Layout zu oder entfernen Sie nur ungenutzte Layouts.

Weitere Informationen zur obersten Ebene dieser Hierarchie finden Sie unter [Slide Master](/slides/de/php-java/slide-master/).

Um geerbte Logos oder dekorative Master‑Formen auf einer Folie oder über ein gemeinsames Layout auszublenden, siehe [Control the Visibility of Master Graphics](/slides/de/php-java/slide-master/). Das Beispiel vergleicht zwei Folien, die denselben Master verwenden.

## **Auswahl und Anwendung eines Folienlayouts**

Verwenden Sie einen Layouttyp, wenn die Präsentation den standardmäßigen PowerPoint‑Layoutdefinitionen folgt. Layout‑Namen können vom Benutzer bearbeitet und lokalisiert werden, sodass eine Auswahl anhand des Namens weniger zuverlässig ist, es sei denn, Sie kontrollieren die Quellvorlage.

Das folgende Beispiel sucht nach **Title and Content** im ersten Master. Ist dieses Layout nicht verfügbar, wird bewusst auf **Blank** zurückgegriffen. Die zweite Null‑Prüfung ist erforderlich, weil eine Präsentation ausschließlich benutzerdefinierte Layouts enthalten kann. Das ausgewählte Layout wird dann über die Methode [Slide.setLayoutSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#setLayoutSlide) auf die erste normale Folie angewendet.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ändern des Layouts einer Folie entfernt nicht die direkt zur Folie hinzugefügten normalen Formen. Allerdings können sich Platzhalterpositionen, vererbte Formatierungen und die Zuordnung zwischen vorhandenen Platzhaltern und dem neuen Layout ändern, sodass Sie die Ausgabe prüfen sollten, wenn Sie zwischen deutlich unterschiedlichen Layouts wechseln.

## **Hinzufügen einer Layout‑Folie**

Auswahl und Erstellung sind getrennte Vorgänge. Das vorherige Beispiel wählt ein bestehendes Layout aus; es erstellt keines. Um ein Layout zu erstellen, rufen Sie die Methode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterlayoutslidecollection/#add) auf der Layout‑Sammlung des Ziel‑Masters auf.

Das folgende Beispiel fügt stets ein neues **Title and Content**‑Layout mit dem Namen `Report Title and Content` hinzu und erstellt anschließend eine normale Folie, die darauf basiert. Layout‑Namen müssen innerhalb der Sammlung eindeutig sein.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Fügen Sie ein Layout nur hinzu, wenn die Vorlage tatsächlich eine weitere wiederverwendbare Struktur benötigt. Existiert bereits ein passendes Layout, wählen Sie es aus und verwenden es erneut, anstatt ein Duplikat zu erstellen.

## **Platzhalter zu einer Layout‑Folie hinzufügen**

Die Methode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/#getPlaceholderManager) liefert einen [LayoutPlaceholderManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutplaceholdermanager/), mit dem Platzhalter‑Formen zu einem Layout hinzugefügt werden können.

| PowerPoint‑Platzhalter              | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![Inhalt](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Inhalt (Vertikal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertikal)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Bild](picture.png)                | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagramm](chart.png)              | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabelle](table.png)               | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Medien](media.png)                | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online‑Bild](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Das folgende Beispiel prüft, ob das **Blank**‑Layout existiert, fügt ihm vier Platzhalter hinzu und erstellt anschließend eine normale Folie, die das modifizierte Layout verwendet. Die Reihenfolge ist beabsichtigt: Die Platzhalter werden hinzugefügt, bevor die normale Folie erstellt wird, sodass Aspose.Slides die entsprechenden Platzhalter‑Formen auf dieser Folie erzeugen kann.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![Die Platzhalter auf der Layout‑Folie](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Das Ändern vererbter Formatierungen oder der Geometrie vorhandener Layout‑Platzhalter kann abhängige Folien beeinflussen. Ein neu hinzugefügter Layout‑Platzhalter wird nicht rückwirkend in bestehende normale Folien eingefügt. Testen Sie Layout‑Änderungen an einer Kopie der Präsentation und prüfen Sie jede abhängige Folie.
{{% /alert %}}

## **Entfernen nicht verwendeter Layout‑Folien**

Verwenden Sie die Methode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/compress/#removeUnusedLayoutSlides), um Layouts zu entfernen, auf die keine normale Folie verweist. Die Methode lässt weiterhin verwendete Layouts unverändert.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Um ein bestimmtes Layout zu entfernen, verwenden Sie zuerst dessen Methode [hasDependingSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/#hasDependingSlides) oder [getDependingSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/#getDependingSlides). Ordnen Sie alle abhängigen Folien neu zu, bevor Sie [LayoutSlide.remove](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/#remove) aufrufen. Der Versuch, ein verwendetes Layout zu entfernen, löst eine [PptxEditException](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxeditexception/) aus.

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einer Layout‑Folie**

Ein Layout besitzt eigene Fußzeilen-, Folien‑Nummer‑ und Datum‑Uhrzeit‑Platzhalter. Verwenden Sie die Methode [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/#getHeaderFooterManager), um diese Platzhalter für ein Layout zu steuern. Das ist nützlich, wenn beispielsweise Inhalts‑Layouts Fußzeilen anzeigen sollen, Titellayouts jedoch nicht.

Das folgende Beispiel wählt ein Layout sicher aus und macht dessen Fußzeilen‑Elemente sichtbar:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Steuerung der Fußzeilen‑Sichtbarkeit auf einem Master und dessen untergeordneten Layouts**

Um konsistente Fußzeilen‑Einstellungen über eine Master‑Hierarchie hinweg anzuwenden, verwenden Sie die Methode [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Die Propagations‑Methoden von [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/de/php-java/aspose.slides/masterslideheaderfootermanager/) wirken auf den Master sowie dessen abhängige Layout‑Folien und normalen Folien; sie richten sich nicht nur an eine einzelne normale Folie.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Was ist der Unterschied zwischen einer Master‑Folie und einer Layout‑Folie?**

Eine Master‑Folie definiert das Design und die gemeinsamen Formatierungen der Präsentation. Eine Layout‑Folie gehört zu einem Master und definiert eine wiederverwendbare Anordnung von Platzhaltern. Normale Folien verwenden diese Layouts und speichern folienspezifischen Inhalt.

**Kann ich eine Layout‑Folie von einer Präsentation in eine andere kopieren?**

Ja. Fügen Sie mit der Methode [addClone](https://reference.aspose.com/slides/de/php-java/aspose.slides/globallayoutslidecollection/#addClone) eine Kopie zur Ziel‑Sammlung hinzu. Beim Kopieren zwischen Präsentationen sollten Sie außerdem Schriftarten, Designs, Bilder und andere vom Quell‑Layout verwendete Ressourcen überprüfen.

**Was passiert, wenn ich ein bereits verwendetes Layout ändere?**

Abhängige Folien übernehmen die Layout‑Änderungen, sofern sie die betroffenen Formatierungen oder Objekte nicht lokal überschreiben. Damit können sich die Platzhaltergeometrie und das vererbte Styling auf vielen Folien gleichzeitig ändern. Verwenden Sie [getDependingSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/layoutslide/#getDependingSlides), um die betroffenen Folien zu ermitteln, bevor Sie das Layout bearbeiten.

**Was passiert, wenn ich ein noch verwendetes Layout entferne?**

Aspose.Slides wirft eine [PptxEditException](https://reference.aspose.com/slides/de/php-java/aspose.slides/pptxeditexception/). Ordnen Sie zuerst die abhängigen Folien neu zu, oder verwenden Sie [removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/compress/#removeUnusedLayoutSlides), um nur nicht referenzierte Layouts zu entfernen.