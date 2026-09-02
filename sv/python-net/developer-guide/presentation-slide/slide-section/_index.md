---
title: Hantera bildsektioner i presentationer med Python
linktitle: Bildsektion
type: docs
weight: 100
url: /sv/python-net/slide-section/
keywords:
- skapa sektion
- lägga till sektion
- redigera sektion
- ändra sektion
- sektionsnamn
- hämta sektionens bilder
- bearbeta sektionsbilder
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera bildsektioner med Aspose.Slides för Python via .NET: skapa, byta namn, omordna, hämta och bearbeta sektionsbilder i PPTX‑presentationer."
---
## **Introduktion**

Sektioner organiserar på varandra följande bildspel i namngivna grupper utan att ändra bildinnehållet. Med Aspose.Slides för Python via .NET kan du skapa, omordna, byta namn, inspektera och ta bort sektioner via egenskapen [Presentation.sections](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/sections/) .

Sektioner är särskilt användbara när:

- en stor presentation behöver delas upp i logiska ämnen eller kapitel;
- olika grupper av bilder tilldelas olika medarbetare;
- bilder behöver bearbetas, flyttas eller slås samman som grupper.

Välj koncisa sektionsnamn som beskriver syftet med de grupperade bilderna. Eftersom sektioner är en del av presentationens struktur, använd sektions‑API:erna för att avgöra medlemskap istället för att härleda det från bildpositioner.

## **Skapa och hantera sektioner**

Använd [SectionCollection.add_section](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sectioncollection/add_section/) för att skapa en sektion genom att ange dess namn och startbild. Aspose.Slides avgör vilka bilder som tillhör sektionen utifrån presentationens nuvarande sektionsstruktur.

Samma [SectionCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sectioncollection/) låter dig också:

- flytta en sektion tillsammans med dess bilder genom att använda [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/) ;
- ta bort endast sektionens definition med [SectionCollection.remove_section](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sectioncollection/remove_section/) , vilket behåller dess bilder ;
- ta bort en sektion och dess bilder med [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sectioncollection/remove_section_with_slides/) ;
- lägga till en tom sektion i slutet med [SectionCollection.append_empty_section](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sectioncollection/append_empty_section/) .

Följande exempel skapar två sektioner, flyttar en av dem, tar bort den tillsammans med dess bilder och lägger till en tom sektion:

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

Efter dessa operationer innehåller presentationen `Introduction`‑sektionen med dess bilder och en tom `Appendix`‑sektion. `Results`‑sektionen och dess bilder har tagits bort.

## **Byt namn på sektioner**

För att byta namn på en sektion, sätt dess [Section.name](https://reference.aspose.com/slides/sv/python-net/aspose.slides/section/name/) egenskap. Sektionens bilder och position förblir oförändrade.

Följande exempel skapar en sektion och ändrar dess namn:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Hämta bilder från sektioner**

Egenskapen [Presentation.sections](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/sections/) returnerar en [SectionCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sectioncollection/) som du kan iterera över. För varje [Section](https://reference.aspose.com/slides/sv/python-net/aspose.slides/section/) , anropa [Section.get_slides_list_of_section](https://reference.aspose.com/slides/sv/python-net/aspose.slides/section/get_slides_list_of_section/) för att få de bilder som för närvarande tillhör den. Metoden returnerar en [SectionSlideCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sectionslidecollection/) , som ger ett antal, indexerad åtkomst och iteration.

Följande exempel skapar två fyllda sektioner och en tom sektion, och skriver sedan ut varje sekts [name](https://reference.aspose.com/slides/sv/python-net/aspose.slides/section/name/) , [identifier](https://reference.aspose.com/slides/sv/python-net/aspose.slides/section/section_id/) , [starting slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/section/started_from_slide/) , bildantal och bildnummer. Det använder indexerad åtkomst för att läsa den första bilden och en `for`‑loop för att bearbeta varje bild. För den tomma sektionen har den returnerade samlingen ett antal på noll, indexet nås inte och iterationen utför inga steg.

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

Sektionstillhörighet bestäms av presentationens sektionsstruktur. Beräkna inte en sektons intervall manuellt från [Section.started_from_slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/section/started_from_slide/) , bildindex och nästa sektions startbild.

Strukturella ändringar kan förändra både de bilder som returneras för en sektion och deras bildnummer. Detta inkluderar omordning av bilder, kloning av en bild till en sektion, flyttning av en sektion tillsammans med dess bilder, borttagning av bilder och borttagning av sektioner. Nästa exempel anropar [Section.get_slides_list_of_section](https://reference.aspose.com/slides/sv/python-net/aspose.slides/section/get_slides_list_of_section/) efter varje sådan förändring istället för att behålla antaganden om sektionens tidigare gränser.

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

Anropa [Section.get_slides_list_of_section](https://reference.aspose.com/slides/sv/python-net/aspose.slides/section/get_slides_list_of_section/) igen när bilder eller sektioner omordnas, klonas, flyttas eller tas bort. Detta håller efterföljande bearbetning i linje med den aktuella presentationsstrukturen.

PPT‑formatet (PowerPoint 97–2003) bevarar inte sektionsmetadata. Använd detta arbetsflöde med ett format som stödjer sektioner, som PPTX; konvertering till PPT tar bort den sektionsstruktur som behövs för senare iteration.

## **Vanliga frågor**

**Finns sektioner bevarade när man sparar till PPT (PowerPoint 97–2003)-formatet?**

Nej. PPT‑formatet stödjer inte sektionsmetadata, så sektionsgrupperingen går förlorad när man sparar till .ppt.

**Kan en hel sektion "gömmas"?**

Nej. En sektion har inget synlighetstillstånd. För att dölja dess innehåll, sätt egenskapen [Slide.hidden](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/hidden/) för varje bild i sektionen.

**Hur kan jag hitta sektionen som innehåller en bild?**

Iterera över [Presentation.sections](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/sections/) , anropa [Section.get_slides_list_of_section](https://reference.aspose.com/slides/sv/python-net/aspose.slides/section/get_slides_list_of_section/) för varje sektion, och jämför de returnerade bilderna med målbilden. För en icke‑tom sektion returnerar [Section.started_from_slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/section/started_from_slide/) dess första bild; för en tom sektion returneras `None`.