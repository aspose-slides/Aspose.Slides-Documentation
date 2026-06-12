---
title: Grafiektabellen aanpassen in presentaties met PHP
linktitle: Datatabel
type: docs
url: /nl/php-java/chart-data-table/
keywords:
- grafiekgegevens
- datatabel
- lettertype-eigenschappen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Pas grafiektabellen aan voor PPT en PPTX met Aspose.Slides voor PHP via Java om de efficiëntie en aantrekkelijkheid in presentaties te verhogen."
---
## **Overzicht**

Dit artikel legt uit hoe je met grafiek‑datatabellen werkt in Aspose.Slides. Het laat zien hoe je een datatabel voor een grafiek weergeeft en de tekstopmaak ervan aanpast door eigenschappen van het lettertype in te stellen, zoals vetgedrukt en letterhoogte. Het voorbeeld laat zien hoe je een presentatie laadt, een grafiek toevoegt, de grafiek‑datatabel inschakelt, lettertype‑instellingen toepast en de bijgewerkte presentatie opslaat.

Het bevat ook korte antwoorden op veelgestelde vragen over het tonen van legende‑sleutels in een grafiek‑datatabel, het behouden van de datatabel bij export, werken met grafieken die zijn geladen uit bestaande presentaties of sjablonen, en het identificeren van grafieken waarbij de datatabel is ingeschakeld.

## **Lettertype‑eigenschappen instellen voor een grafiek‑datatabel**
Aspose.Slides voor PHP via Java biedt ondersteuning voor het wijzigen van de kleur van categorieën in een reekskleur.  

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑object aan.  
1. Voeg een grafiek toe aan de dia.  
1. Stel de grafiek‑tabel in.  
1. Stel de letterhoogte in.  
1. Sla de aangepaste presentatie op.  

Hieronder staat een voorbeeld.  

```php
  # Lege presentatie maken
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik kleine legende‑sleutels naast de waarden in de datatabel van de grafiek tonen?**

Ja. De datatabel ondersteunt [legenda‑sleutels](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datatable/setshowlegendkey/), en je kunt ze in- of uitschakelen.

**Wordt de datatabel behouden bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert de grafiek als onderdeel van de dia, dus de geëxporteerde [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/nl/php-java/convert-powerpoint-to-html/)/[afbeelding](/slides/nl/php-java/convert-powerpoint-to-png/) bevat de grafiek met de bijbehorende datatabel.

**Worden datatabellen ondersteund voor grafieken die uit een sjabloonbestand komen?**

Ja. Voor elke grafiek die uit een bestaande presentatie of sjabloon is geladen, kun je controleren en wijzigen of een datatabel [wordt weergegeven](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/hasdatatable/) via de eigenschappen van de grafiek.

**Hoe kan ik snel vinden welke grafieken in een bestand de datatabel hebben ingeschakeld?**

Bekijk de eigenschap van elke grafiek die aangeeft of de datatabel [wordt weergegeven](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/hasdatatable/), en doorloop de dia’s om de grafieken te identificeren waarvoor deze is ingeschakeld.