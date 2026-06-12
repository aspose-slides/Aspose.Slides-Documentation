---
title: Maak miniaturen van presentatievormen in C++
linktitle: Vormminiaturen
type: docs
weight: 70
url: /nl/cpp/shape-thumbnails/
keywords:
- vormminiatuur
- vormafbeelding
- vorm renderen
- vormweergave
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint-dia's met Aspose.Slides voor C++ - maak en exporteer eenvoudig presentatieminiaturen."
---
## **Inleiding**

Aspose.Slides wordt gebruikt om presentatiedocumenten te maken waarbij elke pagina een dia is. Deze dia's kunnen worden bekeken door de presentatiedocumenten te openen met Microsoft PowerPoint. Soms moeten ontwikkelaars echter de afbeeldingen van de vormen afzonderlijk bekijken in een afbeeldingsviewer. In zulke gevallen helpt Aspose.Slides u miniatuurafbeeldingen van de dia‑vormen te genereren. Hoe u deze functie gebruikt, wordt in dit artikel beschreven.
Dit artikel legt uit hoe u dia‑miniaturen op verschillende manieren kunt genereren:

- Een vorm‑miniatuur genereren binnen een dia.
- Een vorm‑miniatuur genereren voor een dia‑vorm met door de gebruiker gedefinieerde afmetingen.
- Een vorm‑miniatuur genereren binnen de grenzen van de weergave van een vorm.

## **Genereer een vorm‑miniatuur vanuit een dia**

Om een vorm‑miniatuur van een willekeurige dia te genereren met Aspose.Slides for C++:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Verkrijg de verwijzing naar een willekeurige dia met behulp van de id of index.
1. Haal de vorm‑miniatuurafbeelding van de opgegeven dia op de standaard schaal op.
1. Sla de miniatuurafbeelding op in een gewenst beeldformaat.

Het onderstaande voorbeeld genereert een vorm‑miniatuur.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Genereer een miniatuur met door de gebruiker gedefinieerde schaalfactor**

Om de vorm‑miniatuur van een willekeurige dia‑vorm te genereren met Aspose.Slides for C++:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Verkrijg de verwijzing naar een willekeurige dia met behulp van de id of index.
1. Haal de miniatuurafbeelding van de opgegeven dia op met vorm‑grenzen.
1. Sla de miniatuurafbeelding op in een gewenst beeldformaat.

Het onderstaande voorbeeld genereert een miniatuur met een door de gebruiker gedefinieerde schaalfactor.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Schalen langs de X- en Y-assen.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Genereer een miniatuur van vormweergave op basis van grenzen**

Deze methode om miniaturen van vormen te maken stelt ontwikkelaars in staat een miniatuur te genereren binnen de grenzen van de weergave van de vorm. Hierbij worden alle vorm‑effecten meegenomen. De gegenereerde vorm‑miniatuur wordt beperkt door de dia‑grenzen. Om een miniatuur van een willekeurige dia‑vorm binnen de grenzen van de weergave te genereren, gebruik de volgende voorbeeldcode:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Verkrijg de verwijzing naar een willekeurige dia met behulp van de id of index.
1. Haal de miniatuurafbeelding van de opgegeven dia op met vorm‑grenzen als weergave.
1. Sla de miniatuurafbeelding op in een gewenst beeldformaat.

Het onderstaande voorbeeld maakt een miniatuur met een door de gebruiker gedefinieerde schaalfactor.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Schalen langs de X- en Y-assen.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Welke afbeeldingsformaten kunnen gebruikt worden bij het opslaan van vorm‑miniaturen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imageformat/), en andere. Vormen kunnen ook [geëxporteerd worden als vector‑SVG](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/writeassvg/) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen Shape‑ en Appearance‑grenzen bij het renderen van een miniatuur?**

`Shape` gebruikt de geometrie van de vorm; `Appearance` houdt rekening met [visuele effecten](/slides/nl/cpp/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm gemarkeerd is als verborgen? Wordt er nog steeds een miniatuur gerenderd?**

Een verborgen vorm blijft onderdeel van het model en kan gerenderd worden; de verborgen‑vlag beïnvloedt de weergave van de diavoorstelling, maar verhindert niet het genereren van de afbeelding van de vorm.

**Worden groepsvormen, grafieken, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als [Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chart/) en [SmartArt](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/smartart/)) kan worden opgeslagen als een miniatuur of als SVG.

**Beïnvloeden systeem‑geïnstalleerde lettertypen de kwaliteit van miniaturen voor tekstvormen?**

Ja. U moet de vereiste lettertypen [beschikbaar stellen](/slides/nl/cpp/custom-font/) (of [lettertype‑substituties configureren](/slides/nl/cpp/font-substitution/)) om ongewenste fallback‑opties en tekst‑herindeling te voorkomen.