---
title: Vergelijk presentatie-dia's in C++
linktitle: Vergelijk Dia's
type: docs
weight: 50
url: /nl/cpp/compare-slides/
keywords:
- dia's vergelijken
- dia-vergelijking
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Vergelijk PowerPoint- en OpenDocument-presentaties programmatisch met Aspose.Slides voor C++. Identificeer dia-verschillen in code snel."
---
## **Overzicht**

Aspose.Slides stelt u in staat dia’s, lay-outdia’s en masterdia’s te vergelijken met behulp van de `Equals`‑methode die wordt geleverd door de `IBaseSlide`‑interface en de `BaseSlide`‑klasse. Deze methode geeft `true` terug wanneer de vergeleken dia’s identiek zijn in hun structuur en statische inhoud.

## **Twee dia’s vergelijken**
De Equals‑methode is toegevoegd aan de IBaseSlide‑interface en de BaseSlide‑klasse. Ze geeft true terug voor de dia’s / lay‑outdia’s / masterdia’s die identiek zijn qua structuur en statische inhoud.

Twee dia’s zijn gelijk als alle vormen, stijlen, teksten, animaties en andere instellingen etc. gelijk zijn. De vergelijking houdt geen rekening met unieke identificatiewaarden, bijvoorbeeld SlideId, en met dynamische inhoud, bijvoorbeeld de huidige datumwaarde in een datum‑placeholder.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSlidesComparison-CheckSlidesComparison.cpp" >}}

## **FAQ**

**Heeft het feit dat een dia verborgen is invloed op de vergelijking van de dia’s zelf?**

[Hidden status](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slide/get_hidden/) is een eigenschap op presentatieniveau/afspeelniveau, niet op visuele inhoud. De gelijkheid van twee specifieke dia’s wordt bepaald door hun structuur en statische inhoud; het louter feit dat een dia verborgen is, maakt de dia’s niet verschillend.

**Worden hyperlinks en hun parameters in aanmerking genomen?**

Ja. Links maken deel uit van de statische inhoud van een dia. Als de URL of de hyperlink‑actie verschilt, wordt dit doorgaans beschouwd als een verschil in statische inhoud.

**Als een grafiek verwijst naar een extern Excel‑bestand, wordt de inhoud van dat bestand dan meegenomen?**

Nee. De vergelijking wordt uitgevoerd op basis van de dia’s zelf. Externe gegevensbronnen worden over het algemeen niet gelezen tijdens het vergelijken; alleen wat zich bevindt in de structuur en de statische toestand van de dia wordt in overweging genomen.