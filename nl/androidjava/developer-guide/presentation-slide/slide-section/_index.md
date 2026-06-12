---
title: Secties van dia's beheren in presentaties op Android
linktitle: Dia-sectie
type: docs
weight: 90
url: /nl/androidjava/slide-section/
keywords:
- sectie aanmaken
- sectie toevoegen
- sectie bewerken
- sectie wijzigen
- sectienaam
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Optimaliseer dia-secties in PowerPoint en OpenDocument met Aspose.Slides for Android via Java - splitsen, hernoemen en herschikken om PPTX- en ODP-werkstromen te optimaliseren."
---
## **Inleiding**

Met Aspose.Slides for Android via Java kunt u een PowerPoint‑presentatie in secties indelen. U kunt secties maken die specifieke dia’s bevatten.

U wilt mogelijk secties maken en ze gebruiken om dia’s in een presentatie te organiseren of te verdelen in logische delen in de volgende situaties:

- Wanneer u aan een grote presentatie werkt met andere personen of een team – en u moet bepaalde dia’s toewijzen aan een collega of enkele teamleden. 
- Wanneer u een presentatie hebt die veel dia’s bevat – en u moeite heeft om de inhoud in één keer te beheren of te bewerken.

Idealiter moet u een sectie maken die soortgelijke dia’s bevat – de dia’s hebben iets gemeen of kunnen op basis van een regel in een groep worden geplaatst – en de sectie een naam geven die de dia’s beschrijft die erin staan. 

## **Secties maken in presentaties**

Om een sectie toe te voegen die dia’s in een presentatie bevat, biedt Aspose.Slides for Android via Java de [addSection()](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) methode die u in staat stelt de naam van de te creëren sectie en de dia waar de sectie start op te geven.

Deze voorbeeldcode laat zien hoe u een sectie in een presentatie maakt in Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 eindigt bij newSlide2 en daarna start section2   

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

Nadat u een sectie in een PowerPoint‑presentatie heeft aangemaakt, kunt u besluiten de naam ervan te wijzigen. 

Deze voorbeeldcode laat zien hoe u de naam van een sectie in een presentatie wijzigt in Java met behulp van Aspose.Slides:

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

**Worden secties behouden bij het opslaan in het PPT (PowerPoint 97–2003) formaat?**

Nee. Het PPT‑formaat ondersteunt geen sectie‑metadata, waardoor de sectiegroepering verloren gaat bij het opslaan als .ppt.

**Kan een hele sectie "verborgen" worden?**

Nee. Alleen individuele dia's kunnen worden verborgen. Een sectie als entiteit heeft geen "verborgen" status.

**Kan ik snel een sectie vinden op basis van een dia en omgekeerd de eerste dia van een sectie?**

Ja. Een sectie wordt uniek gedefinieerd door de startdia; gegeven een dia kunt u bepalen tot welke sectie deze behoort, en voor een sectie kunt u de eerste dia benaderen.