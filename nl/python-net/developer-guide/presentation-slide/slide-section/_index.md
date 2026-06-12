---
title: Beheer dia‑secties in presentaties met Python
linktitle: Dia‑sectie
type: docs
weight: 100
url: /nl/python-net/slide-section/
keywords:
- sectie maken
- sectie toevoegen
- sectie bewerken
- sectie wijzigen
- sectienaam
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Stroomlijn dia‑secties in PowerPoint en OpenDocument met Aspose.Slides for Python — splits, hernoem en herschik om PPTX‑ en ODP‑werkstromen te optimaliseren."
---
## **Introductie**

Met Aspose.Slides for Python kun je een PowerPoint‑presentatie organiseren in secties die specifieke dia's groeperen.

Je wilt mogelijk secties aanmaken om een presentatie te organiseren of op te delen in logische delen in de volgende situaties:

- Wanneer je aan een grote presentatie werkt met een team en bepaalde dia's aan specifieke collega's moet toewijzen.
- Wanneer je een presentatie hebt met veel dia's en het moeilijk vindt om alles in één keer te beheren of te bewerken.

Idealiter maak je secties die verwante dia's groeperen—dia's die een thema, onderwerp of doel delen—en geef je elke sectie een naam die duidelijk de inhoud weergeeft. 

## **Secties maken in presentaties**

Om een [Section](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/) toe te voegen die dia's in een presentatie groepeert, biedt Aspose.Slides de [add_section](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sectioncollection/add_section/) methode. Hiermee kun je de naam van de sectie en de dia waarop de sectie begint opgeven.

Het volgende Python‑voorbeeld toont hoe je een sectie in een presentatie maakt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Sectie 1 eindigt bij dia2; Sectie 2 begint bij dia3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **De namen van secties wijzigen**

Nadat je een [Section](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/) in een PowerPoint‑presentatie hebt aangemaakt, kun je besluiten de naam te wijzigen.

Het volgende Python‑voorbeeld toont hoe je een sectie in een presentatie hernoemt:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **FAQ**

**Worden secties behouden bij het opslaan in het PPT (PowerPoint 97–2003) formaat?**

Nee. Het PPT‑formaat ondersteunt geen sectiemetagegevens, waardoor de sectiegroepering verloren gaat bij het opslaan als .ppt.

**Kan een hele sectie "verborgen" worden?**

Nee. Alleen individuele dia's kunnen worden verborgen. Een sectie als entiteit heeft geen "verborgen" status.

**Kan ik snel een sectie vinden aan de hand van een dia en, omgekeerd, de eerste dia van een sectie?**

Ja. Een sectie wordt uniek gedefinieerd door de startdia; gegeven een dia kun je bepalen tot welke sectie hij behoort, en voor een sectie kun je de eerste dia benaderen.