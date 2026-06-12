---
title: Diagramlegenda's aanpassen in presentaties met PHP
linktitle: Diagramlegenda
type: docs
url: /nl/php-java/chart-legend/
keywords:
- diagramlegenda
- legenda positie
- lettergrootte
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Pas diagramlegenda's aan met Aspose.Slides for PHP via Java om PowerPoint-presentaties te optimaliseren met op maat gemaakte legenda-opmaak."
---
## **Overzicht**

Aspose.Slides biedt opties om de legenda van diagrammen in PowerPoint‑presentaties aan te passen. Dit artikel laat zien hoe je de positie en grootte van een legenda kunt instellen, het lettertype van de volledige legenda kunt wijzigen en opmaak kunt toepassen op een afzonderlijk legendaveld.

Het behandelt ook verschillende gerelateerde scenario’s in de FAQ, waaronder het gebruik van de niet‑overlay‑modus zodat het plot‑gebied ruimte maakt voor de legenda, het automatisch laten omslaan of afbreken van lange legendalabels, en het laten overerven van de opmaak van de legenda uit het presentatie‑thema wanneer geen expliciete tekst‑‑ en opvullingsinstellingen zijn opgegeven.

## **Legenda‑positionering**
Om de legenda‑eigenschappen in te stellen, volg je de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.
- Verkrijg een referentie naar de dia.
- Voeg een diagram toe aan de dia.
- Stel de eigenschappen van de legenda in.
- Schrijf de presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we de positie en grootte van de diagramlegenda ingesteld.

```php
  # Maak een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    # Krijg een referentie naar de dia
    $slide = $pres->getSlides()->get_Item(0);
    # Voeg een gegroepeerde kolomgrafiek toe op de dia
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Stel legende-eigenschappen in
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Schrijf de presentatie naar schijf
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lettergrootte van een legenda instellen**
Aspose.Slides for PHP via Java maakt het mogelijk om de lettergrootte van de legenda te bepalen. Volg de onderstaande stappen:

- Instantieer de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.
- Maak het standaarddiagram aan.
- Stel de lettergrootte in.
- Stel de minimum‑aswaarde in.
- Stel de maximum‑aswaarde in.
- Schrijf de presentatie naar schijf.

```php
  # Maak een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lettergrootte van een afzonderlijk legendaveld instellen**
Aspose.Slides for PHP via Java maakt het mogelijk om de lettergrootte van individuele legendavelden te bepalen. Volg de onderstaande stappen:

- Instantieer de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.
- Maak het standaarddiagram aan.
- Open het gewenste legendaveld.
- Stel de lettergrootte in.
- Stel de minimum‑aswaarde in.
- Stel de maximum‑aswaarde in.
- Schrijf de presentatie naar schijf.

```php
  # Maak een instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik de legenda activeren zodat het diagram automatisch ruimte hiervoor reserveert in plaats van deze erboven te leggen?**

Ja. Gebruik de niet‑overlay‑modus ([setOverlay(false)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/legend/setoverlay/)); in dat geval krimpt het plot‑gebied om de legenda te huisvesten.

**Kan ik legendalabels op meerdere regels laten weergeven?**

Ja. Lange labels worden automatisch afgebroken wanneer er onvoldoende ruimte is; geforceerde regeleinden worden ondersteund via nieuwe‑regel‑tekens in de serienaam.

**Hoe zorg ik ervoor dat de legenda de kleuren uit het themaschema van de presentatie overneemt?**

Stel geen expliciete kleuren, opvullingen of lettertypen in voor de legenda of de tekst ervan. Ze zullen dan overerven van het thema en correct worden bijgewerkt wanneer het ontwerp verandert.