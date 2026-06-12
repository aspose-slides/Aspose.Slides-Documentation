---
title: Layout‑slide
type: docs
weight: 20
url: /nl/java/examples/elements/layout-slide/
keywords:
- codevoorbeeld
- layout‑slide
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer layout‑slides in Aspose.Slides voor Java: kies, pas toe en pas de slide‑layouts, placeholders en masters aan met Java‑voorbeelden voor PPT-, PPTX- en ODP‑presentaties."
---
Dit artikel toont hoe u kunt werken met **Layout Slides** in Aspose.Slides voor Java. Een layout‑slide definieert het ontwerp en de opmaak die normale slides overnemen. U kunt layout‑slides toevoegen, benaderen, klonen en verwijderen, en ongebruikte slides opruimen om de bestandsgrootte van de presentatie te verkleinen.

## **Een layout‑slide toevoegen**

U kunt een aangepaste layout‑slide maken om herbruikbare opmaak te definiëren. Bijvoorbeeld kunt u een tekstvak toevoegen dat op alle slides met deze layout verschijnt.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Maak een layout‑slide met een lege layout‑type en een aangepaste naam.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Voeg een tekstvak toe aan de layout‑slide.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Voeg twee slides toe met deze layout; beide erven de tekst van de layout.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Opmerking 1:** Layout‑slides fungeren als sjablonen voor individuele slides. U kunt gemeenschappelijke elementen één keer definiëren en ze vervolgens in veel slides hergebruiken.

> 💡 **Opmerking 2:** Wanneer u vormen of tekst aan een layout‑slide toevoegt, tonen alle slides die op die layout zijn gebaseerd automatisch deze gedeelde inhoud.  
> De screenshot hieronder toont twee slides, elk een tekstvak overervend van dezelfde layout‑slide.

![Slides die layout‑inhoud overerven](layout-slide-result.png)

## **Toegang tot een layout‑slide**

Layout‑slides kunnen benaderd worden via een index of op layouttype (bijv. `Blank`, `Title`, `SectionHeader`, enz.).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Toegang tot een layout slide via index.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Toegang tot een layout slide via type.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Een layout‑slide verwijderen**

U kunt een specifieke layout‑slide verwijderen als deze niet meer nodig is.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Haal een layout slide op via type en verwijder deze.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Ongebruikte layout‑slides verwijderen**

Om de grootte van de presentatie te verkleinen, wilt u wellicht layout‑slides verwijderen die door geen enkele normale slide worden gebruikt.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Verwijdert automatisch alle layout‑slides die door geen enkele slide worden gebruikt.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Een layout‑slide klonen**

U kunt een layout‑slide dupliceren met behulp van de methode `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Haal een bestaande layout‑slide op via type.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Kloon de layout‑slide naar het einde van de layout‑slide‑collectie.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Samenvatting:** Layout‑slides zijn krachtige hulpmiddelen voor het beheren van consistente opmaak over slides heen. Aspose.Slides biedt volledige controle over het maken, beheren en optimaliseren van layout‑slides.