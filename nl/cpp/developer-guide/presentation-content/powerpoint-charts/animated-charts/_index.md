---
title: Animeer PowerPoint-grafieken in C++
linktitle: Geanimeerde grafieken
type: docs
weight: 80
url: /nl/cpp/animated-charts/
keywords:
- grafiek
- geanimeerde grafiek
- grafiekanimatie
- grafiekserie
- grafiekcategorie
- serie-element
- categorie-element
- effect toevoegen
- effecttype
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Maak verbluffende geanimeerde grafieken in C++ met Aspose.Slides. Verhoog presentaties met dynamische visuals in PPT- en PPTX-bestanden - begin nu."
---
## **Introductie**

Aspose.Slides ondersteunt het animeren van de grafiekelementen. **Series**, **Categorieën**, **Serierelementen**, **Categorie‑elementen** kunnen geanimeerd worden met de methode [ISequence::AddEffect](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/isequence/addeffect/) en twee enumeraties [EffectChartMajorGroupingType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effectchartmajorgroupingtype/) en [EffectChartMinorGroupingType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/effectchartminorgroupingtype/).

## **Animatie van grafiekserie**
Als je een grafiekserie wilt animeren, schrijf je de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Haal een referentie op van het grafiekobject.
1. Animeer de serie.
1. Schrijf het presentatie‑bestand naar schijf.

In het onderstaande voorbeeld hebben we een grafiekserie geanimeerd.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animatie in een serierelement**
Als je serierelementen wilt animeren, schrijf je de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Haal een referentie op van het grafiekobject.
1. Animeer serierelementen.
1. Schrijf het presentatie‑bestand naar schijf.

In het onderstaande voorbeeld hebben we de serierelementen geanimeerd.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **Animatie van grafiekcategorie**
Als je een grafiekcategorie wilt animeren, schrijf je de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Haal een referentie op van het grafiekobject.
1. Animeer de categorie.
1. Schrijf het presentatie‑bestand naar schijf.

In het onderstaande voorbeeld hebben we de grafiekcategorie geanimeerd.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **Animatie in een categorie‑element**
Als je categorie‑elementen wilt animeren, schrijf je de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Haal een referentie op van het grafiekobject.
1. Animeer categorie‑elementen.
1. Schrijf het presentatie‑bestand naar schijf.

In het onderstaande voorbeeld hebben we de categorie‑elementen geanimeerd.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **FAQ**

**Worden verschillende effecttypen (bijv. binnenkomst, nadruk, uitgang) ondersteund voor grafieken zoals voor gewone vormen?**

Ja. Een grafiek wordt behandeld als een vorm, dus ondersteunt hij de standaard animatie‑effecttypen, inclusief binnenkomst, nadruk en uitgang, met volledige controle via de tijdlijn van de dia en animatie‑reeksen.

**Kan ik grafiekanimatie combineren met dia‑overgangen?**

Ja. [Transitions](/slides/nl/cpp/slide-transition/) worden toegepast op de dia, terwijl animatie‑effecten worden toegepast op objecten op de dia. Je kunt beide samen gebruiken in dezelfde presentatie en ze onafhankelijk beheren.

**Worden grafiekanimaties bewaard bij het opslaan naar PPTX?**

Ja. Wanneer je [save to PPTX](/slides/nl/cpp/save-presentation/) gebruikt, worden alle animatie‑effecten en hun volgorde bewaard omdat ze deel uitmaken van het native animatiemodel van de presentatie.

**Kan ik bestaande grafiekanimaties uit een presentatie lezen en wijzigen?**

Ja. De [API](https://reference.aspose.com/slides/nl/cpp/aspose.slides.animation/) biedt toegang tot de tijdlijn van de dia, de reeksen en de effecten, waardoor je bestaande grafiekanimaties kunt inspecteren en aanpassen zonder alles opnieuw te creëren.

**Kan ik een video maken die grafiekanimaties bevat met Aspose.Slides?**

Ja. Je kunt een presentatie naar video exporteren [/slides/nl/cpp/convert-powerpoint-to-video/](/slides/nl/cpp/convert-powerpoint-to-video/) terwijl je de animaties behoudt, de timing en andere exportinstellingen configureert zodat de resulterende clip de geanimeerde weergave weerspiegelt.