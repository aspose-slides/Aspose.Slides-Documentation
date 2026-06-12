---
title: Beheer dia‑secties in presentaties met JavaScript
linktitle: Dia‑sectie
type: docs
weight: 90
url: /nl/nodejs-java/slide-section/
keywords:
- sectie maken
- sectie toevoegen
- sectie bewerken
- sectie wijzigen
- sectienaam
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Stroomlijn dia‑secties in PowerPoint en OpenDocument met Aspose.Slides voor Node.js — splitsen, hernoemen en herschikken om PPTX‑ en ODP‑workflows te optimaliseren."
---
## **Inleiding**

Met Aspose.Slides for Node.js via Java kun je een PowerPoint‑presentatie in secties indelen. Je kunt secties maken die specifieke dia’s bevatten.

Je wilt mogelijk secties maken en ze gebruiken om dia’s in een presentatie te organiseren of te verdelen in logische delen in de volgende situaties:

- Wanneer je aan een grote presentatie werkt met andere mensen of een team—en je bepaalde dia’s moet toewijzen aan een collega of enkele teamleden. 
- Wanneer je te maken hebt met een presentatie die vele dia’s bevat—en je moeite hebt om de inhoud in één keer te beheren of te bewerken.

Idealiter maak je een sectie die soortgelijke dia’s bevat—de dia’s hebben iets gemeen of kunnen op basis van een regel in een groep worden geplaatst—en geef je de sectie een naam die de dia’s erin beschrijft. 

## **Secties maken in presentaties**

Om een sectie toe te voegen die dia’s in een presentatie bevat, biedt Aspose.Slides for Node.js via Java de [addSection()](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) methode waarmee je de naam van de te maken sectie kunt opgeven en de dia waar de sectie begint.

Deze voorbeeldcode laat zien hoe je een sectie maakt in een presentatie in JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// sectie1 eindigt bij newSlide2 en daarna begint sectie2
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **De namen van secties wijzigen**

Nadat je een sectie in een PowerPoint‑presentatie hebt gemaakt, kun je besluiten de naam ervan te wijzigen. 

Deze voorbeeldcode laat zien hoe je de naam van een sectie wijzigt in een presentatie in JavaScript met Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Worden secties behouden bij het opslaan in het PPT‑formaat (PowerPoint 97–2003)?**

Nee. Het PPT‑formaat ondersteunt geen sectiemetagegevens, waardoor sectiegroepering verloren gaat bij het opslaan als .ppt.

**Kan een gehele sectie "verborgen" worden?**

Nee. Alleen individuele dia’s kunnen worden verborgen. Een sectie als entiteit heeft geen "verborgen"-status.

**Kan ik snel een sectie vinden aan de hand van een dia en, omgekeerd, de eerste dia van een sectie?**

Ja. Een sectie wordt eenduidig bepaald door de begindia; gegeven een dia kun je bepalen tot welke sectie deze behoort, en voor een sectie kun je de eerste dia opvragen.