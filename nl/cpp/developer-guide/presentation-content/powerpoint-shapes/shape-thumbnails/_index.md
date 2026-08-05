---
title: "Miniaturen van presentatievormen maken in C++"
linktitle: "Vormminiaturen"
type: docs
weight: 70
url: /nl/cpp/shape-thumbnails/
keywords:
- vormminiatuur
- vormafbeelding
- vorm renderen
- vormrendering
- visuele grenzen
- vormgrenzen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint-dia's met Aspose.Slides voor C++ – maak eenvoudig presentatieminiaturen aan en exporteer ze."
---
## **Inleiding**

Aspose.Slides wordt gebruikt om presentatiesbestanden te maken waarin elke pagina een dia is. Deze dia’s kunnen worden bekeken door de presentaties te openen met Microsoft PowerPoint. Soms hebben ontwikkelaars echter de afbeeldingen van de vormen afzonderlijk nodig in een afbeeldingsviewer. In dat geval helpt Aspose.Slides u miniatuurafbeeldingen van de dia‑vormen te genereren. Hoe u deze functionaliteit gebruikt, wordt in dit artikel beschreven.

Dit artikel legt uit hoe u dia‑miniaturen op verschillende manieren kunt genereren:

- Een miniatuur van een vorm binnen een dia genereren.
- Een miniatuur van een vorm voor een dia‑vorm met door de gebruiker gedefinieerde afmetingen genereren.
- Een miniatuur van een vorm binnen de grenzen van de weergave van de vorm genereren.

## **Miniatuur van een vorm uit een dia genereren**

Om een miniatuur van een vorm uit een willekeurige dia te genereren met Aspose.Slides voor C++:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Verkrijg de referentie van een willekeurige dia via zijn ID of index.
1. Haal de miniatuurafbeelding van de vorm van de refererende dia op met de standaard schaal.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingformaat.

Het onderstaande voorbeeld genereert een vormminiatuur.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Miniatuur met door de gebruiker gedefinieerde schaalfactor genereren**

Om de miniatuur van een vorm van een willekeurige dia‑vorm te genereren met Aspose.Slides voor C++:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Verkrijg de referentie van een willekeurige dia via zijn ID of index.
1. Haal de miniatuurafbeelding van de refererende dia op met de vormgrenzen.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingformaat.

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

## **Miniatuur van vormweergave op basis van grenzen maken**

Deze methode om miniaturen van vormen te maken stelt ontwikkelaars in staat een miniatuur te genereren binnen de grenzen van de weergave van de vorm. Hierbij worden alle vormeffecten meegenomen. De gegenereerde vormminiatuur wordt beperkt door de dia‑grenzen. Om een miniatuur van een willekeurige dia‑vorm binnen de grenzen van de weergave te genereren, gebruikt u de volgende voorbeeldcode:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Verkrijg de referentie van een willekeurige dia via zijn ID of index.
1. Haal de miniatuurafbeelding van de refererende dia op met de vormgrenzen als weergave.
1. Sla de miniatuurafbeelding op in een gewenst afbeeldingformaat.

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

## **De werkelijke visuele grenzen van een vorm ophalen**

De frame‑eigenschappen van [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/)—`IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()`, en `IShape::get_Height()`—beschrijven het rechthoekige gebied dat in het presentatiemodel wordt opgeslagen. De inhoud die daadwerkelijk gerenderd wordt, kan buiten dat frame uitstrekken of een ander rechthoekig gebied innemen. Rotatie, randen, pijlpunten, tekstindeling en -overloop, gegenereerde SmartArt‑geometrie en andere render‑effecten kunnen het ingenomen gebied veranderen.

Gebruik [Shape::GetVisualBounds](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getvisualbounds/) om dat ingenomen gebied te berekenen zonder een afbeelding te maken. De methode retourneert een [RectangleF](https://reference.aspose.com/slides/nl/cpp/system.drawing/rectanglef/) in dia‑coördinaten. Het geretourneerde rechthoek wordt niet bijgesneden tot de dia, zodat de coördinaten negatief kunnen zijn wanneer de inhoud buiten de oorsprong van de dia uitstekt.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getvisualbounds/) is momenteel niet gedeclareerd in de [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) interface. Bewaar daarom de vorm die u uit de vormverzameling van de dia haalt als een interface‑waarde en cast deze alleen bij het aanroepen van de methode.

Het volgende voorbeeld haalt en vergelijkt het frame en de visuele grenzen:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

Dezelfde [RectangleF](https://reference.aspose.com/slides/nl/cpp/system.drawing/rectanglef/) kan worden gebruikt om naburige vormen uit te lijnen op zijn `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` of `RectangleF::get_Bottom()` rand; om voldoende ruimte te reserveren in een gegenereerde lay-out; of om inhoud buiten een toegestane regio te detecteren. Visuele grenzen zijn vooral nuttig voor SmartArt, tekstvakken, pijlen, afbeeldingen, geroteerde vormen en groepsvormen, waar het opgeslagen frame mogelijk niet het volledige gerenderde resultaat weergeeft.

Gebruik [Shape::GetVisualBounds](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getvisualbounds/) wanneer u coördinaten nodig heeft voor lay-out of validatie en geen bitmap nodig hebt. Gebruik [IShape::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/getimage/) wanneer u de vorm moet renderen. Met [ShapeThumbnailBounds](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shapethumbnailbounds/) bepaalt `ShapeThumbnailBounds::Shape` de grootte van de afbeelding op basis van de vormgrenzen, inclusief randinstellingen, terwijl `ShapeThumbnailBounds::Appearance` de grootte bepaalt op basis van de weergave van de vorm en het resultaat beperkt tot de dia‑grenzen. Daarentegen retourneert [Shape::GetVisualBounds](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/getvisualbounds/) alleen het berekende rechthoek en snijdt het niet bij tot de dia.

## **FAQ**

**Welke afbeeldingsformaten kunnen worden gebruikt bij het opslaan van vormminiaturen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imageformat/), en andere. Vormen kunnen ook worden [geëxporteerd als vector‑SVG](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/writeassvg/) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen Shape‑ en Appearance‑grenzen bij het renderen van een miniatuur?**

`Shape` gebruikt de geometrie van de vorm; `Appearance` houdt rekening met [visuele effecten](/slides/nl/cpp/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm als verborgen is gemarkeerd? Wordt er nog steeds een miniatuur van gerenderd?**

Een verborgen vorm blijft deel uitmaken van het model en kan worden gerenderd; de verborgen‑vlag beïnvloedt alleen de weergave van de diavoorstelling, maar verhindert niet het genereren van de afbeelding van de vorm.

**Worden groepsvormen, grafieken, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als [Shape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chart/), en [SmartArt](https://reference.aspose.com/slides/nl/cpp/aspose.slides.smartart/smartart/)) kan worden opgeslagen als een miniatuur of als SVG.

**Beïnvloeden systeem‑ingevoegde lettertypen de kwaliteit van miniaturen voor tekstelementen?**

Ja. U moet [de vereiste lettertypen leveren](/slides/nl/cpp/custom-font/) (of [lettertype‑substituties configureren](/slides/nl/cpp/font-substitution/)) om ongewenste fallback‑lettertypen en tekst‑reflow te voorkomen.