---
title: Beheer dia-secties in presentaties met Java
linktitle: Dia-sectie
type: docs
weight: 90
url: /nl/java/slide-section/
keywords:
- sectie maken
- sectie toevoegen
- sectie bewerken
- sectie wijzigen
- sectienaam
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Stroomlijn dia-secties in PowerPoint en OpenDocument met Aspose.Slides voor Java — splits, hernoem en herschik om PPTX- en ODP-werkstromen te optimaliseren."
---
## **Introductie**

Met Aspose.Slides voor Java kunt u een PowerPoint‑presentatie organiseren in secties. U kunt secties maken die specifieke dia's bevatten. 

U wilt mogelijk secties maken en deze gebruiken om dia's in een presentatie te organiseren of te verdelen in logische delen in de volgende situaties:

- Wanneer u aan een grote presentatie werkt met anderen of in een team — en u bepaalde dia's aan een collega of teamleden wilt toewijzen. 
- Wanneer u te maken heeft met een presentatie die veel dia's bevat — en u moeite heeft om de inhoud in één keer te beheren of te bewerken.

Idealiter maakt u een sectie die vergelijkbare dia's bevat — de dia's hebben iets gemeen of kunnen op basis van een regel in een groep bestaan — en geeft u de sectie een naam die de dia's erin omschrijft. 

## **Secties maken in presentaties**

Om een sectie toe te voegen die dia's in een presentatie bevat, biedt Aspose.Slides voor Java de methode [addSection()](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) die u in staat stelt de naam van de sectie die u wilt maken en de dia waarop de sectie begint op te geven. 

Deze voorbeeldcode laat zien hoe u een sectie maakt in een presentatie in Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 wordt beëindigd bij newSlide2 en daarna start section2   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **De namen van secties wijzigen**

Nadat u een sectie in een PowerPoint‑presentatie hebt gemaakt, kunt u besluiten de naam te wijzigen. 

Deze voorbeeldcode laat zien hoe u de naam van een sectie wijzigt in een presentatie in Java met behulp van Aspose.Slides:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Worden secties bewaard bij het opslaan in het PPT (PowerPoint 97–2003) formaat?**

Nee. Het PPT‑formaat ondersteunt geen sectiemetadata, waardoor de sectiegroepering verloren gaat bij het opslaan als .ppt.

**Kan een hele sectie "verborgen" worden?**

Nee. Alleen individuele dia's kunnen worden verborgen. Een sectie als entiteit heeft geen "verborgen" status.

**Kan ik snel een sectie vinden via een dia en, omgekeerd, de eerste dia van een sectie?**

Ja. Een sectie wordt uniek gedefinieerd door zijn startdia; vanaf een dia kunt u bepalen tot welke sectie deze behoort, en voor een sectie kunt u de eerste dia benaderen.