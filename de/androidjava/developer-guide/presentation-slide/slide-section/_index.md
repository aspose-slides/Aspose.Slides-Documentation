---
title: Verwalten von Folienabschnitten in Präsentationen auf Android
linktitle: Folienabschnitt
type: docs
weight: 90
url: /de/androidjava/slide-section/
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
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte mit Aspose.Slides für Android über Java: Erstellen, Umbenennen, Neuordnen, Abrufen und Verarbeiten von Abschnittsfolien in PPTX‑Präsentationen."
---
## **Einleitung**

Abschnitte organisieren aufeinanderfolgende Folien in benannte Gruppen, ohne den Folieninhalt zu ändern. Mit Aspose.Slides für Android über Java können Sie Abschnitte erstellen, neu anordnen, umbenennen, inspizieren und entfernen mittels der [Presentation.getSections](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSections--)‑Methode.

Abschnitte sind besonders nützlich, wenn:

- eine große Präsentation in logische Themen oder Kapitel unterteilt werden muss;
- verschiedene Gruppen von Folien verschiedenen Mitarbeitenden zugewiesen werden;
- Folien als Gruppen verarbeitet, verschoben oder zusammengeführt werden müssen.

Verwenden Sie prägnante Abschnittsnamen, die den Zweck der gruppierten Folien beschreiben. Da Abschnitte Teil der Präsentationsstruktur sind, nutzen Sie die Abschnitt‑APIs, um die Zugehörigkeit zu bestimmen, anstatt sie aus Folienpositionen abzuleiten.

## **Abschnitte erstellen und verwalten**

Verwenden Sie [ISectionCollection.addSection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) um einen Abschnitt zu erstellen, indem Sie dessen Namen und die Startfolie angeben. Aspose.Slides ermittelt, welche Folien zu dem Abschnitt gehören, anhand der aktuellen Abschnittsstruktur der Präsentation.

Die gleiche [ISectionCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isectioncollection/) ermöglicht Ihnen außerdem:

- einen Abschnitt zusammen mit seinen Folien verschieben, indem Sie [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-) verwenden;
- nur die Abschnittsdefinition entfernen mit [ISectionCollection.removeSection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-), wobei die Folien erhalten bleiben;
- einen Abschnitt und seine Folien entfernen mit [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- einen leeren Abschnitt am Ende hinzufügen mit [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

Das folgende Beispiel erstellt zwei Abschnitte, verschiebt einen davon, entfernt ihn zusammen mit seinen Folien und fügt einen leeren Abschnitt an:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Nach diesen Vorgängen enthält die Präsentation den `Introduction`‑Abschnitt mit seinen Folien und einen leeren `Appendix`‑Abschnitt. Der `Results`‑Abschnitt und seine Folien wurden entfernt.

## **Abschnitte umbenennen**

Um einen Abschnitt umzubenennen, rufen Sie dessen [ISection.setName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isection/#setName-java.lang.String-)‑Methode auf. Die Folien und die Position des Abschnitts bleiben unverändert.

Das folgende Beispiel erstellt einen Abschnitt und ändert seinen Namen:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Folien aus Abschnitten abrufen**

Die Methode [Presentation.getSections](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSections--) gibt eine [ISectionCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isectioncollection/) zurück, über die Sie iterieren können. Für jedes [ISection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isection/) rufen Sie [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) auf, um die Folien zu erhalten, die derzeit zu diesem Abschnitt gehören. Die Methode gibt eine [ISectionSlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isectionslidecollection/) zurück, die eine Zählung, indizierten Zugriff und Iteration bereitstellt.

Das folgende Beispiel erstellt zwei befüllte Abschnitte und einen leeren Abschnitt, gibt dann für jeden Abschnitt den [name](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isection/#getName--) den [identifier](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isection/#getSectionId--) die [starting slide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) die Folienanzahl und die Foliennummern aus. Es verwendet [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) um die erste Folie zu lesen und eine erweiterte `for`‑Anweisung, um jede Folie zu verarbeiten. Für den leeren Abschnitt hat die zurückgegebene Sammlung die Größe Null, die Methode wird nicht aufgerufen und die Iteration führt keine Operationen aus.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

Die Zugehörigkeit zu einem Abschnitt wird durch die Abschnittsstruktur der Präsentation bestimmt. Berechnen Sie den Bereich eines Abschnitts nicht manuell aus [ISection.getStartedFromSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) Folienindizes und der Startfolie des nächsten Abschnitts.

Strukturelle Änderungen können sowohl die für einen Abschnitt zurückgegebenen Folien als auch deren Foliennummern verändern. Dazu gehören das Neuanordnen von Folien, das Klonen einer Folie in einen Abschnitt, das Verschieben eines Abschnitts zusammen mit seinen Folien, das Entfernen von Folien und das Entfernen von Abschnitten. Das nächste Beispiel ruft nach jeder solchen Änderung [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) auf, anstatt Annahmen über die früheren Grenzen des Abschnitts beizubehalten.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

Rufen Sie [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) erneut auf, sobald Folien oder Abschnitte neu geordnet, geklont, verschoben oder entfernt werden. Dadurch bleibt die nachfolgende Verarbeitung mit der aktuellen Präsentationsstruktur synchron.

Das PPT‑Format (PowerPoint 97–2003) bewahrt keine Abschnitts‑Metadaten. Verwenden Sie diesen Workflow mit einem Format, das Abschnitte unterstützt, wie PPTX; die Konvertierung nach PPT entfernt die für spätere Iterationen benötigte Abschnittsstruktur.

## **FAQ**

**Werden Abschnitte beim Speichern im PPT‑Format (PowerPoint 97–2003) erhalten?**

Nein. Das PPT‑Format unterstützt keine Abschnitts‑Metadaten, sodass die Abschnitts‑Gruppierung beim Speichern als .ppt verloren geht.

**Kann ein ganzer Abschnitt „ausgeblendet“ werden?**

Nein. Ein Abschnitt besitzt keinen Sichtbarkeitszustand. Um dessen Inhalte auszublenden, rufen Sie für jede Folie im Abschnitt [ISlide.setHidden](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/#setHidden-boolean-) auf.

**Wie kann ich den Abschnitt finden, der eine Folie enthält?**

Iterieren Sie über die von [Presentation.getSections](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#getSections--) zurückgegebene Sammlung, rufen Sie für jeden Abschnitt [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) auf und vergleichen Sie die zurückgegebenen Folien mit der Ziel‑Folien. Für einen nicht‑leeren Abschnitt gibt [ISection.getStartedFromSlide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) seine erste Folie zurück; für einen leeren Abschnitt gibt er `null` zurück.