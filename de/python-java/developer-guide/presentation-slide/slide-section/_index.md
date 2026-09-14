---
title: Folienabschnitte in Präsentationen mit Python via Java verwalten
linktitle: Folienabschnitt
type: docs
weight: 90
url: /de/python-java/slide-section/
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
- Python
- Java
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte mit Aspose.Slides für Python via Java: Abschnittsfolien in PPTX‑Präsentationen erstellen, umbenennen, neu anordnen, abrufen und verarbeiten."
---
## **Einführung**

Abschnitte organisieren aufeinanderfolgende Folien in benannte Gruppen, ohne den Folieninhalt zu ändern. Mit Aspose.Slides für Python via Java können Sie Abschnitte erstellen, neu anordnen, umbenennen, prüfen und entfernen über die [Presentation.getSections](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSections) Methode.

Abschnitte sind besonders nützlich, wenn:
- eine große Präsentation in logische Themen oder Kapitel aufgeteilt werden muss;
- verschiedene Foliengruppen verschiedenen Mitarbeitern zugewiesen werden;
- Folien als Gruppen verarbeitet, verschoben oder zusammengeführt werden müssen.

Wählen Sie prägnante Abschnittsnamen, die den Zweck der gruppierten Folien beschreiben. Da Abschnitte Teil der Präsentationsstruktur sind, verwenden Sie die Abschnitts‑APIs, um die Zugehörigkeit zu bestimmen, anstatt sie aus den Folienpositionen abzuleiten.

## **Abschnitte erstellen und verwalten**

