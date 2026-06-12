---
title: "Vergelijk presentatiedia's in JavaScript"
linktitle: "Dia's vergelijken"
type: docs
weight: 50
url: /nl/nodejs-java/compare-slides/
keywords:
- "dia's vergelijken"
- "dia vergelijking"
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Vergelijk PowerPoint- en OpenDocument-presentaties programmatisch met Aspose.Slides voor Node.js via Java. Identificeer dia-verschillen in code snel."
---
## **Overzicht**

Aspose.Slides stelt u in staat om dia's, lay-outdia's en masterdia's te vergelijken met behulp van de `equals`-methode die wordt geleverd door de `BaseSlide`-klasse. Deze methode retourneert `true` wanneer de vergeleken dia's identiek zijn in hun structuur en statische inhoud.

## **Vergelijk twee dia's**

De `Equals`-methode is toegevoegd aan de [BaseSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/BaseSlide)-klasse en de [BaseSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/BaseSlide)-klasse. Deze retourneert `true` voor de dia's/lay-out en dia's/master die identiek zijn in hun structuur en statische inhoud.

Twee dia's zijn gelijk als alle vormen, stijlen, teksten, animaties en andere instellingen, enz., gelijk zijn. De vergelijking houdt geen rekening met unieke identifier-waarden, bijvoorbeeld SlideId, en met dynamische inhoud, bijvoorbeeld de huidige datumwaarde in een datum-plaatsaanduiding.

```javascript
var presentation1 = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    var presentation2 = new aspose.slides.Presentation("HelloWorld.pptx");
    try {
        for (var i = 0; i < presentation1.getMasters().size(); i++) {
            for (var j = 0; j < presentation2.getMasters().size(); j++) {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j))) {
                    console.log(java.callStaticMethodSync("java.lang.String", "format", "SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
                }
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```

## **FAQ**

**Heeft het feit dat een dia verborgen is invloed op de vergelijking van de dia's zelf?**

[Hidden status](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/gethidden/) is een eigenschap op presentatie-/afspeelniveau, geen visuele inhoud. De gelijkheid van twee specifieke dia's wordt bepaald door hun structuur en statische inhoud; het enige feit dat een dia verborgen is, maakt de dia's niet verschillend.

**Worden hyperlinks en hun parameters in aanmerking genomen?**

Ja. Links maken deel uit van de statische inhoud van een dia. Als de URL of de hyperlink-actie verschilt, wordt dit doorgaans beschouwd als een verschil in statische inhoud.

**Als een diagram verwijst naar een extern Excel-bestand, wordt de inhoud van dat bestand dan in aanmerking genomen?**

Nee. De vergelijking wordt uitgevoerd op basis van de dia's zelf. Externe gegevensbronnen worden doorgaans niet gelezen tijdens het vergelijken; alleen wat aanwezig is in de structuur en statische status van de dia wordt in aanmerking genomen.