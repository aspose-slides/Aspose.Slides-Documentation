---
title: "Vergelijk presentatiedia's in Java"
linktitle: "Vergelijk dia's"
type: docs
weight: 50
url: /nl/java/compare-slides/
keywords:
- "dia's vergelijken"
- "dia vergelijking"
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Vergelijk PowerPoint- en OpenDocument-presentaties programmatisch met Aspose.Slides voor Java. Identificeer dia-verschillen snel in de code."
---
## **Overzicht**

Aspose.Slides stelt u in staat om dia’s, lay-outdia’s en masterdia’s te vergelijken met behulp van de `equals`‑methode die wordt geleverd door de `IBaseSlide`‑interface en de `BaseSlide`‑klasse. Deze methode geeft `true` terug wanneer de vergeleken dia’s identiek zijn in hun structuur en statische inhoud.

## **Vergelijk twee dia’s**
De equals‑methode is toegevoegd aan de [IBaseSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IBaseSlide) interface en de [BaseSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/BaseSlide) klasse. Ze geeft true terug voor de dia’s/lay-out en dia’s/master die identiek zijn qua structuur en statische inhoud.  

Twee dia’s zijn gelijk als alle vormen, stijlen, teksten, animaties en andere instellingen, enz., gelijk zijn. De vergelijking houdt geen rekening met unieke identifier‑waarden, bijvoorbeeld SlideId, en dynamische inhoud, bijvoorbeeld de huidige datumwaarde in een datum‑placeholder.

```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
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

**Heeft het feit dat een dia verborgen is invloed op de vergelijking van de dia’s zelf?**

[Hidden status](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#getHidden--) is een eigenschap op presentatie-/afspeelniveau, niet van visuele inhoud. De gelijkheid van twee specifieke dia’s wordt bepaald door hun structuur en statische inhoud; het feit dat een dia verborgen is, maakt de dia’s niet verschillend.

**Worden hyperlinks en hun parameters in aanmerking genomen?**

Ja. Links maken deel uit van de statische inhoud van een dia. Als de URL of de hyperlink‑actie verschilt, wordt dit doorgaans beschouwd als een verschil in statische inhoud.

**Als een grafiek verwijst naar een extern Excel‑bestand, wordt dan de inhoud van dat bestand in aanmerking genomen?**

Nee. De vergelijking wordt uitgevoerd op basis van de dia’s zelf. Externe gegevensbronnen worden meestal niet ingelezen tijdens de vergelijking; alleen wat aanwezig is in de structuur en statische status van de dia wordt in overweging genomen.