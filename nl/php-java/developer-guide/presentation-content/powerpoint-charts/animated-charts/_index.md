---
title: Animeer PowerPoint-diagrammen in PHP
linktitle: Geanimeerde diagrammen
type: docs
weight: 80
url: /nl/php-java/animated-charts/
keywords:
- diagram
- geanimeerd diagram
- diagramanimatie
- diagramserie
- diagramcategorie
- serie‑element
- categorie‑element
- effect toevoegen
- effecttype
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Maak verbluffende geanimeerde diagrammen met Aspose.Slides for PHP via Java. Geef presentaties een boost met dynamische visuals in PPT‑ en PPTX‑bestanden — begin nu."
---
## **Introductie**

Aspose.Slides for PHP via Java ondersteunt het animeren van diagramonderdelen. **Series**, **Categorieën**, **Series-elementen**, **Categorieën-elementen** kunnen worden geanimeerd met de methode [Sequence::addEffect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sequence/#addEffect) en twee enumeraties [EffectChartMajorGroupingType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/EffectChartMajorGroupingType) en [EffectChartMinorGroupingType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/EffectChartMinorGroupingType).

## **Animatie van diagramseries**
Als je een diagramserie wilt animeren, schrijf je de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Verkrijg een referentie naar het diagramobject.
1. Animeer de serie.
1. Schrijf het presentatiebestand naar de schijf.

In het onderstaande voorbeeld hebben we diagramseries geanimeerd.

```php
  # Instantieer de Presentation‑klasse die een presentatiebestand vertegenwoordigt
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Verkrijg een referentie naar het diagramobject
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animeer de serie
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Schrijf de gewijzigde presentatie naar schijf
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animatie van diagramcategorie**
Als je een diagramcategorie wilt animeren, schrijf je de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Verkrijg een referentie naar het diagramobject.
1. Animeer de categorie.
1. Schrijf het presentatiebestand naar de schijf.

In het onderstaande voorbeeld hebben we diagramcategorie geanimeerd.

```php
  # Instantieer de Presentation‑klasse die een presentatiebestand vertegenwoordigt
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animatie in een serie‑element**
Als je serie‑elementen wilt animeren, schrijf je de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Verkrijg een referentie naar het diagramobject.
1. Animeer serie‑elementen.
1. Schrijf het presentatiebestand naar de schijf.

In het onderstaande voorbeeld hebben we de elementen van de serie geanimeerd.

```php
  # Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Verkrijg een referentie naar het diagramobject
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animeer serie-elementen
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Schrijf het presentatiebestand naar schijf
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animatie in een categorie‑element**
Als je categorie‑elementen wilt animeren, schrijf je de code volgens de onderstaande stappen:

1. Laad een presentatie.
1. Verkrijg een referentie naar het diagramobject.
1. Animeer categorie‑elementen.
1. Schrijf het presentatiebestand naar de schijf.

In het onderstaande voorbeeld hebben we categorie‑elementen geanimeerd.

```php
  # Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Verkrijg een referentie naar het diagramobject
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animeer categorie‑elementen
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Schrijf het presentatiebestand naar schijf
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Worden verschillende effecttypen (bijv. ingang, nadruk, uitgang) ondersteund voor diagrammen zoals voor gewone vormen?**

Ja. Een diagram wordt behandeld als een vorm, dus het ondersteunt de standaard animatie‑effecttypen, waaronder ingang, nadruk en uitgang, met volledige controle via de tijdlijn van de dia en animatiesequenties.

**Kan ik diagramanimatie combineren met dia‑overgangen?**

Ja. [Transitions](/slides/nl/php-java/slide-transition/) worden toegepast op de dia, terwijl animatie‑effecten worden toegepast op objecten op de dia. Je kunt beide tegelijk gebruiken in dezelfde presentatie en ze onafhankelijk van elkaar besturen.

**Worden diagramanimaties behouden bij het opslaan naar PPTX?**

Ja. Wanneer je [save to PPTX](/slides/nl/php-java/save-presentation/) gebruikt, blijven alle animatie‑effecten en hun volgorde behouden omdat ze deel uitmaken van het native animatiemodel van de presentatie.

**Kan ik bestaande diagramanimaties uit een presentatie lezen en aanpassen?**

Ja. De API biedt toegang tot de tijdlijn van de dia, de sequenties en de effecten, zodat je bestaande diagramanimaties kunt inspecteren en aanpassen zonder alles opnieuw te hoeven maken.

**Kan ik een video maken die diagramanimaties bevat met Aspose.Slides?**

Ja. Je kunt een presentatie [export a presentation to video](/slides/nl/php-java/convert-powerpoint-to-video/) exporteren naar video terwijl je animaties behoudt, de timing en andere exportinstellingen configureert, zodat het resulterende fragment de geanimeerde weergave reflecteert.