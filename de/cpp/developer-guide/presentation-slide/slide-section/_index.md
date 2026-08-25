---
title: Slide-Abschnitte in Präsentationen mit C++
linktitle: Folienabschnitt
type: docs
weight: 100
url: /de/cpp/slide-section/
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
- C++
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte mit Aspose.Slides für C++: Erstellen, Umbennen, Neuordnen, Abrufen und Verarbeiten von Abschnittsfolien in PPTX-Präsentationen."
---
## **Einführung**

Abschnitte organisieren aufeinanderfolgende Folien in benannte Gruppen, ohne den Folieninhalt zu ändern. Mit Aspose.Slides für C++ können Sie Abschnitte über die Methode [Presentation::get_Sections](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_sections/) erstellen, neu anordnen, umbenennen, inspizieren und entfernen.

Abschnitte sind besonders nützlich, wenn:

- eine große Präsentation in logische Themen oder Kapitel unterteilt werden muss;
- verschiedene Foliengruppen verschiedenen Mitarbeitenden zugewiesen werden;
- Folien als Gruppen verarbeitet, verschoben oder zusammengeführt werden müssen.

Wählen Sie prägnante Abschnittsnamen, die den Zweck der gruppierten Folien beschreiben. Da Abschnitte Teil der Präsentationsstruktur sind, verwenden Sie die Abschnitt‑APIs, um die Zugehörigkeit zu bestimmen, anstatt sie aus den Folienpositionen abzuleiten.

## **Abschnitte erstellen und verwalten**

Verwenden Sie [ISectionCollection::AddSection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isectioncollection/addsection/), um einen Abschnitt zu erstellen, indem Sie dessen Namen und Startfolie angeben. Aspose.Slides ermittelt, welche Folien zum Abschnitt gehören, anhand der aktuellen Abschnittsstruktur der Präsentation.

Die gleiche [ISectionCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isectioncollection/) ermöglicht Ihnen außerdem:

- einen Abschnitt zusammen mit seinen Folien verschieben, indem Sie [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/isectioncollection/reordersectionwithslides/) verwenden;
- nur die Abschnittsdefinition entfernen mit [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isectioncollection/removesection/), wobei die Folien erhalten bleiben;
- einen Abschnitt und seine Folien entfernen mit [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/de/cpp/aspose.slides/isectioncollection/removesectionwithslides/);
- am Ende einen leeren Abschnitt hinzufügen mit [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isectioncollection/appendemptysection/).

Das folgende Beispiel erstellt zwei Abschnitte, verschiebt einen davon, entfernt ihn zusammen mit seinen Folien und hängt einen leeren Abschnitt an:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

Nach diesen Vorgängen enthält die Präsentation den Abschnitt `Introduction` mit seinen Folien und einen leeren Abschnitt `Appendix`. Der Abschnitt `Results` und seine Folien wurden entfernt.

## **Abschnitte umbenennen**

Um einen Abschnitt umzubenennen, rufen Sie [ISection::set_Name](https://reference.aspose.com/slides/de/cpp/aspose.slides/isection/set_name/) auf. Die Folien des Abschnitts und dessen Position bleiben unverändert.

Das folgende Beispiel erstellt einen Abschnitt und ändert dessen Namen:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **Folien aus Abschnitten abrufen**

Die Methode [Presentation::get_Sections](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_sections/) gibt eine [ISectionCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isectioncollection/) zurück, die Sie enumerieren können. Für jedes [ISection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isection/) rufen Sie [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isection/getslideslistofsection/) auf, um die Folien zu erhalten, die derzeit zu ihm gehören. Die Methode liefert eine [ISectionSlideCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isectionslidecollection/), die eine Zählung, indizierten Zugriff und Enumeration bereitstellt.

Das folgende Beispiel erstellt zwei gefüllte Abschnitte und einen leeren Abschnitt, gibt dann für jeden Abschnitt den [Namen](https://reference.aspose.com/slides/de/cpp/aspose.slides/isection/get_name/), die [Kennung](https://reference.aspose.com/slides/de/cpp/aspose.slides/isection/get_sectionid/), die [Startfolie](https://reference.aspose.com/slides/de/cpp/aspose.slides/isection/get_startedfromslide/), die Folienzahl und die Foliennummern aus. Es verwendet indizierten Zugriff, um die erste Folie zu lesen, und eine bereichsbasierte `for`‑Schleife, um jede Folie zu verarbeiten. Für den leeren Abschnitt hat die zurückgegebene Sammlung eine Zählung von null, indizierter Zugriff wird nicht verwendet und die Enumeration führt keine Durchläufe aus.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

Die Zugehörigkeit zu einem Abschnitt wird durch die Abschnittsstruktur der Präsentation bestimmt. Berechnen Sie den Bereich eines Abschnitts nicht manuell aus [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/isection/get_startedfromslide/), Folienindizes und der Startfolie des nächsten Abschnitts.

Strukturelle Änderungen können sowohl die für einen Abschnitt zurückgegebenen Folien als auch deren Foliennummern ändern. Dazu gehören das Neuordnen von Folien, das Klonen einer Folie in einen Abschnitt, das Verschieben eines Abschnitts zusammen mit seinen Folien, das Entfernen von Folien und das Entfernen von Abschnitten. Das nächste Beispiel ruft [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isection/getslideslistofsection/) nach jeder solchen Änderung auf, anstatt Annahmen über die ehemaligen Grenzen des Abschnitts beizubehalten.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

Rufen Sie [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isection/getslideslistofsection/) erneut auf, wann immer Folien oder Abschnitte neu geordnet, geklont, verschoben oder entfernt werden. Dadurch bleibt die nachfolgende Verarbeitung mit der aktuellen Präsentationsstruktur abgestimmt.

Das PPT‑Format (PowerPoint 97–2003) bewahrt keine Abschnitts‑Metadaten. Verwenden Sie diesen Workflow mit einem Format, das Abschnitte unterstützt, z. B. PPTX; das Konvertieren in PPT entfernt die Abschnittsstruktur, die für eine spätere Enumeration erforderlich ist.

## **FAQ**

**Werden Abschnitte beim Speichern im PPT (PowerPoint 97–2003)-Format erhalten?**

Nein. Das PPT‑Format unterstützt keine Abschnitts‑Metadaten, sodass die Gruppierung von Abschnitten beim Speichern in .ppt verloren geht.

**Kann ein kompletter Abschnitt „ausgeblendet“ werden?**

Nein. Ein Abschnitt hat keinen Sichtbarkeitsstatus. Um seinen Inhalt auszublenden, rufen Sie für jede Folie im Abschnitt [ISlide::set_Hidden](https://reference.aspose.com/slides/de/cpp/aspose.slides/islide/set_hidden/) auf.

**Wie kann ich den Abschnitt finden, der eine Folie enthält?**

Enumerieren Sie [Presentation::get_Sections](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_sections/), rufen Sie für jeden Abschnitt [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isection/getslideslistofsection/) auf und vergleichen Sie die zurückgegebenen Folien mit der Ziel­folie. Für einen nicht‑leeren Abschnitt liefert [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/de/cpp/aspose.slides/isection/get_startedfromslide/) seine erste Folie; für einen leeren Abschnitt liefert er `nullptr`.