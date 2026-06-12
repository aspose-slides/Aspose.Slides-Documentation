---
title: Groepsvormen in presentaties in JavaScript
linktitle: Vormgroep
type: docs
weight: 40
url: /nl/nodejs-java/group/
keywords:
- groepsvorm
- vormgroep
- groep toevoegen
- alternatieve tekst
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u vormen kunt groeperen en degroeperen in PowerPoint presentaties met Aspose.Slides voor Node.js via Java — een snelle, stapsgewijze handleiding met gratis JavaScript code."
---
## **Overview**

Dit artikel legt uit hoe u kunt werken met groepsvormen in Aspose.Slides. Het laat zien hoe u een groepsvorm aan een dia toevoegt, vormen erin plaatst en de bijgewerkte presentatie opslaat. Het laat ook zien hoe u vormen die zich in een groep bevinden kunt benaderen en hun `AlternativeText`‑waarden kunt lezen. Daarnaast bespreekt het kort gerelateerde mogelijkheden van groepsvormen, zoals geneste groepen, z‑volgorde en vergrendelingsopties.

## **Add Group Shape**
Aspose.Slides ondersteunt het werken met groepsvormen op dia's. Deze functie helpt ontwikkelaars om rijkere presentaties te maken. Aspose.Slides for Node.js via Java ondersteunt het toevoegen of benaderen van groepsvormen. Het is mogelijk om vormen toe te voegen aan een toegevoegde groepsvorm om deze te vullen of een eigenschap van de groepsvorm te benaderen. Om een groepsvorm aan een dia toe te voegen met Aspose.Slides for Node.js via Java:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Verkrijg de referentie van een dia door gebruik te maken van de Index.
1. Voeg een groepsvorm toe aan de dia.
1. Voeg de vormen toe aan de toegevoegde groepsvorm.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

Het voorbeeld hieronder voegt een groepsvorm toe aan een dia.

```javascript
// Instantieer Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    // Benader de vormcollectie van de dia's
    var slideShapes = sld.getShapes();
    // Voeg een groepsvorm toe aan de dia
    var groupShape = slideShapes.addGroupShape();
    // Voeg vormen toe binnen de toegevoegde groepsvorm
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Voeg groepsvormframe toe
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Schrijf het PPTX-bestand naar schijf
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Access AltText Property**
Dit onderwerp toont eenvoudige stappen, voorzien van code‑voorbeelden, voor het toevoegen van een groepsvorm en het benaderen van de AltText‑eigenschap van groepsvormen op dia's. Om de AltText van een groepsvorm op een dia te benaderen met Aspose.Slides for Node.js via Java:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse die een PPTX‑bestand vertegenwoordigt.
1. Verkrijg de referentie van een dia door gebruik te maken van de Index.
1. Benader de vormcollectie van de dia's.
1. Benader de groepsvorm.
1. Roep de [getAlternativeText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Shape#getAlternativeText--)‑eigenschap aan.

Het voorbeeld hieronder benadert de alternatieve tekst van de groepsvorm.

```javascript
// Instantieer Presentation-klasse die een PPTX-bestand vertegenwoordigt
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Haal de eerste dia op
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Benader de vormcollectie van de dia's
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Benader de groepsvorm.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Benader de AltText‑eigenschap
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Is nested grouping (a group inside a group) supported?**

Ja. [GroupShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/groupshape/) heeft een [getParentGroup](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getparentgroup/)‑methode, die rechtstreeks aangeeft dat hiërarchie wordt ondersteund (een groep kan een kind van een andere groep zijn).

**How do I control the group’s z-order relative to other objects on the slide?**

Gebruik de [GroupShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/groupshape/)‑[getZOrderPosition](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/getzorderposition/)‑methode om de positie in de weergave‑stack te inspecteren.

**Can I prevent moving/editing/ungrouping?**

Ja. Het vergrendelings‑gedeelte van de groep wordt blootgesteld via [GroupShapeLock](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/groupshape/getgroupshapelock/), waarmee u bewerkingen op het object kunt beperken.