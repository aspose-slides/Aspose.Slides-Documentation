---
title: Layoutdia
type: docs
weight: 20
url: /nl/androidjava/examples/elements/layout-slide/
keywords:
- codevoorbeeld
- layoutdia
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer layoutdia's in Aspose.Slides voor Android: kies, pas toe en personaliseer dia lay-outs, placeholders en masters met Java-voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel toont hoe u werkt met **Layout Slides** in Aspose.Slides voor Android via Java. Een layout slide definieert het ontwerp en de opmaak die normale slides overnemen. U kunt layout slides toevoegen, openen, klonen en verwijderen, en ongebruikte layout slides opschonen om de grootte van de presentatie te verkleinen.

## **Toevoegen van een Layout Slide**

U kunt een aangepaste layout slide maken om herbruikbare opmaak te definiëren. Bijvoorbeeld, u kunt een tekstvak toevoegen dat op alle slides met deze layout verschijnt.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Maak een layoutdia met een lege lay-outtype en een aangepaste naam.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Voeg een tekstvak toe aan de layoutdia.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Voeg twee dia's toe met deze lay-out; beide erven de tekst van de lay-out.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Opmerking 1:** Layout slides fungeren als sjablonen voor individuele slides. U kunt gemeenschappelijke elementen één keer definiëren en ze vervolgens in veel slides hergebruiken.

> 💡 **Opmerking 2:** Wanneer u vormen of tekst toevoegt aan een layout slide, zullen alle slides die op die layout zijn gebaseerd deze gedeelde inhoud automatisch weergeven.  
> De screenshot hieronder toont twee slides, die elk een tekstvak van dezelfde layout slide overerven.

![Slides die layoutinhoud overerven](layout-slide-result.png)

## **Toegang tot een Layout Slide**

Layout slides kunnen benaderd worden op index of op layouttype (bijv. `Blank`, `Title`, `SectionHeader`, enz.).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Toegang tot een layoutdia via index.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Toegang tot een layoutdia via type.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Verwijderen van een Layout Slide**

U kunt een specifieke layout slide verwijderen als deze niet meer nodig is.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Haal een layoutdia op via type en verwijder deze.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Ongebruikte Layout Slides verwijderen**

Om de grootte van de presentatie te verkleinen, kunt u layout slides verwijderen die niet door enige normale slide worden gebruikt.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Verwijdert automatisch alle layoutdia's die niet door een slide worden gerefereerd.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Een Layout Slide klonen**

U kunt een layout slide dupliceren met de `addClone` methode.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Haal een bestaande layoutdia op via type.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Kloon de layoutdia naar het einde van de layoutdia-collectie.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Samenvatting:** Layout slides zijn krachtige hulpmiddelen om consistente opmaak over slides te beheren. Aspose.Slides biedt volledige controle over het maken, beheren en optimaliseren van layout slides.