---
title: Beheer dia‑secties in presentaties in .NET
linktitle: Dia‑sectie
type: docs
weight: 100
url: /nl/net/slide-section/
keywords:
- sectie aanmaken
- sectie toevoegen
- sectie bewerken
- sectie wijzigen
- sectienaam
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Vereenvoudig dia‑secties in PowerPoint en OpenDocument met Aspose.Slides voor .NET — splitsen, hernoemen en herschikken om PPTX‑ en ODP‑werkstromen te optimaliseren."
---
## **Inleiding**

Met Aspose.Slides for .NET kunt u een PowerPoint‑presentatie in secties indelen. U kunt secties maken die specifieke dia’s bevatten.  

U wilt mogelijk secties maken en ze gebruiken om dia’s in een presentatie te organiseren of op te delen in logische delen in de volgende situaties:

- Wanneer u aan een grote presentatie werkt met andere personen of een team—en u bepaalde dia’s moet toewijzen aan een collega of enkele teamleden.  
- Wanneer u te maken hebt met een presentatie die veel dia’s bevat—en u moeite heeft om de inhoud in één keer te beheren of te bewerken.

Idealiter maakt u een sectie die vergelijkbare dia’s groepeert—de dia’s hebben iets gemeen of kunnen op basis van een regel in een groep bestaan—en geeft u de sectie een naam die de inhoud van de dia’s beschrijft.  

## **Secties maken in presentaties**

Om een sectie toe te voegen die dia’s in een presentatie bevat, biedt Aspose.Slides for .NET de methode **AddSection** waarmee u de naam van de te maken sectie en de dia waar de sectie begint, kunt opgeven.  

Deze voorbeeldcode laat zien hoe u een sectie in een presentatie maakt in C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 zal worden beëindigd bij newSlide2 en daarna zal section2 starten   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **De namen van secties wijzigen**

Nadat u een sectie in een PowerPoint‑presentatie hebt gemaakt, kunt u besluiten de naam ervan te wijzigen.  

Deze voorbeeldcode laat zien hoe u de naam van een sectie in een presentatie wijzigt in C# met Aspose.Slides:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **FAQ**

**Worden secties bewaard bij het opslaan in het PPT‑formaat (PowerPoint 97–2003)?**

Nee. Het PPT‑formaat ondersteunt geen sectie‑metadata, waardoor de sectiegroepering verloren gaat bij het opslaan als .ppt.

**Kan een volledige sectie \"verborgen\" worden?**

Nee. Alleen individuele dia’s kunnen verborgen worden. Een sectie als entiteit heeft geen \"verborgen\"‑status.

**Kan ik snel een sectie vinden op basis van een dia en omgekeerd, de eerste dia van een sectie?**

Ja. Een sectie wordt uniek bepaald door de startdia; gegeven een dia kunt u bepalen tot welke sectie deze behoort, en bij een sectie kunt u de eerste dia benaderen.