Verwenden Sie [SectionCollection.addSection](https://reference.aspose.com/slides/de/python-java/aspose.slides/sectioncollection/#addSection) um einen Abschnitt zu erstellen, indem Sie seinen Namen und die Startfolie angeben. Aspose.Slides ermittelt, welche Folien zum Abschnitt gehören, anhand der aktuellen Abschnittsstruktur der Präsentation.

Die gleiche [SectionCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/sectioncollection/) ermöglicht Ihnen ebenfalls:
- einen Abschnitt zusammen mit seinen Folien verschieben, indem Sie [reorderSectionWithSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) verwenden;
- nur die Abschnittsdefinition entfernen mit [removeSection](https://reference.aspose.com/slides/de/python-java/aspose.slides/sectioncollection/#removeSection), wobei die Folien erhalten bleiben;
- einen Abschnitt und seine Folien entfernen mit [removeSectionWithSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- am Ende einen leeren Abschnitt hinzufügen mit [appendEmptySection](https://reference.aspose.com/slides/de/python-java/aspose.slides/sectioncollection/#appendEmptySection).

Das folgende Beispiel erstellt zwei Abschnitte, verschiebt einen davon, entfernt ihn zusammen mit seinen Folien und fügt einen leeren Abschnitt hinzu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

Nach diesen Vorgängen enthält die Präsentation den Abschnitt `Introduction` mit seinen Folien und einen leeren Abschnitt `Appendix`. Der Abschnitt `Results` und seine Folien wurden entfernt.

## **Abschnitte umbenennen**

Um einen Abschnitt umzubenennen, rufen Sie die Methode [Section.setName](https://reference.aspose.com/slides/de/python-java/aspose.slides/section/#setName) auf. Die Folien des Abschnitts und seine Position bleiben unverändert.

Das folgende Beispiel erstellt einen Abschnitt und ändert dessen Namen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **Folien aus Abschnitten abrufen**

Die Methode [Presentation.getSections](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSections) gibt eine [SectionCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/sectioncollection/) zurück, über die Sie iterieren können. Für jede [Section](https://reference.aspose.com/slides/de/python-java/aspose.slides/section/), rufen Sie [Section.getSlidesListOfSection](https://reference.aspose.com/slides/de/python-java/aspose.slides/section/#getSlidesListOfSection) auf, um die Folien zu erhalten, die derzeit zu ihr gehören. Die Methode liefert eine [SectionSlideCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/sectionslidecollection/), die eine Zählung, indexierten Zugriff und Iteration bereitstellt.

Das folgende Beispiel erstellt zwei gefüllte Abschnitte und einen leeren Abschnitt, gibt dann für jeden Abschnitt den [Namen](https://reference.aspose.com/slides/de/python-java/aspose.slides/section/#getName), die [Kennung](https://reference.aspose.com/slides/de/python-java/aspose.slides/section/#getSectionId), die [Startfolie](https://reference.aspose.com/slides/de/python-java/aspose.slides/section/#getStartedFromSlide), die Folienanzahl und die Foliennummern aus. Es verwendet [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/de/python-java/aspose.slides/sectionslidecollection/#get_Item) um die erste Folie zu lesen und eine `for`‑Anweisung, um jede Folie zu verarbeiten. Für den leeren Abschnitt hat die zurückgegebene Sammlung die Größe null, die Methode wird nicht aufgerufen und die Iteration führt keine Aktionen aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

Die Zugehörigkeit zu einem Abschnitt wird durch die Abschnittsstruktur der Präsentation bestimmt. Berechnen Sie den Bereich eines Abschnitts nicht manuell aus [Section.getStartedFromSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/section/#getStartedFromSlide), Folienindizes und der Startfolie des nächsten Abschnitts.

Strukturelle Änderungen können sowohl die für einen Abschnitt zurückgegebenen Folien als auch deren Foliennummern ändern. Dazu gehören das Neuordnen von Folien, das Klonen einer Folie in einen Abschnitt, das Verschieben eines Abschnitts zusammen mit seinen Folien, das Entfernen von Folien und das Entfernen von Abschnitten. Das nächste Beispiel ruft nach jeder solchen Änderung [Section.getSlidesListOfSection](https://reference.aspose.com/slides/de/python-java/aspose.slides/section/#getSlidesListOfSection) auf, anstatt Annahmen über die früheren Grenzen des Abschnitts beizubehalten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

Rufen Sie [Section.getSlidesListOfSection](https://reference.aspose.com/slides/de/python-java/aspose.slides/section/#getSlidesListOfSection) erneut auf, wann immer Folien oder Abschnitte neu angeordnet, geklont, verschoben oder entfernt werden. Dadurch bleibt die nachfolgende Verarbeitung mit der aktuellen Präsentationsstruktur synchron.

Das PPT‑Format (PowerPoint 97–2003) bewahrt keine Abschnitts‑Metadaten. Verwenden Sie diesen Workflow mit einem Format, das Abschnitte unterstützt, wie PPTX; das Konvertieren zu PPT entfernt die für spätere Iterationen benötigte Abschnittsstruktur.

## **FAQ**

**Werden Abschnitte beim Speichern im PPT‑Format (PowerPoint 97–2003) beibehalten?**

Nein. Das PPT‑Format unterstützt keine Abschnitts‑Metadaten, sodass die Abschnitts‑Gruppierung beim Speichern als .ppt verloren geht.

**Kann ein kompletter Abschnitt "ausgeblendet" werden?**

Nein. Ein Abschnitt hat keinen Sichtbarkeitsstatus. Um seinen Inhalt auszublenden, rufen Sie für jede Folie im Abschnitt [Slide.setHidden](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#setHidden) auf.

**Wie finde ich den Abschnitt, der eine Folie enthält?**

Iterieren Sie über die Sammlung, die von [Presentation.getSections](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSections) zurückgegeben wird, rufen Sie für jeden Abschnitt [Section.getSlidesListOfSection](https://reference.aspose.com/slides/de/python-java/aspose.slides/section/#getSlidesListOfSection) auf und vergleichen Sie die zurückgegebenen Folien mit der Ziel‑Folie. Für einen nicht leeren Abschnitt liefert [Section.getStartedFromSlide](https://reference.aspose.com/slides/de/python-java/aspose.slides/section/#getStartedFromSlide) seine erste Folie; für einen leeren Abschnitt wird `None` zurückgegeben.