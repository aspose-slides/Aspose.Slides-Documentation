---
title: Vergelijk presentatiedia's op Android
linktitle: Dia's vergelijken
type: docs
weight: 50
url: /nl/androidjava/compare-slides/
keywords:
- dia's vergelijken
- dia-vergelijking
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Vergelijk PowerPoint- en OpenDocument-presentaties op programmeerwijze met Aspose.Slides voor Android. Identificeer snel dia‑verschillen in Java‑code."
---
## **Overzicht**

Aspose.Slides stelt u in staat om dia's, lay-outdia's en masterdia's te vergelijken met behulp van de `equals`‑methode die wordt geleverd door de `IBaseSlide`‑interface en de `BaseSlide`‑klasse. Deze methode retourneert `true` wanneer de vergeleken dia's identiek zijn in hun structuur en statische inhoud.

## **Vergelijk twee dia's**
De Equals‑methode is toegevoegd aan de [IBaseSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IBaseSlide) interface en de [BaseSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/BaseSlide) klasse. Deze retourneert true voor de dia‑/layout‑ en dia‑/master‑dia's die identiek zijn qua structuur en statische inhoud.  

Twee dia's zijn gelijk als alle vormen, stijlen, teksten, animaties en andere instellingen, enz., gelijk zijn. De vergelijking houdt geen rekening met unieke identificatiewaarden, zoals SlideId, en dynamische inhoud, zoals de huidige datumwaarde in een datum‑plaatsaanduiding.

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

**Heeft het feit dat een dia verborgen is invloed op de vergelijking van de dia's zelf?**

[Hidden status](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slide/#getHidden--) is een eigenschap op presentatieniveau/weergave‑niveau, niet visuele inhoud. De gelijkheid van twee specifieke dia's wordt bepaald door hun structuur en statische inhoud; het feit dat een dia verborgen is maakt de dia's niet verschillend.

**Worden hyperlinks en hun parameters in aanmerking genomen?**

Ja. Links maken deel uit van de statische inhoud van een dia. Als de URL of de hyperlink‑actie verschilt, wordt dit meestal beschouwd als een verschil in statische inhoud.

**Als een grafiek verwijst naar een extern Excel‑bestand, worden de inhoud van dat bestand dan meegenomen?**

Nee. De vergelijking wordt uitgevoerd op basis van de dia's zelf. Externe gegevensbronnen worden doorgaans niet gelezen op het moment van vergelijken; alleen wat aanwezig is in de structuur en statische toestand van de dia wordt in aanmerking genomen.