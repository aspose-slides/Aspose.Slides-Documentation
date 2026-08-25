---
title: Folienabschnitte in Präsentationen mit JavaScript verwalten
linktitle: Folienabschnitt
type: docs
weight: 90
url: /de/nodejs-java/slide-section/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte mit Aspose.Slides für Node.js via Java: Erstellen, umbenennen, neu anordnen, abrufen und verarbeiten Sie Abschnittsfolien in PPTX‑Präsentationen."
---
## **Einleitung**

Abschnitte organisieren aufeinanderfolgende Folien in benannte Gruppen, ohne den Folieninhalt zu ändern. Mit Aspose.Slides für Node.js über Java können Sie Abschnitte erstellen, neu anordnen, umbenennen, prüfen und entfernen über die [Presentation.getSections](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getSections)-Methode.

Abschnitte sind besonders nützlich, wenn:

- eine große Präsentation in logische Themen oder Kapitel unterteilt werden muss;
- verschiedene Foliengruppen verschiedenen Mitarbeitern zugewiesen werden;
- Folien als Gruppen verarbeitet, verschoben oder zusammengeführt werden müssen.

Wählen Sie prägnante Abschnittsnamen, die den Zweck der gruppierten Folien beschreiben. Da Abschnitte Teil der Präsentationsstruktur sind, verwenden Sie die Abschnitt‑APIs, um die Zugehörigkeit zu bestimmen, anstatt sie aus Folienpositionen abzuleiten.

## **Erstellen und Verwalten von Abschnitten**

Verwenden Sie [SectionCollection.addSection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sectioncollection/#addSection), um einen Abschnitt zu erstellen, indem Sie dessen Namen und die Startfolie angeben. Aspose.Slides ermittelt, welche Folien zum Abschnitt gehören, anhand der aktuellen Abschnittsstruktur der Präsentation.

Die gleiche [SectionCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sectioncollection/) ermöglicht Ihnen außerdem:

- einen Abschnitt zusammen mit seinen Folien verschieben, indem Sie [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) verwenden;
- nur die Abschnittsdefinition entfernen mit [SectionCollection.removeSection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sectioncollection/#removeSection), wobei die Folien erhalten bleiben;
- einen Abschnitt samt seinen Folien entfernen mit [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- am Ende einen leeren Abschnitt hinzufügen mit [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

Das folgende Beispiel erstellt zwei Abschnitte, verschiebt einen davon, entfernt ihn zusammen mit seinen Folien und fügt einen leeren Abschnitt hinzu:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

Nach diesen Vorgängen enthält die Präsentation den Abschnitt `Introduction` mit seinen Folien sowie einen leeren Abschnitt `Appendix`. Der Abschnitt `Results` und seine Folien wurden entfernt.

## **Abschnitte umbenennen**

Um einen Abschnitt umzubenennen, rufen Sie die Methode [Section.setName](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/section/#setName) auf. Die Folien des Abschnitts und seine Position bleiben unverändert.

Das folgende Beispiel erstellt einen Abschnitt und ändert dessen Namen:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **Folien aus Abschnitten abrufen**

Die Methode [Presentation.getSections](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getSections) gibt eine [SectionCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sectioncollection/) zurück, auf die Sie über einen Index zugreifen können. Für jeden [Section](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/section/) rufen Sie [Section.getSlidesListOfSection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/section/#getSlidesListOfSection) auf, um die Folien zu erhalten, die derzeit zu ihm gehören. Die Methode liefert eine [SectionSlideCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sectionslidecollection/), die eine Zählung und indizierten Zugriff bietet.

Das folgende Beispiel erstellt zwei gefüllte Abschnitte und einen leeren Abschnitt, dann gibt es den [Name](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/section/#getName), die [Kennung](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/section/#getSectionId), die [Startfolie](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/section/#getStartedFromSlide), die Folienanzahl und die Foliennummern jedes Abschnitts aus. Es verwendet [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sectionslidecollection/#get_Item), um sowohl die erste Folie als auch jede Folie in der Sammlung zu lesen. Für den leeren Abschnitt hat die zurückgegebene Sammlung die Größe Null, indizierter Zugriff wird übersprungen und die Schleife führt keine Operationen aus.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

Die Zugehörigkeit zu einem Abschnitt wird durch die Abschnittsstruktur der Präsentation bestimmt. Berechnen Sie den Bereich eines Abschnitts nicht manuell aus [Section.getStartedFromSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/section/#getStartedFromSlide), Folienindizes und der Startfolie des nächsten Abschnitts.

Strukturelle Änderungen können sowohl die für einen Abschnitt zurückgegebenen Folien als auch deren Foliennummern ändern. Dies umfasst das Neuordnen von Folien, das Klonen einer Folie in einen Abschnitt, das Verschieben eines Abschnitts zusammen mit seinen Folien, das Entfernen von Folien und das Entfernen von Abschnitten. Das nächste Beispiel ruft [Section.getSlidesListOfSection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/section/#getSlidesListOfSection) nach jeder solchen Änderung auf, anstatt Annahmen über die früheren Grenzen des Abschnitts beizubehalten.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

Rufen Sie [Section.getSlidesListOfSection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/section/#getSlidesListOfSection) erneut auf, sobald Folien oder Abschnitte neu geordnet, geklont, verschoben oder entfernt werden. Dadurch bleibt die nachfolgende Verarbeitung mit der aktuellen Präsentationsstruktur synchron.

Das PPT‑Format (PowerPoint 97–2003) bewahrt keine Abschnittsmetadaten. Verwenden Sie diesen Workflow mit einem Format, das Abschnitte unterstützt, z. B. PPTX; die Konvertierung nach PPT entfernt die für spätere Durchläufe erforderliche Abschnittsstruktur.

## **FAQ**

**Werden Abschnitte beim Speichern im PPT‑Format (PowerPoint 97–2003) erhalten?**

Nein. Das PPT‑Format unterstützt keine Abschnittsmetadaten, sodass die Abschnittsgruppierung beim Speichern als .ppt verloren geht.

**Kann ein kompletter Abschnitt „ausgeblendet“ werden?**

Nein. Ein Abschnitt hat keinen Sichtbarkeitszustand. Um seinen Inhalt auszublenden, rufen Sie für jede Folie im Abschnitt [Slide.setHidden](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#setHidden) auf.

**Wie kann ich den Abschnitt finden, der eine Folie enthält?**

Greifen Sie auf jeden Abschnitt in der von [Presentation.getSections](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getSections) zurückgegebenen Sammlung zu, rufen Sie für jeden Abschnitt [Section.getSlidesListOfSection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/section/#getSlidesListOfSection) auf und vergleichen Sie die zurückgegebenen Folien mit der Ziel‑folie. Für einen nicht leeren Abschnitt liefert [Section.getStartedFromSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/section/#getStartedFromSlide) seine erste Folie; für einen leeren Abschnitt gibt er `null` zurück.