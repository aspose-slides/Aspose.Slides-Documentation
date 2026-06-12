---
title: Masterdia
type: docs
weight: 30
url: /nl/androidjava/examples/elements/master-slide/
keywords:
- codevoorbeeld
- masterdia
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek Aspose.Slides voor Android masterdia-voorbeelden: maak, bewerk en style masters, placeholders en thema's in PPT, PPTX en ODP met duidelijke Java-code."
---
Masterdia's vormen het hoogste niveau van de dia‑erfenishierarchie in PowerPoint. Een **master slide** definieert gemeenschappelijke ontwerpelementen zoals achtergronden, logo's en tekstopmaak. **Layout slides** erven van master slides, en **normal slides** erven van layout slides.

Dit artikel laat zien hoe u master slides kunt aanmaken, wijzigen en beheren met Aspose.Slides voor Android via Java.

## **Een masterdia toevoegen**

Dit voorbeeld toont hoe u een nieuwe master slide kunt creëren door de standaardslide te klonen. Vervolgens wordt er een banner met de bedrijfsnaam aan alle slides toegevoegd via layout‑erfenis.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Kloon de standaard masterdia.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Voeg een banner met bedrijfsnaam toe aan de bovenkant van de masterdia.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Wijs de nieuwe masterdia toe aan een layoutdia.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Wijs de layoutdia toe aan de eerste dia in de presentatie.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Masterdia's bieden een manier om consistente branding of gedeelde ontwerpelementen toe te passen op alle dia's. Elke wijziging die op de master wordt aangebracht, wordt automatisch doorgevoerd in de afhankelijke layout‑ en normale dia's.

> 💡 **Note 2:** Alle vormen of opmaak die aan een master slide worden toegevoegd, worden geërfd door layout slides en vervolgens door alle normale slides die die layouts gebruiken. De afbeelding hieronder illustreert hoe een tekstvak dat op een master slide is toegevoegd, automatisch wordt weergegeven op de uiteindelijke slide.

![Voorbeeld van master‑erfelijkheid](master-slide-banner.png)

## **Een masterdia openen**

U kunt master slides benaderen via de presentatie‑mastercollectie. Hier volgt hoe u ze kunt ophalen en ermee kunt werken:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Wijzig het achtergrondtype.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Een masterdia verwijderen**

Master slides kunnen verwijderd worden op basis van index of referentie.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Verwijder een masterdia op index.
        presentation.getMasters().removeAt(0);

        // Verwijder een masterdia via referentie.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Ongebruikte masterdia's verwijderen**

Sommige presentaties bevatten master slides die niet worden gebruikt. Het verwijderen van deze slides kan helpen de bestandsgrootte te verkleinen.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Verwijder alle ongebruikte masterdia's (zelfs die gemarkeerd als Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```