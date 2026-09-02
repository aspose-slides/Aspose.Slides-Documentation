---
title: Folienabschnitte in Präsentationen mit PHP verwalten
linktitle: Folienabschnitt
type: docs
weight: 90
url: /de/php-java/slide-section/
keywords:
- Abschnitt erstellen
- Abschnitt hinzufügen
- Abschnitt bearbeiten
- Abschnitt ändern
- Abschnittsname
- Abschnittsfolien abrufen
- Abschnittsfolien verarbeiten
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte mit Aspose.Slides für PHP via Java: Erstellen, Umbenennen, Neuordnen, Abrufen und Verarbeiten von Abschnittsfolien in PPTX‑Präsentationen."
---
## **Einführung**

Abschnitte organisieren aufeinanderfolgende Folien in benannte Gruppen, ohne den Folieninhalt zu verändern. Mit Aspose.Slides für PHP via Java können Sie über die Methode [Presentation::getSections](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSections) Abschnitte erstellen, neu anordnen, umbenennen, inspizieren und entfernen.

Abschnitte sind besonders nützlich, wenn:
- eine große Präsentation in logische Themen oder Kapitel unterteilt werden muss;
- verschiedene Foliengruppen verschiedenen Mitarbeitern zugewiesen werden;
- Folien als Gruppen verarbeitet, verschoben oder zusammengeführt werden müssen.

Wählen Sie prägnante Abschnittsnamen, die den Zweck der gruppierten Folien beschreiben. Da Abschnitte Teil der Präsentationsstruktur sind, verwenden Sie die Abschnitt‑APIs, um die Zugehörigkeit zu bestimmen, anstatt sie aus den Folienpositionen abzuleiten.

## **Erstellen und Verwalten von Abschnitten**

