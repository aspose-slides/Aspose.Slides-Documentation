---
title: Folienabschnitte in Präsentationen mit Python verwalten
linktitle: Folienabschnitt
type: docs
weight: 100
url: /de/python-net/slide-section/
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
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte mit Aspose.Slides für Python via .NET: Erstellen, umbenennen, neu anordnen, abrufen und verarbeiten von Abschnittsfolien in PPTX-Präsentationen."
---
## **Einführung**

Abschnitte organisieren aufeinanderfolgende Folien in benannte Gruppen, ohne den Folieninhalt zu ändern. Mit Aspose.Slides für Python via .NET können Sie Abschnitte über die [Presentation.sections](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/sections/)-Eigenschaft erstellen, neu anordnen, umbenennen, inspizieren und entfernen.

Abschnitte sind besonders nützlich, wenn:

- eine große Präsentation in logische Themen oder Kapitel unterteilt werden muss;
- verschiedene Foliengruppen unterschiedlichen Mitarbeitern zugewiesen werden;
- Folien als Gruppen verarbeitet, verschoben oder zusammengeführt werden müssen.

Wählen Sie kurze Abschnittsnamen, die den Zweck der gruppierten Folien beschreiben. Da Abschnitte Teil der Präsentationsstruktur sind, verwenden Sie die Abschnitt‑APIs, um die Zugehörigkeit zu bestimmen, anstatt sie aus den Folienpositionen abzuleiten.

## **Abschnitte erstellen und verwalten**

