---
title: Groepsvormen in presentaties op Android
linktitle: Vormgroep
type: docs
weight: 40
url: /nl/androidjava/group/
keywords:
- groepsvorm
- vormgroep
- groep toevoegen
- alternatieve tekst
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u vormen in PowerPoint-presentaties kunt groeperen en degroeperen met Aspose.Slides voor Android—snelle, stapsgewijze handleiding met gratis Java-code."
---
## **Overzicht**

Dit artikel legt uit hoe u met groepvormen in Aspose.Slides kunt werken. Het laat zien hoe u een groepvorm aan een dia kunt toevoegen, vormen erin kunt plaatsen en de bijgewerkte presentatie kunt opslaan. Het demonstreert ook hoe u vormen die in een groep zijn opgeslagen kunt benaderen en hun `AlternativeText`‑waarden kunt lezen. Daarnaast behandelt het artikel kort gerelateerde mogelijkheden van groepvormen, zoals geneste groepen, z‑volgorde en vergrendelingsopties.

## **Groepvorm toevoegen**
Aspose.Slides ondersteunt het werken met groepvormen op dia's. Deze functie helpt ontwikkelaars om rijkere presentaties te ondersteunen. Aspose.Slides voor Android via Java ondersteunt het toevoegen of benaderen van groepvormen. Het is mogelijk om vormen toe te voegen aan een toegevoegde groepvorm om deze te vullen of om een eigenschap van de groepvorm te benaderen. Om een groepvorm aan een dia toe te voegen met Aspose.Slides voor Android via Java:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
1. Verkrijg de referentie van een dia door zijn Index te gebruiken.  
1. Voeg een groepvorm toe aan de dia.  
1. Voeg de vormen toe aan de toegevoegde groepvorm.  
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Het onderstaande voorbeeld voegt een groepvorm toe aan een dia.

```java
// Instantieer de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);

    // Benader de vormcollectie van de dia's
    IShapeCollection slideShapes = sld.getShapes();

    // Voeg een groepvorm toe aan de dia
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Voeg vormen toe binnen de toegevoegde groepvorm
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Voeg een frame toe aan de groepvorm
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Schrijf het PPTX-bestand naar schijf
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Toegang tot de AltText‑eigenschap**
Dit onderwerp toont eenvoudige stappen, inclusief code‑voorbeelden, voor het toevoegen van een groepvorm en het benaderen van de AltText‑eigenschap van groepvormen op dia's. Om de AltText van een groepvorm in een dia te benaderen met Aspose.Slides voor Android via Java:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse die een PPTX‑bestand voorstelt.  
1. Verkrijg de referentie van een dia door zijn Index te gebruiken.  
1. Benader de vormcollectie van de dia's.  
1. Benader de groepvorm.  
1. Benader de [AlternativeText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShape#getAlternativeText--) eigenschap.

Het onderstaande voorbeeld benadert de alternatieve tekst van de groepvorm.

```java
// Instantieer de Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation("AltText.pptx");
try {
    // Haal de eerste dia op
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Benader de vormcollectie van de dia's
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Benader de groepvorm.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Benader de AltText-eigenschap
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Wordt geneste groepering (een groep binnen een groep) ondersteund?**

Ja. De [GroupShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/groupshape/) heeft een [getParentGroup](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getParentGroup--)‑methode, die direct aangeeft dat hiërarchie wordt ondersteund (een groep kan een kind zijn van een andere groep).

**Hoe kan ik de z‑volgorde van de groep ten opzichte van andere objecten op de dia regelen?**

Gebruik de [GroupShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/groupshape/)‑methode [getZOrderPosition](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getZOrderPosition--) om de positie ervan in de weergavestack te inspecteren.

**Kan ik verplaatsen/bewerken/degroeperen voorkomen?**

Ja. Het vergrendelingsgedeelte van de groep wordt blootgesteld via [getGroupShapeLock](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--), waardoor u bewerkingen op het object kunt beperken.