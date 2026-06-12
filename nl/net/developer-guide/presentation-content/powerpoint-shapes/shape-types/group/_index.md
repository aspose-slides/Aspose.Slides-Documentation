---
title: Groepsvormen in presentaties met .NET
linktitle: Vormgroep
type: docs
weight: 40
url: /nl/net/group/
keywords:
- groepsvorm
- vormgroep
- groep toevoegen
- alternatieve tekst
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u vormen groepeert en degroepeert in PowerPoint-presentaties met Aspose.Slides voor .NET — een snelle, stapsgewijze gids met gratis C#-code."
---
## **Overzicht**

Dit artikel legt uit hoe u met groepsvormen in Aspose.Slides kunt werken. Het toont hoe u een groepsvorm aan een dia toevoegt, vormen erin plaatst en de bijgewerkte presentatie opslaat. Het laat ook zien hoe u de vormen die zich in een groep bevinden kunt benaderen en hun `AlternativeText`-waarden kunt lezen. Daarnaast behandelt het artikel kort gerelateerde mogelijkheden van groepsvormen, zoals geneste groepen, z-order en vergrendelingsopties.

## **Een groepsvorm toevoegen**
Aspose.Slides ondersteunt het werken met groepsvormen op dia’s. Deze functie helpt ontwikkelaars om rijkere presentaties te ondersteunen. Aspose.Slides voor .NET ondersteunt het toevoegen of benaderen van groepsvormen. Het is mogelijk om vormen toe te voegen aan een toegevoegde groepsvorm om deze te vullen of om een eigenschap van de groepsvorm te benaderen. Om een groepsvorm aan een dia toe te voegen met Aspose.Slides voor .NET:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)-klasse.
2. Verkrijg de referentie van een dia door gebruik te maken van de Index.
3. Voeg een groepsvorm toe aan de dia.
4. Voeg de vormen toe aan de toegevoegde groepsvorm.
5. Sla de gewijzigde presentatie op als een PPTX-bestand.

Het voorbeeld hieronder voegt een groepsvorm toe aan een dia.

```c#
// Instantieer Presentation-klasse 
using (Presentation pres = new Presentation())
{
    // Verkrijg de eerste dia 
    ISlide sld = pres.Slides[0];

    // Benader de vormverzameling van de dia's 
    IShapeCollection slideShapes = sld.Shapes;

    // Voeg een groepsvorm toe aan de dia 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Voeg vormen toe binnen de toegevoegde groepsvorm 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Voeg frame van de groepsvorm toe 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Schrijf het PPTX-bestand naar schijf 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```

## **De AltText‑eigenschap benaderen**
Dit onderwerp toont eenvoudige stappen, inclusief code-voorbeelden, voor het toevoegen van een groepsvorm en het benaderen van de AltText‑eigenschap van groepsvormen op dia’s. Om de AltText van een groepsvorm in een dia te benaderen met Aspose.Slides voor .NET:

1. Instantieer de `Presentation`-klasse die een PPTX-bestand vertegenwoordigt.
2. Verkrijg de referentie van een dia door gebruik te maken van de Index.
3. Benader de vormcollectie van de dia’s.
4. Benader de groepsvorm.
5. Benader de AltText‑eigenschap.

Het voorbeeld hieronder benadert de alternatieve tekst van de groepsvorm.

```c#
// Instantieer de Presentation-klasse die een PPTX-bestand voorstelt
Presentation pres = new Presentation("AltText.pptx");

// Verkrijg de eerste dia
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Benader de vormverzameling van de dia's
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Benader de groepsvorm.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Benader de AltText‑eigenschap
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **FAQ**

**Wordt geneste groepering (een groep binnen een groep) ondersteund?**

Ja. [GroupShape](https://reference.aspose.com/slides/nl/net/aspose.slides/groupshape/) heeft een [ParentGroup](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/parentgroup/)‑eigenschap, die direct hiërarchische ondersteuning aangeeft (een groep kan een kind van een andere groep zijn).

**Hoe kan ik de z-order van een groep ten opzichte van andere objecten op de dia regelen?**

Gebruik de [ZOrderPosition](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/zorderposition/)‑eigenschap van de [GroupShape](https://reference.aspose.com/slides/nl/net/aspose.slides/groupshape/) om de positie ervan in de weergave‑stack te inspecteren.

**Kan ik verplaatsen/bewerken/ontgroeperen voorkomen?**

Ja. Het vergrendelingsgedeelte van de groep wordt blootgesteld via [GroupShapeLock](https://reference.aspose.com/slides/nl/net/aspose.slides/groupshape/groupshapelock/), waarmee u bewerkingen op het object kunt beperken.