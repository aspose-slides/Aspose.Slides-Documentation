---
title: Groepspresentatievormen in Java
linktitle: Vormgroep
type: docs
weight: 40
url: /nl/java/group/
keywords:
- groepsvorm
- vormgroep
- groep toevoegen
- alternatieve tekst
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u vormen in PowerPoint-presentaties kunt groeperen en degroeperen met Aspose.Slides voor Java - snelle, stapsgewijze handleiding met gratis Java-code."
---
## **Overzicht**

Dit artikel legt uit hoe u kunt werken met groepsvormen in Aspose.Slides. Het laat zien hoe u een groepsvorm aan een dia kunt toevoegen, vormen erin kunt plaatsen en de bijgewerkte presentatie kunt opslaan. Het demonstreert ook hoe u vormen die zich binnen een groep bevinden kunt benaderen en hun `AlternativeText`‑waarden kunt lezen. Daarnaast behandelt het artikel kort gerelateerde mogelijkheden van groepsvormen, zoals geneste groepen, z‑volgorde en vergrendelingsopties.

## **Groepsvorm toevoegen**
Aspose.Slides ondersteunt het werken met groepsvormen op dia’s. Deze functie helpt ontwikkelaars rijkere presentaties te ondersteunen. Aspose.Slides for Java ondersteunt het toevoegen of benaderen van groepsvormen. Het is mogelijk om vormen toe te voegen aan een toegevoegde groepsvorm om deze te vullen of om enige eigenschap van de groepsvorm te benaderen. Om een groepsvorm aan een dia toe te voegen met Aspose.Slides for Java:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)-klasse.  
2. Verkrijg de referentie van een dia door zijn Index te gebruiken.  
3. Voeg een groepsvorm toe aan de dia.  
4. Voeg de vormen toe aan de toegevoegde groepsvorm.  
5. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Het voorbeeld hieronder voegt een groepsvorm toe aan een dia.

```java
// Instantieer Presentation-klasse
Presentation pres = new Presentation();
try {
    // Verkrijg de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Benader de vormencollectie van dia's
    IShapeCollection slideShapes = sld.getShapes();

    // Voeg een groepsvorm toe aan de dia
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Voeg vormen toe binnen de toegevoegde groepsvorm
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Voeg groepsvormframe toe
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Schrijf het PPTX-bestand naar schijf
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Toegang tot de AltText‑eigenschap**
Dit onderwerp toont eenvoudige stappen, compleet met code‑voorbeelden, voor het toevoegen van een groepsvorm en het benaderen van de AltText‑eigenschap van groepsvormen op dia’s. Om AltText van een groepsvorm op een dia te benaderen met Aspose.Slides for Java:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)-klasse die een PPTX‑bestand vertegenwoordigt.  
2. Verkrijg de referentie van een dia door zijn Index te gebruiken.  
3. Benader de vormencollectie van dia’s.  
4. Benader de groepsvorm.  
5. Benader de [AlternativeText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShape#getAlternativeText--)‑eigenschap.

Het voorbeeld hieronder benadert de alternatieve tekst van een groepsvorm.

```java
// Instantieer Presentation-klasse die PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation("AltText.pptx");
try {
    // Verkrijg de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Benader de vormencollectie van dia's
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Benader de groepsvorm.
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

**Is geneste groepering (een groep binnen een groep) ondersteund?**

Ja. [GroupShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/groupshape/) heeft een [getParentGroup](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getParentGroup--)‑methode, die direct de hiërarchische ondersteuning aangeeft (een groep kan een kind zijn van een andere groep).

**Hoe regel ik de z‑volgorde van de groep ten opzichte van andere objecten op de dia?**

Gebruik de [GroupShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/groupshape/)‑[getZOrderPosition](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getZOrderPosition--)‑methode om zijn positie in de weergave‑stack te inspecteren.

**Kan ik verplaatsen/bewerken/degroeperen voorkomen?**

Ja. Het vergrendelingsgedeelte van de groep wordt blootgesteld via [GroupShapeLock](https://reference.aspose.com/slides/nl/java/com.aspose.slides/groupshape/#getGroupShapeLock--), waarmee u operaties op het object kunt beperken.