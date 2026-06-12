---
title: Presentatiedia's vergelijken in Python
linktitle: Dia's vergelijken
type: docs
weight: 50
url: /nl/python-net/compare-slides/
keywords:
- dia's vergelijken
- dia vergelijking
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Vergelijk PowerPoint- en OpenDocument-presentaties programmatisch met Aspose.Slides voor Python via .NET. Identificeer snel dia-verschillen in de code."
---
## **Overzicht**

Aspose.Slides stelt u in staat om dia’s, lay‑outdia’s en masterdia’s te vergelijken met behulp van de `equals`‑methode die wordt geleverd door de `BaseSlide`‑klasse. Deze methode retourneert `True` wanneer de vergeleken dia’s identiek zijn in hun structuur en statische inhoud.

## **Vergelijk twee dia’s**
De `equals`‑methode is toegevoegd aan de [BaseSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseslide/)‑klasse. Ze retourneert true voor de dia’s/lay‑out en dia’s/master die identiek zijn qua structuur en statische inhoud.

Twee dia’s zijn gelijk als alle vormen, stijlen, teksten, animaties en andere instellingen overeenkomen. De vergelijking houdt geen rekening met unieke identifier‑waarden, zoals SlideId, en met dynamische inhoud, zoals de huidige datumwaarde in een datum‑placeholder.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i].equals(p2.masters[j]):
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **FAQ**

**Heeft het feit dat een dia verborgen is invloed op de vergelijking van de dia’s zelf?**

De [verborgen status](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/hidden/) is een eigenschap op presentatieniveau/weergaveniveau, niet een visueel inhouds‑onderdeel. De gelijkheid van twee specifieke dia’s wordt bepaald door hun structuur en statische inhoud; het feit dat een dia verborgen is, maakt de dia’s niet verschillend.

**Worden hyperlinks en hun parameters in aanmerking genomen?**

Ja. Links maken deel uit van de statische inhoud van een dia. Als de URL of de hyperlink‑actie verschilt, wordt dit meestal beschouwd als een verschil in statische inhoud.

**Als een grafiek verwijst naar een extern Excel‑bestand, worden de inhoud van dat bestand dan in aanmerking genomen?**

Nee. De vergelijking wordt uitgevoerd op basis van de dia’s zelf. Externe gegevensbronnen worden over het algemeen niet gelezen op het moment van vergelijken; alleen hetgeen dat aanwezig is in de structuur en statische staat van de dia wordt meegenomen.