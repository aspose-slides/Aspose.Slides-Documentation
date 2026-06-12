---
title: Masterdia
type: docs
weight: 30
url: /nl/java/examples/elements/master-slide/
keywords:
- codevoorbeeld
- masterdia
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Ontdek voorbeelden van masterdia's in Aspose.Slides voor Java: maak, bewerk en style masters, placeholders en thema's in PPT, PPTX en ODP met duidelijke Java-code."
---
Masterdia's vormen het hoogste niveau van de dia‑erfenishierarchie in PowerPoint. Een **masterdia** definieert gemeenschappelijke ontwerpelementen zoals achtergronden, logo's en tekstopmaak. **Lay‑outdia's** erven van masterdia's, en **normale dia's** erven van lay‑outdia's.

Dit artikel toont hoe je masterdia's maakt, wijzigt en beheert met Aspose.Slides for Java.

## **Een masterdia toevoegen**

Dit voorbeeld laat zien hoe je een nieuwe masterdia maakt door het standaardvoorbeeld te klonen. Vervolgens wordt er een banner met de bedrijfsnaam aan alle dia's toegevoegd via lay‑out‑erfenis.

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

        // Wijs de nieuwe masterdia toe aan een lay‑outdia.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Wijs de lay‑outdia toe aan de eerste dia in de presentatie.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Opmerking 1:** Masterdia's bieden een manier om consistente branding of gedeelde ontwerpelementen toe te passen op alle dia's. Elke wijziging die op de master wordt aangebracht, wordt automatisch weergegeven op de afhankelijke lay‑out‑ en normale dia's.  
>  
> 💡 **Opmerking 2:** Alle vormen of opmaak die aan een masterdia worden toegevoegd, worden geërfd door lay‑outdia's en vervolgens door alle normale dia's die die lay‑outs gebruiken.  
> De afbeelding hieronder illustreert hoe een tekstvak dat op een masterdia is toegevoegd automatisch wordt weergegeven op de uiteindelijke dia.

![Master Inheritance Example](master-slide-banner.png)

## **Toegang tot een masterdia**

Je kunt masterdia's benaderen via de mastercollectie van de presentatie. Hieronder vind je hoe je ze kunt ophalen en ermee kunt werken:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Verander het achtergrondtype.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Een masterdia verwijderen**

Masterdia's kunnen worden verwijderd op basis van index of referentie.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Verwijder een masterdia op basis van index.
        presentation.getMasters().removeAt(0);

        // Verwijder een masterdia op basis van referentie.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Ongebruikte masterdia's verwijderen**

Sommige presentaties bevatten masterdia's die niet worden gebruikt. Het verwijderen van deze dia's kan helpen de bestandsgrootte te verkleinen.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Verwijder alle ongebruikte masterdia's (ook die gemarkeerd als Preserve).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```