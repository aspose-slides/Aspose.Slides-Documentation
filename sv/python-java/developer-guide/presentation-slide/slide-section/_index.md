---
title: Hantera bildavsnitt i presentationer med Python via Java
linktitle: Bildavsnitt
type: docs
weight: 90
url: /sv/python-java/slide-section/
keywords:
- skapa avsnitt
- lägga till avsnitt
- redigera avsnitt
- ändra avsnitt
- avsnittsnamn
- hämta avsnittsbilder
- behandla avsnittsbilder
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Hantera bildavsnitt med Aspose.Slides för Python via Java: skapa, byta namn, omordna, hämta och behandla avsnittsbilder i PPTX-presentationer."
---
## **Introduktion**

Avsnitt organiserar på varandra följande bilder i namngivna grupper utan att ändra bildinnehållet. Med Aspose.Slides för Python via Java kan du skapa, omordna, byta namn, inspektera och ta bort avsnitt via metoden [Presentation.getSections](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSections).

Avsnitt är särskilt användbara när:

- en stor presentation behöver delas in i logiska ämnen eller kapitel;
- olika grupper av bilder tilldelas olika medarbetare;
- bilder måste bearbetas, flyttas eller slås ihop som grupper.

Välj koncisa avsnittsnamn som beskriver syftet med de grupperade bilderna. Eftersom avsnitt är en del av presentationens struktur bör du använda avsnitts‑API:erna för att fastställa medlemskap i stället för att härleda det från bildpositioner.

## **Skapa och hantera avsnitt**

Använd [SectionCollection.addSection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sectioncollection/#addSection) för att skapa ett avsnitt genom att ange dess namn och startbild. Aspose.Slides avgör vilka bilder som tillhör avsnittet utifrån presentationens aktuella avsnittsstruktur.

Samma [SectionCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sectioncollection/) låter dig också:

- flytta ett avsnitt tillsammans med dess bilder genom att använda [reorderSectionWithSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- bara ta bort avsnittets definition med [removeSection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sectioncollection/#removeSection), vilket behåller dess bilder;
- ta bort ett avsnitt och dess bilder med [removeSectionWithSlides](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- lägga till ett tomt avsnitt i slutet med [appendEmptySection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sectioncollection/#appendEmptySection).

Följande exempel skapar två avsnitt, flyttar ett av dem, tar bort det tillsammans med dess bilder och lägger till ett tomt avsnitt:

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

Efter dessa operationer innehåller presentationen `Introduction`‑avsnittet med dess bilder samt ett tomt `Appendix`‑avsnitt. `Results`‑avsnittet och dess bilder har tagits bort.

## **Byta namn på avsnitt**

För att byta namn på ett avsnitt, anropa dess [Section.setName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/section/#setName)-metod. Avsnittets bilder och position förblir oförändrade.

Följande exempel skapar ett avsnitt och ändrar dess namn:

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

## **Hämta bilder från avsnitt**

Metoden [Presentation.getSections](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSections) returnerar en [SectionCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sectioncollection/) som du kan iterera över. För varje [Section](https://reference.aspose.com/slides/sv/python-java/aspose.slides/section/), anropa [Section.getSlidesListOfSection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/section/#getSlidesListOfSection) för att hämta de bilder som för närvarande tillhör den. Metoden returnerar en [SectionSlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sectionslidecollection/), som erbjuder räknare, indexerad åtkomst och iteration.

Följande exempel skapar två fyllda avsnitt och ett tomt avsnitt, och skriver sedan ut varje avsnitts [name](https://reference.aspose.com/slides/sv/python-java/aspose.slides/section/#getName), [identifier](https://reference.aspose.com/slides/sv/python-java/aspose.slides/section/#getSectionId), [starting slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/section/#getStartedFromSlide), bildantal och bildnummer. Det använder [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sectionslidecollection/#get_Item) för att läsa den första bilden och ett `for`‑uttryck för att bearbeta varje bild. För det tomma avsnittet har den returnerade samlingen storlek noll, metoden anropas inte och iterationen utför inga operationer.

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

Avsnittstillhörighet bestäms av presentationens avsnittsstruktur. Beräkna inte ett avsnitts intervall manuellt från [Section.getStartedFromSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/section/#getStartedFromSlide), bildindex eller nästa avsnitts startbild.

Strukturella ändringar kan påverka både bilderna som returneras för ett avsnitt och deras bildnummer. Detta inkluderar omordning av bilder, kloning av en bild till ett avsnitt, flytt av ett avsnitt tillsammans med dess bilder, borttagning av bilder och borttagning av avsnitt. Nästa exempel anropar [Section.getSlidesListOfSection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/section/#getSlidesListOfSection) efter varje sådan förändring istället för att behålla antaganden om avsnittets tidigare gränser.

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

Anropa [Section.getSlidesListOfSection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/section/#getSlidesListOfSection) igen när bilder eller avsnitt omordnas, klonas, flyttas eller tas bort. Detta håller efterföljande bearbetning i synk med den aktuella presentationsstrukturen.

PPT‑formatet (PowerPoint 97–2003) bevarar inte avsnittmetadata. Använd detta arbetsflöde med ett format som stödjer avsnitt, exempelvis PPTX; konvertering till PPT tar bort den avsnittsstruktur som behövs för senare iteration.

## **Vanliga frågor**

**Behålls avsnitt när man sparar till PPT (PowerPoint 97–2003)-formatet?**

Nej. PPT‑formatet stödjer inte avsnittmetadata, så avsnittsgruppering går förlorad när du sparar till .ppt.

**Kan ett helt avsnitt “döljas”?**

Nej. Ett avsnitt har ingen synlighetsstatus. För att dölja dess innehåll, anropa [Slide.setHidden](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#setHidden) för varje bild i avsnittet.

**Hur kan jag hitta avsnittet som innehåller en bild?**

Iterera över samlingen som returneras av [Presentation.getSections](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSections), anropa [Section.getSlidesListOfSection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/section/#getSlidesListOfSection) för varje avsnitt och jämför de returnerade bilderna med mål‑bilden. För ett icke‑tomt avsnitt returnerar [Section.getStartedFromSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/section/#getStartedFromSlide) dess första bild; för ett tomt avsnitt returnerar det `None`.