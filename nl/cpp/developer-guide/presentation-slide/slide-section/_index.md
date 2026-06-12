---
title: Beheer dia‑secties in presentaties met C++
linktitle: Dia‑sectie
type: docs
weight: 100
url: /nl/cpp/slide-section/
keywords:
- sectie maken
- sectie toevoegen
- sectie bewerken
- sectie wijzigen
- sectienaam
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Stroomlijn dia‑secties in PowerPoint en OpenDocument met Aspose.Slides voor C++ — splitsen, hernoemen en herschikken om PPTX‑ en ODP‑workflows te optimaliseren."
---
## **Inleiding**

Met Aspose.Slides for C++ kun je een PowerPoint‑presentatie in secties indelen. Je kunt secties maken die specifieke dia's bevatten. 

Je wilt wellicht secties maken en deze gebruiken om dia's in een presentatie te organiseren of op te delen in logische delen in de volgende situaties:

- Wanneer je aan een grote presentatie werkt met andere personen of een team — en je bepaalde dia's moet toewijzen aan een collega of enkele teamleden. 
- Wanneer je te maken hebt met een presentatie die veel dia's bevat — en je moeite hebt om de inhoud in één keer te beheren of te bewerken.

Idealiter maak je een sectie die soortgelijke dia's bevat — de dia's hebben iets gemeen of ze kunnen op basis van een regel in een groep bestaan — en geef je de sectie een naam die de dia's erin beschrijft. 

## **Secties aanmaken in presentaties**

Om een sectie toe te voegen die dia's in een presentatie bevat, biedt Aspose.Slides for C++ de methode AddSection, waarmee je de naam van de te maken sectie en de dia vanaf waar de sectie begint kunt opgeven. 

Deze voorbeeldcode laat zien hoe je een sectie in een presentatie maakt in C++:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 eindigt bij newSlide2 en daarna start section2   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## **De namen van secties wijzigen**

Nadat je een sectie hebt aangemaakt in een PowerPoint‑presentatie, kun je besluiten de naam ervan te wijzigen. 

Deze voorbeeldcode laat zien hoe je de naam van een sectie in een presentatie wijzigt in C++ met behulp van Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```

## **FAQ**

**Worden secties behouden bij het opslaan in het PPT‑formaat (PowerPoint 97–2003)?**

Nee. Het PPT‑formaat ondersteunt geen sectiemetadata, waardoor de sectiegroepering verloren gaat bij het opslaan als .ppt.

**Kan een volledige sectie “verborgen” worden?**

Nee. Alleen individuele dia's kunnen verborgen worden. Een sectie als entiteit heeft geen “verborgen” status.

**Kan ik snel een sectie vinden op basis van een dia en, omgekeerd, de eerste dia van een sectie?**

Ja. Een sectie wordt uniek bepaald door de startdia; gegeven een dia kun je bepalen tot welke sectie deze behoort, en voor een sectie kun je de eerste dia opvragen.