Verwenden Sie [SectionCollection::addSection](https://reference.aspose.com/slides/de/php-java/aspose.slides/SectionCollection/#addSection), um einen Abschnitt zu erstellen, indem Sie dessen Namen und die Startfolie angeben. Aspose.Slides ermittelt, welche Folien zum Abschnitt gehören, anhand der aktuellen Abschnittsstruktur der Präsentation.

Die gleiche [SectionCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/SectionCollection/) ermöglicht Ihnen außerdem:
- einen Abschnitt zusammen mit seinen Folien verschieben, indem Sie [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides) verwenden;
- nur die Abschnittsdefinition entfernen mit [SectionCollection::removeSection](https://reference.aspose.com/slides/de/php-java/aspose.slides/SectionCollection/#removeSection), wobei die Folien erhalten bleiben;
- einen Abschnitt und seine Folien entfernen mit [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides);
- am Ende einen leeren Abschnitt hinzufügen mit [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/de/php-java/aspose.slides/SectionCollection/#appendEmptySection).

Das folgende Beispiel erstellt zwei Abschnitte, verschiebt einen davon, entfernt ihn zusammen mit seinen Folien und fügt einen leeren Abschnitt hinzu:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $titleSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $resultsSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $titleSlide);
    $resultsSection = $presentation->getSections()->addSection("Results", $resultsSlide);

    $presentation->getSections()->reorderSectionWithSlides($resultsSection, 0);
    $presentation->getSections()->removeSectionWithSlides($resultsSection);
    $presentation->getSections()->appendEmptySection("Appendix");
} finally {
    $presentation->dispose();
}
```

Nach diesen Vorgängen enthält die Präsentation den Abschnitt `Introduction` mit seinen Folien und einen leeren Abschnitt `Appendix`. Der Abschnitt `Results` und seine Folien wurden entfernt.

## **Abschnitte umbenennen**

Um einen Abschnitt umzubenennen, rufen Sie seine Methode [Section::setName](https://reference.aspose.com/slides/de/php-java/aspose.slides/Section/#setName) auf. Die Folien des Abschnitts und seine Position bleiben unverändert.

Das folgende Beispiel erstellt einen Abschnitt und ändert seinen Namen:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $section = $presentation->getSections()->addSection("Overview", $slide);
    $section->setName("Introduction");
} finally {
    $presentation->dispose();
}
```

## **Folien aus Abschnitten abrufen**

Die Methode [Presentation::getSections](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSections) gibt eine [SectionCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/SectionCollection/) zurück, die Sie nach Index verarbeiten können. Für jedes [Section](https://reference.aspose.com/slides/de/php-java/aspose.slides/Section/) rufen Sie [Section::getSlidesListOfSection](https://reference.aspose.com/slides/de/php-java/aspose.slides/Section/#getSlidesListOfSection) auf, um die Folien zu erhalten, die derzeit zu diesem Abschnitt gehören. Die Methode gibt eine [SectionSlideCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/SectionSlideCollection/) zurück, die eine Anzahl und indexed Zugriff bietet.

Das folgende Beispiel erstellt zwei befüllte Abschnitte und einen leeren Abschnitt, gibt dann für jeden Abschnitt den [name](https://reference.aspose.com/slides/de/php-java/aspose.slides/Section/#getName), die [identifier](https://reference.aspose.com/slides/de/php-java/aspose.slides/Section/#getSectionId), die [starting slide](https://reference.aspose.com/slides/de/php-java/aspose.slides/Section/#getStartedFromSlide), die Folienanzahl und die Foliennummern aus. Es verwendet [SectionCollection::get_Item](https://reference.aspose.com/slides/de/php-java/aspose.slides/SectionCollection/#get_Item) und [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/de/php-java/aspose.slides/SectionSlideCollection/#get_Item) für den indexierten Zugriff. Für den leeren Abschnitt hat die zurückgegebene Sammlung die Größe null und `get_Item` wird nicht aufgerufen.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $firstSlide);
    $presentation->getSections()->addSection("Details", $thirdSlide);
    $presentation->getSections()->appendEmptySection("Appendix");

    $sections = $presentation->getSections();
    $sectionCount = java_values($sections->size());
    for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
        $section = $sections->get_Item($sectionIndex);
        $sectionSlides = $section->getSlidesListOfSection();
        $startingSlide = java_is_null($section->getStartedFromSlide()) ? "none" : java_values($section->getStartedFromSlide()->getSlideNumber());
        $slideCount = java_values($sectionSlides->size());

        echo "Section: " . java_values($section->getName()) . PHP_EOL;
        echo "ID: " . java_values($section->getSectionId()) . PHP_EOL;
        echo "Starting slide: " . $startingSlide . PHP_EOL;
        echo "Slide count: " . $slideCount . PHP_EOL;

        if ($slideCount > 0) {
            echo "First slide via get_Item: " . java_values($sectionSlides->get_Item(0)->getSlideNumber()) . PHP_EOL;
        }

        echo "Slide numbers:";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Die Zugehörigkeit zu einem Abschnitt wird durch die Abschnittsstruktur der Präsentation bestimmt. Berechnen Sie den Bereich eines Abschnitts nicht manuell aus [Section::getStartedFromSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/Section/#getStartedFromSlide), Folienindizes und der Startfolie des nächsten Abschnitts.

Strukturelle Änderungen können sowohl die für einen Abschnitt zurückgegebenen Folien als auch deren Foliennummern ändern. Dazu gehören das Neuordnen von Folien, das Klonen einer Folie in einen Abschnitt, das Verschieben eines Abschnitts zusammen mit seinen Folien, das Entfernen von Folien und das Entfernen von Abschnitten. Das nächste Beispiel ruft [Section::getSlidesListOfSection](https://reference.aspose.com/slides/de/php-java/aspose.slides/Section/#getSlidesListOfSection) nach jeder solchen Änderung auf, anstatt Annahmen über die früheren Grenzen des Abschnitts beizubehalten.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $firstSection = $presentation->getSections()->addSection("First", $firstSlide);
    $secondSection = $presentation->getSections()->addSection("Second", $thirdSlide);

    $printSectionSlides = function ($label, $section) {
        $sectionSlides = $section->getSlidesListOfSection();
        $slideCount = java_values($sectionSlides->size());
        echo $label . " (" . $slideCount . " slides):";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    };

    $printSectionSlides("Initially", $firstSection);

    $slidesBeforeClone = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->addClone($slidesBeforeClone->get_Item(0), $firstSection);
    $printSectionSlides("After cloning into the section", $firstSection);

    $slidesBeforeReorder = $firstSection->getSlidesListOfSection();
    $firstSectionPosition = java_values($slidesBeforeReorder->get_Item(0)->getSlideNumber()) - 1;
    $lastSlideIndex = java_values($slidesBeforeReorder->size()) - 1;
    $presentation->getSlides()->reorder($firstSectionPosition, $slidesBeforeReorder->get_Item($lastSlideIndex));
    $printSectionSlides("After reordering slides", $firstSection);

    $presentation->getSections()->reorderSectionWithSlides($firstSection, 1);
    $printSectionSlides("After moving the section", $firstSection);

    $slidesBeforeRemoval = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->remove($slidesBeforeRemoval->get_Item(0));
    $printSectionSlides("After removing a slide", $firstSection);

    $presentation->getSections()->removeSectionWithSlides($secondSection);
    $remainingSections = $presentation->getSections();
    $remainingSectionCount = java_values($remainingSections->size());
    for ($sectionIndex = 0; $sectionIndex < $remainingSectionCount; $sectionIndex++) {
        $section = $remainingSections->get_Item($sectionIndex);
        $printSectionSlides("Remaining section", $section);
    }
} finally {
    $presentation->dispose();
}
```

Rufen Sie [Section::getSlidesListOfSection](https://reference.aspose.com/slides/de/php-java/aspose.slides/Section/#getSlidesListOfSection) erneut auf, wann immer Folien oder Abschnitte neu geordnet, geklont, verschoben oder entfernt werden. Dadurch bleibt die nachfolgende Verarbeitung mit der aktuellen Präsentationsstruktur abgestimmt.

Das PPT‑Format (PowerPoint 97–2003) bewahrt keine Abschnitts‑Metadaten. Verwenden Sie diesen Arbeitsablauf mit einem Format, das Abschnitte unterstützt, z. B. PPTX; das Konvertieren zu PPT entfernt die für spätere Durchläufe benötigte Abschnittsstruktur.

## **FAQ**

**Werden Abschnitte beim Speichern im PPT‑Format (PowerPoint 97–2003) erhalten?**

Nein. Das PPT‑Format unterstützt keine Abschnitts‑Metadaten, sodass die Abschnittszuordnung beim Speichern als .ppt verloren geht.

**Kann ein kompletter Abschnitt "ausgeblendet" werden?**

Nein. Ein Abschnitt hat keinen Sichtbarkeitsstatus. Um seinen Inhalt auszublenden, rufen Sie für jede Folie im Abschnitt [Slide::setHidden](https://reference.aspose.com/slides/de/php-java/aspose.slides/Slide/#setHidden) auf.

**Wie kann ich den Abschnitt finden, der eine Folie enthält?**

Durchlaufen Sie die von [Presentation::getSections](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation/#getSections) zurückgegebene Sammlung, rufen Sie für jeden Abschnitt [Section::getSlidesListOfSection](https://reference.aspose.com/slides/de/php-java/aspose.slides/Section/#getSlidesListOfSection) auf und vergleichen Sie die zurückgegebenen Folien mit der Ziel‑Folie. Für einen nicht leeren Abschnitt gibt [Section::getStartedFromSlide](https://reference.aspose.com/slides/de/php-java/aspose.slides/Section/#getStartedFromSlide) seine erste Folie zurück; für einen leeren Abschnitt liefert er `null`.