Verwenden Sie [SectionCollection.add_section](https://reference.aspose.com/slides/de/python-net/aspose.slides/sectioncollection/add_section/), um einen Abschnitt zu erstellen, indem Sie dessen Namen und die Startfolie angeben. Aspose.Slides bestimmt, welche Folien zu dem Abschnitt gehören, anhand der aktuellen Abschnittsstruktur der Präsentation.

Die gleiche [SectionCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/sectioncollection/) lässt Sie außerdem:

- einen Abschnitt zusammen mit seinen Folien verschieben, indem Sie [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/) verwenden;
- nur die Abschnittsdefinition entfernen mit [SectionCollection.remove_section](https://reference.aspose.com/slides/de/python-net/aspose.slides/sectioncollection/remove_section/), wobei die Folien erhalten bleiben;
- einen Abschnitt und seine Folien entfernen mit [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/sectioncollection/remove_section_with_slides/);
- am Ende einen leeren Abschnitt hinzufügen mit [SectionCollection.append_empty_section](https://reference.aspose.com/slides/de/python-net/aspose.slides/sectioncollection/append_empty_section/).

Das folgende Beispiel erstellt zwei Abschnitte, verschiebt einen davon, entfernt ihn zusammen mit seinen Folien und fügt einen leeren Abschnitt hinzu:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

Nach diesen Vorgängen enthält die Präsentation den Abschnitt `Introduction` mit seinen Folien und einen leeren Abschnitt `Appendix`. Der Abschnitt `Results` und seine Folien wurden entfernt.

## **Abschnitte umbenennen**

Um einen Abschnitt umzubenennen, setzen Sie dessen [Section.name](https://reference.aspose.com/slides/de/python-net/aspose.slides/section/name/)-Eigenschaft. Die Folien und die Position des Abschnitts bleiben unverändert.

Das folgende Beispiel erstellt einen Abschnitt und ändert dessen Namen:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Folien aus Abschnitten abrufen**

Die [Presentation.sections](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/sections/)-Eigenschaft liefert eine [SectionCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/sectioncollection/), über die Sie iterieren können. Für jeden [Section](https://reference.aspose.com/slides/de/python-net/aspose.slides/section/) rufen Sie [Section.get_slides_list_of_section](https://reference.aspose.com/slides/de/python-net/aspose.slides/section/get_slides_list_of_section/) auf, um die Folien zu erhalten, die derzeit zu ihm gehören. Die Methode liefert eine [SectionSlideCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/sectionslidecollection/), die eine Zählung, indizierten Zugriff und Iteration bereitstellt.

Das folgende Beispiel erstellt zwei gefüllte Abschnitte und einen leeren Abschnitt, dann gibt es für jeden Abschnitt den [name](https://reference.aspose.com/slides/de/python-net/aspose.slides/section/name/), die [identifier](https://reference.aspose.com/slides/de/python-net/aspose.slides/section/section_id/), die [starting slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/section/started_from_slide/), die Folienanzahl und die Foliennummern aus. Es verwendet indizierten Zugriff, um die erste Folie zu lesen, und eine `for`-Schleife, um jede Folie zu verarbeiten. Für den leeren Abschnitt hat die zurückgegebene Sammlung eine Zählung von null, auf den Index wird nicht zugegriffen, und die Iteration führt keine Schritte aus.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

Die Mitgliedschaft eines Abschnitts wird durch die Abschnittsstruktur der Präsentation bestimmt. Berechnen Sie den Bereich eines Abschnitts nicht manuell aus [Section.started_from_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/section/started_from_slide/), Folienindizes und der Startfolie des nächsten Abschnitts.

Strukturelle Änderungen können sowohl die für einen Abschnitt zurückgegebenen Folien als auch deren Foliennummern ändern. Dazu gehören das Neuordnen von Folien, das Klonen einer Folie in einen Abschnitt, das Verschieben eines Abschnitts zusammen mit seinen Folien, das Entfernen von Folien und das Entfernen von Abschnitten. Das nächste Beispiel ruft [Section.get_slides_list_of_section](https://reference.aspose.com/slides/de/python-net/aspose.slides/section/get_slides_list_of_section/) nach jeder solchen Änderung auf, anstatt Annahmen über die früheren Grenzen des Abschnitts beizubehalten.

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

Rufen Sie [Section.get_slides_list_of_section](https://reference.aspose.com/slides/de/python-net/aspose.slides/section/get_slides_list_of_section/) erneut auf, wann immer Folien oder Abschnitte neu geordnet, geklont, verschoben oder entfernt werden. Dadurch bleibt die nachfolgende Verarbeitung mit der aktuellen Präsentationsstruktur abgestimmt.

Das PPT‑Format (PowerPoint 97–2003) speichert keine Abschnittsmetadaten. Verwenden Sie diesen Workflow mit einem Format, das Abschnitte unterstützt, wie PPTX; die Konvertierung zu PPT entfernt die für die spätere Iteration benötigte Abschnittsstruktur.

## **FAQ**

**Werden Abschnitte beim Speichern im PPT‑Format (PowerPoint 97–2003) erhalten?**

Nein. Das PPT‑Format unterstützt keine Abschnittsmetadaten, sodass die Abschnittsgruppierung beim Speichern in .ppt verloren geht.

**Kann ein kompletter Abschnitt „ausgeblendet“ werden?**

Nein. Ein Abschnitt hat keinen Sichtbarkeitsstatus. Um seinen Inhalt auszublenden, setzen Sie die [Slide.hidden](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/hidden/)-Eigenschaft für jede Folie im Abschnitt.

**Wie kann ich den Abschnitt finden, der eine Folie enthält?**

Iterieren Sie über [Presentation.sections](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/sections/), rufen Sie für jeden Abschnitt [Section.get_slides_list_of_section](https://reference.aspose.com/slides/de/python-net/aspose.slides/section/get_slides_list_of_section/) auf und vergleichen Sie die zurückgegebenen Folien mit der Ziel‑Folie. Für einen nicht‑leeren Abschnitt gibt [Section.started_from_slide](https://reference.aspose.com/slides/de/python-net/aspose.slides/section/started_from_slide/) seine erste Folie zurück; für einen leeren Abschnitt gibt er `None` zurück.