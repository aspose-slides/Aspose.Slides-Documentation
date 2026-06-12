---
title: "Presentatiedia's vergelijken in .NET"
linktitle: "Dia's vergelijken"
type: docs
weight: 50
url: /nl/net/compare-slides/
keywords:
- dia's vergelijken
- dia-vergelijking
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Vergelijk PowerPoint- en OpenDocument-presentaties programmatisch met Aspose.Slides voor .NET. Identificeer slide-verschillen snel in code."
---
## **Overzicht**

Aspose.Slides stelt u in staat om dia’s, lay‑outdia’s en mastdia’s te vergelijken met behulp van de `Equals`‑methode die wordt geleverd door de `IBaseSlide`‑interface en de `BaseSlide`‑klasse. Deze methode retourneert `true` wanneer de vergeleken dia’s identiek zijn in hun structuur en statische inhoud.

## **Twee dia’s vergelijken**

De `Equals`‑methode is toegevoegd aan de [IBaseSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide) interface en de [BaseSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/baseslide) klasse. Ze retourneert `true` voor dia’s/lay‑outs en dia’s/mastdia’s die identiek zijn qua structuur en statische inhoud.

Twee dia’s zijn gelijk als alle vormen, stijlen, teksten, animaties en andere instellingen overeenkomen, enz. De vergelijking houdt geen rekening met unieke identifier‑waarden, zoals SlideId, en met dynamische inhoud, zoals de huidige datumbaarde in een datum‑placeholder.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```

## **FAQ**

**Beïnvloedt het feit dat een dia verborgen is de vergelijking van de dia’s zelf?**

[Hidden status](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/hidden/) is een eigenschap op presentatieniveau/weergaveniveau, niet een visuele inhoud. De gelijkheid van twee specifieke dia’s wordt bepaald door hun structuur en statische inhoud; het eenvoudige feit dat een dia verborgen is maakt de dia’s niet verschillend.

**Worden hyperlinks en hun parameters in overweging genomen?**

Ja. Links maken deel uit van de statische inhoud van een dia. Als de URL of de hyperlink‑actie verschilt, wordt dit meestal beschouwd als een verschil in statische inhoud.

**Als een chart verwijst naar een extern Excel‑bestand, worden de inhoud van dat bestand dan in overweging genomen?**

Nee. De vergelijking wordt uitgevoerd op basis van de dia’s zelf. Externe gegevensbronnen worden over het algemeen niet gelezen op het moment van de vergelijking; alleen wat aanwezig is in de structuur en statische staat van de dia wordt meegenomen.